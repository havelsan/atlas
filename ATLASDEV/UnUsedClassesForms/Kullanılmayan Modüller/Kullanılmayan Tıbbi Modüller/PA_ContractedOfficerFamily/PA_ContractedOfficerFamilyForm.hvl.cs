
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
    /// Sözleşmeli Subay Ailesi Kabulü
    /// </summary>
    public partial class PA_ContractedOfficerFamilyForm : PA_OfficerFamilyForm
    {
    /// <summary>
    /// Sözleşmeli Subay Ailesi Kabul
    /// </summary>
        protected TTObjectClasses.PA_ContractedOfficerFamily _PA_ContractedOfficerFamily
        {
            get { return (TTObjectClasses.PA_ContractedOfficerFamily)_ttObject; }
        }

        public PA_ContractedOfficerFamilyForm() : base("PA_CONTRACTEDOFFICERFAMILY", "PA_ContractedOfficerFamilyForm")
        {
        }

        protected PA_ContractedOfficerFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}