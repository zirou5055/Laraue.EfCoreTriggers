using Laraue.EfCoreTriggers.Common.SqlGeneration;
using Laraue.EfCoreTriggers.Tests.Tests.Base;

namespace Laraue.EfCoreTriggers.Tests.Tests.Unit
{
    public abstract class UnitMathFunctionsTests : BaseMathFunctionsTests
    {
        protected readonly ITriggerProvider Provider;

        protected UnitMathFunctionsTests(ITriggerProvider provider)
        {
            Provider = provider;
        }

        public abstract string ExceptedAbsSql { get; }

        public abstract string ExceptedAcosSql { get; }

        public abstract string ExceptedAsinSql { get; }

        public abstract string ExceptedAtanSql { get; }

        public abstract string ExceptedAtan2Sql { get; }

        public abstract string ExceptedCeilingSql { get; }

        public abstract string ExceptedCosSql { get; }

        public abstract string ExceptedExpSql { get; }

        public abstract string ExceptedFloorSql { get; }

        public override void MathAbsDecimalSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedAbsSql, MathAbsDecimalValueExpression);
        }
        
        public override void MathAcosSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedAcosSql, MathAcosDoubleValueExpression);
        }

        public override void MathAsinSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedAsinSql, MathAsinDoubleValueExpression);
        }

        public override void MathAtanSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedAtanSql, MathAtanDoubleValueExpression);
        }

        public override void MathAtan2Sql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedAtan2Sql, MathAtan2DoubleValueExpression);
        }

        public override void MathCeilingDoubleSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedCeilingSql, MathCeilingDoubleValueExpression);
        }

        public override void MathCosSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedCosSql, MathCosDoubleValueExpression);
        }

        public override void MathExpSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedExpSql, MathExpDoubleValueExpression);
        }

        public override void MathFloorDoubleSql()
        {
            Provider.AssertGeneratedInsertTriggerInsertActionSql(ExceptedFloorSql, MathFloorDoubleValueExpression);
        }
    }
}