﻿namespace Machete.Translators.PropertyTranslators
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;


    public class SetInputPropertyTranslator<TEntity, TProperty, TInput, TSchema> :
        PropertyTranslator<TEntity, TProperty>,
        IInputPropertyTranslator<TEntity, TInput, TSchema>
        where TSchema : Entity
        where TEntity : TSchema
        where TInput : TSchema
    {
        readonly TProperty _propertyValue;

        public SetInputPropertyTranslator(Type implementationType, PropertyInfo propertyInfo, TProperty propertyValue)
            : base(implementationType, propertyInfo)
        {
            _propertyValue = propertyValue;
        }

        public async Task Apply(TEntity entity, TranslateContext<TInput, TSchema> context)
        {
            Property.Set(entity, _propertyValue);
        }
    }
}