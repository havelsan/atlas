//$0BC26114
import { Component,  OnInit  } from '@angular/core';

import { RadiologyTestAdditionalReportFormViewModel } from './RadiologyTestAdditionalReportFormViewModel';

import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { RadiologyAdditionalReport } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';

@Component({
    selector: 'RadiologyTestAdditionalReportForm',
    templateUrl: './RadiologyTestAdditionalReportForm.html',
    providers: [MessageService]
})
export class RadiologyTestAdditionalReportForm extends TTVisual.TTForm implements OnInit {
    AdditionalReport: TTVisual.ITTRichTextBoxControl;
    AdditionalResults: TTVisual.ITTRichTextBoxControl;
    labelAdditionalReport: TTVisual.ITTLabel;
    labelReportDate: TTVisual.ITTLabel;
    ReportDate: TTVisual.ITTDateTimePicker;
    public radiologyTestAdditionalReportFormViewModel: RadiologyTestAdditionalReportFormViewModel = new RadiologyTestAdditionalReportFormViewModel();
    public get _RadiologyAdditionalReport(): RadiologyAdditionalReport {
        return this._TTObject as RadiologyAdditionalReport;
    }
    private RadiologyTestAdditionalReportForm_DocumentUrl: string = '/api/RadiologyAdditionalReportService/RadiologyTestAdditionalReportForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('RADIOLOGYADDITIONALREPORT', 'RadiologyTestAdditionalReportForm');
        this._DocumentServiceUrl = this.RadiologyTestAdditionalReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyAdditionalReport();
        this.radiologyTestAdditionalReportFormViewModel = new RadiologyTestAdditionalReportFormViewModel();
        this._ViewModel = this.radiologyTestAdditionalReportFormViewModel;
        this.radiologyTestAdditionalReportFormViewModel._RadiologyAdditionalReport = this._TTObject as RadiologyAdditionalReport;
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyTestAdditionalReportFormViewModel = this._ViewModel as RadiologyTestAdditionalReportFormViewModel;
        that._TTObject = this.radiologyTestAdditionalReportFormViewModel._RadiologyAdditionalReport;
        if (this.radiologyTestAdditionalReportFormViewModel == null)
            this.radiologyTestAdditionalReportFormViewModel = new RadiologyTestAdditionalReportFormViewModel();
        if (this.radiologyTestAdditionalReportFormViewModel._RadiologyAdditionalReport == null)
            this.radiologyTestAdditionalReportFormViewModel._RadiologyAdditionalReport = new RadiologyAdditionalReport();

    }

    async ngOnInit() {
        await this.load(RadiologyTestAdditionalReportFormViewModel);
    }
    public setInputParam(value: any) {
        if (value != "")
            this.ObjectID = value as Guid;

    }
    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }
    public onAdditionalReportChanged(event): void {
        if (this._RadiologyAdditionalReport != null && this._RadiologyAdditionalReport.AdditionalReport != event) {
            this._RadiologyAdditionalReport.AdditionalReport = event;
        }
    }

    public onAdditionalResultsChanged(event): void {
        if (this._RadiologyAdditionalReport != null && this._RadiologyAdditionalReport.AdditionalResults != event) {
            this._RadiologyAdditionalReport.AdditionalResults = event;
        }
    }

    public onReportDateChanged(event): void {
        if (this._RadiologyAdditionalReport != null && this._RadiologyAdditionalReport.ReportDate != event) {
            this._RadiologyAdditionalReport.ReportDate = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ReportDate, "Value", this.__ttObject, "ReportDate");
        redirectProperty(this.AdditionalReport, "Rtf", this.__ttObject, "AdditionalReport");
        redirectProperty(this.AdditionalResults, "Rtf", this.__ttObject, "AdditionalResults");
    }

    public initFormControls(): void {
        this.labelReportDate = new TTVisual.TTLabel();
        this.labelReportDate.Text = "Ek Rapor Tarihi";
        this.labelReportDate.Name = "labelReportDate";
        this.labelReportDate.TabIndex = 3;

        this.ReportDate = new TTVisual.TTDateTimePicker();
        this.ReportDate.Format = DateTimePickerFormat.Long;
        this.ReportDate.Name = "ReportDate";
        this.ReportDate.TabIndex = 2;

        this.labelAdditionalReport = new TTVisual.TTLabel();
        this.labelAdditionalReport.Text = "Ek Rapor";
        this.labelAdditionalReport.Name = "labelAdditionalReport";
        this.labelAdditionalReport.TabIndex = 1;

        this.AdditionalReport = new TTVisual.TTRichTextBoxControl();
        this.AdditionalReport.Name = "AdditionalReport";
        this.AdditionalReport.TabIndex = 0;

        this.AdditionalResults = new TTVisual.TTRichTextBoxControl();
        this.AdditionalResults.Name = "AdditionalResults";
        this.AdditionalResults.TabIndex = 0;

        this.Controls = [this.labelReportDate, this.ReportDate, this.labelAdditionalReport, this.AdditionalReport, this.AdditionalResults];

    }


}
