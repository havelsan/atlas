//$D7BB2081
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using TTStorageManager;

namespace Core.Controllers
{
    public partial class NuclearMedicineServiceController
    {
        partial void PreScript_NuclearMedicineRadioPharmacyForm(NuclearMedicineRadioPharmacyFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTObjectContext objectContext)
        {
            nuclearMedicine.InjectedBy = Common.CurrentResource;
        }

        partial void PostScript_NuclearMedicineRadioPharmacyForm(NuclearMedicineRadioPharmacyFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (String.IsNullOrEmpty(nuclearMedicine.NuclearMedicineTests[0].AccessionNo))
            {
                Guid AccessionNumber = new Guid("a40495b0-9265-432c-9467-f2b14f3b020c");
                nuclearMedicine.NuclearMedicineTests[0].AccessionNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[AccessionNumber], null, null).ToString();
            }
        }

        partial void AfterContextSaveScript_NuclearMedicineRadioPharmacyForm(NuclearMedicineRadioPharmacyFormViewModel viewModel, NuclearMedicine nuclearMedicine, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE")
            {
                if (transDef != null)
                {
                    if (transDef.ToStateDefID == NuclearMedicine.States.Procedure)
                    {
                        string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
                        if (sysparam == "TRUE")
                        {
                            List<Guid> appIDs = new List<Guid>();
                            foreach (NuclearMedicineTest test in nuclearMedicine.NuclearMedicineTests)
                            {
                                appIDs.Add(test.ObjectID);
                            }

                            if (TTObjectClasses.SystemParameter.GetParameterValue("USEASYNCSERVER", "FALSE") == "TRUE")
                            {
                                TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01", "PACS");
                            }
                            else
                            {
                                //InternalTCPClient.HL7Remoting.SendHospitalMessageToEngine(appIDs, "O01", InternalTCPClient.HL7ServerNames.PACS);
                                HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(appIDs, "O01", HL7ServerNames.PACS);

                            }
                        }
                    }
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class NuclearMedicineRadioPharmacyFormViewModel: BaseViewModel
    {
    }
}
