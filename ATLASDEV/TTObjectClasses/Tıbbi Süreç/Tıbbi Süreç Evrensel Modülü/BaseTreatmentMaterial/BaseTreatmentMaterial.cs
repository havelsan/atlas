
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
    /// Ana Tedavi Sarf Tabı
    /// </summary>
    public partial class BaseTreatmentMaterial : SubActionMaterial, IMedulaChildOfEpisodeAction
    {
        public partial class GetTreatmentMaterialByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetTreatmentMaterialsByNSNAndStore_Class : TTReportNqlObject
        {
        }

        public partial class GetTreatmentMaterialBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class VEM_STOK_FIS_Class : TTReportNqlObject
        {
        }

        #region IMedulaChildOfEpisodeAction Members
        public PatientMedulaHastaKabul GetMedulaHastaKabul()
        {
            return MedulaHastaKabul;
        }

        public void SetMedulaHastaKabul(PatientMedulaHastaKabul value)
        {
            MedulaHastaKabul = value;
        }

        public IEpisodeAction GetEpisodeActionObject()
        {
            return EpisodeActionObject;
        }

        public void SetEpisodeActionObject(IEpisodeAction value)
        {
            EpisodeActionObject = value;
        }
        #endregion

        #region ITTBaseObject Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion



        public override void OnContextDispose()
        {
            base.OnContextDispose();
            _calculeteUnitPrice = CalculateUnitePrice;
            _calculateAmount = CalculateAmount;
            _calculateDistributionType = CalculateDistributionType;
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "SUBACTIONPROCEDUREFLOWABLE":
                    {
                        SubactionProcedureFlowable value = (SubactionProcedureFlowable)newValue;
                        #region SUBACTIONPROCEDUREFLOWABLE_SetParentScript
                        Episode = value.Episode;
                        if (SubEpisode == null)
                            SubEpisode = value.SubEpisode;

                        SetStore((IEpisodeActionResources)value);
                        //            if(value.ForceToUpdate==null)
                        //            {
                        //                value.ForceToUpdate=false;
                        //            }
                        //            else
                        //            {
                        //                value.ForceToUpdate = !(value.ForceToUpdate);
                        //            }
                        #endregion SUBACTIONPROCEDUREFLOWABLE_SetParentScript
                    }
                    break;
                case "EPISODEACTION":
                    {
                        EpisodeAction value = (EpisodeAction)newValue;
                        #region EPISODEACTION_SetParentScript
                        //Description            
                        //
                        if (value != null)
                        {
                            Episode = value.Episode;
                            //if (this.Store == null)
                            //    this.SetStore((IEpisodeActionResources)value);

                            // SubEpisode Set etme
                            SubEpisode = value.SubEpisode;
                            //                                                     
                        }
                        //            if(value.ForceToUpdate==null)
                        //            {
                        //                value.ForceToUpdate=false;
                        //            }
                        //            else
                        //            {
                        //                value.ForceToUpdate = !(value.ForceToUpdate);
                        //            }
                        #endregion EPISODEACTION_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
            #region PreInsert
            if (UnitPrice == null && SubEpisode != null)
            {
                if (SubEpisode.OpenSubEpisodeProtocol != null)
                {
                    if (CreationDate != null)
                    {
                        UnitPrice = Material.GetMaterialPrice(SubEpisode.OpenSubEpisodeProtocol, CreationDate);
                    }
                    else
                    {
                        throw new TTException("Malzeme Fiyat Oluşturma Tarihi Boş olamaz.");
                    }
                }
            }

            base.PreInsert();

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            CheckDischargeStatusAndDate();
            StockOutByEpisodeActionAttribute();


            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();
            StockOutByEpisodeActionAttribute();

            #endregion PostUpdate
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled

            Cancel();
            #endregion PostTransition_New2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }


        #region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                SetFirstState();
            }
        }

        // Taburcu olmuş ve fatura kaydı yapılmış SGK'lı hastalara malzeme girilemesin kontrolü
        public void CheckDischargeStatusAndDate()
        {
            // XXXXXXda böyle kontrol edilyormuş 
            //if (this.Episode != null && this.Episode.PatientStatus == PatientStatusEnum.Discharge)
            //{
            //    if (this.SubEpisode.IsSGK)
            //    {
            //        if (SubEpisode.SGKSEP != null && SubEpisode.SGKSEP.InvoiceStatus == MedulaSubEpisodeStatusEnum.Invoiced)
            //            throw new TTException("Fatura kaydı yapılmış SGK'lı hastalara malzeme sarfı yapılamaz !");
            //        else
            //        {
            //            DateTime? latestClinicDischargeDate = this.Episode.GetLatestClinicDischargeDate();
            //            if(this.ActionDate.HasValue && latestClinicDischargeDate.HasValue && this.ActionDate.Value.Date > latestClinicDischargeDate.Value.Date)
            //                throw new TTException("SGK'lı hastalara taburcu tarihinden sonraki bir tarih ile malzeme sarfı yapılamaz !");
            //        }
            //    }
            //}

            if (this is OrthesisProthesisRequestTreatmentMaterial) // Ortez Protez işleminden girilen malzemelerde fatura ve taburcu tarih kontrollerinin yapılmaması istendi
                return;

            if (SubEpisode != null)
            {
                var starterInPatientTreatmentClinicApplication = SubEpisode.GetStarterInPatientTreatmentClinicApplication();
                if (starterInPatientTreatmentClinicApplication != null)
                {
                    if (SubEpisode.IsSGK)
                    {
                        if (SubEpisode.SGKSEP != null && SubEpisode.SGKSEP.IsInvoiced)
                            throw new TTException(TTUtils.CultureService.GetText("M25637", "Fatura kaydı yapılmış SGK'lı hastalara malzeme sarfı yapılamaz !"));

                        DateTime? clinicDischargeDate = starterInPatientTreatmentClinicApplication.ClinicDischargeDate;
                        if (!IgnoreClinicDischargeDate())
                        {
                            if (ActionDate.HasValue && clinicDischargeDate.HasValue && ActionDate.Value.Date > clinicDischargeDate.Value.Date)
                            {
                                if (PricingDate != null)
                                {
                                    if (PricingDate.Value.Date > clinicDischargeDate.Value.Date)
                                        throw new TTException(TTUtils.CultureService.GetText("M26874", "SGK'lı hastalara taburcu tarihinden sonraki bir tarih ile malzeme sarfı yapılamaz !"));
                                }
                                else
                                {
                                    throw new TTException(TTUtils.CultureService.GetText("M26874", "SGK'lı hastalara taburcu tarihinden sonraki bir tarih ile malzeme sarfı yapılamaz !"));
                                }
                            }

                        }
                    }
                }
            }
        }




        public virtual void SetFirstState()
        {
            CurrentStateDefID = BaseTreatmentMaterial.States.New;
        }







        //        /// <summary>
        //        /// Class'a bağlanan StoreUsageAttribute yoksa StoreUsageEnum.UseMasterResource, varda parametre değeri ne ise o döner.
        //        /// </summary>
        //        public StoreUsageEnum GetStoreUsage()
        //        {
        //            if (Common.IsAttributeExists(typeof(StoreUsageAttribute),(TTObject)this)==false)
        //            {
        //                return StoreUsageEnum.UseMasterResource;
        //            }
        //            else
        //            {
        //                string storeUsageEnum = this.ObjectDef.Attributes["STOREUSAGEATTRIBUTE"].Parameters["StoreUsage"].Value.ToString();
        //                switch (storeUsageEnum)
        //                {
        //                    case "0":
        //                        return StoreUsageEnum.Nothing;
        //                        break;
        //                    case "1":
        //                        return StoreUsageEnum.UseMasterResource;
        //                        break;
        //                    case "2":
        //                        return StoreUsageEnum.UseFromResource;
        //                        break;
        //                    case "3":
        //                        return StoreUsageEnum.UseSecMasterResource;
        //                        break;
        //                    case "4":
        //                        return StoreUsageEnum.UseUser;
        //                        break;
        //                    default:
        //                        return StoreUsageEnum.UseMasterResource;
        //                        break;
        //                }
        //            }
        //        }
        //
        //        public void SetStore(IEpisodeActionResources episodeActionResources)
        //        {
        //            switch (this.GetStoreUsage())
        //            {
        //                case StoreUsageEnum.UseMasterResource:
        //                    this.Store=episodeActionResources.MasterResource.Store;
        //                    break;
        //                case StoreUsageEnum.UseFromResource:
        //                    this.Store=episodeActionResources.FromResource.Store;
        //                    break;
        //                case StoreUsageEnum.UseUser:
        //                    this.Store=Common.CurrentResource.Store;
        //                    break;
        //                case StoreUsageEnum.UseSecMasterResource:
        //                    this.Store=episodeActionResources.SecondaryMasterResource.Store;
        //                    break;
        //            }
        //        }

        //        public class StockOutStores
        //        {
        //            public  IList<SubActionMaterial> subActionMaterials = new List<SubActionMaterial>();
        //            public  Store store;
        //        }
        //
        //        public void StockOutOperation()
        //        {
        //            if(this.StockActionDetail==null)
        //            {
        //                bool stockout=false;
        //                StockOutStores stockOutStores = new StockOutStores();
        //                stockOutStores.store = this.Store;
        //                stockOutStores.subActionMaterials.Add(this);
        //
        //                Store store = stockOutStores.store;
        //
        //                StockOut stockOut = new StockOut(ObjectContext);
        //                stockOut.CurrentStateDefID = StockOut.States.New;
        //                stockOut.Store = store;
        //
        //                StockActionDetailOut stockActionDetailOut = (StockActionDetailOut)stockOut.StockOutMaterials.AddNew();
        //                stockActionDetailOut.Material = this.Material;
        //                stockActionDetailOut.Amount = this.Amount;
        //                stockActionDetailOut.StockLevelType = StockLevelType.NewStockLevel;
        //                stockActionDetailOut.Status = StockActionDetailStatusEnum.New;
        //                this.StockActionDetail= stockActionDetailOut;
        //                stockOut.Update();
        //                stockOut.CurrentStateDefID = StockOut.States.Completed;
        //            }
        //        }
        //        public void StockOutByEpisodeActionAttribute()
        //        {
        //            if(this.StockActionDetail==null)
        //            {
        //                bool stockout=false;
        //                if(this.EpisodeAction!=null)
        //                {
        //                    if(Common.IsStateAttributeExists(typeof(StockOutTreatmentMaterialOnSaveAttribute),this.EpisodeAction.OriginalStateDef))
        //                    {
        //                        this.StockOutOperation();
        //                        stockout=true;
        //                    }
        //                    if(this.EpisodeAction.TransDef!=null && !stockout)
        //                    {
        //                        if(Common.IsTransitionAttributeExists(typeof(StockOutTreatmentMaterialOnTransitionAttribute),this.EpisodeAction.TransDef))
        //                        {
        //                            this.StockOutOperation();
        //                            stockout=true;
        //                        }
        //                    }
        //                }
        //                if(this.SubactionProcedureFlowable!=null && !stockout)
        //                {
        //                    if(Common.IsStateAttributeExists(typeof(StockOutTreatmentMaterialOnSaveAttribute),this.SubactionProcedureFlowable.OriginalStateDef))
        //                    {
        //                        this.StockOutOperation();
        //                        stockout=true;
        //                    }
        //                    if(this.SubactionProcedureFlowable.TransDef!=null && !stockout)
        //                    {
        //                        if(Common.IsTransitionAttributeExists(typeof(StockOutTreatmentMaterialOnTransitionAttribute),this.SubactionProcedureFlowable.TransDef))
        //                        {
        //                            this.StockOutOperation();
        //                            stockout=true;
        //                        }
        //                    }
        //                }
        //            }
        //        }


        //        public void AccountOperation (AccountOperationTimeEnum pPreAccounting)
        //        {
        //            AccountOperationTimeEnum accountOp = AccountOperationTimeEnum.PRE;
        //            AccountOperationTimeEnum pAccounting = AccountOperationTimeEnum.PRE;
        //            AccountOperationTimeEnum tempAccountOp = AccountOperationTimeEnum.PRE;
        //            PatientStatusEnum pStatus;
        //            PackageDefinition packDef = null;
        //            IList packageSubActionProcedures;
        //            PatientGroupEnum pGroup;
        //            Material mDef = null;
        //            bool isPackageProcedure =false;
        //            bool pFound = false;
        //            Episode myEpisode = null;
        //
        //            myEpisode = this.EpisodeAction.Episode;
        //            pStatus = myEpisode.PatientStatus.Value;
        //            pGroup = myEpisode.PatientGroup.Value;
        //            mDef =  this.Material;
        //
        //            // notHasAccTrxs kısmı yoktu önceden
        //            bool notHasAccTrxs = true;
        //
        //            foreach (AccountTransaction accTrx in this.AccountTransactions)
        //            {
        //                if (accTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
        //                    notHasAccTrxs = false;
        //            }
        //            // 
        //
        //            if (pPreAccounting == AccountOperationTimeEnum.PREPOST)
        //            {
        //                // this.AccountTransactions.count = 0 ise PRE, değilse POST şeklindeydi eski hali, artık tüm acctrx leri iptal
        //                // ise de PRE çalışsın şeklinde değiştirildi. Diş entegrasyonu için, tüm AccTrx leri iptal olmuş bir SubactionProcedure
        //                // için tekrar AccountOperation çağırıldığında eski halinde ücretlendirmiyordu, artık ücretlendiriyor.
        //                // BaseTreatmentMaterial de SubactionProcedure ile aynı mantıkta çalışsın diye aynı değişikliği burda da yaptık. )
        //
        //                //if ( this.AccountTransactions.Count == 0)
        //                if (notHasAccTrxs)
        //                    accountOp = AccountOperationTimeEnum.PRE;
        //                else
        //                    accountOp = AccountOperationTimeEnum.POST;
        //            }
        //            else
        //            {    accountOp = pPreAccounting;
        //            }
        //            //Hasta Grubuna gore account tipini bul
        //            IList patientGroupList = PatientGroupDefinition.GetAll(this.ObjectContext);
        //            foreach (PatientGroupDefinition pgd in patientGroupList)
        //            {
        //                if (pGroup == pgd.PatientGroupEnum)
        //                {
        //                    if (pStatus == PatientStatusEnum.Outpatient)
        //                        pAccounting = pgd.InvoiceAccountDefinition.OutPatientPaymentType.Value;
        //                    else
        //                        pAccounting = pgd.InvoiceAccountDefinition.InPatientPaymentType.Value;
        //                    pFound = true;
        //                    break;
        //                }
        //            }
        //
        //            if (pFound == false)
        //                throw new TTException("Hasta Grup Tanımı ekranından " + myEpisode.PatientGroup.ToString() + " hasta grubu için tanımlama yapılması gerekmektedir!");
        //            else
        //            {
        //                if (accountOp == AccountOperationTimeEnum.PRE)
        //                {
        //                    if (notHasAccTrxs)        // if (this.AccountTransactions.Count == 0)  dı eskiden, yukarı ile ilişkili
        //                    {
        //                        EpisodeProtocol ep = myEpisode.MyEpisodeProtocol();
        //
        //                        if (ep == null)
        //                            throw new TTException("Bu vakaya ait açık anlaşma bulunmamaktadır. Vakaya ait fatura işlemleri bitmiştir ya da anlaşma kapatılmıştır. Fatura işlemleri bitmişse, işleme yeni bir vakada devam ediniz. Fatura işlemleri bitmemişse, anlaşmaların durumunu kontrol ediniz!");
        //
        //                        //Girilen malzeme ilk bulunan paket hizmet kapsaminda mi kontrolunu yap.
        //                        packageSubActionProcedures = ep.GetPackagesInEP();
        //                        foreach (SubActionProcedure sp in packageSubActionProcedures)
        //                        {
        //                            PackageDefinition p = sp.PackageDefinition;
        //                            if (p.IsIncluded(mDef, (Int16)this.PricingDate.Value.Subtract(sp.PricingDate.Value).Days) == true)
        //                            {
        //                                this.MasterPackgSubActionProcedure = sp;
        //                                packDef = p;
        //                                break;
        //                            }
        //                        }
        //
        //                        ArrayList col = new ArrayList();
        //                        if(this.SubActionMatPricingDet == null)
        //                            col = ep.Protocol.CalculatePrice(mDef, myEpisode.PatientStatus, packDef, DateTime.Now);
        //                        else
        //                        {
        //                            foreach(SubActionMatPricingDet subActMatPrices in this.SubActionMatPricingDet)
        //                            {
        //                                ManipulatedPrice mypd = new ManipulatedPrice(ObjectContext);
        //                                mypd.ExternalCode = subActMatPrices.ExternalCode;
        //                                mypd.Description = subActMatPrices.Description;
        //                                mypd.Price = (double)subActMatPrices.PatientPrice + (double)subActMatPrices.PayerPrice;
        //                                mypd.PatientPrice = subActMatPrices.PatientPrice;
        //                                mypd.PayerPrice = subActMatPrices.PayerPrice;
        //                                col.Add(mypd);
        //                            }
        //                        }
        //
        //                        if (col.Count == 0)
        //                        {
        //                            throw new TTException("Malzeme ( " + mDef.Name.ToString() + " ) Fiyat eşleştirilmemiş!");
        //                        }
        //                        else
        //                        {
        //                            foreach (ManipulatedPrice mpd in col)
        //                            {
        //                                if (mpd.PatientPrice == 0 && mpd.PayerPrice == 0)
        //                                {
        //                                    ep.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, packDef, accountOp);
        //                                    tempAccountOp = accountOp;
        //                                }
        //
        //                                if (mpd.PayerPrice > 0)
        //                                {
        //                                    if (pPreAccounting == AccountOperationTimeEnum.PREPOST)
        //                                    {
        //                                        ep.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, packDef, accountOp);
        //                                        tempAccountOp = accountOp;
        //                                    }
        //                                    else
        //                                    {
        //                                        ep.AddAccountTransaction(AccountOwnerType.PAYER, this, mpd, packDef, pAccounting);
        //                                        tempAccountOp = pAccounting;
        //                                    }
        //                                }
        //                                if (mpd.PatientPrice > 0)
        //                                {
        //                                    ep.AddAccountTransaction(AccountOwnerType.PATIENT, this, mpd, packDef, accountOp);
        //                                    tempAccountOp = accountOp;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                else if (accountOp == AccountOperationTimeEnum.POST)
        //                {
        //                    foreach (AccountTransaction accTrx in this.AccountTransactions)
        //                    {
        //                        if (accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew)
        //                            accTrx.CurrentStateDefID =  AccountTransaction.States.New;
        //                    }
        //
        //                }
        //            }
        //        }
        //
        //        public void AccountOperationAttribute()
        //        {
        //            if((bool)this.Material.Chargable)
        //            {
        //                if (this.TransDef != null)
        //                {
        //                    if(Common.IsTransitionAttributeExists(typeof(AccountOperationAttribute),this.TransDef))
        //                    {
        //
        //                        if (this.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //                        {
        //                            AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum) this.TransDef.AllAttributes["AccountOperationAttribute"].Parameters["PreAccounting"].Value;
        //                            this.AccountOperation(pPreAccounting);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if(Common.IsStateAttributeExists(typeof(AccountOperationStateAttribute),this.CurrentStateDef))
        //                    {
        //                        if (this.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //                        {
        //                            AccountOperationTimeEnum pPreAccounting = (AccountOperationTimeEnum) this.CurrentStateDef.AllAttributes["AccountOperationStateAttribute"].Parameters["PreAccounting"].Value;
        //                            this.AccountOperation(pPreAccounting);
        //                        }
        //                    }
        //                }
        //            }
        //
        //        }

        public bool IsStockOutOperationDone()
        {
            if (this["STOCKACTIONDETAIL"] != null)
                return true;
            return false;
        }



        override public bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        {
            if (relDef.ParentObjectDefID == new Guid("f18cbf08-9ee2-40de-8029-c3f7e739c3a4"))// SubEpisode
                return false;

            if (relDef.ParentObjectDef.IsOfType(typeof(Material).Name.ToUpperInvariant()) || relDef.ParentObjectDef.IsOfType(typeof(Store).Name.ToUpperInvariant()))
                return IsStockOutOperationDone() || IsAccountOperationDone();
            else
                return false;
        }


        override public bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        {
            if (propDef.PropertyDefID == new Guid("f65f3ad6-7a53-488a-a443-4465e14d4bb3"))
                return IsStockOutOperationDone() || IsAccountOperationDone();
            else
                return false;
        }

        override public object GetDVO(AccountTransaction AccTrx)
        {
            if (Material is DrugDefinition)
                return GetDrugDVO(AccTrx);
            else
                return GetMaterialDVO(AccTrx);
        }

        public HizmetKayitIslemleri.ilacBilgisiDVO GetDrugDVO(AccountTransaction AccTrx)
        {
            HizmetKayitIslemleri.ilacBilgisiDVO ilacBilgisiDVO = new HizmetKayitIslemleri.ilacBilgisiDVO();

            if (Material.AccTrxAmountMultiplier.HasValue)
                ilacBilgisiDVO.adet = AccTrx.Amount * Material.AccTrxAmountMultiplier.Value;
            else
                ilacBilgisiDVO.adet = AccTrx.Amount;

            //ilacBilgisiDVO.adetSpecified = true;
            ilacBilgisiDVO.barkod = string.IsNullOrEmpty(AccTrx.Barcode) ? Material.Barcode : AccTrx.Barcode;
            ilacBilgisiDVO.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
            ilacBilgisiDVO.islemTarihi = AccTrx.MedulaTransactionDate;
            ilacBilgisiDVO.paketHaric = AccTrx.MedulaPackageInOut;
            ilacBilgisiDVO.tutar = AccTrx.UnitPrice;
            //ilacBilgisiDVO.tutarSpecified = true;

            // 1 : Barkodlu İlaç , 2 : Majistral İlaç , 3 : Radyofarmasötik Ajan  (Şimdilik 3 göndermiyoruz)
            if (Material is MagistralPreparationDefinition)
            {
                ilacBilgisiDVO.ilacTuru = "2";
                ilacBilgisiDVO.aciklama = MedulaMagistralPreparationDescription;   // majistral ilacın içeriğini döndüren coded property
            }
            else
                ilacBilgisiDVO.ilacTuru = "1";

            StockTransaction stockTransaction = GetStockTransactionForDrugDVO();
            if (stockTransaction != null)
            {
                ilacBilgisiDVO.SN = stockTransaction.SerialNo;
                ilacBilgisiDVO.sonKullanimTarihi = stockTransaction.ExpirationDate.HasValue ? stockTransaction.ExpirationDate.Value.ToString("dd.MM.yyyy") : null;
                ilacBilgisiDVO.batchNo = stockTransaction.LotNo;
                //ilacBilgisiDVO.itsBirimSarfId = null;  // Şimdilik tutulan bir bilgi değil, ileride gerek olursa doldurulacak. 
            }

            if (OzelDurum != null && OzelDurum.ozelDurumKodu != null)
                ilacBilgisiDVO.ozelDurum = OzelDurum.ozelDurumKodu;

            if (CokluOzelDurum != null && CokluOzelDurum.Count > 0)
            {
                List<String> listCokluOzelDurum = new List<String>();
                foreach (CokluOzelDurum od in CokluOzelDurum)
                {
                    listCokluOzelDurum.Add(od.OzelDurum.ozelDurumKodu);
                }
                ilacBilgisiDVO.cokluOzelDurum = listCokluOzelDurum.ToArray();
            }

            return ilacBilgisiDVO;
        }

        public HizmetKayitIslemleri.malzemeBilgisiDVO GetMaterialDVO(AccountTransaction AccTrx)
        {
            HizmetKayitIslemleri.malzemeBilgisiDVO malzemeBilgisiDVO = new HizmetKayitIslemleri.malzemeBilgisiDVO();
            malzemeBilgisiDVO.adet = AccTrx.Amount;
            //malzemeBilgisiDVO.adetSpecified = true;
            malzemeBilgisiDVO.barkod = !string.IsNullOrEmpty(AccTrx.Barcode) ? AccTrx.Barcode : Material.Barcode;
            malzemeBilgisiDVO.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
            malzemeBilgisiDVO.islemTarihi = AccTrx.MedulaTransactionDate;
            malzemeBilgisiDVO.malzemeTuru = "1";  // Default "1: SUT Kodlu" gönderilir  (1: SUT Kodlu, 2: Emekli Sandığı Protokol Kodlu, 3: Kodsuz Malzeme)
            malzemeBilgisiDVO.malzemeKodu = AccTrx.MedulaMaterialCode;
            malzemeBilgisiDVO.kodsuzMalzemeFiyati = Convert.ToDouble(AccTrx.UnitPrice * AccTrx.Amount);
            //malzemeBilgisiDVO.kodsuzMalzemeFiyatiSpecified = true;

            malzemeBilgisiDVO.bransKodu = GetMedulaBransKodu();
            malzemeBilgisiDVO.drTescilNo = GetMedulaDrTescilNo(malzemeBilgisiDVO.bransKodu);

            DateTime? malzemeSatinAlisTarihi = GetMedulaMalzemeSatinAlisTarihi(AccTrx);

            if (malzemeSatinAlisTarihi.HasValue)
                malzemeBilgisiDVO.malzemeSatinAlisTarihi = malzemeSatinAlisTarihi.Value.ToString("dd.MM.yyyy");

            malzemeBilgisiDVO.paketHaric = AccTrx.MedulaPackageInOut;
            malzemeBilgisiDVO.katkiPayi = MedulaPatientShareExists(AccTrx);
            malzemeBilgisiDVO.firmaTanimlayiciNo = !string.IsNullOrEmpty(AccTrx.ProducerCode) ? AccTrx.ProducerCode : ((Material.Producer != null && Material.Producer.FirmIdentifierNo.HasValue) ? Material.Producer.FirmIdentifierNo.ToString() : null);
            malzemeBilgisiDVO.donorId = DonorID;

            // Satın Alma Tarihi 04.09.2019 tarihinden sonra olan malzemeler için Bayi No gönderilmez.
            if (!malzemeSatinAlisTarihi.HasValue || (malzemeSatinAlisTarihi.HasValue && malzemeSatinAlisTarihi.Value < DateTime.Parse("04/09/2019")))
                malzemeBilgisiDVO.bayiNo = !string.IsNullOrEmpty(AccTrx.MedulaDealerNo) ? AccTrx.MedulaDealerNo : GetMedulaBayiNo();

            malzemeBilgisiDVO.seriNo = AccTrx.StockOutTransaction != null ? AccTrx.StockOutTransaction.SerialNo : null;
            malzemeBilgisiDVO.lotNo = AccTrx.StockOutTransaction != null ? AccTrx.StockOutTransaction.LotNo : null;
            malzemeBilgisiDVO.kullanimBildirimID = AccTrx.UTSNotificationDetail != null ? AccTrx.UTSNotificationDetail.NotificationID : null;

            if (Material.MaterialVatRates != null && Material.MaterialVatRates.Count > 0)
            {
                if (Material.MaterialVatRates[0].VatRate != null)
                {
                    malzemeBilgisiDVO.kdv = Convert.ToInt32(Material.MaterialVatRates[0].VatRate.Value);
                    //malzemeBilgisiDVO.kdvSpecified = true;
                }
            }

            if (OzelDurum != null && !string.IsNullOrEmpty(OzelDurum.ozelDurumKodu))
                malzemeBilgisiDVO.ozelDurum = OzelDurum.ozelDurumKodu;

            if (CokluOzelDurum != null && CokluOzelDurum.Count > 0)
            {
                List<String> listCokluOzelDurum = new List<String>();
                foreach (CokluOzelDurum od in CokluOzelDurum)
                    listCokluOzelDurum.Add(od.OzelDurum.ozelDurumKodu);

                malzemeBilgisiDVO.cokluOzelDurum = listCokluOzelDurum.ToArray();
            }

            return malzemeBilgisiDVO;
        }

        public string GetMedulaBransKodu()
        {
            if (Material.Brans != null)
                return Material.Brans.Code;

            if (SubEpisode != null && SubEpisode.Speciality != null)
                return SubEpisode.Speciality.Code;

            if (Episode.MainSpeciality != null)
                return Episode.MainSpeciality.Code;

            return null;
        }

        public string GetMedulaDrTescilNo(string branchCode)
        {
            if (SubactionProcedureFlowable != null)
            {
                if (SubactionProcedureFlowable is RadiologyTest)
                {
                    RadiologyTest radiologyTest = SubactionProcedureFlowable as RadiologyTest;
                    string drTescilNo = radiologyTest.GetDVODrTescilNo(branchCode);
                    if (!string.IsNullOrEmpty(drTescilNo))
                        return drTescilNo;
                }

                if (SubactionProcedureFlowable.ProcedureDoctor != null && !string.IsNullOrEmpty(SubactionProcedureFlowable.ProcedureDoctor.DiplomaRegisterNo))
                    return SubactionProcedureFlowable.ProcedureDoctor.DiplomaRegisterNo;

                if (SubactionProcedureFlowable.EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(SubactionProcedureFlowable.EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
                    return SubactionProcedureFlowable.EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;
            }

            if (EpisodeAction != null)
            {
                if (EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
                    return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;

                if (EpisodeAction is Manipulation)
                {
                    Manipulation manipulation = EpisodeAction as Manipulation;
                    if (manipulation.SorumluDoktor != null && !string.IsNullOrEmpty(manipulation.SorumluDoktor.DiplomaRegisterNo))
                        return manipulation.SorumluDoktor.DiplomaRegisterNo;
                }
                else if (EpisodeAction is Pathology)
                {

                    Pathology pathology = EpisodeAction as Pathology;
                    string drTescilNo = pathology.GetDoctorRegistrationNumber(branchCode);
                    if (!string.IsNullOrEmpty(drTescilNo))
                        return drTescilNo;
                }
            }

            if (Episode.InPatientTreatmentClinicApplications != null && Episode.InPatientTreatmentClinicApplications.Count > 0)
            {
                foreach (InPatientTreatmentClinicApplication treatClinicApp in Episode.InPatientTreatmentClinicApplications)
                {
                    if (treatClinicApp.ProcedureDoctor != null && !string.IsNullOrEmpty(treatClinicApp.ProcedureDoctor.DiplomaRegisterNo))
                        return treatClinicApp.ProcedureDoctor.DiplomaRegisterNo;
                }
            }

            foreach (EpisodeAction episodeAction in SubEpisode.PatientAdmission.FiredEpisodeActions)
            {
                if (episodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(episodeAction.ProcedureDoctor.DiplomaRegisterNo))
                    return episodeAction.ProcedureDoctor.DiplomaRegisterNo;

                if (episodeAction is Manipulation)
                {
                    Manipulation manipulation = episodeAction as Manipulation;
                    if (manipulation.SorumluDoktor != null && !string.IsNullOrEmpty(manipulation.SorumluDoktor.DiplomaRegisterNo))
                        return manipulation.SorumluDoktor.DiplomaRegisterNo;
                }
            }

            ResUser examinationDoctor = Episode.GetPatientExaminationDoctor();
            if (examinationDoctor != null && !string.IsNullOrEmpty(examinationDoctor.DiplomaRegisterNo))
                return examinationDoctor.DiplomaRegisterNo;

            return null;
        }

        public DateTime? GetMedulaMalzemeSatinAlisTarihi(AccountTransaction AccTrx)
        {
            if (AccTrx.PurchaseDate.HasValue)
                return AccTrx.PurchaseDate.Value;

            if (StockActionDetail != null && StockActionDetail.StockTransactions.Select("INOUT=2").Count > 0)
            {
                DateTime? satinAlisTarihi = StockActionDetail.StockTransactions.Select("INOUT=2")[0].GetPurchaseDate();
                if (satinAlisTarihi.HasValue)
                    return satinAlisTarihi.Value;
            }

            if (Material.PurchaseDate.HasValue)
                return Material.PurchaseDate.Value;

            return null;
        }

        public string GetMedulaBayiNo()
        {
            StockTransaction st = StockActionDetail.StockTransactions.Select("").FirstOrDefault();
            if (st != null)
                return st.GetSupplierNumber();

            return null;
        }

        public string GetMedulaMaterialCode(AccountTransaction AccTrx)
        {
            string malzemeKodu = string.Empty;
            if (Material.IsOldMaterial.HasValue && Material.IsOldMaterial.Value == true) // Eski malzemeler için
            {
                if (Material.GetOldMaterialType() == OldMaterialTypeEnum.TITUBBMaterial)
                {
                    // 22F Malzemesi ise SUT Kodu tekliften alınıyor
                    if (this is SurgeryDirectPurchaseGrid)
                    {
                        SurgeryDirectPurchaseGrid surgeryDirectPurchaseGrid = (SurgeryDirectPurchaseGrid)this;
                        if (surgeryDirectPurchaseGrid.DPADetailFirmPriceOffer != null && surgeryDirectPurchaseGrid.DPADetailFirmPriceOffer.OfferedSUTCode != null)
                        {
                            if (!string.IsNullOrEmpty(surgeryDirectPurchaseGrid.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode))
                                malzemeKodu = surgeryDirectPurchaseGrid.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode.Replace(".", "").Trim();
                        }
                    }
                    else // Diğerlerinde TITUBB eşleşmelerinden alınıyor
                    {
                        ProductDefinition product = null;
                        if (SubActionMatPricingDet.Count > 0)
                        {
                            foreach (SubActionMatPricingDet smpd in SubActionMatPricingDet)
                            {
                                if (smpd.ProductDefinition != null)
                                {
                                    product = smpd.ProductDefinition;
                                    break;
                                }
                            }
                        }
                        if (product == null)
                            product = Material.GetCorrectProduct();

                        if (product != null && product.ProductSUTMatchs != null && product.ProductSUTMatchs.Count > 0)
                        {
                            ProductSUTMatchDefinition productSUTMatch = product.GetProperSUTMatch();
                            if (!string.IsNullOrEmpty(productSUTMatch.SUTCode))
                                malzemeKodu = productSUTMatch.SUTCode.Replace(".", "").Trim();
                        }
                    }
                }
            }
            else // Yeni malzemeler için
                malzemeKodu = AccTrx.MedulaMaterialCode;

            return malzemeKodu;
        }

        public StockTransaction GetStockTransactionForDrugDVO()
        {
            if (StockActionDetail != null)
            {
                foreach (StockTransaction stockTransaction in StockActionDetail.StockTransactions.Select(string.Empty))
                {
                    if (stockTransaction.CurrentStateDefID == StockTransaction.States.Completed)
                        return stockTransaction;
                }
            }

            return null;
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(BaseTreatmentMaterial).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == BaseTreatmentMaterial.States.New && toState == BaseTreatmentMaterial.States.Cancelled)
                PostTransition_New2Cancelled();

            if (fromState == BaseTreatmentMaterial.States.Completed && toState == BaseTreatmentMaterial.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }



        /// <summary>
        ///Hesaplanmış Fiyat
        /// </summary>
        private Currency? _calculeteUnitPrice = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public Currency? CalculateUnitePrice
        {
            get
            {
                try
                {
                    if (UnitPrice == 0)
                    {
                        if (_calculeteUnitPrice.HasValue == false)
                        {
                            Currency totalUnitPrice = 0;
                            Currency totolAmount = 0;
                            if (this.StockActionDetail != null)
                            {
                                foreach (StockTransaction st in this.StockActionDetail.StockTransactions.Select(string.Empty))
                                {
                                    if (st.CurrentStateDefID != StockTransaction.States.Cancelled)
                                    {
                                        totalUnitPrice += (Currency)st.UnitPrice * (Currency)st.Amount;
                                        totolAmount += (Currency)st.Amount.Value;
                                    }
                                }
                                return totalUnitPrice / totolAmount;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            return _calculeteUnitPrice.Value;
                        }
                    }
                    else
                    {
                        return UnitPrice;
                    }

                }
                catch
                {
                    if (UnitPrice != null)
                        return UnitPrice;
                    else
                        return 0;
                }
            }
        }


        /// <summary>
        /// Depo Mevcudu
        /// </summary>
        [TTStorageManager.Attributes.TTSerializeProperty]
        public string UTSUseNotification
        {
            get
            {
                string result = "-";
                try
                {
                    if (((ITTObject)this).IsDeleted == false)
                    {
                        using (var objectContext = new TTObjectContext(true))
                        {

                            var objectDef = TTObjectDefManager.Instance.ObjectDefs.Values.Where(d => d.Name.ToUpperInvariant() == "BASETREATMENTMATERIAL").FirstOrDefault();
                            BaseTreatmentMaterial baseTreatmentMaterial = (BaseTreatmentMaterial)objectContext.GetObject(ObjectID, objectDef, false);

                            if (baseTreatmentMaterial != null)
                            {
                                if (baseTreatmentMaterial.Material.IsIndividualTrackingRequired != null && baseTreatmentMaterial.Material.IsIndividualTrackingRequired.Value)
                                {
                                    result = "Bildirilmedi";
                                    if (baseTreatmentMaterial.StockActionDetail != null)
                                    {
                                        foreach (StockTransaction trx in baseTreatmentMaterial.StockActionDetail.StockTransactions.Select(string.Empty))
                                        {
                                            if (trx.UTSNotificationDetails.Count() == trx.Amount)
                                            {
                                                foreach (UTSNotificationDetail uTSNotificationDetail in trx.UTSNotificationDetails)
                                                {
                                                    if (uTSNotificationDetail.NotificationID == null)
                                                    {
                                                        return "Bildirilmedi";
                                                    }
                                                    if (uTSNotificationDetail.CurrentStateDefID == UTSNotificationDetail.States.Cancelled)
                                                    {
                                                        return "Bildirilmedi";
                                                    }

                                                    result = "Bildirildi";
                                                }
                                            }
                                            else
                                            {
                                                foreach (UTSNotificationDetail uTSNotificationDetail in trx.UTSNotificationDetails)
                                                {
                                                    if (uTSNotificationDetail.CurrentStateDefID != UTSNotificationDetail.States.Cancelled)
                                                    {
                                                        if (uTSNotificationDetail.NotificationID == null)
                                                        {
                                                            return "Bildirilmedi";
                                                        }
                                                    }
                                                    result = "Bildirildi";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "UTSUseNotification") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Hesaplanmış Miktar
        /// </summary>
        private double? _calculateAmount = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public double CalculateAmount
        {
            get
            {
                try
                {
                    if (_calculateAmount.HasValue)
                        return _calculateAmount.Value;

                    #region CalculateAmount_GetScript    
                    if (Material != null)
                    {
                        if (Material.DivideAmountToPatient == true)
                        {
                            return Amount.Value * Material.DivideTotalAmount.Value;
                        }
                        else
                            return Amount.Value;
                    }
                    else
                    {
                        return Amount.Value;
                    }
                    #endregion CalculateAmount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CalculateAmount") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Hesaplanmış Dağıtım Şekli
        /// </summary>
        private string _calculateDistributionType = string.Empty;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public string CalculateDistributionType
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(_calculateDistributionType) == false)
                        return _calculateDistributionType;

                    #region CalculateDistributionType_GetScript    
                    if (Material != null)
                    {
                        if (Material.DivideAmountToPatient == true)
                        {
                            if (Material.DivideUnitDefinition != null)
                                return Material.DivideUnitDefinition.Name;
                            else
                                return Material.StockCard.DistributionType.DistributionType;

                        }
                        else
                            return Material.StockCard.DistributionType.DistributionType;
                    }
                    else
                    {
                        return string.Empty;
                    }
                    #endregion CalculateDistributionType_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CalculateDistributionType") + " : " + ex.Message, ex);
                }
            }
        }

    }
}