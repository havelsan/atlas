
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
    /// Sözleşmeli Er/Erbaş Kabul Formu
    /// </summary>
    public partial class PA_ContractedPrivateNonComForm : PA_ExpertNonComForm
    {
    /// <summary>
    /// Sözleşmeli Er/Erbaş Kabul 
    /// </summary>
        protected TTObjectClasses.PA_ContractedPrivateNonCom _PA_ContractedPrivateNonCom
        {
            get { return (TTObjectClasses.PA_ContractedPrivateNonCom)_ttObject; }
        }

        public PA_ContractedPrivateNonComForm() : base("PA_CONTRACTEDPRIVATENONCOM", "PA_ContractedPrivateNonComForm")
        {
        }

        protected PA_ContractedPrivateNonComForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}