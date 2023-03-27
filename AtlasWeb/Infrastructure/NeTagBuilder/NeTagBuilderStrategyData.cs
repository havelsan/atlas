using System;


namespace Infrastructure.NeTagBuilder
{
    public class NeTagBuilderStrategyData : Attribute, ITagBuilderStrategyData
    {
        public NeTagBuilderStrategyData(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        public bool IsDefault
        {
            get;
            set;
        }
    }
}