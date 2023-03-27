
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
    /// Sağlık Kurulu Muayene Onay
    /// </summary>
    public partial class ExaminationApprovalExaminationForm : EpisodeActionForm
    {
    /// <summary>
    /// Muayene Onay Modülü
    /// </summary>
        protected TTObjectClasses.ExaminationApproval _ExaminationApproval
        {
            get { return (TTObjectClasses.ExaminationApproval)_ttObject; }
        }

        protected ITTLabel labelPatientStatus;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTextBox OfferOfDecision;
        protected ITTTextBox Report;
        protected ITTTextBox AdditionalDecision;
        protected ITTLabel labelOfferOfDecision;
        protected ITTLabel labelReasonForExamination;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel labelPatientGroup;
        protected ITTLabel labelAdditionalDecision;
        protected ITTLabel labelReport;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTEnumComboBox PatientGroup;
        override protected void InitializeControls()
        {
            labelPatientStatus = (ITTLabel)AddControl(new Guid("d99199bc-7307-49b8-99aa-0150339ca10d"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("b94276b2-6805-4fae-a862-026172efb9ff"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("d0cef0bd-3425-4ade-9da8-277724294e6b"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("d9a7d0e8-5ea1-4dd6-b91c-249d0ca42822"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("81884d24-a6e5-4f40-a72b-31f03ce8f174"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("7ace6a44-53d4-4028-aba4-33756bdad1e5"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("be90dc4a-db13-4c9a-939d-e167064cb7e1"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("df04e8ab-99e0-4a82-9f90-e467fe4a2f32"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("cbe10993-0b02-4c49-a039-88e9ff551c73"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("2796c478-d73e-4e6f-8465-adabefa9e6db"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("d04a88a6-d417-4e9a-b799-4479ff523759"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("713979cb-cbd5-4666-a3f2-6db4828edc4a"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("918e8011-8d92-46da-82a2-53b90e04cb39"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c2e2d429-d371-4b80-90ff-745ac24d3ef0"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("87e3b340-cd6a-49df-aed7-d646152dff9e"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("6d9b42c6-3c46-493f-896a-ce928431f9f7"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("17259384-2382-4fe2-b465-938081e870c3"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("8571b6fc-0103-4b00-8dca-e404d3b9bdd6"));
            OfferOfDecision = (ITTTextBox)AddControl(new Guid("b00b665d-9152-4ee6-9724-3b48ad3cb368"));
            Report = (ITTTextBox)AddControl(new Guid("91e6c034-f638-4a24-8906-9785a4ac2985"));
            AdditionalDecision = (ITTTextBox)AddControl(new Guid("9a620744-2ca0-4db5-8b49-ea06d838d3aa"));
            labelOfferOfDecision = (ITTLabel)AddControl(new Guid("887c29a2-fc3d-4fbe-ace8-090ec11f9b38"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("eb434879-14be-4aae-b86d-3a44b523dbd4"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("59351b13-8469-40bc-a5c9-4d28774e855e"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("e285ccd6-4bc5-45f7-bd23-52b90ab2820d"));
            labelAdditionalDecision = (ITTLabel)AddControl(new Guid("d1e15a37-63e2-419b-ab67-692238e415ea"));
            labelReport = (ITTLabel)AddControl(new Guid("43efe5da-e7f6-43e9-9486-9358434aca7c"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("3c3947c2-35cb-4eb2-92c9-aafd3889c5b2"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("fd2e437c-5898-4814-ab66-e95244256a4e"));
            base.InitializeControls();
        }

        public ExaminationApprovalExaminationForm() : base("EXAMINATIONAPPROVAL", "ExaminationApprovalExaminationForm")
        {
        }

        protected ExaminationApprovalExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}