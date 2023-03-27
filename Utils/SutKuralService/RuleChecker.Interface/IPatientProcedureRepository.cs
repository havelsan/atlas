using RuleChecker.Interface.Entities;
using System.Collections.Generic;

namespace RuleChecker.Interface
{
    public interface IPatientProcedureRepository
    {
        IEnumerable<ProcedureRequestDetailDto> PatientProcedureList(object patientId, string procedureCode);
        IEnumerable<ProcedureRequestDetailDto> EpisodeProcedureList(object episodeId, string procedureCode);
        IEnumerable<ProcedureRequestDetailDto> EpisodeProcedureList(object episodeId);
    }
}
