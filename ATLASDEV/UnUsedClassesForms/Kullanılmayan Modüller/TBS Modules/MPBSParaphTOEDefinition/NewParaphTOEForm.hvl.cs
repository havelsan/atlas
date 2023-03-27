
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
    /// Yeni Paraf TMK Tanımlama
    /// </summary>
    public partial class NewParaphTOEForm : TTForm
    {
    /// <summary>
    /// Paraf TMK Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSParaphTOEDefinition _MPBSParaphTOEDefinition
        {
            get { return (TTObjectClasses.MPBSParaphTOEDefinition)_ttObject; }
        }

        protected ITTTextBox ParaphTOECode;
        protected ITTLabel labelName;
        protected ITTListDefComboBox ttlistdefcombobox2;
        protected ITTCheckBox Active;
        protected ITTLabel labelOffice;
        protected ITTLabel labelMainTOE;
        protected ITTListDefComboBox ttlistdefcombobox1;
        override protected void InitializeControls()
        {
            ParaphTOECode = (ITTTextBox)AddControl(new Guid("a96572a8-17df-40c8-8cbc-0f50a584fb59"));
            labelName = (ITTLabel)AddControl(new Guid("d327ae42-0fc6-4d69-aa60-147fdd094110"));
            ttlistdefcombobox2 = (ITTListDefComboBox)AddControl(new Guid("6b9eca2a-8d2f-449b-a595-5d2d7c20d70b"));
            Active = (ITTCheckBox)AddControl(new Guid("004efb3a-4b46-4b4a-8540-9047e367c25d"));
            labelOffice = (ITTLabel)AddControl(new Guid("a2e6ecbc-fc59-4c60-aa8a-f87e410106c5"));
            labelMainTOE = (ITTLabel)AddControl(new Guid("8175e0a3-2290-4f94-a9b3-e3be44f27656"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("7f74aa8b-46da-4abc-acff-f743a0b0afde"));
            base.InitializeControls();
        }

        public NewParaphTOEForm() : base("MPBSPARAPHTOEDEFINITION", "NewParaphTOEForm")
        {
        }

        protected NewParaphTOEForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}