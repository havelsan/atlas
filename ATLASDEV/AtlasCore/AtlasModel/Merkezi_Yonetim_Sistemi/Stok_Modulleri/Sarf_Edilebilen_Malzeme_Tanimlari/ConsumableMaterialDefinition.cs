using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ConsumableMaterialDefinition
    {
        public Guid ObjectId { get; set; }
        public bool? IsAllogreft { get; set; }
        public SexEnum? SEX { get; set; }
        public int? MaxPatientAge { get; set; }
        public int? MinPatientAge { get; set; }
        public double? OrderRPTDay { get; set; }
        public Guid? SpecificationFile { get; set; }
        public string SpecificationFileName { get; set; }
        public DateTime? SpecificationUploadDate { get; set; }
        public bool? NotAppearInEpicrisis { get; set; }
        public bool? HasEstimatedTime { get; set; }
        public Guid? ParentConsumableMaterialRef { get; set; }

        #region Base Object Navigation Property
        public virtual Material Material { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ConsumableMaterialDefinition ParentConsumableMaterial { get; set; }
        #endregion Parent Relations
    }
}