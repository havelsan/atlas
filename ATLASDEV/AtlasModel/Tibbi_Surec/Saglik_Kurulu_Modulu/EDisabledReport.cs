using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EDisabledReport
    {
        public Guid ObjectId { get; set; }
        public string ApplicationExplanation { get; set; }
        public string PatientAppId { get; set; }
        public EngelliRaporuMuracaatNedeniEnum? ApplicationReason { get; set; }
        public EngelliRaporuMuracaatTipiEnum? ApplicationType { get; set; }
        public EngelliRaporuKurumsalMuracaatTuruEnum? CorporateApplicationType { get; set; }
        public EngelliRaporuKisiselMuracaatTuruEnum? PersonalApplicationType { get; set; }
        public EngelliRaporuTerorKazaMuracaatTipiEnum? TerrorAccidentInjuryAppType { get; set; }
        public EngelliRaporuTerorKazaMuracaatNedeniEnum? TerrorAccidentInjuryAppReason { get; set; }
        public EngelliRaporuMuayeneAdimiEnum? ApplicationCouncilSituation { get; set; }
        public bool? IsCozgerReport { get; set; }
    }
}