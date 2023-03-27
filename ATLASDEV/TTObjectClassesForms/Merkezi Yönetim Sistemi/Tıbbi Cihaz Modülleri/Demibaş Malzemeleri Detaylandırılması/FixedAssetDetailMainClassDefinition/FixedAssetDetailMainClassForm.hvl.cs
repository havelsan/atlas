
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
    /// Malzemenin Ana Sınıfı / Adı
    /// </summary>
    public partial class FixedAssetDetailMainClassForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.FixedAssetDetailMainClassDefinition _FixedAssetDetailMainClassDefinition
        {
            get { return (TTObjectClasses.FixedAssetDetailMainClassDefinition)_ttObject; }
        }

        protected ITTLabel labelMainClassName;
        protected ITTTextBox MainClassName;
        override protected void InitializeControls()
        {
            labelMainClassName = (ITTLabel)AddControl(new Guid("d7662fed-6172-4e5f-9967-f1e2a34af8ac"));
            MainClassName = (ITTTextBox)AddControl(new Guid("b1202f29-29d0-45d7-9e79-8800bae65967"));
            base.InitializeControls();
        }

        public FixedAssetDetailMainClassForm() : base("FIXEDASSETDETAILMAINCLASSDEFINITION", "FixedAssetDetailMainClassForm")
        {
        }

        protected FixedAssetDetailMainClassForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}