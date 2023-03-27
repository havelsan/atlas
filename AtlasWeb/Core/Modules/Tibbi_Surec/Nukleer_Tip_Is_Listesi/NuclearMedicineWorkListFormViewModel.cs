using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class NuclearMedicineWorkListStateItem
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

    public class NuclearMedicineWorkListFormViewModel
    {
        public bool OnlyOwnPatient // Yalnız Kendi Hastaları
        {
            get;
            set;
        }

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
        public string ProtocolNo
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }

        public string ID
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

        public List<NuclearMedicineWorkListItemModel> NuclearMedicineList
        {
            get;
            set;
        }

        public List<TTObjectClasses.MenuDefinition> MenuList
        {
            get;
            set;
        }

        public List<NuclearMedicineWorkListItem> WorkListItems
        {
            get;
            set;
        }

        public List<NuclearMedicineWorkListStateItem> WorkListStateItems
        {
            get;
            set;
        }

        public List<NuclearMedicineWorkListItem> SelectedWorkListItems
        {
            get;
            set;
        }

        public List<NuclearMedicineWorkListStateItem> SelectedWorkListStateItems
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

        public List<EquipmentItem> NuclearMedicineEquipmentItems
        {
            get;
            set;
        }

        public List<EquipmentItem> SelectedNuclearMedicineEquipmentItems
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

    public class NuclearMedicineWorkListItemModel
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

        public string NuclearMedicineTestName
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

        public bool isNuclearMedicineTestEmergency
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
    }

    public class NuclearMedicineWorkListItem
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

    public class NuclearMedicineEquipmentOutputDVO
    {
        public List<EquipmentItem> EquipmentItemList
        {
            get;
            set;
        }
    }
}