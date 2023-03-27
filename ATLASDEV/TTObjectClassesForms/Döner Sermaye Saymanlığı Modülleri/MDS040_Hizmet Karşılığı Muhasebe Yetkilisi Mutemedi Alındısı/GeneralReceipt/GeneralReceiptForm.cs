/*
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
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı
    /// </summary>
    public partial class GeneralReceiptForm : TTForm
    {
        override protected void BindControlEvents()
        {
            GRIDCashs.CellValueChanged += new TTGridCellEventDelegate(GRIDCashs_CellValueChanged);
            GRIDCreditCards.CellValueChanged += new TTGridCellEventDelegate(GRIDCreditCards_CellValueChanged);
            GRIDReceiptProcedures.CellValueChanged += new TTGridCellEventDelegate(GRIDReceiptProcedures_CellValueChanged);
            GRIDReceiptProcedures.UserDeletedRow += new TTGridRowEventDelegate(GRIDReceiptProcedures_UserDeletedRow);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GRIDCashs.CellValueChanged -= new TTGridCellEventDelegate(GRIDCashs_CellValueChanged);
            GRIDCreditCards.CellValueChanged -= new TTGridCellEventDelegate(GRIDCreditCards_CellValueChanged);
            GRIDReceiptProcedures.CellValueChanged -= new TTGridCellEventDelegate(GRIDReceiptProcedures_CellValueChanged);
            GRIDReceiptProcedures.UserDeletedRow -= new TTGridRowEventDelegate(GRIDReceiptProcedures_UserDeletedRow);
            base.UnBindControlEvents();
        }

        private void GRIDCashs_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region GeneralReceiptForm_GRIDCashs_CellValueChanged
   if (columnIndex == 0 || columnIndex == 1 && rowIndex != -1)
            {
                this._GeneralReceipt.TotalPayment = this._GeneralReceipt.GeneralReceiptDocument.GetTotalPayment();
            }
#endregion GeneralReceiptForm_GRIDCashs_CellValueChanged
        }

        private void GRIDCreditCards_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region GeneralReceiptForm_GRIDCreditCards_CellValueChanged
   if (columnIndex == 6)
            {
                this._GeneralReceipt.TotalPayment = this._GeneralReceipt.GeneralReceiptDocument.GetTotalPayment();
            }
#endregion GeneralReceiptForm_GRIDCreditCards_CellValueChanged
        }

        private void GRIDReceiptProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region GeneralReceiptForm_GRIDReceiptProcedures_CellValueChanged
   if ((columnIndex == 0 || columnIndex == 1 || columnIndex == 2 || columnIndex == 3) && rowIndex != -1)
            {
                if (columnIndex == 0 || columnIndex == 1)
                {
                    if(GRIDReceiptProcedures.Rows[rowIndex].Cells["PACTIONDATE"].Value != null && GRIDReceiptProcedures.Rows[rowIndex].Cells["PPROCEDURE"].Value != null)
                    {
                        ArrayList pricingDetailList = new ArrayList();
                        ProcedureDefinition procedure = (ProcedureDefinition)((GeneralReceiptProcedure)((TTVisual.ITTGridRow)GRIDReceiptProcedures.Rows[rowIndex]).TTObject).Procedure;
                        pricingDetailList = procedure.GetProcedurePricingDetails((DateTime)GRIDReceiptProcedures.Rows[rowIndex].Cells["PACTIONDATE"].Value);
                        
                        if(pricingDetailList != null)
                        {
                            if(pricingDetailList.Count == 0)
                                GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = 0;
                            else if(pricingDetailList.Count == 1)
                                GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = (double)((PricingDetailDefinition)pricingDetailList[0]).Price.Value;
                            else if(pricingDetailList.Count > 1)
                            {
                                MultiSelectForm pMSForm = new MultiSelectForm();
                                foreach (PricingDetailDefinition pp in pricingDetailList)
                                    pMSForm.AddMSItem(pp.PricingList.Name + "  :  " + pp.Price.Value.ToString() + " " + pp.CurrencyType.Qref, pp.ObjectID.ToString(), pp);
                                
                                string sKey = pMSForm.GetMSItem(this, "Seçtiğiniz hizmetin eşleştiği birden çok fiyat bulundu. Birim Fiyatı seçiniz.", false, true, false);
                                if (string.IsNullOrEmpty(sKey))
                                    GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = 0;
                                else
                                    GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = (double)((PricingDetailDefinition)pMSForm.MSSelectedItemObject).Price.Value;
                            }
                        }
                        
                        if(GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value != null && GRIDReceiptProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value != null)
                            GRIDReceiptProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = Convert.ToDouble(GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value) * Convert.ToInt32(GRIDReceiptProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value);
                        else
                            GRIDReceiptProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = 0;
                    }
                    else
                    {
                        GRIDReceiptProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value = 1;
                        GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = 0;
                        GRIDReceiptProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = 0;
                    }
                }
                else if (columnIndex == 2)
                {
                    if(GRIDReceiptProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value == null || Convert.ToInt32(GRIDReceiptProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value) == 0)
                        GRIDReceiptProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value = 1;
                    else if(GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value != null)
                        GRIDReceiptProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = Convert.ToDouble(GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value) * Convert.ToInt32(GRIDReceiptProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value);
                    else
                        GRIDReceiptProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = 0;
                }
                else if (columnIndex == 3)
                {
                    if(GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value == null)
                        GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value = 0;
                    else if(GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value != null && GRIDReceiptProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value != null)
                        GRIDReceiptProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = Convert.ToDouble(GRIDReceiptProcedures.Rows[rowIndex].Cells["PUNITPRICE"].Value) * Convert.ToInt32(GRIDReceiptProcedures.Rows[rowIndex].Cells["PAMOUNT"].Value);
                    else
                        GRIDReceiptProcedures.Rows[rowIndex].Cells["PTOTALPRICE"].Value = 0;
                }
                
                // Toplam Tutar güncellenir
                double totalPrice = 0;
                foreach(ITTGridRow row in GRIDReceiptProcedures.Rows)
                {
                    if(row.Cells["PTOTALPRICE"].Value != null)
                        totalPrice = totalPrice + Convert.ToDouble(row.Cells["PTOTALPRICE"].Value);
                }
                
                _GeneralReceipt.TotalPrice = totalPrice;
            }
#endregion GeneralReceiptForm_GRIDReceiptProcedures_CellValueChanged
        }

        private void GRIDReceiptProcedures_UserDeletedRow()
        {
#region GeneralReceiptForm_GRIDReceiptProcedures_UserDeletedRow
   double totalPrice = 0;
            
            // Toplam Tutar güncellenir
            foreach(ITTGridRow row in GRIDReceiptProcedures.Rows)
            {
                if(row.Cells["PTOTALPRICE"].Value != null)
                    totalPrice = totalPrice + Convert.ToDouble(row.Cells["PTOTALPRICE"].Value);
            }
            
            _GeneralReceipt.TotalPrice = totalPrice;
#endregion GeneralReceiptForm_GRIDReceiptProcedures_UserDeletedRow
        }

        protected override void PreScript()
        {
#region GeneralReceiptForm_PreScript
    if (_GeneralReceipt.CurrentStateDefID == GeneralReceipt.States.New)
            {
                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                CashierLog  _myCashierLog = null;
                if (_myResUser != null)
                    _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
                
                if (_myCashierLog == null)
                    throw new TTException(SystemMessage.GetMessage(71));
                else
                {
                    if (_myCashierLog.CashOffice.Type != CashOfficeTypeEnum.CashOffice)
                        throw new TTException(SystemMessage.GetMessage(71));
                    else
                    {
                        this.cmdOK.Visible = false;
                        _GeneralReceipt.CashOfficeName = _myCashierLog.CashOffice.Name;
                        
                        if (_GeneralReceipt.GeneralReceiptDocument == null)
                        {
                            _GeneralReceipt.GeneralReceiptDocument = new GeneralReceiptDocument(_GeneralReceipt.ObjectContext);
                            _GeneralReceipt.GeneralReceiptDocument.CashierLog = _myCashierLog;
                            _GeneralReceipt.GeneralReceiptDocument.DocumentDate = DateTime.Now.Date;
                            _GeneralReceipt.GeneralReceiptDocument.CurrentStateDefID = GeneralReceiptDocument.States.New;
                            
                            ReceiptCashOfficeDefinition _myReceiptCashOfficeDefinition;
                            IList myList = ReceiptCashOfficeDefinition.GetByCashOffice(_GeneralReceipt.ObjectContext, _myCashierLog.CashOffice.ObjectID.ToString());

                            if (myList.Count == 0)
                                throw new TTException(SystemMessage.GetMessage(74, new string[] { _GeneralReceipt.CashOfficeName }));
                            else
                            {
                                _myReceiptCashOfficeDefinition = (ReceiptCashOfficeDefinition)_GeneralReceipt.ObjectContext.QueryObjects("ReceiptCashOfficeDefinition", "CASHOFFICE = '" + _myCashierLog.CashOffice.ObjectID + "'" )[0];
                                _GeneralReceipt.GeneralReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(_myReceiptCashOfficeDefinition);
                                _GeneralReceipt.GeneralReceiptDocument.CreditCardDocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(_myReceiptCashOfficeDefinition);
                            }
                            
                            double totalPrice = 0;
                            
                            if(_GeneralReceipt.GeneralReceiptProcedures.Count > 0)
                            {
                                _GeneralReceipt.IsIntegration = true;
                                GRIDReceiptProcedures.AllowUserToAddRows = false;
                                GRIDReceiptProcedures.AllowUserToDeleteRows = false;
                                GRIDReceiptProcedures.ReadOnly = true; 
                                
                                int priceCount;
                                ArrayList pricingDetailList = new ArrayList();
                                
                                PricingListDefinition SUTPriceList = null ;
                                SUTPriceList = (PricingListDefinition)PricingListDefinition.GetByObjectID(_GeneralReceipt.ObjectContext, TTObjectClasses.SystemParameter.GetParameterValue("SUTPRICELISTOBJECTID", "").ToString())[0];
                                
                                foreach (GeneralReceiptProcedure recProc in _GeneralReceipt.GeneralReceiptProcedures)
                                {
                                    if(recProc.Procedure == null)
                                        throw new TTException(SystemMessage.GetMessage(476));
                                    
                                    if(recProc.ActionDate == null)
                                        throw new TTException(SystemMessage.GetMessage(477, new string[] { "(" + recProc.Procedure.Code + " " + recProc.Procedure.Name + ")" }));

                                    if(recProc.Amount == null || recProc.Amount == 0)
                                        throw new TTException(SystemMessage.GetMessage(478, new string[] { "(" + recProc.Procedure.Code + " " + recProc.Procedure.Name + ")" }));
                                    
                                    priceCount = 0;
                                    pricingDetailList.Clear();
                                    pricingDetailList = recProc.Procedure.GetProcedurePricingDetail(SUTPriceList, (DateTime)recProc.ActionDate);
                                    
                                    foreach (PricingDetailDefinition pp in pricingDetailList)
                                    {
                                        if(pp.Price != null)
                                        {
                                            recProc.UnitPrice = (double)pp.Price;
                                            recProc.Price = pp;
                                        }
                                        priceCount ++;
                                    }
                                    
                                    if (priceCount == 0)
                                    {
                                        recProc.UnitPrice = 0;
                                        InfoBox.Alert(recProc.Procedure.Code + " " + recProc.Procedure.Name + " hizmetinin eşleştiği aktif SUT fiyatı bulunamadı!", TTDefinitionManagement.MessageIconEnum.WarningMessage);
                                    }
                                    if (priceCount > 1)
                                    {
                                        recProc.UnitPrice = 0;
                                        recProc.Price = null;
                                        InfoBox.Alert(recProc.Procedure.Code + " " + recProc.Procedure.Name + " hizmetinin eşleştiği birden çok aktif SUT fiyatı bulundu, bu yüzden Birim Fiyat sıfır olarak güncellendi. Hizmetin eşleşmiş olduğu aktif SUT fiyatlarını kontrol ediniz!", TTDefinitionManagement.MessageIconEnum.WarningMessage);
                                    }
                                    
                                    recProc.TotalPrice = recProc.Amount * recProc.UnitPrice;
                                    
                                    totalPrice = totalPrice + (double)recProc.TotalPrice;
                                }
                            }
                            else
                            {
                                _GeneralReceipt.IsIntegration = false;
                                GRIDReceiptProcedures.AllowUserToAddRows = true;
                                GRIDReceiptProcedures.AllowUserToDeleteRows = true;
                                GRIDReceiptProcedures.ReadOnly = false;
                            }
                            
                            _GeneralReceipt.TotalPrice = totalPrice;
                            _GeneralReceipt.TotalPayment = 0 ;
                            
                            _GeneralReceipt.GeneralReceiptDocument.TotalPrice = 0;
                            _GeneralReceipt.GeneralReceiptDocument.CurrentStateDefID = GeneralReceiptDocument.States.New;
                            
                            if (this._GeneralReceipt.TotalPrice > 0)
                            {
                                Cash csh = new Cash(_GeneralReceipt.ObjectContext);
                                csh.Price = this._GeneralReceipt.TotalPrice;
                                
                                IList curTypeList  = CurrencyTypeDefinition.GetByQref(_GeneralReceipt.ObjectContext,"TL");
                                if (curTypeList.Count != 0)
                                {
                                    foreach (CurrencyTypeDefinition curType in curTypeList)
                                    {
                                        csh.CurrencyType = curType;
                                        break ;
                                    }
                                }
                                this._GeneralReceipt.GeneralReceiptDocument.CashPayment.Add(csh);
                                this._GeneralReceipt.TotalPayment = this._GeneralReceipt.GeneralReceiptDocument.GetTotalPayment();
                            }
                        }
                    }
                }
            }
            else
            {
                if (this._GeneralReceipt.GeneralReceiptDocument.CashPayment.Count == 0)
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_GeneralReceiptReport));
                
                if (this._GeneralReceipt.GeneralReceiptDocument.CreditCardPayments.Count == 0)
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_GeneralReceiptCreditCardReport));
                
                if (this._GeneralReceipt.IsIntegration == true)
                    this.DropStateButton(GeneralReceipt.States.Cancelled);
                    
            }
#endregion GeneralReceiptForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region GeneralReceiptForm_PostScript
    if (_GeneralReceipt.GeneralReceiptDocument.CashPayment.Count == 0)
                _GeneralReceipt.GeneralReceiptDocument.DocumentNo = null;
            
            if (_GeneralReceipt.GeneralReceiptDocument.CreditCardPayments.Count == 0)
                _GeneralReceipt.GeneralReceiptDocument.CreditCardDocumentNo = null;
#endregion GeneralReceiptForm_PostScript

            }
            
#region GeneralReceiptForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            // Nakit ve Kredi Kartı raporları dökülür
            if(transDef != null && transDef.ToStateDefID == GeneralReceipt.States.Completed)
            {
                if (_GeneralReceipt.GeneralReceiptDocument.CashPayment.Count > 0)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _GeneralReceipt.ObjectID.ToString());
                    
                    parameters.Add("TTOBJECTID",cache);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_GeneralReceiptReport), true, 1, parameters);
                }
                
                if (_GeneralReceipt.GeneralReceiptDocument.CreditCardPayments.Count > 0)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _GeneralReceipt.ObjectID.ToString());
                    
                    parameters.Add("TTOBJECTID",cache);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_GeneralReceiptCreditCardReport), true, 1, parameters);
                }
            }
            
        }
        
#endregion GeneralReceiptForm_Methods
    }
}*/