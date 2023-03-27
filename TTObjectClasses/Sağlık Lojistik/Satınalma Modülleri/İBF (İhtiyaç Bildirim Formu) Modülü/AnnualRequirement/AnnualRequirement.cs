
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
    /// İhtiyaç Bildirim Formu
    /// </summary>
    public  partial class AnnualRequirement : BasePurchaseAction, IAnnualRequirementWorkList
    {
        
                    
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            
            OwnerSite = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));

#endregion PreInsert
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
            
            List<IBFDemand> objList = new List<IBFDemand>();
            
            if(CurrentStateDefID == AnnualRequirement.States.Cancelled)
            {
                foreach(IBFDemand ibf in IBFDemands)
                    objList.Add(ibf);
                
                foreach(IBFDemand id in objList)
                    ((ITTObject)id).Delete();
            }

#endregion PostUpdate
        }

        protected void PostTransition_RegionalCommanderApprove2LDApprove()
        {
            // From State : RegionalCommanderApprove   To State : LDApprove
#region PostTransition_RegionalCommanderApprove2LDApprove
            
            
            List<TTObject> ttObjects = FillDetailsForRemote();
            //TTMessage message = AnnualRequirement.RemoteMethods.SaveIBF((Guid)Sites.SiteMerkezSagKom, ttObjects);

#endregion PostTransition_RegionalCommanderApprove2LDApprove
        }

        protected void PostTransition_AdministrativeChief2LogBrApprove()
        {
            // From State : AdministrativeChief   To State : LogBrApprove
#region PostTransition_AdministrativeChief2LogBrApprove
            
            
            List<TTObject> ttObjects = FillDetailsForRemote();
            //TTMessage message = AnnualRequirement.RemoteMethods.SaveIBF((Guid)Sites.SiteMerkezSagKom, ttObjects);

#endregion PostTransition_AdministrativeChief2LogBrApprove
        }

        protected void PostTransition_LDApprove2Completed()
        {
            // From State : LDApprove   To State : Completed
#region PostTransition_LDApprove2Completed
            
            
            foreach(AnnualRequirementDetail ard in AnnualRequirementDetails)
            {
                if(ard.CurrentStateDefID != AnnualRequirementDetail.States.Cancelled)
                    ard.CurrentStateDefID = AnnualRequirementDetail.States.Completed;
            }

            List<TTObject> ttObjects = FillDetailsForRemote();
            //TTMessage message = AnnualRequirement.RemoteMethods.SaveIBF((Guid)OwnerSite, ttObjects);

#endregion PostTransition_LDApprove2Completed
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                if (RequestNo.Value == null)
                    RequestNo.GetNextValue();
                
            }
        }
        
        
        public void ClearChildrenCollections()
        {
            //Bağlı tüm detay sınıflarının siler
            List<IBFDemand> IBFList = new List<IBFDemand>();
            foreach(IBFDemand ibf in IBFDemands)
                IBFList.Add(ibf);
            foreach(IBFDemand ibfDemand in IBFList)
                ibfDemand.AnnualRequirement = null;
            
            List<AnnualRequirementDetail> deleteList = new List<AnnualRequirementDetail>();
            foreach(AnnualRequirementDetail ardDet in AnnualRequirementDetails)
                deleteList.Add(ardDet);
            
            foreach(AnnualRequirementDetail det in deleteList)
                ((ITTObject)det).Delete();
        }
        
        public bool HaveDetails()
        {
            //İBF İşleminde detay(malzeme) olup olmadığını kontrol eder
            bool haveDetail = false;
            foreach(AnnualRequirementDetail ard in AnnualRequirementDetails)
            {
                if(ard.CurrentStateDefID == AnnualRequirementDetail.States.New)
                {
                    haveDetail = true;
                    break;
                }
            }
            
            return haveDetail;
        }
        
        public string NullAmounts()
        {
            //Miktarı yada onaylanan miktarı sıfır yada null olan malzemeleri kontrol ederek sonucu string olarak döndürür
            if(OriginalStateDef == null)
                return null;
            
            string errMsg = null;
            foreach(AnnualRequirementDetail ard in AnnualRequirementDetails)
            {
                if(ard.CurrentStateDefID != AnnualRequirementDetail.States.Cancelled)
                {
                    if(OriginalStateDef.StateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        if(CurrentStateDefID != AnnualRequirement.States.LogBrIBFRegisrty)
                        {
                            if(ard.ACC_ApproveAmount == null)
                                errMsg += "\n" + ard.PurchaseItemDef.ItemName;
                        }
                    }
                    else if(OriginalStateDef.StateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        if(CurrentStateDefID == AnnualRequirement.States.AdministrativeChief || CurrentStateDefID == AnnualRequirement.States.HeadDoctorApproval)
                        {
                            if(ard.LB_ApproveAmount == null)
                                errMsg += "\n" + ard.PurchaseItemDef.ItemName;
                        }
                    }
                    else if(OriginalStateDef.StateDefID == AnnualRequirement.States.LDApprove)
                    {
                        if(CurrentStateDefID == AnnualRequirement.States.Completed)
                        {
                            if(ard.LD_ApproveAmount == null)
                                errMsg += "\n" + ard.PurchaseItemDef.ItemName;
                        }
                    }
                }
            }
            return errMsg;
        }
        
        public bool CheckDemands(int ibfType, int ibfYear)
        {
            //Verilen İBF türü ve yılına göre İBF listeri olup olmadığını kontrol eder
            ClearChildrenCollections();
            IList<IBFDemand> list;
            list = IBFDemand.GetIBFDemandsByTypeAndYear((TTObjectContext)ObjectContext, ibfType, ibfYear);
            if(list.Count > 0)
                return true;
            else
                return false;
        }
        
        public void FillDemands(int ibfType, int ibfYear)
        {
            //Verilen İBF türü ve yılındaki İBF listesine gire İBF detaylarını doldurur
            ClearChildrenCollections();
            
            IList<IBFDemand> list;
            list = IBFDemand.GetIBFDemandsByTypeAndYear((TTObjectContext)ObjectContext, ibfType, ibfYear);
            
            ArrayList ItemInList = new ArrayList();
            ArrayList ItemOutList = new ArrayList();
            
            switch(ibfType)
            {
                case 0: //piyasa ilaç
                    foreach(IBFDemand demand in list)
                    {
                        IBFDemands.Add(demand);
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_MarketDrugIn det = new ARD_MarketDrugIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_MarketDrugIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.ClinicStocks = det.PurchaseItemDef.GetItemStocks(((BasePurchaseAction)this).MasterResource.Store);
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_MarketDrugIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_MarketDrugOut det = new ARD_MarketDrugOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_MarketDrugOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.ClinicStocks = det.PurchaseItemDef.GetItemStocks(((BasePurchaseAction)this).MasterResource.Store);
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_MarketDrugOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                case 1: //XXXXXX ilaç
                    foreach(IBFDemand demand in list)
                    {
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_MilitaryDrugIn det = new ARD_MilitaryDrugIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_MilitaryDrugIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_MilitaryDrugIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_MilitaryDrugOut det = new ARD_MilitaryDrugOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_MilitaryDrugOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_MilitaryDrugOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                case 2: //XXXXXX ilaç
                    foreach(IBFDemand demand in list)
                    {
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_XXXXXXDrugIn det = new ARD_XXXXXXDrugIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_XXXXXXDrugIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_XXXXXXDrugIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_XXXXXXDrugOut det = new ARD_XXXXXXDrugOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_XXXXXXDrugOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_XXXXXXDrugOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                case 3: //tıbbi sarf
                    foreach(IBFDemand demand in list)
                    {
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_MedicalConsIn det = new ARD_MedicalConsIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_MedicalConsIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_MedicalConsIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_MedicalConsOut det = new ARD_MedicalConsOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_MedicalConsOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_MedicalConsOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                case 4: //tıbbi cihaz
                    foreach(IBFDemand demand in list)
                    {
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_MedicalEquipmentIn det = new ARD_MedicalEquipmentIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_MedicalEquipmentIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_MedicalEquipmentIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_MedicalEquipmentOut det = new ARD_MedicalEquipmentOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_MedicalEquipmentOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_MedicalEquipmentOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                case 5: //yedek parça
                    foreach(IBFDemand demand in list)
                    {
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_SparePartIn det = new ARD_SparePartIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_SparePartIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_SparePartIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_SparePartOut det = new ARD_SparePartOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_SparePartOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_SparePartOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                case 6: //serum
                    foreach(IBFDemand demand in list)
                    {
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_SerumIn det = new ARD_SerumIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_SerumIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_SerumIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_SerumOut det = new ARD_SerumOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_SerumOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_SerumOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                case 7: //kit
                    foreach(IBFDemand demand in list)
                    {
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_KitIn det = new ARD_KitIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_KitIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_KitIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_KitOut det = new ARD_KitOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_KitOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_KitOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                case 8: //basılı evrak
                    foreach(IBFDemand demand in list)
                    {
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_PrintedDocumentIn det = new ARD_PrintedDocumentIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_PrintedDocumentIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_PrintedDocumentIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_PrintedDocumentOut det = new ARD_PrintedDocumentOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_PrintedDocumentOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_PrintedDocumentOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                case 9: //aşı
                    foreach(IBFDemand demand in list)
                    {
                        foreach(IBFBaseDemandDetail demandDet in demand.IBFBaseDemandDetails)
                        {
                            ARDDetDetail detDetail = new ARDDetDetail(ObjectContext);
                            detDetail.MasterResource = ((BasePurchaseAction)demand).MasterResource;
                            detDetail.Amount = demandDet.Amount;
                            
                            if(demandDet is IBFDetDetailIn)
                            {
                                if(ItemInList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_VaccineIn det = new ARD_VaccineIn(ObjectContext);
                                    det.CurrentStateDefID = ARD_VaccineIn.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemInList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_VaccineIns.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                            else
                            {
                                if(ItemOutList.Contains(demandDet.PurchaseItemDef.ObjectID))
                                {
                                    foreach(AnnualRequirementDetail arDet in AnnualRequirementDetails)
                                    {
                                        if(arDet.PurchaseItemDef.ObjectID == demandDet.PurchaseItemDef.ObjectID)
                                        {
                                            arDet.RequestAmount += demandDet.Amount;
                                            arDet.ARDDetDetails.Add(detDetail);
                                        }
                                    }
                                }
                                else
                                {
                                    ARD_VaccineOut det = new ARD_VaccineOut(ObjectContext);
                                    det.CurrentStateDefID = ARD_VaccineOut.States.New;
                                    det.PurchaseItemDef = demandDet.PurchaseItemDef;
                                    det.NSN = demandDet.NSN;
                                    ItemOutList.Add(det.PurchaseItemDef.ObjectID);
                                    det.RequestAmount = demandDet.Amount;
                                    ARD_VaccineOuts.Add(det);
                                    det.ARDDetDetails.Add(detDetail);
                                }
                            }
                        }
                    }
                    break;
                    
                default:
                    break;
            }
        }
        
        public List<TTObject> FillDetailsForRemote() //Remote bağlantı için gönderilecek IBF detaylarını hazırlar
        {
            List<TTObject> list = new List<TTObject>();
            TTObjectContext trashContext = new TTObjectContext(false);
            AnnualRequirement packageAnnual = (AnnualRequirement)trashContext.GetObject(ObjectID, typeof(AnnualRequirement).Name);
            packageAnnual.MasterResource = null;
            list.Add(packageAnnual);
            trashContext.Dispose();
            foreach(AnnualRequirementDetail ard in AnnualRequirementDetails)
            {
                if(ard.CurrentStateDefID != AnnualRequirementDetail.States.Cancelled)
                    list.Add(ard);
            }
            return list;
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AnnualRequirement).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AnnualRequirement.States.RegionalCommanderApprove && toState == AnnualRequirement.States.LDApprove)
                PostTransition_RegionalCommanderApprove2LDApprove();
            else if (fromState == AnnualRequirement.States.AdministrativeChief && toState == AnnualRequirement.States.LogBrApprove)
                PostTransition_AdministrativeChief2LogBrApprove();
            else if (fromState == AnnualRequirement.States.LDApprove && toState == AnnualRequirement.States.Completed)
                PostTransition_LDApprove2Completed();
        }

    }
}