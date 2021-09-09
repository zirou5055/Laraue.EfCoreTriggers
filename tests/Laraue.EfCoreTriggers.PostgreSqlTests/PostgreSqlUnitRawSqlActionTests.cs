using System;
using Laraue.EfCoreTriggers.Common.SqlGeneration;
using Laraue.EfCoreTriggers.PostgreSql;
using Laraue.EfCoreTriggers.Tests.Tests.Unit;
using Xunit.Categories;

namespace Laraue.EfCoreTriggers.PostgreSqlTests
{
    [UnitTest]
    public class PostgreSqlUnitRawSqlActionTests : UnitRawSqlActionTests
    {
        public PostgreSqlUnitRawSqlActionTests() : base(new PostgreSqlProvider(new ContextFactory().CreateDbContext().Model))
        {
        }

        public override string ExpectedInsertTriggerRawSqlPlainTextActionSql => "RAW SQL;";

        public override string ExpectedInsertTriggerRawSqlNotifyActionSql => "PERFORM pg_notify('insert', row_to_json(NEW)::text);";

        public override string ExpectedDeleteTriggerRawSqlNotifyActionSql => "PERFORM pg_notify('delete', row_to_json(OLD)::text);";

        public override string ExpectedUpdateTriggerRawSqlNotifyActionSql => "PERFORM pg_notify('update', row_to_json(NEW)::text);";
    }
}
