
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
    /// Kayıt Kabul Tanımı
    /// </summary>
    public partial class PatientAddmissionUnitDefinitionForm : TTForm
    {
    /// <summary>
    /// Hasta Kabul Birimi
    /// </summary>
        protected TTObjectClasses.ResPatientAddmissionUnit _ResPatientAddmissionUnit
        {
            get { return (TTObjectClasses.ResPatientAddmissionUnit)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelStore;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTObjectListBox Hospital;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("6a7e860e-5921-4372-9835-37eda550a336"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("17a3251e-9519-41d9-9741-0abec149a00d"));
            Location = (ITTTextBox)AddControl(new Guid("6db1a42c-aced-4236-ae3c-7729b26e4c99"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("6fa8c08c-1815-4aef-8bb3-cf9763baee03"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bb6c857b-7be2-4a04-a94f-e8b9c3fda66c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1f5e9084-edb6-437e-b283-834013c4eba5"));
            labelStore = (ITTLabel)AddControl(new Guid("64e74a4a-50f2-43e7-89f0-aba2b60befd5"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("9ef51b48-2cb1-4f12-9913-b9206efeb77f"));
            Store = (ITTObjectListBox)AddControl(new Guid("9f60a494-1baa-40dd-8c87-dfdf6f627cc6"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("639878a7-d141-433f-ac45-d685eab799b6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("fd97c7ab-2660-4f5f-b2d2-f7b3cc13cb07"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("dcc6907b-d56e-47b4-8789-1a43277f2827"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("18cd08bb-d43e-459b-8929-eaa82eb1170e"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("eab6241e-45d4-447b-9819-e082b3dceffe"));
            labelLocation = (ITTLabel)AddControl(new Guid("c8ac0ce8-eafc-4b00-b50f-c8ea0b2cdc65"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("b9b0d19a-285e-450f-954d-d979777ef1da"));
            base.InitializeControls();
        }

        public PatientAddmissionUnitDefinitionForm() : base("RESPATIENTADDMISSIONUNIT", "PatientAddmissionUnitDefinitionForm")
        {
        }

        protected PatientAddmissionUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}