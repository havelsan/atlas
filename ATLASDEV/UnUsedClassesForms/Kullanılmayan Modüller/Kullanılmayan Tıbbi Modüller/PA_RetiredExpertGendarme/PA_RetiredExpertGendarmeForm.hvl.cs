
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
    /// Emekli Uzman Jandarma Kabulü
    /// </summary>
    public partial class PA_RetiredExpertGendarmeForm : PA_MilitaryRetiredForm
    {
    /// <summary>
    /// Emekli Uzman Jandarma Kabul 
    /// </summary>
        protected TTObjectClasses.PA_RetiredExpertGendarme _PA_RetiredExpertGendarme
        {
            get { return (TTObjectClasses.PA_RetiredExpertGendarme)_ttObject; }
        }

        public PA_RetiredExpertGendarmeForm() : base("PA_RETIREDEXPERTGENDARME", "PA_RetiredExpertGendarmeForm")
        {
        }

        protected PA_RetiredExpertGendarmeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}