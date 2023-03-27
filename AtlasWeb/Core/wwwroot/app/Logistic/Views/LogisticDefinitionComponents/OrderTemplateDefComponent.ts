import { Component, ViewChild, OnInit } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { CommisionTypeEnum, SignUserTypeEnum, ResUser, DrugOrderTypeEnum, DrugUsageTypeEnum, Material, HospitalTimeSchedule, OrderTemplateStatusEnum, DrugShapeTypeEnum, Resource, SpecialityDefinition, UserResource } from 'app/NebulaClient/Model/AtlasClientModel';
import { LogDataSource } from 'Modules/Core_Destek_Modulleri/Log_Modulu/AuditQueryFormViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Type } from 'NebulaClient/ClassTransformer';
import { ControlOfDefinitionRole } from 'app/Logistic/Models/MainViewModel';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { DxDataGridComponent } from 'devextreme-angular';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { MessageService } from 'app/Fw/Services/MessageService';
import { DrugOrderIntroductionService, DrugInfo, DrugIngredient } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import DataSource from 'devextreme/data/data_source';
import { FavoriteDrugService } from 'app/NebulaClient/Services/ObjectService/FavoriteDrugService';
import { UserHelper } from 'app/Helper/UserHelper';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IAuditObjectService, AuditObject } from 'app/Fw/Services/IAuditObjectService';
import { IModalService } from 'app/Fw/Services/IModalService';
@Component({
    selector: "ordertemplatedef-component",
    templateUrl: './OrderTemplateDefComponent.html',
    providers: [SystemApiService, MessageService]


})
export class OrderTemplateDefComponent implements IModal, OnInit {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public orderTemplateDefinitionSource: Array<OrderTemplateDefinitionDataSource> = new Array<OrderTemplateDefinitionDataSource>();
    public timeScheduleDataSource: Array<HospitalTimeSch>;
    public selectedItemFromOpen: boolean = false;
    public activeOrderTemplateDefinition: OrderTemplateDefinitionInputDTO = new OrderTemplateDefinitionInputDTO();
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public selectionGridObjectID: any;
    public isActive: boolean;
    public DrugOrderType: Array<EnumItem> = DrugOrderTypeEnum.Items;
    public DrugUsageType: Array<EnumItem> = DrugUsageTypeEnum.Items;
    public OrderTemplateStatus: Array<EnumItem> = OrderTemplateStatusEnum.Items;

    public clinicSeleted: boolean = false;
    public bransSeleted: boolean = false;

    public SeletedResource:Guid;
    public SeletedSpecialityDef:Guid;


    constructor(private http: NeHttpService) {
      
    }

   async ngOnInit() {
        this.getAllOrderTemplateDefinition();
    }

    public searchText = '';
    public isInheldDrugList = false;
    public isFavoriteDrugList = false;
    public drugSource: DataSource;
    public drugSearchEnabled: boolean;
    public inheldDrugList: Array<DrugInfo> = new Array<DrugInfo>();
    public selectedActiveIngeridents: Array<DrugIngredient> = new Array<DrugIngredient>();
    public searchIsPatientOwnDrug = false;
    public favoriteDrugs: Array<DrugInfo>;
    public selectedDrugListItems: Array<DrugInfo> = new Array<DrugInfo>();

    public UserResources: Array<OrderTempleateUserResurce> = Array<OrderTempleateUserResurce>();
    public UserSpecialityDefinitions: Array<OrderTemplateSpecialityDefinition> = Array<OrderTemplateSpecialityDefinition>();

    onOrderTemplateStatus(data: any) {
        this.clinicSeleted = false;
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
        }
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
            auditObject.AuditObjectID = this.activeOrderTemplateDefinition.ObjectID;
            auditObject.AuditObjectDefID = new Guid("bf7466b4-fb48-46fc-813d-84d3002d4d03");
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


    public async onFavoriteDrugListValueChanged(e: any) {
        this.searchText = '';
        if (e.value === true) {

            //if (this.favoriteDrugs === undefined) {
            let user: ResUser = await UserHelper.CurrentResource;
            this.favoriteDrugs = await FavoriteDrugService.GetFavoriteDrugsWithResUser(user.ObjectID, this.isInheldDrugList, this.selectedActiveIngeridents);
            //}

            this.drugSource = new DataSource({
                store: this.favoriteDrugs,
                searchOperation: 'contains',
                searchExpr: 'name'
            });
            this.searchIsPatientOwnDrug = false;
            this.OpenSearchList();
        } else {
            if (this.searchIsPatientOwnDrug === false) {
                this.drugSource = new DataSource({
                });
                this.CloseSearchList();
            }
        }
    }
    public CloseSearchList() {
        this.searchText = '';
        this.isFavoriteDrugList = false;
        this.drugSearchEnabled = false;
        this.isInheldDrugList = false;
        this.searchIsPatientOwnDrug = false;
    }

    public async onSearchValueChanged(event) {
        let drugs: Array<DrugInfo>;
        if (this.isFavoriteDrugList === false) {
            if (event.value.length === 0) {
                if (this.isInheldDrugList === false) {
                    this.drugSource = new DataSource({
                    });
                    this.isFavoriteDrugList = false;
                    this.drugSearchEnabled = false;
                } else {
                    if (this.inheldDrugList.length > 0) {
                        this.drugSource = new DataSource({
                            store: this.inheldDrugList,
                        });
                    } else {
                        drugs = await DrugOrderIntroductionService.SearchDrug(this.searchText, this.isInheldDrugList, this.selectedActiveIngeridents);
                        this.drugSource = new DataSource({
                            store: drugs,
                        });
                    }
                    this.drugSearchEnabled = true;
                }
            }
            if (event.value.length > 2) {
                drugs = await DrugOrderIntroductionService.SearchDrug(event.value.toString(), this.isInheldDrugList, this.selectedActiveIngeridents);
                this.drugSource = new DataSource({
                    store: drugs,
                });
                if (drugs != null)
                    this.OpenSearchList();
            }
        }


        if (this.isFavoriteDrugList === true) {
            if (this.drugSource !== undefined) {
                this.drugSource.searchValue(event.value);
                this.drugSource.load();
            }
        }
    }
    public OpenSearchList() {
        this.drugSearchEnabled = true;
    }

    public async onInheldValueChanged(event) {
        if (this.isFavoriteDrugList === true) {
            let user: ResUser = await UserHelper.CurrentResource;
            this.favoriteDrugs = await FavoriteDrugService.GetFavoriteDrugsWithResUser(user.ObjectID, this.isInheldDrugList, this.selectedActiveIngeridents);
            this.OpenSearchList();
            this.drugSource = new DataSource({
                store: this.favoriteDrugs,
            });
            this.drugSource.searchValue(this.searchText);
            this.drugSource.load();
        } else if (this.isInheldDrugList) {
            let drugs: Array<DrugInfo> = await DrugOrderIntroductionService.SearchDrug(this.searchText, this.isInheldDrugList, this.selectedActiveIngeridents);
            this.OpenSearchList();
            this.drugSource = new DataSource({
                store: drugs,
            });
            this.inheldDrugList = drugs;
        } else {
            let drugs: Array<DrugInfo> = new Array<DrugInfo>();
            this.drugSource = new DataSource({
            });
            this.CloseSearchList();
        }
    }


    public drugListOnItemClick(event) {
        if (event.itemData == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else {
            let material = new Material();
            material.ObjectID = new Guid(event.itemData.drugObjectId);
            material.Name = event.itemData.name;
            let contaisMat = this.activeOrderTemplateDefinition.OrderTemplateDetails.find(x => x.MaterialObjectID == event.itemData.drugObjectId);
            if (contaisMat == null) {
                let newRow: OrderTemplateDetailDTO = new OrderTemplateDetailDTO();
                newRow.MaterialName = material.Name;
                newRow.MaterialObjectID = material.ObjectID;
                this.activeOrderTemplateDefinition.OrderTemplateDetails.push(newRow);
                this.CloseSearchList();
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
        }
    }


    public GetDrugItemWithType(drugShapeTypeEnum: DrugShapeTypeEnum) {

        if (drugShapeTypeEnum == null) {
            return "../../Content/DrugShapes/dragee.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Ampul) {
            return "../../Content/DrugShapes/ampul.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Granul) {
            return "../../Content/DrugShapes/granul-şase.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Sase) {
            return "../../Content/DrugShapes/granul-şase.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Hap) {
            return "../../Content/DrugShapes/kapsul.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Losyon) {
            return "../../Content/DrugShapes/solüsyon-süspansiyon.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Solusyon) {
            return "../../Content/DrugShapes/solüsyon-süspansiyon.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Süspansiyon) {
            return "../../Content/DrugShapes/solüsyon-süspansiyon.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Krem) {
            return "../../Content/DrugShapes/pomad-krem.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Pomad) {
            return "../../Content/DrugShapes/pomad-krem.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Ovul) {
            return "../../Content/DrugShapes/ovul-supozituar.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Supozituar) {
            return "../../Content/DrugShapes/ovul-supozituar.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Toz) {
            return "../../Content/DrugShapes/toz.png";
        } else if (drugShapeTypeEnum == DrugShapeTypeEnum.Tablet) {
            return "../../Content/DrugShapes/tablet.png";
        } else {
            return "../../Content/DrugShapes/dragee.png";
        }
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

    orderTemplateDefintiionDataColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: 'Şablon Adı',
            dataField: 'Name',
            width: 300,
            sortOrder: 'desc',
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];


    selectionGridEvent(e) {
        if (e.selectedRowsData != null && e.selectedRowsData.length > 0) {
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GetOrderTemplateDefinition_Input = new GetOrderTemplateDefinition_Input();
            input.ObjectID = e.selectedRowsData[0].ObjectID;
            let fullApiUrl: string = 'api/OrderTemplateDefintion/getOrderTemplateDefinition';
            this.http.post<OrderTemplateDefinitionInputDTO>(fullApiUrl, input)
                .then((res) => {
                    this.activeOrderTemplateDefinition = res as OrderTemplateDefinitionInputDTO;
                    this.SeletedResource = this.activeOrderTemplateDefinition.Resource;
                    this.SeletedSpecialityDef = this.activeOrderTemplateDefinition.SpecialityDefinition;
                    this.isActive = this.activeOrderTemplateDefinition.IsActive;
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


    getAllOrderTemplateDefinition() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/OrderTemplateDefintion/getAllOrderTemplateDefinition';
        this.http.post<GetOrderTemlplateDefinition>(fullApiUrl, null)
            .then((res) => {
                that.orderTemplateDefinitionSource = res.OrderTemplateDefinitionDataSourceList as Array<OrderTemplateDefinitionDataSource>;
                that.timeScheduleDataSource = res.HospitalTimeScheduleList as Array<HospitalTimeSch>;
                that.UserResources = res.UserResources as Array<OrderTempleateUserResurce>;
                that.UserSpecialityDefinitions = res.UserSpecialityDefinitions as Array<OrderTemplateSpecialityDefinition>;
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
        this.activeOrderTemplateDefinition = new OrderTemplateDefinitionInputDTO();
        this.activeOrderTemplateDefinition.isNew = true;
        this.activeOrderTemplateDefinition.IsActive = true;
        this.isActive = true;
        this.activeOrderTemplateDefinition.OrderTemplateDetails = new Array<OrderTemplateDetailDTO>();

    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.clearData();
    }

    Save() {

        this.loadingVisible = true;
        if (this.activeOrderTemplateDefinition != null) {
            if (String.isNullOrEmpty(this.activeOrderTemplateDefinition.Name)) {
                ServiceLocator.MessageService.showError("Şablon Adı Boş Olamaz!");
                this.loadingVisible = false;
                return;
            }
        }
        if (this.activeOrderTemplateDefinition.OrderTemplateDetails.length == 0) {
            ServiceLocator.MessageService.showError("Şablon için order birgileri Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }
        if (this.activeOrderTemplateDefinition.OrderTemplateStatus == null) {
            ServiceLocator.MessageService.showError("Şablon tipi Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        if(this.bransSeleted == true &&  this.SeletedResource ==  Guid.Empty){
            ServiceLocator.MessageService.showError("Şablon tipi Branş Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        if(this.clinicSeleted == true && this.SeletedSpecialityDef == Guid.Empty){
            ServiceLocator.MessageService.showError("Şablon tipi Klinik Boş Olamaz!");
            this.loadingVisible = false;
            return;
        }

        this.activeOrderTemplateDefinition.SpecialityDefinition = this.SeletedSpecialityDef;
        this.activeOrderTemplateDefinition.Resource = this.SeletedResource;

        let that = this;
        let fullApiUrl: string = 'api/OrderTemplateDefintion/saveObject';
        this.http.post(fullApiUrl, that.activeOrderTemplateDefinition)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                // this.selectedItemFromOpen = false;
                this.getAllOrderTemplateDefinition();
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }
}

export class OrderTemplateDefinitionInputDTO {
    public isNew: boolean;
    public ObjectID: Guid;
    public OrderTemplateStatus: OrderTemplateStatusEnum;
    public Name: string;
    public IsActive: boolean;
    public OrderTemplateDetails: Array<OrderTemplateDetailDTO>;
    public Resource: Guid;
    public SpecialityDefinition: Guid;
}
export class OrderTemplateDetailDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Description: string;
    public DoseAmount: number;
    public DrugOrderType: DrugOrderTypeEnum;
    public DrugUsageType: DrugUsageTypeEnum;
    public MaterialName: string;
    public MaterialObjectID: Guid;
    public HospitalTimeSchedule: HospitalTimeSchedule;
}

export class OrderTemplateDefinitionDataSource {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public IsActive: boolean;
    public OrderTemplateStatus: OrderTemplateStatusEnum;
}

export class GetOrderTemlplateDefinition {
    public HospitalTimeScheduleList: Array<HospitalTimeSch>;
    public OrderTemplateDefinitionDataSourceList: Array<OrderTemplateDefinitionDataSource>;
    public UserResources: Array<OrderTempleateUserResurce>;
    public UserSpecialityDefinitions: Array<OrderTemplateSpecialityDefinition>;
}


export class OrderTempleateUserResurce {
    @Type(() => Guid)
    public ResourceObjectID: Guid;
    public ResourceName: string;
}
export class OrderTemplateSpecialityDefinition {
    @Type(() => Guid)
    public SpecialityDefObjectID: Guid;
    public SpecialityDefName: string;
}


export class GetOrderTemplateDefinition_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}

export class HospitalTimeSch {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
}