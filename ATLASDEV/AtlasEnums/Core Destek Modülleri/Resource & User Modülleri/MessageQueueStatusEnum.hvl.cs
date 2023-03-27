namespace TTObjectClasses
{
    public enum MessageQueueStatusEnum : int
    {
        SocketException = -5,
        OtherException = -4,
        ServerException = -3,
        RemotingException = -2,
        InternalException = -1,
        Unknown = 0,
        Waiting = 1,
        RequestTimeOut = 2
    }
}