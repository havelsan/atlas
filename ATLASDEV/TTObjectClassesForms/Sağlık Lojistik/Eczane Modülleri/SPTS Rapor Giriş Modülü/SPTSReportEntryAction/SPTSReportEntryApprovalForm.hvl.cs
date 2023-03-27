
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
    /// SPTS Onay
    /// </summary>
    public partial class SPTSReportEntryApprovalForm : TTForm
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
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelReportEndDate;
        protected ITTDateTimePicker ReportEndDate;
        protected ITTLabel labelReportStartDate;
        protected ITTDateTimePicker ReportStartDate;
        protected ITTLabel ttlabel1;
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
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("e1056b23-a8b5-472f-bef4-33042022413e"));
            SchemeOfCure = (ITTCheckBox)AddControl(new Guid("dfd62222-8669-432d-a1af-0b35c0b766ee"));
            TValue = (ITTCheckBox)AddControl(new Guid("edb07b25-5fbc-4714-8355-5fc5a18444d6"));
            PathologyReport = (ITTCheckBox)AddControl(new Guid("0fb1902c-4fbd-467c-927b-b567c6d6e007"));
            OralNutrition = (ITTCheckBox)AddControl(new Guid("683e19a5-eb0f-4213-a2ac-18b2181faca4"));
            AgeAndSize = (ITTCheckBox)AddControl(new Guid("d44e5735-846b-4316-a7ea-1899cb3c47ac"));
            SpecialityForReports = (ITTGrid)AddControl(new Guid("116b9772-ce9c-446c-bc2c-308bd2bc2aae"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("bc9d550e-cfbc-4f76-a2ce-900875d3856e"));
            DiagnosisForReports = (ITTGrid)AddControl(new Guid("639bcfbf-804b-4180-952e-cdf4f2e7b796"));
            SPTSDiagnosisInfo = (ITTListBoxColumn)AddControl(new Guid("95a2c439-c5b7-4825-bc1c-75d4d78a1749"));
            labelID = (ITTLabel)AddControl(new Guid("6625b371-9331-46cd-9563-198af3a43712"));
            ID = (ITTTextBox)AddControl(new Guid("bc49ee3e-228c-476c-8f34-4437c01779fb"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6933396c-b448-42d2-a7fd-a1f842dc007b"));
            labelActionDate = (ITTLabel)AddControl(new Guid("6b9dcea9-3cd2-4480-98a3-3d0d4fcc4666"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("aa588a98-82ed-4a2c-a17d-464bedf9619b"));
            labelReportEndDate = (ITTLabel)AddControl(new Guid("4ada8020-1a5b-4659-93cf-a0373a742ed1"));
            ReportEndDate = (ITTDateTimePicker)AddControl(new Guid("4d5c76c1-5250-4712-8fc3-20b11ccf13c5"));
            labelReportStartDate = (ITTLabel)AddControl(new Guid("0dc309da-505e-4dc4-834c-aec0c3131064"));
            ReportStartDate = (ITTDateTimePicker)AddControl(new Guid("63f80bd8-d92b-45bc-8962-16ad6e30fff6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("be0e5d44-18fe-4a5d-b007-38af34f756eb"));
            labelFoundationType = (ITTLabel)AddControl(new Guid("eca06bf1-db52-4de2-aee1-f9b115210679"));
            FoundationType = (ITTEnumComboBox)AddControl(new Guid("d1cdd27f-a02a-4d5d-913e-0cc35027b528"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("eb98f2be-f754-4c6d-a312-c8292d3634ee"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("0b18b933-a334-4164-b93a-b3850d86bb2a"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("7bb602bc-efc7-41a8-9e6c-aef17e79bab1"));
            DrugOrderForReports = (ITTGrid)AddControl(new Guid("77efeba3-7137-46a2-84d6-9f2ce056c23c"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("eb49c9cc-e3f0-49bf-92da-ef1d7fa6a218"));
            BarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("4dc980d3-10b8-42c1-b800-f5176a7f03f4"));
            Dosage = (ITTTextBoxColumn)AddControl(new Guid("71df7927-ba5b-409d-9cca-12b427dc0371"));
            DosageAmount = (ITTTextBoxColumn)AddControl(new Guid("cd0282a5-9442-4faa-9bce-f867c8707664"));
            WeeklyMonthly = (ITTTextBoxColumn)AddControl(new Guid("7120dfc9-6ee5-4e41-9d7e-2adef89b1806"));
            HasReport = (ITTCheckBoxColumn)AddControl(new Guid("e534a3e0-84f6-448c-b999-76591aeed30b"));
            HasTenDays = (ITTCheckBoxColumn)AddControl(new Guid("50a059e6-e281-4560-92b2-4dc5b6344e38"));
            base.InitializeControls();
        }

        public SPTSReportEntryApprovalForm() : base("SPTSREPORTENTRYACTION", "SPTSReportEntryApprovalForm")
        {
        }

        protected SPTSReportEntryApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}