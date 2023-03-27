
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
    /// Dış Ambulans İşlemleri
    /// </summary>
    public partial class ExteriorAmbulanceForm : ActionForm
    {
    /// <summary>
    /// Dış Ambulans Modülü
    /// </summary>
        protected TTObjectClasses.ExteriorAmbulance _ExteriorAmbulance
        {
            get { return (TTObjectClasses.ExteriorAmbulance)_ttObject; }
        }

        protected ITTTextBox AmbulancePlate;
        protected ITTEnumComboBox AmbulanceType;
        protected ITTLabel labelAmbulanceType;
        protected ITTLabel labelAmbulanceName;
        protected ITTLabel labelNote;
        protected ITTDateTimePicker EnteranceTime;
        protected ITTTextBox AmbulanceName;
        protected ITTLabel labelAmbulancePlate;
        protected ITTLabel labelEnteranceTime;
        protected ITTTextBox Note;
        override protected void InitializeControls()
        {
            AmbulancePlate = (ITTTextBox)AddControl(new Guid("fe3a66a7-1717-4353-b993-3913dcc5c96f"));
            AmbulanceType = (ITTEnumComboBox)AddControl(new Guid("d0c5853f-f919-4b36-879a-5a390854f98e"));
            labelAmbulanceType = (ITTLabel)AddControl(new Guid("29306b41-ac98-4d6e-965a-5b79e78eb310"));
            labelAmbulanceName = (ITTLabel)AddControl(new Guid("4943f2a3-69a6-42bd-8155-6ab42fefee27"));
            labelNote = (ITTLabel)AddControl(new Guid("a197b253-e6ee-4fc8-9f89-9c1f9b31356c"));
            EnteranceTime = (ITTDateTimePicker)AddControl(new Guid("1848e38a-d248-4ab6-9b91-9e2357fd090c"));
            AmbulanceName = (ITTTextBox)AddControl(new Guid("6940d644-7ddf-46c3-a729-c2dc5a5d92a6"));
            labelAmbulancePlate = (ITTLabel)AddControl(new Guid("5183dec4-9e45-404e-9d0b-cfa5813ed29b"));
            labelEnteranceTime = (ITTLabel)AddControl(new Guid("d60f86fb-ce98-4a15-aeb0-e69eb3ea5c14"));
            Note = (ITTTextBox)AddControl(new Guid("10c7a759-6f0e-48cc-bf59-f71d6403a6c4"));
            base.InitializeControls();
        }

        public ExteriorAmbulanceForm() : base("EXTERIORAMBULANCE", "ExteriorAmbulanceForm")
        {
        }

        protected ExteriorAmbulanceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}