using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResSurgeryDesk
    {
        public Guid ObjectId { get; set; }
        public Guid? SurgeryRoomRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResSurgeryRoom SurgeryRoom { get; set; }
        #endregion Parent Relations
    }
}