
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
    /// Banka Hesap Tanımı
    /// </summary>
    public partial class BankAccountForm : TTDefinitionForm
    {
    /// <summary>
    /// Banka Hesap Tanımı
    /// </summary>
        protected TTObjectClasses.BankAccountDefinition _BankAccountDefinition
        {
            get { return (TTObjectClasses.BankAccountDefinition)_ttObject; }
        }

        protected ITTCheckBox UseInInvoicePaymentCheckBox;
        protected ITTTextBox ACCOUNTNO;
        protected ITTTextBox IBAN;
        protected ITTTextBox ACCOUNTCODE;
        protected ITTLabel ttlabel1;
        protected ITTValueListBox BANKBRANCH;
        protected ITTLabel TTLABEL8;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel17;
        override protected void InitializeControls()
        {
            UseInInvoicePaymentCheckBox = (ITTCheckBox)AddControl(new Guid("6aa90af7-4049-4100-9690-cca22ef483f0"));
            ACCOUNTNO = (ITTTextBox)AddControl(new Guid("a402f11b-c596-46d9-9e04-6aa2b98ae650"));
            IBAN = (ITTTextBox)AddControl(new Guid("146f9757-d8fa-4ce8-b990-8f8da93f756c"));
            ACCOUNTCODE = (ITTTextBox)AddControl(new Guid("7959c2be-5796-42f8-9f7e-db5c2debf180"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("af05da5d-9056-4b39-b58a-83a11f86e103"));
            BANKBRANCH = (ITTValueListBox)AddControl(new Guid("4003bdb1-3364-46b8-b24c-332f35510def"));
            TTLABEL8 = (ITTLabel)AddControl(new Guid("f4350b87-af1a-464f-8d1b-9dc0c8429439"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c4faedda-0c36-4222-8e37-fd39d2193d6e"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("691e2084-bab3-479f-b7fd-cfb1ade79f8f"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("aded6114-726f-44b5-9c5d-a479e2efecd1"));
            base.InitializeControls();
        }

        public BankAccountForm() : base("BANKACCOUNTDEFINITION", "BankAccountForm")
        {
        }

        protected BankAccountForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}