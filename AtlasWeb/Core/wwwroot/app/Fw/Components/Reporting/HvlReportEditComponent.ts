import { Component, ViewEncapsulation, OnInit, ViewChild, Input, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import DevExpress from "@devexpress/analytics-core";
import { DxReportDesignerComponent } from 'devexpress-reporting-angular';

import { environment } from 'app/environments/environment';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { DynamicReportParameters, ReportRevisionDto } from './HvlDynamicReportComponent';
import { DxTextBoxComponent, DxSelectBoxComponent } from 'devextreme-angular';

@Component({
    selector: 'hvl-report-edit',
    templateUrl: './HvlReportEditComponent.html'
})
export class HvlReportEditComponent implements OnInit {
    public reports: Array<ReportDto> = [];
    public revisions: Array<ReportRevisionDto> = [];
    public dataSourceClasses: Array<string> = [];
    public showCreateReport: boolean = false;
    public showDesigner: boolean = false;

    public uploadUrl : string = environment.apiRoot + "/api/DynamicReport/UploadReport";
    public uploadValue : any;
    public uploadHeaders : any;

    @ViewChild('txtReportName') txtReportName: DxTextBoxComponent;
    @ViewChild('txtClassName') txtClassName: DxSelectBoxComponent;
    @ViewChild('txtReportComment') txtReportComment: DxTextBoxComponent;
    @ViewChild('txtReportCode') txtReportCode: DxTextBoxComponent;
    constructor(private httpService: NeHttpService, private changeDetector : ChangeDetectorRef
        ) {
        this.emptyReports();
    }

    onUploaded(event : any){
        this.loadReports();
        console.log(event);
    }
    onUploadError(event : any){
        console.log(event);
    }


    emptyReports() {
        this.reports.Clear();
        this.reports.push({ ObjectID: '-1', LongName : 'Lütfen Rapor Seçiniz', Name: 'Lütfen Rapor Seçiniz', ReportClassName: '' });
        this.reports.push({ ObjectID: '0', LongName : 'Yeni Rapor',  Name: 'Yeni Rapor', ReportClassName: '' });
    }


    public DynamicReportParameters: DynamicReportParameters = {};

    ngOnInit() {

        this.loadReports();
        this.loadDataSourceClasses();

        let token = sessionStorage.getItem('token');
        this.uploadHeaders = { Authorization: `Bearer ${token}` };
    }


    loadReports() {
        this.httpService.get<Array<ReportDto>>("/api/DynamicReport/GetReports?getAll=false").then(x => {
            if (x && x.length > 0) {
                this.emptyReports();
                this.reports = this.reports.concat(x);
            }
        });
    }

    loadDataSourceClasses() {
        this.httpService.get<Array<string>>("/api/DynamicReport/GetDataSourceClasses").then(x => {
            if (x && x.length > 0) {
                this.dataSourceClasses = x;
            }
        });
    }

    loadRevisions(dynamicReportID: string) {
        this.httpService.get<Array<ReportRevisionDto>>("/api/DynamicReport/GetRevisionReports?dynamicReportID=" + dynamicReportID).then(x => {
            this.revisions = x;

            if(this.revisions.length == 0){
                this.showDesigner = true;
            }
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

    downloadRevision(){
        this.httpService.get<any>("/api/DynamicReport/DownloadReportRevision?revisionID=" + this.DynamicReportParameters.DynamicReportRevisionID).then(x => {
            
            this.saveJSON(x, "Report.json");

        });
    }

    setAsMainRevision(){

        this.httpService.get<Boolean>("/api/DynamicReport/SetAsMainRevision?objectID=" + this.DynamicReportParameters.DynamicReportRevisionID).then(x => {
            
            this.DynamicReportParameters.DynamicReportRevisionID = null;
            this.loadRevisions(this.DynamicReportParameters.DynamicReportID);
            
        });
    }

    clearReportObject(){
        this.DynamicReportParameters.DynamicReportID = null;
        this.DynamicReportParameters.DynamicReportRevisionID = null;
        this.DynamicReportParameters.ReportComment = '';
        this.DynamicReportParameters.ReportParams = null;

        if(this.revisions && this.revisions.length > 0){
            this.revisions.Clear();
        }
        
    }
    enableDisableButtonClicked(){

        this.setEnableDisable(this.selectedItem.ObjectID, !this.selectedItem.Enabled);
    }
    setEnableDisable(objectID : string, enabled : boolean){
        this.httpService.get<Boolean>("/api/DynamicReport/SetEnableDisable?objectID=" + objectID + "&enable=" + enabled).then(x => {
            this.loadReports();
        });
    }

    selectedItem : ReportDto;
    reportChanged(e) {

        let value = e.value as ReportDto;

        this.selectedItem = value;

        this.showDesigner = false;
        if (value.ObjectID == '0') {
            //New Report
            this.showCreateReport = true;
            this.clearReportObject();
        }
        else if (value.ObjectID == '-1') {
            //Please Select
            this.showCreateReport = false;
            this.clearReportObject();
        }
        else {
            //A Report
            this.showCreateReport = false;

            this.DynamicReportParameters.DynamicReportID = value.ObjectID;
            this.DynamicReportParameters.DynamicReportRevisionID = null;

            this.loadRevisions(value.ObjectID);
        }
        console.log(e);
    }
    revisionChanged(e) {
        console.log(e);
        let value = e.value as ReportRevisionDto;
        this.showDesigner = false;
        this.changeDetector.detectChanges();
        this.DynamicReportParameters.DynamicReportRevisionID = value.ObjectID;
        this.showDesigner = true;
        this.changeDetector.detectChanges();
    }

    public beforeSave(e:any){
        this.DynamicReportParameters.ReportComment = this.txtReportComment.value;
    }

    public onSave(e:any){
        this.loadRevisions(this.DynamicReportParameters.DynamicReportID);
    }


 saveJSON(data, filename){

        if(!data) {
            console.error('No data')
            return;
        }
    
        if(!filename) filename = 'console.json'
    
        if(typeof data === "object"){
            data = JSON.stringify(data, undefined, 4)
        }
    
        var blob = new Blob([data], {type: 'text/json'}),
            e    = document.createEvent('MouseEvents'),
            a    = document.createElement('a')
    
        a.download = filename
        a.href = window.URL.createObjectURL(blob)
        a.dataset.downloadurl =  ['text/json', a.download, a.href].join(':')
        e.initMouseEvent('click', true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null)
        a.dispatchEvent(e)
    }

}

export class ReportDto {
    public Name: string;
    public ReportClassName: string;
    public ObjectID?: string;
    public Enabled? : boolean;
    public Code?: string;
    public LongName?: string;

}