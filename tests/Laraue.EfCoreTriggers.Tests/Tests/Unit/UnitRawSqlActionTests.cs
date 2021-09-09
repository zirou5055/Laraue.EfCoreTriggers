using System;
using Laraue.EfCoreTriggers.Common.SqlGeneration;
using Laraue.EfCoreTriggers.Tests.Tests.Base;
using Xunit;

namespace Laraue.EfCoreTriggers.Tests.Tests.Unit
{
    public abstract class UnitRawSqlActionTests : BaseRawSqlActionTests
    {
        protected readonly ITriggerProvider Provider;

        protected UnitRawSqlActionTests(ITriggerProvider provider)
        {
            Provider = provider;
            Provider.Converters.ExpressionCallConverters.Push(new RawSqlExtensionsNotifyConverter());
        }

        public abstract string ExpectedInsertTriggerRawSqlPlainTextActionSql { get; }

        public abstract string ExpectedInsertTriggerRawSqlNotifyActionSql { get; }

        public abstract string ExpectedDeleteTriggerRawSqlNotifyActionSql { get; }

        public abstract string ExpectedUpdateTriggerRawSqlNotifyActionSql { get; }

        [Fact]
        public override void InsertTriggerRawSqlActionSql()
        {
            Provider.AssertGeneratedInsertTriggerRawActionSql(ExpectedInsertTriggerRawSqlPlainTextActionSql, InsertTirggerRawSqlPlainTextActionExpression!);
        }

        [Fact]
        public override void InsertTriggerRawSqlNotifyConverter()
        {
            Provider.Converters.ExpressionCallConverters.Push(new RawSqlExtensionsNotifyConverter());
            Provider.AssertGeneratedInsertTriggerRawActionSql(ExpectedInsertTriggerRawSqlNotifyActionSql, InsertTriggerRawSqlNotifyActionExpression);
        }

        [Fact]
        public override void DeleteTriggerRawSqlNotifyConverter()
        {
            Provider.Converters.ExpressionCallConverters.Push(new RawSqlExtensionsNotifyConverter());
            Provider.AssertGeneratedDeleteTriggerRawActionSql(ExpectedDeleteTriggerRawSqlNotifyActionSql, DeleteTriggerRawSqlNotifyActionExpression);
        }

        [Fact]
        public override void UpdateTriggerRawSqlNotifyConverter()
        {
            Provider.Converters.ExpressionCallConverters.Push(new RawSqlExtensionsNotifyConverter());
            Provider.AssertGeneratedUpdateTriggerRawActionSql(ExpectedUpdateTriggerRawSqlNotifyActionSql, UpdateTriggerRawSqlNotifyActionExpression);
        }
    }
}
