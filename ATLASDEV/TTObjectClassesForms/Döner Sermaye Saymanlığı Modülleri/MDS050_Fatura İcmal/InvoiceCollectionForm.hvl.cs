
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
    public partial class InvoiceCollectionForm : TTUnboundForm
    {
        protected ITTButton ttbutton1;
        protected ITTLabel lblCreateUser;
        protected ITTCheckBox ttcheckbox1;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tbInvoiceCollectionSendNo;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tbCapacity;
        protected ITTTextBox tttextbox6;
        protected ITTLabel lblIcmalNo;
        protected ITTLabel lblNote;
        protected ITTLabel lblState;
        protected ITTListDefComboBox cbInvoiceTerm;
        protected ITTLabel ttlabel1;
        protected ITTLabel lblTedaviTipi;
        protected ITTListDefComboBox cbTedaviTuru;
        protected ITTDateTimePicker dtpInvoiceCollectionFirstDate;
        protected ITTLabel lblDate;
        protected ITTLabel dateLabel;
        protected ITTDateTimePicker dtpInvoiceCollectionStateFirstDate;
        protected ITTLabel lblSendNo;
        protected ITTObjectListBox lbPayerDefinition;
        protected ITTLabel lblPayer;
        protected ITTLabel lblDescription;
        protected ITTListDefComboBox ttlistdefcombobox3;
        protected ITTLabel lblTedaviTuru;
        protected ITTListDefComboBox ttlistdefcombobox4;
        protected ITTLabel lblTakipTipi;
        protected ITTListDefComboBox ttlistdefcombobox5;
        protected ITTLabel lblProvizyonTipi;
        protected ITTLabel lblCapacity;
        protected ITTLabel lblName;
        override protected void InitializeControls()
        {
            ttbutton1 = (ITTButton)AddControl(new Guid("ad742384-3eaa-4336-892a-0da0dfbfe990"));
            lblCreateUser = (ITTLabel)AddControl(new Guid("bcddcfa5-9ae8-4141-9887-461444299192"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("4fdf4315-b58b-4963-a02f-7db73c59e95a"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("e197eed7-a3c0-4086-b5c9-b49926a8efc6"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("dfc47c9b-9c67-4289-b96f-357df882f719"));
            tbInvoiceCollectionSendNo = (ITTTextBox)AddControl(new Guid("87911d72-325c-4540-a47d-5397deaf042d"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("dccb9cb6-8415-4b00-ad28-90489d532a61"));
            tbCapacity = (ITTTextBox)AddControl(new Guid("1588ac8b-027e-4c99-a309-a72f2c2aafb3"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("53d35e83-f038-41d6-a5de-92740bbd83c7"));
            lblIcmalNo = (ITTLabel)AddControl(new Guid("67554bad-b713-43bb-b0da-41dd7ad53739"));
            lblNote = (ITTLabel)AddControl(new Guid("8a5e1fb3-7fb9-40e8-867b-08eb1bb33af1"));
            lblState = (ITTLabel)AddControl(new Guid("0a5379ac-0e4e-4d4b-8a38-2eba8de3c39d"));
            cbInvoiceTerm = (ITTListDefComboBox)AddControl(new Guid("6e590b3a-419a-4623-957f-4c78b006dfe6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5b4f7454-c581-43d5-baf4-40ea4b30a98a"));
            lblTedaviTipi = (ITTLabel)AddControl(new Guid("3c721563-c0f2-48c9-9117-6950cd906793"));
            cbTedaviTuru = (ITTListDefComboBox)AddControl(new Guid("e497de08-9b61-47be-92a3-fd7e31f012ef"));
            dtpInvoiceCollectionFirstDate = (ITTDateTimePicker)AddControl(new Guid("bdb8410a-6538-465a-8e28-45e71552948e"));
            lblDate = (ITTLabel)AddControl(new Guid("d5c2c170-2f11-416a-b4c9-6a994565fb0f"));
            dateLabel = (ITTLabel)AddControl(new Guid("e75ce820-1288-4381-ba1c-8724a6084a4b"));
            dtpInvoiceCollectionStateFirstDate = (ITTDateTimePicker)AddControl(new Guid("783ae8cc-182b-4dae-96e1-91b163e12832"));
            lblSendNo = (ITTLabel)AddControl(new Guid("44c77a80-0bfc-4fae-8140-40ce40f988f3"));
            lbPayerDefinition = (ITTObjectListBox)AddControl(new Guid("4c0c91d6-8963-448d-97d1-52153f388ec5"));
            lblPayer = (ITTLabel)AddControl(new Guid("b5ba09fe-74c0-4c90-b68a-f8eb3e61a4f5"));
            lblDescription = (ITTLabel)AddControl(new Guid("1103b870-2c94-4403-b0b9-bcaac19fde50"));
            ttlistdefcombobox3 = (ITTListDefComboBox)AddControl(new Guid("7059e8ba-d20c-45a5-9fd3-fbc09ddb2573"));
            lblTedaviTuru = (ITTLabel)AddControl(new Guid("e65fead1-e671-4602-865a-b1b6d9c4199a"));
            ttlistdefcombobox4 = (ITTListDefComboBox)AddControl(new Guid("e1d8f325-ea12-4250-a7c3-e617de0c803b"));
            lblTakipTipi = (ITTLabel)AddControl(new Guid("7c97bb93-2909-402b-9df1-0f3340422279"));
            ttlistdefcombobox5 = (ITTListDefComboBox)AddControl(new Guid("5c050a46-ee85-483c-abf2-76cad9fb5569"));
            lblProvizyonTipi = (ITTLabel)AddControl(new Guid("989fc467-4129-4d66-8b25-e3925a3130d8"));
            lblCapacity = (ITTLabel)AddControl(new Guid("c3e53430-b4d9-4519-ac6a-2f573868616a"));
            lblName = (ITTLabel)AddControl(new Guid("3951f120-35f7-4bb9-93cf-97f29614e27d"));
            base.InitializeControls();
        }

        public InvoiceCollectionForm() : base("InvoiceCollectionForm")
        {
        }

        protected InvoiceCollectionForm(string formDefName) : base(formDefName)
        {
        }
    }
}