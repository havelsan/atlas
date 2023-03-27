namespace TTObjectClasses
{
    public enum RequiredPatientStatusEnum : int
    {
        OutPatient = 0,
        InPatient = 1,
        Discharge = 2,
        InOrOutPatient = 3,
        OutOrDischarge = 4,
        InOrDischarge = 5
    }
}