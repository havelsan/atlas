
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
    /// Vezne Tahsilat İşlemi
    /// </summary>
    public partial class MainCashOfficeOperationForm : TTForm
    {
        override protected void BindControlEvents()
        {
            //CashierLogsGrid.CellValueChanged += new TTGridCellEventDelegate(CashierLogsGrid_CellValueChanged);
            //GRIDCashPayment.CellValueChanged += new TTGridCellEventDelegate(GRIDCashPayment_CellValueChanged);
            //GRIDValuablePaper.CellValueChanged += new TTGridCellEventDelegate(GRIDValuablePaper_CellValueChanged);
            MONEYRECEIVEDTYPE.SelectedObjectChanged += new TTControlEventDelegate(MONEYRECEIVEDTYPE_SelectedObjectChanged);
            cbxPaymentType.SelectedIndexChanged += new TTControlEventDelegate(cbxPaymentTypeEnum_SelectedIndexChange);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //CashierLogsGrid.CellValueChanged -= new TTGridCellEventDelegate(CashierLogsGrid_CellValueChanged);
            //GRIDCashPayment.CellValueChanged -= new TTGridCellEventDelegate(GRIDCashPayment_CellValueChanged);
            //GRIDValuablePaper.CellValueChanged -= new TTGridCellEventDelegate(GRIDValuablePaper_CellValueChanged);
            MONEYRECEIVEDTYPE.SelectedObjectChanged -= new TTControlEventDelegate(MONEYRECEIVEDTYPE_SelectedObjectChanged);
            cbxPaymentType.SelectedIndexChanged -= new TTControlEventDelegate(cbxPaymentTypeEnum_SelectedIndexChange);
            base.UnBindControlEvents();
        }

        private void cbxPaymentTypeEnum_SelectedIndexChange()
        {
            if (_MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType == PaymentTypeEnum.Bank)
            {
                BANKACCOUNT.ReadOnly = false;
                BANKDECOUNTNO.ReadOnly = false;
                DOCUMENTDATE.ReadOnly = false;
                _MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = null;
            }
            else
            {
                BANKACCOUNT.ReadOnly = true;
                BANKDECOUNTNO.ReadOnly = true;
                DOCUMENTDATE.ReadOnly = true;
                _MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentDate = Common.RecTime();
                _MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.DecountNo = null;
                _MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.BankAccount = null;
                _MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
            }
        }
        /*private void CashierLogsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MainCashOfficeOperationForm_CashierLogsGrid_CellValueChanged
   if (columnIndex == 6 && rowIndex != -1)
            {
                if(CashierLogsGrid.Rows.Count != 0 && CashierLogsGrid.Rows[rowIndex].Cells[6].Value != null)
                {
                    CashierLog cl = null;
                    
                    this._MainCashOfficeOperation.TotalPrice = 0;
                    this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashPayment.DeleteChildren();
                    foreach(ITTGridRow row in CashierLogsGrid.Rows)
                    {
                        if(row.Cells["SUBMIT"].Value != null)
                        {
                            if((bool)row.Cells["SUBMIT"].Value)
                                this._MainCashOfficeOperation.TotalPrice = (double)this._MainCashOfficeOperation.TotalPrice + Convert.ToDouble(row.Cells["SUBMITTEDTOTAL"].Value);
                        }
                        if((bool)row.Cells["SUBMIT"].Value == true)
                        {
                            if(cl == null)
                                cl = (CashierLog)((SubmittedCashierLog)row.TTObject).CashierLog;
                        }
                    }
                    
                    if(this._MainCashOfficeOperation.TotalPrice != 0)
                    {
                        // Default olarak nakit ödeme tutarı ve  TL para birimi set ediliyor
                        Cash csh = new Cash(_MainCashOfficeOperation.ObjectContext);
                        csh.Price = this._MainCashOfficeOperation.TotalPrice;
                        
                        IList curTypeList  = CurrencyTypeDefinition.GetByQref(_MainCashOfficeOperation.ObjectContext,"TL");
                        if (curTypeList.Count != 0)
                        {
                            foreach (CurrencyTypeDefinition curType in curTypeList)
                            {
                                csh.CurrencyType = curType;
                                break ;
                            }
                        }
                        this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashPayment.Add(csh);
                    }
                    
                    if(cl == null)
                    {
                        this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeName = null;
                        this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeUniqueRefNo = null;
                    }
                    else
                    {
                        this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeName = cl.ResUser.Person.FullName;
                        this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeUniqueRefNo = cl.ResUser.Person.UniqueRefNo.ToString();
                    }
                }
            }
#endregion MainCashOfficeOperationForm_CashierLogsGrid_CellValueChanged
        }*/

        /*private void GRIDCashPayment_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MainCashOfficeOperationForm_GRIDCashPayment_CellValueChanged
   //             if (columnIndex == 0)
            //             {
            //                 double cashTotal = 0;
            //                 for (int i = 0; i < GRIDCashPayment.Rows.Count; i++)
            //                 {
            //                     cashTotal = cashTotal + Convert.ToDouble(GRIDCashPayment.Rows[i].Cells[columnIndex].Value);
            //                 }
            //                 _MainCashOfficeOperation.TotalPrice = cashTotal;
            //             }

            if (columnIndex == 0 || columnIndex == 1 && rowIndex != -1)
            {
                this._MainCashOfficeOperation.TotalPrice = this._MainCashOfficeOperation.CashOfficeReceiptDocument.GetTotalPayment();
            }
#endregion MainCashOfficeOperationForm_GRIDCashPayment_CellValueChanged
        }*/

        /*private void GRIDValuablePaper_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MainCashOfficeOperationForm_GRIDValuablePaper_CellValueChanged
   if (columnIndex == 0 && rowIndex != -1)
            {
                this._MainCashOfficeOperation.TotalPrice = this._MainCashOfficeOperation.CashOfficeReceiptDocument.GetTotalPayment();
            }
#endregion MainCashOfficeOperationForm_GRIDValuablePaper_CellValueChanged
        }*/
        private void MONEYRECEIVEDTYPE_SelectedObjectChanged()
        {
            #region MainCashOfficeOperationForm_MONEYRECEIVEDTYPE_SelectedObjectChanged
            MainCashOfficePaymentTypeDefinition _myPaymentType = null;
            _myPaymentType = (MainCashOfficePaymentTypeDefinition)this.MONEYRECEIVEDTYPE.SelectedObject;

            /*if (_myPaymentType.IsChattel == true)
            {
                _MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = null;
                this.RECEIPTNO.ReadOnly = false;
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashPayment.DeleteChildren();
                if (_myPaymentType.IsBankOperation == true)
                {
                    _MainCashOfficeOperation.PaymentType = PaymentTypeCashCCBankEnum.Bank;
                }
                else
                    _MainCashOfficeOperation.PaymentType = PaymentTypeCashCCBankEnum.Cash;

                //this.GRIDCashPayment.ReadOnly = true;
                //this.GRIDValuablePaper.ReadOnly = false;
            }*/
            //else
            //{
            if (selectedCashOffice == null)
                throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Diğer Tahsilatları yapmaya yetikiniz bulunmamaktadır!");


            //ReceiptCashOfficeDefinition _myReceiptCashOfficeDefinition;
            //IList myList = ReceiptCashOfficeDefinition.GetByCashOffice(_MainCashOfficeOperation.ObjectContext, selectedCashOffice.ObjectID.ToString());

            //_myReceiptCashOfficeDefinition = (ReceiptCashOfficeDefinition)_MainCashOfficeOperation.ObjectContext.QueryObjects("ReceiptCashOfficeDefinition", "CASHOFFICE = '" + selectedCashOffice.ObjectID + "'")[0];

            if (selectedRCODef != null)
                _MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);

            //_MainCashOfficeOperation.CashOfficeReceiptDocument.ValuablePaperPayments.DeleteChildren();
            //this.GRIDCashPayment.ReadOnly = false;
            //this.GRIDValuablePaper.ReadOnly = true;
            //}

            /*this._MainCashOfficeOperation.TotalPrice; this._MainCashOfficeOperation.CashOfficeReceiptDocument.GetTotalPayment();*/

            /*if (_myPaymentType.IsSubCashOfficePayment == true)
            {
                this._MainCashOfficeOperation.SubmittedCashierLogs.DeleteChildren();
                IList myLogList = CashierLog.GetClosedLogs(_MainCashOfficeOperation.ObjectContext);
                foreach (CashierLog myLog in myLogList)
                {
                    if (myLog.CashOfficeClosing.Count > 0)
                    {
                        // Bankaya Teslim edilmiş olan kasa kapamalar gride eklenmemeli
                        if (myLog.CashOfficeClosing[0].CashOfficeClosingDocument.BankAccount == null)
                        {
                            if (myLog.CashPaymentExists())
                            {
                                SubmittedCashierLog mySubmittedLog = new SubmittedCashierLog(_MainCashOfficeOperation.ObjectContext);
                                mySubmittedLog.CashierLog = myLog;
                                mySubmittedLog.Submit = false;
                                mySubmittedLog.SubmittedTotal = myLog.CashOfficeClosing[0].SubmittedTotal;
                                this._MainCashOfficeOperation.SubmittedCashierLogs.Add(mySubmittedLog);
                            }
                        }
                    }
                }

                this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashPayment.DeleteChildren();
                //this.GRIDCashPayment.ReadOnly = true;
                //this.GRIDValuablePaper.ReadOnly = true;
            }
            else
            {
                this._MainCashOfficeOperation.SubmittedCashierLogs.DeleteChildren();
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashPayment.DeleteChildren();
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeName = null;
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeUniqueRefNo = null;
            }*/

            if (_myPaymentType == null)
            {
                _MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType = PaymentTypeEnum.Cash;
                cbxPaymentType.ReadOnly = false;
                return;
            }

            if (_myPaymentType.IsBankOperation == true)
            {
                _MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType = PaymentTypeEnum.Bank;
                cbxPaymentType.ReadOnly = true;
            }
            else
            {
                _MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType = PaymentTypeEnum.Cash;
                cbxPaymentType.ReadOnly = false;
            }

            #endregion MainCashOfficeOperationForm_MONEYRECEIVEDTYPE_SelectedObjectChanged
        }
        CashOfficeDefinition selectedCashOffice;
        ReceiptCashOfficeDefinition selectedRCODef;
        protected override void ClientSidePreScript()
        {
            #region MainCashOfficeOperationForm_PreScript
            if (_MainCashOfficeOperation.CurrentStateDefID == MainCashOfficeOperation.States.New)
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);

                if (selectedCashOffice == null)
                    throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Diğer Tahsilatları yapmaya yetikiniz bulunmamaktadır!");

                selectedRCODef = new ReceiptCashOfficeDefinition();
                selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(_MainCashOfficeOperation.ObjectContext, selectedCashOffice.ObjectID);

                this.cmdOK.Visible = false;
                // this._MainCashOfficeOperation.TotalPrice = 0;
                _MainCashOfficeOperation.CashOfficeName = selectedCashOffice.Name;

                if (_MainCashOfficeOperation.CashOfficeReceiptDocument == null)
                {
                    _MainCashOfficeOperation.CashOfficeReceiptDocument = new CashOfficeReceiptDocument(_MainCashOfficeOperation.ObjectContext);
                    _MainCashOfficeOperation.CashOfficeReceiptDocument.ResUser = resUser;
                    _MainCashOfficeOperation.CashOfficeReceiptDocument.CashOffice = selectedCashOffice;
                    _MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentDate = Common.RecTime();
                    _MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType = PaymentTypeEnum.Cash;
                    _MainCashOfficeOperation.CashOfficeReceiptDocument.CurrentStateDefID = CashOfficeReceiptDocument.States.New;

                    //ReceiptCashOfficeDefinition _myReceiptCashOfficeDefinition;
                    //IList myList = ReceiptCashOfficeDefinition.GetByCashOffice(_MainCashOfficeOperation.ObjectContext, selectedCashOffice.ObjectID.ToString());

                    //_myReceiptCashOfficeDefinition = (ReceiptCashOfficeDefinition)_MainCashOfficeOperation.ObjectContext.QueryObjects("ReceiptCashOfficeDefinition", "CASHOFFICE = '" + selectedCashOffice.ObjectID + "'")[0];
                    _MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
                }
            }
            else
            {
                if (_MainCashOfficeOperation.CashOfficeReceiptDocument.MoneyReceivedType.IsBankOperation == true)
                {
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CashOfficeReceiptDocumentReport));
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_ChattelReceiptReport));
                }
                else if (_MainCashOfficeOperation.CashOfficeReceiptDocument.MoneyReceivedType.IsChattel == true)
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CashOfficeReceiptDocumentReport));
                else
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_ChattelReceiptReport));
            }
            #endregion MainCashOfficeOperationForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region MainCashOfficeOperationForm_PostScript
            if (_MainCashOfficeOperation.TotalPrice == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(187));
            else
                _MainCashOfficeOperation.CashOfficeReceiptDocument.TotalPrice = _MainCashOfficeOperation.TotalPrice;
            #endregion MainCashOfficeOperationForm_PostScript

        }

        #region MainCashOfficeOperationForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            // Raporlar dökülür
            if (transDef != null && transDef.ToStateDefID == MainCashOfficeOperation.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                cache.Add("VALUE", _MainCashOfficeOperation.ObjectID.ToString());
                parameters.Add("TTOBJECTID", cache);

                if (_MainCashOfficeOperation.CashOfficeReceiptDocument.MoneyReceivedType.IsChattel == true)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ChattelReceiptReport), true, 1, parameters);
                else
                {
                    if (_MainCashOfficeOperation.CashOfficeReceiptDocument.MoneyReceivedType.IsBankOperation != true)
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CashOfficeReceiptDocumentReport), true, 1, parameters);
                }
            }
        }

        #endregion MainCashOfficeOperationForm_Methods
    }
}