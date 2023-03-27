using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PathologyMaterial
    {
        public Guid ObjectId { get; set; }
        public string ClinicalFindings { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfSampleTaken { get; set; }
        public Guid? Macroscopy { get; set; }
        public Guid? Microscopy { get; set; }
        public Guid? Note { get; set; }
        public Guid? PathologicDiagnosis { get; set; }
        public bool? Frozen { get; set; }
        public bool? Malign { get; set; }
        public string MaterialNumber { get; set; }
        public int? No { get; set; }
        public bool? SuspiciousMalign { get; set; }
        public bool? Benign { get; set; }
        public Guid? AlindigiDokununTemelOzelligiRef { get; set; }
        public Guid? MorfolojiKoduRef { get; set; }
        public Guid? NumuneAlinmaSekliRef { get; set; }
        public Guid? PatolojiPreparatiDurumuRef { get; set; }
        public Guid? YerlesimYeriRef { get; set; }
        public Guid? PathologyRequestRef { get; set; }
        public Guid? PathologyRef { get; set; }
        public Guid? ReasonForPathologyRejectionRef { get; set; }
        public Guid? KavanozTipiRef { get; set; }

        #region Parent Relations
        public virtual SKRSICDOMORFOLOJIKODU MorfolojiKodu { get; set; }
        public virtual SKRSICDOYERLESIMYERI YerlesimYeri { get; set; }
        public virtual PathologyRequest PathologyRequest { get; set; }
        public virtual Pathology Pathology { get; set; }
        public virtual PathologyJarTypeDef KavanozTipi { get; set; }
        #endregion Parent Relations
    }
}