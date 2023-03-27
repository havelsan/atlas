
import { Input, Component, ViewChild, ViewChildren, OnInit, QueryList, Renderer2 } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import {
    DrugOrderIntroductionDet,
    DescriptionTypeEnum, DrugUsageTypeEnum, ResSection, DrugOrderIntroduction, DrugOrderTypeEnum,
    Episode, SubEpisode, InPatientPhysicianApplication, ResUser, DrugShapeTypeEnum, RefactoredFrequencyEnum, HospitalTimeSchedule, DrugOrderStatusEnum, DrugDefinition, DrugReportType, DrugOrderDetail, DrugSpecificationEnum, PTSAction
} from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionService, DrugInfo, GetDrugReportNo_Input, DrugIngredient, ControlRepeatDay_Output } from 'NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { DxDataGridComponent, DxRadioGroupComponent } from 'devextreme-angular';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import DataSource from 'devextreme/data/data_source';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { UserHelper } from 'app/Helper/UserHelper';
import { FavoriteDrugService } from 'ObjectClassService/FavoriteDrugService';
import { DrugOrderIntroductionGridViewModel, DrugOrderTimceSchedule, DrugOrderIntroductionNewForm_Output, DrugOrderIntroductionFormViewModel, SaveDrugOrder_Output, DrugOrderIntroductionNewForm_Input, PatientDTO, StopDrugOrders_Input, StopDrugOrders_Output, DrugOrderInfo_Input, DrugOrderInfo_Output, UpgradeDrugOrderDVO, PrepareInteraction_Input, PrepareInteraction_Output, GetAllDrugOrderGridViewModel_Input } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { DrugOrderAddRequirement } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Requirements/DrugOrderAddRequirement';
import { AtlasObjectCloner } from 'app/NebulaClient/ClassTransformer/AtlasObjectCloner';
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { QueryVademecumInteractionDVONew } from 'app/Logistic/Models/LogisticDashboardViewModel';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { DrugOrderIntroductionNewFormViewModel } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderIntroductionNewFormViewModel';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { stringify } from 'querystring';
import { ComboListItem } from 'app/NebulaClient/Visual/ComboListItem';
import { InputForm } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { find } from 'rxjs/operators';
import { OrderTemplateDetailItem } from 'app/Logistic/Views/OrderTemplateComponent';
import { Resolve } from '@angular/router';


@Component({
    selector: 'drug-order-grid-component',
    templateUrl: './DrugOrderGridComponentFormView.html',
    providers: [{ provide: IESignatureService, useClass: ESignatureService }]
})

export class DrugOrderGridComponent implements OnInit {

    //#region DrugOrder verilirken gereken resource ve diğer bilgiler input olarak tanımlandı.
    public _masterResource: ResSection;
    @Input() set MasterResource(propVal: ResSection) {
        this._masterResource = propVal;
    }
    get MasterResource(): ResSection {
        return this._masterResource;
    }
    public _secondaryMasterResource: ResSection;
    @Input() set SecondaryMasterResource(propVal: ResSection) {
        this._secondaryMasterResource = propVal;
    }
    get SecondaryMasterResource(): ResSection {
        return this._secondaryMasterResource;
    }
    public _episode: Episode;
    @Input() set Episode(propVal: Episode) {
        this._episode = propVal;
    }
    get Episode(): Episode {
        return this._episode;
    }
    public _subEpisode: SubEpisode;
    @Input() set SubEpisode(propVal: SubEpisode) {
        this._subEpisode = propVal;
    }
    get SubEpisode(): SubEpisode {
        return this._subEpisode;
    }
    public _activeInPatientPhysicianApp: InPatientPhysicianApplication;
    @Input() set ActiveInPatientPhysicianApp(propVal: InPatientPhysicianApplication) {
        this._activeInPatientPhysicianApp = propVal;
    }
    get ActiveInPatientPhysicianApp(): InPatientPhysicianApplication {
        return this._activeInPatientPhysicianApp;
    }

    public _isVisible: boolean = true;
    @Input() set IsVisible(propVal: boolean) {
        this._isVisible = propVal;
        if (this._isVisible === false)
            this.checkBoxesMode = 'none';
    }
    get IsVisible(): boolean {
        return this._isVisible;
    }

    //#endregion

    // private _patientOwnDrug: ResSection;
    // @Input() set PatientOwnDrug(propVal: ResSection) {
    //     this._patientOwnDrug = propVal;
    // }

    public url = 'api/DrugOrderIntroductionService';
    public drugOrderIntroductionFormViewModel: DrugOrderIntroductionFormViewModel = new DrugOrderIntroductionFormViewModel();
    public refreshGridDataSrouce: Array<DrugOrderIntroductionGridViewModel> = new Array<DrugOrderIntroductionGridViewModel>();
    //Order'ın kaç günlük olacağı.
    public day?: number;
    //Doz Miktarı
    public doseAmount?: number;
    //Order Başlangıç Saati
    public plannedStartTime: Date;
    public timeScheduleDataSource: Array<HospitalTimeSchedule>;
    public selectedTimeSchedule?: Guid;
    public drugName: string;
    public isPatientOwnDrug = false;
    public searchIsPatientOwnDrug = false;
    public patientOwnDrugAmount = 0;
    public isImmediate = false;
    public caseOfNeed = false;
    public isFavoriteDrugList = false;
    public isInheldDrugList = false;
    public isInheld = false;
    public isInpatient = true;
    public searchText = '';
    public favoriteDrugs: Array<DrugInfo>;
    public patientOwnDrugs: Array<DrugInfo>;
    public drugSource: DataSource;
    //public PeriodUnitTypeDataSource = PeriodUnitTypeEnum.Items;
    public DrugUsageTypeDataSource = DrugUsageTypeEnum.Items;
    public DrugOrderTypeDataSource = DrugOrderTypeEnum.Items;
    public DescriptionTypeDataSource = DescriptionTypeEnum.Items;
    public DrugOrderStatusDataSource = DrugOrderStatusEnum.Items;
    //public selectedPeriodUnitType: PeriodUnitTypeEnum;
    public selectedDrugUsageType: DrugUsageTypeEnum;
    public selectedDrugOrderType: DrugOrderTypeEnum;
    public selectedDescriptionType: DescriptionTypeEnum;
    public _DrugOrderIntroduction: DrugOrderIntroduction;
    public drugOrderMaxDate: Date;
    public drugOrderMinDate: Date;
    public MasterGridColumns;
    public MultiSelectGridColumns;
    public MultiSelectGridDataSource: Array<DrugOrderIntroductionGridViewModel> = new Array<DrugOrderIntroductionGridViewModel>();
    public DrugOrderDetailGridColumns;
    public selectedMaterials: Array<DrugInfo> = new Array<DrugInfo>();
    public selectedDrugListItems: Array<DrugInfo> = new Array<DrugInfo>();
    public inheldDrugList: Array<DrugInfo> = new Array<DrugInfo>();
    public usageNote: string = '';
    public drugListSelectionMode: string = 'single';
    //Çoklu seçim.
    public drugListShowSelectionControl: boolean = false;
    //Requirement için
    patient: PatientDTO;
    public drugSearchEnabled: boolean;
    public selectedMasterGridRowKeys: Array<string> = new Array<string>();
    public isHimssRequired = false;
    public isVademecumEntegrasyon = false;
    public checkDrugAmount = false;
    public patientAllergicDrug: Array<Guid> = new Array<Guid>();
    public isFriday: boolean = false;
    public isIngredientSearch: boolean = false;
    public activeIngeridents: Array<DrugIngredient> = new Array<DrugIngredient>();
    public selectedActiveIngeridents: Array<DrugIngredient> = new Array<DrugIngredient>();
    public OrderStatus: string[] = ['Devam Eden Tedaviler', 'Durdurulan & İptal Edilenler', 'Tümü'];
    public SelectedOrderStatus: string = 'Devam Eden Tedaviler';
    public oldOrderstatus: string;
    public isNew: boolean = true;
    public loadingVisible: boolean = false;
    public OrderRestDayCount: number = 1;
    public OrderRestDayDescription: string;
    public DrugUsageTypeSource: Array<EnumItem> = new Array<EnumItem>();
    public checkBoxesMode: string = 'onClick';
    public isCVOrder: boolean = false;
    public isCV: boolean = false;
    public stateAction: Array<any> = new Array<any>();
    public repeatDayWarning: string;
    public isTeleOrder: boolean = false;
    public doctorList: Array<ResUser.ClinicDoctorListNQL_Class> = new Array<ResUser.ClinicDoctorListNQL_Class>();

    @ViewChild('orderMasterGrid') orderMasterGrid: DxDataGridComponent;
    @ViewChildren('orderDetailGrid') orderDetailGrids: QueryList<DxDataGridComponent>;
    @ViewChild('eventRadioGroup') eventRadioGroup: DxRadioGroupComponent;


    public CreateMasterGridColumns(): Array<any> {
        if (this.timeScheduleDataSource != null)
            return this.MasterGridColumns = [
                {
                    caption: "Durum",
                    dataField: 'Status',
                    lookup: { dataSource: this.DrugOrderStatusDataSource, valueExpr: 'ordinal', displayExpr: 'description' },
                    width: 'auto',
                    fixed: true,
                    visibleIndex: 0,
                    allowEditing: false,

                },
                {
                    caption: "Order Tarihi",
                    dataField: 'CreationDate',
                    dataType: 'date',
                    format: 'dd/MM/yyyy',
                    fixed: true,
                    allowEditing: false,
                    width: 'auto',
                    visibleIndex: 1,
                    sortOrder: 'desc'
                },
                {
                    caption: i18n("M27573", "Uyg. Baş. Tarihi"),
                    dataField: 'PlannedStartTime',
                    dataType: 'date',
                    format: 'dd/MM/yyyy',
                    fixed: true,
                    width: 'auto',
                    visibleIndex: 2,
                    sortOrder: 'desc',
                    editorOptions: {
                        min: this.drugOrderMinDate,
                        max: this.drugOrderMaxDate
                    }
                },
                {
                    caption: 'Baş. Saati',
                    dataField: 'DrugOrderIntroDuctionTimeSchedule[0].Time',
                    dataType: "date",
                    format: "shortTime",
                    fixed: true,
                    width: 80,
                    visibleIndex: 3,
                    allowEditing: false,
                    editorOptions: { type: "time" },
                },
                {
                    caption: 'Baş. Saati',
                    dataField: 'OrderStartTime',
                    dataType: "date",
                    format: "shortTime",
                    visible: false,
                    allowEditing: true,
                    editorOptions: { type: "time" },
                },
                {
                    caption: "Uyg. Bit. Tarihi",
                    dataField: 'PlannedEndTime',
                    dataType: 'date',
                    format: 'dd/MM/yyyy HH:mm',
                    fixed: true,
                    width: 'auto',
                    visibleIndex: 4,
                    allowEditing: false,
                    editorOptions: {
                        min: this.drugOrderMinDate,
                        max: this.drugOrderMaxDate
                    }
                },
                {
                    caption: i18n("M16287", "İlaç"),
                    dataField: 'Material.name',
                    fixed: true,
                    allowEditing: false,
                    width: 200,
                },
                {
                    caption: i18n("M13285", "Doz Aralığı"),
                    dataField: 'HospitalTimeScheduleObjectID',
                    lookup: { dataSource: this.timeScheduleDataSource, valueExpr: 'ObjectID', displayExpr: 'Name' },
                    alignment: 'right',
                    fixed: true,
                    width: 80,
                    validationRules: [{ type: 'required', message: 'Doz Aralığı Boş Geçilemez' }]
                },
                {
                    caption: i18n("M13294", "Doz Miktarı"),
                    dataField: 'DoseAmount',
                    dataType: 'number',
                    //format: '##,#',
                    /*editorOptions: {
                        onKeyPress: function (e) {
                            let event = e.event,
                                str = String.fromCharCode(event.keyCode);
                            if (!/[0-9]/.test(str))
                                event.preventDefault();
                        }
                    },*/
                    alignment: 'left',
                    fixed: true,
                    width: 'auto',
                    validationRules: [{ type: 'required', message: 'Doz Miktarı Boş Geçilemez' }]
                },
                {
                    caption: i18n("M14998", "Gün"),
                    dataField: 'Day',
                    dataType: 'number',
                    format: '#',
                    editorOptions: {
                        onKeyPress: function (e) {
                            let event = e.event,
                                str = String.fromCharCode(event.keyCode);
                            if (!/[0-9]/.test(str))
                                event.preventDefault();
                            /*if (Number(event.key) > 9) {
                                event.preventDefault();
                                ServiceLocator.MessageService.showError('En fazla 3 günlük Order verebilirsiniz!');
                            }*/
                        }
                    },
                    fixed: true,
                    width: 50,
                    validationRules: [{ type: 'required', message: 'Gün Boş Geçilemez' }]
                },
                {
                    caption: i18n("M17991", "Kullanma Açıklaması"),
                    dataField: 'UsageNote',
                    width: 200,
                },
                {
                    caption: i18n("M10430", "Acil İlaç"),
                    dataField: 'IsImmediate',
                    dataType: 'boolean',
                    width: 'auto',
                },
                {
                    caption: "CV",
                    dataField: 'IsCV',
                    dataType: 'boolean',
                    allowEditing: false,
                    width: 'auto',
                },
                {
                    caption: "Sözel Order",
                    dataField: 'IsTeleOrder',
                    dataType: 'boolean',
                    allowEditing: false,
                    width: 'auto',
                },
                {
                    caption: "Hastanın İlacı",
                    dataField: 'PatientOwnDrug',
                    dataType: 'boolean',
                    width: 'auto',
                    //allowEditing: false,
                },
                {
                    caption: i18n("M26386", "Lüzumu Halinde"),
                    dataField: 'CaseOfNeed',
                    dataType: 'boolean',
                    width: 'auto',
                },
                {
                    caption: i18n("M17982", "Kullanım Şekli"),
                    dataField: 'DrugUsageType',
                    lookup: { dataSource: this.DrugUsageTypeSource, valueExpr: 'ordinal', displayExpr: 'description' },
                    width: 'auto',
                    validationRules: [{ type: 'required', message: 'Kullanım Şekli Boş Geçilemez' }]
                },
                {
                    caption: i18n("M17982", "Tedavi Türü"),
                    dataField: 'DrugOrderType',
                    lookup: { dataSource: DrugOrderTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
                    width: 90,
                },
                {
                    caption: 'Doktor Adı',
                    dataField: 'DoctorName',
                    allowEditing: false,
                    width: 'auto',
                },
                {
                    caption: 'ID',
                    dataField: 'ID',
                    cellTemplate: 'buttonCellTemplate',
                    alignment: 'center',
                    allowResizing: false,
                    allowEditing: false,
                    fixedPosition: "right",
                    fixed: true,
                    cssClass: 'remove-padding',
                    width: 120,
                    visible: this._isVisible,
                }
            ];
    }


    public CreateDetailGridColumns(): Array<any> {
        return this.DrugOrderDetailGridColumns = [
            {
                caption: 'T',
                dataField: 'DetailNo',
                dataType: 'number',
                allowEditing: false,
                width: 40,
            },
            {
                caption: 'Tarih',
                dataField: 'Time',
                dataType: "date",
                format: "shortDateShortTime",
                width: 160,
                allowEditing: false,
            },
            {
                caption: 'Saat',
                dataField: 'Time',
                dataType: "date",
                format: "shortTime",
                width: 80,
                editorOptions: {
                    type: "time",
                    min: this.drugOrderMinDate,
                    //max: this.drugOrderMaxDate,
                },
            },
            {
                caption: i18n("M13294", "Doz Miktarı"),
                dataField: 'DoseAmount',
                dataType: 'number',
                //format: '#.#',
                /*editorOptions: {
                    onKeyPress: function (e) {
                        let event = e.event,
                            str = String.fromCharCode(event.keyCode);
                        if (!/[0-9]/.test(str))
                            event.preventDefault();
                        if (Number(event.key) <= 0) {
                            event.preventDefault();
                            ServiceLocator.MessageService.showError('Doz Miktarı sıfırdan büyük olmalıdır!');
                        }
                    }
                },*/
                alignment: 'left',
                width: 120,
            },
            {
                caption: i18n("M17991", "Kullanma Açıklaması"),
                dataField: 'UsageNote',
                width: 250,
            }
        ];
    }

    public CreateMultiSelectGridColumns(): Array<any> {
        if (this.timeScheduleDataSource != null)
            return this.MultiSelectGridColumns = [
                {
                    caption: i18n("M16287", "İlaç"),
                    dataField: 'Material.name',
                    fixed: true,
                    allowEditing: false,
                    width: 200,
                },
                {
                    caption: i18n("M13285", "Doz Aralığı"),
                    dataField: 'HospitalTimeScheduleObjectID',
                    lookup: { dataSource: this.timeScheduleDataSource, valueExpr: 'ObjectID', displayExpr: 'Name' },
                    alignment: 'right',
                    fixed: true,
                    width: 80,
                    validationRules: [{ type: 'required', message: 'Doz Aralığı Boş Geçilemez' }]
                },
                {
                    caption: i18n("M13294", "Doz Miktarı"),
                    dataField: 'DoseAmount',
                    dataType: 'number',
                    //format: '##,#',
                    /*editorOptions: {
                        onKeyPress: function (e) {
                            let event = e.event,
                                str = String.fromCharCode(event.keyCode);
                            if (!/[0-9]/.test(str))
                                event.preventDefault();
                        }
                    },*/
                    alignment: 'left',
                    fixed: true,
                    width: 'auto',
                },
                {
                    caption: i18n("M14998", "Gün"),
                    dataField: 'Day',
                    dataType: 'number',
                    format: '#',
                    editorOptions: {
                        onKeyPress: function (e) {
                            let event = e.event,
                                str = String.fromCharCode(event.keyCode);
                            if (!/[0-9]/.test(str))
                                event.preventDefault();
                            /*if (Number(event.key) > 9) {
                                event.preventDefault();
                                ServiceLocator.MessageService.showError('En fazla 3 günlük Order verebilirsiniz!');
                            }*/
                        }
                    },
                    fixed: true,
                    width: 50,
                },
                {
                    caption: i18n("M17991", "Kullanma Açıklaması"),
                    dataField: 'UsageNote',
                    width: 200,
                },
                {
                    caption: i18n("M10430", "Acil İlaç"),
                    dataField: 'IsImmediate',
                    dataType: 'boolean',
                    width: 'auto',
                },
                {
                    caption: "Hastanın İlacı",
                    dataField: 'PatientOwnDrug',
                    dataType: 'boolean',
                    width: 'auto',
                    //allowEditing: false,
                },
                {
                    caption: i18n("M26386", "Lüzumu Halinde"),
                    dataField: 'CaseOfNeed',
                    dataType: 'boolean',
                    width: 'auto',
                },
                {
                    caption: i18n("M17982", "Kullanım Şekli"),
                    dataField: 'DrugUsageType',
                    lookup: { dataSource: this.DrugUsageTypeSource, valueExpr: 'ordinal', displayExpr: 'description' },
                    width: 'auto',
                },
                {
                    caption: i18n("M17982", "Tedavi Türü"),
                    dataField: 'DrugOrderType',
                    lookup: { dataSource: DrugOrderTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
                    width: 90,
                }
            ];
    }

    constructor(protected http: NeHttpService, public signService: IESignatureService, public renderer: Renderer2) {
        this.cancelClickHandler = this.cancelClickHandler.bind(this);
        this.saveClickHandler = this.saveClickHandler.bind(this);
        this.checkBoxesMode = 'onClick';
        this.stateAction = [
            {
                Caption: "Yeni Direktifleri Sil",
                ActionName: "DeleteDrugOrderGridModel",
                Icon: "dx-icon-trash"
            },
            {
                Caption: "Bütün Direktifleri Getir",
                ActionName: "AllDrugOrderGridModel",
                Icon: "dx-icon-chevrondoubleleft"
            },
            {
                Caption: "Şablondan Seç",
                ActionName: "orderTemplateSelect",
                Icon: "dx-icon-favorites"
            },
            {
                Caption: "Şablon Kaydet",
                ActionName: "orderTemplateAddNew",
                Icon: "dx-icon-save"
            },

        ];
    }

    ngOnInit(): void {
        this.DrugUsageTypeSource = DrugUsageTypeEnum.Items.sort((a, b) => {
            if (a.ordinal > b.ordinal) {
                return 1;
            } else if (a.ordinal < b.ordinal) {
                return -1;
            } else {
                return 0;
            }
        });


        let input: DrugOrderIntroductionNewForm_Input = new DrugOrderIntroductionNewForm_Input();
        if (this._episode.ObjectID != null)
            input.episodeObjectID = this._episode.ObjectID;
        else
            input.episodeObjectID = new Guid(this._episode.toString());
        if (typeof this._masterResource === 'string')
            input.masterResourceObjectID = new Guid(this._masterResource);
        else
            input.masterResourceObjectID = this._masterResource.ObjectID;
        if (typeof this._subEpisode === 'string')
            input.subEpisodeObjectID = new Guid(this._subEpisode);
        else
            input.subEpisodeObjectID = this._subEpisode.ObjectID;
        input.activeInPatientPhysicianApp = this._activeInPatientPhysicianApp.ObjectID;
        input.allDate = false;
        this.http.post<DrugOrderIntroductionNewForm_Output>(this.url + '/CreateDrugOrderIntroductionNewForm', input, DrugOrderIntroductionNewForm_Output).then(result => {
            this._DrugOrderIntroduction = result.drugOrderIntroduction;
            this._DrugOrderIntroduction.DrugOrderIntroductionDetails = new Array<DrugOrderIntroductionDet>();
            this._DrugOrderIntroduction.MasterResource = this._masterResource;
            this._DrugOrderIntroduction.SecondaryMasterResource = this._secondaryMasterResource;
            this._DrugOrderIntroduction.Episode = this._episode;
            this._DrugOrderIntroduction.SubEpisode = this._subEpisode;
            this._DrugOrderIntroduction.ActiveInPatientPhysicianApp = this._activeInPatientPhysicianApp;
            this._DrugOrderIntroduction.PatientOwnDrug = false;
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroduction = this._DrugOrderIntroduction;
            this.patient = result.patientDTO;
            this.isHimssRequired = result.IsHimssRequired;
            this.checkDrugAmount = result.checkDrugAmount;
            this.isVademecumEntegrasyon = result.isVademecumEntegrasyon;
            this.OrderRestDayCount = result.OrderRestDayCount;
            this.OrderRestDayDescription = result.OrderRestDayDescription;
            this.patientAllergicDrug = result.patientDTO.PatientAllergicIngredient;
            this.isCV = result.isCV;
            this.IsVisible = result.isVisible;
            //HospitalTimeSchedule içerisine relation'ı olan HospitalTimeScheduleDetail ları doldurur. (Enterprise daki array içerisinde dönüp relation doldurması gibi.)
            if (result.hospitalTimeSchedule && result.hospitalTimeScheduleDetail != null) {
                result.hospitalTimeSchedule.forEach(element => {
                    element.HospitalTimeScheduleDetails = result.hospitalTimeScheduleDetail.filter(x => x.HospitalTimeSchedule.toString() == element.ObjectID.toString());
                });

                this.timeScheduleDataSource = result.hospitalTimeSchedule.sort((x1, x2) => {
                    if (<number>x1.Frequency > <number>x2.Frequency)
                        return 1;
                    if (<number>x1.Frequency < (<number>x2.Frequency))
                        return -1;
                    return 0;
                });
            }
            else {
                TTVisual.InfoBox.Alert('Doz Aralığı için Zaman Çizelgesi tanımı bulunamadı! Direktif verebilmek için Lütfen yetkili kişiden tanımların yapılmasını isteyiniz.');
            }

            this.CreateMasterGridColumns();
            this.CreateDetailGridColumns();
            //this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel = result.DrugOrderGirdViewModelList as Array<DrugOrderIntroductionGridViewModel>;

            let tempArray: Array<DrugOrderIntroductionGridViewModel> = new Array<DrugOrderIntroductionGridViewModel>();

            tempArray = <Array<DrugOrderIntroductionGridViewModel>>AtlasObjectCloner.clone(result.DrugOrderGirdViewModelList);

            this.refreshGridDataSrouce = tempArray;
            this.filterOrders(this.SelectedOrderStatus);

            //TODO: Sistem parametresinden alınacak. 2 saat öncesine veya 10 gün sonrasına order verileblir.
            let nowDate = new Date(Date.now());
            let minute: number;
            let minTime: Date;
            if (result.DrugOrderTimeOffset > 0) {
                if (nowDate.getMinutes() > 30) {
                    this.drugOrderMinDate = nowDate.AddMinutes(60 - nowDate.getMinutes()).AddHours(-result.DrugOrderTimeOffset);
                }
                else {
                    this.drugOrderMinDate = nowDate.AddMinutes(-nowDate.getMinutes()).AddHours(-result.DrugOrderTimeOffset);
                }
            }
            else {
                this.drugOrderMinDate = new Date(Date.now());
            }
            //this.plannedStartTime = this.drugOrderMinDate.AddMinutes(1);
            this.plannedStartTime = nowDate.AddMinutes(1);
            //this.drugOrderMinDate = new Date(nowDate.getFullYear(), nowDate.getMonth(), nowDate.getDate(), nowDate.getHours()).AddHours(-2);
            this.drugOrderMaxDate = new Date(Date.now()).AddDays(result.OrderRestDayCount);
            this.selectedDrugOrderType = DrugOrderTypeEnum.Treatment;

            this.selectedMasterGridRowKeys = new Array<string>();
            if (this.isNew === true) {
                setTimeout(x => {
                    this.orderMasterGrid.instance.repaint();
                    this.orderDetailGrids.forEach(element => {
                        element.instance.repaint();
                    });
                }, 2500);
                this.isNew = false;
            }
        });


        if (this._activeInPatientPhysicianApp !== undefined) {
            if (this._activeInPatientPhysicianApp.CurrentStateDefID.valueOf() === InPatientPhysicianApplication.InPatientPhysicianApplicationStates.Discharged.id ||
                this._activeInPatientPhysicianApp.CurrentStateDefID.valueOf() === InPatientPhysicianApplication.InPatientPhysicianApplicationStates.PreDischarged.id) {
            } else {
                this.isInpatient = true;
            }
        }

        DrugOrderIntroductionService.GetPatientOwnDrug(this._episode).then(result => {
            this.patientOwnDrugs = result;
        });
    }

    public async SaveDrugOrderMethod() {

        this.loadingVisible = true;
        this.SaveEditCell();
        if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length == 0) {
            if (this.selectedMasterGridRowKeys.length > 0) {
                TTVisual.InfoBox.Alert('Yeni veya Tedavi Güncellenmiş herhangi bir order bulunamamıştır. Lütfen kontrol ediniz.');
            } else {
                TTVisual.InfoBox.Alert('Lütfen ilaç seçimi yapınız!');
            }
            this.loadingVisible = false;
            return;
        }
        //this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.filter(x => x.SelectionCheck == true);
        if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.filter(x => x.DoseAmount == null || x.HospitalTimeSchedule == null
            || x.HospitalTimeScheduleObjectID == null || x.HospitalTimeScheduleObjectID == Guid.Empty || x.Day == null || x.DrugUsageType == null).length > 0) {
            TTVisual.InfoBox.Alert('Doz Aralığı, Doz Miktarı, Gün, Kullanım Şekli değerleri boş olamaz! Lütfen Direktifleri kontrol ediniz.');
            this.loadingVisible = false;
            return;
        }

        if (this.isVademecumEntegrasyon) {
            let result = await this.showDrugInteractions();
            if (result === DialogResult.Cancel) {
                TTVisual.InfoBox.Alert(i18n("M16907", "İşlemden vazgeçildi"));
                this.loadingVisible = false;
                return;
            }
        } else {
            let result = await this.showAtlasDrugInteractions();
            if (result === DialogResult.Cancel) {
                TTVisual.InfoBox.Alert(i18n("M16907", "İşlemden vazgeçildi"));
                this.loadingVisible = false;
                return;
            }
        }

        if (this.isHimssRequired)
            await this.signService.showLoginModal();

        this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.forEach(item => {
            if (item.ParentDrugOrderObjectID == null) {
                let findOldDrugOrder: DrugOrderIntroductionGridViewModel = this.refreshGridDataSrouce.find(x => x.Material.drugObjectId === item.Material.drugObjectId
                    && x.HospitalTimeScheduleObjectID === item.HospitalTimeScheduleObjectID
                    && x.DoseAmount === item.DoseAmount
                    && x.CaseOfNeed === item.CaseOfNeed);

                if (findOldDrugOrder != null) {
                    if (findOldDrugOrder.ParentDrugOrderObjectID != null) {
                        item.ParentDrugOrderObjectID = findOldDrugOrder.ParentDrugOrderObjectID;
                    } else {
                        item.ParentDrugOrderObjectID = findOldDrugOrder.LastDrugOrderObjectID;
                    }
                }
            }
            let changeDetail: Array<DrugOrderTimceSchedule> = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID === item.ID).DrugOrderIntroDuctionTimeSchedule;
            item.DrugOrderIntroDuctionTimeSchedule.forEach(detailItem => {
                detailItem.Time = changeDetail.find(x => x.DetailNo === detailItem.DetailNo).Time;
            });
        });

        return new Promise<boolean>((resolve, reject) => {
            this.http.post<SaveDrugOrder_Output>(this.url + '/SaveDrugOrder', this.drugOrderIntroductionFormViewModel).then(res => {
                if (res.IsSuccess) {
                    ServiceLocator.MessageService.showSuccess('Direktifler başarılı olarak kayıt edildi.');
                    //this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel = res.GridViewModel;
                    this.ngOnInit();
                    // let tempArray: Array<DrugOrderIntroductionGridViewModel> = new Array<DrugOrderIntroductionGridViewModel>();

                    // tempArray = <Array<DrugOrderIntroductionGridViewModel>>AtlasObjectCloner.clone(res.GridViewModel);

                    // this.refreshGridDataSrouce = tempArray;
                    // this.filterOrders(this.SelectedOrderStatus);
                    this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = new Array<DrugOrderIntroductionGridViewModel>();
                    this.loadingVisible = false;
                    resolve(true);
                }
                else {
                    //TODO: Hata mesajı SaveDrugOrder_Output class'ı içerisinde ErrorMessage property'sine doldurulup gösterilecek.
                    ServiceLocator.MessageService.showError('Direktifler kayıt edilemedi!');
                    this.loadingVisible = false;
                }
            }).catch(error => {
                if (typeof error === 'string')
                    TTVisual.InfoBox.Alert("HATA", error, MessageIconEnum.ErrorMessage);
                reject(error);
                this.loadingVisible = false;
            });
        });
    }

    public SaveDrugOrders() {
        setTimeout(() => {
            this.SaveDrugOrderMethod();
        }, 500);
    }

    public async onValueChangedOrderStatus(event: any) {
        if (event.value !== this.oldOrderstatus) {
            if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length > 0) {
                let result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), " ", "Yeni direktifler silinecektir. İşleme devam etmek istiyormusunuz ?");
                //TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), " ", "Yeni direktifler silinecektir. İşleme devam etmek istiyormusunuz ?").then(res => {
                if (result === 'E') {
                    this.filterOrders(event.value);
                    this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = new Array<DrugOrderIntroductionGridViewModel>();
                } else {
                    this.eventRadioGroup.value = event.previousValue;
                }
            } else {
                this.filterOrders(event.value);
            }
        }
    }

    public filterOrders(selectedOrderStatus: string) {
        if (selectedOrderStatus === 'Tümü') {
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel = this.refreshGridDataSrouce;
        } else if (selectedOrderStatus === 'Devam Eden Tedaviler') {
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel = this.refreshGridDataSrouce.filter(x => x.Status === DrugOrderStatusEnum.Complated || x.Status === DrugOrderStatusEnum.Continue || x.Status === DrugOrderStatusEnum.Approve);
        } else if (selectedOrderStatus === 'Durdurulan & İptal Edilenler') {
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel = this.refreshGridDataSrouce.filter(x => x.Status === DrugOrderStatusEnum.Cancel || x.Status === DrugOrderStatusEnum.Stopped || x.Status === DrugOrderStatusEnum.OutOfTreatment);
        }
        this.oldOrderstatus = selectedOrderStatus;
    }

    public showDrugInteractions(): Promise<DialogResult> {

        return new Promise<DialogResult>((resolve, reject) => {

            let that = this;
            let productList: Array<Guid> = new Array<Guid>();
            for (let detailItem of that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.map(x => x.Material)) {
                productList.push(new Guid(detailItem.drugObjectId));
            }

            if (productList.length > 0) {
                let inputDvo = new QueryVademecumInteractionDVONew();
                inputDvo.prdList = productList;
                if (that._DrugOrderIntroduction.Episode.ObjectID != null)
                    inputDvo.episodeID = that._DrugOrderIntroduction.Episode.ObjectID.toString();
                else
                    inputDvo.episodeID = that._DrugOrderIntroduction.Episode.toString();
                let fullApiUrl: string = 'api/LogisticDashboard/QueryVademecumNew';
                this.http.post(fullApiUrl, inputDvo)
                    .then((res: string) => {
                        let componentInfo = new DynamicComponentInfo();
                        componentInfo.ComponentName = 'DrugInteractionComponent';
                        componentInfo.ModuleName = 'LogisticFormsModule';
                        componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                        componentInfo.InputParam = res;

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

    public showAtlasDrugInteractions(): Promise<DialogResult> {

        return new Promise<DialogResult>((resolve, reject) => {

            let that = this;
            let productList: Array<Guid> = new Array<Guid>();
            for (let detailItem of that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.map(x => x.Material)) {
                productList.push(new Guid(detailItem.drugObjectId));
            }

            if (productList.length > 0) {
                let inputDvo = new PrepareInteraction_Input();
                inputDvo.drugList = productList;
                if (that._DrugOrderIntroduction.Episode.ObjectID != null)
                    inputDvo.episodeID = that._DrugOrderIntroduction.Episode.ObjectID;
                else
                    inputDvo.episodeID = new Guid(that._DrugOrderIntroduction.Episode.ToString());
                let fullApiUrl: string = 'api/DrugOrderIntroductionService/PrepareInteraction';
                this.http.post(fullApiUrl, inputDvo)
                    .then((res: PrepareInteraction_Output) => {
                        if (res.drugDrugInteractions.length > 0 || res.drugFoodInteractions.length > 0) {
                            let componentInfo = new DynamicComponentInfo();
                            componentInfo.ComponentName = 'DrugAtlasInteractionComponent';
                            componentInfo.ModuleName = 'LogisticFormsModule';
                            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                            componentInfo.InputParam = res;

                            let modalInfo: ModalInfo = new ModalInfo();
                            modalInfo.Title = 'UYARI';
                            modalInfo.Width = 1200;
                            modalInfo.Height = 800;

                            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                            let result2 = modalService.create(componentInfo, modalInfo);
                            result2.then(res2 => {
                                resolve(res2.Result);
                            });
                        } else {
                            resolve(DialogResult.OK);
                        }
                    })
                    .catch(error => {
                        TTVisual.InfoBox.Alert(error);
                        reject(error);
                    });
            }
        });

    }

    public async StopDrugOrders() {
        let input: StopDrugOrders_Input = new StopDrugOrders_Input();
        let selectedItemsToStopped = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.filter(x => x.Status == DrugOrderStatusEnum.Continue && x.SelectionCheck == true);
        if (selectedItemsToStopped.length > 0) {
            let message = selectedItemsToStopped.map(x => x.Material.name).join(', ');
            message += '</br>İlaçlara ait Direktifler Durdurulacaktır! Devam etmek istiyor musunuz?';
            let result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M20924", "Direktif Durdur"),
                message);
            if (result === 'T') {
                input.DrugOrderObjectIDList = selectedItemsToStopped.map(x => x.LastDrugOrderObjectID);
                this.http.post<StopDrugOrders_Output>(this.url + '/StopDrugOrders', input).then(res => {
                    if (res.Result) {
                        res.details.forEach(item => {
                            selectedItemsToStopped.find(x => x.LastDrugOrderObjectID === item.objectId).Status = item.status;
                        });
                        TTVisual.InfoBox.Alert(res.ResultMessage);
                        this.filterOrders(this.SelectedOrderStatus);
                    }
                    else
                        TTVisual.InfoBox.Alert(res.ResultMessage);

                });
            }
        }
        else
            TTVisual.InfoBox.Alert('Sadece Devam Ediyor durumundaki direktfiler durdurulabilir!');
    }









    public async OutOfTreatmentDrugOrders() {
        let input: StopDrugOrders_Input = new StopDrugOrders_Input();
        let selectedItemsToOutOfTreatment = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.filter(x => x.Status == DrugOrderStatusEnum.Complated && x.SelectionCheck == true);
        if (selectedItemsToOutOfTreatment.length > 0) {
            let message = selectedItemsToOutOfTreatment.map(x => x.Material.name).join(', ');
            message += '</br>İlaçlara ait Direktifler Tedavi Dışı yapılacaktır! Devam etmek istiyor musunuz?';
            let result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Tedavi Dışı',
                message);
            if (result === 'T') {
                input.DrugOrderObjectIDList = selectedItemsToOutOfTreatment.map(x => x.LastDrugOrderObjectID);
                this.http.post<StopDrugOrders_Output>(this.url + '/OutOfTreatmentDrugOrders', input).then(res => {
                    if (res.Result) {
                        res.details.forEach(item => {
                            selectedItemsToOutOfTreatment.find(x => x.LastDrugOrderObjectID === item.objectId).Status = item.status;
                        });
                        TTVisual.InfoBox.Alert(res.ResultMessage);
                        this.filterOrders(this.SelectedOrderStatus);
                    }
                    else
                        TTVisual.InfoBox.Alert(res.ResultMessage);

                });
            }
        }
        else
            TTVisual.InfoBox.Alert('Sadece Tamamlandı durumundaki direktfiler tedavi dışı yapılabilinir!');
    }

    //İlaç arama textbox valuechanged event'i
    public async onSearchValueChanged(event) {
        let drugs: Array<DrugInfo>;
        if (this.isFavoriteDrugList === false) {
            if (event.value.length === 0) {
                if (this.isInheldDrugList === false) {
                    this.drugSource = new DataSource({
                    });
                    //this.CloseSearchList();
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

    //Favori ilaçlar checkbox valuechanged event'i
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

    //Mevcudu olan ilaçlar checkbox valuechanged event'i
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

    public async onIngeridentsValueChanged(event) {
        if (this.selectedActiveIngeridents.length > 0) {
            if (this.isInheldDrugList === true) {
                let drugs: Array<DrugInfo> = await DrugOrderIntroductionService.SearchDrug(this.searchText, this.isInheldDrugList, this.selectedActiveIngeridents);
                this.OpenSearchList();
                this.drugSource = new DataSource({
                    store: drugs,
                });
            } else {
                this.isInheldDrugList = true;
            }
        }
    }

    public checkEquivalent(equivalentDrugs: Array<DrugInfo>): Promise<DrugInfo> {
        return new Promise<DrugInfo>((resolve, reject) => {
            if (equivalentDrugs.length > 0) {
                let drugObjectid: any = null;
                this.showEquivalentDrug(equivalentDrugs).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        resolve(result.Param as DrugInfo);
                    } else {
                        resolve(null);
                    }
                }).catch(err => reject(err));
            } else {
                resolve(null);
                //TTVisual.InfoBox.Alert('İlacın mevcut eş değeri bulunmamaktadır!');
            }
        });
    }

    private showEquivalentDrug(data: Array<DrugInfo>): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugEquivalentComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13913", "Eşdeğer İlaçlar");
            modalInfo.Width = 600;
            modalInfo.Height = 400;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    //İlaç arama: İlaç seçilen listenin onItemClick event'inde çalışan fonksiyon
    public async drugListOnItemClick(event) {

        let infoDrug: DrugInfo = event.itemData;
        await this.addDrug(infoDrug);

        /*if (this.OrderRestDayCount === 1) {

            let nowDate = new Date(Date.now());
            let day: number = nowDate.getDay();
            if (day === 5 && this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length === 0 && this.drugListShowSelectionControl === false && this.isFriday === false) {
                let isFriday = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                    'Bugün günlerden Cuma 3 günlük order vermek istiyor musunuz?');
                if (isFriday === 'E') {
                    this.isFriday = true;
                }
            }
        } else {
            if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length === 0 && this.drugListShowSelectionControl === false && this.isFriday === false) {
                let restDay = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                    this.OrderRestDayDescription + ' nedeniyle ' + this.OrderRestDayCount.toString() + ' günlük order vermek istiyor musunuz?');
                if (restDay === 'E') {
                    this.isFriday = true;
                }
            }
        }

        if (this.isCV === true) {
            let isCVQuestion = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'CV',
                'Bugün bu hastaya daha önce order verilmiş. Bu order CV mi olacak ?');
            if (isCVQuestion === 'E') {
                this.isCVOrder = true;
            }
        }
        let infoDrug: DrugInfo = event.itemData;
        let isHuman = infoDrug.DrugSpecifications.find(x => x.Value === DrugSpecificationEnum.HumanAlbumin);
        if (isHuman != null) {
            if (this.patient.IsLiverTransplant === false) {
                let restDay = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Karaciğer Nakli',
                    'Hastaya daha önce Karaciğer Nakli yapıldı mı ?');
                if (restDay === 'H') {
                    if (this.patient.IsRequestAlbuminExamination === false) {
                        TTVisual.InfoBox.Alert('Hastanın herhangi bir istenmiş veya tamamlanmış Albumin Tetkiği bulunmamaktadır. Bu ilacı isteyemezsiniz.');
                        return;
                    } else {
                        if (this.patient.ResultAlbuminExamination === 1) {
                            TTVisual.InfoBox.Alert('Hastanın Albumin Tetkiği sonucu 2,5 dan yüksektir. Bu ilacı isteyemezsiniz.');
                            return;
                        }
                    }
                }
            }
        }

        let drugReportNo: string = '0';
        if (event.itemData.DrugReportType === DrugReportType.RaporlaOdenir && this.patient.IsSGK === true) {
            await new Promise<boolean>((resolve, reject) => {
                let input: GetDrugReportNo_Input = new GetDrugReportNo_Input();
                input.DrugID = event.itemData.drugObjectId;
                if (this.Episode.ObjectID != null)
                    input.EpisodeID = this.Episode.ObjectID;
                else
                    input.EpisodeID = new Guid(this.Episode.toString());
                this.http.post<string>(this.url + '/GetDrugReportNo', input).then(result => {
                    drugReportNo = result;
                    event.itemData.MedulaReportNo = result;
                    resolve(true);
                }).catch(err => {
                    TTVisual.InfoBox.Alert(err);
                    reject(err);
                    return;
                });
            });

            if (drugReportNo === '0') {
                TTVisual.InfoBox.Alert('Hastanın herhangi bir raporu bulunamadı.Lütfen etken maddeye uygun rapor yazınız.');
                return;
            }
        }


        if (event.itemData.DrugDescription != null && event.itemData.DrugDescription !== "" && this.drugListShowSelectionControl === true) {
            TTVisual.InfoBox.Alert(event.itemData.DrugDescription, MessageIconEnum.ErrorMessage);
        }

        if (this.patientAllergicDrug.length > 0) {
            for (let drugActiveIngredient of event.itemData.ActiveIngeridents) {
                if (this.patientAllergicDrug.find(x => x === drugActiveIngredient.Objectid) != null) {
                    TTVisual.InfoBox.Alert('Hastanın ' + drugActiveIngredient.Name + ' etken maddesine allerjisi vardır. Bu ilacı yazamazsınız.', MessageIconEnum.ErrorMessage);
                    return;
                }
            }
        }

        //if (this.isHimssRequired)
        //    await this.signService.showLoginModal();
        if (event.itemData !== null) {

            //this.drugName = event.itemData.barcode + " " + event.itemData.name;
            this.patientOwnDrugAmount = <number>event.itemData.inheldStatus;
            // this.selectedMaterial = new Material();
            // this.selectedMaterial.Name = event.itemData.name;
            // this.selectedMaterial.ObjectID = event.itemData.drugObjectId;
            if (this.selectedMaterials.find(x => x.drugObjectId == event.itemData.drugObjectId) == null) {
                if (!Number.isNaN(parseInt(event.itemData.inheldStatus)) && parseInt(event.itemData.inheldStatus) == 0) {
                    let material = new DrugDefinition();
                    material.ObjectID = new Guid(event.itemData.drugObjectId);
                    let equivalentDrugs: Array<DrugInfo> = await DrugOrderIntroductionService.GetEquivalentDrug(material, 1);
                    let equivalentDrug: DrugInfo = await this.checkEquivalent(equivalentDrugs);
                    if (equivalentDrug !== null) {
                        this.selectedMaterials.push(equivalentDrug as DrugInfo);
                    }
                    else {
                        let patientOwnDrug = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Hastanın İlacı',
                            'Bu ilacı "Hastanın Yanında Getirdiği" ilaç olarak order etmek istiyormusunuz? ');
                        if (patientOwnDrug === 'E') {
                            this.selectedMaterials.push(event.itemData);
                            this.isPatientOwnDrug = true;
                        } else {
                            return;
                        }
                        //TTVisual.InfoBox.Alert('İlacın mevcudu bulunmamaktadır. Direktif veremezsiniz!');
                    }
                }
                else
                    this.selectedMaterials.push(event.itemData);
            }
            if (!this.drugListShowSelectionControl) {
                //TODO: Default time schedule tanımlama imkanı sağlanacak ve doz aralığına o set edilecek.
                if (this.timeScheduleDataSource != null && this.timeScheduleDataSource.length > 0) {
                    //this.selectedTimeSchedule = this.timeScheduleDataSource[0].ObjectID;
                }
                //Çoklu seçim aktif değil ise kullanım şeklini otomatik set et.
                this.selectedDrugUsageType = event.itemData.drugUsageTypeEnum;
                //this.doseAmount = 1;
                this.CreateDrugOrderGridModel().then(x => {
                    this.CloseSearchList();
                });
            }
            else {

            }

            //TODO: Burası kontrol edilecek.
            if (event.itemData.inheldStatus === 'Var') {
                this.isInheld = true;
            } else if (event.itemData.inheldStatus === 'Yok') {
                this.isInheld = false;
            } else if (event.itemData.inheldStatus === '0') {
                this.isInheld = false;
            } else {
                this.isInheld = true;
            }

            if (this.SelectedOrderStatus !== 'Devam Eden Tedaviler') {
                this.SelectedOrderStatus = 'Devam Eden Tedaviler';
                this.filterOrders(this.SelectedOrderStatus);
            }

        } else {
            this._DrugOrderIntroduction.DrugName = '';
            this._DrugOrderIntroduction.DrugObjectID = null;
        }*/
    }

    public async onMultiSelectTagSelectionChanged(event: any) {
        if (event.addedItems.length > 0 && this.drugListShowSelectionControl) {
            let selectedItem: DrugInfo = event.addedItems[0];
            let drugOrderIntroductionGridViewModel = new DrugOrderIntroductionGridViewModel();
            drugOrderIntroductionGridViewModel.ID = Guid.newGuid().id;
            drugOrderIntroductionGridViewModel.PlannedStartTime = this.plannedStartTime;
            drugOrderIntroductionGridViewModel.Day = this.day;
            drugOrderIntroductionGridViewModel.PlannedStartTime = this.plannedStartTime;

            drugOrderIntroductionGridViewModel.Material = selectedItem;
            if (this.day == null) {
                if (this.isFriday) {
                    if (this.OrderRestDayCount === 1) {
                        drugOrderIntroductionGridViewModel.Day = 3;
                    } else {
                        drugOrderIntroductionGridViewModel.Day = this.OrderRestDayCount;
                    }
                } else {
                    drugOrderIntroductionGridViewModel.Day = 1;
                }
            } else {
                drugOrderIntroductionGridViewModel.Day = this.day;
            }
            drugOrderIntroductionGridViewModel.Material.ActiveIngeridents = selectedItem.ActiveIngeridents;
            //Sunucuda gerekli.
            if (this.selectedTimeSchedule != null) {
                let timeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID == this.selectedTimeSchedule);
                drugOrderIntroductionGridViewModel.HospitalTimeSchedule = timeSchedule;
                drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID = this.selectedTimeSchedule;
                drugOrderIntroductionGridViewModel.HospitalTimeSchedule = timeSchedule;
                drugOrderIntroductionGridViewModel.HospitalTimeSchedule = timeSchedule;
            }
            if (this.doseAmount == null) {
                drugOrderIntroductionGridViewModel.DoseAmount = 1;
            } else {
                drugOrderIntroductionGridViewModel.DoseAmount = this.doseAmount;
            }

            if (selectedItem.drugUsageTypeEnum == null) {
                let drugUsageList: Array<ComboListItem> = [];
                for (let i of this.DrugUsageTypeDataSource) {
                    drugUsageList.push(new ComboListItem(i.code, i.description));
                }
                let usageType: ComboListItem = await InputForm.GetValueListItem("Kullanım Şekli Seçiniz", drugUsageList);
                if (usageType != null) {
                    drugOrderIntroductionGridViewModel.DrugUsageType = <DrugUsageTypeEnum>usageType.DataValue;
                }
            } else {
                drugOrderIntroductionGridViewModel.DrugUsageType = <DrugUsageTypeEnum>selectedItem.drugUsageTypeEnum;
            }

            drugOrderIntroductionGridViewModel.DrugOrderType = this.selectedDrugOrderType;
            drugOrderIntroductionGridViewModel.PatientOwnDrug = this.isPatientOwnDrug;
            drugOrderIntroductionGridViewModel.IsImmediate = this.isImmediate;
            drugOrderIntroductionGridViewModel.CaseOfNeed = this.caseOfNeed;
            drugOrderIntroductionGridViewModel.UsageNote = this.usageNote;
            drugOrderIntroductionGridViewModel.SelectionCheck = true;
            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.New;
            this.MultiSelectGridDataSource.push(drugOrderIntroductionGridViewModel);
        }
    }


    //İlaç Arama: Hastanın İlaçları checkbox valuechanged event
    public onOwnDrugValueChanged(event: any) {
        //this.searchText = '';
        if (event.value === true) {
            this.drugSource = new DataSource({
                store: this.patientOwnDrugs,
                searchOperation: 'contains',
                searchExpr: 'name'
            });
            this._DrugOrderIntroduction.PatientOwnDrug = true;
            this.isFavoriteDrugList = false;
            this.isInheldDrugList = false;
            this.isPatientOwnDrug = true;
            this.OpenSearchList();
        } else {
            if (this.isFavoriteDrugList === false) {
                this.drugSource = new DataSource({
                });
            }
            this.isPatientOwnDrug = false;
            this.CloseSearchList();
            this._DrugOrderIntroduction.PatientOwnDrug = false;
        }
    }

    //İlaç arama bölümündeki icon lar için
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

    public GetDrugOrderIntroductionGridViewModelDTO(): Array<DrugOrderIntroductionGridViewModel> {
        return this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO;
    }


    public async RepeatDrugOrders() {
        this.loadingVisible = true;
        let that = this;

        let repeatedDrugOrderList: Array<DrugOrderIntroductionGridViewModel> = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.filter(x => x.SelectionCheck === true &&
            (x.Status === DrugOrderStatusEnum.Stopped || x.Status === DrugOrderStatusEnum.Cancel || x.Status === DrugOrderStatusEnum.OutOfTreatment));
        let errorMessage = '';
        let warningMessage = '';
        //Bu ilaçlar daha önce tekrarlanmış mı?
        let continueRepeatDrugOrderList: Array<DrugOrderIntroductionGridViewModel> = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.filter(x => x.SelectionCheck === true && (x.Status === DrugOrderStatusEnum.Continue || x.Status === DrugOrderStatusEnum.Complated));

        for (let continueOrder of continueRepeatDrugOrderList) {
            let firstTimeSchedule: DrugOrderTimceSchedule = continueOrder.DrugOrderIntroDuctionTimeSchedule.find(x => x.DetailNo === 1);
            if (firstTimeSchedule != null) {
                let firstTimeDay: Date = new Date(firstTimeSchedule.Time.getFullYear(), firstTimeSchedule.Time.getMonth(), firstTimeSchedule.Time.getDate(), 0, 0, 0);
                let nowDate = new Date(Date.now());
                let newOrderDate: Date = new Date(nowDate.getFullYear(), nowDate.getMonth(), nowDate.getDate(), 0, 0, 0);
                if (continueOrder.HospitalTimeScheduleObjectID.toString() === '5c6ca805-ad11-4b93-b804-83be6ff0582c') {
                    newOrderDate = newOrderDate.AddDays(1);
                }
                if (newOrderDate <= firstTimeDay) {
                    errorMessage += continueOrder.Material.name + ', ';
                } else {
                    repeatedDrugOrderList.push(continueOrder);
                }
            }
        }

        if (!String.isNullOrEmpty(errorMessage)) {
            errorMessage += ' isimli ilaç(lar) tedavi güncellemeye uygun değil! Lütfen seçilen ilacın/ilaçların seçimini kaldırıp güncelleme işlemini yeniden yapınız.';
            TTVisual.InfoBox.Alert(errorMessage, MessageIconEnum.ErrorMessage);
            this.loadingVisible = false;
            return;
        }

        if (repeatedDrugOrderList.length === 0) {
            TTVisual.InfoBox.Alert('Lütfen tekrar etmek istediğiniz ilaçları seçiniz! Tekrar edilebilir ilaçlar bugün order edilmeye uygun Tamamlandı, Devam Ediyor durumunda veya Durduruldu durumunda olmalıdır.');
            this.loadingVisible = false;
            return;
        }

        repeatedDrugOrderList.forEach(item => {
            if (item.PatientOwnDrug) {
                if (this.isHimssRequired) {
                    if (item.Material.inheldStatus != null && item.Material.inheldStatus === "0") {
                        errorMessage += item.Material.name + ', ';
                    }
                }
            } else {
                if (item.Material.inheldStatus != null && item.Material.inheldStatus === "0") {
                    errorMessage += item.Material.name + ', ';
                }
            }

        });

        for (let item of repeatedDrugOrderList) {
            if (item.Material.drugType) {
                let rptDayOutput: ControlRepeatDay_Output = await DrugOrderIntroductionService.ControlRepeatDay(new Guid(item.Material.drugObjectId), this.Episode, new Date(Date.now()));
                if (rptDayOutput.isWarning === true) {
                    warningMessage += rptDayOutput.warningMessage + ', ';
                    item.RepeatDayWarning = rptDayOutput.warningMessage;
                }
            }
        }

        if (!String.isNullOrEmpty(warningMessage)) {
            let rptDay = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                warningMessage + ' Devam etmek istiyor musunuz ?');
            if (rptDay === 'H') {
                this.loadingVisible = false;
                return;
            }
        }

        if (!String.isNullOrEmpty(errorMessage)) {
            errorMessage += ' isimli ilaç(lar) mevcudu bulunmadığı için tedavi güncelleyemezsiniz.';
            TTVisual.InfoBox.Alert(errorMessage, MessageIconEnum.ErrorMessage);
            this.loadingVisible = false;
            return;
        }

        repeatedDrugOrderList.map((x1, x2) => {
            if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.find(x => x.Material.drugObjectId == x1.Material.drugObjectId) != null)
                errorMessage += x1.Material.name + ', ';
        });
        if (!String.isNullOrEmpty(errorMessage)) {
            errorMessage += ' isimli ilaç(lar) daha önce tekrarlanmış! Lütfen seçilen ilacın/ilaçların seçimini kaldırıp güncelleme işlemini yeniden yapınız.';
            TTVisual.InfoBox.Alert(errorMessage, MessageIconEnum.ErrorMessage);
            this.loadingVisible = false;
            return;
        }

        if (this.OrderRestDayCount === 1) {
            let nowDate = new Date(Date.now());
            let day: number = nowDate.getDay();
            if (day === 5 && this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length === 0 && this.isFriday === false) {
                let isFriday = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                    'Bugün günlerden Cuma 3 günlük order vermek istiyor musunuz?');
                if (isFriday === 'E') {
                    this.isFriday = true;
                }
            }
        } else {
            if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length === 0 && this.isFriday === false) {
                let restDay = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                    this.OrderRestDayDescription + ' nedeniyle ' + this.OrderRestDayCount.toString() + ' günlük order vermek istiyor musunuz?');
                if (restDay === 'E') {
                    this.isFriday = true;
                }
            }
        }

        repeatedDrugOrderList.forEach(async element => {
            await this.CreateDrugOrderGridModelForRepeat(element as DrugOrderIntroductionGridViewModel);

            let drugOrderIntroductionDTO: DrugOrderIntroductionGridViewModel = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.find(x => x.ID === element.ID);
            drugOrderIntroductionDTO.Day = element.Day;
            drugOrderIntroductionDTO.DrugOrderIntroDuctionTimeSchedule = element.DrugOrderIntroDuctionTimeSchedule;
            if (drugOrderIntroductionDTO.Material.InfectionApproval === true) {
                let pTime = drugOrderIntroductionDTO.PlannedEndTime;
                if (drugOrderIntroductionDTO.Day == 1)
                    pTime = drugOrderIntroductionDTO.PlannedStartTime;
                let activeInfectionCom = this.patient.ActiveInfectionCommiteeApproves.find(x => x.MaterialID.toString() === drugOrderIntroductionDTO.Material.drugObjectId);
                if (activeInfectionCom != null) {
                    if (new Date(pTime) > new Date(activeInfectionCom.EndDate)) {
                        TTVisual.InfoBox.Alert(drugOrderIntroductionDTO.Material.name + ' İlaç Enfeksiyon Komitesi Onayına Gidecektir!');
                    }
                } else {
                    TTVisual.InfoBox.Alert(drugOrderIntroductionDTO.Material.name + ' Enfeksiyon Komitesi Onayına Gidecektir!');
                }
            }
            //this.FindFirstDetailTime(element.HospitalTimeSchedule, element.PlannedStartTime);
        });



        let drugOrderAddRequirement = new DrugOrderAddRequirement(this.http, null, this.GetDrugOrderIntroductionGridViewModelDTO(),
            this.timeScheduleDataSource, this.selectedTimeSchedule, this.plannedStartTime, this.drugOrderMinDate, this.patient, this.doseAmount, this.day, this._episode, this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel, false);
        let requirementResult = drugOrderAddRequirement.ExecuteRequirements();
        if (!requirementResult.IsSuccess) {
            TTVisual.InfoBox.Alert(requirementResult.resultMessage);
            repeatedDrugOrderList.forEach(element => {
                this.UndoDrugOrder(element as DrugOrderIntroductionGridViewModel);
                if (that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.Material.drugObjectId === element.Material.drugObjectId && x.Status === DrugOrderStatusEnum.New) != null) {
                    that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel = that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.filter(x => x.Material.drugObjectId !== element.Material.drugObjectId && x.Status !== DrugOrderStatusEnum.New);
                }
                if (that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.find(x => x.Material.drugObjectId === element.Material.drugObjectId && x.Status === DrugOrderStatusEnum.New) != null) {
                    that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.filter(x => x.Material.drugObjectId !== element.Material.drugObjectId && x.Status !== DrugOrderStatusEnum.New);
                }
                //this.FindFirstDetailTime(element.HospitalTimeSchedule, element.PlannedStartTime);
            });
            return;
        }
        let drugOrderAddRequirementWithApproval = new DrugOrderAddRequirement(this.http, null, this.GetDrugOrderIntroductionGridViewModelDTO(), this.timeScheduleDataSource, this.selectedTimeSchedule, this.plannedStartTime, this.drugOrderMinDate,
            this.patient, this.doseAmount, this.day, this._episode, this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel, false);
        let requirementResultWithApproval = await drugOrderAddRequirementWithApproval.ExecuteRequirementsWithApproval();
        if (!requirementResultWithApproval.IsSuccess) {
            repeatedDrugOrderList.forEach(element => {
                this.UndoDrugOrder(element as DrugOrderIntroductionGridViewModel);
                that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.forEach(innerElement => {
                    if (innerElement.Material.drugObjectId == element.Material.drugObjectId && innerElement.Status == DrugOrderStatusEnum.New)
                        that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel = that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.filter(x => x.ID != innerElement.ID);

                });
                that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.forEach(innerElement => {
                    if (innerElement.Material.drugObjectId == element.Material.drugObjectId && innerElement.Status == DrugOrderStatusEnum.New)
                        that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = that.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.filter(x => x.ID != innerElement.ID);

                });

                //this.FindFirstDetailTime(element.HospitalTimeSchedule, element.PlannedStartTime);
            });
        }
        this.loadingVisible = false;
        //}
        //else {
        // errorMessage += ' isimli ilaç(lar) daha önce tekrarlanmış! Lütfen seçilen ilacın/ilaçların seçimini kaldırıp güncelleme işlemini yeniden yapınız.';
        // TTVisual.InfoBox.Alert(errorMessage, MessageIconEnum.ErrorMessage);
        //}
    }

    public async CreateDrugOrderGridModelForRepeat(drugOrderIntroductionGridViewModel: DrugOrderIntroductionGridViewModel) {
        //let detailTime = this.FindFirstDetailTimeForRepeat(drugOrderIntroductionGridViewModel);
        let newGridViewModel: DrugOrderIntroductionGridViewModel = new DrugOrderIntroductionGridViewModel();

        let keys = Object.keys(drugOrderIntroductionGridViewModel);
        keys.forEach(key => {
            newGridViewModel[key] = drugOrderIntroductionGridViewModel[key];
        });

        newGridViewModel.IsCV = false;
        drugOrderIntroductionGridViewModel.IsCV = false;

        /*if (detailTime == null) {
            newGridViewModel.Status = DrugOrderStatusEnum.New;
            //this.selectedMasterGridRowKeys = this.selectedMasterGridRowKeys.filter(x => x != drugOrderIntroductionGridViewModel.ID);
            newGridViewModel.ID = Guid.newGuid().id;
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.push(newGridViewModel);
            this.selectedMasterGridRowKeys.push(newGridViewModel.ID);
            this.selectedMasterGridRowKeys = this.selectedMasterGridRowKeys.filter(x => x != drugOrderIntroductionGridViewModel.ID);
            this.orderMasterGrid.instance.selectRows([newGridViewModel.ID], true);
            // this.orderMasterGrid.instance.deselectRows([drugOrderIntroductionGridViewModel.ID]);
        }
        else {*/

        if (this.isFriday) {
            if (this.OrderRestDayCount === 1) {
                newGridViewModel.Day = 3;
                drugOrderIntroductionGridViewModel.Day = 3;
            } else {
                newGridViewModel.Day = this.OrderRestDayCount;
                drugOrderIntroductionGridViewModel.Day = this.OrderRestDayCount;
            }
        } else {
            newGridViewModel.Day = 1;
            drugOrderIntroductionGridViewModel.Day = 1;
        }

        if (drugOrderIntroductionGridViewModel.ParentDrugOrderObjectID != null)
            newGridViewModel.ParentDrugOrderObjectID = drugOrderIntroductionGridViewModel.ParentDrugOrderObjectID;
        else
            newGridViewModel.ParentDrugOrderObjectID = drugOrderIntroductionGridViewModel.LastDrugOrderObjectID;
        drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.Continue;
        this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.push(newGridViewModel);
        await this.CreateDrugOrderIntroductionTimeModel(drugOrderIntroductionGridViewModel);

        if (drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.length === newGridViewModel.DrugOrderIntroDuctionTimeSchedule.length) {
            newGridViewModel.DrugOrderIntroDuctionTimeSchedule.forEach(element => {
                let time1: DrugOrderTimceSchedule = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.find(x => x.DetailNo === element.DetailNo)
                if (time1 != null) {
                    time1.Time = new Date(time1.Time.getFullYear(), time1.Time.getMonth(), time1.Time.getDate(), element.Time.getHours(), element.Time.getMinutes(), 0);

                    if (time1.DoseAmount !== element.DoseAmount) {
                        time1.DoseAmount = element.DoseAmount;
                    }
                }
            });
        } else {
            let repeatCount: number = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.length / newGridViewModel.DrugOrderIntroDuctionTimeSchedule.length;
            for (let index = 0; index < repeatCount; index++) {
                let orderNo: number = repeatCount * index;
                newGridViewModel.DrugOrderIntroDuctionTimeSchedule.forEach(element => {
                    let time1: DrugOrderTimceSchedule = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.find(x => x.DetailNo === element.DetailNo + orderNo)
                    if (time1 != null) {
                        time1.Time = new Date(time1.Time.getFullYear(), time1.Time.getMonth(), time1.Time.getDate(), element.Time.getHours(), element.Time.getMinutes(), 0);

                        if (time1.DoseAmount !== element.DoseAmount) {
                            time1.DoseAmount = element.DoseAmount;
                        }
                    }
                });
            }
        }
        let detailCount: number = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.length;
        drugOrderIntroductionGridViewModel.PlannedEndTime = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule[detailCount - 1].Time;

        // }

        await this.CreateDrugOrderIntroductionTimeModel(newGridViewModel);

        if (drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.length === newGridViewModel.DrugOrderIntroDuctionTimeSchedule.length) {
            drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.forEach(element2 => {
                let time2: DrugOrderTimceSchedule = newGridViewModel.DrugOrderIntroDuctionTimeSchedule.find(x => x.DetailNo === element2.DetailNo)
                if (time2 != null) {
                    time2.Time = new Date(time2.Time.getFullYear(), time2.Time.getMonth(), time2.Time.getDate(), element2.Time.getHours(), element2.Time.getMinutes(), 0);

                    if (time2.DoseAmount !== element2.DoseAmount) {
                        time2.DoseAmount = element2.DoseAmount;
                    }
                }
            });
        } else {
            let repeatCount: number = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.length / newGridViewModel.DrugOrderIntroDuctionTimeSchedule.length;
            for (let index = 0; index < repeatCount; index++) {
                let orderNo: number = repeatCount * index;
                drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.forEach(element2 => {
                    let time2: DrugOrderTimceSchedule = newGridViewModel.DrugOrderIntroDuctionTimeSchedule.find(x => x.DetailNo === element2.DetailNo + orderNo)
                    if (time2 != null) {
                        time2.Time = new Date(time2.Time.getFullYear(), time2.Time.getMonth(), time2.Time.getDate(), element2.Time.getHours(), element2.Time.getMinutes(), 0);

                        if (time2.DoseAmount !== element2.DoseAmount) {
                            time2.DoseAmount = element2.DoseAmount;
                        }
                    }
                });
            }
        }

        newGridViewModel.PlannedEndTime = newGridViewModel.DrugOrderIntroDuctionTimeSchedule[detailCount - 1].Time;

    }

    public async CreateMultiSelectDrugOrderGridModel(): Promise<void> {

        await this.MultiSelectGridDataSource.forEach((element, index) => {
            let drugOrderIntroductionGridViewModel = new DrugOrderIntroductionGridViewModel();
            drugOrderIntroductionGridViewModel.ID = Guid.newGuid().id;
            drugOrderIntroductionGridViewModel.PlannedStartTime = element.PlannedStartTime;
            drugOrderIntroductionGridViewModel.Day = element.Day;
            drugOrderIntroductionGridViewModel.PlannedStartTime = element.PlannedStartTime;

            drugOrderIntroductionGridViewModel.Material = element.Material;
            drugOrderIntroductionGridViewModel.Material.ActiveIngeridents = element.Material.ActiveIngeridents;
            drugOrderIntroductionGridViewModel.HospitalTimeSchedule = element.HospitalTimeSchedule;
            drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID = element.HospitalTimeScheduleObjectID;
            drugOrderIntroductionGridViewModel.DoseAmount = element.DoseAmount;
            drugOrderIntroductionGridViewModel.DrugUsageType = element.DrugUsageType;

            drugOrderIntroductionGridViewModel.DrugOrderType = element.DrugOrderType;
            drugOrderIntroductionGridViewModel.PatientOwnDrug = element.PatientOwnDrug;
            drugOrderIntroductionGridViewModel.IsImmediate = element.IsImmediate;
            drugOrderIntroductionGridViewModel.CaseOfNeed = element.CaseOfNeed;
            drugOrderIntroductionGridViewModel.UsageNote = element.UsageNote;
            drugOrderIntroductionGridViewModel.SelectionCheck = true;
            drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.New;
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.push(drugOrderIntroductionGridViewModel);
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.push(drugOrderIntroductionGridViewModel);

            this.selectedMasterGridRowKeys.push(drugOrderIntroductionGridViewModel.ID);

            if (drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID != null)
                this.CreateDrugOrderIntroductionTimeModel(drugOrderIntroductionGridViewModel);
            if (index == this.selectedMaterials.length - 1) {
                this.orderMasterGrid.instance.repaint();
                this.FieldDefaultsAfterMaterialAdding();
            }
        });
        this.drugListShowSelectionControl = false;
        this.isIngredientSearch = false;
        this.MultiSelectGridDataSource = new Array<DrugOrderIntroductionGridViewModel>();
    }

    public CancelMultiSelectDrugOrderGridModel() {
        this.drugListShowSelectionControl = false;
        this.isIngredientSearch = false;
        this.MultiSelectGridDataSource = new Array<DrugOrderIntroductionGridViewModel>();
    }

    public onMultiSelectGirdRowRemoving(event: any) {
        this.selectedMaterials = this.selectedMaterials.filter(x => x.drugObjectId !== event.data.Material.drugObjectId);
    }

    //DrugOrder kayıt etmek için gerekli modeli oluşturur.
    public async CreateDrugOrderGridModel(): Promise<void> {
        //if (this.isHimssRequired)
        //    await this.signService.showLoginModal();
        let that = this;

        let drugOrderAddRequirement = new DrugOrderAddRequirement(this.http, this.selectedMaterials, this.GetDrugOrderIntroductionGridViewModelDTO(),
            this.timeScheduleDataSource, this.selectedTimeSchedule, this.plannedStartTime, this.drugOrderMinDate, this.patient, this.doseAmount, this.day, this._episode,
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel, false
        );
        let requirementResult = drugOrderAddRequirement.ExecuteRequirements();
        if (!requirementResult.IsSuccess) {
            if (!this.drugListShowSelectionControl) {
                this.selectedMaterials = new Array<DrugInfo>();
            }
            TTVisual.InfoBox.Alert(requirementResult.resultMessage);
            return;
        }
        else {
            //İlacı ekleyip eklemeyeceği
            /*let drugOrderAddRequirementWithApproval = new DrugOrderAddRequirement(this.http, this.selectedMaterials, this.GetDrugOrderIntroductionGridViewModelDTO(),
                this.timeScheduleDataSource, this.selectedTimeSchedule, this.plannedStartTime, this.drugOrderMinDate,
                this.patient, this.doseAmount, this.day, this._episode, this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel, false);
            let requirementResultWithApproval = await drugOrderAddRequirementWithApproval.ExecuteRequirementsWithApproval();
            if (requirementResultWithApproval.IsSuccess) {*/

            await this.selectedMaterials.forEach((element, index) => {
                let drugOrderIntroductionGridViewModel = new DrugOrderIntroductionGridViewModel();
                drugOrderIntroductionGridViewModel.ID = Guid.newGuid().id;
                drugOrderIntroductionGridViewModel.PlannedStartTime = this.plannedStartTime;
                drugOrderIntroductionGridViewModel.Day = this.day;
                drugOrderIntroductionGridViewModel.PlannedStartTime = this.plannedStartTime;

                drugOrderIntroductionGridViewModel.Material = element;
                if (this.day == null) {
                    if (this.isFriday) {
                        if (this.OrderRestDayCount === 1) {
                            drugOrderIntroductionGridViewModel.Day = 3;
                        } else {
                            drugOrderIntroductionGridViewModel.Day = this.OrderRestDayCount;
                        }
                    } else {
                        drugOrderIntroductionGridViewModel.Day = 1;
                    }
                } else {
                    drugOrderIntroductionGridViewModel.Day = this.day;
                }
                drugOrderIntroductionGridViewModel.Material.ActiveIngeridents = element.ActiveIngeridents;
                //Sunucuda gerekli.
                if (this.selectedTimeSchedule != null) {
                    let timeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID == this.selectedTimeSchedule);
                    drugOrderIntroductionGridViewModel.HospitalTimeSchedule = timeSchedule;
                    drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID = this.selectedTimeSchedule;
                    drugOrderIntroductionGridViewModel.HospitalTimeSchedule = timeSchedule;
                    drugOrderIntroductionGridViewModel.HospitalTimeSchedule = timeSchedule;
                }
                if (this.doseAmount == null) {
                    drugOrderIntroductionGridViewModel.DoseAmount = 1;
                } else {
                    drugOrderIntroductionGridViewModel.DoseAmount = this.doseAmount;
                }

                //Çoklu seçim aktif ise seçili Kullanım Şeklini set et. Değil ise ilaç tanımından gelen set edilir.
                if (!this.drugListShowSelectionControl)
                    drugOrderIntroductionGridViewModel.DrugUsageType = that.selectedDrugUsageType;
                else
                    drugOrderIntroductionGridViewModel.DrugUsageType = <DrugUsageTypeEnum>element.drugUsageTypeEnum;

                drugOrderIntroductionGridViewModel.DrugOrderType = this.selectedDrugOrderType;
                drugOrderIntroductionGridViewModel.PatientOwnDrug = this.isPatientOwnDrug;
                drugOrderIntroductionGridViewModel.IsImmediate = this.isImmediate;
                drugOrderIntroductionGridViewModel.IsCV = this.isCVOrder;
                drugOrderIntroductionGridViewModel.IsTeleOrder = this.isTeleOrder;
                drugOrderIntroductionGridViewModel.CaseOfNeed = this.caseOfNeed;
                drugOrderIntroductionGridViewModel.UsageNote = this.usageNote;
                drugOrderIntroductionGridViewModel.RepeatDayWarning = this.repeatDayWarning;
                drugOrderIntroductionGridViewModel.SelectionCheck = true;
                drugOrderIntroductionGridViewModel.Status = DrugOrderStatusEnum.New;
                this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.push(drugOrderIntroductionGridViewModel);
                this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.push(drugOrderIntroductionGridViewModel);

                this.selectedMasterGridRowKeys.push(drugOrderIntroductionGridViewModel.ID);

                if (this.selectedTimeSchedule != null)
                    this.CreateDrugOrderIntroductionTimeModel(drugOrderIntroductionGridViewModel);
                if (index == this.selectedMaterials.length - 1) {
                    this.orderMasterGrid.instance.repaint();

                    this.FieldDefaultsAfterMaterialAdding();
                }
            });
            this.drugListShowSelectionControl = false;
            this.isIngredientSearch = false;
            //}
            //else {

            //}
        }
    }

    public async CreateDrugOrderIntroductionTimeModel(drugOrderIntroductionGridViewModel: DrugOrderIntroductionGridViewModel) {
        // if (this.isHimssRequired)
        //     await this.signService.showLoginModal();
        let detailTime: Date = null;
        let detailTTimeSchedule: Array<DrugOrderTimceSchedule> = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule;
        drugOrderIntroductionGridViewModel.HospitalTimeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID == drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID);
        if (drugOrderIntroductionGridViewModel.Status !== DrugOrderStatusEnum.New) {
            if (drugOrderIntroductionGridViewModel.IsUpgraded === false || drugOrderIntroductionGridViewModel.IsUpgraded == null)
                detailTime = this.FindFirstDetailTimeForRepeat(drugOrderIntroductionGridViewModel);
        }

        if (drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.length > 0) {
            drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule = new Array<DrugOrderTimceSchedule>();
        }

        if (drugOrderIntroductionGridViewModel.HospitalTimeSchedule != null && detailTime == null) {
            detailTime = this.FindFirstDetailTime(drugOrderIntroductionGridViewModel.HospitalTimeSchedule, drugOrderIntroductionGridViewModel.PlannedStartTime);

            if (drugOrderIntroductionGridViewModel.OrderStartTime != null) {
                if (drugOrderIntroductionGridViewModel.PlannedStartTime != null) {
                    detailTime = new Date(drugOrderIntroductionGridViewModel.PlannedStartTime.getFullYear(), drugOrderIntroductionGridViewModel.PlannedStartTime.getMonth(), drugOrderIntroductionGridViewModel.PlannedStartTime.getDate(), drugOrderIntroductionGridViewModel.OrderStartTime.getHours(), drugOrderIntroductionGridViewModel.OrderStartTime.getMinutes());
                } else {
                    detailTime = new Date(detailTime.getFullYear(), detailTime.getMonth(), detailTime.getDate(), drugOrderIntroductionGridViewModel.OrderStartTime.getHours(), drugOrderIntroductionGridViewModel.OrderStartTime.getMinutes());
                }
            }
        }

        let hospitalTimeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID == drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID);

        if (detailTime != null) {
            if (drugOrderIntroductionGridViewModel.Status == DrugOrderStatusEnum.New)
                drugOrderIntroductionGridViewModel.PlannedStartTime = new Date(detailTime.toString());
            let detailTimePeriod = this.GetDetailTimePeriod(hospitalTimeSchedule.Frequency);
            let detailCount = this.GetDetailCount(drugOrderIntroductionGridViewModel);
            for (let index = 0; index < detailCount; index++) {
                //TODO: Sunucuda yapılacak ya da component'e Input olarak verilecek.
                let drugOrderTimceSchedule: DrugOrderTimceSchedule = new DrugOrderTimceSchedule();
                drugOrderTimceSchedule.DetailNo = index + 1;
                //detailTime Direkt olarak set edildiği zaman
                drugOrderTimceSchedule.Time = new Date(detailTime.toString());
                drugOrderTimceSchedule.UsageNote = drugOrderIntroductionGridViewModel.UsageNote;
                drugOrderTimceSchedule.DoseAmount = drugOrderIntroductionGridViewModel.DoseAmount;
                drugOrderTimceSchedule.MasterID = drugOrderIntroductionGridViewModel.ID;
                drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.push(drugOrderTimceSchedule);
                detailTime = detailTime.AddHours(detailTimePeriod);
            }
            if (detailCount === detailTTimeSchedule.length) {
                for (let index = 0; index < detailCount; index++) {
                    if (detailTTimeSchedule[index].UsageNote != null)
                        drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule[index].UsageNote = detailTTimeSchedule[index].UsageNote;
                }
            }
            if (drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.length > 0)
                drugOrderIntroductionGridViewModel.PlannedEndTime = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule[detailCount - 1].Time;
        }
    }

    public FieldDefaultsAfterMaterialAdding() {
        this.day = null;
        this.usageNote = '';
        this.caseOfNeed = false;
        this.isImmediate = false;
        this.isPatientOwnDrug = false;
        this.plannedStartTime = new Date(Date.now());
        this.selectedMaterials = new Array<DrugInfo>();
        this.selectedTimeSchedule = null;
        this.selectedDrugOrderType = DrugOrderTypeEnum.Treatment;
        this.CloseSearchList();
        //TODO: Default time schedule tanımlama imkanı sağlanacak ve doz aralığına o set edilecek.
        //this.selectedTimeSchedule = this.timeScheduleDataSource[0].ObjectID;
    }

    public DeleteDrugOrderGridModel() {
        this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.filter(x => x.Status != DrugOrderStatusEnum.New);
        this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.filter(x => x.Status != DrugOrderStatusEnum.New);
    }

    public async AllDrugOrderGridModel() {
        if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length > 0) {
            let result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), " ", "Yeni direktifler silinecektir. İşleme devam etmek istiyormusunuz ?");
            if (result === 'E') {
                this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = new Array<DrugOrderIntroductionGridViewModel>();
                this.getAllDrugOrders();
            }
        } else {
            this.getAllDrugOrders();
        }
    }

    public async getAllDrugOrders() {
        let input: DrugOrderIntroductionNewForm_Input = new DrugOrderIntroductionNewForm_Input();
        if (this._episode.ObjectID != null)
            input.episodeObjectID = this._episode.ObjectID;
        else
            input.episodeObjectID = new Guid(this._episode.toString());
        if (typeof this._masterResource === 'string')
            input.masterResourceObjectID = new Guid(this._masterResource);
        else
            input.masterResourceObjectID = this._masterResource.ObjectID;
        if (typeof this._subEpisode === 'string')
            input.subEpisodeObjectID = new Guid(this._subEpisode);
        else
            input.subEpisodeObjectID = this._subEpisode.ObjectID;
        input.allDate = true;
        input.activeInPatientPhysicianApp = this._activeInPatientPhysicianApp.ObjectID;
        this.http.post<DrugOrderIntroductionNewForm_Output>(this.url + '/CreateDrugOrderIntroductionNewForm', input, DrugOrderIntroductionNewForm_Output).then(result => {
            this._DrugOrderIntroduction = result.drugOrderIntroduction;
            this._DrugOrderIntroduction.DrugOrderIntroductionDetails = new Array<DrugOrderIntroductionDet>();
            this._DrugOrderIntroduction.MasterResource = this._masterResource;
            this._DrugOrderIntroduction.SecondaryMasterResource = this._secondaryMasterResource;
            this._DrugOrderIntroduction.Episode = this._episode;
            this._DrugOrderIntroduction.SubEpisode = this._subEpisode;
            this._DrugOrderIntroduction.ActiveInPatientPhysicianApp = this._activeInPatientPhysicianApp;
            this._DrugOrderIntroduction.PatientOwnDrug = false;
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroduction = this._DrugOrderIntroduction;
            this.patient = result.patientDTO;
            this.isHimssRequired = result.IsHimssRequired;
            this.checkDrugAmount = result.checkDrugAmount;
            this.isVademecumEntegrasyon = result.isVademecumEntegrasyon;
            this.OrderRestDayCount = result.OrderRestDayCount;
            this.OrderRestDayDescription = result.OrderRestDayDescription;
            this.patientAllergicDrug = result.patientDTO.PatientAllergicIngredient;
            this.isCV = result.isCV;
            this.IsVisible = result.isVisible;
            //HospitalTimeSchedule içerisine relation'ı olan HospitalTimeScheduleDetail ları doldurur. (Enterprise daki array içerisinde dönüp relation doldurması gibi.)
            if (result.hospitalTimeSchedule && result.hospitalTimeScheduleDetail != null) {
                result.hospitalTimeSchedule.forEach(element => {
                    element.HospitalTimeScheduleDetails = result.hospitalTimeScheduleDetail.filter(x => x.HospitalTimeSchedule.toString() == element.ObjectID.toString());
                });

                this.timeScheduleDataSource = result.hospitalTimeSchedule.sort((x1, x2) => {
                    if (<number>x1.Frequency > <number>x2.Frequency)
                        return 1;
                    if (<number>x1.Frequency < (<number>x2.Frequency))
                        return -1;
                    return 0;
                });
            }
            else {
                TTVisual.InfoBox.Alert('Doz Aralığı için Zaman Çizelgesi tanımı bulunamadı! Direktif verebilmek için Lütfen yetkili kişiden tanımların yapılmasını isteyiniz.');
            }

            this.CreateMasterGridColumns();
            this.CreateDetailGridColumns();
            //this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel = result.DrugOrderGirdViewModelList as Array<DrugOrderIntroductionGridViewModel>;

            let tempArray: Array<DrugOrderIntroductionGridViewModel> = new Array<DrugOrderIntroductionGridViewModel>();

            tempArray = <Array<DrugOrderIntroductionGridViewModel>>AtlasObjectCloner.clone(result.DrugOrderGirdViewModelList);

            this.refreshGridDataSrouce = tempArray;
            this.filterOrders(this.SelectedOrderStatus);

            //TODO: Sistem parametresinden alınacak. 2 saat öncesine veya 10 gün sonrasına order verileblir.
            let nowDate = new Date(Date.now());
            let minute: number;
            let minTime: Date;
            if (result.DrugOrderTimeOffset > 0) {
                if (nowDate.getMinutes() > 30) {
                    this.drugOrderMinDate = nowDate.AddMinutes(60 - nowDate.getMinutes()).AddHours(-result.DrugOrderTimeOffset);
                }
                else {
                    this.drugOrderMinDate = nowDate.AddMinutes(-nowDate.getMinutes()).AddHours(-result.DrugOrderTimeOffset);
                }
            }
            else {
                this.drugOrderMinDate = new Date(Date.now());
            }
            this.plannedStartTime = this.drugOrderMinDate.AddMinutes(1);

            //this.drugOrderMinDate = new Date(nowDate.getFullYear(), nowDate.getMonth(), nowDate.getDate(), nowDate.getHours()).AddHours(-2);
            this.drugOrderMaxDate = new Date(Date.now()).AddDays(result.DrugOrderQueryDate);
            this.selectedDrugOrderType = DrugOrderTypeEnum.Treatment;

            this.selectedMasterGridRowKeys = new Array<string>();
            if (this.isNew === true) {
                setTimeout(x => {
                    this.orderMasterGrid.instance.repaint();
                    this.orderDetailGrids.forEach(element => {
                        element.instance.repaint();
                    });
                }, 2500);
                this.isNew = false;
            }
        });


        if (this._activeInPatientPhysicianApp !== undefined) {
            if (this._activeInPatientPhysicianApp.CurrentStateDefID.valueOf() === InPatientPhysicianApplication.InPatientPhysicianApplicationStates.Discharged.id ||
                this._activeInPatientPhysicianApp.CurrentStateDefID.valueOf() === InPatientPhysicianApplication.InPatientPhysicianApplicationStates.PreDischarged.id) {
            } else {
                this.isInpatient = true;
            }
        }

        DrugOrderIntroductionService.GetPatientOwnDrug(this._episode).then(result => {
            this.patientOwnDrugs = result;
        });
    }

    public FindFirstDetailTime(timeSchedule: HospitalTimeSchedule, plannedStartTime: Date): Date {

        let detailTime: Date = null;
        //drugOrderIntroductionGridViewModel.DrugOrderIntroductionDetail.HospitalTimeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID == drugOrderIntroductionGridViewModel.DrugOrderIntroductionDetail.HospitalTimeScheduleObjectID);
        let hospitalTimeSchedule = timeSchedule;

        if (hospitalTimeSchedule.HospitalTimeScheduleDetails.length === 0) {
            let today = new Date(Date.now());
            detailTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), today.AddHours(1).getHours(), 0, 0);
        }

        for (let index = 0; index < hospitalTimeSchedule.HospitalTimeScheduleDetails.length; index++) {
            let element = hospitalTimeSchedule.HospitalTimeScheduleDetails[index];

            let today = new Date(Date.now());

            //Order'ın verilmek istendiği tarih.
            let plannedStartDate;
            plannedStartDate = plannedStartTime;

            let tempPlannedStartDate = new Date(plannedStartDate.getFullYear(), plannedStartDate.getMonth(), plannedStartDate.getDate(), 0, 0, 0);

            //Tanımlı order saatlerinden oluşturulan geçici tarih.(Verilen order ile karşılaştırma yapabilmek için)
            let tempX1 = new Date(today.getFullYear(), today.getMonth(), today.getDate(), element.Time.getHours(), element.Time.getMinutes());
            //Order'ın verildiği şimdiki saat. (Tanımlı order saatleri ile karşılaştırmak için)
            let tempX2 = new Date(today.getFullYear(), today.getMonth(), today.getDate(), new Date(Date.now()).getHours(), new Date(Date.now()).getMinutes());

            if (tempPlannedStartDate > tempX1) {
                today = new Date(Date.now());
                detailTime = new Date(plannedStartDate.getFullYear(), plannedStartDate.getMonth(), plannedStartDate.getDate(), element.Time.getHours(), element.Time.getMinutes());
                break;
            }
            else if (tempX1 > tempX2) {
                //Order saati geçmemiş ise tanımlı saat ile aynı güne atanır.
                today = new Date(Date.now());
                detailTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), element.Time.getHours(), element.Time.getMinutes());
                break;
            }

            //Son zaman dilimi detayına kadar uygun saat bulunamadı koşulu. (Tanımlı zaman dilimleri order saatini geçmiş.)
            if (index == hospitalTimeSchedule.HospitalTimeScheduleDetails.length - 1 && (detailTime == null)) {
                //Order saati geçmişse ertesi günün ilk tanımlanan saatine atanır.
                today = new Date(Date.now());
                let hospitalTimeScheduleDetail = hospitalTimeSchedule.HospitalTimeScheduleDetails.find(x => x.TimeNumber == 1).Time;
                detailTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), hospitalTimeScheduleDetail.getHours(), hospitalTimeScheduleDetail.getMinutes()).AddDays(1);

            }
        }
        return detailTime;
    }

    public FindFirstDetailTimeForRepeat(drugOrderIntroductionGridViewModel: DrugOrderIntroductionGridViewModel): Date {

        //if (drugOrderIntroductionGridViewModel.Status == DrugOrderStatusEnum.Stopped)
        //    return null;

        let detailTime: Date = null;
        let today = new Date(Date.now());
        let drugOrderStartTime = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule[0].Time;

        if (drugOrderIntroductionGridViewModel.HospitalTimeSchedule.IsTomorrow != null && drugOrderIntroductionGridViewModel.HospitalTimeSchedule.IsTomorrow === true) {
            let tomorrow: Date = today.AddDays(1);
            detailTime = new Date(tomorrow.getFullYear(), tomorrow.getMonth(), tomorrow.getDate(), drugOrderStartTime.getHours(), drugOrderStartTime.getMinutes());
        } else {

            let hospitalTimeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID == drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID);
            detailTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), drugOrderStartTime.getHours(), drugOrderStartTime.getMinutes());

            //Eski detaylar
            let oldDetails: Array<DrugOrderTimceSchedule> = new Array<DrugOrderTimceSchedule>();
            //Eski detayların referansını farklı yapıp binding'i ayırmak için bu şekilde oldDetails lara push edildi.
            if (drugOrderIntroductionGridViewModel.Status == DrugOrderStatusEnum.Complated) {
                drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.forEach(element => {
                    let keys = Object.keys(element);
                    let oldDetail = new DrugOrderTimceSchedule();
                    keys.forEach(key => {
                        oldDetail[key] = element[key];
                    });
                    oldDetails.push(oldDetail);
                });
            }
            //let diff = Math.abs(detailTime.getTime() - drugOrderIntroductionGridViewModel.PlannedEndTime.getTime());
            //let diffDays = Math.Round(diff / (1000 * 3600 * 24), 2);
        }

        if (detailTime > this.drugOrderMinDate)
            return detailTime;

        return null;
    }

    public patientOwnDrugValueChanged(event: boolean) {
    }

    public isImmediateValueChanged(event: boolean) {
    }

    public caseOfNeedValueChanged(event: boolean) {
    }

    public onPlannedStartTimeValueChanged(event: any) {
        //console.log(event);
    }

    public async onDrugListSelectionModeValueChange(event: any) {
        this.selectedMaterials = new Array<DrugInfo>();
        if (event.value == true) {
            this.CreateMultiSelectGridColumns();
            this.drugListSelectionMode = 'multiple';
            this.isInheldDrugList = true;
            if (this.day == null && this.isFriday === false) {
                if (this.OrderRestDayCount === 1) {
                    let nowDate = new Date(Date.now());
                    let day: number = nowDate.getDay();
                    if (day === 5 && this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length === 0) {
                        let isFriday = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                            'Bugün günlerden Cuma 3 günlük order vermek istiyor musunuz?');
                        if (isFriday === 'E') {
                            this.isFriday = true;
                        }
                    }
                } else {
                    if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length === 0) {
                        let restDay = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                            this.OrderRestDayDescription + ' nedeniyle ' + this.OrderRestDayCount.toString() + ' günlük order vermek istiyor musunuz?');
                        if (restDay === 'E') {
                            this.isFriday = true;
                        }
                    }
                }

                if (this.isFriday) {
                    if (this.OrderRestDayCount === 1) {
                        this.day = 3;
                    } else {
                        this.day = this.OrderRestDayCount;
                    }
                } else {
                    this.day = 1;
                }
            }
            if (this.doseAmount == null) {
                this.doseAmount = 1;
            }
        }
        else {
            this.drugListSelectionMode = 'single';
            this.isInheldDrugList = false;
            this.isIngredientSearch = false;
            this.day = null;
            this.doseAmount = null;
        }
    }

    public async onIngredientSearchValueChange(event: any) {
        if (event.value === true) {
            if (this.activeIngeridents.length === 0) {
                this.http.get<Array<DrugIngredient>>(this.url + '/GetDrugIngredients').then(res => {
                    this.activeIngeridents = res;
                });
            }
            this.isInheldDrugList = false;
        } else {
            this.selectedActiveIngeridents = new Array<DrugIngredient>();
        }

    }

    public onTimeScheduleChanged(event: any) {
        if (event.value != null)
            this.plannedStartTime = this.FindFirstDetailTime(this.timeScheduleDataSource.find(x => x.ObjectID == event.value), new Date(Date.now()));
    }

    public async MasterGridUpdatingFunction(event: any): Promise<boolean> {
        return new Promise<boolean>(async (resolve, reject) => {
            let drugOrderIntroductionGridViewModel = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.key);
            if (drugOrderIntroductionGridViewModel.Status === DrugOrderStatusEnum.Continue) {
                if (event.newData.HospitalTimeScheduleObjectID != null
                    || event.newData.DoseAmount != null
                ) {
                    ServiceLocator.MessageService.showError('Güncellenen direktiflerde sadece Kullanma Açıklaması değiştirilebilir ');
                    resolve(true);
                    return;
                }
            }



            if (event.newData.PatientOwnDrug === false) {
                if (drugOrderIntroductionGridViewModel.Material.inheldStatus === "0") {
                    ServiceLocator.MessageService.showError('İlacın mevcudu olmadığı için sadece "Hastanın İlacı" olarak order edebilirsiniz.');
                    resolve(true);
                    return;
                }
                if (drugOrderIntroductionGridViewModel.Material.isPatientOwnDrug != null) {
                    if (drugOrderIntroductionGridViewModel.Material.isPatientOwnDrug === true) {
                        ServiceLocator.MessageService.showError('Sadece "Hastanın İlacı" olarak order edebilirsiniz.');
                        resolve(true);
                        return;
                    }
                }
            }

            if (event.newData.PlannedStartTime != null || event.newData.HospitalTimeScheduleObjectID != null
                || event.newData.DoseAmount != null
                || event.newData.Day != null) {
                let plannedStartTime: Date;
                let timeSchedule: Guid;
                let doseAmount: number;
                let day: number;
                if (event.newData.DoseAmount != null && event.newData.DoseAmount <= 0) {
                    ServiceLocator.MessageService.showError('Doz Miktarı sıfırdan büyük olmalıdır!');
                    resolve(true);
                    return;
                }
                let orderDayPeriod: string = (await SystemParameterService.GetParameterValue('ORDERPLANNIGDAYPERIOD', '3'));
                if (event.newData.Day != null && event.newData.Day > Number.parseInt(orderDayPeriod)) {
                    ServiceLocator.MessageService.showError('Gün ' + orderDayPeriod + ' den büyük olmamalıdır!');
                    resolve(true);
                    return;
                }
                if (event.newData.HospitalTimeScheduleObjectID != null)
                    timeSchedule = event.newData.HospitalTimeScheduleObjectID;
                else
                    timeSchedule = drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID;

                if (timeSchedule == null) {
                    ServiceLocator.MessageService.showError('Doz Aralığı seçiniz');
                    resolve(true);
                    return;
                } else {
                    if (event.newData.PlannedStartTime != null) {
                        if (timeSchedule != null)
                            plannedStartTime = this.FindFirstDetailTime(this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule), new Date(event.newData.PlannedStartTime));
                        else
                            plannedStartTime = new Date(event.newData.PlannedStartTime);
                    }
                    else {
                        if (timeSchedule != null)
                            plannedStartTime = this.FindFirstDetailTime(this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule), event.oldData.PlannedStartTime);
                        else
                            plannedStartTime = new Date(drugOrderIntroductionGridViewModel.PlannedStartTime.toString());
                    }

                    if (event.newData.DoseAmount != null) {
                        if (timeSchedule != null) {
                            doseAmount = event.newData.DoseAmount * <number>this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule).Frequency;
                        }
                        else
                            doseAmount = drugOrderIntroductionGridViewModel.DoseAmount * <number>this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule).Frequency;
                    }
                }
                if (event.newData.Day)
                    day = event.newData.Day;
                else
                    day = drugOrderIntroductionGridViewModel.Day;

                if (this.checkDrugAmount) {
                    if (drugOrderIntroductionGridViewModel.PatientOwnDrug === false && drugOrderIntroductionGridViewModel.Material.drugType != null && drugOrderIntroductionGridViewModel.Material.drugType) {
                        let totalAmount: number = doseAmount * day;
                        if (totalAmount > Number.parseInt(drugOrderIntroductionGridViewModel.Material.inheldStatus)) {
                            ServiceLocator.MessageService.showError('Eczanede yeterli mevcut bulunmamaktadır. İstenen: ' + totalAmount.toString() + ' Mevcut: ' + drugOrderIntroductionGridViewModel.Material.inheldStatus);
                            resolve(true);
                            return;
                        }
                    }
                    if (this.isHimssRequired && drugOrderIntroductionGridViewModel.PatientOwnDrug && drugOrderIntroductionGridViewModel.Material.drugType != null && drugOrderIntroductionGridViewModel.Material.drugType) {
                        let totalAmount: number = doseAmount * day;
                        if (totalAmount > Number.parseInt(drugOrderIntroductionGridViewModel.Material.inheldStatus)) {
                            ServiceLocator.MessageService.showError('Hastanın yeterli mevcutlu ilacı bulunmamaktadır.');
                            resolve(true);
                            return;
                        }
                    }
                } else {
                    if (this.isHimssRequired && drugOrderIntroductionGridViewModel.PatientOwnDrug && drugOrderIntroductionGridViewModel.Material.drugType != null && drugOrderIntroductionGridViewModel.Material.drugType) {
                        let totalAmount: number = doseAmount * day;
                        if (totalAmount > Number.parseInt(drugOrderIntroductionGridViewModel.Material.inheldStatus)) {
                            ServiceLocator.MessageService.showError('Hastanın yeterli mevcutlu ilacı bulunmamaktadır.');
                            resolve(true);
                            return;
                        }
                    }
                }

                drugOrderIntroductionGridViewModel.UpdatedOnGrid = true;
                let drugOrderAddRequirementWithApproval = new DrugOrderAddRequirement(this.http, this.selectedMaterials, this.GetDrugOrderIntroductionGridViewModelDTO(),
                    this.timeScheduleDataSource, timeSchedule, plannedStartTime,
                    this.drugOrderMinDate,
                    this.patient,
                    doseAmount, day,
                    this._episode,
                    this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel,
                    true
                );
                let requirementResultWithApproval = await drugOrderAddRequirementWithApproval.ExecuteRequirementsWithApproval();
                if (requirementResultWithApproval.IsSuccess == false) {
                    // let keys = Object.keys(event.newData.DrugOrderIntroductionDetailDTO);
                    // keys.forEach(key => {
                    //     drugOrderIntroductionGridViewModel[key] = event.oldData.DrugOrderIntroductionDetailDTO[key];
                    // });
                    //this.orderMasterGrid.instance.cancelEditData();
                }
                resolve(!requirementResultWithApproval.IsSuccess);
            }
            else
                resolve(false);
        });
    }

    public async onDrugOrderIntroductionGridUpdating(event: any) {
        event.cancel = this.MasterGridUpdatingFunction(event);
    }

    public onDrugOrderIntroductionGridUpdated(event: any) {
        let row = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.key);
        if (row.PlannedStartTime || row.HospitalTimeScheduleObjectID || row.DoseAmount || row.Day) {
            let drugOrderIntroductionGridViewModel = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.key);
            this.CreateDrugOrderIntroductionTimeModel(drugOrderIntroductionGridViewModel);

            let drugOrderIntroductionDTO: DrugOrderIntroductionGridViewModel = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.find(x => x.ID === event.key);
            drugOrderIntroductionDTO.Day = drugOrderIntroductionGridViewModel.Day;
            drugOrderIntroductionDTO.DrugOrderIntroDuctionTimeSchedule = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule;
            if (drugOrderIntroductionDTO.Material.InfectionApproval === true) {
                let pTime = drugOrderIntroductionDTO.PlannedEndTime;
                if (drugOrderIntroductionDTO.Day == 1)
                    pTime = drugOrderIntroductionDTO.PlannedStartTime;
                let activeInfectionCom = this.patient.ActiveInfectionCommiteeApproves.find(x => x.MaterialID.toString() === drugOrderIntroductionDTO.Material.drugObjectId);
                if (activeInfectionCom != null) {
                    if (new Date(pTime) > new Date(activeInfectionCom.EndDate)) {
                        TTVisual.InfoBox.Alert('Enfeksiyon Komitesi Onayına Gidecektir!');
                    }
                } else {
                    TTVisual.InfoBox.Alert('Enfeksiyon Komitesi Onayına Gidecektir!');
                }
            }
        }
    }

    public onMasterGirdRowRemoving(event: any) {
        if (event != null && event.data != null && event.data.Status == DrugOrderStatusEnum.New) {
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.filter(x => x.ID != event.data.ID);
            event.cancel = false;
        }
        else {
            TTVisual.InfoBox.Alert('Sadece Yeni durumundaki direktifler silinebilir!');
            event.cancel = true;
        }
    }

    public onMasterGridEditingStart(event: any) {
        let row = <DrugOrderIntroductionGridViewModel>event.data;

        if (row.Status != DrugOrderStatusEnum.New) {
            if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.find(x => x.ID === event.data.ID) == null) {
                event.cancel = true;
                TTVisual.InfoBox.Alert('Sadece Yeni Durumunda olan veya  Tedavi Güncelle yapılan Direktifler güncellenebilir!');
            }
        } else {
            row.EditOnGrid = true;
        }
    }

    public onMasterGridEditorPreparing(event: any) {
        if (event.parentType == 'headerRow' && event.command == 'select') {
            event.editorElement.remove();
        }
    }

    onEditorPrepared(e) {
        if (e.parentType == "dataRow" && e.component.columnOption(e.dataField, "validationRules")) {
            setTimeout(function () {
                var validator = null;
                try {
                    if (e.row.rowType == "data")
                        validator = $(e.editorElement).dxValidator("instance");
                    else
                        validator = $(e.editorElement).parent().parent().dxValidator("instance");
                }
                catch (e) {

                }

                if (validator)
                    validator.validate();
            }, 100)
        }
    }

    cancelClickHandler(args) {
        this.orderMasterGrid.instance.cancelEditData();
    }
    async saveClickHandler(args) {
        let isValid: boolean = true;
        let checkDiviedAmount: boolean = true;
        /*let onRow: DrugOrderIntroductionGridViewModel = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.find(x => x.EditOnGrid === true);
        if (onRow.DoseAmount == null || onRow.HospitalTimeScheduleObjectID == null || onRow.DrugUsageType == null)
            isValid = false;*/

        for (let row of this.orderMasterGrid.instance.getVisibleRows()) {
            if (row.isSelected && row.data.EditOnGrid) {
                if (row.data.DoseAmount == null || row.data.HospitalTimeScheduleObjectID == null || row.data.DrugUsageType == null)
                    isValid = false;

                if (row.data.DoseAmount != null) {
                    if (Math.Ceiling(row.data.DoseAmount) > row.data.DoseAmount) {
                        if (row.data.Material.isDivisibleDrug === false) {
                            isValid = false;
                            checkDiviedAmount = false;
                        }
                    }
                }
            }

        }

        if (isValid) {
            for (let updateRow of this.orderMasterGrid.instance.getVisibleRows()) {
                if (updateRow.data.EditOnGrid)
                    updateRow.data.EditOnGrid = false;
            }
            this.orderMasterGrid.instance.saveEditData();
        } else {
            if (checkDiviedAmount === false) {
                ServiceLocator.MessageService.showError('Seçmiş olduğunuz ilaç Bölünebilir İlaç olmadığı için küsüratlı doz order edemezsiniz.');
            } else {
                ServiceLocator.MessageService.showError('Zorunlu alanları doldurmalısınız.');
            }
        }
    }


    public onRowPrepared(event: any) {
        if (event.rowElement.firstItem() !== undefined && event.rowElement.firstItem().length > 0 && event.rowType === 'data' && event.data !== undefined) {
            if (event.data.Status === DrugOrderStatusEnum.Stopped || event.data.Status === DrugOrderStatusEnum.Cancel) {
                this.renderer.setStyle(event.rowElement.firstItem(), "background-color", "red");
            }
        }
    }

    public DetailGridRowUpdating(event: any): Promise<boolean> {
        return new Promise<boolean>(async (resolve, reject) => {
            let materRow = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.key.MasterID);
            if (event.newData.DoseAmount != null && materRow.Status == DrugOrderStatusEnum.New) {
                let plannedStartTime: Date;
                let timeSchedule: Guid;
                let doseAmount: number;
                let day: number;

                timeSchedule = materRow.HospitalTimeScheduleObjectID;
                plannedStartTime = new Date(materRow.PlannedStartTime.toString());
                /*if (event.newData.PlannedStartTime) {
                    if (timeSchedule != null)
                        plannedStartTime = this.FindFirstDetailTime(this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule), new Date(event.newData.PlannedStartTime));
                    else
                        plannedStartTime = new Date(event.newData.PlannedStartTime);
                }
                else {
                    if (timeSchedule != null)
                        plannedStartTime = this.FindFirstDetailTime(this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule), event.oldData.PlannedStartTime);
                    else
                }*/

                if (event.newData.DoseAmount)
                    if (timeSchedule != null) {
                        doseAmount = event.newData.DoseAmount * <number>this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule).Frequency;
                    }
                    else
                        doseAmount = materRow.DoseAmount * <number>this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule).Frequency;
                if (event.newData.Day)
                    day = event.newData.Day;
                else
                    day = materRow.Day;
                materRow.UpdatedOnGrid = true;
                let drugOrderAddRequirementWithApproval = new DrugOrderAddRequirement(this.http, this.selectedMaterials, this.GetDrugOrderIntroductionGridViewModelDTO(),
                    this.timeScheduleDataSource, timeSchedule, plannedStartTime,
                    this.drugOrderMinDate,
                    this.patient,
                    doseAmount, day,
                    this._episode,
                    this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel,
                    true
                );
                let requirementResultWithApproval = await drugOrderAddRequirementWithApproval.ExecuteRequirementsWithApproval();
                if (requirementResultWithApproval.IsSuccess == false) {
                    // let keys = Object.keys(event.newData.DrugOrderIntroductionDetailDTO);
                    // keys.forEach(key => {
                    //     drugOrderIntroductionGridViewModel[key] = event.oldData.DrugOrderIntroductionDetailDTO[key];
                    // });
                    //this.orderMasterGrid.instance.cancelEditData();
                }
                resolve(!requirementResultWithApproval.IsSuccess);
            }
            else if (event.newData.Time != null && materRow.Status !== DrugOrderStatusEnum.Complated && materRow.Status !== DrugOrderStatusEnum.Stopped && materRow.Status !== DrugOrderStatusEnum.Approve) {
                if (event.newData.Time < new Date(Date.now())) {
                    //TODO error
                    event.newData.Time = event.key.Time;
                    ServiceLocator.MessageService.showError("Eski tarihli order veremezsiniz!");
                }
                else {
                    let detailCount = materRow.DrugOrderIntroDuctionTimeSchedule.length - event.oldData.DetailNo;
                    let diff = +(new Date(event.newData.Time)) - +(new Date(event.key.Time));
                    if (diff !== 0 && detailCount > 0) {
                        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Tedavi Saatleri',
                            'Sonraki tedavi saatleri de güncellensin mi?');
                        if (result === 'E') {
                            materRow.DrugOrderIntroDuctionTimeSchedule.filter(x => x.DetailNo > event.oldData.DetailNo).forEach(element => {
                                element.Time = new Date(element.Time.toString()).AddMinutes(diff / 1000 / 60);
                            });
                        }
                    }
                }
                resolve(false);
            }
            else
                resolve(false);
        });
    }

    public onDrugOrderIntroductionTimeScheduleGridUpdating(event: any) {
        event.cancel = this.DetailGridRowUpdating(event);
    }

    public onDrugOrderIntroductionTimeScheduleGridUpdated(event: any) {
        console.log(event);
    }

    public onDetailGridEditingStart(event: any) {
        let row = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.data.MasterID);
        if (row.Status !== DrugOrderStatusEnum.New) {
            if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.find(x => x.ID === event.data.MasterID) == null) {
                event.cancel = true;
                TTVisual.InfoBox.Alert('Sadece Yeni Durumunda ve Tedavi Güncelle yapılan Direktiflerin detayları güncellenebilir!');
            }
        }
        console.log(event);
    }

    public UndoDrugOrder(data: any) {
        if (data != null) {
            let rowKey: string;
            let row: DrugOrderIntroductionGridViewModel = null;
            if (data.key != null)
                rowKey = data.key;
            if (data.ID != null)
                rowKey = data.ID;

            row = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == rowKey);

            if (row != null && row.Status != DrugOrderStatusEnum.New) {
                if (row.Status !== DrugOrderStatusEnum.Stopped) {
                    this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.filter(x => x.ID != rowKey);
                    let unBoundObject = AtlasObjectCloner.clone(this.refreshGridDataSrouce.find(x => x.ID == rowKey));
                    if (unBoundObject != null) {
                        let keys = Object.keys(unBoundObject);
                        keys.forEach(key => {
                            row[key] = unBoundObject[key];
                        });
                    }
                    if (row.SelectionCheck == false) {
                        this.orderMasterGrid.instance.deselectRows([row.ID]);
                        //this.selectedMasterGridRowKeys = this.selectedMasterGridRowKeys.filter(x => x !== row.ID);
                    }
                }
            }
        }
        console.log(data);
    }

    public InfoDrugOrder(data: any) {
        if (data != null) {
            let rowKey: string;
            let row: DrugOrderIntroductionGridViewModel = null;
            if (data.key != null)
                rowKey = data.key;
            if (data.ID != null)
                rowKey = data.ID;

            row = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID === rowKey);

            let input: DrugOrderInfo_Input = new DrugOrderInfo_Input();
            if (row.ParentDrugOrderObjectID != null) {
                input.ParentDrugOrderObjectID = row.ParentDrugOrderObjectID;
            } else {
                input.DrugOrderObjectID = row.LastDrugOrderObjectID;
            }

            this.http.post<DrugOrderInfo_Output>(this.url + '/GetDrugOrderInfo', input).then(result => {
                if (result != null) {
                    this.showDrugOrderInfo(result);
                }
            });
        }
    }

    private showDrugOrderInfo(data: DrugOrderInfo_Output): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderInfoComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'İnfo';
            modalInfo.Width = 750;
            modalInfo.Height = 400;
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

    public onMasterGridSelectionChanged(event: any) {
        let currentDeselectedRow: DrugOrderIntroductionGridViewModel;
        let currentSelectedRow: DrugOrderIntroductionGridViewModel;

        /*TODO: Burada allowSelectAll yapılırken kullanıcıya tüm yapılan değişiklikler geri alınacaktır uyarısı verilecek.
                Kullanıcı onaylarsa yeni durumundaki direktifler hariç currentDeselectedRow lar eski haline alınacak.
                Vazgeç derse değişiklikler kalacak ve currentDeselectedRow'lar tekrar check lenecek
        */

        if (event.currentDeselectedRowKeys != null && event.currentDeselectedRowKeys.length == 1)
            currentDeselectedRow = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.currentDeselectedRowKeys[0]);

        if (event.currentSelectedRowKeys != null && event.currentSelectedRowKeys.length == 1) {
            currentSelectedRow = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.currentSelectedRowKeys[0]);
            currentSelectedRow.SelectionCheck = true;

            if (event.selectedRowsData.find(x => x.ID !== currentSelectedRow.ID && x.Material.drugObjectId === currentSelectedRow.Material.drugObjectId) != null) {
                currentSelectedRow.SelectionCheck = false;
                event.component.deselectRows(event.currentSelectedRowKeys[0]);
                TTVisual.InfoBox.Alert('Bu ilaç zaten seçilmiş.');
            }

            let continueOrder: DrugOrderIntroductionGridViewModel = this.refreshGridDataSrouce.find(x => x.ID !== currentSelectedRow.ID &&
                x.Material.drugObjectId == currentSelectedRow.Material.drugObjectId && x.Status === DrugOrderStatusEnum.Continue);
            if (continueOrder != null) {
                currentSelectedRow.SelectionCheck = false;
                event.component.deselectRows(event.currentSelectedRowKeys[0]);
                TTVisual.InfoBox.Alert('Seçtiğiniz ilaçın şu an devam eden bir uygulaması bulunmaktardır. Bu nedenle bu ilacı güncelleyemezsiniz.');
            }


            if (currentSelectedRow.Status === DrugOrderStatusEnum.New && this.drugListShowSelectionControl === false && currentSelectedRow.HospitalTimeSchedule == null) {
                event.component.editRow(this.orderMasterGrid.instance.getRowIndexByKey(event.currentSelectedRowKeys[0]));
            }
            this.drugListShowSelectionControl = false;
            if (currentSelectedRow.Material.DrugDescription != null && currentSelectedRow.Material.DrugDescription !== "") {
                TTVisual.InfoBox.Alert(currentSelectedRow.Material.DrugDescription, MessageIconEnum.ErrorMessage);
            }
        }

        if (currentDeselectedRow != null && currentDeselectedRow.Status == DrugOrderStatusEnum.New) {
            event.component.selectRows(currentDeselectedRow.ID, true);
            TTVisual.InfoBox.Alert('Lütfen Yeni Eklenen İlaçlar için Silme özelliğini kullanın.');
        }
        else if (currentDeselectedRow != null) {
            //Seçimi kaldırılan satır DTO içerisinde varsa onu DTO'dan çıkart ve undo yap.
            this.UndoDrugOrder(currentDeselectedRow);
            //this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO == this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.filter(x => x.ID !== currentDeselectedRow.ID);
            currentDeselectedRow.SelectionCheck = false;
        }



        console.log(event);
    }


    //Kayıt işlemi yapılırken en son değiştirilen cell'in bind olmasını sağlayan metod. (Master ve detail grid için)
    public async SaveEditCell() {


        if (this.orderDetailGrids.length > 0) {
            this.orderDetailGrids.forEach(element => {
                element.instance.saveEditData();
                element.instance.closeEditCell();
            });
        }
        this.orderMasterGrid.instance.closeEditCell();
        this.orderMasterGrid.instance.saveEditData();
    }

    //İlaç için oluşturalacak detay sayısını belirler. Örn:1x1 için 1 detay 2x1 için 2 datay gibi.
    public GetDetailCount(drugOrderIntroductionDetail: DrugOrderIntroductionGridViewModel): number {
        return drugOrderIntroductionDetail.Day * <number>drugOrderIntroductionDetail.HospitalTimeSchedule.Frequency;
    }

    //İlacın kaç saat aralık ile verileceği.
    public GetDetailTimePeriod(refactoredFrequency: RefactoredFrequencyEnum): number {
        return 24 / <number>refactoredFrequency;
    }

    public OpenSearchList() {
        this.drugSearchEnabled = true;
        //this.isInheldDrugList = true;
    }

    public CloseSearchList() {
        this.searchText = '';
        this.isFavoriteDrugList = false;
        this.drugSearchEnabled = false;
        this.isInheldDrugList = false;
        this.isPatientOwnDrug = false;
        this.searchIsPatientOwnDrug = false;
        this.isCVOrder = false;
        this.repeatDayWarning = '';
        //this.drugListShowSelectionControl = false;
    }
    public async upgradeDrugOrderClick(data: any) {
        if (data.data.Status === DrugOrderStatusEnum.Continue && data.data.Day === 1 && data.data.PatientOwnDrug === false
            && data.data.IsImmediate === false && data.data.Material.InfectionApproval === false) {
            let oldDetails: Array<DrugOrderTimceSchedule> = data.data.DrugOrderIntroDuctionTimeSchedule;
            let drugOrderDetails: Array<DrugOrderDetail> = await DrugOrderIntroductionService.GetActiveDrugOrderDetails(data.data.LastDrugOrderObjectID);
            let upgradeDrugOrderDVO: UpgradeDrugOrderDVO = new UpgradeDrugOrderDVO();
            upgradeDrugOrderDVO.drugOrderDetails = drugOrderDetails;
            upgradeDrugOrderDVO.timeScheduleDataSource = this.timeScheduleDataSource;
            upgradeDrugOrderDVO.oldDrugOrderIntroductionGridViewModel = data.data;
            upgradeDrugOrderDVO.newIsCV = data.data.IsCV;
            upgradeDrugOrderDVO.newUsageNote = data.data.UsageNote;
            if (drugOrderDetails.length > 0)
                this.showDrugOrderUpgrade(upgradeDrugOrderDVO).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let upgradetData = res.Param as DrugOrderIntroductionGridViewModel;
                        data.data.HospitalTimeScheduleObjectID = upgradetData.HospitalTimeScheduleObjectID;
                        data.data.DoseAmount = upgradetData.DoseAmount;
                        data.data.PlannedStartTime = upgradetData.DrugOrderIntroDuctionTimeSchedule[0].Time;
                        data.data.PlannedEndTime = upgradetData.DrugOrderIntroDuctionTimeSchedule[upgradetData.DrugOrderIntroDuctionTimeSchedule.length - 1].Time;
                    }
                });
            else
                ServiceLocator.MessageService.showInfo('Bu Order için güncellenecek veri bulunmamaktadır.');
        } else {
            ServiceLocator.MessageService.showInfo('Sadece Eczane tarafından karşılanan, Enfeksiyon onayı gerekmeyen ve "Devam Ediyor" durumundaki direktiflerin güncellemesi yapılabilinir.');
        }

    }

    private showDrugOrderUpgrade(data: UpgradeDrugOrderDVO): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderUpgradeComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Order Güncelleme';
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

    public async changeDrugOrderClick(data: any) {

        if (data.data.Status === DrugOrderStatusEnum.Continue) {
            let oldDetails: Array<DrugOrderTimceSchedule> = data.data.DrugOrderIntroDuctionTimeSchedule;
            let drugOrderDetails: Array<DrugOrderDetail> = await DrugOrderIntroductionService.GetActiveDrugOrderDetails(data.data.LastDrugOrderObjectID);
            if (drugOrderDetails.length > 0)
                this.showDrugOrderSchedule(drugOrderDetails).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK)
                        DrugOrderIntroductionService.UpdateDrugOrderDetails(res.Param as Array<DrugOrderDetail>).then(result => {
                            if (result) {
                                let updateDetails: Array<DrugOrderDetail> = res.Param as Array<DrugOrderDetail>;
                                for (let det of updateDetails) {
                                    let changeDetail = oldDetails.find(x => x.DetailNo === det.DetailNo);
                                    if (changeDetail != null) {
                                        changeDetail.Time = det.OrderPlannedDate;
                                    }
                                }
                                ServiceLocator.MessageService.showSuccess('Güncelleme başarılı.');
                            } else
                                ServiceLocator.MessageService.showError('Güncelleme yapılırken bir hata oluştu!');
                        });
                });
            else
                ServiceLocator.MessageService.showInfo('Bu Order için güncellenecek veri bulunmamaktadır.');
        } else {
            ServiceLocator.MessageService.showInfo('Sadece "Devam Ediyor" durumundaki direktiflerin saat güncellemesi yapılabilinir.');
        }
    }

    private showDrugOrderSchedule(data: Array<DrugOrderDetail>): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderScheduleComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Zaman Çizelgesi';
            modalInfo.Width = 600;
            modalInfo.Height = 400;
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

    public actionMenuVisible: boolean = false;
    public showActionMenu(): void {
        this.actionMenuVisible = true;
    }

    public onActionMenuClick(e: any) {
        if (e.itemData.ActionName === "DeleteDrugOrderGridModel") {
            this.DeleteDrugOrderGridModel();
        }

        if (e.itemData.ActionName === "AllDrugOrderGridModel") {
            this.AllDrugOrderGridModel();
        }

        if (e.itemData.ActionName === "orderTemplateSelect") {
            this.orderTemplateSelect();
        }

        if (e.itemData.ActionName === "orderTemplateAddNew") {
            this.showOrderAddNewTemplateSelect();
        }
    }

    public async orderTemplateSelect() {
        let orderTempalteItem: Array<OrderTemplateDetailItem> = await this.showOrderTemplateSelect();
        if (orderTempalteItem != null) {
            for (let item of orderTempalteItem) {
                this.selectedTimeSchedule = item.HospitalTimeSchedule;
                this.doseAmount = item.DoseAmount;
                this.selectedDrugUsageType = item.DrugUsageType;
                this.selectedDrugOrderType = item.DrugOrderType;
                this.usageNote = item.Description;
                await this.addDrug(item.drugInfo);
            }
            this.selectedTimeSchedule = null;
            this.doseAmount = null;
            this.selectedDrugUsageType = null;
            this.selectedDrugOrderType = null;
            this.usageNote = null;
        }
    }

    public async showOrderTemplateSelect(): Promise<Array<OrderTemplateDetailItem>> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'OrderTemplateComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            //Branş,Klinik gönderilmeli
            //let dvo: MaterialSelectInputDVO = new MaterialSelectInputDVO();
            // componentInfo.InputParam = new DynamicComponentInputParam(dvo, new ActiveIDsModel(that.EpisodeAction.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M12417", "Şablondan Seç");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                if (inner.Result == DialogResult.OK) {
                    resolve(inner.Param as Array<OrderTemplateDetailItem>);
                } else {
                    resolve(null);
                }
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async addDrug(infoDrug: DrugInfo) {

        if (this.OrderRestDayCount === 1) {

            let nowDate = new Date(Date.now());
            let day: number = nowDate.getDay();
            if (day === 5 && this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length === 0 && this.drugListShowSelectionControl === false && this.isFriday === false) {
                let isFriday = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                    'Bugün günlerden Cuma 3 günlük order vermek istiyor musunuz?');
                if (isFriday === 'E') {
                    this.isFriday = true;
                }
            }
        } else {
            if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.length === 0 && this.drugListShowSelectionControl === false && this.isFriday === false) {
                let restDay = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                    this.OrderRestDayDescription + ' nedeniyle ' + this.OrderRestDayCount.toString() + ' günlük order vermek istiyor musunuz?');
                if (restDay === 'E') {
                    this.isFriday = true;
                }
            }
        }
        if (infoDrug.drugType) {
            let rptDayOutput: ControlRepeatDay_Output = await DrugOrderIntroductionService.ControlRepeatDay(new Guid(infoDrug.drugObjectId), this.Episode, new Date(Date.now()));
            if (rptDayOutput.isWarning === true) {
                let rptDay = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Gün Uyarısı',
                    rptDayOutput.warningMessage + ' Devam etmek istiyor musunuz ?');
                if (rptDay === 'E') {
                    this.repeatDayWarning = rptDayOutput.warningMessage;
                } else {
                    return;
                }
            }
        }
        if (this.isCV === true) {
            let isCVQuestion = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'CV',
                'Bugün bu hastaya daha önce order verilmiş. Bu order CV mi olacak ?');
            if (isCVQuestion === 'E') {
                this.isCVOrder = true;
            }
        }
        let isHuman = infoDrug.DrugSpecifications.find(x => x.Value === DrugSpecificationEnum.HumanAlbumin);
        if (isHuman != null) {
            if (this.patient.IsLiverTransplant === false) {
                let restDay = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Karaciğer Nakli',
                    'Hastaya daha önce Karaciğer Nakli yapıldı mı ?');
                if (restDay === 'H') {
                    if (this.patient.IsRequestAlbuminExamination === false) {
                        TTVisual.InfoBox.Alert('Hastanın herhangi bir istenmiş veya tamamlanmış Albumin Tetkiği bulunmamaktadır. Bu ilacı isteyemezsiniz.');
                        return;
                    } else {
                        if (this.patient.ResultAlbuminExamination === 1) {
                            TTVisual.InfoBox.Alert('Hastanın Albumin Tetkiği sonucu 2,5 dan yüksektir. Bu ilacı isteyemezsiniz.');
                            return;
                        }
                    }
                }
            }
        }

        let drugReportNo: string = '0';
        if (infoDrug.DrugReportType === DrugReportType.RaporlaOdenir && this.patient.IsSGK === true) {
            await new Promise<boolean>((resolve, reject) => {
                let input: GetDrugReportNo_Input = new GetDrugReportNo_Input();
                input.DrugID = new Guid(infoDrug.drugObjectId);
                if (this.Episode.ObjectID != null)
                    input.EpisodeID = this.Episode.ObjectID;
                else
                    input.EpisodeID = new Guid(this.Episode.toString());
                this.http.post<string>(this.url + '/GetDrugReportNo', input).then(result => {
                    drugReportNo = result;
                    infoDrug.MedulaReportNo = result;
                    resolve(true);
                }).catch(err => {
                    TTVisual.InfoBox.Alert(err);
                    reject(err);
                    return;
                });
            });

            if (drugReportNo === '0') {
                TTVisual.InfoBox.Alert('Hastanın herhangi bir raporu bulunamadı.Lütfen etken maddeye uygun rapor yazınız.');
                return;
            }
        }


        if (infoDrug.DrugDescription != null && infoDrug.DrugDescription !== "" && this.drugListShowSelectionControl === true) {
            TTVisual.InfoBox.Alert(infoDrug.DrugDescription, MessageIconEnum.ErrorMessage);
        }

        if (this.patientAllergicDrug.length > 0) {
            for (let drugActiveIngredient of infoDrug.ActiveIngeridents) {
                if (this.patientAllergicDrug.find(x => x === drugActiveIngredient.Objectid) != null) {
                    TTVisual.InfoBox.Alert('Hastanın ' + drugActiveIngredient.Name + ' etken maddesine allerjisi vardır. Bu ilacı yazamazsınız.', MessageIconEnum.ErrorMessage);
                    return;
                }
            }
        }

        //if (this.isHimssRequired)
        //    await this.signService.showLoginModal();
        if (infoDrug !== null) {

            //this.drugName = event.itemData.barcode + " " + event.itemData.name;
            this.patientOwnDrugAmount = parseInt(infoDrug.inheldStatus);
            // this.selectedMaterial = new Material();
            // this.selectedMaterial.Name = event.itemData.name;
            // this.selectedMaterial.ObjectID = event.itemData.drugObjectId;
            if (this.selectedMaterials.find(x => x.drugObjectId == infoDrug.drugObjectId) == null) {
                if (!Number.isNaN(parseInt(infoDrug.inheldStatus)) && parseInt(infoDrug.inheldStatus) == 0) {
                    let material = new DrugDefinition();
                    material.ObjectID = new Guid(infoDrug.drugObjectId);
                    let equivalentDrugs: Array<DrugInfo> = await DrugOrderIntroductionService.GetEquivalentDrug(material, 1);
                    let equivalentDrug: DrugInfo = await this.checkEquivalent(equivalentDrugs);
                    if (equivalentDrug !== null) {
                        this.selectedMaterials.push(equivalentDrug as DrugInfo);
                    }
                    else {
                        let patientOwnDrug = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Hastanın İlacı',
                            infoDrug.name + ' ilacını "Hastanın Yanında Getirdiği" ilaç olarak order etmek istiyormusunuz? ');
                        if (patientOwnDrug === 'E') {
                            this.selectedMaterials.push(infoDrug);
                            this.isPatientOwnDrug = true;
                        } else {
                            return;
                        }
                        //TTVisual.InfoBox.Alert('İlacın mevcudu bulunmamaktadır. Direktif veremezsiniz!');
                    }
                }
                else
                    this.selectedMaterials.push(infoDrug);
            }
            if (!this.drugListShowSelectionControl) {
                //TODO: Default time schedule tanımlama imkanı sağlanacak ve doz aralığına o set edilecek.
                if (this.timeScheduleDataSource != null && this.timeScheduleDataSource.length > 0) {
                    //this.selectedTimeSchedule = this.timeScheduleDataSource[0].ObjectID;
                }
                //Çoklu seçim aktif değil ise kullanım şeklini otomatik set et.
                if (this.selectedDrugUsageType == null)
                    this.selectedDrugUsageType = infoDrug.drugUsageTypeEnum;
                //this.doseAmount = 1;
                this.CreateDrugOrderGridModel().then(x => {
                    this.CloseSearchList();
                });
            }
            else {

            }

            //TODO: Burası kontrol edilecek.
            if (infoDrug.inheldStatus === 'Var') {
                this.isInheld = true;
            } else if (infoDrug.inheldStatus === 'Yok') {
                this.isInheld = false;
            } else if (infoDrug.inheldStatus === '0') {
                this.isInheld = false;
            } else {
                this.isInheld = true;
            }

            if (this.SelectedOrderStatus !== 'Devam Eden Tedaviler') {
                this.SelectedOrderStatus = 'Devam Eden Tedaviler';
                this.filterOrders(this.SelectedOrderStatus);
            }

        } else {
            this._DrugOrderIntroduction.DrugName = '';
            this._DrugOrderIntroduction.DrugObjectID = null;
        }
    }

    public async showOrderAddNewTemplateSelect() {
        let that = this;
        let orders: Array<DrugOrderIntroductionGridViewModel> = this.GetDrugOrderIntroductionGridViewModelDTO();
        if (orders.length > 0) {
            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'OrderTemplateAddNewComponent';
                componentInfo.ModuleName = 'LogisticFormsModule';
                componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                componentInfo.InputParam = this.GetDrugOrderIntroductionGridViewModelDTO();

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = i18n("M12417", "Şablon Kaydet");
                modalInfo.Width = 1200;
                modalInfo.Height = 700;

                let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                let result = modalService.create(componentInfo, modalInfo);
                result.then(inner => {
                    if (inner.Result == DialogResult.OK) {
                        ServiceLocator.MessageService.showSuccess(inner.Param.toString());
                        resolve(inner.Param as Array<OrderTemplateDetailItem>);
                    } else {
                        resolve(null);
                    }
                }).catch(err => {
                    reject(err);
                });
            });
        } else {
            ServiceLocator.MessageService.showError("Yeni yazılmış hiç order bulunmamıştır.");
        }
    }

}
