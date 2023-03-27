
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
    /// Fiş Arama
    /// </summary>
    public partial class SlipSearchForm : TTForm
    {
    /// <summary>
    /// Fiş
    /// </summary>
        protected TTObjectClasses.MhSSlip _MhSSlip
        {
            get { return (TTObjectClasses.MhSSlip)_ttObject; }
        }

        protected ITTTextBox SlipNo;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTTextBox tttextbox6;
        protected ITTLabel ttlabel12;
        protected ITTTextBox Comment;
        protected ITTGrid ttgrid1;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTTextBox tttextbox7;
        protected ITTTextBox JournalNo;
        protected ITTTextBox WhyCreated;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTTextBox tttextbox8;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelJournalNo;
        protected ITTLabel ttlabel7;
        protected ITTButton ttbutton1;
        protected ITTListDefComboBox ttlistdefcombobox2;
        protected ITTLabel labelType;
        protected ITTLabel labelSlipNo;
        protected ITTLabel labelComment;
        protected ITTDateTimePicker JournalDate;
        protected ITTEnumComboBox ttenumcombobox2;
        protected ITTLabel labelWhyCreated;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelJournalDate;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel8;
        override protected void InitializeControls()
        {
            SlipNo = (ITTTextBox)AddControl(new Guid("b81514c9-7730-4cb3-81f4-0749ea1a6e5b"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("75cab162-d1e0-4ce6-88ea-d8f9ed9f461e"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("d4e7ce13-b703-440e-aec7-e94a5aeb6ef3"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("bfbb5418-db52-42cc-9d23-e1d82ca27f4c"));
            Comment = (ITTTextBox)AddControl(new Guid("45a840ee-94d7-4618-bccf-c22a69767d32"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("2eb54b42-ddb7-4616-b266-a38287652d70"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("86f77586-ad47-4063-b7bd-98b9c1965028"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("742a425a-52e0-4937-a068-bd5ba98d49c5"));
            JournalNo = (ITTTextBox)AddControl(new Guid("5985cc47-9861-47a6-bb82-89563fdf824e"));
            WhyCreated = (ITTTextBox)AddControl(new Guid("f49be41d-7418-46d4-887b-b613ea4d8230"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("2f1b570d-8f13-48c1-9f06-8141ab3263f1"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("43375cae-c5b3-47da-8c0f-78d17fc6a44d"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("ea51a0a2-2eba-454a-b478-5bcbb323e457"));
            labelJournalNo = (ITTLabel)AddControl(new Guid("a1a73d81-724c-44ac-a28a-6f4959d6790d"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("325f4962-b3a5-41f6-b621-50a28bd6fda2"));
            ttbutton1 = (ITTButton)AddControl(new Guid("e52f1b03-18cc-41bb-8dc2-676470861f16"));
            ttlistdefcombobox2 = (ITTListDefComboBox)AddControl(new Guid("3f85e3ac-b7d2-4c0d-9643-63c1f182a59e"));
            labelType = (ITTLabel)AddControl(new Guid("f156c801-c68e-418d-9362-757ca1bb9d47"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("a0f4b447-7f83-4c53-87f9-45b1250ecde3"));
            labelComment = (ITTLabel)AddControl(new Guid("7bd8cf8f-05f4-4387-811f-3a054cee504e"));
            JournalDate = (ITTDateTimePicker)AddControl(new Guid("aa331013-7995-4aa5-a71f-40127a7933e8"));
            ttenumcombobox2 = (ITTEnumComboBox)AddControl(new Guid("a5c984d4-7280-4de4-b5dc-487f2ecdb15c"));
            labelWhyCreated = (ITTLabel)AddControl(new Guid("922ee1e2-dad3-48ae-bbe8-38b91b97409d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e1891cc8-3f09-411e-be7d-241c694b0b9d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("b26ae84b-c7fc-472d-8857-130c5f90fe43"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("4a098901-b7f3-49c8-9a3d-1e97dffe4b64"));
            labelJournalDate = (ITTLabel)AddControl(new Guid("6fc0e270-f2cf-4e8f-92ba-084b5415f5a1"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("8a9385d3-e59c-4530-8c8d-010e4f47ce5d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("077d6c1d-b8d5-463f-8179-de66f46d2732"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("ef61ced6-455d-4457-8b60-f4242f42f48a"));
            base.InitializeControls();
        }

        public SlipSearchForm() : base("MHSSLIP", "SlipSearchForm")
        {
        }

        protected SlipSearchForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}