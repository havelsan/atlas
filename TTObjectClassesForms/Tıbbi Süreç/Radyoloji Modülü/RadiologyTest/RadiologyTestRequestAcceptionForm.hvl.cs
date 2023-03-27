
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
    /// Radyoloji Tetkik İnceleme Formu
    /// </summary>
    public partial class RadiologyTestRequestAcceptionForm : RadiologyTestBaseForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
        }

        protected ITTLabel labelContrastType;
        protected ITTEnumComboBox ContrastType;
        protected ITTCheckBox GunuBirlikTakip;
        protected ITTCheckBox ttBarcodePreviewCheck;
        protected ITTTextBox RequestNo;
        protected ITTButton cmdPrintRequestNo;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage tttabpage1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox Equipment;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox Deparment;
        protected ITTLabel ttlabel1;
        protected ITTTextBox DisTaahhutNo;
        protected ITTTextBox TestTechnicianNote;
        protected ITTEnumComboBox cmbToothNumber;
        protected ITTLabel labelDisTaahhutNo;
        protected ITTButton ttbuttonToothSchema;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox cmbDentalPosition;
        protected ITTLabel lblToothNumber;
        protected ITTTabPage tabMaterial;
        protected ITTGrid Materials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTabPage MedulaTakipBilgileriTabPage;
        protected ITTListDefComboBox takipTipi;
        protected ITTLabel labeltakipTipi;
        protected ITTLabel labeltedaviTipi;
        protected ITTListDefComboBox tedaviTipi;
        protected ITTTextBox OwnerType;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox CommonDescription;
        protected ITTTextBox PREDIAGNOSIS;
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
        protected ITTLabel lblAge;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel7;
        protected ITTLabel lblRequestNo;
        protected ITTButton ttPrintRequestBarcode;
        protected ITTCheckBox Acil;
        override protected void InitializeControls()
        {
            labelContrastType = (ITTLabel)AddControl(new Guid("3090170a-36a0-4417-a813-dd9db45e1d9c"));
            ContrastType = (ITTEnumComboBox)AddControl(new Guid("ab0385fe-bc1a-4e9a-891a-0d63292db045"));
            GunuBirlikTakip = (ITTCheckBox)AddControl(new Guid("627fad7f-5feb-44fb-bfed-a20c72c29e73"));
            ttBarcodePreviewCheck = (ITTCheckBox)AddControl(new Guid("ea1b0c1e-d000-4f00-ac91-89d0d37605e5"));
            RequestNo = (ITTTextBox)AddControl(new Guid("356f6d55-4bed-4a23-8e70-066bf2636449"));
            cmdPrintRequestNo = (ITTButton)AddControl(new Guid("f637517c-20a1-4de7-8fb2-2179428d8572"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("9bc6fc7f-3fad-44cb-af11-1ca2cc5456d8"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("bb7eb6f1-ed00-4914-b7e6-a7e71fb78e89"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("52eda176-a79c-4b1c-9927-194cc7a310ac"));
            Description = (ITTTextBox)AddControl(new Guid("ead63cdc-68e5-4d7d-8686-8db9f8eb3d98"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("67cc0c91-6110-4d25-9325-0198c1bb1c15"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("08cdc4ac-31b0-4e5e-842a-9197852914e3"));
            Equipment = (ITTObjectListBox)AddControl(new Guid("b1ec1f6a-54bd-49cf-94d6-a3e27e10e60c"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("05770751-9663-4410-8e3e-f9cf2c4e7655"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("165f41c9-9145-43f1-bc22-8bff4e792386"));
            Deparment = (ITTObjectListBox)AddControl(new Guid("a85b97ca-f0a5-4926-ab75-95e90df17c2a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f45dbbee-aab2-472c-966b-5762af7d290a"));
            DisTaahhutNo = (ITTTextBox)AddControl(new Guid("5708a1eb-c185-4bb1-9988-a3c4f1c668b2"));
            TestTechnicianNote = (ITTTextBox)AddControl(new Guid("c4154a8c-6b82-4a69-9176-878814018d3a"));
            cmbToothNumber = (ITTEnumComboBox)AddControl(new Guid("c3f9a41f-3afa-4966-a491-9eee36419ccf"));
            labelDisTaahhutNo = (ITTLabel)AddControl(new Guid("d0d33836-b3b3-4f99-ab90-17491d72f256"));
            ttbuttonToothSchema = (ITTButton)AddControl(new Guid("f0dd8335-0717-4e21-bd4c-a7ba6303a010"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("92d90d87-5c0c-46f6-acd4-08757ac357a6"));
            cmbDentalPosition = (ITTEnumComboBox)AddControl(new Guid("3a79062a-3a99-42b1-8f8c-29abeda4fc79"));
            lblToothNumber = (ITTLabel)AddControl(new Guid("f6ca1064-a6bb-4914-8c16-21e6b8d42569"));
            tabMaterial = (ITTTabPage)AddControl(new Guid("0024a131-e757-4754-904d-c8d8d50c8b06"));
            Materials = (ITTGrid)AddControl(new Guid("f30af8d8-5bee-4c36-903c-95a8707f9766"));
            Material = (ITTListBoxColumn)AddControl(new Guid("f88fa868-25a3-4785-bfc3-3d74bb149252"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("00c6573c-2d11-4015-97de-f340d9e56e6c"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("ef46d277-ca0e-40ba-82d0-b955900d26f7"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("1cf3c441-98a4-4e8d-9679-b66897d72102"));
            MedulaTakipBilgileriTabPage = (ITTTabPage)AddControl(new Guid("3f7e7dcd-93d7-4cc3-9230-7561ed43f347"));
            takipTipi = (ITTListDefComboBox)AddControl(new Guid("e3c537f8-5ba9-4f54-843f-2f68bb35a2c9"));
            labeltakipTipi = (ITTLabel)AddControl(new Guid("8c1b7163-340c-43bd-9519-24fa1aa53fd7"));
            labeltedaviTipi = (ITTLabel)AddControl(new Guid("fffe609f-24f0-4d52-9a85-a16d7c92af32"));
            tedaviTipi = (ITTListDefComboBox)AddControl(new Guid("c54473c5-44c1-4cd1-8956-812d4271a7b4"));
            OwnerType = (ITTTextBox)AddControl(new Guid("19f655ce-617f-49ba-b07c-a96a669e4238"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("5a9e2205-4879-4286-9156-c34f8cfd89b9"));
            CommonDescription = (ITTTextBox)AddControl(new Guid("6b29b195-2781-4a84-97ae-1d1cd103caa1"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("a67bd5b9-d0ff-4484-b1c0-a29118f1c55e"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("8ab1f989-cebc-4431-8d79-ba23c3d6c3da"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("470f097b-b5f4-4b10-970b-58252eb5bb75"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("ae8ab151-9a1f-41c0-a7d3-2f984e9226ed"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("f84cf9e7-3159-408e-83c1-b3284f6afc8d"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("18d4cfca-5f20-4939-b6d2-750406a9f15e"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("886bb8ae-9066-4a23-a420-bcc45c142faa"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("14d2e65d-3ff2-4820-9c8f-74e7517ca2e0"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("74459ea3-19a6-4aad-be57-4571a53a52ad"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("019ff919-1b39-4c8d-b506-932b3fb435ae"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("851c9360-6906-4a0f-b0de-d71b4baaf61b"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("cd4a3226-126a-41f8-aee2-f89ba8f25a1a"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("0afff315-e5c9-4fc1-abf2-882147e3c042"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("a387f3f6-b016-47f4-a04f-be3ad9a9eff1"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("fe92eb0c-0b8a-4d8f-bce4-b4704d03e102"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("4d1e2578-b335-4168-8734-5313a6304c8c"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("5fb3b5f1-33b4-4acb-bd6d-4f42b7dbce4a"));
            lblAge = (ITTLabel)AddControl(new Guid("3b27e5ba-1cd1-4659-82c8-663e9922f38c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("60bfecbe-7331-404b-943f-81d1823d0a3b"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("dd013313-e7dd-4d8c-a1e4-37497042cf04"));
            lblRequestNo = (ITTLabel)AddControl(new Guid("e220acd4-ad52-4be1-9293-073c6d58daf9"));
            ttPrintRequestBarcode = (ITTButton)AddControl(new Guid("47435ac8-cf0c-42fb-a56e-cbf67112e00c"));
            Acil = (ITTCheckBox)AddControl(new Guid("158a41a9-e850-455e-8fab-67973b4318c1"));
            base.InitializeControls();
        }

        public RadiologyTestRequestAcceptionForm() : base("RADIOLOGYTEST", "RadiologyTestRequestAcceptionForm")
        {
        }

        protected RadiologyTestRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}