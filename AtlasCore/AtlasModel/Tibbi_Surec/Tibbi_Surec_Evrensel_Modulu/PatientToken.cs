using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientToken
    {
        public Guid ObjectId { get; set; }
        public string Token { get; set; }
        public PatientTokenTypeEnum? TokenType { get; set; }
        public Guid? PatientRef { get; set; }

        #region Parent Relations
        public virtual Patient Patient { get; set; }
        #endregion Parent Relations
    }
}