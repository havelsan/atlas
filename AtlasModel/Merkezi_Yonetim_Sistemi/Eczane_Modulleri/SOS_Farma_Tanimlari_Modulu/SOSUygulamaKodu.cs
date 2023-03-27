using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SOSUygulamaKodu
    {
        public Guid ObjectId { get; set; }
        public long? SOSID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? XXXXXXRouteOfAdminRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}