//$74EAA21B
import { Component, OnInit, NgZone } from '@angular/core';
import { PathologyAdditionalReportFormViewModel } from './PathologyAdditionalReportFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PathologyAdditionalReport } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'PathologyAdditionalReportForm',
    templateUrl: './PathologyAdditionalReportForm.html',
    providers: [MessageService]
})
export class PathologyAdditionalReportForm extends TTVisual.TTForm implements OnInit, IModal {
    AdditionalReport: TTVisual.ITTRichTextBoxControl;
    ApproveDate: TTVisual.ITTDateTimePicker;
    labelAdditionalReport: TTVisual.ITTLabel;
    labelApproveDate: TTVisual.ITTLabel;
    labelReportDate: TTVisual.ITTLabel;
    ReportDate: TTVisual.ITTDateTimePicker;
    public pathologyAdditionalReportFormViewModel: PathologyAdditionalReportFormViewModel = new PathologyAdditionalReportFormViewModel();
    public get _PathologyAdditionalReport(): PathologyAdditionalReport {
        return this._TTObject as PathologyAdditionalReport;
    }
    private PathologyAdditionalReportForm_DocumentUrl: string = '/api/PathologyAdditionalReportService/PathologyAdditionalReportForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('PATHOLOGYADDITIONALREPORT', 'PathologyAdditionalReportForm');
        this._DocumentServiceUrl = this.PathologyAdditionalReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PathologyAdditionalReport();
        this.pathologyAdditionalReportFormViewModel = new PathologyAdditionalReportFormViewModel();
        this._ViewModel = this.pathologyAdditionalReportFormViewModel;
        this.pathologyAdditionalReportFormViewModel._PathologyAdditionalReport = this._TTObject as PathologyAdditionalReport;
    }

    protected loadViewModel() {
        let that = this;

        that.pathologyAdditionalReportFormViewModel = this._ViewModel as PathologyAdditionalReportFormViewModel;
        that._TTObject = this.pathologyAdditionalReportFormViewModel._PathologyAdditionalReport;
        if (this.pathologyAdditionalReportFormViewModel == null)
            this.pathologyAdditionalReportFormViewModel = new PathologyAdditionalReportFormViewModel();
        if (this.pathologyAdditionalReportFormViewModel._PathologyAdditionalReport == null)
            this.pathologyAdditionalReportFormViewModel._PathologyAdditionalReport = new PathologyAdditionalReport();

        if (this.pathologyAdditionalReportFormViewModel._PathologyAdditionalReport.CurrentStateDefID == PathologyAdditionalReport.PathologyAdditionalReportStates.Approved) {
            this.ReadOnly = true;

        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(PathologyAdditionalReportFormViewModel);
  
    }


    public onAdditionalReportChanged(event): void {
        if (event != null) {
            if (this._PathologyAdditionalReport != null && this._PathologyAdditionalReport.AdditionalReport != event) {
                this._PathologyAdditionalReport.AdditionalReport = event;
            }
        }
    }

    public onApproveDateChanged(event): void {
        if (event != null) {
            if (this._PathologyAdditionalReport != null && this._PathologyAdditionalReport.ApproveDate != event) {
                this._PathologyAdditionalReport.ApproveDate = event;
            }
        }
    }

    public onReportDateChanged(event): void {
        if (event != null) {
            if (this._PathologyAdditionalReport != null && this._PathologyAdditionalReport.ReportDate != event) {
                this._PathologyAdditionalReport.ReportDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ReportDate, "Value", this.__ttObject, "ReportDate");
        redirectProperty(this.ApproveDate, "Value", this.__ttObject, "ApproveDate");
        redirectProperty(this.AdditionalReport, "Rtf", this.__ttObject, "AdditionalReport");
    }

    public initFormControls(): void {
        this.labelAdditionalReport = new TTVisual.TTLabel();
        this.labelAdditionalReport.Text = i18n("M13524", "Ek Rapor");
        this.labelAdditionalReport.Name = "labelAdditionalReport";
        this.labelAdditionalReport.TabIndex = 5;

        this.AdditionalReport = new TTVisual.TTRichTextBoxControl();
        this.AdditionalReport.Name = "AdditionalReport";
        this.AdditionalReport.TabIndex = 4;

        this.labelReportDate = new TTVisual.TTLabel();
        this.labelReportDate.Text = i18n("M13526", "Ek Rapor Tarihi");
        this.labelReportDate.Name = "labelReportDate";
        this.labelReportDate.TabIndex = 3;

        this.ReportDate = new TTVisual.TTDateTimePicker();
        this.ReportDate.Format = DateTimePickerFormat.Long;
        this.ReportDate.Name = "ReportDate";
        this.ReportDate.TabIndex = 2;
        this.ReportDate.Enabled = false;
        this.ReportDate.BackColor = "#F0F0F0";

        this.labelApproveDate = new TTVisual.TTLabel();
        this.labelApproveDate.Text = i18n("M13525", "Ek Rapor Onay Tarihi");
        this.labelApproveDate.Name = "labelApproveDate";
        this.labelApproveDate.TabIndex = 1;

        this.ApproveDate = new TTVisual.TTDateTimePicker();
        this.ApproveDate.Format = DateTimePickerFormat.Long;
        this.ApproveDate.Name = "ApproveDate";
        this.ApproveDate.TabIndex = 0;
        this.ApproveDate.Enabled = false;
        this.ApproveDate.BackColor = "#F0F0F0";

        this.Controls = [this.labelAdditionalReport, this.AdditionalReport, this.labelReportDate, this.ReportDate, this.labelApproveDate, this.ApproveDate];

    }

    public setInputParam(value: any) {
        if (value != "")
            this.ObjectID = value as Guid;

    }
    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

}
