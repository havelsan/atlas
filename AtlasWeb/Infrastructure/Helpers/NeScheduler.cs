using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Infrastructure.Helpers
{
    public class NeScheduler
    {
        private readonly ViewContext _viewContext;
        public NeScheduler(IHtmlHelper htmlHelper, string name, string height, string dataSource, int startDayHour, int endDayHour, string currentView, DateTime currentDate, string disabled = null, string visible = null, int tabIndex = 0)
        {
            TagBuilder builder = new TagBuilder("dx-scheduler");
            //builder.MergeAttribute("[(value)]", _ModelPrefix + nameBinding);
            if (!String.IsNullOrWhiteSpace(dataSource))
            {
                builder.MergeAttribute("[dataSource]", dataSource);
            }

            if (startDayHour > 0)
            {
                builder.MergeAttribute("startDayHour", startDayHour.ToString());
            }

            if (endDayHour > 0)
            {
                builder.MergeAttribute("endDayHour", endDayHour.ToString());
            }

            if (!String.IsNullOrWhiteSpace(currentView))
            {
                builder.MergeAttribute("currentView", currentView);
            }

            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[Disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(height))
            {
                builder.MergeAttribute("[height]", height);
            }

            if (currentDate != null)
            {
                builder.MergeAttribute("[currentDate]", currentDate.ToShortDateString());
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