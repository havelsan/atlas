
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
    /// Sivil Ücretsiz Kabulü
    /// </summary>
    public partial class PA_UnpaidCivilianForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sivil Ücretsiz Kabul 
    /// </summary>
        protected TTObjectClasses.PA_UnpaidCivilian _PA_UnpaidCivilian
        {
            get { return (TTObjectClasses.PA_UnpaidCivilian)_ttObject; }
        }

        protected ITTCheckBox IsRelativeOfSoldier;
        override protected void InitializeControls()
        {
            IsRelativeOfSoldier = (ITTCheckBox)AddControl(new Guid("686cbf59-4445-41f0-87f5-cd574abbc1b6"));
            base.InitializeControls();
        }

        public PA_UnpaidCivilianForm() : base("PA_UNPAIDCIVILIAN", "PA_UnpaidCivilianForm")
        {
        }

        protected PA_UnpaidCivilianForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}