
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
    /// Hesap Tanımlama
    /// </summary>
    public partial class NewAccountForm : TTForm
    {
    /// <summary>
    /// Hesap
    /// </summary>
        protected TTObjectClasses.MhSAccount _MhSAccount
        {
            get { return (TTObjectClasses.MhSAccount)_ttObject; }
        }

        protected ITTObjectListBox ParentAccount;
        protected ITTTabPage tttabpage1;
        protected ITTTabPage AccountRules;
        protected ITTLabel labelDebit;
        protected ITTTextBox Code;
        protected ITTGrid BalanceStatuses;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel12;
        protected ITTLabel Credit;
        protected ITTLabel labelType;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTListDefComboBox ExpenceCenter;
        protected ITTLabel labelCode;
        protected ITTTabPage Balances;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelName;
        protected ITTListDefComboBox Group2;
        protected ITTListDefComboBox Group4;
        protected ITTLabel labelBalance;
        protected ITTTabControl tttabcontrol1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox Name;
        protected ITTLabel ttlabel11;
        protected ITTTextBox Comment;
        protected ITTLabel labelCredit;
        protected ITTListDefComboBox Group3;
        protected ITTLabel ttlabel8;
        protected ITTTabPage AccountDetail;
        protected ITTListDefComboBox Group1;
        protected ITTLabel Balance;
        protected ITTLabel labelComment;
        protected ITTLabel Debit;
        override protected void InitializeControls()
        {
            ParentAccount = (ITTObjectListBox)AddControl(new Guid("34ba9c5b-dc29-4d6b-b28b-09e7bd28fb2b"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("5d72d443-8ebc-4f60-907f-eba9e6fdfe5d"));
            AccountRules = (ITTTabPage)AddControl(new Guid("8974fdab-f651-4176-b1bf-dea0a2c043b5"));
            labelDebit = (ITTLabel)AddControl(new Guid("6189ed06-8240-4426-ad37-d949d4cf7bd3"));
            Code = (ITTTextBox)AddControl(new Guid("a9e36e8d-e8b3-4c3d-806a-bd562daee4fd"));
            BalanceStatuses = (ITTGrid)AddControl(new Guid("b0707030-f638-4754-b55b-bf0d468f1dc0"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("1e0e0eac-3830-46ad-b57f-cc0bd2dda4cb"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("97d05835-943a-4618-9af0-c465b568aa5c"));
            Credit = (ITTLabel)AddControl(new Guid("fdba13d1-2d37-4f6c-84c0-afc6cb0df325"));
            labelType = (ITTLabel)AddControl(new Guid("f5488246-85cc-4a45-a152-a0fe8e930d49"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("22a44ef4-ee0b-4574-9e29-a74da518d94e"));
            ExpenceCenter = (ITTListDefComboBox)AddControl(new Guid("f6ede609-f93b-430b-becd-a3bc23a6135e"));
            labelCode = (ITTLabel)AddControl(new Guid("f8acd3f5-905e-48f1-b800-839d0cf13bec"));
            Balances = (ITTTabPage)AddControl(new Guid("ae3a819a-8983-4975-adb8-94256c84e375"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("fd24e6cc-66be-42c5-9c4a-7e7e27163e5c"));
            labelName = (ITTLabel)AddControl(new Guid("dd4c17ad-1fda-45a4-aaba-569fc592f490"));
            Group2 = (ITTListDefComboBox)AddControl(new Guid("540870ad-7bed-4652-a369-61573160e515"));
            Group4 = (ITTListDefComboBox)AddControl(new Guid("4db335ef-f797-4724-96d7-5dcafe881838"));
            labelBalance = (ITTLabel)AddControl(new Guid("2d666180-da88-471a-9cd8-5f697b9042ee"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("bf4af797-96b7-4372-9ef8-372e298c0cde"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("07f937ef-acac-4477-8270-636606db38c5"));
            Name = (ITTTextBox)AddControl(new Guid("bdce5f03-668b-4f94-8a01-41dc134ba13f"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("77431df6-3096-44db-a33e-275b361d08b2"));
            Comment = (ITTTextBox)AddControl(new Guid("d3a57556-d410-4d76-ad42-25bb2216630c"));
            labelCredit = (ITTLabel)AddControl(new Guid("f58e84a9-fab9-4fc1-86b8-1775d0837d3c"));
            Group3 = (ITTListDefComboBox)AddControl(new Guid("30d3753c-14e5-4d94-8152-2b5f3453312f"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("33232581-f195-4c4f-981e-17004c99fd64"));
            AccountDetail = (ITTTabPage)AddControl(new Guid("a2c4c4fc-f5b7-4cd5-a97b-20e2907b2fd5"));
            Group1 = (ITTListDefComboBox)AddControl(new Guid("5f5b6f15-d23d-49f9-9fb2-0bcca8773e36"));
            Balance = (ITTLabel)AddControl(new Guid("90cf4589-e53b-4453-a8e9-023f71e26932"));
            labelComment = (ITTLabel)AddControl(new Guid("1acc101d-4342-4dbc-9257-f020b432889d"));
            Debit = (ITTLabel)AddControl(new Guid("d238bcf3-0ed3-49af-b054-e6edd1b52d76"));
            base.InitializeControls();
        }

        public NewAccountForm() : base("MHSACCOUNT", "NewAccountForm")
        {
        }

        protected NewAccountForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}