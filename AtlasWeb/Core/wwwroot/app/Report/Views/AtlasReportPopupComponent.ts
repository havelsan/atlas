import { Component, Input } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';

@Component({
    selector: "atlas-report-popup-component",
    template: ` <dx-button [text]= "ReportName" type="btn btn-default" (click)="printReport()"  ></dx-button>
                <dx-popup  [title]= "ReportName"  [(visible)]="showPopup" [width]="300" [height]="300">
                   <div *dxTemplate="let data of 'content'">
                        <atlas-report-component [ReportDefName]="ReportDefName" (ReportPrinted)="reportPrinted()" [TTObjectID] ="TTObjectID" ></atlas-report-component>
                  </div>
                </dx-popup> `,
})
export class AtlasReportPopupComponent {

    showPopup: boolean = false;
    @Input() ReportName: String;
    @Input() ReportDefName: String;

    private _ttObjectID?: string;
    @Input() set TTObjectID(value: string) {
        this._ttObjectID = value;
    }
    get TTObjectID(): string {
        return this._ttObjectID;
    }

    constructor(private http: NeHttpService) {

    }

    public printReport() {

        this.showPopup = true;
    }

    public reportPrinted() {

        this.showPopup = false;
    }

}