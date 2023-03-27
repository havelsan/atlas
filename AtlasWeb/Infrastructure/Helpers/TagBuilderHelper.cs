using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace Infrastructure.Helpers
{
    public static class TagBuilderHelper
    {
        public static string ToHtmlString(this TagBuilder tagBuilder)
        {
            using (var writer = new StringWriter())
            {
                tagBuilder.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        public static void SetInnerHtml(this TagBuilder tagBuilder, string text)
        {
            tagBuilder.InnerHtml.Clear();
            tagBuilder.InnerHtml.Append(text);
        }
    }
}