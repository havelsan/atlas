using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResRoomGroup
    {
        public Guid ObjectId { get; set; }
        public Guid? WardRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResWard Ward { get; set; }
        #endregion Parent Relations
    }
}