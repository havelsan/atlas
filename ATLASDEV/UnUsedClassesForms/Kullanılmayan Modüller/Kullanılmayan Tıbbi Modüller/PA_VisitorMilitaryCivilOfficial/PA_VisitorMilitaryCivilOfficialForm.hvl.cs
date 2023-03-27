
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
    /// Misafir XXXXXX Sivil Memur-İşçi Kabulü
    /// </summary>
    public partial class PA_VisitorMilitaryCivilOfficialForm : PA_VisitorMilitaryForm
    {
    /// <summary>
    /// Misafir XXXXXX Sivil Memur-İşçi Kabulü
    /// </summary>
        protected TTObjectClasses.PA_VisitorMilitaryCivilOfficial _PA_VisitorMilitaryCivilOfficial
        {
            get { return (TTObjectClasses.PA_VisitorMilitaryCivilOfficial)_ttObject; }
        }

        public PA_VisitorMilitaryCivilOfficialForm() : base("PA_VISITORMILITARYCIVILOFFICIAL", "PA_VisitorMilitaryCivilOfficialForm")
        {
        }

        protected PA_VisitorMilitaryCivilOfficialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}