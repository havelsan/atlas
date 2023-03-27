//$B0F54848
import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Store, CommisionTypeEnum, SignUserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialSelectViewModel, MaterialTreeItem, MaterialListInputDVO, MaterialItem, MaterialSelectInputDVO, SumAmountMaterialItem } from '../Models/MaterialSelectViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DxDataGridComponent } from 'devextreme-angular';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DatePipe } from '@angular/common';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
import { AtlasObjectCloner } from 'app/NebulaClient/ClassTransformer/AtlasObjectCloner';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { CommisionDefinitionInputDTO, GetCommisionDefinitionByCommisionType_Input } from './LogisticDefinitionComponents/CommisionDefinitionComponent';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
@Component({
    selector: 'commision-select-component',
    providers: [DatePipe],
    template: `
    <div class="container-fluid">
    <div class="row">
        <div style="float:left; width:30%; padding-top: 20px;">
            <dx-list #list
                     [dataSource]="commisions"
                     [width]="200"
                     [height]="200"
                     [searchEnabled]="true"
                     searchExpr="Description"
                     searchMode="contains"
                     (onItemClick)="selectItem($event)">
                <div *dxTemplate="let data of 'item'">
                    <div>{{data.Description}}</div>
                </div>
            </dx-list>
        </div>
        <div style="float:right; width:69%; padding-top: 20px;">
            <div class="row">
                <div class="col-sm-3">
                    Başlangıç Tarihi
                    <dx-date-box [(value)]="selectedCommision.StartDate" [readOnly]="true">
                    </dx-date-box>
                </div>
                <div class="col-sm-3">
                    Bitiş Tarihi
                    <dx-date-box [(value)]="selectedCommision.EndDate" [readOnly]="true">
                    </dx-date-box>
                </div>
                <div class="col-sm-6">
                    Komisyon Tipi
                    <dx-select-box [dataSource]="CommisionTypes" valueExpr="ordinal"
                                   displayExpr="description" [readOnly]="true" [(value)]="selectedCommision.CommisionType">
                    </dx-select-box>
                </div>
            </div>
            <br />
            <dx-data-grid [columns]="CommisionMemberColumns"
                          [dataSource]="selectedCommision.CommisionMembers"
                          [filterRow]="{visible: true}"
                          (onRowClick)="select($event)"
                          [selection]="{mode: 'single',allowSelectAll: false}"
                          style="height: 300px;float:left">
            </dx-data-grid>
        </div>
    </div>
    <br />
    <div class="row">
        <div style="float: left">
            <dx-button type="btn btn-default" text="Ekle" style="width:80px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="btn btn-default" text="Vazgec" style="width:80px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class CommisionSelectComponent implements IModal {
    public commisions: Array<CommisionDefinitionInputDTO> = new Array<CommisionDefinitionInputDTO>();
    public selectedCommision: CommisionDefinitionInputDTO = new CommisionDefinitionInputDTO();
    public commisionType: CommisionTypeEnum;
    private _modalInfo: ModalInfo;
    public CommisionTypes: Array<EnumItem> = CommisionTypeEnum.Items;
    public SignUserTypes: Array<EnumItem> = SignUserTypeEnum.Items;

    @ViewChild('gridSelectedMaterials') dataGrid: DxDataGridComponent;

    public CommisionMemberColumns = [
        {
            caption: "İmza Tipi",
            dataField: 'SignUserType',
            lookup: { dataSource: this.SignUserTypes, valueExpr: 'ordinal', displayExpr: 'description' },
            width: 200,
        },
        {
            'caption': "Personel",
            dataField: 'ResUserName',
            width: 350,
        },
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private datePipe: DatePipe) {
    }

    ngOnInit() {
        this.getCommision();
    }
    public setInputParam(value: any) {
        this.commisionType = value as CommisionTypeEnum;

    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    onAmountChanged(data, row) {
        row.data.Amount = data.value;
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedCommision);
    }

    public async getCommision() {
        if (this.commisionType !== null) {
            let input: GetCommisionDefinitionByCommisionType_Input = new GetCommisionDefinitionByCommisionType_Input();
            input.CommisionType = this.commisionType;
            let fullApiUrl: string = 'api/CommisionDefinition/getCommisionDefinitionByCommisionType';
            await this.http.post<Array<CommisionDefinitionInputDTO>>(fullApiUrl, input)
                .then((res) => {
                    this.commisions = res as Array<CommisionDefinitionInputDTO>;
                });
        }
    }

    selectItem(e) {
        this.selectedCommision = e.itemData;
    }
}