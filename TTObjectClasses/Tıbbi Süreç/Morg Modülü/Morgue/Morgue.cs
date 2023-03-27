
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
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class Morgue : EpisodeAction, IWorkListEpisodeAction
    {
        public partial class OLAP_GetMorgue_Class : TTReportNqlObject 
        {
        }

        public partial class GetDeathPatientCount_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetCancelledMorgue_Class : TTReportNqlObject 
        {
        }

        public partial class GetMorgueRequests_Class : TTReportNqlObject 
        {
        }

        public partial class VEM_HASTA_OLUM_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "CUPBOARD":
                    {
                        CupboardDefinition value = (CupboardDefinition)newValue;
#region CUPBOARD_SetParentScript
                        if(Cupboard!=value)
            {
                if (Cupboard!=null)
                {
                    Cupboard.UsedByAction=null;
                }
                if (value!=null)
                {
                    value.UsedByAction=(BaseAction)this;
                }
            }
#endregion CUPBOARD_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
            
            //Klinik taburcu tarihi morga gönderildiği tarih olarak set ediliyor.
            if(StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)//Morg işlemi ölüdoğan bebek için başlatıldı ise
            {
                if (Episode.PatientStatus==PatientStatusEnum.Inpatient)
                {
                    foreach(InpatientAdmission ia in Episode.InpatientAdmissions)
                    {
                        if(ia.CurrentStateDef.Status != StateStatusEnum.Cancelled && ia.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                        {
                            if(ia.ActiveInPatientTrtmentClcApp != null)
                            {
                                ia.ActiveInPatientTrtmentClcApp.ClinicDischargeDate = RequestDate;
                            }
                        }
                    }
                }
            }
#endregion PostInsert
        }

        protected override void PostDelete()
        {
#region PostDelete
            //İstek adımını geçtiyse ;İstekden farklı tüm adımlarda 
               //YAPILACAKLAR//Buraya hastanın Episodelarını kapatılmadan önceki  son stateleri  çevirecek script yazılmalı
            //Son stepde ise;Tamam Stepinde
               Episode.Patient.Death = true;
               //YAPILACAKLAR//Episodun durumunu eski stateine çevirecek Script yazılmalı
               NoCancel();
#endregion PostDelete
        }

        protected void PreTransition_Delivery2Completed()
        {
            // From State : Delivery   To State : Completed
#region PreTransition_Delivery2Completed
            
            
            if(StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)//Morg işlemi ölüdoğan bebek için başlatıldı ise patient ölü hale getirilmez.
            {
                //Yatan hasta taburcu edilmeden morg işlemi tamamlanamaz
                if (Episode.PatientStatus==PatientStatusEnum.Inpatient)
                {
                    throw new TTException(SystemMessage.GetMessage(595));
                }
            }
            //Hasta Kabul sebebi Alkol Darp Muayenesi - Tutuklu- Adli Gözetim olan kişiler için Ölüm Tutanağı yazılmadan morg tamamalanamaz.
            //todo bg
            /*
            if (this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.AlcoholStorkeExamination || this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.Arrested || this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.JudicialObservation)
            {
                bool found=false;
                foreach(AutopsyReport autopsyReport in this.Episode.AutopsyReports )
                {
                    if (!autopsyReport.IsCancelled)
                    {
                        found=true;
                        break;
                    }
                }
                if(found==false)
                    throw new TTException(SystemMessage.GetMessage(596));
            }*/
            if(Episode.Paid()==false)
            {
                throw new TTException(SystemMessage.GetMessage(597));
            }
            

#endregion PreTransition_Delivery2Completed
        }

        protected void PostTransition_Delivery2Completed()
        {
            // From State : Delivery   To State : Completed
#region PostTransition_Delivery2Completed
            //Hastanın aliveı false  yapar
            if(StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)//Morg işlemi ölüdoğan bebek için başlatıldı ise patient ölü hale getirilmez.
            {
                Episode.Patient.Alive=false;
                //Episodu Açık Devam Yapar
                Episode.CloseEpisodeToNew();
                Episode.ClosedByMorgue=true;
            }

#endregion PostTransition_Delivery2Completed
        }

        protected void UndoTransition_Delivery2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Delivery   To State : Completed
#region UndoTransition_Delivery2Completed
            
            if(StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)//Morg işlemi ölüdoğan bebek için başlatıldı ise patient ölü hale getirilmez.
            {
                //Episodun durumunu eski stateine çevirir
                if(Episode.CurrentStateDefID != Episode.States.Open)
                    ((ITTObject)Episode).UndoLastTransition();
                Episode.ClosedByMorgue=false;
                // Hastanın Aliveını tekrar true yapar
                Episode.Patient.Alive=true;
            }
            

#endregion UndoTransition_Delivery2Completed
        }

        protected void PostTransition_Delivery2Cancelled()
        {
            // From State : Delivery   To State : Cancelled
#region PostTransition_Delivery2Cancelled
            Cancel();
#endregion PostTransition_Delivery2Cancelled
        }

        protected void UndoTransition_Delivery2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Delivery   To State : Cancelled
#region UndoTransition_Delivery2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Delivery2Cancelled
        }

        protected void PostTransition_OutMorgueDelivery2Cancelled()
        {
            // From State : OutMorgueDelivery   To State : Cancelled
#region PostTransition_OutMorgueDelivery2Cancelled
            
            Cancel();

#endregion PostTransition_OutMorgueDelivery2Cancelled
        }

        protected void UndoTransition_OutMorgueDelivery2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OutMorgueDelivery   To State : Cancelled
#region UndoTransition_OutMorgueDelivery2Cancelled
            
            NoBackStateBack();

#endregion UndoTransition_OutMorgueDelivery2Cancelled
        }

        protected void PreTransition_OutMorgueDelivery2Completed()
        {
            // From State : OutMorgueDelivery   To State : Completed
#region PreTransition_OutMorgueDelivery2Completed
            
            
            
            if(StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)//Morg işlemi ölüdoğan bebek için başlatıldı ise patient ölü hale getirilmez.
            {
                //Yatan hasta taburcu edilmeden morg işlemi tamamlanamaz
                if (Episode.PatientStatus==PatientStatusEnum.Inpatient)
                {
                    throw new TTException(SystemMessage.GetMessage(595));
                }
            }
            //Hasta Kabul sebebi Alkol Darp Muayenesi - Tutuklu- Adli Gözetim olan kişiler için Ölüm Tutanağı yazılmadan morg tamamalanamaz.
            //todo bg
            /*
            if (this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.AlcoholStorkeExamination || this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.Arrested || this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.JudicialObservation)
            {
                bool found=false;
                foreach(AutopsyReport autopsyReport in this.Episode.AutopsyReports )
                {
                    if (!autopsyReport.IsCancelled)
                    {
                        found=true;
                        break;
                    }
                }
                if(found==false)
                    throw new TTException(SystemMessage.GetMessage(596));
            }*/
            if(Episode.Paid()==false)
            {
                throw new TTException(SystemMessage.GetMessage(597));
            }

#endregion PreTransition_OutMorgueDelivery2Completed
        }

        protected void PostTransition_OutMorgueDelivery2Completed()
        {
            // From State : OutMorgueDelivery   To State : Completed
#region PostTransition_OutMorgueDelivery2Completed
            
            //Hastanın aliveı false  yapar
            if(StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)//Morg işlemi ölüdoğan bebek için başlatıldı ise patient ölü hale getirilmez.
            {
                Episode.Patient.Alive=false;
                //Episodu Açık Devam Yapar
                Episode.CloseEpisodeToNew();
                Episode.ClosedByMorgue=true;
            }
            

#endregion PostTransition_OutMorgueDelivery2Completed
        }

        protected void UndoTransition_OutMorgueDelivery2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OutMorgueDelivery   To State : Completed
#region UndoTransition_OutMorgueDelivery2Completed
            
            if(StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)//Morg işlemi ölüdoğan bebek için başlatıldı ise patient ölü hale getirilmez.
            {
                //Episodun durumunu eski stateine çevirir
                if(Episode.CurrentStateDefID != Episode.States.Open)
                    ((ITTObject)Episode).UndoLastTransition();
                Episode.ClosedByMorgue=false;
                // Hastanın Aliveını tekrar true yapar
                Episode.Patient.Alive=true;
            }

#endregion UndoTransition_OutMorgueDelivery2Completed
        }

        protected void PostTransition_DoctorControl2Cancelled()
        {
            // From State : DoctorControl   To State : Cancelled
#region PostTransition_DoctorControl2Cancelled
            Cancel();
#endregion PostTransition_DoctorControl2Cancelled
        }

        protected void UndoTransition_DoctorControl2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : DoctorControl   To State : Cancelled
#region UndoTransition_DoctorControl2Cancelled
            NoBackStateBack();
#endregion UndoTransition_DoctorControl2Cancelled
        }

        protected void PostTransition_InRequest2Cancelled()
        {
            // From State : InRequest   To State : Cancelled
#region PostTransition_InRequest2Cancelled
            
            
            Cancel();
            

#endregion PostTransition_InRequest2Cancelled
        }

        protected void UndoTransition_InRequest2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : InRequest   To State : Cancelled
#region UndoTransition_InRequest2Cancelled
            NoBackStateBack();
#endregion UndoTransition_InRequest2Cancelled
        }

        protected void PostTransition_InRequest2RequestAcception()
        {
            // From State : InRequest   To State : RequestAcception
#region PostTransition_InRequest2RequestAcception
            IsOutRequest = false;
            if(StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)
            {
                CloseAllOtherEpisodes();
                bool closeEpisode = true;
                foreach (InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication in Episode.InPatientTreatmentClinicApplications)
                {
                    foreach(NursingApplication nursingApplication in inPatientTreatmentClinicApplication.NursingApplications)
                    {
                        if(nursingApplication.CurrentStateDefID == NursingApplication.States.Application || nursingApplication.CurrentStateDefID == NursingApplication.States.PreDischarged)
                        {
                            closeEpisode = false;
                            break;
                        }
                    }
                    if(!closeEpisode)
                        break;
                }
                
                if(closeEpisode)
                {
                    Episode.CloseEpisodeToNew();
                    Episode.ClosedByMorgue=true;
                }
            }
#endregion PostTransition_InRequest2RequestAcception
        }

        protected void UndoTransition_InRequest2RequestAcception(TTObjectStateTransitionDef transitionDef)
        {
            // From State : InRequest   To State : RequestAcception
#region UndoTransition_InRequest2RequestAcception
            if(StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)
            {
                UndoClosedEpisodes();
            }
#endregion UndoTransition_InRequest2RequestAcception
        }

        protected void PostTransition_OutRequest2Cancelled()
        {
            // From State : OutRequest   To State : Cancelled
#region PostTransition_OutRequest2Cancelled
            
            Cancel();

#endregion PostTransition_OutRequest2Cancelled
        }

        protected void UndoTransition_OutRequest2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OutRequest   To State : Cancelled
#region UndoTransition_OutRequest2Cancelled
            
            NoBackStateBack();

#endregion UndoTransition_OutRequest2Cancelled
        }

        protected void PostTransition_OutRequest2OutRequestAcception()
        {
            // From State : OutRequest   To State : OutRequestAcception
#region PostTransition_OutRequest2OutRequestAcception
            
            IsOutRequest = true;
            CloseAllOtherEpisodes();

#endregion PostTransition_OutRequest2OutRequestAcception
        }

        protected void UndoTransition_OutRequest2OutRequestAcception(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OutRequest   To State : OutRequestAcception
#region UndoTransition_OutRequest2OutRequestAcception
            
            UndoClosedEpisodes();

#endregion UndoTransition_OutRequest2OutRequestAcception
        }

        protected void PostTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
#region PostTransition_Approval2Cancelled
            Cancel();
#endregion PostTransition_Approval2Cancelled
        }

        protected void UndoTransition_Approval2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Approval   To State : Cancelled
#region UndoTransition_Approval2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Approval2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
#region UndoTransition_Completed2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Completed2Cancelled
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
#region PostTransition_RequestAcception2Cancelled
            Cancel();
#endregion PostTransition_RequestAcception2Cancelled
        }

        protected void UndoTransition_RequestAcception2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Cancelled
#region UndoTransition_RequestAcception2Cancelled
            NoBackStateBack();
#endregion UndoTransition_RequestAcception2Cancelled
        }

        protected void PostTransition_OutRequestAcception2Cancelled()
        {
            // From State : OutRequestAcception   To State : Cancelled
#region PostTransition_OutRequestAcception2Cancelled
            Cancel();
#endregion PostTransition_OutRequestAcception2Cancelled
        }

        protected void UndoTransition_OutRequestAcception2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OutRequestAcception   To State : Cancelled
#region UndoTransition_OutRequestAcception2Cancelled
            NoBackStateBack();
#endregion UndoTransition_OutRequestAcception2Cancelled
        }

        protected void PostTransition_MorgueProcedure2Cancelled()
        {
            // From State : MorgueProcedure   To State : Cancelled
#region PostTransition_MorgueProcedure2Cancelled
            Cancel();
#endregion PostTransition_MorgueProcedure2Cancelled
        }

        protected void UndoTransition_MorgueProcedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : MorgueProcedure   To State : Cancelled
#region UndoTransition_MorgueProcedure2Cancelled
            NoBackStateBack();
#endregion UndoTransition_MorgueProcedure2Cancelled
        }

        protected void PostTransition_MorgueProcedure2Approval()
        {
            // From State : MorgueProcedure   To State : Approval
#region PostTransition_MorgueProcedure2Approval
            
            if(IsOutRequest.Value)
            {
                if(OutDeathOrderNo.Value==null)
                    OutDeathOrderNo.GetNextValue(Common.RecTime().Date.Year);
            }
            else
            {
                if(DeathOrderNo.Value==null)
                    DeathOrderNo.GetNextValue(Common.RecTime().Date.Year);
            }
           EmptyCupboard();
#endregion PostTransition_MorgueProcedure2Approval
        }

#region Methods
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList= base.OldActionPropertyList();
            if(propertyList==null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            
            //-------------------------------------
            
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M19126", "Morg Dolap No"), Common.ReturnObjectAsString(MorgueCupboardNo)));
            if(DeliveredBy != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25356", "Cenazeyi Teslim Eden"), Common.ReturnObjectAsString(DeliveredBy.Name)));
            // propertyList.Add(new OldActionPropertyObject("Cenazeyi Teslim Alan",Common.ReturnObjectAsString(DeathBodyAdmittedTo)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25702", "Geliş Tarihi"),Common.ReturnObjectAsString(Episode.OpeningDate)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M18969", "Mezarlığa Gidiş Tarihi"),Common.ReturnObjectAsString(DateOfSentToGrave)));
            if(DiedClinic != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject("Vefat Ettiği Kilinik",Common.ReturnObjectAsString(DiedClinic.Name)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject("Mezarlık Ada Parsel No",Common.ReturnObjectAsString(GraveyardPlotNo)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25433", "Dış İstek/Ölümü Tespit Eden Doktor"),Common.ReturnObjectAsString(ExternalDoctorFixed)));
            if(DoctorFixed != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M19954", "Ölümü Tespit Eden Doktor"),Common.ReturnObjectAsString(DoctorFixed.Name)));
            if(SenderDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M19138", "Morga Gönderen Doktor"),Common.ReturnObjectAsString(SenderDoctor.Name)));
            if(Nurse != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25917", "Hemşire"),Common.ReturnObjectAsString(Nurse.Name)));
            //            propertyList.Add(new OldActionPropertyObject("Ölüm Tarihi/Saati",Common.ReturnObjectAsString(DateTimeOfDeath)));
            //            if(MernisDeathReasons != null)
            //                propertyList.Add(new OldActionPropertyObject("Mernis Ölüm Sebebi",Common.ReturnObjectAsString(MernisDeathReasons.ReasonName)));
            //propertyList.Add(new OldActionPropertyObject("Ölüm Yeri",Common.ReturnObjectAsString(DeathPlace)));
            //            propertyList.Add(new OldActionPropertyObject("Rapor",Common.ReturnObjectAsString(Report)));
            //---------------------------------------
            return propertyList;
            
        }
        
       
        
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.Morgue;
            }
        }
        /// <summary>
        /// Vakada Onay(Approval) yada Tamam(OkWithApproval/OkWithoutApproval) stateinde MTS yoksa morg işleminin başlatılmasına izin verilmez.
        /// Ayaktan hasta için kabul sebebi Acil ya da Ölü Duhul değilse, morg işlemi başlatılamaz.
        /// </summary>
        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
            try
            {
                //TODO ASLI
                //if(subEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.OluKabul)
                //{
                //    this.CurrentStateDefID = Morgue.States.OutRequest;
                //}
                
                //// Ayaktan hasta için kabul sebebi Acil ya da Ölü Duhul değilse, morg işlemi başlatılamaz.NOT(Yeni doğan ve Ölüm şüphesi için başlatılabilir)
                //if(this.StatisticalDeathReason!=TTObjectClasses.StatisticalDeathReason.DeadBirth)
                //{
                //    //todo bg
                //    //              if(subEpisode.Episode.PatientStatus != PatientStatusEnum.Inpatient && (subEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.OluKabul && subEpisode.PatientAdmission.AdmissionType.Value != AdmissionTypeEnum.NewBorn))
                //    if (subEpisode.Episode.PatientStatus != PatientStatusEnum.Inpatient && (subEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.OluKabul))
                //    {
                //        if(subEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.OluKabul && subEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.Acil)
                //            throw new TTException(SystemMessage.GetMessage(598));
                //    }
                //}
                
            }
            catch(Exception ex)
            {//InnerException ile handle etmek için exception catch edilip yeniden ex parametresi ile throw edilmeli
                if (ex is TTException)
                    throw ex;
                throw new TTException(ex.Message,ex);
            }
        }
        
        public void CloseAllOtherEpisodes()
        {
            foreach (Episode episode in Episode.Patient.Episodes)
            {
                if(episode.ObjectID!=Episode.ObjectID && episode.CurrentStateDefID!=Episode.States.Closed)
                {
                    episode.CloseEpisode();
                    episode.ClosedByMorgue=true;
                    
                }
            }
        }
        
        public void UndoClosedEpisodes()
        {
            foreach (Episode episode in Episode.Patient.Episodes)
            {
                if(episode.CurrentStateDefID==Episode.States.Closed && episode.ClosedByMorgue==true)
                {
                    ((ITTObject)episode).UndoLastTransition();
                    episode.ClosedByMorgue=false;
                    
                }
            }
        }
        
        public string FullPatientName
        {
            get{return Episode.Patient.Name + " " + Episode.Patient.Surname;}
        }
        
        public void EmptyCupboard()
        {
            if(Cupboard!=null)
            {
                Cupboard.UsedByAction=null;
            }
        }
        public override void Cancel()
        {
            bool cancel=false;
            if(MasterAction==null)
            {
                cancel=true;
            }
            else if (CancelledByMasterAction==true)//Tedavi Kararından iptal edilirken bu değer true olur
            {
                cancel=true;
            }
            else
            {
                if(MasterAction is TreatmentDischarge)
                {
                    throw new Exception(SystemMessage.GetMessage(612));
                }
                else if(MasterAction is BirthReport)
                {
                    if(((BirthReport)MasterAction).BabyStatus.Value == BirthReportBabyStatus.Dead)
                    {
                        throw new Exception(SystemMessage.GetMessage(599));
                    }
                    else
                    {
                        cancel=true;
                    }

                }
                else
                {
                    cancel=true;
                }
            }
            if(PatientAdmission!=null)
            {
                if (SubEpisode.PatientAdmission.PAStatus != PAStatusEnum.Sirada && SubEpisode.PatientAdmission.PAStatus != PAStatusEnum.IptalEdildi 
                    && SubEpisode.PatientAdmission.PAStatus != PAStatusEnum.KabulSilindi && SubEpisode.PatientAdmission.PAStatus != PAStatusEnum.MuayeneyeGelmedi)
                {
                    if (SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.OluKabul)
                    {
                        throw new Exception(SystemMessage.GetMessage(600));
                    }
                    else
                    {
                        cancel = true;
                    }
                }
            }
            
            EmptyCupboard();
            if(cancel)
            {
                UndoClosedEpisodes();
                Episode.Patient.Alive = true;
                Episode.Patient.Death = false;
                Episode.Patient.DeathReportNo = null;
                Episode.Patient.ExDate = null;
                if(Episode.ClosedByMorgue == true)
                {
                    //Episodun durumunu eski stateine çevirir
                    if(Episode.CurrentStateDefID != Episode.States.Open)
                        ((ITTObject)Episode).UndoLastTransition();
                    Episode.ClosedByMorgue=false;
                }
                base.Cancel();
            }
            
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Morgue).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

           
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Morgue).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == States.Request && toState == States.MorgueProcedure)
            //    PostTransition_Delivery2Completed();
            //else if (fromState == States.Delivery && toState == States.Cancelled)
            //    PostTransition_Delivery2Cancelled();
            //else if (fromState == States.OutMorgueDelivery && toState == States.Cancelled)
            //    PostTransition_OutMorgueDelivery2Cancelled();
            //else if (fromState == States.OutMorgueDelivery && toState == States.Completed)
            //    PostTransition_OutMorgueDelivery2Completed();
            //else if (fromState == States.DoctorControl && toState == States.Cancelled)
            //    PostTransition_DoctorControl2Cancelled();
            if (fromState == Morgue.States.Request && toState == Morgue.States.Cancelled)
                PostTransition_InRequest2Cancelled();
            //else if (fromState == States.InRequest && toState == States.RequestAcception)
            //    PostTransition_InRequest2RequestAcception();
            else if (fromState == Morgue.States.OutRequest && toState == Morgue.States.Cancelled)
            PostTransition_OutRequest2Cancelled();
            //else if (fromState == States.OutRequest && toState == States.OutRequestAcception)
            //    PostTransition_OutRequest2OutRequestAcception();
            //else if (fromState == States.Approval && toState == States.Cancelled)
            //    PostTransition_Approval2Cancelled();
            //else if (fromState == States.Completed && toState == States.Cancelled)
            //    PostTransition_Completed2Cancelled();
            //else if (fromState == States.RequestAcception && toState == States.Cancelled)
            //    PostTransition_RequestAcception2Cancelled();
            //else if (fromState == States.OutRequestAcception && toState == States.Cancelled)
            //    PostTransition_OutRequestAcception2Cancelled();
            else if (fromState == Morgue.States.MorgueProcedure && toState == Morgue.States.Cancelled)
                PostTransition_MorgueProcedure2Cancelled();
            //else if (fromState == States.MorgueProcedure && toState == States.Approval)
            //    PostTransition_MorgueProcedure2Approval();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Morgue).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == States.Delivery && toState == States.Completed)
            //    UndoTransition_Delivery2Completed(transDef);
            //else if (fromState == States.Delivery && toState == States.Cancelled)
            //    UndoTransition_Delivery2Cancelled(transDef);
            //else if (fromState == States.OutMorgueDelivery && toState == States.Cancelled)
            //    UndoTransition_OutMorgueDelivery2Cancelled(transDef);
            //else if (fromState == States.OutMorgueDelivery && toState == States.Completed)
            //    UndoTransition_OutMorgueDelivery2Completed(transDef);
            //else if (fromState == States.DoctorControl && toState == States.Cancelled)
            //    UndoTransition_DoctorControl2Cancelled(transDef);
            //else if (fromState == States.InRequest && toState == States.Cancelled)
            //    UndoTransition_InRequest2Cancelled(transDef);
            //else if (fromState == States.InRequest && toState == States.RequestAcception)
            //    UndoTransition_InRequest2RequestAcception(transDef);
            //else if (fromState == States.OutRequest && toState == States.Cancelled)
            //    UndoTransition_OutRequest2Cancelled(transDef);
            //else if (fromState == States.OutRequest && toState == States.OutRequestAcception)
            //    UndoTransition_OutRequest2OutRequestAcception(transDef);
            //else if (fromState == States.Approval && toState == States.Cancelled)
            //    UndoTransition_Approval2Cancelled(transDef);
            //else if (fromState == States.Completed && toState == States.Cancelled)
            //    UndoTransition_Completed2Cancelled(transDef);
            //else if (fromState == States.RequestAcception && toState == States.Cancelled)
            //    UndoTransition_RequestAcception2Cancelled(transDef);
            //else if (fromState == States.OutRequestAcception && toState == States.Cancelled)
            //    UndoTransition_OutRequestAcception2Cancelled(transDef);
            //else if (fromState == States.MorgueProcedure && toState == States.Cancelled)
            //    UndoTransition_MorgueProcedure2Cancelled(transDef);
        }

    }
}