using System;
using System.Linq.Expressions;
using Laraue.EfCoreTriggers.Common.Extensions;
using Laraue.EfCoreTriggers.Common.SqlGeneration;
using Laraue.EfCoreTriggers.Common.TriggerBuilders.OnDelete;
using Laraue.EfCoreTriggers.Common.TriggerBuilders.OnInsert;
using Laraue.EfCoreTriggers.Common.TriggerBuilders.OnUpdate;
using Laraue.EfCoreTriggers.Tests.Infrastructure;
using Xunit;

namespace Laraue.EfCoreTriggers.Tests.Tests.Unit
{
    public static class TriggerProviderExtensions
    {
        public static void AssertGeneratedInsertTriggerInsertActionSql(this ITriggerProvider provider, string sql, Expression<Func<SourceEntity, DestinationEntity>> expression)
        {
            var trigger = new OnInsertTriggerInsertAction<SourceEntity, DestinationEntity>(expression);

            var generatedSql = trigger.BuildSql(provider);

            Assert.Equal(sql, generatedSql);
        }

        public static void AssertGeneratedInsertTriggerRawActionSql(this ITriggerProvider provider, string sql, Expression<Func<SourceEntity, string>> expression)
        {
            var trigger = new OnInsertTriggerRawAction<SourceEntity>(expression);

            var generatedSql = trigger.BuildSql(provider);

            Assert.Equal(sql, generatedSql);
        }

        public static void AssertGeneratedDeleteTriggerRawActionSql(this ITriggerProvider provider, string sql, Expression<Func<SourceEntity, string>> expression)
        {
            var trigger = new OnDeleteTriggerRawAction<SourceEntity>(expression);

            var generatedSql = trigger.BuildSql(provider);

            Assert.Equal(sql, generatedSql);
        }

        public static void AssertGeneratedUpdateTriggerRawActionSql(this ITriggerProvider provider, string sql, Expression<Func<SourceEntity, SourceEntity, string>> expression)
        {
            var trigger = new OnUpdateTriggerRawAction<SourceEntity>(expression);

            var generatedSql = trigger.BuildSql(provider);

            Assert.Equal(sql, generatedSql);
        }

        public static DynamicDbContext GetDbContext(this IContextOptionsFactory<DynamicDbContext> optionsFactory, Expression<Func<SourceEntity, DestinationEntity>> insertDestinationEntityBasedOnSourceEntityFunc)
        {
            return DynamicDbContextFactory.GetDbContext(
                optionsFactory,
                builder => builder.Entity<SourceEntity>()
                    .AfterInsert(trigger => trigger.Action(
                        action => action.Insert(insertDestinationEntityBasedOnSourceEntityFunc))));
        }
    }
}