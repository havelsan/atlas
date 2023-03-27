
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
    /// Randevu Listesi
    /// </summary>
    public partial class AppointmentWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTObjectListBox AppointmentDefinition;
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        protected ITTListView MResources;
        protected ITTLabel lblSelectedUnits;
        protected ITTButton SelectButton;
        protected ITTTextBox PatientBox;
        protected ITTTextBox ActionID;
        protected ITTLabel lblPatient;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            AppointmentDefinition = (ITTObjectListBox)AddControl(new Guid("e77294dc-399d-4572-a46c-c2dfe8a9c0ac"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6638fc3e-e892-404a-9e85-20fbb91f8672"));
            StatusBox = (ITTComboBox)AddControl(new Guid("dedbd098-3eb9-4431-b4ce-4907e70e0c2f"));
            MResources = (ITTListView)AddControl(new Guid("37276536-ad44-4bb1-b57f-b280a1f67441"));
            lblSelectedUnits = (ITTLabel)AddControl(new Guid("1c2872d2-6f69-4fc1-a401-d953f07f96c3"));
            SelectButton = (ITTButton)AddControl(new Guid("173f4504-8871-4aa3-bb46-5d1611e16b06"));
            PatientBox = (ITTTextBox)AddControl(new Guid("65f4d21e-26d6-4b22-97c0-40cfa8a32ad7"));
            ActionID = (ITTTextBox)AddControl(new Guid("ce5dfec2-dda0-434c-873b-6718a8375042"));
            lblPatient = (ITTLabel)AddControl(new Guid("0c3f2205-3476-4f82-97bc-f28c50c8cd27"));
            ttbutton1 = (ITTButton)AddControl(new Guid("4a4d2dbd-a25a-4e6c-9e3c-2a933f88dc0e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("57e1bfcc-b90d-4203-b499-d0ce78c6300c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1ddd564b-f752-42c1-bc42-d17e26d97e02"));
            base.InitializeControls();
        }

        public AppointmentWLCriteriaForm() : base("AppointmentWLCriteriaForm")
        {
        }

        protected AppointmentWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}