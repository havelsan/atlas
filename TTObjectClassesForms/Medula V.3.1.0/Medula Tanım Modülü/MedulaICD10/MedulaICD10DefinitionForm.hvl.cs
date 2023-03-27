
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
    /// Medula ICD10 Tanımlama
    /// </summary>
    public partial class MedulaICD10DefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Medula ICD10
    /// </summary>
        protected TTObjectClasses.MedulaICD10 _MedulaICD10
        {
            get { return (TTObjectClasses.MedulaICD10)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("bc9c4f51-625c-4dd2-90a7-dcfc7d72deb5"));
            Name = (ITTTextBox)AddControl(new Guid("05ff0e66-aef6-4413-9371-8d000568f24b"));
            labelCode = (ITTLabel)AddControl(new Guid("7f72d160-a9ff-4e33-b8d2-3b349da1e406"));
            Code = (ITTTextBox)AddControl(new Guid("cff548c5-12c9-411b-a68b-037d0f2eec68"));
            base.InitializeControls();
        }

        public MedulaICD10DefinitionForm() : base("MEDULAICD10", "MedulaICD10DefinitionForm")
        {
        }

        protected MedulaICD10DefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}