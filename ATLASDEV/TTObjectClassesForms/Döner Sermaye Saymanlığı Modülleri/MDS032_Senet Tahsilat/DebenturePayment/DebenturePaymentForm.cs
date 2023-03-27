
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
//    /// Senet Tahsilat
//    /// </summary>
//    public partial class DebenturePaymentForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            GRIDDebentures.CellContentClick += new TTGridCellEventDelegate(GRIDDebentures_CellContentClick);
//            GRIDDebentures.CellValueChanged += new TTGridCellEventDelegate(GRIDDebentures_CellValueChanged);
//            GRIDCashs.CellValueChanged += new TTGridCellEventDelegate(GRIDCashs_CellValueChanged);
//            GRIDCreditCards.CellValueChanged += new TTGridCellEventDelegate(GRIDCreditCards_CellValueChanged);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            GRIDDebentures.CellContentClick -= new TTGridCellEventDelegate(GRIDDebentures_CellContentClick);
//            GRIDDebentures.CellValueChanged -= new TTGridCellEventDelegate(GRIDDebentures_CellValueChanged);
//            GRIDCashs.CellValueChanged -= new TTGridCellEventDelegate(GRIDCashs_CellValueChanged);
//            GRIDCreditCards.CellValueChanged -= new TTGridCellEventDelegate(GRIDCreditCards_CellValueChanged);
//            base.UnBindControlEvents();
//        }

//        private void GRIDDebentures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebenturePaymentForm_GRIDDebentures_CellContentClick
//   if (columnIndex == 5 && rowIndex != -1 )
//            {
//                if (rowIndex < this._DebenturePayment.PatientDebentures.Count )
                    
//                {
//                    if ( _DebenturePayment.PatientDebentures[rowIndex].Debenture == null)
//                        throw new Exception("Kefil Bulunamadı");
//                    else
//                    {
//                        DebentureGuarantor debentureGuarantor;
//                        Debenture debenture ;
                        
//                        debenture = _DebenturePayment.PatientDebentures[rowIndex].Debenture ;
//                        debentureGuarantor = debenture.Guarantor ;
//                        DebentureGuarantorForm frm = new DebentureGuarantorForm();
//                        frm.ShowReadOnly(this.FindForm(),debentureGuarantor);
                        
//                    }
                    
//                    //  string debentureObjectID = _DebenturePayment.PatientDebentures[rowIndex].DebentureObjectID.ToString();
//                    //  IList MyDebentureList = Debenture.GetByObjectID(_DebenturePayment.ObjectContext,debentureObjectID);
                    
//                    //                    if (MyDebentureList.Count == 0)
//                    //                        throw new Exception("Kefil Bulunamadı");
//                    //                    else
//                    //                    {
//                    //                        DebentureGuarantor debentureGuarantor;
//                    //                        Debenture debenture ;
//                    //                        foreach (Debenture db in MyDebentureList)
//                    //                        {
//                    //                            debenture = db ;
//                    //                            debentureGuarantor = db.Guarantor ;
//                    //                            DebentureGuarantorForm frm = new DebentureGuarantorForm();
//                    //                            frm.ShowReadOnly(this.FindForm(),debentureGuarantor);
//                    //                        }
//                    //                    }
//                }
//            }
//#endregion DebenturePaymentForm_GRIDDebentures_CellContentClick
//        }

//        private void GRIDDebentures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebenturePaymentForm_GRIDDebentures_CellValueChanged
//   if (columnIndex == 4 && rowIndex != -1)
//            {
//                //   rowIndex = GRIDDebentures.CurrentCell.RowIndex;
//                //   columnIndex = GRIDDebentures.CurrentCell.ColumnIndex;
//                if (_DebenturePayment.TotalPrice != null)
//                {
//                    if (!(bool)GRIDDebentures.Rows[rowIndex].Cells[columnIndex].Value)
//                        _DebenturePayment.TotalPrice  = (double)_DebenturePayment.TotalPrice - Convert.ToDouble(GRIDDebentures.Rows[rowIndex].Cells[2].Value);
//                    else if ((bool)GRIDDebentures.Rows[rowIndex].Cells[columnIndex].Value)
//                        _DebenturePayment.TotalPrice  = (double)_DebenturePayment.TotalPrice + Convert.ToDouble(GRIDDebentures.Rows[rowIndex].Cells[2].Value);
//                }

//            }
//#endregion DebenturePaymentForm_GRIDDebentures_CellValueChanged
//        }

//        private void GRIDCashs_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebenturePaymentForm_GRIDCashs_CellValueChanged
//   //            if (columnIndex == 0 && rowIndex != -1)
//            //            {
//            //                double totalPayment = 0;
//            //                if ( this._DebenturePayment.DebenturePaymentDocument.CashPayment.Count != 0)
//            //                {
//            //                    foreach (Payment cashPay in  this._DebenturePayment.DebenturePaymentDocument.CashPayment)
//            //                    {
//            //                        if (cashPay.Price != null)
//            //                            totalPayment  = (double)totalPayment + (double)cashPay.Price ;
//            //                    }
//            //                }
////
//            //                if (this._DebenturePayment.DebenturePaymentDocument.CreditCardPayments.Count != 0 )
//            //                {
//            //                    foreach (Payment creditPay in this._DebenturePayment.DebenturePaymentDocument.CreditCardPayments)
//            //                    {
////
//            //                        if (creditPay.Price != null)
//            //                            totalPayment = (double)totalPayment + (double)creditPay.Price ;
//            //                    }
//            //                }
//            //                _DebenturePayment.PaymentPrice = (double)totalPayment;
//            //            }

//            if (columnIndex == 0 || columnIndex == 1 && rowIndex != -1)
//            {
//                this._DebenturePayment.PaymentPrice = this._DebenturePayment.DebenturePaymentDocument.GetTotalPayment();
              
//            }
//#endregion DebenturePaymentForm_GRIDCashs_CellValueChanged
//        }

//        private void GRIDCreditCards_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebenturePaymentForm_GRIDCreditCards_CellValueChanged
//   if (columnIndex == 5)
//            {
//                this._DebenturePayment.PaymentPrice = this._DebenturePayment.DebenturePaymentDocument.GetTotalPayment();
//            }
            
//             if (columnIndex != 1)
//            {
//                if(this._DebenturePayment.DebenturePaymentDocument.CreditCardPayments[rowIndex].PhoneNo == null)
//                {
            
//                    if (this._DebenturePayment.Episode.Patient.PatientAddress.HomePhone != null)
//                        this._DebenturePayment.DebenturePaymentDocument.CreditCardPayments[rowIndex].PhoneNo = this._DebenturePayment.Episode.Patient.PatientAddress.HomePhone;
//                    else if (this._DebenturePayment.Episode.Patient.PatientAddress.MobilePhone != null)
//                        this._DebenturePayment.DebenturePaymentDocument.CreditCardPayments[rowIndex].PhoneNo = this._DebenturePayment.Episode.Patient.PatientAddress.MobilePhone;
//                    else
//                        this._DebenturePayment.DebenturePaymentDocument.CreditCardPayments[rowIndex].PhoneNo = null;
//                }
//            }
//#endregion DebenturePaymentForm_GRIDCreditCards_CellValueChanged
//        }

//        protected override void PreScript()
//        {
//#region DebenturePaymentForm_PreScript
//    if (_DebenturePayment.CurrentStateDefID == DebenturePayment.States.New)
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
//                        this.cmdOK.Visible = false ;

//                        foreach (EpisodeAction ea in this._DebenturePayment.Episode.EpisodeActions)
//                        {
//                            if (ea.Cancelled == false)
//                            {
//                                Receipt myReceipt = ea as Receipt ;
//                                if (myReceipt != null)
//                                {
//                                    if (myReceipt.CurrentStateDefID == Receipt.States.Paid)
//                                    {
//                                        foreach (Debenture db in myReceipt.ReceiptDocument.DebenturePayments)
//                                        {
//                                            if (db.CurrentStateDefID != Debenture.States.Cancelled)
//                                            {
//                                                DebenturePaymentPatientDebentures patientDebs = new DebenturePaymentPatientDebentures(_DebenturePayment.ObjectContext);
//                                                patientDebs.Paid = false ;
//                                                patientDebs.Status = db.CurrentStateDef.DisplayText.ToString();
//                                                patientDebs.Debenture = db ;
//                                                _DebenturePayment.PatientDebentures.Add(patientDebs);
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        foreach (EpisodeAction ea in this._DebenturePayment.Episode.EpisodeActions)
//                        {
//                            if (ea.Cancelled == false)
//                            {
//                                Advance myAdvance = ea as Advance;
//                                if (myAdvance != null)
//                                {
//                                    if (myAdvance.CurrentStateDefID == Advance.States.Paid)
//                                    {
//                                        foreach (Debenture db in myAdvance.AdvanceDocument.DebenturePayments)
//                                        {
//                                            if (db.CurrentStateDefID != Debenture.States.Cancelled)
//                                            {
//                                                DebenturePaymentPatientDebentures patientDebsAdv = new DebenturePaymentPatientDebentures(_DebenturePayment.ObjectContext);
//                                                patientDebsAdv.Paid = false ;
//                                                patientDebsAdv.Status = db.CurrentStateDef.DisplayText.ToString();
//                                                patientDebsAdv.Debenture = db ;
//                                                _DebenturePayment.PatientDebentures.Add(patientDebsAdv);
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                        _DebenturePayment.TotalPrice = 0 ;
//                        _DebenturePayment.PaymentPrice = 0 ;
//                        _DebenturePayment.GeneralTotalPrice = 0;
//                        _DebenturePayment.CashOfficeName = _myCashierLog.CashOffice.Name ;
                        
//                        if (_DebenturePayment.DebenturePaymentDocument == null)
                            
//                        {
//                            _DebenturePayment.DebenturePaymentDocument =  new DebenturePaymentDocument(_DebenturePayment.ObjectContext);
//                            _DebenturePayment.DebenturePaymentDocument.CashierLog = _myCashierLog ;
//                            _DebenturePayment.DebenturePaymentDocument.DocumentDate = DateTime.Now.Date;
//                            _DebenturePayment.DebenturePaymentDocument.CurrentStateDefID = DebenturePaymentDocument.States.New ;
//                            _DebenturePayment.DebenturePaymentDocument.TotalPrice = 0;
                            
//                            IList myList = ReceiptCashOfficeDefinition.GetByCashOffice(_DebenturePayment.ObjectContext,_myCashierLog.CashOffice.ObjectID.ToString());
                            
//                            if (myList.Count == 0)
//                                throw new TTException(SystemMessage.GetMessage(74, new string[] { _DebenturePayment.CashOfficeName }));
//                            else
//                            {
//                                ReceiptCashOfficeDefinition cashOfficeDef = (ReceiptCashOfficeDefinition) myList[0];
//                                _DebenturePayment.DebenturePaymentDocument.DocumentNo = (string)ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(cashOfficeDef);
//                                _DebenturePayment.DebenturePaymentDocument.CreditCardDocumentNo = (string)ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(cashOfficeDef);
//                            }

//                        }
//                        for (int i = 0 ; i < this.GRIDDebentures.Rows.Count  ; i++)
//                        {
//                            if (this.GRIDDebentures.Rows[i].Cells[3].Value.ToString() == "Ödendi" )
//                                this.GRIDDebentures.Rows[i].Cells[4].ReadOnly = true ;
//                            else
//                                this.GRIDDebentures.Rows[i].Cells[4].ReadOnly = false ;
//                        }
//                    }
//                }
//            }
//#endregion DebenturePaymentForm_PreScript

//            }
            
//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//#region DebenturePaymentForm_PostScript
//    if (_DebenturePayment.TotalPrice != _DebenturePayment.PaymentPrice)
//                throw new TTException(SystemMessage.GetMessage(384));
            
//            if (_DebenturePayment.DebenturePaymentDocument.CashPayment.Count == 0)
//                _DebenturePayment.DebenturePaymentDocument.DocumentNo = null;
//            if (_DebenturePayment.DebenturePaymentDocument.CreditCardPayments.Count == 0)
//                _DebenturePayment.DebenturePaymentDocument.CreditCardDocumentNo = null;
//#endregion DebenturePaymentForm_PostScript

//            }
            
//#region DebenturePaymentForm_Methods
//        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
//        {
//            base.AfterContextSavedScript(transDef);

//            // Nakit ve Kredi Kartı raporları dökülür
//            if(transDef != null && transDef.ToStateDefID == DebenturePayment.States.Paid)
//            {
//                if (_DebenturePayment.DebenturePaymentDocument.CashPayment.Count > 0)
//                {
//                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
//                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//                    cache.Add("VALUE", _DebenturePayment.ObjectID.ToString());
                    
//                    parameters.Add("TTOBJECTID",cache);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_DebPaymentReport), true, 1, parameters);
//                }
//                if (_DebenturePayment.DebenturePaymentDocument.CreditCardPayments.Count > 0)
//                {
//                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
//                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//                    cache.Add("VALUE", _DebenturePayment.ObjectID.ToString());
                    
//                    parameters.Add("TTOBJECTID",cache);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_DebPaymentCrCardReport), true, 1, parameters);
//                }
                
//            }
//        }
        
//#endregion DebenturePaymentForm_Methods
//    }
//}