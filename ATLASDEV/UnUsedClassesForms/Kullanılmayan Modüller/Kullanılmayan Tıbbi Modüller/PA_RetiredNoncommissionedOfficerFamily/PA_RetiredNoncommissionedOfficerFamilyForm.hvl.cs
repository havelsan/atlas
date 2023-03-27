
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
    /// Emekli Astsubay Ailesi Kabulü
    /// </summary>
    public partial class PA_RetiredNoncommissionedOfficerFamilyForm : PA_MilitaryRetiredFamiliyForm
    {
    /// <summary>
    /// Emekli Astsubay Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_RetiredNoncommissionedOfficerFamily _PA_RetiredNoncommissionedOfficerFamily
        {
            get { return (TTObjectClasses.PA_RetiredNoncommissionedOfficerFamily)_ttObject; }
        }

        public PA_RetiredNoncommissionedOfficerFamilyForm() : base("PA_RETIREDNONCOMMISSIONEDOFFICERFAMILY", "PA_RetiredNoncommissionedOfficerFamilyForm")
        {
        }

        protected PA_RetiredNoncommissionedOfficerFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}