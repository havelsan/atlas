//$4DDB4EAB
import { Component, OnInit, NgZone } from '@angular/core';
import { BulasiciHastaliklarNewFormViewModel } from './BulasiciHastaliklarNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BulasiciHastalikVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { BulasiciHastalikTelefon } from 'NebulaClient/Model/AtlasClientModel';
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
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'BulasiciHastaliklarNewForm',
    templateUrl: './BulasiciHastaliklarNewForm.html',
    providers: [MessageService]
})
export class BulasiciHastaliklarNewForm extends TTVisual.TTForm implements OnInit {
    BelirtilerinBaslamaTarihi: TTVisual.ITTDateTimePicker;
    Beyan_Bucak: TTVisual.ITTObjectListBox;
    Beyan_CSBM: TTVisual.ITTObjectListBox;
    Beyan_Il: TTVisual.ITTObjectListBox;
    Beyan_Ilce: TTVisual.ITTObjectListBox;
    Beyan_Koy: TTVisual.ITTObjectListBox;
    Beyan_Mahalle: TTVisual.ITTObjectListBox;
    BulasiciHastalikTelefon: TTVisual.ITTGrid;
    DisKapiNoBeyan: TTVisual.ITTTextBox;
    DisKapiNoIkamet: TTVisual.ITTTextBox;
    IcKapiNoBeyan: TTVisual.ITTTextBox;
    IcKapiNoIkamet: TTVisual.ITTTextBox;
    Ikamet_Bucak: TTVisual.ITTObjectListBox;
    Ikamet_CSBM: TTVisual.ITTObjectListBox;
    Ikamet_Il: TTVisual.ITTObjectListBox;
    Ikamet_Ilce: TTVisual.ITTObjectListBox;
    Ikamet_Koy: TTVisual.ITTObjectListBox;
    Ikamet_Mahalle: TTVisual.ITTObjectListBox;
    labelBelirtilerinBaslamaTarihi: TTVisual.ITTLabel;
    labelBeyan_Bucak: TTVisual.ITTLabel;
    labelBeyan_CSBM: TTVisual.ITTLabel;
    labelBeyan_Il: TTVisual.ITTLabel;
    labelBeyan_Ilce: TTVisual.ITTLabel;
    labelBeyan_Koy: TTVisual.ITTLabel;
    labelBeyan_Mahalle: TTVisual.ITTLabel;
    labelDisKapiNoBeyan: TTVisual.ITTLabel;
    labelDisKapiNoIkamet: TTVisual.ITTLabel;
    labelIcKapiNoBeyan: TTVisual.ITTLabel;
    labelIcKapiNoIkamet: TTVisual.ITTLabel;
    labelIkamet_Bucak: TTVisual.ITTLabel;
    labelIkamet_CSBM: TTVisual.ITTLabel;
    labelIkamet_Il: TTVisual.ITTLabel;
    labelIkamet_Ilce: TTVisual.ITTLabel;
    labelIkamet_Koy: TTVisual.ITTLabel;
    labelIkamet_Mahalle: TTVisual.ITTLabel;
    labelPaketeAitIslemZamani: TTVisual.ITTLabel;
    labelResponsibleDoctor: TTVisual.ITTLabel;
    labelSKRSICD: TTVisual.ITTLabel;
    labelSKRSVakaTipi: TTVisual.ITTLabel;
    labelVakaDurum: TTVisual.ITTLabel;
    PaketeAitIslemZamani: TTVisual.ITTDateTimePicker;
    ResponsibleDoctor: TTVisual.ITTObjectListBox;
    SKRSICD: TTVisual.ITTObjectListBox;
    SKRSTelefonTipiBulasiciHastalikTelefon: TTVisual.ITTListBoxColumn;
    SKRSVakaTipi: TTVisual.ITTObjectListBox;
    TelefonNumarasiBulasiciHastalikTelefon: TTVisual.ITTTextBoxColumn;
    RouteData: any;
    RouteData2: any;
    VakaDurum: TTVisual.ITTEnumComboBox;
    public BulasiciHastalikTelefonColumns = [];
    public telefonTipiArray: Array<any> = [];
    public TelefonTipiCache: any;
    public bulasiciHastaliklarNewFormViewModel: BulasiciHastaliklarNewFormViewModel = new BulasiciHastaliklarNewFormViewModel();
    public get _BulasiciHastalikVeriSeti(): BulasiciHastalikVeriSeti {
        return this._TTObject as BulasiciHastalikVeriSeti;
    }
    private BulasiciHastaliklarNewForm_DocumentUrl: string = '/api/BulasiciHastalikVeriSetiService/BulasiciHastaliklarNewForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('BULASICIHASTALIKVERISETI', 'BulasiciHastaliklarNewForm');
        this._DocumentServiceUrl = this.BulasiciHastaliklarNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BulasiciHastalikVeriSeti();
        this.bulasiciHastaliklarNewFormViewModel = new BulasiciHastaliklarNewFormViewModel();
        this._ViewModel = this.bulasiciHastaliklarNewFormViewModel;
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti = this._TTObject as BulasiciHastalikVeriSeti;
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.BulasiciHastalikTelefon = new Array<BulasiciHastalikTelefon>();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_CSBM = new SKRSCSBMTipi();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_CSBM = new SKRSCSBMTipi();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Mahalle = new SKRSMahalleKodlari();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Mahalle = new SKRSMahalleKodlari();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Koy = new SKRSKoyKodlari();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Koy = new SKRSKoyKodlari();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Bucak = new SKRSBucakKodlari();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Bucak = new SKRSBucakKodlari();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.ResponsibleDoctor = new ResUser();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.SKRSICD = new SKRSICD();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.SKRSVakaTipi = new SKRSVakaTipi();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Ilce = new SKRSIlceKodlari();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Ilce = new SKRSIlceKodlari();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Il = new SKRSILKodlari();
        this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Il = new SKRSILKodlari();
    }

    protected loadViewModel() {
        let that = this;

        that.bulasiciHastaliklarNewFormViewModel = this._ViewModel as BulasiciHastaliklarNewFormViewModel;
        that._TTObject = this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti;
        if (this.bulasiciHastaliklarNewFormViewModel == null)
            this.bulasiciHastaliklarNewFormViewModel = new BulasiciHastaliklarNewFormViewModel();
        if (this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti == null)
            this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti = new BulasiciHastalikVeriSeti();
        that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.BulasiciHastalikTelefon = that.bulasiciHastaliklarNewFormViewModel.BulasiciHastalikTelefonGridList;
        for (let detailItem of that.bulasiciHastaliklarNewFormViewModel.BulasiciHastalikTelefonGridList) {
            let sKRSTelefonTipiObjectID = detailItem["SKRSTelefonTipi"];
            if (sKRSTelefonTipiObjectID != null && (typeof sKRSTelefonTipiObjectID === "string")) {
                let sKRSTelefonTipi = that.bulasiciHastaliklarNewFormViewModel.SKRSTelefonTipis.find(o => o.ObjectID.toString() === sKRSTelefonTipiObjectID.toString());
                 if (sKRSTelefonTipi) {
                    detailItem.SKRSTelefonTipi = sKRSTelefonTipi;
                }
            }
        }
        let beyan_CSBMObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Beyan_CSBM"];
        if (beyan_CSBMObjectID != null && (typeof beyan_CSBMObjectID === "string")) {
            let beyan_CSBM = that.bulasiciHastaliklarNewFormViewModel.SKRSCSBMTipis.find(o => o.ObjectID.toString() === beyan_CSBMObjectID.toString());
             if (beyan_CSBM) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_CSBM = beyan_CSBM;
            }
        }
        let ikamet_CSBMObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Ikamet_CSBM"];
        if (ikamet_CSBMObjectID != null && (typeof ikamet_CSBMObjectID === "string")) {
            let ikamet_CSBM = that.bulasiciHastaliklarNewFormViewModel.SKRSCSBMTipis.find(o => o.ObjectID.toString() === ikamet_CSBMObjectID.toString());
             if (ikamet_CSBM) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_CSBM = ikamet_CSBM;
            }
        }
        let beyan_MahalleObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Beyan_Mahalle"];
        if (beyan_MahalleObjectID != null && (typeof beyan_MahalleObjectID === "string")) {
            let beyan_Mahalle = that.bulasiciHastaliklarNewFormViewModel.SKRSMahalleKodlaris.find(o => o.ObjectID.toString() === beyan_MahalleObjectID.toString());
             if (beyan_Mahalle) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Mahalle = beyan_Mahalle;
            }
        }
        let ikamet_MahalleObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Ikamet_Mahalle"];
        if (ikamet_MahalleObjectID != null && (typeof ikamet_MahalleObjectID === "string")) {
            let ikamet_Mahalle = that.bulasiciHastaliklarNewFormViewModel.SKRSMahalleKodlaris.find(o => o.ObjectID.toString() === ikamet_MahalleObjectID.toString());
             if (ikamet_Mahalle) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Mahalle = ikamet_Mahalle;
            }
        }
        let beyan_KoyObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Beyan_Koy"];
        if (beyan_KoyObjectID != null && (typeof beyan_KoyObjectID === "string")) {
            let beyan_Koy = that.bulasiciHastaliklarNewFormViewModel.SKRSKoyKodlaris.find(o => o.ObjectID.toString() === beyan_KoyObjectID.toString());
             if (beyan_Koy) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Koy = beyan_Koy;
            }
        }
        let ikamet_KoyObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Ikamet_Koy"];
        if (ikamet_KoyObjectID != null && (typeof ikamet_KoyObjectID === "string")) {
            let ikamet_Koy = that.bulasiciHastaliklarNewFormViewModel.SKRSKoyKodlaris.find(o => o.ObjectID.toString() === ikamet_KoyObjectID.toString());
             if (ikamet_Koy) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Koy = ikamet_Koy;
            }
        }
        let beyan_BucakObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Beyan_Bucak"];
        if (beyan_BucakObjectID != null && (typeof beyan_BucakObjectID === "string")) {
            let beyan_Bucak = that.bulasiciHastaliklarNewFormViewModel.SKRSBucakKodlaris.find(o => o.ObjectID.toString() === beyan_BucakObjectID.toString());
             if (beyan_Bucak) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Bucak = beyan_Bucak;
            }
        }
        let ikamet_BucakObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Ikamet_Bucak"];
        if (ikamet_BucakObjectID != null && (typeof ikamet_BucakObjectID === "string")) {
            let ikamet_Bucak = that.bulasiciHastaliklarNewFormViewModel.SKRSBucakKodlaris.find(o => o.ObjectID.toString() === ikamet_BucakObjectID.toString());
             if (ikamet_Bucak) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Bucak = ikamet_Bucak;
            }
        }
        let responsibleDoctorObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["ResponsibleDoctor"];
        if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === "string")) {
            let responsibleDoctor = that.bulasiciHastaliklarNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
             if (responsibleDoctor) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.ResponsibleDoctor = responsibleDoctor;
            }
        }
        let sKRSICDObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["SKRSICD"];
        if (sKRSICDObjectID != null && (typeof sKRSICDObjectID === "string")) {
            let sKRSICD = that.bulasiciHastaliklarNewFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === sKRSICDObjectID.toString());
             if (sKRSICD) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.SKRSICD = sKRSICD;
            }
        }
        let sKRSVakaTipiObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["SKRSVakaTipi"];
        if (sKRSVakaTipiObjectID != null && (typeof sKRSVakaTipiObjectID === "string")) {
            let sKRSVakaTipi = that.bulasiciHastaliklarNewFormViewModel.SKRSVakaTipis.find(o => o.ObjectID.toString() === sKRSVakaTipiObjectID.toString());
             if (sKRSVakaTipi) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.SKRSVakaTipi = sKRSVakaTipi;
            }
        }
        let beyan_IlceObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Beyan_Ilce"];
        if (beyan_IlceObjectID != null && (typeof beyan_IlceObjectID === "string")) {
            let beyan_Ilce = that.bulasiciHastaliklarNewFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === beyan_IlceObjectID.toString());
             if (beyan_Ilce) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Ilce = beyan_Ilce;
            }
        }
        let ikamet_IlceObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Ikamet_Ilce"];
        if (ikamet_IlceObjectID != null && (typeof ikamet_IlceObjectID === "string")) {
            let ikamet_Ilce = that.bulasiciHastaliklarNewFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === ikamet_IlceObjectID.toString());
             if (ikamet_Ilce) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Ilce = ikamet_Ilce;
            }
        }
        let beyan_IlObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Beyan_Il"];
        if (beyan_IlObjectID != null && (typeof beyan_IlObjectID === "string")) {
            let beyan_Il = that.bulasiciHastaliklarNewFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === beyan_IlObjectID.toString());
             if (beyan_Il) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Il = beyan_Il;
            }
        }
        let ikamet_IlObjectID = that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti["Ikamet_Il"];
        if (ikamet_IlObjectID != null && (typeof ikamet_IlObjectID === "string")) {
            let ikamet_Il = that.bulasiciHastaliklarNewFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === ikamet_IlObjectID.toString());
             if (ikamet_Il) {
                that.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Il = ikamet_Il;
            }
        }

    }

    async ngOnInit()  {
        let that = this;

        if (this.RouteData2 != null){
            this.ObjectID = this.RouteData2.ObjectID;
            this.ActiveIDsModel = new ActiveIDsModel(this.RouteData2.EpisodeActionID, null, null);
       
        }


        that.telefonTipiArray = await this.TelefonTipi();
        that.GenerateTelListColumns();
        await this.load(BulasiciHastaliklarNewFormViewModel);
  
    }


    public onBelirtilerinBaslamaTarihiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi != event) {
                this._BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi = event;
            }
        }
    }

    public onBeyan_BucakChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Beyan_Bucak != event) {
                this._BulasiciHastalikVeriSeti.Beyan_Bucak = event;
            }

        }
        this.triggerLoadChildComboBoxByBUCAK(event);
    }

    private triggerLoadChildComboBoxByBUCAK(BUCAK): void {

        if (BUCAK != null) {

            this.Beyan_Koy.ListFilterExpression = " THIS.BUCAKKODU= '" + BUCAK.KODU.toString() + "'";

        }
        else {
            this.Beyan_Koy.ListFilterExpression = " ";
        }

        this._BulasiciHastalikVeriSeti.Beyan_Koy = null;
        this._BulasiciHastalikVeriSeti.Beyan_Mahalle = null;

    }

    public onBeyan_CSBMChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Beyan_CSBM != event) {
                this._BulasiciHastalikVeriSeti.Beyan_CSBM = event;
            }
        }
    }

    public onBeyan_IlceChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Beyan_Ilce != event) {
                this._BulasiciHastalikVeriSeti.Beyan_Ilce = event;
            }


        }
        this.triggerLoadChildComboBoxByILCE(event);
    }

    private triggerLoadChildComboBoxByILCE(ILCE): void {

        if (ILCE != null) {

            this.Beyan_Bucak.ListFilterExpression = " THIS.ILCEKODU= '" + ILCE.KODU.toString() + "'";

        }
        else {
            this.Beyan_Bucak.ListFilterExpression = " ";
        }


        this._BulasiciHastalikVeriSeti.Beyan_Bucak = null;
        this._BulasiciHastalikVeriSeti.Beyan_Koy = null;
        this._BulasiciHastalikVeriSeti.Beyan_Mahalle = null;

    }

    public onBeyan_IlChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Beyan_Il != event) {
                this._BulasiciHastalikVeriSeti.Beyan_Il = event;
            }

        }
        this.triggerLoadChildComboBoxByIL(event);


    }

    private triggerLoadChildComboBoxByIL(IL): void {

        if (IL != null) {

            this.Beyan_Ilce.ListFilterExpression = " THIS.ILKODU= '" + IL.KODU.toString() + "'";

        }
        else {
            this.Beyan_Ilce.ListFilterExpression = " ";
        }

        this._BulasiciHastalikVeriSeti.Beyan_Ilce = null;
        this._BulasiciHastalikVeriSeti.Beyan_Bucak = null;
        this._BulasiciHastalikVeriSeti.Beyan_Koy = null;
        this._BulasiciHastalikVeriSeti.Beyan_Mahalle = null;

    }

    public onBeyan_KoyChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Beyan_Koy != event) {
                this._BulasiciHastalikVeriSeti.Beyan_Koy = event;
            }
        }
        this.triggerLoadChildComboBoxByKOY(event);
    }

    private triggerLoadChildComboBoxByKOY(KOY): void {

        if (KOY != null) {

            this.Beyan_Mahalle.ListFilterExpression = " THIS.KOYKODU= '" + KOY.KODU.toString() + "'";

        }
        else {
            this.Beyan_Mahalle.ListFilterExpression = " ";
        }


        this._BulasiciHastalikVeriSeti.Beyan_Mahalle = null;

    }

    public onBeyan_MahalleChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Beyan_Mahalle != event) {
                this._BulasiciHastalikVeriSeti.Beyan_Mahalle = event;
            }
        }
    }

    public onDisKapiNoBeyanChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.DisKapiNoBeyan != event) {
                this._BulasiciHastalikVeriSeti.DisKapiNoBeyan = event;
            }
        }
    }

    public onDisKapiNoIkametChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.DisKapiNoIkamet != event) {
                this._BulasiciHastalikVeriSeti.DisKapiNoIkamet = event;
            }
        }
    }

    public onIcKapiNoBeyanChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.IcKapiNoBeyan != event) {
                this._BulasiciHastalikVeriSeti.IcKapiNoBeyan = event;
            }
        }
    }

    public onIcKapiNoIkametChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.IcKapiNoIkamet != event) {
                this._BulasiciHastalikVeriSeti.IcKapiNoIkamet = event;
            }
        }
    }

    public onIkamet_BucakChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Ikamet_Bucak != event) {
                this._BulasiciHastalikVeriSeti.Ikamet_Bucak = event;
            }
        }
    }

    public onIkamet_CSBMChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Ikamet_CSBM != event) {
                this._BulasiciHastalikVeriSeti.Ikamet_CSBM = event;
            }
        }
    }

    public onIkamet_IlceChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Ikamet_Ilce != event) {
                this._BulasiciHastalikVeriSeti.Ikamet_Ilce = event;
            }
        }
    }

    public onIkamet_IlChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Ikamet_Il != event) {
                this._BulasiciHastalikVeriSeti.Ikamet_Il = event;
            }
        }
    }

    public onIkamet_KoyChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Ikamet_Koy != event) {
                this._BulasiciHastalikVeriSeti.Ikamet_Koy = event;
            }
        }
    }

    public onIkamet_MahalleChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.Ikamet_Mahalle != event) {
                this._BulasiciHastalikVeriSeti.Ikamet_Mahalle = event;
            }
        }
    }

    public onPaketeAitIslemZamaniChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.PaketeAitIslemZamani != event) {
                this._BulasiciHastalikVeriSeti.PaketeAitIslemZamani = event;
            }
        }
    }

    public onResponsibleDoctorChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.ResponsibleDoctor != event) {
                this._BulasiciHastalikVeriSeti.ResponsibleDoctor = event;
            }
        }
    }

    public onSKRSICDChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.SKRSICD != event) {
                this._BulasiciHastalikVeriSeti.SKRSICD = event;
            }
        }
    }

    public onSKRSVakaTipiChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.SKRSVakaTipi != event) {
                this._BulasiciHastalikVeriSeti.SKRSVakaTipi = event;
            }
        }
    }

    public onVakaDurumChanged(event): void {
        if (event != null) {
            if (this._BulasiciHastalikVeriSeti != null && this._BulasiciHastalikVeriSeti.VakaDurum != event) {
                this._BulasiciHastalikVeriSeti.VakaDurum = event;
            }
        }
    }

    public onPositiveNegativeEnumChanged(event): void {
        if (event != null) {
            if (this.bulasiciHastaliklarNewFormViewModel != null && this.bulasiciHastaliklarNewFormViewModel.InfluenzaResult != event) {
                this.bulasiciHastaliklarNewFormViewModel.InfluenzaResult = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.BelirtilerinBaslamaTarihi, "Value", this.__ttObject, "BelirtilerinBaslamaTarihi");
        redirectProperty(this.VakaDurum, "Value", this.__ttObject, "VakaDurum");
        redirectProperty(this.PaketeAitIslemZamani, "Value", this.__ttObject, "PaketeAitIslemZamani");
        redirectProperty(this.DisKapiNoIkamet, "Text", this.__ttObject, "DisKapiNoIkamet");
        redirectProperty(this.IcKapiNoIkamet, "Text", this.__ttObject, "IcKapiNoIkamet");
        redirectProperty(this.DisKapiNoBeyan, "Text", this.__ttObject, "DisKapiNoBeyan");
        redirectProperty(this.IcKapiNoBeyan, "Text", this.__ttObject, "IcKapiNoBeyan");
    }

    public initFormControls(): void {
        this.labelVakaDurum = new TTVisual.TTLabel();
        this.labelVakaDurum.Text = "Vaka Durumu";
        this.labelVakaDurum.Name = "labelVakaDurum";
        this.labelVakaDurum.TabIndex = 44;

        this.VakaDurum = new TTVisual.TTEnumComboBox();
        this.VakaDurum.DataTypeName = "DeathAliveEnum";
        this.VakaDurum.Name = "VakaDurum";
        this.VakaDurum.TabIndex = 43;

        this.BulasiciHastalikTelefon = new TTVisual.TTGrid();
        this.BulasiciHastalikTelefon.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BulasiciHastalikTelefon.Name = "BulasiciHastalikTelefon";
        this.BulasiciHastalikTelefon.TabIndex = 0;
        this.BulasiciHastalikTelefon.Height = "150px";
        this.BulasiciHastalikTelefon.ShowFilterCombo = true;
        this.BulasiciHastalikTelefon.FilterColumnName = "SKRSTelefonTipiBulasiciHastalikTelefon";
        this.BulasiciHastalikTelefon.FilterLabel = i18n("M23142", "Telefon Tipi");
        this.BulasiciHastalikTelefon.Filter = { ListDefName: "SKRSTelefonTipiList" };
        this.BulasiciHastalikTelefon.AllowUserToAddRows = false;
        this.BulasiciHastalikTelefon.DeleteButtonWidth = "5%";
        this.BulasiciHastalikTelefon.AllowUserToDeleteRows = true;

        this.SKRSTelefonTipiBulasiciHastalikTelefon = new TTVisual.TTListBoxColumn();
        this.SKRSTelefonTipiBulasiciHastalikTelefon.ListDefName = "SKRSTelefonTipiList";
        this.SKRSTelefonTipiBulasiciHastalikTelefon.DataMember = "SKRSTelefonTipi";
        this.SKRSTelefonTipiBulasiciHastalikTelefon.DisplayIndex = 0;
        this.SKRSTelefonTipiBulasiciHastalikTelefon.HeaderText = "";
        this.SKRSTelefonTipiBulasiciHastalikTelefon.Name = "SKRSTelefonTipiBulasiciHastalikTelefon";
        this.SKRSTelefonTipiBulasiciHastalikTelefon.Width = "45%";


        this.TelefonNumarasiBulasiciHastalikTelefon = new TTVisual.TTTextBoxColumn();
        this.TelefonNumarasiBulasiciHastalikTelefon.DataMember = "TelefonNumarasi";
        this.TelefonNumarasiBulasiciHastalikTelefon.DisplayIndex = 1;
        this.TelefonNumarasiBulasiciHastalikTelefon.HeaderText = i18n("M23138", "Telefon Numarası");
        this.TelefonNumarasiBulasiciHastalikTelefon.Name = "TelefonNumarasiBulasiciHastalikTelefon";
        this.TelefonNumarasiBulasiciHastalikTelefon.Width = "45%";

        this.labelBeyan_CSBM = new TTVisual.TTLabel();
        this.labelBeyan_CSBM.Text = i18n("M12294", "CSBM Tipi");
        this.labelBeyan_CSBM.Name = "labelBeyan_CSBM";
        this.labelBeyan_CSBM.TabIndex = 41;

        this.Beyan_CSBM = new TTVisual.TTObjectListBox();
        this.Beyan_CSBM.ListDefName = "SKRSCSBMTipiList";
        this.Beyan_CSBM.Name = "Beyan_CSBM";
        this.Beyan_CSBM.TabIndex = 40;

        this.labelIkamet_CSBM = new TTVisual.TTLabel();
        this.labelIkamet_CSBM.Text = i18n("M12294", "CSBM Tipi");
        this.labelIkamet_CSBM.Name = "labelIkamet_CSBM";
        this.labelIkamet_CSBM.TabIndex = 39;

        this.Ikamet_CSBM = new TTVisual.TTObjectListBox();
        this.Ikamet_CSBM.ListDefName = "SKRSCSBMTipiList";
        this.Ikamet_CSBM.Name = "Ikamet_CSBM";
        this.Ikamet_CSBM.TabIndex = 38;
        this.Ikamet_CSBM.Enabled = false;

        this.labelBeyan_Mahalle = new TTVisual.TTLabel();
        this.labelBeyan_Mahalle.Text = i18n("M18436", "Mahalle");
        this.labelBeyan_Mahalle.Name = "labelBeyan_Mahalle";
        this.labelBeyan_Mahalle.TabIndex = 37;

        this.Beyan_Mahalle = new TTVisual.TTObjectListBox();
        this.Beyan_Mahalle.ListDefName = "SKRSMahalleKodlariList";
        this.Beyan_Mahalle.Name = "Beyan_Mahalle";
        this.Beyan_Mahalle.TabIndex = 36;

        this.labelIkamet_Mahalle = new TTVisual.TTLabel();
        this.labelIkamet_Mahalle.Text = i18n("M18436", "Mahalle");
        this.labelIkamet_Mahalle.Name = "labelIkamet_Mahalle";
        this.labelIkamet_Mahalle.TabIndex = 35;

        this.Ikamet_Mahalle = new TTVisual.TTObjectListBox();
        this.Ikamet_Mahalle.ListDefName = "SKRSMahalleKodlariList";
        this.Ikamet_Mahalle.Name = "Ikamet_Mahalle";
        this.Ikamet_Mahalle.TabIndex = 34;
        this.Ikamet_Mahalle.Enabled = false;

        this.labelBeyan_Koy = new TTVisual.TTLabel();
        this.labelBeyan_Koy.Text = i18n("M17848", "Köy");
        this.labelBeyan_Koy.Name = "labelBeyan_Koy";
        this.labelBeyan_Koy.TabIndex = 33;

        this.Beyan_Koy = new TTVisual.TTObjectListBox();
        this.Beyan_Koy.ListDefName = "SKRSKoyKodlariList";
        this.Beyan_Koy.Name = "Beyan_Koy";
        this.Beyan_Koy.TabIndex = 32;

        this.labelIkamet_Koy = new TTVisual.TTLabel();
        this.labelIkamet_Koy.Text = i18n("M17848", "Köy");
        this.labelIkamet_Koy.Name = "labelIkamet_Koy";
        this.labelIkamet_Koy.TabIndex = 31;

        this.Ikamet_Koy = new TTVisual.TTObjectListBox();
        this.Ikamet_Koy.ListDefName = "SKRSKoyKodlariList";
        this.Ikamet_Koy.Name = "Ikamet_Koy";
        this.Ikamet_Koy.TabIndex = 30;
        this.Ikamet_Koy.Enabled = false;

        this.labelBeyan_Bucak = new TTVisual.TTLabel();
        this.labelBeyan_Bucak.Text = i18n("M12097", "Bucak");
        this.labelBeyan_Bucak.Name = "labelBeyan_Bucak";
        this.labelBeyan_Bucak.TabIndex = 29;

        this.Beyan_Bucak = new TTVisual.TTObjectListBox();
        this.Beyan_Bucak.ListDefName = "SKRSBucakKodlariList";
        this.Beyan_Bucak.Name = "Beyan_Bucak";
        this.Beyan_Bucak.TabIndex = 28;

        this.labelIkamet_Bucak = new TTVisual.TTLabel();
        this.labelIkamet_Bucak.Text = i18n("M12097", "Bucak");
        this.labelIkamet_Bucak.Name = "labelIkamet_Bucak";
        this.labelIkamet_Bucak.TabIndex = 27;

        this.Ikamet_Bucak = new TTVisual.TTObjectListBox();
        this.Ikamet_Bucak.ListDefName = "SKRSBucakKodlariList";
        this.Ikamet_Bucak.Name = "Ikamet_Bucak";
        this.Ikamet_Bucak.TabIndex = 26;
        this.Ikamet_Bucak.Enabled = false;

        this.labelResponsibleDoctor = new TTVisual.TTLabel();
        this.labelResponsibleDoctor.Text = i18n("M22142", "Sorumlu Doktor");
        this.labelResponsibleDoctor.Name = "labelResponsibleDoctor";
        this.labelResponsibleDoctor.TabIndex = 25;

        this.ResponsibleDoctor = new TTVisual.TTObjectListBox();
        this.ResponsibleDoctor.ListDefName = "DoctorListDefinition";
        this.ResponsibleDoctor.Name = "ResponsibleDoctor";
        this.ResponsibleDoctor.TabIndex = 24;
        this.ResponsibleDoctor.Enabled = false;

        this.labelSKRSICD = new TTVisual.TTLabel();
        this.labelSKRSICD.Text = i18n("M22736", "Tanı");
        this.labelSKRSICD.Name = "labelSKRSICD";
        this.labelSKRSICD.TabIndex = 23;

        this.SKRSICD = new TTVisual.TTObjectListBox();
        this.SKRSICD.ListDefName = "SKRSICDList";
        this.SKRSICD.Name = "SKRSICD";
        this.SKRSICD.TabIndex = 22;
        this.SKRSICD.Enabled = false;

        this.labelSKRSVakaTipi = new TTVisual.TTLabel();
        this.labelSKRSVakaTipi.Text = i18n("M24030", "Vaka Tipi");
        this.labelSKRSVakaTipi.Name = "labelSKRSVakaTipi";
        this.labelSKRSVakaTipi.TabIndex = 21;

        this.SKRSVakaTipi = new TTVisual.TTObjectListBox();
        this.SKRSVakaTipi.ListDefName = "SKRSVakaTipiList";
        this.SKRSVakaTipi.Name = "SKRSVakaTipi";
        this.SKRSVakaTipi.TabIndex = 20;

        this.labelBeyan_Ilce = new TTVisual.TTLabel();
        this.labelBeyan_Ilce.Text = i18n("M16396", "İlçe");
        this.labelBeyan_Ilce.Name = "labelBeyan_Ilce";
        this.labelBeyan_Ilce.TabIndex = 19;

        this.Beyan_Ilce = new TTVisual.TTObjectListBox();
        this.Beyan_Ilce.ListDefName = "SKRSIlceKodlariList";
        this.Beyan_Ilce.Name = "Beyan_Ilce";
        this.Beyan_Ilce.TabIndex = 18;

        this.labelIkamet_Ilce = new TTVisual.TTLabel();
        this.labelIkamet_Ilce.Text = i18n("M16396", "İlçe");
        this.labelIkamet_Ilce.Name = "labelIkamet_Ilce";
        this.labelIkamet_Ilce.TabIndex = 17;

        this.Ikamet_Ilce = new TTVisual.TTObjectListBox();
        this.Ikamet_Ilce.ListDefName = "SKRSIlceKodlariList";
        this.Ikamet_Ilce.Name = "Ikamet_Ilce";
        this.Ikamet_Ilce.TabIndex = 16;
        this.Ikamet_Ilce.Enabled = false;

        this.labelBeyan_Il = new TTVisual.TTLabel();
        this.labelBeyan_Il.Text = i18n("M16269", "İl");
        this.labelBeyan_Il.Name = "labelBeyan_Il";
        this.labelBeyan_Il.TabIndex = 15;

        this.Beyan_Il = new TTVisual.TTObjectListBox();
        this.Beyan_Il.ListDefName = "SKRSILKodlariList";
        this.Beyan_Il.Name = "Beyan_Il";
        this.Beyan_Il.TabIndex = 14;

        this.labelIkamet_Il = new TTVisual.TTLabel();
        this.labelIkamet_Il.Text = i18n("M16269", "İl");
        this.labelIkamet_Il.Name = "labelIkamet_Il";
        this.labelIkamet_Il.TabIndex = 13;

        this.Ikamet_Il = new TTVisual.TTObjectListBox();
        this.Ikamet_Il.ListDefName = "SKRSILKodlariList";
        this.Ikamet_Il.Name = "Ikamet_Il";
        this.Ikamet_Il.TabIndex = 12;
        this.Ikamet_Il.Enabled = false;

        this.labelIcKapiNoBeyan = new TTVisual.TTLabel();
        this.labelIcKapiNoBeyan.Text = i18n("M16163", "İç Kapı No");
        this.labelIcKapiNoBeyan.Name = "labelIcKapiNoBeyan";
        this.labelIcKapiNoBeyan.TabIndex = 11;

        this.IcKapiNoBeyan = new TTVisual.TTTextBox();
        this.IcKapiNoBeyan.Name = "IcKapiNoBeyan";
        this.IcKapiNoBeyan.TabIndex = 10;

        this.DisKapiNoBeyan = new TTVisual.TTTextBox();
        this.DisKapiNoBeyan.Name = "DisKapiNoBeyan";
        this.DisKapiNoBeyan.TabIndex = 8;

        this.IcKapiNoIkamet = new TTVisual.TTTextBox();
        this.IcKapiNoIkamet.Name = "IcKapiNoIkamet";
        this.IcKapiNoIkamet.TabIndex = 6;
        this.IcKapiNoIkamet.Enabled = false;

        this.DisKapiNoIkamet = new TTVisual.TTTextBox();
        this.DisKapiNoIkamet.Name = "DisKapiNoIkamet";
        this.DisKapiNoIkamet.TabIndex = 4;
        this.DisKapiNoIkamet.Enabled = false;

        this.labelDisKapiNoBeyan = new TTVisual.TTLabel();
        this.labelDisKapiNoBeyan.Text = i18n("M12746", "Dış Kapı No");
        this.labelDisKapiNoBeyan.Name = "labelDisKapiNoBeyan";
        this.labelDisKapiNoBeyan.TabIndex = 9;

        this.labelIcKapiNoIkamet = new TTVisual.TTLabel();
        this.labelIcKapiNoIkamet.Text = i18n("M16163", "İç Kapı No");
        this.labelIcKapiNoIkamet.Name = "labelIcKapiNoIkamet";
        this.labelIcKapiNoIkamet.TabIndex = 7;

        this.labelDisKapiNoIkamet = new TTVisual.TTLabel();
        this.labelDisKapiNoIkamet.Text = i18n("M12746", "Dış Kapı No");
        this.labelDisKapiNoIkamet.Name = "labelDisKapiNoIkamet";
        this.labelDisKapiNoIkamet.TabIndex = 5;

        this.labelPaketeAitIslemZamani = new TTVisual.TTLabel();
        this.labelPaketeAitIslemZamani.Text = i18n("M20178", "Pakete Ait İşlem Zamanı");
        this.labelPaketeAitIslemZamani.Name = "labelPaketeAitIslemZamani";
        this.labelPaketeAitIslemZamani.TabIndex = 3;

        this.PaketeAitIslemZamani = new TTVisual.TTDateTimePicker();
        this.PaketeAitIslemZamani.Format = DateTimePickerFormat.Long;
        this.PaketeAitIslemZamani.Name = "PaketeAitIslemZamani";
        this.PaketeAitIslemZamani.TabIndex = 2;
        this.PaketeAitIslemZamani.Enabled = false;

        this.labelBelirtilerinBaslamaTarihi = new TTVisual.TTLabel();
        this.labelBelirtilerinBaslamaTarihi.Text = i18n("M11758", "Belirtilerin Başlama Tarihi");
        this.labelBelirtilerinBaslamaTarihi.Name = "labelBelirtilerinBaslamaTarihi";
        this.labelBelirtilerinBaslamaTarihi.TabIndex = 1;

        this.BelirtilerinBaslamaTarihi = new TTVisual.TTDateTimePicker();
        this.BelirtilerinBaslamaTarihi.Format = DateTimePickerFormat.Long;
        this.BelirtilerinBaslamaTarihi.Name = "BelirtilerinBaslamaTarihi";
        this.BelirtilerinBaslamaTarihi.TabIndex = 0;

       //this.BulasiciHastalikTelefonColumns = [this.SKRSTelefonTipiBulasiciHastalikTelefon, this.TelefonNumarasiBulasiciHastalikTelefon];
        this.Controls = [this.labelVakaDurum, this.VakaDurum, this.BulasiciHastalikTelefon, this.SKRSTelefonTipiBulasiciHastalikTelefon, this.TelefonNumarasiBulasiciHastalikTelefon, this.labelBeyan_CSBM, this.Beyan_CSBM, this.labelIkamet_CSBM, this.Ikamet_CSBM, this.labelBeyan_Mahalle, this.Beyan_Mahalle, this.labelIkamet_Mahalle, this.Ikamet_Mahalle, this.labelBeyan_Koy, this.Beyan_Koy, this.labelIkamet_Koy, this.Ikamet_Koy, this.labelBeyan_Bucak, this.Beyan_Bucak, this.labelIkamet_Bucak, this.Ikamet_Bucak, this.labelResponsibleDoctor, this.ResponsibleDoctor, this.labelSKRSICD, this.SKRSICD, this.labelSKRSVakaTipi, this.SKRSVakaTipi, this.labelBeyan_Ilce, this.Beyan_Ilce, this.labelIkamet_Ilce, this.Ikamet_Ilce, this.labelBeyan_Il, this.Beyan_Il, this.labelIkamet_Il, this.Ikamet_Il, this.labelIcKapiNoBeyan, this.IcKapiNoBeyan, this.DisKapiNoBeyan, this.IcKapiNoIkamet, this.DisKapiNoIkamet, this.labelDisKapiNoBeyan, this.labelIcKapiNoIkamet, this.labelDisKapiNoIkamet, this.labelPaketeAitIslemZamani, this.PaketeAitIslemZamani, this.labelBelirtilerinBaslamaTarihi, this.BelirtilerinBaslamaTarihi];

    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.bulasiciHastaliklarNewFormViewModel);


        that.bulasiciHastaliklarNewFormViewModel.DiagnosisObjectID = this.RouteData2.DiagnosisObjectID;


        let fullApiUrl: string = 'api/InfluenzaResultService/IsInfluenzaDiagnosis?DiagnosisObjectID=' + that.bulasiciHastaliklarNewFormViewModel.DiagnosisObjectID;
        this.httpService.get(fullApiUrl).then((ress: boolean) => {
            that.bulasiciHastaliklarNewFormViewModel.HasInfluenzaDiagnosis = ress;
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    onCopyAddress() {
   

        if (this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Il != null) {
            this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Il = this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Il;
            this.triggerLoadChildComboBoxByIL(this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Il);
        }

        if (this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Ilce != null) {
            this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Ilce = this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Ilce;
            this.triggerLoadChildComboBoxByILCE(this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Ilce);
        }

        if (this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Bucak != null) {
            this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Bucak = this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Bucak;
            this.triggerLoadChildComboBoxByBUCAK(this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Bucak);
                
        }

        if (this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Koy != null) {
            this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Koy = this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Koy;
            this.triggerLoadChildComboBoxByKOY(this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Koy);
        }

        if (this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Mahalle != null)
            this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_Mahalle = this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_Mahalle;

        if (this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_CSBM != null)
            this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Beyan_CSBM = this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.Ikamet_CSBM;

        if (this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.DisKapiNoIkamet != null)
            this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.DisKapiNoBeyan = this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.DisKapiNoIkamet;

        if (this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.IcKapiNoIkamet != null)
            this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.IcKapiNoBeyan = this.bulasiciHastaliklarNewFormViewModel._BulasiciHastalikVeriSeti.IcKapiNoIkamet;
    }

    GenerateTelListColumns() {
        let that = this;

        this.BulasiciHastalikTelefonColumns = [
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
