import { Component, OnInit, ViewChild, Input, Renderer2 } from '@angular/core';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MaterialReportByExpirationDateFormViewModel } from './MaterialReportByExpirationDateFormViewModel';
import { TTUnboundForm } from "app/NebulaClient/Visual/TTUnboundForm";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { Headers, RequestOptions } from '@angular/http';
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { TransactionTypeEnum } from "app/NebulaClient/Model/AtlasClientModel";
import { DxAccordionComponent } from "devextreme-angular";
import { ModalActionResult, ModalInfo } from "app/Fw/Models/ModalInfo";
import { DynamicComponentInfo } from "app/Fw/Models/DynamicComponentInfo";
import { IModalService } from "app/Fw/Services/IModalService";
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';

@Component({
    selector: "MaterialReportByExpirationDateForm",
    templateUrl: './MaterialReportByExpirationDateForm.html',
    providers: [SystemApiService, MessageService]
})

export class MaterialReportByExpirationDateForm extends TTUnboundForm implements OnInit {
    public MaterialReportByExpirationDateFormViewModel: MaterialReportByExpirationDateFormViewModel;
    public DayQueryNumber: number;
    private _StoreObjectId: string;
    public MaterialList: Array<MaterialItem> = new Array<MaterialItem>();
    public SelectedMaterials: Array<Guid> = new Array<Guid>();
    public StartDate: Date;
    public EndDate: Date;
    public visibility: boolean = false;
    public OnlyInStore: boolean;
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    public storeListFiltred: string ="";
    @ViewChild('materialActionDetayAccordion') materialActionDetayAccordion: DxAccordionComponent;

    public WorkListColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            width: 50
        },
        {
            'caption': i18n("M16866", "İşlem No"),
            dataField: 'StockActionID',
            width: 100,
            allowSorting: true
        },
        {
            'caption': i18n("M17307", "Karşı Depo Adı"),
            dataField: 'DestinationStore',
            dataType: 'string',
            width: 250,
            allowSorting: true
        },
        {
            'caption': i18n("M16886", "İşlem Tarihi"),
            dataField: 'TransactionDate',
            width: 160,
            allowSorting: true,
            dataType: 'date',
            format: "dd/MM/yyyy"
        },
        {
            'caption': i18n("M15101", "Haraket Tipi"),
            dataField: 'StockActionType',
            dataType: 'string',
            width: 300,
            allowSorting: true,
            lookup: { dataSource: this.TransactionTypes, valueExpr: 'code', displayExpr: 'description' }
        },
        {
            'caption': i18n("M15133", "Hasta Adı Soyadı"),
            dataField: 'PatientName',
            dataType: 'string',
            width: 300,
            allowSorting: true
        },
        {
            'caption': i18n("M19030", "Miktar"),
            dataField: 'Amount',
            width: 100,
            allowSorting: true
        },
        {
            'caption': i18n("M16818", "İşlem"),
            dataField: 'StockactionName',
            dataType: 'string',
            width: 250,
            allowSorting: true
        },
        {
            'caption': i18n("M16838", "İşlem Durumu"),
            dataField: 'StateName',
            dataType: 'string',
            width: 'auto',
            allowSorting: true
        }

    ];

    public MaterialColumns = [

        {
            dataField: 'StockTransactionID',
            visible: false
        },
        {
            'caption': "Malzeme Adı",
            dataField: 'Name',
            width: 150,
            allowSorting: true
        },
        {
            'caption': "Taşınır Kodu",
            dataField: 'NATOStockNO',
            dataType: 'string',
            width: 150,
            allowSorting: true
        },

        {
            'caption': "Miktar",
            dataField: 'Restamount',
            dataType: 'string',
            width: 100,
            allowSorting: true
        },
        {
            'caption': "Kalan Gün",
            dataField: 'DayLife',
            dataType: 'string',
            width: 100,
            allowSorting: true
        },
        {
            'caption': "Son Kullanma Tarihi",
            dataField: 'ExpirationDate',
            width: 150,
            allowSorting: true,
            dataType: 'date',
            format: "dd/MM/yyyy"
        },
        {
            'caption': "MKYS Stok Hareket ID'si",
            dataField: 'MKYSStockTransactionID',
            width: 150,
            allowSorting: true
        }

    ];

    public get TransactionTypes(): Array<EnumItem> {
        return TransactionTypeEnum.Items;
    }

    @Input() set StoreObjectId(object: string) {
        if (object != null && this._StoreObjectId != object) {
            this._StoreObjectId = object;
        }
    }
    get StoreObjectId(): string {
        return this._StoreObjectId;
    }

 
    @Input() set SelectedMainStore(value: any) {
        if (value != null && value != undefined)
            this.MaterialReportByExpirationDateFormViewModel.StoreID = value.ObjectID;
    }
    get SelectedMainStore(): any {
        return this.MaterialReportByExpirationDateFormViewModel.StoreID;
    }







    constructor(protected httpService: NeHttpService, private modalService: IModalService, protected messageService: MessageService, public systemApiService: SystemApiService, private renderer: Renderer2) {
        super('MaterialExpirationDateInfo', 'MaterialExpirationDateInfoForm');
        this.initViewModel();
    }

    public initViewModel(): void {
        this.MaterialReportByExpirationDateFormViewModel = new MaterialReportByExpirationDateFormViewModel();
        this.OnlyInStore = true;
    }

    async ngOnInit() {
        this.setDefaultDates();
    }

    public showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        this.storeListFiltred =  this._StoreObjectId.toString();
        this.showMaterialMultiSelectForm = true;
    }

    async MaterialsSelected(event) {
        this.showMaterialMultiSelectForm = false;
        let selectedMaterials = event;
        this.visibility = true;
        selectedMaterials.forEach(element => {
            this.SelectedMaterials.push(element.ObjectID);
            this.selectedMaterialsText += element.Name + " - ";
        });
    }

    async MaterialsCleared() {
        //this.showMaterialMultiSelectForm = false;
        this.SelectedMaterials = new Array<Guid>();
        this.selectedMaterialsText = "";
    }

    rowPrepared(row: any) {
        if (row.rowType == "data") {
            if (row.data.DayLife != null) {
                if (row.data.DayLife < 1) {
                    this.renderer.setStyle(row.rowElement.firstItem(), "background-color", "#ff7d79");
                }
                else if (row.data.DayLife < 181) {
                    this.renderer.setStyle(row.rowElement.firstItem(), "background-color", "#efec81");
                }
            }
        }
    }
    public startDate: Date;
    public endDate: Date;
    public setDefaultDates() {
        let startDateString;
        let currentDate = new Date();
        let currentYear = currentDate.getFullYear();
        startDateString = currentYear + "-01-01";
        this.StartDate = new Date(startDateString);
        this.StartDate.setHours(0, 0, 0, 0);
        this.EndDate = new Date();
        this.EndDate.setHours(23, 59, 59, 0);
    }

    public stockactionlist: StockActionWorkListDashboardItemModel = new StockActionWorkListDashboardItemModel();
    public selectedMaterialsText: string = "";
    async showWorkListDetail(rowData: any) {
        this.showLoadPanel = true;
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/MaterialReportByExpirationDateService/getStockActionList';
            let body = { 'MaterialObjectID': rowData.data.MaterialObjectID, 'Store': this._StoreObjectId, 'StartDateDashboardItem': this.StartDate, 'EndDateDashboardItem': this.EndDate, 'StockTransactionID': rowData.data.StockTransactionID };
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.stockactionlist = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
        finally {
            this.showLoadPanel = false;
        }
    }

    async GetMaterialListWithFilter() {
        this.showLoadPanel = true;
        try {
            /*if(this.DayQueryNumber == null || this.DayQueryNumber < 0)
            {
                ServiceLocator.MessageService.showError("Sorgulanacak gün sayısını giriniz!");
            }
            else*/{
                let that = this;
                let apiUrlForPASearchUrl: string = '/api/MaterialReportByExpirationDateService/getMaterialsInfoByExprationDate';
                if (this.DayQueryNumber == undefined)
                    this.DayQueryNumber = -1;
                let body = { 'StoreObjectId': this._StoreObjectId, 'DayQueryNumber': this.DayQueryNumber, 'Materials': this.SelectedMaterials, 'StartDate': this.StartDate, 'EndDate': this.EndDate, 'OnlyInStore': this.OnlyInStore };
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });

                await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                    let result = response;
                    if (result) {
                        this.MaterialList = result;
                    }
                    if (this.DayQueryNumber == -1)
                        this.DayQueryNumber = undefined;
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
        finally {
            this.showLoadPanel = false;
        }
    }
    public clearSelectedMaterials() {
        this.SelectedMaterials = new Array<Guid>();
        this.selectedMaterialsText = "";
    }

    private showStockAction(data: string): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DashboardActionComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16835", "İşlem Detayı");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async selectAction(value: any): Promise<void> {
        this.showStockAction(value.data.ObjectID);
    }


}

export class MaterialItem {
    StockTransactionID: string;
    MaterialObjectID: string;
    Name: string;
    NATOStockNO: string;
    Restamount: string;
    ExpirationDate: Date;
    DayLife: number;
    MKYSStockTransactionID: string;
}

export class StockActionWorkListDashboardItemModel {

    public ObjectID: string;
    public StockActionID: number;
    public StockActionType: TransactionTypeEnum;
    public DestinationStore: string;
    public StockactionName: string;
    public PatientName: string;
    public TransactionDate: Date;
    public StateName: string;
    public StateFormName: string;
    public Amount: number;
}