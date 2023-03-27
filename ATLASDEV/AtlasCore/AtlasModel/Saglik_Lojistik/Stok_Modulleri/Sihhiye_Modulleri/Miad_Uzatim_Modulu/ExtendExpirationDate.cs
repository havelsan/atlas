using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ExtendExpirationDate
    {
        public Guid ObjectId { get; set; }
        public bool? InMkysControl { get; set; }
        public bool? OutMkysControl { get; set; }
        public int? MKYS_AyniyatMakbuzIDGiris { get; set; }

        #region Base Object Navigation Property
        public virtual BaseChattelDocument BaseChattelDocument { get; set; }
        #endregion Base Object Navigation Property
    }
}