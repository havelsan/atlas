
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
    /// Acil Hasta Kabul Formu
    /// </summary>
    public partial class PA_EmergencyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Acil Kabul
    /// </summary>
        protected TTObjectClasses.PA_Emergency _PA_Emergency
        {
            get { return (TTObjectClasses.PA_Emergency)_ttObject; }
        }

        public PA_EmergencyForm() : base("PA_EMERGENCY", "PA_EmergencyForm")
        {
        }

        protected PA_EmergencyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}