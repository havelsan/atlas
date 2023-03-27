using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SpecialityBasedObject
    {
        public Guid ObjectId { get; set; }
        public Guid? PhysicianApplicationRef { get; set; }
        public Guid? OldPhysicianApplicationRef { get; set; }

        #region Parent Relations
        public virtual PhysicianApplication PhysicianApplication { get; set; }
        public virtual PhysicianApplication OldPhysicianApplication { get; set; }
        #endregion Parent Relations
    }
}