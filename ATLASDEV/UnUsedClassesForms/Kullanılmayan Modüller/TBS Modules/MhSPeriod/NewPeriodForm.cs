
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Yeni Çalışma Yılı
    /// </summary>
    public partial class NewPeriodForm : TTForm
    {
        override protected void BindControlEvents()
        {
            Year.TextChanged += new TTControlEventDelegate(Year_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Year.TextChanged -= new TTControlEventDelegate(Year_TextChanged);
            base.UnBindControlEvents();
        }

        private void Year_TextChanged()
        {
#region NewPeriodForm_Year_TextChanged
   if(String.IsNullOrEmpty(Year.Text))
               Alias.Text = "";
            else
                Alias.Text = Year.Text + " " + "Çalışma Yılı";
#endregion NewPeriodForm_Year_TextChanged
        }

        protected override void PreScript()
        {
#region NewPeriodForm_PreScript
    //TemplateChartOfAccounts.ListFilterExpression =
#endregion NewPeriodForm_PreScript

            }
                }
}