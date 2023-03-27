
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
//    /// Manuel Kurum Faturası
//    /// </summary>
//    public partial class ManualInvoiceForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            GRIDInvoiceProcedures.CellValueChanged += new TTGridCellEventDelegate(GRIDInvoiceProcedures_CellValueChanged);
//            KDVRATE.TextChanged += new TTControlEventDelegate(KDVRATE_TextChanged);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            GRIDInvoiceProcedures.CellValueChanged -= new TTGridCellEventDelegate(GRIDInvoiceProcedures_CellValueChanged);
//            KDVRATE.TextChanged -= new TTControlEventDelegate(KDVRATE_TextChanged);
//            base.UnBindControlEvents();
//        }

//        private void GRIDInvoiceProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region ManualInvoiceForm_GRIDInvoiceProcedures_CellValueChanged
//   if((columnIndex == 2 || columnIndex == 3 || columnIndex == 4) && rowIndex != -1)
//            {
//                ManualInvoiceProcedure manualInvoiceProcedure = GRIDInvoiceProcedures.CurrentCell.OwningRow.TTObject as ManualInvoiceProcedure;
//                if(manualInvoiceProcedure != null)
//                {
//                    if(columnIndex == 2 || columnIndex == 3)
//                    {
//                        if( manualInvoiceProcedure.Amount.HasValue && manualInvoiceProcedure.UnitPrice.HasValue)
//                            manualInvoiceProcedure.TotalPrice = manualInvoiceProcedure.Amount.Value * manualInvoiceProcedure.UnitPrice.Value;
//                        else
//                            manualInvoiceProcedure.TotalPrice = null;
                        
//                        CalculateInvoicePrice();
//                    }
//                    else if(columnIndex == 4)
//                        CalculateInvoicePrice();
//                }
//            }
//#endregion ManualInvoiceForm_GRIDInvoiceProcedures_CellValueChanged
//        }

//        private void KDVRATE_TextChanged()
//        {
//#region ManualInvoiceForm_KDVRATE_TextChanged
//   CalculateInvoicePrice();
//#endregion ManualInvoiceForm_KDVRATE_TextChanged
//        }

//        protected override void PreScript()
//        {
//#region ManualInvoiceForm_PreScript
//    if (_ManualInvoice.CurrentStateDefID == ManualInvoice.States.New)
//            {
//                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
//                CashierLog _myCashierLog = null;
//                if (_myResUser != null)
//                    _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
                
//                if (_myCashierLog == null)
//                    throw new TTException(SystemMessage.GetMessage(210));
//                else
//                {
//                    if (_myCashierLog.CashOffice.Type != CashOfficeTypeEnum.InvoicingService)
//                        throw new TTUtils.TTException(SystemMessage.GetMessage(210));
//                    else
//                    {
//                        this.cmdOK.Visible = false;
//                        _ManualInvoice.CashOfficeName = _myCashierLog.CashOffice.Name;
                        
//                        if (_ManualInvoice.ManualInvoiceDocument == null)
//                        {
//                            _ManualInvoice.ManualInvoiceDocument = new ManualInvoiceDocument(_ManualInvoice.ObjectContext);
//                            _ManualInvoice.ManualInvoiceDocument.CashierLog = _myCashierLog;
//                            _ManualInvoice.ManualInvoiceDocument.DocumentDate = DateTime.Now.Date;
//                            _ManualInvoice.ManualInvoiceDocument.CurrentStateDefID = ManualInvoiceDocument.States.New;
//                            _ManualInvoice.ManualInvoiceDocument.AccountAction = _ManualInvoice;
                            
                            
//                            _ManualInvoice.TotalPrice = 0;
//                            _ManualInvoice.ManualInvoiceDocument.TotalPrice = 0;
//                        }
//                    }
//                }
//            }
//#endregion ManualInvoiceForm_PreScript

//            }
            
//#region ManualInvoiceForm_ClientSideMethods
//        // Fatura Tutarı ve KDV'li Fatura Tutarı hesaplanır
//        public void CalculateInvoicePrice()
//        {
//            double totalPrice = 0;
//            foreach(ITTGridRow row in GRIDInvoiceProcedures.Rows)
//            {
//                ManualInvoiceProcedure manualInvoiceProcedure = row.TTObject as ManualInvoiceProcedure;
//                if(manualInvoiceProcedure != null && manualInvoiceProcedure.TotalPrice.HasValue)
//                    totalPrice += manualInvoiceProcedure.TotalPrice.Value;
//            }
            
//            _ManualInvoice.TotalPriceWithoutKDV = totalPrice;
            
//            if(!string.IsNullOrEmpty(_ManualInvoice.KDVRate.ToString()))
//            {
//                int kdv = Convert.ToInt16(_ManualInvoice.KDVRate.ToString());
//                if(kdv >= 0 && kdv <= 100)
//                    _ManualInvoice.TotalPrice = _ManualInvoice.TotalPriceWithoutKDV * (100 + kdv) / 100;
//                else
//                {
//                    _ManualInvoice.KDVRate = null;
//                    _ManualInvoice.TotalPrice = _ManualInvoice.TotalPriceWithoutKDV;
//                    InfoBox.Alert("KDV Oranı 0 ile 100 arasında bir değer olmalıdır.", TTDefinitionManagement.MessageIconEnum.WarningMessage);
//                }
//            }
//            else
//                _ManualInvoice.TotalPrice = _ManualInvoice.TotalPriceWithoutKDV;
//        }
        
//#endregion ManualInvoiceForm_ClientSideMethods
//    }
//}