import { Component } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { Supplier, Producer } from 'app/NebulaClient/Model/AtlasClientModel';
import { LogDataSource } from 'Modules/Core_Destek_Modulleri/Log_Modulu/AuditQueryFormViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ControlOfDefinitionRole } from '../Models/MainViewModel';
import { IAuditObjectService, AuditObject } from 'app/Fw/Services/IAuditObjectService';
import { IModalService } from 'app/Fw/Services/IModalService';
@Component({
    selector: 'supplierandproducerdef-component',
    template: ` 
    <div class="{{this.collapseSelectedDivProperties()}}" style="height: 100%;" id="A16462">
    <div class="row" style="height: 100%;">
        <div class="col-sm-12 gradientPanel" id="A16463">
            <h4 style="color:#fff; font-size:19px;text-align:left;" id="A16464">
                <div class="btn collapseBtn" (click)="btnCollapse()"
                     style="padding:0;margin-top:3px;margin-right: 5px;" id="A16465">
                    <i class="{{this.collapseIconProperties()}}" id="A16466"></i>
                </div>
                <span i18n="@@M16766" id="A16467">Firma Listesi</span>
            </h4>
        </div>
        <div class="panel-body" style="background-color:#f6f6f6;padding-bottom:0; height:100%;padding: 0">
            <div class="col-md-12" style="padding: 2px;height: calc(100% - 127px);" id="A10249">
                <dx-data-grid #grid [dataSource]="gridSource"  style="height: 100%;" [columns]="supplierOrProcedureDataColumn"
                              [filterRow]="{visible: true}" [paging]="{pageSize:34}"
                              (onSelectionChanged)="selectionGridEvent($event)"
                              [showBorders]="true">
                              <dxo-selection mode="single"></dxo-selection>
                              <div *dxTemplate="let cellData of 'LabelCellTemplate'" id="A16530">
                              <span *ngIf="cellData.data.IsActive==1">Aktif</span>
                              <span *ngIf="cellData.data.IsActive==0">Pasif</span>
                              <span *ngIf="cellData.data.IsActive==-1">Tümü</span>
                          </div>
                </dx-data-grid>
            </div>
            <br />
            <div class="col-md-12" style="max-height: 111px;">
                <div class="row">
                    <div class ="col-sm-6">  
                        <dx-button icon="fas fa-plus" style="float: left;" stylingMode="contained" text="Yeni" type="default" [width]="120" (onClick)="addNew()">
                        </dx-button>
                    </div>
                    <div class ="col-sm-6">  
                        <dx-button style="float: right;" stylingMode="contained" text="Listele" type="default" [width]="120" (onClick)="getSupplierOrProcedure()">
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
        <span i18n="@@M16766">&nbsp;&nbsp;&nbsp;&nbsp;Firma Listesi</span>
    </div>
</div>

<div class="col-sm-8" style="padding-top: 1%;padding-left: 2% !important;">
        <div id="detail" *ngIf="selectedItemFromOpen">
            <div class="row">
            <dx-button icon="fab fa-get-pocket" style="float: left;" stylingMode="contained" text="ÜTS'den Getir" type="success" [width]="160" (onClick)="getUTSFirm()">
            </dx-button>
            <dx-button icon="fab fa-get-pocket" style="float: left;" stylingMode="contained" text="MKYS'den Getir" type="success" [width]="160" (onClick)="getMKYSFirm()">
            </dx-button>
            <dx-button icon="fa fa-times" style="float: right;" stylingMode="contained" text="Vazgeç" type="danger" [width]="120" (onClick)="Cancel()">
            </dx-button>
            <dx-button icon="fas fa-save" style="float: right;" stylingMode="contained" text="Kaydet" type="success" [width]="120" (onClick)="Save()">
            </dx-button>
            </div>
        <br/>
        <br/>
            <div class="row">
                <div class="col-sm-2">
                    Kodu
                    <dx-text-box [readOnly]="true" [(value)]="code"></dx-text-box>
                </div>
                <div class="col-sm-2">
                    Ekleyen Kul.
                    <dx-text-box [readOnly]="true" [(value)]="creationUser"></dx-text-box>
                </div>
                <div class="col-sm-2">
                    Eklenme Tar.
                    <dx-date-box [readOnly]="true" [(value)]="creationDate"></dx-date-box>
                </div>
                <div class="col-sm-3">
                    Değiştiren Kul.
                    <dx-text-box [readOnly]="true" [(value)]="lastUpdateUser"></dx-text-box>
                </div>
                <div class="col-sm-2">
                    Değiştirilme Tar.
                    <dx-date-box [readOnly]="true" [(value)]="lastUpdateDate"></dx-date-box>
                </div>
                
                <div class="col-sm-1" stype="padding-top: 1.5%;">
                      <dx-select-box [(value)]="isActive" [items]="IsActiveItems" displayExpr="Name" valueExpr="Value"></dx-select-box>
                </div>
            </div>
            <br/>
            <div class="row">
                <div class="col-sm-12">
                    Firma Adı*
                    <dx-text-box  [(value)]="FirmName">
                        <dx-validator>
                            <dxi-validation-rule type="required" message="Firma Adı Boş Olamaz!"></dxi-validation-rule>
                        </dx-validator>
                    </dx-text-box>
                </div>
            </div>
            <br/>
            <div class="row">
                <div class="col-sm-3">
                    Vergi No*
                    <dx-text-box [(value)]="FirmTaxNo" [maxLength]="11" >
                    <dx-validator>
                         <dxi-validation-rule type="required" message="Firma Vergi No Boş Olamaz!"></dxi-validation-rule>
                </dx-validator>
                </dx-text-box>
                </div>
                <div class="col-sm-3">
                    Vergi Dairesi
                    <dx-text-box [(value)]="FirmTaxOfficeName"></dx-text-box>
                </div>
                <div class="col-sm-3">
                    Firma Tanımlayıcı No
                    <dx-text-box [(value)]="FirmIdentifierNo">
                    </dx-text-box>
                </div>
                <div class="col-sm-3">
                    GLN NO
                    <dx-text-box [(value)]="FirmGLNNo">
                    </dx-text-box>
                </div>
            </div>
            <br/>
            <div class="row">
                <div class="col-sm-4">
                    Telefon Numarası
                    <dx-text-box [(value)]="FirmTelephone"></dx-text-box>
                </div>
                <div class="col-sm-4">
                    Fax Numarası
                    <dx-text-box  [(value)]="FirmFax"></dx-text-box>
                </div>
                <div class="col-sm-4">
                    E-Posta Adresi
                    <dx-text-box  [(value)]="FirmEmail"></dx-text-box>
                </div>
            </div>
            <br/>
            <div class="row">
                <div class="col-sm-12">
                    Adresi
                    <dx-text-area [height]="90" [(value)]="FirmAddress">
                    </dx-text-area>
                </div>
            </div>
            <br/>
            <div class="row">
                <div class="col-sm-12">
                    Açıklama
                    <dx-text-area [height]="90" [(value)]="FirmNote">
                    </dx-text-area>
                </div>
            </div>
        </div>
    </div>

    <dx-load-panel shadingColor="rgba(0,0,0,0.4)" [(visible)]="loadingVisible" [showIndicator]="true" [showPane]="true"
    [shading]="true" [closeOnOutsideClick]="false" [(message)]="LoadPanelMessage">
    </dx-load-panel>

    `
})
export class SupplierAndProducerDefComponent implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public dynemicSupplierAndProcedureDataSource: SupplierAndProcedureDataSource = new SupplierAndProcedureDataSource();
    public gridSource;
    public selectedItemFromOpen: boolean = false;
    public newItemPrioritiesFromOpen: boolean = false;
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public code: number;
    public objectID: Guid;
    public isActive: boolean;
    public seletectedRowData;
    public FirmName: string;
    public FirmGLNNo: string;
    public FirmTaxNo: string;
    public FirmEmail: string;
    public FirmAddress: string;
    public FirmNote: string;
    public FirmTaxOfficeName: string;
    public FirmIdentifierNo: string;
    public FirmTelephone: string;
    public FirmFax: string;
    public IsNew: boolean = false;
    public componentInfo: DynamicComponentInfo;
    public selectedDataGrid: any;
    public SupplierAndProducreNewAdd: boolean = false;

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
        this.getAllSupplierOrProcedure();
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

    public IsActiveItems = [
        {
            Name: "Aktif",
            Value: true
        },
        {
            Name: "Pasif",
            Value: false
        }

    ];

    supplierOrProcedureDataColumn = [
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
            caption: 'Firma Adı',
            dataField: 'Name',
            sortOrder: 'asc',
        },
        {
            "caption": "Durumu",
            dataField: 'IsActive',
            cellTemplate: "LabelCellTemplate",
            falseText: "Pasif",
            trueText: "Aktif",
            width: 50
        },
    ];



    async getAllSupplierOrProcedure() {
        this.loadingVisible = true;
        //this.dynemicSupplierAndProcedureDataSource = new SupplierAndProcedureDataSource();
        //this.dynemicSupplierAndProcedureDataSource.suppliersAndProducers = new Array<SuppliersAndProducer>();
        let that = this;
        let fullApiUrl: string = 'api/SupplierAndProducer/getAllSupplierOrProcedure';
        await this.http.post<SupplierAndProcedureDataSource>(fullApiUrl, null)
            .then((res) => {
                this.gridSource = res.suppliersAndProducers as Array<SuppliersAndProducer>;
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }

    getSupplierOrProcedure() {
        this.getAllSupplierOrProcedure();
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

    async selectionGridEvent(e) {
        this.loadingVisible = true;
        this.IsNew = false;
        this.clearData();
        if (e.selectedRowsData.length > 0) {
            this.selectedItemFromOpen = true;
            this.getAuditInfo(e.selectedRowsData[0].ObjectID);
            this.seletectedRowData = e.selectedRowsData[0];
            let queryString = 'ObjectID=' + new Guid(e.selectedRowsData[0].ObjectID);
            let apiUrl: string = '/api/SupplierAndProducer/GetSuppOrProducer?' + queryString;
            this.http.get<InputDVO>(apiUrl).then(
                x => {
                    this.objectID = x.objectID;
                    this.code = x.Code;
                    this.isActive = x.isActive;
                    this.FirmName = x.FirmName;
                    this.FirmTaxNo = x.FirmTaxNo;
                    this.FirmEmail = x.FirmEmail;
                    this.FirmTaxOfficeName = x.FirmTaxOfficeName;
                    this.FirmIdentifierNo = x.FirmIdentifierNo;
                    this.FirmTelephone = x.FirmTelephone;
                    this.FirmFax = x.FirmFax;
                    this.FirmNote = x.FirmNote;
                    this.FirmGLNNo = x.FirmGLNNo;
                    this.selectedDataGrid = e;
                    this.loadingVisible = false;
                }
            ).catch(error => {
                this.loadingVisible = false;
                ServiceLocator.MessageService.showError("Hatalı İşlem..");
            });
        } else {
            this.loadingVisible = false;
        }
    }

    clearData() {
        this.code = null;
        this.isActive = true;
        this.FirmName = "";
        this.FirmTaxNo = "";
        this.FirmTaxOfficeName = "";
        this.FirmIdentifierNo = "";
        this.FirmTelephone = "";
        this.FirmFax = "";
        this.FirmNote = "";
        this.FirmGLNNo = "";
        this.FirmEmail = "";
        this.FirmAddress = "";
        this.FirmNote = "";
        this.objectID = new Guid;
        this.newItemPrioritiesFromOpen = false;
    }


    async getRoleControlMain() {
        this.loadingVisible = true;
        let input: any;
        let that = this;
        let fullApiUrl: string = 'api/MainView/GetRoleControlDefinitionSet';
        await this.http.post(fullApiUrl, input)
            .then((res) => {
                let result = <ControlOfDefinitionRole>res;
                that.SupplierAndProducreNewAdd = result.SupplierAndProducreNewAdd;
                this.loadingVisible = false;
            })
            .catch(error => {
                this.loadingVisible = false;
                ServiceLocator.MessageService.showError("Hatalı İşlem..");
            });
    }

    async addNew() {
        await this.getRoleControlMain();
        if (this.SupplierAndProducreNewAdd == true) {
            this.IsNew = true;
            this.clearData();
            this.selectedItemFromOpen = true;
            this.newItemPrioritiesFromOpen = true;
        }
        else {
            ServiceLocator.MessageService.showError("Yeni Firma Tanımı Yapmaya Yetkiniz Bulunmamaktadır.");
        }
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.IsNew = false;
        this.clearData();
    }

    async Save() {
        this.loadingVisible = true;
        if (String.isNullOrEmpty(this.FirmName)) {
            ServiceLocator.MessageService.showError("Firma Adı Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }
        if (String.isNullOrEmpty(this.FirmTaxNo)) {
            ServiceLocator.MessageService.showError("Firma Vergi No Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        if (this.gridSource.filter(x => x.Tax == this.FirmTaxNo && x.ObjectID != this.objectID).length > 0) {
            let existFirm: any = this.gridSource.filter(x => x.Tax == this.FirmTaxNo && x.ObjectID != this.objectID);
            let existFirmName: string = existFirm[0].Name;
            ServiceLocator.MessageService.showError("Vergi Numarası : " + existFirmName + " Firma İle Aynıdır. Aynı vergi Numarası İle Kayıt İşlemi Yapılamaz!");
            this.loadingVisible = false;
            return;
        }

        let inputDVO: InputDVO = new InputDVO();
        inputDVO.isNew = this.IsNew;
        inputDVO.objectID = this.objectID;
        inputDVO.isActive = this.isActive;
        inputDVO.FirmName = this.FirmName;
        inputDVO.FirmGLNNo = this.FirmGLNNo;
        inputDVO.FirmTaxNo = this.FirmTaxNo;
        inputDVO.FirmEmail = this.FirmEmail;
        inputDVO.FirmAddress = this.FirmAddress;
        inputDVO.FirmNote = this.FirmNote;
        inputDVO.FirmTaxOfficeName = this.FirmTaxOfficeName;
        inputDVO.FirmIdentifierNo = this.FirmIdentifierNo;
        inputDVO.FirmTelephone = this.FirmTelephone;
        inputDVO.FirmFax = this.FirmFax;

        let that = this;
        let fullApiUrl: string = 'api/SupplierAndProducer/saveObject';

        await this.http.post<SupplierAndProcedureDataSource>(fullApiUrl, inputDVO)
            .then((res) => {
                this.gridSource = res.suppliersAndProducers as Array<SuppliersAndProducer>;
                if (this.selectedDataGrid != null) {
                    this.selectionGridEvent(this.selectedDataGrid);
                }
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }

    getUTSFirm() {
        this.loadingVisible = true;
        if (String.isNullOrEmpty(this.FirmTaxNo) == false) {
            let that = this;
            let fullApiUrl: string = 'api/SupplierAndProducer/ütsSupplier?FirmTaxNo=' + this.FirmTaxNo;
            this.http.get<InputDVO>(fullApiUrl).then(
                x => {
                    this.objectID = x.objectID;
                    this.code = x.Code;
                    this.isActive = x.isActive;
                    this.FirmName = x.FirmName;
                    this.FirmTaxNo = x.FirmTaxNo;
                    this.FirmEmail = x.FirmEmail;
                    this.FirmTaxOfficeName = x.FirmTaxOfficeName;
                    this.FirmIdentifierNo = x.FirmIdentifierNo;
                    this.FirmTelephone = x.FirmTelephone;
                    this.FirmFax = x.FirmFax;
                    this.FirmNote = x.FirmNote;
                    this.FirmGLNNo = x.FirmGLNNo;
                    this.loadingVisible = false;

                    if (this.FirmName != null)
                        ServiceLocator.MessageService.showInfo("ÜTS Kaydı Başarılı Şekilde Tamamlandı..");
                    else
                        TTVisual.InfoBox.Alert("ÜTS'de kayıt bulunamadı!.");
                }
            ).catch(error => {
                this.loadingVisible = false;
                ServiceLocator.MessageService.showError("Hatalı İşlem..");
            });
        }
        else {
            this.loadingVisible = false;
            TTVisual.InfoBox.Alert("Firma Vergi Numarası Girilmeden ÜTS'den arama yapılamaz!.");
        }

    }
    getMKYSFirm() {
        this.loadingVisible = true;
        if (String.isNullOrEmpty(this.FirmTaxNo) == false) {
            let that = this;
            let fullApiUrl: string = 'api/SupplierAndProducer/mkysSupplier?FirmTaxNo=' + this.FirmTaxNo;
            returnValue: this.http.get<InputDVO>(fullApiUrl).then(
                x => {
                    this.objectID = x.objectID;
                    this.code = x.Code;
                    this.isActive = x.isActive;
                    this.FirmName = x.FirmName;
                    this.FirmTaxNo = x.FirmTaxNo;
                    this.FirmEmail = x.FirmEmail;
                    this.FirmTaxOfficeName = x.FirmTaxOfficeName;
                    this.FirmIdentifierNo = x.FirmIdentifierNo;
                    this.FirmTelephone = x.FirmTelephone;
                    this.FirmFax = x.FirmFax;
                    this.FirmNote = x.FirmNote;
                    this.FirmGLNNo = x.FirmGLNNo;
                    this.loadingVisible = false;
                    if (this.FirmName != null)
                        ServiceLocator.MessageService.showInfo("MKYS Kaydı Başarılı Şekilde Tamamlandı..");
                    else
                        TTVisual.InfoBox.Alert("MKYS'de kayıt bulunamadı!.");
                }
            ).catch(error => {
                this.loadingVisible = false;
                ServiceLocator.MessageService.showError("Hatalı İşlem..");
            });
        }
        else {
            this.loadingVisible = false;
            TTVisual.InfoBox.Alert("Firma Vergi Numarası Girilmeden MKYS'den arama yapılamaz!.");
        }
    }
}

export class SupplierOrProcedureData {
    ID: number;
    Name: string;
}
export class ItemStatus {
    ID: number;
    Name: string;
}

export class SupplierAndProcedureDataSource {
    suppliersAndProducers: Array<SuppliersAndProducer> = new Array<SuppliersAndProducer>();
}

export class SuppliersAndProducer {
    ObjectID: Guid;
    isActive: boolean;
    Code: number;
    Name: string;
    IsActive: boolean;
    //SupOrPro: number;
    Tax: string;
}

export class InputDVO {
    isNew: boolean;
    objectID: Guid;
    //intType: number;
    isActive: boolean;
    FirmName: string;
    FirmGLNNo: string;
    FirmTaxNo: string;
    FirmEmail: string;
    FirmAddress: string;
    FirmNote: string;
    FirmTaxOfficeName: string;
    FirmIdentifierNo: string;
    FirmTelephone: string;
    FirmFax: string;
    Code: number;
}

