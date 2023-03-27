
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
    /// Döner Sermaye İş Listesi
    /// </summary>
    public partial class InvoicingWLCriteriaForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region InvoicingWLCriteriaForm_Methods
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true)
                return BaseAction.GetByBaseActionWorklistDate(context, dtStart, dtEnd, sExpression);
            else
                return BaseAction.GetByWLFilterExpression(context,sExpression);
        }
        
        public override void OnSave()
        {
            try
            {
                this.SaveCriteria("ID", "System.Int64", this.ActionID.Text);
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }

        }
        
#endregion InvoicingWLCriteriaForm_Methods
    }
}