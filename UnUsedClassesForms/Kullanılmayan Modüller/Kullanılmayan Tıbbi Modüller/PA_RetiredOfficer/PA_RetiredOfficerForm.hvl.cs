
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
    /// Emekli Subay Kabulü
    /// </summary>
    public partial class PA_RetiredOfficerForm : PA_MilitaryRetiredForm
    {
    /// <summary>
    /// Emekli Subay Kabul 
    /// </summary>
        protected TTObjectClasses.PA_RetiredOfficer _PA_RetiredOfficer
        {
            get { return (TTObjectClasses.PA_RetiredOfficer)_ttObject; }
        }

        public PA_RetiredOfficerForm() : base("PA_RETIREDOFFICER", "PA_RetiredOfficerForm")
        {
        }

        protected PA_RetiredOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}