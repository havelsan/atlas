
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
    /// Tıbbi Genetik İş Listesi
    /// </summary>
    public partial class GeneticWLCriteriaForm : EpisodeActionWLCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region GeneticWLCriteriaForm_Methods
        public override void OnSave()
        {
            try
            {
                base.OnSave();
                this.SaveCriteria("GENETICSAMPLENO","System.String",GeneticSampleNo.Text);
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
            
            CriteriaValue crValNo = this.GetCriteriaValue("GENETICSAMPLENO");
            if(crValNo != null && !string.IsNullOrEmpty(crValNo.Value))
            {
                try
                {
                    GeneticSampleNo.Text = crValNo.Value;
                }
                catch(Exception ex)
                {
                    InfoBox.Show(ex);
                }
            }
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true && String.IsNullOrEmpty(this.GeneticSampleNo.Text) == true)
                return Genetic.WorkListNQL(context, dtStart, dtEnd, sExpression);
            else
                return Genetic.GetByWLFilterExpression(context, sExpression);
        }
        
        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true && String.IsNullOrEmpty(this.GeneticSampleNo.Text) == true)
                return Genetic.GetByGeneticWorklistDateReport(dtStart, dtEnd, sExpression);
            else
                return Genetic.GetByGeneticFilterExpressionReport(sExpression);
        }
        
        public override IList ExecuteReportNQL(string sExpression)
        {
            return Genetic.GetByGeneticFilterExpressionReport(sExpression);
        }
        
#endregion GeneticWLCriteriaForm_Methods
    }
}