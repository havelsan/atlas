
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
    public partial class RTFDefinitionsBySpecialityForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.RTFDefinitionsBySpeciality _RTFDefinitionsBySpeciality
        {
            get { return (TTObjectClasses.RTFDefinitionsBySpeciality)_ttObject; }
        }

        protected ITTLabel labelSpeciality;
        protected ITTObjectListBox Speciality;
        protected ITTLabel labelTitle;
        protected ITTTextBox Title;
        protected ITTCheckBox IsNeedForEpicrisis;
        override protected void InitializeControls()
        {
            labelSpeciality = (ITTLabel)AddControl(new Guid("e62805af-4af9-49cb-8e84-e270dbac55c6"));
            Speciality = (ITTObjectListBox)AddControl(new Guid("40afdcf7-38a0-485e-8226-db23335576a5"));
            labelTitle = (ITTLabel)AddControl(new Guid("b0b9a353-19b8-431f-b09d-92da66b32cbc"));
            Title = (ITTTextBox)AddControl(new Guid("37e75979-8b02-4194-94a8-515398eb472d"));
            IsNeedForEpicrisis = (ITTCheckBox)AddControl(new Guid("ac46677c-d0ae-4bb3-951e-75bb6934f747"));
            base.InitializeControls();
        }

        public RTFDefinitionsBySpecialityForm() : base("RTFDEFINITIONSBYSPECIALITY", "RTFDefinitionsBySpecialityForm")
        {
        }

        protected RTFDefinitionsBySpecialityForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}