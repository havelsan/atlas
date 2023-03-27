
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
    /// Diş Tedavi İşlemi
    /// </summary>
    public partial class DentalTreatmentProcedureForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Diş Tedavi Prosedür
    /// </summary>
        protected TTObjectClasses.DentalTreatmentProcedure _DentalTreatmentProcedure
        {
            get { return (TTObjectClasses.DentalTreatmentProcedure)_ttObject; }
        }

        protected ITTCheckBox ttcheckboxGeneralAnesthesia;
        protected ITTEnumComboBox ToothNumber;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage GridDiagnosisEntry;
        protected ITTGrid SecDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTEnumComboBoxColumn SecToothNum;
        protected ITTEnumComboBoxColumn SecDentalPosition;
        protected ITTButtonColumn SecToothSchema;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTabPage EpisodeDiagnosisPage;
        protected ITTGrid EpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTextBox DefinitiontoTechnician;
        protected ITTTextBox Amount;
        protected ITTLabel labelDefinitiontoTechnician;
        protected ITTLabel labelDentalPosition;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelDentalTreatmentDescription;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelDepartment;
        protected ITTEnumComboBox DentalPosition;
        protected ITTObjectListBox TechnicalDepartment;
        protected ITTLabel labelDentalExaminationFile;
        protected ITTLabel labelAmount;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTObjectListBox DentalRequestType;
        protected ITTObjectListBox ProcedureObject;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel labelToothNumber;
        protected ITTLabel labelDentalRequestType;
        protected ITTLabel labelProcedure;
        protected ITTTabControl SubactionTab;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn MaterialAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn Note;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTListBoxColumn MalzemeBilgisi_OzelDurum;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTTabPage MedulaBilgileri;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTObjectListBox TTListBoxOzelDurum;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        protected ITTObjectListBox TTListBoxAyniFarkliKesi;
        protected ITTCheckBox Anomali;
        protected ITTLabel labelAyniFarkliKesi;
        protected ITTLabel labelOzelDurum;
        protected ITTLabel labelDrAnesteziTescilNo;
        protected ITTTextBox DisTaahhutNo;
        protected ITTLabel labelDisTaahhutNo;
        protected ITTTextBox DentalTreatmentDescription;
        protected ITTTextBox DentalExaminationFile;
        protected ITTCheckBox ttcheckbox1;
        protected ITTObjectListBox ProcedureDepartment;
        protected ITTLabel labelTechnicalDepartment;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTButton btnNewTreatmentDischarge;
        protected ITTButton ttbuttonToothSchema;
        override protected void InitializeControls()
        {
            ttcheckboxGeneralAnesthesia = (ITTCheckBox)AddControl(new Guid("6589981f-1080-425b-a1cb-09e0a38aeec4"));
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("3c9c6631-e3a4-4705-84c5-7e353e6aa5ae"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("d00a189f-7cca-4477-be57-447c04422909"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("9815310e-7f20-4de6-9f82-7c938801d1de"));
            SecDiagnosis = (ITTGrid)AddControl(new Guid("a52a62a0-2af8-4e31-b389-80898e85d392"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("8a6291e2-598b-49cd-aec0-5b04681868c9"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("6c9b7aee-9c16-4b97-9613-423a928f2dc2"));
            SecDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("af3e8015-ab3f-458c-9fef-c126ef2fe8a6"));
            SecToothSchema = (ITTButtonColumn)AddControl(new Guid("62b97370-db41-434f-b21d-3a6208dc75c4"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("516f8e59-19ff-466d-9b93-0672ce660e83"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("3107faec-43ef-412b-a6ef-99afe9fd4255"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("69462669-37e6-4c7d-a565-90e6a49a45fd"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("30fab5bd-43c6-4b40-a053-e56fc58ae0f2"));
            EpisodeDiagnosisPage = (ITTTabPage)AddControl(new Guid("c907beef-f5dc-4a0f-a587-57c7571641a7"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("aab05e00-c680-4c12-9511-7c0931e5ffa0"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("eb3ca756-2309-441a-b9f6-fca45b6acaa7"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("9ca5eea5-cbaf-47b5-b574-4721ba3e359b"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("3a814280-de02-4c0b-bff8-851377c40148"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("337263fc-375f-4be8-ad02-276473bfcc2f"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("19940f35-cf14-4676-9df7-d599dcf52196"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("20f0f3da-e869-4146-9199-06991c615d61"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("957c091b-10b5-4cb3-8cec-5853c0e91ba5"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9a23e86f-fa12-4aad-bd2d-4c6214a1949f"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("31ec2fba-a9f8-4649-b1b8-c62e0b58e4a0"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("ce359367-b09f-4a8f-a549-7af1f0ff3ff6"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("9c1385a4-36d3-45f3-ab73-f29362c5bd9c"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("a308d8cc-1b61-4aeb-a7bd-05b4182f7317"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("fa99919f-61b9-42c9-a337-45ecc4189ef8"));
            DefinitiontoTechnician = (ITTTextBox)AddControl(new Guid("34790e46-ebf7-46b7-a6a3-2e729279a548"));
            Amount = (ITTTextBox)AddControl(new Guid("952ef350-1373-4c52-866d-8f9d187d2a91"));
            labelDefinitiontoTechnician = (ITTLabel)AddControl(new Guid("95c2da4f-35f0-417c-a857-062a88a262a4"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("30898ff6-6daa-470f-adc1-1418883cbc5c"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("a7d190e9-7b76-408c-94c8-14cead415cbc"));
            labelDentalTreatmentDescription = (ITTLabel)AddControl(new Guid("2299ea60-9118-4107-bd54-1d80535c30a1"));
            labelActionDate = (ITTLabel)AddControl(new Guid("4d8c30e1-0816-49fa-bdab-2b7eb7fdb27f"));
            labelDepartment = (ITTLabel)AddControl(new Guid("71f61884-a791-4164-84ad-2f015bd50b7d"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("0a28ff91-ed5c-47be-86ec-327629515a3e"));
            TechnicalDepartment = (ITTObjectListBox)AddControl(new Guid("b88889b2-f951-41aa-bb40-4288da594de1"));
            labelDentalExaminationFile = (ITTLabel)AddControl(new Guid("969d6bad-75b5-4e36-9b58-524fbecff16a"));
            labelAmount = (ITTLabel)AddControl(new Guid("b12ef473-0a1f-4540-b7ac-527cda0ec553"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("73b3ce55-4a6b-44bb-9089-837e29cd4e52"));
            DentalRequestType = (ITTObjectListBox)AddControl(new Guid("e65037eb-4e94-43fc-be27-84a34e366e79"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("cda9f934-09d4-4e81-9375-8ce9947c2079"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("9980fa66-a650-48ab-9dba-9a1b96535115"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("689c77eb-c7c1-4eea-93f9-9e466fa2b154"));
            labelDentalRequestType = (ITTLabel)AddControl(new Guid("ed66e62f-3b6d-4cad-939b-a51cfb48bcb6"));
            labelProcedure = (ITTLabel)AddControl(new Guid("5003fe7d-cd35-43b7-8b14-abc962a7655c"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("fd953750-4737-426a-9bcc-bba62db83a6f"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("c4dfb088-f26b-4afa-8a79-5e31112322a8"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("47b7568f-4adc-4867-897d-6086649a5929"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("4fd67d6c-ce26-4fce-bc55-675da5f5215b"));
            Material = (ITTListBoxColumn)AddControl(new Guid("da03dac7-d3d0-4f99-ac16-8559b11a342f"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("a217de36-2325-4268-99c2-41d4e9265f3d"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("41a0d465-8a6e-41b2-993a-15851acd1a78"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("d2fecde3-8ecf-49ed-a6a9-3931dfefcf1e"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("226aab01-0e68-460a-ac73-3677add5eff9"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("50ab8eb5-5afa-4ee4-9a16-21990250c810"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("a69b27bd-7add-408e-ab19-87340b37a242"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("d2ce1da7-5961-4d7c-a04f-82b35b2f122c"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("52aa076d-4000-4706-aaee-deffce1acd5a"));
            MalzemeBilgisi_OzelDurum = (ITTListBoxColumn)AddControl(new Guid("4d2d1a0a-5a04-40bb-b9b0-e3494b3fc900"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("9361f16c-f031-4f86-b6dc-9e2a75f6e9ee"));
            MedulaBilgileri = (ITTTabPage)AddControl(new Guid("a2d00db5-c45b-4017-af03-c1fc293828aa"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("7134b285-9c23-4a9e-9694-b7a204109683"));
            TTListBoxOzelDurum = (ITTObjectListBox)AddControl(new Guid("9d5301c5-33f5-4eb1-bd04-a49fc2be73c8"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("88ceb6dc-f5fe-4471-82dc-7b2c9cecab40"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("c568a94c-bc90-402e-9921-a27a953d7fc5"));
            TTListBoxAyniFarkliKesi = (ITTObjectListBox)AddControl(new Guid("3b614723-d0e2-4fcf-aea3-b98fec8ff177"));
            Anomali = (ITTCheckBox)AddControl(new Guid("a3d8fcbe-8811-4ac6-b520-c5f5a66a07dd"));
            labelAyniFarkliKesi = (ITTLabel)AddControl(new Guid("5abdb2d6-2b4a-4310-be23-32976f035692"));
            labelOzelDurum = (ITTLabel)AddControl(new Guid("09f73315-e40e-49dc-8ef4-5bc90cff198b"));
            labelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("1769fc38-587b-4500-a406-aa75f10d70f6"));
            DisTaahhutNo = (ITTTextBox)AddControl(new Guid("758cdb5b-a4d6-4928-8a67-efeb0b4ba352"));
            labelDisTaahhutNo = (ITTLabel)AddControl(new Guid("a124673b-3a6a-4c6a-a21d-9170ac1fd8c2"));
            DentalTreatmentDescription = (ITTTextBox)AddControl(new Guid("09b9d333-4fe1-425a-a86b-fd4b13011e87"));
            DentalExaminationFile = (ITTTextBox)AddControl(new Guid("cbdf8164-1f95-4d1e-81d1-592e95102c0b"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("4ed9babd-db73-4a48-9f79-d233c94e9482"));
            ProcedureDepartment = (ITTObjectListBox)AddControl(new Guid("e5e128c0-e9dd-4ad5-93cc-d8e2f482f8c8"));
            labelTechnicalDepartment = (ITTLabel)AddControl(new Guid("25244902-136e-47c2-8044-e5fa944d9f23"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("017f04c6-8abc-4025-968d-795ea4981e0c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("4a414370-9a69-4ed8-9dfd-c58fc81a802a"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("b16648ff-17f1-41df-b096-2d057faa44eb"));
            btnNewTreatmentDischarge = (ITTButton)AddControl(new Guid("d75a57b8-4a39-48be-8cc7-605c11d4f1ea"));
            ttbuttonToothSchema = (ITTButton)AddControl(new Guid("7e7b2ef4-4119-4ce0-979e-51ccdcdd984e"));
            base.InitializeControls();
        }

        public DentalTreatmentProcedureForm() : base("DENTALTREATMENTPROCEDURE", "DentalTreatmentProcedureForm")
        {
        }

        protected DentalTreatmentProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}