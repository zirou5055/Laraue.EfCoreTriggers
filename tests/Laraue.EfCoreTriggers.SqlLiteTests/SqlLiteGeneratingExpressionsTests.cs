﻿using Laraue.EfCoreTriggers.SqlLite;
using Laraue.EfCoreTriggers.Tests.Tests;
using Xunit.Categories;

namespace Laraue.EfCoreTriggers.SqlLiteTests
{
    [UnitTest]
    public class SqlLiteGeneratingExpressionsTests : BaseGeneratingExpressionsTests
    {
        public SqlLiteGeneratingExpressionsTests() : base(new SqlLiteProvider(new ContextFactory().CreateDbContext().Model))
        {
        }

        public override string ExceptedConcatSql => "INSERT INTO transactions_mirror (description) VALUES (NEW.description || 'abc');";

        public override string ExceptedStringLowerSql => "INSERT INTO transactions_mirror (description) VALUES (LOWER(NEW.description));";

        public override string ExceptedStringUpperSql => "INSERT INTO transactions_mirror (description) VALUES (UPPER(NEW.description));";

        public override string ExceptedEnumValueSql => "INSERT INTO users (role) VALUES (999);";

        public override string ExceptedDecimalAddSql => "INSERT INTO test_entities (decimal_value) VALUES (NEW.decimal_value + 3);";

        public override string ExceptedDoubleSubSql => "INSERT INTO test_entities (double_value) VALUES (NEW.double_value - 3);";

        public override string ExceptedIntMultiplySql => "INSERT INTO test_entities (int_value) VALUES (NEW.int_value * 2);";

        public override string ExceptedBooleanSql => "INSERT INTO test_entities (boolean_value) VALUES (true);";

        public override string ExceptedNewGuidSql => "INSERT INTO test_entities (guid_value) VALUES (lower(hex(randomblob(4))) || '-' || lower(hex(randomblob(2))) || '-4' || substr(lower(hex(randomblob(2))),2) || '-' || substr('89ab', abs(random()) % 4 + 1, 1) || substr(lower(hex(randomblob(2))),2) || '-' || lower(hex(randomblob(6))));";

        public override string ExceptedStringTrimSql => "INSERT INTO transactions_mirror (description) VALUES (TRIM(NEW.description));";

        public override string ExceptedContainsSql => "INSERT INTO transactions_mirror (is_veryfied) VALUES (INSTR(NEW.description, 'abc') > 0);";
        
        public override string ExceptedEndsWithSql => "INSERT INTO transactions_mirror (is_veryfied) VALUES (NEW.description LIKE ('%' || 'abc'));";
        
        public override string ExceptedIsNullOrEmptySql => "INSERT INTO transactions_mirror (is_veryfied) VALUES (NEW.description IS NULL OR NEW.description = '');";

        public override string ExceptedAbsSql => "INSERT INTO transactions_mirror (value) VALUES (ABS(NEW.value));";

        public override string ExceptedAcosSql => "INSERT INTO transactions_mirror (double_value) VALUES (ACOS(NEW.double_value));";
       
        public override string ExceptedAsinSql => "INSERT INTO transactions_mirror (double_value) VALUES (ASIN(NEW.double_value));";
        
        public override string ExceptedAtanSql => "INSERT INTO transactions_mirror (double_value) VALUES (ATAN(NEW.double_value));";
       
        public override string ExceptedAtanTwoSql => "INSERT INTO transactions_mirror (double_value) VALUES (ATAN2(NEW.double_value, NEW.double_value));";
        
        public override string ExceptedCeilingSql => "INSERT INTO transactions_mirror (double_value) VALUES (CEILING(NEW.double_value));";

        public override string ExceptedCosSql => "INSERT INTO transactions_mirror (double_value) VALUES (COS(NEW.double_value));";

        public override string ExceptedExpSql => "INSERT INTO transactions_mirror (double_value) VALUES (EXP(NEW.double_value));";

        public override string ExceptedFloorSql => "INSERT INTO transactions_mirror (double_value) VALUES (FLOOR(NEW.double_value));";

    }
}
