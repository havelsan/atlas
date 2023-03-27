
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
    /// Normal Doğum İşlemleri
    /// </summary>
    public partial class RegularObstetricNewForm : EpisodeActionForm
    {
    /// <summary>
    /// Normal Doğum
    /// </summary>
        protected TTObjectClasses.RegularObstetric _RegularObstetric
        {
            get { return (TTObjectClasses.RegularObstetric)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelBirthLocationPregnancy;
        protected ITTObjectListBox BirthLocationPregnancy;
        protected ITTLabel labelBirthTerminationDatePregnancy;
        protected ITTDateTimePicker BirthTerminationDatePregnancy;
        protected ITTLabel labelLastMenstrualPeriodPregnancy;
        protected ITTDateTimePicker LastMenstrualPeriodPregnancy;
        protected ITTLabel labelEstimatedBirthDatePregnancy;
        protected ITTDateTimePicker EstimatedBirthDatePregnancy;
        protected ITTLabel labelPregnancyRange;
        protected ITTObjectListBox PregnancyRange;
        protected ITTLabel labelBirthResult;
        protected ITTObjectListBox BirthResult;
        protected ITTLabel labelWhichPregnancy;
        protected ITTTextBox WhichPregnancy;
        protected ITTLabel labelPregnancyRiskInfo;
        protected ITTTextBox PregnancyRiskInfo;
        protected ITTLabel labelMotherAge;
        protected ITTTextBox MotherAge;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn RegularObstetricActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn RegularObstetricDoctor;
        protected ITTTextBoxColumn RaporTakipNo;
        protected ITTListDefComboBoxColumn OzelDurum;
        protected ITTListDefComboBoxColumn AyniFarkliKesi;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTabPage PersonnelTab;
        protected ITTGrid GridPersonnel;
        protected ITTListBoxColumn Personnel;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn StockOutAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTListDefComboBoxColumn MalzemeTuru;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTCheckBox ApprovalFormGiven;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("4ef8fc53-d432-4abc-b9c3-9bc49395c7f5"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("4e14053f-3c6a-442f-ae93-b1c77c65f793"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("da7c8960-4718-47ad-afc3-8f2941631791"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("b5d5c457-272b-4c79-8f8d-456166e530b9"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e13a9c34-cbb0-4842-96f8-23d62e124243"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("03175b4a-8225-4605-a3f7-cb67e3a4bd48"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("b59731ba-87ff-4b13-8ebb-13e6b5843166"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("a5f01dc8-ebb3-428f-8984-63f7cc273d72"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("35f60693-644a-4e0c-b377-81acdc117a50"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("520a6327-5188-4458-8202-a2527d2fe997"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("72204c9e-f76f-4bb8-9f84-93c22c17faa6"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("7313a78a-2758-4884-b0d7-b30e0d1f75d6"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("e00c3ad6-0401-4f5a-8f30-abff004d669a"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("8aa86b06-ff1b-4fd1-a0da-d0c55fbdc637"));
            labelBirthLocationPregnancy = (ITTLabel)AddControl(new Guid("b8475fc5-c96e-4384-a13f-f746ce439eb2"));
            BirthLocationPregnancy = (ITTObjectListBox)AddControl(new Guid("ee2170d2-2fe0-44d5-a9cc-b7eb6cb89906"));
            labelBirthTerminationDatePregnancy = (ITTLabel)AddControl(new Guid("52f3de2b-0629-44fc-8860-657e768b86e5"));
            BirthTerminationDatePregnancy = (ITTDateTimePicker)AddControl(new Guid("ed74372b-806d-42ad-9b2e-7427938b947b"));
            labelLastMenstrualPeriodPregnancy = (ITTLabel)AddControl(new Guid("a68002bb-82d7-437a-8dd0-4d8b7aff3354"));
            LastMenstrualPeriodPregnancy = (ITTDateTimePicker)AddControl(new Guid("2172c4ba-203d-41a1-9e41-6cc3f020e9f6"));
            labelEstimatedBirthDatePregnancy = (ITTLabel)AddControl(new Guid("633a0c1c-5ebf-4169-8fcd-de4801d3cafb"));
            EstimatedBirthDatePregnancy = (ITTDateTimePicker)AddControl(new Guid("5a76e172-5e48-4ae1-9b73-2f959b7a97cd"));
            labelPregnancyRange = (ITTLabel)AddControl(new Guid("095ec704-595e-4eef-8217-a84fb71a9300"));
            PregnancyRange = (ITTObjectListBox)AddControl(new Guid("282bb7b0-52ec-4154-a299-f599ed20523a"));
            labelBirthResult = (ITTLabel)AddControl(new Guid("53271499-4411-4eb2-941d-cb7d24603ec7"));
            BirthResult = (ITTObjectListBox)AddControl(new Guid("1977434d-50e1-408e-b37c-02b6b9382d19"));
            labelWhichPregnancy = (ITTLabel)AddControl(new Guid("fb98ddfa-4e23-45b2-ad58-665a565cee27"));
            WhichPregnancy = (ITTTextBox)AddControl(new Guid("5818f352-3ea4-401b-a009-5ef58a2fd024"));
            labelPregnancyRiskInfo = (ITTLabel)AddControl(new Guid("1db06b4e-566e-42e8-a7ef-92b37ca19bd2"));
            PregnancyRiskInfo = (ITTTextBox)AddControl(new Guid("ea3c1c3f-2748-4457-b431-f622e169c8fc"));
            labelMotherAge = (ITTLabel)AddControl(new Guid("0ad668c8-6519-4781-b1c3-24492940f906"));
            MotherAge = (ITTTextBox)AddControl(new Guid("85e4f63d-a5e6-421f-8f10-d46e78db8da1"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("23c8e3fa-940e-4752-875f-e054b6a70b15"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("f3575d36-a17a-4eb8-8c39-131d1f75b4b4"));
            GridManipulations = (ITTGrid)AddControl(new Guid("b9b9cc5b-b257-489e-bb0b-17a07d32a0b8"));
            RegularObstetricActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b08c0151-ecb7-4011-84f5-5eb304593624"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("7eb7a8b4-d777-4fa8-8cfc-102437006875"));
            RegularObstetricDoctor = (ITTListBoxColumn)AddControl(new Guid("1db0c9a6-0c8c-4db1-afc5-3d7a931966f3"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("5a8143da-8018-42da-b30e-bfca42b814a6"));
            OzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("63a4e2d7-9135-4054-8f17-1c9191e4f4e1"));
            AyniFarkliKesi = (ITTListDefComboBoxColumn)AddControl(new Guid("9835f314-52b7-40ab-9d80-219201d4a5e7"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("797e8e12-2729-4ecd-aaf0-c3e80a37d3ea"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("5904daea-6b26-4eda-90d9-e480d8be0901"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("12bf8352-6bc9-4f2c-a991-9e62c856770a"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("8a629cee-4ec7-4874-a952-81f416f06ce6"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("2dff322f-9fad-4fec-99ec-7c799bfe71f4"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("de8c24e6-e707-4cd4-8c71-1511b21aa4ea"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("c52b473c-c9ab-4fe8-ae4a-47c8e393defa"));
            Material = (ITTListBoxColumn)AddControl(new Guid("276ba5ec-38f6-4fe8-8d41-d17c0f07e834"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("5067eec0-7415-4244-9f08-564260248f40"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("1ee8e059-c38e-4f11-b05b-b79ecda48cef"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("688c1a78-f9c5-4176-a74d-a2964951c4f4"));
            StockOutAmount = (ITTTextBoxColumn)AddControl(new Guid("5753a0a8-4fbf-4eb8-baed-f97d353cef7b"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("745acb3c-ee9c-47ec-8078-862adf09b4f1"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("87106e66-a933-4144-b790-49617c87c138"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("ec8a8868-7827-44cb-a6fc-376c7806080c"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("6d5709f1-2223-4e6b-9b00-4352641463b5"));
            MalzemeTuru = (ITTListDefComboBoxColumn)AddControl(new Guid("ba1f55bf-40cf-4200-acff-8c0ca9a8fc9d"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("a4ee0322-784e-4988-89c9-dc8dedcc6550"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("091ec71b-74b9-4c02-abc4-51bfe68efcb0"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("f2922021-2a5c-4416-befe-0908d6db6605"));
            ApprovalFormGiven = (ITTCheckBox)AddControl(new Guid("b435b870-b1db-4ad4-b7fb-878182486a2e"));
            base.InitializeControls();
        }

        public RegularObstetricNewForm() : base("REGULAROBSTETRIC", "RegularObstetricNewForm")
        {
        }

        protected RegularObstetricNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}