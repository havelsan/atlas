//$69752EA9

import { Component, OnInit } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

@Component({
    selector: 'ErrorWatcherForm',
    templateUrl: './ErrorWatcherForm.html',
})
export class ErrorWatcherForm implements OnInit  {
    public errors: any[];

    constructor(protected http: NeHttpService, protected messageService: MessageService) {
         
    }

    async ngOnInit() {
    }

    async LoadTTErrorLogs() {
        let input: any;
        let fullApiUrl: string = '/api/ErrorWatcherService/LoadTTErrorLogs';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                 this.errors = <any>res;
            })
            .catch(error => {
                
            });
    }

    onRowClickEvent(event){
        alert(event.data.Description);
    }

    public ErrorListColumns = [
        {
            caption: i18n("", "UserID"),
            dataField: "UserID",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("", "ErrorDate"),
            dataField: "ErrorDate",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("", "WorkStationName"),
            dataField: "WorkStationName",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("", "Description"),
            dataField: "Description",
            width: 400,
            allowSorting: true
        }
    ];
}