
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
    public partial class SpendingSlipForm : TTForm
    {
    /// <summary>
    /// Tediye Fişi Girişi
    /// </summary>
        protected TTObjectClasses.MhSSpendingSlip _MhSSpendingSlip
        {
            get { return (TTObjectClasses.MhSSpendingSlip)_ttObject; }
        }

        protected ITTLabel Debit;
        protected ITTLabel ttlabel11;
        protected ITTGrid JournalEntries;
        protected ITTListDefComboBox SelectedCase;
        protected ITTLabel labelPeriod;
        protected ITTLabel ttlabel2;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox Period;
        protected ITTLabel labelJournalNo;
        protected ITTDateTimePicker JournalDate;
        protected ITTLabel ttlabel1;
        protected ITTTextBox JournalNo;
        protected ITTTextBox WhyCreated;
        protected ITTLabel Balance;
        protected ITTLabel labelJournalDate;
        protected ITTTextBox SendOrderNo;
        protected ITTTextBox ChequeNo;
        protected ITTLabel labelSlipNo;
        protected ITTLabel labelBalance;
        protected ITTLabel labelCredit;
        protected ITTTextBox Comment;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelDebit;
        protected ITTLabel labelSendOrderNo;
        protected ITTTextBox Related;
        protected ITTLabel labelComment;
        protected ITTLabel Credit;
        protected ITTLabel labelWhyCreated;
        protected ITTTextBox SlipNo;
        override protected void InitializeControls()
        {
            Debit = (ITTLabel)AddControl(new Guid("b5395f87-44db-4153-a990-06246aa7ad6c"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("e22f3274-85e8-4c6c-8656-e3b851af86c5"));
            JournalEntries = (ITTGrid)AddControl(new Guid("57c1396c-76f3-4cae-b6ec-dcd9380e1a91"));
            SelectedCase = (ITTListDefComboBox)AddControl(new Guid("1f9589be-288d-4fdc-9c09-f127f37107b0"));
            labelPeriod = (ITTLabel)AddControl(new Guid("d2ad62fd-7d49-4f81-92d5-d9275ccaef57"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("28a69d12-a639-4045-9360-b75a8375d8e8"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("446ca4bb-6986-46f3-b823-ca78d27aad12"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("05a1d477-a500-415e-b3d1-bea8a335e98c"));
            Period = (ITTObjectListBox)AddControl(new Guid("5706f712-07b8-4172-bfb9-b1ad90c7cabb"));
            labelJournalNo = (ITTLabel)AddControl(new Guid("887eea4d-ddea-4efa-8c75-c63040b27926"));
            JournalDate = (ITTDateTimePicker)AddControl(new Guid("2f7e9e0d-34c1-46f0-8abf-b66a9d03de33"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("029f939c-2bef-4f1f-85c3-a166d6011b4e"));
            JournalNo = (ITTTextBox)AddControl(new Guid("b60dd915-56af-4f23-88e8-77e33a4c0c83"));
            WhyCreated = (ITTTextBox)AddControl(new Guid("6fddc1d0-d55e-460e-b7bf-6a8f65717bae"));
            Balance = (ITTLabel)AddControl(new Guid("1c799f65-bf25-4d83-9a33-765cf493c737"));
            labelJournalDate = (ITTLabel)AddControl(new Guid("2a314027-9a29-4736-99e6-94897b94d4f2"));
            SendOrderNo = (ITTTextBox)AddControl(new Guid("f09bbec2-10e4-44f4-8632-7744d2202235"));
            ChequeNo = (ITTTextBox)AddControl(new Guid("ee0ecb8b-7d4f-43ae-bdc8-97db2293cb06"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("e3cd81f6-9c34-4a53-9bf1-8e0a68b71881"));
            labelBalance = (ITTLabel)AddControl(new Guid("66735d6d-e8c4-496d-9ca4-6d7a50d9caa7"));
            labelCredit = (ITTLabel)AddControl(new Guid("5996afad-e621-4b46-94fd-5a8de9178038"));
            Comment = (ITTTextBox)AddControl(new Guid("96ca5622-74c2-4f28-8b6f-5ae24241eeef"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("44ffd332-d3dd-4a06-b625-3631630c0244"));
            labelDebit = (ITTLabel)AddControl(new Guid("bfc8d8f4-e81e-4294-9d94-4df61f088bb1"));
            labelSendOrderNo = (ITTLabel)AddControl(new Guid("ec4aae0d-86aa-4ab6-adf7-3d1e7fd9e0bd"));
            Related = (ITTTextBox)AddControl(new Guid("d5fe2ba7-59a8-42a1-bdc1-1041258a7286"));
            labelComment = (ITTLabel)AddControl(new Guid("6aa26510-772f-44f4-8abc-1145a660863d"));
            Credit = (ITTLabel)AddControl(new Guid("84361ec7-b17e-490b-bdbf-136686fd5196"));
            labelWhyCreated = (ITTLabel)AddControl(new Guid("f387612d-5fe2-483e-a10f-ee738327c40c"));
            SlipNo = (ITTTextBox)AddControl(new Guid("c3bd6a4f-ad31-48b9-bfbf-fc416fc79852"));
            base.InitializeControls();
        }

        public SpendingSlipForm() : base("MHSSPENDINGSLIP", "SpendingSlipForm")
        {
        }

        protected SpendingSlipForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}