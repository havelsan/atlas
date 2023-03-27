
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
    /// Haksahipliği Tanımlama Formu
    /// </summary>
    public partial class BeneficaryDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Haksahipliği Tanımlama
    /// </summary>
        protected TTObjectClasses.BeneficiaryDefinition _BeneficiaryDefinition
        {
            get { return (TTObjectClasses.BeneficiaryDefinition)_ttObject; }
        }

        protected ITTLabel labelFormerCode;
        protected ITTTextBox FormerCode;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        override protected void InitializeControls()
        {
            labelFormerCode = (ITTLabel)AddControl(new Guid("26f4b012-c290-48b8-8dbc-98366a1db1bc"));
            FormerCode = (ITTTextBox)AddControl(new Guid("d008d3cc-c34d-464c-899d-ba42aa78de73"));
            labelName = (ITTLabel)AddControl(new Guid("f47cfcd1-4d7d-4efb-958a-e9bd6e5e41bb"));
            Name = (ITTTextBox)AddControl(new Guid("9599fea9-cb12-464b-8ee2-0b75a5a77e7c"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("38204419-df12-46e2-b6cb-cc67c2e1be51"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("c501ccd7-e62c-4b18-9bd4-a720cbd89a7e"));
            base.InitializeControls();
        }

        public BeneficaryDefinitionForm() : base("BENEFICIARYDEFINITION", "BeneficaryDefinitionForm")
        {
        }

        protected BeneficaryDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}