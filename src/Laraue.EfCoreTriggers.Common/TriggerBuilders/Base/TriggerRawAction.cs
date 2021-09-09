using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Laraue.EfCoreTriggers.Common.SqlGeneration;

namespace Laraue.EfCoreTriggers.Common.TriggerBuilders.Base
{
    public abstract class TriggerRawAction<TTriggerEntity> : ITriggerAction
        where TTriggerEntity : class
    {
        internal LambdaExpression RawExpression;

        public TriggerRawAction(LambdaExpression rawExpression)
        {
            RawExpression = rawExpression;
        }

        public virtual SqlBuilder BuildSql(ITriggerProvider visitor)
            => visitor.GetTriggerRawActionSql(this);

        internal abstract Dictionary<string, ArgumentType> RawExpressionPrefixes { get; }
    }
}
