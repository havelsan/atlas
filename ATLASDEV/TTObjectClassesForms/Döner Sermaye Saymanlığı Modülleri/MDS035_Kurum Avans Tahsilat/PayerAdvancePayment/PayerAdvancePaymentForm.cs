
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
    /// Kurum Avans Tahsilat
    /// </summary>
    public partial class PayerAdvancePaymentForm : TTForm
    {
        override protected void BindControlEvents()
        {
            GridCashPayment.CellValueChanged += new TTGridCellEventDelegate(GridCashPayment_CellValueChanged);
            GridBankDecountPayment.CellValueChanged += new TTGridCellEventDelegate(GridBankDecountPayment_CellValueChanged);
            GridChequePayment.CellValueChanged += new TTGridCellEventDelegate(GridChequePayment_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridCashPayment.CellValueChanged -= new TTGridCellEventDelegate(GridCashPayment_CellValueChanged);
            GridBankDecountPayment.CellValueChanged -= new TTGridCellEventDelegate(GridBankDecountPayment_CellValueChanged);
            GridChequePayment.CellValueChanged -= new TTGridCellEventDelegate(GridChequePayment_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GridCashPayment_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PayerAdvancePaymentForm_GridCashPayment_CellValueChanged
   if (columnIndex == 0 && rowIndex != -1)
            {
                this._PayerAdvancePayment.TotalPrice = this._PayerAdvancePayment.PayerAdvancePaymentDocument.GetTotalPayment();
            }
#endregion PayerAdvancePaymentForm_GridCashPayment_CellValueChanged
        }

        private void GridBankDecountPayment_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PayerAdvancePaymentForm_GridBankDecountPayment_CellValueChanged
   if (columnIndex == 2 && rowIndex != -1)
            {
                this._PayerAdvancePayment.TotalPrice = this._PayerAdvancePayment.PayerAdvancePaymentDocument.GetTotalPayment();
            }
#endregion PayerAdvancePaymentForm_GridBankDecountPayment_CellValueChanged
        }

        private void GridChequePayment_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PayerAdvancePaymentForm_GridChequePayment_CellValueChanged
   if (columnIndex == 1 && rowIndex != -1)
            {
                this._PayerAdvancePayment.TotalPrice = this._PayerAdvancePayment.PayerAdvancePaymentDocument.GetTotalPayment();
            }
#endregion PayerAdvancePaymentForm_GridChequePayment_CellValueChanged
        }

        protected override void PreScript()
        {
#region PayerAdvancePaymentForm_PreScript
    if (_PayerAdvancePayment.CurrentStateDefID == PayerAdvancePayment.States.New)
            {
                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

                CashierLog _myCashierLog = null;
                if (_myResUser != null)
                    _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
                
                if (_myCashierLog == null)
                    throw new TTException(SystemMessage.GetMessage(210));
                else
                {
                    /*
                    if (_myCashierLog.CashOffice.Type != CashOfficeTypeEnum.InvoicingService)
                        throw new TTException(SystemMessage.GetMessage(210));
                    else
                    {
                     */
                    this.cmdOK.Visible = false;
                    _PayerAdvancePayment.CashOfficeName = _myCashierLog.CashOffice.Name;

                    if (_PayerAdvancePayment.PayerAdvancePaymentDocument == null)
                    {
                        _PayerAdvancePayment.PayerAdvancePaymentDocument = new PayerAdvancePaymentDocument(_PayerAdvancePayment.ObjectContext);
                        _PayerAdvancePayment.PayerAdvancePaymentDocument.CashierLog = _myCashierLog;
                        _PayerAdvancePayment.PayerAdvancePaymentDocument.DocumentDate = DateTime.Now.Date;
                        _PayerAdvancePayment.PayerAdvancePaymentDocument.TotalPrice = 0;
                        _PayerAdvancePayment.PayerAdvancePaymentDocument.CurrentStateDefID = PayerAdvancePaymentDocument.States.New;
                    }
                    //}
                }
            }
#endregion PayerAdvancePaymentForm_PreScript

            }
                }
}