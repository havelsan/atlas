
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
    /// Üretici Tanımlama
    /// </summary>
    public partial class ProducerDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Üretici
    /// </summary>
        protected TTObjectClasses.Producer _Producer
        {
            get { return (TTObjectClasses.Producer)_ttObject; }
        }

        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelCode = (ITTLabel)AddControl(new Guid("edc58f47-46b5-45df-8b68-c94e2e2cf6e0"));
            Code = (ITTTextBox)AddControl(new Guid("90c2e8bf-db2e-4ac0-9616-8a0d2ea6b609"));
            Name = (ITTTextBox)AddControl(new Guid("8020357c-abee-457b-b564-96e04fafca12"));
            labelName = (ITTLabel)AddControl(new Guid("f4ccf3f7-7eee-475d-9426-92b7a4520c17"));
            base.InitializeControls();
        }

        public ProducerDefinitionForm() : base("PRODUCER", "ProducerDefinitionForm")
        {
        }

        protected ProducerDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}