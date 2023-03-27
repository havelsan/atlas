//$B6A32B45
import { Component } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { SimpleTimer } from 'ng2-simple-timer';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
@Component({
    selector: 'GenelLcdForm',
    templateUrl: './GenelLcdForm.html',
    providers: [MessageService]
})
export class GenelLcdForm {
    Model: any;
    dataSource: any;
    selectedQueue: any;
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private st: SimpleTimer, private activeUserService: IActiveUserService) {
        let apiUrl: string = '/api/GenelLcdForm/GenelLcdFormOpen';
        this.httpService.get(apiUrl).then(
            x => {
                this.Model = x;
                this.dataSource = this.Model.queueList;
            }
        );

    }
    public GridColumns = [
        {
            'caption': i18n("M10514", "Adı"),
            dataField: 'Name',
            allowSorting: true
        },

    ];
    select(data) {
        this.selectedQueue = data.selectedRowsData;
    }

    OpenEmergencyForm() {

        let objectIds = "";
        for (let i = 0; i < this.selectedQueue.length; i++) {
            if (i == this.selectedQueue.length - 1)
                objectIds += this.selectedQueue[i].ObjectID.toString();
            else
                objectIds += this.selectedQueue[i].ObjectID.toString() + ",";
        }
        let currentLocation = window.location.href.replace("/hastacagri", "");
        let url = currentLocation + "/lcd/emergenyCallPatientForm?showAsAnonymous&IDS=" + objectIds;
        let input: any = { Url: encodeURI(url) };
        let httpServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
        this.httpService.post(httpServiceUrl, input);

    }
    async OpenMonitor() {
        let isnewlcd = await SystemParameterService.GetParameterValue('ISNEWLCD', 'FALSE');
        if (isnewlcd == "FALSE") {
            let objectIds1 = "";
            for (let i = 0; i < this.selectedQueue.length; i++) {
                if (i == this.selectedQueue.length - 1)
                    objectIds1 += this.selectedQueue[i].ObjectID.toString();
                else
                    objectIds1 += this.selectedQueue[i].ObjectID.toString() + ",";
            }
            let currentLocation1 = window.location.href.replace("/hastacagri", "");
            let url1 = currentLocation1 + "/PatientCaller/HastaGenelCagriForm?outPatientResIDs=" + objectIds1 + "&includeCalleds=false";
            let input1: any = { Url: encodeURI(url1) };
            console.log(input1);
            let httpServiceUrl1 = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
            this.httpService.post(httpServiceUrl1, input1);
        } else {
            let objectIds = "";
            for (let i = 0; i < this.selectedQueue.length; i++) {
                if (i == this.selectedQueue.length - 1)
                    objectIds += this.selectedQueue[i].ObjectID.toString();
                else
                    objectIds += this.selectedQueue[i].ObjectID.toString() + ",";
            }
            let currentLocation = window.location.href.replace("/hastacagri", "");
            let url = currentLocation + "/lcd/generalLcdForm?showAsAnonymous&IDS=" + objectIds;
            let input: any = { Url: encodeURI(url) };
            console.log(input);
            let httpServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
            this.httpService.post(httpServiceUrl, input);
        }
    }

    OpenSurgeryMonitor() {

        let currentLocation = window.location.href.replace("/hastacagri", "");
        let url = currentLocation + "/lcd/surgery?showAsAnonymous";
        let input: any = { Url: encodeURI(url) };
        let httpServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
        this.httpService.post(httpServiceUrl, input);

    }

    OpenEmergencyMonitor() {

        let currentLocation = window.location.href.replace("/hastacagri", "");
        let url = currentLocation + "/lcd/emergency?showAsAnonymous";
        let input: any = { Url: encodeURI(url) };
        let httpServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
        this.httpService.post(httpServiceUrl, input);

    }


    OpenNewBornMonitor() {

        let currentLocation = window.location.href.replace("/hastacagri", "");
        let url = currentLocation + "/lcd/newBorn?showAsAnonymous";
        let input: any = { Url: encodeURI(url) };
        let httpServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
        this.httpService.post(httpServiceUrl, input);

    }
}