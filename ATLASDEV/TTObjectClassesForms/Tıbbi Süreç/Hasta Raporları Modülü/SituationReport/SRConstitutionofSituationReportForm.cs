
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
    /// Akibet Raporu
    /// </summary>
    public partial class SRConstitutionofSituationReportForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region SRConstitutionofSituationReportForm_PreScript
    base.PreScript();
            
            this._SituationReport.Date = Common.RecTime().Date;
            this._SituationReport.SiteName = TTObjectClasses.SystemParameter.GetParameterValue("SITENAME", "XXXXXX");
            this._SituationReport.HeadDoctor = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR", "XXXXXX");            
            
            this._SituationReport.HealthCommitteeDiagnosis = "";
            this._SituationReport.HealthCommitteeMatters = "[";
            if(this._SituationReport.HealthCommitteeAction != null)
            {
                //TODO: SKYAZIKODU eklenecek, şimdilik 9999 yapıldı...YY
                this._SituationReport.SNO = "9999" + "-" +this._SituationReport.HealthCommitteeAction.ProtocolNo.Value.ToString() + "-" + Common.RecTime().Year + "/SAĞ.KRL.-";
                this._SituationReport.SNO+=this._SituationReport.HealthCommitteeAction.ID == null ? "0" : this._SituationReport.HealthCommitteeAction.ID.Value.ToString();
                
                foreach(HealthCommittee_DiagnosisGrid pDiagnosis in this._SituationReport.HealthCommitteeAction.Diagnosis)
                {
                    this._SituationReport.HealthCommitteeDiagnosis += pDiagnosis.Diagnose.Name + ", ";
                }
                foreach(HealthCommittee_MatterSliceAnectodeGrid pAnectode in this._SituationReport.HealthCommitteeAction.MatterSliceAnectodes)
                {
                    this._SituationReport.HealthCommitteeMatters += pAnectode.Matter+"/"+pAnectode.Slice+"/"+pAnectode.Anectode + ", ";
                }
                this._SituationReport.HealthCommitteeMatters += "]";
            }
#endregion SRConstitutionofSituationReportForm_PreScript

            }
                }
}