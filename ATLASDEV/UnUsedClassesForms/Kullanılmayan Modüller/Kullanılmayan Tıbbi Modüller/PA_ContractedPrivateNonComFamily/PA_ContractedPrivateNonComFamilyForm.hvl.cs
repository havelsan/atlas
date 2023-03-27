
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
    /// Sözleşmeli Er/Erbaş Ailesi Kabulü
    /// </summary>
    public partial class PA_ContractedPrivateNonComFamilyForm : PA_ExpertNonComFamilyForm
    {
    /// <summary>
    /// Sözleşmeli Er/Erbaş Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_ContractedPrivateNonComFamily _PA_ContractedPrivateNonComFamily
        {
            get { return (TTObjectClasses.PA_ContractedPrivateNonComFamily)_ttObject; }
        }

        public PA_ContractedPrivateNonComFamilyForm() : base("PA_CONTRACTEDPRIVATENONCOMFAMILY", "PA_ContractedPrivateNonComFamilyForm")
        {
        }

        protected PA_ContractedPrivateNonComFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}