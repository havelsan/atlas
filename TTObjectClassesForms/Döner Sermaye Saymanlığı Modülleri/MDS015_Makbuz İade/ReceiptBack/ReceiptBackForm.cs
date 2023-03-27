
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
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade İşlemi
    /// </summary>
    public partial class ReceiptBackForm : TTForm
    {
        override protected void BindControlEvents()
        {
            lstBoxReceipts.SelectedObjectChanged += new TTControlEventDelegate(lstBoxReceipts_SelectedObjectChanged);
            GRIDReceiptBackDetails.CellValueChanged += new TTGridCellEventDelegate(GRIDReceiptBackDetails_CellValueChanged);
            BTNLISTDETAIL.Click += new TTControlEventDelegate(BTNLISTDETAIL_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            lstBoxReceipts.SelectedObjectChanged -= new TTControlEventDelegate(lstBoxReceipts_SelectedObjectChanged);
            GRIDReceiptBackDetails.CellValueChanged -= new TTGridCellEventDelegate(GRIDReceiptBackDetails_CellValueChanged);
            BTNLISTDETAIL.Click -= new TTControlEventDelegate(BTNLISTDETAIL_Click);
            base.UnBindControlEvents();
        }
        private void lstBoxReceipts_SelectedObjectChanged()
        {
            if (_ReceiptBack.Receipt != null)
            {
                //IList receiptList = null;
                /*
                receiptList = ReceiptDocument.GetByDocumentNoAndState(_ReceiptBack.ObjectContext, _ReceiptBack.ReceiptNo.ToString().ToUpper(), ReceiptDocument.States.Paid.ToString(), _ReceiptBack.Episode.ObjectID.ToString());
                if(receiptList.Count == 0)
                    receiptList = ReceiptDocument.GetByCreditCardDocumentNoAndState(_ReceiptBack.ObjectContext, _ReceiptBack.ReceiptNo.ToString().ToUpper(), ReceiptDocument.States.Paid.ToString(), _ReceiptBack.Episode.ObjectID.ToString());
                */
                /*receiptList = Receipt.GetByEpisodeStateAndDocumentNo(_ReceiptBack.ObjectContext, _ReceiptBack.Episode.ObjectID.ToString(), Receipt.States.Paid.ToString(), _ReceiptBack.ReceiptNo.ToUpper());
                if (receiptList.Count == 0)
                    receiptList = Receipt.GetByEpisodeStateAndCreditCardDocumentNo(_ReceiptBack.ObjectContext, _ReceiptBack.Episode.ObjectID.ToString(), Receipt.States.Paid.ToString(), _ReceiptBack.ReceiptNo.ToUpper());

                if (receiptList.Count == 0)
                    throw new TTException("Vakada " + _ReceiptBack.ReceiptNo + " numaralı ve Ödendi durumunda olan Muhasebe Yetkilisi Mutemedi Alındısı işlemi bulunamadı. Muhasebe Yetkilisi Mutemedi Alındı numarasını kontrol ediniz!");*/
                //else
                //{

                Receipt receipt = this._ReceiptBack.Receipt;/*(Receipt)receiptList[0];*/

                /*if (_ReceiptBack.ReceiptBackDocument.CashierLog.CashOffice.Type == CashOfficeTypeEnum.SubCashOffice && receipt.ReceiptDocument.CashierLog.ClosingDate != null)
                {
                    string msg = _ReceiptBack.ReceiptNo.ToString() + " numaralı Muhasebe Yetkilisi Mutemedi Alındısı işleminin yapıldığı Muhasebe Yetkilisi Mutemetliği kapandığı için iade işlemi yapılamaz! İade işlemi Vezne tarafından yapılmalıdır.";
                    InfoBox.Show(msg);
                }*/
                //else
                //{

                //_ReceiptBack.ReceiptTotalPrice = (double)receipt.ReceiptDocument.PaymentPrice;

                foreach (ReceiptBackDetail backDetail in _ReceiptBack.ReceiptBackDetails)
                {
                    backDetail.AccountTransaction.Clear();
                }
                _ReceiptBack.ReceiptBackDetails.DeleteChildren();

                foreach (ReceiptDocumentGroup receiptDocGroup in receipt.ReceiptDocument.ReceiptDocumentGroups)
                {
                    foreach (ReceiptDocumentDetail receiptDocDetail in receiptDocGroup.ReceiptDocumentDetails)
                    {
                        ReceiptBackDetail _receiptBackDetail = new ReceiptBackDetail(_ReceiptBack.ObjectContext);
                        PatientPaymentDetail ppDetail = ReceiptDocument.GetPatientPaymentDetail(receiptDocDetail.AccountTrxDocument[0].AccountTransaction.ObjectID, receipt.ReceiptDocument);

                        if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID != AccountTransaction.States.Cancelled)
                            _receiptBackDetail.AccountTransaction.Add(receiptDocDetail.AccountTrxDocument[0].AccountTransaction);
                        _receiptBackDetail.ReceiptDocumentDetail = receiptDocDetail;

                        _receiptBackDetail.ActionDate = (DateTime)receiptDocDetail.AccountTrxDocument[0].AccountTransaction.TransactionDate.Value;
                        _receiptBackDetail.Amount = receiptDocDetail.Amount;
                        _receiptBackDetail.ExternalCode = receiptDocDetail.ExternalCode;
                        _receiptBackDetail.Description = receiptDocDetail.Description;
                        _receiptBackDetail.UnitPrice = receiptDocDetail.UnitPrice;
                        //_receiptBackDetail.TotalDiscountedPrice = receiptDocDetail.TotalDiscountedPrice;
                        _receiptBackDetail.TotalPrice = (double)receiptDocDetail.Amount * (double)receiptDocDetail.UnitPrice;
                        _receiptBackDetail.PaymentPrice = ppDetail.PaymentPrice;

                        if ((receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure) != null)
                        {
                            if ((receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure).ObjectDef.ToString() == "LABORATORYPROCEDURE")
                            {
                                if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDefID == LaboratoryProcedure.States.PendingCancel)
                                {
                                    _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDef.DisplayText.ToString();
                                    //_receiptBackDetail.ReadOnlyFlag = false;
                                    _receiptBackDetail.Editable = true;
                                }
                                else if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDefID == LaboratoryProcedure.States.Completed)
                                {
                                    _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDef.DisplayText.ToString();
                                    //_receiptBackDetail.ReadOnlyFlag = true;
                                    _receiptBackDetail.Editable = false;
                                }
                                else
                                {
                                    _receiptBackDetail.State = receiptDocDetail.CurrentStateDef.DisplayText.ToString();
                                    //_receiptBackDetail.ReadOnlyFlag = true;
                                    _receiptBackDetail.Editable = false;
                                }
                            }
                            else
                            {
                                if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDefID == SubActionProcedure.States.Completed)
                                {
                                    _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDef.DisplayText.ToString();
                                    //_receiptBackDetail.ReadOnlyFlag = true;
                                    _receiptBackDetail.Editable = false;
                                }
                                else
                                {
                                    _receiptBackDetail.State = receiptDocDetail.CurrentStateDef.DisplayText.ToString();
                                    if (receiptDocDetail.CurrentStateDefID == ReceiptDocumentDetail.States.ReturnBack)
                                        //_receiptBackDetail.ReadOnlyFlag = true;
                                        _receiptBackDetail.Editable = false;
                                    else
                                        //_receiptBackDetail.ReadOnlyFlag = false;
                                        _receiptBackDetail.Editable = true;
                                }
                            }
                        }
                        else
                        {
                            if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionMaterial.CurrentStateDefID == SubActionMaterial.States.Completed)
                            {
                                _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionMaterial.CurrentStateDef.DisplayText.ToString();
                                //_receiptBackDetail.ReadOnlyFlag = true;
                                _receiptBackDetail.Editable = false;
                            }
                            else
                            {
                                _receiptBackDetail.State = receiptDocDetail.CurrentStateDef.DisplayText.ToString();
                                if (receiptDocDetail.CurrentStateDefID == ReceiptDocumentDetail.States.ReturnBack)
                                    //_receiptBackDetail.ReadOnlyFlag = true;
                                    _receiptBackDetail.Editable = false;
                                else
                                    //_receiptBackDetail.ReadOnlyFlag = false;
                                    _receiptBackDetail.Editable = true;
                            }
                        }

                        _receiptBackDetail.Return = false;

                        _ReceiptBack.ReceiptBackDetails.Add(_receiptBackDetail);
                        _ReceiptBack.ReturnTotalPrice = 0;

                    }
                    //}
                    for (int i = 0; i < this.GRIDReceiptBackDetails.Rows.Count; i++)
                    {
                        this.GRIDReceiptBackDetails.Rows[i].Cells[8].ReadOnly = (bool)this.GRIDReceiptBackDetails.Rows[i].Cells[9].Value;
                    }
                    //}
                }
            }
        }
        private void GRIDReceiptBackDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReceiptBackForm_GRIDReceiptBackDetails_CellValueChanged
            if (columnIndex == 8)
            {
                double clildTotal = 0;
                // Kan bankası için eklenen kısım
                ReceiptBackDetail checkedsp = this.GRIDReceiptBackDetails.Rows[rowIndex].TTObject as ReceiptBackDetail;

                if (checkedsp.AccountTransaction[0].SubActionProcedure is BloodBankBloodProducts && !(checkedsp.AccountTransaction[0].SubActionProcedure is BloodBankSubProduct))
                {
                    foreach (ITTGridRow subrow in this.GRIDReceiptBackDetails.Rows)
                    {
                        ReceiptBackDetail detChild = subrow.TTObject as ReceiptBackDetail;
                        if (detChild != null)
                        {
                            if (detChild.AccountTransaction[0].SubActionProcedure.MasterSubActionProcedure == checkedsp.AccountTransaction[0].SubActionProcedure)
                            {
                                BloodBankTestDefinition testDef = detChild.AccountTransaction[0].SubActionProcedure.ProcedureObject as BloodBankTestDefinition;
                                if (testDef != null)
                                {
                                    if (testDef.OnlyChargeWithProduct == true)
                                    {
                                        detChild.Return = checkedsp.Return;
                                        clildTotal = clildTotal + Convert.ToDouble(subrow.Cells[6].Value);
                                    }
                                }
                            }
                        }
                    }
                }

                if (/*GRIDReceiptBackDetails.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False"*/ checkedsp.Return.Value == false)
                    _ReceiptBack.ReturnTotalPrice -= (Convert.ToDouble(GRIDReceiptBackDetails.Rows[rowIndex].Cells[6].Value) + clildTotal);
                else /*if (GRIDReceiptBackDetails.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True")*/
                    _ReceiptBack.ReturnTotalPrice += (Convert.ToDouble(GRIDReceiptBackDetails.Rows[rowIndex].Cells[6].Value) + clildTotal);
            }
            #endregion ReceiptBackForm_GRIDReceiptBackDetails_CellValueChanged
        }

        private void BTNLISTDETAIL_Click()
        {
            #region ReceiptBackForm_BTNLISTDETAIL_Click

            #endregion ReceiptBackForm_BTNLISTDETAIL_Click
        }

        protected override void ClientSidePreScript()
        {
            base.ClientSidePreScript();
            lstBoxReceipts.ListFilterExpression = "EPISODE = " + "'" + _ReceiptBack.Episode.ObjectID + "'";

            if (_ReceiptBack.CurrentStateDefID == ReceiptBack.States.New)
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                CashOfficeDefinition selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice,resUser);

                if (selectedCashOffice == null)
                    throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Makbuz kesmeye yetikiniz bulunmamaktadır!!");

                this.cmdOK.Visible = false;
                _ReceiptBack.CashOfficeName = selectedCashOffice.Name;
                if (_ReceiptBack.ReceiptBackDocument == null)
                {
                    _ReceiptBack.ReceiptBackDocument = new ReceiptBackDocument(_ReceiptBack.ObjectContext);
                    _ReceiptBack.ReceiptBackDocument.CashOffice = selectedCashOffice;
                    _ReceiptBack.CashOfficeName = selectedCashOffice.Name;
                    _ReceiptBack.ReceiptBackDocument.DocumentDate = DateTime.Now.Date;
                    _ReceiptBack.ReceiptBackDocument.CurrentStateDefID = ReceiptBackDocument.States.New;
                    _ReceiptBack.ReceiptBackDocument.ResUser = resUser;
                }
            }
            else
                this.BTNLISTDETAIL.ReadOnly = true;
        }

        protected override void PreScript()
        {
            #region ReceiptBackForm_PreScript
            /*if (_ReceiptBack.CurrentStateDefID == ReceiptBack.States.New)
            {
                CashierLog _myCashierLog;

                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                _myCashierLog = (CashierLog)_myResUser.GetOpenCashCashierLog();

                if (_myCashierLog == null)
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(174));
                }
                else
                {
                    if (_myCashierLog.CashOffice.Type != CashOfficeTypeEnum.MainCashOffice && _myCashierLog.CashOffice.Type != CashOfficeTypeEnum.SubCashOffice)
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessage(175));
                    }
                    else
                    {
                        if (_myCashierLog.CashOffice.Type == CashOfficeTypeEnum.SubCashOffice)
                        {
                            if (TTObjectClasses.SystemParameter.GetParameterValue("SUBCASHOFFICECANREFUND", "FALSE") != "TRUE")
                                throw new TTUtils.TTException(SystemMessage.GetMessage(176, new string[] { "Muhasebe Yetkilisi Mutemedi Alındısı İade" }));
                        }

                        this.cmdOK.Visible = false;
                        _ReceiptBack.CashOfficeName = _myCashierLog.CashOffice.Name;
                        if (_ReceiptBack.ReceiptBackDocument == null)
                        {
                            _ReceiptBack.ReceiptBackDocument = new ReceiptBackDocument(_ReceiptBack.ObjectContext);
                            _ReceiptBack.ReceiptBackDocument.CashierLog = _myCashierLog;
                            _ReceiptBack.ReceiptBackDocument.DocumentDate = DateTime.Now.Date;
                            _ReceiptBack.ReceiptBackDocument.CurrentStateDefID = ReceiptBackDocument.States.New;
                        }
                    }
                }
                this.BTNLISTDETAIL.ReadOnly = false;
            }
            else
                this.BTNLISTDETAIL.ReadOnly = true;

            if (_ReceiptBack.ReceiptBackDocument.CashierLog.CashOffice.Type == CashOfficeTypeEnum.SubCashOffice)
            {
                this.labelCashOfficeName.Text = "Muhasebe Yetkilisi Mutemetliği";
                this.labelOfficerName.Text = "Muhasebe Yetkilisi Mutemedi Adı";
                this.labelCashierLogId.Text = "Açılış İz Sürme No";
            }
            else if (_ReceiptBack.ReceiptBackDocument.CashierLog.CashOffice.Type == CashOfficeTypeEnum.MainCashOffice)
            {
                this.labelCashOfficeName.Text = "Vezne Adı";
                this.labelOfficerName.Text = "Vezne Memuru Adı";
                this.labelCashierLogId.Text = "Açılış İz Sürme No";
            }*/
            #endregion ReceiptBackForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region ReceiptBackForm_PostScript
            //            CashierLog  _myCashierLog;
            //            ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            //            _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
            //            
            //            
            //            if (_myCashierLog.CashOffice.Type == CashOfficeTypeEnum.SubCashOffice && _ReceiptBack.ReceiptBackDocument.CashierLog.ClosingDate != null )
            //            {
            //                throw new TTException("Sayman Mutemedi Alındısının kesildiği Sayman Mutemetliği kapandığı için Sayman Mutemedi Alındısı İade işlemi yapılamaz!");
            //            }
            //            else if(_myCashierLog.CashOffice.Type == CashOfficeTypeEnum.InvoicingService)
            //            {
            //                throw new TTException("Fatura Servisinden Sayman Mutemedi Alındısı İade işlemi yapılamaz!");
            //            }
            //            else
            //            {
            _ReceiptBack.ReceiptBackDocument.TotalPrice = _ReceiptBack.ReturnTotalPrice;
            //           }
            #endregion ReceiptBackForm_PostScript

        }
    }
}