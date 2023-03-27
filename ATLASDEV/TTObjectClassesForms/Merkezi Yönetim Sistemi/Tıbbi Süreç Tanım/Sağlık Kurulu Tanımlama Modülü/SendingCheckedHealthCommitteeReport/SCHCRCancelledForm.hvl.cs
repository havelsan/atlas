
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
    public partial class SCHCRCancelledForm : TTForm
    {
    /// <summary>
    /// Kontrol Edilen Sağlık Kurulu Raporları Gönderme Modülü
    /// </summary>
        protected TTObjectClasses.SendingCheckedHealthCommitteeReport _SendingCheckedHealthCommitteeReport
        {
            get { return (TTObjectClasses.SendingCheckedHealthCommitteeReport)_ttObject; }
        }

        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelResult;
        protected ITTLabel labelSendBackNo;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker EndDate;
        protected ITTObjectListBox Result;
        protected ITTLabel labelSendBackDate;
        protected ITTTextBox SendBackNo;
        protected ITTLabel labelEndDate;
        protected ITTObjectListBox ChairToBeSend;
        protected ITTLabel labelChairToBeSend;
        protected ITTLabel labelSendBackNote;
        protected ITTDateTimePicker SendBackDate;
        protected ITTDateTimePicker HealthCommitteeStartDate;
        protected ITTGrid Reports;
        protected ITTListBoxColumn ConfirmationUnitDefinition;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn ReportNo;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTTextBoxColumn ConsignmentNo;
        protected ITTDateTimePickerColumn StartDate;
        protected ITTTextBox SendBackNote;
        override protected void InitializeControls()
        {
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("622051a5-705f-45f7-ab01-6c29adeb9d0f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e9815559-3cae-431a-bf61-b564e44766bf"));
            labelResult = (ITTLabel)AddControl(new Guid("4497f1a5-0696-4fd1-8a5d-ccc934a514ea"));
            labelSendBackNo = (ITTLabel)AddControl(new Guid("af109882-2afd-4716-8e91-5cc0ff1aa5fb"));
            labelStartDate = (ITTLabel)AddControl(new Guid("67829e7c-12f8-400f-884e-e446784185d7"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("f24ac6c9-d20d-4725-b8e8-732f59d1ec35"));
            Result = (ITTObjectListBox)AddControl(new Guid("e14ffd97-2732-44e9-a330-edd0f71ed8cf"));
            labelSendBackDate = (ITTLabel)AddControl(new Guid("56cb4b52-2e21-4d64-8e4b-c0071b79a631"));
            SendBackNo = (ITTTextBox)AddControl(new Guid("094507a8-5432-4135-88ff-d5d0a45c5144"));
            labelEndDate = (ITTLabel)AddControl(new Guid("a588c351-0ed9-4653-bcb4-2777bdf88c18"));
            ChairToBeSend = (ITTObjectListBox)AddControl(new Guid("50f5a650-bad3-45f4-bb86-559f921afbaf"));
            labelChairToBeSend = (ITTLabel)AddControl(new Guid("5f51950e-7f67-4467-b1ec-b3e120276aaa"));
            labelSendBackNote = (ITTLabel)AddControl(new Guid("fbb9a1d6-5584-408f-b12b-d6de382f3d0d"));
            SendBackDate = (ITTDateTimePicker)AddControl(new Guid("569a9564-50c5-4482-8284-e85c1d32256a"));
            HealthCommitteeStartDate = (ITTDateTimePicker)AddControl(new Guid("3fe64af4-4557-4117-a3b9-881818f02f0b"));
            Reports = (ITTGrid)AddControl(new Guid("3fa194cf-1ff9-4f60-be29-69444e0ff1fe"));
            ConfirmationUnitDefinition = (ITTListBoxColumn)AddControl(new Guid("925e7e5c-d24e-4a52-8f7a-380f8913b42f"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("9dff99ea-fe15-4255-85bf-d6db93977327"));
            ReportNo = (ITTTextBoxColumn)AddControl(new Guid("66a7e279-f52b-48ec-aa7e-851a780446c8"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("6506f363-8f7a-4c13-bca6-386c66ffe6b7"));
            ConsignmentNo = (ITTTextBoxColumn)AddControl(new Guid("5ba04b9e-8471-440f-bd50-b201cb16d68d"));
            StartDate = (ITTDateTimePickerColumn)AddControl(new Guid("bb7b5eac-a484-4cc0-b6ac-220774e85a68"));
            SendBackNote = (ITTTextBox)AddControl(new Guid("299fcfdc-4816-4970-9989-f1ee059b4b78"));
            base.InitializeControls();
        }

        public SCHCRCancelledForm() : base("SENDINGCHECKEDHEALTHCOMMITTEEREPORT", "SCHCRCancelledForm")
        {
        }

        protected SCHCRCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}