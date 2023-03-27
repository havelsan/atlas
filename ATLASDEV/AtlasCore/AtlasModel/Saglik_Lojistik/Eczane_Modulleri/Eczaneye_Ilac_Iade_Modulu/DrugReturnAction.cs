using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugReturnAction
    {
        public Guid ObjectId { get; set; }
        public string DrugReturnReason { get; set; }
        public Guid? PharmacyStoreDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Store PharmacyStoreDefinition { get; set; }
        #endregion Parent Relations
    }
}