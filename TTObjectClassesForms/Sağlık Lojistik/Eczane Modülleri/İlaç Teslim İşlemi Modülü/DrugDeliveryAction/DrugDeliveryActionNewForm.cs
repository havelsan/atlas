
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
    /// İlaç Teslim İşlemi
    /// </summary>
    public partial class DrugDeliveryActionNewForm : TTForm
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
#region DrugDeliveryActionNewForm_PreScript
    base.PreScript();

            BindingList<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class> allDrugOrderTransaction = DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ(_DrugDeliveryAction.Episode.ObjectID);
            Dictionary<Guid, DrugOrder> drugOrderList = new Dictionary<Guid, DrugOrder>();

            foreach (DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class  drugOrderTransaction in allDrugOrderTransaction)
            {
                if (drugOrderList.ContainsKey((Guid)drugOrderTransaction.Drugorder) == false)
                {
                    DrugOrderTransaction trx = (DrugOrderTransaction)_DrugDeliveryAction.ObjectContext.GetObject((Guid)drugOrderTransaction.ObjectID, "DRUGORDERTRANSACTION");
                    DrugOrder order = (DrugOrder)_DrugDeliveryAction.ObjectContext.GetObject((Guid)drugOrderTransaction.Drugorder, "DRUGORDER");
                    drugOrderList.Add((Guid)drugOrderTransaction.Drugorder, order);
                    DrugDefinition drugDefinition = (DrugDefinition)_DrugDeliveryAction.ObjectContext.GetObject((Guid)drugOrderTransaction.Drugdefinition , "DRUGDEFINITION"); 
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    if (drugType)
                    {
                        if (DrugOrderTransaction.GetRestDose(order) > 0)
                        {
                            DrugDeliveryActionDetail drugDeliveryActionDetail = _DrugDeliveryAction.DrugDeliveryActionDetails.AddNew();
                            drugDeliveryActionDetail.ResDose = DrugOrderTransaction.GetRestDose(order);
                            drugDeliveryActionDetail.DrugName = drugDefinition.Name;
                            drugDeliveryActionDetail.DrugOrderTransaction = trx;

                            foreach (DrugOrderDetail drugOrderDetail in order.DrugOrderDetails)
                            {
                                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ExPharmacySupply)
                                {
                                    drugDeliveryActionDetail.DrugOrderDetails.Add(drugOrderDetail);
                                }
                            }
                        }
                    }
                    else
                    {
                        double resVolume = DrugOrderTransaction.GetRestDose(order);
                        double resAmount = 0;
                        if (resVolume > 0)
                        {
                            resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
                            if (resAmount > 0)
                            {
                                DrugDeliveryActionDetail drugDeliveryActionDetail = _DrugDeliveryAction.DrugDeliveryActionDetails.AddNew();
                                drugDeliveryActionDetail.ResDose = resAmount;
                                drugDeliveryActionDetail.DrugName = drugDefinition.Name;
                                drugDeliveryActionDetail.DrugOrderTransaction = trx;

                                foreach (DrugOrderDetail drugOrderDetail in order.DrugOrderDetails)
                                {
                                    if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ExPharmacySupply)
                                    {
                                        drugDeliveryActionDetail.DrugOrderDetails.Add(drugOrderDetail);
                                    }
                                }
                            }
                        }
                    }
                }
            }
#endregion DrugDeliveryActionNewForm_PreScript

            }
            
#region DrugDeliveryActionNewForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null && transDef.ToStateDefID == DrugDeliveryAction.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _DrugDeliveryAction.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_DrugDeliveryReport), true, 1, parameter);
            }
        }
        
#endregion DrugDeliveryActionNewForm_Methods
    }
}