
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
    public partial class ConsultationCancelledForm : EpisodeActionForm
    {
        protected TTObjectClasses.Consultation _Consultation
        {
            get { return (TTObjectClasses.Consultation)_ttObject; }
        }

        protected ITTTextBox tttextboxProtokolNo;
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProceduerDoctor;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox RequestedDoctor;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ConsultationRequestDate;
        protected ITTCheckBox InPatientBed;
        protected ITTCheckBox Emergency;
        protected ITTObjectListBox RequesterDepatment;
        protected ITTLabel labelProcessDate;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel labelRequesterDepatment;
        protected ITTLabel ttlabel2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTLabel labelReasonOfCancel;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage GridDiagnosisEntry;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        override protected void InitializeControls()
        {
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("8382e90f-4925-48d3-a635-fac8c7964ebf"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("9728bc3c-5490-461d-b612-5c56e95e8c00"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("99f6589a-acdf-4d9f-86aa-be96c4d193bb"));
            ProceduerDoctor = (ITTObjectListBox)AddControl(new Guid("48f87afc-262c-4f2f-aa03-69bee488d189"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("5183872d-7e4f-459c-8f10-d217631f28aa"));
            RequestedDoctor = (ITTObjectListBox)AddControl(new Guid("d7f14bb8-fa27-4ca9-9e15-9851b1a19d41"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e89e8e4f-c29f-40d9-bdec-407dae03f70b"));
            ConsultationRequestDate = (ITTDateTimePicker)AddControl(new Guid("b40d39ed-aa8d-45c2-ba08-c42cb18b6b1f"));
            InPatientBed = (ITTCheckBox)AddControl(new Guid("3ec2f904-c46a-4db8-bae0-66ddd46095bd"));
            Emergency = (ITTCheckBox)AddControl(new Guid("9730ae7e-77bf-461f-8087-fea6ea8dccd4"));
            RequesterDepatment = (ITTObjectListBox)AddControl(new Guid("bb0270a1-5a02-418d-b419-d9670579bb24"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("a33929ee-5448-44cc-85fb-6dc6d269c83c"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("2e192271-0082-4297-b442-74493ab3415f"));
            labelRequesterDepatment = (ITTLabel)AddControl(new Guid("ca911d10-5fc8-46cf-b5c2-c3ecdbac5c46"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("57923a00-63be-4ef9-a407-8de279bd9d0c"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("5f8cf7e6-4f68-4add-87bb-cebf3e0f23fa"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("0c2c65f2-2d8a-4a6f-8341-52591a740c53"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("47a795ec-6e30-4903-89c6-0bec74cc70f3"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("d9d728ac-a5b0-40e4-a637-b82fac30f25f"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("a5387541-8353-48e8-8fe4-2111d17540c4"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("a05c5c81-ff50-46d8-bfc5-cbab032993c8"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("42ec1860-6e77-4853-8ab1-32709df21664"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("666e6ff8-3e68-47db-8c2f-c2bf452a3b1c"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("1096d637-7787-45cc-87d8-7e5397a4df15"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("8b35baa3-6f8c-4b34-a994-087b39f0298b"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("8dd7324b-205a-46f3-8088-09b1f6e436c0"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("6840219e-c9f4-4e99-817c-d4669eab32ed"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("26319994-a58f-406d-98c4-9b711134ddef"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("83c047e7-af5e-413e-9213-26bcfb637a27"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("146c2150-486f-44e5-9aa6-ddaa8d74f661"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("2adae5ee-0f36-4066-b150-6ec0259262a7"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("5235ce60-350a-4ef6-8192-083681c8849e"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("19889db0-00d4-4b74-82ef-288fce4e948d"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("8f277c19-ea83-4b18-bbf7-aebafacaef14"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("0a0c3a98-42ce-4c4e-8c4f-453dbf90fc1c"));
            base.InitializeControls();
        }

        public ConsultationCancelledForm() : base("CONSULTATION", "ConsultationCancelledForm")
        {
        }

        protected ConsultationCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}