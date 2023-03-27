//$B031EBC6
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { HasLaundryRolesModel } from './LaundryViewModel';

import { ServiceLocator } from 'Fw/Services/ServiceLocator';

@Component({
    selector: "laundry-main-form",
    templateUrl: './LaundryMainForm.html'
})
export class LaundryMainForm implements OnInit {

    public hasLaundryRole: HasLaundryRolesModel = new HasLaundryRolesModel();

    constructor(protected http: NeHttpService) {
        this.http.get<HasLaundryRolesModel>("api/LaundryApi/HasLaundryRoles").then(result => {
            this.hasLaundryRole = result;
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
            console.log(error);
        });
    }

    ngOnInit() {

    }
}