
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
    /// <summary>
    /// İş Görmezlik Belgesi
    /// </summary>
    public  partial class UnavailableToWorkReport : EpisodeAction
    {
        public partial class GetUnavailableToWorkReport_Class : TTReportNqlObject 
        {
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();

#endregion PostUpdate
        }

        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();

#endregion PreDelete
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            //if(!string.IsNullOrEmpty (this.MedulaChasingNo))
//            {
//                throw new TTException("İş Görmezlik Belgesi Medula'ya kaydedildiğinden geri alınamaz!");
//            }
#endregion UndoTransition_New2Completed
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            















            //if (this.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this.SubEpisode.SGKSEP.MedulaTakipNo))
            // {
            try
            {
                //RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, GetRaporBilgisiSil(this));
                //if (response != null && response.sonucKodu != null)
                //{
                //    if (response.sonucKodu.Equals(0))
                //    {
                //        this.ResultCode = response.sonucKodu.ToString();
                //    }
                //    else
                //    {
                //        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                //        {
                //            throw new TTException("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                //        }

                //    }
                //}
            }
            catch (Exception)
            {

                throw;
            }
            //  }
            // else
            // {

            //      throw new TTException("Hastaya Medula Provizyon Alınmadığında Dolayı Rapor Kaydı Yapılamamıştır.");
            //  }














#endregion PreTransition_Completed2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            
            //
            //            if(!string.IsNullOrEmpty (this.MedulaChasingNo))
            //            {
            //                throw new TTException("İş Görmezlik Belgesi Medula'ya kaydedildiğinden iptal edilemez!");
            //            }
            
            
            
            // İptal işleminde meduladan silinmesi
            
            if (SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(SubEpisode.SGKSEP.MedulaTakipNo))
            {
                try
                {
                    int vakaTuru = 0;

                    if (Excuse != null)
                    {
                        switch (Convert.ToInt32(Excuse))
                        {
                            case 0:
                                vakaTuru = 1;
                                break;
                            case 1:
                                vakaTuru = 2;
                                break;
                            case 2:
                                vakaTuru = 3;
                                break;
                            case 3:
                                vakaTuru = 4;
                                break;
                            case 4:
                                vakaTuru = 5;
                                break;
                        }
                    }

                    if (string.IsNullOrEmpty(MedulaChasingNo) || string.IsNullOrEmpty(ReportRowNumber))
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M26745", "Rapor Medulaya Kayıt Edilmediğinden Dolayı Rapor Silme İşlemi Gerçekleştirilmedi!!!"));
                    }
                    else
                    {
                        IsGormezlikServis.CevapDTO response = IsGormezlikServis.WebMethods.raporSilSync(Sites.SiteLocalHost, MedulaChasingNo, Convert.ToInt32(ReportRowNumber), vakaTuru, TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                        //if (response != null && response.sonucKodu != null)
                        if (response != null)
                        {
                            if (response.sonucKodu.Equals(0))
                            {
                                BindingList<UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class> getUnavailToWorkRptInfo = UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery(Convert.ToInt64(Episode.Patient.UniqueRefNo));
                                TTObjectContext newContext = new TTObjectContext(false);
                                foreach (UnavailToWorkRprtInfo.GetUnavailToWorkRptInfoQuery_Class item in getUnavailToWorkRptInfo)
                                {
                                    if (item.MedulaChasingNo == MedulaChasingNo && item.ReportRowNumber == ReportRowNumber)
                                    {
                                        UnavailToWorkRprtInfo unavailToWorkRprtInfo = (UnavailToWorkRprtInfo)newContext.GetObject((item.ObjectID).GetValueOrDefault(), typeof(UnavailToWorkRprtInfo));
                                        unavailToWorkRprtInfo.ReportDeleted = true;
                                        newContext.Save();
                                    }
                                }

                                TTObjectContext context = ObjectContext;
                                UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(ObjectID, typeof(UnavailableToWorkReport));
                                ResultCode = response.sonucKodu.ToString();
                                ResultExplanation = TTUtils.CultureService.GetText("M26743", "Rapor Bilgisi Silinmiştir");
                                unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
                                unavailableToWorkReport.ResultExplanation = TTUtils.CultureService.GetText("M26743", "Rapor Bilgisi Silinmiştir");
                                unavailableToWorkReport.MedulaChasingNo = "";
                                unavailableToWorkReport.ReportRowNumber = "";
                                unavailableToWorkReport.CarryCase = CarryCaseTypeEnum.No;
                                MedulaChasingNo = "";
                                ReportRowNumber = "";
                                //context.Save();

                                TTUtils.InfoMessageService.Instance.ShowMessage("Hastanın Raporu Silinmiştir ! ");
                            }
                            else
                            {
//                                TTObjectContext context = this.ObjectContext;
//                                UnavailableToWorkReport unavailableToWorkReport = (UnavailableToWorkReport)context.GetObject(this.ObjectID, typeof(UnavailableToWorkReport));
//                                this.ResultCode = response.sonucKodu.ToString();
//                                this.ResultExplanation = response.hataMesaji;
//                                unavailableToWorkReport.ResultCode = response.sonucKodu.ToString();
//                                unavailableToWorkReport.ResultExplanation = response.hataMesaji;
//                                unavailableToWorkReport.CarryCase = CarryCaseTypeEnum.No;
                                //context.Save();
                                
                                throw new Exception("Hastanın Raporu Silinememiştir !!! " +  response.hataMesaji);
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            

#endregion PostTransition_Completed2Cancelled
        }

#region Methods
        public UnavailableToWorkReport(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = UnavailableToWorkReport.States.New;
            Episode = episodeAction.Episode;
        }

        public UnavailableToWorkReport(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = UnavailableToWorkReport.States.New;
            Episode = subactionProcedureFlowable.Episode;
        }
        
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
            if (theObj.IsNew)
            {
                ReportSeqNo.GetNextValue();
            }
        }

        public static void CheckRequiredFields(UnavailableToWorkReport unavailableToWorkReport)
        {
            switch ((int)unavailableToWorkReport.ContinuedHospitalizationType)
            {
                    //Yatış Var, Taburcu olmuş
                case 3:
                    if (unavailableToWorkReport.DischargeDate == null)
                        throw new TTUtils.TTException("Yatış Devam Durumu Yatış Var, Taburcu Olmuş Secilmiş İse XXXXXX Çıkış Tarihi Zorunludur ");

                    if (unavailableToWorkReport.SubEpisode.InpatientAdmission != null && unavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27219", "Yatış Devam Durumu Yatış Devam Ediyor Secilmiş İse XXXXXX Yatış Tarihi Zorunludur"));
                    break;

                    //Yatış Devam Ediyor
                case 2:
                    if (unavailableToWorkReport.SubEpisode.InpatientAdmission!= null && unavailableToWorkReport.SubEpisode.InpatientAdmission.HospitalInPatientDate == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27219", "Yatış Devam Durumu Yatış Devam Ediyor Secilmiş İse XXXXXX Yatış Tarihi Zorunludur"));
                    break;
            }
        }
        
        
//        public void CheckUndoAndCancelRules()
//        {
//            if (!string.IsNullOrEmpty(this.MedulaChasingNo))
//            {
//                if(this.TransDef != null && this.CurrentStateDefID != null)
//                {
//                    //Tamamlandı -> İptal (İptal Etme)
//                    if (this.CurrentStateDef.StateDefID.Equals(UnavailableToWorkReport.States.Completed) == true  &&(this.TransDef.ToStateDefID.Equals(UnavailableToWorkReport.States.Cancelled) == true))
//                        throw new TTException("İş GÖrmezlik Belgesi Medula'ya kaydedildiğinden iptal edilemez!");
//                    //Tamamlandı -> Yeni  (Geri Alma)
//                    if (this.CurrentStateDef.StateDefID.Equals(UnavailableToWorkReport.States.Completed) == true && (this.TransDef.ToStateDefID.Equals(UnavailableToWorkReport.States.New) == true))
//                        throw new TTException("İş GÖrmezlik Belgesi Medula'ya kaydedildiğinden geri alınamaz!");
//                }
//            }
//            
//        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(UnavailableToWorkReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == UnavailableToWorkReport.States.Completed && toState == UnavailableToWorkReport.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(UnavailableToWorkReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == UnavailableToWorkReport.States.Completed && toState == UnavailableToWorkReport.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(UnavailableToWorkReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == UnavailableToWorkReport.States.New && toState == UnavailableToWorkReport.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}