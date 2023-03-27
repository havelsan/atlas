
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
    /// Laboratuvar Cihaz Tanımı
    /// </summary>
    public partial class ObservationEquipmentDefinitionForm : TTForm
    {
    /// <summary>
    /// Cihaz
    /// </summary>
        protected TTObjectClasses.ResEquipment _ResEquipment
        {
            get { return (TTObjectClasses.ResEquipment)_ttObject; }
        }

        protected ITTLabel labelObservationUnit;
        protected ITTObjectListBox ObservationUnit;
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
            labelObservationUnit = (ITTLabel)AddControl(new Guid("864fa78b-3a9a-4a0a-8e54-5fe63b8a232d"));
            ObservationUnit = (ITTObjectListBox)AddControl(new Guid("70acef5f-7b00-42c8-975d-621d7b69f065"));
            labelAppointmentLimit = (ITTLabel)AddControl(new Guid("bebf72ba-1fa9-4d8d-8b49-19b470c2d3bc"));
            AppointmentLimit = (ITTTextBox)AddControl(new Guid("deed0bf1-8a51-4e88-b700-5e4431d2cfa8"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("877b2e45-1574-4afa-9a7e-0fde14c1b6cc"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("40a516e0-b455-4175-b3bb-b9b90f4ff93e"));
            Location = (ITTTextBox)AddControl(new Guid("6340d7ee-d9fb-4183-9d92-7734848513ad"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("288285d1-2a43-4cff-874b-16775b025556"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("625da3b3-e082-4c88-9198-4e67d163e806"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("450f00b8-5324-457f-9d7d-ba011a10155e"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("80da03d9-6607-44c8-a2fb-f97bff35270b"));
            labelLocation = (ITTLabel)AddControl(new Guid("2b3293f8-20fc-47e0-9ebc-1d793c882b63"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("8b3619ba-f185-4679-a2da-b0fb0865cfe6"));
            base.InitializeControls();
        }

        public ObservationEquipmentDefinitionForm() : base("RESEQUIPMENT", "ObservationEquipmentDefinitionForm")
        {
        }

        protected ObservationEquipmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}