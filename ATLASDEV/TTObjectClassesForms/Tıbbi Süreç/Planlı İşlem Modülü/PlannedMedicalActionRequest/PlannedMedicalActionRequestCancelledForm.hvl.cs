
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
    public partial class PlannedMedicalActionRequestCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Planlı Tıbbi İşlem İstek
    /// </summary>
        protected TTObjectClasses.PlannedMedicalActionRequest _PlannedMedicalActionRequest
        {
            get { return (TTObjectClasses.PlannedMedicalActionRequest)_ttObject; }
        }

        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTDateTimePicker RequestDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage PlannedMedicalActionOrder;
        protected ITTGrid PlannedMedicalActions;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn TreatmentUnit;
        protected ITTTextBoxColumn ApplicationArea;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Duration;
        protected ITTTextBoxColumn TreatmentProperties;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox Note;
        protected ITTTabPage ClinicInfo;
        protected ITTTextBox ClinicFindings;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelRequestDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelProcedureDoctor;
        protected ITTLabel labelReasonOfCancel;
        override protected void InitializeControls()
        {
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("1d5c545e-7999-4f3e-a3cd-a306e16e1f23"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("ed867567-d207-4521-a5f7-57644b643910"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("1ac23502-2251-4934-b303-8b333a3d021c"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("297e01b2-2c1e-4446-9ff3-f33c88f1b0d9"));
            PlannedMedicalActionOrder = (ITTTabPage)AddControl(new Guid("c425da7e-0daf-4410-a7ed-e63efbb798e6"));
            PlannedMedicalActions = (ITTGrid)AddControl(new Guid("a8c9b834-068c-49c7-a40c-8cf45cdb41d7"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("b17b5134-a1f0-4b63-ab5c-d006b9b8fda0"));
            TreatmentUnit = (ITTListBoxColumn)AddControl(new Guid("d94f63d9-49c5-4019-b477-af83da981715"));
            ApplicationArea = (ITTTextBoxColumn)AddControl(new Guid("b0b037ec-5757-44ac-9b22-ea5d108095c4"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("38f74205-5085-4876-9159-37a322716fa0"));
            Duration = (ITTTextBoxColumn)AddControl(new Guid("ca8452bf-9dc0-4893-ab05-f19ee0e95468"));
            TreatmentProperties = (ITTTextBoxColumn)AddControl(new Guid("d8eca4f4-ba32-41fa-96d0-819be2138fba"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("07d33569-ade0-48ff-aac1-bcba85df780d"));
            Note = (ITTTextBox)AddControl(new Guid("0035f2dc-589e-4b01-9125-d33ca6a5607b"));
            ClinicInfo = (ITTTabPage)AddControl(new Guid("58c1690c-3770-4e6c-a597-4963c0f98c41"));
            ClinicFindings = (ITTTextBox)AddControl(new Guid("552751fb-ec0b-4b28-9d4e-c18cff280ab6"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("28b890d9-fc3e-485c-980e-c3108318b42d"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("d896a18f-62ef-440b-842f-989be1575dc8"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("8d5e9cd1-db6e-4e27-b16f-339789a064a5"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("bc8435aa-17d9-47e2-9f91-134661ef99b9"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("3d6f0474-ac88-4b09-a318-9edd56af75bc"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("f7a68cae-e25c-495f-82cf-9534b222d826"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("901a1e46-38b0-4828-8f05-a34be4b3f1a6"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("77eb9e1c-02db-4a27-aff1-d26024c8c843"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("51e04da7-a86f-4ce1-bb56-545f5180dd1e"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("ad3aba41-aa24-48dc-996c-9a382cd367d3"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("9f45849f-addb-4941-ba43-b4bfd60fe98c"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("5dbfca40-f224-4cae-a968-96c732efe85f"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("13e95e31-3774-419c-b205-4de75c36f15e"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("16c09b97-4414-4146-8d3e-40edab506301"));
            base.InitializeControls();
        }

        public PlannedMedicalActionRequestCancelledForm() : base("PLANNEDMEDICALACTIONREQUEST", "PlannedMedicalActionRequestCancelledForm")
        {
        }

        protected PlannedMedicalActionRequestCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}