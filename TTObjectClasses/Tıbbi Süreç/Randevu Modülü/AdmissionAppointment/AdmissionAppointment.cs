
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
    /// Kafa Randevusu
    /// </summary>
    public partial class AdmissionAppointment : BaseAction, IAdmissionAppointmentDef, IWorkListAppointment
    {
        public partial class GetByPatientAndDate_Class : TTReportNqlObject
        {
        }

        public partial class GetAdmissionAppointmentNQL_Class : TTReportNqlObject
        {
        }

        #region IAdmissionAppointmentDef Members
        public String GetPatientName()
        {
            return PatientName;
        }

        public void SetPatientName(String value)
        {
            PatientName = value;
        }

        public String GetPatientSurname()
        {
            return PatientSurname;
        }

        public void SetPatientSurname(String value)
        {
            PatientSurname = value;
        }

        public Patient GetSelectedPatient()
        {
            return SelectedPatient;
        }

        public void SetSelectedPatient(Patient value)
        {
            SelectedPatient = value;
        }
        #endregion

        public string PatientNameSurname
        {
            get
            {
                try
                {
#region PatientNameSurname_GetScript                    
                    return (SelectedPatient == null ? (PatientName + " " + PatientSurname) : SelectedPatient.FullName);
#endregion PatientNameSurname_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "PatientNameSurname") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Randevu verilen kaynağın ismini getirir.
    /// </summary>
        public string ResourceName
        {
            get
            {
                try
                {
#region ResourceName_GetScript                    
                    string resName = String.Empty;
                if (CurrentStateDefID == AdmissionAppointment.States.Appointment)
                {
                    if(GetMyNewAppointments().Count > 0)
                        resName = (GetMyNewAppointments()[0].Resource != null ? GetMyNewAppointments()[0].Resource.Name : String.Empty);
                }
                else
                {
                    if(MyCompletedAppointments.Count > 0)
                        resName = (MyCompletedAppointments[0].Resource != null ? MyCompletedAppointments[0].Resource.Name : String.Empty);
                }
                return resName;
#endregion ResourceName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ResourceName") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();

#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();

#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            if (OriginalStateDef.StateDefID == AdmissionAppointment.States.New)
            {
                foreach(Appointment app in GetMyNewAppointments())
                {
                    MasterResource = app.MasterResource;
                    WorkListDate = Convert.ToDateTime(app.StartTime);
                    break;
                }
            }
#endregion PostUpdate
        }

        protected void PostTransition_New2Appointment()
        {
            // From State : New   To State : Appointment
#region PostTransition_New2Appointment
            
            //Sivil hasta kontenjanı PPP lerde olmayacağı için kapatıldı BB
            //foreach(Appointment app in this.MyNewAppointments)
            //{
            //    if(app.MasterResource is ResSection)
            //    {
            //        ((ResSection)app.MasterResource).DecreaseRemainingDailyQuota(this);
            //    }
            //}
#endregion PostTransition_New2Appointment
        }

        protected void UndoTransition_New2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Appointment
#region UndoTransition_New2Appointment
            
            NoBackStateBack();
            //this.CompleteMyNewAppoinments();
#endregion UndoTransition_New2Appointment
        }

        protected void PostTransition_Appointment2Cancelled()
        {
            // From State : Appointment   To State : Cancelled
#region PostTransition_Appointment2Cancelled
            
            Cancel();
#endregion PostTransition_Appointment2Cancelled
        }

        protected void PostTransition_Appointment2Completed()
        {
            // From State : Appointment   To State : Completed
#region PostTransition_Appointment2Completed
            
            CompleteMyUnCompletedAppoinments(); // Muayene Kabulu yapıldığında CompleteMyNewAppointments çağrılacak.
#endregion PostTransition_Appointment2Completed
        }

#region Methods
        private List<AppointmentCarrier> _appointmentCarrierList = new List<AppointmentCarrier>();
        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get{return _appointmentCarrierList;}
            set{_appointmentCarrierList=value;}
        }

        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }

        public override void Cancel()
        {
            base.Cancel();
            CompleteMyNewAppoinments();
        }
        
        public static Episode CheckHasSameSpecialityAdmissionInTenDays(AdmissionAppointment admissionAppointment)
        {
            Resource appMasterResource = null;
            bool checkOldEpisodesToday = true;
            SpecialityDefinition examinationSpeciality = null;          
            PoliclinicTypeEnum policlinicType = PoliclinicTypeEnum.DentalPoliclinic;
            bool checkPoliclinicType = false;
            bool hasSameSpeciality = false;
            if(admissionAppointment.SelectedPatient != null)
            {
                if(admissionAppointment.AppointmentDefinition != null)
                {
                    //if(this.AppointmentDefinition.ReasonForAdmission != null && this.AppointmentDefinition.AppointmentDefinitionName == AppointmentDefinitionEnum.PatientExamination && this.AppointmentDefinition.ReasonForAdmission.Type == AdmissionTypeEnum.Examination)
                    //{
                        foreach(Appointment app in admissionAppointment.GetMyNewAppointments())
                        {
                            appMasterResource = null;
                            if(app.InitialObjectID == null)
                            {
                                if(hasSameSpeciality == true)
                                    break;
                                if(app.MasterResource != null)
                                    appMasterResource = app.MasterResource;
                                else if(app.Resource != null)
                                    appMasterResource = app.Resource;
                            }
                        if (appMasterResource != null)
                        {
                            foreach (ResourceSpecialityGrid sp in appMasterResource.ResourceSpecialities)
                            {
                                examinationSpeciality = sp.Speciality;
                                break;
                            }
                            if (appMasterResource is ResPoliclinic)
                            {
                                if (((ResPoliclinic)appMasterResource).PoliclinicType != null)
                                {
                                    checkPoliclinicType = true;
                                    policlinicType = (PoliclinicTypeEnum)((ResPoliclinic)appMasterResource).PoliclinicType;
                                }
                            }

                            if (examinationSpeciality != null || checkPoliclinicType) // 10 gün yada Aynı gün kontrolünü yap
                            {
                                // MT 04.10.2013 10 gün kuralı kapatıldı.                                       
                                //int limit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("SGKSPECIALITYCONTROLDAYLIMIT","10"));
                                // MT 01.10.2013 Hasta kabulün kabül edildiği günden itibaren sayılması için limit 9 güne ayarlandı.                                       
                                // DateTime dateLimit = Convert.ToDateTime(Common.RecTime()).AddDays(-1 * (limit-1)).Date;

                                foreach (Episode episode in admissionAppointment.SelectedPatient.Episodes)// zaten contexte Episodelar dolduruluyordu o yüzden tekrar NQL çelmedi
                                {
                                    // MT 01.10.2013 Hasta muayenesinde 10 gün kuralı kaldırıldı.
                                    // NE 08.03.2016 10 gün içinde aynı branştan kabulü varsa kontrol muayenesi açılmak için açıldı
                                    if (episode.OpeningDate > TTObjectDefManager.ServerTime.AddDays(-10))// NQL yerine Vakaları tek tek  dolaşacağı için eklendi
                                    {
                                        if (episode.PatientStatus != null && (int)episode.PatientStatus == PatientStatusEnum.Outpatient.GetHashCode())
                                        {
                                            if (examinationSpeciality != null) // 10 Gün Kontrolü (Uzmanlık Dalına göre)
                                            {
                                                if (episode.MainSpeciality != null)
                                                {
                                                    if (examinationSpeciality.ObjectID == episode.MainSpeciality.ObjectID)
                                                    {
                                                        foreach (var subEpisode in episode.SubEpisodes)
                                                        {
                                                            if (subEpisode.PatientAdmission.IsSGKPatientAdmission && subEpisode.PatientAdmission.IsIgnoredTenDaysRule(admissionAppointment.PatientAdmission[0].AdmissionType) == false)
                                                            {

                                                                hasSameSpeciality = true;
                                                                if (subEpisode.PatientAdmission.FiredEpisodeActions.Count > 0)
                                                                {
                                                                    if (subEpisode.PatientAdmission.FiredEpisodeActions[0].NumaratorAppointments.Count > 0)
                                                                        subEpisode.PatientAdmission.FiredEpisodeActions[0].CancelMyUnCompletedAppoinments();
                                                                    app.EpisodeAction = subEpisode.PatientAdmission.FiredEpisodeActions[0];
                                                                }
                                                                return episode;
                                                            }
                                                        }
                                                    }
                                                    /*
                                                    if(checkPoliclinicType) // 10 gün kontrolü (Poliklinik Türüne Göre)
                                                    {
                                                        if(episode.PatientAdmission != null)
                                                        {
                                                            foreach(EpisodeAction ea in episode.PatientAdmission.FiredEpisodeActions)
                                                            {
                                                                if(ea.MasterResource is ResPoliclinic)
                                                                {
                                                                    if(((ResPoliclinic)ea.MasterResource).PoliclinicType != null)
                                                                    {
                                                                        if(policlinicType == (PoliclinicTypeEnum)((ResPoliclinic)ea.MasterResource).PoliclinicType)
                                                                        {
                                                                            hasSameSpeciality = true;
                                                                            if(app.EpisodeAction.NumaratorAppointments.Count>0)
                                                                                app.EpisodeAction.CancelMyUnCompletedAppoinments();
                                                                            app.EpisodeAction = ea;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                     */
                                                }
                                            }  // MT 01.10.2013 Hasta muayenesinde 10 gün kuralı kaldırıldı. // NE 08.03.2016 10 gün içinde aynı branştan kabulü varsa kontrol muayenesi açılmak için açıldı
                                        }
                                    }
                                }
                            }
                        }
                    }                    
                }
            }
            
            //if(hasSameSpeciality == true)
            //    return examinationSpeciality;
            return null;
        }
        
        public bool IsQuotaUsedInTenDays()
        {
            if(SelectedPatient != null)
            {
                foreach(Appointment app in GetMyNewAppointments())
                {
                    int limit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("SGKSPECIALITYCONTROLDAYLIMIT","10"));
                    DateTime startDate = Convert.ToDateTime(app.AppDate).AddDays(-1 * (limit)).Date; //Randevu tarihinden 10 gün öncesi
                    // MT 18.9.2013 10 gün kontrolü hesabında yanlışlık var. Hasta çıkış tarihi - Hasta kabul tarihi = 10 ise kabule izin vermiyor.
                    // Hasta kabul tarihi bir gün önceye alındı.
                    startDate = startDate.AddDays(-1).Date;
                    
                    DateTime endDate = app.AppDate.Value.Date; //Randevu Tarihi
                    Resource appMasterResource = null; //Randevu verilen birim
                    if(app.MasterResource != null)
                        appMasterResource = app.MasterResource;
                    else if(app.Resource != null)
                        appMasterResource = app.Resource;
                    
                    if(appMasterResource != null)
                    {
                        //Hastanın 10 gün içinde randevu verilen birimden kota kullanıp kullanmadığına bakılır. Varsa true döner.
                        BindingList<TTObjectClasses.QuotaHistory> quotaHistoryInTenDaysListByPatient = TTObjectClasses.QuotaHistory.GetByPatientAndRessection(ObjectContext,SelectedPatient.ObjectID,appMasterResource.ObjectID,startDate,endDate);
                        if(quotaHistoryInTenDaysListByPatient.Count > 0)
                            return true;
                        //10 gün içinde randevu verilen birimden kullanılan kotalar alınır.
                        BindingList<TTObjectClasses.QuotaHistory> quotaHistoryInTenDaysList = TTObjectClasses.QuotaHistory.GetByStartEndDate(ObjectContext,startDate,endDate,appMasterResource.ObjectID);
                        //Bu kotaların içinde dönülüp, Kafa Randevusu ile kota kullanıldıysa ve bu Kafa Randevusundan yapılan hasta kabul bu hastaya aitse true döner.
                        foreach(TTObjectClasses.QuotaHistory quotaHistory in quotaHistoryInTenDaysList)
                        {
                            if(quotaHistory.AdmissionAppointment != null)
                            {
                                foreach (Episode episode in SelectedPatient.Episodes)
                                {
                                    foreach (SubEpisode subEpisode in episode.SubEpisodes)
                                    {
                                        if (subEpisode.PatientAdmission != null && subEpisode.PatientAdmission.AdmissionAppointment != null)
                                        {
                                            if (subEpisode.PatientAdmission.AdmissionAppointment.ObjectID == quotaHistory.AdmissionAppointment.ObjectID)
                                                return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            return false;
        }
        
        
        public Episode ReturnEpisodeWithSameSpecialityInTenDays()
        {
            
            return null;
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AdmissionAppointment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AdmissionAppointment.States.New && toState == AdmissionAppointment.States.Appointment)
                PostTransition_New2Appointment();
            else if (fromState == AdmissionAppointment.States.Appointment && toState == AdmissionAppointment.States.Cancelled)
                PostTransition_Appointment2Cancelled();
            else if (fromState == AdmissionAppointment.States.Appointment && toState == AdmissionAppointment.States.Completed)
                PostTransition_Appointment2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AdmissionAppointment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AdmissionAppointment.States.New && toState == AdmissionAppointment.States.Appointment)
                UndoTransition_New2Appointment(transDef);
        }

    }
}