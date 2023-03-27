import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { AtlasFormFieldConfig } from '../../DynamicForm/Models/AtlasFormFieldConfig';
import { ReportDefinition } from '../Models/ReportDefinition';
import { AtlasReportService } from '../Services/AtlasReportService';
import { AtlasDynamicFormComponent } from '../../DynamicForm/Views/AtlasDynamicFormComponent';

@Component({
    selector: 'atlas-modal-report-component',
    template: `
<dx-box direction="col" width="100%" [height]="'420px'">
    <dxi-item [ratio]="1">
        <h4 style='margin: 0px'>{{this.reportCaption}}</h4>
    </dxi-item>
    <dxi-item [ratio]="8">
        <atlas-dynamic-form [config]="config" #atlasDynamicForm></atlas-dynamic-form>
    </dxi-item>
    <dxi-item [ratio]="1">
        <dx-box direction="row" width="100%" [height]="25">
            <dxi-item [ratio]="40"></dxi-item>
            <dxi-item [ratio]="10">
                <dx-button type="danger" text="İptal" (onClick)="cancelClick()"></dx-button>
            </dxi-item>
            <dxi-item [ratio]="10">
                <dx-button type="default" text="Tamam" (onClick)="okClick()"></dx-button>
            </dxi-item>
        </dx-box>
    </dxi-item>
</dx-box>
`
})
export class AtlasModalReportComponent implements OnInit, IModal {

    private _reportDefName: string;
    @Input() set ReportDefName(value: string) {
        this._reportDefName = value;
    }
    get ReportDefName(): string {
        return this._reportDefName;
    }

    public config: AtlasFormFieldConfig[] = [];

    public reportDefinition: ReportDefinition;
    public reportCaption : string;

    @ViewChild('atlasDynamicForm') form: AtlasDynamicFormComponent;

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    private _inputParam: Object;
    public setInputParam(value: Object) {
        this._inputParam = value;

        if (typeof value === 'string') {
            const reportDefName = value as string;
            this.ReportDefName = reportDefName;
            let that = this;
            this.reportService.getReportDefinition(this.ReportDefName).then(repDef => {
                that.reportDefinition = repDef;
                that.reportCaption = repDef.Caption;
                that.config = that.reportService.buildReportParameterFormConfig(that.reportDefinition);
            });
        }
    }

    constructor(private modalStateService: ModalStateService,
        private reportService: AtlasReportService) {
    }

    ngOnInit() {
    }

    cancelClick() {
        if (this._modalInfo != null) {
            this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, null);
        }

    }

    okClick() {
        if (this._modalInfo != null) {
            const reportParameters = this.reportService.buildReportParameters(this.reportDefinition, this.form.value);
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, reportParameters);
        }

    }

}