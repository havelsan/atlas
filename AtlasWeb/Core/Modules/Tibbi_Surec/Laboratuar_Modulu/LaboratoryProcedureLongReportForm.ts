//$8018EA5E
import { Component, OnInit, NgZone } from '@angular/core';
import { LaboratoryProcedureLongReportFormViewModel } from './LaboratoryProcedureLongReportFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'LaboratoryProcedureLongReportForm',
    templateUrl: './LaboratoryProcedureLongReportForm.html',
    providers: [MessageService]
})
export class LaboratoryProcedureLongReportForm extends TTVisual.TTForm implements OnInit {
    rtfLongReport: TTVisual.ITTRichTextBoxControl;
    public laboratoryProcedureLongReportFormViewModel: LaboratoryProcedureLongReportFormViewModel = new LaboratoryProcedureLongReportFormViewModel();
    public get _LaboratoryProcedure(): LaboratoryProcedure {
        return this._TTObject as LaboratoryProcedure;
    }
    private LaboratoryProcedureLongReportForm_DocumentUrl: string = '/api/LaboratoryProcedureService/LaboratoryProcedureLongReportForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('LABORATORYPROCEDURE', 'LaboratoryProcedureLongReportForm');
        this._DocumentServiceUrl = this.LaboratoryProcedureLongReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PreScript() {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LaboratoryProcedure();
        this.laboratoryProcedureLongReportFormViewModel = new LaboratoryProcedureLongReportFormViewModel();
        this._ViewModel = this.laboratoryProcedureLongReportFormViewModel;
        this.laboratoryProcedureLongReportFormViewModel._LaboratoryProcedure = this._TTObject as LaboratoryProcedure;
    }

    protected loadViewModel() {
        let that = this;

        that.laboratoryProcedureLongReportFormViewModel = this._ViewModel as LaboratoryProcedureLongReportFormViewModel;
        that._TTObject = this.laboratoryProcedureLongReportFormViewModel._LaboratoryProcedure;
        if (this.laboratoryProcedureLongReportFormViewModel == null)
            this.laboratoryProcedureLongReportFormViewModel = new LaboratoryProcedureLongReportFormViewModel();
        if (this.laboratoryProcedureLongReportFormViewModel._LaboratoryProcedure == null)
            this.laboratoryProcedureLongReportFormViewModel._LaboratoryProcedure = new LaboratoryProcedure();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(LaboratoryProcedureLongReportFormViewModel);
  
    }


    public onrtfLongReportChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.LongReport != event) {
                this._LaboratoryProcedure.LongReport = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.rtfLongReport, "Rtf", this.__ttObject, "LongReport");
    }

    public initFormControls(): void {
        this.rtfLongReport = new TTVisual.TTRichTextBoxControl();
        this.rtfLongReport.Name = "rtfLongReport";
        this.rtfLongReport.TabIndex = 0;

        this.Controls = [this.rtfLongReport];

    }


}
