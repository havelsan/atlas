
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
    /// Firmaya verilen sipariş bilgilerinin tutuldufu sınıftır
    /// </summary>
    public  partial class PurchaseOrder : BasePurchaseAction, IPurchaseOrderWorkList
    {
        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            


#endregion PostUpdate
        }

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
#region PreTransition_New2Approval
            
            
            if(WarningMsg != null)
            {
                   throw new TTUtils.TTException(SystemMessage.GetMessage(55) + WarningMsg.ToString());
            }

#endregion PreTransition_New2Approval
        }

#region Methods
        public bool CheckCompletability()
        {
            //Bir sipariş işleminin kapatılabilir durumda olup olmadığını kontrol eder
            bool retValue = true;
            foreach(PurchaseOrderDetail pod in PurchaseOrderDetails)
            {
                if (retValue == false)
                    break;
                if (pod.Status == OrderDetailStatusEnum.IhtarnameTebligiYapildi || pod.Status == OrderDetailStatusEnum.IhtarnameYazilacak
                    || pod.Status == OrderDetailStatusEnum.IhtarnemeYazildi || pod.Status == OrderDetailStatusEnum.IlkTeslimBekleniyor
                    || pod.Status == OrderDetailStatusEnum.KurusluKesilecek || pod.Status == OrderDetailStatusEnum.MuayeneAsamasinda
                    || pod.Status == OrderDetailStatusEnum.RedTebligiYapilacak || pod.Status == OrderDetailStatusEnum.RedTebligiYapildi
                    || pod.Status == OrderDetailStatusEnum.RedTebligiYazildi)
                    retValue = false;
            }

            return retValue;
        }
        
        public void AddDetailFromContractDetail(ContractDetail contractDetail, TTObjectContext objContext)
        {
            //Siparişe bağlı sözleşmede malzeme detaylarını aktarır
            if(Supplier == null)
                Supplier = contractDetail.Contract.Supplier;
            
            if(contractDetail.Contract.Supplier.ObjectID != Supplier.ObjectID)
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(56));
            }
            
            //Bu kalem zaten eklenmişse tekrar eklemeyoruz
            foreach(PurchaseOrderDetail det in PurchaseOrderDetails)
            {
                if(det.PurchaseItemDef == contractDetail.PurchaseItemDef)
                    return;
            }
            
            double oldOrders = 0;
            PurchaseOrderDetail pod = new PurchaseOrderDetail(objContext);
            pod.PurchaseItemDef = contractDetail.PurchaseItemDef;
            pod.CurrentStateDefID = PurchaseOrderDetail.States.New;
            
            //Calculate old orders
            foreach (PurchaseOrderDetail pod2 in contractDetail.PurchaseOrderDetails)
            {
                if(pod2.ObjectID != pod.ObjectID && pod2.CurrentStateDefID != PurchaseOrderDetail.States.Cancelled && pod2.PurchaseOrder.CurrentStateDefID != PurchaseOrder.States.Cancelled)
                    oldOrders += (double)pod2.Amount;
            }
            pod.RestAmount = contractDetail.Amount - oldOrders;
            pod.PurchaseProjectDetail = contractDetail.PurchaseProjectDetail;
            pod.ContractDetail = contractDetail;
            pod.PurchaseOrder = this;
            Contract = contractDetail.Contract;
        }
        
        public void FillTmpContractsGrid(int projectNo, string confirmNo, Supplier supplier)
        {
            //Sözleşmedeki malzeme detaylarını, formda göstermek amacıyla geçiçi sınıfa atar
            IList list;
            if(projectNo > 0)
                list = PurchaseProject.GetPurchaseProjectByProjectNo(ObjectContext, projectNo);
            else
                list = PurchaseProject.GetPurchaseProjectByConfirmNo(ObjectContext, confirmNo);
            
            if (list.Count == 0)
            {
                
            }
            
            PurchaseProject myProject = (PurchaseProject)list[0];
            
            if(myProject.PurchaseTypeMatPro != PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
                return;
            
            switch (list.Count)
            {
                case 1:
                    if(myProject.CurrentStateDefID == PurchaseProject.States.Completed)
                    {
                        PurchaseProject = myProject;
                        
                        foreach(Contract c in PurchaseProject.Contracts)
                        {
                            if(supplier == null ||c.Supplier.ObjectID == supplier.ObjectID)
                            {
                                if (c.CurrentStateDefID != Contract.States.Cancelled)
                                    TmpContracts.Add(c);
                            }
                        }
                    }
                    break;
                    
                case 0:
                    throw new TTUtils.TTException (SystemMessage.GetMessage(57));
                    //break;
                    
                default:
                    throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                    //break;
            }
        }
        
        public void SetFooterValues()
        {
            //Seçilen sipariş kalemlerine göre formun altındaki toplam değerlerini hesaplar
            double orderedPrice = 0;
            double remainingOrderPrice = 0;
            
            foreach(PurchaseOrderDetail pod in PurchaseOrderDetails)
            {
                orderedPrice += ((double)pod.ContractDetail.Amount - (double)pod.RestAmount) * (double)pod.ContractDetail.UnitPrice;
                if(pod.Amount != null)
                {
                    orderedPrice += (double)pod.Amount * (double)pod.ContractDetail.UnitPrice;
                }
            }
            remainingOrderPrice = (double)Contract.TotalContractValue - orderedPrice;
            
            //Aktif durumda başka açık sipariş varsa uyarıp, rakamları güncelleyelim
            //            IList activeOrders = GetCurrentOrdersByFirm(this.ObjectContext, this.Contract.Supplier.ObjectID.ToString());
            //            if (activeOrders.Count > 0)
            //            {
            //                foreach(PurchaseOrder po in activeOrders)
            //                {
            //                    foreach(PurchaseOrderDetail pod2 in po.PurchaseOrderDetails)
            //                    {
            //                        orderedPrice += (double)pod2.Amount * (double)pod2.ContractDetail.UnitPrice;
            //                    }
//
            //                }
            //            }
            
            OrderedPrice = orderedPrice;
            RemainingOrderPrice = remainingOrderPrice;
            
            if (ExceededOrderPrice())
            {
                WarningMsg = TTUtils.CultureService.GetText("M26891", "Sipariş Limiti Aşıldı");
            }
            else
            {
                WarningMsg = null;
            }
        }
        
        public void SetOrderPrices(PurchaseOrderDetail pod)
        {
            //Sipariş fiyatlarını günceller
            pod.OrderPrice = (double)pod.Amount * (double)pod.ContractDetail.UnitPrice;
        }
        
        public bool ExceededOrderPrice()
        {
            //Kullanılabilir alım fiyatının aşılıp aşılmadığını kontrol eder 
            if((Contract.TotalContractValue * 0.2) < (RemainingOrderPrice * -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public string CheckActiveExaminations()
        {
            //Siparişin muayene aşamasındaki kalemlerinin ilgili muayene durumlarını bulur
            string errMsg = null;
            IList exList = null;
            
            if(TransDef.ToStateDefID == null)
                return null;
            
            if(TransDef.ToStateDefID == PurchaseOrder.States.Cancelled)
            {
                foreach(PurchaseOrderDetail pod in PurchaseOrderDetails)
                {
                    if(pod.CurrentStateDefID != PurchaseOrderDetail.States.Cancelled)
                    {
                        exList = PurchaseExaminationDetail.GetExaminationDetailsByOrderDetail(ObjectContext, pod.ObjectID.ToString());
                        if(exList.Count > 0)
                        {
                            foreach(PurchaseExaminationDetail ped in exList)
                            {
                                if(ped.PurchaseExamination.CurrentStateDefID != PurchaseExamination.States.Cancelled)
                                {
                                    errMsg += "\n" + pod.PurchaseItemDef.ItemName + " - " + ped.StockAction.StockActionID.ToString() + " nolu muayene işlemi";
                                }
                            }
                        }
                    }
                }
            }
            return errMsg;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PurchaseOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PurchaseOrder.States.New && toState == PurchaseOrder.States.Approval)
                PreTransition_New2Approval();
        }

    }
}