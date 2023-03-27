// Atlas auth-guard.service.ts
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CanActivate } from '@angular/router';
import { IAuthenticationService } from 'Fw/Services/IAuthenticationService';

@Injectable()
export class AtlasAuthGuardService implements CanActivate {

    constructor(private auth: IAuthenticationService, private router: Router) { }

    canActivate() {
        if (this.auth.loggedIn()) {
            return true;
        } else {
            this.router.navigate(['giris']);
            return false;
        }
    }
}