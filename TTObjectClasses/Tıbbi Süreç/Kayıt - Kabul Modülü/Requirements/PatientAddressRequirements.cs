using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTUtils.RequirementManager;

namespace TTObjectClasses.Tıbbi_Süreç.Kayıt___Kabul_Modülü.Requirements
{
  
    public class PatientAddressRequirements : IRequirement
    {
        PatientIdentityAndAddress patientAddress = null;
        public PatientAddressRequirements(PatientIdentityAndAddress patientAddressParam)
        {
            patientAddress = patientAddressParam;

        }

        public RequirementResultCode ExecuteRequirement()
        {
            RequirementResultCode requirementResultCode = new RequirementResultCode();
            requirementResultCode.resultCode = 0;
            requirementResultCode.resultMessage = "Success";

            if (patientAddress == null)
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25776", "Hasta adresi tanımlı değildir.");
                return requirementResultCode;
            }
            if (patientAddress.HomeAddress == null || patientAddress.HomeAddress == "")
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25621", "Ev adresi alanı boş bırakılamaz.");
                return requirementResultCode;
            }
            if (patientAddress.MobilePhone == null || patientAddress.MobilePhone == "")
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25357", "Cep telefonu alanı boş bırakılamaz.");
                return requirementResultCode;
            }
            return requirementResultCode;
        }
    }

}
