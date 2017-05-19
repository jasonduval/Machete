﻿namespace Machete.SchemaConfiguration.Builders
{
    using System;
    using System.Collections.Generic;
    using EntityFactories;
    using EntityMaps;


    public class DynamicEntityMapBuilder<TEntity, TSchema> :
        IEntityMapBuilder<TEntity, TSchema>
        where TSchema : Entity
        where TEntity : TSchema
    {
        readonly ISchemaBuilder<TSchema> _schemaBuilder;
        readonly IEntityTypeSelector _entityTypeSelector;
        readonly IList<IEntityProperty<TEntity>> _properties;
        readonly IList<ITextSliceProvider<TEntity>> _sliceProviders;

        public DynamicEntityMapBuilder(ISchemaBuilder<TSchema> schemaBuilder, IEntityTypeSelector entityTypeSelector)
        {
            _schemaBuilder = schemaBuilder;
            _entityTypeSelector = entityTypeSelector;

            ImplementationType = schemaBuilder.GetImplementationType<TEntity>();

            _properties = new List<IEntityProperty<TEntity>>();
            _sliceProviders = new List<ITextSliceProvider<TEntity>>();
        }

        public Type ImplementationType { get; }

        public IEntityMap<T> GetEntityMap<T>()
            where T : TSchema
        {
            return _schemaBuilder.GetEntityMap<T>();
        }

        public void AddValue(IEntityProperty<TEntity> property, ITextSliceProvider<TEntity> sliceProvider)
        {
            _properties.Add(property);
            _sliceProviders.Add(sliceProvider);
        }

        public IEntityMap<TEntity> Build()
        {
            var entityFactory = new DynamicEntityFactory<TEntity>(ImplementationType);

            return new DynamicEntityMap<TEntity, TSchema>(ImplementationType, _entityTypeSelector, entityFactory, _properties, _sliceProviders);
        }
    }
}