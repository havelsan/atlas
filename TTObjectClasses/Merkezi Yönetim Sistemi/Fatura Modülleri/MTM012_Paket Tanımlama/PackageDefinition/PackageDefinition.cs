
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
    /// Paket Tanımlama
    /// </summary>
    public  partial class PackageDefinition : TerminologyManagerDef
    {
        public partial class GetPackageDefinitions_Class : TTReportNqlObject 
        {
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObject = this as ITTObject;
            if (theObject.IsNew)
            {
                ID.GetNextValue();
            }
        }
        
        public bool IsIncluded (TTObject pObject, Int16 pElapsedDay)
        {
            if (pObject.ObjectDef.IsOfType("PROCEDUREDEFINITION") == true)
            {   ProcedureDefinition pDef =  (ProcedureDefinition) pObject;
                return IsProcedureIncluded(pDef, pElapsedDay);
            }
            else if (pObject.ObjectDef.IsOfType("MATERIAL") == true) //(pObject.ObjectDef.Name == "MATERIAL")
            {   Material mDef = (Material) pObject;
                return IsMaterialIncluded(mDef, pElapsedDay);
            }
            else
                return false;
        }
        
        
        private bool IsProcedureIncluded (ProcedureDefinition pProcedure, Int16 pElapsedDay)
        {
            if (DayLimit > 0 && DayLimit < pElapsedDay)
                return false;
            else
            {
                // once exceptionlara bakiliyor.
                // Daha sonra exceptionda amount kontrolu de yapılacak.
                foreach (PackageExceptionProcedure pexc in PackageExceptionProcedures)
                {
                    if (pProcedure == pexc.ProcedureDefinition)
                    {
                        if (pexc.Inclusive  == PackageInclusiveEnum.Included)
                            return true;
                        else if (pexc.Inclusive  == PackageInclusiveEnum.Excluded)
                            return false;
                    }
                }
                //exceptionda yoksa detaylara bakiliyor.
                PackageDetailProcedure packDetail;
                packDetail = (PackageDetailProcedure) GetPackageDetailProcedureDefinition(pProcedure);
                if (packDetail != null)
                {
                    if (packDetail.Inclusive == PackageInclusiveEnum.Included)
                        return true;
                    else if (packDetail.Inclusive == PackageInclusiveEnum.Excluded)
                        return false;
                }
                else
                    return false;
                
            }
            return true;
        }
        
        private bool IsMaterialIncluded (Material pMaterial, Int16 pElapsedDay)
        {
            if (DayLimit > 0 && DayLimit < pElapsedDay)
                return false;
            else
            {
                // once exceptionlara bakiliyor.
                // Daha sonra exceptionda amount kontrolu de yapılacak.
                foreach (PackageExceptionMaterial pexc in PackageExceptionMaterials)
                {
                    if (pMaterial == pexc.Material)
                    {
                        if (pexc.Inclusive  == PackageInclusiveEnum.Included)
                            return true;
                        else if (pexc.Inclusive  == PackageInclusiveEnum.Excluded)
                            return false;
                    }
                }
                //exceptionda yoksa detaylara bakiliyor.
                PackageDetailMaterial packDetail;
                packDetail = (PackageDetailMaterial) GetPackageDetailMaterialDefinition(pMaterial);
                if (packDetail != null)
                {
                    if (packDetail.Inclusive == PackageInclusiveEnum.Included)
                        return true;
                    else if (packDetail.Inclusive == PackageInclusiveEnum.Excluded)
                        return false;
                }
                else
                    return false;
                
            }
            return true;
        }
        
        private PackageDetailProcedure GetPackageDetailProcedureDefinition (ProcedureDefinition pProcedure)
        {
            bool notFound = true;
            IList pDetailProcedures = null;
            ProcedureTreeDefinition parentProcedureTree;

            parentProcedureTree = (ProcedureTreeDefinition) pProcedure.ProcedureTree;
            
            TTObjectContext ctxRO = new TTObjectContext(true);
            while (notFound)
            {
                pDetailProcedures = PackageDetailProcedure.GetByPackageAndProcedureTree(ctxRO, ObjectID.ToString(), parentProcedureTree.ObjectID.ToString());
                if (pDetailProcedures.Count == 0)
                {
                    parentProcedureTree = (ProcedureTreeDefinition) parentProcedureTree.ParentID;
                    if (parentProcedureTree == null)
                        break;
                }
                else
                    notFound = false;
            }
            if (notFound)
                return null;
            else
                return (PackageDetailProcedure)pDetailProcedures[0];
            
        }
        
        private PackageDetailMaterial GetPackageDetailMaterialDefinition(Material pMaterial)
        {
            bool notFound = true;
            IList pDetailMaterials = null;
            MaterialTreeDefinition parentMaterialTree;
            TTObjectContext ctxRO = new TTObjectContext(true);

            parentMaterialTree = (MaterialTreeDefinition) pMaterial.MaterialTree;
            while (notFound)
            {
                pDetailMaterials = PackageDetailMaterial.GetByPackageAndMaterialTree(ctxRO, parentMaterialTree.ObjectID.ToString(), ObjectID.ToString());
                if (pDetailMaterials.Count == 0)
                {
                    parentMaterialTree = (MaterialTreeDefinition) parentMaterialTree.ParentMaterialTree;
                    if (parentMaterialTree == null)
                        break;
                }
                else
                    notFound = false;
            }
            if (notFound)
                return null;
            else
                return (PackageDetailMaterial)pDetailMaterials[0];
        }
        
        
        public ArrayList CalculatePackagePrice(TTObject pObject, DateTime? pSubActDate, PricingListDefinition pPricingList)
        {
            if (pObject.ObjectDef.IsOfType("PROCEDUREDEFINITION") == true)
            {
                ProcedureDefinition pDef = (ProcedureDefinition) pObject;
                
                if(pSubActDate == null)
                    return CalculateProcedurePackagePrice(pDef, pPricingList);
                else
                    return CalculateProcedurePackagePrice(pDef, pSubActDate);
            }
            else if (pObject.ObjectDef.IsOfType("MATERIAL") == true)
            {
                Material mDef = (Material) pObject;
                
                if(pSubActDate == null)
                    return CalculateMaterialPackagePrice(mDef, pPricingList);
                else
                    return CalculateMaterialPackagePrice(mDef, pSubActDate);
            }
            else
                return null;
        }
        
        public ArrayList CalculatePackagePrice(TTObject pObject, PricingListDefinition pPricingList)
        {
            return CalculatePackagePrice(pObject, null, pPricingList);
        }
        
        public ArrayList CalculatePackagePrice(TTObject pObject, DateTime? pSubActDate)
        {
            return CalculatePackagePrice(pObject, pSubActDate, null);
        }
        
        
        private ArrayList CalculateProcedurePackagePrice(ProcedureDefinition pProcedure, DateTime? pSubActionDate, PricingListDefinition pPricingList)
        {
            ArrayList pricingDetailList = new ArrayList();
            ArrayList manipulatedPDList = new ArrayList();
            PackageDetailProcedure packDetail;
            TTObjectContext context = new TTObjectContext(false);
            
            foreach (PackageExceptionProcedure pExc in PackageExceptionProcedures)
            {
                if (pExc.ProcedureDefinition == pProcedure)
                {
                    if(pSubActionDate == null)
                        pricingDetailList = pProcedure.GetProcedurePricingDetail(pPricingList);
                    else
                        pricingDetailList = pProcedure.GetProcedurePricingDetail(pExc.PricingListDefinition, pSubActionDate);
                    
                    foreach (PricingDetailDefinition pp in pricingDetailList)
                    {
                        //ManipulatedPrice mypd = new ManipulatedPrice(ObjectContext);
                        ManipulatedPrice mypd = new ManipulatedPrice(context);
                        mypd.ExternalCode = pp.ExternalCode;
                        mypd.Description = pp.Description;
                        mypd.Price = pp.Price;
                        mypd.PricingDetailDefinition = pp;
                        manipulatedPDList.Add(mypd);
                    }
                    return manipulatedPDList;
                }
            }
            
            packDetail = (PackageDetailProcedure)GetPackageDetailProcedureDefinition(pProcedure);
            if (packDetail != null)
            {
                double multiplier = 0; // Fiyat Listesi çarpanı
                
                if(pSubActionDate == null)
                    pricingDetailList = pProcedure.GetProcedurePricingDetail(pPricingList);
                else
                {
                    // Fiyat Listesinden fiyat kontrolü
                    pricingDetailList = pProcedure.GetProcedurePricingDetail(packDetail.PricingListDefinition, pSubActionDate);
                    if(pricingDetailList.Count > 0)
                    {
                        if(packDetail.PricingListMultiplier != null)
                            multiplier = (double)packDetail.PricingListMultiplier.Multiplier;
                    }
                    else // Alternatif Fiyat Listesinden fiyat kontrolü
                    {
                        if(packDetail.SecondPricingList != null)
                        {
                            pricingDetailList = pProcedure.GetProcedurePricingDetail(packDetail.SecondPricingList, pSubActionDate);
                            if(pricingDetailList.Count > 0)
                            {
                                if(packDetail.SecondPricingListMultiplier != null)
                                    multiplier = (double)packDetail.SecondPricingListMultiplier.Multiplier;
                            }
                        }
                    }
                }
                foreach (PricingDetailDefinition pp in pricingDetailList)
                {
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = pp.ExternalCode;
                    mypd.Description = pp.Description;
                    mypd.Price = pp.Price;
                    
                    if(multiplier > 0)  // Fiyat Listesi çarpanı varsa fiyat çarpılır
                        mypd.Price = Math.Round((double)(mypd.Price * multiplier),8);
                    
                    mypd.PricingDetailDefinition = pp;
                    manipulatedPDList.Add(mypd);
                }
                return manipulatedPDList;
            }
            // anlasma taniminda olmayan bir hizmet grubundan hizmet girildigi zaman
            // %100 hastaya ve XXXXXXnin Cari fiyat listesinden hesap yapiliyor.
            // XXXXXXnin cari fiyat listesi sistem parametresinden alinacak.
            else
            {
                throw new TTException(SystemMessage.GetMessageV3(545, new string[] {Code, Name, pProcedure.Code, pProcedure.Name}));
                
                /*
                if(pSubActionDate == null)
                    throw new TTException("Paket tanımında olmayan bir hizmet grubundan hizmet girildiği için işlem yapılamadı! (" + pProcedure.Code + " " + pProcedure.Name + ")");
                else
                {
                    PricingListDefinition cariPricingList;
                    //IList pricingList = PricingListDefinition.GetByCode(this.ObjectContext, TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALPRICINGLISTCODE","0"));
                    IList pricingList = PricingListDefinition.GetByCode(context, TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALPRICINGLISTCODE","0"));
                    if (pricingList.Count == 0)
                        throw new TTException("XXXXXX Cari fiyat listesi bulunamadı!");
                    else
                        cariPricingList =  (PricingListDefinition) pricingList[0];
                    
                    pricingDetailList = pProcedure.GetProcedurePricingDetail(cariPricingList, pSubActionDate);
                    foreach (PricingDetailDefinition pp in pricingDetailList)
                    {
                        //ManipulatedPrice mypd = new ManipulatedPrice(ObjectContext);
                        ManipulatedPrice mypd = new ManipulatedPrice(context);
                        mypd.ExternalCode = pp.ExternalCode;
                        mypd.Description = pp.Description;
                        mypd.Price = pp.Price;
                        mypd.PricingDetailDefinition = pp;
                        manipulatedPDList.Add(mypd);
                    }
                    return manipulatedPDList;
                }
                 */
            }
        }
        
        private ArrayList CalculateProcedurePackagePrice(ProcedureDefinition pProcedure, PricingListDefinition pPricingList)
        {
            return CalculateProcedurePackagePrice(pProcedure, null, pPricingList);
        }
        
        private ArrayList CalculateProcedurePackagePrice(ProcedureDefinition pProcedure, DateTime? pSubActionDate)
        {
            return CalculateProcedurePackagePrice(pProcedure, pSubActionDate, null);
        }
        
        private ArrayList CalculateMaterialPackagePrice(Material pMaterial, DateTime? pSubActionDate, PricingListDefinition pPricingList)
        {
            ArrayList pricingDetailList = new ArrayList();
            ArrayList manipulatedPDList = new ArrayList();
            PackageDetailMaterial packDetail;
            TTObjectContext context = new TTObjectContext(false);
            
            foreach (PackageExceptionMaterial pExc in PackageExceptionMaterials)
            {
                if (pExc.Material == pMaterial)
                {
                    if(pSubActionDate == null)
                        pricingDetailList = pMaterial.GetMaterialPricingDetail(pPricingList);
                    else
                        pricingDetailList = pMaterial.GetMaterialPricingDetail(pExc.PricingListDefinition, pSubActionDate);
                    
                    foreach (PricingDetailDefinition pp in pricingDetailList)
                    {
                        //ManipulatedPrice mypd = new ManipulatedPrice(ObjectContext);
                        ManipulatedPrice mypd = new ManipulatedPrice(context);
                        mypd.ExternalCode = pp.ExternalCode;
                        mypd.Description = pp.Description;
                        mypd.Price = pp.Price;
                        mypd.PricingDetailDefinition = pp;
                        manipulatedPDList.Add(mypd);
                    }
                    
                    // Hiç fiyat eşleşmesi olmayan malzemelere 0(sıfır) fiyat oluşturması için
                    if(manipulatedPDList.Count == 0)
                    {
                        ManipulatedPrice mp = new ManipulatedPrice(context);
                        mp.ExternalCode = pMaterial.Code;
                        mp.Description = pMaterial.Name;
                        mp.Price = 0;
                        mp.PatientPrice = 0;
                        mp.PayerPrice = 0;
                        manipulatedPDList.Add(mp);
                    }
                    
                    return manipulatedPDList;
                }
            }
            
            packDetail = (PackageDetailMaterial)GetPackageDetailMaterialDefinition(pMaterial);
            if (packDetail != null)
            {
                if(pSubActionDate == null)
                    pricingDetailList = pMaterial.GetMaterialPricingDetail(pPricingList);
                else
                    pricingDetailList = pMaterial.GetMaterialPricingDetail(packDetail.PricingListDefinition, pSubActionDate);
                
                foreach (PricingDetailDefinition pp in pricingDetailList)
                {
                    //ManipulatedPrice mypd = new ManipulatedPrice(ObjectContext);
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = pp.ExternalCode;
                    mypd.Description = pp.Description;
                    mypd.Price = pp.Price;
                    mypd.PricingDetailDefinition = pp;
                    manipulatedPDList.Add(mypd);
                }
                
                // Hiç fiyat eşleşmesi olmayan malzemelere 0(sıfır) fiyat oluşturması için
                if(manipulatedPDList.Count == 0)
                {
                    ManipulatedPrice mp = new ManipulatedPrice(context);
                    mp.ExternalCode = pMaterial.Code;
                    mp.Description = pMaterial.Name;
                    mp.Price = 0;
                    mp.PatientPrice = 0;
                    mp.PayerPrice = 0;
                    manipulatedPDList.Add(mp);
                }
                
                return manipulatedPDList;
            }
            // anlasma taniminda olmayan bir hizmet grubundan hizmet girildigi zaman
            // %100 hastaya ve XXXXXXnin Cari fiyat listesinden hesap yapiliyor.
            // XXXXXXnin cari fiyat listesi sistem parametresinden alinacak.
            else
            {
                throw new TTException(SystemMessage.GetMessageV3(545, new string[] {Code, Name, pMaterial.Code, pMaterial.Name}));
                
                /*
                if(pSubActionDate == null)
                    throw new TTException("Paket tanımında olmayan bir malzeme grubundan malzeme/ilaç girildiği için işlem yapılamadı! (" + pMaterial.Code + " " + pMaterial.Name + ")");
                else
                {
                    PricingListDefinition cariPricingList;
                    //IList pricingList = PricingListDefinition.GetByCode(this.ObjectContext, TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALPRICINGLISTCODE","0"));
                    IList pricingList = PricingListDefinition.GetByCode(context, TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALPRICINGLISTCODE","0"));
                    if (pricingList.Count == 0)
                        throw new TTException("XXXXXX Cari fiyat listesi bulunamadı!");
                    else
                        cariPricingList =  (PricingListDefinition) pricingList[0];
                    
                    pricingDetailList = pMaterial.GetMaterialPricingDetail(cariPricingList, pSubActionDate);
                    foreach (PricingDetailDefinition pp in pricingDetailList)
                    {
                        //ManipulatedPrice mypd = new ManipulatedPrice(ObjectContext);
                        ManipulatedPrice mypd = new ManipulatedPrice(context);
                        mypd.ExternalCode = pp.ExternalCode;
                        mypd.Description = pp.Description;
                        mypd.Price = pp.Price;
                        mypd.PricingDetailDefinition = pp;
                        manipulatedPDList.Add(mypd);
                    }
                    return manipulatedPDList;
                }
                 */
            }
        }
        
        private ArrayList CalculateMaterialPackagePrice(Material pMaterial, PricingListDefinition pPricingList)
        {
            return CalculateMaterialPackagePrice(pMaterial, null, pPricingList);
        }
        
        private ArrayList CalculateMaterialPackagePrice(Material pMaterial, DateTime? pSubActionDate)
        {
            return CalculateMaterialPackagePrice(pMaterial, pSubActionDate, null);
        }
        
        public void AddSubActionIntoPackage(TTObject pObject, SubEpisodeProtocol pSEP, AccountOperationTimeEnum pAccountOp, Int16 pElapsedDay,SubActionPackageProcedure pMasterPackSubActProcedure)
        {
            ArrayList priceCol = new ArrayList();
            TTObject pmDef = null;
            bool packageInclude = false;
            SubActionProcedure sp = null;
            SubActionMaterial sm = null;
            PackageDefinition myPack = null;
            DateTime sActDate ;
            TTObjectContext context = new TTObjectContext(false);
            
            if (pObject.ObjectDef.IsOfType("SUBACTIONPROCEDURE") == true)
            {
                sp =  (SubActionProcedure) pObject;
                pmDef =  (TTObject) sp.ProcedureObject;
                sActDate = (DateTime) sp.PricingDate;
                if (IsIncluded(pmDef, pElapsedDay) == true)
                {
                    packageInclude = true;
                    sp.MasterPackgSubActionProcedure = pMasterPackSubActProcedure ;
                }
                else
                    sp.MasterPackgSubActionProcedure = null;
            }
            else
            {
                sm = (SubActionMaterial) pObject;
                pmDef =  (TTObject) sm.Material;
                sActDate = (DateTime) sm.PricingDate ;
                if (IsIncluded(pmDef, pElapsedDay) == true)
                {
                    packageInclude = true;
                    sm.MasterPackgSubActionProcedure = pMasterPackSubActProcedure ;
                }
                else
                    sm.MasterPackgSubActionProcedure = null;
            }

            if (packageInclude == true)
                myPack = this;
            

            if (pObject.ObjectDef.IsOfType("SUBACTIONPROCEDURE") == true)
            {
                foreach(AccountTransaction at in sp.AccountTransactions)
                {
                    if (at.IsAllowedToCancel == true)
                        at.CurrentStateDefID = TTObjectClasses.AccountTransaction.States.Cancelled;
                }
                
                if(sp.SubActionProcPricingDet.Count == 0)
                    priceCol = pSEP.Protocol.CalculatePrice(pmDef, pSEP.SubEpisode.Episode.PatientStatus, myPack, sActDate, pSEP.SubEpisode.Episode.Patient.AgeCompleted);
                else
                {
                    foreach(SubActionProcPricingDet subActProcPrice in sp.SubActionProcPricingDet)
                    {
                        double patientPrice = 0;
                        double payerPrice = 0;
                        ManipulatedPrice mypd = new ManipulatedPrice(context);
                        mypd.ExternalCode = subActProcPrice.ExternalCode;
                        mypd.Description = subActProcPrice.Description;
                        if (subActProcPrice.PatientPrice != null)
                            patientPrice = (double)subActProcPrice.PatientPrice;
                        if (subActProcPrice.PayerPrice != null)
                            payerPrice = (double)subActProcPrice.PayerPrice;
                        mypd.Price = patientPrice + payerPrice;
                        mypd.PatientPrice = patientPrice;
                        mypd.PayerPrice = payerPrice;
                        priceCol.Add(mypd);
                    }
                }
                
                if (priceCol.Count == 0)
                {
                    string procedureName = "";
                    if(sp != null)
                    {
                        if(sp.ProcedureObject != null)
                        {
                            if(sp.ProcedureObject.Code != null)
                                procedureName += sp.ProcedureObject.Code + " ";
                            
                            if(sp.ProcedureObject.Name != null)
                                procedureName += sp.ProcedureObject.Name;
                        }
                    }
                    throw new TTException(SystemMessage.GetMessageV3(546,new string[] {procedureName}));
                }
            }
            else if (pObject.ObjectDef.IsOfType("SUBACTIONMATERIAL") == true)
            {
                foreach (AccountTransaction at in sm.AccountTransactions)
                {
                    if (at.IsAllowedToCancel == true)
                        at.CurrentStateDefID = TTObjectClasses.AccountTransaction.States.Cancelled;
                }
                
                if(sm.SubActionMatPricingDet.Count == 0)
                    priceCol = pSEP.Protocol.CalculatePrice(pmDef, pSEP.SubEpisode.Episode.PatientStatus, myPack, sActDate, pSEP.SubEpisode.Episode.Patient.AgeCompleted);
                else
                {
                    foreach(SubActionMatPricingDet subActMatPrices in sm.SubActionMatPricingDet)
                    {
                        double patientPrice = 0;
                        double payerPrice = 0;
                        ManipulatedPrice mypd = new ManipulatedPrice(context);
                        mypd.ExternalCode = subActMatPrices.ExternalCode;
                        
                        if(!string.IsNullOrEmpty(subActMatPrices.Description))
                            mypd.Description = subActMatPrices.Description;
                        else
                            mypd.Description = "-";
                        
                        if (subActMatPrices.PatientPrice != null)
                            patientPrice = (double)subActMatPrices.PatientPrice;
                        
                        if (subActMatPrices.PayerPrice != null)
                            payerPrice = (double)subActMatPrices.PayerPrice;
                        
                        mypd.Price = patientPrice + payerPrice;
                        mypd.PatientPrice = patientPrice;
                        mypd.PayerPrice = payerPrice;
                        priceCol.Add(mypd);
                    }
                }
                
                if (priceCol.Count == 0)
                {
                    string materialName = "";
                    if(sm != null)
                    {
                        if(sm.Material != null)
                        {
                            if(sm.Material.Code != null)
                                materialName += sm.Material.Code + " ";
                            
                            if(sm.Material.Name != null)
                                materialName += sm.Material.Name;
                        }
                    }
                    throw new TTException(SystemMessage.GetMessageV3(547,new string[] {materialName}));
                }
            }
            
            if (priceCol.Count > 0)
            {
                foreach (ManipulatedPrice mpd in priceCol)
                {
                    if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
                        pSEP.AddAccountTransaction(AccountOwnerType.PAYER, pObject, mpd, myPack, pAccountOp );
                    if (mpd.PayerPrice > 0)
                        pSEP.AddAccountTransaction(AccountOwnerType.PAYER, pObject, mpd, myPack, pAccountOp);
                    if (mpd.PatientPrice > 0)
                        pSEP.AddAccountTransaction(AccountOwnerType.PATIENT, pObject, mpd, myPack, pAccountOp);
                }
            }
            // yeni oluşan acctrx lerin tarihleri subaction ın tarihiyle güncellenir
            if (pObject.ObjectDef.IsOfType("SUBACTIONPROCEDURE") == true)
            {
                foreach(AccountTransaction at in sp.AccountTransactions)
                {
                    if (at.CurrentStateDefID == TTObjectClasses.AccountTransaction.States.New || at.CurrentStateDefID == TTObjectClasses.AccountTransaction.States.ToBeNew)
                    {
                        at.TransactionDate = sp.PricingDate;
                        // ameliyat ve paket giriş action ındaki indirim ve bindirimi yeni acctrx lere yansıtmak için aşağıdaki kısım
                        if (sp.DiscountPercent != null && sp.DiscountPercent != 0)
                        {
                            if ((double)sp.DiscountPercent > 100)
                            {
                                at.UnitPrice = Math.Round((double)(at.UnitPrice * (sp.DiscountPercent / 100)),8);
                                at.Description = at.Description + " (%" + (sp.DiscountPercent - 100).ToString() + " ARTIRIM)";
                            }
                            else
                            {
                                at.UnitPrice = Math.Round((double)(at.UnitPrice * (1 - (sp.DiscountPercent / 100))),8);
                                at.Description = at.Description + " (%" + sp.DiscountPercent.ToString() + " İNDİRİM)";
                            }
                        }
                    }
                }
            }
            else if (pObject.ObjectDef.IsOfType("SUBACTIONMATERIAL") == true)
            {   foreach (AccountTransaction at in sm.AccountTransactions)
                {
                    if (at.CurrentStateDefID == TTObjectClasses.AccountTransaction.States.New || at.CurrentStateDefID == TTObjectClasses.AccountTransaction.States.ToBeNew)
                        at.TransactionDate = sm.PricingDate;
                }
            }
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PackageDefinitionInfo;
        }

        public static bool UsePackageDefinitions
        {
            get { return false; }
        }

        #endregion Methods

    }
}