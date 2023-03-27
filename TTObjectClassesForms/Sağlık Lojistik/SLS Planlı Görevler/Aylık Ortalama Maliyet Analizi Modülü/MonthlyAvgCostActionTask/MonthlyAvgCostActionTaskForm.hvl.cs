
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
    public partial class MonthlyAvgCostActionTaskForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Aylık Ortalama Maliyet Analizi
    /// </summary>
        protected TTObjectClasses.MonthlyAvgCostActionTask _MonthlyAvgCostActionTask
        {
            get { return (TTObjectClasses.MonthlyAvgCostActionTask)_ttObject; }
        }

        protected ITTTextBox DayOfMonthly;
        protected ITTLabel labelDayOfMonthly;
        override protected void InitializeControls()
        {
            DayOfMonthly = (ITTTextBox)AddControl(new Guid("6a45d8d4-4594-42b0-b546-e8d4c1fb9e46"));
            labelDayOfMonthly = (ITTLabel)AddControl(new Guid("cbec3c65-14ff-4325-be75-2151b7f28746"));
            base.InitializeControls();
        }

        public MonthlyAvgCostActionTaskForm() : base("MONTHLYAVGCOSTACTIONTASK", "MonthlyAvgCostActionTaskForm")
        {
        }

        protected MonthlyAvgCostActionTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}