//$C044DA99
import { Component, ViewChild, OnInit, AfterViewInit, ElementRef, Output, EventEmitter, OnDestroy, NgZone } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { NursingApplicationMainFormViewModel, ReportController, GetBarcode, NewOrderDetailDTO, GetNewOrderDetail_Input, ApplyNewOrderDetail_Output } from './NursingApplicationMainFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NursingApplication, PatientOwnDrugEntry, PatientOwnDrugEntryDetail, Patient, ResSection, KSchedule, PatientOwnDrugReturn, PatientOwnDrugReturnDetail, PatientLastUseDrug, InPatientPhysicianApplication, Material, StockActionDetailStatusEnum, DrugDefinition, Store } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { EmergencyIntervention } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { NursingApplicationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DxSchedulerComponent, DxDataGridComponent, DxDropDownBoxComponent } from 'devextreme-angular';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { OrderScheduleDetail, ArchiveRequestModel, EpisodeFolderModel } from '../Yatan_Hasta_Modulu/InPatientPhysicianApplicationFormViewModel'; //TODO: ismail bunun yerine kendi objesi gelecek sonra kaldır
import { NursingOrderDetail } from 'NebulaClient/Model/AtlasClientModel'; //TODO: ismail bunun yerine kendi objesi gelecek sonra kaldır
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { IModalService } from "Fw/Services/IModalService";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { OrderTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DrugReturnAction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDeliveryAction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugReturnActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDeliveryActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { RequestedProceduresForm } from "../Tetkik_Istem_Modulu/RequestedProceduresForm";
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { GetPatientOwnDrugEntry_Output, GetPatientNewOwnDrugEntry_Output, DrugOrderIntroductionService, OldDrugOrderIntroductionDet, TempDrugOrder } from 'ObjectClassService/DrugOrderIntroductionService';
import { GetReturnDetails, DrugReturnActionService, GetDrugReturnAndDeliveryDetails } from 'ObjectClassService/DrugReturnActionService';
import { DatePipe } from '@angular/common';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
import { TTObjectStateTransitionDef } from "app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import query from 'devextreme/data/query';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { DateParam } from 'app/NebulaClient/Mscorlib/DateParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { ArrayParam } from 'app/NebulaClient/Mscorlib/ArrayParam';
import { IntegerParam, StringParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { KScheduleService, HimsDrugBarcodesContainer } from 'ObjectClassService/KScheduleService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { SerumBarcodeInfo } from 'app/Barcode/Models/InpatientTreatmentBarcodeInfo';
import { InfoBox, ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ModelForInfoInput } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Kullanilmayan_Malzeme_Raporu/UnusedMaterialFormViewModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { itemData } from 'devexpress-dashboard/data/index.internal';
import { forEach } from 'app/NebulaClient/System/Collections/Enumeration/Enumerator';
import { SurgeryChecklistModel } from '../Tibbi_Surec_Evrensel_Modulu/EpisodeActionFormViewModel';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { EquivalentInfo, StockActionService } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { StockLevelService } from 'app/NebulaClient/Services/ObjectService/StockLevelService';
import { UserHelper } from 'app/Helper/UserHelper';
import { ResourceService } from 'app/NebulaClient/Services/ObjectService/ResourceService';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';

@Component({
    selector: 'NursingApplicationMainForm',
    templateUrl: './NursingApplicationMainForm.html',
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
    providers: [MessageService, SystemApiService, DatePipe, AtlasReportService]
})
export class NursingApplicationMainForm extends EpisodeActionForm implements OnInit, AfterViewInit, OnDestroy {
    Bed: TTVisual.ITTObjectListBox;
    GridDiagnosis: TTVisual.ITTGrid;
    HospitalInpatientDate: TTVisual.ITTDateTimePicker;
    labelBed: TTVisual.ITTLabel;
    labelHospitalInpatientDate: TTVisual.ITTLabel;
    labelResponsibleDoctor: TTVisual.ITTLabel;
    labelResponsibleNurse: TTVisual.ITTLabel;
    labelRoom: TTVisual.ITTLabel;
    labelRoomGroup: TTVisual.ITTLabel;
    ResponsibleDoctor: TTVisual.ITTObjectListBox;
    ResponsibleNurse: TTVisual.ITTObjectListBox;
    Room: TTVisual.ITTObjectListBox;
    RoomGroup: TTVisual.ITTObjectListBox;
    SecDiagnose: TTVisual.ITTListBoxColumn;
    SecDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    SecFreeDiagnosis: TTVisual.ITTTextBoxColumn;
    SecIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    SecResponsibleUser: TTVisual.ITTListBoxColumn;
    InpatientObservationEndTime: TTVisual.ITTDateTimePicker;
    InpatientObservationTime: TTVisual.ITTDateTimePicker;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel21: TTVisual.ITTLabel;
    public GridDiagnosisColumns = [];
    public nursingApplicationMainFormViewModel: NursingApplicationMainFormViewModel = new NursingApplicationMainFormViewModel();
    public get _NursingApplication(): NursingApplication {
        return this._TTObject as NursingApplication;
    }
    private NursingApplicationMainForm_DocumentUrl: string = '/api/NursingApplicationService/NursingApplicationMainForm';
    public _scheduleWidth = "100%";
    currentDate: Date = new Date(Date.now());
    nodScheduleViews: any = ['day'];
    appointmentsData: any[];
    nursingOrderScheduleResource: any[];
    @ViewChild('noddetailscheduler') _noddetailscheduler: DxSchedulerComponent;
    @ViewChild(RequestedProceduresForm) requestedProceduresFormInstance: RequestedProceduresForm;
    public componentInfo: DynamicComponentInfo;
    public _scheduleWorkListDate: Date = new Date();
    public _scheduleCurrentView: string = "day";

    public hasEmergencySpecialityBasedObject: boolean = true;
    public hasEmergencyIntervention: boolean = false;
    public patientOwnDrugEntryies: Array<GetPatientOwnDrugEntry_Output>;
    public patientNewOwnDrugEntryies: Array<GetPatientNewOwnDrugEntry_Output>;
    outputDetails: GetReturnDetails = new GetReturnDetails();
    public startDate: Date;
    public endDate: Date;

    public OrderTypeList: any[];
    public statusListForClient: any[];
    public statusListForNOD: any[];

    public reportController: ReportController = new ReportController();
    public showNursingReport = false;

    ShowPainInfoPopup: boolean = false;
    ShowOutDatedFallingRiskPopUp = false;
    ShowWoundInfoPopup: boolean = false;
    ShowFallingRiskPopup: boolean = false;
    ShowFallingAgeWarningPopup: boolean = false;
    ShowOutDatedFormsPopup: boolean = false;
    ShowDrugFormsPopup: boolean = false;
    fallingAgeWarningMessage: string = "";
    fallingPatientDrugsWarningMessage: string = "";
    fallingRiskMessage: string = "";
    IsMessageShownOnLoad: boolean = false; //sarflar için kaydette tekrarload edildiğinde mesajları göstermesin

    public newNursingFormStartDate: Date;
    public newNursingFormEndDate: Date;
    public allDate: boolean = false;
    public selectedStatusListItems: Array<any> = ['d4f85132-8d05-4dc7-b9b2-fc04bae622b0', '94c4b7eb-b764-4ca5-add6-76e2217f7dd4'];
    public selectedNODStatusListItems: Array<any> = ['95d0ea09-0398-42fc-ba11-45f2583520d3'];
    public printMenuVisible: boolean = false;
    public stateReports: Array<any> = new Array<any>();
    public actionMenuVisible: boolean = false;
    public stateAction: Array<any> = new Array<any>();
    public showPopup: boolean = false;
    public newReportName: string;
    public newReportDefName: string;
    public newTTObjectID: Guid;
    public selecttedOrderType: any;
    public OrderColumns = [
        {
            caption: "Objectid",
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: "ObjectDefId",
            dataField: 'ObjectDefID',
            visible: false,
        },
        {
            caption: "StateId",
            dataField: 'StateID',
            visible: false,
        },
        {
            caption: 'Uygulama Tarihi',
            dataField: 'OrderDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150,
            allowEditing: false,
        },
        {
            caption: 'Uygulama Saati',
            dataField: 'OrderDate',
            dataType: "date",
            format: "shortTime",
            width: 100,
            allowEditing: false,
        },
        {
            caption: "İlaç / Hemşirelik Hizmet Adı",
            dataField: 'OrderName',
            allowEditing: false,
            width: 600,
        },
        {
            caption: "Sonuç",
            dataField: 'Result',
            allowEditing: false,
            width: 150,
        },
        {
            caption: "İlaç Durumu",
            dataField: 'DrugOrderDetailStatus',
            allowEditing: false,
            width: 150,
        },
        {
            caption: "H.Hizmetleri Durumu",
            dataField: 'NursingOrderStatus',
            allowEditing: false,
            width: 150,
        },
        {
            caption: "Türü",
            dataField: 'OrderType',
            allowEditing: false,
            width: 150,
        },
        {
            caption: "Uygulayan Kullanıcı",
            dataField: 'User',
            allowEditing: false,
            width: 200,
        }
    ];
    public ArchiveGridColumns = [
        {
            'caption': i18n("M20568", "Arşiv Numarası"),
            dataField: 'ArchiveNo',
            allowSorting: true,
        },
        {
            'caption': "Kabul No",
            dataField: 'ProtocolNo',
            allowSorting: true
        },
        {
            'caption': 'Yatış Tarihi',
            dataField: 'InpatientDate',
            dataType: 'date',
            format: 'dd.MM.yyyy',
        },
        {
            'caption': 'Çıkış Tarihi',
            dataField: 'DischargeDate',
            dataType: 'date',
            format: 'dd.MM.yyyy',
        },
        {
            'caption': i18n("M24454", "Yatış Yeri"),
            dataField: 'ClinicName',
            allowSorting: true
        },
        {
            'caption': i18n("M24454", "Arşiv Yeri"),
            dataField: 'Location',
            allowSorting: true
        },
        {
            'caption': i18n("M24454", "Arşiv Durumu"),
            dataField: 'Status',
            allowSorting: true
        }
    ];
    public newOrderDetailGridDataSource: Array<NewOrderDetailDTO> = new Array<NewOrderDetailDTO>();
    public selectedNewOrderDetail: Array<NewOrderDetailDTO> = new Array<NewOrderDetailDTO>();

    @ViewChild('orderDetailGrid') orderDetailGrid: DxDataGridComponent;

    message: string = i18n("M30914",
        `1.  Pozisyon değiştirmek
    2.  Mesaj, sıcak-soğuk uygulama
    3.  Dikkati başka yöne çekmek (radyo, tv, müzik vb.)
    4.  Ağrı nedenlerini azaltma yöntemleri konusunda eğitim, iletişim
    5.  Çevrenin sakin, sessiz ve loş ışıklı olmasını sağlamak
    6.  Gevşeme tekniklerini öğretmek
    7.  Ağız bakımı
    8.  Havalı yatak kullanmak
    9.  Arzu ettiği kişilerle görüşmesini sağlamak
    10. Ilık banyo
    11. Farmakolojik girişim
    12. Diğer`).replace(/[\n]/g, "<br\>");

    _showVitalInfoPopUp: boolean = false;

    @Output() nursingDynamicComponentSavedEventEmitter: EventEmitter<Guid> = new EventEmitter<Guid>();

    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private element: ElementRef,
        public systemApiService: SystemApiService,
        protected modalService: IModalService,
        private barcodePrintService: IBarcodePrintService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        protected reportService: AtlasReportService,
        private objectContextService: ObjectContextService, private http: NeHttpService,
        protected ngZone: NgZone) {

        // super('NURSINGAPPLICATION', 'NursingApplicationMainForm')
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingApplicationMainForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.getResourceList();
        this.startDate = new Date();
        this.startDate.setHours(0, 0, 0, 0);
        this.endDate = new Date();
        this.endDate.setHours(23, 59, 59, 0);

        this.newNursingFormStartDate = new Date();
        this.newNursingFormStartDate.setHours(0, 0, 0, 0);
        this.newNursingFormEndDate = new Date();
        this.newNursingFormEndDate.setHours(23, 59, 59, 0);


        this.OrderTypeList = [
            {
                TypeName: 'Tümü',
                TypeID: 0
            }, {
                TypeName: "İlaçlar",
                TypeID: 1
            }, {
                TypeName: "Hemşirelik Hizmetleri",
                TypeID: 2
            }
        ];

        this.selecttedOrderType = 0;


        this.statusListForClient = [
            {
                StateID: 'cb22e74b-a2be-456f-8680-660d0b21dc24',
                StatusItemName: "Eczaneden İstenmedi",
                TypeID: 0
            },
            {
                StateID: 'da01e671-efb9-4d84-8122-4bae07e08c20',
                StatusItemName: "Eczaneden İstendi",
                TypeID: 0
            },
            {
                StateID: 'd4f85132-8d05-4dc7-b9b2-fc04bae622b0',
                StatusItemName: "Teslim Edildi",
                TypeID: 0
            },
            {
                StateID: '94c4b7eb-b764-4ca5-add6-76e2217f7dd4',
                StatusItemName: "Var olan Kullanım",
                TypeID: 0
            },
            {
                StateID: 'd39a37a6-610e-4143-aca2-691ce5818915',
                StatusItemName: "Uygulandı",
                TypeID: 0
            },
            {
                StateID: 'f1b24e44-ecb3-4b44-9b23-1d77e9901721',
                StatusItemName: "Durduruldu",
                TypeID: 0
            },
            {
                StateID: 'add6e452-c007-4849-b477-17d30400abe8',
                StatusItemName: "İptal Edildi",
                TypeID: 0
            },
            {
                StateID: '4223ab9b-1b9f-4f59-845f-b903adcda8a0',
                StatusItemName: "Eczaneye İade Edildi",
                TypeID: 0
            },
            {
                StateID: '14ea4626-5b27-4663-82f9-64968cb4eb63',
                StatusItemName: "Hastaya Teslim Edildi",
                TypeID: 0
            },
        ];

        this.statusListForNOD = [
            {
                StateID: '95d0ea09-0398-42fc-ba11-45f2583520d3',
                StatusItemName: "Uygulanacak",
                TypeID: 0
            },
            {
                StateID: '61c779a2-b25c-42ea-895d-48dc61acc255',
                StatusItemName: "Uygulandı",
                TypeID: 1
            },
            {
                StateID: '75810ba6-7fd0-4124-821b-c05df44e3ca3',
                StatusItemName: "İptal Edildi",
                TypeID: 2
            }
        ];



        this.stateReports = [
            {
                Caption: "Hemşirelik Uygulamaları Planı",
                ReportName: "NursingApplicationOrderInfoReportBySign"
            },
            {
                Caption: "Hasta Order Raporu Yazdır",
                ReportName: "NursingApplicationDailyOrderDetailReport"
            },
            {
                Caption: "Barkod Oluştur",
                ReportName: "OpenBarcodePrint"
            }
        ];

        this.stateAction = [
            {
                Caption: "İlaç Teslim-İade-İmha İşlemi",
                ActionName: "DrugReturnAndDeliveryClick"
            },
            {
                Caption: "Hasta için GİÇ Oluştur",
                ActionName: "getUsercontrolTool"
            },
            {
                Caption: "Hastanın İlaçları Giriş",
                ActionName: "PatientOwnDrugClick"
            },
            {
                Caption: "Hastanın İlaçları İade",
                ActionName: "PatientOwnDrugReturnClick"
            },
            {
                Caption: "Kan Ürun İstem",
                ActionName: "cmdImage_Click"
            },
            {
                Caption: "Sözel Order",
                ActionName: "OpenTeleOrderClick"
            }
            
        ];

       



        this.IsMessageShownOnLoad = false;

    }

    public RefreshNewOrderDetail() {

        if (this.nursingApplicationMainFormViewModel.ShowNewOrderTab == true) {
            let that = this;
            let input: GetNewOrderDetail_Input = new GetNewOrderDetail_Input();
            input.allDate = this.allDate;
            input.nursingApplicationID = that.nursingApplicationMainFormViewModel._NursingApplication.ObjectID;
            input.startDate = that.newNursingFormStartDate;
            input.endDate = that.newNursingFormEndDate;
            input.orderTypeId = that.selecttedOrderType;
            if (that.selectedStatusListItems != null && that.selectedStatusListItems.length > 0) {
                input.drugOrderDetailStateIDs = new Array<Guid>();
                for (let obj of that.selectedStatusListItems) {
                    input.drugOrderDetailStateIDs.push(new Guid(obj));
                }
            }
            if (that.selectedNODStatusListItems != null && that.selectedNODStatusListItems.length > 0) {
                input.nursingOrderDetailStateIDs = new Array<Guid>();
                for (let obj of that.selectedNODStatusListItems) {
                    input.nursingOrderDetailStateIDs.push(new Guid(obj));
                }
            }
            that.httpService.post<Array<NewOrderDetailDTO>>('/api/NursingApplicationService/GetNewOrderDetail', input).then(result => {
                that.newOrderDetailGridDataSource = result;
            });
        }

    }

    public ApplyOrderDetail() {
        let wrongDetails: Array<NewOrderDetailDTO> = this.orderDetailGrid.instance.getSelectedRowsData().filter(x => x.StateID != 'd4f85132-8d05-4dc7-b9b2-fc04bae622b0' && x.StateID != '94c4b7eb-b764-4ca5-add6-76e2217f7dd4');
        if (wrongDetails.length > 0) {
            ServiceLocator.MessageService.showError("Teslim Edildi ve Var olan Kullanım durumundaki ilaç orderlarını uygulayabilirsiniz.")
        } else {
            let drugOrderDetail: Array<NewOrderDetailDTO> = this.selectedNewOrderDetail.filter(x => x.ObjectDefID.toString() == '5beac21d-06b6-4d8f-a574-ff1ea8af3ce8');
            this.httpService.post<ApplyNewOrderDetail_Output>('/api/NursingApplicationService/ApplyNewOrderDetail', drugOrderDetail).then(result => {
                if (result.isError === true) {
                    ServiceLocator.MessageService.showError(result.msg);
                } else {
                    ServiceLocator.MessageService.showSuccess(result.msg);
                    this.RefreshNewOrderDetail();
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
        }

    }

    selectOrder(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {

            if (e.data.OrderType === "İlaç Direktifi") {
                this.openDrugOrderDetail(e.data.ObjectID);
            }

            if (e.data.typeId == OrderTypeEnum.NursingOrder)
                this.openNursingOrderDetailForm(e.data.ObjectID);
        }
    }

    showReportMenu(): void {
        this.printMenuVisible = true;
    }

    onReportMenuClick(e: any) {

        if (e.itemData.ReportName === "NursingApplicationOrderInfoReportBySign") {
            this.showPopup = true;
            this.newReportName = "Hemşirelik Uygulamaları Planı";
            this.newReportDefName = "NursingApplicationOrderInfoReportBySign";
            this.newTTObjectID = this.nursingApplicationMainFormViewModel._NursingApplication.ObjectID;
        }
        if (e.itemData.ReportName === "NursingApplicationDailyOrderDetailReport") {
            this.showPopup = true;
            this.newReportName = "Hasta Order Raporu Yazdır";
            this.newTTObjectID = this.nursingApplicationMainFormViewModel._NursingApplication.ObjectID;
            if (this.stockSiteNgIf) {
                this.newReportDefName = "NursingApplicationOrderInfoReport";
            } else {
                this.newReportDefName = "NursingApplicationDailyOrderDetailReport";
            }
        }
        if (e.itemData.ReportName === "OpenBarcodePrint") {
            this.OpenBarcodePrint();
        }
    }

    public reportPrinted() {

        this.showPopup = false;
    }

    showActionMenu(): void {
        this.actionMenuVisible = true;
    }

    onActionMenuClick(e: any) {
        if (e.itemData.ActionName === "DrugReturnAndDeliveryClick") {
            this.DrugReturnAndDeliveryClick();
        }

        if (e.itemData.ActionName === "getUsercontrolTool") {
            this.getUsercontrolTool();
        }

        if (e.itemData.ActionName === "PatientOwnDrugClick") {
            this.PatientOwnDrugClick();
        }

        if (e.itemData.ActionName === "PatientOwnDrugReturnClick") {
            this.PatientOwnDrugReturnClick();
        }

        if (e.itemData.ActionName === "cmdImage_Click") {
            this.cmdImage_Click();
        }

        if (e.itemData.ActionName === "OpenTeleOrderClick") {
            this.OpenTeleOrderClick();
        }
        if (e.itemData.ActionName === "OpenEmergencyOrderClick") {
            this.OpenEmergencyOrderClick();
        }
    }

    ngAfterViewInit() {
        let that = this;

    }

    // ***** Method declarations start *****
    public tempDrugOrders: Array<TempDrugOrder>;
    public totalCount: number;
    public expanded = true;

    getGroupCount(groupField: string, DrugOrders: Array<TempDrugOrder>) {
        return query(DrugOrders)
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
                },
                {
                    value: 'OrderDate',
                    text: i18n("M22844", "Tarihe Göre Grupla")
                }],
                displayExpr: 'text',
                valueExpr: 'value',
                value: 'OrderDate',
                onValueChanged: this.groupChanged.bind(this)//hataveren yer!! _co.valueChanged is not a function
            }
        }, {
            location: 'before',
            widget: 'dxButton',
            options: {
                hint: i18n("M15727", "Hepsini Kapat"),
                icon: 'chevrondown',
                onClick: this.collapseAllClick.bind(this)
            }
        },
            {
                location: 'before',
                widget: 'dxButton',
                options: {
                    hint: i18n("M30013", "Tümünü Getir"),
                    icon: 'fa fa-align-justify',
                    onClick: this.GetDrugOrderIntroductions.bind(this)
                }
            },

            {
                location: 'after',
                widget: 'dxButton',
                options: {
                    icon: 'refresh',
                    onClick: this.refreshDataGrid.bind(this)
                }
            },
        );
    }
    @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;
    groupChanged(e) {
        this.dataGrid.instance.clearGrouping();
        this.dataGrid.instance.columnOption(e.value, 'groupIndex', 0);
        this.totalCount = this.getGroupCount(e.value, this.tempDrugOrders);
    }

    collapseAllClick(e) {
        this.expanded = !this.expanded;
        e.component.option({
            icon: this.expanded ? 'chevrondown' : 'chevronnext',
            hint: this.expanded ? i18n("M15727", "Hepsini Kapat") : i18n("M15725", "Hepsini Aç")
        });
    }
    GetDrugOrderIntroductions(event) {
        let date: Date = null;
        this.GetDrugOrderIntroductionsWithDate(date);
    }
    refreshDataGrid() {
        this.dataGrid.instance.refresh();
    }
    public async GetDrugOrderIntroductionsWithDate(date: Date) {

        if (date != null) {
            date = Convert.ToDateTime(Convert.ToDateTime(date).ToShortDateString() + " 00:00:00");
        }
        let oldOrders: OldDrugOrderIntroductionDet = await DrugOrderIntroductionService.GetOldDrugOrderIntroductionDetsWithDate(this._NursingApplication.Episode, date);
        this.tempDrugOrders = oldOrders.TempDrugOrders;

        let url: string = '/api/NursingApplicationService/GetNOsByDateForTimeUpdate';
        let input = { 'episode': this._NursingApplication.Episode, 'PlannedStartDate': date };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OldDrugOrderIntroductionDet>(url, input);


        if (this.tempDrugOrders != null)
            this.tempDrugOrders = this.tempDrugOrders.concat(result.TempDrugOrders);
        else
            this.tempDrugOrders = result.TempDrugOrders;

        if (this.tempDrugOrders != null)
            this.totalCount = this.getGroupCount('OrderDate', this.tempDrugOrders);
        else
            this.totalCount = 0;
    }
    private showDrugOrderSchedule(data: Array<DrugOrderDetail>): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderScheduleComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Zaman Çizelgesi';
            modalInfo.Width = 600;
            modalInfo.Height = 400;
            modalInfo.IsShowCloseButton = false;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private showNursingOrderSchedule(data: Array<NursingOrderDetail>): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'NursingOrderScheduleComponent';
            componentInfo.ModuleName = 'HemsirelikIslemleriModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/HemsirelikIslemleriModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Zaman Çizelgesi';
            modalInfo.Width = 600;
            modalInfo.Height = 400;
            modalInfo.IsShowCloseButton = false;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    public async changeDrugOrderClick(data: any) {
        let that = this;
        if (data.data.OrderID == -1) {
            let nursingOrderDetails: Array<NursingOrderDetail> = new Array<NursingOrderDetail>();

            let _url = "/api/NursingApplicationService/GetActiveNursingOrderDetails";
            nursingOrderDetails = await this.httpService.get<Array<NursingOrderDetail>>(_url + '?ObjectID=' + data.data.OrderObjectID);
            nursingOrderDetails = plainToClass(NursingOrderDetail, nursingOrderDetails);

            this.showNursingOrderSchedule(nursingOrderDetails).then(res => {
                let modalActionResult = res as ModalActionResult;
                if (modalActionResult.Result == DialogResult.OK)

                    that.http.post('api/NursingApplicationService/UpdateNursingOrderDetails', res.Param as Array<NursingOrderDetail>)
                        .then((res) => {
                            if (res)
                                ServiceLocator.MessageService.showSuccess('Güncelleme başarılı.');
                            else
                                ServiceLocator.MessageService.showError('Güncelleme yapılırken bir hata oluştu!');
                        })
                        .catch(error => {
                            TTVisual.InfoBox.Alert(error);
                        });


            });
        }
        else {
            let drugOrderDetails: Array<DrugOrderDetail> = new Array<DrugOrderDetail>();

            drugOrderDetails = await DrugOrderIntroductionService.GetActiveDrugOrderDetails(data.data.OrderObjectID);

            this.showDrugOrderSchedule(drugOrderDetails).then(res => {
                let modalActionResult = res as ModalActionResult;
                if (modalActionResult.Result == DialogResult.OK)
                    DrugOrderIntroductionService.UpdateDrugOrderDetails(res.Param as Array<DrugOrderDetail>).then(result => {
                        if (result)
                            ServiceLocator.MessageService.showSuccess('Güncelleme başarılı.');
                        else
                            ServiceLocator.MessageService.showError('Güncelleme yapılırken bir hata oluştu!');
                    });
            });
        }


    }
    public nursingDynamicComponentSaved(event: any) {
        this.nursingDynamicComponentSavedEventEmitter.emit(event);
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingApplication();
        this.nursingApplicationMainFormViewModel = new NursingApplicationMainFormViewModel();
        this._ViewModel = this.nursingApplicationMainFormViewModel;
        this.nursingApplicationMainFormViewModel._NursingApplication = this._TTObject as NursingApplication;
        this.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp = new InPatientTreatmentClinicApplication();
        //this.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission = new BaseInpatientAdmission();
        //this.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed = new ResBed();
        //this.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room = new ResRoom();
        //this.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup = new ResRoomGroup();
        this.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp.ResponsibleNurse = new ResUser();
        this.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp.ProcedureDoctor = new ResUser();
        this.nursingApplicationMainFormViewModel._NursingApplication.Episode = new Episode();
        this.nursingApplicationMainFormViewModel._NursingApplication.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.nursingApplicationMainFormViewModel._NursingApplication.EmergencyIntervention = new EmergencyIntervention();
        this.nursingApplicationMainFormViewModel._NursingApplication.NursingApplicationTreatmentMaterials = new Array<NursingApplicationTreatmentMaterial>();

    }

    protected loadViewModel() {
        let that = this;

        that.nursingApplicationMainFormViewModel = this._ViewModel as NursingApplicationMainFormViewModel;
        that._TTObject = this.nursingApplicationMainFormViewModel._NursingApplication;
        if (this.nursingApplicationMainFormViewModel == null)
            this.nursingApplicationMainFormViewModel = new NursingApplicationMainFormViewModel();
        if (this.nursingApplicationMainFormViewModel._NursingApplication == null)
            this.nursingApplicationMainFormViewModel._NursingApplication = new NursingApplication();
        let inPatientTreatmentClinicAppObjectID = that.nursingApplicationMainFormViewModel._NursingApplication["InPatientTreatmentClinicApp"];
        if (inPatientTreatmentClinicAppObjectID != null && (typeof inPatientTreatmentClinicAppObjectID === 'string')) {
            let inPatientTreatmentClinicApp = that.nursingApplicationMainFormViewModel.InPatientTreatmentClinicApplications.find(o => o.ObjectID.toString() === inPatientTreatmentClinicAppObjectID.toString());
            if (inPatientTreatmentClinicApp) {
                that.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp = inPatientTreatmentClinicApp;
            }
            //if (inPatientTreatmentClinicApp != null) {
            //    let baseInpatientAdmissionObjectID = inPatientTreatmentClinicApp["BaseInpatientAdmission"];
            //    if (baseInpatientAdmissionObjectID != null && (typeof baseInpatientAdmissionObjectID === 'string')) {
            //        let baseInpatientAdmission = that.nursingApplicationMainFormViewModel.BaseInpatientAdmissions.find(o => o.ObjectID.toString() === baseInpatientAdmissionObjectID.toString());
            //        inPatientTreatmentClinicApp.BaseInpatientAdmission = baseInpatientAdmission;
            //        if (baseInpatientAdmission != null) {
            //            let bedObjectID = baseInpatientAdmission["Bed"];
            //            if (bedObjectID != null && (typeof bedObjectID === 'string')) {
            //                let bed = that.nursingApplicationMainFormViewModel.ResBeds.find(o => o.ObjectID.toString() === bedObjectID.toString());
            //                baseInpatientAdmission.Bed = bed;
            //            }
            //        }
            //        if (baseInpatientAdmission != null) {
            //            let roomObjectID = baseInpatientAdmission["Room"];
            //            if (roomObjectID != null && (typeof roomObjectID === 'string')) {
            //                let room = that.nursingApplicationMainFormViewModel.ResRooms.find(o => o.ObjectID.toString() === roomObjectID.toString());
            //                baseInpatientAdmission.Room = room;
            //            }
            //        }
            //        if (baseInpatientAdmission != null) {
            //            let roomGroupObjectID = baseInpatientAdmission["RoomGroup"];
            //            if (roomGroupObjectID != null && (typeof roomGroupObjectID === 'string')) {
            //                let roomGroup = that.nursingApplicationMainFormViewModel.ResRoomGroups.find(o => o.ObjectID.toString() === roomGroupObjectID.toString());
            //                baseInpatientAdmission.RoomGroup = roomGroup;
            //            }
            //        }
            //    }
            //}
            if (inPatientTreatmentClinicApp != null) {
                let responsibleNurseObjectID = inPatientTreatmentClinicApp["ResponsibleNurse"];
                if (responsibleNurseObjectID != null && (typeof responsibleNurseObjectID === 'string')) {
                    let responsibleNurse = that.nursingApplicationMainFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleNurseObjectID.toString());
                    if (responsibleNurse) {
                        inPatientTreatmentClinicApp.ResponsibleNurse = responsibleNurse;
                    }
                }
            }
            if (inPatientTreatmentClinicApp != null) {
                let procedureDoctorObjectID = inPatientTreatmentClinicApp["ProcedureDoctor"];
                if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                    let procedureDoctor = that.nursingApplicationMainFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                    if (procedureDoctor) {
                        inPatientTreatmentClinicApp.ProcedureDoctor = procedureDoctor;
                    }
                }
            }
        }
        let episodeObjectID = that.nursingApplicationMainFormViewModel._NursingApplication["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.nursingApplicationMainFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nursingApplicationMainFormViewModel._NursingApplication.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nursingApplicationMainFormViewModel.GridDiagnosisGridList;
                for (let detailItem of that.nursingApplicationMainFormViewModel.GridDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.nursingApplicationMainFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.nursingApplicationMainFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let emergencyInterventionObjectID = that.nursingApplicationMainFormViewModel._NursingApplication["EmergencyIntervention"];
        if (emergencyInterventionObjectID != null && (typeof emergencyInterventionObjectID === 'string')) {
            let emergencyIntervention = that.nursingApplicationMainFormViewModel.EmergencyInterventions.find(o => o.ObjectID.toString() === emergencyInterventionObjectID.toString());
            if (emergencyIntervention) {
                that.nursingApplicationMainFormViewModel._NursingApplication.EmergencyIntervention = emergencyIntervention;
            }
        }
        //  that.nursingApplicationMainFormViewModel._NursingApplication.NursingApplicationTreatmentMaterials = that.nursingApplicationMainFormViewModel.NewTreatmentMaterialsGridList;
        for (let detailItem of that.nursingApplicationMainFormViewModel.NewTreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.nursingApplicationMainFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.nursingApplicationMainFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.nursingApplicationMainFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            if ((that.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp != null
                && that.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp.IsDailyOperation == true)
                || that.nursingApplicationMainFormViewModel._NursingApplication.EmergencyIntervention != null) {
                let subEpisodeID = detailItem['SubEpisode'];
                if (subEpisodeID != null && (typeof subEpisodeID === 'string')) {
                    let subEpisode = that.nursingApplicationMainFormViewModel.SubEpisodeList.find(o => o.ObjectID.toString() === subEpisodeID.toString());
                    if (subEpisode) {
                        detailItem.SubEpisode = subEpisode;
                    }
                }

                let episodeActionID = detailItem['EpisodeAction'];
                if (episodeActionID != null && (typeof episodeActionID === 'string')) {
                    let episodeAction = that.nursingApplicationMainFormViewModel.EpisodeActionList.find(o => o.ObjectID != null && o.ObjectID.toString() === episodeActionID.toString());
                    if (episodeAction) {
                        detailItem.EpisodeAction = episodeAction;
                    }
                }
            }

        }
    }

    private DrugOrderQueryDayNumber: number = -10;

    private async LoadDrugOrderDayNumber() {
        let result: string = await DrugOrderIntroductionService.GetDrugOrderQueryDayNumber();
        this.DrugOrderQueryDayNumber = Number.parseInt(result);
        if (this.DrugOrderQueryDayNumber > 0)
            this.DrugOrderQueryDayNumber *= (-1);
    }

    public stockSiteNgIf: boolean = true;

    async ngOnInit() {
        let that = this;

        // this.selectedStatusListItems = ['d4f85132-8d05-4dc7-b9b2-fc04bae622b0', '94c4b7eb-b764-4ca5-add6-76e2217f7dd4'];
        // this.selectedNODStatusListItems = ['95d0ea09-0398-42fc-ba11-45f2583520d3'];


        await this.load(NursingApplicationMainFormViewModel);
        this.AddHelpMenu();

        let date: Date = new Date();
        date = date.AddDays(this.DrugOrderQueryDayNumber);
        this.GetDrugOrderIntroductionsWithDate(date);


        let stockSitesName: string = (await SystemParameterService.GetParameterValue("STOCKSITESNAME", "GAZİLER"));
        if (stockSitesName === "GAZİLER") {
            this.stockSiteNgIf = true;
        }
        else {
            this.stockSiteNgIf = false;
            this.stateAction.push(
            {
                Caption: "Acil Order",
                ActionName: "OpenEmergencyOrderClick"
            });
        }
    }

    private async cmdImage_Click(): Promise<void> {
        let that = this;
        let fullApiUrl: string = "api/ProcedureRequestService/GetBloodRequestURL?EpisodeActionObjectID=" + that.nursingApplicationMainFormViewModel._NursingApplication.ObjectID.toString();
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                if (result == null) {
                    InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
                }
                else {
                    let win = window.open(result, '_blank');
                    win.focus();
                }
            })
            .catch(error => {
                console.log(error);
            });

    }


    protected async save() {

        let saveuserOption = await this.requestedProceduresFormInstance.saveProcedureTestFilterUserOption();
        let returnValue: number;
        //try {
        //    if (this.nursingApplicationMainFormViewModel.IsDischarged == true)
        //        throw new TTException(i18n("M22146", "Taburculuğu tamamlanmış ücretli hastalarda yeni işlem yapılamaz."));

        returnValue = await this.requestedProceduresFormInstance.fireRequestedProceduresActions(this.nursingApplicationMainFormViewModel._NursingApplication);
        if (returnValue == 0 || returnValue == 1) {
            await super.save();
        }
        else if (returnValue == 2) {
            throw new TTException(i18n("M22395", "SUT Kural ihlali oldu ve işlemden vazgeçildi!"));

            //}}        
            //catch (error) {
            //    ServiceLocator.MessageService.showError(error);
        }

    }

    protected async PreScript(): Promise<void> {
        super.PreScript();
        // servera taşındı
        this.DropStateButton(NursingApplication.NursingApplicationStates.Cancelled);
        this.DropStateButton(NursingApplication.NursingApplicationStates.PreDischarged);
        if (this.nursingApplicationMainFormViewModel._NursingApplication.EmergencyIntervention == null)
            this.DropStateButton(NursingApplication.NursingApplicationStates.Discharged);

        if (this.nursingApplicationMainFormViewModel._NursingApplication.CurrentStateDefID == NursingApplication.NursingApplicationStates.Discharged)
            this.DropStateButton(NursingApplication.NursingApplicationStates.Cancelled);

        if (this._NursingApplication.EmergencyIntervention != null) {
            this.hasEmergencySpecialityBasedObject = false;
            this.hasEmergencyIntervention = true;
        }
    }
    public onBedChanged(event): void {
        if (event != null) {
            if (this._NursingApplication != null &&
                this._NursingApplication.InPatientTreatmentClinicApp != null &&
                this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null && this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed != event) {
                this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed = event;
            }
        }
    }

    public onHospitalInpatientDateChanged(event): void {
        if (event != null) {
            if (this._NursingApplication != null &&
                this._NursingApplication.InPatientTreatmentClinicApp != null && this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null && this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HospitalInPatientDate != event) {
                this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HospitalInPatientDate = event;
            }
        }
    }

    public onResponsibleDoctorChanged(event): void {
        if (event != null) {
            if (this._NursingApplication != null &&
                this._NursingApplication.InPatientTreatmentClinicApp != null && this._NursingApplication.InPatientTreatmentClinicApp.ProcedureDoctor != event) {
                this._NursingApplication.InPatientTreatmentClinicApp.ProcedureDoctor = event;
            }
        }
    }

    public onResponsibleNurseChanged(event): void {
        if (event != null) {
            if (this._NursingApplication != null &&
                this._NursingApplication.InPatientTreatmentClinicApp != null && this._NursingApplication.InPatientTreatmentClinicApp.ResponsibleNurse != event) {
                this._NursingApplication.InPatientTreatmentClinicApp.ResponsibleNurse = event;
            }
        }
    }

    public onRoomChanged(event): void {
        if (event != null) {
            if (this._NursingApplication != null &&
                this._NursingApplication.InPatientTreatmentClinicApp != null &&
                this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null && this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room != event) {
                this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room = event;
            }
        }
    }

    public onRoomGroupChanged(event): void {
        if (event != null) {
            if (this._NursingApplication != null &&
                this._NursingApplication.InPatientTreatmentClinicApp != null &&
                this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null && this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup != event) {
                this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup = event;
            }
        }
    }
    public onInpatientObservationEndTimeChanged(event): void {
        if (event != null) {
            if (this._NursingApplication != null &&
                this._NursingApplication.EmergencyIntervention != null && this._NursingApplication.EmergencyIntervention.DischargeTime != event) {
                this._NursingApplication.EmergencyIntervention.DischargeTime = event;
            }
        }
    }

    public onInpatientObservationTimeChanged(event): void {
        if (event != null) {
            if (this._NursingApplication != null &&
                this._NursingApplication.EmergencyIntervention != null && this._NursingApplication.EmergencyIntervention.InpatientObservationTime != event) {
                this._NursingApplication.EmergencyIntervention.InpatientObservationTime = event;
            }
        }
    }
    protected redirectProperties(): void {
        redirectProperty(this.InpatientObservationTime, "Value", this.__ttObject, "EmergencyIntervention.InpatientObservationTime");
        redirectProperty(this.InpatientObservationEndTime, "Value", this.__ttObject, "EmergencyIntervention.DischargeTime");
    }

    public initFormControls(): void {
        this.Bed = new TTVisual.TTObjectListBox();
        this.Bed.LinkedControlName = "Room";
        this.Bed.ReadOnly = true;
        this.Bed.ListFilterExpression = "UsedByBedProcedure is Null";
        this.Bed.ListDefName = "BedListDefinition";
        this.Bed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Bed.Name = "Bed";
        this.Bed.TabIndex = 9;
        this.Bed.Enabled = false;

        this.labelResponsibleNurse = new TTVisual.TTLabel();
        this.labelResponsibleNurse.Text = i18n("M22151", "Sorumlu Hemşire");
        this.labelResponsibleNurse.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelResponsibleNurse.ForeColor = "#000000";
        this.labelResponsibleNurse.Name = "labelResponsibleNurse";
        this.labelResponsibleNurse.TabIndex = 183;

        this.labelHospitalInpatientDate = new TTVisual.TTLabel();
        this.labelHospitalInpatientDate.Text = i18n("M15402", "XXXXXX Yatış Tarihi");
        this.labelHospitalInpatientDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelHospitalInpatientDate.ForeColor = "#000000";
        this.labelHospitalInpatientDate.Name = "labelHospitalInpatientDate";
        this.labelHospitalInpatientDate.TabIndex = 189;

        this.Room = new TTVisual.TTObjectListBox();
        this.Room.LinkedControlName = "RoomGroup";
        this.Room.ReadOnly = true;
        this.Room.ListDefName = "RoomListDefinition";
        this.Room.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Room.Name = "Room";
        this.Room.TabIndex = 8;
        this.Room.Enabled = false;

        this.RoomGroup = new TTVisual.TTObjectListBox();
        this.RoomGroup.ReadOnly = true;
        this.RoomGroup.ListDefName = "RoomGroupListDefinition";
        this.RoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RoomGroup.Name = "RoomGroup";
        this.RoomGroup.TabIndex = 7;
        this.RoomGroup.Enabled = false;

        this.labelRoomGroup = new TTVisual.TTLabel();
        this.labelRoomGroup.Text = i18n("M19605", "Oda Grubu");
        this.labelRoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoomGroup.ForeColor = "#000000";
        this.labelRoomGroup.Name = "labelRoomGroup";
        this.labelRoomGroup.TabIndex = 187;

        this.labelBed = new TTVisual.TTLabel();
        this.labelBed.Text = i18n("M24353", "Yatak");
        this.labelBed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBed.ForeColor = "#000000";
        this.labelBed.Name = "labelBed";
        this.labelBed.TabIndex = 179;

        this.ResponsibleNurse = new TTVisual.TTObjectListBox();
        this.ResponsibleNurse.ReadOnly = true;
        this.ResponsibleNurse.ListDefName = "ClinicNurseListDefinition";
        this.ResponsibleNurse.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResponsibleNurse.Name = "ResponsibleNurse";
        this.ResponsibleNurse.TabIndex = 11;

        this.labelResponsibleDoctor = new TTVisual.TTLabel();
        this.labelResponsibleDoctor.Text = i18n("M22158", "Sorumlu Tabip");
        this.labelResponsibleDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelResponsibleDoctor.ForeColor = "#000000";
        this.labelResponsibleDoctor.Name = "labelResponsibleDoctor";
        this.labelResponsibleDoctor.TabIndex = 181;

        this.ResponsibleDoctor = new TTVisual.TTObjectListBox();
        this.ResponsibleDoctor.ReadOnly = true;
        this.ResponsibleDoctor.ListDefName = "ClinicDoctorListDefinition";
        this.ResponsibleDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResponsibleDoctor.Name = "ResponsibleDoctor";
        this.ResponsibleDoctor.TabIndex = 10;

        this.HospitalInpatientDate = new TTVisual.TTDateTimePicker();
        this.HospitalInpatientDate.BackColor = "#F0F0F0";
        this.HospitalInpatientDate.CustomFormat = "";
        this.HospitalInpatientDate.Format = DateTimePickerFormat.Long;
        this.HospitalInpatientDate.Enabled = false;
        this.HospitalInpatientDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.HospitalInpatientDate.Name = "HospitalInpatientDate";
        this.HospitalInpatientDate.TabIndex = 5;

        this.labelRoom = new TTVisual.TTLabel();
        this.labelRoom.Text = i18n("M19602", "Oda");
        this.labelRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoom.ForeColor = "#000000";
        this.labelRoom.Name = "labelRoom";
        this.labelRoom.TabIndex = 185;

        this.GridDiagnosis = new TTVisual.TTGrid();
        this.GridDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridDiagnosis.Name = "GridDiagnosis";
        this.GridDiagnosis.TabIndex = 4;

        this.SecDiagnose = new TTVisual.TTListBoxColumn();
        this.SecDiagnose.AllowMultiSelect = true;
        this.SecDiagnose.ListDefName = "DiagnosisListDefinition";
        this.SecDiagnose.DataMember = 'Diagnose';
        this.SecDiagnose.DisplayIndex = 0;
        this.SecDiagnose.HeaderText = i18n("M17498", "Kesin Tanı");
        this.SecDiagnose.Name = 'SecDiagnose';
        this.SecDiagnose.Width = 300;

        this.SecFreeDiagnosis = new TTVisual.TTTextBoxColumn();
        this.SecFreeDiagnosis.DataMember = 'FreeDiagnosis';
        this.SecFreeDiagnosis.DisplayIndex = 1;
        this.SecFreeDiagnosis.HeaderText = i18n("M22737", "Tanı Açıklaması");
        this.SecFreeDiagnosis.Name = 'SecFreeDiagnosis';
        this.SecFreeDiagnosis.Width = 200;

        this.SecIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.SecIsMainDiagnose.DataMember = 'IsMainDiagnose';
        this.SecIsMainDiagnose.DisplayIndex = 2;
        this.SecIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.SecIsMainDiagnose.Name = 'SecIsMainDiagnose';
        this.SecIsMainDiagnose.Width = 75;

        this.SecResponsibleUser = new TTVisual.TTListBoxColumn();
        this.SecResponsibleUser.ListDefName = 'UserListDefinition';
        this.SecResponsibleUser.DataMember = 'ResponsibleUser';
        this.SecResponsibleUser.DisplayIndex = 3;
        this.SecResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.SecResponsibleUser.Name = 'SecResponsibleUser';
        this.SecResponsibleUser.ReadOnly = true;
        this.SecResponsibleUser.Width = 200;

        this.SecDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.SecDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.SecDiagnoseDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.SecDiagnoseDate.DataMember = 'DiagnoseDate';
        this.SecDiagnoseDate.DisplayIndex = 4;
        this.SecDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.SecDiagnoseDate.Name = 'SecDiagnoseDate';
        this.SecDiagnoseDate.ReadOnly = true;
        this.SecDiagnoseDate.Width = 170;


        this.InpatientObservationEndTime = new TTVisual.TTDateTimePicker();
        this.InpatientObservationEndTime.Format = DateTimePickerFormat.Long;
        this.InpatientObservationEndTime.Name = 'InpatientObservationEndTime';
        this.InpatientObservationEndTime.TabIndex = 17477;

        this.ttlabel21 = new TTVisual.TTLabel();
        this.ttlabel21.Text = i18n("M19368", "Müşahede Bitiş");
        this.ttlabel21.Name = 'ttlabel21';
        this.ttlabel21.TabIndex = 17476;

        this.InpatientObservationTime = new TTVisual.TTDateTimePicker();
        this.InpatientObservationTime.Format = DateTimePickerFormat.Long;
        this.InpatientObservationTime.Name = 'InpatientObservationTime';
        this.InpatientObservationTime.TabIndex = 17475;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = 'Müşahedeye Alınış';
        this.ttlabel10.Name = 'ttlabel10';
        this.ttlabel10.TabIndex = 17474;

        this.GridDiagnosisColumns = [this.SecDiagnose, this.SecFreeDiagnosis, this.SecIsMainDiagnose, this.SecResponsibleUser, this.SecDiagnoseDate];
        this.Controls = [this.Bed, this.labelResponsibleNurse, this.labelHospitalInpatientDate, this.Room, this.RoomGroup, this.labelRoomGroup, this.labelBed, this.ResponsibleNurse, this.labelResponsibleDoctor, this.ResponsibleDoctor, this.HospitalInpatientDate, this.labelRoom, this.GridDiagnosis, this.SecDiagnose, this.SecFreeDiagnosis, this.SecIsMainDiagnose, this.SecResponsibleUser, this.SecDiagnoseDate];

    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        this.IsMessageShownOnLoad = true;
        await super.AfterContextSavedScript(transDef);

        await this.load(NursingApplicationMainFormViewModel);
    }


    public getAppo(_startDate, _endDate, scroll) {
        let that = this;
        if (this.nursingApplicationMainFormViewModel.ShowNewOrderTab == false) {
            that.httpService.get<OrderScheduleDetail[]>('/api/NursingApplicationService/GetNursingOrdersByDate?ObjectID=' + this.nursingApplicationMainFormViewModel._NursingApplication.ObjectID + '&startDate=' + _startDate + '&endDate=' + _endDate)
                .then(response => {
                    that.appointmentsData = plainToClass(OrderScheduleDetail, response);
                    that.GlobalappointmentsData = plainToClass(OrderScheduleDetail, response);
                    if (scroll)
                        that._noddetailscheduler.instance.scrollToTime(that.currentDate.getHours(), that.currentDate.getMinutes(), that._scheduleWorkListDate);
                    that.repaintNodDetailScheduler();
                    this.filterGlobalAppointment();
                })
                .catch(error => {
                    this.messageService.showError(error);

                });

        }

    }


    GlobalappointmentsData: any = new Array<any>();
    showCancelled: boolean = true;
    chkChanged(data) {
        if (data.value == true) {
            this.appointmentsData = this.GlobalappointmentsData;
        }
        else {
            let newArray: Array<any> = new Array<any>();
            for (let i = 0; i < this.appointmentsData.length; i++) {
                if (this.appointmentsData[i].statusName != i18n("M23755", "Uygulama İptal Edildi!") && this.appointmentsData[i].statusName != i18n("M13353", "Durduruldu") && this.appointmentsData[i].statusName != i18n("M16526", "İptal "))
                    newArray.push(this.appointmentsData[i]);
            }
            this.appointmentsData = newArray;
        }
    }
    filterAppointmentData: any;
    filterTypeExp(data: any) {
        this.filterAppointmentData = data;
        this.filterGlobalAppointment();
    }

    filterAppointmentStatusData: any;
    filterStatusExp(data: any) {
        this.filterAppointmentStatusData = data;
        this.filterGlobalAppointment();
    }

    filterGlobalAppointment() {
        this.appointmentsData = this.GlobalappointmentsData;
        if (this.filterAppointmentData != undefined || this.filterAppointmentData != null) {
            if (this.filterAppointmentData.itemData.TypeID === -1) {
                this.appointmentsData = this.GlobalappointmentsData;
            } else if (this.filterAppointmentData.itemData.TypeID === 0) {
                let newArray: Array<any> = new Array<any>();
                for (let i = 0; i < this.appointmentsData.length; i++) {
                    if (this.appointmentsData[i].typeId == OrderTypeEnum.DrugOrder)
                        newArray.push(this.appointmentsData[i]);
                }
                this.appointmentsData = newArray;
            }
            else if (this.filterAppointmentData.itemData.TypeID === 1) {
                let newArray: Array<any> = new Array<any>();
                for (let i = 0; i < this.appointmentsData.length; i++) {
                    if (this.appointmentsData[i].typeId == OrderTypeEnum.NursingOrder)
                        newArray.push(this.appointmentsData[i]);
                }
                this.appointmentsData = newArray;
            }
        }
        if (this.filterAppointmentStatusData != undefined || this.filterAppointmentStatusData != null) {
            if (this.filterAppointmentStatusData.itemData.TypeID === 0) {
                if (this.filterAppointmentStatusData.itemData.StateID === 'f1b24e44-ecb3-4b44-9b23-1d77e9901721') {
                    let newArray: Array<any> = new Array<any>();
                    for (let i = 0; i < this.appointmentsData.length; i++) {
                        if (this.appointmentsData[i].StateID == 'f1b24e44-ecb3-4b44-9b23-1d77e9901721')
                            newArray.push(this.appointmentsData[i]);
                    }
                    this.appointmentsData = newArray;
                }
                else if (this.filterAppointmentStatusData.itemData.StateID === '14ea4626-5b27-4663-82f9-64968cb4eb63') {
                    let newArray: Array<any> = new Array<any>();
                    for (let i = 0; i < this.appointmentsData.length; i++) {
                        if (this.appointmentsData[i].StateID == '14ea4626-5b27-4663-82f9-64968cb4eb63')
                            newArray.push(this.appointmentsData[i]);
                    }
                    this.appointmentsData = newArray;
                }
                else if (this.filterAppointmentStatusData.itemData.StateID === 'd39a37a6-610e-4143-aca2-691ce5818915') {
                    let newArray: Array<any> = new Array<any>();
                    for (let i = 0; i < this.appointmentsData.length; i++) {
                        if (this.appointmentsData[i].StateID == 'd39a37a6-610e-4143-aca2-691ce5818915')
                            newArray.push(this.appointmentsData[i]);
                    }
                    this.appointmentsData = newArray;
                }
                else if (this.filterAppointmentStatusData.itemData.StateID === 'add6e452-c007-4849-b477-17d30400abe8') {
                    let newArray: Array<any> = new Array<any>();
                    for (let i = 0; i < this.appointmentsData.length; i++) {
                        if (this.appointmentsData[i].StateID == 'add6e452-c007-4849-b477-17d30400abe8')
                            newArray.push(this.appointmentsData[i]);
                    }
                    this.appointmentsData = newArray;
                }
            }
        }
    }



    public getResourceList() {
        //let resources: any[] = [
        //    {
        //        text: "Samantha Bright",
        //        id: OrderTypeEnum.DietOrder,
        //        color: "#cb6bb2"
        //    }, {
        //        text: "John Heart",
        //        id: OrderTypeEnum.DrugOrder,
        //        color: "#56ca85"
        //    }, {
        //        text: "Todd Hoffman",
        //        id: OrderTypeEnum.NursingOrder,
        //        color: "#1e90ff"
        //    }
        //];

        let resources: any[] = [
            {
                text: 'Cancelled',
                id: NursingOrderDetail.NursingOrderDetailStates.Cancelled.toString(),
                color: '#F37171'//kırmızı
            }, {
                text: 'Completed',
                id: NursingOrderDetail.NursingOrderDetailStates.Completed.toString(),
                color: '#56CA85'//yeşil
            }, {
                text: i18n("M19691", "Onayla"),
                id: NursingOrderDetail.NursingOrderDetailStates.Execution.toString(),
                color: '#1E90FF'//mavi
            }, {
                text: i18n("M23791", "Uygulandı"), //İlaç
                id: DrugOrderDetail.DrugOrderDetailStates.Apply,
                color: '#56CA85'//yeşil
            }, {
                text: i18n("M23755", "Uygulama İptal Edildi!"), //İlaç
                id: DrugOrderDetail.DrugOrderDetailStates.Cancel,
                color: '#F37171'//yeşil
            }, {
                text: i18n("M15127", "Hasta / Hasta Yakınına teslim edildi."), //İlaç
                id: DrugOrderDetail.DrugOrderDetailStates.PatientDelivery,
                color: '#56CA85'//yeşil
            }
        ];
        this.nursingOrderScheduleResource = resources;
    }

    onNursingOrderTabClick(e: any) {
        //this._noddetailscheduler.width = "100%";
        this._scheduleWorkListDate = this.currentDate;
        this.repaintNodDetailScheduler();

    }

    isConsultation: boolean = false;
    onNursingProcedureTabClick(e: any) {
        let that = this;
        setTimeout(function () {
            that.requestedProceduresFormInstance.repaintHizmetGrid();
        }, 100);
    }

    onConsultationTabClick(e: any) {
        this.isConsultation = true;
    }


    onScheduleOptionChange(e: any) {
        let _startDate: Date;
        let _endDate: Date;
        let that = this;

        if (e.name == 'currentView') {
            that._scheduleCurrentView = e.value;
            _startDate = that._scheduleWorkListDate;

            if (e.previousValue == "agenda")
                _endDate = _startDate.AddDays(1);
            if (e.previousValue == "day")
                _endDate = _startDate.AddDays(7);
        }
        else if (e.name == 'currentDate') {
            that._scheduleWorkListDate = e.value;
            _startDate = e.value;

            //if (this._scheduleCurrentView == "agenda")
            //{
            //    if (e.previousValue < e.value)//bi sonraki haftaya bvakacak demek
            //        _endDate = _startDate.AddDays(7);
            //    else
            //    {
            //        _endDate = e.previousValue;
            //    }
            //}
            //if (this._scheduleCurrentView == "day")
            //{
            //    if (e.previousValue < e.value)// bi sonraki gün
            //    {
            //        _endDate = _startDate.AddDays(1);
            //        //_startDate = e.value;
            //    }
            //    else {
            //        _endDate = e.previousValue;
            //    }
            //}

            if (e.previousValue.toDateString() != e.value.toDateString()) {//iki kere giriyor buraya
                if (e.previousValue < e.value)// ileri tuşuna basıldı ise
                {
                    if (that._scheduleCurrentView == 'agenda')
                        _endDate = _startDate.AddDays(7);
                    else
                        _endDate = _startDate.AddDays(1);
                }
                else
                    _endDate = e.previousValue;
            }

        }

        if (_startDate != undefined && _endDate != undefined) {
            //event içinde yine veriyi değiştirdiğimiz için saçmalayabiliyor, o yüzden geçiktirdik
            setTimeout(function () {
                that.getAppo(_startDate.toDateString(), _endDate.toDateString(), true);
            }, 500);
        }
    }

    async onNODScheduleDblClick(e: any) {
        e.cancel = true;
        let _comp = e;
        if (this._scheduleCurrentView == "day")//agenda görünümde yeni ekleyemediği için ve haftayı gösterebilmek için ilk günü değiştirmemek gerek
            this._scheduleWorkListDate = e.appointmentData.startDate;
        if (e.appointmentData.typeId == OrderTypeEnum.NursingOrder)
            this.openNursingOrderDetailForm(e.appointmentData.id);
        else if (e.appointmentData.typeId == OrderTypeEnum.DrugOrder)
            this.openDrugOrderDetail(e.appointmentData.id);


        setTimeout(function () {
            _comp.component.hideAppointmentTooltip();
        }, 500);
        // this.componentInfo = await this.systemApiService.open(e.appointmentData.id, "NURSINGORDERDETAIL", 'ffadb707-6870-4a6e-baaa-d43480f4c52a');


    }

    editDetails(detail: any) {
        let orderDetail = detail.appointmentData;
        if (this._scheduleCurrentView == "day")//agenda görünümde yeni ekleyemediği için ve haftayı gösterebilmek için ilk günü değiştirmemek gerek
            this._scheduleWorkListDate = orderDetail.startDate;
        if (orderDetail.typeId == OrderTypeEnum.NursingOrder)
            this.openNursingOrderDetailForm(orderDetail.id);
        else if (orderDetail.typeId == OrderTypeEnum.DrugOrder)
            this.openDrugOrderDetail(orderDetail.id);
        //this.openDrugOrderDetail(orderDetail.id);

    }

    private openNursingOrderDetailForm(_id: string) {
        let that = this;
        that.createNursingOrderDetailForm(_id).then(result => {
            let modalActionResult = result as ModalActionResult;
            if (modalActionResult.Result == DialogResult.OK) {
                this.RefreshNewOrderDetail();
                if (this.nursingApplicationMainFormViewModel.ShowNewOrderTab == false) {
                    that.getAppo(that._scheduleWorkListDate.toDateString(), that.arrangeScheduleEndDate(), false);
                }
            }
        });

    }



    async DrugReturnAndDeliveryClick() {

        DrugReturnActionService.GetDrugReturnAndDeliveryDetail(this._EpisodeAction.SubEpisode.toString()).then(result => {

            let drugReturnAndDeliveryDetail: GetDrugReturnAndDeliveryDetails = result;
            drugReturnAndDeliveryDetail.MasterResource = Guid.Empty;
            drugReturnAndDeliveryDetail.SecondaryMasterResource = Guid.Empty;
            if (this._NursingApplication.MasterResource != null)
                drugReturnAndDeliveryDetail.MasterResource = new Guid(this._NursingApplication.MasterResource.toString());
            if (this._NursingApplication.SecondaryMasterResource != null)
                drugReturnAndDeliveryDetail.SecondaryMasterResource = new Guid(this._NursingApplication.SecondaryMasterResource.toString());
            drugReturnAndDeliveryDetail.Episode = this._NursingApplication.Episode.ObjectID;
            drugReturnAndDeliveryDetail.SubEpisode = new Guid(this._NursingApplication.SubEpisode.toString());

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'DrugReturnAndDeliveryComponent';
                componentInfo.ModuleName = 'LogisticFormsModule';
                componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                componentInfo.InputParam = new DynamicComponentInputParam(drugReturnAndDeliveryDetail, null);

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = i18n("M16330", "İlaç Teslim/İade İşlemi");
                modalInfo.Width = 1000;
                modalInfo.Height = 600;

                let result2 = this.modalService.create(componentInfo, modalInfo);
                result2.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        });
    }



    ReturnDrugClick() {
        this.objectContextService.getNewObject<DrugReturnAction>(DrugReturnAction.ObjectDefID).then(result => {

            let drugReturnAction: DrugReturnAction = result;
            drugReturnAction.MasterResource = this._NursingApplication.MasterResource;
            drugReturnAction.SecondaryMasterResource = this._NursingApplication.SecondaryMasterResource;
            drugReturnAction.Episode = this._NursingApplication.Episode;
            drugReturnAction.SubEpisode = this._NursingApplication.SubEpisode;
            drugReturnAction.DrugReturnActionDetails = new Array<DrugReturnActionDetail>();

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'DrugReturnActionNewForm';
                componentInfo.ModuleName = 'EczaneyeIlacIadeModule';
                componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Eczaneye_Ilac_Iade_Modulu/EczaneyeIlacIadeModule';
                componentInfo.InputParam = new DynamicComponentInputParam(drugReturnAction, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = i18n("M16330", "İlaç İade");
                modalInfo.Width = 700;
                modalInfo.Height = 600;

                let result2 = this.modalService.create(componentInfo, modalInfo);
                result2.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        });
    }

    DrugDeliverClick() {
        this.objectContextService.getNewObject<DrugDeliveryAction>(DrugDeliveryAction.ObjectDefID).then(result => {

            let drugDeliveryAction: DrugDeliveryAction = result;
            drugDeliveryAction.MasterResource = this._NursingApplication.MasterResource;
            drugDeliveryAction.SecondaryMasterResource = this._NursingApplication.SecondaryMasterResource;
            drugDeliveryAction.Episode = this._NursingApplication.Episode;
            drugDeliveryAction.SubEpisode = this._NursingApplication.SubEpisode;
            drugDeliveryAction.DrugDeliveryActionDetails = new Array<DrugDeliveryActionDetail>();

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'DrugDeliveryActionNewForm';
                componentInfo.ModuleName = 'IlacTeslimIslemiModule';
                componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Teslim_Islemi_Modulu/IlacTeslimIslemiModule';
                componentInfo.InputParam = new DynamicComponentInputParam(drugDeliveryAction, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = i18n("M16368", "İlaç Teslim");
                modalInfo.Width = 700;
                modalInfo.Height = 600;

                let result2 = this.modalService.create(componentInfo, modalInfo);
                result2.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        });
    }

    PatientOwnDrugClick() {
        this.objectContextService.getNewObject<PatientOwnDrugEntry>(PatientOwnDrugEntry.ObjectDefID).then(result => {

            let patientOwnDrugEntry: PatientOwnDrugEntry = result;
            patientOwnDrugEntry.MasterResource = this._NursingApplication.MasterResource;
            patientOwnDrugEntry.SecondaryMasterResource = this._NursingApplication.SecondaryMasterResource;
            patientOwnDrugEntry.Episode = this._NursingApplication.Episode;
            patientOwnDrugEntry.SubEpisode = this._NursingApplication.SubEpisode;
            patientOwnDrugEntry.PatientOwnDrugEntryDetails = new Array<PatientOwnDrugEntryDetail>();
            patientOwnDrugEntry.PatientLastUseDrugs = new Array<PatientLastUseDrug>();

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'PatientOwnDrugEntryForm';
                componentInfo.ModuleName = 'HastaninIlaclariGirisModule';
                componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Hastanin_Ilaclari_Giris_Modulu/HastaninIlaclariGirisModule';
                componentInfo.InputParam = new DynamicComponentInputParam(patientOwnDrugEntry, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = i18n("M15459", "Hastanın İlaçları Giriş");
                modalInfo.Width = 900;
                modalInfo.Height = 700;
                //modalInfo.fullScreen = true;

                let result2 = this.modalService.create(componentInfo, modalInfo);
                result2.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        });

    }

    PatientOwnDrugReturnClick() {
        this.objectContextService.getNewObject<PatientOwnDrugReturn>(PatientOwnDrugReturn.ObjectDefID).then(result => {

            let patientOwnDrugReturn: PatientOwnDrugReturn = result;
            patientOwnDrugReturn.MasterResource = this._NursingApplication.MasterResource;
            patientOwnDrugReturn.SecondaryMasterResource = this._NursingApplication.SecondaryMasterResource;
            patientOwnDrugReturn.Episode = this._NursingApplication.Episode;
            patientOwnDrugReturn.SubEpisode = this._NursingApplication.SubEpisode;
            patientOwnDrugReturn.PatientOwnDrugReturnDetails = new Array<PatientOwnDrugReturnDetail>();

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'PatientOwnDrugReturnForm';
                componentInfo.ModuleName = 'HastaninIlaclariIadeModule';
                componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Hastanin_Ilaclari_Iade_Modulu/HastaninIlaclariIadeModule';
                componentInfo.InputParam = new DynamicComponentInputParam(patientOwnDrugReturn, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = i18n("M15459", "Hastanın İlaçları İade");
                modalInfo.Width = 700;
                modalInfo.Height = 600;

                let result2 = this.modalService.create(componentInfo, modalInfo);
                result2.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        });

    }

    async getUsercontrolTool() {
        let that = this;
        let fullApiUrl = 'api/NursingWorkListService/Get_UsercontrolTool';
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        that.http.post(fullApiUrl, options)
            .then((res: NursingApplicationMainFormViewModel) => {
                that._ViewModel.NursingApplicationMainFormViewModel = res;
                if (that._ViewModel.NursingApplicationMainFormViewModel.toolOption) {
                    this.DailyDrugClick();
                } else {
                    ServiceLocator.MessageService.showError("GİÇ PARAMETRESİ KAPALI");
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    DailyDrugClick() {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DailyDrugScheduleNewForm';
            componentInfo.ModuleName = 'GunlukIlacCizelgesiModule';
            componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Gunluk_Ilac_Cizelgesi_Modulu/GunlukIlacCizelgesiModule';
            componentInfo.InputParam = new DynamicComponentInputParam(this._NursingApplication, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16335", "İlaç İstek");
            modalInfo.Width = 1200;
            modalInfo.Height = 750;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                this.getAppo(this._scheduleWorkListDate.toDateString(), this.arrangeScheduleEndDate(), true);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private createNursingOrderDetailForm(data: string): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'NursingOrderDetailForm';
            componentInfo.ModuleName = 'HemsirelikIslemleriModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/HemsirelikIslemleriModule';
            componentInfo.InputParam = new DynamicComponentInputParam(<any>this._scheduleWorkListDate, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));
            componentInfo.objectID = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M15638", "Hemşirelik Uygulamaları Ekranı");
            modalInfo.Width = 800;
            modalInfo.Height = 350;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private openDrugOrderDetail(data: string): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderDetailForm';
            componentInfo.ModuleName = 'TedaviIlacUgulamaModule';
            componentInfo.ModulePath = 'Modules/Saglik_Lojistik/Eczane_Modulleri/Tedavi_Ilac_Ugulama_Modulu/TedaviIlacUgulamaModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M23747", "Uygulama");
            modalInfo.Width = 800;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                this.RefreshNewOrderDetail();
                this.getAppo(this._scheduleWorkListDate.toDateString(), this.arrangeScheduleEndDate(), false);
            }).catch(err => {
                reject(err);
                this.RefreshNewOrderDetail();
                this.getAppo(this._scheduleWorkListDate.toDateString(), this.arrangeScheduleEndDate(), false);
            });
        });
    }

    protected arrangeScheduleEndDate(): string {
        let _date = "";

        if (this._scheduleCurrentView == "agenda")
            _date = this._scheduleWorkListDate.AddDays(7).toDateString();
        else
            _date = this._scheduleWorkListDate.AddDays(1).toDateString();

        return _date;
    }

    protected async ClientSidePreScript(): Promise<void> {
        //TODO ismail yeni direktif eklenince direktif change de de çağır
        super.ClientSidePreScript();

        if (this.nursingApplicationMainFormViewModel.HasFalling == true && this.nursingApplicationMainFormViewModel.showFallingRiskParameter) {
            this.ShowFallingRiskPopup = true;
            this.fallingRiskMessage = i18n("M30913", `1. Çevresel faktörleri kontrol ediniz.
                                       2. Hasta ve/ veya yakınlarına düşme riski eğitimi veriniz.
                                       3. Hemşire çağrı zili hastanın ulaşabileceği bir yerde bulundurunuz.
                                       4. Yatak kenarlıkları yukarıda tutunuz.Sedye, tekerlekli sandalye ve yatağın tekerlekleri kilitleyiniz.`);
        }
        else if (this.nursingApplicationMainFormViewModel.fallingWarningAge > -1 && this.nursingApplicationMainFormViewModel.showFallingRiskParameter) {
            this.ShowFallingAgeWarningPopup = true;
            if (this.nursingApplicationMainFormViewModel.fallingWarningAge > 65)
                this.fallingAgeWarningMessage = i18n("M15128", "Hasta 65 yaşının üstündedir. Lütfen Düşme Riski Değerlendirmesi Yapınız.");
            else if (this.nursingApplicationMainFormViewModel.fallingWarningAge < 7)
                this.fallingAgeWarningMessage = i18n("M15129", "Hasta 7 yaşın altındadır. Lütfen Düşme Riski Değerlendirmesi Yapınız.");
        }
        //TTVisual.InfoBox.Alert("Uyarı !", "Hastanın düşme riski mevcuttur. Çevresel faktörleri kontrol ediniz.Hasta ve/veya yakınlarına düşme riski eğitimi veriniz. Hemşire çağrı zili hastanın ulaşabileceği bir yerde bulundurunuz.Yatak kenarlıkları yukarıda tutunuz. Sedye, tekerlekli sandalye ve yatağın tekerlekleri kilitleyiniz.", MessageIconEnum.WarningMessage);
        if (this.nursingApplicationMainFormViewModel.HasVitalSignWarning)
            this._showVitalInfoPopUp = true;
        if (this.nursingApplicationMainFormViewModel.HasPainInfo)
            this.ShowPainInfoPopup = true;
        if (this.nursingApplicationMainFormViewModel.HasWoundInfo)
            this.ShowWoundInfoPopup = true;
        if (this.nursingApplicationMainFormViewModel.HasOutDatedForm)
            this.ShowOutDatedFormsPopup = true;
        if (this.nursingApplicationMainFormViewModel.HasOutDatedFallingRiskForm)
            this.ShowOutDatedFallingRiskPopUp = true;


        this.RefreshNewOrderDetail();
        this.getAppo(this.currentDate.toDateString(), this.currentDate.AddDays(1).toDateString(), true);
        this.patientOwnDrugEntryies = await DrugOrderIntroductionService.GetPatientOwnDrugEntry(this._NursingApplication.Episode);
        this.patientNewOwnDrugEntryies = await DrugOrderIntroductionService.GetNewPatientOwnDrugEntry(this._NursingApplication.Episode);

        let datePipe = new DatePipe("en-US");
        for (let i = 0; i < this.GlobalappointmentsData.length; i++) {
            if (this.GlobalappointmentsData[i].typeId.toString() == "0") {
                if (this.GlobalappointmentsData[i].isStoped === true) {
                    if (this.GlobalappointmentsData[i].statusName == i18n("M23755", "Uygulama İptal Edildi!") ||
                        this.GlobalappointmentsData[i].statusName == i18n("M13353", "Durduruldu") ||
                        this.GlobalappointmentsData[i].statusName == i18n("M16526", "İptal ")) {
                        this.ShowDrugFormsPopup = true;
                        let message: string = this.GlobalappointmentsData[i].text.toString();

                        this.fallingPatientDrugsWarningMessage += message.split("-", 1) + " isimli ilaçın " +
                            datePipe.transform(this.GlobalappointmentsData[i].periodStartTime, "dd.MM.yyyy").toString() + " tarihli " +
                            datePipe.transform(this.GlobalappointmentsData[i].periodStartTime, "HH:mm").toString() + " tedavisi durdurulmuştur.";

                    }
                }
            }
        }
        if (String.isNullOrEmpty(this.fallingPatientDrugsWarningMessage) === false) {
            this.fallingPatientDrugsWarningMessage += "Lütfen yukarıdaki ilaçların iade işlemlerini gerçekleştiriniz !";
        }


    }

    private repaintNodDetailScheduler() {
        let that = this;
        that._scheduleWidth = '99%';
        setTimeout(function () {
            if (that._noddetailscheduler != null) {
                that._noddetailscheduler.instance.repaint();
                that._noddetailscheduler.instance.scrollToTime(that.currentDate.getHours(), that.currentDate.getMinutes(), that._scheduleWorkListDate);
            }
        }, 500);
    }
    private showBarcodePrinter: boolean = false;
    OpenBarcodePrint() {
        this.showBarcodePrinter = true;
    }
    private async SendActionsForBarcodePrint() {

        let inputDvo = new GetBarcode();
        inputDvo.startDate = this.startDate;
        inputDvo.endDate = this.endDate;
        inputDvo.NursingApplicationObjectid = this._NursingApplication.ObjectID;
        try {
            let url: string = '/api/NursingApplicationService/GetBarcode';
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let result = await httpService.post<HimsDrugBarcodesContainer>(url, inputDvo);
            console.log(result);
            for (let barcodeInfo of result.DrugBarcodes) {
                this.barcodePrintService.printAllBarcode(barcodeInfo, "generateHimsDrugBarcode", "printHimsDrugBarcode");
            }
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }

    }
    private showStockAction(data: string): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DashboardActionComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

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


    public onAppointmentFormCreated(e: any) {

        e.cancel = true;
        setTimeout(function () {
            e.component.hideAppointmentPopup(); //popup kapat
        }, 300);

        if (e.appointmentData != null && e.appointmentData.typeId == null) {//uygula butonuda bunu açmaya başlamış
            let dischargeDate = this.currentDate;
            if (this._NursingApplication != null && this._NursingApplication.InPatientTreatmentClinicApp != null) {
                dischargeDate = plainToClass(Date, this.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate);
            }
            else if (this.nursingApplicationMainFormViewModel._NursingApplication.EmergencyIntervention != null)
                dischargeDate = plainToClass(Date, this.nursingApplicationMainFormViewModel._NursingApplication.EmergencyIntervention.DischargeTime);

            if (this.nursingApplicationMainFormViewModel._NursingApplication.CurrentStateDefID == NursingApplication.NursingApplicationStates.Discharged) {
                this.messageService.showInfo(i18n("M22566", "Taburcu Olan Hastalara Yeni Order Eklenemez."));
            }
            else if (this.nursingApplicationMainFormViewModel._NursingApplication.CurrentStateDefID == NursingApplication.NursingApplicationStates.PreDischarged && e.appointmentData.startDate > dischargeDate) {
                this.messageService.showInfo(i18n("M19985", "Ön Taburcusu Yapılmış Hastalara Taburcu Tarihinden Daha İleriye Order Eklenemez."));
            }
            else if (this.nursingApplicationMainFormViewModel.ReadOnly)
                return false;
            else {
                this._scheduleWorkListDate = e.appointmentData.startDate;
                this.openNursingOrderDetailForm(null);
            }
        }
    }

    openNewNODForm() {
        let dischargeDate = new Date(Date.now());
        if (this._NursingApplication != null && this._NursingApplication.InPatientTreatmentClinicApp != null) {
            dischargeDate = plainToClass(Date, this.nursingApplicationMainFormViewModel._NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate);
        }
        else if (this.nursingApplicationMainFormViewModel._NursingApplication.EmergencyIntervention != null)
            dischargeDate = plainToClass(Date, this.nursingApplicationMainFormViewModel._NursingApplication.EmergencyIntervention.DischargeTime);

        if (this.nursingApplicationMainFormViewModel._NursingApplication.CurrentStateDefID == NursingApplication.NursingApplicationStates.Discharged) {
            this.messageService.showInfo(i18n("M22566", "Taburcu Olan Hastalara Yeni Order Eklenemez."));
        }
        // else if (this.nursingApplicationMainFormViewModel._NursingApplication.CurrentStateDefID == NursingApplication.NursingApplicationStates.PreDischarged && e.appointmentData.startDate > dischargeDate) {
        //     this.messageService.showInfo(i18n("M19985", "Ön Taburcusu Yapılmış Hastalara Taburcu Tarihinden Daha İleriye Order Eklenemez."));
        // }
        else if (this.nursingApplicationMainFormViewModel.ReadOnly)
            return false;
        else {
            this._scheduleWorkListDate = null;
            this.openNursingOrderDetailForm(null);
        }
    }


    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let printEpicrisisForm = new DynamicSidebarMenuItem();
        printEpicrisisForm.key = 'epicrisisForm';
        printEpicrisisForm.icon = 'fa fa-file-text-o';
        printEpicrisisForm.label = 'Epikriz Formu';
        printEpicrisisForm.componentInstance = this.helpMenuService;
        printEpicrisisForm.clickFunction = this.helpMenuService.printEpicrisisForm;
        printEpicrisisForm.parameterFunctionInstance = this;
        printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        printEpicrisisForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', printEpicrisisForm);

        let patientDocumentUpload = new DynamicSidebarMenuItem();
        patientDocumentUpload.key = 'patientDocumentUpload';
        patientDocumentUpload.icon = 'ai ai-hasta-dokuman-ekle';
        patientDocumentUpload.label = i18n("M15178", "Hasta Dokümanı Ekle");
        patientDocumentUpload.componentInstance = this.helpMenuService;
        patientDocumentUpload.clickFunction = this.helpMenuService.patientDocumentUpload;
        patientDocumentUpload.parameterFunctionInstance = this;
        patientDocumentUpload.getParamsFunction = this.getClickFunctionParams;
        patientDocumentUpload.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', patientDocumentUpload);



        /* let emergencyOrderMenu = new DynamicSidebarMenuItem();
        emergencyOrderMenu.key = 'emergencyOrderMenu';
        emergencyOrderMenu.icon = 'fa fa-file-text-o';
        emergencyOrderMenu.label = "Acil Servis Direktif";
        emergencyOrderMenu.componentInstance = this.helpMenuService;
        emergencyOrderMenu.clickFunction = this.helpMenuService.onEmergencyOrderOpen;
        emergencyOrderMenu.parameterFunctionInstance = this;
        emergencyOrderMenu.getParamsFunction = this.getEmergencyClickFunctionParams;
        emergencyOrderMenu.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', emergencyOrderMenu); */




        let inpatientTreatmentClinicApp = new DynamicSidebarMenuItem();
        inpatientTreatmentClinicApp.key = 'inpatientTreatmentClinicApp';
        inpatientTreatmentClinicApp.label = 'Yatan Hasta Klinik İşlemleri';
        inpatientTreatmentClinicApp.icon = 'ai ai-yatan-hasta-klinik';
        inpatientTreatmentClinicApp.componentInstance = this.helpMenuService;
        inpatientTreatmentClinicApp.clickFunction = this.helpMenuService.openInpatientTreatmentClinicApp;
        inpatientTreatmentClinicApp.parameterFunctionInstance = this;
        inpatientTreatmentClinicApp.getParamsFunction = this.getClickFunctionParams;
        inpatientTreatmentClinicApp.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', inpatientTreatmentClinicApp);

        let printInpatientTreatmentBarcode = new DynamicSidebarMenuItem();
        printInpatientTreatmentBarcode.key = 'printInpatientTreatmentBarcode';
        printInpatientTreatmentBarcode.label = 'Yatan Hasta Barkodu Bas';
        printInpatientTreatmentBarcode.icon = 'ai ai-barkod-bas';
        printInpatientTreatmentBarcode.componentInstance = this.helpMenuService;
        printInpatientTreatmentBarcode.clickFunction = this.helpMenuService.printInpatientTreatmentBarcode;
        printInpatientTreatmentBarcode.parameterFunctionInstance = this;
        printInpatientTreatmentBarcode.getParamsFunction = this.getClickFunctionParams;
        printInpatientTreatmentBarcode.ParentInstance = this;
        this.sideBarMenuService.addMenu('Barkod', printInpatientTreatmentBarcode);

        let printInpatientBarcode = new DynamicSidebarMenuItem();
        printInpatientBarcode.key = 'printInpatientBarcode';
        printInpatientBarcode.label = 'Hasta Bilekliği Bas';
        printInpatientBarcode.icon = 'ai ai-barkod-bas';
        printInpatientBarcode.componentInstance = this.helpMenuService;
        printInpatientBarcode.clickFunction = this.helpMenuService.printInPatientWristBarcode;
        printInpatientBarcode.parameterFunctionInstance = this;
        printInpatientBarcode.getParamsFunction = this.getClickFunctionParams;
        printInpatientBarcode.ParentInstance = this;
        this.sideBarMenuService.addMenu('Barkod', printInpatientBarcode);

        let printSerumBarcode = new DynamicSidebarMenuItem();
        printSerumBarcode.key = 'printSerumBarcode';
        printSerumBarcode.label = 'Serum Etiketi Bas';
        printSerumBarcode.icon = 'ai ai-barkod-bas';
        printSerumBarcode.componentInstance = this;
        printSerumBarcode.clickFunction = this.printSerumBarcode;
        printSerumBarcode.parameterFunctionInstance = this;
        printSerumBarcode.getParamsFunction = this.getClickFunctionParams;
        printSerumBarcode.ParentInstance = this;
        this.sideBarMenuService.addMenu('Barkod', printSerumBarcode);

        let dentistAdmission = new DynamicSidebarMenuItem();
        dentistAdmission.key = 'dentistAdmission';
        dentistAdmission.label = 'Diş Kabulü';
        dentistAdmission.icon = 'ai ai-dis-kabul-al';
        dentistAdmission.componentInstance = this;
        dentistAdmission.clickFunction = this.getDentistResource;
        this.sideBarMenuService.addMenu('YardimciMenu', dentistAdmission);

        let nursingNoteReport = new DynamicSidebarMenuItem();
        nursingNoteReport.key = 'nursingNoteReport';
        nursingNoteReport.icon = 'fa fa-file-text-o';
        nursingNoteReport.label = 'Hemşire Notu Raporu';
        nursingNoteReport.componentInstance = this;
        nursingNoteReport.clickFunction = this.openNursingNoteReportDiag;
        this.sideBarMenuService.addMenu('YardimciMenu', nursingNoteReport);

        let printInpatientAdmissionInfoByTreatmentClinicReport = new DynamicSidebarMenuItem();
        printInpatientAdmissionInfoByTreatmentClinicReport.key = 'printInpatientAdmissionInfoByTreatmentClinicReport';
        printInpatientAdmissionInfoByTreatmentClinicReport.label = i18n("M15342", "Hasta Yatış Formu");
        printInpatientAdmissionInfoByTreatmentClinicReport.icon = 'ai ai-hasta-yatis-formu';
        printInpatientAdmissionInfoByTreatmentClinicReport.componentInstance = this.helpMenuService;
        printInpatientAdmissionInfoByTreatmentClinicReport.clickFunction = this.helpMenuService.printInpatientAdmissionInfoByTreatmentClinicReport;
        printInpatientAdmissionInfoByTreatmentClinicReport.parameterFunctionInstance = this;
        printInpatientAdmissionInfoByTreatmentClinicReport.getParamsFunction = this.getClickFunctionParams;
        printInpatientAdmissionInfoByTreatmentClinicReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', printInpatientAdmissionInfoByTreatmentClinicReport);

        if (this.nursingApplicationMainFormViewModel.hasOrthesisRequestRole == true) {
            let ortezIstek = new DynamicSidebarMenuItem();
            ortezIstek.key = 'ortezIstek';
            ortezIstek.label = 'Ortez - Protez İstek';
            ortezIstek.icon = 'ai ai-kayitli-ortez-protez';
            ortezIstek.componentInstance = this.helpMenuService;
            ortezIstek.clickFunction = this.helpMenuService.openOrthesisProcedure;
            ortezIstek.parameterFunctionInstance = this;
            ortezIstek.getParamsFunction = this.getClickFunctionParams;
            ortezIstek.ParentInstance = this
            this.sideBarMenuService.addMenu('YardimciMenu', ortezIstek);
        }

        let archiveDeliveryForm = new DynamicSidebarMenuItem();
        archiveDeliveryForm.key = 'archiveDeliveryForm';
        archiveDeliveryForm.label = 'Arşiv Teslim Formu';
        archiveDeliveryForm.icon = 'fa fa-file-text-o';
        archiveDeliveryForm.componentInstance = this.helpMenuService;
        archiveDeliveryForm.clickFunction = this.helpMenuService.openArchiveDeliveryForm;
        archiveDeliveryForm.parameterFunctionInstance = this;
        archiveDeliveryForm.getParamsFunction = this.getClickFunctionParams;
        archiveDeliveryForm.ParentInstance = this
        this.sideBarMenuService.addMenu('YardimciMenu', archiveDeliveryForm);

        ///BEGIN RAPORLAR

        let orderInfoReport = new DynamicSidebarMenuItem();
        orderInfoReport.key = 'onMedulaReports';
        orderInfoReport.icon = 'fa fa-print';
        orderInfoReport.label = i18n("M30900", "Hasta Orderları Yazdır");
        orderInfoReport.componentInstance = this;
        orderInfoReport.clickFunction = this.openOrderInfoReport;
        this.sideBarMenuService.addMenu('ReportMainItem', orderInfoReport);

        let orderInfoReportBySign = new DynamicSidebarMenuItem();
        orderInfoReportBySign.key = 'onMedulaReports';
        orderInfoReportBySign.icon = 'fa fa-file-text-o';
        orderInfoReportBySign.label = i18n("M30900", "Hemşirelik Uygulamaları Planı");
        orderInfoReportBySign.componentInstance = this;
        orderInfoReportBySign.clickFunction = this.openOrderInfoReportBySign;
        this.sideBarMenuService.addMenu('ReportMainItem', orderInfoReportBySign);



        let nursingApplicationDailyOrder = new DynamicSidebarMenuItem();
        nursingApplicationDailyOrder.key = 'onMedulaReports';
        nursingApplicationDailyOrder.icon = 'fa fa-file-text-o';
        nursingApplicationDailyOrder.label = i18n("M30900", "HEMŞİRELİK HİZMETLERİ HASTA İZLEM FORMU");
        nursingApplicationDailyOrder.componentInstance = this;
        nursingApplicationDailyOrder.clickFunction = this.opennursingApplicationDailyOrder;
        this.sideBarMenuService.addMenu('ReportMainItem', nursingApplicationDailyOrder);

        let patientVacationForm = new DynamicSidebarMenuItem();
        patientVacationForm.key = 'patientVacationForm';
        patientVacationForm.icon = 'fa fa-print';
        patientVacationForm.label = i18n("M30900", "Hasta İzin Formu");
        patientVacationForm.componentInstance = this;
        patientVacationForm.clickFunction = this.printVacationForm;
        this.sideBarMenuService.addMenu('ReportMainItem', patientVacationForm);

        let empBedStaticForm = new DynamicSidebarMenuItem();
        empBedStaticForm.key = 'empBedStaticForm';
        empBedStaticForm.icon = 'fas fa-chart-bar';
        empBedStaticForm.label = 'Boş Yatak Listesi'
        empBedStaticForm.componentInstance = this;
        empBedStaticForm.clickFunction = this.getActiveClinicsForReport;
        // emergencyStaticForm.parameterFunctionInstance = this;
        // emergencyStaticForm.getParamsFunction = this.getClickFunctionParams;
        empBedStaticForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', empBedStaticForm);

        let patientVacationListReport = new DynamicSidebarMenuItem();
        patientVacationListReport.key = 'patientVacationListReport';
        patientVacationListReport.icon = 'fas fa-chart-bar';
        patientVacationListReport.label = 'İzinli Hasta Listesi'
        patientVacationListReport.componentInstance = this;
        patientVacationListReport.clickFunction = this.getActiveClinicsForReport;
        patientVacationListReport.parameterFunctionInstance = this;
        patientVacationListReport.getParamsFunction = this.returnPatientVacationListReportName;
        patientVacationListReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', patientVacationListReport);


        ///END RAPORLAR

        let archiveRequest = new DynamicSidebarMenuItem();
        archiveRequest.key = 'archiveRequest';
        archiveRequest.icon = "fa fa-archive";
        archiveRequest.label = 'Arşiv İstek';
        archiveRequest.componentInstance = this;
        archiveRequest.clickFunction = this.openArchiveRequest;
        this.sideBarMenuService.addMenu('YardimciMenu', archiveRequest);

        let checklist = new DynamicSidebarMenuItem();
        checklist.key = 'checklist';
        checklist.icon = 'fa fa-list-ol';
        checklist.label = "Güvenli Cerrahi Kontrol Listesi";
        checklist.componentInstance = this;
        checklist.clickFunction = this.openSafeSurgeryChecklists;
        this.sideBarMenuService.addMenu('YardimciMenu', checklist);

        let labBarcode = new DynamicSidebarMenuItem();
        labBarcode.key = 'labBarcode';
        labBarcode.icon = 'fa fa-barcode';
        labBarcode.label = 'Laboratuvar Barkodu Bas';
        labBarcode.componentInstance = this.helpMenuService;
        labBarcode.clickFunction = this.helpMenuService.printLabBarcode;
        labBarcode.parameterFunctionInstance = this;
        labBarcode.getParamsFunction = this.getClickFunctionParams;
        labBarcode.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', labBarcode);

    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('epicrisisForm');
        this.sideBarMenuService.removeMenu('inpatientTreatmentClinicApp');
        this.sideBarMenuService.removeMenu('printInpatientTreatmentBarcode');
        this.sideBarMenuService.removeMenu('patientDocumentUpload');
        this.sideBarMenuService.removeMenu('dentistAdmission');
        this.sideBarMenuService.removeMenu('printInpatientAdmissionInfoByTreatmentClinicReport');
        this.sideBarMenuService.removeMenu('nursingNoteReport');
        this.sideBarMenuService.removeMenu('orderInfoReport');
        this.sideBarMenuService.removeMenu('orderInfoReportBySign');
        this.sideBarMenuService.removeMenu('report');
        this.sideBarMenuService.removeMenu('onMedulaReports');
        this.sideBarMenuService.removeMenu('printInpatientBarcode');
        this.sideBarMenuService.removeMenu('empBedStaticForm');
        this.sideBarMenuService.removeMenu('printSerumBarcode');
        this.sideBarMenuService.removeMenu('patientVacationListReport');
        this.sideBarMenuService.removeMenu('patientVacationForm');
        this.sideBarMenuService.removeMenu('archiveDeliveryForm');
        this.sideBarMenuService.removeMenu('archiveRequest');
        /*  this.sideBarMenuService.removeMenu('emergencyOrderMenu'); */

        this.sideBarMenuService.removeMenu('checklist');
        this.sideBarMenuService.removeMenu('labBarcode');


    }

    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

    }

    onTabItemRendered(e: any) {
        if (e.itemData.title === i18n("M15930", "Hizmet ve Tetkik")) {
            let that = this;
            setTimeout(function () {
                that.requestedProceduresFormInstance.PackageProcedureGrid.Height = that.requestedProceduresFormInstance.PackageProcedureGrid.Height - 1;
            }, 300);
        }
    }

    okClickFallingRiskBox(isDone: boolean) {
        this.ShowFallingRiskPopup = false;
        if (isDone) {
            let params: NursingAppDoneInfoInput = new NursingAppDoneInfoInput();
            params.NursingApplicationID = this.nursingApplicationMainFormViewModel._NursingApplication.ObjectID;
            let apiUrl: string = '/api/NursingApplicationService/setFallingRiskNursingAppDoneDate';
            this.httpService.post<void>(apiUrl, params);
        }
    }

    okClickWoundRiskInfoBox(isDone: boolean) {
        this.ShowWoundInfoPopup = false;
        if (isDone) {
            let params: NursingAppDoneInfoInput = new NursingAppDoneInfoInput();
            params.NursingApplicationID = this.nursingApplicationMainFormViewModel._NursingApplication.ObjectID;
            let apiUrl: string = '/api/NursingApplicationService/setLastWoundAssessmentNursingAppDoneDate';
            this.httpService.post<void>(apiUrl, params);
        }
    }
    okClickPainInfoBox(isDone: boolean) {
        this.ShowPainInfoPopup = false;
        if (isDone) {
            let params: NursingAppDoneInfoInput = new NursingAppDoneInfoInput();
            params.NursingApplicationID = this.nursingApplicationMainFormViewModel._NursingApplication.ObjectID;
            let apiUrl: string = '/api/NursingApplicationService/setLastPainScaleNursingAppDoneDate';
            this.httpService.post<void>(apiUrl, params);
        }
    }
    yesClickOutDatedFallingRiskInfoBox() {
        this.ShowOutDatedFallingRiskPopUp = false;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'BaseNursingFallingDownRiskForm';
            componentInfo.ModuleName = "HemsirelikIslemleriModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/HemsirelikIslemleriModule';
            componentInfo.InputParam = new DynamicComponentInputParam(this.nursingApplicationMainFormViewModel._NursingApplication, new ActiveIDsModel(this._NursingApplication.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Hemşirelik Düşme Riski Değerlendirme Formu";
            modalInfo.Width = 1100;
            modalInfo.Height = 850;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    okClickOutDatedFallingRiskInfoBox() {
        this.ShowOutDatedFallingRiskPopUp = false;
    }
    okClickOutDatedFormBox() {
        this.ShowOutDatedFormsPopup = false;
    }
    noClickOutDatedFallingRiskInfoBox() {
        let params: NursingAppDoneInfoInput = new NursingAppDoneInfoInput();
        params.NursingApplicationID = this.nursingApplicationMainFormViewModel._NursingApplication.ObjectID;
        let apiUrl: string = '/api/NursingApplicationService/setFallingRiskFormNursingAppDoneDate';
        this.httpService.post<void>(apiUrl, params);
        this.ShowOutDatedFallingRiskPopUp = false;
    }
    okClickDrugFormBox() {
        this.ShowDrugFormsPopup = false;
    }
    okClickVitalInfoBox() {
        this._showVitalInfoPopUp = false;
    }

    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;
    }

    public getMasterObjectIdForDentalExam() {
        return this._NursingApplication.InPatientTreatmentClinicApp.ObjectID;
    }

    public getClinicList() {

    }

    public onContentReady(args) {

        let agendaView = args.component.getWorkSpace();
        agendaView.option("rowHeight", 70);
    }
    public onAppointmentRendered(args: any) {

        args.appointmentElement.style.height = '70px';
    }

    public openNursingNoteReportDiag() {
        let that = this;
        that.reportController.startDate = new Date(this.currentDate.toString());
        that.reportController.endDate = new Date(this.currentDate.AddDays(1).toString());
        this.httpService.get<Array<ResSection>>("api/NursingApplicationService/GetResourceList")
            .then(result => {
                that.reportController.ResourceList = result as Array<ResSection>;
                that.showNursingReport = true;
            })
            .catch(error => {
                that.messageService.showError(error);
            });

    }

    public getPatientList(event) {
        let that = this;
        this.httpService.get<Array<Patient>>("api/NursingApplicationService/GetPatientList?ResourceID=" + event.value)
            .then(result => {
                this.reportController.PatientList = result as Array<Patient>;

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public onReportSDateChanged(event) {
        this.reportController.startDate = event.value;
    }

    onReportEDateChanged(event) {
        this.reportController.endDate = event.value;
    }

    public openNursingNoteReport() {
        const objectIdParam = new GuidParam("f1799df8-f784-4f81-b80e-4ea1e21c8416");//öyleswine bir guid raporda kullanılmıyor
        const master = new GuidParam(this.reportController.selectedReportResource.toString());
        let _patient = [];

        let control = new IntegerParam();
        let i = 0;

        if (this.reportController.selectedPatient != undefined) {
            this.reportController.selectedPatient.forEach(x => {
                _patient.push(new StringParam(x.ObjectID.toString()));
            });
        }

        let _patientList = null;

        if (_patient[0] == undefined) {
            control = new IntegerParam(0);

        }
        else {
            control = new IntegerParam(1);
        }
        _patientList = new ArrayParam(_patient);
        let reportParameters: any = {
            'TTOBJECTID': objectIdParam, 'MASTERRESOURCE': master,
            'PATIENTS': _patientList, 'STARTDATE': new DateParam(this.reportController.startDate), 'ENDDATE': new DateParam(this.reportController.endDate),
            'PATIENTCONTROL': control
        };
        this.reportService.showReport('NursingNoteReport', reportParameters);

    }


    public openOrderInfoReport(event) {
        const objectIdParam = new GuidParam(this._NursingApplication.ObjectID.toString());
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReportModal('NursingApplicationOrderInfoReport', reportParameters);
    }

    public openOrderInfoReportBySign(event) {
        const objectIdParam = new GuidParam(this._NursingApplication.ObjectID.toString());
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReportModal('NursingApplicationOrderInfoReportBySign', reportParameters);
    }

    public opennursingApplicationDailyOrder(event) {
        let sdate: Date = new Date(this.reportController.startDate.Year, this.reportController.startDate.Month, this.reportController.startDate.Day, 0, 0, 0, 0);
        let edate: Date = new Date(this.reportController.endDate.Year, this.reportController.endDate.Month, this.reportController.endDate.Day, 23, 59, 59, 0);
        const objectIdParam = new GuidParam(this._NursingApplication.ObjectID.toString());
        let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'STARTDATE': new DateParam(sdate), 'ENDDATE': new DateParam(edate) };
        this.reportService.showReportModal('NursingApplicationDailyOrderDetailReport', reportParameters);
    }

    public printSerumBarcode() {
        let that = this;
        let info: SerumBarcodeInfo = new SerumBarcodeInfo();
        info.PatientName = that.nursingApplicationMainFormViewModel.PatientNameSurname;
        info.NurseName = that.nursingApplicationMainFormViewModel.NurseName;
        that.barcodePrintService.printAllBarcode(info, "generateSerumBarcode", "");
    }

    public returnPatientVacationListReportName(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, "IZINLIHASTALISTESI");
        return clickFunctionParams;
    }

    async printVacationForm() {

        let fullApiUrl = '/api/InpatientPhysicianApplicationService/GetPatientLastActiveVacation/?Patient=' + this.nursingApplicationMainFormViewModel._NursingApplication.Episode.Patient;

        let ID = await this.httpService.get<string>(fullApiUrl);

        if (ID != "")
            this.onPrintVacationForm(ID);
        else
            this.messageService.showInfo("Hastaya ait aktif bir izin bulunamadı");
    }

    onPrintVacationForm(ID: string) {

        let reportData: DynamicReportParameters = {

            Code: 'VACATIONFORM',
            ReportParams: { ObjectID: ID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "HASTA İZİN FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }


    async newOrderSelectionChange(data: any) {
        /**
         * Hemşirelik uygulamaları seçili ise çalışssın
         */

        if (data.currentSelectedRowKeys.length >= 1) {
            if (data.currentSelectedRowKeys != null) {

                for (let i = 0; (i < data.currentSelectedRowKeys.length); i++) {
                    if (data.currentSelectedRowKeys[i].typeId === OrderTypeEnum.NursingOrder) {
                        data.component.deselectRows(data.currentSelectedRowKeys[i]);
                    }
                }
            }
        }

    }

    public showArchiveRequest: boolean = false;
    public controlCount: boolean = false;
    public ArchiveRequest: ArchiveRequestModel = new ArchiveRequestModel();
    PatientEpisodeFolderList: Array<EpisodeFolderModel> = new Array<EpisodeFolderModel>();
    public async openArchiveRequest() {
        let fullApiUrl = '/api/InpatientPhysicianApplicationService/GetPatientEpisodeFolders?EpisodeActionID=' + this.nursingApplicationMainFormViewModel._NursingApplication.ObjectID.toString();
        await this.httpService.get<ArchiveRequestModel>(fullApiUrl).then(response => {
            let result = response;
            if (result != null) {
                this.ArchiveRequest = result;
                this.PatientEpisodeFolderList = result.PatientEpisodeFolders;
                if (result.PatientEpisodeFolders.length > 0) {
                    this.showArchiveRequest = true;
                }
                else {
                    ServiceLocator.MessageService.showError("Hastanın arşiv kaydı bulunmamaktadır");
                }
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }
    selectedFolders: Array<any> = new Array<any>();
    selectionEpisodeFolder(data) {
        this.selectedFolders = data.selectedRowsData;

    }

    RequestedFilesList: Array<Guid> = new Array<Guid>();
    archiveRequestFormInput: Guid;
    public archiveDescription: string = "";
    public CreateArchiveRequest() {

        if (this.archiveDescription == "") {
            ServiceLocator.MessageService.showError("İstek açıklaması yazılmadan arşiv isteği yapılamaz");
            return;
        }


        this.selectedFolders.forEach(folder => {
            this.RequestedFilesList.push(folder.ObjectID);
        });

        let requestInput: string = "";
        requestInput = JSON.stringify(this.RequestedFilesList);

        let that = this;
        let requestURL: string = '/api/InpatientPhysicianApplicationService/CreateArchiveRequest?inputList=' + requestInput
            + "&description=" + this.archiveDescription + "&requesterSectionId=" + new Guid(this._NursingApplication.MasterResource.toString());

        that.httpService.get<Guid>(requestURL).then(
            async result => {
                this.archiveRequestFormInput = result;
                this.messageService.showInfo("İstek Oluşturuldu");
                this.showArchiveRequest = false;
                this.archiveDescription = "";
                this.RequestedFilesList = new Array<Guid>();
                this.printRequestForm();
            }).catch(error => {
                this.messageService.showError(error);
            });
    }

    public async printRequestForm(): Promise<ModalActionResult> {


        let reportData: DynamicReportParameters = {

            Code: 'ARSIVISTEKFORMU',
            ReportParams: { ArchiveRequestObjectID: this.archiveRequestFormInput },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "ARŞİV İSTEK FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public ProceduresGridColumns = [
        {
            caption: i18n("M19030", "Ameliyat İstek Tarihi"),
            dataField: 'RequestDate',
            allowSorting: true,
            format: 'dd.MM.yyyy',
            dataType: 'date',
            width: 150
        },
        {
            caption: i18n("M19030", "Ameliyat Hizmetleri"),
            dataField: 'Procedures',
            dataType: 'string',
            allowEditing: false,
            width: 300
        }
    ];
    showChecklistSelection: boolean = false;
    safeSurgerydataSource: Array<SurgeryChecklistModel> = new Array<SurgeryChecklistModel>();
    public openSafeSurgeryChecklists() {
        let that = this;

        this.httpService.get<Array<SurgeryChecklistModel>>("api/SafeSurgeryCheckListService/GetSafeSurgeryChecklistsBySurgery?episodeActionId=" + this._NursingApplication.MasterAction + "&ObjectDefName=" + "NURSINGAPPLICATION").then(async result => {
            let checklists = result as Array<SurgeryChecklistModel>;
            if (checklists.length == 0) {
                this.messageService.showInfo('Kayıtlı Güvenli Cerrahi Kontrol Listesi bulunamamıştır');
                return;
            }
            else if (checklists.length > 1) {
                this.safeSurgerydataSource = checklists;
                this.showChecklistSelection = true;
            }
            else if (checklists.length == 1) {
                let param: ClickFunctionParams = this.getClickFunctionParams();
                await that.helpMenuService.showSurgeryChecklist(checklists[0].ChecklistID, param);
            }
        }).catch(error => {
            console.log(error);
        });
    }
    public selectedSurgery: SurgeryChecklistModel;
    public async onSafeSurgeryGridRowClick(event) {
        this.selectedSurgery = event.data;

        if (this.selectedSurgery == null) {
            this.messageService.showInfo('Lütfen açmak istediğiniz kaydı seçiniz');
            return;
        }

        else {
            let param: ClickFunctionParams = this.getClickFunctionParams();
            await this.helpMenuService.showSurgeryChecklist(this.selectedSurgery.ChecklistID, param);
        }
    }

    public openTeleOrder: boolean = false;
    public activeInpatientApp: InPatientPhysicianApplication;
    async OpenTeleOrderClick() {
        let params: NursingAppDoneInfoInput = new NursingAppDoneInfoInput();
        params.NursingApplicationID = this.nursingApplicationMainFormViewModel._NursingApplication.ObjectID;
        let apiUrl: string = '/api/NursingApplicationService/GetActiveInPatientPhysicianApp';
        this.activeInpatientApp = await this.httpService.post<InPatientPhysicianApplication>(apiUrl, params);
        this.openTeleOrder = true;
    }

    public StoreList: Array<Store>;
    public selectedStore: Array<Store> = new Array<Store>();
    public openEmergencyOrder: boolean = false;
    filterMaterial: string;
    async OpenEmergencyOrderClick() {
        this.getEmergencyOrderDetail();

        this.StoreList = await UserHelper.UseUserResourcesStores;
        let getStore = await ResourceService.GetStore(this._NursingApplication.MasterResource.toString());
        this.selectedStore.push(this.StoreList.find(x => x.ObjectID.toString() == getStore.ObjectID.toString()));
        this.setTreatmentMaterialFilterExpression(this.selectedStore[0]);
        this.selectedEmergencyOrderDetail = new Array<EmergecyOrderDetailDTO>();
        this.openEmergencyOrder = true;
    }

    async setTreatmentMaterialFilterExpression(store: Store) {
        let filterString: string = '""';
        if (store) {
            filterString = 'THIS.OBJECTDEFNAME IN (\'CONSUMABLEMATERIALDEFINITION\',\'DRUGDEFINITION\') ';//,
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

    openMaterialDropDown(e: any) {
        this.getNewMaterialDataSource();
    }

    materialDataSource: DataSource;
    public searchText: string;
    selectedMaterialItem: any = {};

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

    @ViewChild('materialDrop') materialDrop: DxDropDownBoxComponent;
    selectMaterial(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedMaterialItem = e.data;
        this.materialSelected(e.data);
        this.materialDrop.instance.close();
        this.onClearMaterial(null);
    }

    public materialSelected(material: any) {

        let emgMat: EmergecyOrderDetailDTO = new EmergecyOrderDetailDTO();
        emgMat.materialObjectID = material.ObjectID;
        emgMat.materialName = material.Name;
        emgMat.status = StockActionDetailStatusEnum.New;
        emgMat.detailObjectId = Guid.Empty;
        emgMat.amount = 1;


        if (this.EmergencyOrderDetail.length > 0) {
            if (this.EmergencyOrderDetail.filter(x => x.materialObjectID == material.ObjectID).length > 0) {
                ServiceLocator.MessageService.showError("Aynı ilaç eklemessiniz");
            }
            else {
                this.EmergencyOrderDetail.push(emgMat);
            }
        }
        else {
            this.EmergencyOrderDetail.push(emgMat);
        }
    }

    public onClearMaterial(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedMaterialItem = {};
        }
    }

    EmergencyOrderDesciption: string;
    EmergencyOrderDetail: Array<EmergecyOrderDetailDTO> = new Array<EmergecyOrderDetailDTO>();
    EmergencyOrderDetailComp: Array<EmergecyOrderDetailDTO> = new Array<EmergecyOrderDetailDTO>();
    public selectedEmergencyOrderDetail: Array<EmergecyOrderDetailDTO> = new Array<EmergecyOrderDetailDTO>();

    async newEmergencyOrderSelectionChange(data: any) {
        if (data.currentSelectedRowKeys.length >= 1) {
            if (data.currentSelectedRowKeys != null) {
                if (data.currentSelectedRowKeys[0].status != 0) {
                    this.selectedEmergencyOrderDetail = data.selectedRowKeys.filter(x => x.materialObjectID != data.currentSelectedRowKeys[0].materialObjectID);
                    ServiceLocator.MessageService.showError("Durumu yeni olmayan ugulama seçemessiniz.");
                }
            }
        }
    }

    public getEmergencyOrderDetail() {
        let that = this;
        this.EmergencyOrderDetail = new Array<EmergecyOrderDetailDTO>();
        this.EmergencyOrderDetailComp = new Array<EmergecyOrderDetailDTO>();
        let fullApiUrl: string = 'api/EmergencyOrderService/getEmergencyOrderDetails';
        let input: EmergecyOrderDetailInput_DTO = new EmergecyOrderDetailInput_DTO();
        input.episodeActionID = this._EpisodeAction.ObjectID;

        this.httpService.post<Array<EmergecyOrderDetailDTO>>(fullApiUrl, input)
            .then((res) => {
                for (let item of res) {
                    if (item.status == 0) {
                        this.EmergencyOrderDetail.push(item);
                    } else {
                        this.EmergencyOrderDetailComp.push(item);
                    }
                }
                if (this.EmergencyOrderDetail.length > 0) {
                    this.EmergencyOrderDesciption = this.EmergencyOrderDetail[this.EmergencyOrderDetail.length - 1].desciption;
                } else {
                    ServiceLocator.MessageService.showSuccess("Acil İlaç Bulunamadı.");
                    this.EmergencyOrderDesciption = "";
                }

            })
            .catch(error => {
                ServiceLocator.MessageService.showSuccess(error);
            });
    }

    public EmergencyOrderDetailGridColumns = [
        {
            dataField: 'detailObjectId',
            visible: false
        },
        {
            dataField: 'materialObjectID',
            visible: false
        },
        {
            caption: 'Eş Değeri',
            name: "RowEquivalent",
            dataField: 'materialObjectID',
            width: '10%',
            cellTemplate: 'equivalentCellTemplate',
            allowEditing: false,
            cssClass: "remove-padding"
        },
        {
            caption: "Malzeme",
            dataField: 'materialName',
            width: '60%'
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
            lookup: { dataSource: StockActionDetailStatusEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' }
        },
        {
            caption: 'İptal Et',
            name: "RowDelete",
            alignment: "center",
            width: '10%',
            cellTemplate: "deleteCellTemplate",

        }];


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
            allowEditing: true,
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


    async onAmountUpdateChanged(data, row) {
        row.data.amount = data.value;
    }

    @ViewChild('emergecyOrderGrid') datagrid: DxDataGridComponent;
    async gridEmergecyOrderMaterialGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    let result1: string =
                        await ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", i18n("M23735", "Uyarı"), i18n("M18921", "Order İptal!"), "Bu order iptal edilecektir." + "\r\n" + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                    if (result1 == "T") {
                        data.row.key.status = 1;
                        this.dataGrid.instance.refresh();
                    }
                }
            }
        }
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
                    else {
                        ServiceLocator.MessageService.showInfo('İptal edilen bir order tekrar iptal edilemez.');
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


    async btnEqualDrug(event) {
        let order: any = event.row.data;

        let equivalentInfo: Array<EquivalentInfo> = await StockActionService.GetEquivalentDrug(this._EpisodeAction.MasterResource.toString(), order.materialObjectID.toString());
        if (equivalentInfo.length > 0) {
            let equivalentDrug: any = await this.checkEquivalent(equivalentInfo);
            if (equivalentDrug !== null) {
                order.Material = equivalentDrug;
                let stockInheld2: number = await StockLevelService.StockInheld(order.materialObjectID, this._EpisodeAction.MasterResource.ObjectID);
                order.StoreInheld = stockInheld2;
                for (let detailItem of this.EmergencyOrderDetail) {
                    if (detailItem.detailObjectId.toString() === order.RowObjectId.id) {
                        detailItem.materialName = order.Material.Name;
                        detailItem.materialObjectID = order.Material.ObjectDefId;
                    }
                }
            }
        } else {
            ServiceLocator.MessageService.showInfo('Seçmiş olduğunuz Mevcutlu eşdeğeri bulunmamaktadır.');
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
                        if (drugObjectid !== null) {
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

    closePopupCancel() {
        this.openEmergencyOrder = false;
    }

    public selectedEmergencyOrderDetailDTO: Array<EmergecyOrderDetailDTO> = new Array<EmergecyOrderDetailDTO>();
    closePopupOK() {
        this.selectedEmergencyOrderDetailDTO = new Array<EmergecyOrderDetailDTO>();
        for(let selectItem of this.selectedEmergencyOrderDetail){
            if(this.selectedEmergencyOrderDetailDTO.length > 0){
                if(this.selectedEmergencyOrderDetailDTO.find(x=>x.materialObjectID == selectItem.materialObjectID) == null){
                    this.selectedEmergencyOrderDetailDTO.push(selectItem);
                }
            }
            else{
                this.selectedEmergencyOrderDetailDTO.push(selectItem);
            }
        }
        
        if(this.selectedEmergencyOrderDetailDTO.length == 0)
        {
            ServiceLocator.MessageService.showInfo("Malzeme seçimi yapılmadan işlem devam ettirilemez");
            return;
        }

        let that = this;
        let fullApiUrl: string = 'api/EmergencyOrderService/applyEmergencyOrderDetails';
        let input: EmergecyOrderDTO_Input = new EmergecyOrderDTO_Input();
        input.emergecyOrderDetailDTO = new Array<EmergecyOrderDetailDTO>();
        input.emergecyOrderDetailDTO = that.EmergencyOrderDetail;
        input.selectedEmergecyOrderDetailDTO = that.selectedEmergencyOrderDetailDTO;
        input.episodeActionID = this._EpisodeAction.ObjectID;
        input.desciption = this.EmergencyOrderDesciption;
        input.storeID = this.selectedStore[0].ObjectID;
        this.httpService.post<string>(fullApiUrl, input)
            .then((res) => {
                ServiceLocator.MessageService.showSuccess(res);
                this.openEmergencyOrder = false;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                //this.openEmergencyOrder = false;
            });
    }

    public getLaboratoryFunctionParams(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams;
        if (typeof this._EpisodeAction.Episode == "string") {
            clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode, null));
        } else {
            if (typeof this._EpisodeAction.Episode.Patient == "string") {
                clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient));
            }
            else {
                clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient.ObjectID));
            }
        }
        clickFunctionParams = new ClickFunctionParams(this, this.barcodePrintService);
        return clickFunctionParams;
    }


}
export class NursingAppDoneInfoInput {
    public NursingApplicationID: Guid;
}

export class EmergecyOrderDetailInput_DTO {
    public episodeActionID: Guid;
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

export class EmergecyOrderDTO_Input {
    public emergecyOrderDetailDTO: Array<EmergecyOrderDetailDTO>;
    public episodeActionID: Guid;
    public desciption: string;
    public selectedEmergecyOrderDetailDTO: Array<EmergecyOrderDetailDTO>;
    public storeID: Guid;
}

export class CancelEmergecyOrderDetailInput_DTO {
    public detailObjectId: Guid;
}

export class CancelEmergecyOrderDetailOutput_DTO {
    public status: StockActionDetailStatusEnum;
    public message:string;
}