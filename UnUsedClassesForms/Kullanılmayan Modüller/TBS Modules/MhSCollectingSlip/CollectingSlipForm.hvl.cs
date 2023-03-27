
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
    /// Tahsil Fişi
    /// </summary>
    public partial class CollectingSlip : TTForm
    {
    /// <summary>
    /// Tahsil Fişi Girişi
    /// </summary>
        protected TTObjectClasses.MhSCollectingSlip _MhSCollectingSlip
        {
            get { return (TTObjectClasses.MhSCollectingSlip)_ttObject; }
        }

        protected ITTObjectListBox Period;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelPeriod;
        protected ITTTextBox Comment;
        protected ITTTextBox CreditTakenNo;
        protected ITTTextBox WhyCreated;
        protected ITTGrid JournalEntries;
        protected ITTTextBox CashTakenNo;
        protected ITTLabel labelComment;
        protected ITTDateTimePicker JournalDate;
        protected ITTTextBox JournalNo;
        protected ITTTextBox SlipNo;
        protected ITTLabel labelCredit;
        protected ITTListDefComboBox SelectedCase;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelJournalDate;
        protected ITTLabel Balance;
        protected ITTLabel labelWhyCreated;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelJournalNo;
        protected ITTLabel labelDebit;
        protected ITTLabel labelSlipNo;
        protected ITTLabel Credit;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelBalance;
        protected ITTLabel Debit;
        protected ITTLabel ttlabel3;
        protected ITTLabel Related;
        override protected void InitializeControls()
        {
            Period = (ITTObjectListBox)AddControl(new Guid("9d373054-38e7-4d01-89f9-039e6f41fee4"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("bd4ac4cd-7af5-45de-8cd1-e6b250a42a1d"));
            labelPeriod = (ITTLabel)AddControl(new Guid("06098519-c482-425b-8f0a-fa903b5c9c88"));
            Comment = (ITTTextBox)AddControl(new Guid("068fbd70-deb8-44e1-9b43-d0a06ed42e68"));
            CreditTakenNo = (ITTTextBox)AddControl(new Guid("ef532880-1f10-45ba-8908-c80f91d15c90"));
            WhyCreated = (ITTTextBox)AddControl(new Guid("b58be9b7-739d-4cc8-8b3f-b0d2d6abaae5"));
            JournalEntries = (ITTGrid)AddControl(new Guid("dd450ab9-4fa9-41ce-befd-c84ab0e0ac18"));
            CashTakenNo = (ITTTextBox)AddControl(new Guid("7b5a296e-bf36-42f0-9647-a82c4c414a02"));
            labelComment = (ITTLabel)AddControl(new Guid("32738b5d-012f-4165-8a3b-99311b9cd09e"));
            JournalDate = (ITTDateTimePicker)AddControl(new Guid("571b25e6-eaab-4b14-8f7d-b0d3c8ce4d03"));
            JournalNo = (ITTTextBox)AddControl(new Guid("3fbba15a-cfa8-42cb-b156-771ac9f3febe"));
            SlipNo = (ITTTextBox)AddControl(new Guid("ba6e9469-c264-4c6c-951c-a5f2c8c48a08"));
            labelCredit = (ITTLabel)AddControl(new Guid("10c56a94-d500-48fc-b71d-9d0b16f53187"));
            SelectedCase = (ITTListDefComboBox)AddControl(new Guid("2b81f980-7775-4ec6-ad32-a26796211fb9"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("b35e816b-646b-472a-b02c-8b78ecdb8fba"));
            labelJournalDate = (ITTLabel)AddControl(new Guid("4250c76a-a428-499e-ad6c-6ec9305e788d"));
            Balance = (ITTLabel)AddControl(new Guid("0e0ca2db-89a3-417f-9cfa-7f0dac8afbc7"));
            labelWhyCreated = (ITTLabel)AddControl(new Guid("c47e3ce8-1a00-465a-93f8-5569d1f1acaf"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("b1c1e619-53f3-4ece-9538-61d9bcc8d004"));
            labelJournalNo = (ITTLabel)AddControl(new Guid("4e95511c-e78d-44c4-b949-4757565e111c"));
            labelDebit = (ITTLabel)AddControl(new Guid("371cbbb5-e63f-4520-985a-365c58dad6d2"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("98bf9b58-3d99-4086-b47a-609ecdf2cbdb"));
            Credit = (ITTLabel)AddControl(new Guid("47608677-5553-448f-9beb-496f88cb049c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c594657e-d192-4509-aa25-0ab62a461d25"));
            labelBalance = (ITTLabel)AddControl(new Guid("9136f08b-87b0-4d8e-91fc-11e1f76f8745"));
            Debit = (ITTLabel)AddControl(new Guid("eab50165-1f9a-4d25-bc2a-0164af3d07e7"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("4cc2ff5c-34fd-4906-b8b6-dfda64a93dd9"));
            Related = (ITTLabel)AddControl(new Guid("e965811a-a337-4f3a-9a25-ddcaf0b4ac71"));
            base.InitializeControls();
        }

        public CollectingSlip() : base("MHSCOLLECTINGSLIP", "CollectingSlip")
        {
        }

        protected CollectingSlip(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}