
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
    /// Malzeme Kullanım Yeri Tanımı
    /// </summary>
    public partial class MaterialPlaceOfUseDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Malzeme Kullanım Yeri Tanımı
    /// </summary>
        protected TTObjectClasses.MaterialPlaceOfUseDef _MaterialPlaceOfUseDef
        {
            get { return (TTObjectClasses.MaterialPlaceOfUseDef)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("cb0f0c8b-80fc-42a4-98b0-44210d8ff5f2"));
            Name = (ITTTextBox)AddControl(new Guid("bc061e7e-c4e1-497c-bff7-731a63bcc0af"));
            base.InitializeControls();
        }

        public MaterialPlaceOfUseDefForm() : base("MATERIALPLACEOFUSEDEF", "MaterialPlaceOfUseDefForm")
        {
        }

        protected MaterialPlaceOfUseDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}