
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
    public partial class SurfaceSupportSystemDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.SurfaceSupportSystemsDef _SurfaceSupportSystemsDef
        {
            get { return (TTObjectClasses.SurfaceSupportSystemsDef)_ttObject; }
        }

        protected ITTCheckBox PlusTwentyRiskChecked;
        protected ITTCheckBox PlusFifteenRiskChecked;
        protected ITTCheckBox PlusTenRiskChecked;
        protected ITTLabel SurfaceSupportSystemDefinition;
        protected ITTTextBox Definition;
        override protected void InitializeControls()
        {
            PlusTwentyRiskChecked = (ITTCheckBox)AddControl(new Guid("45d5a7e8-5a53-4039-9d9f-23a3eebd6421"));
            PlusFifteenRiskChecked = (ITTCheckBox)AddControl(new Guid("1bd6a91a-ef4e-4ff1-ba5b-11bda2be0fd0"));
            PlusTenRiskChecked = (ITTCheckBox)AddControl(new Guid("073705c4-d2f6-4948-9192-57cc6e132682"));
            SurfaceSupportSystemDefinition = (ITTLabel)AddControl(new Guid("dbd94a38-df61-47df-9c9c-09708fe57a87"));
            Definition = (ITTTextBox)AddControl(new Guid("b0ea5d5d-8c41-47d7-a265-14de3c1f7a9d"));
            base.InitializeControls();
        }

        public SurfaceSupportSystemDefForm() : base("SURFACESUPPORTSYSTEMSDEF", "SurfaceSupportSystemDefForm")
        {
        }

        protected SurfaceSupportSystemDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}