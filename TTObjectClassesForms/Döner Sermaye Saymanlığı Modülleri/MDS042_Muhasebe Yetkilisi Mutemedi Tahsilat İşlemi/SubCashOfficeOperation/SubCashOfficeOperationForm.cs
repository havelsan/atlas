
//using System;
//using System.Xml;
//using System.Data;
//using System.Text;
//using System.Drawing;
//using System.Reflection;
//using System.Collections;
//using System.Linq;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.Collections.ObjectModel;
//using System.Runtime.InteropServices;

//using TTUtils;
//using TTObjectClasses;
//using TTDataDictionary;
//using TTCoreDefinitions;
//using TTConnectionManager;
//using TTInstanceManagement;
//using TTDefinitionManagement;
//using TTStorageManager.Security;

//using SmartCardWrapper;

//using TTStorageManager;
//using System.Runtime.Versioning;
//using System.Windows.Forms;
//using TTVisual;
//namespace TTFormClasses
//{
//    /// <summary>
//    /// Muhasebe Yetkilisi Mutemedi Tahsilat İşlemi
//    /// </summary>
//    public partial class SubCashOfficeOperationForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            GRIDCashs.CellValueChanged += new TTGridCellEventDelegate(GRIDCashs_CellValueChanged);
//            GRIDCreditCards.CellValueChanged += new TTGridCellEventDelegate(GRIDCreditCards_CellValueChanged);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            GRIDCashs.CellValueChanged -= new TTGridCellEventDelegate(GRIDCashs_CellValueChanged);
//            GRIDCreditCards.CellValueChanged -= new TTGridCellEventDelegate(GRIDCreditCards_CellValueChanged);
//            base.UnBindControlEvents();
//        }

//        private void GRIDCashs_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region SubCashOfficeOperationForm_GRIDCashs_CellValueChanged
//   if (columnIndex == 0 || columnIndex == 1 && rowIndex != -1)
//            {
//                this._SubCashOfficeOperation.TotalPrice = this._SubCashOfficeOperation.SubCashOfficeReceiptDocument.GetTotalPayment();
//            }
//#endregion SubCashOfficeOperationForm_GRIDCashs_CellValueChanged
//        }

//        private void GRIDCreditCards_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region SubCashOfficeOperationForm_GRIDCreditCards_CellValueChanged
//   if (columnIndex == 6)
//            {
//                this._SubCashOfficeOperation.TotalPrice = this._SubCashOfficeOperation.SubCashOfficeReceiptDocument.GetTotalPayment();
//            }
//#endregion SubCashOfficeOperationForm_GRIDCreditCards_CellValueChanged
//        }

//        protected override void PreScript()
//        {
//#region SubCashOfficeOperationForm_PreScript
//    if (_SubCashOfficeOperation.CurrentStateDefID == SubCashOfficeOperation.States.New)
//            {
//                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
//                CashierLog  _myCashierLog = null;
//                if (_myResUser != null)
//                    _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
                
//                if (_myCashierLog == null)
//                    throw new TTException(SystemMessage.GetMessage(71));
//                else
//                {
//                    if (_myCashierLog.CashOffice.Type != CashOfficeTypeEnum.CashOffice)
//                        throw new TTException(SystemMessage.GetMessage(71));
//                    else
//                    {
                        
//                        this.MONEYRECEIVEDTYPE.ListFilterExpression = "SUBCASHIERCANDO = 1";                        
//                        this.cmdOK.Visible = false;
//                        _SubCashOfficeOperation.CashOfficeName = _myCashierLog.CashOffice.Name;
                        
//                        if (_SubCashOfficeOperation.SubCashOfficeReceiptDocument == null)
//                        {
//                            _SubCashOfficeOperation.SubCashOfficeReceiptDocument = new SubCashOfficeReceiptDoc(_SubCashOfficeOperation.ObjectContext);
//                            _SubCashOfficeOperation.SubCashOfficeReceiptDocument.CashierLog = _myCashierLog;
//                            _SubCashOfficeOperation.SubCashOfficeReceiptDocument.DocumentDate = DateTime.Now.Date;
//                            _SubCashOfficeOperation.SubCashOfficeReceiptDocument.CurrentStateDefID = SubCashOfficeReceiptDoc.States.New;

                            
//                            ReceiptCashOfficeDefinition _myReceiptCashOfficeDefinition;
//                            IList myList = ReceiptCashOfficeDefinition.GetByCashOffice(_SubCashOfficeOperation.ObjectContext, _myCashierLog.CashOffice.ObjectID.ToString());

//                            if (myList.Count == 0)
//                                throw new TTException(SystemMessage.GetMessage(74, new string[] { _SubCashOfficeOperation.CashOfficeName }));
//                            else
//                            {
//                                _myReceiptCashOfficeDefinition = (ReceiptCashOfficeDefinition)_SubCashOfficeOperation.ObjectContext.QueryObjects("ReceiptCashOfficeDefinition", "CASHOFFICE = '" + _myCashierLog.CashOffice.ObjectID + "'" )[0];
//                                _SubCashOfficeOperation.SubCashOfficeReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(_myReceiptCashOfficeDefinition);
//                                _SubCashOfficeOperation.SubCashOfficeReceiptDocument.CreditCardDocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(_myReceiptCashOfficeDefinition);
//                            }
//                        }
//                    }
//                }
//            }
//            else
//            {
//                if (this._SubCashOfficeOperation.SubCashOfficeReceiptDocument.CashPayment.Count == 0)
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeReceiptReport));
                
//                if (this._SubCashOfficeOperation.SubCashOfficeReceiptDocument.CreditCardPayments.Count == 0)
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_SubCashOfficeReceiptCreditCardReport));
                
//            }
//#endregion SubCashOfficeOperationForm_PreScript

//            }
            
//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//#region SubCashOfficeOperationForm_PostScript
//    if (_SubCashOfficeOperation.TotalPrice == 0)
//                throw new TTException(SystemMessage.GetMessage(187));
//            else
//                _SubCashOfficeOperation.SubCashOfficeReceiptDocument.TotalPrice = _SubCashOfficeOperation.TotalPrice;
            
//            if (_SubCashOfficeOperation.SubCashOfficeReceiptDocument.CashPayment.Count == 0)
//                _SubCashOfficeOperation.SubCashOfficeReceiptDocument.DocumentNo = null;
            
//            if (_SubCashOfficeOperation.SubCashOfficeReceiptDocument.CreditCardPayments.Count == 0)
//                _SubCashOfficeOperation.SubCashOfficeReceiptDocument.CreditCardDocumentNo = null;
//#endregion SubCashOfficeOperationForm_PostScript

//            }
            
//#region SubCashOfficeOperationForm_Methods
//        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
//        {
//            base.AfterContextSavedScript(transDef);

//            // Nakit ve Kredi Kartı raporları dökülür
//            if(transDef != null && transDef.ToStateDefID == SubCashOfficeOperation.States.Completed)
//            {
//                if (_SubCashOfficeOperation.SubCashOfficeReceiptDocument.CashPayment.Count > 0)
//                {
//                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
//                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//                    cache.Add("VALUE", _SubCashOfficeOperation.ObjectID.ToString());
                    
//                    parameters.Add("TTOBJECTID",cache);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SubCashOfficeReceiptReport), true, 1, parameters);
//                }
                
//                if (_SubCashOfficeOperation.SubCashOfficeReceiptDocument.CreditCardPayments.Count > 0)
//                {
//                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
//                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//                    cache.Add("VALUE", _SubCashOfficeOperation.ObjectID.ToString());
                    
//                    parameters.Add("TTOBJECTID",cache);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SubCashOfficeReceiptCreditCardReport), true, 1, parameters);
//                }
//            }
//        }
        
//#endregion SubCashOfficeOperationForm_Methods
//    }
//}