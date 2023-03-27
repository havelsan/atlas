//$C3BCD385
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
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class ManagerPrescriptionCountsServiceController
    {
        partial void PreScript_ManagerPrescriptionCountForm(ManagerPrescriptionCountFormViewModel viewModel, ManagerPrescriptionCounts managerPrescriptionCounts, TTObjectContext objectContext)
        {            
            var oldPrescriptionCounts = ManagerPrescriptionCounts.GetManagerPrescriptions(objectContext, "WHERE CANCELLED =0 OR CANCELLED IS NULL ").ToList();
            foreach (var oldPrescription in oldPrescriptionCounts)
            {
                OldAddedCounts oldAddedCounts = new OldAddedCounts();
                oldAddedCounts.ObjectId = oldPrescription.ObjectID;
                oldAddedCounts.AddedUser = oldPrescription.AddedUser.Name;
                oldAddedCounts.ePrescriptionCount = oldPrescription.ePrescriptionCount.ToString();
                oldAddedCounts.EmergencyPrescriptionCount = oldPrescription.EmergencyPrescriptionCount != null ? oldPrescription.EmergencyPrescriptionCount.ToString() : "";
                oldAddedCounts.PoliclinicPrescriptionCount = oldPrescription.PoliclinicPrescriptionCount != null ? oldPrescription.PoliclinicPrescriptionCount.ToString() : "";
                oldAddedCounts.PrescriptionCountRate = oldPrescription.PrescriptionCountRate;
                oldAddedCounts.TotalPrescriptionCounts = oldPrescription.TotalPrescriptionCounts;
                oldAddedCounts.StartDate = (DateTime) oldPrescription.StartDate;
                oldAddedCounts.EndDate = (DateTime)oldPrescription.EndDate;
                oldAddedCounts.LastUpdate = (DateTime)oldPrescription.LastUpdate;

                oldAddedCounts.doctorName = oldPrescription.ResUser != null ? oldPrescription.ResUser.Name : "";
                viewModel.oldCounts.Add(oldAddedCounts);
            }
            ContextToViewModel(viewModel,objectContext);
        }

        partial void PostScript_ManagerPrescriptionCountForm(ManagerPrescriptionCountFormViewModel viewModel, ManagerPrescriptionCounts managerPrescriptionCounts, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (managerPrescriptionCounts.AddedUser == null)
            {
                managerPrescriptionCounts.AddedUser = Common.CurrentResource;
            }
        }

        [HttpGet]
        public bool CancelAddedManagerPrescriptionCount(Guid ObjectId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var managerPrescriptionCount = objectContext.GetObject<ManagerPrescriptionCounts>(ObjectId);

                if(managerPrescriptionCount != null)
                {
                    managerPrescriptionCount.Cancelled = true;
                    objectContext.Save();
                    return true;
                }
            }
            return false;
        }

    }
}

namespace Core.Models
{
    public partial class ManagerPrescriptionCountFormViewModel: BaseViewModel
    {
        public List<OldAddedCounts> oldCounts = new List<OldAddedCounts>();
    }

    public class OldAddedCounts
    {
        public Guid ObjectId { get; set; }
        public string AddedUser { get; set; }
        public string ePrescriptionCount { get; set; }
        public string EmergencyPrescriptionCount { get; set; }
        public string PoliclinicPrescriptionCount { get; set; }
        public string PrescriptionCountRate { get; set; }
        public string TotalPrescriptionCounts { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public string doctorName { get; set; }
    }
}
