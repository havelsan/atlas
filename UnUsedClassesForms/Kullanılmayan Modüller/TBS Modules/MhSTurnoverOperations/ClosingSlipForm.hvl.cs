
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
    /// Kapanış Fişi
    /// </summary>
    public partial class ClosingSlipForm : TTForm
    {
    /// <summary>
    /// Devir İşlemleri
    /// </summary>
        protected TTObjectClasses.MhSTurnoverOperations _MhSTurnoverOperations
        {
            get { return (TTObjectClasses.MhSTurnoverOperations)_ttObject; }
        }

        protected ITTLabel labelJournalDate;
        protected ITTLabel ttlabel7;
        protected ITTTextBox SlipNo;
        protected ITTLabel ttlabel5;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelComment;
        protected ITTLabel labelPeriod;
        protected ITTDateTimePicker JournalDate;
        protected ITTLabel labelSlipNo;
        protected ITTLabel ttlabel9;
        protected ITTTextBox Comment;
        protected ITTObjectListBox Period;
        protected ITTTextBox JournalNo;
        protected ITTLabel ttlabel10;
        protected ITTGrid JournalEntries;
        protected ITTLabel labelJournalNo;
        override protected void InitializeControls()
        {
            labelJournalDate = (ITTLabel)AddControl(new Guid("f7a97362-0070-40ce-a63f-1bd2be957137"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("d64037f3-b845-43e7-a610-cf3b531a451e"));
            SlipNo = (ITTTextBox)AddControl(new Guid("91762580-ba4e-4daa-8fa1-c93e990f852b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a5d482d2-3e60-434c-b3de-be662dcb8621"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f93d9572-f363-400c-97c8-9ca9f24fd1ec"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("77dcce60-8c22-4037-a305-94659f186e72"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4b9cca06-d244-4f15-be02-7caf31e3aa92"));
            labelComment = (ITTLabel)AddControl(new Guid("5730f150-5226-4bcc-8085-491c22fc741b"));
            labelPeriod = (ITTLabel)AddControl(new Guid("5ccef4c6-402f-41ed-af26-477190d2ab22"));
            JournalDate = (ITTDateTimePicker)AddControl(new Guid("415a6ac8-8c9d-4314-adfb-3952fb4bb944"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("3038a24c-45e8-402c-8769-25f959ede223"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("adcc361e-8bce-4739-b926-188085e34c47"));
            Comment = (ITTTextBox)AddControl(new Guid("94058401-bd5e-46d3-9264-0fef251dfa0c"));
            Period = (ITTObjectListBox)AddControl(new Guid("bd68a784-a0e9-445c-acfc-10a9f277e6e2"));
            JournalNo = (ITTTextBox)AddControl(new Guid("14e3bd8f-328d-40c2-aec1-1e5e21b4bf5e"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("40cd9168-5158-42c1-8445-0a8cde502a9b"));
            JournalEntries = (ITTGrid)AddControl(new Guid("e73f36fc-4607-4198-9d9c-f3e670c74926"));
            labelJournalNo = (ITTLabel)AddControl(new Guid("9f34cc37-334d-4d16-9da2-eaf4ed8b5b03"));
            base.InitializeControls();
        }

        public ClosingSlipForm() : base("MHSTURNOVEROPERATIONS", "ClosingSlipForm")
        {
        }

        protected ClosingSlipForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}