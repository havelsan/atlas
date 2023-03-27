import { Component, OnInit, OnDestroy } from '@angular/core';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';

@Component({
    selector: 'serialize-test-component',
    template: `
<h2>TTUser </h2>

<div class="row">
    <div class="col-lg-3"><h4>Aktif Kullanıcı</h4></div>
</div>
<div class="row">
    <div class="col-lg-4">Active User Name</div>
    <div class="col-lg-6">{{ActiveUser.Name}}</div>
</div>
<div class="row">
    <div class="col-lg-4">Active User IsSuperUser</div>
    <div class="col-lg-6">{{ActiveUser.IsSuperUser}}</div>
</div>

`
})
export class ActiveUserServiceTestComponent implements OnInit, OnDestroy {
    public ActiveUser: TTUser;
    constructor(private activeUserService: IActiveUserService, private httpService: NeHttpService) {
    }
    ngOnInit() {
       // this.ActiveUser = this.activeUserService.ActiveUser;
       // console.log(this.ActiveUser);
        this.ActiveUser = TTUser.CurrentUser;
        console.log(this.ActiveUser);
    }
    ngOnDestroy() {
    }
}