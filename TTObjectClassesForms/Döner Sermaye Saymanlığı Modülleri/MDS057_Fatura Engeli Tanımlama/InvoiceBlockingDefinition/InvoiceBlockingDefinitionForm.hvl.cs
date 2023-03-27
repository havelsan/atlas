
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
    /// Fatura Engeli Tanımlama
    /// </summary>
    public partial class InvoiceBlockingDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Fatura Engeli Tanımlama
    /// </summary>
        protected TTObjectClasses.InvoiceBlockingDefinition _InvoiceBlockingDefinition
        {
            get { return (TTObjectClasses.InvoiceBlockingDefinition)_ttObject; }
        }

        protected ITTCheckBox IsActive;
        protected ITTCheckBox CashOfficeBlock;
        protected ITTCheckBox InvoiceBlock;
        protected ITTTextBox StateDefId;
        protected ITTComboBox StateComboBox;
        protected ITTLabel lblStateDef;
        protected ITTLabel lblSP;
        protected ITTLabel lblEA;
        protected ITTComboBox EAComboBox;
        protected ITTLabel lblStateId;
        protected ITTComboBox SPComboBox;
        override protected void InitializeControls()
        {
            IsActive = (ITTCheckBox)AddControl(new Guid("a3125b1b-555d-4fc0-ac5f-31cdbcaf6b88"));
            CashOfficeBlock = (ITTCheckBox)AddControl(new Guid("b8cec1da-e699-4202-93dd-bdb1c88542b8"));
            InvoiceBlock = (ITTCheckBox)AddControl(new Guid("6990cd46-10ca-4801-8ca1-2b74974a17db"));
            StateDefId = (ITTTextBox)AddControl(new Guid("f442a1b7-a724-4722-8632-0c1cd9966147"));
            StateComboBox = (ITTComboBox)AddControl(new Guid("77091628-24ba-4714-b944-9992b66733ff"));
            lblStateDef = (ITTLabel)AddControl(new Guid("14faf2c0-8c58-44b8-9a18-91399adb43c6"));
            lblSP = (ITTLabel)AddControl(new Guid("4e1a0151-6d59-465d-a2d5-77eb15ca1227"));
            lblEA = (ITTLabel)AddControl(new Guid("84eb7671-bf52-4bba-bfcc-dcea882b3a8f"));
            EAComboBox = (ITTComboBox)AddControl(new Guid("45113036-463a-40dc-ac25-929f057a164e"));
            lblStateId = (ITTLabel)AddControl(new Guid("8c7511a7-4a48-4c31-b729-ac4f4c57515d"));
            SPComboBox = (ITTComboBox)AddControl(new Guid("fc0eb637-1cc3-4c26-84ee-1ca1a12e4ebb"));
            base.InitializeControls();
        }

        public InvoiceBlockingDefinitionForm() : base("INVOICEBLOCKINGDEFINITION", "InvoiceBlockingDefinitionForm")
        {
        }

        protected InvoiceBlockingDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}