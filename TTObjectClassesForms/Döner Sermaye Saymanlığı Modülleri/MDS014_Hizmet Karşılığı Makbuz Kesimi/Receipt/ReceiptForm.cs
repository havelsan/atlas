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
    /// Muhasebe Yetkilisi Mutemedi Alındısı
    /// </summary>
    public partial class ReceiptForm : TTForm
    {
        override protected void BindControlEvents()
        {
            //TOTALDISCOUNTENTRY.TextChanged += new TTControlEventDelegate(TOTALDISCOUNTENTRY_TextChanged);
            txtTotalPayment.TextChanged += new TTControlEventDelegate(txtTotalPayment_TextChanged);
            //BUTTONDISCOUNT.Click += new TTControlEventDelegate(BUTTONDISCOUNT_Click);
            //DISCOUNTTYPE.SelectedObjectChanged += new TTControlEventDelegate(DISCOUNTTYPE_SelectedObjectChanged);
            //GRIDCashs.CellValueChanged += new TTGridCellEventDelegate(GRIDCashs_CellValueChanged);
            //GRIDCashs.UserDeletedRow += new TTGridRowEventDelegate(GRIDCashs_UserDeletedRow);
            //GRIDCreditCards.CellValueChanged += new TTGridCellEventDelegate(GRIDCreditCards_CellValueChanged);
            //GRIDCreditCards.SelectionChanged += new TTControlEventDelegate(GRIDCreditCards_SelectionChanged);
            //GRIDCreditCards.UserDeletedRow += new TTGridRowEventDelegate(GRIDCreditCards_UserDeletedRow);
            //GRIDDebentures.CellContentClick += new TTGridCellEventDelegate(GRIDDebentures_CellContentClick);
            //GRIDDebentures.CellValueChanged += new TTGridCellEventDelegate(GRIDDebentures_CellValueChanged);
            //GRIDDebentures.RowLeave += new TTGridCellEventDelegate(GRIDDebentures_RowLeave);
            //GRIDDebentures.UserDeletedRow += new TTGridRowEventDelegate(GRIDDebentures_UserDeletedRow);
            //GRIDCheques.CellValueChanged += new TTGridCellEventDelegate(GRIDCheques_CellValueChanged);
            //GRIDCheques.UserDeletedRow += new TTGridRowEventDelegate(GRIDCheques_UserDeletedRow);
            GRIDReceiptProcedures.CellValueChanged += new TTGridCellEventDelegate(GRIDReceiptProcedures_CellValueChanged);
            GRIDReceiptMaterials.CellValueChanged += new TTGridCellEventDelegate(GRIDReceiptMaterials_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //TOTALDISCOUNTENTRY.TextChanged -= new TTControlEventDelegate(TOTALDISCOUNTENTRY_TextChanged);
            txtTotalPayment.TextChanged -= new TTControlEventDelegate(txtTotalPayment_TextChanged);
            //BUTTONDISCOUNT.Click -= new TTControlEventDelegate(BUTTONDISCOUNT_Click);
            //DISCOUNTTYPE.SelectedObjectChanged -= new TTControlEventDelegate(DISCOUNTTYPE_SelectedObjectChanged);
            //GRIDCashs.CellValueChanged -= new TTGridCellEventDelegate(GRIDCashs_CellValueChanged);
            //GRIDCashs.UserDeletedRow -= new TTGridRowEventDelegate(GRIDCashs_UserDeletedRow);
            //GRIDCreditCards.CellValueChanged -= new TTGridCellEventDelegate(GRIDCreditCards_CellValueChanged);
            //GRIDCreditCards.SelectionChanged -= new TTControlEventDelegate(GRIDCreditCards_SelectionChanged);
            //GRIDCreditCards.UserDeletedRow -= new TTGridRowEventDelegate(GRIDCreditCards_UserDeletedRow);
            //GRIDDebentures.CellContentClick -= new TTGridCellEventDelegate(GRIDDebentures_CellContentClick);
            //GRIDDebentures.CellValueChanged -= new TTGridCellEventDelegate(GRIDDebentures_CellValueChanged);
            //GRIDDebentures.RowLeave -= new TTGridCellEventDelegate(GRIDDebentures_RowLeave);
            //GRIDDebentures.UserDeletedRow -= new TTGridRowEventDelegate(GRIDDebentures_UserDeletedRow);
            //GRIDCheques.CellValueChanged -= new TTGridCellEventDelegate(GRIDCheques_CellValueChanged);
            //GRIDCheques.UserDeletedRow -= new TTGridRowEventDelegate(GRIDCheques_UserDeletedRow);
            GRIDReceiptProcedures.CellValueChanged -= new TTGridCellEventDelegate(GRIDReceiptProcedures_CellValueChanged);
            GRIDReceiptMaterials.CellValueChanged -= new TTGridCellEventDelegate(GRIDReceiptMaterials_CellValueChanged);
            base.UnBindControlEvents();
        }
        //private void TOTALDISCOUNTENTRY_TextChanged()
        //{
        //    #region ReceiptForm_TOTALDISCOUNTENTRY_TextChanged
        //    if (_Receipt.TotalDiscountEntry == null || _Receipt.TotalDiscountEntry == 0)
        //    {
        //        foreach (ReceiptProcedure rProc in _Receipt.ReceiptProcedures)
        //        {
        //            rProc.TotalDiscountPrice = 0;
        //            rProc.TotalDiscountedPrice = rProc.TotalPrice;
        //        }
        //        foreach (ReceiptMaterial rMat in _Receipt.ReceiptMaterials)
        //        {
        //            rMat.TotalDiscountPrice = 0;
        //            rMat.TotalDiscountedPrice = rMat.TotalPrice;
        //        }

        //        _Receipt.TotalDiscountPrice = 0;
        //        _Receipt.GeneralTotalPrice = _Receipt.TotalPrice;
        //        this.DISCOUNTTYPE.ReadOnly = false;
        //        _Receipt.DiscountTypeDefinition = null;

        //        /*if (_Receipt.TotalDiscountEntry == null)
        //        {
        //            this.GRIDCashs.Rows[0].Cells["CASHPRICE"].Value = _Receipt.GeneralTotalPrice;
        //            _Receipt.TotalDiscountEntry = 0;
        //        }*/
        //    }
        //    else
        //    {
        //        this.DISCOUNTTYPE.ReadOnly = true;
        //        _Receipt.DiscountTypeDefinition = null;
        //    }
        //    #endregion ReceiptForm_TOTALDISCOUNTENTRY_TextChanged
        //}

        /*private void BUTTONDISCOUNT_Click()
        {
            #region ReceiptForm_BUTTONDISCOUNT_Click
            if (_Receipt.TotalDiscountEntry > _Receipt.TotalPrice)
            {
                String message = SystemMessage.GetMessage(2328);
                TTVisual.InfoBox.Show(message);
                this.TOTALDISCOUNTENTRY.Text = "0";
            }
            else
            {
                if ((_Receipt.DiscountTypeDefinition == null && _Receipt.TotalDiscountEntry == 0) || (_Receipt.TotalDiscountEntry == null && _Receipt.TotalDiscountEntry == null))
                {
                    String message = SystemMessage.GetMessage(122);
                    TTVisual.InfoBox.Show(message);
                }
                else
                {
                    double discountPercent;
                    bool notFound;
                    double discountPrice = 0;
                    double totalDiscountPrice = 0;
                    double discountAmountEntry = 0;
                    ProcedureTreeDefinition pTree = null;
                    MaterialTreeDefinition mTree = null;


                    // Onceki secilen indirim tipinden kalan degerleri resetle
                    foreach (ReceiptProcedure rProc in _Receipt.ReceiptProcedures)
                    {
                        rProc.TotalDiscountPrice = 0;
                        rProc.TotalDiscountedPrice = rProc.TotalPrice;
                    }

                    foreach (ReceiptMaterial rMat in _Receipt.ReceiptMaterials)
                    {
                        rMat.TotalDiscountPrice = 0;
                        rMat.TotalDiscountedPrice = rMat.TotalPrice;
                    }

                    _Receipt.TotalDiscountPrice = 0;
                    _Receipt.GeneralTotalPrice = _Receipt.TotalPrice;


                    discountAmountEntry = (double)_Receipt.TotalDiscountEntry;
                    DiscountTypeDefinition selectedDiscountType = _Receipt.DiscountTypeDefinition;

                    if (discountAmountEntry > 0)
                    {
                        ReceiptProcedure lastProc = null;
                        ReceiptMaterial lastMat = null;

                        discountPercent = (double)(discountAmountEntry / (double)_Receipt.TotalPrice) * 100;
                        foreach (ReceiptProcedure rProc in _Receipt.ReceiptProcedures)
                        {
                            if (rProc.Paid == true)
                            {
                                discountPrice = Math.Round((double)(rProc.TotalPrice * discountPercent) / 100, 2);
                                rProc.TotalDiscountPrice = discountPrice;
                                rProc.TotalDiscountedPrice = Math.Round((double)(rProc.TotalPrice - discountPrice), 2);
                                lastProc = rProc;
                                totalDiscountPrice = totalDiscountPrice + discountPrice;
                            }
                        }

                        foreach (ReceiptMaterial rMat in _Receipt.ReceiptMaterials)
                        {
                            if (rMat.Paid == true)
                            {

                                discountPrice = Math.Round((double)(rMat.TotalPrice * discountPercent) / 100, 2);
                                rMat.TotalDiscountPrice = discountPrice;
                                rMat.TotalDiscountedPrice = Math.Round((double)(rMat.TotalPrice - discountPrice), 2);
                                lastMat = rMat;
                                totalDiscountPrice = totalDiscountPrice + discountPrice;
                            }
                        }
                        if (totalDiscountPrice != discountAmountEntry)
                        {
                            if (lastMat != null)
                            {
                                lastMat.TotalDiscountPrice = Math.Round((double)(lastMat.TotalDiscountPrice + (discountAmountEntry - totalDiscountPrice)), 2);
                                lastMat.TotalDiscountedPrice = Math.Round((double)(lastMat.TotalPrice - lastMat.TotalDiscountPrice), 2);
                            }
                            else
                            {
                                if (lastProc != null)
                                {
                                    lastProc.TotalDiscountPrice = Math.Round((double)(lastProc.TotalDiscountPrice + (discountAmountEntry - totalDiscountPrice)), 2);
                                    lastProc.TotalDiscountedPrice = Math.Round((double)(lastProc.TotalPrice - lastProc.TotalDiscountPrice), 2);
                                }
                            }
                            totalDiscountPrice = discountAmountEntry;
                        }
                    }
                    else
                    {

                        foreach (ReceiptProcedure rProc in _Receipt.ReceiptProcedures)
                        {
                            discountPercent = 0;
                            notFound = true;

                            if (rProc.Paid == true)
                            {
                                discountPercent = selectedDiscountType.GetExceptionDiscountPercent(rProc.AccountTransaction[0].SubActionProcedure.ProcedureObject);
                                if (discountPercent > 0)
                                {
                                    discountPrice = Math.Round((double)(rProc.TotalPrice * discountPercent) / 100, 2);
                                    rProc.TotalDiscountPrice = discountPrice;
                                    rProc.TotalDiscountedPrice = Math.Round((double)(rProc.TotalPrice - discountPrice), 2);
                                    totalDiscountPrice = totalDiscountPrice + discountPrice;
                                }
                                else
                                {
                                    pTree = rProc.AccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree;
                                    while (notFound && pTree != null)
                                    {
                                        discountPercent = selectedDiscountType.GetGroupDiscountPercent(pTree);
                                        if (discountPercent > 0)
                                        {
                                            notFound = false;
                                            discountPrice = Math.Round((double)(rProc.TotalPrice * discountPercent) / 100, 2);
                                            rProc.TotalDiscountPrice = discountPrice;
                                            rProc.TotalDiscountedPrice = Math.Round((double)(rProc.TotalPrice - discountPrice), 2);
                                            totalDiscountPrice = totalDiscountPrice + discountPrice;
                                        }
                                        else
                                            pTree = pTree.ParentID;
                                    }
                                }
                            }
                        }

                        foreach (ReceiptMaterial rMat in _Receipt.ReceiptMaterials)
                        {
                            discountPercent = 0;
                            notFound = true;

                            if (rMat.Paid == true)
                            {
                                discountPercent = selectedDiscountType.GetExceptionDiscountPercent(rMat.AccountTransaction[0].SubActionMaterial.Material);
                                if (discountPercent > 0)
                                {
                                    discountPrice = Math.Round((double)(rMat.TotalPrice * discountPercent) / 100, 2);
                                    rMat.TotalDiscountPrice = discountPrice;
                                    rMat.TotalDiscountedPrice = Math.Round((double)(rMat.TotalPrice - discountPrice), 2);
                                    totalDiscountPrice = totalDiscountPrice + discountPrice;
                                }
                                else
                                {
                                    mTree = rMat.AccountTransaction[0].SubActionMaterial.Material.MaterialTree;
                                    while (notFound && mTree != null)
                                    {
                                        discountPercent = selectedDiscountType.GetGroupDiscountPercent(mTree);
                                        if (discountPercent > 0)
                                        {
                                            notFound = false;
                                            discountPrice = Math.Round((double)(rMat.TotalPrice * discountPercent) / 100, 2);
                                            rMat.TotalDiscountPrice = discountPrice;
                                            rMat.TotalDiscountedPrice = Math.Round((double)(rMat.TotalPrice - discountPrice), 2);
                                            totalDiscountPrice = totalDiscountPrice + discountPrice;
                                        }
                                        else
                                            mTree = mTree.ParentMaterialTree;
                                    }
                                }
                            }
                        }
                    }

                    _Receipt.TotalDiscountPrice = totalDiscountPrice;
                    _Receipt.GeneralTotalPrice = _Receipt.TotalPrice - _Receipt.TotalDiscountPrice - _Receipt.DebentureTaken - _Receipt.AdvanceTaken;

                    // Payment ları ayarlar
                    if (_Receipt.ReceiptDocument.CashPayment.Count > 0)
                    {
                        foreach (Cash ch in _Receipt.ReceiptDocument.CashPayment)
                        {
                            ch.Price = this._Receipt.GeneralTotalPrice;
                            break;
                        }
                    }
                    else if (_Receipt.ReceiptDocument.CreditCardPayments.Count > 0)
                    {
                        foreach (CreditCard cc in _Receipt.ReceiptDocument.CreditCardPayments)
                        {
                            cc.Price = this._Receipt.GeneralTotalPrice;
                            break;
                        }
                    }

                    this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();
                }
            }
            #endregion ReceiptForm_BUTTONDISCOUNT_Click
        }*/

        /*private void DISCOUNTTYPE_SelectedObjectChanged()
        {
            #region ReceiptForm_DISCOUNTTYPE_SelectedObjectChanged
            if (_Receipt.DiscountTypeDefinition == null)
            {

                foreach (ReceiptProcedure rProc in _Receipt.ReceiptProcedures)
                {
                    rProc.TotalDiscountPrice = 0;
                    rProc.TotalDiscountedPrice = rProc.TotalPrice;
                }

                foreach (ReceiptMaterial rMat in _Receipt.ReceiptMaterials)
                {
                    rMat.TotalDiscountPrice = 0;
                    rMat.TotalDiscountedPrice = rMat.TotalPrice;
                }

                _Receipt.TotalDiscountPrice = 0;
                _Receipt.GeneralTotalPrice = _Receipt.TotalPrice;
                _Receipt.TotalDiscountEntry = 0;
                this.TOTALDISCOUNTENTRY.ReadOnly = false;
                //this.GRIDCashs.Rows[0].Cells["CASHPRICE"].Value = _Receipt.GeneralTotalPrice;

            }
            else
            {
                _Receipt.TotalDiscountEntry = 0;
                this.TOTALDISCOUNTENTRY.ReadOnly = true;
            }
            #endregion ReceiptForm_DISCOUNTTYPE_SelectedObjectChanged
        }*/

        /*private void GRIDCashs_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReceiptForm_GRIDCashs_CellValueChanged
            if (columnIndex == 0 || columnIndex == 1)
            {
                this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();
            }
            #endregion ReceiptForm_GRIDCashs_CellValueChanged
        }*/

        /*private void GRIDCashs_UserDeletedRow()
        {
            #region ReceiptForm_GRIDCashs_UserDeletedRow
            this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();
            #endregion ReceiptForm_GRIDCashs_UserDeletedRow
        }*/

        /*private void GRIDCreditCards_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReceiptForm_GRIDCreditCards_CellValueChanged
            if (columnIndex == 6)
            {
                this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();
            }

            if (columnIndex != 1)
            {
                if (this._Receipt.ReceiptDocument.CreditCardPayments[rowIndex].PhoneNo == null)
                {
               
                    if (this._Receipt.Episode.Patient.PatientAddress.HomePhone != null)
                        this._Receipt.ReceiptDocument.CreditCardPayments[rowIndex].PhoneNo = this._Receipt.Episode.Patient.PatientAddress.HomePhone;
                    else if (this._Receipt.Episode.Patient.PatientAddress.MobilePhone != null)
                        this._Receipt.ReceiptDocument.CreditCardPayments[rowIndex].PhoneNo = this._Receipt.Episode.Patient.PatientAddress.MobilePhone;
                    else
                        this._Receipt.ReceiptDocument.CreditCardPayments[rowIndex].PhoneNo = null;
                }
            }
            #endregion ReceiptForm_GRIDCreditCards_CellValueChanged
        }*/

        /*private void GRIDCreditCards_SelectionChanged()
        {
        }*/

        /*private void GRIDCreditCards_UserDeletedRow()
        {
            #region ReceiptForm_GRIDCreditCards_UserDeletedRow
            this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();
            #endregion ReceiptForm_GRIDCreditCards_UserDeletedRow
        }*/

        /*private void GRIDDebentures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReceiptForm_GRIDDebentures_CellContentClick
            if (GRIDDebentures.CurrentCell.OwningColumn.Name == "ENTERGUARANTORINFO")
            {
                if (rowIndex < this.GRIDDebentures.Rows.Count && rowIndex > -1)
                {
                    Guid savePointGuid = this._Receipt.ObjectContext.BeginSavePoint();
                    try
                    {
                        Debenture debenture = (Debenture)((ITTGridRow)GRIDDebentures.Rows[rowIndex]).TTObject;
                        DebentureGuarantor debentureGuarantor;

                        bool isNew = false;
                        if (this.GRIDDebentures.Rows[rowIndex].Cells[4].Value != null)
                        {
                            isNew = (bool)this.GRIDDebentures.Rows[rowIndex].Cells[4].Value;
                        }

                        if (debenture.Guarantor == null)
                        {
                            if (rowIndex == 0 || isNew)
                                debentureGuarantor = new DebentureGuarantor(this._Receipt.ObjectContext);
                            else
                                debentureGuarantor = (DebentureGuarantor)((Debenture)((ITTGridRow)GRIDDebentures.Rows[0]).TTObject).Guarantor;


                            int paymentOrderPeriod = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("PAYMENTORDERPERIOD", "20"));
                            DateTime dueDate = (DateTime)debenture.DueDate;
                            debenture.PaymentOrderDate = dueDate.Date.AddDays(paymentOrderPeriod);

                            int executionPeriod = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("EXECUTIONORDERPERIOD", "20"));
                            DateTime paymentOrderDate = (DateTime)debenture.PaymentOrderDate;
                            debenture.ExecutionDate = paymentOrderDate.Date.AddDays(executionPeriod);
                        }
                        else
                            if (isNew)
                        {
                            debenture.Guarantor = null;
                            debentureGuarantor = new DebentureGuarantor(this._Receipt.ObjectContext);
                        }
                        else
                            debentureGuarantor = (DebentureGuarantor)((Debenture)((ITTGridRow)GRIDDebentures.Rows[rowIndex]).TTObject).Guarantor;


                        DebentureGuarantorForm frm = new DebentureGuarantorForm();
                        DialogResult dialogResult;
                        if (this._Receipt.CurrentStateDefID == Receipt.States.New)
                        {
                            dialogResult = frm.ShowEdit(this.FindForm(), debentureGuarantor);


                        }
                        else
                            dialogResult = frm.ShowReadOnly(this.FindForm(), debentureGuarantor);

                        if (dialogResult == DialogResult.OK)
                            debenture.Guarantor = debentureGuarantor;
                        else
                            this._Receipt.ObjectContext.RollbackSavePoint(savePointGuid);


                    }
                    catch (System.Exception ex)
                    {
                        InfoBox.Show(ex);
                    }
                }
            }
            #endregion ReceiptForm_GRIDDebentures_CellContentClick
        }*/

        /*private void GRIDDebentures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReceiptForm_GRIDDebentures_CellValueChanged
            if (columnIndex == 2)
            {
                this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();

            }
            #endregion ReceiptForm_GRIDDebentures_CellValueChanged
        }*/

        /*private void GRIDDebentures_RowLeave(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReceiptForm_GRIDDebentures_RowLeave
            Debenture debenture = (Debenture)((ITTGridRow)GRIDDebentures.Rows[rowIndex]).TTObject;
            if (debenture.Guarantor == null)
                InfoBox.Show("Senetin  Kefil Bilgisini Oluşturmadınız!!!");
            #endregion ReceiptForm_GRIDDebentures_RowLeave
        }*/

        /*private void GRIDDebentures_UserDeletedRow()
        {
            #region ReceiptForm_GRIDDebentures_UserDeletedRow
            this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();
            #endregion ReceiptForm_GRIDDebentures_UserDeletedRow
        }*/

        /*private void GRIDCheques_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReceiptForm_GRIDCheques_CellValueChanged
            if (columnIndex == 1)
            {
                this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();

            }
            #endregion ReceiptForm_GRIDCheques_CellValueChanged
        }*/

        /*private void GRIDCheques_UserDeletedRow()
        {
            #region ReceiptForm_GRIDCheques_UserDeletedRow
            this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();
            #endregion ReceiptForm_GRIDCheques_UserDeletedRow
        }*/

        private void GRIDReceiptProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReceiptForm_GRIDReceiptProcedures_CellValueChanged
            if (columnIndex == 9)
                CalculateSelectedProcsAndMatsPrice();

            #endregion ReceiptForm_GRIDReceiptProcedures_CellValueChanged
        }

        private void GRIDReceiptMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReceiptForm_GRIDReceiptMaterials_CellValueChanged
            if (columnIndex == 8)
                CalculateSelectedProcsAndMatsPrice();
            #endregion ReceiptForm_GRIDReceiptMaterials_CellValueChanged
        }

        public void CalculateSelectedProcsAndMatsPrice()
        {
            double vTotalPrice = 0;
            if (_Receipt.ReceiptProcedures.Count != 0)
            {
                foreach (ReceiptProcedure rp in _Receipt.ReceiptProcedures)
                {
                    if (rp.Paid == true)
                    {
                        vTotalPrice += rp.RemainingPrice.Value;
                    }
                }
            }

            if (_Receipt.ReceiptMaterials.Count != 0)
            {
                foreach (ReceiptMaterial rm in _Receipt.ReceiptMaterials)
                {
                    if (rm.Paid == true)
                    {
                        vTotalPrice += rm.RemainingPrice.Value;
                    }
                }
            }
            if (vTotalPrice > Convert.ToDouble(_Receipt.AdvanceTaken))
            {
                _Receipt.TotalPrice = vTotalPrice - _Receipt.AdvanceTaken;
                _Receipt.TotalPayment = _Receipt.TotalPrice;
            }
            else
            {
                InfoBox.Alert("Hastadan alınan avans toplamı, ödenmemiş hizmet/malzeme toplamından fazladır. Makbuz kesme işlemini tamamlayamazsınız, Seçilmeyen Hizmet/Malzeme var ise seçiniz ya da Avans İade yapınız!", MessageIconEnum.ErrorMessage);
                UpdatePaymentPrices(0);
            }
        }

        private void txtTotalPayment_TextChanged()
        {
            if (_Receipt.TotalPayment + _Receipt.AdvanceTaken > totalRemainingPrice)
                throw new TTException("Hastadan alınan avans ve girilen miktarın toplamı, ödenmemiş hizmet/malzeme toplamından fazladır. Makbuz kesme işlemini tamamlayamazsınız. Seçilmeyen hizmet/malzeme varsa seçiniz ya da daha az bir tutar giriniz!");
            else
                UpdatePaymentPrices(_Receipt.TotalPayment.Value + _Receipt.AdvanceTaken.Value);
        }
        public void UpdatePaymentPrices(Currency totalPayment)
        {
            if (totalPayment > 0)
            {
                foreach (ReceiptProcedure rp in _Receipt.ReceiptProcedures)
                {
                    if (rp.Paid == true)
                    {
                        if (rp.RemainingPrice <= totalPayment)
                        {
                            totalPayment -= rp.RemainingPrice.Value;
                            rp.PaymentPrice = rp.RemainingPrice;
                        }
                        else
                        {
                            if (totalPayment > 0)
                            {
                                rp.PaymentPrice = totalPayment;
                                totalPayment = 0;
                            }
                            else
                                rp.PaymentPrice = 0;
                        }
                    }
                    else
                        rp.PaymentPrice = 0;
                }
                foreach (ReceiptMaterial rm in _Receipt.ReceiptMaterials)
                {
                    if (rm.Paid == true)
                    {
                        if (rm.RemainingPrice <= totalPayment)
                        {
                            totalPayment -= rm.RemainingPrice.Value;
                            rm.PaymentPrice = rm.RemainingPrice;
                        }
                        else
                        {
                            if (totalPayment > 0)
                            {
                                rm.PaymentPrice = totalPayment;
                                totalPayment = 0;
                            }
                            else
                                rm.PaymentPrice = 0;
                        }
                    }
                    else
                        rm.PaymentPrice = 0;
                }
            }
            else
            {
                _Receipt.TotalPrice = 0;
                _Receipt.TotalPayment = 0;
            }
        }

        Currency totalRemainingPrice = 0;
        protected override void ClientSidePreScript()
        {
            base.ClientSidePreScript();
            if (_Receipt.CurrentStateDefID == Receipt.States.New)
            {
                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, _myResUser);

                if (selectedCashOffice == null)
                    throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Hastadan Tahsilat yapmaya yetikiniz bulunmamaktadır!");

                ReceiptCashOfficeDefinition selectedRCODef = new ReceiptCashOfficeDefinition();
                selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(_Receipt.ObjectContext, selectedCashOffice.ObjectID);

                cmdOK.Visible = false;
                _Receipt.CashOfficeName = selectedCashOffice.Name;//_myCashierLog.CashOffice.Name;

                if (_Receipt.ReceiptDocument == null)
                {
                    _Receipt.ReceiptDocument = new ReceiptDocument(_Receipt.ObjectContext);
                    _Receipt.ReceiptDocument.DocumentDate = Common.RecTime();

                    // ACCtrx leri doldurma Islemi

                    _Receipt.ReceiptDocument.PayeeName = _Receipt.Episode.Patient.FullName;
                    _Receipt.ReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
                    _Receipt.ReceiptDocument.ResUser = _myResUser;
                    _Receipt.ReceiptDocument.CashOffice = selectedCashOffice;
                    _Receipt.ReceiptDocument.PaymentType = PaymentTypeEnum.Cash;
                    foreach (AccountTransaction accTrx in Episode.GetTransactionsForReceipt(_Receipt.Episode))
                    {
                        if (accTrx.SubActionProcedure != null && accTrx.RemainingPrice > 0)
                        {
                            ReceiptProcedure rp = new ReceiptProcedure(_Receipt.ObjectContext);
                            rp.ActionDate = accTrx.TransactionDate.Value;
                            rp.ExternalCode = accTrx.ExternalCode;

                            if (accTrx.ExternalCode != null)
                            {
                                if (accTrx.ExternalCode == "520010" && accTrx.SubActionProcedure.ProcedureSpeciality != null)
                                {
                                    if (accTrx.Description.IndexOf(accTrx.SubActionProcedure.ProcedureSpeciality.Name) == -1)
                                        accTrx.Description += " (" + accTrx.SubActionProcedure.ProcedureSpeciality.Name + ")";
                                }
                            }

                            rp.Description = accTrx.Description;

                            //if (accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode() != null)
                            //rp.RevenueType = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode().Description;

                            rp.Amount = (int)accTrx.Amount;
                            rp.UnitPrice = accTrx.UnitPrice;
                            rp.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
                            rp.PaymentPrice = accTrx.RemainingPrice;
                            rp.RemainingPrice = accTrx.RemainingPrice;
                            rp.Paid = true;
                            rp.AccountTransaction.Add(accTrx);

                            totalRemainingPrice += rp.RemainingPrice.Value;
                            _Receipt.ReceiptProcedures.Add(rp);
                        }

                        if (accTrx.SubActionMaterial != null && accTrx.RemainingPrice > 0)
                        {
                            ReceiptMaterial rm = new ReceiptMaterial(_Receipt.ObjectContext);
                            rm.ActionDate = (DateTime)accTrx.TransactionDate;
                            rm.Description = accTrx.Description;
                            rm.ExternalCode = accTrx.ExternalCode;
                            rm.Amount = accTrx.Amount;
                            rm.UnitPrice = accTrx.UnitPrice;
                            rm.TotalPrice = (double)(accTrx.Amount * accTrx.UnitPrice);
                            rm.RemainingPrice = accTrx.RemainingPrice;
                            rm.PaymentPrice = accTrx.RemainingPrice;
                            rm.Paid = true;
                            rm.AccountTransaction.Add(accTrx);
                            totalRemainingPrice += rm.RemainingPrice.Value;
                            _Receipt.ReceiptMaterials.Add(rm);
                        }
                    }

                    _Receipt.UnDetailedReport = false;
                    //_Receipt.TotalDiscountPrice = 0;
                    //_Receipt.GeneralTotalPrice = totalPrice;
                    //_Receipt.TotalDiscountEntry = 0;
                    _Receipt.ReceiptDocument.PatientName = _Receipt.Episode.Patient.Name + " " + _Receipt.Episode.Patient.Surname;
                    _Receipt.ReceiptDocument.PatientNo = _Receipt.Episode.Patient.ID.Value;
                    //_Receipt.ReceiptDocument.TotalDiscountPrice = 0;
                    //_Receipt.ReceiptDocument.GeneralTotalPrice = 0;
                    _Receipt.ReceiptDocument.CurrentStateDefID = ReceiptDocument.States.New;

                    double totalAdvanceTaken = 0;
                    

                    foreach (Advance advance in _Receipt.Episode.Advances)
                    {
                        if (advance.AdvanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid && advance.AdvanceDocument.Used.Value == false)
                        {
                            totalAdvanceTaken += advance.TotalPrice.Value;
                            advance.AdvanceDocument.Used = true;
                            _Receipt.ReceiptDocument.AdvanceDocuments.Add(advance.AdvanceDocument);
                        }
                    }

                    //IsChildHasUnpaidCharge();

                    _Receipt.AdvanceTaken = totalAdvanceTaken;
                    _Receipt.TotalPrice = totalRemainingPrice;

                    if (_Receipt.TotalPrice > Convert.ToDouble(_Receipt.AdvanceTaken))
                    {
                        _Receipt.TotalPrice -= _Receipt.AdvanceTaken.Value;
                        _Receipt.TotalPayment = _Receipt.TotalPrice;
                    }
                    else
                    {
                        totalRemainingPrice = 0;
                        _Receipt.TotalPayment = 0;
                        //throw new TTException("Hastadan alınan avans miktarı, ödenmemiş hizmet/malzeme toplamından fazladır. Makbuz kesme işlemini tamamlayamazsınız. Seçilmeyen hizmet/malzeme varsa seçiniz ya da daha az bir miktar giriniz!");
                    }

                }
            }
            else
            {
                this.BUTTONDISCOUNT.ReadOnly = true;

                //if (this._Receipt.ReceiptDocument.CashPayment.Count == 0)
                //{
                //    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptReport));
                //    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptDetailedReport));
                //}

                //if (this._Receipt.ReceiptDocument.CreditCardPayments.Count == 0)
                //{
                //    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptCreditCardReport));
                //    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptCreditCardDetailedReport));
                //}

                if (this._Receipt.UnDetailedReport == true)
                {
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptDetailedReport));
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptCreditCardDetailedReport));
                }

                //if (this._Receipt.ReceiptDocument.DebenturePayments.Count == 0)
                //{
                //    this.DropCurrentStateReport(typeof(TTReportClasses.I_EmergentPatientRecordForm));
                //    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptDebentureReport));
                //}
            }
        }
        CashOfficeDefinition selectedCashOffice;
        protected override void PreScript()
        {
            #region ReceiptForm_PreScript

            #endregion ReceiptForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region ReceiptForm_PostScript
            //if (_Receipt.ReceiptDocument.CashPayment.Count == 0)
            //    _Receipt.ReceiptDocument.DocumentNo = null;
            //if (_Receipt.ReceiptDocument.CreditCardPayments.Count == 0)
            //    _Receipt.ReceiptDocument.CreditCardDocumentNo = null;
            //this._Receipt.TotalPayment = this._Receipt.ReceiptDocument.GetTotalPayment();

            //            foreach (Debenture debenture in this._Receipt.ReceiptDocument.DebenturePayments )
            //            {
            //                if (debenture.Guarantor.Count == 0 )
            //                {
            //                    throw new Exception("Kefil Bulunamadı");
            //                }
            //            }
            #endregion ReceiptForm_PostScript

        }

        #region ReceiptForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            // Nakit ve Kredi Kartı raporları dökülür
            /*if (transDef != null && transDef.ToStateDefID == Receipt.States.Paid)
            {
                if (_Receipt.ReceiptDocument.CashPayment.Count > 0)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _Receipt.ObjectID.ToString());

                    parameters.Add("TTOBJECTID", cache);
                    if (_Receipt.UnDetailedReport == true)
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ReceiptReport), true, 1, parameters);
                    else
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ReceiptDetailedReport), true, 1, parameters);
                }
                if (_Receipt.ReceiptDocument.CreditCardPayments.Count > 0)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _Receipt.ObjectID.ToString());

                    parameters.Add("TTOBJECTID", cache);
                    if (_Receipt.UnDetailedReport == true)
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ReceiptCreditCardReport), true, 1, parameters);
                    else
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ReceiptCreditCardDetailedReport), true, 1, parameters);
                }
                if (_Receipt.ReceiptDocument.DebenturePayments.Count > 0)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _Receipt.ObjectID.ToString());

                    parameters.Add("TTOBJECTID", cache);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_EmergentPatientRecordForm), true, 1, parameters);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ReceiptDebentureReport), true, 1, parameters);

                }
            }*/
        }

        public void IsChildHasUnpaidCharge()
        {
            string msg = string.Empty;
            foreach (Patient child in this._Receipt.Episode.Patient.Child)
            {
                foreach (Episode episode in child.Episodes)
                {
                    foreach (SubEpisode subEpisode in episode.SubEpisodes)
                    {
                        //todo bg
                        break;
                        /*
                        if (subEpisode.PatientAdmission.AdmissionType.Value == AdmissionTypeEnum.NewBorn)
                        {
                            foreach (AccountTransaction accTrx in Episode.GetTransactionsForReceipt(_Receipt.Episode))
                                msg += child.FullName + "     " + episode.OpeningDate + "\n";
                            break;
                        }*/
                    }
                }
            }

            if (!string.IsNullOrEmpty(msg))
                TTVisual.InfoBox.Alert("Hastanın çocuklarının aşağıdaki gelişlerinde ödenmemiş hizmet/malzeme vardır! :\n" + msg, MessageIconEnum.InformationMessage);
        }

        #endregion ReceiptForm_Methods
    }
}