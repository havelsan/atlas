import { Component, ViewChild, OnInit } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { LogDataSource } from 'Modules/Core_Destek_Modulleri/Log_Modulu/AuditQueryFormViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Type } from 'NebulaClient/ClassTransformer';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { MessageService } from 'app/Fw/Services/MessageService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IAuditObjectService, AuditObject } from 'app/Fw/Services/IAuditObjectService';
import { IModalService } from 'app/Fw/Services/IModalService';
import DateTime from 'app/NebulaClient/System/Time/DateTime';

@Component({
    selector: "orderRestDayDefinition-component",
    templateUrl: './OrderRestDayDefinitionComponent.html',
    providers: [SystemApiService, MessageService]


})
export class OrderRestDayDefinitionComponent implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public orderRestDayDefinitionListDTOs: Array<OrderRestDayDefinitionListDTO> = new Array<OrderRestDayDefinitionListDTO>();
    public activeOrderRestDayDefinitionItem: OrderRestDayDefinitionOutputItem = new OrderRestDayDefinitionOutputItem();
    public selectedOrderRestDayDefinitionItem: OrderRestDayDefinitionListDTO;
    
    public selectedItemFromOpen: boolean = false;
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public selectionGridObjectID: any;
    public isActive: boolean;

    constructor(private http: NeHttpService) {
        this.getOrderRestDayDefinition();
    }

   
   

    public async getDetailAudit() {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ShowAuditForm';
            componentInfo.ModuleName = 'LogModule';
            componentInfo.ModulePath = '/Modules/Core_Destek_Modulleri/Log_Modulu/LogModule';
            const auditService = ServiceLocator.Injector.get(IAuditObjectService);
            auditService.ObjectIDList.Clear();
            let auditObject: AuditObject = new AuditObject;
            auditObject.AuditObjectID = this.activeOrderRestDayDefinitionItem.ObjectID;
            auditObject.AuditObjectDefID = new Guid("e1052e15-9c4e-458e-8430-c9b5e0d59b8a");
            auditService.ObjectIDList.push(auditObject);
            componentInfo.InputParam = auditService.ObjectIDList;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'İşlem Tarihçesi';
            modalInfo.Width = 1300;
            modalInfo.Height = 750;

            const modalService = ServiceLocator.Injector.get(IModalService);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

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

    orderRestDayDefinitionColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: 'Order Günü',
            dataField: 'OrderDay',
            dataType: 'date',
            sortOrder: 'desc',
            width: 100,

        },
        {
            caption: 'Tatil Günü Açıklaması',
            dataField: 'RestDayDescription',
            width: 300,
        }
    ];


    async selectGridRow(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GetOrderRestDayDefinition_Input = new GetOrderRestDayDefinition_Input();
            input.ObjectID = value.data.ObjectID;

            let fullApiUrl: string = 'api/OrderRestDayDefinition/getOrderRestDayDefinitionItem';
            this.http.post<OrderRestDayDefinitionOutputItem>(fullApiUrl, input)
                .then((res) => {
                    this.activeOrderRestDayDefinitionItem = res as OrderRestDayDefinitionOutputItem;
                    this.isActive = this.activeOrderRestDayDefinitionItem.IsActive;
                    this.getAuditInfo(value.data.ObjectID);
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
        this.isActive = null;
    }


    getOrderRestDayDefinition() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/OrderRestDayDefinition/getAllOrderRestDayDefinition';
        this.http.post<GetOrderRestDayDefinition>(fullApiUrl, null)
            .then((res) => {
                that.orderRestDayDefinitionListDTOs = res.orderRestDayDefinitionListDTOs as Array<OrderRestDayDefinitionListDTO>;
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }



    async addNew() {
        this.clearData();
        this.selectedItemFromOpen = true;
        this.activeOrderRestDayDefinitionItem = new OrderRestDayDefinitionOutputItem();
        this.activeOrderRestDayDefinitionItem.isNew = true;
        this.activeOrderRestDayDefinitionItem.IsActive = true;
        this.activeOrderRestDayDefinitionItem.OrderDay = new Date();
        this.isActive = true;
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.clearData();
        this.activeOrderRestDayDefinitionItem = null;
    }

    Save() {

        if (this.activeOrderRestDayDefinitionItem.RestDayCount == null) {
            ServiceLocator.MessageService.showError("Gün Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        if (this.activeOrderRestDayDefinitionItem.RestDayDescription == null) {
            ServiceLocator.MessageService.showError("Açıklama Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }
        if (this.activeOrderRestDayDefinitionItem.OrderDay == null) {
            ServiceLocator.MessageService.showError("Order Günü Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        this.activeOrderRestDayDefinitionItem.IsActive = this.isActive;

        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/OrderRestDayDefinition/saveObject';
        this.http.post(fullApiUrl, that.activeOrderRestDayDefinitionItem)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                this.getOrderRestDayDefinition();
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }
}


export class OrderRestDayDefinitionListDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public RestDayDescription: string;
    public OrderDay:Date;
}

export class GetOrderRestDayDefinition {
    public orderRestDayDefinitionListDTOs: Array<OrderRestDayDefinitionListDTO>;
}

export class GetOrderRestDayDefinition_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}


export class OrderRestDayDefinitionOutputItem {
    public isNew: boolean;
    public ObjectID: Guid;
    public RestDayDescription: string;
    public OrderDay:Date;
    public RestDayCount:number;
    public IsActive:boolean;
}