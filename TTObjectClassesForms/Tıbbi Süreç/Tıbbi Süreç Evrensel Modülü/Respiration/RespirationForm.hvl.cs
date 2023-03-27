
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
    public partial class RespirationForm : TTForm
    {
        protected TTObjectClasses.Respiration _Respiration
        {
            get { return (TTObjectClasses.Respiration)_ttObject; }
        }

        protected ITTLabel labelValue;
        protected ITTTextBox Value;
        override protected void InitializeControls()
        {
            labelValue = (ITTLabel)AddControl(new Guid("3d18c8b1-7b82-4d79-a7c7-2b63cf94f43e"));
            Value = (ITTTextBox)AddControl(new Guid("fb19dcba-051d-4f4a-a3aa-c76bd988a723"));
            base.InitializeControls();
        }

        public RespirationForm() : base("RESPIRATION", "RespirationForm")
        {
        }

        protected RespirationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}