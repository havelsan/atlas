
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
    /// Sağlık Kurulu Rapor Çıkış
    /// </summary>
    public partial class ReportOutputForm : EpisodeActionForm
    {
    /// <summary>
    /// Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommittee _HealthCommittee
        {
            get { return (TTObjectClasses.HealthCommittee)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHC;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel16;
        protected ITTDateTimePicker ttdateDateOfExists;
        protected ITTLabel ttlabel15;
        protected ITTTabControl tttabcontrolDiagnosis;
        protected ITTTabPage tttabpageEpisodeDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTTextBoxColumn EpisodeFreeDiagnosis;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage tttabpagePreDiagnosis;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTTextBoxColumn FreeDiagnosis;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTextBox tttextboxClinicWeight;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTTextBox RationWeight;
        protected ITTTextBox tttextboxClinicHeight;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel1;
        protected ITTTextBox RationHeight;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTTextBox tttextboxBookCategory;
        protected ITTDateTimePicker HCStartDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelReportDate;
        protected ITTLabel labelReportNo;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTCheckBox Unanimity;
        protected ITTTextBox BookNumber;
        protected ITTObjectListBox MasterResource;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel LabelMasterResource;
        protected ITTTextBox NumberOfProcedure;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelNumberOfDocumnets;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelBookNumber;
        protected ITTTextBox ReportNo;
        protected ITTTabPage tttabpagePI;
        protected ITTObjectListBox MilitaryOffice;
        protected ITTLabel ttlabel11;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelBirthDate;
        protected ITTTextBox Adres;
        protected ITTLabel ttlabel7;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox FatherName;
        protected ITTObjectListBox Relationship;
        protected ITTObjectListBox TownOfRegistry;
        protected ITTObjectListBox CityOfRegistry;
        protected ITTLabel labelRelationship;
        protected ITTObjectListBox TownOfBirth;
        protected ITTLabel labelCityOfBirth;
        protected ITTTextBox VillageOfRegistry;
        protected ITTLabel labelVillageOfRegistry;
        protected ITTLabel labelTownOfRegistry;
        protected ITTObjectListBox CityOfBirth;
        protected ITTLabel labelBirthPlaceCountry;
        protected ITTLabel labelTownOfBirth;
        protected ITTObjectListBox CountryOfBirth;
        protected ITTTextBox tttextboxTCNo;
        protected ITTLabel ttlabel12;
        protected ITTLabel labelCityOfRegistry;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelBirlik;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelRank;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelRegistryNo;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTabPage tttabpageDecision;
        protected ITTTabPage tttabpagePRV;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("1707d68d-144b-4b4b-bfa5-0b9389514113"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("7351cab8-5edd-44c8-869a-26cd5ecdd3f3"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("1a57b160-67e5-4a0d-b687-b3da77edfe99"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("c5f372a1-0a89-4250-bd3a-fffea97803f9"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("dc1e20ef-df85-4617-824b-08bf6f46a6f7"));
            ttdateDateOfExists = (ITTDateTimePicker)AddControl(new Guid("aa02a16f-6471-47aa-9863-bace679852cc"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("1675b86a-c9a4-4af2-b24c-c7a1c259b62f"));
            tttabcontrolDiagnosis = (ITTTabControl)AddControl(new Guid("6a592ae2-b2e9-4abe-b44f-b755a7af8916"));
            tttabpageEpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("86180f1c-9e87-4099-9271-65792dd7dab0"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("063a5d73-cf1b-4f81-8231-32dc9638740f"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c6adbfcd-6640-47f5-a2bb-f9d4fc990e8e"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("7f58c168-5b88-427f-99b2-4e152d17d8dd"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("1fea1233-59ad-4295-af1f-9f94b242675d"));
            EpisodeFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("1cd1c861-4288-4b25-ade6-bf4b3e2f3450"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("49a58be7-1576-4d05-b8fb-7cd8b5507d4d"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("957dcb66-6952-4948-be62-78aa1fb6183c"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("3b791700-d1fc-4176-8639-d389038a74a3"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("4a5194db-c886-44dc-95dc-3d646b8c2d42"));
            tttabpagePreDiagnosis = (ITTTabPage)AddControl(new Guid("300449c1-721a-4574-a8e1-d356e6851861"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("2baf11c7-1b78-4cbc-8082-c7cc93c6ae74"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("cd267cf8-dc37-4de2-b54f-09095a24dd87"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("1d2e0f85-5755-484c-821b-23954bebbeb4"));
            FreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("bc8f6425-e26b-4d8a-901e-b1019cace374"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("a5532250-6af8-48cb-8d4a-2c508e764877"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("23282486-6c9e-4a11-90a9-91656d695fde"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("059054c5-d527-4bc6-ab34-54496411ac27"));
            tttextboxClinicWeight = (ITTTextBox)AddControl(new Guid("89c8f771-9a91-4b71-91aa-3382a91c5387"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("1784b8d5-cdda-4397-9302-705ee42419f1"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b3dd66a8-eb3b-4d8d-880a-74dd622c4c26"));
            RationWeight = (ITTTextBox)AddControl(new Guid("034d77f3-2eea-48fa-8bc8-4638b6aea22d"));
            tttextboxClinicHeight = (ITTTextBox)AddControl(new Guid("85417be4-861e-4e75-b5fc-59bc0ff450a9"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("207c6abd-1fac-4ff5-9a80-3d9076e68c0e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("45b6e88f-1bb3-4297-9853-186f744627af"));
            RationHeight = (ITTTextBox)AddControl(new Guid("8656684b-3b2a-4867-a70a-4b00771007e6"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("7484cc6f-5b2c-4237-bf39-e76677d080a0"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("0352d69f-3732-4ea2-9fdd-15eb39193e76"));
            tttextboxBookCategory = (ITTTextBox)AddControl(new Guid("0daf552c-5443-4ed8-ba38-4b60aa661c8c"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("e964ea99-7f3c-46cd-8eb0-d12a32f34ace"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("14d14ecb-2639-46da-bbbe-2e2108e58864"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("ee536bcb-9bf9-4570-8c9f-525ce9a0240d"));
            labelStartDate = (ITTLabel)AddControl(new Guid("5bea63d6-eb99-4bb1-9fa9-f03f04c2056f"));
            labelReportDate = (ITTLabel)AddControl(new Guid("bb30778c-b5d8-43b5-973e-5a043de103b8"));
            labelReportNo = (ITTLabel)AddControl(new Guid("b7b8231a-8d8f-49f3-9da5-b0c4feb1624a"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("61e89616-9b1c-4b13-bcee-1cae220713ca"));
            Unanimity = (ITTCheckBox)AddControl(new Guid("68204e18-b7f1-497b-bdc1-c3b593fa7fce"));
            BookNumber = (ITTTextBox)AddControl(new Guid("72a1b4f5-2e3d-4c08-883e-b5442380aba8"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("abb83d3b-053d-45d7-a157-d3263a10aa57"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("de9132cb-998e-404a-9763-93f96d34a6a3"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("cf7bcf68-6995-49fc-b551-e49fa886a853"));
            NumberOfProcedure = (ITTTextBox)AddControl(new Guid("02a2c7ba-3101-40c5-a877-f4403f925309"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("289c3ff0-cecd-446b-aa8d-e47f6b34529d"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("40c6396f-4ec4-484d-9024-a166c178a483"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("3ef24a18-9789-4fd7-b7e1-96cb894986c2"));
            labelBookNumber = (ITTLabel)AddControl(new Guid("68f3efde-b324-4f59-8a10-e01a3fea1bdf"));
            ReportNo = (ITTTextBox)AddControl(new Guid("092e07eb-a36e-4545-b80b-8be92d3e5f14"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("1e615b93-7055-4521-971e-9ac10bb6add7"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("3d01c3d9-0b93-44e1-9d08-e5195834f02a"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("18d2c247-4ba4-492b-b2be-036af321db8f"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("1879df99-ae09-48dc-b956-0fbba5e035dc"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("fd66c532-b6ce-4d12-a802-dc02331a723e"));
            Adres = (ITTTextBox)AddControl(new Guid("a2a02bb2-5d7d-4190-b9fa-bea84152e027"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("e778a85b-17de-4f7e-baa4-4d765d617020"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("023db97a-1509-4c24-924c-450b49d39b25"));
            labelFatherName = (ITTLabel)AddControl(new Guid("4c56cb55-22ac-441e-80e4-e58b678af416"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("bbb57d18-6df9-4593-86db-2d38428d58a1"));
            FatherName = (ITTTextBox)AddControl(new Guid("683f2428-c80c-4dcc-9d4e-1b7014e38582"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("8ee31bc3-4566-4ec7-80a4-27c4df6a4711"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("7e33ac3b-3982-4d49-bbd2-170fc25b2e2f"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("8f8a8e27-b7a0-47e5-9d30-54b78583c4ec"));
            labelRelationship = (ITTLabel)AddControl(new Guid("4fd45597-b13f-4d5d-a16e-50d9c9bd5c83"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("2d32a2d1-21f0-4ea1-b861-44e664dd64e7"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("8e8e8fcf-8660-48d0-adf3-83c41db4f1da"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("b08ad499-041b-461e-a3db-681fc6820e0e"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("b297bdd7-19d8-45cf-b57b-c08f7b330a6e"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("46d8c0a3-2506-48fc-83e1-f934f4be7a06"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("a48efcca-4882-4f18-ad81-a76db21d5a8e"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("0779c0b7-183a-42b0-b82f-375dffe73961"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("7ccff102-45e0-4bb5-9b1e-4bcc9b2c802a"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("de69fd62-ea54-43b7-b7bf-40899e78d271"));
            tttextboxTCNo = (ITTTextBox)AddControl(new Guid("8dd238d2-4edb-4503-9746-c8c28628738d"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("7da4a242-e809-4d6a-89aa-e68ee0b61619"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("6497495c-92d2-47ea-8659-7777ab39377c"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("792d89f3-f52a-4448-bf31-5e06b831b108"));
            labelBirlik = (ITTLabel)AddControl(new Guid("c158497d-5e45-4fe1-824a-7a691f589cd6"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("bdb44255-6aab-4ee6-bb73-03542bc6608f"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("cbf59cb3-b836-4fe9-a620-b83346f0b59b"));
            Rank = (ITTObjectListBox)AddControl(new Guid("541bb3fe-76ae-4594-8e68-7095f78fc856"));
            labelRank = (ITTLabel)AddControl(new Guid("84001d42-b683-4fd2-b7c7-4f887ecaafda"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("39a6fd89-6df3-4fe2-bad0-1ad008f50098"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("0f209e2d-a83d-4a65-b4d3-6de521ec695e"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("33f14bcf-ba37-4ca2-aa18-b9eff775b4ad"));
            tttabpageDecision = (ITTTabPage)AddControl(new Guid("f865bf19-4152-4d83-a13e-1c03a5532207"));
            tttabpagePRV = (ITTTabPage)AddControl(new Guid("e0cecec2-168d-463d-b516-77dcf50d68b6"));
            base.InitializeControls();
        }

        public ReportOutputForm() : base("HEALTHCOMMITTEE", "ReportOutputForm")
        {
        }

        protected ReportOutputForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}