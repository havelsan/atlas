
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
    /// Profesörler Sağlık Kurulu
    /// </summary>
    public partial class HCProfsCommitteeExaminationForm : EpisodeActionForm
    {
    /// <summary>
    /// Profesörler Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeOfProfessors _HealthCommitteeOfProfessors
        {
            get { return (TTObjectClasses.HealthCommitteeOfProfessors)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageSK;
        protected ITTTabControl tttabcontrolDiagnosis;
        protected ITTTabPage tttabpageEpisodeDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage tttabpagePreDiagnosis;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn Matter;
        protected ITTEnumComboBoxColumn Slice;
        protected ITTTextBoxColumn Anectode;
        protected ITTRichTextBoxControl Desicion;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelProtocolNo;
        protected ITTGrid ExplanationsofRejectionGrid;
        protected ITTListBoxColumn DoctorA;
        protected ITTTextBoxColumn ExplanationOfRejectionA;
        protected ITTLabel labelOtherMeasurements;
        protected ITTObjectListBox SenderChair;
        protected ITTTextBox OtherMeasurements;
        protected ITTLabel labelNumberOfDocumnets;
        protected ITTLabel labelDocumentDate;
        protected ITTTextBox ReportNo;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker InPatientDate;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelReportNo;
        protected ITTEnumComboBox PatientGroup;
        protected ITTTextBox Weight;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel ttlabel9;
        protected ITTEnumComboBox PatientStatus;
        protected ITTCheckBox Unanimity;
        protected ITTTextBox BookNumber;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelInpatientDate;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker HCStartDate;
        protected ITTLabel labelBookNumber;
        protected ITTTextBox Height;
        protected ITTDateTimePicker ReportDate;
        protected ITTTabPage tttabpagePI;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelRegistryNo;
        protected ITTLabel labelBirthDate;
        protected ITTTextBox EmploymentRecordID;
        protected ITTObjectListBox Relationship;
        protected ITTObjectListBox CityOfRegistry;
        protected ITTLabel labelVillageOfRegistry;
        protected ITTObjectListBox TownOfBirth;
        protected ITTLabel labelRank;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelBirthPlaceCountry;
        protected ITTLabel labelTownOfRegistry;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelBirlik;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTLabel labelRelationship;
        protected ITTTextBox FatherName;
        protected ITTTextBox Adres;
        protected ITTObjectListBox CityOfBirth;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelCityOfRegistry;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelTownOfBirth;
        protected ITTTextBox VillageOfRegistry;
        protected ITTLabel labelCityOfBirth;
        protected ITTObjectListBox CountryOfBirth;
        protected ITTObjectListBox TownOfRegistry;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("b2dc2c2e-2e3f-4a5e-8a80-430910987f44"));
            tttabpageSK = (ITTTabPage)AddControl(new Guid("f5ed51ca-427f-462a-8962-9c8816d6941b"));
            tttabcontrolDiagnosis = (ITTTabControl)AddControl(new Guid("8295b9fd-50a3-4ea7-9abc-41718ddcce0b"));
            tttabpageEpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("908cfcab-e022-4a26-8b19-4044d000a735"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("4138650f-0b4d-4479-b072-368478b53696"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("3bda68c7-f9cd-49e2-ba96-5ea2dec25c5a"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("59291a98-c070-4215-ad16-d121b05fe6f9"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("856dd264-fcc9-4144-8c6b-cde798cb8334"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("2903e74a-127b-40e4-8a7b-2d739d6aa4ba"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("b38511e9-070b-46d5-8708-7a950f2d5215"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("3f1016d5-52c9-4e77-950d-a1e03c8c0b0c"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("9c92d249-896f-44f2-ad2f-0bf8f860ac23"));
            tttabpagePreDiagnosis = (ITTTabPage)AddControl(new Guid("9d264c16-6b5a-4611-90eb-a5f1719a89a5"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("8f66fe73-c813-45b0-9374-1ea5ab8df83d"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("6644b6bb-22bb-49af-ad29-3c7aa883c94d"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("e8c7ba00-0582-43ba-8ea7-512a820df3ea"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("7bb3b0b8-be40-4e85-92eb-835b8eedca6e"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("ccbc65f1-9846-4e2e-a683-f0fc1124b388"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("54e93090-15fc-4c0c-b223-de0b663cecea"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("138eb1de-fabb-47ea-92e5-cf4dd6f3511a"));
            Matter = (ITTTextBoxColumn)AddControl(new Guid("6eb6e83d-24c7-4fd7-bd03-97555cb625c9"));
            Slice = (ITTEnumComboBoxColumn)AddControl(new Guid("f3886238-0af0-4837-adfa-4724dc8ba785"));
            Anectode = (ITTTextBoxColumn)AddControl(new Guid("9e76a01b-3722-4879-ab26-569e208b9d8d"));
            Desicion = (ITTRichTextBoxControl)AddControl(new Guid("a8d3c7ae-14d3-4034-9760-cd851cfeedeb"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("d85c827b-d069-49e8-8272-76366c437cbd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5425f37a-f51b-4311-b930-020d69faf4d9"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("47662596-6247-4c5b-9d28-8ed10c0cb704"));
            ExplanationsofRejectionGrid = (ITTGrid)AddControl(new Guid("ac7c0138-5622-4f0d-a364-50e38fe7c6c7"));
            DoctorA = (ITTListBoxColumn)AddControl(new Guid("64f7319d-4a31-420b-add0-7baa2037bb61"));
            ExplanationOfRejectionA = (ITTTextBoxColumn)AddControl(new Guid("d182cc86-92ee-443a-8cc9-7b687ae82167"));
            labelOtherMeasurements = (ITTLabel)AddControl(new Guid("2075002d-7693-4dff-979c-134e7f900df5"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("6b1a0b8f-d456-4a33-864b-911df541fcbe"));
            OtherMeasurements = (ITTTextBox)AddControl(new Guid("c5caf16a-503e-4632-b72a-24ab5e684c80"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("b1855af9-37f4-4969-912e-9e2df8928b33"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("f288189b-4c55-4435-99d5-0a284cd2c915"));
            ReportNo = (ITTTextBox)AddControl(new Guid("333500ea-d7b9-4600-be9c-35d4d3bacb9b"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("7d0e10d5-dece-4469-91e0-919fabff84f8"));
            labelReportDate = (ITTLabel)AddControl(new Guid("4e8e2f41-d26a-4fe0-8229-40ba7baea9c7"));
            InPatientDate = (ITTDateTimePicker)AddControl(new Guid("6392d0b9-a64e-45b3-9f35-3da37408741b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("717a9450-4986-423c-9ffb-6d6a1b6c93e3"));
            labelReportNo = (ITTLabel)AddControl(new Guid("b3e194fa-5063-4997-873f-6849236026fb"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("91d28aca-100a-475f-ab43-57326f4c5171"));
            Weight = (ITTTextBox)AddControl(new Guid("9654253d-e3a5-4856-b346-769a122b790c"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("b9296ba1-5349-4e09-8b05-4d107654a2e1"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f731720a-853d-46ba-ae2d-494f8ff83dd6"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("624c1d5a-12cb-4efe-addd-451430a62e42"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("fbe2fd39-9bc8-451e-9dc2-aae376e07b27"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("c8ff750f-e9c5-4e6d-a7a5-867760613238"));
            Unanimity = (ITTCheckBox)AddControl(new Guid("43b136cc-c287-4a1f-987d-8b1d90f42a89"));
            BookNumber = (ITTTextBox)AddControl(new Guid("4be17c43-b3ab-4e64-a2fc-b2f6598c7049"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("c67ba1a8-331a-4234-9fc6-8ebc619309a6"));
            labelInpatientDate = (ITTLabel)AddControl(new Guid("3d28ccf6-69c9-4d7b-a02c-f19b2e0116ba"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("227e18f6-492a-4d5f-b629-c25356f228d5"));
            labelStartDate = (ITTLabel)AddControl(new Guid("25d47158-b132-47ca-9bd1-c8fd8158aef9"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("c7db3ea0-a585-40eb-afbb-c67c1d88ebb9"));
            labelBookNumber = (ITTLabel)AddControl(new Guid("a04c736b-2a42-4aa8-982d-fe490c32309c"));
            Height = (ITTTextBox)AddControl(new Guid("552cffdd-9a85-4cdf-bd8e-ca7869ec1757"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("ae003f30-934b-459f-b1bd-e815b7d6e8e5"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("f9493b47-8bbe-4b19-89c2-0a4db6e847ee"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("c7e04841-5f57-4d72-a1d3-42f6bcaac9ed"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("11c70752-f2ab-4740-911f-a23329067bf2"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("153a25bd-817d-4c45-9bca-878af2084911"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("ebb9dafa-f307-49a7-bcb7-c84a8221b8bf"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("fb4fc618-cbb3-499d-8f9c-3b1d2e0f9a5c"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("0ae62a49-f50e-425a-ba02-62f88dfa0431"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("a90e7cff-02d9-4115-8ddc-8b7080cb85e9"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("1a5c5018-e7c2-4bc5-a15e-d88d16337635"));
            labelRank = (ITTLabel)AddControl(new Guid("e45d4d52-bc30-45ab-9b1b-868986e3c6da"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("7620da0d-c413-42d4-982c-5ddf3663dcd6"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("1d1c0812-4346-40c8-9106-a8c9aee38c57"));
            labelFatherName = (ITTLabel)AddControl(new Guid("3df5f81d-e600-4cb6-b72a-0e85637a4664"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("d518dd0b-28c4-4c38-aca5-61b6fa4fd587"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("ec16fb67-7367-4dc9-bfbe-e288e83b43b9"));
            Rank = (ITTObjectListBox)AddControl(new Guid("f4f81b85-62aa-4a7f-80f9-1f6b05f54643"));
            labelBirlik = (ITTLabel)AddControl(new Guid("3fef2272-2488-47dd-b76b-dd8d6d8367d0"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("64ff46ea-b0ca-4b54-ac59-844e41498534"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("31cd0609-a9cf-4ef1-be2a-a95821bdeb28"));
            labelRelationship = (ITTLabel)AddControl(new Guid("7dd99064-6db1-4c6a-9a61-12f79f270ca7"));
            FatherName = (ITTTextBox)AddControl(new Guid("bee4f1ef-c312-4855-a0ba-399a2e703a29"));
            Adres = (ITTTextBox)AddControl(new Guid("f1224e66-be1b-4912-8505-98b4a5dca584"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("5778d16a-f5e9-46d8-a891-e3387b505707"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("25ff4c82-0165-4271-9e27-12a456903284"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("2b5d110f-838f-4427-8dea-6f6a559e7fa7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("58c76c62-df54-4b4a-a83d-6335ac516749"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("58481be9-1ba6-48cc-9e6f-4efd30201fff"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("3bcbe45c-03e9-4a88-81aa-cf7618dc2656"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("665bdb76-317e-4982-8331-a36700b65c81"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("e95b2c33-398f-4e2e-9c7f-b15ee86d3de6"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("a0224f1f-2948-4ff5-bd7b-c36b0be6b69a"));
            base.InitializeControls();
        }

        public HCProfsCommitteeExaminationForm() : base("HEALTHCOMMITTEEOFPROFESSORS", "HCProfsCommitteeExaminationForm")
        {
        }

        protected HCProfsCommitteeExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}