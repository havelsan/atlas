
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
    /// Hesap Planı
    /// </summary>
    public partial class ChartOfAccountsForm : TTForm
    {
    /// <summary>
    /// Hesap Planı
    /// </summary>
        protected TTObjectClasses.MhSChartOfAccounts _MhSChartOfAccounts
        {
            get { return (TTObjectClasses.MhSChartOfAccounts)_ttObject; }
        }

        protected ITTButton deleteAccountButton;
        protected ITTObjectListBox labelPeriod;
        protected ITTLabel labelComment;
        protected ITTGrid Accounts;
        protected ITTLabel labelName;
        protected ITTButton editAccountButton;
        protected ITTLabel labePeriod;
        protected ITTTextBox Comment;
        protected ITTButton newAccountButton;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            deleteAccountButton = (ITTButton)AddControl(new Guid("203f768f-6677-46fe-869b-18c02b93a077"));
            labelPeriod = (ITTObjectListBox)AddControl(new Guid("9f2ff6a1-d8e4-4fac-b835-1730d498d683"));
            labelComment = (ITTLabel)AddControl(new Guid("dc70e834-32b1-4b18-bc1b-5311d862828f"));
            Accounts = (ITTGrid)AddControl(new Guid("4119f8ae-bcc0-4694-8682-62d98a812983"));
            labelName = (ITTLabel)AddControl(new Guid("97ce43e2-bab5-4c42-8ab3-54e750d7a69b"));
            editAccountButton = (ITTButton)AddControl(new Guid("6340ec28-e894-4d04-8864-7bb198af977f"));
            labePeriod = (ITTLabel)AddControl(new Guid("dceb204f-8e38-49ca-b50e-80613f937b74"));
            Comment = (ITTTextBox)AddControl(new Guid("891c7076-b953-47f2-b38e-a001b21fffce"));
            newAccountButton = (ITTButton)AddControl(new Guid("4ae58a9f-f8f0-46ab-9620-adc6057d8793"));
            Name = (ITTTextBox)AddControl(new Guid("91ffeafe-ba9a-41dd-abd7-a067dc959e24"));
            base.InitializeControls();
        }

        public ChartOfAccountsForm() : base("MHSCHARTOFACCOUNTS", "ChartOfAccountsForm")
        {
        }

        protected ChartOfAccountsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}