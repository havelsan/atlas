//$0919EA4E
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { KScheduleCompletedFormViewModel, InpatientHasDrugListDTO } from './KScheduleCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { KSchedule, KScheduleMaterialRowType, StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionBaseForm } from 'Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { KScheduleUnListMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { DrugOrderIntroductionService, TempDrugOrder, OldDrugOrderIntroductionDet } from 'ObjectClassService/DrugOrderIntroductionService';
import query from 'devextreme/data/query';
import { DxDataGridComponent } from 'devextreme-angular';


import { StockActionService, InPatientPhysicianApplication_Output } from 'Fw/Services/StockActionService';


import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { KScheduleService, GetCompletedKScheduleMaterial_Output, HimsDrugBarcodesContainer, PrintBarcodeForPursaklar_Input, DrugBarcodesContainer } from 'ObjectClassService/KScheduleService';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { IBarcodePrinterProvider } from 'app/Barcode/Services/IBarcodePrinterProvider';
import { barcodeProviderFactory } from 'app/Barcode/Services/BarcodeProviderFactory';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { KScheduleMaterialRowViewModel } from 'NebulaClient/Services/ObjectService/KScheduleService';
@Component({
    selector: 'KScheduleCompletedForm',
    templateUrl: './KScheduleCompletedForm.html',
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
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }]
})
export class KScheduleCompletedForm extends StockActionBaseForm implements OnInit {
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
    Material: TTVisual.ITTListBoxColumn;
    Patient: TTVisual.ITTTextBoxColumn;
    PatientName: TTVisual.ITTTextBoxColumn;
    PatientNo: TTVisual.ITTTextBoxColumn;
    //QuarantinaNO: TTVisual.ITTTextBoxColumn;
    QuarantineNo: TTVisual.ITTTextBoxColumn;
    Reason: TTVisual.ITTTextBoxColumn;
    ReceivedAmount: TTVisual.ITTTextBoxColumn;
    RequestAmount: TTVisual.ITTTextBoxColumn;
    StartDate: TTVisual.ITTDateTimePicker;
    StatusStockActionDetail: TTVisual.ITTEnumComboBoxColumn;
    KScheduleMaterialRowType: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockActionOutDetails: TTVisual.ITTGrid;
    // StockLevelType: TTVisual.ITTListDefComboBoxColumn;
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
    UnListDrug: TTVisual.ITTTextBoxColumn;
    MaterialKSchedulePatienOwnDrug: TTVisual.ITTListBoxColumn;
    DrugAmountKSchedulePatienOwnDrug: TTVisual.ITTTextBoxColumn;
    StockActionStatusKSchedulePatienOwnDrug: TTVisual.ITTEnumComboBoxColumn;
    KSchedulePatienOwnDrugs: TTVisual.ITTGrid;
    ExpirationDatePatientOwnDrugEntryDetail: TTVisual.ITTDateTimePickerColumn;
    public clinicName: string;
    public clinicRoom: string;
    public clinicBed: string;
    public clinicProtocolNo: string;
    public clinicDischargeDate: Date;
    public hasPhysicianApplication: boolean = false;

    tempDrugOrders: Array<TempDrugOrder>;
    completedKScheduleMaterial: Array<GetCompletedKScheduleMaterial_Output>;
    expanded = true;
    totalCount: number;
    @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;
    public KSchedulePatienOwnDrugsColumns = [];
    public DrugsColumns = [];
    public StockActionOutDetailsColumns = [];
    public ttgrid2Columns = [];
    public kScheduleCompletedFormViewModel: KScheduleCompletedFormViewModel = new KScheduleCompletedFormViewModel();

    public InpatientHasDrugList: Array<InpatientHasDrugListDTO> = new Array<InpatientHasDrugListDTO>();
    
    public KScheduleMaterialRowViewModelList: Array<KScheduleMaterialRowViewModel> = new Array<KScheduleMaterialRowViewModel>();


    public get _KSchedule(): KSchedule {
        return this._TTObject as KSchedule;
    }
    private KScheduleCompletedForm_DocumentUrl: string = '/api/KScheduleService/KScheduleCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private objectContextService: ObjectContextService,
        private barcodePrintService: IBarcodePrintService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.KScheduleCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }



    tabSelectionPatient(event) {
        if (event.addedItems[0].title === "Bu Gelişe Ait İlaçlar") {
            if (this.InpatientHasDrugList.length == 0) {
                let that = this;
                let apiUrl: string = 'api/KScheduleService/GetInpatientHasDrugList?InPatientPhysicianApplication='+this.kScheduleCompletedFormViewModel._KSchedule.InPatientPhysicianApplication;
                this.httpService.post<Array<InpatientHasDrugListDTO>>(apiUrl, null).then(
                    result => {
                        this.InpatientHasDrugList = result;
                    },
                ).catch(ex => {
              
                });
            }
        }
    }

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
            caption : 'Malzeme Türü',
            dataField:'MaterialType',
            allowEditing:false,
            width:150,
        }
    ];

    public MaterialGridColumns = [
        {
            caption: i18n("M23462", "Tipi"),
            dataField: 'KScheduleMaterialRowType',
            lookup: { dataSource: KScheduleMaterialRowType.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            width: 'auto',
            allowEditing: false
        },
        {
            caption: i18n("M17244", "Uyg. Baş. Tarihi"),
            dataField: 'DrugOrderStartDate',
            dataType: 'date',
            format: 'dd/MM/yyyy hh:mm',
            allowEditing: false,
           
        },
        {
            caption: i18n("M16287", "İlaç"),
            dataField: 'Material.Name',
            allowEditing: false,
           
        },
        {
            caption: i18n("M16713", "İstenen Miktar"),
            dataField: 'RequestAmount',
            allowEditing: false,
          
        },
        {
            caption: i18n("M17315", "Karşılanan Miktar"),
            dataField: 'ReceivedAmount',
            dataType: 'number',
            allowEditing: false,
           
        },
        {
            caption: i18n("M13460", "Eczane Mevcudu"),
            dataField: 'StoreInheld',
            dataType: 'number',
            allowEditing: false,
           
        },
        {
            caption: "Reçete No",
            dataField: 'PrescriptionNo',
            allowEditing: false,
            width: 80
        },
        {
            caption: i18n("M10469", "Açıklama"),
            dataField: 'DemandDescription',
            allowEditing: false,
          
        },
        {
            caption: i18n("M15131", "İlaç Kullanım Şekli"),
            dataField: 'UsageNote',
            allowEditing: false,
            
        },
        {
            caption: "Durum",
            dataField: 'Status',
            lookup: { dataSource: StockActionDetailStatusEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            
            allowEditing: false
        }
    ];


    // ***** Method declarations start *****

    /*  protected async PreScript() {
          super.PreScript();
          if (this._KSchedule instanceof KScheduleDaily) {
              this.DropCurrentStateReport(typeof TTReportClasses.I_KScheduleReport);
              this.DropCurrentStateReport(typeof TTReportClasses.I_KScheduleBarcodeReport);
          }
          else {
              this.DropCurrentStateReport(typeof TTReportClasses.I_KScheduleDailyReport);
          }
          let kSchedule: KSchedule = this._KSchedule;
          let drugsHashtable: Dictionary<Guid, Object> = new Dictionary<Guid, Object>();
          for (let kScheduleMaterial of this._KSchedule.StockActionOutDetails) {
              let stocks: Array<Stock> = (await StockService.GetStoreMaterial(kSchedule.ObjectContext, kSchedule.Store.ObjectID, kScheduleMaterial.Material.ObjectID));
              if (stocks.length > 0) {
                  let stock: Stock = stocks[0];
                  kScheduleMaterial.StoreInheld = stock.Inheld;
              }
              if (drugsHashtable.containsKey(kScheduleMaterial.Material.ObjectID)) {
                  let material: KSchedule.KScheduleTotalMaterial = (<KSchedule.KScheduleTotalMaterial>drugsHashtable[kScheduleMaterial.Material.ObjectID]);
                  material.QuarantinaNo = Convert.toString(material.QuarantinaNo) + "," + Convert.toString(kScheduleMaterial.QuarantinaNO);
                  material.TotalAmount = <number>material.TotalAmount + <number>kScheduleMaterial.Amount;
                  drugsHashtable[kScheduleMaterial.Material.ObjectID] = material;
              }
              else {
                  let kScheludeTotalMaterial: KSchedule.KScheduleTotalMaterial = new KSchedule.KScheduleTotalMaterial();
                  kScheludeTotalMaterial.QuarantinaNo = Convert.toString(kScheduleMaterial.QuarantinaNO);
                  kScheludeTotalMaterial.TotalAmount = <number>kScheduleMaterial.Amount;
                  drugsHashtable.push(kScheduleMaterial.Material.ObjectID, kScheludeTotalMaterial);
              }
          }
          for (let drugDetails of drugsHashtable) {
              let material: Material = <Material>kSchedule.ObjectContext.GetObject(new Guid(drugDetails.Key.toString()), "MATERIAL");
              let kScheduleTotalMaterial: KSchedule.KScheduleTotalMaterial = (<KSchedule.KScheduleTotalMaterial>drugDetails.Value);
              let addedRow: TTVisual.ITTGridRow = this.Drugs.Rows.push();
              addedRow.Cells[0].Value = material.ObjectID;
              addedRow.Cells[1].Value = kScheduleTotalMaterial.TotalAmount;
              addedRow.Cells[2].Value = Convert.toString(kScheduleTotalMaterial.QuarantinaNo);
          }
      }*/


    StockActionOutDetails_CellValueChangedEmitted(data: any) { }
    public patientOwnDrugDesciption: string;
    protected async ClientSidePreScript(): Promise<void> {
        let outputCompleted: Array<GetCompletedKScheduleMaterial_Output> = await KScheduleService.GetCompletedKScheduleMaterial(this._KSchedule.Episode.ObjectID);
        this.completedKScheduleMaterial = outputCompleted;
        let dateTime: Date = null;

        let oldOrders: OldDrugOrderIntroductionDet = await DrugOrderIntroductionService.GetOldDrugOrderIntroductionDetsWithDate(this._KSchedule.Episode, dateTime);
        this.tempDrugOrders = oldOrders.TempDrugOrders;
        this.totalCount = this.getGroupCount('OrderType');

        if (this._KSchedule.InPatientPhysicianApplication !== undefined) {

            this.hasPhysicianApplication = true;

            let output: InPatientPhysicianApplication_Output = await StockActionService.GetInPatientPhysicianApplication_Info(this._KSchedule.InPatientPhysicianApplication.toString());

            if (output != null) {
                this.clinicProtocolNo = output.clinicProtocolNo;
                this.clinicBed = output.clinicBed;
                this.clinicRoom = output.clinicRoom;
                this.clinicName = output.clinicName;
                this.clinicDischargeDate = output.clinicDischargeDate;
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

        if (this.kScheduleCompletedFormViewModel != null && this.kScheduleCompletedFormViewModel.KScheduleMaterialRowViewModelList != undefined) {
            let KSchedulePatienOwnDrugscount = (this.kScheduleCompletedFormViewModel.KScheduleMaterialRowViewModelList.filter(dr => dr.KScheduleMaterialRowType == KScheduleMaterialRowType.KSchedulePatienOwnDrug)).length;
            if (KSchedulePatienOwnDrugscount > 0) {
                this.patientOwnDrugDesciption = "  Hastanın yanında getirdiği ilaçlardan " + KSchedulePatienOwnDrugscount.toString() + " tane order verilmiştir!!";
            }
        }


    }


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

    getGroupCount(groupField) {
        return query(this.tempDrugOrders)
            .groupBy(groupField)
            .toArray().length;
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
                    value: 'OrderType',
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
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new KSchedule();
        this.kScheduleCompletedFormViewModel = new KScheduleCompletedFormViewModel();
        this._ViewModel = this.kScheduleCompletedFormViewModel;
        this.kScheduleCompletedFormViewModel._KSchedule = this._TTObject as KSchedule;
        //this.kScheduleCompletedFormViewModel._KSchedule.KScheduleMaterials = new Array<KScheduleMaterial>();
        this.kScheduleCompletedFormViewModel._KSchedule.KScheduleUnListMaterials = new Array<KScheduleUnListMaterial>();
        //this.kScheduleCompletedFormViewModel._KSchedule.KSchedulePatienOwnDrugs = new Array<KSchedulePatienOwnDrug>();
        this.kScheduleCompletedFormViewModel._KSchedule.Episode = new Episode();
        this.kScheduleCompletedFormViewModel._KSchedule.Episode.Patient = new Patient();
        this.kScheduleCompletedFormViewModel._KSchedule.DestinationStore = new Store();
        this.kScheduleCompletedFormViewModel._KSchedule.Store = new Store();
    }
    public headerOwnDrugAmount: string;
    protected loadViewModel() {
        let that = this;

        that.kScheduleCompletedFormViewModel = this._ViewModel as KScheduleCompletedFormViewModel;
        that._TTObject = this.kScheduleCompletedFormViewModel._KSchedule;
        if (this.kScheduleCompletedFormViewModel == null)
            this.kScheduleCompletedFormViewModel = new KScheduleCompletedFormViewModel();
        if (this.kScheduleCompletedFormViewModel._KSchedule == null)
            this.kScheduleCompletedFormViewModel._KSchedule = new KSchedule();
            
        // KSchedulePatienOwnDrugs ve KScheduleMaterials kaldırılıp KScheduleMaterialRowViewModelList da birleştirildi
        //that.kScheduleCompletedFormViewModel._KSchedule.KScheduleMaterials = that.kScheduleCompletedFormViewModel.StockActionOutDetailsGridList;
        //for (let detailItem of that.kScheduleCompletedFormViewModel.StockActionOutDetailsGridList) {
        //    let materialObjectID = detailItem['Material'];
        //    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
        //        let material = that.kScheduleCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
        //         if (material) {
        //            detailItem.Material = material;
        //        }
        //    }
        //    let stockLevelTypeObjectID = detailItem['StockLevelType'];
        //    if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
        //        let stockLevelType = that.kScheduleCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
        //         if (stockLevelType) {
        //            detailItem.StockLevelType = stockLevelType;
        //        }
        //    }
        //}
        //that.kScheduleCompletedFormViewModel._KSchedule.KSchedulePatienOwnDrugs = that.kScheduleCompletedFormViewModel.KSchedulePatienOwnDrugsGridList;
        //for (let detailItemOwn of that.kScheduleCompletedFormViewModel.KSchedulePatienOwnDrugsGridList) {
        //    let materialOwnObjectID = detailItemOwn['Material'];
        //    if (materialOwnObjectID != null && (typeof materialOwnObjectID === 'string')) {
        //        let materialOwn = that.kScheduleCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialOwnObjectID.toString());
        //         if (materialOwn) {
        //            detailItemOwn.Material = materialOwn;
        //        }
        //    }
        //}
        that.kScheduleCompletedFormViewModel._KSchedule.KScheduleUnListMaterials = that.kScheduleCompletedFormViewModel.ttgrid2GridList;
        for (let detailItem of that.kScheduleCompletedFormViewModel.ttgrid2GridList) {
        }
        let episodeObjectID = that.kScheduleCompletedFormViewModel._KSchedule['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.kScheduleCompletedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.kScheduleCompletedFormViewModel._KSchedule.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.kScheduleCompletedFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let destinationStoreObjectID = that.kScheduleCompletedFormViewModel._KSchedule['DestinationStore'];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.kScheduleCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.kScheduleCompletedFormViewModel._KSchedule.DestinationStore = destinationStore;
            }
        }
        let storeObjectID = that.kScheduleCompletedFormViewModel._KSchedule['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.kScheduleCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.kScheduleCompletedFormViewModel._KSchedule.Store = store;
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(KScheduleCompletedFormViewModel);
        if (this._KSchedule.CurrentStateDefID.toString() === KSchedule.KScheduleStates.RequestFulfilled.id.toString()) {
            this.FormCaption = i18n("M15030", "Günlük İlaç Çizelgesi   ( Tamamlandı )");
        }
        if (this._KSchedule.CurrentStateDefID.toString() === KSchedule.KScheduleStates.Cancelled.id.toString()) {
            this.FormCaption = i18n("M15031", "Günlük İlaç Çizelgesi  ( İptal Edildi )");
        }

        /*this.headerOwnDrugAmount = 'Hasta Yanında Getirdiği İlaçlar(' + this._KSchedule.KSchedulePatienOwnDrugs.length.toString() + ')';
        const item = this.tab.instance.option('items[1]');
        item.title = this.headerOwnDrugAmount;
        this.tab.instance.option('items[1]', item);*/
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

    private async KSchedulePatienOwnDrugs_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {

    }

    //public async KSchedulePatienOwnDrugs_CellValueChangedEmitted(data: any): Promise<void> {
    //    await this.KSchedulePatienOwnDrugs_CellValueChanged(data, null, null);
    //}

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
        this.KSchedulePatienOwnDrugs.Name = 'KSchedulePatienOwnDrugs';
        this.KSchedulePatienOwnDrugs.TabIndex = 32;
        this.KSchedulePatienOwnDrugs.AllowUserToAddRows = false;
        this.KSchedulePatienOwnDrugs.AllowUserToDeleteRows = false;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 0;
        this.tttabpage3.TabIndex = 1;
        this.tttabpage3.Text = i18n("M16709", "İstenen İlaçlar");
        this.tttabpage3.Name = 'tttabpage3';
        this.tttabpage3.Visible = false;

        this.Drugs = new TTVisual.TTGrid();
        this.Drugs.ReadOnly = true;
        this.Drugs.Name = 'Drugs';
        this.Drugs.TabIndex = 0;
        this.Drugs.Height = 350;
        this.Drugs.AllowUserToAddRows = false;
        this.Drugs.AllowUserToDeleteRows = false;

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
        this.tttabpage1.Text = i18n("M16710", "İstenen İlaçlar (Hasta Bazında)");
        this.tttabpage1.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.tttabpage1.Name = 'tttabpage1';

        this.StockActionOutDetails = new TTVisual.TTGrid();
        this.StockActionOutDetails.AllowUserToAddRows = false;
        this.StockActionOutDetails.AllowUserToDeleteRows = false;
        this.StockActionOutDetails.ReadOnly = true;
        this.StockActionOutDetails.Name = 'StockActionOutDetails';
        this.StockActionOutDetails.TabIndex = 0;
        this.StockActionOutDetails.Height = 350;

        this.PatientNo = new TTVisual.TTTextBoxColumn();
        this.PatientNo.DataMember = 'PatientID';
        this.PatientNo.DisplayIndex = 0;
        this.PatientNo.HeaderText = i18n("M15286", "Hasta Numarası");
        this.PatientNo.Name = 'PatientNo';
        this.PatientNo.ReadOnly = true;
        this.PatientNo.Width = 160;

        this.PatientName = new TTVisual.TTTextBoxColumn();
        this.PatientName.DataMember = 'PatientName';
        this.PatientName.DisplayIndex = 1;
        this.PatientName.HeaderText = i18n("M15131", "Hasta Adı");
        this.PatientName.Name = 'PatientName';
        this.PatientName.ReadOnly = true;
        this.PatientName.Width = 300;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = 'MaterialListDefinition';
        this.Material.DataMember = 'Material';
        this.Material.DisplayIndex = 2;
        this.Material.HeaderText = i18n("M16287", "İlaç");
        this.Material.Name = 'Material';
        this.Material.ReadOnly = true;
        this.Material.Width = 500;

        this.RequestAmount = new TTVisual.TTTextBoxColumn();
        this.RequestAmount.DataMember = 'RequestAmount';
        this.RequestAmount.DisplayIndex = 3;
        this.RequestAmount.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequestAmount.Name = 'RequestAmount';
        this.RequestAmount.ReadOnly = true;
        this.RequestAmount.Width = 160;

        this.ReceivedAmount = new TTVisual.TTTextBoxColumn();
        this.ReceivedAmount.DataMember = 'ReceivedAmount'; // kScheduleMaterial.Amount;
        this.ReceivedAmount.DisplayIndex = 4;
        this.ReceivedAmount.HeaderText = i18n("M17315", "Karşılanan Miktar");
        this.ReceivedAmount.Name = 'ReceivedAmount';
        this.ReceivedAmount.Width = 160;

        //this.QuarantinaNO = new TTVisual.TTTextBoxColumn();
        //this.QuarantinaNO.DataMember = 'QuarantinaNO';
        //this.QuarantinaNO.DisplayIndex = 5;
        //this.QuarantinaNO.HeaderText = i18n("M17265", "Karantina No");
        //this.QuarantinaNO.Name = 'QuarantinaNO';
        //this.QuarantinaNO.ReadOnly = true;
        //this.QuarantinaNO.Width = 160;
        //this.QuarantinaNO.Visible = false;

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
        this.StatusStockActionDetail.ReadOnly = true;

        //this.StockLevelType = new TTVisual.TTListDefComboBoxColumn();
        //this.StockLevelType.ListDefName = 'StockLevelTypeList';
        //this.StockLevelType.DataMember = 'StockLevelType';
        //this.StockLevelType.DisplayIndex = 8;
        //this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        //this.StockLevelType.Name = 'StockLevelType';
        //this.StockLevelType.Visible = false;
        //this.StockLevelType.Width = 160;

        this.KScheduleMaterialRowType = new TTVisual.TTEnumComboBoxColumn();
        this.KScheduleMaterialRowType.DataTypeName = "KScheduleMaterialRowType";
        this.KScheduleMaterialRowType.DataMember = "KScheduleMaterialRowType";
        this.KScheduleMaterialRowType.DisplayIndex = 2;
        this.KScheduleMaterialRowType.HeaderText = i18n("M23462", "Tipi");
        this.KScheduleMaterialRowType.Name = "KScheduleMaterialRowType";
        this.KScheduleMaterialRowType.ReadOnly = true;
        this.KScheduleMaterialRowType.Width = 100;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 2;
        this.tttabpage2.BackColor = '#FFFFFF';
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = 'Çıkmayan İlaçlar';
        this.tttabpage2.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.tttabpage2.Name = 'tttabpage2';

        this.ttgrid2 = new TTVisual.TTGrid();
        this.ttgrid2.AllowUserToDeleteRows = false;
        this.ttgrid2.ReadOnly = true;
        this.ttgrid2.Name = 'ttgrid2';
        this.ttgrid2.TabIndex = 0;
        this.ttgrid2.Height = 350;
        this.ttgrid2.AllowUserToAddRows = false;
        this.ttgrid2.AllowUserToDeleteRows = false;

        this.UnListDrug = new TTVisual.TTTextBoxColumn();
        this.UnListDrug.DataMember = 'UnlistDrug';
        this.UnListDrug.DisplayIndex = 0;
        this.UnListDrug.HeaderText = i18n("M16287", "İlaç");
        this.UnListDrug.Name = 'UnListDrug';
        this.UnListDrug.ReadOnly = true;
        this.UnListDrug.Width = 500;

        this.Patient = new TTVisual.TTTextBoxColumn();
        this.Patient.DataMember = 'UnlistPatient';
        this.Patient.DisplayIndex = 1;
        this.Patient.HeaderText = i18n("M15125", "Hasta");
        this.Patient.Name = 'Patient';
        this.Patient.Width = 200;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = 'UnlistAmount';
        this.Amount.DisplayIndex = 2;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = 'Amount';
        this.Amount.Width = 160;

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
        this.Reason.Width = 270;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.BackColor = '#F0F0F0';
        this.Description.ReadOnly = true;
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
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.CustomFormat = 'dd/MM/yyyy';
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Enabled = false;
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
        this.MaterialKSchedulePatienOwnDrug.HeaderText = i18n("M16287", "İlaç");
        this.MaterialKSchedulePatienOwnDrug.Name = 'MaterialKSchedulePatienOwnDrug';
        this.MaterialKSchedulePatienOwnDrug.Width = 500;

        this.DrugAmountKSchedulePatienOwnDrug = new TTVisual.TTTextBoxColumn();
        this.DrugAmountKSchedulePatienOwnDrug.DataMember = 'DrugAmount';
        this.DrugAmountKSchedulePatienOwnDrug.DisplayIndex = 1;
        this.DrugAmountKSchedulePatienOwnDrug.HeaderText = i18n("M19030", "Miktar");
        this.DrugAmountKSchedulePatienOwnDrug.Name = 'DrugAmountKSchedulePatienOwnDrug';
        this.DrugAmountKSchedulePatienOwnDrug.Width = 300;
        this.DrugAmountKSchedulePatienOwnDrug.ReadOnly = true;
        this.DrugAmountKSchedulePatienOwnDrug.IsNumeric = true;

        this.StockActionStatusKSchedulePatienOwnDrug = new TTVisual.TTEnumComboBoxColumn();
        this.StockActionStatusKSchedulePatienOwnDrug.DataTypeName = 'StockActionDetailStatusEnum';
        this.StockActionStatusKSchedulePatienOwnDrug.DataMember = 'StockActionStatus';
        this.StockActionStatusKSchedulePatienOwnDrug.DisplayIndex = 2;
        this.StockActionStatusKSchedulePatienOwnDrug.HeaderText = i18n("M13372", "Durumu");
        this.StockActionStatusKSchedulePatienOwnDrug.Name = 'StockActionStatusKSchedulePatienOwnDrug';
        this.StockActionStatusKSchedulePatienOwnDrug.Width = 100;

        this.ExpirationDatePatientOwnDrugEntryDetail = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDatePatientOwnDrugEntryDetail.Format = DateTimePickerFormat.Custom;
        this.ExpirationDatePatientOwnDrugEntryDetail.CustomFormat = "MM/yyyy";
        this.ExpirationDatePatientOwnDrugEntryDetail.DataMember = "ExpirationDate";
        this.ExpirationDatePatientOwnDrugEntryDetail.DisplayIndex = 13;
        this.ExpirationDatePatientOwnDrugEntryDetail.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDatePatientOwnDrugEntryDetail.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDatePatientOwnDrugEntryDetail.Width = 180;
        this.ExpirationDatePatientOwnDrugEntryDetail.ReadOnly = true;

        this.KSchedulePatienOwnDrugsColumns = [this.MaterialKSchedulePatienOwnDrug, this.DrugAmountKSchedulePatienOwnDrug, this.ExpirationDatePatientOwnDrugEntryDetail, this.StockActionStatusKSchedulePatienOwnDrug];
        this.DrugsColumns = [this.TDrug, this.TAmount, this.QuarantineNo];
        this.StockActionOutDetailsColumns = [this.KScheduleMaterialRowType, this.Material, this.RequestAmount, this.ReceivedAmount, this.StoreInheld,
        this.DemandDescription, this.StatusStockActionDetail, this.ExpirationDatePatientOwnDrugEntryDetail]; //KSchedulePatienOwnDrugs için eklendi    , this.StockLevelType ,this.QuarantinaNO, ise kulanılmadığı için çıkarıldı
        // this.StockActionOutDetailsColumns = [this.Material, this.RequestAmount, this.ReceivedAmount, this.QuarantinaNO, this.StoreInheld, this.DemandDescription,
        //this.StatusStockActionDetail, this.StockLevelType];
        this.ttgrid2Columns = [this.UnListDrug, this.Patient, this.Amount, this.Dose, this.Reason];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2];
        this.tttabpage3.Controls = [this.Drugs];
        this.tttabpage1.Controls = [this.StockActionOutDetails];
        this.tttabpage2.Controls = [this.ttgrid2];
        this.Controls = [this.KSchedulePatienOwnDrugs, this.MKYS_TeslimAlan, this.tttabcontrol1, this.Drugs, this.TDrug, this.TAmount, this.QuarantineNo, this.tttabpage1, this.StockActionOutDetails,
        this.PatientNo, this.PatientName, this.Material, this.RequestAmount, this.ReceivedAmount, this.StoreInheld, this.DemandDescription, this.ExpirationDatePatientOwnDrugEntryDetail,
        this.tttabpage2, this.ttgrid2, this.UnListDrug, this.Patient, this.Amount, this.Dose, this.Reason, this.Description, this.StockActionID,
        this.IDPatient, this.FullNamePatient, this.StartDate, this.DestinationStore, this.TransactionDate, this.labelTransactionDate, this.EndDate, this.labelStore,
        this.labelDescription, this.labelStockActionID, this.Store, this.labelDestinationStore, this.ttlabel1, this.ttlabel2, this.labelFullNamePatient, this.labelIDPatient, this.KScheduleMaterialRowType]; //, this.StockLevelType, this.QuarantinaNO

    }


}
