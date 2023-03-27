
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
    public partial class PainQualityDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Ağrı Niteliği
    /// </summary>
        protected TTObjectClasses.PainQualityDefinition _PainQualityDefinition
        {
            get { return (TTObjectClasses.PainQualityDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("66c34819-f812-4957-b00b-6bc631be8974"));
            Name = (ITTTextBox)AddControl(new Guid("e61cb1dc-8ff3-4390-9c57-0c4259f6b0d5"));
            Aktif = (ITTCheckBox)AddControl(new Guid("994ee5e9-a5b6-402d-977a-3fbb19ae35e0"));
            base.InitializeControls();
        }

        public PainQualityDefinitionForm() : base("PAINQUALITYDEFINITION", "PainQualityDefinitionForm")
        {
        }

        protected PainQualityDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}