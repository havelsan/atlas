
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
    /// Avans İade
    /// </summary>
    public partial class AdvanceBackForm : TTForm
    {
    /// <summary>
    /// Avans İade İşlemi
    /// </summary>
        protected TTObjectClasses.AdvanceBack _AdvanceBack
        {
            get { return (TTObjectClasses.AdvanceBack)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel5;
        protected ITTTextBox RECEIPTTOTAL;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox REASONOFRETURN;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox ADVANCETOTAL;
        protected ITTTextBox SERVICETOTAL;
        protected ITTTextBox TOTALPRICE;
        protected ITTTextBox ADVANCEBACKTOTAL;
        protected ITTTextBox RECEIPTBACKTOTAL;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelCashierLogId;
        protected ITTLabel labelTotalPrice;
        protected ITTGrid GRIDAdvanceDetail;
        protected ITTDateTimePickerColumn DATE;
        protected ITTTextBoxColumn NO;
        protected ITTComboBoxColumn CREDITCARDRECEIPTNO;
        protected ITTTextBoxColumn TOTALPRICEG;
        protected ITTTextBoxColumn STATUS;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelOfficerName;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel11;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("68a293ae-4b8c-4f00-aefe-da9ac03e8456"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("d9d44939-10d4-4e52-bbff-1fbd6e052c72"));
            RECEIPTTOTAL = (ITTTextBox)AddControl(new Guid("ca13a7f8-5774-472c-81c9-2452b1eb76ce"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("7dafd143-8839-4c13-9a86-32c0a718c43b"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("9014abd2-4186-4f21-af58-427f776971c9"));
            REASONOFRETURN = (ITTTextBox)AddControl(new Guid("7e231357-7cfa-4123-bdf9-662cd8944e01"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("b8766eae-8c28-4ac7-8608-8249b02e521e"));
            ADVANCETOTAL = (ITTTextBox)AddControl(new Guid("8f4dd82a-262e-4872-b516-8545bd1ec759"));
            SERVICETOTAL = (ITTTextBox)AddControl(new Guid("4acdbaa8-4033-42c2-ae23-b97578d647d8"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("53f80ad1-4feb-403f-82a6-dc0cdb5cdac2"));
            ADVANCEBACKTOTAL = (ITTTextBox)AddControl(new Guid("ef9aa2c7-35a7-4a53-b1ed-f4ba7a15d321"));
            RECEIPTBACKTOTAL = (ITTTextBox)AddControl(new Guid("3c5e3afd-3f42-415d-90d5-0e9030b8a3ec"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("95ce6ad3-2aab-4d84-a70d-28a67feb2266"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("e89c68cb-ac3a-4b6a-8677-2ebc88287cdc"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("195cb503-e95a-492f-a040-55b7f93e8eab"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("3f29b522-4664-4d31-b8f5-6b5382f414b6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("b59d5918-f240-417b-b328-7340d5d28db4"));
            labelCashierLogId = (ITTLabel)AddControl(new Guid("5f06fe3b-5016-45ff-ab03-7a50dbfe8f56"));
            labelTotalPrice = (ITTLabel)AddControl(new Guid("d9deed12-874f-4d5f-a9a7-8f3cbe18d464"));
            GRIDAdvanceDetail = (ITTGrid)AddControl(new Guid("8942bb47-b790-46b0-b641-bc1be3e06a9e"));
            DATE = (ITTDateTimePickerColumn)AddControl(new Guid("fb580188-a4e2-43b7-9da9-8cd45d55db83"));
            NO = (ITTTextBoxColumn)AddControl(new Guid("c1ebb25d-56fb-4106-8fe4-03b29c9b8cfb"));
            CREDITCARDRECEIPTNO = (ITTComboBoxColumn)AddControl(new Guid("e1c034ff-df3a-401e-96f6-987ae4118e52"));
            TOTALPRICEG = (ITTTextBoxColumn)AddControl(new Guid("9f69395f-f98c-4bc7-add5-4bc346a3d4f6"));
            STATUS = (ITTTextBoxColumn)AddControl(new Guid("77c70bdc-3d46-4761-baa7-86a701370895"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a0b5d639-2b2d-4b52-b070-ca6f879f0a8e"));
            labelOfficerName = (ITTLabel)AddControl(new Guid("ea076cac-2f64-48db-bd25-e5a2a5fc81f7"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("81b1c0f6-b292-4a51-86f2-f3780681fbc5"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a1780787-0b86-490d-a29a-f9ef1c3579b5"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("b8c0a4e7-3848-4510-8bf7-c10961dbf3e6"));
            base.InitializeControls();
        }

        public AdvanceBackForm() : base("ADVANCEBACK", "AdvanceBackForm")
        {
        }

        protected AdvanceBackForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}