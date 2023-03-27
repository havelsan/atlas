
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
    /// Diş Tedavi
    /// </summary>
    public partial class DentalTreatmentForm : BaseDentalEpisodeActionForm
    {
    /// <summary>
    /// Diş Tedavi İstek
    /// </summary>
        protected TTObjectClasses.DentalTreatmentRequest _DentalTreatmentRequest
        {
            get { return (TTObjectClasses.DentalTreatmentRequest)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage DentalExaminationDiagnosisPage;
        protected ITTGrid SecDiagnosisGrid;
        protected ITTCheckBoxColumn ttcheckboxcolumn3;
        protected ITTEnumComboBoxColumn SecToothNum;
        protected ITTEnumComboBoxColumn SecDentalPosition;
        protected ITTButtonColumn SecToothSchema;
        protected ITTListBoxColumn ttlistboxcolumn3;
        protected ITTCheckBoxColumn ttcheckboxcolumn4;
        protected ITTListBoxColumn ttlistboxcolumn4;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTTabPage EpisodeDiagnosisPage;
        protected ITTGrid EpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTCheckBoxColumn ttcheckboxcolumn7;
        protected ITTListBoxColumn ttlistboxcolumn7;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn5;
        protected ITTCheckBoxColumn ttcheckboxcolumn8;
        protected ITTListBoxColumn ttlistboxcolumn8;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn4;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage DentalTreatmentTab;
        protected ITTGrid DentalTreatments;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn DentalRequestType;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTEnumComboBoxColumn TreatmentToothNum;
        protected ITTEnumComboBoxColumn TreatmentDentalPosition;
        protected ITTButtonColumn ProcedureToothSchema;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn DentalTreatmentDescription;
        protected ITTListBoxColumn ProcedureDepartment;
        protected ITTListBoxColumn ProcedureDoctor;
        protected ITTTextBoxColumn DefinitiontoTechnician;
        protected ITTTextBoxColumn TechnicianNote;
        protected ITTListBoxColumn TechnicalDepartment;
        protected ITTTabPage SuggestedDentalTreatment;
        protected ITTGrid SuggestedTreatments;
        protected ITTCheckBoxColumn SuggestedEmergency;
        protected ITTListBoxColumn SuggestedDentalRequestType;
        protected ITTListBoxColumn SuggestedTreatmentProcedure;
        protected ITTEnumComboBoxColumn SuggestedToothNum;
        protected ITTEnumComboBoxColumn SuggestedDentalPosition;
        protected ITTListBoxColumn SuggestedDepartment;
        protected ITTTextBoxColumn SuggestedDefinition;
        protected ITTTextBox DentalExaminationFile;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelDentalExaminationFile;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e6ade791-9d6f-487c-bc01-5b8154f88b77"));
            DentalExaminationDiagnosisPage = (ITTTabPage)AddControl(new Guid("77a17261-3356-4be7-ab2b-53ba959c4b34"));
            SecDiagnosisGrid = (ITTGrid)AddControl(new Guid("31d9ec28-2c21-46bb-8faf-a852e26d6faa"));
            ttcheckboxcolumn3 = (ITTCheckBoxColumn)AddControl(new Guid("783d7b04-1e5d-4ced-8dad-7bd66380ffe6"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("c5aafd28-89d7-4124-9214-5a0ec44a0f06"));
            SecDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("c86dd16b-e173-45dd-87f3-31a8e454642b"));
            SecToothSchema = (ITTButtonColumn)AddControl(new Guid("c797dfaa-506c-43e1-b37c-5d1ad56bcf20"));
            ttlistboxcolumn3 = (ITTListBoxColumn)AddControl(new Guid("0ec63a6d-ba2d-4ec2-8185-bfc2b3894731"));
            ttcheckboxcolumn4 = (ITTCheckBoxColumn)AddControl(new Guid("cdc997e4-8e82-4152-9076-844913135908"));
            ttlistboxcolumn4 = (ITTListBoxColumn)AddControl(new Guid("8ec4fa63-39ed-485b-8b27-88e20fb32d81"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("238648c2-558d-4980-a9a8-0de6aa1d7846"));
            EpisodeDiagnosisPage = (ITTTabPage)AddControl(new Guid("a69fcba1-81a4-4a50-8b8e-ad74e88f673d"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("03d2e385-990c-4355-b880-f3f5f38a64ad"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c17b912f-7255-43f2-8e12-2d615a39cf16"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("cf11dcf5-07dc-4b33-9f62-63f52d05dd81"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("74d40d38-498b-4945-a77f-c4164a360fe8"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("4b4f9403-c3cd-4ef8-9110-32a3b3eb98a2"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f7b0742d-537f-427f-98de-117781bdce6b"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("f5db5a6f-c6c2-49e1-99d1-5d341355235d"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("10df4ecb-2e54-4bb3-b920-6af1ea8f4e8d"));
            ttcheckboxcolumn7 = (ITTCheckBoxColumn)AddControl(new Guid("b8425c96-efe3-40c1-8917-24f23c4d11b2"));
            ttlistboxcolumn7 = (ITTListBoxColumn)AddControl(new Guid("d78617c5-2444-44f9-9be2-a0e7397b50c9"));
            ttenumcomboboxcolumn5 = (ITTEnumComboBoxColumn)AddControl(new Guid("10f90177-2165-44d7-9fb6-c7507015014a"));
            ttcheckboxcolumn8 = (ITTCheckBoxColumn)AddControl(new Guid("59ea8b32-afb4-496f-8696-42aa77791916"));
            ttlistboxcolumn8 = (ITTListBoxColumn)AddControl(new Guid("fd092046-edf1-43c0-ae29-0c314f218cbf"));
            ttdatetimepickercolumn4 = (ITTDateTimePickerColumn)AddControl(new Guid("0f545a09-d254-4835-848f-2533b3fbd1e8"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("c8cc2627-e325-425d-980d-37cdc2bfd77b"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("6c3dbe75-fb05-4615-bbce-48855f093858"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("4e722d75-5288-4ba4-9be9-545486cd770d"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("fa756c7f-9eed-4a6d-9022-6ae4cd4f774f"));
            DentalTreatmentTab = (ITTTabPage)AddControl(new Guid("8d43dda3-8b82-4eae-b872-11745923b029"));
            DentalTreatments = (ITTGrid)AddControl(new Guid("f9ccee86-7aef-4b12-9a4b-ab8bfd2e8705"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("2023d9cf-cc7d-4572-a0c9-ae37b0692f54"));
            DentalRequestType = (ITTListBoxColumn)AddControl(new Guid("20cd672b-8f91-4d4b-bb1e-5f16b3636bb5"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("52203ee1-5cd8-464f-9e8b-defb18b3b282"));
            TreatmentToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("6c523c80-1cc2-4849-ae76-d043621a6c7d"));
            TreatmentDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("241b8d25-fa2c-4194-956c-1fab9e9a72b8"));
            ProcedureToothSchema = (ITTButtonColumn)AddControl(new Guid("4729b8cc-9afb-4b25-bde3-87f2bede4dcf"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("500ebc25-ac74-45f8-a43b-bf331a77ca13"));
            DentalTreatmentDescription = (ITTTextBoxColumn)AddControl(new Guid("b0d95719-4f26-4a85-8431-2d41fe24f7b2"));
            ProcedureDepartment = (ITTListBoxColumn)AddControl(new Guid("56bd2485-b578-4ce1-859e-4d36aea04fb8"));
            ProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("a3e797de-2cbb-4352-a102-88ae42038af4"));
            DefinitiontoTechnician = (ITTTextBoxColumn)AddControl(new Guid("86856b29-1620-4bf4-821b-d3c9ec200194"));
            TechnicianNote = (ITTTextBoxColumn)AddControl(new Guid("6a2b6388-29aa-4f9a-b063-63fcae88e783"));
            TechnicalDepartment = (ITTListBoxColumn)AddControl(new Guid("d03da2ee-0099-4f6b-91d7-67df8bdbef9f"));
            SuggestedDentalTreatment = (ITTTabPage)AddControl(new Guid("57cb7844-1070-4be3-88e3-dd5b3b6d96e5"));
            SuggestedTreatments = (ITTGrid)AddControl(new Guid("383a8209-0676-4aa7-9536-c810bd84d364"));
            SuggestedEmergency = (ITTCheckBoxColumn)AddControl(new Guid("92bab200-484a-4f1d-bd82-049cbc85bba9"));
            SuggestedDentalRequestType = (ITTListBoxColumn)AddControl(new Guid("8d940758-5f3f-4997-877b-48860ec96c57"));
            SuggestedTreatmentProcedure = (ITTListBoxColumn)AddControl(new Guid("a19e0e53-84aa-4ae3-a9ac-a049017bafe4"));
            SuggestedToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("0a6b2e70-6b1b-40fa-a1bb-1e5dc51c97ae"));
            SuggestedDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("08ed9297-2918-4701-b961-e4ee1c1ce3f7"));
            SuggestedDepartment = (ITTListBoxColumn)AddControl(new Guid("ee44a6e7-6238-4ad3-b69a-c814a1be27d7"));
            SuggestedDefinition = (ITTTextBoxColumn)AddControl(new Guid("0435293d-7e06-4214-bcc9-aea9375a347c"));
            DentalExaminationFile = (ITTTextBox)AddControl(new Guid("766092b9-91b8-4718-8304-d537233b4192"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("a25820d1-bb01-4276-a44d-87bb93577589"));
            labelDentalExaminationFile = (ITTLabel)AddControl(new Guid("99a54a1d-7b1b-4b5e-b17a-a18a7c14df04"));
            base.InitializeControls();
        }

        public DentalTreatmentForm() : base("DENTALTREATMENTREQUEST", "DentalTreatmentForm")
        {
        }

        protected DentalTreatmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}