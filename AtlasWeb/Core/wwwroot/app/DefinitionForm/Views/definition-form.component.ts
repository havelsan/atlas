//$741875C0
import { Component, OnInit, ComponentRef, Input, ViewChild, Type, Inject } from '@angular/core';
import { Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { TTBoundFormBase } from 'NebulaClient/Visual/TTBoundFormBase';
import { TTFormBase } from 'NebulaClient/Visual/TTFormBase';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { GridQueryResult } from "../../QueryList/Models/GridQueryResult";
import { SystemApiService } from "Fw/Services/SystemApiService";
import { MessageService } from "Fw/Services/MessageService";
import { DxDataGridComponent } from "devextreme-angular";
import { AtlasHttpService } from "Fw/Services/AtlasHttpService";
import { CommonHelper } from "app/Helper/CommonHelper";
import { IModalService } from "Fw/Services/IModalService";
import { ModalInfo } from "Fw/Models/ModalInfo";
import { ImportDefinitionComponent } from "./import-definition.component";
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";

const objectIDPropertyName = 'ObjectID';

@Component({
    selector: 'atlas-definition-form',
    template: `
<div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-lg-6">
            <div class="row">
                <div class="col-lg-2">
                    <dx-button type="success" style="width: 100%; margin: 0px 5px 0px 0px" text="Yeni [F2]" (onClick)="onNewRecord()"></dx-button>
                </div>
                <div class="col-lg-2">
                    <dx-button type="danger" style="width: 100%; margin: 0px 5px 0px 0px" text="Sil" (onClick)="onDeleteRecord(grid)"></dx-button>
                </div>
                <div class="col-lg-2">
                    <dx-button type="success" style="width: 100%; margin: 0px 5px 0px 0px" text="İçeriye Al" (onClick)="onImportRecord()"></dx-button>
                </div>
                <div class="col-lg-2">
                    <dx-button type="success" style="width: 100%; margin: 0px 5px 0px 0px" text="Dışarıya Çıkart" (onClick)="onExportRecord()"></dx-button>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="row">
                <div class="col-lg-2">
                </div>
                <div class="col-lg-2">
                </div>
                <div class="col-lg-2">
                </div>
                <div class="col-lg-2">
                </div>
                <div class="col-lg-2">
                    <dx-button type="success" style="width: 100%; margin: 0px 5px 0px 0px" text="Kaydet [F12]" (onClick)="onSaveChanges()"></dx-button>
                </div>
                <div class="col-lg-2">
                    <dx-button type="success" style="width: 100%; margin: 0px 5px 0px 0px" text="Vazgeç"></dx-button>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="margin-bottom:5px">
        <comp-compose #dynComp [Info]="componentInfo" (ComponentCreated)="onComponentCreated($event)"
        (DynamicComponentActionExecuted)="dynamicComponentActionExecuted($event)"></comp-compose>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <dx-data-grid #grid id="gridContainer" height="400px" [hoverStateEnabled]="true" [showColumnLines]="true" [showRowLines]="true"
                [showBorders]="true" [rowAlternationEnabled]="true" (onSelectionChanged)="onSelectionChanged($event)" [dataSource]="gridDataSource"
                [columns]="gridColumns">
                <dxo-selection mode="single"></dxo-selection>
                <dxo-header-filter [visible]="true"></dxo-header-filter>
                <dxo-paging [pageSize]="10"></dxo-paging>
                <dxo-pager [showPageSizeSelector]="true" [allowedPageSizes]="[10, 20, 30, 40, 50]" [showInfo]="true">
                </dxo-pager>
            </dx-data-grid>
        </div>
    </div>
</div>
    `,
    providers: [SystemApiService]
})
export class DefinitionFormComponent implements OnInit {

    public gridDataSource: Array<any> = new Array<any>();
    public gridColumns: any;
    public componentInfo: DynamicComponentInfo;
    private editorFormInstance: any;
    private selectedRowData: any;
    private newRecordMode: boolean = false;

    @Input() FormDefId: string;
    @Input() ObjectDefName: string;

    @ViewChild('grid') dataGrid: DxDataGridComponent;

    constructor(private http: NeHttpService
        , private systemApi: SystemApiService
        , private messageService: MessageService
        , private http2: AtlasHttpService
        , private modalService: IModalService
        , @Inject('ImportDefinitionComponent') private importDefinitionComponent: Type<ImportDefinitionComponent>) {
    }

    private getDefinitionResult(formDefID: string): Promise<GridQueryResult> {
        const url = `/api/list/GetDefinitionObjectList?formDefID=${formDefID}`;
        return this.http.get<GridQueryResult>(url);
    }

    private deleteDefinitionObject(input: any): Promise<any> {
        const url = `/api/ObjectDef/DeleteDefinitionObject`;
        return this.http.post(url, input);
    }

    private exportObjectToFile(input: any): Promise<void> {
        const url: string = '/api/DefinitionObject/ExportDefinitionObject';
        let headers = new Headers();
        headers.set('Content-Type', 'application/json');
        let options = new RequestOptions();
        options.headers = headers;
        options.responseType = ResponseContentType.Blob;
        const exportFileName = `${input.ObjectDefName}_${input.ObjectID}`;
        return this.http2.post(url, JSON.stringify(input), options).toPromise().then(
            (res) => {
                CommonHelper.saveFile(res.blob(), exportFileName);
            });
    }

    private isEditorModified(): boolean {

        if (this.editorFormInstance instanceof TTBoundFormBase) {
            let boundFormBase = this.editorFormInstance as TTBoundFormBase;
            return boundFormBase.isModified();
        }
        return false;
    }

    private loadEditRecord(objectID: Guid): void {
        if (this.editorFormInstance instanceof TTFormBase) {
            const formBase = this.editorFormInstance as TTFormBase;
            formBase.ObjectID = objectID;
            if (this.editorFormInstance instanceof TTBoundFormBase) {
                let boundFormBase = this.editorFormInstance as TTBoundFormBase;
                (<any>boundFormBase).load();
            }
        }
    }

    private setEditorFormItem(selectedItem: any): void {
        if (!selectedItem) {
            this.loadEditRecord(Guid.empty());
            return;
        }

        if (!this.editorFormInstance)
            return;

        if (this.editorFormInstance instanceof TTFormBase) {
            const formBase = this.editorFormInstance as TTFormBase;
            let objectID = selectedItem[objectIDPropertyName];
            let objectIDGuid: Guid;
            if (objectID instanceof Guid) {
                objectIDGuid = objectID as Guid;
            } else if ((typeof objectID) === 'string') {
                objectIDGuid = new Guid(objectID as string);
            }
            this.loadEditRecord(objectIDGuid);
        }
    }

    public ngOnInit(): void {
        const that = this;
        this.systemApi.new(that.ObjectDefName, null, that.FormDefId, null).then(res => {
            that.componentInfo = res;
        });

        this.getDefinitionResult(that.FormDefId).then(result => {
            if (result && result.QueryResult) {
                that.gridDataSource = result.QueryResult;
                let gridColumns = result.QueryColumns.map(c => {
                    let dataColumnInfo: any = {};
                    dataColumnInfo.dataField = c.DataField;
                    dataColumnInfo.dataType = c.DataType;
                    dataColumnInfo.caption = c.Caption;
                    dataColumnInfo.alignment = c.Alignment;
                    dataColumnInfo.visible = c.Visible;
                    dataColumnInfo.visibleIndex = c.VisibleIndex;
                    dataColumnInfo.width = c.Width;
                    return dataColumnInfo;
                });
                that.gridColumns = gridColumns;
            }
        });
    }

    public onSelectionChanged(e: any) {
        if (!e && !e.selectedRowsData) {
            return;
        }
        if (e.selectedRowsData instanceof Array) {
            let rowDataArray = e.selectedRowsData as Array<any>;
            if (rowDataArray.length > 0) {
                const selectedRowData = rowDataArray[0];

                if (this.selectedRowData) {
                    const selectedObjectID = this.selectedRowData[objectIDPropertyName];
                    const objectID = selectedRowData[objectIDPropertyName];
                    if (selectedObjectID.toString() === objectID.toString()) {
                        return;
                    }
                }

                if (this.isEditorModified() === true) {
                    const result = confirm('Değişiklikler kaydedilmemiş. Yine de devem etmek istiyor musunuz?');
                    if (result === false) {
                        if (e.currentSelectedRowKeys.length) {
                            e.component.deselectRows(e.currentSelectedRowKeys);
                            e.currentSelectedRowKeys.splice(0, e.currentSelectedRowKeys.length);
                            if (this.selectedRowData) {
                                e.component.selectRows([this.selectedRowData]);
                            }
                        }
                        return;
                    }
                }


                this.selectedRowData = selectedRowData;
                this.setEditorFormItem(selectedRowData);
            }
        }

    }

    public onComponentCreated(compRef: ComponentRef<any>) {
        this.editorFormInstance = compRef.instance;
    }

    public onNewRecord(): void {
        const that = this;
        this.systemApi.new(this.ObjectDefName).then(result => {
            that.selectedRowData = result;
            that.setEditorFormItem(result);
            that.newRecordMode = true;
        });
    }

    public onImportRecord(): void {
        const componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'ImportDefinitionComponent';
        componentInfo.ModuleName = 'DefinitionFormModule';
        componentInfo.ModulePath = 'app/DefinitionForm/definition-form.module';

        const modalInfo = new ModalInfo();
        modalInfo.Title = "Tanım nesnesi içe aktarım";
        modalInfo.Height = 250;
        modalInfo.Width = 500;

        this.modalService.create(componentInfo, modalInfo).then(result => {

        });
    }

    public onExportRecord(): void {
        if (!this.selectedRowData) {
            this.messageService.showInfo('Lütfen dışarıya aktarılacak kaydı seçiniz');
            return;
        }

        const confirmResult = confirm('Seçilen kayıt dışarıya aktarılacak. Devam etmek istiyor musunuz?');
        if (confirmResult === false) {
            return;
        }

        const that = this;
        const objectID = this.selectedRowData[objectIDPropertyName];
        const input = { ObjectDefName: this.ObjectDefName, ObjectID: objectID.toString() };
        this.exportObjectToFile(input).then(result => {
            that.messageService.showInfo('Kayıt başarılı olarak dışarıya aktarıldı');
        });
    }

    public onDeleteRecord(grid: DxDataGridComponent): void {
        if (!this.selectedRowData) {
            this.messageService.showInfo('Lütfen silinecek kaydı seçiniz');
            return;
        }

        const confirmResult = confirm('Seçilen kayıt silinecek. Devam etmek istiyor musunuz?');
        if (confirmResult === false) {
            return;
        }

        const that = this;
        const objectID = this.selectedRowData[objectIDPropertyName];
        const input = { ObjectDefName: this.ObjectDefName, ObjectID: objectID };
        this.deleteDefinitionObject(input).then(result => {
            that.messageService.showInfo('Kayıt başarılı olarak silindi');
            const targetItemIndex = that.gridDataSource.findIndex(x => x[objectIDPropertyName] == objectID);
            if (targetItemIndex) {
                that.gridDataSource.splice(targetItemIndex, 1);
                that.setEditorFormItem(null);
            }
            setTimeout(() => {
                if (grid && grid.instance) {
                    grid.instance.refresh();
                }
            }, 500);
        });

    }

    public onSaveChanges(): void {
        const that = this;
        if (this.editorFormInstance instanceof TTBoundFormBase) {
            let boundFormBase = this.editorFormInstance as TTBoundFormBase;
            const saveInfo = new FormSaveInfo(that.ObjectDefName, false);
            boundFormBase.saveForm(saveInfo).then(result => {
                that.newRecordMode = true;
            });
        }
    }

    public dynamicComponentActionExecuted(eventParam: any): void {
        const that = this;
        if (eventParam.hasOwnProperty('IsSave') == false)
            return;

        let dynamicComponentSaved = eventParam['IsSave'] as boolean;
        if (dynamicComponentSaved === true) {
            if (this.editorFormInstance instanceof TTBoundFormBase) {
                let boundFormBase = this.editorFormInstance as TTBoundFormBase;
                const ttObject = boundFormBase['__ttObject'];
                if (this.newRecordMode) {
                    this.gridDataSource.push(ttObject);
                    this.newRecordMode = false;
                } else {
                    // transfer fields to grid row from editor viewmodel
                    Object.assign(this.selectedRowData, ttObject);
                }

                setTimeout(() => {
                    if (that.dataGrid.instance) {
                        that.dataGrid.instance.refresh();
                    }
                }, 500);
            }
        }

    }
    ///// class
}