using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResRoom
    {
        public Guid ObjectId { get; set; }
        public Guid? RoomGroupRef { get; set; }

        #region Base Object Navigation Property
        public virtual ResSection ResSection { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResRoomGroup RoomGroup { get; set; }
        #endregion Parent Relations
    }
}