using Laraue.EfCoreTriggers.Common.SqlGeneration;
using Laraue.EfCoreTriggers.Tests.Tests.Base;

namespace Laraue.EfCoreTriggers.Tests.Tests.Unit
{
    public abstract class BaseMemberAssignmentUnitTests : BaseMemberAssignmentTests
    {
        protected readonly ITriggerProvider Provider;

        protected BaseMemberAssignmentUnitTests(ITriggerProvider provider)
        {
            Provider = provider;
        }

        public abstract string ExceptedEnumValueSql { get; }

        public abstract string ExceptedDecimalAddSql { get; }

        public abstract string ExceptedDoubleSubSql { get; }

        public abstract string ExceptedIntMultiplySql { get; }

        public abstract string ExceptedBooleanSql { get; }

        public abstract string ExceptedNewGuidSql { get; }

        public override void EnumValueSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedEnumValueSql, SetEnumValueExpression);
        }

        public override void DecimalAddSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedDecimalAddSql, AddDecimalValueExpression);
        }

        public override void DoubleSubSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedDoubleSubSql, SubDoubleValueExpression);
        }

        public override void IntMultiplySql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedIntMultiplySql, MultiplyIntValueExpression);
        }

        public override void BooleanValueSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedBooleanSql, SetBooleanValueExpression);
        }

        public override void NewGuid()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedNewGuidSql, SetNewGuidValueExpression);
        }
    }
}