
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
    /// Hemşirelik Uygulamaları - Aldığı Çıkardığı Tanımlamaları
    /// </summary>
    public partial class TakeInTakeOutDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.TakeInTakeOutDefinition _TakeInTakeOutDefinition
        {
            get { return (TTObjectClasses.TakeInTakeOutDefinition)_ttObject; }
        }

        protected ITTCheckBox Aktif;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            Aktif = (ITTCheckBox)AddControl(new Guid("2919557b-59c4-4d8d-88c6-66479e4b3362"));
            labelName = (ITTLabel)AddControl(new Guid("89a32eb1-7556-4578-9b3d-a957d0cbd7c5"));
            Name = (ITTTextBox)AddControl(new Guid("4385fc8f-cc14-4ff8-aca9-b4ea92959d36"));
            base.InitializeControls();
        }

        public TakeInTakeOutDefinitionForm() : base("TAKEINTAKEOUTDEFINITION", "TakeInTakeOutDefinitionForm")
        {
        }

        protected TakeInTakeOutDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}