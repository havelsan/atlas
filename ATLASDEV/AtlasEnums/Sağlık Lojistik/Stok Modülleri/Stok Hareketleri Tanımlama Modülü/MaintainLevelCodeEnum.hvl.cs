namespace TTObjectClasses
{
    public enum MaintainLevelCodeEnum : int
    {
        Nothing = 0,
        IncreaseInheld = 2,
        DecreaseInheld = 4,
        IncreaseConsigned = 8,
        DecreaseConsigned = 16,
        DecreaseInheld__IncreaseConsigned = 32,
        IncreaseInheld__DecreaseConsigned = 64,
        ReturnInheld = 128
    }
}