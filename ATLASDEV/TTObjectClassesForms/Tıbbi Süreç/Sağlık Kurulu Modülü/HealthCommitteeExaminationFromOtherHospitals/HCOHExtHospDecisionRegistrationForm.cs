
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
    public partial class HCOHExtHospDecisionRegistrationForm : EpisodeActionForm
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
#region HCOHExtHospDecisionRegistrationForm_IsHealthy_CheckedChanged
   if(this._HealthCommitteeExaminationFromOtherHospitals.IsHealthy == true)
            {
       if(this._HealthCommitteeExaminationFromOtherHospitals.Report == null || (this._HealthCommitteeExaminationFromOtherHospitals.Report != null && string.IsNullOrEmpty(Common.GetTextOfRTFString(this._HealthCommitteeExaminationFromOtherHospitals.Report.ToString()).Trim())))
                    this.ttrichtextboxcontrol1.Text = "SAĞLAM";   //Report
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
#endregion HCOHExtHospDecisionRegistrationForm_IsHealthy_CheckedChanged
        }

        protected override void PreScript()
        {
#region HCOHExtHospDecisionRegistrationForm_PreScript
    base.PreScript();
            
            if(this._HealthCommitteeExaminationFromOtherHospitals.CurrentStateDefID == HealthCommitteeExaminationFromOtherHospitals.States.ExternalHospitalDecisionRegistration)
            {
                if(this._HealthCommitteeExaminationFromOtherHospitals.ReportDate == null)
                    this._HealthCommitteeExaminationFromOtherHospitals.ReportDate = Common.RecTime();
                
                if(this._HealthCommitteeExaminationFromOtherHospitals.DrSpeciality == null)
                    this._HealthCommitteeExaminationFromOtherHospitals.DrSpeciality = this._HealthCommitteeExaminationFromOtherHospitals.Speciality;
            }
            else if(this._HealthCommitteeExaminationFromOtherHospitals.CurrentStateDefID == HealthCommitteeExaminationFromOtherHospitals.States.Resulted)
            {
                // Muayeneye Gönderen XXXXXX
                //if(String.IsNullOrEmpty(this._HealthCommitteeExaminationFromOtherHospitals.SourceObjectID))
                //{
                   // if(!Common.CurrentUser.IsSuperUser)
                   //   this.DropStateButton(HealthCommitteeExaminationFromOtherHospitals.States.ExternalHospitalDecisionRegistration);
                //}
                //else 
                if(!String.IsNullOrEmpty(this._HealthCommitteeExaminationFromOtherHospitals.SourceObjectID))  // Muayeneye Gönderilen XXXXXX
                {
                    this.DropStateButton(HealthCommitteeExaminationFromOtherHospitals.States.ExternalHospitalDecisionRegistration);
                    this.DropStateButton(HealthCommitteeExaminationFromOtherHospitals.States.Cancelled);
                    
                    if(this._HealthCommitteeExaminationFromOtherHospitals.ReportNo.Value != null)
                        this.ReportNoText.Text = this._HealthCommitteeExaminationFromOtherHospitals.ReportNo.Value.ToString();
                }
            }
#endregion HCOHExtHospDecisionRegistrationForm_PreScript

            }
                }
}