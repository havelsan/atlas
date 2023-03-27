export enum AuthenticationResultEnum {
    PasswordOK,
    PasswordWrong,
    PasswordExpired,
    UserNotFound,
    DisableUser,
    UserIsDisabled,
    WarnUserToChangePassword,
    SystemAccountsCantLogin
}