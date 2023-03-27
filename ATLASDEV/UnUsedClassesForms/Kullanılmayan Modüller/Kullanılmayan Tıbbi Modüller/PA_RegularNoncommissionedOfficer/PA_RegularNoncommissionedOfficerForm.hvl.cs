
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
    /// Muvazzaf Astsubay Adayı Kabulü
    /// </summary>
    public partial class PA_RegularNoncommissionedOfficerForm : PA_CadetCandidateForm
    {
    /// <summary>
    /// Muvazzaf Astsubay Adayı Kabul
    /// </summary>
        protected TTObjectClasses.PA_RegularNoncommissionedOfficer _PA_RegularNoncommissionedOfficer
        {
            get { return (TTObjectClasses.PA_RegularNoncommissionedOfficer)_ttObject; }
        }

        public PA_RegularNoncommissionedOfficerForm() : base("PA_REGULARNONCOMMISSIONEDOFFICER", "PA_RegularNoncommissionedOfficerForm")
        {
        }

        protected PA_RegularNoncommissionedOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}