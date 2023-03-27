
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
    /// Emekli Sivil Memuri Kabulü
    /// </summary>
    public partial class PA_RetiredMilitaryCivilOfficialForm : PA_MilitaryRetiredForm
    {
    /// <summary>
    /// Emekli Sivil Memur Kabulü
    /// </summary>
        protected TTObjectClasses.PA_RetiredMilitaryCivilOfficial _PA_RetiredMilitaryCivilOfficial
        {
            get { return (TTObjectClasses.PA_RetiredMilitaryCivilOfficial)_ttObject; }
        }

        protected ITTLabel labelMilitaryCivilOfficeStatus;
        protected ITTEnumComboBox MilitaryCivilOfficeStatus;
        override protected void InitializeControls()
        {
            labelMilitaryCivilOfficeStatus = (ITTLabel)AddControl(new Guid("4dacf350-6262-4728-863b-b462b2c482dd"));
            MilitaryCivilOfficeStatus = (ITTEnumComboBox)AddControl(new Guid("e02c392e-e5dc-4986-a5f0-268c2a2d3da6"));
            base.InitializeControls();
        }

        public PA_RetiredMilitaryCivilOfficialForm() : base("PA_RETIREDMILITARYCIVILOFFICIAL", "PA_RetiredMilitaryCivilOfficialForm")
        {
        }

        protected PA_RetiredMilitaryCivilOfficialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}