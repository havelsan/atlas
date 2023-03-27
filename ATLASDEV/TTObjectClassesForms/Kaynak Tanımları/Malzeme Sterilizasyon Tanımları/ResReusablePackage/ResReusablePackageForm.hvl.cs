
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
    public partial class ResReusablePackageForm : TTDefinitionForm
    {
    /// <summary>
    /// Sterile Edilebilir  Paket
    /// </summary>
        protected TTObjectClasses.ResReusablePackage _ResReusablePackage
        {
            get { return (TTObjectClasses.ResReusablePackage)_ttObject; }
        }

        protected ITTLabel labelOwnerResource;
        protected ITTObjectListBox OwnerResource;
        protected ITTGrid ReusableMaterialDetails;
        protected ITTTextBoxColumn QrefResReusableMaterial;
        protected ITTTextBoxColumn NameResReusableMaterial;
        protected ITTButtonColumn DeleteRow;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox MaterialSelection;
        override protected void InitializeControls()
        {
            labelOwnerResource = (ITTLabel)AddControl(new Guid("f4c45c50-fa7e-4626-8ed1-073b0549f388"));
            OwnerResource = (ITTObjectListBox)AddControl(new Guid("5fabf262-8e21-424d-83c7-3db68ddf4d89"));
            ReusableMaterialDetails = (ITTGrid)AddControl(new Guid("928a1ed6-2966-4ea8-84ac-b9f341d8a482"));
            QrefResReusableMaterial = (ITTTextBoxColumn)AddControl(new Guid("9987a29f-c98f-498c-bec8-12c1a878101c"));
            NameResReusableMaterial = (ITTTextBoxColumn)AddControl(new Guid("6433ebf7-c3f8-40af-826c-ddeca2603eac"));
            DeleteRow = (ITTButtonColumn)AddControl(new Guid("f91ecfff-7d4e-42a4-9cc4-658d154e4bd9"));
            labelQref = (ITTLabel)AddControl(new Guid("63e73709-7215-444f-8e99-8d2c6cad24a1"));
            Qref = (ITTTextBox)AddControl(new Guid("0e8309fa-2b58-409c-bef7-9f2ad66c5b44"));
            Name = (ITTTextBox)AddControl(new Guid("6a373ba9-e12f-4ae0-9437-c232e3763b0f"));
            labelName = (ITTLabel)AddControl(new Guid("82ffbf7e-aa9e-4e00-ab15-612ebc121438"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f137685e-759c-41e8-b45d-b47b577fdd99"));
            MaterialSelection = (ITTObjectListBox)AddControl(new Guid("68e1d464-a5a3-4f6d-890c-a4f235155c69"));
            base.InitializeControls();
        }

        public ResReusablePackageForm() : base("RESREUSABLEPACKAGE", "ResReusablePackageForm")
        {
        }

        protected ResReusablePackageForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}