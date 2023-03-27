using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResponseOfENabiz
    {
        public Guid ObjectId { get; set; }
        public DateTime? SendDate { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public Guid? SendToENabizRef { get; set; }

        #region Parent Relations
        public virtual SendToENabiz SendToENabiz { get; set; }
        #endregion Parent Relations
    }
}