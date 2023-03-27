
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
    /// Oral Diagnoz ve Radyoloji
    /// </summary>
    public partial class DentalExaminationForm : BaseDentalEpisodeActionForm
    {
    /// <summary>
    /// Oral Diagnoz ve Radyoloji İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DentalExamination _DentalExamination
        {
            get { return (TTObjectClasses.DentalExamination)_ttObject; }
        }

        protected ITTCheckBox ch3;
        protected ITTCheckBox ch4;
        protected ITTCheckBox ch6;
        protected ITTCheckBox ch5;
        protected ITTCheckBox ch7;
        protected ITTCheckBox ch2;
        protected ITTCheckBox ch1;
        protected ITTLabel labelRequesterDoctor;
        protected ITTObjectListBox RequesterDoctor;
        protected ITTObjectListBox MasterResource;
        protected ITTButton ttbutton3;
        protected ITTGrid DentalProcessNew;
        protected ITTListBoxColumn ProdecureObject;
        protected ITTButton ttbuttonPatoloji;
        protected ITTButton ttbuttonBiyokimya;
        protected ITTButton ttbuttonMikrobiyoloji;
        protected ITTButton ttbuttonRadyoloji;
        protected ITTButton ttbuttonTemizle;
        protected ITTButton ttbuttonPrescription;
        protected ITTButton ttbuttonTopluIslemTamamla;
        protected ITTListView ttlistviewDentalSpecialityList;
        protected ITTButton ttButtonHizmetKontrol;
        protected ITTButton ttButtonOrtodontiForm;
        protected ITTCheckBox ttChkBoxGeneralAnesthesia;
        protected ITTLabel labelTriajCode;
        protected ITTEnumComboBox cmbTriajCode;
        protected ITTTabControl TabExaminationType;
        protected ITTTabPage Examination;
        protected ITTRichTextBoxControl DentalExaminationFile1;
        protected ITTTabPage GridDiagnosisEntry;
        protected ITTGrid SecDiagnosisGrid;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTEnumComboBoxColumn SecToothNum;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTabPage ProcedureEntry;
        protected ITTGrid DentalProsthesis;
        protected ITTButtonColumn Mustehaklik;
        protected ITTCheckBoxColumn columnHastaOdeme;
        protected ITTCheckBoxColumn columnHizmetKaydedildi;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn ProcedureDoctor;
        protected ITTEnumComboBoxColumn ProsthesisToothNum;
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTCheckBoxColumn Anomali;
        protected ITTListBoxColumn OzelDurum;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTextBoxColumn PatientPrice;
        protected ITTListBoxColumn TeethMasterResource;
        protected ITTTabPage DisKonsultasyonIstek;
        protected ITTGrid DentalConsultation;
        protected ITTListBoxColumn KonsultasyonIstenenBirim;
        protected ITTTextBoxColumn KonsultasyonIstekAciklamasi;
        protected ITTTextBoxColumn SelectedToothNumbers;
        protected ITTTabPage TreatmentMatEnrty;
        protected ITTGrid UsedMaterials;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTButtonColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn Note;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTListBoxColumn UsedMaterials_OzelDurum;
        protected ITTTabPage MedulaBilgileri;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MedulaDisBilgileriTab;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelDrAnesteziTescilNo;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn cokluOzelDurumColumn;
        protected ITTLabel labelOzelDurum;
        protected ITTTabPage OnerilenIslemler;
        protected ITTGrid ttgrid3;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTCheckBoxColumn ttcheckboxcolumn1;
        protected ITTListBoxColumn SUGGESTEDPROSTHESISPROCEDURE;
        protected ITTEnumComboBoxColumn CurrentState;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn1;
        protected ITTListBoxColumn datagridviewcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid DiagnosisGrid;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage OlduExaminations;
        protected ITTGrid OldDentalExaminationsGrid;
        protected ITTDateTimePickerColumn ExaminationDateTime;
        protected ITTTextBoxColumn ExaminationIndication;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox TriajColor;
        protected ITTDateTimePicker ProcessTime;
        protected ITTCheckBox Emergency;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelProcessTime;
        protected ITTObjectListBox Doctor;
        protected ITTButton btnNewTreatmentDischarge;
        protected ITTButton ttButtonTaahhut;
        override protected void InitializeControls()
        {
            ch3 = (ITTCheckBox)AddControl(new Guid("acc18ad8-97ba-49f0-ac94-b169f71badcb"));
            ch4 = (ITTCheckBox)AddControl(new Guid("3a447e2b-7748-4246-a838-d00b2845073f"));
            ch6 = (ITTCheckBox)AddControl(new Guid("77bcc8c6-33dd-4430-8a1d-b2483cc2b430"));
            ch5 = (ITTCheckBox)AddControl(new Guid("adfd441c-c1c8-4dd2-ac88-c35d9fe5cb64"));
            ch7 = (ITTCheckBox)AddControl(new Guid("a03efbb6-6c10-40d5-8683-dfdac6f9e262"));
            ch2 = (ITTCheckBox)AddControl(new Guid("36a057c7-246f-4188-bb81-770075d27556"));
            ch1 = (ITTCheckBox)AddControl(new Guid("55986517-e38f-4f5e-a104-359e09f26227"));
            labelRequesterDoctor = (ITTLabel)AddControl(new Guid("331bf10e-da69-4278-a3ad-1eea61ff174f"));
            RequesterDoctor = (ITTObjectListBox)AddControl(new Guid("809d9aa9-ab34-4954-be7a-0a28eb1ac9a3"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("c4c4011e-3f4b-4f31-aefa-fc393375555b"));
            ttbutton3 = (ITTButton)AddControl(new Guid("3fd4f54d-5b84-4446-99a1-c4e5b3056bea"));
            DentalProcessNew = (ITTGrid)AddControl(new Guid("8b10cb09-525f-4e9e-a7f2-be46a203dc3a"));
            ProdecureObject = (ITTListBoxColumn)AddControl(new Guid("3b718569-3af9-41e4-9afb-ccd9cdcc58d7"));
            ttbuttonPatoloji = (ITTButton)AddControl(new Guid("b584cd62-83eb-435b-a26e-3b61876ff5a5"));
            ttbuttonBiyokimya = (ITTButton)AddControl(new Guid("c3bdf2fb-31c6-4b45-9358-cb8a7d7d29eb"));
            ttbuttonMikrobiyoloji = (ITTButton)AddControl(new Guid("5b0bcac8-c8ac-49d8-af1c-fe222a4ae78f"));
            ttbuttonRadyoloji = (ITTButton)AddControl(new Guid("93c17f32-4ab6-414c-b586-162031d3089c"));
            ttbuttonTemizle = (ITTButton)AddControl(new Guid("7bc372e7-dc11-4b5c-a4de-ca5842ed82f6"));
            ttbuttonPrescription = (ITTButton)AddControl(new Guid("3883c6c6-bb4e-4c5a-8614-aa9b171f3243"));
            ttbuttonTopluIslemTamamla = (ITTButton)AddControl(new Guid("e10608b6-9096-4b95-89b9-7158c66cf1c7"));
            ttlistviewDentalSpecialityList = (ITTListView)AddControl(new Guid("fb30d9fb-a4fe-4617-90d3-d40cee81e224"));
            ttButtonHizmetKontrol = (ITTButton)AddControl(new Guid("127db828-fee4-4c8e-8986-10a169aa9731"));
            ttButtonOrtodontiForm = (ITTButton)AddControl(new Guid("07192244-eccd-4044-8894-b5b0a49be365"));
            ttChkBoxGeneralAnesthesia = (ITTCheckBox)AddControl(new Guid("03aaa166-5753-4caa-a5d1-05f16254c722"));
            labelTriajCode = (ITTLabel)AddControl(new Guid("79a307ab-b896-4b05-b7cb-aab586f9b00e"));
            cmbTriajCode = (ITTEnumComboBox)AddControl(new Guid("0c0c8363-e084-4740-91de-234da74d5c66"));
            TabExaminationType = (ITTTabControl)AddControl(new Guid("37b7b116-9c76-4655-88a4-249a0c738892"));
            Examination = (ITTTabPage)AddControl(new Guid("88480b26-f505-4c40-b3a1-5eeaf7c84eba"));
            DentalExaminationFile1 = (ITTRichTextBoxControl)AddControl(new Guid("44e08425-3159-4e00-a182-af5b62444baf"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("c684c5b5-d11f-490c-82f8-4329279324e7"));
            SecDiagnosisGrid = (ITTGrid)AddControl(new Guid("f06a19ff-68f6-4c08-befa-70c5222b237d"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("be7c458e-187a-493a-a4bc-3f81afef0ee8"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("2116f0ff-ceb8-4257-8b7f-c6a569f1bbfe"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("7ab461da-aed7-4cd1-8214-a333e67cd3bc"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1e21f6af-b362-4dfd-b420-d681ea6d27a8"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("5f086e9a-7056-41fb-88a6-a3f4a29758ac"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("3b4dfdfb-189b-4761-83e0-16fde4eb2669"));
            ProcedureEntry = (ITTTabPage)AddControl(new Guid("2ebb66c4-914f-4444-b615-eac266f941dc"));
            DentalProsthesis = (ITTGrid)AddControl(new Guid("3c905a76-6405-4a1b-9611-5da5853c9ffb"));
            Mustehaklik = (ITTButtonColumn)AddControl(new Guid("df8e1e46-8bf6-407d-80f4-f3ee1b5e7553"));
            columnHastaOdeme = (ITTCheckBoxColumn)AddControl(new Guid("b7df7d7a-04e5-4274-9d0b-459352874560"));
            columnHizmetKaydedildi = (ITTCheckBoxColumn)AddControl(new Guid("fd149fea-e60a-46d1-826e-5acc594a6326"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("9f4b85d3-49ed-4c23-ac1e-98df0963240b"));
            ProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("bad5f3f3-f6dd-43fa-9394-4ea0aa532170"));
            ProsthesisToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("fba69754-9710-4f36-a1d8-daa64c743648"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("736229c3-70bb-4181-a9a4-a65fb375aa14"));
            Anomali = (ITTCheckBoxColumn)AddControl(new Guid("cf36c3ad-f19f-49a4-a1d4-2e98002b7565"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("47f4fb9b-7a6c-4190-ae85-50d35a087cbe"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("b7dae5f7-505b-4a12-a0d3-c0c83c9a7c21"));
            PatientPrice = (ITTTextBoxColumn)AddControl(new Guid("3d6a58bc-c425-4978-9003-6f1836539175"));
            TeethMasterResource = (ITTListBoxColumn)AddControl(new Guid("81d3c2ab-440f-4d71-a555-f5898fa41afa"));
            DisKonsultasyonIstek = (ITTTabPage)AddControl(new Guid("d52de854-5fef-41c9-8980-1cf7e082b525"));
            DentalConsultation = (ITTGrid)AddControl(new Guid("d158daf5-8f69-43a3-b2e1-b1bb88429e90"));
            KonsultasyonIstenenBirim = (ITTListBoxColumn)AddControl(new Guid("0c5e8f4b-bc9d-42e4-a186-054e05ab0472"));
            KonsultasyonIstekAciklamasi = (ITTTextBoxColumn)AddControl(new Guid("f2049914-9988-4bea-a15e-935254a08f3b"));
            SelectedToothNumbers = (ITTTextBoxColumn)AddControl(new Guid("0754b837-4dbb-4122-a147-6bb7ada1edef"));
            TreatmentMatEnrty = (ITTTabPage)AddControl(new Guid("31ef7012-422d-4c34-87d9-ce8a959d6ce4"));
            UsedMaterials = (ITTGrid)AddControl(new Guid("6f830453-2de0-4652-bd28-99016741e6b7"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("8c52e8d3-79e0-4e0d-9158-2538b9a35a77"));
            Material = (ITTListBoxColumn)AddControl(new Guid("65923240-0e70-4b57-b5e6-e4dc2f76f668"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("41fc1523-5ec9-415f-ae65-c2c1f9152d27"));
            DistributionType = (ITTButtonColumn)AddControl(new Guid("333cd265-8e16-4549-a6a3-65748b93f3ac"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("43996651-d767-4d5c-9f3b-1070b6ee17c5"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("a5e010e1-f167-40ad-ac76-1873fc5d5c12"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("7135c150-e98f-486d-9e9c-cd5b2e9e33fd"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("e6d82c73-dbbe-443e-9bb5-10c6e1e6ea7d"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("97b20ec7-94dd-49f5-a99f-d2dfa8922812"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("2a4b3313-008e-4f9e-a34f-4653a2d5b175"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("fe6f2511-4931-4030-bd5a-3715a3a50c7a"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("82a30019-15ba-461b-9063-330118f6a1d9"));
            UsedMaterials_OzelDurum = (ITTListBoxColumn)AddControl(new Guid("1ec46f59-79ce-4e6e-9682-7ba86339ee87"));
            MedulaBilgileri = (ITTTabPage)AddControl(new Guid("647b8128-c1d7-40ce-86f7-0f6058d81c0f"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("dd2f9441-075d-4d17-aa48-014e0f6fab23"));
            MedulaDisBilgileriTab = (ITTTabPage)AddControl(new Guid("89aaaaa6-fcfd-494a-b4be-8b649bfdb04f"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("a303e5fd-ac83-442e-a528-80766396cf46"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("759f83e6-c8ad-4760-a0e1-caf7cef6e8ca"));
            labelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("d6abdf5f-f702-4f7f-a56f-60c53f896e94"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("b5adc351-8190-41f7-ae77-a6d4254dff07"));
            cokluOzelDurumColumn = (ITTListBoxColumn)AddControl(new Guid("6e5b3588-f093-4738-b09a-040975895d37"));
            labelOzelDurum = (ITTLabel)AddControl(new Guid("0fddd094-f664-4f4d-8bcd-b9047d2742cb"));
            OnerilenIslemler = (ITTTabPage)AddControl(new Guid("2d703f3c-dca2-4ff0-9e3e-b5226fab2cac"));
            ttgrid3 = (ITTGrid)AddControl(new Guid("d36a52b8-a589-4116-989a-ecc43ae99613"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("a177e8d6-c167-45ef-8bf7-b87d68b72d19"));
            ttcheckboxcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("714d1782-4b7d-4601-9531-1036341f4171"));
            SUGGESTEDPROSTHESISPROCEDURE = (ITTListBoxColumn)AddControl(new Guid("957634f4-759e-480c-b81b-bcf527d8236a"));
            CurrentState = (ITTEnumComboBoxColumn)AddControl(new Guid("7bdc8141-804d-4205-ae37-d18d43c7967d"));
            ttenumcomboboxcolumn1 = (ITTEnumComboBoxColumn)AddControl(new Guid("32026b32-df1a-480c-b16f-eed5a3869775"));
            datagridviewcolumn1 = (ITTListBoxColumn)AddControl(new Guid("c5eb41a7-82da-4d56-a036-42a002704a6b"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("f772882f-236b-4365-8a4e-4024c0df028c"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("1cfaaeb0-e228-4842-b1a1-400fde08b123"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("06b062d7-6d47-4cef-be52-78cef4c0c523"));
            DiagnosisGrid = (ITTGrid)AddControl(new Guid("2f3d6f7b-6ed7-48a8-860c-d9643f8d08a0"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("4047842a-02a9-4056-a00f-cc1e8c16ee50"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("4417cd78-3a2e-46f7-8d54-bb9b2c7b78ab"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("de955443-4f3c-4591-8522-5c0f7e6f8f33"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("bab61402-921d-4f0d-b626-b87d71b7e18e"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("b1ea205a-7676-4418-9f6b-157865d102bc"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d2e9ac10-9c10-4d4a-aec6-deed70b65a04"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("0b81551c-55e0-4b05-8391-1a6828271aa8"));
            OlduExaminations = (ITTTabPage)AddControl(new Guid("2f4c81e2-dffa-42af-81ff-f493c22b630f"));
            OldDentalExaminationsGrid = (ITTGrid)AddControl(new Guid("92222376-50e9-4095-95ef-0c485a4efdcd"));
            ExaminationDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("6535fd99-cf9d-4ea9-adcc-5205ff5a6efc"));
            ExaminationIndication = (ITTTextBoxColumn)AddControl(new Guid("7c8aec00-23ab-4ed4-abd8-4e59152bd25e"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("006bd290-26f5-4592-9afc-3ae593457bfd"));
            TriajColor = (ITTTextBox)AddControl(new Guid("dfac832c-4a59-4cde-908d-e062b3f41733"));
            ProcessTime = (ITTDateTimePicker)AddControl(new Guid("57472cf0-7df9-47cb-b67f-1b315b7d1724"));
            Emergency = (ITTCheckBox)AddControl(new Guid("0e52431a-92d9-48b9-b160-372facb5790c"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("9a4f68ab-a391-485c-bff5-97c2233a2455"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("b6745431-c286-4717-bfd8-a5f6ef1d8196"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("2ec48bd0-fbdf-4e97-8338-c97822c5e3e1"));
            Doctor = (ITTObjectListBox)AddControl(new Guid("f845a197-88c4-4fe1-9a4d-db71e62d7db7"));
            btnNewTreatmentDischarge = (ITTButton)AddControl(new Guid("e931ef7a-1f3d-44dc-9f40-f88a3aa9ccf0"));
            ttButtonTaahhut = (ITTButton)AddControl(new Guid("015e72a5-1b8c-4e2d-804d-dda719d89b3e"));
            base.InitializeControls();
        }

        public DentalExaminationForm() : base("DENTALEXAMINATION", "DentalExaminationForm")
        {
        }

        protected DentalExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}