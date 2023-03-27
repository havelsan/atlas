using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class AdmissionAppointment
    {
        public Guid ObjectId { get; set; }
        public string PatientName { get; set; }
        public string SelectedPatientFiltered { get; set; }
        public string PatientSurname { get; set; }
        public long? PatientUniqueRefNo { get; set; }
        public string PatientPhone { get; set; }
        public PhoneTypeEnum? PhoneType { get; set; }
        public bool? NotRequiredQuota { get; set; }
        public Guid? SelectedPatientRef { get; set; }
        public Guid? MasterResourceRef { get; set; }
        public Guid? AppointmentDefinitionRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAction BaseAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Patient SelectedPatient { get; set; }
        public virtual Resource MasterResource { get; set; }
        public virtual AppointmentDefinition AppointmentDefinition { get; set; }
        #endregion Parent Relations
    }
}