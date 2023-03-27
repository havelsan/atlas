
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
    public partial class BloodPressureForm : TTForm
    {
        protected TTObjectClasses.BloodPressure _BloodPressure
        {
            get { return (TTObjectClasses.BloodPressure)_ttObject; }
        }

        protected ITTLabel labelDiastolik;
        protected ITTTextBox Diastolik;
        protected ITTTextBox Sistolik;
        protected ITTLabel labelSistolik;
        override protected void InitializeControls()
        {
            labelDiastolik = (ITTLabel)AddControl(new Guid("f3526c91-c337-4abc-82c1-d027826a4833"));
            Diastolik = (ITTTextBox)AddControl(new Guid("2f9d27a8-535b-4d42-a923-f0e4127497c1"));
            Sistolik = (ITTTextBox)AddControl(new Guid("f52a3ef5-842e-46e7-8a15-6f52151efb6a"));
            labelSistolik = (ITTLabel)AddControl(new Guid("81a61ac0-b307-4732-848a-19eff99d603f"));
            base.InitializeControls();
        }

        public BloodPressureForm() : base("BLOODPRESSURE", "BloodPressureForm")
        {
        }

        protected BloodPressureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}