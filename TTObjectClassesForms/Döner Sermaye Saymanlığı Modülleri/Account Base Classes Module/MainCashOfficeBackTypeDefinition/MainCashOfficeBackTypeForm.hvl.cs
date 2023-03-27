
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
    /// Vezne İade Türü Tanımı
    /// </summary>
    public partial class MainCashOfficeBackTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Vezne İade Türü Tanımı
    /// </summary>
        protected TTObjectClasses.MainCashOfficeBackTypeDefinition _MainCashOfficeBackTypeDefinition
        {
            get { return (TTObjectClasses.MainCashOfficeBackTypeDefinition)_ttObject; }
        }

        protected ITTTextBox NAME;
        protected ITTTextBox CODE;
        protected ITTTextBox ACCOUNTCODE;
        protected ITTTextBox DEBTACCOUNTCODE;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel17;
        protected ITTCheckBox AccountEntegration;
        protected ITTCheckBox IsBankOperation;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox cbxActive;
        override protected void InitializeControls()
        {
            NAME = (ITTTextBox)AddControl(new Guid("9e190ed7-6417-4247-b796-422dfa5996e3"));
            CODE = (ITTTextBox)AddControl(new Guid("92c04b38-5d1e-4c31-92bb-5fb82a86afa6"));
            ACCOUNTCODE = (ITTTextBox)AddControl(new Guid("80aebe85-3603-4259-ab45-79aaa746944e"));
            DEBTACCOUNTCODE = (ITTTextBox)AddControl(new Guid("2f09efa7-d096-4ffe-a539-b1733722dccc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("159088b5-c154-40f7-9c07-f5817494a883"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("264fe98d-0098-425e-9b82-6d8b33612462"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("ef5ad474-cf64-427f-a3ef-67d4cbbcfde9"));
            AccountEntegration = (ITTCheckBox)AddControl(new Guid("9623a1cd-29da-4efd-8a81-b8f254df882d"));
            IsBankOperation = (ITTCheckBox)AddControl(new Guid("de2ebac1-e83f-4f70-bc45-d3e5555d5d8a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b608f1c3-ce1a-4c97-9688-1ca5c91a6874"));
            cbxActive = (ITTCheckBox)AddControl(new Guid("ab43126b-613f-4750-a477-ecdee2a34287"));
            base.InitializeControls();
        }

        public MainCashOfficeBackTypeForm() : base("MAINCASHOFFICEBACKTYPEDEFINITION", "MainCashOfficeBackTypeForm")
        {
        }

        protected MainCashOfficeBackTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}