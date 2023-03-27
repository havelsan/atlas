
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
    /// Emekli Uzman Erbaş Kabulü
    /// </summary>
    public partial class PA_RetiredExpertNonComForm : PA_MilitaryRetiredForm
    {
    /// <summary>
    /// Emekli Uzman Erbaş Kabul 
    /// </summary>
        protected TTObjectClasses.PA_RetiredExpertNonCom _PA_RetiredExpertNonCom
        {
            get { return (TTObjectClasses.PA_RetiredExpertNonCom)_ttObject; }
        }

        public PA_RetiredExpertNonComForm() : base("PA_RETIREDEXPERTNONCOM", "PA_RetiredExpertNonComForm")
        {
        }

        protected PA_RetiredExpertNonComForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}