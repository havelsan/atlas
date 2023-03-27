
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
    /// Muvazzaf Subay Adayı Kabulü
    /// </summary>
    public partial class PA_RegularOfficerCandidateForm : PA_CadetCandidateForm
    {
    /// <summary>
    /// Muvazzaf Subay Adayı Kabul
    /// </summary>
        protected TTObjectClasses.PA_RegularOfficerCandidate _PA_RegularOfficerCandidate
        {
            get { return (TTObjectClasses.PA_RegularOfficerCandidate)_ttObject; }
        }

        public PA_RegularOfficerCandidateForm() : base("PA_REGULAROFFICERCANDIDATE", "PA_RegularOfficerCandidateForm")
        {
        }

        protected PA_RegularOfficerCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}