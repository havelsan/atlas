using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class OlayAfetSMSGonderim
    {
        public Guid ObjectId { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? SKRSILKodlariRef { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}