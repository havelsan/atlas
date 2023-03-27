using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Gynecology
    {
        public Guid ObjectId { get; set; }
        public MenstrualCycleAbnormalitiesEnum? MenstrualCycleAbnormalities { get; set; }
        public string MenstrualCycleInformation { get; set; }
        public string GenitalExamination { get; set; }
        public string PelvicExamination { get; set; }
        public string VulvaVagen { get; set; }
        public string Cervix { get; set; }
        public string Uterus { get; set; }
        public string ReproductiveAbnormalitiesInfo { get; set; }
        public string GynecologicalHistory { get; set; }
        public string BasalUltrasound { get; set; }
        public string TumorMarkers { get; set; }
        public DateTime? LastExaminationDate { get; set; }
        public DateTime? LastSmearDate { get; set; }
        public BirthControlMethodEnum? PreviousBirthControlMethod { get; set; }
        public BirthControlMethodEnum? CurrentBirthControlMethod { get; set; }
        public bool? VaginalDischarge { get; set; }
        public GenitalAbnormalitiesEnum? GenitalAbnormalities { get; set; }
        public string GenitalAbnormalitiesInfo { get; set; }
        public bool? Dysuria { get; set; }
        public string DysuriaInformation { get; set; }
        public bool? Dyspareunia { get; set; }
        public string DyspareuniaInformation { get; set; }
        public bool? Hirsutism { get; set; }
        public string HirsutismInformation { get; set; }
        public string VaginalDischargeInformation { get; set; }
        public Guid? ReproductiveAbnormalityRef { get; set; }
    }
}