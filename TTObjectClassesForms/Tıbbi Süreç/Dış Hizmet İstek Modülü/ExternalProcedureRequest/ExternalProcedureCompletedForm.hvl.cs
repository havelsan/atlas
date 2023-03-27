
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
    /// Dış XXXXXX Hizmet Sonuç
    /// </summary>
    public partial class ExternalProcedureCompletedForm : TTForm
    {
    /// <summary>
    /// Dış Hizmet İstek
    /// </summary>
        protected TTObjectClasses.ExternalProcedureRequest _ExternalProcedureRequest
        {
            get { return (TTObjectClasses.ExternalProcedureRequest)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel labelPreInformation;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTLabel ttlabel4;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid ProcedureGrid;
        protected ITTListBoxColumn ProcedureDefinition;
        protected ITTTextBoxColumn AccessionNumber;
        protected ITTTextBoxColumn Unit;
        protected ITTTextBoxColumn Result;
        protected ITTEnumComboBoxColumn TreatmentToothPosition;
        protected ITTTextBoxColumn ISBTUnitNumber;
        protected ITTTextBoxColumn ISBTElementCode;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox RequestedExternalHospital;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("be42fafc-1a9a-4e9f-bed3-b2dfd8e75084"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("494ffa33-6d18-4bf9-a10a-3607e5a23fa0"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("cd393c0f-9abb-41c0-a164-fdc74f6c4671"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("d38a233a-86f7-4af3-9c85-7cdc0fef0bcb"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("9a62cb93-6dfd-4499-8635-722922ece670"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("8c3fc97a-6e95-442f-bf05-55d58c350211"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("1c891d94-653e-4b2b-bbf3-b9e941ddafb7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c324223d-f9e4-47e6-bffc-d150f577c811"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b99aaa8c-7899-46a3-8620-539dbd3ba1c1"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("eed4b1ba-b689-4a14-af9b-30b0eb5c57d9"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("28dc1d0e-da70-4caf-90ad-61dd755348a0"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("6cef575a-2c42-4caa-a046-e9a1984c3709"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("2556c813-6ed8-41e6-aa97-a36245ff70b4"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("be6ca114-a85d-4bfd-9390-f50374f77b74"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("948def99-555c-437c-b35c-f03b87cc6d96"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("4da3cdf2-491b-41cd-ae27-2322fb537319"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("810cc0ce-054c-401c-ae0b-4f931852458e"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e9e16434-bf77-46fd-81fb-1f2aa24db373"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("a111362a-3c04-4ca7-8f79-f77918bcd39d"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("d5e7ead5-d37c-4fa9-8f93-d8e3bfd141de"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("81028540-960a-4e3a-a16a-222ac70e6803"));
            ProcedureGrid = (ITTGrid)AddControl(new Guid("4c97209a-236b-4874-828a-11e6f811956d"));
            ProcedureDefinition = (ITTListBoxColumn)AddControl(new Guid("55970070-06be-40c3-86b8-05288e0fff9e"));
            AccessionNumber = (ITTTextBoxColumn)AddControl(new Guid("386a5d06-1388-4e4a-9324-5004b3168eb0"));
            Unit = (ITTTextBoxColumn)AddControl(new Guid("e827bd03-6648-4bf3-b6d2-79ec0f9b382f"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("5e315a9d-24f7-454a-8645-479a01c01b54"));
            TreatmentToothPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("0a51d522-4995-46d4-800e-95fa98da51ca"));
            ISBTUnitNumber = (ITTTextBoxColumn)AddControl(new Guid("cebe1e91-e9cf-46ae-923e-36bfeef5fdd8"));
            ISBTElementCode = (ITTTextBoxColumn)AddControl(new Guid("8f0d2d90-fe5a-420f-bef2-268a4cdc4186"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7364de10-0282-46c4-8fe2-6325cb3c8852"));
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("0673f473-bedd-4ad8-af07-9bfbf6f98f85"));
            base.InitializeControls();
        }

        public ExternalProcedureCompletedForm() : base("EXTERNALPROCEDUREREQUEST", "ExternalProcedureCompletedForm")
        {
        }

        protected ExternalProcedureCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}