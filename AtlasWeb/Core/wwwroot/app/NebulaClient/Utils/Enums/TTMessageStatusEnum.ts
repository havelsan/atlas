export enum TTMessageStatusEnum {
    Unknown = 0,
    Waiting = 1,
    RequestTimeOut = 2,
    InternalException = -1,
    RemotingException = -2,
    ServerException = -3,
    OtherException = -4,
    SocketException = -5,
    MessageNotFound = -7,
    MessageReject = -8,
    MessageSizeLimit = -9,
    Completed = 8
}