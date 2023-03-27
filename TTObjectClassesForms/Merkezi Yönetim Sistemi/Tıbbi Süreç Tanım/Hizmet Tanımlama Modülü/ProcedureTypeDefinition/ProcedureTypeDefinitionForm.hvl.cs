
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
    /// Hizmet Türleri Tanımlama
    /// </summary>
    public partial class ProcedureTypeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hizmet Türleri Tanımlama
    /// </summary>
        protected TTObjectClasses.ProcedureTypeDefinition _ProcedureTypeDefinition
        {
            get { return (TTObjectClasses.ProcedureTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelProcedureTypeName;
        protected ITTTextBox ProcedureTypeName;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelProcedureTypeName = (ITTLabel)AddControl(new Guid("1d1a9926-8933-4540-a0d7-de18ba8b7f9d"));
            ProcedureTypeName = (ITTTextBox)AddControl(new Guid("5d1748cb-8599-4d53-b09b-f1a21a1118dd"));
            labelCode = (ITTLabel)AddControl(new Guid("c2e15e23-0d8e-40c0-8899-272644c25be6"));
            Code = (ITTTextBox)AddControl(new Guid("028ae678-3abf-41fb-bd84-9461a38bfd29"));
            base.InitializeControls();
        }

        public ProcedureTypeDefinitionForm() : base("PROCEDURETYPEDEFINITION", "ProcedureTypeDefinitionForm")
        {
        }

        protected ProcedureTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}