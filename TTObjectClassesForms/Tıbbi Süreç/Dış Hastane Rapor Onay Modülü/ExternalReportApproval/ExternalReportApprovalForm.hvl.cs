
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
    public partial class ExternalReportApprovalForm : EpisodeActionForm
    {
    /// <summary>
    /// Dış XXXXXX Rapor Onay
    /// </summary>
        protected TTObjectClasses.ExternalReportApproval _ExternalReportApproval
        {
            get { return (TTObjectClasses.ExternalReportApproval)_ttObject; }
        }

        protected ITTRichTextBoxControl Decision;
        protected ITTLabel labelReportType;
        protected ITTObjectListBox ReportType;
        protected ITTLabel labelApprovalDoctor;
        protected ITTObjectListBox ApprovalDoctor;
        protected ITTLabel labelReportNo;
        protected ITTTextBox ReportNo;
        protected ITTTextBox HospitalOfReport;
        protected ITTTextBox DoctorOfReport;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelReportApprovalDate;
        protected ITTDateTimePicker ReportApprovalDate;
        protected ITTLabel labelHospitalOfReport;
        protected ITTLabel labelDoctorOfReport;
        override protected void InitializeControls()
        {
            Decision = (ITTRichTextBoxControl)AddControl(new Guid("0e8da037-349c-4cbf-9ba9-80960538fcc9"));
            labelReportType = (ITTLabel)AddControl(new Guid("a0f7b072-2aee-4e5e-9bc2-68ac6dc37ea7"));
            ReportType = (ITTObjectListBox)AddControl(new Guid("4c68a434-aa7a-4565-9b62-a496837396c8"));
            labelApprovalDoctor = (ITTLabel)AddControl(new Guid("29377e13-c7ed-4676-b79b-31777ef5594c"));
            ApprovalDoctor = (ITTObjectListBox)AddControl(new Guid("fd4b18b3-54e7-4f39-aaa7-b004bd234420"));
            labelReportNo = (ITTLabel)AddControl(new Guid("bf103529-2532-47ea-83c6-35a8ab178daf"));
            ReportNo = (ITTTextBox)AddControl(new Guid("4d8f3f05-9bcd-4a26-bad3-4736da1ee93b"));
            HospitalOfReport = (ITTTextBox)AddControl(new Guid("ede6effe-2e04-4042-b878-6c399f738dd7"));
            DoctorOfReport = (ITTTextBox)AddControl(new Guid("8a8dc386-49db-45eb-b670-432daf28e5b6"));
            labelReportDate = (ITTLabel)AddControl(new Guid("2ffd1fba-7875-437d-86e6-7ea524be3765"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("8e21c3ab-439b-4af6-8a97-38ffedec6ff2"));
            labelReportApprovalDate = (ITTLabel)AddControl(new Guid("bb17fe80-be08-4cfd-9270-f22d85cad2ac"));
            ReportApprovalDate = (ITTDateTimePicker)AddControl(new Guid("b418e4e6-57f7-447a-b250-f641198f1f4b"));
            labelHospitalOfReport = (ITTLabel)AddControl(new Guid("cba4dd19-13d9-47a9-878f-21027a7ef0e8"));
            labelDoctorOfReport = (ITTLabel)AddControl(new Guid("21669d86-42b3-486b-b6b5-af419162b1d3"));
            base.InitializeControls();
        }

        public ExternalReportApprovalForm() : base("EXTERNALREPORTAPPROVAL", "ExternalReportApprovalForm")
        {
        }

        protected ExternalReportApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}