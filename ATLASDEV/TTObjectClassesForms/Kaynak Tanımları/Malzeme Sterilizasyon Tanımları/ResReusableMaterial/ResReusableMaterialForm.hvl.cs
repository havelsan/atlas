
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
    public partial class ResReusableMaterialForm : TTDefinitionForm
    {
    /// <summary>
    /// Sterile Edilebilir Malzeme
    /// </summary>
        protected TTObjectClasses.ResReusableMaterial _ResReusableMaterial
        {
            get { return (TTObjectClasses.ResReusableMaterial)_ttObject; }
        }

        protected ITTLabel labelOwnerResource;
        protected ITTObjectListBox OwnerResource;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTCheckBox ttcheckbox2;
        override protected void InitializeControls()
        {
            labelOwnerResource = (ITTLabel)AddControl(new Guid("9efe8c08-64a7-45ec-996c-1db3a0294f68"));
            OwnerResource = (ITTObjectListBox)AddControl(new Guid("c1e313bd-851f-426d-a3f1-5c7e9dd1feee"));
            labelQref = (ITTLabel)AddControl(new Guid("01a79c59-7df4-4e5e-b934-37610387c700"));
            Qref = (ITTTextBox)AddControl(new Guid("1bf5dde8-9e5b-4cc3-a023-583c937b6e00"));
            Name = (ITTTextBox)AddControl(new Guid("06a79eba-21a8-43ae-b147-c3557bfb1cd3"));
            labelName = (ITTLabel)AddControl(new Guid("98a7670d-a47c-49ea-b16f-a2f223e40ff1"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("e0315663-81c6-461d-a9af-c42d06933337"));
            base.InitializeControls();
        }

        public ResReusableMaterialForm() : base("RESREUSABLEMATERIAL", "ResReusableMaterialForm")
        {
        }

        protected ResReusableMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}