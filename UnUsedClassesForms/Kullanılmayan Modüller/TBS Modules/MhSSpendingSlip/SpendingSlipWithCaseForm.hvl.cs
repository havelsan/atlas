
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
    /// Ödeme Fişi
    /// </summary>
    public partial class SpendingSlipWithCaseForm : TTForm
    {
    /// <summary>
    /// Tediye Fişi Girişi
    /// </summary>
        protected TTObjectClasses.MhSSpendingSlip _MhSSpendingSlip
        {
            get { return (TTObjectClasses.MhSSpendingSlip)_ttObject; }
        }

        protected ITTLabel labelSendOrderNo;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox Related;
        protected ITTTextBox JournalNo;
        protected ITTListDefComboBox SelectedCase;
        protected ITTLabel labelWhyCreated;
        protected ITTTextBox ChequeNo;
        protected ITTTextBox SendOrderNo;
        protected ITTLabel Debit;
        protected ITTLabel Balance;
        protected ITTLabel labelBalance;
        protected ITTLabel labelDebit;
        protected ITTTextBox SlipNo;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelCredit;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelPeriod;
        protected ITTTextBox Comment;
        protected ITTLabel labelSlipNo;
        protected ITTGrid JournalEntries;
        protected ITTTextBox WhyCreated;
        protected ITTLabel labelComment;
        protected ITTObjectListBox Period;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelJournalDate;
        protected ITTDateTimePicker JournalDate;
        protected ITTLabel labelJournalNo;
        protected ITTLabel Credit;
        override protected void InitializeControls()
        {
            labelSendOrderNo = (ITTLabel)AddControl(new Guid("5124fd5b-ff7d-4594-af86-0018ce329446"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("3842d2a9-5091-45b2-bbcb-fe2b1ad21ca1"));
            Related = (ITTTextBox)AddControl(new Guid("d43c51eb-6f5d-4ca0-9077-c7f3395f9131"));
            JournalNo = (ITTTextBox)AddControl(new Guid("d794aa73-385d-40ad-886b-cdc9b5f83812"));
            SelectedCase = (ITTListDefComboBox)AddControl(new Guid("988d5886-ac34-4958-8e78-d503430fbc51"));
            labelWhyCreated = (ITTLabel)AddControl(new Guid("378e30f8-7604-47c9-b70d-d44d3be143b1"));
            ChequeNo = (ITTTextBox)AddControl(new Guid("6fa27779-2968-49d3-b6d0-e7281a0195bc"));
            SendOrderNo = (ITTTextBox)AddControl(new Guid("b3592eb8-b184-47d6-8be2-b5abccc6f4f3"));
            Debit = (ITTLabel)AddControl(new Guid("65d19fc7-f928-478b-a4dc-9d8bb5167d02"));
            Balance = (ITTLabel)AddControl(new Guid("9a564cc2-4485-4e69-ba6f-657693802a22"));
            labelBalance = (ITTLabel)AddControl(new Guid("552c49e9-5061-4198-8c40-a55c326dac8c"));
            labelDebit = (ITTLabel)AddControl(new Guid("0eaa818b-a17e-4ece-9867-7aa390f3a9a6"));
            SlipNo = (ITTTextBox)AddControl(new Guid("f4327a96-2701-4c6c-b084-8d1d63b9a3be"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a045cb5b-f54f-4a73-9ab4-71476be00ff2"));
            labelCredit = (ITTLabel)AddControl(new Guid("dc441358-a3ba-425b-91d3-59b0844cefe4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3c35567e-18ec-4363-9d64-73b550f56d90"));
            labelPeriod = (ITTLabel)AddControl(new Guid("e8c29617-a685-4955-a337-431c0306ced1"));
            Comment = (ITTTextBox)AddControl(new Guid("aced5f5f-d63a-44c6-9704-5e08a7a6c947"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("e4980dd0-c65f-45fb-9cb7-39ed7e2a77c6"));
            JournalEntries = (ITTGrid)AddControl(new Guid("777f4950-10cc-4061-bacf-5107a1a5fd17"));
            WhyCreated = (ITTTextBox)AddControl(new Guid("77ca1490-437a-4479-8950-22c6d5666a53"));
            labelComment = (ITTLabel)AddControl(new Guid("75e6982a-814e-4f7e-88e2-2bdbb515d87c"));
            Period = (ITTObjectListBox)AddControl(new Guid("c7809c63-28bf-47bd-a94f-3ad99f316cdb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("15e85931-a6ea-431f-818e-34dd20f3ec59"));
            labelJournalDate = (ITTLabel)AddControl(new Guid("66f74735-6d03-402d-85e1-2f1cbb1d260d"));
            JournalDate = (ITTDateTimePicker)AddControl(new Guid("e7372e81-9b9d-4c2e-ba50-30cbc21242b4"));
            labelJournalNo = (ITTLabel)AddControl(new Guid("d2bad452-6fd4-44c3-8e72-f3a399e38235"));
            Credit = (ITTLabel)AddControl(new Guid("8d0b6940-7903-46ae-915d-e2519ad49e9f"));
            base.InitializeControls();
        }

        public SpendingSlipWithCaseForm() : base("MHSSPENDINGSLIP", "SpendingSlipWithCaseForm")
        {
        }

        protected SpendingSlipWithCaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}