namespace TTObjectClasses
{
    public enum FixedAssetCMRStatusEnum : int
    {
        InUse = 0,
        InRepairProgress = 1,
        InReferToUpperLevelProgress = 2,
        InMaintenanceOrderProgress = 3,
        InCalibrationProgress = 4,
        InMaintenanceProgress = 5
    }
}