
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
    public partial class PainPlaceDefitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Ağrının Yeri 
    /// </summary>
        protected TTObjectClasses.PainPlaceDefition _PainPlaceDefition
        {
            get { return (TTObjectClasses.PainPlaceDefition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("0a550f9b-5da1-456e-adab-bb006e1170ab"));
            Name = (ITTTextBox)AddControl(new Guid("8889869f-ebf3-49d5-91f0-07f37ef81545"));
            Aktif = (ITTCheckBox)AddControl(new Guid("2a4fc5e2-4db0-45fd-927c-4fc6e91f1427"));
            base.InitializeControls();
        }

        public PainPlaceDefitionForm() : base("PAINPLACEDEFITION", "PainPlaceDefitionForm")
        {
        }

        protected PainPlaceDefitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}