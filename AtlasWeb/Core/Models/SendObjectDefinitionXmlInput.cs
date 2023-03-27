using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SendObjectDefinitionXmlInput
    {
        public string FileName { get; set; }
        public IList<FormFile> Attachments { get; set; }
    }
}
