
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
    /// Acil Hasta Müdahale
    /// </summary>
    public partial class EmergencyInterventionAdmissionForm : EpisodeActionForm
    {
    /// <summary>
    /// Acil Hasta Müdahale İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.EmergencyIntervention _EmergencyIntervention
        {
            get { return (TTObjectClasses.EmergencyIntervention)_ttObject; }
        }

        protected ITTCheckBox IsEmergencyInjured;
        protected ITTCheckBox IsEmergencyDispatched;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox BringerName;
        protected ITTMaskedTextBox BringerPhone;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelEnteranceTime;
        protected ITTDateTimePicker EnteranceTime;
        override protected void InitializeControls()
        {
            IsEmergencyInjured = (ITTCheckBox)AddControl(new Guid("da9aea93-bde4-401f-8986-2094b0496515"));
            IsEmergencyDispatched = (ITTCheckBox)AddControl(new Guid("ac6befa8-1d41-4d59-8f6e-bc9d902189c3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("0b39ad39-2530-4f40-b330-a88306a7e45c"));
            BringerName = (ITTTextBox)AddControl(new Guid("c9dfa09a-6f0d-4212-b544-6904e27472bd"));
            BringerPhone = (ITTMaskedTextBox)AddControl(new Guid("27d26bd4-985f-4648-8cdc-3f17948c21bb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4a5b233a-d1ef-4bd8-b6ae-90a962e89181"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ae0c4de8-a5a2-458c-a83c-4ac115040957"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cc703769-3614-48e2-abde-51788d48be4c"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("36c1949f-421f-4a6c-a799-b7552f70f2ac"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("5d99d2ac-ee5e-46dc-a038-e6388decd4dd"));
            labelEnteranceTime = (ITTLabel)AddControl(new Guid("89e99bac-1261-425c-a56b-415b84b84280"));
            EnteranceTime = (ITTDateTimePicker)AddControl(new Guid("8135c364-e607-4393-b5bd-ed15372d3fcc"));
            base.InitializeControls();
        }

        public EmergencyInterventionAdmissionForm() : base("EMERGENCYINTERVENTION", "EmergencyInterventionAdmissionForm")
        {
        }

        protected EmergencyInterventionAdmissionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}