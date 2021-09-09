using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Laraue.EfCoreTriggers.Common.Converters.MethodCall;
using Laraue.EfCoreTriggers.Common.SqlGeneration;
using Laraue.EfCoreTriggers.Common.TriggerBuilders;
using Laraue.EfCoreTriggers.Tests.Infrastructure;
using Xunit;

namespace Laraue.EfCoreTriggers.Tests.Tests.Base
{
    public abstract class BaseRawSqlActionTests
    {
        /// <summary>
        /// 
        /// </summary>
        protected Expression<Func<SourceEntity, string>> InsertTirggerRawSqlPlainTextActionExpression = sourceEntity => "RAW SQL;";

        [Fact]
        public abstract void InsertTriggerRawSqlActionSql();

        /// <summary>
        /// 
        /// </summary>
        protected Expression<Func<SourceEntity, string>> InsertTriggerRawSqlNotifyActionExpression = sourceEntity => sourceEntity.Notify("insert");

        [Fact]
        public abstract void InsertTriggerRawSqlNotifyConverter();

        /// <summary>
        /// 
        /// </summary>
        protected Expression<Func<SourceEntity, string>> DeleteTriggerRawSqlNotifyActionExpression = sourceEntity => sourceEntity.Notify("delete");

        [Fact]
        public abstract void DeleteTriggerRawSqlNotifyConverter();

        /// <summary>
        /// 
        /// </summary>
        protected Expression<Func<SourceEntity, SourceEntity, string>> UpdateTriggerRawSqlNotifyActionExpression = (oldEntity, newEntity) => newEntity.Notify("update");

        [Fact]
        public abstract void UpdateTriggerRawSqlNotifyConverter();
    }

    internal static class RawSqlExtensions
    {
        public static string Notify<TTriggerEntity>(this TTriggerEntity entity, string channel)
        {
            return "";
        }
    }

    internal class RawSqlExtensionsNotifyConverter : MethodCallConverter
    {
        public override string MethodName => nameof(RawSqlExtensions.Notify);

        public override Type ReflectedType => typeof(RawSqlExtensions);

        public override SqlBuilder BuildSql(BaseExpressionProvider provider, MethodCallExpression expression, Dictionary<string, ArgumentType> argumentTypes)
        {
            var entityName = (expression.Arguments[0] as ParameterExpression)!.Name!;
            var argumentChannelExpression = expression.Arguments[1] as ConstantExpression;
            var argumentType = argumentTypes[entityName];
            var entityPrefix = argumentType switch
            {
                ArgumentType.New => "NEW",
                ArgumentType.Old => "OLD",
                _ => throw new Exception($"Not supported argument type {argumentType}")
            };

            return new SqlBuilder($"PERFORM pg_notify('{argumentChannelExpression!.Value}', row_to_json({entityPrefix})::text);");
        }
    }
}
