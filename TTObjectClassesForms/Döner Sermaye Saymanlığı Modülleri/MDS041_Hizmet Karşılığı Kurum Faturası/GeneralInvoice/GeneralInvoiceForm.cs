
/*using System;
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
    /// Hizmet Karşılığı Kurum Faturası
    /// </summary>
    public partial class GeneralInvoiceForm : TTForm
    {
        override protected void BindControlEvents()
        {
            GRIDInvoiceProcedures.UserDeletedRow += new TTGridRowEventDelegate(GRIDInvoiceProcedures_UserDeletedRow);
            GRIDInvoiceProcedures.CellValueChanged += new TTGridCellEventDelegate(GRIDInvoiceProcedures_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GRIDInvoiceProcedures.UserDeletedRow -= new TTGridRowEventDelegate(GRIDInvoiceProcedures_UserDeletedRow);
            GRIDInvoiceProcedures.CellValueChanged -= new TTGridCellEventDelegate(GRIDInvoiceProcedures_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GRIDInvoiceProcedures_UserDeletedRow()
        {
#region GeneralInvoiceForm_GRIDInvoiceProcedures_UserDeletedRow
   double totalPrice = 0;
            
            // Toplam Tutar güncellenir
            foreach(ITTGridRow row in GRIDInvoiceProcedures.Rows)
            {
                if(row.Cells["PTOTALPRICE"].Value != null)
                    totalPrice = totalPrice + Convert.ToDouble(row.Cells["PTOTALPRICE"].Value);
            }
            
            _GeneralInvoice.TotalPrice = totalPrice;
#endregion GeneralInvoiceForm_GRIDInvoiceProcedures_UserDeletedRow
        }

        private void GRIDInvoiceProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region GeneralInvoiceForm_GRIDInvoiceProcedures_CellValueChanged
   if ((columnIndex == 0 || columnIndex == 1 || columnIndex == 2 || columnIndex == 3) && rowIndex != -1)
            {
                if (columnIndex == 0 || columnIndex == 1)
                {
                    if(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PACTIONDATE"].Value != null && GRIDInvoiceProcedures.Rows[rowIndex].Cells["PPROCEDURE"].Value != null)
                    {
                        ArrayList pricingDetailList = new ArrayList();
                        ProcedureDefinition procedure = (ProcedureDefinition)((GeneralInvoiceProcedure)((TTVisual.ITTGridRow)GRIDInvoiceProcedures.Rows[rowIndex]).TTObject).Procedure;
                        pricingDetailList = procedure.GetProcedurePricingDetails((DateTime)GRIDInvoiceProcedures.Rows[rowIndex].Cells["PACTIONDATE"].Value);
                        
                        if(pricingDetailList != null)
                        {
                            if(pricingDetailList.Count == 0)
                                GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = 0;
                            else if(pricingDetailList.Count == 1)
                                GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = (double)((PricingDetailDefinition)pricingDetailList[0]).Price.Value;
                            else if(pricingDetailList.Count > 1)
                            {
                                MultiSelectForm pMSForm = new MultiSelectForm();
                                foreach (PricingDetailDefinition pp in pricingDetailList)
                                    pMSForm.AddMSItem(pp.PricingList.Name + "  :  " + pp.Price.Value.ToString() + " " + pp.CurrencyType.Qref, pp.ObjectID.ToString(), pp);
                                
                                string sKey = pMSForm.GetMSItem(this, "Seçtiğiniz hizmetin eşleştiği birden çok fiyat bulundu. Birim Fiyatı seçiniz.", false, true, false);
                                if (string.IsNullOrEmpty(sKey))
                                    GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = 0;
                                else
                                    GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = (double)((PricingDetailDefinition)pMSForm.MSSelectedItemObject).Price.Value;
                            }
                        }
                        
                        if(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value != null && GRIDInvoiceProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value != null)
                            GRIDInvoiceProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = Convert.ToDouble(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value) * Convert.ToInt32(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value);
                        else
                            GRIDInvoiceProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = 0;
                    }
                    else
                    {
                        GRIDInvoiceProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value = 1;
                        GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = 0;
                        GRIDInvoiceProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = 0;
                    }
                }
                else if (columnIndex == 2)
                {
                    if(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value == null || Convert.ToInt32(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value) == 0)
                        GRIDInvoiceProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value = 1;
                    else if(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value != null)
                        GRIDInvoiceProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = Convert.ToDouble(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value) * Convert.ToInt32(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value);
                    else
                        GRIDInvoiceProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = 0;
                }
                else if (columnIndex == 3)
                {
                    if(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value == null)
                        GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = 0;
                    else if(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value != null && GRIDInvoiceProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value != null)
                        GRIDInvoiceProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = Convert.ToDouble(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value) * Convert.ToInt32(GRIDInvoiceProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value);
                    else
                        GRIDInvoiceProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = 0;
                }
                
                // Toplam Tutar güncellenir
                double totalPrice = 0;
                foreach(ITTGridRow row in GRIDInvoiceProcedures.Rows)
                {
                    if(row.Cells["PTOTALPRICE"].Value != null)
                        totalPrice = totalPrice + Convert.ToDouble(row.Cells["PTOTALPRICE"].Value);
                }
                
                _GeneralInvoice.TotalPrice = totalPrice;
            }
#endregion GeneralInvoiceForm_GRIDInvoiceProcedures_CellValueChanged
        }

        protected override void PreScript()
        {
#region GeneralInvoiceForm_PreScript
    if (_GeneralInvoice.CurrentStateDefID == GeneralInvoice.States.New)
            {
                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                CashierLog _myCashierLog = null;
                if (_myResUser != null)
                    _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
                
                if (_myCashierLog == null)
                    throw new TTException(SystemMessage.GetMessage(210));
                else
                {
                    if (_myCashierLog.CashOffice.Type != CashOfficeTypeEnum.InvoicingService)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(210));
                    else
                    {
                        this.cmdOK.Visible = false;
                        this.DropStateButton(GeneralInvoice.States.Cancelled);
                        _GeneralInvoice.CashOfficeName = _myCashierLog.CashOffice.Name;
                        
                        if (_GeneralInvoice.GeneralInvoiceDocument == null)
                        {
                            _GeneralInvoice.GeneralInvoiceDocument = new GeneralInvoiceDocument(_GeneralInvoice.ObjectContext);
                            _GeneralInvoice.GeneralInvoiceDocument.CashierLog = _myCashierLog;
                            _GeneralInvoice.GeneralInvoiceDocument.DocumentDate = DateTime.Now.Date;
                            _GeneralInvoice.GeneralInvoiceDocument.CurrentStateDefID = GeneralInvoiceDocument.States.New;
                            
                            IList myList = InvoiceCashOfficeDefinition.GetByCashOffice(_GeneralInvoice.ObjectContext, _myCashierLog.CashOffice.ObjectID.ToString());
                            if (myList.Count == 0)
                                throw new TTUtils.TTException(SystemMessage.GetMessage(213, new string[] { _GeneralInvoice.CashOfficeName }));
                            else
                            {
                                InvoiceCashOfficeDefinition _myInvoiceCashOfficeDefinition = (InvoiceCashOfficeDefinition) myList[0];
                                _GeneralInvoice.GeneralInvoiceDocument.DocumentNo = InvoiceCashOfficeDefinition.GetCurrentInvoiceNumber(_myInvoiceCashOfficeDefinition);
                            }
                            
                            _GeneralInvoice.IsIntegration = false;
                            double totalPrice = 0;
                            
                            if(_GeneralInvoice.GeneralInvoiceProcedures.Count > 0)
                            {
                                GRIDInvoiceProcedures.AllowUserToAddRows = false;
                                GRIDInvoiceProcedures.AllowUserToDeleteRows = false;
                                GRIDInvoiceProcedures.ReadOnly = true;

                                if (_GeneralInvoice.CommunityHealthRequest.Count == 0)
                                {
                                    _GeneralInvoice.IsIntegration = true;
                                    int priceCount;
                                    ArrayList pricingDetailList = new ArrayList();

                                    PricingListDefinition SUTPriceList = null;
                                    SUTPriceList = (PricingListDefinition)PricingListDefinition.GetByObjectID(_GeneralInvoice.ObjectContext, TTObjectClasses.SystemParameter.GetParameterValue("SUTPRICELISTOBJECTID", "").ToString())[0];

                                    foreach (GeneralInvoiceProcedure invProc in _GeneralInvoice.GeneralInvoiceProcedures)
                                    {
                                        if (invProc.Procedure == null)
                                            throw new TTException(SystemMessage.GetMessage(476));

                                        if (invProc.ActionDate == null)
                                            throw new TTException(SystemMessage.GetMessage(477, new string[] { "(" + invProc.Procedure.Code + " " + invProc.Procedure.Name + ")" }));

                                        if (invProc.Amount == null || invProc.Amount == 0)
                                            throw new TTException(SystemMessage.GetMessage(478, new string[] { "(" + invProc.Procedure.Code + " " + invProc.Procedure.Name + ")" }));

                                        priceCount = 0;
                                        pricingDetailList.Clear();
                                        pricingDetailList = invProc.Procedure.GetProcedurePricingDetail(SUTPriceList, (DateTime)invProc.ActionDate);

                                        foreach (PricingDetailDefinition pp in pricingDetailList)
                                        {
                                            if (pp.Price != null)
                                            {
                                                invProc.UnitPrice = (double)pp.Price;
                                                invProc.Price = pp;
                                            }
                                            priceCount++;
                                        }

                                        if (priceCount == 0)
                                        {
                                            invProc.UnitPrice = 0;
                                            InfoBox.Alert(invProc.Procedure.Code + " " + invProc.Procedure.Name + " hizmetinin eşleştiği aktif SUT fiyatı bulunamadı!", TTDefinitionManagement.MessageIconEnum.WarningMessage);
                                        }
                                        if (priceCount > 1)
                                        {
                                            invProc.UnitPrice = 0;
                                            invProc.Price = null;
                                            InfoBox.Alert(invProc.Procedure.Code + " " + invProc.Procedure.Name + " hizmetinin eşleştiği birden çok aktif SUT fiyatı bulundu, bu yüzden Birim Fiyat sıfır olarak güncellendi. Hizmetin eşleşmiş olduğu aktif SUT fiyatlarını kontrol ediniz!", TTDefinitionManagement.MessageIconEnum.WarningMessage);
                                        }

                                        invProc.TotalPrice = invProc.Amount * invProc.UnitPrice;
                                        totalPrice = totalPrice + (double)invProc.TotalPrice;
                                    }
                                }
                            }
                            else
                            {
                                GRIDInvoiceProcedures.AllowUserToAddRows = true;
                                GRIDInvoiceProcedures.AllowUserToDeleteRows = true;
                                GRIDInvoiceProcedures.ReadOnly = false;
                            }

                            if (_GeneralInvoice.CommunityHealthRequest.Count == 0)
                            {
                                _GeneralInvoice.TotalPrice = totalPrice;
                                CommunityHealthPayer.ReadOnly = true;
                            }
                            else
                                Payer.ReadOnly = true;

                            _GeneralInvoice.GeneralInvoiceDocument.TotalPrice = _GeneralInvoice.TotalPrice;
                        }
                    }
                }
            }
            else
            {
                if (this._GeneralInvoice.IsIntegration == true)
                    this.DropStateButton(GeneralInvoice.States.Cancelled);
            }
#endregion GeneralInvoiceForm_PreScript

            }
                }
}*/