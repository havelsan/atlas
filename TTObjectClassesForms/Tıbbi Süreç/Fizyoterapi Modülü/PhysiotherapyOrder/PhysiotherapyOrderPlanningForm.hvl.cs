
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
    public partial class PhysiotherapyOrderPlanningForm : TTForm
    {
    /// <summary>
    /// F.T.R. Emrinin Veridiği Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder
        {
            get { return (TTObjectClasses.PhysiotherapyOrder)_ttObject; }
        }

        protected ITTLabel labelTreatmentRoom;
        protected ITTObjectListBox TreatmentRoom;
        protected ITTCheckBox IsPaidTreatment;
        protected ITTLabel labelPackageProcedure;
        protected ITTObjectListBox PackageProcedure;
        protected ITTLabel labelTreatmentProperties;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox DoseDurationInfo;
        protected ITTTextBox Dose;
        protected ITTTextBox StartSession;
        protected ITTTextBox SeansGunSayisi;
        protected ITTTextBox FinishSession;
        protected ITTTextBox Duration;
        protected ITTTextBox ApplicationArea;
        protected ITTLabel labelDoseDurationInfo;
        protected ITTLabel labelPhysiotherapyStartDate;
        protected ITTDateTimePicker PhysiotherapyStartDate;
        protected ITTLabel labelDose;
        protected ITTLabel labelStartSession;
        protected ITTLabel labelSeansGunSayisi;
        protected ITTCheckBox IncludeFriday;
        protected ITTCheckBox IncludeThursday;
        protected ITTCheckBox IncludeWednesday;
        protected ITTCheckBox IncludeMonday;
        protected ITTCheckBox IncludeTuesday;
        protected ITTCheckBox IncludeSunday;
        protected ITTCheckBox IncludeSaturday;
        protected ITTLabel labelFinishSession;
        protected ITTLabel labelDuration;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureObject;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelFTRApplicationAreaDef;
        protected ITTObjectListBox FTRApplicationAreaDef;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTPanel ttpanel1;
        protected ITTLabel labelReportNoPhysiotherapyReports;
        protected ITTLabel labelDiagnosisGroupPhysiotherapyReports;
        protected ITTEnumComboBox TreatmentTypePhysiotherapyReports;
        protected ITTLabel labelTreatmentTypePhysiotherapyReports;
        protected ITTObjectListBox FTRApplicationAreaDefPhysiotherapyReports;
        protected ITTTextBox TreatmentProcessTypePhysiotherapyReports;
        protected ITTLabel labelFTRApplicationAreaDefPhysiotherapyReports;
        protected ITTTextBox PackageProcedureInfoPhysiotherapyReports;
        protected ITTLabel labelReportInfoPhysiotherapyReports;
        protected ITTTextBox ReportTimePhysiotherapyReports;
        protected ITTDateTimePicker ReportEndDatePhysiotherapyReports;
        protected ITTTextBox ReportNoPhysiotherapyReports;
        protected ITTLabel labelReportEndDatePhysiotherapyReports;
        protected ITTTextBox ReportInfoPhysiotherapyReports;
        protected ITTDateTimePicker ReportStartDatePhysiotherapyReports;
        protected ITTTextBox DiagnosisGroupPhysiotherapyReports;
        protected ITTLabel labelReportStartDatePhysiotherapyReports;
        protected ITTLabel labelReportTimePhysiotherapyReports;
        protected ITTDateTimePicker ReportDatePhysiotherapyReports;
        protected ITTLabel labelReportDatePhysiotherapyReports;
        protected ITTCheckBox ReportType;
        protected ITTLabel labelPackageProcedureInfoPhysiotherapyReports;
        protected ITTLabel labelTreatmentProcessTypePhysiotherapyReports;
        override protected void InitializeControls()
        {
            labelTreatmentRoom = (ITTLabel)AddControl(new Guid("49d54da6-bc63-4f2d-a001-df3841457661"));
            TreatmentRoom = (ITTObjectListBox)AddControl(new Guid("2c6c78b0-ecd4-4cc0-b8cb-1fd56a928513"));
            IsPaidTreatment = (ITTCheckBox)AddControl(new Guid("7e99d3ab-f440-480e-8d8b-d40e6405ee9b"));
            labelPackageProcedure = (ITTLabel)AddControl(new Guid("80c7fe96-0514-47ac-99d4-9caa2d30e0a7"));
            PackageProcedure = (ITTObjectListBox)AddControl(new Guid("3ad00cc6-1f1f-4106-8013-c1228bf50c2f"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("d4b78ebd-a9ec-4614-9ac4-f1137a3a4e92"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("3bace407-3434-4e91-bf6f-ac2432872983"));
            DoseDurationInfo = (ITTTextBox)AddControl(new Guid("bb2c7b4f-8b9e-49d9-9ccb-2136a7a08864"));
            Dose = (ITTTextBox)AddControl(new Guid("33b60df8-3be2-4a92-b37f-303eb867e79f"));
            StartSession = (ITTTextBox)AddControl(new Guid("74f3f0b3-df56-46db-ab1c-6dcb4f25d525"));
            SeansGunSayisi = (ITTTextBox)AddControl(new Guid("b5f113cc-eff4-4e94-a60d-5944951c1d38"));
            FinishSession = (ITTTextBox)AddControl(new Guid("1f75d1f1-2bfa-479f-89e0-04d5c34eafe3"));
            Duration = (ITTTextBox)AddControl(new Guid("1824d3ed-4047-4c91-9df9-09fc99d5a1a1"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("029ce81b-bde7-4fc2-b987-d16f4cb1eb6d"));
            labelDoseDurationInfo = (ITTLabel)AddControl(new Guid("6feb3d1d-9b29-4de9-ad34-562da1ed1b44"));
            labelPhysiotherapyStartDate = (ITTLabel)AddControl(new Guid("4514e132-2f79-40a5-86d9-5e8ee38f289a"));
            PhysiotherapyStartDate = (ITTDateTimePicker)AddControl(new Guid("00618c68-c0e4-43f9-aa3f-9c134f482acc"));
            labelDose = (ITTLabel)AddControl(new Guid("36536019-79eb-4e74-aa0a-9e17d2411fe0"));
            labelStartSession = (ITTLabel)AddControl(new Guid("e3c6cd0b-79e2-4fcf-8bf4-0e2059f2cf2a"));
            labelSeansGunSayisi = (ITTLabel)AddControl(new Guid("64db8d33-72e7-4d2a-af46-468fd3465742"));
            IncludeFriday = (ITTCheckBox)AddControl(new Guid("40cb82f8-b293-42fa-a84b-a959f3a634f8"));
            IncludeThursday = (ITTCheckBox)AddControl(new Guid("4b0af685-eba0-4b79-8869-0a34dad5ee7e"));
            IncludeWednesday = (ITTCheckBox)AddControl(new Guid("2214f26e-dd05-4ef6-9d15-d8147cb4e61d"));
            IncludeMonday = (ITTCheckBox)AddControl(new Guid("476966ea-6fbc-4149-a7c7-45afab09a603"));
            IncludeTuesday = (ITTCheckBox)AddControl(new Guid("050d6cc5-eeec-43d6-85ef-d232255f1cc3"));
            IncludeSunday = (ITTCheckBox)AddControl(new Guid("90c0e0ac-5ab6-4de1-a6e2-891d30e8dbd8"));
            IncludeSaturday = (ITTCheckBox)AddControl(new Guid("68938c0c-47d5-4c62-93a9-5166c1dcf2ad"));
            labelFinishSession = (ITTLabel)AddControl(new Guid("facb8ecb-70e0-47ed-9539-87f03e12ed69"));
            labelDuration = (ITTLabel)AddControl(new Guid("ef5c3edd-ebc4-4858-b241-81476ff46f3b"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("242ccd90-4a99-45bb-8fa4-2cf652db6937"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("5690ba4e-f9d4-4c49-9371-581170406c9a"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("db5f9ce2-ba36-4eb9-b597-40c450345f35"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("99d0f9c2-c010-46e6-991c-71bd522f9dc6"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("1b41d1be-fbe8-494e-b5c4-96d296cd3d6f"));
            labelFTRApplicationAreaDef = (ITTLabel)AddControl(new Guid("d669ebec-1af9-4c06-999b-5a3846dc5f78"));
            FTRApplicationAreaDef = (ITTObjectListBox)AddControl(new Guid("4028a802-cf2f-4816-ba3d-bebe197b88f4"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("0ffec601-09b5-464a-ad87-fd67b634b327"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("265c64c3-86d8-478d-bebb-cafdc15044f8"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("6e983e6b-096d-44e1-bb33-4ff3f893dfea"));
            labelReportNoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("bbf607dd-6284-44d2-aded-98e2c2885f39"));
            labelDiagnosisGroupPhysiotherapyReports = (ITTLabel)AddControl(new Guid("3fc7b0c2-3bda-400c-aa80-3560150076e2"));
            TreatmentTypePhysiotherapyReports = (ITTEnumComboBox)AddControl(new Guid("df7998d4-7637-4fc5-8537-f34e897acdf1"));
            labelTreatmentTypePhysiotherapyReports = (ITTLabel)AddControl(new Guid("2644b37b-993d-4ad2-924c-3fcc55988253"));
            FTRApplicationAreaDefPhysiotherapyReports = (ITTObjectListBox)AddControl(new Guid("86310e21-ec55-4c65-850a-17f68dc788d4"));
            TreatmentProcessTypePhysiotherapyReports = (ITTTextBox)AddControl(new Guid("8c8e402c-7ba4-4046-973b-9c4651cbf7ac"));
            labelFTRApplicationAreaDefPhysiotherapyReports = (ITTLabel)AddControl(new Guid("16dbf97b-0340-468f-a7dd-226f06c2cc57"));
            PackageProcedureInfoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("a3928acc-3547-4ea0-b1b0-61c811b2e075"));
            labelReportInfoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("2e83f512-8357-4e0c-8d2b-b3e16f518234"));
            ReportTimePhysiotherapyReports = (ITTTextBox)AddControl(new Guid("6aef5fd2-915b-4ae6-bd4c-681fbc7114fd"));
            ReportEndDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("c36b9a86-63d8-46b3-86a1-4065d97f9362"));
            ReportNoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("76f0f854-637f-4f95-a8fe-97e4a5b38ab1"));
            labelReportEndDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("3696a28c-6486-40be-b471-354bdb1a3a0f"));
            ReportInfoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("d34bd514-df36-4417-b3b2-23d5dacf43e1"));
            ReportStartDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("a651840b-01fb-4bb6-9f33-c77a5c72de14"));
            DiagnosisGroupPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("9c4eb3cc-0f91-4897-8114-404c7c4188aa"));
            labelReportStartDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("8899c84a-4da3-48c0-af3c-2907673c4cd3"));
            labelReportTimePhysiotherapyReports = (ITTLabel)AddControl(new Guid("5ba6a511-1fd5-41ef-ad36-05777f85ab07"));
            ReportDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("caa387ef-53d6-4a44-bd3e-5500f628fca9"));
            labelReportDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("934e59b5-d27d-492c-b1d8-c1b1a817a217"));
            ReportType = (ITTCheckBox)AddControl(new Guid("90c74f58-5e81-4b9f-8f65-aefef40bdf10"));
            labelPackageProcedureInfoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("963b473a-6d6e-4c4a-b4a0-7cbb5f41f83f"));
            labelTreatmentProcessTypePhysiotherapyReports = (ITTLabel)AddControl(new Guid("0c2a1692-d793-48ba-b975-ac0c11e02a27"));
            base.InitializeControls();
        }

        public PhysiotherapyOrderPlanningForm() : base("PHYSIOTHERAPYORDER", "PhysiotherapyOrderPlanningForm")
        {
        }

        protected PhysiotherapyOrderPlanningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}