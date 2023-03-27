
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
//    /// Senet Takip
//    /// </summary>
//    public partial class DebentureFollowForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            UnSelectAllButton.Click += new TTControlEventDelegate(UnSelectAllButton_Click);
//            SelectAllButton.Click += new TTControlEventDelegate(SelectAllButton_Click);
//            ExecutionOrderListButton.Click += new TTControlEventDelegate(ExecutionOrderListButton_Click);
//            GRIDPaymentOrders.CellContentClick += new TTGridCellEventDelegate(GRIDPaymentOrders_CellContentClick);
//            GRIDPaymentOrders.CellValueChanged += new TTGridCellEventDelegate(GRIDPaymentOrders_CellValueChanged);
//            GRIDExecutionOrders.CellValueChanged += new TTGridCellEventDelegate(GRIDExecutionOrders_CellValueChanged);
//            GRIDExecutionOrders.CellContentClick += new TTGridCellEventDelegate(GRIDExecutionOrders_CellContentClick);
//            PaymentOrderListButton.Click += new TTControlEventDelegate(PaymentOrderListButton_Click);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            UnSelectAllButton.Click -= new TTControlEventDelegate(UnSelectAllButton_Click);
//            SelectAllButton.Click -= new TTControlEventDelegate(SelectAllButton_Click);
//            ExecutionOrderListButton.Click -= new TTControlEventDelegate(ExecutionOrderListButton_Click);
//            GRIDPaymentOrders.CellContentClick -= new TTGridCellEventDelegate(GRIDPaymentOrders_CellContentClick);
//            GRIDPaymentOrders.CellValueChanged -= new TTGridCellEventDelegate(GRIDPaymentOrders_CellValueChanged);
//            GRIDExecutionOrders.CellValueChanged -= new TTGridCellEventDelegate(GRIDExecutionOrders_CellValueChanged);
//            GRIDExecutionOrders.CellContentClick -= new TTGridCellEventDelegate(GRIDExecutionOrders_CellContentClick);
//            PaymentOrderListButton.Click -= new TTControlEventDelegate(PaymentOrderListButton_Click);
//            base.UnBindControlEvents();
//        }

//        private void UnSelectAllButton_Click()
//        {
//#region DebentureFollowForm_UnSelectAllButton_Click
//   if (this._DebentureFollow.CurrentStateDefID == DebentureFollow.States.New)
//            {
//                _DebentureFollow.DebentureAmount = 0 ;
//                foreach (DebentureFollowPaymentOrderList orderList in this._DebentureFollow.PaymentOrderList)
//                {
//                    orderList.Reported = false;
//                }
//                foreach (DebentureFollowExecutionList eList in this._DebentureFollow.ExecutionList)
//                {
//                    eList.Reported = false;
//                }
//            }
//#endregion DebentureFollowForm_UnSelectAllButton_Click
//        }

//        private void SelectAllButton_Click()
//        {
//#region DebentureFollowForm_SelectAllButton_Click
//   if (this._DebentureFollow.CurrentStateDefID == DebentureFollow.States.New)
//            {
//                _DebentureFollow.DebentureAmount = 0;
//                foreach (DebentureFollowPaymentOrderList orderList in this._DebentureFollow.PaymentOrderList)
//                {
//                    orderList.Reported = true;
//                    _DebentureFollow.DebentureAmount  =  _DebentureFollow.DebentureAmount +1;
//                }
//                foreach (DebentureFollowExecutionList eList in this._DebentureFollow.ExecutionList)
//                {
//                    eList.Reported = true;
//                    _DebentureFollow.DebentureAmount  =  _DebentureFollow.DebentureAmount +1;
//                }
//            }
//#endregion DebentureFollowForm_SelectAllButton_Click
//        }

//        private void ExecutionOrderListButton_Click()
//        {
//#region DebentureFollowForm_ExecutionOrderListButton_Click
//   if (this._DebentureFollow.CurrentStateDefID == DebentureFollow.States.New)
//            {
//                DateTime sDate = (DateTime)this._DebentureFollow.StartDate;
//                DateTime eDate = (DateTime)this._DebentureFollow.EndDate ;
//                string msg = "";
//                if(eDate > DateTime.Now.Date)
//                    msg = "Bitiş Tarihi bugünden ileri bir tarih  seçilemez!.";
//                else if (sDate > DateTime.Now.Date)
//                    msg = "Başlangıç Tarihi bugünden ileri bir tarih  seçilemez!.";
//                if (msg == "")
//                {
//                    this._DebentureFollow.DebentureAmount  = 0;
                    
//                    // Gridler ve child collection lar siliniyor
//                    foreach(DebentureFollowPaymentOrderList dPayOrdLst in this._DebentureFollow.PaymentOrderList)
//                    {
//                        dPayOrdLst.Debentures.Clear();
//                    }
//                    this._DebentureFollow.PaymentOrderList.DeleteChildren();
                    
//                    foreach(DebentureFollowExecutionList dPayExcLst in this._DebentureFollow.ExecutionList)
//                    {
//                        dPayExcLst.Debentures.Clear();
//                    }
//                    this._DebentureFollow.ExecutionList.DeleteChildren();
                    
//                    IList executionDebentureList = Debenture.GetByExecutionDateAndState(_DebentureFollow.ObjectContext,(DateTime)sDate.Date ,(DateTime)eDate.Date ,Debenture.States.PaymentOder.ToString());

//                    foreach (Debenture db in executionDebentureList)
//                    {
//                        DebentureFollowExecutionList dExList = new DebentureFollowExecutionList(_DebentureFollow.ObjectContext);
//                        dExList.ExecutionDate = DateTime.Now.Date ;
//                        dExList.Reported = false ;
//                        dExList.Debenture = db ;
                        
//                        if((AccountDocument)db.AccountDocument is AdvanceDocument)
//                        {
//                            AdvanceDocument advanceDocument = (AdvanceDocument)db.AccountDocument ;
//                            Advance advance = (Advance)advanceDocument.Advance[0];
//                            dExList.Episode = advance.Episode ;
//                        }
//                        else if((AccountDocument)db.AccountDocument is ReceiptDocument)
//                        {
//                            ReceiptDocument receiptDocument = (ReceiptDocument)db.AccountDocument ;
//                            Receipt receipt = (Receipt)receiptDocument.Receipt[0] ;
//                            dExList.Episode = receipt.Episode ;
//                          }
//                        this._DebentureFollow.ExecutionList.Add(dExList);
//                    }
//                    this.TabExecutionOrder.Focus();
//                }
//                else
//                    InfoBox.Show(msg);
//            }
//#endregion DebentureFollowForm_ExecutionOrderListButton_Click
//        }

//        private void GRIDPaymentOrders_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureFollowForm_GRIDPaymentOrders_CellContentClick
//   if (columnIndex == 9 && rowIndex != -1 )
//            {
                
//                if (rowIndex < this._DebentureFollow.PaymentOrderList.Count)
//                {
//                    DebentureGuarantor debentureGuarantor;
//                    debentureGuarantor = this._DebentureFollow.PaymentOrderList[rowIndex].Debenture.Guarantor;
//                    DebentureGuarantorForm frm = new DebentureGuarantorForm();
//                    frm.ShowReadOnly(this.FindForm(),debentureGuarantor);
//                }
//            }
//#endregion DebentureFollowForm_GRIDPaymentOrders_CellContentClick
//        }

//        private void GRIDPaymentOrders_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureFollowForm_GRIDPaymentOrders_CellValueChanged
//   if (columnIndex == 8 && rowIndex != -1)
//            {
                
//                if (!(bool)GRIDPaymentOrders.Rows[rowIndex].Cells[columnIndex].Value)
//                    _DebentureFollow.DebentureAmount   = _DebentureFollow.DebentureAmount - 1;
//                else if ((bool)GRIDPaymentOrders.Rows[rowIndex].Cells[columnIndex].Value)
//                    _DebentureFollow.DebentureAmount  =  _DebentureFollow.DebentureAmount +1;
//            }
//#endregion DebentureFollowForm_GRIDPaymentOrders_CellValueChanged
//        }

//        private void GRIDExecutionOrders_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureFollowForm_GRIDExecutionOrders_CellValueChanged
//   if (columnIndex == 11 && rowIndex != -1)
//            {
                
//                if (!(bool)GRIDExecutionOrders.Rows[rowIndex].Cells[columnIndex].Value)
//                    _DebentureFollow.DebentureAmount   = _DebentureFollow.DebentureAmount - 1;
//                else if ((bool)GRIDExecutionOrders.Rows[rowIndex].Cells[columnIndex].Value)
//                     _DebentureFollow.DebentureAmount  =  _DebentureFollow.DebentureAmount +1;
//            }
//#endregion DebentureFollowForm_GRIDExecutionOrders_CellValueChanged
//        }

//        private void GRIDExecutionOrders_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureFollowForm_GRIDExecutionOrders_CellContentClick
//   if (columnIndex == 12 && rowIndex != -1 )
//            {
//                if (rowIndex < this._DebentureFollow.ExecutionList.Count)
//                {
//                    DebentureGuarantor debentureGuarantor;
//                    debentureGuarantor = this._DebentureFollow.ExecutionList[rowIndex].Debenture.Guarantor;
//                    DebentureGuarantorForm frm = new DebentureGuarantorForm();
//                    frm.ShowReadOnly(this.FindForm(),debentureGuarantor);
//                }
//            }
//#endregion DebentureFollowForm_GRIDExecutionOrders_CellContentClick
//        }

//        private void PaymentOrderListButton_Click()
//        {
//#region DebentureFollowForm_PaymentOrderListButton_Click
//   if (this._DebentureFollow.CurrentStateDefID == DebentureFollow.States.New)
//            {
//                DateTime sDate = (DateTime)this._DebentureFollow.StartDate;
//                DateTime eDate = (DateTime)this._DebentureFollow.EndDate ;
//                string msg = "";
//                if(eDate > DateTime.Now.Date)
//                    msg = "Bitiş Tarihi bugünden ileri bir tarih  seçilemez!.";
//                else if (sDate > DateTime.Now.Date)
//                    msg = "Başlangıç Tarihi bugünden ileri bir tarih  seçilemez!.";
//                if (msg == "")
//                {
//                    this._DebentureFollow.DebentureAmount  = 0;
                    
//                    // Gridler ve child collection lar siliniyor
//                    foreach(DebentureFollowPaymentOrderList dPayOrdLst in this._DebentureFollow.PaymentOrderList)
//                    {
//                        dPayOrdLst.Debentures.Clear();
//                    }
//                    this._DebentureFollow.PaymentOrderList.DeleteChildren();
                    
//                    foreach(DebentureFollowExecutionList dPayExcLst in this._DebentureFollow.ExecutionList)
//                    {
//                        dPayExcLst.Debentures.Clear();
//                    }
//                    this._DebentureFollow.ExecutionList.DeleteChildren();
                    
                    
                    
//                    IList paymentOrderDebentureList = Debenture.GetByPaymentOrderDateAndState(_DebentureFollow.ObjectContext,(DateTime)sDate.Date ,(DateTime)eDate.Date ,Debenture.States.New.ToString());
                    
//                    foreach (Debenture db in paymentOrderDebentureList)
//                    {
//                        DebentureFollowPaymentOrderList dPayOrdList = new DebentureFollowPaymentOrderList(_DebentureFollow.ObjectContext);
//                        dPayOrdList.PaymentOrderDate = DateTime.Now.Date;
//                        dPayOrdList.Reported = false ;
//                        dPayOrdList.Debenture = db;
                        
//                        if((AccountDocument)db.AccountDocument is AdvanceDocument)
//                        {
//                            AdvanceDocument advanceDocument = (AdvanceDocument)db.AccountDocument ;
//                            Advance advance = (Advance)advanceDocument.Advance[0];
//                            dPayOrdList.Episode = advance.Episode ;
//                        }
//                        else if((AccountDocument)db.AccountDocument is ReceiptDocument)
//                        {
//                            ReceiptDocument receiptDocument = (ReceiptDocument)db.AccountDocument ;
//                            Receipt receipt = (Receipt)receiptDocument.Receipt[0] ;
//                            dPayOrdList.Episode = receipt.Episode ;
//                        }
//                        this._DebentureFollow.PaymentOrderList.Add(dPayOrdList);
//                    }
//                }
//                else
//                    InfoBox.Show(msg);
//            }
//#endregion DebentureFollowForm_PaymentOrderListButton_Click
//        }

//        protected override void PreScript()
//        {
//#region DebentureFollowForm_PreScript
//    if (this._DebentureFollow.CurrentStateDefID == DebentureFollow.States.New)
//            {
//                base.PreScript();
//                this._DebentureFollow.StartDate = DateTime.Now.Date  ;
//                this._DebentureFollow.EndDate = DateTime.Now.Date  ;
//                this._DebentureFollow.DebentureAmount  = 0;
//            }
//            if(this._DebentureFollow.CurrentStateDefID == DebentureFollow.States.Completed)
//            {
//                if(this._DebentureFollow.PaymentOrderList.Count == 0)
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_DebentureFollowPaymentOrderReport));
//                if(this._DebentureFollow.ExecutionList.Count == 0)
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_DebentureFollowExecutionReport));
                    
//            }
//#endregion DebentureFollowForm_PreScript

//            }
            
//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//#region DebentureFollowForm_PostScript
//    base.PostScript(transDef);
//            if (this._DebentureFollow.DebentureAmount  == 0)
//                throw new TTException(SystemMessage.GetMessage(435));
//#endregion DebentureFollowForm_PostScript

//            }
            
//#region DebentureFollowForm_Methods
//        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
//        {
//            base.AfterContextSavedScript(transDef);

//            // Ödeme Emri  ve İcra Emri raporları dökülür
//            if(transDef != null && transDef.ToStateDefID == DebentureFollow.States.Completed)
//            {
//                if (_DebentureFollow.PaymentOrderList.Count > 0)
//                {
//                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
//                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//                    cache.Add("VALUE", _DebentureFollow.ObjectID.ToString());
                    
//                    parameters.Add("TTOBJECTID",cache);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_DebentureFollowPaymentOrderReport), true, 1, parameters);
//                }
//                if (_DebentureFollow.ExecutionList.Count > 0)
//                {
//                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
//                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//                    cache.Add("VALUE", _DebentureFollow.ObjectID.ToString());
                    
//                    parameters.Add("TTOBJECTID",cache);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_DebentureFollowExecutionReport), true, 1, parameters);
//                }
//            }
//        }
        
//#endregion DebentureFollowForm_Methods
//    }
//}