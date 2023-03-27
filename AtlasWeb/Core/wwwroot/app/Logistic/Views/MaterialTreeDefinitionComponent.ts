import { Component } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { Supplier, Producer, MaterialTreeDefinition, Service } from 'app/NebulaClient/Model/AtlasClientModel';
import { LogDataSource } from 'Modules/Core_Destek_Modulleri/Log_Modulu/AuditQueryFormViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ControlOfDefinitionRole } from '../Models/MainViewModel';
import { IAuditObjectService, AuditObject } from 'app/Fw/Services/IAuditObjectService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { Type } from 'NebulaClient/ClassTransformer';
@Component({
    selector: 'materialtreedefinition-component',
    template: ` 
    <div class="{{this.collapseSelectedDivProperties()}}" style="height: 100%;" id="A16462">
    <div class="row" style="height: 100%;">
        <div class="col-sm-12 gradientPanel" id="A16463">
            <h4 style="color:#fff; font-size:19px;text-align:left;" id="A16464">
                <div class="btn collapseBtn" (click)="btnCollapse()"
                     style="padding:0;margin-top:3px;margin-right: 5px;" id="A16465">
                    <i class="{{this.collapseIconProperties()}}" id="A16466"></i>
                </div>
                <span i18n="@@M16766" id="A16467">Malzeme Grup Listesi</span>
            </h4>
        </div>
        <div class="panel-body" style="background-color:#f6f6f6;padding-bottom:0; height:100%;padding: 0">
            <div class="col-md-12" style="padding: 2px;height: calc(100% - 127px);" id="A10249">
                <dx-data-grid #grid [dataSource]="gridSource"  style="height: 100%;" [columns]="materialTreeDataColumn"
                              [filterRow]="{visible: true}" [paging]="{pageSize:34}"
                              (onSelectionChanged)="selectionGridEvent($event)"
                              [showBorders]="true">
                              <dxo-selection mode="single"></dxo-selection>
                </dx-data-grid>
            </div>
            <br />
            <div class="col-md-12" style="max-height: 111px;">
                <div class="row">
                    <div class ="col-sm-6">  
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
        <span i18n="@@M16766">&nbsp;&nbsp;&nbsp;&nbsp;Malzeme Grup Listesi</span>
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
        <br/>
        <br/>
        <div class="row">
                <div class="col-sm-3" style="font-weight: bold;">
                    Ekleyen Kullanıcı
                    <dx-text-box [readOnly]="true" [(value)]="creationUser"></dx-text-box>
                </div>
                <div class="col-sm-3" style="font-weight: bold;">
                    Eklenme Tarihi
                    <dx-date-box  style="width: 100%;" [readOnly]="true" [(value)]="creationDate"></dx-date-box>
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
        <br/>
        <div class="row">
            <div class="col-sm-12" style="font-weight: bold;">
                Taşınır Kodu*
                <dx-text-box  [(value)]="GroupCode">
                    <dx-validator>
                        <dxi-validation-rule type="required" message="Taşınır Kodu Boş Olamaz!"></dxi-validation-rule>
                    </dx-validator>
                </dx-text-box>
            </div>
        </div>
        <br/>
        <div class="row">
            <div class="col-sm-12" style="font-weight: bold;">
            Grup Adı*
            <dx-text-box  [(value)]="Name">
                <dx-validator>
                    <dxi-validation-rule type="required" message="Grup Adı Boş Olamaz!"></dxi-validation-rule>
                </dx-validator>
            </dx-text-box>
            </div>
        </div>
        <br/>
        <div class="row">
            <div class="col-sm-2" id="A4023">
				<dx-check-box [(value)]="IsGroup"
					[width]="400" text="Grup" style="margin-bottom: 10px;"></dx-check-box>
            </div>
            <div class="col-sm-10">
                <div class=" dx-field" style="margin: 0 0 5px 0;">
                    <div class="dx-field-label" style="width: 67px;font-weight: bold;" title="Ana Grup">Üst Grubu</div>
                    <div class="dx-field-value" style="width: 90%;">
                    <dx-drop-down-box
                    [(value)]="parentMaterialTreeDropDown"
                    valueExpr="ObjectID" [deferRendering]="false" displayExpr="Name" placeholder="Seçiniz.."
                    [showClearButton]="true" [dataSource]="parentListSource">
                        <div *dxTemplate="let data of 'content'">
                            <dx-data-grid
                            [dataSource]="parentListSource"
                            [columns]="parentmaterialTreeDataColumn"
                            [selection]="{ mode: 'single' }"
                            [hoverStateEnabled]="true"
                            [paging]="{ enabled: true, pageSize: 10 }"
                            [filterRow]="{ visible: true }"
                            [scrolling]="{ mode: 'infinite' }"
                            (onSelectionChanged)="onParentTreeSelectionChanged($event)"
                            height="100%">
                            </dx-data-grid>
                        </div>
                    </dx-drop-down-box>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<dx-load-panel shadingColor="rgba(0,0,0,0.4)" [(visible)]="loadingVisible" [showIndicator]="true" [showPane]="true"
    [shading]="true" [closeOnOutsideClick]="false" [(message)]="LoadPanelMessage">
 </dx-load-panel>

    `
})
export class MaterialTreeDefitionComponent implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public gridSource: Array<MaterialTreeDef> = new Array<MaterialTreeDef>();
    public parentListSource: Array<ParentMaterialTreeDef> = new Array<ParentMaterialTreeDef>();
    public parentMaterialTree: ParentMaterialTreeDef;
    public parentMaterialTreeDropDown: Guid;
    public selectedItemFromOpen: boolean = false;
    public IsNew: boolean = false;
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public GroupCode: string;
    public IsGroup: boolean = false;
    public ObjectID: Guid;
    public Name: string;
    public selectionGridObjectID: any;
    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
        this.getAllMaterialTreeDefinition();
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

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
    }

    public okClick(): void {
    }

    materialTreeDataColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: 'Kodu',
            dataField: 'Code',
            width: 100,
        },
        {
            caption: 'Adı',
            dataField: 'Name',
            sortOrder: 'asc',
        }
    ];

    parentmaterialTreeDataColumn = [
        {
            caption: 'Kodu',
            dataField: 'Code',
            width: 190,
        },
        {
            caption: 'Adı',
            dataField: 'Name',
        }
    ];

    onParentTreeSelectionChanged(event: any) {
        if (this.IsNew != true) {
            if (this.ObjectID != event.selectedRowKeys[0].ObjectID) {
                this.parentMaterialTreeDropDown = event.selectedRowKeys[0].ObjectID;
            } else {
                ServiceLocator.MessageService.showError("Üst Grup Kendisi Olamaz.");
            }
        }else{
            this.parentMaterialTreeDropDown = event.selectedRowKeys[0].ObjectID;
        }
    }

    async selectionGridEvent(e) {
        this.loadingVisible = true;
        this.IsNew = false;
        if (e.selectedRowsData.length > 0) {
            this.selectedItemFromOpen = true;
            this.selectionGridObjectID = e.selectedRowsData[0].ObjectID;
            this.getAuditInfo(e.selectedRowsData[0].ObjectID);
            this.ObjectID = e.selectedRowsData[0].ObjectID;
            this.Name = e.selectedRowsData[0].Name;
            this.GroupCode = e.selectedRowsData[0].Code;
            this.IsGroup = e.selectedRowsData[0].IsGroup;
            if (e.selectedRowsData[0].ParentMaterialTree != null) {
                let pMatTreeDef: Array<ParentMaterialTreeDef> = this.parentListSource.filter(x => x.ObjectID == e.selectedRowsData[0].ParentMaterialTree.ObjectID) as Array<ParentMaterialTreeDef>;
                this.parentMaterialTreeDropDown = (pMatTreeDef[0] as ParentMaterialTreeDef).ObjectID;
            } else {
                this.parentMaterialTreeDropDown = null;
            }
            this.loadingVisible = false;
        } else {
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
        this.GroupCode = "";
        this.Name = "";
        this.lastUpdateDate = null;
        this.lastUpdateUser = "";
        this.creationDate = null;
        this.creationUser = "";
        this.parentMaterialTree = null;
        this.IsGroup = false;
    }

    async getAllMaterialTreeDefinition() {
        this.loadingVisible = true;
        let that = this;
        let seletedGrid:any;
        let fullApiUrl: string = 'api/MaterialTreeDefinition/getAllMaterialTreeDefinition';
        await this.http.post<MaterialTreeDefinitionDataSource>(fullApiUrl, null)
            .then((res) => {
                that.gridSource = res.materialTreeDefs as Array<MaterialTreeDef>;
                that.parentListSource = res.parentMaterialTreeDefs as Array<ParentMaterialTreeDef>;
                this.loadingVisible = false;
                if (that.selectionGridObjectID != null) {
                    seletedGrid= that.gridSource.find(x=>x.ObjectID == that.selectionGridObjectID);
                    this.selectedItemFromOpen = true;
                    this.getAuditInfo(seletedGrid.ObjectID);
                    this.ObjectID = seletedGrid.ObjectID;
                    this.Name = seletedGrid.Name;
                    this.GroupCode = seletedGrid.Code;
                    this.IsGroup = seletedGrid.IsGroup;
                    if (seletedGrid.ParentMaterialTree != null) {
                        let pMatTreeDef: Array<ParentMaterialTreeDef> = this.parentListSource.filter(x => x.ObjectID == seletedGrid.ParentMaterialTree.ObjectID) as Array<ParentMaterialTreeDef>;
                        this.parentMaterialTreeDropDown = (pMatTreeDef[0] as ParentMaterialTreeDef).ObjectID;
                    } else {
                        this.parentMaterialTreeDropDown = null;
                    }
                    this.loadingVisible = false;
                }
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
            .catch(error => {
                this.loadingVisible = false;
                ServiceLocator.MessageService.showError("Hatalı İşlem..");
            });
    }


    async addNew() {
        await this.getRoleControlMain();
        if (this.MaterialTreeNewAdd == true) {
            this.clearData();
            this.selectedItemFromOpen = true;
            this.IsNew = true;
        }
        else {
            ServiceLocator.MessageService.showError("Malzeme Grup Tanımı Yetkiniz Bulunmamaktadır.");
        }
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.IsNew = false;
        this.clearData();
    }

    Save() {
        this.loadingVisible = true;
        if (String.isNullOrEmpty(this.Name)) {
            ServiceLocator.MessageService.showError("Adı Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }
        if (String.isNullOrEmpty(this.GroupCode)) {
            ServiceLocator.MessageService.showError("Taşınır Kodu Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        let inputDTO: MaterialTreeInputDTO = new MaterialTreeInputDTO();
        inputDTO.isNew = this.IsNew;
        inputDTO.ObjectID = this.ObjectID;
        inputDTO.Code = this.GroupCode;
        inputDTO.Name = this.Name;

        if (this.parentMaterialTreeDropDown != null) {
            inputDTO.ParentMaterialTreeObjectId = this.parentMaterialTreeDropDown;
        }
        inputDTO.IsGroup = this.IsGroup;



        let that = this;
        let fullApiUrl: string = 'api/MaterialTreeDefinition/saveObject';
        this.http.post(fullApiUrl, inputDTO)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                if (this.IsNew == true) {
                    this.selectedItemFromOpen = false;
                    this.getAllMaterialTreeDefinition();
                } else {
                    if (this.selectionGridObjectID != null) {
                        this.getAllMaterialTreeDefinition();
                    }
                }
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }
}



export class MaterialTreeDefinitionDataSource {
    materialTreeDefs: Array<MaterialTreeDef> = new Array<MaterialTreeDef>();
    parentMaterialTreeDefs: Array<ParentMaterialTreeDef> = new Array<ParentMaterialTreeDef>();
}

export class MaterialTreeDef {
    ObjectID: Guid;
    Code: number;
    Name: string;
    ParentMaterialTree: ParentMaterialTreeDef;
    IsGroup: boolean;
}


export class ParentMaterialTreeDef {
    @Type(() => Guid)
    ObjectID: Guid;
    Code: number;
    Name: string;
}

export class MaterialTreeInputDTO {
    isNew: boolean;
    ObjectID: Guid;
    Code: string;
    Name: string;
    @Type(() => Guid)
    ParentMaterialTreeObjectId: Guid;
    IsGroup: boolean;
}



