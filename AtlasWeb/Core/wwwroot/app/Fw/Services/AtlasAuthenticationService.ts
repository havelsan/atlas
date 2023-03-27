//$6967B4A6
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Headers, RequestOptionsArgs, RequestMethod } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { tokenNotExpired } from '../../auth.module';
import { ReplaySubject } from 'rxjs';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { MessageService } from 'Fw/Services/MessageService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { AuthViewResultModel } from '../../System/Models/AuthViewResultModel';
import { AuthenticationResultEnum } from 'NebulaClient/Utils/Enums/AuthenticationResultEnum';
import { IAuthenticationService } from 'app/Fw/Services/IAuthenticationService';
import { EventEmitter } from '@angular/core';



const failedLoginMessage = i18n("M14800", "Giriş işlemi başarısız. Lütfen kullanıcı adı/şifrenizi kontrol ediniz");
const authUrl = `/api/account/authenticate`;

@Injectable()
export class AtlasAuthenticationService implements IAuthenticationService {
    
    public OnLogout: EventEmitter<string> = new EventEmitter<string>();
    private readonly LabelCurrentUser = 'currentUser';
    private readonly LabelToken = 'token';
    private readonly LabelUserName = 'UserName';
    public token: string;

    private _authenticationCompleted: ReplaySubject<string> = new ReplaySubject<string>(1);
    public AuthenticationCompletedSource = this._authenticationCompleted.asObservable();

    private get targetStorage(): Storage {
        return sessionStorage;
    }

    constructor(private http: HttpClient, public router: Router, private activeUserService: IActiveUserService,
        private messageService: MessageService) {
        // set token if saved in session storage
        let currentUser = this.targetStorage.getItem(this.LabelCurrentUser);
        this.token = this.targetStorage.getItem(this.LabelToken);
    }

    public login(userName: string, password: string, captchaguid: Guid, captchaCode: string): Promise<AuthViewResultModel> {
        let that = this;
        return new Promise<AuthViewResultModel>((resolve, reject) => {
            let headers = new Headers({
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            });

            const payload = { UserName: userName, Password: password, CaptchaGuid: captchaguid, CaptchaCode: captchaCode };

            let options: RequestOptionsArgs = {};
            options.url = authUrl;
            options.method = RequestMethod.Post;
            options.body = JSON.stringify(payload);
            options.headers = headers;

            that.http.post(authUrl, payload).toPromise().then((response: AuthViewResultModel) => {
                // login successful if there's a jwt token in the response
                let token = response && response.Value && response.Value.access_token;
                if (token) {
                    // set token property
                    this.token = token;
                    let currentUser = plainToClass<TTUser, {}>(TTUser, response.Value.user);
                    // store username and jwt token in session storage to keep user logged in between page refreshes
                    this.targetStorage.setItem(this.LabelCurrentUser, currentUser.UserID.toString());
                    this.targetStorage.setItem(this.LabelToken, token);
                    this.targetStorage.setItem(this.LabelUserName, userName);
                    // store active user information to shared sigleton service
                    that.activeUserService.ActiveUser = currentUser;
                    // return true to indicate successful login
                    that._authenticationCompleted.next(currentUser.UserID.toString());

                    if (response.Value.AuthResultEnum == AuthenticationResultEnum.PasswordOK)
                        response.Value.IsTokenAvailable = true;
                    else if (response.Value.AuthResultEnum == AuthenticationResultEnum.PasswordExpired) {
                        response.Value.IsTokenAvailable = false;
                        that.messageService.showError(response.Value.ErrorMessage);
                    }
                    else if (response.Value.AuthResultEnum == AuthenticationResultEnum.WarnUserToChangePassword) {
                        response.Value.IsTokenAvailable = true;
                        that.messageService.showError(response.Value.ErrorMessage);
                    }

                    //response.Value.IsTokenAvailable = true;
                    resolve(response);
                } else {
                    if (!String.isNullOrEmpty(response.Value.ErrorMessage))
                        that.messageService.showError(response.Value.ErrorMessage);
                    resolve(response);
                }

            });
            // .catch((error: HttpErrorResponse) => {
            //     let errorMessage = '';
            //     if (error.error && error.error.error_description) {
            //         errorMessage = error.error.error_description;
            //     }
            //     that.messageService.showError(errorMessage);
            //     resolve(false);

            // });
        });
    }

    logout(): void {
        // clear token remove user from session storage to log user out
        this.token = null;
        this.targetStorage.removeItem(this.LabelCurrentUser);
        this.targetStorage.removeItem(this.LabelToken);
        window.sessionStorage.clear();
        this.activeUserService.clearState();
        this.OnLogout.emit();
        this.router.navigate(['giris']);
    }

    loggedIn(): boolean {
        return tokenNotExpired();
    }

    refreshCaptcha(userName: string): Promise<AuthViewResultModel> {
        let that = this;
        return new Promise<AuthViewResultModel>((resolve, reject) => {
            let headers = new Headers({
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            });

            // let options: RequestOptionsArgs = {};
            // options.url = '/api/account/RefreshCaptcha';
            // options.method = RequestMethod.Post;
            // options.headers = headers;
            let url = '/api/account/RefreshCaptcha?userName=' + userName;
            that.http.get(url).toPromise().then((response: AuthViewResultModel) => {
                // login successful if there's a jwt token in the response
                if (response) {
                    if (!String.isNullOrEmpty(response.Value.ErrorMessage))
                        that.messageService.showError(response.Value.ErrorMessage);
                    else
                        resolve(response);
                }
            });
        });
    }
}