
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
    public partial class MuscleTestForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Adele Testi
    /// </summary>
        protected TTObjectClasses.MuscleTestForm _MuscleTestForm
        {
            get { return (TTObjectClasses.MuscleTestForm)_ttObject; }
        }

        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTLabel labelRotation;
        protected ITTEnumComboBox Rotation;
        protected ITTLabel labelAbduction;
        protected ITTEnumComboBox Abduction;
        protected ITTLabel labelFlexion;
        protected ITTEnumComboBox Flexion;
        protected ITTLabel labelExtension;
        protected ITTEnumComboBox Extension;
        override protected void InitializeControls()
        {
            labelCreationDate = (ITTLabel)AddControl(new Guid("fff5363e-7d1f-4b0f-969a-bbe26c100692"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("35e610ca-ed1b-4865-bd2c-f48d62e04e84"));
            labelCode = (ITTLabel)AddControl(new Guid("93e90808-205a-4552-b55c-89f747b99fa3"));
            Code = (ITTTextBox)AddControl(new Guid("b4833291-52f0-40fb-a858-2ec7a0f6caf4"));
            labelRotation = (ITTLabel)AddControl(new Guid("cbeab4a8-81ea-4b09-aebf-4d5e0e76ff69"));
            Rotation = (ITTEnumComboBox)AddControl(new Guid("3cc3def5-fa2b-4e76-9bda-743f58510108"));
            labelAbduction = (ITTLabel)AddControl(new Guid("90959785-fb59-4349-a216-b47968274c19"));
            Abduction = (ITTEnumComboBox)AddControl(new Guid("024bb5ce-e008-46f6-949c-b48a6e854f86"));
            labelFlexion = (ITTLabel)AddControl(new Guid("b57d9ea9-f413-46fa-8439-226910896a7a"));
            Flexion = (ITTEnumComboBox)AddControl(new Guid("678d6028-72e9-45fc-9cd8-333f22ecfa04"));
            labelExtension = (ITTLabel)AddControl(new Guid("1a7bb552-010a-4c0e-a4da-3522f684a2ee"));
            Extension = (ITTEnumComboBox)AddControl(new Guid("bd662250-da93-4066-9a4a-4d53a22136d7"));
            base.InitializeControls();
        }

        public MuscleTestForm() : base("MUSCLETESTFORM", "MuscleTestForm")
        {
        }

        protected MuscleTestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}