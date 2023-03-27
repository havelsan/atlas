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
import { OpenCloseEnum, MKYS_ECikisStokHareketTurEnum, MKYS_EButceTurEnum, Accountancy, MKYS_EEntegrasyonDurumuEnum, StoreSMSUser } from 'app/NebulaClient/Model/AtlasClientModel';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';

@Component({
    selector: "mainStoreDefinition-component",
    templateUrl: './MainStoreDefinitionComponent.html',
    providers: [SystemApiService, MessageService]


})
export class MainStoreDefinitionComponent implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";


    public mainStoreDefinitionListDTOs: Array<MainStoreDefinitionListDTO> = new Array<MainStoreDefinitionListDTO>();
    public activeMainStoreDefinitionItem: MainStoreDefinitionOutputItem = new MainStoreDefinitionOutputItem();
    public selectedMainStoreDefinitionItem: MainStoreDefinitionListDTO;
    public MainStoreStatus: Array<EnumItem> = OpenCloseEnum.Items;
    public MKYSButceTuru: Array<EnumItem> = MKYS_EButceTurEnum.Items;
    public selectedItemFromOpen: boolean = false;
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public selectionGridObjectID: any;
    public isActive: boolean;

    public smsUserListDataSource: Array<SmsUserDTO> = new Array<SmsUserDTO>();


    public resUserDataSource: Array<ResUserDataSource> = new Array<ResUserDataSource>();
    public accoutancyDataSource: Array<AccoutancyDataSource> = new Array<AccoutancyDataSource>();
    public seletectResDataSource:SmsUserDTO = new SmsUserDTO();


    constructor(private http: NeHttpService) {
        this.getMainStoreDefinition();
        this.activeMainStoreDefinitionItem.GoodsResponsible = new StoreResponsibleDTO();
        this.activeMainStoreDefinitionItem.GoodsResponsible.ResUserName = "";

        this.activeMainStoreDefinitionItem.GoodsAccountant = new StoreResponsibleDTO();
        this.activeMainStoreDefinitionItem.GoodsAccountant.ResUserName = "";

        this.activeMainStoreDefinitionItem.AccountManager = new StoreResponsibleDTO();
        this.activeMainStoreDefinitionItem.AccountManager.ResUserName = "";

        this.activeMainStoreDefinitionItem.StoreSMSUsers = new Array<SmsUserDTO>();
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
            auditObject.AuditObjectID = this.activeMainStoreDefinitionItem.ObjectID;
            auditObject.AuditObjectDefID = new Guid("3958eb35-7eae-48e8-afe0-185d1faa29ea");
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

    mainStoreDefinitionColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: 'Cepo Depo Adı',
            dataField: 'Name',
            sortOrder: 'asc',
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
            this.clearData();
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GetMainStoreDefinition_Input = new GetMainStoreDefinition_Input();
            input.ObjectID = value.data.ObjectID;

            let fullApiUrl: string = 'api/MainStoreDefinition/getMainStoreDefinitionItem';
            this.http.post<MainStoreDefinitionOutputItem>(fullApiUrl, input)
                .then((res) => {
                    if(res.StoreSMSUsers != null){
                        for(let x of res.StoreSMSUsers){
                            let member: SmsUserDTO = new SmsUserDTO();
                            member.ResUserObjectID = x.ResUserObjectID;
                            member.ResUserName = x.ResUserName;
                            this.smsUserListDataSource.push(member);
                        }
                    }
                    this.activeMainStoreDefinitionItem = res as MainStoreDefinitionOutputItem;
                    this.isActive = this.activeMainStoreDefinitionItem.IsActive;
                  
                    
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
        this.seletectResDataSource = new SmsUserDTO();
        this.smsUserListDataSource = new Array<SmsUserDTO>();

    }


    getMainStoreDefinition() {
        this.clearData();
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/MainStoreDefinition/getAllMainStoreDefinition';
        this.http.post<GetMainStoreDefinition>(fullApiUrl, null)
            .then((res) => {
                that.mainStoreDefinitionListDTOs = res.mainStoreDefinitionListDTOs as Array<MainStoreDefinitionListDTO>;
                that.resUserDataSource = res.ResUserDataSources;
                that.accoutancyDataSource = res.AccotuntancyDataSource;
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }



    async addNew() {
        /* this.clearData();
        this.selectedItemFromOpen = true;
        this.activeMainStoreDefinitionItem = new MainStoreDefinitionOutputItem();
        this.activeMainStoreDefinitionItem.isNew = true;
        this.activeMainStoreDefinitionItem.IsActive = true;
        this.isActive = true; */
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.clearData();
        this.selectedMainStoreDefinitionItem = null;
    }

    Save() {
        if (this.activeMainStoreDefinitionItem.Name == null || this.activeMainStoreDefinitionItem.Name == "") {
            ServiceLocator.MessageService.showError("Ana Depo Adı Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        this.activeMainStoreDefinitionItem.IsActive = this.isActive;

        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/MainStoreDefinition/saveObject';
        this.http.post(fullApiUrl, that.activeMainStoreDefinitionItem)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                this.getMainStoreDefinition();
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

    onSelectionChangedGoodsAccountant(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option("value", keys.length > 0 ? keys[0] : null);
        let member: StoreResponsibleDTO = new StoreResponsibleDTO();
        if (e.selectedRowsData.length == 1) {
            member.ReUserObjectID = e.selectedRowsData[0].ObjectID;
            member.ResUserName = e.selectedRowsData[0].Name;
            this.activeMainStoreDefinitionItem.GoodsAccountant = member;
        }
    }

    onSelectionChangedGoodsResponsible(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option("value", keys.length > 0 ? keys[0] : null);
        let member: StoreResponsibleDTO = new StoreResponsibleDTO();
        if (e.selectedRowsData.length == 1) {
            member.ReUserObjectID = e.selectedRowsData[0].ObjectID;
            member.ResUserName = e.selectedRowsData[0].Name;
            this.activeMainStoreDefinitionItem.GoodsResponsible = member;
        }
    }

    onSelectionChangedAccountManager(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option("value", keys.length > 0 ? keys[0] : null);
        let member: StoreResponsibleDTO = new StoreResponsibleDTO();
        if (e.selectedRowsData.length == 1) {
            member.ReUserObjectID = e.selectedRowsData[0].ObjectID;
            member.ResUserName = e.selectedRowsData[0].Name;
            this.activeMainStoreDefinitionItem.AccountManager = member;
        }
    }
    
    onSelectionChangedSmsUser(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option("value", keys.length > 0 ? keys[0] : null);
        let member: SmsUserDTO = new SmsUserDTO();
        if (e.selectedRowsData.length == 1) {
            member.ResUserObjectID = e.selectedRowsData[0].ObjectID;
            member.ResUserName = e.selectedRowsData[0].ResUserName;
            member.StoreSmsUserObjectID = null;
            if(this.smsUserListDataSource.find(x=>x.ResUserObjectID == member.ResUserObjectID) == null){
                this.smsUserListDataSource.push(member);
                this.seletectResDataSource = member;
            }else{
                TTVisual.InfoBox.Alert("Kullanıcı Zaten Listede Var.");
            }
           
        }
    }
}


export class MainStoreDefinitionListDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public IsActive: boolean;
}

export class GetMainStoreDefinition {
    public mainStoreDefinitionListDTOs: Array<MainStoreDefinitionListDTO>;
    public ResUserDataSources: Array<ResUserDataSource> = new Array<ResUserDataSource>();
    public AccotuntancyDataSource: Array<AccoutancyDataSource> = new Array<AccoutancyDataSource>();
}

export class GetMainStoreDefinition_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}


export class MainStoreDefinitionOutputItem {
    public isNew: boolean;
    public ObjectID: Guid;
    public Name: string;
    public Qref: string;
    public IsActive: boolean;
    public StoreCode: string;
    public Accountancy: Guid;
    public IntegrationScope: MKYS_EEntegrasyonDurumuEnum;
    public StoreRecordNo: number;
    public UnitRecordNo: number;
    public MKYS_ButceTuru: MKYS_EButceTurEnum;
    public Status: OpenCloseEnum;
    public GoodsAccountant: StoreResponsibleDTO;
    public GoodsResponsible: StoreResponsibleDTO;
    public AccountManager: StoreResponsibleDTO;
    public StoreSMSUsers: Array<SmsUserDTO>;
}

export class StoreResponsibleDTO {
    @Type(() => Guid)
    public ReUserObjectID: Guid;
    public ResUserName: string;
}

export class ResUserDataSource {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ResUserName: string;
}

export class AccoutancyDataSource {
    @Type(() => Guid)
    public ObjectID: Guid;
    public AccountancyName: string;
}

export class SmsUserDTO {
    public StoreSmsUserObjectID: Guid;
    public ResUserObjectID: Guid;
    public ResUserName: string;
}