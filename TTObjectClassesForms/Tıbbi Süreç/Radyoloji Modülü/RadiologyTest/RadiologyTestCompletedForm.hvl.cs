
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
    /// Radyoloji Test Sonuç Formu
    /// </summary>
    public partial class RadiologyTestCompletedForm : RadiologyTestBaseForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
        }

        protected ITTTabControl TabPageInfo;
        protected ITTTabPage tttabpage1;
        protected ITTRichTextBoxControl rtfReport;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox RepeatReason;
        protected ITTTabPage tttabpage2;
        protected ITTGrid Materials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTTabPage TabPageHidden;
        protected ITTTextBox Description;
        protected ITTObjectListBox cityOfBirth;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel9;
        protected ITTEnumComboBox encboSex;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel17;
        protected ITTTextBox TestTechnicianNote;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel5;
        protected ITTTextBox OwnerType;
        protected ITTDateTimePicker PatientBirthDate;
        protected ITTObjectListBox ApprovedBy;
        protected ITTObjectListBox Deparment;
        protected ITTLabel ttlabel19;
        protected ITTTextBox tttextbox2;
        protected ITTObjectListBox Equipment;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ReportedBy;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker TestDate;
        protected ITTTabPage tttabpage3;
        protected ITTGrid SurgeryDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOffer;
        protected ITTTextBoxColumn txtBarcode;
        protected ITTTextBoxColumn txtKesinlesenMiktar;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel15;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTLabel ttlabel16;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tabAnamnez;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTabPage tabDescription;
        protected ITTTextBox CommonDescription;
        protected ITTTabPage tabAdditionalRequest;
        protected ITTTextBox tttextbox1;
        protected ITTButton cmdImage;
        override protected void InitializeControls()
        {
            TabPageInfo = (ITTTabControl)AddControl(new Guid("81b47ded-cef7-4a94-a85d-b401dae8e842"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("f9dd8489-387e-4209-a905-e3c546278768"));
            rtfReport = (ITTRichTextBoxControl)AddControl(new Guid("508ace3e-a2a9-4184-8d80-f71fa92b3d39"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("63a15a1a-a34f-449e-8ab1-8004157f8154"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e150c056-ec36-42b1-9245-c39efeb7d05f"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("164dabbb-8a84-4ae7-86d3-d69303af9b58"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e312b652-42d3-40d3-9f01-55697e929b1b"));
            RepeatReason = (ITTObjectListBox)AddControl(new Guid("e18ab2bb-9010-43d3-9169-e92ae570495a"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("f9b2047f-c80b-4b54-a3fb-cab8a1242ccb"));
            Materials = (ITTGrid)AddControl(new Guid("d1015dff-bd0f-4488-aed7-05b96ba20ccf"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a2f23d6e-8b84-4e3f-9ba6-11882650084e"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("c6c29cec-f668-41bc-aa56-05ef7f841193"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("1d194f71-4363-426f-b6dc-00c8abf2ed8d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2edc0360-e663-4e82-bfac-c5680cfdd344"));
            TabPageHidden = (ITTTabPage)AddControl(new Guid("7be3bb2b-06d1-4363-83b0-9623b1bb0c52"));
            Description = (ITTTextBox)AddControl(new Guid("00e6d2c2-aeb8-444d-9584-f1ee25ad7801"));
            cityOfBirth = (ITTObjectListBox)AddControl(new Guid("816f07ce-08cb-473b-98d2-29f6f509d3bf"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("922c83b3-187a-4b9c-b205-da8658bb96e0"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("390f2008-8cec-49b1-a2c1-925450d93599"));
            encboSex = (ITTEnumComboBox)AddControl(new Guid("ddecafaf-b42b-4237-90df-6c6cc2108e49"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("cf65b914-315f-4426-9e2b-29bf6448a82f"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("9cf72d0d-a5c4-4d08-9375-957f367fa44f"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("fa432f0a-6599-47ec-b783-f6d5ef68eeef"));
            TestTechnicianNote = (ITTTextBox)AddControl(new Guid("2d8d7072-b6b2-4a04-946a-de9df3eb21f5"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("2609833b-0d91-4e2c-b8ea-d6bc200248a3"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("c03f5150-8a7c-4b5b-b184-6b773e6d541b"));
            OwnerType = (ITTTextBox)AddControl(new Guid("6c48169f-8127-4a64-a852-df71449beb0a"));
            PatientBirthDate = (ITTDateTimePicker)AddControl(new Guid("a4229deb-5a17-4c8f-a7bc-5024640884e2"));
            ApprovedBy = (ITTObjectListBox)AddControl(new Guid("d5a5839d-7267-4616-b936-a496fe46354e"));
            Deparment = (ITTObjectListBox)AddControl(new Guid("c6c82fba-9e9f-46a6-90ac-fe20e27249d7"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("ce242dee-74ec-4adb-b573-20581f8bef41"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("0ed6552e-4f69-46e8-acc7-126cf699a3e4"));
            Equipment = (ITTObjectListBox)AddControl(new Guid("3d49e2e3-f007-4e8d-9f4d-d998ebfe321c"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("b502e914-1ebe-4535-b08c-51def9978036"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("1109ada9-efbb-4860-a21d-307ed5830064"));
            ReportedBy = (ITTObjectListBox)AddControl(new Guid("9453dd79-63af-46e4-bba9-6e9ded5d699a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7f15f54b-f68a-4cca-8543-04cbffe9f11a"));
            TestDate = (ITTDateTimePicker)AddControl(new Guid("efbe5d4e-129d-4995-b398-831061da74ca"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("03c29e12-1ab9-48fa-a95d-b065116fdebf"));
            SurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("c08b4693-d924-475c-84b1-4166317de989"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("8533f5f4-e9d6-4cac-aa3a-8b3d5342b5e6"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("03aa7560-f92f-47a8-a12b-3a209641abb6"));
            txtKesinlesenMiktar = (ITTTextBoxColumn)AddControl(new Guid("dc9a275a-6acd-458e-939f-fd1a0f0ddd46"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("8f66ec56-a5bf-4988-be64-07133e07ecc5"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c3555b5b-3c7e-4279-a032-1530f0ca13e8"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("6fd4f0eb-bd3c-4fac-b1da-7391d03f3fea"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("44ec7bfb-b1c2-435a-b8c6-0276d9288deb"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("c1d4e577-821b-4c67-a8ab-5f8aef25eb4a"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("f1ba071c-f24f-4287-a4c0-4409d0009206"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("253ed72d-6e65-4860-92a9-05cc03258786"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("033926b9-2cb1-42a8-a510-e3dc4e1d6d06"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("dc1767bd-d931-4ad0-8ccf-05d6d688a43b"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("a28cf87b-13c1-4875-9937-f4b7064d0737"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("a9c9bd36-69f5-472b-8f50-2db7b295b49c"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("3c2886ce-24ab-48a8-bd12-587a2bf6ec5f"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("29536544-7752-43ac-a721-da7195d4bbf9"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("6aa90400-0d15-4364-903d-d54f44cde817"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("54cb07b1-aadc-4f8e-b17b-570e4158ac6f"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("fa3e13a5-3c1f-4c7c-b45c-2d07678eec27"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("7b3e746c-1ab5-40f2-b44c-e69492cea504"));
            tabAnamnez = (ITTTabPage)AddControl(new Guid("697e0a77-1698-4955-8818-2911ba91255a"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("80a4f791-ddfc-4664-9e62-3da1f397dd52"));
            tabDescription = (ITTTabPage)AddControl(new Guid("0122f2f0-0dd4-47ab-a265-415d5e6e7386"));
            CommonDescription = (ITTTextBox)AddControl(new Guid("69504cb9-dfe5-42a6-a30e-9bcff763e514"));
            tabAdditionalRequest = (ITTTabPage)AddControl(new Guid("3ad4b71a-9c89-4644-a1e4-31ca018256f7"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2adf1588-6b86-4772-9ba2-7b6fcdcd35bd"));
            cmdImage = (ITTButton)AddControl(new Guid("b4bfc000-1577-497b-8638-d2821419042c"));
            base.InitializeControls();
        }

        public RadiologyTestCompletedForm() : base("RADIOLOGYTEST", "RadiologyTestCompletedForm")
        {
        }

        protected RadiologyTestCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}