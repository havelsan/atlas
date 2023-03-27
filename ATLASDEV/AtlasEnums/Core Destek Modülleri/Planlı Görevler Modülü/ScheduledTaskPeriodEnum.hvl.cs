namespace TTObjectClasses
{
    public enum ScheduledTaskPeriodEnum : int
    {
        OneTime = 0,
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Hourly = 4,
        EachTenMinutes = 5,
        CronExpression = 6
    }
}