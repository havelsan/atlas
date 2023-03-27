
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
    /// Misafir Erbaş/Er Kabulü
    /// </summary>
    public partial class PA_VisitorPrivateNonComForm : PA_VisitorMilitaryForm
    {
    /// <summary>
    /// Misafir Erbaş/Er Kabulü
    /// </summary>
        protected TTObjectClasses.PA_VisitorPrivateNonCom _PA_VisitorPrivateNonCom
        {
            get { return (TTObjectClasses.PA_VisitorPrivateNonCom)_ttObject; }
        }

        public PA_VisitorPrivateNonComForm() : base("PA_VISITORPRIVATENONCOM", "PA_VisitorPrivateNonComForm")
        {
        }

        protected PA_VisitorPrivateNonComForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}