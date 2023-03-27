//$14CD6246
import { Component, OnInit, NgZone } from '@angular/core';
import { InfectionCommitteeFormViewModel, InpatientHasDrugListDTO, PatientInputDTO } from './InfectionCommitteeFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/ActionForm";
import { InfectionCommittee, FrequencyEnum, DrugOrderTypeEnum, AntibioticTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { InfectionCommitteeDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionService, InPatientPhysicianApplication_Output } from 'Fw/Services/StockActionService';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { IActiveTabService } from 'Fw/Services/IActiveTabService';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { itemColorScheme } from 'devexpress-dashboard/model/index.metadata';
import { TestResultQueryInputDVO } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { InfoBox, InputForm } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
@Component({
    selector: 'InfectionCommitteeForm',
    templateUrl: './InfectionCommitteeForm.html',
    providers: [MessageService]
})
export class InfectionCommitteeForm extends ActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Day: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    DoseAmount: TTVisual.ITTTextBoxColumn;
    Drug: TTVisual.ITTListBoxColumn;
    DrugOrderTab: TTVisual.ITTTabPage;
    Frequency: TTVisual.ITTEnumComboBoxColumn;
    FromResource: TTVisual.ITTObjectListBox;
    ID: TTVisual.ITTTextBox;
    InpatientDrugOrders: TTVisual.ITTGrid;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelMasterResource: TTVisual.ITTLabel;
    labelNamePerson: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    NamePerson: TTVisual.ITTTextBox;
    ProtocolNo: TTVisual.ITTTextBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    UsageNote: TTVisual.ITTTextBoxColumn;
    RecentActiveTab: string;
    ActivePage: string;
    DayOfDrugOrder: number;
    textdisabled: boolean;
    viewResultURL: string = "";
    public EpisodeObjectID: Guid;
    public PatientObjectID: Guid;
    public TCKimlikNo: string;
    public clinicName: string;
    public clinicRoom: string;
    public clinicBed: string;
    public clinicProtocolNo: string;
    public clinicDischargeDate: Date;
    public hasPhysicianApplication: boolean = true;
    public hasSpecialityBasedObject: boolean = false;
    public hasEmergencySpecialityBasedObject: boolean = true;
    public InpatientDrugOrdersColumns = [];
    public infectionCommitteeDayParameter: boolean = false;
    public infectionCommitteeFormViewModel: InfectionCommitteeFormViewModel = new InfectionCommitteeFormViewModel();
    public InpatientHasDrugList: Array<InpatientHasDrugListDTO> = new Array<InpatientHasDrugListDTO>();
    public AllInpatientHasDrugList: Array<InpatientHasDrugListDTO> = new Array<InpatientHasDrugListDTO>();
    public get _InfectionCommittee(): InfectionCommittee {
        return this._TTObject as InfectionCommittee;
    }
    private InfectionCommitteeForm_DocumentUrl: string = '/api/InfectionCommitteeService/InfectionCommitteeForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected tabService: IActiveTabService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.InfectionCommitteeForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async ClientSidePreScript(): Promise<void> {
        if (this._InfectionCommittee.InPatientPhysicianApplication != undefined) {
            this.hasPhysicianApplication = true;
            let output: InPatientPhysicianApplication_Output = await StockActionService.GetInPatientPhysicianApplication_Info(this._InfectionCommittee.InPatientPhysicianApplication.toString());
            if (output != null) {
                this.clinicProtocolNo = output.clinicProtocolNo;
                this.clinicBed = output.clinicBed;
                this.clinicRoom = output.clinicRoom;
                this.clinicName = output.clinicName;
                this.clinicDischargeDate = output.clinicDischargeDate;
            }
        }
        else {
            this.hasPhysicianApplication = false;
        }

        let sysParam: string = (await SystemParameterService.GetParameterValue("INFECTIONCOMMITEEDAYAPPROVEL", "FALSE"));
        if (this._InfectionCommittee.CurrentStateDefID.toString() !== InfectionCommittee.InfectionCommitteeStates.Completed.id) {
            if (sysParam === "TRUE") {
                this.textdisabled = false;
                this.infectionCommitteeDayParameter = true;
                this.DayOfDrugOrder = 0;
            }
            else {
                for (let item of this.infectionCommitteeFormViewModel._InfectionCommittee.InfectionCommitteeDetails) {

                    let timeOfItem = new Date(item.DrugOrder.PlannedStartTime).AddDays(parseInt(item.DrugOrder.Day.toString()));
                    item.EndDate = new Date(timeOfItem.getFullYear(), timeOfItem.getMonth(), timeOfItem.getDate(), 23, 59, 59);
                }
            }
        }
        else {
            if (sysParam === "TRUE") {
                this.textdisabled = true;
                this.infectionCommitteeDayParameter = true;
                for (let item of this.infectionCommitteeFormViewModel._InfectionCommittee.InfectionCommitteeDetails) {
                    let endDate: Date = new Date(item.DrugOrder.PlannedStartTime.getFullYear(), item.DrugOrder.PlannedStartTime.getMonth(), item.DrugOrder.PlannedStartTime.getDate())
                    if (item.EndDate != null) {
                        let startDate: Date = new Date(item.EndDate.getFullYear(), item.EndDate.getMonth(), item.EndDate.getDate());
                        var diffDays = Math.ceil((startDate.valueOf() - endDate.valueOf()) / (1000 * 3600 * 24));
                    }
                    this.DayOfDrugOrder = diffDays;
                }
            }
        }
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (this.DayOfDrugOrder == null) {
            TTVisual.InfoBox.Alert("Gün Alanı Boş Geçilemez!");
        }
        if (transDef.ToStateDefID.valueOf() === InfectionCommittee.InfectionCommitteeStates.Cancel.id) {
            let cancelReason: string = await InputForm.GetText("İptal Nedeni Giriniz");
            this._InfectionCommittee.CancelReason = cancelReason;
        }

    }
    public InpatientDrugOrdersNewColumns = [
        {
            caption: "Malzeme Adı",
            dataField: 'DrugOrder.Material.Name',
            allowEditing: false,
        },
        {
            caption: "Doz Aralığı",
            dataField: 'DrugOrder.Frequency',
            lookup: { dataSource: FrequencyEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
        },
        {
            caption: "Miktar",
            dataField: 'DrugOrder.DoseAmount',
            allowEditing: false,
        },
        {
            caption: "Gün",
            dataField: 'DrugOrder.Day',
            allowEditing: false,
        },
        {
            caption: "Kullanıcı Notu",
            dataField: 'DrugOrder.UsageNote',
            allowEditing: false,
        },
        {
            caption: "Başlangıç Tarihi",
            dataField: 'DrugOrder.PlannedStartTime',
            dataType: "date",
            format: "shortDateShortTime",
            allowEditing: false,
        },
        {
            caption: "Bitiş Tarihi",
            dataField: 'EndDate',
            dataType: "date",
            format: "shortDateShortTime",
            allowEditing: false,
        },
        {
            caption: "Açıklama",
            dataField: 'Description',
            allowEditing: true,
        }
    ];

    public DTOList = [
        {
            caption: i18n("M27573", "Uyg. Baş. Tarihi"),
            dataField: 'PlannedStartTime',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            fixed: true,
            width: 'auto',
            visibleIndex: 0,
            allowEditing: false,
            sortOrder: 'desc',
        },
        {
            caption: "Uyg. Bit. Tarihi",
            dataField: 'PlannedEndTime',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            fixed: true,
            width: 'auto',
            visibleIndex: 1,
            allowEditing: false,
        },
        {
            caption: "Onay Bitiş Tarihi",
            dataField: 'InfectionCommitteeDetail.EndDate',
            dataType: "date",
            format: "shortDateShortTime",
            fixed: true,
            width: 'auto',
            visibleIndex: 2,
            allowEditing: false,
        },
        {
            caption: i18n("M16287", "İlaç"),
            dataField: 'DrugName',
            fixed: true,
            visibleIndex: 3,
            allowEditing: false,
            width: 400,
        },
        {
            caption: "Doz Aralığı",
            dataField: 'Frequency',
            fixed: true,
            visibleIndex: 4,
            allowEditing: false,
            width: 80,
        },
        {
            caption: i18n("M13294", "Doz Miktarı"),
            dataField: 'DoseAmount',
            dataType: 'number',
            alignment: 'left',
            fixed: true,
            visibleIndex: 5,
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M14998", "Gün"),
            dataField: 'Day',
            dataType: 'number',
            format: '#',
            fixed: true,
            visibleIndex: 6,
            allowEditing: false,
            width: 50,
        },
        {
            caption: i18n("M17991", "Kullanma Açıklaması"),
            dataField: 'UsageNote',
            visibleIndex: 7,
            allowEditing: false,
            width: 300,
        },
        {
            caption: i18n("M10430", "Acil İlaç"),
            dataField: 'IsImmediate',
            dataType: 'boolean',
            visibleIndex: 8,
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M26386", "Lüzumu Halinde"),
            dataField: 'CaseOfNeed',
            dataType: 'boolean',
            visibleIndex: 9,
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M17982", "Tedavi Türü"),
            dataField: 'DrugOrderType',
            lookup: { dataSource: DrugOrderTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            visibleIndex: 10,
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Doktor Adı',
            dataField: 'DoctorName',
            visibleIndex: 11,
            allowEditing: false,
            width: 'auto',
        },
    ];

    public OrderDTOList = [
        {
            caption: i18n("M27573", "Uyg. Baş. Tarihi"),
            dataField: 'PlannedStartTime',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            fixed: true,
            width: 'auto',
            visibleIndex: 0,
            allowEditing: false,
            sortOrder: 'desc',
        },
        {
            caption: "Uyg. Bit. Tarihi",
            dataField: 'PlannedEndTime',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            fixed: true,
            width: 'auto',
            visibleIndex: 1,
            allowEditing: false,
        },
        {
            caption: i18n("M16287", "İlaç"),
            dataField: 'DrugName',
            fixed: true,
            visibleIndex: 2,
            allowEditing: false,
            width: 400,
        },
        {
            caption: "Doz Aralığı",
            dataField: 'Frequency',
            fixed: true,
            visibleIndex: 3,
            allowEditing: false,
            width: 80,
        },
        {
            caption: i18n("M13294", "Doz Miktarı"),
            dataField: 'DoseAmount',
            dataType: 'number',
            alignment: 'left',
            fixed: true,
            visibleIndex: 4,
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M14998", "Gün"),
            dataField: 'Day',
            dataType: 'number',
            format: '#',
            fixed: true,
            visibleIndex: 5,
            allowEditing: false,
            width: 50,
        },
        {
            caption: i18n("M17991", "Kullanma Açıklaması"),
            dataField: 'UsageNote',
            visibleIndex: 6,
            allowEditing: false,
            width: 300,
        },
        {
            caption: i18n("M10430", "Acil İlaç"),
            dataField: 'IsImmediate',
            dataType: 'boolean',
            visibleIndex: 7,
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: "Hastanın İlacı",
            dataField: 'PatientOwnDrug',
            dataType: 'boolean',
            visibleIndex: 8,
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M26386", "Lüzumu Halinde"),
            dataField: 'CaseOfNeed',
            dataType: 'boolean',
            visibleIndex: 9,
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M17982", "Tedavi Türü"),
            dataField: 'DrugOrderType',
            lookup: { dataSource: DrugOrderTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            visibleIndex: 10,
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Doktor Adı',
            dataField: 'DoctorName',
            visibleIndex: 11,
            allowEditing: false,
            width: 'auto',
        },
    ];

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
            caption: "Bitiş Tarihi",
            dataField: 'PlannedEndTime',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            width: 110,
        },
        {
            caption: 'İlaç Adı',
            dataField: 'DrugName',
            allowEditing: false,
            width: 350,
        },
        {
            caption: 'EHU',
            dataField: 'EhuStatus',
            lookup: { dataSource: AntibioticTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Doz Aralığı',
            dataField: 'Dose',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Doz Miktarı',
            dataField: 'DoseAmount',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Gün',
            dataField: 'Day',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Miktar',
            dataField: 'Amount',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Kullanım Açık.',
            dataField: 'Desciption',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Acil İlaç',
            dataField: 'IsImmediately',
            allowEditing: false,
            width: 80,
        },
        {
            caption: 'Hastanın İlacı',
            dataField: 'PatientOwnDrug',
            allowEditing: false,
            width: 80,
        },
        {
            caption: 'Lüzümu Halinde',
            dataField: 'CaseOfNeed',
            allowEditing: false,
            width: 80,
        },
        {
            caption: i18n("M17982", "Tedavi Türü"),
            dataField: 'TreatmentType',
            lookup: { dataSource: DrugOrderTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Doktor',
            dataField: 'DoctorName',
            allowEditing: false,
            width: 180,
        },
        {
            caption: 'Klinik',
            dataField: 'ClinikName',
            allowEditing: false,
            width: 200,
        },
        /* {
            caption: 'İnfo',
            allowEditing: false,
        }, */
    ];

    loadingVisible: boolean = false;
    LoadPanelMessage: string = "";
    tabSelectionPatient(event) {
        if (event.addedItems[0].title === "Yatışa Ait İlaçlar") {
            this.loadingVisible = true;
            this.LoadPanelMessage = "Yatışa Ait İlaçlar Listeleniyor..";
            if (this.InpatientHasDrugList.length == 0) {
                let that = this;
                let inputDVO = new PatientInputDTO();
                inputDVO.SubepisodeObjectId = this._InfectionCommittee.SubEpisode.toString();
                inputDVO.all = false;
                let apiUrl: string = 'api/InfectionCommitteeService/GetInpatientHasDrugList';
                this.httpService.post<Array<InpatientHasDrugListDTO>>(apiUrl, inputDVO).then(
                    result => {
                        this.InpatientHasDrugList = result;
                        this.loadingVisible = false;
                    },
                ).catch(ex => {
                    this.loadingVisible = false;
                });
            }
        }
        if (event.addedItems[0].title === "Daha Önceki Yatışlara Ait İlaçlar") {
            this.loadingVisible = true;
            this.LoadPanelMessage = "Daha Önceki Yatışlara Ait İlaçlar Listeleniyor..";
            if (this.AllInpatientHasDrugList.length == 0) {
                let that = this;
                let inputDVO = new PatientInputDTO();
                inputDVO.EpisodeObjectID = this._InfectionCommittee.Episode.ObjectID.toString();
                inputDVO.SubepisodeObjectId = this._InfectionCommittee.SubEpisode.toString();
                inputDVO.all = true;
                let apiUrl: string = 'api/InfectionCommitteeService/GetInpatientHasDrugList';
                this.httpService.post<Array<InpatientHasDrugListDTO>>(apiUrl, inputDVO).then(
                    result => {
                        this.AllInpatientHasDrugList = result;
                        this.loadingVisible = false;
                    },
                ).catch(ex => {
                    this.loadingVisible = false;
                });
            }
        }
        this.loadingVisible = false;
    }

    public onTransactionDayChanged(event): void {
        if (event.value == "") {
            TTVisual.InfoBox.Alert("Boş Geçilemez!");
            this.DayOfDrugOrder = 0;
        }
        if (event != null) {
            if (this.DayOfDrugOrder != null && this.DayOfDrugOrder >= 0 && this.DayOfDrugOrder < 11) {
                for (let item of this.infectionCommitteeFormViewModel._InfectionCommittee.InfectionCommitteeDetails) {
                    let timeOfItem = new Date(item.DrugOrder.PlannedStartTime).AddDays(parseInt(this.DayOfDrugOrder.toString()));
                    item.EndDate = new Date(timeOfItem.getFullYear(), timeOfItem.getMonth(), timeOfItem.getDate(), 23, 59, 59);
                }
                for (let item of this.infectionCommitteeFormViewModel.InfectionCommitteeDetailDTOList) {
                    let timeOfItem = new Date(item.InfectionCommitteeDetail.DrugOrder.PlannedStartTime).AddDays(parseInt(this.DayOfDrugOrder.toString()));
                    item.InfectionCommitteeDetail.EndDate = new Date(timeOfItem.getFullYear(), timeOfItem.getMonth(), timeOfItem.getDate(), 23, 59, 59);
                }
            }
            else {
                TTVisual.InfoBox.Alert("0 dan küçük veya  10 günden fazla değer girilemez!");
                this.DayOfDrugOrder = 0;
                event.value = 0;
            }
        }
    }

    showPathologyResultsPopUp: boolean = false;

    btnShowAllPathologyResults(): void {
        this.popupTitleRadiologyTestResultsForm = "Geçmiş Patoloji Sonuçları";
        this.showPathologyResultsPopUp = true;
    }
    openInNewTab(url) {
        if (url == null) {
            InfoBox.Alert(i18n("M12080", "Bu hizmetin sonucu bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }

    btnShowLISResultViewForAllEpisodes_Click(): void {
        this.viewResultURL = "";
        this.GetViewResultURLForAllEpisodes().then(() => {
            this.openInNewTab(this.viewResultURL);
        });
    }

    public async GetViewResultURLForAllEpisodes(): Promise<void> {

        let that = this;
        let inputDVO = new TestResultQueryInputDVO();


        inputDVO.PatientTCKN = this.TCKimlikNo;
        inputDVO.EpisodeID = this._InfectionCommittee.Episode.ID.toString();

        let apiUrl: string = 'api/ProcedureRequestService/GetURLForAllEpisodeTestResults';
        let result = await this.httpService.post<string>(apiUrl, inputDVO);
        this.viewResultURL = result;
    }

    showPopupRadiologyTestResultsForm: boolean;
    popupTitleRadiologyTestResultsForm: string;
    btnShowPatientAllRadiologyTestResult_Click(): void {
        this.popupTitleRadiologyTestResultsForm = "Geçmiş Radyoloji Sonuçları";
        this.showPopupRadiologyTestResultsForm = true;
    }
    // *****Method declarations end *****



    public initViewModel(): void {
        this._TTObject = new InfectionCommittee();
        this.infectionCommitteeFormViewModel = new InfectionCommitteeFormViewModel();
        this._ViewModel = this.infectionCommitteeFormViewModel;
        this.infectionCommitteeFormViewModel._InfectionCommittee = this._TTObject as InfectionCommittee;
        this.infectionCommitteeFormViewModel._InfectionCommittee.InfectionCommitteeDetails = new Array<InfectionCommitteeDetail>();
        this.infectionCommitteeFormViewModel._InfectionCommittee.Episode = new Episode();
        this.infectionCommitteeFormViewModel._InfectionCommittee.Episode.Patient = new Patient();
        this.infectionCommitteeFormViewModel._InfectionCommittee.FromResource = new ResSection();
    }

    protected loadViewModel() {
        let that = this;

        that.infectionCommitteeFormViewModel = this._ViewModel as InfectionCommitteeFormViewModel;
        that._TTObject = this.infectionCommitteeFormViewModel._InfectionCommittee;
        if (this.infectionCommitteeFormViewModel == null)
            this.infectionCommitteeFormViewModel = new InfectionCommitteeFormViewModel();
        if (this.infectionCommitteeFormViewModel._InfectionCommittee == null)
            this.infectionCommitteeFormViewModel._InfectionCommittee = new InfectionCommittee();
        that.infectionCommitteeFormViewModel._InfectionCommittee.InfectionCommitteeDetails = that.infectionCommitteeFormViewModel.InpatientDrugOrdersGridList;
        for (let detailItem of that.infectionCommitteeFormViewModel.InpatientDrugOrdersGridList) {
            let drugOrderObjectID = detailItem["DrugOrder"];
            if (drugOrderObjectID != null && (typeof drugOrderObjectID === 'string')) {
                let drugOrder = that.infectionCommitteeFormViewModel.DrugOrders.find(o => o.ObjectID.toString() === drugOrderObjectID.toString());
                if (drugOrder) {
                    detailItem.DrugOrder = drugOrder;
                }
                if (drugOrder != null) {
                    let materialObjectID = drugOrder["Material"];
                    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                        let material = that.infectionCommitteeFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                        if (material) {
                            drugOrder.Material = material;
                        }
                    }
                }
            }
        }
        for (let detailDTO of that.infectionCommitteeFormViewModel.InfectionCommitteeDetailDTOList) {
            let drugOrderObjectID = detailDTO.InfectionCommitteeDetail["DrugOrder"];
            if (drugOrderObjectID != null && (typeof drugOrderObjectID === 'string')) {
                let drugOrder = that.infectionCommitteeFormViewModel.DrugOrders.find(o => o.ObjectID.toString() === drugOrderObjectID.toString());
                if (drugOrder) {
                    detailDTO.InfectionCommitteeDetail.DrugOrder = drugOrder;
                }
                if (drugOrder != null) {
                    let materialObjectID = drugOrder["Material"];
                    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                        let material = that.infectionCommitteeFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                        if (material) {
                            drugOrder.Material = material;
                        }
                    }
                }
            }
        }
        let episodeObjectID = that.infectionCommitteeFormViewModel._InfectionCommittee["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.infectionCommitteeFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.infectionCommitteeFormViewModel._InfectionCommittee.Episode = episode;
                that.EpisodeObjectID = episode.ObjectID;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.infectionCommitteeFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                        that.PatientObjectID = patient.ObjectID;
                        that.TCKimlikNo = patient.UniqueRefNo.toString();
                    }
                }
            }
        }
        let fromResourceObjectID = that.infectionCommitteeFormViewModel._InfectionCommittee["FromResource"];
        if (fromResourceObjectID != null && (typeof fromResourceObjectID === 'string')) {
            let fromResource = that.infectionCommitteeFormViewModel.ResSections.find(o => o.ObjectID.toString() === fromResourceObjectID.toString());
            if (fromResource) {
                that.infectionCommitteeFormViewModel._InfectionCommittee.FromResource = fromResource;
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(InfectionCommitteeFormViewModel);
        this.FormCaption = "Enfeksiyon Komitesi İstek";
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._InfectionCommittee != null && this._InfectionCommittee.ActionDate != event) {
                this._InfectionCommittee.ActionDate = event;
            }
        }
    }

    public onFromResourceChanged(event): void {
        if (event != null) {
            if (this._InfectionCommittee != null && this._InfectionCommittee.FromResource != event) {
                this._InfectionCommittee.FromResource = event;
            }
        }
    }

    public onNamePersonChanged(event): void {
        if (event != null) {
            if (this._InfectionCommittee != null &&
                this._InfectionCommittee.Episode != null &&
                this._InfectionCommittee.Episode.Patient != null && this._InfectionCommittee.Episode.Patient.FullName != event) {
                this._InfectionCommittee.Episode.Patient.FullName = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._InfectionCommittee != null &&
                this._InfectionCommittee.Episode != null && this._InfectionCommittee.Episode.HospitalProtocolNo != event) {
                this._InfectionCommittee.Episode.HospitalProtocolNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "Episode.HospitalProtocolNo");
        redirectProperty(this.NamePerson, "Text", this.__ttObject, "Episode.Patient.FullName");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 16;

        this.DrugOrderTab = new TTVisual.TTTabPage();
        this.DrugOrderTab.DisplayIndex = 0;
        this.DrugOrderTab.TabIndex = 0;
        this.DrugOrderTab.Text = i18n("M16287", "İlaç");
        this.DrugOrderTab.Name = "DrugOrderTab";

        this.InpatientDrugOrders = new TTVisual.TTGrid();
        this.InpatientDrugOrders.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InpatientDrugOrders.Name = "InpatientDrugOrders";
        this.InpatientDrugOrders.TabIndex = 0;
        this.InpatientDrugOrders.Height = 350;
        this.InpatientDrugOrders.AllowUserToDeleteRows = false;
        this.InpatientDrugOrders.AllowUserToAddRows = false;

        this.Drug = new TTVisual.TTListBoxColumn();
        this.Drug.ListDefName = "DrugList";
        this.Drug.DataMember = "DrugOrder.Material";
        this.Drug.DisplayIndex = 0;
        this.Drug.HeaderText = i18n("M16287", "İlaç");
        this.Drug.Name = "Drug";
        this.Drug.ReadOnly = true;
        this.Drug.Width = 420;

        this.Frequency = new TTVisual.TTEnumComboBoxColumn();
        this.Frequency.DataTypeName = "FrequencyEnum";
        this.Frequency.DataMember = "DrugOrder.Frequency";
        this.Frequency.Required = true;
        this.Frequency.DisplayIndex = 1;
        this.Frequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.Frequency.Name = "Frequency";
        this.Frequency.Width = 120;

        this.DoseAmount = new TTVisual.TTTextBoxColumn();
        this.DoseAmount.DataMember = "DrugOrder.DoseAmount";
        this.DoseAmount.Required = true;
        this.DoseAmount.DisplayIndex = 2;
        this.DoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmount.Name = "DoseAmount";
        this.DoseAmount.Width = 120;

        this.Day = new TTVisual.TTTextBoxColumn();
        this.Day.DataMember = "DrugOrder.Day";
        this.Day.Required = true;
        this.Day.DisplayIndex = 3;
        this.Day.HeaderText = i18n("M14998", "Gün");
        this.Day.Name = "Day";
        this.Day.Width = 120;

        this.UsageNote = new TTVisual.TTTextBoxColumn();
        this.UsageNote.DataMember = "DrugOrder.UsageNote";
        this.UsageNote.DisplayIndex = 4;
        //this.UsageNote.HeaderText = i18n("M17992", "Kullanma Tarifi");
        this.UsageNote.HeaderText = i18n("M10469", "Açıklama");
        this.UsageNote.Name = "UsageNote";
        this.UsageNote.ReadOnly = true;
        this.UsageNote.Width = 270;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 5;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.ReadOnly = true;
        this.Description.Visible = false;
        this.Description.Width = 320;

        this.NamePerson = new TTVisual.TTTextBox();
        this.NamePerson.BackColor = "#F0F0F0";
        this.NamePerson.ReadOnly = true;
        this.NamePerson.Name = "NamePerson";
        this.NamePerson.TabIndex = 0;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 3;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = "#F0F0F0";
        this.ID.ReadOnly = true;
        this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ID.Name = "ID";
        this.ID.TabIndex = 0;

        this.labelNamePerson = new TTVisual.TTLabel();
        this.labelNamePerson.Text = i18n("M15133", "Hasta Adı Soyadı");
        this.labelNamePerson.Name = "labelNamePerson";
        this.labelNamePerson.TabIndex = 1;

        this.FromResource = new TTVisual.TTObjectListBox();
        this.FromResource.ReadOnly = true;
        this.FromResource.ListDefName = "ResourceListDefinition";
        this.FromResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FromResource.Name = "FromResource";
        this.FromResource.TabIndex = 7;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16866", "İşlem No");
        this.labelID.BackColor = "#DCDCDC";
        this.labelID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelID.ForeColor = "#000000";
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 10;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 1;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.BackColor = "#DCDCDC";
        this.labelActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelActionDate.ForeColor = "#000000";
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 11;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 15;

        this.labelMasterResource = new TTVisual.TTLabel();
        this.labelMasterResource.Text = i18n("M14857", "Gönderen Bölüm");
        this.labelMasterResource.BackColor = "#DCDCDC";
        this.labelMasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMasterResource.ForeColor = "#000000";
        this.labelMasterResource.Name = "labelMasterResource";
        this.labelMasterResource.TabIndex = 12;

        this.InpatientDrugOrdersColumns = [this.Drug, this.Frequency, this.DoseAmount, this.Day, this.UsageNote, this.Description];
        this.tttabcontrol1.Controls = [this.DrugOrderTab];
        this.DrugOrderTab.Controls = [this.InpatientDrugOrders];
        this.Controls = [this.tttabcontrol1, this.DrugOrderTab, this.InpatientDrugOrders, this.Drug, this.Frequency, this.DoseAmount, this.Day, this.UsageNote, this.Description, this.NamePerson, this.ProtocolNo, this.ID, this.labelNamePerson, this.FromResource, this.labelID, this.ActionDate, this.labelActionDate, this.labelProtocolNo, this.labelMasterResource];

    }


}
