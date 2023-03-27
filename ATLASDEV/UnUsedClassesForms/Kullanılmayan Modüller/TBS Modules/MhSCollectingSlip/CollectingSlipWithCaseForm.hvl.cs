
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
    public partial class CollectingSlipWithCaseForm : TTForm
    {
    /// <summary>
    /// Tahsil Fişi Girişi
    /// </summary>
        protected TTObjectClasses.MhSCollectingSlip _MhSCollectingSlip
        {
            get { return (TTObjectClasses.MhSCollectingSlip)_ttObject; }
        }

        protected ITTTextBox Comment;
        protected ITTLabel labelDebit;
        protected ITTLabel labelCredit;
        protected ITTObjectListBox Period;
        protected ITTLabel ttlabel3;
        protected ITTTextBox CashTakenNo;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox JournalNo;
        protected ITTLabel Balance;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelComment;
        protected ITTDateTimePicker JournalDate;
        protected ITTLabel labelWhyCreated;
        protected ITTLabel labelBalance;
        protected ITTGrid JournalEntries;
        protected ITTTextBox WhyCreated;
        protected ITTListDefComboBox SelectedCase;
        protected ITTLabel labelSlipNo;
        protected ITTLabel Debit;
        protected ITTLabel labelJournalDate;
        protected ITTLabel labelJournalNo;
        protected ITTLabel labelPeriod;
        protected ITTLabel ttlabel1;
        protected ITTTextBox SlipNo;
        protected ITTLabel ttlabel4;
        protected ITTLabel Credit;
        protected ITTLabel Related;
        protected ITTTextBox CreditTakenNo;
        override protected void InitializeControls()
        {
            Comment = (ITTTextBox)AddControl(new Guid("7fbeb62c-0102-4807-add1-025ec82dbfa0"));
            labelDebit = (ITTLabel)AddControl(new Guid("867f652c-1d3d-4c4e-b2c2-f8b522bd6d71"));
            labelCredit = (ITTLabel)AddControl(new Guid("c481b5c5-a71c-405c-a138-eb058a9e5d96"));
            Period = (ITTObjectListBox)AddControl(new Guid("1dd8f632-6bb1-4c5d-8f8e-d8f0e63a400c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a646bbe7-e687-4c9e-9320-d0ed6f5bfeba"));
            CashTakenNo = (ITTTextBox)AddControl(new Guid("fad31dd2-321b-4283-a10e-b748b21a55a3"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("57577c8a-47ad-43c6-a93c-d51f8ef0a6a0"));
            JournalNo = (ITTTextBox)AddControl(new Guid("977db47b-120c-48bd-b952-b4ed6fb96f6e"));
            Balance = (ITTLabel)AddControl(new Guid("0eb96390-0b5b-4840-811a-c3213818b55f"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("2d001cec-2410-4674-96ce-88eff66f3ece"));
            labelComment = (ITTLabel)AddControl(new Guid("e8a5826b-ab00-48de-9f0a-a1ea588728c7"));
            JournalDate = (ITTDateTimePicker)AddControl(new Guid("9eb468d3-145a-4153-92b2-9e3b8f35e50a"));
            labelWhyCreated = (ITTLabel)AddControl(new Guid("a36144c0-013c-435c-8691-8663597d04e5"));
            labelBalance = (ITTLabel)AddControl(new Guid("7f79e551-b315-4114-a622-8a8709c6f611"));
            JournalEntries = (ITTGrid)AddControl(new Guid("52942e9a-fc0d-4dd4-9b35-80d9cc16b1c9"));
            WhyCreated = (ITTTextBox)AddControl(new Guid("90082ffc-8fd9-48b5-a792-8ad41929da31"));
            SelectedCase = (ITTListDefComboBox)AddControl(new Guid("5a8577cb-1d3f-4d2f-99b5-8fd4eb0b7287"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("81e51a8a-7bd3-4d86-9683-919fbc50c669"));
            Debit = (ITTLabel)AddControl(new Guid("2361ba81-edb8-432a-b56f-696a05814fa7"));
            labelJournalDate = (ITTLabel)AddControl(new Guid("eea04f16-6bc8-468d-b9ef-6c6c8aa65475"));
            labelJournalNo = (ITTLabel)AddControl(new Guid("0307d9ca-7ead-4289-a52c-4bb9a94e12eb"));
            labelPeriod = (ITTLabel)AddControl(new Guid("15fd89d3-b2ef-48f4-bc7c-4c6653cac068"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("38d67863-cfd9-4233-a385-3c986d8e18c8"));
            SlipNo = (ITTTextBox)AddControl(new Guid("7bb15393-6cc9-47b3-b648-0491699d1e0d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e0c6626e-0f8f-44ed-94b3-01811ed6a0b1"));
            Credit = (ITTLabel)AddControl(new Guid("1bef1341-d338-48fc-8a41-011e895807e8"));
            Related = (ITTLabel)AddControl(new Guid("828db0ca-3f88-4d8c-906e-e53af96dce9b"));
            CreditTakenNo = (ITTTextBox)AddControl(new Guid("346bf938-3cf6-4211-980c-dd30639f1949"));
            base.InitializeControls();
        }

        public CollectingSlipWithCaseForm() : base("MHSCOLLECTINGSLIP", "CollectingSlipWithCaseForm")
        {
        }

        protected CollectingSlipWithCaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}