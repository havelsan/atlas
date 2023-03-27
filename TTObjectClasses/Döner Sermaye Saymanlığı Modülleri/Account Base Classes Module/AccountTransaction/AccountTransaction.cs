
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
    /// İşlem Hareketi
    /// </summary>
    public partial class AccountTransaction : TTObject
    {
        public partial class OLAP_GetSubactionAccTransaction_Class : TTReportNqlObject
        {
        }

        public partial class GetToBeNewTrxsByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetIncomesFromDepartment_Class : TTReportNqlObject
        {
        }

        public partial class DetailedRevenueListProcedureQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialListByDateAndDepartment_Class : TTReportNqlObject
        {
        }

        public partial class GetNotInvoicedPatientListByPatientStatus_Class : TTReportNqlObject
        {
        }

        public partial class DetailedRevenueListMaterialQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialTrxsByHospitalProtocolNo_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientParticipationTransactions_Class : TTReportNqlObject
        {
        }

        public partial class CollectedInvoiceProcedureDetailReportQueryCheck_Class : TTReportNqlObject
        {
        }

        public partial class GetProcedureTrxsByHospitalProtocolNo_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugTrxsByHospitalProtocolNo_Class : TTReportNqlObject
        {
        }

        public partial class GetProcedureIncomesByMasterResource_Class : TTReportNqlObject
        {
        }

        public partial class CollInvoiceDetailedRevenueListMaterialQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaDontSendDrugTrxsByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaDontSendProcedureTrxsByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaDontSendMaterialTrxsByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetTransactionsForMedulaBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialIncomesByMasterResource_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialIncomesByRessection_Class : TTReportNqlObject
        {
        }

        public partial class GetDrugIncomesByRessection_Class : TTReportNqlObject
        {
        }

        public partial class GetCountForMedulaBySEP_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialTrxsBySEPAndCode_Class : TTReportNqlObject
        {
        }

        public partial class GetProcedureIncomesByRessection_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientTotalNotPaid_Class : TTReportNqlObject
        {
        }

        public partial class GetPayerTotalPriceBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaEntryPriceBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaTransactionsBySEPAndState_Class : TTReportNqlObject
        {
        }

        public partial class CollectedInvoiceProcDetPreviewReportQuery1_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetInvoiceByResource_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetInvoiceByPharmacyResource_Class : TTReportNqlObject
        {
        }

        public partial class CollectedInvoiceProcDetPreviewReportQuery2_Class : TTReportNqlObject
        {
        }

        public partial class GetOrthesisProsthesisByProtocolNoAndYear_Class : TTReportNqlObject
        {
        }

        public partial class GetPackageTrxsByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetOrthesisProsthesisByProcedureAndDate_Class : TTReportNqlObject
        {
        }

        public partial class CollInvoiceDetailedRevenueListProcedureQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaTransactionCountBySEPAndState_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientTotalPriceBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetPayerTotalPriceByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientTotalPriceByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class CollInvoiceDetailedRevenueListMaterialQuery_NP_Class : TTReportNqlObject
        {
        }

        public partial class CollInvoiceDetailedRevenueListProcedureQuery_NP_Class : TTReportNqlObject
        {
        }

        public string MedulaTransactionDate
        {
            get
            {
                try
                {
                    #region MedulaTransactionDate_GetScript                    
                    if (TransactionDate.HasValue)
                        return TransactionDate.Value.ToString("dd.MM.yyyy");

                    return null;
                    #endregion MedulaTransactionDate_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MedulaTransactionDate") + " : " + ex.Message, ex);
                }
            }
        }

        public string MedulaProcedureCode
        {
            get
            {
                try
                {
                    #region MedulaProcedureCode_GetScript                    
                    if (SubActionProcedure != null)
                    {
                        // Vaka Başı hizmetlerinin kodu "P520030" gitmeli
                        if (SubActionProcedure.ProcedureObject != null && SubActionProcedure.ProcedureObject is BulletinProcedureDefinition)
                            return "P520030";

                        if (ExternalCode != null)
                            return ExternalCode;

                        if (PricingDetail != null)
                            return PricingDetail.ExternalCode;

                        if (SubActionProcedure.ProcedureObject != null)
                            return SubActionProcedure.ProcedureObject.Code;
                    }

                    return null;
                    #endregion MedulaProcedureCode_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MedulaProcedureCode") + " : " + ex.Message, ex);
                }
            }
        }

        public string MedulaMaterialCode
        {
            get
            {
                try
                {
                    #region MedulaMaterialCode_GetScript                    
                    if (SubActionMaterial != null)
                    {
                        // 10.10.2017 de değiştirildi, malzeme tanımından baksın herzaman diye
                        //if (!string.IsNullOrEmpty(this.ExternalCode))
                        //    return this.ExternalCode.Replace(".", "").Trim();

                        //if (this.PricingDetail != null && !string.IsNullOrEmpty(this.PricingDetail.ExternalCode))
                        //    return this.PricingDetail.ExternalCode.Replace(".", "").Trim();

                        if (SubActionMaterial.Material != null && !string.IsNullOrEmpty(SubActionMaterial.Material.Code))
                            return SubActionMaterial.Material.Code.Replace(".", "").Trim();
                    }

                    return null;
                    #endregion MedulaMaterialCode_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MedulaMaterialCode") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula Referans Numarası
        /// </summary>
        public string MedulaReferenceNumber
        {
            get
            {
                try
                {
                    #region MedulaReferenceNumber_GetScript                    
                    if (Id.Value != null)
                        return "H" + Id.Value.ToString();

                    return null;
                    #endregion MedulaReferenceNumber_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MedulaReferenceNumber") + " : " + ex.Message, ex);
                }
            }
        }

        public string MedulaPackageInOut
        {
            get
            {
                try
                {
                    #region MedulaPackageInOut_GetScript                    
                    if (InvoiceInclusion == true)
                        return "1";
                    else
                        return "0";
                    #endregion MedulaPackageInOut_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MedulaPackageInOut") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();

            if (Amount < 0 || UnitPrice < 0)
                throw new TTException("Fatura kaleminin miktarı veya fiyatı sıfırdan küçük olamaz !\n\rHizmet/Malzeme : " + ExternalCode + " " + Description + " (" + TransactionDate.ToString() + ")");

            //if (this.SubActionProcedure != null && this.SubActionProcedure is PMAddingPSProcedure && this.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
            //    throw new TTException("Hizmet Malzeme Giriş (Hasta Payı) işleminden girilen hizmetin kurum payı tipinde bir hareketi olamaz!\n\rHizmet : " + this.SubActionProcedure.ProcedureObject.Code + " " + this.SubActionProcedure.ProcedureObject.Name);
            //else if (this.SubActionMaterial != null && this.SubActionMaterial is PMAddingPSMaterial && this.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
            //    throw new TTException("Hizmet Malzeme Giriş (Hasta Payı) işleminden girilen ilaç/malzemenin kurum payı tipinde bir hareketi olamaz!\n\rİlaç/Malzeme : " + this.SubActionMaterial.Material.Code + " " + this.SubActionMaterial.Material.Name);

            MedulaPreProcedureEntryControl();
            //CheckToCreateInMedulaDontSendState();
            CheckForInvoiceInclusion();
            MedulaOzelDurumEkle();
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            // Yeni AccTrx oluştuğunda, Takip "Hizmet Kaydı Tamamlandı" durumunda ise "Hizmet Kaydı Tamamlanmadı" durumuna almak lazım
            if (CurrentStateDefID == AccountTransaction.States.New || CurrentStateDefID == AccountTransaction.States.ToBeNew)
            {
                if (IsMedulaAccountTransaction())
                {
                    //Günübirlik takiplerde işlem tarihi ile takip tarihi arasında 1 günden fazla fark varsa işlem tarihi değiştirilir
                    SetTransactionDateForDailySGKSEP();

                    // Fatura Kayıt bekleyen veya Faturalandı durumundaki takibe hizmet eklenememeli
                    if (SubEpisodeProtocol.IsInvoiced)
                        throw new TTUtils.TTException("Fatura Kaydı Bekleyen veya Faturalandı durumundaki takip içerisine yeni hizmet eklenemez. (Takip No: " + SubEpisodeProtocol.MedulaTakipNo + ")");

                    if (SubEpisodeProtocol.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProvisionNoNotExists && SubEpisodeProtocol.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProcedureEntryWithError)
                        SubEpisodeProtocol.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;

                    // Hizmet Tanımına bakılıp gerekiyorsa Takibin Provizyon Tipi, Takip Tipi ve Tedavi Tipi Medula'da güncellenir
                    UpdateSGKSEP();
                }
            }
            else if (CurrentStateDefID == AccountTransaction.States.MedulaDontSend)
                InvoiceInclusion = false;

            // Hizmet tanımında Özel Durum varsa, AccountTransaction ın özel durumu olarak set edilir.
            if (IsMedulaAccountTransaction())
            {
                if (SubActionProcedure != null && SubActionProcedure.ProcedureObject != null && SubActionProcedure.ProcedureObject.OzelDurum != null)
                    OzelDurum = SubActionProcedure.ProcedureObject.OzelDurum;
            }

            ControlSubepisodeForDailyBedProcedure();

            UpdateMRAndBTPrices(OperationTypeEnum.Insert);

            CreateSendToENabiz();

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();

            if (Amount < 0 || UnitPrice < 0)
                throw new TTException("Fatura kaleminin miktarı veya fiyatı sıfırdan küçük olamaz !\n\rHizmet/Malzeme : " + ExternalCode + " " + Description + " (" + TransactionDate.ToString() + ")");

            //if (this.SubActionProcedure != null && this.SubActionProcedure is PMAddingPSProcedure && this.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
            //    throw new TTException("Hizmet Malzeme Giriş (Hasta Payı) işleminden girilen hizmetin kurum payı tipinde bir hareketi olamaz!\n\rHizmet : " + this.SubActionProcedure.ProcedureObject.Code + " " + this.SubActionProcedure.ProcedureObject.Name);
            //else if (this.SubActionMaterial != null && this.SubActionMaterial is PMAddingPSMaterial && this.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
            //    throw new TTException("Hizmet Malzeme Giriş (Hasta Payı) işleminden girilen ilaç/malzemenin kurum payı tipinde bir hareketi olamaz!\n\rİlaç/Malzeme : " + this.SubActionMaterial.Material.Code + " " + this.SubActionMaterial.Material.Name);

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            if (CurrentStateDefID == AccountTransaction.States.New)
            {
                if (IsMedulaAccountTransaction())
                {
                    //Günübirlik takiplerde işlem tarihi ile takip tarihi arasında 1 günden fazla fark varsa işlem tarihi değiştirilir
                    SetTransactionDateForDailySGKSEP();

                    // AccountTransaction ın update ten önceki orjinal hali alınır
                    TTObjectContext objContext = new TTObjectContext(true);
                    AccountTransaction originalAccTrx = objContext.GetObject(ObjectID, ObjectDef, false) as AccountTransaction;

                    if (originalAccTrx != null)
                    {
                        if (originalAccTrx.CurrentStateDefID != AccountTransaction.States.New)
                        {
                            // Fatura Kayıt bekleyen veya Faturalandı durumundaki takibe hizmet eklenememeli
                            if (SubEpisodeProtocol.IsInvoiced)
                                throw new TTUtils.TTException("Fatura Kaydı Bekleyen veya Faturalandı durumundaki takip içerisine yeni hizmet eklenemez. (Takip No: " + SubEpisodeProtocol.MedulaTakipNo + ")");
                        }

                        // Yeni durumuna geçilmiş ise Takip i "Hizmet Kaydı Tamamlanmadı" durumuna almak gerekir
                        if (originalAccTrx.CurrentStateDefID == AccountTransaction.States.MedulaDontSend ||
                            originalAccTrx.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful ||
                            originalAccTrx.CurrentStateDefID == AccountTransaction.States.Cancelled ||
                            originalAccTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        {
                            if (SubEpisodeProtocol.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProvisionNoNotExists && SubEpisodeProtocol.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProcedureEntryWithError)
                                SubEpisodeProtocol.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                        }

                        // Hizmet Tanımına bakılıp gerekiyorsa Takibin Provizyon Tipi, Takip Tipi ve Tedavi Tipi Medula'da güncellenir
                        if (originalAccTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                            UpdateSGKSEP();
                    }
                }
            }
            else if (CurrentStateDefID == AccountTransaction.States.MedulaDontSend)
            {
                InvoiceInclusion = false;
                if (Nabiz700Status == SendToENabizEnum.UnSuccessful)
                    Nabiz700Status = SendToENabizEnum.ToBeSent;
            }
            else if (CurrentStateDefID == AccountTransaction.States.Cancelled)
            {
                if (SubActionMaterial != null)
                {   // ENabizMaterial iptal edilir
                    TTObjectContext objContext = new TTObjectContext(true);
                    AccountTransaction originalAccTrx = objContext.GetObject(ObjectID, ObjectDef, false) as AccountTransaction;

                    if (originalAccTrx != null)
                    {
                        if (originalAccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                        {
                            ENabizMaterial eNabizMaterial = SubActionMaterial.ENabizMaterials.Select("").FirstOrDefault(x => x.CurrentStateDefID == TTObjectClasses.ENabizMaterial.States.Completed && x.AccountTransaction.ObjectID == ObjectID);
                            if (eNabizMaterial != null)
                                eNabizMaterial.CurrentStateDefID = TTObjectClasses.ENabizMaterial.States.Cancelled;
                        }
                    }
                }
            }

            // Medula İşlem Sıra Numarası dolu ise "Hizmet Kaydı Başarılı" dan başka bir durumda olamamalı
            if (!string.IsNullOrEmpty(MedulaProcessNo) && CurrentStateDefID != AccountTransaction.States.MedulaEntrySuccessful && CurrentStateDefID != AccountTransaction.States.Invoiced)
                throw new TTUtils.TTException("Medula İşlem Sıra Numarası dolu olan hizmet/malzeme 'Hizmet Kaydı Başarılı' veya 'Faturalandı' dan başka bir durumda olamaz. (Hizmet/Malzeme: " + ExternalCode + " " + Description + " (Hizmet Sunucu Referans No: " + Id.Value.ToString() + " , Medula İşlem Sıra No: " + MedulaProcessNo + "))");

            UpdateMRAndBTPrices(OperationTypeEnum.Update);

            #endregion PostUpdate
        }

        public enum OperationTypeEnum
        {
            Insert = 0,
            Update = 1,
            Delete = 2
        }

        public enum MRBTEnum
        {
            MR = 0,
            BT = 1
        }

        private class SubActionProcedurePrice
        {
            public SubActionProcedure subActionProcedure;
            public Decimal price;
        }

        private class SPObjectIDPriceListComparer : IComparer<AccountTransaction.SubActionProcedurePrice>
        {
            public int Compare(AccountTransaction.SubActionProcedurePrice x, AccountTransaction.SubActionProcedurePrice y)
            {
                return x.price.CompareTo(y.price);
            }
        }

        public void UpdateMRAndBTPrices(OperationTypeEnum operationType)
        {
            if (SubActionProcedure != null && SubActionProcedure.ProcedureObject != null)
            {
                MRBTEnum? MRBT = null;

                if (SubActionProcedure.ProcedureObject.IsMR)
                    MRBT = MRBTEnum.MR;
                else if (SubActionProcedure.ProcedureObject.IsBT)
                    MRBT = MRBTEnum.BT;

                if (MRBT.HasValue)
                {
                    if (operationType == OperationTypeEnum.Insert)
                    {
                        if (CurrentStateDefID != AccountTransaction.States.Cancelled)
                            ArrangeMRAndBTPrices(MRBT.Value, this?.SubEpisodeProtocol?.SEPMaster, TransactionDate);
                    }
                    else if (operationType == OperationTypeEnum.Update)
                    {
                        TTObjectContext roContext = new TTObjectContext(true);
                        AccountTransaction originalAccTrx = roContext.GetObject(ObjectID, ObjectDef, false) as AccountTransaction;
                        if (originalAccTrx != null)
                        {
                            // Tarih veya Başvuru değiştiğinde originalAccTrx için ArrangeMRAndBTPrices metodunu çağırmak gerekiyor
                            if (originalAccTrx.TransactionDate.Value.Date != TransactionDate.Value.Date ||
                                originalAccTrx.SubEpisodeProtocol.SEPMaster.ObjectID != SubEpisodeProtocol.SEPMaster.ObjectID)
                            {
                                SEPMaster originalSEPMaster = ObjectContext.GetObject<SEPMaster>(originalAccTrx.SubEpisodeProtocol.SEPMaster.ObjectID, false);
                                ArrangeMRAndBTPrices(MRBT.Value, originalSEPMaster, originalAccTrx.TransactionDate); // AccTrx in eski tarih ve başvurusundaki fiyat güncellemeleri için 
                            }

                            // Tarih, Başvuru veya State değiştiğinde (AccTrx in şimdiki tarih ve başvurusundaki fiyat güncellemeleri için )
                            if (originalAccTrx.TransactionDate.Value.Date != TransactionDate.Value.Date ||
                                originalAccTrx.SubEpisodeProtocol.SEPMaster.ObjectID != SubEpisodeProtocol.SEPMaster.ObjectID ||
                                (originalAccTrx.CurrentStateDefID == AccountTransaction.States.Cancelled && CurrentStateDefID != AccountTransaction.States.Cancelled) ||
                                (originalAccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && CurrentStateDefID == AccountTransaction.States.Cancelled))

                                ArrangeMRAndBTPrices(MRBT.Value, this?.SubEpisodeProtocol?.SEPMaster, TransactionDate);
                        }
                    }
                }
            }
        }

        // Aynı gün birden fazla MR ve BT hizmeti varsa yüksek fiyatlı hizmetin %100, diğer hizmetlerin fiyatının %50 olarak hesaplanmasını sağlayan metod
        public static void ArrangeMRAndBTPrices(MRBTEnum MRBT, SEPMaster sepMaster, DateTime? pricingDate)
        {
            if (sepMaster != null && pricingDate.HasValue)
            {
                List<AccountTransaction.SubActionProcedurePrice> SPPriceList = new List<AccountTransaction.SubActionProcedurePrice>();

                foreach (SubEpisodeProtocol sep in sepMaster.SubEpisodeProtocols.Where(x => x.IsCancelled == false))
                {
                    foreach (AccountTransaction accTrx in sep.AccountTransactions.Select("").Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.SubActionProcedure != null && x.TransactionDate.Value.Date == pricingDate.Value.Date))
                    {
                        if ((MRBT == MRBTEnum.MR && accTrx?.SubActionProcedure?.ProcedureObject?.IsMR == true) || (MRBT == MRBTEnum.BT && accTrx?.SubActionProcedure?.ProcedureObject?.IsBT == true))
                        {
                            if (SPPriceList.Any(x => x.subActionProcedure.ObjectID == accTrx.SubActionProcedure.ObjectID) == false)
                            {
                                if (accTrx.PricingDetail == null) // Fiyat tanımından ücretlenmemişse çıkılır (ilerde fiyat tanımından ücretlenmeyenler için ekleme yapılabilir) MDZ
                                    return;

                                AccountTransaction.SubActionProcedurePrice SPPrice = new AccountTransaction.SubActionProcedurePrice();
                                SPPrice.subActionProcedure = accTrx.SubActionProcedure;
                                SPPrice.price = Convert.ToDecimal(accTrx.PricingDetail.Price);
                                SPPriceList.Add(SPPrice);
                            }
                        }
                    }
                }

                SPPriceList.Sort(new AccountTransaction.SPObjectIDPriceListComparer()); // SPList Price a göre artan sıralanır

                for (int i = 0; i < SPPriceList.Count; i++)
                {
                    SubActionProcedure sp = SPPriceList[i].subActionProcedure;

                    List<AccountTransaction> notCancelledAccTrxs = sp.AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled).ToList();
                    if (notCancelledAccTrxs.Where(x => x.IsAllowedToChangeUnitPrice == false).Any()) // Durumu fiyat update etmeye uygun olmayan accTrx varsa o SubActionProcedure atlanır
                        continue;

                    // Hizmetin fiyatı yeniden hesaplanarak AccTrx.UnitPrice lar set edilir, sonra da fiyatı en yüksek olan dışındakilerin fiyatı %50 düşürülür
                    ArrayList col = new ArrayList();
                    col = notCancelledAccTrxs[0].SubEpisodeProtocol.Protocol.CalculatePrice(sp.ProcedureObject, sp.EpisodeAction.Episode.PatientStatus, null, sp.PricingDate, sp.EpisodeAction.Episode.Patient.AgeCompleted);

                    if (col.Count == 0)
                        throw new TTException(SystemMessage.GetMessageV3(950, new string[] { sp.ProcedureObject.Name }));

                    double payerPrice = Convert.ToDouble(((ManipulatedPrice)col[0]).PayerPrice);
                    double patientPrice = Convert.ToDouble(((ManipulatedPrice)col[0]).PatientPrice);

                    foreach (AccountTransaction accTrx in notCancelledAccTrxs)
                    {
                        if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                            accTrx.UnitPrice = Math.Round(payerPrice, 2);

                        if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
                            accTrx.UnitPrice = Math.Round(patientPrice, 2);

                        if (i != SPPriceList.Count - 1) // Fiyatı en yüksek olan hizmet dışındakilerin fiyat %50 düşürülür
                            accTrx.UnitPrice = Math.Round((accTrx.UnitPrice.Value / 2), 2);
                    }
                }
            }
        }

        public override void OnContextDispose()
        {
            base.OnContextDispose();
            _remainingPrice = RemainingPrice;
        }

        private Currency? _remainingPrice = null;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public Currency RemainingPrice
        {
            get
            {
                if (_remainingPrice != null)
                    return _remainingPrice.Value;
                else if ((Amount.Value * UnitPrice.Value) - PaidPrice < 0)
                    throw new TTException(TTUtils.CultureService.GetText("M25962", "Hizmet/Malzeme bedeli için ödenecek bir tutar bulunmamaktadır."));
                else
                    return (Amount.Value * UnitPrice.Value) - PaidPrice;
            }
        }

        public Currency PaidPrice
        {
            get
            {
                if (PatientPaymentDetail != null && PatientPaymentDetail.Count > 0)
                    return PatientPaymentDetail.Where(x => x.AccountTransaction.ObjectID == ObjectID && x.IsCancel == false && x.IsBack == false).Sum(x => (decimal)x.PaymentPrice);
                else
                    return 0;
            }
        }

        #region Methods


        // Günübirlik takipler için işlem tarihi ile takip tarihi arasında 1 günden fazla varsa, işlem tarihini takip tarihi ile günceller
        public void SetTransactionDateForDailySGKSEP()
        {
            if (SubEpisodeProtocol != null && SubEpisodeProtocol.MedulaTedaviTuru != null && !string.IsNullOrEmpty(SubEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu))
            {
                if (SubEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu.Equals("G")) // Takibin Tedavi Türü "Günübirlik" ise
                {
                    // "3200 : Radyasyon Onkolojisi" branşı için işlem tarihlerinin değişmemesi gerekiyor (istisna branş)
                    if ((SubEpisodeProtocol.Brans != null && !SubEpisodeProtocol.Brans.Code.Equals("3200")) || SubEpisodeProtocol.Brans == null)
                    {
                        if (TransactionDate.HasValue && SubEpisodeProtocol.MedulaProvizyonTarihi.HasValue)
                        {
                            int daysDiff = TransactionDate.Value.Date.Subtract(SubEpisodeProtocol.MedulaProvizyonTarihi.Value.Date).Days;
                            if (daysDiff > 1)
                            {
                                try
                                {
                                    TransactionDate = SubEpisodeProtocol.MedulaProvizyonTarihi;
                                }
                                catch (Exception ex) { }
                            }
                        }
                    }
                }
            }
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
                Id.GetNextValue();
        }

        public bool IsMedulaAccountTransaction()
        {
            if (AccountPayableReceivable.Type == APRTypeEnum.PAYER)
            {
                if (SubEpisodeProtocol != null && SubEpisodeProtocol.IsSGK)
                    return true;
            }
            return false;
        }

        public static BindingList<AccountTransaction> GetByIdv2(List<int> IdList)
        {
            BindingList<AccountTransaction> accTrxList = new BindingList<AccountTransaction>();
            if (IdList.Count > 0)
            {
                TTObjectContext context = new TTObjectContext(true);
                accTrxList = AccountTransaction.GetById(context, IdList);
            }
            return accTrxList;
        }

        /*
        public bool IsNotAllowedToCancel
        {
            get
            {
                if (this.CurrentStateDefID != AccountTransaction.States.New &&
                    this.CurrentStateDefID != AccountTransaction.States.ToBeNew &&
                    this.CurrentStateDefID != AccountTransaction.States.Cancelled &&
                    this.CurrentStateDefID != AccountTransaction.States.MedulaDontSend &&
                    this.CurrentStateDefID != AccountTransaction.States.MedulaEntryUnsuccessful)
                    return true;

                return false;
            }
        }
        */

        public bool IsAllowedToChangeUnitPrice
        {
            get
            {
                if (CurrentStateDefID == AccountTransaction.States.ToBeNew ||
                    CurrentStateDefID == AccountTransaction.States.MedulaDontSend ||
                    CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful ||
                    CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful)
                    return true;

                if (CurrentStateDefID == AccountTransaction.States.New)
                {
                    if (AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                        return true;
                    else if (AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
                    {
                        if (PaidPrice > 0)
                            return false;
                        else
                            return true;
                    }
                }

                return false;
            }
        }

        public bool IsAllowedToCancel
        {
            get
            {
                if (CurrentStateDefID == AccountTransaction.States.ToBeNew ||
                    CurrentStateDefID == AccountTransaction.States.MedulaDontSend ||
                    CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful)
                    return true;

                if (CurrentStateDefID == AccountTransaction.States.New)
                {
                    if (AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                        return true;
                    else if (AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
                    {
                        if (PaidPrice > 0)
                            return false;
                        else
                            return true;
                    }
                }

                return false;
            }
        }

        public bool IsAllowedToArrangeInvoiceInclusion
        {
            get
            {
                if (CurrentStateDefID == AccountTransaction.States.New ||
                    CurrentStateDefID == AccountTransaction.States.ToBeNew ||
                    CurrentStateDefID == AccountTransaction.States.MedulaDontSend ||
                    CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful)
                {
                    if ((AccountPayableReceivable.Type == APRTypeEnum.PATIENT && SubEpisodeProtocol.Payer.Type.PayerType != PayerTypeEnum.Paid) == false)
                        return true;
                }
                return false;
            }
        }

        public void ControlToSetInvoiceInclusion()
        {
            if (SubEpisodeProtocol == null)
                return;

            if (IsAllowedToArrangeInvoiceInclusion)
            {
                InvoiceInclusionResultEnum result;
                if (SubActionProcedure != null && SubActionProcedure.ProcedureObject != null)
                    result = SubEpisodeProtocol.GetTransactionInclusionInfo(SubActionProcedure.ProcedureObject);
                else if (SubActionMaterial != null && SubActionMaterial.Material != null)
                    result = SubEpisodeProtocol.GetTransactionInclusionInfo(SubActionMaterial.Material);
                else
                    return;

                SetInvoiceInclusion(result);
            }
        }

        public void SetInvoiceInclusion(InvoiceInclusionResultEnum result)
        {
            if (result == InvoiceInclusionResultEnum.Included)
            {
                InvoiceInclusion = true;
                if (CurrentStateDefID != AccountTransaction.States.New && CurrentStateDefID != AccountTransaction.States.ToBeNew)
                    CurrentStateDefID = AccountTransaction.States.New;
            }
            else if (result == InvoiceInclusionResultEnum.ForInfo)
            {
                InvoiceInclusion = false;
                if (CurrentStateDefID != AccountTransaction.States.New && CurrentStateDefID != AccountTransaction.States.ToBeNew)
                    CurrentStateDefID = AccountTransaction.States.New;
            }
            else if (result == InvoiceInclusionResultEnum.DoNotSendToMedula)
            {
                InvoiceInclusion = false;
                CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
            }
        }

        public void MedulaPreProcedureEntryControl()
        {
            if (SubActionProcedure != null && SubActionProcedure.ProcedureObject != null && SubActionProcedure.ProcedureObject.PreProcedureEntryNecessity == true)
            {
                if (AccountPayableReceivable.Type == APRTypeEnum.PAYER && SubEpisodeProtocol.SubEpisode != null)
                {
                    if (SubEpisodeProtocol.IsSGK && !string.IsNullOrEmpty(SubEpisodeProtocol.MedulaTakipNo))
                    {
                        HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO = new HizmetKayitIslemleri.hizmetKayitGirisDVO();
                        hizmetKayitGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                        hizmetKayitGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
                        hizmetKayitGirisDVO.hastaBasvuruNo = SubEpisodeProtocol.MedulaBasvuruNo;
                        hizmetKayitGirisDVO.takipNo = SubEpisodeProtocol.MedulaTakipNo;
                        hizmetKayitGirisDVO.triajBeyani = SubEpisodeProtocol.Triaj;

                        object obj = null;
                        if (SubActionProcedure != null)
                            obj = SubActionProcedure.GetDVO(this);

                        string tempHizSunucuNo = Guid.NewGuid().ToString().Substring(0, 20);
                        if (obj is HizmetKayitIslemleri.muayeneBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.muayeneBilgisi = (HizmetKayitIslemleri.muayeneBilgisiDVO)obj;
                            hizmetKayitGirisDVO.muayeneBilgisi.hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.ameliyatveGirisimBilgileri = new HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO[1];
                            hizmetKayitGirisDVO.ameliyatveGirisimBilgileri[0] = (HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)obj;
                            hizmetKayitGirisDVO.ameliyatveGirisimBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.digerIslemBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.digerIslemBilgileri = new HizmetKayitIslemleri.digerIslemBilgisiDVO[1];
                            hizmetKayitGirisDVO.digerIslemBilgileri[0] = (HizmetKayitIslemleri.digerIslemBilgisiDVO)obj;
                            hizmetKayitGirisDVO.digerIslemBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.disBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.disBilgileri = new HizmetKayitIslemleri.disBilgisiDVO[1];
                            hizmetKayitGirisDVO.disBilgileri[0] = (HizmetKayitIslemleri.disBilgisiDVO)obj;
                            hizmetKayitGirisDVO.disBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.hastaYatisBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.hastaYatisBilgileri = new HizmetKayitIslemleri.hastaYatisBilgisiDVO[1];
                            hizmetKayitGirisDVO.hastaYatisBilgileri[0] = (HizmetKayitIslemleri.hastaYatisBilgisiDVO)obj;
                            hizmetKayitGirisDVO.hastaYatisBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.ilacBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.ilacBilgileri = new HizmetKayitIslemleri.ilacBilgisiDVO[1];
                            hizmetKayitGirisDVO.ilacBilgileri[0] = (HizmetKayitIslemleri.ilacBilgisiDVO)obj;
                            hizmetKayitGirisDVO.ilacBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.kanBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.kanBilgileri = new HizmetKayitIslemleri.kanBilgisiDVO[1];
                            hizmetKayitGirisDVO.kanBilgileri[0] = (HizmetKayitIslemleri.kanBilgisiDVO)obj;
                            hizmetKayitGirisDVO.kanBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.konsultasyonBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.konsultasyonBilgileri = new HizmetKayitIslemleri.konsultasyonBilgisiDVO[1];
                            hizmetKayitGirisDVO.konsultasyonBilgileri[0] = (HizmetKayitIslemleri.konsultasyonBilgisiDVO)obj;
                            hizmetKayitGirisDVO.konsultasyonBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.malzemeBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.malzemeBilgileri = new HizmetKayitIslemleri.malzemeBilgisiDVO[1];
                            hizmetKayitGirisDVO.malzemeBilgileri[0] = (HizmetKayitIslemleri.malzemeBilgisiDVO)obj;
                            hizmetKayitGirisDVO.malzemeBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.tahlilBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.tahlilBilgileri = new HizmetKayitIslemleri.tahlilBilgisiDVO[1];
                            hizmetKayitGirisDVO.tahlilBilgileri[0] = (HizmetKayitIslemleri.tahlilBilgisiDVO)obj;
                            hizmetKayitGirisDVO.tahlilBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else if (obj is HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO)
                        {
                            hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri = new HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO[1];
                            hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri[0] = (HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO)obj;
                            hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri[0].hizmetSunucuRefNo = tempHizSunucuNo;
                        }
                        else
                            return;

                        Guid? procedureID = SubActionProcedure.ProcedureObject.ObjectID;
                        HizmetKayitIslemleri.hizmetKayitCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetKayitSync(Sites.SiteLocalHost, procedureID, hizmetKayitGirisDVO);

                        if (result.sonucKodu == "0000")
                        {
                            System.Threading.Thread.Sleep(2000); // Medula 2 sn içinde aynı takibe ait işleme izin vermediği için
                            HizmetKayitIslemleri.hizmetIptalGirisDVO hizmetIptalGirisDVO = new HizmetKayitIslemleri.hizmetIptalGirisDVO();
                            hizmetIptalGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                            hizmetIptalGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
                            hizmetIptalGirisDVO.takipNo = SubEpisodeProtocol.MedulaTakipNo;

                            hizmetIptalGirisDVO.islemSiraNumaralari = new string[1];
                            hizmetIptalGirisDVO.islemSiraNumaralari[0] = result.islemBilgileri[0].islemSiraNo; // Sadece tek hizmet gönderdiğimiz için tek hizmet siliyoruz

                            HizmetKayitIslemleri.hizmetIptalCevapDVO iptalResult = HizmetKayitIslemleri.WebMethods.hizmetIptalSync(Sites.SiteLocalHost, hizmetIptalGirisDVO);
                            //                            if (iptalResult.sonucKodu != "0000")
                            //                                TTVisual.InfoBox.Alert("'" + this.SubActionProcedure.ProcedureObject.Code + " " + this.SubActionProcedure.ProcedureObject.Name + "' için medulaya Ön Hizmet Kayıt Kontrolü yapılırken, hizmet kaydı yapılabilmiş fakat hizmet kaydını iptal ederken aşağıdaki hata alınmıştır.\n" + iptalResult.sonucKodu + " " + iptalResult.sonucMesaji + "\n" + "D1000 Hizmet Sunucu Referans Numaralı ve " + result.islemBilgileri[0].islemSiraNo + " İşlem Sıra Numaralı hizmetin meduladan hizmet kaydının iptal edilmesi için Çağrı Merkezine haber veriniz.", MessageIconEnum.WarningMessage);
                        }
                        else  // Hizmet kayıtta hata alındı
                        {
                            string errorMessage = string.Empty;

                            if (result.hataliKayitlar != null && result.hataliKayitlar.Length > 0)
                                errorMessage = result.hataliKayitlar[0].hataKodu + " " + result.hataliKayitlar[0].hataMesaji;
                            else
                                errorMessage = result.sonucKodu + " " + result.sonucMesaji;

                            // Client Server ayırması sırasında kapatıldı ve direkt exception atacak şekilde değiştirildi. Kullanıcıya sorma kısmına daha sonra bir çözüm bulmak gerekecek. )
                            //if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "'" + this.SubActionProcedure.ProcedureObject.Code + " " + this.SubActionProcedure.ProcedureObject.Name + "' için medulaya Ön Hizmet Kayıt Kontrolü yapılırken aşağıdaki hata alınmıştır.\n" + errorMessage + "\nİşleme devam etmek istiyor musunuz?") == "H")
                            //    throw new TTUtils.TTException("İşlemden vazgeçildi.");

                            throw new TTUtils.TTException("'" + SubActionProcedure.ProcedureObject.Code + " " + SubActionProcedure.ProcedureObject.Name + "' için Medula'ya Ön Hizmet Kayıt Kontrolü yapılırken aşağıdaki hata alındığı için işlem tamamlanamadı.\n" + errorMessage);
                        }
                    }
                }
            }
        }

        // Hizmet Tanımına bakılıp gerekiyorsa Takibin Provizyon Tipi, Takip Tipi ve Tedavi Tipi Medula'da güncellenir
        public void UpdateSGKSEP()
        {
            if (SubEpisodeProtocol != null && !string.IsNullOrEmpty(SubEpisodeProtocol.MedulaTakipNo))
            {
                if (SubActionProcedure != null && SubActionProcedure.ProcedureObject != null)
                {
                    // Provizyon Tipi güncellenir
                    if (SubActionProcedure.ProcedureObject.ProvizyonTipi != null && !string.IsNullOrEmpty(SubActionProcedure.ProcedureObject.ProvizyonTipi.provizyonTipiKodu))
                    {
                        if (SubEpisodeProtocol.MedulaProvizyonTipi != null && SubEpisodeProtocol.MedulaProvizyonTipi.provizyonTipiKodu != SubActionProcedure.ProcedureObject.ProvizyonTipi.provizyonTipiKodu)
                        {
                            HastaKabulIslemleri.provizyonDegistirGirisDVO provizyonDegistirGirisDVO = new HastaKabulIslemleri.provizyonDegistirGirisDVO();
                            provizyonDegistirGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                            provizyonDegistirGirisDVO.takipNo = SubEpisodeProtocol.MedulaTakipNo;
                            provizyonDegistirGirisDVO.yeniProvizyonTipi = SubActionProcedure.ProcedureObject.ProvizyonTipi.provizyonTipiKodu;

                            XXXXXXMedulaServices.UpdateProvizyonTipiParam inputParam = new XXXXXXMedulaServices.UpdateProvizyonTipiParam(provizyonDegistirGirisDVO, SubEpisodeProtocol.ObjectID.ToString());
                            HastaKabulIslemleri.WebMethods.updateProvizyonTipiASync(Sites.SiteLocalHost, inputParam, provizyonDegistirGirisDVO);
                        }
                    }
                    // Takip Tipi güncellenir
                    if (SubActionProcedure.ProcedureObject.TakipTipi != null && !string.IsNullOrEmpty(SubActionProcedure.ProcedureObject.TakipTipi.takipTipiKodu))
                    {
                        if (SubEpisodeProtocol.MedulaTakipTipi != null && SubEpisodeProtocol.MedulaTakipTipi.takipTipiKodu != SubActionProcedure.ProcedureObject.TakipTipi.takipTipiKodu)
                        {
                            HastaKabulIslemleri.takipTipiDegistirGirisDVO takipTipiDegistirGirisDVO = new HastaKabulIslemleri.takipTipiDegistirGirisDVO();
                            takipTipiDegistirGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                            takipTipiDegistirGirisDVO.takipNo = SubEpisodeProtocol.MedulaTakipNo;
                            takipTipiDegistirGirisDVO.yeniTakiTipi = SubActionProcedure.ProcedureObject.TakipTipi.takipTipiKodu;

                            XXXXXXMedulaServices.UpdateTakipTipiParam inputParam = new XXXXXXMedulaServices.UpdateTakipTipiParam(takipTipiDegistirGirisDVO, SubEpisodeProtocol.ObjectID.ToString());
                            HastaKabulIslemleri.WebMethods.updateTakipTipiASync(Sites.SiteLocalHost, inputParam, takipTipiDegistirGirisDVO);
                        }
                    }
                    // Tedavi Tipi güncellenir
                    if (SubActionProcedure.ProcedureObject.TedaviTipi != null && !string.IsNullOrEmpty(SubActionProcedure.ProcedureObject.TedaviTipi.tedaviTipiKodu))
                    {
                        if (SubEpisodeProtocol.MedulaTedaviTipi != null && SubEpisodeProtocol.MedulaTedaviTipi.tedaviTipiKodu != SubActionProcedure.ProcedureObject.TedaviTipi.tedaviTipiKodu)
                        {
                            HastaKabulIslemleri.takipOkuGirisDVO takipOkuGirisDVO = new HastaKabulIslemleri.takipOkuGirisDVO();
                            takipOkuGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                            takipOkuGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
                            takipOkuGirisDVO.takipNo = SubEpisodeProtocol.MedulaTakipNo;
                            takipOkuGirisDVO.yeniTedaviTipi = Convert.ToInt32(SubActionProcedure.ProcedureObject.TedaviTipi.tedaviTipiKodu);

                            XXXXXXMedulaServices.HastaKabulOkuParam inputParam = new XXXXXXMedulaServices.HastaKabulOkuParam(takipOkuGirisDVO, SubEpisodeProtocol.ObjectID.ToString(), "UpdateTedaviTipi", SubEpisodeProtocol);
                            HastaKabulIslemleri.WebMethods.updateTedaviTipiASync(Sites.SiteLocalHost, inputParam, takipOkuGirisDVO);
                        }
                    }
                }
            }
        }

        public void ControlSubepisodeForDailyBedProcedure()
        {
            string dailyBedProcedureSUTCode = ProcedureDefinition.DailyBedProcedureSUTCode;

            if (SubActionProcedure != null && SubActionProcedure.ProcedureObject != null && SubActionProcedure.ProcedureObject.DailyMedulaProvisionNecessity != true &&
               (ExternalCode == dailyBedProcedureSUTCode || SubActionProcedure.ProcedureObject.Code == dailyBedProcedureSUTCode))
            {
                if (SubEpisodeProtocol != null && SubEpisodeProtocol.IsSGK)
                {
                    if (SubEpisodeProtocol?.MedulaTedaviTuru?.tedaviTuruKodu == "A")
                        throw new TTException("Ayaktan takibin altına 'Gündüz Yatak Hizmeti' eklenemez.");
                }
            }
        }

        public void CheckToCreateInMedulaDontSendState()
        {
            if (SubActionProcedure != null && SubActionProcedure.ProcedureObject != null)
            {
                if (IsMedulaAccountTransaction())
                {
                    if (SubActionProcedure.ProcedureObject.CreateInMedulaDontSendState == true)
                        CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                }
            }
            else if (SubActionMaterial != null && SubActionMaterial.Material != null)
            {
                if (IsMedulaAccountTransaction())
                {
                    if (SubActionMaterial.Material.CreateInMedulaDontSendState == true)
                        CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                    else
                    {
                        DrugDefinition drug = SubActionMaterial.Material as DrugDefinition;
                        if (drug != null && drug.IsArmyDrug == true)
                            CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                    }
                }
            }
        }


        public void MedulaOzelDurumEkle()
        {
            if (SubActionMaterial != null)
            {
                DrugDefinition drugDefinition = SubActionMaterial.Material as DrugDefinition;
                if (drugDefinition != null)
                {
                    bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugDefinition);
                    if (drugType)
                    {
                        DateTime startdate = new DateTime(Common.RecTime().Year, Common.RecTime().Month, Common.RecTime().Day, 0, 0, 0, 0);
                        DateTime enddate = new DateTime(Common.RecTime().Year, Common.RecTime().Month, Common.RecTime().Day, 23, 59, 59);
                        var amountOfDaily = GetAccountTrxDrugBySEPMat(SubActionMaterial.Episode.ObjectID, enddate, startdate, SubActionMaterial.Material.ObjectID).FirstOrDefault();
                        if (amountOfDaily != null && drugDefinition.InpatientMaxDoseOne != null)
                        {
                            double amountMaterialDose = Convert.ToDouble(amountOfDaily.Dailymaterialamount) + 1;
                            if (amountMaterialDose > drugDefinition.InpatientMaxDoseOne.Value)
                            {
                                this.OzelDurum = OzelDurum.GetOzelDurum("i");
                                if (SubActionMaterial is BaseTreatmentMaterial)
                                {
                                    ((BaseTreatmentMaterial)SubActionMaterial).OzelDurum = OzelDurum.GetOzelDurum("i");
                                }
                            }
                        }
                    }
                }
            }
        }


        // Ortez-Protez, Diş Protez vs. gibi hasta katılım payı olan hizmetlerde gazilere ödeme çıkmaması için, hasta payı olan
        // AccountTransaction makbuz/fatura dışı bırakılır (Ücretli Anlaşması değilse)
        public void CheckForInvoiceInclusion()
        {
            if (AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
            {
                if (SubActionProcedure != null) // Hizmet ise
                {
                    if (SubActionProcedure.PatientPay == true) // Hizmete hasta öder denmiş ise fatura dışı bırakılmaz
                        return;

                    if (SubActionProcedure is OrthesisProsthesisProcedure)
                    {  // Ortez protez işleminden hastaya pay çıkmışsa fatura dışı bırakılmaz (Kullanıcı seçiyor %100, %20 veya %10 olacağını) 
                        if (((OrthesisProsthesisProcedure)SubActionProcedure).PayRatio.HasValue)
                            return;
                    }
                }

                if (SubActionMaterial != null && SubActionMaterial.PatientPay == true)   // Malzemeye hasta öder denmiş ise fatura dışı bırakılmaz
                    return;

                if (SubEpisodeProtocol.Protocol.Type != ProtocolTypeEnum.Paid) // Ücretli hasta ise fatura dışı bırakılmaz
                {
                    if (SubEpisodeProtocol.CheckToCancelPatientShareAccTrx())
                        InvoiceInclusion = false;
                }
            }
        }

        // Hasta Payı AccountTransaction ın Kurum Payı da var mı (katılım payı mı) bilgisini döndürür
        public bool? IsPatientParticipationShare()
        {
            if (AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
            {
                if (SubActionProcedure != null)
                {
                    foreach (AccountTransaction accTrx in SubActionProcedure.AccountTransactions)
                    {
                        if (accTrx.ObjectID != ObjectID && accTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                            return true;
                    }
                }

                if (SubActionMaterial != null)
                {
                    foreach (AccountTransaction accTrx in SubActionMaterial.AccountTransactions)
                    {
                        if (accTrx.ObjectID != ObjectID && accTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                            return true;
                    }
                }
            }

            return null;
        }

        public bool IsPaidPatientShare()
        {
            if (AccountPayableReceivable != null && AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
            {
                if (CurrentStateDefID == AccountTransaction.States.Paid || CurrentStateDefID == AccountTransaction.States.Invoiced)
                    return true;
                else if (CurrentStateDefID == AccountTransaction.States.New && PaidPrice > 0)
                    return true;
            }

            return false;
        }

        // AccountTransaction ı hasta payına çevirir
        public void TurnToPatientShare(bool? isInvoiceIncluded = null, bool changeByKSHTPrice = false)
        {
            if (CurrentStateDefID != AccountTransaction.States.Cancelled)
            {
                AccountPayableReceivable = SubEpisodeProtocol.Episode.Patient.MyAPR();
                CurrentStateDefID = AccountTransaction.States.New;

                if (isInvoiceIncluded.HasValue)
                    InvoiceInclusion = isInvoiceIncluded.Value;

                if (changeByKSHTPrice && SubActionProcedure != null && SubActionProcedure.ProcedureObject != null)
                {
                    if (SubActionProcedure.AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled).Count() == 1)
                    {
                        IList pricingListDefinitions = PricingListDefinition.GetByCode(ObjectContext, "4"); // "Kamu Sağlık Hizmetleri Satış Tarifesi" fiyat listesi
                        if (pricingListDefinitions.Count > 0)
                        {
                            PricingDetailDefinition pdd = null;
                            ArrayList pricingDetailList = new ArrayList();
                            pricingDetailList = SubActionProcedure.ProcedureObject.GetProcedurePricingDetail((PricingListDefinition)pricingListDefinitions[0], SubActionProcedure.PricingDate);
                            if (pricingDetailList.Count > 0)
                            {
                                pdd = (PricingDetailDefinition)pricingDetailList[0];
                                UnitPrice = pdd.Price;
                            }
                            else // KSHT fiyat listesinde fiyat yoksa yoksa SUT * 1.5 yapması için
                            {
                                pricingListDefinitions = PricingListDefinition.GetByCode(ObjectContext, "1"); // "SUT Hizmet Fiyat Listesi" 
                                if (pricingListDefinitions.Count > 0)
                                {
                                    pricingDetailList = SubActionProcedure.ProcedureObject.GetProcedurePricingDetail((PricingListDefinition)pricingListDefinitions[0], SubActionProcedure.PricingDate);
                                    if (pricingDetailList.Count > 0)
                                    {
                                        pdd = (PricingDetailDefinition)pricingDetailList[0];
                                        UnitPrice = pdd.Price * 1.5;   // SUT * 1.5
                                    }
                                }
                            }

                            // KSHT veya SUT ta fiyat bulunmuşsa
                            if (pdd != null)
                            {
                                ExternalCode = pdd.ExternalCode;
                                Description = pdd.Description;
                                PricingDetail = pdd;

                                // Fiyat tanımında bir indirim/artırım varsa uygulanır
                                if (SystemParameter.GetParameterValue("APPLYPRICEDISCOUNTPERCENT", "TRUE").Equals("TRUE"))
                                {
                                    double percent = 0;

                                    if (SubEpisodeProtocol.Episode.PatientStatus == PatientStatusEnum.Outpatient && pdd.OutPatientDiscountPercent.HasValue && pdd.OutPatientDiscountPercent > 0)
                                        percent = pdd.OutPatientDiscountPercent.Value;
                                    else if (SubEpisodeProtocol.Episode.PatientStatus != PatientStatusEnum.Outpatient && pdd.InPatientDiscountPercent.HasValue && pdd.InPatientDiscountPercent > 0)
                                        percent = pdd.InPatientDiscountPercent.Value;

                                    if (percent >= 100)
                                        UnitPrice = Math.Round(UnitPrice.Value * (percent / 100), 2);
                                    else if (percent > 0 && percent < 100)
                                        UnitPrice = Math.Round(UnitPrice.Value * (1 - (percent / 100)), 2);
                                }
                            }
                        }
                    }
                    else
                        throw new TTException("Hizmetten oluşturulmuş birden fazla fatura kalemi bulundu. Hasta payına çevrilemez.");
                }
            }
        }

        // AccountTransaction ı kurum payına çevirir
        public void TurnToPayerShare(bool changeBySUTPrice = false)
        {
            if (CurrentStateDefID != AccountTransaction.States.Cancelled)
                AccountPayableReceivable = SubEpisodeProtocol.Payer.MyAPR();

            if (changeBySUTPrice && SubActionProcedure != null && SubActionProcedure.ProcedureObject != null)
            {

                if (SubActionProcedure.AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled).Count() == 1)
                {
                    IList pricingListDefinitions = PricingListDefinition.GetByCode(ObjectContext, "1");
                    if (pricingListDefinitions.Count > 0)
                    {
                        ArrayList pricingDetailList = new ArrayList();
                        pricingDetailList = SubActionProcedure.ProcedureObject.GetProcedurePricingDetail((PricingListDefinition)pricingListDefinitions[0], SubActionProcedure.PricingDate);
                        if (pricingDetailList.Count > 0)
                        {
                            UnitPrice = ((PricingDetailDefinition)pricingDetailList[0]).Price;
                            ExternalCode = ((PricingDetailDefinition)pricingDetailList[0]).ExternalCode;
                        }
                    }
                }
                else
                    throw new TTException("Hizmetten oluşturulmuş birden fazla fatura kalemi bulundu. Kurum payına çevrilemez.");
            }
        }

        public AccountTransaction CloneWithAmountAndDate(double? amount, DateTime? transactionDate)
        {
            AccountTransaction accTrx = (AccountTransaction)Clone();
            TTSequence.allowSetSequenceValue = true;
            accTrx.Id.SetSequenceValue(0);
            accTrx.Id.GetNextValue();

            if (amount.HasValue)
                accTrx.Amount = amount;

            if (transactionDate.HasValue)
                accTrx.TransactionDate = transactionDate;

            return accTrx;
        }

        /* Metod artık kullanılmıyor )
        public string CloneByAmountForMedula()
        {
            if (IsMedulaAccountTransaction() && (CurrentStateDefID == AccountTransaction.States.New || CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful))
            {
                if (SubActionProcedure != null)
                {
                    if (SubActionProcedure.AccTrxsMultipliedByAmount == true)
                        return "Hizmet adete göre çoğaltılmış durumdadır.\n(" + ExternalCode + " " + Description + ")";

                    if (Amount <= 1 || SubActionProcedure.Amount <= 1)
                        return TTUtils.CultureService.GetText("M25941", "Hizmet adeti çoğaltılmaya uygun değildir. Çoğaltılabilmesi için 1 adetten büyük olmalıdır.\n(") + ExternalCode + " " + Description + ")";

                    bool isConsecutiveDateRequired = false;

                    // Yatak hizmetlerinde tarihler ardışık olmalı
                    if (SubActionProcedure is BaseBedProcedure || (SubActionProcedure.ProcedureObject != null && SubActionProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.hastaYatisBilgileri))
                        isConsecutiveDateRequired = true;

                    for (long i = 1; i < Amount; i++)
                    {
                        if (isConsecutiveDateRequired)
                            CloneWithAmountAndDate(1, TransactionDate.Value.AddDays(i));
                        else
                            CloneWithAmountAndDate(1, null);
                    }

                    Amount = 1;
                    SubActionProcedure.AccTrxsMultipliedByAmount = true;
                }
                else if (SubActionMaterial != null)
                {
                    DrugDefinition drugDefinition = SubActionMaterial.Material as DrugDefinition;
                    if (drugDefinition != null)
                    {
                        if (SubActionMaterial.AccTrxsMultipliedByAmount == true)
                            return TTUtils.CultureService.GetText("M26059", "İlaç adete göre çoğaltılmış durumdadır.\n(") + ExternalCode + " " + Description + ")";

                        double packageAmount = 1;
                        //if (drugDefinition.AccTrxUnitPriceDivider.HasValue && drugDefinition.AccTrxAmountMultiplier.HasValue)
                        //{
                        //    packageAmount = drugDefinition.AccTrxUnitPriceDivider.Value;
                        //    if (Amount <= packageAmount || SubActionMaterial.Amount <= (drugDefinition.AccTrxUnitPriceDivider.Value / drugDefinition.AccTrxAmountMultiplier.Value))
                        //        return "İlaç adeti çoğaltılmaya uygun değildir. Çoğaltılabilmesi için " + packageAmount.ToString() + " adetten büyük olmalıdır.\n(" + ExternalCode + " " + Description + ")";
                        //}
                        if (drugDefinition.PackageAmount.HasValue && drugDefinition.PackageAmount.Value > 0)
                        {
                            packageAmount = drugDefinition.PackageAmount.Value;
                            if (Amount <= packageAmount || SubActionMaterial.Amount <= packageAmount)
                                return "İlaç adeti çoğaltılmaya uygun değildir. Çoğaltılabilmesi için " + packageAmount.ToString() + " adetten büyük olmalıdır.\n(" + ExternalCode + " " + Description + ")";
                        }
                        else
                            return TTUtils.CultureService.GetText("M26046", "İlacın Ambalaj Miktarı boş veya sıfır olduğundan adete göre çoğaltma işlemi yapılamaz.\n(") + ExternalCode + " " + Description + ")";

                        double restAmount = Amount.Value - packageAmount;
                        while (restAmount > 0)
                        {
                            if (restAmount >= packageAmount)
                                CloneWithAmountAndDate(packageAmount, null);
                            else
                                CloneWithAmountAndDate(restAmount, null);

                            restAmount -= packageAmount;
                        }

                        Amount = packageAmount;
                        SubActionMaterial.AccTrxsMultipliedByAmount = true;
                    }
                    else
                        return TTUtils.CultureService.GetText("M26799", "Sarf malzemeleri adete göre çoğaltılamaz.\n(") + ExternalCode + " " + Description + ")";
                }
            }
            return string.Empty;
        }
        */

        //ENabiz a Islem bilgisi gondermek icin SendToENabiz oluşturur
        public void CreateSendToENabiz()
        {
            if (SubActionProcedure != null)
            {
                if (SubActionProcedure.SubEpisode != null && SubActionProcedure.SendToENabiz(true))
                {
                    //NQL ilesorgulamada contextteki obje gelemiyor ve tekrar sendtoenabiz objesi olusturuluyordu. LocalQuery e cevrildi. 
                    IList<SendToENabiz> sendToENabizList = SendToENabiz.GetByObjectIDNameCodeAndStatus(ObjectContext, SubActionProcedure.ObjectID, SubActionProcedure.ObjectDef.Name, "102", SendToENabizEnum.ToBeSent);
                    if (sendToENabizList.Count == 0)
                    {
                        if (ObjectContext.LocalQuery<SendToENabiz>("INTERNALOBJECTID = '" + SubActionProcedure.ObjectID.ToString() + "' AND INTERNALOBJECTDEFNAME = '" + SubActionProcedure.ObjectDef.Name.ToString() + "' AND PACKAGECODE = '102' AND STATUS = " + Common.GetEnumValueDefOfEnumValue(SendToENabizEnum.ToBeSent).Value).Count == 0)
                            new SendToENabiz(ObjectContext, SubActionProcedure.SubEpisode, SubActionProcedure.ObjectID, SubActionProcedure.ObjectDef.Name, "102", Common.RecTime());
                    }
                }
                else if (SubActionProcedure.Episode.SubEpisodes.Count > 0 && SubActionProcedure.SendToENabiz(true))
                {
                    IList<SendToENabiz> sendToENabizList = SendToENabiz.GetByObjectIDNameCodeAndStatus(ObjectContext, SubActionProcedure.ObjectID, SubActionProcedure.ObjectDef.Name, "102", SendToENabizEnum.ToBeSent);
                    if (sendToENabizList.Count == 0)
                    {
                        if (ObjectContext.LocalQuery<SendToENabiz>("INTERNALOBJECTID = '" + SubActionProcedure.ObjectID.ToString() + "' AND INTERNALOBJECTDEFNAME = '" + SubActionProcedure.ObjectDef.Name.ToString() + "' AND PACKAGECODE = '102' AND STATUS = " + Common.GetEnumValueDefOfEnumValue(SendToENabizEnum.ToBeSent).Value).Count == 0)
                            new SendToENabiz(ObjectContext, SubActionProcedure.Episode.SubEpisodes[0], SubActionProcedure.ObjectID, SubActionProcedure.ObjectDef.Name, "102", Common.RecTime());
                    }
                }
            }
            else if (SubActionMaterial != null)
            {
                if (AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    SubActionMaterial.CreateENabizMaterial(this);
                else if (AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
                {
                    if (SubActionMaterial.AccountTransactions.Any(x => x.IsCancelled == false && x.AccountPayableReceivable.Type == APRTypeEnum.PAYER) == false)
                        SubActionMaterial.CreateENabizMaterial(this);
                }

                /*if (SubActionMaterial.SubEpisode != null && SubActionMaterial.SendToENabiz())
                {
                    IList<SendToENabiz> sendToENabizList = SendToENabiz.GetByObjectIDNameCodeAndStatus(ObjectContext, SubActionMaterial.ObjectID, SubActionMaterial.ObjectDef.Name, "102", SendToENabizEnum.ToBeSent);
                    if (sendToENabizList.Count == 0)
                    {
                        if (ObjectContext.LocalQuery<SendToENabiz>("INTERNALOBJECTID = '" + SubActionMaterial.ObjectID.ToString() + "' AND INTERNALOBJECTDEFNAME = '" + SubActionMaterial.ObjectDef.Name.ToString() + "' AND PACKAGECODE = '102' AND STATUS = " + Common.GetEnumValueDefOfEnumValue(SendToENabizEnum.ToBeSent).Value).Count == 0)
                            new SendToENabiz(ObjectContext, SubActionMaterial.SubEpisode, SubActionMaterial.ObjectID, SubActionMaterial.ObjectDef.Name, "102", Common.RecTime());
                    }
                }
                else if (SubActionMaterial.Episode.SubEpisodes.Count > 0 && SubActionMaterial.SendToENabiz())
                {
                    IList<SendToENabiz> sendToENabizList = SendToENabiz.GetByObjectIDNameCodeAndStatus(ObjectContext, SubActionMaterial.ObjectID, SubActionMaterial.ObjectDef.Name, "102", SendToENabizEnum.ToBeSent);
                    if (sendToENabizList.Count == 0)
                    {
                        if (ObjectContext.LocalQuery<SendToENabiz>("INTERNALOBJECTID = '" + SubActionMaterial.ObjectID.ToString() + "' AND INTERNALOBJECTDEFNAME = '" + SubActionMaterial.ObjectDef.Name.ToString() + "' AND PACKAGECODE = '102' AND STATUS = " + Common.GetEnumValueDefOfEnumValue(SendToENabizEnum.ToBeSent).Value).Count == 0)
                            new SendToENabiz(ObjectContext, SubActionMaterial.Episode.SubEpisodes[0], SubActionMaterial.ObjectID, SubActionMaterial.ObjectDef.Name, "102", Common.RecTime());
                    }
                }*/
            }
        }

        public string GetDescriptionInfoFromDVO()
        {
            string result = "";
            if (!string.IsNullOrEmpty(MedulaDescription))
                return MedulaDescription;

            object obj = null;
            if (SubActionProcedure != null)
                obj = SubActionProcedure.GetDVO(this);
            else if (SubActionMaterial != null)
                obj = SubActionMaterial.GetDVO(this);

            if (obj != null)
            {
                if (obj is HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)
                {
                    result = ((HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)obj).aciklama;
                }
                else if (obj is HizmetKayitIslemleri.hastaYatisBilgisiDVO)
                {
                    result = ((HizmetKayitIslemleri.hastaYatisBilgisiDVO)obj).aciklama;
                }
                else if (obj is HizmetKayitIslemleri.ilacBilgisiDVO)
                {
                    result = ((HizmetKayitIslemleri.ilacBilgisiDVO)obj).aciklama;
                }
                else if (obj is HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO)
                {
                    result = ((HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO)obj).aciklama;
                }
                else
                {
                    throw new TTException(TTUtils.CultureService.GetText("M25168", "AmeliyatveGirisimBilgisiDVO, IlacBilgisiDVO, TetkikveRadyolojiBilgisiDVO ve HastaYatisBilgisiDVO") +
TTUtils.CultureService.GetText("M25434", "dışında açıklama bilgisi medulaya gönderilmiyor. Diğer DVO larda bu bilgi güncellenemez."));
                }
            }
            return result;

        }

        public void CopyFromOldToNewAccTrxProperties(AccountTransaction cancelledAccTrx)
        {
            if (cancelledAccTrx == null)
                return;

            //this.TransactionDate = cancelledAccTrx.TransactionDate;  // PricingDate güncellenerek tekrar AccTrx oluşturulduğu durumlarda TransactionDate in değişmesi gerektiği için kapatıldı )
            Doctor = cancelledAccTrx.Doctor;
            OzelDurum = cancelledAccTrx.OzelDurum;
            PurchaseDate = cancelledAccTrx.PurchaseDate;
            Barcode = cancelledAccTrx.Barcode;
            ProducerCode = cancelledAccTrx.ProducerCode;
            MedulaDescription = cancelledAccTrx.MedulaDescription;
            AyniFarkliKesi = cancelledAccTrx.AyniFarkliKesi;
            MedulaBedNo = cancelledAccTrx.MedulaBedNo;
            MedulaAccessionNo = cancelledAccTrx.MedulaAccessionNo;
            MedulaDealerNo = cancelledAccTrx.MedulaDealerNo;
        }

        public static void ControlAndCopyAfterChangeMyProtocol(List<AccountTransaction> cancelledAtList, List<AccountTransaction> newAtList)
        {
            if (cancelledAtList.Count == 1 && newAtList.Count == 1)
            {
                newAtList[0].CopyFromOldToNewAccTrxProperties(cancelledAtList[0]);
            }
            else if (cancelledAtList.Count == 2 && newAtList.Count == 2)
            {
                foreach (var innerAccTrx in newAtList)
                {
                    if (innerAccTrx.AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
                        innerAccTrx.CopyFromOldToNewAccTrxProperties(cancelledAtList.Where(x => x.AccountPayableReceivable.Type == APRTypeEnum.PATIENT).FirstOrDefault());
                    else if (innerAccTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                        innerAccTrx.CopyFromOldToNewAccTrxProperties(cancelledAtList.Where(x => x.AccountPayableReceivable.Type == APRTypeEnum.PAYER).FirstOrDefault());
                }
            }
            else if (cancelledAtList.Count == 1 && newAtList.Count == 2)
            {
                foreach (var innerAccTrx in newAtList)
                {
                    innerAccTrx.CopyFromOldToNewAccTrxProperties(cancelledAtList[0]);
                }
            }
            else if (cancelledAtList.Count == 2 && newAtList.Count == 1)
            {
                if (newAtList[0].AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
                    newAtList[0].CopyFromOldToNewAccTrxProperties(cancelledAtList.Where(x => x.AccountPayableReceivable.Type == APRTypeEnum.PATIENT).FirstOrDefault());
                else if (newAtList[0].AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    newAtList[0].CopyFromOldToNewAccTrxProperties(cancelledAtList.Where(x => x.AccountPayableReceivable.Type == APRTypeEnum.PAYER).FirstOrDefault());
            }
        }

        public static void MedulaProcedureEntry(List<SubActionProcedure> spList)
        {
            if (spList != null && spList.Count > 0)
            {
                List<AccountTransaction> accTrxList = new List<AccountTransaction>();
                foreach (SubActionProcedure sp in spList)
                {
                    foreach (AccountTransaction accTrx in sp.AccountTransactions)
                    {
                        if (accTrx.SubEpisodeProtocol.IsSGK && accTrx.CurrentStateDefID == AccountTransaction.States.New && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                            if (!accTrxList.Contains(accTrx))
                                accTrxList.Add(accTrx);
                    }
                }

                AccountTransaction.MedulaProcedureEntry(accTrxList);
            }
        }

        public static void MedulaProcedureEntry(List<AccountTransaction> accTrxList)
        {
            if (accTrxList != null && accTrxList.Count > 0)
            {
                List<SubEpisodeProtocol> sepList = new List<SubEpisodeProtocol>();
                List<AccountTransaction> trxList = new List<AccountTransaction>();

                foreach (AccountTransaction accTrx in accTrxList)
                {
                    if (accTrx.SubEpisodeProtocol.IsSGK && accTrx.CurrentStateDefID == AccountTransaction.States.New && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    {
                        if (!sepList.Contains(accTrx.SubEpisodeProtocol))
                            sepList.Add(accTrx.SubEpisodeProtocol);

                        if (!trxList.Contains(accTrx))
                            trxList.Add(accTrx);
                    }
                }

                foreach (SubEpisodeProtocol sep in sepList)
                {
                    List<Guid> trxGuidList = trxList.Where(x => x.SubEpisodeProtocol.ObjectID == sep.ObjectID).Select(x => x.ObjectID).ToList();
                    if (trxGuidList.Count > 0)
                        try { sep.HizmetKayitSync(false, trxGuidList); } catch { }
                }
            }
        }

        public static void MedulaProcedureEntryCancel(List<SubActionProcedure> spList)
        {
            if (spList != null && spList.Count > 0)
            {
                List<AccountTransaction> accTrxList = new List<AccountTransaction>();
                foreach (SubActionProcedure sp in spList)
                {
                    foreach (AccountTransaction accTrx in sp.AccountTransactions)
                    {
                        if (!string.IsNullOrEmpty(accTrx.MedulaProcessNo) && accTrx.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful && accTrx.SubEpisodeProtocol.IsSGK && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                            if (!accTrxList.Contains(accTrx))
                                accTrxList.Add(accTrx);
                    }
                }

                AccountTransaction.MedulaProcedureEntryCancel(accTrxList);
            }
        }

        public static void MedulaProcedureEntryCancel(List<AccountTransaction> accTrxList)
        {
            if (accTrxList != null && accTrxList.Count > 0)
            {
                List<SubEpisodeProtocol> sepList = new List<SubEpisodeProtocol>();
                List<AccountTransaction> trxList = new List<AccountTransaction>();

                foreach (AccountTransaction accTrx in accTrxList)
                {
                    if (!string.IsNullOrEmpty(accTrx.MedulaProcessNo) && accTrx.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful && accTrx.SubEpisodeProtocol.IsSGK && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    {
                        if (!sepList.Contains(accTrx.SubEpisodeProtocol))
                            sepList.Add(accTrx.SubEpisodeProtocol);

                        if (!trxList.Contains(accTrx))
                            trxList.Add(accTrx);
                    }
                }

                foreach (SubEpisodeProtocol sep in sepList)
                {
                    List<Guid> trxGuidList = trxList.Where(x => x.SubEpisodeProtocol.ObjectID == sep.ObjectID).Select(x => x.ObjectID).ToList();
                    List<string> medulaProcessNoList = trxList.Where(x => x.SubEpisodeProtocol.ObjectID == sep.ObjectID).Select(x => x.MedulaProcessNo).ToList();

                    if (trxGuidList.Count > 0 && medulaProcessNoList.Count > 0)
                        try { sep.HizmetKayitIptalSync(medulaProcessNoList, trxGuidList, true); } catch { }
                }
            }
        }

        #endregion Methods

    }
}