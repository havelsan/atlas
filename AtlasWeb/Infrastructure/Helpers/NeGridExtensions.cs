using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Helpers
{
    public static class NeGridTagBuilder
    {
        public static GridHelper NeGridFor(this IHtmlHelper helper, string dataSource)
        {
            return new GridHelper(new TagBuilder("dx-data-grid"), dataSource);
        }
    }
}