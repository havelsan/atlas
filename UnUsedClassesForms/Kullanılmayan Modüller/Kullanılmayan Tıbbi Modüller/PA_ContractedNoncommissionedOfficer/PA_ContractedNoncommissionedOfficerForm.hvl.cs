
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
    /// Sözleşmeli Astsubay Kabulü
    /// </summary>
    public partial class PA_ContractedNoncommissionedOfficerForm : PA_NoncommissionedOfficerForm
    {
    /// <summary>
    /// Sözleşmeli Astsubay Kabul
    /// </summary>
        protected TTObjectClasses.PA_ContractedNoncommissionedOfficer _PA_ContractedNoncommissionedOfficer
        {
            get { return (TTObjectClasses.PA_ContractedNoncommissionedOfficer)_ttObject; }
        }

        public PA_ContractedNoncommissionedOfficerForm() : base("PA_CONTRACTEDNONCOMMISSIONEDOFFICER", "PA_ContractedNoncommissionedOfficerForm")
        {
        }

        protected PA_ContractedNoncommissionedOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}