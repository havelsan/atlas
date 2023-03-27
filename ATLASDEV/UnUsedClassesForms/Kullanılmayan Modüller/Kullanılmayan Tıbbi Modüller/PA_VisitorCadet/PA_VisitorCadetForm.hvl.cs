
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
    /// Misafir XXXXXX Öğrenci Kabulü
    /// </summary>
    public partial class PA_VisitorCadetForm : PA_VisitorMilitaryForm
    {
    /// <summary>
    /// Misafir XXXXXX Öğrenci Kabul 
    /// </summary>
        protected TTObjectClasses.PA_VisitorCadet _PA_VisitorCadet
        {
            get { return (TTObjectClasses.PA_VisitorCadet)_ttObject; }
        }

        public PA_VisitorCadetForm() : base("PA_VISITORCADET", "PA_VisitorCadetForm")
        {
        }

        protected PA_VisitorCadetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}