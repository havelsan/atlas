
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
    public partial class NursingDietDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.NursingDietDefinition _NursingDietDefinition
        {
            get { return (TTObjectClasses.NursingDietDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("ae68b1f8-e3bd-4ebb-bf5b-81e503378576"));
            Name = (ITTTextBox)AddControl(new Guid("22392a1e-f4b8-4a03-b5f5-eb0ee850ea09"));
            Aktif = (ITTCheckBox)AddControl(new Guid("48343e7f-97ab-4aad-9bbe-6e9a8ce893ba"));
            base.InitializeControls();
        }

        public NursingDietDefinitionForm() : base("NURSINGDIETDEFINITION", "NursingDietDefinitionForm")
        {
        }

        protected NursingDietDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}