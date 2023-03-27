//$8FB36BAA
import { Component, Input, EventEmitter, Output  } from '@angular/core';
import { VaccineApplicationFormViewModel, ATSSorgulaInput, ATSSorgulaResult, ATSBildirimResult, BarcodeShortInfo} from "./VaccineApplicationFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SKRSAsiKodu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsininDozu } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { VaccineDetails } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsininUygulamaSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsiOzelDurumNedeni } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsiUygulamaYeri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsiYapilmamaDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsiYapilmamaNedeni } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsininSaglandigiKaynak } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { SKRSASIISLEMTURU } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKurumlar } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";


import { VaccineFollowUp } from 'NebulaClient/Model/AtlasClientModel';
import { ConfirmObj } from "./VaccineFollowUpFormViewModel";

@Component({
    selector: 'VaccineApplicationForm',
    templateUrl: './VaccineApplicationForm.html',
    providers: [MessageService]
})
export class VaccineApplicationForm extends TTVisual.TTForm  {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    ASIEOrtayaCikisTarihi: TTVisual.ITTDateTimePicker;
    //AsiAntiSerumuKarekodu: TTVisual.ITTTextBox;
    AsiKarekodu: TTVisual.ITTTextBox;
    IslemYapan: TTVisual.ITTTextBox;
    BilgiAlinanKisiAdiSoyadi: TTVisual.ITTTextBox;
    BilgiAlinanKisiTel: TTVisual.ITTTextBox;
    AsininSonKullanmaTarihi: TTVisual.ITTDateTimePicker;
    //AsiSulandiriciKarekodu: TTVisual.ITTTextBox;
    ATS_Bildirim: TTVisual.ITTButton;
    ATS_Sorgula: TTVisual.ITTButton;
    Barkod: TTVisual.ITTTextBox;
    BildirimDurumu: TTVisual.ITTTextBox;
    Date: TTVisual.ITTDateTimePicker;
    DisMerkez: TTVisual.ITTTextBox;
    DisMerkezMi: TTVisual.ITTCheckBox;
    GeziciHizmetMi: TTVisual.ITTCheckBox;
    GroupSeperator1: TTVisual.ITTGroupBox;
    KirilimBilgisi: TTVisual.ITTTextBox;
    labelApplicationDate: TTVisual.ITTLabel;
    //labelAsiAntiSerumuKarekodu: TTVisual.ITTLabel;
    labelAsiKarekodu: TTVisual.ITTLabel;
    labelAsininSonKullanmaTarihi: TTVisual.ITTLabel;
    //labelAsiSulandiriciKarekodu: TTVisual.ITTLabel;
    labelBarkod: TTVisual.ITTLabel;
    labelBildirimDurumu: TTVisual.ITTLabel;
    labelDate: TTVisual.ITTLabel;
    labelDisMerkez: TTVisual.ITTLabel;
    labelKirilimBilgisi: TTVisual.ITTLabel;
    labelNotes: TTVisual.ITTLabel;
    labelPartiNumarasi: TTVisual.ITTLabel;
    labelResUser: TTVisual.ITTLabel;
    labelResUser1: TTVisual.ITTLabel;
    labelSeriNumarasi: TTVisual.ITTLabel;
    labelSKRSAsiKodu: TTVisual.ITTLabel;
    labelSKRSAsininDozu: TTVisual.ITTLabel;
    labelSKRSAsininSaglandigiKaynak: TTVisual.ITTLabel;
    labelSKRSAsininUygulamaSekli: TTVisual.ITTLabel;
    labelSKRSAsiOzelDurumNedeni: TTVisual.ITTLabel;
    labelSKRSAsiSonrasiIstenmeyenEtki: TTVisual.ITTLabel;
    labelSKRSAsiUygulamaYeri: TTVisual.ITTLabel;
    labelSKRSAsiYapilmamaDurumu: TTVisual.ITTLabel;
    labelSKRSAsiYapilmamaNedeni: TTVisual.ITTLabel;
    labelSorguNumarasi: TTVisual.ITTLabel;
    labelSorguSonucu: TTVisual.ITTLabel;
    labelVaccinePostponeTime: TTVisual.ITTLabel;
    labelVaccineState: TTVisual.ITTLabel;
    Notes: TTVisual.ITTTextBox;
    PartiNumarasi: TTVisual.ITTTextBox;
    private _karekod: string = "";
    public AsiKodu: string;
    public Barkod1: string;
    public BirimKirilimDegerleri: string;
    public Doz: number;
    public GezisiHizmetMi: boolean;
    public Hl7Kodu: string;
    public Kirilim: string;
    public PartiNo: string;
    public SeriNo: string;
    public SonKullanmaTarihi: Date;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    //public TasimaBirimTipi: ETasimaBirimiTipi;
    ResUser: TTVisual.ITTObjectListBox;
    ResUser1: TTVisual.ITTObjectListBox;
    SeriNumarasi: TTVisual.ITTTextBox;
    SKRSAsiKodu: TTVisual.ITTObjectListBox;
    SKRSAsininDozu: TTVisual.ITTObjectListBox;
    SKRSAsininSaglandigiKaynak: TTVisual.ITTObjectListBox;
    SKRSAsininUygulamaSekli: TTVisual.ITTObjectListBox;
    SKRSAsiOzelDurumNedeni: TTVisual.ITTObjectListBox;
    SKRSASIISLEMTURU: TTVisual.ITTObjectListBox;
    SKRSKurumlar: TTVisual.ITTObjectListBox;
    SKRSAsiSonrasiIstenmeyenEtki: TTVisual.ITTObjectListBox;
    SKRSAsiUygulamaYeri: TTVisual.ITTObjectListBox;
    SKRSAsiYapilmamaDurumu: TTVisual.ITTObjectListBox;
    SKRSAsiYapilmamaNedeni: TTVisual.ITTObjectListBox;
    SorguNumarasi: TTVisual.ITTTextBox;
    SorguSonucu: TTVisual.ITTTextBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    VaccinePostponeTime: TTVisual.ITTTextBox;
    VaccineState: TTVisual.ITTEnumComboBox;
    public vaccineApplicationFormViewModel: VaccineApplicationFormViewModel = new VaccineApplicationFormViewModel();
   // _VaccineFollowupEA: VaccineFollowUp = new VaccineFollowUp();

    @Output() refreshDetails: EventEmitter<number> = new EventEmitter<number>();
    @Input() _VaccineFollowupEA: VaccineFollowUp;
    @Input() _PatientID: Guid;
    @Input() set vaccineDetail(value: VaccineDetails) {

        this._TTObject = value;
        this.vaccineApplicationFormViewModel = new VaccineApplicationFormViewModel();
        this._ViewModel = this.vaccineApplicationFormViewModel;
        this.vaccineApplicationFormViewModel._VaccineDetails = this._TTObject as VaccineDetails;
        if (this._TTObject.ObjectID != undefined && this._TTObject.ObjectID != null) {
            this.ObjectID = this._TTObject.ObjectID;
            this.load();
        }

    }

    @Input() set _IsReadOnly(value: boolean) {

        this.ReadOnly = value;

    }
    get _IsReadOnly() {

        return this.ReadOnly;

    }

    public get _VaccineDetails(): VaccineDetails {
        return this._TTObject as VaccineDetails;
    }
    private VaccineApplicationForm_DocumentUrl: string = '/api/VaccineDetailsService/VaccineApplicationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("VACCINEDETAILS", "VaccineApplicationForm");
        this._DocumentServiceUrl = this.VaccineApplicationForm_DocumentUrl;
        //this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****



    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);

    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new VaccineDetails();
        this.vaccineApplicationFormViewModel = new VaccineApplicationFormViewModel();
        this._ViewModel = this.vaccineApplicationFormViewModel;
        this.vaccineApplicationFormViewModel._VaccineDetails = this._TTObject as VaccineDetails;
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiSonrasiIstenmeyenEtki = new SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiOzelDurumNedeni = new SKRSAsiOzelDurumNedeni();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiKodu = new SKRSAsiKodu();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininDozu = new SKRSAsininDozu();
        this.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleNurse = new ResUser();
        this.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleDoctor = new ResUser();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininUygulamaSekli = new SKRSAsininUygulamaSekli();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininSaglandigiKaynak = new SKRSAsininSaglandigiKaynak();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiUygulamaYeri = new SKRSAsiUygulamaYeri();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiYapilmamaNedeni = new SKRSAsiYapilmamaNedeni();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiYapilmamaDurumu = new SKRSAsiYapilmamaDurumu();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSASIISLEMTURU = new SKRSASIISLEMTURU();
        this.vaccineApplicationFormViewModel._VaccineDetails.SKRSKurumlar = new SKRSKurumlar();
    }

    protected loadViewModel() {
        let that = this;
        that.vaccineApplicationFormViewModel = this._ViewModel as VaccineApplicationFormViewModel;
        that._TTObject = this.vaccineApplicationFormViewModel._VaccineDetails;
        if (this.vaccineApplicationFormViewModel == null)
            this.vaccineApplicationFormViewModel = new VaccineApplicationFormViewModel();
        if (this.vaccineApplicationFormViewModel._VaccineDetails == null)
            this.vaccineApplicationFormViewModel._VaccineDetails = new VaccineDetails();
        let sKRSAsiSonrasiIstenmeyenEtkiObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSAsiSonrasiIstenmeyenEtki"];
        if (sKRSAsiSonrasiIstenmeyenEtkiObjectID != null && (typeof sKRSAsiSonrasiIstenmeyenEtkiObjectID === 'string')) {
            let sKRSAsiSonrasiIstenmeyenEtki = that.vaccineApplicationFormViewModel.SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtkis.find(o => o.ObjectID.toString() === sKRSAsiSonrasiIstenmeyenEtkiObjectID.toString());
             if (sKRSAsiSonrasiIstenmeyenEtki) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiSonrasiIstenmeyenEtki = sKRSAsiSonrasiIstenmeyenEtki;
            }
        }
        let SKRSASIISLEMTURUObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSASIISLEMTURU"];
        if (SKRSASIISLEMTURUObjectID != null && (typeof SKRSASIISLEMTURUObjectID === 'string')) {
            let sKRSASIISLEMTURU = that.vaccineApplicationFormViewModel.SKRSASIISLEMTURUs.find(o => o.ObjectID.toString() === SKRSASIISLEMTURUObjectID.toString());
             if (sKRSASIISLEMTURU) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSASIISLEMTURU = sKRSASIISLEMTURU;
            }
        }
        let SKRSKurumlarObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSKurumlar"];
        if (SKRSKurumlarObjectID != null && (typeof SKRSKurumlarObjectID === 'string')) {
            let sKRSKurumlar = that.vaccineApplicationFormViewModel.SKRSKurumlars.find(o => o.ObjectID.toString() === SKRSKurumlarObjectID.toString());
             if (sKRSKurumlar) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSKurumlar = sKRSKurumlar;
            }
        }
        let sKRSAsiOzelDurumNedeniObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSAsiOzelDurumNedeni"];
        if (sKRSAsiOzelDurumNedeniObjectID != null && (typeof sKRSAsiOzelDurumNedeniObjectID === 'string')) {
            let sKRSAsiOzelDurumNedeni = that.vaccineApplicationFormViewModel.SKRSAsiOzelDurumNedenis.find(o => o.ObjectID.toString() === sKRSAsiOzelDurumNedeniObjectID.toString());
             if (sKRSAsiOzelDurumNedeni) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiOzelDurumNedeni = sKRSAsiOzelDurumNedeni;
            }
        }
        let sKRSAsiKoduObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSAsiKodu"];
        if (sKRSAsiKoduObjectID != null && (typeof sKRSAsiKoduObjectID === 'string')) {
            let sKRSAsiKodu = that.vaccineApplicationFormViewModel.SKRSAsiKodus.find(o => o.ObjectID.toString() === sKRSAsiKoduObjectID.toString());
             if (sKRSAsiKodu) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiKodu = sKRSAsiKodu;
            }
        }
        let sKRSAsininDozuObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSAsininDozu"];
        if (sKRSAsininDozuObjectID != null && (typeof sKRSAsininDozuObjectID === 'string')) {
            let sKRSAsininDozu = that.vaccineApplicationFormViewModel.SKRSAsininDozus.find(o => o.ObjectID.toString() === sKRSAsininDozuObjectID.toString());
             if (sKRSAsininDozu) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininDozu = sKRSAsininDozu;
            }
        }
        let responsibleNurseObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["ResponsibleNurse"];
        if (responsibleNurseObjectID != null && (typeof responsibleNurseObjectID === 'string')) {
            let responsibleNurse = that.vaccineApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleNurseObjectID.toString());
             if (responsibleNurse) {
                that.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleNurse = responsibleNurse;
            }
        }
        let responsibleDoctorObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["ResponsibleDoctor"];
        if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === 'string')) {
            let responsibleDoctor = that.vaccineApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
             if (responsibleDoctor) {
                that.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleDoctor = responsibleDoctor;
            }
        }
        let sKRSAsininUygulamaSekliObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSAsininUygulamaSekli"];
        if (sKRSAsininUygulamaSekliObjectID != null && (typeof sKRSAsininUygulamaSekliObjectID === 'string')) {
            let sKRSAsininUygulamaSekli = that.vaccineApplicationFormViewModel.SKRSAsininUygulamaSeklis.find(o => o.ObjectID.toString() === sKRSAsininUygulamaSekliObjectID.toString());
             if (sKRSAsininUygulamaSekli) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininUygulamaSekli = sKRSAsininUygulamaSekli;
            }
        }
        let sKRSAsininSaglandigiKaynakObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSAsininSaglandigiKaynak"];
        if (sKRSAsininSaglandigiKaynakObjectID != null && (typeof sKRSAsininSaglandigiKaynakObjectID === 'string')) {
            let sKRSAsininSaglandigiKaynak = that.vaccineApplicationFormViewModel.SKRSAsininSaglandigiKaynaks.find(o => o.ObjectID.toString() === sKRSAsininSaglandigiKaynakObjectID.toString());
            if (sKRSAsininSaglandigiKaynak) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininSaglandigiKaynak = sKRSAsininSaglandigiKaynak;
            }
        }
        let sKRSAsiUygulamaYeriObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSAsiUygulamaYeri"];
        if (sKRSAsiUygulamaYeriObjectID != null && (typeof sKRSAsiUygulamaYeriObjectID === 'string')) {
            let sKRSAsiUygulamaYeri = that.vaccineApplicationFormViewModel.SKRSAsiUygulamaYeris.find(o => o.ObjectID.toString() === sKRSAsiUygulamaYeriObjectID.toString());
             if (sKRSAsiUygulamaYeri) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiUygulamaYeri = sKRSAsiUygulamaYeri;
            }
        }
        let sKRSAsiYapilmamaNedeniObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSAsiYapilmamaNedeni"];
        if (sKRSAsiYapilmamaNedeniObjectID != null && (typeof sKRSAsiYapilmamaNedeniObjectID === 'string')) {
            let sKRSAsiYapilmamaNedeni = that.vaccineApplicationFormViewModel.SKRSAsiYapilmamaNedenis.find(o => o.ObjectID.toString() === sKRSAsiYapilmamaNedeniObjectID.toString());
             if (sKRSAsiYapilmamaNedeni) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiYapilmamaNedeni = sKRSAsiYapilmamaNedeni;
            }
        }
        let sKRSAsiYapilmamaDurumuObjectID = that.vaccineApplicationFormViewModel._VaccineDetails["SKRSAsiYapilmamaDurumu"];
        if (sKRSAsiYapilmamaDurumuObjectID != null && (typeof sKRSAsiYapilmamaDurumuObjectID === 'string')) {
            let sKRSAsiYapilmamaDurumu = that.vaccineApplicationFormViewModel.SKRSAsiYapilmamaDurumus.find(o => o.ObjectID.toString() === sKRSAsiYapilmamaDurumuObjectID.toString());
             if (sKRSAsiYapilmamaDurumu) {
                that.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiYapilmamaDurumu = sKRSAsiYapilmamaDurumu;
            }
        }
    }


    //async ngOnInit() {
    //       await this.load();
    //}

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.ApplicationDate != event) {
                this._VaccineDetails.ApplicationDate = event;
            }
        }
    }

    public onASIEOrtayaCikisTarihiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.ASIEOrtayaCikisTarihi != event) {
                this._VaccineDetails.ASIEOrtayaCikisTarihi = event;
            }
        }
    }

    public keyCodeArray: Array<number> = [];

    public charCodeArray: Array<string> = [];

    public onAsiKarekoduChanged(event): void {
        this.keyCodeArray.push(event.keyCode);
        this.charCodeArray.push(event.key);

        //Bu alan karekod cihazından okutulacak
        //Karekodu özel karekter ile birlikte oluştur (this._karekod)!!!   enter karekterini alabiliyorsak eger direk ats sorgulayı çağır alamıyorsak butonla devam edecek
        let keyCode: any = event.keyCode;
        if (keyCode == undefined) {
            this._karekod = "";
            return;
        }
        if (keyCode == 8)//backspace
        {
            this._karekod = "";
            return;
        }
        if ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 48 && keyCode <= 57)) {
            this._karekod += event.key;
        }
        else if (keyCode == 29 || (keyCode >= 100 && keyCode != 131)) {
            this._karekod += "|";
        } else if (keyCode == 13) { // Enter karekteri
            this.ParseBarcode();
        }


    }

    public onIslemYapanChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.IslemYapan != event) {
                this._VaccineDetails.IslemYapan = event;
            }
        }
    }

    public onBilgiAlinanKisiTelChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.BilgiAlinanKisiTel != event) {
                this._VaccineDetails.BilgiAlinanKisiTel = event;
            }
        }
    }

    public onBilgiAlinanKisiAdiSoyadiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.BilgiAlinanKisiAdiSoyadi != event) {
                this._VaccineDetails.BilgiAlinanKisiAdiSoyadi = event;
            }
        }
    }

    public onAsininSonKullanmaTarihiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.AsininSonKullanmaTarihi != event) {
                this._VaccineDetails.AsininSonKullanmaTarihi = event;
            }
        }
    }

    public onBarkodChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.Barkod != event) {
                this._VaccineDetails.Barkod = event;
            }
        }
    }

    public onBildirimDurumuChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.BildirimDurumu != event) {
                this._VaccineDetails.BildirimDurumu = event;
            }
        }
    }

    public onDateChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.Date != event) {
                this._VaccineDetails.Date = event;
            }
        }
    }

    public onDisMerkezChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.DisMerkez != event) {
                this._VaccineDetails.DisMerkez = event;
            }
        }
    }

    public onDisMerkezMiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.DisMerkezMi != event) {
                this._VaccineDetails.DisMerkezMi = event;
            }
        }
    }

    public onGeziciHizmetMiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.GeziciHizmetMi != event) {
                this._VaccineDetails.GeziciHizmetMi = event;
            }
        }
    }

    public onKirilimBilgisiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.KirilimBilgisi != event) {
                this._VaccineDetails.KirilimBilgisi = event;
            }
        }
    }

    public onNotesChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.Notes != event) {
                this._VaccineDetails.Notes = event;
            }
        }
    }

    public onPartiNumarasiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.PartiNumarasi != event) {
                this._VaccineDetails.PartiNumarasi = event;
            }
        }
    }

    public onResUser1Changed(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.ResponsibleDoctor != event) {
                this._VaccineDetails.ResponsibleDoctor = event;
            }
        }
    }

    public onResUserChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.ResponsibleNurse != event) {
                this._VaccineDetails.ResponsibleNurse = event;
            }
        }
    }

    public onSeriNumarasiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SeriNumarasi != event) {
                this._VaccineDetails.SeriNumarasi = event;
            }
        }
    }

    public onSKRSAsiKoduChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSAsiKodu != event) {
                this._VaccineDetails.SKRSAsiKodu = event;
            }
        }
    }

    public onSKRSAsininDozuChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSAsininDozu != event) {
                this._VaccineDetails.SKRSAsininDozu = event;
            }

            if (event.KODU == 9) {//Doz bilgisi Özel durum aşı dozu ise özel durum nedeni zorunlu
                this.SKRSAsiOzelDurumNedeni.BackColor = "#ffeee5";
                this.SKRSAsiOzelDurumNedeni.Required = true;
            } else
            {
                this.SKRSAsiOzelDurumNedeni.BackColor = "#ffffff";
                this.SKRSAsiOzelDurumNedeni.Required = false;
            }
        } else {
            this.SKRSAsiOzelDurumNedeni.BackColor = "#ffffff";
            this.SKRSAsiOzelDurumNedeni.Required = false;
        }
    }

    public onSKRSASIISLEMTURUChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSASIISLEMTURU != event) {
                this._VaccineDetails.SKRSASIISLEMTURU = event;
            }

            if (event.KODU == 2)//Beyana dayalı ise İzlemin yapıldığı yer,işlem yapan, bilgi alınan kişi adı soyadı ve teli zorunlu olmalı
            {
                this.SKRSAsiOzelDurumNedeni.BackColor = "#ffeee5";
                this.SKRSKurumlar.BackColor = "#ffeee5";
                this.IslemYapan.BackColor = "#ffeee5";
                this.BilgiAlinanKisiAdiSoyadi.BackColor = "#ffeee5";
                this.BilgiAlinanKisiTel.BackColor = "#ffeee5";
            } else
            {
                this.SKRSAsiOzelDurumNedeni.BackColor = "#ffffff";
                this.SKRSKurumlar.BackColor = "#ffffff";
                this.IslemYapan.BackColor = "#ffffff";
                this.BilgiAlinanKisiAdiSoyadi.BackColor = "#ffffff";
                this.BilgiAlinanKisiTel.BackColor = "#ffffff";
            }
        } else {
            this.SKRSAsiOzelDurumNedeni.BackColor = "#ffffff";
            this.SKRSKurumlar.BackColor = "#ffffff";
            this.IslemYapan.BackColor = "#ffffff";
            this.BilgiAlinanKisiAdiSoyadi.BackColor = "#ffffff";
            this.BilgiAlinanKisiTel.BackColor = "#ffffff";
        }
    }

    public onSKRSKurumlarChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSKurumlar != event) {
                this._VaccineDetails.SKRSKurumlar = event;
            }
        }
    }

    public onSKRSAsininUygulamaSekliChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSAsininUygulamaSekli != event) {
                this._VaccineDetails.SKRSAsininUygulamaSekli = event;
            }
        }
    }

    public onSKRSAsiOzelDurumNedeniChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSAsiOzelDurumNedeni != event) {
                this._VaccineDetails.SKRSAsiOzelDurumNedeni = event;
            }
        }
    }

    public onSKRSAsiSonrasiIstenmeyenEtkiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSAsiSonrasiIstenmeyenEtki != event) {
                this._VaccineDetails.SKRSAsiSonrasiIstenmeyenEtki = event;
            }
        }
    }

    public onSKRSAsiUygulamaYeriChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSAsiUygulamaYeri != event) {
                this._VaccineDetails.SKRSAsiUygulamaYeri = event;
            }
        }
    }

    public onSKRSAsiYapilmamaDurumuChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSAsiYapilmamaDurumu != event) {
                this._VaccineDetails.SKRSAsiYapilmamaDurumu = event;
            }
        }
    }

    public onSKRSAsiYapilmamaNedeniChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSAsiYapilmamaNedeni != event) {
                this._VaccineDetails.SKRSAsiYapilmamaNedeni = event;
            }
        }
    }

    public onSorguNumarasiChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SorguNumarasi != event) {
                this._VaccineDetails.SorguNumarasi = event;
            }
        }
    }

    public onSorguSonucuChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SorguSonucu != event) {
                this._VaccineDetails.SorguSonucu = event;
            }
        }
    }

    public onVaccinePostponeTimeChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.VaccinePostponeTime != event) {
                this._VaccineDetails.VaccinePostponeTime = event;
            }
        }
    }

    public onVaccineStateChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.VaccineState != event) {
                this._VaccineDetails.VaccineState = event;
            }
        }
    }

    public onSKRSAsininSaglandigiKaynakChanged(event): void {
        if (event != null) {
            if (this._VaccineDetails != null && this._VaccineDetails.SKRSAsininSaglandigiKaynak != event) {
                this._VaccineDetails.SKRSAsininSaglandigiKaynak = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.Date, "Value", this.__ttObject, "Date");
        //redirectProperty(this.AsiAntiSerumuKarekodu, "Text", this.__ttObject, "AsiAntiSerumuKarekodu");
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        //redirectProperty(this.AsiSulandiriciKarekodu, "Text", this.__ttObject, "AsiSulandiriciKarekodu");
        redirectProperty(this.GeziciHizmetMi, "Value", this.__ttObject, "GeziciHizmetMi");
        redirectProperty(this.AsiKarekodu, "Text", this.__ttObject, "AsiKarekodu");
        redirectProperty(this.IslemYapan, "Text", this.__ttObject, "IslemYapan");
        redirectProperty(this.BilgiAlinanKisiAdiSoyadi, "Text", this.__ttObject, "BilgiAlinanKisiAdiSoyadi");
        redirectProperty(this.BilgiAlinanKisiTel, "Text", this.__ttObject, "BilgiAlinanKisiTel");
        redirectProperty(this.AsininSonKullanmaTarihi, "Value", this.__ttObject, "AsininSonKullanmaTarihi");
        redirectProperty(this.Barkod, "Text", this.__ttObject, "Barkod");
        redirectProperty(this.SeriNumarasi, "Text", this.__ttObject, "SeriNumarasi");
        redirectProperty(this.PartiNumarasi, "Text", this.__ttObject, "PartiNumarasi");
        redirectProperty(this.KirilimBilgisi, "Text", this.__ttObject, "KirilimBilgisi");
        redirectProperty(this.SorguNumarasi, "Text", this.__ttObject, "SorguNumarasi");
        redirectProperty(this.SorguSonucu, "Text", this.__ttObject, "SorguSonucu");
        redirectProperty(this.BildirimDurumu, "Text", this.__ttObject, "BildirimDurumu");
        redirectProperty(this.DisMerkezMi, "Value", this.__ttObject, "DisMerkezMi");
        redirectProperty(this.DisMerkez, "Text", this.__ttObject, "DisMerkez");
        redirectProperty(this.Notes, "Text", this.__ttObject, "Notes");
        redirectProperty(this.VaccineState, "Value", this.__ttObject, "VaccineState");
        redirectProperty(this.VaccinePostponeTime, "Text", this.__ttObject, "VaccinePostponeTime");
        redirectProperty(this.ASIEOrtayaCikisTarihi, "Value", this.__ttObject, "ASIEOrtayaCikisTarihi");
    }

    public initFormControls(): void {
        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Text = i18n("M11211", "Aşı Sonrası İstenmeyen Etki");
        this.ttgroupbox3.Name = "ttgroupbox3";
        this.ttgroupbox3.TabIndex = 52;

        this.labelSKRSAsiSonrasiIstenmeyenEtki = new TTVisual.TTLabel();
        this.labelSKRSAsiSonrasiIstenmeyenEtki.Text = "Bildirimi Zorunlu Aşı Sonrası Istenmeyen Etki";
        this.labelSKRSAsiSonrasiIstenmeyenEtki.Name = "labelSKRSAsiSonrasiIstenmeyenEtki";
        this.labelSKRSAsiSonrasiIstenmeyenEtki.TabIndex = 1;

        this.SKRSAsiSonrasiIstenmeyenEtki = new TTVisual.TTObjectListBox();
        this.SKRSAsiSonrasiIstenmeyenEtki.ListDefName = "SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtkiList";
        this.SKRSAsiSonrasiIstenmeyenEtki.Name = "SKRSAsiSonrasiIstenmeyenEtki";
        this.SKRSAsiSonrasiIstenmeyenEtki.TabIndex = 0;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M11222", "Aşı Veri Seti");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 51;

        this.labelSKRSAsiOzelDurumNedeni = new TTVisual.TTLabel();
        this.labelSKRSAsiOzelDurumNedeni.Text = i18n("M11209", "Aşı Özel Durum Nedeni");
        this.labelSKRSAsiOzelDurumNedeni.Name = "labelSKRSAsiOzelDurumNedeni";
        this.labelSKRSAsiOzelDurumNedeni.TabIndex = 54;

        this.SKRSAsiOzelDurumNedeni = new TTVisual.TTObjectListBox();
        this.SKRSAsiOzelDurumNedeni.Required = true;
        this.SKRSAsiOzelDurumNedeni.ListDefName = "SKRSAsiOzelDurumNedeniList";
        this.SKRSAsiOzelDurumNedeni.Name = "SKRSAsiOzelDurumNedeni";
        this.SKRSAsiOzelDurumNedeni.TabIndex = 53;

        this.SKRSASIISLEMTURU = new TTVisual.TTObjectListBox();
        this.SKRSASIISLEMTURU.Required = true;
        this.SKRSASIISLEMTURU.ListDefName = "SKRSASIISLEMTURUList";
        this.SKRSASIISLEMTURU.Name = "SKRSASIISLEMTURU";
        this.SKRSASIISLEMTURU.TabIndex = 53;
        this.SKRSASIISLEMTURU.BackColor = "#ffeee5";


        this.SKRSKurumlar = new TTVisual.TTObjectListBox();
        this.SKRSKurumlar.Required = true;
        this.SKRSKurumlar.ListDefName = "SKRSKurumlarList";
        this.SKRSKurumlar.Name = "SKRSKurumlar";
        this.SKRSKurumlar.TabIndex = 53;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = "ATS";
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 50;

        this.SKRSAsiKodu = new TTVisual.TTObjectListBox();
        this.SKRSAsiKodu.Required = true;
        this.SKRSAsiKodu.ListDefName = "SKRSAsiKoduList";
        this.SKRSAsiKodu.Name = "SKRSAsiKodu";
        this.SKRSAsiKodu.TabIndex = 23;
        this.SKRSAsiKodu.BackColor = "#ffeee5";

        this.labelSKRSAsiKodu = new TTVisual.TTLabel();
        this.labelSKRSAsiKodu.Text = i18n("M11207", "Aşı Kodu");
        this.labelSKRSAsiKodu.Name = "labelSKRSAsiKodu";
        this.labelSKRSAsiKodu.TabIndex = 24;

        this.BildirimDurumu = new TTVisual.TTTextBox();
        this.BildirimDurumu.BackColor = "#F0F0F0";
        this.BildirimDurumu.ReadOnly = true;
        this.BildirimDurumu.Enabled = false;
        this.BildirimDurumu.Multiline = true;
        this.BildirimDurumu.Name = "BildirimDurumu";
        this.BildirimDurumu.TabIndex = 10;

        this.SorguSonucu = new TTVisual.TTTextBox();
        this.SorguSonucu.Multiline = true;
        this.SorguSonucu.BackColor = "#F0F0F0";
        this.SorguSonucu.ReadOnly = true;
        this.SorguSonucu.Enabled = false;
        this.SorguSonucu.Name = "SorguSonucu";
        this.SorguSonucu.TabIndex = 34;

        this.ATS_Bildirim = new TTVisual.TTButton();
        this.ATS_Bildirim.Text = i18n("M23746", "Uygula ve ATS'ye Bildir");
        this.ATS_Bildirim.Name = "ATS_Bildirim";
        this.ATS_Bildirim.TabIndex = 36;

        this.labelBildirimDurumu = new TTVisual.TTLabel();
        this.labelBildirimDurumu.Text = i18n("M11779", "Bildirim Durumu");
        this.labelBildirimDurumu.Name = "labelBildirimDurumu";
        this.labelBildirimDurumu.TabIndex = 11;

        this.labelSKRSAsininDozu = new TTVisual.TTLabel();
        this.labelSKRSAsininDozu.Text = i18n("M11225", "Aşının Dozu");
        this.labelSKRSAsininDozu.Name = "labelSKRSAsininDozu";
        this.labelSKRSAsininDozu.TabIndex = 26;


        this.SorguNumarasi = new TTVisual.TTTextBox();
        this.SorguNumarasi.BackColor = "#F0F0F0";
        this.SorguNumarasi.ReadOnly = true;
        this.SorguNumarasi.Enabled = false;
        this.SorguNumarasi.Name = "SorguNumarasi";
        this.SorguNumarasi.TabIndex = 19;

        this.SKRSAsininDozu = new TTVisual.TTObjectListBox();
        this.SKRSAsininDozu.Required = true;
        this.SKRSAsininDozu.ListDefName = "SKRSAsininDozuList";
        this.SKRSAsininDozu.Name = "SKRSAsininDozu";
        this.SKRSAsininDozu.TabIndex = 25;
        this.SKRSAsininDozu.BackColor = "#ffeee5";

        this.labelSorguSonucu = new TTVisual.TTLabel();
        this.labelSorguSonucu.Text = i18n("M22120", "Sorgu Sonucu");
        this.labelSorguSonucu.Name = "labelSorguSonucu";
        this.labelSorguSonucu.TabIndex = 35;

        this.GeziciHizmetMi = new TTVisual.TTCheckBox();
        this.GeziciHizmetMi.Value = false;
        this.GeziciHizmetMi.Title = i18n("M14775", "Gezici Hizmet Mi?");
        this.GeziciHizmetMi.Name = "GeziciHizmetMi";
        this.GeziciHizmetMi.TabIndex = 12;

        this.labelAsiKarekodu = new TTVisual.TTLabel();
        this.labelAsiKarekodu.Text = i18n("M11205", "Aşı Karekodu");
        this.labelAsiKarekodu.Name = "labelAsiKarekodu";
        this.labelAsiKarekodu.TabIndex = 3;

        this.SeriNumarasi = new TTVisual.TTTextBox();
        this.SeriNumarasi.BackColor = "#F0F0F0";
        this.SeriNumarasi.ReadOnly = true;
        this.SeriNumarasi.Enabled = false;
        this.SeriNumarasi.Name = "SeriNumarasi";
        this.SeriNumarasi.TabIndex = 17;

        this.labelSorguNumarasi = new TTVisual.TTLabel();
        this.labelSorguNumarasi.Text = i18n("M22118", "Sorgu Numarası");
        this.labelSorguNumarasi.Name = "labelSorguNumarasi";
        this.labelSorguNumarasi.TabIndex = 20;

        this.AsiKarekodu = new TTVisual.TTTextBox();
        this.AsiKarekodu.Name = "AsiKarekodu";
        this.AsiKarekodu.TabIndex = 2;


        this.IslemYapan = new TTVisual.TTTextBox();
        this.IslemYapan.Name = "IslemYapan";

        this.BilgiAlinanKisiAdiSoyadi = new TTVisual.TTTextBox();
        this.BilgiAlinanKisiAdiSoyadi.Name = "BilgiAlinanKisiAdiSoyadi";

        this.BilgiAlinanKisiTel = new TTVisual.TTTextBox();
        this.BilgiAlinanKisiTel.Name = "BilgiAlinanKisiTel";

        this.KirilimBilgisi = new TTVisual.TTTextBox();
        this.KirilimBilgisi.BackColor = "#F0F0F0";
        this.KirilimBilgisi.ReadOnly = true;
        this.KirilimBilgisi.Enabled = false;
        this.KirilimBilgisi.Name = "KirilimBilgisi";
        this.KirilimBilgisi.TabIndex = 13;

        this.PartiNumarasi = new TTVisual.TTTextBox();
        this.PartiNumarasi.BackColor = "#F0F0F0";
        this.PartiNumarasi.ReadOnly = true;
        this.PartiNumarasi.Enabled = false;
        this.PartiNumarasi.Name = "PartiNumarasi";
        this.PartiNumarasi.TabIndex = 15;

        this.ATS_Sorgula = new TTVisual.TTButton();
        this.ATS_Sorgula.Text = "ATS Sorgula";
        this.ATS_Sorgula.Name = "ATS_Sorgula";
        this.ATS_Sorgula.TabIndex = 33;

        this.labelAsininSonKullanmaTarihi = new TTVisual.TTLabel();
        this.labelAsininSonKullanmaTarihi.Text = i18n("M11228", "Aşının Son Kullanma Tarihi");
        this.labelAsininSonKullanmaTarihi.Name = "labelAsininSonKullanmaTarihi";
        this.labelAsininSonKullanmaTarihi.TabIndex = 5;

        this.AsininSonKullanmaTarihi = new TTVisual.TTDateTimePicker();
        this.AsininSonKullanmaTarihi.BackColor = "#F0F0F0";
        this.AsininSonKullanmaTarihi.Format = DateTimePickerFormat.Long;
        this.AsininSonKullanmaTarihi.Enabled = false;
        this.AsininSonKullanmaTarihi.Name = "AsininSonKullanmaTarihi";
        this.AsininSonKullanmaTarihi.TabIndex = 4;

        this.Barkod = new TTVisual.TTTextBox();
        this.Barkod.BackColor = "#F0F0F0";
        this.Barkod.ReadOnly = true;
        this.Barkod.Name = "Barkod";
        this.Barkod.Enabled = false;
        this.Barkod.TabIndex = 8;

        this.labelSeriNumarasi = new TTVisual.TTLabel();
        this.labelSeriNumarasi.Text = i18n("M21642", "Seri Numarası");
        this.labelSeriNumarasi.Name = "labelSeriNumarasi";
        this.labelSeriNumarasi.TabIndex = 18;

        this.labelKirilimBilgisi = new TTVisual.TTLabel();
        this.labelKirilimBilgisi.Text = "Kırılım Bilgisi";
        this.labelKirilimBilgisi.Name = "labelKirilimBilgisi";
        this.labelKirilimBilgisi.TabIndex = 14;

        this.labelBarkod = new TTVisual.TTLabel();
        this.labelBarkod.Text = "Barkodu";
        this.labelBarkod.Name = "labelBarkod";
        this.labelBarkod.TabIndex = 9;

        this.labelPartiNumarasi = new TTVisual.TTLabel();
        this.labelPartiNumarasi.Text = i18n("M20213", "Parti Numarası");
        this.labelPartiNumarasi.Name = "labelPartiNumarasi";
        this.labelPartiNumarasi.TabIndex = 16;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 21;
       


        this.ASIEOrtayaCikisTarihi = new TTVisual.TTDateTimePicker();
        this.ASIEOrtayaCikisTarihi.Format = DateTimePickerFormat.Long;
        this.ASIEOrtayaCikisTarihi.Name = "ASIEOrtayaCikisTarihi";
        this.ASIEOrtayaCikisTarihi.TabIndex = 21;


        this.labelVaccineState = new TTVisual.TTLabel();
        this.labelVaccineState.Text = i18n("M11199", "Aşı Durumu");
        this.labelVaccineState.Name = "labelVaccineState";
        this.labelVaccineState.TabIndex = 47;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23763", "Uygulama Tarihi");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 22;


        this.VaccineState = new TTVisual.TTEnumComboBox();
        this.VaccineState.DataTypeName = "VaccineStateEnum";
        this.VaccineState.Name = "VaccineState";
        this.VaccineState.TabIndex = 46;

        this.labelDate = new TTVisual.TTLabel();
        this.labelDate.Text = "Tarih";
        this.labelDate.Name = "labelDate";
        this.labelDate.TabIndex = 49;

        this.labelDisMerkez = new TTVisual.TTLabel();
        this.labelDisMerkez.Text = i18n("M12717", "Dış  Merkez");
        this.labelDisMerkez.Name = "labelDisMerkez";
        this.labelDisMerkez.TabIndex = 41;

        this.Date = new TTVisual.TTDateTimePicker();
        this.Date.Format = DateTimePickerFormat.Long;
        this.Date.Name = "Date";
        this.Date.TabIndex = 48;

        this.labelResUser = new TTVisual.TTLabel();
        this.labelResUser.Text = i18n("M22151", "Sorumlu Hemşire");
        this.labelResUser.Name = "labelResUser";
        this.labelResUser.TabIndex = 45;

        this.DisMerkez = new TTVisual.TTTextBox();
        this.DisMerkez.Name = "DisMerkez";
        this.DisMerkez.TabIndex = 40;

        this.labelResUser1 = new TTVisual.TTLabel();
        this.labelResUser1.Text = i18n("M22142", "Sorumlu Doktor");
        this.labelResUser1.Name = "labelResUser1";
        this.labelResUser1.TabIndex = 43;

        this.ResUser = new TTVisual.TTObjectListBox();
        this.ResUser.ListDefName = "NurseListDefinition";
        this.ResUser.Name = "ResUser";
        this.ResUser.TabIndex = 44;
        this.ResUser.BackColor = "#ffeee5";
        this.ResUser.Required = true;

        this.ResUser1 = new TTVisual.TTObjectListBox();
        this.ResUser1.ListDefName = "SpecialistDoctorListDefinition";
        this.ResUser1.Name = "ResUser1";
        this.ResUser1.TabIndex = 42;
        this.ResUser1.BackColor = "#ffeee5";
        this.ResUser1.Required = true;

        this.Notes = new TTVisual.TTTextBox();
        this.Notes.Multiline = true;
        this.Notes.Name = "Notes";
        this.Notes.TabIndex = 38;


        //this.labelAsiAntiSerumuKarekodu = new TTVisual.TTLabel();
        //this.labelAsiAntiSerumuKarekodu.Text = "Aşı Anti Serumu Karekodu";
        //this.labelAsiAntiSerumuKarekodu.Name = "labelAsiAntiSerumuKarekodu";
        //this.labelAsiAntiSerumuKarekodu.TabIndex = 1;

        //this.labelAsiSulandiriciKarekodu = new TTVisual.TTLabel();
        //this.labelAsiSulandiriciKarekodu.Text = "Aşı Sulandırıcı Karekodu";
        //this.labelAsiSulandiriciKarekodu.Name = "labelAsiSulandiriciKarekodu";
        //this.labelAsiSulandiriciKarekodu.TabIndex = 7;

        this.SKRSAsininUygulamaSekli = new TTVisual.TTObjectListBox();
        this.SKRSAsininUygulamaSekli.Required = true;
        this.SKRSAsininUygulamaSekli.ListDefName = "SKRSAsininUygulamaSekliList";
        this.SKRSAsininUygulamaSekli.Name = "SKRSAsininUygulamaSekli";
        this.SKRSAsininUygulamaSekli.TabIndex = 27;
        this.SKRSAsininUygulamaSekli.BackColor = "#ffeee5";

        this.labelSKRSAsininUygulamaSekli = new TTVisual.TTLabel();
        this.labelSKRSAsininUygulamaSekli.Text = i18n("M23760", "Uygulama Şekli");
        this.labelSKRSAsininUygulamaSekli.Name = "labelSKRSAsininUygulamaSekli";
        this.labelSKRSAsininUygulamaSekli.TabIndex = 28;

        this.SKRSAsininSaglandigiKaynak = new TTVisual.TTObjectListBox();
        this.SKRSAsininSaglandigiKaynak.ListDefName = "SKRSAsininSaglandigiKaynakList";
        this.SKRSAsininSaglandigiKaynak.Name = "SKRSAsininSaglandigiKaynak";
        this.SKRSAsininSaglandigiKaynak.TabIndex = 29;
        this.SKRSAsininSaglandigiKaynak.BackColor = "#ffeee5";
        this.SKRSAsininSaglandigiKaynak.Required = true;

        this.DisMerkezMi = new TTVisual.TTCheckBox();
        this.DisMerkezMi.Value = false;
        this.DisMerkezMi.Title = i18n("M12759", "Dış Merkezde Uygulandı.");
        this.DisMerkezMi.Name = "DisMerkezMi";
        this.DisMerkezMi.TabIndex = 37;

        this.labelNotes = new TTVisual.TTLabel();
        this.labelNotes.Text = i18n("M19476", "Not");
        this.labelNotes.Name = "labelNotes";
        this.labelNotes.TabIndex = 39;

        this.labelSKRSAsininSaglandigiKaynak = new TTVisual.TTLabel();
        this.labelSKRSAsininSaglandigiKaynak.Text = "Aşının Sağlandığı Kaynak";
        this.labelSKRSAsininSaglandigiKaynak.Name = "labelSKRSAsininSaglandigiKaynak";
        this.labelSKRSAsininSaglandigiKaynak.TabIndex = 30;

        this.SKRSAsiUygulamaYeri = new TTVisual.TTObjectListBox();
        this.SKRSAsiUygulamaYeri.Required = true;
        this.SKRSAsiUygulamaYeri.ListDefName = "SKRSAsiUygulamaYeriList";
        this.SKRSAsiUygulamaYeri.Name = "SKRSAsiUygulamaYeri";
        this.SKRSAsiUygulamaYeri.TabIndex = 31;
        this.SKRSAsiUygulamaYeri.BackColor = "#ffeee5";

        //this.AsiSulandiriciKarekodu = new TTVisual.TTTextBox();
        //this.AsiSulandiriciKarekodu.Name = "AsiSulandiriciKarekodu";
        //this.AsiSulandiriciKarekodu.TabIndex = 6;

        this.labelSKRSAsiUygulamaYeri = new TTVisual.TTLabel();
        this.labelSKRSAsiUygulamaYeri.Text = i18n("M11221", "Aşı Uygulama Yeri");
        this.labelSKRSAsiUygulamaYeri.Name = "labelSKRSAsiUygulamaYeri";
        this.labelSKRSAsiUygulamaYeri.TabIndex = 32;


        //this.AsiAntiSerumuKarekodu = new TTVisual.TTTextBox();
        //this.AsiAntiSerumuKarekodu.Name = "AsiAntiSerumuKarekodu";
        //this.AsiAntiSerumuKarekodu.TabIndex = 0;

        this.GroupSeperator1 = new TTVisual.TTGroupBox();
        this.GroupSeperator1.Text = i18n("M11201", "Aşı Erteleme / İptal");
        this.GroupSeperator1.Name = "GroupSeperator1";
        this.GroupSeperator1.TabIndex = 50;

        this.labelSKRSAsiYapilmamaNedeni = new TTVisual.TTLabel();
        this.labelSKRSAsiYapilmamaNedeni.Text = i18n("M11224", "Aşı Yapılmama Nedeni");
        this.labelSKRSAsiYapilmamaNedeni.Name = "labelSKRSAsiYapilmamaNedeni";
        this.labelSKRSAsiYapilmamaNedeni.TabIndex = 5;

        this.SKRSAsiYapilmamaNedeni = new TTVisual.TTObjectListBox();
        this.SKRSAsiYapilmamaNedeni.ListDefName = "SKRSAsiYapilmamaNedeniList";
        this.SKRSAsiYapilmamaNedeni.Name = "SKRSAsiYapilmamaNedeni";
        this.SKRSAsiYapilmamaNedeni.TabIndex = 4;

        this.labelSKRSAsiYapilmamaDurumu = new TTVisual.TTLabel();
        this.labelSKRSAsiYapilmamaDurumu.Text = i18n("M11126", "Asi Yapılmama Durumu");
        this.labelSKRSAsiYapilmamaDurumu.Name = "labelSKRSAsiYapilmamaDurumu";
        this.labelSKRSAsiYapilmamaDurumu.TabIndex = 3;

        this.SKRSAsiYapilmamaDurumu = new TTVisual.TTObjectListBox();
        this.SKRSAsiYapilmamaDurumu.ListDefName = "SKRSAsiYapilmamaDurumuList";
        this.SKRSAsiYapilmamaDurumu.Name = "SKRSAsiYapilmamaDurumu";
        this.SKRSAsiYapilmamaDurumu.TabIndex = 2;

        this.labelVaccinePostponeTime = new TTVisual.TTLabel();
        this.labelVaccinePostponeTime.Text = i18n("M11202", "Aşı Erteleme Süresi");
        this.labelVaccinePostponeTime.Name = "labelVaccinePostponeTime";
        this.labelVaccinePostponeTime.TabIndex = 1;

        this.VaccinePostponeTime = new TTVisual.TTTextBox();
        this.VaccinePostponeTime.Name = "VaccinePostponeTime";
        this.VaccinePostponeTime.TabIndex = 0;

        this.ttgroupbox3.Controls = [this.labelSKRSAsiSonrasiIstenmeyenEtki, this.SKRSAsiSonrasiIstenmeyenEtki];
        this.ttgroupbox1.Controls = [this.labelSKRSAsiOzelDurumNedeni, this.SKRSAsiOzelDurumNedeni, this.ttgroupbox2, this.ApplicationDate, this.labelVaccineState, this.labelApplicationDate, this.VaccineState, this.labelDate, this.labelDisMerkez, this.Date, this.labelResUser, this.DisMerkez, this.labelResUser1, this.ResUser, this.ResUser1, this.Notes, this.SKRSAsininUygulamaSekli, this.labelSKRSAsininUygulamaSekli, this.DisMerkezMi, this.labelNotes, this.SKRSAsiUygulamaYeri, this.labelSKRSAsiUygulamaYeri];
        this.ttgroupbox2.Controls = [this.SKRSAsiKodu, this.labelSKRSAsiKodu, this.BildirimDurumu, this.SorguSonucu, this.ATS_Bildirim, this.labelBildirimDurumu, this.labelSKRSAsininDozu, this.SorguNumarasi, this.SKRSAsininDozu, this.labelSorguSonucu, this.GeziciHizmetMi, this.labelAsiKarekodu, this.SeriNumarasi, this.labelSorguNumarasi, this.AsiKarekodu, this.KirilimBilgisi, this.PartiNumarasi, this.ATS_Sorgula, this.labelAsininSonKullanmaTarihi, this.AsininSonKullanmaTarihi, this.Barkod, this.labelSeriNumarasi, this.labelKirilimBilgisi, this.labelBarkod, this.labelPartiNumarasi];
        this.GroupSeperator1.Controls = [this.labelSKRSAsiYapilmamaNedeni, this.SKRSAsiYapilmamaNedeni, this.labelSKRSAsiYapilmamaDurumu, this.SKRSAsiYapilmamaDurumu, this.labelVaccinePostponeTime, this.VaccinePostponeTime];
        this.Controls = [this.ttgroupbox3, this.labelSKRSAsiSonrasiIstenmeyenEtki, this.SKRSAsiSonrasiIstenmeyenEtki, this.SKRSASIISLEMTURU, this.SKRSKurumlar,
            this.ASIEOrtayaCikisTarihi, this.ttgroupbox1, this.labelSKRSAsiOzelDurumNedeni, this.SKRSAsiOzelDurumNedeni, this.ttgroupbox2, this.SKRSAsiKodu, this.labelSKRSAsiKodu, this.BildirimDurumu, this.SorguSonucu,
            this.ATS_Bildirim, this.labelBildirimDurumu, this.labelSKRSAsininDozu, this.SorguNumarasi, this.SKRSAsininDozu, this.labelSorguSonucu, this.GeziciHizmetMi, this.labelAsiKarekodu,
            this.SeriNumarasi, this.labelSorguNumarasi, this.AsiKarekodu, this.IslemYapan, this.BilgiAlinanKisiTel, this.BilgiAlinanKisiAdiSoyadi, this.KirilimBilgisi, this.PartiNumarasi, this.ATS_Sorgula, this.labelAsininSonKullanmaTarihi,
            this.AsininSonKullanmaTarihi, this.Barkod, this.labelSeriNumarasi, this.labelKirilimBilgisi, this.labelBarkod, this.labelPartiNumarasi, this.ApplicationDate, this.labelVaccineState, this.labelApplicationDate, this.VaccineState,
            this.labelDate, this.labelDisMerkez, this.Date, this.labelResUser, this.DisMerkez, this.labelResUser1, this.ResUser, this.ResUser1, this.Notes, this.SKRSAsininUygulamaSekli, this.labelSKRSAsininUygulamaSekli, this.DisMerkezMi,
            this.labelNotes, this.SKRSAsiUygulamaYeri, this.labelSKRSAsiUygulamaYeri, this.GroupSeperator1, this.labelSKRSAsiYapilmamaNedeni, this.SKRSAsiYapilmamaNedeni, this.labelSKRSAsiYapilmamaDurumu, this.SKRSAsiYapilmamaDurumu, this.SKRSAsininSaglandigiKaynak, this.labelSKRSAsininSaglandigiKaynak,
            this.labelVaccinePostponeTime, this.VaccinePostponeTime];

    }

    ATS_Sorgula_Click(): void {

        let that = this;

        let confirmResult: ConfirmObj = this.confirmATS();
        if (confirmResult.Result == false) {
            this.messageService.showError(confirmResult.Message);
            return;
        }

        let input: ATSSorgulaInput = new ATSSorgulaInput();
        input.karekod = this._karekod;
        input.skrsAsiKodu = this._VaccineDetails.SKRSAsiKodu.KODU.toString();
        input.skrsAsiDozu = this._VaccineDetails.SKRSAsininDozu.KODU.toString();
        input.geziciHizmetMi = this._VaccineDetails.GeziciHizmetMi;
        input.skrsAsiSaglandigiKaynakKod = this._VaccineDetails.SKRSAsininSaglandigiKaynak.KODU.toString();
        input.vaccineFollowupEA = this._VaccineFollowupEA;
        input.patientID = this._PatientID;
        input.ResponsibleDoctor = this.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleDoctor;
        input.vaccineDetailObjectID = this._VaccineDetails.ObjectID;
        let apiUrlATS: string = '/api/VaccineDetailsService/ATSSorgula';

        that.httpService.post<ATSSorgulaResult>(apiUrlATS, input)
            .then(response => {
                that.vaccineApplicationFormViewModel._VaccineDetails.AsininSonKullanmaTarihi = response.SonKullanmaTarihi;
                that.vaccineApplicationFormViewModel._VaccineDetails.Barkod = response.Barkod;
                that.vaccineApplicationFormViewModel._VaccineDetails.SeriNumarasi = response.SeriNo;
                that.vaccineApplicationFormViewModel._VaccineDetails.PartiNumarasi = response.PartiNo;
                that.vaccineApplicationFormViewModel._VaccineDetails.KirilimBilgisi = response.Kirilim;
                that.vaccineApplicationFormViewModel._VaccineDetails.SorguNumarasi = response.ats_output_SorguNo;
                that.vaccineApplicationFormViewModel._VaccineDetails.SorguSonucu = response.ats_output_KullanilabilirlikDurum + "-" + response.ats_output_Bilgi;
                this.messageService.showInfo(response.ats_output_KullanilabilirlikDurum + "-" + response.ats_output_Bilgi);
            })
            .catch(error => {
                console.log(error);
            });

    }

    ATS_Bildirim_Click(): void {
        let that = this;

        if (this._VaccineDetails.SorguSonucu == null || this._VaccineDetails.SorguSonucu.toString() == "") {
            this.messageService.showError(i18n("M22119", "Sorgu Numarası olmayan aşılar uygulanamaz."));
            return;
        } else if (this._VaccineDetails.ApplicationDate == undefined || this._VaccineDetails.ApplicationDate == null ) {
            this.messageService.showError("Uygulama tarihi girilmemiş aşılar uygulanamaz.");
            return;
        }



        this.loadATSPanelOperation(true, i18n("M14461", "ATS bildirimi yapılıyor, lütfen bekleyiniz."));

        let apiUrlATS: string = '/api/VaccineDetailsService/ATSBildirim';
        that.httpService.post<ATSBildirimResult>(apiUrlATS, this.vaccineApplicationFormViewModel._VaccineDetails)
            .then(response => {


                if (response.IsSuccess) {
                    //that.vaccineApplicationFormViewModel._VaccineDetails.ApplicationDate = response.ApplicationDate; // Uygulama Tarihi
                    that.vaccineApplicationFormViewModel._VaccineDetails.CurrentStateDefID = VaccineDetails.VaccineDetailsStates.Completed; // Aşı durumu
                    that.vaccineApplicationFormViewModel._VaccineDetails.BildirimDurumu = "Başarılı: " + response.Result;
                    that.messageService.showInfo("ATS Bildirim Durumu: Başarılı  " + response.Result);

                    //bildirim durumu başarılı ise bizdeki stoktan düş

                } else {
                    that.vaccineApplicationFormViewModel._VaccineDetails.BildirimDurumu = "Başarısız: " + response.Result;
                    that.messageService.showError("ATS Bildirim Durumu: " + response.Result);
                }


                that.loadATSPanelOperation(false, '');


            })
            .catch(error => {
                console.log(error);
                that.loadATSPanelOperation(false, '');
                that.messageService.showError("ATS Bildirim Hatası: " + error);
            });
    }

    confirmATS(): ConfirmObj {
        let result: ConfirmObj = new ConfirmObj();

        if (this._karekod == "") {
            result.Result = false;
            this.messageService.showError(i18n("M22128", "Sorgulama Yapmadan Önce Lütfen Aşı Karekodunu Okutunuz."));
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleDoctor == null || this.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleDoctor == undefined) {
            result.Result = false;
            result.Message = i18n("M22150", "Sorumlu Doktoru Seçiniz.");
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiKodu == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiKodu == undefined) {
            result.Result = false;
            result.Message = i18n("M11210", "Aşı Seçiniz.");
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininDozu == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininDozu == undefined) {
            result.Result = false;
            result.Message = i18n("M11226", "Aşının Dozunu Seçiniz.");
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininSaglandigiKaynak == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininSaglandigiKaynak == undefined) {
            result.Result = false;
            result.Message = "Aşının Sağlandığı Kaynağı Seçiniz.";
            return result;
        }

        return result;
    }

    loadATSPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    ParseBarcode() {
        let that = this;
        this.loadATSPanelOperation(true, "Karekod çözümleniyor, lütfen bekleyiniz.");
        let apiUrl: string = '/api/VaccineDetailsService/ParseBarcode?Barcode=' + this._karekod;
        that.httpService.get<BarcodeShortInfo>(apiUrl)
            .then(response => {

                that.vaccineApplicationFormViewModel._VaccineDetails.AsininSonKullanmaTarihi = response.SonKullanmaTarihi;
                that.vaccineApplicationFormViewModel._VaccineDetails.Barkod = response.Barkod;
                that.vaccineApplicationFormViewModel._VaccineDetails.SeriNumarasi = response.SeriNo;
                that.vaccineApplicationFormViewModel._VaccineDetails.PartiNumarasi = response.PartiNo;
                that.vaccineApplicationFormViewModel._VaccineDetails.KirilimBilgisi = response.BirimKirilimDegerleri;
                that.loadATSPanelOperation(false, '');
            })
            .catch(error => {
                console.log(error);
                that.loadATSPanelOperation(false, '');
                that.messageService.showError("Karekod Çözümleme Hatası: " + error);
            });


    }


    SaveVaccineDetail() {
        let that = this;

        let confirmResult: ConfirmObj = this.confirmSaveVaccineDetails();
        if (confirmResult.Result == false) {
            this.messageService.showError(confirmResult.Message);
            return;
        }

        let apiUrl: string = '/api/VaccineDetailsService/SaveVaccineDetail'; //?viewModel=' + this.medicalInformationFormViewModel;
        that.httpService.post<any>(apiUrl, this.vaccineApplicationFormViewModel)
            .then(response => {
                this.messageService.showInfo(i18n("M16831", "İşlem Başarılı."));
               // await this.load(VaccineApplicationFormViewModel);
                this.load();
            })
            .catch(error => {
                this.messageService.showError(error);

            });

    }

    confirmSaveVaccineDetails(): ConfirmObj {
        let result: ConfirmObj = new ConfirmObj();

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSASIISLEMTURU == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSASIISLEMTURU == undefined) {
            result.Result = false;
            result.Message = i18n("M11204", "Aşı İşlem Türünü Seçiniz.");
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSASIISLEMTURU.KODU == "1" && (this.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleDoctor == null || this.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleDoctor == undefined)) {
            result.Result = false;
            result.Message = i18n("M22150", "Sorumlu Doktoru Seçiniz.");
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSASIISLEMTURU.KODU == "1" && (this.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleNurse == null || this.vaccineApplicationFormViewModel._VaccineDetails.ResponsibleNurse == undefined)) {
            result.Result = false;
            result.Message = i18n("M22152", "Sorumlu Hemşireyi Seçiniz.");
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSKurumlar == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSKurumlar == undefined) {
            result.Result = false;
            result.Message = "İzlemin Yapıldığı Yeri Seçiniz.";
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiOzelDurumNedeni == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiOzelDurumNedeni == undefined) {
            result.Result = false;
            result.Message = "Özel Durum Nedenini Seçiniz.";
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.BilgiAlinanKisiAdiSoyadi == null || this.vaccineApplicationFormViewModel._VaccineDetails.BilgiAlinanKisiAdiSoyadi == undefined) {
            result.Result = false;
            result.Message = "Bilgi Alınan Kişi Adı Soyadını Giriniz.";
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.BilgiAlinanKisiTel == null || this.vaccineApplicationFormViewModel._VaccineDetails.BilgiAlinanKisiTel == undefined) {
            result.Result = false;
            result.Message = "Bilgi Alınan Kişinin Telefon Numarasını Giriniz.";
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiKodu == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiKodu == undefined) {
            result.Result = false;
            result.Message = i18n("M11210", "Aşı Seçiniz.");
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininDozu == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininDozu == undefined) {
            result.Result = false;
            result.Message = i18n("M11226", "Aşının Dozunu Seçiniz.");
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiUygulamaYeri == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsiUygulamaYeri == undefined) {
            result.Result = false;
            result.Message = i18n("M23769", "Uygulama Yerini Seçiniz.");
            return result;
        }

        if (this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininUygulamaSekli == null || this.vaccineApplicationFormViewModel._VaccineDetails.SKRSAsininUygulamaSekli == undefined) {
            result.Result = false;
            result.Message = i18n("M23761", "Uygulama Şeklini Seçiniz.");
            return result;
        }

        return result;
    }
    CancelVaccineDetail() {

        let that = this;
        //tamamlanmış kontrolü
        if (this.vaccineApplicationFormViewModel._VaccineDetails.CurrentStateDefID == VaccineDetails.VaccineDetailsStates.Completed) {
            this.messageService.showError(i18n("M23795", "Uygulanmış Aşıları İptal Edemezsiniz."));
            return;

        } else if (this.vaccineApplicationFormViewModel._VaccineDetails.ObjectID == Guid.empty()) {
            this.messageService.showError("Kaydedilmemiş Aşıyı İptal Edemezsiniz.");
            return;
        }
        else if (this.vaccineApplicationFormViewModel._VaccineDetails.CurrentStateDefID == VaccineDetails.VaccineDetailsStates.New) {

            let apiUrl: string = '/api/VaccineFollowUpService/CancelVaccine';
            that.httpService.post<any>(apiUrl, this.vaccineApplicationFormViewModel._VaccineDetails)
                .then(response => {
                    this.messageService.showInfo(i18n("M16831", "İşlem Başarılı."));
                    this.vaccineApplicationFormViewModel._VaccineDetails.CurrentStateDefID = VaccineDetails.VaccineDetailsStates.Canceled;
                    this.refreshDetails.emit();
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }
}




