
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
    public partial class PA_CivilCadetCandidateForm : PA_CadetCandidateForm
    {
    /// <summary>
    /// Sivil Öğrenci Adayı
    /// </summary>
        protected TTObjectClasses.PA_CivilCadetCandidate _PA_CivilCadetCandidate
        {
            get { return (TTObjectClasses.PA_CivilCadetCandidate)_ttObject; }
        }

        public PA_CivilCadetCandidateForm() : base("PA_CIVILCADETCANDIDATE", "PA_CivilCadetCandidateForm")
        {
        }

        protected PA_CivilCadetCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}