/*
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Muhasebe Yetkilisi Mutemetliği / Vezne / Fatura Servisi Kapama
    /// </summary>
    public partial class CashOfficeClosingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            SUBMITTEDTOTAL.TextChanged += new TTControlEventDelegate(SUBMITTEDTOTAL_TextChanged);
            PREVIEWREPORT.Click += new TTControlEventDelegate(PREVIEWREPORT_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SUBMITTEDTOTAL.TextChanged -= new TTControlEventDelegate(SUBMITTEDTOTAL_TextChanged);
            PREVIEWREPORT.Click -= new TTControlEventDelegate(PREVIEWREPORT_Click);
            base.UnBindControlEvents();
        }

        private void SUBMITTEDTOTAL_TextChanged()
        {
#region CashOfficeClosingForm_SUBMITTEDTOTAL_TextChanged
   if (this._CashOfficeClosing.SubmittedTotal > (this._CashOfficeClosing.Balance + this._CashOfficeClosing.CashRevenueTotal))
            {
                InfoBox.Show("Teslim Tutarı Vezne Toplam Tutarından fazla olamaz!",MessageIconEnum.InformationMessage);
                this._CashOfficeClosing.SubmittedTotal = null;
            }
            else
            {
                this._CashOfficeClosing.RemainingTotal = 0 ;
                double SubmittedPrice ;
                if (this._CashOfficeClosing.SubmittedTotal == null)
                    SubmittedPrice = 0;
                else
                    SubmittedPrice = (double)this._CashOfficeClosing.SubmittedTotal;
                
                this._CashOfficeClosing.RemainingTotal = (this._CashOfficeClosing.Balance + (this._CashOfficeClosing.CashRevenueTotal - this._CashOfficeClosing.TreatmentPriceBackTotal - this._CashOfficeClosing.OtherPriceBackTotal)) - (double)SubmittedPrice;
            }
            
            if (_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
            {
                if (this._CashOfficeClosing.SubmittedTotal == null || this._CashOfficeClosing.SubmittedTotal == 0)
                {
                    if (this._CashOfficeClosing.SubmittedTotal == null)
                        this._CashOfficeClosing.SubmittedTotal = 0;
                    
                    this._CashOfficeClosing.CashOfficeClosingDocument.BankAccount = null;
                    this._CashOfficeClosing.CashOfficeClosingDocument.DocumentNo = null;
                    this.BANKACCOUNT.ReadOnly = true;
                }
                else
                {
                    ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                    CashierLog  _myCashierLog = null;
                    if (_myResUser != null)
                        _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();

                    ReceiptCashOfficeDefinition _myReceiptCashOfficeDefinition;
                    IList myList = ReceiptCashOfficeDefinition.GetByCashOffice(_CashOfficeClosing.ObjectContext, _myCashierLog.CashOffice.ObjectID.ToString());
                    
                    if (myList.Count == 0)
                    {
                        throw new TTException("İşlem yapılan vezne (" + _CashOfficeClosing.CashierLog.CashOffice.Name + ") için Teslimat Müzekkeresi seri ve no bilgisi tanımlanmamış.");
                    }
                    else
                    {
                        _myReceiptCashOfficeDefinition = (ReceiptCashOfficeDefinition)_CashOfficeClosing.ObjectContext.QueryObjects("ReceiptCashOfficeDefinition", "CASHOFFICE = '" + _myCashierLog.CashOffice.ObjectID + "'" )[0];
//                        if((string)_myReceiptCashOfficeDefinition.GetCurrentBankDeliveryNumber() == "")
//                           throw new TTException("İşlem yapılan vezne (" + _CashOfficeClosing.CashierLog.CashOffice.Name + ") için Teslimat Müzekkeresi seri ve no bilgisi tanımlanmamış.");
//                        else
//                            _CashOfficeClosing.CashOfficeClosingDocument.DocumentNo = (string)_myReceiptCashOfficeDefinition.GetCurrentBankDeliveryNumber();
                    }
                    
                    this.BANKACCOUNT.ReadOnly = false;
                }
            }
#endregion CashOfficeClosingForm_SUBMITTEDTOTAL_TextChanged
        }

        private void PREVIEWREPORT_Click()
        {
#region CashOfficeClosingForm_PREVIEWREPORT_Click
   ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            CashierLog  _myCashierLog;
            _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
            
            if (_myCashierLog == null)
                throw new TTException("Açık Muhasebe Yetkilisi Mutemetliği, Vezne veya Fatura Servisi bulunamadı.");
            else
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> cashierLogGuid = new TTReportTool.PropertyCache<object>();
                cashierLogGuid.Add("VALUE", _myCashierLog.ObjectID.ToString());
                parameters.Add("CASHIERLOGGUID",cashierLogGuid);
                TTReportTool.PropertyCache<object> submittedTotal = new TTReportTool.PropertyCache<object>();
                submittedTotal.Add("VALUE", Convert.ToDouble(this.SUBMITTEDTOTAL.Text));
                parameters.Add("SUBMITTEDTOTAL",submittedTotal);
                TTReportTool.PropertyCache<object> remainingTotal = new TTReportTool.PropertyCache<object>();
                remainingTotal.Add("VALUE", Convert.ToDouble(this.REMAININGTOTAL.Text));
                parameters.Add("REMAININGTOTAL",remainingTotal);
                TTReportTool.PropertyCache<object> treatmentPriceBackTotal = new TTReportTool.PropertyCache<object>();
                treatmentPriceBackTotal.Add("VALUE", Convert.ToDouble(this.TREATMENTPRICEBACKTOTAL.Text));
                parameters.Add("TREATMENTPRICEBACKTOTAL",treatmentPriceBackTotal);
                TTReportTool.PropertyCache<object> otherPriceBackTotal = new TTReportTool.PropertyCache<object>();
                otherPriceBackTotal.Add("VALUE", Convert.ToDouble(this.OTHERPRICEBACKTOTAL.Text));
                parameters.Add("OTHERPRICEBACKTOTAL",otherPriceBackTotal);
                
                if(_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                {
                    TTReportTool.PropertyCache<object> balance = new TTReportTool.PropertyCache<object>();
                    balance.Add("VALUE", Convert.ToDouble(this.CASHOFFICEBALANCE.Text));
                    parameters.Add("BALANCE",balance);
                    
                    if(Convert.ToDouble(this.CASHREVENUETOTAL.Text) > 0 || _myCashierLog.CashPaymentExists())
                    {
                        TTReportTool.PropertyCache<object> cashOfficeCashAnnual = new TTReportTool.PropertyCache<object>();
                        cashOfficeCashAnnual.Add("VALUE", Convert.ToDouble(this.CASHOFFICECASHANNUAL.Text));
                        parameters.Add("CASHOFFICECASHANNUAL",cashOfficeCashAnnual);
                        TTReportTool.PropertyCache<object> cashRevenueTotal= new TTReportTool.PropertyCache<object>();
                        cashRevenueTotal.Add("VALUE", Convert.ToDouble(this.CASHREVENUETOTAL.Text));
                        parameters.Add("CASHREVENUETOTAL",cashRevenueTotal);
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PreSubCashOfficeClosingReport), true, 1, parameters);
                    }
                    if(Convert.ToDouble(this.CREDITCARDREVENUETOTAL.Text) > 0 || _myCashierLog.CreditCardPaymentExists())
                    {
                        TTReportTool.PropertyCache<object> cashOfficeCreditCardAnnual = new TTReportTool.PropertyCache<object>();
                        cashOfficeCreditCardAnnual.Add("VALUE", Convert.ToDouble(this.CASHOFFICECREDITCARDANNUAL.Text));
                        parameters.Add("CASHOFFICECREDITCARDANNUAL",cashOfficeCreditCardAnnual);
                        TTReportTool.PropertyCache<object> creditCardRevenueTotal= new TTReportTool.PropertyCache<object>();
                        creditCardRevenueTotal.Add("VALUE", Convert.ToDouble(this.CREDITCARDREVENUETOTAL.Text));
                        parameters.Add("CREDITCARDREVENUETOTAL",creditCardRevenueTotal);
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PreSubCashOfficeClosingCreditCardReport), true, 1, parameters);
                    }
                }
                
                if(_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                {
                    
                    TTReportTool.PropertyCache<object> cashOfficeCashAnnual = new TTReportTool.PropertyCache<object>();
                    cashOfficeCashAnnual.Add("VALUE", Convert.ToDouble(this.CASHOFFICECASHANNUAL.Text));
                    parameters.Add("CASHOFFICECASHANNUAL",cashOfficeCashAnnual);
                    TTReportTool.PropertyCache<object> revenueTotal = new TTReportTool.PropertyCache<object>();
                    revenueTotal.Add("VALUE", Convert.ToDouble(this.GENERALREVENUETOTAL.Text));
                    parameters.Add("REVENUETOTAL",revenueTotal);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PreMainCashOfficeClosingReport), true, 1, parameters);
                }
            }
#endregion CashOfficeClosingForm_PREVIEWREPORT_Click
        }

        protected override void PreScript()
        {
#region CashOfficeClosingForm_PreScript
    this.cmdOK.Visible = false;
            
            CashierLog  _myCashierLog;
            ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            
            _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();

            if (_CashOfficeClosing.CurrentStateDefID == CashOfficeClosing.States.New)
            {
                if (_myCashierLog == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(129));
                else
                {
                    _CashOfficeClosing.CashierLog = _myCashierLog;
                    
                    if(_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice || _CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.InvoicingService)
                        _CashOfficeClosing.Balance = 0;
                    else if (_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                    {
                        IList userBalanceList = AccountPayableReceivable.GetAPRByResUser(_CashOfficeClosing.ObjectContext,_myResUser.ObjectID.ToString());
                        if (userBalanceList.Count == 0)
                            _CashOfficeClosing.Balance = 0;
                        else
                        {
                            foreach (AccountPayableReceivable apr in userBalanceList)
                            {
                                _CashOfficeClosing.Balance = apr.Balance; // Sadece Vezneler için Balans devreye girecek
                            }
                        }
                    }
                    
                    if (_CashOfficeClosing.CashOfficeClosingDocument == null)
                    {
                        _CashOfficeClosing.CashOfficeClosingDocument = new CashOfficeClosingDocument(_CashOfficeClosing.ObjectContext);
                        _CashOfficeClosing.CashOfficeClosingDocument.CashierLog = _myCashierLog;
                        _CashOfficeClosing.CashOfficeClosingDocument.DocumentDate = DateTime.Now.Date;
                        _CashOfficeClosing.CashOfficeClosingDocument.TotalPrice = 0 ;
                        _CashOfficeClosing.CashOfficeClosingDocument.CurrentStateDefID = CashOfficeClosingDocument.States.New;
                        
                        //CashOfficeDefinition cashOfficeDef = (CashOfficeDefinition)_CashOfficeClosing.ObjectContext.GetObject(_myCashierLog.CashOffice.ObjectID,"CashOfficeDefinition");
                        _CashOfficeClosing.CashOfficeClosingDocument.BankAccount = _CashOfficeClosing.CashierLog.CashOffice.BankAccount;
                    }
                    this._CashOfficeClosing.TreatmentPriceBackTotal = 0;
                    this._CashOfficeClosing.OtherPriceBackTotal = 0;
                    //this._CashOfficeClosing.SubmittedTotal = 0;
                    
                    this._CashOfficeClosing.RevenueTotal = 0;
                    this._CashOfficeClosing.CashRevenueTotal = 0;
                    this._CashOfficeClosing.CreditCardRevenueTotal = 0;
                    this._CashOfficeClosing.CashOfficeCashAnnual = 0 ;
                    this._CashOfficeClosing.CashOfficeCreditCardAnnual = 0;
                    string year = TTObjectClasses.Common.RecTime().Year.ToString();
                    string startDate = year + "-01-01 00:00:00";
                    string endDate = TTObjectClasses.Common.RecTime().ToString("yyyy-MM-dd 23:59:59");
                    string cashOffice = _CashOfficeClosing.CashierLog.CashOffice.ObjectID.ToString();
                    
                    foreach (AccountDocument accDoc in _CashOfficeClosing.GetBackTypeDocsForCashOffice( _CashOfficeClosing.CashierLog.ObjectID.ToString()))
                    {
                        if(accDoc is MainCashOfficeBackDocument)
                        {
                            MainCashOfficeBackDocument mainCashOfficeBackDocument = (MainCashOfficeBackDocument)accDoc;
                            if(mainCashOfficeBackDocument.BackBankAccount == null && mainCashOfficeBackDocument.CurrentStateDefID == MainCashOfficeBackDocument.States.Paid)
                                this._CashOfficeClosing.OtherPriceBackTotal = this._CashOfficeClosing.OtherPriceBackTotal + (double)mainCashOfficeBackDocument.TotalPrice;
                        }
                        else if(accDoc is ReceiptBackDocument)
                        {
                            ReceiptBackDocument receiptBackDocument = (ReceiptBackDocument)accDoc;
                            if(receiptBackDocument.BackBankAccount == null && receiptBackDocument.CurrentStateDefID == ReceiptBackDocument.States.Paid)
                                this._CashOfficeClosing.TreatmentPriceBackTotal = this._CashOfficeClosing.TreatmentPriceBackTotal + (double)receiptBackDocument.TotalPrice ;
                        }
                        else if(accDoc is AdvanceBackDocument)
                        {
                            AdvanceBackDocument advanceBackDocument = (AdvanceBackDocument)accDoc;
                            if(advanceBackDocument.BackBankAccount == null && advanceBackDocument.CurrentStateDefID == AdvanceBackDocument.States.Paid)
                                this._CashOfficeClosing.TreatmentPriceBackTotal = this._CashOfficeClosing.TreatmentPriceBackTotal + (double)advanceBackDocument.TotalPrice ;

                        }
                    }
                    
                    foreach (CashOfficeClosing cc in _CashOfficeClosing.GetAnnualCashOfficeClosings(Convert.ToDateTime(startDate),Convert.ToDateTime(endDate),cashOffice))
                    {
                        this._CashOfficeClosing.CashOfficeCashAnnual = this._CashOfficeClosing.CashOfficeCashAnnual + (double)cc.CashRevenueTotal ;
                        this._CashOfficeClosing.CashOfficeCreditCardAnnual = this._CashOfficeClosing.CashOfficeCreditCardAnnual + (double)cc.CreditCardRevenueTotal;
                    }

                    foreach (AccountDocument accDoc in _CashOfficeClosing.GetAccountDocumentsForCashOffice( _CashOfficeClosing.CashierLog.ObjectID.ToString(),(CashOfficeTypeEnum) _CashOfficeClosing.CashierLog.CashOffice.Type))
                    {
                        if(accDoc is ReceiptDocument)
                        {
                            ReceiptDocument receiptDocument = (ReceiptDocument)accDoc;
                            if(receiptDocument.CurrentStateDefID == ReceiptDocument.States.Paid)
                            {
                                this._CashOfficeClosing.CashRevenueTotal = this._CashOfficeClosing.CashRevenueTotal + (double)receiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(receiptDocument.DocumentDate));
                                this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)receiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(receiptDocument.DocumentDate));

                                foreach (CreditCard myCreditCard in receiptDocument.CreditCardPayments)
                                {
                                    this._CashOfficeClosing.CreditCardRevenueTotal = this._CashOfficeClosing.CreditCardRevenueTotal + (double)myCreditCard.Price ;
                                    this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)myCreditCard.Price ;
                                }
                            }
                        }
                        
                        else if(accDoc is AdvanceDocument)
                        {
                            AdvanceDocument advanceDocument = (AdvanceDocument)accDoc;
                            if(advanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid)
                            {
                                this._CashOfficeClosing.CashRevenueTotal = this._CashOfficeClosing.CashRevenueTotal + (double)advanceDocument.GetCalculatedCashPayment(Convert.ToDateTime(advanceDocument.DocumentDate));
                                this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)advanceDocument.GetCalculatedCashPayment(Convert.ToDateTime(advanceDocument.DocumentDate));

                                foreach (CreditCard myCreditCard in advanceDocument.CreditCardPayments)
                                {
                                    this._CashOfficeClosing.CreditCardRevenueTotal = this._CashOfficeClosing.CreditCardRevenueTotal + (double)myCreditCard.Price ;
                                    this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)myCreditCard.Price ;
                                }
                            }
                        }
                        
                        else if(accDoc is DebenturePaymentDocument)
                        {
                            DebenturePaymentDocument debenturePaymentDocument = (DebenturePaymentDocument)accDoc;
                            if(debenturePaymentDocument.CurrentStateDefID == DebenturePaymentDocument.States.Paid)
                            {
                                this._CashOfficeClosing.CashRevenueTotal = this._CashOfficeClosing.CashRevenueTotal + (double)debenturePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(debenturePaymentDocument.DocumentDate));
                                this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)debenturePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(debenturePaymentDocument.DocumentDate));

                                foreach (CreditCard myCreditCard in debenturePaymentDocument.CreditCardPayments)
                                {
                                    this._CashOfficeClosing.CreditCardRevenueTotal = this._CashOfficeClosing.CreditCardRevenueTotal + (double)myCreditCard.Price ;
                                    this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)myCreditCard.Price ;
                                }
                            }
                        }
                        
                        else if(accDoc is CashOfficeReceiptDocument)
                        {
                            CashOfficeReceiptDocument cashOfficeReceiptDocument = (CashOfficeReceiptDocument)accDoc;
                            if(cashOfficeReceiptDocument.CurrentStateDefID == CashOfficeReceiptDocument.States.Paid)
                            {
                                this._CashOfficeClosing.CashRevenueTotal = this._CashOfficeClosing.CashRevenueTotal + (double)cashOfficeReceiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(cashOfficeReceiptDocument.DocumentDate));
                                this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)cashOfficeReceiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(cashOfficeReceiptDocument.DocumentDate));
                                
                                foreach (CreditCard myCreditCard in cashOfficeReceiptDocument.CreditCardPayments)
                                {
                                    this._CashOfficeClosing.CreditCardRevenueTotal = this._CashOfficeClosing.CreditCardRevenueTotal + (double)myCreditCard.Price ;
                                    this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)myCreditCard.Price ;
                                }
                            }
                        }
                        
                        else if(accDoc is PayerPaymentDocument)
                        {
                            PayerPaymentDocument payerPaymentDocument = (PayerPaymentDocument)accDoc;
                            if(payerPaymentDocument.CurrentStateDefID == PayerPaymentDocument.States.Paid)
                            {
                                this._CashOfficeClosing.CashRevenueTotal = this._CashOfficeClosing.CashRevenueTotal + (double)payerPaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(payerPaymentDocument.DocumentDate));
                                this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)payerPaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(payerPaymentDocument.DocumentDate));

                                foreach (CreditCard myCreditCard in payerPaymentDocument.CreditCardPayments)
                                {
                                    this._CashOfficeClosing.CreditCardRevenueTotal = this._CashOfficeClosing.CreditCardRevenueTotal + (double)myCreditCard.Price ;
                                    this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)myCreditCard.Price ;
                                }
                            }
                        }
                        
                        else if(accDoc is PayerAdvancePaymentDocument)
                        {
                            PayerAdvancePaymentDocument payerAdvancePaymentDocument = (PayerAdvancePaymentDocument)accDoc;
                            if(payerAdvancePaymentDocument.CurrentStateDefID == PayerAdvancePaymentDocument.States.Paid)
                            {
                                this._CashOfficeClosing.CashRevenueTotal = this._CashOfficeClosing.CashRevenueTotal + (double)payerAdvancePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(payerAdvancePaymentDocument.DocumentDate));
                                this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)payerAdvancePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(payerAdvancePaymentDocument.DocumentDate));

                                foreach (CreditCard myCreditCard in payerAdvancePaymentDocument.CreditCardPayments)
                                {
                                    this._CashOfficeClosing.CreditCardRevenueTotal = this._CashOfficeClosing.CreditCardRevenueTotal + (double)myCreditCard.Price ;
                                    this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)myCreditCard.Price ;
                                }
                            }
                        }
                        else if(accDoc is SubCashOfficeReceiptDoc)
                        {
                            SubCashOfficeReceiptDoc subCashOfficeReceiptDoc = (SubCashOfficeReceiptDoc)accDoc;
                            if(subCashOfficeReceiptDoc.CurrentStateDefID == SubCashOfficeReceiptDoc.States.Paid)
                            {
                                this._CashOfficeClosing.CashRevenueTotal = this._CashOfficeClosing.CashRevenueTotal + (double)subCashOfficeReceiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(subCashOfficeReceiptDoc.DocumentDate));
                                this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)subCashOfficeReceiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(subCashOfficeReceiptDoc.DocumentDate));

                                foreach (CreditCard myCreditCard in subCashOfficeReceiptDoc.CreditCardPayments)
                                {
                                    this._CashOfficeClosing.CreditCardRevenueTotal = this._CashOfficeClosing.CreditCardRevenueTotal + (double)myCreditCard.Price ;
                                    this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)myCreditCard.Price ;
                                }
                            }
                        }
                        else if(accDoc is GeneralReceiptDocument)
                        {
                            GeneralReceiptDocument generalReceiptDocument = (GeneralReceiptDocument)accDoc;
                            if(generalReceiptDocument.CurrentStateDefID == GeneralReceiptDocument.States.Paid)
                            {
                                this._CashOfficeClosing.CashRevenueTotal = this._CashOfficeClosing.CashRevenueTotal + (double)generalReceiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(generalReceiptDocument.DocumentDate));
                                this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)generalReceiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(generalReceiptDocument.DocumentDate));
                                
                                foreach(CreditCard myCreditCard in generalReceiptDocument.CreditCardPayments)
                                {
                                    this._CashOfficeClosing.CreditCardRevenueTotal = this._CashOfficeClosing.CreditCardRevenueTotal + (double)myCreditCard.Price ;
                                    this._CashOfficeClosing.RevenueTotal = this._CashOfficeClosing.RevenueTotal + (double)myCreditCard.Price ;
                                }
                            }
                        }
                    }
                    //this._CashOfficeClosing.RemainingTotal = this._CashOfficeClosing.Balance + this._CashOfficeClosing.RevenueTotal;
                    //this._CashOfficeClosing.SubmittedTotal = this._CashOfficeClosing.Balance + this._CashOfficeClosing.CashRevenueTotal - this._CashOfficeClosing.TreatmentPriceBackTotal - this._CashOfficeClosing.OtherPriceBackTotal;
                    this._CashOfficeClosing.SubmittedTotal = this._CashOfficeClosing.Balance + this._CashOfficeClosing.CashRevenueTotal - this._CashOfficeClosing.TreatmentPriceBackTotal - this._CashOfficeClosing.OtherPriceBackTotal;
                    this._CashOfficeClosing.RemainingTotal = 0;
                }
            }
            else
            {
                this.PREVIEWREPORT.Visible = false;
                
                if(_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                {
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_MainCashOfficeClosingReport));
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_MainCashOfficeClosingBankDeliveryReport));
                    
                    if(_CashOfficeClosing.CashRevenueTotal == 0 && _CashOfficeClosing.CashierLog.CashPaymentExists() == false)
                        this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeClosingReport));
                    
                    if (_CashOfficeClosing.CreditCardRevenueTotal == 0 && _CashOfficeClosing.CashierLog.CreditCardPaymentExists() == false)
                        this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeClosingCreditCardReport));
                }
                else if (_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                {
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeClosingReport));
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeClosingCreditCardReport));
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeRevenueReport));
                    
                    if (_CashOfficeClosing.SubmittedTotal == null || _CashOfficeClosing.SubmittedTotal == 0)
                        this.DropCurrentStateReport(typeof(TTReportClasses.I_MainCashOfficeClosingBankDeliveryReport));
                }
                else if(_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.InvoicingService)
                {
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeClosingReport));
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeClosingCreditCardReport));
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeRevenueReport));
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_MainCashOfficeClosingReport));
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_MainCashOfficeClosingBankDeliveryReport));
                    this.PREVIEWREPORT.Visible = false;
                }
            }
            
            if(_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
            {
                this.Text = "Muhasebe Yetkilisi Mutemetliği Kapama (" + this._CashOfficeClosing.CurrentStateDef.DisplayText + ")";
                this.KodLabel.Text = "Muh.Yetkilisi Mutemetliği Kodu";
                this.AdLabel.Text = "Muh.Yetkilisi Mutemetliği Adı";
                
                this.SUBMITTEDTOTAL.ReadOnly = true;
                
                this.RECEIPTNO.Visible = false;
                this.ttlabel15.Visible = false;
                
                this.SPECIALNO.Visible = false;
                this.ttlabel16.Visible = false;
                
                this.ttlabel6.Location = new Point(this.ttlabel6.Location.X, this.ttlabel6.Location.Y - 30);
                this.BANKACCOUNT.Location = new Point(this.BANKACCOUNT.Location.X, this.BANKACCOUNT.Location.Y - 30);
                
                this.BANKDELIVERY.Text = "Banka Teslimat Bilgisi";
                this.BANKDELIVERY.Size = new Size(318,60);
                
                this.ttlabel11.Location = new Point(this.ttlabel11.Location.X, this.ttlabel11.Location.Y - 30);
                this.REMAININGTOTAL.Location = new Point(this.REMAININGTOTAL.Location.X, this.REMAININGTOTAL.Location.Y - 30);
                this.ttlabel13.Location = new Point(this.ttlabel13.Location.X, this.ttlabel13.Location.Y - 30);
                this.CASHOFFICECASHANNUAL.Location = new Point(this.CASHOFFICECASHANNUAL.Location.X, this.CASHOFFICECASHANNUAL.Location.Y - 30);
                this.ttlabel14.Location = new Point(this.ttlabel14.Location.X, this.ttlabel14.Location.Y - 30);
                this.CASHOFFICECREDITCARDANNUAL.Location = new Point(this.CASHOFFICECREDITCARDANNUAL.Location.X, this.CASHOFFICECREDITCARDANNUAL.Location.Y - 30);
                this.Height = 640;
            }
            else if (_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
            {
                this.Text = "Vezne Kapama (" + this._CashOfficeClosing.CurrentStateDef.DisplayText + ")";
                this.KodLabel.Text = "Vezne Kodu";
                this.AdLabel.Text = "Vezne Adı";
                
                if (_CashOfficeClosing.CurrentStateDefID == CashOfficeClosing.States.New)
                    this.SUBMITTEDTOTAL.ReadOnly = false;
                
                if (this._CashOfficeClosing.SubmittedTotal == null || this._CashOfficeClosing.SubmittedTotal == 0)
                {
                    this._CashOfficeClosing.CashOfficeClosingDocument.BankAccount = null;
                    this.BANKACCOUNT.ReadOnly = true;
                }
                else
                {
                    if (_CashOfficeClosing.CurrentStateDefID == CashOfficeClosing.States.New)
                        this.BANKACCOUNT.ReadOnly = false;
                }
                 
                if (_CashOfficeClosing.CurrentStateDefID == CashOfficeClosing.States.New)
                {
                    ReceiptCashOfficeDefinition _myReceiptCashOfficeDefinition;
                    IList myList = ReceiptCashOfficeDefinition.GetByCashOffice(_CashOfficeClosing.ObjectContext, _myCashierLog.CashOffice.ObjectID.ToString());
                    
                    if (myList.Count == 0)
                    {
                        throw new TTException("İşlem yapılan vezne (" + _CashOfficeClosing.CashierLog.CashOffice.Name + ") için Teslimat Müzekkeresi seri ve no bilgisi tanımlanmamış.");
                    }
                    else
                    {
                        _myReceiptCashOfficeDefinition = (ReceiptCashOfficeDefinition)_CashOfficeClosing.ObjectContext.QueryObjects("ReceiptCashOfficeDefinition", "CASHOFFICE = '" + _myCashierLog.CashOffice.ObjectID + "'" )[0];
//                        if((string)_myReceiptCashOfficeDefinition.GetCurrentBankDeliveryNumber() == "")
//                            throw new TTException("İşlem yapılan vezne (" + _CashOfficeClosing.CashierLog.CashOffice.Name + ") için Teslimat Müzekkeresi seri ve no bilgisi tanımlanmamış.");
//                        else
//                            _CashOfficeClosing.CashOfficeClosingDocument.DocumentNo = (string)_myReceiptCashOfficeDefinition.GetCurrentBankDeliveryNumber();
                    }
                }
            }
            else if(_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.InvoicingService)
            {
                this.TREATMENTPRICEBACKTOTAL.Visible = false ;
                this.TREATMENTPRICEBACKTOTALLABEL.Visible = false ;
                this.Text = "Fatura Servisi Kapama (" + this._CashOfficeClosing.CurrentStateDef.DisplayText + ")";
                this.KodLabel.Text = "Fatura Servisi Kodu";
                this.AdLabel.Text = "Fatura Servisi Adı";
                this.Height = 240;
                this.ttlabel7.Visible = false;
                this.CASHOFFICEBALANCE.Visible = false;
                this.ttgroupbox1.Visible = false ;
                this.ttlabel10.Visible = false;
                this.CASHREVENUETOTAL.Visible = false;
                this.ttlabel12.Visible = false;
                this.CREDITCARDREVENUETOTAL.Visible = false;
                this.ttlabel8.Visible = false;
                this.GENERALREVENUETOTAL.Visible = false;
                this.ttlabel9.Visible = false;
                this.SUBMITTEDTOTAL.Visible = false;
                this.ttlabel11.Visible = false;
                this.REMAININGTOTAL.Visible = false;
                this.ttlabel13.Visible = false;
                this.CASHOFFICECASHANNUAL.Visible = false;
                this.CASHOFFICECREDITCARDANNUAL.Visible = false;
                this.ttlabel14.Visible = false;
                this.OTHERPRICEBACKTOTAL.Visible = false;
                this.ttlabel1.Visible = false;
                this.BANKACCOUNT.Visible = false;
                this.ttlabel6.Visible = false;
                this.RECEIPTNO.Visible = false;
                this.ttlabel15.Visible = false;
                this.SPECIALNO.Visible = false;
                this.ttlabel16.Visible = false;
                this.BANKDELIVERY.Visible = false;
            }
#endregion CashOfficeClosingForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CashOfficeClosingForm_PostScript
    if (_CashOfficeClosing.CashierLog.ClosingDate < _CashOfficeClosing.CashierLog.OpeningDate)
                throw new TTUtils.TTException(SystemMessage.GetMessage(131));
#endregion CashOfficeClosingForm_PostScript

            }
            
#region CashOfficeClosingForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            
            if(transDef != null && transDef.ToStateDefID == CashOfficeClosing.States.Completed)
            {
                if (_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _CashOfficeClosing.ObjectID.ToString());
                    
                    parameters.Add("TTOBJECTID",cache);
                    if (this._CashOfficeClosing.CashRevenueTotal > 0 || _CashOfficeClosing.CashierLog.CashPaymentExists())
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SubCashOfficeClosingReport), true, 1, parameters);
                    
                    if (this._CashOfficeClosing.CreditCardRevenueTotal > 0 || _CashOfficeClosing.CashierLog.CreditCardPaymentExists())
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SubCashOfficeClosingCreditCardReport), true, 1, parameters);
                }
                if (_CashOfficeClosing.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _CashOfficeClosing.ObjectID.ToString());
                    
                    parameters.Add("TTOBJECTID",cache);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MainCashOfficeClosingReport), true, 1, parameters);
                    
                    
                    //if (_CashOfficeClosing.SubmittedTotal != null)
                    //{
                    //    if (_CashOfficeClosing.SubmittedTotal > 0)
                    //        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MainCashOfficeClosingBankDeliveryReport), true, 1, parameters);
                    //}
                    
                }
            }
        }
        
#endregion CashOfficeClosingForm_Methods
    }
}*/