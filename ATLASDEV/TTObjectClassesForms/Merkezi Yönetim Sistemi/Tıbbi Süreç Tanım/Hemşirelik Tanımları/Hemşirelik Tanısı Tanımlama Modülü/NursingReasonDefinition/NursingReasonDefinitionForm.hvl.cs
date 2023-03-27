
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
    /// Hemşirelik Uygulamaları -  Nanda  Neden Tanımları
    /// </summary>
    public partial class NursingReasonDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hemşirelik Neden Tanımlama
    /// </summary>
        protected TTObjectClasses.NursingReasonDefinition _NursingReasonDefinition
        {
            get { return (TTObjectClasses.NursingReasonDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("2a912797-dfee-4a2c-8a5d-45ee58a97b67"));
            Name = (ITTTextBox)AddControl(new Guid("f66faf47-e1aa-4886-81f0-38e8aefc14cd"));
            Aktif = (ITTCheckBox)AddControl(new Guid("c4509df7-c45c-4bf5-b1d9-4bd6151fbeaf"));
            base.InitializeControls();
        }

        public NursingReasonDefinitionForm() : base("NURSINGREASONDEFINITION", "NursingReasonDefinitionForm")
        {
        }

        protected NursingReasonDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}