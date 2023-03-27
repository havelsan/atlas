import { Component, ViewEncapsulation, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';

import { DxReportDesignerComponent } from 'devexpress-reporting-angular';
import { environment } from 'app/environments/environment';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import DevExpress from 'devexpress-reporting';
import * as devex2 from "@devexpress/analytics-core";

@Component({
    selector: 'hvl-dynamic-report',
    templateUrl: './HvlDynamicReportComponent.html',
})
export class HvlDynamicReportComponent implements OnInit {

    ready: boolean = false;
    constructor(private httpService: NeHttpService) {
        
        devex2.default.Analytics.Utils.ajaxSetup.ajaxSettings = {
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('token') }
        };
    }
    public reportUrl: string = '';
    public _Parameters: DynamicReportParameters;
    @Input() set Parameters(value: DynamicReportParameters) {
        this._Parameters = value;
        this._Parameters.Token = sessionStorage.getItem('token');
        this.reportUrl = JSON.stringify(value);
    }
    get Parameters(): DynamicReportParameters {
        return this._Parameters;
    }
    @Output() BeforeSave: EventEmitter<any> = new EventEmitter();
    @Output() OnSave: EventEmitter<any> = new EventEmitter();
    hostUrl: string = environment.apiRoot;
    getDesignerModelAction: string = '/api/DynamicReport/GetReportDesignerModel';

    @ViewChild('dxcomp') dxcomp: DxReportDesignerComponent;
    ReportOpened(event) {
        console.log(event);
        if (this.Parameters.ViewerMode == true) {
            this.previewAction.clickAction();
            if(this.Parameters.Code == null && this.Parameters.DynamicReportRevisionID == null){
                console.warn("Report Code or DynamicReportRevisionID must be filled on the view mode. ");
                return;
            }
        }
        else{
            if(this.Parameters.DynamicReportID == null ){
                console.warn("DynamicReportID must be filled on the design mode.");
                return;
            }
        }
        this.ready = true;
    }
    save() {

        this.BeforeSave.emit();

        var reportJsonModel = this.dxcomp.bindingSender.GetJsonReportModel()
        console.log(reportJsonModel);
        console.log(JSON.stringify(reportJsonModel));

        let dto: ReportRevisionDto = {
            DynamicReport: this.Parameters.DynamicReportID,
            ReportComment: this.Parameters.ReportComment,
            ReportJSONContent: JSON.stringify(reportJsonModel)
        };

        return this.httpService.post<any>("/api/DynamicReport/SaveReportRevision", dto).then(x => {

            this.OnSave.emit(x);
        });
    }
    ngOnInit() {

    }
    PreviewCustomizeMenuActions(event) {
        
        if (this.Parameters.ViewerMode) {
            let designAction = event.args.GetById(DevExpress.Reporting.Viewer.ActionId.Design);
            designAction.visible = false;
            
            if (this.Parameters.DisablePrintButtons) {
                let print1 = event.args.GetById(DevExpress.Reporting.Viewer.ActionId.Print);
                print1.visible = false;
                let print2 = event.args.GetById(DevExpress.Reporting.Viewer.ActionId.PrintPage);
                print2.visible = false;
                let print3 = event.args.GetById(DevExpress.Reporting.Viewer.ActionId.ExportTo);
                print3.visible = false;

            }
        }
    }
    previewAction: any;
    CustomizeMenuActions(event) {

        let saveAction = event.args.GetById(DevExpress.Reporting.Designer.Actions.ActionId.Save);
        saveAction.clickAction = () => {
            this.save();
        }
        this.previewAction = event.args.GetById(DevExpress.Reporting.Designer.Actions.ActionId.Preview);

    }

    public setInputParam(value: DynamicReportParameters) {

        this.Parameters = value;
    }
}

export class DynamicReportParameters {

    public DynamicReportRevisionID?: string;
    public Code?: string;
    public ReportParams?: any;
    public ViewerMode?: boolean;
    public Token?: string;
    public DynamicReportID?: string;
    public ReportComment?: string;
    public DisablePrintButtons?: boolean;

}
export class ReportRevisionDto {
    public ObjectID?: string;
    public ReportComment: string;
    public ReportJSONContent: string;
    public DynamicReport: string;
}