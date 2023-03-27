//$FFF45EED
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DailyDrugScheduleServiceController : Controller
    {

        public class PrapareDailyDrugPatient_Input
        {
            public System.Guid storeID
            {
                get;
                set;
            }

            public System.DateTime startDate
            {
                get;
                set;
            }

            public System.DateTime endDate
            {
                get;
                set;
            }
            public System.Guid PatientObjectID
            {
                get;
                set;
            }
        }

        public class DailyDrugPatientDVO
        {
            public DailyDrugPatient dailyDrugPatient
            {
                get;
                set;
            }

            public List<DailyDrugPatientOrderDet> dailyDrugPatientOrderDets
            {
                get;
                set;
            }
        }

        public class PrapareDailyDrugPatient_Output
        {
            public List<DailyDrugPatientDVO> dailyDrugPatientDVOs
            {
                get;
                set;
            }
        }



        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Gunluk_Ilac_Cizelgesi_Yeni, TTRoleNames.Gunluk_Ilac_Cizelgesi_Tamam)]
        public PrepareDrugDetail_Output PrapareDailyDrugPatient(PrapareDailyDrugPatient_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                DateTime startDate = input.startDate;// Convert.ToDateTime(input.startDate.ToShortDateString() + " 00:00:00");
                DateTime endDate = input.endDate;// Convert.ToDateTime(input.endDate.ToShortDateString() + " 23:59:59");

                PrepareDrugDetail_Output prepareDrugDetail_Output = new PrepareDrugDetail_Output();
                prepareDrugDetail_Output.dailyDrugSchOrders = new List<DailyDrugSchOrder>();
                prepareDrugDetail_Output.dailyDrugSchOrderDetails = new List<DailyDrugSchOrderDetail>();
                prepareDrugDetail_Output.dailyDrugUnDrugs = new List<DailyDrugUnDrug>();
                prepareDrugDetail_Output.dailyDrugUnDrugDets = new List<DailyDrugUnDrugDet>();
                prepareDrugDetail_Output.details = new List<PrepareDrugDetail_Output_Detail>();
                prepareDrugDetail_Output.dailyDrugPatients = new List<DailyDrugPatient>();
                prepareDrugDetail_Output.udDrugDetails = new List<PrepareUnDrugDetail_Output_Detail>();
                //PrapareDailyDrugPatient_Output prapareDailyDrugPatient_Output = new Controllers.DailyDrugScheduleServiceController.PrapareDailyDrugPatient_Output();
                //prapareDailyDrugPatient_Output.dailyDrugPatientDVOs = new List<DailyDrugPatientDVO>();
                var ret = DailyDrugSchedule.PrapareDailyDrugPatient(context, input.storeID, startDate, endDate);

                foreach (DailyDrugPatient dailyDrugPatient in ret)
                {
                    foreach (DailyDrugSchOrder schOrder in dailyDrugPatient.DailyDrugSchOrders)
                    {

                        if (input.PatientObjectID != Guid.Empty)
                        {
                            if (schOrder.DailyDrugPatient.Episode.Patient.ObjectID == input.PatientObjectID)
                            {
                                PrepareDrugDetail_Output_Detail det = new PrepareDrugDetail_Output_Detail();
                                det.dailyDrugSchOrder = schOrder;
                                prepareDrugDetail_Output.dailyDrugSchOrders.Add(schOrder);
                                det.PatientName = schOrder.DailyDrugPatient.Episode.Patient.FullName;
                                det.Amount = (double)schOrder.DoseAmount;
                                det.DrugName = schOrder.Material.Name;

                                if (((DrugDefinition)schOrder.Material).IsNarcotic == null)
                                {
                                    det.IsNarcotic = false;
                                }
                                else
                                {
                                    det.IsNarcotic = (bool)((DrugDefinition)schOrder.Material).IsNarcotic;
                                }

                                if (((DrugDefinition)schOrder.Material).IsPsychotropic == null)
                                {
                                    det.IsPsychotropic = false;
                                }
                                else
                                {
                                    det.IsPsychotropic = (bool)((DrugDefinition)schOrder.Material).IsPsychotropic;
                                }

                                det.dailyDrugSchOrderDetails = new List<DailyDrugSchOrderDetail>();
                                foreach (DailyDrugSchOrderDetail schOrderDet in schOrder.DailyDrugSchOrderDetails)
                                {
                                    prepareDrugDetail_Output.dailyDrugSchOrderDetails.Add(schOrderDet);
                                    det.dailyDrugSchOrderDetails.Add(schOrderDet);
                                }
                                prepareDrugDetail_Output.dailyDrugPatients.Add(schOrder.DailyDrugPatient);
                                prepareDrugDetail_Output.details.Add(det);
                            }
                        }
                        else
                        {
                            PrepareDrugDetail_Output_Detail det = new PrepareDrugDetail_Output_Detail();
                            det.dailyDrugSchOrder = schOrder;
                            prepareDrugDetail_Output.dailyDrugSchOrders.Add(schOrder);
                            det.PatientName = schOrder.DailyDrugPatient.Episode.Patient.FullName;
                            det.Amount = (double)schOrder.DoseAmount;
                            det.DrugName = schOrder.Material.Name;

                            if(((DrugDefinition)schOrder.Material).IsNarcotic == null)
                            {
                                det.IsNarcotic = false;
                            }
                            else
                            {
                                det.IsNarcotic = (bool)((DrugDefinition)schOrder.Material).IsNarcotic;
                            }

                            if (((DrugDefinition)schOrder.Material).IsPsychotropic == null)
                            {
                                det.IsPsychotropic = false;
                            }
                            else
                            {
                                det.IsPsychotropic = (bool)((DrugDefinition)schOrder.Material).IsPsychotropic;
                            }

                           
                            det.dailyDrugSchOrderDetails = new List<DailyDrugSchOrderDetail>();
                            foreach (DailyDrugSchOrderDetail schOrderDet in schOrder.DailyDrugSchOrderDetails)
                            {
                                prepareDrugDetail_Output.dailyDrugSchOrderDetails.Add(schOrderDet);
                                det.dailyDrugSchOrderDetails.Add(schOrderDet);
                            }
                            prepareDrugDetail_Output.dailyDrugPatients.Add(schOrder.DailyDrugPatient);
                            prepareDrugDetail_Output.details.Add(det);
                        }
                    }

                    foreach (DailyDrugUnDrug schOrderUnDrug in dailyDrugPatient.DailyDrugUnDrugs)
                    {
                        PrepareUnDrugDetail_Output_Detail unDrug = new PrepareUnDrugDetail_Output_Detail();
                        unDrug.PatientName = schOrderUnDrug.DailyDrugPatient.Episode.Patient.FullName;
                        unDrug.DrugName = schOrderUnDrug.Material.Name;
                        unDrug.Amount = (double)schOrderUnDrug.DoseAmount;

                        prepareDrugDetail_Output.dailyDrugUnDrugs.Add(schOrderUnDrug);
                        foreach (DailyDrugUnDrugDet schOrderUnDrugDet in schOrderUnDrug.DailyDrugUnDrugDets)
                            prepareDrugDetail_Output.dailyDrugUnDrugDets.Add(schOrderUnDrugDet);

                        prepareDrugDetail_Output.udDrugDetails.Add(unDrug);
                    }
                }

                context.FullPartialllyLoadedObjects();
                return prepareDrugDetail_Output;
            }
        }

        public class PrepareDrugDetail_Input
        {
            public TTObjectClasses.DailyDrugPatient dailyDrugPatient
            {
                get;
                set;
            }

            public System.DateTime startDate
            {
                get;
                set;
            }

            public System.DateTime endDate
            {
                get;
                set;
            }

            public List<DailyDrugPatientOrderDet> dailyDrugPatientOrderDets
            {
                get;
                set;
            }
        }

        public class PrepareDrugDetail_Output
        {
            public List<DailyDrugSchOrder> dailyDrugSchOrders
            {
                get;
                set;
            }

            public List<DailyDrugUnDrug> dailyDrugUnDrugs
            {
                get;
                set;
            }

            public List<DailyDrugSchOrderDetail> dailyDrugSchOrderDetails
            {
                get;
                set;
            }

            public List<DailyDrugUnDrugDet> dailyDrugUnDrugDets
            {
                get;
                set;
            }

            public List<DailyDrugPatient> dailyDrugPatients
            {
                get;
                set;
            }
            public List<PrepareDrugDetail_Output_Detail> details
            {
                get;
                set;
            }

            public List<PrepareUnDrugDetail_Output_Detail> udDrugDetails
            {
                get;
                set;
            }
        }

        public class PrepareDrugDetail_Output_Detail
        {
            public string PatientName { get; set; }
            public string DrugName { get; set; }
            public double Amount { get; set; }
            public bool IsNarcotic { get; set; }
            public bool IsPsychotropic { get; set; }
            public DailyDrugSchOrder dailyDrugSchOrder { get; set; }
            public List<DailyDrugSchOrderDetail> dailyDrugSchOrderDetails { get; set; }
        }

        public class PrepareUnDrugDetail_Output_Detail
        {
            public string PatientName { get; set; }
            public string DrugName { get; set; }
            public double Amount { get; set; }
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Gunluk_Ilac_Cizelgesi_Yeni)]
        public PrepareDrugDetail_Output PrepareDrugDetail(PrepareDrugDetail_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                DateTime startDate = Convert.ToDateTime(input.startDate.ToShortDateString() + " 00:00:00");
                DateTime endDate = Convert.ToDateTime(input.endDate.ToShortDateString() + " 23:59:59");
                PrepareDrugDetail_Output prepareDrugDetail_Output = new Controllers.DailyDrugScheduleServiceController.PrepareDrugDetail_Output();
                prepareDrugDetail_Output.dailyDrugSchOrders = new List<DailyDrugSchOrder>();
                prepareDrugDetail_Output.dailyDrugUnDrugs = new List<DailyDrugUnDrug>();
                prepareDrugDetail_Output.dailyDrugSchOrderDetails = new List<DailyDrugSchOrderDetail>();
                prepareDrugDetail_Output.dailyDrugUnDrugDets = new List<DailyDrugUnDrugDet>();
                if (input.dailyDrugPatient != null)
                    input.dailyDrugPatient = (TTObjectClasses.DailyDrugPatient)context.AddObject(input.dailyDrugPatient);
                if (input.dailyDrugPatientOrderDets != null)
                {
                    foreach (DailyDrugPatientOrderDet det in input.dailyDrugPatientOrderDets)
                        context.AddObject(det);
                }

                var ret = DailyDrugSchedule.PrepareDrugDetail(context, input.dailyDrugPatient, startDate, endDate);
                foreach (DailyDrugSchOrder order in ret.DailyDrugSchOrders)
                {
                    prepareDrugDetail_Output.dailyDrugSchOrders.Add(order);
                    foreach (DailyDrugSchOrderDetail orderDetail in order.DailyDrugSchOrderDetails)
                    {
                        prepareDrugDetail_Output.dailyDrugSchOrderDetails.Add(orderDetail);
                    }
                }

                foreach (DailyDrugUnDrug unDrug in ret.DailyDrugUnDrugs)
                {
                    prepareDrugDetail_Output.dailyDrugUnDrugs.Add(unDrug);
                    foreach (DailyDrugUnDrugDet unDrugDetail in unDrug.DailyDrugUnDrugDets)
                    {
                        prepareDrugDetail_Output.dailyDrugUnDrugDets.Add(unDrugDetail);
                    }
                }

                context.FullPartialllyLoadedObjects();
                return prepareDrugDetail_Output;
            }
        }
    }
}