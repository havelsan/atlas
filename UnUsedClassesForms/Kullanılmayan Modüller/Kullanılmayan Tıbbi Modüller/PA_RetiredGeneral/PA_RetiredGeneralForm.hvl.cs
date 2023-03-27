
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
    /// Emekli General/Amiral Kabulü
    /// </summary>
    public partial class PA_RetiredGeneralForm : PA_MilitaryRetiredForm
    {
    /// <summary>
    /// Emekli General/Amiral Kabulü
    /// </summary>
        protected TTObjectClasses.PA_RetiredGeneral _PA_RetiredGeneral
        {
            get { return (TTObjectClasses.PA_RetiredGeneral)_ttObject; }
        }

        public PA_RetiredGeneralForm() : base("PA_RETIREDGENERAL", "PA_RetiredGeneralForm")
        {
        }

        protected PA_RetiredGeneralForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}