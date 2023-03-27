
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Toplam Borç
    /// </summary>
    public partial class AccountTotalDebtForm : TTForm
    {
        protected TTObjectClasses.AccountTotalDebt _AccountTotalDebt
        {
            get { return (TTObjectClasses.AccountTotalDebt)_ttObject; }
        }

        protected ITTLabel labelAccountPeriod;
        protected ITTObjectListBox AccountPeriod;
        protected ITTLabel labelTotalDebt;
        protected ITTTextBox TotalDebt;
        override protected void InitializeControls()
        {
            labelAccountPeriod = (ITTLabel)AddControl(new Guid("06901258-7f24-4650-b5f8-a6a36a9437ec"));
            AccountPeriod = (ITTObjectListBox)AddControl(new Guid("41f805ea-4718-4946-bfdc-1b0c477e424d"));
            labelTotalDebt = (ITTLabel)AddControl(new Guid("b7c4fcbd-60ec-4348-99b0-9dfe674e3a19"));
            TotalDebt = (ITTTextBox)AddControl(new Guid("53fc4849-a5a7-489a-947b-2fac9842d4e3"));
            base.InitializeControls();
        }

        public AccountTotalDebtForm() : base("ACCOUNTTOTALDEBT", "AccountTotalDebtForm")
        {
        }

        protected AccountTotalDebtForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}