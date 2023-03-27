
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
    /// Emekli Uzman Jandarma Ailesi Kabulü
    /// </summary>
    public partial class PA_RetiredExpertGendarmeFamilyForm : PA_MilitaryRetiredFamiliyForm
    {
    /// <summary>
    /// Emekli Uzman Jandarma Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_RetiredExpertGendarmeFamily _PA_RetiredExpertGendarmeFamily
        {
            get { return (TTObjectClasses.PA_RetiredExpertGendarmeFamily)_ttObject; }
        }

        public PA_RetiredExpertGendarmeFamilyForm() : base("PA_RETIREDEXPERTGENDARMEFAMILY", "PA_RetiredExpertGendarmeFamilyForm")
        {
        }

        protected PA_RetiredExpertGendarmeFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}