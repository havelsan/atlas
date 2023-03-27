//$C6AC9B95
import { Component, OnInit  } from '@angular/core';
import { CancerScreeningFormViewModel } from './CancerScreeningFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CancerScreening } from 'NebulaClient/Model/AtlasClientModel';
import { BreastBiopsy } from 'NebulaClient/Model/AtlasClientModel';
import { CervicalBiopsyResults } from 'NebulaClient/Model/AtlasClientModel';
import { CervicalCytologyResults } from 'NebulaClient/Model/AtlasClientModel';
import { ColonoscopyQualityCriteria } from 'NebulaClient/Model/AtlasClientModel';
import { ColorectalBiopsyResults } from 'NebulaClient/Model/AtlasClientModel';
import { HPVTypeInfo } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGaitadaGizliKanTesti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSHPVTaramaTesti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKendiKendineMemeMuayenesi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKlinikMemeMuayenesi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKolonGoruntulemeYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKolonoskopi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKolonoskopininSuresi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKolposkopi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMamografi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMamografiSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPapSmearTesti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigmoidoskopi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTARAMATIPI } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';

@Component({
    selector: 'CancerScreeningForm',
    templateUrl: './CancerScreeningForm.html',
    providers: [MessageService]
})
export class CancerScreeningForm extends TTVisual.TTForm implements OnInit {
    BreastBiopsy: TTVisual.ITTGrid;
    CervicalBiopsyResults: TTVisual.ITTGrid;
    CervicalCytologyResults: TTVisual.ITTGrid;
    ColonoscopyQualityCriteria: TTVisual.ITTGrid;
    ColorectalBiopsyResults: TTVisual.ITTGrid;
    HPVTypeInfo: TTVisual.ITTGrid;
    KolonoskopiKaliteKriterleriColonoscopyQualityCriteria: TTVisual.ITTListBoxColumn;
    labelSKRSGaitadaGizliKanTesti: TTVisual.ITTLabel;
    labelSKRSHPVTaramaTesti: TTVisual.ITTLabel;
    labelSKRSKendiKendineMemeMuayenesi: TTVisual.ITTLabel;
    labelSKRSKlinikMemeMuayenesi: TTVisual.ITTLabel;
    labelSKRSKolonGoruntulemeYontemi: TTVisual.ITTLabel;
    labelSKRSKolonoskopi: TTVisual.ITTLabel;
    labelSKRSKolonoskopininSuresi: TTVisual.ITTLabel;
    labelSKRSKolposkopi: TTVisual.ITTLabel;
    labelSKRSMamografi: TTVisual.ITTLabel;
    labelSKRSMamografiSonucu: TTVisual.ITTLabel;
    labelSKRSPapSmearTesti: TTVisual.ITTLabel;
    labelSKRSSigmoidoskopi: TTVisual.ITTLabel;
    labelSKRSTARAMATIPI: TTVisual.ITTLabel;
    labelTaramaSonuclanmaTarihi: TTVisual.ITTLabel;
    labelTaramaTarihi: TTVisual.ITTLabel;
    SKRSGaitadaGizliKanTesti: TTVisual.ITTObjectListBox;
    SKRSHPVTaramaTesti: TTVisual.ITTObjectListBox;
    SKRSHpvTipiHPVTypeInfo: TTVisual.ITTListBoxColumn;
    SKRSKendiKendineMemeMuayenesi: TTVisual.ITTObjectListBox;
    SKRSKlinikMemeMuayenesi: TTVisual.ITTObjectListBox;
    SKRSKolonGoruntulemeYontemi: TTVisual.ITTObjectListBox;
    SKRSKolonoskopi: TTVisual.ITTObjectListBox;
    SKRSKolonoskopininSuresi: TTVisual.ITTObjectListBox;
    SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults: TTVisual.ITTListBoxColumn;
    SKRSKolposkopi: TTVisual.ITTObjectListBox;
    SKRSMamografi: TTVisual.ITTObjectListBox;
    SKRSMamografiSonucu: TTVisual.ITTObjectListBox;
    SKRSMemeBiyopsiSonucuBreastBiopsy: TTVisual.ITTListBoxColumn;
    SKRSMemedenBiyopsiAlimiBreastBiopsy: TTVisual.ITTListBoxColumn;
    SKRSPapSmearTesti: TTVisual.ITTObjectListBox;
    SKRSServikalBiyopsiSonucuCervicalBiopsyResults: TTVisual.ITTListBoxColumn;
    SKRSServikalSitolojiSonucuCervicalCytologyResults: TTVisual.ITTListBoxColumn;
    SKRSSigmoidoskopi: TTVisual.ITTObjectListBox;
    SKRSTARAMATIPI: TTVisual.ITTObjectListBox;
    TaramaSonuclanmaTarihi: TTVisual.ITTDateTimePicker;
    TaramaTarihi: TTVisual.ITTDateTimePicker;
    public BreastBiopsyColumns = [];
    public CervicalBiopsyResultsColumns = [];
    public CervicalCytologyResultsColumns = [];
    public ColonoscopyQualityCriteriaColumns = [];
    public ColorectalBiopsyResultsColumns = [];
    public HPVTypeInfoColumns = [];
    public statesPanelClass: string = "col-lg-6";
    public _buttonCaption: string = "Yazdır";
    public _buttonIcon: string = "fa fa-print";
    public cancerScreeningFormViewModel: CancerScreeningFormViewModel = new CancerScreeningFormViewModel();
    public get _CancerScreening(): CancerScreening {
        return this._TTObject as CancerScreening;
    }
    private CancerScreeningForm_DocumentUrl: string = '/api/CancerScreeningService/CancerScreeningForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        super('CANCERSCREENING', 'CancerScreeningForm');
        this._DocumentServiceUrl = this.CancerScreeningForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CancerScreening();
        this.cancerScreeningFormViewModel = new CancerScreeningFormViewModel();
        this._ViewModel = this.cancerScreeningFormViewModel;
        this.cancerScreeningFormViewModel._CancerScreening = this._TTObject as CancerScreening;
        this.cancerScreeningFormViewModel._CancerScreening.SKRSTARAMATIPI = new SKRSTARAMATIPI();
        this.cancerScreeningFormViewModel._CancerScreening.BreastBiopsy = new Array<BreastBiopsy>();
        this.cancerScreeningFormViewModel._CancerScreening.CervicalCytologyResults = new Array<CervicalCytologyResults>();
        this.cancerScreeningFormViewModel._CancerScreening.CervicalBiopsyResults = new Array<CervicalBiopsyResults>();
        this.cancerScreeningFormViewModel._CancerScreening.ColorectalBiopsyResults = new Array<ColorectalBiopsyResults>();
        this.cancerScreeningFormViewModel._CancerScreening.ColonoscopyQualityCriteria = new Array<ColonoscopyQualityCriteria>();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSSigmoidoskopi = new SKRSSigmoidoskopi();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSPapSmearTesti = new SKRSPapSmearTesti();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSMamografiSonucu = new SKRSMamografiSonucu();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSMamografi = new SKRSMamografi();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSKolposkopi = new SKRSKolposkopi();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSKolonoskopininSuresi = new SKRSKolonoskopininSuresi();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSKlinikMemeMuayenesi = new SKRSKlinikMemeMuayenesi();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSKendiKendineMemeMuayenesi = new SKRSKendiKendineMemeMuayenesi();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSHPVTaramaTesti = new SKRSHPVTaramaTesti();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSKolonoskopi = new SKRSKolonoskopi();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSKolonGoruntulemeYontemi = new SKRSKolonGoruntulemeYontemi();
        this.cancerScreeningFormViewModel._CancerScreening.SKRSGaitadaGizliKanTesti = new SKRSGaitadaGizliKanTesti();
        this.cancerScreeningFormViewModel._CancerScreening.HPVTypeInfo = new Array<HPVTypeInfo>();
    }

    protected loadViewModel() {
        let that = this;
        that.cancerScreeningFormViewModel = this._ViewModel as CancerScreeningFormViewModel;
        that._TTObject = this.cancerScreeningFormViewModel._CancerScreening;
        if (this.cancerScreeningFormViewModel == null)
            this.cancerScreeningFormViewModel = new CancerScreeningFormViewModel();
        if (this.cancerScreeningFormViewModel._CancerScreening == null)
            this.cancerScreeningFormViewModel._CancerScreening = new CancerScreening();
        let sKRSTARAMATIPIObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSTARAMATIPI"];
        if (sKRSTARAMATIPIObjectID != null && (typeof sKRSTARAMATIPIObjectID === "string")) {
            let sKRSTARAMATIPI = that.cancerScreeningFormViewModel.SKRSTARAMATIPIs.find(o => o.ObjectID.toString() === sKRSTARAMATIPIObjectID.toString());
             if (sKRSTARAMATIPI) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSTARAMATIPI = sKRSTARAMATIPI;
            }
        }
        that.cancerScreeningFormViewModel._CancerScreening.BreastBiopsy = that.cancerScreeningFormViewModel.BreastBiopsyGridList;
        for (let detailItem of that.cancerScreeningFormViewModel.BreastBiopsyGridList) {
            let sKRSMemedenBiyopsiAlimiObjectID = detailItem["SKRSMemedenBiyopsiAlimi"];
            if (sKRSMemedenBiyopsiAlimiObjectID != null && (typeof sKRSMemedenBiyopsiAlimiObjectID === "string")) {
                let sKRSMemedenBiyopsiAlimi = that.cancerScreeningFormViewModel.SKRSMemedenBiyopsiAlimis.find(o => o.ObjectID.toString() === sKRSMemedenBiyopsiAlimiObjectID.toString());
                 if (sKRSMemedenBiyopsiAlimi) {
                    detailItem.SKRSMemedenBiyopsiAlimi = sKRSMemedenBiyopsiAlimi;
                }
            }
            let sKRSMemeBiyopsiSonucuObjectID = detailItem["SKRSMemeBiyopsiSonucu"];
            if (sKRSMemeBiyopsiSonucuObjectID != null && (typeof sKRSMemeBiyopsiSonucuObjectID === "string")) {
                let sKRSMemeBiyopsiSonucu = that.cancerScreeningFormViewModel.SKRSMemeBiyopsiSonucus.find(o => o.ObjectID.toString() === sKRSMemeBiyopsiSonucuObjectID.toString());
                 if (sKRSMemeBiyopsiSonucu) {
                    detailItem.SKRSMemeBiyopsiSonucu = sKRSMemeBiyopsiSonucu;
                }
            }
        }
        that.cancerScreeningFormViewModel._CancerScreening.CervicalCytologyResults = that.cancerScreeningFormViewModel.CervicalCytologyResultsGridList;
        for (let detailItem of that.cancerScreeningFormViewModel.CervicalCytologyResultsGridList) {
            let sKRSServikalSitolojiSonucuObjectID = detailItem["SKRSServikalSitolojiSonucu"];
            if (sKRSServikalSitolojiSonucuObjectID != null && (typeof sKRSServikalSitolojiSonucuObjectID === "string")) {
                let sKRSServikalSitolojiSonucu = that.cancerScreeningFormViewModel.SKRSServikalSitolojiSonucus.find(o => o.ObjectID.toString() === sKRSServikalSitolojiSonucuObjectID.toString());
                 if (sKRSServikalSitolojiSonucu) {
                    detailItem.SKRSServikalSitolojiSonucu = sKRSServikalSitolojiSonucu;
                }
            }
        }
        that.cancerScreeningFormViewModel._CancerScreening.CervicalBiopsyResults = that.cancerScreeningFormViewModel.CervicalBiopsyResultsGridList;
        for (let detailItem of that.cancerScreeningFormViewModel.CervicalBiopsyResultsGridList) {
            let sKRSServikalBiyopsiSonucuObjectID = detailItem["SKRSServikalBiyopsiSonucu"];
            if (sKRSServikalBiyopsiSonucuObjectID != null && (typeof sKRSServikalBiyopsiSonucuObjectID === "string")) {
                let sKRSServikalBiyopsiSonucu = that.cancerScreeningFormViewModel.SKRSServikalBiyopsiSonucus.find(o => o.ObjectID.toString() === sKRSServikalBiyopsiSonucuObjectID.toString());
                 if (sKRSServikalBiyopsiSonucu) {
                    detailItem.SKRSServikalBiyopsiSonucu = sKRSServikalBiyopsiSonucu;
                }
            }
        }
        that.cancerScreeningFormViewModel._CancerScreening.ColorectalBiopsyResults = that.cancerScreeningFormViewModel.ColorectalBiopsyResultsGridList;
        for (let detailItem of that.cancerScreeningFormViewModel.ColorectalBiopsyResultsGridList) {
            let sKRSKolorektalBiyopsiSonucuObjectID = detailItem["SKRSKolorektalBiyopsiSonucu"];
            if (sKRSKolorektalBiyopsiSonucuObjectID != null && (typeof sKRSKolorektalBiyopsiSonucuObjectID === "string")) {
                let sKRSKolorektalBiyopsiSonucu = that.cancerScreeningFormViewModel.SKRSKolorektalBiyopsiSonucus.find(o => o.ObjectID.toString() === sKRSKolorektalBiyopsiSonucuObjectID.toString());
                 if (sKRSKolorektalBiyopsiSonucu) {
                    detailItem.SKRSKolorektalBiyopsiSonucu = sKRSKolorektalBiyopsiSonucu;
                }
            }
        }
        that.cancerScreeningFormViewModel._CancerScreening.ColonoscopyQualityCriteria = that.cancerScreeningFormViewModel.ColonoscopyQualityCriteriaGridList;
        for (let detailItem of that.cancerScreeningFormViewModel.ColonoscopyQualityCriteriaGridList) {
            let kolonoskopiKaliteKriterleriObjectID = detailItem[i18n("M17707", "KolonoskopiKaliteKriterleri")];
            if (kolonoskopiKaliteKriterleriObjectID != null && (typeof kolonoskopiKaliteKriterleriObjectID === "string")) {
                let kolonoskopiKaliteKriterleri = that.cancerScreeningFormViewModel.SKRSKolonoskopiKaliteKriterleris.find(o => o.ObjectID.toString() === kolonoskopiKaliteKriterleriObjectID.toString());
                 if (kolonoskopiKaliteKriterleri) {
                    detailItem.KolonoskopiKaliteKriterleri = kolonoskopiKaliteKriterleri;
                }
            }
        }
        let sKRSSigmoidoskopiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSSigmoidoskopi"];
        if (sKRSSigmoidoskopiObjectID != null && (typeof sKRSSigmoidoskopiObjectID === "string")) {
            let sKRSSigmoidoskopi = that.cancerScreeningFormViewModel.SKRSSigmoidoskopis.find(o => o.ObjectID.toString() === sKRSSigmoidoskopiObjectID.toString());
             if (sKRSSigmoidoskopi) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSSigmoidoskopi = sKRSSigmoidoskopi;
            }
        }
        let sKRSPapSmearTestiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSPapSmearTesti"];
        if (sKRSPapSmearTestiObjectID != null && (typeof sKRSPapSmearTestiObjectID === "string")) {
            let sKRSPapSmearTesti = that.cancerScreeningFormViewModel.SKRSPapSmearTestis.find(o => o.ObjectID.toString() === sKRSPapSmearTestiObjectID.toString());
             if (sKRSPapSmearTesti) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSPapSmearTesti = sKRSPapSmearTesti;
            }
        }
        let sKRSMamografiSonucuObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSMamografiSonucu"];
        if (sKRSMamografiSonucuObjectID != null && (typeof sKRSMamografiSonucuObjectID === "string")) {
            let sKRSMamografiSonucu = that.cancerScreeningFormViewModel.SKRSMamografiSonucus.find(o => o.ObjectID.toString() === sKRSMamografiSonucuObjectID.toString());
             if (sKRSMamografiSonucu) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSMamografiSonucu = sKRSMamografiSonucu;
            }
        }
        let sKRSMamografiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSMamografi"];
        if (sKRSMamografiObjectID != null && (typeof sKRSMamografiObjectID === "string")) {
            let sKRSMamografi = that.cancerScreeningFormViewModel.SKRSMamografis.find(o => o.ObjectID.toString() === sKRSMamografiObjectID.toString());
             if (sKRSMamografi) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSMamografi = sKRSMamografi;
            }
        }
        let sKRSKolposkopiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSKolposkopi"];
        if (sKRSKolposkopiObjectID != null && (typeof sKRSKolposkopiObjectID === "string")) {
            let sKRSKolposkopi = that.cancerScreeningFormViewModel.SKRSKolposkopis.find(o => o.ObjectID.toString() === sKRSKolposkopiObjectID.toString());
             if (sKRSKolposkopi) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSKolposkopi = sKRSKolposkopi;
            }
        }
        let sKRSKolonoskopininSuresiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSKolonoskopininSuresi"];
        if (sKRSKolonoskopininSuresiObjectID != null && (typeof sKRSKolonoskopininSuresiObjectID === "string")) {
            let sKRSKolonoskopininSuresi = that.cancerScreeningFormViewModel.SKRSKolonoskopininSuresis.find(o => o.ObjectID.toString() === sKRSKolonoskopininSuresiObjectID.toString());
             if (sKRSKolonoskopininSuresi) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSKolonoskopininSuresi = sKRSKolonoskopininSuresi;
            }
        }
        let sKRSKlinikMemeMuayenesiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSKlinikMemeMuayenesi"];
        if (sKRSKlinikMemeMuayenesiObjectID != null && (typeof sKRSKlinikMemeMuayenesiObjectID === "string")) {
            let sKRSKlinikMemeMuayenesi = that.cancerScreeningFormViewModel.SKRSKlinikMemeMuayenesis.find(o => o.ObjectID.toString() === sKRSKlinikMemeMuayenesiObjectID.toString());
             if (sKRSKlinikMemeMuayenesi) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSKlinikMemeMuayenesi = sKRSKlinikMemeMuayenesi;
            }
        }
        let sKRSKendiKendineMemeMuayenesiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSKendiKendineMemeMuayenesi"];
        if (sKRSKendiKendineMemeMuayenesiObjectID != null && (typeof sKRSKendiKendineMemeMuayenesiObjectID === "string")) {
            let sKRSKendiKendineMemeMuayenesi = that.cancerScreeningFormViewModel.SKRSKendiKendineMemeMuayenesis.find(o => o.ObjectID.toString() === sKRSKendiKendineMemeMuayenesiObjectID.toString());
             if (sKRSKendiKendineMemeMuayenesi) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSKendiKendineMemeMuayenesi = sKRSKendiKendineMemeMuayenesi;
            }
        }
        let sKRSHPVTaramaTestiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSHPVTaramaTesti"];
        if (sKRSHPVTaramaTestiObjectID != null && (typeof sKRSHPVTaramaTestiObjectID === "string")) {
            let sKRSHPVTaramaTesti = that.cancerScreeningFormViewModel.SKRSHPVTaramaTestis.find(o => o.ObjectID.toString() === sKRSHPVTaramaTestiObjectID.toString());
             if (sKRSHPVTaramaTesti) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSHPVTaramaTesti = sKRSHPVTaramaTesti;
            }
        }
        let sKRSKolonoskopiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSKolonoskopi"];
        if (sKRSKolonoskopiObjectID != null && (typeof sKRSKolonoskopiObjectID === "string")) {
            let sKRSKolonoskopi = that.cancerScreeningFormViewModel.SKRSKolonoskopis.find(o => o.ObjectID.toString() === sKRSKolonoskopiObjectID.toString());
             if (sKRSKolonoskopi) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSKolonoskopi = sKRSKolonoskopi;
            }
        }
        let sKRSKolonGoruntulemeYontemiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSKolonGoruntulemeYontemi"];
        if (sKRSKolonGoruntulemeYontemiObjectID != null && (typeof sKRSKolonGoruntulemeYontemiObjectID === "string")) {
            let sKRSKolonGoruntulemeYontemi = that.cancerScreeningFormViewModel.SKRSKolonGoruntulemeYontemis.find(o => o.ObjectID.toString() === sKRSKolonGoruntulemeYontemiObjectID.toString());
             if (sKRSKolonGoruntulemeYontemi) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSKolonGoruntulemeYontemi = sKRSKolonGoruntulemeYontemi;
            }
        }
        let sKRSGaitadaGizliKanTestiObjectID = that.cancerScreeningFormViewModel._CancerScreening["SKRSGaitadaGizliKanTesti"];
        if (sKRSGaitadaGizliKanTestiObjectID != null && (typeof sKRSGaitadaGizliKanTestiObjectID === "string")) {
            let sKRSGaitadaGizliKanTesti = that.cancerScreeningFormViewModel.SKRSGaitadaGizliKanTestis.find(o => o.ObjectID.toString() === sKRSGaitadaGizliKanTestiObjectID.toString());
             if (sKRSGaitadaGizliKanTesti) {
                that.cancerScreeningFormViewModel._CancerScreening.SKRSGaitadaGizliKanTesti = sKRSGaitadaGizliKanTesti;
            }
        }
        that.cancerScreeningFormViewModel._CancerScreening.HPVTypeInfo = that.cancerScreeningFormViewModel.HPVTypeInfoGridList;
        for (let detailItem of that.cancerScreeningFormViewModel.HPVTypeInfoGridList) {
            let sKRSHpvTipiObjectID = detailItem["SKRSHpvTipi"];
            if (sKRSHpvTipiObjectID != null && (typeof sKRSHpvTipiObjectID === "string")) {
                let sKRSHpvTipi = that.cancerScreeningFormViewModel.SKRSHpvTipis.find(o => o.ObjectID.toString() === sKRSHpvTipiObjectID.toString());
                 if (sKRSHpvTipi) {
                    detailItem.SKRSHpvTipi = sKRSHpvTipi;
                }
            }
        }

    }

    async ngOnInit() {
        await this.load(CancerScreeningFormViewModel);
    }

    public onSKRSGaitadaGizliKanTestiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.SKRSGaitadaGizliKanTesti != event) {
                this._CancerScreening.SKRSGaitadaGizliKanTesti = event;
            }
        }
    }

    public onSKRSHPVTaramaTestiChanged(event): void {
        if (event != null) {

            if (this.cancerScreeningFormViewModel.IsMale) {
                this.messageService.showError("Erkek hastalarda seçilemez.");
                return;
            }

            if (this._CancerScreening != null && this._CancerScreening.SKRSHPVTaramaTesti != event) {
                this._CancerScreening.SKRSHPVTaramaTesti = event;
            }
        }
    }

    public onSKRSKendiKendineMemeMuayenesiChanged(event): void {

        if (event != null) {

            if (this.cancerScreeningFormViewModel.IsMale) {
                this.messageService.showError("Erkek hastalarda seçilemez.");
                return;
            }

            if (this._CancerScreening != null && this._CancerScreening.SKRSKendiKendineMemeMuayenesi != event) {
                this._CancerScreening.SKRSKendiKendineMemeMuayenesi = event;
            }
        }
    }

    public onSKRSKlinikMemeMuayenesiChanged(event): void {
        if (event != null) {

            if (this.cancerScreeningFormViewModel.IsMale) {
                this.messageService.showError("Erkek hastalarda seçilemez.");
                return;
            }

            if (this._CancerScreening != null && this._CancerScreening.SKRSKlinikMemeMuayenesi != event) {
                this._CancerScreening.SKRSKlinikMemeMuayenesi = event;
            }
        }
    }

    public onSKRSKolonGoruntulemeYontemiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.SKRSKolonGoruntulemeYontemi != event) {
                this._CancerScreening.SKRSKolonGoruntulemeYontemi = event;
            }
        }
    }

    public onSKRSKolonoskopiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.SKRSKolonoskopi != event) {
                this._CancerScreening.SKRSKolonoskopi = event;
            }
        }
    }

    public onSKRSKolonoskopininSuresiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.SKRSKolonoskopininSuresi != event) {
                this._CancerScreening.SKRSKolonoskopininSuresi = event;
            }
        }
    }

    public onSKRSKolposkopiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.SKRSKolposkopi != event) {
                this._CancerScreening.SKRSKolposkopi = event;
            }
        }
    }

    public onSKRSMamografiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.SKRSMamografi != event) {
                this._CancerScreening.SKRSMamografi = event;
            }
        }
    }

    public onSKRSMamografiSonucuChanged(event): void {
        if (event != null) {

            if (this.cancerScreeningFormViewModel.IsMale) {
                this.messageService.showError("Erkek hastalarda seçilemez.");
                return;
            }

            if (this._CancerScreening != null && this._CancerScreening.SKRSMamografiSonucu != event) {
                this._CancerScreening.SKRSMamografiSonucu = event;
            }
        }
    }

    public onSKRSPapSmearTestiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.SKRSPapSmearTesti != event) {
                this._CancerScreening.SKRSPapSmearTesti = event;
            }
        }
    }

    public onSKRSSigmoidoskopiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.SKRSSigmoidoskopi != event) {
                this._CancerScreening.SKRSSigmoidoskopi = event;
            }
        }
    }

    public onSKRSTARAMATIPIChanged(event): void {
        if (event != null) {

            if (this.cancerScreeningFormViewModel.IsMale && event.KODU != "1")
            {
                this.messageService.showError("Erkek hastalarda seçilemez.");
                this._CancerScreening.SKRSTARAMATIPI = new SKRSTARAMATIPI();
                return;
            }

            if (this._CancerScreening != null && this._CancerScreening.SKRSTARAMATIPI != event) {
                this._CancerScreening.SKRSTARAMATIPI = event;
            }
        }
    }

    public onTaramaSonuclanmaTarihiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.TaramaSonuclanmaTarihi != event) {
                this._CancerScreening.TaramaSonuclanmaTarihi = event;
            }
        }
    }

    public onTaramaTarihiChanged(event): void {
        if (event != null) {
            if (this._CancerScreening != null && this._CancerScreening.TaramaTarihi != event) {
                this._CancerScreening.TaramaTarihi = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.TaramaTarihi, "Value", this.__ttObject, "TaramaTarihi");
        redirectProperty(this.TaramaSonuclanmaTarihi, "Value", this.__ttObject, "TaramaSonuclanmaTarihi");
    }

    public initFormControls(): void {
        this.labelSKRSTARAMATIPI = new TTVisual.TTLabel();
        this.labelSKRSTARAMATIPI.Text = "Tarama Tipi";
        this.labelSKRSTARAMATIPI.Name = "labelSKRSTARAMATIPI";
        this.labelSKRSTARAMATIPI.TabIndex = 38;

        this.SKRSTARAMATIPI = new TTVisual.TTObjectListBox();
        this.SKRSTARAMATIPI.ListDefName = "SKRSTARAMATIPIList";
        this.SKRSTARAMATIPI.Name = "SKRSTARAMATIPI";
        this.SKRSTARAMATIPI.TabIndex = 37;
        this.SKRSTARAMATIPI.BackColor = "#ffeee5";

        this.labelTaramaSonuclanmaTarihi = new TTVisual.TTLabel();
        this.labelTaramaSonuclanmaTarihi.Text = "Tarama Sonuçlanma Tarihi";
        this.labelTaramaSonuclanmaTarihi.Name = "labelTaramaSonuclanmaTarihi";
        this.labelTaramaSonuclanmaTarihi.TabIndex = 36;

        this.TaramaSonuclanmaTarihi = new TTVisual.TTDateTimePicker();
        this.TaramaSonuclanmaTarihi.Format = DateTimePickerFormat.Long;
        this.TaramaSonuclanmaTarihi.Name = "TaramaSonuclanmaTarihi";
        this.TaramaSonuclanmaTarihi.TabIndex = 35;

        this.labelTaramaTarihi = new TTVisual.TTLabel();
        this.labelTaramaTarihi.Text = "Tarama Tarihi";
        this.labelTaramaTarihi.Name = "labelTaramaTarihi";
        this.labelTaramaTarihi.TabIndex = 34;

        this.TaramaTarihi = new TTVisual.TTDateTimePicker();
        this.TaramaTarihi.Format = DateTimePickerFormat.Long;
        this.TaramaTarihi.Name = "TaramaTarihi";
        this.TaramaTarihi.TabIndex = 33;

        this.BreastBiopsy = new TTVisual.TTGrid();
        this.BreastBiopsy.Name = "BreastBiopsy";
        this.BreastBiopsy.TabIndex = 32;
        this.BreastBiopsy.DeleteButtonWidth= "15%";

        this.SKRSMemedenBiyopsiAlimiBreastBiopsy = new TTVisual.TTListBoxColumn();
        this.SKRSMemedenBiyopsiAlimiBreastBiopsy.ListDefName = "SKRSMemedenBiyopsiAlimiList";
        this.SKRSMemedenBiyopsiAlimiBreastBiopsy.DataMember = "SKRSMemedenBiyopsiAlimi";
        this.SKRSMemedenBiyopsiAlimiBreastBiopsy.DisplayIndex = 0;
        this.SKRSMemedenBiyopsiAlimiBreastBiopsy.HeaderText = i18n("M18870", "Memeden Biyopsi Alımı");
        this.SKRSMemedenBiyopsiAlimiBreastBiopsy.Name = "SKRSMemedenBiyopsiAlimiBreastBiopsy";
        this.SKRSMemedenBiyopsiAlimiBreastBiopsy.Width = 125;

        this.SKRSMemeBiyopsiSonucuBreastBiopsy = new TTVisual.TTListBoxColumn();
        this.SKRSMemeBiyopsiSonucuBreastBiopsy.ListDefName = "SKRSMemeBiyopsiSonucuList";
        this.SKRSMemeBiyopsiSonucuBreastBiopsy.DataMember = "SKRSMemeBiyopsiSonucu";
        this.SKRSMemeBiyopsiSonucuBreastBiopsy.DisplayIndex = 1;
        this.SKRSMemeBiyopsiSonucuBreastBiopsy.HeaderText = i18n("M18863", "Meme Biyopsi Sonucu");
        this.SKRSMemeBiyopsiSonucuBreastBiopsy.Name = "SKRSMemeBiyopsiSonucuBreastBiopsy";
        this.SKRSMemeBiyopsiSonucuBreastBiopsy.Width = 125;

        this.CervicalCytologyResults = new TTVisual.TTGrid();
        this.CervicalCytologyResults.Name = "CervicalCytologyResults";
        this.CervicalCytologyResults.TabIndex = 31;
        this.CervicalCytologyResults.DeleteButtonWidth = "15%";

        this.SKRSServikalSitolojiSonucuCervicalCytologyResults = new TTVisual.TTListBoxColumn();
        this.SKRSServikalSitolojiSonucuCervicalCytologyResults.ListDefName = "SKRSServikalSitolojiSonucuList";
        this.SKRSServikalSitolojiSonucuCervicalCytologyResults.DataMember = "SKRSServikalSitolojiSonucu";
        this.SKRSServikalSitolojiSonucuCervicalCytologyResults.DisplayIndex = 0;
        this.SKRSServikalSitolojiSonucuCervicalCytologyResults.HeaderText = i18n("M21659", "Servikal Sitoloji Sonucu");
        this.SKRSServikalSitolojiSonucuCervicalCytologyResults.Name = "SKRSServikalSitolojiSonucuCervicalCytologyResults";
        this.SKRSServikalSitolojiSonucuCervicalCytologyResults.Width = 250;

        this.CervicalBiopsyResults = new TTVisual.TTGrid();
        this.CervicalBiopsyResults.Name = "CervicalBiopsyResults";
        this.CervicalBiopsyResults.TabIndex = 30;
        this.CervicalBiopsyResults.DeleteButtonWidth= "15%";

        this.SKRSServikalBiyopsiSonucuCervicalBiopsyResults = new TTVisual.TTListBoxColumn();
        this.SKRSServikalBiyopsiSonucuCervicalBiopsyResults.ListDefName = "SKRSServikalBiyopsiSonucuList";
        this.SKRSServikalBiyopsiSonucuCervicalBiopsyResults.DataMember = "SKRSServikalBiyopsiSonucu";
        this.SKRSServikalBiyopsiSonucuCervicalBiopsyResults.DisplayIndex = 0;
        this.SKRSServikalBiyopsiSonucuCervicalBiopsyResults.HeaderText = i18n("M21658", "Servikal Biyopsi Sonucu");
        this.SKRSServikalBiyopsiSonucuCervicalBiopsyResults.Name = "SKRSServikalBiyopsiSonucuCervicalBiopsyResults";
        this.SKRSServikalBiyopsiSonucuCervicalBiopsyResults.Width = 250;

        this.ColorectalBiopsyResults = new TTVisual.TTGrid();
        this.ColorectalBiopsyResults.Name = "ColorectalBiopsyResults";
        this.ColorectalBiopsyResults.TabIndex = 28;
        this.ColorectalBiopsyResults.DeleteButtonWidth= "15%";

        this.SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults = new TTVisual.TTListBoxColumn();
        this.SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults.ListDefName = "SKRSKolorektalBiyopsiSonucuList";
        this.SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults.DataMember = "SKRSKolorektalBiyopsiSonucu";
        this.SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults.DisplayIndex = 0;
        this.SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults.HeaderText = i18n("M17709", "Kolorektal Biyopsi Sonucu");
        this.SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults.Name = "SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults";
        this.SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults.Width = 250;

        this.ColonoscopyQualityCriteria = new TTVisual.TTGrid();
        this.ColonoscopyQualityCriteria.Name = "ColonoscopyQualityCriteria";
        this.ColonoscopyQualityCriteria.TabIndex = 27;
        this.ColonoscopyQualityCriteria.DeleteButtonWidth = "15%";

        this.KolonoskopiKaliteKriterleriColonoscopyQualityCriteria = new TTVisual.TTListBoxColumn();
        this.KolonoskopiKaliteKriterleriColonoscopyQualityCriteria.ListDefName = "SKRSKolonoskopiKaliteKriterleriList";
        this.KolonoskopiKaliteKriterleriColonoscopyQualityCriteria.DataMember = i18n("M17707", "KolonoskopiKaliteKriterleri");
        this.KolonoskopiKaliteKriterleriColonoscopyQualityCriteria.DisplayIndex = 0;
        this.KolonoskopiKaliteKriterleriColonoscopyQualityCriteria.HeaderText = i18n("M17706", "Kolonoskopi Kalite Kriterleri");
        this.KolonoskopiKaliteKriterleriColonoscopyQualityCriteria.Name = "KolonoskopiKaliteKriterleriColonoscopyQualityCriteria";
        this.KolonoskopiKaliteKriterleriColonoscopyQualityCriteria.Width = 250;

        this.labelSKRSSigmoidoskopi = new TTVisual.TTLabel();
        this.labelSKRSSigmoidoskopi.Text = "Sigmoidoskopi";
        this.labelSKRSSigmoidoskopi.Name = "labelSKRSSigmoidoskopi";
        this.labelSKRSSigmoidoskopi.TabIndex = 26;

        this.SKRSSigmoidoskopi = new TTVisual.TTObjectListBox();
        this.SKRSSigmoidoskopi.ListDefName = "SKRSSigmoidoskopiList";
        this.SKRSSigmoidoskopi.Name = "SKRSSigmoidoskopi";
        this.SKRSSigmoidoskopi.TabIndex = 25;

        this.labelSKRSPapSmearTesti = new TTVisual.TTLabel();
        this.labelSKRSPapSmearTesti.Text = i18n("M20187", "Pap Smear Testi");
        this.labelSKRSPapSmearTesti.Name = "labelSKRSPapSmearTesti";
        this.labelSKRSPapSmearTesti.TabIndex = 24;

        this.SKRSPapSmearTesti = new TTVisual.TTObjectListBox();
        this.SKRSPapSmearTesti.ListDefName = "SKRSPapSmearTestiList";
        this.SKRSPapSmearTesti.Name = "SKRSPapSmearTesti";
        this.SKRSPapSmearTesti.TabIndex = 23;

        this.labelSKRSMamografiSonucu = new TTVisual.TTLabel();
        this.labelSKRSMamografiSonucu.Text = i18n("M18660", "Mamografi Sonucu");
        this.labelSKRSMamografiSonucu.Name = "labelSKRSMamografiSonucu";
        this.labelSKRSMamografiSonucu.TabIndex = 22;

        this.SKRSMamografiSonucu = new TTVisual.TTObjectListBox();
        this.SKRSMamografiSonucu.ListDefName = "SKRSMamografiSonucuList";
        this.SKRSMamografiSonucu.Name = "SKRSMamografiSonucu";
        this.SKRSMamografiSonucu.TabIndex = 21;

        this.labelSKRSMamografi = new TTVisual.TTLabel();
        this.labelSKRSMamografi.Text = i18n("M18658", "Mamografi");
        this.labelSKRSMamografi.Name = "labelSKRSMamografi";
        this.labelSKRSMamografi.TabIndex = 20;

        this.SKRSMamografi = new TTVisual.TTObjectListBox();
        this.SKRSMamografi.ListDefName = "SKRSMamografiList";
        this.SKRSMamografi.Name = "SKRSMamografi";
        this.SKRSMamografi.TabIndex = 19;

        this.labelSKRSKolposkopi = new TTVisual.TTLabel();
        this.labelSKRSKolposkopi.Text = i18n("M17710", "Kolposkopi");
        this.labelSKRSKolposkopi.Name = "labelSKRSKolposkopi";
        this.labelSKRSKolposkopi.TabIndex = 18;

        this.SKRSKolposkopi = new TTVisual.TTObjectListBox();
        this.SKRSKolposkopi.ListDefName = "SKRSKolposkopiList";
        this.SKRSKolposkopi.Name = "SKRSKolposkopi";
        this.SKRSKolposkopi.TabIndex = 17;

        this.labelSKRSKolonoskopininSuresi = new TTVisual.TTLabel();
        this.labelSKRSKolonoskopininSuresi.Text = i18n("M17708", "Kolonoskopinin Süresi");
        this.labelSKRSKolonoskopininSuresi.Name = "labelSKRSKolonoskopininSuresi";
        this.labelSKRSKolonoskopininSuresi.TabIndex = 16;

        this.SKRSKolonoskopininSuresi = new TTVisual.TTObjectListBox();
        this.SKRSKolonoskopininSuresi.ListDefName = "SKRSKolonoskopininSuresiList";
        this.SKRSKolonoskopininSuresi.Name = "SKRSKolonoskopininSuresi";
        this.SKRSKolonoskopininSuresi.TabIndex = 15;

        this.labelSKRSKlinikMemeMuayenesi = new TTVisual.TTLabel();
        this.labelSKRSKlinikMemeMuayenesi.Text = i18n("M17642", "Klinik Meme Muayenesi");
        this.labelSKRSKlinikMemeMuayenesi.Name = "labelSKRSKlinikMemeMuayenesi";
        this.labelSKRSKlinikMemeMuayenesi.TabIndex = 14;

        this.SKRSKlinikMemeMuayenesi = new TTVisual.TTObjectListBox();
        this.SKRSKlinikMemeMuayenesi.ListDefName = "SKRSKlinikMemeMuayenesiList";
        this.SKRSKlinikMemeMuayenesi.Name = "SKRSKlinikMemeMuayenesi";
        this.SKRSKlinikMemeMuayenesi.TabIndex = 13;

        this.labelSKRSKendiKendineMemeMuayenesi = new TTVisual.TTLabel();
        this.labelSKRSKendiKendineMemeMuayenesi.Text = i18n("M17482", "Kendi Kendine Meme Muayenesi");
        this.labelSKRSKendiKendineMemeMuayenesi.Name = "labelSKRSKendiKendineMemeMuayenesi";
        this.labelSKRSKendiKendineMemeMuayenesi.TabIndex = 12;

        this.SKRSKendiKendineMemeMuayenesi = new TTVisual.TTObjectListBox();
        this.SKRSKendiKendineMemeMuayenesi.ListDefName = "SKRSKendiKendineMemeMuayenesiList";
        this.SKRSKendiKendineMemeMuayenesi.Name = "SKRSKendiKendineMemeMuayenesi";
        this.SKRSKendiKendineMemeMuayenesi.TabIndex = 11;

        this.labelSKRSHPVTaramaTesti = new TTVisual.TTLabel();
        this.labelSKRSHPVTaramaTesti.Text = i18n("M15964", "HPV Tarama Testi");
        this.labelSKRSHPVTaramaTesti.Name = "labelSKRSHPVTaramaTesti";
        this.labelSKRSHPVTaramaTesti.TabIndex = 10;

        this.SKRSHPVTaramaTesti = new TTVisual.TTObjectListBox();
        this.SKRSHPVTaramaTesti.ListDefName = "SKRSHPVTaramaTestiList";
        this.SKRSHPVTaramaTesti.Name = "SKRSHPVTaramaTesti";
        this.SKRSHPVTaramaTesti.TabIndex = 9;

        this.labelSKRSKolonoskopi = new TTVisual.TTLabel();
        this.labelSKRSKolonoskopi.Text = i18n("M17705", "Kolonoskopi");
        this.labelSKRSKolonoskopi.Name = "labelSKRSKolonoskopi";
        this.labelSKRSKolonoskopi.TabIndex = 8;

        this.SKRSKolonoskopi = new TTVisual.TTObjectListBox();
        this.SKRSKolonoskopi.ListDefName = "SKRSKolonoskopiList";
        this.SKRSKolonoskopi.Name = "SKRSKolonoskopi";
        this.SKRSKolonoskopi.TabIndex = 7;

        this.labelSKRSKolonGoruntulemeYontemi = new TTVisual.TTLabel();
        this.labelSKRSKolonGoruntulemeYontemi.Text = i18n("M17703", "Kolon Görüntüleme Yöntemi");
        this.labelSKRSKolonGoruntulemeYontemi.Name = "labelSKRSKolonGoruntulemeYontemi";
        this.labelSKRSKolonGoruntulemeYontemi.TabIndex = 6;

        this.SKRSKolonGoruntulemeYontemi = new TTVisual.TTObjectListBox();
        this.SKRSKolonGoruntulemeYontemi.ListDefName = "SKRSKolonGoruntulemeYontemiList";
        this.SKRSKolonGoruntulemeYontemi.Name = "SKRSKolonGoruntulemeYontemi";
        this.SKRSKolonGoruntulemeYontemi.TabIndex = 5;

        this.labelSKRSGaitadaGizliKanTesti = new TTVisual.TTLabel();
        this.labelSKRSGaitadaGizliKanTesti.Text = i18n("M14506", "Gaitada Gizli Kan Testi");
        this.labelSKRSGaitadaGizliKanTesti.Name = "labelSKRSGaitadaGizliKanTesti";
        this.labelSKRSGaitadaGizliKanTesti.TabIndex = 2;

        this.SKRSGaitadaGizliKanTesti = new TTVisual.TTObjectListBox();
        this.SKRSGaitadaGizliKanTesti.ListDefName = "SKRSGaitadaGizliKanTestiList";
        this.SKRSGaitadaGizliKanTesti.Name = "SKRSGaitadaGizliKanTesti";
        this.SKRSGaitadaGizliKanTesti.TabIndex = 1;

        this.HPVTypeInfo = new TTVisual.TTGrid();
        this.HPVTypeInfo.Name = "HPVTypeInfo";
        this.HPVTypeInfo.TabIndex = 0;
        this.HPVTypeInfo.DeleteButtonWidth = "15%"

        this.SKRSHpvTipiHPVTypeInfo = new TTVisual.TTListBoxColumn();
        this.SKRSHpvTipiHPVTypeInfo.ListDefName = "SKRSHpvTipiList";
        this.SKRSHpvTipiHPVTypeInfo.DataMember = "SKRSHpvTipi";
        this.SKRSHpvTipiHPVTypeInfo.DisplayIndex = 0;
        this.SKRSHpvTipiHPVTypeInfo.HeaderText = i18n("M15965", "Hpv Tipi");
        this.SKRSHpvTipiHPVTypeInfo.Name = "SKRSHpvTipiHPVTypeInfo";
        this.SKRSHpvTipiHPVTypeInfo.Width = 250;
   
        this.BreastBiopsyColumns = [this.SKRSMemedenBiyopsiAlimiBreastBiopsy, this.SKRSMemeBiyopsiSonucuBreastBiopsy];
        this.CervicalCytologyResultsColumns = [this.SKRSServikalSitolojiSonucuCervicalCytologyResults];
        this.CervicalBiopsyResultsColumns = [this.SKRSServikalBiyopsiSonucuCervicalBiopsyResults];
        this.ColorectalBiopsyResultsColumns = [this.SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults];
        this.ColonoscopyQualityCriteriaColumns = [this.KolonoskopiKaliteKriterleriColonoscopyQualityCriteria];
        this.HPVTypeInfoColumns = [this.SKRSHpvTipiHPVTypeInfo];
        this.Controls = [this.labelSKRSTARAMATIPI, this.SKRSTARAMATIPI, this.labelTaramaSonuclanmaTarihi, this.TaramaSonuclanmaTarihi, this.labelTaramaTarihi, this.TaramaTarihi, this.BreastBiopsy, this.SKRSMemedenBiyopsiAlimiBreastBiopsy, this.SKRSMemeBiyopsiSonucuBreastBiopsy, this.CervicalCytologyResults, this.SKRSServikalSitolojiSonucuCervicalCytologyResults, this.CervicalBiopsyResults, this.SKRSServikalBiyopsiSonucuCervicalBiopsyResults, this.ColorectalBiopsyResults, this.SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults, this.ColonoscopyQualityCriteria, this.KolonoskopiKaliteKriterleriColonoscopyQualityCriteria, this.labelSKRSSigmoidoskopi, this.SKRSSigmoidoskopi, this.labelSKRSPapSmearTesti, this.SKRSPapSmearTesti, this.labelSKRSMamografiSonucu, this.SKRSMamografiSonucu, this.labelSKRSMamografi, this.SKRSMamografi, this.labelSKRSKolposkopi, this.SKRSKolposkopi, this.labelSKRSKolonoskopininSuresi, this.SKRSKolonoskopininSuresi, this.labelSKRSKlinikMemeMuayenesi, this.SKRSKlinikMemeMuayenesi, this.labelSKRSKendiKendineMemeMuayenesi, this.SKRSKendiKendineMemeMuayenesi, this.labelSKRSHPVTaramaTesti, this.SKRSHPVTaramaTesti, this.labelSKRSKolonoskopi, this.SKRSKolonoskopi, this.labelSKRSKolonGoruntulemeYontemi, this.SKRSKolonGoruntulemeYontemi, this.labelSKRSGaitadaGizliKanTesti, this.SKRSGaitadaGizliKanTesti, this.HPVTypeInfo, this.SKRSHpvTipiHPVTypeInfo];

    }

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        if (this.cancerScreeningFormViewModel._CancerScreening.SKRSTARAMATIPI == null)
            throw new Exception("Lütfen Tarama Tipini Seçiniz.");
    }

    printCancerScreeningForm() {

        let reportData: DynamicReportParameters = {

            Code: 'TOPLUMTABANLIKANSERTARAMA',
            ReportParams: { ObjectID: this._CancerScreening.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "TOPLUM TABANLI KANSER TARAMA FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

}
