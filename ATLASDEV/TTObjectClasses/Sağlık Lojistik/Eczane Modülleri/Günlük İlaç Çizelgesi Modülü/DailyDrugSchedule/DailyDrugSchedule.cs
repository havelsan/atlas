using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;



namespace TTObjectClasses
{
    /// <summary>
    /// Günlük İlaç Çizelgesi
    /// </summary>
    public partial class DailyDrugSchedule : StockAction
    {

        public static List<DailyDrugPatient> PrapareDailyDrugPatient(TTObjectContext context, Guid storeID, DateTime startDate, DateTime endDate)
        {
            //TTObjectContext context = new TTObjectContext(false);
            List<DailyDrugPatient> dailyDrugPatients = new List<DailyDrugPatient>();
            BindingList<DrugOrderDetail> myDrugOrderDetails = DrugOrderDetail.GetDrugOrderDetails(context, startDate, endDate, storeID);
            Dictionary<Guid, double> detailsHashtable = new Dictionary<Guid, double>();
            double totalAmount = 0;
            foreach (DrugOrderDetail drugOrderDetail in myDrugOrderDetails)
            {
                bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
                if (drugOrderDetail.DrugOrder != null && drugOrderDetail.Amount > 0)
                {
                    if (detailsHashtable.ContainsKey(drugOrderDetail.DrugOrder.ObjectID))
                    {
                        totalAmount = 0;
                        totalAmount = detailsHashtable[drugOrderDetail.DrugOrder.ObjectID];
                        if (drugType)
                            totalAmount += (double)drugOrderDetail.Amount;
                        else
                            totalAmount += (double)drugOrderDetail.DoseAmount;
                        detailsHashtable[drugOrderDetail.DrugOrder.ObjectID] = totalAmount;
                    }
                    else
                    {
                        if (drugType)
                            detailsHashtable.Add(drugOrderDetail.DrugOrder.ObjectID, (double)drugOrderDetail.Amount);
                        else
                            detailsHashtable.Add(drugOrderDetail.DrugOrder.ObjectID, (double)drugOrderDetail.DoseAmount);
                    }
                }
            }

            foreach (KeyValuePair<Guid, double> de in detailsHashtable)
            {
                DrugOrder drugOrder = (DrugOrder)context.GetObject(de.Key, typeof(DrugOrder));
                IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, startDate, endDate);
                if (dailyDrugPatients.Select(t => t.Episode.Patient == drugOrder.Episode.Patient).FirstOrDefault())
                {
                    DailyDrugPatient findDailyDrugPatient = dailyDrugPatients.Where(t => t.Episode.Patient == drugOrder.Episode.Patient).FirstOrDefault();
                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class orderDetail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)orderDetail.ObjectID, typeof(DrugOrderDetail));
                        DailyDrugPatientOrderDet dailyDrugPatientOrderDet = new DailyDrugPatientOrderDet(context);
                        dailyDrugPatientOrderDet.DrugOrderDetail = drugOrderDetail;
                        findDailyDrugPatient.DailyDrugPatientOrderDets.Add(dailyDrugPatientOrderDet);
                    }
                }
                else
                {
                    DailyDrugPatient dailyDrugPatient = new DailyDrugPatient(context);
                    dailyDrugPatient.Episode = drugOrder.Episode;
                    dailyDrugPatient.InPatientPhysicianApplication = drugOrder.InPatientPhysicianApplication;
                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class orderDetail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)orderDetail.ObjectID, typeof(DrugOrderDetail));
                        DailyDrugPatientOrderDet dailyDrugPatientOrderDet = new DailyDrugPatientOrderDet(context);
                        dailyDrugPatientOrderDet.DrugOrderDetail = drugOrderDetail;
                        dailyDrugPatient.DailyDrugPatientOrderDets.Add(dailyDrugPatientOrderDet);
                    }

                    dailyDrugPatients.Add(dailyDrugPatient);
                    /*List<DailyDrugPatient> prepareDailyDrugPatients = new List<DailyDrugPatient>(); 
                    foreach(DailyDrugPatient p in dailyDrugPatients)
                    {
                        DailyDrugPatient prepareDailyDrugPatient = PrepareDrugDetail(context, p, startDate, endDate);
                        prepareDailyDrugPatients.Add(prepareDailyDrugPatient);
                    }*/
                }
            }

            List<DailyDrugPatient> prepareDailyDrugPatients = new List<DailyDrugPatient>();
            foreach (DailyDrugPatient p in dailyDrugPatients)
            {
                DailyDrugPatient prepareDailyDrugPatient = PrepareDrugDetail(context, p, startDate, endDate);
                prepareDailyDrugPatients.Add(prepareDailyDrugPatient);
            }


            return dailyDrugPatients;
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Gunluk_Ilac_Cizelgesi_Yeni)]
        public static DailyDrugPatient PrepareDrugDetail(TTObjectContext context, DailyDrugPatient dailyDrugPatient, DateTime startDate, DateTime endDate)
        {
            //TTObjectContext context = new TTObjectContext(false);
            List<DrugOrderDetail> allDrugOrderDetails = new List<DrugOrderDetail>();
            foreach (DailyDrugPatientOrderDet det in dailyDrugPatient.DailyDrugPatientOrderDets)
                allDrugOrderDetails.Add(det.DrugOrderDetail);
            Dictionary<Guid, double> detailsHashtable = new Dictionary<Guid, double>();
            double totalAmount = 0;
            foreach (DrugOrderDetail drugOrderDetail in allDrugOrderDetails)
            {
                if (drugOrderDetail.DrugOrder != null && drugOrderDetail.Amount > 0)
                {
                    if (detailsHashtable.ContainsKey(drugOrderDetail.DrugOrder.ObjectID))
                    {
                        totalAmount = 0;
                        totalAmount = detailsHashtable[drugOrderDetail.DrugOrder.ObjectID];
                        totalAmount += (double)drugOrderDetail.Amount;
                        detailsHashtable[drugOrderDetail.DrugOrder.ObjectID] = totalAmount;
                    }
                    else
                    {
                        detailsHashtable.Add(drugOrderDetail.DrugOrder.ObjectID, (double)drugOrderDetail.Amount);
                    }
                }
            }

            foreach (KeyValuePair<Guid, double> de in detailsHashtable)
            {
                double restDose = 0;
                List<DrugOrderDetail> unListDetails = new List<DrugOrderDetail>();
                DrugOrder drugOrder = (DrugOrder)context.GetObject(de.Key, typeof(DrugOrder));
                bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);
                Dictionary<object, double> rests = DrugOrderTransaction.GetPatientRestDose(drugOrder.Material, drugOrder.Episode);
                foreach (KeyValuePair<object, double> rest in rests)
                {
                    restDose = restDose + rest.Value;
                }

                if (restDose == 0)
                {
                    double rAmount = de.Value;
                    DailyDrugSchOrder schOrder = new DailyDrugSchOrder(context);
                    schOrder.Material = drugOrder.Material;
                    if (drugType)
                        schOrder.DoseAmount = rAmount;
                    else
                        schOrder.DoseAmount = Math.Ceiling(rAmount / (double)((DrugDefinition)drugOrder.Material).Volume);
                    schOrder.DailyDrugPatient = dailyDrugPatient;
                    IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, startDate, endDate);
                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class orderDetail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)orderDetail.ObjectID, typeof(DrugOrderDetail));
                        DailyDrugSchOrderDetail schdetail = new DailyDrugSchOrderDetail(context);
                        schdetail.DrugOrderDetail = drugOrderDetail;
                        schdetail.DailyDrugSchOrder = schOrder;
                    }

                    dailyDrugPatient.DailyDrugSchOrders.Add(schOrder);
                }

                if (restDose > 0 && restDose < (double)de.Value)
                {
                    double rAmount = (double)de.Value - restDose;
                    IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, startDate, endDate);
                    //bool drugType = DrugOrder.GetDrugUsedType(((DrugDefinition)drugOrder.Material));
                    List<DrugOrderDetail> schOrderDetails = new List<DrugOrderDetail>();
                    double schamount = 0;
                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class detail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                        if (rAmount >= detail.Amount)
                        {
                            if (drugType)
                            {
                                rAmount -= (double)drugOrderDetail.Amount;
                                schOrderDetails.Add(drugOrderDetail);
                                schamount += (double)drugOrderDetail.Amount;
                            }
                            else
                            {
                                rAmount -= (double)drugOrderDetail.DoseAmount;
                                schOrderDetails.Add(drugOrderDetail);
                                schamount += (double)drugOrderDetail.DoseAmount;
                            }
                        }
                        else
                        {
                            unListDetails.Add(drugOrderDetail);
                        }
                    }

                    DailyDrugSchOrder schOrder = new DailyDrugSchOrder(context);
                    schOrder.Material = drugOrder.Material;
                    if (drugType)
                        schOrder.DoseAmount = schamount;
                    else
                        schOrder.DoseAmount = Math.Ceiling(schamount / (double)((DrugDefinition)drugOrder.Material).Volume);
                    schOrder.DailyDrugPatient = dailyDrugPatient;
                    foreach (DrugOrderDetail orderDetail in schOrderDetails)
                    {
                        DailyDrugSchOrderDetail schdetail = new DailyDrugSchOrderDetail(context);
                        schdetail.DrugOrderDetail = orderDetail;
                        schdetail.DailyDrugSchOrder = schOrder;
                    }

                    dailyDrugPatient.DailyDrugSchOrders.Add(schOrder);
                }

                if (restDose > 0 && restDose >= (double)de.Value)
                {
                    IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, startDate, endDate);
                    //bool drugType = DrugOrder.GetDrugUsedType(((DrugDefinition)drugOrder.Material));
                    foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class detail in drugOrderDetails)
                    {
                        DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                        unListDetails.Add(drugOrderDetail);
                    }
                }

                if (unListDetails.Count > 0)
                {
                    DailyDrugUnDrug undrug = new DailyDrugUnDrug(context);
                    undrug.Material = drugOrder.Material;
                    //bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);
                    if (drugType)
                    {
                        undrug.DoseAmount = restDose;
                        undrug.UnlistVolume = restDose * ((DrugDefinition)drugOrder.Material).Volume;
                    }
                    else
                    {
                        undrug.DoseAmount = restDose / ((DrugDefinition)drugOrder.Material).Volume;
                        undrug.UnlistVolume = restDose;
                    }

                    undrug.DailyDrugPatient = dailyDrugPatient;
                    foreach (DrugOrderDetail unDrugDetail in unListDetails)
                    {
                        DailyDrugUnDrugDet unDetail = new DailyDrugUnDrugDet(context);
                        unDetail.DrugOrderDetail = unDrugDetail;
                        unDetail.DailyDrugUnDrug = undrug;
                    }
                }
            }

            return dailyDrugPatient;
        }


    }
}