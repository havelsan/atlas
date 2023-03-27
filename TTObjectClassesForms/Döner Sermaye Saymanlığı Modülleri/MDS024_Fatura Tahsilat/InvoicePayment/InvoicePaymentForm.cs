
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
//    /// Fatura Tahsilat
//    /// </summary>
//    public partial class InvoicePaymentForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            GridInvoiceList.CellValueChanged += new TTGridCellEventDelegate(GridInvoiceList_CellValueChanged);
//            PAYMENTPRICE.TextChanged += new TTControlEventDelegate(PAYMENTPRICE_TextChanged);
//            FillPayerButton.Click += new TTControlEventDelegate(FillPayerButton_Click);
//            CheckAll.Click += new TTControlEventDelegate(CheckAll_Click);
//            ListButon.Click += new TTControlEventDelegate(ListButon_Click);
//            GridCashPayment.CellValueChanged += new TTGridCellEventDelegate(GridCashPayment_CellValueChanged);
//            GridCashPayment.UserDeletedRow += new TTGridRowEventDelegate(GridCashPayment_UserDeletedRow);
//            GridBankDecountPayment.CellValueChanged += new TTGridCellEventDelegate(GridBankDecountPayment_CellValueChanged);
//            GridBankDecountPayment.UserDeletedRow += new TTGridRowEventDelegate(GridBankDecountPayment_UserDeletedRow);
//            GridChequePayment.CellValueChanged += new TTGridCellEventDelegate(GridChequePayment_CellValueChanged);
//            USEADVANCE.CheckedChanged += new TTControlEventDelegate(USEADVANCE_CheckedChanged);
//            GridAdvancePayment.CellValueChanged += new TTGridCellEventDelegate(GridAdvancePayment_CellValueChanged);
//            TOTALPAYMENT.TextChanged += new TTControlEventDelegate(TOTALPAYMENT_TextChanged);
//            UncheckAll.Click += new TTControlEventDelegate(UncheckAll_Click);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            GridInvoiceList.CellValueChanged -= new TTGridCellEventDelegate(GridInvoiceList_CellValueChanged);
//            PAYMENTPRICE.TextChanged -= new TTControlEventDelegate(PAYMENTPRICE_TextChanged);
//            FillPayerButton.Click -= new TTControlEventDelegate(FillPayerButton_Click);
//            CheckAll.Click -= new TTControlEventDelegate(CheckAll_Click);
//            ListButon.Click -= new TTControlEventDelegate(ListButon_Click);
//            GridCashPayment.CellValueChanged -= new TTGridCellEventDelegate(GridCashPayment_CellValueChanged);
//            GridCashPayment.UserDeletedRow -= new TTGridRowEventDelegate(GridCashPayment_UserDeletedRow);
//            GridBankDecountPayment.CellValueChanged -= new TTGridCellEventDelegate(GridBankDecountPayment_CellValueChanged);
//            GridBankDecountPayment.UserDeletedRow -= new TTGridRowEventDelegate(GridBankDecountPayment_UserDeletedRow);
//            GridChequePayment.CellValueChanged -= new TTGridCellEventDelegate(GridChequePayment_CellValueChanged);
//            USEADVANCE.CheckedChanged -= new TTControlEventDelegate(USEADVANCE_CheckedChanged);
//            GridAdvancePayment.CellValueChanged -= new TTGridCellEventDelegate(GridAdvancePayment_CellValueChanged);
//            TOTALPAYMENT.TextChanged -= new TTControlEventDelegate(TOTALPAYMENT_TextChanged);
//            UncheckAll.Click -= new TTControlEventDelegate(UncheckAll_Click);
//            base.UnBindControlEvents();
//        }

//        private void GridInvoiceList_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region InvoicePaymentForm_GridInvoiceList_CellValueChanged
//   if (columnIndex == 6 && rowIndex != -1 )
//            {
//                if (GridInvoiceList.Rows[rowIndex].Cells[columnIndex].Value.ToString() ==  "False")
//                {
//                    _InvoicePayment.TotalPrice = _InvoicePayment.TotalPrice - Convert.ToDouble(GridInvoiceList.Rows[rowIndex].Cells[4].Value);
//                    _InvoicePayment.CutOffPrice = _InvoicePayment.CutOffPrice - Convert.ToDouble(GridInvoiceList.Rows[rowIndex].Cells[5].Value);
//                    GridInvoiceList.Rows[rowIndex].Cells[5].Value = 0 ;
//                    GridInvoiceList.Rows[rowIndex].Cells[5].ReadOnly = true ;    
//                }
//                else if (GridInvoiceList.Rows[rowIndex].Cells[columnIndex].Value.ToString() ==  "True")
//                {
//                    _InvoicePayment.TotalPrice= _InvoicePayment.TotalPrice + Convert.ToDouble(GridInvoiceList.Rows[rowIndex].Cells[4].Value);
//                    _InvoicePayment.CutOffPrice = _InvoicePayment.CutOffPrice + Convert.ToDouble(GridInvoiceList.Rows[rowIndex].Cells[5].Value);
//                    GridInvoiceList.Rows[rowIndex].Cells[5].ReadOnly = false ;    
//                }
//                this._InvoicePayment.UpdateBankAccountOrCashFields();
//                this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
//            }
            
//            if (columnIndex == 5)
//            {
//                double cutOffPrice = 0;
//                for (int i=0; i<GridInvoiceList.Rows.Count; i++)
//                    cutOffPrice = cutOffPrice + Convert.ToDouble(GridInvoiceList.Rows[i].Cells[columnIndex].Value);

//                _InvoicePayment.CutOffPrice = cutOffPrice;
//                this._InvoicePayment.UpdateBankAccountOrCashFields();
//                this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
//            }
            
//            _InvoicePayment.PaymentPrice = _InvoicePayment.TotalPrice - _InvoicePayment.CutOffPrice;
//#endregion InvoicePaymentForm_GridInvoiceList_CellValueChanged
//        }

//        private void PAYMENTPRICE_TextChanged()
//        {
//#region InvoicePaymentForm_PAYMENTPRICE_TextChanged
//   double totalPayment = 0;
//            if(!string.IsNullOrEmpty(this.TOTALPAYMENT.Text))
//                 totalPayment = Convert.ToDouble(this.TOTALPAYMENT.Text);
//            this.RemainderCheckbox.Text = ((Convert.ToDouble(this.PAYMENTPRICE.Text)) - totalPayment).ToString();
//#endregion InvoicePaymentForm_PAYMENTPRICE_TextChanged
//        }

//        private void FillPayerButton_Click()
//        {
//#region InvoicePaymentForm_FillPayerButton_Click
//   string documentStartNo = _InvoicePayment.InvoiceDocumentNoStart;
//            string documentEndNo = _InvoicePayment.InvoiceDocumentNoEnd;
//   if (!string.IsNullOrEmpty(documentStartNo))
//            {
//                BindingList<PayerInvoiceDocument> payerInvoiceDocument = PayerInvoiceDocument.GetByDocumentNo(_InvoicePayment.ObjectContext, documentStartNo);
//                if(payerInvoiceDocument.Count > 0)
//                    _InvoicePayment.Payer = payerInvoiceDocument[0].Payer;
                
//                BindingList<GeneralInvoiceDocument> generalInvoiceDocument = GeneralInvoiceDocument.GetByDocumentNo(_InvoicePayment.ObjectContext, documentStartNo);
//                if(generalInvoiceDocument.Count > 0)
//                    _InvoicePayment.Payer = ((GeneralInvoice)(generalInvoiceDocument[0].AccountAction)).Payer;
//            }
//            else if (!string.IsNullOrEmpty(documentEndNo))
//            {
//                BindingList<PayerInvoiceDocument> payerInvoiceDocument = PayerInvoiceDocument.GetByDocumentNo(_InvoicePayment.ObjectContext, documentEndNo);
//                if(payerInvoiceDocument.Count > 0)
//                    _InvoicePayment.Payer = payerInvoiceDocument[0].Payer;
                
//                BindingList<GeneralInvoiceDocument> generalInvoiceDocument = GeneralInvoiceDocument.GetByDocumentNo(_InvoicePayment.ObjectContext, documentEndNo);
//                if(generalInvoiceDocument.Count > 0)
//                    _InvoicePayment.Payer = ((GeneralInvoice)(generalInvoiceDocument[0].AccountAction)).Payer;
//            }
//#endregion InvoicePaymentForm_FillPayerButton_Click
//        }

//        private void CheckAll_Click()
//        {
//#region InvoicePaymentForm_CheckAll_Click
//   if(this._InvoicePayment.InvoicePaymentPatients.Count > 0)
//            {
//       double totalPrice = 0;
//       double cutOff = 0;
//                foreach (InvoicePaymentPatientList paymentList in this._InvoicePayment.InvoicePaymentPatients)
//                {
//                    paymentList.Paid = true;
//                    totalPrice += Convert.ToDouble(paymentList.InvoiceTotalPrice) ;
//                    cutOff += Convert.ToDouble(paymentList.InvoiceCutOffPrice) ; 
//                }
//                for(int i = 0; i < GridInvoiceList.Rows.Count; i++)
//                {
//                    GridInvoiceList.Rows[i].Cells[5].ReadOnly = false ;
//                }
//                this._InvoicePayment.TotalPrice = totalPrice;
//                this._InvoicePayment.CutOffPrice = cutOff;
//                this._InvoicePayment.PaymentPrice = totalPrice - cutOff;
//                this._InvoicePayment.UpdateBankAccountOrCashFields();
//                this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
//            }
//#endregion InvoicePaymentForm_CheckAll_Click
//        }

//        private void ListButon_Click()
//        {
//#region InvoicePaymentForm_ListButon_Click
//   DateTime sDate =  Convert.ToDateTime("01/01/1900");
//            DateTime eDate = (DateTime)DateTime.Now.Date;
//            double totalPrice = 0;
//            double cutOffPrice = 0;
            
//            string documentStartNo = null;
//            string documentEndNo = null;
//            string documentNo = null;
            
//            if (_InvoicePayment.Payer == null)
//                InfoBox.Show("Kurum seçimi zorunludur!");
//            else
//            {
//                if (_InvoicePayment.InvoiceDateStart != null && _InvoicePayment.InvoiceDateEnd != null)
//                {
//                    sDate = (DateTime)_InvoicePayment.InvoiceDateStart;
//                    eDate = (DateTime)_InvoicePayment.InvoiceDateEnd;
//                }
//                else if (_InvoicePayment.InvoiceDateStart != null && _InvoicePayment.InvoiceDateEnd == null)
//                    sDate = (DateTime)_InvoicePayment.InvoiceDateStart;
//                else if (_InvoicePayment.InvoiceDateStart == null && _InvoicePayment.InvoiceDateEnd != null)
//                    eDate = (DateTime)_InvoicePayment.InvoiceDateEnd;
                
//                documentStartNo = _InvoicePayment.InvoiceDocumentNoStart;
//                documentEndNo = _InvoicePayment.InvoiceDocumentNoEnd;
//                if (documentStartNo != null && documentEndNo == null)
//                    documentNo = documentStartNo;
//                else if (documentStartNo == null && documentEndNo != null)
//                    documentNo = documentEndNo;
                
//                _InvoicePayment.InvoicePaymentPatients.DeleteChildren();
//                _InvoicePayment.CancelledInvoicePatients.DeleteChildren();
                
//                IList payerDocumentList = null;
//                IList collectedDocumentList = null;
//                IList generalDocumentList = null;
//                IList manualDocumentList = null;
                
//                IList cancelledPayerDocumentList = null;
//                IList cancelledGeneralDocumentList = null;
                
//                if (documentNo == null && documentStartNo == null && documentEndNo == null)
//                {
//                    //Sadece tarıhe gore fıltreleme yapılacak.
//                    payerDocumentList = PayerInvoiceDocument.GetByPayerIdAndDateAndState(_InvoicePayment.ObjectContext, (DateTime)sDate, PayerInvoiceDocument.States.Send.ToString(), (DateTime)eDate, _InvoicePayment.Payer.ObjectID.ToString());
//                    collectedDocumentList = CollectedInvoiceDocument.GetByPayerAndDateAndState(_InvoicePayment.ObjectContext, _InvoicePayment.Payer.ObjectID.ToString(), (DateTime)sDate, CollectedInvoiceDocument.States.Send.ToString(), (DateTime)eDate);
//                    generalDocumentList = GeneralInvoiceDocument.GetByPayerAndDateAndState(_InvoicePayment.ObjectContext, (DateTime)sDate, (DateTime)eDate, _InvoicePayment.Payer.ObjectID.ToString(), GeneralInvoiceDocument.States.Send.ToString());
//                    manualDocumentList = ManualInvoiceDocument.GetByPayerAndDateAndState(_InvoicePayment.ObjectContext, (DateTime)sDate, (DateTime)eDate, _InvoicePayment.Payer.ObjectID.ToString(), ManualInvoiceDocument.States.Send.ToString());
                    
//                    //İptal edilen faturalar
//                    cancelledPayerDocumentList = PayerInvoiceDocument.GetByPayerIdAndDateAndState(_InvoicePayment.ObjectContext, (DateTime)sDate, PayerInvoiceDocument.States.Cancelled.ToString(), (DateTime)eDate, _InvoicePayment.Payer.ObjectID.ToString());
//                    cancelledGeneralDocumentList = GeneralInvoiceDocument.GetByPayerAndDateAndState(_InvoicePayment.ObjectContext, (DateTime)sDate, (DateTime)eDate, _InvoicePayment.Payer.ObjectID.ToString(), GeneralInvoiceDocument.States.Cancelled.ToString());
//                }
//                else if (documentStartNo != null && documentEndNo != null)
//                {
//                    //Dokuman aralıgına gore fıltreleme yapılacak
//                    payerDocumentList = PayerInvoiceDocument.GetByPayerIdAndStateAndDocumentNoInterval(_InvoicePayment.ObjectContext, PayerInvoiceDocument.States.Send.ToString(), documentStartNo, documentEndNo, _InvoicePayment.Payer.ObjectID.ToString());
//                    collectedDocumentList = CollectedInvoiceDocument.GetByPayerAndStateAndDocumentNoInterval(_InvoicePayment.ObjectContext, CollectedInvoiceDocument.States.Send.ToString(),_InvoicePayment.Payer.ObjectID.ToString(), documentStartNo, documentEndNo);
//                    generalDocumentList = GeneralInvoiceDocument.GetByPayerAndStateAndDocumentNoInterval(_InvoicePayment.ObjectContext, _InvoicePayment.Payer.ObjectID.ToString(), GeneralInvoiceDocument.States.Send.ToString(), documentStartNo, documentEndNo);
//                    manualDocumentList = ManualInvoiceDocument.GetByPayerAndStateAndDocumentNoInterval(_InvoicePayment.ObjectContext, _InvoicePayment.Payer.ObjectID.ToString(), ManualInvoiceDocument.States.Send.ToString(), documentStartNo, documentEndNo);
                    
//                    //İptal edilen faturalar
//                    cancelledPayerDocumentList = PayerInvoiceDocument.GetByPayerIdAndStateAndDocumentNoInterval(_InvoicePayment.ObjectContext, PayerInvoiceDocument.States.Cancelled.ToString(), documentStartNo, documentEndNo, _InvoicePayment.Payer.ObjectID.ToString());
//                    cancelledGeneralDocumentList = GeneralInvoiceDocument.GetByPayerAndStateAndDocumentNoInterval(_InvoicePayment.ObjectContext, _InvoicePayment.Payer.ObjectID.ToString(), GeneralInvoiceDocument.States.Cancelled.ToString(), documentStartNo, documentEndNo);
//                }
//                else if (documentNo != null)
//                {
//                    //Sadece dokuman no ya gore fıltreleme yapılacak
//                    payerDocumentList = PayerInvoiceDocument.GetByPayerIdAndStateAndDocumentNo(_InvoicePayment.ObjectContext, PayerInvoiceDocument.States.Send.ToString(), documentNo, _InvoicePayment.Payer.ObjectID.ToString());
//                    collectedDocumentList = CollectedInvoiceDocument.GetByPayerAndStateAndDocumentNo(_InvoicePayment.ObjectContext, CollectedInvoiceDocument.States.Send.ToString(), documentNo, _InvoicePayment.Payer.ObjectID.ToString());
//                    generalDocumentList = GeneralInvoiceDocument.GetByPayerAndStateAndDocumentNo(_InvoicePayment.ObjectContext, _InvoicePayment.Payer.ObjectID.ToString(), GeneralInvoiceDocument.States.Send.ToString(), documentNo);
//                    manualDocumentList = ManualInvoiceDocument.GetByPayerAndStateAndDocumentNo(_InvoicePayment.ObjectContext, _InvoicePayment.Payer.ObjectID.ToString(), ManualInvoiceDocument.States.Send.ToString(), documentNo);
                    
//                    //İptal edilen faturalar
//                    cancelledPayerDocumentList = PayerInvoiceDocument.GetByPayerIdAndStateAndDocumentNo(_InvoicePayment.ObjectContext, PayerInvoiceDocument.States.Cancelled.ToString(), documentNo, _InvoicePayment.Payer.ObjectID.ToString());
//                    cancelledGeneralDocumentList = GeneralInvoiceDocument.GetByPayerAndStateAndDocumentNo(_InvoicePayment.ObjectContext, _InvoicePayment.Payer.ObjectID.ToString(), GeneralInvoiceDocument.States.Cancelled.ToString(), documentNo);
//                }
                
//                foreach (CollectedInvoiceDocument collDoc in collectedDocumentList)
//                {
//                    InvoicePaymentPatientList invDet = new InvoicePaymentPatientList(_InvoicePayment.ObjectContext);
//                    invDet.PatientName = "TOPLU FATURA";
//                    invDet.InvoiceDate = (DateTime)collDoc.DocumentDate;
//                    invDet.InvoiceDocumentNo = collDoc.DocumentNo;
//                    invDet.InvoiceTotalPrice = collDoc.TotalPrice;
//                    invDet.InvoiceCutOffPrice = 0;
//                    invDet.Paid = true;
//                    invDet.CollectedInvoiceDocument = collDoc;
                    
//                    totalPrice = totalPrice + (double)collDoc.TotalPrice;
//                    _InvoicePayment.InvoicePaymentPatients.Add(invDet);
//                }
                
//                foreach (PayerInvoiceDocument payerDoc in payerDocumentList)
//                {
//                    InvoicePaymentPatientList invDet = new InvoicePaymentPatientList(_InvoicePayment.ObjectContext);
//                    invDet.PatientNo = payerDoc.EpisodeAccountAction.Episode.Patient.ID.Value;
//                    invDet.PatientName = payerDoc.EpisodeAccountAction.Episode.Patient.FullName;
//                    invDet.InvoiceDate = (DateTime)payerDoc.DocumentDate;
//                    invDet.InvoiceDocumentNo = payerDoc.DocumentNo;
//                    invDet.InvoiceTotalPrice = payerDoc.GeneralTotalPrice;
//                    invDet.InvoiceCutOffPrice = 0;
//                    invDet.Paid = true;
//                    invDet.PayerInvoiceDocument = payerDoc;
                    
//                    totalPrice = totalPrice + (double)payerDoc.GeneralTotalPrice;
//                    _InvoicePayment.InvoicePaymentPatients.Add(invDet);
//                }
                
//                foreach (GeneralInvoiceDocument genDoc in generalDocumentList)
//                {
//                    InvoicePaymentPatientList invDet = new InvoicePaymentPatientList(_InvoicePayment.ObjectContext);
//                    invDet.PatientName = "HİZMET KARŞILIĞI FATURA";
//                    invDet.InvoiceDate = (DateTime)genDoc.DocumentDate;
//                    invDet.InvoiceDocumentNo = genDoc.DocumentNo;
//                    invDet.InvoiceTotalPrice = genDoc.TotalPrice;
//                    invDet.InvoiceCutOffPrice = 0;
//                    invDet.Paid = true;
//                    invDet.GeneralInvoiceDocument = genDoc;
                    
//                    totalPrice = totalPrice + (double)genDoc.TotalPrice;
//                    _InvoicePayment.InvoicePaymentPatients.Add(invDet);
//                }
                
//                foreach (ManualInvoiceDocument mid in manualDocumentList)
//                {
//                    InvoicePaymentPatientList invDet = new InvoicePaymentPatientList(_InvoicePayment.ObjectContext);
//                    invDet.PatientName = ((ManualInvoice)mid.AccountAction).PatientName;
//                    invDet.InvoiceDate = (DateTime)mid.DocumentDate;
//                    invDet.InvoiceDocumentNo = mid.DocumentNo;
//                    invDet.InvoiceTotalPrice = mid.TotalPrice;
//                    invDet.InvoiceCutOffPrice = 0;
//                    invDet.Paid = true;
//                    invDet.ManualInvoiceDocument = mid;

//                    totalPrice = totalPrice + (double)mid.TotalPrice;
//                    _InvoicePayment.InvoicePaymentPatients.Add(invDet);
//                }
                
//                _InvoicePayment.TotalPrice = totalPrice;
//                _InvoicePayment.CutOffPrice = 0;
//                _InvoicePayment.PaymentPrice = totalPrice;
//                _InvoicePayment.PayerPaymentDocument.PayerName = _InvoicePayment.Payer;
//                _InvoicePayment.PayerPaymentDocument.TotalPrice = totalPrice;
//                _InvoicePayment.PayerPaymentDocument.CurrentStateDefID = PayerPaymentDocument.States.New;
                
//                if(this._InvoicePayment.PayerPaymentDocument.BankDecountPayments.Count == 0)
//                {
//                    if(this._InvoicePayment.InvoicePaymentPatients.Count > 0)
//                    {
//                        BindingList<BankAccountDefinition> list = BankAccountDefinition.GetBankAccountToUseInInvoicePayment(this._InvoicePayment.ObjectContext);
//                        if (list.Count > 0)
//                        {
//                            BankDecount decount = new BankDecount(this._InvoicePayment.ObjectContext);
//                            decount.BankAccount = list[0];
//                            decount.Price = 0;
//                            this._InvoicePayment.PayerPaymentDocument.BankDecountPayments.Add(decount);
//                        }
                        
//                    }
//                }
//                this._InvoicePayment.UpdateBankAccountOrCashFields();
//                this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
                
//                //İptal edilen faturaların gride doldurulması için
//                foreach (PayerInvoiceDocument payerDoc in cancelledPayerDocumentList)
//                {
//                    CancelledInvoicePatientList canInv = new CancelledInvoicePatientList(_InvoicePayment.ObjectContext);
//                    canInv.PatientNo = payerDoc.EpisodeAccountAction.Episode.Patient.ID.Value;
//                    canInv.PatientName = payerDoc.EpisodeAccountAction.Episode.Patient.FullName;
//                    canInv.InvoiceDate = (DateTime)payerDoc.DocumentDate;
//                    canInv.InvoiceDocumentNo = payerDoc.DocumentNo;
//                    canInv.InvoiceTotalPrice = payerDoc.GeneralTotalPrice;
//                    if(((PayerInvoice)payerDoc.EpisodeAccountAction).CancelReason != null && ((PayerInvoice)payerDoc.EpisodeAccountAction).CancelReason.Name != null)
//                        canInv.CancelReason = ((PayerInvoice)payerDoc.EpisodeAccountAction).CancelReason.Name;
//                    canInv.PayerInvoiceDocument = payerDoc;
//                    _InvoicePayment.CancelledInvoicePatients.Add(canInv);
//                }
                
//                foreach (GeneralInvoiceDocument genDoc in cancelledGeneralDocumentList)
//                {
//                    CancelledInvoicePatientList canInv = new CancelledInvoicePatientList(_InvoicePayment.ObjectContext);
//                    canInv.PatientName = "HİZMET KARŞILIĞI FATURA";
//                    canInv.InvoiceDate = (DateTime)genDoc.DocumentDate;
//                    canInv.InvoiceDocumentNo = genDoc.DocumentNo;
//                    canInv.InvoiceTotalPrice = genDoc.TotalPrice;
//                    canInv.GeneralInvoiceDocument = genDoc;
//                    _InvoicePayment.CancelledInvoicePatients.Add(canInv);
//                }
//            }
//#endregion InvoicePaymentForm_ListButon_Click
//        }

//        private void GridCashPayment_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region InvoicePaymentForm_GridCashPayment_CellValueChanged
//   if (columnIndex == 0 && rowIndex != -1)
//            {
//                this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
//            }
//#endregion InvoicePaymentForm_GridCashPayment_CellValueChanged
//        }

//        private void GridCashPayment_UserDeletedRow()
//        {
//#region InvoicePaymentForm_GridCashPayment_UserDeletedRow
//   this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
//#endregion InvoicePaymentForm_GridCashPayment_UserDeletedRow
//        }

//        private void GridBankDecountPayment_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region InvoicePaymentForm_GridBankDecountPayment_CellValueChanged
//   if (columnIndex == 2 && rowIndex != -1)
//            {
//                this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
//            }
//#endregion InvoicePaymentForm_GridBankDecountPayment_CellValueChanged
//        }

//        private void GridBankDecountPayment_UserDeletedRow()
//        {
//#region InvoicePaymentForm_GridBankDecountPayment_UserDeletedRow
//   this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
//#endregion InvoicePaymentForm_GridBankDecountPayment_UserDeletedRow
//        }

//        private void GridChequePayment_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region InvoicePaymentForm_GridChequePayment_CellValueChanged
//   if (columnIndex == 1 && rowIndex != -1)
//            {
//                this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();                
//            }
//#endregion InvoicePaymentForm_GridChequePayment_CellValueChanged
//        }

//        private void USEADVANCE_CheckedChanged()
//        {
//#region InvoicePaymentForm_USEADVANCE_CheckedChanged
//   if (this._InvoicePayment.UseAdvance == true)
//            {
//                if (_InvoicePayment.Payer == null)
//                    throw new TTException("Kurum seçimi zorunludur!");
                
//                // Kurum Avans larını getirir
//                IList payerAdvanceList = null;
//                payerAdvanceList = PayerAdvancePayment.GetByPayerAndState(_InvoicePayment.ObjectContext, _InvoicePayment.Payer.ObjectID.ToString(), PayerAdvancePayment.States.Paid.ToString());
                
//                foreach (PayerAdvancePayment payerAdvance in payerAdvanceList)
//                {
//                    PayerPaymentAdvanceList advance = new PayerPaymentAdvanceList(_InvoicePayment.ObjectContext);
//                    advance.RemainingPrice = payerAdvance.RemainingPrice;
//                    advance.UsedPrice = 0;
//                    advance.Used = false;
                    
//                    // Avans, banka dekontu ile ödenmişse Dekont No lar getirilir
//                    string DecountNo = null;
//                    foreach (BankDecount BD in payerAdvance.PayerAdvancePaymentDocument.BankDecountPayments)
//                    {
//                        DecountNo = DecountNo + BD.DecountNo + " , ";
//                    }
                    
//                    if (DecountNo != null)
//                        advance.DecountNo = DecountNo.Substring(0, (DecountNo.Length - 3));
                    
//                    advance.PayerAdvancePayment = payerAdvance;
//                    _InvoicePayment.PayerPaymentAdvances.Add(advance);
//                }
//            }
//            else
//            {
//                _InvoicePayment.PayerPaymentAdvances.Clear();
//                this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment();
//            }
//#endregion InvoicePaymentForm_USEADVANCE_CheckedChanged
//        }

//        private void GridAdvancePayment_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region InvoicePaymentForm_GridAdvancePayment_CellValueChanged
//   if(rowIndex != -1)
//            {
//                if (columnIndex == 4 || columnIndex == 5)
//                {
//                    this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
//                }
//            }
//#endregion InvoicePaymentForm_GridAdvancePayment_CellValueChanged
//        }

//        private void TOTALPAYMENT_TextChanged()
//        {
//#region InvoicePaymentForm_TOTALPAYMENT_TextChanged
//   double totalPayment = 0;
//            if(!string.IsNullOrEmpty(this.TOTALPAYMENT.Text))
//                 totalPayment = Convert.ToDouble(this.TOTALPAYMENT.Text);
//            this.RemainderCheckbox.Text = ((Convert.ToDouble(this.PAYMENTPRICE.Text)) - totalPayment).ToString();
//#endregion InvoicePaymentForm_TOTALPAYMENT_TextChanged
//        }

//        private void UncheckAll_Click()
//        {
//#region InvoicePaymentForm_UncheckAll_Click
//   if(this._InvoicePayment.InvoicePaymentPatients.Count > 0)
//            {
//                foreach (InvoicePaymentPatientList paymentList in this._InvoicePayment.InvoicePaymentPatients)
//                {
//                    paymentList.Paid = false;
//                }
//                _InvoicePayment.TotalPrice= 0;
//                _InvoicePayment.CutOffPrice = 0;
//                _InvoicePayment.PaymentPrice = 0;
//                for(int i = 0; i < GridInvoiceList.Rows.Count; i++)
//                    GridInvoiceList.Rows[i].Cells[5].ReadOnly = true;
//                this._InvoicePayment.UpdateBankAccountOrCashFields();
//                this._InvoicePayment.TotalPayment = this._InvoicePayment.PayerPaymentDocument.GetTotalPayment() + this._InvoicePayment.GetTotalUsedAdvancePayment();
//            }
//#endregion InvoicePaymentForm_UncheckAll_Click
//        }

//        protected override void PreScript()
//        {
//#region InvoicePaymentForm_PreScript
//    if (_InvoicePayment.CurrentStateDefID == InvoicePayment.States.New)
//            {
//                this.ListButon.ReadOnly = false;
//                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

//                CashierLog  _myCashierLog = null;
//                if (_myResUser != null)
//                    _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
                
//                if (_myCashierLog == null)
//                    throw new TTUtils.TTException(SystemMessage.GetMessage(210));
//                else
//                {
//                    /*
//                    if (_myCashierLog.CashOffice.Type != CashOfficeTypeEnum.InvoicingService)
//                        throw new TTUtils.TTException(SystemMessage.GetMessage(210));
//                    else
//                    {
//                     */
//                    this.cmdOK.Visible = false;
//                    _InvoicePayment.CashOfficeName = _myCashierLog.CashOffice.Name;

//                    if (_InvoicePayment.PayerPaymentDocument == null)
//                    {
//                        _InvoicePayment.PayerPaymentDocument = new PayerPaymentDocument(_InvoicePayment.ObjectContext);
//                        _InvoicePayment.PayerPaymentDocument.CashierLog = _myCashierLog;
//                        _InvoicePayment.PayerPaymentDocument.DocumentDate = DateTime.Now.Date;
//                    }
//                    _InvoicePayment.InvoiceDateStart = DateTime.Now.Date;
//                    _InvoicePayment.InvoiceDateEnd = DateTime.Now.Date;
//                    //}
//                }
//            }
//            else
//            {
//                this.ListButon.ReadOnly = true;
//                this.CheckAll.ReadOnly = true;
//                this.UncheckAll.ReadOnly = true;
//                this.FillPayerButton.ReadOnly = true;
//            }
//#endregion InvoicePaymentForm_PreScript

//            }
//                }
//}