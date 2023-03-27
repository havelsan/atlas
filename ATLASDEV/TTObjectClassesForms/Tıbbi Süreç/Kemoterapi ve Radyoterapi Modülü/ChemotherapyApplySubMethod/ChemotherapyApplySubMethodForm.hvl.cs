
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
    /// Kemoterapi Alt Uygulama Şekli Tanımları
    /// </summary>
    public partial class ChemotherapyApplySubMethodForm : TTDefinitionForm
    {
    /// <summary>
    /// Kemoterapi Alt Uygulama Şekilleri Tanımları
    /// </summary>
        protected TTObjectClasses.ChemotherapyApplySubMethod _ChemotherapyApplySubMethod
        {
            get { return (TTObjectClasses.ChemotherapyApplySubMethod)_ttObject; }
        }

        protected ITTLabel labelChemotherapyApplyMethod;
        protected ITTObjectListBox ChemotherapyApplyMethod;
        protected ITTCheckBox Isactive;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelChemotherapyApplyMethod = (ITTLabel)AddControl(new Guid("e01eb808-0ec5-443e-add4-c0496fc91897"));
            ChemotherapyApplyMethod = (ITTObjectListBox)AddControl(new Guid("10690896-4fee-4ee7-9488-2f734703ead8"));
            Isactive = (ITTCheckBox)AddControl(new Guid("d58d6162-77ba-446e-98a2-94d08e86691b"));
            labelName = (ITTLabel)AddControl(new Guid("ac44b3b4-ee76-466c-ba20-c3d4bba46cbf"));
            Name = (ITTTextBox)AddControl(new Guid("28e4f638-8997-4be1-b410-8d6b649448f2"));
            Code = (ITTTextBox)AddControl(new Guid("2a5dd0c2-5540-4a74-9c8b-173699775bff"));
            labelCode = (ITTLabel)AddControl(new Guid("ff8ebde7-b4b0-4f1b-a8d2-14e9eea5ee0c"));
            base.InitializeControls();
        }

        public ChemotherapyApplySubMethodForm() : base("CHEMOTHERAPYAPPLYSUBMETHOD", "ChemotherapyApplySubMethodForm")
        {
        }

        protected ChemotherapyApplySubMethodForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}