
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
    /// Mahsup Fişi Girişi
    /// </summary>
    public partial class MhSChargingSlipForm : TTForm
    {
    /// <summary>
    /// Mahsup Fişi Girişi
    /// </summary>
        protected TTObjectClasses.MhSChargingSlipOperations _MhSChargingSlipOperations
        {
            get { return (TTObjectClasses.MhSChargingSlipOperations)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelWhyCreated;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel Balance;
        protected ITTListDefComboBox ttlistdefcombobox2;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel5;
        protected ITTLabel Debit;
        protected ITTLabel ttlabel6;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelPeriod;
        protected ITTGrid JournalEntries;
        protected ITTTextBox JournalNo;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTTextBox WhyCreated;
        protected ITTLabel Credit;
        protected ITTLabel labelSlipNo;
        protected ITTLabel labelJournalDate;
        protected ITTTextBox Comment;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker JournalDate;
        protected ITTObjectListBox Period;
        protected ITTLabel labelComment;
        protected ITTTextBox SlipNo;
        protected ITTLabel labelJournalNo;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("4e2abcff-87a5-4857-a1b5-0c5d2a30e01e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("f98ce481-bdcd-4c19-b745-e217598926d4"));
            labelWhyCreated = (ITTLabel)AddControl(new Guid("8fad5a6d-16c2-44e7-8c99-f2d4f7b3e555"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("41674f50-1d3f-4a65-82bb-f847e789a9f5"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("a9950019-b693-47bf-8ba2-e05df98a88dd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("99f9f2aa-bcbb-4641-9fcc-ae4ec954cb52"));
            Balance = (ITTLabel)AddControl(new Guid("489bfef1-2570-4981-ac8e-c9e25100f946"));
            ttlistdefcombobox2 = (ITTListDefComboBox)AddControl(new Guid("436bbbf6-2447-4c05-b68d-af9ab3908cfa"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e6d3826b-a1bb-4672-9261-9aee6323e4c4"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a1f35922-b6b6-472e-8c73-91146112e517"));
            Debit = (ITTLabel)AddControl(new Guid("2d775580-be2d-4b22-a432-78b2ad4e275e"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("6d93cf6a-b741-461f-9b08-83e20355522b"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("950aa742-ae60-4d53-9dd6-83dd28dc34de"));
            labelPeriod = (ITTLabel)AddControl(new Guid("bc1c2d1f-f824-482b-aa86-57f099f63800"));
            JournalEntries = (ITTGrid)AddControl(new Guid("80c7b9ee-a4a2-4630-a896-6554c41e2a93"));
            JournalNo = (ITTTextBox)AddControl(new Guid("ed52c09e-d942-40de-8412-597da4362686"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("ffba2173-de5e-4f97-89ce-6b9e582b4017"));
            WhyCreated = (ITTTextBox)AddControl(new Guid("3c23251d-48fa-4aa0-8929-61e6623cbae2"));
            Credit = (ITTLabel)AddControl(new Guid("010a5d7c-82cf-45d6-aeb4-21c7694aa5b9"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("ce287f7e-5054-4eff-818f-50316c041e79"));
            labelJournalDate = (ITTLabel)AddControl(new Guid("c134d5c5-d0d3-45c3-971e-389d1732c6a9"));
            Comment = (ITTTextBox)AddControl(new Guid("0d5023b9-f1fe-4b7f-8a0a-2fe03b2b3287"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("9c1e12b5-6f9e-4f01-b2b8-1e10c604fbe2"));
            JournalDate = (ITTDateTimePicker)AddControl(new Guid("f0a8d458-db2e-4b05-9c89-139e31ebf828"));
            Period = (ITTObjectListBox)AddControl(new Guid("3a1caef9-c6fa-4685-9271-0f557ae0821a"));
            labelComment = (ITTLabel)AddControl(new Guid("0f9fa90a-7046-40fe-8e2d-170f66691809"));
            SlipNo = (ITTTextBox)AddControl(new Guid("2e6df671-c550-4988-8ab1-f636296079ba"));
            labelJournalNo = (ITTLabel)AddControl(new Guid("8816a5e7-6d93-4fb6-b85f-f7a7ac7a211d"));
            base.InitializeControls();
        }

        public MhSChargingSlipForm() : base("MHSCHARGINGSLIPOPERATIONS", "MhSChargingSlipForm")
        {
        }

        protected MhSChargingSlipForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}