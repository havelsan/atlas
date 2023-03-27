
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
    /// Nükleer Tıp İş Listesi
    /// </summary>
    public partial class NuclearWLCriteriaForm : EpisodeActionWLCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region NuclearWLCriteriaForm_Methods
        public override void OnSave()
        {
            try
            {
                base.OnSave();
                this.SaveCriteria("TESTSEQUENCENO","System.String",TestSequenceNo.Text);
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            CriteriaValue crValNo = this.GetCriteriaValue("TESTSEQUENCENO");
            if(crValNo != null && !string.IsNullOrEmpty(crValNo.Value))
            {
                try
                {
                    TestSequenceNo.Text = crValNo.Value;
                }
                catch(Exception ex)
                {
                    InfoBox.Show(ex);
                }
            }
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true && String.IsNullOrEmpty(this.TestSequenceNo.Text) == true)
                return NuclearMedicine.WorkListNQL(context, dtStart, dtEnd, sExpression);
            else
                return NuclearMedicine.GetByWLFilterExpression(context,sExpression);
        }
        
        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true && String.IsNullOrEmpty(this.TestSequenceNo.Text) == true)
                return NuclearMedicine.GetByNuclearMedicineWorklistDateReport(dtStart, dtEnd, sExpression);
            else
                return NuclearMedicine.GetByWLFilterExpressionReport(sExpression);
        }
        
        public override IList ExecuteReportNQL(string sExpression)
        {
            return NuclearMedicine.GetByWLFilterExpressionReport(sExpression);
        }
        
#endregion NuclearWLCriteriaForm_Methods
    }
}