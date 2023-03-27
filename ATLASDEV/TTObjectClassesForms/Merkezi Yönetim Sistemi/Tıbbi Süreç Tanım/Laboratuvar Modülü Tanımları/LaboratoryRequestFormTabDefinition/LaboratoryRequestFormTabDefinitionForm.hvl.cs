
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
    /// Laboratuvar Sekme Tanımları
    /// </summary>
    public partial class LaboratoryRequestFormTabDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.LaboratoryRequestFormTabDefinition _LaboratoryRequestFormTabDefinition
        {
            get { return (TTObjectClasses.LaboratoryRequestFormTabDefinition)_ttObject; }
        }

        protected ITTCheckBox chkUrgentProcess;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox TabOrder;
        protected ITTLabel labelTabOrder;
        protected ITTCheckBox ISACTIVE;
        protected ITTObjectListBox TestType;
        protected ITTLabel lblDepartment;
        protected ITTObjectListBox listboxEnvironment;
        protected ITTLabel lblEnvironment;
        override protected void InitializeControls()
        {
            chkUrgentProcess = (ITTCheckBox)AddControl(new Guid("a6933f1f-94cd-4dd8-8d81-06e5921676c5"));
            labelName = (ITTLabel)AddControl(new Guid("77c4b0af-babb-4feb-813b-2a0044feb83d"));
            Name = (ITTTextBox)AddControl(new Guid("576ea4d6-4711-4dd3-a85e-43b66b8cb60f"));
            TabOrder = (ITTTextBox)AddControl(new Guid("3916a650-fabe-4362-801a-dcaa41db943a"));
            labelTabOrder = (ITTLabel)AddControl(new Guid("3b0c6065-334b-415b-8463-486336897c09"));
            ISACTIVE = (ITTCheckBox)AddControl(new Guid("0a98eb9a-7db3-45a3-b345-8b87f8b9d7af"));
            TestType = (ITTObjectListBox)AddControl(new Guid("5d0177b1-d484-4383-944e-be60f7be8595"));
            lblDepartment = (ITTLabel)AddControl(new Guid("8a527b52-7ada-4632-b7ea-3d5fde749655"));
            listboxEnvironment = (ITTObjectListBox)AddControl(new Guid("6fd65857-737b-42d0-8010-35cb844511c0"));
            lblEnvironment = (ITTLabel)AddControl(new Guid("8524a589-b5aa-4da8-8060-ca8c3c442736"));
            base.InitializeControls();
        }

        public LaboratoryRequestFormTabDefinitionForm() : base("LABORATORYREQUESTFORMTABDEFINITION", "LaboratoryRequestFormTabDefinitionForm")
        {
        }

        protected LaboratoryRequestFormTabDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}