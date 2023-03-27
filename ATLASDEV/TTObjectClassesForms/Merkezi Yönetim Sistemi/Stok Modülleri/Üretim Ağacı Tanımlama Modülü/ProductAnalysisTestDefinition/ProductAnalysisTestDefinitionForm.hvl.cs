
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
    /// Ürün Analiz Test Tanımı
    /// </summary>
    public partial class ProductAnalysisTestDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Ürün Analiz Test Tanımı
    /// </summary>
        protected TTObjectClasses.ProductAnalysisTestDefinition _ProductAnalysisTestDefinition
        {
            get { return (TTObjectClasses.ProductAnalysisTestDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("dd6decde-3be8-4bfe-8b04-72f6ec8fd049"));
            Name = (ITTTextBox)AddControl(new Guid("9b329110-4762-4024-afe4-45c999133c30"));
            base.InitializeControls();
        }

        public ProductAnalysisTestDefinitionForm() : base("PRODUCTANALYSISTESTDEFINITION", "ProductAnalysisTestDefinitionForm")
        {
        }

        protected ProductAnalysisTestDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}