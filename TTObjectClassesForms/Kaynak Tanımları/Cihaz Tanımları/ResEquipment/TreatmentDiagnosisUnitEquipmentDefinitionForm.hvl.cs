
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
    /// Tedavi Ünitesi Cihaz Tanımı
    /// </summary>
    public partial class TreatmentDiagnosisUnitEquipmentDefinitionForm : TTForm
    {
    /// <summary>
    /// Cihaz
    /// </summary>
        protected TTObjectClasses.ResEquipment _ResEquipment
        {
            get { return (TTObjectClasses.ResEquipment)_ttObject; }
        }

        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
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
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("ca28a50e-c7c3-410b-ace3-599eb77a994c"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("e7f5e8d6-2291-4636-8b8e-986c872a7826"));
            labelAppointmentLimit = (ITTLabel)AddControl(new Guid("b3e6fab1-17e3-42d4-947f-92d8deed4b17"));
            AppointmentLimit = (ITTTextBox)AddControl(new Guid("6bb03e9e-0f64-43fe-be52-46a72e06417b"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("28baa3c2-821a-4896-8937-965346159e84"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("cc8304ec-dacf-4cd0-bd47-b7a871a8c2e7"));
            Location = (ITTTextBox)AddControl(new Guid("42445c4d-50e2-452d-95e4-ae92f527e0c1"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("bcbb8858-555a-44b1-9014-c4ea6e4b918a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("54a7f0fb-35f3-45b2-ac43-4129e62c63a8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0530b344-c92c-4cff-93b7-f45232f648af"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("87efca86-3b99-4d2f-9687-000b731353de"));
            labelLocation = (ITTLabel)AddControl(new Guid("28298113-ed01-48b5-8cab-1fb8e38272a6"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("496d043c-4e34-4bc2-952c-0d7497229a51"));
            base.InitializeControls();
        }

        public TreatmentDiagnosisUnitEquipmentDefinitionForm() : base("RESEQUIPMENT", "TreatmentDiagnosisUnitEquipmentDefinitionForm")
        {
        }

        protected TreatmentDiagnosisUnitEquipmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}