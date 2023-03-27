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
import { OpenCloseEnum, MKYS_ECikisStokHareketTurEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';

@Component({
    selector: "subStoreDefinition-component",
    templateUrl: './SubStoreDefinitionComponent.html',
    providers: [SystemApiService, MessageService]


})
export class SubStoreDefinitionComponent implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public subStoreDefinitionListDTOs: Array<SubStoreDefinitionListDTO> = new Array<SubStoreDefinitionListDTO>();
    public activeSubStoreDefinitionItem: SubStoreDefinitionOutputItem = new SubStoreDefinitionOutputItem();
    
    public selectedSubStoreDefinitionItem: SubStoreDefinitionListDTO;

    
    public SubStoreStatus: Array<EnumItem> = OpenCloseEnum.Items;
    public MKYSCikisHareketTuru: Array<EnumItem> = MKYS_ECikisStokHareketTurEnum.Items;

    public selectedItemFromOpen: boolean = false;
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public selectionGridObjectID: any;
    public isActive: boolean;


    public resUserDataSource: Array<ResUserDataSource> = new Array<ResUserDataSource>();


    constructor(private http: NeHttpService) {
        this.getSubStoreDefinition();
        this.activeSubStoreDefinitionItem.StoreResponsible = new StoreResponsibleDTO();
        this.activeSubStoreDefinitionItem.StoreResponsible.ResUserName ="";
    }

    onMKYSCikisHareketTuru(data: any) {}
    onStatus(data: any) {
        /* this.clinicSeleted = false;
        this.bransSeleted = false;
        if (this.activeOrderTemplateDefinition.OrderTemplateStatus != null) {
            if(this.activeOrderTemplateDefinition.OrderTemplateStatus == OrderTemplateStatusEnum.JustMyBranch){
                this.bransSeleted = true;
                this.activeOrderTemplateDefinition.Resource = new Guid();
                this.activeOrderTemplateDefinition.SpecialityDefinition =new Guid();
            }
            if(this.activeOrderTemplateDefinition.OrderTemplateStatus == OrderTemplateStatusEnum.OnlyMyClinic){
                this.clinicSeleted = true;
                this.activeOrderTemplateDefinition.Resource = new Guid();
                this.activeOrderTemplateDefinition.SpecialityDefinition =new Guid();
            }
        } */
    }

    public CreatToMkys(){
        if (this.activeSubStoreDefinitionItem.SubStoreMKYS != null) {
            ServiceLocator.MessageService.showError("MKYS sistemine daha önce kaydı yapılmıştır.!");
            this.loadingVisible = false;
            return;
        }

        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/SubStoreDefinition/CreatToMkys';
        this.http.post(fullApiUrl, that.activeSubStoreDefinitionItem)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                this.getSubStoreDefinition();
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
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
            auditObject.AuditObjectID = this.activeSubStoreDefinitionItem.ObjectID;
            auditObject.AuditObjectDefID = new Guid("009d82e7-40a9-444f-b8c6-a3ca69eca81c");
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

    subStoreDefinitionColumn = [
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
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GetSubStoreDefinition_Input = new GetSubStoreDefinition_Input();
            input.ObjectID = value.data.ObjectID;

            let fullApiUrl: string = 'api/SubStoreDefinition/getSubStoreDefinitionItem';
            this.http.post<SubStoreDefinitionOutputItem>(fullApiUrl, input)
                .then((res) => {
                    this.activeSubStoreDefinitionItem = res as SubStoreDefinitionOutputItem;
                    if (this.activeSubStoreDefinitionItem.StoreResponsible == null) {
                        let member: StoreResponsibleDTO = new StoreResponsibleDTO();
                        member.ResUserName = "Kullanıcı Seçiniz...";
                        this.activeSubStoreDefinitionItem.StoreResponsible = member;
                    }
                    this.isActive = this.activeSubStoreDefinitionItem.IsActive;
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


    getSubStoreDefinition() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/SubStoreDefinition/getAllSubStoreDefinition';
        this.http.post<GetSubStoreDefinition>(fullApiUrl, null)
            .then((res) => {
                that.subStoreDefinitionListDTOs = res.subStoreDefinitionListDTOs as Array<SubStoreDefinitionListDTO>;
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
        this.activeSubStoreDefinitionItem = new SubStoreDefinitionOutputItem();
        this.activeSubStoreDefinitionItem.isNew = true;
        this.activeSubStoreDefinitionItem.IsActive = true;
        this.activeSubStoreDefinitionItem.AutoReturningDocumentCreat = false;
        this.activeSubStoreDefinitionItem.IsEmergencyStore = false;
        this.activeSubStoreDefinitionItem.StoreResponsible = new StoreResponsibleDTO();
        this.activeSubStoreDefinitionItem.SubStoreMKYS = null;
        this.activeSubStoreDefinitionItem.SubStoreMKYSName = "";
        this.isActive = true;
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.clearData();
        this.selectedSubStoreDefinitionItem = null;
    }

    Save() {

        if (this.activeSubStoreDefinitionItem.Name == null) {
            ServiceLocator.MessageService.showError("Cep Depo Adı Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }


        this.activeSubStoreDefinitionItem.IsActive = this.isActive;

        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/SubStoreDefinition/saveObject';
        this.http.post(fullApiUrl, that.activeSubStoreDefinitionItem)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                this.getSubStoreDefinition();
                this.activeSubStoreDefinitionItem.isNew = false;
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
        let member: StoreResponsibleDTO = new StoreResponsibleDTO();
        if (e.selectedRowsData.length == 1) {
            member.ReUserObjectID = e.selectedRowsData[0].ObjectID;
            member.ResUserName = e.selectedRowsData[0].Name;
            this.activeSubStoreDefinitionItem.StoreResponsible = member;
        }

    }

}


export class SubStoreDefinitionListDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public IsActive: boolean;
}

export class GetSubStoreDefinition {
    public subStoreDefinitionListDTOs: Array<SubStoreDefinitionListDTO>;
    public ResUserDataSources: Array<ResUserDataSource> = new Array<ResUserDataSource>();
}

export class GetSubStoreDefinition_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}


export class SubStoreDefinitionOutputItem {
    public isNew: boolean;
    public ObjectID: Guid;
    public Name: string;
    public StoreResponsible: StoreResponsibleDTO;
    public Qref: string;
    public IsActive: boolean;
    public AutoReturningDocumentCreat: boolean;
    public IsEmergencyStore: boolean;
    public UnitCode: string;
    public UnitRegistryNo: number;
    public DependantUnitID: number;
    public Status: OpenCloseEnum;
    public SubStoreMKYS: Guid;
    public SubStoreMKYSName:string;
    public MKYS_CikisHareketTuru: MKYS_ECikisStokHareketTurEnum;
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