using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class RadiologyTestDefinition
    {
        public Guid ObjectId { get; set; }
        public bool? OnMonday { get; set; }
        public string TabDescription { get; set; }
        public bool? OnTuesday { get; set; }
        public bool? OnWednesday { get; set; }
        public int? ProcedureTime { get; set; }
        public bool? IsRestrictedTest { get; set; }
        public int? TimeLimit { get; set; }
        public bool? OnThursday { get; set; }
        public bool? OnSaturday { get; set; }
        public bool? IsHeader { get; set; }
        public int? TabRow { get; set; }
        public bool? OnSunday { get; set; }
        public string TabName { get; set; }
        public RadiologyBodyPartEnum? BodyPart { get; set; }
        public bool? OnFriday { get; set; }
        public SexEnum? SexControl { get; set; }
        public bool? AccessionModalityRequires { get; set; }
        public bool? IsPassiveNow { get; set; }
        public long? TestID { get; set; }
        public string ReasonForPassive { get; set; }
        public bool? IsRISEntegratedTest { get; set; }
        public string PreInformation { get; set; }
        public int? EstimatedCompletionTime { get; set; }
        public Guid? TMRadTestRef { get; set; }
        public Guid? TestSubTypeRef { get; set; }
        public Guid? TestTabRef { get; set; }
        public Guid? TestTypeRef { get; set; }

        #region Base Object Navigation Property
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual RadiologyTestTypeDefinition TestSubType { get; set; }
        public virtual RadiologyTestTypeDefinition TestType { get; set; }
        #endregion Parent Relations
    }
}