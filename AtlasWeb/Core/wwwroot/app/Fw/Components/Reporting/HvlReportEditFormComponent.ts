import { Component, ViewEncapsulation, OnInit, ViewChild, Input, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import DevExpress from "@devexpress/analytics-core";
import { DxReportDesignerComponent } from 'devexpress-reporting-angular';

import { environment } from 'app/environments/environment';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { DynamicReportParameters, ReportRevisionDto } from './HvlDynamicReportComponent';
import { DxTextBoxComponent } from 'devextreme-angular';
import { ReportDto } from './HvlReportEditComponent';

@Component({
    selector: 'hvl-report-editform',
    templateUrl: './HvlReportEditFormComponent.html'
})
export class HvlReportEditFormComponent implements OnInit {
    public reports: Array<ReportDto> = [];
    public showCreateReport: boolean = false;
    public showDesigner: boolean = false;

    @ViewChild('txtReportName') txtReportName: DxTextBoxComponent;
    @ViewChild('txtClassName') txtClassName: DxTextBoxComponent;
    @ViewChild('txtReportCode') txtReportCode: DxTextBoxComponent;
    @ViewChild('txtReportComment') txtReportComment: DxTextBoxComponent;

    constructor(private httpService: NeHttpService, private changeDetector : ChangeDetectorRef
        ) {
        this.emptyReports();
    }
    emptyReports() {
        this.reports.Clear();
        this.reports.push({ ObjectID: '-1', Name: 'Lütfen Veri Kaynağı Seçiniz', ReportClassName: ''});
        this.reports.push({ ObjectID: '0', Name: 'Yeni Veri Kaynağı', ReportClassName: ''});
    }
    ngOnInit() {
        this.loadReports();
    }
    loadReports() {
        this.httpService.get<Array<ReportDto>>("/api/DynamicReport/GetReports?getAll=true").then(x => {
            if (x && x.length > 0) {
                this.emptyReports();
                this.reports = this.reports.concat(x);
            }
        });
    }
    enableDisableButtonClicked(){

        this.setEnableDisable(this.selectedItem.ObjectID, !this.selectedItem.Enabled);
    }

    setEnableDisable(objectID : string, enabled : boolean){
        this.httpService.get<Boolean>("/api/DynamicReport/SetEnableDisable?objectID=" + objectID + "&enable=" + enabled).then(x => {
            this.loadReports();
        });
    }

    saveReport() {
        let reportName = this.txtReportName.value;
        let className = this.txtClassName.value;

        if (reportName.length < 1 || className.length < 1) {
            console.warn("reportName and className must be filled.");
            return;
        }
        let dto: ReportDto = { Name: this.txtReportName.value, ReportClassName: this.txtClassName.value, Code : this.txtReportCode.value };

        this.httpService.post<Boolean>("/api/DynamicReport/SaveReport", dto).then(x => {
            this.loadReports();
        });
    }

    selectedItem : ReportDto;

    reportChanged(e) {

        this.selectedItem = e.value as ReportDto;

        if (this.selectedItem.ObjectID == '0') {
            //New Report
            this.showCreateReport = true;
        }
        else if (this.selectedItem.ObjectID == '-1') {
            //Please Select
            this.showCreateReport = false;
        }
        else {
            //A Report
            this.showCreateReport = false;

        }
        
        console.log(e);
    }
}

