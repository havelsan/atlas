using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.NeTagBuilder
{
    public class TagBuilderServiceList
    {
        public IEnumerable<Lazy<ITagBuilderStrategy, ITagBuilderStrategyData>> TagBuilders
        {
            get
            {
                return _tagBuilders;
            }
        }

        private IEnumerable<Lazy<ITagBuilderStrategy, ITagBuilderStrategyData>> _tagBuilders;
        public TagBuilderServiceList(IEnumerable<Lazy<ITagBuilderStrategy, ITagBuilderStrategyData>> tagBuilders)
        {
            _tagBuilders = tagBuilders;
        }

        public IDictionary<string, ITagBuilderStrategy> _tagBuilderCache = new Dictionary<string, ITagBuilderStrategy>();
        public ITagBuilderStrategy GetTagBuilderStrategy(string name)
        {
            if (_tagBuilderCache.ContainsKey(name))
            {
                var tagBuilderStrategyItem = _tagBuilderCache[name];
                return tagBuilderStrategyItem;
            }

            var tagBuilderStrategy = _tagBuilders.Where(t => t.Metadata.Name == name).FirstOrDefault();
            // TO DO : Handle null 
            var tagBuilder = tagBuilderStrategy.Value;
            if (tagBuilder != null)
            {
                _tagBuilderCache.Add(name, tagBuilder);
            }

            return tagBuilder;
        }

        private ITagBuilderStrategy _defaultTagBuilder = null;
        public ITagBuilderStrategy GetDefaultTagBuilderStrategy()
        {
            if (_defaultTagBuilder == null)
            {
                var tagBuilder = _tagBuilders.Where(t => t.Metadata.IsDefault).FirstOrDefault();
                if (tagBuilder != null)
                    _defaultTagBuilder = tagBuilder.Value;
            }

            return _defaultTagBuilder;
        }
    }
}