import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';

@Injectable()
export class AtlasConfigurationService {

    constructor(private http: AtlasHttpService, private activeUserService: IActiveUserService) {
    }

    initialize(): Promise<void> {
        let that = this;
        return new Promise<void>((resolve, reject) => {
            let currentUserId = sessionStorage.getItem('currentUser');
            if (currentUserId == null) {
                resolve();
                return;
            }
            let authUserUrl = `/api/account/getuser?userID=${currentUserId}`;
            this.http.get(authUserUrl).toPromise()
                .then((response: Response) => {
                    let currentUserJson = response.json() && response.json().user;
                    if (currentUserJson) {
                        let currentUser = plainToClass<TTUser, {}>(TTUser, response.json().user);
                        that.activeUserService.ActiveUser = currentUser;
                    }
                    resolve();
                }).catch(err => {
                    resolve();
                });
        });

    }

}
