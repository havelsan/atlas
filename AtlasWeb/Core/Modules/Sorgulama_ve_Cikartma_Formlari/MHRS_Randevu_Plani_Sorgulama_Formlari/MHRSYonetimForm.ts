//$39B5D806
import { Component, OnInit, NgZone } from '@angular/core';
import { MHRSYonetimFormViewModel, CetvelSorgulaViewModel,CetvelSorgulamaReturnData,DoktorEkleListModel, MHRSAltKlinikEkleListModel, MHRSKlinikEkleListModel, PoliklinikMHRSKlinikKoduEslestirmeListModel, ScheduleListModel, BransListModel } from './MHRSYonetimFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MHRSYonetim } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewTriState } from 'NebulaClient/Utils/Enums/DataGridViewTriState';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ServiceLocator } from '../../../wwwroot/app/Fw/Services/ServiceLocator';


@Component({
    selector: 'MHRSYonetimForm',
    templateUrl: './MHRSYonetimForm.html',
    providers: [MessageService]
})
export class MHRSYonetimForm extends TTVisual.TTForm implements OnInit {
    btnAltKlinikEkle: TTVisual.ITTButton;
    btnHekimEkle: TTVisual.ITTButton;
    btnKlinikEkle: TTVisual.ITTButton;
    btnSetMHRSClinicCode: TTVisual.ITTButton;
    btnUncertainedSchedule: TTVisual.ITTButton;
    btnAllSchedule: TTVisual.ITTButton;
    ckcMHRSyeGonder: TTVisual.ITTCheckBoxColumn;
    gridMHRSHekim: TTVisual.ITTGrid;
    gridMHRSPoliklinic: TTVisual.ITTGrid;
    gridSchedule: TTVisual.ITTGrid;
    gridMHRSyeEklenenAltPoliklinikler: TTVisual.ITTGrid;
    gridMHRSyeEklenenPoliklinikler: TTVisual.ITTGrid;
    tabPageKlinikHekimBildirimi: TTVisual.ITTTabPage;
    tabPageRandevuPlanlariSorgulama: TTVisual.ITTTabPage;
    tbMHRSIslemleri: TTVisual.ITTTabControl;
    ttlabel1: TTVisual.ITTLabel;
    txtHekimEkleBilgi: TTVisual.ITTTextBoxColumn;
    txtHekimEkleHekim: TTVisual.ITTTextBoxColumn;
    txtHekimEklePoliklinik: TTVisual.ITTTextBoxColumn;
    txtMHRSPoliklinic: TTVisual.ITTTextBoxColumn;
    txtMHRSPoliklinicMHRSClinic: TTVisual.ITTTextBoxColumn;
    txtMHRSyeEklendi: TTVisual.ITTTextBoxColumn;
    txtMHRSyeEklendiAltKlinik: TTVisual.ITTTextBoxColumn;
    txtMHRSyeEklenenAltPoliklinic: TTVisual.ITTTextBoxColumn;
    txtMHRSyeEklenenPoliklinic: TTVisual.ITTTextBoxColumn;
    txPoliclinic: TTVisual.ITTTextBoxColumn;
    txtDoctor: TTVisual.ITTTextBoxColumn;
    txtBaslangicTarihi: TTVisual.ITTTextBoxColumn;
    txtBitisTarihi: TTVisual.ITTTextBoxColumn;
    ckcKesinlesti: TTVisual.ITTCheckBoxColumn;
    txtKesinlesmeHatasi: TTVisual.ITTTextBoxColumn;
    BitisTarihi: TTVisual.ITTDateTimePicker;
    BaslangicTarihi: TTVisual.ITTDateTimePicker;
    listDoctor: TTVisual.ITTObjectListBox;
    listDoctorCetvelsorgula: TTVisual.ITTObjectListBox;
    lstPoliclinic: TTVisual.ITTObjectListBox;
    lstPoliclinicCetvelsorgula: TTVisual.ITTObjectListBox;
    public gridMHRSHekimColumns = [];
    public gridMHRSPoliklinicColumns = [];
    public gridMHRSyeEklenenAltPolikliniklerColumns = [];
    public gridMHRSyeEklenenPolikliniklerColumns = [];
    public gridScheduleColumns = [];
    public mHRSYonetimFormViewModel: MHRSYonetimFormViewModel = new MHRSYonetimFormViewModel();
    public cetvelSorgulaViewModel: CetvelSorgulaViewModel = new CetvelSorgulaViewModel();

    public get _MHRSYonetim(): MHRSYonetim {
        return this._TTObject as MHRSYonetim;
    }
    private MHRSYonetimForm_DocumentUrl: string = '/api/MHRSYonetimService/MHRSYonetimForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('MHRSYONETIM', 'MHRSYonetimForm');
        this._DocumentServiceUrl = this.MHRSYonetimForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async btnSetMHRSClinicCode_Click(): Promise<void> {
        let response: PoliklinikMHRSKlinikKoduEslestirmeListModel[];
        this.httpService.get("/api/MHRSYonetimService/setMHRSClinicCode")
            .then(response => {
                let responseDVO = response as PoliklinikMHRSKlinikKoduEslestirmeListModel[];
                if (responseDVO != null) {
                    for (let i: number = 0; i < responseDVO.length; i++) {
                        let klinikKoduEslestirme: PoliklinikMHRSKlinikKoduEslestirmeListModel = new PoliklinikMHRSKlinikKoduEslestirmeListModel();
                        klinikKoduEslestirme.Poliklinik = responseDVO[i].Poliklinik;
                        klinikKoduEslestirme.PoliklinikName = responseDVO[i].PoliklinikName;
                        klinikKoduEslestirme.MHRSKlinik = responseDVO[i].MHRSKlinik;
                        klinikKoduEslestirme.Ekle = responseDVO[i].Ekle;
                        this.mHRSYonetimFormViewModel.PoliklinikMHRSKlinikKoduEslestirmeList.push(klinikKoduEslestirme);
                    }
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
    public async btnAllSchedule_Click(): Promise<void> {
        this.mHRSYonetimFormViewModel.ScheduleList.Clear();
        if (this.mHRSYonetimFormViewModel.BaslangicTarihi == null) {
            this.messageService.showError(i18n("M11639", "Başlangıç Tarihi Boş Geçilemez ! "));
            return;
        }
        if (this.mHRSYonetimFormViewModel.BitisTarihi == null) {
            this.messageService.showError(i18n("M11941", "Bitiş Tarihi Boş Geçilemez ! "));
            return;
        }
        if (this.mHRSYonetimFormViewModel.BitisTarihi <= this.mHRSYonetimFormViewModel.BaslangicTarihi) {
            this.messageService.showError(i18n("M11944", "Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! "));
            return;
        }

        this.mHRSYonetimFormViewModel.Kesinlesmis = true;

        let result = <ScheduleListModel[]>await this.httpService.post('/api/MHRSYonetimService/getAllSchedule', this.mHRSYonetimFormViewModel);
        this.mHRSYonetimFormViewModel.ScheduleList = result;
    }

    public async btnUncertainedSchedule_Click(): Promise<void> {
        this.mHRSYonetimFormViewModel.ScheduleList.Clear();
        if (this.mHRSYonetimFormViewModel.BaslangicTarihi == null) {
            this.messageService.showError(i18n("M11639", "Başlangıç Tarihi Boş Geçilemez ! "));
            return;
        }
        if (this.mHRSYonetimFormViewModel.BitisTarihi == null) {
            this.messageService.showError(i18n("M11941", "Bitiş Tarihi Boş Geçilemez ! "));
            return;
        }
        if (this.mHRSYonetimFormViewModel.BitisTarihi <= this.mHRSYonetimFormViewModel.BaslangicTarihi) {
            this.messageService.showError(i18n("M11944", "Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! "));
            return;
        }

        this.mHRSYonetimFormViewModel.Kesinlesmis = false;

        let result = <ScheduleListModel[]>await this.httpService.post('/api/MHRSYonetimService/getAllSchedule', this.mHRSYonetimFormViewModel);
        this.mHRSYonetimFormViewModel.ScheduleList = result;
    }

    public async btnKlinikEkle_Click(): Promise<void> {
        let result = <MHRSKlinikEkleListModel[]>await this.httpService.post('/api/MHRSYonetimService/addClinic', this.mHRSYonetimFormViewModel.PoliklinikMHRSKlinikKoduEslestirmeList);
        this.mHRSYonetimFormViewModel.MHRSKlinikEkleList = result;
    }

    public async btnAltKlinikEkle_Click(): Promise<void> {
        let result = <MHRSAltKlinikEkleListModel[]>await this.httpService.post('/api/MHRSYonetimService/addPoliclinic', this.mHRSYonetimFormViewModel.MHRSKlinikEkleList);
        this.mHRSYonetimFormViewModel.MHRSAltKlinikEkleList = result;
    }
    public async btnHekimEkle_Click(): Promise<void> {
        let result = <DoktorEkleListModel[]>await this.httpService.get('/api/MHRSYonetimService/addDoctor');
        this.mHRSYonetimFormViewModel.DoktorEkleList = result;
    }
    public onDoctorChanged(event): void {
        if (event != null) {
            if (this.mHRSYonetimFormViewModel != null && this.mHRSYonetimFormViewModel.Doctor != event) {
                this.mHRSYonetimFormViewModel.Doctor = event;
            }
        }
    }

    public onDoctorChangedCetvelSorgula(event): void {
        if (event != null) {
            if (this.cetvelSorgulaViewModel != null && this.cetvelSorgulaViewModel.Doctor != event) {
                this.cetvelSorgulaViewModel.Doctor = event;
            }
        }
    }

    public async onPoliclinicChanged(event): Promise<void> {
        if (event != null) {
            if (this.mHRSYonetimFormViewModel != null && this.mHRSYonetimFormViewModel.Policlinic != event) {
                this.mHRSYonetimFormViewModel.Policlinic = event;
            }
        }
        let result = <BransListModel[]>await this.httpService.get('/api/MHRSYonetimService/GetBransofPoliclinic?policlinicObjectID=' + this.mHRSYonetimFormViewModel.Policlinic.ObjectID);
        this.mHRSYonetimFormViewModel.BransList = result;

        let i: number = 1;
        let filterExpression: string = "ResourceSpecialities.Speciality.Code IN(";
        for (let item of this.mHRSYonetimFormViewModel.BransList) {
            filterExpression += "'" + item.BransKodu + "'";
            if (i < this.mHRSYonetimFormViewModel.BransList.length)
                filterExpression += ',';
            i++;
        }
        filterExpression += ')';
        this.listDoctor.ListFilterExpression = filterExpression;
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MHRSYonetim();
        this.mHRSYonetimFormViewModel = new MHRSYonetimFormViewModel();
        this._ViewModel = this.mHRSYonetimFormViewModel;
        this.mHRSYonetimFormViewModel._MHRSYonetim = this._TTObject as MHRSYonetim;
    }

    protected loadViewModel() {
        let that = this;

        that.mHRSYonetimFormViewModel = this._ViewModel as MHRSYonetimFormViewModel;
        that._TTObject = this.mHRSYonetimFormViewModel._MHRSYonetim;
        if (this.mHRSYonetimFormViewModel == null)
            this.mHRSYonetimFormViewModel = new MHRSYonetimFormViewModel();
        if (this.mHRSYonetimFormViewModel._MHRSYonetim == null)
            this.mHRSYonetimFormViewModel._MHRSYonetim = new MHRSYonetim();

        this.cetvelSorgulaViewModel = new CetvelSorgulaViewModel();
        this.cetvelSorgulaViewModel.StartDate = new Date();
        this.cetvelSorgulaViewModel.EndDate = new Date(); 
    }

    async ngOnInit()  {
        let that = this;
        await this.load(MHRSYonetimFormViewModel);
  
    }


    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.tbMHRSIslemleri = new TTVisual.TTTabControl();
        this.tbMHRSIslemleri.Name = "tbMHRSIslemleri";
        this.tbMHRSIslemleri.TabIndex = 1;

        this.tabPageRandevuPlanlariSorgulama = new TTVisual.TTTabPage();
        this.tabPageRandevuPlanlariSorgulama.DisplayIndex = 0;
        this.tabPageRandevuPlanlariSorgulama.TabIndex = 1;
        this.tabPageRandevuPlanlariSorgulama.Text = "MHRS Randevu Planları Sorgulama";
        this.tabPageRandevuPlanlariSorgulama.Name = "tabPageRandevuPlanlariSorgulama";

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "ttlabel1";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 0;

        this.tabPageKlinikHekimBildirimi = new TTVisual.TTTabPage();
        this.tabPageKlinikHekimBildirimi.DisplayIndex = 1;
        this.tabPageKlinikHekimBildirimi.TabIndex = 0;
        this.tabPageKlinikHekimBildirimi.Text = i18n("M17632", "Klinik Hekim Bildirimi");
        this.tabPageKlinikHekimBildirimi.Name = "tabPageKlinikHekimBildirimi";

        this.btnSetMHRSClinicCode = new TTVisual.TTButton();
        this.btnSetMHRSClinicCode.Text = i18n("M20432", "Poliklinik - MHRS Klinik Kodu Eşleşmesi");
        this.btnSetMHRSClinicCode.Name = "btnSetMHRSClinicCode";
        this.btnSetMHRSClinicCode.TabIndex = 0;

        this.btnHekimEkle = new TTVisual.TTButton();
        this.btnHekimEkle.Text = "MHRS'ye Hekim Ekle";
        this.btnHekimEkle.Name = "btnHekimEkle";
        this.btnHekimEkle.TabIndex = 6;

        this.gridMHRSHekim = new TTVisual.TTGrid();
        this.gridMHRSHekim.Name = "gridMHRSHekim";
        this.gridMHRSHekim.TabIndex = 7;
        this.gridMHRSHekim.AllowUserToAddRows = false;
        this.gridMHRSHekim.AllowUserToDeleteRows = false;
        this.gridMHRSHekim.AllowUserToOrderColumns = true;
        this.gridMHRSHekim.Height = "250";

        this.txtHekimEklePoliklinik = new TTVisual.TTTextBoxColumn();
        this.txtHekimEklePoliklinik.DataMember = "Uzmanlik";
        this.txtHekimEklePoliklinik.DisplayIndex = 0;
        this.txtHekimEklePoliklinik.HeaderText = i18n("M23868", "Uzmanlık");
        this.txtHekimEklePoliklinik.Name = "txtHekimEklePoliklinik";
        this.txtHekimEklePoliklinik.Width = 300;
        this.txtHekimEklePoliklinik.ReadOnly = true;

        this.txtHekimEkleHekim = new TTVisual.TTTextBoxColumn();
        this.txtHekimEkleHekim.DisplayIndex = 1;
        this.txtHekimEkleHekim.DataMember = "Doktor";
        this.txtHekimEkleHekim.HeaderText = i18n("M15621", "Hekim");
        this.txtHekimEkleHekim.Name = "txtHekimEkleHekim";
        this.txtHekimEkleHekim.Width = 300;
        this.txtHekimEkleHekim.ReadOnly = true;

        this.txtHekimEkleBilgi = new TTVisual.TTTextBoxColumn();
        this.txtHekimEkleBilgi.DataMember = i18n("M13550", "Eklendi");
        this.txtHekimEkleBilgi.DisplayIndex = 2;
        this.txtHekimEkleBilgi.HeaderText = i18n("M13550", "Eklendi");
        this.txtHekimEkleBilgi.Name = "txtHekimEkleBilgi";
        this.txtHekimEkleBilgi.Width = 400;
        this.txtHekimEkleBilgi.ReadOnly = true;

        this.btnKlinikEkle = new TTVisual.TTButton();
        this.btnKlinikEkle.Text = "MHRS'ye Klinik Ekle";
        this.btnKlinikEkle.Name = "btnKlinikEkle";
        this.btnKlinikEkle.TabIndex = 4;

        this.btnAllSchedule = new TTVisual.TTButton();
        this.btnAllSchedule.Text = i18n("M23643", "Tüm Planları Listele");
        this.btnAllSchedule.Name = "btnAllSchedule";
        this.btnAllSchedule.TabIndex = 4;

        this.btnUncertainedSchedule = new TTVisual.TTButton();
        this.btnUncertainedSchedule.Text = i18n("M17506", "Kesinleşmemiş Randevu Planları");
        this.btnUncertainedSchedule.Name = "btnUncertainedSchedule";
        this.btnUncertainedSchedule.TabIndex = 4;

        this.gridMHRSyeEklenenPoliklinikler = new TTVisual.TTGrid();
        this.gridMHRSyeEklenenPoliklinikler.AllowUserToDeleteRows = false;
        this.gridMHRSyeEklenenPoliklinikler.AllowUserToAddRows = false;
        this.gridMHRSyeEklenenPoliklinikler.Name = "gridMHRSyeEklenenPoliklinikler";
        this.gridMHRSyeEklenenPoliklinikler.TabIndex = 5;
        this.gridMHRSyeEklenenPoliklinikler.Height = "250";

        this.txtMHRSyeEklenenPoliklinic = new TTVisual.TTTextBoxColumn();
        this.txtMHRSyeEklenenPoliklinic.DataMember = "PoliklinikName";
        this.txtMHRSyeEklenenPoliklinic.DisplayIndex = 0;
        this.txtMHRSyeEklenenPoliklinic.HeaderText = i18n("M20431", "Poliklinik");
        this.txtMHRSyeEklenenPoliklinic.Name = "txtMHRSyeEklenenPoliklinic";
        this.txtMHRSyeEklenenPoliklinic.Width = 400;
        this.txtMHRSyeEklenenPoliklinic.ReadOnly = true;

        this.txtMHRSyeEklendi = new TTVisual.TTTextBoxColumn();
        this.txtMHRSyeEklendi.DataMember = i18n("M13550", "Eklendi");
        this.txtMHRSyeEklendi.DisplayIndex = 1;
        this.txtMHRSyeEklendi.HeaderText = "MHRS'ye Eklendi";
        this.txtMHRSyeEklendi.Name = "txtMHRSyeEklendi";
        this.txtMHRSyeEklendi.Width = 400;
        this.txtMHRSyeEklendi.ReadOnly = true;
        this.txtMHRSyeEklendi.WrapMode = DataGridViewTriState.True;

        this.gridMHRSPoliklinic = new TTVisual.TTGrid();
        this.gridMHRSPoliklinic.AllowUserToDeleteRows = false;
        this.gridMHRSPoliklinic.AllowUserToAddRows = false;
        this.gridMHRSPoliklinic.Name = "gridMHRSPoliklinic";
        this.gridMHRSPoliklinic.TabIndex = 1;
        this.gridMHRSPoliklinic.Height = "250";

        this.txtMHRSPoliklinic = new TTVisual.TTTextBoxColumn();
        this.txtMHRSPoliklinic.DataMember = "PoliklinikName";
        this.txtMHRSPoliklinic.DisplayIndex = 0;
        this.txtMHRSPoliklinic.HeaderText = i18n("M20431", "Poliklinik");
        this.txtMHRSPoliklinic.Name = "txtMHRSPoliklinic";
        this.txtMHRSPoliklinic.ReadOnly = true;
        this.txtMHRSPoliklinic.Width = 500;

        this.txtMHRSPoliklinicMHRSClinic = new TTVisual.TTTextBoxColumn();
        this.txtMHRSPoliklinicMHRSClinic.DataMember = "MHRSKlinik";
        this.txtMHRSPoliklinicMHRSClinic.DisplayIndex = 1;
        this.txtMHRSPoliklinicMHRSClinic.HeaderText = "MHRS Klinik";
        this.txtMHRSPoliklinicMHRSClinic.Name = "txtMHRSPoliklinicMHRSClinic";
        this.txtMHRSPoliklinicMHRSClinic.ReadOnly = true;
        this.txtMHRSPoliklinicMHRSClinic.Width = 500;

        this.ckcMHRSyeGonder = new TTVisual.TTCheckBoxColumn();
        this.ckcMHRSyeGonder.DataMember = i18n("M13543", "Ekle");
        this.ckcMHRSyeGonder.DisplayIndex = 2;
        this.ckcMHRSyeGonder.HeaderText = "MHRS'ye Gönderilsin";
        this.ckcMHRSyeGonder.Name = "ckcMHRSyeGonder";
        this.ckcMHRSyeGonder.Width = 120;

        this.btnAltKlinikEkle = new TTVisual.TTButton();
        this.btnAltKlinikEkle.Text = "MHRS'ye Alt Klinikleri Ekle";
        this.btnAltKlinikEkle.Name = "btnAltKlinikEkle";
        this.btnAltKlinikEkle.TabIndex = 2;

        this.gridMHRSyeEklenenAltPoliklinikler = new TTVisual.TTGrid();
        this.gridMHRSyeEklenenAltPoliklinikler.Name = "gridMHRSyeEklenenAltPoliklinikler";
        this.gridMHRSyeEklenenAltPoliklinikler.TabIndex = 3;
        this.gridMHRSyeEklenenAltPoliklinikler.AllowUserToAddRows = false;
        this.gridMHRSyeEklenenAltPoliklinikler.AllowUserToDeleteRows = false;
        this.gridMHRSyeEklenenAltPoliklinikler.AllowUserToOrderColumns = true;
        this.gridMHRSyeEklenenAltPoliklinikler.Height = "250";

        this.txtMHRSyeEklenenAltPoliklinic = new TTVisual.TTTextBoxColumn();
        this.txtMHRSyeEklenenAltPoliklinic.DataMember = "PoliklinikName";
        this.txtMHRSyeEklenenAltPoliklinic.DisplayIndex = 0;
        this.txtMHRSyeEklenenAltPoliklinic.HeaderText = i18n("M20431", "Poliklinik");
        this.txtMHRSyeEklenenAltPoliklinic.Name = "txtMHRSyeEklenenAltPoliklinic";
        this.txtMHRSyeEklenenAltPoliklinic.Width = 400;
        this.txtMHRSyeEklenenAltPoliklinic.ReadOnly = true;

        this.txtMHRSyeEklendiAltKlinik = new TTVisual.TTTextBoxColumn();
        this.txtMHRSyeEklendiAltKlinik.DataMember = i18n("M13550", "Eklendi");
        this.txtMHRSyeEklendiAltKlinik.DisplayIndex = 1;
        this.txtMHRSyeEklendiAltKlinik.HeaderText = "MHRS'ye Eklendi";
        this.txtMHRSyeEklendiAltKlinik.Name = "txtMHRSyeEklendiAltKlinik";
        this.txtMHRSyeEklendiAltKlinik.Width = 400;
        this.txtMHRSyeEklendiAltKlinik.ReadOnly = true;
        this.txtMHRSyeEklendiAltKlinik.WrapMode = DataGridViewTriState.True;

        this.BitisTarihi = new TTVisual.TTDateTimePicker();
        this.BitisTarihi.Format = DateTimePickerFormat.Short;
        this.BitisTarihi.Name = "BitisTarihi";
        this.BitisTarihi.TabIndex = 12;
        this.BitisTarihi.Visible = true;

        this.BaslangicTarihi = new TTVisual.TTDateTimePicker();
        this.BaslangicTarihi.Format = DateTimePickerFormat.Short;
        this.BaslangicTarihi.Name = i18n("M11571", "BaslangicTarihi");
        this.BaslangicTarihi.TabIndex = 12;
        this.BaslangicTarihi.Visible = true;

        this.lstPoliclinic = new TTVisual.TTObjectListBox();
        this.lstPoliclinic.ListDefName = "PoliclinicListDefinition";
        this.lstPoliclinic.ListFilterExpression = "MHRSCODE IS NOT NULL AND MHRSALTKLINIKKODU IS NOT NULL";
        this.lstPoliclinic.Name = "lstPoliclinic";
        this.lstPoliclinic.TabIndex = 5;
        this.lstPoliclinic.Visible = true;

        this.lstPoliclinicCetvelsorgula = new TTVisual.TTObjectListBox();
        this.lstPoliclinicCetvelsorgula.ListDefName = "PoliclinicListDefinition";
        this.lstPoliclinicCetvelsorgula.ListFilterExpression = "MHRSCODE IS NOT NULL AND MHRSALTKLINIKKODU IS NOT NULL";
        this.lstPoliclinicCetvelsorgula.Name = "lstPoliclinic";
        this.lstPoliclinicCetvelsorgula.TabIndex = 5;
        this.lstPoliclinicCetvelsorgula.Visible = true;

        this.listDoctor = new TTVisual.TTObjectListBox();
        this.listDoctor.ListDefName = "DoctorListDefinition";
        this.listDoctor.Name = "listDoctor";
        this.listDoctor.TabIndex = 5;
        this.listDoctor.Visible = true;

        this.listDoctorCetvelsorgula = new TTVisual.TTObjectListBox();
        this.listDoctorCetvelsorgula.ListDefName = "DoctorListDefinition";
        this.listDoctorCetvelsorgula.Name = "listDoctorCetvelsorgula";
        this.listDoctorCetvelsorgula.TabIndex = 5;
        this.listDoctorCetvelsorgula.Visible = true;

        this.gridSchedule = new TTVisual.TTGrid();
        this.gridSchedule.AllowUserToDeleteRows = false;
        this.gridSchedule.AllowUserToAddRows = false;
        this.gridSchedule.Name = "gridSchedule";
        this.gridSchedule.TabIndex = 1;
        this.gridSchedule.Height = "600";

        this.txPoliclinic = new TTVisual.TTTextBoxColumn();
        this.txPoliclinic.DataMember = "PoliklinikName";
        this.txPoliclinic.DisplayIndex = 0;
        this.txPoliclinic.HeaderText = i18n("M20431", "Poliklinik");
        this.txPoliclinic.Name = "txPoliclinic";
        this.txPoliclinic.ReadOnly = true;
        this.txPoliclinic.Width = 250;

        this.txtDoctor = new TTVisual.TTTextBoxColumn();
        this.txtDoctor.DataMember = "Doktor";
        this.txtDoctor.DisplayIndex = 1;
        this.txtDoctor.HeaderText = "Doktor";
        this.txtDoctor.Name = "txtDoctor";
        this.txtDoctor.ReadOnly = true;
        this.txtDoctor.Width = 250;

        this.txtBaslangicTarihi = new TTVisual.TTTextBoxColumn();
        this.txtBaslangicTarihi.DataMember = i18n("M11571", "BaslangicTarihi");
        this.txtBaslangicTarihi.DisplayIndex = 1;
        this.txtBaslangicTarihi.HeaderText = i18n("M11637", "Başlangıç Tarihi");
        this.txtBaslangicTarihi.Name = "txtBaslangicTarihi";
        this.txtBaslangicTarihi.ReadOnly = true;
        this.txtBaslangicTarihi.Width = 100;

        this.txtBitisTarihi = new TTVisual.TTTextBoxColumn();
        this.txtBitisTarihi.DataMember = "BitisTarihi";
        this.txtBitisTarihi.DisplayIndex = 1;
        this.txtBitisTarihi.HeaderText = i18n("M11939", "Bitiş Tarihi");
        this.txtBitisTarihi.Name = "txtBitisTarihi";
        this.txtBitisTarihi.ReadOnly = true;
        this.txtBitisTarihi.Width = 100;

        this.txtKesinlesmeHatasi = new TTVisual.TTTextBoxColumn();
        this.txtKesinlesmeHatasi.DataMember = i18n("M17501", "KesinlesmeHatasi");
        this.txtKesinlesmeHatasi.DisplayIndex = 1;
        this.txtKesinlesmeHatasi.HeaderText = i18n("M17505", "Kesinleşme Hatası");
        this.txtKesinlesmeHatasi.Name = "txtKesinlesmeHatasi";
        this.txtKesinlesmeHatasi.ReadOnly = true;
        this.txtKesinlesmeHatasi.Width = 500;

        this.ckcKesinlesti = new TTVisual.TTCheckBoxColumn();
        this.ckcKesinlesti.DataMember = i18n("M17502", "Kesinlesti");
        this.ckcKesinlesti.DisplayIndex = 2;
        this.ckcKesinlesti.HeaderText = i18n("M17502", "Kesinlesti");
        this.ckcKesinlesti.Name = "ckcKesinlesti";
        this.ckcKesinlesti.Width = 120;
        this.ckcKesinlesti.ReadOnly = true;

        this.gridMHRSHekimColumns = [this.txtHekimEklePoliklinik, this.txtHekimEkleHekim, this.txtHekimEkleBilgi];
        this.gridMHRSyeEklenenPolikliniklerColumns = [this.txtMHRSyeEklenenPoliklinic, this.txtMHRSyeEklendi];
        this.gridMHRSPoliklinicColumns = [this.txtMHRSPoliklinic, this.txtMHRSPoliklinicMHRSClinic, this.ckcMHRSyeGonder];
        this.gridMHRSyeEklenenAltPolikliniklerColumns = [this.txtMHRSyeEklenenAltPoliklinic, this.txtMHRSyeEklendiAltKlinik];
        this.gridScheduleColumns = [this.txPoliclinic, this.txtDoctor, this.txtBaslangicTarihi, this.txtBitisTarihi, this.ckcKesinlesti, this.txtKesinlesmeHatasi];
        this.tbMHRSIslemleri.Controls = [this.tabPageRandevuPlanlariSorgulama, this.tabPageKlinikHekimBildirimi];
        this.tabPageRandevuPlanlariSorgulama.Controls = [this.ttlabel1];
        this.tabPageKlinikHekimBildirimi.Controls = [this.btnSetMHRSClinicCode, this.btnHekimEkle, this.gridMHRSHekim, this.btnKlinikEkle, this.gridMHRSyeEklenenPoliklinikler, this.gridMHRSPoliklinic, this.btnAltKlinikEkle, this.gridMHRSyeEklenenAltPoliklinikler];
        this.Controls = [this.listDoctorCetvelsorgula, this.tbMHRSIslemleri, this.tabPageRandevuPlanlariSorgulama, this.ttlabel1, this.tabPageKlinikHekimBildirimi, this.btnSetMHRSClinicCode, this.btnHekimEkle, this.gridMHRSHekim, this.txtHekimEklePoliklinik, this.txtHekimEkleHekim, this.txtHekimEkleBilgi, this.btnKlinikEkle, this.gridMHRSyeEklenenPoliklinikler, this.txtMHRSyeEklenenPoliklinic, this.txtMHRSyeEklendi, this.gridMHRSPoliklinic, this.txtMHRSPoliklinic, this.txtMHRSPoliklinicMHRSClinic, this.ckcMHRSyeGonder, this.btnAltKlinikEkle, this.gridMHRSyeEklenenAltPoliklinikler, this.txtMHRSyeEklenenAltPoliklinic, this.txtMHRSyeEklendiAltKlinik];

    }
    public CetvelSorgulamaDataSource: Array<CetvelSorgulamaReturnData> = Array<CetvelSorgulamaReturnData>();

    //public cetvelId: number;
    //public cetvelDurumu: string;
    //public cetvelTipi: string;
    //public aksiyonId: number;
    //public baslangicZamani: string;
    //public bitisZamani: string;
    //public klinikKodu: number;
    //public klinikAdi: string;
    //public muayeneYeriId: number;
    //public muayeneYeriAdi: string;
    //public randevuSuresi: number;
    //public slotHastaSayisi: number;
    //public ikOzelDurum: string; 

    public CetvelSorgulamaColumns =
        [
            {
                caption: 'Cetvel Durumu',
                dataField: 'cetvelDurumu',
                width: 150,
                allowEditing: false
            },
            {
                caption: 'Cetvel Tipi',
                dataField: 'cetvelTipi',
                width: 150,
                allowEditing: false

            },
            {
                caption: 'Başlangıç Zamanı',
                dataField: 'baslangicZamani',
                width: 165,
                allowEditing: false
            },
            {
                caption: 'Bitiş Zamanı',
                dataField: 'bitisZamani',
                width: 165,
                allowEditing: false
            }, {
                caption: 'Randevu Süresi',
                dataField: 'randevuSuresi',
                width: 150,
                allowEditing: false
            }, {
                caption: 'Slot Hasta Sayısı',
                dataField: 'slotHastaSayisi',
                width: 150,
                allowEditing: false
            }, {
                caption: 'Klinik Kodu',
                dataField: 'klinikKodu',
                width: 100,
                allowEditing: false
            },{
                caption: 'Klinik Adı',
                dataField: 'klinikAdi',
                width: 200,
                allowEditing: false
            }, {
                caption: 'Muayene Yeri',
                dataField: 'muayeneYeriAdi',
                width: 200,
                allowEditing: false
            },{
                caption: 'Atlas Durumu',
                dataField: 'CetvelKayitliMi',
                width: 200,
                allowEditing: false
            },{
                "caption": "Kaydet",
                width: 50,
                allowSorting: false,
                allowEditing: false,
                cellTemplate: "saveScheduleTemplate"

            }

        ];
    async CetvelSorgula() {

        let apiUrl: string = '/api/MHRSYonetimService/MHRSCetvelSorgula';


        this.httpService.post<Array<CetvelSorgulamaReturnData>>(apiUrl, this.cetvelSorgulaViewModel).then(response => {
            let result = <Array<CetvelSorgulamaReturnData>>response;

            this.CetvelSorgulamaDataSource = result;
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
            console.log(error);
        });


        //let result = <Array<CetvelSorgulamaReturnData>>await this.httpService.post('/api/MHRSYonetimService/MHRSCetvelSorgula', this.cetvelSorgulaViewModel);
    
    }

    public async SaveSchedule(row: CetvelSorgulamaReturnData): Promise<any> {
        let that = this;

        let apiUrl: string = '/api/MHRSYonetimService/SaveSchedule';
        this.httpService.post<any>(apiUrl, row).then(response => {
            this.CetvelSorgula();
        }).catch(error => {
            console.log(error);
        });
      




    }

    public _searchType = [

        {
            Name: "Doktora göre sorgula",
            ObjectID: 0
        },
        {
            Name: "Birime göre sorgula",
            ObjectID: 1
        }
    ];

    onSearchTypeChanged(e) {
        if (e.value == 1) {
           // this._subepisodedateReadOnly = true;
            this.cetvelSorgulaViewModel.SearchType = 1; //Birim
        } else {
          //  this._subepisodedateReadOnly = false;
            this.cetvelSorgulaViewModel.SearchType = 0; //Doktor
        }



    }


    public onBirimChangedCetvelSorgula(event): void {
        if (event != null) {
            if (this.cetvelSorgulaViewModel != null && this.cetvelSorgulaViewModel.Birim != event) {
                this.cetvelSorgulaViewModel.Birim = event;
            }
        }
    }
}
