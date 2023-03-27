//$F8E8FE48
import { Component, OnInit, NgZone } from '@angular/core';
import { EvdeSaglikBasvuruKaydetFormViewModel } from './EvdeSaglikBasvuruKaydetFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EvdeSaglikHizmetleri } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';

import { CommonHelper } from 'app/Helper/CommonHelper';

@Component({
    selector: 'EvdeSaglikBasvuruKaydetForm',
    templateUrl: './EvdeSaglikBasvuruKaydetForm.html',
    providers: [MessageService]
})
export class EvdeSaglikBasvuruKaydetForm extends TTVisual.TTForm implements OnInit, IModal {
    AlinanNotlar: TTVisual.ITTTextBox;
    BasvuranAciklamasi: TTVisual.ITTTextBox;
    BasvuranAd: TTVisual.ITTTextBox;
    BasvuranSoyad: TTVisual.ITTTextBox;
    BasvuranTC: TTVisual.ITTTextBox;
    BasvuranTel: TTVisual.ITTMaskedTextBox;
    HastaAd: TTVisual.ITTTextBox;
    HastaAdres: TTVisual.ITTTextBox;
    HastaSoyad: TTVisual.ITTTextBox;
    HastaTC: TTVisual.ITTTextBox;
    HizmetEmriTarihi: TTVisual.ITTDateTimePicker;
    labelAlinanNotlar: TTVisual.ITTLabel;
    labelBasvuranAciklamasi: TTVisual.ITTLabel;
    labelBasvuranAd: TTVisual.ITTLabel;
    labelBasvuranSoyad: TTVisual.ITTLabel;
    labelBasvuranTC: TTVisual.ITTLabel;
    labelBasvuranTel: TTVisual.ITTLabel;
    labelHastaAd: TTVisual.ITTLabel;
    labelHastaAdres: TTVisual.ITTLabel;
    labelHastaSoyad: TTVisual.ITTLabel;
    labelHastaTC: TTVisual.ITTLabel;
    labelHizmetEmriTarihi: TTVisual.ITTLabel;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ResponsibleDoctor: TTVisual.ITTObjectListBox;
    _FromPatientAdmission: boolean = false;

    public evdeSaglikBasvuruKaydetFormViewModel: EvdeSaglikBasvuruKaydetFormViewModel = new EvdeSaglikBasvuruKaydetFormViewModel();
    public get _EvdeSaglikHizmetleri(): EvdeSaglikHizmetleri {
        return this._TTObject as EvdeSaglikHizmetleri;
    }

    private EvdeSaglikBasvuruKaydetForm_DocumentUrl: string = '/api/EvdeSaglikHizmetleriService/EvdeSaglikBasvuruKaydetForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {

        super('EVDESAGLIKHIZMETLERI', 'EvdeSaglikBasvuruKaydetForm');
        this._DocumentServiceUrl = this.EvdeSaglikBasvuruKaydetForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EvdeSaglikHizmetleri();
        this.evdeSaglikBasvuruKaydetFormViewModel = new EvdeSaglikBasvuruKaydetFormViewModel();
        this._ViewModel = this.evdeSaglikBasvuruKaydetFormViewModel;
        this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri = this._TTObject as EvdeSaglikHizmetleri;
    }

    protected loadViewModel() {
        let that = this;
        that.evdeSaglikBasvuruKaydetFormViewModel = this._ViewModel as EvdeSaglikBasvuruKaydetFormViewModel;
        that._TTObject = this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri;
        if (this.evdeSaglikBasvuruKaydetFormViewModel == null)
            this.evdeSaglikBasvuruKaydetFormViewModel = new EvdeSaglikBasvuruKaydetFormViewModel();
        if (this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri == null)
            this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri = new EvdeSaglikHizmetleri();
        let responsibleDoctorObjectID = that.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri["ResponsibleDoctor"];
        if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === 'string')) {
            let responsibleDoctor = that.evdeSaglikBasvuruKaydetFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
             if (responsibleDoctor) {
                that.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri.ResponsibleDoctor = responsibleDoctor;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        if (!this._FromPatientAdmission)
            await this.load(EvdeSaglikBasvuruKaydetFormViewModel);
  
    }

    public onResponsibleDoctorChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.ResponsibleDoctor != event) {
                this._EvdeSaglikHizmetleri.ResponsibleDoctor = event;
            }
        }
    }
    public onAlinanNotlarChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.AlinanNotlar != event) {
                this._EvdeSaglikHizmetleri.AlinanNotlar = event;
            }
        }
    }

    public onBasvuranAciklamasiChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.BasvuranAciklamasi != event) {
                this._EvdeSaglikHizmetleri.BasvuranAciklamasi = event;
            }
        }
    }

    public onBasvuranAdChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.BasvuranAd != event) {
                this._EvdeSaglikHizmetleri.BasvuranAd = event;
            }
        }
    }

    public onBasvuranSoyadChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.BasvuranSoyad != event) {
                this._EvdeSaglikHizmetleri.BasvuranSoyad = event;
            }
        }
    }

    public onBasvuranTCChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.BasvuranTC != event) {
                this._EvdeSaglikHizmetleri.BasvuranTC = event;
            }
        }
    }

    public onBasvuranTelChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.BasvuranTel != event) {
                this._EvdeSaglikHizmetleri.BasvuranTel = event;
            }
        }
    }

    public onHastaAdChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.HastaAd != event) {
                this._EvdeSaglikHizmetleri.HastaAd = event;
            }
        }
    }

    public onHastaAdresChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.HastaAdres != event) {
                this._EvdeSaglikHizmetleri.HastaAdres = event;
            }
        }
    }

    public onHastaSoyadChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.HastaSoyad != event) {
                this._EvdeSaglikHizmetleri.HastaSoyad = event;
            }
        }
    }

    public onHastaTCChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.HastaTC != event) {
                this._EvdeSaglikHizmetleri.HastaTC = event;
            }
        }
    }

    public onHizmetEmriTarihiChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikHizmetleri != null && this._EvdeSaglikHizmetleri.HizmetEmriTarihi != event) {
                this._EvdeSaglikHizmetleri.HizmetEmriTarihi = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.HizmetEmriTarihi, "Value", this.__ttObject, "HizmetEmriTarihi");
        redirectProperty(this.BasvuranTel, "Text", this.__ttObject, "BasvuranTel");
        redirectProperty(this.BasvuranTC, "Text", this.__ttObject, "BasvuranTC");
        redirectProperty(this.BasvuranAd, "Text", this.__ttObject, "BasvuranAd");
        redirectProperty(this.BasvuranAciklamasi, "Text", this.__ttObject, "BasvuranAciklamasi");
        redirectProperty(this.BasvuranSoyad, "Text", this.__ttObject, "BasvuranSoyad");
        redirectProperty(this.HastaTC, "Text", this.__ttObject, "HastaTC");
        redirectProperty(this.HastaAdres, "Text", this.__ttObject, "HastaAdres");
        redirectProperty(this.HastaAd, "Text", this.__ttObject, "HastaAd");
        redirectProperty(this.HastaSoyad, "Text", this.__ttObject, "HastaSoyad");
        redirectProperty(this.AlinanNotlar, "Text", this.__ttObject, "AlinanNotlar");
    }

    public initFormControls(): void {
        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = i18n("M15158", "Hasta Bilgileri");
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 25;

        this.ResponsibleDoctor = new TTVisual.TTObjectListBox();
        this.ResponsibleDoctor.ListDefName = "DoctorListDefinition";
        this.ResponsibleDoctor.Name = "ResponsibleDoctor";
        this.ResponsibleDoctor.TabIndex = 26;
        this.ResponsibleDoctor.Required = true;
        this.ResponsibleDoctor.BackColor = "#ffeee5";

        this.labelHastaTC = new TTVisual.TTLabel();
        this.labelHastaTC.Text = i18n("M15316", "Hasta TC");
        this.labelHastaTC.Name = "labelHastaTC";
        this.labelHastaTC.TabIndex = 15;

        this.HastaTC = new TTVisual.TTTextBox();
        this.HastaTC.Name = "HastaTC";
        this.HastaTC.TabIndex = 14;
        this.HastaTC.BackColor = "#ffeee5";
        this.HastaTC.Required = true;

        this.HastaAd = new TTVisual.TTTextBox();
        this.HastaAd.Name = "HastaAd";
        this.HastaAd.TabIndex = 16;
        this.HastaAd.BackColor = "#ffeee5";
        this.HastaAd.Required = true;

        this.labelHastaAd = new TTVisual.TTLabel();
        this.labelHastaAd.Text = i18n("M15130", "Hasta Ad");
        this.labelHastaAd.Name = "labelHastaAd";
        this.labelHastaAd.TabIndex = 17;

        this.labelHastaAdres = new TTVisual.TTLabel();
        this.labelHastaAdres.Text = i18n("M15136", "Hasta Adres");
        this.labelHastaAdres.Name = "labelHastaAdres";
        this.labelHastaAdres.TabIndex = 21;

        this.HastaSoyad = new TTVisual.TTTextBox();
        this.HastaSoyad.Name = "HastaSoyad";
        this.HastaSoyad.TabIndex = 18;
        this.HastaSoyad.BackColor = "#ffeee5";
        this.HastaSoyad.Required = true;

        this.HastaAdres = new TTVisual.TTTextBox();
        this.HastaAdres.Multiline = true;
        this.HastaAdres.Name = "HastaAdres";
        this.HastaAdres.TabIndex = 20;
        this.HastaAdres.BackColor = "#ffeee5";
        this.HastaAdres.Required = true;

        this.labelHastaSoyad = new TTVisual.TTLabel();
        this.labelHastaSoyad.Text = i18n("M15302", "Hasta Soyad");
        this.labelHastaSoyad.Name = "labelHastaSoyad";
        this.labelHastaSoyad.TabIndex = 19;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M11650", "Başvuran Bilgileri");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 24;

        this.labelBasvuranTel = new TTVisual.TTLabel();
        this.labelBasvuranTel.Text = i18n("M11654", "Başvuran Telefon");
        this.labelBasvuranTel.Name = "labelBasvuranTel";
        this.labelBasvuranTel.TabIndex = 1;

        this.BasvuranTel = new TTVisual.TTMaskedTextBox();
        this.BasvuranTel.Mask = "000 0000000";
        this.BasvuranTel.Name = "BasvuranTel";
        this.BasvuranTel.TabIndex = 0;

        this.BasvuranAd = new TTVisual.TTTextBox();
        this.BasvuranAd.Name = "BasvuranAd";
        this.BasvuranAd.TabIndex = 2;
        this.BasvuranAd.BackColor = "#ffeee5";
        this.BasvuranAd.Required = true;

        this.labelBasvuranAd = new TTVisual.TTLabel();
        this.labelBasvuranAd.Text = i18n("M11649", "Başvuran Ad");
        this.labelBasvuranAd.Name = "labelBasvuranAd";
        this.labelBasvuranAd.TabIndex = 3;

        this.BasvuranSoyad = new TTVisual.TTTextBox();
        this.BasvuranSoyad.Name = "BasvuranSoyad";
        this.BasvuranSoyad.TabIndex = 4;
        this.BasvuranSoyad.BackColor = "#ffeee5";
        this.BasvuranSoyad.Required = true;

        this.labelBasvuranSoyad = new TTVisual.TTLabel();
        this.labelBasvuranSoyad.Text = i18n("M11651", "Başvuran Soyad");
        this.labelBasvuranSoyad.Name = "labelBasvuranSoyad";
        this.labelBasvuranSoyad.TabIndex = 5;

        this.BasvuranTC = new TTVisual.TTTextBox();
        this.BasvuranTC.Name = "BasvuranTC";
        this.BasvuranTC.TabIndex = 6;
        this.BasvuranTC.BackColor = "#ffeee5";
        this.BasvuranTC.Required = true;

        this.labelBasvuranTC = new TTVisual.TTLabel();
        this.labelBasvuranTC.Text = i18n("M11652", "Başvuran TC");
        this.labelBasvuranTC.Name = "labelBasvuranTC";
        this.labelBasvuranTC.TabIndex = 7;

        this.BasvuranAciklamasi = new TTVisual.TTTextBox();
        this.BasvuranAciklamasi.Multiline = true;
        this.BasvuranAciklamasi.Name = "BasvuranAciklamasi";
        this.BasvuranAciklamasi.TabIndex = 8;

        this.labelBasvuranAciklamasi = new TTVisual.TTLabel();
        this.labelBasvuranAciklamasi.Text = i18n("M11648", "Başvuran Açıklaması");
        this.labelBasvuranAciklamasi.Name = "labelBasvuranAciklamasi";
        this.labelBasvuranAciklamasi.TabIndex = 9;

        this.labelHizmetEmriTarihi = new TTVisual.TTLabel();

        this.labelHizmetEmriTarihi.Text = i18n("M15842", "Hizmet Emri Tarihi");
        this.labelHizmetEmriTarihi.Name = "labelHizmetEmriTarihi";
        this.labelHizmetEmriTarihi.TabIndex = 23;


        this.HizmetEmriTarihi = new TTVisual.TTDateTimePicker();
        this.HizmetEmriTarihi.Format = DateTimePickerFormat.Long;
        this.HizmetEmriTarihi.Name = "HizmetEmriTarihi";
        this.HizmetEmriTarihi.TabIndex = 22;
        this.HizmetEmriTarihi.BackColor = "#ffeee5";
        this.HizmetEmriTarihi.Required = true;

        this.labelAlinanNotlar = new TTVisual.TTLabel();
        this.labelAlinanNotlar.Text = i18n("M10709", "Alınan Notlar");
        this.labelAlinanNotlar.Name = "labelAlinanNotlar";
        this.labelAlinanNotlar.TabIndex = 11;

        this.AlinanNotlar = new TTVisual.TTTextBox();
        this.AlinanNotlar.Multiline = true;
        this.AlinanNotlar.Name = "AlinanNotlar";
        this.AlinanNotlar.TabIndex = 10;

        this.ttgroupbox2.Controls = [this.labelHastaTC, this.HastaTC, this.HastaAd, this.labelHastaAd, this.labelHastaAdres, this.HastaSoyad, this.HastaAdres, this.labelHastaSoyad];
        this.ttgroupbox1.Controls = [this.labelBasvuranTel, this.BasvuranTel, this.BasvuranAd, this.labelBasvuranAd, this.BasvuranSoyad, this.labelBasvuranSoyad, this.BasvuranTC, this.labelBasvuranTC, this.BasvuranAciklamasi, this.labelBasvuranAciklamasi];
        this.Controls = [this.ResponsibleDoctor, this.ttgroupbox2, this.labelHastaTC, this.HastaTC, this.HastaAd, this.labelHastaAd, this.labelHastaAdres, this.HastaSoyad, this.HastaAdres, this.labelHastaSoyad, this.ttgroupbox1, this.labelBasvuranTel, this.BasvuranTel, this.BasvuranAd, this.labelBasvuranAd, this.BasvuranSoyad, this.labelBasvuranSoyad, this.BasvuranTC, this.labelBasvuranTC, this.BasvuranAciklamasi, this.labelBasvuranAciklamasi, this.labelHizmetEmriTarihi, this.HizmetEmriTarihi, this.labelAlinanNotlar, this.AlinanNotlar];


    }

    public setInputParam(value: boolean) {
        if (value)
            this._FromPatientAdmission = true;

    }
    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    saveApplication(): void {
        let that = this;
        let flag = this.confirmSaveApplication();
        if (!flag)
            return;
        let apiUrl: string = '/api/EvdeSaglikHizmetleriService/SaveApplication';
        that.httpService.post<any>(apiUrl, this.evdeSaglikBasvuruKaydetFormViewModel)
            .then(response => {
                if (response.indexOf('Hata') >= 0)
                    this.messageService.showError(response);
                else
                    this.messageService.showInfo(response);
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

    confirmSaveApplication(): boolean {
        let flag: boolean = true;
        if (this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri.BasvuranTC != null) {
            if (!CommonHelper.IsNumeric(this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri.BasvuranTC.toString()) || !CommonHelper.CheckMernisNumber(this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri.BasvuranTC)) {
                this.messageService.showError(i18n("M11653", "Başvuran TC Kimlik Numarasını Kontrol Ediniz."));
                flag = false;
            }
        } else {
            this.messageService.showError(i18n("M11653", "Başvuran TC Kimlik Numarasını Kontrol Ediniz."));
            flag = false;
        }

        if (this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri.HastaTC != null) {
            if (!CommonHelper.IsNumeric(this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri.HastaTC.toString()) || !CommonHelper.CheckMernisNumber(this.evdeSaglikBasvuruKaydetFormViewModel._EvdeSaglikHizmetleri.HastaTC)) {
                this.messageService.showError(i18n("M15319", "Hasta TC Kimlik Numarasını Kontrol Ediniz."));
                flag = false;
            }
        } else {
            this.messageService.showError(i18n("M15319", "Hasta TC Kimlik Numarasını Kontrol Ediniz."));
            flag = false;
        }

        return flag;

    }
}
