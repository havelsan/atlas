
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
    /// Mahalli Satınalma Ana Sınıfına Bağlı Her Detayın/Kalemin Bağlı Olduğu Sınıftır
    /// </summary>
    public  partial class PurchaseProjectDetail : TTObject
    {
        public partial class GetPurchaseOrderChaseReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetProjectDetails_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();

#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();

#endregion PreUpdate
        }

#region Methods
        public void CheckRemoteAnswers()
        {
            
//            if(this.AccountancyAmounts.Count == 0)
//            {
//                List<BasePurchaseAction.AccountancyInheldInfo> accountancyInheldInfoList = this.PurchaseProject.SendAmountRequestToAllSitesForPurchaseItem(this.PurchaseItemDef);
//                foreach (BasePurchaseAction.AccountancyInheldInfo accountancyInheldInfo in accountancyInheldInfoList)
//                {
//                    PPDAccountancyAmount ppda = new PPDAccountancyAmount(this.ObjectContext);
//                    ppda.CurrentStateDefID = LBAccountancyAmount.States.Waiting;
//                    ppda.Accountancy = this.ObjectContext.GetObject(accountancyInheldInfo.AccountancyID, typeof(Accountancy)) as Accountancy;
//                    ppda.PurchaseProjectDetail = this;
//                    ppda.Amount = accountancyInheldInfo.Inheld;
//                    ppda.SurplusAmount = PurchaseItemDef.RemoteMethods.GetPurchaseItemAccountancySurplusAmounts(Sites.SiteMerkezSagKom, this.PurchaseItemDef.ObjectID, accountancyInheldInfo.AccountancyID);
//                }
//            }
        }
        
        public void CalculateApproveDetails()
        {
            
            
            double approved = 0;
            double cancelled = 0;
            foreach (LBApproveDetail lbad in LBApproveDetails)
            {
                if(lbad.Amount == null)
                    lbad.Amount = 0;
                
                if (lbad.ApproveType != LBApproveDetailTypeEnum.Internal)
                {
                    cancelled += (double)lbad.Amount;
                }
                else
                {
                    approved += (double)lbad.Amount;
                }
            }
            
            Amount = approved;
            CancelledAmount = cancelled;
        }
        
        public void CheckDetailAmounts()
        {
            if ((Amount + CancelledAmount) != RequestedAmount)
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(43));
            }
            foreach(LBApproveDetail lb in LBApproveDetails)
            {
                if(lb.ApproveType == LBApproveDetailTypeEnum.CounterBalance && lb.Accountancy == null && lb.Amount > 0)
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(44));
                }
            }
        }
        
        public void FindBestAndSecondProposalDetail()
        {
            ProposalDetail bestPd = null;
            ProposalDetail secPd = null;
            foreach (ProposalDetail pd in ProposalDetails)
            {
                if (pd.ProposalPrice != 0 && pd.ProposalPrice != null)
                {
                    if (pd.Status != ProposalDetailStatusEnum.Denied)
                    {
                        if (bestPd == null)
                        {
                            bestPd = pd;
                        }
                        else
                        {
                            if (pd.ProposalPrice < bestPd.ProposalPrice)
                            {
                                secPd = bestPd;
                                bestPd = pd;
                            }
                            else
                            {
                                if (secPd == null && pd.ProposalPrice != 0 && pd.ProposalPrice != null)
                                {
                                    secPd = pd;
                                }
                                else
                                {
                                    if (pd.ProposalPrice < secPd.ProposalPrice)
                                    {
                                        secPd = pd;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (bestPd != null)
                bestPd.Status = ProposalDetailStatusEnum.Best;
            if (secPd != null)
                secPd.Status = ProposalDetailStatusEnum.Second;
        }
        
        
        
        public void GetExternalPurchases()
        {
            List<ExternalPurchaseDefinition> existingExps = new List<ExternalPurchaseDefinition>();
            foreach(PublicPurchasesForFormulation ppf in PublicPurchasesForFormulations)
            {
                existingExps.Add(ppf.ExternalPurchaseDefinition);
            }
            
            IList externals = ExternalPurchaseDefinition.GetExternalPurchases(ObjectContext,  PurchaseItemDef.ObjectID.ToString());
            foreach(ExternalPurchaseDefinition exP in externals)
            {
                if (existingExps.Contains(exP) == false)
                {
                    PublicPurchasesForFormulation ppff = new PublicPurchasesForFormulation(ObjectContext);
                    ppff.PurchaseProjectDetail = this;
                    ppff.ExternalPurchaseDefinition = exP;
                }
                
            }
        }
           
        
        
        public void GenerateOldPurchases()
        {
            OldPurchases.ClearChildren();
            
            IList cds = ContractDetail.GetOldPurchasesForPriceFormulation(ObjectContext, PurchaseItemDef.ObjectID.ToString());
            foreach(ContractDetail cd in cds)
            {
                OldPurchase old = new OldPurchase(ObjectContext);
                old.CurrentStateDefID= OldPurchase.States.New;
                old.PurchaseProjectDetail = this;
                old.Amount = cd.Amount;
                old.PurchaseDate = cd.Contract.ContractDate;
                old.Supplier = cd.Contract.Supplier;
                old.UnitPrice = cd.UnitPrice;
                old.ProcurementUnitDef = cd.PurchaseProjectDetail.PurchaseProject.ResponsibleProcurementUnitDef;
            }
        }
        
#endregion Methods

    }
}