using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using static TTObjectClasses.SubEpisodeProtocol;

using Core.Services;
using TTUtils;
using TTDataDictionary;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers.Invoice
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class InvoicePaymentApiController : Controller
    {
        private readonly Core.Services.IInvoicePaymentService _paymentService;
        public InvoicePaymentApiController(Core.Services.IInvoicePaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tahsilat_Islemleri)]
        public InvoicePaymentSearchResultModel[] InvoicePaymentSearch(InvoicePaymentSearchModel ipsm)
        {
            InvoicePaymentSearchResultModel[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                StringBuilder sb = new StringBuilder();
                if (ipsm.Term != null && ipsm.Term.HasValue)
                    sb.AppendLine(" AND PIPDETAILS(ICD.INVOICECOLLECTION.INVOICETERM = '" + ipsm.Term.ToString() + "').EXISTS");
                if (ipsm.Payer != null && ipsm.Payer != Guid.Empty)
                    sb.AppendLine(" AND PAYER =  '" + ipsm.Payer + "'");
                if (ipsm.User != null && ipsm.User != Guid.Empty)
                    sb.AppendLine(" AND RESUSER =  '" + ipsm.User + "'");
                if (ipsm.BankAccount != null && ipsm.BankAccount != Guid.Empty)
                    sb.AppendLine(" AND BANKDECOUNT.BANKACCOUNT =  '" + ipsm.BankAccount + "'");
                if (!string.IsNullOrEmpty(ipsm.PatientUniqueRefNo))
                    sb.AppendLine(" AND PIPDETAILS(ICD.EPISODE.PATIENT.UNIQUEREFNO = '" + ipsm.PatientUniqueRefNo + "').EXISTS");
                if (!string.IsNullOrEmpty(ipsm.InvoiceNo))
                    sb.AppendLine(" AND PIPDETAILS(INVOICENO = '" + ipsm.InvoiceNo + "').EXISTS");
                if (!string.IsNullOrEmpty(ipsm.State))
                    sb.AppendLine(" AND CURRENTSTATE =  STATES." + ipsm.State);
                if (!string.IsNullOrEmpty(ipsm.DecountNo))
                    sb.AppendLine(" AND BANKDECOUNT.DECOUNTNO =" + ipsm.DecountNo);
                if (ipsm.FirstDecountDate != null)
                {
                    string icFirstDate = Convert.ToDateTime(ipsm.FirstDecountDate.Value.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    sb.AppendLine(" AND BANKDECOUNT.DECOUNTDATE >= TODATE('" + icFirstDate + "')");
                }

                if (ipsm.LastDecountDate != null)
                {
                    string icLastDate = Convert.ToDateTime(ipsm.LastDecountDate.Value.ToShortDateString() + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");
                    sb.AppendLine(" AND BANKDECOUNT.DECOUNTDATE <= TODATE('" + icLastDate + "')");
                }

                if (!string.IsNullOrEmpty(ipsm.FirstPrice))
                    sb.AppendLine(" AND TOTALPRICE >= " + ipsm.FirstPrice);
                if (!string.IsNullOrEmpty(ipsm.LastPrice))
                    sb.AppendLine(" AND TOTALPRICE <= " + ipsm.LastPrice);

                BindingList<PayerInvoicePayment.GetByInjection_Class> tempList = PayerInvoicePayment.GetByInjection(objectContext, sb.ToString());
                var query =
                    from tl in tempList
                    select new InvoicePaymentSearchResultModel { ObjectID = tl.ObjectID, Payer = tl.Payername, StateDisplayText = tl.Statedisplaytext.ToString(), DecountNo = tl.DecountNo, DecountDate = tl.DecountDate, TotalPrice = tl.TotalPrice.HasValue ? tl.TotalPrice.ToString() : string.Empty, Deduction = tl.Deduction.HasValue ? tl.Deduction.ToString() : string.Empty };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tahsilat_Islemleri)]
        public InvoiceCollectionSearchResultModel[] GetInvoiceCollectionFromPayer(GetInvoiceCollectionFromPayer_Input input)
        {
            InvoiceCollectionSearchResultModel[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                StringBuilder sb = new StringBuilder();
                if (input.payerObjectID.HasValue && input.payerObjectID.Value != Guid.Empty)
                {
                    PayerDefinition pd = objectContext.GetObject<PayerDefinition>(input.payerObjectID.Value);
                    if (pd.Type.PayerType == PayerTypeEnum.Paid || pd.Type.PayerType == PayerTypeEnum.UnPaid)
                        throw new TTException(TTUtils.CultureService.GetText("M27160", "Ücretli/Ücretsiz tipindeki kurumların tahsilatları yapılamaz."));
                }

                sb.AppendLine(" WHERE CURRENTSTATE in (STATES.PARTIALPAID,STATES.DELIVERED)");

                if (input.payerObjectID.HasValue && input.payerObjectID != Guid.Empty)
                    sb.AppendLine(" AND PAYER =  '" + input.payerObjectID.Value + "'");

                if (input.termObjectID.HasValue && input.termObjectID.Value != Guid.Empty)
                    sb.AppendLine(" AND INVOICETERM = '" + input.termObjectID.Value + "'");

                if (input.payerType.HasValue && input.payerType.Value != Guid.Empty)
                    sb.AppendLine(" AND PAYER.TYPE = '" + input.payerType.Value + "'");


                if (input.lastPaymentDate.HasValue)
                {
                    string icLastPaymentDate = Convert.ToDateTime(input.lastPaymentDate.Value.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    sb.AppendLine(" AND LASTPAYMENTDATE = TODATE('" + icLastPaymentDate + "')");
                }

                if (input.remainingPaymentTime.HasValue && input.lastPaymentDate.HasValue == false)
                {
                    string startDate = Convert.ToDateTime((DateTime.Now.ToShortDateString() + " 00:00:00")).ToString("yyyy-MM-dd HH:mm:ss");
                    string endDate = Convert.ToDateTime((DateTime.Now.AddDays(input.remainingPaymentTime.Value).ToShortDateString() + " 23:59:59")).ToString("yyyy-MM-dd HH:mm:ss");
                    sb.AppendLine(" AND LASTPAYMENTDATE BETWEEN TODATE('" + startDate + "') AND TODATE('" + endDate + "')");
                }

                BindingList<InvoiceCollection.GetInvoiceCollectionByInjection_Class> tempList = InvoiceCollection.GetInvoiceCollectionByInjection(objectContext, sb.ToString());
                if (tempList.Count == 0)
                    throw new TTException(TTUtils.CultureService.GetText("M26368", "Kuruma uygun tahsilat yapılabilecek herhangi bir kayıt bulunamadı."));
                var query =
                    from tl in tempList
                    select new InvoiceCollectionSearchResultModel { Date = tl.Date, InvoicePrice = tl.Invoiceprice != null ? tl.Invoiceprice.ToString() : string.Empty, Name = tl.Name, No = tl.No, ObjectID = tl.ObjectID, Payer = new listboxObject(null, tl.Payername, null), StateDisplayText = tl.Statedisplaytext.ToString(), InvoiceCount = Convert.ToInt32(tl.Invoicecount), TermName = tl.Invoicetermname, LastPaymentDate = tl.LastPaymentDate };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
                return result;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tahsilat_Islemleri)]
        public InvoicePaymentDetailModel[] GetInvoiceCollectionDetailFromIC([FromQuery] Guid? ICObjectID)
        {
            InvoicePaymentDetailModel[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                StringBuilder sb = new StringBuilder();
                if (ICObjectID.HasValue && ICObjectID != Guid.Empty)
                {
                    sb.AppendLine(" AND INVOICECOLLECTION = '" + ICObjectID.Value.ToString() + "'");
                    BindingList<InvoiceCollectionDetail.GetICDByInjection_Class> tempList = InvoiceCollectionDetail.GetICDByInjection(objectContext, sb.ToString());
                    var query =
                        from tl in tempList
                        select new InvoicePaymentDetailModel { ICDCurrentStateDefID = tl.CurrentStateDefID.Value, InvoiceCollectionDetailID = tl.ObjectID.Value, PatientName = tl.Name + ' ' + tl.Surname, UniqueRefNo = tl.UniqueRefNo.HasValue ? tl.UniqueRefNo.Value.ToString() : "", EpisodeID = tl.Episodeid.ToString(), InvoiceDate = tl.DocumentDate?.ToString("dd/MM/yyyy"), InvoiceNo = tl.DocumentNo, InvoicePrice = Currency.Parse(tl.Invoiceprice.ToString()), InvoiceRestPrice = (Currency.Parse(tl.Invoiceprice.ToString()) - Convert.ToDecimal(tl.Payment) - Convert.ToDecimal(tl.Deduction)), Payment = Convert.ToDecimal(tl.Payment), PayerObjectID = tl.Payerobjectid, PayerName = tl.Payername, StatusDisplayText = tl.Status.ToString(), Deduction = Convert.ToDecimal(tl.Deduction), TermName = tl.Termname, IsTermOpen = new Guid(tl.Termstate.ToString()) == InvoiceTerm.States.Closed ? false : true };
                    result = query.ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                    return result;
                }
                else
                    return new InvoicePaymentDetailModel[0];
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tahsilat_Islemleri)]
        public InvoicePaymentDetailModel[] GetFromUniqueID([FromQuery] string UniqueID)
        {
            InvoicePaymentDetailModel[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(UniqueID))
                {
                    sb.AppendLine(" AND EPISODE.PATIENT.UNIQUEREFNO = '" + UniqueID + "'");
                    BindingList<InvoiceCollectionDetail.GetICDByInjection_Class> tempList = InvoiceCollectionDetail.GetICDByInjection(objectContext, sb.ToString());
                    if (tempList.Count == 0)
                        throw new TTException("TC kimlik no'a uygun tahsilat yapılabilecek herhangi bir kayıt bulunamadı.");
                    var query =
                        from tl in tempList
                        select new InvoicePaymentDetailModel { ICDCurrentStateDefID = tl.CurrentStateDefID.Value, InvoiceCollectionDetailID = tl.ObjectID.Value, PatientName = tl.Name + ' ' + tl.Surname, UniqueRefNo = tl.UniqueRefNo.HasValue ? tl.UniqueRefNo.Value.ToString() : "", EpisodeID = tl.Episodeid.ToString(), InvoiceDate = tl.DocumentDate?.ToString("dd/MM/yyyy"), InvoiceNo = tl.DocumentNo, InvoicePrice = Currency.Parse(tl.Invoiceprice.ToString()), InvoiceRestPrice = (Currency.Parse(tl.Invoiceprice.ToString()) - Convert.ToDecimal(tl.Payment) - Convert.ToDecimal(tl.Deduction)), Payment = Convert.ToDecimal(tl.Payment), PayerObjectID = tl.Payerobjectid, PayerName = tl.Payername, StatusDisplayText = tl.Status.ToString(), Deduction = Convert.ToDecimal(tl.Deduction), TermName = tl.Termname, IsTermOpen = new Guid(tl.Termstate.ToString()) == InvoiceTerm.States.Closed ? false : true };
                    result = query.ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                    return result;
                }
                else
                    return new InvoicePaymentDetailModel[0];
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tahsilat_Islemleri)]
        public InvoicePaymentDetailModel[] GetFromInvoiceNo([FromQuery] string InvoiceNo)
        {
            InvoicePaymentDetailModel[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(InvoiceNo))
                {
                    sb.AppendLine(" AND PAYERINVOICEDOCUMENT.DOCUMENTNO = '" + InvoiceNo + "'");
                    BindingList<InvoiceCollectionDetail.GetICDByInjection_Class> tempList = InvoiceCollectionDetail.GetICDByInjection(objectContext, sb.ToString());
                    if (tempList.Count == 0)
                        throw new TTException(TTUtils.CultureService.GetText("M25642", "Fatura numarasına uygun tahsilat yapılabilecek herhangi bir kayıt bulunamadı."));
                    var query =
                        from tl in tempList
                        select new InvoicePaymentDetailModel { ICDCurrentStateDefID = tl.CurrentStateDefID.Value, InvoiceCollectionDetailID = tl.ObjectID.Value, PatientName = tl.Name + ' ' + tl.Surname, UniqueRefNo = tl.UniqueRefNo.HasValue ? tl.UniqueRefNo.Value.ToString() : "", EpisodeID = tl.Episodeid.ToString(), InvoiceDate = tl.DocumentDate?.ToString("dd/MM/yyyy"), InvoiceNo = tl.DocumentNo, InvoicePrice = Currency.Parse(tl.Invoiceprice.ToString()), InvoiceRestPrice = (Currency.Parse(tl.Invoiceprice.ToString()) - Convert.ToDecimal(tl.Payment) - Convert.ToDecimal(tl.Deduction)), Payment = Convert.ToDecimal(tl.Payment), PayerObjectID = tl.Payerobjectid, PayerName = tl.Payername, StatusDisplayText = tl.Status.ToString(), Deduction = Convert.ToDecimal(tl.Deduction), TermName = tl.Termname, IsTermOpen = new Guid(tl.Termstate.ToString()) == InvoiceTerm.States.Closed ? false : true };
                    result = query.ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                    return result;
                }
                else
                    return new InvoicePaymentDetailModel[0];
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tahsilat_Islemleri)]
        public Guid NewInvoicePayment(InvoicePaymentFormModel ipfm)
        {
            return _paymentService.NewInvoicePayment(ipfm);
        }

        public class CancelInvoicePaymentModel
        {
            public Guid PIPObjectId
            {
                get;
                set;
            }

            public string CancelDesc
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tahsilat_Islemleri)]
        public void CancelInvoicePayment(CancelInvoicePaymentModel cipm)
        {
            _paymentService.CancelInvoicePayment(cipm.PIPObjectId, cipm.CancelDesc);
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tahsilat_Islemleri)]
        public InvoicePaymentFormModel GetPayerInvoicePayment([FromQuery] Guid PIPObjectID)
        {
            InvoicePaymentFormModel ipfm = new InvoicePaymentFormModel();
            using (var objectContext = new TTObjectContext(true))
            {
                PayerInvoicePayment pip = objectContext.GetObject<PayerInvoicePayment>(PIPObjectID);
                ipfm.InvoicePayment.BankAccount = pip.BankDecount.BankAccount.ObjectID;
                ipfm.InvoicePayment.CreateDate = pip.CreateDate;
                ipfm.InvoicePayment.DecountDate = pip.BankDecount.DecountDate;
                ipfm.InvoicePayment.DecountNo = pip.BankDecount.DecountNo;
                ipfm.InvoicePayment.Deduction = pip.Deduction.HasValue ? Convert.ToDecimal(pip.Deduction.Value) : 0;
                ipfm.InvoicePayment.PIPObjectId = PIPObjectID;
                ipfm.InvoicePayment.PaymentPrice = pip.TotalPrice.HasValue ? Convert.ToDecimal(pip.TotalPrice.Value) : 0;
                ipfm.InvoicePayment.Description = pip.Description;
                ipfm.InvoicePayment.Username = pip.ResUser.Name;
                ipfm.InvoicePayment.Payer.ObjectID = pip.Payer.ObjectID;
                ipfm.InvoicePayment.Payer.Name = pip.Payer.Name;
                ipfm.InvoicePayment.Payer.Code = pip.Payer.Code.HasValue ? pip.Payer.Code.Value.ToString() : "";
                ipfm.InvoicePayment.CurrentStateDefID = pip.CurrentStateDefID.Value;
                ipfm.InvoicePayment.CancelDescription = pip.CurrentStateDefID == PayerInvoicePayment.States.Cancelled ? pip.CancelDescription : "";

                BindingList<PayerInvoicePaymentDetail.GetByPIPObjectId_Class> PIPDetails = PayerInvoicePaymentDetail.GetByPIPObjectId(objectContext, pip.ObjectID);
                foreach (PayerInvoicePaymentDetail.GetByPIPObjectId_Class PIPDetail in PIPDetails)
                {
                    InvoicePaymentDetailModel ipdm = new InvoicePaymentDetailModel();
                    ipdm.InvoiceCollectionDetailID = PIPDetail.ObjectID.Value;
                    ipdm.ICDCurrentStateDefID = PIPDetail.CurrentStateDefID.Value;
                    ipdm.EpisodeID = PIPDetail.Episodeid.Value.ToString();
                    ipdm.PatientName = PIPDetail.Name + ' ' + PIPDetail.Surname;
                    ipdm.UniqueRefNo = PIPDetail.UniqueRefNo.HasValue ? PIPDetail.UniqueRefNo.Value.ToString() : "";
                    ipdm.InvoiceDate = PIPDetail.InvoiceDate.Value.ToString("dd/MM/yyyy");
                    ipdm.InvoiceNo = PIPDetail.InvoiceNo;
                    ipdm.InvoicePrice = PIPDetail.InvoicePrice.HasValue ? Convert.ToDecimal(PIPDetail.InvoicePrice.Value) : 0;
                    ipdm.InvoiceRestPrice = PIPDetail.InvoiceRestPrice.HasValue ? Convert.ToDecimal(PIPDetail.InvoiceRestPrice.Value) : 0;
                    ipdm.Payment = PIPDetail.Payment.HasValue ? Convert.ToDecimal(PIPDetail.Payment.Value) : 0;
                    ipdm.Deduction = PIPDetail.Deduction.HasValue ? Convert.ToDecimal(PIPDetail.Deduction.Value) : 0;
                    ipfm.InvoicePaymentDetailList.Add(ipdm);
                }
            }

            return ipfm;
        }
    }
}