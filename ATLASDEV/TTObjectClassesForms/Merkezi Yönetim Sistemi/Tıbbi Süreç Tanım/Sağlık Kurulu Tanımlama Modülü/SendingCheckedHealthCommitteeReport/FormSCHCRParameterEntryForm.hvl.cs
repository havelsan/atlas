
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
    public partial class FormSCHCRParameterEntry : TTForm
    {
    /// <summary>
    /// Kontrol Edilen Sağlık Kurulu Raporları Gönderme Modülü
    /// </summary>
        protected TTObjectClasses.SendingCheckedHealthCommitteeReport _SendingCheckedHealthCommitteeReport
        {
            get { return (TTObjectClasses.SendingCheckedHealthCommitteeReport)_ttObject; }
        }

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
            labelResult = (ITTLabel)AddControl(new Guid("b97bca73-c79a-444a-9bcc-0a17f87bcd09"));
            labelSendBackNo = (ITTLabel)AddControl(new Guid("b3058f4e-d33e-44f6-8f09-2287235834ea"));
            labelStartDate = (ITTLabel)AddControl(new Guid("280cdea3-4726-4572-9054-251a58f2a1d5"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("53d5324e-b672-4e95-8288-35c4924a0d61"));
            Result = (ITTObjectListBox)AddControl(new Guid("97d42bd9-9e7e-4d08-b031-3f2dbe63afc1"));
            labelSendBackDate = (ITTLabel)AddControl(new Guid("240888d4-4e03-498d-a169-77e5333abca8"));
            SendBackNo = (ITTTextBox)AddControl(new Guid("5e3287fb-f530-424b-9c99-8aaf21c8ab7c"));
            labelEndDate = (ITTLabel)AddControl(new Guid("c6c0952b-d80b-4331-9f0a-8e30d59ae8dc"));
            ChairToBeSend = (ITTObjectListBox)AddControl(new Guid("2e80dd38-268e-4ec2-a324-9884826be4fe"));
            labelChairToBeSend = (ITTLabel)AddControl(new Guid("8fd9a93d-83af-4cf8-a92a-a9d00b8bf69d"));
            labelSendBackNote = (ITTLabel)AddControl(new Guid("a04619b2-c23a-48a8-9199-c38a91ceea83"));
            SendBackDate = (ITTDateTimePicker)AddControl(new Guid("88f16159-9872-46f9-b97e-c55c118a2d61"));
            HealthCommitteeStartDate = (ITTDateTimePicker)AddControl(new Guid("16337f2b-56e2-467b-b45f-ce257e0f7c83"));
            Reports = (ITTGrid)AddControl(new Guid("12edd852-0c43-4c96-b4f8-d99be8a80084"));
            ConfirmationUnitDefinition = (ITTListBoxColumn)AddControl(new Guid("3ab9b305-556c-4edc-b356-2ec0040907a6"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("431423a1-f4ee-4e0d-9db0-e3583a269521"));
            ReportNo = (ITTTextBoxColumn)AddControl(new Guid("75201d7a-a918-4025-84c5-c10052b342f8"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("502429a3-12ad-41a8-8e3a-2360a6282a8f"));
            ConsignmentNo = (ITTTextBoxColumn)AddControl(new Guid("9a6da4e3-fa7b-4143-b875-bc0aaf880315"));
            StartDate = (ITTDateTimePickerColumn)AddControl(new Guid("efdfcf23-05b3-4730-a328-3c1c0b5aefad"));
            SendBackNote = (ITTTextBox)AddControl(new Guid("1bb2eb6f-bd32-433f-a511-d9b9a65e3d8f"));
            base.InitializeControls();
        }

        public FormSCHCRParameterEntry() : base("SENDINGCHECKEDHEALTHCOMMITTEEREPORT", "FormSCHCRParameterEntry")
        {
        }

        protected FormSCHCRParameterEntry(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}