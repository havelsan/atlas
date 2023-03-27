import { Component, Input, ViewChild } from '@angular/core';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { UserHelper } from 'app/Helper/UserHelper';
import { Episode, EpisodeAction, Material, ResSection, StockActionDetailStatusEnum, Store, SubEpisode } from 'app/NebulaClient/Model/AtlasClientModel';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { DxDataGridComponent, DxDropDownBoxComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ResourceService } from 'app/NebulaClient/Services/ObjectService/ResourceService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ShowBox } from 'app/NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'emergecy-order-component',
    templateUrl: './EmergencyOrderComponent.html',
})

export class EmergencyOrderComponent implements IModal {
    private _modalInfo: ModalInfo;
    public StoreList: Array<Store>;
    public selectedStore: Array<Store> = new Array<Store>();
    public searchText: string;
    materialDataSource: DataSource;
    filterMaterial: string;
    selectedMaterialItem: any = {};
    public Desciption: string;
    public EmergecyOrderMaterialGridDataSource: Array<EmergecyOrderMaterial> = new Array<EmergecyOrderMaterial>();
    EmergencyOrderDetailComp: Array<EmergecyOrderDetailDTO> = new Array<EmergecyOrderDetailDTO>();
    EmergencyOrderDetailWait: Array<EmergecyOrderDetailDTO> = new Array<EmergecyOrderDetailDTO>();
    public patientInfo: any;

    constructor(protected httpService: NeHttpService, private modalStateService: ModalStateService, private objectContextService: ObjectContextService) {
    }

    public setInputParam(value: any) {
        this.setStore();
        this.patientInfo = value;
        this.getEmergencyOrderDetail();
    }

    public async setStore() {
        this.StoreList = await UserHelper.UseUserResourcesStores;
        let getStore = await ResourceService.GetStore(this.patientInfo.masterResource.toString());
        this.selectedStore.push(this.StoreList.find(x => x.ObjectID.toString() == getStore.ObjectID.toString()));
        this.setTreatmentMaterialFilterExpression(this.selectedStore[0]);

    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public closeClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    @ViewChild('materialDrop') materialDrop: DxDropDownBoxComponent;
    selectMaterial(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedMaterialItem = e.data;
        this.materialSelected(e.data);
        this.materialDrop.instance.close();
        this.onClearMaterial(null);
    }


    public onClearMaterial(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedMaterialItem = {};
        }
    }

    public EmergecyOrderMaterialListColumns = [
        {
            caption: i18n("M12615", "Sarf Malzeme"),
            name: "material",
            dataField: "material.Name",
            width: '65%',
            allowEditing: false
        },
        {
            caption: i18n("M19030", "Miktar"),
            name: "amount",
            dataField: "amount",
            cellTemplate: "AmountCellTemplate",
            alignment: "center",
            width: '15%',
            allowEditing: true
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            name: "Distributiontypename",
            alignment: "center",
            dataField: "material.Distributiontypename", //StockCard.DistributionType.DistributionType",
            width: '15%',
            allowEditing: false
        },
        {
            caption: i18n("M27286", "Sil"),
            name: "RowDelete",
            alignment: "center",
            width: '5%',
            cellTemplate: "deleteCellTemplate",
        },
    ];

    @ViewChild('materialGrid') materialGrid: DxDataGridComponent;
    public materialGridColumns = [
        {
            'caption': "Barkod",
            dataField: 'Barcode',
            width: 100,
            allowSorting: true
        },
        {
            'caption': "Malzeme Adı",
            dataField: 'Stockcardname',
            width: 250,
            allowSorting: true
        },
        {
            'caption': "Barkod Adı",
            dataField: 'Name',
            width: 250,
            allowSorting: true
        },
        {
            'caption': "Mevcut",
            dataField: 'Inheld',
            width: 80,
            allowSorting: true
        },
        {
            'caption': "Dağıtım Şekli",
            dataField: 'Distributiontypename',
            width: 100,
            allowSorting: true
        }
    ];

    public EmergencyOrderDetailCompGridColumns = [
        {
            dataField: 'detailObjectId',
            visible: false
        },
        {
            dataField: 'materialObjectID',
            visible: false
        },
        {
            caption: 'Uygulama Tarihi',
            dataField: 'orderDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: '15%',
            sortOrder: 'desc',
            allowEditing: false,
        },
        {
            caption: "Malzeme",
            dataField: 'materialName',
            width: '55%',
            allowEditing: false,
        },
        {
            caption: "Miktar",
            dataField: 'amount',
            width: '10%',
            allowEditing: false,
        },
        {
            caption: "Durumu",
            dataField: 'status',
            width: '10%',
            allowEditing: false,
            lookup: { dataSource: StockActionDetailStatusEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' }
        }, {
            caption: 'İptal Et',
            name: "RowDelete",
            alignment: "center",
            width: '10%',
            cellTemplate: "deleteCellTemplate",
        }];

    public EmergencyOrderDetailWaitGridColumns = [
        {
            dataField: 'detailObjectId',
            visible: false
        },
        {
            dataField: 'materialObjectID',
            visible: false
        },
        {
            caption: 'Uygulama Tarihi',
            dataField: 'orderDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: '11%',
            sortOrder: 'desc',
            allowEditing: false,
        },
        {
            caption: "Malzeme",
            dataField: 'materialName',
            width: '55%',
            allowEditing: false,
        },
        {
            caption: i18n("M19030", "Miktar"),
            name: "amount",
            dataField: "amount",
            cellTemplate: "AmountCellTemplate",
            alignment: "center",
            width: '10%',
            allowEditing: true
        },
        {
            caption: "Durumu",
            dataField: 'status',
            width: '10%',
            allowEditing: false,
            lookup: { dataSource: StockActionDetailStatusEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' }
        },
        {
            caption: 'Güncelle',
            name: "RowUpdate",
            alignment: "center",
            width: '7%',
            cellTemplate: "updateCellTemplate",
        },
        {
            caption: 'İptal Et',
            name: "RowDelete",
            alignment: "center",
            width: '7%',
            cellTemplate: "deleteCellTemplate",
        }];


    openMaterialDropDown(e: any) {
        this.getNewMaterialDataSource();
    }


    public materialSelected(material: any) {

        let emgMat: EmergecyOrderMaterial = new EmergecyOrderMaterial();
        emgMat.material = material;
        emgMat.amount = 1;

        if (this.EmergecyOrderMaterialGridDataSource.length > 0) {
            if (this.EmergecyOrderMaterialGridDataSource.filter(x => x.material.ObjectID == material.ObjectID).length > 0) {
                ServiceLocator.MessageService.showError("Aynı ilaç eklemessiniz");
            }
            else {
                this.EmergecyOrderMaterialGridDataSource.push(emgMat);
            }
        }
        else {
            this.EmergecyOrderMaterialGridDataSource.push(emgMat);
        }
    }

    async setTreatmentMaterialFilterExpression(store: Store) {
        let filterString: string = '""';
        if (store) {
            filterString = 'THIS.OBJECTDEFNAME IN (\'DRUGDEFINITION\') ';//\'CONSUMABLEMATERIALDEFINITION\',
            if (store.ObjectID == null) {
                filterString = filterString + ' AND STOCKS.INHELD>0 AND STOCKS.STORE = \'' + await store + '\'';
            } else {
                filterString = filterString + ' AND STOCKS.INHELD>0 AND STOCKS.STORE = \'' + await store.ObjectID.toString() + '\'';
            }

            this.filterMaterial = filterString;
        } else {
            filterString = '1=0';
            this.filterMaterial = filterString;
        }
    }

    async onAmountChanged(data, row) {
        row.data.amount = data.value;
        this.datagrid.instance.refresh();
    }

    async onAmountUpdateChanged(data, row) {
        row.data.amount = data.value;
    }

    getNewMaterialDataSource() {
        this.materialDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: this.searchText,
                        definitionName: 'AllowedConsumableMaterialAndDrugList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/NewMaterialSelectComponent/GetTreatmentMaterialList?filterExpretion=' + this.filterMaterial, loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    @ViewChild('emergecyOrderGrid') datagrid: DxDataGridComponent;
    gridEmergecyOrderMaterialGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.IsNew) {
                        this.datagrid.instance.deleteRow(data.rowIndex);

                    }
                    else {
                        data.key.EntityState = EntityStateEnum.Cancelled;
                        this.datagrid.instance.filter(['EntityState', '<>', 4]);
                        this.datagrid.instance.refresh();
                    }
                    this.EmergecyOrderMaterialGridDataSource = this.EmergecyOrderMaterialGridDataSource.filter(x => x.material.ObjectID != data.row.data.material.ObjectID);
                }
            }
        }
    }

    closePopupOK() {
        //this.loadingVisible = true;
        if (this.EmergecyOrderMaterialGridDataSource.length == 0) {
            ServiceLocator.MessageService.showError("Detay Girmeden Devam Edemessiniz!");
            return;
        }

        let that = this;
        let fullApiUrl: string = 'api/EmergencyOrderService/saveEmergencyOrder';
        let input: EmergecyOrderDTO = new EmergecyOrderDTO();
        input.emergecyOrderMaterials = this.EmergecyOrderMaterialGridDataSource;
        input.episodeActionId = this.patientInfo.episodeActionId;
        input.episodeId = this.patientInfo.episodeId;
        input.patientId = this.patientInfo.patientId;
        input.store = this.selectedStore[0].ObjectID;
        input.desciption = this.Desciption;

        this.httpService.post<string>(fullApiUrl, input)
            .then((res) => {
                ServiceLocator.MessageService.showSuccess(res);
                this.getEmergencyOrderDetail();
                this.EmergecyOrderMaterialGridDataSource = new Array<EmergecyOrderMaterial>();
            })
            .catch(error => {
                ServiceLocator.MessageService.showSuccess(error);
                this.closeClick();
            });
    }
    closePopupCancel() {
        this.closeClick();
    }

    public getEmergencyOrderDetail() {
        let that = this;
        this.EmergencyOrderDetailComp = new Array<EmergecyOrderDetailDTO>();
        this.EmergencyOrderDetailWait = new Array<EmergecyOrderDetailDTO>();
        let fullApiUrl: string = 'api/EmergencyOrderService/getEmergencyOrderDetails';
        let input: EmergecyOrderDetailInput_DTO = new EmergecyOrderDetailInput_DTO();
        input.episodeActionID = this.patientInfo.episodeActionId;
        this.httpService.post<Array<EmergecyOrderDetailDTO>>(fullApiUrl, input)
            .then((res) => {
                for (let item of res) {
                    if (item.status != 0) {
                        this.EmergencyOrderDetailComp.push(item);
                    } else {
                        this.EmergencyOrderDetailWait.push(item);
                    }
                }
            })
            .catch(error => {
                ServiceLocator.MessageService.showSuccess(error);
            });
    }

    @ViewChild('emergecyOrderGridComp') datagridComp: DxDataGridComponent;
    async gridEmergecyOrderMaterialCompGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.status == 3) {
                        let result1: string =
                            await ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", i18n("M23735", "Uyarı"), i18n("M18921", "Order İptal!"), "Bu order iptal edilecektir.Faturadan silinecektir." + "\r\n" + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                        if (result1 == "T") {
                            this.cancelEmergencyOrderDetail(data.row.key.detailObjectId,data.row.key.status).then(x=>{
                                data.row.key.status=this.actionStatus;
                                this.datagridComp.instance.refresh();
                            });
                        }
                    }
                    else if (data.row.key.status == 0) { //yeni
                        //daha hemşire uygulamadı.
                        let result2: string =
                            await ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", i18n("M23735", "Uyarı"), i18n("M18921", "Order İptal!"), "Bu order iptal edilecektir." + "\r\n" + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                        if (result2 == "T") {
                            this.cancelEmergencyOrderDetail(data.row.key.detailObjectId,data.row.key.status).then(x=>{
                                data.row.key.status=this.actionStatus;
                                this.datagridComp.instance.refresh();
                            });
                        }
                    }
                    else {
                        ServiceLocator.MessageService.showInfo('İptal edilen bir order tekrar iptal edilemez.');
                    }
                }
            }
        }
        if (data.column.name == "RowUpdate") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.status == 0) {
                        await this.updateAmountEmergencyOrderDetail(data.row.key.detailObjectId, data.row.key.amount);
                        ServiceLocator.MessageService.showInfo("Miktar Güncellendi.");
                    }
                }
            }
        }
    }

    
    actionStatus: StockActionDetailStatusEnum;
    async cancelEmergencyOrderDetail(detailObjectID: Guid,status:any) {
        let that = this;
        let fullApiUrl: string = 'api/EmergencyOrderService/cancelEmergencyOrderDetail';
        let input: CancelEmergecyOrderDetailInput_DTO = new CancelEmergecyOrderDetailInput_DTO();
        input.detailObjectId = detailObjectID;

       await this.httpService.post<CancelEmergecyOrderDetailOutput_DTO>(fullApiUrl, input)
            .then((res) => {
                this.actionStatus = res.status;
                ServiceLocator.MessageService.showInfo(res.message);
                if (this.actionStatus == 3) {
                    ServiceLocator.MessageService.showError("Fatura işlemi iptali sırasında hata alınmıştır.");
                } else {
                    status = this.actionStatus;
                    ServiceLocator.MessageService.showSuccess("İptal işlemi gerçekleştirilmiştir.");
                }
            })
            .catch(error => {
                ServiceLocator.MessageService.showSuccess(error);
            });
    }


    amountMaterial: number;
    public updateAmountEmergencyOrderDetail(detailObjectID: Guid, amount: number) {
        let that = this;
        let fullApiUrl: string = 'api/EmergencyOrderService/updateAmountEmergencyOrderDetail';
        let input: UpdateEmergecyOrderDetailInput_DTO = new UpdateEmergecyOrderDetailInput_DTO();
        input.detailObjectId = detailObjectID;
        input.amount = amount;
        this.httpService.post<number>(fullApiUrl, input)
            .then((res) => {
                this.amountMaterial = res;
            })
            .catch(error => {
                ServiceLocator.MessageService.showSuccess(error);
            });
    }

}

export class GetEpisodeActionByID_Input {
    public ID: string;
}


export class EmergecyOrderMaterial {
    public material: Material;
    public amount: number;
}

export class EmergecyOrderDTO {
    public store: Guid;
    public episodeActionId: string;
    public episodeId: string;
    public patientId: string;
    public emergecyOrderMaterials: Array<EmergecyOrderMaterial>;
    public desciption: string;
}
export class EmergecyOrderDetailDTO {
    public orderDate: Date;
    public materialName: string;
    public detailObjectId: Guid;
    public amount: number;
    public status: StockActionDetailStatusEnum;
    public materialObjectID: string;
    public desciption: string;
}
export class EmergecyOrderDetailInput_DTO {
    public episodeActionID: Guid;
}
export class CancelEmergecyOrderDetailInput_DTO {
    public detailObjectId: Guid;
}
export class UpdateEmergecyOrderDetailInput_DTO {
    public detailObjectId: Guid
    public amount: number;
}
export class CancelEmergecyOrderDetailOutput_DTO {
    public status: StockActionDetailStatusEnum;
    public message:string;
}
