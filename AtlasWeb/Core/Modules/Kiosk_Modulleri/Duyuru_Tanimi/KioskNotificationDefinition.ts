import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
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
import { KioskDeviceDefinition } from 'app/NebulaClient/Model/AtlasClientModel';

@Component({
    selector: "kioskNotificationDefinition-component",
    templateUrl: './KioskNotificationDefinition.html',
    providers: [SystemApiService, MessageService]


})
export class KioskNotificationDefinition implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public notificationDefinitionListDTOs: Array<NotificationDefinitionListDTO> = new Array<NotificationDefinitionListDTO>();
    public DevicesList: Array<KioskDevice> = new Array<KioskDevice>();
    public selecteDevices: Array<KioskDevice> = new Array<KioskDevice>();
    public activeNotificationDefinitionItem: NotificationDefinitionOutputItem = new NotificationDefinitionOutputItem();
    public selectedNotificationDefinitionItem: NotificationDefinitionListDTO;
    public selectedItemFromOpen: boolean = false;
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public selectionGridObjectID: any;
    public isActive: boolean;

    constructor(private http: NeHttpService) {
        this.getAllNotificationDefinition();
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
            auditObject.AuditObjectID = this.activeNotificationDefinitionItem.ObjectID;
            auditObject.AuditObjectDefID = new Guid("7bd4d499-b56f-4e66-84b4-7a8835cd58ea");
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

    notificationDefinitionColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: 'Duyuru',
            dataField: 'Notification',
            width: 300,
            sortOrder: 'asc',
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];

    deviceObjectIDList : Array<Guid> = new Array<Guid>();
    async selectGridRow(value: any): Promise<void> {
        this.clearData();
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GetNotificationDefinition_Input = new GetNotificationDefinition_Input();
            input.ObjectID = value.data.ObjectID;
            let that = this;
            let fullApiUrl: string = 'api/KioskNotificationDefinition/getNotificationDefinitionItem';
            this.http.post<NotificationDefinitionOutputItem>(fullApiUrl, input)
                .then((res) => {
                    that.activeNotificationDefinitionItem = res as NotificationDefinitionOutputItem;
                    if (that.activeNotificationDefinitionItem.Devices != null) {
                        for (let itemDevice of that.activeNotificationDefinitionItem.Devices) {
                            this.selecteDevices.push(this.DevicesList.find(x => x.ObjectID == itemDevice.ObjectID));
                        }
                    }
                    that.isActive = this.activeNotificationDefinitionItem.IsActive;
                    that.getAuditInfo(value.data.ObjectID);
                }).catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    that.loadingVisible = false;
                });
            that.loadingVisible = false;
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
        this.selecteDevices = new Array<KioskDevice>();
    }


    getAllNotificationDefinition() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/KioskNotificationDefinition/getAllNotificationDefinition';
        this.http.post<GetNotificationDefinition>(fullApiUrl, null)
            .then((res) => {
                that.notificationDefinitionListDTOs = res.notificationDefinitionListDTOs as Array<NotificationDefinitionListDTO>;
                that.DevicesList = res.deviceListDTOs as Array<KioskDeviceDefinition>;

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
        this.activeNotificationDefinitionItem = new NotificationDefinitionOutputItem();
        this.activeNotificationDefinitionItem.isNew = true;
        this.activeNotificationDefinitionItem.IsActive = true;
        this.activeNotificationDefinitionItem.Notification = "";
        this.isActive = true;
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.clearData();
        this.selectedNotificationDefinitionItem = null;
    }

    Save() {
        this.activeNotificationDefinitionItem.IsActive = this.isActive;

        if (this.activeNotificationDefinitionItem.Notification == null) {
            ServiceLocator.MessageService.showError("Duyuru İçeriği Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        if (this.selecteDevices != null) {
            this.activeNotificationDefinitionItem.Devices = new Array<KioskDevice>();
            for (let device of this.selecteDevices) {
                let item: KioskDevice = new KioskDevice();
                item.DeviceName = device.DeviceName;
                item.ObjectID = device.ObjectID;
                this.activeNotificationDefinitionItem.Devices.push(item);
            }
        }

        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/KioskNotificationDefinition/saveObject';
        this.http.post(fullApiUrl, that.activeNotificationDefinitionItem)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                this.getAllNotificationDefinition();
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }

}


export class NotificationDefinitionListDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Notification: string;
    public IsActive: boolean;
}

export class GetNotificationDefinition {
    public notificationDefinitionListDTOs: Array<NotificationDefinitionListDTO>;
    public deviceListDTOs: Array<KioskDeviceDefinition>;
}

export class GetNotificationDefinition_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}


export class NotificationDefinitionOutputItem {
    public isNew: boolean;
    public ObjectID: Guid;
    public Notification: string;
    public IsActive: boolean;
    public StartDate: DateTime;
    public EndDate: DateTime;
    public Devices: Array<KioskDevice>;
}

export class KioskDevice {
    public ObjectID: Guid;
    public DeviceName: string;
}

