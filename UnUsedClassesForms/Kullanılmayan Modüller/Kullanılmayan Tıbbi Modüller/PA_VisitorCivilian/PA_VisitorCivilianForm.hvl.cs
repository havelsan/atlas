
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
    /// Misafir Sivil Kabulü
    /// </summary>
    public partial class PA_VisitorCivilianForm : PA_VisitorMilitaryForm
    {
    /// <summary>
    /// Misafir Sivil Kabulü
    /// </summary>
        protected TTObjectClasses.PA_VisitorCivilian _PA_VisitorCivilian
        {
            get { return (TTObjectClasses.PA_VisitorCivilian)_ttObject; }
        }

        public PA_VisitorCivilianForm() : base("PA_VISITORCIVILIAN", "PA_VisitorCivilianForm")
        {
        }

        protected PA_VisitorCivilianForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}