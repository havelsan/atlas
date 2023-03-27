
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
    /// Kuvvet Tanımlama
    /// </summary>
    public partial class ForcesCommandDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kuvvet
    /// </summary>
        protected TTObjectClasses.ForcesCommand _ForcesCommand
        {
            get { return (TTObjectClasses.ForcesCommand)_ttObject; }
        }

        protected ITTTextBox Qref;
        protected ITTTextBox ExternalCode;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelQref;
        protected ITTLabel labelExternalCode;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            Qref = (ITTTextBox)AddControl(new Guid("b60733e6-bae5-4812-8a4b-b28a062ea46c"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("cf413c6d-570d-4566-bd65-bff171f1330a"));
            Name = (ITTTextBox)AddControl(new Guid("4c0e0158-c485-4daf-ab9f-e74a172acf6f"));
            Code = (ITTTextBox)AddControl(new Guid("f52b14df-20fc-44f5-955e-064901e8d654"));
            labelQref = (ITTLabel)AddControl(new Guid("fc5fe01e-137f-475c-9b2f-cf4531277565"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("06e3e6e6-dff4-4e37-b3fa-48337ef5ddc8"));
            labelName = (ITTLabel)AddControl(new Guid("ab0d9269-70f9-4119-8187-af31e3615550"));
            labelCode = (ITTLabel)AddControl(new Guid("64c42e2a-45d3-4dbf-bf8d-ce77ac94e9f6"));
            Active = (ITTCheckBox)AddControl(new Guid("b20b2bd8-0736-4be6-ba4e-c29e54fd9448"));
            base.InitializeControls();
        }

        public ForcesCommandDefinitionForm() : base("FORCESCOMMAND", "ForcesCommandDefinitionForm")
        {
        }

        protected ForcesCommandDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}