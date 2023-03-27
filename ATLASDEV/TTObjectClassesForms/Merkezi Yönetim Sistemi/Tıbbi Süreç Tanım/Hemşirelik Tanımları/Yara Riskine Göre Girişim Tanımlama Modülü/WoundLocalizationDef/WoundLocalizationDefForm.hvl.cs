
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
    public partial class WoundLocalizationDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Yara riski lokalizasyon
    /// </summary>
        protected TTObjectClasses.WoundLocalizationDef _WoundLocalizationDef
        {
            get { return (TTObjectClasses.WoundLocalizationDef)_ttObject; }
        }

        protected ITTLabel labelLocalization;
        protected ITTTextBox Localization;
        override protected void InitializeControls()
        {
            labelLocalization = (ITTLabel)AddControl(new Guid("a4bfe341-95d7-47c3-a870-1109df3dc15d"));
            Localization = (ITTTextBox)AddControl(new Guid("07c45da7-3007-43a7-b4ed-aec995a4e5fd"));
            base.InitializeControls();
        }

        public WoundLocalizationDefForm() : base("WOUNDLOCALIZATIONDEF", "WoundLocalizationDefForm")
        {
        }

        protected WoundLocalizationDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}