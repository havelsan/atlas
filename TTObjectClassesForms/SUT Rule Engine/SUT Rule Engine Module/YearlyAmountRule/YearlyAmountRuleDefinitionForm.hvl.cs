
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
    /// Yıllık Miktar Kuralı Tanımlama
    /// </summary>
    public partial class YearlyAmountRuleDefinitionForm : RuleBaseDefinitionForm
    {
    /// <summary>
    /// Yıllık Miktar Kuralı
    /// </summary>
        protected TTObjectClasses.YearlyAmountRule _YearlyAmountRule
        {
            get { return (TTObjectClasses.YearlyAmountRule)_ttObject; }
        }

        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        protected ITTLabel labelYearCount;
        protected ITTTextBox YearCount;
        override protected void InitializeControls()
        {
            labelAmount = (ITTLabel)AddControl(new Guid("515684f3-3e08-47ed-aada-406150fc27a3"));
            Amount = (ITTTextBox)AddControl(new Guid("3b633a1c-4c0d-4e84-a93c-05afe6ee1d94"));
            labelYearCount = (ITTLabel)AddControl(new Guid("c6e2bcfa-4156-4b5a-b250-8534c8c4f26d"));
            YearCount = (ITTTextBox)AddControl(new Guid("dfb4ee69-03dc-4850-baf2-9f64e65205bd"));
            base.InitializeControls();
        }

        public YearlyAmountRuleDefinitionForm() : base("YEARLYAMOUNTRULE", "YearlyAmountRuleDefinitionForm")
        {
        }

        protected YearlyAmountRuleDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}