
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
    /// Sağlık Kurulu Karar Kategori Tanımı
    /// </summary>
    public partial class HCDecisionCategoryDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sağlık Kurulu Karar Kategori Tanımı
    /// </summary>
        protected TTObjectClasses.HealthCommitteeDecisionCategoryDefinition _HealthCommitteeDecisionCategoryDefinition
        {
            get { return (TTObjectClasses.HealthCommitteeDecisionCategoryDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("085b6ac2-1b7d-4cca-9879-d93e48bf9015"));
            Code = (ITTTextBox)AddControl(new Guid("6d911de7-dc1c-4277-b307-3bcdda2aacef"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("22926b63-1485-497c-8322-9c4bb024b4e1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("553ae0bc-76ac-4a40-9aba-6014a4104a4d"));
            IsActive = (ITTCheckBox)AddControl(new Guid("d8af53e3-ab60-44ba-9136-a31fbb657564"));
            base.InitializeControls();
        }

        public HCDecisionCategoryDefinitionForm() : base("HEALTHCOMMITTEEDECISIONCATEGORYDEFINITION", "HCDecisionCategoryDefinitionForm")
        {
        }

        protected HCDecisionCategoryDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}