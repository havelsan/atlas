
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
    /// Danışılan Konu Tanımları
    /// </summary>
    public partial class ConsultedSubjectDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Konsültasyon Danışılan Konular Tanımları
    /// </summary>
        protected TTObjectClasses.ConsultedSubjectDefinition _ConsultedSubjectDefinition
        {
            get { return (TTObjectClasses.ConsultedSubjectDefinition)_ttObject; }
        }

        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTLabel labelConsultedSubject;
        protected ITTTextBox ConsultedSubject;
        override protected void InitializeControls()
        {
            labelCode = (ITTLabel)AddControl(new Guid("4a17e6c2-4eb8-4e5c-86c4-954552c713b0"));
            Code = (ITTTextBox)AddControl(new Guid("1124f1d9-2384-4a04-a84f-fd7addb05c57"));
            labelConsultedSubject = (ITTLabel)AddControl(new Guid("711a8303-370c-46b8-893f-678f66538618"));
            ConsultedSubject = (ITTTextBox)AddControl(new Guid("91fc5cc9-3d4e-4819-8e42-ac91151cabd0"));
            base.InitializeControls();
        }

        public ConsultedSubjectDefinitionForm() : base("CONSULTEDSUBJECTDEFINITION", "ConsultedSubjectDefinitionForm")
        {
        }

        protected ConsultedSubjectDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}