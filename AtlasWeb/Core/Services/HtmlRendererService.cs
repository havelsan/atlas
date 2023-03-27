using TTUtils;

namespace Core.Services
{
    public class HtmlRendererService : IHtmlRendererService
    {
        public string ConvertHTMLtoPlainText(string source)
        {
            var plainText = TheArtOfDev.HtmlRenderer.PlainText.HtmlContainer.HTMLtoPlainText(source);
            return plainText;
        }
    }
}
