using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseBedProcedure
    {
        public Guid ObjectId { get; set; }
        public bool? IsLast { get; set; }
        public DateTime? BedDischargeDate { get; set; }
        public DateTime? BedInPatientDate { get; set; }
        public UsedStatusEnum? UsedStatus { get; set; }
        public string DrAnesteziTescilNo { get; set; }
        public string Aciklama { get; set; }
        public bool? IsNewPricingType { get; set; }
        public Guid? RoomRef { get; set; }
        public Guid? RoomGroupRef { get; set; }
        public Guid? BedRef { get; set; }
        public Guid? ClinicRef { get; set; }
        public Guid? OzelDurumRef { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? BaseInpatientAdmissionRef { get; set; }

        #region Base Object Navigation Property
        public virtual BedProcedureWithoutBed BedProcedureWithoutBed { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResRoom Room { get; set; }
        public virtual ResRoomGroup RoomGroup { get; set; }
        public virtual ResBed Bed { get; set; }
        public virtual ResWard Clinic { get; set; }
        public virtual OzelDurum OzelDurum { get; set; }
        public virtual ResUser ResUser { get; set; }
        public virtual BaseInpatientAdmission BaseInpatientAdmission { get; set; }
        #endregion Parent Relations
    }
}