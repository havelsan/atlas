
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
    /// Genel Cihaz Tanımları
    /// </summary>
    public partial class ClinicEquipmentDefinitionForm : TTForm
    {
    /// <summary>
    /// Cihaz
    /// </summary>
        protected TTObjectClasses.ResEquipment _ResEquipment
        {
            get { return (TTObjectClasses.ResEquipment)_ttObject; }
        }

        protected ITTLabel labelClinic;
        protected ITTObjectListBox Clinic;
        protected ITTLabel labelAppointmentLimit;
        protected ITTTextBox AppointmentLimit;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelClinic = (ITTLabel)AddControl(new Guid("8c651f27-1bbe-4720-bba1-d602668aef12"));
            Clinic = (ITTObjectListBox)AddControl(new Guid("ac3eeca1-c2aa-4445-8388-d49c998e6825"));
            labelAppointmentLimit = (ITTLabel)AddControl(new Guid("7ec69ab4-c56f-49b5-84e2-ec07ae06be9a"));
            AppointmentLimit = (ITTTextBox)AddControl(new Guid("6e1a3524-2098-434a-a465-7e3fab0521d7"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a32d7a59-1b35-41f1-afca-3b5f7cd19d29"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("2e066a27-d9da-4b30-a698-43d70808f7c8"));
            Location = (ITTTextBox)AddControl(new Guid("2be36815-487a-4968-b617-d102033e6ced"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("6dc40cd7-08e3-4777-a8a2-6d82cac34284"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cab6a248-920b-4fa4-bc13-2b2710f6a052"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("99032665-4543-48cc-99c4-9aad4e03ca27"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("4d44d2d1-9ac8-4c83-b9ac-faed3fe3cf72"));
            labelLocation = (ITTLabel)AddControl(new Guid("e55a5674-0917-4a08-9ffe-3ca41a067d73"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("0980876c-d760-4990-ba1a-8ef90b221466"));
            base.InitializeControls();
        }

        public ClinicEquipmentDefinitionForm() : base("RESEQUIPMENT", "ClinicEquipmentDefinitionForm")
        {
        }

        protected ClinicEquipmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}