
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
    /// Patoloji Lokalizasyon Tanım Ekranı
    /// </summary>
    public partial class PathologyLocalisationDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.PathologyLocalisationDefinition _PathologyLocalisationDefinition
        {
            get { return (TTObjectClasses.PathologyLocalisationDefinition)_ttObject; }
        }

        protected ITTCheckBox Aktif;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            Aktif = (ITTCheckBox)AddControl(new Guid("5570b58e-7107-4211-aa3e-664df316b53e"));
            labelName = (ITTLabel)AddControl(new Guid("c052acab-1017-4c2b-b716-522814895468"));
            Name = (ITTTextBox)AddControl(new Guid("335d9dd6-9ed5-4716-a3f8-25691c7662cb"));
            labelCode = (ITTLabel)AddControl(new Guid("0dbb91fe-725b-4a66-a058-74d46d07944f"));
            Code = (ITTTextBox)AddControl(new Guid("ad2aa431-32b0-4f65-b7cd-81f7c2ae0165"));
            base.InitializeControls();
        }

        public PathologyLocalisationDefinitionForm() : base("PATHOLOGYLOCALISATIONDEFINITION", "PathologyLocalisationDefinitionForm")
        {
        }

        protected PathologyLocalisationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}