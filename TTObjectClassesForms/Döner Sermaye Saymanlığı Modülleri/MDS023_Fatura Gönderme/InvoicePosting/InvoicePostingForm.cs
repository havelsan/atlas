
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
    /// Fatura Gönderme
    /// </summary>
    public partial class InvoicePostingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            CheckAll.Click += new TTControlEventDelegate(CheckAll_Click);
            GRIDInvoiceLists.CellValueChanged += new TTGridCellEventDelegate(GRIDInvoiceLists_CellValueChanged);
            ListButton.Click += new TTControlEventDelegate(ListButton_Click);
            UncheckAll.Click += new TTControlEventDelegate(UncheckAll_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            CheckAll.Click -= new TTControlEventDelegate(CheckAll_Click);
            GRIDInvoiceLists.CellValueChanged -= new TTGridCellEventDelegate(GRIDInvoiceLists_CellValueChanged);
            ListButton.Click -= new TTControlEventDelegate(ListButton_Click);
            UncheckAll.Click -= new TTControlEventDelegate(UncheckAll_Click);
            base.UnBindControlEvents();
        }

        private void CheckAll_Click()
        {
#region InvoicePostingForm_CheckAll_Click
   double totalPrice = 0;
            foreach(InvoicePostDetail invoicePost in this._InvoicePosting.InvoicePostDetails)
            {
                invoicePost.Send = true;
                totalPrice += Convert.ToDouble(invoicePost.PayerInvoiceDocument.GeneralTotalPrice);
            }
            this._InvoicePosting.TotalPrice = totalPrice;
#endregion InvoicePostingForm_CheckAll_Click
        }

        private void GRIDInvoiceLists_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region InvoicePostingForm_GRIDInvoiceLists_CellValueChanged
   if (columnIndex == 9 && rowIndex != -1)
                {
                    if (GRIDInvoiceLists.Rows[rowIndex].Cells[columnIndex].Value.ToString() ==  "False")
                        _InvoicePosting.TotalPrice = _InvoicePosting.TotalPrice - Convert.ToDouble(GRIDInvoiceLists.Rows[rowIndex].Cells[8].Value);
                    else if (GRIDInvoiceLists.Rows[rowIndex].Cells[columnIndex].Value.ToString() ==  "True")
                        _InvoicePosting.TotalPrice= _InvoicePosting.TotalPrice + Convert.ToDouble(GRIDInvoiceLists.Rows[rowIndex].Cells[8].Value);
                }
#endregion InvoicePostingForm_GRIDInvoiceLists_CellValueChanged
        }

        private void ListButton_Click()
        {
#region InvoicePostingForm_ListButton_Click
   DateTime sDate =  Convert.ToDateTime("01/01/1900");
            DateTime eDate = (DateTime)DateTime.Now.Date;
            
            if (_InvoicePosting.StartDate != null)
                sDate = (DateTime)_InvoicePosting.StartDate;
            
            if (_InvoicePosting.EndDate != null)
                eDate = (DateTime)_InvoicePosting.EndDate;
            
            PayerInvoice myPayerInvoice;
            double totalPrice = 0;
            IList payerList = null;
            IList payerInvoiceDocumentList = null;
            bool patientStatusFlag;
            bool invoiceTypeFlag;
            int counter = 0;
            long payerCodeStart = 0;
            long payerCodeEnd = 0;
            
            if (_InvoicePosting.PayerCodeStart != null)
                payerCodeStart = (long)_InvoicePosting.PayerCodeStart;
            if (_InvoicePosting.PayerCodeEnd != null)
                payerCodeEnd = (long)_InvoicePosting.PayerCodeEnd;
            
            string documentStartNo = (string)_InvoicePosting.InvoiceDocumentNoStart;
            string documentEndNo = (string)_InvoicePosting.InvoiceDocumentNoEnd;
            string documentNo = null;
            
            if (documentStartNo != null && documentEndNo == null)
                documentNo = documentStartNo;
            else if (documentStartNo == null && documentEndNo != null)
                documentNo = documentEndNo;

            if (payerCodeStart == 0 && payerCodeEnd == 0 && documentStartNo == null && documentEndNo == null)
                TTVisual.InfoBox.Show("Kurum Kodu (Başlangıç), Kurum Kodu (Bitiş), Fatura No (Başlangıç), Fatura No (Bitiş) alanlarından en az birini girmek zorunludur!", MessageIconEnum.WarningMessage);
            else
            {
                _InvoicePosting.InvoicePostDetails.DeleteChildren();
                
                if (payerCodeStart != 0 || payerCodeEnd != 0)  // Kurum Kodu girilmişse
                {
                    counter = 0;
                    if (documentStartNo == null && documentEndNo == null)
                        payerInvoiceDocumentList = PayerInvoiceDocument.GetByPayerAndDateAndState(_InvoicePosting.ObjectContext, (DateTime)sDate, PayerInvoiceDocument.States.Invoiced.ToString(), (DateTime)eDate, payerCodeStart , payerCodeEnd);
                    else if (documentStartNo != null && documentEndNo != null)
                        payerInvoiceDocumentList = PayerInvoiceDocument.GetByPayerAndStateAndDocumentNoInterval(_InvoicePosting.ObjectContext, PayerInvoiceDocument.States.Invoiced.ToString(), documentStartNo, documentEndNo, payerCodeStart , payerCodeEnd);
                    else if (documentNo != null)
                        payerInvoiceDocumentList = PayerInvoiceDocument.GetByPayerAndStateAndDocumentNo(_InvoicePosting.ObjectContext, PayerInvoiceDocument.States.Invoiced.ToString(), documentNo, payerCodeStart , payerCodeEnd);
                    
                    foreach (PayerInvoiceDocument payerDoc in payerInvoiceDocumentList)
                    {
                        if (counter ++ < payerDoc.Payer.LimitOfInvoiceSummaryList)
                        {
                            patientStatusFlag = false;
                            invoiceTypeFlag = false;
                            
                            myPayerInvoice = payerDoc.MyPayerInvoice();
                            if (_InvoicePosting.PatientStatus.Value.ToString() == "OutPatient" && myPayerInvoice.Episode.PatientStatus.Value.ToString() == "Outpatient" && myPayerInvoice.SubEpisode.PatientAdmission.AdmissionType.ToString() != "NewBorn")
                                patientStatusFlag = true;
                            else if (_InvoicePosting.PatientStatus.Value.ToString() == "InPatient" && (myPayerInvoice.Episode.PatientStatus.Value.ToString() == "Inpatient" || myPayerInvoice.Episode.PatientStatus.Value.ToString() == "Discharge") && myPayerInvoice.SubEpisode.PatientAdmission.AdmissionType.ToString() != "NewBorn")
                                patientStatusFlag = true;
                            else if (_InvoicePosting.PatientStatus.Value.ToString() == "NewBorn" && myPayerInvoice.SubEpisode.PatientAdmission.AdmissionType.ToString() == "NewBorn")
                                patientStatusFlag = true;
                            
                            if (_InvoicePosting.InvoiceType == null)
                                invoiceTypeFlag = true;
                            else if (_InvoicePosting.InvoiceType == payerDoc.InvoicePostingInvoiceType)
                                invoiceTypeFlag = true;
                            
                            if (patientStatusFlag && invoiceTypeFlag)
                            {
                                InvoicePostDetail invDet = new InvoicePostDetail(_InvoicePosting.ObjectContext);
                                invDet.Send = true;
                                invDet.PayerInvoiceDocument = payerDoc;
                                
                                totalPrice = totalPrice + (double)payerDoc.GeneralTotalPrice;
                                _InvoicePosting.InvoicePostDetails.Add(invDet);
                            }
                        }
                    }
                }
                else if (documentStartNo != null || documentEndNo != null)   // Kurum Kodu girilmemişse
                {
                    if (documentStartNo != null && documentEndNo != null)
                        payerInvoiceDocumentList = PayerInvoiceDocument.GetByStateAndDocumentNoInterval(_InvoicePosting.ObjectContext, PayerInvoiceDocument.States.Invoiced.ToString(), documentStartNo, documentEndNo);
                    else if (documentNo != null)
                        payerInvoiceDocumentList = PayerInvoiceDocument.GetByStateAndDocumentNo(_InvoicePosting.ObjectContext, PayerInvoiceDocument.States.Invoiced.ToString(), documentNo);
                    
                    PayerDefinition tempPayer = null;
                    
                    foreach (PayerInvoiceDocument payerDoc in payerInvoiceDocumentList)
                    {
                        if (tempPayer != payerDoc.Payer)
                        {
                            counter = 0;
                            tempPayer = payerDoc.Payer;
                        }
                        
                        if (counter ++ < payerDoc.Payer.LimitOfInvoiceSummaryList)
                        {
                            patientStatusFlag = false;
                            invoiceTypeFlag = false;
                            
                            myPayerInvoice = payerDoc.MyPayerInvoice();
                            if (_InvoicePosting.PatientStatus.Value.ToString() == "OutPatient" && myPayerInvoice.Episode.PatientStatus.Value.ToString() == "Outpatient" && myPayerInvoice.SubEpisode.PatientAdmission.AdmissionType.ToString() != "NewBorn")
                                patientStatusFlag = true;
                            else if (_InvoicePosting.PatientStatus.Value.ToString() == "InPatient" && (myPayerInvoice.Episode.PatientStatus.Value.ToString() == "Inpatient" || myPayerInvoice.Episode.PatientStatus.Value.ToString() == "Discharge") && myPayerInvoice.SubEpisode.PatientAdmission.AdmissionType.ToString() != "NewBorn")
                                patientStatusFlag = true;
                            else if (_InvoicePosting.PatientStatus.Value.ToString() == "NewBorn" && myPayerInvoice.SubEpisode.PatientAdmission.AdmissionType.ToString() == "NewBorn")
                                patientStatusFlag = true;
                            
                            if (_InvoicePosting.InvoiceType == null)
                                invoiceTypeFlag = true;
                            else if (_InvoicePosting.InvoiceType == payerDoc.InvoicePostingInvoiceType)
                                invoiceTypeFlag = true;
                            
                            if (patientStatusFlag && invoiceTypeFlag)
                            {
                                InvoicePostDetail invDet = new InvoicePostDetail(_InvoicePosting.ObjectContext);
                                invDet.Send = true;
                                invDet.PayerInvoiceDocument = payerDoc;
                                
                                totalPrice = totalPrice + (double)payerDoc.GeneralTotalPrice;
                                _InvoicePosting.InvoicePostDetails.Add(invDet);
                            }
                        }
                    }
                }
                _InvoicePosting.TotalPrice = totalPrice;
            }
#endregion InvoicePostingForm_ListButton_Click
        }

        private void UncheckAll_Click()
        {
#region InvoicePostingForm_UncheckAll_Click
   foreach(InvoicePostDetail invoicePost in this._InvoicePosting.InvoicePostDetails)
            {
                invoicePost.Send = false;
            }
            this._InvoicePosting.TotalPrice = 0;
#endregion InvoicePostingForm_UncheckAll_Click
        }

        protected override void PreScript()
        {
#region InvoicePostingForm_PreScript
    this.cmdOK.Visible = false;
            if (_InvoicePosting.CurrentStateDefID == InvoicePosting.States.New)
            {
                _InvoicePosting.StartDate = DateTime.Now.Date;
                _InvoicePosting.EndDate = DateTime.Now.Date;
                _InvoicePosting.PatientStatus = InvoicePostingPatientStatusEnum.OutPatient;
                this.ListButton.ReadOnly = false;
            }
            else
                this.ListButton.ReadOnly = true;
#endregion InvoicePostingForm_PreScript

            }
                }
}