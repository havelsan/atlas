
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
    /// Hizmet İşleri Kabul Tutanağı
    /// </summary>
    public partial class ProcedureWorksAcceptNoticeForm : TTForm
    {
    /// <summary>
    /// Hizmet İşleri Kabul Tutanağı
    /// </summary>
        protected TTObjectClasses.ProcedureWorksAcceptNotice _ProcedureWorksAcceptNotice
        {
            get { return (TTObjectClasses.ProcedureWorksAcceptNotice)_ttObject; }
        }

        protected ITTTextBox txtActionID;
        protected ITTTextBox txtProjectNo;
        protected ITTTextBox txtConfirmNo;
        protected ITTLabel ttlabel12;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid ContractsGrid;
        protected ITTTextBoxColumn ContractNo;
        protected ITTListBoxColumn Supplier;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel7;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox TTListBox;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker ttdatetimepicker4;
        protected ITTLabel ttlabel10;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel8;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel5;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox6;
        protected ITTLabel ttlabel11;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel9;
        protected ITTButton cmdFind;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            txtActionID = (ITTTextBox)AddControl(new Guid("b53bcdef-46c8-47e1-9ccd-93dc43a4256b"));
            txtProjectNo = (ITTTextBox)AddControl(new Guid("09c06da9-24b0-4fa7-82db-343b59170188"));
            txtConfirmNo = (ITTTextBox)AddControl(new Guid("ff388a14-dceb-48ca-94f8-5a405695a096"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("cb092a10-c5a0-45e8-84f9-b08f36008179"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("ef5b9c36-daf3-4626-8b15-7d0a260a31ef"));
            ContractsGrid = (ITTGrid)AddControl(new Guid("1728a2f0-caa6-461f-afa4-e46e08abecef"));
            ContractNo = (ITTTextBoxColumn)AddControl(new Guid("ac870e36-5ab9-44a2-ba93-fa942c897aaf"));
            Supplier = (ITTListBoxColumn)AddControl(new Guid("efbff3bf-349c-41cc-b017-10bf3acc5ceb"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("71a8c93b-6476-48f1-bade-96a68d95af55"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("375da2c2-c673-4320-926c-988924d2ad2b"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("3f6c2b3e-58d4-49d6-8809-35be5be12c67"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("91bc8465-b10c-48ef-9ddd-217972198ab6"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("79637f1b-4600-448c-a86e-6c0cc43140d7"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f3b117b2-96f8-4dea-8fab-92ea0448c0b6"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("de0c49af-c03b-4108-a99f-9ac0ff85d93d"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("816a5fc4-9edb-436c-aa8b-82cd02d81fa8"));
            ttdatetimepicker4 = (ITTDateTimePicker)AddControl(new Guid("b84e1d89-d732-4d61-8c4a-dc54f63fe844"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("21ab0bee-f46f-4438-8617-5b0447feb113"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("011d6275-70cc-4c7f-badb-68ac47cda8aa"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("b2c3c334-8bdb-4c67-86ea-1a2c799bc0c2"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("292104c8-1708-45fa-bd2a-a39d3742c237"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("dbbef5d2-420d-41ef-ba7a-58be3f35ed07"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("4f647a42-ae34-4274-8f0e-ae9593bf77f2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("40d8ca8a-584e-46e7-add6-20e5103e9d2b"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("de471235-181c-41be-b14b-80707179aa9f"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("94070d8d-1f29-4d94-8c2b-2b32f4490366"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("8fc558b4-165b-4f0c-b8aa-f6f6ab0ebf1b"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("3a2065db-0ec3-4508-95dd-d8af30d60bff"));
            cmdFind = (ITTButton)AddControl(new Guid("ba14bf83-95d5-4250-8cf6-b1819b3b75f7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bb9399d2-7084-4fa4-afb0-45100aca015d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("395f5f72-be4a-4340-be32-e0ab70205ff0"));
            base.InitializeControls();
        }

        public ProcedureWorksAcceptNoticeForm() : base("PROCEDUREWORKSACCEPTNOTICE", "ProcedureWorksAcceptNoticeForm")
        {
        }

        protected ProcedureWorksAcceptNoticeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}