
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
    public partial class DPA22FCodelessMatarialDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.DPA22FCodelessMaterialDef _DPA22FCodelessMaterialDef
        {
            get { return (TTObjectClasses.DPA22FCodelessMaterialDef)_ttObject; }
        }

        protected ITTLabel labelMatchedSUTPrice;
        protected ITTTextBox MatchedSUTPrice;
        protected ITTTextBox MatchedSUTCode;
        protected ITTTextBox MaterialName;
        protected ITTLabel labelMatchedSUTCode;
        protected ITTLabel labelMaterialName;
        override protected void InitializeControls()
        {
            labelMatchedSUTPrice = (ITTLabel)AddControl(new Guid("21966e06-aeff-4e70-8360-43a70f754fd0"));
            MatchedSUTPrice = (ITTTextBox)AddControl(new Guid("78ec373a-af3a-435f-9d7c-2e7216b819da"));
            MatchedSUTCode = (ITTTextBox)AddControl(new Guid("b470d6aa-3d28-4f10-9d11-01a1da3d37cc"));
            MaterialName = (ITTTextBox)AddControl(new Guid("eec40153-8474-41fa-847f-5114459fb0b2"));
            labelMatchedSUTCode = (ITTLabel)AddControl(new Guid("1968a90f-a4e1-45d4-aced-39b6c15bdf44"));
            labelMaterialName = (ITTLabel)AddControl(new Guid("9a25efde-25c6-4271-9bdb-606aaed00b6c"));
            base.InitializeControls();
        }

        public DPA22FCodelessMatarialDefForm() : base("DPA22FCODELESSMATERIALDEF", "DPA22FCodelessMatarialDefForm")
        {
        }

        protected DPA22FCodelessMatarialDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}