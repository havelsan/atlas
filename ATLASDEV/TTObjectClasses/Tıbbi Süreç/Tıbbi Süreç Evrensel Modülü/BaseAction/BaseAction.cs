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
    /// Program üzerinde orak özelikler taşıyan işlemlerin ana Nesnesi
    /// </summary>
    public partial class BaseAction : TTObject, IGeneralWorkList, ISetWorkListDate
    {
        public partial class GetAppointmentActions_Class : TTReportNqlObject
        {
        }
        public TTSequence GetID()
        {
            return ID;
        }
        /// <summary>
        /// Sunucu Tarihi
        /// </summary>
        public DateTime? ServerTime
        {
            get
            {
                try
                {
#region ServerTime_GetScript                    
                    return TTObjectDefManager.ServerTime;
#endregion ServerTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ServerTime") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            OlapLastUpdate = DateTime.Now;
        //this.OlapDate = DateTime.Now;
#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            OlapLastUpdate = DateTime.Now;
#endregion PreUpdate
        }

#region Methods
        public string TempProvisionNo = string.Empty; //Meduladan takip alındıktan sonra XXXXXX patlarsa uyumsuzluk için flag MC
        public virtual bool NotSetWorklist
        {
            get
            {
                return false;
            }

            set
            {
            }
        }

        //IAllocateSpeciality ve ISetWorkListDate için kullanılacak
        public SubActionProcedure MySubActionProcedure
        {
            get
            {
                return null;
            }

            set
            {
            }
        }

        //ISetWorkListDate için kullanılacak
        public BaseAction MyAction
        {
            get
            {
                return (BaseAction)this;
            }

            set
            {
            }
        }

        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                ID.GetNextValue();
            }
        }

        public void CheckOnlySuperUserAction()
        {
            if (this is IExpirationDateCorrectionAction == false)
            {
                if (TTUser.CurrentUser.Status != UserStatusEnum.SuperUser)
                    throw new Exception(SystemMessage.GetMessageV3(1036, new string[]{ObjectDef.ApplicationName.ToString()}));
            }
        }

        public bool IsAttributeExists(System.Type AttributeType)
        {
            bool found = false;
            foreach (TTObjectDefAttribute attribute in ObjectDef.AllAttributes)
            {
                if (attribute.AttributeDef.CodeName == AttributeType.Name)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        /// <summary>
        ///Yalnız Enterprise daki scriplerden çağırılabilir bir Cancel kodu; (NOT Ç:kullanıcının cancelled edemiyeceği işlemler koddan cancelled edilebiliyorsa kullanılır)
        /// </summary>
        public virtual void CancelByCode()
        {
        }

        /// <summary>
        /// Action Cancel edilmek istendiğinde çalıştırılmalı
        /// </summary>
        public virtual void Cancel()
        {
        }

        /// <summary>
        /// State back virtual metodu
        /// </summary>
        protected virtual void NoBackStateBack()
        {
            throw new Exception(SystemMessage.GetMessage(992));
        }

        /// <summary>
        /// Cancel virtual metodu.
        /// </summary>
        protected virtual void NoCancel()
        {
            throw new TTException(SystemMessage.GetMessage(1037));
        }

        /// <summary>
        /// Bir MasterActiona ba?ly Actionlaryn hepsi tamamalandy ise true döndürür.Biri bile tamamlanmamy? ise false döndürür.
        /// </summary>
        /// <returns></returns>
        public bool HasUnCompletedLinkedAction()
        {
            bool found = false;
            foreach (BaseAction action in LinkedActions)
            {
                if (action.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        /// <summary>
        /// Bir MasterActiona ba?ly Actionlardan tamamlanmayanları döndürür.
        /// </summary>
        /// <returns></returns>
         
        /// <summary>
        /// Aynı masteractiona sahip olduğu actionların hepsi tamamlandı ise  false biri bile tamamalanmadı ise true döndürür.MasterActionı yoksa da false döndürür
        /// </summary>
        /// <returns></returns>
        protected bool HasUnCompletedSiblingAction()
        {
            if (MasterAction == null)
            {
                return false;
            }
            else
            {
                foreach (BaseAction action in MasterAction.LinkedActions)
                {
                    if (action != (BaseAction)this && action.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public virtual bool SendToENabiz()
        {
            if (IsOldAction == true)
                return false;
            return true;
        }

        public virtual BindingList<Appointment> GetMyNewAppointments()
        {
            return (BindingList<Appointment>)Appointment.GetByActionAndState(ObjectContext, ObjectID.ToString(), Convert.ToString(Appointment.States.New));
        }

        public static BindingList<Appointment> GetMyNewAppointments(BaseAction baseAction)
        {
            return (BindingList<Appointment>)Appointment.GetByActionAndState(baseAction.ObjectContext, baseAction.ObjectID.ToString(), Convert.ToString(Appointment.States.New));
        }

        public virtual BindingList<Appointment> MyCompletedAppointments
        {
            get
            {
                return (BindingList<Appointment>)Appointment.GetByActionAndState(ObjectContext, ObjectID.ToString(), Convert.ToString(Appointment.States.Completed));
            }
        }

        public virtual BindingList<Appointment> MyCancelledAppointments
        {
            get
            {
                return (BindingList<Appointment>)Appointment.GetByActionAndState(ObjectContext, ObjectID.ToString(), Convert.ToString(Appointment.States.Cancelled));
            }
        }

        public virtual BindingList<Appointment> MyNotApprovedAppointments
        {
            get
            {
                return (BindingList<Appointment>)Appointment.GetByActionAndState(ObjectContext, ObjectID.ToString(), Convert.ToString(Appointment.States.NotApproved));
            }
        }

        public virtual void CancelMyUnCompletedAppoinments()
        {
            foreach (Appointment app in GetMyNewAppointments())
            {
                app.CurrentStateDefID = Appointment.States.Cancelled;
            }

            foreach (Appointment app in MyNotApprovedAppointments)
            {
                app.CurrentStateDefID = Appointment.States.Cancelled;
            }
        }

        public virtual void CompleteMyUnCompletedAppoinments()
        {
            if (TransDef != null)
            {
                foreach (Appointment app in GetMyNewAppointments())
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || (PrevState != null && TransDef.ToStateDefID == PrevState.StateDefID))
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }

                    if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }

                foreach (Appointment app in MyNotApprovedAppointments)
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || (PrevState != null && TransDef.ToStateDefID == PrevState.StateDefID))
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }

                    if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
            }
        }

        public virtual void CompleteMyNewAppoinments()
        {
            if (TransDef != null)
            {
                foreach (Appointment app in GetMyNewAppointments())
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || (PrevState != null && TransDef.ToStateDefID == PrevState.StateDefID))
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }

                    if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
            }
        }

        public virtual void CompleteMyNewAppoinments(TTObjectStateTransitionDef transDef)
        {
            if (transDef != null)
            {
                foreach (Appointment app in GetMyNewAppointments())
                {
                    if (transDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || transDef.ToStateDef.Status == StateStatusEnum.Cancelled || (PrevState != null && transDef.ToStateDefID == PrevState.StateDefID))
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }

                    if (transDef.ToStateDef.Status == StateStatusEnum.Uncompleted || transDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
            }
        }

        public virtual void ChangeMyNewAppoinmentsToNotApporived()
        {
            if (TransDef != null)
            {
                foreach (Appointment app in GetMyNewAppointments())
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || (PrevState != null && TransDef.ToStateDefID == PrevState.StateDefID))
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }

                    if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.NotApproved;
                    }
                }
            }
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Radyoloji_Test_Randevu, TTRoleNames.Radyoloji_Test_R)]
        public static string GetFullAppointmentDescription(BaseAction baseAction)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Appointment app in baseAction.GetMyNewAppointments())
            {
                builder.Append("Açıklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append(TTUtils.CultureService.GetText("M27267", "Zaman  : Saatsiz Randevu \r\n"));
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name.ToString() + " : " + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description.ToString() + " : " + app.Resource.Name + "\r\n");
                }

                builder.Append(app.ObjectDef.Description + " : " + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append("Durum  : " + app.CurrentStateDef.ToString() + "\r\n");
                TimeSpan dtDiff = app.AppDate.Value.Subtract(Common.RecTime().Date);
                if (dtDiff.TotalDays > -1) // Randevu aynı günde yada ilerdeyse
                {
                    if (dtDiff.TotalDays == 0) //aynı gündeyse
                    {
                        dtDiff = app.StartTime.Value.TimeOfDay.Subtract(Common.RecTime().TimeOfDay);
                        if (dtDiff.TotalMinutes > -1) // aynı günde ilerde ise
                        {
                            if (dtDiff.TotalMinutes < 60)
                                builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalMinutes) + " dakika sonra.\r\n");
                            else
                                builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalHours) + " saat sonra.\r\n");
                        }
                        else
                        {
                            //double nDuration = app.EndTime.Value.Subtract(app.StartTime.Value).TotalHours;
                            //if(nDuration < Math.Abs(dtDiff.TotalHours))
                            if (app.EndTime.Value.TimeOfDay.Subtract(Common.RecTime().TimeOfDay).TotalMinutes > 0)
                                builder.Append(TTUtils.CultureService.GetText("M27271", "Zamanlama : süresi geçiyor\r\n"));
                            else
                                builder.Append(TTUtils.CultureService.GetText("M27272", "Zamanlama : süresi geçmiş\r\n"));
                        }
                    }
                    else
                        builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalDays) + " gün sonra.\r\n");
                }
                else
                {
                    builder.Append(TTUtils.CultureService.GetText("M27272", "Zamanlama : süresi geçmiş\r\n"));
                }

                builder.Append(TTUtils.CultureService.GetText("M26764", "Referans No :")+ (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())));
                builder.Append("\r\n");
                builder.Append("\r\n");
            }

            return builder.ToString();
        }

        public static string GetFullCompletedAppointmentDescription(BaseAction baseAction)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Appointment app in baseAction.MyCompletedAppointments)
            {
                builder.Append("Açıklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append(TTUtils.CultureService.GetText("M27267", "Zaman  : Saatsiz Randevu \r\n"));
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name + " :" + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description + " :" + app.Resource.Name + "\r\n");
                }

                builder.Append(app.ObjectDef.Description + " :" + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append(TTUtils.CultureService.GetText("M25550", "Durum  :")+ app.CurrentStateDef.ToString() + "\r\n");
                builder.Append(TTUtils.CultureService.GetText("M26764", "Referans No :")+ (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())));
                builder.Append("\r\n");
                builder.Append("\r\n");
            }

            foreach (Appointment app in baseAction.MyCancelledAppointments)
            {
                builder.Append("Açıklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append(TTUtils.CultureService.GetText("M27267", "Zaman  : Saatsiz Randevu \r\n"));
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name + " :" + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description + " :" + app.Resource.Name + "\r\n");
                }

                builder.Append(app.ObjectDef.Description + " :" + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append(TTUtils.CultureService.GetText("M25550", "Durum  :")+ app.CurrentStateDef.ToString() + "\r\n");
                builder.Append(TTUtils.CultureService.GetText("M26764", "Referans No :")+ (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())) + "\r\n");
                builder.Append(TTUtils.CultureService.GetText("M26089", "İptal Sebebi :")+ baseAction.ReasonOfCancel);
                builder.Append("\r\n");
                builder.Append("\r\n");
            }

            return builder.ToString();
        }

        protected static void ClearAppointmentCarrierDynamicFields(List<AppointmentCarrier> appointmentCarrierList)
        {
            foreach (AppointmentCarrier appointmentCarrier in appointmentCarrierList)
            {
                appointmentCarrier.AppointmentCount = 1;
                appointmentCarrier.AppointmentDuration = 15;
                appointmentCarrier.AppointmentType = null;
                appointmentCarrier.MasterResourceFilter = "";
            }
        }

        #region ISetWorkListDate Members
        public bool? GetIsOldAction()
        {
            return IsOldAction;
        }

        public void SetIsOldAction(bool? value)
        {
            IsOldAction = value;
        }

        public AppointmentWithoutResource.ChildAppointmentWithoutResourceCollection GetAppointmentWithoutResources()
        {
            return AppointmentWithoutResources;
        }

        public DateTime? GetWorkListDate()
        {
            return WorkListDate;
        }

        public void SetWorkListDate(DateTime? value)
        {
            WorkListDate = value;
        }

        public bool GetNotSetWorklist()
        {
            return NotSetWorklist;
        }

        public void SetNotSetWorklist(bool value)
        {
            NotSetWorklist = value;
        }

        public Guid? GetCurrentStateDefID()
        {
            return CurrentStateDefID;
        }

        public void SetCurrentStateDefID(Guid? value)
        {
            CurrentStateDefID = value;
        }
        #endregion
        #endregion Methods
    }
}