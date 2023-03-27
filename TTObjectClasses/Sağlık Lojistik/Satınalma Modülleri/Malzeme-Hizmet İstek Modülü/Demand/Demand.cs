
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
    /// Malzeme/Hizmet İstek modülü için ana sınıftır
    /// </summary>
    public  partial class Demand : BasePurchaseAction, IDemandWorkList
    {
        public partial class SatınalmaIstek_DemandQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetPurchaseDecisionReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetAccountancyDemandEvaluationReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetDemandTechCommissionQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
#endregion PostUpdate
        }

        protected void PostTransition_AccountancyApproval2LogisticDepartmentApproval()
        {
            // From State : AccountancyApproval   To State : LogisticDepartmentApproval
#region PostTransition_AccountancyApproval2LogisticDepartmentApproval
            
            
            PassedFromAccountancy = true;

            ArrayList transferStores = new ArrayList();
            foreach (TransferForDemand tf in TransferForDemands)
            {
                if (tf.CurrentStateDefID != TransferForDemand.States.Cancelled && transferStores.Contains(tf.Store) == false)
                    transferStores.Add(tf.Store);
            }

            if (transferStores.Count > 0)
            {
                BindingList<MainStoreDefinition> mainStores = MainStoreDefinition.GetAllMainStores(ObjectContext);
                MainStoreDefinition mainStore = null;
                if (mainStores.Count == 1)
                    mainStore = mainStores[0];
                else if (mainStores.Count > 1)
                {
                    foreach (MainStoreDefinition ms in mainStores)
                    {
                        IList list = Stock.GetStockForStockCard(ObjectContext, ms.ObjectID.ToString());
                        if (list.Count > 0)
                        {
                            mainStore = ms;
                            break;
                        }
                    }
                }

                if (mainStore != null)
                {
                    foreach (Store s in transferStores)
                    {
                        //İADE
                        if (s is MainStoreDefinition == false)
                        {
                            ReturningDocument rd = new ReturningDocument(ObjectContext);
                            rd.CurrentStateDefID = ReturningDocument.States.New;
                            rd.Store = s;
                            rd.DestinationStore = mainStore;
                            rd.Description = RequestNo.Value.ToString() + " No.lu malzeme istek işlemine istinaden otomatik olarak başlatılan dağıtım belgesidir.";

                            foreach (TransferForDemand tf in TransferForDemands)
                            {
                                if (tf.Store == s)
                                {
                                    ReturningDocumentMaterial rdm = new ReturningDocumentMaterial(ObjectContext);
                                    rdm.StockAction = (StockAction)rd;
                                    rdm.RequireAmount = tf.Amount;
                                    rdm.Material = tf.Material;
                                    rdm.StockLevelType = StockLevelType.NewStockLevel;
                                    tf.CurrentStateDefID = TransferForDemand.States.Completed;
                                }
                            }
                        }
                    }

                    //DAĞITIM

                    Dictionary<Guid, double> matList = new Dictionary<Guid, double>();

                    DistributionDocument dd = new DistributionDocument(ObjectContext);
                    dd.CurrentStateDefID = DistributionDocument.States.New;
                    dd.Store = mainStore;
                    dd.DestinationStore = MasterResource.Store;
                    dd.Description = RequestNo.Value.ToString() + " No.lu malzeme istek işlemine istinaden otomatik olarak başlatılan dağıtım belgesidir.";

                    foreach (TransferForDemand tf in TransferForDemands)
                    {
                        if (matList.ContainsKey(tf.Material.ObjectID) == false)
                            matList.Add(tf.Material.ObjectID, (double)tf.Amount);
                        else
                            matList[tf.Material.ObjectID] += (double)tf.Amount;
                        tf.CurrentStateDefID = TransferForDemand.States.Completed;
                    }

                    foreach (KeyValuePair<Guid, double> kv in matList)
                    {
                        DistributionDocumentMaterial ddm = new DistributionDocumentMaterial(ObjectContext);
                        ddm.StockAction = (StockAction)dd;
                        ddm.AcceptedAmount = kv.Value;
                        ddm.Material = (Material)ObjectContext.GetObject(kv.Key, "MATERIAL");
                        ddm.StockLevelType = StockLevelType.NewStockLevel;
                    }
                }
            }

#endregion PostTransition_AccountancyApproval2LogisticDepartmentApproval
        }

        protected void PostTransition_Approval2Rejected()
        {
            // From State : Approval   To State : Rejected
#region PostTransition_Approval2Rejected
            
            SendRejectMessage(RequestNo.ToString() + " no.lu satınalma isteğiniz birim amirince reddedilmiştir");

#endregion PostTransition_Approval2Rejected
        }

#region Methods
        public override string ToString()
        {
            return   TTUtils.CultureService.GetText("M26147", "İstek No:")+ RequestNo.Value.ToString() + " - İstek Tarihi: " + DemandDate.Value.ToString() + " - Step: " + CurrentStateDef.ToString();
        }
        
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
                RequestNo.GetNextValue();
        }
        
        public void SendRejectMessage(string messageBody)
        {
            //İstek sahibi kullanıcıya isteğinin red edildiğine dair sistem mesajı yollar
            ResUser user = null;
            foreach(TTObjectState objectState in GetStateHistory())
            {
                if(objectState.StateDefID == Demand.States.New)
                {
                    user = (ResUser)objectState.User.UserObject;
                    break;
                }
            }
            
            if (user != null)
            {
                UserMessage message = new UserMessage(ObjectContext);
                message.IsSystemMessage = true;
                message.MessageDate = DateTime.Now;
                message.Subject = TTUtils.CultureService.GetText("M26146", "İstek İptali");
            //    message.Status = MessageStatusEnum.Sent;
                message.ToUser = user;
                message.Sender = user;
                message.SetRTFBody(messageBody);
            }
        }
        
        public void CheckNullAmounts()
        {
            //Boş yada sıfır olarak onaylanan miktarları komtrol eder
            if (TransDef != null)
            {
                if (TransDef.FromStateDefID == Demand.States.New && TransDef.ToStateDefID == TTObjectClasses.Demand.States.Approval)
                {
                    foreach(DemandDetail dd in DemandDetails)
                    {
                        if (dd.RequestAmount == null)
                            throw new TTException(SystemMessage.GetMessage(48) + dd.PurchaseItemDef.ItemName);
                    }
                }
                
                else if (TransDef.FromStateDefID == Demand.States.Approval && TransDef.ToStateDefID == TTObjectClasses.Demand.States.AccountancyApproval)
                {
                    foreach(DemandDetail dd in DemandDetails)
                    {
                        if (dd.ClinicApprovedAmount == null)
                            throw new TTException(SystemMessage.GetMessage(48) + dd.PurchaseItemDef.ItemName);
                    }
                }
                
                else if (TransDef.FromStateDefID == Demand.States.AccountancyApproval && TransDef.ToStateDefID == TTObjectClasses.Demand.States.Completed)
                {
                    foreach(DemandDetail dd in DemandDetails)
                    {
                        if (dd.Amount == null)
                            throw new TTException(SystemMessage.GetMessage(48) + dd.PurchaseItemDef.ItemName);
                    }
                }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Demand).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Demand.States.AccountancyApproval && toState == Demand.States.LogisticDepartmentApproval)
                PostTransition_AccountancyApproval2LogisticDepartmentApproval();
            else if (fromState == Demand.States.Approval && toState == Demand.States.Rejected)
                PostTransition_Approval2Rejected();
        }

    }
}