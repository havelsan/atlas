
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
    /// Lojistik İkmal Faliyetleri modülü temel sınıfıdır
    /// </summary>
    public  partial class LBPurchaseProject : BasePurchaseAction, ILBPurchaseProjectWorkList
    {
#region Methods
        public static int ibfTypeValue = 1000;
        
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
                PurchaseProjectNo.GetNextValue();
        }
        
        public void ClearInChildrenCollections()
        {
            //İşlemdeki tüm detay satırlarını siler
            List<AnnualRequirementDetailInList> ARDInList = new List<AnnualRequirementDetailInList>();
            foreach(LBPurchaseProjectDetailInList lbpIn in LBPurchaseProjectDetailInLists)
            {
                foreach(AnnualRequirementDetailInList arIn in lbpIn.AnnualRequirementDetailInLists)
                    ARDInList.Add(arIn);
            }
            foreach (AnnualRequirementDetailInList arIn in ARDInList)
            {
                arIn.LBPurchaseProjectDetailInList = null;
            }

            List<LBPurchaseProjectDetailInList> deleteInList = new List<LBPurchaseProjectDetailInList>();
            foreach(LBPurchaseProjectDetailInList lbpIn in LBPurchaseProjectDetailInLists)
                deleteInList.Add(lbpIn);

            foreach(LBPurchaseProjectDetailInList det in deleteInList)
                ((ITTObject)det).Delete();
        }
        
        public void ClearOutChildrenCollections()
        {
            //İşlemdeki İBF listesi dahilindeki tüm detay satırlarını siler
            List<AnnualRequirementDetailOutOfList> ARDOutOfList = new List<AnnualRequirementDetailOutOfList>();
            foreach(LBPurchaseProjectDetailOutOfList lbpOut in LBPurchaseProjectDetailOutOfLists)
            {
                foreach(AnnualRequirementDetailOutOfList arOut in lbpOut.AnnualRequirementDetailOutOfLists)
                    ARDOutOfList.Add(arOut);
            }
            foreach (AnnualRequirementDetailOutOfList arOut in ARDOutOfList)
            {
                arOut.LBPurchaseProjectDetOutOfList = null;
            }
            
            List<LBPurchaseProjectDetailOutOfList> deleteOutList = new List<LBPurchaseProjectDetailOutOfList>();
            foreach(LBPurchaseProjectDetailOutOfList lbpOut in LBPurchaseProjectDetailOutOfLists)
                deleteOutList.Add(lbpOut);

            foreach(LBPurchaseProjectDetailOutOfList det in deleteOutList)
                ((ITTObject)det).Delete();
        }
        
        public void GetAvailableIBFs(bool InIBFList, byte ibfType, int ibfYear)
        {
            //Lojistik daire ikmal faaliyetlerine çıkabilecek durumdaki İBF isteklerini bulur
            bool found = false;
            int orderNo = 0;
            
            ArrayList ItemInList = new ArrayList();
            ArrayList ItemOutList = new ArrayList();
            
            switch(ibfType)
            {
                case 0://piyasa ilaç
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_MarketDrugIn lbin = new LBD_MarketDrugIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_MarketDrugIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_MarketDrugIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_MarketDrugOut lbout = new LBD_MarketDrugOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_MarketDrugOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_MarketDrugOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                    case 1://XXXXXX ilaç
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_MilitaryDrugIn lbin = new LBD_MilitaryDrugIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_MilitaryDrugIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_MilitaryDrugIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_MilitaryDrugOut lbout = new LBD_MilitaryDrugOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_MilitaryDrugOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_MilitaryDrugOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                    case 2://XXXXXX ilaç
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_XXXXXXDrugIn lbin = new LBD_XXXXXXDrugIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_XXXXXXDrugIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_XXXXXXDrugIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_XXXXXXDrugOut lbout = new LBD_XXXXXXDrugOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_XXXXXXDrugOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_XXXXXXDrugOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                    case 3://tıbbi sarf
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_MedicalConsIn lbin = new LBD_MedicalConsIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_MedicalConsIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_MedicalConsIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_MedicalConsOut lbout = new LBD_MedicalConsOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_MedicalConsOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_MedicalConsOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                    case 4://tıbbi cihaz
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_MedicalEquipmentIn lbin = new LBD_MedicalEquipmentIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_MedicalEquipmentIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_MedicalEquipmentIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_MedicalEquipmentOut lbout = new LBD_MedicalEquipmentOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_MedicalEquipmentOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_MedicalEquipmentOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                    case 5://yedek parça
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_SpareIn lbin = new LBD_SpareIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_SpareIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_SpareIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_SpareOut lbout = new LBD_SpareOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_SpareOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_SpareOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                    case 6://serum
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_SerumIn lbin = new LBD_SerumIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_SerumIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_SerumIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_SerumOut lbout = new LBD_SerumOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_SerumOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_SerumOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                    case 7://kit
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_KitIn lbin = new LBD_KitIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_KitIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_KitIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_KitOut lbout = new LBD_KitOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_KitOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_KitOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                    case 8://basılı evrak
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_PrintedDocumentIn lbin = new LBD_PrintedDocumentIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_PrintedDocumentIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_PrintedDocumentIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_PrintedDocumentOut lbout = new LBD_PrintedDocumentOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_PrintedDocumentOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_PrintedDocumentOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                    case 9://aşı
                    if(InIBFList)
                    {
                        ClearInChildrenCollections();
                        
                        IList inDetails = AnnualRequirementDetailInList.GetAvailableInListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailInList annDetIn in inDetails)
                        {
                            if(ItemInList.Contains(annDetIn.PurchaseItemDef.ObjectID))
                            {
                                foreach(LBPurchaseProjectDetailInList lbin in LBPurchaseProjectDetailInLists)
                                {
                                    if(lbin.PurchaseItemDef.ObjectID == annDetIn.PurchaseItemDef.ObjectID)
                                    {
                                        lbin.RequestedAmount += annDetIn.RequestAmount;
                                        annDetIn.LBPurchaseProjectDetailInList = lbin;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                orderNo++;
                                LBD_VaccineIn lbin = new LBD_VaccineIn(ObjectContext);
                                lbin.CurrentStateDefID = LBD_VaccineIn.States.New;
                                annDetIn.LBPurchaseProjectDetailInList = lbin;
                                lbin.NSN = annDetIn.NSN;
                                lbin.PurchaseItemDef = annDetIn.PurchaseItemDef;
                                ItemInList.Add(annDetIn.PurchaseItemDef.ObjectID);
                                lbin.RequestedAmount = annDetIn.RequestAmount;
                                lbin.OrderNO = orderNo;
                                LBD_VaccineIns.Add(lbin);
                            }
                        }
                    }
                    else
                    {
                        ClearOutChildrenCollections();
                        
                        IList outDetails = AnnualRequirementDetailOutOfList.GetAvailableOutOfListDets((TTObjectContext)ObjectContext, ibfType, ibfYear);
                        foreach (AnnualRequirementDetailOutOfList annDetOut in outDetails)
                        {
                            if(ItemOutList.Contains(annDetOut.PurchaseItemDef.ObjectID))
                            {
                                
                                foreach(LBPurchaseProjectDetailOutOfList lbout in LBPurchaseProjectDetailOutOfLists)
                                {
                                    if(lbout.PurchaseItemDef.ObjectID == annDetOut.PurchaseItemDef.ObjectID)
                                    {
                                        lbout.RequestedAmount += annDetOut.RequestAmount;
                                        annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                        break;
                                    }
                                }
                            }
                            
                            else
                            {
                                orderNo++;
                                LBD_VaccineOut lbout = new LBD_VaccineOut(ObjectContext);
                                lbout.CurrentStateDefID = LBD_VaccineOut.States.New;
                                annDetOut.LBPurchaseProjectDetOutOfList = lbout;
                                lbout.NSN = annDetOut.NSN;
                                lbout.PurchaseItemDef = annDetOut.PurchaseItemDef;
                                ItemOutList.Add(annDetOut.PurchaseItemDef.ObjectID);
                                lbout.RequestedAmount = annDetOut.RequestAmount;
                                lbout.OrderNO = orderNo;
                                LBD_VaccineOuts.Add(lbout);
                            }
                        }
                    }
                    break;
                    
                default:
                    break;
            }
        }

            
            public void TransferItem(LBPurchaseProjectDetail lbPurchaseProjectDetail, IBFTypeEnum ibfType)
            {
                //İBF listesi dahilindeki bir malzemeyi liste dışına yada liste dışındaki bir malzemeyi İBF listesine taşır
                if(lbPurchaseProjectDetail == null)
                    return;
                
                switch(ibfType)
                {
                    case IBFTypeEnum.Asi:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_VaccineIn.States.Cancelled;
                            LBD_VaccineOut newP = new LBD_VaccineOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_VaccineOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_VaccineOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_VaccineOut.States.Cancelled;
                            LBD_VaccineIn newP = new LBD_VaccineIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_VaccineIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_VaccineIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    case IBFTypeEnum.BasiliEvrak:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_PrintedDocumentIn.States.Cancelled;
                            LBD_PrintedDocumentOut newP = new LBD_PrintedDocumentOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_PrintedDocumentOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_PrintedDocumentOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_PrintedDocumentOut.States.Cancelled;
                            LBD_PrintedDocumentIn newP = new LBD_PrintedDocumentIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_PrintedDocumentIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_PrintedDocumentIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    case IBFTypeEnum.XXXXXXIlac:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_XXXXXXDrugIn.States.Cancelled;
                            LBD_XXXXXXDrugOut newP = new LBD_XXXXXXDrugOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_XXXXXXDrugOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_XXXXXXDrugOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_XXXXXXDrugOut.States.Cancelled;
                            LBD_XXXXXXDrugIn newP = new LBD_XXXXXXDrugIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_XXXXXXDrugIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_XXXXXXDrugIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    case IBFTypeEnum.Kit:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_KitIn.States.Cancelled;
                            LBD_KitOut newP = new LBD_KitOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_KitOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_KitOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_KitOut.States.Cancelled;
                            LBD_KitIn newP = new LBD_KitIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_KitIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_KitIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    case IBFTypeEnum.OrduIlac:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_MilitaryDrugIn.States.Cancelled;
                            LBD_MilitaryDrugOut newP = new LBD_MilitaryDrugOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_MilitaryDrugOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_MilitaryDrugOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_MilitaryDrugOut.States.Cancelled;
                            LBD_MilitaryDrugIn newP = new LBD_MilitaryDrugIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_MilitaryDrugIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_MilitaryDrugIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    case IBFTypeEnum.PiyasaIlac:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_MarketDrugIn.States.Cancelled;
                            LBD_MarketDrugOut newP = new LBD_MarketDrugOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_MarketDrugOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_MarketDrugOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_MarketDrugOut.States.Cancelled;
                            LBD_MarketDrugIn newP = new LBD_MarketDrugIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_MarketDrugIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_MarketDrugIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    case IBFTypeEnum.Serum:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_SerumIn.States.Cancelled;
                            LBD_SerumOut newP = new LBD_SerumOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_SerumOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_SerumOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_SerumOut.States.Cancelled;
                            LBD_SerumIn newP = new LBD_SerumIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_SerumIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_SerumIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    case IBFTypeEnum.TibbiCihaz:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_MedicalEquipmentIn.States.Cancelled;
                            LBD_MedicalEquipmentOut newP = new LBD_MedicalEquipmentOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_MedicalEquipmentOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_MedicalEquipmentOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_MedicalEquipmentOut.States.Cancelled;
                            LBD_MedicalEquipmentIn newP = new LBD_MedicalEquipmentIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_MedicalEquipmentIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_MedicalEquipmentIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    case IBFTypeEnum.TibbiSarf:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_MedicalConsIn.States.Cancelled;
                            LBD_MedicalConsOut newP = new LBD_MedicalConsOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_MedicalConsOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_MedicalConsOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_MedicalConsOut.States.Cancelled;
                            LBD_MedicalConsIn newP = new LBD_MedicalConsIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_MedicalConsIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_MedicalConsIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    case IBFTypeEnum.YedekParca:
                        if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_SpareIn.States.Cancelled;
                            LBD_SpareOut newP = new LBD_SpareOut(ObjectContext);
                            newP.CurrentStateDefID = LBD_SpareOut.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_SpareOuts.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                        {
                            lbPurchaseProjectDetail.CurrentStateDefID = LBD_SpareOut.States.Cancelled;
                            LBD_SpareIn newP = new LBD_SpareIn(ObjectContext);
                            newP.CurrentStateDefID = LBD_SpareIn.States.New;
                            newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                            newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                            newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                            newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                            newP.NSN = lbPurchaseProjectDetail.NSN;
                            LBD_SpareIns.Add(newP);
                            ((ITTObject)lbPurchaseProjectDetail).Delete();
                        }
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessage(58));
                        break;
                        
                    default:
                        break;
                }
                
                //            if(lbPurchaseProjectDetail is LBPurchaseProjectDetailInList)
                //            {
                //                lbPurchaseProjectDetail.CurrentStateDefID = LBPurchaseProjectDetailInList.States.Cancelled;
                //                LBPurchaseProjectDetailOutOfList newP = new LBPurchaseProjectDetailOutOfList(this.ObjectContext);
                //                newP.CurrentStateDefID = LBPurchaseProjectDetailOutOfList.States.New;
                //                newP.LBPurchaseProject = this;
                //                newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                //                newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                //                newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                //                newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                //                newP.NSN = lbPurchaseProjectDetail.NSN;
                //                ((ITTObject)lbPurchaseProjectDetail).Delete();
                //            }
                //            else if (lbPurchaseProjectDetail is LBPurchaseProjectDetailOutOfList)
                //            {
                //                lbPurchaseProjectDetail.CurrentStateDefID = LBPurchaseProjectDetailOutOfList.States.Cancelled;
                //                LBPurchaseProjectDetailInList newP = new LBPurchaseProjectDetailInList(this.ObjectContext);
                //                newP.CurrentStateDefID = LBPurchaseProjectDetailInList.States.New;
                //                newP.LBPurchaseProject = this;
                //                newP.ApprovedAmount = lbPurchaseProjectDetail.ApprovedAmount;
                //                newP.CancelledAmount = lbPurchaseProjectDetail.CancelledAmount;
                //                newP.PurchaseItemDef = lbPurchaseProjectDetail.PurchaseItemDef;
                //                newP.RequestedAmount = lbPurchaseProjectDetail.RequestedAmount;
                //                newP.NSN = lbPurchaseProjectDetail.NSN;
                //                ((ITTObject)lbPurchaseProjectDetail).Delete();
                //            }
                //            else
                //                throw new TTUtils.TTException("İşlemde hata oluştu");
                
                
                
                int order = 0;
                foreach(LBPurchaseProjectDetailInList inList in LBPurchaseProjectDetailInLists)
                {
                    if(inList.CurrentStateDefID != LBPurchaseProjectDetailInList.States.Cancelled)
                    {
                        order++;
                        inList.OrderNO = order;
                    }
                }
                
                order = 0;
                foreach(LBPurchaseProjectDetailOutOfList outList in LBPurchaseProjectDetailOutOfLists)
                {
                    if(outList.CurrentStateDefID != LBPurchaseProjectDetailOutOfList.States.Cancelled)
                    {
                        order++;
                        outList.OrderNO = order;
                    }
                }
            }
        
#endregion Methods

    }
}