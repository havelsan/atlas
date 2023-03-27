import { Component, Input, OnInit, OnDestroy, ViewChild, Output, EventEmitter } from '@angular/core';
import { ReportDefinition } from '../Models/ReportDefinition';
import { AtlasReportService } from '../Services/AtlasReportService';
import { AtlasFormFieldConfig } from '../../DynamicForm/Models/AtlasFormFieldConfig';
import { AtlasDynamicFormComponent } from '../../DynamicForm/Views/AtlasDynamicFormComponent';
import { Subscription } from 'rxjs';
import { MessageService } from 'Fw/Services/MessageService';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';


@Component({

    selector: 'atlas-report-component-new',
    template: `
    <h5 style="font-weight:bold; text-align:center">Raporlar</h5>
    <div *ngIf="CommandPanelVisible">
        <dx-select-box [items]="ReportDefList" (onSelectionChanged)="loadReportDefinition($event)" displayExpr="Caption" valueExpr="Name" [showClearButton]="true" [(value)]="exportFormatType">
        </dx-select-box>
    <div>
    <div>
      <atlas-dynamic-form
        [config]="config"
        #atlasDynamicForm>
      </atlas-dynamic-form>
    </div>
    <div style="padding-top:10px; text-align:center" class="col-sm-4 col-sm-offset-4">
        <dx-button type="btn btn-default" style="margin: 0px 0px 5px 0px" [text]="'Rapor Oluştur'" (click)="printReport()"></dx-button>
    </div>
    `,
    providers: [MessageService]
})
export class AtlasReportComponentNew implements OnInit, OnDestroy {
    @ViewChild('atlasDynamicForm') formInstance: AtlasDynamicFormComponent;

    private formChangesSubscription: Subscription;

    @Input() CommandPanelVisible: boolean = true;

    private _reportDefList?: Array<ReportDefinition>;
    @Input() set ReportDefList(value: Array<ReportDefinition>) {
        this._reportDefList = value;
    }
    get ReportDefList(): Array<ReportDefinition> {
        return this._reportDefList;
    }

    private _reportDefName?: string;
    @Input() set ReportDefName(value: string) {
        this._reportDefName = value;
    }
    get ReportDefName(): string {
        return this._reportDefName;
    }

    @Output() ReportPrinted: EventEmitter<any> = new EventEmitter<any>();
    @Output() CriteriaChanged: EventEmitter<any> = new EventEmitter<any>();
    @Output() ReportDefinitionLoaded: EventEmitter<ReportDefinition> = new EventEmitter<ReportDefinition>();
    @Output() ParameterConfigInitialized: EventEmitter<Array<AtlasFormFieldConfig>> = new EventEmitter<Array<AtlasFormFieldConfig>>();

    public config: AtlasFormFieldConfig[] = [

    ];

    public reportDefinition: ReportDefinition;

    public exportFormatType: string;

    constructor(private reportService: AtlasReportService, protected messageService: MessageService, protected modalService: IModalService) {

    }

    private loadReportDefinition(event: any): void {
        console.log(event);
        const that = this;
        if (event.selectedItem != null) {
            let selectedReportDef = this.ReportDefList.find(x => x.Name === event.selectedItem.Name);
            if (selectedReportDef != null) {
                that.reportDefinition = selectedReportDef;
                that.ReportDefinitionLoaded.emit(selectedReportDef);
                that.config = that.reportService.buildReportParameterFormConfig(that.reportDefinition);
                that.ParameterConfigInitialized.emit(that.config);
            }
        }
        else {
            this.config = [];
            this.reportDefinition = null;
        }
    }

    ngOnInit() {

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

    public printReport() {

        if (this.reportDefinition == null)
            return;
        if (this.formInstance.valid === false) {
            this.messageService.showInfo('Lütfen gerekli alanları doldurunuz');
            return;
        }

        let res = {};
        this.reportDefinition.Parameters.List.forEach(x => {
            let value = this.reportService.getReportParam(this.formInstance.value, x);
            res[x.Name] = (<any>value).paramValue;
        });

        let data: DynamicReportParameters = {
            Code: this.reportDefinition.Name,
            ReportParams: res,
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = this.reportDefinition.Caption

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
}