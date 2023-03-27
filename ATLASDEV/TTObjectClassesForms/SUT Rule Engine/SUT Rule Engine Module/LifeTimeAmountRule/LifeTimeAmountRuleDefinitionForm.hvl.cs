
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
    /// Ömrü Boyunca Miktar Kuralı Tanımlama
    /// </summary>
    public partial class LifeTimeAmountRuleDefinitionForm : RuleBaseDefinitionForm
    {
    /// <summary>
    /// Ömrü Boyunca Miktar Kuralı
    /// </summary>
        protected TTObjectClasses.LifeTimeAmountRule _LifeTimeAmountRule
        {
            get { return (TTObjectClasses.LifeTimeAmountRule)_ttObject; }
        }

        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        override protected void InitializeControls()
        {
            labelAmount = (ITTLabel)AddControl(new Guid("4e351cc7-6284-433d-931b-e66def9c8510"));
            Amount = (ITTTextBox)AddControl(new Guid("2ad7f393-2942-4513-a0c3-ee073c8bd5bf"));
            base.InitializeControls();
        }

        public LifeTimeAmountRuleDefinitionForm() : base("LIFETIMEAMOUNTRULE", "LifeTimeAmountRuleDefinitionForm")
        {
        }

        protected LifeTimeAmountRuleDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}