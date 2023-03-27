
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
    /// Misafir XXXXXX Sivil Memur-İşçi Ailesi Kabulü
    /// </summary>
    public partial class PA_VisitorMilitaryCivilOfficialFamilyForm : PA_VisitorMilitaryFamiliyForm
    {
    /// <summary>
    /// Misafir XXXXXX Sivil Memur-İşçi Ailesi Kabulü
    /// </summary>
        protected TTObjectClasses.PA_VisitorMilitaryCivilOfficialFamily _PA_VisitorMilitaryCivilOfficialFamily
        {
            get { return (TTObjectClasses.PA_VisitorMilitaryCivilOfficialFamily)_ttObject; }
        }

        public PA_VisitorMilitaryCivilOfficialFamilyForm() : base("PA_VISITORMILITARYCIVILOFFICIALFAMILY", "PA_VisitorMilitaryCivilOfficialFamilyForm")
        {
        }

        protected PA_VisitorMilitaryCivilOfficialFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}