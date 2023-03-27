
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
    public partial class HCPReportApproval : TTForm
    {
    /// <summary>
    /// Profesörler Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeOfProfessors _HealthCommitteeOfProfessors
        {
            get { return (TTObjectClasses.HealthCommitteeOfProfessors)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpageHC;
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
        protected ITTGrid HospitalsUnits;
        protected ITTListBoxColumn Units;
        protected ITTListBoxColumn RespectiveDoctor;
        protected ITTCheckBoxColumn ApprovalStatus;
        protected ITTTextBox ReasonForRequest;
        protected ITTLabel labelUnitsHospitals;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelNumberOfDocumnets;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelOtherMeasurements;
        protected ITTDateTimePicker DocumentDate;
        protected ITTTextBox OtherMeasurements;
        protected ITTObjectListBox SenderChair;
        protected ITTTextBox ReportNo;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker InPatientDate;
        protected ITTLabel labelReportNo;
        protected ITTLabel labelProtocolNo;
        protected ITTTextBox Weight;
        protected ITTLabel ttlabel8;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel9;
        protected ITTTextBox ProtocolNo;
        protected ITTCheckBox Unanimity;
        protected ITTTextBox BookNumber;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTDateTimePicker HCStartDate;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelStartDate;
        protected ITTTextBox Height;
        protected ITTLabel labelInpatientDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelBookNumber;
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
        protected ITTTabPage tttabpageDecision;
        protected ITTRichTextBoxControl Desicion;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("3cad02c0-cf67-4b65-b92e-b97ba8f1adbe"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("34be3be7-9c79-4aad-93d6-94704a75c4c6"));
            tttabcontrolDiagnosis = (ITTTabControl)AddControl(new Guid("b9386292-ed8e-46d6-afc3-2211fc41d430"));
            tttabpageEpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("06e20971-759c-4433-aeb3-8a621c2da80b"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("a45506ba-9610-44c9-a0bb-54e7b09c6656"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("63c20340-29a6-4ea9-9cca-c1b3b2048b98"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("876dc5ac-7752-48f1-8560-147822a2b317"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("8bcefed0-1eb0-4274-afac-e2228371f650"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("267b50aa-054a-456e-ae8a-64975bcd3da9"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("aefca165-b77a-4f17-a048-833e511f19b3"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("3ebc24d6-da57-49eb-bc74-4fc868a63169"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("503d4bb0-ad86-4607-b14c-192bd0952872"));
            tttabpagePreDiagnosis = (ITTTabPage)AddControl(new Guid("7f4e5447-57a2-4d3a-88bc-d3bc83924502"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("c263e9c8-717a-4258-89dc-e837e8a4a579"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("4285155c-9960-4811-9ae5-ad287a827dbe"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("39285784-6a68-4ab0-897f-a7b2d5d7ad4d"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("91504af9-8dd2-4679-abb5-8e04db7650a1"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("b4bd1860-0d44-4905-935f-fef384ba20f0"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("08af5a5f-c9ae-437d-8dea-c1b97da23faa"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("109c0283-632f-45bc-8d4f-f9691de7e373"));
            Units = (ITTListBoxColumn)AddControl(new Guid("3d31ebd7-a15a-4f33-8f7f-562765346597"));
            RespectiveDoctor = (ITTListBoxColumn)AddControl(new Guid("f2310b44-331f-4504-8c86-84791380fcdc"));
            ApprovalStatus = (ITTCheckBoxColumn)AddControl(new Guid("febce6f1-2de7-499c-beea-dcbbe19efcdc"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("8daf5123-2457-4529-b66a-094eb2e5aeee"));
            labelUnitsHospitals = (ITTLabel)AddControl(new Guid("c3b553de-3a2c-4fa3-a0a2-e792f703eedc"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("dc008e7e-2b67-408a-8ea1-9babfdda5a9d"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("40cfa35f-edc8-40be-9388-1eb9fb63d92b"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("3b8f1227-0a3e-4abd-ade2-ec0715e62e8f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("aeb3292a-c36b-464c-bf22-fe86150d9668"));
            labelOtherMeasurements = (ITTLabel)AddControl(new Guid("a031012d-f2dc-4ba6-a940-7b55251a8988"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("9fbf4dfc-a812-4929-bcf8-c891dd68a8c2"));
            OtherMeasurements = (ITTTextBox)AddControl(new Guid("eb9f94ce-fb0e-4867-96dd-06e040e8921b"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("b2f039b8-e8e5-4456-8862-03ac1faaf01f"));
            ReportNo = (ITTTextBox)AddControl(new Guid("40d44bff-4ebb-45fc-bccf-a84ba172bbf4"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("5ef1cff7-bd3e-44b2-bdfc-b5e7f067eff7"));
            labelReportDate = (ITTLabel)AddControl(new Guid("984d5a1a-010e-4f9a-a2a2-6aada6700de7"));
            InPatientDate = (ITTDateTimePicker)AddControl(new Guid("3aec8b1f-a36a-48e7-8c3b-ce858b3315ba"));
            labelReportNo = (ITTLabel)AddControl(new Guid("1895c821-a34e-42eb-82b1-43b5daee4a91"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("ef46ea9c-ad2c-46b9-8a96-436d8baf5f03"));
            Weight = (ITTTextBox)AddControl(new Guid("d2f03a47-9c41-466f-aeac-2be878fbb4b1"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("3360b6eb-38fa-47da-8028-af0022bdfa1c"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("57fad278-3d81-4f1f-8fb6-b94f575ced0e"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("3dbc6655-6353-4c45-9708-edf9f93a59f5"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("bbbbe1ec-d53b-4f49-bad1-dcc34945b600"));
            Unanimity = (ITTCheckBox)AddControl(new Guid("901d7197-7bff-4070-b60e-e004bbf329c1"));
            BookNumber = (ITTTextBox)AddControl(new Guid("ce25ca79-1935-478a-9a68-0f466119e3b9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b2a9f3cf-ccfa-4fd6-b94f-75e946f0d85f"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("1ed35ac7-4c49-43b3-a83c-f9ff7bb8de70"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("3561c959-355c-44c9-a2e5-7a872f1e7fef"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("60b0bb49-ac6e-4d68-9b5f-6cf28273567b"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("c11bd822-9473-4446-bb53-fabcb8892756"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("84238e68-6121-4df7-af61-a9be681e8c26"));
            labelStartDate = (ITTLabel)AddControl(new Guid("0af07858-1797-4206-97a3-d46f0b9db100"));
            Height = (ITTTextBox)AddControl(new Guid("6ddb4bfa-f30d-403e-a0be-b7def3bfe61b"));
            labelInpatientDate = (ITTLabel)AddControl(new Guid("82fc348c-1a7f-4752-85c3-737b930388b7"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("eeb5b241-5bcb-43fb-ad4a-2aca8162ded0"));
            labelBookNumber = (ITTLabel)AddControl(new Guid("404983f7-3473-4c9d-851d-9e06542d76a1"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("8653a2d6-7243-463c-8d54-40ea110dc0f6"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("64bcc7fa-11a7-47ac-b9ad-8e5e7e2744e2"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("629196bd-f475-446d-bddd-4fefe830b935"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("b1413de8-0b3b-4c05-964f-c56e20916d8b"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("75d15551-e2d3-4d0d-9e9e-6e3efbc463ba"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("fe5cf9b1-bc32-4bdf-9bc2-fa034c108cde"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("e2a219b0-3cf2-481e-af1e-49781201c58c"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("10f003ea-c260-4c52-8462-86bf99abe2d1"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("f0ca2700-5c43-4dce-839d-67539982ef53"));
            labelRank = (ITTLabel)AddControl(new Guid("346baa19-fe61-42b5-a870-8cd755d6a840"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("a6970ebe-fdc7-4b19-a5ab-07827a339913"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("be19acf2-7181-4c0c-9269-356efce262df"));
            labelFatherName = (ITTLabel)AddControl(new Guid("01631a02-f4b6-4ad0-98e1-c24ab6b364fb"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("9b255baa-1818-4fd6-aae2-bb8cc23201f1"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("45e1c760-11a4-4763-9b72-fd35c83dca96"));
            Rank = (ITTObjectListBox)AddControl(new Guid("79b982e0-092a-4b6c-bc09-1ce3e462eb82"));
            labelBirlik = (ITTLabel)AddControl(new Guid("2587207c-379d-4324-8490-1a0fa8dec80a"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("5a858d96-16af-4ba2-996f-abede8f24595"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("2f1dcbbd-ec10-419d-aa18-8fbfcec72ff6"));
            labelRelationship = (ITTLabel)AddControl(new Guid("86853fcc-da4e-4738-9d8e-f46eb05cf181"));
            FatherName = (ITTTextBox)AddControl(new Guid("13327032-ec42-43e2-a365-56f77d3f0431"));
            Adres = (ITTTextBox)AddControl(new Guid("b7ff80a7-49d5-4dc1-af4e-350a8bbffe6d"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("bab9a75b-e6b2-40d1-85e9-5e96fb55d6e7"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("d1887668-f23f-4198-a838-96300ba74970"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("ac85512b-b0c0-4aeb-a3e3-72c1007c3906"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3f5e4829-9263-4da7-af8e-20553e61166a"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("300174cc-ee17-42ef-81ae-02ddbb9b4e9a"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("a750a397-4ed8-4bff-9f89-1caf0836e12c"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("dcc9c887-eca0-4649-a05c-3a9aff5fe0f3"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("2eb0efd2-ba14-4676-b089-088bdf6e9862"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("a29f4615-91bd-4723-86a8-99e7e783432b"));
            tttabpageDecision = (ITTTabPage)AddControl(new Guid("8797a9fd-20a0-4d1f-a360-666f45e7456f"));
            Desicion = (ITTRichTextBoxControl)AddControl(new Guid("7bf34c51-6d7a-4979-9db6-dbe33535c682"));
            base.InitializeControls();
        }

        public HCPReportApproval() : base("HEALTHCOMMITTEEOFPROFESSORS", "HCPReportApproval")
        {
        }

        protected HCPReportApproval(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}