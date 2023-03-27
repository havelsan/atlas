
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
    public partial class PA_ContractedPrivateCandidateForm : PA_ContractedNoncommissionedCandidateForm
    {
    /// <summary>
    /// Sözleşmeli Er/Erbaş Adayı Kabulü
    /// </summary>
        protected TTObjectClasses.PA_ContractedPrivateCandidate _PA_ContractedPrivateCandidate
        {
            get { return (TTObjectClasses.PA_ContractedPrivateCandidate)_ttObject; }
        }

        public PA_ContractedPrivateCandidateForm() : base("PA_CONTRACTEDPRIVATECANDIDATE", "PA_ContractedPrivateCandidateForm")
        {
        }

        protected PA_ContractedPrivateCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}