
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
    /// Hemşirelik Uygulamaları -  Nanda Hedef Tanımları
    /// </summary>
    public partial class NursingTargetDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hemşirelik Hedef Tanımları
    /// </summary>
        protected TTObjectClasses.NursingTargetDefinition _NursingTargetDefinition
        {
            get { return (TTObjectClasses.NursingTargetDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("dc156040-58c0-49e1-8926-31a11e42911b"));
            Name = (ITTTextBox)AddControl(new Guid("1b58dfaa-8d44-4009-b073-b81aec1442fb"));
            Aktif = (ITTCheckBox)AddControl(new Guid("707aae3d-1049-4c38-a9a7-e5b4897dfa74"));
            base.InitializeControls();
        }

        public NursingTargetDefinitionForm() : base("NURSINGTARGETDEFINITION", "NursingTargetDefinitionForm")
        {
        }

        protected NursingTargetDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}