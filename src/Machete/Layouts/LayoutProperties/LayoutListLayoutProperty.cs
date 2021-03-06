﻿namespace Machete.Layouts.LayoutProperties
{
    using System.Reflection;
    using Internals.Reflection;
    using Parsers;


    public class LayoutListLayoutProperty<TLayout, TSchema, T> :
        ILayoutProperty<TLayout, TSchema>,
        ILayoutPropertyWriter<TLayout, LayoutList<T>>
        where TSchema : Entity
        where TLayout : Layout
        where T : Layout
    {
        readonly ILayoutParserFactory<T, TSchema> _layout;
        readonly bool _required;
        readonly IWriteProperty<TLayout, LayoutList<T>> _property;

        public LayoutListLayoutProperty(PropertyInfo property, ILayoutParserFactory<T, TSchema> layout, bool required)
        {
            _layout = layout;
            _required = required;
            _property = WritePropertyCache<TLayout>.GetProperty<LayoutList<T>>(property.Name);
        }

        public IParser<TSchema, LayoutMatch<TLayout>> CreateQuery(LayoutParserOptions options, IQueryBuilder<TSchema> queryBuilder)
        {
            IParser<TSchema, T> parser = _layout.CreateParser(options, queryBuilder);
            var listParser = _required ? parser.OneOrMore() : parser.ZeroOrMore();

            return new LayoutListLayoutParser<TLayout, TSchema, T>(listParser, this);
        }

        public void SetProperty(TLayout layout, LayoutList<T> value)
        {
            _property.Set(layout, value);
        }
    }
}