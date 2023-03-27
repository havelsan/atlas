using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;

namespace RuleChecker.Interface
{
    public class RuleCheckParameters
    {
        public PatientInfoDto PatientInfo { get; set; }
        public EpisodeInfoDto EpisodeInfo { get; set; }
        public DateTime RuleCheckDate { get; set; }
        public IList<string> PatientIcd10DiagnosisList { get; set; }
        public IList<ProcedureRequestDetailDto> DetailList { get; set; }
        public IBranchRepository BranchRepository { get; set; }
        public IProcedureRepository ProcedureRepository { get; set; }
        public IPatientProcedureRepository PatientProcedureRepository { get; set; }
        public IIcd10Repository Icd10Repository { get; set; }
        public IList<ProcedureRequestDetailDto> NewEntries { get; set; }
    }
}
