
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
    /// Emekli Subay Ailesi Kabulü
    /// </summary>
    public partial class PA_RetiredOfficerFamilyForm : PA_MilitaryRetiredFamiliyForm
    {
    /// <summary>
    /// Emekli Subay Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_RetiredOfficerFamily _PA_RetiredOfficerFamily
        {
            get { return (TTObjectClasses.PA_RetiredOfficerFamily)_ttObject; }
        }

        public PA_RetiredOfficerFamilyForm() : base("PA_RETIREDOFFICERFAMILY", "PA_RetiredOfficerFamilyForm")
        {
        }

        protected PA_RetiredOfficerFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}