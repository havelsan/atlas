
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
    /// Durum Bildirir Raporu
    /// </summary>
    public partial class StatusNotificationReportForm : TTForm
    {
    /// <summary>
    /// Durum Bildirir Raporu
    /// </summary>
        protected TTObjectClasses.StatusNotificationReport _StatusNotificationReport
        {
            get { return (TTObjectClasses.StatusNotificationReport)_ttObject; }
        }

        protected ITTCheckBox CommitteeReport;
        protected ITTLabel labelThirdDoctor;
        protected ITTObjectListBox ThirdDoctor;
        protected ITTLabel labelSecondDoctor;
        protected ITTObjectListBox SecondDoctor;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelReasonForExaminationHCRequestReason;
        protected ITTObjectListBox ReasonForExaminationHCRequestReason;
        protected ITTLabel labelHCRequestReason;
        protected ITTObjectListBox HCRequestReason;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelReportNo;
        protected ITTTextBox ReportNo;
        protected ITTTextBox Description;
        protected ITTLabel labelReportDecision;
        protected ITTRichTextBoxControl ReportDecision;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            CommitteeReport = (ITTCheckBox)AddControl(new Guid("184e7b24-5c83-4a08-89ca-55b392f5847f"));
            labelThirdDoctor = (ITTLabel)AddControl(new Guid("531c41e8-a0bf-4aa8-ad21-983c94924186"));
            ThirdDoctor = (ITTObjectListBox)AddControl(new Guid("1559016f-abc4-408a-891e-5681be569163"));
            labelSecondDoctor = (ITTLabel)AddControl(new Guid("36c48e1b-5b0d-48f7-b6b7-d9be11a1623a"));
            SecondDoctor = (ITTObjectListBox)AddControl(new Guid("b44ac779-d0fb-4a9a-aa7a-a97338bc2dc7"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("b7763a3c-015b-44cd-9911-871447ce1681"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("277eeca2-dc47-4dc4-9b44-7307a7baded0"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("ec34f343-9a97-4f6a-a282-fabf00cccd7c"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("4c3188bb-e483-4914-93fb-59ee14db4164"));
            labelReasonForExaminationHCRequestReason = (ITTLabel)AddControl(new Guid("1ee2712f-42f3-464d-953d-c4e2fe2cef73"));
            ReasonForExaminationHCRequestReason = (ITTObjectListBox)AddControl(new Guid("507fcba1-85ac-426b-87af-10ed05522e71"));
            labelHCRequestReason = (ITTLabel)AddControl(new Guid("c2e8c695-1e80-43ec-9b32-cfaa1fdeeefd"));
            HCRequestReason = (ITTObjectListBox)AddControl(new Guid("e30ad48f-4b94-4fa7-a946-c18afa6a7cc8"));
            labelActionDate = (ITTLabel)AddControl(new Guid("66aee986-96c8-4d17-a323-4a610225fbf6"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("1148e5f6-8f23-4844-bc5e-d80c926c7e76"));
            labelStartDate = (ITTLabel)AddControl(new Guid("5be76f5e-a0c7-47c7-8e4b-21f8bb4ca67d"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("54624632-fb41-4aaf-a3a9-755001045efd"));
            labelReportNo = (ITTLabel)AddControl(new Guid("5727b209-eead-4688-bb2f-c7ccacdcd2c2"));
            ReportNo = (ITTTextBox)AddControl(new Guid("45453d47-014c-45a9-afde-9a261135563b"));
            Description = (ITTTextBox)AddControl(new Guid("f016e897-d14f-4ef6-b5a1-f57b43147851"));
            labelReportDecision = (ITTLabel)AddControl(new Guid("f2f895ba-60aa-4ecf-8cb0-e05f98f7a82a"));
            ReportDecision = (ITTRichTextBoxControl)AddControl(new Guid("74d2f06f-1474-4148-abaa-42c9a2439873"));
            labelEndDate = (ITTLabel)AddControl(new Guid("1aa28e2e-115f-4776-a7d2-8a1996ac59b2"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("3eba89d2-a9e4-424b-8119-48fa1619a6ff"));
            labelDescription = (ITTLabel)AddControl(new Guid("ae15e3f0-8bc2-4088-84c4-66e3e01b6672"));
            base.InitializeControls();
        }

        public StatusNotificationReportForm() : base("STATUSNOTIFICATIONREPORT", "StatusNotificationReportForm")
        {
        }

        protected StatusNotificationReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}