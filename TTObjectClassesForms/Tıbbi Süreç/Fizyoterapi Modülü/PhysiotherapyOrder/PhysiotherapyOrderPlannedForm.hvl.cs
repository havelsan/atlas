
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
    public partial class PhysiotherapyOrderPlannedForm : TTForm
    {
    /// <summary>
    /// F.T.R. Emrinin Veridiği Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder
        {
            get { return (TTObjectClasses.PhysiotherapyOrder)_ttObject; }
        }

        protected ITTCheckBox IsPaidTreatment;
        protected ITTLabel labelPackageProcedure;
        protected ITTObjectListBox PackageProcedure;
        protected ITTCheckBox IsAdditionalTreatment;
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
            IsPaidTreatment = (ITTCheckBox)AddControl(new Guid("61cc31ed-6ec6-494f-9f92-90a3256fe8aa"));
            labelPackageProcedure = (ITTLabel)AddControl(new Guid("e60d0846-4704-495a-85ff-397facd0d6a7"));
            PackageProcedure = (ITTObjectListBox)AddControl(new Guid("27554b7a-83a3-46d2-a279-031fca518a27"));
            IsAdditionalTreatment = (ITTCheckBox)AddControl(new Guid("db136a2c-9b3e-4016-8ba3-943a067f7779"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("4a3a8188-9c9a-411d-8a33-b57316b97ad0"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("8647b806-1f09-473f-809f-d02d393808cf"));
            DoseDurationInfo = (ITTTextBox)AddControl(new Guid("8112160f-768a-41cb-a6ed-9fcfe0b34338"));
            Dose = (ITTTextBox)AddControl(new Guid("fe995906-da51-4d68-93bc-c8106f0ae664"));
            StartSession = (ITTTextBox)AddControl(new Guid("4f1f9617-36c8-46da-aa6c-54706f768522"));
            SeansGunSayisi = (ITTTextBox)AddControl(new Guid("4792380a-f30d-40d2-8add-c233ae7759d9"));
            FinishSession = (ITTTextBox)AddControl(new Guid("c96a55ff-65a0-47ce-9331-35989f211bbd"));
            Duration = (ITTTextBox)AddControl(new Guid("ff83a571-cdd6-4306-b8a7-0eccf077e012"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("4bca78c7-6670-4b2f-bf55-a49c1739ee45"));
            labelDoseDurationInfo = (ITTLabel)AddControl(new Guid("307b73b9-c8f7-46ed-b1f2-59f6860c574a"));
            labelPhysiotherapyStartDate = (ITTLabel)AddControl(new Guid("0806e4d0-f637-4ec8-b024-0de258d6fcba"));
            PhysiotherapyStartDate = (ITTDateTimePicker)AddControl(new Guid("03adb270-73da-4ae5-af9f-ad75593debee"));
            labelDose = (ITTLabel)AddControl(new Guid("e074079d-a62d-4552-99e7-235ee728c6d5"));
            labelStartSession = (ITTLabel)AddControl(new Guid("f14e1d57-7e8d-4511-a564-c719f03d2587"));
            labelSeansGunSayisi = (ITTLabel)AddControl(new Guid("494ea167-6dbb-4465-b952-7f6d30f7e31e"));
            IncludeFriday = (ITTCheckBox)AddControl(new Guid("b4783207-f7a7-4727-bd10-cbd05e788e80"));
            IncludeThursday = (ITTCheckBox)AddControl(new Guid("af4fc19e-c24f-470e-a3e8-24004520dc47"));
            IncludeWednesday = (ITTCheckBox)AddControl(new Guid("5fa960f6-864c-43a3-87f3-7eaa15f5e59a"));
            IncludeMonday = (ITTCheckBox)AddControl(new Guid("acb747a6-0d68-480a-bdfc-b06f1c638e11"));
            IncludeTuesday = (ITTCheckBox)AddControl(new Guid("9324fc15-20f7-4aea-994f-15c9ff807606"));
            IncludeSunday = (ITTCheckBox)AddControl(new Guid("9a25fd27-1fe4-4c9a-b90a-f92bc59f12b8"));
            IncludeSaturday = (ITTCheckBox)AddControl(new Guid("3ad4b45c-bfcf-4c66-8978-c7fde3da6f9e"));
            labelFinishSession = (ITTLabel)AddControl(new Guid("ae4196ab-f06f-4e2b-887d-372f9335ed1f"));
            labelDuration = (ITTLabel)AddControl(new Guid("9588ab66-44f3-4991-868d-cf47ceef305c"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("2b963ad4-6209-4c03-bb93-3ae48b751a7b"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("690dc0de-a776-4f70-a220-6fc25e262ce7"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("9d5c01cd-c560-4c2c-99b0-dee3ce306685"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("eec576d0-9365-4c2b-9442-34a0b2f5207c"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("782fc88a-5efc-44a3-bec9-42fda3bc2fe2"));
            labelFTRApplicationAreaDef = (ITTLabel)AddControl(new Guid("89e80ca7-8640-4275-9fbb-86cb65b685d9"));
            FTRApplicationAreaDef = (ITTObjectListBox)AddControl(new Guid("e080eb31-e112-45d7-9780-daea6ff04a30"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("536c1d16-2d8e-4fe1-968a-e8de2dd4e29c"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("7c30d67b-ceab-4e76-ab28-9b98d8f7713c"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("845d765b-9e03-4cd2-9a7e-e85d24ff62d0"));
            labelReportNoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("9171c11e-3d09-48e9-8669-895f037b6773"));
            labelDiagnosisGroupPhysiotherapyReports = (ITTLabel)AddControl(new Guid("f9244f0f-90b0-443e-b9d2-19fb17a4e5fa"));
            TreatmentTypePhysiotherapyReports = (ITTEnumComboBox)AddControl(new Guid("1e3c8852-5982-4623-9545-4712b854eabe"));
            labelTreatmentTypePhysiotherapyReports = (ITTLabel)AddControl(new Guid("ba1d970f-1e8a-47d4-ab5c-0cc6557b7704"));
            FTRApplicationAreaDefPhysiotherapyReports = (ITTObjectListBox)AddControl(new Guid("bbeba129-636b-47b8-8371-d5b480dc211a"));
            TreatmentProcessTypePhysiotherapyReports = (ITTTextBox)AddControl(new Guid("425e6c87-1e81-4a9e-9293-b590ed832f69"));
            labelFTRApplicationAreaDefPhysiotherapyReports = (ITTLabel)AddControl(new Guid("b60a2f2f-5614-49e7-8360-c503127f5309"));
            PackageProcedureInfoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("a06b96fe-2d42-46dc-ac01-f64b8b821c78"));
            labelReportInfoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("a63d4ec9-3008-4847-8975-67d3a6db139a"));
            ReportTimePhysiotherapyReports = (ITTTextBox)AddControl(new Guid("11c77643-8193-4e4e-9145-4f4298e00936"));
            ReportEndDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("994d6241-2388-44d4-8574-7552329f7c3c"));
            ReportNoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("e8298b9b-5bfb-43f3-acc9-f5a7662ae9a2"));
            labelReportEndDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("a1300f6d-4a9d-483c-bea9-dae37e91060b"));
            ReportInfoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("fe6ebf6b-a965-4997-a14e-09438f836b98"));
            ReportStartDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("63a1d351-4684-435d-9de2-e06e12e5b965"));
            DiagnosisGroupPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("b7b195d6-6dcd-4ab3-b94f-c092e40faea4"));
            labelReportStartDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("fe741a6c-80b1-43bd-ad00-32f811ffc4fd"));
            labelReportTimePhysiotherapyReports = (ITTLabel)AddControl(new Guid("e8a6a195-d984-4d9b-8ee1-ba6b8aa67fdf"));
            ReportDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("81b41ede-8633-4890-b1b7-f4d336b1eaf5"));
            labelReportDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("adb4aa63-5e2e-4b4b-99e2-20fbf4fa012b"));
            ReportType = (ITTCheckBox)AddControl(new Guid("4be437c1-58e9-4ddc-a446-d0184cbf981b"));
            labelPackageProcedureInfoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("f63a6258-bcb3-4684-a450-c9611b518493"));
            labelTreatmentProcessTypePhysiotherapyReports = (ITTLabel)AddControl(new Guid("056b1bbd-92a1-4138-938b-9fdacde6ad35"));
            base.InitializeControls();
        }

        public PhysiotherapyOrderPlannedForm() : base("PHYSIOTHERAPYORDER", "PhysiotherapyOrderPlannedForm")
        {
        }

        protected PhysiotherapyOrderPlannedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}