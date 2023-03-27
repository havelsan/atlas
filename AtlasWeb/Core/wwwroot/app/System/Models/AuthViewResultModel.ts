import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { TTUser } from 'app/NebulaClient/StorageManager/Security/TTUser';
import { AuthenticationResultEnum } from 'NebulaClient/Utils/Enums/AuthenticationResultEnum';

export class AuthViewResultModel {
    public Value: ValueContainer;
}
export class ValueContainer {
    public CaptchaGuid: Guid;
    public CaptchaImage: string;
    public ErrorMessage: string;
    public IsTokenAvailable: boolean;
    public access_token: string;
    public user: TTUser;
    public AuthResultEnum: AuthenticationResultEnum;
}