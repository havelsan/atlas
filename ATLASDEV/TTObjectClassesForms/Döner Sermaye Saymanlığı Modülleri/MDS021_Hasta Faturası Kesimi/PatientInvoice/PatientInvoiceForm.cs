
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
    /// Hasta Faturası
    /// </summary>
    public partial class PatientInvoiceForm : TTForm
    {
        override protected void BindControlEvents()
        {
            GRIDPatientInvoiceProcedures.CellValueChanged += new TTGridCellEventDelegate(GRIDPatientInvoiceProcedures_CellValueChanged);
            GRIDPatientInvoiceMaterials.CellValueChanged += new TTGridCellEventDelegate(GRIDPatientInvoiceMaterials_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GRIDPatientInvoiceProcedures.CellValueChanged -= new TTGridCellEventDelegate(GRIDPatientInvoiceProcedures_CellValueChanged);
            GRIDPatientInvoiceMaterials.CellValueChanged -= new TTGridCellEventDelegate(GRIDPatientInvoiceMaterials_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GRIDPatientInvoiceProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region PatientInvoiceForm_GRIDPatientInvoiceProcedures_CellValueChanged
            if (columnIndex == 6 && rowIndex != -1)
            {
                if (GRIDPatientInvoiceProcedures.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False")
                {
                    _PatientInvoice.TotalPrice = _PatientInvoice.TotalPrice - Convert.ToDouble(GRIDPatientInvoiceProcedures.Rows[rowIndex].Cells[5].Value);
                }
                else if (GRIDPatientInvoiceProcedures.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True")
                {
                    _PatientInvoice.TotalPrice = _PatientInvoice.TotalPrice + Convert.ToDouble(GRIDPatientInvoiceProcedures.Rows[rowIndex].Cells[5].Value);
                }
            }
            #endregion PatientInvoiceForm_GRIDPatientInvoiceProcedures_CellValueChanged
        }

        private void GRIDPatientInvoiceMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region PatientInvoiceForm_GRIDPatientInvoiceMaterials_CellValueChanged
            if (columnIndex == 6 && rowIndex != -1)
            {
                if (GRIDPatientInvoiceMaterials.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False")
                {
                    _PatientInvoice.TotalPrice = _PatientInvoice.TotalPrice - Convert.ToDouble(GRIDPatientInvoiceMaterials.Rows[rowIndex].Cells[5].Value);
                }
                else if (GRIDPatientInvoiceMaterials.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True")
                {
                    _PatientInvoice.TotalPrice = _PatientInvoice.TotalPrice + Convert.ToDouble(GRIDPatientInvoiceMaterials.Rows[rowIndex].Cells[5].Value);
                }
            }
            #endregion PatientInvoiceForm_GRIDPatientInvoiceMaterials_CellValueChanged
        }

        protected override void ClientSidePreScript()
        {
            #region PatientInvoiceForm_PreScript
            if (_PatientInvoice.CurrentStateDefID == PatientInvoice.States.New)
            {

                ResUser resUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

                CashOfficeDefinition selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.InvoicingService,resUser);

                if (selectedCashOffice == null)
                    throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Hasta Faturası kesmeye yetikiniz bulunmamaktadır!");

                this.cmdOK.Visible = false;
                _PatientInvoice.CashOfficeName = selectedCashOffice.Name;

                if (_PatientInvoice.PatientInvoiceDocument == null)
                {
                    _PatientInvoice.PatientInvoiceDocument = new PatientInvoiceDocument(_PatientInvoice.ObjectContext);
                    _PatientInvoice.PatientInvoiceDocument.CashOffice = selectedCashOffice;
                    _PatientInvoice.PatientInvoiceDocument.DocumentDate = DateTime.Now.Date;
                    _PatientInvoice.PatientInvoiceDocument.ResUser = resUser;

                    IList myList = InvoiceCashOfficeDefinition.GetByCashOffice(_PatientInvoice.ObjectContext, selectedCashOffice.ObjectID.ToString());
                    if (myList.Count == 0)
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(213, new string[] { _PatientInvoice.CashOfficeName }));
                    else
                    {
                        InvoiceCashOfficeDefinition _myInvoiceCashOfficeDefinition = (InvoiceCashOfficeDefinition)myList[0];
                        _PatientInvoice.PatientInvoiceDocument.DocumentNo = (string)InvoiceCashOfficeDefinition.GetCurrentInvoiceNumber(_myInvoiceCashOfficeDefinition);
                    }

                    Episode myEpisode = _PatientInvoice.Episode;
                    //Formdaki Patient ile ilgili alanlari set et
                    _PatientInvoice.PatientInvoiceDocument.PatientName = myEpisode.Patient.Name + " " + myEpisode.Patient.Surname;
                    _PatientInvoice.PatientInvoiceDocument.PatientNo = myEpisode.Patient.ID.Value;
                    _PatientInvoice.PatientInvoiceDocument.Address = myEpisode.Patient.PatientAddress.HomeAddress;
                    _PatientInvoice.PatientInvoiceDocument.Patient = myEpisode.Patient;

                    //Gridlerdeki verilerin doldurulmasi
                    double totalPrice = 0;

                    AccountPayableReceivable myAPR = myEpisode.Patient.MyAPR();
                    if (myAPR == null)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(221));
                    else
                    {
                        if (_PatientInvoice.CurrentStateDefID == PatientInvoice.States.New)
                        {
                            IList transactionList = AccountTransaction.GetTransactionsForReceiptByEpisode(_PatientInvoice.ObjectContext, AccountTransaction.States.Paid, myEpisode.ObjectID, myAPR.ObjectID);
                            foreach (AccountTransaction accTrx in transactionList)
                            {
                                if (accTrx.PackageDefinition == null)
                                {
                                    if (accTrx.SubActionProcedure != null) // && accTrx.PatientInvoiceProcedure == null)
                                    {
                                        PatientInvoiceProcedure invproc = new PatientInvoiceProcedure(_PatientInvoice.ObjectContext);
                                        invproc.ActionDate = accTrx.TransactionDate.Value;

                                        if (accTrx.ExternalCode != null)
                                        {
                                            if (accTrx.ExternalCode == "520010" && accTrx.SubActionProcedure.ProcedureSpeciality != null)
                                            {
                                                if (accTrx.Description.IndexOf(accTrx.SubActionProcedure.ProcedureSpeciality.Name) == -1)
                                                    accTrx.Description += " (" + accTrx.SubActionProcedure.ProcedureSpeciality.Name + ")";
                                            }
                                        }

                                        invproc.Description = accTrx.Description;
                                        invproc.ExternalCode = accTrx.ExternalCode;
                                        invproc.Amount = (int)accTrx.Amount;

                                        if (accTrx.ReceiptProcedure != null)
                                        {
                                            if (accTrx.ReceiptProcedure.Receipt.CurrentStateDefID == Receipt.States.Paid)
                                            {
                                                invproc.UnitPrice = (double)(accTrx.ReceiptProcedure.TotalDiscountedPrice / (int)accTrx.Amount);
                                                invproc.TotalPrice = accTrx.ReceiptProcedure.TotalDiscountedPrice;
                                            }
                                        }
                                        else
                                        {
                                            invproc.UnitPrice = accTrx.UnitPrice;
                                            invproc.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
                                        }

                                        invproc.Paid = true;
                                        invproc.AccountTransaction.Add(accTrx);

                                        _PatientInvoice.PatientInvoiceProcedures.Add(invproc);
                                        totalPrice = totalPrice + (double)invproc.TotalPrice;
                                    }

                                    if (accTrx.SubActionMaterial != null) // && accTrx.PatientInvoiceMaterial == null)
                                    {
                                        PatientInvoiceMaterial invmat = new PatientInvoiceMaterial(_PatientInvoice.ObjectContext);
                                        invmat.ActionDate = (DateTime)accTrx.TransactionDate;
                                        invmat.Description = accTrx.Description;
                                        invmat.ExternalCode = accTrx.ExternalCode;
                                        invmat.Amount = accTrx.Amount;

                                        if (accTrx.ReceiptMaterial != null)
                                        {
                                            if (accTrx.ReceiptMaterial.Receipt.CurrentStateDefID == Receipt.States.Paid)
                                            {
                                                invmat.UnitPrice = (double)(accTrx.ReceiptMaterial.TotalDiscountedPrice / accTrx.Amount);
                                                invmat.TotalPrice = accTrx.ReceiptMaterial.TotalDiscountedPrice;
                                            }
                                        }
                                        else
                                        {
                                            invmat.UnitPrice = accTrx.UnitPrice;
                                            invmat.TotalPrice = (double)(accTrx.Amount * accTrx.UnitPrice);
                                        }

                                        invmat.Paid = true;
                                        invmat.AccountTransaction.Add(accTrx);

                                        _PatientInvoice.PatientInvoiceMaterials.Add(invmat);
                                        totalPrice = totalPrice + (double)invmat.TotalPrice;
                                    }
                                }
                            }

                            _PatientInvoice.TotalPrice = totalPrice;
                            _PatientInvoice.PatientInvoiceDocument.TotalPrice = _PatientInvoice.TotalPrice;
                            _PatientInvoice.PatientInvoiceDocument.CurrentStateDefID = PatientInvoiceDocument.States.New;
                        }
                    }
                }
            }
            #endregion PatientInvoiceForm_PreScript

        }
    }
}