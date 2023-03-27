
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
    /// <summary>
    /// K-Çizelgesi
    /// </summary>
    public partial class KScheduleForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region KScheduleForm_PreScript
    if ( _KSchedule is KScheduleDaily )
            {
                this.DropStateButton(KSchedule.States.Approval);
            }
            else
            {
                this.DropStateButton(KSchedule.States.RequestPreparation);
            }
            
            KSchedule kSchedule = _KSchedule;
            ITTObject ttObject = (ITTObject)kSchedule;
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            if (ttObject.IsNew)
            {
                this.StartDate.Enabled = false;
                this.EndDate.Enabled = false;
                Store store;

                if (TTObjectClasses.SystemParameter.GetParameterValue("MKYS_INTEGRATED", "FALSE") == "FALSE")
                {
                    BindingList<PharmacyStoreDefinition> pharmacyStore = PharmacyStoreDefinition.GetInpatientPharmacyStore(readOnlyContext);
                    store = pharmacyStore[0];
                }
                else
                {
                    string storeId = TTObjectClasses.SystemParameter.GetParameterValue("PHARMACYSTOREOBJECTID", "");
                    if (storeId == "")
                    {
                        throw new TTException(" Eczahane Depo Parametresini Tanımlayın! ");
                    }
                    store = (Store)_KSchedule.ObjectContext.GetObject(Guid.Parse(storeId), typeof(Store));
                }

                _KSchedule.Store = store;
                
                
                BindingList<DrugOrderDetail> myDrugOrderDetails = null;
                
                if ( _KSchedule is KScheduleDaily )
                {
                    myDrugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsForDaily(_KSchedule.ObjectContext, (DateTime)kSchedule.StartDate, (DateTime)kSchedule.EndDate, _KSchedule.DestinationStore.ObjectID);
                }
                else
                {
                    myDrugOrderDetails = DrugOrderDetail.GetDrugOrderDetails(_KSchedule.ObjectContext, (DateTime)kSchedule.StartDate, (DateTime)kSchedule.EndDate, _KSchedule.DestinationStore.ObjectID);
                }
                Dictionary<Guid, double> detailsHashtable = new Dictionary<Guid, double>();

                double totalAmount = 0;

                foreach (DrugOrderDetail drugOrderDetail in myDrugOrderDetails)
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
                    Dictionary<Guid, DrugOrderDetail> unListDetails = new Dictionary<Guid, DrugOrderDetail>();
                    DrugOrder drugOrder = (DrugOrder)kSchedule.ObjectContext.GetObject(new Guid(de.Key.ToString()), "DRUGORDER");

                    Dictionary<object, double> rests = DrugOrderTransaction.GetPatientRestDose(drugOrder.Material, drugOrder.Episode);
                    foreach (KeyValuePair<object, double> rest in rests)
                    {
                        restDose = restDose + rest.Value ;
                    }

                    if (restDose == 0)
                    {
                        double rAmount = de.Value;
                        KScheduleMaterial kScheduleMaterial = KSchedule.CreateKScheduleMaterial(kSchedule.ObjectContext, drugOrder, de.Value);
                        kSchedule.StockActionOutDetails.Add(kScheduleMaterial);
                        IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, (DateTime)kSchedule.StartDate, (DateTime)kSchedule.EndDate);
                        KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(_KSchedule.ObjectContext);
                        foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class detail in drugOrderDetails)
                        {
                            DrugOrderDetail drugOrderDetail = (DrugOrderDetail)kSchedule.ObjectContext.GetObject((Guid)detail.ObjectID,"DRUGORDERDETAIL");
                            kScheduleCollectedOrder.DrugOrderDetails.Add(drugOrderDetail);
                        }
                        kScheduleMaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
                    }

                    if (restDose > 0 && restDose < (double)de.Value)
                    {
                        double rAmount = (double)de.Value - restDose;
                        KScheduleMaterial kScheduleMaterial = KSchedule.CreateKScheduleMaterial(kSchedule.ObjectContext, drugOrder, rAmount);
                        kSchedule.StockActionOutDetails.Add(kScheduleMaterial);
                        IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, (DateTime)kSchedule.StartDate, (DateTime)kSchedule.EndDate);
                        KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(_KSchedule.ObjectContext);
                        bool drugType = DrugOrder.GetDrugUsedType(((DrugDefinition)drugOrder.Material));
                        foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class detail in drugOrderDetails)
                        {
                            DrugOrderDetail drugOrderDetail = (DrugOrderDetail)kSchedule.ObjectContext.GetObject((Guid)detail.ObjectID, "DRUGORDERDETAIL");
                            if (rAmount >= detail.Amount)
                            {
                                rAmount -= (double)detail.Amount;
                                kScheduleCollectedOrder.DrugOrderDetails.Add(drugOrderDetail);
                            }
                            else
                            {
                                unListDetails.Add(drugOrderDetail.ObjectID, drugOrderDetail);
                            }
                        }
                        kScheduleMaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;

                    }

                    if(restDose > 0 && restDose >= (double)de.Value)
                    {
                        IList drugOrderDetails = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, (DateTime)kSchedule.StartDate, (DateTime)kSchedule.EndDate);
                        bool drugType = DrugOrder.GetDrugUsedType(((DrugDefinition)drugOrder.Material));
                        foreach (DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class detail in drugOrderDetails)
                        {
                            DrugOrderDetail drugOrderDetail = (DrugOrderDetail)kSchedule.ObjectContext.GetObject((Guid)detail.ObjectID, "DRUGORDERDETAIL");
                            unListDetails.Add(drugOrderDetail.ObjectID, drugOrderDetail);
                        }
                    }

                    if(unListDetails.Count>0)
                    {
                        TTObjectContext readonlyContext = new TTObjectContext(true);
                        Patient unlistPatient = (Patient)readonlyContext.GetObject(new Guid(drugOrder.Episode.Patient.ObjectID.ToString()), "PATIENT");
                        DrugDefinition unlistDrug = (DrugDefinition)readonlyContext.GetObject(new Guid(drugOrder.Material.ObjectID.ToString()),"DRUGDEFINITION");
                        KScheduleUnListMaterial kScheduleUnListMaterial = new KScheduleUnListMaterial(_KSchedule.ObjectContext);
                        kScheduleUnListMaterial.UnlistDrug = unlistDrug.Name ;
                        kScheduleUnListMaterial.UnlistPatient = unlistPatient.FullName;
                        bool drugType = DrugOrder.GetDrugUsedType(unlistDrug);
                        if (drugType)
                        {
                            kScheduleUnListMaterial.UnlistAmount = restDose;
                            kScheduleUnListMaterial.UnlistVolume = restDose * unlistDrug.Volume;
                        }
                        else
                        {
                            kScheduleUnListMaterial.UnlistAmount = restDose / unlistDrug.Volume;
                            kScheduleUnListMaterial.UnlistVolume = restDose;
                        }
                        kScheduleUnListMaterial.UnlistReason = "Hasta üzerinde bu ilaç bulunmaktadır.";
                        _KSchedule.KScheduleUnListMaterials.Add(kScheduleUnListMaterial);
                        foreach (KeyValuePair<Guid, DrugOrderDetail> unListDetail in unListDetails)
                        {
                            unListDetail.Value.KScheduleUnListMaterial = kScheduleUnListMaterial;
                        }
                    }
                }
            }
#endregion KScheduleForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region KScheduleForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            ITTObject ttObject = (ITTObject)_KSchedule;
            if (ttObject.IsNew)
            {
                TTFormClasses.DateForm dateform = new TTFormClasses.DateForm();
                TTFormClasses.KScheduleForm kScheduleForm = new TTFormClasses.KScheduleForm();
                KSchedule kSchedule = _KSchedule;
                dateform.ShowEdit(kScheduleForm.FindForm(), kSchedule);
            }
#endregion KScheduleForm_ClientSidePreScript

        }

#region KScheduleForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if(transDef.ToStateDefID == KSchedule.States.RequestPreparation || transDef.ToStateDefID == KSchedule.States.Approval)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                    objectID.Add("VALUE", _KSchedule.ObjectID.ToString());
                    parameter.Add("TTOBJECTID", objectID);
                    Type reportType = typeof(TTReportClasses.I_KScheduleReport);
                    if ( _KSchedule is KScheduleDaily )
                    {
                        reportType = typeof(TTReportClasses.I_KScheduleDailyReport);
                    }
                    TTReportTool.TTReport.PrintReport(reportType, true, 1, parameter);
                }
            }
        }
        
#endregion KScheduleForm_Methods
    }
}