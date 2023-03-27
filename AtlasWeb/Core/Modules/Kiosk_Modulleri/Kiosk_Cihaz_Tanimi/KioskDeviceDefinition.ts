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
import { DxDataGridComponent } from 'devextreme-angular';
import { ResUser } from 'app/NebulaClient/Model/AtlasClientModel';
@Component({
    selector: "kioskDeviceDefinition-component",
    templateUrl: './KioskDeviceDefinition.html',
    providers: [SystemApiService, MessageService]


})
export class KioskDeviceDefinition implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public deviceDefinitionListDTOs: Array<DeviceDefinitionListDTO> = new Array<DeviceDefinitionListDTO>();
    public activeDeviceDefinitionItem: DeviceDefinitionOutputItem = new DeviceDefinitionOutputItem();
    public selectedDeviceDefinitionItem: DeviceDefinitionListDTO;
    public selectedItemFromOpen: boolean = false;
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public selectionGridObjectID: any;
    public isActive: boolean;


    public resUserDataSource: Array<ResUserDataSource> = new Array<ResUserDataSource>();


    constructor(private http: NeHttpService) {
        this.getAllDeviceDefinition();
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
            auditObject.AuditObjectID = this.activeDeviceDefinitionItem.ObjectID;
            auditObject.AuditObjectDefID = new Guid("feca95a4-f071-4af5-bf5d-054995f96bf3");
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

    deviceDefinitionColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },

        {
            caption: 'Cihaz Kodu',
            dataField: 'Code',
            width: 100,
            sortOrder: 'asc',
        },
        {
            caption: 'Cihaz Adı',
            dataField: 'Name',
            width: 300,
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];


    async selectGridRow(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GetDeviceDefinition_Input = new GetDeviceDefinition_Input();
            input.ObjectID = value.data.ObjectID;

            let fullApiUrl: string = 'api/KioskDeviceDefinition/getDeviceDefinitionItem';
            this.http.post<DeviceDefinitionOutputItem>(fullApiUrl, input)
                .then((res) => {
                    this.activeDeviceDefinitionItem = res as DeviceDefinitionOutputItem;
                    if (this.activeDeviceDefinitionItem.KioskMember == null) {
                        let member: KioskMemberDTO = new KioskMemberDTO();
                        member.ResUserName = "Kullanıcı Seçiniz...";
                        this.activeDeviceDefinitionItem.KioskMember = member;
                    }
                    this.isActive = this.activeDeviceDefinitionItem.IsActive;
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


    getAllDeviceDefinition() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/KioskDeviceDefinition/getAllDeviceDefinition';
        this.http.post<GetDeviceDefinition>(fullApiUrl, null)
            .then((res) => {
                that.deviceDefinitionListDTOs = res.deviceDefinitionListDTOs as Array<DeviceDefinitionListDTO>;
                that.resUserDataSource = res.ResUserDataSources;
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
        this.activeDeviceDefinitionItem = new DeviceDefinitionOutputItem();
        this.activeDeviceDefinitionItem.isNew = true;
        this.activeDeviceDefinitionItem.IsActive = true;
        this.activeDeviceDefinitionItem.HasMernisVerification = false;
        this.activeDeviceDefinitionItem.HasPatientAdmission = false;
        this.activeDeviceDefinitionItem.HasPatientResult = false;
        this.activeDeviceDefinitionItem.HasAppointmentAvailable = false;
        this.activeDeviceDefinitionItem.DeviceName = "";
        this.activeDeviceDefinitionItem.DeviceCode = "";
        this.isActive = true;
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.clearData();
        this.selectedDeviceDefinitionItem = null;
    }

    Save() {


        if (this.activeDeviceDefinitionItem.DeviceName == null) {
            ServiceLocator.MessageService.showError("Anket Başlığı Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        if (this.activeDeviceDefinitionItem.KioskMember == null) {
            ServiceLocator.MessageService.showError("Cihaz Kullanıcısı Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }
        if (this.activeDeviceDefinitionItem.KioskMember.ResUserName == "Kullanıcı Seçiniz...") {
            ServiceLocator.MessageService.showError("Cihaz Kullanıcısı Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        this.activeDeviceDefinitionItem.IsActive = this.isActive;

        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/KioskDeviceDefinition/saveObject';
        this.http.post(fullApiUrl, that.activeDeviceDefinitionItem)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                // this.selectedItemFromOpen = false;
                this.getAllDeviceDefinition();
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }

    onValueChanged(args, setValueMethod) {
        setValueMethod(args.value);
    }
    onSelectionChanged(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option("value", keys.length > 0 ? keys[0] : null);
        let member: KioskMemberDTO = new KioskMemberDTO();
        if (e.selectedRowsData.length == 1) {
            member.ReUserObjectID = e.selectedRowsData[0].ObjectID;
            member.ResUserName = e.selectedRowsData[0].Name;
            this.activeDeviceDefinitionItem.KioskMember = member;
        }

    }

}


export class DeviceDefinitionListDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public Code: string;
    public IsActive: boolean;
}

export class GetDeviceDefinition {
    public deviceDefinitionListDTOs: Array<DeviceDefinitionListDTO>;
    public ResUserDataSources: Array<ResUserDataSource> = new Array<ResUserDataSource>();
}

export class GetDeviceDefinition_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}


export class DeviceDefinitionOutputItem {
    public isNew: boolean;
    public ObjectID: Guid;
    public DeviceName: string;
    public DeviceCode: string;
    public IsActive: boolean;
    public HasMernisVerification: boolean;
    public HasPatientAdmission: boolean;
    public HasPatientResult: boolean;
    public HasAppointmentAvailable: boolean;
    public KioskMember: KioskMemberDTO;

}

export class KioskMemberDTO {

    @Type(() => Guid)
    public ReUserObjectID: Guid;
    public ResUserName: string;
}

export class ResUserDataSource {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ResUserName: string;
}
