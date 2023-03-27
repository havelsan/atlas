
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
    /// Aylık Miktar Kuralı Tanımlama
    /// </summary>
    public partial class MonthlyAmountRuleDefinitionForm : RuleBaseDefinitionForm
    {
    /// <summary>
    /// Aylık Miktar Kuralı
    /// </summary>
        protected TTObjectClasses.MonthlyAmountRule _MonthlyAmountRule
        {
            get { return (TTObjectClasses.MonthlyAmountRule)_ttObject; }
        }

        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        protected ITTLabel labelMonthCount;
        protected ITTTextBox MonthCount;
        override protected void InitializeControls()
        {
            labelAmount = (ITTLabel)AddControl(new Guid("975cc157-cf15-43b4-a234-4d8d64bf2de4"));
            Amount = (ITTTextBox)AddControl(new Guid("2a63982d-f2f1-40ba-9ddd-95fd943a11f9"));
            labelMonthCount = (ITTLabel)AddControl(new Guid("ae83d938-b38c-48ac-92f4-04892e9cc4e1"));
            MonthCount = (ITTTextBox)AddControl(new Guid("6b6bf405-366a-48fa-bc19-172852a04e6d"));
            base.InitializeControls();
        }

        public MonthlyAmountRuleDefinitionForm() : base("MONTHLYAMOUNTRULE", "MonthlyAmountRuleDefinitionForm")
        {
        }

        protected MonthlyAmountRuleDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}