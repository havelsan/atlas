
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
    /// Avans Alma
    /// </summary>
    public partial class AdvanceForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
            #region AdvanceForm_PreScript
            base.PreScript();
            #endregion AdvanceForm_PreScript

        }

        protected override void ClientSidePreScript()
        {
            #region AdvanceForm_ClientSidePreScript
            base.ClientSidePreScript();
            if (_Advance.CurrentStateDefID == Advance.States.New)
            {
                ResUser resUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

                selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);

                if (selectedCashOffice == null)
                    throw new TTException("Bu kullanýcý için tanýmlý bir vezne yok ya da Avans almaya yetikiniz bulunmamaktadýr!!");

                List<ReceiptCashOfficeDefinition> receiptCashOfficeDefList = ReceiptCashOfficeDefinition.GetByCashOffice(_Advance.ObjectContext, selectedCashOffice.ObjectID.ToString()).ToList();

                //Aktif vezne alýndý numarasý tanýmlanmamýþ
                if (receiptCashOfficeDefList.Where(x => x.IsActive == true).Count() == 0)
                {
                    throw new TTUtils.TTException("Vezne için aktif vezne alýndý numarasý bulunmamaktadýr!");
                }
                else
                {
                    ReceiptCashOfficeDefinition selectedRCODef = new ReceiptCashOfficeDefinition();
                    selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(_Advance.ObjectContext, selectedCashOffice.ObjectID); /*receiptCashOfficeDefList.OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();*/

                    this.cmdOK.Visible = false;
                    _Advance.CashOfficeName = selectedCashOffice.Name;

                    if (_Advance.AdvanceDocument == null)
                    {
                        _Advance.AdvanceDocument = new AdvanceDocument(_Advance.ObjectContext);
                        _Advance.AdvanceDocument.PatientName = _Advance.Episode.Patient.Name + " " + _Advance.Episode.Patient.Surname;
                        _Advance.AdvanceDocument.PatientNo = _Advance.Episode.Patient.ID.Value;
                        _Advance.AdvanceDocument.DocumentDate = Common.RecTime();
                        _Advance.AdvanceDocument.PayeeName = _Advance.Episode.Patient.FullName;
                        _Advance.AdvanceDocument.ResUser = resUser;
                        _Advance.AdvanceDocument.CashOffice = selectedCashOffice;
                        _Advance.AdvanceDocument.PaymentType = PaymentTypeEnum.Cash;
                        _Advance.AdvanceDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
                    }
                }
            }
            else if (_Advance.CurrentStateDefID == Advance.States.Paid)
            {
                if (this._Advance.AdvanceDocument.CashPayment.Count == 0)
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_AdvanceDocumentCashReport));
                if (this._Advance.AdvanceDocument.CreditCardPayments.Count == 0)
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_AdvanceDocumentCreditCardReport));
                if (this._Advance.AdvanceDocument.DebenturePayments.Count == 0)
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_AdvanceDebentureReport));
            }
            #endregion AdvanceForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region AdvanceForm_PostScript
            _Advance.AdvanceDocument.TotalPrice = _Advance.TotalPrice;
            /*if (_Advance.AdvanceDocument.CreditCardPayments.Count == 0)
                _Advance.AdvanceDocument.CreditCardDocumentNo = null;
            if (_Advance.AdvanceDocument.CashPayment.Count == 0)
                _Advance.AdvanceDocument.DocumentNo = null;*/
            #endregion AdvanceForm_PostScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region AdvanceForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);
            #endregion AdvanceForm_ClientSidePostScript

        }

        #region AdvanceForm_Methods
        public CashOfficeDefinition selectedCashOffice;
        public List<CashOfficeComputerUserDefinition> cashOfficeCompUserList = new List<CashOfficeComputerUserDefinition>();
        private void Update_TotalPrice()
        {
            _Advance.TotalPrice = Convert.ToDouble(TOTALPRICE.Text);
        }

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            /*
            base.AfterContextSavedScript(transDef);

            // Nakit ve Kredi Kartý makbuzlarý dökülür
            if (transDef != null && transDef.ToStateDefID == Advance.States.Paid)
            {
                if (_Advance.AdvanceDocument.CashPayment.Count > 0)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _Advance.ObjectID.ToString());

                    parameters.Add("TTOBJECTID", cache);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_AdvanceDocumentCashReport), true, 1, parameters);
                }

                if (_Advance.AdvanceDocument.CreditCardPayments.Count > 0)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _Advance.ObjectID.ToString());

                    parameters.Add("TTOBJECTID", cache);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_AdvanceDocumentCreditCardReport), true, 1, parameters);
                }

                if (_Advance.AdvanceDocument.DebenturePayments.Count > 0)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                    cache.Add("VALUE", _Advance.ObjectID.ToString());

                    parameters.Add("TTOBJECTID", cache);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_AdvanceDebentureReport), true, 1, parameters);
                }
            }*/
        }

        #endregion AdvanceForm_Methods
    }
}