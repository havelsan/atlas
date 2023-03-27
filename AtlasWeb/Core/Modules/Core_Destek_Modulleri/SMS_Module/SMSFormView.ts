import { Component, OnInit, Input, AfterViewInit, ViewChild, ApplicationRef } from "@angular/core";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { SMSFormViewModel } from "./SMSFormViewModel";
import { NeHttpService } from "app/Fw/Services/NeHttpService";


@Component({
    selector: 'sms-form-view',
    templateUrl: './SMSFormView.html',
    providers: [MessageService, SystemApiService]
})
export class SMSFormView implements OnInit, AfterViewInit {

    /**
     *
     */
    public mainViewModel: SMSFormViewModel = new SMSFormViewModel();
    public SpecialityDataSource: Array<any>;
    public SKRSIlList: Array<any>;
    public UserSearchCriteriaButtonStyle: Object = { 'min-width': '275px', 'text-align': 'left' };
    
    constructor(private http: NeHttpService) {

    }

    ngOnInit(): void {
        let that = this;
        this.http.get<SMSFormViewModel>('api/SMSFormApi/InitSMSForm').then(res => {
            this.mainViewModel = res;
        });
    }

    ngAfterViewInit(): void {
    }

}