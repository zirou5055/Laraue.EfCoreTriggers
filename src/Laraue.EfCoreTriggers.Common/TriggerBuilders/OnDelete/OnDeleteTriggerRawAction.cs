using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Laraue.EfCoreTriggers.Common.TriggerBuilders.Base;

namespace Laraue.EfCoreTriggers.Common.TriggerBuilders.OnDelete
{
    public class OnDeleteTriggerRawAction<TTriggerEntity> : TriggerRawAction<TTriggerEntity>
        where TTriggerEntity : class
    {
        public OnDeleteTriggerRawAction(Expression<Func<TTriggerEntity, string>> sql)
            : base(sql)
        {
        }

        internal override Dictionary<string, ArgumentType> RawExpressionPrefixes => new()
        {
            [RawExpression.Parameters[0].Name] = ArgumentType.Old,
        };
    }
}
