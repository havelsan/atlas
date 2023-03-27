
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
    /// Sağlık Kurulu Muayene Edecek Birim(ler) / XXXXXX(ler) Tanımlama
    /// </summary>
    public partial class ReasonForExaminationDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sağlık Kurulu Muayene Edecek Birim(ler) / XXXXXX(ler) Tanımlama
    /// </summary>
        protected TTObjectClasses.ReasonForExaminationDefinition _ReasonForExaminationDefinition
        {
            get { return (TTObjectClasses.ReasonForExaminationDefinition)_ttObject; }
        }

        protected ITTCheckBox IntegratedReporting;
        protected ITTLabel ttlabel2;
        protected ITTGrid HCRequestReason;
        protected ITTTextBoxColumn ReasonNameHCRequestReason;
        protected ITTEnumComboBoxColumn HCEReportType;
        protected ITTGrid MembersHealthCommitteMemberGrid;
        protected ITTListBoxColumn DoctorHealthCommitteMemberGrid;
        protected ITTListBoxColumn UnitHealthCommitteMemberGrid;
        protected ITTLabel labelMemberOfHealthCommittee;
        protected ITTObjectListBox MemberOfHealthCommittee;
        protected ITTLabel labelControlUnitOfTime;
        protected ITTEnumComboBox ControlUnitOfTime;
        protected ITTLabel labelControlTime;
        protected ITTTextBox ControlTime;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Code;
        protected ITTLabel labelPackageProcedure;
        protected ITTObjectListBox PackageProcedure;
        protected ITTCheckBox IsPoliclinicAllowedReport;
        protected ITTCheckBox IsPrintReportBeforeExam;
        protected ITTCheckBox IsForcedDiagnosis;
        protected ITTGrid ExaminationDepartmentsHospitals;
        protected ITTListBoxColumn Speciality;
        protected ITTListBoxColumn Policklinic;
        protected ITTListBoxColumn Procedure;
        protected ITTListBoxColumn Template;
        protected ITTLabel lblSystems;
        protected ITTGrid SystemForDisabledReportGrid;
        protected ITTListBoxColumn System;
        protected ITTLabel labelHCReportTypeDefinition;
        protected ITTObjectListBox HCReportTypeDefinition;
        protected ITTLabel labelCode;
        protected ITTLabel labelReasonForExamination;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox ExaminationReasonType;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            IntegratedReporting = (ITTCheckBox)AddControl(new Guid("1a56d375-dc37-49c8-bec1-2967e10b33cb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4142ebc4-2655-4e32-948a-06ded58149d5"));
            HCRequestReason = (ITTGrid)AddControl(new Guid("c9d89472-59ee-4c7a-8ab5-9040771a3344"));
            ReasonNameHCRequestReason = (ITTTextBoxColumn)AddControl(new Guid("faf2ff2e-c2ab-4e61-83f3-2cfb6e97d9f4"));
            HCEReportType = (ITTEnumComboBoxColumn)AddControl(new Guid("795598eb-06f0-48ac-8c52-592e72282dc2"));
            MembersHealthCommitteMemberGrid = (ITTGrid)AddControl(new Guid("b07a8bd3-4378-4d24-ac48-588204e1814a"));
            DoctorHealthCommitteMemberGrid = (ITTListBoxColumn)AddControl(new Guid("fe7c8a0b-04c5-4c38-af0c-5269526d28fc"));
            UnitHealthCommitteMemberGrid = (ITTListBoxColumn)AddControl(new Guid("86355aec-8a92-4fd8-8c9b-1fd90d627aab"));
            labelMemberOfHealthCommittee = (ITTLabel)AddControl(new Guid("a4cebb34-7864-4229-9a83-0dee5992eb6c"));
            MemberOfHealthCommittee = (ITTObjectListBox)AddControl(new Guid("9534c2a3-590a-4b56-80a3-3c1bd47bdee4"));
            labelControlUnitOfTime = (ITTLabel)AddControl(new Guid("f42ce2c8-f0e8-4379-b7ae-6c343da5b0dc"));
            ControlUnitOfTime = (ITTEnumComboBox)AddControl(new Guid("6e86dc9d-1b7b-44a0-a6e0-ed79bdf06c6d"));
            labelControlTime = (ITTLabel)AddControl(new Guid("66cb5f38-7b40-4405-8959-d4ff229c6347"));
            ControlTime = (ITTTextBox)AddControl(new Guid("03e5e646-3605-4f98-b958-120d360f50ab"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("0fecadcc-9932-4a5d-b2f3-6e47159cae5a"));
            Code = (ITTTextBox)AddControl(new Guid("2551a8a2-5274-4163-ae08-64b77e4ccab7"));
            labelPackageProcedure = (ITTLabel)AddControl(new Guid("06caabdd-cdb0-4bb1-aea9-9628ea473e3b"));
            PackageProcedure = (ITTObjectListBox)AddControl(new Guid("210cbb9c-26d0-4a66-b1f8-624f6dc09d33"));
            IsPoliclinicAllowedReport = (ITTCheckBox)AddControl(new Guid("864aa893-99cd-40b5-af2e-d2703da41067"));
            IsPrintReportBeforeExam = (ITTCheckBox)AddControl(new Guid("45fe0f51-cdb2-40d9-8b08-0586e804aca7"));
            IsForcedDiagnosis = (ITTCheckBox)AddControl(new Guid("c1557438-4d43-48aa-ac4f-cb9f8b2fa2a1"));
            ExaminationDepartmentsHospitals = (ITTGrid)AddControl(new Guid("30b06cfd-bc4b-430c-a9c2-17c9c1e2dd44"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("13aa5437-d114-41cd-9322-8fc258f84ef5"));
            Policklinic = (ITTListBoxColumn)AddControl(new Guid("fe90692e-cba2-4ba0-8ea2-933887b3a71e"));
            Procedure = (ITTListBoxColumn)AddControl(new Guid("2a4b2f96-1d31-4ff7-a953-bf0d165b0d10"));
            Template = (ITTListBoxColumn)AddControl(new Guid("972649fe-996a-4e79-a56f-5aa0e975fd1a"));
            lblSystems = (ITTLabel)AddControl(new Guid("83c2d230-f098-4429-aff2-ab3138e1d174"));
            SystemForDisabledReportGrid = (ITTGrid)AddControl(new Guid("ea9ed00e-9792-456b-b913-fc03bf7aaf44"));
            System = (ITTListBoxColumn)AddControl(new Guid("a660b59e-2195-4265-be41-e9cc1e2bbc39"));
            labelHCReportTypeDefinition = (ITTLabel)AddControl(new Guid("8c164064-22d9-4c4c-9b6c-4565bec7a3cb"));
            HCReportTypeDefinition = (ITTObjectListBox)AddControl(new Guid("af7f2f22-e641-4711-b66a-114b5f687b92"));
            labelCode = (ITTLabel)AddControl(new Guid("86dda55d-e8ac-4122-8548-2e1e8d712b39"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("d44e6cc6-9bec-4972-91fa-63012008facf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e98014b0-17ba-4081-a0a2-671554fd2eb7"));
            ExaminationReasonType = (ITTEnumComboBox)AddControl(new Guid("60bacebd-5753-4d0b-aac5-fb714ce7f38d"));
            Active = (ITTCheckBox)AddControl(new Guid("eb348e33-3212-4875-9986-b28028163142"));
            base.InitializeControls();
        }

        public ReasonForExaminationDefinitionForm() : base("REASONFOREXAMINATIONDEFINITION", "ReasonForExaminationDefinitionForm")
        {
        }

        protected ReasonForExaminationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}