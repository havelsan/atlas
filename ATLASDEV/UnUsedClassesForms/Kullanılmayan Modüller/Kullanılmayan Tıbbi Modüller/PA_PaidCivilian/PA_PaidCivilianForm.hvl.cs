
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
    /// Sivil Ücretli Kabul 
    /// </summary>
    public partial class PA_PaidCivilianForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sivil Ücretli Kabul 
    /// </summary>
        protected TTObjectClasses.PA_PaidCivilian _PA_PaidCivilian
        {
            get { return (TTObjectClasses.PA_PaidCivilian)_ttObject; }
        }

        protected ITTCheckBox IsRelativeOfSoldier;
        override protected void InitializeControls()
        {
            IsRelativeOfSoldier = (ITTCheckBox)AddControl(new Guid("63cb8e6d-8b5c-4cef-973e-e31b6c9909e5"));
            base.InitializeControls();
        }

        public PA_PaidCivilianForm() : base("PA_PAIDCIVILIAN", "PA_PaidCivilianForm")
        {
        }

        protected PA_PaidCivilianForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}