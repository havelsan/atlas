
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
    /// Patoloji Laborant İşlem Tanım Ekranı
    /// </summary>
    public partial class PathologyLabMaterialDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.PathologyLabProcedureDef _PathologyLabProcedureDef
        {
            get { return (TTObjectClasses.PathologyLabProcedureDef)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("25971c02-d424-407a-928b-1f94cd28babd"));
            Name = (ITTTextBox)AddControl(new Guid("5cd1e9f0-44b4-404e-82e8-40cb047cdd3d"));
            labelCode = (ITTLabel)AddControl(new Guid("4d909e03-aa51-4f59-aa3f-2f1aa7ef3ab0"));
            Code = (ITTTextBox)AddControl(new Guid("567e6e11-f038-405d-88b1-0b080b432116"));
            Aktif = (ITTCheckBox)AddControl(new Guid("d417c44f-86e5-420a-a406-8ea3f79c1d96"));
            base.InitializeControls();
        }

        public PathologyLabMaterialDefinitionForm() : base("PATHOLOGYLABPROCEDUREDEF", "PathologyLabMaterialDefinitionForm")
        {
        }

        protected PathologyLabMaterialDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}