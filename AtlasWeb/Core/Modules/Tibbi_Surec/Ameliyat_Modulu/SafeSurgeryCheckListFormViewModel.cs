//$CC5017B4
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class SafeSurgeryCheckListServiceController
    {
        partial void PreScript_SafeSurgeryCheckListForm(SafeSurgeryCheckListFormViewModel viewModel, SafeSurgeryCheckList safeSurgeryCheckList, TTObjectContext objectContext)
        {
            viewModel._Surgery = safeSurgeryCheckList.Surgery[0];
        }

        [HttpGet]
        public List<SurgeryChecklistModel> GetSafeSurgeryChecklistsBySurgery(Guid episodeActionId, string ObjectDefName = null)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if(ObjectDefName != null)
                {
                    InPatientTreatmentClinicApplication app = objectContext.GetObject<InPatientTreatmentClinicApplication>(episodeActionId);
                    InPatientPhysicianApplication phy = app.InPatientPhysicianApplication[0];
                    episodeActionId = phy.ObjectID;
                }
                var list = Surgery.GetSurgeryInfoByMasterAction(episodeActionId);
                List<SurgeryChecklistModel> checklists = new List<SurgeryChecklistModel>();

                foreach (Surgery.GetSurgeryInfoByMasterAction_Class item in list)
                {
                    if (item.Checklist != null)
                    {
                        SurgeryChecklistModel model = new SurgeryChecklistModel();
                        model.ChecklistID = item.Checklist;
                        model.RequestDate = item.RequestDate;
                        var procs = SurgeryProcedure.GetSurgeryProceduresBySurgery(item.ObjectID.ToString());
                        foreach (SurgeryProcedure.GetSurgeryProceduresBySurgery_Class procedure in procs)
                        {
                            model.Procedures += procedure.Code + "-" + procedure.Name + ", ";
                        }
                        model.Procedures = model.Procedures.Remove(model.Procedures.LastIndexOf(", "));
                        checklists.Add(model);
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return checklists;
            }

        }

        [HttpGet]
        public SafeSurgeryCheckList GetSafeSurgeryChecklistObject(Guid objectId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SafeSurgeryCheckList cl = objectContext.GetObject<SafeSurgeryCheckList>(objectId);
                List<SafeSurgeryCheckList> checklist = new List<SafeSurgeryCheckList>();
                objectContext.FullPartialllyLoadedObjects();
                return cl;
            }

        }

        partial void PostScript_SafeSurgeryCheckListForm(SafeSurgeryCheckListFormViewModel viewModel, SafeSurgeryCheckList safeSurgeryCheckList, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

        }


    }
}

namespace Core.Models
{
    public partial class SafeSurgeryCheckListFormViewModel : BaseViewModel
    {
        public Surgery _Surgery { get; set; }
    }
}
