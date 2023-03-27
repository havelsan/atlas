
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
    /// İcmal Detayları
    /// </summary>
    public partial class InvoiceCollectionDetail : TTObject
    {
        public void CreatePayerInvoice(DateTime _invoiceDate, string _description)
        {
            if (InvoiceCollection != null && InvoiceCollection.InvoiceTerm == null)
                throw new TTException(TTUtils.CultureService.GetText("M25644", "Fatura oluşturulurken icmal in dönem bilgisi belirlenmiş olmalıdır."));

            InvoiceTerm it = InvoiceCollection.InvoiceTerm;

            if (it.StartDate > _invoiceDate || it.EndDate < _invoiceDate)
                throw new TTException(TTUtils.CultureService.GetText("M25657", "Fatura tarihi icmal için belirlenmiş dönem tarihleri arasında olmalıdır."));

            List<SubEpisodeProtocol> sepList = SubEpisodeProtocols.Where(x => x.InvoiceStatus == MedulaSubEpisodeStatusEnum.InsideInvoiceCollection).ToList();

            foreach (SubEpisodeProtocol sepControl in sepList)
            {
                sepControl.ControlInvoiceBlocking();

                if (SystemParameter.GetParameterValue("CONTROLSEPINVOICEINPATIENTSTATUS", "FALSE") == "TRUE" && sepControl.SubEpisode.InpatientStatus == InpatientStatusEnum.Predischarged)
                    throw new TTException("Ön taburcu statüsündeki hastanın faturası kesilemez. Lütfen yattığı birim ile iletişime geçiniz.");

            }

            //Aktif Yatış Kontrol İşlemi
            if (sepList.Count == 0)
                throw new TTException("En az bir adet SEP olmalı!");

            //Hasta faturası için bu kontroller yapılmamalı.
            if (InvoiceCollection.Payer.Type.PayerType != PayerTypeEnum.Paid)
            {
                foreach (InpatientAdmission trtClnc in sepList[0].Episode.InpatientAdmissions)
                {
                    if (trtClnc.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
                        throw new TTException(SystemMessage.GetMessage(513));
                }

                //if (this.IsTenDaysPastFromEpisodeOpeningDate() == false)
                //    throw new TTException("Ayaktan hastaya fatura kesilebilmesi için vaka açılış tarihinden itibaren 10 gün geçmesi gerekmektedir.");
            }

            Guid medulaInvoiceReferenceNumber = new Guid("15a270ae-3037-4f28-9aee-7dc671372c03");

            string faturaRefNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[medulaInvoiceReferenceNumber], null, null).ToString();

            PayerInvoiceDocument pid = new PayerInvoiceDocument(ObjectContext, _invoiceDate, string.Empty, faturaRefNo, _description, 0, InvoiceCollection.Payer);
            Currency invoiceTotalPrice = 0;

            bool invoicedExists = false;

            foreach (var sep in sepList)
            {
                if (sep != null)
                {
                    InvoiceLog.AddInfo("Fatura dökümanı kayıt edildi. ", sep.ObjectID, InvoiceOperationTypeEnum.Faturalandir, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
                    sep.MedulaSonucKodu = "";
                    sep.MedulaSonucMesaji = "";
                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.Invoiced;
                    sep.CurrentStateDefID = SubEpisodeProtocol.States.Closed;
                    List<AccountTransaction> acctxList = null;

                    if (InvoiceCollection.Payer.Type.PayerType != PayerTypeEnum.Paid)
                        acctxList = sep.AccountTransactions.Select("").Where(x => x.CurrentStateDefID == AccountTransaction.States.New && x.InvoiceInclusion == true).ToList();
                    else
                        acctxList = sep.AccountTransactions.Select("").Where(x => x.CurrentStateDefID == AccountTransaction.States.Paid && x.InvoiceInclusion == true).ToList();

                    sep.MedulaFaturaTutari = acctxList.Sum(s => s.Amount * s.UnitPrice);

                    invoiceTotalPrice += (sep.MedulaFaturaTutari.HasValue ? sep.MedulaFaturaTutari.Value : (Currency)0);
                    foreach (var acctx in acctxList)
                    {

                        #region fatura kayıt detayları grup ve detayları alıyor.
                        invoicedExists = true;
                        PayerInvoiceDocumentDetail invdd = new PayerInvoiceDocumentDetail(ObjectContext);
                        AccountTrxDocument accTrxDoc = new AccountTrxDocument(ObjectContext);

                        invdd.ExternalCode = acctx.ExternalCode;
                        invdd.Description = acctx.Description;
                        invdd.Amount = acctx.Amount;
                        invdd.UnitPrice = acctx.UnitPrice;
                        invdd.TotalDiscountPrice = 0;
                        invdd.TotalDiscountedPrice = acctx.Amount * acctx.UnitPrice;
                        //invdd.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Invoiced;

                        accTrxDoc.AccountDocumentDetail = invdd;
                        accTrxDoc.AccountTransaction = acctx;
                        accTrxDoc.AccountTransaction.TotalDiscountPrice = 0;
                        acctx.CurrentStateDefID = AccountTransaction.States.Invoiced;

                        string groupCode = string.Empty;
                        string groupDescription = string.Empty;
                        bool groupExists = false;
                        PayerInvoiceDocumentGroup procTempGroup = null;

                        if (acctx.PricingDetail != null && acctx.PricingDetail.PricingListGroup != null)
                        {
                            groupCode = acctx.PricingDetail.PricingListGroup.ExternalCode;
                            groupDescription = acctx.PricingDetail.PricingListGroup.Description;
                        }
                        else if (acctx.SubActionProcedure != null && acctx.SubActionProcedure.ProcedureObject != null && acctx.SubActionProcedure.ProcedureObject.ProcedureTree != null)
                        {
                            groupCode = acctx.SubActionProcedure.ProcedureObject.ProcedureTree.ExternalCode;
                            groupDescription = acctx.SubActionProcedure.ProcedureObject.ProcedureTree.Description;
                        }
                        else if (acctx.SubActionMaterial != null && acctx.SubActionMaterial.Material != null && acctx.SubActionMaterial.Material.MaterialTree != null)
                        {
                            groupCode = "-";
                            groupDescription = acctx.SubActionMaterial.Material.MaterialTree.Name;
                        }

                        if (string.IsNullOrEmpty(groupCode))
                            groupCode = "-";
                        if (string.IsNullOrEmpty(groupDescription))
                            groupDescription = "DİĞER";

                        foreach (PayerInvoiceDocumentGroup pg in pid.PayerInvoiceDocumentGroups)
                        {
                            if (pg.GroupCode == groupCode && pg.GroupDescription == groupDescription)
                            {
                                groupExists = true;
                                procTempGroup = pg;
                                break;
                            }
                        }

                        if (groupExists == false)
                        {
                            PayerInvoiceDocumentGroup invdg = new PayerInvoiceDocumentGroup(ObjectContext);
                            invdg.GroupCode = groupCode;
                            invdg.GroupDescription = groupDescription;
                            invdg.PayerInvoiceDocumentDetails.Add(invdd);
                            invdg.AccountDocument = pid;
                        }
                        else
                            procTempGroup.PayerInvoiceDocumentDetails.Add(invdd);

                        if (acctx.SubActionMaterial != null)
                            if (acctx.SubActionMaterial.Material is DrugDefinition || acctx.SubActionMaterial.Material is MagistralPreparationDefinition)
                            {
                                if (!pid.DrugTotal.HasValue)
                                    pid.DrugTotal = 0;

                                pid.DrugTotal += invdd.TotalDiscountedPrice;
                            }
                            else
                            {
                                if (!pid.MaterialTotal.HasValue)
                                    pid.MaterialTotal = 0;

                                pid.MaterialTotal += invdd.TotalDiscountedPrice;
                            }
                        #endregion
                    }
                }
            }
            if (!invoicedExists)
                throw new TTUtils.TTException(SystemMessage.GetMessage(216));

            pid.TotalPrice = invoiceTotalPrice;
            pid.GeneralTotalPrice = invoiceTotalPrice;

            //Hasta faturası için AprTrx oluşturulmaz.
            if (InvoiceCollection.Payer.Type.PayerType != PayerTypeEnum.Paid)
                pid.AddAPRTransaction((AccountPayableReceivable)pid.Payer.MyAPR(), (double)(-1 * pid.GeneralTotalPrice), (APRTrxType)APRTrxType.GetByType(ObjectContext, 4)[0]);

            PayerInvoiceDocument = pid;
            CurrentStateDefID = InvoiceCollectionDetail.States.Invoiced;

            pid.ControlAndGetInvoiceNumber();// Fatura numarasına burası karar verir alıyor.

            if (Episode.PatientStatus == PatientStatusEnum.Outpatient)
                pid.PatientStatus = OutPatientInPatientBothEnum.OutPatient;
            else
                pid.PatientStatus = OutPatientInPatientBothEnum.InPatient;

        }

        public bool IsTenDaysPastFromEpisodeOpeningDate()
        {
            if (Episode.PatientStatus == PatientStatusEnum.Outpatient)
            {
                int limit = 10;
                DateTime dateLimit = Convert.ToDateTime(Common.RecTime()).AddDays(-1 * (limit)).Date;
                if (Episode.OpeningDate.Value.Date >= dateLimit)
                    return false;
            }
            return true;
        }

        public Currency InvoicePrice
        {
            get
            {
                Currency invoicePrice = 0;

                foreach (SubEpisodeProtocol sep in SubEpisodeProtocols.Where(x => x.MedulaFaturaTutari.HasValue))
                    invoicePrice += sep.MedulaFaturaTutari.Value;

                return invoicePrice;
            }
        }

        public Currency InvoiceRestPrice
        {
            get
            {
                Currency invoiceRestPrice = InvoicePrice;

                if (Payment.HasValue)
                    invoiceRestPrice -= Payment.Value;

                if (Deduction.HasValue)
                    invoiceRestPrice -= Deduction.Value;

                if (invoiceRestPrice < 0)
                    throw new TTException("Faturanın kalan tutarı sıfırdan küçük olamaz kontrol ediniz. Hasta : " + Episode.Patient.FullName + " Protokol No : " + Episode.HospitalProtocolNo.Value.ToString() + " Fatura No : " + this?.PayerInvoiceDocument?.DocumentNo);

                return invoiceRestPrice;
            }
        }

        public void ChangeInvoiceCollection(InvoiceCollection newInvoiceCollection)
        {
            if (InvoiceCollection.InvoiceTerm.ObjectID != newInvoiceCollection.InvoiceTerm.ObjectID)
                throw new TTException(TTUtils.CultureService.GetText("M25543", "Dönemi aynı olmayan İcmaller arasında Taşıma veya Birleştirme İşlemi yapılamaz!"));

            if (InvoiceCollection.Payer.ObjectID != newInvoiceCollection.Payer.ObjectID)
                throw new TTException(TTUtils.CultureService.GetText("M26371", "Kurumu aynı olmayan İcmaller arasında Taşıma veya Birleştirme İşlemi yapılamaz!"));

            if (InvoiceCollection.CurrentStateDefID != InvoiceCollection.States.Open)
                throw new TTException("Açık durumunda olmayan İcmal içerisindeki detay(lar) taşınamaz veya birleştirilemez!");

            if (newInvoiceCollection.IsAutoGenerated == true || InvoiceCollection.IsAutoGenerated == true)
                throw new TTException(TTUtils.CultureService.GetText("M26644", "Otomatik oluşturulan İcmallerde Taşıma veya Birleştirme işlemi yapılamaz!"));

            if (newInvoiceCollection.CurrentStateDefID != InvoiceCollection.States.Open)
                throw new TTException("Açık durumunda olmayan İcmale detay taşınamaz veya başka bir icmal ile birleştirilemez!");

            if (newInvoiceCollection.TedaviTuru != null && InvoiceCollection.TedaviTuru != null && newInvoiceCollection.TedaviTuru.ObjectID != InvoiceCollection.TedaviTuru.ObjectID)
                throw new TTException(TTUtils.CultureService.GetText("M27082", "Tedavi türü aynı olmayan İcmaller arasında taşıma veya birleştirme işlemi yapılamaz!"));

            if (newInvoiceCollection.Capacity.HasValue && newInvoiceCollection.InvoiceCollectionDetails.Count(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled) >= newInvoiceCollection.Capacity)
                throw new TTException(TTUtils.CultureService.GetText("M27063", "Taşıma yapılan İcmalin Kapasitesi doldu!"));

            if (CurrentStateDefID == InvoiceCollectionDetail.States.PartialPaid || CurrentStateDefID == InvoiceCollectionDetail.States.Paid || CurrentStateDefID == InvoiceCollectionDetail.States.Cancelled)
                throw new TTException(TTUtils.CultureService.GetText("M27204", "Yalnızca Yeni veya Faturalanmış durumda olan detaylar için taşıma işlemi yapılabilir!"));

            InvoiceCollectionDetail newInvoiceCollectionDetail;

            if (CurrentStateDefID == InvoiceCollectionDetail.States.Invoiced)
            {
                SubEpisodeProtocol sep = SubEpisodeProtocols[0];
                PayerInvoiceDocument.Cancel();
                ObjectContext.Update();
                InvoiceCollection.RemoveInvoiceCollectionDetail(this, CancelledInvoiceTypeEnum.Moved);
                newInvoiceCollectionDetail = newInvoiceCollection.AddInvoiceCollectionDetail(sep);
                NewInvoiceCollectionDetail = newInvoiceCollectionDetail;
                ObjectContext.Update();
                newInvoiceCollectionDetail.CreatePayerInvoice(newInvoiceCollection.Date.Value, string.Empty);
            }
            else
            {
                SubEpisodeProtocol sep = SubEpisodeProtocols[0];
                InvoiceCollection.RemoveInvoiceCollectionDetail(this, CancelledInvoiceTypeEnum.Moved);
                newInvoiceCollectionDetail = newInvoiceCollection.AddInvoiceCollectionDetail(sep);
                NewInvoiceCollectionDetail = newInvoiceCollectionDetail;
            }
        }
    }
}