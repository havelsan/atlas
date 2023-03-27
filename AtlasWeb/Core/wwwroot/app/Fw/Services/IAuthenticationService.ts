import { Observable } from "rxjs";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { AuthViewResultModel } from '../../System/Models/AuthViewResultModel';
import { EventEmitter } from "@angular/core";

export abstract class IAuthenticationService {
    abstract login(username: string, password: string, captchaguid: Guid, captchaCode: string): Promise<AuthViewResultModel>;
    abstract refreshCaptcha(userName: string): Promise<AuthViewResultModel>;
    abstract logout(): void;
    abstract loggedIn(): boolean;
    abstract AuthenticationCompletedSource: Observable<string>;
    abstract OnLogout: EventEmitter<string>;
}