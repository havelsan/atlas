//$0805DFF8
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class InfectionCommitteeServiceController
    {
        partial void AfterContextSaveScript_InfectionCommitteeForm(InfectionCommitteeFormViewModel viewModel, InfectionCommittee infectionCommittee, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("INFECTIONCOMMITTEEAFTERKSCHEDULE", "FALSE") == "TRUE")
            {
                if (transDef != null)
                {
                    if (transDef.ToStateDefID == InfectionCommittee.States.Completed)
                    {
                        KSchedule kScheduleNew = null;
                        DateTime startDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
                        DateTime endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");
                        BindingList<KSchedule> activeKschedules = KSchedule.GetActiveKSchedule(objectContext, infectionCommittee.InPatientPhysicianApplication.ObjectID, startDate, endDate);
                        if (activeKschedules.Count > 0)
                        {
                            kScheduleNew = activeKschedules[0];
                        }
                        else
                        {

                            kScheduleNew = new KSchedule(objectContext);
                            kScheduleNew.StartDate = startDate;
                            kScheduleNew.EndDate = endDate;
                            Store pharmacy = Store.GetPharmacyStore(objectContext);
                            if (pharmacy!= null)
                            {
                                kScheduleNew.Store = pharmacy;
                            }
                            kScheduleNew.DestinationStore = infectionCommittee.FromResource.Store;
                            kScheduleNew.Episode = infectionCommittee.Episode;
                            kScheduleNew.InPatientPhysicianApplication = infectionCommittee.InPatientPhysicianApplication;
                            kScheduleNew.MKYS_TeslimAlanObjID = Common.CurrentUser.UserObject.ObjectID;
                            kScheduleNew.MKYS_TeslimAlan = ((ResUser)Common.CurrentUser.UserObject).Name;
                            kScheduleNew.CurrentStateDefID = KSchedule.States.New;
                            kScheduleNew.Update();
                            kScheduleNew.CurrentStateDefID = KSchedule.States.Approval;
                            kScheduleNew.Update();
                            kScheduleNew.CurrentStateDefID = KSchedule.States.RequestPreparation;
                        }


                        if (infectionCommittee.InfectionCommitteeDetails.Count > 0)
                        {
                            foreach (InfectionCommitteeDetail order in infectionCommittee.InfectionCommitteeDetails)
                            {
                                if (kScheduleNew.KScheduleInfectionDrugs.Select(string.Empty).Count > 0)
                                {
                                    KScheduleInfectionDrug kScheduleInfectionDrug = kScheduleNew.KScheduleInfectionDrugs.Where(x => x.DrugOrderObjectID == order.DrugOrder.ObjectID).FirstOrDefault();
                                    if (kScheduleInfectionDrug != null)
                                        kScheduleInfectionDrug.IsApproved = true;
                                }

                                KScheduleMaterial ksmaterial = new KScheduleMaterial(objectContext);

                                double amount = 0;
                                foreach (DrugOrderDetail detail in order.DrugOrder.DrugOrderDetails)
                                {
                                    amount += Math.Round(detail.Amount.Value);
                                }

                                ksmaterial.RequestAmount = amount;
                                ksmaterial.Amount = amount;
                                ksmaterial.Material = order.DrugOrder.Material;
                                ksmaterial.IsImmediate =  order.DrugOrder.IsImmediate;
                                ksmaterial.BarcodeVerifyCounter = 0;
                                ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                                kScheduleNew.KScheduleMaterials.Add(ksmaterial);
                                KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(objectContext);
                                foreach (DrugOrderDetail detail in order.DrugOrder.DrugOrderDetails.Select(string.Empty))
                                {
                                    kScheduleCollectedOrder.DrugOrderDetails.Add(detail);
                                    detail.CurrentStateDefID = DrugOrderDetail.States.Request;
                                }
                                ksmaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;

                                kScheduleNew.EndDate = ((DateTime)(infectionCommittee.ActionDate)).AddDays(order.DrugOrder.Day.Value);
                            }
                        }
                    }
                    objectContext.Save();
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class InfectionCommitteeFormViewModel
    {
    }

    public class InFectionCommitteeDetailDTO
    {
        public InfectionCommitteeDetail InfectionCommitteeDetail { get; set; }
        public DateTime? PlannedStartTime { get; set; }
        public DateTime? PlannedEndTime { get; set; }
        public string DrugName { get; set; }
        public string Frequency { get; set; }
        public double DoseAmount { get; set; }
        public int Day { get; set; }
        public string UsageNote { get; set; }
        public bool? IsImmediate { get; set; }
        public bool? PatientOwnDrug { get; set; }
        public bool? CaseOfNeed { get; set; }
        public DrugOrderTypeEnum? DrugOrderType { get; set; }
        public string DoctorName { get; set; }
        public string UsageType { get; set; }
        public string Resource { get; set; }
    }


}