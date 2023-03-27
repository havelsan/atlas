
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
    /// SPTS Rapor Giriş
    /// </summary>
    public partial class SPTSReportEntryForm : TTForm
    {
    /// <summary>
    /// SPTS Rapor Giriş 
    /// </summary>
        protected TTObjectClasses.SPTSReportEntryAction _SPTSReportEntryAction
        {
            get { return (TTObjectClasses.SPTSReportEntryAction)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTCheckBox SchemeOfCure;
        protected ITTCheckBox TValue;
        protected ITTCheckBox PathologyReport;
        protected ITTCheckBox OralNutrition;
        protected ITTCheckBox AgeAndSize;
        protected ITTGrid SpecialityForReports;
        protected ITTListBoxColumn Speciality;
        protected ITTGrid DiagnosisForReports;
        protected ITTListBoxColumn SPTSDiagnosisInfo;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelReportEndDate;
        protected ITTDateTimePicker ReportEndDate;
        protected ITTLabel labelReportStartDate;
        protected ITTDateTimePicker ReportStartDate;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelFoundationType;
        protected ITTEnumComboBox FoundationType;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel9;
        protected ITTGrid DrugOrderForReports;
        protected ITTListBoxColumn Drug;
        protected ITTTextBoxColumn BarcodeLevel;
        protected ITTTextBoxColumn Dosage;
        protected ITTTextBoxColumn DosageAmount;
        protected ITTTextBoxColumn WeeklyMonthly;
        protected ITTCheckBoxColumn HasReport;
        protected ITTCheckBoxColumn HasTenDays;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("d73bcb45-919a-47fe-9414-78795ecd67f7"));
            SchemeOfCure = (ITTCheckBox)AddControl(new Guid("f2d592c8-da79-4810-b583-219c67b83f11"));
            TValue = (ITTCheckBox)AddControl(new Guid("ce65cb2a-45a3-465a-add8-90243cb23fed"));
            PathologyReport = (ITTCheckBox)AddControl(new Guid("36eaa65a-3379-4e24-a300-6d4faa841c07"));
            OralNutrition = (ITTCheckBox)AddControl(new Guid("664ab09e-3953-4d39-b2ae-cca04842a2c8"));
            AgeAndSize = (ITTCheckBox)AddControl(new Guid("feac0a4e-ea85-4434-92f2-2363e8fedd0d"));
            SpecialityForReports = (ITTGrid)AddControl(new Guid("a8038c1c-b29f-40d4-8bfb-59888506e811"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("af061f84-2ec2-4673-8760-f8a07f879d79"));
            DiagnosisForReports = (ITTGrid)AddControl(new Guid("f00f8655-c095-49da-a698-6621413fb06f"));
            SPTSDiagnosisInfo = (ITTListBoxColumn)AddControl(new Guid("ba60b985-0844-43c9-ae1e-001ceed70020"));
            labelID = (ITTLabel)AddControl(new Guid("13537e28-4df0-4b6c-b774-5459707c3fcf"));
            ID = (ITTTextBox)AddControl(new Guid("3a03cbc7-add3-47b6-8bdf-100daed21816"));
            labelActionDate = (ITTLabel)AddControl(new Guid("6942ae01-449e-4446-81dd-6043028f7049"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("98810110-d477-4fd8-8656-f97f228cf475"));
            labelReportEndDate = (ITTLabel)AddControl(new Guid("9ac92cdb-1503-4768-8f3f-1af33ac855ee"));
            ReportEndDate = (ITTDateTimePicker)AddControl(new Guid("c021a7db-e0ad-4e11-93cb-bfcda234e6a4"));
            labelReportStartDate = (ITTLabel)AddControl(new Guid("2b1ed33e-d9b0-4a5a-89da-4e3264fb2428"));
            ReportStartDate = (ITTDateTimePicker)AddControl(new Guid("13ab99dd-6afe-43ed-be1e-0f799b19c035"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cada1212-a8d7-4891-b4db-de170c480123"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("aeb15778-7aab-4990-9465-944b9374bf24"));
            labelFoundationType = (ITTLabel)AddControl(new Guid("8652ba2f-7a60-4efe-84e5-52f96412f394"));
            FoundationType = (ITTEnumComboBox)AddControl(new Guid("e8e010ac-9599-403d-a809-e38e2eaeeed8"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("d41d6e36-ca43-4cdf-975d-ad2d888b6b91"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("ac256d01-ed28-4e00-a2ed-4b11d471de7b"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("b562ef5f-68d6-4942-8540-f30f2de9df61"));
            DrugOrderForReports = (ITTGrid)AddControl(new Guid("61de5640-5abb-49dc-a739-67f3f162d871"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("088a6df6-f981-41d4-8de8-07fc5e5a87de"));
            BarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("b85c0ca8-a4c7-480e-b6e9-2e206a1dd360"));
            Dosage = (ITTTextBoxColumn)AddControl(new Guid("ad6b47fa-5629-459a-992e-d4980e52fc27"));
            DosageAmount = (ITTTextBoxColumn)AddControl(new Guid("dd1920f6-3bff-4a0b-80e4-5e479a3208cb"));
            WeeklyMonthly = (ITTTextBoxColumn)AddControl(new Guid("f0178965-1c99-47a6-be68-5468c844b658"));
            HasReport = (ITTCheckBoxColumn)AddControl(new Guid("450b42a6-6ba6-4d80-8fd6-eb323c113488"));
            HasTenDays = (ITTCheckBoxColumn)AddControl(new Guid("e123fb06-c78e-4582-8e6f-af570ce0981d"));
            base.InitializeControls();
        }

        public SPTSReportEntryForm() : base("SPTSREPORTENTRYACTION", "SPTSReportEntryForm")
        {
        }

        protected SPTSReportEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}