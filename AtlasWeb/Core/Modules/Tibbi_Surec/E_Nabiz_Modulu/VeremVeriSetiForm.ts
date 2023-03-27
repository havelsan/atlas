//$B446FD7B
import { Component, OnInit, NgZone  } from '@angular/core';
import { VeremVeriSetiFormViewModel } from './VeremVeriSetiFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { VeremVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDGTUygulamasiniYapanKisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDGTUygulamaYeri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSHastaninTedaviyeUyumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKulturSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSVeremHastasiTedaviYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSVeremOlguTanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYaymaSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { VeremHastalikTutumYeri } from 'NebulaClient/Model/AtlasClientModel';
import { VeremIlacBilgisi } from 'NebulaClient/Model/AtlasClientModel';
import { VeremKlinikOrnegi } from 'NebulaClient/Model/AtlasClientModel';
import { VeremTedaviSonucBilgisi } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'VeremVeriSetiForm',
    templateUrl: './VeremVeriSetiForm.html',
    providers: [MessageService]
})
export class VeremVeriSetiForm extends TTVisual.TTForm implements OnInit {
    BcgSkarSayisi: TTVisual.ITTTextBox;
    labelBcgSkarSayisi: TTVisual.ITTLabel;
    labelSKRSDGTUygulamasiniYapanKisi: TTVisual.ITTLabel;
    labelSKRSDGTUygulamaYeri: TTVisual.ITTLabel;
    labelSKRSHastaninTedaviyeUyumu: TTVisual.ITTLabel;
    labelSKRSKulturSonucu: TTVisual.ITTLabel;
    labelSKRSVeremHastasiTedaviYontemi: TTVisual.ITTLabel;
    labelSKRSVeremOlguTanimi: TTVisual.ITTLabel;
    labelSKRSYaymaSonucu: TTVisual.ITTLabel;
    labelTuberkulinDeriTestiSonuc: TTVisual.ITTLabel;
    SKRSDGTUygulamasiniYapanKisi: TTVisual.ITTObjectListBox;
    SKRSDGTUygulamaYeri: TTVisual.ITTObjectListBox;
    SKRSHastaninTedaviyeUyumu: TTVisual.ITTObjectListBox;
    SKRSIlacAdiVeremVeremIlacBilgisi: TTVisual.ITTListBoxColumn;
    SKRSIlacDirenciVeremVeremIlacBilgisi: TTVisual.ITTListBoxColumn;
    SKRSKulturSonucu: TTVisual.ITTObjectListBox;
    SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri: TTVisual.ITTListBoxColumn;
    SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi: TTVisual.ITTListBoxColumn;
    SKRSVeremHastasiTedaviYontemi: TTVisual.ITTObjectListBox;
    SKRSVeremOlguTanimi: TTVisual.ITTObjectListBox;
    SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi: TTVisual.ITTListBoxColumn;
    SKRSYaymaSonucu: TTVisual.ITTObjectListBox;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    TuberkulinDeriTestiSonuc: TTVisual.ITTTextBox;
    VeremHastalikTutumYeri: TTVisual.ITTGrid;
    VeremIlacBilgisi: TTVisual.ITTGrid;
    VeremKlinikOrnegi: TTVisual.ITTGrid;
    VeremTedaviSonucBilgisi: TTVisual.ITTGrid;
    RouteData: any;
    RouteData2: any;
    public VeremHastalikTutumYeriColumns = [];
    public VeremIlacBilgisiColumns = [];
    public VeremKlinikOrnegiColumns = [];
    public VeremTedaviSonucBilgisiColumns = [];
    public veremVeriSetiFormViewModel: VeremVeriSetiFormViewModel = new VeremVeriSetiFormViewModel();
    public get _VeremVeriSeti(): VeremVeriSeti {
        return this._TTObject as VeremVeriSeti;
    }
    private VeremVeriSetiForm_DocumentUrl: string = '/api/VeremVeriSetiService/VeremVeriSetiForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('VEREMVERISETI', 'VeremVeriSetiForm');
        this._DocumentServiceUrl = this.VeremVeriSetiForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new VeremVeriSeti();
        this.veremVeriSetiFormViewModel = new VeremVeriSetiFormViewModel();
        this._ViewModel = this.veremVeriSetiFormViewModel;
        this.veremVeriSetiFormViewModel._VeremVeriSeti = this._TTObject as VeremVeriSeti;
        this.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSYaymaSonucu = new SKRSYaymaSonucu();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSVeremOlguTanimi = new SKRSVeremOlguTanimi();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSVeremHastasiTedaviYontemi = new SKRSVeremHastasiTedaviYontemi();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSKulturSonucu = new SKRSKulturSonucu();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSHastaninTedaviyeUyumu = new SKRSHastaninTedaviyeUyumu();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSDGTUygulamasiniYapanKisi = new SKRSDGTUygulamasiniYapanKisi();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSDGTUygulamaYeri = new SKRSDGTUygulamaYeri();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.VeremTedaviSonucBilgisi = new Array<VeremTedaviSonucBilgisi>();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.VeremKlinikOrnegi = new Array<VeremKlinikOrnegi>();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.VeremIlacBilgisi = new Array<VeremIlacBilgisi>();
        this.veremVeriSetiFormViewModel._VeremVeriSeti.VeremHastalikTutumYeri = new Array<VeremHastalikTutumYeri>();
    }

    protected loadViewModel() {
        let that = this;
        that.veremVeriSetiFormViewModel = this._ViewModel as VeremVeriSetiFormViewModel;
        that._TTObject = this.veremVeriSetiFormViewModel._VeremVeriSeti;
        if (this.veremVeriSetiFormViewModel == null)
            this.veremVeriSetiFormViewModel = new VeremVeriSetiFormViewModel();
        if (this.veremVeriSetiFormViewModel._VeremVeriSeti == null)
            this.veremVeriSetiFormViewModel._VeremVeriSeti = new VeremVeriSeti();
        let sKRSYaymaSonucuObjectID = that.veremVeriSetiFormViewModel._VeremVeriSeti["SKRSYaymaSonucu"];
        if (sKRSYaymaSonucuObjectID != null && (typeof sKRSYaymaSonucuObjectID === "string")) {
            let sKRSYaymaSonucu = that.veremVeriSetiFormViewModel.SKRSYaymaSonucus.find(o => o.ObjectID.toString() === sKRSYaymaSonucuObjectID.toString());
             if (sKRSYaymaSonucu) {
                that.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSYaymaSonucu = sKRSYaymaSonucu;
            }
        }
        let sKRSVeremOlguTanimiObjectID = that.veremVeriSetiFormViewModel._VeremVeriSeti["SKRSVeremOlguTanimi"];
        if (sKRSVeremOlguTanimiObjectID != null && (typeof sKRSVeremOlguTanimiObjectID === "string")) {
            let sKRSVeremOlguTanimi = that.veremVeriSetiFormViewModel.SKRSVeremOlguTanimis.find(o => o.ObjectID.toString() === sKRSVeremOlguTanimiObjectID.toString());
             if (sKRSVeremOlguTanimi) {
                that.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSVeremOlguTanimi = sKRSVeremOlguTanimi;
            }
        }
        let sKRSVeremHastasiTedaviYontemiObjectID = that.veremVeriSetiFormViewModel._VeremVeriSeti["SKRSVeremHastasiTedaviYontemi"];
        if (sKRSVeremHastasiTedaviYontemiObjectID != null && (typeof sKRSVeremHastasiTedaviYontemiObjectID === "string")) {
            let sKRSVeremHastasiTedaviYontemi = that.veremVeriSetiFormViewModel.SKRSVeremHastasiTedaviYontemis.find(o => o.ObjectID.toString() === sKRSVeremHastasiTedaviYontemiObjectID.toString());
             if (sKRSVeremHastasiTedaviYontemi) {
                that.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSVeremHastasiTedaviYontemi = sKRSVeremHastasiTedaviYontemi;
            }
        }
        let sKRSKulturSonucuObjectID = that.veremVeriSetiFormViewModel._VeremVeriSeti["SKRSKulturSonucu"];
        if (sKRSKulturSonucuObjectID != null && (typeof sKRSKulturSonucuObjectID === "string")) {
            let sKRSKulturSonucu = that.veremVeriSetiFormViewModel.SKRSKulturSonucus.find(o => o.ObjectID.toString() === sKRSKulturSonucuObjectID.toString());
             if (sKRSKulturSonucu) {
                that.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSKulturSonucu = sKRSKulturSonucu;
            }
        }
        let sKRSHastaninTedaviyeUyumuObjectID = that.veremVeriSetiFormViewModel._VeremVeriSeti["SKRSHastaninTedaviyeUyumu"];
        if (sKRSHastaninTedaviyeUyumuObjectID != null && (typeof sKRSHastaninTedaviyeUyumuObjectID === "string")) {
            let sKRSHastaninTedaviyeUyumu = that.veremVeriSetiFormViewModel.SKRSHastaninTedaviyeUyumus.find(o => o.ObjectID.toString() === sKRSHastaninTedaviyeUyumuObjectID.toString());
             if (sKRSHastaninTedaviyeUyumu) {
                that.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSHastaninTedaviyeUyumu = sKRSHastaninTedaviyeUyumu;
            }
        }
        let sKRSDGTUygulamasiniYapanKisiObjectID = that.veremVeriSetiFormViewModel._VeremVeriSeti["SKRSDGTUygulamasiniYapanKisi"];
        if (sKRSDGTUygulamasiniYapanKisiObjectID != null && (typeof sKRSDGTUygulamasiniYapanKisiObjectID === "string")) {
            let sKRSDGTUygulamasiniYapanKisi = that.veremVeriSetiFormViewModel.SKRSDGTUygulamasiniYapanKisis.find(o => o.ObjectID.toString() === sKRSDGTUygulamasiniYapanKisiObjectID.toString());
             if (sKRSDGTUygulamasiniYapanKisi) {
                that.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSDGTUygulamasiniYapanKisi = sKRSDGTUygulamasiniYapanKisi;
            }
        }
        let sKRSDGTUygulamaYeriObjectID = that.veremVeriSetiFormViewModel._VeremVeriSeti["SKRSDGTUygulamaYeri"];
        if (sKRSDGTUygulamaYeriObjectID != null && (typeof sKRSDGTUygulamaYeriObjectID === "string")) {
            let sKRSDGTUygulamaYeri = that.veremVeriSetiFormViewModel.SKRSDGTUygulamaYeris.find(o => o.ObjectID.toString() === sKRSDGTUygulamaYeriObjectID.toString());
             if (sKRSDGTUygulamaYeri) {
                that.veremVeriSetiFormViewModel._VeremVeriSeti.SKRSDGTUygulamaYeri = sKRSDGTUygulamaYeri;
            }
        }
        that.veremVeriSetiFormViewModel._VeremVeriSeti.VeremTedaviSonucBilgisi = that.veremVeriSetiFormViewModel.VeremTedaviSonucBilgisiGridList;
        for (let detailItem of that.veremVeriSetiFormViewModel.VeremTedaviSonucBilgisiGridList) {
            let sKRSVeremTedaviSonucuObjectID = detailItem["SKRSVeremTedaviSonucu"];
            if (sKRSVeremTedaviSonucuObjectID != null && (typeof sKRSVeremTedaviSonucuObjectID === "string")) {
                let sKRSVeremTedaviSonucu = that.veremVeriSetiFormViewModel.SKRSVeremTedaviSonucus.find(o => o.ObjectID.toString() === sKRSVeremTedaviSonucuObjectID.toString());
                 if (sKRSVeremTedaviSonucu) {
                    detailItem.SKRSVeremTedaviSonucu = sKRSVeremTedaviSonucu;
                }
            }
        }
        that.veremVeriSetiFormViewModel._VeremVeriSeti.VeremKlinikOrnegi = that.veremVeriSetiFormViewModel.VeremKlinikOrnegiGridList;
        for (let detailItem of that.veremVeriSetiFormViewModel.VeremKlinikOrnegiGridList) {
            let sKRSVeremHastasiKlinikOrnegiObjectID = detailItem["SKRSVeremHastasiKlinikOrnegi"];
            if (sKRSVeremHastasiKlinikOrnegiObjectID != null && (typeof sKRSVeremHastasiKlinikOrnegiObjectID === "string")) {
                let sKRSVeremHastasiKlinikOrnegi = that.veremVeriSetiFormViewModel.SKRSVeremHastasiKlinikOrnegis.find(o => o.ObjectID.toString() === sKRSVeremHastasiKlinikOrnegiObjectID.toString());
                 if (sKRSVeremHastasiKlinikOrnegi) {
                    detailItem.SKRSVeremHastasiKlinikOrnegi = sKRSVeremHastasiKlinikOrnegi;
                }
            }
        }
        that.veremVeriSetiFormViewModel._VeremVeriSeti.VeremIlacBilgisi = that.veremVeriSetiFormViewModel.VeremIlacBilgisiGridList;
        for (let detailItem of that.veremVeriSetiFormViewModel.VeremIlacBilgisiGridList) {
            let sKRSIlacAdiVeremObjectID = detailItem["SKRSIlacAdiVerem"];
            if (sKRSIlacAdiVeremObjectID != null && (typeof sKRSIlacAdiVeremObjectID === "string")) {
                let sKRSIlacAdiVerem = that.veremVeriSetiFormViewModel.SKRSIlacAdiVerems.find(o => o.ObjectID.toString() === sKRSIlacAdiVeremObjectID.toString());
                 if (sKRSIlacAdiVerem) {
                    detailItem.SKRSIlacAdiVerem = sKRSIlacAdiVerem;
                }
            }
            let sKRSIlacDirenciVeremObjectID = detailItem["SKRSIlacDirenciVerem"];
            if (sKRSIlacDirenciVeremObjectID != null && (typeof sKRSIlacDirenciVeremObjectID === "string")) {
                let sKRSIlacDirenciVerem = that.veremVeriSetiFormViewModel.SKRSIlacDirenciVerems.find(o => o.ObjectID.toString() === sKRSIlacDirenciVeremObjectID.toString());
                 if (sKRSIlacDirenciVerem) {
                    detailItem.SKRSIlacDirenciVerem = sKRSIlacDirenciVerem;
                }
            }
        }
        that.veremVeriSetiFormViewModel._VeremVeriSeti.VeremHastalikTutumYeri = that.veremVeriSetiFormViewModel.VeremHastalikTutumYeriGridList;
        for (let detailItem of that.veremVeriSetiFormViewModel.VeremHastalikTutumYeriGridList) {
            let sKRSVeremHastaligiTutulumYeriObjectID = detailItem["SKRSVeremHastaligiTutulumYeri"];
            if (sKRSVeremHastaligiTutulumYeriObjectID != null && (typeof sKRSVeremHastaligiTutulumYeriObjectID === "string")) {
                let sKRSVeremHastaligiTutulumYeri = that.veremVeriSetiFormViewModel.SKRSVeremHastaligininTutulumYeris.find(o => o.ObjectID.toString() === sKRSVeremHastaligiTutulumYeriObjectID.toString());
                 if (sKRSVeremHastaligiTutulumYeri) {
                    detailItem.SKRSVeremHastaligiTutulumYeri = sKRSVeremHastaligiTutulumYeri;
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
        await this.load(VeremVeriSetiFormViewModel);
  
    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.veremVeriSetiFormViewModel);


    }


    public onBcgSkarSayisiChanged(event): void {
        if (event != null) {
            if (this._VeremVeriSeti != null && this._VeremVeriSeti.BcgSkarSayisi != event) {
                this._VeremVeriSeti.BcgSkarSayisi = event;
            }
        }
    }

    public onSKRSDGTUygulamasiniYapanKisiChanged(event): void {
        if (event != null) {
            if (this._VeremVeriSeti != null && this._VeremVeriSeti.SKRSDGTUygulamasiniYapanKisi != event) {
                this._VeremVeriSeti.SKRSDGTUygulamasiniYapanKisi = event;
            }
        }
    }

    public onSKRSDGTUygulamaYeriChanged(event): void {
        if (event != null) {
            if (this._VeremVeriSeti != null && this._VeremVeriSeti.SKRSDGTUygulamaYeri != event) {
                this._VeremVeriSeti.SKRSDGTUygulamaYeri = event;
            }
        }
    }

    public onSKRSHastaninTedaviyeUyumuChanged(event): void {
        if (event != null) {
            if (this._VeremVeriSeti != null && this._VeremVeriSeti.SKRSHastaninTedaviyeUyumu != event) {
                this._VeremVeriSeti.SKRSHastaninTedaviyeUyumu = event;
            }
        }
    }

    public onSKRSKulturSonucuChanged(event): void {
        if (event != null) {
            if (this._VeremVeriSeti != null && this._VeremVeriSeti.SKRSKulturSonucu != event) {
                this._VeremVeriSeti.SKRSKulturSonucu = event;
            }
        }
    }

    public onSKRSVeremHastasiTedaviYontemiChanged(event): void {
        if (event != null) {
            if (this._VeremVeriSeti != null && this._VeremVeriSeti.SKRSVeremHastasiTedaviYontemi != event) {
                this._VeremVeriSeti.SKRSVeremHastasiTedaviYontemi = event;
            }
        }
    }

    public onSKRSVeremOlguTanimiChanged(event): void {
        if (event != null) {
            if (this._VeremVeriSeti != null && this._VeremVeriSeti.SKRSVeremOlguTanimi != event) {
                this._VeremVeriSeti.SKRSVeremOlguTanimi = event;
            }
        }
    }

    public onSKRSYaymaSonucuChanged(event): void {
        if (event != null) {
            if (this._VeremVeriSeti != null && this._VeremVeriSeti.SKRSYaymaSonucu != event) {
                this._VeremVeriSeti.SKRSYaymaSonucu = event;
            }
        }
    }

    public onTuberkulinDeriTestiSonucChanged(event): void {
        if (event != null) {
            if (this._VeremVeriSeti != null && this._VeremVeriSeti.TuberkulinDeriTestiSonuc != event) {
                this._VeremVeriSeti.TuberkulinDeriTestiSonuc = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.BcgSkarSayisi, "Text", this.__ttObject, "BcgSkarSayisi");
        redirectProperty(this.TuberkulinDeriTestiSonuc, "Text", this.__ttObject, "TuberkulinDeriTestiSonuc");
    }

    public initFormControls(): void {
        this.labelSKRSYaymaSonucu = new TTVisual.TTLabel();
        this.labelSKRSYaymaSonucu.Text = "Yayma Sonucu";
        this.labelSKRSYaymaSonucu.Name = "labelSKRSYaymaSonucu";
        this.labelSKRSYaymaSonucu.TabIndex = 21;

        this.SKRSYaymaSonucu = new TTVisual.TTObjectListBox();
        this.SKRSYaymaSonucu.ListDefName = "SKRSYaymaSonucuList";
        this.SKRSYaymaSonucu.Name = "SKRSYaymaSonucu";
        this.SKRSYaymaSonucu.TabIndex = 20;

        this.labelSKRSVeremOlguTanimi = new TTVisual.TTLabel();
        this.labelSKRSVeremOlguTanimi.Text = i18n("M24080", "Verem Olgu Tanımı");
        this.labelSKRSVeremOlguTanimi.Name = "labelSKRSVeremOlguTanimi";
        this.labelSKRSVeremOlguTanimi.TabIndex = 19;

        this.SKRSVeremOlguTanimi = new TTVisual.TTObjectListBox();
        this.SKRSVeremOlguTanimi.ListDefName = "SKRSVeremOlguTanimiList";
        this.SKRSVeremOlguTanimi.Name = "SKRSVeremOlguTanimi";
        this.SKRSVeremOlguTanimi.TabIndex = 18;

        this.labelSKRSVeremHastasiTedaviYontemi = new TTVisual.TTLabel();
        this.labelSKRSVeremHastasiTedaviYontemi.Text = i18n("M24077", "Verem Hastası Tedavi Yöntemi");
        this.labelSKRSVeremHastasiTedaviYontemi.Name = "labelSKRSVeremHastasiTedaviYontemi";
        this.labelSKRSVeremHastasiTedaviYontemi.TabIndex = 17;

        this.SKRSVeremHastasiTedaviYontemi = new TTVisual.TTObjectListBox();
        this.SKRSVeremHastasiTedaviYontemi.ListDefName = "SKRSVeremHastasiTedaviYontemiList";
        this.SKRSVeremHastasiTedaviYontemi.Name = "SKRSVeremHastasiTedaviYontemi";
        this.SKRSVeremHastasiTedaviYontemi.TabIndex = 16;

        this.labelSKRSKulturSonucu = new TTVisual.TTLabel();
        this.labelSKRSKulturSonucu.Text = i18n("M18137", "Kültür Sonucu");
        this.labelSKRSKulturSonucu.Name = "labelSKRSKulturSonucu";
        this.labelSKRSKulturSonucu.TabIndex = 15;

        this.SKRSKulturSonucu = new TTVisual.TTObjectListBox();
        this.SKRSKulturSonucu.ListDefName = "SKRSKulturSonucuList";
        this.SKRSKulturSonucu.Name = "SKRSKulturSonucu";
        this.SKRSKulturSonucu.TabIndex = 14;

        this.labelSKRSHastaninTedaviyeUyumu = new TTVisual.TTLabel();
        this.labelSKRSHastaninTedaviyeUyumu.Text = i18n("M15487", "Hastanın Tedaviye Uyumu");
        this.labelSKRSHastaninTedaviyeUyumu.Name = "labelSKRSHastaninTedaviyeUyumu";
        this.labelSKRSHastaninTedaviyeUyumu.TabIndex = 13;

        this.SKRSHastaninTedaviyeUyumu = new TTVisual.TTObjectListBox();
        this.SKRSHastaninTedaviyeUyumu.ListDefName = "SKRSHastaninTedaviyeUyumuList";
        this.SKRSHastaninTedaviyeUyumu.Name = "SKRSHastaninTedaviyeUyumu";
        this.SKRSHastaninTedaviyeUyumu.TabIndex = 12;

        this.labelSKRSDGTUygulamasiniYapanKisi = new TTVisual.TTLabel();
        this.labelSKRSDGTUygulamasiniYapanKisi.Text = "DGT Uygulamasını Yapan Kişi";
        this.labelSKRSDGTUygulamasiniYapanKisi.Name = "labelSKRSDGTUygulamasiniYapanKisi";
        this.labelSKRSDGTUygulamasiniYapanKisi.TabIndex = 11;

        this.SKRSDGTUygulamasiniYapanKisi = new TTVisual.TTObjectListBox();
        this.SKRSDGTUygulamasiniYapanKisi.ListDefName = "SKRSDGTUygulamasiniYapanKisiList";
        this.SKRSDGTUygulamasiniYapanKisi.Name = "SKRSDGTUygulamasiniYapanKisi";
        this.SKRSDGTUygulamasiniYapanKisi.TabIndex = 10;

        this.labelSKRSDGTUygulamaYeri = new TTVisual.TTLabel();
        this.labelSKRSDGTUygulamaYeri.Text = "DGT Uygulama Yeri";
        this.labelSKRSDGTUygulamaYeri.Name = "labelSKRSDGTUygulamaYeri";
        this.labelSKRSDGTUygulamaYeri.TabIndex = 9;

        this.SKRSDGTUygulamaYeri = new TTVisual.TTObjectListBox();
        this.SKRSDGTUygulamaYeri.ListDefName = "SKRSDGTUygulamaYeriList";
        this.SKRSDGTUygulamaYeri.Name = "SKRSDGTUygulamaYeri";
        this.SKRSDGTUygulamaYeri.TabIndex = 8;

        /*this.VeremTedaviSonucBilgisi = new TTVisual.TTGrid();
        this.VeremTedaviSonucBilgisi.Name = "VeremTedaviSonucBilgisi";
        this.VeremTedaviSonucBilgisi.TabIndex = 7;
*/
        this.VeremTedaviSonucBilgisi = new TTVisual.TTGrid();
        this.VeremTedaviSonucBilgisi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.VeremTedaviSonucBilgisi.Name = "VeremTedaviSonucBilgisi";
        this.VeremTedaviSonucBilgisi.TabIndex = 0;
        this.VeremTedaviSonucBilgisi.Height = "150px";
        this.VeremTedaviSonucBilgisi.ShowFilterCombo = true;
        this.VeremTedaviSonucBilgisi.FilterColumnName = "SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi";
        this.VeremTedaviSonucBilgisi.FilterLabel = i18n("M24082", "Tedavi Sonuç Bilgisi");
        this.VeremTedaviSonucBilgisi.Filter = { ListDefName: "SKRSVeremTedaviSonucuList" };
        this.VeremTedaviSonucBilgisi.AllowUserToAddRows = false;
        this.VeremTedaviSonucBilgisi.DeleteButtonWidth = "5%";
        this.VeremTedaviSonucBilgisi.AllowUserToDeleteRows = true;
        this.VeremTedaviSonucBilgisi.IsFilterLabelSingleLine = false;

        this.SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi = new TTVisual.TTListBoxColumn();
        this.SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi.ListDefName = "SKRSVeremTedaviSonucuList";
        this.SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi.DataMember = "SKRSVeremTedaviSonucu";
        this.SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi.DisplayIndex = 0;
        this.SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi.HeaderText = i18n("M24082", "Tedavi Sonuç Bilgisi");
        this.SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi.Name = "SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi";
        this.SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi.Width = 300;

        /*this.VeremKlinikOrnegi = new TTVisual.TTGrid();
        this.VeremKlinikOrnegi.Name = "VeremKlinikOrnegi";
        this.VeremKlinikOrnegi.TabIndex = 6;
*/
        this.VeremKlinikOrnegi = new TTVisual.TTGrid();
        this.VeremKlinikOrnegi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.VeremKlinikOrnegi.Name = "VeremKlinikOrnegi";
        this.VeremKlinikOrnegi.TabIndex = 0;
        this.VeremKlinikOrnegi.Height = "150px";
        this.VeremKlinikOrnegi.ShowFilterCombo = true;
        this.VeremKlinikOrnegi.FilterColumnName = "SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi";
        this.VeremKlinikOrnegi.FilterLabel = i18n("M24079", "Hastalık Klinik Örneği");
        this.VeremKlinikOrnegi.Filter = { ListDefName: "SKRSVeremHastasiKlinikOrnegiList" };
        this.VeremKlinikOrnegi.AllowUserToAddRows = false;
        this.VeremKlinikOrnegi.DeleteButtonWidth = "5%";
        this.VeremKlinikOrnegi.AllowUserToDeleteRows = true;
        this.VeremKlinikOrnegi.IsFilterLabelSingleLine = false;

        this.SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi = new TTVisual.TTListBoxColumn();
        this.SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi.ListDefName = "SKRSVeremHastasiKlinikOrnegiList";
        this.SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi.DataMember = "SKRSVeremHastasiKlinikOrnegi";
        this.SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi.DisplayIndex = 0;
        this.SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi.HeaderText = i18n("M24079", "Hastalık Klinik Örneği");
        this.SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi.Name = "SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi";
        this.SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi.Width = 300;

        /*this.VeremIlacBilgisi = new TTVisual.TTGrid();
        this.VeremIlacBilgisi.Name = "VeremIlacBilgisi";
        this.VeremIlacBilgisi.TabIndex = 5;
*/
        this.VeremIlacBilgisi = new TTVisual.TTGrid();
        this.VeremIlacBilgisi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.VeremIlacBilgisi.Name = "VeremIlacBilgisi";
        this.VeremIlacBilgisi.TabIndex = 0;
        this.VeremIlacBilgisi.Height = "200px";
        this.VeremIlacBilgisi.ShowFilterCombo = true;
        this.VeremIlacBilgisi.FilterColumnName = "SKRSIlacAdiVeremVeremIlacBilgisi";
        this.VeremIlacBilgisi.FilterLabel = i18n("M16294", "İlaç Adı");
        this.VeremIlacBilgisi.Filter = { ListDefName: "SKRSIlacAdiVeremList" };
        this.VeremIlacBilgisi.AllowUserToAddRows = false;
        this.VeremIlacBilgisi.DeleteButtonWidth = "5%";
        this.VeremIlacBilgisi.AllowUserToDeleteRows = true;
        this.VeremIlacBilgisi.IsFilterLabelSingleLine = false;
        this.VeremIlacBilgisi.Required = true;

        this.SKRSIlacAdiVeremVeremIlacBilgisi = new TTVisual.TTListBoxColumn();
        this.SKRSIlacAdiVeremVeremIlacBilgisi.ListDefName = "SKRSIlacAdiVeremList";
        this.SKRSIlacAdiVeremVeremIlacBilgisi.DataMember = "SKRSIlacAdiVerem";
        this.SKRSIlacAdiVeremVeremIlacBilgisi.DisplayIndex = 0;
        this.SKRSIlacAdiVeremVeremIlacBilgisi.HeaderText = i18n("M16294", "İlaç Adı");
        this.SKRSIlacAdiVeremVeremIlacBilgisi.Name = "SKRSIlacAdiVeremVeremIlacBilgisi";
        this.SKRSIlacAdiVeremVeremIlacBilgisi.Width = 300;

        this.SKRSIlacDirenciVeremVeremIlacBilgisi = new TTVisual.TTListBoxColumn();
        this.SKRSIlacDirenciVeremVeremIlacBilgisi.ListDefName = "SKRSIlacDirenciVeremList";
        this.SKRSIlacDirenciVeremVeremIlacBilgisi.DataMember = "SKRSIlacDirenciVerem";
        this.SKRSIlacDirenciVeremVeremIlacBilgisi.DisplayIndex = 1;
        this.SKRSIlacDirenciVeremVeremIlacBilgisi.HeaderText = i18n("M16315", "İlaç Direnci");
        this.SKRSIlacDirenciVeremVeremIlacBilgisi.Name = "SKRSIlacDirenciVeremVeremIlacBilgisi";
        this.SKRSIlacDirenciVeremVeremIlacBilgisi.Width = 300;

        /*this.VeremHastalikTutumYeri = new TTVisual.TTGrid();
        this.VeremHastalikTutumYeri.Name = "VeremHastalikTutumYeri";
        this.VeremHastalikTutumYeri.TabIndex = 4;*/

        this.VeremHastalikTutumYeri = new TTVisual.TTGrid();
        this.VeremHastalikTutumYeri.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.VeremHastalikTutumYeri.Name = "VeremHastalikTutumYeri";
        this.VeremHastalikTutumYeri.TabIndex = 0;
        this.VeremHastalikTutumYeri.Height = "150px";
        this.VeremHastalikTutumYeri.ShowFilterCombo = true;
        this.VeremHastalikTutumYeri.FilterColumnName = "SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri";
        this.VeremHastalikTutumYeri.FilterLabel = i18n("M24075", "Hastalık Tutum Yeri");
        this.VeremHastalikTutumYeri.Filter = { ListDefName: "SKRSVeremHastaligininTutulumYeriList" };
        this.VeremHastalikTutumYeri.AllowUserToAddRows = false;
        this.VeremHastalikTutumYeri.DeleteButtonWidth = "5%";
        this.VeremHastalikTutumYeri.AllowUserToDeleteRows = true;
        this.VeremHastalikTutumYeri.IsFilterLabelSingleLine = true;

        this.SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri = new TTVisual.TTListBoxColumn();
        this.SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri.ListDefName = "SKRSVeremHastaligininTutulumYeriList";
        this.SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri.DataMember = "SKRSVeremHastaligiTutulumYeri";
        this.SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri.DisplayIndex = 0;
        this.SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri.HeaderText = i18n("M24075", "Hastalık Tutum Yeri");
        this.SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri.Name = "SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri";
        this.SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri.Width = 300;

        this.labelTuberkulinDeriTestiSonuc = new TTVisual.TTLabel();
        this.labelTuberkulinDeriTestiSonuc.Text = i18n("M23619", "Tüberkülin Deri Testi Sonucu");
        this.labelTuberkulinDeriTestiSonuc.Name = "labelTuberkulinDeriTestiSonuc";
        this.labelTuberkulinDeriTestiSonuc.TabIndex = 3;

        this.TuberkulinDeriTestiSonuc = new TTVisual.TTTextBox();
        this.TuberkulinDeriTestiSonuc.Name = "TuberkulinDeriTestiSonuc";
        this.TuberkulinDeriTestiSonuc.TabIndex = 2;

        this.BcgSkarSayisi = new TTVisual.TTTextBox();
        this.BcgSkarSayisi.Name = "BcgSkarSayisi";
        this.BcgSkarSayisi.TabIndex = 0;

        this.labelBcgSkarSayisi = new TTVisual.TTLabel();
        this.labelBcgSkarSayisi.Text = i18n("M11676", "Bcg Skar Sayısı");
        this.labelBcgSkarSayisi.Name = "labelBcgSkarSayisi";
        this.labelBcgSkarSayisi.TabIndex = 1;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M24075", "Verem Hastalığının Tutum Yeri");
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 3;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M24078", "Verem İlaç Bilgisi");
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 3;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M24079", "Verem Klinik Örneği");
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 3;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M24082", "Verem Tedavi Sonuç Bilgisi");
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 3;

        this.VeremTedaviSonucBilgisiColumns = [this.SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi];
        this.VeremKlinikOrnegiColumns = [this.SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi];
        this.VeremIlacBilgisiColumns = [this.SKRSIlacAdiVeremVeremIlacBilgisi, this.SKRSIlacDirenciVeremVeremIlacBilgisi];
        this.VeremHastalikTutumYeriColumns = [this.SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri];
        this.Controls = [this.labelSKRSYaymaSonucu, this.SKRSYaymaSonucu, this.labelSKRSVeremOlguTanimi, this.SKRSVeremOlguTanimi, this.labelSKRSVeremHastasiTedaviYontemi, this.SKRSVeremHastasiTedaviYontemi, this.labelSKRSKulturSonucu, this.SKRSKulturSonucu, this.labelSKRSHastaninTedaviyeUyumu, this.SKRSHastaninTedaviyeUyumu, this.labelSKRSDGTUygulamasiniYapanKisi, this.SKRSDGTUygulamasiniYapanKisi, this.labelSKRSDGTUygulamaYeri, this.SKRSDGTUygulamaYeri, this.VeremTedaviSonucBilgisi, this.SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi, this.VeremKlinikOrnegi, this.SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi, this.VeremIlacBilgisi, this.SKRSIlacAdiVeremVeremIlacBilgisi, this.SKRSIlacDirenciVeremVeremIlacBilgisi, this.VeremHastalikTutumYeri, this.SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri, this.labelTuberkulinDeriTestiSonuc, this.TuberkulinDeriTestiSonuc, this.BcgSkarSayisi, this.labelBcgSkarSayisi, this.ttlabel10, this.ttlabel11, this.ttlabel12, this.ttlabel13];

    }


}
