﻿namespace Machete.Translators.PropertyTranslators
{
    using System.Threading.Tasks;


    public interface IPropertyTranslator<in TEntity, TSchema>
        where TEntity : TSchema
        where TSchema : Entity
    {
        /// <summary>
        /// Apply the property translation to the entity
        /// </summary>
        /// <param name="entity">The target entity</param>
        /// <param name="context">The translate context</param>
        /// <returns></returns>
        Task Apply(TEntity entity, TranslateContext<TSchema> context);
    }
}