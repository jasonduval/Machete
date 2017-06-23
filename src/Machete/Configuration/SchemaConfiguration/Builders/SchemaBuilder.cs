﻿namespace Machete.SchemaConfiguration.Builders
{
    using System;
    using System.Collections.Generic;
    using Internals.Reflection;
    using TypeSelectors;


    public class SchemaBuilder<TSchema> :
        ISchemaBuilder<TSchema>
        where TSchema : Entity
    {
        readonly IDictionary<Type, IEntityConverter> _entityConverters;
        readonly IImplementationBuilder _implementationBuilder;
        readonly IEntityTypeSelectorFactory _entityTypeSelectorFactory;
        readonly IDictionary<Type, IEntityFormatter> _entityFormatters;

        public SchemaBuilder(IEntityTypeSelectorFactory entityTypeSelectorFactory)
        {
            _entityTypeSelectorFactory = entityTypeSelectorFactory;

            _entityConverters = new Dictionary<Type, IEntityConverter>();
            _entityFormatters = new Dictionary<Type, IEntityFormatter>();

            _implementationBuilder = new DynamicImplementationBuilder();
        }

        public Type GetImplementationType<T>()
            where T : TSchema
        {
            return _implementationBuilder.GetImplementationType(typeof(T));
        }

        public IEntityConverter<T> GetEntityConverter<T>()
            where T : TSchema
        {
            IEntityConverter result;
            if (_entityConverters.TryGetValue(typeof(T), out result))
            {
                return result as IEntityConverter<T>;
            }

            throw new KeyNotFoundException($"The {typeof(T).Name} entity converter was not found");
        }

        public IEntityFormatter<T> GetEntityFormatter<T>()
            where T : TSchema
        {
            IEntityFormatter result;
            if (_entityFormatters.TryGetValue(typeof(T), out result))
            {
                return result as IEntityFormatter<T>;
            }

            throw new KeyNotFoundException($"The {typeof(T).Name} entity formatter was not found");
        }

        public void Add<T>(IEntityConverter<T> converter)
            where T : TSchema
        {
            _entityConverters[converter.EntityType.EntityType] = converter;

            if (converter.EntityType.EntityTypeSelector != null)
                _entityTypeSelectorFactory.Add(converter.EntityType);
        }

        public void Add<T>(IEntityFormatter<T> formatter)
            where T : TSchema
        {
            _entityFormatters[formatter.EntityType] = formatter;
        }

        public ISchema<TSchema> Build()
        {
            var entityTypeSelector = _entityTypeSelectorFactory.Build();

            return new Schema<TSchema>(_entityConverters.Values, entityTypeSelector, _implementationBuilder);
        }
    }
}