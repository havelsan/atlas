namespace Infrastructure.NeTagBuilder
{
    public interface ITagBuilderStrategyData
    {
        string Name
        {
            get;
        }

        bool IsDefault
        {
            get;
        }
    }
}