
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
    /// Sağlık Kurulu Zeyil/Ek Raporları
    /// </summary>
    public partial class HCAdditionalReportForm : TTForm
    {
        override protected void BindControlEvents()
        {
            IsOtherHospitalHC.CheckedChanged += new TTControlEventDelegate(IsOtherHospitalHC_CheckedChanged);
            lstHealthCommittee.SelectedObjectChanged += new TTControlEventDelegate(lstHealthCommittee_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IsOtherHospitalHC.CheckedChanged -= new TTControlEventDelegate(IsOtherHospitalHC_CheckedChanged);
            lstHealthCommittee.SelectedObjectChanged -= new TTControlEventDelegate(lstHealthCommittee_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void IsOtherHospitalHC_CheckedChanged()
        {
#region HCAdditionalReportForm_IsOtherHospitalHC_CheckedChanged
   if(this._HealthCommitteeAdditionalReport.IsOtherHospitalHC == true)
            {
                this.lstHealthCommittee.Required = false;
                this.HCHospitalName.ReadOnly = false;
                this.HCReportNo.ReadOnly = false;
                this.HCDate.ReadOnly = false;
                this.CommitteeTypeCombo.ReadOnly = false;
                this.HCHospitalName.Required = true;
                this.HCReportNo.Required = true;
                this.HCDate.Required = true;
                this.CommitteeTypeCombo.Required = true;
            }
            else
            {
                this.lstHealthCommittee.Required = true;
                this.HCHospitalName.ReadOnly = true;
                this.HCReportNo.ReadOnly = true;
                this.HCDate.ReadOnly = true;
                this.CommitteeTypeCombo.ReadOnly = true;
                this.HCHospitalName.Text = null;
                this.HCReportNo.Text = null;
                this.HCDate.Text = null;
                this.CommitteeTypeCombo.SelectedValue = null;
                this.HCHospitalName.Required = false;
                this.HCReportNo.Required = false;
                this.HCDate.Required = false;
                this.CommitteeTypeCombo.Required = false;
            }
#endregion HCAdditionalReportForm_IsOtherHospitalHC_CheckedChanged
        }

        private void lstHealthCommittee_SelectedObjectChanged()
        {
#region HCAdditionalReportForm_lstHealthCommittee_SelectedObjectChanged
   if(this._HealthCommitteeAdditionalReport.HealthCommittee != null)
            {
                this.IsOtherHospitalHC.ReadOnly = true;
                //this.HCHospitalName.ReadOnly = true;
                //this.HCReportNo.ReadOnly = true;
                //this.HCDate.ReadOnly = true;
                this.IsOtherHospitalHC.Value = false;
                //this.HCHospitalName = null;
                //this.HCReportNo = null;
                //this.HCDate = null;
            }
            else
            {
                this.IsOtherHospitalHC.ReadOnly = false;
            }
#endregion HCAdditionalReportForm_lstHealthCommittee_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region HCAdditionalReportForm_PreScript
    base.PreScript();
            this.lstHealthCommittee.ListFilterExpression = "EPISODE = '" + this._HealthCommitteeAdditionalReport.Episode.ObjectID.ToString() + "'";
            
            if(_HealthCommitteeAdditionalReport.CurrentStateDefID == HealthCommitteeAdditionalReport.States.New)
            {
                
                if (_HealthCommitteeAdditionalReport.ReportNo.Value == null)
                    _HealthCommitteeAdditionalReport.ReportDate = Common.RecTime();
            }
            else
                if(_HealthCommitteeAdditionalReport.CurrentStateDefID == HealthCommitteeAdditionalReport.States.Completed)
            {
                if (_HealthCommitteeAdditionalReport.ReportType == HCAdditionalReportTypeEnum.AddendumReport)
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_HCAdditionalReport));
                else if(_HealthCommitteeAdditionalReport.ReportType == HCAdditionalReportTypeEnum.AdditionalReport)
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_HCAddendumReport));
            }
            
            if(this._HealthCommitteeAdditionalReport.CurrentStateDefID == HealthCommitteeAdditionalReport.States.New)
            {
                this.IsOtherHospitalHC.Value = false;
            }
            //if(this._HealthCommitteeAdditionalReport.HealthCommittee != null)
            //{
                //this.IsOtherHospitalHC.ReadOnly = true;
                //this.HCHospitalName.ReadOnly = true;
                //this.HCReportNo.ReadOnly = true;
                //this.HCDate.ReadOnly = true;
            //}
#endregion HCAdditionalReportForm_PreScript

            }
            
#region HCAdditionalReportForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            // Zeyil ve Ek raporlar dökülür
            if(transDef != null && transDef.ToStateDefID == HealthCommitteeAdditionalReport.States.Completed)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                
                TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                cache.Add("VALUE", _HealthCommitteeAdditionalReport.ObjectID.ToString());
                
                parameters.Add("TTOBJECTID",cache);
                if (_HealthCommitteeAdditionalReport.ReportType == HCAdditionalReportTypeEnum.AddendumReport)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCAddendumReport), true, 1, parameters);
                else if(_HealthCommitteeAdditionalReport.ReportType == HCAdditionalReportTypeEnum.AdditionalReport)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCAdditionalReport), true, 1, parameters);
            }
        }
        
#endregion HCAdditionalReportForm_Methods
    }
}