import { Component, Input, OnInit, OnDestroy, OnChanges, SimpleChange, ViewChild, Output, EventEmitter } from '@angular/core';
import { ReportDefinition } from '../Models/ReportDefinition';
import { AtlasReportService } from '../Services/AtlasReportService';
import { AtlasFormFieldConfig } from '../../DynamicForm/Models/AtlasFormFieldConfig';
import { AtlasDynamicFormComponent } from '../../DynamicForm/Views/AtlasDynamicFormComponent';
import { Subscription } from 'rxjs';
import { ReportExportTargetType } from 'NebulaClient/Utils/Enums/ReportExportTargetType';
import { EnumItem } from 'NebulaClient/Mscorlib/EnumItem';
import { MessageService } from 'Fw/Services/MessageService';


@Component({

    selector: 'atlas-report-component',
    template: `
    <div *ngIf="CommandPanelVisible">
        <dx-button type="btn btn-default" style="margin: 0px 0px 5px 0px" [text]="'Rapor Oluştur'" (click)="renderReport()"></dx-button>
        <dx-select-box [items]="exportEnumList" displayExpr="name" valueExpr="code" [showClearButton]="true" [(value)]="exportFormatType">
        </dx-select-box>
    <div>
    <h4>{{reportDefinition?.Caption}}</h4>
    <div>
      <atlas-dynamic-form
        [config]="config"
        #atlasDynamicForm>
      </atlas-dynamic-form>
    </div>
    `,
    providers: [MessageService]
})
export class AtlasReportComponent implements OnInit, OnChanges, OnDestroy {
    @ViewChild('atlasDynamicForm') formInstance: AtlasDynamicFormComponent;

    private formChangesSubscription: Subscription;

    @Input() CommandPanelVisible: boolean = true;

    private _reportDefName?: string;
    @Input() set ReportDefName(value: string) {
        this._reportDefName = value;
    }
    get ReportDefName(): string {
        return this._reportDefName;
    }

    private _ttObjectID?: string;
    @Input() set TTObjectID(value: string) {
        this._ttObjectID = value;
    }
    get TTObjectID(): string {
        return this._ttObjectID;
    }

    @Output() ReportPrinted: EventEmitter<any> = new EventEmitter<any>();
    @Output() CriteriaChanged: EventEmitter<any> = new EventEmitter<any>();
    @Output() ReportDefinitionLoaded: EventEmitter<ReportDefinition> = new EventEmitter<ReportDefinition>();
    @Output() ParameterConfigInitialized: EventEmitter<Array<AtlasFormFieldConfig>> = new EventEmitter<Array<AtlasFormFieldConfig>>();

    public config: AtlasFormFieldConfig[] = [

    ];

    public reportDefinition: ReportDefinition;

    public exportFormatType: ReportExportTargetType;
    private exportEnumList: Array<EnumItem>;

    constructor(private reportService: AtlasReportService, protected messageService: MessageService) {
        this.exportFormatType = ReportExportTargetType.Pdf;
    }

    private loadReportDefinition(): void {
        const that = this;
        this.reportService.getReportDefinition(this.ReportDefName).then(repDef => {
            that.reportDefinition = repDef;
            that.ReportDefinitionLoaded.emit(repDef);
            that.config = that.reportService.buildReportParameterFormConfig(that.reportDefinition, this.TTObjectID);
            that.ParameterConfigInitialized.emit(that.config);
        }).catch(err => {
            that.messageService.showError(err);
        });
    }

    ngOnInit() {
        this.exportEnumList = ReportExportTargetType.Items;
    }

    ngOnDestroy() {
        if (this.formChangesSubscription != null) {
            this.formChangesSubscription.unsubscribe();
            this.formChangesSubscription = null;
        }
    }

    ngAfterViewInit() {
        if (this.formInstance) {
            let previousValid = this.formInstance.valid;
            this.formChangesSubscription = this.formInstance.changes.subscribe(() => {
                if (this.formInstance.valid !== previousValid) {
                    previousValid = this.formInstance.valid;
                    this.formInstance.setDisabled('submit', !previousValid);
                }
            });
        }
    }

    ngOnChanges(changes: { [ReportDefName: string]: SimpleChange }) {
        const reportDefName = changes['ReportDefName'].currentValue;
        if (reportDefName != null && reportDefName !== '') {
            this.loadReportDefinition();
        } else {
            this.config = [];
            this.reportDefinition = null;
        }
    }

    public renderReport(): void {
        const that = this;
        if (this.reportDefinition == null)
            return;
        if (this.formInstance.valid === false) {
            this.messageService.showInfo('Lütfen gerekli alanları doldurunuz');
            return;
        }
        const parameters = this.reportService.buildReportParameters(this.reportDefinition, this.formInstance.value, this.TTObjectID);
        this.reportService.renderReport(this.ReportDefName, this.exportFormatType, parameters).then(res => {
            const fileURL = URL.createObjectURL(res);
            window.open(fileURL);
            that.ReportPrinted.emit();
        }).catch(err => {
            that.messageService.showError(err);
        });
    }
}