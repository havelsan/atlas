
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
    /// Diş Protez İşlemi
    /// </summary>
    public partial class DentalProsthesisProcedureForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Diş Protez Prosedür
    /// </summary>
        protected TTObjectClasses.DentalProsthesisProcedure _DentalProsthesisProcedure
        {
            get { return (TTObjectClasses.DentalProsthesisProcedure)_ttObject; }
        }

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
        protected ITTTextBox ProsthesisMeasurement;
        protected ITTTextBox DentalProsthesisDescription;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelAmount;
        protected ITTLabel labelDentalPosition;
        protected ITTCheckBox Emergency;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelToothNumber;
        protected ITTLabel labelToothColor;
        protected ITTLabel labelProsthesisMeasurement;
        protected ITTTabControl SubactionTab;
        protected ITTTabPage RowMaterial;
        protected ITTGrid RowMaterials;
        protected ITTTextBoxColumn TakenRowMaterial;
        protected ITTTextBoxColumn ExpendRowMaterial;
        protected ITTTextBoxColumn LossRowMaterial;
        protected ITTTextBoxColumn ReturnedRowMaterial;
        protected ITTTextBoxColumn MaterialDefinition;
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
        protected ITTDateTimePickerColumn MalzemeSAtinAlisTarihi;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTListBoxColumn MalzemeBilgisi_OzelDurum;
        protected ITTTabPage UsedSets;
        protected ITTGrid UsedSet;
        protected ITTListBoxColumn ProsthesisUsedSet;
        protected ITTTextBoxColumn SetDefinition;
        protected ITTTabPage MedulaBilgileri;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTObjectListBox TTListBoxOzelDurum;
        protected ITTObjectListBox TTListBoxAyniFarkliKesi;
        protected ITTLabel labelDrAnesteziTescilNo;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        protected ITTLabel labelAyniFarkliKesi;
        protected ITTCheckBox Anomali;
        protected ITTTextBox DisTaahhutNo;
        protected ITTLabel labelOzelDurum;
        protected ITTLabel labelDisTaahhutNo;
        protected ITTTextBox OuterLabName;
        protected ITTTextBox ToothColor;
        protected ITTTextBox DentalExaminationFile;
        protected ITTTextBox Amount;
        protected ITTTextBox DefinitionToTechnician;
        protected ITTLabel labelTechnicalDepartment;
        protected ITTObjectListBox Department;
        protected ITTLabel labelDepartment;
        protected ITTObjectListBox TechnicalDepartment;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelDentalExaminationFile;
        protected ITTLabel labelDoctor;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelDentalProsthesisDescription;
        protected ITTObjectListBox Doctor;
        protected ITTLabel labelDefinitionToTechnician;
        protected ITTLabel labelOuterLabName;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTButton btnNewTreatmentDischarge;
        protected ITTButton ttbutton1;
        protected ITTCheckBox ttcheckboxGeneralAnesthesia;
        override protected void InitializeControls()
        {
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("6c915a9b-7a20-4a4b-8dc9-ab82aa1f795c"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("5876e93d-3b35-4714-9030-3d61640d89d6"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("9996801d-75d5-47f0-b413-ed7629d78bc9"));
            SecDiagnosis = (ITTGrid)AddControl(new Guid("18108990-7fa0-4257-b3e4-aff982d7e192"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("804c31a0-cedc-4675-9acb-04f34458516c"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("7003cfec-39e4-4778-a8e5-4bde4ace4777"));
            SecDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("a7799909-d883-470b-96df-a715659e5d30"));
            SecToothSchema = (ITTButtonColumn)AddControl(new Guid("c818b523-cf57-4ddf-b8a8-5b118bb788da"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("8af49faa-b61f-4240-bdf8-d037c1962a5d"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("4fb7f4f2-0c71-42b3-a907-069cce4d9126"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("664484af-2342-472b-a3f9-3e1ba8171453"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("c294d120-7a54-4ebe-9917-d549639722b4"));
            EpisodeDiagnosisPage = (ITTTabPage)AddControl(new Guid("08bd50fc-888c-4865-9888-569fd88da7a3"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("84dad221-89ba-461e-933d-04da0ceff74e"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("05651fde-065e-4bf8-b18d-65c3c300b3a6"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("fdea9faf-df9c-4b5c-a9b2-7d639aea687e"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("c9277142-6281-445e-b34f-5da7cf680d69"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("be328367-e4e5-4f4b-8f4b-8c577d33c022"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("68883fa2-ed18-4f9a-8a60-b6662ac4fccc"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("0980e8c8-b1ec-4658-a325-f2a815f70116"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("aa394515-19f1-4fd6-840c-6727bc690b29"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b9fa8fb0-ecad-4968-8b56-bbc153d223b2"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("3be840fc-4394-426f-84b4-60d190dc29ff"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("a13c2873-cc36-498b-98ee-26c5b84299d1"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("c7b8cef7-8888-4581-8c61-6d901c83b26d"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("3c855781-6e6d-4acd-8caa-c2f889cedc89"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("ee2ceaea-526a-4182-adfa-1294ebff18a0"));
            ProsthesisMeasurement = (ITTTextBox)AddControl(new Guid("ca775f22-7afd-4c0b-bd8b-17e4b2bbc50a"));
            DentalProsthesisDescription = (ITTTextBox)AddControl(new Guid("13b8f28d-a390-4d83-a605-30e9fed5d34f"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("7c7a5100-6a17-4771-9a68-babac2bbbb00"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("0910ea5e-2084-4485-b5cd-63771a361e24"));
            labelAmount = (ITTLabel)AddControl(new Guid("031ea3e0-83d7-4c6b-8771-16b8deee01eb"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("b6396fb4-435e-475e-9267-1a09a6c727d8"));
            Emergency = (ITTCheckBox)AddControl(new Guid("235bf7e5-4e59-4d74-b7c0-1beca23b44b5"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("413edf73-9002-463b-a037-1ddffd6cc31f"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("587dc8e0-052d-4662-be29-22ae43e6dfaa"));
            labelToothColor = (ITTLabel)AddControl(new Guid("722af3fb-646d-4aa6-9a3f-2e8b4aae59b2"));
            labelProsthesisMeasurement = (ITTLabel)AddControl(new Guid("7b9884b1-11e1-4bf2-9eaa-3260e7d15a74"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("390cec73-0385-49b0-bdbb-35b8721fae5d"));
            RowMaterial = (ITTTabPage)AddControl(new Guid("1b814960-bc37-4c8d-a748-48631ae7af28"));
            RowMaterials = (ITTGrid)AddControl(new Guid("47a0fb97-ad5f-46db-a77f-5da320c27b85"));
            TakenRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("7559eb9a-d339-4b64-aac6-98be73c3eadc"));
            ExpendRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("d394b80d-9bc3-453e-9e41-9b9b01882181"));
            LossRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("2fd98fd6-6aaf-4714-9135-6df70f2079ca"));
            ReturnedRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("21e73b97-4f5f-4917-97fc-baa2fc95f1ee"));
            MaterialDefinition = (ITTTextBoxColumn)AddControl(new Guid("a6094223-3626-4254-b1df-6c82eb1dff5e"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("a9a85f59-da43-442b-9b78-88650b1f73d6"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("62c6ac58-5c65-45b2-b01d-d791c5079e68"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("09f81356-eb0d-4c65-b5be-c3ba48983112"));
            Material = (ITTListBoxColumn)AddControl(new Guid("bf6e4357-4e8d-4dc3-bef3-8239447dccd2"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("6177ed77-107d-4492-bbcd-e9cd342c1d4b"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("e096538f-2628-450a-a8bf-338085128661"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("420145a7-2c16-4f0a-bbf4-737b0800062d"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("6a9833aa-9467-4616-9359-f82445020b5b"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("dd289f56-34bb-4b76-9542-0d2ebc3e8d2f"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("55aaf5b0-af2e-4f45-994d-51750a3b7427"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("671568df-4d15-455e-a9b6-45c3e0da1458"));
            MalzemeSAtinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("8791243a-592c-48ff-834b-db94c10cad4d"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("5297d7fe-50f2-4425-bb1a-ca121eb75418"));
            MalzemeBilgisi_OzelDurum = (ITTListBoxColumn)AddControl(new Guid("a877bb57-27dd-413a-8383-defc2da84343"));
            UsedSets = (ITTTabPage)AddControl(new Guid("a4ef7fa1-f2f0-4053-bf92-a2cc6d01751a"));
            UsedSet = (ITTGrid)AddControl(new Guid("05f428b2-5521-40f8-9c17-ae086ae1f5cd"));
            ProsthesisUsedSet = (ITTListBoxColumn)AddControl(new Guid("ea604e00-5ecc-4031-96f3-fa51c9c1eec3"));
            SetDefinition = (ITTTextBoxColumn)AddControl(new Guid("e700ba07-3ee4-4ccb-bfec-230d45f50d5f"));
            MedulaBilgileri = (ITTTabPage)AddControl(new Guid("7e14d063-a6e1-4681-9ceb-7c5536877f44"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("902127c4-a886-4c98-b29c-24dc21e5ee4e"));
            TTListBoxOzelDurum = (ITTObjectListBox)AddControl(new Guid("04106201-e506-4993-b81d-92a5fe388c88"));
            TTListBoxAyniFarkliKesi = (ITTObjectListBox)AddControl(new Guid("fa24488e-b852-482b-b2ac-a2119e867d0f"));
            labelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("0090ddf4-8fbc-4399-a0c9-19a5731d1adf"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("f0509248-7a86-4956-b678-13aab34ed174"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("10a213aa-56a9-4272-b6e4-7252ab7f8af1"));
            labelAyniFarkliKesi = (ITTLabel)AddControl(new Guid("bb831473-835c-4fad-b007-dd5514ba72ad"));
            Anomali = (ITTCheckBox)AddControl(new Guid("d407bc6f-eb4a-4376-886c-f9a8128c0679"));
            DisTaahhutNo = (ITTTextBox)AddControl(new Guid("d57b62ab-f0e8-426a-94a3-5817617476fc"));
            labelOzelDurum = (ITTLabel)AddControl(new Guid("a8e22ea0-b772-4f51-ba1e-089a878ded67"));
            labelDisTaahhutNo = (ITTLabel)AddControl(new Guid("07b11b7a-dbd8-4b6d-bb00-84bec0520d9f"));
            OuterLabName = (ITTTextBox)AddControl(new Guid("fd5f8b50-b944-4c2f-afa4-43d805289164"));
            ToothColor = (ITTTextBox)AddControl(new Guid("f7e04a7e-202d-49c0-9070-4fc21ea6e9a9"));
            DentalExaminationFile = (ITTTextBox)AddControl(new Guid("2fccdfb5-5dc4-495e-abee-6f4c12953083"));
            Amount = (ITTTextBox)AddControl(new Guid("54495bc6-33d8-4cfe-bc96-c0cde86ee13c"));
            DefinitionToTechnician = (ITTTextBox)AddControl(new Guid("ba525e50-eaf0-4319-9055-dfd77a19c91a"));
            labelTechnicalDepartment = (ITTLabel)AddControl(new Guid("af40be51-b04a-4d0c-b9b3-4b84f8065ddf"));
            Department = (ITTObjectListBox)AddControl(new Guid("b05d61d2-e7f6-4ae7-9d5c-4ce7b7592f1e"));
            labelDepartment = (ITTLabel)AddControl(new Guid("3d243430-8ea3-4fde-94fd-563aae549459"));
            TechnicalDepartment = (ITTObjectListBox)AddControl(new Guid("4760c44c-e29f-48c1-b675-59a78d318144"));
            labelProcedure = (ITTLabel)AddControl(new Guid("22116a95-6f8e-48d3-af75-7b3a0f68320f"));
            labelDentalExaminationFile = (ITTLabel)AddControl(new Guid("a5930ea9-8516-4580-9f7e-86335413a620"));
            labelDoctor = (ITTLabel)AddControl(new Guid("0b40c2f9-e64e-46db-bc1d-8782a8178c3e"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("16d27641-e7a3-4aba-baa8-91f43361c5b0"));
            labelDentalProsthesisDescription = (ITTLabel)AddControl(new Guid("5e907fbc-e611-4d69-9a2a-bddb0164e2df"));
            Doctor = (ITTObjectListBox)AddControl(new Guid("2bbaa87e-4543-45bb-8d9f-c4e165044fad"));
            labelDefinitionToTechnician = (ITTLabel)AddControl(new Guid("422e202c-a2fe-488c-bd00-c64581c21dc4"));
            labelOuterLabName = (ITTLabel)AddControl(new Guid("7b02cf23-2676-4354-b89e-cdad8508f3e1"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("1c0655a8-cb6b-46d0-b69a-da178511253b"));
            btnNewTreatmentDischarge = (ITTButton)AddControl(new Guid("87680bb2-9a06-44a7-9154-3f573e78333d"));
            ttbutton1 = (ITTButton)AddControl(new Guid("88b83201-0244-414e-a239-b248bf0c57b3"));
            ttcheckboxGeneralAnesthesia = (ITTCheckBox)AddControl(new Guid("e7f0ca0c-37f0-4275-af2a-5abb143b7fa6"));
            base.InitializeControls();
        }

        public DentalProsthesisProcedureForm() : base("DENTALPROSTHESISPROCEDURE", "DentalProsthesisProcedureForm")
        {
        }

        protected DentalProsthesisProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}