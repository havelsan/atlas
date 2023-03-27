
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
    /// Dış XXXXXX Hizmet Ana Formu
    /// </summary>
    public partial class ExternalProcedureBaseForm : TTForm
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
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox RequestedExternalHospital;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("e250bfef-d608-4bd1-bf1a-fb7fdb89da6e"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("80c3e873-c6c4-4bb2-8b8f-a77aeb41f2ee"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("1813645b-8b25-4e9d-ae72-ad1f2dd7593e"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("4fdaf284-023c-4857-b442-a0d07ccee7c4"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("37d9c6a3-da35-4141-9d70-96d7afeafddf"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c5af17a8-e1b6-40b0-9cd1-13954de8191f"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("fc56d605-d0de-4df8-83bd-8b0a9762e7da"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f1e775c7-64e0-44bf-bb50-8dbb508d65ad"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e2127157-86dd-4549-92ca-6550a2c508d3"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("11d4ebe4-7311-4385-8178-7623a76e5f70"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("42ca3389-ea8a-4964-bed9-1dffd27cf2aa"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("34481df0-c18a-4838-9d5f-67a610db4f20"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("4f3814e1-d3f8-4e4b-8319-9ff4cc93d792"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("8a0091a3-2fbb-4725-b348-05646ae451ea"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("8fc43911-9f93-4645-9c29-1476ebc17b2a"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1293f22f-d239-442b-83b4-f9729b1c1c51"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("19be0bee-df48-4524-88a2-c79e419d9be5"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("072f0459-08a6-4842-a759-eaa9e50ae1ac"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("2d1f899a-da59-4d9d-99db-274e319d26a0"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("b489ce2f-c816-4621-a29a-e892dcae890b"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("4c85bd82-bb15-4819-be4f-f8111c690d95"));
            ProcedureGrid = (ITTGrid)AddControl(new Guid("02a7c129-419b-4197-936a-c325edf9e174"));
            ProcedureDefinition = (ITTListBoxColumn)AddControl(new Guid("e2658839-43f7-45e6-889d-883df4d8bec9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("bb0edd32-9733-44ee-af8f-734ff4ad4826"));
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("6b73399c-521b-461b-ab6d-4ddb38b2f773"));
            base.InitializeControls();
        }

        public ExternalProcedureBaseForm() : base("EXTERNALPROCEDUREREQUEST", "ExternalProcedureBaseForm")
        {
        }

        protected ExternalProcedureBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}