using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AppointmentCarrier
    {
        public Guid ObjectId { get; set; }
        public string SubResourceCaption { get; set; }
        public string SubResource { get; set; }
        public AppointmentTypeEnum? AppointmentType { get; set; }
        public string RelationParentName { get; set; }
        public bool? IsDefault { get; set; }
        public int? AppointmentCount { get; set; }
        public string MasterResourceCaption { get; set; }
        public string CarrierName { get; set; }
        public int? AppointmentDuration { get; set; }
        public string MasterResource { get; set; }
        public string MasterResourceFilter { get; set; }
        public Guid? AppointmentDefinitionRef { get; set; }

        #region Parent Relations
        public virtual AppointmentDefinition AppointmentDefinition { get; set; }
        #endregion Parent Relations
    }
}