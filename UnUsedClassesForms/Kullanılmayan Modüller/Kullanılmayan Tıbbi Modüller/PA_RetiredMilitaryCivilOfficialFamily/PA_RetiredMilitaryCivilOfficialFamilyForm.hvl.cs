
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
    /// Emekli  Sivil Memur Ailesi Kabul
    /// </summary>
    public partial class PA_RetiredMilitaryCivilOfficialFamilyForm : PA_MilitaryRetiredFamiliyForm
    {
    /// <summary>
    /// Emekli Sivil Memur Ailesi Kabulü
    /// </summary>
        protected TTObjectClasses.PA_RetiredMilitaryCivilOfficialFamily _PA_RetiredMilitaryCivilOfficialFamily
        {
            get { return (TTObjectClasses.PA_RetiredMilitaryCivilOfficialFamily)_ttObject; }
        }

        protected ITTLabel labelMilitaryCivilOfficeStatus;
        protected ITTEnumComboBox MilitaryCivilOfficeStatus;
        override protected void InitializeControls()
        {
            labelMilitaryCivilOfficeStatus = (ITTLabel)AddControl(new Guid("ec2805cd-b6d2-409a-a482-4aa67a9ef429"));
            MilitaryCivilOfficeStatus = (ITTEnumComboBox)AddControl(new Guid("05cec612-97bd-40ff-85d7-f12fa8bf77da"));
            base.InitializeControls();
        }

        public PA_RetiredMilitaryCivilOfficialFamilyForm() : base("PA_RETIREDMILITARYCIVILOFFICIALFAMILY", "PA_RetiredMilitaryCivilOfficialFamilyForm")
        {
        }

        protected PA_RetiredMilitaryCivilOfficialFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}