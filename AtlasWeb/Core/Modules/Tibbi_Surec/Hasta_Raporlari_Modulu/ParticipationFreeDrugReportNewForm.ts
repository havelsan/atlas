//$FC84A6FB
import { Component, ViewChild, OnInit, HostListener, Input, NgZone, EventEmitter, ApplicationRef, ChangeDetectorRef } from '@angular/core';
import { ParticipationFreeDrugReportNewFormViewModel, EtkinMaddeListModel, AddedDiagnosisListModel, TeshisListModel, EtkenMaddeTeshisListModel, MedulaResult, DrugReportApproveModel, SendSignedReport_Input, SendSignedReportDelete_Input, SendSignedReportApproveModel, SendSignedReportAddDescription_Input, SendSignedReportAddDiagnosis_Input, SendSignedReportAddTeshis_Input, SendSignedReportAddEtkinMadde_Input, UserTemplateModel, TeshisImzalanacakXml } from './ParticipationFreeDrugReportNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EtkinMadde } from 'NebulaClient/Model/AtlasClientModel';
import { FrequencyEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { IlacRaporuServis } from 'NebulaClient/Services/External/IlacRaporuServis';
import { MedulaReportResult } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ParticipationFreeDrgGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ParticipatnFreeDrugReport } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PeriodUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ReportApproveTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { Teshis } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { UsageDoseUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PeriodUnitTypeWithUndefiniteEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ITTGridRow } from 'NebulaClient/Visual/ControlInterfaces/TTGrid/ITTGridRow';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { DxPopoverComponent, DxDataGridComponent, DxSelectBoxComponent } from 'devextreme-angular';
import { ModalInfo, ModalActionResult, ModalStateService } from "Fw/Models/ModalInfo";
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';

import { ReportDiagnosisForm } from "Modules/Tibbi_Surec/Tani_Modulu/ReportDiagnosisForm";
import { UsernamePwdInput, UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { UsernamePwdFormViewModel } from 'Fw/Components/UsernamePwdFormComponent';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { ITTGridCell } from 'NebulaClient/Visual/TTVisualControlInterfaces';

@Component({
    selector: 'ParticipationFreeDrugReportNewForm',
    templateUrl: './ParticipationFreeDrugReportNewForm.html',
    providers: [MessageService, { provide: IESignatureService, useClass: ESignatureService }],
    outputs: ['OnClosing']
})
export class ParticipationFreeDrugReportNewForm extends TTVisual.TTForm implements OnInit {
    @ViewChild('scrollPanel') ScrollPanel: HTMLElement;
    @ViewChild('TemplateCombo') TemplateCombo: DxSelectBoxComponent;
    ActiveIngredientTab: TTVisual.ITTTabPage;
    AddToHistory: TTVisual.ITTCheckBoxColumn;
    btn1Year: TTVisual.ITTButton;
    btn2Years: TTVisual.ITTButton;
    btn3Months: TTVisual.ITTButton;
    btn6Months: TTVisual.ITTButton;
    btnAciklamaEkle: TTVisual.ITTButton;
    btnDeleteTemplate: TTVisual.ITTButton;
    btnEtkinMaddeEkle: TTVisual.ITTButton;
    btnGridAciklamaEkle: TTVisual.ITTButtonColumn;
    btnGridEtkinMaddeEkle: TTVisual.ITTButtonColumn;
    btnGridTaniEkle: TTVisual.ITTButtonColumn;
    btnGridTeshisEkle: TTVisual.ITTButtonColumn;
    btnHastaIlacRaporuListesi: TTVisual.ITTButton;
    btnIkinciTabipOnay: TTVisual.ITTButton;
    btnLoadFromSection: TTVisual.ITTButton;
    btnLoadFromUser: TTVisual.ITTButton;
    btnMedulaBashekimOnay: TTVisual.ITTButton;
    btnOnay: TTVisual.ITTButtonColumn;
    btnOnayIptal: TTVisual.ITTButtonColumn;
    btnRaporKaydet: TTVisual.ITTButton;
    btnRaporuSil: TTVisual.ITTButtonColumn;
    btnInfo: TTVisual.ITTButtonColumn;
    btnSaveAsTemplate: TTVisual.ITTButton;
    btnTaniEkle: TTVisual.ITTButton;
    btnTeshisEkle: TTVisual.ITTButton;
    btnUcuncuTabipOnay: TTVisual.ITTButton;
    chkTumTeshisler: TTVisual.ITTCheckBoxColumn;
    cmbEklenecekDozAraligi: TTVisual.ITTEnumComboBox;
    cmbEklenecekDozBirimi: TTVisual.ITTEnumComboBox;
    cmdEkelenecekPeriyodBirimi: TTVisual.ITTEnumComboBox;
    CommitteeReport: TTVisual.ITTCheckBox;
    TaniListesi: TTVisual.ITTObjectListBox;
    EklenecekTaniListesi: TTVisual.ITTObjectListBox;
    DayParticipationFreeDrgGrid: TTVisual.ITTTextBoxColumn;
    Diagnose: TTVisual.ITTListBoxColumn;
    DiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    DiagnosisEntryTab: TTVisual.ITTTabPage;
    DiagnosisTab: TTVisual.ITTTabControl;
    DrugName: TTVisual.ITTTextBoxColumn;
    EtkinMaddeParticipationFreeDrgGrid: TTVisual.ITTListBoxColumn;
    ExaminationDate: TTVisual.ITTDateTimePicker;
    FindingsAndTests: TTVisual.ITTTabPage;
    FreeDiagnosis: TTVisual.ITTTextBoxColumn;
    FrequencyParticipationFreeDrgGrid: TTVisual.ITTEnumComboBoxColumn;
    gridAddedDiagnosis: TTVisual.ITTGrid;
    GridDiagnosis: TTVisual.ITTGrid;
    gridTeshisEkleTanilari: TTVisual.ITTListBoxColumn;
    IlacEtkinMadde: TTVisual.ITTButtonColumn;
    IsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    labelPatientApprovalFormNo: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelReportEndDate: TTVisual.ITTLabel;
    labelReportStartDate: TTVisual.ITTLabel;
    listSecondDoctor: TTVisual.ITTObjectListBox;
    lstDiagnoseAddedToTeshis: TTVisual.ITTObjectListBox;
    lstDiagnosisAddedToEpisode: TTVisual.ITTObjectListBox;
    lstEklenecekEtkinMadde: TTVisual.ITTObjectListBox;
    EtkinMaddeList: TTVisual.ITTObjectListBox;
    lstTeshisAddedToDiagnosis: TTVisual.ITTObjectListBox;
    MedulaDoseParticipationFreeDrgGrid: TTVisual.ITTTextBoxColumn;
    MedulaReportResults: TTVisual.ITTGrid;
    ParticipationFreeDrugs: TTVisual.ITTGrid;
    PatientApprovalFormNo: TTVisual.ITTMaskedTextBox;
    PatientEnterprise: TTVisual.ITTTextBox;
    PeriodUnitTypeParticipationFreeDrgGrid: TTVisual.ITTEnumComboBoxColumn;
    private kodu: string;
    //private tanilar: Array<TaniListesi>;
    private teshis: Teshis;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProtocolNumber: TTVisual.ITTTextBox;
    ReportChasingNoMedulaReportResult: TTVisual.ITTTextBoxColumn;
    ReportEndDate: TTVisual.ITTDateTimePicker;
    ReportNumberMedulaReportResult: TTVisual.ITTTextBoxColumn;
    ReportRowNumberMedulaReportResult: TTVisual.ITTTextBoxColumn;
    ReportStartDate: TTVisual.ITTDateTimePicker;
    ResponsibleUser: TTVisual.ITTListBoxColumn;
    ResultCodeMedulaReportResult: TTVisual.ITTTextBoxColumn;
    ResultExplanationMedulaReportResult: TTVisual.ITTTextBoxColumn;
    SendReportDateMedulaReportResult: TTVisual.ITTDateTimePickerColumn;
    SocialInsurance: TTVisual.ITTTextBox;
    SUTRules: TTVisual.ITTButtonColumn;
    tabAciklamaEkle: TTVisual.ITTTabPage;
    tabEtkinMaddeEkle: TTVisual.ITTTabPage;
    tabIlacRaporlari: TTVisual.ITTTabPage;
    tabTaniEkle: TTVisual.ITTTabPage;
    tabTeshisEkle: TTVisual.ITTTabPage;
    Teshis: TTVisual.ITTListBoxColumn;
    TeshisEndDate: TTVisual.ITTDateTimePicker;
    TeshistStartDate: TTVisual.ITTDateTimePicker;
    TestsAndSigns: TTVisual.ITTRichTextBoxControl;
    ThirdDoctor: TTVisual.ITTObjectListBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel19: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel20: TTVisual.ITTLabel;
    ttlabel21: TTVisual.ITTLabel;
    ttlabel22: TTVisual.ITTLabel;
    ttlabel23: TTVisual.ITTLabel;
    ttlabel24: TTVisual.ITTLabel;
    ttlabel25: TTVisual.ITTLabel;
    ttlabel26: TTVisual.ITTLabel;
    ttlabel27: TTVisual.ITTLabel;
    ttlabel28: TTVisual.ITTLabel;
    ttlabel29: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel30: TTVisual.ITTLabel;
    ttlabel31: TTVisual.ITTLabel;
    ttlabel32: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttrichtextboxAciklama: TTVisual.ITTRichTextBoxControl;
    ttrtbTumRaporlar: TTVisual.ITTRichTextBoxControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabHastaKatilimPayindanMuafIlacRaporu: TTVisual.ITTTabPage;
    tttabIslemler: TTVisual.ITTTabControl;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextbox7: TTVisual.ITTTextBox;
    txtRaporSuresi: TTVisual.ITTTextBox;
    txtAciklamaEkleAciklama: TTVisual.ITTTextBox;
    txtAciklamaEkleSonucMesaji: TTVisual.ITTTextBox;
    txtAciklamaEkleTakipFormuNo: TTVisual.ITTTextBox;
    txtEklenecekDoz: TTVisual.ITTTextBox;
    txtEklenecekDoz2: TTVisual.ITTTextBox;
    txtEklenecekPeriyodu: TTVisual.ITTTextBox;
    txtEtkinMaddeEkleSonucKodu: TTVisual.ITTTextBox;
    txtEtkinMaddeEkleSonucMesaji: TTVisual.ITTTextBox;
    txtTaniEkleSonucKodu: TTVisual.ITTTextBox;
    txtTaniEkleSonucMesaji: TTVisual.ITTTextBox;
    txtTeshisEkleSonucKodu: TTVisual.ITTTextBox;
    txtTeshisEkleSonucMesaji: TTVisual.ITTTextBox;
    UsageDoseUnitTypeParticipationFreeDrgGrid: TTVisual.ITTEnumComboBoxColumn;
    aciklamaEkleSelected: boolean = false;
    taniEkleSelected: boolean = false;
    medulaResult: boolean = false;
    teshisSelected: boolean = false;
    etkinMaddeEkleSelected: boolean = false;
    tumRaporlarSelected: boolean = false;
    sended: boolean = false;
    bashekimOnay: boolean = false;
    ikinciTabipOnay: boolean = false;
    ucuncuTabipOnay: boolean = false;
    ilkTabipOnay: boolean = false;
    medulayaGonder: boolean = true;
    public IsNewState: boolean = false;
    public SaveAndSendMedula: boolean = false;
    public IsCancelState: boolean = false;
    public CanPrint: boolean = false;
    public IsBackState: boolean = false;
    public IsTakeProvision: boolean = false;
    public IsDelete: boolean = false;
    public MedulaDetailedResult: string = "";
    cmbRaporSureTuru: TTVisual.ITTEnumComboBox;
    TaniTeshisColumns = [];
    EtkinMaddeColumns = [];
    public taniDefArray: Array<any> = [];
    public taniDefCache: any;
    public teshisDefArray: Array<any> = [];
    public teshisDefCache: any;
    public dozAraligiCache2: Array<any> = [];
    public dozAraligiCache: any;
    public dozAraligiArray: Array<any> = [];
    public etkinMaddeCache: any;
    public etkinMaddeArray: Array<any> = [];
    public dozBirimiCache2: Array<any> = [];
    public dozBirimiCache: any;
    public dozBirimiArray: Array<any> = [];
    public periyodBirimiCache2: Array<any> = [];
    public periyodBirimiCache: any;
    public periyodBirimiArray: Array<any> = [];
    public selectedDiagnosisList: Array<AddedDiagnosisListModel>;
    public selectedTeshisTaniList: Array<AddedDiagnosisListModel> = new Array<AddedDiagnosisListModel>();
    public selectedTeshis: TeshisListModel = new TeshisListModel();
    public selectedReportDiagnosisList: Array<Guid> = new Array<Guid>();
    openedReportAsPopUp: boolean = false;
    showMedulaerrorsPopup: boolean = false;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public MedulaSonucMesaji: string = "";
    labelTabip2: string;
    labelTabip3: string;
    public bagliTakipNo: string = '';
    public bagliTakipAlinacakSEPid: any;
    public showBagliTakipAlPopup = false;
    public showReportDiagnosis = false;
    public gridAddedDiagnosisColumns = [];
    public GridDiagnosisColumns = [];
    public MedulaReportResultsColumns = [];
    public ParticipationFreeDrugsColumns = [];
    public enableMedulaPasswordEntrance: boolean = false;
    public enableStartDateBounds: boolean = false;

    /*Paket Tanımı */



    public selectedUserTemplate;
    public userTemplateName;
    /*Paket Tanımı Son */

    public ReportDurationComboItems;

    public medulaReportResultGridColumns = [];

    public lastSelectedCell;

    @ViewChild(DxPopoverComponent) popOver: DxPopoverComponent;
    @ViewChild('EtkinMaddeGrid') etkinMaddeGrid: DxDataGridComponent;

    OnClosing: EventEmitter<Boolean> = new EventEmitter<any>();

    public diabetTeshisArray = [
        '246',
        '247',
        '50',
        '51',
        '52',
        '53',
        '54',
        '55',
        '56',
        '244',
        '271',
        '226',
        '206'
    ];

    public diabetTeshis07_02_1_Array = [
        '246',
        '247',
        '50',
        '51',
        '52',
        '53',
        '54',
        '55',
        '56',
        '244',
        '271'
    ];

    private ParticipationFreeDrugReportNewForm_DocumentUrl: string = '/api/ParticipatnFreeDrugReportService/ParticipationFreeDrugReportNewForm';
    private ParticipatnFreeDrugReportNewFormPre_DocumentUrl: string = '/api/ParticipatnFreeDrugReportService/ParticipatnFreeDrugReportFormPre';
    private ParticipatnFreeDrugReportNewFormEmpty_DocumentUrl: string = '/api/ParticipatnFreeDrugReportService/ParticipatnFreeDrugReportFormEmpty';

    public participationFreeDrugReportNewFormViewModel: ParticipationFreeDrugReportNewFormViewModel = new ParticipationFreeDrugReportNewFormViewModel();
    public get _ParticipatnFreeDrugReport(): ParticipatnFreeDrugReport {
        return this._TTObject as ParticipatnFreeDrugReport;
    }
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private modalStateService: ModalStateService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone,
        protected modalService: IModalService,
        public signService: IESignatureService) {
        super('PARTICIPATNFREEDRUGREPORT', 'ParticipationFreeDrugReportNewForm');
        this._DocumentServiceUrl = this.ParticipationFreeDrugReportNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

        this.ReportDurationComboItems = [
            {
                key: "0",
                value: "3 Ay"
            },
            {
                key: "1",
                value: "6 Ay"
            },
            {
                key: "2",
                value: "1 Yıl"
            },
            {
                key: "3",
                value: "2 Yıl"
            },

        ];
        this.medulaReportResultGridColumns = [
            {
                caption: 'Rapor Takip No',
                dataField: 'ReportChasingNo',
                allowEditing: true,
                width: 100
            },
            {
                caption: 'Rapor No',
                dataField: 'ReportNumber',
                allowEditing: false,
                width: 80
            },
            {
                caption: 'Rapor Sıra No',
                dataField: 'ReportRowNumber',
                allowEditing: false,
                width: 100
            },
            {
                caption: 'Sonuç Kodu',
                dataField: 'ResultCode',
                allowEditing: false,
                width: 90
            },
            {
                caption: 'Sonuç Açıklaması',
                dataField: 'ResultExplanation',
                allowEditing: false,
                width: 400
            },
            {
                caption: 'Detay',
                dataField: '',
                cellTemplate: 'detailButtonTemplate',
                Name: 'btnInfo',
                //width: 400
            },
            {
                caption: 'Sil',
                dataField: '',
                cellTemplate: 'deleteButtonTemplate',
                Name: 'btnRaporuSil',
                //width: 400
            },
            {
                caption: 'Açıklama Ekle',
                dataField: '',
                cellTemplate: 'addDescriptionButtonTemplate',
                Name: 'btnGridAciklamaEkle',
                //width: 400
            },
            {
                caption: 'Tani Ekle',
                dataField: '',
                cellTemplate: 'addDiagnosisButtonTemplate',
                Name: 'btnGridTaniEkle',
                //width: 400
            },
            {
                caption: 'Teshis Ekle',
                dataField: '',
                cellTemplate: 'addTeshisButtonTemplate',
                Name: 'btnGridTeshisEkle',
                //width: 400
            },
            {
                caption: 'Etkin Madde Ekle',
                dataField: '',
                cellTemplate: 'addEtkinMaddeButtonTemplate',
                Name: 'btnGridEtkinMaddeEkle',
                //width: 400
            }

        ]
    }

    private _modalInfo: ModalInfo;

    public setInputParam(value: ParticipatnFreeDrugReport) {
        if (value != null && !value.IsNew) {
            this.ObjectID = value.ObjectID;
        }
        if (value != null)
            this.openedReportAsPopUp = true;
        else
            this.openedReportAsPopUp = false;
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    @Input() set ParticipationFreeDrugReportNewFormRep(value: ParticipatnFreeDrugReport) {
        if (value != null) {
            this.ObjectID = value.ObjectID as Guid;

        }


    }

    private _reportActiveIDsModel: ActiveIDsModel;
    @Input() set ReportActiveIDsModel(value: ActiveIDsModel) {
        this._reportActiveIDsModel = value;
        this.ActiveIDsModel = value
    }
    get reportActiveIDsModel(): ActiveIDsModel {
        return this._reportActiveIDsModel;
    }

    /*Paket Tanımı Fonksiyonlar */

    async SelectUserTemplate(event: any): Promise<void> {
        if (event.itemData != null) {

            if (this.participationFreeDrugReportNewFormViewModel.selectedUserTemplate == null || (this.participationFreeDrugReportNewFormViewModel.selectedUserTemplate.ObjectID != event.itemData.ObjectID)) {
                this.participationFreeDrugReportNewFormViewModel.selectedUserTemplate = event.itemData;
                const that = this;
                this.loadPanelOperation(true, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
                that.loadReportByTemplate();
                this.loadPanelOperation(false, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
                //this.onProcedureDoctorChanged(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ProcedureDoctor);
            }
        }

    }

    async btnAddUserTemplate_Click(): Promise<void> {
        try {
            if (this.userTemplateName != null || (this.userTemplateName != null && !this.userTemplateName.toString().isNullOrEmpty())) {
                let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

                savedUserTemplate.Description = this.userTemplateName;
                savedUserTemplate.TAObjectDefID = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ObjectDefID;
                savedUserTemplate.TAObjectID = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ObjectID;

                let apiUrl: string = 'api/ParticipatnFreeDrugReportService/SaveParticipatnFreeDrugReportUserTemplate';
                this.loadPanelOperation(true, 'Şablon Kaydediliyor, Lütfen Bekleyiniz');
                await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                    this.participationFreeDrugReportNewFormViewModel.userTemplateList = result;
                    this.participationFreeDrugReportNewFormViewModel.selectedUserTemplate = null;
                    this.userTemplateName = "";
                    ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Oluşturuldu");
                });
                this.loadPanelOperation(false, '');
            } else {
                ServiceLocator.MessageService.showError("Şablon ismi girmeden yeni şablon oluşturamazsınız");
            }


        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    async btnClearUserTemplate_Click(): Promise<void> {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Şablon Temizlenerek Boş bir Form Açılacaktır. Devam Etmek İstiyor Musunuz? "), 1);
        if (result === "H")
            return;
        this.loadPanelOperation(true, 'Form Açılıyor, Lütfen Bekleyiniz');

        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.IsNew) {
            this.LoadEmptyForm();
        } else {
            this.loadReportByID(this._ParticipatnFreeDrugReport.ObjectID);
        }
        this.loadPanelOperation(false, '');

        this.TemplateCombo.value = null;
        this.selectedUserTemplate = null;
        this.participationFreeDrugReportNewFormViewModel.selectedUserTemplate = null;
    }

    async btnDeleteSelectedUserTemplate_Click(): Promise<void> {
        try {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Şablon Sistemden Silinecektir!! Devam Etmek İstiyor Musunuz ? "), 1);
            if (result === "H")
                return;
            let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

            savedUserTemplate.ObjectID = this.participationFreeDrugReportNewFormViewModel.selectedUserTemplate.ObjectID;
            savedUserTemplate.TAObjectDefID = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ObjectDefID;
            let apiUrl: string = 'api/ParticipatnFreeDrugReportService/SaveParticipatnFreeDrugReportUserTemplate';
            this.loadPanelOperation(true, 'Şablon Siliniyor, Lütfen Bekleyiniz');
            await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                this.participationFreeDrugReportNewFormViewModel.userTemplateList = result;
                this.participationFreeDrugReportNewFormViewModel.selectedUserTemplate = null;
                this.userTemplateName = "";
                ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Silindi");
            });
            this.loadPanelOperation(false, '');

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }


    /*Paket Tanımı Fonksiyonlar */

    public async LoadForm() {
        let that = this;
        let promiseArray: Array<Promise<any>> = new Array<any>();
        promiseArray.push(this.DozAraligi());
        promiseArray.push(this.DozBirimi());
        promiseArray.push(this.PeriyodBirimi());
        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            //that.taniDefArray = sonuc[0];
            // that.teshisDefArray = sonuc[1];
            that.dozAraligiArray = sonuc[0];
            //that.etkinMaddeArray = sonuc[3];
            that.dozBirimiArray = sonuc[1];
            that.periyodBirimiArray = sonuc[2];

            //  that.GenerateTaniTeshisColumns();
            that.GeneratEtkinMaddeColumns();
            this.load(ParticipationFreeDrugReportNewFormViewModel);

        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
            TTVisual.InfoBox.Alert("Uyarı", error, MessageIconEnum.ErrorMessage);
        });


        let enableMedulaPasswordEntrance: string = (await SystemParameterService.GetParameterValue('MEDULASIFREGIRISEKRANIAKTIF', 'FALSE'));
        if (enableMedulaPasswordEntrance === 'TRUE') {
            this.enableMedulaPasswordEntrance = true;
        }
        else {
            this.enableMedulaPasswordEntrance = false;
        }

        let enableStartDateBounds: string = (await SystemParameterService.GetParameterValue('RAPORBASLANGICTARIHISINIR', 'FALSE'));
        if (enableStartDateBounds === 'TRUE') {
            this.enableStartDateBounds = true;
        }
        else {
            this.enableStartDateBounds = false;
        }
    }

    async ngOnInit() {
        if (this.ObjectID != null) {
            this.LoadForm();
        }
        else {
            await this.LoadEmptyForm();
            this.LoadForm();
        }
    }

    async LoadEmptyForm() {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";
            fullApiUrl = this.ParticipatnFreeDrugReportNewFormEmpty_DocumentUrl;

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.post<ParticipationFreeDrugReportNewFormViewModel>(fullApiUrl, this.reportActiveIDsModel, ParticipationFreeDrugReportNewFormViewModel);

            this._ViewModel = response;

            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
            //await this.Report.getReadOnlyDiagnosis();
            await this.SetButtonVisibility();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }
    protected async loadReportByID(objectID: Guid) {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";

            if (objectID != null) {
                fullApiUrl = this.ParticipatnFreeDrugReportNewFormPre_DocumentUrl + '/?id=' + objectID;
            }
            else {
                fullApiUrl = `${this.ParticipatnFreeDrugReportNewFormPre_DocumentUrl}/${Guid.Empty}`;
            }

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<ParticipationFreeDrugReportNewFormViewModel>(fullApiUrl, ParticipationFreeDrugReportNewFormViewModel);
            this._ViewModel = response;


            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
            //await this.Report.getReadOnlyDiagnosis();
            await this.SetButtonVisibility();
            this.etkinMaddeGrid.instance.refresh();
            if (this.TemplateCombo != null)
                this.TemplateCombo.value = null;
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    protected async loadReportByTemplate() {
        try {


            let fullApiUrl: string = "";


            fullApiUrl = "/api/ParticipatnFreeDrugReportService/ParticipatnFreeDrugReportFormTemplate";

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.post<ParticipationFreeDrugReportNewFormViewModel>(fullApiUrl, this.participationFreeDrugReportNewFormViewModel, ParticipationFreeDrugReportNewFormViewModel);
            this.initViewModel();
            this.initFormControls();
            //this.selectedUserTemplate = null;
            this._ViewModel = response;


            this.loadViewModel();

            await this.ClientSidePreScript();
            await this.PreScript();
            //await this.Report.getReadOnlyDiagnosis();
            await this.SetButtonVisibility();
            this.etkinMaddeGrid.instance.refresh();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    async SetButtonVisibility() {
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New.id) {
            this.IsBackState = false;
            this.IsCancelState = true;
            this.IsTakeProvision = true;
            this.IsNewState = true;
            this.SaveAndSendMedula = true;
            this.bashekimOnay = false;
            this.ikinciTabipOnay = false;
            this.ucuncuTabipOnay = false;
            this.IsDelete = false;
            this.ilkTabipOnay = false;
        }
        else if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Report.id) {
            this.IsBackState = false;
            this.IsCancelState = true;
            this.IsTakeProvision = true;
            this.IsNewState = false;
            this.SaveAndSendMedula = true;
            this.bashekimOnay = false;
            this.ikinciTabipOnay = false;
            this.ucuncuTabipOnay = false;
            this.IsDelete = false;
            this.ilkTabipOnay = false;
        }
        else if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Completed.id) {
            this.IsCancelState = false;
            this.IsBackState = true;
            this.IsTakeProvision = false;
            this.IsNewState = false;
            this.SaveAndSendMedula = false;
            this.IsDelete = true;
            this.bashekimOnay = false;
            this.ikinciTabipOnay = false;
            this.ilkTabipOnay = true;
            //if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CommitteeReport)
            //    this.ikinciTabipOnay = true;
            //else {
            //    this.ikinciTabipOnay = false;
            //    this.bashekimOnay = true;
            //}

            this.ucuncuTabipOnay = false;
        }
        else if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval.id) {
            this.IsBackState = true;
            this.IsCancelState = false;
            this.IsTakeProvision = false;
            this.IsNewState = false;
            this.SaveAndSendMedula = false;
            this.bashekimOnay = true;
            this.ikinciTabipOnay = false;
            this.ucuncuTabipOnay = false;
            this.IsDelete = true;
            this.ilkTabipOnay = false;
        }
        else if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval.id) {
            this.IsCancelState = false;
            this.IsBackState = true;
            this.IsTakeProvision = false;
            this.IsNewState = false;
            this.SaveAndSendMedula = false;
            this.bashekimOnay = false;
            this.ikinciTabipOnay = true;
            this.ucuncuTabipOnay = true;
            this.IsDelete = true;
            this.ilkTabipOnay = false;
        }
        else if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ThirdDoctorApproval.id) {
            this.IsBackState = true;
            this.IsCancelState = false;
            this.IsTakeProvision = false;
            this.IsNewState = false;
            this.SaveAndSendMedula = false;
            this.bashekimOnay = false;
            this.ucuncuTabipOnay = true;
            this.ikinciTabipOnay = true;
            this.IsDelete = false;
            this.ilkTabipOnay = false;
        }
        else if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Cancelled.id) {
            this.IsBackState = false;
            this.IsCancelState = false;
            this.IsTakeProvision = false;
            this.IsNewState = false;
            this.SaveAndSendMedula = false;
            this.bashekimOnay = false;
            this.ucuncuTabipOnay = false;
            this.ikinciTabipOnay = false;
            this.IsDelete = false;
            this.ilkTabipOnay = false;
        }
        else if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ReportCompleted.id) {
            this.IsBackState = true;
            this.IsCancelState = false;
            this.IsTakeProvision = false;
            this.IsNewState = false;
            this.SaveAndSendMedula = false;
            this.bashekimOnay = false;
            this.ikinciTabipOnay = false;
            this.ucuncuTabipOnay = false;
            this.IsDelete = false;
            this.ilkTabipOnay = false;
        }
    }

    // ***** Method declarations start *****
    public actionIdForDemografic(): Guid {
        if (this._ParticipatnFreeDrugReport.MasterAction != null) {
            if (typeof this._ParticipatnFreeDrugReport.MasterAction === "string") {
                return this._ParticipatnFreeDrugReport.MasterAction;
            }
            else {
                return this._ParticipatnFreeDrugReport.MasterAction.ObjectID;
            }
        }

        return this._ParticipatnFreeDrugReport.ObjectID;
    }
    public async btndiagnosis_Click(): Promise<void> {
        this.showReportDiagnosis = true;

        // await this.Report.getReadOnlyDiagnosis();

    }
    public async btn1Year_Click(): Promise<void> {
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate != null) {
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate.AddYears(1);
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration = 1;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDurationType = PeriodUnitTypeWithUndefiniteEnum.YearPeriod;

        }
        else {
            TTVisual.InfoBox.Alert("Uyarı", i18n("M18392", "Lütfen Rapor Başlangıç Tarihini Giriniz!"), MessageIconEnum.WarningMessage);
        }
    }
    public async btn2Years_Click(): Promise<void> {
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate != null) {
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate.AddYears(2);
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration = 2;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDurationType = PeriodUnitTypeWithUndefiniteEnum.YearPeriod;

        }
        else {
            TTVisual.InfoBox.Alert("Uyarı", i18n("M18392", "Lütfen Rapor Başlangıç Tarihini Giriniz!"), MessageIconEnum.WarningMessage);
        }
    }
    public async btn3Months_Click(): Promise<void> {
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate != null) {
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate.AddMonths(3);

            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration = 3;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDurationType = PeriodUnitTypeWithUndefiniteEnum.MonthPeriod;

        }
        else {
            TTVisual.InfoBox.Alert("Uyarı", i18n("M18392", "Lütfen Rapor Başlangıç Tarihini Giriniz!"), MessageIconEnum.WarningMessage);
        }
    }
    public async btn6Months_Click(): Promise<void> {
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate != null) {
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate.AddMonths(6);
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration = 6;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDurationType = PeriodUnitTypeWithUndefiniteEnum.MonthPeriod;

        }
        else {
            TTVisual.InfoBox.Alert("Uyarı", i18n("M18392", "Lütfen Rapor Başlangıç Tarihini Giriniz!"), MessageIconEnum.WarningMessage);
        }
    }
    public selectReportDuration(event: any) {
        if (event.itemData != null) {
            if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate != null) {
                if (event.itemData.key == "0" || event.itemData.key == "1") { //3 - 6 - 1 - 2
                    let month = 3 * (+event.itemData.key + 1);
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate.AddMonths(month);
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration = month;
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDurationType = PeriodUnitTypeWithUndefiniteEnum.MonthPeriod;
                } else if (event.itemData.key == "2" || event.itemData.key == "3") { //3 - 6 - 1 - 2
                    let year = +event.itemData.key - 1;
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate.AddYears(year);
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration = year;
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDurationType = PeriodUnitTypeWithUndefiniteEnum.YearPeriod;
                }
            } else {
                TTVisual.InfoBox.Alert("Uyarı", i18n("M18392", "Lütfen Rapor Başlangıç Tarihini Giriniz!"), MessageIconEnum.WarningMessage);
            }
        }
    }
    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public async MedulaPasswordSendPanel(): Promise<void> {
        let userNamePwdInput = new UsernamePwdInput();
        userNamePwdInput.GetMkysUsernameOnInit = false;
        userNamePwdInput.SessionStoragePwdName = 'MedulaPwd';
        userNamePwdInput.SessionStorageUsername = 'MedulaUsername';
        userNamePwdInput.Title = 'E-Rapor Kaydet';
        userNamePwdInput.GetUserUniqueRefNoOnInit = true;
        userNamePwdInput.doNotOpenSavedScreen = true;
        let userNamePwdResult = await UsernamePwdBox.Show(false, userNamePwdInput);
        if ((<ModalActionResult>userNamePwdResult).Result === DialogResult.OK) {
            let params = <UsernamePwdFormViewModel>(<ModalActionResult>userNamePwdResult).Param;
            this.participationFreeDrugReportNewFormViewModel.medulaUsername = params.userName;
            this.participationFreeDrugReportNewFormViewModel.medulaPassword = params.password;
        }
    }

    public async MedulaPasswordApprovePanel(approveModel: DrugReportApproveModel): Promise<void> {
        let userNamePwdInput = new UsernamePwdInput();
        userNamePwdInput.GetMkysUsernameOnInit = false;
        userNamePwdInput.SessionStoragePwdName = 'MedulaPwd';
        userNamePwdInput.SessionStorageUsername = 'MedulaUsername';
        userNamePwdInput.Title = 'E-Rapor Kaydet';
        userNamePwdInput.GetUserUniqueRefNoOnInit = true;
        userNamePwdInput.doNotOpenSavedScreen = true;

        let userNamePwdResult = await UsernamePwdBox.Show(false, userNamePwdInput);
        if ((<ModalActionResult>userNamePwdResult).Result === DialogResult.OK) {
            let params = <UsernamePwdFormViewModel>(<ModalActionResult>userNamePwdResult).Param;
            approveModel.medulaUsername = params.userName;
            approveModel.medulaPassword = params.password;
        }
    }

    public async MedulaPasswordSignedApprovePanel(approveModel: SendSignedReportApproveModel): Promise<void> {
        let userNamePwdInput = new UsernamePwdInput();
        userNamePwdInput.GetMkysUsernameOnInit = false;
        userNamePwdInput.SessionStoragePwdName = 'MedulaPwd';
        userNamePwdInput.SessionStorageUsername = 'MedulaUsername';
        userNamePwdInput.Title = 'E-Rapor Kaydet';
        userNamePwdInput.GetUserUniqueRefNoOnInit = true;
        userNamePwdInput.doNotOpenSavedScreen = true;

        let userNamePwdResult = await UsernamePwdBox.Show(false, userNamePwdInput);
        if ((<ModalActionResult>userNamePwdResult).Result === DialogResult.OK) {
            let params = <UsernamePwdFormViewModel>(<ModalActionResult>userNamePwdResult).Param;
            approveModel.medulaUsername = params.userName;
            approveModel.medulaPassword = params.password;
        }
    }

    public resetSavedPassword() {
        let savePwd = window.sessionStorage.getItem('savePasswordForSession')
        if (savePwd == 'true') {
            window.sessionStorage.setItem('MedulaUsername', '');
            window.sessionStorage.setItem('MedulaPwd', '');
            window.sessionStorage.setItem('savePasswordForSession', 'false');
        }

    }

    public async btnAciklamaEkle_Click(): Promise<void> {
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
        }
        try {
            if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult != null && this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo != null) {

                let eraporAciklamaEkleIstekDVO: IlacRaporuServis.eraporAciklamaEkleIstekDVO = new IlacRaporuServis.eraporAciklamaEkleIstekDVO();
                eraporAciklamaEkleIstekDVO.raporTakipNo = this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo;
                let eraporAciklamaDVO: IlacRaporuServis.eraporAciklamaDVO = new IlacRaporuServis.eraporAciklamaDVO();
                if (this.txtAciklamaEkleTakipFormuNo == null) {
                    ServiceLocator.MessageService.showError(i18n("M10476", "Açıklama Giriniz!"));
                }
                else {
                    eraporAciklamaDVO.aciklama = this.txtAciklamaEkleAciklama.Text;
                    eraporAciklamaDVO.takipFormuNo = this.txtAciklamaEkleTakipFormuNo.Text;
                    eraporAciklamaEkleIstekDVO.eraporAciklamaDVO = eraporAciklamaDVO;
                }

                this.participationFreeDrugReportNewFormViewModel.AciklamaEkleIstekDVO = eraporAciklamaEkleIstekDVO;
                this.participationFreeDrugReportNewFormViewModel.sonucKodu = null;
                this.participationFreeDrugReportNewFormViewModel.sonucMesaji = null;
                this.participationFreeDrugReportNewFormViewModel.uyariMesaji = null;

                await this.signService.showLoginModal();

                let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareSignedReportDescriptionContent', this.participationFreeDrugReportNewFormViewModel);

                let signedContent: string = await this.signService.signContent(signedReportOutput);

                let sendSignedReportAddDescription_Input: SendSignedReportAddDescription_Input = new SendSignedReportAddDescription_Input();
                sendSignedReportAddDescription_Input.signContent = signedContent;
                sendSignedReportAddDescription_Input.viewModel = this.participationFreeDrugReportNewFormViewModel;



                this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                let result = <ParticipationFreeDrugReportNewFormViewModel>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportDescriptionContent', sendSignedReportAddDescription_Input);
                this.loadPanelOperation(false, '');
                this.participationFreeDrugReportNewFormViewModel = result;
                if (result != null && result.sonucKodu === '0000') {
                    this.txtAciklamaEkleSonucMesaji.Text = result.sonucMesaji + " " + result.uyariMesaji + " " + i18n("M16831", "İşlem Başarılı.");
                }
                else {

                    if (result != null && result.sonucKodu == "9107") {
                        this.resetSavedPassword();
                    }
                    if (!String.isNullOrEmpty(result.sonucMesaji)) {
                        this.txtAciklamaEkleSonucMesaji.Text = result.uyariMesaji + " " + result.sonucMesaji + " " + i18n("M20831", "Rapor Onaylanamamıştır.");
                        TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"), MessageIconEnum.ErrorMessage);
                        console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                    }
                }


                const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                await this.loadReportByID(objectIdParam);

                await this.SetFormReadOnlyControls();
                this.showSaveSuccessMessage();

            }
        }
        catch (err) {
            this.loadPanelOperation(false, '');
            console.log(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }

    }

    public async btnTaniEkle_Click(): Promise<void> {
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
        }
        try {
            if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult != null && this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo != null) {

                if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo == null) {
                    console.log(i18n("M20859", "Rapor Takip Nuamarası Giriniz!"));
                    ServiceLocator.MessageService.showError(i18n("M20859", "Rapor Takip Nuamarası Giriniz!"));
                }
                if (this.lstDiagnosisAddedToEpisode == null) {
                    console.log(i18n("M22768", "Tanı Seçiniz!"));
                    ServiceLocator.MessageService.showError(i18n("M22768", "Tanı Seçiniz!"));
                }
                if (this.lstTeshisAddedToDiagnosis == null) {
                    console.log(i18n("M23288", "Teşhis Seçiniz!"));
                    ServiceLocator.MessageService.showError(i18n("M23288", "Teşhis Seçiniz!"));
                }

                let eraporTaniEkleIstekDVO: IlacRaporuServis.eraporTaniEkleIstekDVO = new IlacRaporuServis.eraporTaniEkleIstekDVO();
                eraporTaniEkleIstekDVO.raporTakipNo = this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo;

                let eraporTaniDVO: IlacRaporuServis.eraporTaniDVO = new IlacRaporuServis.eraporTaniDVO();
                eraporTaniDVO.taniKodu = (<DiagnosisDefinition>this.lstDiagnosisAddedToEpisode.SelectedObject).Code;
                eraporTaniDVO.taniAdi = (<DiagnosisDefinition>this.lstDiagnosisAddedToEpisode.SelectedObject).Name;
                eraporTaniEkleIstekDVO.eraporTaniDVO = eraporTaniDVO;

                eraporTaniEkleIstekDVO.raporTeshisKodu = (<Teshis>this.lstTeshisAddedToDiagnosis.SelectedObject).teshisKodu.toString();
                eraporTaniEkleIstekDVO.raporTakipNo = this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo;

                this.participationFreeDrugReportNewFormViewModel.TaniEkleIstekDVO = eraporTaniEkleIstekDVO;
                this.participationFreeDrugReportNewFormViewModel.sonucKodu = null;
                this.participationFreeDrugReportNewFormViewModel.sonucMesaji = null;
                this.participationFreeDrugReportNewFormViewModel.uyariMesaji = null;

                await this.signService.showLoginModal();

                let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareSignedReportDiagnosisContent', this.participationFreeDrugReportNewFormViewModel);

                let signedContent: string = await this.signService.signContent(signedReportOutput);

                let sendSignedReportAddDiagnosis_Input: SendSignedReportAddDiagnosis_Input = new SendSignedReportAddDiagnosis_Input();
                sendSignedReportAddDiagnosis_Input.signContent = signedContent;
                sendSignedReportAddDiagnosis_Input.viewModel = this.participationFreeDrugReportNewFormViewModel;

                this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                let result = <ParticipationFreeDrugReportNewFormViewModel>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportDiagnosisContent', sendSignedReportAddDiagnosis_Input);
                this.loadPanelOperation(false, '');
                this.participationFreeDrugReportNewFormViewModel = result;
                if (result != null && result.sonucKodu === '0000') {
                    this.txtAciklamaEkleSonucMesaji.Text = result.sonucMesaji + " " + result.uyariMesaji + " " + i18n("M16831", "İşlem Başarılı.");
                }
                else {

                    if (result != null && result.sonucKodu == "9107") {
                        this.resetSavedPassword();
                    }
                    if (!String.isNullOrEmpty(result.sonucMesaji)) {
                        this.txtAciklamaEkleSonucMesaji.Text = result.uyariMesaji + " " + result.sonucMesaji + " " + i18n("M20831", "Rapor Onaylanamamıştır.");
                        console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                        //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                        TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"), MessageIconEnum.ErrorMessage);
                    }
                }

                const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                await this.loadReportByID(objectIdParam);

                await this.SetFormReadOnlyControls();
                this.showSaveSuccessMessage();
            }
        }
        catch (err) {
            this.loadPanelOperation(false, '');
            console.log(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    public async btnTeshisEkle_Click(): Promise<void> {
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
        }
        try {
            if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult != null && this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo != null) {
                if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo == null) {
                    console.log(i18n("M20859", "Rapor Takip Nuamarası Giriniz!"));
                    ServiceLocator.MessageService.showError(i18n("M20859", "Rapor Takip Nuamarası Giriniz!"));
                }
                if (this.participationFreeDrugReportNewFormViewModel.AddedDiagnosisList.length == 0) {
                    console.log(i18n("M22768", "Tanı Seçiniz!"));
                    ServiceLocator.MessageService.showError(i18n("M22768", "Tanı Seçiniz!"));
                }
                if (this.lstDiagnoseAddedToTeshis == null) {
                    console.log(i18n("M23288", "Teşhis Seçiniz!"));
                    ServiceLocator.MessageService.showError(i18n("M23288", "Teşhis Seçiniz!"));
                }

                let eraporTeshisEkleIstekDVO: IlacRaporuServis.eraporTeshisEkleIstekDVO = new IlacRaporuServis.eraporTeshisEkleIstekDVO();
                eraporTeshisEkleIstekDVO.raporTakipNo = this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo;

                let eraporTeshisDVO: IlacRaporuServis.eraporTeshisDVO = new IlacRaporuServis.eraporTeshisDVO();
                eraporTeshisDVO.raporTeshisKodu = (<Teshis>this.lstDiagnoseAddedToTeshis.SelectedObject).teshisKodu.toString();
                eraporTeshisEkleIstekDVO.eraporTeshisDVO = eraporTeshisDVO;

                this.participationFreeDrugReportNewFormViewModel.TeshisEkleIstekDVO = eraporTeshisEkleIstekDVO;
                this.participationFreeDrugReportNewFormViewModel.sonucKodu = null;
                this.participationFreeDrugReportNewFormViewModel.sonucMesaji = null;
                this.participationFreeDrugReportNewFormViewModel.uyariMesaji = null;

                let diabetTeshisList = this.participationFreeDrugReportNewFormViewModel.TeshisList.filter(x => this.diabetTeshis07_02_1_Array.includes(x.teshisKodu) || x.teshisKodu == "206" || x.teshisKodu == "226")

                if (diabetTeshisList.length > 0) {
                    this.loadPanelOperation(false, 'Lütfen bekleyiniz.');
                    let diabetFormRes = await this.showDiabetesMellitusForm(this.participationFreeDrugReportNewFormViewModel);
                    if (diabetFormRes.Result == DialogResult.Cancel) {
                        ServiceLocator.MessageService.showError('Kayıt işleminden vazgeçildi.');
                        return;
                    }
                    else {
                        this.loadPanelOperation(true, 'Lütfen bekleyiniz!');
                    }
                }

                await this.signService.showLoginModal();

                let signedReportOutputArray: Array<any> = await this.httpService.post<Array<any>>('/api/ParticipatnFreeDrugReportService/PrepareSignedReportTeshisContent', this.participationFreeDrugReportNewFormViewModel);

                let sendSignedReportAddTeshis_Input: SendSignedReportAddTeshis_Input = new SendSignedReportAddTeshis_Input();

                for (let index = 0; index < signedReportOutputArray.length; index++) {
                    const signedReportOutput = signedReportOutputArray[index];
                    let signedContent: string = await this.signService.signContent(signedReportOutput.imzalanacakXml);

                    let teshisImzalanacakXml = new TeshisImzalanacakXml();
                    teshisImzalanacakXml.imzalanacakXml = signedContent;
                    teshisImzalanacakXml.Type = signedReportOutput.Type;
                    sendSignedReportAddTeshis_Input.signContentList.push(teshisImzalanacakXml);
                }

                await this.signService.showLoginModal();

                let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareSignedReportTeshisContent', this.participationFreeDrugReportNewFormViewModel);

                sendSignedReportAddTeshis_Input.viewModel = this.participationFreeDrugReportNewFormViewModel;

                this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                let result = <ParticipationFreeDrugReportNewFormViewModel>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportTeshisContent', sendSignedReportAddTeshis_Input);

                this.loadPanelOperation(false, '');
                this.participationFreeDrugReportNewFormViewModel = result;
                if (result != null && result.sonucKodu === '0000') {
                    this.txtAciklamaEkleSonucMesaji.Text = result.sonucMesaji + " " + result.uyariMesaji + " " + i18n("M16831", "İşlem Başarılı.");
                }
                else {

                    if (result != null && result.sonucKodu == "9107") {
                        this.resetSavedPassword();
                    }
                    if (!String.isNullOrEmpty(result.sonucMesaji)) {
                        this.txtAciklamaEkleSonucMesaji.Text = result.uyariMesaji + " " + result.sonucMesaji + " " + i18n("M20831", "Rapor Onaylanamamıştır.");
                        console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                        //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                        TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"), MessageIconEnum.ErrorMessage);
                    }

                }

                const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                await this.loadReportByID(objectIdParam);

                await this.SetFormReadOnlyControls();
                this.showSaveSuccessMessage();
            }
        }
        catch (err) {
            this.loadPanelOperation(false, '');
            console.log(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }


    public async btnEtkinMaddeEkle_Click(): Promise<void> {
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
        }
        try {
            if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult != null && this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo != null) {
                if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo == null) {
                    console.log(i18n("M20859", "Rapor Takip Nuamarası Giriniz!"));
                    ServiceLocator.MessageService.showError(i18n("M20859", "Rapor Takip Nuamarası Giriniz!"));
                }
                if (this.lstEklenecekEtkinMadde == null) {
                    console.log(i18n("M13951", "Etkin Madde Seçiniz!"));
                    ServiceLocator.MessageService.showError(i18n("M13951", "Etkin Madde Seçiniz!"));
                }
                if (this.txtEklenecekDoz2 == null) {
                    console.log(i18n("M13287", "Kullanım Doz 2 giriniz"));
                    ServiceLocator.MessageService.showError(i18n("M13287", "Kullanım Doz 2 giriniz"));
                }
                if (this.cmbEklenecekDozBirimi == null) {
                    console.log(i18n("M13291", "Doz Birimi Seçiniz!"));
                    ServiceLocator.MessageService.showError(i18n("M13291", "Doz Birimi Seçiniz!"));
                }
                if (this.cmdEkelenecekPeriyodBirimi == null) {
                    console.log(i18n("M20311", "Periyod Birimi Seçiniz!"));
                    ServiceLocator.MessageService.showError(i18n("M20311", "Periyod Birimi Seçiniz!"));
                }
                if (this.txtEklenecekDoz == null) {
                    console.log(i18n("M13293", "Kullanım Doz 1 giriniz"));
                    ServiceLocator.MessageService.showError(i18n("M13293", "Kullanım Doz 1 giriniz"));
                }
                if (this.txtEklenecekPeriyodu == null) {
                    console.log(i18n("M20321", "Periyodu Giriniz!"));
                    ServiceLocator.MessageService.showError(i18n("M20321", "Periyodu Giriniz!"));
                }

                let eraporEtkinMaddeEkleIstekDVO: IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO = new IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO();
                eraporEtkinMaddeEkleIstekDVO.raporTakipNo = this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo;

                let eraporEtkinMaddeDVO: IlacRaporuServis.eraporEtkinMaddeDVO = new IlacRaporuServis.eraporEtkinMaddeDVO();
                eraporEtkinMaddeDVO.etkinMaddeKodu = (<EtkinMadde>this.lstEklenecekEtkinMadde.SelectedObject).etkinMaddeKodu;
                eraporEtkinMaddeDVO.kullanimDoz1 = this.txtEklenecekDoz.Text;
                eraporEtkinMaddeDVO.kullanimDoz2 = this.txtEklenecekDoz2.Text;
                eraporEtkinMaddeDVO.kullanimDozBirimi = this.cmbEklenecekDozBirimi.SelectedValue.toString();
                eraporEtkinMaddeDVO.kullanimDozPeriyot = this.txtEklenecekPeriyodu.Text;
                eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi = this.cmdEkelenecekPeriyodBirimi.SelectedValue.toString();

                let etkinMaddeDVO: IlacRaporuServis.etkinMaddeDVO = new IlacRaporuServis.etkinMaddeDVO();
                etkinMaddeDVO.kodu = (<EtkinMadde>this.lstEklenecekEtkinMadde.SelectedObject).etkinMaddeKodu;
                etkinMaddeDVO.adi = (<EtkinMadde>this.lstEklenecekEtkinMadde.SelectedObject).etkinMaddeAdi;
                etkinMaddeDVO.icerikMiktari = (<EtkinMadde>this.lstEklenecekEtkinMadde.SelectedObject).icerikMiktari;
                etkinMaddeDVO.formu = (<EtkinMadde>this.lstEklenecekEtkinMadde.SelectedObject).form;
                eraporEtkinMaddeDVO.etkinMaddeDVO = etkinMaddeDVO;

                eraporEtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO = eraporEtkinMaddeDVO;

                this.participationFreeDrugReportNewFormViewModel.EtkinMaddeEkleIstekDVO = eraporEtkinMaddeEkleIstekDVO;
                this.participationFreeDrugReportNewFormViewModel.sonucKodu = null;
                this.participationFreeDrugReportNewFormViewModel.sonucMesaji = null;
                this.participationFreeDrugReportNewFormViewModel.uyariMesaji = null;
                await this.signService.showLoginModal();

                let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareSignedReportEtkinMaddeContent', this.participationFreeDrugReportNewFormViewModel);

                let signedContent: string = await this.signService.signContent(signedReportOutput);

                let sendSignedReportAddEtkinMadde_Input: SendSignedReportAddEtkinMadde_Input = new SendSignedReportAddEtkinMadde_Input();
                sendSignedReportAddEtkinMadde_Input.signContent = signedContent;
                sendSignedReportAddEtkinMadde_Input.viewModel = this.participationFreeDrugReportNewFormViewModel;

                this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                let result = <ParticipationFreeDrugReportNewFormViewModel>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportEtkinMaddeContent', sendSignedReportAddEtkinMadde_Input);
                this.loadPanelOperation(false, '');
                this.participationFreeDrugReportNewFormViewModel = result;
                if (result != null && result.sonucKodu === '0000') {
                    this.txtAciklamaEkleSonucMesaji.Text = result.sonucMesaji + " " + result.uyariMesaji + " " + i18n("M16831", "İşlem Başarılı.");

                }
                else {

                    if (result != null && result.sonucKodu == "9107") {
                        this.resetSavedPassword();
                    }
                    if (!String.isNullOrEmpty(result.sonucMesaji)) {
                        this.txtAciklamaEkleSonucMesaji.Text = result.uyariMesaji + " " + result.sonucMesaji + " " + i18n("M20831", "Rapor Onaylanamamıştır.");
                        console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                        //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                        TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"), MessageIconEnum.ErrorMessage);

                    }
                }

                const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                await this.loadReportByID(objectIdParam);

                await this.SetFormReadOnlyControls();
                this.showSaveSuccessMessage();
            }
        }
        catch (err) {
            this.loadPanelOperation(false, '');
            console.log(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    private async btnChoose_Click(): Promise<void> {
        let a = 1;
    }


    private async btnIkinciTabipOnay_Click(): Promise<void> {

        //TODO : Burcu Test edebilmek için konuldu.
        if (this.participationFreeDrugReportNewFormViewModel.closeMedula) {
            this.loadPanelOperation(true, i18n("M18851", "Lütfen bekleyiniz."));

            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.SecondDoktorApprove;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ThirdDoctorApproval;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.SecondDoctorApproval = 1;
            this.messageService.showSuccess(i18n("M20833", "Rapor Onaylandı."));
            await this.save();
            await this.AfterContextSavedScript(null);
            const objectIdParam = new GuidParam(this.ObjectID);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('ParticipatnFreeDrugReportReport', reportParameters);
            const objectIdParam2 = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
            await this.loadReportByID(objectIdParam2);

            await this.SetFormReadOnlyControls();
            this.loadPanelOperation(false, '');
        }
        else {
            let approveModel: SendSignedReportApproveModel = new SendSignedReportApproveModel();
            approveModel.isSecondDoctorApprove = true;
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSignedApprovePanel(approveModel);
                /*let approveDoctor = <string>await this.httpService.post('/api/ParticipatnFreeDrugReportService/getUniqueRefnoOfApproveUser', this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport);
                if (approveDoctor != approveModel.medulaUsername) {
                    console.log("Diğer hekim yerine rapor onayı yapamazsınız!!");
                    ServiceLocator.MessageService.showError("Diğer hekim yerine rapor onayı yapamazsınız!!");
                    return;
                }*/
                if (this.participationFreeDrugReportNewFormViewModel.secondDoctor != approveModel.medulaUsername) {
                    console.log("Diğer hekim yerine rapor onayı yapamazsınız!!");
                    //ServiceLocator.MessageService.showError("Diğer hekim yerine rapor onayı yapamazsınız!!");
                    TTVisual.InfoBox.Alert("Uyarı", "Diğer hekim yerine rapor onayı yapamazsınız!!", MessageIconEnum.ErrorMessage);
                    this.resetSavedPassword();
                    return;
                }

            }

            try {
                if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult != null && this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo != null) {
                    approveModel.participatnFreeDrugReport = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport;



                    await this.signService.showLoginModal();
                    this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));

                    let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareSignedReportApproveContent', approveModel);

                    let signedContent: string = await this.signService.signContent(signedReportOutput);


                    approveModel.signContent = signedContent;
                    let result = <IlacRaporuServis.imzaliEraporOnayCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportApproveContent', approveModel);
                    //let result = <IlacRaporuServis.eraporOnayCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/Onay', approveModel);
                    this.loadPanelOperation(false, '');
                    if (result != null && result.sonucKodu === '0000') {
                        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.SecondDoktorApprove;
                        //this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval;
                        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ThirdDoctorApproval;
                        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.SecondDoctorApproval = 1;
                        this.messageService.showSuccess(i18n("M20833", "Rapor Onaylandı."));

                        const objectIdParam = new GuidParam(this.ObjectID);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                        this.reportService.showReport('ParticipatnFreeDrugReportReport', reportParameters);
                    }
                    else if (result != null && result.sonucKodu === 'RAP_0052') {
                        console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji);
                        //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji);
                        TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji, MessageIconEnum.ErrorMessage);
                    }
                    else {

                        if (result != null && result.sonucKodu == "9107") {
                            this.resetSavedPassword();
                        }
                        if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.SecondDoctorApproval = 0;
                            this.txtAciklamaEkleSonucMesaji.Text = result.uyariMesaji + " " + result.sonucMesaji + " " + i18n("M20831", "Rapor Onaylanamamıştır.");
                            console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                            //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                            TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"), MessageIconEnum.ErrorMessage);
                        }
                    }

                    const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                    await this.loadReportByID(objectIdParam);

                    await this.SetFormReadOnlyControls();
                    this.showSaveSuccessMessage();
                }
                else {
                    console.log("Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
                    //ServiceLocator.MessageService.showError("Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
                    TTVisual.InfoBox.Alert("Uyarı", "Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!", MessageIconEnum.ErrorMessage);
                }
            }
            catch (e) {
                this.loadPanelOperation(false, '');
                console.log(e);
                TTVisual.InfoBox.Alert("Uyarı", e, MessageIconEnum.ErrorMessage);
            }
        }
    }

    //Eski kayıtlarda Completed adımında olanlar için yazıldı.
    private async btnIlkTabipOnay_Click(): Promise<void> {
        this.loadPanelOperation(true, i18n("M18851", "Lütfen bekleyiniz."));

        if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() === ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Completed.id) {
            if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CommitteeReport)
                this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval;
            else
                this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval;
        }
        await this.save();

        await this.AfterContextSavedScript(null);
        const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
        await this.loadReportByID(objectIdParam);

        await this.SetFormReadOnlyControls();
        this.loadPanelOperation(false, '');
    }

    private async btnMedulaBashekimOnay_Click(): Promise<void> {
        //TODO : Burcu Test edebilmek için konuldu.
        if (this.participationFreeDrugReportNewFormViewModel.closeMedula) {
            this.loadPanelOperation(true, i18n("M18851", "Lütfen bekleyiniz."));

            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.HeadDoctorApprove;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ReportCompleted;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.HeadDoctorApproval = 1;

            this.messageService.showSuccess(i18n("M20833", "Rapor Onaylandı."));
            await this.save();
            await this.AfterContextSavedScript(null);
            const objectIdParam = new GuidParam(this.ObjectID);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('ParticipatnFreeDrugReportReport', reportParameters);
            const objectIdParam2 = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
            await this.loadReportByID(objectIdParam2);

            await this.SetFormReadOnlyControls();
            this.loadPanelOperation(false, '');
        }
        else {
            let approveModel: SendSignedReportApproveModel = new SendSignedReportApproveModel();
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSignedApprovePanel(approveModel);
            }
            try {
                if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult != null && this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo != null) {
                    approveModel.participatnFreeDrugReport = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport;

                    await this.signService.showLoginModal();
                    this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));

                    let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareSignedReportHeadDoctorApproveContent', approveModel);

                    let signedContent: string = await this.signService.signContent(signedReportOutput);


                    approveModel.signContent = signedContent;
                    this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                    let result = <IlacRaporuServis.imzaliEraporBashekimOnayCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportHeadDoctorApproveContent', approveModel);
                    this.loadPanelOperation(false, '');
                    if (result != null && result.sonucKodu === '0000') {
                        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.HeadDoctorApprove;
                        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ReportCompleted;
                        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.HeadDoctorApproval = 1;
                        this.messageService.showSuccess(i18n("M20833", "Rapor Onaylandı."));
                    }
                    else if (result != null && result.sonucKodu === 'RAP_0047') {
                        console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji);
                        //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji);
                        TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji, MessageIconEnum.ErrorMessage);
                    }
                    else {

                        if (result != null && result.sonucKodu == "9107") {
                            this.resetSavedPassword();
                        }
                        if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.HeadDoctorApproval = 0;
                            this.txtAciklamaEkleSonucMesaji.Text = result.uyariMesaji + " " + result.sonucMesaji + " " + i18n("M20831", "Rapor Onaylanamamıştır.");
                            console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                            //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                            TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"), MessageIconEnum.ErrorMessage);
                        }
                    }

                    const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                    await this.loadReportByID(objectIdParam);

                    await this.SetFormReadOnlyControls();
                    this.showSaveSuccessMessage();
                }
                else {
                    console.log("Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
                    //ServiceLocator.MessageService.showError("Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
                    TTVisual.InfoBox.Alert("Uyarı", "Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!", MessageIconEnum.ErrorMessage);
                }
            }
            catch (e) {
                this.loadPanelOperation(false, '');
                console.log(e);
                TTVisual.InfoBox.Alert("Uyarı", e, MessageIconEnum.ErrorMessage);
            }
        }
    }
    private AddSelectedDiagnosisList(): void {
        if (this.selectedDiagnosisList != null)
            this.selectedDiagnosisList.Clear();
        else
            this.selectedDiagnosisList = Array<AddedDiagnosisListModel>();
        if (this.participationFreeDrugReportNewFormViewModel.TeshisList != null) {
            for (let i = 0; i < this.participationFreeDrugReportNewFormViewModel.TeshisList.length; i++) {
                if (this.participationFreeDrugReportNewFormViewModel.TeshisList[i].SelectedDiagnosisList != null) {
                    for (let j = 0; j < this.participationFreeDrugReportNewFormViewModel.TeshisList[i].SelectedDiagnosisList.length; j++) {
                        this.selectedDiagnosisList.push(this.participationFreeDrugReportNewFormViewModel.TeshisList[i].SelectedDiagnosisList[j]);
                    }
                }
            }
        }
    }

    public async SetFormReadOnlyControls() { }

    onCellHover(e: any) {
        if (e.column != null && e.rowType == "data") {
            if (e.column.dataField == 'ResultExplanation') {
                if (e.data.ResultExplanation !== "") {
                    this.popOver.target = e.cellElement;
                    this.popOver.contentTemplate = e.data.ResultExplanation;
                    this.popOver.visible = true;
                }
            } else {
                this.popOver.visible = false;
            }
        }
        else
            this.popOver.visible = false;
    }

    async btnBagliTakipAl_Click() {

        this.bagliTakipNo = '';
        this.bagliTakipAlinacakSEPid = this.participationFreeDrugReportNewFormViewModel.SubEpisodeProtocol.ObjectID;

        if (this.participationFreeDrugReportNewFormViewModel.SubEpisodeProtocol.MedulaTakipNo != null) {
            ServiceLocator.MessageService.showError(i18n("M15511", "Hastaya alınmış takip numarası mevcuttur,önce takip siliniz."));
            this.showBagliTakipAlPopup = false;
        }
        else
            this.showBagliTakipAlPopup = true;


    }

    async onClickBagliTakipAl() {
        if (this.bagliTakipNo !== '')
            await this.btnTakipAl_Click();

        this.showBagliTakipAlPopup = false;
    }

    onValueChangedBagliTakipPopup(e: any): void {
        this.bagliTakipNo = e.value;
    }
    async btnTakipAl_Click(): Promise<void> {
        try {
            let that = this;
            let takipAlUrl = '';
            if (this.participationFreeDrugReportNewFormViewModel.SubEpisodeProtocol.MedulaTakipNo != null)
                ServiceLocator.MessageService.showError(i18n("M15511", "Hastaya alınmış takip numarası mevcuttur,önce takip siliniz."));
            if (this.bagliTakipNo === '')
                takipAlUrl = '/api/InvoiceTopMenuApi/takipAl?sepObjectID=' + this.participationFreeDrugReportNewFormViewModel.SubEpisodeProtocol.ObjectID;
            else
                takipAlUrl = '/api/InvoiceTopMenuApi/takipAl?sepObjectID=' + this.participationFreeDrugReportNewFormViewModel.SubEpisodeProtocol.ObjectID + '&bagliTakipNo=' + this.bagliTakipNo;

            this.httpService.get<MedulaResult>(takipAlUrl, MedulaResult)
                .then(result => {
                    ServiceLocator.MessageService.showInfo(result.SonucKodu + ' - ' + result.SonucMesaji);
                })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                });

        }
        catch (Exception) {
            this.loadPanelOperation(false, '');
            console.log(Exception);
            TTVisual.InfoBox.Alert("Uyarı", Exception, MessageIconEnum.ErrorMessage);
        }
    }


    private showDiabetesMellitusForm(data: ParticipationFreeDrugReportNewFormViewModel): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DiabetesMellitusForm';
            componentInfo.ModuleName = 'HastaRaporlariModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'İlave Değer Bilgileri';
            modalInfo.Width = 400;
            modalInfo.Height = 450;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private async btnKaydet_Click(): Promise<boolean> {
        this.loadPanelOperation(true, i18n("M18851", "Lütfen bekleyiniz."));
        this.AddSelectedDiagnosisList();
        this.participationFreeDrugReportNewFormViewModel.SelectedTeshisTaniList = this.selectedDiagnosisList;
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ProcedureDoctor === null) {
            this.messageService.showInfo(i18n("M13163", "Doktor Bilgisi Boş Olamaz!."));
            this.loadPanelOperation(false, '');
            return;
        }
        if (this.selectedDiagnosisList.length == 0) {
            this.messageService.showInfo(i18n("M22769", "Tanı Seçmeden Devam Edemezsiniz!"));
            this.loadPanelOperation(false, '');
            return;
        }
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate == null) {
            this.messageService.showInfo(i18n("M11942", "Bitiş Tarihi Girmeden Devam Edemezsiniz!"));
            this.loadPanelOperation(false, '');
            return;
        }
        if (this.participationFreeDrugReportNewFormViewModel.EtkinMaddeList == null && this.participationFreeDrugReportNewFormViewModel.EtkinMaddeList.length == 0) {
            this.messageService.showInfo(i18n("M15781", "Hiçbir etkin madde seçmeden devam edemezsiniz!"));
            this.loadPanelOperation(false, '');
            return;
        }
        else {
            for (let i = 0; i < this.participationFreeDrugReportNewFormViewModel.EtkinMaddeList.length; i++) {
                if (this.participationFreeDrugReportNewFormViewModel.EtkinMaddeList[i].Doz == null) {
                    this.messageService.showInfo(i18n("M13292", "Kullanım Doz 1 alanı boş geçilemez!"));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.participationFreeDrugReportNewFormViewModel.EtkinMaddeList[i].Doz2 == null) {
                    this.messageService.showInfo(i18n("M13286", "Kullanım Doz 2 alanı boş geçilemez!"));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.participationFreeDrugReportNewFormViewModel.EtkinMaddeList[i].DozBirimi == null) {
                    this.messageService.showInfo(i18n("M13290", "Doz Birimi boş geçilemez!"));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.participationFreeDrugReportNewFormViewModel.EtkinMaddeList[i].Periyod == null) {
                    this.messageService.showInfo(i18n("M17975", "Kullanım Periyodu boş geçilemez!"));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.participationFreeDrugReportNewFormViewModel.EtkinMaddeList[i].PeriyodBirimi == null) {
                    this.messageService.showInfo(i18n("M17973", "Kullanım Periyod Birimi boş geçilemez!"));
                    this.loadPanelOperation(false, '');
                    return;
                }
            }
        }

        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CommitteeReport === true) {
            if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.SecondDoctor == null) {
                this.messageService.showInfo(i18n("M13163", "İkinci Hekim Bilgisi Boş Olamaz!."));
                this.loadPanelOperation(false, '');
                return;
            }
            if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ThirdDoctor == null) {
                this.messageService.showInfo(i18n("M13163", "Üçüncü Hekim Bilgisi Boş Olamaz!."));
                this.loadPanelOperation(false, '');
                return;
            }
        }

        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ExaminationDate.setHours(0);
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ExaminationDate.setMinutes(0);
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ExaminationDate.setSeconds(0);
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ExaminationDate > this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate) {
            this.messageService.showInfo(i18n("M20776", "Rapor Başlangıç Tarihi Muayene Tarihinden Küçük Olamaz!"));
            this.loadPanelOperation(false, '');
            return;
        }

        let diabetTeshisList = this.participationFreeDrugReportNewFormViewModel.TeshisList.filter(x => this.diabetTeshis07_02_1_Array.includes(x.teshisKodu) || x.teshisKodu == "206" || x.teshisKodu == "226")

        if (diabetTeshisList.length > 0) {
            this.loadPanelOperation(false, 'Lütfen bekleyiniz.');
            let diabetFormRes = await this.showDiabetesMellitusForm(this.participationFreeDrugReportNewFormViewModel);
            if (diabetFormRes.Result == DialogResult.Cancel) {
                ServiceLocator.MessageService.showError('Kayıt işleminden vazgeçildi.');
                return;
            }
            else {
                this.loadPanelOperation(true, 'Lütfen bekleyiniz!');
            }
        }

        if (this._modalInfo != null)
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport);
        if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() === ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New.id)
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Report;
        await this.save();

        await this.AfterContextSavedScript(null);
        const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
        await this.loadReportByID(objectIdParam);

        await this.SetFormReadOnlyControls();
        this.loadPanelOperation(false, '');
        return true;
    }

    private async btnMedulayaGonderKaydet_Click(): Promise<void> {

        let a = await this.btnKaydet_Click();

        if (a != null) {

            await this.SignedEraporGirisKaydet();

            await this.btnPrint_Click();
        }
    }



    async SignedEraporGirisKaydet() {
        //TODO : Burcu Test edebilmek için konuldu.

        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
            let approveDoctor = <string>await this.httpService.post('/api/ParticipatnFreeDrugReportService/getUniqueRefnoOfApproveUser', this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport);
            if (approveDoctor != this.participationFreeDrugReportNewFormViewModel.medulaUsername) {
                console.log("Diğer hekim yerine raporu gönderemezsiniz!!");
                //                ServiceLocator.MessageService.showError("Diğer hekim yerine raporu gönderemezsiniz!!");
                TTVisual.InfoBox.Alert("Uyarı", "Diğer hekim yerine raporu gönderemezsiniz!!", MessageIconEnum.ErrorMessage);
                this.resetSavedPassword();
                return;
            }
        }
        try {
            await this.signService.showLoginModal();
            this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));

            let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareSignedReportContent', this.participationFreeDrugReportNewFormViewModel);

            let signedContent: string = await this.signService.signContent(signedReportOutput);

            let preSend: SendSignedReport_Input = new SendSignedReport_Input();
            preSend.signContent = signedContent;
            preSend.viewModel = this.participationFreeDrugReportNewFormViewModel;
            this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
            let result = <IlacRaporuServis.imzaliEraporGirisCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportContent', preSend);

            this.loadPanelOperation(false, '');
            if (result.sonucKodu == "0000") {
                this.showMedulaerrorsPopup = false;
                await this.AfterContextSavedScript(null);
                const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                await this.loadReportByID(objectIdParam);

                await this.SetFormReadOnlyControls();

                this.showSaveSuccessMessage();

                this.messageService.showInfo(i18n("M20841", "Rapor Servisinden Gelen Sonuç Mesajı : İşlem Başarılı"));

                //await this.btnPrint_Click();
            }
            else {

                if (result != null && result.sonucKodu == "9107") {
                    this.resetSavedPassword();
                }
                this.showMedulaerrorsPopup = true;
                this.MedulaSonucMesaji = result.uyariMesaji + "\n" + result.sonucMesaji;
            }
        }

        catch (Exception) {
            console.log(Exception);
            console.log(Exception);
            TTVisual.InfoBox.Alert("Uyarı", Exception, MessageIconEnum.ErrorMessage);
            this.loadPanelOperation(false, '');
            // console.log(Exception);
        }

    }


    async EraporGirisKaydet() {
        //TODO : Burcu Test edebilmek için konuldu.
        if (this.participationFreeDrugReportNewFormViewModel.closeMedula) {
            this.loadPanelOperation(true, i18n("M18851", "Lütfen bekleyiniz."));

            if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() === ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New.id || this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() === ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Report.id) {
                if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CommitteeReport)
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval;
                else
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval;
            }

            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
            await this.save();

            await this.AfterContextSavedScript(null);
            const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
            await this.loadReportByID(objectIdParam);

            await this.SetFormReadOnlyControls();
            this.loadPanelOperation(false, '');
        }
        else {
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSendPanel();
            }
            try {
                let result = <IlacRaporuServis.eraporGirisCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/EraporGirisKaydet', this.participationFreeDrugReportNewFormViewModel);
                this.loadPanelOperation(false, '');
                if (result.sonucKodu == "0000") {
                    this.showMedulaerrorsPopup = false;
                    await this.AfterContextSavedScript(null);
                    const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                    await this.loadReportByID(objectIdParam);

                    await this.SetFormReadOnlyControls();

                    this.showSaveSuccessMessage();

                    this.messageService.showInfo(i18n("M20841", "Rapor Servisinden Gelen Sonuç Mesajı : İşlem Başarılı"));

                    //await this.btnPrint_Click();
                }
                else {

                    if (result != null && result.sonucKodu == "9107") {
                        this.resetSavedPassword();
                    }
                    this.showMedulaerrorsPopup = true;
                    this.MedulaSonucMesaji = result.uyariMesaji + "\n" + result.sonucMesaji;
                }
            }

            catch (Exception) {
                this.loadPanelOperation(false, '');
                console.log(Exception);
                TTVisual.InfoBox.Alert("Uyarı", Exception, MessageIconEnum.ErrorMessage);
            }
        }
    }

    private async btnUcuncuTabipOnay_Click(): Promise<void> {
        //TODO : Burcu Test edebilmek için konuldu.
        if (this.participationFreeDrugReportNewFormViewModel.closeMedula) {
            this.loadPanelOperation(true, i18n("M18851", "Lütfen bekleyiniz."));

            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ThirdDoktorApprove;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ThirdDoctorApproval = 1;

            this.messageService.showSuccess(i18n("M20833", "Rapor Onaylandı."));
            await this.save();
            await this.AfterContextSavedScript(null);
            const objectIdParam = new GuidParam(this.ObjectID);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('ParticipatnFreeDrugReportReport', reportParameters);
            const objectIdParam2 = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
            await this.loadReportByID(objectIdParam2);

            await this.SetFormReadOnlyControls();
            this.loadPanelOperation(false, '');
        }
        else {

            let approveModel: SendSignedReportApproveModel = new SendSignedReportApproveModel();
            approveModel.isThirdDoctorApprove = true;
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSignedApprovePanel(approveModel);
                /*let approveDoctor = <string>await this.httpService.post('/api/ParticipatnFreeDrugReportService/getUniqueRefnoOfApproveUser', this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport);
                if (approveDoctor != approveModel.medulaUsername) {
                    console.log("Diğer hekim yerine rapor onayı yapamazsınız!!");
                    ServiceLocator.MessageService.showError("Diğer hekim yerine rapor onayı yapamazsınız!!");
                    return;
                }*/
                if (this.participationFreeDrugReportNewFormViewModel.thirdDoctor != approveModel.medulaUsername) {
                    console.log("Diğer hekim yerine rapor onayı yapamazsınız!!");
                    //ServiceLocator.MessageService.showError("Diğer hekim yerine rapor onayı yapamazsınız!!");
                    TTVisual.InfoBox.Alert("Uyarı", "Diğer hekim yerine rapor onayı yapamazsınız!!", MessageIconEnum.ErrorMessage);
                    this.resetSavedPassword();
                    return;
                }
            }
            try {
                if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult != null && this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo != null) {
                    approveModel.participatnFreeDrugReport = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport;


                    await this.signService.showLoginModal();
                    this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));

                    let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareSignedReportApproveContent', approveModel);

                    let signedContent: string = await this.signService.signContent(signedReportOutput);


                    approveModel.signContent = signedContent;// signedContent;
                    this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                    let result = <IlacRaporuServis.imzaliEraporOnayCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportApproveContent', approveModel);
                    this.loadPanelOperation(false, '');
                    if (result != null && result.sonucKodu === '0000') {
                        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ThirdDoktorApprove;
                        //this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval;
                        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval;
                        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ThirdDoctorApproval = 1;
                        this.messageService.showSuccess(i18n("M20833", "Rapor Onaylandı."));

                        const objectIdParam = new GuidParam(this.ObjectID);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                        this.reportService.showReport('ParticipatnFreeDrugReportReport', reportParameters);
                    }
                    else if (result != null && result.sonucKodu === 'RAP_0052') {
                        console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji);
                        //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji);
                        TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji, MessageIconEnum.ErrorMessage);
                    }
                    else {

                        if (result != null && result.sonucKodu == "9107") {
                            this.resetSavedPassword();
                        }
                        if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ThirdDoctorApproval = 0;
                            this.txtAciklamaEkleSonucMesaji.Text = result.uyariMesaji + " " + result.sonucMesaji + " " + i18n("M20831", "Rapor Onaylanamamıştır.");
                            console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                            //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                            TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"), MessageIconEnum.ErrorMessage);
                        }
                    }

                    const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                    await this.loadReportByID(objectIdParam);

                    await this.SetFormReadOnlyControls();
                    this.showSaveSuccessMessage();
                }
                else {
                    console.log("Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
                    //ServiceLocator.MessageService.showError("Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
                    TTVisual.InfoBox.Alert("Uyarı", "Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!", MessageIconEnum.ErrorMessage);
                }
            }
            catch (e) {
                this.loadPanelOperation(false, '');
                console.log(e);
                TTVisual.InfoBox.Alert("Uyarı", e, MessageIconEnum.ErrorMessage);
            }
        }
    }

    public async btnPrint_Click() {
        try {
            const objectIdParam = new GuidParam(this.ObjectID);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('ParticipatnFreeDrugReportReport', reportParameters);
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    private async CommitteeReport_CheckedChanged(): Promise<void> {
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CommitteeReport) {
            //((ITTObjectListBox)this.SecondDoctor).Visible = true;

            this.listSecondDoctor.Enabled = true;
            this.listSecondDoctor.Required = true;
            this.ThirdDoctor.Enabled = true;
            this.ThirdDoctor.Required = true;
            if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() === ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New.id) {

                this.btnIkinciTabipOnay.Visible = true;
                this.btnUcuncuTabipOnay.Visible = false;
                this.btnMedulaBashekimOnay.Visible = false;
            }
        }
        else {
            this.listSecondDoctor.Enabled = false;
            this.listSecondDoctor.Required = false;

            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.SecondDoctor = null;

            this.ThirdDoctor.Enabled = false;
            this.ThirdDoctor.Required = false;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ThirdDoctor = null;

            this.btnIkinciTabipOnay.Visible = false;
            this.btnUcuncuTabipOnay.Visible = false;
            this.btnMedulaBashekimOnay.Visible = true;
        }

    }
    private async GridDiagnosis_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {

    }

    private async lstDiagnosisAddedToEpisode_SelectedObjectChanged(): Promise<void> {
        let diagnosisDefinition: DiagnosisDefinition = (<DiagnosisDefinition>this.lstDiagnosisAddedToEpisode.SelectedObject);
        if (diagnosisDefinition.Teshis !== null) {
            // this.GridDiagnosis.Rows[rowIndex].Cells["Teshis"].Value = secDiagnosisGrid.Diagnose.Teshis;
            this.lstTeshisAddedToDiagnosis.SelectedObject = diagnosisDefinition.Teshis;
        }
    }
    MedulaReportResults_CellContentClickEmitted(data: any) {
        if (data && this.MedulaReportResults_CellContentClick && data.row && data.column) {
            this.lastSelectedCell = {
                OwningRow: data.row,
                OwningColumn: data.column
            };
            //this.MedulaReportResults.CurrentCell =

            this.MedulaReportResults_CellContentClick(data.RowIndex, data.ColIndex);
        }
    }

    private async MedulaReportResults_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {

        if (this.lastSelectedCell !== null) {
            this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult = <MedulaReportResult>this.lastSelectedCell.OwningRow.data;

            if (this.lastSelectedCell.OwningColumn.Name == 'btnRaporuSil') {
                if (this.enableMedulaPasswordEntrance) {
                    await this.MedulaPasswordSendPanel();
                }
                try {
                    if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo != null) {
                        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Raporu Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? "), 1);
                        if (result === "H") {
                            ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
                            return;
                        }
                        await this.signService.showLoginModal();
                        this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));

                        let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareDeleteReportContent', this.participationFreeDrugReportNewFormViewModel);

                        let signedContent: string = await this.signService.signContent(signedReportOutput);

                        let preSend: SendSignedReportDelete_Input = new SendSignedReportDelete_Input();
                        preSend.signContent = signedContent;
                        preSend.viewModel = this.participationFreeDrugReportNewFormViewModel;
                        let response = <IlacRaporuServis.imzaliEraporSilCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportDeleteContent', preSend);



                        //let response = <IlacRaporuServis.eraporSilCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/Sil', this.participationFreeDrugReportNewFormViewModel);
                        this.loadPanelOperation(false, '');
                        if (response != null && response.sonucKodu === '0000') {
                            this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.CurrentStateDefID = MedulaReportResult.MedulaReportResultStates.Completed;
                            this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ResultCode = response.sonucKodu;
                            this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ResultExplanation = i18n("M20786", "Rapor Bilgisi Silinmiştir");
                            this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportRowNumber = null;
                            this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportNumber = "";
                            this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo = "";

                            this.txtAciklamaEkleSonucMesaji.Text = response.sonucMesaji + " " + response.uyariMesaji + " " + i18n("M16831", "İşlem Başarılı.");
                        }
                        else {
                            if (!String.isNullOrEmpty(response.sonucMesaji)) {
                                this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ResultCode = response.sonucKodu;
                                this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ResultExplanation = "";
                                console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + response.uyariMesaji + '' + response.sonucMesaji + i18n("M20831", " Rapor Silinememiştir.  !!!"));
                                //ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + response.uyariMesaji + '' + response.sonucMesaji + i18n("M20831", " Rapor Silinememiştir.  !!!"));
                                TTVisual.InfoBox.Alert("Uyarı", i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + response.uyariMesaji + '' + response.sonucMesaji + i18n("M20831", " Rapor Silinememiştir.  !!!"), MessageIconEnum.ErrorMessage);
                            }
                        }


                        this.lastSelectedCell = this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult as ITTGridRow;

                        const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                        await this.loadReportByID(objectIdParam);

                        await this.SetFormReadOnlyControls();
                        this.showSaveSuccessMessage();

                        await this.OnClosing.emit(false);

                    }
                    else {
                        TTVisual.InfoBox.Alert("Uyarı", i18n("M18855", "Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Meduladan Silme İşlemi Yapamazsınız!!!"), MessageIconEnum.ErrorMessage);
                    }
                }
                catch (err) {
                    this.loadPanelOperation(false, '');
                    TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
                    throw err;
                }

            }
            else {
                if (this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo == null) {
                    ServiceLocator.MessageService.showError(i18n("M18855", "Medula kaydı yapılmamış raporlar için bu işlem gerçekleştirilemez.Önce Medula rapor kaydını yapınız."));
                    return null;

                }
                else {
                    if (this.lastSelectedCell.OwningColumn.Name == 'btnGridAciklamaEkle') {
                        this.aciklamaEkleSelected = true;
                        this.tumRaporlarSelected = false;
                        this.etkinMaddeEkleSelected = false;
                        this.teshisSelected = false;
                        this.taniEkleSelected = false;
                        this.medulaResult = false;
                    }

                    if (this.lastSelectedCell.OwningColumn.Name == 'btnGridTaniEkle') {
                        this.aciklamaEkleSelected = false;
                        this.tumRaporlarSelected = false;
                        this.etkinMaddeEkleSelected = false;
                        this.teshisSelected = false;
                        this.taniEkleSelected = true;
                        this.medulaResult = false;
                    }
                    if (this.lastSelectedCell.OwningColumn.Name == 'btnGridTeshisEkle') {
                        this.aciklamaEkleSelected = false;
                        this.tumRaporlarSelected = false;
                        this.etkinMaddeEkleSelected = false;
                        this.teshisSelected = true;
                        this.taniEkleSelected = false;
                        this.medulaResult = false;

                    }
                    if (this.lastSelectedCell.OwningColumn.Name == 'btnGridEtkinMaddeEkle') {
                        this.aciklamaEkleSelected = false;
                        this.tumRaporlarSelected = false;
                        this.etkinMaddeEkleSelected = true;
                        this.teshisSelected = false;
                        this.taniEkleSelected = false;
                        this.medulaResult = false;
                    }
                }
                if (this.lastSelectedCell.OwningColumn.Name == 'btnInfo') {
                    this.aciklamaEkleSelected = false;
                    this.tumRaporlarSelected = false;
                    this.etkinMaddeEkleSelected = false;
                    this.teshisSelected = false;
                    this.taniEkleSelected = false;
                    this.medulaResult = true;
                    this.MedulaDetailedResult = this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ResultExplanation;
                }
            }
        }
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            if ((transDef.FromStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval.id && transDef.ToStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New.id)
                || (transDef.FromStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval.id && transDef.ToStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Report.id)) {
                if (this._ParticipatnFreeDrugReport.HeadDoctorApproval == 1) {
                    let result: string;
                    if (transDef.FromStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval.id)
                        result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), "Raporu Medula'da onayladınız. \nİade ettiğinizde Medula onayı iptal edilmeyecektir !!!. \nDevam etmek istediğinize emin misiniz?", 1);
                    //else
                    //     result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Rapor Medula'dan iptal edilecektir !!! Devam etmek istediğinize emin misiniz?", 1);
                    if (result === "H")
                        ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
                }
            }
            if ((transDef.FromStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ThirdDoctorApproval.id && transDef.ToStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New.id) ||
                (transDef.FromStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval.id && transDef.ToStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New.id) ||
                (transDef.FromStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ThirdDoctorApproval.id && transDef.ToStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Report.id) ||
                (transDef.FromStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval.id && transDef.ToStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Report.id)) {
                if (this._ParticipatnFreeDrugReport.ThirdDoctorApproval == 1 || this._ParticipatnFreeDrugReport.SecondDoctorApproval == 1) {
                    let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), "Raporu Medula'da onayladınız. \nİade ettiğinizde Medula onayı iptal edilmeyecektir !!!. \nDevam etmek istediğinize emin misiniz?", 1);
                    if (result === "H")
                        ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
                }
            }
        }
    }

    public checkRemoveNeccesityForUndo() {
        let that = this;
        if (that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.toString() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ThirdDoctorApproval.id.toString()) {
            return false;
        } else if (that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.toString() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval.id.toString()) {
            if (that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CommitteeReport == true) {
                return false;
            } else {
                return true;
            }
        } else if (that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.toString() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval.id.toString()) {
            return true;
        } else if (that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID.toString() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ReportCompleted.id.toString()) {
            return false;
        }
    }

    private async btnBack_Click() {
        //TODO : Burcu Test edebilmek için konuldu.

        /*if (!this.participationFreeDrugReportNewFormViewModel.closeMedula) {
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSendPanel();
            }
        }*/
        try {
            let that = this;
            if (!this.checkRemoveNeccesityForUndo()) {
                this.loadPanelOperation(true, i18n("M18851", " İşlem geri alınıyor. Lütfen bekleyiniz."));

                let apiUrlForRaporBilgisBul: string = '/api/ParticipatnFreeDrugReportService/Undo';
                await this.httpService.post(apiUrlForRaporBilgisBul, this.participationFreeDrugReportNewFormViewModel);
                this.messageService.showInfo(i18n("M16844", "İşlem geri alındı"));

                const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                await this.loadReportByID(objectIdParam);

                await this.SetFormReadOnlyControls();

                this.showSaveSuccessMessage();
                this.loadPanelOperation(false, "");

            } else {
                this.btnDelete_Click(null);
            }





            await this.OnClosing.emit(false);
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    public async btnCancel_Click() {
        //TODO : Burcu Test edebilmek için konuldu.
        if (this.participationFreeDrugReportNewFormViewModel.closeMedula) {
            this.loadPanelOperation(true, i18n("M18851", "Lütfen bekleyiniz."));

            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Cancelled;
            this.messageService.showSuccess(i18n("M20833", "İptal edildi."));
            await this.save();
            await this.AfterContextSavedScript(null);

            const objectIdParam2 = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
            await this.loadReportByID(objectIdParam2);

            await this.SetFormReadOnlyControls();
            this.loadPanelOperation(false, '');
        }
        else {
            try {
                if (!this.participationFreeDrugReportNewFormViewModel.closeMedula) {
                    for (let detailItem of this.participationFreeDrugReportNewFormViewModel.MedulaReportResultsGridList) {
                        if (detailItem.ReportChasingNo == null || detailItem.ReportChasingNo == "0") {
                            this.messageService.showInfo("Raporu iptal etmek için raporu Medula'dan siliniz.");
                            break;
                        }

                        return;
                    }
                }
                if (this.participationFreeDrugReportNewFormViewModel.ToState == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New || this.participationFreeDrugReportNewFormViewModel.ToState == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Report) {
                    console.log("Yazılmamış raporları iptal edemezsiniz.");
                    ServiceLocator.MessageService.showError("Yazılmamış raporları iptal edemezsiniz.");
                    return;
                }

                let that = this;
                let apiUrlForRaporBilgisBul: string = '/api/ParticipatnFreeDrugReportService/Cancel';
                await this.httpService.post(apiUrlForRaporBilgisBul, this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport);

                this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Cancelled;
                this.messageService.showInfo(i18n("M20811", "Rapor iptal edildi."));

                const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                await this.loadReportByID(objectIdParam);

                await this.OnClosing.emit(true);
            }
            catch (err) {
                ServiceLocator.MessageService.showError(err);
                TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
            }
        }

    }
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
    }
    protected async PreScript(): Promise<void> {
        this.resize(undefined);
        super.PreScript();
        // let that = this;
        //  this.EtkinMaddeList.ListFilterExpression = this.participationFreeDrugReportNewFormViewModel.EtkinMaddeListFilter;

        if (!this.participationFreeDrugReportNewFormViewModel.IsSuperUser) {
            this.ProcedureDoctor.ReadOnly = true;
        }
        else {
            this.ProcedureDoctor.ReadOnly = false;
        }
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CommitteeReport == null)
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CommitteeReport = false;
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.CommitteeReport == true) {
            this.listSecondDoctor.Visible = true;
            this.listSecondDoctor.Required = true;
            this.ThirdDoctor.Visible = true;
            this.ThirdDoctor.Required = true;

            if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New.id || this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Report.id) {

                this.CommitteeReport.Enabled = true;
            }
            else if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval.id) {
                this.CommitteeReport.Enabled = false;
            }
            //else if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.SecondDoctorApproval.id) {
            else if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ThirdDoctorApproval.id) {

                this.AddStateButton(ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New);
                if (this.participationFreeDrugReportNewFormViewModel.SecondDoctorApprove == true) {
                    this.CommitteeReport.Enabled = false;
                }
                else {
                    this.CommitteeReport.Enabled = false;
                }
            }
            //else if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.ThirdDoctorApproval.id) {
            else if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Approval.id) {

                if (this.participationFreeDrugReportNewFormViewModel.ThirdDoctorApprove == true) {
                    this.CommitteeReport.Enabled = false;
                }
                else {
                    this.CommitteeReport.Enabled = true;
                }
            }
            else {
                this.CommitteeReport.Enabled = false;
            }
        }
        else {
            this.listSecondDoctor.Enabled = false;
            this.listSecondDoctor.Required = false;
            this.ThirdDoctor.Enabled = false;
            this.ThirdDoctor.Required = false;

            if (this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.New.id
                || this._ParticipatnFreeDrugReport.CurrentStateDefID.valueOf() == ParticipatnFreeDrugReport.ParticipatnFreeDrugReportStates.Report.id) {
                this.CommitteeReport.Enabled = true;
            }
            else
                this.CommitteeReport.Enabled = false;
        }

    }



    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ParticipatnFreeDrugReport();
        this.participationFreeDrugReportNewFormViewModel = new ParticipationFreeDrugReportNewFormViewModel();
        this._ViewModel = this.participationFreeDrugReportNewFormViewModel;
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport = this._TTObject as ParticipatnFreeDrugReport;
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ThirdDoctor = new ResUser();
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.SecondDoctor = new ResUser();
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.MedulaReportResults = new Array<MedulaReportResult>();
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ParticipationFreeDrugs = new Array<ParticipationFreeDrgGrid>();
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.Diagnosis = new Array<DiagnosisGrid>();
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ProcedureDoctor = new ResUser();
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.MasterResource = new ResSection();
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.Episode = new Episode();
        this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.Episode.Patient = new Patient();
        this.participationFreeDrugReportNewFormViewModel.SubEpisodeProtocol = new SubEpisodeProtocol();
    }

    protected loadViewModel() {
        let that = this;

        that.participationFreeDrugReportNewFormViewModel = this._ViewModel as ParticipationFreeDrugReportNewFormViewModel;
        that._TTObject = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport;
        if (this.participationFreeDrugReportNewFormViewModel == null)
            this.participationFreeDrugReportNewFormViewModel = new ParticipationFreeDrugReportNewFormViewModel();
        if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport == null)
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport = new ParticipatnFreeDrugReport();
        let thirdDoctorObjectID = that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport["ThirdDoctor"];
        if (thirdDoctorObjectID != null && (typeof thirdDoctorObjectID === 'string')) {
            let thirdDoctor = that.participationFreeDrugReportNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === thirdDoctorObjectID.toString());
            if (thirdDoctor) {
                that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ThirdDoctor = thirdDoctor;
            }
        }
        let secondDoctorObjectID = that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport["SecondDoctor"];
        if (secondDoctorObjectID != null && (typeof secondDoctorObjectID === 'string')) {
            let secondDoctor = that.participationFreeDrugReportNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === secondDoctorObjectID.toString());
            if (secondDoctor) {
                that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.SecondDoctor = secondDoctor;
            }
        }
        that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.MedulaReportResults = that.participationFreeDrugReportNewFormViewModel.MedulaReportResultsGridList;

        this.sended = false;
        for (let detailItem of that.participationFreeDrugReportNewFormViewModel.MedulaReportResultsGridList) {
            if (detailItem.ReportChasingNo != null && detailItem.ReportChasingNo != "0")
                this.sended = true;
        }
        if (this.sended) {
            this.ReportStartDate.Enabled = false;
            this.CommitteeReport.ReadOnly = true;
            this.ProcedureDoctor.Enabled = false;
            this.listSecondDoctor.Enabled = false;
            this.ReportEndDate.Enabled = false;
            this.ThirdDoctor.Enabled = false;
            this.EtkinMaddeList.Enabled = false;
            this.TestsAndSigns.ReadOnly = true;
            this.ttrichtextboxAciklama.ReadOnly = true;
        }

        that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ParticipationFreeDrugs = that.participationFreeDrugReportNewFormViewModel.ParticipationFreeDrugsGridList;
        for (let detailItem of that.participationFreeDrugReportNewFormViewModel.ParticipationFreeDrugsGridList) {
            let etkinMaddeObjectID = detailItem["EtkinMadde"];
            if (etkinMaddeObjectID != null && (typeof etkinMaddeObjectID === 'string')) {
                let etkinMadde = that.participationFreeDrugReportNewFormViewModel.EtkinMaddes.find(o => o.ObjectID.toString() === etkinMaddeObjectID.toString());
                if (etkinMadde) {
                    detailItem.EtkinMadde = etkinMadde;
                }
            }
        }

        for (let detailItem of that.participationFreeDrugReportNewFormViewModel.TeshisList) {
            let teshisObjectID = detailItem["teshis"];
            if (teshisObjectID != null && (typeof teshisObjectID === 'string')) {
                let teshis = that.participationFreeDrugReportNewFormViewModel.Teshiss.find(o => o.ObjectID.toString() === teshisObjectID.toString());
                if (teshis) {
                    detailItem.teshis = teshis;
                }
                detailItem.teshisAdi = teshis.teshisAdi;
                detailItem.teshisKodu = teshis.teshisKodu.toString();

            }
            for (let detailTeshisItem of detailItem.AddedDiagnosisList) {
                let taniObjectID = detailItem["Tani"];
                if (taniObjectID != null && (typeof taniObjectID === 'string')) {
                    let tani = that.participationFreeDrugReportNewFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === taniObjectID.toString());
                    if (tani) {
                        detailTeshisItem.Tani = tani;
                    }
                    detailTeshisItem.taniAdi = tani.Name;
                    detailTeshisItem.taniKodu = tani.Code.toString();
                }
            }
            detailItem.SelectedDiagnosisList = new Array<AddedDiagnosisListModel>();
            this.selectedDiagnosisList = new Array<AddedDiagnosisListModel>();
            for (let detailSelectedDiagnosisItem of that.participationFreeDrugReportNewFormViewModel.SelectedTeshisTaniList) {
                this.selectedDiagnosisList.push(detailSelectedDiagnosisItem);
                if (detailSelectedDiagnosisItem.teshisObjectID == teshisObjectID.ObjectID) {
                    detailItem.SelectedDiagnosisList.push(detailSelectedDiagnosisItem);
                    if (detailItem.SelectedDiagnosisListKeys == null) {
                        detailItem.SelectedDiagnosisListKeys = new Array<string>();
                    }
                    detailItem.SelectedDiagnosisListKeys.push(detailSelectedDiagnosisItem.taniKodu);
                }
            }

            detailItem.selectedDiagnoses = this.getSelectedDiagnosisText(detailItem);
        }
        that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.Diagnosis = that.participationFreeDrugReportNewFormViewModel.GridDiagnosisGridList;

        let procedureDoctorObjectID = that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.participationFreeDrugReportNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ProcedureDoctor = procedureDoctor;
            }
        }
        let masterResourceObjectID = that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.participationFreeDrugReportNewFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.MasterResource = masterResource;
            }
        }
        let episodeObjectID = that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.participationFreeDrugReportNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.participationFreeDrugReportNewFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }

        this.SetButtonVisibility();
        if (this.enableStartDateBounds == true) {
            this.ReportStartDate.Min = this.participationFreeDrugReportNewFormViewModel.minReportDate;
            this.ReportStartDate.Max = this.participationFreeDrugReportNewFormViewModel.maxReportDate;
        }
    }




    public GenerateTaniTeshisColumns() {
        let that = this;

        this.TaniTeshisColumns = [
            {
                caption: i18n("M22736", "Tanı"),
                dataField: 'Tani',
                lookup: { dataSource: that.taniDefArray, valueExpr: 'ItemKey', displayExpr: 'Name' },
                width: 100,
                allowEditing: true
            },
            {
                caption: i18n("M23281", "Teşhis"),
                dataField: 'Teshis',
                lookup: { dataSource: that.teshisDefArray, valueExpr: 'ItemKey', displayExpr: 'Name' },
                width: 250,
                allowEditing: true
            }
        ];
    }
    public GeneratEtkinMaddeColumns() {
        let that = this;

        this.EtkinMaddeColumns = [
            {
                caption: 'Etkin Madde(Medula Kapsamında)',
                dataField: 'EtkinMaddeName',
                width: 350,
                allowEditing: false
            },
            {
                caption: 'Etkin Madde(Medula Harici)',
                dataField: 'EtkinMaddeMudalaHarici',
                width: 200,
                allowEditing: true
            },
            {
                caption: i18n("M17974", "Kullanım Periyodu"),
                dataField: i18n("M20308", "Periyod"),
                width: 100,
                allowEditing: true
            },
            {
                caption: i18n("M17972", "Kullanım Periyod Birimi"),
                dataField: i18n("M20315", "PeriyodBirimi"),
                lookup: { dataSource: that.periyodBirimiArray, valueExpr: 'id', displayExpr: 'name' },
                width: 150,
                allowEditing: true
            },
            {
                caption: "Kullanım Doz 1",
                dataField: "Doz",
                width: 140,
                allowEditing: true
            },
            {
                caption: "Kullanım Doz 2",
                dataField: "Doz2",
                width: 140,
                allowEditing: true
            },
            {
                caption: i18n("M17970", "Kullanım Doz Birimi"),
                dataField: 'DozBirimi',
                lookup: { dataSource: that.dozBirimiArray, valueExpr: 'id', displayExpr: 'name' },
                width: 130,
                allowEditing: true
            }

        ];
    }

    TeshisGridColumns = [
        { caption: i18n("M23206", "Teshis Kodu"), dataField: 'teshisKodu', fixed: true, width: '100' },
        { caption: 'Teshis', dataField: 'teshisAdi', fixed: true, width: '400' }
    ];
    public async Tanilar(): Promise<any> {
        let listDefName: string = "DiagnosisListDefinition";
        if (!this.taniDefCache) {
            this.taniDefCache = await this.httpService.get("/api/MedulaTreatmentReportService/GetListDefValues?listDefName=" + listDefName + '&listFilterExpression=' + '&linkFilterExpression=');
            return this.taniDefCache;
        }
        else {
            return this.taniDefCache;
        }
    }
    public async Teshisler(): Promise<any> {
        let listDefName: string = "TeshisListDefinition";
        //let listFilterExpression: string = "TEDAVIRAPORUTURUKODU = '5'";
        if (!this.teshisDefCache) {
            this.teshisDefCache = await this.httpService.get("/api/MedulaTreatmentReportService/GetListDefValues?listDefName=" + listDefName + '&listFilterExpression=' + '&linkFilterExpression=');
            return this.teshisDefCache;
        }
        else {
            return this.teshisDefCache;
        }
    }
    public DozAraligi(): Promise<any> {

        if (this.dozAraligiCache2.length == 0) {
            for (let item of FrequencyEnum.Items) {
                let enumAdi: string = item.description;
                if (typeof enumAdi != 'number') {
                    this.dozAraligiCache2.push({ id: <any>item.code, name: enumAdi });
                }
            }
            this.dozAraligiCache = this.dozAraligiCache2;
            return this.dozAraligiCache;
        }
        else {
            return this.dozAraligiCache;
        }
    }
    public DozBirimi(): Promise<any> {

        if (this.dozBirimiCache2.length == 0) {
            for (let item of UsageDoseUnitTypeEnum.Items) {
                let enumAdi: string = item.description;
                if (typeof enumAdi != 'number') {
                    this.dozBirimiCache2.push({ id: <any>item.code, name: enumAdi });
                }
            }
            this.dozBirimiCache = this.dozBirimiCache2;
            return this.dozBirimiCache;
        }
        else {
            return this.dozBirimiCache;
        }
    }
    public PeriyodBirimi(): Promise<any> {

        if (this.periyodBirimiCache2.length == 0) {
            for (let item of PeriodUnitTypeEnum.Items) {
                let enumAdi: string = item.description;
                if (typeof enumAdi != 'number') {
                    this.periyodBirimiCache2.push({ id: <any>item.code, name: enumAdi });
                }
            }
            this.periyodBirimiCache = this.periyodBirimiCache2;
            return this.periyodBirimiCache;
        }
        else {
            return this.periyodBirimiCache;
        }
    }

    public async EtkinMaddeler(): Promise<any> {
        let listDefName: string = "EtkinMaddeListDefinition";
        let date = new Date();
        let dateString = date.ToShortDateString();
        // let listFilterExpression: string = "BITISTARIHI > TO_DATE('" + dateString + "','dd.mm.yyyy') AND BASLANGICTARIHI < TO_DATE('" + dateString + "','dd.mm.yyyy')";
        //let listFilterExpression: string = this.participationFreeDrugReportNewFormViewModel.EtkinMaddeListFilter;
        if (!this.etkinMaddeCache) {
            this.etkinMaddeCache = await this.httpService.get("/api/MedulaTreatmentReportService/GetListDefValues?listDefName=" + listDefName + '&listFilterExpression=' + '&linkFilterExpression=');
            return this.etkinMaddeCache;
        }
        else {
            return this.etkinMaddeCache;
        }
    }
    EtkinMAddeSelected(data: any) {
        if (data != null) {
            let that = this;
            let EtkinMadde: EtkinMaddeListModel = new EtkinMaddeListModel();
            EtkinMadde.EtkinMadde = data.ObjectID;
            EtkinMadde.EtkinMaddeName = data.etkinMaddeKodu + " : " + data.etkinMaddeAdi;
            EtkinMadde.ParticipatientFreeDrugObjectID = Guid.Empty;
            that.participationFreeDrugReportNewFormViewModel.EtkinMaddeList.push(EtkinMadde);
            this.GetRelatedTeshisTani(EtkinMadde.EtkinMadde);
        }
    }
    async GetRelatedTeshisTani(etkinMaddeObjectID: Guid) {
        if (etkinMaddeObjectID != null) {
            let that = this;
            let etkenMaddeTeshisList: EtkenMaddeTeshisListModel = new EtkenMaddeTeshisListModel();
            etkenMaddeTeshisList.etkenMaddeObjectId = etkinMaddeObjectID;
            etkenMaddeTeshisList.TeshisList = that.participationFreeDrugReportNewFormViewModel.TeshisList;
            let TeshisList = <Array<TeshisListModel>>await this.httpService.post('/api/ParticipatnFreeDrugReportService/GetTeshisTani', etkenMaddeTeshisList);

            for (let teshis of TeshisList) {
                let teshisVar: boolean = false;
                let existTeshis: TeshisListModel = new TeshisListModel();
                for (let viewModelTeshis of that.participationFreeDrugReportNewFormViewModel.TeshisList) {
                    if (viewModelTeshis.teshisKodu == teshis.teshisKodu) {
                        existTeshis = viewModelTeshis;
                        viewModelTeshis.relatedEtkenMaddeList.push(teshis.relatedEtkenMaddeList[0]);
                        viewModelTeshis.relatedEtkenMaddeNames += ", " + teshis.relatedEtkenMaddeList[0].etkinMaddeAdi;
                        teshisVar = true;
                    }
                }
                if (!teshisVar) {
                    that.participationFreeDrugReportNewFormViewModel.TeshisList.push(teshis);
                }
                else {

                }
            }
        }
    }

    async  onRowDeleted(event) {

        let item: any = event.data.EtkinMadde;
        let etkinmaddeName: string = event.data.EtkinMaddeName.split(" : ", 2)[1];
        let TeshisListCount: number = this.participationFreeDrugReportNewFormViewModel.TeshisList.length;
        let previousCount: number = this.participationFreeDrugReportNewFormViewModel.TeshisList.length;
        if (item != null) {
            for (let i = 0; i < this.participationFreeDrugReportNewFormViewModel.TeshisList.length; i++) {
                let etkinMaddeFound: boolean = false;
                for (let j = 0; j < this.participationFreeDrugReportNewFormViewModel.TeshisList[i].relatedEtkenMaddeList.length; j++) {
                    let etkinMadde: EtkinMadde = this.participationFreeDrugReportNewFormViewModel.TeshisList[i].relatedEtkenMaddeList[j];
                    if (etkinMadde.ObjectID.toString() == item.toString()) {
                        this.participationFreeDrugReportNewFormViewModel.TeshisList[i].relatedEtkenMaddeList.splice(j, 1);
                        j = -1;
                        if (this.participationFreeDrugReportNewFormViewModel.TeshisList[i].relatedEtkenMaddeList.length > 0) {
                            this.participationFreeDrugReportNewFormViewModel.TeshisList[i].relatedEtkenMaddeNames = this.getRelatedEtkinMaddeText(this.participationFreeDrugReportNewFormViewModel.TeshisList[i].relatedEtkenMaddeList);
                        } else {
                            this.participationFreeDrugReportNewFormViewModel.TeshisList.splice(i, 1);
                            if (this.participationFreeDrugReportNewFormViewModel.TeshisList.length != previousCount) {
                                i = -1;
                                previousCount = this.participationFreeDrugReportNewFormViewModel.TeshisList.length + 1;
                            }
                            break;
                        }
                    }
                }
            }
        }
        if (this.participationFreeDrugReportNewFormViewModel.TeshisList.length == 0) {
            this.selectedTeshisTaniList = new Array<AddedDiagnosisListModel>();
        }

    }

    public getRelatedEtkinMaddeText(etkinMaddeList: Array<EtkinMadde>): string {
        let output: string = "";

        etkinMaddeList.forEach(etkinMadde => {
            output += etkinMadde.etkinMaddeAdi + ", ";
        });
        return output.substring(0, output.length - 2);
    }

    public getSelectedDiagnosisText(teshis: TeshisListModel): string {
        let output: string = "";

        teshis.SelectedDiagnosisList.forEach(tani => {
            output += tani.taniKodu + "-" + tani.taniAdi + ", ";
        });
        return output.substring(0, output.length - 2);
    }

    async btnDelete_Click(value) {

        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Raporu Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? "), 1);
        if (result === "H") {
            ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
            return;
        }
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
        }
        try {
            if (this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.IsSendedMedula == true) {


                await this.signService.showLoginModal();
                this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));

                let signedReportOutput: string = await this.httpService.post<string>('/api/ParticipatnFreeDrugReportService/PrepareDeleteReportContent', this.participationFreeDrugReportNewFormViewModel);

                let signedContent: string = await this.signService.signContent(signedReportOutput);
                this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                let preSend: SendSignedReportDelete_Input = new SendSignedReportDelete_Input();
                preSend.signContent = signedContent;
                preSend.viewModel = this.participationFreeDrugReportNewFormViewModel;
                let response = <IlacRaporuServis.imzaliEraporSilCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/SendSignedReportDeleteContent', preSend);


                //let response = <IlacRaporuServis.eraporSilCevapDVO>await this.httpService.post('/api/ParticipatnFreeDrugReportService/Sil', this.participationFreeDrugReportNewFormViewModel);
                this.loadPanelOperation(false, '');
                if (response != null && response.sonucKodu === '0000') {
                    this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.CurrentStateDefID = MedulaReportResult.MedulaReportResultStates.Completed;
                    this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ResultCode = response.sonucKodu;
                    this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ResultExplanation = i18n("M20786", "Rapor Bilgisi Silinmiştir");
                    this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportRowNumber = null;
                    this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportNumber = "";
                    this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ReportChasingNo = "";

                    this.txtAciklamaEkleSonucMesaji.Text = response.sonucMesaji + " " + response.uyariMesaji + " " + i18n("M16831", "İşlem Başarılı.");
                }
                else {
                    if (!String.isNullOrEmpty(response.sonucMesaji)) {
                        this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ResultCode = response.sonucKodu;
                        this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult.ResultExplanation = "";
                        console.log(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + response.uyariMesaji + '' + response.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                        ServiceLocator.MessageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + response.uyariMesaji + '' + response.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                    }
                }


                const objectIdParam = new Guid(this._ParticipatnFreeDrugReport.ObjectID);
                await this.loadReportByID(objectIdParam);

                await this.SetFormReadOnlyControls();
                this.showSaveSuccessMessage();

                this.lastSelectedCell.OwningRow = this.participationFreeDrugReportNewFormViewModel.SelectededulaReportResult as ITTGridRow;
            }
            else {
                console.log(i18n("M18855", "Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Meduladan Silme İşlemi Yapamazsınız!!!"));
                ServiceLocator.MessageService.showError(i18n("M18855", "Medulaya Kaydı Yapılmamış Bir İlaç Raporunu Meduladan Silme İşlemi Yapamazsınız!!!"));
            }
        }
        catch (err) {
            this.loadPanelOperation(false, '');
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
            throw err;
        }
    }
    @HostListener('window:resize', ['$event'])
    resize(event: Event) {
        if (this.ScrollPanel) {
            let rect: ClientRect = this.ScrollPanel['nativeElement'].getBoundingClientRect();
            let top = rect.top;

            let viewPortHeight: number = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
            this.ScrollPanel['nativeElement'].style.height = (viewPortHeight - (top)).toString() + "px";
        }
    }



    ngOnDestroy() {
    }

    public fun(a: any) {

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PopupTextAreaForm';
        componentInfo.ModuleName = 'PopupTextAreaModule';
        componentInfo.ModulePath = 'Modules/Tibbi_Surec/Sosyal_Hizmetler_Modulu/PopupTextArea/PopupTextAreaModule';
        componentInfo.InputParam = new DynamicComponentInputParam(a.Text, new ActiveIDsModel(this._ParticipatnFreeDrugReport.ObjectID, null, null));

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = "";
        modalInfo.Width = 950;
        modalInfo.Height = 950;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                if (res.Param.toString() != "[object Object]")
                    a.Text = res.Param;
            }).catch(err => {
                reject(err);
            });
        });
        return promise;

    }

    onTeshisSelected(e: any): void {
        if (e.itemData != null) {
            this.selectedTeshis = e.itemData;
            this.selectedTeshisTaniList = e.itemData.AddedDiagnosisList;
            if (e.itemData.SelectedDiagnosisList == null)
                e.itemData.SelectedDiagnosisList = new Array<AddedDiagnosisListModel>();
            if (e.itemData.SelectedDiagnosisListKeys == null)
                e.itemData.SelectedDiagnosisListKeys = new Array<string>();

            this.selectedReportDiagnosisList = e.itemData.SelectedDiagnosisListKeys;
            //this.selectedReportDiagnosisList = new Array<Guid>();
            /*if (e.itemData.SelectedDiagnosisList != null) {
                e.itemData.SelectedDiagnosisList.forEach(element => {
                    this.selectedReportDiagnosisList.push(element.taniKodu);
                });
            }*/

        }
    }

    onRowSelectedTeshis(e: any): void {

        if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' && e.rowElement.firstItem().length === 1 && e.data != null) {

            if (e.data.teshisKodu != null) {
                let selected: boolean = false;
                if (this.selectedDiagnosisList != null) {
                    for (let viewModelDiagnosis of this.selectedDiagnosisList) {
                        if (viewModelDiagnosis.teshisObjectID == e.data.teshis.ObjectID) {
                            selected = true;
                        }
                    }
                }
                if (selected) {
                    e.rowElement.firstItem().style.backgroundColor = '#B5E196';
                    e.rowElement.firstItem().style.color = 'black';
                }
                else {
                    e.rowElement.firstItem().style.backgroundColor = 'transparent';
                    e.rowElement.firstItem().style.color = 'black';
                }
            }
        }
    }
    onSelectionChangedDiagnosisiList(e: any): void {
        if (e.selectedRowKeys != null && e.selectedRowKeys !== undefined) {
            for (let i = 0; i < e.selectedRowKeys.length; i++) {
                if (e.currentSelectedRowKeys != null && e.currentSelectedRowKeys.lenght > 0 && e.selectedRowKeys[i].Tani != e.currentSelectedRowKeys[0].Tani)
                    e.selectedRowKeys[i].selected = true;
                // this.selectedDiagnosisList.push(e.selectedRowKeys[i]);
            }
        }
        //  onSelectionChangedDiagnosisiList
        //if(e.selectedRowKeys)

    }

    onSelectionChangedDiagnosisList(e: any): void {

        if (e.selectedRowKeys != null && e.selectedRowKeys !== undefined) {
            for (let i = 0; i < e.selectedRowKeys.length; i++) {
                if (e.currentSelectedRowKeys != null && e.currentSelectedRowKeys.lenght > 0 && e.selectedRowKeys[i].Tani != e.currentSelectedRowKeys[0].Tani)
                    e.selectedRowKeys[i].selected = true;
                // this.selectedDiagnosisList.push(e.selectedRowKeys[i]);
            }
        }
        //  onSelectionChangedDiagnosisiList
        //if(e.selectedRowKeys)

    }


    CheckedItemControl(e: any): void {
        let keyFound = false;
        let itemFound = false;

        if (e.addedItems[0] != null && e.addedItems.length == 1) {
            if (this.selectedTeshis.SelectedDiagnosisList.length == 0 && this.selectedTeshis.SelectedDiagnosisListKeys.length == 1) {
                this.selectedTeshis.SelectedDiagnosisListKeys.splice(0, 1);
            }

            for (let i = 0; i < this.selectedTeshis.SelectedDiagnosisList.length; i++) {
                if (this.selectedTeshis.SelectedDiagnosisList[i].taniKodu == e.addedItems[0].taniKodu) {
                    itemFound = true;
                }
            }

            for (let i = 0; i < this.selectedTeshis.SelectedDiagnosisListKeys.length; i++) {
                if (this.selectedTeshis.SelectedDiagnosisListKeys[i] == e.addedItems[0].taniKodu) {
                    keyFound = true;
                }
            }

            if (!itemFound) {
                this.selectedTeshis.SelectedDiagnosisList.push(e.addedItems[0]);
            }
            if (!keyFound) {
                this.selectedTeshis.SelectedDiagnosisListKeys.push(e.addedItems[0].taniKodu);
            }


            this.selectedTeshis.selectedDiagnoses = this.getSelectedDiagnosisText(this.selectedTeshis);
        } else if (e.removedItems[0] != null && e.removedItems.length == 1) {

            for (let i = 0; i < this.selectedTeshis.SelectedDiagnosisList.length; i++) {
                if (this.selectedTeshis.SelectedDiagnosisList[i].taniKodu == e.removedItems[0].taniKodu) {
                    this.selectedTeshis.SelectedDiagnosisList.splice(i, 1);
                }
            }

            for (let i = 0; i < this.selectedTeshis.SelectedDiagnosisListKeys.length; i++) {
                if (this.selectedTeshis.SelectedDiagnosisListKeys[i] == e.removedItems[0].taniKodu) {
                    this.selectedTeshis.SelectedDiagnosisListKeys.splice(i, 1);
                }
            }
            this.selectedTeshis.selectedDiagnoses = this.getSelectedDiagnosisText(this.selectedTeshis);
        }

        /*if (e.itemData != null) {
            if(this.selectedTeshis.SelectedDiagnosisList.length==0 && this.selectedTeshis.SelectedDiagnosisListKeys.length == 1){
                this.selectedTeshis.SelectedDiagnosisListKeys.splice(0,1);
            }

            for(var i=0; i<this.selectedTeshis.SelectedDiagnosisList.length; i++){
                if(this.selectedTeshis.SelectedDiagnosisList[i].taniKodu == e.itemData.taniKodu){
                    this.selectedTeshis.SelectedDiagnosisList.splice(i,1);
                    itemFound=true;
                }
            }

            for(var i=0; i<this.selectedTeshis.SelectedDiagnosisListKeys.length; i++){
                if(this.selectedTeshis.SelectedDiagnosisListKeys[i] == e.itemData.taniKodu){
                    this.selectedTeshis.SelectedDiagnosisListKeys.splice(i,1);
                    keyFound = true;
                }
            }





        }*/

    }

    // kullanılmıyor
    //taniSelected(data: any) {
    //    if (data != null) {
    //        let that = this;
    //        let tani: TaniTeshisListModel = new TaniTeshisListModel();
    //        tani.Tani = data.ObjectID;
    //        if (data.Teshis != null)
    //            tani.Teshis = data.Teshis.ObjectID;
    //        that.participationFreeDrugReportNewFormViewModel.TaniTeshisList.push(tani);
    //    }
    //}

    eklenecekTaniSelected(data: any) {
        if (data != null) {
            let that = this;
            let addedTani: AddedDiagnosisListModel = new AddedDiagnosisListModel();
            addedTani.Tani = data;
            that.participationFreeDrugReportNewFormViewModel.AddedDiagnosisList.push(addedTani);
        }
    }
    public ontxtRaporSuresiChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.ReportDuration != event) {
                this._ParticipatnFreeDrugReport.ReportDuration = event;

                let thisdate: Date = new Date();
                thisdate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate;
                if (this._ParticipatnFreeDrugReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.DayPeriod) {
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = thisdate.AddDays(parseInt(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration.toString()));
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate.AddDays(-1);
                }
                if (this._ParticipatnFreeDrugReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.MonthPeriod) {
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = thisdate.AddMonths(parseInt(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration.toString()));
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate.AddDays(-1);
                }
                if (this._ParticipatnFreeDrugReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.YearPeriod) {
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = thisdate.AddYears(parseInt(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration.toString()));
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate.AddDays(-1);
                }
                if (this._ParticipatnFreeDrugReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.WeekPeriod) {
                    let gun: number = parseInt(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration.toString()) * 7;
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = thisdate.AddDays(gun);
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate.AddDays(-1);
                }
                if (this._ParticipatnFreeDrugReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.Undefinite) {
                    this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = null;
                }
            }
        }
    }

    public cmbRaporSureTuruChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.ReportDurationType != event) {
                this._ParticipatnFreeDrugReport.ReportDurationType = event;
            }
        }

        let thisdate: Date = new Date();
        thisdate = this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportStartDate;
        if (event == PeriodUnitTypeWithUndefiniteEnum.DayPeriod) {
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = thisdate.AddDays(parseInt(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration.toString()));
        }
        if (event == PeriodUnitTypeWithUndefiniteEnum.MonthPeriod) {
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = thisdate.AddMonths(parseInt(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration.toString()));
        }
        if (event == PeriodUnitTypeWithUndefiniteEnum.YearPeriod) {
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = thisdate.AddYears(parseInt(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration.toString()));
        }
        if (event == PeriodUnitTypeWithUndefiniteEnum.WeekPeriod) {
            let gun: number = parseInt(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration.toString()) * 7;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = thisdate.AddDays(gun);
        }
        if (event == PeriodUnitTypeWithUndefiniteEnum.Undefinite) {
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportEndDate = null;
            this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ReportDuration = null;
        }
    }
    public onCommitteeReportChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.CommitteeReport != event) {
                this._ParticipatnFreeDrugReport.CommitteeReport = event;
            }
        }
        this.CommitteeReport_CheckedChanged();
    }

    public onExaminationDateChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.ExaminationDate != event) {
                this._ParticipatnFreeDrugReport.ExaminationDate = event;
            }
        }
    }

    public async onlistSecondDoctorChanged(event) {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.SecondDoctor != event) {
                this._ParticipatnFreeDrugReport.SecondDoctor = event;
            }

            if (this._ParticipatnFreeDrugReport.ReportStartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._ParticipatnFreeDrugReport.SecondDoctor.ObjectID, this._ParticipatnFreeDrugReport.ReportStartDate);
                if (a) {
                    this.messageService.showInfo(this._ParticipatnFreeDrugReport.SecondDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._ParticipatnFreeDrugReport.SecondDoctor = null;
                    }, 500);
                }
            }
        }
    }

    public onPatientEnterpriseChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.PatientEnterprise != event) {
                this._ParticipatnFreeDrugReport.PatientEnterprise = event;
            }
        }
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.ProcedureDoctor != event) {
                this._ParticipatnFreeDrugReport.ProcedureDoctor = event;
            }

            if (this._ParticipatnFreeDrugReport.ReportStartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._ParticipatnFreeDrugReport.ProcedureDoctor.ObjectID, this._ParticipatnFreeDrugReport.ReportStartDate);
                if (a) {
                    this.messageService.showInfo(this._ParticipatnFreeDrugReport.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._ParticipatnFreeDrugReport.ProcedureDoctor = null;
                    }, 500);
                }
            }

        }
        // this.ProcedureDoctor_SelectedObjectChanged();
    }

    public onProtocolNumberChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.ProtocolNumber != event) {
                this._ParticipatnFreeDrugReport.ProtocolNumber = event;
            }
        }
    }

    public onReportEndDateChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.ReportEndDate != event) {
                this._ParticipatnFreeDrugReport.ReportEndDate = event;
            }
        }
    }

    public async onReportStartDateChanged(event) {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.ReportStartDate != event) {
                this._ParticipatnFreeDrugReport.ReportStartDate = event;
            }

            if (this._ParticipatnFreeDrugReport.ProcedureDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._ParticipatnFreeDrugReport.ProcedureDoctor.ObjectID, this._ParticipatnFreeDrugReport.ReportStartDate);
                if (a) {
                    this.messageService.showInfo(this._ParticipatnFreeDrugReport.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._ParticipatnFreeDrugReport.ProcedureDoctor = null;
                    }, 500);
                }
            }

            if (this._ParticipatnFreeDrugReport.SecondDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._ParticipatnFreeDrugReport.SecondDoctor.ObjectID, this._ParticipatnFreeDrugReport.ReportStartDate);
                if (a) {
                    this.messageService.showInfo(this._ParticipatnFreeDrugReport.SecondDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._ParticipatnFreeDrugReport.SecondDoctor = null;
                    }, 500);
                }
            }

            if (this._ParticipatnFreeDrugReport.ThirdDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._ParticipatnFreeDrugReport.ThirdDoctor.ObjectID, this._ParticipatnFreeDrugReport.ReportStartDate);
                if (a) {
                    this.messageService.showInfo(this._ParticipatnFreeDrugReport.ThirdDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._ParticipatnFreeDrugReport.ThirdDoctor = null;
                    }, 500);
                }
            }
        }
    }

    public onSocialInsuranceChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.SocialInsurance != event) {
                this._ParticipatnFreeDrugReport.SocialInsurance = event;
            }
        }
    }

    public onTestsAndSignsChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.TestsAndSigns != event) {
                this._ParticipatnFreeDrugReport.TestsAndSigns = event;
            }
        }
    }

    public async onThirdDoctorChanged(event) {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.ThirdDoctor != event) {
                this._ParticipatnFreeDrugReport.ThirdDoctor = event;
            }

            if (this._ParticipatnFreeDrugReport.ReportStartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._ParticipatnFreeDrugReport.ThirdDoctor.ObjectID, this._ParticipatnFreeDrugReport.ReportStartDate);
                if (a) {
                    this.messageService.showInfo(this._ParticipatnFreeDrugReport.ThirdDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._ParticipatnFreeDrugReport.ThirdDoctor = null;
                    }, 500);
                }
            }
        }
    }

    public onttrichtextboxAciklamaChanged(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.Description != event) {
                this._ParticipatnFreeDrugReport.Description = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null &&
                this._ParticipatnFreeDrugReport.Episode != null &&
                this._ParticipatnFreeDrugReport.Episode.Patient != null && this._ParticipatnFreeDrugReport.Episode.Patient.UniqueRefNo != event) {
                this._ParticipatnFreeDrugReport.Episode.Patient.UniqueRefNo = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null && this._ParticipatnFreeDrugReport.ExamptionProtocolNo != event) {
                this._ParticipatnFreeDrugReport.ExamptionProtocolNo = event;
            }
        }
    }

    public ontttextbox7Changed(event): void {
        if (event != null) {
            if (this._ParticipatnFreeDrugReport != null &&
                this._ParticipatnFreeDrugReport.MasterResource != null && this._ParticipatnFreeDrugReport.MasterResource.Name != event) {
                this._ParticipatnFreeDrugReport.MasterResource.Name = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.CommitteeReport, "Value", this.__ttObject, "CommitteeReport");
        redirectProperty(this.PatientApprovalFormNo, "Text", this.__ttObject, "PatientApprovalFormNo");
        redirectProperty(this.ExaminationDate, "Value", this.__ttObject, "ExaminationDate");
        redirectProperty(this.ProtocolNumber, "Text", this.__ttObject, "ProtocolNumber");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "ExamptionProtocolNo");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Episode.Patient.UniqueRefNo");
        redirectProperty(this.ttrichtextboxAciklama, "Rtf", this.__ttObject, "Description");
        redirectProperty(this.PatientEnterprise, "Text", this.__ttObject, "PatientEnterprise");
        redirectProperty(this.tttextbox7, "Text", this.__ttObject, "MasterResource.Name");
        redirectProperty(this.SocialInsurance, "Text", this.__ttObject, "SocialInsurance");
        redirectProperty(this.TestsAndSigns, "Rtf", this.__ttObject, "TestsAndSigns");
        redirectProperty(this.ReportStartDate, "Value", this.__ttObject, "ReportStartDate");
        redirectProperty(this.ReportEndDate, "Value", this.__ttObject, "ReportEndDate");
        redirectProperty(this.txtAciklamaEkleAciklama, "Text", this.__ttObject, "txtAciklamaEkleAciklama");
    }

    public initFormControls(): void {
        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 0;

        this.tttabHastaKatilimPayindanMuafIlacRaporu = new TTVisual.TTTabPage();
        this.tttabHastaKatilimPayindanMuafIlacRaporu.DisplayIndex = 0;
        this.tttabHastaKatilimPayindanMuafIlacRaporu.TabIndex = 0;
        this.tttabHastaKatilimPayindanMuafIlacRaporu.Text = i18n("M15259", "Hasta Katılım Payından Muaf İlaç Raporu");
        this.tttabHastaKatilimPayindanMuafIlacRaporu.Name = "tttabHastaKatilimPayindanMuafIlacRaporu";

        this.EtkinMaddeList = new TTVisual.TTObjectListBox();
        this.EtkinMaddeList.ListDefName = "EtkinMaddeListDefinition";
        this.EtkinMaddeList.Name = "EtkinMAddeList";

        this.PatientApprovalFormNo = new TTVisual.TTMaskedTextBox();
        this.PatientApprovalFormNo.Mask = "000000000";
        this.PatientApprovalFormNo.Name = "PatientApprovalFormNo";
        this.PatientApprovalFormNo.TabIndex = 48;

        this.labelPatientApprovalFormNo = new TTVisual.TTLabel();
        this.labelPatientApprovalFormNo.Text = i18n("M15288", "Hasta Onay Formu No");
        this.labelPatientApprovalFormNo.Name = "labelPatientApprovalFormNo";
        this.labelPatientApprovalFormNo.TabIndex = 47;

        this.CommitteeReport = new TTVisual.TTCheckBox();
        this.CommitteeReport.Value = false;
        this.CommitteeReport.Text = "Heyet";
        this.CommitteeReport.Title = "Heyet";
        this.CommitteeReport.Name = "CommitteeReport";
        this.CommitteeReport.TabIndex = 0;

        this.TaniListesi = new TTVisual.TTObjectListBox();
        this.TaniListesi.ListDefName = "DiagnosisListDefinition";
        this.TaniListesi.Name = "TaniListesi";

        this.EklenecekTaniListesi = new TTVisual.TTObjectListBox();
        this.EklenecekTaniListesi.ListDefName = "DiagnosisListDefinition";
        this.EklenecekTaniListesi.Name = "EklenecekTaniListesi";

        this.ThirdDoctor = new TTVisual.TTObjectListBox();
        this.ThirdDoctor.ListDefName = "DoctorListDefinition";
        this.ThirdDoctor.Name = "ThirdDoctor";
        this.ThirdDoctor.TabIndex = 4;
        this.ThirdDoctor.Visible = true;
        this.ThirdDoctor.ReadOnly = this.participationFreeDrugReportNewFormViewModel.ReadOnly;

        this.listSecondDoctor = new TTVisual.TTObjectListBox();
        this.listSecondDoctor.ListDefName = "DoctorListDefinition";
        this.listSecondDoctor.Name = "listSecondDoctor";
        this.listSecondDoctor.TabIndex = 3;
        this.listSecondDoctor.Visible = true;
        this.listSecondDoctor.ReadOnly = this.participationFreeDrugReportNewFormViewModel.ReadOnly;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M18730", "Medula Açıklama");
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 13;

        this.ttrichtextboxAciklama = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxAciklama.Name = "ttrichtextboxAciklama";
        this.ttrichtextboxAciklama.TabIndex = 9;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M19222", "Muayene Tarihi");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 3;

        this.tttabIslemler = new TTVisual.TTTabControl();
        this.tttabIslemler.Name = "tttabIslemler";
        this.tttabIslemler.TabIndex = 15;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 0;
        this.tttabpage3.TabIndex = 0;
        this.tttabpage3.Text = i18n("M18770", "Medula İşlemleri");
        this.tttabpage3.Name = "tttabpage3";

        this.btnLoadFromSection = new TTVisual.TTButton();
        this.btnLoadFromSection.Text = i18n("M12039", "Bölüm Şablonlarından Yükle");
        this.btnLoadFromSection.Name = "btnLoadFromSection";
        this.btnLoadFromSection.TabIndex = 5;

        this.btn2Years = new TTVisual.TTButton();
        this.btn2Years.Text = i18n("M10178", "2 Yıl");
        this.btn2Years.Name = "btn2Years";
        this.btn2Years.TabIndex = 3;

        this.btn1Year = new TTVisual.TTButton();
        this.btn1Year.Text = i18n("M10074", "1 Yıl");
        this.btn1Year.Name = "btn1Year";
        this.btn1Year.TabIndex = 1;

        this.btn6Months = new TTVisual.TTButton();
        this.btn6Months.Text = "6 Ay";
        this.btn6Months.Name = "btn6Months";
        this.btn6Months.TabIndex = 2;

        this.btn3Months = new TTVisual.TTButton();
        this.btn3Months.Text = "3 Ay";
        this.btn3Months.Name = "btn3Months";
        this.btn3Months.TabIndex = 0;

        this.btnDeleteTemplate = new TTVisual.TTButton();
        this.btnDeleteTemplate.Text = i18n("M22456", "Şablon Sil");
        this.btnDeleteTemplate.Name = "btnDeleteTemplate";
        this.btnDeleteTemplate.TabIndex = 8;

        this.btnSaveAsTemplate = new TTVisual.TTButton();
        this.btnSaveAsTemplate.Text = i18n("M22452", "Şablon Olarak Kaydet");
        this.btnSaveAsTemplate.Name = "btnSaveAsTemplate";
        this.btnSaveAsTemplate.TabIndex = 7;

        this.btnLoadFromUser = new TTVisual.TTButton();
        this.btnLoadFromUser.Text = i18n("M17919", "Kullanıcı Şablonlarından Yükle");
        this.btnLoadFromUser.Name = "btnLoadFromUser";
        this.btnLoadFromUser.TabIndex = 6;

        this.btnMedulaBashekimOnay = new TTVisual.TTButton();
        this.btnMedulaBashekimOnay.Text = i18n("M18734", " Medula Başhekim Onay ");
        this.btnMedulaBashekimOnay.Name = "btnMedulaBashekimOnay";
        this.btnMedulaBashekimOnay.TabIndex = 10;
        this.btnMedulaBashekimOnay.Visible = false;

        this.btnUcuncuTabipOnay = new TTVisual.TTButton();
        this.btnUcuncuTabipOnay.Text = i18n("M10292", "3.Tabip Onay");
        this.btnUcuncuTabipOnay.Name = "btnUcuncuTabipOnay";
        this.btnUcuncuTabipOnay.TabIndex = 49;
        this.btnUcuncuTabipOnay.Visible = false;

        this.btnIkinciTabipOnay = new TTVisual.TTButton();
        this.btnIkinciTabipOnay.Text = i18n("M10224", "2.Tabip Onay");
        this.btnIkinciTabipOnay.Name = "btnIkinciTabipOnay";
        this.btnIkinciTabipOnay.TabIndex = 48;
        this.btnIkinciTabipOnay.Visible = false;

        this.labelReportStartDate = new TTVisual.TTLabel();
        this.labelReportStartDate.Text = i18n("M18789", "Medula Rapor Başlangıç Tarihi");
        this.labelReportStartDate.Name = "labelReportStartDate";
        this.labelReportStartDate.TabIndex = 6;

        this.ReportStartDate = new TTVisual.TTDateTimePicker();
        this.ReportStartDate.Format = DateTimePickerFormat.Short;
        this.ReportStartDate.Name = "ReportStartDate";
        this.ReportStartDate.TabIndex = 0;

        this.labelReportEndDate = new TTVisual.TTLabel();
        this.labelReportEndDate.Text = i18n("M18791", "Medula Rapor Bitiş Tarihi");
        this.labelReportEndDate.Name = "labelReportEndDate";
        this.labelReportEndDate.TabIndex = 4;

        this.ReportEndDate = new TTVisual.TTDateTimePicker();
        this.ReportEndDate.Format = DateTimePickerFormat.Short;
        this.ReportEndDate.Name = "ReportEndDate";
        this.ReportEndDate.TabIndex = 4;

        this.btnRaporKaydet = new TTVisual.TTButton();
        this.btnRaporKaydet.Text = i18n("M20896", " Raporu Kaydet");
        this.btnRaporKaydet.Name = "btnRaporKaydet";
        this.btnRaporKaydet.TabIndex = 9;

        this.btnHastaIlacRaporuListesi = new TTVisual.TTButton();
        this.btnHastaIlacRaporuListesi.Text = i18n("M15234", "Hasta İlaç Raporu Listesi");
        this.btnHastaIlacRaporuListesi.Name = "btnHastaIlacRaporuListesi";
        this.btnHastaIlacRaporuListesi.TabIndex = 12;

        this.cmbRaporSureTuru = new TTVisual.TTEnumComboBox();
        this.cmbRaporSureTuru.DataTypeName = "PeriodUnitTypeWithUndefiniteEnum";
        this.cmbRaporSureTuru.Required = true;
        this.cmbRaporSureTuru.Name = "cmbRaporSureTuru";
        this.cmbRaporSureTuru.TabIndex = 4;
        this.cmbRaporSureTuru.ReadOnly = this.participationFreeDrugReportNewFormViewModel.ReadOnly;

        this.txtRaporSuresi = new TTVisual.TTTextBox();
        this.txtRaporSuresi.Multiline = false;
        this.txtRaporSuresi.Name = "txtRaporSuresi";
        this.txtRaporSuresi.TabIndex = 0;
        this.txtRaporSuresi.ReadOnly = this.participationFreeDrugReportNewFormViewModel.ReadOnly;

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 1;
        this.tttabpage4.TabIndex = 1;
        this.tttabpage4.Text = i18n("M18793", "Medula Rapor İşlemleri");
        this.tttabpage4.Name = "tttabpage4";

        this.MedulaReportResults = new TTVisual.TTGrid();
        this.MedulaReportResults.Name = "MedulaReportResults";
        this.MedulaReportResults.TabIndex = 39;
        this.MedulaReportResults.AllowUserToAddRows = false;
        this.MedulaReportResults.AllowUserToDeleteRows = false;
        this.MedulaReportResults.Height = 150;

        this.ReportChasingNoMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ReportChasingNoMedulaReportResult.DataMember = "ReportChasingNo";
        this.ReportChasingNoMedulaReportResult.DisplayIndex = 0;
        this.ReportChasingNoMedulaReportResult.HeaderText = i18n("M20855", "Rapor Takip No");
        this.ReportChasingNoMedulaReportResult.Name = "ReportChasingNoMedulaReportResult";
        this.ReportChasingNoMedulaReportResult.Width = 100;

        this.ReportNumberMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ReportNumberMedulaReportResult.DataMember = "ReportNumber";
        this.ReportNumberMedulaReportResult.DisplayIndex = 1;
        this.ReportNumberMedulaReportResult.HeaderText = i18n("M20821", "Rapor No");
        this.ReportNumberMedulaReportResult.Name = "ReportNumberMedulaReportResult";
        this.ReportNumberMedulaReportResult.Width = 80;

        this.ReportRowNumberMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ReportRowNumberMedulaReportResult.DataMember = "ReportRowNumber";
        this.ReportRowNumberMedulaReportResult.DisplayIndex = 2;
        this.ReportRowNumberMedulaReportResult.HeaderText = i18n("M20844", "Rapor Sıra No");
        this.ReportRowNumberMedulaReportResult.Name = "ReportRowNumberMedulaReportResult";
        this.ReportRowNumberMedulaReportResult.Width = 100;

        this.ResultCodeMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ResultCodeMedulaReportResult.DataMember = "ResultCode";
        this.ResultCodeMedulaReportResult.DisplayIndex = 3;
        this.ResultCodeMedulaReportResult.HeaderText = i18n("M22075", "Sonuc Kodu");
        this.ResultCodeMedulaReportResult.Name = "ResultCodeMedulaReportResult";
        this.ResultCodeMedulaReportResult.ReadOnly = true;
        this.ResultCodeMedulaReportResult.Width = 90;

        this.ResultExplanationMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ResultExplanationMedulaReportResult.DataMember = "ResultExplanation";
        this.ResultExplanationMedulaReportResult.DisplayIndex = 4;
        this.ResultExplanationMedulaReportResult.HeaderText = i18n("M22088", "Sonuç Açıklaması");
        this.ResultExplanationMedulaReportResult.Name = "ResultExplanationMedulaReportResult";
        this.ResultExplanationMedulaReportResult.ReadOnly = true;
        this.ResultExplanationMedulaReportResult.Width = 400;

        this.SendReportDateMedulaReportResult = new TTVisual.TTDateTimePickerColumn();
        this.SendReportDateMedulaReportResult.DataMember = "SendReportDate";
        this.SendReportDateMedulaReportResult.DisplayIndex = 5;
        this.SendReportDateMedulaReportResult.HeaderText = i18n("M20771", "Rapor Başlandıç Tarihi");
        this.SendReportDateMedulaReportResult.Name = "SendReportDateMedulaReportResult";
        this.SendReportDateMedulaReportResult.Width = 150;

        this.btnOnay = new TTVisual.TTButtonColumn();
        this.btnOnay.DisplayIndex = 6;
        this.btnOnay.HeaderText = i18n("M19673", "Onay");
        this.btnOnay.Name = "btnOnay";
        this.btnOnay.Visible = false;
        this.btnOnay.Width = 50;

        this.btnOnayIptal = new TTVisual.TTButtonColumn();
        this.btnOnayIptal.DisplayIndex = 7;
        this.btnOnayIptal.HeaderText = i18n("M19681", "Onay Iptal");
        this.btnOnayIptal.Name = "btnOnayIptal";
        this.btnOnayIptal.Visible = false;
        this.btnOnayIptal.Width = 70;

        this.btnRaporuSil = new TTVisual.TTButtonColumn();
        this.btnRaporuSil.DisplayIndex = 8;
        this.btnRaporuSil.HeaderText = "";
        this.btnRaporuSil.Name = "btnRaporuSil";
        this.btnRaporuSil.Visible = true;
        //this.btnRaporuSil.Width = 50;
        this.btnRaporuSil.Text = "Sil";

        this.btnInfo = new TTVisual.TTButtonColumn();
        this.btnInfo.DisplayIndex = 8;
        this.btnInfo.HeaderText = "";
        this.btnInfo.Name = "btnInfo";
        this.btnInfo.Visible = true;
        //this.btnInfo.Width = 80;
        this.btnInfo.Text = "Detay";

        this.btnGridAciklamaEkle = new TTVisual.TTButtonColumn();
        this.btnGridAciklamaEkle.DisplayIndex = 9;
        this.btnGridAciklamaEkle.HeaderText = "";
        this.btnGridAciklamaEkle.Name = "btnGridAciklamaEkle";
        //this.btnGridAciklamaEkle.Width = 100;
        this.btnGridAciklamaEkle.ReadOnly = false;
        this.btnGridAciklamaEkle.Text = "Açıklama Ekle";

        this.btnGridTaniEkle = new TTVisual.TTButtonColumn();
        this.btnGridTaniEkle.DisplayIndex = 10;
        this.btnGridTaniEkle.HeaderText = "";
        this.btnGridTaniEkle.Name = "btnGridTaniEkle";
        //this.btnGridTaniEkle.Width = 100;
        this.btnGridTaniEkle.Text = "Tanı Ekle";

        this.btnGridTeshisEkle = new TTVisual.TTButtonColumn();
        this.btnGridTeshisEkle.DisplayIndex = 11;
        this.btnGridTeshisEkle.HeaderText = "";
        this.btnGridTeshisEkle.Name = "btnGridTeshisEkle";
        //this.btnGridTeshisEkle.Width = 100;
        this.btnGridTeshisEkle.Text = "Teşhis Ekle";

        this.btnGridEtkinMaddeEkle = new TTVisual.TTButtonColumn();
        this.btnGridEtkinMaddeEkle.DisplayIndex = 12;
        this.btnGridEtkinMaddeEkle.HeaderText = "";
        this.btnGridEtkinMaddeEkle.Name = "btnGridEtkinMaddeEkle";
        //this.btnGridEtkinMaddeEkle.Width = 100;
        this.btnGridEtkinMaddeEkle.Text = "Etkin Madde Ekle";

        this.tabAciklamaEkle = new TTVisual.TTTabPage();
        this.tabAciklamaEkle.DisplayIndex = 2;
        this.tabAciklamaEkle.TabIndex = 2;
        this.tabAciklamaEkle.Text = i18n("M10474", "Açıklama Ekle");
        this.tabAciklamaEkle.Visible = false;
        this.tabAciklamaEkle.Name = "tabAciklamaEkle";

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M22103", "Sonuç Mesajı");
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 7;

        this.txtAciklamaEkleSonucMesaji = new TTVisual.TTTextBox();
        //this.txtAciklamaEkleSonucMesaji.BackColor = "#F0F0F0";
        this.txtAciklamaEkleSonucMesaji.ReadOnly = true;
        this.txtAciklamaEkleSonucMesaji.Name = "txtAciklamaEkleSonucMesaji";
        this.txtAciklamaEkleSonucMesaji.TabIndex = 6;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M10469", "Açıklama");
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 5;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = "Takip Formu Nu.";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 4;

        this.txtAciklamaEkleAciklama = new TTVisual.TTTextBox();
        this.txtAciklamaEkleAciklama.Multiline = true;
        this.txtAciklamaEkleAciklama.Name = "txtAciklamaEkleAciklama";
        this.txtAciklamaEkleAciklama.TabIndex = 3;
        this.txtAciklamaEkleAciklama.Height = "50";

        this.txtAciklamaEkleTakipFormuNo = new TTVisual.TTTextBox();
        this.txtAciklamaEkleTakipFormuNo.Name = "txtAciklamaEkleTakipFormuNo";
        this.txtAciklamaEkleTakipFormuNo.TabIndex = 2;

        this.btnAciklamaEkle = new TTVisual.TTButton();
        this.btnAciklamaEkle.Text = i18n("M10474", "Açıklama Ekle");
        this.btnAciklamaEkle.Name = "btnAciklamaEkle";
        this.btnAciklamaEkle.TabIndex = 1;

        this.tabTaniEkle = new TTVisual.TTTabPage();
        this.tabTaniEkle.DisplayIndex = 3;
        this.tabTaniEkle.TabIndex = 3;
        this.tabTaniEkle.Text = i18n("M22744", "Tanı Ekle");
        this.tabTaniEkle.Visible = false;
        this.tabTaniEkle.Name = "tabTaniEkle";

        this.ttlabel19 = new TTVisual.TTLabel();
        this.ttlabel19.Text = i18n("M23281", "Teşhis");
        this.ttlabel19.Name = "ttlabel19";
        this.ttlabel19.TabIndex = 11;

        this.lstTeshisAddedToDiagnosis = new TTVisual.TTObjectListBox();
        this.lstTeshisAddedToDiagnosis.ListDefName = "TeshisListDefinition";
        this.lstTeshisAddedToDiagnosis.Name = "lstTeshisAddedToDiagnosis";
        this.lstTeshisAddedToDiagnosis.TabIndex = 10;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = i18n("M22103", "Sonuç Mesajı");
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 9;

        this.ttlabel17 = new TTVisual.TTLabel();
        this.ttlabel17.Text = i18n("M22099", "Sonuç Kodu");
        this.ttlabel17.Name = "ttlabel17";
        this.ttlabel17.TabIndex = 8;

        this.txtTaniEkleSonucMesaji = new TTVisual.TTTextBox();
        //this.txtTaniEkleSonucMesaji.BackColor = "#F0F0F0";
        this.txtTaniEkleSonucMesaji.ReadOnly = true;
        this.txtTaniEkleSonucMesaji.Name = "txtTaniEkleSonucMesaji";
        this.txtTaniEkleSonucMesaji.TabIndex = 7;

        this.txtTaniEkleSonucKodu = new TTVisual.TTTextBox();
        //this.txtTaniEkleSonucKodu.BackColor = "#F0F0F0";
        this.txtTaniEkleSonucKodu.ReadOnly = true;
        this.txtTaniEkleSonucKodu.Name = "txtTaniEkleSonucKodu";
        this.txtTaniEkleSonucKodu.TabIndex = 6;

        this.btnTaniEkle = new TTVisual.TTButton();
        this.btnTaniEkle.Text = i18n("M22744", "Tanı Ekle");
        this.btnTaniEkle.Name = "btnTaniEkle";
        this.btnTaniEkle.TabIndex = 5;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = i18n("M22736", "Tanı");
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 2;

        this.lstDiagnosisAddedToEpisode = new TTVisual.TTObjectListBox();
        this.lstDiagnosisAddedToEpisode.ListDefName = "DiagnosisListDefinition";
        this.lstDiagnosisAddedToEpisode.Name = "lstDiagnosisAddedToEpisode";
        this.lstDiagnosisAddedToEpisode.TabIndex = 1;

        this.tabTeshisEkle = new TTVisual.TTTabPage();
        this.tabTeshisEkle.DisplayIndex = 4;
        this.tabTeshisEkle.TabIndex = 4;
        this.tabTeshisEkle.Text = i18n("M23285", "Teşhis Ekle");
        this.tabTeshisEkle.Visible = false;
        this.tabTeshisEkle.Name = "tabTeshisEkle";

        this.ttlabel25 = new TTVisual.TTLabel();
        this.ttlabel25.Text = i18n("M11939", "Bitiş Tarihi");
        this.ttlabel25.Name = "ttlabel25";
        this.ttlabel25.TabIndex = 13;

        this.ttlabel24 = new TTVisual.TTLabel();
        this.ttlabel24.Text = i18n("M11637", "Başlangıç Tarihi");
        this.ttlabel24.Name = "ttlabel24";
        this.ttlabel24.TabIndex = 12;

        this.TeshisEndDate = new TTVisual.TTDateTimePicker();
        this.TeshisEndDate.CustomFormat = "dd/MM/yyyy";
        this.TeshisEndDate.Format = DateTimePickerFormat.Short;
        this.TeshisEndDate.Name = "TeshisEndDate";
        this.TeshisEndDate.TabIndex = 11;

        this.TeshistStartDate = new TTVisual.TTDateTimePicker();
        this.TeshistStartDate.CustomFormat = "dd/MM/yyyy";
        this.TeshistStartDate.Format = DateTimePickerFormat.Short;
        this.TeshistStartDate.Name = "TeshistStartDate";
        this.TeshistStartDate.TabIndex = 10;

        this.ttlabel23 = new TTVisual.TTLabel();
        this.ttlabel23.Text = i18n("M22103", "Sonuç Mesajı");
        this.ttlabel23.Name = "ttlabel23";
        this.ttlabel23.TabIndex = 9;

        this.ttlabel22 = new TTVisual.TTLabel();
        this.ttlabel22.Text = i18n("M22099", "Sonuç Kodu");
        this.ttlabel22.Name = "ttlabel22";
        this.ttlabel22.TabIndex = 8;

        this.txtTeshisEkleSonucKodu = new TTVisual.TTTextBox();
        //this.txtTeshisEkleSonucKodu.BackColor = "#F0F0F0";
        this.txtTeshisEkleSonucKodu.ReadOnly = true;
        this.txtTeshisEkleSonucKodu.Name = "txtTeshisEkleSonucKodu";
        this.txtTeshisEkleSonucKodu.TabIndex = 7;

        this.txtTeshisEkleSonucMesaji = new TTVisual.TTTextBox();
        this.txtTeshisEkleSonucMesaji.Multiline = true;
        //this.txtTeshisEkleSonucMesaji.BackColor = "#F0F0F0";
        this.txtTeshisEkleSonucMesaji.ReadOnly = true;
        this.txtTeshisEkleSonucMesaji.Name = "txtTeshisEkleSonucMesaji";
        this.txtTeshisEkleSonucMesaji.TabIndex = 6;

        this.btnTeshisEkle = new TTVisual.TTButton();
        this.btnTeshisEkle.Text = i18n("M23285", "Teşhis Ekle");
        this.btnTeshisEkle.Name = "btnTeshisEkle";
        this.btnTeshisEkle.TabIndex = 5;

        this.ttlabel21 = new TTVisual.TTLabel();
        this.ttlabel21.Text = i18n("M22736", "Tanı");
        this.ttlabel21.Name = "ttlabel21";
        this.ttlabel21.TabIndex = 4;

        this.ttlabel20 = new TTVisual.TTLabel();
        this.ttlabel20.Text = i18n("M23281", "Teşhis");
        this.ttlabel20.Name = "ttlabel20";
        this.ttlabel20.TabIndex = 3;

        this.gridAddedDiagnosis = new TTVisual.TTGrid();
        this.gridAddedDiagnosis.Name = "gridAddedDiagnosis";
        this.gridAddedDiagnosis.TabIndex = 1;
        this.gridAddedDiagnosis.AllowUserToAddRows = false;
        this.gridAddedDiagnosis.DeleteButtonWidth = 70;

        this.gridTeshisEkleTanilari = new TTVisual.TTListBoxColumn();
        this.gridTeshisEkleTanilari.ListDefName = "DiagnosisListDefinition";
        this.gridTeshisEkleTanilari.DataMember = "Tani";
        this.gridTeshisEkleTanilari.DisplayIndex = 0;
        this.gridTeshisEkleTanilari.HeaderText = i18n("M22736", "Tanı");
        this.gridTeshisEkleTanilari.Name = "gridTeshisEkleTanilari";
        this.gridTeshisEkleTanilari.Width = 500;

        this.lstDiagnoseAddedToTeshis = new TTVisual.TTObjectListBox();
        this.lstDiagnoseAddedToTeshis.ListDefName = "TeshisListDefinition";
        this.lstDiagnoseAddedToTeshis.Name = "lstDiagnoseAddedToTeshis";
        this.lstDiagnoseAddedToTeshis.TabIndex = 0;

        this.tabEtkinMaddeEkle = new TTVisual.TTTabPage();
        this.tabEtkinMaddeEkle.DisplayIndex = 5;
        this.tabEtkinMaddeEkle.TabIndex = 5;
        this.tabEtkinMaddeEkle.Text = i18n("M13947", "Etkin Madde Ekle");
        this.tabEtkinMaddeEkle.Visible = false;
        this.tabEtkinMaddeEkle.Name = "tabEtkinMaddeEkle";

        this.ttlabel32 = new TTVisual.TTLabel();
        this.ttlabel32.Text = i18n("M22103", "Sonuç Mesajı");
        this.ttlabel32.Name = "ttlabel32";
        this.ttlabel32.TabIndex = 16;

        this.txtEtkinMaddeEkleSonucMesaji = new TTVisual.TTTextBox();
        //this.txtEtkinMaddeEkleSonucMesaji.BackColor = "#F0F0F0";
        this.txtEtkinMaddeEkleSonucMesaji.ReadOnly = true;
        this.txtEtkinMaddeEkleSonucMesaji.Name = "txtEtkinMaddeEkleSonucMesaji";
        this.txtEtkinMaddeEkleSonucMesaji.TabIndex = 15;

        this.txtEtkinMaddeEkleSonucKodu = new TTVisual.TTTextBox();
        // this.txtEtkinMaddeEkleSonucKodu.BackColor = "#F0F0F0";
        this.txtEtkinMaddeEkleSonucKodu.ReadOnly = true;
        this.txtEtkinMaddeEkleSonucKodu.Name = "txtEtkinMaddeEkleSonucKodu";
        this.txtEtkinMaddeEkleSonucKodu.TabIndex = 14;

        this.ttlabel31 = new TTVisual.TTLabel();
        this.ttlabel31.Text = i18n("M22099", "Sonuç Kodu");
        this.ttlabel31.Name = "ttlabel31";
        this.ttlabel31.TabIndex = 13;

        this.cmdEkelenecekPeriyodBirimi = new TTVisual.TTEnumComboBox();
        this.cmdEkelenecekPeriyodBirimi.DataTypeName = "PeriodUnitTypeEnum";
        this.cmdEkelenecekPeriyodBirimi.Name = "cmdEkelenecekPeriyodBirimi";
        this.cmdEkelenecekPeriyodBirimi.TabIndex = 12;

        this.ttlabel30 = new TTVisual.TTLabel();
        this.ttlabel30.Text = i18n("M17980", "Kullanım Periyot Birimi");
        this.ttlabel30.Name = "ttlabel30";
        this.ttlabel30.TabIndex = 11;

        this.ttlabel29 = new TTVisual.TTLabel();
        this.ttlabel29.Text = i18n("M17974", "Kullanım Periyodu");
        this.ttlabel29.Name = "ttlabel29";
        this.ttlabel29.TabIndex = 10;

        this.txtEklenecekPeriyodu = new TTVisual.TTTextBox();
        this.txtEklenecekPeriyodu.Name = "txtEklenecekPeriyodu";
        this.txtEklenecekPeriyodu.TabIndex = 9;

        this.txtEklenecekDoz = new TTVisual.TTTextBox();
        this.txtEklenecekDoz.Name = "txtEklenecekDoz";
        this.txtEklenecekDoz.TabIndex = 8;

        this.txtEklenecekDoz2 = new TTVisual.TTTextBox();
        this.txtEklenecekDoz2.Name = "txtEklenecekDoz2";
        this.txtEklenecekDoz2.TabIndex = 8;

        this.cmbEklenecekDozBirimi = new TTVisual.TTEnumComboBox();
        this.cmbEklenecekDozBirimi.DataTypeName = "UsageDoseUnitTypeEnum";
        this.cmbEklenecekDozBirimi.Name = "cmbEklenecekDozBirimi";
        this.cmbEklenecekDozBirimi.TabIndex = 7;

        this.cmbEklenecekDozAraligi = new TTVisual.TTEnumComboBox();
        this.cmbEklenecekDozAraligi.DataTypeName = "FrequencyEnum";
        this.cmbEklenecekDozAraligi.Name = "cmbEklenecekDozAraligi";
        this.cmbEklenecekDozAraligi.TabIndex = 6;

        this.ttlabel28 = new TTVisual.TTLabel();
        this.ttlabel28.Text = i18n("M17970", "Kullanım Doz Birimi");
        this.ttlabel28.Name = "ttlabel28";
        this.ttlabel28.TabIndex = 5;

        this.ttlabel27 = new TTVisual.TTLabel();
        this.ttlabel27.Text = i18n("M13284", "Doz");
        this.ttlabel27.Name = "ttlabel27";
        this.ttlabel27.TabIndex = 4;

        this.ttlabel26 = new TTVisual.TTLabel();
        this.ttlabel26.Text = i18n("M13285", "Doz Aralığı");
        this.ttlabel26.Name = "ttlabel26";
        this.ttlabel26.TabIndex = 3;

        this.ttlabel16 = new TTVisual.TTLabel();
        this.ttlabel16.Text = i18n("M13942", "Etkin Madde");
        this.ttlabel16.Name = "ttlabel16";
        this.ttlabel16.TabIndex = 2;

        this.lstEklenecekEtkinMadde = new TTVisual.TTObjectListBox();
        this.lstEklenecekEtkinMadde.ListDefName = "EtkinMaddeListDefinition";
        this.lstEklenecekEtkinMadde.Name = "lstEklenecekEtkinMadde";
        this.lstEklenecekEtkinMadde.TabIndex = 1;

        this.btnEtkinMaddeEkle = new TTVisual.TTButton();
        this.btnEtkinMaddeEkle.Text = i18n("M13947", "Etkin Madde Ekle");
        this.btnEtkinMaddeEkle.Name = "btnEtkinMaddeEkle";
        this.btnEtkinMaddeEkle.TabIndex = 0;

        this.tabIlacRaporlari = new TTVisual.TTTabPage();
        this.tabIlacRaporlari.DisplayIndex = 6;
        this.tabIlacRaporlari.TabIndex = 6;
        this.tabIlacRaporlari.Text = i18n("M16355", "İlaç Raporları");
        this.tabIlacRaporlari.Name = "tabIlacRaporlari";

        this.ttrtbTumRaporlar = new TTVisual.TTRichTextBoxControl();
        this.ttrtbTumRaporlar.Required = true;
        this.ttrtbTumRaporlar.BackColor = "#FFE3C6";
        this.ttrtbTumRaporlar.Name = "ttrtbTumRaporlar";
        this.ttrtbTumRaporlar.TabIndex = 1;

        this.DiagnosisTab = new TTVisual.TTTabControl();
        this.DiagnosisTab.Name = "DiagnosisTab";
        this.DiagnosisTab.TabIndex = 14;

        this.ActiveIngredientTab = new TTVisual.TTTabPage();
        this.ActiveIngredientTab.DisplayIndex = 0;
        this.ActiveIngredientTab.TabIndex = 3;
        this.ActiveIngredientTab.Text = i18n("M13942", "Etkin Madde");
        this.ActiveIngredientTab.Name = "ActiveIngredientTab";

        this.ParticipationFreeDrugs = new TTVisual.TTGrid();
        this.ParticipationFreeDrugs.Name = "ParticipationFreeDrugs";
        this.ParticipationFreeDrugs.TabIndex = 0;

        this.EtkinMaddeParticipationFreeDrgGrid = new TTVisual.TTListBoxColumn();
        this.EtkinMaddeParticipationFreeDrgGrid.ListDefName = "EtkinMaddeListDefinition";
        this.EtkinMaddeParticipationFreeDrgGrid.DataMember = "EtkinMadde";
        this.EtkinMaddeParticipationFreeDrgGrid.DisplayIndex = 0;
        this.EtkinMaddeParticipationFreeDrgGrid.HeaderText = "Etkin Madde (Medula Kapsamında)";
        this.EtkinMaddeParticipationFreeDrgGrid.Name = "EtkinMaddeParticipationFreeDrgGrid";
        this.EtkinMaddeParticipationFreeDrgGrid.Width = 220;

        this.DrugName = new TTVisual.TTTextBoxColumn();
        this.DrugName.DataMember = "DrugName";
        this.DrugName.DisplayIndex = 1;
        this.DrugName.HeaderText = "Etkin Madde (Medula Harici)";
        this.DrugName.Name = "DrugName";
        this.DrugName.Width = 220;

        this.FrequencyParticipationFreeDrgGrid = new TTVisual.TTEnumComboBoxColumn();
        this.FrequencyParticipationFreeDrgGrid.DataTypeName = "FrequencyEnum";
        this.FrequencyParticipationFreeDrgGrid.DataMember = "Frequency";
        this.FrequencyParticipationFreeDrgGrid.DisplayIndex = 2;
        this.FrequencyParticipationFreeDrgGrid.HeaderText = i18n("M13285", "Doz Aralığı");
        this.FrequencyParticipationFreeDrgGrid.Name = "FrequencyParticipationFreeDrgGrid";
        this.FrequencyParticipationFreeDrgGrid.Width = 60;

        this.MedulaDoseParticipationFreeDrgGrid = new TTVisual.TTTextBoxColumn();
        this.MedulaDoseParticipationFreeDrgGrid.DataMember = "MedulaDoseInteger";
        this.MedulaDoseParticipationFreeDrgGrid.DisplayIndex = 3;
        this.MedulaDoseParticipationFreeDrgGrid.HeaderText = i18n("M13284", "Doz");
        this.MedulaDoseParticipationFreeDrgGrid.Name = "MedulaDoseParticipationFreeDrgGrid";
        this.MedulaDoseParticipationFreeDrgGrid.Width = 60;

        this.UsageDoseUnitTypeParticipationFreeDrgGrid = new TTVisual.TTEnumComboBoxColumn();
        this.UsageDoseUnitTypeParticipationFreeDrgGrid.DataTypeName = "UsageDoseUnitTypeEnum";
        this.UsageDoseUnitTypeParticipationFreeDrgGrid.DataMember = "UsageDoseUnitType";
        this.UsageDoseUnitTypeParticipationFreeDrgGrid.DisplayIndex = 4;
        this.UsageDoseUnitTypeParticipationFreeDrgGrid.HeaderText = i18n("M17970", "Kullanım Doz Birimi");
        this.UsageDoseUnitTypeParticipationFreeDrgGrid.Name = "UsageDoseUnitTypeParticipationFreeDrgGrid";
        this.UsageDoseUnitTypeParticipationFreeDrgGrid.Width = 60;

        this.DayParticipationFreeDrgGrid = new TTVisual.TTTextBoxColumn();
        this.DayParticipationFreeDrgGrid.DataMember = "Day";
        this.DayParticipationFreeDrgGrid.DisplayIndex = 5;
        this.DayParticipationFreeDrgGrid.HeaderText = i18n("M17974", "Kullanım Periyodu");
        this.DayParticipationFreeDrgGrid.MinimumWidth = 2;
        this.DayParticipationFreeDrgGrid.Name = "DayParticipationFreeDrgGrid";
        this.DayParticipationFreeDrgGrid.Width = 60;

        this.PeriodUnitTypeParticipationFreeDrgGrid = new TTVisual.TTEnumComboBoxColumn();
        this.PeriodUnitTypeParticipationFreeDrgGrid.DataTypeName = "PeriodUnitTypeEnum";
        this.PeriodUnitTypeParticipationFreeDrgGrid.DataMember = "PeriodUnitType";
        this.PeriodUnitTypeParticipationFreeDrgGrid.DisplayIndex = 6;
        this.PeriodUnitTypeParticipationFreeDrgGrid.HeaderText = i18n("M17980", "Kullanım Periyot Birimi");
        this.PeriodUnitTypeParticipationFreeDrgGrid.Name = "PeriodUnitTypeParticipationFreeDrgGrid";
        this.PeriodUnitTypeParticipationFreeDrgGrid.Width = 60;

        this.SUTRules = new TTVisual.TTButtonColumn();
        this.SUTRules.Text = "SUT";
        this.SUTRules.UseColumnTextForButtonValue = true;
        this.SUTRules.DisplayIndex = 7;
        this.SUTRules.HeaderText = i18n("M22399", "SUT Kuralları");
        this.SUTRules.Name = "SUTRules";
        this.SUTRules.Width = 60;

        this.IlacEtkinMadde = new TTVisual.TTButtonColumn();
        this.IlacEtkinMadde.DisplayIndex = 8;
        this.IlacEtkinMadde.HeaderText = i18n("M16306", "İlaç Bilgileri");
        this.IlacEtkinMadde.Name = "IlacEtkinMadde";
        this.IlacEtkinMadde.Width = 60;

        this.DiagnosisEntryTab = new TTVisual.TTTabPage();
        this.DiagnosisEntryTab.DisplayIndex = 1;
        this.DiagnosisEntryTab.BackColor = "#FFFFFF";
        this.DiagnosisEntryTab.TabIndex = 0;
        this.DiagnosisEntryTab.Text = i18n("M22747", "Tanı Giriş");
        this.DiagnosisEntryTab.Name = "DiagnosisEntryTab";

        this.GridDiagnosis = new TTVisual.TTGrid();
        this.GridDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridDiagnosis.Text = i18n("M17498", "Kesin Tanı");
        this.GridDiagnosis.Name = "GridDiagnosis";
        this.GridDiagnosis.TabIndex = 0;

        this.AddToHistory = new TTVisual.TTCheckBoxColumn();
        this.AddToHistory.DataMember = "AddToHistory";
        this.AddToHistory.DisplayIndex = 0;
        this.AddToHistory.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.AddToHistory.Name = "AddToHistory";
        this.AddToHistory.Width = 90;

        this.Diagnose = new TTVisual.TTListBoxColumn();
        this.Diagnose.AllowMultiSelect = true;
        this.Diagnose.ListDefName = "DiagnosisListDefinition";
        this.Diagnose.DataMember = "Diagnose";
        this.Diagnose.DisplayIndex = 1;
        this.Diagnose.HeaderText = i18n("M17498", "Kesin Tanı");
        this.Diagnose.Name = "Diagnose";
        this.Diagnose.Width = 300;

        this.Teshis = new TTVisual.TTListBoxColumn();
        this.Teshis.ListDefName = "TeshisListDefinition";
        this.Teshis.DataMember = "Teshis";
        this.Teshis.Required = true;
        this.Teshis.DisplayIndex = 2;
        this.Teshis.HeaderText = "Teshis";
        this.Teshis.Name = "Teshis";
        this.Teshis.Width = 100;

        this.chkTumTeshisler = new TTVisual.TTCheckBoxColumn();
        this.chkTumTeshisler.DataMember = "AllDiagnosisDefTeshis";
        this.chkTumTeshisler.DisplayIndex = 3;
        this.chkTumTeshisler.HeaderText = i18n("M23649", "Tüm Teşhisler");
        this.chkTumTeshisler.Name = "chkTumTeshisler";
        this.chkTumTeshisler.Width = 75;

        this.IsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.IsMainDiagnose.DataMember = "IsMainDiagnose";
        this.IsMainDiagnose.DisplayIndex = 4;
        this.IsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.IsMainDiagnose.Name = "IsMainDiagnose";
        this.IsMainDiagnose.Width = 75;

        this.FreeDiagnosis = new TTVisual.TTTextBoxColumn();
        this.FreeDiagnosis.DataMember = "FreeDiagnosis";
        this.FreeDiagnosis.DisplayIndex = 5;
        this.FreeDiagnosis.HeaderText = i18n("M21631", "Serbest Tanı");
        this.FreeDiagnosis.Name = "FreeDiagnosis";
        this.FreeDiagnosis.Width = 200;

        this.ResponsibleUser = new TTVisual.TTListBoxColumn();
        this.ResponsibleUser.ListDefName = "UserListDefinition";
        this.ResponsibleUser.DataMember = "ResponsibleUser";
        this.ResponsibleUser.DisplayIndex = 6;
        this.ResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.ResponsibleUser.Name = "ResponsibleUser";
        this.ResponsibleUser.ReadOnly = true;
        this.ResponsibleUser.Width = 200;

        this.DiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.DiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.DiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.DiagnoseDate.DataMember = "DiagnoseDate";
        this.DiagnoseDate.DisplayIndex = 7;
        this.DiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.DiagnoseDate.Name = "DiagnoseDate";
        this.DiagnoseDate.ReadOnly = true;
        this.DiagnoseDate.Width = 170;

        this.FindingsAndTests = new TTVisual.TTTabPage();
        this.FindingsAndTests.DisplayIndex = 2;
        this.FindingsAndTests.TabIndex = 2;
        this.FindingsAndTests.Text = i18n("M12125", "Bulgular ve Tetkikler");
        this.FindingsAndTests.Name = "FindingsAndTests";

        this.TestsAndSigns = new TTVisual.TTRichTextBoxControl();
        this.TestsAndSigns.DisplayText = i18n("M12125", "Bulgular ve Tetkikler");
        this.TestsAndSigns.TemplateGroupName = i18n("M15259", "Hasta Katılım Payından Muaf İlaç Raporu");
        this.TestsAndSigns.Name = "TestsAndSigns";
        this.TestsAndSigns.TabIndex = 11;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.Required = true;
        this.ProcedureDoctor.ListDefName = "DoctorListDefinition";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 2;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 8;

        this.PatientEnterprise = new TTVisual.TTTextBox();
        this.PatientEnterprise.Name = "PatientEnterprise";
        this.PatientEnterprise.TabIndex = 11;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = "Tabip";
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 36;

        this.tttextbox7 = new TTVisual.TTTextBox();
        this.tttextbox7.BackColor = "#F0F0F0";
        this.tttextbox7.ReadOnly = true;
        this.tttextbox7.Name = "tttextbox7";
        this.tttextbox7.TabIndex = 12;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.BackColor = "#F0F0F0";
        this.tttextbox2.ReadOnly = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 7;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20565", "Protokol Defter No");
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 3;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.Enabled = false;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 6;

        this.SocialInsurance = new TTVisual.TTTextBox();
        this.SocialInsurance.Name = "SocialInsurance";
        this.SocialInsurance.TabIndex = 13;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M19156", "Muafiyet Protokol No");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 3;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12335", "Çalıştığı Kurumu");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 3;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M22936", "TC Kimlik No");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 3;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "Poliklinik/Klinik";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 3;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M21831", "Sicil No");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 3;

        this.ExaminationDate = new TTVisual.TTDateTimePicker();
        this.ExaminationDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ExaminationDate.Format = DateTimePickerFormat.Custom;
        this.ExaminationDate.Name = "ExaminationDate";
        this.ExaminationDate.TabIndex = 1;
        this.ExaminationDate.Enabled = false;

        this.ProtocolNumber = new TTVisual.TTTextBox();
        this.ProtocolNumber.Name = "ProtocolNumber";
        this.ProtocolNumber.TabIndex = 5;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M22176", "Sosyal Güvencesi");
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 3;

        this.MedulaReportResultsColumns = [this.ReportChasingNoMedulaReportResult, this.ReportNumberMedulaReportResult, this.ReportRowNumberMedulaReportResult, this.ResultCodeMedulaReportResult, this.ResultExplanationMedulaReportResult, this.btnInfo, this.btnRaporuSil, this.btnGridAciklamaEkle, this.btnGridTaniEkle, this.btnGridTeshisEkle, this.btnGridEtkinMaddeEkle];
        this.gridAddedDiagnosisColumns = [this.gridTeshisEkleTanilari];
        this.ParticipationFreeDrugsColumns = [this.EtkinMaddeParticipationFreeDrgGrid, this.DrugName, this.FrequencyParticipationFreeDrgGrid, this.MedulaDoseParticipationFreeDrgGrid, this.UsageDoseUnitTypeParticipationFreeDrgGrid, this.DayParticipationFreeDrgGrid, this.PeriodUnitTypeParticipationFreeDrgGrid, this.SUTRules, this.IlacEtkinMadde];
        this.GridDiagnosisColumns = [this.AddToHistory, this.Diagnose, this.Teshis, this.chkTumTeshisler, this.IsMainDiagnose, this.FreeDiagnosis, this.ResponsibleUser, this.DiagnoseDate];
        this.tttabcontrol2.Controls = [this.tttabHastaKatilimPayindanMuafIlacRaporu];
        this.tttabHastaKatilimPayindanMuafIlacRaporu.Controls = [this.PatientApprovalFormNo, this.labelPatientApprovalFormNo, this.CommitteeReport, this.ThirdDoctor, this.listSecondDoctor, this.ttlabel11, this.ttrichtextboxAciklama, this.ttlabel6, this.tttabIslemler, this.DiagnosisTab, this.ProcedureDoctor, this.tttextbox1, this.PatientEnterprise, this.labelProcedureDoctor, this.tttextbox7, this.tttextbox2, this.labelProtocolNo, this.tttextbox3, this.SocialInsurance, this.ttlabel3, this.ttlabel4, this.ttlabel2, this.ttlabel7, this.ttlabel1, this.ExaminationDate, this.ProtocolNumber, this.ttlabel8];
        this.tttabIslemler.Controls = [this.tttabpage3, this.tttabpage4, this.tabAciklamaEkle, this.tabTaniEkle, this.tabTeshisEkle, this.tabEtkinMaddeEkle, this.tabIlacRaporlari];
        this.tttabpage3.Controls = [this.btnLoadFromSection, this.btn2Years, this.btn1Year, this.btn6Months, this.btn3Months, this.btnDeleteTemplate, this.btnSaveAsTemplate, this.btnLoadFromUser, this.btnMedulaBashekimOnay, this.btnUcuncuTabipOnay, this.btnIkinciTabipOnay, this.labelReportStartDate, this.ReportStartDate, this.labelReportEndDate, this.ReportEndDate, this.btnRaporKaydet, this.btnHastaIlacRaporuListesi];
        this.tttabpage4.Controls = [this.MedulaReportResults];
        this.tabAciklamaEkle.Controls = [this.ttlabel14, this.txtAciklamaEkleSonucMesaji, this.ttlabel13, this.ttlabel12, this.txtAciklamaEkleAciklama, this.txtAciklamaEkleTakipFormuNo, this.btnAciklamaEkle];
        this.tabTaniEkle.Controls = [this.ttlabel19, this.lstTeshisAddedToDiagnosis, this.ttlabel18, this.ttlabel17, this.txtTaniEkleSonucMesaji, this.txtTaniEkleSonucKodu, this.btnTaniEkle, this.ttlabel15, this.lstDiagnosisAddedToEpisode];
        this.tabTeshisEkle.Controls = [this.ttlabel25, this.ttlabel24, this.TeshisEndDate, this.TeshistStartDate, this.ttlabel23, this.ttlabel22, this.txtTeshisEkleSonucKodu, this.txtTeshisEkleSonucMesaji, this.btnTeshisEkle, this.ttlabel21, this.ttlabel20, this.gridAddedDiagnosis, this.lstDiagnoseAddedToTeshis];
        this.tabEtkinMaddeEkle.Controls = [this.ttlabel32, this.txtEtkinMaddeEkleSonucMesaji, this.txtEtkinMaddeEkleSonucKodu, this.ttlabel31, this.cmdEkelenecekPeriyodBirimi, this.ttlabel30, this.ttlabel29, this.txtEklenecekPeriyodu, this.txtEklenecekDoz, this.txtEklenecekDoz2, this.cmbEklenecekDozBirimi, this.cmbEklenecekDozAraligi, this.ttlabel28, this.ttlabel27, this.ttlabel26, this.ttlabel16, this.lstEklenecekEtkinMadde, this.btnEtkinMaddeEkle];
        this.tabIlacRaporlari.Controls = [this.ttrtbTumRaporlar];
        this.DiagnosisTab.Controls = [this.ActiveIngredientTab, this.DiagnosisEntryTab, this.FindingsAndTests];
        this.ActiveIngredientTab.Controls = [this.ParticipationFreeDrugs];
        this.DiagnosisEntryTab.Controls = [this.GridDiagnosis];
        this.FindingsAndTests.Controls = [this.TestsAndSigns];
        this.Controls = [this.tttabcontrol2, this.tttabHastaKatilimPayindanMuafIlacRaporu, this.PatientApprovalFormNo, this.labelPatientApprovalFormNo, this.CommitteeReport, this.ThirdDoctor, this.listSecondDoctor, this.ttlabel11, this.ttrichtextboxAciklama, this.ttlabel6, this.tttabIslemler, this.tttabpage3, this.btnLoadFromSection, this.btn2Years, this.btn1Year, this.btn6Months, this.btn3Months, this.btnDeleteTemplate, this.btnSaveAsTemplate, this.btnLoadFromUser, this.btnMedulaBashekimOnay, this.btnUcuncuTabipOnay, this.btnIkinciTabipOnay, this.labelReportStartDate, this.ReportStartDate, this.labelReportEndDate, this.ReportEndDate, this.btnRaporKaydet, this.btnHastaIlacRaporuListesi, this.tttabpage4, this.MedulaReportResults, this.ReportChasingNoMedulaReportResult, this.ReportNumberMedulaReportResult, this.ReportRowNumberMedulaReportResult, this.ResultCodeMedulaReportResult, this.ResultExplanationMedulaReportResult, this.SendReportDateMedulaReportResult, this.btnOnay, this.btnOnayIptal, this.btnRaporuSil, this.btnGridAciklamaEkle, this.btnGridTaniEkle, this.btnGridTeshisEkle, this.btnGridEtkinMaddeEkle, this.tabAciklamaEkle, this.ttlabel14, this.txtAciklamaEkleSonucMesaji, this.ttlabel13, this.ttlabel12, this.txtAciklamaEkleAciklama, this.txtAciklamaEkleTakipFormuNo, this.btnAciklamaEkle, this.tabTaniEkle, this.ttlabel19, this.lstTeshisAddedToDiagnosis, this.ttlabel18, this.ttlabel17, this.txtTaniEkleSonucMesaji, this.txtTaniEkleSonucKodu, this.btnTaniEkle, this.ttlabel15, this.lstDiagnosisAddedToEpisode, this.tabTeshisEkle, this.ttlabel25, this.ttlabel24, this.TeshisEndDate, this.TeshistStartDate, this.ttlabel23, this.ttlabel22, this.txtTeshisEkleSonucKodu, this.txtTeshisEkleSonucMesaji, this.btnTeshisEkle, this.ttlabel21, this.ttlabel20, this.gridAddedDiagnosis, this.gridTeshisEkleTanilari, this.lstDiagnoseAddedToTeshis, this.tabEtkinMaddeEkle, this.ttlabel32, this.txtEtkinMaddeEkleSonucMesaji, this.txtEtkinMaddeEkleSonucKodu, this.ttlabel31, this.cmdEkelenecekPeriyodBirimi, this.ttlabel30, this.ttlabel29, this.txtEklenecekPeriyodu, this.txtEklenecekDoz, this.txtEklenecekDoz2, this.cmbEklenecekDozBirimi, this.cmbEklenecekDozAraligi, this.ttlabel28, this.ttlabel27, this.ttlabel26, this.ttlabel16, this.lstEklenecekEtkinMadde, this.btnEtkinMaddeEkle, this.tabIlacRaporlari, this.ttrtbTumRaporlar, this.DiagnosisTab, this.ActiveIngredientTab, this.ParticipationFreeDrugs, this.EtkinMaddeParticipationFreeDrgGrid, this.DrugName, this.FrequencyParticipationFreeDrgGrid, this.MedulaDoseParticipationFreeDrgGrid, this.UsageDoseUnitTypeParticipationFreeDrgGrid, this.DayParticipationFreeDrgGrid, this.PeriodUnitTypeParticipationFreeDrgGrid, this.SUTRules, this.IlacEtkinMadde, this.DiagnosisEntryTab, this.GridDiagnosis, this.AddToHistory, this.Diagnose, this.Teshis, this.chkTumTeshisler, this.IsMainDiagnose, this.FreeDiagnosis, this.ResponsibleUser, this.DiagnoseDate, this.FindingsAndTests, this.TestsAndSigns, this.ProcedureDoctor, this.tttextbox1, this.PatientEnterprise, this.labelProcedureDoctor, this.tttextbox7, this.tttextbox2, this.labelProtocolNo, this.tttextbox3, this.SocialInsurance, this.ttlabel3, this.ttlabel4, this.ttlabel2, this.ttlabel7, this.ttlabel1, this.ExaminationDate, this.ProtocolNumber, this.ttlabel8];

    }


}
