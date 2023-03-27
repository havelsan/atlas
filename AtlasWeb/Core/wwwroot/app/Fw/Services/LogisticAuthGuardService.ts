//$9F7B89C1
// Atlas auth-guard.service.ts
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

@Injectable()
export class LogisticAuthGuardService implements CanActivate {

    constructor(protected http: NeHttpService ) {

    }

    async canActivate(): Promise<boolean> {
        let auth = await this.http.get<boolean>('api/MainView/CheckSecurity');
        if (!auth)
            ServiceLocator.MessageService.showError(i18n("M12086", "Bu işlemi yapmaya yetkiniz bulunmamaktadır."));
        return auth;
    }


}