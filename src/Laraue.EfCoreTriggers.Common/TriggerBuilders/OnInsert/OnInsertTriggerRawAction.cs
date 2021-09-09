using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Laraue.EfCoreTriggers.Common.SqlGeneration;
using Laraue.EfCoreTriggers.Common.TriggerBuilders.Base;

namespace Laraue.EfCoreTriggers.Common.TriggerBuilders.OnInsert
{
    public class OnInsertTriggerRawAction<TTriggerEntity> : TriggerRawAction<TTriggerEntity>
        where TTriggerEntity : class
    {
        public OnInsertTriggerRawAction(Expression<Func<TTriggerEntity, string>> sql)
            : base(sql)
        {
        }

        internal override Dictionary<string, ArgumentType> RawExpressionPrefixes => new()
        {
            [RawExpression.Parameters[0].Name] = ArgumentType.New,
        };
    }
}
