using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResUserTakeOffFromWork
    {
        public Guid ObjectId { get; set; }
        public string UniqueRefNo { get; set; }
        public string IntegrationId { get; set; }
        public string IntegrationVersion { get; set; }
        public string Definition { get; set; }
        public bool? ResUserTakeOffFromWorkType { get; set; }
        public bool? IsActive { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? MHRSActionTypeRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        public virtual MHRSActionTypeDefinition MHRSActionType { get; set; }
        #endregion Parent Relations
    }
}