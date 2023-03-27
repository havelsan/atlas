using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace Core.Models
{
    public class EpisodeActionWorkListFormViewModel
    {
        public string txtPatient
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public Int32 ID
        {
            get;
            set;
        }

        public Int32 WorkListCount
        {
            get;
            set;
        }

        public string StateType
        {
            get;
            set;
        }

        public string PatientStatus
        {
            get;
            set;
        }

        public List<EpisodeActionWorkListItemModel> EpisodeActionList
        {
            get;
            set;
        }

        public List<TTObjectClasses.MenuDefinition> MenuList
        {
            get;
            set;
        }

        public List<EpisodeActionWorkListItem> WorkListItems
        {
            get;
            set;
        }

        public List<EpisodeActionWorkListStateItem> WorkListStateItems
        {
            get;
            set;
        }

        public List<EpisodeActionWorkListItem> SelectedWorkListItems
        {
            get;
            set;
        }

        public List<EpisodeActionWorkListStateItem> SelectedWorkListStateItems
        {
            get;
            set;
        }

        public List<UserResourceItem> UserResourceItems
        {
            get;
            set;
        }

        public List<UserResourceItem> SelectedUserResourceItems
        {
            get;
            set;
        }

        public List<SpecialPanelListItem> SpecialPanelListItems
        {
            get;
            set;
        }

        public SpecialPanelListItem LastSelectedSpecialPanel
        {
            get;
            set;
        }
        public List<string> SelectedStateTypes
        {
            get;
            set;
        }

        public List<string> SelectedStateTypesEM
        {
            get;
            set;
        }
        public int WorkListMaxDayToSearch
        {
            get;
            set;
        }
        public int maxWorklistItemCount
        {
            get;
            set;
        }

        public int timerPeriod
        {
            get
            {
                var tp = TTObjectClasses.SystemParameter.GetParameterValue("EPISODEACTIONWORKLISTTIMERPEROD", "60");
                if (int.TryParse(tp, out int tpInt))
                    return tpInt;
                else
                    return 60;
            }
            set { }
        }

        public bool autoRefreshWorkList
        {
            get
            {
                return TTObjectClasses.SystemParameter.GetParameterValue("EPISODEACTIONWORKLISTAUTOREFRESH", "FALSE") == "TRUE";
            }
        }

        public List<LCDNotificationDefinition> LCDNotificationList { get; set; }
        public string isNewLcd { get; set; }
    }

    public class EpisodeActionWorkListItemModel
    {
        public string ObjectID
        {
            get;
            set;
        }

        public string ObjectDefName
        {
            get;
            set;
        }

        public string ID
        {
            get;
            set;
        }

        public string AdmissionQueueNumber
        {
            get;
            set;
        }

        public string PatientIdentityNumber
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }

        public string EpisodeActionName
        {
            get;
            set;
        }

        public DateTime TransactionDate
        {
            get;
            set;
        }

        public string StateName
        {
            get;
            set;
        }

        public string AdmissionResourceName
        {
            get;
            set;
        }

        public DateTime RequestDateStr
        {
            get;
            set;
        }

        public bool isPregnant
        {
            get;
            set;
        }

        public bool isEmergency
        {
            get;
            set;
        }

        public bool isYoung
        {
            get;
            set;
        }

        public bool isOld
        {
            get;
            set;
        }

        public bool isVetera
        {
            get;
            set;
        }

        public bool isDisabled
        {
            get;
            set;
        }

        public bool hasMedicalInformation
        {
            get;
            set;
        }

        public Guid EpisodeObjectID
        {
            get;
            set;
        }

        public string TriageCode
        {
            get;
            set;
        }

        // Yatan hasta için 
        public bool HasTightContactIsolation
        {
            get;
            set;
        }

        public bool HasFallingRisk
        {
            get;
            set;
        }

        public bool HasDropletIsolation
        {
            get;
            set;
        }

        public bool HasAirborneContactIsolation
        {
            get;
            set;
        }

        public bool HasContactIsolation
        {
            get;
            set;
        }
        public long QueueNumberToSort
        {
            get;
            set;
        }

        public string RowColor
        {
            get;
            set;
        }

        public string AdmissionDoctorName
        {
            get;
            set;
        }

        public string ResponsibleNurseName
        {
            get;
            set;
        }

        //public List<TTObjectClasses.PriorityStatusDefinition> priorityStatusList { get; set; }
        //public string StateFormName { get; set; }

        public string PatientCallStatus { get; set; }
        public string TriageColor { get; set; }

        public string CurrentStateDefID { get; set; }

        public string ReasonOfCancel { get; set; }

        public bool isEmergencyManipulationRequest { get; set; }
    }

    public class EpisodeActionWorkListItem
    {
        public string ObjectDefName
        {
            get;
            set;
        }

        public string ObjectDefID
        {
            get;
            set;
        }
    }

    [Serializable]
    public class EpisodeActionWorkListStateItem
    {
        public string StateDefName
        {
            get;
            set;
        }

        public string StateDefID
        {
            get;
            set;
        }
        public string StateStatus
        {
            get;
            set;
        }
    }

    public class UserResourceItem
    {
        public string ResourceName
        {
            get;
            set;
        }

        public string ResourceID
        {
            get;
            set;
        }
    }

    public class SpecialPanelListItem
    {
        public string Name;
        public string Caption;
        public string ObjectID;
        public string User;
        public List<SpecialPanelCriteriaVal> SpecialPanelCriteriaValues;
    }

    public class SpecialPanelCriteriaVal
    {
        public string Name;
        public string ObjectID;
        public string Value;
    }

    public class SpecialPanelOutputDVO
    {
        public List<SpecialPanelListItem> SpecialPanelList;
        public SpecialPanelListItem LastSelectedSpecialPanel;
    }

    public class SpecialPanelInputDVO
    {
        public List<EpisodeActionWorkListItem> SelectedWorkListItems
        {
            get;
            set;
        }

        public List<EpisodeActionWorkListStateItem> SelectedWorkListStateItems
        {
            get;
            set;
        }

        public List<SpecialPanelListItem> SpecialPanelListItems
        {
            get;
            set;
        }

        public SpecialPanelListItem LastSelectedSpecialPanel
        {
            get;
            set;
        }

        public bool isNew
        {
            get;
            set;
        }

        public string SpecialPanelListItemCaption
        {
            get;
            set;
        }

        public string activeResUserObjectID
        {
            get;
            set;
        }
    }

    //public class ActiveInfoDVO
    //{
    //    public Guid EpisodeActionObjectID;
    //    public Guid EpisodeObjectID;
    //    public Guid PatientObjectID;
    //}
}