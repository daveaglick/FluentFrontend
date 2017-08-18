using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentFrontend
{
    public static class ElementExtensions
    {
        public static IElement<TTag> If<TTag>(
            this IElement<TTag> element,
            bool condition,
            Func<IElement<TTag>, IElement<TTag>> ifFunction,
            Func<IElement<TTag>, IElement<TTag>> elseFunction = null)
            where TTag : class, ITag => 
            condition ? ifFunction(element) : (elseFunction == null ? element : elseFunction(element));

        public static IElement<TTag> If<TTag>(
            this IElement<TTag> element,
            Func<IElement<TTag>, bool> conditionFunction,
            Func<IElement<TTag>, IElement<TTag>> ifFunction,
            Func<IElement<TTag>, IElement<TTag>> elseFunction = null)
            where TTag : class, ITag =>
            conditionFunction(element) ? ifFunction(element) : (elseFunction == null ? element : elseFunction(element));

        public static IElement<TTag> ForEach<TTag, TItem>(
            this IElement<TTag> element,
            IEnumerable<TItem> items,
            Func<IElement<TTag>, TItem, IElement<TTag>> forEachFunction)
            where TTag : class, ITag => 
            items.Aggregate(element, forEachFunction);
    }
}
