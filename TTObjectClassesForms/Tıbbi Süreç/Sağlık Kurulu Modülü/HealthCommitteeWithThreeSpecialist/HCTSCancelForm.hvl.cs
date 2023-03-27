
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
    /// Üç Uzman Tabip İmzalı Rapor
    /// </summary>
    public partial class HCTSCancelForm : EpisodeActionForm
    {
    /// <summary>
    /// Üç Uzman Tabip İmzalı Rapor  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeWithThreeSpecialist _HealthCommitteeWithThreeSpecialist
        {
            get { return (TTObjectClasses.HealthCommitteeWithThreeSpecialist)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHCT;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelReasonForExamination;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTLabel ttlabel9;
        protected ITTTextBox tttextboxClinicReportNo;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelReasonForAdmission;
        protected ITTTextBox ReportNo;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTTextBox ProtocolNo;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTTextBoxColumn EpisodeFreeDiagnosis;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnosis;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTabPage tttabpagePI;
        protected ITTTextBox Adres;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelFatherName;
        protected ITTTextBox FatherName;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelBirthDate;
        protected ITTObjectListBox TownOfBirth;
        protected ITTLabel labelCityOfBirth;
        protected ITTObjectListBox CityOfBirth;
        protected ITTLabel labelBirthPlaceCountry;
        protected ITTLabel labelTownOfBirth;
        protected ITTObjectListBox CountryOfBirth;
        protected ITTTextBox tttextboxTCNo;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelBirlik;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelRank;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelRegistryNo;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("938f4323-1798-4b82-99c1-6e2f35ce858a"));
            tttabpageHCT = (ITTTabPage)AddControl(new Guid("e1d55db6-64be-4d35-a7a9-67bbfe3a4e4e"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("dfde8387-21a5-413d-915b-83e4e2601b97"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c0629290-b7df-41a6-8d44-4839a49d66a0"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("248e82b9-9f66-4489-9a5a-7ff7551afdc0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ba6dc288-18ca-4caf-9a75-5f5d5c63415f"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("d2d99e12-bbdd-47c0-9b49-21947c7a3fbb"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("0a9b6393-48a6-479e-b0db-bca1b06bd231"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("626c265c-cccd-42ca-8a65-c44ceab94a51"));
            tttextboxClinicReportNo = (ITTTextBox)AddControl(new Guid("2145c63f-4138-4f71-860c-bf612369fc50"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1392adaa-b402-4bf5-97dd-61dde8d7561c"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("ea0d1b99-cd3a-49fa-bff2-6eb912c80209"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("96097c43-2215-4ab7-8006-6ee9940440a4"));
            ReportNo = (ITTTextBox)AddControl(new Guid("89756035-1ced-47f4-a044-f0696a7971ec"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3580ae8e-6359-4211-83d4-b3a02ea9b166"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("14d6d2e9-8df6-4ec4-8817-878531039191"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("3f1988d0-f8d3-4817-b351-3ed343263085"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("eef90e9d-d740-41d0-a5f6-ace33f2eb78a"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("26a54ce2-2171-4f35-823e-3625e4387310"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("f49be020-57fb-4452-a5a0-bfd7651105fd"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("32179349-e8d4-4414-9503-32d435f4c934"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("feb35615-66f5-4a8a-adc7-f8f26f80c0d3"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("f4b8cf97-b89c-4a23-9956-b9a44dcc12a6"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("40fd30ec-9ca8-4893-833e-f003480f18ce"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("279b08a7-8df8-48ef-9ec1-f6f8875e7231"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("2767666a-1f2d-4e1f-ab44-c6c4cae186d2"));
            EpisodeFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("24435dfd-01be-408c-ac7e-817982cad2bd"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("586cbe1f-0321-4b55-9d90-e4746af13b89"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("8e2af27b-7581-44db-a721-1d9bfd322043"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("3b2fed64-a6ea-439a-b298-944ca73e34aa"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("b5d308ad-b2cc-466c-a3a8-8313f65617a8"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("31bbb40c-694e-47e6-847b-d1bd948162ef"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("1de34bfb-0c24-4b9c-8f4a-01cca0c11aef"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("ccecf5bb-e748-428e-8470-e18bace54a12"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("e8724f0c-4865-425b-9549-d892a9b57d0e"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("29106217-3c4b-45a4-b744-8f47b059b310"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("4fb3a1cf-ce5d-4859-adb4-51ddcf3d4fb1"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f75f6158-0452-4019-8e86-7d31328629b6"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("aef02485-a6b4-4619-b607-f39d49c0a6f8"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("6dc272b3-c216-4781-8176-fecc74b1e7e5"));
            Adres = (ITTTextBox)AddControl(new Guid("8ab17bf9-5ba9-44c3-883a-f7b94db29b11"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("1209bd98-8eb0-406a-9754-a8d833b08f9c"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("604c9559-d449-4611-94a1-c98aa957b5ae"));
            labelFatherName = (ITTLabel)AddControl(new Guid("b4cc947e-a8c0-4aa3-8a55-c7cb8de1a99b"));
            FatherName = (ITTTextBox)AddControl(new Guid("6943c4dc-e27d-457b-8ab6-116c7949936d"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("49457239-4d61-45aa-a929-1e819a9c1181"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("835b9cd8-a85b-4c87-902a-86bb6e8ab1fd"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("416631e2-d1af-4cd5-9437-c3fe8f70a02f"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("eb350d80-bcc1-434c-956c-bc7e1bdc1065"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("19a08e90-0e62-4bf5-91e2-69869773ef4f"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("c9a2f68c-4cb2-4b79-8e72-f433cc5f6762"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("e3b1164a-0603-45e7-9b42-3caaae128145"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("3f8e6b48-a4b8-4bf2-ba51-ec7c54ff9f2f"));
            tttextboxTCNo = (ITTTextBox)AddControl(new Guid("3e058e53-d68f-4946-8ff5-18bac6908a29"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b64d20d9-cf0d-4b41-9517-5d8cc7347dd6"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("3341abed-cb15-45d3-a7c4-6ae71f547cfa"));
            labelBirlik = (ITTLabel)AddControl(new Guid("b10628dc-6dab-41f0-aebe-d2bf2a8dc22f"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("2ab79d1b-7119-49d1-9e84-ca643f3c8c9c"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("82b3fc0f-8b92-49c1-8622-d7497fafd9a4"));
            Rank = (ITTObjectListBox)AddControl(new Guid("dd08b3e6-58c7-4bcb-8925-d07466607a48"));
            labelRank = (ITTLabel)AddControl(new Guid("36d46e7f-0207-49c3-807d-4f165ef59652"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("af5a6fea-6713-431b-bce5-02aeaaf068a2"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("f5f334a5-474b-483c-828c-6088804e938c"));
            base.InitializeControls();
        }

        public HCTSCancelForm() : base("HEALTHCOMMITTEEWITHTHREESPECIALIST", "HCTSCancelForm")
        {
        }

        protected HCTSCancelForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}