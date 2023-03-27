
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class DailyDrugScheduleNewForm : BaseDailyDrugScheduleForm
    {
        #region methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == DailyDrugSchedule.States.Completed)
                {
                    List<KSchedule> KSchedulePatients = new List<KSchedule>();
                    if (this._DailyDrugSchedule.DailyDrugPatients.Count > 0)
                    {
                        foreach (DailyDrugPatient patient in this._DailyDrugSchedule.DailyDrugPatients)
                        {
                            if (patient.IsCheck == true)
                            {
                                KSchedule kScheduleNew = new KSchedule(_DailyDrugSchedule.ObjectContext);
                                kScheduleNew.StartDate = this._DailyDrugSchedule.StartDate;
                                kScheduleNew.EndDate = this._DailyDrugSchedule.EndDate;
                                kScheduleNew.Store = this._DailyDrugSchedule.Store;
                                kScheduleNew.DestinationStore = this._DailyDrugSchedule.DestinationStore;
                                kScheduleNew.Episode = patient.Episode;
                                kScheduleNew.CurrentStateDefID = KSchedule.States.New;
                                kScheduleNew.DailyDrugSchedule = this._DailyDrugSchedule;
                                KSchedulePatients.Add(kScheduleNew);
                            }
                        }
                    }
                    foreach (KSchedule kschedule in KSchedulePatients)
                    {
                        if (this._DailyDrugSchedule.DailyDrugSchOrders.Count > 0)
                        {
                            foreach (DailyDrugSchOrder order in this._DailyDrugSchedule.DailyDrugSchOrders)
                            {
                                if (order.DailyDrugPatient.ObjectID == kschedule.Episode.ObjectID)
                                {
                                    KScheduleMaterial ksmaterial = new KScheduleMaterial(_DailyDrugSchedule.ObjectContext);
                                    ksmaterial.RequestAmount = order.DoseAmount;
                                    ksmaterial.Amount = order.DoseAmount;
                                    ksmaterial.Material = order.Material;
                                    ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                                    kschedule.KScheduleMaterials.Add(ksmaterial);

                                    KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(_DailyDrugSchedule.ObjectContext);
                                    foreach (DailyDrugSchOrderDetail detail in order.DailyDrugSchOrderDetails.Select(string.Empty))
                                    {
                                        kScheduleCollectedOrder.DrugOrderDetails.Add(detail.DrugOrderDetail);
                                    }
                                    ksmaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
                                }
                            }
                        }

                        if (this._DailyDrugSchedule.DailyDrugUnDrugs.Count > 0)
                        {
                            foreach (DailyDrugUnDrug unDrug in this._DailyDrugSchedule.DailyDrugUnDrugs)
                            {
                                if (unDrug.DailyDrugPatient.Episode.ObjectID == kschedule.Episode.ObjectID)
                                {
                                    KScheduleUnListMaterial ksUnMaterial = new KScheduleUnListMaterial(_DailyDrugSchedule.ObjectContext);
                                    ksUnMaterial.UnlistAmount = unDrug.DoseAmount;
                                    ksUnMaterial.UnlistVolume = unDrug.UnlistVolume;
                                    ksUnMaterial.UnlistDrug = unDrug.Material.Name;
                                    ksUnMaterial.UnlistReason = "Hasta üzerinde bu ilaç bulunmaktadýr.";
                                    ksUnMaterial.KSchedule = kschedule;
                                }
                            }
                        }




                    }
                }
                _DailyDrugSchedule.ObjectContext.Save();
            }
            #endregion methods

        }
    }
}