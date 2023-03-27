//$B1B8D247
import { Component, OnInit, NgZone } from '@angular/core';
import { MaddeBagimliligiVeriSetiFormViewModel } from './MaddeBagimliligiVeriSetiFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MaddeBagimliligiVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { MaddeBagimBulasiciHastalik } from 'NebulaClient/Model/AtlasClientModel';
import { MaddeBagimliligiKulMadde } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAlkolKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSEnjektorPaylasimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGonderenBirim } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIsDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKullanilanMadde } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigaraKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTedaviMerkeziTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTedaviSonucuMaddeBagimliligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSUygulananTedaviTuruMaddeBagimliligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYasadigiBolge } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYasamBicimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'MaddeBagimliligiVeriSetiForm',
    templateUrl: './MaddeBagimliligiVeriSetiForm.html',
    providers: [MessageService]
})
export class MaddeBagimliligiVeriSetiForm extends TTVisual.TTForm implements OnInit {
    DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde: TTVisual.ITTTextBoxColumn;
    EnjeksiyonIleIlkMaddeKulYas: TTVisual.ITTTextBox;
    HastaKodu: TTVisual.ITTTextBox;
    labelEnjeksiyonIleIlkMaddeKulYas: TTVisual.ITTLabel;
    labelHastaKodu: TTVisual.ITTLabel;
    labelSigaraAdedi: TTVisual.ITTLabel;
    labelSKRSAlkolKullanimi: TTVisual.ITTLabel;
    labelSKRSEnjeksiyonMaddeKullanimi: TTVisual.ITTLabel;
    labelSKRSEnjektorPaylasimDurumu: TTVisual.ITTLabel;
    labelSKRSGonderenBirim: TTVisual.ITTLabel;
    labelSKRSIsDurumu: TTVisual.ITTLabel;
    labelSKRSKullanilanMadde: TTVisual.ITTLabel;
    labelSKRSOgrenimDurumu: TTVisual.ITTLabel;
    labelSKRSSigaraKullanimi: TTVisual.ITTLabel;
    labelSKRSTedaviMerkeziTipi: TTVisual.ITTLabel;
    labelSKRSTedaviSonucuMaddeBagim: TTVisual.ITTLabel;
    labelSKRSUygulananTedaviMaddeBagim: TTVisual.ITTLabel;
    labelSKRSYasadigiBolge: TTVisual.ITTLabel;
    labelSKRSYasamBicimi: TTVisual.ITTLabel;
    MaddeBagimBulasiciHastalik: TTVisual.ITTGrid;
    MaddeBagimliligiKulMadde: TTVisual.ITTGrid;
    MaddeIlkKullanimYasiMaddeBagimliligiKulMadde: TTVisual.ITTTextBoxColumn;
    SigaraAdedi: TTVisual.ITTTextBox;
    SKRSAlkolKullanimi: TTVisual.ITTObjectListBox;
    SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik: TTVisual.ITTListBoxColumn;
    SKRSEnjeksiyonMaddeKullanimi: TTVisual.ITTObjectListBox;
    SKRSEnjektorPaylasimDurumu: TTVisual.ITTObjectListBox;
    SKRSGonderenBirim: TTVisual.ITTObjectListBox;
    SKRSIsDurumu: TTVisual.ITTObjectListBox;
    SKRSKullanilanMadde: TTVisual.ITTObjectListBox;
    SKRSKullanilanMaddeMaddeBagimliligiKulMadde: TTVisual.ITTListBoxColumn;
    SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde: TTVisual.ITTListBoxColumn;
    SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde: TTVisual.ITTListBoxColumn;
    SKRSOgrenimDurumu: TTVisual.ITTObjectListBox;
    SKRSSigaraKullanimi: TTVisual.ITTObjectListBox;
    SKRSTedaviMerkeziTipi: TTVisual.ITTObjectListBox;
    SKRSTedaviSonucuMaddeBagim: TTVisual.ITTObjectListBox;
    SKRSUygulananTedaviMaddeBagim: TTVisual.ITTObjectListBox;
    SKRSYasadigiBolge: TTVisual.ITTObjectListBox;
    SKRSYasamBicimi: TTVisual.ITTObjectListBox;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    RouteData: any;
    RouteData2: any;
    public MaddeBagimBulasiciHastalikColumns = [];
    public MaddeBagimliligiKulMaddeColumns = [];
    public maddeBagimliligiVeriSetiFormViewModel: MaddeBagimliligiVeriSetiFormViewModel = new MaddeBagimliligiVeriSetiFormViewModel();
    public get _MaddeBagimliligiVeriSeti(): MaddeBagimliligiVeriSeti {
        return this._TTObject as MaddeBagimliligiVeriSeti;
    }
    private MaddeBagimliligiVeriSetiForm_DocumentUrl: string = '/api/MaddeBagimliligiVeriSetiService/MaddeBagimliligiVeriSetiForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('MADDEBAGIMLILIGIVERISETI', 'MaddeBagimliligiVeriSetiForm');
        this._DocumentServiceUrl = this.MaddeBagimliligiVeriSetiForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MaddeBagimliligiVeriSeti();
        this.maddeBagimliligiVeriSetiFormViewModel = new MaddeBagimliligiVeriSetiFormViewModel();
        this._ViewModel = this.maddeBagimliligiVeriSetiFormViewModel;
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti = this._TTObject as MaddeBagimliligiVeriSeti;
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSYasamBicimi = new SKRSYasamBicimi();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi = new SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSYasadigiBolge = new SKRSYasadigiBolge();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim = new SKRSUygulananTedaviTuruMaddeBagimliligi();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim = new SKRSTedaviSonucuMaddeBagimliligi();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi = new SKRSTedaviMerkeziTipi();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSSigaraKullanimi = new SKRSSigaraKullanimi();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSOgrenimDurumu = new SKRSOgrenimDurumu();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSKullanilanMadde = new SKRSKullanilanMadde();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSIsDurumu = new SKRSIsDurumu();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSGonderenBirim = new SKRSGonderenBirim();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu = new SKRSEnjektorPaylasimDurumu();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSAlkolKullanimi = new SKRSAlkolKullanimi();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.MaddeBagimliligiKulMadde = new Array<MaddeBagimliligiKulMadde>();
        this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.MaddeBagimBulasiciHastalik = new Array<MaddeBagimBulasiciHastalik>();
    }

    protected loadViewModel() {
        let that = this;
        that.maddeBagimliligiVeriSetiFormViewModel = this._ViewModel as MaddeBagimliligiVeriSetiFormViewModel;
        that._TTObject = this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti;
        if (this.maddeBagimliligiVeriSetiFormViewModel == null)
            this.maddeBagimliligiVeriSetiFormViewModel = new MaddeBagimliligiVeriSetiFormViewModel();
        if (this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti == null)
            this.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti = new MaddeBagimliligiVeriSeti();
        let sKRSYasamBicimiObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSYasamBicimi"];
        if (sKRSYasamBicimiObjectID != null && (typeof sKRSYasamBicimiObjectID === "string")) {
            let sKRSYasamBicimi = that.maddeBagimliligiVeriSetiFormViewModel.SKRSYasamBicimis.find(o => o.ObjectID.toString() === sKRSYasamBicimiObjectID.toString());
             if (sKRSYasamBicimi) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSYasamBicimi = sKRSYasamBicimi;
            }
        }
        let sKRSEnjeksiyonMaddeKullanimiObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSEnjeksiyonMaddeKullanimi"];
        if (sKRSEnjeksiyonMaddeKullanimiObjectID != null && (typeof sKRSEnjeksiyonMaddeKullanimiObjectID === "string")) {
            let sKRSEnjeksiyonMaddeKullanimi = that.maddeBagimliligiVeriSetiFormViewModel.SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumus.find(o => o.ObjectID.toString() === sKRSEnjeksiyonMaddeKullanimiObjectID.toString());
             if (sKRSEnjeksiyonMaddeKullanimi) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi = sKRSEnjeksiyonMaddeKullanimi;
            }
        }
        let sKRSYasadigiBolgeObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSYasadigiBolge"];
        if (sKRSYasadigiBolgeObjectID != null && (typeof sKRSYasadigiBolgeObjectID === "string")) {
            let sKRSYasadigiBolge = that.maddeBagimliligiVeriSetiFormViewModel.SKRSYasadigiBolges.find(o => o.ObjectID.toString() === sKRSYasadigiBolgeObjectID.toString());
             if (sKRSYasadigiBolge) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSYasadigiBolge = sKRSYasadigiBolge;
            }
        }
        let sKRSUygulananTedaviMaddeBagimObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSUygulananTedaviMaddeBagim"];
        if (sKRSUygulananTedaviMaddeBagimObjectID != null && (typeof sKRSUygulananTedaviMaddeBagimObjectID === "string")) {
            let sKRSUygulananTedaviMaddeBagim = that.maddeBagimliligiVeriSetiFormViewModel.SKRSUygulananTedaviTuruMaddeBagimliligis.find(o => o.ObjectID.toString() === sKRSUygulananTedaviMaddeBagimObjectID.toString());
             if (sKRSUygulananTedaviMaddeBagim) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim = sKRSUygulananTedaviMaddeBagim;
            }
        }
        let sKRSTedaviSonucuMaddeBagimObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSTedaviSonucuMaddeBagim"];
        if (sKRSTedaviSonucuMaddeBagimObjectID != null && (typeof sKRSTedaviSonucuMaddeBagimObjectID === "string")) {
            let sKRSTedaviSonucuMaddeBagim = that.maddeBagimliligiVeriSetiFormViewModel.SKRSTedaviSonucuMaddeBagimliligis.find(o => o.ObjectID.toString() === sKRSTedaviSonucuMaddeBagimObjectID.toString());
             if (sKRSTedaviSonucuMaddeBagim) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim = sKRSTedaviSonucuMaddeBagim;
            }
        }
        let sKRSTedaviMerkeziTipiObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSTedaviMerkeziTipi"];
        if (sKRSTedaviMerkeziTipiObjectID != null && (typeof sKRSTedaviMerkeziTipiObjectID === "string")) {
            let sKRSTedaviMerkeziTipi = that.maddeBagimliligiVeriSetiFormViewModel.SKRSTedaviMerkeziTipis.find(o => o.ObjectID.toString() === sKRSTedaviMerkeziTipiObjectID.toString());
             if (sKRSTedaviMerkeziTipi) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi = sKRSTedaviMerkeziTipi;
            }
        }
        let sKRSSigaraKullanimiObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSSigaraKullanimi"];
        if (sKRSSigaraKullanimiObjectID != null && (typeof sKRSSigaraKullanimiObjectID === "string")) {
            let sKRSSigaraKullanimi = that.maddeBagimliligiVeriSetiFormViewModel.SKRSSigaraKullanimis.find(o => o.ObjectID.toString() === sKRSSigaraKullanimiObjectID.toString());
             if (sKRSSigaraKullanimi) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSSigaraKullanimi = sKRSSigaraKullanimi;
            }
        }
        let sKRSOgrenimDurumuObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSOgrenimDurumu"];
        if (sKRSOgrenimDurumuObjectID != null && (typeof sKRSOgrenimDurumuObjectID === "string")) {
            let sKRSOgrenimDurumu = that.maddeBagimliligiVeriSetiFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === sKRSOgrenimDurumuObjectID.toString());
             if (sKRSOgrenimDurumu) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSOgrenimDurumu = sKRSOgrenimDurumu;
            }
        }
        let sKRSKullanilanMaddeObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSKullanilanMadde"];
        if (sKRSKullanilanMaddeObjectID != null && (typeof sKRSKullanilanMaddeObjectID === "string")) {
            let sKRSKullanilanMadde = that.maddeBagimliligiVeriSetiFormViewModel.SKRSKullanilanMaddes.find(o => o.ObjectID.toString() === sKRSKullanilanMaddeObjectID.toString());
             if (sKRSKullanilanMadde) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSKullanilanMadde = sKRSKullanilanMadde;
            }
        }
        let sKRSIsDurumuObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSIsDurumu"];
        if (sKRSIsDurumuObjectID != null && (typeof sKRSIsDurumuObjectID === "string")) {
            let sKRSIsDurumu = that.maddeBagimliligiVeriSetiFormViewModel.SKRSIsDurumus.find(o => o.ObjectID.toString() === sKRSIsDurumuObjectID.toString());
             if (sKRSIsDurumu) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSIsDurumu = sKRSIsDurumu;
            }
        }
        let sKRSGonderenBirimObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSGonderenBirim"];
        if (sKRSGonderenBirimObjectID != null && (typeof sKRSGonderenBirimObjectID === "string")) {
            let sKRSGonderenBirim = that.maddeBagimliligiVeriSetiFormViewModel.SKRSGonderenBirims.find(o => o.ObjectID.toString() === sKRSGonderenBirimObjectID.toString());
             if (sKRSGonderenBirim) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSGonderenBirim = sKRSGonderenBirim;
            }
        }
        let sKRSEnjektorPaylasimDurumuObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSEnjektorPaylasimDurumu"];
        if (sKRSEnjektorPaylasimDurumuObjectID != null && (typeof sKRSEnjektorPaylasimDurumuObjectID === "string")) {
            let sKRSEnjektorPaylasimDurumu = that.maddeBagimliligiVeriSetiFormViewModel.SKRSEnjektorPaylasimDurumus.find(o => o.ObjectID.toString() === sKRSEnjektorPaylasimDurumuObjectID.toString());
             if (sKRSEnjektorPaylasimDurumu) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu = sKRSEnjektorPaylasimDurumu;
            }
        }
        let sKRSAlkolKullanimiObjectID = that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti["SKRSAlkolKullanimi"];
        if (sKRSAlkolKullanimiObjectID != null && (typeof sKRSAlkolKullanimiObjectID === "string")) {
            let sKRSAlkolKullanimi = that.maddeBagimliligiVeriSetiFormViewModel.SKRSAlkolKullanimis.find(o => o.ObjectID.toString() === sKRSAlkolKullanimiObjectID.toString());
             if (sKRSAlkolKullanimi) {
                that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.SKRSAlkolKullanimi = sKRSAlkolKullanimi;
            }
        }
        that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.MaddeBagimliligiKulMadde = that.maddeBagimliligiVeriSetiFormViewModel.MaddeBagimliligiKulMaddeGridList;
        for (let detailItem of that.maddeBagimliligiVeriSetiFormViewModel.MaddeBagimliligiKulMaddeGridList) {
            let sKRSKullanilanMaddeObjectID = detailItem["SKRSKullanilanMadde"];
            if (sKRSKullanilanMaddeObjectID != null && (typeof sKRSKullanilanMaddeObjectID === "string")) {
                let sKRSKullanilanMadde = that.maddeBagimliligiVeriSetiFormViewModel.SKRSKullanilanMaddes.find(o => o.ObjectID.toString() === sKRSKullanilanMaddeObjectID.toString());
                 if (sKRSKullanilanMadde) {
                    detailItem.SKRSKullanilanMadde = sKRSKullanilanMadde;
                }
            }
            let sKRSMaddeKullanimSikligiObjectID = detailItem["SKRSMaddeKullanimSikligi"];
            if (sKRSMaddeKullanimSikligiObjectID != null && (typeof sKRSMaddeKullanimSikligiObjectID === "string")) {
                let sKRSMaddeKullanimSikligi = that.maddeBagimliligiVeriSetiFormViewModel.SKRSMaddeKullanimSikligis.find(o => o.ObjectID.toString() === sKRSMaddeKullanimSikligiObjectID.toString());
                 if (sKRSMaddeKullanimSikligi) {
                    detailItem.SKRSMaddeKullanimSikligi = sKRSMaddeKullanimSikligi;
                }
            }
            let sKRSMaddeKullanimYoluObjectID = detailItem["SKRSMaddeKullanimYolu"];
            if (sKRSMaddeKullanimYoluObjectID != null && (typeof sKRSMaddeKullanimYoluObjectID === "string")) {
                let sKRSMaddeKullanimYolu = that.maddeBagimliligiVeriSetiFormViewModel.SKRSMaddeKullanimYolus.find(o => o.ObjectID.toString() === sKRSMaddeKullanimYoluObjectID.toString());
                 if (sKRSMaddeKullanimYolu) {
                    detailItem.SKRSMaddeKullanimYolu = sKRSMaddeKullanimYolu;
                }
            }
        }
        that.maddeBagimliligiVeriSetiFormViewModel._MaddeBagimliligiVeriSeti.MaddeBagimBulasiciHastalik = that.maddeBagimliligiVeriSetiFormViewModel.MaddeBagimBulasiciHastalikGridList;
        for (let detailItem of that.maddeBagimliligiVeriSetiFormViewModel.MaddeBagimBulasiciHastalikGridList) {
            let sKRSBulasiciHastalikDurumuObjectID = detailItem["SKRSBulasiciHastalikDurumu"];
            if (sKRSBulasiciHastalikDurumuObjectID != null && (typeof sKRSBulasiciHastalikDurumuObjectID === "string")) {
                let sKRSBulasiciHastalikDurumu = that.maddeBagimliligiVeriSetiFormViewModel.SKRSBulasiciHastalikDurumus.find(o => o.ObjectID.toString() === sKRSBulasiciHastalikDurumuObjectID.toString());
                 if (sKRSBulasiciHastalikDurumu) {
                    detailItem.SKRSBulasiciHastalikDurumu = sKRSBulasiciHastalikDurumu;
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
        await this.load(MaddeBagimliligiVeriSetiFormViewModel);
  
    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.maddeBagimliligiVeriSetiFormViewModel);


    }

    public onEnjeksiyonIleIlkMaddeKulYasChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.EnjeksiyonIleIlkMaddeKulYas != event) {
                this._MaddeBagimliligiVeriSeti.EnjeksiyonIleIlkMaddeKulYas = event;
            }
        }
    }

    public onHastaKoduChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.HastaKodu != event) {
                this._MaddeBagimliligiVeriSeti.HastaKodu = event;
            }
        }
    }

    public onSigaraAdediChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SigaraAdedi != event) {
                this._MaddeBagimliligiVeriSeti.SigaraAdedi = event;
            }
        }
    }

    public onSKRSAlkolKullanimiChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSAlkolKullanimi != event) {
                this._MaddeBagimliligiVeriSeti.SKRSAlkolKullanimi = event;
            }
        }
    }

    public onSKRSEnjeksiyonMaddeKullanimiChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi != event) {
                this._MaddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi = event;
            }
        }
    }

    public onSKRSEnjektorPaylasimDurumuChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu != event) {
                this._MaddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu = event;
            }
        }
    }

    public onSKRSGonderenBirimChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSGonderenBirim != event) {
                this._MaddeBagimliligiVeriSeti.SKRSGonderenBirim = event;
            }
        }
    }

    public onSKRSIsDurumuChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSIsDurumu != event) {
                this._MaddeBagimliligiVeriSeti.SKRSIsDurumu = event;
            }
        }
    }

    public onSKRSKullanilanMaddeChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSKullanilanMadde != event) {
                this._MaddeBagimliligiVeriSeti.SKRSKullanilanMadde = event;
            }
        }
    }

    public onSKRSOgrenimDurumuChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSOgrenimDurumu != event) {
                this._MaddeBagimliligiVeriSeti.SKRSOgrenimDurumu = event;
            }
        }
    }

    public onSKRSSigaraKullanimiChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSSigaraKullanimi != event) {
                this._MaddeBagimliligiVeriSeti.SKRSSigaraKullanimi = event;
            }
        }
    }

    public onSKRSTedaviMerkeziTipiChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi != event) {
                this._MaddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi = event;
            }
        }
    }

    public onSKRSTedaviSonucuMaddeBagimChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim != event) {
                this._MaddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim = event;
            }
        }
    }

    public onSKRSUygulananTedaviMaddeBagimChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim != event) {
                this._MaddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim = event;
            }
        }
    }

    public onSKRSYasadigiBolgeChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSYasadigiBolge != event) {
                this._MaddeBagimliligiVeriSeti.SKRSYasadigiBolge = event;
            }
        }
    }

    public onSKRSYasamBicimiChanged(event): void {
        if (event != null) {
            if (this._MaddeBagimliligiVeriSeti != null && this._MaddeBagimliligiVeriSeti.SKRSYasamBicimi != event) {
                this._MaddeBagimliligiVeriSeti.SKRSYasamBicimi = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EnjeksiyonIleIlkMaddeKulYas, "Text", this.__ttObject, "EnjeksiyonIleIlkMaddeKulYas");
        redirectProperty(this.HastaKodu, "Text", this.__ttObject, "HastaKodu");
        redirectProperty(this.SigaraAdedi, "Text", this.__ttObject, "SigaraAdedi");
    }

    public initFormControls(): void {
        this.labelSKRSYasamBicimi = new TTVisual.TTLabel();
        this.labelSKRSYasamBicimi.Text = i18n("M24345", "Yaşam Biçimi");
        this.labelSKRSYasamBicimi.Name = "labelSKRSYasamBicimi";
        this.labelSKRSYasamBicimi.TabIndex = 33;

        this.SKRSYasamBicimi = new TTVisual.TTObjectListBox();
        this.SKRSYasamBicimi.ListDefName = "SKRSYasamBicimiList";
        this.SKRSYasamBicimi.Name = "SKRSYasamBicimi";
        this.SKRSYasamBicimi.TabIndex = 32;

        this.labelSKRSEnjeksiyonMaddeKullanimi = new TTVisual.TTLabel();
        this.labelSKRSEnjeksiyonMaddeKullanimi.Text = "Enjeksiyon ile Madde Kullanımı";
        this.labelSKRSEnjeksiyonMaddeKullanimi.Name = "labelSKRSEnjeksiyonMaddeKullanimi";
        this.labelSKRSEnjeksiyonMaddeKullanimi.TabIndex = 31;

        this.SKRSEnjeksiyonMaddeKullanimi = new TTVisual.TTObjectListBox();
        this.SKRSEnjeksiyonMaddeKullanimi.ListDefName = "SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumuL";
        this.SKRSEnjeksiyonMaddeKullanimi.Name = "SKRSEnjeksiyonMaddeKullanimi";
        this.SKRSEnjeksiyonMaddeKullanimi.TabIndex = 30;

        this.labelSKRSYasadigiBolge = new TTVisual.TTLabel();
        this.labelSKRSYasadigiBolge.Text = i18n("M24343", "Yaşadığı Bölge");
        this.labelSKRSYasadigiBolge.Name = "labelSKRSYasadigiBolge";
        this.labelSKRSYasadigiBolge.TabIndex = 29;

        this.SKRSYasadigiBolge = new TTVisual.TTObjectListBox();
        this.SKRSYasadigiBolge.ListDefName = "SKRSYasadigiBolgeList";
        this.SKRSYasadigiBolge.Name = "SKRSYasadigiBolge";
        this.SKRSYasadigiBolge.TabIndex = 28;

        this.labelSKRSUygulananTedaviMaddeBagim = new TTVisual.TTLabel();
        this.labelSKRSUygulananTedaviMaddeBagim.Text = "Uygulanan Tedavi";
        this.labelSKRSUygulananTedaviMaddeBagim.Name = "labelSKRSUygulananTedaviMaddeBagim";
        this.labelSKRSUygulananTedaviMaddeBagim.TabIndex = 27;

        this.SKRSUygulananTedaviMaddeBagim = new TTVisual.TTObjectListBox();
        this.SKRSUygulananTedaviMaddeBagim.ListDefName = "SKRSUygulananTedaviTuruMaddeBagimliligiList";
        this.SKRSUygulananTedaviMaddeBagim.Name = "SKRSUygulananTedaviMaddeBagim";
        this.SKRSUygulananTedaviMaddeBagim.TabIndex = 26;

        this.labelSKRSTedaviSonucuMaddeBagim = new TTVisual.TTLabel();
        this.labelSKRSTedaviSonucuMaddeBagim.Text = i18n("M23023", "Tedavi Sonucu");
        this.labelSKRSTedaviSonucuMaddeBagim.Name = "labelSKRSTedaviSonucuMaddeBagim";
        this.labelSKRSTedaviSonucuMaddeBagim.TabIndex = 25;

        this.SKRSTedaviSonucuMaddeBagim = new TTVisual.TTObjectListBox();
        this.SKRSTedaviSonucuMaddeBagim.ListDefName = "SKRSTedaviSonucuMaddeBagimliligiList";
        this.SKRSTedaviSonucuMaddeBagim.Name = "SKRSTedaviSonucuMaddeBagim";
        this.SKRSTedaviSonucuMaddeBagim.TabIndex = 24;

        this.labelSKRSTedaviMerkeziTipi = new TTVisual.TTLabel();
        this.labelSKRSTedaviMerkeziTipi.Text = i18n("M23002", "Tedavi Merkezi Tipi");
        this.labelSKRSTedaviMerkeziTipi.Name = "labelSKRSTedaviMerkeziTipi";
        this.labelSKRSTedaviMerkeziTipi.TabIndex = 23;

        this.SKRSTedaviMerkeziTipi = new TTVisual.TTObjectListBox();
        this.SKRSTedaviMerkeziTipi.ListDefName = "SKRSTedaviMerkeziTipiList";
        this.SKRSTedaviMerkeziTipi.Name = "SKRSTedaviMerkeziTipi";
        this.SKRSTedaviMerkeziTipi.TabIndex = 22;

        this.labelSKRSSigaraKullanimi = new TTVisual.TTLabel();
        this.labelSKRSSigaraKullanimi.Text = i18n("M21841", "Sigara Kullanımı");
        this.labelSKRSSigaraKullanimi.Name = "labelSKRSSigaraKullanimi";
        this.labelSKRSSigaraKullanimi.TabIndex = 21;

        this.SKRSSigaraKullanimi = new TTVisual.TTObjectListBox();
        this.SKRSSigaraKullanimi.ListDefName = "SKRSSigaraKullanimiList";
        this.SKRSSigaraKullanimi.Name = "SKRSSigaraKullanimi";
        this.SKRSSigaraKullanimi.TabIndex = 20;

        this.labelSKRSOgrenimDurumu = new TTVisual.TTLabel();
        this.labelSKRSOgrenimDurumu.Text = i18n("M19901", "Öğrenim Durumu");
        this.labelSKRSOgrenimDurumu.Name = "labelSKRSOgrenimDurumu";
        this.labelSKRSOgrenimDurumu.TabIndex = 19;

        this.SKRSOgrenimDurumu = new TTVisual.TTObjectListBox();
        this.SKRSOgrenimDurumu.ListDefName = "SKRSOgrenimDurumuList";
        this.SKRSOgrenimDurumu.Name = "SKRSOgrenimDurumu";
        this.SKRSOgrenimDurumu.TabIndex = 18;

        this.labelSKRSKullanilanMadde = new TTVisual.TTLabel();
        this.labelSKRSKullanilanMadde.Text = "Kullanılan Madde";
        this.labelSKRSKullanilanMadde.Name = "labelSKRSKullanilanMadde";
        this.labelSKRSKullanilanMadde.TabIndex = 17;

        this.SKRSKullanilanMadde = new TTVisual.TTObjectListBox();
        this.SKRSKullanilanMadde.ListDefName = "SKRSKullanilanMaddeList";
        this.SKRSKullanilanMadde.Name = "SKRSKullanilanMadde";
        this.SKRSKullanilanMadde.TabIndex = 16;

        this.labelSKRSIsDurumu = new TTVisual.TTLabel();
        this.labelSKRSIsDurumu.Text = i18n("M16744", "İş Durumu");
        this.labelSKRSIsDurumu.Name = "labelSKRSIsDurumu";
        this.labelSKRSIsDurumu.TabIndex = 15;

        this.SKRSIsDurumu = new TTVisual.TTObjectListBox();
        this.SKRSIsDurumu.ListDefName = "SKRSIsDurumuList";
        this.SKRSIsDurumu.Name = "SKRSIsDurumu";
        this.SKRSIsDurumu.TabIndex = 14;

        this.labelSKRSGonderenBirim = new TTVisual.TTLabel();
        this.labelSKRSGonderenBirim.Text = i18n("M14853", "Gönderen Birim");
        this.labelSKRSGonderenBirim.Name = "labelSKRSGonderenBirim";
        this.labelSKRSGonderenBirim.TabIndex = 13;

        this.SKRSGonderenBirim = new TTVisual.TTObjectListBox();
        this.SKRSGonderenBirim.ListDefName = "SKRSGonderenBirimList";
        this.SKRSGonderenBirim.Name = "SKRSGonderenBirim";
        this.SKRSGonderenBirim.TabIndex = 12;

        this.labelSKRSEnjektorPaylasimDurumu = new TTVisual.TTLabel();
        this.labelSKRSEnjektorPaylasimDurumu.Text = i18n("M13752", "Enjektör Paylaşım Durumu");
        this.labelSKRSEnjektorPaylasimDurumu.Name = "labelSKRSEnjektorPaylasimDurumu";
        this.labelSKRSEnjektorPaylasimDurumu.TabIndex = 11;

        this.SKRSEnjektorPaylasimDurumu = new TTVisual.TTObjectListBox();
        this.SKRSEnjektorPaylasimDurumu.ListDefName = "SKRSEnjektorPaylasimDurumuList";
        this.SKRSEnjektorPaylasimDurumu.Name = "SKRSEnjektorPaylasimDurumu";
        this.SKRSEnjektorPaylasimDurumu.TabIndex = 10;

        this.labelSKRSAlkolKullanimi = new TTVisual.TTLabel();
        this.labelSKRSAlkolKullanimi.Text = "Alkol Kullanimi";
        this.labelSKRSAlkolKullanimi.Name = "labelSKRSAlkolKullanimi";
        this.labelSKRSAlkolKullanimi.TabIndex = 9;

        this.SKRSAlkolKullanimi = new TTVisual.TTObjectListBox();
        this.SKRSAlkolKullanimi.ListDefName = "SKRSAlkolKullanimiList";
        this.SKRSAlkolKullanimi.Name = "SKRSAlkolKullanimi";
        this.SKRSAlkolKullanimi.TabIndex = 8;

        /*this.MaddeBagimliligiKulMadde = new TTVisual.TTGrid();
        this.MaddeBagimliligiKulMadde.Name = "MaddeBagimliligiKulMadde";
        this.MaddeBagimliligiKulMadde.TabIndex = 7;*/
        this.MaddeBagimliligiKulMadde = new TTVisual.TTGrid();
        this.MaddeBagimliligiKulMadde.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MaddeBagimliligiKulMadde.Name = "MaddeBagimliligiKulMadde";
        this.MaddeBagimliligiKulMadde.TabIndex = 0;
        this.MaddeBagimliligiKulMadde.Height = "150px";
        this.MaddeBagimliligiKulMadde.ShowFilterCombo = true;
        this.MaddeBagimliligiKulMadde.FilterColumnName = "SKRSKullanilanMaddeMaddeBagimliligiKulMadde";
        this.MaddeBagimliligiKulMadde.FilterLabel =  i18n("M27614", "Kullanılan Madde");
        this.MaddeBagimliligiKulMadde.Filter = { ListDefName: "SKRSKullanilanMaddeList" };
        this.MaddeBagimliligiKulMadde.AllowUserToAddRows = false;
        this.MaddeBagimliligiKulMadde.DeleteButtonWidth = "5%";
        this.MaddeBagimliligiKulMadde.AllowUserToDeleteRows = true;
        this.MaddeBagimliligiKulMadde.IsFilterLabelSingleLine = false;

        this.SKRSKullanilanMaddeMaddeBagimliligiKulMadde = new TTVisual.TTListBoxColumn();
        this.SKRSKullanilanMaddeMaddeBagimliligiKulMadde.ListDefName = "SKRSKullanilanMaddeList";
        this.SKRSKullanilanMaddeMaddeBagimliligiKulMadde.DataMember = "SKRSKullanilanMadde";
        this.SKRSKullanilanMaddeMaddeBagimliligiKulMadde.DisplayIndex = 0;
        this.SKRSKullanilanMaddeMaddeBagimliligiKulMadde.HeaderText = i18n("M27614", "Kullanılan Madde");
        this.SKRSKullanilanMaddeMaddeBagimliligiKulMadde.Name = "SKRSKullanilanMaddeMaddeBagimliligiKulMadde";
        this.SKRSKullanilanMaddeMaddeBagimliligiKulMadde.Width = 200;

        this.SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde = new TTVisual.TTListBoxColumn();
        this.SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde.ListDefName = "SKRSMaddeKullanimSikligiList";
        this.SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde.DataMember = "SKRSMaddeKullanimSikligi";
        this.SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde.DisplayIndex = 1;
        this.SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde.HeaderText = i18n("M30533", "Kullanım Sıklığı");
        this.SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde.Name = "SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde";
        this.SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde.Width = 100;

        this.SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde = new TTVisual.TTListBoxColumn();
        this.SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde.ListDefName = "SKRSMaddeKullanimYoluList";
        this.SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde.DataMember = "SKRSMaddeKullanimYolu";
        this.SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde.DisplayIndex = 2;
        this.SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde.HeaderText = i18n("M30534", "Kullanım Yolu");
        this.SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde.Name = "SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde";
        this.SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde.Width = 100;

        this.DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde = new TTVisual.TTTextBoxColumn();
        this.DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde.DataMember = "DuzenliMaddeKullanimSuresi";
        this.DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde.DisplayIndex = 3;
        this.DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde.HeaderText = i18n("M30535", "Düzenli Kul. Süresi");
        this.DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde.Name = "DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde";
        this.DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde.Width = 80;

        this.MaddeIlkKullanimYasiMaddeBagimliligiKulMadde = new TTVisual.TTTextBoxColumn();
        this.MaddeIlkKullanimYasiMaddeBagimliligiKulMadde.DataMember = "MaddeIlkKullanimYasi";
        this.MaddeIlkKullanimYasiMaddeBagimliligiKulMadde.DisplayIndex = 4;
        this.MaddeIlkKullanimYasiMaddeBagimliligiKulMadde.HeaderText = i18n("M30536", "İlk Kullanım Yaşı");
        this.MaddeIlkKullanimYasiMaddeBagimliligiKulMadde.Name = "MaddeIlkKullanimYasiMaddeBagimliligiKulMadde";
        this.MaddeIlkKullanimYasiMaddeBagimliligiKulMadde.Width = 80;

        /*this.MaddeBagimBulasiciHastalik = new TTVisual.TTGrid();
                this.MaddeBagimBulasiciHastalik.Name = "MaddeBagimBulasiciHastalik";
                this.MaddeBagimBulasiciHastalik.TabIndex = 6;*/

        this.MaddeBagimBulasiciHastalik = new TTVisual.TTGrid();
        this.MaddeBagimBulasiciHastalik.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MaddeBagimBulasiciHastalik.Name = "MaddeBagimBulasiciHastalik";
        this.MaddeBagimBulasiciHastalik.TabIndex = 0;
        this.MaddeBagimBulasiciHastalik.Height = "150px";
        this.MaddeBagimBulasiciHastalik.ShowFilterCombo = true;
        this.MaddeBagimBulasiciHastalik.FilterColumnName = "SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik";
        this.MaddeBagimBulasiciHastalik.FilterLabel = i18n("M12107", "Bulaşıcı Hastalık Durumu");
        this.MaddeBagimBulasiciHastalik.Filter = { ListDefName: "SKRSBulasiciHastalikDurumuList" };
        this.MaddeBagimBulasiciHastalik.AllowUserToAddRows = false;
        this.MaddeBagimBulasiciHastalik.DeleteButtonWidth = "5%";
        this.MaddeBagimBulasiciHastalik.AllowUserToDeleteRows = true;
        this.MaddeBagimBulasiciHastalik.IsFilterLabelSingleLine = false;

        this.SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik = new TTVisual.TTListBoxColumn();
        this.SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik.ListDefName = "SKRSBulasiciHastalikDurumuList";
        this.SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik.DataMember = "SKRSBulasiciHastalikDurumu";
        this.SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik.DisplayIndex = 0;
        this.SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik.HeaderText = i18n("M12107", "Bulaşıcı Hastalık Durumu");
        this.SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik.Name = "SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik";
        this.SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik.Width = 300;

        this.labelSigaraAdedi = new TTVisual.TTLabel();
        this.labelSigaraAdedi.Text = "Sigara Adedi";
        this.labelSigaraAdedi.Name = "labelSigaraAdedi";
        this.labelSigaraAdedi.TabIndex = 5;

        this.SigaraAdedi = new TTVisual.TTTextBox();
        this.SigaraAdedi.Name = "SigaraAdedi";
        this.SigaraAdedi.TabIndex = 4;

        this.HastaKodu = new TTVisual.TTTextBox();
        this.HastaKodu.Name = "HastaKodu";
        this.HastaKodu.TabIndex = 2;

        this.EnjeksiyonIleIlkMaddeKulYas = new TTVisual.TTTextBox();
        this.EnjeksiyonIleIlkMaddeKulYas.Name = "EnjeksiyonIleIlkMaddeKulYas";
        this.EnjeksiyonIleIlkMaddeKulYas.TabIndex = 0;

        this.labelHastaKodu = new TTVisual.TTLabel();
        this.labelHastaKodu.Text = "Hasta Kodu";
        this.labelHastaKodu.Name = "labelHastaKodu";
        this.labelHastaKodu.TabIndex = 3;

        this.labelEnjeksiyonIleIlkMaddeKulYas = new TTVisual.TTLabel();
        this.labelEnjeksiyonIleIlkMaddeKulYas.Text = "Enjeksiyon ile İlk Madde Kullanım Yaşı";
        this.labelEnjeksiyonIleIlkMaddeKulYas.Name = "labelEnjeksiyonIleIlkMaddeKulYas";
        this.labelEnjeksiyonIleIlkMaddeKulYas.TabIndex = 1;

        this.ttlabel17 = new TTVisual.TTLabel();
        this.ttlabel17.Text = i18n("M12107", "Bulaşıcı Hastalık Durumu");
        this.ttlabel17.Name = "ttlabel17";
        this.ttlabel17.TabIndex = 5;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = "Kullanılan Madde Bilgisi";
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 5;

        this.MaddeBagimliligiKulMaddeColumns = [this.SKRSKullanilanMaddeMaddeBagimliligiKulMadde, this.SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde, this.SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde, this.DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde, this.MaddeIlkKullanimYasiMaddeBagimliligiKulMadde];
        this.MaddeBagimBulasiciHastalikColumns = [this.SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik];
        this.Controls = [this.labelSKRSYasamBicimi, this.SKRSYasamBicimi, this.labelSKRSEnjeksiyonMaddeKullanimi, this.SKRSEnjeksiyonMaddeKullanimi, this.labelSKRSYasadigiBolge, this.SKRSYasadigiBolge, this.labelSKRSUygulananTedaviMaddeBagim, this.SKRSUygulananTedaviMaddeBagim, this.labelSKRSTedaviSonucuMaddeBagim, this.SKRSTedaviSonucuMaddeBagim, this.labelSKRSTedaviMerkeziTipi, this.SKRSTedaviMerkeziTipi, this.labelSKRSSigaraKullanimi, this.SKRSSigaraKullanimi, this.labelSKRSOgrenimDurumu, this.SKRSOgrenimDurumu, this.labelSKRSKullanilanMadde, this.SKRSKullanilanMadde, this.labelSKRSIsDurumu, this.SKRSIsDurumu, this.labelSKRSGonderenBirim, this.SKRSGonderenBirim, this.labelSKRSEnjektorPaylasimDurumu, this.SKRSEnjektorPaylasimDurumu, this.labelSKRSAlkolKullanimi, this.SKRSAlkolKullanimi, this.MaddeBagimliligiKulMadde, this.SKRSKullanilanMaddeMaddeBagimliligiKulMadde, this.SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde, this.SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde, this.DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde, this.MaddeIlkKullanimYasiMaddeBagimliligiKulMadde, this.MaddeBagimBulasiciHastalik, this.SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik, this.labelSigaraAdedi, this.SigaraAdedi, this.HastaKodu, this.EnjeksiyonIleIlkMaddeKulYas, this.labelHastaKodu, this.labelEnjeksiyonIleIlkMaddeKulYas, this.ttlabel17, this.ttlabel18];

    }


}
