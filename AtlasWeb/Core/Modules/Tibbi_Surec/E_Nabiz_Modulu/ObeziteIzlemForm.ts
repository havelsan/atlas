//$8E862C39
import { Component, OnInit, NgZone } from '@angular/core';
import { ObeziteIzlemFormViewModel } from './ObeziteIzlemFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ObeziteIzlemVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { ObeziteEgzersiz } from 'NebulaClient/Model/AtlasClientModel';
import { ObeziteEkHastalik } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyetTedavisiTibbiBeslenmeTedavisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMorbidObezHastaLenfatikOdemVarligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSObeziteIlacTedavisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPsikolojikTedavi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'ObeziteIzlemForm',
    templateUrl: './ObeziteIzlemForm.html',
    providers: [MessageService]
})
export class ObeziteIzlemForm extends TTVisual.TTForm implements OnInit {
    BelCevresi: TTVisual.ITTTextBox;
    Boy: TTVisual.ITTTextBox;
    DiyetTibbiBeslenmeTedavisi: TTVisual.ITTObjectListBox;
    IlkTaniTarihi: TTVisual.ITTDateTimePicker;
    KalcaCevresi: TTVisual.ITTTextBox;
    Kilo: TTVisual.ITTTextBox;
    labelBelCevresi: TTVisual.ITTLabel;
    labelBoy: TTVisual.ITTLabel;
    labelDiyetTibbiBeslenmeTedavisi: TTVisual.ITTLabel;
    labelIlkTaniTarihi: TTVisual.ITTLabel;
    labelKalcaCevresi: TTVisual.ITTLabel;
    labelKilo: TTVisual.ITTLabel;
    labelOdemVarligi: TTVisual.ITTLabel;
    labelSKRSObeziteIlacTedavisi: TTVisual.ITTLabel;
    labelSKRSPsikolojikTedavi: TTVisual.ITTLabel;
    ObeziteEgzersiz: TTVisual.ITTGrid;
    ObeziteEkHastalik: TTVisual.ITTGrid;
    OdemVarligi: TTVisual.ITTObjectListBox;
    SKRSEgzersizObeziteEgzersiz: TTVisual.ITTListBoxColumn;
    SKRSICDObeziteEkHastalik: TTVisual.ITTListBoxColumn;
    SKRSObeziteIlacTedavisi: TTVisual.ITTObjectListBox;
    SKRSPsikolojikTedavi: TTVisual.ITTObjectListBox;
    RouteData: any;
    RouteData2: any;
    public ObeziteEgzersizColumns = [];
    public ObeziteEkHastalikColumns = [];
    public obeziteIzlemFormViewModel: ObeziteIzlemFormViewModel = new ObeziteIzlemFormViewModel();
    public get _ObeziteIzlemVeriSeti(): ObeziteIzlemVeriSeti {
        return this._TTObject as ObeziteIzlemVeriSeti;
    }
    private ObeziteIzlemForm_DocumentUrl: string = '/api/ObeziteIzlemVeriSetiService/ObeziteIzlemForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('OBEZITEIZLEMVERISETI', 'ObeziteIzlemForm');
        this._DocumentServiceUrl = this.ObeziteIzlemForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ObeziteIzlemVeriSeti();
        this.obeziteIzlemFormViewModel = new ObeziteIzlemFormViewModel();
        this._ViewModel = this.obeziteIzlemFormViewModel;
        this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti = this._TTObject as ObeziteIzlemVeriSeti;
        this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.SKRSPsikolojikTedavi = new SKRSPsikolojikTedavi();
        this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.SKRSObeziteIlacTedavisi = new SKRSObeziteIlacTedavisi();
        this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.OdemVarligi = new SKRSMorbidObezHastaLenfatikOdemVarligi();
        this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.DiyetTibbiBeslenmeTedavisi = new SKRSDiyetTedavisiTibbiBeslenmeTedavisi();
        this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.ObeziteEkHastalik = new Array<ObeziteEkHastalik>();
        this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.ObeziteEgzersiz = new Array<ObeziteEgzersiz>();
    }

    protected loadViewModel() {
        let that = this;

        that.obeziteIzlemFormViewModel = this._ViewModel as ObeziteIzlemFormViewModel;
        that._TTObject = this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti;
        if (this.obeziteIzlemFormViewModel == null)
            this.obeziteIzlemFormViewModel = new ObeziteIzlemFormViewModel();
        if (this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti == null)
            this.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti = new ObeziteIzlemVeriSeti();
        let sKRSPsikolojikTedaviObjectID = that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti["SKRSPsikolojikTedavi"];
        if (sKRSPsikolojikTedaviObjectID != null && (typeof sKRSPsikolojikTedaviObjectID === "string")) {
            let sKRSPsikolojikTedavi = that.obeziteIzlemFormViewModel.SKRSPsikolojikTedavis.find(o => o.ObjectID.toString() === sKRSPsikolojikTedaviObjectID.toString());
             if (sKRSPsikolojikTedavi) {
                that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.SKRSPsikolojikTedavi = sKRSPsikolojikTedavi;
            }
        }
        let sKRSObeziteIlacTedavisiObjectID = that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti["SKRSObeziteIlacTedavisi"];
        if (sKRSObeziteIlacTedavisiObjectID != null && (typeof sKRSObeziteIlacTedavisiObjectID === "string")) {
            let sKRSObeziteIlacTedavisi = that.obeziteIzlemFormViewModel.SKRSObeziteIlacTedavisis.find(o => o.ObjectID.toString() === sKRSObeziteIlacTedavisiObjectID.toString());
             if (sKRSObeziteIlacTedavisi) {
                that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.SKRSObeziteIlacTedavisi = sKRSObeziteIlacTedavisi;
            }
        }
        let odemVarligiObjectID = that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti["OdemVarligi"];
        if (odemVarligiObjectID != null && (typeof odemVarligiObjectID === "string")) {
            let odemVarligi = that.obeziteIzlemFormViewModel.SKRSMorbidObezHastaLenfatikOdemVarligis.find(o => o.ObjectID.toString() === odemVarligiObjectID.toString());
             if (odemVarligi) {
                that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.OdemVarligi = odemVarligi;
            }
        }
        let diyetTibbiBeslenmeTedavisiObjectID = that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti["DiyetTibbiBeslenmeTedavisi"];
        if (diyetTibbiBeslenmeTedavisiObjectID != null && (typeof diyetTibbiBeslenmeTedavisiObjectID === "string")) {
            let diyetTibbiBeslenmeTedavisi = that.obeziteIzlemFormViewModel.SKRSDiyetTedavisiTibbiBeslenmeTedavisis.find(o => o.ObjectID.toString() === diyetTibbiBeslenmeTedavisiObjectID.toString());
             if (diyetTibbiBeslenmeTedavisi) {
                that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.DiyetTibbiBeslenmeTedavisi = diyetTibbiBeslenmeTedavisi;
            }
        }
        that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.ObeziteEkHastalik = that.obeziteIzlemFormViewModel.ObeziteEkHastalikGridList;
        for (let detailItem of that.obeziteIzlemFormViewModel.ObeziteEkHastalikGridList) {
            let sKRSICDObjectID = detailItem["SKRSICD"];
            if (sKRSICDObjectID != null && (typeof sKRSICDObjectID === "string")) {
                let sKRSICD = that.obeziteIzlemFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === sKRSICDObjectID.toString());
                 if (sKRSICD) {
                    detailItem.SKRSICD = sKRSICD;
                }
            }
        }
        that.obeziteIzlemFormViewModel._ObeziteIzlemVeriSeti.ObeziteEgzersiz = that.obeziteIzlemFormViewModel.ObeziteEgzersizGridList;
        for (let detailItem of that.obeziteIzlemFormViewModel.ObeziteEgzersizGridList) {
            let sKRSEgzersizObjectID = detailItem["SKRSEgzersiz"];
            if (sKRSEgzersizObjectID != null && (typeof sKRSEgzersizObjectID === "string")) {
                let sKRSEgzersiz = that.obeziteIzlemFormViewModel.SKRSEgzersizs.find(o => o.ObjectID.toString() === sKRSEgzersizObjectID.toString());
                 if (sKRSEgzersiz) {
                    detailItem.SKRSEgzersiz = sKRSEgzersiz;
                }
            }
        }

    }

    async ngOnInit()  {
        let that = this;
        if (this.RouteData2 != null){
            this.ObjectID = this.RouteData2.ObjectID;
            this.ActiveIDsModel = new ActiveIDsModel(this.RouteData2.EpisodeActionID, null, null);
       
        }
        await this.load(ObeziteIzlemFormViewModel);
  
    }


    public onBelCevresiChanged(event): void {
        if (event != null) {
            if (this._ObeziteIzlemVeriSeti != null && this._ObeziteIzlemVeriSeti.BelCevresi != event) {
                this._ObeziteIzlemVeriSeti.BelCevresi = event;
            }
        }
    }

    public onBoyChanged(event): void {
        if (event != null) {
            if (this._ObeziteIzlemVeriSeti != null && this._ObeziteIzlemVeriSeti.Boy != event) {
                this._ObeziteIzlemVeriSeti.Boy = event;
            }
        }
    }

    public onDiyetTibbiBeslenmeTedavisiChanged(event): void {
        if (event != null) {
            if (this._ObeziteIzlemVeriSeti != null && this._ObeziteIzlemVeriSeti.DiyetTibbiBeslenmeTedavisi != event) {
                this._ObeziteIzlemVeriSeti.DiyetTibbiBeslenmeTedavisi = event;
            }
        }
    }

    public onIlkTaniTarihiChanged(event): void {
        if (event != null) {
            if (this._ObeziteIzlemVeriSeti != null && this._ObeziteIzlemVeriSeti.IlkTaniTarihi != event) {
                this._ObeziteIzlemVeriSeti.IlkTaniTarihi = event;
            }
        }
    }

    public onKalcaCevresiChanged(event): void {
        if (event != null) {
            if (this._ObeziteIzlemVeriSeti != null && this._ObeziteIzlemVeriSeti.KalcaCevresi != event) {
                this._ObeziteIzlemVeriSeti.KalcaCevresi = event;
            }
        }
    }

    public onKiloChanged(event): void {
        if (event != null) {
            if (this._ObeziteIzlemVeriSeti != null && this._ObeziteIzlemVeriSeti.Kilo != event) {
                this._ObeziteIzlemVeriSeti.Kilo = event;
            }
        }
    }

    public onOdemVarligiChanged(event): void {
        if (event != null) {
            if (this._ObeziteIzlemVeriSeti != null && this._ObeziteIzlemVeriSeti.OdemVarligi != event) {
                this._ObeziteIzlemVeriSeti.OdemVarligi = event;
            }
        }
    }

    public onSKRSObeziteIlacTedavisiChanged(event): void {
        if (event != null) {
            if (this._ObeziteIzlemVeriSeti != null && this._ObeziteIzlemVeriSeti.SKRSObeziteIlacTedavisi != event) {
                this._ObeziteIzlemVeriSeti.SKRSObeziteIlacTedavisi = event;
            }
        }
    }

    public onSKRSPsikolojikTedaviChanged(event): void {
        if (event != null) {
            if (this._ObeziteIzlemVeriSeti != null && this._ObeziteIzlemVeriSeti.SKRSPsikolojikTedavi != event) {
                this._ObeziteIzlemVeriSeti.SKRSPsikolojikTedavi = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.IlkTaniTarihi, "Value", this.__ttObject, "IlkTaniTarihi");
        redirectProperty(this.Boy, "Text", this.__ttObject, "Boy");
        redirectProperty(this.Kilo, "Text", this.__ttObject, "Kilo");
        redirectProperty(this.BelCevresi, "Text", this.__ttObject, "BelCevresi");
        redirectProperty(this.KalcaCevresi, "Text", this.__ttObject, "KalcaCevresi");
    }

    public initFormControls(): void {
        this.labelSKRSPsikolojikTedavi = new TTVisual.TTLabel();
        this.labelSKRSPsikolojikTedavi.Text = i18n("M20612", "Psikolojik Tedavi");
        this.labelSKRSPsikolojikTedavi.Name = "labelSKRSPsikolojikTedavi";
        this.labelSKRSPsikolojikTedavi.TabIndex = 19;

        this.SKRSPsikolojikTedavi = new TTVisual.TTObjectListBox();
        this.SKRSPsikolojikTedavi.ListDefName = "SKRSPsikolojikTedaviList";
        this.SKRSPsikolojikTedavi.Name = "SKRSPsikolojikTedavi";
        this.SKRSPsikolojikTedavi.TabIndex = 18;

        this.labelSKRSObeziteIlacTedavisi = new TTVisual.TTLabel();
        this.labelSKRSObeziteIlacTedavisi.Text = i18n("M19591", "Obezite İlaç Tedavisi");
        this.labelSKRSObeziteIlacTedavisi.Name = "labelSKRSObeziteIlacTedavisi";
        this.labelSKRSObeziteIlacTedavisi.TabIndex = 17;

        this.SKRSObeziteIlacTedavisi = new TTVisual.TTObjectListBox();
        this.SKRSObeziteIlacTedavisi.ListDefName = "SKRSObeziteIlacTedavisiList";
        this.SKRSObeziteIlacTedavisi.Name = "SKRSObeziteIlacTedavisi";
        this.SKRSObeziteIlacTedavisi.TabIndex = 16;

        this.labelOdemVarligi = new TTVisual.TTLabel();
        this.labelOdemVarligi.Text = i18n("M19121", "Morbid Obez Hasta Lenfatik Odem Varlığı");
        this.labelOdemVarligi.Name = "labelOdemVarligi";
        this.labelOdemVarligi.TabIndex = 15;

        this.OdemVarligi = new TTVisual.TTObjectListBox();
        this.OdemVarligi.ListDefName = "SKRSMorbidObezHastaLenfatikOdemVarligiList";
        this.OdemVarligi.Name = "OdemVarligi";
        this.OdemVarligi.TabIndex = 14;

        this.labelDiyetTibbiBeslenmeTedavisi = new TTVisual.TTLabel();
        this.labelDiyetTibbiBeslenmeTedavisi.Text = i18n("M13061", "Diyet-Tıbbi Beslenme Tedavisi");
        this.labelDiyetTibbiBeslenmeTedavisi.Name = "labelDiyetTibbiBeslenmeTedavisi";
        this.labelDiyetTibbiBeslenmeTedavisi.TabIndex = 13;

        this.DiyetTibbiBeslenmeTedavisi = new TTVisual.TTObjectListBox();
        this.DiyetTibbiBeslenmeTedavisi.ListDefName = "SKRSDiyetTedavisiTibbiBeslenmeTedavisiList";
        this.DiyetTibbiBeslenmeTedavisi.Name = "DiyetTibbiBeslenmeTedavisi";
        this.DiyetTibbiBeslenmeTedavisi.TabIndex = 12;

        //this.ObeziteEkHastalik = new TTVisual.TTGrid();
        //this.ObeziteEkHastalik.Name = "ObeziteEkHastalik";
        //this.ObeziteEkHastalik.TabIndex = 11;

        this.ObeziteEkHastalik = new TTVisual.TTGrid();
        this.ObeziteEkHastalik.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ObeziteEkHastalik.Name = "ObeziteEkHastalik";
        this.ObeziteEkHastalik.TabIndex = 0;
        this.ObeziteEkHastalik.Height = "150px";
        this.ObeziteEkHastalik.ShowFilterCombo = true;
        this.ObeziteEkHastalik.FilterColumnName = "SKRSICDObeziteEkHastalik";
        this.ObeziteEkHastalik.FilterLabel = i18n("M13520", "Ek Hastalıklar");
        this.ObeziteEkHastalik.Filter = { ListDefName: "SKRSICDList" };
        this.ObeziteEkHastalik.AllowUserToAddRows = false;
        this.ObeziteEkHastalik.DeleteButtonWidth = "5%";
        this.ObeziteEkHastalik.AllowUserToDeleteRows = true;
        this.ObeziteEkHastalik.IsFilterLabelSingleLine = true;

        this.SKRSICDObeziteEkHastalik = new TTVisual.TTListBoxColumn();
        this.SKRSICDObeziteEkHastalik.ListDefName = "SKRSICDList";
        this.SKRSICDObeziteEkHastalik.DataMember = "SKRSICD";
        this.SKRSICDObeziteEkHastalik.DisplayIndex = 0;
        this.SKRSICDObeziteEkHastalik.HeaderText = "";
        this.SKRSICDObeziteEkHastalik.Name = "SKRSICDObeziteEkHastalik";
        this.SKRSICDObeziteEkHastalik.Width = "90%";

        //this.ObeziteEgzersiz = new TTVisual.TTGrid();
        //this.ObeziteEgzersiz.Name = "ObeziteEgzersiz";
        //this.ObeziteEgzersiz.TabIndex = 10;

        this.ObeziteEgzersiz = new TTVisual.TTGrid();
        this.ObeziteEgzersiz.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ObeziteEgzersiz.Name = "ObeziteEgzersiz";
        this.ObeziteEgzersiz.TabIndex = 0;
        this.ObeziteEgzersiz.Height = "150px";
        this.ObeziteEgzersiz.ShowFilterCombo = true;
        this.ObeziteEgzersiz.FilterColumnName = "SKRSEgzersizObeziteEgzersiz";
        this.ObeziteEgzersiz.FilterLabel = i18n("M30544", "Egzersiz");
        this.ObeziteEgzersiz.Filter = { ListDefName: "SKRSEgzersizList" };
        this.ObeziteEgzersiz.AllowUserToAddRows = false;
        this.ObeziteEgzersiz.DeleteButtonWidth = "5%";
        this.ObeziteEgzersiz.AllowUserToDeleteRows = true;
        this.ObeziteEgzersiz.IsFilterLabelSingleLine = true;

        this.SKRSEgzersizObeziteEgzersiz = new TTVisual.TTListBoxColumn();
        this.SKRSEgzersizObeziteEgzersiz.ListDefName = "SKRSEgzersizList";
        this.SKRSEgzersizObeziteEgzersiz.DataMember = "SKRSEgzersiz";
        this.SKRSEgzersizObeziteEgzersiz.DisplayIndex = 0;
        this.SKRSEgzersizObeziteEgzersiz.HeaderText = i18n("M30544", "Egzersiz");
        this.SKRSEgzersizObeziteEgzersiz.Name = "SKRSEgzersizObeziteEgzersiz";
        this.SKRSEgzersizObeziteEgzersiz.Width = "90%";

        this.labelKilo = new TTVisual.TTLabel();
        this.labelKilo.Text = "Kilo";
        this.labelKilo.Name = "labelKilo";
        this.labelKilo.TabIndex = 9;

        this.Kilo = new TTVisual.TTTextBox();
        this.Kilo.Name = "Kilo";
        this.Kilo.TabIndex = 8;

        this.Boy = new TTVisual.TTTextBox();
        this.Boy.Name = "Boy";
        this.Boy.TabIndex = 6;

        this.KalcaCevresi = new TTVisual.TTTextBox();
        this.KalcaCevresi.Name = "KalcaCevresi";
        this.KalcaCevresi.TabIndex = 4;

        this.BelCevresi = new TTVisual.TTTextBox();
        this.BelCevresi.Name = "BelCevresi";
        this.BelCevresi.TabIndex = 0;

        this.labelBoy = new TTVisual.TTLabel();
        this.labelBoy.Text = "Boy";
        this.labelBoy.Name = "labelBoy";
        this.labelBoy.TabIndex = 7;

        this.labelKalcaCevresi = new TTVisual.TTLabel();
        this.labelKalcaCevresi.Text = i18n("M17088", "Kalça Çevresi");
        this.labelKalcaCevresi.Name = "labelKalcaCevresi";
        this.labelKalcaCevresi.TabIndex = 5;

        this.labelIlkTaniTarihi = new TTVisual.TTLabel();
        this.labelIlkTaniTarihi.Text = i18n("M16454", "İlk Tanı Tarihi");
        this.labelIlkTaniTarihi.Name = "labelIlkTaniTarihi";
        this.labelIlkTaniTarihi.TabIndex = 3;

        this.IlkTaniTarihi = new TTVisual.TTDateTimePicker();
        this.IlkTaniTarihi.Format = DateTimePickerFormat.Long;
        this.IlkTaniTarihi.Name = "IlkTaniTarihi";
        this.IlkTaniTarihi.TabIndex = 2;

        this.labelBelCevresi = new TTVisual.TTLabel();
        this.labelBelCevresi.Text = i18n("M11732", "Bel Çevresi");
        this.labelBelCevresi.Name = "labelBelCevresi";
        this.labelBelCevresi.TabIndex = 1;

        this.ObeziteEkHastalikColumns = [this.SKRSICDObeziteEkHastalik];
        this.ObeziteEgzersizColumns = [this.SKRSEgzersizObeziteEgzersiz];
        this.Controls = [this.labelSKRSPsikolojikTedavi, this.SKRSPsikolojikTedavi, this.labelSKRSObeziteIlacTedavisi, this.SKRSObeziteIlacTedavisi, this.labelOdemVarligi, this.OdemVarligi, this.labelDiyetTibbiBeslenmeTedavisi, this.DiyetTibbiBeslenmeTedavisi, this.ObeziteEkHastalik, this.SKRSICDObeziteEkHastalik, this.ObeziteEgzersiz, this.SKRSEgzersizObeziteEgzersiz, this.labelKilo, this.Kilo, this.Boy, this.KalcaCevresi, this.BelCevresi, this.labelBoy, this.labelKalcaCevresi, this.labelIlkTaniTarihi, this.IlkTaniTarihi, this.labelBelCevresi];

    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.obeziteIzlemFormViewModel);


    }
}
