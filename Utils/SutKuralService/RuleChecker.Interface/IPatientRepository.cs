using RuleChecker.Interface.Entities;

namespace RuleChecker.Interface
{
    public interface IPatientRepository
    {
        PatientInfoDto GetPatientInfo(object patientId);
    }
}
