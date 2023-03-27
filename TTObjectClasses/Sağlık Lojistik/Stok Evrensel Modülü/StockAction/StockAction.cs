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
    /// T�m Stok ��lemlerinin Temel s�n�f�d�r. Stok mod�llerinin ana s�n�flar� bu s�n�ftan t�rer.
    /// </summary>
    public abstract partial class StockAction : BaseAction, IAutoDocumentNumber, IStockWorkList, IStockAction
    {
        public partial class GetDocumentNumbersForMaterialClassReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class UnitPriceStockActionOutDetailsReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class StockActionInDetailsReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDocumentSavingRegisterReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetStockCardPresentationReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class StockActionOutDetailsReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class CensusReportNQL_AllDocuments_Class : TTReportNqlObject
        {
        }

        public partial class CensusReportNQL_StockActionInDetailsReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class SearchDocumentRegistryReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetStockActionsCount_Class : TTReportNqlObject
        {
        }

        public partial class GetMaxMKYS_MakbuzNo_Class : TTReportNqlObject
        {
        }

        #region ITTCoreObject Members

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion

        /// <summary>
        /// Ta��n�r Mal Saymanl���
        /// </summary>
        public Guid? ChattelInventoryObjectID
        {
            get
            {
                try
                {
                    #region ChattelInventoryObjectID_GetScript                    
                    Guid? retValue = null;
                    if (Store != null)
                        if (Store is MainStoreDefinition)
                            return ((MainStoreDefinition)Store).Accountancy.ObjectID;
                    if (DestinationStore != null)
                        if (DestinationStore is MainStoreDefinition)
                            return ((MainStoreDefinition)DestinationStore).Accountancy.ObjectID;
                    return retValue;
                    #endregion ChattelInventoryObjectID_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ChattelInventoryObjectID") + " : " + ex.Message, ex);
                }
            }
        }

        public string DocumentRecordLogNumbers
        {
            get
            {
                try
                {
                    #region DocumentRecordLogNumbers_GetScript                    
                    string retValue = string.Empty;
                    IList documentRecordLogs = DocumentRecordLogs.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(DocumentRecordLog.States.Completed));
                    if (documentRecordLogs.Count > 0)
                    {
                        int i = 1;
                        foreach (DocumentRecordLog documentRecordLog in documentRecordLogs)
                        {
                            retValue += documentRecordLog.DocumentRecordLogNumber.Value.ToString();
                            if (i < documentRecordLogs.Count)
                                retValue += " - ";
                            i++;
                        }
                    }

                    return retValue;
                    #endregion DocumentRecordLogNumbers_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DocumentRecordLogNumbers") + " : " + ex.Message, ex);
                }
            }
        }

        public Guid? StockActionObjectID
        {
            get
            {
                try
                {
                    #region StockActionObjectID_GetScript                    
                    return ObjectID;
                    #endregion StockActionObjectID_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "StockActionObjectID") + " : " + ex.Message, ex);
                }
            }
        }

        public string AccountancyName
        {
            get
            {
                try
                {
                    #region AccountancyName_GetScript                    
                    string accName;
                    if (this is IChattelDocumentInputWithAccountancy)
                    {
                        accName = ((IChattelDocumentInputWithAccountancy)this).GetAccountancy().GetName();
                    }
                    else if (this is IChattelDocumentOutputWithAccountancy)
                    {
                        accName = ((IChattelDocumentOutputWithAccountancy)this).GetAccountancy().GetName();
                    }
                    else
                    {
                        accName = null;
                    }

                    return accName;
                    #endregion AccountancyName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "AccountancyName") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert
            bool requiredAccountingTerm = true;
            if (this is SubStoreStockTransfer || this is StockFirstIn || this is StockOut || this is StockPrescriptionOut || this is ResSubStoreConsumption || this is StockIn || this is PurchaseExamination || this is E1 || this is MilitaryDrugProductionProcedure || this is DrugProductionTest || this is SubStoreConsumptionAction || this is IVoucherDistributingDocument || this is IVoucherReturnDocument || this is IProductionConsumptionInfirmaryDocument || this is IDepStoreFirstIn || this is ICensusOrderByStore || this is FreePrescriptionEntry)
                requiredAccountingTerm = false;

            if (this is KSchedule && Store is PharmacySubStoreDefinition)
                requiredAccountingTerm = false;

            if (requiredAccountingTerm && AccountingTerm == null)
            {
                if (Store is MainStoreDefinition && DestinationStore is MainStoreDefinition && !(this is IMainStoreStockTransfer))
                    throw new Exception(SystemMessage.GetMessage(1225));
                MainStoreDefinition mainStore = null;
                if (Store is MainStoreDefinition)
                    mainStore = (MainStoreDefinition)Store;
                if (DestinationStore is MainStoreDefinition)
                    mainStore = (MainStoreDefinition)DestinationStore;
                if (mainStore == null)
                    throw new Exception(SystemMessage.GetMessage(1226));
                AccountingTerm openAccountingTerm = mainStore.Accountancy.GetOpenAccountingTerm();
                AccountingTerm = openAccountingTerm;
                if (AccountingTerm == null)
                    throw new Exception(SystemMessage.GetMessage(1227));
            }

            if (!(this is ReviewAction || this is KSchedule || this is DailyDrugSchedule || this is ISupplyRequest || this is ISupplyRequestPool || this is ICostAction))
            {
                if (StockActionDetails.Count == 0)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M26948", "Stok i�lemi detay listesinde kay�t olmadan i�leme devam edilemez!"));
                }
            }

            SetMKYS_Yil();
            //CheckDetailsWithTheEqualityOfFixedassets();
            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate

            if (!(this is ReviewAction || this is KSchedule || this is DailyDrugSchedule || this is ISupplyRequest || this is ISupplyRequestPool || this is ICostAction))
            {
                if (StockActionDetails.Count == 0)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M26948", "Stok i�lemi detay listesinde kay�t olmadan i�leme devam edilemez!"));
                }
            }

            if (((ITTObject)this).IsNew == false)
            {
                if (this is IDepStoreFirstIn == false)
                    CheckStockCardCardDrawers();
                if (this is IDistributionDepStore == false)
                    CheckDetailsWithTheEqualityOfFixedassets();
            }

            SetMKYS_Yil();
            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            if (AccountingTerm != null)
            {
                string err = string.Empty;
                if (TTObjectClasses.Common.DateDiffV2(Common.DateIntervalEnum.Day, (DateTime)TransactionDate.Value, (DateTime)AccountingTerm.StartDate.Value, false) < 0)
                {
                    err = TTUtils.CultureService.GetText("M26215", "��lem tarihi, Hesap D�nemi Ba�lang�� Tarihi'nden k���k olamaz.\r\n");
                    err += "��lem Tarihi : " + TransactionDate.Value.ToShortDateString() + "\r\n";
                    err += "Ba�lang�� Tarihi : " + AccountingTerm.StartDate.Value.ToShortDateString();
                    throw new Exception(err);
                }

                if (TTObjectClasses.Common.DateDiffV2(Common.DateIntervalEnum.Day, (DateTime)TransactionDate.Value, (DateTime)AccountingTerm.EndDate.Value, false) > 0)
                {
                    err = TTUtils.CultureService.GetText("M26216", "��lem tarihi, Hesap D�nemi Biti� Tarihi'nden b�y�k olamaz.\r\n");
                    err += "��lem Tarihi : " + TransactionDate.Value.ToShortDateString() + "\r\n";
                    err += "Biti� Tarihi : " + AccountingTerm.EndDate.Value.ToShortDateString();
                    throw new Exception(err);
                }



            }
            #endregion PostUpdate
        }

        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
            #region PreTransition_New2Completed
            if (TransactionDate == null)
                TransactionDate = TTObjectDefManager.ServerTime;

            if (this.Store is MainStoreDefinition || this.DestinationStore is MainStoreDefinition)
            {
                string costActionParameter = SystemParameter.GetParameterValue("USECOSTACTION", "FALSE");
                if (costActionParameter == "TRUE")
                {
                    string err = string.Empty;
                    BindingList<CostAction.GetCostActionByDate_Class> costActionList = CostAction.GetCostActionByDate((DateTime)TransactionDate.Value, Store.ObjectID);
                    if (costActionList.Count > 0)
                    {
                        err = "Bu i�lemi tamamlaman�z i�in tamamlanm�� Maliyet Analizi i�lemini iptal etmeniz gerekir. \r\n";
                        err += "��lem Tarihi : " + TransactionDate.Value.ToShortDateString() + "\r\n";
                        err += "Maliyet Analizi ��lem Numaras� : " + costActionList[0].StockActionID.ToString();
                        throw new Exception(err);
                    }

                    int costActionDayParameter = Convert.ToInt32(SystemParameter.GetParameterValue("CHECKCOSTACTIONDAY", "10"));
                    if (TransactionDate.Value.Day > costActionDayParameter)
                    {
                        BindingList<CostAction.GetCostActionByDate_Class> beforeCostActionList = CostAction.GetCostActionByDate((DateTime)TransactionDate.Value.AddMonths(-1), Store.ObjectID);
                        if (costActionList.Count == 0)
                        {
                            string ayIsim = CostAction.AyIsmi(TransactionDate.Value.Month - 1);
                            throw new Exception(ayIsim + " ay�n�n Maliyet Analizi i�lemi yap�lmadan bu belgeyi tamamlayamazs�n�z");
                        }
                    }
                }
            }

            #endregion PreTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
            #region UndoTransition_New2Completed
            throw new Exception(SystemMessage.GetMessage(1229));
            #endregion UndoTransition_New2Completed
        }

        protected void PreTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PreTransition_New2Cancelled
            foreach (StockActionDetail stockActionDetail in StockActionDetails)
                stockActionDetail.Status = StockActionDetailStatusEnum.Cancelled;
            #endregion PreTransition_New2Cancelled
        }

        protected void UndoTransition_New2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Cancelled
            #region UndoTransition_New2Cancelled
            throw new Exception(SystemMessage.GetMessage(1228));
            #endregion UndoTransition_New2Cancelled
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled
            bool requiredAccountingTerm = true;
            if (this is StockOut || this is StockPrescriptionOut || this is StockIn || this is ResSubStoreConsumption || this is PurchaseExamination || this is KSchedule || this is E1 || this is MagistralPreparationAction
                || this is MilitaryDrugProductionProcedure || this is DrugProductionTest || this is SubStoreConsumptionAction || this is IVoucherDistributingDocument || this is IVoucherReturnDocument || this is IProductionConsumptionInfirmaryDocument
                || this is SubStoreStockTransfer || this is StockFirstIn)
                requiredAccountingTerm = false;
            if (requiredAccountingTerm)
            {
                if (AccountingTerm != null) //Bu nesnenin null geldi�i bir hata bilgisi g�nderildi.Buna istinaden bu if else eklendi.
                {
                    if (AccountingTerm.Status == AccountingTermStatusEnum.Close)
                        throw new Exception(SystemMessage.GetMessage(1230));
                }
                else
                {
                    throw new Exception(ObjectDef.Name + " nesnesinde AccountingTerm bilgisi bulunamad�.L�tfen bilgi i�leme haber veriniz!");
                }
            }

            if (this.Store is MainStoreDefinition || this.DestinationStore is MainStoreDefinition)
            {
                string costActionParameter = SystemParameter.GetParameterValue("USECOSTACTION", "FALSE");
                if (costActionParameter == "TRUE")
                {
                    string err = string.Empty;
                    BindingList<CostAction.GetCostActionByDate_Class> costActionList = CostAction.GetCostActionByDate((DateTime)TransactionDate.Value, Store.ObjectID);
                    if (costActionList.Count > 0)
                    {
                        err = "Bu i�lemi iptal etmeniz i�in tamamlanm�� Maliyet Analizi i�lemini iptal etmeniz gerekir. \r\n";
                        err += "��lem Tarihi : " + TransactionDate.Value.ToShortDateString() + "\r\n";
                        err += "Maliyet Analizi ��lem Numaras� : " + costActionList[0].StockActionID.ToString();
                        throw new Exception(err);
                    }
                }
            }

            foreach (StockActionDetail stockActionDetail in StockActionDetails)
                stockActionDetail.Status = StockActionDetailStatusEnum.Cancelled;

            string errDoc = string.Empty;
            errDoc = "MKYS Silinmemi� ��lemler Mevcuttur. �nce Bu ��lemleri Silmeniz Gerekmektedir.";
            foreach (DocumentRecordLog doc in this.DocumentRecordLogs.Select(string.Empty))
            {
                if (doc.ReceiptNumber != null)
                {
                    errDoc += doc.ReceiptNumber.ToString();
                    throw new Exception(errDoc);
                }
            }

            //TransactionDate = TTObjectDefManager.ServerTime;
            #endregion PreTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            if (!(this is IMainStoreStockTransfer || this is IExtendExpirationDate || this is IChattelDocumentInputWithAccountancy)) //TRANSFER ��LEM�NDE GER� ALINMASI GEREKL�YOR!!!!!!
                throw new Exception(SystemMessage.GetMessage(1228));
            #endregion UndoTransition_Completed2Cancelled
        }

        #region Methods
        #region IStockAction Members
        IStore IStockAction.GetStore()
        {
            return (IStore)Store;
        }

        IStore IStockAction.GetDestinationStore()
        {
            return (IStore)DestinationStore;
        }

        IAccountingTerm IStockAction.GetAccountingTerm()
        {
            return (IAccountingTerm)AccountingTerm;
        }

        public string GetRegistrationNumber()
        {
            return RegistrationNumber;
        }

        public string GetSequenceNumber()
        {
            return SequenceNumber;
        }

        public DateTime? GetTransactionDate()
        {
            return TransactionDate;
        }

        public TTSequence GetStockActionID()
        {
            return StockActionID;
        }
        #endregion

        #region IAutoDocumentNumber Members
        public Store GetStore()
        {
            return Store;
        }

        public Store GetDestinationStore()
        {
            return DestinationStore;
        }

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public TTSequence GetRegistrationNumberSeq()
        {
            return RegistrationNumberSeq;
        }

        public TTSequence GetSequenceNumberSeq()
        {
            return SequenceNumberSeq;
        }


        #endregion

        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                StockActionID.GetNextValue();
            }
        }

        public static List<DistributionDocumentMaterial> AutoDistributionCreate(Store store, Store destinationStore)
        {
            TTObjectContext context = new TTObjectContext(false);
            List<DistributionDocumentMaterial> newAutoDistributionCreate = new List<DistributionDocumentMaterial>();
            BindingList<Stock> stocks = destinationStore.Stocks.Select(" INHELD <= MINIMUMLEVEL AND MINIMUMLEVEL <> '0' AND MAXIMUMLEVEL <> '0' ");
            List<Guid> resMaterial = new List<Guid>();
            List<Stock> requestMaterials = new List<Stock>();
            foreach (Stock s in stocks)
            {
                BindingList<Stock> dests = store.Stocks.Select("MATERIAL = '" + s.Material.ObjectID + "'");
                foreach (Stock d in dests)
                {
                    if (s.Material == d.Material && d.Inheld > 0)
                    {
                        resMaterial.Add(s.Material.ObjectID);
                        requestMaterials.Add(s);
                    }
                }

                BindingList<DistributionDocumentMaterial.GetExistAutoDistributionDoc_Class> allReadyrequestedList = DistributionDocumentMaterial.GetExistAutoDistributionDoc(destinationStore.ObjectID, resMaterial);
                foreach (DistributionDocumentMaterial.GetExistAutoDistributionDoc_Class differenceMaterial in allReadyrequestedList)
                {
                    foreach (Stock st in requestMaterials)
                    {
                        if (st.Material.ObjectID == differenceMaterial.Material.Value)
                        {
                            requestMaterials.Remove(st);
                            if (requestMaterials.Count == 0)
                                break;
                        }
                    }
                }
            }

            foreach (Stock autoDistribution in requestMaterials)
            {
                DistributionDocumentMaterial mat = new DistributionDocumentMaterial(context);
                mat.Material = autoDistribution.Material;
                mat.AcceptedAmount = autoDistribution.MaximumLevel - autoDistribution.Inheld;
                newAutoDistributionCreate.Add(mat);
            }

            return newAutoDistributionCreate;
            //if(distributionDocument.DistributionDocumentMaterials.Count != 0)
            //distributionDocument.IsAutoDistribution = true;
        }

        public static MkysServis.EGirisStokHareketTurID GetMKYSStokHareketTurEnumFromTedarik(MkysServis.ETedarikTurID tedarikTuru)
        {
            //return MkysServis.EGirisStokHareketTurID.grGarantiVeyaSigortaKApsamindaGiris;
            switch (tedarikTuru)
            {
                case MkysServis.ETedarikTurID.satinalma:
                    return MkysServis.EGirisStokHareketTurID.grSatinAlinanMalzemeninGirisi;
                case MkysServis.ETedarikTurID.takas:
                    return MkysServis.EGirisStokHareketTurID.grTakas;
                case MkysServis.ETedarikTurID.duzeltme:
                    return MkysServis.EGirisStokHareketTurID.grDuzetme;
                case MkysServis.ETedarikTurID.icImkanlarlaUretim:
                    return MkysServis.EGirisStokHareketTurID.grIcImkanlarlaUretilen;
                case MkysServis.ETedarikTurID.tasfiyeIdaresindenEdinilen:
                    return MkysServis.EGirisStokHareketTurID.grTasfiyeIdaresindenEdinilen;
                case MkysServis.ETedarikTurID.sayimFazlasi:
                    return MkysServis.EGirisStokHareketTurID.grSayimFazlasi;
                case MkysServis.ETedarikTurID.iadeEdilen:
                    return MkysServis.EGirisStokHareketTurID.grBirimlerdenIade;
                case MkysServis.ETedarikTurID.devirAlinan:
                    return MkysServis.EGirisStokHareketTurID.grBirimlerdenGelenMalzemeGirisi;
                case MkysServis.ETedarikTurID.bagisVeYardim:
                    return MkysServis.EGirisStokHareketTurID.grBagisHibe;
                case MkysServis.ETedarikTurID.temelSagliktanDevir:
                    return MkysServis.EGirisStokHareketTurID.grTemelSagliktanDevir;
                case MkysServis.ETedarikTurID.XXXXXXBirlesmesindenDevir:
                    return MkysServis.EGirisStokHareketTurID.grXXXXXXBirlesmesindenDevir;
                case MkysServis.ETedarikTurID.koordinatorXXXXXXdenDevir:
                    return MkysServis.EGirisStokHareketTurID.grKoordinatorXXXXXXdenDevirAlinan;
                case MkysServis.ETedarikTurID.stokFazlasiDevir:
                    return MkysServis.EGirisStokHareketTurID.grStokFazlasiGirisi;
                case MkysServis.ETedarikTurID.ihtiyacFazlasiDevir:
                    return MkysServis.EGirisStokHareketTurID.grIhtiyacFazlasiGirisi;
                case MkysServis.ETedarikTurID.ambarlarArasiDevir:
                    return MkysServis.EGirisStokHareketTurID.grAmbarlarArasiDevir;
                case MkysServis.ETedarikTurID.acilisFiiliSayim:
                    return MkysServis.EGirisStokHareketTurID.grYilSonuDevri;
                case MkysServis.ETedarikTurID.novartisHibe:
                    return MkysServis.EGirisStokHareketTurID.grNovartisHibe;
                case MkysServis.ETedarikTurID.ilOzelIdaresindenDevirAlinan:
                    return MkysServis.EGirisStokHareketTurID.grilOzelIdaresindenDevir;
                case MkysServis.ETedarikTurID.universiteXXXXXXndenIhtiyacFazlasiDevir:
                    return MkysServis.EGirisStokHareketTurID.grUnvXXXXXXndenIhtiyacFazlasiDevirGirisi;
                case MkysServis.ETedarikTurID.universiteXXXXXXndenStokFazlasiDevir:
                    return MkysServis.EGirisStokHareketTurID.grUnvXXXXXXndenStokFazlasiDevirGirisi;
                //case MkysServis.ETedarikTurID.KHKdanDevirAlinan:  //20
                //    return MkysServis.EGirisStokHareketTurID.; // ????
                case MkysServis.ETedarikTurID.MiadUzatimi: //21
                    return MkysServis.EGirisStokHareketTurID.grMiadUzatimiGiris;
                //case MkysServis.ETedarikTurID.bagliBirliktenDevir:  //22
                //    return MkysServis.EGirisStokHareketTurID. ???????????????????????????
                case MkysServis.ETedarikTurID.birlikSaglikTesisineDevir: //23
                    return MkysServis.EGirisStokHareketTurID.grBirlikSaglikTesisineDevir;
                case MkysServis.ETedarikTurID.bagliSaglikTsisisndenDevir:  //24
                    return MkysServis.EGirisStokHareketTurID.grBirlikSaglikTesisineDevir;
                case MkysServis.ETedarikTurID.garantiSigortaKapsamindaGiris: //25
                    return MkysServis.EGirisStokHareketTurID.grGarantiVeyaSigortaKApsamindaGiris;
                //case MkysServis.ETedarikTurID.XXXXXXAndidotAntidoksinGiris: //26
                //    return MkysServis.EGirisStokHareketTurID.grSatinalinanKamuOZelXXXXXXAntidotAntidoksinCikis;
                case MkysServis.ETedarikTurID.devirKurumlarArasiDevir: //27
                    return MkysServis.EGirisStokHareketTurID.grDevirKurumlarArasiDevirGirisi;
                case MkysServis.ETedarikTurID.devirDigerKamuIdarelerineDevirGiris: //28
                    return MkysServis.EGirisStokHareketTurID.grDevirDigerKamuIdarelerineDevirGiris;
                case MkysServis.ETedarikTurID.devir667KHKDevir: //29
                    return MkysServis.EGirisStokHareketTurID.gr667KHKDevir;
                case MkysServis.ETedarikTurID.devir669KHKDevir: //30
                    return MkysServis.EGirisStokHareketTurID.gr669KHKDevir;
                case MkysServis.ETedarikTurID.devirTedarikPaylasim:
                    return MkysServis.EGirisStokHareketTurID.grTedarikPaylasim;
                case MkysServis.ETedarikTurID.hudutSahillerindenDevir:
                    return MkysServis.EGirisStokHareketTurID.grHudutSahillerindenDevirGirisi;
                case MkysServis.ETedarikTurID.hibeProje:
                    return MkysServis.EGirisStokHareketTurID.grHibeProje;
                case MkysServis.ETedarikTurID.kamuOzelIsBirligi6428SayiliKanun:
                    return MkysServis.EGirisStokHareketTurID.grKamuOzelIsBirligi6428SayiliKanun;
                // case MkysServis.ETedarikTurID.devir694KHKDevir:
                //  return MkysServis.EGirisStokHareketTurID.grDevir.devir694KHKDevir;
                case MkysServis.ETedarikTurID.hibeSihhatProje:
                    return MkysServis.EGirisStokHareketTurID.grHibeSihhatProje;
                case MkysServis.ETedarikTurID.devirMucbirDevirTedarikPaylasim:
                    return MkysServis.EGirisStokHareketTurID.grMucbirDevirTedarikPaylasim;
                case MkysServis.ETedarikTurID.pgd:
                    return MkysServis.EGirisStokHareketTurID.grPgdGirisi;
                case MkysServis.ETedarikTurID.devirSaglikMarketDevir:
                    return MkysServis.EGirisStokHareketTurID.grDevirSaglikMarketDevir;
                case MkysServis.ETedarikTurID.devirGeciciTahsisDevir:
                    return MkysServis.EGirisStokHareketTurID.grDevirSaglikMarketDevir;
                case MkysServis.ETedarikTurID.hibeBarisGucu:
                    return MkysServis.EGirisStokHareketTurID.grHibeBarisGucu;
                case MkysServis.ETedarikTurID.sgkTarafindanTedarikEdilenUrun:
                    return MkysServis.EGirisStokHareketTurID.grSgkTarafindanTedarikEdilenUrun;
                case MkysServis.ETedarikTurID.covid19Satinalma:
                    return MkysServis.EGirisStokHareketTurID.grCovid19SatinalmaGiris;
                case MkysServis.ETedarikTurID.devirCovid19DevirAlinan:
                    return MkysServis.EGirisStokHareketTurID.grDevirCovid19DevirAlinan;


            }

            throw new Exception("Ge�ersiz tedarik t�r� - " + tedarikTuru.ToString());
        }

        #region UTS_Methodlar�
        public static string UTSMakeDeliveryNotification(StockTransaction stockTransaction)
        {
            string sonuc = "";
            bool basarili = true;

            UTSServis.VermeBildirimiIstek vermeBildirimiIstek = new UTSServis.VermeBildirimiIstek();
            vermeBildirimiIstek.ADT = stockTransaction.Amount;
            vermeBildirimiIstek.LNO = stockTransaction.LotNo;
            vermeBildirimiIstek.SNO = stockTransaction.SerialNo;
            vermeBildirimiIstek.BNO = stockTransaction.IncomingDeliveryNotifID;
            vermeBildirimiIstek.UNO = stockTransaction.Stock.Material.Barcode;

            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
            try
            {
                UTSServis.BildirimCevap VermeBildirimCevap = UTSServis.WebMethods.VermeBildirimiSync(new Guid(siteID), vermeBildirimiIstek);
                sonuc = VermeBildirimCevap.MSJ[0].MET;
            }
            catch (Exception e)
            {
                sonuc = e.ToString();
                basarili = false;
            }
            if (basarili)
            {
                using (TTObjectContext context = new TTObjectContext(false))
                {
                    foreach (UTSNotificationDetail item in stockTransaction.UTSNotificationDetails.Select(string.Empty))
                    {
                        item.CurrentStateDefID = UTSNotificationDetail.States.Cancelled;
                    }
                }
            }
            return sonuc;
        }

        #endregion

        #region XXXXXX_Methodlar�
        public static string XXXXXXGetMuayeneKabul_TS(StockAction stockAction)
        {
            return stockAction.XXXXXXGetMuayeneKabul();
        }

        public string XXXXXXGetMuayeneKabul()
        {
            string SonucMesaj = string.Empty;
            TTObjectContext objectContext = new TTObjectContext(false);
            StockAction stockAction = null;
            stockAction = (StockAction)objectContext.GetObject(ObjectID, ObjectDef);
            string BolumId = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPBOLUMID", "");
            string ehipWsUsername = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI", "");
            string ehipWsPassword = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI", "");
            XXXXXXTasinirMal.IslemSonuc sonuc = XXXXXXTasinirMal.WebMethods.GetEhipWsEntegreKeyByBolumIdSync(Sites.SiteLocalHost, BolumId, ehipWsUsername, ehipWsPassword);
            XXXXXXTasinirMal.MuayeneAramaKriterInfoWS muayeneKR = new XXXXXXTasinirMal.MuayeneAramaKriterInfoWS();
            muayeneKR.MkysDepoKodu = ((MainStoreDefinition)Store).StoreRecordNo.Value.ToString();
            // muayeneKR.IrsaliyeNo = 
            //XXXXXXTasinirMal.MuayeneKabulInfoWS[] kabulInfoList = XXXXXXTasinirMal.WebMethods.MuayeneKabulGetSync(Sites.SiteLocalHost, sonuc.Mesaj, muayeneKR).ToArray();
            return SonucMesaj;
        }

        #endregion XXXXXX_Methodlar�
        #region MKYS_Input_Message
        //public static string SendMKYSForInputDocumentTS(StockAction stockAction)
        //{
        //    return stockAction.SendMKYSForInputDocument();
        //}

        public string SendMKYSForActionInfoCorrection(string mkysPwd, Guid baseChattelObjectID)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            StockAction stockAction = null;
            stockAction = (StockAction)objectContext.GetObject(baseChattelObjectID, ObjectDef);

            MkysServis.ayniyatMakbuzuUpdateItem ayniyatMakbuzuUpdateItem = new MkysServis.ayniyatMakbuzuUpdateItem();
            if (stockAction.MKYS_EAlimYontemi != null)
                ayniyatMakbuzuUpdateItem.alimYontemi = (MkysServis.EAlimYontemiID)(int)stockAction.MKYS_EAlimYontemi.Value;

            if (stockAction.DocumentRecordLogNumbers.Length > 0)
                ayniyatMakbuzuUpdateItem.ayniyatMakbuzID = ((DocumentRecordLog)stockAction.DocumentRecordLogs.FirstOrDefault()).ReceiptNumber.Value;

            if (stockAction is IChattelDocumentWithPurchase) // SATINALMA YOLUYLA G�R��
            {
                ayniyatMakbuzuUpdateItem.ihaleTarihi = ((IChattelDocumentWithPurchase)stockAction).GetAuctionDate();
                ayniyatMakbuzuUpdateItem.ihaleKayitNo = ((IChattelDocumentWithPurchase)stockAction).GetRegistrationAuctionNo();
            }

            ayniyatMakbuzuUpdateItem.malzemeGrubu = (MkysServis.EMalzemeGrupID)(int)stockAction.MKYS_EMalzemeGrup.Value;

            List<MkysServis.ayniyatMakbuzuUpdateItem> makbuz = new List<MkysServis.ayniyatMakbuzuUpdateItem>();
            makbuz.Add(ayniyatMakbuzuUpdateItem);

            MkysServis.mkysSonuc mkysSonuc = MkysServis.WebMethods.makbuzUpdateSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, mkysPwd, makbuz.ToArray());
            if (mkysSonuc.basariDurumu == true)
            {
                ((DocumentRecordLog)stockAction.DocumentRecordLogs.FirstOrDefault()).ReceiptNumber = mkysSonuc.islemKayitNo;
                objectContext.Save();
                objectContext.Dispose();
                return mkysSonuc.islemKayitNo + " numaras� ile " + mkysSonuc.mesaj;
            }
            else
            {
                return "Hatal� i�lem yap�lm��t�r";
            }
        }


        public string SendMKYSForInputDocument(string mkysPwd, string MuaneNo = "", DateTime? MauaneTarihi = null)
        {
            string SonucMesaj = string.Empty;
            try
            {
                bool isFailed = true;
                TTObjectContext objectContext = new TTObjectContext(false);
                StockAction stockAction = null;
                stockAction = (StockAction)objectContext.GetObject(ObjectID, ObjectDef);
                int depoKayitNo;
                if (stockAction is ReturningDocument || stockAction is IMainStoreStockTransfer)
                {
                    depoKayitNo = ((MainStoreDefinition)(stockAction.DestinationStore)).StoreRecordNo.Value;
                }
                else
                    depoKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo.Value;

                //MKYS den depoYetkiKontrolu yapiliyor
                string depoYetkiKontrolSonucMsg = MKYSKullaniciDepoYetkiVarMiSonuc(depoKayitNo, Common.CurrentResource.MkysUserName);
                if (depoYetkiKontrolSonucMsg != "0")
                    SonucMesaj = depoYetkiKontrolSonucMsg;


                var makbuzDetayGirisListe = new List<MkysServis.makbuzDetayGirisItem>();
                Dictionary<Guid, StockTransaction> tranactionToCompareMKYS = new Dictionary<Guid, StockTransaction>();
                Dictionary<MKYS_EButceTurEnum, List<StockTransaction>> trxs = new Dictionary<MKYS_EButceTurEnum, List<StockTransaction>>();
                if (stockAction.IsPTSAction == true)
                {
                    StockTransaction sampleTRX = stockAction.StockActionInDetails[0].StockTransactions.Select(string.Empty)[0];
                    List<StockTransaction> sampleTrxList = new List<StockTransaction>();
                    sampleTrxList.Add(sampleTRX);
                    trxs.Add(sampleTRX.BudgetTypeDefinition.MKYS_Butce.Value, sampleTrxList);
                }
                else
                {
                    foreach (StockActionDetail actionDetailCompare in stockAction.StockActionDetails)
                    {
                        foreach (StockTransaction stockTransaction in actionDetailCompare.StockTransactions.Select(" INOUT = 1 "))
                        {
                            tranactionToCompareMKYS.Add(stockTransaction.ObjectID, stockTransaction);
                        }
                    }

                    foreach (StockActionDetail actionDetail in stockAction.StockActionDetails)
                    {
                        foreach (StockTransaction stockTransaction in actionDetail.StockTransactions.Select(" INOUT = 1 "))
                        {

                            if (stockTransaction.CurrentStateDefID != StockTransaction.States.Cancelled)
                            {

                                if (trxs.ContainsKey((MKYS_EButceTurEnum)stockTransaction.BudgetTypeDefinition.MKYS_Butce))
                                {
                                    trxs[(MKYS_EButceTurEnum)stockTransaction.BudgetTypeDefinition.MKYS_Butce].Add(stockTransaction);
                                }
                                else
                                {
                                    List<StockTransaction> trx = new List<TTObjectClasses.StockTransaction>();
                                    trx.Add(stockTransaction);
                                    trxs.Add((MKYS_EButceTurEnum)stockTransaction.BudgetTypeDefinition.MKYS_Butce, trx);
                                }

                            }
                        }
                    }
                }

                foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockTransaction>> transactions in trxs)
                {
                    MkysServis.makbuzInsertGirisItem girisItem = new MkysServis.makbuzInsertGirisItem();
                    girisItem.islemTuru = MkysServis.EGirisIslemTuru.giris;
                    if (stockAction.MKYS_ETedarikTuru != null)
                        girisItem.tedarikTurID = (MkysServis.ETedarikTurID)(int)stockAction.MKYS_ETedarikTuru.Value;
                    if (stockAction.MKYS_EMalzemeGrup != null)
                        girisItem.malzemeGrupID = (MkysServis.EMalzemeGrupID)(int)stockAction.MKYS_EMalzemeGrup.Value;
                    girisItem.stokHareketTurID = GetMKYSStokHareketTurEnumFromTedarik(girisItem.tedarikTurID);
                    DocumentRecordLog currentLog = null;
                    foreach (DocumentRecordLog log in stockAction.DocumentRecordLogs)
                    {
                        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In && log.BudgeType == transactions.Key)
                        {
                            girisItem.butceTurID = (MkysServis.EButceTurID)(int)log.BudgeType.Value;
                            girisItem.makbuzNo = Int32.Parse(log.DocumentRecordLogNumber.Value.ToString());
                            girisItem.makbuzTarihi = (DateTime)log.DocumentDateTime;
                            currentLog = log;
                            break;
                        }
                    }

                    if (stockAction.MKYS_MuayeneNo == null)
                    {
                        girisItem.muayeneNo = MuaneNo;
                        girisItem.muayeneTarihi = MauaneTarihi;
                    }
                    else
                        girisItem.muayeneNo = stockAction.MKYS_MuayeneNo;

                    girisItem.dayanagiBelgeNo = stockAction.StockActionID.Value.ToString(); //dayanak numaras� i�lem numaras� olacak eski hali -> this.BaseNumber;
                    girisItem.dayanagiBelgeTarihi = stockAction.TransactionDate; //dayanak tarihi i�lem tarihi olcak eski hali -> this.BaseDateTime.Value;

                    //depoKayitNo yetki kontrolu isinden dolayi yukari tasindi
                    //if (stockAction is ReturningDocument || stockAction is IMainStoreStockTransfer)
                    //{
                    //    girisItem.depoKayitNo = ((MainStoreDefinition)(stockAction.DestinationStore)).StoreRecordNo.Value;
                    //}
                    //else
                    //    girisItem.depoKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo.Value;

                    girisItem.depoKayitNo = depoKayitNo;
                    girisItem.teslimAlan = MKYS_TeslimAlan;
                    girisItem.teslimEden = MKYS_TeslimEden;
                    if (stockAction.MKYS_EAlimYontemi != null)
                        girisItem.alimYontemiID = (MkysServis.EAlimYontemiID)(int)stockAction.MKYS_EAlimYontemi.Value;
                    girisItem.hbysID = SystemParameter.GetParameterValue("MKYS_HBYS_ID", "Atlas");
                    if (stockAction is IChattelDocumentWithPurchase) // SATINALMA YOLUYLA G�R��
                    {
                        girisItem.muayeneTarihi = ((IChattelDocumentWithPurchase)stockAction).GetExaminationReportDate();
                        girisItem.fisAciklama = "SATINALMA YOLUYLA G�R��";
                        girisItem.geldigiYer = stockAction.AccountancyName;
                        girisItem.ihaleTarihi = ((IChattelDocumentWithPurchase)stockAction).GetAuctionDate();
                        girisItem.ihaleKayitNo = ((IChattelDocumentWithPurchase)stockAction).GetRegistrationAuctionNo();

                        if (((IChattelDocumentWithPurchase)stockAction).GetSupplier() != null && ((IChattelDocumentWithPurchase)stockAction).GetSupplier().GetTaxNo() != null)
                        {
                            girisItem.firmaVergiKayitNo = ((IChattelDocumentWithPurchase)stockAction).GetSupplier().GetTaxNo().ToString();
                        }
                        else
                        {
                            throw new Exception("Vergi Numaras� Alan� Bo� oldu�u i�in MKYS G�nderimi Tamamlanamad�.");
                        }

                        if (((IChattelDocumentWithPurchase)this).GetWaybill() != null)
                            girisItem.dayanagiBelgeNo = ((IChattelDocumentWithPurchase)this).GetWaybill();
                        if (((IChattelDocumentWithPurchase)this).GetWaybillDate() != null)
                            girisItem.dayanagiBelgeTarihi = ((IChattelDocumentWithPurchase)this).GetWaybillDate();
                    }

                    if (stockAction is IChattelDocumentInputWithAccountancy) // TA�INIR MAL G�R��
                    {
                        girisItem.muayeneTarihi = null;
                        girisItem.fisAciklama = "TA�INIR MAL G�R��";
                        if (!String.IsNullOrEmpty(((IChattelDocumentInputWithAccountancy)stockAction).GetAccountancy().GetAccountancyNO()))
                        {
                            try
                            {
                                girisItem.gonderenBirimKayitNo = Int32.Parse(((IChattelDocumentInputWithAccountancy)stockAction).GetAccountancy().GetAccountancyNO());
                            }
                            catch (Exception e)
                            {
                                throw new Exception(((IChattelDocumentInputWithAccountancy)stockAction).GetAccountancy().GetName() + "i�in g�nderen birim kay�t No, Say�sal bir de�er de�il.", e);
                            }
                        }
                        girisItem.geldigiYer = ((IChattelDocumentInputWithAccountancy)stockAction).GetAccountancy().GetName();
                        girisItem.ihaleTarihi = null;
                        girisItem.ihaleKayitNo = "";
                        if (((IChattelDocumentInputWithAccountancy)this).GetWaybill() != null)
                            girisItem.dayanagiBelgeNo = ((IChattelDocumentInputWithAccountancy)this).GetWaybill();
                        if (((IChattelDocumentInputWithAccountancy)this).GetWaybillDate() != null)
                            girisItem.dayanagiBelgeTarihi = ((IChattelDocumentInputWithAccountancy)this).GetWaybillDate();
                        if (((MainStoreDefinition)stockAction.Store).GoodsResponsible != null && ((MainStoreDefinition)stockAction.Store).GoodsResponsible.UniqueNo != null)
                            girisItem.firmaVergiKayitNo = ((MainStoreDefinition)stockAction.Store).GoodsResponsible.UniqueNo;
                        if (((IChattelDocumentInputWithAccountancy)this).GetStockActionID() != null)
                        {
                            girisItem.teslimAlan = MKYS_TeslimAlan;
                            girisItem.teslimEden = MKYS_TeslimEden;
                        }

                    }

                    if (stockAction is ReturningDocument) //�ADE BELGES� G�R��
                    {
                        girisItem.muayeneTarihi = null;
                        girisItem.fisAciklama = "�ADE BELGES� G�R��";
                        girisItem.geldigiYer = stockAction.Store.Name;
                        girisItem.ihaleTarihi = null;
                        girisItem.ihaleKayitNo = "";
                        girisItem.firmaVergiKayitNo = "";
                    }

                    if (stockAction is StockIn) //�ADE �LA� G�R��
                    {
                        stockAction.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.iadeEdilen;
                        stockAction.MKYS_EMalzemeGrup = MKYS_EMalzemeGrupEnum.ilac;
                        if (stockAction.MKYS_ETedarikTuru != null)
                            girisItem.tedarikTurID = (MkysServis.ETedarikTurID)(int)stockAction.MKYS_ETedarikTuru.Value;
                        if (stockAction.MKYS_EMalzemeGrup != null)
                            girisItem.malzemeGrupID = (MkysServis.EMalzemeGrupID)(int)stockAction.MKYS_EMalzemeGrup.Value;
                        girisItem.stokHareketTurID = GetMKYSStokHareketTurEnumFromTedarik(girisItem.tedarikTurID);

                        girisItem.muayeneTarihi = null;
                        girisItem.fisAciklama = "�LA� �ADE BELGES� G�R��";
                        girisItem.geldigiYer = stockAction.DestinationStore.Name;
                        girisItem.ihaleTarihi = null;
                        girisItem.ihaleKayitNo = "";
                        if (((MainStoreDefinition)stockAction.Store).GoodsResponsible != null && ((MainStoreDefinition)stockAction.Store).GoodsResponsible.UniqueNo != null)
                            girisItem.firmaVergiKayitNo = ((MainStoreDefinition)stockAction.Store).GoodsResponsible.UniqueNo;
                    }

                    if (stockAction is IGrantMaterial) //BA�I� YARDIM �LE G�R��
                    {
                        girisItem.teslimEden = ((IGrantMaterial)stockAction).GetMaterialGranttedBy();
                        girisItem.geldigiYer = ((IGrantMaterial)stockAction).GetMaterialGranttedBy();
                        girisItem.fisAciklama = "BA�I� YARDIM �LE G�R��";
                        girisItem.ihaleTarihi = null;
                        girisItem.ihaleKayitNo = "";
                        girisItem.firmaVergiKayitNo = ((IGrantMaterial)stockAction).GetGranttedByUniqNo();
                        girisItem.muayeneTarihi = null;
                    }

                    if (stockAction is IExtendExpDateIn) //MIAD G�NCELLEME G�R��
                    {
                        girisItem.teslimEden = stockAction.Store.Name;
                        girisItem.geldigiYer = stockAction.Store.Name;
                        girisItem.fisAciklama = "M�AD G�NCELLEME G�R��";
                        girisItem.ihaleTarihi = null;
                        girisItem.ihaleKayitNo = "";
                        girisItem.firmaVergiKayitNo = Common.CurrentResource.UniqueNo.ToString();
                        girisItem.muayeneTarihi = null;
                    }

                    if (stockAction is IMainStoreStockTransfer) //AMBARLAR ARASI G�R��
                    {
                        girisItem.geldigiYer = stockAction.Store.Name;
                        girisItem.fisAciklama = "AMBARLAR ARASI DEV�R G�R��";
                        girisItem.gonderenBirimKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo.Value;
                        girisItem.ihaleTarihi = null;
                        girisItem.ihaleKayitNo = "";
                        girisItem.firmaVergiKayitNo = "";
                        girisItem.muayeneTarihi = null;
                    }

                    if (stockAction is IGeneralProductionAction) //Genel �retim ��lemi //GENEL �RET�M ���N �ZEL DURUM VAR TEK MALZEME G�R�� YAPILACAKTIR.!!!
                    {
                        girisItem.geldigiYer = stockAction.Store.Name;
                        girisItem.fisAciklama = "GENEL �RET�M ��LEM�";
                        girisItem.gonderenBirimKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo.Value;
                        girisItem.ihaleTarihi = null;
                        girisItem.ihaleKayitNo = "";
                        girisItem.firmaVergiKayitNo = "";
                        girisItem.muayeneTarihi = null;
                    }

                    if (stockAction is CensusFixed) //Say�m D�zeltme
                    {
                        girisItem.geldigiYer = stockAction.Store.Name;
                        girisItem.fisAciklama = "SAYIM D�ZELTME ��LEM�";
                        girisItem.gonderenBirimKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo.Value;
                        girisItem.ihaleTarihi = null;
                        girisItem.ihaleKayitNo = "";
                        girisItem.firmaVergiKayitNo = "";
                        girisItem.muayeneTarihi = null;
                    }


                    if (stockAction.IsPTSAction == true)
                    {
                        foreach (PTSStockActionDetail pts in this.PTSStockActionDetails.Select(string.Empty))
                        {
                            MkysServis.makbuzDetayGirisItem makbuzDetayItem = new MkysServis.makbuzDetayGirisItem();
                            if (pts.Material.MkysMalzemeKodu != null)
                                makbuzDetayItem.malzemeKayitID = pts.Material.MkysMalzemeKodu.Value;
                            else
                                SonucMesaj += pts.Material.Name + " isimli malzemenin mkys malzeme kodu tan�mlanmam��t�r! ";
                            makbuzDetayItem.miktar = (decimal)pts.Amount;
                            makbuzDetayItem.olcuBirimiID = (MkysServis.EOlcuBirimID)(int)pts.Material.StockCard.DistributionType.MKYS_DistType;
                            if (stockAction is IChattelDocumentWithPurchase) // SATINALMA YOLUYLA G�R��
                            {
                                IChattelDocumentDetailWithPurchase interfaceChattelDet = (IChattelDocumentDetailWithPurchase)pts.StockActionDetails[0];
                                IStockActionDetailIn interfaceStockAction = (IStockActionDetailIn)pts.StockActionDetails[0];
                                makbuzDetayItem.vergisizBirimFiyat = interfaceChattelDet.GetUnitPriceWithOutVat().Value;
                                makbuzDetayItem.vergiliBirimFiyat = (decimal)interfaceStockAction.GetUnitPrice();
                                makbuzDetayItem.edinimYili = pts.RetrievalYear;
                                makbuzDetayItem.kdvOrani = pts.VatRate;
                                makbuzDetayItem.indirimOrani = interfaceStockAction.GetDiscountRate();
                                makbuzDetayItem.indirimTutari = makbuzDetayItem.indirimOrani * (decimal)pts.Amount / 100;
                                makbuzDetayItem.edinimYili = pts.RetrievalYear;
                            }
                            if (stockAction is IChattelDocumentInputWithAccountancy) // SATINALMA YOLUYLA G�R��
                            {
                                IStockActionDetailIn interfaceStockAction = (IStockActionDetailIn)pts.StockActionDetails[0];

                                makbuzDetayItem.vergisizBirimFiyat = interfaceStockAction.GetNotDiscountedUnitPrice().Value;
                                makbuzDetayItem.vergiliBirimFiyat = (decimal)interfaceStockAction.GetUnitPrice();
                                makbuzDetayItem.edinimYili = pts.RetrievalYear;
                                makbuzDetayItem.kdvOrani = pts.VatRate;
                                makbuzDetayItem.indirimOrani = interfaceStockAction.GetDiscountRate();
                                makbuzDetayItem.indirimTutari = makbuzDetayItem.indirimOrani * (decimal)pts.Amount / 100;
                                makbuzDetayItem.edinimYili = pts.RetrievalYear;
                            }
                            if (stockAction is ReturningDocument) //�ADE BELGES� G�R��
                            {
                                makbuzDetayItem.vergisizBirimFiyat = (decimal)pts.UnitPrice;
                                makbuzDetayItem.vergiliBirimFiyat = (decimal)pts.UnitPrice;
                                makbuzDetayItem.kdvOrani = 0;
                                makbuzDetayItem.edinimYili = pts.RetrievalYear;
                            }

                            if (stockAction is StockIn) //�ADE �LA� G�R��
                            {
                                makbuzDetayItem.vergisizBirimFiyat = (decimal)pts.UnitPrice;
                                makbuzDetayItem.vergiliBirimFiyat = (decimal)pts.UnitPrice;
                                makbuzDetayItem.kdvOrani = 0;
                                makbuzDetayItem.edinimYili = pts.RetrievalYear;
                            }

                            if (stockAction is IGrantMaterial) //BA�I� YARDIM �LE G�R��
                            {
                                makbuzDetayItem.vergisizBirimFiyat = (((IChattelDocumentDetailWithPurchase)pts.StockActionDetails[0])).GetUnitPriceWithOutVat().Value;
                                makbuzDetayItem.vergiliBirimFiyat = (decimal)pts.UnitPrice;
                                makbuzDetayItem.edinimYili = pts.RetrievalYear;
                            }

                            if (stockAction is IExtendExpDateIn) //MIAD G�NCELLEME G�R��
                            {
                                makbuzDetayItem.vergisizBirimFiyat = (decimal)pts.UnitPrice;
                                makbuzDetayItem.vergiliBirimFiyat = (decimal)pts.UnitPrice;
                                makbuzDetayItem.edinimYili = pts.RetrievalYear;
                            }

                            if (pts.ProductionDate != null)
                            {
                                makbuzDetayItem.uretimTarihi = pts.ProductionDate;
                            }

                            makbuzDetayItem.malzemeDigerAciklama = pts.Material.Name;
                            if (string.IsNullOrEmpty(pts.Material.Barcode))
                                makbuzDetayItem.urunBarkodu = string.Empty;
                            else
                                makbuzDetayItem.urunBarkodu = pts.Material.Barcode;
                            makbuzDetayItem.hbysMakbuzDetayKayitNo = pts.ObjectID.ToString();
                            makbuzDetayItem.sonKullanmaTarihi = pts.ExpirationDate;
                            makbuzDetayGirisListe.Add(makbuzDetayItem);
                        }
                    }
                    else
                    {
                        if (stockAction is ReturningDocument)
                        {
                            List<MkysServis.makbuzDetayGirisItem> prepareDetailList = new List<MkysServis.makbuzDetayGirisItem>();
                            foreach (StockTransaction trx in transactions.Value)
                            {
                                bool find = prepareDetailList.Where(x => x.malzemeKayitID == trx.StockActionDetail.Material.MkysMalzemeKodu.Value && x.sonKullanmaTarihi == trx.ExpirationDate
                               && x.vergiliBirimFiyat == trx.UnitPrice && x.hbysMakbuzDetayKayitNo == trx.StockActionDetail.ObjectID.ToString()).Any();
                                if (find)
                                {
                                    MkysServis.makbuzDetayGirisItem findItem = prepareDetailList.Where(x => x.malzemeKayitID == trx.StockActionDetail.Material.MkysMalzemeKodu.Value && x.sonKullanmaTarihi == trx.ExpirationDate
                                && x.vergiliBirimFiyat == trx.UnitPrice && x.hbysMakbuzDetayKayitNo == trx.StockActionDetail.ObjectID.ToString()).FirstOrDefault();
                                    findItem.miktar += (decimal)trx.Amount;
                                }
                                else
                                {
                                    MkysServis.makbuzDetayGirisItem newItem = new MkysServis.makbuzDetayGirisItem();
                                    if (trx.StockActionDetail.Material.MkysMalzemeKodu != null)
                                        newItem.malzemeKayitID = trx.StockActionDetail.Material.MkysMalzemeKodu.Value;
                                    else
                                        SonucMesaj += trx.StockActionDetail.Material.Name + " isimli malzemenin mkys malzeme kodu tan�mlanmam��t�r! ";
                                    newItem.miktar = (decimal)trx.Amount;
                                    newItem.olcuBirimiID = (MkysServis.EOlcuBirimID)(int)trx.StockActionDetail.Material.StockCard.DistributionType.MKYS_DistType;
                                    newItem.vergisizBirimFiyat = (decimal)trx.UnitPrice;
                                    newItem.vergiliBirimFiyat = (decimal)trx.UnitPrice;
                                    newItem.kdvOrani = 0;
                                    foreach (StockTransaction stockTransactionOut in trx.StockActionDetail.StockTransactions.Select(" INOUT = 2 "))
                                    {
                                        StockTransaction firstInStockTransaction = stockTransactionOut.GetFirstInTransaction();
                                        newItem.uretimTarihi = ((StockActionDetailIn)firstInStockTransaction.StockActionDetail).ProductionDate;
                                    }
                                    newItem.malzemeDigerAciklama = trx.StockActionDetail.Material.Name;
                                    if (string.IsNullOrEmpty(trx.StockActionDetail.Material.Barcode))
                                        newItem.urunBarkodu = string.Empty;
                                    else
                                        newItem.urunBarkodu = trx.StockActionDetail.Material.Barcode;
                                    newItem.hbysMakbuzDetayKayitNo = trx.StockActionDetail.ObjectID.ToString();
                                    newItem.sonKullanmaTarihi = trx.ExpirationDate;



                                    prepareDetailList.Add(newItem);
                                }
                            }
                            foreach (MkysServis.makbuzDetayGirisItem prepareItem in prepareDetailList)
                            {
                                makbuzDetayGirisListe.Add(prepareItem);
                            }
                        }
                        else
                        {
                            foreach (StockTransaction stockTransaction in transactions.Value)
                            {
                                MkysServis.makbuzDetayGirisItem makbuzDetayItem = new MkysServis.makbuzDetayGirisItem();
                                if (stockTransaction.StockActionDetail.Material.MkysMalzemeKodu != null)
                                    makbuzDetayItem.malzemeKayitID = stockTransaction.StockActionDetail.Material.MkysMalzemeKodu.Value;
                                else
                                    SonucMesaj += stockTransaction.StockActionDetail.Material.Name + " isimli malzemenin mkys malzeme kodu tan�mlanmam��t�r! ";
                                makbuzDetayItem.miktar = (decimal)stockTransaction.Amount;
                                makbuzDetayItem.olcuBirimiID = (MkysServis.EOlcuBirimID)(int)stockTransaction.StockActionDetail.Material.StockCard.DistributionType.MKYS_DistType;
                                if (stockAction is IChattelDocumentWithPurchase) // SATINALMA YOLUYLA G�R��
                                {
                                    makbuzDetayItem.vergisizBirimFiyat = ((IChattelDocumentDetailWithPurchase)stockTransaction.StockActionDetail).GetUnitPriceWithOutVat().Value;
                                    makbuzDetayItem.vergiliBirimFiyat = (decimal)((IStockActionDetailIn)stockTransaction.StockActionDetail).GetUnitPrice(); //((IChattelDocumentDetailWithPurchase)actionDetail).UnitPriceWithInVat.Value;
                                    makbuzDetayItem.edinimYili = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetRetrievalYear();
                                    makbuzDetayItem.kdvOrani = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetVatRate();
                                    makbuzDetayItem.indirimOrani = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetDiscountRate();
                                    //makbuzDetayItem.indirimTutari = ((IStockActionDetailIn)stockTransaction.StockActionDetail).DiscountAmount;
                                    makbuzDetayItem.indirimTutari = makbuzDetayItem.indirimOrani * makbuzDetayItem.miktar / 100;
                                    //((IStockActionDetailIn)stockTransaction.StockActionDetail).GetDiscountAmount() / (decimal)stockTransaction.Amount;
                                }

                                if (stockAction is IChattelDocumentInputWithAccountancy) // TA�INIR MAL G�R��
                                {
                                    makbuzDetayItem.vergisizBirimFiyat = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetNotDiscountedUnitPrice().Value;
                                    makbuzDetayItem.vergiliBirimFiyat = (decimal)((IStockActionDetailIn)stockTransaction.StockActionDetail).GetUnitPrice(); //((IStockActionDetailIn)actionDetail).NotDiscountedUnitPrice.Value;
                                    makbuzDetayItem.edinimYili = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetRetrievalYear();
                                    makbuzDetayItem.indirimOrani = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetDiscountRate();
                                    //makbuzDetayItem.indirimTutari = ((IStockActionDetailIn)stockTransaction.StockActionDetail).DiscountAmount;
                                    makbuzDetayItem.indirimTutari = makbuzDetayItem.indirimTutari = makbuzDetayItem.indirimOrani * makbuzDetayItem.miktar / 100;
                                    //((IStockActionDetailIn)stockTransaction.StockActionDetail).GetDiscountAmount() / (decimal)stockTransaction.Amount;
                                    makbuzDetayItem.kdvOrani = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetVatRate();

                                    //devredilecek stock hareket id giri� i�lemi
                                    makbuzDetayItem.stokHareketDevirID = stockTransaction.StockActionDetail.MKYS_CikisStokHareketID;
                                }

                                if (stockAction is ReturningDocument) //�ADE BELGES� G�R��
                                {
                                    makbuzDetayItem.vergisizBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                    makbuzDetayItem.vergiliBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                    makbuzDetayItem.kdvOrani = 0;
                                }

                                if (stockAction is StockIn) //�ADE �LA� G�R��
                                {
                                    makbuzDetayItem.vergisizBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                    makbuzDetayItem.vergiliBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                    makbuzDetayItem.kdvOrani = 0;
                                }

                                if (stockAction is IGrantMaterial) //BA�I� YARDIM �LE G�R��
                                {
                                    makbuzDetayItem.vergisizBirimFiyat = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetNotDiscountedUnitPrice().Value;
                                    makbuzDetayItem.vergiliBirimFiyat = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetNotDiscountedUnitPrice().Value;
                                    makbuzDetayItem.edinimYili = ((IStockActionDetailIn)stockTransaction.StockActionDetail).GetRetrievalYear();
                                }

                                if (stockAction is IExtendExpDateIn) //MIAD G�NCELLEME G�R��
                                {
                                    makbuzDetayItem.vergisizBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                    makbuzDetayItem.vergiliBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                }

                                if (stockAction is IMainStoreStockTransfer) //AMBARLAR ARASI G�R��
                                {
                                    makbuzDetayItem.vergisizBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                    makbuzDetayItem.vergiliBirimFiyat = (decimal)stockTransaction.UnitPrice;

                                    //D�KKAT !!! BURADA MUTLAKA O DETAILA A�T �IKI� TRANSACTIONININ MKYSSTOKHAREKETID'si G�NDERILMELIDIR !!!
                                    //********
                                    StockTransaction trnsactForOut = null;
                                    var trnsactForOutList = stockTransaction.StockActionDetail.StockTransactions.Select(" INOUT = 2");
                                    if (trnsactForOutList.Count == 1)
                                    {
                                        trnsactForOut = trnsactForOutList.FirstOrDefault();
                                    }

                                    if (trnsactForOut != null)
                                    {
                                        if (trnsactForOut.MKYS_StokHareketID != null)
                                            makbuzDetayItem.stokHareketDevirID = trnsactForOut.MKYS_StokHareketID;
                                    }
                                    //**********

                                }

                                if (stockAction is IGeneralProductionAction) //GENEL �RET�M ��LEM�
                                {
                                    makbuzDetayItem.vergisizBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                    makbuzDetayItem.vergiliBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                }

                                if (stockAction is CensusFixed) //SAYIM D�ZELTME ��LEM�
                                {
                                    makbuzDetayItem.vergisizBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                    makbuzDetayItem.vergiliBirimFiyat = (decimal)stockTransaction.UnitPrice;
                                    makbuzDetayItem.sonKullanmaTarihi = stockTransaction.ExpirationDate;
                                }

                                if (stockTransaction.StockActionDetail is StockActionDetailIn)
                                {
                                    if (((StockActionDetailIn)stockTransaction.StockActionDetail).ProductionDate != null)
                                    {
                                        makbuzDetayItem.uretimTarihi = ((StockActionDetailIn)stockTransaction.StockActionDetail).ProductionDate;
                                    }
                                }

                                if (stockTransaction.StockActionDetail is StockActionDetailOut)
                                {
                                    foreach (StockTransaction stockTransactionOut in stockTransaction.StockActionDetail.StockTransactions.Select(" INOUT = 2 "))
                                    {
                                        StockTransaction firstInStockTransaction = stockTransactionOut.GetFirstInTransaction();
                                        makbuzDetayItem.uretimTarihi = ((StockActionDetailIn)firstInStockTransaction.StockActionDetail).ProductionDate;
                                    }
                                }

                                makbuzDetayItem.malzemeDigerAciklama = stockTransaction.StockActionDetail.Material.Name;
                                if (string.IsNullOrEmpty(stockTransaction.StockActionDetail.Material.Barcode))
                                    makbuzDetayItem.urunBarkodu = string.Empty;
                                else
                                    makbuzDetayItem.urunBarkodu = stockTransaction.StockActionDetail.Material.Barcode;
                                makbuzDetayItem.hbysMakbuzDetayKayitNo = stockTransaction.ObjectID.ToString();
                                makbuzDetayItem.sonKullanmaTarihi = stockTransaction.ExpirationDate;
                                makbuzDetayGirisListe.Add(makbuzDetayItem);
                            }
                        }
                    }




                    //a��klama alanlar�na ek yaz�lanlar� istediklerinden yap�ld�.
                    girisItem.fisAciklama += " " + stockAction.Description;
                    girisItem.makbuzDetayList = makbuzDetayGirisListe.ToArray();
                    stockAction.MKYS_GonderimTarihi = Common.RecTime();
                    stockAction.MKYS_GidenVeri = TTUtils.SerializationHelper.XmlSerializeObject(girisItem);
                    MkysServis.makbuzInsertGirisSonuc makbuzInsertGirisSonuc = MkysServis.WebMethods.makbuzInsertGirisSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, mkysPwd, girisItem);
                    stockAction.MKYS_GelenVeri = TTUtils.SerializationHelper.XmlSerializeObject(makbuzInsertGirisSonuc);
                    if (makbuzInsertGirisSonuc.basariDurumu == false)
                    {
                        SonucMesaj += "MKYS'ye Bildirim Ba�ar�s�z. " + makbuzInsertGirisSonuc.mesaj;
                        currentLog.MKYSStatus = MKYSControlEnum.Completed;
                        return SonucMesaj;
                    }
                    else
                    {
                        SonucMesaj += girisItem.makbuzNo.ToString() + " Makbuz Nolu i�lem, " + makbuzInsertGirisSonuc.ayniyatMakbuzID.ToString() + " Ayniyat Numaras� ile MKYS'ye Bildirim Ba�ar�l� Kaydedilmi�tir.";
                    }

                    currentLog.ReceiptNumber = makbuzInsertGirisSonuc.ayniyatMakbuzID;
                    currentLog.Descriptions = makbuzInsertGirisSonuc.mesaj;
                    currentLog.MKYSStatus = MKYSControlEnum.CompletedSent;


                    foreach (var makbuzDetayIt in makbuzInsertGirisSonuc.sonucMakbuzDetayList)
                    {
                        if (stockAction.IsPTSAction == true)
                        {
                            foreach (var detailIn in stockAction.PTSStockActionDetails)
                            {
                                if (detailIn.ObjectID == new Guid(makbuzDetayIt.hbysMakbuzDetayKayitNo))
                                {
                                    detailIn.VoucherDetailRecordNo = makbuzDetayIt.makbuzDetayKayitNo;
                                }
                            }

                        }
                        else
                        {
                            foreach (var detailIn in stockAction.StockActionInDetails)
                            {
                                if (detailIn.ObjectID == new Guid(makbuzDetayIt.hbysMakbuzDetayKayitNo))
                                {
                                    detailIn.VoucherDetailRecordNo = makbuzDetayIt.makbuzDetayKayitNo;
                                }
                            }

                        }
                    }

                    foreach (var stokHareketDetay in makbuzInsertGirisSonuc.sonucStokHareketList)
                    {
                        if (stockAction.IsPTSAction == true)
                        {
                            PTSStockActionDetail pTSStockActionDetail = (PTSStockActionDetail)objectContext.GetObject(new Guid(stokHareketDetay.hbysStokHareketID), typeof(PTSStockActionDetail));
                            foreach (StockActionDetail det in pTSStockActionDetail.StockActionDetails.Select(string.Empty))
                            {
                                foreach (StockTransaction st in det.StockTransactions.Select(string.Empty))
                                {
                                    st.MKYS_StokHareketID = stokHareketDetay.stokHareketID;
                                }
                            }
                        }
                        else
                        {
                            if (tranactionToCompareMKYS.ContainsKey(new Guid(stokHareketDetay.hbysStokHareketID)))
                            {
                                tranactionToCompareMKYS[new Guid(stokHareketDetay.hbysStokHareketID)].MKYS_StokHareketID = stokHareketDetay.stokHareketID;
                            }
                        }
                    }

                    stockAction.MKYSControl = true;
                    if (stockAction is IMainStoreStockTransfer)
                    {
                        ((IMainStoreStockTransfer)stockAction).SetInMkysControl(true);
                    }

                    if (stockAction is IExtendExpirationDate)
                    {
                        ((IExtendExpirationDate)stockAction).SetInMkysControl(true);
                    }

                    if (stockAction is IGeneralProductionAction)
                    {
                        ((IGeneralProductionAction)stockAction).SetInMkysControl(true);
                    }

                    if (stockAction is CensusFixed)
                    {
                        ((CensusFixed)stockAction).InMkysControl = true;
                    }
                }

                if (String.IsNullOrEmpty(SonucMesaj))
                {
                    SonucMesaj = TTUtils.CultureService.GetText("M26531", "MKYS g�nderim i�lemi Ba�ar�s�z");
                }
                else
                {
                    try
                    {
                        if (stockAction is IChattelDocumentWithPurchase)
                            if (((IChattelDocumentWithPurchase)stockAction).GetIsFastSoft().HasValue && ((IChattelDocumentWithPurchase)stockAction).GetIsFastSoft().Value)
                            {
                                string birim_ID = TTObjectClasses.SystemParameter.GetParameterValue("FASTSOFTBIRIMID", "");
                                Guid siteID = Sites.SiteLocalHost;
                                var documentRecordLog = stockAction.DocumentRecordLogs[0];
                                string exp = string.Empty;
                                int FaturaId = ((IChattelDocumentWithPurchase)stockAction).GetFastSoftFaturaId().Value;
                                int UygulamaId = ((IChattelDocumentWithPurchase)stockAction).GetFastSoftUygulamaId().Value;
                                FsTasinirWebServis.KayitSonuc kayitSonuc = FsTasinirWebServis.WebMethods.MuayeneFaturaTifKaydetSync(siteID, "", "", birim_ID, documentRecordLog.ReceiptNumber.ToString(), documentRecordLog.DocumentDateTime.Value, UygulamaId, FaturaId);
                                if (kayitSonuc.basariDurumu)
                                {
                                    SonucMesaj += " Fastsoft bildirim i�lemi Ba�ar�l�.";
                                }
                                else
                                {
                                    SonucMesaj += "Fastsoft bildirim i�lemi Ba�ar�s�z!";
                                }
                            }
                    }
                    catch (Exception ex)
                    {
                        SonucMesaj += "Fastsoft bildirim i�lemi Ba�ar�s�z! " + ex.ToString();
                    }
                }

                objectContext.Save();
                return SonucMesaj;
            }
            catch (Exception ex)
            {
                SonucMesaj = ex.Message + " - MKYS g�nderim i�leminde hata olu�tu! ";
                return SonucMesaj;
            }
        }

        #endregion MKYS_Input_Message
        #region MKYS_KisiVarMi_Message
        public string MKYSTeslimAlanKisiVarMiSonuc(string kisiTCNo)
        {
            //Teslim alan kisi MKYS de kayitli ise basarili olarak "0" kodu donduruluyor.
            //Kayitli degilse servisten donen mesaj donduruluyor
            try
            {
                MkysServis.kisiKontrolSonuc kisiKontrol = MkysServis.WebMethods.kisiVarMiSync(Sites.SiteLocalHost, kisiTCNo);
                if (kisiKontrol.varMi == false)
                    return kisiKontrol.mesaj;
                else
                    return "0";
            }
            catch
            {
                return "MKYS KisiVarMi servisinde hata olu�tu! ";
            }

        }

        #endregion MKYS_KisiVarMi_Message

        #region MKYS_DepoYetkiKontrol_Message
        public string MKYSKullaniciDepoYetkiVarMiSonuc(int depoKayitNo, string kullaniciAdi)
        {
            //Depo Yetki Kontrol sorgulamasi basarili ise "0" kodu donduruluyor.
            //Depo Yetki Kontrol yoksa degilse servisten donen mesaj donduruluyor

            try
            {
                MkysServis.depoYetkiKontrolItem yetkiKontrolItem = new MkysServis.depoYetkiKontrolItem();
                yetkiKontrolItem.depoKayitNo = depoKayitNo;
                yetkiKontrolItem.mkysKullaniciAdi = kullaniciAdi;

                MkysServis.depoYetkiKontrolSonuc yetkiKontrolSonuc = MkysServis.WebMethods.depoYetkiKontrolSync(Sites.SiteLocalHost, yetkiKontrolItem);
                if (yetkiKontrolSonuc.yetkiVar == false)
                    return yetkiKontrolSonuc.mesaj;
                else
                    return "0";
            }
            catch
            {
                return "MKYS DepoYetkiKontrol servisinde hata olu�tu! ";
            }
        }

        #endregion MKYS_DepoYetkiKontrol_Message

        #region MKYS_Output_Message
        //public static string SendMKYSForOutputDocumentTS(StockAction stockAction, string mkysPwd)
        //{
        //    return stockAction.SendMKYSForOutputDocument(mkysPwd);
        //}

        public string SendMKYSForOutputDocument(string mkysPwd)
        {
            string SonucMesaj = string.Empty;
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                StockAction stockAction = null;
                stockAction = (StockAction)objectContext.GetObject(ObjectID, ObjectDef);

                //MKYS den Teslim Alan kisi bilgisi kontrolu yapiliyor
                string teslimAlanKisiTCNO = "";
                if (stockAction.MKYS_TeslimAlanObjID != null)
                {
                    List<ResUser> user = objectContext.QueryObjects<ResUser>("OBJECTID = '" + stockAction.MKYS_TeslimAlanObjID + "'").ToList();
                    if (user.Count > 0)
                    {
                        teslimAlanKisiTCNO = ((ResUser)user[0]).UniqueNo;
                        string teslimAlanKisiVarMiSonucMsg = MKYSTeslimAlanKisiVarMiSonuc(teslimAlanKisiTCNO);
                        if (teslimAlanKisiVarMiSonucMsg != "0")
                            SonucMesaj = teslimAlanKisiVarMiSonucMsg;
                    }
                }

                //MKYS den depoYetkiKontrolu yapiliyor
                int depoKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo.Value;
                string depoYetkiKontrolSonucMsg = MKYSKullaniciDepoYetkiVarMiSonuc(depoKayitNo, Common.CurrentResource.MkysUserName);
                if (depoYetkiKontrolSonucMsg != "0")
                    SonucMesaj += depoYetkiKontrolSonucMsg;


                Dictionary<Guid, StockTransaction> tranactionToCompareMKYS = new Dictionary<Guid, StockTransaction>();
                Dictionary<Guid, List<StockTransaction>> stockActionDetailCompare = new Dictionary<Guid, List<StockTransaction>>();
                foreach (StockActionDetail actionDetailCompare in stockAction.StockActionDetails)
                {
                    List<StockTransaction> detTRX = new List<StockTransaction>();
                    stockActionDetailCompare.Add(actionDetailCompare.ObjectID, detTRX);
                    foreach (StockTransaction stockTransaction in actionDetailCompare.StockTransactions.Select(" INOUT = 2 "))
                    {
                        tranactionToCompareMKYS.Add(stockTransaction.ObjectID, stockTransaction);
                        stockActionDetailCompare[actionDetailCompare.ObjectID].Add(stockTransaction);
                    }
                }

                Dictionary<MKYS_EButceTurEnum, List<StockTransaction>> trxs = new Dictionary<MKYS_EButceTurEnum, List<StockTransaction>>();
                foreach (StockActionDetail actionDetail in stockAction.StockActionDetails)
                {
                    foreach (StockTransaction stockTransaction in actionDetail.StockTransactions.Select(" INOUT = 2 "))
                    {
                        if (stockTransaction.CurrentStateDefID != StockTransaction.States.Cancelled)
                        {
                            if (trxs.ContainsKey((MKYS_EButceTurEnum)stockTransaction.BudgetTypeDefinition.MKYS_Butce))
                            {
                                trxs[(MKYS_EButceTurEnum)stockTransaction.BudgetTypeDefinition.MKYS_Butce].Add(stockTransaction);
                            }
                            else
                            {
                                List<StockTransaction> trx = new List<TTObjectClasses.StockTransaction>();
                                trx.Add(stockTransaction);
                                trxs.Add((MKYS_EButceTurEnum)stockTransaction.BudgetTypeDefinition.MKYS_Butce, trx);
                            }
                        }
                    }
                }

                foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockTransaction>> transactions in trxs)
                {
                    MkysServis.makbuzInsertCikisItem cikisItem = new MkysServis.makbuzInsertCikisItem();
                    if (stockAction is IMainStoreStockTransfer || stockAction is IExtendExpirationDate || stockAction is IDeleteRecordDocumentDestroyable || stockAction is IDeleteRecordDocumentWaste || stockAction is IGeneralProductionAction || stockAction is CensusFixed || stockAction is DistributionDocument || stockAction is MainStoreDistributionDoc) //HEK i�lemi i�in ��k�� verildi!
                        cikisItem.islemTuru = MkysServis.ECikisIslemTuru.cikis;
                    else if (stockAction is IChangeStockLevelType)
                        cikisItem.islemTuru = MkysServis.ECikisIslemTuru.ihtiyacFazlasi;
                    else
                        cikisItem.islemTuru = (MkysServis.ECikisIslemTuru)(int)stockAction.MKYS_CikisIslemTuru.Value;
                    //cikisItem.butceTurID = (MkysServis.EButceTurID)((int)(((MainStoreDefinition)stockAction.Store).MKYS_ButceTuru.Value));  // cikisItem.butceTurID = (MkysServis.EButceTurID)(int)stockAction.BudgetTypeDefinition.MKYS_Butce.Value;
                    cikisItem.stokHareketTurID = (MkysServis.ECikisStokHareketTurID)(int)stockAction.MKYS_CikisStokHareketTuru; //_ChattelDocumentOutputWithAccountancy.MKYS_CikisStokHareketTuru;
                    DocumentRecordLog currentLog = null;
                    foreach (DocumentRecordLog log in stockAction.DocumentRecordLogs)
                    {
                        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out && log.BudgeType == transactions.Key)
                        {
                            cikisItem.butceTurID = (MkysServis.EButceTurID)(int)log.BudgeType.Value;
                            cikisItem.makbuzNo = Int32.Parse(log.DocumentRecordLogNumber.Value.ToString());
                            cikisItem.makbuzTarihi = (DateTime)log.DocumentDateTime;
                            currentLog = log;
                            break;
                        }
                    }

                    cikisItem.muayaneNo = stockAction.MKYS_MuayeneNo;
                    cikisItem.muayeneTarihi = stockAction.MKYS_MuayeneTarihi;
                    if (this is IChattelDocumentOutputWithAccountancy)
                    {
                        cikisItem.dayanagiBelgeNo = ((IChattelDocumentOutputWithAccountancy)this).GetStockActionID().ToString();
                        cikisItem.dayanagiBelgeTarihi = ((IChattelDocumentOutputWithAccountancy)this).GetTransactionDate();

                        if (((IChattelDocumentOutputWithAccountancy)this).GetAccountancy().GetAccountancyNO() != null)
                        {
                            cikisItem.cikisYapilanDepoKayitNo = Convert.ToInt32(((IChattelDocumentOutputWithAccountancy)this).GetAccountancy().GetAccountancyNO());
                            cikisItem.cikisBirimKayitNo = Convert.ToInt32(((IChattelDocumentOutputWithAccountancy)this).GetAccountancy().GetAccountancyNO());
                        }
                        else
                        {
                            cikisItem.cikisYapilanDepoKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo;
                            cikisItem.cikisBirimKayitNo = ((MainStoreDefinition)stockAction.Store).UnitRecordNo;
                        }

                    }
                    else
                    {
                        cikisItem.dayanagiBelgeNo = stockAction.StockActionID.Value.ToString(); //stockAction.BaseNumber;
                        cikisItem.dayanagiBelgeTarihi = stockAction.TransactionDate; // stockAction.BaseDateTime;

                        if (stockAction.DestinationStore != null)
                        {
                            if (stockAction.DestinationStore is SubStoreDefinition)
                            {
                                cikisItem.cikisYapilanDepoKayitNo = ((SubStoreDefinition)stockAction.DestinationStore).UnitRegistryNo;
                                cikisItem.cikisBirimKayitNo = ((SubStoreDefinition)stockAction.DestinationStore).UnitRegistryNo;
                            }
                            else
                            {
                                cikisItem.cikisYapilanDepoKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo;
                                cikisItem.cikisBirimKayitNo = ((MainStoreDefinition)stockAction.Store).UnitRecordNo;
                            }
                        }
                        else
                        {
                            cikisItem.cikisYapilanDepoKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo;
                            cikisItem.cikisBirimKayitNo = ((MainStoreDefinition)stockAction.Store).UnitRecordNo;
                        }
                    }

                    cikisItem.depoKayitNo = ((MainStoreDefinition)stockAction.Store).StoreRecordNo.Value;
                    cikisItem.teslimAlan = stockAction.MKYS_TeslimAlan;
                    cikisItem.teslimEden = stockAction.MKYS_TeslimEden;

                    if (teslimAlanKisiTCNO != "")
                        cikisItem.cikisYapilanKisiTCKimlikNo = teslimAlanKisiTCNO;

                    //KisiVarMi kontrolu icin asagidaki kod yukariya tasindi
                    //if (stockAction.MKYS_TeslimAlanObjID != null)
                    //{
                    //    List<ResUser> user = objectContext.QueryObjects<ResUser>("OBJECTID = '" + stockAction.MKYS_TeslimAlanObjID + "'").ToList();
                    //    if (user.Count > 0)
                    //    {
                    //        cikisItem.cikisYapilanKisiTCKimlikNo = ((ResUser)user[0]).UniqueNo;
                    //    }
                    //}

                    cikisItem.fisAciklama = stockAction.Description;

                    cikisItem.digerBirimAdi = ((MainStoreDefinition)stockAction.Store).Name;
                    cikisItem.hbysID = SystemParameter.GetParameterValue("MKYS_HBYS_ID", "Atlas");

                    var makbuzDetayCikisListe = new List<MkysServis.stokHareketCikisItem>();
                    foreach (StockTransaction stockTransaction in transactions.Value)
                    {
                        foreach (StockTransactionDetail stockTransactionDetail in stockTransaction.OutStockTransactionDetails)
                        {

                            if (stockTransactionDetail.InStockTransaction.MKYS_StokHareketID == null || stockTransactionDetail.InStockTransaction.MKYS_StokHareketID == 0)
                            {
                                SonucMesaj += stockTransactionDetail.InStockTransaction.StockActionDetail.Material.Name + " i�in MKYS Stok HareketID'si bulunamad�!. " + stockTransactionDetail.InStockTransaction.StockActionDetail.StockAction.StockActionID + " numaral� i�lemin MKYS g�nderim durumunu kontrol ediniz! ";
                            }
                            else
                            {
                                if (makbuzDetayCikisListe.Where(x => x.girisStokHareketID == stockTransactionDetail.InStockTransaction.MKYS_StokHareketID.Value).Any())
                                {
                                    MkysServis.stokHareketCikisItem findItem = makbuzDetayCikisListe.Where(x => x.girisStokHareketID == stockTransactionDetail.InStockTransaction.MKYS_StokHareketID.Value).FirstOrDefault();
                                    findItem.cikisMiktar = findItem.cikisMiktar + Convert.ToDecimal(stockTransactionDetail.Amount);
                                    findItem.hbysStokHareketID = stockTransaction.StockActionDetail.ObjectID.ToString();
                                }
                                else
                                {
                                    MkysServis.stokHareketCikisItem stokHareketCikisItem = new MkysServis.stokHareketCikisItem();
                                    stokHareketCikisItem.girisStokHareketID = stockTransactionDetail.InStockTransaction.MKYS_StokHareketID.Value;

                                    if (stockTransaction.StockActionDetail is StockActionDetailOut)
                                    {
                                        if (string.IsNullOrEmpty(((StockActionDetailOut)stockTransaction.StockActionDetail).TagNo) == false)
                                            stokHareketCikisItem.cikisTibbiCihazKunyeNo = ((StockActionDetailOut)stockTransaction.StockActionDetail).TagNo;
                                    }

                                    stokHareketCikisItem.cikisMiktar = Convert.ToDecimal(stockTransactionDetail.Amount);
                                    stokHareketCikisItem.hbysStokHareketID = stockTransaction.ObjectID.ToString();
                                    makbuzDetayCikisListe.Add(stokHareketCikisItem);
                                }
                            }
                        }
                    }

                    if (makbuzDetayCikisListe.Count > 0)
                        cikisItem.cikisStokHareketList = makbuzDetayCikisListe.ToArray();
                    stockAction.MKYS_GonderimTarihi = Common.RecTime();
                    stockAction.MKYS_GidenVeri = TTUtils.SerializationHelper.XmlSerializeObject(cikisItem);
                    MkysServis.makbuzInsertCikisSonuc makbuzInsertCikisSonuc = MkysServis.WebMethods.makbuzInsertCikisSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, mkysPwd, cikisItem);
                    stockAction.MKYS_GelenVeri = TTUtils.SerializationHelper.XmlSerializeObject(makbuzInsertCikisSonuc);
                    if (!makbuzInsertCikisSonuc.basariDurumu)
                    {
                        SonucMesaj += makbuzInsertCikisSonuc.mesaj + " MKYS G�nderim BA�ARISIZ ";
                        //return SonucMesaj;
                    }
                    else
                    {
                        SonucMesaj += cikisItem.makbuzNo.ToString() + " Makbuz Nolu i�lem, " + makbuzInsertCikisSonuc.islemKayitNo.ToString() + " Ayniyat Numaras� ile MKYS'ye Bildirim Ba�ar�l� Kaydedilmi�tir.";
                        currentLog.ReceiptNumber = makbuzInsertCikisSonuc.islemKayitNo;
                        currentLog.Descriptions = makbuzInsertCikisSonuc.mesaj;
                        currentLog.MKYSStatus = MKYSControlEnum.CompletedSent;
                        foreach (MkysServis.sonucStokHareketItem sonucStokHareketItem in makbuzInsertCikisSonuc.sonucStokHareketList)
                        {
                            if (tranactionToCompareMKYS.ContainsKey(new Guid(sonucStokHareketItem.hbysStokHareketID)))
                            {
                                tranactionToCompareMKYS[new Guid(sonucStokHareketItem.hbysStokHareketID)].MKYS_StokHareketID = sonucStokHareketItem.stokHareketID;
                            }
                            else
                            {
                                if (stockActionDetailCompare.ContainsKey(new Guid(sonucStokHareketItem.hbysStokHareketID)))
                                {
                                    foreach (StockTransaction itsTRX in stockActionDetailCompare[new Guid(sonucStokHareketItem.hbysStokHareketID)])
                                    {
                                        itsTRX.MKYS_StokHareketID = sonucStokHareketItem.stokHareketID;
                                    }
                                }
                            }
                        }

                        stockAction.MKYSControl = true;
                        if (stockAction is IMainStoreStockTransfer)
                            ((IMainStoreStockTransfer)stockAction).SetOutMkysControl(true);
                        if (stockAction is IExtendExpirationDate)
                            ((IExtendExpirationDate)stockAction).SetOutMkysControl(true);
                        if (stockAction is IGeneralProductionAction)
                            ((IGeneralProductionAction)stockAction).SetOutMkysControl(true);
                        if (stockAction is CensusFixed)
                            ((CensusFixed)stockAction).OutMkysControl = true;
                    }
                }

                if (String.IsNullOrEmpty(SonucMesaj))
                {
                    SonucMesaj = TTUtils.CultureService.GetText("M26531", "MKYS g�nderim i�lemi Ba�ar�s�z");
                }



                objectContext.Save();
                return SonucMesaj;
            }
            catch (Exception ex)
            {
                SonucMesaj = ex.Message + " - MKYS g�nderim i�leminde hata olu�tu! ";
                return SonucMesaj;
            }
        }

        #endregion MKYS_Output_Message
        #region MKYS_InOutDelete_Message

        public string SendDeleteMessageToMkys(bool IsOutOperetion, int AyniyatMakbuzID, string mkysPwd)
        {
            DocumentRecordLog log = null;
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                IBindingList documentRecordLogs = objectContext.QueryObjects("DOCUMENTRECORDLOG", "RECEIPTNUMBER ='" + AyniyatMakbuzID + "'");
                foreach (DocumentRecordLog d in documentRecordLogs)
                {
                    log = d;
                }
            }

            string SonucMesaj = string.Empty;
            if (IsOutOperetion) //bu bir ��k�� silme i�lemidir...
            {
                MkysServis.makbuzSilmeSonuc makbuzSilmeSonuc = MkysServis.WebMethods.cikisMakbuzDeleteSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, mkysPwd, AyniyatMakbuzID);
                SonucMesaj = makbuzSilmeSonuc.mesaj;
                if (makbuzSilmeSonuc.basariDurumu == true)
                {
                    SonucMesaj = "MKYSden " + AyniyatMakbuzID + " nolu Ayniyat Makbuzu Silinmi�tir.";
                    if (log != null)
                        log.MKYSStatus = MKYSControlEnum.CancelledSent;
                }
                else
                {
                    if (log != null)
                        log.MKYSStatus = MKYSControlEnum.Cancelled;
                    throw new Exception("MKYSden " + AyniyatMakbuzID + " nolu Ayniyat Makbuzu Silinememi�tir!" + SonucMesaj);
                }
            }
            else //bu bir giri� silme i�lemidir...
            {
                MkysServis.makbuzSilmeSonuc makbuzSilmeSonuc = MkysServis.WebMethods.girisMakbuzDeleteSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, mkysPwd, AyniyatMakbuzID);
                SonucMesaj = makbuzSilmeSonuc.mesaj;
                if (makbuzSilmeSonuc.basariDurumu == true)
                {
                    SonucMesaj = "MKYSden " + AyniyatMakbuzID + " nolu Ayniyat Makbuzu Silinmi�tir.";
                    if (log != null)
                        log.MKYSStatus = MKYSControlEnum.CancelledSent;
                }
                else
                {
                    if (log != null)
                        log.MKYSStatus = MKYSControlEnum.Cancelled;
                    throw new Exception("MKYSden " + AyniyatMakbuzID + " nolu Ayniyat Makbuzu Silinememi�tir!" + SonucMesaj);
                }
            }

            if (String.IsNullOrEmpty(SonucMesaj))
            {
                SonucMesaj = TTUtils.CultureService.GetText("M26531", "MKYS g�nderim i�lemi Ba�ar�s�z");
            }

            return SonucMesaj;
        }

        #endregion MKYS_InOutDelete_Message
        #region MKYS_Log_Message
        public static List<MkysServis.stokHareketLogItem> MkysLogSearch(int receiptNumber, string password)
        {
            List<MkysServis.stokHareketLogItem> returnList = new List<MkysServis.stokHareketLogItem>();
            List<MkysServis.stokHareketLogItem> stokHareketLogItems = MkysServis.WebMethods.stokHareketGirisLogGetDataSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, password, receiptNumber).ToList();
            if (stokHareketLogItems.Count > 0)
            {
                returnList = stokHareketLogItems;
            }

            return returnList;
        }

        #endregion

        #region MKYS_ROW_DELETE

        public class DocumentRecordLog_Input
        {
            public string password { get; set; }
            public string documentRecordLogObjectID { get; set; }
        }

        public static bool DeleteMkysSelectedRow(DocumentRecordLog_Input input)
        {
            bool IsOutOperetion;

            TTObjectContext context = new TTObjectContext(false);
            DocumentRecordLog log = context.GetObject<DocumentRecordLog>(new Guid(input.documentRecordLogObjectID));
            bool SonucMesaj;
            if (SystemParameter.GetParameterValue("USECOSTACTION", "FALSE") == "TRUE")
            {
                var constActionList = CostAction.GetCostActionByDate(log.StockAction.TransactionDate.Value, log.StockAction.Store.ObjectID).ToList();
                if (constActionList.Count > 0)
                {
                    SonucMesaj = false;
                    throw new TTException("Kapal� D�neme Ait Bir ��lem �ptal Edilemez. �nce D�nemi �ptal Etmeniz Gerekmektedir.��lem Numaras� : " + constActionList[0].StockActionID);
                }
            }

            if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                IsOutOperetion = true;
            else
                IsOutOperetion = false;



            if (IsOutOperetion) //bu bir ��k�� silme i�lemidir...
            {
                MkysServis.makbuzSilmeSonuc makbuzSilmeSonuc = MkysServis.WebMethods.cikisMakbuzDeleteSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, input.password, log.ReceiptNumber.Value);
                if (makbuzSilmeSonuc.basariDurumu == true)
                {
                    SonucMesaj = true;
                    if (log.StockAction.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        log.MKYSStatus = MKYSControlEnum.Completed;
                    }
                    else
                    {
                        log.MKYSStatus = MKYSControlEnum.Cancelled;
                    }
                    log.ReceiptNumber = null;
                }
                else
                {
                    if (log.StockAction.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        log.MKYSStatus = MKYSControlEnum.CompletedSent;
                    }
                    else
                    {
                        log.MKYSStatus = MKYSControlEnum.CancelledSent;
                    }
                    SonucMesaj = false;
                }
            }
            else //bu bir giri� silme i�lemidir...
            {
                MkysServis.makbuzSilmeSonuc makbuzSilmeSonuc = MkysServis.WebMethods.girisMakbuzDeleteSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, input.password, log.ReceiptNumber.Value);
                if (makbuzSilmeSonuc.basariDurumu == true)
                {
                    SonucMesaj = true;
                    log.ReceiptNumber = null;
                    if (log.StockAction.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        log.MKYSStatus = MKYSControlEnum.Completed;
                    }
                    else
                    {
                        log.MKYSStatus = MKYSControlEnum.Cancelled;
                    }
                }
                else
                {
                    if (log.StockAction.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        log.MKYSStatus = MKYSControlEnum.CompletedSent;
                    }
                    else
                    {
                        log.MKYSStatus = MKYSControlEnum.CancelledSent;
                    }
                    SonucMesaj = false;
                }
            }
            context.Save();
            return SonucMesaj;
        }

        #endregion

        #region MKYS_Update_Message

        public string SendUpdateMessageToMKYS(string mkysPwd)
        {
            string SonucMesaj = string.Empty;

            using (var objectContext = new TTObjectContext(false))
            {
                StockAction stockAction = null;
                stockAction = (StockAction)objectContext.GetObject(ObjectID, ObjectDef);

                if (stockAction is IExtendExpirationDate) //MIAD G�NCELLEME G�R��
                {
                    SonucMesaj = sonKullanmaTarihiUpdateToMKYS(mkysPwd, stockAction);
                }

                if (String.IsNullOrEmpty(SonucMesaj))
                {
                    SonucMesaj = TTUtils.CultureService.GetText("M26531", "MKYS g�nderim i�lemi Ba�ar�s�z");
                }

                return SonucMesaj;
            }
        }

        public string sonKullanmaTarihiUpdateToMKYS(string mkysPwd, StockAction stockAction)
        {
            string SonucMesaj = string.Empty;
            DocumentRecordLog currentLog = null;
            try
            {
                MkysServis.sonKullanmaUpdateInsertItem updateInsertItem = new MkysServis.sonKullanmaUpdateInsertItem();
                updateInsertItem.depoKayitNo = (int)((MainStoreDefinition)stockAction.Store).StoreRecordNo;
                var sonKullanmaTarihiUpdateItemListe = new List<MkysServis.sonKullanmaTarihiUpdateItemList>();

                foreach (StockActionDetail actionDetail in stockAction.StockActionDetails)
                {
                    foreach (StockTransaction stockTransaction in actionDetail.StockTransactions.Select(" INOUT = 1 "))
                    {
                        MkysServis.sonKullanmaTarihiUpdateItemList updateItemList = new MkysServis.sonKullanmaTarihiUpdateItemList();
                        updateItemList.sonKullanmaTarihi = Convert.ToDateTime(((IExtendExpirationDateDetail)actionDetail).GetNewDateForExpiration());
                        updateItemList.stokHareketID = (int)stockTransaction.MKYS_StokHareketID;
                        sonKullanmaTarihiUpdateItemListe.Add(updateItemList);
                    }
                }

                if (sonKullanmaTarihiUpdateItemListe.Count > 0)
                    updateInsertItem.list = sonKullanmaTarihiUpdateItemListe.ToArray();

                stockAction.MKYS_GonderimTarihi = Common.RecTime();
                stockAction.MKYS_GidenVeri = TTUtils.SerializationHelper.XmlSerializeObject(updateInsertItem);
                MkysServis.mkysSonuc sonKullanmaTarihiUpdateSonuc = MkysServis.WebMethods.sonKullanmaTarihiUpdateSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, mkysPwd, updateInsertItem);
                stockAction.MKYS_GelenVeri = TTUtils.SerializationHelper.XmlSerializeObject(sonKullanmaTarihiUpdateSonuc);

                //if (sonKullanmaTarihiUpdateSonuc != null)
                //{
                //    if (sonKullanmaTarihiUpdateSonuc.islemKayitNo != null)
                //        currentLog.ReceiptNumber = sonKullanmaTarihiUpdateSonuc.islemKayitNo;
                //    currentLog.Descriptions = sonKullanmaTarihiUpdateSonuc.mesaj;
                //}

                if (sonKullanmaTarihiUpdateSonuc.basariDurumu)
                    SonucMesaj += updateInsertItem.depoKayitNo.ToString() + " Depo Kay�t Nolu i�lem, MKYS'ye Bildirim Ba�ar�l� Kaydedilmi�tir.";
                else
                    SonucMesaj += "MKYS'ye Bildirim Ba�ar�s�z. " + sonKullanmaTarihiUpdateSonuc.mesaj;

                return SonucMesaj;
            }
            catch (Exception ex)
            {
                SonucMesaj = "sonKullanmaTarihiUpdateToMKYS methodunda hata olu�tu. Hata : " + ex.Message.ToString();
                return SonucMesaj;
            }
        }

        #endregion MKYS_Update_Message


        


        public string SendITSReceiptNotification()
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            StockAction stockAction = (StockAction)objectContext.GetObject(ObjectID, ObjectDef);

            ReceiptNotification.ItsPlainRequest itsPlainRequest = new ReceiptNotification.ItsPlainRequest();
            var products = new List<ReceiptNotification.ItsPlainRequestPRODUCT>();

            foreach (StockActionDetailIn actionDetail in stockAction.StockActionDetails)
            {
                ReceiptNotification.ItsPlainRequestPRODUCT itsRequestPRODUCT = new ReceiptNotification.ItsPlainRequestPRODUCT();
                itsRequestPRODUCT.GTIN = actionDetail.Material.Barcode;
                itsRequestPRODUCT.SN = actionDetail.SerialNo;
                itsRequestPRODUCT.XD = (DateTime)actionDetail.ExpirationDate;
                itsRequestPRODUCT.BN = actionDetail.LotNo;
                products.Add(itsRequestPRODUCT);
            }

            itsPlainRequest.PRODUCTS = products.ToArray();
            var response = ReceiptNotification.WebMethods.sendReceiptNotificationSync(Sites.SiteLocalHost, itsPlainRequest);
            if (string.IsNullOrEmpty(response.NOTIFICATIONID) == false)
            {
                return response.NOTIFICATIONID;
            }
            else
            {
                return string.Empty;
            }
        }

        protected override bool IsParentRelationRequired(TTObjectRelationDef relDef)
        {
            //Parametre olarak verilen nesne ili�kisi tan�m�nda, parent olan nesnenin zorunlu olup olmad���n� kontrol eder.
            TTObjectRelationDef def = ObjectDef.AllParentRelationDefs[typeof(AccountingTerm).Name];
            if (relDef.RelationDefID.Equals(def.RelationDefID))
            {
                if (this is SubStoreStockTransfer || this is IChangeStockLevelType || this is StockOut || this is StockPrescriptionOut || this is StockIn || this is PurchaseExamination || this is E1 || this is MagistralPreparationAction || this is MilitaryDrugProductionProcedure || this is DrugProductionTest || this is SubStoreConsumptionAction || this is ResSubStoreConsumption || this is IVoucherDistributingDocument || this is IVoucherReturnDocument || this is IProductionConsumptionInfirmaryDocument || this is ICensusOrderByStore || this is FreePrescriptionEntry || this is StockFirstIn)
                    return false;
                if (this is KSchedule && Store is PharmacySubStoreDefinition)
                    return false;
                return true;
            }

            return base.IsParentRelationRequired(relDef);
        }

        private void CheckStockCardCardDrawers()
        { /* TODO MASA B�LG�S� SORULMAYACAK KAPATILDI.
            bool check = true;
            if (this.AccountingTerm != null && this is IDistributionDepStore == false && this is IReturnDepStore == false)
            {
                if (this is ProductionConsumptionDocument && this.Store is IUnitStoreDefinition)
                    check = false;
                if (check)
                {
                    string errMsg = "A�a��daki Malzeme veya Malzemeler de Masa Bilgisi Eksiktir.\r\nMerkezde Ara / Burada olu�tur yap�larak Masa Bilgisini G�ncelleyin.\r\n";
                    bool err = false;
                    foreach (StockActionDetail stockActionDetail in this.StockActionDetails)
                    {
                        AccountancyStockCard accountancyStockCard = stockActionDetail.Material.StockCard.GetAccountancyStockCard(this.AccountingTerm.Accountancy);
                        if (accountancyStockCard == null)
                        {
                            errMsg += stockActionDetail.Material.StockCard.NATOStockNO + " - " + stockActionDetail.Material.Name + "\r\n";
                            err = true;
                        }
                    }

                    if (err)
                        throw new Exception(errMsg);
                }
            }*/
        }

        public void CheckStockCardCardNofCount(int nofCount)
        {
            Dictionary<string, bool> DistinctStockCard = new Dictionary<string, bool>();
            foreach (StockActionDetail stockActionDetail in StockActionDetails)
            {
                DistinctStockCard[stockActionDetail.Material.StockCard.ObjectID.ToString()] = true;
            }

            List<string> result = new List<string>();
            result.AddRange(DistinctStockCard.Keys);
            if (DistinctStockCard.Count > nofCount)
            {
                throw new Exception(nofCount + " den fazla stok kart� se�ilmi�tir. L�tfen tekrar kontrol ediniz.");
            }
        }

        private void CheckDetailsWithTheEqualityOfFixedassets()
        {
            //Bir demirba� stok hareketinde, giri� ve ��k��larda, ilgili malzemeye demirba� detaylar�ndaki bilgilerin eksiksiz girilmi� olup olmad���n� kontrol eder.
            if (ObjectDef.ID != new Guid("87b43545-54b2-468c-909d-913cb518aa53"))
            {
                if (StockActionInDetails.Count > 0)
                    CheckInDetailsWithTheEqualityOfFixedassets();
            }

            if (StockActionOutDetails.Count > 0)
            {
                bool checking = true;
                if (CurrentStateDefID == DistributionDocument.States.New || CurrentStateDefID == DistributionDocument.States.Approval || CurrentStateDefID == SectionRequirement.States.New || CurrentStateDefID == SectionRequirement.States.Approval)
                    checking = false;
                if (checking)
                    CheckOutDetailsWithTheEqualityOfFixedassets();
            }
        }

        private void CheckInDetailsWithTheEqualityOfFixedassets()
        {
            //Giri� tipindeki demirba� stok hareketinde, ilgili malzemeye demirba� detaylar�ndaki bilgilerin eksiksiz girilmi� olup olmad���n� kontrol eder.
            string errMessage = string.Empty;
            foreach (StockActionDetailIn stockActionInDetail in StockActionInDetails)
            {
                if (stockActionInDetail.Material is FixedAssetDefinition && stockActionInDetail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                {
                    if (stockActionInDetail.FixedAssetInDetails.Count == 0)
                        errMessage += stockActionInDetail.Material.Name + " malzemeye ait Demirba� Detaylar� hi� girilmemi�. L�tfen ilgili sat�r�n ba��ndaki kutucu�a �ift t�klayarak demirba� detaylar�n� giriniz.";
                    if (stockActionInDetail.FixedAssetInDetails.Count < stockActionInDetail.Amount)
                        errMessage += stockActionInDetail.Material.Name + " malzemeye ait Demirba� Detaylar� eksik girilmi�.\r\nGirilen Detay : " + stockActionInDetail.FixedAssetInDetails.Count + " Olmas� Gereken Detay : " + stockActionInDetail.Amount;
                }
            }

            if (string.IsNullOrEmpty(errMessage) == false)
                throw new Exception(SystemMessage.GetMessageV3(1231, new string[] { errMessage.ToString() }));
        }

        private void CheckOutDetailsWithTheEqualityOfFixedassets()
        {
            //��k�� tipindeki demirba� stok hareketinde, ilgili malzemeye demirba� detaylar�ndaki bilgilerin eksiksiz girilmi� olup olmad���n� kontrol eder.
            string errMessage = string.Empty;
            foreach (StockActionDetailOut stockActionOutDetail in StockActionOutDetails)
            {
                if (stockActionOutDetail.Material is FixedAssetDefinition && stockActionOutDetail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                {
                    if (stockActionOutDetail.FixedAssetOutDetails.Count == 0)
                        errMessage += stockActionOutDetail.Material.Name + " malzemeye ait Demirba� Detaylar� hi� girilmemi�. L�tfen ilgili sat�r�n ba��ndaki kutucu�a �ift t�klayarak demirba� detaylar�n� giriniz.";
                    if (stockActionOutDetail.FixedAssetOutDetails.Count < stockActionOutDetail.Amount)
                        errMessage += stockActionOutDetail.Material.Name + " malzemeye ait Demirba� Detaylar� eksik girilmi�.\r\nGirilen Detay : " + stockActionOutDetail.FixedAssetOutDetails.Count + " Olmas� Gereken Detay : " + stockActionOutDetail.Amount;
                }
            }

            if (string.IsNullOrEmpty(errMessage) == false)
                throw new Exception(SystemMessage.GetMessageV3(1231, new string[] { errMessage.ToString() }));
        }

        public Dictionary<Guid, ResCardDrawer> SelectedCardDrawers
        {
            get
            {
                Dictionary<Guid, ResCardDrawer> selectedCardDrawers = new Dictionary<Guid, ResCardDrawer>();
                if (AccountingTerm != null)
                {
                    foreach (StockActionDetailIn inDetail in StockActionInDetails)
                        AddSelectedCardDrawers(inDetail, ref selectedCardDrawers);
                    foreach (StockActionDetailOut outDetail in StockActionOutDetails)
                        AddSelectedCardDrawers(outDetail, ref selectedCardDrawers);
                }

                return selectedCardDrawers;
            }
        }

        private void AddSelectedCardDrawers(StockActionDetail stockActionDetail, ref Dictionary<Guid, ResCardDrawer> selectedCardDrawers)
        {
            //Parametrede verilen bilgiler do�rultusunda bir stok kart� masas� yarat�r
            if (stockActionDetail.Material.StockCard != null)
            {
                AccountancyStockCard accountancyStockCard = stockActionDetail.Material.StockCard.GetAccountancyStockCard(stockActionDetail.StockAction.AccountingTerm.Accountancy);
                if (accountancyStockCard != null)
                {
                    ResCardDrawer cardDrawer = accountancyStockCard.CardDrawer;
                    if (cardDrawer != null && selectedCardDrawers.ContainsKey(cardDrawer.ObjectID) == false)
                        selectedCardDrawers.Add(cardDrawer.ObjectID, cardDrawer);
                }
            }
        }

        public void UnitPriceControl()
        {
            //Birim fiyat bilgisinin s�f�r olup olmad���n� kontrol eder
            if (StockActionInDetails != null)
            {
                foreach (StockActionDetailIn stockActionDetailIn in StockActionInDetails)
                {
                    if (stockActionDetailIn.UnitPrice == 0)
                        throw new Exception(SystemMessage.GetMessage(1232));
                }
            }
        }

        public void CancelDocumentRecordLogs()
        {
            foreach (DocumentRecordLog documentRecordLog in DocumentRecordLogs.Select(string.Empty))
                documentRecordLog.CurrentStateDefID = DocumentRecordLog.States.Cancelled;
        }

        public static List<StockActionInspectionDetail> StockActionInspectionDetailTS(InspectionUserTypeEnum[] signUserTypes)
        {
            List<StockActionInspectionDetail> stockActionInspectionDetail = new List<StockActionInspectionDetail>();
            foreach (InspectionUserTypeEnum inspectionUserTypeEnumReturn in signUserTypes)
            {
                TTObjectContext context = new TTObjectContext(false);
                StockActionInspectionDetail inspectionDetail = new StockActionInspectionDetail(context);
                inspectionDetail.InspectionUserType = inspectionUserTypeEnumReturn;
                stockActionInspectionDetail.Add(inspectionDetail);
            }

            return stockActionInspectionDetail;
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Kayit_Silme_Belgesi_Yok_Edilen_Malzeme_Kontrol, TTRoleNames.Kayit_Silme_Belgesi_Yok_Edilen_Kayit)]
        public static StockActionInspection StockActionInspectionTS(InspectionUserTypeEnum[] signUserTypes)
        {
            TTObjectContext context = new TTObjectContext(false);
            StockActionInspection stockActionInspection = new StockActionInspection(context);
            stockActionInspection.InspectionDate = TTObjectDefManager.ServerTime;
            List<StockActionInspectionDetail> stockActionInspectionDetail = new List<StockActionInspectionDetail>();
            foreach (InspectionUserTypeEnum inspectionUserTypeEnumReturn in signUserTypes)
            {
                StockActionInspectionDetail inspectionDetail = new StockActionInspectionDetail(context);
                inspectionDetail.InspectionUserType = inspectionUserTypeEnumReturn;
                stockActionInspectionDetail.Add(inspectionDetail);
                stockActionInspection.StockActionInspectionDetails.Add(inspectionDetail);
            }

            return stockActionInspection;
        }

        public void CreateStockActionInspection()
        {
            if (StockActionInspection == null)
            {
                StockActionInspection = new StockActionInspection(ObjectContext);
                StockActionInspection.InspectionDate = TTObjectDefManager.ServerTime;
                StockActionInspectionDetail stockActionInspectionDetail = StockActionInspection.StockActionInspectionDetails.AddNew();
                stockActionInspectionDetail.InspectionUserType = InspectionUserTypeEnum.Baskan;
                stockActionInspectionDetail.InspectionUser = null;
                stockActionInspectionDetail = StockActionInspection.StockActionInspectionDetails.AddNew();
                stockActionInspectionDetail.InspectionUserType = InspectionUserTypeEnum.Uye;
                stockActionInspectionDetail.InspectionUser = null;
                stockActionInspectionDetail = StockActionInspection.StockActionInspectionDetails.AddNew();
                stockActionInspectionDetail.InspectionUserType = InspectionUserTypeEnum.Uye;
                stockActionInspectionDetail.InspectionUser = null;
                stockActionInspectionDetail = StockActionInspection.StockActionInspectionDetails.AddNew();
                stockActionInspectionDetail.InspectionUserType = InspectionUserTypeEnum.TeknikUye;
                stockActionInspectionDetail.InspectionUser = null;
            }
        }

        public override string ToString()
        {
            return "��lem No: " + StockActionID.ToString() + "   ----   ��lem tarihi: " + ActionDate.ToString() + "   ----   Step: " + CurrentStateDef.ToString();
        }

        public void AutoDocumentNumberOperation()
        {
            TTObjectDef objectDef = ObjectDef;
            TTAttribute autoDocumentNumberAttribute;
            objectDef.Attributes.TryGetValue(typeof(AutoDocumentNumberAttribute).Name, out autoDocumentNumberAttribute);
            if (autoDocumentNumberAttribute != null)
            {
                Guid objectID = ObjectID;
                TTObjectContext objectContext = new TTObjectContext(false);
                StockAction stockAction = (StockAction)objectContext.GetObject(objectID, objectDef);
                if (stockAction.SequenceNumberSeq.Value != null)
                    stockAction.SequenceNumber = stockAction.SequenceNumberSeq.Value.ToString();
                if (stockAction.RegistrationNumberSeq.Value != null)
                {
                    TTAttribute attribute;
                    objectDef.Attributes.TryGetValue(typeof(StockInTransactionAttribute).Name, out attribute);
                    if (attribute == null)
                        objectDef.Attributes.TryGetValue(typeof(StockOutTransactionAttribute).Name, out attribute);
                    if (attribute == null)
                        objectDef.Attributes.TryGetValue(typeof(StockTransferTransactionAttribute).Name, out attribute);
                    if (attribute == null)
                        objectDef.Attributes.TryGetValue(typeof(StockConsumptionTransactionAttribute).Name, out attribute);
                    if (attribute == null)
                        objectDef.Attributes.TryGetValue(typeof(StockProductionTransactionAttribute).Name, out attribute);
                    if (attribute == null)
                        objectDef.Attributes.TryGetValue(typeof(StockCensusOrderAttribute).Name, out attribute);
                    if (attribute == null)
                        objectDef.Attributes.TryGetValue(typeof(StockMergeTransactionAttribute).Name, out attribute);
                    if (attribute != null)
                    {
                        StockTransactionDefinition stockTransactionDefinition = StockTransactionDefinition.GetStockTransactionDefinition((Guid)attribute.Parameters["stockTransactionDef"].Value);
                        stockAction.RegistrationNumber = stockTransactionDefinition.ReferenceLetter + "-" + stockAction.RegistrationNumberSeq.Value;
                    }
                }

                objectContext.Save();
                objectContext.Dispose();
            }

            TTAttribute autoDocumentRecordLogAttribute;
            objectDef.Attributes.TryGetValue(typeof(AutoDocumentRecordLogAttribute).Name, out autoDocumentRecordLogAttribute);
            if (autoDocumentRecordLogAttribute != null)
            {
                IList documentRecordLogs = DocumentRecordLogs.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(DocumentRecordLog.States.Completed));
                //                foreach (DocumentRecordLog documentRecordLog in documentRecordLogs)
                //                    documentRecordLog.PrintStateReports(parent);
            }
        }

        public void SetMKYS_Yil()
        {
            if (MKYS_MakbuzTarihi.HasValue)
                MKYS_Yil = MKYS_MakbuzTarihi.Value.Year;
        }

        public int? GetNextMKYS_MakbuzNo()
        {
            if (MKYS_DepoKayitNo.HasValue && MKYS_EButceTur.HasValue && MKYS_MakbuzTarihi.HasValue)
            {
                BindingList<StockAction.GetMaxMKYS_MakbuzNo_Class> makbuzList = StockAction.GetMaxMKYS_MakbuzNo(MKYS_DepoKayitNo.Value, MKYS_EButceTur.Value, MKYS_MakbuzTarihi.Value.Year);
                return Convert.ToInt32(makbuzList[0].Makbuzno) + 1;
            }

            return null;
        }

        public void CheckStockActionOutDetails()
        {
            string exception = string.Empty;
            BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = null;
            BindingList<StockTransaction.LOTOutableStockTransactionsBudgetType_Class> outableStockTransactionsByBudgetType = null;
            foreach (StockActionDetailOut item in StockActionDetails)
            {
                if (item is StockActionDetailOut)
                {
                    Stock stock = item.StockAction.Store.GetStock(item.Material);
                    if (item.StockAction.Store is MainStoreDefinition)
                    {
                        if (((MainStoreDefinition)(item.StockAction.Store)).MKYS_ButceTuru != null)
                        {
                            Guid budgetGuid = Guid.Empty;
                            TTObjectContext context = new TTObjectContext(false);
                            if (((MainStoreDefinition)item.StockAction.Store).MKYS_ButceTuru != null)
                            {
                                List<BudgetTypeDefinition> budgetTypeDefList = context.QueryObjects<BudgetTypeDefinition>("MKYS_BUTCE = " + Common.GetEnumValueDefOfEnumValue(((MainStoreDefinition)(item.StockAction.Store)).MKYS_ButceTuru.Value).Value).ToList();
                                if (budgetTypeDefList.Count == 1)
                                {
                                    budgetGuid = ((BudgetTypeDefinition)budgetTypeDefList[0]).ObjectID;
                                }
                                else if (budgetTypeDefList.Count > 1)
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25075", "1 den fazla b�t�e tipi tan�mlanm��t�r. Bilgi i�leme haber veriniz.!"));
                                }
                                else
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M27039", "Tan�ml� b�t�e tipi bulunamam��t�r. Bilgi i�leme haber veriniz.!"));
                                }
                            }

                            outableStockTransactionsByBudgetType = StockTransaction.LOTOutableStockTransactionsBudgetType(stock.ObjectID, budgetGuid);
                        }
                        else
                        {
                            outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
                        }
                    }
                    else
                    {
                        outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
                    }

                    if (SystemParameter.GetParameterValue("USELOTANDEXPIREDATE", "FALSE") == "FALSE")
                    {
                        if (outableStockTransactions != null)
                        {
                            foreach (StockTransaction.LOTOutableStockTransactions_Class lot in outableStockTransactions)
                            {
                                OuttableLot outtableLot = new OuttableLot(ObjectContext);
                                outtableLot.LotNo = lot.LotNo;
                                if (lot.ExpirationDate == null)
                                    outtableLot.ExpirationDate = DateTime.MinValue;
                                else
                                    outtableLot.ExpirationDate = lot.ExpirationDate;
                                outtableLot.RestAmount = CurrencyType.ConvertFrom(lot.Restamount);
                                outtableLot.Amount = CurrencyType.ConvertFrom(lot.Restamount);
                                outtableLot.isUse = true;
                                outtableLot.StockActionDetailOut = item;
                            }
                        }

                        if (outableStockTransactionsByBudgetType != null)
                        {
                            foreach (StockTransaction.LOTOutableStockTransactionsBudgetType_Class lot in outableStockTransactionsByBudgetType)
                            {
                                OuttableLot outtableLot = new OuttableLot(ObjectContext);
                                outtableLot.LotNo = lot.LotNo;
                                if (lot.ExpirationDate == null)
                                    outtableLot.ExpirationDate = DateTime.MinValue;
                                else
                                    outtableLot.ExpirationDate = lot.ExpirationDate;
                                outtableLot.RestAmount = CurrencyType.ConvertFrom(lot.Restamount);
                                outtableLot.Amount = CurrencyType.ConvertFrom(lot.Restamount);
                                outtableLot.isUse = true;
                                outtableLot.StockActionDetailOut = item;
                            }
                        }
                    }
                    else
                    {
                        if (outableStockTransactions.Count == 1)
                        {
                            OuttableLot outtableLot = new OuttableLot(ObjectContext);
                            outtableLot.LotNo = outableStockTransactions[0].LotNo;
                            if (outableStockTransactions[0].ExpirationDate == null)
                                outtableLot.ExpirationDate = DateTime.MinValue;
                            else
                                outtableLot.ExpirationDate = outableStockTransactions[0].ExpirationDate;
                            outtableLot.RestAmount = CurrencyType.ConvertFrom(outableStockTransactions[0].Restamount);
                            outtableLot.Amount = CurrencyType.ConvertFrom(outableStockTransactions[0].Restamount);
                            outtableLot.isUse = true;
                            outtableLot.StockActionDetailOut = item;
                        }
                    }

                    switch ((StockMethodEnum)item.Material.StockCard.StockMethod)
                    {
                        case StockMethodEnum.ExpirationDated:
                        case StockMethodEnum.LotUsed:
                            Currency restAmount = 0;
                            foreach (OuttableLot lot in item.OuttableLots)
                            {
                                if (lot.isUse == true)
                                {
                                    restAmount += (Currency)lot.RestAmount;
                                }
                            }

                            if (item.Amount > restAmount)
                            {
                                if (exception != "")
                                    exception += Environment.NewLine + item.Material.Name + " isimli malzemenin ��k�labilir giri�lerinde yeterli mevcut yoktur. Tekrar Se�iniz.";
                                else
                                    exception += item.Material.Name + " isimli malzemenin ��k�labilir giri�lerinde yeterli mevcut yoktur. Tekrar Se�iniz.";
                            }

                            break;
                        case StockMethodEnum.QRCodeUsed:
                            double packageAmount = (double)item.Material.PackageAmount;
                            Currency availAmount = (Currency)item.Amount % packageAmount;
                            double qrCodeCount = Math.Floor((double)item.Amount / packageAmount);
                            if (availAmount > 0)
                            {
                                double stockInheld = item.Material.StockInheld(item.StockAction.Store, item.StockLevelType);
                                if (stockInheld % packageAmount == 0)
                                    qrCodeCount = qrCodeCount + 1;
                            }

                            if (qrCodeCount != item.QRCodeOutDetails.Count)
                            {
                                if (exception != "")
                                    exception += Environment.NewLine + item.Material.Name + " isimli malzemenin kare kod detaylar� eksik girilmi� veya girilmemi�tir. Tekrar Se�iniz.";
                                else
                                    exception += item.Material.Name + " isimli malzemenin kare kod detaylar� eksik girilmi� veya girilmemi�tir. Tekrar Se�iniz.";
                            }

                            break;
                        case StockMethodEnum.SerialNumbered:
                            if (item.Amount > item.FixedAssetOutDetails.Count || item.FixedAssetOutDetails.Count == 0)
                            {
                                if (exception != "")
                                    exception += Environment.NewLine + item.Material.Name + " isimli malzemenin demirba� detaylar� eksik girilmi� veya girilmemi�tir. Tekrar Se�iniz.";
                                else
                                    exception += item.Material.Name + " isimli malzemenin demirba� detaylar� eksik girilmi� veya girilmemi�tir. Tekrar Se�iniz.";
                            }

                            break;
                        case StockMethodEnum.StockNumbered:
                        default:
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(exception))
                throw new TTException(exception);
        }



        public class DocumentRecordLogContent
        {
            private DocumentTransactionTypeEnum _transactionType;
            public DocumentTransactionTypeEnum TransactionType
            {
                get { return _transactionType; }
            }

            private StockAction _stockAction;
            public StockAction StockAction
            {
                get { return _stockAction; }
            }

            private int _numberOfRows;
            public int NumberOfRows
            {
                get { return _numberOfRows; }
            }

            private string _takenGivenPlace;
            public string TakenGivenPlace
            {
                get { return _takenGivenPlace; }
            }

            private string _description;
            public string Descriptions
            {
                get { return _description; }
            }


            private MKYS_EButceTurEnum _butceTur;
            public MKYS_EButceTurEnum ButceTur
            {
                get { return _butceTur; }
            }

            public DocumentRecordLogContent(DocumentTransactionTypeEnum transactionType, StockAction stockAction, int numberOfRows, string takenGivenPlace, MKYS_EButceTurEnum butceTur)
            {
                _transactionType = transactionType;
                _stockAction = stockAction;
                _numberOfRows = numberOfRows;
                _takenGivenPlace = takenGivenPlace;
                _butceTur = butceTur;

            }
            public DocumentRecordLogContent(DocumentTransactionTypeEnum transactionType, StockAction stockAction, int numberOfRows, string takenGivenPlace, MKYS_EButceTurEnum butceTur, string description)
            {
                _transactionType = transactionType;
                _stockAction = stockAction;
                _numberOfRows = numberOfRows;
                _takenGivenPlace = takenGivenPlace;
                _butceTur = butceTur;
                _description = description;
            }
        }

        public void CreateStockActionNewDocumentRecordLog(StockAction.DocumentRecordLogContent documentRecordLogContent)
        {
            DocumentRecordLog documentRecordLog = new DocumentRecordLog(ObjectContext);
            documentRecordLog.StockAction = documentRecordLogContent.StockAction;
            TTObjectContext context = new TTObjectContext(true);
            IBindingList activeList = context.QueryObjects("ACCOUNTINGTERM", "STATUS = '1' ");
            Guid documentRecordLogSequenceID = new Guid("38b068a4-81c5-4a47-b8d3-efd350ef3ee5");
            string filterTXT = ((MainStoreDefinition)(documentRecordLogContent.StockAction.Store)).Accountancy.ObjectID.ToString() + "_" + ((MKYS_EButceTurEnum)documentRecordLogContent.ButceTur).ToString();
            if (documentRecordLogContent.StockAction.ClonedObjectID != null)
            {
                StockAction cloneedStockAction = (StockAction)ObjectContext.GetObject(documentRecordLogContent.StockAction.ClonedObjectID.Value, typeof(StockAction));
                if (documentRecordLogContent.StockAction.AccountingTerm == cloneedStockAction.AccountingTerm)
                {
                    DocumentRecordLog findDocument = cloneedStockAction.DocumentRecordLogs.Where(x => x.BudgeType == documentRecordLogContent.ButceTur).FirstOrDefault();
                    if (findDocument != null)
                    {
                        documentRecordLog.DocumentRecordLogNumber = findDocument.DocumentRecordLogNumber;
                    }
                    else
                    {
                        documentRecordLog.DocumentRecordLogNumber = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[documentRecordLogSequenceID], filterTXT, ((AccountingTerm)activeList[0]).TermYear.Value);
                    }
                }
                else
                {
                    documentRecordLog.DocumentRecordLogNumber = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[documentRecordLogSequenceID], filterTXT, ((AccountingTerm)activeList[0]).TermYear.Value);
                }

            }
            else
            {
                documentRecordLog.DocumentRecordLogNumber = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[documentRecordLogSequenceID], filterTXT, ((AccountingTerm)activeList[0]).TermYear.Value);
                //documentRecordLog.DocumentRecordLogNumber.GetNextValue(documentRecordLogContent.StockAction.AccountingTerm.Accountancy.ObjectID.ToString() + "_" + ((MKYS_EButceTurEnum)documentRecordLogContent.ButceTur).ToString(), documentRecordLogContent.StockAction.AccountingTerm.TermYear.Value);
            }
            documentRecordLog.DocumentTransactionType = documentRecordLogContent.TransactionType;
            documentRecordLog.DocumentDateTime = documentRecordLogContent.StockAction.TransactionDate;
            documentRecordLog.NumberOfRows = documentRecordLogContent.NumberOfRows;
            documentRecordLog.Subject = documentRecordLogContent.StockAction.ObjectDef.ApplicationName;
            documentRecordLog.TakenGivenPlace = documentRecordLogContent.TakenGivenPlace;
            documentRecordLog.BudgeType = documentRecordLogContent.ButceTur;
            documentRecordLog.MKYSStatus = MKYSControlEnum.Completed;
            if (documentRecordLogContent.StockAction is ProductionConsumptionDocument)
                documentRecordLog.Descriptions = documentRecordLogContent.StockAction.Description;
            if (documentRecordLogContent.StockAction is ReviewAction)
                documentRecordLog.Descriptions = documentRecordLogContent.Descriptions;
            documentRecordLog.CurrentStateDefID = DocumentRecordLog.States.New;
            documentRecordLog.Update();
            documentRecordLog.CurrentStateDefID = DocumentRecordLog.States.Completed;

        }
        public void UpdateStockActionDocumentRecordLog(StockAction.DocumentRecordLogContent documentRecordLogContent)
        {
            IList documentRecordLogs = documentRecordLogContent.StockAction.DocumentRecordLogs.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(DocumentRecordLog.States.Completed) + " AND DOCUMENTTRANSACTIONTYPE = " + (int)documentRecordLogContent.TransactionType);
            foreach (DocumentRecordLog documentRecordLog in documentRecordLogs)
            {
                ((ITTObject)documentRecordLog).UndoLastTransition(TTUtils.CultureService.GetText("M25750", "G�ncelleme nedeniyle."));
                documentRecordLog.Update();
                documentRecordLog.NumberOfRows = documentRecordLog.NumberOfRows;
                documentRecordLog.TakenGivenPlace = documentRecordLog.TakenGivenPlace;
                documentRecordLog.BudgeType = documentRecordLog.BudgeType;
                documentRecordLog.CurrentStateDefID = DocumentRecordLog.States.Completed;
            }
        }




        #endregion Methods
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockAction).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == StockAction.States.New && toState == StockAction.States.Completed)
                PreTransition_New2Completed();
            else if (fromState == StockAction.States.New && toState == StockAction.States.Cancelled)
                PreTransition_New2Cancelled();
            else if (fromState == StockAction.States.Completed && toState == StockAction.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockAction).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == StockAction.States.New && toState == StockAction.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == StockAction.States.New && toState == StockAction.States.Cancelled)
                UndoTransition_New2Cancelled(transDef);
            else if (fromState == StockAction.States.Completed && toState == StockAction.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }


    }
}