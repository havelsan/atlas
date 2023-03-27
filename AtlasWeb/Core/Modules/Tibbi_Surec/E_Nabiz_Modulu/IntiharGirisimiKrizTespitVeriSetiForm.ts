//$60F505E1
import { Component, OnInit, NgZone  } from '@angular/core';
import { IntiharGirisimiKrizTespitVeriSetiFormViewModel } from './IntiharGirisimiKrizTespitVeriSetiFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { IntiharGirisimKrizVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { IntiharGirisimiKrizNedeni } from 'NebulaClient/Model/AtlasClientModel';
import { IntiharGirisimiVakaSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { IntiharGirisimiYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { IntiharGirisimPsikiyatTani } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAilesindeIntiharGirisimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAilesindePsikiyatrikVaka } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIntiharGirisimiGecmisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIntiharKrizVakaTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPsikiyatrikTedaviGecmisi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'IntiharGirisimiKrizTespitVeriSetiForm',
    templateUrl: './IntiharGirisimiKrizTespitVeriSetiForm.html',
    providers: [MessageService]
})
export class IntiharGirisimiKrizTespitVeriSetiForm extends TTVisual.TTForm implements OnInit {
    IntiharGirisimiKrizNedeni: TTVisual.ITTGrid;
    IntiharGirisimiVakaSonucu: TTVisual.ITTGrid;
    IntiharGirisimiYontemi: TTVisual.ITTGrid;
    IntiharGirisimPsikiyatTani: TTVisual.ITTGrid;
    labelOlayZamani: TTVisual.ITTLabel;
    labelSKRSAilesindeIntiharGirisimi: TTVisual.ITTLabel;
    labelSKRSAilesindePsikiyatrikVaka: TTVisual.ITTLabel;
    labelSKRSIntiharGirisimiGecmisi: TTVisual.ITTLabel;
    labelSKRSIntiharKrizVakaTuru: TTVisual.ITTLabel;
    labelSKRSPsikiyatrikTedaviGecmisi: TTVisual.ITTLabel;
    OlayZamani: TTVisual.ITTDateTimePicker;
    PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani: TTVisual.ITTListBoxColumn;
    SKRSAilesindeIntiharGirisimi: TTVisual.ITTObjectListBox;
    SKRSAilesindePsikiyatrikVaka: TTVisual.ITTObjectListBox;
    SKRSIntiharGirisimiGecmisi: TTVisual.ITTObjectListBox;
    SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi: TTVisual.ITTListBoxColumn;
    SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni: TTVisual.ITTListBoxColumn;
    SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu: TTVisual.ITTListBoxColumn;
    SKRSIntiharKrizVakaTuru: TTVisual.ITTObjectListBox;
    SKRSPsikiyatrikTedaviGecmisi: TTVisual.ITTObjectListBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    RouteData: any;
    RouteData2: any;
    public IntiharGirisimiKrizNedeniColumns = [];
    public IntiharGirisimiVakaSonucuColumns = [];
    public IntiharGirisimiYontemiColumns = [];
    public IntiharGirisimPsikiyatTaniColumns = [];
    public intiharGirisimiKrizTespitVeriSetiFormViewModel: IntiharGirisimiKrizTespitVeriSetiFormViewModel = new IntiharGirisimiKrizTespitVeriSetiFormViewModel();
    public get _IntiharGirisimKrizVeriSeti(): IntiharGirisimKrizVeriSeti {
        return this._TTObject as IntiharGirisimKrizVeriSeti;
    }
    private IntiharGirisimiKrizTespitVeriSetiForm_DocumentUrl: string = '/api/IntiharGirisimKrizVeriSetiService/IntiharGirisimiKrizTespitVeriSetiForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('INTIHARGIRISIMKRIZVERISETI', 'IntiharGirisimiKrizTespitVeriSetiForm');
        this._DocumentServiceUrl = this.IntiharGirisimiKrizTespitVeriSetiForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new IntiharGirisimKrizVeriSeti();
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel = new IntiharGirisimiKrizTespitVeriSetiFormViewModel();
        this._ViewModel = this.intiharGirisimiKrizTespitVeriSetiFormViewModel;
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti = this._TTObject as IntiharGirisimKrizVeriSeti;
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimPsikiyatTani = new Array<IntiharGirisimPsikiyatTani>();
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiYontemi = new Array<IntiharGirisimiYontemi>();
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi = new SKRSPsikiyatrikTedaviGecmisi();
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru = new SKRSIntiharKrizVakaTuru();
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi = new SKRSIntiharGirisimiGecmisi();
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka = new SKRSAilesindePsikiyatrikVaka();
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi = new SKRSAilesindeIntiharGirisimi();
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiVakaSonucu = new Array<IntiharGirisimiVakaSonucu>();
        this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiKrizNedeni = new Array<IntiharGirisimiKrizNedeni>();
    }

    protected loadViewModel() {
        let that = this;
        that.intiharGirisimiKrizTespitVeriSetiFormViewModel = this._ViewModel as IntiharGirisimiKrizTespitVeriSetiFormViewModel;
        that._TTObject = this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti;
        if (this.intiharGirisimiKrizTespitVeriSetiFormViewModel == null)
            this.intiharGirisimiKrizTespitVeriSetiFormViewModel = new IntiharGirisimiKrizTespitVeriSetiFormViewModel();
        if (this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti == null)
            this.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti = new IntiharGirisimKrizVeriSeti();
        that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimPsikiyatTani = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.IntiharGirisimPsikiyatTaniGridList;
        for (let detailItem of that.intiharGirisimiKrizTespitVeriSetiFormViewModel.IntiharGirisimPsikiyatTaniGridList) {
            let psikiyatrikTaniGecmisiObjectID = detailItem["PsikiyatrikTaniGecmisi"];
            if (psikiyatrikTaniGecmisiObjectID != null && (typeof psikiyatrikTaniGecmisiObjectID === "string")) {
                let psikiyatrikTaniGecmisi = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === psikiyatrikTaniGecmisiObjectID.toString());
                 if (psikiyatrikTaniGecmisi) {
                    detailItem.PsikiyatrikTaniGecmisi = psikiyatrikTaniGecmisi;
                }
            }
        }
        that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiYontemi = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.IntiharGirisimiYontemiGridList;
        for (let detailItem of that.intiharGirisimiKrizTespitVeriSetiFormViewModel.IntiharGirisimiYontemiGridList) {
            let sKRSIntiharGirisimiYontemiICDObjectID = detailItem["SKRSIntiharGirisimiYontemiICD"];
            if (sKRSIntiharGirisimiYontemiICDObjectID != null && (typeof sKRSIntiharGirisimiYontemiICDObjectID === "string")) {
                let sKRSIntiharGirisimiYontemiICD = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === sKRSIntiharGirisimiYontemiICDObjectID.toString());
                 if (sKRSIntiharGirisimiYontemiICD) {
                    detailItem.SKRSIntiharGirisimiYontemiICD = sKRSIntiharGirisimiYontemiICD;
                }
            }
        }
        let sKRSPsikiyatrikTedaviGecmisiObjectID = that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti["SKRSPsikiyatrikTedaviGecmisi"];
        if (sKRSPsikiyatrikTedaviGecmisiObjectID != null && (typeof sKRSPsikiyatrikTedaviGecmisiObjectID === "string")) {
            let sKRSPsikiyatrikTedaviGecmisi = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.SKRSPsikiyatrikTedaviGecmisis.find(o => o.ObjectID.toString() === sKRSPsikiyatrikTedaviGecmisiObjectID.toString());
             if (sKRSPsikiyatrikTedaviGecmisi) {
                that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi = sKRSPsikiyatrikTedaviGecmisi;
            }
        }
        let sKRSIntiharKrizVakaTuruObjectID = that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti["SKRSIntiharKrizVakaTuru"];
        if (sKRSIntiharKrizVakaTuruObjectID != null && (typeof sKRSIntiharKrizVakaTuruObjectID === "string")) {
            let sKRSIntiharKrizVakaTuru = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.SKRSIntiharKrizVakaTurus.find(o => o.ObjectID.toString() === sKRSIntiharKrizVakaTuruObjectID.toString());
             if (sKRSIntiharKrizVakaTuru) {
                that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru = sKRSIntiharKrizVakaTuru;
            }
        }
        let sKRSIntiharGirisimiGecmisiObjectID = that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti["SKRSIntiharGirisimiGecmisi"];
        if (sKRSIntiharGirisimiGecmisiObjectID != null && (typeof sKRSIntiharGirisimiGecmisiObjectID === "string")) {
            let sKRSIntiharGirisimiGecmisi = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.SKRSIntiharGirisimiGecmisis.find(o => o.ObjectID.toString() === sKRSIntiharGirisimiGecmisiObjectID.toString());
             if (sKRSIntiharGirisimiGecmisi) {
                that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi = sKRSIntiharGirisimiGecmisi;
            }
        }
        let sKRSAilesindePsikiyatrikVakaObjectID = that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti["SKRSAilesindePsikiyatrikVaka"];
        if (sKRSAilesindePsikiyatrikVakaObjectID != null && (typeof sKRSAilesindePsikiyatrikVakaObjectID === "string")) {
            let sKRSAilesindePsikiyatrikVaka = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.SKRSAilesindePsikiyatrikVakas.find(o => o.ObjectID.toString() === sKRSAilesindePsikiyatrikVakaObjectID.toString());
             if (sKRSAilesindePsikiyatrikVaka) {
                that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka = sKRSAilesindePsikiyatrikVaka;
            }
        }
        let sKRSAilesindeIntiharGirisimiObjectID = that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti["SKRSAilesindeIntiharGirisimi"];
        if (sKRSAilesindeIntiharGirisimiObjectID != null && (typeof sKRSAilesindeIntiharGirisimiObjectID === "string")) {
            let sKRSAilesindeIntiharGirisimi = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.SKRSAilesindeIntiharGirisimis.find(o => o.ObjectID.toString() === sKRSAilesindeIntiharGirisimiObjectID.toString());
             if (sKRSAilesindeIntiharGirisimi) {
                that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi = sKRSAilesindeIntiharGirisimi;
            }
        }
        that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiVakaSonucu = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.IntiharGirisimiVakaSonucuGridList;
        for (let detailItem of that.intiharGirisimiKrizTespitVeriSetiFormViewModel.IntiharGirisimiVakaSonucuGridList) {
            let sKRSIntiharKrizVakaSonucuObjectID = detailItem["SKRSIntiharKrizVakaSonucu"];
            if (sKRSIntiharKrizVakaSonucuObjectID != null && (typeof sKRSIntiharKrizVakaSonucuObjectID === "string")) {
                let sKRSIntiharKrizVakaSonucu = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.SKRSIntiharKrizVakaSonucus.find(o => o.ObjectID.toString() === sKRSIntiharKrizVakaSonucuObjectID.toString());
                 if (sKRSIntiharKrizVakaSonucu) {
                    detailItem.SKRSIntiharKrizVakaSonucu = sKRSIntiharKrizVakaSonucu;
                }
            }
        }
        that.intiharGirisimiKrizTespitVeriSetiFormViewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiKrizNedeni = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.IntiharGirisimiKrizNedeniGridList;
        for (let detailItem of that.intiharGirisimiKrizTespitVeriSetiFormViewModel.IntiharGirisimiKrizNedeniGridList) {
            let sKRSIntiharGirisimKrizNedenObjectID = detailItem["SKRSIntiharGirisimKrizNeden"];
            if (sKRSIntiharGirisimKrizNedenObjectID != null && (typeof sKRSIntiharGirisimKrizNedenObjectID === "string")) {
                let sKRSIntiharGirisimKrizNeden = that.intiharGirisimiKrizTespitVeriSetiFormViewModel.SKRSIntiharGirisimiyadaKrizNedenleris.find(o => o.ObjectID.toString() === sKRSIntiharGirisimKrizNedenObjectID.toString());
                 if (sKRSIntiharGirisimKrizNeden) {
                    detailItem.SKRSIntiharGirisimKrizNeden = sKRSIntiharGirisimKrizNeden;
                }
            }
        }

    }

    async ngOnInit() {
        let that = this;
        if (this.RouteData2 != null){
            this.ObjectID = this.RouteData2;
        }
        await this.load(IntiharGirisimiKrizTespitVeriSetiFormViewModel);
  
    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.intiharGirisimiKrizTespitVeriSetiFormViewModel);
    }

    public onOlayZamaniChanged(event): void {
        if (event != null) {
            if (this._IntiharGirisimKrizVeriSeti != null && this._IntiharGirisimKrizVeriSeti.OlayZamani != event) {
                this._IntiharGirisimKrizVeriSeti.OlayZamani = event;
            }
        }
    }

    public onSKRSAilesindeIntiharGirisimiChanged(event): void {
        if (event != null) {
            if (this._IntiharGirisimKrizVeriSeti != null && this._IntiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi != event) {
                this._IntiharGirisimKrizVeriSeti.SKRSAilesindeIntiharGirisimi = event;
            }
        }
    }

    public onSKRSAilesindePsikiyatrikVakaChanged(event): void {
        if (event != null) {
            if (this._IntiharGirisimKrizVeriSeti != null && this._IntiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka != event) {
                this._IntiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka = event;
            }
        }
    }

    public onSKRSIntiharGirisimiGecmisiChanged(event): void {
        if (event != null) {
            if (this._IntiharGirisimKrizVeriSeti != null && this._IntiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi != event) {
                this._IntiharGirisimKrizVeriSeti.SKRSIntiharGirisimiGecmisi = event;
            }
        }
    }

    public onSKRSIntiharKrizVakaTuruChanged(event): void {
        if (event != null) {
            if (this._IntiharGirisimKrizVeriSeti != null && this._IntiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru != event) {
                this._IntiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru = event;
            }
        }
    }

    public onSKRSPsikiyatrikTedaviGecmisiChanged(event): void {
        if (event != null) {
            if (this._IntiharGirisimKrizVeriSeti != null && this._IntiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi != event) {
                this._IntiharGirisimKrizVeriSeti.SKRSPsikiyatrikTedaviGecmisi = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.OlayZamani, "Value", this.__ttObject, "OlayZamani");
    }

    public initFormControls(): void {
        /*this.IntiharGirisimPsikiyatTani = new TTVisual.TTGrid();
        this.IntiharGirisimPsikiyatTani.Name = "IntiharGirisimPsikiyatTani";
        this.IntiharGirisimPsikiyatTani.TabIndex = 15;*/

        this.IntiharGirisimPsikiyatTani = new TTVisual.TTGrid();
        this.IntiharGirisimPsikiyatTani.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IntiharGirisimPsikiyatTani.Name = "IntiharGirisimPsikiyatTani";
        this.IntiharGirisimPsikiyatTani.TabIndex = 0;
        this.IntiharGirisimPsikiyatTani.Height = "150px";
        this.IntiharGirisimPsikiyatTani.ShowFilterCombo = true;
        this.IntiharGirisimPsikiyatTani.FilterColumnName = "PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani";
        this.IntiharGirisimPsikiyatTani.FilterLabel = i18n("M30538", "Psikiyatrik Tanı Geçmişi");
        this.IntiharGirisimPsikiyatTani.Filter = { ListDefName: "SKRSICDList" };
        this.IntiharGirisimPsikiyatTani.AllowUserToAddRows = false;
        this.IntiharGirisimPsikiyatTani.DeleteButtonWidth = "5%";
        this.IntiharGirisimPsikiyatTani.AllowUserToDeleteRows = true;
        this.IntiharGirisimPsikiyatTani.IsFilterLabelSingleLine = false;

        this.PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani = new TTVisual.TTListBoxColumn();
        this.PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani.ListDefName = "SKRSICDList";
        this.PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani.DataMember = "PsikiyatrikTaniGecmisi";
        this.PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani.DisplayIndex = 0;
        this.PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani.HeaderText = i18n("M30538", "Psikiyatrik Tanı Geçmişi");
        this.PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani.Name = "PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani";
        this.PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani.Width = 450;

        /*this.IntiharGirisimiYontemi = new TTVisual.TTGrid();
        this.IntiharGirisimiYontemi.Name = "IntiharGirisimiYontemi";
        this.IntiharGirisimiYontemi.TabIndex = 14;
*/

        this.IntiharGirisimiYontemi = new TTVisual.TTGrid();
        this.IntiharGirisimiYontemi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IntiharGirisimiYontemi.Name = "IntiharGirisimiYontemi";
        this.IntiharGirisimiYontemi.TabIndex = 0;
        this.IntiharGirisimiYontemi.Height = "150px";
        this.IntiharGirisimiYontemi.ShowFilterCombo = true;
        this.IntiharGirisimiYontemi.FilterColumnName = "SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi";
        this.IntiharGirisimiYontemi.FilterLabel = i18n("M30537", "İntihar Girişim Yöntemi");
        this.IntiharGirisimiYontemi.Filter = { ListDefName: "SKRSICDList" };
        this.IntiharGirisimiYontemi.AllowUserToAddRows = false;
        this.IntiharGirisimiYontemi.DeleteButtonWidth = "5%";
        this.IntiharGirisimiYontemi.AllowUserToDeleteRows = true;
        this.IntiharGirisimiYontemi.IsFilterLabelSingleLine = false;

        this.SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi = new TTVisual.TTListBoxColumn();
        this.SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi.ListDefName = "SKRSICDList";
        this.SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi.DataMember = "SKRSIntiharGirisimiYontemiICD";
        this.SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi.DisplayIndex = 0;
        this.SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi.HeaderText = i18n("M30537", "İntihar Girişim Yöntemi");
        this.SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi.Name = "SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi";
        this.SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi.Width = 450;

        this.labelSKRSPsikiyatrikTedaviGecmisi = new TTVisual.TTLabel();
        this.labelSKRSPsikiyatrikTedaviGecmisi.Text = i18n("M20596", "Psikiyatrik Tedavi Geçmişi");
        this.labelSKRSPsikiyatrikTedaviGecmisi.Name = "labelSKRSPsikiyatrikTedaviGecmisi";
        this.labelSKRSPsikiyatrikTedaviGecmisi.TabIndex = 13;

        this.SKRSPsikiyatrikTedaviGecmisi = new TTVisual.TTObjectListBox();
        this.SKRSPsikiyatrikTedaviGecmisi.ListDefName = "SKRSPsikiyatrikTedaviGecmisiList";
        this.SKRSPsikiyatrikTedaviGecmisi.Name = "SKRSPsikiyatrikTedaviGecmisi";
        this.SKRSPsikiyatrikTedaviGecmisi.TabIndex = 12;

        this.labelSKRSIntiharKrizVakaTuru = new TTVisual.TTLabel();
        this.labelSKRSIntiharKrizVakaTuru.Text = "İntihar Kriz Vaka Türü";
        this.labelSKRSIntiharKrizVakaTuru.Name = "labelSKRSIntiharKrizVakaTuru";
        this.labelSKRSIntiharKrizVakaTuru.TabIndex = 11;

        this.SKRSIntiharKrizVakaTuru = new TTVisual.TTObjectListBox();
        this.SKRSIntiharKrizVakaTuru.ListDefName = "SKRSIntiharKrizVakaTuruList";
        this.SKRSIntiharKrizVakaTuru.Name = "SKRSIntiharKrizVakaTuru";
        this.SKRSIntiharKrizVakaTuru.TabIndex = 10;

        this.labelSKRSIntiharGirisimiGecmisi = new TTVisual.TTLabel();
        this.labelSKRSIntiharGirisimiGecmisi.Text = "İntihar Girişim Geçmişi";
        this.labelSKRSIntiharGirisimiGecmisi.Name = "labelSKRSIntiharGirisimiGecmisi";
        this.labelSKRSIntiharGirisimiGecmisi.TabIndex = 9;

        this.SKRSIntiharGirisimiGecmisi = new TTVisual.TTObjectListBox();
        this.SKRSIntiharGirisimiGecmisi.ListDefName = "SKRSIntiharGirisimiGecmisiList";
        this.SKRSIntiharGirisimiGecmisi.Name = "SKRSIntiharGirisimiGecmisi";
        this.SKRSIntiharGirisimiGecmisi.TabIndex = 8;

        this.labelSKRSAilesindePsikiyatrikVaka = new TTVisual.TTLabel();
        this.labelSKRSAilesindePsikiyatrikVaka.Text = "Ailede Psikiyatrik Vaka";
        this.labelSKRSAilesindePsikiyatrikVaka.Name = "labelSKRSAilesindePsikiyatrikVaka";
        this.labelSKRSAilesindePsikiyatrikVaka.TabIndex = 7;

        this.SKRSAilesindePsikiyatrikVaka = new TTVisual.TTObjectListBox();
        this.SKRSAilesindePsikiyatrikVaka.ListDefName = "SKRSAilesindePsikiyatrikVakaList";
        this.SKRSAilesindePsikiyatrikVaka.Name = "SKRSAilesindePsikiyatrikVaka";
        this.SKRSAilesindePsikiyatrikVaka.TabIndex = 6;

        this.labelSKRSAilesindeIntiharGirisimi = new TTVisual.TTLabel();
        this.labelSKRSAilesindeIntiharGirisimi.Text = i18n("M10615", "Ailesinde İntihar Girişimi");
        this.labelSKRSAilesindeIntiharGirisimi.Name = "labelSKRSAilesindeIntiharGirisimi";
        this.labelSKRSAilesindeIntiharGirisimi.TabIndex = 5;

        this.SKRSAilesindeIntiharGirisimi = new TTVisual.TTObjectListBox();
        this.SKRSAilesindeIntiharGirisimi.ListDefName = "SKRSAilesindeIntiharGirisimiList";
        this.SKRSAilesindeIntiharGirisimi.Name = "SKRSAilesindeIntiharGirisimi";
        this.SKRSAilesindeIntiharGirisimi.TabIndex = 4;

        /*this.IntiharGirisimiVakaSonucu = new TTVisual.TTGrid();
        this.IntiharGirisimiVakaSonucu.Name = "IntiharGirisimiVakaSonucu";
        this.IntiharGirisimiVakaSonucu.TabIndex = 3;*/

        this.IntiharGirisimiVakaSonucu = new TTVisual.TTGrid();
        this.IntiharGirisimiVakaSonucu.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IntiharGirisimiVakaSonucu.Name = "IntiharGirisimiVakaSonucu";
        this.IntiharGirisimiVakaSonucu.TabIndex = 0;
        this.IntiharGirisimiVakaSonucu.Height = "150px";
        this.IntiharGirisimiVakaSonucu.ShowFilterCombo = true;
        this.IntiharGirisimiVakaSonucu.FilterColumnName = "SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu";
        this.IntiharGirisimiVakaSonucu.FilterLabel = i18n("M30539", "Vaka Sonucu");
        this.IntiharGirisimiVakaSonucu.Filter = { ListDefName: "SKRSIntiharKrizVakaSonucuList" };
        this.IntiharGirisimiVakaSonucu.AllowUserToAddRows = false;
        this.IntiharGirisimiVakaSonucu.DeleteButtonWidth = "5%";
        this.IntiharGirisimiVakaSonucu.AllowUserToDeleteRows = true;
        this.IntiharGirisimiVakaSonucu.IsFilterLabelSingleLine = false;

        this.SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu = new TTVisual.TTListBoxColumn();
        this.SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu.ListDefName = "SKRSIntiharKrizVakaSonucuList";
        this.SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu.DataMember = "SKRSIntiharKrizVakaSonucu";
        this.SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu.DisplayIndex = 0;
        this.SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu.HeaderText = i18n("M30539", "Vaka Sonucu");
        this.SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu.Name = "SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu";
        this.SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu.Width = 450;

        /*this.IntiharGirisimiKrizNedeni = new TTVisual.TTGrid();
        this.IntiharGirisimiKrizNedeni.Name = "IntiharGirisimiKrizNedeni";
        this.IntiharGirisimiKrizNedeni.TabIndex = 2;*/

        this.IntiharGirisimiKrizNedeni = new TTVisual.TTGrid();
        this.IntiharGirisimiKrizNedeni.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IntiharGirisimiKrizNedeni.Name = "IntiharGirisimiKrizNedeni";
        this.IntiharGirisimiKrizNedeni.TabIndex = 0;
        this.IntiharGirisimiKrizNedeni.Height = "150px";
        this.IntiharGirisimiKrizNedeni.ShowFilterCombo = true;
        this.IntiharGirisimiKrizNedeni.FilterColumnName = "SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni";
        this.IntiharGirisimiKrizNedeni.FilterLabel = i18n("M30540", "İntihar Girişim Nedeni");
        this.IntiharGirisimiKrizNedeni.Filter = { ListDefName: "SKRSIntiharGirisimiyadaKrizNedenleriList" };
        this.IntiharGirisimiKrizNedeni.AllowUserToAddRows = false;
        this.IntiharGirisimiKrizNedeni.DeleteButtonWidth = "5%";
        this.IntiharGirisimiKrizNedeni.AllowUserToDeleteRows = true;
        this.IntiharGirisimiKrizNedeni.IsFilterLabelSingleLine = false;

        this.SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni = new TTVisual.TTListBoxColumn();
        this.SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni.ListDefName = "SKRSIntiharGirisimiyadaKrizNedenleriList";
        this.SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni.DataMember = "SKRSIntiharGirisimKrizNeden";
        this.SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni.DisplayIndex = 0;
        this.SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni.HeaderText = i18n("M30540", "İntihar Girişim Nedeni");
        this.SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni.Name = "SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni";
        this.SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni.Width = 450;

        this.labelOlayZamani = new TTVisual.TTLabel();
        this.labelOlayZamani.Text = "Olay Zamanı";
        this.labelOlayZamani.Name = "labelOlayZamani";
        this.labelOlayZamani.TabIndex = 1;

        this.OlayZamani = new TTVisual.TTDateTimePicker();
        this.OlayZamani.Format = DateTimePickerFormat.Long;
        this.OlayZamani.Name = "OlayZamani";
        this.OlayZamani.TabIndex = 0;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "İntihar Girişimi ya da Kriz Nedeni";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 7;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "İntihar Girişimi Vaka Sonucu";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 7;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "İntihar Girişim Yöntemi";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 7;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "İntihar Girişimi Psikiyatrik Tanı";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 7;

        this.IntiharGirisimPsikiyatTaniColumns = [this.PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani];
        this.IntiharGirisimiYontemiColumns = [this.SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi];
        this.IntiharGirisimiVakaSonucuColumns = [this.SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu];
        this.IntiharGirisimiKrizNedeniColumns = [this.SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni];
        this.Controls = [this.IntiharGirisimPsikiyatTani, this.PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani, this.IntiharGirisimiYontemi, this.SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi, this.labelSKRSPsikiyatrikTedaviGecmisi, this.SKRSPsikiyatrikTedaviGecmisi, this.labelSKRSIntiharKrizVakaTuru, this.SKRSIntiharKrizVakaTuru, this.labelSKRSIntiharGirisimiGecmisi, this.SKRSIntiharGirisimiGecmisi, this.labelSKRSAilesindePsikiyatrikVaka, this.SKRSAilesindePsikiyatrikVaka, this.labelSKRSAilesindeIntiharGirisimi, this.SKRSAilesindeIntiharGirisimi, this.IntiharGirisimiVakaSonucu, this.SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu, this.IntiharGirisimiKrizNedeni, this.SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni, this.labelOlayZamani, this.OlayZamani, this.ttlabel7, this.ttlabel8, this.ttlabel1, this.ttlabel2];

    }


}
