using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Laraue.EfCoreTriggers.Common.TriggerBuilders.Base;

namespace Laraue.EfCoreTriggers.Common.TriggerBuilders.OnUpdate
{
    public class OnUpdateTriggerRawAction<TTriggerEntity> : TriggerRawAction<TTriggerEntity>
        where TTriggerEntity : class
    {
        public OnUpdateTriggerRawAction(Expression<Func<TTriggerEntity, TTriggerEntity, string>> sql)
                : base(sql)
        {
        }

        internal override Dictionary<string, ArgumentType> RawExpressionPrefixes => new()
        {
            [RawExpression.Parameters[0].Name] = ArgumentType.Old,
            [RawExpression.Parameters[1].Name] = ArgumentType.New,
        };
    }
}
