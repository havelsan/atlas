//$5A09452A
// Atlas auth-guard.service.ts
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

@Injectable()
export class CashOfficeAuthGuardService implements CanActivate {

    constructor(protected http: NeHttpService, ) {

    }

    async canActivate(): Promise<boolean> {
        let auth = await this.http.get<boolean>('api/CashOfficePatientApi/CheckSecurity');
        if (!auth)
            ServiceLocator.MessageService.showError(i18n("M12091", "Bu sayfayı görüntülemeye yetkiniz bulunmamaktadır."));
        return auth;
    }
}