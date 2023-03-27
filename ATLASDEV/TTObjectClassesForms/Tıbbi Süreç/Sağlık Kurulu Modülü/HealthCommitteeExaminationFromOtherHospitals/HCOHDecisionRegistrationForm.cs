
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
    /// Diğer XXXXXXlerden Sağlık Kurulu Muayenesi
    /// </summary>
    public partial class HCOHDecisionRegistrationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            IsHealthy.CheckedChanged += new TTControlEventDelegate(IsHealthy_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IsHealthy.CheckedChanged -= new TTControlEventDelegate(IsHealthy_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void IsHealthy_CheckedChanged()
        {
#region HCOHDecisionRegistrationForm_IsHealthy_CheckedChanged
   if(this._HealthCommitteeExaminationFromOtherHospitals.IsHealthy == true)
            {
       if(this._HealthCommitteeExaminationFromOtherHospitals.Report == null || (this._HealthCommitteeExaminationFromOtherHospitals.Report != null && string.IsNullOrEmpty(Common.GetTextOfRTFString(this._HealthCommitteeExaminationFromOtherHospitals.Report.ToString()).Trim())))
                    this.Report.Text = "SAĞLAM";
                bool healthyDiagnoseExists = false;
                foreach(DiagnosisGrid sdg in this._HealthCommitteeExaminationFromOtherHospitals.SecDiagnosis)
                {
                    if(sdg.DiagnoseCode.Trim() == "Z13.9")
                    {
                        healthyDiagnoseExists = true;
                        break;
                    }
                }
                if(!healthyDiagnoseExists)
                {
                    DiagnosisDefinition healthyDiagnosis = null;
                    BindingList<DiagnosisDefinition> ddList = DiagnosisDefinition.GetDiagnosisDefinitionByCode(this._HealthCommitteeExaminationFromOtherHospitals.ObjectContext, "Z13.9", "");
                    foreach(DiagnosisDefinition dd in ddList)
                    {
                        healthyDiagnosis = dd;
                        break;
                    }
                    if(healthyDiagnosis != null)
                    {
                        DiagnosisGrid healthyDiagnosisGrid = new DiagnosisGrid(this._HealthCommitteeExaminationFromOtherHospitals.ObjectContext);
                        healthyDiagnosisGrid.Diagnose = healthyDiagnosis;
                        healthyDiagnosisGrid.DiagnosisType = DiagnosisTypeEnum.Seconder;
                        this._HealthCommitteeExaminationFromOtherHospitals.SecDiagnosis.Add(healthyDiagnosisGrid);
                    }
                }
            }
            else
            {
                if(this._HealthCommitteeExaminationFromOtherHospitals.Report != null && (Common.GetTextOfRTFString(this._HealthCommitteeExaminationFromOtherHospitals.Report.ToString()).ToUpper()).Trim() == "SAĞLAM")
                    this._HealthCommitteeExaminationFromOtherHospitals.Report = "";
                List<DiagnosisGrid> sdgList = new List<DiagnosisGrid>();
                foreach(DiagnosisGrid sdg in this._HealthCommitteeExaminationFromOtherHospitals.SecDiagnosis)
                {
                    if(sdg.DiagnoseCode.Trim() == "Z13.9")
                        sdgList.Add(sdg);
                }
                
                foreach(DiagnosisGrid sdg in sdgList)
                    ((ITTObject)sdg).Delete();
            }
#endregion HCOHDecisionRegistrationForm_IsHealthy_CheckedChanged
        }

        protected override void PreScript()
        {
#region HCOHDecisionRegistrationForm_PreScript
    base.PreScript();

            
            // Muayeneye Gönderen XXXXXX
            if(String.IsNullOrEmpty(this._HealthCommitteeExaminationFromOtherHospitals.SourceObjectID))
            {
                this.DropStateButton(HealthCommitteeExaminationFromOtherHospitals.States.Resulted);
                this.DropStateButton(HealthCommitteeExaminationFromOtherHospitals.States.Cancelled);
                
                this.cmdOK.Visible = false;
                this.ReportDate.ReadOnly = true;
                this.NumberOfProcess.ReadOnly = true;
                this.Doctor.ReadOnly = true;
                this.OfferofDecision.ReadOnly = true;
                this.HCTSMatterSliceAnectode.ReadOnly = true;
                this.GridDiagnosis.ReadOnly = true;
                this.Report.ReadOnly = true;
            }
            else // Muayeneye Gönderilen XXXXXX
            {
                ResUser currentUser = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                if (currentUser.UserType == UserTypeEnum.Doctor)
                    this._HealthCommitteeExaminationFromOtherHospitals.Doctor = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                
                if(this._HealthCommitteeExaminationFromOtherHospitals.ReportDate == null)
                    this._HealthCommitteeExaminationFromOtherHospitals.ReportDate = Common.RecTime();
            }
            //Malzeme listesi set ediliyor.
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"], (ITTGridColumn)this.TreatmentMaterialsGrid.Columns["Material"]);
#endregion HCOHDecisionRegistrationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HCOHDecisionRegistrationForm_PostScript
    base.PostScript(transDef);
#endregion HCOHDecisionRegistrationForm_PostScript

            }
            
#region HCOHDecisionRegistrationForm_Methods
        /*
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (!String.IsNullOrEmpty(this._HealthCommitteeExaminationFromOtherHospitals.SourceObjectID))
            {
                if(transDef != null && (transDef.ToStateDefID.Equals(HealthCommitteeExaminationFromOtherHospitals.States.Resulted) || transDef.ToStateDefID.Equals(HealthCommitteeExaminationFromOtherHospitals.States.Cancelled)))
                    this._HealthCommitteeExaminationFromOtherHospitals.RunReturnHealthCommitteeExaminationFromOtherHospitals();
            }
        }
        */
        
#endregion HCOHDecisionRegistrationForm_Methods
    }
}