
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
    /// Kapsama Ait Birimlerin Tanımlanması
    /// </summary>
    public partial class DepartmentDefinitionsForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.DepartmentDefinition _DepartmentDefinition
        {
            get { return (TTObjectClasses.DepartmentDefinition)_ttObject; }
        }

        protected ITTLabel labelMAINTOECODE;
        protected ITTTextBox MAINTOECODE;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelUnitEnclosureID;
        protected ITTObjectListBox UnitEnclosureID;
        protected ITTLabel labelSHORT_NAME;
        protected ITTTextBox SHORT_NAME;
        protected ITTTextBox PCODE;
        protected ITTTextBox NAME;
        protected ITTLabel labelPCODE;
        protected ITTLabel labelNAME;
        override protected void InitializeControls()
        {
            labelMAINTOECODE = (ITTLabel)AddControl(new Guid("2a4dfdab-0c54-437e-b07b-807d27a0fe43"));
            MAINTOECODE = (ITTTextBox)AddControl(new Guid("6d6185e9-4f67-495c-b019-662d666ba43e"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("919d2c71-03e7-40e6-a122-cf47c177b40c"));
            labelUnitEnclosureID = (ITTLabel)AddControl(new Guid("c6a5e799-5913-4c2a-b395-3b4294b9d853"));
            UnitEnclosureID = (ITTObjectListBox)AddControl(new Guid("8f34d3ac-34a3-4977-bdc7-3a63717a29a3"));
            labelSHORT_NAME = (ITTLabel)AddControl(new Guid("5a81c3ed-ad3e-4111-b6fc-5f386806e050"));
            SHORT_NAME = (ITTTextBox)AddControl(new Guid("c6ffe78e-6369-4980-a180-e357de11f787"));
            PCODE = (ITTTextBox)AddControl(new Guid("4b33a2df-a677-441d-b9f1-0bd0fca3eda8"));
            NAME = (ITTTextBox)AddControl(new Guid("018e5e3d-fceb-429e-aca6-de12dbeaa41f"));
            labelPCODE = (ITTLabel)AddControl(new Guid("f21ef210-3cb5-4f47-99af-0d68dc489389"));
            labelNAME = (ITTLabel)AddControl(new Guid("7a30d12a-82ec-4fdf-88db-da93fccdead1"));
            base.InitializeControls();
        }

        public DepartmentDefinitionsForm() : base("DEPARTMENTDEFINITION", "DepartmentDefinitionsForm")
        {
        }

        protected DepartmentDefinitionsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}