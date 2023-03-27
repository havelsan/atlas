
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
    /// Blok Randevu İşlemleri için Kullanılan Ana  objedir
    /// </summary>
    public  abstract  partial class BaseBlockAppointment : BaseAdmissionAppointment, IStartFromNewActionInPatientFolder, IAppointmentDef
    {
        public string PatientNameSurname
        {
            get
            {
                try
                {
#region PatientNameSurname_GetScript                    
                    return (SelectedPatient == null ? "-": SelectedPatient.FullName);
#endregion PatientNameSurname_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "PatientNameSurname") + " : " + ex.Message, ex);
                }
            }
        }

        public string ResourceName
        {
            get
            {
                try
                {
#region ResourceName_GetScript                    
                    return Resource == null ? "-" : Resource.Name;
#endregion ResourceName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ResourceName") + " : " + ex.Message, ex);
                }
            }
        }

        #region Methods

        #region IStartFromNewActionInPatientFolder Members
        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public MenuDefinition GetMenuDefinition()
        {
            return MenuDefinition;
        }

        public void SetMenuDefinition(MenuDefinition value)
        {
            MenuDefinition = value;
        }

        public ActionTypeEnum GetActionType()
        {
            return ActionType;
        }
        #endregion

        //Yeni süreçten başlarılırken kullanılır
        private MenuDefinition menuDefinition;
        public MenuDefinition MenuDefinition
        {
            get { return menuDefinition; }
            set { menuDefinition = value; }
        }
        
        
        public bool IsEpisodeStatesIgnored()
        {
            if (IsAttributeExists(typeof(IgnoreEpisodeStatesAttribute)) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public virtual ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.UnDefinedAction;
            }
        }
        
        
        public virtual  IList<Episode> LimiteEpisodesOfPatientToStartFromNewActionInPatientFolder( IList<Episode> episodes)
        {
            return episodes;
        }
        
        public virtual void SetPropertiesWhenStartFromNewActionInPatientFolder(Episode episode)
        {
            if (episode != null)
                SelectedPatient = episode.Patient;
            SetFromResource(episode);
            AppointmentDefinition = GetAppointmentDefinition();
        }
        
        /// <summary>
        /// İşlemi İsteyen Birimin Atamasını Yapar
        /// </summary>
        /// <param name="episode"></param>
        public virtual void SetFromResource(Episode episode)
        {

            if (FromResource == null)
            {
                if (episode != null)
                {
                    if (Common.CurrentResource != null)
                    {
                        if (episode.PatientStatus == PatientStatusEnum.Inpatient)
                        {
                            if (Common.CurrentResource.SelectedInPatientResource != null)
                            {
                                FromResource = (ResSection)Common.CurrentResource.SelectedInPatientResource;
                                return;
                            }
                        }
                        else
                        {
                            if (Common.CurrentResource.SelectedOutPatientResource != null)
                            {
                                FromResource = (ResSection)Common.CurrentResource.SelectedOutPatientResource;
                                return;
                            }
                        }
                    }

                }
            }
        }
        
        public void SetProcedureDoctorAsCurrentResource()
        {
            if(CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if(ProcedureDoctor == null && (Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist || Common.CurrentResource.UserType == UserTypeEnum.Dietician || Common.CurrentResource.UserType == UserTypeEnum.InternDoctor || Common.CurrentResource.UserType == UserTypeEnum.Psychologist || Common.CurrentResource.UserType == UserTypeEnum.Physiotherapist))
                {
                    ProcedureDoctor = Common.CurrentResource;
                }
            }
        }
        
        
        protected static List<AppointmentCarrier> _appointmentList=new List<AppointmentCarrier>();
        public virtual List<AppointmentCarrier> AppointmentCarrierList
        {
            
            get{
                
                lock(_appointmentList)
                {
                    ClearAppointmentCarrierDynamicFields(_appointmentList);
                    return _appointmentList;
                }
            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        public virtual AppointmentDefinition GetAppointmentDefinition()
        {
            AppointmentDefinition appDef = null;
            
            foreach (AppointmentCarrier appointmentCarrier in AppointmentCarrierList)
            {
                if(appointmentCarrier.IsDefault == true)
                    return appointmentCarrier.AppointmentDefinition;
                if(appDef == null)
                    appDef = appointmentCarrier.AppointmentDefinition; 
            }
            return appDef;
        }
        
#endregion Methods

    }
}