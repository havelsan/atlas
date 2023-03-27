using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;

namespace Infrastructure.Helpers
{
    public class NePopup
    {
        ViewContext _ViewContext;
        TextWriter _HtmlWriter;
        Action<TextWriter> _OnEnd;
        public NePopup(ViewContext viewContext, string binding, Action<TextWriter> onBegin, Action<TextWriter> onEnd)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException("viewContext");
            }

            if (onBegin == null)
            {
                throw new ArgumentNullException("onBegin");
            }

            if (onEnd == null)
            {
                throw new ArgumentNullException("onEnd");
            }

            _OnEnd = onEnd;
            _ViewContext = viewContext;
            _HtmlWriter = viewContext.Writer;
            onBegin.Invoke(_HtmlWriter);
        }

        
    }
}