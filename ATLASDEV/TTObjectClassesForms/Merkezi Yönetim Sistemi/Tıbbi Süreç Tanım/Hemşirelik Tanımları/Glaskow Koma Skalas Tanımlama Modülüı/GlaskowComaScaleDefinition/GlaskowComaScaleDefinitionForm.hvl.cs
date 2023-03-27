
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
    /// Hemşirelik Uygulamaları - Glaskow Koma Skalası Tanımları
    /// </summary>
    public partial class GlaskowComaScaleDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.GlaskowComaScaleDefinition _GlaskowComaScaleDefinition
        {
            get { return (TTObjectClasses.GlaskowComaScaleDefinition)_ttObject; }
        }

        protected ITTLabel labelGKSType;
        protected ITTEnumComboBox GKSType;
        protected ITTLabel labelScore;
        protected ITTTextBox Score;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelGKSType = (ITTLabel)AddControl(new Guid("437e17e2-6b39-46c6-8567-8532e304090b"));
            GKSType = (ITTEnumComboBox)AddControl(new Guid("80635236-175e-47e7-bcce-543e526c7abd"));
            labelScore = (ITTLabel)AddControl(new Guid("83e17379-5800-4364-b209-6c73fffd514f"));
            Score = (ITTTextBox)AddControl(new Guid("ebea4942-9492-4348-be31-eab2768fc1e1"));
            labelName = (ITTLabel)AddControl(new Guid("bcd73d6b-d308-4c62-9a0c-3d6797e88ec2"));
            Name = (ITTTextBox)AddControl(new Guid("1ca48951-688f-430c-9b85-c70874c1d7a7"));
            Aktif = (ITTCheckBox)AddControl(new Guid("c79d95c5-5102-4a69-a66a-7b936a6bab03"));
            base.InitializeControls();
        }

        public GlaskowComaScaleDefinitionForm() : base("GLASKOWCOMASCALEDEFINITION", "GlaskowComaScaleDefinitionForm")
        {
        }

        protected GlaskowComaScaleDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}