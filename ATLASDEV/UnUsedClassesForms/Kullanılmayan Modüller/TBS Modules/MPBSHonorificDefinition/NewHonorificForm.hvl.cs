
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
    /// Unvan Tanımlama
    /// </summary>
    public partial class NewHonorificForm : TTForm
    {
    /// <summary>
    /// Unvan Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSHonorificDefinition _MPBSHonorificDefinition
        {
            get { return (TTObjectClasses.MPBSHonorificDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("54643e05-dd3d-4404-90a8-2a96d5695078"));
            labelName = (ITTLabel)AddControl(new Guid("bdf3ce4b-8d97-455c-acf2-e95fb63e1703"));
            base.InitializeControls();
        }

        public NewHonorificForm() : base("MPBSHONORIFICDEFINITION", "NewHonorificForm")
        {
        }

        protected NewHonorificForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}