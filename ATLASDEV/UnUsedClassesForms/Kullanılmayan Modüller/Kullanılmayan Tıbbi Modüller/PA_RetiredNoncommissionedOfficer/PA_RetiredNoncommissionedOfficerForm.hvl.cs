
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
    /// Emekli Astsubay Kabulü
    /// </summary>
    public partial class PA_RetiredNoncommissionedOfficerForm : PA_MilitaryRetiredForm
    {
    /// <summary>
    /// Emekli Astsubay Kabul
    /// </summary>
        protected TTObjectClasses.PA_RetiredNoncommissionedOfficer _PA_RetiredNoncommissionedOfficer
        {
            get { return (TTObjectClasses.PA_RetiredNoncommissionedOfficer)_ttObject; }
        }

        public PA_RetiredNoncommissionedOfficerForm() : base("PA_RETIREDNONCOMMISSIONEDOFFICER", "PA_RetiredNoncommissionedOfficerForm")
        {
        }

        protected PA_RetiredNoncommissionedOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}