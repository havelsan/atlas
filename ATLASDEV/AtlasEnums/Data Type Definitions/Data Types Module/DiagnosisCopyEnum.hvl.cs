namespace TTObjectClasses
{
    public enum DiagnosisCopyEnum : int
    {
        DontCopy = 0,
        CopyFromFirstSubEpisode = 1,
        CopyFromLastSubEpisode = 2,
        CopyFromLastSubEpisodeWithSameSpeciality = 3
    }
}