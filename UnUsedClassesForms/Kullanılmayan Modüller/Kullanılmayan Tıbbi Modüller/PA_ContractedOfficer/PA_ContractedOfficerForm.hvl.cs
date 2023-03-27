
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
    /// Sözleşmeli Subay Kabulü
    /// </summary>
    public partial class PA_ContractedOfficerForm : PA_OfficerForm
    {
    /// <summary>
    /// Sözleşmeli Subay Kabul
    /// </summary>
        protected TTObjectClasses.PA_ContractedOfficer _PA_ContractedOfficer
        {
            get { return (TTObjectClasses.PA_ContractedOfficer)_ttObject; }
        }

        public PA_ContractedOfficerForm() : base("PA_CONTRACTEDOFFICER", "PA_ContractedOfficerForm")
        {
        }

        protected PA_ContractedOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}