
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
    public partial class SlipEntryForm : TTForm
    {
    /// <summary>
    /// Fiş
    /// </summary>
        protected TTObjectClasses.MhSSlip _MhSSlip
        {
            get { return (TTObjectClasses.MhSSlip)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTObjectListBox Period;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel6;
        protected ITTTextBox WhyCreated;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel5;
        protected ITTTextBox Comment;
        protected ITTLabel labelPeriod;
        protected ITTLabel labelJournalDate;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelWhyCreated;
        protected ITTDateTimePicker JournalDate;
        protected ITTLabel labelComment;
        protected ITTTextBox SlipNo;
        protected ITTLabel labelSlipNo;
        protected ITTGrid JournalEntries;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelJournalNo;
        protected ITTTextBox JournalNo;
        protected ITTLabel ttlabel7;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("3c98f81f-0343-4a18-adbc-1785bcaae9a8"));
            Period = (ITTObjectListBox)AddControl(new Guid("673c45c3-cf3d-4e94-acc0-f4ad3077abb9"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("da34594b-234d-45c1-863a-e831ec9163c9"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("0465a82d-75cf-4c28-88aa-9bfde0067d2b"));
            WhyCreated = (ITTTextBox)AddControl(new Guid("9f8d123d-d493-4336-8406-ae4f27f4ccdd"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("86041d89-1935-4876-a8fc-7b3fde12af83"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("aa03350e-0e73-4336-bb0c-7dc675499070"));
            Comment = (ITTTextBox)AddControl(new Guid("afe4e687-eb47-4eca-a03b-8e2eaf974f8a"));
            labelPeriod = (ITTLabel)AddControl(new Guid("8cf0c120-9184-4af3-b7a0-9c1391b9730a"));
            labelJournalDate = (ITTLabel)AddControl(new Guid("50b891cb-1f4b-4a76-a645-f5f31ec0a88f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5c813a3d-d96a-4291-ba62-86c5092e6876"));
            labelWhyCreated = (ITTLabel)AddControl(new Guid("a39b4d60-8771-4483-8c5e-984a1d89cd81"));
            JournalDate = (ITTDateTimePicker)AddControl(new Guid("2fca5d98-0b59-420c-8826-868f75237ac0"));
            labelComment = (ITTLabel)AddControl(new Guid("3fbaeff8-a1c1-46ff-8ea1-7038f937d15c"));
            SlipNo = (ITTTextBox)AddControl(new Guid("83076a89-80cc-4fde-add6-6a639e537e93"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("4ed2d882-716f-4316-a795-434140f66941"));
            JournalEntries = (ITTGrid)AddControl(new Guid("32750ded-a04d-4b5c-9c67-4a6b22e248cc"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("80ed7dab-e686-46f2-a5bc-6003fe446d2a"));
            labelJournalNo = (ITTLabel)AddControl(new Guid("c4d550fa-062e-4abf-9439-5ffdbf4a9295"));
            JournalNo = (ITTTextBox)AddControl(new Guid("1552ba43-01ef-4d65-9195-89fbefd0125c"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("43fb9226-4685-4df5-9665-ef39a3e14f58"));
            base.InitializeControls();
        }

        public SlipEntryForm() : base("MHSSLIP", "SlipEntryForm")
        {
        }

        protected SlipEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}