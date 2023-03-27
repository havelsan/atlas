//$A18D205A
import { Component, OnInit, NgZone  } from '@angular/core';
import { KuduzRiskliTemasVeriSetiFormViewModel } from './KuduzRiskliTemasVeriSetiFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { KuduzRiskliTemasVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { KuduzRiskliTemasAdres } from 'NebulaClient/Model/AtlasClientModel';
import { KuduzRiskliTemasPlanProfBi } from 'NebulaClient/Model/AtlasClientModel';
import { KuduzRiskliTemasRiskTemTip } from 'NebulaClient/Model/AtlasClientModel';
import { KuduzRiskliTemasTelefon } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSHayvaninMevcutDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSHayvaninSahiplikDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSImmunglobulinTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKategorizasyon } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKuduzRiskliTemasDegerlendirmeDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSRiskliTemasaSebepOlanHayvan } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'KuduzRiskliTemasVeriSetiForm',
    templateUrl: './KuduzRiskliTemasVeriSetiForm.html',
    providers: [MessageService]
})
export class KuduzRiskliTemasVeriSetiForm extends TTVisual.TTForm implements OnInit {
    DisKapiKuduzRiskliTemasAdres: TTVisual.ITTTextBoxColumn;
    IcKapiKuduzRiskliTemasAdres: TTVisual.ITTTextBoxColumn;
    ImmunglobulinMiktari: TTVisual.ITTTextBox;
    Kilo: TTVisual.ITTTextBox;
    KuduzRiskliTemasAdres: TTVisual.ITTGrid;
    KuduzRiskliTemasPlanProfBi: TTVisual.ITTGrid;
    KuduzRiskliTemasRiskTemTip: TTVisual.ITTGrid;
    KuduzRiskliTemasTelefon: TTVisual.ITTGrid;
    labelImmunglobulinMiktari: TTVisual.ITTLabel;
    labelKilo: TTVisual.ITTLabel;
    labelRiskliTemasTarihi: TTVisual.ITTLabel;
    labelSKRSHayvaninMevcutDurumu: TTVisual.ITTLabel;
    labelSKRSHayvaninSahiplikDurumu: TTVisual.ITTLabel;
    labelSKRSImmunglobulinTuru: TTVisual.ITTLabel;
    labelSKRSKategorizasyon: TTVisual.ITTLabel;
    labelSKRSKuduzRiskliTemasDegDurumu: TTVisual.ITTLabel;
    labelSKRSRiskliTemasSebepOlHayvan: TTVisual.ITTLabel;
    RiskliTemasTarihi: TTVisual.ITTDateTimePicker;
    SKRSAdresTipiKuduzRiskliTemasAdres: TTVisual.ITTListBoxColumn;
    SKRSBucakKodlariKuduzRiskliTemasAdres: TTVisual.ITTListBoxColumn;
    SKRSCSBMTipiKuduzRiskliTemasAdres: TTVisual.ITTListBoxColumn;
    SKRSHayvaninMevcutDurumu: TTVisual.ITTObjectListBox;
    SKRSHayvaninSahiplikDurumu: TTVisual.ITTObjectListBox;
    SKRSIlceKodlariKuduzRiskliTemasAdres: TTVisual.ITTListBoxColumn;
    SKRSILKodlariKuduzRiskliTemasAdres: TTVisual.ITTListBoxColumn;
    SKRSImmunglobulinTuru: TTVisual.ITTObjectListBox;
    SKRSKategorizasyon: TTVisual.ITTObjectListBox;
    SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi: TTVisual.ITTListBoxColumn;
    SKRSKoyKodlariKuduzRiskliTemasAdres: TTVisual.ITTListBoxColumn;
    SKRSKuduzRiskliTemasDegDurumu: TTVisual.ITTObjectListBox;
    SKRSMahalleKodlariKuduzRiskliTemasAdres: TTVisual.ITTListBoxColumn;
    SKRSRiskliTemasSebepOlHayvan: TTVisual.ITTObjectListBox;
    SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip: TTVisual.ITTListBoxColumn;
    SKRSTelefonTipiKuduzRiskliTemasTelefon: TTVisual.ITTListBoxColumn;
    TelefonNumarasiKuduzRiskliTemasTelefon: TTVisual.ITTTextBoxColumn;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    RouteData: any;
    RouteData2: any;
    public KuduzRiskliTemasAdresColumns = [];
    public KuduzRiskliTemasPlanProfBiColumns = [];
    public KuduzRiskliTemasRiskTemTipColumns = [];
    public KuduzRiskliTemasTelefonColumns = [];
    public kuduzRiskliTemasVeriSetiFormViewModel: KuduzRiskliTemasVeriSetiFormViewModel = new KuduzRiskliTemasVeriSetiFormViewModel();
    public get _KuduzRiskliTemasVeriSeti(): KuduzRiskliTemasVeriSeti {
        return this._TTObject as KuduzRiskliTemasVeriSeti;
    }
    private KuduzRiskliTemasVeriSetiForm_DocumentUrl: string = '/api/KuduzRiskliTemasVeriSetiService/KuduzRiskliTemasVeriSetiForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('KUDUZRISKLITEMASVERISETI', 'KuduzRiskliTemasVeriSetiForm');
        this._DocumentServiceUrl = this.KuduzRiskliTemasVeriSetiForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new KuduzRiskliTemasVeriSeti();
        this.kuduzRiskliTemasVeriSetiFormViewModel = new KuduzRiskliTemasVeriSetiFormViewModel();
        this._ViewModel = this.kuduzRiskliTemasVeriSetiFormViewModel;
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti = this._TTObject as KuduzRiskliTemasVeriSeti;
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan = new SKRSRiskliTemasaSebepOlanHayvan();
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSKuduzRiskliTemasDegDurumu = new SKRSKuduzRiskliTemasDegerlendirmeDurumu();
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSKategorizasyon = new SKRSKategorizasyon();
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSImmunglobulinTuru = new SKRSImmunglobulinTuru();
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSHayvaninSahiplikDurumu = new SKRSHayvaninSahiplikDurumu();
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSHayvaninMevcutDurumu = new SKRSHayvaninMevcutDurumu();
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasTelefon = new Array<KuduzRiskliTemasTelefon>();
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip = new Array<KuduzRiskliTemasRiskTemTip>();
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasPlanProfBi = new Array<KuduzRiskliTemasPlanProfBi>();
        this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasAdres = new Array<KuduzRiskliTemasAdres>();
    }

    protected loadViewModel() {
        let that = this;
        that.kuduzRiskliTemasVeriSetiFormViewModel = this._ViewModel as KuduzRiskliTemasVeriSetiFormViewModel;
        that._TTObject = this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti;
        if (this.kuduzRiskliTemasVeriSetiFormViewModel == null)
            this.kuduzRiskliTemasVeriSetiFormViewModel = new KuduzRiskliTemasVeriSetiFormViewModel();
        if (this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti == null)
            this.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti = new KuduzRiskliTemasVeriSeti();
        let sKRSRiskliTemasSebepOlHayvanObjectID = that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti["SKRSRiskliTemasSebepOlHayvan"];
        if (sKRSRiskliTemasSebepOlHayvanObjectID != null && (typeof sKRSRiskliTemasSebepOlHayvanObjectID === "string")) {
            let sKRSRiskliTemasSebepOlHayvan = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSRiskliTemasaSebepOlanHayvans.find(o => o.ObjectID.toString() === sKRSRiskliTemasSebepOlHayvanObjectID.toString());
             if (sKRSRiskliTemasSebepOlHayvan) {
                that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan = sKRSRiskliTemasSebepOlHayvan;
            }
        }
        let sKRSKuduzRiskliTemasDegDurumuObjectID = that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti["SKRSKuduzRiskliTemasDegDurumu"];
        if (sKRSKuduzRiskliTemasDegDurumuObjectID != null && (typeof sKRSKuduzRiskliTemasDegDurumuObjectID === "string")) {
            let sKRSKuduzRiskliTemasDegDurumu = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSKuduzRiskliTemasDegerlendirmeDurumus.find(o => o.ObjectID.toString() === sKRSKuduzRiskliTemasDegDurumuObjectID.toString());
             if (sKRSKuduzRiskliTemasDegDurumu) {
                that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSKuduzRiskliTemasDegDurumu = sKRSKuduzRiskliTemasDegDurumu;
            }
        }
        let sKRSKategorizasyonObjectID = that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti["SKRSKategorizasyon"];
        if (sKRSKategorizasyonObjectID != null && (typeof sKRSKategorizasyonObjectID === "string")) {
            let sKRSKategorizasyon = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSKategorizasyons.find(o => o.ObjectID.toString() === sKRSKategorizasyonObjectID.toString());
             if (sKRSKategorizasyon) {
                that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSKategorizasyon = sKRSKategorizasyon;
            }
        }
        let sKRSImmunglobulinTuruObjectID = that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti["SKRSImmunglobulinTuru"];
        if (sKRSImmunglobulinTuruObjectID != null && (typeof sKRSImmunglobulinTuruObjectID === "string")) {
            let sKRSImmunglobulinTuru = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSImmunglobulinTurus.find(o => o.ObjectID.toString() === sKRSImmunglobulinTuruObjectID.toString());
             if (sKRSImmunglobulinTuru) {
                that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSImmunglobulinTuru = sKRSImmunglobulinTuru;
            }
        }
        let sKRSHayvaninSahiplikDurumuObjectID = that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti["SKRSHayvaninSahiplikDurumu"];
        if (sKRSHayvaninSahiplikDurumuObjectID != null && (typeof sKRSHayvaninSahiplikDurumuObjectID === "string")) {
            let sKRSHayvaninSahiplikDurumu = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSHayvaninSahiplikDurumus.find(o => o.ObjectID.toString() === sKRSHayvaninSahiplikDurumuObjectID.toString());
             if (sKRSHayvaninSahiplikDurumu) {
                that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSHayvaninSahiplikDurumu = sKRSHayvaninSahiplikDurumu;
            }
        }
        let sKRSHayvaninMevcutDurumuObjectID = that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti["SKRSHayvaninMevcutDurumu"];
        if (sKRSHayvaninMevcutDurumuObjectID != null && (typeof sKRSHayvaninMevcutDurumuObjectID === "string")) {
            let sKRSHayvaninMevcutDurumu = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSHayvaninMevcutDurumus.find(o => o.ObjectID.toString() === sKRSHayvaninMevcutDurumuObjectID.toString());
             if (sKRSHayvaninMevcutDurumu) {
                that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.SKRSHayvaninMevcutDurumu = sKRSHayvaninMevcutDurumu;
            }
        }
        that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasTelefon = that.kuduzRiskliTemasVeriSetiFormViewModel.KuduzRiskliTemasTelefonGridList;
        for (let detailItem of that.kuduzRiskliTemasVeriSetiFormViewModel.KuduzRiskliTemasTelefonGridList) {
            let sKRSTelefonTipiObjectID = detailItem["SKRSTelefonTipi"];
            if (sKRSTelefonTipiObjectID != null && (typeof sKRSTelefonTipiObjectID === "string")) {
                let sKRSTelefonTipi = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSTelefonTipis.find(o => o.ObjectID.toString() === sKRSTelefonTipiObjectID.toString());
                 if (sKRSTelefonTipi) {
                    detailItem.SKRSTelefonTipi = sKRSTelefonTipi;
                }
            }
        }
        that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip = that.kuduzRiskliTemasVeriSetiFormViewModel.KuduzRiskliTemasRiskTemTipGridList;
        for (let detailItem of that.kuduzRiskliTemasVeriSetiFormViewModel.KuduzRiskliTemasRiskTemTipGridList) {
            let sKRSRiskliTemasTipiObjectID = detailItem["SKRSRiskliTemasTipi"];
            if (sKRSRiskliTemasTipiObjectID != null && (typeof sKRSRiskliTemasTipiObjectID === "string")) {
                let sKRSRiskliTemasTipi = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSRiskliTemasTipis.find(o => o.ObjectID.toString() === sKRSRiskliTemasTipiObjectID.toString());
                 if (sKRSRiskliTemasTipi) {
                    detailItem.SKRSRiskliTemasTipi = sKRSRiskliTemasTipi;
                }
            }
        }
        that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasPlanProfBi = that.kuduzRiskliTemasVeriSetiFormViewModel.KuduzRiskliTemasPlanProfBiGridList;
        for (let detailItem of that.kuduzRiskliTemasVeriSetiFormViewModel.KuduzRiskliTemasPlanProfBiGridList) {
            let sKRSKisiyePlanKuduzProfilaksiObjectID = detailItem["SKRSKisiyePlanKuduzProfilaksi"];
            if (sKRSKisiyePlanKuduzProfilaksiObjectID != null && (typeof sKRSKisiyePlanKuduzProfilaksiObjectID === "string")) {
                let sKRSKisiyePlanKuduzProfilaksi = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSKisiyePlanlananKuduzProfilaksisis.find(o => o.ObjectID.toString() === sKRSKisiyePlanKuduzProfilaksiObjectID.toString());
                 if (sKRSKisiyePlanKuduzProfilaksi) {
                    detailItem.SKRSKisiyePlanKuduzProfilaksi = sKRSKisiyePlanKuduzProfilaksi;
                }
            }
        }
        that.kuduzRiskliTemasVeriSetiFormViewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasAdres = that.kuduzRiskliTemasVeriSetiFormViewModel.KuduzRiskliTemasAdresGridList;
        for (let detailItem of that.kuduzRiskliTemasVeriSetiFormViewModel.KuduzRiskliTemasAdresGridList) {
            let sKRSAdresTipiObjectID = detailItem["SKRSAdresTipi"];
            if (sKRSAdresTipiObjectID != null && (typeof sKRSAdresTipiObjectID === "string")) {
                let sKRSAdresTipi = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSAdresTipis.find(o => o.ObjectID.toString() === sKRSAdresTipiObjectID.toString());
                 if (sKRSAdresTipi) {
                    detailItem.SKRSAdresTipi = sKRSAdresTipi;
                }
            }
            let sKRSBucakKodlariObjectID = detailItem["SKRSBucakKodlari"];
            if (sKRSBucakKodlariObjectID != null && (typeof sKRSBucakKodlariObjectID === "string")) {
                let sKRSBucakKodlari = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSBucakKodlaris.find(o => o.ObjectID.toString() === sKRSBucakKodlariObjectID.toString());
                 if (sKRSBucakKodlari) {
                    detailItem.SKRSBucakKodlari = sKRSBucakKodlari;
                }
            }
            let sKRSCSBMTipiObjectID = detailItem["SKRSCSBMTipi"];
            if (sKRSCSBMTipiObjectID != null && (typeof sKRSCSBMTipiObjectID === "string")) {
                let sKRSCSBMTipi = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSCSBMTipis.find(o => o.ObjectID.toString() === sKRSCSBMTipiObjectID.toString());
                 if (sKRSCSBMTipi) {
                    detailItem.SKRSCSBMTipi = sKRSCSBMTipi;
                }
            }
            let sKRSIlceKodlariObjectID = detailItem["SKRSIlceKodlari"];
            if (sKRSIlceKodlariObjectID != null && (typeof sKRSIlceKodlariObjectID === "string")) {
                let sKRSIlceKodlari = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === sKRSIlceKodlariObjectID.toString());
                 if (sKRSIlceKodlari) {
                    detailItem.SKRSIlceKodlari = sKRSIlceKodlari;
                }
            }
            let sKRSILKodlariObjectID = detailItem["SKRSILKodlari"];
            if (sKRSILKodlariObjectID != null && (typeof sKRSILKodlariObjectID === "string")) {
                let sKRSILKodlari = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === sKRSILKodlariObjectID.toString());
                 if (sKRSILKodlari) {
                    detailItem.SKRSILKodlari = sKRSILKodlari;
                }
            }
            let sKRSKoyKodlariObjectID = detailItem["SKRSKoyKodlari"];
            if (sKRSKoyKodlariObjectID != null && (typeof sKRSKoyKodlariObjectID === "string")) {
                let sKRSKoyKodlari = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSKoyKodlaris.find(o => o.ObjectID.toString() === sKRSKoyKodlariObjectID.toString());
                 if (sKRSKoyKodlari) {
                    detailItem.SKRSKoyKodlari = sKRSKoyKodlari;
                }
            }
            let sKRSMahalleKodlariObjectID = detailItem["SKRSMahalleKodlari"];
            if (sKRSMahalleKodlariObjectID != null && (typeof sKRSMahalleKodlariObjectID === "string")) {
                let sKRSMahalleKodlari = that.kuduzRiskliTemasVeriSetiFormViewModel.SKRSMahalleKodlaris.find(o => o.ObjectID.toString() === sKRSMahalleKodlariObjectID.toString());
                 if (sKRSMahalleKodlari) {
                    detailItem.SKRSMahalleKodlari = sKRSMahalleKodlari;
                }
            }
        }

    }


    async ngOnInit() {
        let that = this;
        if (this.RouteData2 != null){
            this.ObjectID = this.RouteData2.ObjectID;
            this.ActiveIDsModel = new ActiveIDsModel(this.RouteData2.EpisodeActionID, null, null);
       
        }
        await this.load(KuduzRiskliTemasVeriSetiFormViewModel);
  
    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.kuduzRiskliTemasVeriSetiFormViewModel);


    }


    public onImmunglobulinMiktariChanged(event): void {
        if (event != null) {
            if (this._KuduzRiskliTemasVeriSeti != null && this._KuduzRiskliTemasVeriSeti.ImmunglobulinMiktari != event) {
                this._KuduzRiskliTemasVeriSeti.ImmunglobulinMiktari = event;
            }
        }
    }

    public onKiloChanged(event): void {
        if (event != null) {
            if (this._KuduzRiskliTemasVeriSeti != null && this._KuduzRiskliTemasVeriSeti.Kilo != event) {
                this._KuduzRiskliTemasVeriSeti.Kilo = event;
            }
        }
    }

    public onRiskliTemasTarihiChanged(event): void {
        if (event != null) {
            if (this._KuduzRiskliTemasVeriSeti != null && this._KuduzRiskliTemasVeriSeti.RiskliTemasTarihi != event) {
                this._KuduzRiskliTemasVeriSeti.RiskliTemasTarihi = event;
            }
        }
    }

    public onSKRSHayvaninMevcutDurumuChanged(event): void {
        if (event != null) {
            if (this._KuduzRiskliTemasVeriSeti != null && this._KuduzRiskliTemasVeriSeti.SKRSHayvaninMevcutDurumu != event) {
                this._KuduzRiskliTemasVeriSeti.SKRSHayvaninMevcutDurumu = event;
            }
        }
    }

    public onSKRSHayvaninSahiplikDurumuChanged(event): void {
        if (event != null) {
            if (this._KuduzRiskliTemasVeriSeti != null && this._KuduzRiskliTemasVeriSeti.SKRSHayvaninSahiplikDurumu != event) {
                this._KuduzRiskliTemasVeriSeti.SKRSHayvaninSahiplikDurumu = event;
            }
        }
    }

    public onSKRSImmunglobulinTuruChanged(event): void {
        if (event != null) {
            if (this._KuduzRiskliTemasVeriSeti != null && this._KuduzRiskliTemasVeriSeti.SKRSImmunglobulinTuru != event) {
                this._KuduzRiskliTemasVeriSeti.SKRSImmunglobulinTuru = event;
            }
        }
    }

    public onSKRSKategorizasyonChanged(event): void {
        if (event != null) {
            if (this._KuduzRiskliTemasVeriSeti != null && this._KuduzRiskliTemasVeriSeti.SKRSKategorizasyon != event) {
                this._KuduzRiskliTemasVeriSeti.SKRSKategorizasyon = event;
            }
        }
    }

    public onSKRSKuduzRiskliTemasDegDurumuChanged(event): void {
        if (event != null) {
            if (this._KuduzRiskliTemasVeriSeti != null && this._KuduzRiskliTemasVeriSeti.SKRSKuduzRiskliTemasDegDurumu != event) {
                this._KuduzRiskliTemasVeriSeti.SKRSKuduzRiskliTemasDegDurumu = event;
            }
        }
    }

    public onSKRSRiskliTemasSebepOlHayvanChanged(event): void {
        if (event != null) {
            if (this._KuduzRiskliTemasVeriSeti != null && this._KuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan != event) {
                this._KuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Kilo, "Text", this.__ttObject, "Kilo");
        redirectProperty(this.ImmunglobulinMiktari, "Text", this.__ttObject, "ImmunglobulinMiktari");
        redirectProperty(this.RiskliTemasTarihi, "Value", this.__ttObject, "RiskliTemasTarihi");
    }

    public initFormControls(): void {
        this.labelSKRSRiskliTemasSebepOlHayvan = new TTVisual.TTLabel();
        this.labelSKRSRiskliTemasSebepOlHayvan.Text = "Temasa Sebep Olan Hayvan";
        this.labelSKRSRiskliTemasSebepOlHayvan.Name = "labelSKRSRiskliTemasSebepOlHayvan";
        this.labelSKRSRiskliTemasSebepOlHayvan.TabIndex = 21;

        this.SKRSRiskliTemasSebepOlHayvan = new TTVisual.TTObjectListBox();
        this.SKRSRiskliTemasSebepOlHayvan.ListDefName = "SKRSRiskliTemasaSebepOlanHayvanList";
        this.SKRSRiskliTemasSebepOlHayvan.Name = "SKRSRiskliTemasSebepOlHayvan";
        this.SKRSRiskliTemasSebepOlHayvan.TabIndex = 20;

        this.labelSKRSKuduzRiskliTemasDegDurumu = new TTVisual.TTLabel();
        this.labelSKRSKuduzRiskliTemasDegDurumu.Text = "Riskli Temas Değerlendirme Durumu";
        this.labelSKRSKuduzRiskliTemasDegDurumu.Name = "labelSKRSKuduzRiskliTemasDegDurumu";
        this.labelSKRSKuduzRiskliTemasDegDurumu.TabIndex = 19;

        this.SKRSKuduzRiskliTemasDegDurumu = new TTVisual.TTObjectListBox();
        this.SKRSKuduzRiskliTemasDegDurumu.ListDefName = "SKRSKuduzRiskliTemasDegerlendirmeDurumuList";
        this.SKRSKuduzRiskliTemasDegDurumu.Name = "SKRSKuduzRiskliTemasDegDurumu";
        this.SKRSKuduzRiskliTemasDegDurumu.TabIndex = 18;

        this.labelSKRSKategorizasyon = new TTVisual.TTLabel();
        this.labelSKRSKategorizasyon.Text = i18n("M17352", "Kategorizasyon");
        this.labelSKRSKategorizasyon.Name = "labelSKRSKategorizasyon";
        this.labelSKRSKategorizasyon.TabIndex = 17;

        this.SKRSKategorizasyon = new TTVisual.TTObjectListBox();
        this.SKRSKategorizasyon.ListDefName = "SKRSKategorizasyonList";
        this.SKRSKategorizasyon.Name = "SKRSKategorizasyon";
        this.SKRSKategorizasyon.TabIndex = 16;

        this.labelSKRSImmunglobulinTuru = new TTVisual.TTLabel();
        this.labelSKRSImmunglobulinTuru.Text = "Immuniglobulin Türü";
        this.labelSKRSImmunglobulinTuru.Name = "labelSKRSImmunglobulinTuru";
        this.labelSKRSImmunglobulinTuru.TabIndex = 15;

        this.SKRSImmunglobulinTuru = new TTVisual.TTObjectListBox();
        this.SKRSImmunglobulinTuru.ListDefName = "SKRSImmunglobulinTuruList";
        this.SKRSImmunglobulinTuru.Name = "SKRSImmunglobulinTuru";
        this.SKRSImmunglobulinTuru.TabIndex = 14;

        this.labelSKRSHayvaninSahiplikDurumu = new TTVisual.TTLabel();
        this.labelSKRSHayvaninSahiplikDurumu.Text = i18n("M15574", "Hayvanın Sahiplik Durumu");
        this.labelSKRSHayvaninSahiplikDurumu.Name = "labelSKRSHayvaninSahiplikDurumu";
        this.labelSKRSHayvaninSahiplikDurumu.TabIndex = 13;

        this.SKRSHayvaninSahiplikDurumu = new TTVisual.TTObjectListBox();
        this.SKRSHayvaninSahiplikDurumu.ListDefName = "SKRSHayvaninSahiplikDurumuList";
        this.SKRSHayvaninSahiplikDurumu.Name = "SKRSHayvaninSahiplikDurumu";
        this.SKRSHayvaninSahiplikDurumu.TabIndex = 12;

        this.labelSKRSHayvaninMevcutDurumu = new TTVisual.TTLabel();
        this.labelSKRSHayvaninMevcutDurumu.Text = i18n("M15573", "Hayvanın Mevcut Durumu");
        this.labelSKRSHayvaninMevcutDurumu.Name = "labelSKRSHayvaninMevcutDurumu";
        this.labelSKRSHayvaninMevcutDurumu.TabIndex = 11;

        this.SKRSHayvaninMevcutDurumu = new TTVisual.TTObjectListBox();
        this.SKRSHayvaninMevcutDurumu.ListDefName = "SKRSHayvaninMevcutDurumuList";
        this.SKRSHayvaninMevcutDurumu.Name = "SKRSHayvaninMevcutDurumu";
        this.SKRSHayvaninMevcutDurumu.TabIndex = 10;

        /*this.KuduzRiskliTemasTelefon = new TTVisual.TTGrid();
        this.KuduzRiskliTemasTelefon.Name = "KuduzRiskliTemasTelefon";
        this.KuduzRiskliTemasTelefon.TabIndex = 9;*/

        this.KuduzRiskliTemasTelefon = new TTVisual.TTGrid();
        this.KuduzRiskliTemasTelefon.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.KuduzRiskliTemasTelefon.Name = "KuduzRiskliTemasTelefon";
        this.KuduzRiskliTemasTelefon.TabIndex = 0;
        this.KuduzRiskliTemasTelefon.Height = "150px";
        this.KuduzRiskliTemasTelefon.ShowFilterCombo = true;
        this.KuduzRiskliTemasTelefon.FilterColumnName = "SKRSTelefonTipiKuduzRiskliTemasTelefon";
        this.KuduzRiskliTemasTelefon.FilterLabel = i18n("M23142", "Telefon Tipi");
        this.KuduzRiskliTemasTelefon.Filter = { ListDefName: "SKRSTelefonTipiList" };
        this.KuduzRiskliTemasTelefon.AllowUserToAddRows = false;
        this.KuduzRiskliTemasTelefon.DeleteButtonWidth = "5%";
        this.KuduzRiskliTemasTelefon.AllowUserToDeleteRows = true;
        this.KuduzRiskliTemasTelefon.IsFilterLabelSingleLine = false;

        this.SKRSTelefonTipiKuduzRiskliTemasTelefon = new TTVisual.TTListBoxColumn();
        this.SKRSTelefonTipiKuduzRiskliTemasTelefon.ListDefName = "SKRSTelefonTipiList";
        this.SKRSTelefonTipiKuduzRiskliTemasTelefon.DataMember = "SKRSTelefonTipi";
        this.SKRSTelefonTipiKuduzRiskliTemasTelefon.DisplayIndex = 0;
        this.SKRSTelefonTipiKuduzRiskliTemasTelefon.HeaderText = i18n("M23142", "Telefon Tipi");
        this.SKRSTelefonTipiKuduzRiskliTemasTelefon.Name = "SKRSTelefonTipiKuduzRiskliTemasTelefon";
        this.SKRSTelefonTipiKuduzRiskliTemasTelefon.Width = 420;

        this.TelefonNumarasiKuduzRiskliTemasTelefon = new TTVisual.TTTextBoxColumn();
        this.TelefonNumarasiKuduzRiskliTemasTelefon.DataMember = "TelefonNumarasi";
        this.TelefonNumarasiKuduzRiskliTemasTelefon.DisplayIndex = 1;
        this.TelefonNumarasiKuduzRiskliTemasTelefon.HeaderText = i18n("M23138", "Telefon Numarası");
        this.TelefonNumarasiKuduzRiskliTemasTelefon.Name = "TelefonNumarasiKuduzRiskliTemasTelefon";
        this.TelefonNumarasiKuduzRiskliTemasTelefon.Width = 80;

        /*this.KuduzRiskliTemasRiskTemTip = new TTVisual.TTGrid();
        this.KuduzRiskliTemasRiskTemTip.Name = "KuduzRiskliTemasRiskTemTip";
        this.KuduzRiskliTemasRiskTemTip.TabIndex = 8;*/

        this.KuduzRiskliTemasRiskTemTip = new TTVisual.TTGrid();
        this.KuduzRiskliTemasRiskTemTip.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.KuduzRiskliTemasRiskTemTip.Name = "KuduzRiskliTemasRiskTemTip";
        this.KuduzRiskliTemasRiskTemTip.TabIndex = 0;
        this.KuduzRiskliTemasRiskTemTip.Height = "150px";
        this.KuduzRiskliTemasRiskTemTip.ShowFilterCombo = true;
        this.KuduzRiskliTemasRiskTemTip.FilterColumnName = "SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip";
        this.KuduzRiskliTemasRiskTemTip.FilterLabel = i18n("M21048", "Temas Tipi");
        this.KuduzRiskliTemasRiskTemTip.Filter = { ListDefName: "SKRSRiskliTemasTipiList" };
        this.KuduzRiskliTemasRiskTemTip.AllowUserToAddRows = false;
        this.KuduzRiskliTemasRiskTemTip.DeleteButtonWidth = "5%";
        this.KuduzRiskliTemasRiskTemTip.AllowUserToDeleteRows = true;
        this.KuduzRiskliTemasRiskTemTip.IsFilterLabelSingleLine = false;

        this.SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip = new TTVisual.TTListBoxColumn();
        this.SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip.ListDefName = "SKRSRiskliTemasTipiList";
        this.SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip.DataMember = "SKRSRiskliTemasTipi";
        this.SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip.DisplayIndex = 0;
        this.SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip.HeaderText = i18n("M21048", "Temas Tipi");
        this.SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip.Name = "SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip";
        this.SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip.Width = 300;

        /*this.KuduzRiskliTemasPlanProfBi = new TTVisual.TTGrid();
        this.KuduzRiskliTemasPlanProfBi.Name = "KuduzRiskliTemasPlanProfBi";
        this.KuduzRiskliTemasPlanProfBi.TabIndex = 7;*/

        this.KuduzRiskliTemasPlanProfBi = new TTVisual.TTGrid();
        this.KuduzRiskliTemasPlanProfBi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.KuduzRiskliTemasPlanProfBi.Name = "KuduzRiskliTemasPlanProfBi";
        this.KuduzRiskliTemasPlanProfBi.TabIndex = 0;
        this.KuduzRiskliTemasPlanProfBi.Height = "150px";
        this.KuduzRiskliTemasPlanProfBi.ShowFilterCombo = true;
        this.KuduzRiskliTemasPlanProfBi.FilterColumnName = "SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi";
        this.KuduzRiskliTemasPlanProfBi.FilterLabel = i18n("M17605", "Planlanan Kuduz Profilaksisi");
        this.KuduzRiskliTemasPlanProfBi.Filter = { ListDefName: "SKRSKisiyePlanlananKuduzProfilaksisiList" };
        this.KuduzRiskliTemasPlanProfBi.AllowUserToAddRows = false;
        this.KuduzRiskliTemasPlanProfBi.DeleteButtonWidth = "5%";
        this.KuduzRiskliTemasPlanProfBi.AllowUserToDeleteRows = true;
        this.KuduzRiskliTemasPlanProfBi.IsFilterLabelSingleLine = false;

        this.SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi = new TTVisual.TTListBoxColumn();
        this.SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi.ListDefName = "SKRSKisiyePlanlananKuduzProfilaksisiList";
        this.SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi.DataMember = "SKRSKisiyePlanKuduzProfilaksi";
        this.SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi.DisplayIndex = 0;
        this.SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi.HeaderText = i18n("M17605", "Planlanan Kuduz Profilaksisi");
        this.SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi.Name = "SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi";
        this.SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi.Width = 300;

        /*this.KuduzRiskliTemasAdres = new TTVisual.TTGrid();
        this.KuduzRiskliTemasAdres.Name = "KuduzRiskliTemasAdres";
        this.KuduzRiskliTemasAdres.TabIndex = 6;*/

        this.KuduzRiskliTemasAdres = new TTVisual.TTGrid();
        this.KuduzRiskliTemasAdres.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.KuduzRiskliTemasAdres.Name = "KuduzRiskliTemasAdres";
        this.KuduzRiskliTemasAdres.TabIndex = 0;
        this.KuduzRiskliTemasAdres.Height = "150px";
        this.KuduzRiskliTemasAdres.ShowFilterCombo = true;
        this.KuduzRiskliTemasAdres.FilterColumnName = "SKRSAdresTipiKuduzRiskliTemasAdres";
        this.KuduzRiskliTemasAdres.FilterLabel = i18n("M10552", "Adres Tipi");
        this.KuduzRiskliTemasAdres.Filter = { ListDefName: "SKRSAdresTipiList" };
        this.KuduzRiskliTemasAdres.AllowUserToAddRows = false;
        this.KuduzRiskliTemasAdres.DeleteButtonWidth = "5%";
        this.KuduzRiskliTemasAdres.AllowUserToDeleteRows = true;
        this.KuduzRiskliTemasAdres.IsFilterLabelSingleLine = false;

        this.SKRSAdresTipiKuduzRiskliTemasAdres = new TTVisual.TTListBoxColumn();
        this.SKRSAdresTipiKuduzRiskliTemasAdres.ListDefName = "SKRSAdresTipiList";
        this.SKRSAdresTipiKuduzRiskliTemasAdres.DataMember = "SKRSAdresTipi";
        this.SKRSAdresTipiKuduzRiskliTemasAdres.DisplayIndex = 0;
        this.SKRSAdresTipiKuduzRiskliTemasAdres.HeaderText = i18n("M10552", "Adres Tipi");
        this.SKRSAdresTipiKuduzRiskliTemasAdres.Name = "SKRSAdresTipiKuduzRiskliTemasAdres";
        this.SKRSAdresTipiKuduzRiskliTemasAdres.Width = 300;

        this.SKRSBucakKodlariKuduzRiskliTemasAdres = new TTVisual.TTListBoxColumn();
        this.SKRSBucakKodlariKuduzRiskliTemasAdres.ListDefName = "SKRSBucakKodlariList";
        this.SKRSBucakKodlariKuduzRiskliTemasAdres.DataMember = "SKRSBucakKodlari";
        this.SKRSBucakKodlariKuduzRiskliTemasAdres.DisplayIndex = 1;
        this.SKRSBucakKodlariKuduzRiskliTemasAdres.HeaderText = i18n("M12097", "Bucak");
        this.SKRSBucakKodlariKuduzRiskliTemasAdres.Name = "SKRSBucakKodlariKuduzRiskliTemasAdres";
        this.SKRSBucakKodlariKuduzRiskliTemasAdres.Width = 300;

        this.SKRSCSBMTipiKuduzRiskliTemasAdres = new TTVisual.TTListBoxColumn();
        this.SKRSCSBMTipiKuduzRiskliTemasAdres.ListDefName = "SKRSCSBMTipiList";
        this.SKRSCSBMTipiKuduzRiskliTemasAdres.DataMember = "SKRSCSBMTipi";
        this.SKRSCSBMTipiKuduzRiskliTemasAdres.DisplayIndex = 2;
        this.SKRSCSBMTipiKuduzRiskliTemasAdres.HeaderText = i18n("M12294", "CSBM Tipi");
        this.SKRSCSBMTipiKuduzRiskliTemasAdres.Name = "SKRSCSBMTipiKuduzRiskliTemasAdres";
        this.SKRSCSBMTipiKuduzRiskliTemasAdres.Width = 300;

        this.SKRSIlceKodlariKuduzRiskliTemasAdres = new TTVisual.TTListBoxColumn();
        this.SKRSIlceKodlariKuduzRiskliTemasAdres.ListDefName = "SKRSIlceKodlariList";
        this.SKRSIlceKodlariKuduzRiskliTemasAdres.DataMember = "SKRSIlceKodlari";
        this.SKRSIlceKodlariKuduzRiskliTemasAdres.DisplayIndex = 3;
        this.SKRSIlceKodlariKuduzRiskliTemasAdres.HeaderText = i18n("M16396", "İlçe");
        this.SKRSIlceKodlariKuduzRiskliTemasAdres.Name = "SKRSIlceKodlariKuduzRiskliTemasAdres";
        this.SKRSIlceKodlariKuduzRiskliTemasAdres.Width = 300;

        this.SKRSILKodlariKuduzRiskliTemasAdres = new TTVisual.TTListBoxColumn();
        this.SKRSILKodlariKuduzRiskliTemasAdres.ListDefName = "SKRSILKodlariList";
        this.SKRSILKodlariKuduzRiskliTemasAdres.DataMember = "SKRSILKodlari";
        this.SKRSILKodlariKuduzRiskliTemasAdres.DisplayIndex = 4;
        this.SKRSILKodlariKuduzRiskliTemasAdres.HeaderText = i18n("M16269", "İl");
        this.SKRSILKodlariKuduzRiskliTemasAdres.Name = "SKRSILKodlariKuduzRiskliTemasAdres";
        this.SKRSILKodlariKuduzRiskliTemasAdres.Width = 300;

        this.SKRSKoyKodlariKuduzRiskliTemasAdres = new TTVisual.TTListBoxColumn();
        this.SKRSKoyKodlariKuduzRiskliTemasAdres.ListDefName = "SKRSKoyKodlariList";
        this.SKRSKoyKodlariKuduzRiskliTemasAdres.DataMember = "SKRSKoyKodlari";
        this.SKRSKoyKodlariKuduzRiskliTemasAdres.DisplayIndex = 5;
        this.SKRSKoyKodlariKuduzRiskliTemasAdres.HeaderText = i18n("M17848", "Köy");
        this.SKRSKoyKodlariKuduzRiskliTemasAdres.Name = "SKRSKoyKodlariKuduzRiskliTemasAdres";
        this.SKRSKoyKodlariKuduzRiskliTemasAdres.Width = 300;

        this.SKRSMahalleKodlariKuduzRiskliTemasAdres = new TTVisual.TTListBoxColumn();
        this.SKRSMahalleKodlariKuduzRiskliTemasAdres.ListDefName = "SKRSMahalleKodlariList";
        this.SKRSMahalleKodlariKuduzRiskliTemasAdres.DataMember = "SKRSMahalleKodlari";
        this.SKRSMahalleKodlariKuduzRiskliTemasAdres.DisplayIndex = 6;
        this.SKRSMahalleKodlariKuduzRiskliTemasAdres.HeaderText = i18n("M18436", "Mahalle");
        this.SKRSMahalleKodlariKuduzRiskliTemasAdres.Name = "SKRSMahalleKodlariKuduzRiskliTemasAdres";
        this.SKRSMahalleKodlariKuduzRiskliTemasAdres.Width = 300;

        this.DisKapiKuduzRiskliTemasAdres = new TTVisual.TTTextBoxColumn();
        this.DisKapiKuduzRiskliTemasAdres.DataMember = "DisKapi";
        this.DisKapiKuduzRiskliTemasAdres.DisplayIndex = 7;
        this.DisKapiKuduzRiskliTemasAdres.HeaderText = "Dış Kapı";
        this.DisKapiKuduzRiskliTemasAdres.Name = "DisKapiKuduzRiskliTemasAdres";
        this.DisKapiKuduzRiskliTemasAdres.Width = 80;

        this.IcKapiKuduzRiskliTemasAdres = new TTVisual.TTTextBoxColumn();
        this.IcKapiKuduzRiskliTemasAdres.DataMember = "IcKapi";
        this.IcKapiKuduzRiskliTemasAdres.DisplayIndex = 8;
        this.IcKapiKuduzRiskliTemasAdres.HeaderText = "İç Kapı";
        this.IcKapiKuduzRiskliTemasAdres.Name = "IcKapiKuduzRiskliTemasAdres";
        this.IcKapiKuduzRiskliTemasAdres.Width = 80;

        this.labelRiskliTemasTarihi = new TTVisual.TTLabel();
        this.labelRiskliTemasTarihi.Text = "Riskli Temas Tarihi";
        this.labelRiskliTemasTarihi.Name = "labelRiskliTemasTarihi";
        this.labelRiskliTemasTarihi.TabIndex = 5;

        this.RiskliTemasTarihi = new TTVisual.TTDateTimePicker();
        this.RiskliTemasTarihi.Format = DateTimePickerFormat.Long;
        this.RiskliTemasTarihi.Name = "RiskliTemasTarihi";
        this.RiskliTemasTarihi.TabIndex = 4;

        this.labelImmunglobulinMiktari = new TTVisual.TTLabel();
        this.labelImmunglobulinMiktari.Text = "Immunglobulin Miktarı";
        this.labelImmunglobulinMiktari.Name = "labelImmunglobulinMiktari";
        this.labelImmunglobulinMiktari.TabIndex = 3;

        this.ImmunglobulinMiktari = new TTVisual.TTTextBox();
        this.ImmunglobulinMiktari.Name = "ImmunglobulinMiktari";
        this.ImmunglobulinMiktari.TabIndex = 2;

        this.labelKilo = new TTVisual.TTLabel();
        this.labelKilo.Text = "Hasta Kilosu (Gram)";
        this.labelKilo.Name = "labelKilo";
        this.labelKilo.TabIndex = 1;

        this.Kilo = new TTVisual.TTTextBox();
        this.Kilo.Name = "Kilo";
        this.Kilo.TabIndex = 0;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = "Adres Bilgisi";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 1;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M21048", "Riskli Temas Tipi");
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 1;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = "Planlanan Kuduz Profilaksisi";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 1;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = "Telefon Bilgisi";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 1;

        this.KuduzRiskliTemasTelefonColumns = [this.SKRSTelefonTipiKuduzRiskliTemasTelefon, this.TelefonNumarasiKuduzRiskliTemasTelefon];
        this.KuduzRiskliTemasRiskTemTipColumns = [this.SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip];
        this.KuduzRiskliTemasPlanProfBiColumns = [this.SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi];
        this.KuduzRiskliTemasAdresColumns = [this.SKRSAdresTipiKuduzRiskliTemasAdres, this.SKRSBucakKodlariKuduzRiskliTemasAdres, this.SKRSCSBMTipiKuduzRiskliTemasAdres, this.SKRSIlceKodlariKuduzRiskliTemasAdres, this.SKRSILKodlariKuduzRiskliTemasAdres, this.SKRSKoyKodlariKuduzRiskliTemasAdres, this.SKRSMahalleKodlariKuduzRiskliTemasAdres, this.DisKapiKuduzRiskliTemasAdres, this.IcKapiKuduzRiskliTemasAdres];
        this.Controls = [this.labelSKRSRiskliTemasSebepOlHayvan, this.SKRSRiskliTemasSebepOlHayvan, this.labelSKRSKuduzRiskliTemasDegDurumu, this.SKRSKuduzRiskliTemasDegDurumu, this.labelSKRSKategorizasyon, this.SKRSKategorizasyon, this.labelSKRSImmunglobulinTuru, this.SKRSImmunglobulinTuru, this.labelSKRSHayvaninSahiplikDurumu, this.SKRSHayvaninSahiplikDurumu, this.labelSKRSHayvaninMevcutDurumu, this.SKRSHayvaninMevcutDurumu, this.KuduzRiskliTemasTelefon, this.SKRSTelefonTipiKuduzRiskliTemasTelefon, this.TelefonNumarasiKuduzRiskliTemasTelefon, this.KuduzRiskliTemasRiskTemTip, this.SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip, this.KuduzRiskliTemasPlanProfBi, this.SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi, this.KuduzRiskliTemasAdres, this.SKRSAdresTipiKuduzRiskliTemasAdres, this.SKRSBucakKodlariKuduzRiskliTemasAdres, this.SKRSCSBMTipiKuduzRiskliTemasAdres, this.SKRSIlceKodlariKuduzRiskliTemasAdres, this.SKRSILKodlariKuduzRiskliTemasAdres, this.SKRSKoyKodlariKuduzRiskliTemasAdres, this.SKRSMahalleKodlariKuduzRiskliTemasAdres, this.DisKapiKuduzRiskliTemasAdres, this.IcKapiKuduzRiskliTemasAdres, this.labelRiskliTemasTarihi, this.RiskliTemasTarihi, this.labelImmunglobulinMiktari, this.ImmunglobulinMiktari, this.labelKilo, this.Kilo, this.ttlabel10, this.ttlabel11, this.ttlabel12, this.ttlabel13];

    }


}
