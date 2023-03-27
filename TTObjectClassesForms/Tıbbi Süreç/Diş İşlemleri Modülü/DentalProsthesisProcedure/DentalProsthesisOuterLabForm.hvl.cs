
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
    /// Diş Protez İşlemleri
    /// </summary>
    public partial class DentalProsthesisOuterLabForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Diş Protez Prosedür
    /// </summary>
        protected TTObjectClasses.DentalProsthesisProcedure _DentalProsthesisProcedure
        {
            get { return (TTObjectClasses.DentalProsthesisProcedure)_ttObject; }
        }

        protected ITTEnumComboBox ToothNumber;
        protected ITTLabel labelActionDate;
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
        protected ITTTextBox Decision;
        protected ITTTextBox ReasonOfReturn;
        protected ITTTextBox Amount;
        protected ITTTextBox OuterLabName;
        protected ITTTextBox ToothColor;
        protected ITTTextBox DefinitionToTechnician;
        protected ITTTextBox DentalProsthesisDescription;
        protected ITTTextBox ProsthesisMeasurement;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelDoctor;
        protected ITTLabel labelToothNumber;
        protected ITTObjectListBox Department;
        protected ITTLabel labelProcedure;
        protected ITTObjectListBox ProcedureObject;
        protected ITTObjectListBox Doctor;
        protected ITTLabel labelDentalPosition;
        protected ITTLabel labelDefinitionToTechnician;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelProsthesisMeasurement;
        protected ITTLabel labelOuterLabName;
        protected ITTLabel labelDecision;
        protected ITTLabel labelDentalProsthesisDescription;
        protected ITTLabel labelReasonOfReturn;
        protected ITTLabel labelAmount;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelDepartment;
        protected ITTLabel labelToothColor;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("29cdd3b5-5ba3-4b44-ac70-148b4a85122d"));
            labelActionDate = (ITTLabel)AddControl(new Guid("9ee02e8c-fce0-44e0-bdb4-079cf86bb74e"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("73a609e6-7d91-4458-8439-fb2a66edd522"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("acfbebe4-f6fa-45fc-8274-fadea3506265"));
            SecDiagnosis = (ITTGrid)AddControl(new Guid("d7b2328b-9016-4306-aba5-b0631725d841"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9f5d130c-107c-4f1b-ac83-867207b4f35b"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("5853ea75-18a1-4d87-9e02-064d73dcd0c1"));
            SecDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("91d86efa-7960-49c1-abfc-07f5aeded81f"));
            SecToothSchema = (ITTButtonColumn)AddControl(new Guid("388d204e-141f-4d79-9411-4014bbc84838"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("f35d6ab8-5ce3-4cf9-a270-a33c87b85f11"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("42e191ea-57ea-4bdd-8544-4e69f0f1f728"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f9e6be6f-6726-454f-9d37-5f26c4368121"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4c48cfdb-cdd9-419b-9c03-2c6fecb0b0ea"));
            EpisodeDiagnosisPage = (ITTTabPage)AddControl(new Guid("ca92c11d-7318-4e97-97d1-59b0f8ff9df4"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("67d705f2-5e7a-4f8d-b51d-a90c923e564f"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("10ed19e0-8903-4198-a4f0-2fcaf235e96b"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("5e9b311b-5f81-4e3b-904e-0cc1db654208"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("c7acba1f-d290-4b55-96e3-30b24a421b2e"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("7c28f39e-a019-4be9-b0af-6f6f6de3e42a"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("98769c51-b7d4-4a76-85e1-5b1290b8c12a"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("c33a57cc-cda5-4f69-9588-83e5a019b93c"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("82cad634-bd5f-49db-8ec0-6763eb744ea8"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c8718c6c-0ff6-48e6-9136-ea8fe1df411b"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("61431679-9982-4b30-aa86-3f3f61ece357"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("b12d26a5-741d-4bed-9a05-911bd322af13"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("bbd7bce8-48f9-4507-b495-737df7247ea2"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("410693f4-447e-4892-b589-b81cd1f66d4f"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("5d1a2778-ab21-439b-9e0e-45e414b69315"));
            Decision = (ITTTextBox)AddControl(new Guid("5968ddac-f467-46f5-b944-013d0ebd515f"));
            ReasonOfReturn = (ITTTextBox)AddControl(new Guid("caa0fe39-3ba4-49ff-919d-216a952ba508"));
            Amount = (ITTTextBox)AddControl(new Guid("62dd5306-5c0d-4547-8d4e-5edc04c7eab9"));
            OuterLabName = (ITTTextBox)AddControl(new Guid("a692357d-d8b9-4980-a02b-619d8507bcbd"));
            ToothColor = (ITTTextBox)AddControl(new Guid("2182ab8a-a92e-46ca-8ab4-6f70df738cde"));
            DefinitionToTechnician = (ITTTextBox)AddControl(new Guid("1eefeb0a-b907-4ef1-976d-a4340b5f7741"));
            DentalProsthesisDescription = (ITTTextBox)AddControl(new Guid("c431f61d-c6b4-46cb-973f-c2574fe6a449"));
            ProsthesisMeasurement = (ITTTextBox)AddControl(new Guid("2e851719-f8f0-498d-a0d3-e41b1ded075b"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("f32c570b-a7bf-4b36-a2e6-d6156a08faf3"));
            labelDoctor = (ITTLabel)AddControl(new Guid("f9b31b54-81a5-4b49-869c-15a162a3e2c5"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("672155de-469d-4c35-bc9a-17469fbfdd66"));
            Department = (ITTObjectListBox)AddControl(new Guid("8a9f25aa-9b06-4e93-96c3-215c9bb56ead"));
            labelProcedure = (ITTLabel)AddControl(new Guid("b586a9fb-51ef-41ca-88f0-2168fe8de51c"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("503c11b8-b4e7-47c2-94f0-27133776412e"));
            Doctor = (ITTObjectListBox)AddControl(new Guid("6382fe74-5488-4826-8dfc-5cadc9422eab"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("af2f5d70-5674-4654-8a12-74c506547b9f"));
            labelDefinitionToTechnician = (ITTLabel)AddControl(new Guid("910f8170-6be2-4f21-a5bd-8a565b66f2ab"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("3b935db2-1139-480b-ad64-91b69ef1ed6b"));
            labelProsthesisMeasurement = (ITTLabel)AddControl(new Guid("6913c5b2-7004-4b44-8880-bfb42a749ea0"));
            labelOuterLabName = (ITTLabel)AddControl(new Guid("f3c938f8-24ef-4f18-ae69-cb1f9e48e7d6"));
            labelDecision = (ITTLabel)AddControl(new Guid("7b7abb64-d645-43ce-8d95-d4184fc96f1f"));
            labelDentalProsthesisDescription = (ITTLabel)AddControl(new Guid("3cbc05d1-b3ec-432a-ab23-dd71f53942c5"));
            labelReasonOfReturn = (ITTLabel)AddControl(new Guid("063fc988-9558-4327-9143-f0d9434c8d28"));
            labelAmount = (ITTLabel)AddControl(new Guid("afba38c7-3c49-4910-98e8-f7b36ab2f058"));
            Emergency = (ITTCheckBox)AddControl(new Guid("fb605f70-a3a4-40e1-aa0c-f9d6e1fc8c5c"));
            labelDepartment = (ITTLabel)AddControl(new Guid("0ef6e8c2-4972-42c1-8a72-f9fbea7970ca"));
            labelToothColor = (ITTLabel)AddControl(new Guid("777f44ab-2ef6-4731-af52-ff76b6d60b43"));
            ttbutton1 = (ITTButton)AddControl(new Guid("98b7b440-42e7-464e-92b0-156d1486b37b"));
            base.InitializeControls();
        }

        public DentalProsthesisOuterLabForm() : base("DENTALPROSTHESISPROCEDURE", "DentalProsthesisOuterLabForm")
        {
        }

        protected DentalProsthesisOuterLabForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}