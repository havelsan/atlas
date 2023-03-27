
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
    /// CPT4 Tanımları
    /// </summary>
    public partial class CPT4DefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// CPT4 Tanımları
    /// </summary>
        protected TTObjectClasses.CPT4Definition _CPT4Definition
        {
            get { return (TTObjectClasses.CPT4Definition)_ttObject; }
        }

        protected ITTLabel labelProcedureType;
        protected ITTObjectListBox ProcedureType;
        protected ITTLabel labelTurkishName;
        protected ITTTextBox TurkishName;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTLabel labelOriginalName;
        protected ITTTextBox OriginalName;
        protected ITTLabel labelEnglishName;
        protected ITTTextBox EnglishName;
        protected ITTLabel labelCPTCode;
        protected ITTTextBox CPTCode;
        override protected void InitializeControls()
        {
            labelProcedureType = (ITTLabel)AddControl(new Guid("ac076501-650e-4695-a31c-72485bf5c62b"));
            ProcedureType = (ITTObjectListBox)AddControl(new Guid("93adb2ce-c461-4ad3-a639-2a08d55624eb"));
            labelTurkishName = (ITTLabel)AddControl(new Guid("c67cb8d2-8d1e-476c-a436-ffc8a7b2cf1c"));
            TurkishName = (ITTTextBox)AddControl(new Guid("4f914e75-0ecd-4aa5-8533-af0486fbb80a"));
            labelQref = (ITTLabel)AddControl(new Guid("78b7fc02-ff29-4550-9816-ee230768a767"));
            Qref = (ITTTextBox)AddControl(new Guid("6ac1b62e-b9b7-45ac-a263-c150b6a5a0f7"));
            labelOriginalName = (ITTLabel)AddControl(new Guid("bc161890-bbd4-4577-a838-65f406575783"));
            OriginalName = (ITTTextBox)AddControl(new Guid("6bbc044c-0dbb-4c26-9d80-38ca39ae1481"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("0228c3cf-e1d6-41a1-a490-a74b18c8068a"));
            EnglishName = (ITTTextBox)AddControl(new Guid("8b1006b4-30bc-4594-a9bf-4cd3831712ca"));
            labelCPTCode = (ITTLabel)AddControl(new Guid("cad84ea3-5cae-498d-80a7-5f6a3e76e15a"));
            CPTCode = (ITTTextBox)AddControl(new Guid("d640d27c-0a61-4506-952a-8651db9b1093"));
            base.InitializeControls();
        }

        public CPT4DefinitionForm() : base("CPT4DEFINITION", "CPT4DefinitionForm")
        {
        }

        protected CPT4DefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}