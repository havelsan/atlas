
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
    /// Banka Ödeme Fişi Girişi
    /// </summary>
    public partial class BankPaymentDecountForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void ClientSidePreScript()
        {
            base.ClientSidePreScript();

            cmdOK.Visible = false;
            if (_BankPaymentDecount.CurrentStateDefID == BankPaymentDecount.States.New)
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                CashOfficeDefinition selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);

                if (selectedCashOffice == null)
                    throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Diğer Tahsilatları yapmaya yetikiniz bulunmamaktadır!");

                _BankPaymentDecount.BankPaymentDecountDocument = new BankPaymentDecountDocument(_BankPaymentDecount.ObjectContext);
                _BankPaymentDecount.BankPaymentDecountDocument.CashOffice = selectedCashOffice;
                _BankPaymentDecount.BankPaymentDecountDocument.ResUser = resUser;
                _BankPaymentDecount.BankPaymentDecountDocument.CurrentStateDefID = BankPaymentDecountDocument.States.New;
                _BankPaymentDecount.BankPaymentDecountDocument.DocumentDate = Common.RecTime();
            }
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region MainCashOfficeOperationForm_PostScript
            if (_BankPaymentDecount.TotalPrice == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(187));
            else
                _BankPaymentDecount.BankPaymentDecountDocument.TotalPrice = _BankPaymentDecount.TotalPrice;
            #endregion MainCashOfficeOperationForm_PostScript

        }

    }
}