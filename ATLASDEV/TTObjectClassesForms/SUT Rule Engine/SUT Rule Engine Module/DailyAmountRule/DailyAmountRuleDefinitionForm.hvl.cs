
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
    /// Günlük Miktar Kuralı Tanımlama
    /// </summary>
    public partial class DailyAmountRuleDefinitionForm : RuleBaseDefinitionForm
    {
    /// <summary>
    /// Günlük Miktar Kuralı
    /// </summary>
        protected TTObjectClasses.DailyAmountRule _DailyAmountRule
        {
            get { return (TTObjectClasses.DailyAmountRule)_ttObject; }
        }

        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        protected ITTLabel labelDayCount;
        protected ITTTextBox DayCount;
        override protected void InitializeControls()
        {
            labelAmount = (ITTLabel)AddControl(new Guid("d0b90f44-54bb-4854-9d4c-b567c8c8756b"));
            Amount = (ITTTextBox)AddControl(new Guid("79d4f46d-1c61-4e0c-927c-123e3b6b387a"));
            labelDayCount = (ITTLabel)AddControl(new Guid("0c1c867d-dacb-48bc-8f7e-2aaaaadeca33"));
            DayCount = (ITTTextBox)AddControl(new Guid("f70d0917-0392-4647-bbb1-03c21ca51a16"));
            base.InitializeControls();
        }

        public DailyAmountRuleDefinitionForm() : base("DAILYAMOUNTRULE", "DailyAmountRuleDefinitionForm")
        {
        }

        protected DailyAmountRuleDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}