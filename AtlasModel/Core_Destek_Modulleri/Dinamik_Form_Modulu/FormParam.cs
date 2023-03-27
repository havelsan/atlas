using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class FormParam
    {
        public Guid ObjectId { get; set; }
        public bool? IsFilter { get; set; }
        public bool? IsRequired { get; set; }
        public string ParamKey { get; set; }
    }
}