
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
    /// Marka Tanımı
    /// </summary>
    public partial class FixedAssetDetailMarkDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.FixedAssetDetailMarkDef _FixedAssetDetailMarkDef
        {
            get { return (TTObjectClasses.FixedAssetDetailMarkDef)_ttObject; }
        }

        protected ITTLabel labelFixedAssetDetailMainClass;
        protected ITTObjectListBox FixedAssetDetailMainClass;
        protected ITTLabel labelMarkName;
        protected ITTTextBox MarkName;
        override protected void InitializeControls()
        {
            labelFixedAssetDetailMainClass = (ITTLabel)AddControl(new Guid("6c1a0eba-5090-4354-ac6d-df4ac5138788"));
            FixedAssetDetailMainClass = (ITTObjectListBox)AddControl(new Guid("0085aa70-880e-4795-b1f8-c7d1fdd263fd"));
            labelMarkName = (ITTLabel)AddControl(new Guid("8d32f46f-c43f-4af6-9b96-5db1fab4ff07"));
            MarkName = (ITTTextBox)AddControl(new Guid("b0f48657-a24c-4917-9d2e-74b98fefae2a"));
            base.InitializeControls();
        }

        public FixedAssetDetailMarkDefForm() : base("FIXEDASSETDETAILMARKDEF", "FixedAssetDetailMarkDefForm")
        {
        }

        protected FixedAssetDetailMarkDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}