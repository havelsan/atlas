using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Helpers
{
    public class Validators
    {
        public static string Required
        {
            get
            {
                return "Validators.Required";
            }
        }

        public static string MinLength(int minLength)
        {
            return string.Format("Validators.Min({0})", minLength);
        }
    }

    public static class NebulaFormExtensions
    {
        public static HtmlString NeFormFor<TModel>(this IHtmlHelper<TModel> htmlHelper, params string[] validators)
        {
            //var name = ExpressionHelper.GetExpressionText(expression);
            //var tagBuilderStrategy = NebulaTagBuilder.Instance;
            //return tagBuilderStrategy.Date(htmlHelper, metadata, name, metadata.Model, null);
            return null;
        }
    }
}