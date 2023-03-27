
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
    /// Emekli Uzman Erbaş Ailesi Kabulü
    /// </summary>
    public partial class PA_RetiredExpertNonComFamilyForm : PA_MilitaryRetiredFamiliyForm
    {
    /// <summary>
    /// Emekli Uzman Erbaş Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_RetiredExpertNonComFamily _PA_RetiredExpertNonComFamily
        {
            get { return (TTObjectClasses.PA_RetiredExpertNonComFamily)_ttObject; }
        }

        public PA_RetiredExpertNonComFamilyForm() : base("PA_RETIREDEXPERTNONCOMFAMILY", "PA_RetiredExpertNonComFamilyForm")
        {
        }

        protected PA_RetiredExpertNonComFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}