//$AB307CC1
import { Component, ViewChild, OnInit, NgZone, Input, EventEmitter, ViewChildren, QueryList } from '@angular/core';
import { MedulaTedaviRaporlariViewModel, FizyoterapiIslemleriListModel, HastaAktifTakipleriListModel, GridHOTRaporlariListModel, GridEvdiyalizRaporlariListModel, GridTupBebekRaporlariListModel, GridDiyalizRaporlariListModel, GridEswlRaporlariListModel, HastaAktifTumTakipleriListModel, GridFtrRaporlariListModel, TasBilgisiIslemleriListModel, ESWTIslemleriListModel } from './MedulaTedaviRaporlariViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Bobrek } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { FTRVucutBolgesiService } from "ObjectClassService/FTRVucutBolgesiService";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MedulaTreatmentReport } from 'NebulaClient/Model/AtlasClientModel';
import { RaporIslemleri } from 'NebulaClient/Services/External/RaporIslemleri';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';
import { TedaviRaporiIslemKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { TedaviRaporTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PeriodUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PatientAdmissionSearchForm } from "../Kayit_Kabul_Modulu/PatientAdmissionSearch/PatientAdmissionSearchForm";
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { ModalInfo } from "Fw/Models/ModalInfo";
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DatePipe } from '@angular/common';
import { DxDataGridComponent } from "devextreme-angular";
import { FTRReportDetailGrid, ESWTReport, FTRReport, ESWTReportDetailGrid, ESWLReportDetailGrid, ESWLReport, HBTReport, TubeBabyReport, HomeHemodialysisReport, DialysisReport } from 'NebulaClient/Model/AtlasClientModel';
import { ReportDiagnosisForm } from "Modules/Tibbi_Surec/Tani_Modulu/ReportDiagnosisForm";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';



@Component({
    selector: 'MedulaTedaviRaporlari',
    templateUrl: './MedulaTedaviRaporlari.html',
    providers: [MessageService, DatePipe],
    outputs: ['OnClosing']
})
export class MedulaTedaviRaporlari extends TTVisual.TTForm implements OnInit {
    @ViewChildren(DxDataGridComponent) dataGrid: QueryList<DxDataGridComponent>;
    btnFtrIstek: TTVisual.ITTButton;
    btnRaporArama: TTVisual.ITTButton;
    btnRaporKaydet: TTVisual.ITTButton;
    btnSearchChasing: TTVisual.ITTButton;
    btnSearchReportInfo: TTVisual.ITTButton;
    btnSearchTCKNo: TTVisual.ITTButton;
    chkFtrHeyetRaporu: TTVisual.ITTCheckBox;
    chkOzelDurum: TTVisual.ITTCheckBox;
    chkRaporKaydet: TTVisual.ITTCheckBox;
    chkRefakatVarYok: TTVisual.ITTCheckBox;
    chkSearchChasing: TTVisual.ITTCheckBox;
    chkSearchReportInfo: TTVisual.ITTCheckBox;
    chkSearchTCKNo: TTVisual.ITTCheckBox;
    cmbDiyalizSeansGun: TTVisual.ITTEnumComboBox;
    cmbEvHemodiyalizSeansGun: TTVisual.ITTEnumComboBox;
    cmbOzelDurum: TTVisual.ITTEnumComboBox;
    cmbRaporTuru: TTVisual.ITTEnumComboBox;
    cmbRaporSureTuru: TTVisual.ITTEnumComboBox;
    cmbRBReportType: TTVisual.ITTEnumComboBox;
    cmbReportType: TTVisual.ITTEnumComboBox;
    cmbTupBebekTuru: TTVisual.ITTEnumComboBox;
    cmdSearchPatient: TTVisual.ITTButton;
    dtReportDate: TTVisual.ITTDateTimePicker;
    // TaniListesi: TTVisual.ITTObjectListBox;
    FizyoterapiList: TTVisual.ITTObjectListBox;
    ESWTFizyoterapiList: TTVisual.ITTObjectListBox;
    lokalizasyonList: TTVisual.ITTObjectListBox;
    FizyoterapiIslemiESWT: TTVisual.ITTListBoxColumn;
    FTRTaniGrubu: TTVisual.ITTTextBoxColumn;
    gridEswtIslemi: TTVisual.ITTGrid;
    gridFizyoTerapiIslemleri: TTVisual.ITTGrid;
    gridHastaAktifTakipleri: TTVisual.ITTGrid;
    gridHastaAktifTumTakipler: TTVisual.ITTGrid;
    gridTani: TTVisual.ITTGrid;
    gridTasBilgisi: TTVisual.ITTGrid;
    kur: TTVisual.ITTTextBoxColumn;
    lblBobrekBilgisi: TTVisual.ITTLabel;
    lblDiyalizRaporKodu: TTVisual.ITTLabel;
    lblDiyalizSeansSayisi: TTVisual.ITTLabel;
    lblEswlRaporKodu: TTVisual.ITTLabel;
    lblEswlSeansSayisi: TTVisual.ITTLabel;
    lblEvHemodiyalizRaporKodu: TTVisual.ITTLabel;
    lblEvHemodiyalizSeansSayisi: TTVisual.ITTLabel;
    lblEvHemodiyalizTedaviSuresi: TTVisual.ITTLabel;
    lblHOTSeansSayisi: TTVisual.ITTLabel;
    lblHOTTedaviSuresi: TTVisual.ITTLabel;
    lblKimlikNo: TTVisual.ITTLabel;
    lblOzelDurum: TTVisual.ITTLabel;
    lblRaporBaslangicTarihi: TTVisual.ITTLabel;
    lblRaporBitisTarihi: TTVisual.ITTLabel;
    lblRaporTakipNo: TTVisual.ITTLabel;
    lblRapotTuru: TTVisual.ITTLabel;
    lblTabip: TTVisual.ITTLabel;
    lblTabip2: TTVisual.ITTLabel;
    lblTabip3: TTVisual.ITTLabel;
    lblTasSayisi: TTVisual.ITTLabel;
    lblTupBebekRaporKodu: TTVisual.ITTLabel;
    lblTupBebekTuru: TTVisual.ITTLabel;
    Lokalizasyon2: TTVisual.ITTListBoxColumn;
    lstBobrekBilgisi: TTVisual.ITTObjectListBox;
    lstDiyalizRaporKodu: TTVisual.ITTObjectListBox;
    lstEswlRaporKodu: TTVisual.ITTObjectListBox;
    lstEvHemodiyalizRaporKodu: TTVisual.ITTObjectListBox;
    lstTabip: TTVisual.ITTObjectListBox;
    lstTabip2: TTVisual.ITTObjectListBox;
    lstTabip3: TTVisual.ITTObjectListBox;
    lstTani: TTVisual.ITTListBoxColumn;
    lstTupBebekRaporKodu: TTVisual.ITTObjectListBox;
    pnlSearchResult: TTVisual.ITTPanel;
    RaporBaslangicTarihi: TTVisual.ITTDateTimePicker;
    RaporBitisTarihi: TTVisual.ITTDateTimePicker;
    raporGonderimTarihi: TTVisual.ITTTextBoxColumn;
    raporGonderimTarihiDiyaliz: TTVisual.ITTTextBoxColumn;
    raporGonderimTarihiEswl: TTVisual.ITTTextBoxColumn;
    raporGonderimTarihiEvHemodiyaliz: TTVisual.ITTTextBoxColumn;
    raporGonderimTarihiHOT: TTVisual.ITTTextBoxColumn;
    raporGonderimTarihiTupBebek: TTVisual.ITTTextBoxColumn;
    raporNumarasi: TTVisual.ITTTextBoxColumn;
    raporNumarasiDiyaliz: TTVisual.ITTTextBoxColumn;
    raporNumarasiEswl: TTVisual.ITTTextBoxColumn;
    raporNumarasiEvHemodiyaliz: TTVisual.ITTTextBoxColumn;
    raporNumarasiHOT: TTVisual.ITTTextBoxColumn;
    raporNumarasiTupBebek: TTVisual.ITTTextBoxColumn;
    raporSil: TTVisual.ITTButtonColumn;
    raporSilDiyaliz: TTVisual.ITTButtonColumn;
    raporSilEswl: TTVisual.ITTButtonColumn;
    raporSilEvHemodiyaliz: TTVisual.ITTButtonColumn;
    raporSilHOT: TTVisual.ITTButtonColumn;
    raporSilTupBebek: TTVisual.ITTButtonColumn;
    raporSiraNo: TTVisual.ITTTextBoxColumn;
    raporSiraNoDiyaliz: TTVisual.ITTTextBoxColumn;
    raporSiraNoEswl: TTVisual.ITTTextBoxColumn;
    raporSiraNoEvHemodiyaliz: TTVisual.ITTTextBoxColumn;
    raporSiraNoHOT: TTVisual.ITTTextBoxColumn;
    raporSiraNoTupBebek: TTVisual.ITTTextBoxColumn;
    raporTakipNo: TTVisual.ITTTextBoxColumn;
    raporTakipNoDiyaliz: TTVisual.ITTTextBoxColumn;
    raporTakipNoEswl: TTVisual.ITTTextBoxColumn;
    raporTakipNoEvHemodiyaliz: TTVisual.ITTTextBoxColumn;
    raporTakipNoHOT: TTVisual.ITTTextBoxColumn;
    raporTakipNoTupBebek: TTVisual.ITTTextBoxColumn;
    raporTesisi: TTVisual.ITTTextBoxColumn;
    raporTesisiDiyaliz: TTVisual.ITTTextBoxColumn;
    raporTesisiEswl: TTVisual.ITTTextBoxColumn;
    raporTesisiEvHemodiyaliz: TTVisual.ITTTextBoxColumn;
    raporTesisiHOT: TTVisual.ITTTextBoxColumn;
    raporTesisiTupBebek: TTVisual.ITTTextBoxColumn;
    raporVucutBolgesi: TTVisual.ITTTextBoxColumn;
    SeansSayisi: TTVisual.ITTTextBoxColumn;
    SeansSayisiESWT: TTVisual.ITTTextBoxColumn;
    sonucKoduDiyaliz: TTVisual.ITTTextBoxColumn;
    sonucKoduEswl: TTVisual.ITTTextBoxColumn;
    sonucKoduEvHemodiyaliz: TTVisual.ITTTextBoxColumn;
    sonucKoduHOT: TTVisual.ITTTextBoxColumn;
    sonucKoduTupBebek: TTVisual.ITTTextBoxColumn;
    sonucMesajiDiyaliz: TTVisual.ITTTextBoxColumn;
    sonucMesajiEswl: TTVisual.ITTTextBoxColumn;
    sonucMesajiEvHemodiyaliz: TTVisual.ITTTextBoxColumn;
    sonucMesajiHOT: TTVisual.ITTTextBoxColumn;
    sonucMesajiTupBebek: TTVisual.ITTTextBoxColumn;
    TasBoyutu2: TTVisual.ITTTextBoxColumn;
    TedaviTuru: TTVisual.ITTListBoxColumn;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    tttabAramaIslemleri: TTVisual.ITTTabPage;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabDiyalizRaporKaydet: TTVisual.ITTTabPage;
    tttabDiyalizRaporlari: TTVisual.ITTTabPage;
    tttabESWLRaporKaydet: TTVisual.ITTTabPage;
    tttabEswlRaporlari: TTVisual.ITTTabPage;
    tttabESWTRaporKaydet: TTVisual.ITTTabPage;
    tttabEvHemoDiyalizRaporKaydet: TTVisual.ITTTabPage;
    tttabEvHemodiyalizRaporlari: TTVisual.ITTTabPage;
    tttabFtrRaporKaydet: TTVisual.ITTTabPage;
    tttabFtrRaporlari: TTVisual.ITTTabPage;
    tttabHOTRaporKaydet: TTVisual.ITTTabPage;
    tttabHOTRaporlari: TTVisual.ITTTabPage;
    tttabRaporlar: TTVisual.ITTTabControl;
    tttabReportSave: TTVisual.ITTTabPage;
    tabSearchBenchMarks: boolean = false;
    tttabSearchChasing: TTVisual.ITTTabPage;
    tttabSearchReportInfo: TTVisual.ITTTabPage;
    tttabSearchTCKNo: TTVisual.ITTTabPage;
    tttabTedaviRaporlariKaydet: TTVisual.ITTTabControl;
    tttabTumRaporlar: TTVisual.ITTTabPage;
    tttabTupBebekRaporKaydet: TTVisual.ITTTabPage;
    tttabTupBebekRaporlari: TTVisual.ITTTabPage;
    txtBagliTakipNo1: TTVisual.ITTTextBoxColumn;
    txtBagliTakipNo2: TTVisual.ITTTextBoxColumn;
    txtBirthDate: TTVisual.ITTTextBox;
    txtBrans1: TTVisual.ITTTextBoxColumn;
    txtBrans2: TTVisual.ITTTextBoxColumn;
    txtBransKodu1: TTVisual.ITTTextBoxColumn;
    txtBransKodu2: TTVisual.ITTTextBoxColumn;
    txtDiyalizSeansSayisi: TTVisual.ITTTextBox;
    txtEswlSeansSayisi: TTVisual.ITTTextBox;
    txtEvHemodiyalizSeansSayisi: TTVisual.ITTTextBox;
    txtEvHemodiyalizTedaviSuresi: TTVisual.ITTTextBox;
    txtXXXXXXProtocolNo1: TTVisual.ITTTextBoxColumn;
    txtXXXXXXProtocolNo2: TTVisual.ITTTextBoxColumn;
    txtHOTSeansSayisi: TTVisual.ITTTextBox;
    txtHOTTedaviSuresi: TTVisual.ITTTextBox;
    txtName: TTVisual.ITTTextBox;
    txtProvizyonTarihi1: TTVisual.ITTTextBoxColumn;
    txtProvizyonTarihi2: TTVisual.ITTTextBoxColumn;
    txtRaporTakipNo: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    txtRBReportChasing: TTVisual.ITTTextBox;
    txtRBReportRow: TTVisual.ITTTextBox;
    txtReportChasing: TTVisual.ITTTextBox;
    txtReportRow: TTVisual.ITTTextBox;
    txtResult: TTVisual.ITTRichTextBoxControl;
    txtSex: TTVisual.ITTTextBox;
    txtSurname: TTVisual.ITTTextBox;
    txtTakipNo1: TTVisual.ITTTextBoxColumn;
    txtTakipNo2: TTVisual.ITTTextBoxColumn;
    txtTasSayisi: TTVisual.ITTTextBox;
    txtTCKNo: TTVisual.ITTTextBox;
    txtTedaviTuru1: TTVisual.ITTTextBoxColumn;
    txtTedaviTuru2: TTVisual.ITTTextBoxColumn;
    txtVakaAcilisTarihi1: TTVisual.ITTTextBoxColumn;
    txtVakaAcilisTarihi2: TTVisual.ITTTextBoxColumn;
    SonucKodu: TTVisual.ITTTextBox;
    SonucAciklamasi: TTVisual.ITTTextBox;
    VucutBolgesi: TTVisual.ITTListBoxColumn;
    VucutBolgesiESWT: TTVisual.ITTListBoxColumn;
    FizyoTerapiIslemleriColumns = [];
    ESWTIslemleriColumns = [];
    TasBilgisiIslemleriColumns = [];
    HastaAktifTakipleriColumns = [];
    TaniColumns = [];
    labelTabip2: string;
    labelTabip3: string;
    selectedRaporTuru: TedaviRaporTuruEnum;
    ftrSelected: boolean = false;
    eswtSelected: boolean = false;
    eswlSelected: boolean = false;
    diyalizSelected: boolean = false;
    evHemodiyaliziSelected: boolean = false;
    hbtSelected: boolean = false;
    tupBebekSelected: boolean = false;
    kaydetSelected: boolean = false;
    kimlikNoIleSorgulaSelected: boolean = false;
    takipNoIleSorgulaSelected: boolean = false;
    raporBilgisiIleSorgulaSelected: boolean = false;
    hastaKabulleriGetir: boolean = true;
    reportDetail: Object;
    showReportDetail: boolean = false;

    tabRaporlar: boolean = false;
    raporlarSelected: boolean = false;
    eswlRaporlarSelected: boolean = false;
    diyalizRaporlarSelected: boolean = false;
    evHemodiyalizRaporlarSelected: boolean = false;
    hbtRaporlarSelected: boolean = false;
    tupBebekRaporlarSelected: boolean = false;

    isNewState: boolean = true;

    public durationChangeControl: boolean = false;
    public durationTypeChangeControl: boolean = false;
    public endDateChangeControl: boolean = false;

    public fizyoterapiDefArray: Array<any> = [];
    public fizyoterapiDefCache: any;
    public vucutBolgesiArray: Array<any> = [];
    public vucutBolgesiCache: any;
    public tedaviTuruArray: Array<any> = [];
    public tedaviTuruCache: any;

    public ESWTFizyoterapiDefArray: Array<any> = [];
    public ESWTFizyoterapiDefCache: any;
    public ESWTVucutBolgesiArray: Array<any> = [];

    public LokalizasyonDefArray: Array<any> = [];
    public LokalizasyonDefCache: any;

    public taniArray: Array<any> = [];
    public taniCache: any;

    public gridDiyalizRaporlariColumns = [];
    public gridEswlRaporlariColumns = [];
    public gridEswtIslemiColumns = [];
    public gridEvdiyalizRaporlariColumns = [];
    public gridEvHemodiyalizRaporlariColumns = [];
    public gridFizyoTerapiIslemleriColumns = [];
    public gridFtrRaporlariColumns = [];
    public selectedTakip: Array<HastaAktifTakipleriListModel> = [];
    public gridHOTRaporlariColumns = [];
    public gridTaniColumns = [];
    public gridTasBilgisiColumns = [];
    public gridTupBebekRaporlariColumns = [];
    public doctor: ResUser = new ResUser();
    public doctor2: ResUser = new ResUser();
    public doctor3: ResUser = new ResUser();
    public FTRBransKodlari: Array<string> = new Array<string>();
    public FTRHOTBransKodlari: Array<string> = new Array<string>();
    public ESWLBransKodlari: Array<string> = new Array<string>();
    public DiyalizBransKodlari: Array<string> = new Array<string>();
    public HOTBransKodlari: Array<string> = new Array<string>();
    public TupBebekBransKodlari: Array<string> = new Array<string>();
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    openedReportAsPopUp: boolean = false;

    public IsNewState: boolean = false;
    public IsCancelState: boolean = false;
    public CanPrint: boolean = false;
    public IsBackState: boolean = false;
    public IsSendMedula: boolean = false;

    private MedulaTreatmentReport_DocumentUrl: string = '/api/MedulaTreatmentReportService/MedulaTreatmentReport';
    private MedulaTreatmentReportPre_DocumentUrl: string = '/api/MedulaTreatmentReportService/MedulaTreatmentReportPre';
    private MedulaTreatmentReportEmpty_DocumentUrl: string = '/api/MedulaTreatmentReportService/MedulaTreatmentReportEmpty';
    // FizyoterapiIslemi: TTVisual.ITTListBoxColumn;
    public enableStartDateBounds: boolean = false;
    @ViewChild('Report') ReportDiagnosisInstance: ReportDiagnosisForm;

    OnClosing: EventEmitter<Boolean> = new EventEmitter<any>();

    public medulaTedaviRaporlariViewModel: MedulaTedaviRaporlariViewModel = new MedulaTedaviRaporlariViewModel();
    public get _MedulaTreatmentReport(): MedulaTreatmentReport {
        return this._TTObject as MedulaTreatmentReport;
    }
    private MedulaTedaviRaporlari_DocumentUrl: string = '/api/MedulaTreatmentReportService/MedulaTedaviRaporlari';
    constructor(protected httpService: NeHttpService, private datePipe: DatePipe,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super('MEDULATREATMENTREPORT', 'MedulaTedaviRaporlari');
        this._DocumentServiceUrl = this.MedulaTedaviRaporlari_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    // ***** Method declarations start *****
    private _modalInfo: ModalInfo;
    public setInputParam(value) {
        if (value != null && !value.IsNew)
            this.ObjectID = value.ObjectID;
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
        if (value == null)
            this.openedReportAsPopUp = false;
        else
            this.openedReportAsPopUp = true;
    }



    @Input() set MedulaTedaviRaporlariRep(value: MedulaTreatmentReport) {
        if (value != null) {
            this.ObjectID = value.ObjectID as Guid;
        }
        else {
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


    async LoadEmptyForm() {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";
            fullApiUrl = this.MedulaTreatmentReportEmpty_DocumentUrl;

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.post<MedulaTedaviRaporlariViewModel>(fullApiUrl, this.reportActiveIDsModel, MedulaTedaviRaporlariViewModel);

            this._ViewModel = response;

            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
            await this.ReportDiagnosisInstance.getReadOnlyDiagnosis();
            await this.SetButtonVisibility();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    public clear() {
        this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission.Clear();
        this.medulaTedaviRaporlariViewModel.TaniGridList.Clear();
        this.medulaTedaviRaporlariViewModel.Tabip = null;
        this.medulaTedaviRaporlariViewModel.Tabip2 = null;
        this.medulaTedaviRaporlariViewModel.Tabip3 = null;

    }
    async patientAdmissionChanged(patient: any) { }
    async patientChanged(patient: any) {

        if (patient != null) {
            this.medulaTedaviRaporlariViewModel.Patient = patient;
            this.medulaTedaviRaporlariViewModel.HastaAktifTumTakipleriList.Clear();
            this.medulaTedaviRaporlariViewModel.HastaAktifTakipleriList.Clear();
            if (this.hastaKabulleriGetir) {
                this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission.Clear();
                this.medulaTedaviRaporlariViewModel.TaniGridList.Clear();
                this.medulaTedaviRaporlariViewModel.Tabip = null;
                let result = <SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class[]>await this.httpService.post('/api/MedulaTreatmentReportService/FillPatientAdmissionHistory', this.medulaTedaviRaporlariViewModel.Patient);
                this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission = result;
                this._ViewModel.patientExisting = false;
            }

            this.btnRaporArama.Visible = true;
            this.chkFtrHeyetRaporu.Enabled = false;
            if (this.chkSearchTCKNo.Value === true) {
                this.tabSearchBenchMarks = true;
            }


            if (this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission != null && this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission.length > 0) {// && this.medulaTedaviRaporlariViewModel.RaporTuru != undefined) {
                for (let i: number = (this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission.length - 1); i >= 0; i--) {

                    if (this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Takipno !== null) {
                        let hastaAktifTumTakibi: HastaAktifTumTakipleriListModel = new HastaAktifTumTakipleriListModel();
                        hastaAktifTumTakibi.TakipNo = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Takipno;
                        hastaAktifTumTakibi.BagliTakipNo = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Baglitakipno;
                        hastaAktifTumTakibi.Brans = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Brans != null ? this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Brans : "GENEL";
                        hastaAktifTumTakibi.BransKodu = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Bransno;
                        hastaAktifTumTakibi.HProtocolNo = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Hprotocolno != null ? this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Hprotocolno.toString() : null;
                        hastaAktifTumTakibi.ProvizyonTarihi = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].ActionDate;
                        hastaAktifTumTakibi.TedaviTuru = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Tedavituru;
                        hastaAktifTumTakibi.VakaAcilisTarihi = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Vakaacilistarihi;
                        hastaAktifTumTakibi.SubEpisode = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Sepobjectid;
                        hastaAktifTumTakibi.EAObjectId = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].StarterEpisodeAction;
                        this.medulaTedaviRaporlariViewModel.HastaAktifTumTakipleriList.push(hastaAktifTumTakibi);

                        let hastaAktifTakibi: HastaAktifTakipleriListModel = new HastaAktifTakipleriListModel();
                        hastaAktifTakibi.TakipNo = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Takipno;
                        hastaAktifTakibi.BagliTakipNo = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Baglitakipno;
                        hastaAktifTakibi.Brans = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Brans != null ? this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Brans : "GENEL";
                        hastaAktifTakibi.BransKodu = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Bransno;
                        hastaAktifTakibi.HProtocolNo = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Hprotocolno != null ? this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Hprotocolno.toString() : null;
                        hastaAktifTakibi.ProvizyonTarihi = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].ActionDate;
                        hastaAktifTakibi.TedaviTuru = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Tedavituru;
                        hastaAktifTakibi.VakaAcilisTarihi = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Vakaacilistarihi;
                        hastaAktifTakibi.SubEpisode = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].Sepobjectid;
                        hastaAktifTakibi.EAObjectId = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[i].StarterEpisodeAction;
                        this.medulaTedaviRaporlariViewModel.HastaAktifTakipleriList.push(hastaAktifTakibi);
                    }
                }
                if (this.selectedRaporTuru != null)
                    this.cmbRaporTuruChanged(this.selectedRaporTuru);
                this.medulaTedaviRaporlariViewModel.SelectedTakip = this.medulaTedaviRaporlariViewModel.HastaAktifTakipleriList[0];
                this.selectedTakip.push(this.medulaTedaviRaporlariViewModel.SelectedTakip);
                this.hastaKabulleriGetir = true;

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

    private async btnFtrIstek_Click(): Promise<void> {

    }
    public async btnRaporArama_Click(): Promise<void> {
        let that = this;
        this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
        this.medulaTedaviRaporlariViewModel.GridFtrRaporlariList.Clear();
        this.medulaTedaviRaporlariViewModel.GridEswlRaporlariList.Clear();
        this.medulaTedaviRaporlariViewModel.GridDiyalizRaporlariList.Clear();
        this.medulaTedaviRaporlariViewModel.GridEvdiyalizRaporlariList.Clear();
        this.medulaTedaviRaporlariViewModel.GridHOTRaporlariList.Clear();
        this.medulaTedaviRaporlariViewModel.GridTupBebekRaporlariList.Clear();
        let _raporOkuTCKimlikNodanDVO: RaporIslemleri.raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
        //TODO : MEDULA20140501
        _raporOkuTCKimlikNodanDVO.raporTuru = "1";
        _raporOkuTCKimlikNodanDVO.tckimlikNo = this.medulaTedaviRaporlariViewModel.Patient.UniqueRefNo.toString().trim();

        let response: RaporIslemleri.raporCevapTCKimlikNodanDVO;
        let apiUrlForRaporBilgisBul: string = '/api/MedulaTreatmentReportService/raporBilgisiBulTCKimlikNodan';
        response = <RaporIslemleri.raporCevapTCKimlikNodanDVO>await this.httpService.post(apiUrlForRaporBilgisBul, _raporOkuTCKimlikNodanDVO);
        if (response !== null) {
            if (response.sonucKodu == 0) {
                let ftrKontrol: number = 0;
                let ftrTrafikKazasiKontrol: number = 0;
                let eswtKontrol: number = 0;
                let eswlKontrol: number = 0;
                let diyalizKontrol: number = 0;
                let evHemodiyalizKontrol: number = 0;
                let hOTKontrol: number = 0;
                let tupBebekKontrol: number = 0;
                let _raporCevapDVOList: Array<RaporIslemleri.raporCevapDVO> = new Array<RaporIslemleri.raporCevapDVO>();
                if (response.raporlar == null) {
                    this.messageService.showInfo(i18n("M20791", "Rapor bulunamadı."));
                    this.loadPanelOperation(false, '');
                    return;
                }
                let fTRVucutBolgesiList: Array<any> = (await FTRVucutBolgesiService.GetFTRVucutBolgesiQuery());
                for (let item of response.raporlar) {
                    if (item.tedaviRapor != null) {
                        let saglikTesisi;
                        if (item.tedaviRapor.raporDVO != null && item.tedaviRapor.raporDVO.raporBilgisi != null && item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu != null && item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.toString() != "0") {
                            saglikTesisi = (await CommonService.GetSaglikTesisleri(item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu.toString()));
                        }
                        for (let tedavi of item.tedaviRapor.islemler) {
                            if (this.medulaTedaviRaporlariViewModel.RaporTuru != null) {
                                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTR && tedavi.ftrRaporBilgisi != null) {
                                    let gridFtrRaporlari: GridFtrRaporlariListModel = new GridFtrRaporlariListModel();
                                    gridFtrRaporlari.TakipNo = item.raporTakipNo;
                                    gridFtrRaporlari.RaporNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                    gridFtrRaporlari.RaporSiraNo = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                    gridFtrRaporlari.SonucMesaji = response.sonucAciklamasi;
                                    gridFtrRaporlari.SonucKodu = response.sonucKodu;
                                    for (let fTRVucutBolgesi of fTRVucutBolgesiList) {
                                        if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedavi.ftrRaporBilgisi.ftrVucutBolgesiKodu.toString())
                                            gridFtrRaporlari.VucutBolgesi = fTRVucutBolgesi.ftrVucutBolgesiAdi;
                                    }
                                    gridFtrRaporlari.Kur = tedavi.ftrRaporBilgisi.seansSayi;
                                    gridFtrRaporlari.RaporBaslangicTarihi = item.tedaviRapor.raporDVO.baslangicTarihi;
                                    gridFtrRaporlari.VerildigiTesis = saglikTesisi;
                                    gridFtrRaporlari.Detail = i18n("M20856", "Rapor Takip No : ") + item.raporTakipNo + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M20774", "Rapor Başlangıç Tarihi : ") + gridFtrRaporlari.RaporBaslangicTarihi + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M20789", "Rapor Bitiş Tarihi : ") + item.tedaviRapor.raporDVO.bitisTarihi + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M16861", "İşlem Kodu : ") + tedavi.ftrRaporBilgisi.butKodu;
                                    if (tedavi.ftrRaporBilgisi.butKodu == "P915033")
                                        gridFtrRaporlari.Detail += i18n("M10002", "(A Grubu)") + "\n\r";
                                    else if (tedavi.ftrRaporBilgisi.butKodu == "P915032")
                                        gridFtrRaporlari.Detail += i18n("M10007", "(B Grubu)") + "\n\r";
                                    else if (tedavi.ftrRaporBilgisi.butKodu == "P915031")
                                        gridFtrRaporlari.Detail += i18n("M10008", "(C Grubu)") + "\n\r";
                                    else if (tedavi.ftrRaporBilgisi.butKodu == "P915030")
                                        gridFtrRaporlari.Detail += i18n("M10010", "(D Grubu)") + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M24188", "Vücut Bölgesi : ") + gridFtrRaporlari.VucutBolgesi + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M21476", "Seans : ") + gridFtrRaporlari.Kur + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M23039", "Tedavi Türü : ") + tedavi.ftrRaporBilgisi.tedaviTuru + "\n\r";
                                    if (item.tedaviRapor.raporDVO.duzenlemeTuru == "1")
                                        gridFtrRaporlari.Detail += i18n("M13411", "Düzenleme Türü : Heyet Raporu") + "\n\r";
                                    else
                                        gridFtrRaporlari.Detail += i18n("M13412", "Düzenleme Türü : Tek Hekim Raporu") + "\n\r";
                                    if (item.tedaviRapor.raporDVO.doktorlar != null) {
                                        for (let doktor of item.tedaviRapor.raporDVO.doktorlar) {
                                            gridFtrRaporlari.Detail += i18n("M13153", "Doktor :") + doktor.drAdi + " " + doktor.drSoyadi + i18n("M12060", " Branşı : ") + doktor.drBransKodu + "\n\r";
                                        }
                                    }
                                    gridFtrRaporlari.Detail += i18n("M23282", "Teşhis : ");
                                    if (item.tedaviRapor.raporDVO.teshisler != null) {
                                        for (let teshis of item.tedaviRapor.raporDVO.teshisler) {
                                            gridFtrRaporlari.Detail += teshis.teshisKodu + ", ";
                                        }
                                    }
                                    gridFtrRaporlari.Detail += "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M22789", "Tanı: ");
                                    if (item.tedaviRapor.raporDVO.tanilar != null) {
                                        for (let tani of item.tedaviRapor.raporDVO.tanilar) {
                                            gridFtrRaporlari.Detail += tani.taniKodu + ", ";
                                        }
                                    }
                                    gridFtrRaporlari.Detail += "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M17658", "Klinik Tanı : ") + item.tedaviRapor.raporDVO.klinikTani + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M10470", "Açıklama : ") + item.tedaviRapor.raporDVO.aciklama + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M24099", "Verildiği Tesis : ") + gridFtrRaporlari.VerildigiTesis;


                                    that.medulaTedaviRaporlariViewModel.GridFtrRaporlariList.push(gridFtrRaporlari);
                                    ftrKontrol++;
                                }
                                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI && tedavi.ftrRaporBilgisi != null) {
                                    let gridFtrRaporlari: GridFtrRaporlariListModel = new GridFtrRaporlariListModel();
                                    gridFtrRaporlari.TakipNo = item.raporTakipNo;
                                    gridFtrRaporlari.RaporNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                    gridFtrRaporlari.RaporSiraNo = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;

                                    for (let fTRVucutBolgesi of this._ViewModel.fTRVucutBolgesiList) {
                                        if (fTRVucutBolgesi.ftrVucutBolgesiKodu === tedavi.ftrRaporBilgisi.ftrVucutBolgesiKodu.toString())
                                            gridFtrRaporlari.VucutBolgesi = fTRVucutBolgesi.ftrVucutBolgesiAdi;
                                    }
                                    gridFtrRaporlari.Kur = tedavi.ftrRaporBilgisi.seansSayi;
                                    gridFtrRaporlari.RaporBaslangicTarihi = item.tedaviRapor.raporDVO.baslangicTarihi;
                                    gridFtrRaporlari.VerildigiTesis = saglikTesisi;
                                    gridFtrRaporlari.SonucMesaji = response.sonucAciklamasi;
                                    gridFtrRaporlari.SonucKodu = response.sonucKodu;
                                    gridFtrRaporlari.Detail = i18n("M20856", "Rapor Takip No : ") + item.raporTakipNo + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M20774", "Rapor Başlangıç Tarihi : ") + gridFtrRaporlari.RaporBaslangicTarihi + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M20789", "Rapor Bitiş Tarihi : ") + item.tedaviRapor.raporDVO.bitisTarihi + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M16861", "İşlem Kodu : ") + tedavi.ftrRaporBilgisi.butKodu;
                                    if (tedavi.ftrRaporBilgisi.butKodu == "P915033")
                                        gridFtrRaporlari.Detail += i18n("M10002", "(A Grubu)") + "\n\r";
                                    else if (tedavi.ftrRaporBilgisi.butKodu == "P915032")
                                        gridFtrRaporlari.Detail += i18n("M10007", "(B Grubu)") + "\n\r";
                                    else if (tedavi.ftrRaporBilgisi.butKodu == "P915031")
                                        gridFtrRaporlari.Detail += i18n("M10008", "(C Grubu)") + "\n\r";
                                    else if (tedavi.ftrRaporBilgisi.butKodu == "P915030")
                                        gridFtrRaporlari.Detail += i18n("M10010", "(D Grubu)") + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M24188", "Vücut Bölgesi : ") + gridFtrRaporlari.VucutBolgesi + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M21476", "Seans : ") + gridFtrRaporlari.Kur + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M23039", "Tedavi Türü : ") + tedavi.ftrRaporBilgisi.tedaviTuru + "\n\r";
                                    if (item.tedaviRapor.raporDVO.duzenlemeTuru == "1")
                                        gridFtrRaporlari.Detail += i18n("M13411", "Düzenleme Türü : Heyet Raporu") + "\n\r";
                                    else
                                        gridFtrRaporlari.Detail += i18n("M13412", "Düzenleme Türü : Tek Hekim Raporu") + "\n\r";
                                    if (item.tedaviRapor.raporDVO.doktorlar != null) {
                                        for (let doktor of item.tedaviRapor.raporDVO.doktorlar) {
                                            gridFtrRaporlari.Detail += i18n("M13153", "Doktor :") + doktor.drAdi + " " + doktor.drSoyadi + i18n("M12060", " Branşı : ") + doktor.drBransKodu + "\n\r";
                                        }
                                    }
                                    gridFtrRaporlari.Detail += i18n("M23282", "Teşhis : ");
                                    if (item.tedaviRapor.raporDVO.teshisler != null) {
                                        for (let teshis of item.tedaviRapor.raporDVO.teshisler) {
                                            gridFtrRaporlari.Detail += teshis.teshisKodu + ", ";
                                        }
                                    }
                                    gridFtrRaporlari.Detail += "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M22789", "Tanı: ");
                                    if (item.tedaviRapor.raporDVO.tanilar != null) {
                                        for (let tani of item.tedaviRapor.raporDVO.tanilar) {
                                            gridFtrRaporlari.Detail += tani.taniKodu + ", ";
                                        }
                                    }
                                    gridFtrRaporlari.Detail += "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M17658", "Klinik Tanı : ") + item.tedaviRapor.raporDVO.klinikTani + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M10470", "Açıklama : ") + item.tedaviRapor.raporDVO.aciklama + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M24099", "Verildiği Tesis : ") + gridFtrRaporlari.VerildigiTesis;

                                    that.medulaTedaviRaporlariViewModel.GridFtrRaporlariList.push(gridFtrRaporlari);
                                    ftrTrafikKazasiKontrol++;
                                }
                                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.ESWT && tedavi.eswtRaporBilgisi !== null) {
                                    let gridFtrRaporlari: GridFtrRaporlariListModel = new GridFtrRaporlariListModel();
                                    gridFtrRaporlari.TakipNo = item.raporTakipNo;
                                    gridFtrRaporlari.RaporNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                    gridFtrRaporlari.RaporSiraNo = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;

                                    for (let fTRVucutBolgesi of this._ViewModel.fTRVucutBolgesiList) {
                                        if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedavi.eswtRaporBilgisi.eswtVucutBolgesiKodu.toString())
                                            gridFtrRaporlari.VucutBolgesi = fTRVucutBolgesi.ftrVucutBolgesiAdi;
                                    }
                                    gridFtrRaporlari.Kur = tedavi.ftrRaporBilgisi.seansSayi;
                                    gridFtrRaporlari.RaporBaslangicTarihi = item.tedaviRapor.raporDVO.baslangicTarihi;
                                    gridFtrRaporlari.VerildigiTesis = saglikTesisi;
                                    gridFtrRaporlari.SonucMesaji = response.sonucAciklamasi;
                                    gridFtrRaporlari.SonucKodu = response.sonucKodu;
                                    gridFtrRaporlari.Detail = i18n("M20856", "Rapor Takip No : ") + item.raporTakipNo + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M20774", "Rapor Başlangıç Tarihi : ") + gridFtrRaporlari.RaporBaslangicTarihi + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M20789", "Rapor Bitiş Tarihi : ") + item.tedaviRapor.raporDVO.bitisTarihi + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M16861", "İşlem Kodu : ") + tedavi.eswtRaporBilgisi.butKodu + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M24188", "Vücut Bölgesi : ") + gridFtrRaporlari.VucutBolgesi + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M21476", "Seans : ") + gridFtrRaporlari.Kur + "\n\r";
                                    if (item.tedaviRapor.raporDVO.duzenlemeTuru == "1")
                                        gridFtrRaporlari.Detail += i18n("M13411", "Düzenleme Türü : Heyet Raporu") + "\n\r";
                                    else
                                        gridFtrRaporlari.Detail += i18n("M13412", "Düzenleme Türü : Tek Hekim Raporu") + "\n\r";
                                    if (item.tedaviRapor.raporDVO.doktorlar != null) {
                                        for (let doktor of item.tedaviRapor.raporDVO.doktorlar) {
                                            gridFtrRaporlari.Detail += i18n("M13153", "Doktor :") + doktor.drAdi + " " + doktor.drSoyadi + i18n("M12060", " Branşı : ") + doktor.drBransKodu + "\n\r";
                                        }
                                    }
                                    gridFtrRaporlari.Detail += i18n("M23282", "Teşhis : ");
                                    if (item.tedaviRapor.raporDVO.teshisler != null) {
                                        for (let teshis of item.tedaviRapor.raporDVO.teshisler) {
                                            gridFtrRaporlari.Detail += teshis.teshisKodu + ", ";
                                        }
                                    }
                                    gridFtrRaporlari.Detail += "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M22789", "Tanı: ");
                                    if (item.tedaviRapor.raporDVO.tanilar != null) {
                                        for (let tani of item.tedaviRapor.raporDVO.tanilar) {
                                            gridFtrRaporlari.Detail += tani.taniKodu + ", ";
                                        }
                                    }
                                    gridFtrRaporlari.Detail += "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M17658", "Klinik Tanı : ") + item.tedaviRapor.raporDVO.klinikTani + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M10470", "Açıklama : ") + item.tedaviRapor.raporDVO.aciklama + "\n\r";
                                    gridFtrRaporlari.Detail += i18n("M24099", "Verildiği Tesis : ") + gridFtrRaporlari.VerildigiTesis;

                                    that.medulaTedaviRaporlariViewModel.GridFtrRaporlariList.push(gridFtrRaporlari);
                                    eswtKontrol++;
                                }
                                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.ESWL && tedavi.eswlRaporBilgisi !== null) {

                                    let gridESWLRaporlari: GridEswlRaporlariListModel = new GridEswlRaporlariListModel();
                                    gridESWLRaporlari.TakipNo = item.raporTakipNo;
                                    gridESWLRaporlari.RaporNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                    gridESWLRaporlari.RaporSiraNo = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                    gridESWLRaporlari.SonucMesaji = response.sonucAciklamasi;
                                    gridESWLRaporlari.SonucKodu = response.sonucKodu;
                                    gridESWLRaporlari.RaporBaslangicTarihi = item.tedaviRapor.raporDVO.baslangicTarihi;
                                    gridESWLRaporlari.VerildigiTesis = saglikTesisi;

                                    gridESWLRaporlari.Detail = i18n("M20856", "Rapor Takip No : ") + item.raporTakipNo + "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M20774", "Rapor Başlangıç Tarihi : ") + gridESWLRaporlari.RaporBaslangicTarihi + "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M20789", "Rapor Bitiş Tarihi : ") + item.tedaviRapor.raporDVO.bitisTarihi + "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M16861", "İşlem Kodu : ") + tedavi.eswlRaporBilgisi.butKodu + "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M21476", "Seans : ") + tedavi.eswlRaporBilgisi.eswlRaporuSeansSayisi + "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M12008", "Böbrek Kodu : ") + tedavi.eswlRaporBilgisi.bobrekBilgisi + "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M22883", "Taş Sayısı : ") + tedavi.eswlRaporBilgisi.eswlRaporuTasSayisi + "\n\r";

                                    if (tedavi.eswlRaporBilgisi.bobrekBilgisi != null) {
                                        for (let tas of tedavi.eswlRaporBilgisi.eswlRaporuTasBilgileri) {
                                            gridESWLRaporlari.Detail += i18n("M12002", "Boyutu :") + tas.tasBoyutu + i18n("M12028", " Bölgesi : ") + tas.tasLokalizasyonKodu + "\n\r";
                                        }
                                    }
                                    if (item.tedaviRapor.raporDVO.duzenlemeTuru == "1")
                                        gridESWLRaporlari.Detail += i18n("M13411", "Düzenleme Türü : Heyet Raporu") + "\n\r";
                                    else
                                        gridESWLRaporlari.Detail += i18n("M13412", "Düzenleme Türü : Tek Hekim Raporu") + "\n\r";
                                    if (item.tedaviRapor.raporDVO.doktorlar != null) {
                                        for (let doktor of item.tedaviRapor.raporDVO.doktorlar) {
                                            gridESWLRaporlari.Detail += i18n("M13153", "Doktor :") + doktor.drAdi + " " + doktor.drSoyadi + i18n("M12060", " Branşı : ") + doktor.drBransKodu + "\n\r";
                                        }
                                    }
                                    gridESWLRaporlari.Detail += i18n("M23282", "Teşhis : ");
                                    if (item.tedaviRapor.raporDVO.teshisler != null) {
                                        for (let teshis of item.tedaviRapor.raporDVO.teshisler) {
                                            gridESWLRaporlari.Detail += teshis.teshisKodu + ", ";
                                        }
                                    }
                                    gridESWLRaporlari.Detail += "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M22789", "Tanı: ");
                                    if (item.tedaviRapor.raporDVO.tanilar != null) {
                                        for (let tani of item.tedaviRapor.raporDVO.tanilar) {
                                            gridESWLRaporlari.Detail += tani.taniKodu + ", ";
                                        }
                                    }
                                    gridESWLRaporlari.Detail += "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M17658", "Klinik Tanı : ") + item.tedaviRapor.raporDVO.klinikTani + "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M10470", "Açıklama : ") + item.tedaviRapor.raporDVO.aciklama + "\n\r";
                                    gridESWLRaporlari.Detail += i18n("M24099", "Verildiği Tesis : ") + gridESWLRaporlari.VerildigiTesis;

                                    that.medulaTedaviRaporlariViewModel.GridEswlRaporlariList.push(gridESWLRaporlari);
                                    eswlKontrol++;

                                }
                                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.DIYALIZ && tedavi.diyalizRaporBilgisi !== null) {
                                    let gridDiyalizRaporlari: GridDiyalizRaporlariListModel = new GridDiyalizRaporlariListModel();
                                    gridDiyalizRaporlari.TakipNo = item.raporTakipNo;
                                    gridDiyalizRaporlari.RaporNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                    gridDiyalizRaporlari.RaporSiraNo = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                    gridDiyalizRaporlari.SonucMesaji = response.sonucAciklamasi;
                                    gridDiyalizRaporlari.SonucKodu = response.sonucKodu;
                                    gridDiyalizRaporlari.RaporBaslangicTarihi = item.tedaviRapor.raporDVO.baslangicTarihi;
                                    gridDiyalizRaporlari.VerildigiTesis = saglikTesisi;

                                    gridDiyalizRaporlari.Detail = i18n("M20856", "Rapor Takip No : ") + item.raporTakipNo + "\n\r";
                                    gridDiyalizRaporlari.Detail += i18n("M20774", "Rapor Başlangıç Tarihi : ") + gridDiyalizRaporlari.RaporBaslangicTarihi + "\n\r";
                                    gridDiyalizRaporlari.Detail += i18n("M20789", "Rapor Bitiş Tarihi : ") + item.tedaviRapor.raporDVO.bitisTarihi + "\n\r";
                                    gridDiyalizRaporlari.Detail += i18n("M16861", "İşlem Kodu : ") + tedavi.diyalizRaporBilgisi.butKodu + "\n\r";
                                    gridDiyalizRaporlari.Detail += i18n("M21476", "Seans : ") + tedavi.diyalizRaporBilgisi.seansSayi + "\n\r";
                                    gridDiyalizRaporlari.Detail += i18n("M20985", "Refakat Durumu : ") + tedavi.diyalizRaporBilgisi.refakatVarMi + "\n\r";
                                    if (item.tedaviRapor.raporDVO.duzenlemeTuru == "1")
                                        gridDiyalizRaporlari.Detail += i18n("M13411", "Düzenleme Türü : Heyet Raporu") + "\n\r";
                                    else
                                        gridDiyalizRaporlari.Detail += i18n("M13412", "Düzenleme Türü : Tek Hekim Raporu") + "\n\r";
                                    if (item.tedaviRapor.raporDVO.doktorlar != null) {
                                        for (let doktor of item.tedaviRapor.raporDVO.doktorlar) {
                                            gridDiyalizRaporlari.Detail += i18n("M13153", "Doktor :") + doktor.drAdi + " " + doktor.drSoyadi + i18n("M12060", " Branşı : ") + doktor.drBransKodu + "\n\r";
                                        }
                                    }
                                    gridDiyalizRaporlari.Detail += i18n("M23282", "Teşhis : ");
                                    if (item.tedaviRapor.raporDVO.teshisler != null) {
                                        for (let teshis of item.tedaviRapor.raporDVO.teshisler) {
                                            gridDiyalizRaporlari.Detail += teshis.teshisKodu + ", ";
                                        }
                                    }
                                    gridDiyalizRaporlari.Detail += "\n\r";
                                    gridDiyalizRaporlari.Detail += i18n("M22789", "Tanı: ");
                                    if (item.tedaviRapor.raporDVO.tanilar != null) {
                                        for (let tani of item.tedaviRapor.raporDVO.tanilar) {
                                            gridDiyalizRaporlari.Detail += tani.taniKodu + ", ";
                                        }
                                    }
                                    gridDiyalizRaporlari.Detail += "\n\r";
                                    gridDiyalizRaporlari.Detail += i18n("M17658", "Klinik Tanı : ") + item.tedaviRapor.raporDVO.klinikTani + "\n\r";
                                    gridDiyalizRaporlari.Detail += i18n("M10470", "Açıklama : ") + item.tedaviRapor.raporDVO.aciklama + "\n\r";
                                    gridDiyalizRaporlari.Detail += i18n("M24099", "Verildiği Tesis : ") + gridDiyalizRaporlari.VerildigiTesis;


                                    that.medulaTedaviRaporlariViewModel.GridDiyalizRaporlariList.push(gridDiyalizRaporlari);
                                    diyalizKontrol++;
                                }
                                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.EVHEMODIYALIZI && item.tedaviRapor.tedaviRaporTuru === 8) {
                                    let gridEvdiyalizRaporlari: GridEvdiyalizRaporlariListModel = new GridEvdiyalizRaporlariListModel();
                                    gridEvdiyalizRaporlari.TakipNo = item.raporTakipNo;
                                    gridEvdiyalizRaporlari.RaporNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                    gridEvdiyalizRaporlari.RaporSiraNo = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                    gridEvdiyalizRaporlari.SonucMesaji = response.sonucAciklamasi;
                                    gridEvdiyalizRaporlari.SonucKodu = response.sonucKodu;
                                    gridEvdiyalizRaporlari.RaporBaslangicTarihi = item.tedaviRapor.raporDVO.baslangicTarihi;
                                    gridEvdiyalizRaporlari.VerildigiTesis = saglikTesisi;

                                    gridEvdiyalizRaporlari.Detail = i18n("M20856", "Rapor Takip No : ") + item.raporTakipNo + "\n\r";
                                    gridEvdiyalizRaporlari.Detail += i18n("M20774", "Rapor Başlangıç Tarihi : ") + gridEvdiyalizRaporlari.RaporBaslangicTarihi + "\n\r";
                                    gridEvdiyalizRaporlari.Detail += i18n("M20789", "Rapor Bitiş Tarihi : ") + item.tedaviRapor.raporDVO.bitisTarihi + "\n\r";
                                    gridEvdiyalizRaporlari.Detail += i18n("M16861", "İşlem Kodu : ") + tedavi.evHemodiyaliziRaporBilgisi.butKodu + "\n\r";
                                    gridEvdiyalizRaporlari.Detail += i18n("M21476", "Seans : ") + tedavi.evHemodiyaliziRaporBilgisi.seansSayi + "\n\r";
                                    if (item.tedaviRapor.raporDVO.duzenlemeTuru == "1")
                                        gridEvdiyalizRaporlari.Detail += i18n("M13411", "Düzenleme Türü : Heyet Raporu") + "\n\r";
                                    else
                                        gridEvdiyalizRaporlari.Detail += i18n("M13412", "Düzenleme Türü : Tek Hekim Raporu") + "\n\r";
                                    if (item.tedaviRapor.raporDVO.doktorlar != null) {
                                        for (let doktor of item.tedaviRapor.raporDVO.doktorlar) {
                                            gridEvdiyalizRaporlari.Detail += i18n("M13153", "Doktor :") + doktor.drAdi + " " + doktor.drSoyadi + i18n("M12060", " Branşı : ") + doktor.drBransKodu + "\n\r";
                                        }
                                    }
                                    gridEvdiyalizRaporlari.Detail += i18n("M23282", "Teşhis : ");
                                    if (item.tedaviRapor.raporDVO.teshisler != null) {
                                        for (let teshis of item.tedaviRapor.raporDVO.teshisler) {
                                            gridEvdiyalizRaporlari.Detail += teshis.teshisKodu + ", ";
                                        }
                                    }
                                    gridEvdiyalizRaporlari.Detail += "\n\r";
                                    gridEvdiyalizRaporlari.Detail += i18n("M22789", "Tanı: ");
                                    if (item.tedaviRapor.raporDVO.tanilar != null) {
                                        for (let tani of item.tedaviRapor.raporDVO.tanilar) {
                                            gridEvdiyalizRaporlari.Detail += tani.taniKodu + ", ";
                                        }
                                    }
                                    gridEvdiyalizRaporlari.Detail += "\n\r";
                                    gridEvdiyalizRaporlari.Detail += i18n("M17658", "Klinik Tanı : ") + item.tedaviRapor.raporDVO.klinikTani + "\n\r";
                                    gridEvdiyalizRaporlari.Detail += i18n("M10470", "Açıklama : ") + item.tedaviRapor.raporDVO.aciklama + "\n\r";
                                    gridEvdiyalizRaporlari.Detail += i18n("M24099", "Verildiği Tesis : ") + gridEvdiyalizRaporlari.VerildigiTesis;
                                    that.medulaTedaviRaporlariViewModel.GridEvdiyalizRaporlariList.push(gridEvdiyalizRaporlari);
                                    evHemodiyalizKontrol++;
                                }
                                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.HBT && tedavi.hotRaporBilgisi !== null) {
                                    let gridHOTRaporlari: GridHOTRaporlariListModel = new GridHOTRaporlariListModel();
                                    gridHOTRaporlari.TakipNo = item.raporTakipNo;
                                    gridHOTRaporlari.RaporNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                    gridHOTRaporlari.RaporSiraNo = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                    gridHOTRaporlari.SonucMesaji = response.sonucAciklamasi;
                                    gridHOTRaporlari.SonucKodu = response.sonucKodu;
                                    gridHOTRaporlari.RaporBaslangicTarihi = item.tedaviRapor.raporDVO.baslangicTarihi;
                                    gridHOTRaporlari.VerildigiTesis = saglikTesisi;

                                    gridHOTRaporlari.Detail = i18n("M20856", "Rapor Takip No : ") + item.raporTakipNo + "\n\r";
                                    gridHOTRaporlari.Detail += i18n("M20774", "Rapor Başlangıç Tarihi : ") + gridHOTRaporlari.RaporBaslangicTarihi + "\n\r";
                                    gridHOTRaporlari.Detail += i18n("M20789", "Rapor Bitiş Tarihi : ") + item.tedaviRapor.raporDVO.bitisTarihi + "\n\r";
                                    gridHOTRaporlari.Detail += i18n("M23028", "Tedavi Süresi: ") + tedavi.hotRaporBilgisi.tedaviSuresi + "\n\r";
                                    gridHOTRaporlari.Detail += i18n("M21476", "Seans : ") + tedavi.hotRaporBilgisi.seansSayi + "\n\r";
                                    if (item.tedaviRapor.raporDVO.duzenlemeTuru == "1")
                                        gridHOTRaporlari.Detail += i18n("M13411", "Düzenleme Türü : Heyet Raporu") + "\n\r";
                                    else
                                        gridHOTRaporlari.Detail += i18n("M13412", "Düzenleme Türü : Tek Hekim Raporu") + "\n\r";
                                    if (item.tedaviRapor.raporDVO.doktorlar != null) {
                                        for (let doktor of item.tedaviRapor.raporDVO.doktorlar) {
                                            gridHOTRaporlari.Detail += i18n("M13153", "Doktor :") + doktor.drAdi + " " + doktor.drSoyadi + i18n("M12060", " Branşı : ") + doktor.drBransKodu + "\n\r";
                                        }
                                    }
                                    gridHOTRaporlari.Detail += i18n("M23282", "Teşhis : ");
                                    if (item.tedaviRapor.raporDVO.teshisler != null) {
                                        for (let teshis of item.tedaviRapor.raporDVO.teshisler) {
                                            gridHOTRaporlari.Detail += teshis.teshisKodu + ", ";
                                        }
                                    }
                                    gridHOTRaporlari.Detail += "\n\r";
                                    gridHOTRaporlari.Detail += i18n("M22789", "Tanı: ");
                                    if (item.tedaviRapor.raporDVO.tanilar != null) {
                                        for (let tani of item.tedaviRapor.raporDVO.tanilar) {
                                            gridHOTRaporlari.Detail += tani.taniKodu + ", ";
                                        }
                                    }
                                    gridHOTRaporlari.Detail += "\n\r";
                                    gridHOTRaporlari.Detail += i18n("M17658", "Klinik Tanı : ") + item.tedaviRapor.raporDVO.klinikTani + "\n\r";
                                    gridHOTRaporlari.Detail += i18n("M10470", "Açıklama : ") + item.tedaviRapor.raporDVO.aciklama + "\n\r";
                                    gridHOTRaporlari.Detail += i18n("M24099", "Verildiği Tesis : ") + gridHOTRaporlari.VerildigiTesis;
                                    that.medulaTedaviRaporlariViewModel.GridHOTRaporlariList.push(gridHOTRaporlari);
                                    hOTKontrol++;
                                }
                                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.TUPBEBEK && tedavi.tupBebekRaporBilgisi !== null) {
                                    let gridTupBebekRaporlari: GridTupBebekRaporlariListModel = new GridTupBebekRaporlariListModel();
                                    gridTupBebekRaporlari.TakipNo = item.raporTakipNo;
                                    gridTupBebekRaporlari.RaporNo = item.tedaviRapor.raporDVO.raporBilgisi.no;
                                    gridTupBebekRaporlari.RaporSiraNo = item.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
                                    gridTupBebekRaporlari.SonucMesaji = response.sonucAciklamasi;
                                    gridTupBebekRaporlari.SonucKodu = response.sonucKodu;
                                    gridTupBebekRaporlari.RaporBaslangicTarihi = item.tedaviRapor.raporDVO.baslangicTarihi;
                                    gridTupBebekRaporlari.VerildigiTesis = saglikTesisi;
                                    gridTupBebekRaporlari.Detail = i18n("M20856", "Rapor Takip No : ") + item.raporTakipNo + "\n\r";
                                    gridTupBebekRaporlari.Detail += i18n("M20774", "Rapor Başlangıç Tarihi : ") + gridTupBebekRaporlari.RaporBaslangicTarihi + "\n\r";
                                    gridTupBebekRaporlari.Detail += i18n("M20789", "Rapor Bitiş Tarihi : ") + item.tedaviRapor.raporDVO.bitisTarihi + "\n\r";
                                    gridTupBebekRaporlari.Detail += i18n("M16862", "İşlem Kodu: ") + tedavi.tupBebekRaporBilgisi.butKodu + "\n\r";
                                    let tupbebekTuru: string = (await CommonService.GetDisplayTextOfEnumValue("TupBebekRaporTuruEnum", tedavi.tupBebekRaporBilgisi.tupBebekRaporTuru - 1));

                                    gridTupBebekRaporlari.Detail += i18n("M23673", "Tüp Bebek Türü : ") + tupbebekTuru + "\n\r";
                                    if (item.tedaviRapor.raporDVO.duzenlemeTuru == "1")
                                        gridTupBebekRaporlari.Detail += i18n("M13411", "Düzenleme Türü : Heyet Raporu") + "\n\r";
                                    else
                                        gridTupBebekRaporlari.Detail += i18n("M13412", "Düzenleme Türü : Tek Hekim Raporu") + "\n\r";
                                    if (item.tedaviRapor.raporDVO.doktorlar != null) {
                                        for (let doktor of item.tedaviRapor.raporDVO.doktorlar) {
                                            gridTupBebekRaporlari.Detail += i18n("M13153", "Doktor :") + doktor.drAdi + " " + doktor.drSoyadi + i18n("M12060", " Branşı : ") + doktor.drBransKodu + "\n\r";
                                        }
                                    }
                                    gridTupBebekRaporlari.Detail += i18n("M23282", "Teşhis : ");
                                    if (item.tedaviRapor.raporDVO.teshisler != null) {
                                        for (let teshis of item.tedaviRapor.raporDVO.teshisler) {
                                            gridTupBebekRaporlari.Detail += teshis.teshisKodu + ", ";
                                        }
                                    }
                                    gridTupBebekRaporlari.Detail += "\n\r";
                                    gridTupBebekRaporlari.Detail += i18n("M22789", "Tanı: ");
                                    if (item.tedaviRapor.raporDVO.tanilar != null) {
                                        for (let tani of item.tedaviRapor.raporDVO.tanilar) {
                                            gridTupBebekRaporlari.Detail += tani.taniKodu + ", ";
                                        }
                                    }
                                    gridTupBebekRaporlari.Detail += "\n\r";
                                    gridTupBebekRaporlari.Detail += i18n("M17658", "Klinik Tanı : ") + item.tedaviRapor.raporDVO.klinikTani + "\n\r";
                                    gridTupBebekRaporlari.Detail += i18n("M10470", "Açıklama : ") + item.tedaviRapor.raporDVO.aciklama + "\n\r";
                                    gridTupBebekRaporlari.Detail += i18n("M24099", "Verildiği Tesis : ") + gridTupBebekRaporlari.VerildigiTesis;
                                    that.medulaTedaviRaporlariViewModel.GridTupBebekRaporlariList.push(gridTupBebekRaporlari);
                                    tupBebekKontrol++;
                                }
                            }
                        }
                    }
                }
                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTR && ftrKontrol === 0) {
                    this.messageService.showInfo(i18n("M15450", "Hastanın FTR Raporu Bulunmamaktadır ! "));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI && ftrTrafikKazasiKontrol === 0) {
                    this.messageService.showInfo(i18n("M15451", "Hastanın FTR-Tarifik Kazası Raporu Bulunmamaktadır ! "));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.ESWT && eswtKontrol === 0) {
                    this.messageService.showInfo(i18n("M15448", "Hastanın ESWT Raporu Bulunmamaktadır ! "));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.ESWL && eswlKontrol === 0) {
                    this.messageService.showInfo(i18n("M15447", "Hastanın ESWL Raporu Bulunmamaktadır ! "));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.DIYALIZ && diyalizKontrol === 0) {
                    this.messageService.showInfo(i18n("M15441", "Hastanın Diyaliz Raporu Bulunmamaktadır ! "));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.EVHEMODIYALIZI && evHemodiyalizKontrol === 0) {
                    this.messageService.showInfo(i18n("M15449", "Hastanın Ev Hemodiyaliz Raporu Bulunmamaktadır ! "));
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.HBT && hOTKontrol === 0) {
                    this.messageService.showInfo("Hastanın HOT Raporu Bulunmamaktadır ! ");
                    this.loadPanelOperation(false, '');
                    return;
                }
                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.TUPBEBEK && tupBebekKontrol === 0) {
                    this.messageService.showInfo(i18n("M15495", "Hastanın Tüp Bebek Raporu Bulunmamaktadır ! "));
                    this.loadPanelOperation(false, '');
                    return;
                }
            }
            else {
                this.messageService.showInfo(i18n("M21677", "Servisten Gelen Açıklama : ") + response.sonucAciklamasi);
                this.loadPanelOperation(false, '');
                return;
            }
            this.loadPanelOperation(false, '');
        }
        this.loadPanelOperation(false, '');
    }
    private async btnGeriAl_Click() {
        this.loadPanelOperation(true, 'Lütfen Bekleyiniz');
        let that = this;
        let apiUrlForRaporBilgisBul: string = '/api/MedulaTreatmentReportService/Undo';
        let response = <boolean>await this.httpService.post(apiUrlForRaporBilgisBul, this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport);
        if (response == true) {
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CurrentStateDefID = MedulaTreatmentReport.MedulaTreatmentReportStates.New;
            this.messageService.showInfo(i18n("M16844", "İşlem geri alındı"));

            const objectIdParam = new Guid(this._MedulaTreatmentReport.ObjectID);
            await this.loadReportByID(objectIdParam);

            await this.SetFormReadOnlyControls();
            this.showSaveSuccessMessage();
            this.loadPanelOperation(false, '');
            await this.OnClosing.emit(false);
        }

    }
    public async btnCancel_Click() {
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo != null && this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo != "0") {
            this.messageService.showInfo("Raporu iptal etmek için raporu Medula'dan siliniz.");
        }
        else {
            let that = this;
            let apiUrlForRaporBilgisBul: string = '/api/MedulaTreatmentReportService/Cancel';
            let response = <boolean>await this.httpService.post(apiUrlForRaporBilgisBul, this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport);
            if (response == true) {
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CurrentStateDefID = MedulaTreatmentReport.MedulaTreatmentReportStates.Cancelled;
                this.messageService.showInfo(i18n("M20811", "Rapor iptal edildi."));

                const objectIdParam = new Guid(this._MedulaTreatmentReport.ObjectID);
                await this.loadReportByID(objectIdParam);

                await this.OnClosing.emit(true);

            }
        }
    }
    public async btnDelete_Click() {
        /*if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo == null || this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo == "0") {
            this.messageService.showInfo(i18n("M18835", "Meduladan silinecek rapor bilgisi bulunamadı."));
        }
        else {*/
        if (this.medulaTedaviRaporlariViewModel.RaporTuru != null) {
            if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTR) {
                await this.deleteFTR("");
            }
            else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI) {
                await this.deleteFTR("");
            }
            else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.ESWT) {
                //
            }
            else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.ESWL) {
                await this.deleteESWL("");
            }
            else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.DIYALIZ) {
                await this.deleteDiyaliz("");
            }
            else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.EVHEMODIYALIZI) {
                await this.deleteEvHemodiyaliz("");
            }
            else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.HBT) {
                await this.deleteHOT("");
            }
            else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.TUPBEBEK) {
                await this.deleteTupBebek("");
            }

            await this.AfterContextSavedScript(null);

            this.showSaveSuccessMessage();

            await this.SetFormReadOnlyControls();

            await this.SetButtonVisibility();

            const objectIdParam = new Guid(this._MedulaTreatmentReport.ObjectID);
            await this.loadReportByID(objectIdParam);

            await this.OnClosing.emit(false);
            //   }
        }
    }

    public checkEmptyFields(provisionControl : boolean) : boolean {
        let that = this;
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate == null) {
            this.messageService.showInfo(i18n("M11941", "Bitiş Tarihi Boş Geçilemez ! "));
            return false;
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate == null) {
            this.messageService.showInfo(i18n("M11639", "Başlangıç Tarihi Boş Geçilemez ! "));
            return false;
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate <= this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate) {
            this.messageService.showInfo(i18n("M11944", "Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! "));
            return false;
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ProcedureDoctor == null) {
            this.messageService.showInfo(i18n("M13157", "Doktor Alanı Boş Geçilemez ! "));
            return false;
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == null) {
            this.messageService.showInfo(i18n("M20873", "Rapor Türü Seçiniz ! "));
            return false;
        }
        if(provisionControl){
            if (this.medulaTedaviRaporlariViewModel.SelectedTakip == null || this.medulaTedaviRaporlariViewModel.SelectedTakip.TakipNo == "") {
            this.messageService.showInfo("Hastanın Takip Numarası Yoktur. Medula Tedavi Raporu Yazılamaz");
            return false;
        }
        }
        


        if ((this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.HBT && this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CommitteeReport) || this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CommitteeReport) {
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.SecondDoctor == null) {
                this.messageService.showInfo(i18n("M10182", "2. Doktor Alanı Boş Geçilemez ! "));
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ThirdDoctor == null) {
                this.messageService.showInfo(i18n("M10268", "3. Doktor Alanı Boş Geçilemez ! "));
                return false;
            }
        }

        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTR || this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI) {

            if (this.medulaTedaviRaporlariViewModel.FizyoterapiIslemleriList == null || this.medulaTedaviRaporlariViewModel.FizyoterapiIslemleriList.length == 0) {
                this.messageService.showInfo(i18n("M14419", "Fizyoterapi İşlemi Seçmeniz Gerekmektedir ! "));
                return false;
            }
            for (let item of this.medulaTedaviRaporlariViewModel.FizyoterapiIslemleriList) {
                if (item.FizyoterapiIslemi == null) {
                    this.messageService.showInfo(i18n("M14425", "Fizyoterapi Rapor Kodu Seçmeniz Gerekmektedir ! "));
                    return false;
                }
                if (item.SeansSayisi == null) {
                    this.messageService.showInfo(i18n("M21490", "Seans Sayısı Girmeniz Gerekmektedir ! "));
                    return false;
                }
                if (item.VucutBolgesi == null) {
                    this.messageService.showInfo(i18n("M24190", "Vücut Bölgesi Seçmeniz Gerekmektedir ! "));
                    return false;
                }
                if (item.TedaviTuru == null) {
                    this.messageService.showInfo(i18n("M23042", "Tedavi Türü Seçmeniz Gerekmektedir ! "));
                    return false;
                }
            }
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWT) {
            if (this.medulaTedaviRaporlariViewModel.ESWTIslemleriList == null || this.medulaTedaviRaporlariViewModel.ESWTIslemleriList.length == 0) {
                this.messageService.showInfo(i18n("M14419", "Fizyoterapi İşlemi Seçmeniz Gerekmektedir ! "));
                return false;
            }
            for (let item of this.medulaTedaviRaporlariViewModel.ESWTIslemleriList) {
                if (item.FizyoterapiIslemiESWT == null) {
                    this.messageService.showInfo(i18n("M14425", "Fizyoterapi Rapor Kodu Seçmeniz Gerekmektedir ! "));
                    return false;
                }
                if (item.SeansSayisiESWT == null) {
                    this.messageService.showInfo(i18n("M21490", "Seans Sayısı Girmeniz Gerekmektedir ! "));
                    return false;
                }
                if (item.VucutBolgesiESWT == null) {
                    this.messageService.showInfo(i18n("M24190", "Vücut Bölgesi Seçmeniz Gerekmektedir ! "));
                    return false;
                }
            }
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWL) {
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport.TedaviRaporiIslemKodlari == null) {
                this.messageService.showInfo(i18n("M13893", "ESWL İşlemi Seçmeniz Gerekmektedir ! "));
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport.NumberOfStone == null) {
                this.messageService.showInfo(i18n("M22884", "Taş Sayısını Girmeniz Gerekmektedir !  "));
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport.NumberOfSessions == null) {
                this.messageService.showInfo(i18n("M21477", "Seans Bilgisini Girmeniz Gerekmektedir ! "));
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport.Bobrek == null) {
                this.messageService.showInfo(i18n("M12006", "Böbrek Bilgisini Girmeniz Gerekmektedir ! "));
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel.TasBilgisiIslemleriList == null || this.medulaTedaviRaporlariViewModel.TasBilgisiIslemleriList.length == 0) {
                this.messageService.showInfo(i18n("M22861", "Taş Bilgilerini Girmeniz Gerekmektedir ! "));
                return false;
            }
            for (let item of this.medulaTedaviRaporlariViewModel.TasBilgisiIslemleriList) {
                if (item.Lokalizasyon == null) {
                    this.messageService.showInfo(i18n("M18349", "Lokalizasyon Seçmeniz Gerekmektedir !  "));
                    return false;
                }
                if (item.TasBoyutu == null) {
                    this.messageService.showInfo(i18n("M22888", "Taşın Boyutunu Girmeniz Gerekmektedir !  "));
                    return false;
                }
            }
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.DIYALIZ) {
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.DialysisReport.TedaviRaporiIslemKodlari == null) {
                this.messageService.showInfo(i18n("M13010", "Diyaliz işlemi seçmeniz gerekmektedir ! "));
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.DialysisReport.NumberOfSessions == null) {
                this.messageService.showInfo("Seans bilgisini girmeniz gerekmektedir !  ");
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.DialysisReport.DialysisSessionsDay == null) {
                this.messageService.showInfo(i18n("M21482", "seans gün seçmeniz gerekmektedir ! "));
                return false;
            }
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.EVHEMODIYALIZI) {
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HomeHemodialysisReport.TedaviRaporiIslemKodlari == null) {
                this.messageService.showInfo(i18n("M13975", "Ev Hemodiyaliz İşlemi Seçmeniz Gerekmektedir ! "));
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HomeHemodialysisReport.NumberOfSessions == null) {
                this.messageService.showInfo(i18n("M21477", "Seans Bilgisini Girmeniz Gerekmektedir ! "));
                return false;
            }
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.HBT) {
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HBTReport.NumberOfSessions == null) {
                this.messageService.showInfo(i18n("M21477", "Seans Bilgisini Girmeniz Gerekmektedir ! "));
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HBTReport.TreatmenDuration == null) {
                this.messageService.showInfo(i18n("M23029", "Tedavi Süresini Girmeniz Gerekmektedir ! "));
                return false;
            }
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.TUPBEBEK) {
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TubeBabyReport.TedaviRaporiIslemKodlari == null) {
                this.messageService.showInfo(i18n("M23662", "Tüp Bebek İşlemi Seçmeniz Gerekmektedir ! "));
                return false;
            }
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TubeBabyReport.TubeBabyReportType == null) {
                this.messageService.showInfo(i18n("M23669", "Tüp Bebek Rapor Türünü Seçmeniz Gerekmektedir ! "));
                return false;
            }
        }
        return true;
    }


    private async btnRaporKaydet_Click() {
        this.dataGrid.forEach(item => {
            item.instance.saveEditData();
        });
        if(!this.checkEmptyFields(true))
            return;
        let history = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission;
        this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission.Clear();
        try {
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo == null)
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo = "0";
            this.medulaTedaviRaporlariViewModel.willSendToMedula = true;
            this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
            let result = <BaseViewModel>await this.httpService.post('/api/MedulaTreatmentReportService/MedulaTedaviRaporlari', this.medulaTedaviRaporlariViewModel);
            this.loadPanelOperation(false, '');

            this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission = history;
            if (result != null) {
                if (result.UpdatedObjects != null && result.UpdatedObjects.length > 0) {
                    this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo = (<MedulaTreatmentReport>result.UpdatedObjects[0]).RaporTakipNo;
                    this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo = (<MedulaTreatmentReport>result.UpdatedObjects[0]).ReportNo;
                }

                this.medulaTedaviRaporlariViewModel.GridFtrRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridEswlRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridDiyalizRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridEvdiyalizRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridHOTRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridTupBebekRaporlariList.Clear();

                await this.setReportInfoToGrid();
            }
            else
                this.messageService.showInfo(i18n("M20840", "Rapor Servisinden Gelen Sonuç Mesajı : ") + this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.SonucAciklamasi + i18n("M20861", "  Rapor Takip Numarası Alınamamıştır.  !!!"));

            await this.AfterContextSavedScript(null);
            const objectIdParam = new Guid(this._MedulaTreatmentReport.ObjectID);
            await this.loadReportByID(objectIdParam);

            await this.SetFormReadOnlyControls();

            this.showSaveSuccessMessage();

            await this.OnClosing.emit(false);
        }
        catch (Exception) {
            this.loadPanelOperation(false, '');
            this.messageService.showError(Exception);
            //throw Exception;
        }
    }

    async saveWithoutSendingToMedula() {
        this.dataGrid.forEach(item => {
            item.instance.saveEditData();
        });
        if(!this.checkEmptyFields(false))
            return;
        this.medulaTedaviRaporlariViewModel.willSendToMedula = false;
        let history = this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission;
        if(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTR){

        }
        this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission.Clear();
        try {

            this.loadPanelOperation(true, "İşlem Kaydediliyor");
            let result = <BaseViewModel>await this.httpService.post('/api/MedulaTreatmentReportService/MedulaTedaviRaporlari', this.medulaTedaviRaporlariViewModel);
            this.loadPanelOperation(false, '');

            this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission = history;
            if (result != null) {

                this.medulaTedaviRaporlariViewModel.GridFtrRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridEswlRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridDiyalizRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridEvdiyalizRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridHOTRaporlariList.Clear();
                this.medulaTedaviRaporlariViewModel.GridTupBebekRaporlariList.Clear();

                await this.setReportInfoToGrid();
            }

            await this.AfterContextSavedScript(null);
            const objectIdParam = new Guid(this._MedulaTreatmentReport.ObjectID);
            await this.loadReportByID(objectIdParam);

            await this.SetFormReadOnlyControls();

            this.showSaveSuccessMessage();

            await this.OnClosing.emit(false);
        }
        catch (Exception) {
            this.loadPanelOperation(false, '');
            this.messageService.showError(Exception);
            //throw Exception;
        }
        //this.save();
    }

    async save() {
        super.save();
    }

    async setReportInfoToGrid() {
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTR || this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI ||
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWT) {

            let gridFtrRaporlari: GridFtrRaporlariListModel = new GridFtrRaporlariListModel();
            gridFtrRaporlari.TakipNo = Convert.ToInt32(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo);
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo)
                gridFtrRaporlari.RaporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo.toString();
            gridFtrRaporlari.RaporSiraNo = 0;
            gridFtrRaporlari.RaporBaslangicTarihi = this.datePipe.transform(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate, 'dd.MM.yyyy');

            if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTR || this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI) {
                for (let item of this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.FTRReport.FTRReportDetailGrid) {
                    gridFtrRaporlari.VucutBolgesi = item.FTRVucutBolgesi.ftrVucutBolgesiAdi;
                    gridFtrRaporlari.Kur = item.NumberOfSessions;
                }
            }
            else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.ESWT) {
                for (let item of this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWTReport.ESWTReportDetailGrid) {
                    gridFtrRaporlari.VucutBolgesi = item.FTRVucutBolgesi.ftrVucutBolgesiAdi;
                    gridFtrRaporlari.Kur += item.NumberOfSessions;
                }
            }

            this.medulaTedaviRaporlariViewModel.GridFtrRaporlariList.push(gridFtrRaporlari);

        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWL) {

            let gridESWLRaporlari: GridEswlRaporlariListModel = new GridEswlRaporlariListModel();
            gridESWLRaporlari.TakipNo = Convert.ToInt32(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo);
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo)
                gridESWLRaporlari.RaporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo.toString();
            gridESWLRaporlari.RaporSiraNo = 0;
            gridESWLRaporlari.RaporBaslangicTarihi = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate.ToShortDateString();
            this.medulaTedaviRaporlariViewModel.GridEswlRaporlariList.push(gridESWLRaporlari);
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.DIYALIZ || this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.EVHEMODIYALIZI) {
            let gridDiyalizRaporlari: GridDiyalizRaporlariListModel = new GridDiyalizRaporlariListModel();
            gridDiyalizRaporlari.TakipNo = Convert.ToInt32(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo);
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo)
                gridDiyalizRaporlari.RaporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo.toString();
            gridDiyalizRaporlari.RaporSiraNo = 0;
            gridDiyalizRaporlari.RaporBaslangicTarihi = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate.ToShortDateString();
            this.medulaTedaviRaporlariViewModel.GridDiyalizRaporlariList.push(gridDiyalizRaporlari);
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.HBT) {
            let gridHOTRaporlari: GridHOTRaporlariListModel = new GridHOTRaporlariListModel();
            gridHOTRaporlari.TakipNo = Convert.ToInt32(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo);
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo)
                gridHOTRaporlari.RaporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo.toString();
            gridHOTRaporlari.RaporSiraNo = 0;
            gridHOTRaporlari.RaporBaslangicTarihi = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate.ToShortDateString();
            this.medulaTedaviRaporlariViewModel.GridHOTRaporlariList.push(gridHOTRaporlari);
        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.TUPBEBEK) {
            let gridTupBebekRaporlari: GridTupBebekRaporlariListModel = new GridTupBebekRaporlariListModel();
            gridTupBebekRaporlari.TakipNo = Convert.ToInt32(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo);
            if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo)
                gridTupBebekRaporlari.RaporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo.toString();
            gridTupBebekRaporlari.RaporSiraNo = 0;
            gridTupBebekRaporlari.RaporBaslangicTarihi = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate.ToShortDateString();
            this.medulaTedaviRaporlariViewModel.GridTupBebekRaporlariList.push(gridTupBebekRaporlari);
        }
    }
    public ontxtRaporTakipNoChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.RaporTakipNo != event) {
                this._MedulaTreatmentReport.RaporTakipNo = event;
            }
        }
    }
    public onchkFtrHeyetRaporuChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.CommitteeReport != event) {
                this._MedulaTreatmentReport.CommitteeReport = event;
            }
        }
        this.chkFtrHeyetRaporuChanged(event);
    }
    private async chkFtrHeyetRaporuChanged(event): Promise<void> {

        if (event == true) {
            this.labelTabip2 = i18n("M10220", "2.Doktor");
            this.labelTabip3 = i18n("M10289", "3.Doktor");
            this.lstTabip3.Enabled = true;
            this.lstTabip2.Enabled = true;
        }
        else {
            this.labelTabip2 = "";
            this.labelTabip3 = "";
            this.lstTabip3.Enabled = false;
            this.lstTabip2.Enabled = false;
        }
    }
    public chkRaporKaydetCheckedChanged(event): void {
        if (event == false) {
            this.ftrSelected = false;
            this.eswtSelected = false;
            this.eswlSelected = false;
            this.diyalizSelected = false;
            this.evHemodiyaliziSelected = false;
            this.hbtSelected = false;
            this.tupBebekSelected = false;
            this.tabSearchBenchMarks = false;
            //this.raporlarSelected = false;

            //this.evHemodiyalizRaporlarSelected = false;
            //this.diyalizRaporlarSelected = false;

            //this.hbtRaporlarSelected = false;
            //this.tupBebekRaporlarSelected = false;
        }
        else {
            this.tabSearchBenchMarks = true;
            this.kaydetSelected = false;
            this.cmbRaporTuru.Enabled = true;
            this.btnRaporKaydet.Visible = true;
            if (this.medulaTedaviRaporlariViewModel.RaporTuru != null) {
                if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTR || this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI) {
                    this.tabSearchBenchMarks = true;
                    this.ftrSelected = true;
                    this.eswtSelected = false;
                    this.eswlSelected = false;
                    this.diyalizSelected = false;
                    this.evHemodiyaliziSelected = false;
                    this.hbtSelected = false;
                    this.tupBebekSelected = false;
                    this.raporlarSelected = true;
                }
                else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.ESWT) {
                    this.tabSearchBenchMarks = true;
                    this.ftrSelected = false;
                    this.eswtSelected = true;
                    this.eswlSelected = false;
                    this.diyalizSelected = false;
                    this.evHemodiyaliziSelected = false;
                    this.hbtSelected = false;
                    this.tupBebekSelected = false;
                    this.raporlarSelected = true;
                }
                else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.ESWL) {
                    this.tabSearchBenchMarks = true;
                    this.ftrSelected = false;
                    this.eswtSelected = false;
                    this.eswlSelected = true;
                    this.diyalizSelected = false;
                    this.evHemodiyaliziSelected = false;
                    this.hbtSelected = false;
                    this.tupBebekSelected = false;
                    this.eswlRaporlarSelected = true;
                }
                else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.DIYALIZ) {
                    this.tabSearchBenchMarks = true;
                    this.ftrSelected = false;
                    this.eswtSelected = false;
                    this.eswlSelected = false;
                    this.diyalizSelected = true;
                    this.evHemodiyaliziSelected = false;
                    this.hbtSelected = false;
                    this.tupBebekSelected = false;
                    this.diyalizRaporlarSelected = true;
                }
                else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.EVHEMODIYALIZI) {
                    this.tabSearchBenchMarks = true;
                    this.ftrSelected = false;
                    this.eswtSelected = false;
                    this.eswlSelected = false;
                    this.diyalizSelected = false;
                    this.evHemodiyaliziSelected = true;
                    this.hbtSelected = false;
                    this.tupBebekSelected = false;
                    this.evHemodiyalizRaporlarSelected = true;
                }
                else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.HBT) {
                    this.tabSearchBenchMarks = true;
                    this.ftrSelected = false;
                    this.eswtSelected = false;
                    this.eswlSelected = false;
                    this.diyalizSelected = false;
                    this.evHemodiyaliziSelected = false;
                    this.hbtSelected = true;
                    this.tupBebekSelected = false;
                    this.hbtRaporlarSelected = true;
                }
                else if (this.medulaTedaviRaporlariViewModel.RaporTuru == TedaviRaporTuruEnum.TUPBEBEK) {
                    this.tabSearchBenchMarks = true;
                    this.ftrSelected = false;
                    this.eswtSelected = false;
                    this.eswlSelected = false;
                    this.diyalizSelected = false;
                    this.evHemodiyaliziSelected = false;
                    this.hbtSelected = false;
                    this.tupBebekSelected = true;
                    this.tupBebekRaporlarSelected = true;
                }
                else {
                    this.tupBebekRaporlarSelected = false;
                    this.hbtRaporlarSelected = false;
                    this.evHemodiyalizRaporlarSelected = false;
                    this.diyalizRaporlarSelected = false;
                    this.eswlRaporlarSelected = false;
                }
            }
            this.tupBebekRaporlarSelected = false;
            this.hbtRaporlarSelected = false;
            this.evHemodiyalizRaporlarSelected = false;
            this.diyalizRaporlarSelected = false;
            this.eswlRaporlarSelected = false;
            this.tabRaporlar = true;

            this.kimlikNoIleSorgulaSelected = false;
            this.takipNoIleSorgulaSelected = false;
            this.raporBilgisiIleSorgulaSelected = false;
            this.cmbReportType.Required = true;
            this.chkSearchTCKNo.Value = false;
            this.chkSearchChasing.Value = false;
            this.chkSearchReportInfo.Value = false;
        }
    }
    comingViewModel(data: any) {
        this.medulaTedaviRaporlariViewModel.reportDiagnosisFormViewModel = data;
    }
    /*comingViewModel(data: ReportDiagnosisFormViewModel ) {
        let that = this;
        that.medulaTedaviRaporlariViewModel.reportDiagnosisFormViewModel = data;
    }*/

    public actionIdForDemografic(): Guid {
        if (this._MedulaTreatmentReport.MasterAction != null) {
            if (typeof this._MedulaTreatmentReport.MasterAction === "string") {
                return this._MedulaTreatmentReport.MasterAction;
            }
            else {
                return this._MedulaTreatmentReport.MasterAction.ObjectID;
            }
        }

        return this._MedulaTreatmentReport.ObjectID;
    }

    public changeDayDifferenceByEndDateSelection() {
        if (this.medulaTedaviRaporlariViewModel.RaporBaslangicTarihi == null) {
            this.messageService.showInfo(i18n("M20775", "Rapor Başlangıç Tarihi Girmelisiniz!"));
            return;
        }
        let thisdate: Date = new Date();
        let endDate: Date = new Date();
        endDate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate;
        thisdate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate;



        let dayDifference: number = Math.floor((endDate.getTime() - thisdate.getTime()) / 86400000) + 1;

        this._MedulaTreatmentReport.DurationType = PeriodUnitTypeEnum.DayPeriod;
        this._MedulaTreatmentReport.Duration = dayDifference;
        this.endDateChangeControl = true;
    }

    public onRaporBitisTarihiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.EndDate != event) {
                this._MedulaTreatmentReport.EndDate = event;
            }
        }
        if (!(this.durationChangeControl || this.durationTypeChangeControl))
            this.changeDayDifferenceByEndDateSelection();

        this.durationChangeControl = false;
        this.durationTypeChangeControl = false;

    }
    public async onRaporBaslangicTarihiChanged(event) {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.StartDate != event) {
                this._MedulaTreatmentReport.StartDate = event;
                if (this._MedulaTreatmentReport.Duration != null && this._MedulaTreatmentReport.DurationType != null)
                    this.cmbRaporSureTuruChanged(this._MedulaTreatmentReport.DurationType);
            }

            if (this._MedulaTreatmentReport.ProcedureDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedulaTreatmentReport.ProcedureDoctor.ObjectID, this._MedulaTreatmentReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedulaTreatmentReport.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedulaTreatmentReport.ProcedureDoctor = null;
                    }, 500);
                }
            }

            if (this._MedulaTreatmentReport.SecondDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedulaTreatmentReport.SecondDoctor.ObjectID, this._MedulaTreatmentReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedulaTreatmentReport.SecondDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedulaTreatmentReport.SecondDoctor = null;
                    }, 500);
                }
            }

            if (this._MedulaTreatmentReport.ThirdDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedulaTreatmentReport.ThirdDoctor.ObjectID, this._MedulaTreatmentReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedulaTreatmentReport.ThirdDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedulaTreatmentReport.ThirdDoctor = null;
                    }, 500);
                }
            }
        }
    }
    public oncmbRaporTuruChanged(event): void {
        if (event != null) {
            if (event != TedaviRaporTuruEnum.FTR && event != TedaviRaporTuruEnum.ESWT && event != TedaviRaporTuruEnum.FTRTRAFIKKAZASI && event != TedaviRaporTuruEnum.HBT && this.medulaTedaviRaporlariViewModel.TedaviTipi == "2") {
                ServiceLocator.MessageService.showError("Tedavi Tipi 'FİZİKSEL TEDAVİ VE REHABİLİTASYON' olan hastalara sadece FTR, FTR Trafik Kazası,ESWT ya da HBT raporu yazılabilir.");
            }

            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.TedaviRaporTuru != event) {
                this._MedulaTreatmentReport.TedaviRaporTuru = event;
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TedaviRaporTuru = event;
            }
        }
        this.cmbRaporTuruChanged(event);
    }
    public oncmbOzelDurumChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.FTRReport != null && this._MedulaTreatmentReport.FTRReport.SpacialCase != event) {
                this._MedulaTreatmentReport.FTRReport.SpacialCase = event;
            }
        }
        else
            this._MedulaTreatmentReport.FTRReport.SpacialCase = null;
    }
    public async onlstTabipChanged(event) {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.ProcedureDoctor != event) {
                this._MedulaTreatmentReport.ProcedureDoctor = event;
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ProcedureDoctor = event;

                let filterExpression: string = " AND  ObjectID <>'";
                filterExpression += event.ObjectID + "'";

                this.lstTabip2.ListFilterExpression += filterExpression;
                this.lstTabip3.ListFilterExpression += filterExpression;

            }

            if (this._MedulaTreatmentReport.StartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedulaTreatmentReport.ProcedureDoctor.ObjectID, this._MedulaTreatmentReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedulaTreatmentReport.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedulaTreatmentReport.ProcedureDoctor = null;
                    }, 500);
                }
            }
        }
    }
    public async onlstTabip2Changed(event) {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.SecondDoctor != event) {
                this._MedulaTreatmentReport.SecondDoctor = event;
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.SecondDoctor = event;

                let filterExpression: string = " AND  ObjectID <>'";
                filterExpression += event.ObjectID + "'";

                this.lstTabip3.ListFilterExpression += filterExpression;
            }

            if (this._MedulaTreatmentReport.StartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedulaTreatmentReport.SecondDoctor.ObjectID, this._MedulaTreatmentReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedulaTreatmentReport.SecondDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedulaTreatmentReport.SecondDoctor = null;
                    }, 500);
                }
            }
        }
    }
    public async onlstTabip3Changed(event) {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.ThirdDoctor != event) {
                this._MedulaTreatmentReport.ThirdDoctor = event;
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ThirdDoctor = event;
            }

            if (this._MedulaTreatmentReport.StartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedulaTreatmentReport.ThirdDoctor.ObjectID, this._MedulaTreatmentReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedulaTreatmentReport.ThirdDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedulaTreatmentReport.ThirdDoctor = null;
                    }, 500);
                }
            }
        }
    }

    onRowClickFtr(event: any): void {
        if (event.parentType == 'dataRow') {
            event.editorOptions.onFocusOut = function (args) {

                if (event.component.hasEditData()) {
                    event.component.saveEditData();
                }
            };
        }
    }

    onRowClickTakipList(event: any): void {
        this.medulaTedaviRaporlariViewModel.SelectedTakip = event.data;
    }
    public cmbRaporSureTuruChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.DurationType != event) {
                this._MedulaTreatmentReport.DurationType = event;
            }
            if (this.medulaTedaviRaporlariViewModel.RaporBaslangicTarihi == null) {
                this.messageService.showInfo(i18n("M20775", "Rapor Başlangıç Tarihi Girmelisiniz!"));
                return;
            }
            let thisdate: Date = new Date();
            thisdate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate;
            if (event == PeriodUnitTypeEnum.DayPeriod) {
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = thisdate.AddDays(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.Duration);
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate.AddDays(-1);
            }
            if (event == PeriodUnitTypeEnum.MonthPeriod) {
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = thisdate.AddMonths(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.Duration);
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate.AddDays(-1);
            }
            if (event == PeriodUnitTypeEnum.YearPeriod) {
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = thisdate.AddYears(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.Duration);
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate.AddDays(-1);
            }
            if (event == PeriodUnitTypeEnum.WeekPeriod) {
                let gun: number = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.Duration * 7;
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = thisdate.AddDays(gun);
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate.AddDays(-1);
            }
            if (!this.endDateChangeControl) {
                this.durationTypeChangeControl = true;
            }
            this.endDateChangeControl = false;
        }
    }

    public reportDurationChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.Duration != event.value) {
                this._MedulaTreatmentReport.Duration = event.value;
            }
            if (this.medulaTedaviRaporlariViewModel.RaporBaslangicTarihi == null) {
                this.messageService.showInfo(i18n("M20775", "Rapor Başlangıç Tarihi Girmelisiniz!"));
                return;
            }
            let thisdate: Date = new Date();
            thisdate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate;
            if (this._MedulaTreatmentReport.DurationType == PeriodUnitTypeEnum.DayPeriod) {
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = thisdate.AddDays(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.Duration);
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate.AddDays(-1);
            }
            if (this._MedulaTreatmentReport.DurationType == PeriodUnitTypeEnum.MonthPeriod) {
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = thisdate.AddMonths(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.Duration);
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate.AddDays(-1);
            }
            if (this._MedulaTreatmentReport.DurationType == PeriodUnitTypeEnum.YearPeriod) {
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = thisdate.AddYears(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.Duration);
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate.AddDays(-1);
            }
            if (this._MedulaTreatmentReport.DurationType == PeriodUnitTypeEnum.WeekPeriod) {
                let gun: number = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.Duration * 7;
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = thisdate.AddDays(gun);
                this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.EndDate.AddDays(-1);
            }
            if (!this.endDateChangeControl) {
                this.durationChangeControl = true;
            }
            this.endDateChangeControl = false;
        }
    }

    public SetHastaAktifTakipleriList(that: this, item: HastaAktifTumTakipleriListModel) {
        let hastaAktifTakibi: HastaAktifTakipleriListModel = new HastaAktifTakipleriListModel();
        hastaAktifTakibi.TakipNo = item.TakipNo;
        hastaAktifTakibi.BagliTakipNo = item.BagliTakipNo;
        hastaAktifTakibi.Brans = item.Brans;
        hastaAktifTakibi.BransKodu = item.BransKodu;
        hastaAktifTakibi.HProtocolNo = item.HProtocolNo;
        hastaAktifTakibi.ProvizyonTarihi = item.ProvizyonTarihi;
        hastaAktifTakibi.TedaviTuru = item.TedaviTuru;
        hastaAktifTakibi.VakaAcilisTarihi = item.VakaAcilisTarihi;
        hastaAktifTakibi.SubEpisode = item.SubEpisode;
        hastaAktifTakibi.EAObjectId = item.EAObjectId;
        that.medulaTedaviRaporlariViewModel.HastaAktifTakipleriList.push(hastaAktifTakibi);
    }
    public cmbRaporTuruChanged(event): void {
        let that = this;
        // this.ftrSelected = true;
        if (this.hastaKabulleriGetir)
            that.medulaTedaviRaporlariViewModel.HastaAktifTakipleriList.Clear();
        this.hastaKabulleriGetir = true;



        if ((event == TedaviRaporTuruEnum.FTR || event == TedaviRaporTuruEnum.ESWT || event == TedaviRaporTuruEnum.FTRTRAFIKKAZASI) && this.chkRaporKaydet.Value == true) {
            this.selectedRaporTuru = TedaviRaporTuruEnum.FTR;
            this.ftrSelected = true;
            for (let item of this.medulaTedaviRaporlariViewModel.HastaAktifTumTakipleriList) {
                let temp = this.FTRBransKodlari.find(t => t == item.BransKodu);
                if (temp != null) {
                    this.SetHastaAktifTakipleriList(that, item);
                }
            }
            let i: number = 1;
            let filterExpression: string = "ResourceSpecialities.Speciality.Code IN(";
            for (let item of this.FTRBransKodlari) {
                filterExpression += "'" + item + "'";
                if (i < this.FTRBransKodlari.length)
                    filterExpression += ',';
                i++;
            }
            filterExpression += ')';
            this.lstTabip.ListFilterExpression = filterExpression;
            this.lstTabip2.ListFilterExpression = filterExpression;
            this.lstTabip3.ListFilterExpression = filterExpression;

            this.kaydetSelected = true;
            if (event == TedaviRaporTuruEnum.FTR || event == TedaviRaporTuruEnum.FTRTRAFIKKAZASI) {
                this.ftrSelected = true;
                this.eswtSelected = false;
                this.eswlSelected = false;
                this.diyalizSelected = false;
                this.evHemodiyaliziSelected = false;
                this.hbtSelected = false;
                this.tupBebekSelected = false;

                this.chkFtrHeyetRaporu.Enabled = true;
                if (this.medulaTedaviRaporlariViewModel.FtrHeyetRaporu == true) {
                    this.labelTabip2 = i18n("M10220", "2.Doktor");
                    this.labelTabip3 = i18n("M10289", "3.Doktor");
                    this.lstTabip3.Enabled = true;
                    this.lstTabip2.Enabled = true;
                }
                this.raporlarSelected = true;
            }
            if (event == TedaviRaporTuruEnum.ESWT) {
                this.ftrSelected = false;
                this.eswtSelected = true;
                this.eswlSelected = false;
                this.diyalizSelected = false;
                this.evHemodiyaliziSelected = false;
                this.hbtSelected = false;
                this.tupBebekSelected = false;

                this.chkFtrHeyetRaporu.Enabled = false;
                this.labelTabip2 = "";
                this.labelTabip3 = "";
                this.lstTabip3.Enabled = false;
                this.lstTabip2.Enabled = false;
            }
            this.raporlarSelected = true;
            this.tupBebekRaporlarSelected = false;
            this.hbtRaporlarSelected = false;
            this.evHemodiyalizRaporlarSelected = false;
            this.diyalizRaporlarSelected = false;
            this.eswlRaporlarSelected = false;

            // this.lstTabip.Visible = true;
            this.RaporBaslangicTarihi.Visible = true;
            this.RaporBitisTarihi.Visible = true;
            this.btnRaporArama.Visible = true;
        }
        else if (event == TedaviRaporTuruEnum.ESWL && this.chkRaporKaydet.Value == true) {

            for (let item of this.medulaTedaviRaporlariViewModel.HastaAktifTumTakipleriList) {
                let temp = this.ESWLBransKodlari.find(t => t == item.BransKodu);
                if (temp != null) {
                    this.SetHastaAktifTakipleriList(that, item);
                }
            }

            let i: number = 1;
            let filterExpression: string = "ResourceSpecialities.Speciality.Code IN(";
            for (let item of this.ESWLBransKodlari) {
                filterExpression += "'" + item + "'";
                if (i < this.ESWLBransKodlari.length)
                    filterExpression += ',';
                i++;
            }
            filterExpression += ')';
            this.lstTabip.ListFilterExpression = filterExpression;
            this.lstTabip2.ListFilterExpression = filterExpression;
            this.lstTabip3.ListFilterExpression = filterExpression;


            this.kaydetSelected = true;

            this.ftrSelected = false;
            this.eswtSelected = false;
            this.eswlSelected = true;
            this.diyalizSelected = false;
            this.evHemodiyaliziSelected = false;
            this.hbtSelected = false;
            this.tupBebekSelected = false;

            this.raporlarSelected = false;
            this.tupBebekRaporlarSelected = false;
            this.hbtRaporlarSelected = false;
            this.evHemodiyalizRaporlarSelected = false;
            this.diyalizRaporlarSelected = false;
            this.eswlRaporlarSelected = true;

            // this.lstTabip.Visible = true;
            this.RaporBaslangicTarihi.Visible = true;
            this.RaporBitisTarihi.Visible = true;
            this.btnRaporArama.Visible = true;
            this.labelTabip2 = "";
            this.labelTabip3 = "";
            this.lstTabip3.Enabled = false;
            this.lstTabip2.Enabled = false;
        }
        else if ((event == TedaviRaporTuruEnum.DIYALIZ || event == TedaviRaporTuruEnum.EVHEMODIYALIZI) && this.chkRaporKaydet.Value == true) {

            for (let item of this.medulaTedaviRaporlariViewModel.HastaAktifTumTakipleriList) {
                let temp = this.DiyalizBransKodlari.find(t => t == item.BransKodu);
                if (temp != null) {
                    this.SetHastaAktifTakipleriList(that, item);
                }
            }

            let i: number = 1;
            let filterExpression: string = "ResourceSpecialities.Speciality.Code IN(";
            for (let item of this.DiyalizBransKodlari) {
                filterExpression += "'" + item + "'";
                if (i < this.DiyalizBransKodlari.length)
                    filterExpression += ',';
                i++;
            }
            filterExpression += ')';
            this.lstTabip.ListFilterExpression = filterExpression;
            this.lstTabip2.ListFilterExpression = filterExpression;
            this.lstTabip3.ListFilterExpression = filterExpression;

            if (event == TedaviRaporTuruEnum.DIYALIZ) {
                this.diyalizSelected = true;
                this.evHemodiyaliziSelected = false;
                this.diyalizRaporlarSelected = true;
                this.evHemodiyalizRaporlarSelected = false;
            }
            if (event == TedaviRaporTuruEnum.EVHEMODIYALIZI) {
                this.diyalizSelected = false;
                this.evHemodiyaliziSelected = true;
                this.diyalizRaporlarSelected = false;
                this.evHemodiyalizRaporlarSelected = true;
            }
            this.kaydetSelected = true;

            this.ftrSelected = false;
            this.eswtSelected = false;
            this.eswlSelected = false;
            this.hbtSelected = false;
            this.tupBebekSelected = false;

            this.raporlarSelected = false;
            this.tupBebekRaporlarSelected = false;
            this.hbtRaporlarSelected = false;
            this.eswlRaporlarSelected = false;

            // this.lstTabip.Visible = true;
            this.RaporBaslangicTarihi.Visible = true;
            this.RaporBitisTarihi.Visible = true;
            this.btnRaporArama.Visible = true;
            this.labelTabip2 = "";
            this.labelTabip3 = "";
            this.lstTabip3.Enabled = false;
            this.lstTabip2.Enabled = false;
        }
        else if (event == TedaviRaporTuruEnum.HBT && this.chkRaporKaydet.Value == true) {


            for (let item of this.medulaTedaviRaporlariViewModel.HastaAktifTumTakipleriList) {
                let temp = this.HOTBransKodlari.find(t => t == item.BransKodu);
                if (temp != null) {
                    this.SetHastaAktifTakipleriList(that, item);
                }
            }
            let i: number = 1;
            let filterExpression: string = "ResourceSpecialities.Speciality.Code IN(";
            for (let item of this.HOTBransKodlari) {
                filterExpression += "'" + item + "'";
                if (i < this.HOTBransKodlari.length)
                    filterExpression += ',';
                i++;
            }
            filterExpression += ')';

            let j: number = 1;
            let filterExpression2: string = "ResourceSpecialities.Speciality.Code IN(";
            for (let item of this.FTRHOTBransKodlari) {
                filterExpression2 += "'" + item + "'";
                if (j < this.FTRHOTBransKodlari.length)
                    filterExpression2 += ',';
                j++;
            }
            filterExpression2 += ')';
            this.lstTabip.ListFilterExpression = filterExpression;
            this.lstTabip2.ListFilterExpression = filterExpression2;
            this.lstTabip3.ListFilterExpression = filterExpression2;

            this.chkFtrHeyetRaporu.Enabled = true;

            this.kaydetSelected = true;

            this.ftrSelected = false;
            this.eswtSelected = false;
            this.eswlSelected = false;
            this.diyalizSelected = false;
            this.evHemodiyaliziSelected = false;
            this.hbtSelected = true;
            this.tupBebekSelected = false;

            this.raporlarSelected = false;
            this.tupBebekRaporlarSelected = false;
            this.hbtRaporlarSelected = true;
            this.evHemodiyalizRaporlarSelected = false;
            this.diyalizRaporlarSelected = false;
            this.eswlRaporlarSelected = false;

            // this.lstTabip.Visible = true;
            this.RaporBaslangicTarihi.Visible = true;
            this.RaporBitisTarihi.Visible = true;
            this.btnRaporArama.Visible = true;
            this.labelTabip2 = "";
            this.labelTabip3 = "";
            this.lstTabip3.Enabled = false;
            this.lstTabip2.Enabled = false;
        }
        else if (event == TedaviRaporTuruEnum.TUPBEBEK && this.chkRaporKaydet.Value == true) {

            for (let item of this.medulaTedaviRaporlariViewModel.HastaAktifTumTakipleriList) {
                let temp = this.TupBebekBransKodlari.find(t => t == item.BransKodu);
                if (temp != null) {
                    this.SetHastaAktifTakipleriList(that, item);
                }
            }

            let i: number = 1;
            let filterExpression: string = "ResourceSpecialities.Speciality.Code IN(";
            for (let item of this.TupBebekBransKodlari) {
                filterExpression += "'" + item + "'";
                if (i < this.TupBebekBransKodlari.length)
                    filterExpression += ',';
                i++;
            }
            filterExpression += ')';
            this.lstTabip.ListFilterExpression = filterExpression;
            this.lstTabip2.ListFilterExpression = filterExpression;
            this.lstTabip3.ListFilterExpression = filterExpression;

            this.kaydetSelected = true;

            this.ftrSelected = false;
            this.eswtSelected = false;
            this.eswlSelected = false;
            this.diyalizSelected = false;
            this.evHemodiyaliziSelected = false;
            this.hbtSelected = false;
            this.tupBebekSelected = true;

            this.raporlarSelected = false;
            this.tupBebekRaporlarSelected = true;
            this.hbtRaporlarSelected = false;
            this.evHemodiyalizRaporlarSelected = false;
            this.diyalizRaporlarSelected = false;
            this.eswlRaporlarSelected = false;

            // this.lstTabip.Visible = true;
            this.RaporBaslangicTarihi.Visible = true;
            this.RaporBitisTarihi.Visible = true;
            this.btnRaporArama.Visible = true;
            this.labelTabip2 = i18n("M10220", "2.Doktor");
            this.labelTabip3 = i18n("M10289", "3.Doktor");
            this.lstTabip3.Enabled = true;
            this.lstTabip2.Enabled = true;
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CommitteeReport = true;
        }
        else {

            for (let item of this.medulaTedaviRaporlariViewModel.HastaAktifTumTakipleriList) {
                this.SetHastaAktifTakipleriList(that, item);

            }
            this.kaydetSelected = false;

            //this.ftrSelected = false;
            //this.eswtSelected = false;
            //this.eswlSelected = false;
            //this.diyalizSelected = false;
            //this.evHemodiyaliziSelected = false;
            //this.hbtSelected = false;
            //this.tupBebekSelected = true;

            this.raporlarSelected = false;
            this.tupBebekRaporlarSelected = false;
            this.hbtRaporlarSelected = false;
            this.evHemodiyalizRaporlarSelected = false;
            this.diyalizRaporlarSelected = false;
            this.eswlRaporlarSelected = false;

            // this.lstTabip.Visible = true;
            //this.RaporBaslangicTarihi.Visible = true;
            //this.RaporBitisTarihi.Visible = true;
            //this.btnRaporArama.Visible = false;
            this.labelTabip2 = "";
            this.labelTabip3 = "";
            this.lstTabip3.Enabled = false;
            this.lstTabip2.Enabled = false;
        }
    }
    detailFTR(value): void {
        let gridFtrRaporlari: GridFtrRaporlariListModel = new GridFtrRaporlariListModel();
        gridFtrRaporlari = value.row.data as GridFtrRaporlariListModel;
        this.reportDetail = gridFtrRaporlari.Detail;
        this.showReportDetail = true;
    }
    detailESWL(value): void {
        let gridEswlRaporlari: GridEswlRaporlariListModel = new GridEswlRaporlariListModel();
        gridEswlRaporlari = value.row.data as GridEswlRaporlariListModel;
        this.reportDetail = gridEswlRaporlari.Detail;
        this.showReportDetail = true;
    }
    detailDiyaliz(value): void {
        let gridDiyalizRaporlari: GridDiyalizRaporlariListModel = new GridDiyalizRaporlariListModel();
        gridDiyalizRaporlari = value.row.data as GridDiyalizRaporlariListModel;
        this.reportDetail = gridDiyalizRaporlari.Detail;
        this.showReportDetail = true;
    }
    detailEvHemodiyaliz(value): void {
        let gridEvDiyalizRaporlari: GridEvdiyalizRaporlariListModel = new GridEvdiyalizRaporlariListModel();
        gridEvDiyalizRaporlari = value.row.data as GridEvdiyalizRaporlariListModel;
        this.reportDetail = gridEvDiyalizRaporlari.Detail;
        this.showReportDetail = true;
    }
    detailHOT(value): void {
        let gridHOTRaporlari: GridHOTRaporlariListModel = new GridHOTRaporlariListModel();
        gridHOTRaporlari = value.row.data as GridHOTRaporlariListModel;
        this.reportDetail = gridHOTRaporlari.Detail;
        this.showReportDetail = true;
    }
    detailTupBebek(value): void {
        let gridTupBebekRaporlari: GridTupBebekRaporlariListModel = new GridTupBebekRaporlariListModel();
        gridTupBebekRaporlari = value.row.data as GridTupBebekRaporlariListModel;
        this.reportDetail = gridTupBebekRaporlari.Detail;
        this.showReportDetail = true;
    }

    public raporNo: any;
    public raporSira: any;
    public raporBaslangicTarihi: any;

    async deleteFTR(value) {
        /*  if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CurrentStateDefID.valueOf() != MedulaTreatmentReport.MedulaTreatmentReportStates.New.id) {
              this.messageService.showInfo(i18n("M22733", "Tamamlanmış raporu silemezsiniz, Geri alınız!"));
              return;
          }*/

        let gridFtrRaporlari: GridFtrRaporlariListModel = new GridFtrRaporlariListModel();

        if (value == "") {
            this.raporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo;
            this.raporSira = "0";
            this.raporBaslangicTarihi = this.datePipe.transform(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate, 'dd.MM.yyyy');
        }
        else {
            gridFtrRaporlari = value.row.data as GridFtrRaporlariListModel;
            this.raporNo = gridFtrRaporlari.RaporNo;
            this.raporSira = gridFtrRaporlari.RaporSiraNo;
            this.raporBaslangicTarihi = gridFtrRaporlari.RaporBaslangicTarihi;
        }

        this.messageService.showInfo(i18n("M21559", "Seçili Rapor Meduladan Silinecektir!! "));
        let apiUrlForRaporSil: string = '/api/MedulaTreatmentReportService/';
        let response: RaporIslemleri.raporCevapDVO;
        let objectID: string = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ObjectID.toString();
        await this.httpService.get(apiUrlForRaporSil + "raporBilgisiSil?no=" + this.raporNo + "&siraNo=" + this.raporSira + "&tarih=" + this.raporBaslangicTarihi + "&objectID=" + objectID)
            .then(response => {
                let responseDVO = response as RaporIslemleri.raporCevapDVO;
                if (responseDVO.sonucKodu == 0) {
                    gridFtrRaporlari.Kur = 0;
                    gridFtrRaporlari.RaporBaslangicTarihi = "";
                    gridFtrRaporlari.RaporNo = "";
                    gridFtrRaporlari.RaporSiraNo = 0;
                    gridFtrRaporlari.TakipNo = 0;
                    gridFtrRaporlari.VerildigiTesis = "";
                    gridFtrRaporlari.VucutBolgesi = "";
                    gridFtrRaporlari.SonucKodu = 0;
                    gridFtrRaporlari.SonucMesaji = "";

                }
                else {
                    this.messageService.showInfo(i18n("M20840", "Rapor Servisinden Gelen Sonuç Mesajı : ") + responseDVO.sonucAciklamasi);
                    return;
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
    async deleteESWL(value) {
        let gridEswlRaporlari: GridEswlRaporlariListModel = new GridEswlRaporlariListModel();
        if (value == "") {
            this.raporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo;
            this.raporSira = "0";
            this.raporBaslangicTarihi = this.datePipe.transform(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate, 'dd.MM.yyyy');
        }
        else {
            gridEswlRaporlari = value.row.data as GridEswlRaporlariListModel;
            this.raporNo = gridEswlRaporlari.RaporNo;
            this.raporSira = gridEswlRaporlari.RaporSiraNo;
            this.raporBaslangicTarihi = gridEswlRaporlari.RaporBaslangicTarihi;
        }

        this.messageService.showInfo(i18n("M21559", "Seçili Rapor Meduladan Silinecektir!! "));
        let apiUrlForRaporSil: string = '/api/MedulaTreatmentReportService/';
        let response: RaporIslemleri.raporCevapDVO;
        await this.httpService.get(apiUrlForRaporSil + "raporBilgisiSil?no=" + this.raporNo + "&siraNo=" + this.raporSira + "&tarih=" + this.raporBaslangicTarihi)
            .then(response => {
                let responseDVO = response as RaporIslemleri.raporCevapDVO;
                if (responseDVO.sonucKodu == 0) {
                    gridEswlRaporlari.SonucKodu = 0;
                    gridEswlRaporlari.RaporBaslangicTarihi = "";
                    gridEswlRaporlari.RaporNo = "";
                    gridEswlRaporlari.RaporSiraNo = 0;
                    gridEswlRaporlari.TakipNo = 0;
                    gridEswlRaporlari.VerildigiTesis = "";
                    gridEswlRaporlari.SonucMesaji = "";
                }
                else {
                    this.messageService.showInfo(i18n("M20840", "Rapor Servisinden Gelen Sonuç Mesajı : ") + responseDVO.sonucAciklamasi);
                    return;
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
    async deleteDiyaliz(value) {
        let gridDiyalizRaporlari: GridDiyalizRaporlariListModel = new GridDiyalizRaporlariListModel();
        if (value == "") {
            this.raporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo;
            this.raporSira = "0";
            this.raporBaslangicTarihi = this.datePipe.transform(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate, 'dd.MM.yyyy');
        }
        else {
            gridDiyalizRaporlari = value.row.data as GridDiyalizRaporlariListModel;
            this.raporNo = gridDiyalizRaporlari.RaporNo;
            this.raporSira = gridDiyalizRaporlari.RaporSiraNo;
            this.raporBaslangicTarihi = gridDiyalizRaporlari.RaporBaslangicTarihi;
        }

        this.messageService.showInfo(i18n("M21559", "Seçili Rapor Meduladan Silinecektir!! "));
        let apiUrlForRaporSil: string = '/api/MedulaTreatmentReportService/';
        let response: RaporIslemleri.raporCevapDVO;
        await this.httpService.get(apiUrlForRaporSil + "raporBilgisiSil?no=" + this.raporNo + "&siraNo=" + this.raporSira + "&tarih=" + this.raporBaslangicTarihi)
            .then(response => {
                let responseDVO = response as RaporIslemleri.raporCevapDVO;
                if (responseDVO.sonucKodu == 0) {
                    gridDiyalizRaporlari.SonucKodu = 0;
                    gridDiyalizRaporlari.RaporBaslangicTarihi = "";
                    gridDiyalizRaporlari.RaporNo = "";
                    gridDiyalizRaporlari.RaporSiraNo = 0;
                    gridDiyalizRaporlari.TakipNo = 0;
                    gridDiyalizRaporlari.VerildigiTesis = "";
                    gridDiyalizRaporlari.SonucMesaji = "";
                }
                else {
                    this.messageService.showInfo(i18n("M20840", "Rapor Servisinden Gelen Sonuç Mesajı : ") + responseDVO.sonucAciklamasi);
                    return;
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
    async deleteEvHemodiyaliz(value) {
        let gridEvdiyalizRaporlari: GridEvdiyalizRaporlariListModel = new GridEvdiyalizRaporlariListModel();
        if (value == "") {
            this.raporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo;
            this.raporSira = "0";
            this.raporBaslangicTarihi = this.datePipe.transform(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate, 'dd.MM.yyyy');
        }
        else {
            gridEvdiyalizRaporlari = value.row.data as GridEvdiyalizRaporlariListModel;
            this.raporNo = gridEvdiyalizRaporlari.RaporNo;
            this.raporSira = gridEvdiyalizRaporlari.RaporSiraNo;
            this.raporBaslangicTarihi = gridEvdiyalizRaporlari.RaporBaslangicTarihi;
        }

        await this.messageService.showInfo(i18n("M21559", "Seçili Rapor Meduladan Silinecektir!! "));
        let apiUrlForRaporSil: string = '/api/MedulaTreatmentReportService/';
        let response: RaporIslemleri.raporCevapDVO;
        this.httpService.get(apiUrlForRaporSil + "raporBilgisiSil?no=" + this.raporNo + "&siraNo=" + this.raporSira + "&tarih=" + this.raporBaslangicTarihi)
            .then(response => {
                let responseDVO = response as RaporIslemleri.raporCevapDVO;
                if (responseDVO.sonucKodu == 0) {
                    gridEvdiyalizRaporlari.SonucKodu = 0;
                    gridEvdiyalizRaporlari.RaporBaslangicTarihi = "";
                    gridEvdiyalizRaporlari.RaporNo = "";
                    gridEvdiyalizRaporlari.RaporSiraNo = 0;
                    gridEvdiyalizRaporlari.TakipNo = 0;
                    gridEvdiyalizRaporlari.VerildigiTesis = "";
                    gridEvdiyalizRaporlari.SonucMesaji = "";
                }
                else {
                    this.messageService.showInfo(i18n("M20840", "Rapor Servisinden Gelen Sonuç Mesajı : ") + responseDVO.sonucAciklamasi);
                    return;
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
    async deleteHOT(value) {
        let gridHOTRaporlari: GridHOTRaporlariListModel = new GridHOTRaporlariListModel();

        if (value == "") {
            this.raporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo;
            this.raporSira = "0";
            this.raporBaslangicTarihi = this.datePipe.transform(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate, 'dd.MM.yyyy');
        }
        else {
            gridHOTRaporlari = value.row.data as GridHOTRaporlariListModel;
            this.raporNo = gridHOTRaporlari.RaporNo;
            this.raporSira = gridHOTRaporlari.RaporSiraNo;
            this.raporBaslangicTarihi = gridHOTRaporlari.RaporBaslangicTarihi;
        }

        this.messageService.showInfo(i18n("M21559", "Seçili Rapor Meduladan Silinecektir!! "));
        let apiUrlForRaporSil: string = '/api/MedulaTreatmentReportService/';
        let response: RaporIslemleri.raporCevapDVO;
        await this.httpService.get(apiUrlForRaporSil + "raporBilgisiSil?no=" + this.raporNo + "&siraNo=" + this.raporSira + "&tarih=" + this.raporBaslangicTarihi)
            .then(response => {
                let responseDVO = response as RaporIslemleri.raporCevapDVO;
                if (responseDVO.sonucKodu == 0) {
                    gridHOTRaporlari.SonucKodu = 0;
                    gridHOTRaporlari.RaporBaslangicTarihi = "";
                    gridHOTRaporlari.RaporNo = "";
                    gridHOTRaporlari.RaporSiraNo = 0;
                    gridHOTRaporlari.TakipNo = 0;
                    gridHOTRaporlari.VerildigiTesis = "";
                    gridHOTRaporlari.SonucMesaji = "";
                }
                else {
                    this.messageService.showInfo(i18n("M20840", "Rapor Servisinden Gelen Sonuç Mesajı : ") + responseDVO.sonucAciklamasi);
                    return;
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
    async deleteTupBebek(value) {
        let gridTupBebekRaporlari: GridTupBebekRaporlariListModel = new GridTupBebekRaporlariListModel();
        if (value == "") {
            this.raporNo = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ReportNo;
            this.raporSira = "0";
            this.raporBaslangicTarihi = this.datePipe.transform(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.StartDate, 'dd.MM.yyyy');
        }
        else {
            gridTupBebekRaporlari = value.row.data as GridTupBebekRaporlariListModel;
            this.raporNo = gridTupBebekRaporlari.RaporNo;
            this.raporSira = gridTupBebekRaporlari.RaporSiraNo;
            this.raporBaslangicTarihi = gridTupBebekRaporlari.RaporBaslangicTarihi;
        }
        this.messageService.showInfo(i18n("M21559", "Seçili Rapor Meduladan Silinecektir!! "));
        let apiUrlForRaporSil: string = '/api/MedulaTreatmentReportService/';
        let response: RaporIslemleri.raporCevapDVO;
        await this.httpService.get(apiUrlForRaporSil + "raporBilgisiSil?no=" + this.raporNo + "&siraNo=" + this.raporSira + "&tarih=" + this.raporBaslangicTarihi)
            .then(response => {
                let responseDVO = response as RaporIslemleri.raporCevapDVO;
                if (responseDVO.sonucKodu == 0) {
                    gridTupBebekRaporlari.SonucKodu = 0;
                    gridTupBebekRaporlari.RaporBaslangicTarihi = "";
                    gridTupBebekRaporlari.RaporNo = "";
                    gridTupBebekRaporlari.RaporSiraNo = 0;
                    gridTupBebekRaporlari.TakipNo = 0;
                    gridTupBebekRaporlari.VerildigiTesis = "";
                    gridTupBebekRaporlari.SonucMesaji = "";
                }
                else {
                    this.messageService.showInfo(i18n("M20840", "Rapor Servisinden Gelen Sonuç Mesajı : ") + responseDVO.sonucAciklamasi);
                    return;
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.Description != event) {
                this._MedulaTreatmentReport.Description = event;
            }
        }
    }

    public onSonucAciklamasiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.SonucAciklamasi != event) {
                this._MedulaTreatmentReport.SonucAciklamasi = event;
            }
        }
    }

    public onSonucKoduChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null && this._MedulaTreatmentReport.SonucKodu != event) {
                this._MedulaTreatmentReport.SonucKodu = event;
            }
        }
    }

    public loadBransKodlari() {
        this.FTRBransKodlari.push("1800");
        this.FTRBransKodlari.push("1855");
        this.FTRBransKodlari.push("2600");
        this.FTRBransKodlari.push("2679");
        this.FTRBransKodlari.push("4000");
        this.FTRBransKodlari.push("600");
        //  this.FTRBransKodlari.push("1100");///Deneme silinecek

        this.FTRHOTBransKodlari.push("1800");
        this.FTRHOTBransKodlari.push("1855");
        this.FTRHOTBransKodlari.push("2600");
        this.FTRHOTBransKodlari.push("2679");
        this.FTRHOTBransKodlari.push("4000");
        this.FTRHOTBransKodlari.push("600");
        this.FTRHOTBransKodlari.push("4300");
        this.FTRHOTBransKodlari.push("4200");

        this.ESWLBransKodlari.push("2700");
        this.ESWLBransKodlari.push("2781");
        this.ESWLBransKodlari.push("2796");

        this.DiyalizBransKodlari.push("1062");

        this.HOTBransKodlari.push("4300");
        this.HOTBransKodlari.push("4200");

        this.TupBebekBransKodlari.push("3000");
        this.TupBebekBransKodlari.push("3050");
    }
    public fun(a: any) {

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PopupTextAreaForm';
        componentInfo.ModuleName = 'PopupTextAreaModule';
        componentInfo.ModulePath = 'Modules/Tibbi_Surec/Sosyal_Hizmetler_Modulu/PopupTextArea/PopupTextAreaModule';
        componentInfo.InputParam = new DynamicComponentInputParam(a.Text, new ActiveIDsModel(this._MedulaTreatmentReport.ObjectID, null, null));

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = "";
        modalInfo.Width = 950;
        modalInfo.Height = 950;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                if (res.Param.toString() != "[object Object]") {
                    a.Rtf = res.Param;

                    a.Text = res.Param;
                }
            }).catch(err => {
                reject(err);
            });
        });
        return promise;

    }

    protected async PreScript() {
        this.chkRaporKaydet.Value = true;

        if (this._ViewModel.Patient != null) {
            this.medulaTedaviRaporlariViewModel = this._ViewModel;
            if (this._ViewModel.HistoryPatientAdmission != null && this._ViewModel.HistoryPatientAdmission.length > 0) {
                this.hastaKabulleriGetir = false;
                if ((this.FTRBransKodlari.find(t => t == this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[0].Bransno)) != null) {
                    this.medulaTedaviRaporlariViewModel.RaporTuru = TedaviRaporTuruEnum.FTR;
                }
                else if ((this.ESWLBransKodlari.find(t => t == this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[0].Bransno)) != null) {
                    this.medulaTedaviRaporlariViewModel.RaporTuru = TedaviRaporTuruEnum.ESWL;
                }
                else if ((this.DiyalizBransKodlari.find(t => t == this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[0].Bransno)) != null) {
                    this.medulaTedaviRaporlariViewModel.RaporTuru = TedaviRaporTuruEnum.DIYALIZ;
                }
                else if ((this.HOTBransKodlari.find(t => t == this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[0].Bransno)) != null) {
                    this.medulaTedaviRaporlariViewModel.RaporTuru = TedaviRaporTuruEnum.HBT;
                }
                else if ((this.TupBebekBransKodlari.find(t => t == this.medulaTedaviRaporlariViewModel.HistoryPatientAdmission[0].Bransno)) != null) {
                    this.medulaTedaviRaporlariViewModel.RaporTuru = TedaviRaporTuruEnum.TUPBEBEK;
                }
                else
                    this.medulaTedaviRaporlariViewModel.RaporTuru = undefined;
                this.patientChanged(this._ViewModel.Patient);
            }



        }
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CommitteeReport == null)
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CommitteeReport = false;

        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CommitteeReport == true) {
            this.lstTabip2.Enabled = true;
            this.lstTabip2.Required = true;
            this.lstTabip3.Enabled = true;
            this.lstTabip3.Required = true;
        }

        await this.SetButtonVisibility();
    }

    async SetButtonVisibility() {
        if (this._MedulaTreatmentReport.CurrentStateDefID.valueOf() == MedulaTreatmentReport.MedulaTreatmentReportStates.New.id) {
            this.IsBackState = true;
            this.IsCancelState = false;
        }
        else if (this._MedulaTreatmentReport.CurrentStateDefID.valueOf() == MedulaTreatmentReport.MedulaTreatmentReportStates.SendMedula.id) {
            this.IsCancelState = true;
            this.IsBackState = true;
        }
        else if (this._MedulaTreatmentReport.CurrentStateDefID.valueOf() == MedulaTreatmentReport.MedulaTreatmentReportStates.Saved.id) {
            this.IsCancelState = false;
            this.IsBackState = false;
        }
        else if (this._MedulaTreatmentReport.CurrentStateDefID.valueOf() == MedulaTreatmentReport.MedulaTreatmentReportStates.Completed.id) {
            this.IsBackState = false;
            this.IsCancelState = false;
        }
        else if (this._MedulaTreatmentReport.CurrentStateDefID.valueOf() == MedulaTreatmentReport.MedulaTreatmentReportStates.Cancelled.id) {
            this.IsBackState = true;
            this.IsCancelState = true;
        }

        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo == null || this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo == "0")
            this.IsSendMedula = true;
        else
            this.IsSendMedula = false;
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MedulaTreatmentReport();
        this.medulaTedaviRaporlariViewModel = new MedulaTedaviRaporlariViewModel();
        //this.medulaTedaviRaporlariViewModel.reportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel ();
        this._ViewModel = this.medulaTedaviRaporlariViewModel;
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport = this._TTObject as MedulaTreatmentReport;
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.FTRReport = new FTRReport();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.FTRReport.FTRReportDetailGrid = new Array<FTRReportDetailGrid>();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWTReport = new ESWTReport();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWTReport.ESWTReportDetailGrid = new Array<ESWTReportDetailGrid>();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport = new ESWLReport();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport.Bobrek = new Bobrek();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport.TedaviRaporiIslemKodlari = new TedaviRaporiIslemKodlari();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport.ESWLReportDetailGrid = new Array<ESWLReportDetailGrid>();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.DialysisReport = new DialysisReport();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.DialysisReport.TedaviRaporiIslemKodlari = new TedaviRaporiIslemKodlari();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HomeHemodialysisReport = new HomeHemodialysisReport();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HomeHemodialysisReport.TedaviRaporiIslemKodlari = new TedaviRaporiIslemKodlari();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HBTReport = new HBTReport();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TubeBabyReport = new TubeBabyReport();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TubeBabyReport.TedaviRaporiIslemKodlari = new TedaviRaporiIslemKodlari();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ThirdDoctor = new ResUser();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.SecondDoctor = new ResUser();
        this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ProcedureDoctor = new ResUser();
        this.loadBransKodlari();
    }

    protected loadViewModel() {
        let that = this;
        that.medulaTedaviRaporlariViewModel = this._ViewModel as MedulaTedaviRaporlariViewModel;
        that._TTObject = this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport;
        if (this.medulaTedaviRaporlariViewModel == null)
            this.medulaTedaviRaporlariViewModel = new MedulaTedaviRaporlariViewModel();
        if (this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport == null)
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport = new MedulaTreatmentReport();
        let fTRReportObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["FTRReport"];
        if (fTRReportObjectID != null && (typeof fTRReportObjectID === "string")) {
            let fTRReport = that.medulaTedaviRaporlariViewModel.FTRReports.find(o => o.ObjectID.toString() === fTRReportObjectID.toString());
            if (fTRReport) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.FTRReport = fTRReport;
            } if (fTRReport != null) {
                fTRReport.FTRReportDetailGrid = that.medulaTedaviRaporlariViewModel.gridFizyoTerapiIslemleriGridList;
                for (let detailItem of that.medulaTedaviRaporlariViewModel.gridFizyoTerapiIslemleriGridList) {
                    let tedaviRaporiIslemKodlariObjectID = detailItem["TedaviRaporiIslemKodlari"];
                    if (tedaviRaporiIslemKodlariObjectID != null && (typeof tedaviRaporiIslemKodlariObjectID === "string")) {
                        let tedaviRaporiIslemKodlari = that.medulaTedaviRaporlariViewModel.TedaviRaporiIslemKodlaris.find(o => o.ObjectID.toString() === tedaviRaporiIslemKodlariObjectID.toString());
                        if (tedaviRaporiIslemKodlari) {
                            detailItem.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodlari;
                        }
                    }
                    let fTRVucutBolgesiObjectID = detailItem["FTRVucutBolgesi"];
                    if (fTRVucutBolgesiObjectID != null && (typeof fTRVucutBolgesiObjectID === "string")) {
                        let fTRVucutBolgesi = that.medulaTedaviRaporlariViewModel.FTRVucutBolgesis.find(o => o.ObjectID.toString() === fTRVucutBolgesiObjectID.toString());
                        if (fTRVucutBolgesi) {
                            detailItem.FTRVucutBolgesi = fTRVucutBolgesi;
                        }
                    }
                    let tedaviTuruObjectID = detailItem["TedaviTuru"];
                    if (tedaviTuruObjectID != null && (typeof tedaviTuruObjectID === "string")) {
                        let tedaviTuru = that.medulaTedaviRaporlariViewModel.TedaviTurus.find(o => o.ObjectID.toString() === tedaviTuruObjectID.toString());
                        if (tedaviTuru) {
                            detailItem.TedaviTuru = tedaviTuru;
                        }
                    }
                }
            }
        }
        else {
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.FTRReport = new FTRReport();
            this.medulaTedaviRaporlariViewModel.FTRReports.push(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.FTRReport);
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.FTRReport.FTRReportDetailGrid = new Array<FTRReportDetailGrid>();
        }
        let eSWTReportObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["ESWTReport"];
        if (eSWTReportObjectID != null && (typeof eSWTReportObjectID === "string")) {
            let eSWTReport = that.medulaTedaviRaporlariViewModel.ESWTReports.find(o => o.ObjectID.toString() === eSWTReportObjectID.toString());
            if (eSWTReport) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWTReport = eSWTReport;
            } if (eSWTReport != null) {
                eSWTReport.ESWTReportDetailGrid = that.medulaTedaviRaporlariViewModel.gridEswtIslemiGridList;
                for (let detailItem of that.medulaTedaviRaporlariViewModel.gridEswtIslemiGridList) {
                    let tedaviRaporiIslemKodlariObjectID = detailItem["TedaviRaporiIslemKodlari"];
                    if (tedaviRaporiIslemKodlariObjectID != null && (typeof tedaviRaporiIslemKodlariObjectID === "string")) {
                        let tedaviRaporiIslemKodlari = that.medulaTedaviRaporlariViewModel.TedaviRaporiIslemKodlaris.find(o => o.ObjectID.toString() === tedaviRaporiIslemKodlariObjectID.toString());
                        if (tedaviRaporiIslemKodlari) {
                            detailItem.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodlari;
                        }
                    }
                    let fTRVucutBolgesiObjectID = detailItem["FTRVucutBolgesi"];
                    if (fTRVucutBolgesiObjectID != null && (typeof fTRVucutBolgesiObjectID === "string")) {
                        let fTRVucutBolgesi = that.medulaTedaviRaporlariViewModel.FTRVucutBolgesis.find(o => o.ObjectID.toString() === fTRVucutBolgesiObjectID.toString());
                        if (fTRVucutBolgesi) {
                            detailItem.FTRVucutBolgesi = fTRVucutBolgesi;
                        }
                    }
                }
            }
        }
        else {
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWTReport = new ESWTReport();
            this.medulaTedaviRaporlariViewModel.ESWTReports.push(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWTReport);
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWTReport.ESWTReportDetailGrid = new Array<ESWTReportDetailGrid>();
        }
        let eSWLReportObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["ESWLReport"];
        if (eSWLReportObjectID != null && (typeof eSWLReportObjectID === "string")) {
            let eSWLReport = that.medulaTedaviRaporlariViewModel.ESWLReports.find(o => o.ObjectID.toString() === eSWLReportObjectID.toString());
            if (eSWLReport) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport = eSWLReport;
            } if (eSWLReport != null) {
                let bobrekObjectID = eSWLReport["Bobrek"];
                if (bobrekObjectID != null && (typeof bobrekObjectID === "string")) {
                    let bobrek = that.medulaTedaviRaporlariViewModel.Bobreks.find(o => o.ObjectID.toString() === bobrekObjectID.toString());
                    if (bobrek) {
                        eSWLReport.Bobrek = bobrek;
                    }
                }
            }
            if (eSWLReport != null) {
                let tedaviRaporiIslemKodlariObjectID = eSWLReport["TedaviRaporiIslemKodlari"];
                if (tedaviRaporiIslemKodlariObjectID != null && (typeof tedaviRaporiIslemKodlariObjectID === "string")) {
                    let tedaviRaporiIslemKodlari = that.medulaTedaviRaporlariViewModel.TedaviRaporiIslemKodlaris.find(o => o.ObjectID.toString() === tedaviRaporiIslemKodlariObjectID.toString());
                    if (tedaviRaporiIslemKodlari) {
                        eSWLReport.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodlari;
                    }
                }
            }
            if (eSWLReport != null) {
                eSWLReport.ESWLReportDetailGrid = that.medulaTedaviRaporlariViewModel.gridTasBilgisiGridList;
                for (let detailItem of that.medulaTedaviRaporlariViewModel.gridTasBilgisiGridList) {
                    let tasLokalizasyonObjectID = detailItem["TasLokalizasyon"];
                    if (tasLokalizasyonObjectID != null && (typeof tasLokalizasyonObjectID === "string")) {
                        let tasLokalizasyon = that.medulaTedaviRaporlariViewModel.TasLokalizasyons.find(o => o.ObjectID.toString() === tasLokalizasyonObjectID.toString());
                        if (tasLokalizasyon) {
                            detailItem.TasLokalizasyon = tasLokalizasyon;
                        }
                    }
                }
            }
        }
        else {
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport = new ESWLReport();
            this.medulaTedaviRaporlariViewModel.ESWLReports.push(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport);
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ESWLReport.ESWLReportDetailGrid = new Array<ESWLReportDetailGrid>();
        }
        let dialysisReportObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["DialysisReport"];
        if (dialysisReportObjectID != null && (typeof dialysisReportObjectID === "string")) {
            let dialysisReport = that.medulaTedaviRaporlariViewModel.DialysisReports.find(o => o.ObjectID.toString() === dialysisReportObjectID.toString());
            if (dialysisReport) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.DialysisReport = dialysisReport;
            } if (dialysisReport != null) {
                let tedaviRaporiIslemKodlariObjectID = dialysisReport["TedaviRaporiIslemKodlari"];
                if (tedaviRaporiIslemKodlariObjectID != null && (typeof tedaviRaporiIslemKodlariObjectID === "string")) {
                    let tedaviRaporiIslemKodlari = that.medulaTedaviRaporlariViewModel.TedaviRaporiIslemKodlaris.find(o => o.ObjectID.toString() === tedaviRaporiIslemKodlariObjectID.toString());
                    if (tedaviRaporiIslemKodlari) {
                        dialysisReport.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodlari;
                    }
                }
            }
        }
        else {
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.DialysisReport = new DialysisReport();
            this.medulaTedaviRaporlariViewModel.DialysisReports.push(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.DialysisReport);
        }
        let homeHemodialysisReportObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["HomeHemodialysisReport"];
        if (homeHemodialysisReportObjectID != null && (typeof homeHemodialysisReportObjectID === "string")) {
            let homeHemodialysisReport = that.medulaTedaviRaporlariViewModel.HomeHemodialysisReports.find(o => o.ObjectID.toString() === homeHemodialysisReportObjectID.toString());
            if (homeHemodialysisReport) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HomeHemodialysisReport = homeHemodialysisReport;
            } if (homeHemodialysisReport != null) {
                let tedaviRaporiIslemKodlariObjectID = homeHemodialysisReport["TedaviRaporiIslemKodlari"];
                if (tedaviRaporiIslemKodlariObjectID != null && (typeof tedaviRaporiIslemKodlariObjectID === "string")) {
                    let tedaviRaporiIslemKodlari = that.medulaTedaviRaporlariViewModel.TedaviRaporiIslemKodlaris.find(o => o.ObjectID.toString() === tedaviRaporiIslemKodlariObjectID.toString());
                    if (tedaviRaporiIslemKodlari) {
                        homeHemodialysisReport.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodlari;
                    }
                }
            }
        } else {
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HomeHemodialysisReport = new HomeHemodialysisReport();
            this.medulaTedaviRaporlariViewModel.HomeHemodialysisReports.push(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HomeHemodialysisReport);
        }

        let hBTReportObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["HBTReport"];
        if (hBTReportObjectID != null && (typeof hBTReportObjectID === "string")) {
            let hBTReport = that.medulaTedaviRaporlariViewModel.HBTReports.find(o => o.ObjectID.toString() === hBTReportObjectID.toString());
            if (hBTReport) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HBTReport = hBTReport;
            }
        }
        else {
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HBTReport = new HBTReport();
            this.medulaTedaviRaporlariViewModel.HBTReports.push(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.HBTReport);
        }
        let tubeBabyReportObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["TubeBabyReport"];
        if (tubeBabyReportObjectID != null && (typeof tubeBabyReportObjectID === "string")) {
            let tubeBabyReport = that.medulaTedaviRaporlariViewModel.TubeBabyReports.find(o => o.ObjectID.toString() === tubeBabyReportObjectID.toString());
            if (tubeBabyReport) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TubeBabyReport = tubeBabyReport;
            } if (tubeBabyReport != null) {
                let tedaviRaporiIslemKodlariObjectID = tubeBabyReport["TedaviRaporiIslemKodlari"];
                if (tedaviRaporiIslemKodlariObjectID != null && (typeof tedaviRaporiIslemKodlariObjectID === "string")) {
                    let tedaviRaporiIslemKodlari = that.medulaTedaviRaporlariViewModel.TedaviRaporiIslemKodlaris.find(o => o.ObjectID.toString() === tedaviRaporiIslemKodlariObjectID.toString());
                    if (tedaviRaporiIslemKodlari) {
                        tubeBabyReport.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodlari;
                    }
                }
            }
        }
        else {
            this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TubeBabyReport = new TubeBabyReport();
            this.medulaTedaviRaporlariViewModel.TubeBabyReports.push(this.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.TubeBabyReport);
        }
        let thirdDoctorObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["ThirdDoctor"];
        if (thirdDoctorObjectID != null && (typeof thirdDoctorObjectID === "string")) {
            let thirdDoctor = that.medulaTedaviRaporlariViewModel.ResUsers.find(o => o.ObjectID.toString() === thirdDoctorObjectID.toString());
            if (thirdDoctor) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ThirdDoctor = thirdDoctor;
            }
        }
        let secondDoctorObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["SecondDoctor"];
        if (secondDoctorObjectID != null && (typeof secondDoctorObjectID === "string")) {
            let secondDoctor = that.medulaTedaviRaporlariViewModel.ResUsers.find(o => o.ObjectID.toString() === secondDoctorObjectID.toString());
            if (secondDoctor) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.SecondDoctor = secondDoctor;
            }
        }
        let procedureDoctorObjectID = that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.medulaTedaviRaporlariViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ProcedureDoctor = procedureDoctor;
            } this.onlstTabipChanged(that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.ProcedureDoctor);
        }

        if (that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CurrentStateDefID.valueOf() == MedulaTreatmentReport.MedulaTreatmentReportStates.Completed.id) {
            this.ESWTFizyoterapiList.ReadOnly = true;
            this.FizyoterapiList.ReadOnly = true;
            this.lokalizasyonList.ReadOnly = true;
            this.cmbRaporSureTuru.ReadOnly = true;
            this.isNewState = false;
        }
        if (that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.RaporTakipNo != null) {
            this.setReportInfoToGrid();
        }
        if (that.medulaTedaviRaporlariViewModel._MedulaTreatmentReport.CommitteeReport == true) {
            this.labelTabip2 = i18n("M10220", "2.Doktor");
            this.labelTabip3 = i18n("M10289", "3.Doktor");
            this.lstTabip3.Enabled = true;
            this.lstTabip2.Enabled = true;
        }
        else {
            this.labelTabip2 = "";
            this.labelTabip3 = "";
            this.lstTabip3.Enabled = false;
            this.lstTabip2.Enabled = false;
        }

        if (this.enableStartDateBounds == true) {
            this.RaporBaslangicTarihi.Min = this.medulaTedaviRaporlariViewModel.minReportDate;
            this.RaporBaslangicTarihi.Max = this.medulaTedaviRaporlariViewModel.maxReportDate;
        }
    }
    protected async loadReportByID(objectID: Guid) {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";
            let formLoadInput  = { Id: this.ObjectID === null ? Guid.Empty : objectID, Model: this.ActiveIDsModel };
            if (objectID != null) {
                fullApiUrl = this.MedulaTreatmentReportPre_DocumentUrl + '/?id=' + objectID;
            }
            else {
                fullApiUrl = `${this.MedulaTreatmentReportPre_DocumentUrl}/${Guid.Empty}`;
            }

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.post<MedulaTedaviRaporlariViewModel>(fullApiUrl,formLoadInput, MedulaTedaviRaporlariViewModel);
            this._ViewModel = response;


            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
            await this.ReportDiagnosisInstance.getReadOnlyDiagnosis();
            await this.SetButtonVisibility();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
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

    public async LoadForm() {
        let that = this;
        await this.load(MedulaTedaviRaporlariViewModel);

        let promiseArray: Array<Promise<any>> = new Array<any>();
        promiseArray.push(this.FizyoterapiIslemi());
        promiseArray.push(this.GetTedaviTuru());
        promiseArray.push(this.GetVucutBolgesi());
        promiseArray.push(this.ESWTFizyoterapiIslemi());
        promiseArray.push(this.LokalizasyonIslemi());
        this.btnRaporArama.Visible = false;
        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            that.fizyoterapiDefArray = sonuc[0];
            that.tedaviTuruArray = sonuc[1];
            that.vucutBolgesiArray = sonuc[2];
            that.ESWTVucutBolgesiArray = sonuc[2];
            that.ESWTFizyoterapiDefArray = sonuc[3];
            that.LokalizasyonDefArray = sonuc[4];

            that.GenerateFizyoTerapiIslemleriColumns();
            that.GenerateHastaAktifTakipleriColumns();
            that.GenerateTaniColumns();
            that.GenerateESWTIslemleriColumns();
            that.GenerateTasBilgisiIslemleriColumns();
            that.GenerateGridFtrRaporlariColumns();
            that.GenerategridEswlRaporlariColumns();
            that.GenerategridDiyalizRaporlariColumns();
            that.GenerategridEvdiyalizRaporlariColumns();
            that.GenerategridHOTRaporlariColumns();
            that.GenerategridTupBebekRaporlariColumns();
            this.load(MedulaTedaviRaporlariViewModel);
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
        });


        let enableStartDateBounds: string = (await SystemParameterService.GetParameterValue('RAPORBASLANGICTARIHISINIR', 'FALSE'));
        if (enableStartDateBounds === 'TRUE') {
            this.enableStartDateBounds = true;
        }
        else {
            this.enableStartDateBounds = false;
        }

    }

    public GenerateFizyoTerapiIslemleriColumns() {
        let that = this;

        this.FizyoTerapiIslemleriColumns = [
            {
                caption: i18n("M14424", "Fizyoterapi Rapor Kodu"),
                dataField: 'FizyoterapiIslemi',
                lookup: { dataSource: that.fizyoterapiDefArray, valueExpr: 'ItemKey', displayExpr: 'Name' },
                //width: 150,
                allowEditing: true
            },
            {
                caption: i18n("M24187", "Vücut Bölgesi"),
                dataField: 'VucutBolgesi',
                lookup: { dataSource: that.vucutBolgesiArray, valueExpr: 'ItemKey', displayExpr: 'Name' },
                // width: 250,
                allowEditing: true
            },
            {
                caption: i18n("M21489", "Seans Sayısı"),
                dataField: 'SeansSayisi',
                //width: 100,
                allowEditing: true
            },
            {
                caption: i18n("M23037", "Tedavi Türü"),
                dataField: 'TedaviTuru',
                lookup: { dataSource: that.tedaviTuruArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                //width: 200,
                allowEditing: true
            }
        ];
    }


    public GenerateESWTIslemleriColumns() {
        let that = this;

        this.ESWTIslemleriColumns = [
            {
                caption: i18n("M13906", "ESWT Rapor Kodu"),
                dataField: 'FizyoterapiIslemiESWT',
                lookup: { dataSource: that.ESWTFizyoterapiDefArray, valueExpr: 'ItemKey', displayExpr: 'Name' },
                //  width: 200,
                allowEditing: true
            },
            {
                caption: i18n("M24187", "Vücut Bölgesi"),
                dataField: 'VucutBolgesiESWT',
                lookup: { dataSource: that.ESWTVucutBolgesiArray, valueExpr: 'ItemKey', displayExpr: 'Name' },
                // width: 250,
                allowEditing: true
            },
            {
                caption: i18n("M21489", "Seans Sayısı"),
                dataField: 'SeansSayisiESWT',
                //width: 100,
                allowEditing: true
            }
        ];
    }
    public GenerateTasBilgisiIslemleriColumns() {
        let that = this;

        this.TasBilgisiIslemleriColumns = [
            {
                caption: 'Lokalizasyon',
                dataField: 'LokalizasyonKodu',
                lookup: { dataSource: that.LokalizasyonDefArray, valueExpr: 'ItemKey', displayExpr: 'Name' },
                // width: 250,
                allowEditing: true
            },
            {
                caption: i18n("M22864", "Taş Boyutu(mm)"),
                dataField: i18n("M22854", "TasBoyutu"),
                // width: 100,
                allowEditing: true
            }
        ];
    }

    public GenerateHastaAktifTakipleriColumns() {
        let that = this;

        this.HastaAktifTakipleriColumns = [
            {
                caption: i18n("M22659", "Takip No"),
                dataField: 'TakipNo',
                allowEditing: false
                //   width: 100
            },
            {
                caption: i18n("M12059", "Branşı"),
                dataField: 'Brans',
                allowEditing: false
                // width: 250
            },
            {
                caption: i18n("M20586", "Provizyon Tarihi"),
                dataField: 'ProvizyonTarihi',
                dataType: 'date',
                format: 'dd.MM.yyyy',
                allowEditing: false
                //   width: 100
            },
            {
                caption: 'Bağlı Takip No',
                dataField: 'BagliTakipNo',
                allowEditing: false
                // width: 100
            },
            {
                caption: i18n("M23037", "Tedavi Türü"),
                dataField: 'TedaviTuru',
                allowEditing: false
                // width: 100
            }
        ];
    }

    public GenerateTaniColumns() {
        let that = this;

        this.TaniColumns = [
            {
                caption: i18n("M22736", "Tanı"),
                dataField: 'Tani',
                //   width: 300,
                allowEditing: true
            },
            {
                caption: i18n("M14494", "FTR Tanı Grup"),
                dataField: 'FTRTaniGrup',
                allowEditing: false
                //  width: 100
            }
        ];
    }
    public GenerateGridFtrRaporlariColumns() {
        let that = this;

        this.gridFtrRaporlariColumns = [
            {
                caption: i18n("M20855", "Rapor Takip No"),
                dataField: 'TakipNo',
                // width: 100,
                allowEditing: true
            },
            {
                caption: i18n("M20821", "Rapor No"),
                dataField: 'RaporNo',
                allowEditing: false
                // width: 100
            },
            {
                caption: i18n("M20844", "Rapor Sıra No"),
                dataField: 'RaporSiraNo',
                allowEditing: false
                // width: 100
            }, {
                caption: i18n("M22099", "Sonuç Kodu"),
                dataField: 'SonucKodu',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M22103", "Sonuç Mesajı"),
                dataField: 'SonucMesaji',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M24187", "Vücut Bölgesi"),
                dataField: 'VucutBolgesi',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M21489", "Seans Sayısı"),
                dataField: 'Kur',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M20773", "Rapor Başlangıç Tarihi"),
                dataField: 'RaporBaslangicTarihi',
                allowEditing: false
                //width: 100
            },
            {
                "caption": "Sil",
                width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateSil",
            },
            {
                "caption": i18n("M12671", "Detay"),
                // width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateDetail",
            },
            {
                caption: i18n("M24098", "Verildiği Tesis"),
                dataField: i18n("M24096", "VerildigiTesis"),
                allowEditing: false
                // width: 400
            }
        ];
    }

    public GenerategridEswlRaporlariColumns() {
        let that = this;

        this.gridEswlRaporlariColumns = [
            {
                caption: i18n("M20855", "Rapor Takip No"),
                dataField: 'TakipNo',
                //  width: 100,
                allowEditing: true
            },
            {
                caption: i18n("M20821", "Rapor No"),
                dataField: 'RaporNo',
                allowEditing: false
                ///  width: 100
            },
            {
                caption: i18n("M20844", "Rapor Sıra No"),
                dataField: 'RaporSiraNo',
                allowEditing: false
                //   width: 100
            },
            {
                caption: i18n("M22099", "Sonuç Kodu"),
                dataField: 'SonucKodu',
                allowEditing: false
                // width: 100
            },
            {
                caption: i18n("M22103", "Sonuç Mesajı"),
                dataField: 'SonucMesaji',
                allowEditing: false
                //  width: 100
            },
            {
                caption: i18n("M20773", "Rapor Başlangıç Tarihi"),
                dataField: 'RaporBaslangicTarihi',
                allowEditing: false
                // width: 100
            },
            {
                "caption": "Sil",
                width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateSil",
            },
            {
                "caption": i18n("M12671", "Detay"),
                // width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateDetail",
            },
            {
                caption: i18n("M24098", "Verildiği Tesis"),
                dataField: i18n("M24096", "VerildigiTesis"),
                allowEditing: false
                // width: 400
            }
        ];
    }

    public GenerategridDiyalizRaporlariColumns() {
        let that = this;

        this.gridDiyalizRaporlariColumns = [
            {
                caption: i18n("M20855", "Rapor Takip No"),
                dataField: 'TakipNo',
                //  width: 100,
                allowEditing: true
            },
            {
                caption: i18n("M20821", "Rapor No"),
                dataField: 'RaporNo',
                allowEditing: false
                // width: 100
            },
            {
                caption: i18n("M20844", "Rapor Sıra No"),
                dataField: 'RaporSiraNo',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M22099", "Sonuç Kodu"),
                dataField: 'SonucKodu',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M22103", "Sonuç Mesajı"),
                dataField: 'SonucMesaji',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M20773", "Rapor Başlangıç Tarihi"),
                dataField: 'RaporBaslangicTarihi',
                allowEditing: false
                //width: 100
            },
            {
                "caption": "Sil",
                width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateSil",
            },
            {
                "caption": i18n("M12671", "Detay"),
                //width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateDetail",
            },
            {
                caption: i18n("M24098", "Verildiği Tesis"),
                dataField: i18n("M24096", "VerildigiTesis"),
                allowEditing: false
                //width: 400
            }
        ];
    }
    public GenerategridEvdiyalizRaporlariColumns() {
        let that = this;

        this.gridEvdiyalizRaporlariColumns = [
            {
                caption: i18n("M20855", "Rapor Takip No"),
                dataField: 'TakipNo',
                //  width: 100,
                allowEditing: true
            },
            {
                caption: i18n("M20821", "Rapor No"),
                dataField: 'RaporNo',
                allowEditing: false,
                // width: 100
            },
            {
                caption: i18n("M20844", "Rapor Sıra No"),
                dataField: 'RaporSiraNo',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M22099", "Sonuç Kodu"),
                dataField: 'SonucKodu',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M22103", "Sonuç Mesajı"),
                dataField: 'SonucMesaji',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M20773", "Rapor Başlangıç Tarihi"),
                dataField: 'RaporBaslangicTarihi',
                allowEditing: false
                //width: 100
            },
            {
                "caption": "Sil",
                width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateSil",
            },
            {
                "caption": i18n("M12671", "Detay"),
                //width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateDetail",
            },
            {
                caption: i18n("M24098", "Verildiği Tesis"),
                dataField: i18n("M24096", "VerildigiTesis"),
                allowEditing: false
                // width: 400
            }
        ];
    }
    public GenerategridHOTRaporlariColumns() {
        let that = this;

        this.gridHOTRaporlariColumns = [
            {
                caption: i18n("M20855", "Rapor Takip No"),
                dataField: 'TakipNo',
                //  width: 100,
                allowEditing: true
            },
            {
                caption: i18n("M20821", "Rapor No"),
                dataField: 'RaporNo',
                allowEditing: false
                // width: 100
            },
            {
                caption: i18n("M20844", "Rapor Sıra No"),
                dataField: 'RaporSiraNo',
                allowEditing: false
                // width: 100
            },
            {
                caption: i18n("M22099", "Sonuç Kodu"),
                dataField: 'SonucKodu',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M22103", "Sonuç Mesajı"),
                dataField: 'SonucMesaji',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M20773", "Rapor Başlangıç Tarihi"),
                dataField: 'RaporBaslangicTarihi',
                allowEditing: false
                //   width: 100
            },
            {
                "caption": "Sil",
                width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateSil",
            },
            {
                "caption": i18n("M12671", "Detay"),
                //width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateDetail",
            },
            {
                caption: i18n("M24098", "Verildiği Tesis"),
                dataField: i18n("M24096", "VerildigiTesis"),
                allowEditing: false
                //width: 400
            }
        ];
    }
    public GenerategridTupBebekRaporlariColumns() {
        let that = this;

        this.gridTupBebekRaporlariColumns = [
            {
                caption: i18n("M20855", "Rapor Takip No"),
                dataField: 'TakipNo',
                // width: 100,
                allowEditing: true
            },
            {
                caption: i18n("M20821", "Rapor No"),
                dataField: 'RaporNo',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M20844", "Rapor Sıra No"),
                dataField: 'RaporSiraNo',
                allowEditing: false
                // width: 100
            },
            {
                caption: i18n("M22099", "Sonuç Kodu"),
                dataField: 'SonucKodu',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M22103", "Sonuç Mesajı"),
                dataField: 'SonucMesaji',
                allowEditing: false
                //width: 100
            },
            {
                caption: i18n("M20773", "Rapor Başlangıç Tarihi"),
                dataField: 'RaporBaslangicTarihi',
                allowEditing: false
                //width: 100
            },
            {
                "caption": "Sil",
                width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateSil",
            },
            {
                "caption": i18n("M12671", "Detay"),
                //width: 75,
                allowSorting: false,
                cellTemplate: "linkCellTemplateDetail",
            },
            {
                caption: i18n("M24098", "Verildiği Tesis"),
                dataField: i18n("M24096", "VerildigiTesis"),
                allowEditing: false
                //width: 400
            }
        ];
    }


    public async Tani(): Promise<any> {
        let listDefName: string = "DiagnosisListDefinition";
        if (!this.taniCache) {
            this.taniCache = await this.httpService.get("/api/MedulaTreatmentReportService/GetListDefValues?listDefName=" + listDefName + '&listFilterExpression=' + '&linkFilterExpression=');
            return this.taniCache;
        }
        else {
            return this.taniCache;
        }
    }

    public async GetTedaviTuru(): Promise<any> {

        if (!this.tedaviTuruCache) {
            this.tedaviTuruCache = await this.httpService.get("api/InvoiceDefinitionApi/GetTedaviTuru");
            return this.tedaviTuruCache;
        }
        else {
            return this.tedaviTuruCache;
        }
    }
    public async FizyoterapiIslemi(): Promise<any> {
        let listDefName: string = "TedaviRaporlariIslemListDefinition";
        let listFilterExpression: string = "TEDAVIRAPORUTURUKODU = '5'";
        if (!this.fizyoterapiDefCache) {
            this.fizyoterapiDefCache = await this.httpService.get("/api/MedulaTreatmentReportService/GetListDefValues?listDefName=" + listDefName + '&listFilterExpression=' + listFilterExpression + '&linkFilterExpression=');
            return this.fizyoterapiDefCache;
        }
        else {
            return this.fizyoterapiDefCache;
        }
    }
    public async GetVucutBolgesi(): Promise<any> {
        let listDefName: string = "FTRVucutBolgesiTTObjectListDefinition";
        if (!this.vucutBolgesiCache) {
            this.vucutBolgesiCache = await this.httpService.get("/api/MedulaTreatmentReportService/GetListDefValues?listDefName=" + listDefName + '&listFilterExpression=' + '&linkFilterExpression=');
            return this.vucutBolgesiCache;
        }
        else {
            return this.vucutBolgesiCache;
        }
    }
    public async ESWTFizyoterapiIslemi(): Promise<any> {
        let listDefName: string = "TedaviRaporlariIslemListDefinition";
        let listFilterExpression: string = "TEDAVIRAPORUTURUKODU = '3'";
        if (!this.ESWTFizyoterapiDefCache) {
            this.ESWTFizyoterapiDefCache = await this.httpService.get("/api/MedulaTreatmentReportService/GetListDefValues?listDefName=" + listDefName + '&listFilterExpression=' + listFilterExpression + '&linkFilterExpression=');
            return this.ESWTFizyoterapiDefCache;
        }
        else {
            return this.ESWTFizyoterapiDefCache;
        }
    }

    public async LokalizasyonIslemi(): Promise<any> {
        let listDefName: string = "TasLokalizasyonListDefinition";
        if (!this.LokalizasyonDefCache) {
            this.LokalizasyonDefCache = await this.httpService.get("/api/MedulaTreatmentReportService/GetListDefValues?listDefName=" + listDefName + '&listFilterExpression=' + '&linkFilterExpression=');
            return this.LokalizasyonDefCache;
        }
        else {
            return this.LokalizasyonDefCache;
        }
    }
    fizyoterapiSelected(data: any) {
        if (data != null) {
            let that = this;
            let fizyoterapiIslemi: FizyoterapiIslemleriListModel = new FizyoterapiIslemleriListModel();
            fizyoterapiIslemi.FizyoterapiIslemi = data.ObjectID;
            fizyoterapiIslemi.TedaviTuru = this._ViewModel.TedaviTuru;
            that.medulaTedaviRaporlariViewModel.FizyoterapiIslemleriList.push(fizyoterapiIslemi);
        }
    }
    lokalizasyonSelected(data: any) {
        if (data != null) {
            let that = this;
            let tasBilgisiIslemi: TasBilgisiIslemleriListModel = new TasBilgisiIslemleriListModel();
            tasBilgisiIslemi.LokalizasyonKodu = data.tasLokalizasyonKodu;
            tasBilgisiIslemi.Lokalizasyon = data.ObjectID;
            that.medulaTedaviRaporlariViewModel.TasBilgisiIslemleriList.push(tasBilgisiIslemi);
        }
    }
    ESWTfizyoterapiSelected(data: any) {
        if (data != null) {
            let that = this;
            let ESWTfizyoterapiIslemi: ESWTIslemleriListModel = new ESWTIslemleriListModel();
            ESWTfizyoterapiIslemi.FizyoterapiIslemiESWT = data.ObjectID;
            that.medulaTedaviRaporlariViewModel.ESWTIslemleriList.push(ESWTfizyoterapiIslemi);
        }
    }

    //taniSelected(data: any) {
    //    if (data != null) {
    //        let that = this;
    //        let tani: TaniGridListModel = new TaniGridListModel();
    //        tani.Tani = data.Code + "-" + data.Name;
    //        tani.TaniKodu = data.Code;
    //        tani.FTRTaniGrup = FTRDiagnosisGroupEnum[data.FtrDiagnoseGroup];
    //        that.medulaTedaviRaporlariViewModel.TaniGridList.push(tani);
    //    }
    //}
    public onTabipChanged(event): void {
        if (event != null) {
            if (this.doctor != event) {
                this.doctor = event;
            }
        }
    }
    public onTabip2Changed(event): void {
        if (event != null) {
            if (this.doctor2 != event) {
                this.doctor2 = event;
            }
        }
    }
    public onTabip3Changed(event): void {
        if (event != null) {
            if (this.doctor3 != event) {
                this.doctor3 = event;
            }
        }
    }
    public onlstEswlRaporKoduChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.ESWLReport != null && this._MedulaTreatmentReport.ESWLReport.TedaviRaporiIslemKodlari != event) {
                this._MedulaTreatmentReport.ESWLReport.TedaviRaporiIslemKodlari = event;
            }
        }
    }
    public onlstBobrekBilgisiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.ESWLReport != null && this._MedulaTreatmentReport.ESWLReport.Bobrek != event) {
                this._MedulaTreatmentReport.ESWLReport.Bobrek = event;
            }
        }
    }
    public ontxtEswlSeansSayisiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.ESWLReport != null && this._MedulaTreatmentReport.ESWLReport.NumberOfSessions != event) {
                this._MedulaTreatmentReport.ESWLReport.NumberOfSessions = event;
            }
        }
    }
    public ontxtTasSayisiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.ESWLReport != null && this._MedulaTreatmentReport.ESWLReport.NumberOfStone != event) {
                this._MedulaTreatmentReport.ESWLReport.NumberOfStone = event;
            }
        }
    }
    public ontxtHOTSeansSayisiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.HBTReport != null && this._MedulaTreatmentReport.HBTReport.NumberOfSessions != event) {
                this._MedulaTreatmentReport.HBTReport.NumberOfSessions = event;
            }
        }
    }

    public ontxtHOTTedaviSuresiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.HBTReport != null && this._MedulaTreatmentReport.HBTReport.TreatmenDuration != event) {
                this._MedulaTreatmentReport.HBTReport.TreatmenDuration = event;
            }
        }
    }

    public oncmbTupBebekTuruChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.TubeBabyReport != null && this._MedulaTreatmentReport.TubeBabyReport.TubeBabyReportType != event) {
                this._MedulaTreatmentReport.TubeBabyReport.TubeBabyReportType = event;
            }
        }
    }
    public onlstTupBebekRaporKoduChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.TubeBabyReport != null && this._MedulaTreatmentReport.TubeBabyReport.TedaviRaporiIslemKodlari != event) {
                this._MedulaTreatmentReport.TubeBabyReport.TedaviRaporiIslemKodlari = event;
            }
        }
    }
    public onlstDiyalizRaporKoduChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.DialysisReport != null && this._MedulaTreatmentReport.DialysisReport.TedaviRaporiIslemKodlari != event) {
                this._MedulaTreatmentReport.DialysisReport.TedaviRaporiIslemKodlari = event;
            }
        }
    }
    public ontxtDiyalizSeansSayisiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.DialysisReport != null && this._MedulaTreatmentReport.DialysisReport.NumberOfSessions != event) {
                this._MedulaTreatmentReport.DialysisReport.NumberOfSessions = event;
            }
        }
    }
    public oncmbDiyalizSeansGunChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.DialysisReport != null && this._MedulaTreatmentReport.DialysisReport.DialysisSessionsDay != event) {
                this._MedulaTreatmentReport.DialysisReport.DialysisSessionsDay = event;
            }
        }
    }
    public onchkRefakatVarYokChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.DialysisReport != null && this._MedulaTreatmentReport.DialysisReport.IsCompanion != event) {
                this._MedulaTreatmentReport.DialysisReport.IsCompanion = event;
            }
        }
    }
    public onlstEvHemodiyalizRaporKoduChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.HomeHemodialysisReport != null && this._MedulaTreatmentReport.HomeHemodialysisReport.TedaviRaporiIslemKodlari != event) {
                this._MedulaTreatmentReport.HomeHemodialysisReport.TedaviRaporiIslemKodlari = event;
            }
        }
    }
    public ontxtEvHemodiyalizSeansSayisiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.HomeHemodialysisReport != null && this._MedulaTreatmentReport.HomeHemodialysisReport.NumberOfSessions != event) {
                this._MedulaTreatmentReport.HomeHemodialysisReport.NumberOfSessions = event;
            }
        }
    }

    public ontxtEvHemodiyalizTedaviSuresiChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.HomeHemodialysisReport != null && this._MedulaTreatmentReport.HomeHemodialysisReport.TreatmenDuration != event) {
                this._MedulaTreatmentReport.HomeHemodialysisReport.TreatmenDuration = event;
            }
        }
    }
    public oncmbEvHemodiyalizSeansGunChanged(event): void {
        if (event != null) {
            if (this._MedulaTreatmentReport != null &&
                this._MedulaTreatmentReport.HomeHemodialysisReport != null && this._MedulaTreatmentReport.HomeHemodialysisReport.DialysisSessionsDay != event) {
                this._MedulaTreatmentReport.HomeHemodialysisReport.DialysisSessionsDay = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.cmbOzelDurum, "Value", this.__ttObject, "FTRReport.SpacialCase");
        redirectProperty(this.txtTasSayisi, "Text", this.__ttObject, "ESWLReport.NumberOfStone");
        redirectProperty(this.txtEswlSeansSayisi, "Text", this.__ttObject, "ESWLReport.NumberOfSessions");
        redirectProperty(this.chkRefakatVarYok, "Value", this.__ttObject, "DialysisReport.IsCompanion");
        redirectProperty(this.txtDiyalizSeansSayisi, "Text", this.__ttObject, "DialysisReport.NumberOfSessions");
        redirectProperty(this.cmbDiyalizSeansGun, "Value", this.__ttObject, "DialysisReport.DialysisSessionsDay");
        redirectProperty(this.txtEvHemodiyalizSeansSayisi, "Text", this.__ttObject, "HomeHemodialysisReport.NumberOfSessions");
        redirectProperty(this.txtEvHemodiyalizTedaviSuresi, "Text", this.__ttObject, "HomeHemodialysisReport.TreatmenDuration");
        redirectProperty(this.cmbEvHemodiyalizSeansGun, "Value", this.__ttObject, "HomeHemodialysisReport.DialysisSessionsDay");
        redirectProperty(this.txtHOTSeansSayisi, "Text", this.__ttObject, "HBTReport.NumberOfSessions");
        redirectProperty(this.txtHOTTedaviSuresi, "Text", this.__ttObject, "HBTReport.TreatmenDuration");
        redirectProperty(this.cmbTupBebekTuru, "Value", this.__ttObject, "TubeBabyReport.TubeBabyReportType");
        redirectProperty(this.txtRaporTakipNo, "Text", this.__ttObject, "RaporTakipNo");
        redirectProperty(this.cmbRaporTuru, "Value", this.__ttObject, "TedaviRaporTuru");
        redirectProperty(this.chkFtrHeyetRaporu, "Value", this.__ttObject, "CommitteeReport");
        redirectProperty(this.RaporBaslangicTarihi, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.RaporBitisTarihi, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.SonucKodu, "Text", this.__ttObject, "SonucKodu");
        redirectProperty(this.SonucAciklamasi, "Text", this.__ttObject, "SonucAciklamasi");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public async SetFormReadOnlyControls() {
        this.txtResult.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.cmbOzelDurum.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.chkOzelDurum.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtEswlSeansSayisi.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtTasSayisi.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.lstEswlRaporKodu.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.cmbDiyalizSeansGun.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtDiyalizSeansSayisi.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.chkRefakatVarYok.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.cmbEvHemodiyalizSeansGun.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtEvHemodiyalizTedaviSuresi.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtEvHemodiyalizSeansSayisi.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtHOTTedaviSuresi.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtHOTSeansSayisi.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.cmbTupBebekTuru.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtRaporTakipNo.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.Description.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.cmbReportType.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtReportChasing.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtReportRow.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.btnSearchReportInfo.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.cmbRBReportType.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtRBReportChasing.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.txtRBReportRow.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.chkFtrHeyetRaporu.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.lstTabip2.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.btnRaporArama.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.lstTabip.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.RaporBaslangicTarihi.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.cmbRaporTuru.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.cmbRaporSureTuru.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.chkRaporKaydet.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.chkSearchReportInfo.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.chkSearchChasing.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.chkSearchTCKNo.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.ttgroupbox1.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.cmdSearchPatient.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.gridEswtIslemi.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.FizyoterapiIslemiESWT.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.VucutBolgesiESWT.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
        this.SeansSayisiESWT.ReadOnly = this.medulaTedaviRaporlariViewModel.ReadOnly;
    }
    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 0;

        this.tttabAramaIslemleri = new TTVisual.TTTabPage();
        this.tttabAramaIslemleri.DisplayIndex = 0;
        this.tttabAramaIslemleri.TabIndex = 0;
        this.tttabAramaIslemleri.Text = i18n("M15147", "Hasta Arama İşlemleri");
        this.tttabAramaIslemleri.Name = "tttabAramaIslemleri";

        this.tttabRaporlar = new TTVisual.TTTabControl();
        this.tttabRaporlar.Name = "tttabRaporlar";
        this.tttabRaporlar.TabIndex = 2;
        this.tttabRaporlar.Visible = false;

        this.tttabFtrRaporlari = new TTVisual.TTTabPage();
        this.tttabFtrRaporlari.DisplayIndex = 0;
        this.tttabFtrRaporlari.TabIndex = 0;
        this.tttabFtrRaporlari.Text = i18n("M14491", "FTR Raporları");
        this.tttabFtrRaporlari.Name = "tttabFtrRaporlari";


        this.tttabTumRaporlar = new TTVisual.TTTabPage();
        this.tttabTumRaporlar.DisplayIndex = 1;
        this.tttabTumRaporlar.TabIndex = 1;
        this.tttabTumRaporlar.Text = i18n("M20887", "Raporlar");
        this.tttabTumRaporlar.Name = "tttabTumRaporlar";

        this.txtResult = new TTVisual.TTRichTextBoxControl();
        this.txtResult.Name = "txtResult";
        this.txtResult.TabIndex = 4;
        this.txtResult.Visible = false;


        this.tttabEswlRaporlari = new TTVisual.TTTabPage();
        this.tttabEswlRaporlari.DisplayIndex = 2;
        this.tttabEswlRaporlari.TabIndex = 2;
        this.tttabEswlRaporlari.Text = i18n("M13898", "ESWL Raporları");
        this.tttabEswlRaporlari.Name = "tttabEswlRaporlari";

        this.tttabDiyalizRaporlari = new TTVisual.TTTabPage();
        this.tttabDiyalizRaporlari.DisplayIndex = 3;
        this.tttabDiyalizRaporlari.TabIndex = 3;
        this.tttabDiyalizRaporlari.Text = i18n("M13020", "Diyaliz Raporları");
        this.tttabDiyalizRaporlari.Name = "tttabDiyalizRaporlari";



        this.tttabEvHemodiyalizRaporlari = new TTVisual.TTTabPage();
        this.tttabEvHemodiyalizRaporlari.DisplayIndex = 4;
        this.tttabEvHemodiyalizRaporlari.TabIndex = 4;
        this.tttabEvHemodiyalizRaporlari.Text = i18n("M13976", "Ev Hemodiyaliz Raporları");
        this.tttabEvHemodiyalizRaporlari.Name = "tttabEvHemodiyalizRaporlari";


        this.tttabHOTRaporlari = new TTVisual.TTTabPage();
        this.tttabHOTRaporlari.DisplayIndex = 6;
        this.tttabHOTRaporlari.TabIndex = 6;
        this.tttabHOTRaporlari.Text = i18n("M15590", "HBT Raporları");
        this.tttabHOTRaporlari.Name = "tttabHOTRaporlari";

        this.tttabReportSave = new TTVisual.TTTabPage();
        this.tttabReportSave.DisplayIndex = 0;
        this.tttabReportSave.TabIndex = 3;
        this.tttabReportSave.Text = i18n("M20815", "Rapor Kaydet");
        this.tttabReportSave.Name = "tttabReportSave";

        this.tttabTedaviRaporlariKaydet = new TTVisual.TTTabControl();
        this.tttabTedaviRaporlariKaydet.Name = "tttabTedaviRaporlariKaydet";
        this.tttabTedaviRaporlariKaydet.TabIndex = 0;

        this.tttabFtrRaporKaydet = new TTVisual.TTTabPage();
        this.tttabFtrRaporKaydet.DisplayIndex = 0;
        this.tttabFtrRaporKaydet.TabIndex = 0;
        this.tttabFtrRaporKaydet.Text = i18n("M14490", "FTR Rapor Kaydet");
        this.tttabFtrRaporKaydet.Visible = false;
        this.tttabFtrRaporKaydet.Name = "tttabFtrRaporKaydet";

        this.lblOzelDurum = new TTVisual.TTLabel();
        this.lblOzelDurum.Text = i18n("M20080", "Özel Durum");
        this.lblOzelDurum.Name = "lblOzelDurum";
        this.lblOzelDurum.TabIndex = 4;

        this.cmbOzelDurum = new TTVisual.TTEnumComboBox();
        this.cmbOzelDurum.DataTypeName = "MedulaRaporOzelDurumEnum";
        this.cmbOzelDurum.Name = "cmbOzelDurum";
        this.cmbOzelDurum.TabIndex = 3;


        this.chkOzelDurum = new TTVisual.TTCheckBox();
        this.chkOzelDurum.Value = false;
        this.chkOzelDurum.Text = i18n("M20081", "Özel Durum (SUT 2.4.4.F-2 - ilave 30 seans raporu kaydedebilmek için)");
        this.chkOzelDurum.Name = "chkOzelDurum";
        this.chkOzelDurum.TabIndex = 2;
        this.chkOzelDurum.Visible = false;


        this.btnFtrIstek = new TTVisual.TTButton();
        this.btnFtrIstek.Text = i18n("M14484", "FTR İstek Başlat");
        this.btnFtrIstek.Name = "btnFtrIstek";
        this.btnFtrIstek.TabIndex = 1;
        this.btnFtrIstek.Visible = false;

        //this.TaniListesi = new TTVisual.TTObjectListBox();
        //this.TaniListesi.ListDefName = "DiagnosisListDefinition";
        //this.TaniListesi.Name = "TaniListesi";

        this.FizyoterapiList = new TTVisual.TTObjectListBox();
        this.FizyoterapiList.ListDefName = "TedaviRaporlariIslemListDefinition";
        this.FizyoterapiList.ListFilterExpression = "TEDAVIRAPORUTURUKODU='5'";
        this.FizyoterapiList.Name = i18n("M14430", "FizyoterapiList");


        this.ESWTFizyoterapiList = new TTVisual.TTObjectListBox();
        this.ESWTFizyoterapiList.ListDefName = "TedaviRaporlariIslemListDefinition";
        this.ESWTFizyoterapiList.ListFilterExpression = "TEDAVIRAPORUTURUKODU='3'";
        this.ESWTFizyoterapiList.Name = "ESWTFizyoterapiList";


        this.lokalizasyonList = new TTVisual.TTObjectListBox();
        this.lokalizasyonList.ListDefName = "TasLokalizasyonListDefinition";
        this.lokalizasyonList.Name = "lokalizasyonList";

        this.tttabESWTRaporKaydet = new TTVisual.TTTabPage();
        this.tttabESWTRaporKaydet.DisplayIndex = 1;
        this.tttabESWTRaporKaydet.TabIndex = 1;
        this.tttabESWTRaporKaydet.Text = i18n("M13905", "ESWT Rapor Kaydet");
        this.tttabESWTRaporKaydet.Visible = false;
        this.tttabESWTRaporKaydet.Name = "tttabESWTRaporKaydet";

        this.tttabESWLRaporKaydet = new TTVisual.TTTabPage();
        this.tttabESWLRaporKaydet.DisplayIndex = 2;
        this.tttabESWLRaporKaydet.TabIndex = 2;
        this.tttabESWLRaporKaydet.Text = i18n("M13896", "ESWL Rapor Kaydet");
        this.tttabESWLRaporKaydet.Visible = false;
        this.tttabESWLRaporKaydet.Name = "tttabESWLRaporKaydet";

        this.lstBobrekBilgisi = new TTVisual.TTObjectListBox();
        this.lstBobrekBilgisi.ListDefName = "BobrekListDefinition";
        this.lstBobrekBilgisi.Name = "lstBobrekBilgisi";
        this.lstBobrekBilgisi.TabIndex = 9;

        this.lblBobrekBilgisi = new TTVisual.TTLabel();
        this.lblBobrekBilgisi.Text = i18n("M12005", "Böbrek Bilgisi");
        this.lblBobrekBilgisi.Name = "lblBobrekBilgisi";
        this.lblBobrekBilgisi.TabIndex = 8;

        this.txtEswlSeansSayisi = new TTVisual.TTTextBox();
        this.txtEswlSeansSayisi.Name = "txtEswlSeansSayisi";
        this.txtEswlSeansSayisi.TabIndex = 7;


        this.lblEswlSeansSayisi = new TTVisual.TTLabel();
        this.lblEswlSeansSayisi.Text = i18n("M21489", "Seans Sayısı");
        this.lblEswlSeansSayisi.Name = "lblEswlSeansSayisi";
        this.lblEswlSeansSayisi.TabIndex = 6;

        this.txtTasSayisi = new TTVisual.TTTextBox();
        this.txtTasSayisi.Name = "txtTasSayisi";
        this.txtTasSayisi.TabIndex = 5;


        this.lblTasSayisi = new TTVisual.TTLabel();
        this.lblTasSayisi.Text = i18n("M22882", "Taş Sayısı");
        this.lblTasSayisi.Name = "lblTasSayisi";
        this.lblTasSayisi.TabIndex = 4;

        this.lstEswlRaporKodu = new TTVisual.TTObjectListBox();
        this.lstEswlRaporKodu.ListFilterExpression = "TEDAVIRAPORUTURUKODU='6'";
        this.lstEswlRaporKodu.ListDefName = "TedaviRaporlariIslemListDefinition";
        this.lstEswlRaporKodu.Name = "lstEswlRaporKodu";
        this.lstEswlRaporKodu.TabIndex = 3;



        this.lblEswlRaporKodu = new TTVisual.TTLabel();
        this.lblEswlRaporKodu.Text = i18n("M13897", "ESWL Rapor Kodu");
        this.lblEswlRaporKodu.Name = "lblEswlRaporKodu";
        this.lblEswlRaporKodu.TabIndex = 0;

        this.tttabDiyalizRaporKaydet = new TTVisual.TTTabPage();
        this.tttabDiyalizRaporKaydet.DisplayIndex = 3;
        this.tttabDiyalizRaporKaydet.TabIndex = 3;
        this.tttabDiyalizRaporKaydet.Text = i18n("M13018", "Diyaliz Rapor Kaydet");
        this.tttabDiyalizRaporKaydet.Visible = false;
        this.tttabDiyalizRaporKaydet.Name = "tttabDiyalizRaporKaydet";

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M21478", "Seans Gün");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 6;

        this.cmbDiyalizSeansGun = new TTVisual.TTEnumComboBox();
        this.cmbDiyalizSeansGun.DataTypeName = i18n("M13036", "DiyalizSeansGunEnum");
        this.cmbDiyalizSeansGun.Name = "cmbDiyalizSeansGun";
        this.cmbDiyalizSeansGun.TabIndex = 5;


        this.lblDiyalizSeansSayisi = new TTVisual.TTLabel();
        this.lblDiyalizSeansSayisi.Text = i18n("M21489", "Seans Sayısı");
        this.lblDiyalizSeansSayisi.Name = "lblDiyalizSeansSayisi";
        this.lblDiyalizSeansSayisi.TabIndex = 4;

        this.txtDiyalizSeansSayisi = new TTVisual.TTTextBox();
        this.txtDiyalizSeansSayisi.Name = "txtDiyalizSeansSayisi";
        this.txtDiyalizSeansSayisi.TabIndex = 3;


        this.lblDiyalizRaporKodu = new TTVisual.TTLabel();
        this.lblDiyalizRaporKodu.Text = i18n("M13019", "Diyaliz Rapor Kodu");
        this.lblDiyalizRaporKodu.Name = "lblDiyalizRaporKodu";
        this.lblDiyalizRaporKodu.TabIndex = 2;

        this.lstDiyalizRaporKodu = new TTVisual.TTObjectListBox();
        this.lstDiyalizRaporKodu.ListFilterExpression = "TEDAVIRAPORUTURUKODU='1'";
        this.lstDiyalizRaporKodu.ListDefName = "TedaviRaporlariIslemListDefinition";
        this.lstDiyalizRaporKodu.Name = "lstDiyalizRaporKodu";
        this.lstDiyalizRaporKodu.TabIndex = 1;

        this.chkRefakatVarYok = new TTVisual.TTCheckBox();
        this.chkRefakatVarYok.Value = false;
        this.chkRefakatVarYok.Title = i18n("M20987", "Refakat Var");
        this.chkRefakatVarYok.Name = "chkRefakatVarYok";
        this.chkRefakatVarYok.TabIndex = 0;


        this.tttabEvHemoDiyalizRaporKaydet = new TTVisual.TTTabPage();
        this.tttabEvHemoDiyalizRaporKaydet.DisplayIndex = 4;
        this.tttabEvHemoDiyalizRaporKaydet.TabIndex = 4;
        this.tttabEvHemoDiyalizRaporKaydet.Text = i18n("M13981", "Ev Hemodiyalizi Raporu Kaydet");
        this.tttabEvHemoDiyalizRaporKaydet.Visible = false;
        this.tttabEvHemoDiyalizRaporKaydet.Name = "tttabEvHemoDiyalizRaporKaydet";

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M21478", "Seans Gün");
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 7;

        this.cmbEvHemodiyalizSeansGun = new TTVisual.TTEnumComboBox();
        this.cmbEvHemodiyalizSeansGun.DataTypeName = i18n("M13036", "DiyalizSeansGunEnum");
        this.cmbEvHemodiyalizSeansGun.Name = "cmbEvHemodiyalizSeansGun";
        this.cmbEvHemodiyalizSeansGun.TabIndex = 6;


        this.txtEvHemodiyalizTedaviSuresi = new TTVisual.TTTextBox();
        this.txtEvHemodiyalizTedaviSuresi.Name = "txtEvHemodiyalizTedaviSuresi";
        this.txtEvHemodiyalizTedaviSuresi.TabIndex = 5;


        this.lblEvHemodiyalizTedaviSuresi = new TTVisual.TTLabel();
        this.lblEvHemodiyalizTedaviSuresi.Text = i18n("M23027", "Tedavi Süresi");
        this.lblEvHemodiyalizTedaviSuresi.Name = "lblEvHemodiyalizTedaviSuresi";
        this.lblEvHemodiyalizTedaviSuresi.TabIndex = 4;

        this.txtEvHemodiyalizSeansSayisi = new TTVisual.TTTextBox();
        this.txtEvHemodiyalizSeansSayisi.Name = "txtEvHemodiyalizSeansSayisi";
        this.txtEvHemodiyalizSeansSayisi.TabIndex = 3;


        this.lblEvHemodiyalizSeansSayisi = new TTVisual.TTLabel();
        this.lblEvHemodiyalizSeansSayisi.Text = i18n("M21489", "Seans Sayısı");
        this.lblEvHemodiyalizSeansSayisi.Name = "lblEvHemodiyalizSeansSayisi";
        this.lblEvHemodiyalizSeansSayisi.TabIndex = 2;

        this.lblEvHemodiyalizRaporKodu = new TTVisual.TTLabel();
        this.lblEvHemodiyalizRaporKodu.Text = i18n("M13978", "Ev Hemodiyalizi Kodu");
        this.lblEvHemodiyalizRaporKodu.Name = "lblEvHemodiyalizRaporKodu";
        this.lblEvHemodiyalizRaporKodu.TabIndex = 1;

        this.lstEvHemodiyalizRaporKodu = new TTVisual.TTObjectListBox();
        this.lstEvHemodiyalizRaporKodu.ListFilterExpression = "TEDAVIRAPORUTURUKODU='8'";
        this.lstEvHemodiyalizRaporKodu.ListDefName = "TedaviRaporlariIslemListDefinition";
        this.lstEvHemodiyalizRaporKodu.Name = "lstEvHemodiyalizRaporKodu";
        this.lstEvHemodiyalizRaporKodu.TabIndex = 0;

        this.tttabHOTRaporKaydet = new TTVisual.TTTabPage();
        this.tttabHOTRaporKaydet.DisplayIndex = 5;
        this.tttabHOTRaporKaydet.TabIndex = 5;
        this.tttabHOTRaporKaydet.Text = i18n("M15589", "HBT Rapor Kaydet");
        this.tttabHOTRaporKaydet.Name = "tttabHOTRaporKaydet";

        this.txtHOTTedaviSuresi = new TTVisual.TTTextBox();
        this.txtHOTTedaviSuresi.Name = "txtHOTTedaviSuresi";
        this.txtHOTTedaviSuresi.TabIndex = 5;


        this.lblHOTTedaviSuresi = new TTVisual.TTLabel();
        this.lblHOTTedaviSuresi.Text = i18n("M23027", "Tedavi Süresi");
        this.lblHOTTedaviSuresi.Name = "lblHOTTedaviSuresi";
        this.lblHOTTedaviSuresi.TabIndex = 4;


        this.txtHOTSeansSayisi = new TTVisual.TTTextBox();
        this.txtHOTSeansSayisi.Name = "txtHOTSeansSayisi";
        this.txtHOTSeansSayisi.TabIndex = 3;


        this.lblHOTSeansSayisi = new TTVisual.TTLabel();
        this.lblHOTSeansSayisi.Text = i18n("M21489", "Seans Sayısı");
        this.lblHOTSeansSayisi.Name = "lblHOTSeansSayisi";
        this.lblHOTSeansSayisi.TabIndex = 2;

        this.tttabTupBebekRaporKaydet = new TTVisual.TTTabPage();
        this.tttabTupBebekRaporKaydet.DisplayIndex = 6;
        this.tttabTupBebekRaporKaydet.TabIndex = 6;
        this.tttabTupBebekRaporKaydet.Text = i18n("M23665", "Tüp Bebek Rapor Kaydet");
        this.tttabTupBebekRaporKaydet.Visible = false;
        this.tttabTupBebekRaporKaydet.Name = "tttabTupBebekRaporKaydet";

        this.cmbTupBebekTuru = new TTVisual.TTEnumComboBox();
        this.cmbTupBebekTuru.DataTypeName = "TupBebekRaporTuruEnum";
        this.cmbTupBebekTuru.Name = "cmbTupBebekTuru";
        this.cmbTupBebekTuru.TabIndex = 3;


        this.lblTupBebekTuru = new TTVisual.TTLabel();
        this.lblTupBebekTuru.Text = i18n("M23667", "Tüp Bebek Rapor Turu");
        this.lblTupBebekTuru.Name = "lblTupBebekTuru";
        this.lblTupBebekTuru.TabIndex = 2;

        this.lstTupBebekRaporKodu = new TTVisual.TTObjectListBox();
        this.lstTupBebekRaporKodu.ListFilterExpression = "TEDAVIRAPORUTURUKODU='4'";
        this.lstTupBebekRaporKodu.ListDefName = "TedaviRaporlariIslemListDefinition";
        this.lstTupBebekRaporKodu.Name = "lstTupBebekRaporKodu";
        this.lstTupBebekRaporKodu.TabIndex = 1;

        this.lblTupBebekRaporKodu = new TTVisual.TTLabel();
        this.lblTupBebekRaporKodu.Text = i18n("M23666", "Tüp Bebek Rapor Kodu");
        this.lblTupBebekRaporKodu.Name = "lblTupBebekRaporKodu";
        this.lblTupBebekRaporKodu.TabIndex = 0;

        this.gridTani = new TTVisual.TTGrid();
        this.gridTani.Name = "gridTani";
        this.gridTani.TabIndex = 1;

        this.lstTani = new TTVisual.TTListBoxColumn();
        this.lstTani.ListDefName = "DiagnosisListDefinition";
        this.lstTani.DisplayIndex = 0;
        this.lstTani.HeaderText = i18n("M22736", "Tanı");
        this.lstTani.Name = "lstTani";
        this.lstTani.Width = 230;

        this.FTRTaniGrubu = new TTVisual.TTTextBoxColumn();
        this.FTRTaniGrubu.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.FTRTaniGrubu.DisplayIndex = 1;
        this.FTRTaniGrubu.HeaderText = i18n("M14493", "FTR Tanı Grubu");
        this.FTRTaniGrubu.Name = "FTRTaniGrubu";
        this.FTRTaniGrubu.ReadOnly = true;
        this.FTRTaniGrubu.Width = 50;

        this.lblRaporTakipNo = new TTVisual.TTLabel();
        this.lblRaporTakipNo.Text = i18n("M20855", "Rapor Takip No");
        this.lblRaporTakipNo.Name = "lblRaporTakipNo";
        this.lblRaporTakipNo.TabIndex = 3;

        this.txtRaporTakipNo = new TTVisual.TTTextBox();
        this.txtRaporTakipNo.BackColor = "#F0F0F0";
        this.txtRaporTakipNo.Name = "txtRaporTakipNo";
        this.txtRaporTakipNo.TabIndex = 4;


        this.Description = new TTVisual.TTTextBox();
        this.Description.Name = "Description";
        this.Description.TabIndex = 4;
        this.Description.Multiline = true;
        this.Description.Height = "50px";


        this.SonucAciklamasi = new TTVisual.TTTextBox();
        this.SonucAciklamasi.ReadOnly = true;
        this.SonucAciklamasi.Name = "SonucAciklamasi";
        this.SonucAciklamasi.TabIndex = 4;
        this.SonucAciklamasi.Multiline = true;
        this.SonucAciklamasi.Height = "30px";

        this.SonucKodu = new TTVisual.TTTextBox();
        this.SonucKodu.ReadOnly = true;
        this.SonucKodu.Name = "SonucKodu";
        this.SonucKodu.TabIndex = 4;

        this.btnRaporKaydet = new TTVisual.TTButton();
        this.btnRaporKaydet.Text = i18n("M20815", "Rapor Kaydet");
        this.btnRaporKaydet.Name = "btnRaporKaydet";
        this.btnRaporKaydet.TabIndex = 2;

        this.tttabSearchTCKNo = new TTVisual.TTTabPage();
        this.tttabSearchTCKNo.DisplayIndex = 1;
        this.tttabSearchTCKNo.TabIndex = 0;
        this.tttabSearchTCKNo.Text = i18n("M17580", "Kimlik Numarası İle Rapor Sorgula");
        this.tttabSearchTCKNo.Name = "tttabSearchTCKNo";

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M20869", "Rapor Türü");
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 2;

        this.cmbReportType = new TTVisual.TTEnumComboBox();
        this.cmbReportType.DataTypeName = "MedulaRaporTuruEnum";
        this.cmbReportType.Name = "cmbReportType";
        this.cmbReportType.TabIndex = 1;
        this.cmbReportType.Required = true;


        this.btnSearchTCKNo = new TTVisual.TTButton();
        this.btnSearchTCKNo.Text = i18n("M17581", "Kimlik Numarası İle Sorgula");
        this.btnSearchTCKNo.Name = "btnSearchTCKNo";
        this.btnSearchTCKNo.TabIndex = 0;

        this.tttabSearchChasing = new TTVisual.TTTabPage();
        this.tttabSearchChasing.DisplayIndex = 2;
        this.tttabSearchChasing.TabIndex = 1;
        this.tttabSearchChasing.Text = i18n("M20862", "Rapor Takip Numarası İle Rapor Sorgula");
        this.tttabSearchChasing.Name = "tttabSearchChasing";

        this.txtReportChasing = new TTVisual.TTTextBox();
        this.txtReportChasing.Name = "txtReportChasing";
        this.txtReportChasing.TabIndex = 4;


        this.txtReportRow = new TTVisual.TTTextBox();
        this.txtReportRow.Name = "txtReportRow";
        this.txtReportRow.TabIndex = 3;


        this.btnSearchChasing = new TTVisual.TTButton();
        this.btnSearchChasing.Text = i18n("M20862", "Rapor Takip Numarası İle Rapor Sorgula");
        this.btnSearchChasing.Name = "btnSearchChasing";
        this.btnSearchChasing.TabIndex = 2;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M20860", "Rapor Takip Numarası");
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 1;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M20845", "Rapor Sıra Numarası");
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 0;

        this.tttabSearchReportInfo = new TTVisual.TTTabPage();
        this.tttabSearchReportInfo.DisplayIndex = 3;
        this.tttabSearchReportInfo.TabIndex = 2;
        this.tttabSearchReportInfo.Text = i18n("M20783", "Rapor Bilgisi İle Rapor Sorgula");
        this.tttabSearchReportInfo.Name = "tttabSearchReportInfo";

        this.btnSearchReportInfo = new TTVisual.TTButton();
        this.btnSearchReportInfo.Text = i18n("M20783", "Rapor Bilgisi İle Rapor Sorgula");
        this.btnSearchReportInfo.Name = "btnSearchReportInfo";
        this.btnSearchReportInfo.TabIndex = 8;


        this.cmbRBReportType = new TTVisual.TTEnumComboBox();
        this.cmbRBReportType.DataTypeName = "MedulaRaporTuruEnum";
        this.cmbRBReportType.Name = "cmbRBReportType";
        this.cmbRBReportType.TabIndex = 7;


        this.dtReportDate = new TTVisual.TTDateTimePicker();
        this.dtReportDate.Format = DateTimePickerFormat.Short;
        this.dtReportDate.Name = "dtReportDate";
        this.dtReportDate.TabIndex = 6;

        this.txtRBReportChasing = new TTVisual.TTTextBox();
        this.txtRBReportChasing.Name = "txtRBReportChasing";
        this.txtRBReportChasing.TabIndex = 5;


        this.txtRBReportRow = new TTVisual.TTTextBox();
        this.txtRBReportRow.Name = "txtRBReportRow";
        this.txtRBReportRow.TabIndex = 4;


        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M20869", "Rapor Türü");
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 3;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M20864", "Rapor Tarihi");
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 2;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M20843", "Rapor Sıra  Numarası");
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 1;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M20824", "Rapor Numarası");
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 0;

        this.pnlSearchResult = new TTVisual.TTPanel();
        this.pnlSearchResult.AutoSize = true;
        this.pnlSearchResult.Name = "pnlSearchResult";
        this.pnlSearchResult.TabIndex = 3;

        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Text = i18n("M15311", "Hasta Takip Bilgileri");
        this.ttgroupbox3.Name = "ttgroupbox3";
        this.ttgroupbox3.TabIndex = 2;
        this.ttgroupbox3.Visible = false;

        this.chkFtrHeyetRaporu = new TTVisual.TTCheckBox();
        this.chkFtrHeyetRaporu.Value = false;
        this.chkFtrHeyetRaporu.Name = "chkFtrHeyetRaporu";
        this.chkFtrHeyetRaporu.TabIndex = 6;


        this.lstTabip3 = new TTVisual.TTObjectListBox();
        this.lstTabip3.ListDefName = "SpecialistDoctorListDefinition";
        this.lstTabip3.Name = "lstTabip3";
        this.lstTabip3.TabIndex = 8;
        this.lstTabip3.Visible = true;

        this.lblTabip3 = new TTVisual.TTLabel();
        this.lblTabip3.Text = i18n("M10291", "3.Tabip");
        this.lblTabip3.Name = "lblTabip3";
        this.lblTabip3.TabIndex = 13;
        this.lblTabip3.Visible = true;

        this.lblTabip2 = new TTVisual.TTLabel();
        this.lblTabip2.Text = i18n("M10223", "2.Tabip");
        this.lblTabip2.Name = "lblTabip2";
        this.lblTabip2.TabIndex = 12;
        this.lblTabip2.Visible = true;

        this.lstTabip2 = new TTVisual.TTObjectListBox();
        this.lstTabip2.ListDefName = "SpecialistDoctorListDefinition";
        this.lstTabip2.Name = "lstTabip2";
        this.lstTabip2.TabIndex = 7;
        this.lstTabip2.Visible = true;


        this.btnRaporArama = new TTVisual.TTButton();
        this.btnRaporArama.Text = i18n("M20765", "Rapor Ara");
        this.btnRaporArama.Name = "btnRaporArama";
        this.btnRaporArama.TabIndex = 10;
        this.btnRaporArama.Visible = true;


        this.lblRaporBitisTarihi = new TTVisual.TTLabel();
        this.lblRaporBitisTarihi.Text = i18n("M20788", "Rapor Bitiş Tarihi");
        this.lblRaporBitisTarihi.Name = "lblRaporBitisTarihi";
        this.lblRaporBitisTarihi.TabIndex = 6;
        this.lblRaporBitisTarihi.Visible = false;

        this.lblRaporBaslangicTarihi = new TTVisual.TTLabel();
        this.lblRaporBaslangicTarihi.Text = i18n("M20773", "Rapor Başlangıç Tarihi");
        this.lblRaporBaslangicTarihi.Name = "lblRaporBaslangicTarihi";
        this.lblRaporBaslangicTarihi.TabIndex = 5;
        this.lblRaporBaslangicTarihi.Visible = true;

        this.RaporBitisTarihi = new TTVisual.TTDateTimePicker();
        this.RaporBitisTarihi.Format = DateTimePickerFormat.Short;
        this.RaporBitisTarihi.Name = "RaporBitisTarihi";
        this.RaporBitisTarihi.TabIndex = 12;
        this.RaporBitisTarihi.Visible = true;
        this.RaporBitisTarihi.Enabled = true;

        this.lstTabip = new TTVisual.TTObjectListBox();
        this.lstTabip.ListDefName = "SpecialistDoctorListDefinition";
        this.lstTabip.Name = "lstTabip";
        this.lstTabip.TabIndex = 5;
        this.lstTabip.Visible = true;


        this.RaporBaslangicTarihi = new TTVisual.TTDateTimePicker();
        this.RaporBaslangicTarihi.Format = DateTimePickerFormat.Short;
        this.RaporBaslangicTarihi.Name = "RaporBaslangicTarihi";
        this.RaporBaslangicTarihi.TabIndex = 11;
        this.RaporBaslangicTarihi.Visible = true;


        this.lblRapotTuru = new TTVisual.TTLabel();
        this.lblRapotTuru.Required = true;
        this.lblRapotTuru.Text = i18n("M20869", "Rapor Türü");
        this.lblRapotTuru.Name = "lblRapotTuru";
        this.lblRapotTuru.TabIndex = 6;

        this.cmbRaporTuru = new TTVisual.TTEnumComboBox();
        this.cmbRaporTuru.DataTypeName = "TedaviRaporTuruEnum";
        this.cmbRaporTuru.Required = true;
        this.cmbRaporTuru.BackColor = "#F0F0F0";
        this.cmbRaporTuru.Enabled = true;
        this.cmbRaporTuru.Name = "cmbRaporTuru";
        this.cmbRaporTuru.TabIndex = 4;


        this.cmbRaporSureTuru = new TTVisual.TTEnumComboBox();
        this.cmbRaporSureTuru.DataTypeName = "PeriodUnitTypeEnum";
        this.cmbRaporSureTuru.Required = true;
        //this.cmbRaporSureTuru.BackColor = "#F0F0F0";
        this.cmbRaporSureTuru.Enabled = true;
        this.cmbRaporSureTuru.Name = "cmbRaporSureTuru";
        this.cmbRaporSureTuru.TabIndex = 4;


        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = "Medula Rapor Sorgulama Türleri";
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 2;

        this.chkRaporKaydet = new TTVisual.TTCheckBox();
        this.chkRaporKaydet.Value = false;
        this.chkRaporKaydet.Title = i18n("M20816", "Rapor Kaydet / Sil");
        this.chkRaporKaydet.Name = "chkRaporKaydet";
        this.chkRaporKaydet.TabIndex = 0;


        this.chkSearchReportInfo = new TTVisual.TTCheckBox();
        this.chkSearchReportInfo.Value = false;
        this.chkSearchReportInfo.Title = i18n("M20783", "Rapor Bilgisi İle Rapor Sorgula");
        this.chkSearchReportInfo.Name = "chkSearchReportInfo";
        this.chkSearchReportInfo.TabIndex = 3;


        this.chkSearchChasing = new TTVisual.TTCheckBox();
        this.chkSearchChasing.Value = false;
        this.chkSearchChasing.Title = i18n("M20862", "Rapor Takip Numarası İle Rapor Sorgula");
        this.chkSearchChasing.Name = "chkSearchChasing";
        this.chkSearchChasing.TabIndex = 2;


        this.chkSearchTCKNo = new TTVisual.TTCheckBox();
        this.chkSearchTCKNo.Value = false;
        this.chkSearchTCKNo.Title = i18n("M17580", "Kimlik Numarası İle Rapor Sorgula");
        this.chkSearchTCKNo.Name = "chkSearchTCKNo";
        this.chkSearchTCKNo.TabIndex = 1;


        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M15158", "Hasta Bilgileri");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 1;


        this.txtSex = new TTVisual.TTTextBox();
        this.txtSex.BackColor = "#F0F0F0";
        this.txtSex.ReadOnly = true;
        this.txtSex.Name = "txtSex";
        this.txtSex.TabIndex = 4;

        this.txtName = new TTVisual.TTTextBox();
        this.txtName.BackColor = "#F0F0F0";
        this.txtName.ReadOnly = true;
        this.txtName.Name = "txtName";
        this.txtName.TabIndex = 0;

        this.txtSurname = new TTVisual.TTTextBox();
        this.txtSurname.BackColor = "#F0F0F0";
        this.txtSurname.ReadOnly = true;
        this.txtSurname.Name = "txtSurname";
        this.txtSurname.TabIndex = 1;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Cinsiyeti";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 8;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M15303", "Hasta Soyadı");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 2;

        this.txtTCKNo = new TTVisual.TTTextBox();
        this.txtTCKNo.BackColor = "#F0F0F0";
        this.txtTCKNo.ReadOnly = true;
        this.txtTCKNo.Name = "txtTCKNo";
        this.txtTCKNo.TabIndex = 2;

        this.txtBirthDate = new TTVisual.TTTextBox();
        this.txtBirthDate.BackColor = "#F0F0F0";
        this.txtBirthDate.ReadOnly = true;
        this.txtBirthDate.Name = "txtBirthDate";
        this.txtBirthDate.TabIndex = 3;

        this.lblKimlikNo = new TTVisual.TTLabel();
        this.lblKimlikNo.Text = i18n("M22941", "TC Kimlik Numarası");
        this.lblKimlikNo.Name = "lblKimlikNo";
        this.lblKimlikNo.TabIndex = 1;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M15131", "Hasta Adı");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 0;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M13132", "Doğum Tarihi");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 6;

        this.cmdSearchPatient = new TTVisual.TTButton();
        this.cmdSearchPatient.Text = "Hasta Ara";
        this.cmdSearchPatient.Name = "cmdSearchPatient";
        this.cmdSearchPatient.TabIndex = 0;


        this.gridEswtIslemi = new TTVisual.TTGrid();
        this.gridEswtIslemi.Name = "gridEswtIslemi";
        this.gridEswtIslemi.TabIndex = 6;
        this.gridEswtIslemi.ShowFilterCombo = true;
        this.gridEswtIslemi.FilterColumnName = "FizyoterapiIslemiESWT";
        this.gridEswtIslemi.FilterLabel = i18n("M13903", " ESWT İşlemi");
        this.gridEswtIslemi.Filter = { ListDefName: "TedaviRaporlariIslemListDefinition", ListFilterExpression: "TEDAVIRAPORUTURUKODU='3'" };
        this.gridEswtIslemi.AllowUserToAddRows = false;
        this.gridEswtIslemi.DeleteButtonWidth = "5%";
        this.gridEswtIslemi.AllowUserToDeleteRows = true;
        this.gridEswtIslemi.IsFilterLabelSingleLine = false;


        this.FizyoterapiIslemiESWT = new TTVisual.TTListBoxColumn();
        this.FizyoterapiIslemiESWT.ListDefName = "TedaviRaporlariIslemListDefinition";
        this.FizyoterapiIslemiESWT.ListFilterExpression = "TEDAVIRAPORUTURUKODU='3'";
        this.FizyoterapiIslemiESWT.DataMember = "TedaviRaporiIslemKodlari";
        this.FizyoterapiIslemiESWT.DisplayIndex = 0;
        this.FizyoterapiIslemiESWT.HeaderText = i18n("M14424", "Fizyoterapi Rapor Kodu");
        this.FizyoterapiIslemiESWT.Name = "FizyoterapiIslemiESWT";
        this.FizyoterapiIslemiESWT.Width = 200;


        this.VucutBolgesiESWT = new TTVisual.TTListBoxColumn();
        this.VucutBolgesiESWT.ListDefName = "FTRVucutBolgesiTTObjectListDefinition";
        this.VucutBolgesiESWT.DataMember = "FTRVucutBolgesi";
        this.VucutBolgesiESWT.DisplayIndex = 1;
        this.VucutBolgesiESWT.HeaderText = i18n("M24187", "Vücut Bölgesi");
        this.VucutBolgesiESWT.Name = "VucutBolgesiESWT";
        this.VucutBolgesiESWT.Width = 100;


        this.SeansSayisiESWT = new TTVisual.TTTextBoxColumn();
        this.SeansSayisiESWT.DataMember = "NumberOfSessions";
        this.SeansSayisiESWT.DisplayIndex = 2;
        this.SeansSayisiESWT.HeaderText = i18n("M21489", "Seans Sayısı");
        this.SeansSayisiESWT.Name = "SeansSayisiESWT";
        this.SeansSayisiESWT.Width = 100;


        this.gridEswtIslemiColumns = [this.FizyoterapiIslemiESWT, this.VucutBolgesiESWT, this.SeansSayisiESWT];
        this.gridFizyoTerapiIslemleriColumns = [this.FizyoterapiIslemi, this.VucutBolgesi, this.SeansSayisi, this.TedaviTuru];

        //  this.gridDiyalizRaporlariColumns = [this.raporTakipNoDiyaliz, this.raporNumarasiDiyaliz, this.raporSiraNoDiyaliz, this.raporGonderimTarihiDiyaliz, this.sonucKoduDiyaliz, this.sonucMesajiDiyaliz, this.raporSilDiyaliz, this.raporTesisiDiyaliz];
        this.gridEvHemodiyalizRaporlariColumns = [this.raporTakipNoEvHemodiyaliz, this.raporNumarasiEvHemodiyaliz, this.raporSiraNoEvHemodiyaliz, this.raporGonderimTarihiEvHemodiyaliz, this.sonucKoduEvHemodiyaliz, this.sonucMesajiEvHemodiyaliz, this.raporSilEvHemodiyaliz, this.raporTesisiEvHemodiyaliz];
        this.gridEvdiyalizRaporlariColumns = [];
        this.gridTupBebekRaporlariColumns = [this.raporTakipNoTupBebek, this.raporNumarasiTupBebek, this.raporSiraNoTupBebek, this.raporGonderimTarihiTupBebek, this.sonucKoduTupBebek, this.sonucMesajiTupBebek, this.raporSilTupBebek, this.raporTesisiTupBebek];
        this.gridHOTRaporlariColumns = [this.raporTakipNoHOT, this.raporNumarasiHOT, this.raporSiraNoHOT, this.raporGonderimTarihiHOT, this.sonucKoduHOT, this.sonucMesajiHOT, this.raporSilHOT, this.raporTesisiHOT];
        this.gridEswtIslemiColumns = [this.FizyoterapiIslemiESWT, this.VucutBolgesiESWT, this.SeansSayisiESWT];
        this.gridTasBilgisiColumns = [this.Lokalizasyon2, this.TasBoyutu2];
        this.gridTaniColumns = [this.lstTani, this.FTRTaniGrubu];
        this.tttabcontrol1.Controls = [this.tttabAramaIslemleri];
        this.tttabAramaIslemleri.Controls = [this.tttabRaporlar, this.pnlSearchResult, this.cmdSearchPatient];
        this.tttabRaporlar.Controls = [this.tttabFtrRaporlari, this.tttabTumRaporlar, this.tttabEswlRaporlari, this.tttabDiyalizRaporlari, this.tttabEvHemodiyalizRaporlari, this.tttabTupBebekRaporlari, this.tttabHOTRaporlari];
        this.tttabTumRaporlar.Controls = [this.txtResult];

        this.tttabReportSave.Controls = [this.tttabTedaviRaporlariKaydet, this.gridTani, this.lblRaporTakipNo, this.txtRaporTakipNo, this.btnRaporKaydet];
        this.tttabTedaviRaporlariKaydet.Controls = [this.tttabFtrRaporKaydet, this.tttabESWTRaporKaydet, this.tttabESWLRaporKaydet, this.tttabDiyalizRaporKaydet, this.tttabEvHemoDiyalizRaporKaydet, this.tttabHOTRaporKaydet, this.tttabTupBebekRaporKaydet];
        this.tttabFtrRaporKaydet.Controls = [this.lblOzelDurum, this.cmbOzelDurum, this.chkOzelDurum, this.btnFtrIstek, this.gridFizyoTerapiIslemleri];
        this.tttabESWTRaporKaydet.Controls = [this.gridEswtIslemi];
        this.tttabESWLRaporKaydet.Controls = [this.lstBobrekBilgisi, this.lblBobrekBilgisi, this.txtEswlSeansSayisi, this.lblEswlSeansSayisi, this.txtTasSayisi, this.lblTasSayisi, this.lstEswlRaporKodu, this.gridTasBilgisi, this.lblEswlRaporKodu];
        this.tttabDiyalizRaporKaydet.Controls = [this.ttlabel1, this.cmbDiyalizSeansGun, this.lblDiyalizSeansSayisi, this.txtDiyalizSeansSayisi, this.lblDiyalizRaporKodu, this.lstDiyalizRaporKodu, this.chkRefakatVarYok];
        this.tttabEvHemoDiyalizRaporKaydet.Controls = [this.ttlabel14, this.cmbEvHemodiyalizSeansGun, this.txtEvHemodiyalizTedaviSuresi, this.lblEvHemodiyalizTedaviSuresi, this.txtEvHemodiyalizSeansSayisi, this.lblEvHemodiyalizSeansSayisi, this.lblEvHemodiyalizRaporKodu, this.lstEvHemodiyalizRaporKodu];
        this.tttabHOTRaporKaydet.Controls = [this.txtHOTTedaviSuresi, this.lblHOTTedaviSuresi, this.txtHOTSeansSayisi, this.lblHOTSeansSayisi];
        this.tttabTupBebekRaporKaydet.Controls = [this.cmbTupBebekTuru, this.lblTupBebekTuru, this.lstTupBebekRaporKodu, this.lblTupBebekRaporKodu];
        this.tttabSearchTCKNo.Controls = [this.ttlabel7, this.cmbReportType, this.btnSearchTCKNo];
        this.tttabSearchChasing.Controls = [this.txtReportChasing, this.txtReportRow, this.btnSearchChasing, this.ttlabel9, this.ttlabel8];
        this.tttabSearchReportInfo.Controls = [this.btnSearchReportInfo, this.cmbRBReportType, this.dtReportDate, this.txtRBReportChasing, this.txtRBReportRow, this.ttlabel13, this.ttlabel12, this.ttlabel11, this.ttlabel10];
        this.pnlSearchResult.Controls = [this.ttgroupbox3, this.ttgroupbox2, this.ttgroupbox1];
        this.ttgroupbox3.Controls = [this.chkFtrHeyetRaporu, this.lstTabip3, this.lblTabip3, this.lblTabip2, this.lstTabip2, this.btnRaporArama, this.gridHastaAktifTumTakipler, this.lblRaporBitisTarihi, this.lblTabip, this.lblRaporBaslangicTarihi, this.RaporBitisTarihi, this.lstTabip, this.RaporBaslangicTarihi, this.cmbRaporSureTuru, this.lblRapotTuru, this.cmbRaporTuru, this.gridHastaAktifTakipleri];
        this.ttgroupbox2.Controls = [this.chkRaporKaydet, this.chkSearchReportInfo, this.chkSearchChasing, this.chkSearchTCKNo];
        this.ttgroupbox1.Controls = [this.txtSex, this.txtName, this.txtSurname, this.ttlabel6, this.ttlabel4, this.txtTCKNo, this.txtBirthDate, this.lblKimlikNo, this.ttlabel2, this.ttlabel5];
        this.Controls = [this.gridFizyoTerapiIslemleri, this.tttabcontrol1, this.Description, this.tttabAramaIslemleri, this.tttabRaporlar, this.tttabFtrRaporlari, this.raporTakipNo, this.raporNumarasi, this.raporSiraNo, this.raporVucutBolgesi, this.kur, this.raporGonderimTarihi, this.raporSil, this.raporTesisi, this.tttabTumRaporlar, this.txtResult, this.tttabEswlRaporlari, this.raporTakipNoEswl, this.raporNumarasiEswl, this.raporSiraNoEswl, this.raporGonderimTarihiEswl, this.sonucKoduEswl, this.sonucMesajiEswl, this.raporSilEswl, this.raporTesisiEswl, this.tttabDiyalizRaporlari, this.raporTakipNoDiyaliz, this.raporNumarasiDiyaliz, this.raporSiraNoDiyaliz, this.raporGonderimTarihiDiyaliz, this.sonucKoduDiyaliz, this.sonucMesajiDiyaliz, this.raporSilDiyaliz, this.raporTesisiDiyaliz, this.tttabEvHemodiyalizRaporlari, this.raporTakipNoEvHemodiyaliz, this.raporNumarasiEvHemodiyaliz, this.raporSiraNoEvHemodiyaliz, this.raporGonderimTarihiEvHemodiyaliz, this.sonucKoduEvHemodiyaliz, this.sonucMesajiEvHemodiyaliz, this.raporSilEvHemodiyaliz, this.raporTesisiEvHemodiyaliz, this.tttabTupBebekRaporlari, this.raporTakipNoTupBebek, this.raporNumarasiTupBebek, this.raporSiraNoTupBebek, this.raporGonderimTarihiTupBebek, this.sonucKoduTupBebek, this.sonucMesajiTupBebek, this.raporSilTupBebek, this.raporTesisiTupBebek, this.tttabHOTRaporlari, this.raporTakipNoHOT, this.raporNumarasiHOT, this.raporSiraNoHOT, this.raporGonderimTarihiHOT, this.sonucKoduHOT, this.sonucMesajiHOT, this.raporSilHOT, this.raporTesisiHOT, this.tttabReportSave, this.tttabTedaviRaporlariKaydet, this.tttabFtrRaporKaydet, this.lblOzelDurum, this.cmbOzelDurum, this.chkOzelDurum, this.btnFtrIstek, this.gridFizyoTerapiIslemleri, this.VucutBolgesi, this.SeansSayisi, this.TedaviTuru, this.tttabESWTRaporKaydet, this.gridEswtIslemi, this.FizyoterapiIslemiESWT, this.VucutBolgesiESWT, this.SeansSayisiESWT, this.tttabESWLRaporKaydet, this.lstBobrekBilgisi, this.lblBobrekBilgisi, this.txtEswlSeansSayisi, this.lblEswlSeansSayisi, this.txtTasSayisi, this.lblTasSayisi, this.lstEswlRaporKodu, this.gridTasBilgisi, this.Lokalizasyon2, this.TasBoyutu2, this.lblEswlRaporKodu, this.tttabDiyalizRaporKaydet, this.ttlabel1, this.cmbDiyalizSeansGun, this.lblDiyalizSeansSayisi, this.txtDiyalizSeansSayisi, this.lblDiyalizRaporKodu, this.lstDiyalizRaporKodu, this.chkRefakatVarYok, this.tttabEvHemoDiyalizRaporKaydet, this.ttlabel14, this.cmbEvHemodiyalizSeansGun, this.txtEvHemodiyalizTedaviSuresi, this.lblEvHemodiyalizTedaviSuresi, this.txtEvHemodiyalizSeansSayisi, this.lblEvHemodiyalizSeansSayisi, this.lblEvHemodiyalizRaporKodu, this.lstEvHemodiyalizRaporKodu, this.tttabHOTRaporKaydet, this.txtHOTTedaviSuresi, this.lblHOTTedaviSuresi, this.txtHOTSeansSayisi, this.lblHOTSeansSayisi, this.tttabTupBebekRaporKaydet, this.cmbTupBebekTuru, this.lblTupBebekTuru, this.lstTupBebekRaporKodu, this.lblTupBebekRaporKodu, this.gridTani, this.lstTani, this.FTRTaniGrubu, this.lblRaporTakipNo, this.txtRaporTakipNo, this.btnRaporKaydet, this.tttabSearchTCKNo, this.ttlabel7, this.cmbReportType, this.btnSearchTCKNo, this.tttabSearchChasing, this.txtReportChasing, this.txtReportRow, this.btnSearchChasing, this.ttlabel9, this.ttlabel8, this.tttabSearchReportInfo, this.btnSearchReportInfo, this.cmbRBReportType, this.dtReportDate, this.txtRBReportChasing, this.txtRBReportRow, this.ttlabel13, this.ttlabel12, this.ttlabel11, this.ttlabel10, this.pnlSearchResult, this.ttgroupbox3, this.chkFtrHeyetRaporu, this.lstTabip3, this.lblTabip3, this.lblTabip2, this.lstTabip2, this.btnRaporArama, this.gridHastaAktifTumTakipler, this.txtTakipNo2, this.txtBrans2, this.txtProvizyonTarihi2, this.txtBagliTakipNo2, this.txtXXXXXXProtocolNo2, this.txtVakaAcilisTarihi2, this.txtBransKodu2, this.txtTedaviTuru2, this.lblRaporBitisTarihi, this.lblTabip, this.lblRaporBaslangicTarihi, this.RaporBitisTarihi, this.lstTabip, this.RaporBaslangicTarihi, this.lblRapotTuru, this.cmbRaporTuru, this.gridHastaAktifTakipleri, this.txtTakipNo1, this.txtBrans1, this.txtProvizyonTarihi1, this.txtBagliTakipNo1, this.txtXXXXXXProtocolNo1, this.txtVakaAcilisTarihi1, this.txtBransKodu1, this.txtTedaviTuru1, this.ttgroupbox2, this.chkRaporKaydet, this.chkSearchReportInfo, this.chkSearchChasing, this.chkSearchTCKNo, this.ttgroupbox1, this.txtSex, this.txtName, this.txtSurname, this.ttlabel6, this.ttlabel4, this.txtTCKNo, this.txtBirthDate, this.lblKimlikNo, this.ttlabel2, this.ttlabel5, this.cmdSearchPatient];

    }


}
