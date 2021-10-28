using System;
using System.Linq.Expressions;
using Laraue.EfCoreTriggers.Common.TriggerBuilders.Base;

namespace Laraue.EfCoreTriggers.Common.TriggerBuilders.OnDelete
{
    public class OnDeleteTriggerActions<TTriggerEntity> : TriggerActions<TTriggerEntity>
        where TTriggerEntity : class
    {
        public OnDeleteTriggerActions<TTriggerEntity> Condition(Expression<Func<TTriggerEntity, bool>> condition)
        {
            ActionConditions.Add(new OnDeleteTriggerCondition<TTriggerEntity>(condition));
            return this;
        }

        public OnDeleteTriggerActions<TTriggerEntity> Update<TUpdateEntity>(
                Expression<Func<TTriggerEntity, TUpdateEntity, bool>> entityFilter,
                Expression<Func<TTriggerEntity, TUpdateEntity, TUpdateEntity>> setValues)
            where TUpdateEntity : class
        {
            Update(new OnDeleteTriggerUpdateAction<TTriggerEntity, TUpdateEntity>(entityFilter, setValues));
            return this;
        }

        public OnDeleteTriggerActions<TTriggerEntity> Upsert<TUpsertEntity>(
            Expression<Func<TTriggerEntity, TUpsertEntity>> matchExpression,
            Expression<Func<TTriggerEntity, TUpsertEntity>> insertExpression,
            Expression<Func<TTriggerEntity, TUpsertEntity, TUpsertEntity>> onMatchExpression)
            where TUpsertEntity : class
        {
            Upsert(new OnDeleteTriggerUpsertAction<TTriggerEntity, TUpsertEntity>(matchExpression, insertExpression, onMatchExpression));
            return this;
        }

        public OnDeleteTriggerActions<TTriggerEntity> InsertIfNotExists<TUpsertEntity>(
            Expression<Func<TTriggerEntity, TUpsertEntity>> matchExpression,
            Expression<Func<TTriggerEntity, TUpsertEntity>> insertExpression)
            where TUpsertEntity : class
        {
            Upsert(new OnDeleteTriggerUpsertAction<TTriggerEntity, TUpsertEntity>(matchExpression, insertExpression, null));
            return this;
        }

        public OnDeleteTriggerActions<TTriggerEntity> Delete<TDeleteEntity>(Expression<Func<TTriggerEntity, TDeleteEntity, bool>> deleteExpression)
            where TDeleteEntity : class
        {
            Delete(new OnDeleteTriggerDeleteAction<TTriggerEntity, TDeleteEntity>(deleteExpression));
            return this;
        }

        public OnDeleteTriggerActions<TTriggerEntity> Insert<TInsertEntity>(Expression<Func<TTriggerEntity, TInsertEntity>> setValues)
            where TInsertEntity : class
        {
            Insert(new OnDeleteTriggerInsertAction<TTriggerEntity, TInsertEntity>(setValues));
            return this;
        }

        public OnDeleteTriggerActions<TTriggerEntity> Raw(Expression<Func<TTriggerEntity, string>> sql)
        {
            Raw(new OnDeleteTriggerRawAction<TTriggerEntity>(sql));
            return this;
        }
    }
}