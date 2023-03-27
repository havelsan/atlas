
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


using System.Threading;

namespace TTObjectClasses
{
    /// <summary>
    /// Alt vaka bazında kurum anlaşma takip bilgisini içerir
    /// </summary>
    public partial class SubEpisodeProtocol : TTObject
    {
        public static bool UpdateInvoiceSEPDetail(Guid id, Guid? newData, int type)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    SubEpisodeProtocol sep = objectContext.GetObject<SubEpisodeProtocol>(id);

                    if (newData.HasValue)
                    {
                        if (type == 1)
                        {
                            if (sep.Brans == null || (sep.Brans != null && sep.Brans.ObjectID != newData.Value))
                            {
                                SpecialityDefinition sp = objectContext.GetObject<SpecialityDefinition>(newData.Value);
                                InvoiceLog.AddInfo(string.Format("Branş bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.Brans != null ? sep.Brans.Name : "", sp.Name), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.Brans = sp;
                            }
                        }
                        else if (type == 2)
                        {
                            if (sep.MedulaDevredilenKurum == null || (sep.MedulaDevredilenKurum != null && sep.MedulaDevredilenKurum.ObjectID != newData.Value))
                            {
                                DevredilenKurum dk = objectContext.GetObject<DevredilenKurum>(newData.Value);
                                InvoiceLog.AddInfo(string.Format("Devredilen kurum bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.MedulaDevredilenKurum != null ? sep.MedulaDevredilenKurum.devredilenKurumAdi : "", dk.devredilenKurumAdi), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.MedulaDevredilenKurum = dk;
                            }
                        }
                        else if (type == 3)
                        {
                            if (sep.MedulaIstisnaiHal == null || (sep.MedulaIstisnaiHal != null && sep.MedulaIstisnaiHal.ObjectID != newData.Value))
                            {
                                IstisnaiHal ih = objectContext.GetObject<IstisnaiHal>(newData.Value);
                                InvoiceLog.AddInfo(string.Format("İstisnai hal bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.MedulaIstisnaiHal != null ? sep.MedulaIstisnaiHal.Adi : "", ih.Adi), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.MedulaIstisnaiHal = ih;
                            }
                        }
                        else if (type == 4)
                        {
                            if (sep.MedulaSigortaliTuru == null || (sep.MedulaSigortaliTuru != null && sep.MedulaSigortaliTuru.ObjectID != newData.Value))
                            {
                                SigortaliTuru st = objectContext.GetObject<SigortaliTuru>(newData.Value);
                                InvoiceLog.AddInfo(string.Format("Sigortalı türü bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.MedulaSigortaliTuru != null ? sep.MedulaSigortaliTuru.sigortaliTuruAdi : "", st.sigortaliTuruAdi), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.MedulaSigortaliTuru = st;
                            }
                        }
                        else if (type == 5)
                        {
                            if (sep.Triage == null || (sep.Triage != null && sep.Triage.ObjectID != newData.Value))
                            {
                                SKRSTRIAJKODU tr = objectContext.GetObject<SKRSTRIAJKODU>(newData.Value);
                                if (tr.KODU.Equals("1") || tr.KODU.Equals("2") || tr.KODU.Equals("3"))
                                {
                                    //throw new TTException("Triaj alanı Kırmızı,Sarı veya Yeşil olarak değiştirilebilir.");
                                    Guid AcilMuaHizmetiID = ProcedureDefinition.EmergencyExaminationProcedureObjectId;
                                    Guid YesilMauHizmetiID = ProcedureDefinition.GreenAreaExaminationProcedureObjectId;
                                    ProcedureDefinition pdAcil = objectContext.GetObject<ProcedureDefinition>(AcilMuaHizmetiID);
                                    ProcedureDefinition pdYesil = objectContext.GetObject<ProcedureDefinition>(YesilMauHizmetiID);
                                    List<AccountTransaction> accList = sep.AccountTransactions.Select(" EXTERNALCODE in ('S520020','520020','520021','S520021') AND CURRENTSTATEDEFID <> '" + AccountTransaction.States.Cancelled + "'  ").ToList();

                                    int i = 0;
                                    foreach (var item in accList)
                                    {
                                        if (item.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful)
                                            throw new TTException("Hizmet kaydı yapılmış muayene işlemi bulundu. Lütfen önce hizmet kayıtları iptal ediniz.");

                                        if (i == 0)
                                        {
                                            if (tr.KODU.Equals("1"))
                                            {
                                                Currency? price = pdYesil.GetProcedurePrice(sep, item.TransactionDate);
                                                if (item.ExternalCode.Contains('S'))
                                                    item.ExternalCode = "S" + pdYesil.Code;
                                                else
                                                    item.ExternalCode = pdYesil.Code;
                                                item.Description = pdYesil.Name;
                                                item.UnitPrice = price;
                                            }
                                            else if (tr.KODU.Equals("2") || tr.KODU.Equals("3"))
                                            {
                                                Currency? price = pdAcil.GetProcedurePrice(sep, item.TransactionDate);
                                                if (item.ExternalCode.Contains('S'))
                                                    item.ExternalCode = "S" + pdAcil.Code;
                                                else
                                                    item.ExternalCode = pdAcil.Code;
                                                item.Description = pdAcil.Name;
                                                item.UnitPrice = price;
                                            }
                                        }
                                        else
                                            item.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                                    }
                                }
                                InvoiceLog.AddInfo(string.Format("Triaj bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.Triage != null ? sep.Triage.ADI : "", tr.ADI), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.Triage = tr;




                            }
                        }
                    }
                    else
                    {
                        if (type == 1)
                        {
                            // sep.Brans null olamayacağı (required relation) için burası kapatıldı )
                            //if (sep.Brans != null)
                            //{
                            //    InvoiceLog.AddInfo(string.Format("Branş bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.Brans != null ? sep.Brans.Name : "", ""), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                            //    sep.Brans = null;
                            //}
                        }
                        else if (type == 2)
                        {
                            if (sep.MedulaDevredilenKurum != null)
                            {
                                InvoiceLog.AddInfo(string.Format("Devredilen kurum bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.MedulaDevredilenKurum != null ? sep.MedulaDevredilenKurum.devredilenKurumAdi : "", ""), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.MedulaDevredilenKurum = null;
                            }
                        }
                        else if (type == 3)
                        {
                            if (sep.MedulaIstisnaiHal != null)
                            {
                                InvoiceLog.AddInfo(string.Format("İstisnai hal bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.MedulaIstisnaiHal != null ? sep.MedulaIstisnaiHal.Adi : "", ""), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.MedulaIstisnaiHal = null;
                            }
                        }
                        else if (type == 4)
                        {
                            if (sep.MedulaSigortaliTuru != null)
                            {
                                InvoiceLog.AddInfo(string.Format("Sigortalı türü bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.MedulaSigortaliTuru != null ? sep.MedulaSigortaliTuru.sigortaliTuruAdi : "", ""), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.MedulaSigortaliTuru = null;
                            }
                        }
                        else if (type == 5)
                        {
                            if (sep.Triage != null)
                            {
                                InvoiceLog.AddInfo(string.Format("Sigortalı türü bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.Triage != null ? sep.Triage.ADI : "", ""), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.Triage = null;
                            }
                        }
                    }

                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        public MedulaResult ConfirmDeleteProvision()
        {
            MedulaResult result = new MedulaResult();

            //if (!this.IsSGK)
            //    throw new TTException("SGK olmayan kurumlarda takip silme işlemi gerçekleştirilemez.");

            if (InvoiceStatus == MedulaSubEpisodeStatusEnum.ProvisionNoNotExists ||
                IsInvoiced)
                throw new TTException(TTUtils.CultureService.GetText("M26996", "Takibi silinmeye çalışılan protokolün durumu takip silmeye uygun değildir. Lütfen kontrol ediniz."));

            int MEDULADELETEPROVISIONMAXDAYLIMIT = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULADELETEPROVISIONMAXDAYLIMIT", "105"));
            int MEDULADELETEPROVISIONDAYLIMIT = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULADELETEPROVISIONDAYLIMIT", "60"));
            bool hasTakipSilmeTamYetkiRoleID = TTUser.CurrentUser.HasRole(Common.TakipSilmeTamYetkiRoleID);
            bool hasTakipSilmeKisitliYetkiRoleID = TTUser.CurrentUser.HasRole(Common.TakipSilmeKisitliYetkiRoleID);



            int DayDiff = (DateTime.Now - MedulaProvizyonTarihi.Value).Days;

            if (DayDiff <= MEDULADELETEPROVISIONMAXDAYLIMIT)
            {
                result.Succes = true;
                result.SonucKodu = "";
                result.SonucMesaji = "";
            }
            //else if (DayDiff > MEDULADELETEPROVISIONDAYLIMIT && DayDiff <= MEDULADELETEPROVISIONMAXDAYLIMIT)
            //{
            //    if (hasTakipSilmeKisitliYetkiRoleID || hasTakipSilmeTamYetkiRoleID)
            //    {
            //        result.Succes = true;
            //        result.SonucKodu = "Confirm";
            //        result.SonucMesaji = TTUtils.CultureService.GetText("M27020", "Takip silme kısıtlı yetkisine sahipsiniz. Kısıt gün limiti:") + MEDULADELETEPROVISIONDAYLIMIT +
            //            ", Silinmeye çalışılan takibin geçen gün sayısı: " + DayDiff + ". Takibi silmek istediğinize emin misiniz? ";
            //    }
            //    else
            //    {
            //        result.Succes = false;
            //        result.SonucKodu = "NoRole";
            //        result.SonucMesaji = MEDULADELETEPROVISIONDAYLIMIT + " günü geçen takipleri silmeye yetkiniz bulunamadı, Silinmeye çalışılan takibin geçen gün sayısı: " + DayDiff + ". ";
            //    }
            //}
            else if (DayDiff > MEDULADELETEPROVISIONMAXDAYLIMIT)
            {
                if (hasTakipSilmeTamYetkiRoleID)
                {
                    result.Succes = true;
                    result.SonucKodu = "Confirm";
                    result.SonucMesaji = TTUtils.CultureService.GetText("M27021", "Takip silme tam yetkisine sahipsiniz. Kısıt gün limiti:") + MEDULADELETEPROVISIONMAXDAYLIMIT +
                        ", Silinmeye çalışılan takibin geçen gün sayısı: " + DayDiff + ". Takibi silmek istediğinize emin misiniz? ";
                }
                else
                {
                    result.Succes = false;
                    result.SonucKodu = "NoRole";
                    result.SonucMesaji = MEDULADELETEPROVISIONMAXDAYLIMIT + " günü geçen takipleri silmeye yetkiniz bulunamadı, Silinmeye çalışılan takibin geçen gün sayısı: " + DayDiff + ". ";
                }
            }
            return result;
        }

        public static bool HizmetKayitIptalWithSEPAndSutCode(List<SubEpisodeProtocol> sepList, string sutCode)
        {
            foreach (SubEpisodeProtocol sep in sepList)
            {
                List<AccountTransaction> actxList = sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' AND SUBACTIONPROCEDURE IS NOT NULL AND EXTERNALCODE = '" + sutCode + "'  ").ToList();
                if (actxList.Count > 0)
                {
                    List<string> ssList = new List<string>();
                    List<Guid> accountTransactionIDs = new List<Guid>();
                    foreach (var item in actxList)
                    {
                        if (!string.IsNullOrEmpty(item.MedulaProcessNo))
                        {
                            ssList.Add(item.MedulaProcessNo.ToString());
                            accountTransactionIDs.Add(item.ObjectID);
                        }
                    }
                    MedulaResult medulaResult = sep.HizmetKayitIptalSync(ssList, accountTransactionIDs, true);
                    if (medulaResult != null && medulaResult.SonucKodu != null)
                    {
                        if (medulaResult.SonucKodu.Equals("0000"))
                        {
                            List<AccountTransaction> actxListInner = sep.AccountTransactions.Select("  CURRENTSTATEDEFID = '" + AccountTransaction.States.New + "' AND SUBACTIONPROCEDURE IS NOT NULL AND EXTERNALCODE = '" + sutCode + "'  ").ToList();
                            foreach (AccountTransaction itemInner in actxListInner)
                            {
                                itemInner.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                            }

                            sep.ObjectContext.Save();

                            if (sep != null)
                                sep.SetInvoiceStatusAfterProcedureEntry();

                            sep.ObjectContext.Save();

                        }
                    }
                }
            }
            return true;

        }

        #region Methods
        public IList GetSubActionProcedureTrxs(List<Guid> stateList)
        {
            IList _subActionProcTrxs = AccountTransaction.GetSubActionProcedureTrxsBySEP(ObjectContext, ObjectID, stateList);
            return _subActionProcTrxs;
        }

        public List<SubActionProcedure> GetSubActionProcedureTrxsToChangeSEP()
        {
            List<Guid> stateList = new List<Guid>();
            stateList.Add(AccountTransaction.States.New);
            stateList.Add(AccountTransaction.States.ToBeNew);
            stateList.Add(AccountTransaction.States.MedulaDontSend);
            stateList.Add(AccountTransaction.States.MedulaEntryUnsuccessful);

            //List<AccountTransaction> _subActionProcTrxs = this.AccountTransactions.Select("").Where(x => x.SubActionProcedure != null && stateList.Contains(x.CurrentStateDefID.Value)).OrderBy(x => x.SubActionProcedure).ToList();
            List<SubActionProcedure> _subActionProcTrxs = AccountTransactions.Select("").Where(x => x.SubActionProcedure != null && stateList.Contains(x.CurrentStateDefID.Value)).Select(x => x.SubActionProcedure).Distinct().ToList();

            return _subActionProcTrxs;
        }

        public IList GetSubActionMaterialTrxs(List<Guid> stateList)
        {
            IList _subActionMatTrxs = AccountTransaction.GetSubActionMaterialTrxsBySEP(ObjectContext, ObjectID, stateList);
            return _subActionMatTrxs;
        }

        public List<SubActionMaterial> GetSubActionMaterialTrxsToChangeSEP()
        {
            List<Guid> stateList = new List<Guid>();
            stateList.Add(AccountTransaction.States.New);
            stateList.Add(AccountTransaction.States.ToBeNew);
            stateList.Add(AccountTransaction.States.MedulaDontSend);
            stateList.Add(AccountTransaction.States.MedulaEntryUnsuccessful);

            //List<AccountTransaction> _subActionMatTrxs = this.AccountTransactions.Select("").Where(x => x.SubActionMaterial != null && stateList.Contains(x.CurrentStateDefID.Value)).OrderBy(x => x.SubActionMaterial).ToList();
            List<SubActionMaterial> _subActionMatTrxs = AccountTransactions.Select("").Where(x => x.SubActionMaterial != null && stateList.Contains(x.CurrentStateDefID.Value)).Select(x => x.SubActionMaterial).Distinct().ToList();

            return _subActionMatTrxs;
        }

        public IList GetTransactionsInsidePackage(PackageDefinition packageDefinition, AccountPayableReceivable apr)
        {
            IList _receiptTrxs = AccountTransaction.GetTransactionsInsidePackageBySEP(ObjectContext, packageDefinition.ObjectID, ObjectID, apr.ObjectID);
            return _receiptTrxs;
        }

        public IList GetNotInvoiceIncludedTransactions(AccountPayableReceivable apr)
        {
            IList _receiptTrxs = AccountTransaction.GetNotInvoiceIncludedTrxsBySEP(ObjectContext, ObjectID, apr.ObjectID);
            return _receiptTrxs;
        }

        public bool ContainsPackage()
        {
            return Convert.ToBoolean(AccountTransactions.Select(" SUBACTIONPROCEDURE IS NOT NULL AND CURRENTSTATEDEFID <> '" + AccountTransaction.States.Cancelled + "' AND (EXTERNALCODE LIKE 'P%' OR EXTERNALCODE LIKE 'SP%')").Count());
        }

        public IList GetPackageSubActionProcedures(bool onlyPackageDefinitionExists = false)
        {
            List<SubActionProcedure> packageSubActionProcedures = new List<SubActionProcedure>();
            foreach (AccountTransaction actrx in AccountTransactions.Select(""))
            {
                if (actrx.CurrentStateDefID == AccountTransaction.States.New && actrx.SubActionProcedure != null && actrx.SubActionProcedure.ProcedureObject is PackageProcedureDefinition)
                {
                    if (onlyPackageDefinitionExists == true)
                    {
                        if (actrx.SubActionProcedure.PackageDefinition != null)
                            packageSubActionProcedures.Add(actrx.SubActionProcedure);
                    }
                    else
                        packageSubActionProcedures.Add(actrx.SubActionProcedure);
                }
            }
            return packageSubActionProcedures;
        }

        public void CancelPatientShareAccTrxs()
        {
            if (Protocol.Type != ProtocolTypeEnum.Paid)
            {
                foreach (AccountTransaction accTrx in AccountTransactions.Select(""))
                {
                    if (accTrx.AccountPayableReceivable != null && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PATIENT && accTrx.IsPaidPatientShare() == false)
                        accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
                }
            }
        }

        public Episode Episode
        {
            get
            {
                if (SubEpisode != null)
                    return SubEpisode.Episode;

                return null;
            }
        }

        public bool IsInvoiced
        {
            get
            {
                if (InvoiceStatus == MedulaSubEpisodeStatusEnum.Invoiced || InvoiceStatus == MedulaSubEpisodeStatusEnum.InvoiceInconsistent)
                    return true;

                return false;
            }
        }

        public MedulaResult AddSEPDiagnosis(List<CollectiveInvoiceOp.addDiagnosisModel> tempDiaGridList)
        {
            MedulaResult result = new MedulaResult();
            try
            {
                var objectContext = ObjectContext;
                if (this.IsInvoiced)
                    throw new TTException("Tanı eklenmeye çalışılan protokolün durumu tanı eklemeye uygun değildir. Lütfen kontrol ediniz.(Faturalanmış)");


                foreach (var item in tempDiaGridList)
                {
                    SEPDiagnosis sd = new SEPDiagnosis(objectContext);
                    sd.SubEpisodeProtocol = this;
                    sd.Diagnose = item.Diagnose;
                    sd.DiagnosisType = item.DiagnosisType;//string.IsNullOrWhiteSpace(item.DiagnosisType) ? DiagnosisTypeEnum.Primer : (DiagnosisTypeEnum)Common.GetEnumValueDefOfEnumValueV2("DiagnosisTypeEnum", Int32.Parse(item.DiagnosisType)).EnumValue;
                    sd.IsMainDiagnose = item.IsMainDiagnose;
                    sd.CurrentStateDefID = SEPDiagnosis.States.New;
                    InvoiceLog.AddInfo("Yeni tanı eklendi. Kodu: " + item.Diagnose.Code + " Adı: " + item.Diagnose.Name, ObjectID, InvoiceOperationTypeEnum.AddNewDiagnosis, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, objectContext);
                }

                objectContext.Save();
                result.Succes = true;
                result.TakipNo = this.MedulaTakipNo;
                result.BasvuruNo = this.MedulaBasvuruNo;
                result.ProtocolNo = this.SubEpisode?.ProtocolNo;
            }
            catch (Exception)
            {
                result.Succes = false;
            }
            return result;
        }

        public MedulaResult ChangeDoctorWithErrorCode(MedulaErrorCodeDefinition mecd, ResUser ru)
        {
            MedulaResult result = new MedulaResult();
            try
            {
                var objectContext = ObjectContext;
                if (this.IsInvoiced)

                    if (this.IsInvoiced || InvoiceStatus == MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted)
                        throw new TTException("Doktorun değiştirildiği protokolün durumu doktor değiştirmeye uygun değildir. Lütfen kontrol ediniz.");

                List<AccountTransaction> accList = AccountTransactions.Select(" CURRENTSTATEDEFID <> '" + AccountTransaction.States.Cancelled + "' AND  MEDULARESULTCODE = '" + mecd.Code + "' ").ToList();
                foreach (var item in accList)
                {
                    item.Doctor = ru;
                }
                objectContext.Save();
                result.TakipNo = this.MedulaTakipNo;
                result.BasvuruNo = this.MedulaBasvuruNo;
                result.ProtocolNo = this.SubEpisode?.ProtocolNo;
                result.Succes = true;

            }
            catch (Exception)
            {
                result.Succes = false;
            }
            return result;
        }

        public MedulaResult UpdateMedulaDescription(List<AccountTransaction> actxList, string medulaDescription)
        {
            MedulaResult result = new MedulaResult();

            if (this.IsInvoiced || InvoiceStatus == MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted)
                throw new TTException("Hizmet medula açıklaması değiştirilmeye çalışılan protokolün durumu değiştirmeye uygun değildir. Lütfen kontrol ediniz.");


            foreach (AccountTransaction item in actxList)
            {
                item.MedulaDescription = medulaDescription;
            }
            result.Succes = true;
            result.TakipNo = this.MedulaTakipNo;
            result.BasvuruNo = this.MedulaBasvuruNo;
            result.ProtocolNo = this.SubEpisode?.ProtocolNo;
            return result;
        }

        public MedulaResult UpdateMedulaCurrentState(List<AccountTransaction> actxList)
        {
            MedulaResult result = new MedulaResult();
            try
            {
                Guid stateGuid = AccountTransaction.States.MedulaDontSend;
                List<string> ssList = new List<string>();
                List<Guid> accountTransactionIDs = new List<Guid>();
                foreach (var item in actxList)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful && !string.IsNullOrEmpty(item.MedulaProcessNo))
                    {
                        ssList.Add(item.MedulaProcessNo.ToString());
                        accountTransactionIDs.Add(item.ObjectID);
                    }
                }
                if (ssList.Count > 999)
                {
                    throw new Exception("Hizmet kayıt iptal sırasında tek seferde en fazla 1000 kayıt gönderilebilir! Toplu hizmet kayıt iptalini deneyiniz.");
                }
                MedulaResult medulaResult = null;
                if (ssList.Count > 0)
                {
                    TTObjectContext objectcontext = new TTObjectContext(false);
                    medulaResult = this.HizmetKayitIptalSync(ssList, accountTransactionIDs, true);
                }
                foreach (AccountTransaction item in actxList)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful)
                        item.CurrentStateDefID = stateGuid;
                }
                this.ObjectContext.Save();
                this.SetInvoiceStatusAfterProcedureEntry();
                result.Succes = true;
                if (medulaResult != null)
                {
                    result.SonucKodu = medulaResult.SonucKodu;
                    result.SonucMesaji = medulaResult.SonucMesaji;
                }
                result.TakipNo = this.MedulaTakipNo;
                result.BasvuruNo = this.MedulaBasvuruNo;
                result.ProtocolNo = this.SubEpisode?.ProtocolNo;
            }
            catch (Exception ex)
            {
                result.SonucMesaji = ex.Message;
                result.Succes = false;
            }
            return result;
        }
        public bool SendNabiz(List<AccountTransaction> actxList)
        {
            SendToENabiz sendToENabiz = new SendToENabiz();
            foreach (AccountTransaction accTrx in actxList)
            {

                if (accTrx.SubActionProcedure != null)
                {
                    sendToENabiz.ControlAndCreatePackageToSendToENabiz(ObjectContext, accTrx.SubEpisodeProtocol.SubEpisode, accTrx.SubActionProcedure.ObjectID, accTrx.SubActionProcedure.ObjectDef.Name, "102");
                    sendToENabiz.ENABIZSend102(accTrx.SubActionProcedure.ObjectID.ToString(), true);
                }
                else if (accTrx.SubActionMaterial != null)
                {
                    if (accTrx.SubActionMaterial.ENabizMaterials != null && accTrx.SubActionMaterial.ENabizMaterials.Count > 0)
                    {
                        sendToENabiz.ControlAndCreatePackageToSendToENabiz(ObjectContext, accTrx.SubEpisodeProtocol.SubEpisode, accTrx.SubActionMaterial.ENabizMaterials[0].ObjectID, accTrx.SubActionMaterial.ENabizMaterials[0].ObjectDef.Name, "102");
                        sendToENabiz.ENABIZSend102(accTrx.SubActionMaterial.ENabizMaterials[0].ObjectID.ToString(), true);
                    }
                    else
                        throw new Exception(" NabizSil: ENabizMaterial bulunamadı.");
                }
            }
            return true;
        }

        public MedulaResult SendNabiz700(bool fromInvoice = true, List<Guid> actxList = null)
        {
            SendToENabiz sendToENabiz = new SendToENabiz();
            MedulaResult result = new MedulaResult();
            if (IsSGKAndActiveWithMedulaTakipNo)
            {
                List<AccountTransaction> tempAccList = null;
                if (actxList != null && actxList.Count > 0)
                {
                    tempAccList = new List<AccountTransaction>();
                    foreach (Guid accItem in actxList)
                    {
                        AccountTransaction accTrx = ObjectContext.GetObject<AccountTransaction>(accItem);
                        tempAccList.Add(accTrx);
                    }
                }
                sendToENabiz.ControlAndCreatePackageToSendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "700");
                List<NabizResponse700> nabizResultList = sendToENabiz.ENABIZSend700(ObjectID.ToString(), fromInvoice, tempAccList);
                result.SEPObjectID = ObjectID;
                NabizResponse700 nabizResult = nabizResultList.FirstOrDefault();
                if (nabizResult != null)
                {
                    result.SEPObjectID = ObjectID;
                    result.SonucKodu = nabizResult.SonucKodu;
                    result.SonucMesaji = nabizResult.SonucMesaji;
                    if (nabizResult.IslemKontrol?.SGKBildirimKontrolIslem?.Count > 0)
                    {
                        foreach (SendToENabiz.SGKBildirimKontrolIslem item in nabizResult.IslemKontrol?.SGKBildirimKontrolIslem)
                        {
                            result.SonucMesaji += "-[" + item.IslemSonuc?.SGKBildirimKontrolSonuc?.SonucKodu + "] " + item.IslemSonuc?.SGKBildirimKontrolSonuc?.SonucMesaji;
                        }
                    }
                    result.TakipNo = nabizResult.SYSTakipNo;
                    result.Succes = true;
                    result.TakipNo = this.MedulaTakipNo;
                    result.BasvuruNo = this.MedulaBasvuruNo;
                    result.ProtocolNo = this.SubEpisode?.ProtocolNo;
                    if (nabizResult.SonucKodu == "S0000")
                        result.Succes = true;
                }
            }
            else
            {
                result.Succes = false;
                result.SonucMesaji = "Sadece Takip Numarası Olan SGK lı kayıtlar gönderilebilir.";
            }
            return result;
        }

        public bool IsSGK
        {
            get
            {
                return Payer.IsSGK;
            }
        }

        public bool IsSGKManual
        {
            get
            {
                return Payer.IsSGKManual;
            }
        }

        public bool IsSGKAll
        {
            get
            {
                return Payer.IsSGKAll;
            }
        }

        public static SubEpisodeProtocol GetChildSEP(SubEpisodeProtocol sep, bool childSEPHasProvisionNo = true)
        {
            foreach (SubEpisodeProtocol subEpisodeProtocol in sep.ChildSEPs.Select("").Where(x => x.ObjectID != sep.ObjectID && x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled))
            {
                if (childSEPHasProvisionNo)
                {
                    if (!string.IsNullOrEmpty(subEpisodeProtocol.MedulaTakipNo))
                        return subEpisodeProtocol;
                }
                else
                    return subEpisodeProtocol;
            }

            return null;
        }

        // Hastaya katılım payı çıkmaması için oluşan hasta payının fatura dahilliği false yapılır
        public bool CheckToCancelPatientShareAccTrx()
        {
            // Kurum tanımında CancelPatientShareAccTrx (Hastadan Katılım Payı Alınmaz) işaretli ise
            if (Payer.CancelPatientShareAccTrx == true)
                return true;

            if (IsSGK && !string.IsNullOrEmpty(MedulaTakipNo))
            {
                // Hasta kabuldeki Başvuru Türü "İÇ. GüV. Y." veya "15 TEMMUZ" ise
                if (SubEpisode.PatientAdmission.ApplicationReason == ApplicationReasonEnum.Icguvy || SubEpisode.PatientAdmission.ApplicationReason == ApplicationReasonEnum.Temmuz)
                    return true;

                // Hasta kabuldeki Hasta Türü "ER" ise 
                if (SubEpisode.PatientAdmission.PatientClassGroup == PatientClassTypeEnum.Er)
                    return true;

                // Provizyon Tipi "E : 3713/21", "I : IS KAZASI" veya "M : MESLEK HASTALIGI" ise
                if (MedulaProvizyonTipi != null && (MedulaProvizyonTipi.provizyonTipiKodu.Equals("E") || MedulaProvizyonTipi.provizyonTipiKodu.Equals("I") || MedulaProvizyonTipi.provizyonTipiKodu.Equals("M")))
                    return true;
            }

            return false;
        }

        public string Triaj
        {
            get
            {
                bool needTriajCode = false;

                if (MedulaProvizyonTipi != null)
                {
                    // A = Acil , V = Adli Vaka , T = Trafik Kazası , I = İş Kazası , E = 3713/21, S = İstisnai Hal
                    if (MedulaProvizyonTipi.provizyonTipiKodu.Trim().Equals("A"))
                        needTriajCode = true;
                    else if (MedulaProvizyonTipi.provizyonTipiKodu.Trim().Equals("V") || MedulaProvizyonTipi.provizyonTipiKodu.Trim().Equals("T") || MedulaProvizyonTipi.provizyonTipiKodu.Trim().Equals("I") || MedulaProvizyonTipi.provizyonTipiKodu.Trim().Equals("E"))
                    {
                        if (Brans != null && (Brans.Code.Trim().Equals("4400") || Brans.Code.Trim().Equals("1596"))) // 4400: Acil Tıp , 1596: Çocuk Acil
                            needTriajCode = true;
                    }
                    else if (MedulaProvizyonTipi.provizyonTipiKodu.Trim().Equals("S"))
                    {   // 1: Acil hal
                        if (MedulaIstisnaiHal != null && MedulaIstisnaiHal.Kodu.Trim().Equals("1"))
                            needTriajCode = true;
                    }
                }

                if (needTriajCode == false && MedulaIstisnaiHal != null)
                {   // 3: Bildirimi zorunlu bulaşıcı hastalık
                    if (MedulaIstisnaiHal.Kodu.Trim().Equals("3"))
                    {
                        if (Brans != null && (Brans.Code.Trim().Equals("4400") || Brans.Code.Trim().Equals("1596"))) // 4400: Acil Tıp , 1596: Çocuk Acil
                            needTriajCode = true;
                    }
                }

                if (needTriajCode)
                {
                    if (Triage != null)
                    {
                        if (Triage.KODU.Equals("1")) // Yeşil
                            return "Y";
                        else if (Triage.KODU.Equals("2")) // Sarı
                            return "S";
                        else if (Triage.KODU.Equals("3")) // Kırmızı
                            return "K";
                    }
                    return "Y";
                    //if (Episode != null)
                    //{
                    //    string triaj = Episode.Triaj;
                    //    if (!string.IsNullOrWhiteSpace(triaj))
                    //        return triaj;
                    //}
                    //return "Y";
                }

                return null;
            }
        }

        public void updateDischargeType(Guid taburcuKodu)
        {
            TaburcuKodu tk = ObjectContext.GetObject<TaburcuKodu>(taburcuKodu) as TaburcuKodu;
            DischargeType = tk;
            ObjectContext.Save();
        }

        // Hizmet Kaydı yapıldıktan sonra MedulaProvision ın durumunu set eder ve döndürür
        public MedulaSubEpisodeStatusEnum? SetInvoiceStatusAfterProcedureEntry()
        {
            if (SubEpisode != null)
            {
                if (!string.IsNullOrEmpty(this?.InvoiceCollectionDetail?.PayerInvoiceDocument?.DocumentNo))
                {
                    InvoiceStatus = MedulaSubEpisodeStatusEnum.Invoiced;
                    return InvoiceStatus;
                }
                else if (InvoiceCollectionDetail != null && InvoiceCollectionDetail.PayerInvoiceDocument == null)
                {
                    InvoiceStatus = MedulaSubEpisodeStatusEnum.InsideInvoiceCollection;
                    return InvoiceStatus;
                }
                else if (string.IsNullOrEmpty(MedulaTakipNo) || string.IsNullOrEmpty(MedulaBasvuruNo))
                {
                    InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                    return InvoiceStatus;
                }

                // Hata alınmış var ise
                List<Guid> stateList = new List<Guid>();
                stateList.Add(AccountTransaction.States.MedulaEntryUnsuccessful);
                BindingList<AccountTransaction.GetMedulaTransactionsBySEPAndState_Class> accTrxs = AccountTransaction.GetMedulaTransactionsBySEPAndState(ObjectID, stateList.ToArray());
                if (accTrxs.Count > 0)
                {
                    InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                    return InvoiceStatus;
                }

                stateList.Clear();
                stateList.Add(SEPDiagnosis.States.MedulaEntryUnsuccessful);
                BindingList<SEPDiagnosis.GetBySubEpisodeProtocolAndState_Class> diagnosisList = SEPDiagnosis.GetBySubEpisodeProtocolAndState(ObjectID, stateList.ToArray());
                if (diagnosisList.Count > 0)
                {
                    InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                    return InvoiceStatus;
                }

                // Hizmet Kaydı yapılmamış var ise
                stateList.Clear();
                accTrxs.Clear();
                stateList.Add(AccountTransaction.States.New);
                stateList.Add(AccountTransaction.States.ToBeNew);
                stateList.Add(AccountTransaction.States.MedulaSentServer);
                accTrxs = AccountTransaction.GetMedulaTransactionsBySEPAndState(ObjectID, stateList.ToArray());
                if (accTrxs.Count > 0)
                {
                    InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                    return InvoiceStatus;
                }

                stateList.Clear();
                diagnosisList.Clear();
                stateList.Add(SEPDiagnosis.States.New);
                stateList.Add(SEPDiagnosis.States.MedulaSentServer);
                diagnosisList = SEPDiagnosis.GetBySubEpisodeProtocolAndState(ObjectID, stateList.ToArray());
                if (diagnosisList.Count > 0)
                {
                    InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                    return InvoiceStatus;
                }

                // İkisi de yoksa hepsi başarılı hizmet kaydı yapılmış demektir
                InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted;
            }
            return InvoiceStatus;
        }

        public class AddAccountTransactionParameter
        {
            public double? Amount { get; set; }
            public DateTime? TransactionDate { get; set; }

            // Malzeme alış fiyatı için eklenen property ler
            public StockTransaction StockOutTransaction { get; set; }
            public BigCurrency? PurchasePrice { get; set; }
            public Double? PurchaseVatRate { get; set; }

            public UTSNotificationDetail UTSNotificationDetail { get; set; }

            public AddAccountTransactionParameter()
            {
                Amount = 1;
            }

            public AddAccountTransactionParameter(double amount)
            {
                Amount = amount;
            }

            public AddAccountTransactionParameter(double amount, DateTime transactionDate)
            {
                Amount = amount;
                TransactionDate = transactionDate;
            }
        }

        public void AddAccountTransaction(AccountOwnerType accType, TTObject pObject, ManipulatedPrice mPricingDetail, PackageDefinition pPackageDefinition, AccountOperationTimeEnum accountingTimeType)
        {
            //if (accType == AccountOwnerType.PAYER && IsSGK) // Kurum payı ve medula episode u ise - Bu koşul kapatıldı, tüm hasta grupları için AccTrx çoklansın  - 29.06.2018)
            //{
            if (pObject.ObjectDef.IsOfType("SUBACTIONPROCEDURE") == true)
            {
                SubActionProcedure sp = (SubActionProcedure)pObject;
                List<AddAccountTransactionParameter> addAccountTransactionParameterList = new List<AddAccountTransactionParameter>();
                sp.SetAmountAndDateListForSEPAddAccTrx(ref addAccountTransactionParameterList);
                if (addAccountTransactionParameterList.Count > 0)
                {
                    foreach (AddAccountTransactionParameter addAccountTransactionParameter in addAccountTransactionParameterList)
                        AddAccountTransaction(accType, pObject, mPricingDetail, pPackageDefinition, accountingTimeType, addAccountTransactionParameter);

                    sp.AccTrxsMultipliedByAmount = true;
                    return;
                }
            }
            else if (pObject.ObjectDef.IsOfType("SUBACTIONMATERIAL") == true)
            {
                SubActionMaterial sm = (SubActionMaterial)pObject;
                List<AddAccountTransactionParameter> addAccountTransactionParameterList = new List<AddAccountTransactionParameter>();
                sm.SetAmountAndDateListForSEPAddAccTrx(ref addAccountTransactionParameterList);
                if (addAccountTransactionParameterList.Count > 0)
                {
                    foreach (AddAccountTransactionParameter addAccountTransactionParameter in addAccountTransactionParameterList)
                        AddAccountTransaction(accType, pObject, mPricingDetail, pPackageDefinition, accountingTimeType, addAccountTransactionParameter);

                    sm.AccTrxsMultipliedByAmount = true;
                    return;
                }
            }
            //}

            AddAccountTransaction(accType, pObject, mPricingDetail, pPackageDefinition, accountingTimeType, null);
        }

        public void AddAccountTransaction(AccountOwnerType accType, TTObject pObject, ManipulatedPrice mPricingDetail, PackageDefinition pPackageDefinition, AccountOperationTimeEnum accountingTimeType, AddAccountTransactionParameter addAccountTransactionParameter)
        {
            AccountTransaction accTrx = new AccountTransaction(ObjectContext);
            accTrx.SubEpisodeProtocol = this;
            accTrx.InvoiceInclusion = true;
            accTrx.PricingDetail = mPricingDetail.PricingDetailDefinition;
            accTrx.ExternalCode = mPricingDetail.ExternalCode;
            accTrx.Description = mPricingDetail.Description;
            accTrx.CurrentStateDefID = AccountTransaction.States.New;

            if (pPackageDefinition != null) // Paket Tanımına göre paket içi olması gerekiyorsa   
            {
                accTrx.PackageDefinition = pPackageDefinition;
                accTrx.InvoiceInclusion = false;
            }

            if (accType == AccountOwnerType.PAYER)
            {
                // Hasta ve kurum payı 0 ise, AccTrx in hasta veya kurum payı olarak oluşacağına anlaşmasından karar veriliyor, SGK ise hasta payına çevrilmez.
                if (mPricingDetail.PayerPrice == 0 && mPricingDetail.PatientPrice == 0 && Payer.IsSGKAll == false && Protocol.Type == ProtocolTypeEnum.Paid)
                    accTrx.AccountPayableReceivable = SubEpisode.Episode.Patient.MyAPR();
                else
                    accTrx.AccountPayableReceivable = Payer.MyAPR();

                accTrx.UnitPrice = mPricingDetail.PayerPrice;
            }
            else if (accType == AccountOwnerType.PATIENT)
            {
                accTrx.AccountPayableReceivable = SubEpisode.Episode.Patient.MyAPR();
                accTrx.UnitPrice = mPricingDetail.PatientPrice;
            }

            if (addAccountTransactionParameter != null)
            {
                accTrx.Amount = addAccountTransactionParameter.Amount;
                accTrx.TransactionDate = addAccountTransactionParameter.TransactionDate;
            }

            if (pObject.ObjectDef.IsOfType("SUBACTIONPROCEDURE") == true)
            {
                SubActionProcedure mySubActionProc = (SubActionProcedure)pObject;

                if (mySubActionProc.PricingDate == null)     // PricingDate boş ise, önce ActionDate set edilsin, ActionDate boş ise
                {                                           // serverTime set edilsin şeklinde istendi )
                    if (mySubActionProc.ActionDate != null)
                        mySubActionProc.PricingDate = mySubActionProc.ActionDate;
                    else
                        mySubActionProc.PricingDate = Common.RecTime();
                }

                if (accTrx.Amount.HasValue == false)
                    accTrx.Amount = mySubActionProc.Amount;

                if (accTrx.TransactionDate.HasValue == false)
                    accTrx.TransactionDate = mySubActionProc.PricingDate;

                if (!string.IsNullOrEmpty(mySubActionProc.ExtraDescription))
                    accTrx.Description += " " + mySubActionProc.ExtraDescription;

                mySubActionProc.AccountTransactions.Add(accTrx);
            }
            else if (pObject.ObjectDef.IsOfType("SUBACTIONMATERIAL") == true)
            {
                SubActionMaterial mySubActionMat = (SubActionMaterial)pObject;

                if (mySubActionMat.PricingDate == null)    // PricingDate boş ise, önce ActionDate set edilsin, ActionDate boş ise
                {                                          // serverTime set edilsin şeklinde istendi )
                    if (mySubActionMat.ActionDate != null)
                        mySubActionMat.PricingDate = mySubActionMat.ActionDate;
                    else
                        mySubActionMat.PricingDate = Common.RecTime();
                }

                if (accTrx.Amount.HasValue == false)
                    accTrx.Amount = mySubActionMat.Amount;

                if (accTrx.TransactionDate.HasValue == false)
                    accTrx.TransactionDate = mySubActionMat.PricingDate;

                // İlaçlar için barkodu dolu ise, accTrx.ExternalCode barkod ile set edilir
                if (mySubActionMat.Material != null && mySubActionMat.Material is DrugDefinition && !string.IsNullOrEmpty(mySubActionMat.Material.Barcode))
                    accTrx.ExternalCode = mySubActionMat.Material.Barcode;

                if (!string.IsNullOrEmpty(mySubActionMat.UBBCode))
                    accTrx.Description += " (UBB Kodu:" + mySubActionMat.UBBCode + ")";

                if (accTrx.PricingDetail != null && accTrx.PricingDetail.DiscountPercent != null && accTrx.PricingDetail.DiscountPercent > 0)
                    accTrx.Description += " (%" + (accTrx.PricingDetail.DiscountPercent * 100) + " İNDİRİM)";

                // Sarf malzemeler, SGK kurum payı ise satış fiyatı + %12, diğer durumlarda alış fiyatı + %15 + %1 + %1 + %1 şeklinde ücretlendirilir
                ConsumableMaterialDefinition consumableMaterial = mySubActionMat.Material as ConsumableMaterialDefinition;
                if (consumableMaterial != null)
                {   // SGK kurum payı ve satış fiyatı > 0 ise : Satış Fiyatı + %12
                    if (Payer.IsSGKAll && accType == AccountOwnerType.PAYER && accTrx.UnitPrice > 0)
                        accTrx.UnitPrice = accTrx.UnitPrice * 1.12;
                    else // Diğer durumlarda ; SGK kurum payı ve satış fiyatı 0 ise : KDV'li alış fiyatı + %12
                    {    //                    Değilse                              : KDV'li alış fiyatı + %15 + %1 + %1 + %1
                        if (addAccountTransactionParameter != null)
                        {
                            if (addAccountTransactionParameter.PurchasePrice.HasValue && addAccountTransactionParameter.PurchasePrice.Value > 0) // KDV'li alış fiyatı var ve 0 dan büyükse
                            {
                                double vatRateMultiplier = 1;
                                // addAccountTransactionParameter.PurchasePrice : KDV'li alış fiyatı normalde fakat 
                                // Alış KDV oranı boş veya 0 ise, malzemenin tanımında bir KDV oranı varsa bu oran alış fiyatının üzerine eklenir.
                                if (addAccountTransactionParameter.PurchaseVatRate.HasValue == false || addAccountTransactionParameter.PurchaseVatRate == 0)
                                {
                                    if (mySubActionMat.Material != null && mySubActionMat.Material.MaterialVatRates != null && mySubActionMat.Material.MaterialVatRates.Count > 0)
                                    {
                                        double vatRate = 0;

                                        if (mySubActionMat.Material.MaterialVatRates.Count == 1 && mySubActionMat.Material.MaterialVatRates[0].VatRate.HasValue)
                                            vatRate = mySubActionMat.Material.MaterialVatRates[0].VatRate.Value;
                                        else
                                            vatRate = mySubActionMat.Material.GetVatrateFromMaterial(mySubActionMat.PricingDate);

                                        if (vatRate > 0)
                                            vatRateMultiplier += (vatRate / 100);
                                    }
                                }

                                if (Payer.IsSGKAll && accType == AccountOwnerType.PAYER) // SGK kurum payı ve satış fiyatı 0 ise : KDV'li alış fiyatı + %12
                                    accTrx.UnitPrice = addAccountTransactionParameter.PurchasePrice.Value * vatRateMultiplier * 1.12;
                                else                                                     // Değilse : KDV'li alış fiyatı + %15 + %1 + %1 + %1
                                    accTrx.UnitPrice = addAccountTransactionParameter.PurchasePrice.Value * vatRateMultiplier * 1.15 * 1.01 * 1.01 * 1.01;
                            }
                        }
                    }
                    // StockOutTransaction, AccountTransaction üzerinde tutulur
                    if (addAccountTransactionParameter != null)
                    {
                        accTrx.StockOutTransaction = addAccountTransactionParameter.StockOutTransaction;
                        accTrx.UTSNotificationDetail = addAccountTransactionParameter.UTSNotificationDetail;
                    }
                }

                // "Birim Fiyat Böleni" veya "Miktar Çarpanı" olan ve fiyat tanımından ücretlenen ilaçlar için accTrx.UnitPrice ve accTrx.Amount değiştirilir
                // Burası kaldırıldı, ATLAS için bu şekilde çalışmayacak )
                //if (accTrx.PricingDetail != null)
                //{
                //    DrugDefinition drug = mySubActionMat.Material as DrugDefinition;
                //    if (drug != null)
                //    {
                //        if (accTrx.UnitPrice.HasValue && drug.AccTrxUnitPriceDivider.HasValue && drug.AccTrxUnitPriceDivider.Value != 0)
                //            accTrx.UnitPrice = accTrx.UnitPrice / drug.AccTrxUnitPriceDivider.Value;

                //        if (accTrx.Amount.HasValue && drug.AccTrxAmountMultiplier.HasValue && drug.AccTrxAmountMultiplier.Value != 0)
                //            accTrx.Amount = accTrx.Amount * drug.AccTrxAmountMultiplier.Value;
                //    }
                //}

                mySubActionMat.AccountTransactions.Add(accTrx);
            }

            if (accTrx.UnitPrice.HasValue)
            {
                accTrx.UnitPriceOrg = accTrx.UnitPrice;
                accTrx.UnitPrice = Math.Round(accTrx.UnitPrice.Value, 2);
            }

            accTrx.ControlToSetInvoiceInclusion();
        }

        public class MedulaTransferredPayerWarningDTO
        {
            public string DevredilenKurumAdi { get; set; } = string.Empty;
            public MedulaResult medulaResult { get; set; }
            public PatientDTO patient { get; set; } = new PatientDTO();
        }

        public class PatientDTO
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
            public DateTime? BirthDate { get; set; }
            public long? TCNo { get; set; }
        }

        public class MedulaResult
        {
            private bool _succes;
            private string _basvuruNo;
            private string _takipNo;
            private string _sonucMesaji;
            private string _protocolNo;
            private string _sonucKodu;
            private string _bagliTakipNo;
            private Guid _SEPObjectID;
            public string DevredilenKurumAdi { get; set; } = string.Empty;

            public Guid SEPObjectID
            {
                get
                {
                    return _SEPObjectID;
                }
                set
                {
                    _SEPObjectID = value;
                }
            }

            public bool Succes
            {
                get
                {
                    return _succes;
                }
                set
                {
                    _succes = value;
                }
            }
            public string BasvuruNo
            {
                get
                {
                    return _basvuruNo;
                }
                set
                {
                    _basvuruNo = value;
                }
            }
            public string TakipNo
            {
                get
                {
                    return _takipNo;
                }
                set
                {
                    _takipNo = value;
                }
            }
            public string ProtocolNo
            {
                get
                {
                    return this._protocolNo;
                }
                set
                {
                    this._protocolNo = value;
                }
            }
            public string SonucMesaji
            {
                get
                {
                    return _sonucMesaji;
                }
                set
                {
                    _sonucMesaji = value;
                }
            }
            public string SonucKodu
            {
                get
                {
                    return _sonucKodu;
                }
                set
                {
                    _sonucKodu = value;
                }
            }
            public string BagliTakipNo
            {
                get
                {
                    return _bagliTakipNo;
                }
                set
                {
                    _bagliTakipNo = value;
                }
            }
            public MedulaResult()
            {
                SonucKodu = "";
                SonucMesaji = "";
                Succes = false;
                TakipNo = "";
                BasvuruNo = "";
            }

            public MedulaResult(string sonucKodu, string sonucMesaji)
            {
                SonucKodu = sonucKodu;
                SonucMesaji = sonucMesaji;
                Succes = false;
                TakipNo = "";
                BasvuruNo = "";
            }
        }


        public MedulaResult mustehaklikSorgusuFromMedula(string date, string takipNo = null)
        {
            MedulaResult result = new MedulaResult();
            HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO = null;
            HastaKabulIslemleri.provizyonCevapDVO provizyonCevapDVO = null;

            provizyonGirisDVO = GetProvisionGirisDvo(null, Convert.ToDateTime(date));
            if (!string.IsNullOrEmpty(takipNo))
                provizyonGirisDVO.takipNo = takipNo;

            provizyonCevapDVO = HastaKabulIslemleri.WebMethods.hastaKabulSync(TTObjectClasses.Sites.SiteLocalHost, provizyonGirisDVO);

            if (provizyonCevapDVO.sonucKodu.Equals("0533") || provizyonCevapDVO.sonucKodu.Equals("0541") || provizyonCevapDVO.sonucKodu.Equals("0542") ||
                provizyonCevapDVO.sonucKodu.Equals("0549") || provizyonCevapDVO.sonucKodu.Equals("1129"))
            {
                Thread.Sleep(3000);
                int startIndex = provizyonCevapDVO.sonucMesaji.IndexOf('[') + 1;
                int length = provizyonCevapDVO.sonucMesaji.IndexOf(']') - provizyonCevapDVO.sonucMesaji.IndexOf('[') - 1;
                result = mustehaklikSorgusuFromMedula(date, provizyonCevapDVO.sonucMesaji.Substring(startIndex, length));
            }
            else if (provizyonCevapDVO.sonucKodu.Equals("0000") || provizyonCevapDVO.sonucKodu.Equals("9000") || provizyonCevapDVO.sonucKodu.Equals("0008") || provizyonCevapDVO.sonucKodu.Equals("1163"))
            {
                XXXXXXMedulaServices ams = new XXXXXXMedulaServices();
                HastaKabulIslemleri.takipSilCevapDVO takipSilCevapDVO = new HastaKabulIslemleri.takipSilCevapDVO();
                takipSilCevapDVO = ams.fazlaTakipSil(provizyonCevapDVO.takipNo);

                for (int i = 0; i < 3; i++)
                {
                    if (takipSilCevapDVO.sonucKodu.Equals("0000"))
                    {
                        result.SonucMesaji = "Müstehaklık sorgusu başarılı. Referans takip numarası:" + provizyonCevapDVO.takipNo;
                        result.Succes = true;
                        break;
                    }
                    else
                    {
                        result.SonucMesaji = "Müstehaklık sorgusu sırasında meduladan takip alındı ancak silinemedi. Silinemeyen takibi 'Diğer Medula İşlemleri' menüsü altında fazladan takipler ekranından silebilirsiniz. Takip No: " + provizyonCevapDVO.takipNo + "Sonuç mesajı: " + provizyonCevapDVO.sonucMesaji;
                        result.Succes = false;
                    }
                }
            }
            else
            {
                result.SonucMesaji = "Müstehaklık sorgusu başarısız. Sonuç mesajı: " + provizyonCevapDVO.sonucMesaji;
                result.Succes = false;
            }

            return result;
        }

        public MedulaResult GetProvisionFromMedula(string takipNo = null, HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO = null, DateTime? MedulaProvizyonTarihi = null)
        {
            MedulaResult result = new MedulaResult();

            if (!IsSGK)
                throw new TTException(TTUtils.CultureService.GetText("M26871", "SGK olmayan kurumlar için takip alınamaz."));

            if (InvoiceStatus != MedulaSubEpisodeStatusEnum.ProvisionNoNotExists)
                throw new TTException("(" + Common.GetDisplayTextOfEnumValue("MedulaSubEpisodeStatusEnum", (int)InvoiceStatus) + TTUtils.CultureService.GetText("M25025", ") Takip alınmaya çalışılan protokolün durumu takip almaya uygun değildir. Lütfen kontrol ediniz."));

            CheckSEPConsistency();

            HastaKabulIslemleri.provizyonCevapDVO provizyonCevapDVO = null;
            DateTime sendingTime;
            //try
            //{
            if (provizyonGirisDVO == null)
                provizyonGirisDVO = GetProvisionGirisDvo(takipNo, MedulaProvizyonTarihi);

            provizyonCevapDVO = HastaKabulIslemleri.WebMethods.hastaKabulSync(TTObjectClasses.Sites.SiteLocalHost, provizyonGirisDVO);
            sendingTime = DateTime.Now;
            //}
            //catch (Exception e)
            //{
            //    result.Succes = false;
            //    result.SonucMesaji = e.AllMessage() + " - " + e.AllStackTrace();

            //    return result;
            //}

            if (provizyonCevapDVO.sonucKodu.Equals("0533") || provizyonCevapDVO.sonucKodu.Equals("0541") || provizyonCevapDVO.sonucKodu.Equals("0542") ||
                provizyonCevapDVO.sonucKodu.Equals("0549") || provizyonCevapDVO.sonucKodu.Equals("1129"))
            {
                int startIndex = provizyonCevapDVO.sonucMesaji.IndexOf('[') + 1;
                int length = provizyonCevapDVO.sonucMesaji.IndexOf(']') - provizyonCevapDVO.sonucMesaji.IndexOf('[') - 1;
                provizyonGirisDVO.takipNo = provizyonCevapDVO.sonucMesaji.Substring(startIndex, length);

                provizyonGirisDVO = ClearFacultativeDataFromProvizyonGirisDvo(provizyonGirisDVO);
                DateTime sendingAgain = DateTime.Now;
                if (sendingAgain.TimeOfDay.TotalMilliseconds - sendingTime.TimeOfDay.TotalMilliseconds < 3000)
                    Thread.Sleep(3000 - Convert.ToInt32((sendingAgain.TimeOfDay.TotalMilliseconds - sendingTime.TimeOfDay.TotalMilliseconds)));

                result = GetProvisionFromMedula(null, provizyonGirisDVO);

                return result;
            }
            else if (provizyonCevapDVO.sonucKodu.Equals("9103") || provizyonCevapDVO.sonucKodu.Equals("9102"))
            {
                Thread.Sleep(1000);
                result = GetProvisionFromMedula(null, provizyonGirisDVO);

                return result;
            }
            else if (provizyonCevapDVO.sonucKodu.Equals("0000") || provizyonCevapDVO.sonucKodu.Equals("9000") || provizyonCevapDVO.sonucKodu.Equals("0008") || provizyonCevapDVO.sonucKodu.Equals("1163"))
            {
                SubEpisodeProtocol tempSEP = null;
                if (provizyonCevapDVO.sonucKodu.Equals("1163"))
                {
                    string takipNoInError = string.Empty;
                    int startIndex = provizyonCevapDVO.sonucMesaji.IndexOf('[') + 1;
                    int length = provizyonCevapDVO.sonucMesaji.IndexOf(']') - provizyonCevapDVO.sonucMesaji.IndexOf('[') - 1;
                    takipNoInError = provizyonCevapDVO.sonucMesaji.Substring(startIndex, length);

                    tempSEP = GetSEPByProvisionNo(takipNoInError);
                    if (tempSEP == null)
                    {
                        HastaKabulIslemleri.takipDVO tempTakip = ReadProvisionFromMedula(takipNoInError);

                        provizyonCevapDVO.hastaBilgileri = tempTakip.hastaBilgileri;
                        provizyonCevapDVO.hastaBasvuruNo = tempTakip.hastaBasvuruNo;
                        provizyonCevapDVO.takipNo = tempTakip.takipNo;
                        provizyonGirisDVO.takipNo = tempTakip.ilkTakipNo;
                        provizyonGirisDVO.provizyonTarihi = tempTakip.takipTarihi;
                    }

                }
                if (tempSEP == null)
                {
                    if (string.IsNullOrEmpty(provizyonGirisDVO.takipNo) == false)
                    {
                        ParentSEP = GetSEPByProvisionNo(provizyonGirisDVO.takipNo);

                        if (ParentSEP != null)
                        {
                            SEPMaster = ParentSEP.SEPMaster;

                            if (ParentSEP.MedulaProvizyonTipi != null)
                                MedulaProvizyonTipi = ParentSEP.MedulaProvizyonTipi;
                        }
                        else
                        {
                            if (SEPMaster.SubEpisodeProtocols.Count > 1)
                            {
                                SEPMaster = new SEPMaster(ObjectContext);
                            }

                        }
                    }
                    else
                    {
                        if (SEPMaster.SubEpisodeProtocols.Count > 1 && SEPMaster.SubEpisodeProtocols.Where(x => !string.IsNullOrEmpty(x.MedulaTakipNo)).Count() > 0)
                        {
                            SEPMaster = new SEPMaster(ObjectContext);
                        }
                        ParentSEP = null;
                    }


                    if (provizyonCevapDVO.hastaBilgileri != null && !string.IsNullOrEmpty(provizyonCevapDVO.hastaBilgileri.sigortaliTuru))
                        MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru(provizyonCevapDVO.hastaBilgileri.sigortaliTuru);


                    if (provizyonCevapDVO.hastaBilgileri != null && !string.IsNullOrEmpty(provizyonCevapDVO.hastaBilgileri.devredilenKurum)
                        && !(Payer.MedulaDevredilenKurum != null && Payer.MedulaDevredilenKurum.devredilenKurumKodu == "28"))
                    {
                        MedulaDevredilenKurum = DevredilenKurum.GetDevredilenKurum(provizyonCevapDVO.hastaBilgileri.devredilenKurum);

                        if ((Payer.MedulaDevredilenKurum != null && Payer.MedulaDevredilenKurum.ObjectID != MedulaDevredilenKurum.ObjectID) || Payer.ParentPayer == null)
                        {
                            ChangePayerByMedulaDevredilenKurum();

                            if (MedulaDevredilenKurum != null)
                                result.DevredilenKurumAdi = MedulaDevredilenKurum.devredilenKurumAdi;
                            else
                                result.DevredilenKurumAdi = Payer.Name;
                        }
                    }


                    MedulaBasvuruNo = provizyonCevapDVO.hastaBasvuruNo;
                    MedulaTakipNo = provizyonCevapDVO.takipNo;
                    InvoiceCancelCount = null;
                    this.MedulaProvizyonTarihi = Convert.ToDateTime(provizyonGirisDVO.provizyonTarihi);
                    if (provizyonCevapDVO.hastaBilgileri != null)
                    {
                        MedulaKapsamAdi = provizyonCevapDVO.hastaBilgileri.kapsamAdi;
                        MedulaKatilimPayindanMuaf = provizyonCevapDVO.hastaBilgileri.katilimPayindanMuaf;
                    }

                    if (provizyonCevapDVO.sigortaliAdliGecmisi != null && provizyonCevapDVO.sigortaliAdliGecmisi.Length > 0)
                    {
                        Patient _patient = SubEpisode.Episode.Patient;
                        BindingList<SigortaliAdliGecmisi> sagList = _patient.SigortaliAdliGecmisi.Select("");

                        foreach (SigortaliAdliGecmisi tempSag in sagList)
                        {
                            ((ITTObject)tempSag).Delete();
                        }
                        foreach (var tempItem in provizyonCevapDVO.sigortaliAdliGecmisi)
                        {
                            SigortaliAdliGecmisi sag = new SigortaliAdliGecmisi(ObjectContext, _patient, tempItem.provTarihi, tempItem.provTipi, tempItem.tckNo);
                        }
                    }

                    InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;

                    if (MedulaIstisnaiHal?.Kodu == "9" && MedulaProvizyonTipi?.provizyonTipiKodu == "N" && MedulaTedaviTuru.tedaviTuruKodu == "A")
                    {
                        PatientExamination pe = SubEpisode.PatientAdmission.GetPatientExaminationFiredByMe();
                        if (pe != null)
                            pe.AddPatientExaminationParticipationProcedure();
                        else
                        {
                            DentalExamination de = SubEpisode.PatientAdmission.GetDentalExaminationFiredByMe();
                            if (de != null)
                                de.AddPatientExaminationParticipationProcedure();
                        }
                    }

                    result.Succes = true;
                }
                else
                {
                    result.Succes = false;
                }
                InvoiceLog.AddInfo(string.Format("Meduladan başarı ile takip alındı. Takip No: {0}", provizyonCevapDVO.takipNo), ObjectID, InvoiceOperationTypeEnum.TakipAl, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
            }
            else
            {
                InvoiceLog.AddErr(string.Format("Takip Alma İşlemi Başarısız.Sonuc Kodu: {0} , Sonuc Aciklama: {1}", provizyonCevapDVO.sonucKodu, provizyonCevapDVO.sonucMesaji), ObjectID, InvoiceOperationTypeEnum.TakipAl, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                MedulaSonucKodu = provizyonCevapDVO.sonucKodu;
                MedulaSonucMesaji = provizyonCevapDVO.sonucMesaji;
                result.Succes = false;

                InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;

            }
            result.ProtocolNo = this.SubEpisode?.ProtocolNo;
            result.BasvuruNo = provizyonCevapDVO.hastaBasvuruNo;
            result.TakipNo = provizyonCevapDVO.takipNo;
            result.SonucKodu = provizyonCevapDVO.sonucKodu;
            result.SonucMesaji = provizyonCevapDVO.sonucMesaji;
            result.BagliTakipNo = provizyonGirisDVO.takipNo;

            return result;
        }

        public HastaKabulIslemleri.hastaCikisCevapDVO HastaCikisKayitIptalFromMedula(string dischargeDate)
        {
            HastaKabulIslemleri.hastaCikisCevapDVO response = new HastaKabulIslemleri.hastaCikisCevapDVO();
            if (IsSGK)
            {
                string basvuruNo = MedulaBasvuruNo;

                if (string.IsNullOrEmpty(basvuruNo))
                    throw new TTException("Medulaya çıkış kaydı sadece takipli hastalarda yapılabilir. Başvuru numarası boş olamaz.");

                HastaKabulIslemleri.hastaCikisIptalDVO hastaCikisIptalDVO = new HastaKabulIslemleri.hastaCikisIptalDVO();
                hastaCikisIptalDVO.hastaBasvuruNo = basvuruNo;


                if (!string.IsNullOrEmpty(dischargeDate) && dischargeDate != "-")
                    hastaCikisIptalDVO.hastaCikisTarihi = dischargeDate;
                else
                    throw new TTException("Medulaya çıkış kaydı iptali için çıkış tarihi  belli olmalıdır!");

                hastaCikisIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                response = HastaKabulIslemleri.WebMethods.hastaCikisIptalSync(TTObjectClasses.Sites.SiteLocalHost, hastaCikisIptalDVO);

            }
            else
                throw new TTUtils.TTException(response.sonucMesaji);

            return response;
        }

        public HastaKabulIslemleri.hastaCikisCevapDVO HastaCikisKayitToMedula(string dischargeDate)
        {
            HastaKabulIslemleri.hastaCikisCevapDVO response = new HastaKabulIslemleri.hastaCikisCevapDVO();
            if (IsSGK)
            {
                string basvuruNo = MedulaBasvuruNo;

                if (string.IsNullOrEmpty(basvuruNo))
                    throw new TTException("Medulaya çıkış kaydı sadece takipli hastalarda yapılabilir. Başvuru numarası boş olamaz.");

                HastaKabulIslemleri.hastaCikisDVO hastaCikisDVO = new HastaKabulIslemleri.hastaCikisDVO();
                hastaCikisDVO.hastaBasvuruNo = basvuruNo;


                if (!string.IsNullOrEmpty(dischargeDate))
                    hastaCikisDVO.hastaCikisTarihi = Convert.ToDateTime(dischargeDate).ToString("dd.MM.yyyy");
                else
                    throw new TTException("Medulaya çıkış kaydı için çıkış tarihi  belli olmalıdır!");

                hastaCikisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                response = HastaKabulIslemleri.WebMethods.hastaCikisKayitSync(TTObjectClasses.Sites.SiteLocalHost, hastaCikisDVO);

                if (response.sonucKodu.Equals("0000") && DischargeDate == null)
                {
                    DischargeDate = Convert.ToDateTime(dischargeDate);
                }
            }
            else
                throw new TTUtils.TTException(response.sonucMesaji);

            return response;
        }

        public HastaKabulIslemleri.hastaYatisOkuCevapDVO HastaYatisOkuFromMedula()
        {
            HastaKabulIslemleri.hastaYatisOkuCevapDVO hastaYatisOkuCevapDVO = null;
            HastaKabulIslemleri.hastaYatisOkuDVO hastaYatisOkuDVO = new HastaKabulIslemleri.hastaYatisOkuDVO();

            if (string.IsNullOrEmpty(MedulaBasvuruNo))
                throw new TTException("Başvuru numarası boş olan kayıtlarda yatış okuma işlemi yapılamaz.");

            hastaYatisOkuDVO.hastaBasvuruNo = MedulaBasvuruNo;
            hastaYatisOkuDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            try
            {
                hastaYatisOkuCevapDVO = HastaKabulIslemleri.WebMethods.hastaYatisOkuSync(TTObjectClasses.Sites.SiteLocalHost, hastaYatisOkuDVO);
                return hastaYatisOkuCevapDVO;
            }
            catch (Exception e)
            {
                throw new TTException(e.Message);
            }

        }

        public void ChangePayerByMedulaDevredilenKurum()
        {
            if (MedulaDevredilenKurum != null)
            {
                BindingList<PayerDefinition> pdList = PayerDefinition.GetByDevredilenKurum(ObjectContext, MedulaDevredilenKurum.ObjectID);

                if (pdList != null && pdList.Count > 0)
                {
                    PayerDefinition pd = pdList.First();

                    Payer = pd;

                    if (PatientAdmission != null)
                        PatientAdmission.Payer = pd;

                    //ProtocolDefinition currentProtocolDef = this.Protocol;
                    //ProtocolDefinition newProtocolDef = pd.GetProtocol(this.Episode.Patient, this.MedulaSigortaliTuru);
                    //TODO: AAE SGK altında farklı protocol lerin gelmeyeceğini düşünüyoruz. Gelirse burası yeniden değerlendirilecek.
                    //if (newProtocolDef.ObjectID != currentProtocolDef.ObjectID)
                    //{
                    //    this.Protocol = newProtocolDef;
                    //}
                }
            }
        }

        //Medula Klavuzdaki Gerekli mi? Evet* alanların temizlenmesi
        public HastaKabulIslemleri.provizyonGirisDVO ClearFacultativeDataFromProvizyonGirisDvo(HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO)
        {
            provizyonGirisDVO.sigortaliTuru = "";
            provizyonGirisDVO.devredilenKurum = "";
            provizyonGirisDVO.provizyonTipi = "";

            return provizyonGirisDVO;
        }

        public HastaKabulIslemleri.provizyonGirisDVO GetProvisionGirisDvo(string takipNo = null, DateTime? MedulaProvizyonTarihi = null)
        {
            HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO = new HastaKabulIslemleri.provizyonGirisDVO();
            provizyonGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            provizyonGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();

            //YUPASS NO set et
            if (provizyonGirisDVO.hastaTCKimlikNo == null && SubEpisode != null && SubEpisode.Episode != null
                && SubEpisode.Episode.Patient != null && SubEpisode.Episode.Patient.YUPASSNO != null
                && SubEpisode.Episode.Patient.YUPASSNO.Value != 0)
            {
                provizyonGirisDVO.hastaTCKimlikNo = SubEpisode.Episode.Patient.YUPASSNO.Value.ToString();

                int? YUPASSID;
                if (SubEpisode.PatientAdmission != null && SubEpisode.PatientAdmission.RelatedProvision != null)//Bağlı takip var, aynı güne ait bir takip ise aynı yupassid kullanılmalı MC
                {
                    if (ParentSEP != null && ParentSEP.MedulaYupassNo != null && ParentSEP.MedulaYupassNo.Value != 0 && ParentSEP.MedulaProvizyonTarihi == this.MedulaProvizyonTarihi)
                        YUPASSID = ParentSEP.MedulaYupassNo.Value;
                    else
                        YUPASSID = SubEpisode.PatientAdmission.YurtDisiYardimHakkiSorgula(this.MedulaProvizyonTarihi.Value.ToString("dd.MM.yyyy"));
                }
                else
                    YUPASSID = SubEpisode.PatientAdmission.YurtDisiYardimHakkiSorgula(this.MedulaProvizyonTarihi.Value.ToString("dd.MM.yyyy"));
                provizyonGirisDVO.yardimHakkiID = YUPASSID;
            }

            if (SubEpisode.PatientAdmission != null && !string.IsNullOrEmpty(SubEpisode.PatientAdmission.KurumSevkTalepNo))
                provizyonGirisDVO.kurumSevkTalepNo = SubEpisode.PatientAdmission.KurumSevkTalepNo;

            if (provizyonGirisDVO.yardimHakkiID != null)
                provizyonGirisDVO.hastaTCKimlikNo = Episode.Patient.YUPASSNO.ToString();
            else
            {
                if (SubEpisode.Episode.Patient.Privacy == true && SubEpisode.Episode.Patient.PrivacyUniqueRefNo.HasValue) //Gizli hasta ise
                    provizyonGirisDVO.hastaTCKimlikNo = SubEpisode.Episode.Patient.PrivacyUniqueRefNo.ToString();
                else if (SubEpisode.Episode.IsNewBorn != true)
                    provizyonGirisDVO.hastaTCKimlikNo = SubEpisode.Episode.Patient.UniqueRefNo.HasValue ? SubEpisode.Episode.Patient.UniqueRefNo.ToString() : null;
                else if (SubEpisode.Episode.IsNewBorn == true)
                {
                    if (SubEpisode.Episode.Patient.Mother != null && SubEpisode.Episode.Patient.Mother.UniqueRefNo.HasValue)
                        provizyonGirisDVO.hastaTCKimlikNo = SubEpisode.Episode.Patient.Mother.UniqueRefNo.ToString();
                    else
                        provizyonGirisDVO.hastaTCKimlikNo = null;

                    provizyonGirisDVO.yeniDoganBilgisi = GetYeniDoganBilgisiDVO(SubEpisode.Episode.Patient);
                }
                else
                    throw new Exception(TTUtils.CultureService.GetText("M26712", "Provizyon alınacak hasta Kimlik numarası dolu olmalıdır!"));
            }

            if (Brans != null)
                provizyonGirisDVO.bransKodu = Brans.Code;

            if (MedulaTakipTipi != null)
                provizyonGirisDVO.takipTipi = MedulaTakipTipi.takipTipiKodu;

            if (MedulaTedaviTuru != null)
                provizyonGirisDVO.tedaviTuru = MedulaTedaviTuru.tedaviTuruKodu;

            if (MedulaTedaviTipi != null)
                provizyonGirisDVO.tedaviTipi = MedulaTedaviTipi.tedaviTipiKodu;

            if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("S") && MedulaIstisnaiHal != null && MedulaIstisnaiHal.Kodu.Equals("9"))
            {
                MedulaProvizyonTipi = ProvizyonTipi.GetProvizyonTipi("N");
            }
            if ((Brans.Code == "4400" || Brans.Code == "1596") && MedulaProvizyonTipi.provizyonTipiKodu.Equals("N"))
            {
                MedulaProvizyonTipi = ProvizyonTipi.GetProvizyonTipi("A");
            }

            if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("T"))
            {
                if (MedulaPlakaNo != null)
                    provizyonGirisDVO.plakaNo = MedulaPlakaNo;
                else
                    throw new Exception(TTUtils.CultureService.GetText("M26716", "Provizyon Tipi Trafik Kazası olan hastalarda plakaNo alanı dolu olmalıdır!"));
            }
            else if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("S") || ((MedulaProvizyonTipi.provizyonTipiKodu.Equals("N") || MedulaProvizyonTipi.provizyonTipiKodu.Equals("A")) && MedulaIstisnaiHal != null && MedulaIstisnaiHal.Kodu.Equals("9")))
            {
                if (MedulaIstisnaiHal != null)
                    provizyonGirisDVO.istisnaiHal = MedulaIstisnaiHal.Kodu.ToString();
                else
                    throw new Exception(TTUtils.CultureService.GetText("M26715", "Provizyon Tipi İstisnai Hal Olan Hastalarda İstisnai Hal Alanı Dolu Olmalıdır!"));
            }
            //VAKA TARİHİ
            if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("T") || MedulaProvizyonTipi.provizyonTipiKodu.Equals("V") || MedulaProvizyonTipi.provizyonTipiKodu.Equals("I"))
            {
                if (MedulaVakaTarihi != null)
                    provizyonGirisDVO.vakaTarihi = MedulaVakaTarihi.Value.ToString("dd.MM.yyyy");
                else
                    throw new Exception(TTUtils.CultureService.GetText("M26717", "Provizyon Tipi Trafik Kazası,Adli Vaka ve  İş Kazası olan hastalarda Vaka Tarihi alanı dolu olmalıdır!"));
            }

            // Toplu sorgulama ekranında kullanılmak üzere kapatıldı. TODO: AAE fullpublish almamak için kapatıldı ihtiyaç duyulursa tekrar açılır.
            //provizyonGirisDVO.yesilKartSevkEdenTesisKodu = this.MedulaGreenCardFacilityCode;

            if (!string.IsNullOrEmpty(takipNo))
                provizyonGirisDVO.takipNo = takipNo;
            else if (ParentSEP != null && !string.IsNullOrEmpty(ParentSEP.MedulaTakipNo)) // && this.MedulaTedaviTuru.tedaviTuruKodu == "Y")  // Bu koşul FTR de alınan ayaktan takibin bağlı alınabilmesi için kaldırıldı 
                provizyonGirisDVO.takipNo = ParentSEP.MedulaTakipNo;

            if (!string.IsNullOrEmpty(provizyonGirisDVO.takipNo))
            {
                provizyonGirisDVO.sigortaliTuru = string.Empty;
                provizyonGirisDVO.devredilenKurum = string.Empty;
                provizyonGirisDVO.provizyonTipi = string.Empty;
            }
            else
            {
                if (MedulaSigortaliTuru != null)
                    provizyonGirisDVO.sigortaliTuru = MedulaSigortaliTuru.sigortaliTuruKodu;

                if (MedulaDevredilenKurum != null)
                    provizyonGirisDVO.devredilenKurum = MedulaDevredilenKurum.devredilenKurumKodu;

                if (MedulaProvizyonTipi != null)
                    provizyonGirisDVO.provizyonTipi = MedulaProvizyonTipi.provizyonTipiKodu;
            }

            //TODO:AAE Yatış Bitiş Tarihi Set Edilmeli

            if (MedulaTedaviTuru.tedaviTuruKodu == "Y")
            {
                if (DischargeDate.HasValue)
                    provizyonGirisDVO.yatisBitisTarihi = DischargeDate.Value.ToString("dd.MM.yyyy");
                else if (SubEpisode.ClosingDate.HasValue)
                    provizyonGirisDVO.yatisBitisTarihi = SubEpisode.ClosingDate.Value.ToString("dd.MM.yyyy");
                else
                    provizyonGirisDVO.yatisBitisTarihi = null;
            }
            else
                provizyonGirisDVO.yatisBitisTarihi = null;

            if (MedulaProvizyonTarihi.HasValue) //Parametre olarak gelen provizyon tarihi
                provizyonGirisDVO.provizyonTarihi = MedulaProvizyonTarihi.Value.ToString("dd.MM.yyyy");
            else if (this.MedulaProvizyonTarihi.HasValue)//SEP in üzerindeki tarih
                provizyonGirisDVO.provizyonTarihi = this.MedulaProvizyonTarihi.Value.ToString("dd.MM.yyyy");
            else
                provizyonGirisDVO.provizyonTarihi = SubEpisode.OpeningDate.Value.ToString("dd.MM.yyyy");


            if (MedulaDonorTCKimlikNo != null)
                provizyonGirisDVO.donorTCKimlikNo = MedulaDonorTCKimlikNo.ToString();

            string phone = string.Empty;
            if (SubEpisode.Episode.Patient.Privacy == true)//Gizli hasta ise
            {
                provizyonGirisDVO.hastaAdres = Episode.Patient.PrivacyHomeAddress;
                phone = Episode.Patient.PrivacyMobilePhone;

                if (!string.IsNullOrEmpty(phone))
                    provizyonGirisDVO.hastaTelefon = phone.Replace("(", string.Empty).Replace(")", string.Empty).TrimEnd().TrimStart().Replace(" ", string.Empty);
            }
            else if (SubEpisode.Episode.Patient.PatientAddress != null)
            {
                provizyonGirisDVO.hastaAdres = Episode.Patient.PatientAddress.HomeAddress;

                if (!string.IsNullOrEmpty(Episode.Patient.PatientAddress.MobilePhone))
                    phone = Episode.Patient.PatientAddress.MobilePhone;
                else if (!string.IsNullOrEmpty(Episode.Patient.PatientAddress.HomePhone))
                    phone = Episode.Patient.PatientAddress.HomePhone;
                else if (!string.IsNullOrEmpty(Episode.Patient.PatientAddress.BusinessPhone))
                    phone = Episode.Patient.PatientAddress.BusinessPhone;

                if (!string.IsNullOrEmpty(phone))
                    provizyonGirisDVO.hastaTelefon = phone.Replace("(", string.Empty).Replace(")", string.Empty).TrimEnd().TrimStart().Replace(" ", string.Empty);

                if (string.IsNullOrEmpty(provizyonGirisDVO.hastaTelefon))
                    throw new Exception("Hasta telefon numarası boş. Provizyon alınamaz.");
            }

            return provizyonGirisDVO;
        }


        public HastaKabulIslemleri.yeniDoganBilgisiDVO GetYeniDoganBilgisiDVO(Patient patient)
        {
            HastaKabulIslemleri.yeniDoganBilgisiDVO yeniDoganBilgisiDVO = new HastaKabulIslemleri.yeniDoganBilgisiDVO();
            yeniDoganBilgisiDVO.dogumTarihi = patient.BirthDate.HasValue ? patient.BirthDate.Value.ToString("dd.MM.yyyy") : null;
            yeniDoganBilgisiDVO.cocukSira = 1;

            // Çocuk sırası bilgisi dolu ise set edilir
            if (patient.BirthOrder != null && !string.IsNullOrWhiteSpace(patient.BirthOrder.KODU))
            {
                if (int.TryParse(patient.BirthOrder.KODU, out int cocukSira))
                {
                    if (1 <= cocukSira && cocukSira <= 5)
                        yeniDoganBilgisiDVO.cocukSira = cocukSira;
                }
            }

            return yeniDoganBilgisiDVO;
        }

        public static SubEpisodeProtocol GetSEPByProvisionNo(string ProvisionNo)
        {
            TTObjectContext context = new TTObjectContext(false);
            IBindingList medulaProvisionList = context.QueryObjects(typeof(SubEpisodeProtocol).Name, "MEDULATAKIPNO = '" + ProvisionNo + "'");
            if (medulaProvisionList.Count > 0)
                return (SubEpisodeProtocol)medulaProvisionList[0];

            return null;
        }


        public InvoiceInclusionResultEnum GetTransactionInclusionInfo(TTObject pObject)
        {
            LastIIM = GetInvoiceInclusionMaster();

            if (LastIIM != null)
                return LastIIM.GetResultForSingleTrx(pObject);
            else
                return InvoiceInclusionResultEnum.Included;
        }

        /// <summary>
        /// SEP e ait bütün AccountTransaction ları düzenleyen method
        /// </summary>
        /// <param name="compellingMaster">compellingMaster spesifik bir kural ile düzenleme çalıştırmak için kullanılır.</param>
        /// <returns> Düzenleme başarılı ise true döner. </returns>
        public bool ArrangeAllTrxs(InvoiceInclusionMaster compellingMaster = null)
        {
            if (compellingMaster != null)
                LastIIM = compellingMaster;
            else
                LastIIM = GetInvoiceInclusionMaster();

            if (LastIIM == null)
                return false;

            List<IIMNQLProcedureMaterial> _listOfGroup = LastIIM.IIMNQLProcedureMaterials.Select(" INVOICEINCLUSIONNQL is not null ").ToList();

            IEnumerable<int?> distinctList = _listOfGroup.Select(x => x.InvoiceInclusionNQL.OrderNo).Distinct().OrderBy(x => x.Value);

            foreach (var item in distinctList)
            {
                ArrangeAllTrxsPartOf(item, InvoiceInclusionResultEnum.Included, _listOfGroup);

                ArrangeAllTrxsPartOf(item, InvoiceInclusionResultEnum.DoNotSendToMedula, _listOfGroup);

                ArrangeAllTrxsPartOf(item, InvoiceInclusionResultEnum.ForInfo, _listOfGroup);
            }

            List<IIMNQLProcedureMaterial> _listOfSingleProcedure = LastIIM.IIMNQLProcedureMaterials.Select(" PROCEDUREDEFINITION is not null ").ToList();

            if (_listOfSingleProcedure.Count > 0)
            {
                ArrangeAllTrxsPartOf(InvoiceInclusionResultEnum.Included, _listOfSingleProcedure);

                ArrangeAllTrxsPartOf(InvoiceInclusionResultEnum.DoNotSendToMedula, _listOfSingleProcedure);

                ArrangeAllTrxsPartOf(InvoiceInclusionResultEnum.ForInfo, _listOfSingleProcedure);
            }

            return true;
        }

        private void ArrangeAllTrxsPartOf(InvoiceInclusionResultEnum result, List<IIMNQLProcedureMaterial> _listOfSingleProcedure)
        {
            List<IIMNQLProcedureMaterial> tempList = _listOfSingleProcedure.Where(x => x.Result == result).ToList();

            if (tempList.Count == 0)
                return;

            string filter = " AND THIS:SUBACTIONPROCEDURE.PROCEDUREOBJECT IN (''";
            foreach (IIMNQLProcedureMaterial innerItem in tempList)
            {
                filter += ",'" + innerItem.ProcedureDefinition.ObjectID + "'";
            }

            filter += ")";

            BindingList<AccountTransaction> changeList = AccountTransaction.GetForInvoiceInclusionBySEP(ObjectContext, ObjectID, filter);

            foreach (AccountTransaction actrx in changeList)
            {
                actrx.SetInvoiceInclusion(result);
            }
        }

        private void ArrangeAllTrxsPartOf(int? item, InvoiceInclusionResultEnum result, List<IIMNQLProcedureMaterial> _listOfGroup)
        {
            List<IIMNQLProcedureMaterial> tempList = _listOfGroup.Where(x => x.InvoiceInclusionNQL.OrderNo == item && x.Result == result).ToList();

            if (tempList.Count == 0)
                return;

            string tempNQL;
            string filter = " AND ( 1 <> 1 ";
            foreach (IIMNQLProcedureMaterial innerItem in tempList)
            {
                tempNQL = "";
                if (innerItem.InvoiceInclusionNQL.NQL.Contains("[Exception]"))
                    tempNQL = innerItem.InvoiceInclusionNQL.NQL.Replace("[Exception]", " ");
                else
                    tempNQL = innerItem.InvoiceInclusionNQL.NQL;

                if (innerItem.InvoiceInclusionNQL.ProcedureMaterialType == ProcedureMaterialEnum.Procedure)
                    filter += " OR " + tempNQL.Replace("@", "THIS.SUBACTIONPROCEDURE.PROCEDUREOBJECT.");
                else
                    filter += " OR " + tempNQL.Replace("@", "THIS.SUBACTIONMATERIAL.MATERIAL.");
            }

            filter += " )";

            BindingList<AccountTransaction> changeList = AccountTransaction.GetForInvoiceInclusionBySEP(ObjectContext, ObjectID, filter);

            foreach (AccountTransaction actrx in changeList)
            {
                actrx.SetInvoiceInclusion(result);
            }
        }

        public InvoiceInclusionMaster GetInvoiceInclusionMaster()
        {
            //////////////////////////////////////////////////////////////
            ///////Kural tanımları basit bir şekilde yapılabilmesi ///////
            ///////için bu method içindeki bazı satırlar geçici olarak /// 
            ///////kapatıldı. Veri getirmek için TEMP bir NQL yazıldı ////
            //////////////////////////////////////////////////////////////

            Guid _protocol = Protocol.ObjectID;
            Guid _speciality = Brans.ObjectID;
            InvoiceInclusionMaster tempIIM = null;

            DateTime sepDate = MedulaProvizyonTarihi.Value;

            string _paketDurum = "Y";
            if (ContainsPackage())
                _paketDurum = "V";

            string _ilkBagliTakip = "B";
            if (ParentSEP == null)
                _ilkBagliTakip = "I";

            string _ayniFarkliBrans = "F";
            if (Brans != null && ParentSEP != null && ParentSEP.Brans != null)
            {
                if (Brans.Code == ParentSEP.Brans.Code)
                    _ayniFarkliBrans = "A";
            }

            string _provizyonTipi = "N";
            if (MedulaProvizyonTipi != null)
                _provizyonTipi = MedulaProvizyonTipi.provizyonTipiKodu;

            string _takipTipi = "N";
            if (MedulaTakipTipi != null)
                _takipTipi = MedulaTakipTipi.takipTipiKodu;

            string _tedaviTipi = "0";
            if (MedulaTedaviTipi != null)
                _tedaviTipi = MedulaTedaviTipi.tedaviTipiKodu;

            string _tedaviTuru = "A";
            if (MedulaTedaviTuru != null)
                _tedaviTuru = MedulaTedaviTuru.tedaviTuruKodu;

            string _istisnaiHal = "";
            bool _istisnaiHalControl = false;
            if (MedulaIstisnaiHal != null && !string.IsNullOrEmpty(MedulaIstisnaiHal.Kodu))
            {
                _istisnaiHal = MedulaIstisnaiHal.Kodu;
                _istisnaiHalControl = true;
            }


            string _triaj = "";
            bool _triajControl = false;

            if (!string.IsNullOrEmpty(SubEpisode.Episode.Triaj))
            {
                _triaj = SubEpisode.Episode.Triaj;
                _triajControl = true;
            }

            BindingList<InvoiceInclusionMaster> listOfIIM = InvoiceInclusionMaster.GetBySpecialityAndProtocol(ObjectContext, _protocol, _speciality, _ilkBagliTakip, _ayniFarkliBrans, _provizyonTipi, _takipTipi, _tedaviTipi, _tedaviTuru, _triajControl, _triaj, _istisnaiHal, _istisnaiHalControl, _paketDurum, sepDate);
            //BindingList<InvoiceInclusionMaster> listOfIIM = InvoiceInclusionMaster.GetBySpecialityAndProtocolTEMP(this.ObjectContext, _ayniFarkliBrans, sepDate, _ilkBagliTakip, _paketDurum, _protocol, _speciality, _tedaviTuru, _triaj, _triajControl, _tedaviTipi);


            if (listOfIIM.Count > 0)
                tempIIM = listOfIIM[0];

            var temp = "";
            if (listOfIIM == null || listOfIIM.Count == 0)
                InvoiceLog.AddInfo(TTUtils.CultureService.GetText("M27005", "Takip hiç bir düzenleme kuralına girmedi. Lütfen gerekli kontrolleri yapınız."), ObjectID, InvoiceOperationTypeEnum.ExecRule, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
            else if (listOfIIM.Count > 1)
                InvoiceLog.AddInfo(TTUtils.CultureService.GetText("M27004", "Takip birden fazla düzenleme kuralına girdi. Lütfen gerekli kontrolleri yapınız."), ObjectID, InvoiceOperationTypeEnum.ExecRule, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);

            return tempIIM;
        }

        /*
        public MedulaSubEpisodeStatusEnum GetAndSetMyStatusAfterProcedureEntry()
        {
            if (this.SubEpisode != null)
            {
                // Hata alınmış var ise
                List<Guid> stateList = new List<Guid>();
                stateList.Add(AccountTransaction.States.MedulaEntryUnsuccessful);
                
                BindingList<AccountTransaction.GetMedulaTransactionsBySubEpisodeAndState_Class> accTrxs = AccountTransaction.GetMedulaTransactionsBySubEpisodeAndState(this.SubEpisode.ObjectID, stateList.ToArray());
                if(accTrxs.Count > 0)
                {
                    this.Status = MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                    return (MedulaSubEpisodeStatusEnum)this.Status;
                }
                

                List<int> statuslist = new List<int>();
                statuslist.Add(3); // MedulaDiagnosisStatusEnum.EntryUnsuccessful
                BindingList<DiagnosisGrid.GetMedulaDiagnosisBySubEpisodeAndStatus_Class> diagnosisList = DiagnosisGrid.GetMedulaDiagnosisBySubEpisodeAndStatus(this.SubEpisode.ObjectID, statuslist.ToArray());
                if (diagnosisList.Count > 0)
                {
                    this.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                    return (MedulaSubEpisodeStatusEnum)this.InvoiceStatus;
                }

                // Hizmet Kaydı yapılmamış var ise
                
                stateList.Clear();
                accTrxs.Clear();
                stateList.Add(AccountTransaction.States.New);
                stateList.Add(AccountTransaction.States.ToBeNew);
                stateList.Add(AccountTransaction.States.MedulaSentServer);
                accTrxs = AccountTransaction.GetMedulaTransactionsBySubEpisodeAndState(this.SubEpisode.ObjectID, stateList.ToArray());
                if (accTrxs.Count > 0)
                {
                    this.Status = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                    return (MedulaSubEpisodeStatusEnum)this.Status;
                }
                

                statuslist.Clear();
                diagnosisList.Clear();
                statuslist.Add(0); // MedulaDiagnosisStatusEnum.New
                statuslist.Add(1); // MedulaDiagnosisStatusEnum.SentServer
                diagnosisList = DiagnosisGrid.GetMedulaDiagnosisBySubEpisodeAndStatus(this.SubEpisode.ObjectID, statuslist.ToArray());
                if (diagnosisList.Count > 0)
                {
                    this.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                    return (MedulaSubEpisodeStatusEnum)this.InvoiceStatus;
                }

                // İkisi de yoksa hepsi başarılı hizmet kaydı yapılmış demektir
                this.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted;
            }
            return (MedulaSubEpisodeStatusEnum)this.InvoiceStatus;
        }
        */

        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
                Id.GetNextValue();
        }

        // Takip altındaki Gündüz Yatak hizmetlerini ayarlar (Yoksa oluşturur, birden çok varsa fazla olanları iptal eder)
        public void ArrangeDailyBedProcedure()
        {
            // Fatura Kayıt bekleyen veya Faturalandı durumundaki takip için oluşturulmamalı
            if (IsInvoiced || CloneType == SEPCloneTypeEnum.PatientInvoice)
                return;

            string dailyBedProcedureSUTCode = ProcedureDefinition.DailyBedProcedureSUTCode;

            List<AccountTransaction> aTransactions = AccountTransactions.Select("SUBACTIONPROCEDURE IS NOT NULL AND CURRENTSTATEDEFID <> '4aa5b60f-96cb-4d02-900a-1195b87e24a2' AND EXTERNALCODE = '" + dailyBedProcedureSUTCode + "'").ToList();

            // Ayaktan veya yatan takip içinde Gündüz Yatak hizmeti varsa iptal edilir
            if (MedulaTedaviTuru.tedaviTuruKodu.Equals("A") || MedulaTedaviTuru.tedaviTuruKodu.Equals("Y"))
            {
                foreach (AccountTransaction accTrx in aTransactions)
                {
                    if (accTrx.IsAllowedToCancel)
                        accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
                }
            }
            else if (MedulaTedaviTuru.tedaviTuruKodu.Equals("G"))
            {
                if (aTransactions.Count == 0) // Gündüz Yatak hizmeti yoksa
                {
                    // İptal durumunda ve DailyBedProcedure tipinde Gündüz Yatak hizmeti varsa Yeni durumuna alınacak
                    List<AccountTransaction> cancelledTransactions = AccountTransactions.Select("SUBACTIONPROCEDURE IS NOT NULL AND CURRENTSTATEDEFID = '4aa5b60f-96cb-4d02-900a-1195b87e24a2' AND EXTERNALCODE = '" + dailyBedProcedureSUTCode + "'").ToList();
                    if (cancelledTransactions.Count > 0)
                    {
                        foreach (AccountTransaction accTrx in cancelledTransactions)
                        {
                            accTrx.CurrentStateDefID = AccountTransaction.States.New;
                            break;
                        }
                    }
                    else // İptal durumunda Gündüz Yatak hizmeti yoksa yeni bir tane oluşturulacak
                        AddDailyBedProcedure();
                }
                else if (aTransactions.Count > 1) // Birden çok Gündüz Yatak hizmeti varsa sadece bir tanesi kalacak, diğerleri iptal edilecek
                {
                    // "3200 : Radyasyon Onkolojisi" branşı hariç, bu branşta aynı takip içinde farklı tarihlerde birden çok Gündüz Yatak hizmeti olabiliyor
                    if (!Brans.Code.Equals("3200"))
                    {
                        bool paidOrInvoicedExists = aTransactions.Any(x => x.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful || x.CurrentStateDefID == AccountTransaction.States.Paid || x.CurrentStateDefID == AccountTransaction.States.Invoiced);

                        // Hizmet Kaydı Yapıldı, Ödendi veya Faturalandı durumunda bir Gündüz Yatak hizmeti varsa diğerlerinin hepsi iptal edilecek,
                        // yoksa bir tane Gündüz Yatak hizmeti bırakılacak ve diğerleri iptal edilecek
                        bool oneDailyBedProcedureLeft = false;
                        foreach (AccountTransaction accTrx in aTransactions)
                        {
                            if (accTrx.IsAllowedToCancel)
                            {
                                if (paidOrInvoicedExists)
                                    accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
                                else
                                {
                                    if (!oneDailyBedProcedureLeft)
                                    {
                                        if (accTrx.CurrentStateDefID != AccountTransaction.States.New)
                                            accTrx.CurrentStateDefID = AccountTransaction.States.New;
                                        oneDailyBedProcedureLeft = true;
                                    }
                                    else
                                        accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AddDailyBedProcedure()
        {
            // Fatura Kayıt bekleyen veya Faturalandı durumundaki takip için oluşturulmamalı
            if (IsInvoiced || CloneType == SEPCloneTypeEnum.PatientInvoice)
                return;

            if (MedulaTedaviTuru != null && MedulaTedaviTuru.tedaviTuruKodu != null && MedulaTedaviTuru.tedaviTuruKodu.Equals("G"))
            {
                EpisodeAction episodeAction = null;

                if (SubEpisode.StarterEpisodeAction != null)  // SubEpisode u oluşturan EpisodeAction seçilir
                    episodeAction = SubEpisode.StarterEpisodeAction;
                else if (SubEpisode.StarterSubActionProcedure != null) // SubEpisode u oluşturan SubActionProcedure ün EpisodeAction ı seçilir
                    episodeAction = SubEpisode.StarterSubActionProcedure.EpisodeAction;

                if (episodeAction == null)  // SubEpisode lardan durumu iptal olmayan bir EpisodeAction seçilir
                {
                    foreach (EpisodeAction ea in SubEpisode.EpisodeActions)
                    {
                        if (ea.CurrentStateDef != null && ea.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        {
                            episodeAction = ea;
                            break;
                        }
                    }
                }

                if (episodeAction == null) //Bulunmazsa Subepisodelardaki iptal durumu dışındaki bir AccTrx in EpisodeAction u alınır.
                {
                    foreach (AccountTransaction accTrx in AccountTransactions.Select("SUBACTIONPROCEDURE IS NOT NULL AND CURRENTSTATE <> STATES.CANCELLED"))
                    {
                        if (accTrx.SubActionProcedure.EpisodeAction.CurrentStateDef != null && accTrx.SubActionProcedure.EpisodeAction.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        {
                            episodeAction = accTrx.SubActionProcedure.EpisodeAction;
                            break;
                        }
                    }
                }

                if (episodeAction != null)
                {
                    DailyBedProcedure dailyBedProcedure = new DailyBedProcedure(ObjectContext);
                    dailyBedProcedure.ProcedureObject = ObjectContext.GetObject<ProcedureDefinition>(ProcedureDefinition.DailyBedProcedureObjectId);
                    dailyBedProcedure.Amount = 1;
                    dailyBedProcedure.CurrentStateDefID = DailyBedProcedure.States.Completed;

                    if (MedulaProvizyonTarihi.HasValue)
                        dailyBedProcedure.PricingDate = MedulaProvizyonTarihi.Value;
                    else if (CreationDate.HasValue)
                        dailyBedProcedure.PricingDate = CreationDate.Value;

                    episodeAction.SubactionProcedures.Add(dailyBedProcedure);
                    dailyBedProcedure.SubEpisode = SubEpisode;
                    dailyBedProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST, this);
                }
            }
        }

        public string DischargeCode() // TODO MDZ: Bu metodun düzenlenmesi lazım
        {
            string dischargeCode = "2"; // haliyle taburcu
            int processNo = 0;
            TreatmentDischarge tretDisc = null;
            try
            {
                if (DischargeType != null)
                {
                    dischargeCode = DischargeType.taburcuKodu;
                }
                else if (Episode.PatientStatus == PatientStatusEnum.Outpatient) // Ayaktan durumundaki vakalar için
                {
                    if (Episode.TreatmentDischarges.Count > 0) // Muayene tedavi sonuç işlemi yoksa 2 gönder
                    {
                        foreach (TreatmentDischarge treatmentDischarge in Episode.TreatmentDischarges)
                        {
                            if ((treatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.PreDischarge || treatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.Discharged) && Convert.ToInt32(treatmentDischarge.ID.ToString()) > processNo)
                            {
                                processNo = Convert.ToInt32(treatmentDischarge.ID.ToString());
                                tretDisc = treatmentDischarge;
                            }
                        }
                        if (tretDisc != null && tretDisc.DischargeType != null) // Tamamlandı(Onaylı/Onaysız) adımında MTS yoksa veya varsa ve Taburcu Kodu girilmemişse 2 gönder, varsa ve girilmişse Medula Taburcu tipinde eşleştirme ye bak
                        {
                            IBindingList dischargeTypes = ObjectContext.QueryObjects(typeof(MedulaDischargeTypeDefinition).Name, "XXXXXXDISCHARGETYPE = " + tretDisc.DischargeType.Name + "");
                            if (dischargeTypes.Count > 0)  // Medula Taburcu tipinde eşleştirme varsa ordaki medula taburcu kodunu gönder, yoksa 2 Haliyle taburcu gönder
                            {
                                if (((MedulaDischargeTypeDefinition)dischargeTypes[0]).MedulaDischargeCode != null)
                                    dischargeCode = ((MedulaDischargeTypeDefinition)dischargeTypes[0]).MedulaDischargeCode.taburcuKodu;
                                if (dischargeCode.Equals("5"))  // Ayaktan takipte Tedaviden Vazgeçme(3) taburcu kodu için fatura kaydı yapılamamaktadır. Bundan dolayı Haliyle Taburcu(2) gönderdik
                                    dischargeCode = "8";
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(dischargeCode))
                        dischargeCode = "2";
                }
                else // yatan veya taburcu durumundaki vakalar için
                {
                    if (!MedulaTedaviTuru.tedaviTuruKodu.Equals("Y")) // eğer takibin tedavi türü ayaktan ya da günübirlikse 2 gönder
                    {
                        dischargeCode = "2";
                    }
                    else // takibin tedavi turu yatansa
                    {   /*
                        if (this.InPatientTreatmentClinicApplication.Count > 0 && this.InPatientTreatmentClinicApplication[0].InPatientPhysicianApplication.Count > 0 && this.InPatientTreatmentClinicApplication[0].InPatientPhysicianApplication[0].TreatmentDischarges.Count > 0)
                        {
                            TreatmentDischarge tDischarge = null;
                            if (this.InPatientTreatmentClinicApplication[0].InPatientPhysicianApplication[0].TreatmentDischarge != null)
                                tDischarge = this.InPatientTreatmentClinicApplication[0].InPatientPhysicianApplication[0].TreatmentDischarge;
                            if ((tDischarge.CurrentStateDefID == TreatmentDischarge.States.OkWithApprove || tDischarge.CurrentStateDefID == TreatmentDischarge.States.OkWithoutApprove) && tDischarge.DischargeType != null) // Tamamlandı(Onaylı/Onaysız) adımında MTS yoksa veya varsa ve Taburcu Kodu girilmemişse 2 gönder, varsa ve girilmişse Medula Taburcu tipinde eşleştirme ye bak
                            {
                                IBindingList dischargeTypes = this.ObjectContext.QueryObjects(typeof(MedulaDischargeTypeDefinition).Name, "XXXXXXDISCHARGETYPE = " + Convert.ToInt16(tDischarge.DischargeType.Value) + "");
                                if (dischargeTypes.Count > 0)  // Medula Taburcu tipinde eşleştirme varsa ordaki medula taburcu kodunu gönder, yoksa 2 Haliyle taburcu gönder
                                {
                                    if (((MedulaDischargeTypeDefinition)dischargeTypes[0]).MedulaDischargeCode != null)
                                        dischargeCode = ((MedulaDischargeTypeDefinition)dischargeTypes[0]).MedulaDischargeCode.taburcuKodu;
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(dischargeCode))
                            dischargeCode = "2";
                        */
                    }
                }
                return dischargeCode;
            }
            catch (Exception e)
            {
                return "2"; // haliyle taburcu
            }
        }

        public InvoiceCollection GetMyInvoiceCollection(DateTime InvoiceDate, bool? getClosedTerm = null)
        {
            List<Guid> states = new List<Guid>();
            states.Add(InvoiceTerm.States.Open);

            if (getClosedTerm != null && getClosedTerm.HasValue && getClosedTerm.Value)
                states.Add(InvoiceTerm.States.Closed);

            BindingList<InvoiceTerm> termList = InvoiceTerm.GetInvoiceTermByDate(ObjectContext, InvoiceDate.Date, states);

            if (termList.Count > 1)
                throw new Exception(TTUtils.CultureService.GetText("M25658", "Faturalama için girilen tarih açılmış 2 dönemi kapsamaktadır. Bilgi işlem ile görüşünüz."));
            else if (termList.Count == 0)
                throw new Exception(TTUtils.CultureService.GetText("M25659", "Faturalama için girilen tarih açılmış hic bir dönemi kapsamamaktadır. Bilgi işlem ile görüşünüz."));
            else
            {
                BindingList<InvoiceCollection> ICList = InvoiceCollection.GetICbyTerm(ObjectContext, termList[0].ObjectID);


                string tempName = "";
                if (Payer.Type.PayerType == PayerTypeEnum.Paid)
                    tempName = TTUtils.CultureService.GetText("M27156", "Ücretli");
                else if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("T"))//Trafik Kazası
                    tempName = TTUtils.CultureService.GetText("M27117", "Trafik");
                else if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("V"))//Adli Vaka
                    tempName = TTUtils.CultureService.GetText("M25129", "Adli");
                else if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("I"))//iş Kazası
                    tempName = TTUtils.CultureService.GetText("M26168", "İş");
                else if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("M"))//Meslek Hastalığı
                    tempName = TTUtils.CultureService.GetText("M18929", "Meslek");
                else if (MedulaTedaviTipi.tedaviTipiKodu.Equals("4"))//Kemik İliği Nakli
                    tempName = TTUtils.CultureService.GetText("M26290", "Kemik");
                else if (MedulaTedaviTipi.tedaviTipiKodu.Equals("5"))//Kök Hücre Nakli
                    tempName = TTUtils.CultureService.GetText("M26340", "Kök");
                else if (MedulaTedaviTipi.tedaviTipiKodu.Equals("6"))//Ekstrakorporeal fotoferez tedavisi
                    tempName = TTUtils.CultureService.GetText("M25584", "Ekstrakorporeal");
                else if (MedulaTedaviTipi.tedaviTipiKodu.Equals("11") || MedulaTedaviTipi.tedaviTipiKodu.Equals("12"))//Tüp Bebek
                    tempName = TTUtils.CultureService.GetText("M27130", "Tüp");
                //else if (1 == 0 /*Burası bilinmiyor.*/)//Radyofarmasötik
                //    tempName = "Radyofarmasötik";
                else if (MedulaTedaviTipi.tedaviTipiKodu.Equals("7"))//Hiperbarik Oksijen Tedavisi
                    tempName = TTUtils.CultureService.GetText("M25938", "Hiperbarik");
                else if (MedulaTedaviTipi.tedaviTipiKodu.Equals("9"))//Ağız Protez tedavisi
                    tempName = TTUtils.CultureService.GetText("M25132", "Ağız");
                //else if (1 == 0 /*Allogreft malzemelerin ayrımına bakıp karar verilecek.*/)//Allogreft  
                //    tempName = "Allogreft";
                else if (MedulaTedaviTipi.tedaviTipiKodu.Equals("21"))//Alkol, Madde Bağımlılığı Tedavisi
                    tempName = TTUtils.CultureService.GetText("M10725", "Alkol");
                else if (MedulaDonorTCKimlikNo != null)//Donöre Yapılan Tetkikler  
                    tempName = TTUtils.CultureService.GetText("M25532", "Donör");
                else if (MedulaTedaviTipi.tedaviTipiKodu.Equals("15"))//Plazmaferez Tedavisi
                    tempName = TTUtils.CultureService.GetText("M26699", "Plazmaferez");
                else if (MedulaDevredilenKurum != null && MedulaDevredilenKurum.devredilenKurumKodu.Equals("99"))//Yurtdışı Sigortalılar
                    tempName = TTUtils.CultureService.GetText("M27264", "Yurtdışı");
                else if (MedulaDevredilenKurum != null && MedulaDevredilenKurum.devredilenKurumKodu.Equals("4"))//Yeşil Kart
                    tempName = TTUtils.CultureService.GetText("M27252", "Yeşilkart");
                else if (MedulaTedaviTuru.tedaviTuruKodu.Equals("G"))//Günübirlik
                    tempName = TTUtils.CultureService.GetText("M25759", "Günübirlik");
                else if (MedulaTedaviTuru.tedaviTuruKodu.Equals("Y"))//Yatan
                    tempName = TTUtils.CultureService.GetText("M24377", "Yatan");
                else if (MedulaTedaviTuru.tedaviTuruKodu.Equals("A"))//Ayaktan
                    tempName = TTUtils.CultureService.GetText("M11281", "Ayaktan");
                else
                    throw new Exception("Uygun icmali bulma işlemi sırasında SEP üzerinde eksik ya da hatalı bilgiler bulundu. Lütfen bilgi işlem ile iletişime geçiniz.1");

                InvoiceCollection lastIC = ICList.Where(x => x.IsAutoGenerated.Value &&
                                                            x.Name.Contains(tempName) &&
                                                            (x.Payer.Type.PayerType == PayerTypeEnum.SGK || x.Payer.Type.PayerType == PayerTypeEnum.Paid) &&
                                                            (x.CurrentStateDefID == InvoiceCollection.States.Open || (getClosedTerm != null && getClosedTerm.HasValue && getClosedTerm.Value && x.CurrentStateDefID != InvoiceCollection.States.Cancelled))).FirstOrDefault();

                if (lastIC == null)
                    throw new Exception("Uygun icmali bulma işlemi sırasında SEP üzerinde eksik ya da hatalı bilgiler bulundu. Lütfen bilgi işlem ile iletişime geçiniz.2");


                return lastIC;
            }
        }

        public void CreateInvoiceCollectionDetail(InvoiceCollection ic, Guid state, PayerInvoiceDocument pid = null)
        {
            if (InvoiceCollectionDetail != null)
                throw new Exception("İcmale eklenmeye çalışılan kayıtlarda daha önce icmalde olan bulundu. Lütfen kontrol ediniz.2");

            InvoiceCollectionDetail icd = new InvoiceCollectionDetail(ObjectContext);
            icd.InvoiceCollection = ic;
            icd.PayerInvoiceDocument = pid;
            icd.CreateDate = DateTime.Now;
            icd.CreateUser = Common.CurrentResource;
            icd.CurrentStateDefID = state;
            icd.Episode = Episode;
            InvoiceCollectionDetail = icd;
        }

        public void CheckSEPConsistency()
        {
            if (Payer != null && SEPMaster != null)
            {
                if (IsSGK)
                {
                    SubEpisodeProtocol sep = SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.Payer.Type.ObjectID != Payer.Type.ObjectID).FirstOrDefault();
                    if (sep != null)
                    {
                        throw new TTException("Başvurusu içerisindeki tüm aktif takiplerin kurum türü aynı olmalıdır.\n Eklenen Takibin Kurum Türü : " + Payer.Type.Name + "\n Mevcut Takibin Kurum Türü : " + sep.Payer.Type.Name);
                    }
                }
                else
                {
                    SubEpisodeProtocol sep = SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.Payer.ObjectID != Payer.ObjectID).FirstOrDefault();
                    if (sep != null)
                        throw new TTException("Başvurusu içerisindeki tüm aktif takiplerin kurumu aynı olmalıdır.\n Eklenen Takibin Kurumu : " + Payer.Name + "\n Mevcut Takibin Kurumu : " + sep.Payer.Name);
                }
            }

            if (ClonedFrom != null && !CloneType.HasValue)
                throw new TTException(TTUtils.CultureService.GetText("M26322", "Klonlanan takibin Klonlanma Tipi bilgisi dolu olmalıdır."));

            //if (MedulaTedaviTuru != null && MedulaTedaviTuru.tedaviTuruKodu.Equals("G") && !IsSGK)
            //    throw new TTException("Sadece SGK hastalarına tedavi türü Günübirlik olan takip oluşturulabilir.");
        }

        public void createNewTigObject()
        {
            TigEpisode tigEpisode = new TigEpisode(ObjectContext);
            tigEpisode.InpatientDate = CreationDate;
            tigEpisode.AppointmentStatus = true;
            tigEpisode.BranchGuid = Brans.ObjectID;
            tigEpisode.Cancelled = false;
            tigEpisode.CodingStatus = false;
            tigEpisode.DischargeDate = CreationDate;
            tigEpisode.DischargerDoctorGuid = SubEpisode.StarterEpisodeAction.ProcedureDoctor.ObjectID;
            tigEpisode.DoctorGuid = SubEpisode.StarterEpisodeAction.ProcedureDoctor.ObjectID;
            tigEpisode.EpicrisisStatus = false;
            tigEpisode.EpisodeGuid = Episode.ObjectID;
            tigEpisode.InPatientProtocolNo = SubEpisode.ProtocolNo;
            tigEpisode.InvoiceStatus = InvoiceCollectionDetail != null ? true : false;
            BindingList<Pathology.GetPathologyStatesForTIG_Class> tests = Pathology.GetPathologyStatesForTIG(Episode.ObjectID, null);
            if (tests.Count > 0)
            {
                tigEpisode.PathologyRequestStatus = true;
                tigEpisode.PathologyReportStatus = false;
                foreach (Pathology.GetPathologyStatesForTIG_Class pT in tests)
                {
                    if (pT.CurrentStateDefID == Pathology.States.Approvement || pT.CurrentStateDefID == Pathology.States.Report)
                    {
                        tigEpisode.PathologyReportStatus = true;
                        break;
                    }
                }
            }
            else
            {
                tigEpisode.PathologyRequestStatus = false;
                tigEpisode.PathologyReportStatus = false;
            }
            tigEpisode.PatientGuid = Episode.Patient.ObjectID;
            tigEpisode.PatientType = TIGPatientTypeEnum.Outpatient;

            var firstInPatientTreatmentClinicApplication = Episode.InPatientTreatmentClinicApplications.OrderBy(dr => dr.ClinicInpatientDate).FirstOrDefault(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled);
            if (firstInPatientTreatmentClinicApplication != null)
                tigEpisode.ResourceGuid = firstInPatientTreatmentClinicApplication.MasterResource.ObjectID;
            tigEpisode.SEPGuid = ObjectID;
            //tigEpisode.Surgeries
            tigEpisode.XMLStatus = false;
        }
        protected override void PreInsert()
        {
            CheckSEPConsistency();
            ArrangeDailyBedProcedure();

            // Sadece yeni altvaka ile oluşan sep
            if (SubEpisode != null && (CloneType == SEPCloneTypeEnum.NewSubEpisode || CloneType == SEPCloneTypeEnum.NewDailyProcedure))
            {
                IList<SEPDiagnosis> sepDiagnosisList = SEPDiagnoses.Select("").ToList();
                foreach (var diagnosisSubEpisode in SubEpisode.DiagnosisSubEpisodes)
                {
                    if (!sepDiagnosisList.Where(x => x.SubEpisodeProtocol.ObjectID == ObjectID).Any())
                    {
                        SEPDiagnosis sepDiagnosis = new SEPDiagnosis(ObjectContext);
                        sepDiagnosis.DiagnosisGrid = diagnosisSubEpisode.DiagnosisGrid;
                        sepDiagnosis.SubEpisodeProtocol = this;
                        sepDiagnosis.Diagnose = diagnosisSubEpisode.DiagnosisGrid.Diagnose;
                        sepDiagnosis.DiagnosisType = diagnosisSubEpisode.DiagnosisGrid.DiagnosisType;
                        sepDiagnosis.IsMainDiagnose = diagnosisSubEpisode.DiagnosisGrid.IsMainDiagnose;
                        sepDiagnosis.OzelDurum = diagnosisSubEpisode.DiagnosisGrid.OzelDurum;
                        sepDiagnosis.DiagnosisSubEpisode = diagnosisSubEpisode;
                    }
                }
            }

            if (MedulaTedaviTuru.tedaviTuruKodu == "G")
            {
                if (CloneType != SEPCloneTypeEnum.PatientInvoice && SubEpisode?.PatientAdmission?.IsOldAction != true)
                {
                    createNewTigObject();
                }
            }
        }

        protected override void PreUpdate()
        {
            CheckSEPConsistency();

            TTObjectContext objContext = new TTObjectContext(true);
            SubEpisodeProtocol originalSEP = objContext.GetObject(ObjectID, ObjectDef, false) as SubEpisodeProtocol;

            if (originalSEP != null && !originalSEP.MedulaTedaviTuru.ObjectID.Equals(MedulaTedaviTuru.ObjectID)) // Tedavi Türü değişmişse Gündüz Yatak Hizmeti oluşturulur veya iptal edilir
                ArrangeDailyBedProcedure();
        }

        protected override void PreDelete()
        {
            throw new TTException(TTUtils.CultureService.GetText("M26955", "SubEpisodeProtocol silmeyiniz, İptal durumuna alınız."));
        }

        protected override void PostUpdate()
        {
            if (IsSGK)
            {
                if (CurrentStateDefID == SubEpisodeProtocol.States.Open || CurrentStateDefID == SubEpisodeProtocol.States.Closed)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    SubEpisodeProtocol originalSEP = (SubEpisodeProtocol)objectContext.GetObject(ObjectID, TTObjectDefManager.Instance.ObjectDefs[typeof(SubEpisodeProtocol).Name], false);
                    if (originalSEP != null)
                    {
                        // Takip Faturalandı durumuna geçince Fatura Bilgisi Kayıt tipinde e-nabız objesi oluşturulur
                        if (IsInvoiced && !originalSEP.IsInvoiced)
                            new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "104", Common.RecTime());
                        else if (!IsInvoiced && originalSEP.IsInvoiced)
                        {
                            BindingList<SendToENabiz> stenList = SendToENabiz.GetByObjectID(objectContext, ObjectID, "104");
                            foreach (SendToENabiz item in stenList)
                            {
                                if (item.Status == SendToENabizEnum.ToBeSent)
                                    item.Status = SendToENabizEnum.NotToBeSent;
                            }
                        }

                        // Takip numarası değişmişse 101 paketi tekrar gönderilir
                        if (!string.IsNullOrWhiteSpace(MedulaTakipNo) && MedulaTakipNo != originalSEP.MedulaTakipNo)
                        {
                            if (SubEpisode.Sent101Package == true && SubEpisode.PatientAdmission.IsOldAction != true)
                                new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "101", Common.RecTime());
                        }
                    }
                    //ControlDailyBedProcedure();
                }
            }
        }

        public MedulaResult DeleteProvisionFromMedula()
        {
            MedulaResult result = new MedulaResult();

            //if (!this.IsSGK)
            //    throw new TTException("SGK olmayan kurumlarda takip silme işlemi gerçekleştirilemez.");

            if (InvoiceStatus == MedulaSubEpisodeStatusEnum.ProvisionNoNotExists ||
                IsInvoiced)
                throw new TTException(TTUtils.CultureService.GetText("M26996", "Takibi silinmeye çalışılan protokolün durumu takip silmeye uygun değildir. Lütfen kontrol ediniz."));


            HastaKabulIslemleri.takipSilGirisDVO takipSilGirisDVO = new HastaKabulIslemleri.takipSilGirisDVO();
            takipSilGirisDVO.takipNo = MedulaTakipNo;
            takipSilGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            takipSilGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();

            TTObjectClasses.XXXXXXMedulaServices.HastaKabulIptalParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HastaKabulIptalParam(takipSilGirisDVO, ObjectID.ToString());
            HastaKabulIslemleri.takipSilCevapDVO takipSilCevapDVO = HastaKabulIslemleri.WebMethods.hastaKabulIptalSync(TTObjectClasses.Sites.SiteLocalHost, takipSilGirisDVO);
            inputParam.HastaKabulIptalCompletedInternal(takipSilCevapDVO, takipSilGirisDVO, ObjectID.ToString(), ObjectContext);

            if (takipSilCevapDVO.sonucKodu.Equals("0000") || takipSilCevapDVO.sonucKodu.Equals("0535"))
            {
                result.Succes = true;
                InvoiceLog.AddInfo(string.Format("Meduladan başarı ile takip silindi. Takip No: {0} ", takipSilGirisDVO.takipNo), ObjectID, InvoiceOperationTypeEnum.TakipSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
            }
            else
            {
                result.Succes = false;
                InvoiceLog.AddErr(string.Format("Meduladan takip silme işlemi başarısız. Takip No: {0} Sonuc Kodu: {1} , Sonuc Aciklama: {2}", takipSilGirisDVO.takipNo, takipSilCevapDVO.sonucKodu, takipSilCevapDVO.sonucMesaji), ObjectID, InvoiceOperationTypeEnum.TakipSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
            }

            result.SonucKodu = takipSilCevapDVO.sonucKodu;
            result.SonucMesaji = takipSilCevapDVO.sonucMesaji;
            result.ProtocolNo = this.SubEpisode?.ProtocolNo;
            return result;
        }

        public MedulaResult DeleteProvisionFromMedulaRecursive(int i)
        {
            MedulaResult mr = new MedulaResult();

            do
            {
                i++;
                if (i > 10)//Sigorta 
                    break;
                mr = DeleteProvisionFromMedula();

                if (!mr.Succes)
                {
                    if (mr.SonucKodu.Equals("1128"))
                    {
                        string[] splittedMessage = mr.SonucMesaji.Split(' ');
                        SubEpisodeProtocol tempSep = SubEpisodeProtocol.GetSEPByProvisionNo(splittedMessage[3]);
                        if (tempSep != null)
                        {
                            tempSep.DeleteProvisionFromMedulaRecursive(i);
                            Thread.Sleep(2000);
                        }
                    }
                    else
                        break;
                }
                else if (mr.Succes)
                    ObjectContext.Save();



            }
            while (!mr.Succes);

            return mr;
        }

        // SEP için kuruma göre uygun anlaşmayı set eder
        public void SetProtocol()
        {
            if (Payer == null)
                throw new TTException(TTUtils.CultureService.GetText("M26357", "Kurum belli olmadığı için Alt Vaka anlaşması belirlenemiyor."));

            Protocol = Payer.GetProtocol(this?.SubEpisode?.Episode?.Patient, MedulaSigortaliTuru);
        }

        public void SetSEPMaster()
        {
            if (SEPMaster != null)
                return;

            #region Aynı SubEpisode altında  SEPMaster aynı olur
            foreach (SubEpisodeProtocol sep in SubEpisode.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled))
            {
                if (this != sep && sep.SEPMaster != null && (Payer.ObjectID == sep.Payer.ObjectID || (IsSGK && sep.IsSGK)))
                {
                    SEPMaster = sep.SEPMaster;
                    if (ParentSEP == null)
                        ParentSEP = sep;
                    return;
                }
            }
            #endregion

            // Hasta Kabul ilk açıldığında Episode henüz set edilmemiş olduğu için return edilir, hasta kabul tamamlanırken set edilir SEPMaster
            if (Episode == null)
                return;

            #region  Aynı Episode altında SEPMaster aynı olur
            foreach (SubEpisode se in Episode.SubEpisodes)
            {
                if (SubEpisode != se)
                {
                    foreach (SubEpisodeProtocol sep in se.SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled))
                    {
                        if (sep.SEPMaster != null && (Payer.ObjectID == sep.Payer.ObjectID || (IsSGK && sep.IsSGK)))
                        {
                            SEPMaster = sep.SEPMaster;
                            if (ParentSEP == null)
                                ParentSEP = sep;
                            return;
                        }
                    }
                }
            }
            #endregion

            // SGK hastaları için aşağıdaki kontroller yapılacak. Diğer kurumlar için farklı Episode da ise yeni SEPMaster oluşturulmalı.
            if (IsSGK)
            {
                #region Aynı gün farklı bir branşa gelmiş ise SEPMaster aynı olur.
                if (MedulaTedaviTuru != null && MedulaTedaviTuru.tedaviTuruKodu == "A" && Brans != null && Brans.Code != "4400") // "Ayaktan" ve "Acil" branşı değilse
                {   // Hastanın SGK kurumundan, Ayaktan, SepMaster ı dolu, İptal olmayan, Acil branşı olmayan, bu SEP ten farklı branşta takipleri bulunur
                    BindingList<SubEpisodeProtocol> sepList = SubEpisodeProtocol.GetSEPByPatient(ObjectContext, (DateTime)MedulaProvizyonTarihi.Value.Date, (DateTime)MedulaProvizyonTarihi.Value.Date.AddDays(1), Episode.Patient.ObjectID, " AND OBJECTID <> '" + ObjectID + "' AND CURRENTSTATE <> STATES.CANCELLED AND SEPMASTER IS NOT NULL AND PAYER.TYPE.PAYERTYPE = 0 AND MEDULATEDAVITURU.TEDAVITURUKODU = 'A' AND SUBEPISODE.PATIENTADMISSION.ADMISSIONSTATUS <> 3  AND BRANS.CODE <> '4400' AND BRANS <> '" + Brans.ObjectID + "'");
                    foreach (SubEpisodeProtocol sep in sepList)
                    {
                        SEPMaster = sep.SEPMaster;
                        if (ParentSEP == null)
                            ParentSEP = sep;
                        return;
                    }
                }
                #endregion
                #region 10 gün içinde aynı branşa gelmiş ise SEPMaster aynı olur.
                //if (Payer != null && Brans != null)
                //{
                //    BindingList<SubEpisodeProtocol> sepList = SubEpisodeProtocol.GetSEPByPatient(ObjectContext, (DateTime)MedulaProvizyonTarihi.Value.Date.AddDays(-9), (DateTime)MedulaProvizyonTarihi.Value.Date, Episode.Patient.ObjectID, " AND OBJECTID <> '" + ObjectID + "' AND CURRENTSTATE <> STATES.CANCELLED AND SEPMASTER IS NOT NULL AND PAYER.TYPE.PAYERTYPE = 0 AND BRANS = '" + Brans.ObjectID + "'");
                //    foreach (SubEpisodeProtocol sep in sepList)
                //    {
                //        //if(sep.PatientAdmission != null)
                //        SEPMaster = sep.SEPMaster;
                //        if (ParentSEP == null)
                //            ParentSEP = sep;
                //        return;
                //    }
                //}
                #endregion
            }

            //TODO: AAE Yatışın içinde ameliyat var mı kontrolü yapılmalı ve ona göre de bağlamaya yapılabilir?
            #region Yukarıdaki hiç bir case de bir sonuç bulamaz ise yeni bir tane yaratıp dönmeli.
            SEPMaster = new SEPMaster(ObjectContext);
            #endregion
        }

        public class SEPProperty
        {
            public PayerDefinition payer;
            public ProtocolDefinition protocol;
            public SubEpisode subEpisode;
            public SpecialityDefinition brans;
            public TedaviTuru tedaviTuru;
            public TedaviTipi tedaviTipi;
            public ProvizyonTipi provizyonTipi;
            public TakipTipi takipTipi;
            public SigortaliTuru sigortaliTuru;
            public SubEpisodeProtocol parentSEP;
            public bool checkPaid;
            public bool cancelOldSEP;
            public DateTime creationDate;
            //AKTARIM YAPILABILMESI ICIN EKLENENLER
            public string medulaTakipNo;
            public string medulaBasvuruNo;
            public DateTime? takipTarihi;
            public DevredilenKurum devredilenKurum;

            public SEPProperty()
            {
                checkPaid = true;
                cancelOldSEP = false;
                creationDate = Common.RecTime();
            }
        }

        // SEP i klonlayan metod
        public SubEpisodeProtocol CloneMe(SEPCloneTypeEnum cloneType)
        {
            SubEpisodeProtocol newSEP = Clone() as SubEpisodeProtocol;
            newSEP.ClonedFrom = this;
            newSEP.CloneType = cloneType;
            newSEP.CurrentStateDefID = SubEpisodeProtocol.States.Open;
            TTSequence.allowSetSequenceValue = true;
            newSEP.Id.SetSequenceValue(0);
            newSEP.Id.GetNextValue();
            newSEP.LastIIM = null;
            newSEP.SubEpisode = null;        // Clone lanan newSEP, SubEpisode un SubEpisodeProtocols collection ına girmiyor, girmesi için yapıldı.   
            newSEP.SubEpisode = SubEpisode;  // Clone daki bu sorun düzeltilirse bu iki satır silinebilir.

            if (cloneType == SEPCloneTypeEnum.InvoiceScreenChangePayer)
            {
                if (newSEP.InvoiceCollectionDetail != null)
                    throw new TTException(TTUtils.CultureService.GetText("M26002", "İcmal içerisinde veya faturalanmış bir takibin kurumu değiştirilemez."));

                MedulaBasvuruNo = string.Empty;
                MedulaTakipNo = string.Empty;
                InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                newSEP.SEPMaster = null; // Önemli kaldırmayın çarşı karışır.
                if (string.IsNullOrEmpty(newSEP.MedulaTakipNo))
                {
                    newSEP.MedulaBasvuruNo = string.Empty;
                    newSEP.MedulaSonucKodu = string.Empty;
                    newSEP.MedulaSonucMesaji = string.Empty;
                    newSEP.MedulaYupassNo = null;
                    newSEP.MedulaFaturaTutari = null;
                    newSEP.InvoiceCancelCount = null;
                }
            }
            else
            {
                if (cloneType == SEPCloneTypeEnum.InvoiceScreenAddPayer)
                {
                    newSEP.SEPMaster = null; // Önemli kaldırmayın çarşı karışır.
                }

                newSEP.CreationDate = Common.RecTime();
                newSEP.MedulaProvizyonTarihi = Common.RecTime();
                newSEP.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                newSEP.PatientAdmission = null; // Hasta kabul den klonlanan SEP lerin PatientAdmission ı klonlandıktan sonra set edilir. Burada null landı bu yüzden.
                newSEP.ParentSEP = null;
                newSEP.InvoiceCollectionDetail = null;
                newSEP.MedulaBasvuruNo = string.Empty;
                newSEP.MedulaTakipNo = string.Empty;
                newSEP.MedulaSonucKodu = string.Empty;
                newSEP.MedulaSonucMesaji = string.Empty;
                newSEP.MedulaYupassNo = null;
                newSEP.MedulaFaturaTutari = null;
                newSEP.InvoiceCancelCount = null;

                //if (cloneType == SEPCloneTypeEnum.OrthesisProsthesisMaterial) // Burası kapatıldı çünkü artık Ortez-Protez işlemi için ayrı SubEpisode ve SEP oluşturuluyor (Önceden sadece SEP klonlanıyordu) 
                //    newSEP.SEPMaster = null; // Ortez Protez malzemesi girilebilmesi için oluşturulan SEP yeni bir kurumdan olacağı için yeni SEPMaster oluşması gerekiyor bu yüzden null lanır
            }
            return newSEP;
        }



        // Yeni SEP'in mevcut bir SEP ten klonlanması gereken durumlarda kullanılan metod
        public SubEpisodeProtocol CloneForNewSEP(SEPCloneTypeEnum cloneType, SEPProperty SEPProperty = null)
        {
            SubEpisodeProtocol newSEP = CloneMe(cloneType);

            if (SEPProperty != null)
            {
                if (SEPProperty.payer != null)
                    newSEP.Payer = SEPProperty.payer;

                if (SEPProperty.protocol != null)
                    newSEP.Protocol = SEPProperty.protocol;

                if (SEPProperty.subEpisode != null)
                    newSEP.SubEpisode = SEPProperty.subEpisode;

                if (SEPProperty.brans != null)
                    newSEP.Brans = SEPProperty.brans;

                if (SEPProperty.tedaviTuru != null)
                    newSEP.MedulaTedaviTuru = SEPProperty.tedaviTuru;

                if (SEPProperty.tedaviTipi != null)
                    newSEP.MedulaTedaviTipi = SEPProperty.tedaviTipi;

                if (SEPProperty.provizyonTipi != null)
                    newSEP.MedulaProvizyonTipi = SEPProperty.provizyonTipi;

                if (SEPProperty.takipTipi != null)
                    newSEP.MedulaTakipTipi = SEPProperty.takipTipi;

                if (SEPProperty.parentSEP != null)
                    newSEP.ParentSEP = SEPProperty.parentSEP;

                if (newSEP.SEPMaster == null)
                    newSEP.SetSEPMaster();

                if (SEPProperty.creationDate != null)
                    newSEP.CreationDate = SEPProperty.creationDate;

                if (SEPProperty.cancelOldSEP == true)
                {
                    if (cloneType == SEPCloneTypeEnum.InvoiceScreenChangePayer)
                        CancelForPayerOperation(newSEP);
                    else
                        Cancel(newSEP);
                }
            }

            return newSEP;
        }

        public void TransferAccTrxToNewSEP(SubEpisodeProtocol newSEP)
        {
            //this.Episode.AdjustAccountTransactionsState(); // charge lar için gerekli state düzenlemelerini yapar, ileride kaldırılabilir gereksizse

            if (this == newSEP)
                return;

            if (AccountTransactions.Select("").Where(x => x.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful).Count() > 0)
                throw new TTUtils.TTException("Hizmet kaydı başarılı olan Hizmet/Malzeme bulundu işlem yapılamaz.");
            else if (AccountTransactions.Select("").Where(x => x.CurrentStateDefID == AccountTransaction.States.Invoiced).Count() > 0)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25670", "Faturalanmış Hizmet/Malzeme bulundu işlem yapılamaz."));
            else if (AccountTransactions.Select("").Where(x => x.AccountPayableReceivable.Type == APRTypeEnum.PATIENT && x.IsPaidPatientShare()).Count() > 0)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26654", "Ödenmiş durumda Hizmet/Malzeme bulundu işlem yapılamaz."));

            SubActionProcedure tempSubActP = null;
            SubActionMaterial tempSubActM = null;

            if (CurrentStateDefID == SubEpisodeProtocol.States.Open)
            {
                //List<AccountTransaction> myPAccountTransactions = this.GetSubActionProcedureTrxsToChangeSEP();
                List<SubActionProcedure> spList = GetSubActionProcedureTrxsToChangeSEP();
                foreach (SubActionProcedure sp in spList)
                {
                    //if (tempSubActP != at.SubActionProcedure)
                    //    at.SubActionProcedure.ChangeMyProtocol(newSEP);

                    //tempSubActP = at.SubActionProcedure;
                    sp.ChangeMyProtocol(newSEP);
                }

                List<SubActionMaterial> smList = GetSubActionMaterialTrxsToChangeSEP();
                foreach (SubActionMaterial sm in smList)
                {
                    //if (tempSubActM != at.SubActionMaterial)
                    //    at.SubActionMaterial.ChangeMyProtocol(newSEP);

                    //tempSubActM = at.SubActionMaterial;
                    sm.ChangeMyProtocol(newSEP);
                }
            }
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubEpisodeProtocol).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if ((fromState == States.Open || fromState == States.Closed) && toState == States.Cancelled)
            //    PreTransition_2Cancelled();
        }

        //protected void PreTransition_2Cancelled()
        //{
        //    //this.ControlCancel();
        //}

        //public void ControlCancel()
        //{
        //    //ControlBeforeCancel();
        //    //ControlAfterCancel();
        //}

        public void ControlAfterCancel()
        {
            if (!string.IsNullOrEmpty(MedulaTakipNo))
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26995", "Takibi iptal edebilmek için 'Takip No' boş olmalıdır!"));

            if (InvoiceStatus != MedulaSubEpisodeStatusEnum.ProvisionNoNotExists)
                throw new TTException(TTUtils.CultureService.GetText("M26993", "Takibi iptal edebilmek için durumu 'Takip No Alınmamış' olmalıdır!"));

            if (AccountTransactions.Select("").Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled).Count() > 0)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26994", "Takibi iptal edebilmek için içerisinde hizmet/malzeme olmamalıdır!"));
        }

        public void ControlBeforeCancel(SubEpisodeProtocol newSEP = null)
        {
            if (IsInvoiced)
                throw new TTException(TTUtils.CultureService.GetText("M25671", "Faturalanmış takip iptal edilemez!"));

            if (InvoiceStatus == MedulaSubEpisodeStatusEnum.InsideInvoiceCollection || InvoiceCollectionDetail != null)
                throw new TTException("İcmale eklenmiş takip iptal edilemez.");

            if (newSEP == null)
            {
                if (AccountTransactions.Select("").Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled).Count() > 0)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26994", "Takibi iptal edebilmek için içerisinde hizmet/malzeme olmamalıdır!"));
            }
        }

        public void CancelForPayerOperation(SubEpisodeProtocol newSEP)
        {
            ControlBeforeCancel(newSEP);

            TransferAccTrxToNewSEP(newSEP);

            TransferLog(newSEP);

            TransferSEPDiagnosis(newSEP);

            TransferClosedBond(newSEP);

            CurrentStateDefID = SubEpisodeProtocol.States.Cancelled;

            ControlAfterCancel();
        }

        public void TransferLog(SubEpisodeProtocol newSEP)
        {
            BindingList<InvoiceLog> items = InvoiceLog.GetInvoiceLogObject(ObjectContext, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectID);
            foreach (InvoiceLog item in items)
            {
                InvoiceLog.CopyLog(item, newSEP.ObjectID, ObjectContext);
            }
        }

        public void TransferSEPDiagnosis(SubEpisodeProtocol newSEP)
        {

            if (SEPDiagnoses.Select("").Where(x => x.CurrentStateDefID == SEPDiagnosis.States.MedulaEntrySuccessful).Count() > 0)
                throw new TTUtils.TTException("Hizmet kaydı başarılı olan Tanı bulundu işlem yapılamaz.");

            BindingList<SEPDiagnosis> items = SEPDiagnosis.GetBySEP(ObjectContext, ObjectID);
            foreach (SEPDiagnosis item in items)
            {
                //if(item.DiagnosisGrid != null)
                item.CopySEPDiagnosis(newSEP);
            }
        }

        public void TransferClosedBond(SubEpisodeProtocol newSEP)
        {
            BindingList<BondClosedSeps> items = BondClosedSeps.GetBySEP(ObjectContext, ObjectID);
            foreach (BondClosedSeps item in items)
            {
                item.CopyBondClosedSeps(newSEP);
            }
        }

        public void Cancel(SubEpisodeProtocol newSEP = null, bool userInteraction = false)
        {
            if (CurrentStateDefID == SubEpisodeProtocol.States.Cancelled)
                return;

            ControlBeforeCancel(newSEP);

            if (IsSGKAndActiveWithMedulaTakipNo)
            {
                if (SubEpisodeProtocol.GetChildSEP(this) != null)
                    throw new TTUtils.TTException("Bu takibe bağlı başka takipler alınmıştır. Öncelikle onları silmelisiniz.");

                MedulaResult result = DeleteProvisionFromMedula();
                if (!result.Succes)
                    throw new TTException("Takip silinemedi. " + result.SonucKodu + " " + result.SonucMesaji);

                if (userInteraction)
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M27001", "Takip başarılı bir şekilde iptal edilmiştir."));
            }

            if (newSEP != null)
                TransferAccTrxToNewSEP(newSEP);

            CurrentStateDefID = SubEpisodeProtocol.States.Cancelled;

            ControlAfterCancel();
        }

        public HastaKabulIslemleri.provizyonDegistirCevapDVO UpdateProvizyonTipiFromMedula(string newProvizyontipi)
        {
            HastaKabulIslemleri.provizyonDegistirCevapDVO result = new HastaKabulIslemleri.provizyonDegistirCevapDVO();
            try
            {
                HastaKabulIslemleri.provizyonDegistirGirisDVO provizyonDegistirGirisDVO = new HastaKabulIslemleri.provizyonDegistirGirisDVO();
                provizyonDegistirGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                provizyonDegistirGirisDVO.takipNo = MedulaTakipNo;
                provizyonDegistirGirisDVO.yeniProvizyonTipi = newProvizyontipi;

                XXXXXXMedulaServices.UpdateProvizyonTipiParam inputParam = new XXXXXXMedulaServices.UpdateProvizyonTipiParam(provizyonDegistirGirisDVO, ObjectID.ToString());
                result = HastaKabulIslemleri.WebMethods.updateProvizyonTipiSync(Sites.SiteLocalHost, provizyonDegistirGirisDVO);

                inputParam.UpdateProvizyonTipiCompletedInternal(result, provizyonDegistirGirisDVO, ObjectID.ToString(), ObjectContext);
            }
            catch (Exception ex)
            {
                throw new TTException(ex.Message);
            }


            return result;
        }

        public HastaKabulIslemleri.takipDVO UpdateTedaviTipiFromMedula(int? newTedaviTipi)
        {
            HastaKabulIslemleri.takipDVO result = new HastaKabulIslemleri.takipDVO();
            try
            {
                HastaKabulIslemleri.takipOkuGirisDVO takipOkuGirisDVO = new HastaKabulIslemleri.takipOkuGirisDVO();
                takipOkuGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                takipOkuGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
                takipOkuGirisDVO.takipNo = MedulaTakipNo;
                takipOkuGirisDVO.yeniTedaviTipi = newTedaviTipi;

                TTObjectClasses.XXXXXXMedulaServices.HastaKabulOkuParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HastaKabulOkuParam(takipOkuGirisDVO, ObjectID.ToString(), "UpdateTedaviTipi", this);
                result = HastaKabulIslemleri.WebMethods.updateTedaviTipiSync(TTObjectClasses.Sites.SiteLocalHost, takipOkuGirisDVO);

                inputParam.UpdateTedaviTipiCompletedInternal(result, ObjectID.ToString(), takipOkuGirisDVO, ObjectContext);

            }
            catch (Exception ex)
            {
                throw new TTException(ex.Message);
            }

            return result;
        }


        public HastaKabulIslemleri.takipDVO ReadProvisionFromMedula(string externalTakipNo = null)
        {
            HastaKabulIslemleri.takipOkuGirisDVO takipOkuGirisDVO = new HastaKabulIslemleri.takipOkuGirisDVO();
            takipOkuGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            takipOkuGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();

            if (externalTakipNo == null)
                takipOkuGirisDVO.takipNo = MedulaTakipNo;
            else
                takipOkuGirisDVO.takipNo = externalTakipNo;

            TTObjectClasses.XXXXXXMedulaServices.HastaKabulOkuParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HastaKabulOkuParam(takipOkuGirisDVO, ObjectID.ToString(), "HastaKabulOku", this);
            HastaKabulIslemleri.takipDVO result = HastaKabulIslemleri.WebMethods.hastaKabulOkuSync(TTObjectClasses.Sites.SiteLocalHost, takipOkuGirisDVO);
            inputParam.HastaKabulOkuCompletedInternal(result, takipOkuGirisDVO);
            return result;

        }

        public bool IsSGKAndActiveWithMedulaTakipNo
        {
            get
            {
                if (IsSGK && CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && !string.IsNullOrEmpty(MedulaTakipNo))
                    return true;

                return false;
            }
        }

        public Dictionary<string, string> GetSEPEpicrisisInfo()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            int i = 0;
            foreach (var item in SubEpisode.InPatientPhysicianProgresses.OrderBy(x => x.ProgressDate))
            {
                if (item.Description != null && !string.IsNullOrWhiteSpace(item.Description.ToString()))
                {
                    result.Add(i.ToString() + ". ", (item.ProgressDate.HasValue ? item.ProgressDate.Value.ToString("dd.MM.yyyy") + ": " : string.Empty) + Common.HTMLToText(item.Description.ToString()));
                    i++;
                }
            }

            foreach (var inPatientTreatmentClinicApplication in SubEpisode.InPatientTreatmentClinicApplications)
            {
                if (inPatientTreatmentClinicApplication.InPatientPhysicianApplication.Count() > 0)
                {
                    var inPatientPhysicianApplication = inPatientTreatmentClinicApplication.InPatientPhysicianApplication[0];

                    if (inPatientPhysicianApplication.Complaint != null && !String.IsNullOrWhiteSpace(inPatientPhysicianApplication.Complaint.ToString()))
                        result.Add(i.ToString() + ". ŞİKAYETİ: ", Common.HTMLToText(inPatientPhysicianApplication.Complaint.ToString()));
                    else if (inPatientPhysicianApplication.PhysicalExamination != null && !String.IsNullOrWhiteSpace(inPatientPhysicianApplication.PhysicalExamination.ToString()))
                        result.Add(i.ToString() + ". FİZİKİ MUAYENE: ", Common.HTMLToText(inPatientPhysicianApplication.PhysicalExamination.ToString()));
                    else if (inPatientPhysicianApplication.PatientStory != null && !String.IsNullOrWhiteSpace(inPatientPhysicianApplication.PatientStory.ToString()))
                        result.Add(i.ToString() + ". HİKAYESİ: ", Common.HTMLToText(inPatientPhysicianApplication.PatientStory.ToString()));

                    i++;
                }
            }

            foreach (var InPatientRtfBySpeciality in SubEpisode.InPatientRtfBySpecialities)
            {
                if (InPatientRtfBySpeciality.RTFDefinitionsBySpeciality.IsNeedForEpicrisis == true)
                {
                    if (InPatientRtfBySpeciality.Rtf != null && !String.IsNullOrWhiteSpace(InPatientRtfBySpeciality.Rtf.ToString()))
                    {
                        result.Add(i.ToString() + ". " + InPatientRtfBySpeciality.Title, Common.HTMLToText(InPatientRtfBySpeciality.Rtf.ToString()));
                        i++;
                    }
                }
            }

            return result;
        }

        public string GetSEPEpicrisisDescription(Dictionary<string, string> param)
        {
            string result = "";

            foreach (var item in param)
            {
                result += Common.GetTextOfRTFString(item.Key + " " + item.Value + "<br>");
            }

            return result;
        }

        public ResUser getDoctor()
        {
            if (SubEpisode.InPatientTreatmentClinicApplications != null && SubEpisode.InPatientTreatmentClinicApplications.Count > 0)
            {
                foreach (InPatientTreatmentClinicApplication treatClinicApp in SubEpisode.InPatientTreatmentClinicApplications)
                {
                    if (treatClinicApp.ProcedureDoctor != null && !string.IsNullOrEmpty(treatClinicApp.ProcedureDoctor.DiplomaRegisterNo))
                        return treatClinicApp.ProcedureDoctor;
                }
            }

            foreach (EpisodeAction episodeAction in SubEpisode.PatientAdmission.FiredEpisodeActions)
            {
                if (episodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(episodeAction.ProcedureDoctor.DiplomaRegisterNo))
                    return episodeAction.ProcedureDoctor;

                if (episodeAction is Manipulation)
                {
                    Manipulation manipulation = episodeAction as Manipulation;
                    if (manipulation.SorumluDoktor != null && !string.IsNullOrEmpty(manipulation.SorumluDoktor.DiplomaRegisterNo))
                        return manipulation.SorumluDoktor;
                }
            }

            ResUser examinationDoctor = Episode.GetPatientExaminationDoctor();
            if (examinationDoctor != null && !string.IsNullOrEmpty(examinationDoctor.DiplomaRegisterNo))
                return examinationDoctor;

            return null;
        }

        public ProcedureMaterialAdding AddNewProcedure(decimal amount, Guid procedureObjectID, Guid doctor, DateTime? transactionDate, ProcedureMaterialAdding pmaOut = null)
        {
            ProcedureMaterialAdding pma = null;
            if (pmaOut == null)
            {
                bool foundPMA = false;
                foreach (EpisodeAction ea in Episode.EpisodeActions)
                {
                    if (ea is ProcedureMaterialAdding)
                    {
                        foundPMA = true;
                        pma = (ProcedureMaterialAdding)ea;
                    }
                }
                if (!foundPMA)
                {
                    pma = new ProcedureMaterialAdding(ObjectContext);
                    pma.Episode = Episode;
                    pma.SubEpisode = SubEpisode;
                    pma.ActionDate = DateTime.Now;
                    pma.CurrentStateDefID = ProcedureMaterialAdding.States.New;
                }
            }
            else
                pma = pmaOut;

            ProcedureDefinition proDef = (ProcedureDefinition)ObjectContext.GetObject(procedureObjectID, typeof(ProcedureDefinition));
            PMAddingProcedure PMAddingProc = new PMAddingProcedure(ObjectContext);
            PMAddingProc.ActionDate = Common.RecTime();
            PMAddingProc.PricingDate = transactionDate;
            PMAddingProc.Amount = (long)amount;
            PMAddingProc.ProcedureDoctor = (ResUser)ObjectContext.GetObject(doctor, typeof(ResUser));
            PMAddingProc.RequestedByUser = Common.CurrentResource;
            PMAddingProc.CurrentStateDefID = PMAddingProcedure.States.Completed;
            PMAddingProc.ProcedureObject = proDef;
            PMAddingProc.EpisodeAction = pma;
            PMAddingProc.SubEpisode = SubEpisode; // Hizmetin SubEpisode unun SEP in SubEpisode olarak set edilmesi lazım, yoksa pma nın subepisode u set ediliyor bu da farklı SEP lere hizmet eklenince sorun oluyor.
            PMAddingProc.SetPerformedDate();

            InvoiceLog.AddInfo("Yeni hizmet eklendi. Kodu: " + proDef.Code + TTUtils.CultureService.GetText("M22843", "Tarih:") + transactionDate.Value.ToString("dd/MM/yyyy") + " Adı:" + proDef.Name, ObjectID, InvoiceOperationTypeEnum.AddNewProcedure, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
            return pma;
        }

        public void ControlInvoiceBlocking()
        {
            int coun = Episode.InvoiceBlockings.Where(x => x.Active == true).Count();
            if (coun > 0)
            {
                InvoiceBlocking ib = Episode.InvoiceBlockings.Where(x => x.Active == true).FirstOrDefault();
                throw new TTException(Id + "Id'li alt vakada engel bulundu. Fatura kesilemez. Engeli koyan kullanıcı: " + ib.BlockUser.Name + " Engel açıklaması:" + ib.BlockDescription);
            }

        }

        public void DoUTSUsageCommitmentCancel(List<Guid> accTrxIDs)
        {
            List<MedulaResult> resultList;

            if (accTrxIDs != null)
            {
                List<AccountTransaction> UTSAccTrxList = new List<AccountTransaction>();

                foreach (Guid accTrxID in accTrxIDs)
                {
                    AccountTransaction accTrx = ObjectContext.GetObject<AccountTransaction>(accTrxID, false);

                    if (accTrx != null && accTrx.SubActionMaterial != null && accTrx.UTSNotificationDetail != null &&
                        accTrx.UTSUsageCommitment == true && accTrx.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful)
                    {
                        UTSAccTrxList.Add(accTrx);
                    }
                }

                resultList = UTSUsageCommitmentCancel(UTSAccTrxList);
            }
            else
                resultList = UTSUsageCommitmentCancel();

            if (resultList.Any(x => x.Succes == false))
                throw new TTException("Malzemenin ÜTS Kullanım Kesinleştirmesi iptal edilemediği için hizmet kayıt iptal işlemi yapılmadı. Lütfen kontrol ediniz.");
        }

        // ÜTS Kullanım Kesinleştirme İptal Metodu
        public List<MedulaResult> UTSUsageCommitmentCancel(List<AccountTransaction> accTrxList = null)
        {
            List<MedulaResult> medulaResultList = new List<MedulaResult>();

            if (accTrxList == null) // AccTrx listesi verilmemişse, tüm kesinleştirme yapılmış ÜTS malzemeleri iptal edilir
            {
                List<Guid> sepList = new List<Guid>() { ObjectID };
                accTrxList = AccountTransaction.GetTrxsForUTSUsageCommitment(ObjectContext, sepList, 1).ToList<AccountTransaction>();
            }

            if (accTrxList.Count > 0)
            {
                foreach (AccountTransaction accTrx in accTrxList)
                {
                    FaturaKayitIslemleri.utsKesinlestirmeIptalGirisDVO utsKesinlestirmeIptalGirisDVO = new FaturaKayitIslemleri.utsKesinlestirmeIptalGirisDVO();
                    utsKesinlestirmeIptalGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                    utsKesinlestirmeIptalGirisDVO.kullanimBildirimID = accTrx.UTSNotificationDetail.NotificationID;

                    FaturaKayitIslemleri.utsKesinlestirmeIptalCevapDVO result = FaturaKayitIslemleri.WebMethods.utsKullanimKesinlestirmeIptalSync(Sites.SiteLocalHost, utsKesinlestirmeIptalGirisDVO);

                    if (result != null && !string.IsNullOrEmpty(result.sonucKodu))
                    {
                        MedulaResult medulaResult = new MedulaResult();

                        if (result.sonucKodu.Equals("0000"))
                        {
                            accTrx.UTSUsageCommitment = false;
                            InvoiceLog.AddInfo("ÜTS Kullanım Kesinleştirme İptal başarılı.", accTrx.ObjectID, InvoiceOperationTypeEnum.UXXXXXXullanimKesinlestirmeIptal, InvoiceLogObjectTypeEnum.AccountTransaction, ObjectContext);
                            medulaResult.Succes = true;
                        }
                        else
                        {
                            accTrx.MedulaResultCode = result.sonucKodu;
                            accTrx.MedulaResultMessage = result.sonucMesaji;
                            InvoiceLog.AddErr("ÜTS Kullanım Kesinleştirmede İptal başarısız. (" + result.sonucKodu + " " + result.sonucMesaji + ")", accTrx.ObjectID, InvoiceOperationTypeEnum.UXXXXXXullanimKesinlestirmeIptal, InvoiceLogObjectTypeEnum.AccountTransaction, ObjectContext);
                            medulaResult.Succes = false;
                        }

                        medulaResult.SonucKodu = result.sonucKodu;
                        medulaResult.SonucMesaji = result.sonucMesaji;
                        medulaResultList.Add(medulaResult);
                    }
                }
            }

            return medulaResultList;
        }

        // Medula Döküman Kaydet Metodu
        public List<MedulaResult> SaveMedulaDocument(int? evrakId, List<UploadedDocument> documentList)
        {
            if (string.IsNullOrWhiteSpace(MedulaTakipNo))
                throw new TTException("Döküman kaydedebilmek için Takip Numarası dolu olmalıdır.");

            if (!evrakId.HasValue)
                throw new TTException("Döküman kaydedebilmek için Evrak No dolu olmalıdır.");

            List<MedulaResult> medulaResultList = new List<MedulaResult>();

            if (documentList.Count > 0)
            {
                bool documentExists = false;
                foreach (UploadedDocument document in documentList)
                {   // Döküman önceden bu takip ile Medula'ya kaydedilmemişse
                    if (MedulaDocumentEntries.Any(x => x.UploadedDocument.ObjectID == document.ObjectID && x.CurrentStateDefID == MedulaDocumentEntry.States.Saved) == false)
                    {
                        EvrakDokumanIslemleri.evrakDokumanKayitDVO evrakDokumanKayitDVO = new EvrakDokumanIslemleri.evrakDokumanKayitDVO();
                        evrakDokumanKayitDVO.evrakId = evrakId.Value;
                        evrakDokumanKayitDVO.takipNo = MedulaTakipNo;
                        evrakDokumanKayitDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();

                        evrakDokumanKayitDVO.dokuman = new EvrakDokumanIslemleri.evrakDokumanDVO();
                        //evrakDokumanKayitDVO.dokuman.islemSiraNo = 0; // Herhangi bir işlem ile ilişkili olduğunu belirtmek istendiğinde doldurulacak
                        evrakDokumanKayitDVO.dokuman.dosyaAdi = document.FileName;
                        evrakDokumanKayitDVO.dokuman.dokumanIcerik = (byte[])document.File;
                        //Crc32 crc32 = new Crc32();
                        //byte[] byteArray = crc32.ObjectToByteArray(this);

                        if (document.DosyaTuru != null)
                            evrakDokumanKayitDVO.dokuman.turu = document.DosyaTuru.dosyaTuruKodu.Value;

                        EvrakDokumanIslemleri.evrakDokumanKayitCevapDVO result = EvrakDokumanIslemleri.WebMethods.dokumanKaydetSync(Sites.SiteLocalHost, evrakDokumanKayitDVO);

                        if (result != null && !string.IsNullOrEmpty(result.sonucKodu))
                        {
                            MedulaResult medulaResult = new MedulaResult();

                            if (result.sonucKodu.Equals("0000"))
                            {
                                MedulaDocumentEntry medulaDocumentEntry = new MedulaDocumentEntry(ObjectContext);
                                medulaDocumentEntry.CurrentStateDefID = MedulaDocumentEntry.States.Saved;
                                medulaDocumentEntry.SubEpisodeProtocol = this;
                                medulaDocumentEntry.UploadedDocument = document;
                                medulaDocumentEntry.EvrakId = evrakId.Value;
                                medulaDocumentEntry.TakipNo = MedulaTakipNo;

                                if (result.dokuman != null)
                                    medulaDocumentEntry.ReferenceNo = result.dokuman.kayitReferansNo;

                                InvoiceLog.AddInfo("Medula Döküman Kayıt işlemi başarılı. MedulaDocumentEntry ObjectID : " + medulaDocumentEntry.ObjectID, ObjectID, InvoiceOperationTypeEnum.DokumanKaydet, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
                                medulaResult.Succes = true;
                            }
                            else
                            {
                                InvoiceLog.AddErr("Medula Döküman Kayıt işlemi başarısız. UploadedDocument ObjectID : " + document.ObjectID + "(" + result.sonucKodu + " " + result.sonucMesaji + ")", ObjectID, InvoiceOperationTypeEnum.DokumanKaydet, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
                                medulaResult.Succes = false;
                            }

                            medulaResult.SonucKodu = result.sonucKodu;
                            medulaResult.SonucMesaji = result.sonucMesaji;
                            medulaResultList.Add(medulaResult);
                        }

                        documentExists = true;
                    }
                }

                if (!documentExists)
                    medulaResultList.Add(new MedulaResult() { Succes = false, SonucMesaji = "Seçilen dökümanların hepsi Medula'ya kaydedilmiş durumdadır." });
            }

            return medulaResultList;
        }

        // Medula Döküman Sil Metodu
        public List<MedulaResult> DeleteMedulaDocument(int? evrakId, List<UploadedDocument> documentList)
        {
            if (string.IsNullOrWhiteSpace(MedulaTakipNo))
                throw new TTException("Döküman silebilmek için Takip Numarası dolu olmalıdır.");

            if (!evrakId.HasValue)
                throw new TTException("Döküman silebilmek için Evrak No dolu olmalıdır.");

            List<MedulaResult> medulaResultList = new List<MedulaResult>();

            if (documentList.Count > 0)
            {
                bool documentExists = false;
                foreach (UploadedDocument document in documentList)
                {
                    MedulaDocumentEntry medulaDocumentEntry = MedulaDocumentEntries.FirstOrDefault(x => x.UploadedDocument.ObjectID == document.ObjectID && x.CurrentStateDefID == MedulaDocumentEntry.States.Saved);

                    if (medulaDocumentEntry != null) // Döküman önceden Medula'ya kaydedilmişse
                    {
                        EvrakDokumanIslemleri.evrakDokumanSilDVO evrakDokumanSilDVO = new EvrakDokumanIslemleri.evrakDokumanSilDVO();
                        evrakDokumanSilDVO.evrakId = evrakId.Value;
                        evrakDokumanSilDVO.takipNo = MedulaTakipNo;
                        evrakDokumanSilDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                        evrakDokumanSilDVO.kayitReferansNo = medulaDocumentEntry.ReferenceNo.Value;

                        EvrakDokumanIslemleri.evrakDokumanSilCevapDVO result = EvrakDokumanIslemleri.WebMethods.dokumanSilSync(Sites.SiteLocalHost, evrakDokumanSilDVO);

                        if (result != null && !string.IsNullOrEmpty(result.sonucKodu))
                        {
                            MedulaResult medulaResult = new MedulaResult();

                            if (result.sonucKodu.Equals("0000"))
                            {
                                medulaDocumentEntry.CurrentStateDefID = MedulaDocumentEntry.States.Cancelled;

                                InvoiceLog.AddInfo("Medula Döküman Silme işlemi başarılı. MedulaDocumentEntry ObjectID : " + medulaDocumentEntry.ObjectID, ObjectID, InvoiceOperationTypeEnum.DokumanSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
                                medulaResult.Succes = true;
                            }
                            else
                            {
                                InvoiceLog.AddErr("Medula Döküman Silme işlemi başarısız. MedulaDocumentEntry ObjectID : " + medulaDocumentEntry.ObjectID + "(" + result.sonucKodu + " " + result.sonucMesaji + ")", ObjectID, InvoiceOperationTypeEnum.DokumanSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
                                medulaResult.Succes = false;
                            }

                            medulaResult.SonucKodu = result.sonucKodu;
                            medulaResult.SonucMesaji = result.sonucMesaji;
                            medulaResultList.Add(medulaResult);
                        }

                        documentExists = true;
                    }
                }

                if (!documentExists)
                    medulaResultList.Add(new MedulaResult() { Succes = false, SonucMesaji = "Seçilen dökümanların hiçbiri Medula'ya kaydedilmiş durumda değildir." });
            }

            return medulaResultList;
        }

        public void SetPropertiesFromOtherSEPs()
        {
            // Trafik Kazası ise : MedulaPlakaNo boşsa diğer SEP lerden set edilir
            if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("T"))
            {
                if (string.IsNullOrWhiteSpace(MedulaPlakaNo))
                {
                    SubEpisodeProtocol sep = SEPMaster.SubEpisodeProtocols.FirstOrDefault(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && !string.IsNullOrWhiteSpace(x.MedulaPlakaNo));
                    if (sep != null)
                        MedulaPlakaNo = sep.MedulaPlakaNo;
                }
            }

            // Trafik Kazası, İş Kazası ve Adli Vaka ise : MedulaVakaTarihi boşsa diğer SEP lerden set edilir
            if (MedulaProvizyonTipi.provizyonTipiKodu.Equals("T") || MedulaProvizyonTipi.provizyonTipiKodu.Equals("V") || MedulaProvizyonTipi.provizyonTipiKodu.Equals("I"))
            {
                if (MedulaVakaTarihi.HasValue == false)
                {
                    SubEpisodeProtocol sep = SEPMaster.SubEpisodeProtocols.FirstOrDefault(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.MedulaVakaTarihi.HasValue);
                    if (sep != null)
                        MedulaVakaTarihi = sep.MedulaVakaTarihi;
                }
            }
        }

        #endregion Methods
        public static StringBuilder InvoiceSEPSearchFilter(InvoiceSEPSearchCriteria issc, TTObjectContext objectContext)
        {
            StringBuilder sb = new StringBuilder();
            string stringInvoiceStatus = "";
            foreach (int? item in issc.status)
            {
                stringInvoiceStatus += item.ToString() + ",";
            }
            stringInvoiceStatus += "-99";
            #region Invoice Search and Durum
            if (issc.InvoiceSearchType == (int)PayerTypeEnum.Paid)
            {
                if (issc.status != null && (issc.status.Contains((int)MedulaSubEpisodeStatusEnum.Invoiced) || issc.status.Contains((int)MedulaSubEpisodeStatusEnum.InvoiceInconsistent)))
                {
                    #region Durum 
                    if (issc.status.Contains((int)MedulaSubEpisodeStatusEnum.Invoiced))
                        sb.AppendLine(" AND INVOICESTATUS = " + (int)MedulaSubEpisodeStatusEnum.Invoiced);
                    else if (issc.status.Contains((int)MedulaSubEpisodeStatusEnum.InvoiceInconsistent))
                        sb.AppendLine(" AND INVOICESTATUS = " + (int)MedulaSubEpisodeStatusEnum.InvoiceInconsistent);
                    #endregion
                    #region Invoice Search 
                    sb.AppendLine(" AND PAYER.TYPE.PAYERTYPE = " + (int)PayerTypeEnum.Paid);
                    #endregion
                }
                else
                {
                    if (issc.status != null && issc.status.Count > 0)
                        sb.AppendLine(" AND ((PAYER.TYPE.PAYERTYPE = " + (int)PayerTypeEnum.Paid + " AND INVOICESTATUS in ( " + stringInvoiceStatus + " )) or ");
                    else
                        sb.AppendLine(" AND ((PAYER.TYPE.PAYERTYPE = " + (int)PayerTypeEnum.Paid + "  ) or ");
                    sb.AppendLine(" (PAYER.TYPE.PAYERTYPE <> " + (int)PayerTypeEnum.Paid + " AND ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND INVOICEINCLUSION = 1 AND ACCOUNTPAYABLERECEIVABLE.TYPE = " + (int)APRTypeEnum.PATIENT + ").EXISTS ) ) ");
                }
            }
            else
            {
                #region Durum
                if (issc.status != null && issc.status.Count > 0)
                    sb.AppendLine(" AND INVOICESTATUS in ( " + stringInvoiceStatus + " )");
                #endregion
                #region Invoice Search
                if (issc.InvoiceSearchType != null)
                    sb.AppendLine(" AND PAYER.TYPE.PAYERTYPE = " + issc.InvoiceSearchType.Value);
                #endregion
            }

            if (sb.ToString().Contains("AND INVOICESTATUS") && issc.onlyStatus)
            {
                sb.AppendLine(" AND  NOT SEPMASTER.SUBEPISODEPROTOCOLS(CURRENTSTATE <> STATES.CANCELLED AND INVOICESTATUS not in ( " + stringInvoiceStatus + " )).EXISTS() ");
            }
            #endregion
            #region Müracaat Tarihi
            if (issc.episodeStartDate != null)
                sb.AppendLine(" AND MEDULAPROVIZYONTARIHI >= TODATE('" + issc.episodeStartDate.Value.ToString("yyyy-MM-dd 00:00:00 ") + "')");
            if (issc.episodeEndDate != null)
                sb.AppendLine(" AND MEDULAPROVIZYONTARIHI <= TODATE('" + issc.episodeEndDate.Value.ToString("yyyy-MM-dd 23:59:59") + "')");
            #endregion
            #region Yatış Tarihi
            if (issc.inPatientAdmissionStartDate != null)
                sb.AppendLine(" AND SUBEPISODE.INPATIENTADMISSION.HOSPITALINPATIENTDATE >= TODATE('" + issc.inPatientAdmissionStartDate.Value.ToString("yyyy-MM-dd 00:00:00") + "')");
            if (issc.inPatientAdmissionEndDate != null)
                sb.AppendLine(" AND SUBEPISODE.INPATIENTADMISSION.HOSPITALINPATIENTDATE  <= TODATE('" + issc.inPatientAdmissionEndDate.Value.ToString("yyyy-MM-dd 23:59:59") + "')");
            #endregion
            #region Çıkış Tarihi 
            if (issc.dischargeStartDate != null)
                sb.AppendLine(" AND SUBEPISODE.INPATIENTADMISSION.HOSPITALDISCHARGEDATE >= TODATE('" + issc.dischargeStartDate.Value.ToString("yyyy-MM-dd 00:00:00") + "')");
            if (issc.dischargeEndDate != null)
                sb.AppendLine(" AND SUBEPISODE.INPATIENTADMISSION.HOSPITALDISCHARGEDATE  <= TODATE('" + issc.dischargeEndDate.Value.ToString("yyyy-MM-dd 23:59:59") + "')");
            #endregion
            #region Fatura Tarihi 
            if (issc.invoiceStartDate != null)
                sb.AppendLine(" AND INVOICECOLLECTIONDETAIL.PAYERINVOICEDOCUMENT.DOCUMENTDATE >= TODATE('" + issc.invoiceStartDate.Value.ToString("yyyy-MM-dd 00:00:00") + "')");
            if (issc.invoiceEndDate != null)
                sb.AppendLine(" AND INVOICECOLLECTIONDETAIL.PAYERINVOICEDOCUMENT.DOCUMENTDATE <= TODATE('" + issc.invoiceEndDate.Value.ToString("yyyy-MM-dd 23:59:59") + "')");
            #endregion
            #region Fatura Tutarı 
            if (issc.firstInvoicePrice != null)
                sb.AppendLine(" AND MEDULAFATURATUTARI >= " + issc.firstInvoicePrice);
            if (issc.lastInvoicePrice != null)
                sb.AppendLine(" AND MEDULAFATURATUTARI <= " + issc.lastInvoicePrice);
            #endregion
            #region Fatura Kalan Gün Sayısı 
            if (issc.lastXDaysForInvoice != null)
            {

                int tempDay = 0;
                tempDay = 60 - issc.lastXDaysForInvoice.Value;
                DateTime tempDate = DateTime.Now.AddDays(tempDay * -1);
                sb.AppendLine(" AND (DATEPART(MEDULAPROVIZYONTARIHI) <= DATEPART(TODATE('" + tempDate.ToString("yyyy-MM-dd 00:00:00") + "')) OR DATEPART(SUBEPISODE.INPATIENTADMISSION.HOSPITALDISCHARGEDATE) <=  DATEPART(TODATE('" + tempDate.ToString("yyyy-MM-dd 00:00:00") + "')))");
            }

            #endregion
            #region Fatura Kullanıcısı 
            if (issc.InvoiceUser != null)
            {
                sb.AppendLine(" AND INVOICECOLLECTIONDETAIL.PAYERINVOICEDOCUMENT.RESUSER.OBJECTID = '" + issc.InvoiceUser + "' ");
            }
            #endregion
            #region Tedavi Türü
            if (issc.tedaviTuru != null && issc.tedaviTuru.Count > 0)
            {
                if (issc.searchResultType == "Takip")
                {
                    bool agExists = issc.tedaviTuru.Contains(Guid.Empty); // Listede "Ayakta+Günübirlik" var mı ?
                    bool ttExists = !agExists || (agExists && issc.tedaviTuru.Count > 1); // Listede Tedavi Türü (A,Y,G) var mı ?
                    string agFilter = "SEPMASTER.SUBEPISODEPROTOCOLS(CURRENTSTATE <> STATES.CANCELLED AND MEDULATEDAVITURU.TEDAVITURUKODU = 'A').EXISTS() AND SEPMASTER.SUBEPISODEPROTOCOLS(CURRENTSTATE <> STATES.CANCELLED AND MEDULATEDAVITURU.TEDAVITURUKODU = 'G').EXISTS()";

                    if (ttExists)
                    {
                        string ttFilter = "MEDULATEDAVITURU IN (" + CreateInjectionOfGuidList(issc.tedaviTuru) + ")";
                        if (agExists)
                            sb.AppendLine(" AND ((" + ttFilter + ") OR (" + agFilter + "))");
                        else
                            sb.AppendLine(" AND " + ttFilter);
                    }
                    else if (agExists)
                        sb.AppendLine(" AND " + agFilter);
                }
                //else
                //{
                //    if (issc.tedaviTuru.Value != Guid.Empty) // Empty Guid A+G için kullanıldı. Başvuru bazlıda bu şekilde bir durum değerlendirilmedi.
                //    {
                //        TedaviTuru tt = objectContext.GetObject<TedaviTuru>(issc.tedaviTuru.Value) as TedaviTuru;
                //        if (tt != null)
                //        {
                //            if (tt.tedaviTuruKodu == "A" || tt.tedaviTuruKodu == "G")
                //                sb.AppendLine(" AND SUBEPISODE.EPISODE.PATIENTSTATUS = 0 ");
                //            else
                //                sb.AppendLine(" AND SUBEPISODE.EPISODE.PATIENTSTATUS in (1,2,3) ");
                //        }
                //    }
                //}

                if (issc.tedaviTuruSadeceAyaktan)
                    sb.AppendLine(" AND NOT SEPMASTER.SUBEPISODEPROTOCOLS(CURRENTSTATE <> STATES.CANCELLED AND MEDULATEDAVITURU.TEDAVITURUKODU <> 'A').EXISTS() ");
            }
            #endregion

            if (issc.searchResultType == "Takip")
            {
                #region Tedavi Tipi
                if (issc.tedaviTipi != null && issc.tedaviTipi.Count > 0)
                    sb.AppendLine(" AND MEDULATEDAVITIPI IN (" + CreateInjectionOfGuidList(issc.tedaviTipi) + ")");
                #endregion
                #region Takip Tipi
                if (issc.takipTipi != null && issc.takipTipi.Count > 0)
                    sb.AppendLine(" AND MEDULATAKIPTIPI IN (" + CreateInjectionOfGuidList(issc.takipTipi) + ")");
                #endregion
                #region Provizyon Tipi
                if (issc.provizyonTipi != null && issc.provizyonTipi.Count > 0)
                    sb.AppendLine(" AND MEDULAPROVIZYONTIPI IN (" + CreateInjectionOfGuidList(issc.provizyonTipi) + ")");
                #endregion
                #region Devredilen Kurum
                if (issc.devredilenKurum != null && issc.devredilenKurum.Count > 0)
                    sb.AppendLine(" AND MEDULADEVREDILENKURUM IN (" + CreateInjectionOfGuidList(issc.devredilenKurum) + ")");
                #endregion
            }

            #region İstisnai Hal
            if (issc.istisnaiHal != null && issc.istisnaiHal.Count > 0)
                sb.AppendLine(" AND MEDULAISTISNAIHAL IN (" + CreateInjectionOfGuidList(issc.istisnaiHal) + ")");
            #endregion
            #region Triaj
            if (issc.triaj != null && issc.triaj.Count > 0)
                sb.AppendLine(" AND TRIAGE IN (" + CreateInjectionOfGuidList(issc.triaj) + ")");
            #endregion

            #region Dönem
            if (issc.term != null)
                sb.AppendLine(" AND INVOICECOLLECTIONDETAIL.INVOICECOLLECTION.INVOICETERM = '" + issc.term + "'");
            #endregion
            #region Kurum Türü
            if (issc.payerType != null)
                sb.AppendLine(" AND PAYER.TYPE = '" + issc.payerType + "'");
            #endregion
            #region Kurum 
            if (issc.payer != null && issc.payer.Count > 0)
                sb.AppendLine(" AND PAYER in ( " + CreateInjectionOfGuidList(issc.payer) + " )");
            else
            {
                string geciciKorumaKanunuKurumu = TTObjectClasses.SystemParameter.GetParameterValue("GECICIKORUMAKANUNUKURUMU", "13c520bc-1b39-41f6-a3a8-e98f7b2f2c4a");
                sb.AppendLine(" AND PAYER <> '" + geciciKorumaKanunuKurumu + "' ");
            }
            #endregion
            #region Bina
            if (issc.building != null)
                sb.AppendLine(" AND SUBEPISODE.PATIENTADMISSION.BUILDING = '" + issc.building + "'");
            #endregion
            #region Birim
            if (issc.section != null && issc.section.Count > 0)
                sb.AppendLine(" AND SUBEPISODE.RESSECTION in (" + CreateInjectionOfGuidList(issc.section) + " )");
            #endregion
            #region Branş
            if (issc.branch != null && issc.branch.Count > 0)
            {
                if (issc.searchResultType == "Takip")
                    sb.AppendLine(" AND BRANS in ( " + CreateInjectionOfGuidList(issc.branch) + " ) ");
                else
                    sb.AppendLine(" AND SUBEPISODE.EPISODE.MAINSPECIALITY = '" + issc.branch + "'");
            }

            #endregion
            #region Doktor  
            //TODO: AAE Doktor eklenecek
            if (issc.doctor != null && issc.doctor.Count > 0)
                sb.AppendLine(" AND SUBEPISODE.PATIENTEXAMINATIONS( PROCEDUREDOCTOR in (" + CreateInjectionOfGuidList(issc.doctor) + ") ).EXISTS() ");
            #endregion
            #region Yatan Statüsü
            if (issc.inPatientStatus != null)
                sb.AppendLine(" AND SUBEPISODE.INPATIENTSTATUS = " + (int)issc.inPatientStatus);
            #endregion
            #region Tanı
            if (issc.diagnosState != null && (issc.diagnos == null || issc.diagnos == Guid.Empty))
            {
                string tempNOT = "";
                if (issc.diagnosState == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " SEPDIAGNOSES().EXISTS ");
            }
            else if (issc.diagnosState != null && issc.diagnos != null && issc.diagnos != Guid.Empty)
            {
                string tempNOT = "";
                if (issc.diagnosState == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " SEPDIAGNOSES(DIAGNOSE = '" + issc.diagnos + "').EXISTS ");
            }

            #endregion
            #region Hizmet 1
            if (issc.procedure1State != null && (issc.procedure1 == null || issc.procedure1 == Guid.Empty))
            {
                string tempNOT = "";
                if (issc.procedure1State == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE IS NOT NULL).EXISTS ");
            }
            else if (issc.procedure1State != null && issc.procedure1 != null && issc.procedure1 != Guid.Empty)
            {
                string tempNOT = "";
                if (issc.procedure1State == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE IS NOT NULL AND SUBACTIONPROCEDURE.PROCEDUREOBJECT = '" + issc.procedure1 + "').EXISTS ");
            }

            #endregion
            #region Hizmet 2
            if (issc.procedure2State != null && (issc.procedure2 == null || issc.procedure2 == Guid.Empty))
            {
                string tempNOT = "";
                if (issc.procedure2State == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE IS NOT NULL).EXISTS ");
            }
            else if (issc.procedure2State != null && issc.procedure2 != null && issc.procedure2 != Guid.Empty)
            {
                string tempNOT = "";
                if (issc.procedure2State == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE IS NOT NULL AND SUBACTIONPROCEDURE.PROCEDUREOBJECT = '" + issc.procedure2 + "').EXISTS ");
            }

            #endregion
            #region Malzeme
            if (issc.materialState != null && (issc.material == null || issc.material == Guid.Empty))
            {
                string tempNOT = "";
                if (issc.materialState == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONMATERIAL IS NOT NULL).EXISTS ");
            }
            else if (issc.materialState != null && issc.material != null && issc.material != Guid.Empty)
            {
                string tempNOT = "";
                if (issc.materialState == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONMATERIAL IS NOT NULL AND SUBACTIONMATERIAL.MATERIAL = '" + issc.material + "').EXISTS ");
            }

            #endregion
            #region Hizmet Grup
            if (issc.procedureGroupState != null && issc.procedureGroup != null && issc.procedureGroup.Count > 0)
            {
                string tempNOT = "";
                if (issc.procedureGroupState == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE IS NOT NULL AND SUBACTIONPROCEDURE.PROCEDUREOBJECT.MEDULAPROCEDURETYPE in ( " + CreateInjectionOfObjectList(issc.procedureGroup) + ")).EXISTS ");
            }

            #endregion
            #region Hizmet SUT Eki
            if (issc.procedureSUTAppendixState != null && issc.procedureSUTAppendix != null && issc.procedureSUTAppendix.Count > 0)
            {

                string tempNOT = "";
                if (issc.procedureSUTAppendixState == (int)VarYokGarantiEnum.Y)
                    tempNOT = " NOT ";
                sb.AppendLine(" AND " + tempNOT + " ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE IS NOT NULL AND SUBACTIONPROCEDURE.PROCEDUREOBJECT.SUTAPPENDIX in ( " + CreateInjectionOfObjectList(issc.procedureSUTAppendix) + ")).EXISTS ");
            }

            #endregion
            //TODO: AAE Hizmet Grup Bazlı , I/S Grup Bazlı , 4.sütundaki bütün alanlar ,doktor ve yatış numarası için sorgulama kriteri eklenecek. 

            #region Bağlı Takip
            if (issc.bagliTakip != null)
            {
                if (issc.bagliTakip == (int)VarYokGarantiEnum.V)
                    sb.AppendLine(" AND SEPMASTER.SUBEPISODEPROTOCOLS(CURRENTSTATE <> STATES.CANCELLED).COUNT() > 1 ");
                else
                    sb.AppendLine(" AND SEPMASTER.SUBEPISODEPROTOCOLS(CURRENTSTATE <> STATES.CANCELLED).COUNT() = 1 ");
            }
            #endregion
            #region Paket İşlem
            if (issc.inPatientPackage != null)
            {
                if (issc.inPatientPackage == (int)VarYokGarantiEnum.V)
                    sb.AppendLine(" AND ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE IS NOT NULL AND  EXTERNALCODE LIKE 'P%'  ).EXISTS() ");
                else
                    sb.AppendLine(" AND NOT SEPMASTER.SUBEPISODEPROTOCOLS(CURRENTSTATE <> STATES.CANCELLED AND ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE IS NOT NULL AND  EXTERNALCODE LIKE 'P%'  ).EXISTS() ).EXISTS() ");
            }
            #endregion
            #region Muayene
            if (issc.examination != null)
            {
                if (issc.examination == (int)VarYokGarantiEnum.V)
                    sb.AppendLine(" AND (SUBEPISODE.DENTALEXAMINATIONS(CURRENTSTATE IN (STATES.EXAMINATIONCOMPLETED,STATES.COMPLETED ) ).EXISTS() OR SUBEPISODE.PATIENTEXAMINATIONS(CURRENTSTATE IN (STATES.EXAMINATIONCOMPLETED,STATES.COMPLETED ) ).EXISTS() )  ");
                else
                    sb.AppendLine(" AND MEDULATEDAVITURU.TEDAVITURUKODU = 'A' AND ( NOT SUBEPISODE.PATIENTEXAMINATIONS(CURRENTSTATE IN (STATES.EXAMINATIONCOMPLETED,STATES.COMPLETED ) ).EXISTS() AND NOT SUBEPISODE.DENTALEXAMINATIONS(CURRENTSTATE IN (STATES.EXAMINATIONCOMPLETED,STATES.COMPLETED ) ).EXISTS() )  ");
            }
            #endregion
            #region İzlem Listem
            if (issc.sepWatchType != null)
            {
                if (issc.sepWatchType == (int)InvoiceSEPWatchTypeEnum.Izlemdekiler)
                    sb.AppendLine(" AND IZLEMUSER = '" + Common.CurrentUser.TTObjectID + "' ");
                else if (issc.sepWatchType == (int)InvoiceSEPWatchTypeEnum.IzlemdeOlmayanlar)
                    sb.AppendLine(" AND IZLEMUSER IS NOT NULL AND IZLEMUSER <> '" + Common.CurrentUser.TTObjectID + "' ");
                else if (issc.sepWatchType == (int)InvoiceSEPWatchTypeEnum.HicIzlenmemisler)
                    sb.AppendLine(" AND IZLEMUSER IS NULL ");
            }
            #endregion
            #region Fatura Engeli
            if (issc.invoiceBlockingState != null)
            {
                if (issc.invoiceBlockingState == (int)VarYokGarantiEnum.Y)
                    sb.AppendLine(" AND NOT SUBEPISODE.EPISODE.INVOICEBLOCKINGS(ACTIVE = 1).EXISTS ");
                else
                    sb.AppendLine(" AND SUBEPISODE.EPISODE.INVOICEBLOCKINGS(ACTIVE = 1).EXISTS  ");
            }
            #endregion
            #region Sistem Bazlı Fatura Engeli
            if (issc.bannedInvoice != null)
            {
                List<Guid> blockStates = InvoiceBlockingDefinition.GetBlockStateIDs((int)APRTypeEnum.PAYER, objectContext);
                if (blockStates != null && blockStates.Count > 0)
                {
                    string blockStatesString = CreateInjectionOfGuidList(blockStates);

                    if (issc.bannedInvoice == (int)VarYokGarantiEnum.V)
                        sb.AppendLine(" AND ACCOUNTTRANSACTIONS(ACCOUNTPAYABLERECEIVABLE.TYPE = 1 AND CURRENTSTATE <> STATES.CANCELLED AND CURRENTSTATE <> STATES.MEDULADONTSEND AND SUBACTIONPROCEDURE IS NOT NULL AND(IFNULL(SUBACTIONPROCEDURE.PROCEDUREOBJECT.DONTBLOCKINVOICE, 0) <> 1 AND(SUBACTIONPROCEDURE.CURRENTSTATEDEFID in (" + blockStatesString + ") or SUBACTIONPROCEDURE.EPISODEACTION.CURRENTSTATEDEFID in (" + blockStatesString + ")))).EXISTS() ");
                    else
                        sb.AppendLine(" AND NOT SEPMASTER.SUBEPISODEPROTOCOLS(CURRENTSTATE <> STATES.CANCELLED AND ACCOUNTTRANSACTIONS(ACCOUNTPAYABLERECEIVABLE.TYPE = 1 AND CURRENTSTATE <> STATES.CANCELLED AND CURRENTSTATE <> STATES.MEDULADONTSEND AND SUBACTIONPROCEDURE IS NOT NULL AND(IFNULL(SUBACTIONPROCEDURE.PROCEDUREOBJECT.DONTBLOCKINVOICE, 0) <> 1 AND(SUBACTIONPROCEDURE.CURRENTSTATEDEFID in (" + blockStatesString + ") or SUBACTIONPROCEDURE.EPISODEACTION.CURRENTSTATEDEFID in (" + blockStatesString + ")))).EXISTS() ).EXISTS() ");
                }
            }
            #endregion
            #region İncelendi
            if (issc.investigation != null)
            {
                if (issc.investigation == (int)EvetHayirDurumEnum.E)
                    sb.AppendLine(" AND INVESTIGATION = 1 ");
                else
                    sb.AppendLine(" AND (INVESTIGATION = 0 OR INVESTIGATION IS NULL)");
            }
            #endregion
            #region Kontrol Edildi
            if (issc.checkedValue != null)
            {
                if (issc.checkedValue == (int)EvetHayirDurumEnum.E)
                    sb.AppendLine(" AND CHECKED = 1 ");
                else
                    sb.AppendLine(" AND (CHECKED = 0 or CHECKED IS NULL)");
            }
            #endregion
            #region Fatura İptali
            if (issc.invoiceCancel != null)
            {
                if (issc.invoiceCancel == (int)VarYokGarantiEnum.V)
                    sb.AppendLine(" AND IFNULL(INVOICECANCELCOUNT,0) > 0 ");
                else
                    sb.AppendLine(" AND IFNULL(INVOICECANCELCOUNT,0) <= 0 ");
            }
            #endregion
            #region Hizmet Fiyat Güncelleme
            if (issc.accTrxUnitPriceUpdate != null)
            {
                if (issc.accTrxUnitPriceUpdate == (int)VarYokGarantiEnum.V)
                    sb.AppendLine(" AND ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND INVOICELOGS(OPERATIONTYPE = 43).EXISTS()).EXISTS() ");
                else
                    sb.AppendLine(" AND NOT ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND INVOICELOGS(OPERATIONTYPE = 43).EXISTS()).EXISTS() ");
            }
            #endregion
            #region Epikriz
            if (issc.epicrisis != null)
            {
                if (issc.epicrisis == (int)VarYokGarantiEnum.V)
                    sb.AppendLine(" AND (SUBEPISODE.INPATIENTPHYSICIANPROGRESSES().EXISTS OR SUBEPISODE.INPATIENTRTFBYSPECIALITIES(RTFDEFINITIONSBYSPECIALITY.ISNEEDFOREPICRISIS = 1 AND RTF IS NOT NULL).EXISTS) ");
                else
                    sb.AppendLine(" AND NOT (SUBEPISODE.INPATIENTPHYSICIANPROGRESSES().EXISTS OR SUBEPISODE.INPATIENTRTFBYSPECIALITIES(RTFDEFINITIONSBYSPECIALITY.ISNEEDFOREPICRISIS = 1 AND RTF IS NOT NULL).EXISTS) ");
            }
            #endregion
            #region Hata Kodu
            if (issc.FirstSelectErrorCode.HasValue && issc.FirstSelectErrorCode.Value != Guid.Empty && issc.FirstSelectErrorCode != null && issc.status.Count > 0 &&
                (issc.status.Contains((int)MedulaSubEpisodeStatusEnum.InvoiceEntryWithError)
                || issc.status.Contains((int)MedulaSubEpisodeStatusEnum.InvoiceReadWithError) || issc.status.Contains((int)MedulaSubEpisodeStatusEnum.ProcedureEntryWithError)))
            {
                MedulaErrorCodeDefinition mecd = objectContext.GetObject<MedulaErrorCodeDefinition>(issc.FirstSelectErrorCode.Value) as MedulaErrorCodeDefinition;
                if (issc.status.Contains((int)MedulaSubEpisodeStatusEnum.ProcedureEntryWithError))
                    sb.AppendLine(" AND ACCOUNTTRANSACTIONS(CURRENTSTATE = STATES.MEDULAENTRYUNSUCCESSFUL AND MEDULARESULTCODE = '" + mecd.Code + "').EXISTS ");
                else
                    sb.AppendLine(" AND MEDULASONUCKODU = '" + mecd.Code + "' ");

                if (!string.IsNullOrEmpty(issc.SecondSelectErrorCode) && mecd.Code == "1108")
                {
                    if (issc.status.Contains((int)MedulaSubEpisodeStatusEnum.InvoiceEntryWithError) || issc.status.Contains((int)MedulaSubEpisodeStatusEnum.InvoiceReadWithError))
                    {
                        string[] splittedCodes = issc.SecondSelectErrorCode.Split('-');
                        sb.AppendLine(" AND MEDULASONUCMESAJI like '%" + splittedCodes[0] + "%' AND  MEDULASONUCMESAJI like '%" + splittedCodes[1] + "%' ");
                    }
                }
                else if (!string.IsNullOrEmpty(issc.SecondSelectErrorCode) && (mecd.Code == "1299" || mecd.Code == "1030"))
                {
                    if (issc.status.Contains((int)MedulaSubEpisodeStatusEnum.ProcedureEntryWithError))
                    {
                        sb.AppendLine(" AND ACCOUNTTRANSACTIONS(CURRENTSTATE = STATES.MEDULAENTRYUNSUCCESSFUL AND EXTERNALCODE = '" + issc.SecondSelectErrorCode + "').EXISTS ");
                    }
                }
                else if (!string.IsNullOrEmpty(issc.SecondSelectErrorCode) && mecd.Code == "1692")
                {
                    if (!issc.status.Contains((int)MedulaSubEpisodeStatusEnum.ProcedureEntryWithError))
                    {
                        sb.AppendLine(" AND ACCOUNTTRANSACTIONS(NABIZRESULTCODE = '1692' AND EXTERNALCODE = '" + issc.SecondSelectErrorCode + "').EXISTS ");
                    }
                }
            }
            else if (issc.BannedState.HasValue && issc.BannedState.Value != Guid.Empty && issc.BannedState != null && issc.bannedInvoice == (int)VarYokGarantiEnum.V)
            {
                sb.AppendLine(" AND ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND CURRENTSTATE <> STATES.MEDULADONTSEND AND (SUBACTIONPROCEDURE.CURRENTSTATEDEFID = '" + issc.BannedState.Value + "' ");
                sb.AppendLine(" OR SUBACTIONPROCEDURE.EPISODEACTION.CURRENTSTATEDEFID = '" + issc.BannedState.Value + "' ) ");

                if (!string.IsNullOrEmpty(issc.SecondSelectErrorCode))
                {
                    sb.AppendLine("   AND  EXTERNALCODE = '" + issc.SecondSelectErrorCode + "').EXISTS ");
                }
                else
                {
                    sb.AppendLine("  ).EXISTS ");
                }
            }
            #endregion
            #region Cinsiyet
            if (issc.sex != null && issc.sex != Guid.Empty)
                sb.AppendLine(" AND SUBEPISODE.EPISODE.PATIENT.SEX = '" + issc.sex + "'");
            #endregion
            #region Muayene Sonucu                
            if (issc.treatmentResult != null)
            {
                if (issc.treatmentResult == (int)VarYokGarantiEnum.Y)
                    sb.AppendLine(" AND (SUBEPISODE.PATIENTEXAMINATIONS( TREATMENTRESULT is null ).EXISTS() AND SUBEPISODE.DENTALEXAMINATIONS(TREATMENTRESULT is null).EXISTS())  ");
                else
                    sb.AppendLine(" AND (SUBEPISODE.PATIENTEXAMINATIONS( TREATMENTRESULT is not null).EXISTS() OR SUBEPISODE.DENTALEXAMINATIONS( TREATMENTRESULT is not null).EXISTS()) ");
                //if (issc.examination == (int)VarYokGarantiEnum.V)
                //    sb.AppendLine(" AND (SUBEPISODE.DENTALEXAMINATIONS(CURRENTSTATE IN (STATES.EXAMINATIONCOMPLETED,STATES.COMPLETED ) ).EXISTS() OR SUBEPISODE.PATIENTEXAMINATIONS(CURRENTSTATE IN (STATES.EXAMINATIONCOMPLETED,STATES.COMPLETED ) ).EXISTS() )  ");
                //else
                //    sb.AppendLine(" AND MEDULATEDAVITURU.TEDAVITURUKODU = 'A' AND ( NOT SUBEPISODE.PATIENTEXAMINATIONS(CURRENTSTATE IN (STATES.EXAMINATIONCOMPLETED,STATES.COMPLETED ) ).EXISTS() AND NOT SUBEPISODE.DENTALEXAMINATIONS(CURRENTSTATE IN (STATES.EXAMINATIONCOMPLETED,STATES.COMPLETED ) ).EXISTS() )  ");
            }
            #endregion
            #region Nabız 700 Durum
            if (issc.nabizStatus != null)
            {
                if (issc.nabizStatus == 0)//Yeni
                    sb.AppendLine(" AND   ACCOUNTTRANSACTIONS( ACCOUNTPAYABLERECEIVABLE.TYPE <> " + (int)APRTypeEnum.PATIENT + " AND CURRENTSTATE <> STATES.CANCELLED AND CURRENTSTATE <> STATES.MEDULADONTSEND AND ( NABIZ700STATUS = " + (int)SendToENabizEnum.ToBeSent + " OR NABIZ700STATUS is null ) ).EXISTS ");
                else if (issc.nabizStatus == 1)//Başarılı
                    sb.AppendLine(" AND  NOT ACCOUNTTRANSACTIONS( ACCOUNTPAYABLERECEIVABLE.TYPE <> " + (int)APRTypeEnum.PATIENT + " AND CURRENTSTATE <> STATES.CANCELLED AND CURRENTSTATE <> STATES.MEDULADONTSEND AND (NABIZ700STATUS = " + (int)SendToENabizEnum.UnSuccessful + " OR NABIZ700STATUS = " + (int)SendToENabizEnum.ToBeSent + " OR NABIZ700STATUS is null ) ).EXISTS ");
                else if (issc.nabizStatus == 2)//Hatalı
                    sb.AppendLine(" AND   ACCOUNTTRANSACTIONS(  ACCOUNTPAYABLERECEIVABLE.TYPE <> " + (int)APRTypeEnum.PATIENT + " AND CURRENTSTATE <> STATES.CANCELLED AND CURRENTSTATE <> STATES.MEDULADONTSEND AND NABIZ700STATUS = " + (int)SendToENabizEnum.UnSuccessful + ").EXISTS ");
            }
            #endregion
            #region Fatura Açıklaması
            if (issc.SEPDescriptionState != null)
            {
                if (issc.SEPDescriptionState == (int)VarYokGarantiEnum.Y)
                    sb.AppendLine(" AND (DESCRIPTION IS NULL OR DESCRIPTION = ' ')");
                else if (issc.SEPDescriptionState == (int)VarYokGarantiEnum.V && string.IsNullOrEmpty(issc.SEPDescription))
                    sb.AppendLine(" AND DESCRIPTION IS NOT NULL ");
                else if (issc.SEPDescriptionState == (int)VarYokGarantiEnum.V && !string.IsNullOrEmpty(issc.SEPDescription))
                    sb.AppendLine(" AND DESCRIPTION LIKE '%" + issc.SEPDescription + "%' ");
            }
            #endregion
            #region Kabul Tipi
            if (issc.admissionStatus.HasValue)
                sb.AppendLine(" AND SUBEPISODE.PATIENTADMISSION.ADMISSIONSTATUS = " + issc.admissionStatus);
            #endregion
            #region Taburcu Tipi
            if (issc.taburcuTipi != null && issc.taburcuTipi.Count > 0)
                sb.AppendLine(" AND SUBEPISODE.TREATMENTDISCHARGES(CURRENTSTATE IN (STATES.PREDISCHARGE, STATES.DISCHARGED) AND DISCHARGETYPE IN (" + CreateInjectionOfGuidList(issc.taburcuTipi) + ")).EXISTS ");
            #endregion

            #region ÖZEL DURUMLAR
            if (issc.specialCase != null)
            {
                sb.AppendLine(" AND MEDULAGREENCARDFACILITYCODE = " + issc.specialCase);
            }
            #endregion
            #region Fatura Kontrol Durumları
            if (issc.controlStatus != null && issc.controlStatus.Count > 0)
            {
                sb.AppendLine(" AND ( (" + issc.controlStatus[0] + ") ");
                if (issc.controlStatus.Count > 1)
                {
                    for (int i = 1; i < issc.controlStatus.Count; i++)
                    {
                        sb.AppendLine(" OR  (" + issc.controlStatus[i] + ") ");
                    }
                }
                sb.AppendLine(") ");
            }
            #endregion

            #region İşlem Durumları
            if (issc.procedureStateDef != null && issc.procedureStateDef.Count > 0)
            {
                string states = CreateInjectionOfGuidList(issc.procedureStateDef);

                sb.AppendLine(" AND ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE IS NOT NULL AND");
                sb.AppendLine(" (SUBACTIONPROCEDURE.CURRENTSTATEDEFID IN (" + states + ") OR ");
                sb.AppendLine(" SUBACTIONPROCEDURE.EPISODEACTION.CURRENTSTATEDEFID IN (" + states + "))).EXISTS ");
            }
            #endregion

            #region TEXT ARAMA 
            #region Hasta Adı
            if (!string.IsNullOrEmpty(issc.patientName))
                sb.AppendLine(" AND SUBEPISODE.EPISODE.PATIENT.NAME like '%" + issc.patientName.ToUpper() + "%' ");
            #endregion
            #region Hasta Soyadı
            if (!string.IsNullOrEmpty(issc.patientSurname))
                sb.AppendLine(" AND SUBEPISODE.EPISODE.PATIENT.SURNAME like '%" + issc.patientSurname.ToUpper() + "%' ");
            #endregion
            #region TC Kimlik Numarası
            if (!string.IsNullOrEmpty(issc.patientUniqueRefNo))
                sb.AppendLine(" AND SUBEPISODE.EPISODE.PATIENT.UNIQUEREFNO  = '" + issc.patientUniqueRefNo + "' ");
            #endregion
            #region Yatış No
            //TODO: AAE Yatış Numarası eklenecek.
            //if (issc.inPatientAdmissionNo != string.Empty)
            //    sb.AppendLine(" AND XXXX  = '" + issc.inPatientAdmissionNo + "' ");
            #endregion

            if (!string.IsNullOrEmpty(issc.takipNo) || !string.IsNullOrEmpty(issc.basvuruNo) || !string.IsNullOrEmpty(issc.patientAdmissionNo))
                sb = new StringBuilder();
            #region Takip No
            if (!string.IsNullOrEmpty(issc.takipNo))
                sb.AppendLine(" AND MEDULATAKIPNO  = '" + issc.takipNo.Trim() + "' ");
            #endregion
            #region Başvuru No
            if (!string.IsNullOrEmpty(issc.basvuruNo))
                sb.AppendLine(" AND MEDULABASVURUNO  = '" + issc.basvuruNo.Trim() + "' ");
            #endregion
            #region Kabul No
            if (!string.IsNullOrEmpty(issc.patientAdmissionNo))
                sb.AppendLine(" AND SUBEPISODE.PROTOCOLNO  like '" + issc.patientAdmissionNo.Trim() + "%' ");
            #endregion
            #endregion

            sb = new StringBuilder(sb.ToString().Substring(4, sb.Length - 4));
            return sb;
        }

        public static string CreateInjectionOfGuidList(List<Guid> guidList)
        {
            if (guidList != null && guidList.Count > 0)
            {
                string result = string.Empty;
                foreach (Guid guid in guidList)
                    if (guid != Guid.Empty)
                        result += "'" + guid + "',";

                result = result.Substring(0, result.Length - 1);
                return result;
            }
            return null;
        }
        public static string CreateInjectionOfObjectList<T>(List<T> itemList)
        {
            if (itemList != null && itemList.Count > 0)
            {
                string result = string.Empty;
                foreach (T item in itemList)
                    if (item != null)
                        result += "'" + item.ToString() + "',";

                result = result.Substring(0, result.Length - 1);
                return result;
            }
            return null;
        }

        public class InvoiceSEPSearchCriteria
        {
            public int? InvoiceSearchType
            {
                get;
                set;
            }

            public DateTime? episodeStartDate
            {
                get;
                set;
            }

            public DateTime? episodeEndDate
            {
                get;
                set;
            }

            public DateTime? inPatientAdmissionStartDate
            {
                get;
                set;
            }

            public DateTime? inPatientAdmissionEndDate
            {
                get;
                set;
            }

            public DateTime? dischargeStartDate
            {
                get;
                set;
            }

            public DateTime? dischargeEndDate
            {
                get;
                set;
            }
            public DateTime? invoiceStartDate
            {
                get;
                set;
            }

            public DateTime? invoiceEndDate
            {
                get;
                set;
            }
            public List<int?> status
            {
                get;
                set;
            }
            public int? firstInvoicePrice
            {
                get;
                set;
            }
            public int? lastInvoicePrice
            {
                get;
                set;
            }
            public int? lastXDaysForInvoice
            {
                get;
                set;
            }
            public Guid? InvoiceUser
            {
                get;
                set;
            }
            public bool onlyStatus
            {
                get;
                set;
            }

            public List<Guid> tedaviTuru
            {
                get;
                set;
            }
            public bool tedaviTuruSadeceAyaktan
            {
                get;
                set;
            }

            public List<Guid> tedaviTipi
            {
                get;
                set;
            }

            public List<Guid> takipTipi
            {
                get;
                set;
            }

            public List<Guid> provizyonTipi
            {
                get;
                set;
            }

            public List<Guid> devredilenKurum
            {
                get;
                set;
            }

            public Guid? term
            {
                get;
                set;
            }

            public Guid? payerType
            {
                get;
                set;
            }

            public List<Guid> payer
            {
                get;
                set;
            }

            public Guid? building
            {
                get;
                set;
            }

            public List<Guid> section
            {
                get;
                set;
            }

            public List<Guid> branch
            {
                get;
                set;
            }

            public List<Guid> doctor
            {
                get;
                set;
            }

            public int? diagnosState
            {
                get;
                set;
            }
            public int? invoiceBlockingState
            {
                get;
                set;
            }
            public Guid? diagnos
            {
                get;
                set;
            }

            public int? procedure1State
            {
                get;
                set;
            }

            public Guid? procedure1
            {
                get;
                set;
            }

            public int? procedure2State
            {
                get;
                set;
            }

            public Guid? procedure2
            {
                get;
                set;
            }

            public int? materialState
            {
                get;
                set;
            }

            public Guid? material
            {
                get;
                set;
            }

            public int? materialGroupState
            {
                get;
                set;
            }

            public Guid? materialGroup
            {
                get;
                set;
            }

            public int? procedureGroupState
            {
                get;
                set;
            }

            public List<int?> procedureGroup
            {
                get;
                set;
            }

            public int? procedureSUTAppendixState
            {
                get;
                set;
            }

            public List<int?> procedureSUTAppendix
            {
                get;
                set;
            }
            public int? bagliTakip
            {
                get;
                set;
            }

            public int? controlEpisode
            {
                get;
                set;
            }

            public int? bannedInvoice
            {
                get;
                set;
            }

            public int? inPatientPackage
            {
                get;
                set;
            }

            public int? examination
            {
                get;
                set;
            }

            public int? flowableProcedure
            {
                get;
                set;
            }

            public int? traficAccidentForm
            {
                get;
                set;
            }

            public int? invoiceCancel
            {
                get;
                set;
            }

            public int? accTrxUnitPriceUpdate
            {
                get;
                set;
            }

            public int? epicrisis
            {
                get;
                set;
            }

            public int? followList
            {
                get;
                set;
            }

            public string patientName
            {
                get;
                set;
            }

            public string patientSurname
            {
                get;
                set;
            }

            public string patientUniqueRefNo
            {
                get;
                set;
            }

            public string episodeProtocolNo
            {
                get;
                set;
            }

            public string takipNo
            {
                get;
                set;
            }

            public string basvuruNo
            {
                get;
                set;
            }

            public string inPatientAdmissionNo
            {
                get;
                set;
            }

            public string patientAdmissionNo
            {
                get;
                set;
            }

            public string searchResultType
            {
                get;
                set;
            }

            public int? sepWatchType
            {
                get;
                set;
            }
            public int? inPatientStatus
            {
                get;
                set;
            }
            public int? investigation
            {
                get;
                set;
            }
            public int? checkedValue
            {
                get;
                set;
            }
            public Guid? sex
            {
                get;
                set;
            }
            public int? treatmentResult
            {
                get;
                set;
            }

            public Guid? FirstSelectErrorCode
            {
                get;
                set;
            }

            public string SecondSelectErrorCode
            {
                get;
                set;
            }
            public List<Guid> istisnaiHal
            {
                get;
                set;
            }
            public List<Guid> triaj
            {
                get;
                set;
            }

            public int? nabizStatus
            {
                get;
                set;
            }
            public Guid? BannedState
            {
                get;
                set;
            }
            public int? specialCase
            {
                get;
                set;
            }
            public int? SEPDescriptionState
            {
                get;
                set;
            }

            public string SEPDescription
            {
                get;
                set;
            }
            public List<string> controlStatus
            {
                get;
                set;
            }

            public List<Guid> procedureStateDef
            {
                get;
                set;
            }

            public int? admissionStatus
            {
                get;
                set;
            }

            public List<Guid> taburcuTipi
            {
                get;
                set;
            }
        }

    }
}