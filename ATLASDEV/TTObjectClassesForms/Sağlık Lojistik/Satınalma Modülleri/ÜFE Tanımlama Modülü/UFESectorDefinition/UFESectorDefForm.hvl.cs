
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
    /// ÜFE Sektör/Alt Sektör Tanımı
    /// </summary>
    public partial class UFESectorDefForm : TTDefinitionForm
    {
    /// <summary>
    /// ÜFE Sektör/Alt Sektör Tanımı
    /// </summary>
        protected TTObjectClasses.UFESectorDefinition _UFESectorDefinition
        {
            get { return (TTObjectClasses.UFESectorDefinition)_ttObject; }
        }

        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelCode = (ITTLabel)AddControl(new Guid("e26a5ce8-0887-43f2-8636-084e2877c8b3"));
            Code = (ITTTextBox)AddControl(new Guid("aca805e1-6819-4bb5-8fc3-027ffbf0d160"));
            labelName = (ITTLabel)AddControl(new Guid("aa134cbd-a39e-4316-b1d3-7ae3e39c7ee0"));
            Name = (ITTTextBox)AddControl(new Guid("96bf3437-8792-402d-b652-a4130dcd41c9"));
            base.InitializeControls();
        }

        public UFESectorDefForm() : base("UFESECTORDEFINITION", "UFESectorDefForm")
        {
        }

        protected UFESectorDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}