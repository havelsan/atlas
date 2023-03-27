
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
    /// Yeni Kısım Tanımlama
    /// </summary>
    public partial class NewSectionForm : TTForm
    {
    /// <summary>
    /// Kısım Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSSectionDefinition _MPBSSectionDefinition
        {
            get { return (TTObjectClasses.MPBSSectionDefinition)_ttObject; }
        }

        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTLabel labelOfficeDefinition;
        protected ITTCheckBox Active;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTLabel labelUnitDefinition;
        protected ITTListDefComboBox ttlistdefcombobox2;
        override protected void InitializeControls()
        {
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("65b9561b-ee7a-4c86-9b37-4431d1a95b83"));
            labelOfficeDefinition = (ITTLabel)AddControl(new Guid("359ee1ab-a243-477d-906b-5c2d918d6444"));
            Active = (ITTCheckBox)AddControl(new Guid("721d7f02-fdfe-41b6-9126-86d1c5083dc3"));
            Name = (ITTTextBox)AddControl(new Guid("a8d046be-2e75-48e1-a209-a75dcb0a53df"));
            labelName = (ITTLabel)AddControl(new Guid("153a6550-b5a5-42a1-9862-aa20151d412d"));
            labelUnitDefinition = (ITTLabel)AddControl(new Guid("c281c250-d4f2-4a75-93aa-aad15436d9c4"));
            ttlistdefcombobox2 = (ITTListDefComboBox)AddControl(new Guid("a5c3a4d2-0852-48d9-8f79-b3d49c8a810e"));
            base.InitializeControls();
        }

        public NewSectionForm() : base("MPBSSECTIONDEFINITION", "NewSectionForm")
        {
        }

        protected NewSectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}