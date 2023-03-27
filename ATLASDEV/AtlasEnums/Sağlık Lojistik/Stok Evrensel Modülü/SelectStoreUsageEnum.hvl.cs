namespace TTObjectClasses
{
    public enum SelectStoreUsageEnum : int
    {
        Nothing = 0,
        UseUserResources = 1,
        UseInPatientUserResource = 2,
        UseOutPatientUserResource = 3,
        UseSecMasterUserResource = 4,
        UseSelectedInPatientUserResource = 5,
        UseSelectedOutPatientUserResource = 6,
        UseSelectedSecMasterUserResource = 7,
        UseBothPatientUserResource = 8,
        UseUserResource = 9,
        UseClinicPharmacyStores = 10,
        UseMainStoreResources = 11,
        UseMainStores = 12,
        UseTentativeStores = 13,
        UseTentativeStoreResources = 14,
        UseRoomStores = 15,
        UseRoomStoreParentSubStore = 16,
        UseUnitStoreResources = 17,
        UsePharmacyMainStore = 18
    }
}