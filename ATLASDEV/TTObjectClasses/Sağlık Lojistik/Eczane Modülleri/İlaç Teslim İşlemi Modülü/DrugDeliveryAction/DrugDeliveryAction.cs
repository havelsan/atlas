
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
    /// İlaç Teslim İşlemi
    /// </summary>
    public partial class DrugDeliveryAction : EpisodeAction
    {
        public partial class GetDrugDeliveryReportQuery_Class : TTReportNqlObject
        {
        }

        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
            #region PreTransition_New2Completed

            if (DrugDeliveryActionDetails.Count > 0)
            {
                foreach (DrugDeliveryActionDetail drugDeliveryActionDetail in DrugDeliveryActionDetails)
                {
                    double restAmount = (Double)drugDeliveryActionDetail.ResDose;
                    DateTime useDate = DateTime.Now.AddMinutes(-5);
                    if (drugDeliveryActionDetail.DrugOrderTransaction.DrugOrder.SubEpisode != null)
                    {
                        if (drugDeliveryActionDetail.DrugOrderTransaction.DrugOrder.SubEpisode.ClosingDate != null)
                            useDate = drugDeliveryActionDetail.DrugOrderTransaction.DrugOrder.SubEpisode.ClosingDate.Value;
                    }

                    List<DrugOrderDetail> orderDetails = drugDeliveryActionDetail.DrugOrderTransaction.DrugOrder.DrugOrderDetails.Where(t => t.CurrentStateDefID == DrugOrderDetail.States.Supply).ToList();
                    if (orderDetails.Count > 0)
                    {
                        foreach (DrugOrderDetail drugOrderDetail in orderDetails)
                        {
                            if (restAmount > 0)
                            {
                                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.PatientDelivery;
                                drugOrderDetail.OrderPlannedDate = useDate;
                                drugOrderDetail.CreationDate = useDate;
                                restAmount = restAmount - (double)drugOrderDetail.Amount;
                            }
                            else
                            {
                                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ExPharmacySupply)
                                {
                                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.PatientDelivery;
                                    drugOrderDetail.CreationDate = useDate;
                                    drugOrderDetail.OrderPlannedDate = useDate;
                                }
                                else
                                {
                                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                                }
                            }
                        }
                        if (restAmount > 0)
                        {
                            CreateNewDrugOrderDetail(drugDeliveryActionDetail, restAmount, useDate);
                        }
                    }
                    else
                    {
                        CreateNewDrugOrderDetail(drugDeliveryActionDetail, restAmount, useDate);
                    }
                }
            }


            #endregion PreTransition_New2Completed
        }

        private void CreateNewDrugOrderDetail(DrugDeliveryActionDetail drugDeliveryActionDetail, double restAmount, DateTime useDate)
        {
            DrugOrderDetail newDrugOrderDetail = new DrugOrderDetail(ObjectContext);
            DrugOrder drugOrder = drugDeliveryActionDetail.DrugOrderTransaction.DrugOrder;
            newDrugOrderDetail.Amount = restAmount;

            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);
            DrugDefinition drug = (DrugDefinition)drugOrder.Material;

            if (drugType)
                newDrugOrderDetail.DoseAmount = drugOrder.DoseAmount;
            else
                newDrugOrderDetail.DoseAmount = restAmount * drug.Volume;

            newDrugOrderDetail.ActionDate = useDate;
            newDrugOrderDetail.CreationDate = useDate;
            newDrugOrderDetail.Day = drugOrder.Day;
            newDrugOrderDetail.DrugDeliveryActionDetail = drugDeliveryActionDetail;
            newDrugOrderDetail.DrugOrder = drugOrder;
            newDrugOrderDetail.Episode = drugOrder.Episode;
            newDrugOrderDetail.Frequency = drugOrder.Frequency;
            newDrugOrderDetail.FromResource = drugOrder.FromResource;
            newDrugOrderDetail.MasterResource = MasterResource;
            newDrugOrderDetail.Material = drugOrder.Material;
            newDrugOrderDetail.Note = TTUtils.CultureService.GetText("M25869", "Hastaya / Hasta Yakınına teslim edildi.");
            newDrugOrderDetail.NursingApplication = drugOrder.NursingApplication;
            newDrugOrderDetail.OrderPlannedDate = useDate;
            newDrugOrderDetail.PlannedStartTime = useDate;
            newDrugOrderDetail.Store = drugOrder.Store;
            newDrugOrderDetail.UsageNote = drugOrder.UsageNote;
            newDrugOrderDetail.SubEpisode = drugOrder.SubEpisode;
            newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
            newDrugOrderDetail.Update();
            newDrugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.PatientDelivery;
            newDrugOrderDetail.Update();
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugDeliveryAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DrugDeliveryAction.States.New && toState == DrugDeliveryAction.States.Completed)
                PreTransition_New2Completed();
        }

    }
}