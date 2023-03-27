import { Component, Input, OnInit, SimpleChange } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

@Component({
    selector: 'atlas-editor-template-list',
    template: `<dx-box direction="col" width="100%" [height]="'420px'">
    <dxi-item [ratio]="1">
        <h4 style='margin: 0px'>{{TemplateGroupName}}</h4>
    </dxi-item>
    <dxi-item [ratio]="8">
        <dx-data-grid [height]='300' [dataSource]="EditorTemplateList" (onSelectionChanged)="selectionChanged($event)"
         (onRowClick)="rowClick($event)" >
            <dxi-column dataField="MenuCaption" dataType="string" caption="Şablon Adı"></dxi-column>
            <dxo-selection mode="single"></dxo-selection>
            <dxo-load-panel [enabled]="true"></dxo-load-panel>
            <dxo-scrolling mode="virtual"></dxo-scrolling>
            <dxo-filter-row [visible]="showFilterRow" [applyFilter]="'auto'"></dxo-filter-row>
            <dxo-header-filter [visible]="showHeaderFilter"></dxo-header-filter>
            <dxo-search-panel [visible]="showSearchPanel" [width]="240" placeholder="Aranacak terim..."></dxo-search-panel>
        </dx-data-grid>
    </dxi-item>
    <dxi-item [ratio]="1">
        <dx-box direction="row" width="100%" [height]="25">
            <dxi-item [ratio]="30"></dxi-item>
            <dxi-item [ratio]="10">
            <div  [hidden]="!showDelete" >
            <dx-button type="danger" text="Sil" (onClick)="disable()" style="width:100%"></dx-button>
            </div>
            </dxi-item>
            <dxi-item [ratio]="10">
                <dx-button type="default" text="İptal" (onClick)="cancelClick()"></dx-button>
            </dxi-item>
            <dxi-item [ratio]="10">
                <dx-button type="success" text="Seç" (onClick)="selectClick()"></dx-button>
            </dxi-item>
        </dx-box>
    </dxi-item>
</dx-box>
`
})
export class AtlasEditorTemplateList implements OnInit, IModal {


    private _templateGroupName: string;
    @Input() set TemplateGroupName(value: string) {
        this._templateGroupName = value;
    }
    get TemplateGroupName(): string {
        return this._templateGroupName;
    }

    public EditorTemplateList: Array<any>;
    public selectedRowsData: Array<any> = [];
    private clickTimer: any;
    private lastRowCLickedId: any;
    public showHeaderFilter = true;
    public showFilterRow = true;
    public showSearchPanel = false;
    public showDelete = false;

    public gridColumns: Array<any> = [''];

    constructor(private http: NeHttpService
        , private modalStateService: ModalStateService
        , private messageService: MessageService) {
    }


    public setInputParam(value: Object) {
        if (typeof value === "string") {
            this.TemplateGroupName = value.toString();
        }
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    private loadTemplateList(templateGroupName: string): void {
        let that = this;
        const templateUrl = `/api/EditorTemplate/GetEditorTemplates`;
        const input = { TemplateGroupName: templateGroupName };
        this.http.post(templateUrl, input).then(result => {
            that.EditorTemplateList = result as Array<any>;
            this.showDelete = false;
        }).catch(err => {
            that.messageService.showError(err);
        });
    }

    ngOnInit() {
        this.loadTemplateList(this._templateGroupName);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        /* if (changes.hasOwnProperty('TemplateGroupName')) {
             const templateGroupName = changes['TemplateGroupName'].currentValue;
             this.loadTemplateList(templateGroupName);
         } */
    }

    selectClick() {
        if (this._modalInfo != null) {
            let result: any = {};
            const obj = this.selectedRowsData[0];
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, obj);
        }
    }

    cancelClick() {
        if (this._modalInfo != null) {
            this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, null);
        }
    }

    selectionChanged(event: any) {
        this.selectedRowsData = [];
        if (event && event.selectedRowsData) {
            this.selectedRowsData = event.selectedRowsData;
        }
    }

    rowClick(event: any) {
        if (this.clickTimer && this.lastRowCLickedId === event.rowIndex) {
            clearTimeout(this.clickTimer);
            this.clickTimer = null;
            this.lastRowCLickedId = event.rowIndex;
            this.selectClick();
        } else {
            this.clickTimer = setTimeout(Function.prototype, 250);
        }
        this.lastRowCLickedId = event.rowIndex;

        this.showDelete = true;
    }

    disable() {
        
        this.http.get<Boolean>("/api/EditorTemplate/SetEnableDisable?objectID=" + this.EditorTemplateList[this.lastRowCLickedId].ObjectID + "&enable=false").then(x => {
            this.loadTemplateList(this._templateGroupName);
            
        });
    }
}