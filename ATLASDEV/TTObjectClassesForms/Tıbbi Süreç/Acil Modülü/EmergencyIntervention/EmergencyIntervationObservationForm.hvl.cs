
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
    /// Acil Müdahale
    /// </summary>
    public partial class EmergencyIntervationObservationForm : EpisodeActionForm
    {
    /// <summary>
    /// Acil Hasta Müdahale İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.EmergencyIntervention _EmergencyIntervention
        {
            get { return (TTObjectClasses.EmergencyIntervention)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox BringerName;
        protected ITTLabel ttlabel1;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelResponsibleDoctor;
        protected ITTLabel labelResponsibleNurse;
        protected ITTCheckBox IsTraumaticPatient;
        protected ITTLabel labelDischargeTime;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox ResponsibleDoctor;
        protected ITTDateTimePicker EnteranceTime;
        protected ITTDateTimePicker DischargeTime;
        protected ITTObjectListBox ResponsibleNurse;
        protected ITTLabel labelEnteranceTime;
        protected ITTMaskedTextBox ttmaskedtextbox1;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTGrid GridDoctorGroup;
        protected ITTDateTimePickerColumn DoctorActionDate;
        protected ITTListBoxColumn DoctorListBoxColumn;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("80dc54df-1838-43b4-b528-1084121c8f33"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("3325d2c7-6471-4141-9f88-199941ebb8d7"));
            BringerName = (ITTTextBox)AddControl(new Guid("0a20f706-9c5c-41d6-9167-d7e515d000a8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d608fa4c-48ed-404a-9f5c-85046ac5447b"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("0d821a7e-ee1f-41d9-b32d-6b231837beed"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("e847215e-4fab-4217-b829-2fd8a93967e1"));
            labelResponsibleDoctor = (ITTLabel)AddControl(new Guid("2b68fd2b-9bf9-40a5-9751-5fa0e63ea156"));
            labelResponsibleNurse = (ITTLabel)AddControl(new Guid("60b24d5a-4bd8-460d-86f4-8e4d98e0ac16"));
            IsTraumaticPatient = (ITTCheckBox)AddControl(new Guid("12f150ba-8d1e-48d4-8173-ab5cfbdf5e8e"));
            labelDischargeTime = (ITTLabel)AddControl(new Guid("a414845d-b90e-4a00-abbd-916fb042f791"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("b5a20d45-4134-4c7a-8c55-318de7ffee3d"));
            ResponsibleDoctor = (ITTObjectListBox)AddControl(new Guid("28e6fb8c-4b6b-418d-8c55-fe062e573fc8"));
            EnteranceTime = (ITTDateTimePicker)AddControl(new Guid("8b58760b-9ffd-447f-89f9-de41b55e4b19"));
            DischargeTime = (ITTDateTimePicker)AddControl(new Guid("9143b2ea-3b4b-496b-b61f-04854191a7bf"));
            ResponsibleNurse = (ITTObjectListBox)AddControl(new Guid("8a71a060-eaa4-4fab-8f25-cbe255a35cba"));
            labelEnteranceTime = (ITTLabel)AddControl(new Guid("f24f507d-9acd-4051-9e22-cf6cf6b406ad"));
            ttmaskedtextbox1 = (ITTMaskedTextBox)AddControl(new Guid("887bd8db-9be0-4b6d-8de5-93bc27ebb6ec"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("1e058309-b279-4f1a-8429-c17333a4c5c0"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("6c723b3e-405e-4bf3-83be-75de3e99a1e0"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("e2b66dff-b97e-45aa-9fac-e916243dce56"));
            GridDoctorGroup = (ITTGrid)AddControl(new Guid("eb88b519-fc35-41e4-aab6-cb50a220d5a4"));
            DoctorActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("7bde4845-20e8-4c45-af52-39b9cfbe0b3c"));
            DoctorListBoxColumn = (ITTListBoxColumn)AddControl(new Guid("6571cec4-c9f6-41ed-955d-9add59518bda"));
            base.InitializeControls();
        }

        public EmergencyIntervationObservationForm() : base("EMERGENCYINTERVENTION", "EmergencyIntervationObservationForm")
        {
        }

        protected EmergencyIntervationObservationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}