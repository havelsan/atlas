
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
    /// New Form
    /// </summary>
    public partial class OpeningSlipForm : TTForm
    {
    /// <summary>
    /// Açılış Fişi Girişi
    /// </summary>
        protected TTObjectClasses.MhSOpeningSlipOperations _MhSOpeningSlipOperations
        {
            get { return (TTObjectClasses.MhSOpeningSlipOperations)_ttObject; }
        }

        protected ITTLabel ttlabel6;
        protected ITTTextBox WhyCreated;
        protected ITTLabel labelPeriod;
        protected ITTLabel labelJournalNo;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelComment;
        protected ITTTextBox SlipNo;
        protected ITTLabel ttlabel7;
        protected ITTTextBox JournalNo;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelWhyCreated;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTLabel labelSlipNo;
        protected ITTDateTimePicker JournalDate;
        protected ITTLabel ttlabel10;
        protected ITTTextBox Comment;
        protected ITTLabel labelJournalDate;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel5;
        protected ITTGrid JournalEntries;
        override protected void InitializeControls()
        {
            ttlabel6 = (ITTLabel)AddControl(new Guid("00d32ee4-6ff4-46f6-9d07-06d636780ba3"));
            WhyCreated = (ITTTextBox)AddControl(new Guid("260eb58b-1f44-4da9-9a59-cfb228ef501b"));
            labelPeriod = (ITTLabel)AddControl(new Guid("68341b58-a153-4f46-a580-d4f1cd500691"));
            labelJournalNo = (ITTLabel)AddControl(new Guid("53fccb57-1834-4c32-acbb-a0064f6f0e96"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("0bfabdf5-191f-4bb8-8e99-98a62a7877eb"));
            labelComment = (ITTLabel)AddControl(new Guid("946804b7-7ee9-4335-89a5-911625e57b8c"));
            SlipNo = (ITTTextBox)AddControl(new Guid("e2a46ceb-430d-45be-b5dc-9c324f4e8466"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("4f2c7ec3-4f11-40fb-b07a-6d255c9fb1d7"));
            JournalNo = (ITTTextBox)AddControl(new Guid("57a0da88-5617-4ffe-9f1b-5ef091f25221"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("bfa2e3a5-2920-4fc9-944f-61ce75287ca0"));
            labelWhyCreated = (ITTLabel)AddControl(new Guid("f79835f8-7933-4769-9b50-4a6c062e2612"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("0acca380-9e67-4923-9368-55374396c977"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("41b4edd1-68c0-4dde-b24c-53ef1bcdd1a0"));
            JournalDate = (ITTDateTimePicker)AddControl(new Guid("33999aa4-6669-41b7-a853-3ee1f3a84e4f"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("7c7289bd-a650-4a80-93be-3aca9da38e26"));
            Comment = (ITTTextBox)AddControl(new Guid("14f4f77c-1c46-4fb9-82cd-5ebb064fc966"));
            labelJournalDate = (ITTLabel)AddControl(new Guid("a5826360-4600-4bc3-9870-406b43e048b0"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("80665de5-c9da-4487-9628-13d9a0ac338f"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("3b169440-0ea3-4ee3-8776-dbb6c8b094d9"));
            JournalEntries = (ITTGrid)AddControl(new Guid("4cbb6a31-c904-4a5f-a193-e1b4a0f522f1"));
            base.InitializeControls();
        }

        public OpeningSlipForm() : base("MHSOPENINGSLIPOPERATIONS", "OpeningSlipForm")
        {
        }

        protected OpeningSlipForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}