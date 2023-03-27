
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
    /// Önemli Tıbbi Bilgiler
    /// </summary>
    public partial class ImportantMedicalInformationCompletedForm : EpisodeActionForm
    {
    /// <summary>
    /// Hastanın Önemli Tıbbi Bilgilerinin Grişinin Yapıldığı Nesnedir.
    /// </summary>
        protected TTObjectClasses.ImportantMedicalInformation _ImportantMedicalInformation
        {
            get { return (TTObjectClasses.ImportantMedicalInformation)_ttObject; }
        }

        protected ITTCheckBox IsPregnant;
        protected ITTButton ttbutton1;
        protected ITTLabel labelBloodGroup;
        protected ITTCheckBox WarnAllMedicalPersonnel;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage DiagnosisHistoryInfo;
        protected ITTGrid DiagnosisHistory;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTListBoxColumn Diagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTTabPage CancelledDiagnosisInfo;
        protected ITTGrid CancelledDiagnosis;
        protected ITTDateTimePickerColumn CancelledDiagnoseDate;
        protected ITTListBoxColumn CancelledDiagnose;
        protected ITTListBoxColumn CancelDiagnoseUser;
        protected ITTEnumComboBox BloodGroup;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PatientHistory;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelIllnessAndOperation;
        protected ITTLabel ttlabel2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol4;
        protected ITTLabel ttlabel3;
        protected ITTRichTextBoxControl OrganInfo;
        protected ITTTabPage AllergyVaccination;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn Name;
        protected ITTTextBoxColumn Reaction;
        protected ITTEnumComboBoxColumn Risk2;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelAllergyInformation;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn Aşı;
        protected ITTTextBoxColumn Geçerliliği;
        protected ITTEnumComboBoxColumn Risk;
        protected ITTTabPage HistoryInfo;
        protected ITTRichTextBoxControl ttrichtextboxcontrol6;
        protected ITTRichTextBoxControl ttrichtextboxcontrol5;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        override protected void InitializeControls()
        {
            IsPregnant = (ITTCheckBox)AddControl(new Guid("277b2b4b-c27b-4ce3-9f18-ce2c162e2e62"));
            ttbutton1 = (ITTButton)AddControl(new Guid("15b015bc-5179-4cbe-b2e9-ee1d6e6892ef"));
            labelBloodGroup = (ITTLabel)AddControl(new Guid("59d07ed4-570c-4c52-8ee8-323cc1607ea8"));
            WarnAllMedicalPersonnel = (ITTCheckBox)AddControl(new Guid("f75870c6-bfec-4592-a42a-47ac960eaf1b"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("5ecf6f8d-e05a-4ec6-a8e6-ef48d7eae5e6"));
            DiagnosisHistoryInfo = (ITTTabPage)AddControl(new Guid("9242384d-c2eb-48e2-bfb8-019b678f2e33"));
            DiagnosisHistory = (ITTGrid)AddControl(new Guid("4918bf51-a99f-4475-91bd-89021f4b783c"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e3055c5c-1a59-4eb8-8739-d0f4c81b2af9"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("2931932a-af83-42c1-b129-6ee407b87867"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("f91d77d7-5e21-425d-a388-88b22fce34a9"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("c25f8939-9b6f-4b54-9cce-98e7833e5f04"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("f247f0f5-0b02-42f9-b65b-42f4ef077744"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("806dd7cb-f587-4b77-84f9-86879dfaa76c"));
            CancelledDiagnosisInfo = (ITTTabPage)AddControl(new Guid("fb88b911-5b9b-43c3-8267-86b0423defe2"));
            CancelledDiagnosis = (ITTGrid)AddControl(new Guid("62e8daf7-1f96-435e-aefa-c95d500685ac"));
            CancelledDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("f58ee9f2-3b7b-4fd8-9580-829ead80b03a"));
            CancelledDiagnose = (ITTListBoxColumn)AddControl(new Guid("8afc8f6f-5bd7-432f-acb2-ceb2c73e2f73"));
            CancelDiagnoseUser = (ITTListBoxColumn)AddControl(new Guid("7d51483b-28d0-47b5-a9db-fa9311a6427f"));
            BloodGroup = (ITTEnumComboBox)AddControl(new Guid("8e1b024f-fe15-466c-8aa8-d106a87d417f"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d8596aa3-0d54-447e-bebe-336e160c6e97"));
            PatientHistory = (ITTTabPage)AddControl(new Guid("6a2eb973-85ec-4ed5-a028-242abff5578d"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("0a2b4ad7-fdbd-4b4f-bb37-706ecf61ad03"));
            labelIllnessAndOperation = (ITTLabel)AddControl(new Guid("da4f8329-30ac-4c70-a43c-c230629ff086"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("074538a7-e0cd-4cd6-82f5-55bf6c5a5a87"));
            ttrichtextboxcontrol4 = (ITTRichTextBoxControl)AddControl(new Guid("c48fb972-6160-4aa7-aba7-fb95e0a96917"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0ff8d67a-4ac7-4283-8613-e67e8b78f95c"));
            OrganInfo = (ITTRichTextBoxControl)AddControl(new Guid("c3222010-042b-445c-9c25-d925495fa698"));
            AllergyVaccination = (ITTTabPage)AddControl(new Guid("a2c0b9e6-7f9a-49fa-8129-e4f0434086f3"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("6a624794-5f39-449c-af09-e72d600cda03"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("5544b7c9-d94c-43b1-b4c3-445b5dfc2c0c"));
            Reaction = (ITTTextBoxColumn)AddControl(new Guid("35c2d382-baec-42b3-8ece-1a1fb09819f6"));
            Risk2 = (ITTEnumComboBoxColumn)AddControl(new Guid("512ee38d-62e3-4466-a4e6-a15396207b13"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("281ccf3f-c66a-47c9-8344-b030c6f62fc8"));
            labelAllergyInformation = (ITTLabel)AddControl(new Guid("530883cb-7372-4f7e-b451-1c8425e868c5"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("4bfa1b77-5d1e-4608-9c99-5eefcca2bc67"));
            Aşı = (ITTTextBoxColumn)AddControl(new Guid("633097bc-01da-43a1-90c9-fe50b7cbd824"));
            Geçerliliği = (ITTTextBoxColumn)AddControl(new Guid("2448b007-bd84-4e81-b63e-3b4adecaaa53"));
            Risk = (ITTEnumComboBoxColumn)AddControl(new Guid("69566152-bf96-4e6a-ad83-eeffec2df77b"));
            HistoryInfo = (ITTTabPage)AddControl(new Guid("6b69a379-f773-4525-84f9-2ae9d5b24783"));
            ttrichtextboxcontrol6 = (ITTRichTextBoxControl)AddControl(new Guid("d0f94cfc-0c1f-40d6-a168-d278b616016b"));
            ttrichtextboxcontrol5 = (ITTRichTextBoxControl)AddControl(new Guid("ac38f6bc-db53-477d-8e64-0793a70075e9"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("3623510a-be86-44f5-a04d-9f8de2ab15be"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("7d93a7f8-33e9-4a6b-b87b-ad5137d6451b"));
            base.InitializeControls();
        }

        public ImportantMedicalInformationCompletedForm() : base("IMPORTANTMEDICALINFORMATION", "ImportantMedicalInformationCompletedForm")
        {
        }

        protected ImportantMedicalInformationCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}