
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
    /// Emekli General/ Amiral Ailesi Kabulü
    /// </summary>
    public partial class PA_RetiredGeneralFamilyForm : PA_MilitaryRetiredFamiliyForm
    {
    /// <summary>
    /// Emekli General/Amiral Ailesi Kabulü
    /// </summary>
        protected TTObjectClasses.PA_RetiredGeneralFamily _PA_RetiredGeneralFamily
        {
            get { return (TTObjectClasses.PA_RetiredGeneralFamily)_ttObject; }
        }

        public PA_RetiredGeneralFamilyForm() : base("PA_RETIREDGENERALFAMILY", "PA_RetiredGeneralFamilyForm")
        {
        }

        protected PA_RetiredGeneralFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}