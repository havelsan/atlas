
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
    /// Diş Protez
    /// </summary>
    public partial class DentalProsthesisForm : BaseDentalEpisodeActionForm
    {
    /// <summary>
    /// Diş Protez İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DentalProsthesisRequest _DentalProsthesisRequest
        {
            get { return (TTObjectClasses.DentalProsthesisRequest)_ttObject; }
        }

        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage DentalExaminationDiagnosisPage;
        protected ITTGrid SecDiagnosisGrid;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTEnumComboBoxColumn SecToothNum;
        protected ITTEnumComboBoxColumn SecDentalPosition;
        protected ITTButtonColumn SecToothSchema;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTabPage EpisodeDiagnosisPage;
        protected ITTGrid EpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox DentalExaminationFile;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelDentalExaminationFile;
        protected ITTLabel labelProtocolNo;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage SuggestedDentalProsthesis;
        protected ITTGrid SuggestedProsthesis;
        protected ITTCheckBoxColumn SuggestedEmergency;
        protected ITTListBoxColumn SuggestedProsthesisProcedure;
        protected ITTEnumComboBoxColumn SuggestedToothNum;
        protected ITTEnumComboBoxColumn SuggestedDentalPosition;
        protected ITTButtonColumn SuggestedToothSchema;
        protected ITTListBoxColumn SuggestedDepartment;
        protected ITTTextBoxColumn SuggestedDefinition;
        protected ITTTabPage DentalProsthesisTab;
        protected ITTGrid DentalProsthesis;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTEnumComboBoxColumn ProsthesisToothNum;
        protected ITTEnumComboBoxColumn ProthesisDentalPosition;
        protected ITTTextBoxColumn ToothColor;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn DentalProsthesisDescription;
        protected ITTListBoxColumn Department;
        protected ITTListBoxColumn Doctor;
        protected ITTTextBoxColumn DefinitionToTechnician;
        protected ITTTextBoxColumn ProsthesisMeasurement;
        protected ITTTextBoxColumn TechnicianNote;
        protected ITTListBoxColumn TechnicalDepartment;
        protected ITTTextBoxColumn OuterLabName;
        protected ITTTextBoxColumn ReasonOfReturn;
        protected ITTTextBoxColumn Decision;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid UsedMaterials;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn Note;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTListDefComboBoxColumn MalzemeTuru;
        protected ITTListDefComboBoxColumn MalzemeBilgisi_OzelDurum;
        override protected void InitializeControls()
        {
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("96618a59-ccd6-4f21-aabf-9933c38462e0"));
            DentalExaminationDiagnosisPage = (ITTTabPage)AddControl(new Guid("3ae063f5-7f40-46b3-92b3-41b1257c671e"));
            SecDiagnosisGrid = (ITTGrid)AddControl(new Guid("2ce79c18-8590-45e9-9347-d5749e85ca47"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("950b2881-c50d-4265-bf83-6ea591dfee52"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("5f437103-2387-42ed-b470-2536c3115bee"));
            SecDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("0aa7e46f-e25b-4fe3-908c-9d2d6432a011"));
            SecToothSchema = (ITTButtonColumn)AddControl(new Guid("7c381cb2-1441-4d5e-ba48-6c249b08d6cb"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("37746421-131e-46cf-bc52-8f7a9e2c4183"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("b7df6497-eb50-44c7-a505-3b17ae4fe48e"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("a097f188-b9fd-45b5-a7f6-3b0d31e8b45d"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("5a017305-5c4a-4488-af61-06faac9b8f50"));
            EpisodeDiagnosisPage = (ITTTabPage)AddControl(new Guid("081681fe-fc1f-401c-a755-ccf79c9db846"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("a2e8b869-20a0-4093-be86-1480b4f47466"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("f71f2296-ed50-45b9-ba9f-554d612d152d"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("ab426bbc-2083-496a-9330-5794e1d35e6b"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("4d404d53-2736-4dce-a906-6cc8e83ef364"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ed39ce16-927b-4939-b05f-c062d79c95d4"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("163157ba-55ab-4172-9cb7-21e9cd30fccc"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("6c685d27-dfef-4fb9-a59b-ac6f0da68cbd"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("7d88aa7c-a7e2-4765-a90e-698b4b9787b3"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("098c346b-b819-4c9a-950f-2ad92cd79fcf"));
            DentalExaminationFile = (ITTTextBox)AddControl(new Guid("4768927e-782f-4c04-bab4-590228b87bd0"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("bee56539-16aa-4879-a932-562bfcc47aef"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("c5d5a06b-bf8d-42fa-84e9-9cf1af87ae80"));
            labelDentalExaminationFile = (ITTLabel)AddControl(new Guid("f167ead6-5a52-4c5f-a3d2-6c17e0c488a9"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("965f8cdb-493c-4d37-a069-a2bfff79c06c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("356b5ebe-5754-4b59-8681-a5c47632c37e"));
            SuggestedDentalProsthesis = (ITTTabPage)AddControl(new Guid("b9a01dcb-23fe-4733-bcf8-d0e10751bb41"));
            SuggestedProsthesis = (ITTGrid)AddControl(new Guid("3f13d854-4a05-4292-bdf4-d9324497f11e"));
            SuggestedEmergency = (ITTCheckBoxColumn)AddControl(new Guid("04c67420-46cf-4213-9b00-41bbf6a422cc"));
            SuggestedProsthesisProcedure = (ITTListBoxColumn)AddControl(new Guid("f3632346-bcae-4592-b9d6-0a9238a1440b"));
            SuggestedToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("0a374317-3cdc-4c91-b5a7-faf099cd7add"));
            SuggestedDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("293ae4d5-f027-4dbb-9907-f1774b5d5b78"));
            SuggestedToothSchema = (ITTButtonColumn)AddControl(new Guid("8af64ab7-45cf-47b5-87b0-faf93e6434e7"));
            SuggestedDepartment = (ITTListBoxColumn)AddControl(new Guid("c01ab2de-3dea-48d6-ad83-b0b5d42d2966"));
            SuggestedDefinition = (ITTTextBoxColumn)AddControl(new Guid("0277b2da-3747-4c24-ba5c-ef85daa46bc4"));
            DentalProsthesisTab = (ITTTabPage)AddControl(new Guid("f94d4fcd-e35c-412a-9ad9-b623ba51594c"));
            DentalProsthesis = (ITTGrid)AddControl(new Guid("8baeebf9-05ea-4b4b-8972-a30cde463d12"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("a5461401-a001-4831-8c64-458ec115762b"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("498570a0-9fe2-4983-a1ff-10ce2ed14e3f"));
            ProsthesisToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("3ab9d276-b023-4b62-b7f1-fe33a9bb83e0"));
            ProthesisDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("03c9c681-413c-4dde-8499-1ed1baa68e5e"));
            ToothColor = (ITTTextBoxColumn)AddControl(new Guid("e5c4912f-98f2-4313-ae87-e8693ed3e915"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("33b02914-d562-41cd-af35-9c9478dc8525"));
            DentalProsthesisDescription = (ITTTextBoxColumn)AddControl(new Guid("949c419f-ddf8-407c-ada3-33ed5f14cc67"));
            Department = (ITTListBoxColumn)AddControl(new Guid("a217345e-ca33-4335-8d37-66884a8f8758"));
            Doctor = (ITTListBoxColumn)AddControl(new Guid("7ac75a4f-6f98-4b66-8dcc-b6a1a1d7bb0b"));
            DefinitionToTechnician = (ITTTextBoxColumn)AddControl(new Guid("5cf26a4b-6af0-407f-86c6-ce62f1b9dd42"));
            ProsthesisMeasurement = (ITTTextBoxColumn)AddControl(new Guid("21c89257-9893-4b87-9d49-717126fcdd17"));
            TechnicianNote = (ITTTextBoxColumn)AddControl(new Guid("610497b6-f3ab-41fb-b607-c5e3037f6397"));
            TechnicalDepartment = (ITTListBoxColumn)AddControl(new Guid("1a040163-9a8b-418a-9ef1-8d6494f1d1b2"));
            OuterLabName = (ITTTextBoxColumn)AddControl(new Guid("6c5cf8e9-2395-4de7-8455-79fccd887fc2"));
            ReasonOfReturn = (ITTTextBoxColumn)AddControl(new Guid("c3833482-7ed3-4e47-96e6-02332ce3db44"));
            Decision = (ITTTextBoxColumn)AddControl(new Guid("771170fd-53cc-4f00-b485-7c497fc3f7cc"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("a94cbab6-7bb1-4e20-956e-6740d15be0ed"));
            UsedMaterials = (ITTGrid)AddControl(new Guid("05560a0f-88a5-43b4-a6c6-3252dae33f32"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("1bbc84cf-97a9-4a96-aada-390eb39581d0"));
            Material = (ITTListBoxColumn)AddControl(new Guid("6664db88-edcd-4a26-8b51-455d9b9d1d5d"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("5127fad9-21e3-45a9-95ee-f28a38d90cd9"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("7bf33821-9a25-4ae0-a520-b0e88610daab"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("8d2c3614-31bf-43ca-9e96-45f22d6b2de5"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("a0724446-fa3a-46e8-bc59-e0c7c06c5838"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("16a0faf2-623d-483e-b60e-2b45ca08306e"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("1bcea976-47c3-4118-acc1-7e8093856ffc"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("3d175e37-a406-48bd-a6ca-9360a420d1b0"));
            MalzemeTuru = (ITTListDefComboBoxColumn)AddControl(new Guid("6d20f0a4-589d-4d0b-89e9-abd4d3fe0411"));
            MalzemeBilgisi_OzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("3d6292c1-45b1-4a1c-8f72-e09c0c5045cc"));
            base.InitializeControls();
        }

        public DentalProsthesisForm() : base("DENTALPROSTHESISREQUEST", "DentalProsthesisForm")
        {
        }

        protected DentalProsthesisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}