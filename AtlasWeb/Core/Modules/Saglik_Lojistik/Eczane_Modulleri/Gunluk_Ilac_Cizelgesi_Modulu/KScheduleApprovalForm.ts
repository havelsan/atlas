//$30660C4D
import { Component, ViewChild, OnInit, NgZone, Renderer2 } from '@angular/core';
import { KScheduleApprovalFormViewModel, OrderTimeScheduleDetail, InpatientHasDrugListDTO } from './KScheduleApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { DrugDefinition, DrugOrderDetail, KScheduleMaterial, } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { KSchedule } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionBaseForm } from 'Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { KScheduleUnListMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { EquivalentInfo, InPatientPhysicianApplication_Output, StockActionService, OpenStockActionDetailOutput_Input, GetOuttableLots_Output } from 'NebulaClient/Services/ObjectService/StockActionService';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DrugOrderIntroductionService, TempDrugOrder, OldDrugOrderIntroductionDet } from 'ObjectClassService/DrugOrderIntroductionService';
import { InPatientPhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import query from 'devextreme/data/query';
import { DxDataGridComponent, DxTextBoxComponent } from 'devextreme-angular';

import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { StockLevelService } from 'ObjectClassService/StockLevelService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { IBarcodePrinterProvider } from 'app/Barcode/Services/IBarcodePrinterProvider';
import { barcodeProviderFactory } from 'app/Barcode/Services/BarcodeProviderFactory';
import { KScheduleService, HimsDrugBarcodesContainer, GetCompletedKScheduleMaterial_Output, GetPatientOwnDrug_Output, KScheduleMaterialRowViewModel, PrintBarcodeForGivenActions_Input, CompletedKscheduleAction, DrugBarcodesContainer, PrintBarcodeForPursaklar_Input } from 'ObjectClassService/KScheduleService';
import { StockActionDetailStatusEnum, ResSection, KScheduleMaterialRowType } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from "NebulaClient/Utils/Enums/MessageIconEnum";
import { HvlDataGrid } from "Fw/Components/HvlDataGrid";
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { PatientInfo } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/Hasta_Ilac_Dogrulama/DrugCorrectionViewModel";

import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { ModalInfo, ModalStateService, ModalActionResult } from 'Fw/Models/ModalInfo';
import { Product, QueryVademecumInteractionDVO } from "app/Logistic/Models/LogisticDashboardViewModel";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { LogisticUserMessageData } from 'app/Logistic/Views/LogisticUserMessageComponent';
import { IModalService } from "Fw/Services/IModalService";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { OuttableLotDTO } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/ChattelDocumentOutputWithAccountancyNewFormViewModel';
import { TestResultQueryInputDVO } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestViewModel';
@Component({
    selector: 'KScheduleApprovalForm',
    templateUrl: './KScheduleApprovalForm.html',
    styles: [` :host /deep/ .dx-datagrid-header-panel .dx-toolbar {
    margin: 0;
    padding-right: 20px;
    background-color: #5186C3;
}
:host /deep/ .dx-datagrid-header-panel .dx-toolbar-items-container  {
    height: 70px;
}
:host /deep/ .dx-datagrid-header-panel .dx-toolbar-before {
    background-color: #337AB7;
}
:host /deep/ .dx-datagrid-header-panel .dx-selectbox {
     margin: 17px 10px;
}
:host /deep/ .dx-datagrid-header-panel .dx-button {
     margin: 17px 0;
}
/deep/ .informer {
    height: 70px;
    width: 130px;
    text-align: center;
    background: #2A507C url("content/icons/arrow.png") no-repeat 100% 50%;
}
/deep/ .count {
    color: #fff;
    padding-top: 15px;
    line-height: 27px;
}
/deep/ .name {
    color: #619dd1;
}
    `],
    providers: [MessageService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }
    ]
})
export class KScheduleApprovalForm extends StockActionBaseForm implements OnInit {

    @ViewChild('drugText') drugText: DxTextBoxComponent;
    @ViewChild('drugBagText') drugBagText: DxTextBoxComponent;

    Amount: TTVisual.ITTTextBoxColumn;
    MKYS_TeslimAlan: TTVisual.ITTTextBoxColumn;
    DemandDescription: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    DestinationStore: TTVisual.ITTObjectListBox;
    Dose: TTVisual.ITTTextBoxColumn;
    Drugs: TTVisual.ITTGrid;
    EndDate: TTVisual.ITTDateTimePicker;
    FullNamePatient: TTVisual.ITTTextBox;
    IDPatient: TTVisual.ITTTextBox;
    labelDescription: TTVisual.ITTLabel;
    labelDestinationStore: TTVisual.ITTLabel;
    labelFullNamePatient: TTVisual.ITTLabel;
    labelIDPatient: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    KSchedulePatienOwnDrugs: TTVisual.ITTGrid;
    Material: TTVisual.ITTListBoxColumn;
    DrugOrderStartDate: TTVisual.TTDateTimePickerColumn;
    Patient: TTVisual.ITTTextBoxColumn;
    PatientName: TTVisual.ITTTextBoxColumn;
    UsageNote: TTVisual.ITTTextBoxColumn;
    PatientNo: TTVisual.ITTTextBoxColumn;
    //QuarantinaNO: TTVisual.ITTTextBoxColumn; Kullanılmadığı için kapatıldı
    QuarantineNo: TTVisual.ITTTextBoxColumn;
    Reason: TTVisual.ITTTextBoxColumn;
    ReceivedAmount: TTVisual.ITTTextBoxColumn;
    RequestAmount: TTVisual.ITTTextBoxColumn;
    StartDate: TTVisual.ITTDateTimePicker;
    StatusStockActionDetail: TTVisual.ITTEnumComboBoxColumn;
    KScheduleMaterialRowType: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockActionOutDetails: TTVisual.ITTGrid;
    //StockLevelType: TTVisual.ITTListDefComboBoxColumn; Kullanılmadığı için kapatıldı
    Store: TTVisual.ITTObjectListBox;
    StoreInheld: TTVisual.ITTTextBoxColumn;
    TAmount: TTVisual.ITTTextBoxColumn;
    TDrug: TTVisual.ITTListBoxColumn;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttgrid2: TTVisual.ITTGrid;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    UnListDrug: TTVisual.ITTTextBoxColumn;
    MaterialKSchedulePatienOwnDrug: TTVisual.ITTListBoxColumn;
    ExpirationDatePatientOwnDrugEntryDetail: TTVisual.ITTDateTimePickerColumn;
    DrugAmountKSchedulePatienOwnDrug: TTVisual.ITTTextBoxColumn;
    StockActionStatusKSchedulePatienOwnDrug: TTVisual.ITTEnumComboBoxColumn;
    IsImmediateCheckGrid: TTVisual.ITTCheckBoxColumn;
    BarcodeVerifyCounter: TTVisual.ITTTextBoxColumn;
    BarcodeVerifyCounterForOwnDrug: TTVisual.ITTTextBoxColumn;
    buttonDetail: TTVisual.ITTButtonColumn;
    buttonEquivalent: TTVisual.ITTButtonColumn;

    public drugBarcodeValue: string;
    public KSchedulePatienOwnDrugsColumns = [];
    public clinicName: string;
    public clinicRoom: string;
    public clinicBed: string;
    public clinicProtocolNo: string;
    public clinicDischargeDate: Date;
    public hasPhysicianApplication: boolean = true;

    public himssApplicationParamValue: boolean = false;
    public himssResSectionParamValue: boolean = false;

    public PatientDrugInfoVisible: boolean;
    public DrugBarcodeInfoVisible: boolean;
    public patientInfoForKschedule: PatientInfo;
    public stockActionIDValue: string;

    public himssIntegrated: string;

    tempDrugOrders: Array<TempDrugOrder>;
    completedKScheduleMaterial: Array<GetCompletedKScheduleMaterial_Output>;
    expanded = true;
    totalCount: number;
    public showOverDosePopup = false;
    public overDoseMessage: string;

    public showDrugSpecPopup = false;
    public drugSpecMessage: string;

    public showDescriptionPopup = false;
    public drugDescription: string;

    public showDefDescriptionPopup = false;
    public drugDefDescription: string;

    public showRepeatDayWarningPopup = false;
    public repeatDayWarning: string;

    public showIngredientOverDosePopup = false;
    public ingredientMessage: string;

    public showStopSameIngredient = false;
    public stopSameIngredientMessage: string;

    public isCancelButtonShow: boolean = false;
    public CancelButtonCaption: string = 'İşlemi İptal Et';
    public CancelButtonIcon: string = 'close';
    public CancelButtonType: string = 'danger';

    public stockActionOrderNoCount: number = 0;

    public InpatientHasDrugList: Array<InpatientHasDrugListDTO> = new Array<InpatientHasDrugListDTO>();

    @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;
    @ViewChild(HvlDataGrid) stockActionOutDetailsGrid: HvlDataGrid;
    selectedRows: number[];
    public stateAction: Array<any> = new Array<any>();
    public EpisodeObjectID: Guid;
    public PatientObjectID: Guid;
    public DrugsColumns = [];
    public StockActionOutDetailsColumns = [];
    public ttgrid2Columns = [];
    public kScheduleApprovalFormViewModel: KScheduleApprovalFormViewModel = new KScheduleApprovalFormViewModel();
    public get _KSchedule(): KSchedule {
        return this._TTObject as KSchedule;
    }
    private KScheduleApprovalForm_DocumentUrl: string = '/api/KScheduleService/KScheduleApprovalForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private objectContextService: ObjectContextService,
        private barcodePrintService: IBarcodePrintService,
        private modalStateService: ModalStateService,
        protected modalService: IModalService,
        protected ngZone: NgZone,
        private renderer: Renderer2) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.KScheduleApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

        this.stateAction = [
            {
                Caption: "Tüm Laboratuvar Sonuçları",
                ActionName: "btnShowLISResultViewForAllEpisodes_Click"
            },
            {
                Caption: "Geçmiş Radyoloji Sonuçları",
                ActionName: "btnShowPatientAllRadiologyTestResult_Click"
            },
            {
                Caption: "Tüm Patoloji Sonuçları",
                ActionName: "btnShowAllPathologyResults"
            },
        ];

    }


    // ***** Method declarations start *****
    //public setInputParam(value: Object) {

    //}
    public onRowPrepared(e) {
        if (e.rowElement.firstItem() != undefined && e.rowElement.firstItem().length > 0 && e.rowType == 'data' && e.data != undefined) {
            if (e.data.Status == StockActionDetailStatusEnum._Cancelled.ordinal) {
                this.renderer.setStyle(e.rowElement.firstItem(), "background-color", "red");
            }
            else {
                this.renderer.setStyle(e.rowElement.firstItem(), "background-color", "#fff");
            }
        }
    }
    public MaterialGridColumns = [
        {
            name: 'GetDetail',
            width: 'auto',
            cellTemplate: 'detailCellTemplate',
        },
        {
            caption: 'Detaylar',
            dataField: 'ObjectID',
            width: 100,
            cellTemplate: 'buttonCellTemplateDetail',
            allowEditing: false,
        },
        {
            caption: 'Eşdeğer',
            dataField: 'ObjectID',
            width: 100,
            cellTemplate: 'buttonCellTemplateEqual',
            allowEditing: false,
        },
        {
            caption: i18n("M23462", "Tipi"),
            dataField: 'KScheduleMaterialRowType',
            lookup: { dataSource: KScheduleMaterialRowType.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            width: 'auto'
        },
        {
            caption: i18n("M17244", "Uyg. Baş. Tarihi"),
            dataField: 'DrugOrderStartDate',
            dataType: 'date',
            format: 'dd/MM/yyyy hh:mm',
            width: 150
        },
        {
            caption: i18n("M16287", "İlaç"),
            dataField: 'Material.Name',
            allowEditing: false,
            width: 300
        },
        {
            caption: i18n("M16713", "İstenen Miktar"),
            dataField: 'RequestAmount',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M17315", "Karşılanan Miktar"),
            dataField: 'ReceivedAmount',
            dataType: 'number',
            width: 100
        },
        {
            caption: i18n("M13460", "Eczane Mevcudu"),
            dataField: 'StoreInheld',
            dataType: 'number',
            width: 'auto'
        },
        {
            caption: "CV",
            dataField: 'IsCV',
            dataType: 'boolean',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: "Reçete No",
            dataField: 'PrescriptionNo',
            allowEditing: true,
            width: 80
        },
        {
            caption: i18n("M10469", "Açıklama"),
            dataField: 'DemandDescription',
            allowEditing: true,
            width: 150
        },
        {
            caption: i18n("M15131", "İlaç Kullanım Şekli"),
            dataField: 'UsageNote',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: "Durum",
            dataField: 'Status',
            lookup: { dataSource: StockActionDetailStatusEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            width: 100
        },
        {
            caption: i18n("M16504", "Doğrulanan Mik."),
            dataField: 'BarcodeVerifyCounter',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M22057", "Son Kullanma Tarihi"),
            dataField: 'ExpirationDate',
            dataType: 'date',
            format: 'MM/yyyy',
            width: 100
        }
    ];

    tabSelectionPatient(event) {
        if (event.addedItems[0].title === "Bu Gelişe Ait İlaçlar") {
            if (this.InpatientHasDrugList.length == 0) {
                let that = this;
                let apiUrl: string = 'api/KScheduleService/GetInpatientHasDrugList?InPatientPhysicianApplication=' + this.kScheduleApprovalFormViewModel._KSchedule.InPatientPhysicianApplication;
                this.httpService.post<Array<InpatientHasDrugListDTO>>(apiUrl, null).then(
                    result => {
                        this.InpatientHasDrugList = result;
                    },
                ).catch(ex => {

                });
            }
        }
    }

    // TODO Nida test edilecek
    private async StockActionOutDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let that = this;
        if (data.Column.Name === 'StatusStockActionDetail') {
            let kScheduleMaterialRow: KScheduleMaterialRowViewModel = <KScheduleMaterialRowViewModel>(data.Row);
            kScheduleMaterialRow.BarcodeVerifyCounter = 0;
            if (kScheduleMaterialRow.Status === StockActionDetailStatusEnum.Completed) {
                ServiceLocator.MessageService.showError('"İstek Hazırlama" adımında detay satırının durumu "Tamamlandı" seçilemez!');
                setTimeout(function () {
                    if (that.himssResSectionParamValue === true) {
                        kScheduleMaterialRow.Status = StockActionDetailStatusEnum.BarcodeIsNotVerified;
                    }
                    else {
                        kScheduleMaterialRow.Status = StockActionDetailStatusEnum.New;
                    }
                }, 100);

            }
            if (that.himssResSectionParamValue === true) {
                if (kScheduleMaterialRow.Status === StockActionDetailStatusEnum.New) {
                    ServiceLocator.MessageService.showError('"İstek Hazırlama" adımında detay satırının durumu "Yeni" seçilemez!');
                    setTimeout(function () {
                        kScheduleMaterialRow.Status = StockActionDetailStatusEnum.BarcodeIsNotVerified;
                    }, 100);
                }

            }

        }
    }

    // StockActionOutDetails_CellValueChanged bunu da kapsıyor
    //private async KSchedulePatienOwnDrugs_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
    //    let that = this;
    //    if (data.Column.Name === 'StockActionStatusKSchedulePatienOwnDrug') {
    //        let kSchedulePatienOwnDrug: KSchedulePatienOwnDrug = <KSchedulePatienOwnDrug>(data.Row.TTObject);
    //        kSchedulePatienOwnDrug.BarcodeVerifyCounter = 0;
    //        if (kSchedulePatienOwnDrug.StockActionStatus === StockActionDetailStatusEnum.Completed) {
    //            ServiceLocator.MessageService.showError('"İstek Hazırlama" adımında detay satırının durumu "Tamamlandı" seçilemez!');
    //            setTimeout(function () {
    //                if (that.himssResSectionParamValue == true) {
    //                    kSchedulePatienOwnDrug.StockActionStatus = StockActionDetailStatusEnum.BarcodeIsNotVerified;
    //                }
    //                else {
    //                    kSchedulePatienOwnDrug.StockActionStatus = StockActionDetailStatusEnum.New;
    //                }
    //            }, 100);

    //        }
    //        if (that.himssResSectionParamValue == true) {
    //            if (kSchedulePatienOwnDrug.StockActionStatus === StockActionDetailStatusEnum.New) {
    //                ServiceLocator.MessageService.showError('"İstek Hazırlama" adımında detay satırının durumu "Yeni" seçilemez!');
    //                setTimeout(function () {
    //                    kSchedulePatienOwnDrug.StockActionStatus = StockActionDetailStatusEnum.BarcodeIsNotVerified;
    //                }, 100);
    //            }

    //        }
    //    }
    //}

    public showOrderDetailPopup: boolean = false;
    public orderTimeScheduleDetail: OrderTimeScheduleDetail = null;
    public orderScheduleList: Array<OrderTimeScheduleDetail> = new Array<OrderTimeScheduleDetail>();

    // TODO Nida test edilip değiştirilecek
    async onOrderDetailsCellContentClicked(data: any) {
        if (data && this.onOrderDetailsCellContentClicked && data.Row && data.Column) {
            if (data.Column.Name === 'buttonDetail') {
                this.orderTimeScheduleDetail = new OrderTimeScheduleDetail();
                let order: KScheduleMaterialRowViewModel = data.Row.TTObject;

                this.orderTimeScheduleDetail.DrugName = order.Material.Name;
                this.orderTimeScheduleDetail.StartDate = order["DrugOrderStartDate"];
                this.orderTimeScheduleDetail.Times = order.ReceivedAmount; //KScheduleMaterial ın order.Amount u KScheduleMaterialRowViewModel un ReceivedAmount bilgisine atanıyor ;

                this.orderScheduleList.Clear();
                let scheduleDate: Date = Convert.ToDateTime(this.orderTimeScheduleDetail.StartDate); // new Date(this.orderTimeScheduleDetail.StartDate.getVarDate());
                let currentDate: Date = new Date();
                let scheduleTimeCalValue: number = 24;
                if (this.orderTimeScheduleDetail.Times != null && this.orderTimeScheduleDetail.Times != 0)
                    scheduleTimeCalValue = 24 / this.orderTimeScheduleDetail.Times;

                let i: number = 0;
                while (i < this.orderTimeScheduleDetail.Times) {

                    let item: OrderTimeScheduleDetail = new OrderTimeScheduleDetail();
                    item.DrugName = this.orderTimeScheduleDetail.DrugName;
                    item.StartDate = Convert.ToDateTime(scheduleDate); // new Date(scheduleDate.getVarDate());
                    item.Times = this.orderTimeScheduleDetail.Times;
                    this.orderScheduleList.push(item);

                    scheduleDate = scheduleDate.AddHours(scheduleTimeCalValue);
                    i++;
                }

                this.showOrderDetailPopup = true;

            }
            if (data.Column.Name === 'buttonEquivalent') {
                let order: KScheduleMaterialRowViewModel = data.Row.TTObject;

                let equivalentInfo: Array<EquivalentInfo> = await StockActionService.GetEquivalentDrug(this._StockAction.Store.ObjectID.toString(), order.Material.ObjectID.toString());
                if (equivalentInfo.length > 0) {
                    let equivalentDrug: any = await this.checkEquivalent(equivalentInfo);
                    if (equivalentDrug !== null) {
                        order.Material = equivalentDrug;
                        let stockInheld2: number = await StockLevelService.StockInheld(order.Material.ObjectID, this._StockAction.Store.ObjectID);
                        order.StoreInheld = stockInheld2;
                        for (let detailItem of this.kScheduleApprovalFormViewModel.StockActionOutDetailsGridList) {
                            if (detailItem.ObjectID.toString() === order.RowObjectId.id) {
                                detailItem.Material = order.Material;
                            }
                        }
                    }
                } else {
                    ServiceLocator.MessageService.showInfo('Seçmiş olduğunuz ilacın Mevcutlu eşdeğeri bulunmamaktadır.');
                }
            }
        }
    }
    async btnDetail(event) {

        if(event.row.data.KScheduleMaterialRowType != KScheduleMaterialRowType.KScheduleInfection){
        this.orderTimeScheduleDetail = new OrderTimeScheduleDetail();
        let order: KScheduleMaterialRowViewModel = event.row.data;

        this.orderTimeScheduleDetail.DrugName = order.Material.Name;

        let isOwnDrug: boolean = false;
        if (event.row.data.KScheduleMaterialRowType === KScheduleMaterialRowType.KSchedulePatienOwnDrug)
            isOwnDrug = true;
        let drugOrderDetails: Array<DrugOrderDetail> = await StockActionService.GetDrugTime(event.row.data.RowObjectId, isOwnDrug);
        this.orderScheduleList.Clear();
        for (let drugDet of drugOrderDetails) {
            let item: OrderTimeScheduleDetail = new OrderTimeScheduleDetail();
            item.DrugName = this.orderTimeScheduleDetail.DrugName;
            item.StartDate = drugDet.OrderPlannedDate;
            //item.Times = drugDet.OrderPlannedDate.;
            this.orderScheduleList.push(item);
        }
        this.showOrderDetailPopup = true;
    } else {
        ServiceLocator.MessageService.showInfo('Enfeksiyon Komitesinde bulunan ilaçların detayı onaydan sonra oluşacaktır.');
    }

        /*
        this.orderTimeScheduleDetail.DrugName = order.Material.Name;
        this.orderTimeScheduleDetail.StartDate = order["DrugOrderStartDate"];
        this.orderTimeScheduleDetail.Times = order.ReceivedAmount; //KScheduleMaterial ın order.Amount u KScheduleMaterialRowViewModel un ReceivedAmount bilgisine atanıyor ;

        this.orderScheduleList.Clear();
        let scheduleDate: Date = Convert.ToDateTime(this.orderTimeScheduleDetail.StartDate); // new Date(this.orderTimeScheduleDetail.StartDate.getVarDate());
        let currentDate: Date = new Date();
        let scheduleTimeCalValue: number = 24;
        if (this.orderTimeScheduleDetail.Times != null && this.orderTimeScheduleDetail.Times != 0)
            scheduleTimeCalValue = 24 / this.orderTimeScheduleDetail.Times;

        let i: number = 0;
        while (i < this.orderTimeScheduleDetail.Times) {

            let item: OrderTimeScheduleDetail = new OrderTimeScheduleDetail();
            item.DrugName = this.orderTimeScheduleDetail.DrugName;
            item.StartDate = Convert.ToDateTime(scheduleDate); // new Date(scheduleDate.getVarDate());
            item.Times = this.orderTimeScheduleDetail.Times;
            this.orderScheduleList.push(item);

            scheduleDate = scheduleDate.AddHours(scheduleTimeCalValue);
            i++;
        }*/


    }
    async btnEqualDrug(event) {
        let order: KScheduleMaterialRowViewModel = event.row.data;

        let equivalentInfo: Array<EquivalentInfo> = await StockActionService.GetEquivalentDrug(this._StockAction.Store.ObjectID.toString(), order.Material.ObjectID.toString());
        if (equivalentInfo.length > 0) {
            let equivalentDrug: any = await this.checkEquivalent(equivalentInfo);
            if (equivalentDrug !== null) {
                order.Material = equivalentDrug;
                let stockInheld2: number = await StockLevelService.StockInheld(order.Material.ObjectID, this._StockAction.Store.ObjectID);
                order.StoreInheld = stockInheld2;
                for (let detailItem of this.kScheduleApprovalFormViewModel.StockActionOutDetailsGridList) {
                    if (detailItem.ObjectID.toString() === order.RowObjectId.id) {
                        detailItem.Material = order.Material;
                    }
                }
            }
        } else {
            ServiceLocator.MessageService.showInfo('Seçmiş olduğunuz ilacın Mevcutlu eşdeğeri bulunmamaktadır.');
        }
    }
    private checkEquivalent(equivalentDrugs: Array<EquivalentInfo>): Promise<Material> {
        return new Promise<Material>((resolve, reject) => {
            if (equivalentDrugs.length > 0) {
                let drugObjectid: any = null;
                this.showEquivalentDrug(equivalentDrugs).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as EquivalentInfo;
                        drugObjectid = obj.drugObjectId;
                        if (drugObjectid != null) {
                            this.objectContextService.getObject<Material>(drugObjectid, DrugDefinition.ObjectDefID).then(mat => resolve(mat)).catch(error => reject(error));
                        } else {
                            resolve(null);
                        }
                    } else {
                        resolve(null);
                    }
                }).catch(err => reject(err));
            } else {
                resolve(null);
            }
        });
    }

    private showEquivalentDrug(data: Array<EquivalentInfo>): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugEquivalentComponentByStockAction';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13913", "Eşdeğer İlaçlar");
            modalInfo.Width = 600;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async getDetail(data: any) {

        if (data.data.KScheduleMaterialRowType != KScheduleMaterialRowType.KScheduleMaterial) {
            ServiceLocator.MessageService.showError('Sadece "Eczaneden İstenen" ilaçlar için giriş seçebilirsiniz.');
            return;
        }

        let detail: KScheduleMaterial = this.kScheduleApprovalFormViewModel.StockActionOutDetailsGridList.find(x => x.ObjectID == data.data.RowObjectId);
        if (detail == null) {
            ServiceLocator.MessageService.showError('Malzeme seçmediniz.');
            return;
        }

        if (this._KSchedule.Store == null) {
            ServiceLocator.MessageService.showError('Depo seçmediniz.');
            return;
        }
        if (detail.Amount == null) {
            ServiceLocator.MessageService.showError('Miktar girmediniz.');
            return;
        }
        let inputParam: OpenStockActionDetailOutput_Input = new OpenStockActionDetailOutput_Input();
        inputParam.MaterialID = data.data.Material.ObjectID;
        inputParam.StoreID = this._KSchedule.Store.ObjectID;
        inputParam.MaterialName = data.data.Material.Name;
        inputParam.RequestAmount = data.data.ReceivedAmount;
        inputParam.Barcode = data.data.Material.Barcode;
        //inputParam.DistributionTypeName = data.data.Material.DistributionTypeName;
        if (this.kScheduleApprovalFormViewModel.OuttableLotList != null)
            inputParam.selectedOuttableLots = this.kScheduleApprovalFormViewModel.OuttableLotList.filter(x => x.StockActionDetailOrderNo === data.data.ChattelDocDetailOrderNo);
        else
            inputParam.selectedOuttableLots = new Array<OuttableLotDTO>();
        this.showStockActionDetailOutForm(inputParam).then(res => {
            let modalActionResult = res as ModalActionResult;
            if (modalActionResult.Result === DialogResult.OK) {
                this.kScheduleApprovalFormViewModel.OuttableLotList = this.kScheduleApprovalFormViewModel.OuttableLotList.
                    filter(x => x.StockActionDetailOrderNo !== data.data.ChattelDocDetailOrderNo);
                let outtableLots = res.Param as Array<GetOuttableLots_Output>;
                this.stockActionOrderNoCount = this.stockActionOrderNoCount + 1;
                detail.ChattelDocDetailOrderNo = this.stockActionOrderNoCount;
                detail.UserSelectedOutableTrx = true;
                for (let outTRX of outtableLots) {
                    let outtableLot: OuttableLotDTO = new OuttableLotDTO();
                    outtableLot.Amount = outTRX.RestAmount;
                    outtableLot.BudgetTypeName = outTRX.BudgetTypeName;
                    outtableLot.ExpirationDate = outTRX.ExpirationDate;
                    outtableLot.LotNo = outTRX.LotNo;
                    outtableLot.RestAmount = outTRX.RestAmount;
                    outtableLot.SerialNo = outTRX.SerialNo;
                    outtableLot.TrxObjectID = outTRX.TrxObjectID;
                    outtableLot.StockActionDetailOrderNo = this.stockActionOrderNoCount;
                    this.kScheduleApprovalFormViewModel.OuttableLotList.push(outtableLot);
                }
            }
        });
    }

    private showStockActionDetailOutForm(data: OpenStockActionDetailOutput_Input): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'StockActionDetailOutForm';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Çıkılabilir Girişler';
            modalInfo.Width = 800;
            modalInfo.Height = 500;
            modalInfo.IsShowCloseButton = false;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async PatientInfoVerification() {
        try {
            let url: string = '/api/DrugCorrectionService/getPatientInfo';
            let input = { 'stockActionID': this.stockActionIDValue };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let result = await httpService.post<PatientInfo>(url, input);
            console.log(result);
            this.patientInfoForKschedule = result;
            if (this.patientInfoForKschedule.patientObjectID == this._KSchedule.Episode.Patient.ObjectID.toString()) {
                this.PatientDrugInfoVisible = false;
                this.DrugBarcodeInfoVisible = true;
                ServiceLocator.MessageService.showInfo('Hasta Bilgisi ve İlaç Torba Bilgisi eşleştirme BAŞARILI !');
                let that = this;
                setTimeout(() => {
                    that.drugText.instance.focus();
                }, 500);
            }
            else {
                ServiceLocator.MessageService.showError('Hasta Bilgisi ve İlaç Torba Bilgisi eşleştirme BAŞARISIZ !');
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    async verifyPatientInfoClick(): Promise<void> {
        let that = this;
        that.PatientInfoVerification();
    }

    async PatientInfo_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let that = this;
            that.PatientInfoVerification();
        }
    }

    DrugBarcodeVerification() { // test edilmeli
        let drugFound: boolean = false;

        if (this.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList.length > 0) {
            for (let kScheduleMaterialRow of this.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList) {
                if (kScheduleMaterialRow.Material.Barcode === this.drugBarcodeValue.trim()) {
                    drugFound = true;
                    if (kScheduleMaterialRow.Status == StockActionDetailStatusEnum.BarcodeIsNotVerified) {
                        kScheduleMaterialRow.BarcodeVerifyCounter = kScheduleMaterialRow.BarcodeVerifyCounter + 1;
                        if (kScheduleMaterialRow.KScheduleMaterialRowType == KScheduleMaterialRowType.KScheduleMaterial) {

                            ServiceLocator.MessageService.showInfo('Doğrulanan ilaç miktarı güncellenmiştir!');
                            if (kScheduleMaterialRow.BarcodeVerifyCounter == kScheduleMaterialRow.ReceivedAmount) {//kScheduleMaterial.Amount
                                kScheduleMaterialRow.Status = StockActionDetailStatusEnum.New;
                                ServiceLocator.MessageService.showInfo('Seçili barkod için ilaç doğrulanmıştır!');
                            }
                        }
                        else if (kScheduleMaterialRow.KScheduleMaterialRowType == KScheduleMaterialRowType.KSchedulePatienOwnDrug) {
                            ServiceLocator.MessageService.showInfo('Hastanın yanında getirdiği ilaç için doğrulanan miktar güncellenmiştir!');
                            if (kScheduleMaterialRow.BarcodeVerifyCounter == kScheduleMaterialRow.RequestAmount) { // patientOwnDrug.DrugAmount
                                kScheduleMaterialRow.Status = StockActionDetailStatusEnum.New;
                                ServiceLocator.MessageService.showInfo('Seçili barkod için hastanın yanında getirdiği ilaç doğrulanmıştır!');
                            }
                        }
                    }
                    else {
                        if (kScheduleMaterialRow.KScheduleMaterialRowType == KScheduleMaterialRowType.KScheduleMaterial) {

                            if (kScheduleMaterialRow.Status == StockActionDetailStatusEnum.New) {
                                ServiceLocator.MessageService.showError('Seçili barkod için ilaç doğrulanmış durumdadır!');
                            }
                            else {
                                ServiceLocator.MessageService.showError('Seçili barkod için ilaç doğrulama kapsamı dışındadır!');
                            }
                        }
                        else if (kScheduleMaterialRow.KScheduleMaterialRowType == KScheduleMaterialRowType.KSchedulePatienOwnDrug) {
                            if (kScheduleMaterialRow.Status == StockActionDetailStatusEnum.New) {
                                ServiceLocator.MessageService.showError('Seçili barkod için hastanın yanında getirdiği ilaç doğrulanmış durumdadır!');
                            }
                            else {
                                ServiceLocator.MessageService.showError('Seçili barkod için hastanın yanında getirdiği ilaç doğrulama kapsamı dışındadır!');
                            }
                        }

                    }

                }
            }

            if (drugFound == false) {
                ServiceLocator.MessageService.showError('Seçili barkod hasta ilaçları arasında yer almamaktadır');
            }
            this.drugBarcodeValue = "";
        }
        let that = this;
        setTimeout(() => {
            that.stockActionOutDetailsGrid.Refresh();
        }, 500);
    }

    async readDrugBarcodeAndVerifyIt(): Promise<void> {
        let that = this;
        that.DrugBarcodeVerification();
    }

    async DrugBarcode_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let that = this;
            that.DrugBarcodeVerification();
        }

    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public async save() {
        let isVademecumEntegrasyon: boolean = true;
        let vademecumEntg: string = (await SystemParameterService.GetParameterValue('VADEMECUMENTEGRASYON', 'FALSE'));
        if (vademecumEntg === 'FALSE') {
            isVademecumEntegrasyon = false;
        }
        try {
            if (isVademecumEntegrasyon === true) {
                let result = await this.showDrugInteractions();
                if (result === DialogResult.Cancel) {
                    throw new TTException(i18n("M16907", "İşlemden vazgeçildi"));
                }
                if (result === DialogResult.OK) {
                    this.modalStateService.callActionExecuted(DialogResult.OK, null, this._KSchedule);
                    await super.save();
                }
            } else {
                this.modalStateService.callActionExecuted(DialogResult.OK, null, this._KSchedule);
                await super.save();
            }
        } catch (err) {
            TTVisual.InfoBox.Alert(err);
        }
    }

    NewFormCancel() {
        super.cancel();
    }

    public cancel() {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    private showDrugInteractions(): Promise<DialogResult> {
        return new Promise<DialogResult>((resolve, reject) => {
            let that = this;
            let productList: Array<Product> = new Array<Product>();
            //KScheduleMaterialRowViewModelList kullanıldığı içn kapatıldı
            //if (that._KSchedule.KScheduleMaterials != null && that._KSchedule.KScheduleMaterials.length > 0) {
            //    for (let detailItem of that._KSchedule.KScheduleMaterials) {
            //        if ((<DrugDefinition>detailItem.Material).VademecumProductID != null) {
            //            let pdr: Product = new Product();
            //            pdr.id = (<DrugDefinition>detailItem.Material).VademecumProductID;
            //            productList.push(pdr);
            //        }
            //    }
            //}
            //if (that._KSchedule.KSchedulePatienOwnDrugs != null && that._KSchedule.KSchedulePatienOwnDrugs.length > 0) {
            //    for (let detailItem of that._KSchedule.KSchedulePatienOwnDrugs) {
            //        if ((<DrugDefinition>detailItem.Material).VademecumProductID != null) {
            //            let pdr: Product = new Product();
            //            pdr.id = (<DrugDefinition>detailItem.Material).VademecumProductID;
            //            productList.push(pdr);
            //        }
            //    }
            //}

            if (that.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList.length > 0) {

                for (let detailItem of that.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList) {
                    if ((<DrugDefinition>detailItem.Material).VademecumProductID != null) {
                        let pdr: Product = new Product();
                        pdr.id = (<DrugDefinition>detailItem.Material).VademecumProductID;
                        productList.push(pdr);
                    }
                }
            }

            if (productList.length > 0) {
                let inputDvo = new QueryVademecumInteractionDVO();
                inputDvo.episodeID = that._KSchedule.Episode.ObjectID.toString();
                inputDvo.prdList = productList;
                let fullApiUrl: string = 'api/LogisticDashboard/QueryVademecum';
                this.httpService.post(fullApiUrl, inputDvo)
                    .then((res: KScheduleApprovalFormViewModel) => {
                        let componentInfo = new DynamicComponentInfo();
                        componentInfo.ComponentName = 'DrugInteractionComponent';
                        componentInfo.ModuleName = 'LogisticFormsModule';
                        componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                        componentInfo.InputParam = new DynamicComponentInputParam(res, null);

                        let modalInfo: ModalInfo = new ModalInfo();
                        modalInfo.Title = 'UYARI';
                        modalInfo.Width = 1200;
                        modalInfo.Height = 800;

                        let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                        let result2 = modalService.create(componentInfo, modalInfo);
                        result2.then(res2 => {
                            resolve(res2.Result);
                        });

                    })
                    .catch(error => {
                        TTVisual.InfoBox.Alert(error);
                        reject(error);
                    });
            } else {
                ServiceLocator.MessageService.showInfo(i18n("M21522", "Seçilen ilaçların Vademecum sistemi eşleşmesi bulunamadığı için \"Etkileşim Uyarı Ekranı\" görüntülenemeyecektir!"));
                resolve(DialogResult.OK);
            }
        });

    }
    cancelKSchedule(data:any) {
        let td: TTObjectStateTransitionDef = this.kScheduleApprovalFormViewModel.OutgoingTransitions.find(x => x.ToStateDefID.valueOf() === KSchedule.KScheduleStates.Cancelled.id);
        if (td != null) {
            data.onStateButtonClicked(td);
           // this.statePanelComponent.onStateButtonClicked(td);
        }
    }

    public patientOwnDrugDesciption: string;
    protected async ClientSidePreScript(): Promise<void> {

        if (this._KSchedule.CurrentStateDefID.valueOf() === KSchedule.KScheduleStates.RequestPreparation.id) {
            this.DropStateButton(KSchedule.KScheduleStates.Cancelled);
            this.isCancelButtonShow = true;
        }
        //if (this._KSchedule.KSchedulePatienOwnDrugs !== null && this._KSchedule.KSchedulePatienOwnDrugs !== undefined) {
        //    if (this._KSchedule.KSchedulePatienOwnDrugs.length > 0) {
        //        this.patientOwnDrugDesciption = "  Hastanın yanında getirdiği ilaçlardan " + this._KSchedule.KSchedulePatienOwnDrugs.length.toString() + " tane order verilmiştir!!";
        //    }
        //}

        this.stockActionOrderNoCount = this.kScheduleApprovalFormViewModel.StockActionOutDetailsGridList.filter(x => x.ChattelDocDetailOrderNo != null).length;

        if (this.kScheduleApprovalFormViewModel.OuttableLotList == null) {
            this.kScheduleApprovalFormViewModel.OuttableLotList = new Array<OuttableLotDTO>();
        }

        if (this.kScheduleApprovalFormViewModel != null && this.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList != undefined) {
            let KSchedulePatienOwnDrugscount = (this.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList.filter(dr => dr.KScheduleMaterialRowType == KScheduleMaterialRowType.KSchedulePatienOwnDrug)).length;
            if (KSchedulePatienOwnDrugscount > 0) {
                this.patientOwnDrugDesciption = "  Hastanın yanında getirdiği ilaçlardan " + KSchedulePatienOwnDrugscount.toString() + " tane order verilmiştir!!";
            }
        }

        this.PatientDrugInfoVisible = false;
        this.DrugBarcodeInfoVisible = false;

        let outputCompleted: Array<GetCompletedKScheduleMaterial_Output> = await KScheduleService.GetCompletedKScheduleMaterial(this._KSchedule.Episode.ObjectID);
        this.completedKScheduleMaterial = outputCompleted;

        let dateTime: Date = null;
        let oldOrders: OldDrugOrderIntroductionDet = await DrugOrderIntroductionService.GetOldDrugOrderIntroductionDetsWithDate(this._KSchedule.Episode, dateTime);
        this.tempDrugOrders = oldOrders.TempDrugOrders;
        this.totalCount = this.getGroupCount('DrugName');


        if (this._KSchedule.InPatientPhysicianApplication !== undefined) {
            this.hasPhysicianApplication = true;
            let output: InPatientPhysicianApplication_Output = await StockActionService.GetInPatientPhysicianApplication_Info(this._KSchedule.InPatientPhysicianApplication.toString());
            if (output != null) {
                this.clinicProtocolNo = output.clinicProtocolNo;
                this.clinicBed = output.clinicBed;
                this.clinicRoom = output.clinicRoom;
                this.clinicName = output.clinicName;
                this.clinicDischargeDate = output.clinicDischargeDate;
                this.EpisodeObjectID = output.episodeObjectID;
                this.PatientObjectID = output.patientObjectID;
            }

        } else {
            this.hasPhysicianApplication = false;
        }

        //KScheduleMaterialRowViewModelList kullanıldığı içn kapatıldı Prede dolduruluyor
        //if (this._KSchedule.KScheduleMaterials.length > 0) {
        //    for (let kScheduleMaterial of this._KSchedule.KScheduleMaterials) {
        //        if (kScheduleMaterial.Material != null && kScheduleMaterial.StockLevelType != null) {
        //            if (kScheduleMaterial.Material.ObjectID != null) {
        //                let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(kScheduleMaterial.Material.ObjectID,
        //                    this._KSchedule.Store.ObjectID, kScheduleMaterial.StockLevelType.ObjectID);
        //                kScheduleMaterial.StoreInheld = stockInheld;
        //            }
        //        }
        //    }
        //}


        //await this.getPatientOwnDrug();


        this.himssIntegrated = (await SystemParameterService.GetParameterValue('HIMSSINTEGRATED', 'TRUE'));
        if (this.himssIntegrated === 'TRUE') {
            this.himssApplicationParamValue = true;
            if (this._KSchedule.InPatientPhysicianApplication !== null && this._KSchedule.InPatientPhysicianApplication !== undefined) {
                let InPatientPhysicianID: Guid = <any>this._KSchedule['InPatientPhysicianApplication'];
                let InPatientPhysician: InPatientPhysicianApplication = await this.objectContextService.getObject<InPatientPhysicianApplication>(InPatientPhysicianID, InPatientPhysicianApplication.ObjectDefID);
                if (InPatientPhysician !== null && InPatientPhysician !== undefined) {
                    let masterResourceID: Guid = <any>InPatientPhysician['MasterResource'];
                    let masterResource: ResSection = await this.objectContextService.getObject<ResSection>(masterResourceID, ResSection.ObjectDefID);
                    if (masterResource.HimssRequired !== null && masterResource.HimssRequired !== undefined) {
                        if (masterResource.HimssRequired == true) {
                            this.PatientDrugInfoVisible = true;
                            this.himssResSectionParamValue = true;

                            //KScheduleMaterialRowViewModelList kullanıldığı için kapatıldı
                            //if (this._KSchedule.KScheduleMaterials.length > 0) {
                            //    for (let kScheduleMaterial of this._KSchedule.KScheduleMaterials) {
                            //        setTimeout(function () {
                            //            if (kScheduleMaterial.Status == StockActionDetailStatusEnum.New) {
                            //                kScheduleMaterial.Status = StockActionDetailStatusEnum.BarcodeIsNotVerified;
                            //            }
                            //        }, 100);
                            //    }

                            //}
                            //if (this._KSchedule.KSchedulePatienOwnDrugs.length > 0) {
                            //    for (let patientOwnDrug of this._KSchedule.KSchedulePatienOwnDrugs) {
                            //        setTimeout(function () {
                            //            if (patientOwnDrug.StockActionStatus == StockActionDetailStatusEnum.New) {
                            //                patientOwnDrug.StockActionStatus = StockActionDetailStatusEnum.BarcodeIsNotVerified;
                            //            }
                            //        }, 100);
                            //    }
                            //}

                            if (this.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList.length > 0) {
                                for (let kScheduleMaterialRow of this.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList) {
                                    setTimeout(function () {
                                        if (kScheduleMaterialRow.Status == StockActionDetailStatusEnum.New) {
                                            kScheduleMaterialRow.Status = StockActionDetailStatusEnum.BarcodeIsNotVerified;
                                        }
                                    }, 100);
                                }
                            }


                            let that = this;
                            setTimeout(() => {
                                that.drugBagText.instance.focus();
                            }, 500);
                        }
                    }
                }
            }
        }


        // Serverdaki pre scriptde viewmodele  doldurulması sağlandı
        //let retMessage: string = await KScheduleService.IsImmadiatleControl(this._KSchedule.ObjectID);
        //if (retMessage !== "") {
        //    TTVisual.InfoBox.Alert("ACİL İLAÇLAR", retMessage + ' ilaçlar acil olarak işaretlenmiştir.', MessageIconEnum.WarningMessage);
        //}

        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.retMessage)) {
            TTVisual.InfoBox.Alert("ACİL İLAÇLAR", this.kScheduleApprovalFormViewModel.retMessage, MessageIconEnum.WarningMessage);
        }

        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.stopSameIngredientMessage)) {
            this.showStopSameIngredient = true;
            this.stopSameIngredientMessage = this.kScheduleApprovalFormViewModel.stopSameIngredientMessage;
            //TTVisual.InfoBox.Alert("DURDURULAN ETKEN MADDELER", this.kScheduleApprovalFormViewModel.stopSameIngredientMessage, MessageIconEnum.WarningMessage);
        }

        //let alletMessage: string = await KScheduleService.StoppedDrugOrderCheck(this._KSchedule.ObjectID);
        //if (alletMessage !== "") {
        //    TTVisual.InfoBox.Alert("DURDURULAN İLAÇLAR", alletMessage + ' İLAÇLAR DOKTOR TARAFINDAN DURDURULMUŞTUR.', MessageIconEnum.WarningMessage);
        //}

        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.alletMessage)) {
            TTVisual.InfoBox.Alert("DURDURULAN İLAÇLAR", this.kScheduleApprovalFormViewModel.alletMessage, MessageIconEnum.WarningMessage);
        }


        //let input = { 'KScheduleMaterials': this._KSchedule.KScheduleMaterials, 'episode': this._KSchedule.Episode, 'newMaterialObjectIDList': this._KSchedule.KScheduleMaterials.map(x => x.Material.ObjectID) };
        //this.httpService.post<string>('api/DrugOrderIntroductionService/ControlOfActiveIngredientPharmacy', input).then(message => {
        //    if (message != "") {
        //        this.showOverDosePopup = true;
        //        //TTVisual.InfoBox.Alert("UYARI !", message, MessageIconEnum.WarningMessage);
        //        this.overDoseMessage = message;
        //    }
        //});

        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.overDoseMessage)) {
            this.showOverDosePopup = true;
            //TTVisual.InfoBox.Alert("UYARI !", message, MessageIconEnum.WarningMessage);
            this.overDoseMessage = this.kScheduleApprovalFormViewModel.overDoseMessage;
        }

        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.ingredientsOverDoseMessage)) {
            this.showIngredientOverDosePopup = true;
            //TTVisual.InfoBox.Alert("UYARI !", message, MessageIconEnum.WarningMessage);
            this.ingredientMessage = this.kScheduleApprovalFormViewModel.ingredientsOverDoseMessage;
        }

        //let url = '/api/DrugOrderIntroductionService/ControlOfDrugSpecificationPharmacy';

        //let drugObjectIDs: Array<Guid> = new Array<Guid>();

        //if (this.kScheduleApprovalFormViewModel._KSchedule.KSchedulePatienOwnDrugs != null && this.kScheduleApprovalFormViewModel._KSchedule.KSchedulePatienOwnDrugs.length > 0)
        //    drugObjectIDs =drugObjectIDs.concat(this.kScheduleApprovalFormViewModel._KSchedule.KSchedulePatienOwnDrugs.map(x => x.Material.ObjectID));

        //if (this._KSchedule.KScheduleMaterials != null && this._KSchedule.KScheduleMaterials.length > 0)
        //    drugObjectIDs=  drugObjectIDs.concat(this._KSchedule.KScheduleMaterials.map(x => x.Material.ObjectID));

        //if (drugObjectIDs.length > 0) {
        //    let drugSpecificationControlInputDVO = { 'drugObjectIDs': drugObjectIDs, 'patientObjectID': this._KSchedule.Episode.Patient.ObjectID };
        //    this.httpService.post<string>(url, drugSpecificationControlInputDVO).then(message => {
        //        if (!String.isNullOrEmpty(message)) {
        //            this.showDrugSpecPopup = true;
        //            this.drugSpecMessage = message;
        //        }
        //    }).catch(error => {
        //        this.messageService.showError(error);
        //    });
        //}


        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.drugSpecMessage)) {
            this.showDrugSpecPopup = true;
            this.drugSpecMessage = this.kScheduleApprovalFormViewModel.drugSpecMessage;
        }

        // Serverdaki pre scriptde viewmodele  doldurulması sağlandı
        //ngOninitten buraya taşındı

        //this._KSchedule.KScheduleMaterials.forEach(element => {
        //    let materialObjectID: string = element.Material.ObjectID.toString();
        //    let isAgeValidate = this.AgeDifferenceValidate(materialObjectID, episodeObjectID);
        //});

        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.ageDifferenceValidateMessage)) {
            let messageHeader: string = "Yaş Aralığı Uyarısı!";
            await TTVisual.InfoBox.Alert(messageHeader, this.kScheduleApprovalFormViewModel.ageDifferenceValidateMessage, MessageIconEnum.WarningMessage);
        }
        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.drugNutrientInteractionMessage)) {
            let messageHeader: string = "Besin Etkileşimi Uyarısı!";
            await TTVisual.InfoBox.Alert(messageHeader, this.kScheduleApprovalFormViewModel.drugNutrientInteractionMessage, MessageIconEnum.WarningMessage);
        }

        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.doctorDescriptionOnDrug)) {
            this.showDescriptionPopup = true;
            this.drugDescription = this.kScheduleApprovalFormViewModel.doctorDescriptionOnDrug;
            //let messageHeader: string = "Verilen Order İçin Açıklama!";
            //await TTVisual.InfoBox.Alert(messageHeader, this.kScheduleApprovalFormViewModel.doctorDescriptionOnDrug, MessageIconEnum.WarningMessage);
        }

        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.drugDescriptionMessage)) {
            this.showDefDescriptionPopup = true;
            this.drugDefDescription = this.kScheduleApprovalFormViewModel.drugDescriptionMessage;
        }

        if (!String.isNullOrEmpty(this.kScheduleApprovalFormViewModel.repeatDayWarning)) {
            this.showRepeatDayWarningPopup = true;
            this.repeatDayWarning = this.kScheduleApprovalFormViewModel.repeatDayWarning;
        }

        // for (let detail of this._KSchedule.KScheduleMaterials) {
        //     let controlOfActiveIngredient: Array<ControlOfActiveIngredient_Output> = await DrugOrderIntroductionService.ControlOfActiveIngredient(detail.Material.ObjectID, this._KSchedule.Episode, detail.DrugOrderObjectID);
        //     if (controlOfActiveIngredient.length > 0) {
        //         let message: string = "";
        //         for (let activeDrugIngredient of controlOfActiveIngredient) {
        //             //if (activeDrugIngredient.drug !== detail.Material.Name)
        //             message += activeDrugIngredient.activeIngredient + " etken maddeli " + activeDrugIngredient.drug + " isimli ilaç bugün içerisinde istenmiştir. Bilginize !";
        //         }
        //         if (message !== "") {
        //             TTVisual.InfoBox.Alert("UYARI !", message, MessageIconEnum.WarningMessage);
        //         }
        //     }
        // }
    }



    public PatientOwnDrugsGrid: Array<GetPatientOwnDrug_Output>;
    /*async getPatientOwnDrug() {
        let that = this;
        let input: GetPatientOwnDrug_Input = new GetPatientOwnDrug_Input();
        input.KSCHEDULEOBJID = that._KSchedule.ObjectID.toString();
        let outputPatientOwns: Array<GetPatientOwnDrug_Output> = await KScheduleService.GetPatientOwnDrugs(input);
        if (outputPatientOwns !== undefined && outputPatientOwns !== null) {
            that.PatientOwnDrugsGrid = outputPatientOwns;
        }
    }*/

    public inpatientHasDrugListColumn = [
        {
            caption: 'Çıkış Şekli',
            dataField: 'OutStatus',
            allowEditing: false,
            width: 90,
        },
        {
            caption: "Başlangıç Tarihi",
            dataField: 'PlannedStartTime',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            sortOrder: 'asc',
            width: 110,
        },
        {
            caption: 'İlaç Adı',
            dataField: 'DrugName',
            allowEditing: false,
            width: 500,
        },
        {
            caption: 'Miktar',
            dataField: 'Amount',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Doktor',
            dataField: 'DoctorName',
            allowEditing: false,
            width: 200,
        },
        {
            caption: 'Klinik',
            dataField: 'ClinikName',
            allowEditing: false,
            width: 400,
        },
        {
            caption: 'Malzeme Türü',
            dataField: 'MaterialType',
            allowEditing: false,
            width: 150,
        }
    ];

    public PatientOwnDrugsGridColumn = [
        {
            caption: 'Barcod',
            dataField: 'Barcode',
            width: 150,
            allowSorting: true
        },
        {
            caption: i18n("M16287", "İlaç"),
            dataField: 'Material',
            width: 300,
            allowSorting: true
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            width: 100,
            allowSorting: true
        },
        {

            caption: i18n("M13372", "Durumu"),
            dataField: 'StockActionDetailStatusEnum',
            width: 100,
            cellTemplate: 'enumCmbTemplate'

        }];

    public async btnPrintlBarcode() {
        try {
            let stockSitesName: string = (await SystemParameterService.GetParameterValue("STOCKSITESNAME", "GAZİLER"));
            if (stockSitesName === "PURSAKLAR") {
                let InputKS: PrintBarcodeForPursaklar_Input = new PrintBarcodeForPursaklar_Input();
                InputKS.KScheduleObjID = this._KSchedule.ObjectID.toString()
                let returnedBarcodes: DrugBarcodesContainer = await KScheduleService.PrintBarcodeForPursaklar(InputKS);

                for (let barcodeInfo of returnedBarcodes.DrugBarcodes) {
                    this.barcodePrintService.printAllBarcode(barcodeInfo, "generateDrugBarcode", "printDrugBarcode");
                }
            }
            else {
                let url: string = '/api/KScheduleService/GetMyHimsDrugBarcodes';
                let input = { 'KscheduleAction': this._KSchedule };
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                let result = await httpService.post<HimsDrugBarcodesContainer>(url, input);
                console.log(result);
                for (let barcodeInfo of result.DrugBarcodes) {
                    this.barcodePrintService.printAllBarcode(barcodeInfo, "generateHimsDrugBarcode", "printHimsDrugBarcode");
                }
            }
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    openInNewTab(url) {
        if (url == null) {
            TTVisual.InfoBox.Alert(i18n("M12080", "Bu hizmetin sonucu bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }

    public viewResultURL: string;
    btnShowLISResultViewForAllEpisodes_Click(): void {
        this.viewResultURL = "";
        this.GetViewResultURLForAllEpisodes().then(() => {
            this.openInNewTab(this.viewResultURL);
        });
    }

    public async GetViewResultURLForAllEpisodes(): Promise<void> {

        let that = this;
        let inputDVO = new TestResultQueryInputDVO();


        inputDVO.PatientTCKN = that._KSchedule.Episode.Patient.UniqueRefNo.toString();
        inputDVO.EpisodeID = that._KSchedule.Episode.ID.toString();

        let apiUrl: string = 'api/ProcedureRequestService/GetURLForAllEpisodeTestResults';
        let result = await this.httpService.post<string>(apiUrl, inputDVO);
        this.viewResultURL = result;
    }

    public async btnSendMessage() {
        try {

            let message: string = this._KSchedule.Episode.Patient.Name + " " + this._KSchedule.Episode.Patient.Surname + " isimli hastaya verilen order ";
            let data: LogisticUserMessageData = new LogisticUserMessageData();
            data.sentBy = this._KSchedule.MKYS_TeslimAlan;
            data.sentByObjectID = this._KSchedule.MKYS_TeslimAlanObjID.toString();
            data.senderBy = TTUser.CurrentUser.Name;
            data.senderByObjectID = TTUser.CurrentUser.UserObject.toString();
            data.valueForMessage = message;
            data.subject = this._KSchedule.Episode.Patient.Name + " " + this._KSchedule.Episode.Patient.Surname + " isimli hastaya ile ilgili";
            this.showUserMessageComponent(data);
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    private showUserMessageComponent(data: LogisticUserMessageData): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "LogisticUserMessageComponent";
            componentInfo.ModuleName = "LogisticFormsModule";
            componentInfo.ModulePath = "/app/Logistic/LogisticFormsModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Kullanıcı Mesajı";
            modalInfo.Width = 600;
            modalInfo.Height = 350;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    getGroupCount(groupField) {
        if (this.tempDrugOrders != null) {
            return query(this.tempDrugOrders)
                .groupBy(groupField)
                .toArray().length;
        } else {
            return 0;
        }
    }

    onToolbarPreparing(e) {
        e.toolbarOptions.items.unshift({
            location: 'before',
            template: 'totalGroupCount'
        }, {
            location: 'before',
            widget: 'dxSelectBox',
            options: {
                width: 200,
                items: [{
                    value: 'DrugName',
                    text: i18n("M16280", "İlaca Göre Grupla ")
                }],
                displayExpr: 'text',
                valueExpr: 'value',
                value: "DrugName",
                onValueChanged: this.groupChanged.bind(this)
            }
        }, {
            location: 'before',
            widget: 'dxButton',
            options: {
                hint: i18n("M15727", "Hepsini Kapat"),
                icon: 'chevrondown',
                onClick: this.collapseAllClick.bind(this)
            }
        }, {
            location: 'after',
            widget: 'dxButton',
            options: {
                icon: 'refresh',
                onClick: this.refreshDataGrid.bind(this)
            }
        });
    }


    groupChanged(e) {
        this.dataGrid.instance.clearGrouping();
        this.dataGrid.instance.columnOption(e.value, 'groupIndex', 0);
        this.totalCount = this.getGroupCount(e.value);
    }

    collapseAllClick(e) {
        this.expanded = !this.expanded;
        e.component.option({
            icon: this.expanded ? 'chevrondown' : 'chevronnext',
            hint: this.expanded ? 'Collapse All' : 'Expand All'
        });
    }


    refreshDataGrid() {
        this.dataGrid.instance.refresh();
    }



    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            let autoHimsBarcode: string = (await SystemParameterService.GetParameterValue('AUTOHIMSSBARCODE', 'FALSE'));
            if (autoHimsBarcode == 'TRUE') {
                try {
                    let url: string = '/api/KScheduleService/GetMyHimsDrugBarcodes';
                    let input = { 'KscheduleAction': this._KSchedule };
                    let httpService: NeHttpService = ServiceLocator.NeHttpService;
                    let result = await httpService.post<HimsDrugBarcodesContainer>(url, input);
                    console.log(result);
                    for (let barcodeInfo of result.DrugBarcodes) {
                        this.barcodePrintService.printAllBarcode(barcodeInfo, "generateHimsDrugBarcode", "printHimsDrugBarcode");
                    }
                } catch (err) {
                    ServiceLocator.MessageService.showError(err);
                }
            }



            let nowDate = new Date(Date.now());
            let day: number = nowDate.getDay();
            //if (day !== 5) {
            let stockSitesName: string = (await SystemParameterService.GetParameterValue("STOCKSITESNAME", "GAZİLER"));
            if (stockSitesName === "PURSAKLAR") {
                let InputKS: PrintBarcodeForPursaklar_Input = new PrintBarcodeForPursaklar_Input();
                InputKS.KScheduleObjID = this._KSchedule.ObjectID.toString();
                let returnedBarcodes: DrugBarcodesContainer = await KScheduleService.PrintBarcodeForPursaklar(InputKS);

                for (let barcodeInfo of returnedBarcodes.DrugBarcodes) {
                    this.barcodePrintService.printAllBarcode(barcodeInfo, "generateDrugBarcode", "printDrugBarcode");
                }
            }
        }

    }

    // Serverdaki pre scriptde viewmodele  doldurulması sağlandı
    //async AgeDifferenceValidate(materialObjectID: string, episodeObjectID: string): Promise<boolean> {

    //    let AgeValidation: ValidationPatientAgeAndMaterialAgeBand_Output = await DrugOrderIntroductionService.GetValidationPatientAgeAndMaterialAgeBand(episodeObjectID, materialObjectID);
    //    let MaxAgeValidate: boolean = true;
    //    let MinAgeValidate: boolean = true;

    //    if (AgeValidation.MaterialMaxAge != null && AgeValidation.MaterialMaxAge < AgeValidation.PatientAge) {
    //        MaxAgeValidate = false;
    //    }
    //    if (AgeValidation.MaterialMinAge != null && AgeValidation.MaterialMinAge > AgeValidation.PatientAge) {
    //        MinAgeValidate = false;
    //    }

    //    if (MinAgeValidate && MaxAgeValidate) {
    //        return true;
    //    }
    //    else {

    //        let message: string = "Karşıladığınız ilaç hastanın yaş aralığı için uygun değildir. Hastanız " + AgeValidation.PatientAge
    //            + " yaşında, ilaç için tavsiye edilen yaş aralığı (" + AgeValidation.MaterialMinAge + ")-(" + AgeValidation.MaterialMaxAge + ")";
    //        let messageHeader: string = "Yaş Aralığı Uyarısı!"
    //        TTVisual.InfoBox.Alert(messageHeader, message, MessageIconEnum.WarningMessage);
    //        return true;
    //    }
    //}

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        if (transDef != null) {
            let isVademecumEntegrasyon: boolean = true;
            let vademecumEntg: string = (await SystemParameterService.GetParameterValue('VADEMECUMENTEGRASYON', 'FALSE'));
            if (vademecumEntg === 'FALSE') {
                isVademecumEntegrasyon = false;
            }
            try {
                if (isVademecumEntegrasyon === true) {
                    let result = await this.showDrugInteractions();
                    if (result === DialogResult.Cancel) {
                        throw new TTException(i18n("M16907", "İşlemden vazgeçildi"));
                    }
                    if (result === DialogResult.OK) {
                        this.modalStateService.callActionExecuted(DialogResult.OK, null, this._KSchedule);
                    }
                } else {
                    this.modalStateService.callActionExecuted(DialogResult.OK, null, this._KSchedule);
                }
            } catch (err) {
                TTVisual.InfoBox.Alert(err);
            }
        }

        for (let detailItem of this.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList) {
            if (detailItem.KScheduleMaterialRowType == KScheduleMaterialRowType.KScheduleMaterial) {
                if ((<DrugDefinition>detailItem.Material).IsNarcotic === true) {
                    ServiceLocator.MessageService.showInfo(detailItem.Material.Name + ' Yüksek Riskli İlaçtır!');
                }
                if ((<DrugDefinition>detailItem.Material).IsPsychotropic === true) {
                    ServiceLocator.MessageService.showInfo(detailItem.Material.Name + i18n("M20617", " Psikotrop Madde İçermektedir!"));
                }
            }
        }

        //for (let detailItem of this._KSchedule.KScheduleMaterials) {
        //    if ((<DrugDefinition>detailItem.Material).IsNarcotic === true) {
        //        ServiceLocator.MessageService.showInfo(detailItem.Material.Name + ' Yüksek Riskli İlaçtır!');
        //    }
        //    if ((<DrugDefinition>detailItem.Material).IsPsychotropic === true) {
        //        ServiceLocator.MessageService.showInfo(detailItem.Material.Name + i18n("M20617", " Psikotrop Madde İçermektedir!"));
        //    }
        //}

        for (let detailMat of this.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList) {
            if (detailMat.ReceivedAmount < 0) {
                throw new TTException(detailMat.Material.Name + " isimli malzemeye 0 dan düşük değer girilemez!");
            }
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new KSchedule();
        this.kScheduleApprovalFormViewModel = new KScheduleApprovalFormViewModel();
        this._ViewModel = this.kScheduleApprovalFormViewModel;
        this.kScheduleApprovalFormViewModel._KSchedule = this._TTObject as KSchedule;
        //this.kScheduleApprovalFormViewModel._KSchedule.KScheduleMaterials = new Array<KScheduleMaterial>();
        //this.kScheduleApprovalFormViewModel._KSchedule.KSchedulePatienOwnDrugs = new Array<KSchedulePatienOwnDrug>();
        this.kScheduleApprovalFormViewModel._KSchedule.KScheduleUnListMaterials = new Array<KScheduleUnListMaterial>();
        this.kScheduleApprovalFormViewModel._KSchedule.Episode = new Episode();
        this.kScheduleApprovalFormViewModel._KSchedule.Episode.Patient = new Patient();
        this.kScheduleApprovalFormViewModel._KSchedule.DestinationStore = new Store();
        this.kScheduleApprovalFormViewModel._KSchedule.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.kScheduleApprovalFormViewModel = this._ViewModel as KScheduleApprovalFormViewModel;
        that._TTObject = this.kScheduleApprovalFormViewModel._KSchedule;
        if (this.kScheduleApprovalFormViewModel == null)
            this.kScheduleApprovalFormViewModel = new KScheduleApprovalFormViewModel();
        if (this.kScheduleApprovalFormViewModel._KSchedule == null)
            this.kScheduleApprovalFormViewModel._KSchedule = new KSchedule();


        // KSchedulePatienOwnDrugs ve KScheduleMaterials kaldırılıp KScheduleMaterialRowViewModelList da birleştirildi

        //for (let detailItem of that.kScheduleApprovalFormViewModel.KScheduleMaterialRowViewModelList) {
        //    let materialObjectID = detailItem["Material"];
        //    if (materialObjectID != null && (typeof materialObjectID === "string")) {
        //        let material = that.kScheduleApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
        //        if (material) {
        //            detailItem.Material = material;
        //        }
        //    }
        //}


        //that.kScheduleApprovalFormViewModel._KSchedule.KSchedulePatienOwnDrugs = that.kScheduleApprovalFormViewModel.KSchedulePatienOwnDrugsGridList;
        //for (let detailItem of that.kScheduleApprovalFormViewModel.KSchedulePatienOwnDrugsGridList) {
        //    let materialObjectID = detailItem["Material"];
        //    if (materialObjectID != null && (typeof materialObjectID === "string")) {
        //        let material = that.kScheduleApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
        //        if (material) {
        //            detailItem.Material = material;
        //        }
        //    }
        //}
        //that.kScheduleApprovalFormViewModel._KSchedule.KScheduleMaterials = that.kScheduleApprovalFormViewModel.StockActionOutDetailsGridList;
        //for (let detailItem of that.kScheduleApprovalFormViewModel.StockActionOutDetailsGridList) {
        //    let materialObjectID = detailItem['Material'];
        //    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
        //        let material = that.kScheduleApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
        //        if (material) {
        //            detailItem.Material = material;
        //        }
        //    }
        //    //let stockLevelTypeObjectID = detailItem['StockLevelType'];
        //    //if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
        //    //    let stockLevelType = that.kScheduleApprovalFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
        //    //    if (stockLevelType) {
        //    //        detailItem.StockLevelType = stockLevelType;
        //    //    }
        //    //}
        //}
        that.kScheduleApprovalFormViewModel._KSchedule.KScheduleUnListMaterials = that.kScheduleApprovalFormViewModel.ttgrid2GridList;
        for (let detailItem of that.kScheduleApprovalFormViewModel.ttgrid2GridList) {
        }
        let episodeObjectID = that.kScheduleApprovalFormViewModel._KSchedule['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.kScheduleApprovalFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.kScheduleApprovalFormViewModel._KSchedule.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.kScheduleApprovalFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let destinationStoreObjectID = that.kScheduleApprovalFormViewModel._KSchedule['DestinationStore'];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.kScheduleApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.kScheduleApprovalFormViewModel._KSchedule.DestinationStore = destinationStore;
            }
        }
        let storeObjectID = that.kScheduleApprovalFormViewModel._KSchedule['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.kScheduleApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.kScheduleApprovalFormViewModel._KSchedule.Store = store;
            }
        }
    }




    public actionMenuVisible: boolean = false;
    showActionMenu(): void {
        this.actionMenuVisible = true;
    }

    onActionMenuClick(e: any) {
        if (e.itemData.ActionName === "btnShowLISResultViewForAllEpisodes_Click") {
            this.btnShowLISResultViewForAllEpisodes_Click();
        }

        if (e.itemData.ActionName === "btnShowPatientAllRadiologyTestResult_Click") {
            this.btnShowPatientAllRadiologyTestResult_Click();
        }

        if (e.itemData.ActionName === "btnShowAllPathologyResults") {
            this.btnShowAllPathologyResults();
        }
    }

    showPathologyResultsPopUp: boolean = false;

    btnShowAllPathologyResults(): void {
        this.popupTitleRadiologyTestResultsForm = "Geçmiş Patoloji Sonuçları";
        this.showPathologyResultsPopUp = true;
    }


    showPopupRadiologyTestResultsForm: boolean;
    popupTitleRadiologyTestResultsForm: string;
    btnShowPatientAllRadiologyTestResult_Click(): void {
        this.popupTitleRadiologyTestResultsForm = "Geçmiş Radyoloji Sonuçları";
        this.showPopupRadiologyTestResultsForm = true;
    }

    async ngOnInit() {
        await this.load(KScheduleApprovalFormViewModel);
        this.FormCaption = 'Günlük İlaç Çizelgesi ( İstek Hazırlama )';


        // Serverdaki pre scriptde viewmodele  doldurulması sağlandı ve kodu ClientPre scriptine taşında
        //this._KSchedule.KScheduleMaterials.forEach(element => {
        //    let materialObjectID: string = element.Material.ObjectID.toString();
        //    let isAgeValidate = this.AgeDifferenceValidate(materialObjectID, episodeObjectID);
        //});
    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.Description !== event) {
                this._KSchedule.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.DestinationStore !== event) {
                this._KSchedule.DestinationStore = event;
            }
        }
    }

    public onEndDateChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.EndDate !== event) {
                this._KSchedule.EndDate = event;
            }
        }
    }

    public onFullNamePatientChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null &&
                this._KSchedule.Episode != null &&
                this._KSchedule.Episode.Patient != null && this._KSchedule.Episode.Patient.FullName !== event) {
                this._KSchedule.Episode.Patient.FullName = event;
            }
        }
    }

    public onIDPatientChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null &&
                this._KSchedule.Episode != null &&
                this._KSchedule.Episode.Patient != null && this._KSchedule.Episode.Patient.ID !== event) {
                this._KSchedule.Episode.Patient.ID = event;
            }
        }
    }

    public onStartDateChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.StartDate !== event) {
                this._KSchedule.StartDate = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.StockActionID !== event) {
                this._KSchedule.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.Store !== event) {
                this._KSchedule.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.TransactionDate !== event) {
                this._KSchedule.TransactionDate = event;
            }
        }
    }

    public async StockActionOutDetails_CellValueChangedEmitted(data: any): Promise<void> {
        await this.StockActionOutDetails_CellValueChanged(data, null, null);
    }

    //public async KSchedulePatienOwnDrugs_CellValueChangedEmitted(data: any): Promise<void> {
    //    await this.KSchedulePatienOwnDrugs_CellValueChanged(data, null, null);
    //}


    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.StartDate, 'Value', this.__ttObject, 'StartDate');
        redirectProperty(this.EndDate, 'Value', this.__ttObject, 'EndDate');
        redirectProperty(this.IDPatient, 'Text', this.__ttObject, 'Episode.Patient.ID');
        redirectProperty(this.FullNamePatient, 'Text', this.__ttObject, 'Episode.Patient.FullName');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = 'tttabcontrol1';
        this.tttabcontrol1.TabIndex = 31;

        this.KSchedulePatienOwnDrugs = new TTVisual.TTGrid();
        this.KSchedulePatienOwnDrugs.Name = "KSchedulePatienOwnDrugs";
        this.KSchedulePatienOwnDrugs.TabIndex = 32;
        this.KSchedulePatienOwnDrugs.AllowUserToAddRows = false;
        this.KSchedulePatienOwnDrugs.AllowUserToDeleteRows = false;


        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 0;
        this.tttabpage3.TabIndex = 1;
        this.tttabpage3.Text = 'İstenen ilaçlar';
        this.tttabpage3.Name = 'tttabpage3';
        this.tttabpage3.Visible = false;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Name = 'tttextbox1';
        this.tttextbox1.TabIndex = 1;

        this.Drugs = new TTVisual.TTGrid();
        this.Drugs.AllowUserToAddRows = false;
        this.Drugs.AllowUserToDeleteRows = false;
        this.Drugs.Name = 'Drugs';
        this.Drugs.TabIndex = 0;
        this.Drugs.Height = 350;

        this.TDrug = new TTVisual.TTListBoxColumn();
        this.TDrug.ListDefName = 'DrugList';
        this.TDrug.DisplayIndex = 0;
        this.TDrug.HeaderText = i18n("M16389", "İlaçlar");
        this.TDrug.Name = 'TDrug';
        this.TDrug.ReadOnly = true;
        this.TDrug.Width = 500;

        this.TAmount = new TTVisual.TTTextBoxColumn();
        this.TAmount.DisplayIndex = 1;
        this.TAmount.HeaderText = i18n("M19030", "Miktar");
        this.TAmount.Name = 'TAmount';
        this.TAmount.ReadOnly = true;
        this.TAmount.Width = 160;
        this.TAmount.IsNumeric = true;

        this.QuarantineNo = new TTVisual.TTTextBoxColumn();
        this.QuarantineNo.DisplayIndex = 2;
        this.QuarantineNo.HeaderText = i18n("M17266", "Karantina Numaraları");
        this.QuarantineNo.Name = 'QuarantineNo';
        this.QuarantineNo.ReadOnly = true;
        this.QuarantineNo.Width = 500;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 1;
        this.tttabpage1.BackColor = '#FFFFFF';
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = 'İstenen ilaçlar';
        this.tttabpage1.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.tttabpage1.Name = 'tttabpage1';

        this.StockActionOutDetails = new TTVisual.TTGrid();
        this.StockActionOutDetails.AllowUserToAddRows = false;
        this.StockActionOutDetails.AllowUserToDeleteRows = false;
        this.StockActionOutDetails.Name = 'StockActionOutDetails';
        this.StockActionOutDetails.TabIndex = 0;
        this.StockActionOutDetails.Height = 350;

        this.PatientNo = new TTVisual.TTTextBoxColumn();
        this.PatientNo.DataMember = 'PatientID';
        this.PatientNo.DisplayIndex = 0;
        this.PatientNo.HeaderText = i18n("M15286", "Hasta Numarası");
        this.PatientNo.Name = 'PatientNo';
        this.PatientNo.ReadOnly = true;
        this.PatientNo.Width = 100;

        this.PatientName = new TTVisual.TTTextBoxColumn();
        this.PatientName.DataMember = 'PatientName';
        this.PatientName.DisplayIndex = 1;
        this.PatientName.HeaderText = i18n("M15131", "Hasta Adı");
        this.PatientName.Name = 'PatientName';
        this.PatientName.ReadOnly = true;
        this.PatientName.Width = 300;

        this.UsageNote = new TTVisual.TTTextBoxColumn();
        this.UsageNote.DataMember = 'UsageNote';
        this.UsageNote.DisplayIndex = 1;
        this.UsageNote.HeaderText = i18n("M15131", "İlaç Kullanım Şekli");
        this.UsageNote.Name = 'UsageNote';
        this.UsageNote.ReadOnly = true;
        this.UsageNote.Width = 200;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = 'MaterialListDefinition';
        this.Material.AutoCompleteDialogHeight = '60%';
        this.Material.AutoCompleteDialogWidth = '90%';
        this.Material.DataMember = 'Material';
        this.Material.DisplayIndex = 2;
        this.Material.HeaderText = i18n("M16287", "İlaç");
        this.Material.Name = 'Material';
        this.Material.ReadOnly = true;
        this.Material.Width = 500;

        this.DrugOrderStartDate = new TTVisual.TTDateTimePickerColumn();
        this.DrugOrderStartDate.DataMember = "DrugOrderStartDate";
        this.DrugOrderStartDate.Format = DateTimePickerFormat.Long;
        this.DrugOrderStartDate.DisplayIndex = 2;
        this.DrugOrderStartDate.HeaderText = i18n("M17244", "Uyg. Baş. Tarihi");
        this.DrugOrderStartDate.Name = "DrugOrderStartDate";
        this.DrugOrderStartDate.ReadOnly = true;
        this.DrugOrderStartDate.Width = 150;

        this.RequestAmount = new TTVisual.TTTextBoxColumn();
        this.RequestAmount.DataMember = 'RequestAmount';
        this.RequestAmount.DisplayIndex = 3;
        this.RequestAmount.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequestAmount.Name = 'RequestAmount';
        this.RequestAmount.ReadOnly = true;
        this.RequestAmount.Width = 160;
        this.RequestAmount.IsNumeric = true;

        this.ReceivedAmount = new TTVisual.TTTextBoxColumn();
        this.ReceivedAmount.DataMember = 'ReceivedAmount'; // kScheduleMaterial.Amount;
        this.ReceivedAmount.DisplayIndex = 4;
        this.ReceivedAmount.HeaderText = i18n("M17315", "Karşılanan Miktar");
        this.ReceivedAmount.Name = 'ReceivedAmount';
        this.ReceivedAmount.Width = 160;
        this.ReceivedAmount.IsNumeric = true;

        this.StoreInheld = new TTVisual.TTTextBoxColumn();
        this.StoreInheld.DataMember = 'StoreInheld';
        this.StoreInheld.DisplayIndex = 6;
        this.StoreInheld.HeaderText = i18n("M13460", "Eczane Mevcudu");
        this.StoreInheld.Name = 'StoreInheld';
        this.StoreInheld.ReadOnly = true;
        this.StoreInheld.Width = 160;

        this.DemandDescription = new TTVisual.TTTextBoxColumn();
        this.DemandDescription.DataMember = 'Description';
        this.DemandDescription.DisplayIndex = 7;
        this.DemandDescription.HeaderText = i18n("M10469", "Açıklama");
        this.DemandDescription.Name = 'DemandDescription';
        this.DemandDescription.Width = 160;

        this.StatusStockActionDetail = new TTVisual.TTEnumComboBoxColumn();
        this.StatusStockActionDetail.DataTypeName = 'StockActionDetailStatusEnum';
        this.StatusStockActionDetail.DataMember = 'Status';
        this.StatusStockActionDetail.DisplayIndex = 8;
        this.StatusStockActionDetail.HeaderText = 'Durum';
        this.StatusStockActionDetail.Name = 'StatusStockActionDetail';
        this.StatusStockActionDetail.Width = 160;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 2;
        this.tttabpage2.BackColor = '#FFFFFF';
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = 'Çıkmayan ilaçlar';
        this.tttabpage2.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.tttabpage2.Name = 'tttabpage2';

        this.ttgrid2 = new TTVisual.TTGrid();
        this.ttgrid2.AllowUserToAddRows = false;
        this.ttgrid2.AllowUserToDeleteRows = false;
        this.ttgrid2.ReadOnly = true;
        this.ttgrid2.Name = 'ttgrid2';
        this.ttgrid2.TabIndex = 0;
        this.ttgrid2.Height = 350;

        this.UnListDrug = new TTVisual.TTTextBoxColumn();
        this.UnListDrug.DataMember = 'UnlistDrug';
        this.UnListDrug.DisplayIndex = 0;
        this.UnListDrug.HeaderText = i18n("M16287", "İlaç");
        this.UnListDrug.Name = 'UnListDrug';
        this.UnListDrug.ReadOnly = true;
        this.UnListDrug.Width = 500;

        this.buttonDetail = new TTVisual.TTButtonColumn();
        this.buttonDetail.Text = 'Detaylar';
        this.buttonDetail.HeaderText = i18n("M16287", "İlaç Takvimi");
        this.buttonDetail.Name = 'buttonDetail';
        this.buttonDetail.DisplayIndex = 5;
        this.buttonDetail.Width = 100;

        this.buttonEquivalent = new TTVisual.TTButtonColumn();
        this.buttonEquivalent.Text = 'Eşdeğer';
        this.buttonEquivalent.HeaderText = "Eşdeğer";
        this.buttonEquivalent.Name = 'buttonEquivalent';
        this.buttonEquivalent.DisplayIndex = 5;
        this.buttonEquivalent.Width = 100;

        this.KScheduleMaterialRowType = new TTVisual.TTEnumComboBoxColumn();
        this.KScheduleMaterialRowType.DataTypeName = "KScheduleMaterialRowType";
        this.KScheduleMaterialRowType.DataMember = "KScheduleMaterialRowType";
        this.KScheduleMaterialRowType.DisplayIndex = 2;
        this.KScheduleMaterialRowType.HeaderText = i18n("M23462", "Tipi");
        this.KScheduleMaterialRowType.Name = "KScheduleMaterialRowType";
        this.KScheduleMaterialRowType.ReadOnly = true;
        this.KScheduleMaterialRowType.Width = 100;

        this.Patient = new TTVisual.TTTextBoxColumn();
        this.Patient.DataMember = 'UnlistPatient';
        this.Patient.DisplayIndex = 1;
        this.Patient.HeaderText = i18n("M15125", "Hasta");
        this.Patient.Name = 'Patient';
        this.Patient.ReadOnly = true;
        this.Patient.Width = 200;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = 'UnlistAmount';
        this.Amount.DisplayIndex = 2;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = 'Amount';
        this.Amount.ReadOnly = true;
        this.Amount.Width = 160;
        this.Amount.IsNumeric = true;

        this.Dose = new TTVisual.TTTextBoxColumn();
        this.Dose.DataMember = 'UnlistVolume';
        this.Dose.DisplayIndex = 3;
        this.Dose.HeaderText = i18n("M13284", "Doz");
        this.Dose.Name = 'Dose';
        this.Dose.ReadOnly = true;
        this.Dose.Width = 160;

        this.Reason = new TTVisual.TTTextBoxColumn();
        this.Reason.DataMember = 'UnlistReason';
        this.Reason.DisplayIndex = 4;
        this.Reason.HeaderText = i18n("M21504", "Sebebi");
        this.Reason.Name = 'Reason';
        this.Reason.ReadOnly = true;
        this.Reason.Width = 270;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Description.Name = 'Description';
        this.Description.TabIndex = 6;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 0;



        this.IDPatient = new TTVisual.TTTextBox();
        this.IDPatient.BackColor = '#F0F0F0';
        this.IDPatient.ReadOnly = true;
        this.IDPatient.Name = 'IDPatient';
        this.IDPatient.TabIndex = 17;

        this.FullNamePatient = new TTVisual.TTTextBox();
        this.FullNamePatient.BackColor = '#F0F0F0';
        this.FullNamePatient.ReadOnly = true;
        this.FullNamePatient.Name = 'FullNamePatient';
        this.FullNamePatient.TabIndex = 19;

        this.StartDate = new TTVisual.TTDateTimePicker();
        this.StartDate.BackColor = '#F0F0F0';
        this.StartDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.StartDate.Format = DateTimePickerFormat.Custom;
        this.StartDate.Enabled = false;
        this.StartDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.StartDate.Name = 'StartDate';
        this.StartDate.TabIndex = 1;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.Required = true;
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = 'RoomAndSubStoreList';
        this.DestinationStore.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.DestinationStore.Name = 'DestinationStore';
        this.DestinationStore.TabIndex = 5;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.CustomFormat = 'dd/MM/yyyy';
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.ReadOnly = true;
        this.TransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 1;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = '#DCDCDC';
        this.labelTransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelTransactionDate.ForeColor = '#000000';
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 9;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.BackColor = '#F0F0F0';
        this.EndDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.EndDate.Format = DateTimePickerFormat.Custom;
        this.EndDate.Enabled = false;
        this.EndDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.EndDate.Name = 'EndDate';
        this.EndDate.TabIndex = 1;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M16679", "İstek Yapılan Depo");
        this.labelStore.BackColor = '#DCDCDC';
        this.labelStore.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelStore.ForeColor = '#000000';
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 10;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.BackColor = '#DCDCDC';
        this.labelDescription.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelDescription.ForeColor = '#000000';
        this.labelDescription.Name = 'labelDescription';
        this.labelDescription.TabIndex = 14;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.BackColor = '#DCDCDC';
        this.labelStockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelStockActionID.ForeColor = '#000000';
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 8;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.Required = true;
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'StoresList';
        this.Store.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 2;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M16660", "İstek Yapan Depo");
        this.labelDestinationStore.BackColor = '#DCDCDC';
        this.labelDestinationStore.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelDestinationStore.ForeColor = '#000000';
        this.labelDestinationStore.Name = 'labelDestinationStore';
        this.labelDestinationStore.TabIndex = 13;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M11637", "Başlangıç Tarihi");
        this.ttlabel1.BackColor = '#DCDCDC';
        this.ttlabel1.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel1.ForeColor = '#000000';
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 9;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M11939", "Bitiş Tarihi");
        this.ttlabel2.BackColor = '#DCDCDC';
        this.ttlabel2.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel2.ForeColor = '#000000';
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 9;

        this.labelFullNamePatient = new TTVisual.TTLabel();
        this.labelFullNamePatient.Text = i18n("M15428", "Hastanın Adı Soyadı ");
        this.labelFullNamePatient.Name = 'labelFullNamePatient';
        this.labelFullNamePatient.TabIndex = 20;

        this.labelIDPatient = new TTVisual.TTLabel();
        this.labelIDPatient.Text = i18n("M15230", "Hasta ID");
        this.labelIDPatient.Name = 'labelIDPatient';
        this.labelIDPatient.TabIndex = 18;

        this.MKYS_TeslimAlan = new TTVisual.TTTextBoxColumn();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';

        this.MaterialKSchedulePatienOwnDrug = new TTVisual.TTListBoxColumn();
        this.MaterialKSchedulePatienOwnDrug.ListDefName = 'MaterialListDefinition';
        this.MaterialKSchedulePatienOwnDrug.DataMember = 'Material';
        this.MaterialKSchedulePatienOwnDrug.ReadOnly = true;
        this.MaterialKSchedulePatienOwnDrug.DisplayIndex = 0;
        this.MaterialKSchedulePatienOwnDrug.HeaderText = "ilaç";
        this.MaterialKSchedulePatienOwnDrug.Name = "MaterialKSchedulePatienOwnDrug";
        this.MaterialKSchedulePatienOwnDrug.Width = 500;

        this.DrugAmountKSchedulePatienOwnDrug = new TTVisual.TTTextBoxColumn();
        this.DrugAmountKSchedulePatienOwnDrug.DataMember = "DrugAmount";
        this.DrugAmountKSchedulePatienOwnDrug.DisplayIndex = 11;
        this.DrugAmountKSchedulePatienOwnDrug.HeaderText = i18n("M19030", "Miktar");
        this.DrugAmountKSchedulePatienOwnDrug.Name = "DrugAmountKSchedulePatienOwnDrug";
        this.DrugAmountKSchedulePatienOwnDrug.Width = 200;
        this.DrugAmountKSchedulePatienOwnDrug.ReadOnly = true;
        this.DrugAmountKSchedulePatienOwnDrug.IsNumeric = true;

        this.StockActionStatusKSchedulePatienOwnDrug = new TTVisual.TTEnumComboBoxColumn();
        this.StockActionStatusKSchedulePatienOwnDrug.DataTypeName = "StockActionDetailStatusEnum";
        this.StockActionStatusKSchedulePatienOwnDrug.DataMember = "StockActionStatus";
        this.StockActionStatusKSchedulePatienOwnDrug.DisplayIndex = 2;
        this.StockActionStatusKSchedulePatienOwnDrug.HeaderText = i18n("M13372", "Durumu");
        this.StockActionStatusKSchedulePatienOwnDrug.Name = "StockActionStatusKSchedulePatienOwnDrug";
        this.StockActionStatusKSchedulePatienOwnDrug.Width = 120;

        this.BarcodeVerifyCounterForOwnDrug = new TTVisual.TTTextBoxColumn();
        this.BarcodeVerifyCounterForOwnDrug.DataMember = 'BarcodeVerifyCounter';
        this.BarcodeVerifyCounterForOwnDrug.DisplayIndex = 2;
        this.BarcodeVerifyCounterForOwnDrug.HeaderText = 'Doğrulanan Mik.';
        this.BarcodeVerifyCounterForOwnDrug.Name = 'BarcodeVerifyCounterForOwnDrug';
        this.BarcodeVerifyCounterForOwnDrug.ReadOnly = true;
        this.BarcodeVerifyCounterForOwnDrug.Width = 100;
        this.BarcodeVerifyCounterForOwnDrug.IsNumeric = true;


        this.IsImmediateCheckGrid = new TTVisual.TTCheckBoxColumn();
        this.IsImmediateCheckGrid.HeaderText = i18n("M10430", "Acil İlaç");
        this.IsImmediateCheckGrid.Name = 'IsImmediateCheckGrid';
        this.IsImmediateCheckGrid.DataMember = 'IsImmediate';
        this.IsImmediateCheckGrid.ReadOnly = true;


        this.BarcodeVerifyCounter = new TTVisual.TTTextBoxColumn();
        this.BarcodeVerifyCounter.DataMember = 'BarcodeVerifyCounter';
        this.BarcodeVerifyCounter.DisplayIndex = 2;
        this.BarcodeVerifyCounter.HeaderText = 'Doğrulanan Mik.';
        this.BarcodeVerifyCounter.Name = 'BarcodeVerifyCounter';
        this.BarcodeVerifyCounter.ReadOnly = true;
        this.BarcodeVerifyCounter.Width = 100;
        this.BarcodeVerifyCounter.IsNumeric = true;

        this.ExpirationDatePatientOwnDrugEntryDetail = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDatePatientOwnDrugEntryDetail.Format = DateTimePickerFormat.Custom;
        this.ExpirationDatePatientOwnDrugEntryDetail.CustomFormat = "MM/yyyy";
        this.ExpirationDatePatientOwnDrugEntryDetail.DataMember = "ExpirationDate";
        this.ExpirationDatePatientOwnDrugEntryDetail.DisplayIndex = 13;
        this.ExpirationDatePatientOwnDrugEntryDetail.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDatePatientOwnDrugEntryDetail.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDatePatientOwnDrugEntryDetail.Width = 180;
        this.ExpirationDatePatientOwnDrugEntryDetail.ReadOnly = true;

        this.KSchedulePatienOwnDrugsColumns = [this.MaterialKSchedulePatienOwnDrug, this.DrugAmountKSchedulePatienOwnDrug, this.ExpirationDatePatientOwnDrugEntryDetail, this.StockActionStatusKSchedulePatienOwnDrug, this.BarcodeVerifyCounterForOwnDrug];
        this.DrugsColumns = [this.TDrug, this.TAmount]; //, this.QuarantineNo
        this.StockActionOutDetailsColumns = [this.buttonDetail, this.buttonEquivalent, this.KScheduleMaterialRowType, this.IsImmediateCheckGrid, this.DrugOrderStartDate, this.Material, this.RequestAmount, this.ReceivedAmount, this.StoreInheld,
        this.DemandDescription, this.UsageNote, this.StatusStockActionDetail, this.BarcodeVerifyCounter
            , this.ExpirationDatePatientOwnDrugEntryDetail]; //KSchedulePatienOwnDrugs için eklendi    , this.StockLevelType ,this.QuarantinaNO, ise kulanılmadığı için çıkarıldı
        this.ttgrid2Columns = [this.UnListDrug, this.Patient, this.Amount, this.Dose, this.Reason];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2];
        this.tttabpage3.Controls = [this.Drugs];
        this.tttabpage1.Controls = [this.StockActionOutDetails];
        this.tttabpage2.Controls = [this.ttgrid2];
        this.Controls = [this.IsImmediateCheckGrid, this.KSchedulePatienOwnDrugs, this.MKYS_TeslimAlan, this.tttabcontrol1, this.tttextbox1, this.Drugs, this.TDrug,
        this.TAmount, this.QuarantineNo, this.tttabpage1, this.StockActionOutDetails, this.PatientNo,
        this.PatientName, this.Material, this.RequestAmount, this.ReceivedAmount,
        this.StoreInheld, this.DemandDescription, this.StatusStockActionDetail,
        this.tttabpage2, this.ttgrid2, this.UnListDrug, this.Patient, this.Amount, this.Dose, this.Reason,
        this.Description, this.StockActionID, this.IDPatient, this.FullNamePatient, this.StartDate,
        this.DestinationStore, this.TransactionDate, this.labelTransactionDate, this.EndDate, this.ExpirationDatePatientOwnDrugEntryDetail,
        this.labelStore, this.labelDescription, this.labelStockActionID, this.Store, this.labelDestinationStore, this.ttlabel1, this.ttlabel2, this.labelFullNamePatient, this.labelIDPatient]; //, this.StockLevelType, this.QuarantinaNO

    }


}
