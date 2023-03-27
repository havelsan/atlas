
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


namespace TTObjectClasses
{
    public  partial class MedulaOptikReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        protected void PreTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PreTransition_New2Cancelled
            Cancel();
#endregion PreTransition_New2Cancelled
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            
            Cancel();
#endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PreTransition_Approval2Completed
            
            if(IsHeadDoctorApproved == null || IsHeadDoctorApproved == false )
            {
                  throw new TTException("Başhekim onayı yapılmadan tamamlayamazsınız! ");
                
            }

#endregion PreTransition_Approval2Completed
        }

        protected void PreTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
#region PreTransition_Approval2Cancelled
            
            Cancel();
#endregion PreTransition_Approval2Cancelled
        }

        protected void PreTransition_HeadDoctorApproval2Completed()
        {
            // From State : HeadDoctorApproval   To State : Completed
#region PreTransition_HeadDoctorApproval2Completed
            
            if(IsHeadDoctorApproved == null || IsHeadDoctorApproved == false )
            {
                  throw new TTException("Başhekim onayı yapılmadan tamamlayamazsınız! ");
                
            }

#endregion PreTransition_HeadDoctorApproval2Completed
        }

        protected void PreTransition_HeadDoctorApproval2Cancelled()
        {
            // From State : HeadDoctorApproval   To State : Cancelled
#region PreTransition_HeadDoctorApproval2Cancelled
            
            Cancel();
            /*if(this.eReceteNo != null && this.RaporSequenceNo != null)
            {
                OptikRaporIslemleri.eraporBashekimOnayRedIstekDVO _eraporBashekimOnayRedIstekDVO = new OptikRaporIslemleri.eraporBashekimOnayRedIstekDVO();
                _eraporBashekimOnayRedIstekDVO.doktorTcKimlikNo = this.ProcedureDoctor.UniqueNo;//Buraya başhekimin uniqueNo sunu göndermek gerekebilir.
                _eraporBashekimOnayRedIstekDVO.raporTakipNo = this.SubEpisode.SGKSEP.MedulaTakipNo;
                _eraporBashekimOnayRedIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
                
                string eRecetePwd = null;
                if(this.ProcedureDoctor.ErecetePassword != null)
                {
                    eRecetePwd = this.ProcedureDoctor.ErecetePassword;
                    this.ERecetePassword = eRecetePwd;
                }
                else
                    eRecetePwd = this.ERecetePassword;
                OptikRaporIslemleri.eraporBashekimOnayRedCevapDVO response = OptikRaporIslemleri.WebMethods.eraporBashekimOnayRed(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo, eRecetePwd, _eraporBashekimOnayRedIstekDVO);
                if (response != null && response.sonucKodu != null)
                {
                    this.SonucKodu = response.sonucKodu.ToString();
                    this.SonucMesaji = response.sonucMesaji;
                    this.UyariMesaji = response.uyariMesaji;
                }
                else
                {
                    this.SonucMesaji = "Meduladan cevap alınamadı!";
                    throw new TTUtils.TTException("Meduladan cevap alınamadı!");
                }
            }*/
#endregion PreTransition_HeadDoctorApproval2Cancelled
        }

#region Methods
        public MedulaOptikReport(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = MedulaOptikReport.States.New;
            Episode = episodeAction.Episode;
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
            if (theObj.IsNew)
            {
                RaporSequenceNo.GetNextValue();
            }
        }
        
      public override void Cancel()
      {
            
            if(eReceteNo != null && RaporSequenceNo != null)
            {
                OptikRaporIslemleri.eraporSilDVO _eraporSilDVO = new OptikRaporIslemleri.eraporSilDVO();
                _eraporSilDVO.doktorTcKimlikNo = ProcedureDoctor.UniqueNo;
                _eraporSilDVO.raporNoTesis = RaporSequenceNo.ToString();
                _eraporSilDVO.takipNo = SubEpisode.SGKSEP.MedulaTakipNo;
                _eraporSilDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();
                
                string eRecetePwd = null;
                if(ProcedureDoctor.ErecetePassword != null)
                {
                    eRecetePwd = ProcedureDoctor.ErecetePassword;
                    ERecetePassword = eRecetePwd;
                }
                else
                    eRecetePwd = ERecetePassword;
                OptikRaporIslemleri.eRaporSonucDVO response = OptikRaporIslemleri.WebMethods.eraporSil(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo, eRecetePwd, _eraporSilDVO);
                if (response != null && response.sonucKodu != null)
                {
                    SonucKodu = response.sonucKodu.ToString();
                    SonucMesaji = response.sonucMesaji;
                    UyariMesaji = response.uyariMesaji;
                    if(response.raporTesisDVO != null)
                        Durum = response.raporTesisDVO.durum;
                }
                else
                {
                    SonucMesaji = "Meduladan cevap alınamadı!";
                    throw new TTUtils.TTException("Meduladan cevap alınamadı!");
                }
            }
            base.Cancel();
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MedulaOptikReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MedulaOptikReport.States.New && toState == MedulaOptikReport.States.Cancelled)
                PreTransition_New2Cancelled();
            else if (fromState == MedulaOptikReport.States.Completed && toState == MedulaOptikReport.States.Cancelled)
                PreTransition_Completed2Cancelled();
            else if (fromState == MedulaOptikReport.States.Approval && toState == MedulaOptikReport.States.Completed)
                PreTransition_Approval2Completed();
            else if (fromState == MedulaOptikReport.States.Approval && toState == MedulaOptikReport.States.Cancelled)
                PreTransition_Approval2Cancelled();
            else if (fromState == MedulaOptikReport.States.HeadDoctorApproval && toState == MedulaOptikReport.States.Completed)
                PreTransition_HeadDoctorApproval2Completed();
            else if (fromState == MedulaOptikReport.States.HeadDoctorApproval && toState == MedulaOptikReport.States.Cancelled)
                PreTransition_HeadDoctorApproval2Cancelled();
        }

    }
}