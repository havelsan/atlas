using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Infrastructure.Helpers
{
    public class NeAccordion 
    {
        private readonly ViewContext _viewContext;
        public NeAccordion(IHtmlHelper htmlHelper, string name, string width, string height, string dataSource, string disabled = null, string visible = null, int tabIndex = 0)
        {
            TagBuilder builder = new TagBuilder("dx-accordion");
            //builder.MergeAttribute("[(value)]", _ModelPrefix + nameBinding);
            if (!String.IsNullOrWhiteSpace(height))
            {
                builder.MergeAttribute("[height]", height);
            }

            if (!String.IsNullOrWhiteSpace(width))
            {
                builder.MergeAttribute("[width]", width);
            }

            if (!String.IsNullOrWhiteSpace(dataSource))
            {
                builder.MergeAttribute("[dataSource]", dataSource);
            }

            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[Disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[visible]", visible);
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            htmlHelper.ViewContext.Writer.Write(builder.ToHtmlString());
            _viewContext = htmlHelper.ViewContext;
        }

    }
}