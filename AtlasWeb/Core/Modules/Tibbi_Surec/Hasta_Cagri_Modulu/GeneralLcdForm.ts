//$19F8320B
import { Component, OnInit, NgZone, ViewChild, ElementRef } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { Common } from 'app/NebulaClient/Model/AtlasClientModel';
import { Http, Response } from '@angular/http';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { window } from 'rxjs/operators';
@Component({
    selector: 'GeneralLcdForm',
    templateUrl: './GeneralLcdForm.html',
    providers: [MessageService]
})
export class GeneralLcdForm {
    public IDS;
    constructor(protected httpService: Http) {
        this.IDS = this.getUrlParameter("IDS");
    }
    currentItem: QueueItems= new QueueItems();
    public _Model: Array<QueueItems>;

    currentPage: number = 0;
    pageSize: number = 0;
    pageCount: number = 0;
    trHeight: number = 73;
    pageInterval = 10000;
    dataInterval = 5000;

    callPatientCount: number = 0;
    callPatientPage: number = 0;
    callPatientItem: CallPatientItem = new CallPatientItem();

    ngOnInit() {
        this.start();
    }

    async start() {

        //let bodyHeight = window.innerHeight - 204;
        //this.pageSize = Math.floor(bodyHeight / 73);

        await this.LoadData();
        this.updateScreen();

        setInterval(() => {
            this.LoadData();
        }, this.dataInterval);

        setInterval(() => {
            this.updateScreen();
        }, this._Model[0].GeneralLcdUpdateTime);
    }

    updateScreen() {

        if (this._Model == null || this._Model.length == 0) {
            return;
        }

        this.currentItem= this._Model[this.currentPage]

        this.currentPage++;

        if (this.currentPage >= this.pageCount) {
            this.currentPage = 0;
        }

        if (this.callPatientCount > 0) {

            this.callPatientItem = this._Model.filter(c => c.callPatients.length > 0)[this.callPatientPage].callPatients[0];
            this.callPatientPage++;
            if (this.callPatientPage >= this.callPatientCount) {
                this.callPatientPage = 0;
                this.callPatientCount = 0;
            }
        }

    }
    calculateVariables() {
        this.pageCount = this._Model.length;
        this.callPatientCount = this._Model.filter(c => c.callPatients.length > 0).length;
    }


    getUrlParameter(name) {
        name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
        var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
        var results = regex.exec(location.search);
        return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
    }

    public async LoadData() {
        return this.httpService.get("/api/GeneralLcdForm/GetGeneralLcd?outPatientResIDs=" + this.IDS).toPromise().then(response => {

            this._Model = response.json() as Array<QueueItems>;
            this.calculateVariables();

        });
    }
}


export class QueuePatient {
    public patientName: string;
    public OrderNO: string;
    public PriorityReason: string;
    public Priority: string;
    public QueueDate: string;
    public CallTime: Date;
    public DivertedTime: string;
    public Doctor: string;
    public Index: number;
    public ObjectID: Guid;
    public IsEmergency: Boolean;
    public SubActionProcedureObjectID: Guid;
}
export class QueueItems {
    public doctorName: string;
    public polName: string;
    public hospitalName: string;
    public GeneralLcdUpdateTime: number;
    public GeneralLcdNotification: string;
    public LcdNotification: string;
    public Count: number;
    public patient: Array<QueuePatient> = new Array<QueuePatient>();
    public callPatients: Array<CallPatientItem> = new Array<CallPatientItem>();
}

export class Policinics {
    public Policlinics: Array<Policlinic> = new Array<Policlinic>();
}


export class Policlinic {
    public Name: string;
    public Count: number;
}

export class CallPatientItem {
    public patientName: string;
    public policlinicName: string;
}