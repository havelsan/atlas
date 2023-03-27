using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class RadiologyWorkListFormViewModel
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

        public string  ID
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

        public List<RadiologyWorkListItemModel> RadiologyList
        {
            get;
            set;
        }

        public List<TTObjectClasses.MenuDefinition> MenuList
        {
            get;
            set;
        }

        public List<RadiologyWorkListItem> WorkListItems
        {
            get;
            set;
        }

        public List<RadiologyWorkListStateItem> WorkListStateItems
        {
            get;
            set;
        }

        public List<RadiologyWorkListItem> SelectedWorkListItems
        {
            get;
            set;
        }

        public List<RadiologyWorkListStateItem> SelectedWorkListStateItems
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

        public List<EquipmentItem> RadiologyEquipmentItems
        {
            get;
            set;
        }

        public List<EquipmentItem> SelectedRadiologyEquipmentItems
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
    }

    public class RadiologyWorkListItemModel
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

        public string PatientNameSurname
        {
            get;
            set;
        }
        
        public string EpisodeActionObjectID
        {
            get;
            set;
        }

        public string EpisodeActionName
        {
            get;
            set;
        }

        public string RadiologyTestName
        {
            get;
            set;
        }

        public string FromResourceName
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
        public bool Pandemic { get; set; }
        public bool isRadTestEmergency
        {
            get;
            set;
        }

        public string ActionDate
        {
            get;
            set;
        }
        public string RowColor { get; set; }
        //public List<TTObjectClasses.PriorityStatusDefinition> priorityStatusList { get; set; }
        //public string StateFormName { get; set; }
    }

    public class RadiologyWorkListItem
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

    public class RadiologyWorkListStateItem
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
    }


    public class EquipmentItem
    {
        public string EquipmentName
        {
            get;
            set;
        }

        public string EquipmentResourceID
        {
            get;
            set;
        }
    }

    public class RadiologyEquipmentOutputDVO
    {
        public List<EquipmentItem> EquipmentItemList
        {
            get;
            set;
        }
    }


    public class RadiologyStatisticReportViewModel
    {
        public List<RadiologyStatisticBaseObject> TestTypeList { get; set; }
        public List<RadiologyStatisticBaseObject> RadiologyTestList { get; set; }
        public List<RadiologyStatisticBaseObject> GenderList { get; set; }
        public List<RadiologyStatisticBaseObject> PayerList { get; set; }
        public List<RadiologyStatisticBaseObject> ResourceList { get; set; }
        public List<RadiologyStatisticBaseObject> EquipmentList { get; set; }
        public List<RadiologyStatisticBaseObject> ProcedureDoctorList { get; set; }
    }

    public class RadiologyStatisticBaseObject
    {
        public string ObjectID { get; set; }
        public string Name { get; set; }
    }


    //public class UserResourceItem
    //{
    //    public string ResourceName
    //    {
    //        get;
    //        set;
    //    }

    //    public string ResourceID
    //    {
    //        get;
    //        set;
    //    }
    //}

    //public class SpecialPanelListItem
    //{
    //    public string Name;
    //    public string Caption;
    //    public string ObjectID;
    //    public List<SpecialPanelCriteriaVal> SpecialPanelCriteriaValues;
    //}

    //public class SpecialPanelCriteriaVal
    //{
    //    public string Name;
    //    public string ObjectID;
    //    public string Value;
    //}

    //public class SpecialPanelOutputDVO
    //{
    //    public List<SpecialPanelListItem> SpecialPanelList;
    //    public SpecialPanelListItem LastSelectedSpecialPanel;
    //}

    //public class SpecialPanelInputDVO
    //{
    //    public List<RadiologyWorkListItem> SelectedWorkListItems
    //    {
    //        get;
    //        set;
    //    }

    //    public List<RadiologyWorkListStateItem> SelectedWorkListStateItems
    //    {
    //        get;
    //        set;
    //    }

    //    public List<SpecialPanelListItem> SpecialPanelListItems
    //    {
    //        get;
    //        set;
    //    }

    //    public SpecialPanelListItem LastSelectedSpecialPanel
    //    {
    //        get;
    //        set;
    //    }

    //    public bool isNew
    //    {
    //        get;
    //        set;
    //    }

    //    public string SpecialPanelListItemCaption
    //    {
    //        get;
    //        set;
    //    }
    //    public string activeResUserObjectID
    //    {
    //        get;
    //        set;
    //    }
    //}
}