//$4FD69016
import { Component, OnInit, NgZone } from '@angular/core';
import { EvdeSaglikIlkIzlemFormViewModel } from './EvdeSaglikIlkIzlemFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EvdeSaglikIlkIzlemVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { KullandigiYardimciAraclar } from 'NebulaClient/Model/AtlasClientModel';
import { PsikolojikDurum } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAgri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAydinlatma } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBakimveDestekIhtiyaci } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBasiDegerlendirmesi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBasvuruTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBeslenme } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBirSonrakiHizmetIhtiyaci } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSEvHijyeni } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGuvenlik } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICD } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIsinma } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKisiselBakim } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKisiselHijyen } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKonutTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKullanilanHelaTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYatagaBagimlilik } from 'NebulaClient/Model/AtlasClientModel';
import { VerilenEgitimler } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'EvdeSaglikIlkIzlemForm',
    templateUrl: './EvdeSaglikIlkIzlemForm.html',
    providers: [MessageService]
})
export class EvdeSaglikIlkIzlemForm extends TTVisual.TTForm implements OnInit {
    KullandigiYardimciAraclar: TTVisual.ITTGrid;
    labelSKRSAgri: TTVisual.ITTLabel;
    labelSKRSAydinlatma: TTVisual.ITTLabel;
    labelSKRSBakimveDestekIhtiyaci: TTVisual.ITTLabel;
    labelSKRSBasiDegerlendirmesi: TTVisual.ITTLabel;
    labelSKRSBasvuruTuru: TTVisual.ITTLabel;
    labelSKRSBeslenme: TTVisual.ITTLabel;
    labelSKRSBirSonrakiHizmetIhtiyaci: TTVisual.ITTLabel;
    labelSKRSEvHijyeni: TTVisual.ITTLabel;
    labelSKRSGuvenlik: TTVisual.ITTLabel;
    labelSKRSICD: TTVisual.ITTLabel;
    labelSKRSIsinma: TTVisual.ITTLabel;
    labelSKRSKisiselBakim: TTVisual.ITTLabel;
    labelSKRSKisiselHijyen: TTVisual.ITTLabel;
    labelSKRSKonutTipi: TTVisual.ITTLabel;
    labelSKRSKullanilanHelaTipi: TTVisual.ITTLabel;
    labelSKRSYatagaBagimlilik: TTVisual.ITTLabel;
    PsikolojikDurum: TTVisual.ITTGrid;
    SKRSAgri: TTVisual.ITTObjectListBox;
    SKRSAydinlatma: TTVisual.ITTObjectListBox;
    SKRSBakimveDestekIhtiyaci: TTVisual.ITTObjectListBox;
    SKRSBasiDegerlendirmesi: TTVisual.ITTObjectListBox;
    SKRSBasvuruTuru: TTVisual.ITTObjectListBox;
    SKRSBeslenme: TTVisual.ITTObjectListBox;
    SKRSBirSonrakiHizmetIhtiyaci: TTVisual.ITTObjectListBox;
    SKRSEvHijyeni: TTVisual.ITTObjectListBox;
    SKRSGuvenlik: TTVisual.ITTObjectListBox;
    SKRSICD: TTVisual.ITTObjectListBox;
    SKRSIsinma: TTVisual.ITTObjectListBox;
    SKRSKisiselBakim: TTVisual.ITTObjectListBox;
    SKRSKisiselHijyen: TTVisual.ITTObjectListBox;
    SKRSKonutTipi: TTVisual.ITTObjectListBox;
    SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar: TTVisual.ITTListBoxColumn;
    SKRSKullanilanHelaTipi: TTVisual.ITTObjectListBox;
    SKRSPsikolojikDurumPsikolojikDurum: TTVisual.ITTListBoxColumn;
    SKRSVerilenEgitimlerVerilenEgitimler: TTVisual.ITTListBoxColumn;
    SKRSYatagaBagimlilik: TTVisual.ITTObjectListBox;
    VerilenEgitimler: TTVisual.ITTGrid;
    RouteData2: any;
    public KullandigiYardimciAraclarColumns = [];
    public PsikolojikDurumColumns = [];
    public VerilenEgitimlerColumns = [];
    public evdeSaglikIlkIzlemFormViewModel: EvdeSaglikIlkIzlemFormViewModel = new EvdeSaglikIlkIzlemFormViewModel();
    public get _EvdeSaglikIlkIzlemVeriSeti(): EvdeSaglikIlkIzlemVeriSeti {
        return this._TTObject as EvdeSaglikIlkIzlemVeriSeti;
    }
    private EvdeSaglikIlkIzlemForm_DocumentUrl: string = '/api/EvdeSaglikIlkIzlemVeriSetiService/EvdeSaglikIlkIzlemForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('EVDESAGLIKILKIZLEMVERISETI', 'EvdeSaglikIlkIzlemForm');
        this._DocumentServiceUrl = this.EvdeSaglikIlkIzlemForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EvdeSaglikIlkIzlemVeriSeti();
        this.evdeSaglikIlkIzlemFormViewModel = new EvdeSaglikIlkIzlemFormViewModel();
        this._ViewModel = this.evdeSaglikIlkIzlemFormViewModel;
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti = this._TTObject as EvdeSaglikIlkIzlemVeriSeti;
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.VerilenEgitimler = new Array<VerilenEgitimler>();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.PsikolojikDurum = new Array<PsikolojikDurum>();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.KullandigiYardimciAraclar = new Array<KullandigiYardimciAraclar>();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSYatagaBagimlilik = new SKRSYatagaBagimlilik();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSKullanilanHelaTipi = new SKRSKullanilanHelaTipi();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSKonutTipi = new SKRSKonutTipi();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSKisiselHijyen = new SKRSKisiselHijyen();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSKisiselBakim = new SKRSKisiselBakim();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSIsinma = new SKRSIsinma();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSGuvenlik = new SKRSGuvenlik();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSEvHijyeni = new SKRSEvHijyeni();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSICD = new SKRSICD();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBirSonrakiHizmetIhtiyaci = new SKRSBirSonrakiHizmetIhtiyaci();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBeslenme = new SKRSBeslenme();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBasvuruTuru = new SKRSBasvuruTuru();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBasiDegerlendirmesi = new SKRSBasiDegerlendirmesi();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBakimveDestekIhtiyaci = new SKRSBakimveDestekIhtiyaci();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSAydinlatma = new SKRSAydinlatma();
        this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSAgri = new SKRSAgri();
    }

    protected loadViewModel() {
        let that = this;

        that.evdeSaglikIlkIzlemFormViewModel = this._ViewModel as EvdeSaglikIlkIzlemFormViewModel;
        that._TTObject = this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti;
        if (this.evdeSaglikIlkIzlemFormViewModel == null)
            this.evdeSaglikIlkIzlemFormViewModel = new EvdeSaglikIlkIzlemFormViewModel();
        if (this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti == null)
            this.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti = new EvdeSaglikIlkIzlemVeriSeti();
        that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.VerilenEgitimler = that.evdeSaglikIlkIzlemFormViewModel.VerilenEgitimlerGridList;
        for (let detailItem of that.evdeSaglikIlkIzlemFormViewModel.VerilenEgitimlerGridList) {
            let sKRSVerilenEgitimlerObjectID = detailItem["SKRSVerilenEgitimler"];
            if (sKRSVerilenEgitimlerObjectID != null && (typeof sKRSVerilenEgitimlerObjectID === 'string')) {
                let sKRSVerilenEgitimler = that.evdeSaglikIlkIzlemFormViewModel.SKRSVerilenEgitimlers.find(o => o.ObjectID.toString() === sKRSVerilenEgitimlerObjectID.toString());
                 if (sKRSVerilenEgitimler) {
                    detailItem.SKRSVerilenEgitimler = sKRSVerilenEgitimler;
                }
            }
        }
        that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.PsikolojikDurum = that.evdeSaglikIlkIzlemFormViewModel.PsikolojikDurumGridList;
        for (let detailItem of that.evdeSaglikIlkIzlemFormViewModel.PsikolojikDurumGridList) {
            let sKRSPsikolojikDurumObjectID = detailItem["SKRSPsikolojikDurum"];
            if (sKRSPsikolojikDurumObjectID != null && (typeof sKRSPsikolojikDurumObjectID === 'string')) {
                let sKRSPsikolojikDurum = that.evdeSaglikIlkIzlemFormViewModel.SKRSPsikolojikDurumDegerlendirmesis.find(o => o.ObjectID.toString() === sKRSPsikolojikDurumObjectID.toString());
                 if (sKRSPsikolojikDurum) {
                    detailItem.SKRSPsikolojikDurum = sKRSPsikolojikDurum;
                }
            }
        }
        that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.KullandigiYardimciAraclar = that.evdeSaglikIlkIzlemFormViewModel.KullandigiYardimciAraclarGridList;
        for (let detailItem of that.evdeSaglikIlkIzlemFormViewModel.KullandigiYardimciAraclarGridList) {
            let sKRSKullandigiYardimciAraclarObjectID = detailItem["SKRSKullandigiYardimciAraclar"];
            if (sKRSKullandigiYardimciAraclarObjectID != null && (typeof sKRSKullandigiYardimciAraclarObjectID === 'string')) {
                let sKRSKullandigiYardimciAraclar = that.evdeSaglikIlkIzlemFormViewModel.SKRSKullandigiYardimciAraclars.find(o => o.ObjectID.toString() === sKRSKullandigiYardimciAraclarObjectID.toString());
                 if (sKRSKullandigiYardimciAraclar) {
                    detailItem.SKRSKullandigiYardimciAraclar = sKRSKullandigiYardimciAraclar;
                }
            }
        }
        let sKRSYatagaBagimlilikObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSYatagaBagimlilik"];
        if (sKRSYatagaBagimlilikObjectID != null && (typeof sKRSYatagaBagimlilikObjectID === 'string')) {
            let sKRSYatagaBagimlilik = that.evdeSaglikIlkIzlemFormViewModel.SKRSYatagaBagimliliks.find(o => o.ObjectID.toString() === sKRSYatagaBagimlilikObjectID.toString());
             if (sKRSYatagaBagimlilik) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSYatagaBagimlilik = sKRSYatagaBagimlilik;
            }
        }
        let sKRSKullanilanHelaTipiObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSKullanilanHelaTipi"];
        if (sKRSKullanilanHelaTipiObjectID != null && (typeof sKRSKullanilanHelaTipiObjectID === 'string')) {
            let sKRSKullanilanHelaTipi = that.evdeSaglikIlkIzlemFormViewModel.SKRSKullanilanHelaTipis.find(o => o.ObjectID.toString() === sKRSKullanilanHelaTipiObjectID.toString());
             if (sKRSKullanilanHelaTipi) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSKullanilanHelaTipi = sKRSKullanilanHelaTipi;
            }
        }
        let sKRSKonutTipiObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSKonutTipi"];
        if (sKRSKonutTipiObjectID != null && (typeof sKRSKonutTipiObjectID === 'string')) {
            let sKRSKonutTipi = that.evdeSaglikIlkIzlemFormViewModel.SKRSKonutTipis.find(o => o.ObjectID.toString() === sKRSKonutTipiObjectID.toString());
             if (sKRSKonutTipi) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSKonutTipi = sKRSKonutTipi;
            }
        }
        let sKRSKisiselHijyenObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSKisiselHijyen"];
        if (sKRSKisiselHijyenObjectID != null && (typeof sKRSKisiselHijyenObjectID === 'string')) {
            let sKRSKisiselHijyen = that.evdeSaglikIlkIzlemFormViewModel.SKRSKisiselHijyens.find(o => o.ObjectID.toString() === sKRSKisiselHijyenObjectID.toString());
             if (sKRSKisiselHijyen) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSKisiselHijyen = sKRSKisiselHijyen;
            }
        }
        let sKRSKisiselBakimObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSKisiselBakim"];
        if (sKRSKisiselBakimObjectID != null && (typeof sKRSKisiselBakimObjectID === 'string')) {
            let sKRSKisiselBakim = that.evdeSaglikIlkIzlemFormViewModel.SKRSKisiselBakims.find(o => o.ObjectID.toString() === sKRSKisiselBakimObjectID.toString());
             if (sKRSKisiselBakim) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSKisiselBakim = sKRSKisiselBakim;
            }
        }
        let sKRSIsinmaObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSIsinma"];
        if (sKRSIsinmaObjectID != null && (typeof sKRSIsinmaObjectID === 'string')) {
            let sKRSIsinma = that.evdeSaglikIlkIzlemFormViewModel.SKRSIsinmas.find(o => o.ObjectID.toString() === sKRSIsinmaObjectID.toString());
             if (sKRSIsinma) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSIsinma = sKRSIsinma;
            }
        }
        let sKRSGuvenlikObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSGuvenlik"];
        if (sKRSGuvenlikObjectID != null && (typeof sKRSGuvenlikObjectID === 'string')) {
            let sKRSGuvenlik = that.evdeSaglikIlkIzlemFormViewModel.SKRSGuvenliks.find(o => o.ObjectID.toString() === sKRSGuvenlikObjectID.toString());
             if (sKRSGuvenlik) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSGuvenlik = sKRSGuvenlik;
            }
        }
        let sKRSEvHijyeniObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSEvHijyeni"];
        if (sKRSEvHijyeniObjectID != null && (typeof sKRSEvHijyeniObjectID === 'string')) {
            let sKRSEvHijyeni = that.evdeSaglikIlkIzlemFormViewModel.SKRSEvHijyenis.find(o => o.ObjectID.toString() === sKRSEvHijyeniObjectID.toString());
             if (sKRSEvHijyeni) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSEvHijyeni = sKRSEvHijyeni;
            }
        }
        let sKRSICDObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSICD"];
        if (sKRSICDObjectID != null && (typeof sKRSICDObjectID === 'string')) {
            let sKRSICD = that.evdeSaglikIlkIzlemFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === sKRSICDObjectID.toString());
             if (sKRSICD) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSICD = sKRSICD;
            }
        }
        let sKRSBirSonrakiHizmetIhtiyaciObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSBirSonrakiHizmetIhtiyaci"];
        if (sKRSBirSonrakiHizmetIhtiyaciObjectID != null && (typeof sKRSBirSonrakiHizmetIhtiyaciObjectID === 'string')) {
            let sKRSBirSonrakiHizmetIhtiyaci = that.evdeSaglikIlkIzlemFormViewModel.SKRSBirSonrakiHizmetIhtiyacis.find(o => o.ObjectID.toString() === sKRSBirSonrakiHizmetIhtiyaciObjectID.toString());
             if (sKRSBirSonrakiHizmetIhtiyaci) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBirSonrakiHizmetIhtiyaci = sKRSBirSonrakiHizmetIhtiyaci;
            }
        }
        let sKRSBeslenmeObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSBeslenme"];
        if (sKRSBeslenmeObjectID != null && (typeof sKRSBeslenmeObjectID === 'string')) {
            let sKRSBeslenme = that.evdeSaglikIlkIzlemFormViewModel.SKRSBeslenmes.find(o => o.ObjectID.toString() === sKRSBeslenmeObjectID.toString());
             if (sKRSBeslenme) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBeslenme = sKRSBeslenme;
            }
        }
        let sKRSBasvuruTuruObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSBasvuruTuru"];
        if (sKRSBasvuruTuruObjectID != null && (typeof sKRSBasvuruTuruObjectID === 'string')) {
            let sKRSBasvuruTuru = that.evdeSaglikIlkIzlemFormViewModel.SKRSBasvuruTurus.find(o => o.ObjectID.toString() === sKRSBasvuruTuruObjectID.toString());
             if (sKRSBasvuruTuru) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBasvuruTuru = sKRSBasvuruTuru;
            }
        }
        let sKRSBasiDegerlendirmesiObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSBasiDegerlendirmesi"];
        if (sKRSBasiDegerlendirmesiObjectID != null && (typeof sKRSBasiDegerlendirmesiObjectID === 'string')) {
            let sKRSBasiDegerlendirmesi = that.evdeSaglikIlkIzlemFormViewModel.SKRSBasiDegerlendirmesis.find(o => o.ObjectID.toString() === sKRSBasiDegerlendirmesiObjectID.toString());
             if (sKRSBasiDegerlendirmesi) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBasiDegerlendirmesi = sKRSBasiDegerlendirmesi;
            }
        }
        let sKRSBakimveDestekIhtiyaciObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSBakimveDestekIhtiyaci"];
        if (sKRSBakimveDestekIhtiyaciObjectID != null && (typeof sKRSBakimveDestekIhtiyaciObjectID === 'string')) {
            let sKRSBakimveDestekIhtiyaci = that.evdeSaglikIlkIzlemFormViewModel.SKRSBakimveDestekIhtiyacis.find(o => o.ObjectID.toString() === sKRSBakimveDestekIhtiyaciObjectID.toString());
             if (sKRSBakimveDestekIhtiyaci) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSBakimveDestekIhtiyaci = sKRSBakimveDestekIhtiyaci;
            }
        }
        let sKRSAydinlatmaObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSAydinlatma"];
        if (sKRSAydinlatmaObjectID != null && (typeof sKRSAydinlatmaObjectID === 'string')) {
            let sKRSAydinlatma = that.evdeSaglikIlkIzlemFormViewModel.SKRSAydinlatmas.find(o => o.ObjectID.toString() === sKRSAydinlatmaObjectID.toString());
             if (sKRSAydinlatma) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSAydinlatma = sKRSAydinlatma;
            }
        }
        let sKRSAgriObjectID = that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti["SKRSAgri"];
        if (sKRSAgriObjectID != null && (typeof sKRSAgriObjectID === 'string')) {
            let sKRSAgri = that.evdeSaglikIlkIzlemFormViewModel.SKRSAgris.find(o => o.ObjectID.toString() === sKRSAgriObjectID.toString());
             if (sKRSAgri) {
                that.evdeSaglikIlkIzlemFormViewModel._EvdeSaglikIlkIzlemVeriSeti.SKRSAgri = sKRSAgri;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        if (this.RouteData2 != null){
            this.ObjectID = this.RouteData2.ObjectID;
            this.ActiveIDsModel = new ActiveIDsModel(this.RouteData2.EpisodeActionID, null, null);
       
        }
        await this.load(EvdeSaglikIlkIzlemFormViewModel);
  
    }


    public onSKRSAgriChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSAgri != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSAgri = event;
            }
        }
    }

    public onSKRSAydinlatmaChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSAydinlatma != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSAydinlatma = event;
            }
        }
    }

    public onSKRSBakimveDestekIhtiyaciChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSBakimveDestekIhtiyaci != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSBakimveDestekIhtiyaci = event;
            }
        }
    }

    public onSKRSBasiDegerlendirmesiChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSBasiDegerlendirmesi != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSBasiDegerlendirmesi = event;
            }
        }
    }

    public onSKRSBasvuruTuruChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSBasvuruTuru != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSBasvuruTuru = event;
            }
        }
    }

    public onSKRSBeslenmeChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSBeslenme != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSBeslenme = event;
            }
        }
    }

    public onSKRSBirSonrakiHizmetIhtiyaciChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSBirSonrakiHizmetIhtiyaci != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSBirSonrakiHizmetIhtiyaci = event;
            }
        }
    }

    public onSKRSEvHijyeniChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSEvHijyeni != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSEvHijyeni = event;
            }
        }
    }

    public onSKRSGuvenlikChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSGuvenlik != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSGuvenlik = event;
            }
        }
    }

    public onSKRSICDChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSICD != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSICD = event;
            }
        }
    }

    public onSKRSIsinmaChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSIsinma != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSIsinma = event;
            }
        }
    }

    public onSKRSKisiselBakimChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSKisiselBakim != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSKisiselBakim = event;
            }
        }
    }

    public onSKRSKisiselHijyenChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSKisiselHijyen != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSKisiselHijyen = event;
            }
        }
    }

    public onSKRSKonutTipiChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSKonutTipi != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSKonutTipi = event;
            }
        }
    }

    public onSKRSKullanilanHelaTipiChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSKullanilanHelaTipi != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSKullanilanHelaTipi = event;
            }
        }
    }

    public onSKRSYatagaBagimlilikChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIlkIzlemVeriSeti != null && this._EvdeSaglikIlkIzlemVeriSeti.SKRSYatagaBagimlilik != event) {
                this._EvdeSaglikIlkIzlemVeriSeti.SKRSYatagaBagimlilik = event;
            }
        }
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        //this.VerilenEgitimler = new TTVisual.TTGrid();
        //this.VerilenEgitimler.Name = "VerilenEgitimler";
        //this.VerilenEgitimler.TabIndex = 34;


        this.VerilenEgitimler = new TTVisual.TTGrid();
        this.VerilenEgitimler.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.VerilenEgitimler.Name = "VerilenEgitimler";
        this.VerilenEgitimler.TabIndex = 0;
        this.VerilenEgitimler.Height = "150px";
        this.VerilenEgitimler.ShowFilterCombo = true;
        this.VerilenEgitimler.FilterColumnName = "SKRSVerilenEgitimlerVerilenEgitimler";
        this.VerilenEgitimler.FilterLabel = i18n("M24107", "Verilen Eğitimler");
        this.VerilenEgitimler.Filter = { ListDefName: "SKRSVerilenEgitimlerList" };
        this.VerilenEgitimler.AllowUserToAddRows = false;
        this.VerilenEgitimler.DeleteButtonWidth = "5%";
        this.VerilenEgitimler.AllowUserToDeleteRows = true;

        this.SKRSVerilenEgitimlerVerilenEgitimler = new TTVisual.TTListBoxColumn();
        this.SKRSVerilenEgitimlerVerilenEgitimler.ListDefName = "SKRSVerilenEgitimlerList";
        this.SKRSVerilenEgitimlerVerilenEgitimler.DataMember = "SKRSVerilenEgitimler";
        this.SKRSVerilenEgitimlerVerilenEgitimler.DisplayIndex = 0;
        this.SKRSVerilenEgitimlerVerilenEgitimler.HeaderText = i18n("M24107", "Verilen Eğitimler");
        this.SKRSVerilenEgitimlerVerilenEgitimler.Name = "SKRSVerilenEgitimlerVerilenEgitimler";
        this.SKRSVerilenEgitimlerVerilenEgitimler.Width = "90%";

        //this.PsikolojikDurum = new TTVisual.TTGrid();
        //this.PsikolojikDurum.Required = true;
        //this.PsikolojikDurum.Name = "PsikolojikDurum";
        //this.PsikolojikDurum.TabIndex = 33;


        this.PsikolojikDurum = new TTVisual.TTGrid();
        this.PsikolojikDurum.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PsikolojikDurum.Name = "PsikolojikDurum";
        this.PsikolojikDurum.TabIndex = 0;
        this.PsikolojikDurum.Height = "150px";
        this.PsikolojikDurum.ShowFilterCombo = true;
        this.PsikolojikDurum.FilterColumnName = "SKRSPsikolojikDurumPsikolojikDurum";
        this.PsikolojikDurum.FilterLabel = i18n("M20609", "Psikolojik Durum Değerlendirmesi");
        this.PsikolojikDurum.Filter = { ListDefName: "SKRSPsikolojikDurumDegerlendirmesiList" };
        this.PsikolojikDurum.AllowUserToAddRows = false;
        this.PsikolojikDurum.DeleteButtonWidth = "5%";
        this.PsikolojikDurum.AllowUserToDeleteRows = true;
        this.PsikolojikDurum.IsFilterLabelSingleLine = true;

        this.SKRSPsikolojikDurumPsikolojikDurum = new TTVisual.TTListBoxColumn();
        this.SKRSPsikolojikDurumPsikolojikDurum.ListDefName = "SKRSPsikolojikDurumDegerlendirmesiList";
        this.SKRSPsikolojikDurumPsikolojikDurum.DataMember = "SKRSPsikolojikDurum";
        this.SKRSPsikolojikDurumPsikolojikDurum.Required = true;
        this.SKRSPsikolojikDurumPsikolojikDurum.DisplayIndex = 0;
        this.SKRSPsikolojikDurumPsikolojikDurum.HeaderText = i18n("M20609", "Psikolojik Durum Değerlendirmesi ");
        this.SKRSPsikolojikDurumPsikolojikDurum.Name = "SKRSPsikolojikDurumPsikolojikDurum";
        this.SKRSPsikolojikDurumPsikolojikDurum.Width = "90%";


        //this.KullandigiYardimciAraclar = new TTVisual.TTGrid();
        //this.KullandigiYardimciAraclar.Required = true;
        //this.KullandigiYardimciAraclar.Name = "KullandigiYardimciAraclar";
        //this.KullandigiYardimciAraclar.TabIndex = 32;


        this.KullandigiYardimciAraclar = new TTVisual.TTGrid();
        this.KullandigiYardimciAraclar.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.KullandigiYardimciAraclar.Name = "KullandigiYardimciAraclar";
        this.KullandigiYardimciAraclar.TabIndex = 0;
        this.KullandigiYardimciAraclar.Height = "150px";
        this.KullandigiYardimciAraclar.ShowFilterCombo = true;
        this.KullandigiYardimciAraclar.FilterColumnName = "SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar";
        this.KullandigiYardimciAraclar.FilterLabel = i18n("M17891", "Kullandığı Yardımcı Araçlar");
        this.KullandigiYardimciAraclar.Filter = { ListDefName: "SKRSKullandigiYardimciAraclarList" };
        this.KullandigiYardimciAraclar.AllowUserToAddRows = false;
        this.KullandigiYardimciAraclar.DeleteButtonWidth = "5%";
        this.KullandigiYardimciAraclar.AllowUserToDeleteRows = true;

        this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar = new TTVisual.TTListBoxColumn();
        this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar.ListDefName = "SKRSKullandigiYardimciAraclarList";
        this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar.DataMember = "SKRSKullandigiYardimciAraclar";
        this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar.Required = true;
        this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar.DisplayIndex = 0;
        this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar.HeaderText = i18n("M17891", "Kullandığı Yardımcı Araçlar");
        this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar.Name = "SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar";
        this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar.Width = "90%";

        this.labelSKRSYatagaBagimlilik = new TTVisual.TTLabel();
        this.labelSKRSYatagaBagimlilik.Text = i18n("M24351", "Yatağa Bağımlılık");
        this.labelSKRSYatagaBagimlilik.Name = "labelSKRSYatagaBagimlilik";
        this.labelSKRSYatagaBagimlilik.TabIndex = 31;

        this.SKRSYatagaBagimlilik = new TTVisual.TTObjectListBox();
        this.SKRSYatagaBagimlilik.Required = true;
        this.SKRSYatagaBagimlilik.ListDefName = "SKRSYatagaBagimlilikList";
        this.SKRSYatagaBagimlilik.Name = "SKRSYatagaBagimlilik";
        this.SKRSYatagaBagimlilik.TabIndex = 30;

        this.labelSKRSKullanilanHelaTipi = new TTVisual.TTLabel();
        this.labelSKRSKullanilanHelaTipi.Text = i18n("M17950", "Kullanılan Tuvalet Tipi");
        this.labelSKRSKullanilanHelaTipi.Name = "labelSKRSKullanilanHelaTipi";
        this.labelSKRSKullanilanHelaTipi.TabIndex = 29;

        this.SKRSKullanilanHelaTipi = new TTVisual.TTObjectListBox();
        this.SKRSKullanilanHelaTipi.ListDefName = "SKRSKullanilanHelaTipiList";
        this.SKRSKullanilanHelaTipi.Name = "SKRSKullanilanHelaTipi";
        this.SKRSKullanilanHelaTipi.TabIndex = 28;

        this.labelSKRSKonutTipi = new TTVisual.TTLabel();
        this.labelSKRSKonutTipi.Text = i18n("M17832", "Konut Tipi");
        this.labelSKRSKonutTipi.Name = "labelSKRSKonutTipi";
        this.labelSKRSKonutTipi.TabIndex = 27;

        this.SKRSKonutTipi = new TTVisual.TTObjectListBox();
        this.SKRSKonutTipi.Required = true;
        this.SKRSKonutTipi.ListDefName = "SKRSKonutTipiList";
        this.SKRSKonutTipi.Name = "SKRSKonutTipi";
        this.SKRSKonutTipi.TabIndex = 26;

        this.labelSKRSKisiselHijyen = new TTVisual.TTLabel();
        this.labelSKRSKisiselHijyen.Text = i18n("M17601", "Kişisel Hijyen");
        this.labelSKRSKisiselHijyen.Name = "labelSKRSKisiselHijyen";
        this.labelSKRSKisiselHijyen.TabIndex = 25;

        this.SKRSKisiselHijyen = new TTVisual.TTObjectListBox();
        this.SKRSKisiselHijyen.Required = true;
        this.SKRSKisiselHijyen.ListDefName = "SKRSKisiselHijyenList";
        this.SKRSKisiselHijyen.Name = "SKRSKisiselHijyen";
        this.SKRSKisiselHijyen.TabIndex = 24;

        this.labelSKRSKisiselBakim = new TTVisual.TTLabel();
        this.labelSKRSKisiselBakim.Text = i18n("M17599", "Kişisel Bakım");
        this.labelSKRSKisiselBakim.Name = "labelSKRSKisiselBakim";
        this.labelSKRSKisiselBakim.TabIndex = 23;

        this.SKRSKisiselBakim = new TTVisual.TTObjectListBox();
        this.SKRSKisiselBakim.Required = true;
        this.SKRSKisiselBakim.ListDefName = "SKRSKisiselBakimList";
        this.SKRSKisiselBakim.Name = "SKRSKisiselBakim";
        this.SKRSKisiselBakim.TabIndex = 22;

        this.labelSKRSIsinma = new TTVisual.TTLabel();
        this.labelSKRSIsinma.Text = i18n("M16023", "Isınma");
        this.labelSKRSIsinma.Name = "labelSKRSIsinma";
        this.labelSKRSIsinma.TabIndex = 21;

        this.SKRSIsinma = new TTVisual.TTObjectListBox();
        this.SKRSIsinma.Required = true;
        this.SKRSIsinma.ListDefName = "SKRSIsinmaList";
        this.SKRSIsinma.Name = "SKRSIsinma";
        this.SKRSIsinma.TabIndex = 20;

        this.labelSKRSGuvenlik = new TTVisual.TTLabel();
        this.labelSKRSGuvenlik.Text = i18n("M15050", "Güvenlik");
        this.labelSKRSGuvenlik.Name = "labelSKRSGuvenlik";
        this.labelSKRSGuvenlik.TabIndex = 19;

        this.SKRSGuvenlik = new TTVisual.TTObjectListBox();
        this.SKRSGuvenlik.Required = true;
        this.SKRSGuvenlik.ListDefName = "SKRSGuvenlikList";
        this.SKRSGuvenlik.Name = "SKRSGuvenlik";
        this.SKRSGuvenlik.TabIndex = 18;

        this.labelSKRSEvHijyeni = new TTVisual.TTLabel();
        this.labelSKRSEvHijyeni.Text = i18n("M13982", "Ev Hijyeni");
        this.labelSKRSEvHijyeni.Name = "labelSKRSEvHijyeni";
        this.labelSKRSEvHijyeni.TabIndex = 17;

        this.SKRSEvHijyeni = new TTVisual.TTObjectListBox();
        this.SKRSEvHijyeni.Required = true;
        this.SKRSEvHijyeni.ListDefName = "SKRSEvHijyeniList";
        this.SKRSEvHijyeni.Name = "SKRSEvHijyeni";
        this.SKRSEvHijyeni.TabIndex = 16;

        this.labelSKRSICD = new TTVisual.TTLabel();
        this.labelSKRSICD.Text = i18n("M13996", "Evde Sağlık Hizmetine Esas Hastalık Grubu");
        this.labelSKRSICD.Name = "labelSKRSICD";
        this.labelSKRSICD.TabIndex = 15;

        this.SKRSICD = new TTVisual.TTObjectListBox();
        this.SKRSICD.Required = true;
        this.SKRSICD.ListDefName = "SKRSICDList";
        this.SKRSICD.Name = "SKRSICD";
        this.SKRSICD.TabIndex = 14;

        this.labelSKRSBirSonrakiHizmetIhtiyaci = new TTVisual.TTLabel();
        this.labelSKRSBirSonrakiHizmetIhtiyaci.Text = i18n("M11843", "Bir Sonraki Hizmet İhtiyacı");
        this.labelSKRSBirSonrakiHizmetIhtiyaci.Name = "labelSKRSBirSonrakiHizmetIhtiyaci";
        this.labelSKRSBirSonrakiHizmetIhtiyaci.TabIndex = 13;

        this.SKRSBirSonrakiHizmetIhtiyaci = new TTVisual.TTObjectListBox();
        this.SKRSBirSonrakiHizmetIhtiyaci.ListDefName = "SKRSBirSonrakiHizmetIhtiyaciList";
        this.SKRSBirSonrakiHizmetIhtiyaci.Name = "SKRSBirSonrakiHizmetIhtiyaci";
        this.SKRSBirSonrakiHizmetIhtiyaci.TabIndex = 12;

        this.labelSKRSBeslenme = new TTVisual.TTLabel();
        this.labelSKRSBeslenme.Text = i18n("M11763", "Beslenme");
        this.labelSKRSBeslenme.Name = "labelSKRSBeslenme";
        this.labelSKRSBeslenme.TabIndex = 11;

        this.SKRSBeslenme = new TTVisual.TTObjectListBox();
        this.SKRSBeslenme.Required = true;
        this.SKRSBeslenme.ListDefName = "SKRSBeslenmeList";
        this.SKRSBeslenme.Name = "SKRSBeslenme";
        this.SKRSBeslenme.TabIndex = 10;

        this.labelSKRSBasvuruTuru = new TTVisual.TTLabel();
        this.labelSKRSBasvuruTuru.Text = "Başvuru Türü";
        this.labelSKRSBasvuruTuru.Name = "labelSKRSBasvuruTuru";
        this.labelSKRSBasvuruTuru.TabIndex = 9;

        this.SKRSBasvuruTuru = new TTVisual.TTObjectListBox();
        this.SKRSBasvuruTuru.Required = true;
        this.SKRSBasvuruTuru.ListDefName = "SKRSBasvuruTuruList";
        this.SKRSBasvuruTuru.Name = "SKRSBasvuruTuru";
        this.SKRSBasvuruTuru.TabIndex = 8;

        this.labelSKRSBasiDegerlendirmesi = new TTVisual.TTLabel();
        this.labelSKRSBasiDegerlendirmesi.Text = "Bası Değerlendirmesi";
        this.labelSKRSBasiDegerlendirmesi.Name = "labelSKRSBasiDegerlendirmesi";
        this.labelSKRSBasiDegerlendirmesi.TabIndex = 7;

        this.SKRSBasiDegerlendirmesi = new TTVisual.TTObjectListBox();
        this.SKRSBasiDegerlendirmesi.Required = true;
        this.SKRSBasiDegerlendirmesi.ListDefName = "SKRSBasiDegerlendirmesiList";
        this.SKRSBasiDegerlendirmesi.Name = "SKRSBasiDegerlendirmesi";
        this.SKRSBasiDegerlendirmesi.TabIndex = 6;

        this.labelSKRSBakimveDestekIhtiyaci = new TTVisual.TTLabel();
        this.labelSKRSBakimveDestekIhtiyaci.Text = i18n("M11480", "Bakım ve Destek İhtiyacı");
        this.labelSKRSBakimveDestekIhtiyaci.Name = "labelSKRSBakimveDestekIhtiyaci";
        this.labelSKRSBakimveDestekIhtiyaci.TabIndex = 5;

        this.SKRSBakimveDestekIhtiyaci = new TTVisual.TTObjectListBox();
        this.SKRSBakimveDestekIhtiyaci.Required = true;
        this.SKRSBakimveDestekIhtiyaci.ListDefName = "SKRSBakimveDestekIhtiyaciList";
        this.SKRSBakimveDestekIhtiyaci.Name = "SKRSBakimveDestekIhtiyaci";
        this.SKRSBakimveDestekIhtiyaci.TabIndex = 4;

        this.labelSKRSAydinlatma = new TTVisual.TTLabel();
        this.labelSKRSAydinlatma.Text = i18n("M11309", "Aydınlatma");
        this.labelSKRSAydinlatma.Name = "labelSKRSAydinlatma";
        this.labelSKRSAydinlatma.TabIndex = 3;

        this.SKRSAydinlatma = new TTVisual.TTObjectListBox();
        this.SKRSAydinlatma.Required = true;
        this.SKRSAydinlatma.ListDefName = "SKRSAydinlatmaList";
        this.SKRSAydinlatma.Name = "SKRSAydinlatma";
        this.SKRSAydinlatma.TabIndex = 2;

        this.labelSKRSAgri = new TTVisual.TTLabel();
        this.labelSKRSAgri.Text = i18n("M10575", "Ağrı");
        this.labelSKRSAgri.Name = "labelSKRSAgri";
        this.labelSKRSAgri.TabIndex = 1;

        this.SKRSAgri = new TTVisual.TTObjectListBox();
        this.SKRSAgri.Required = true;
        this.SKRSAgri.ListDefName = "SKRSAgriList";
        this.SKRSAgri.Name = "SKRSAgri";
        this.SKRSAgri.TabIndex = 0;

        this.VerilenEgitimlerColumns = [this.SKRSVerilenEgitimlerVerilenEgitimler];
        this.PsikolojikDurumColumns = [this.SKRSPsikolojikDurumPsikolojikDurum];
        this.KullandigiYardimciAraclarColumns = [this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar];
        this.Controls = [this.VerilenEgitimler, this.SKRSVerilenEgitimlerVerilenEgitimler, this.PsikolojikDurum, this.SKRSPsikolojikDurumPsikolojikDurum, this.KullandigiYardimciAraclar, this.SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar, this.labelSKRSYatagaBagimlilik, this.SKRSYatagaBagimlilik, this.labelSKRSKullanilanHelaTipi, this.SKRSKullanilanHelaTipi, this.labelSKRSKonutTipi, this.SKRSKonutTipi, this.labelSKRSKisiselHijyen, this.SKRSKisiselHijyen, this.labelSKRSKisiselBakim, this.SKRSKisiselBakim, this.labelSKRSIsinma, this.SKRSIsinma, this.labelSKRSGuvenlik, this.SKRSGuvenlik, this.labelSKRSEvHijyeni, this.SKRSEvHijyeni, this.labelSKRSICD, this.SKRSICD, this.labelSKRSBirSonrakiHizmetIhtiyaci, this.SKRSBirSonrakiHizmetIhtiyaci, this.labelSKRSBeslenme, this.SKRSBeslenme, this.labelSKRSBasvuruTuru, this.SKRSBasvuruTuru, this.labelSKRSBasiDegerlendirmesi, this.SKRSBasiDegerlendirmesi, this.labelSKRSBakimveDestekIhtiyaci, this.SKRSBakimveDestekIhtiyaci, this.labelSKRSAydinlatma, this.SKRSAydinlatma, this.labelSKRSAgri, this.SKRSAgri];

    }


}
