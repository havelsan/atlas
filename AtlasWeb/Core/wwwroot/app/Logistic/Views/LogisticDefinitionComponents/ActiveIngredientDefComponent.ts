import { Component, OnInit } from '@angular/core';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { SexEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import { LogDataSource } from 'Modules/Core_Destek_Modulleri/Log_Modulu/AuditQueryFormViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Type } from 'NebulaClient/ClassTransformer';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { MessageService } from 'app/Fw/Services/MessageService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IAuditObjectService, AuditObject } from 'app/Fw/Services/IAuditObjectService';
import { IModalService } from 'app/Fw/Services/IModalService';

@Component({
    selector: "activeIngredientDef-component",
    templateUrl: './ActiveIngredientDefComponent.html',
    providers: [SystemApiService, MessageService]
})

export class ActiveIngredientDefComponent implements IModal, OnInit {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public activeIngredientDefDataSource: Array<ActiveIngredientDefDataSource> = new Array<ActiveIngredientDefDataSource>();
    public selectedItemFromOpen: boolean = false;
    public activeIngredientDefinition: ActiveIngredientDefinitionDTO = new ActiveIngredientDefinitionDTO();

    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public selectionGridObjectID: any;

    public Sex: Array<EnumItem> = SexEnum.Items;
    public MaxDoseUnit: Array<MaxDoseUnitList>;



    constructor(private http: NeHttpService) {

    }

    async ngOnInit() {
        this.getActiveIngredientDef();
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
            auditObject.AuditObjectID = this.activeIngredientDefinition.ObjectID;
            auditObject.AuditObjectDefID = new Guid("34c18cf3-f9ea-43c6-8446-06e08ed3f0ac");
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

    activeIngredientDefColumns = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: "Kodu",
            dataField: 'Code',
            width: 'auto',
        },
        {
            caption: 'Etken Madde Adı',
            dataField: 'Name',
            width: 300,
            sortOrder: 'asc',
        },
    ];


    selectionGridEvent(e) {
        if (e.selectedRowsData != null && e.selectedRowsData.length > 0) {
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GettActiveIngredientDefinition_Input = new GettActiveIngredientDefinition_Input();
            input.ObjectID = e.selectedRowsData[0].ObjectID;
            let fullApiUrl: string = 'api/ActiveIngredientDefinition/getActiveIngredientDefinitionDTO';
            this.http.post<ActiveIngredientDefinitionDTO>(fullApiUrl, input)
                .then((res) => {
                    this.activeIngredientDefinition = res as ActiveIngredientDefinitionDTO;
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



    getActiveIngredientDef() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/ActiveIngredientDefinition/getActiveIngredientDef';
        this.http.post<GetActiveIngredientDefinition>(fullApiUrl, null)
            .then((res) => {
                this.activeIngredientDefDataSource = res.activeIngredientDefDataSource as Array<ActiveIngredientDefDataSource>;
                this.MaxDoseUnit = res.maxDoseUnitList as Array<MaxDoseUnitList>;
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
        this.activeIngredientDefinition.isNew  = true;
        this.activeIngredientDefinition.ActiveIngredientDefDetails = new  Array<ActiveIngredientDetailDTO>();
    }

    clearData() {
        this.lastUpdateDate = null;
        this.lastUpdateUser = "";
        this.creationDate = null;
        this.creationUser = "";
        this.activeIngredientDefinition = new ActiveIngredientDefinitionDTO();
        
    }



    Cancel() {
        this.selectedItemFromOpen = false;
    }

    Save() {

        for (let detailControl of this.activeIngredientDefinition.ActiveIngredientDefDetails) {
            if (detailControl.EndAge == null && detailControl.MaxDose == null && detailControl.MaxDoseUnit == null && detailControl.Sex == null && detailControl.StartingAge == null) {
                TTVisual.InfoBox.Alert("Boş Satır Eklediniz.");
                return;
            }
        }


        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/ActiveIngredientDefinition/saveObject';
        this.http.post(fullApiUrl, that.activeIngredientDefinition)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                // this.selectedItemFromOpen = false;
                this.getActiveIngredientDef();
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }
}

export class ActiveIngredientDefDataSource {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public Code: string;
}

export class GetActiveIngredientDefinition {
    public activeIngredientDefDataSource: Array<ActiveIngredientDefDataSource>;
    public maxDoseUnitList: Array<MaxDoseUnitList>;
}

export class GettActiveIngredientDefinition_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}


export class ActiveIngredientDefinitionDTO {
    public ObjectID: Guid;
    public Name: string;
    public Code: string;
    public ActiveIngredientDefDetails: Array<ActiveIngredientDetailDTO>;
    public isNew;
}


export class ActiveIngredientDetailDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public StartingAge: number;
    public EndAge: number;
    public MaxDose: number;
    public Sex: SexEnum;
    public MaxDoseUnit: Guid;
}

export class MaxDoseUnitList {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
}