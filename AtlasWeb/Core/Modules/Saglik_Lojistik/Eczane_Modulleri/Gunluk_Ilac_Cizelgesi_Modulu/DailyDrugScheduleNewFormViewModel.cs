//$534093E8
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class DailyDrugScheduleServiceController
    {
        partial void PreScript_DailyDrugScheduleNewForm(DailyDrugScheduleNewFormViewModel viewModel, DailyDrugSchedule dailyDrugSchedule, TTObjectContext objectContext)
        {
            int startTime = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("DAILYDRUGSCHEDULESTARTDATE", "8"));
            DateTime ts = DateTime.Now;
            dailyDrugSchedule.StartDate = new DateTime(ts.Year, ts.Month, ts.Day, startTime, 0, 0);
            dailyDrugSchedule.EndDate = ((DateTime)dailyDrugSchedule.StartDate).AddDays(1).AddSeconds(-1);
        }

        partial void AfterContextSaveScript_DailyDrugScheduleNewForm(DailyDrugScheduleNewFormViewModel viewModel, DailyDrugSchedule dailyDrugSchedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == DailyDrugSchedule.States.Completed)
                {
                    List<InPatientPhysicianApplication> inPatientPhysApps = new List<InPatientPhysicianApplication>();
                    if (dailyDrugSchedule.DailyDrugSchOrders.Count > 0)
                    {
                        foreach (DailyDrugSchOrder order in dailyDrugSchedule.DailyDrugSchOrders)
                        {
                            if (order.DailyDrugPatient.InPatientPhysicianApplication != null)
                            {
                                if (inPatientPhysApps.Contains(order.DailyDrugPatient.InPatientPhysicianApplication) == false)
                                    inPatientPhysApps.Add(order.DailyDrugPatient.InPatientPhysicianApplication);
                            }
                        }
                    }

                    foreach (InPatientPhysicianApplication inPatientApp in inPatientPhysApps)
                    {
                        KSchedule kScheduleNew = new KSchedule(objectContext);
                        kScheduleNew.StartDate = dailyDrugSchedule.StartDate;
                        kScheduleNew.EndDate = dailyDrugSchedule.EndDate;
                        kScheduleNew.Store = dailyDrugSchedule.Store;
                        kScheduleNew.DestinationStore = dailyDrugSchedule.DestinationStore;
                        kScheduleNew.Episode = inPatientApp.Episode;
                        kScheduleNew.DailyDrugSchedule = dailyDrugSchedule;
                        kScheduleNew.InPatientPhysicianApplication = inPatientApp;
                        kScheduleNew.MKYS_TeslimAlanObjID = Common.CurrentUser.UserObject.ObjectID;
                        kScheduleNew.MKYS_TeslimAlan = ((ResUser)Common.CurrentUser.UserObject).Name;

                        List<DailyDrugSchOrder> orders = dailyDrugSchedule.DailyDrugSchOrders.Where(t => t.DailyDrugPatient.InPatientPhysicianApplication.ObjectID == inPatientApp.ObjectID).ToList();

                        foreach (DailyDrugSchOrder order in orders)
                        {
                            KScheduleMaterial ksmaterial = new KScheduleMaterial(objectContext);
                            ksmaterial.RequestAmount = order.DoseAmount;
                            ksmaterial.Amount = order.DoseAmount;
                            ksmaterial.Material = order.Material;
                            ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                            kScheduleNew.KScheduleMaterials.Add(ksmaterial);
                            KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(objectContext);
                            foreach (DailyDrugSchOrderDetail detail in order.DailyDrugSchOrderDetails.Select(string.Empty))
                            {
                                kScheduleCollectedOrder.DrugOrderDetails.Add(detail.DrugOrderDetail);
                                detail.DrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Request;
                            }

                            ksmaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
                        }
                        kScheduleNew.CurrentStateDefID = KSchedule.States.New;
                        kScheduleNew.Update();
                        kScheduleNew.CurrentStateDefID = KSchedule.States.Approval;
                        kScheduleNew.Update();
                        kScheduleNew.CurrentStateDefID = KSchedule.States.RequestPreparation;
                    }

                    if (dailyDrugSchedule.DailyDrugUnDrugs.Count > 0)
                    {
                        foreach (DailyDrugUnDrug unDrug in dailyDrugSchedule.DailyDrugUnDrugs)
                        {
                            foreach (DailyDrugUnDrugDet unDetail in unDrug.DailyDrugUnDrugDets)
                            {
                                unDetail.DrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                            }
                        }
                    }
                }
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class DailyDrugScheduleNewFormViewModel
    {
    }
}