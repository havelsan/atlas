
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
    /// Hasta Kabul Düzeltme
    /// </summary>
    public partial class PatientAdmissionCorrectionRequestForm : EpisodeActionForm
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
#region PatientAdmissionCorrectionRequestForm_PreScript
    base.PreScript();
            
//            if(this._EpisodeAction.Episode.CurrentStateDefID != Episode.States.Open) // Kapalı episodelarda bu işlemi yanlız admin başlatabilir
//            {
//                if((!Common.CurrentUser.IsSuperUser) && (!Common.CurrentUser.IsPowerUser) && (Common.CurrentUser.HasRole(Common.PatientAdmissionCorrectionForClosedEpisodeRoleID) == false))
//                    throw new Exception ("'AçıkDevam' ve 'Kapalı' vakalarda Hasta Kabul Düzeltme işlemi yanlızca 'Hasta Kabul Düzeltme(Kapalı Vakalarda)' yetkisi olan kullanıcı tarafından yapılabilir. ");
//                
//            }
//            
//            if(!this.ReadOnly)
//            {
//                this.HideForm();
//                this.CancelOldFireNewPatientAdmission();
//            }
#endregion PatientAdmissionCorrectionRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PatientAdmissionCorrectionRequestForm_PostScript
    base.PostScript(transDef);
#endregion PatientAdmissionCorrectionRequestForm_PostScript

            }
            
#region PatientAdmissionCorrectionRequestForm_Methods
        public void CancelOldFireNewPatientAdmission()
        {
          //  this._PatientAdmissionCorrection.OldPatientAdmission=this._PatientAdmissionCorrection.SubEpisode.PatientAdmission;
            TTObjectDef objDef=null;
            if(this._EpisodeAction.SubEpisode.PatientAdmission!=null)
                objDef=this._EpisodeAction.SubEpisode.PatientAdmission.ObjectDef;

            
//            PatientAdmission firedAction= PatientForm.FireNewPatientAdmission(this._PatientAdmissionCorrection.Episode.Patient,this,objDef,this._PatientAdmissionCorrection.Episode,null);
//            if(firedAction==null)
//            {
//                throw new Exception ("Hasta Kabul düzeltme işleminden vazgeçildi");
//            }
//            else
//            {
//                if(this._PatientAdmissionCorrection.OldPatientAdmission.FiredEpisodeActions.Count>0)
//                {
//                    List<EpisodeAction> firedActionList= new List<EpisodeAction>();
//                    foreach (EpisodeAction fea in this._PatientAdmissionCorrection.OldPatientAdmission.FiredEpisodeActions)
//                        firedActionList.Add(fea);
//                    
//                    foreach(EpisodeAction fea in firedActionList)
//                    {
//                        //Episode da Yeni durumunda Muayene varsa o işlem iptal edilecek, yeni kabul yapılan bölümün branşı episode branşına set edilecek.
//                        //Yeni, Cancel ve Hasta Gelmedi durumları dışında muayene işlemi varsa PatientAdmission formunun prescriptinde engellendi.
//                        if (firedAction.FiredEpisodeActions.Count > 0)
//                        {
//                            if (fea is PatientExamination)
//                            {
//                                if (fea.CurrentStateDefID  == PatientExamination.States.New )
//                                {
//                                    fea.CurrentStateDefID = PatientExamination.States.Cancelled;
//                                }
//                                
//                                this._PatientAdmissionCorrection.Episode.MainSpeciality =  firedAction.FiredEpisodeActions[0].ProcedureSpeciality;
//                            }
//                        }
//                        
//                        if (!fea.IsCancelled && fea.CurrentStateDef.Status != StateStatusEnum.Cancelled)
//                            fea.PatientAdmission=firedAction;
//                    }
//                }
//                
//                
//                if(this._PatientAdmissionCorrection.OldPatientAdmission.ResourcesToBeReferred.Count>0)
//                {
//                    List<PatientAdmissionResourcesToBeReferred> rrList= new List<PatientAdmissionResourcesToBeReferred>();
//                    foreach (PatientAdmissionResourcesToBeReferred rr in  this._PatientAdmissionCorrection.OldPatientAdmission.ResourcesToBeReferred)
//                        rrList.Add(rr);
//                    foreach (PatientAdmissionResourcesToBeReferred rr in  rrList)
//                        rr.PatientAdmission=firedAction;
//                    
//                    
//                }
//                
//                this._PatientAdmissionCorrection.LinkedActions.Add(firedAction);
//                this._PatientAdmissionCorrection.NewPatientAdmission=firedAction;
//                this._PatientAdmissionCorrection.SubEpisode.PatientAdmission=firedAction;
//                
//                
//
//                if (this._PatientAdmissionCorrection.OldPatientAdmission!=null)
//                {
//                    this._PatientAdmissionCorrection.OldPatientAdmission.IsCorrected=true;
//                    ((ITTObject)this._PatientAdmissionCorrection.OldPatientAdmission).Cancel();
//                }
//                this.SetRequestStateToDataCorrected();
//            }
            
        }
        public void SetRequestStateToDataCorrected()
        {
//            Guid stateDefID = PatientAdmissionCorrection.States.DataCorrected;
//            TTObjectStateTransitionDef transDef = (TTObjectStateTransitionDef) this._PatientAdmissionCorrection.CurrentStateDef.FindOutoingTransitionDefFromStateDefID(stateDefID);
//            this.DoContextUpdate(transDef);
        }
        
#endregion PatientAdmissionCorrectionRequestForm_Methods
    }
}