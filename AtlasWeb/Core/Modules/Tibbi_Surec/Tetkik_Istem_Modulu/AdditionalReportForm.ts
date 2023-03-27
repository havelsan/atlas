//$D059F0E4
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AdditionalReportFormViewModel } from './AdditionalReportFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AdditionalReport } from 'NebulaClient/Model/AtlasClientModel';
import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'AdditionalReportForm',
    templateUrl: './AdditionalReportForm.html',
    providers: [MessageService]
})
export class AdditionalReportForm extends BaseAdditionalInfoForm implements OnInit{
    CreationDate: TTVisual.ITTDateTimePicker;
    IsCompleted: TTVisual.ITTCheckBox;
    labelCreationDate: TTVisual.ITTLabel;
    labelReport: TTVisual.ITTLabel;
    Report: TTVisual.ITTRichTextBoxControl;
    public additionalReportFormViewModel: AdditionalReportFormViewModel = new AdditionalReportFormViewModel();
    public get _AdditionalReport(): AdditionalReport {
        return this._TTObject as AdditionalReport;
    }
    private AdditionalReportForm_DocumentUrl: string = '/api/AdditionalReportService/AdditionalReportForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.AdditionalReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AdditionalReport();
        this.additionalReportFormViewModel = new AdditionalReportFormViewModel();
        this._ViewModel = this.additionalReportFormViewModel;
        this.additionalReportFormViewModel._AdditionalReport = this._TTObject as AdditionalReport;
    }

    protected loadViewModel() {
        let that = this;
        that.additionalReportFormViewModel = this._ViewModel as AdditionalReportFormViewModel;
        that._TTObject = this.additionalReportFormViewModel._AdditionalReport;
        if (this.additionalReportFormViewModel == null)
            this.additionalReportFormViewModel = new AdditionalReportFormViewModel();
        if (this.additionalReportFormViewModel._AdditionalReport == null)
            this.additionalReportFormViewModel._AdditionalReport = new AdditionalReport();

    }

    async ngOnInit() {
        let that = this;
        await this.load(AdditionalReportFormViewModel);
    }

    public onCreationDateChanged(event): void {
        if (this._AdditionalReport != null && this._AdditionalReport.CreationDate != event) {
            this._AdditionalReport.CreationDate = event;
        }
    }

    public onIsCompletedChanged(event): void {
        if (this._AdditionalReport != null && this._AdditionalReport.IsCompleted != event) {
            this._AdditionalReport.IsCompleted = event;
        }
    }

    public onReportChanged(event): void {
        if (this._AdditionalReport != null && this._AdditionalReport.Report != event) {
            this._AdditionalReport.Report = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.IsCompleted, "Value", this.__ttObject, "IsCompleted");
        redirectProperty(this.Report, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
    }

    public initFormControls(): void {
        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = "Ekleme Tarihi / Saati";
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 4;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 3;

        this.labelReport = new TTVisual.TTLabel();
        this.labelReport.Text = "Rapor";
        this.labelReport.Name = "labelReport";
        this.labelReport.TabIndex = 2;

        this.Report = new TTVisual.TTRichTextBoxControl();
        this.Report.Name = "Report";
        this.Report.TabIndex = 1;

        this.IsCompleted = new TTVisual.TTCheckBox();
        this.IsCompleted.Value = false;
        this.IsCompleted.Title = "Tamamlandı";
        this.IsCompleted.Name = "IsCompleted";
        this.IsCompleted.TabIndex = 0;

        this.Controls = [this.labelCreationDate, this.CreationDate, this.labelReport, this.Report, this.IsCompleted];

    }

 
}
