//$B766413A
import { Component, OnInit, NgZone } from '@angular/core';
import { BulasiciHastaliklarFormViewModel } from './BulasiciHastaliklarFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BulasiciHastaliklarEA } from 'NebulaClient/Model/AtlasClientModel';
import { BulasiciHastalikTelefon } from 'NebulaClient/Model/AtlasClientModel';
import { BulasiciHastalikVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBucakKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCSBMTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICD } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIlceKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKoyKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMahalleKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSVakaTipi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';

@Component({
    selector: 'BulasiciHastaliklarForm',
    templateUrl: './BulasiciHastaliklarForm.html',
    providers: [MessageService, AtlasReportService]
})
export class BulasiciHastaliklarForm extends TTVisual.TTForm implements OnInit {
    BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti: TTVisual.ITTDateTimePicker;
    Beyan_BucakBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Beyan_CSBMBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Beyan_IlBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Beyan_IlceBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Beyan_KoyBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Beyan_MahalleBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    BulasiciHastalikTelefonBulasiciHastalikTelefon: TTVisual.ITTGrid;
    BulasiciHastalikVeriSetiBulasiciHastalikTelefon: TTVisual.ITTListBoxColumn;
    DisKapiNoBeyanBulasiciHastalikVeriSeti: TTVisual.ITTTextBox;
    DisKapiNoIkametBulasiciHastalikVeriSeti: TTVisual.ITTTextBox;
    IcKapiNoBeyanBulasiciHastalikVeriSeti: TTVisual.ITTTextBox;
    IcKapiNoIkametBulasiciHastalikVeriSeti: TTVisual.ITTTextBox;
    Ikamet_BucakBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Ikamet_CSBMBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Ikamet_IlBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Ikamet_IlceBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Ikamet_KoyBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    Ikamet_MahalleBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    labelBelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelBeyan_BucakBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelBeyan_CSBMBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelBeyan_IlBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelBeyan_IlceBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelBeyan_KoyBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelBeyan_MahalleBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelDisKapiNoBeyanBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelDisKapiNoIkametBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelIcKapiNoBeyanBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelIcKapiNoIkametBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelIkamet_BucakBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelIkamet_CSBMBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelIkamet_IlBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelIkamet_IlceBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelIkamet_KoyBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelIkamet_MahalleBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelPaketeAitIslemZamaniBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelResponsibleDoctorBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelSKRSICDBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelSKRSVakaTipiBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    labelVakaDurumBulasiciHastalikVeriSeti: TTVisual.ITTLabel;
    PaketeAitIslemZamaniBulasiciHastalikVeriSeti: TTVisual.ITTDateTimePicker;
    ResponsibleDoctorBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    SKRSICDBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    SKRSTelefonTipiBulasiciHastalikTelefon: TTVisual.ITTListBoxColumn;
    SKRSVakaTipiBulasiciHastalikVeriSeti: TTVisual.ITTObjectListBox;
    TelefonNumarasiBulasiciHastalikTelefon: TTVisual.ITTTextBoxColumn;
    VakaDurumBulasiciHastalikVeriSeti: TTVisual.ITTEnumComboBox;
    public BulasiciHastalikTelefonBulasiciHastalikTelefonColumns = [];
    public telefonTipiArray: Array<any> = [];
    public TelefonTipiCache: any;
    public bulasiciHastaliklarFormViewModel: BulasiciHastaliklarFormViewModel = new BulasiciHastaliklarFormViewModel();
    public get _BulasiciHastaliklarEA(): BulasiciHastaliklarEA {
        return this._TTObject as BulasiciHastaliklarEA;
    }
    private BulasiciHastaliklarForm_DocumentUrl: string = '/api/BulasiciHastaliklarEAService/BulasiciHastaliklarForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
                protected ngZone: NgZone) {
        super('BULASICIHASTALIKLAREA', 'BulasiciHastaliklarForm');
        this._DocumentServiceUrl = this.BulasiciHastaliklarForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BulasiciHastaliklarEA();
        this.bulasiciHastaliklarFormViewModel = new BulasiciHastaliklarFormViewModel();
        this._ViewModel = this.bulasiciHastaliklarFormViewModel;
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA = this._TTObject as BulasiciHastaliklarEA;
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti = new BulasiciHastalikVeriSeti();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_CSBM = new SKRSCSBMTipi();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Mahalle = new SKRSMahalleKodlari();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Koy = new SKRSKoyKodlari();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Bucak = new SKRSBucakKodlari();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_CSBM = new SKRSCSBMTipi();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Mahalle = new SKRSMahalleKodlari();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Koy = new SKRSKoyKodlari();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Bucak = new SKRSBucakKodlari();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.BulasiciHastalikTelefon = new Array<BulasiciHastalikTelefon>();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.ResponsibleDoctor = new ResUser();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.SKRSICD = new SKRSICD();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.SKRSVakaTipi = new SKRSVakaTipi();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Ilce = new SKRSIlceKodlari();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Ilce = new SKRSIlceKodlari();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Il = new SKRSILKodlari();
        this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Il = new SKRSILKodlari();
        //this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.VakaDurum = new DeathAliveEnum.DeathAliveEnumList;
    }

    protected loadViewModel() {
        let that = this;

        that.bulasiciHastaliklarFormViewModel = this._ViewModel as BulasiciHastaliklarFormViewModel;
        that._TTObject = this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA;
        if (this.bulasiciHastaliklarFormViewModel == null)
            this.bulasiciHastaliklarFormViewModel = new BulasiciHastaliklarFormViewModel();
        if (this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA == null)
            this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA = new BulasiciHastaliklarEA();
        let bulasiciHastalikVeriSetiObjectID = that.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA["BulasiciHastalikVeriSeti"];
        if (bulasiciHastalikVeriSetiObjectID != null && (typeof bulasiciHastalikVeriSetiObjectID === "string")) {
            let bulasiciHastalikVeriSeti = that.bulasiciHastaliklarFormViewModel.BulasiciHastalikVeriSetis.find(o => o.ObjectID.toString() === bulasiciHastalikVeriSetiObjectID.toString());
             if (bulasiciHastalikVeriSeti) {
                that.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti = bulasiciHastalikVeriSeti;
            }
            if (bulasiciHastalikVeriSeti != null) {
                let beyan_CSBMObjectID = bulasiciHastalikVeriSeti["Beyan_CSBM"];
                if (beyan_CSBMObjectID != null && (typeof beyan_CSBMObjectID === "string")) {
                    let beyan_CSBM = that.bulasiciHastaliklarFormViewModel.SKRSCSBMTipis.find(o => o.ObjectID.toString() === beyan_CSBMObjectID.toString());
                     if (beyan_CSBM) {
                        bulasiciHastalikVeriSeti.Beyan_CSBM = beyan_CSBM;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let beyan_MahalleObjectID = bulasiciHastalikVeriSeti["Beyan_Mahalle"];
                if (beyan_MahalleObjectID != null && (typeof beyan_MahalleObjectID === "string")) {
                    let beyan_Mahalle = that.bulasiciHastaliklarFormViewModel.SKRSMahalleKodlaris.find(o => o.ObjectID.toString() === beyan_MahalleObjectID.toString());
                     if (beyan_Mahalle) {
                        bulasiciHastalikVeriSeti.Beyan_Mahalle = beyan_Mahalle;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let beyan_KoyObjectID = bulasiciHastalikVeriSeti["Beyan_Koy"];
                if (beyan_KoyObjectID != null && (typeof beyan_KoyObjectID === "string")) {
                    let beyan_Koy = that.bulasiciHastaliklarFormViewModel.SKRSKoyKodlaris.find(o => o.ObjectID.toString() === beyan_KoyObjectID.toString());
                     if (beyan_Koy) {
                        bulasiciHastalikVeriSeti.Beyan_Koy = beyan_Koy;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let beyan_BucakObjectID = bulasiciHastalikVeriSeti["Beyan_Bucak"];
                if (beyan_BucakObjectID != null && (typeof beyan_BucakObjectID === "string")) {
                    let beyan_Bucak = that.bulasiciHastaliklarFormViewModel.SKRSBucakKodlaris.find(o => o.ObjectID.toString() === beyan_BucakObjectID.toString());
                     if (beyan_Bucak) {
                        bulasiciHastalikVeriSeti.Beyan_Bucak = beyan_Bucak;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let ikamet_CSBMObjectID = bulasiciHastalikVeriSeti["Ikamet_CSBM"];
                if (ikamet_CSBMObjectID != null && (typeof ikamet_CSBMObjectID === "string")) {
                    let ikamet_CSBM = that.bulasiciHastaliklarFormViewModel.SKRSCSBMTipis.find(o => o.ObjectID.toString() === ikamet_CSBMObjectID.toString());
                     if (ikamet_CSBM) {
                        bulasiciHastalikVeriSeti.Ikamet_CSBM = ikamet_CSBM;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let ikamet_MahalleObjectID = bulasiciHastalikVeriSeti["Ikamet_Mahalle"];
                if (ikamet_MahalleObjectID != null && (typeof ikamet_MahalleObjectID === "string")) {
                    let ikamet_Mahalle = that.bulasiciHastaliklarFormViewModel.SKRSMahalleKodlaris.find(o => o.ObjectID.toString() === ikamet_MahalleObjectID.toString());
                     if (ikamet_Mahalle) {
                        bulasiciHastalikVeriSeti.Ikamet_Mahalle = ikamet_Mahalle;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let ikamet_KoyObjectID = bulasiciHastalikVeriSeti["Ikamet_Koy"];
                if (ikamet_KoyObjectID != null && (typeof ikamet_KoyObjectID === "string")) {
                    let ikamet_Koy = that.bulasiciHastaliklarFormViewModel.SKRSKoyKodlaris.find(o => o.ObjectID.toString() === ikamet_KoyObjectID.toString());
                     if (ikamet_Koy) {
                        bulasiciHastalikVeriSeti.Ikamet_Koy = ikamet_Koy;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let ikamet_BucakObjectID = bulasiciHastalikVeriSeti["Ikamet_Bucak"];
                if (ikamet_BucakObjectID != null && (typeof ikamet_BucakObjectID === "string")) {
                    let ikamet_Bucak = that.bulasiciHastaliklarFormViewModel.SKRSBucakKodlaris.find(o => o.ObjectID.toString() === ikamet_BucakObjectID.toString());
                     if (ikamet_Bucak) {
                        bulasiciHastalikVeriSeti.Ikamet_Bucak = ikamet_Bucak;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                bulasiciHastalikVeriSeti.BulasiciHastalikTelefon = that.bulasiciHastaliklarFormViewModel.BulasiciHastalikTelefonBulasiciHastalikTelefonGridList;
                for (let detailItem of that.bulasiciHastaliklarFormViewModel.BulasiciHastalikTelefonBulasiciHastalikTelefonGridList) {
                    let sKRSTelefonTipiObjectID = detailItem["SKRSTelefonTipi"];
                    if (sKRSTelefonTipiObjectID != null && (typeof sKRSTelefonTipiObjectID === "string")) {
                        let sKRSTelefonTipi = that.bulasiciHastaliklarFormViewModel.SKRSTelefonTipis.find(o => o.ObjectID.toString() === sKRSTelefonTipiObjectID.toString());
                         if (sKRSTelefonTipi) {
                            detailItem.SKRSTelefonTipi = sKRSTelefonTipi;
                        }
                    }
                    let bulasiciHastalikVeriSetiObjectID = detailItem["BulasiciHastalikVeriSeti"];
                    if (bulasiciHastalikVeriSetiObjectID != null && (typeof bulasiciHastalikVeriSetiObjectID === "string")) {
                        let bulasiciHastalikVeriSeti = that.bulasiciHastaliklarFormViewModel.BulasiciHastalikVeriSetis.find(o => o.ObjectID.toString() === bulasiciHastalikVeriSetiObjectID.toString());
                         if (bulasiciHastalikVeriSeti) {
                            detailItem.BulasiciHastalikVeriSeti = bulasiciHastalikVeriSeti;
                        }
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let responsibleDoctorObjectID = bulasiciHastalikVeriSeti["ResponsibleDoctor"];
                if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === "string")) {
                    let responsibleDoctor = that.bulasiciHastaliklarFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
                     if (responsibleDoctor) {
                        bulasiciHastalikVeriSeti.ResponsibleDoctor = responsibleDoctor;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let sKRSICDObjectID = bulasiciHastalikVeriSeti["SKRSICD"];
                if (sKRSICDObjectID != null && (typeof sKRSICDObjectID === "string")) {
                    let sKRSICD = that.bulasiciHastaliklarFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === sKRSICDObjectID.toString());
                     if (sKRSICD) {
                        bulasiciHastalikVeriSeti.SKRSICD = sKRSICD;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let sKRSVakaTipiObjectID = bulasiciHastalikVeriSeti["SKRSVakaTipi"];
                if (sKRSVakaTipiObjectID != null && (typeof sKRSVakaTipiObjectID === "string")) {
                    let sKRSVakaTipi = that.bulasiciHastaliklarFormViewModel.SKRSVakaTipis.find(o => o.ObjectID.toString() === sKRSVakaTipiObjectID.toString());
                     if (sKRSVakaTipi) {
                        bulasiciHastalikVeriSeti.SKRSVakaTipi = sKRSVakaTipi;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let beyan_IlceObjectID = bulasiciHastalikVeriSeti["Beyan_Ilce"];
                if (beyan_IlceObjectID != null && (typeof beyan_IlceObjectID === "string")) {
                    let beyan_Ilce = that.bulasiciHastaliklarFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === beyan_IlceObjectID.toString());
                     if (beyan_Ilce) {
                        bulasiciHastalikVeriSeti.Beyan_Ilce = beyan_Ilce;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let ikamet_IlceObjectID = bulasiciHastalikVeriSeti["Ikamet_Ilce"];
                if (ikamet_IlceObjectID != null && (typeof ikamet_IlceObjectID === "string")) {
                    let ikamet_Ilce = that.bulasiciHastaliklarFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === ikamet_IlceObjectID.toString());
                     if (ikamet_Ilce) {
                        bulasiciHastalikVeriSeti.Ikamet_Ilce = ikamet_Ilce;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let beyan_IlObjectID = bulasiciHastalikVeriSeti["Beyan_Il"];
                if (beyan_IlObjectID != null && (typeof beyan_IlObjectID === "string")) {
                    let beyan_Il = that.bulasiciHastaliklarFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === beyan_IlObjectID.toString());
                     if (beyan_Il) {
                        bulasiciHastalikVeriSeti.Beyan_Il = beyan_Il;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let ikamet_IlObjectID = bulasiciHastalikVeriSeti["Ikamet_Il"];
                if (ikamet_IlObjectID != null && (typeof ikamet_IlObjectID === "string")) {
                    let ikamet_Il = that.bulasiciHastaliklarFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === ikamet_IlObjectID.toString());
                     if (ikamet_Il) {
                        bulasiciHastalikVeriSeti.Ikamet_Il = ikamet_Il;
                    }
                }
            }
            if (bulasiciHastalikVeriSeti != null) {
                let ikamet_IlObjectID = bulasiciHastalikVeriSeti["Ikamet_Il"];
                if (ikamet_IlObjectID != null && (typeof ikamet_IlObjectID === "string")) {
                    let ikamet_Il = that.bulasiciHastaliklarFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === ikamet_IlObjectID.toString());
                     if (ikamet_Il) {
                        bulasiciHastalikVeriSeti.Ikamet_Il = ikamet_Il;
                    }
                }
            }
        }

    }

    async ngOnInit()  {
        let that = this;
        that.telefonTipiArray = await this.TelefonTipi();
        that.GenerateTelListColumns();
        await this.load(BulasiciHastaliklarFormViewModel);
  
    }


    public onBelirtilerinBaslamaTarihiBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi = event;
            }
        }
    }

    public onBeyan_BucakBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Bucak != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Bucak = event;
            }
        }

        this.triggerLoadChildComboBoxByBUCAK(event);
    }
    private triggerLoadChildComboBoxByBUCAK(BUCAK): void {

        if (BUCAK != null) {

            this.Beyan_KoyBulasiciHastalikVeriSeti.ListFilterExpression = " THIS.BUCAKKODU= '" + BUCAK.KODU.toString() + "'";

        }
        else {
            this.Beyan_KoyBulasiciHastalikVeriSeti.ListFilterExpression = " ";
        }

        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Koy = null;
        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Mahalle = null;

    }

    public onBeyan_CSBMBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_CSBM != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_CSBM = event;
            }
        }
    }

    public onBeyan_IlBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Il != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Il = event;
            }
        }
        this.triggerLoadChildComboBoxByIL(event);
    }

    private triggerLoadChildComboBoxByIL(IL): void {

        if (IL != null) {

            this.Beyan_IlceBulasiciHastalikVeriSeti.ListFilterExpression = " THIS.ILKODU= '" + IL.KODU.toString() + "'";

        }
        else {
            this.Beyan_IlceBulasiciHastalikVeriSeti.ListFilterExpression = " ";
        }

        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Ilce = null;
        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Bucak = null;
        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Koy = null;
        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Mahalle = null;

    }

    public onBeyan_IlceBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Ilce != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Ilce = event;
            }
        }
        this.triggerLoadChildComboBoxByILCE(event);
    }

    private triggerLoadChildComboBoxByILCE(ILCE): void {

        if (ILCE != null) {

            this.Beyan_BucakBulasiciHastalikVeriSeti.ListFilterExpression = " THIS.ILCEKODU= '" + ILCE.KODU.toString() + "'";

        }
        else {
            this.Beyan_BucakBulasiciHastalikVeriSeti.ListFilterExpression = " ";
        }


        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Bucak = null;
        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Koy = null;
        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Mahalle = null;

    }

    public onBeyan_KoyBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Koy != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Koy = event;
            }
        }
        this.triggerLoadChildComboBoxByKOY(event);
    }

    private triggerLoadChildComboBoxByKOY(KOY): void {

        if (KOY != null) {

            this.Beyan_MahalleBulasiciHastalikVeriSeti.ListFilterExpression = " THIS.KOYKODU= '" + KOY.KODU.toString() + "'";

        }
        else {
            this.Beyan_MahalleBulasiciHastalikVeriSeti.ListFilterExpression = " ";
        }


        this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Mahalle = null;

    }

    public onBeyan_MahalleBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Mahalle != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Beyan_Mahalle = event;
            }
        }
    }

    public onDisKapiNoBeyanBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.DisKapiNoBeyan != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.DisKapiNoBeyan = event;
            }
        }
    }

    public onDisKapiNoIkametBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.DisKapiNoIkamet != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.DisKapiNoIkamet = event;
            }
        }
    }

    public onIcKapiNoBeyanBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.IcKapiNoBeyan != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.IcKapiNoBeyan = event;
            }
        }
    }

    public onIcKapiNoIkametBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.IcKapiNoIkamet != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.IcKapiNoIkamet = event;
            }
        }
    }

    public onIkamet_BucakBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Bucak != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Bucak = event;
            }
        }
    }

    public onIkamet_CSBMBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_CSBM != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_CSBM = event;
            }
        }
    }

    public onIkamet_IlBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Il != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Il = event;
            }
        }
    }

    public onIkamet_IlceBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Ilce != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Ilce = event;
            }
        }
    }

    public onIkamet_KoyBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Koy != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Koy = event;
            }
        }
    }

    public onIkamet_MahalleBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Mahalle != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.Ikamet_Mahalle = event;
            }
        }
    }

    public onPaketeAitIslemZamaniBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.PaketeAitIslemZamani != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.PaketeAitIslemZamani = event;
            }
        }
    }

    public onResponsibleDoctorBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.ResponsibleDoctor != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.ResponsibleDoctor = event;
            }
        }
    }

    public onSKRSICDBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.SKRSICD != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.SKRSICD = event;
            }
        }
    }

    public onSKRSVakaTipiBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.SKRSVakaTipi != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.SKRSVakaTipi = event;
            }
        }
    }

    public onVakaDurumBulasiciHastalikVeriSetiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastaliklarEA != null &&
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti != null && this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.VakaDurum != event) {
                this._BulasiciHastaliklarEA.BulasiciHastalikVeriSeti.VakaDurum = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.PaketeAitIslemZamaniBulasiciHastalikVeriSeti, "Value", this.__ttObject, "BulasiciHastalikVeriSeti.PaketeAitIslemZamani");
        redirectProperty(this.BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti, "Value", this.__ttObject, i18n("M12104", "BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi"));
 	redirectProperty(this.VakaDurumBulasiciHastalikVeriSeti, "Value", this.__ttObject, "BulasiciHastalikVeriSeti.VakaDurum");
        redirectProperty(this.DisKapiNoBeyanBulasiciHastalikVeriSeti, "Text", this.__ttObject, "BulasiciHastalikVeriSeti.DisKapiNoBeyan");
        redirectProperty(this.DisKapiNoIkametBulasiciHastalikVeriSeti, "Text", this.__ttObject, "BulasiciHastalikVeriSeti.DisKapiNoIkamet");
        redirectProperty(this.IcKapiNoBeyanBulasiciHastalikVeriSeti, "Text", this.__ttObject, "BulasiciHastalikVeriSeti.IcKapiNoBeyan");
        redirectProperty(this.IcKapiNoIkametBulasiciHastalikVeriSeti, "Text", this.__ttObject, "BulasiciHastalikVeriSeti.IcKapiNoIkamet");
    }

    public initFormControls(): void {
        this.labelVakaDurumBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelVakaDurumBulasiciHastalikVeriSeti.Text = "Vaka Durumu";
        this.labelVakaDurumBulasiciHastalikVeriSeti.Name = "labelVakaDurumBulasiciHastalikVeriSeti";
        this.labelVakaDurumBulasiciHastalikVeriSeti.TabIndex = 44;

        this.VakaDurumBulasiciHastalikVeriSeti = new TTVisual.TTEnumComboBox();
        this.VakaDurumBulasiciHastalikVeriSeti.DataTypeName = "DeathAliveEnum";
        this.VakaDurumBulasiciHastalikVeriSeti.Name = "VakaDurumBulasiciHastalikVeriSeti";
        this.VakaDurumBulasiciHastalikVeriSeti.TabIndex = 43;

        this.labelBeyan_CSBMBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelBeyan_CSBMBulasiciHastalikVeriSeti.Text = i18n("M12294", "CSBM Tipi");
        this.labelBeyan_CSBMBulasiciHastalikVeriSeti.Name = "labelBeyan_CSBMBulasiciHastalikVeriSeti";
        this.labelBeyan_CSBMBulasiciHastalikVeriSeti.TabIndex = 42;

        this.Beyan_CSBMBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Beyan_CSBMBulasiciHastalikVeriSeti.ListDefName = "SKRSCSBMTipiList";
        this.Beyan_CSBMBulasiciHastalikVeriSeti.Name = "Beyan_CSBMBulasiciHastalikVeriSeti";
        this.Beyan_CSBMBulasiciHastalikVeriSeti.TabIndex = 41;

        this.labelBeyan_MahalleBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelBeyan_MahalleBulasiciHastalikVeriSeti.Text = i18n("M18436", "Mahalle");
        this.labelBeyan_MahalleBulasiciHastalikVeriSeti.Name = "labelBeyan_MahalleBulasiciHastalikVeriSeti";
        this.labelBeyan_MahalleBulasiciHastalikVeriSeti.TabIndex = 40;

        this.Beyan_MahalleBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Beyan_MahalleBulasiciHastalikVeriSeti.ListDefName = "SKRSMahalleKodlariList";
        this.Beyan_MahalleBulasiciHastalikVeriSeti.Name = "Beyan_MahalleBulasiciHastalikVeriSeti";
        this.Beyan_MahalleBulasiciHastalikVeriSeti.TabIndex = 39;

        this.labelBeyan_KoyBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelBeyan_KoyBulasiciHastalikVeriSeti.Text = i18n("M17842", "Koy");
        this.labelBeyan_KoyBulasiciHastalikVeriSeti.Name = "labelBeyan_KoyBulasiciHastalikVeriSeti";
        this.labelBeyan_KoyBulasiciHastalikVeriSeti.TabIndex = 38;

        this.Beyan_KoyBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Beyan_KoyBulasiciHastalikVeriSeti.ListDefName = "SKRSKoyKodlariList";
        this.Beyan_KoyBulasiciHastalikVeriSeti.Name = "Beyan_KoyBulasiciHastalikVeriSeti";
        this.Beyan_KoyBulasiciHastalikVeriSeti.TabIndex = 37;

        this.labelBeyan_BucakBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelBeyan_BucakBulasiciHastalikVeriSeti.Text = i18n("M12097", "Bucak");
        this.labelBeyan_BucakBulasiciHastalikVeriSeti.Name = "labelBeyan_BucakBulasiciHastalikVeriSeti";
        this.labelBeyan_BucakBulasiciHastalikVeriSeti.TabIndex = 36;

        this.Beyan_BucakBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Beyan_BucakBulasiciHastalikVeriSeti.ListDefName = "SKRSBucakKodlariList";
        this.Beyan_BucakBulasiciHastalikVeriSeti.Name = "Beyan_BucakBulasiciHastalikVeriSeti";
        this.Beyan_BucakBulasiciHastalikVeriSeti.TabIndex = 35;

        this.labelIcKapiNoBeyanBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelIcKapiNoBeyanBulasiciHastalikVeriSeti.Text = i18n("M16163", "İç Kapı No");
        this.labelIcKapiNoBeyanBulasiciHastalikVeriSeti.Name = "labelIcKapiNoBeyanBulasiciHastalikVeriSeti";
        this.labelIcKapiNoBeyanBulasiciHastalikVeriSeti.TabIndex = 34;

        this.IcKapiNoBeyanBulasiciHastalikVeriSeti = new TTVisual.TTTextBox();
        this.IcKapiNoBeyanBulasiciHastalikVeriSeti.Name = "IcKapiNoBeyanBulasiciHastalikVeriSeti";
        this.IcKapiNoBeyanBulasiciHastalikVeriSeti.TabIndex = 33;

        this.DisKapiNoBeyanBulasiciHastalikVeriSeti = new TTVisual.TTTextBox();
        this.DisKapiNoBeyanBulasiciHastalikVeriSeti.Name = "DisKapiNoBeyanBulasiciHastalikVeriSeti";
        this.DisKapiNoBeyanBulasiciHastalikVeriSeti.TabIndex = 31;

        this.IcKapiNoIkametBulasiciHastalikVeriSeti = new TTVisual.TTTextBox();
        this.IcKapiNoIkametBulasiciHastalikVeriSeti.Name = "IcKapiNoIkametBulasiciHastalikVeriSeti";
        this.IcKapiNoIkametBulasiciHastalikVeriSeti.TabIndex = 21;
        this.IcKapiNoIkametBulasiciHastalikVeriSeti.Enabled = false;

        this.DisKapiNoIkametBulasiciHastalikVeriSeti = new TTVisual.TTTextBox();
        this.DisKapiNoIkametBulasiciHastalikVeriSeti.Name = "DisKapiNoIkametBulasiciHastalikVeriSeti";
        this.DisKapiNoIkametBulasiciHastalikVeriSeti.TabIndex = 19;
        this.DisKapiNoIkametBulasiciHastalikVeriSeti.Enabled = false;

        this.labelDisKapiNoBeyanBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelDisKapiNoBeyanBulasiciHastalikVeriSeti.Text = i18n("M12746", "Dış Kapı No");
        this.labelDisKapiNoBeyanBulasiciHastalikVeriSeti.Name = "labelDisKapiNoBeyanBulasiciHastalikVeriSeti";
        this.labelDisKapiNoBeyanBulasiciHastalikVeriSeti.TabIndex = 32;

        this.labelIkamet_CSBMBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelIkamet_CSBMBulasiciHastalikVeriSeti.Text = i18n("M12294", "CSBM Tipi");
        this.labelIkamet_CSBMBulasiciHastalikVeriSeti.Name = "labelIkamet_CSBMBulasiciHastalikVeriSeti";
        this.labelIkamet_CSBMBulasiciHastalikVeriSeti.TabIndex = 30;

        this.Ikamet_CSBMBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Ikamet_CSBMBulasiciHastalikVeriSeti.ListDefName = "SKRSCSBMTipiList";
        this.Ikamet_CSBMBulasiciHastalikVeriSeti.Name = "Ikamet_CSBMBulasiciHastalikVeriSeti";
        this.Ikamet_CSBMBulasiciHastalikVeriSeti.TabIndex = 29;
        this.Ikamet_CSBMBulasiciHastalikVeriSeti.Enabled = false;

        this.labelIkamet_MahalleBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelIkamet_MahalleBulasiciHastalikVeriSeti.Text = i18n("M18436", "Mahalle");
        this.labelIkamet_MahalleBulasiciHastalikVeriSeti.Name = "labelIkamet_MahalleBulasiciHastalikVeriSeti";
        this.labelIkamet_MahalleBulasiciHastalikVeriSeti.TabIndex = 28;

        this.Ikamet_MahalleBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Ikamet_MahalleBulasiciHastalikVeriSeti.ListDefName = "SKRSMahalleKodlariList";
        this.Ikamet_MahalleBulasiciHastalikVeriSeti.Name = "Ikamet_MahalleBulasiciHastalikVeriSeti";
        this.Ikamet_MahalleBulasiciHastalikVeriSeti.TabIndex = 27;
        this.Ikamet_MahalleBulasiciHastalikVeriSeti.Enabled = false;

        this.labelIkamet_KoyBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelIkamet_KoyBulasiciHastalikVeriSeti.Text = i18n("M17842", "Koy");
        this.labelIkamet_KoyBulasiciHastalikVeriSeti.Name = "labelIkamet_KoyBulasiciHastalikVeriSeti";
        this.labelIkamet_KoyBulasiciHastalikVeriSeti.TabIndex = 26;

        this.Ikamet_KoyBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Ikamet_KoyBulasiciHastalikVeriSeti.ListDefName = "SKRSKoyKodlariList";
        this.Ikamet_KoyBulasiciHastalikVeriSeti.Name = "Ikamet_KoyBulasiciHastalikVeriSeti";
        this.Ikamet_KoyBulasiciHastalikVeriSeti.TabIndex = 25;
        this.Ikamet_KoyBulasiciHastalikVeriSeti.Enabled = false;

        this.labelIkamet_BucakBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelIkamet_BucakBulasiciHastalikVeriSeti.Text = i18n("M12097", "Bucak");
        this.labelIkamet_BucakBulasiciHastalikVeriSeti.Name = "labelIkamet_BucakBulasiciHastalikVeriSeti";
        this.labelIkamet_BucakBulasiciHastalikVeriSeti.TabIndex = 24;

        this.Ikamet_BucakBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Ikamet_BucakBulasiciHastalikVeriSeti.ListDefName = "SKRSBucakKodlariList";
        this.Ikamet_BucakBulasiciHastalikVeriSeti.Name = "Ikamet_BucakBulasiciHastalikVeriSeti";
        this.Ikamet_BucakBulasiciHastalikVeriSeti.TabIndex = 23;
        this.Ikamet_BucakBulasiciHastalikVeriSeti.Enabled = false;

        this.labelIcKapiNoIkametBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelIcKapiNoIkametBulasiciHastalikVeriSeti.Text = i18n("M16163", "İç Kapı No");
        this.labelIcKapiNoIkametBulasiciHastalikVeriSeti.Name = "labelIcKapiNoIkametBulasiciHastalikVeriSeti";
        this.labelIcKapiNoIkametBulasiciHastalikVeriSeti.TabIndex = 22;

        this.labelDisKapiNoIkametBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelDisKapiNoIkametBulasiciHastalikVeriSeti.Text = i18n("M12746", "Dış Kapı No");
        this.labelDisKapiNoIkametBulasiciHastalikVeriSeti.Name = "labelDisKapiNoIkametBulasiciHastalikVeriSeti";
        this.labelDisKapiNoIkametBulasiciHastalikVeriSeti.TabIndex = 20;

        //this.BulasiciHastalikTelefonBulasiciHastalikTelefon = new TTVisual.TTGrid();
        //this.BulasiciHastalikTelefonBulasiciHastalikTelefon.Name = "BulasiciHastalikTelefonBulasiciHastalikTelefon";
        //this.BulasiciHastalikTelefonBulasiciHastalikTelefon.TabIndex = 18;

        this.BulasiciHastalikTelefonBulasiciHastalikTelefon = new TTVisual.TTGrid();
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.Name = "BulasiciHastalikTelefonBulasiciHastalikTelefon";
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.TabIndex = 0;
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.Height = "150px";
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.ShowFilterCombo = true;
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.FilterColumnName = "SKRSTelefonTipiBulasiciHastalikTelefon";
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.FilterLabel = i18n("M23142", "Telefon Tipi");
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.Filter = { ListDefName: "SKRSTelefonTipiList" };
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.AllowUserToAddRows = false;
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.DeleteButtonWidth = "5%";
        this.BulasiciHastalikTelefonBulasiciHastalikTelefon.AllowUserToDeleteRows = true;

        this.SKRSTelefonTipiBulasiciHastalikTelefon = new TTVisual.TTListBoxColumn();
        this.SKRSTelefonTipiBulasiciHastalikTelefon.ListDefName = "SKRSTelefonTipiList";
        this.SKRSTelefonTipiBulasiciHastalikTelefon.DataMember = "SKRSTelefonTipi";
        this.SKRSTelefonTipiBulasiciHastalikTelefon.DisplayIndex = 0;
        this.SKRSTelefonTipiBulasiciHastalikTelefon.HeaderText = i18n("M23142", "Telefon Tipi");
        this.SKRSTelefonTipiBulasiciHastalikTelefon.Name = "SKRSTelefonTipiBulasiciHastalikTelefon";
        this.SKRSTelefonTipiBulasiciHastalikTelefon.Width = "45%";

        //this.BulasiciHastalikVeriSetiBulasiciHastalikTelefon = new TTVisual.TTListBoxColumn();
        //this.BulasiciHastalikVeriSetiBulasiciHastalikTelefon.DataMember = "BulasiciHastalikVeriSeti";
        //this.BulasiciHastalikVeriSetiBulasiciHastalikTelefon.DisplayIndex = 1;
        //this.BulasiciHastalikVeriSetiBulasiciHastalikTelefon.HeaderText = "Telefon Tipi";
        //this.BulasiciHastalikVeriSetiBulasiciHastalikTelefon.Name = "BulasiciHastalikVeriSetiBulasiciHastalikTelefon";
        //this.BulasiciHastalikVeriSetiBulasiciHastalikTelefon.Width = 300;

        this.TelefonNumarasiBulasiciHastalikTelefon = new TTVisual.TTTextBoxColumn();
        this.TelefonNumarasiBulasiciHastalikTelefon.DataMember = "TelefonNumarasi";
        this.TelefonNumarasiBulasiciHastalikTelefon.DisplayIndex = 2;
        this.TelefonNumarasiBulasiciHastalikTelefon.HeaderText = i18n("M23138", "Telefon Numarası");
        this.TelefonNumarasiBulasiciHastalikTelefon.Name = "TelefonNumarasiBulasiciHastalikTelefon";
        this.TelefonNumarasiBulasiciHastalikTelefon.Width = "45%";

        this.labelResponsibleDoctorBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelResponsibleDoctorBulasiciHastalikVeriSeti.Text = "Doktor";
        this.labelResponsibleDoctorBulasiciHastalikVeriSeti.Name = "labelResponsibleDoctorBulasiciHastalikVeriSeti";
        this.labelResponsibleDoctorBulasiciHastalikVeriSeti.TabIndex = 17;

        this.ResponsibleDoctorBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.ResponsibleDoctorBulasiciHastalikVeriSeti.ListDefName = "DoctorListDefinition";
        this.ResponsibleDoctorBulasiciHastalikVeriSeti.Name = "ResponsibleDoctorBulasiciHastalikVeriSeti";
        this.ResponsibleDoctorBulasiciHastalikVeriSeti.TabIndex = 16;
        this.ResponsibleDoctorBulasiciHastalikVeriSeti.Enabled = false;

        this.labelSKRSICDBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelSKRSICDBulasiciHastalikVeriSeti.Text = i18n("M22736", "Tanı");
        this.labelSKRSICDBulasiciHastalikVeriSeti.Name = "labelSKRSICDBulasiciHastalikVeriSeti";
        this.labelSKRSICDBulasiciHastalikVeriSeti.TabIndex = 15;

        this.SKRSICDBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.SKRSICDBulasiciHastalikVeriSeti.ListDefName = "SKRSICDList";
        this.SKRSICDBulasiciHastalikVeriSeti.Name = "SKRSICDBulasiciHastalikVeriSeti";
        this.SKRSICDBulasiciHastalikVeriSeti.TabIndex = 14;
        this.SKRSICDBulasiciHastalikVeriSeti.Enabled = false;

        this.labelSKRSVakaTipiBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelSKRSVakaTipiBulasiciHastalikVeriSeti.Text = i18n("M24030", "Vaka Tipi");
        this.labelSKRSVakaTipiBulasiciHastalikVeriSeti.Name = "labelSKRSVakaTipiBulasiciHastalikVeriSeti";
        this.labelSKRSVakaTipiBulasiciHastalikVeriSeti.TabIndex = 13;

        this.SKRSVakaTipiBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.SKRSVakaTipiBulasiciHastalikVeriSeti.Required = true;
        this.SKRSVakaTipiBulasiciHastalikVeriSeti.ListDefName = "SKRSVakaTipiList";
        this.SKRSVakaTipiBulasiciHastalikVeriSeti.Name = "SKRSVakaTipiBulasiciHastalikVeriSeti";
        this.SKRSVakaTipiBulasiciHastalikVeriSeti.TabIndex = 12;
        this.SKRSVakaTipiBulasiciHastalikVeriSeti.Enabled = false;

        this.labelBeyan_IlceBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelBeyan_IlceBulasiciHastalikVeriSeti.Text = i18n("M16396", "İlçe");
        this.labelBeyan_IlceBulasiciHastalikVeriSeti.Name = "labelBeyan_IlceBulasiciHastalikVeriSeti";
        this.labelBeyan_IlceBulasiciHastalikVeriSeti.TabIndex = 11;

        this.Beyan_IlceBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Beyan_IlceBulasiciHastalikVeriSeti.ListDefName = "SKRSIlceKodlariList";
        this.Beyan_IlceBulasiciHastalikVeriSeti.Name = "Beyan_IlceBulasiciHastalikVeriSeti";
        this.Beyan_IlceBulasiciHastalikVeriSeti.TabIndex = 10;

        this.labelIkamet_IlceBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelIkamet_IlceBulasiciHastalikVeriSeti.Text = i18n("M16396", "İlçe");
        this.labelIkamet_IlceBulasiciHastalikVeriSeti.Name = "labelIkamet_IlceBulasiciHastalikVeriSeti";
        this.labelIkamet_IlceBulasiciHastalikVeriSeti.TabIndex = 9;

        this.Ikamet_IlceBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Ikamet_IlceBulasiciHastalikVeriSeti.ListDefName = "SKRSIlceKodlariList";
        this.Ikamet_IlceBulasiciHastalikVeriSeti.Name = "Ikamet_IlceBulasiciHastalikVeriSeti";
        this.Ikamet_IlceBulasiciHastalikVeriSeti.TabIndex = 8;
        this.Ikamet_IlceBulasiciHastalikVeriSeti.Enabled = false;

        this.labelBeyan_IlBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelBeyan_IlBulasiciHastalikVeriSeti.Text = i18n("M16269", "İl");
        this.labelBeyan_IlBulasiciHastalikVeriSeti.Name = "labelBeyan_IlBulasiciHastalikVeriSeti";
        this.labelBeyan_IlBulasiciHastalikVeriSeti.TabIndex = 7;

        this.Beyan_IlBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Beyan_IlBulasiciHastalikVeriSeti.ListDefName = "SKRSILKodlariList";
        this.Beyan_IlBulasiciHastalikVeriSeti.Name = "Beyan_IlBulasiciHastalikVeriSeti";
        this.Beyan_IlBulasiciHastalikVeriSeti.TabIndex = 6;

        this.labelIkamet_IlBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelIkamet_IlBulasiciHastalikVeriSeti.Text = i18n("M16269", "İl");
        this.labelIkamet_IlBulasiciHastalikVeriSeti.Name = "labelIkamet_IlBulasiciHastalikVeriSeti";
        this.labelIkamet_IlBulasiciHastalikVeriSeti.TabIndex = 5;

        this.Ikamet_IlBulasiciHastalikVeriSeti = new TTVisual.TTObjectListBox();
        this.Ikamet_IlBulasiciHastalikVeriSeti.ListDefName = "SKRSILKodlariList";
        this.Ikamet_IlBulasiciHastalikVeriSeti.Name = "Ikamet_IlBulasiciHastalikVeriSeti";
        this.Ikamet_IlBulasiciHastalikVeriSeti.TabIndex = 4;
        this.Ikamet_IlBulasiciHastalikVeriSeti.Enabled = false;

        this.labelBelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelBelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti.Text = i18n("M11758", "Belirtilerin Başlama Tarihi");
        this.labelBelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti.Name = "labelBelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti";
        this.labelBelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti.TabIndex = 3;

        this.BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti = new TTVisual.TTDateTimePicker();
        this.BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti.Required = true;
        this.BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti.BackColor = "#FFE3C6";
        this.BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti.Format = DateTimePickerFormat.Long;
        this.BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti.Name = "BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti";
        this.BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti.TabIndex = 2;
        this.BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti.Enabled = false;

        this.labelPaketeAitIslemZamaniBulasiciHastalikVeriSeti = new TTVisual.TTLabel();
        this.labelPaketeAitIslemZamaniBulasiciHastalikVeriSeti.Text = i18n("M20178", "Pakete Ait İşlem Zamanı");
        this.labelPaketeAitIslemZamaniBulasiciHastalikVeriSeti.Name = "labelPaketeAitIslemZamaniBulasiciHastalikVeriSeti";
        this.labelPaketeAitIslemZamaniBulasiciHastalikVeriSeti.TabIndex = 1;

        this.PaketeAitIslemZamaniBulasiciHastalikVeriSeti = new TTVisual.TTDateTimePicker();
        this.PaketeAitIslemZamaniBulasiciHastalikVeriSeti.Format = DateTimePickerFormat.Long;
        this.PaketeAitIslemZamaniBulasiciHastalikVeriSeti.Name = "PaketeAitIslemZamaniBulasiciHastalikVeriSeti";
        this.PaketeAitIslemZamaniBulasiciHastalikVeriSeti.TabIndex = 0;
        this.PaketeAitIslemZamaniBulasiciHastalikVeriSeti.Enabled = false;

        //this.BulasiciHastalikTelefonBulasiciHastalikTelefonColumns = [this.SKRSTelefonTipiBulasiciHastalikTelefon, this.TelefonNumarasiBulasiciHastalikTelefon];
        this.Controls = [this.labelVakaDurumBulasiciHastalikVeriSeti, this.VakaDurumBulasiciHastalikVeriSeti, this.labelBeyan_CSBMBulasiciHastalikVeriSeti, this.Beyan_CSBMBulasiciHastalikVeriSeti, this.labelBeyan_MahalleBulasiciHastalikVeriSeti, this.Beyan_MahalleBulasiciHastalikVeriSeti, this.labelBeyan_KoyBulasiciHastalikVeriSeti, this.Beyan_KoyBulasiciHastalikVeriSeti, this.labelBeyan_BucakBulasiciHastalikVeriSeti, this.Beyan_BucakBulasiciHastalikVeriSeti, this.labelIcKapiNoBeyanBulasiciHastalikVeriSeti, this.IcKapiNoBeyanBulasiciHastalikVeriSeti, this.DisKapiNoBeyanBulasiciHastalikVeriSeti, this.IcKapiNoIkametBulasiciHastalikVeriSeti, this.DisKapiNoIkametBulasiciHastalikVeriSeti, this.labelDisKapiNoBeyanBulasiciHastalikVeriSeti, this.labelIkamet_CSBMBulasiciHastalikVeriSeti, this.Ikamet_CSBMBulasiciHastalikVeriSeti, this.labelIkamet_MahalleBulasiciHastalikVeriSeti, this.Ikamet_MahalleBulasiciHastalikVeriSeti, this.labelIkamet_KoyBulasiciHastalikVeriSeti, this.Ikamet_KoyBulasiciHastalikVeriSeti, this.labelIkamet_BucakBulasiciHastalikVeriSeti, this.Ikamet_BucakBulasiciHastalikVeriSeti, this.labelIcKapiNoIkametBulasiciHastalikVeriSeti, this.labelDisKapiNoIkametBulasiciHastalikVeriSeti, this.BulasiciHastalikTelefonBulasiciHastalikTelefon, this.SKRSTelefonTipiBulasiciHastalikTelefon, this.BulasiciHastalikVeriSetiBulasiciHastalikTelefon, this.TelefonNumarasiBulasiciHastalikTelefon, this.labelResponsibleDoctorBulasiciHastalikVeriSeti, this.ResponsibleDoctorBulasiciHastalikVeriSeti, this.labelSKRSICDBulasiciHastalikVeriSeti, this.SKRSICDBulasiciHastalikVeriSeti, this.labelSKRSVakaTipiBulasiciHastalikVeriSeti, this.SKRSVakaTipiBulasiciHastalikVeriSeti, this.labelBeyan_IlceBulasiciHastalikVeriSeti, this.Beyan_IlceBulasiciHastalikVeriSeti, this.labelIkamet_IlceBulasiciHastalikVeriSeti, this.Ikamet_IlceBulasiciHastalikVeriSeti, this.labelBeyan_IlBulasiciHastalikVeriSeti, this.Beyan_IlBulasiciHastalikVeriSeti, this.labelIkamet_IlBulasiciHastalikVeriSeti, this.Ikamet_IlBulasiciHastalikVeriSeti, this.labelBelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti, this.BelirtilerinBaslamaTarihiBulasiciHastalikVeriSeti, this.labelPaketeAitIslemZamaniBulasiciHastalikVeriSeti, this.PaketeAitIslemZamaniBulasiciHastalikVeriSeti];

    }

    ShowForm014(): void {
        const objectIdParam = new GuidParam(this.bulasiciHastaliklarFormViewModel._BulasiciHastaliklarEA.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('Form014', reportParameters);
    }

    GenerateTelListColumns() {
        let that = this;

        this.BulasiciHastalikTelefonBulasiciHastalikTelefonColumns = [
             {
                caption: "",
                dataField: 'SKRSTelefonTipi.ObjectID',
                fixed: true, width: '50%',
                allowSorting: false,
                allowEditing: true,
                lookup: {
                    dataSource: that.telefonTipiArray, valueExpr: 'ObjectID', displayExpr: 'ADI'
                }
            },
            {
                caption: 'Telefon Numarası',
                dataField: 'TelefonNumarasi',
                fixed: true,
                width: '50%',
                allowSorting: false,
                allowEditing: true
            }
        ];

    }

    public async TelefonTipi(): Promise<any> {
        if (!this.TelefonTipiCache) {
            this.TelefonTipiCache = await this.httpService.get('/api/BulasiciHastalikVeriSetiService/GetSKRSTelefonTipi');
            return this.TelefonTipiCache;
        }
        else {
            return this.TelefonTipiCache;
        }
    }
}
