
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
    /// Vezne İade İşlemi
    /// </summary>
    public partial class MainCashOfficeBackOperationForm : TTForm
    {
        override protected void BindControlEvents()
        {
            MONEYBACKTYPE.SelectedObjectChanged += new TTControlEventDelegate(MONEYBACKTYPE_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MONEYBACKTYPE.SelectedObjectChanged -= new TTControlEventDelegate(MONEYBACKTYPE_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void MONEYBACKTYPE_SelectedObjectChanged()
        {
#region MainCashOfficeBackOperationForm_MONEYBACKTYPE_SelectedObjectChanged
   MainCashOfficeBackTypeDefinition _myBackType = null;
            _myBackType = (MainCashOfficeBackTypeDefinition) this.MONEYBACKTYPE.SelectedObject;
            
            if (_myBackType.IsBankOperation == true)
            {
                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                CashierLog  _myCashierLog = null;
                if (_myResUser != null)
                    _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();

                ReceiptCashOfficeDefinition _myReceiptCashOfficeDefinition;
                IList myList = ReceiptCashOfficeDefinition.GetByCashOffice(_MainCashOfficeBackOperation.ObjectContext, _myCashierLog.CashOffice.ObjectID.ToString());
                
                if (myList.Count == 0)
                {
                    throw new TTException("İşlem yapılan vezne (" + _MainCashOfficeBackOperation.CashOfficeName + ") için Teslimat Müzekkeresi seri ve no bilgisi tanımlanmamış.");
                }
                else
                {
//                    _myReceiptCashOfficeDefinition = (ReceiptCashOfficeDefinition)_MainCashOfficeBackOperation.ObjectContext.QueryObjects("ReceiptCashOfficeDefinition", "CASHOFFICE = '" + _myCashierLog.CashOffice.ObjectID + "'" )[0];
//                    _MainCashOfficeBackOperation.MainCashOfficeBackDocument.DocumentNo = (string)_myReceiptCashOfficeDefinition.GetCurrentBankDeliveryNumber();
                }
                
                this.BANKACCOUNT.ReadOnly = false;
                this.BACKBANKACCOUNT.ReadOnly = true;
            }
            else
            {
                _MainCashOfficeBackOperation.MainCashOfficeBackDocument.DocumentNo = null;
                _MainCashOfficeBackOperation.MainCashOfficeBackDocument.BankAccount = null;
                this.BANKACCOUNT.ReadOnly = true;
                this.BACKBANKACCOUNT.ReadOnly = false;
            }
#endregion MainCashOfficeBackOperationForm_MONEYBACKTYPE_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region MainCashOfficeBackOperationForm_PreScript
    if (_MainCashOfficeBackOperation.CurrentStateDefID == MainCashOfficeBackOperation.States.New)
            {
                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                CashierLog  _myCashierLog = null;
                if (_myResUser != null)
                    _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
                
                if (_myCashierLog == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(185));
                else
                {
                    if (_myCashierLog.CashOffice.Type != CashOfficeTypeEnum.CashOffice)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(185));
                    else
                    {
                        this.cmdOK.Visible = false;
                        _MainCashOfficeBackOperation.CashOfficeName = _myCashierLog.CashOffice.Name;
                        _MainCashOfficeBackOperation.TotalPrice = 0;
                        
                        if (_MainCashOfficeBackOperation.MainCashOfficeBackDocument == null)
                        {
                            _MainCashOfficeBackOperation.MainCashOfficeBackDocument = new MainCashOfficeBackDocument(_MainCashOfficeBackOperation.ObjectContext);
                            _MainCashOfficeBackOperation.MainCashOfficeBackDocument.CashierLog = _myCashierLog;
                            _MainCashOfficeBackOperation.MainCashOfficeBackDocument.DocumentDate = DateTime.Now.Date;
                            _MainCashOfficeBackOperation.MainCashOfficeBackDocument.CurrentStateDefID = MainCashOfficeBackDocument.States.New;
                            _MainCashOfficeBackOperation.MainCashOfficeBackDocument.TotalPrice = 0;
                        }
                    }
                }
            }
            else
            {
                if (_MainCashOfficeBackOperation.MainCashOfficeBackDocument.MoneyBackType.IsBankOperation != true)
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_BankDeliveryReport));
            }
#endregion MainCashOfficeBackOperationForm_PreScript

            }
            
#region MainCashOfficeBackOperationForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            /*
            base.AfterContextSavedScript(transDef);

            // Raporlar dökülür
            if(transDef != null && transDef.ToStateDefID == MainCashOfficeBackOperation.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                
                TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                cache.Add("VALUE", _MainCashOfficeBackOperation.ObjectID.ToString());
                parameters.Add("TTOBJECTID",cache);
                
                if (_MainCashOfficeBackOperation.MainCashOfficeBackDocument.MoneyBackType.IsBankOperation == true)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_BankDeliveryReport), true, 1, parameters);
            }
            */
        }
        
#endregion MainCashOfficeBackOperationForm_Methods
    }
}