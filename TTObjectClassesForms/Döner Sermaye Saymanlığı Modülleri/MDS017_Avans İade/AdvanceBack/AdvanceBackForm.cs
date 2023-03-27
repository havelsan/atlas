
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
    /// Avans İade
    /// </summary>
    public partial class AdvanceBackForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }
        CashOfficeDefinition selectedCashOffice;
        protected override void ClientSidePreScript()
        {
            #region AdvanceBackForm_PreScript
            if (_AdvanceBack.CurrentStateDefID == AdvanceBack.States.New)
            {
                double advanceTotal = 0;
                double receiptTotal = 0;
                double advanceBackTotal = 0;
                double receiptBackTotal = 0;
                double serviceTotal = 0;

                ResUser resUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);

                if (selectedCashOffice == null)
                    throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Avans iade etmeye yetikiniz bulunmamaktadır!");

                this.cmdOK.Visible = false;

                //Episode da tamamlanmamis bir Avans Iade varsa yenisi baslatilmayacak
                foreach (AdvanceBack ea in _AdvanceBack.Episode.AdvanceBacks)
                {
                    if (ea.IsCancelled == false)
                    {
                        if (ea != null)
                        {
                            if (ea.ObjectID != _AdvanceBack.ObjectID && ea.CurrentStateDefID != AdvanceBack.States.Paid)
                                throw new TTUtils.TTException(SystemMessage.GetMessage(181));
                        }
                    }
                }

                _AdvanceBack.CashOfficeName = selectedCashOffice.Name;

                if (_AdvanceBack.AdvanceBackDocument == null)
                {
                    _AdvanceBack.AdvanceBackDocument = new AdvanceBackDocument(_AdvanceBack.ObjectContext);
                    _AdvanceBack.AdvanceBackDocument.CashOffice = selectedCashOffice;
                    _AdvanceBack.AdvanceBackDocument.DocumentDate = DateTime.Now.Date;
                    _AdvanceBack.AdvanceBackDocument.PatientName = _AdvanceBack.Episode.Patient.Name + " " + _AdvanceBack.Episode.Patient.Surname;
                    _AdvanceBack.AdvanceBackDocument.PatientNo = _AdvanceBack.Episode.Patient.ID.Value;
                    _AdvanceBack.AdvanceBackDocument.CurrentStateDefID = AdvanceBackDocument.States.New;
                    _AdvanceBack.AdvanceBackDocument.ResUser = resUser;

                    foreach (EpisodeAction ea in _AdvanceBack.Episode.EpisodeActions)
                    {
                        if (ea.IsCancelled == false)
                        {
                            Advance advanceAct = ea as Advance;
                            if (advanceAct != null)
                            {
                                AdvanceBackAdvanceDetail advDetail = new AdvanceBackAdvanceDetail(_AdvanceBack.ObjectContext);
                                advDetail.AdvanceDate = advanceAct.AdvanceDocument.DocumentDate;
                                advDetail.AdvanceDocumentNo = advanceAct.AdvanceDocument.DocumentNo;
                                advDetail.AdvanceCrCardDocumentNo = advanceAct.AdvanceDocument.CreditCardDocumentNo;
                                advDetail.TotalPrice = advanceAct.AdvanceDocument.TotalPrice;
                                advDetail.Status = advanceAct.AdvanceDocument.CurrentStateDef.DisplayText;
                                _AdvanceBack.AdvanceBackAdvanceDetail.Add(advDetail);
                                if (advanceAct.AdvanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid)
                                    advanceTotal = advanceTotal + (double)advanceAct.AdvanceDocument.TotalPrice;
                            }
                            Receipt receiptAct = ea as Receipt;
                            if (receiptAct != null)
                            {
                                if (receiptAct.ReceiptDocument.CurrentStateDefID == ReceiptDocument.States.Paid)
                                    receiptTotal = receiptTotal + (double)receiptAct.TotalPayment;
                            }
                            AdvanceBack advBackAct = ea as AdvanceBack;
                            if (advBackAct != null)
                            {
                                if (advBackAct.AdvanceBackDocument.CurrentStateDefID == AdvanceBackDocument.States.Paid)
                                    advanceBackTotal = advanceBackTotal + (double)advBackAct.AdvanceBackDocument.TotalPrice;
                            }
                            ReceiptBack ReceiptBackAct = ea as ReceiptBack;
                            if (ReceiptBackAct != null)
                            {
                                if (ReceiptBackAct.ReceiptBackDocument.CurrentStateDefID == ReceiptBackDocument.States.Paid)
                                    receiptBackTotal = receiptBackTotal + (double)ReceiptBackAct.ReceiptBackDocument.TotalPrice;
                            }
                        }
                    }

                    IList transactionsList = AccountTransaction.GetIncludedTrxsExceptCancelledByEpisode(_AdvanceBack.ObjectContext, _AdvanceBack.Episode.Patient.MyAPR().ObjectID, _AdvanceBack.Episode.ObjectID);
                    foreach (AccountTransaction accTrx in transactionsList)
                    {
                        if (accTrx.PackageDefinition == null && accTrx.InvoiceInclusion == true)  // Paket içi hizmet/malzemeler toplama dahil edilmez
                            serviceTotal = serviceTotal + (double)(accTrx.UnitPrice * accTrx.Amount);
                    }

                    _AdvanceBack.ADVANCETOTAL = advanceTotal;
                    _AdvanceBack.RECEIPTTOTAL = receiptTotal;
                    _AdvanceBack.ADVANCEBACKTOTAL = advanceBackTotal;
                    _AdvanceBack.RECEIPTBACKTOTAL = receiptBackTotal;
                    _AdvanceBack.SERVICETOTAL = serviceTotal;

                    if ((advanceTotal + receiptTotal) - (advanceBackTotal + receiptBackTotal + serviceTotal) <= 0)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(177));
                    else
                        _AdvanceBack.TotalPrice = (advanceTotal + receiptTotal) - (advanceBackTotal + receiptBackTotal + serviceTotal);

                    _AdvanceBack.AdvanceBackDocument.TotalPrice = _AdvanceBack.TotalPrice;
                }
            }
            #endregion AdvanceBackForm_PreScript

        }
    }
}