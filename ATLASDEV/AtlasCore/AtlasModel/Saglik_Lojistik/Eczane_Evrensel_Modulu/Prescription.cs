using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Prescription
    {
        public Guid ObjectId { get; set; }
        public string PrescriptionNO { get; set; }
        public bool? IsSigned { get; set; }
        public string EHUUniqueNo { get; set; }
        public string EHURecetePassword { get; set; }
        public string DistributionNo { get; set; }
        public double? PrescriptionPrice { get; set; }
        public string EReceteDescription { get; set; }
        public PrescriptionTypeEnum? PrescriptionType { get; set; }
        public Guid? SignedData { get; set; }
        public ProvisionTypeEnum? ProvisionType { get; set; }
        public PrescriptionSubTypeEnum? PrescriptionSubType { get; set; }
        public string EReceteNo { get; set; }
        public DateTime? FillingDate { get; set; }
        public string ERecetePassword { get; set; }
        public bool? IsRepeated { get; set; }
        public Guid? PrescriptionPaperRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property
    }
}