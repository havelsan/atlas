using Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Infrastructure.Helpers
{
    public class NePanel 
    {
        private readonly ViewContext _viewContext;
        public NePanel(IHtmlHelper htmlHelper, PanelTypeEnum panelType, string header, string body, string footer)
        {
            string paneltype = "";
            if (panelType == PanelTypeEnum.Alert)
            {
                paneltype = "panel-danger";
            }
            else if (panelType == PanelTypeEnum.Info)
            {
                paneltype = "panel-info";
            }
            else if (panelType == PanelTypeEnum.Primary)
            {
                paneltype = "panel-primary";
            }
            else if (panelType == PanelTypeEnum.Warning)
            {
                paneltype = "panel-default";
            }
            else if (panelType == PanelTypeEnum.Success)
            {
                paneltype = "panel-success";
            }

            string tags = "<div class=\"panel-group\">";
            if (!String.IsNullOrWhiteSpace(paneltype))
            {
                tags += "<div class=\"panel " + paneltype + "\">";
            }

            if (!String.IsNullOrWhiteSpace(header))
            {
                tags += "<div class=\"panel-heading\">" + header + "</div>";
            }

            if (!String.IsNullOrWhiteSpace(body))
            {
                tags += "<div class=\"panel-body\">" + body + "</div>";
            }

            if (!String.IsNullOrWhiteSpace(footer))
            {
                tags += "<div class=\"panel-footer\">" + footer + "</div>";
            }

            htmlHelper.ViewContext.Writer.Write(tags);
            _viewContext = htmlHelper.ViewContext;
        }

    }
}