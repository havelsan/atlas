import { Component, ViewChild } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { CommisionTypeEnum, SignUserTypeEnum, ResUser } from 'app/NebulaClient/Model/AtlasClientModel';
import { LogDataSource } from 'Modules/Core_Destek_Modulleri/Log_Modulu/AuditQueryFormViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
//import { ControlOfDefinitionRole } from '../Models/MainViewModel';
import { IAuditObjectService, AuditObject } from 'app/Fw/Services/IAuditObjectService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { Type } from 'NebulaClient/ClassTransformer';
import { ControlOfDefinitionRole } from 'app/Logistic/Models/MainViewModel';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { DxDataGridComponent } from 'devextreme-angular';
@Component({
    selector: 'commisiondefinition-component',
    template: ` 
    <div class="{{this.collapseSelectedDivProperties()}}" style="height: 100%;" id="A16462">
    <div class="row" style="height: 100%;">
        <div class="col-sm-12 gradientPanel" id="A16463">
            <h4 style="color:#fff; font-size:19px;text-align:left;" id="A16464">
                <div class="btn collapseBtn" (click)="btnCollapse()"
                     style="padding:0;margin-top:3px;margin-right: 5px;" id="A16465">
                    <i class="{{this.collapseIconProperties()}}" id="A16466"></i>
                </div>
                <span i18n="@@M16766" id="A16467">Komisyon Listesi</span>
            </h4>
        </div>
        <div class="panel-body" style="background-color:#f6f6f6;padding-bottom:0; height:100%;padding: 0">
            <div class="col-md-12" style="padding: 2px;height: calc(100% - 127px);" id="A10249">
                <dx-data-grid #grid [dataSource]="commisionDefinitionSource" style="height: 650px;" [columns]="commissionDefinitionDataColumn"
                              [filterRow]="{visible: true}" [paging]="{pageSize:34}"
                              (onSelectionChanged)="selectionGridEvent($event)"
                              [showBorders]="true">
                    <dxo-selection mode="single"></dxo-selection>
                </dx-data-grid>
            </div>
            <br />
            <div class="col-md-12" style="max-height: 111px;">
                <div class="row">
                    <div class="col-sm-6">
                        <dx-button icon="fas fa-plus" style="float: left;" stylingMode="contained" text="Yeni" type="default" [width]="120" (onClick)="addNew()">
                        </dx-button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="{{this.collapseSelectedHiddenDivProperties()}}" style="position:relative;" id="A16544">
    <div class="MyVerticalText" (click)="btnCollapse()" id="A16545">
        <i class="{{this.collapseIconProperties()}}" id="A16546"></i>
        <span i18n="@@M16766">&nbsp;&nbsp;&nbsp;&nbsp;Komisyon Listesi</span>
    </div>
</div>

<div class="col-sm-8" style="padding-top: 1%;padding-left: 2% !important;">
    <div id="detail" *ngIf="selectedItemFromOpen">
        <div class="row">
            <dx-button icon="fa fa-times" style="float: right;" stylingMode="contained" text="Vazgeç" type="danger" [width]="120" (onClick)="Cancel()">
            </dx-button>
            <dx-button icon="fas fa-save" style="float: right;" stylingMode="contained" text="Kaydet" type="success" [width]="120" (onClick)="Save()">
            </dx-button>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-sm-3" style="font-weight: bold;">
                Ekleyen Kullanıcı
                <dx-text-box [readOnly]="true" [(value)]="creationUser"></dx-text-box>
            </div>
            <div class="col-sm-3" style="font-weight: bold;">
                Eklenme Tarihi
                <dx-date-box style="width: 100%;" [readOnly]="true" [(value)]="creationDate"></dx-date-box>
            </div>
            <div class="col-sm-3" style="font-weight: bold;">
                Değiştiren Kullanıcı
                <dx-text-box [readOnly]="true" [(value)]="lastUpdateUser"></dx-text-box>
            </div>
            <div class="col-sm-3" style="font-weight: bold;">
                Değiştirilme Tarihi
                <dx-date-box style="width: 100%;" [readOnly]="true" [(value)]="lastUpdateDate"></dx-date-box>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-8" style="font-weight: bold;">
                Açıklama *
                <dx-text-box [(value)]="activeCommisionDefinition.Description">
                    <dx-validator>
                        <dxi-validation-rule type="required" message="Açıklama Boş Olamaz!"></dxi-validation-rule>
                    </dx-validator>
                </dx-text-box>
            </div>
            <div class="col-sm-4" style="font-weight: bold;">
                Komisyon Tipi
                <dx-select-box [dataSource]="CommisionTypes" valueExpr="ordinal"
                               displayExpr="description" [readOnly]="true" [(value)]="activeCommisionDefinition.CommisionType">
                </dx-select-box>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4" style="font-weight: bold;">
                Başlangıç Tarihi *
                <dx-date-box style="width: 100%;" [(value)]="activeCommisionDefinition.StartDate">
                    <dx-validator>
                        <dxi-validation-rule type="required" message="Başlangıç Tarihi Boş Olamaz!"></dxi-validation-rule>
                    </dx-validator>
                </dx-date-box>
            </div>
            <div class="col-sm-4" style="font-weight: bold;">
                Bitiş Tarihi *
                <dx-date-box style="width: 100%;" [(value)]="activeCommisionDefinition.EndDate">
                    <dx-validator>
                        <dxi-validation-rule type="required" message="Bitiş Tarihi Boş Olamaz!"></dxi-validation-rule>
                    </dx-validator>
                </dx-date-box>
            </div>
            <div class="col-sm-2" id="A4023">
                <br />
                <dx-check-box [(value)]="activeCommisionDefinition.IsActive"
                              [width]="400" text="Aktif" style="margin-bottom: 10px;"></dx-check-box>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-12">
                <dx-data-grid #commisionMemberGrid id="commisionMemberGrid" [dataSource]="activeCommisionDefinition.CommisionMembers" 
                              [columnFixing]="{eneabled:'true'}" columnResizingMode="widget"
                              height="300" (onRowRemoving)="onMultiSelectGirdRowRemoving($event)">
                    <dxo-paging [enabled]="true"></dxo-paging>
                    <dxo-editing mode="cell"
                                 [allowUpdating]="true"
                                 [allowDeleting]="false"
                                 [allowAdding]="false">
                    </dxo-editing>
                    <dxi-column dataField="SignUserType" caption="İmza Tipi" [width]="80" [allowEditing]="false">
                        <dxo-lookup [dataSource]="SignUserTypes"
                            displayExpr="description"
                            valueExpr="ordinal">
                        </dxo-lookup>
                    </dxi-column>
                    <dxi-column dataField="ReUserObjectID"
                                editCellTemplate="ddBoxTemplate"
                                caption="Personel"
                                [width]="250">
                        <dxo-lookup [dataSource]="resUserDataSource"
                                    displayExpr="Name"
                                    valueExpr="ObjectID">
                        </dxo-lookup>
                    </dxi-column>
                    <div *dxTemplate="let cellData of 'ddBoxTemplate'">
                        <dx-drop-down-box #ddBox (onValueChanged)="onValueChanged($event, cellData.setValue)" [value]="cellData.value" [dataSource]="resUserDataSource" displayExpr="Name" valueExpr="ObjectID">
                            <dxo-drop-down-options [height]="500"></dxo-drop-down-options>
                            <div *dxTemplate="let data of 'content'">
                                <dx-data-grid keyExpr="ObjectID" [selectedRowKeys]="[cellData.value]" width="100%" (onSelectionChanged)="onSelectionChanged($event, ddBox.instance)" [dataSource]="resUserDataSource"
                                              height="100%">
                                    <dxi-column dataField="Name"></dxi-column>
                                    <dxo-filter-row [visible]="true"></dxo-filter-row>
                                    <dxo-scrolling mode="infinite"></dxo-scrolling>
                                    <dxo-selection mode="single"></dxo-selection>
                                </dx-data-grid>
                            </div>
                        </dx-drop-down-box>
                    </div>
                </dx-data-grid>
            </div>
        </div>
    </div>
</div>
<dx-load-panel shadingColor="rgba(0,0,0,0.4)" [(visible)]="loadingVisible" [showIndicator]="true" [showPane]="true"
               [shading]="true" [closeOnOutsideClick]="false" [(message)]="LoadPanelMessage">
</dx-load-panel> 
`
})
export class CommisionDefinitionComponent implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public commisionDefinitionSource: Array<CommisionDefinitionDataSource> = new Array<CommisionDefinitionDataSource>();
    public resUserDataSource: Array<ResUserDataSource> = new Array<ResUserDataSource>();
    public selectedItemFromOpen: boolean = false;
    public activeCommisionDefinition: CommisionDefinitionInputDTO = new CommisionDefinitionInputDTO();
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public Description: string;
    public IsGroup: boolean = false;
    public ObjectID: Guid;
    public Name: string;
    public selectionGridObjectID: any;

    public CommisionTypes: Array<EnumItem> = CommisionTypeEnum.Items;
    public SignUserTypes: Array<EnumItem> = SignUserTypeEnum.Items;
    @ViewChild('commisionMemberGrid') commisionMemberGrid: DxDataGridComponent;

    constructor(private http: NeHttpService) {
        this.getAllCommisionDefinition();
    }

    private collapseAttr = 0;
    public collapseSelectedDivProperties(): string {
        if (this.collapseAttr == 1) {
            return "hidden";
        }
        return "col-md-3";

    }
    public collapseIconProperties(): string {

        if (this.collapseAttr == 1) {
            return "fa fa-2x fa-angle-up";
        }
        return "fa fa-2x fa-angle-left";

    }

    btnCollapse() {
        if (this.collapseAttr == 1) {
            this.collapseAttr = 0;
        } else
            this.collapseAttr = 1;
    }
    public collapseBtnProperties(): string {

        if (this.collapseAttr == 1) {
            return "float-left";
        }
        return "float-right";

    }




    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 episodeColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-9";

    }

    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }

    public async setInputParam(value: Object) {
    }

    public setModalInfo(value: ModalInfo) {
    }

    public cancelClick(): void {
    }

    public okClick(): void {
    }

    commissionDefinitionDataColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: 'Açıklama',
            dataField: 'Description',
            width: 200,
        },
        {
            caption: "Komisyon Tipi",
            dataField: 'CommisionType',
            lookup: { dataSource: this.CommisionTypes, valueExpr: 'ordinal', displayExpr: 'description' },
            width: 200,
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];

    onSelectionChanged(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;

        dropDownBoxInstance.option("value", keys.length > 0 ? keys[0] : null);

        if (keys.length > 0) {
            this.commisionMemberGrid.instance.saveEditData();
            this.commisionMemberGrid.instance.closeEditCell();
        }
    }

    onValueChanged(args, setValueMethod) {
        setValueMethod(args.value);
    }

    async selectionGridEvent(e) {
        if (e.selectedRowsData != null && e.selectedRowsData.length > 0) {
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GetCommisionDefinition_Input = new GetCommisionDefinition_Input();
            input.ObjectID = e.selectedRowsData[0].ObjectID;
            let fullApiUrl: string = 'api/CommisionDefinition/getCommisionDefinition';
            await this.http.post<CommisionDefinitionInputDTO>(fullApiUrl, input)
                .then((res) => {
                    this.activeCommisionDefinition = res as CommisionDefinitionInputDTO;
                    this.getAuditInfo(e.selectedRowsData[0].ObjectID);
                }).catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.loadingVisible = false;
                });
            this.loadingVisible = false;
        }
    }

    public getAuditInfo(objID: string) {
        let apiUrl: string = '/api/AuditQuery/GetObjectAuditRecords?auditObjectID=' + new Guid(objID);
        this.http.get<Array<LogDataSource>>(apiUrl).then(
            x => {
                if (x != null && x.length > 0) {
                    this.lastUpdateDate = x[x.length - 1].Date;
                    this.lastUpdateUser = x[x.length - 1].AccountName;
                    this.creationDate = x[0].Date;
                    this.creationUser = x[0].AccountName;
                }
            }
        );
    }

    clearData() {
        this.lastUpdateDate = null;
        this.lastUpdateUser = "";
        this.creationDate = null;
        this.creationUser = "";
    }

    async getAllCommisionDefinition() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/CommisionDefinition/getAllCommisionDefinition';
        await this.http.post<CommisionDefinitionInitiDataSource>(fullApiUrl, null)
            .then((res) => {
                that.commisionDefinitionSource = res.CommisionDefinitionDataSources;
                that.resUserDataSource = res.ResUserDataSources;
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }

    public MaterialTreeNewAdd: boolean = false;
    async getRoleControlMain() {
        this.loadingVisible = true;
        let input: any;
        let that = this;
        let fullApiUrl: string = 'api/MainView/GetRoleControlDefinitionSet';
        await this.http.post(fullApiUrl, input)
            .then((res) => {
                let result = <ControlOfDefinitionRole>res;
                that.MaterialTreeNewAdd = result.MaterialTreeDefinitionAdd;
                this.loadingVisible = false;
            })
            .catch(() => {
                this.loadingVisible = false;
                ServiceLocator.MessageService.showError("Hatalı İşlem..");
            });
    }


    async addNew() {
        this.clearData();
        this.selectedItemFromOpen = true;
        this.activeCommisionDefinition = new CommisionDefinitionInputDTO();
        this.activeCommisionDefinition.isNew = true;
        this.activeCommisionDefinition.CommisionType = CommisionTypeEnum.PurchaseExaminationCommision;
        this.activeCommisionDefinition.IsActive = true;
        this.activeCommisionDefinition.CommisionMembers = new Array<CommisionMemberDTO>();
        for (let index = 0; index < 3; index++) {
            let member: CommisionMemberDTO = new CommisionMemberDTO();
            member.ObjectID = Guid.newGuid();
            if (index === 0)
                member.SignUserType = SignUserTypeEnum.Baskan;
            else
                member.SignUserType = SignUserTypeEnum.Uye;
            this.activeCommisionDefinition.CommisionMembers.push(member);
        }
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.clearData();
    }

    Save() {
        this.loadingVisible = true;
        if (this.activeCommisionDefinition != null) {
            if (String.isNullOrEmpty(this.activeCommisionDefinition.Description)) {
                ServiceLocator.MessageService.showError("Açıklama Boş Olamaz!");
                this.loadingVisible = false;
                return;
            }
        }

        let that = this;
        let fullApiUrl: string = 'api/CommisionDefinition/saveObject';
        this.http.post(fullApiUrl, that.activeCommisionDefinition)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                this.selectedItemFromOpen = false;
                this.getAllCommisionDefinition();
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }
}

export class CommisionDefinitionInitiDataSource {
    public CommisionDefinitionDataSources: Array<CommisionDefinitionDataSource> = new Array<CommisionDefinitionDataSource>();
    public ResUserDataSources: Array<ResUserDataSource> = new Array<ResUserDataSource>();
}

export class CommisionDefinitionDataSource {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Description: string;
    public CommisionType: CommisionTypeEnum;
    public IsActive: boolean;
    public ResUserDataSource: Array<ResUserDataSource> = new Array<ResUserDataSource>();
}

export class CommisionDefinitionInputDTO {
    public isNew: boolean;
    public ObjectID: Guid;
    public CommisionType: CommisionTypeEnum;
    public Description: string;
    public StartDate: Date;
    public EndDate: Date;
    public IsActive: boolean;
    public CommisionMembers: Array<CommisionMemberDTO>;
}
export class CommisionMemberDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public SignUserType: SignUserTypeEnum;
    @Type(() => Guid)
    public ReUserObjectID: Guid;
    public ResUserName: string;
    @Type(() => ResUser)
    public ResUser: ResUser;
}
export class GetCommisionDefinition_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}
export class ResUserDataSource {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
}

export class GetCommisionDefinitionByCommisionType_Input {
    public CommisionType: CommisionTypeEnum;
}



