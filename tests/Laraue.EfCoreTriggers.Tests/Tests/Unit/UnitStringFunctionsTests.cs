using Laraue.EfCoreTriggers.Common.SqlGeneration;
using Laraue.EfCoreTriggers.Tests.Tests.Base;

namespace Laraue.EfCoreTriggers.Tests.Tests.Unit
{
    public abstract class UnitStringFunctionsTests : BaseStringFunctionsTests
    {
        protected readonly ITriggerProvider Provider;

        protected UnitStringFunctionsTests(ITriggerProvider provider)
        {
            Provider = provider;
        }

        public abstract string ExceptedConcatSql { get; }

        public abstract string ExceptedStringLowerSql { get; }

        public abstract string ExceptedStringUpperSql { get; }

        public abstract string ExceptedStringTrimSql { get; }

        public abstract string ExceptedContainsSql { get; }

        public abstract string ExceptedEndsWithSql { get; }

        public abstract string ExceptedIsNullOrEmptySql { get; }

        protected override void StringConcatSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedConcatSql, ConcatStringExpression);
        }

        protected override void StringLowerSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedStringLowerSql, StringToLowerExpression);
        }

        protected override void StringUpperSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedStringUpperSql, StringToUpperExpression);
        }

        protected override void StringTrimSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedStringTrimSql, TrimStringValueExpression);
        }

        protected override void StringContainsSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedContainsSql, ContainsStringValueExpression);
        }
        
        protected override void StringEndsWithSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedEndsWithSql, EndsWithStringValueExpression);
        }

        protected override void StringIsNullOrEmptySql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedIsNullOrEmptySql, IsNullOrEmptyStringValueExpression);
        }
    }
}