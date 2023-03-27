//$3E0CA74F
import { Component, OnInit, NgZone } from '@angular/core';
import { DiyabetFormViewModel } from './DiyabetFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DiyabetVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { DiyabetKompBilgisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyabetEgitimi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'DiyabetForm',
    templateUrl: './DiyabetForm.html',
    providers: [MessageService]
})
export class DiyabetForm extends TTVisual.TTForm implements OnInit {
    Boy: TTVisual.ITTTextBox;
    DiyabetKompBilgisi: TTVisual.ITTGrid;
    IlkTaniTarihi: TTVisual.ITTDateTimePicker;
    Kilo: TTVisual.ITTTextBox;
    labelBoy: TTVisual.ITTLabel;
    labelIlkTaniTarihi: TTVisual.ITTLabel;
    labelKilo: TTVisual.ITTLabel;
    labelSKRSDiyabetEgitimi: TTVisual.ITTLabel;
    SKRSDiyabetEgitimi: TTVisual.ITTObjectListBox;
    SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi: TTVisual.ITTListBoxColumn;
    RouteData: any;
    RouteData2: any;

    public DiyabetKompBilgisiColumns = [];
    public diyabetFormViewModel: DiyabetFormViewModel = new DiyabetFormViewModel();
    public get _DiyabetVeriSeti(): DiyabetVeriSeti {
        return this._TTObject as DiyabetVeriSeti;
    }
    private DiyabetForm_DocumentUrl: string = '/api/DiyabetVeriSetiService/DiyabetForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('DIYABETVERISETI', 'DiyabetForm');
        this._DocumentServiceUrl = this.DiyabetForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DiyabetVeriSeti();
        this.diyabetFormViewModel = new DiyabetFormViewModel();
        this._ViewModel = this.diyabetFormViewModel;
        this.diyabetFormViewModel._DiyabetVeriSeti = this._TTObject as DiyabetVeriSeti;
        this.diyabetFormViewModel._DiyabetVeriSeti.SKRSDiyabetEgitimi = new SKRSDiyabetEgitimi();
        this.diyabetFormViewModel._DiyabetVeriSeti.DiyabetKompBilgisi = new Array<DiyabetKompBilgisi>();
    }

    protected loadViewModel() {
        let that = this;

        that.diyabetFormViewModel = this._ViewModel as DiyabetFormViewModel;
        that._TTObject = this.diyabetFormViewModel._DiyabetVeriSeti;
        if (this.diyabetFormViewModel == null)
            this.diyabetFormViewModel = new DiyabetFormViewModel();
        if (this.diyabetFormViewModel._DiyabetVeriSeti == null)
            this.diyabetFormViewModel._DiyabetVeriSeti = new DiyabetVeriSeti();
        let sKRSDiyabetEgitimiObjectID = that.diyabetFormViewModel._DiyabetVeriSeti["SKRSDiyabetEgitimi"];
        if (sKRSDiyabetEgitimiObjectID != null && (typeof sKRSDiyabetEgitimiObjectID === "string")) {
            let sKRSDiyabetEgitimi = that.diyabetFormViewModel.SKRSDiyabetEgitimis.find(o => o.ObjectID.toString() === sKRSDiyabetEgitimiObjectID.toString());
             if (sKRSDiyabetEgitimi) {
                that.diyabetFormViewModel._DiyabetVeriSeti.SKRSDiyabetEgitimi = sKRSDiyabetEgitimi;
            }
        }
        that.diyabetFormViewModel._DiyabetVeriSeti.DiyabetKompBilgisi = that.diyabetFormViewModel.DiyabetKompBilgisiGridList;
        for (let detailItem of that.diyabetFormViewModel.DiyabetKompBilgisiGridList) {
            let sKRSDiyabetKomplikasyonlariObjectID = detailItem["SKRSDiyabetKomplikasyonlari"];
            if (sKRSDiyabetKomplikasyonlariObjectID != null && (typeof sKRSDiyabetKomplikasyonlariObjectID === "string")) {
                let sKRSDiyabetKomplikasyonlari = that.diyabetFormViewModel.SKRSDiyabetKomplikasyonlaris.find(o => o.ObjectID.toString() === sKRSDiyabetKomplikasyonlariObjectID.toString());
                 if (sKRSDiyabetKomplikasyonlari) {
                    detailItem.SKRSDiyabetKomplikasyonlari = sKRSDiyabetKomplikasyonlari;
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
        await this.load(DiyabetFormViewModel);
  
    }


    public onBoyChanged(event): void {
        if (event != null) {
            if (this._DiyabetVeriSeti != null && this._DiyabetVeriSeti.Boy != event) {
                this._DiyabetVeriSeti.Boy = event;
            }
        }
    }

    public onIlkTaniTarihiChanged(event): void {
        if (event != null) {
            if (this._DiyabetVeriSeti != null && this._DiyabetVeriSeti.IlkTaniTarihi != event) {
                this._DiyabetVeriSeti.IlkTaniTarihi = event;
            }
        }
    }

    public onKiloChanged(event): void {
        if (event != null) {
            if (this._DiyabetVeriSeti != null && this._DiyabetVeriSeti.Kilo != event) {
                this._DiyabetVeriSeti.Kilo = event;
            }
        }
    }

    public onSKRSDiyabetEgitimiChanged(event): void {
        if (event != null) {
            if (this._DiyabetVeriSeti != null && this._DiyabetVeriSeti.SKRSDiyabetEgitimi != event) {
                this._DiyabetVeriSeti.SKRSDiyabetEgitimi = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.IlkTaniTarihi, "Value", this.__ttObject, "IlkTaniTarihi");
        redirectProperty(this.Boy, "Text", this.__ttObject, "Boy");
        redirectProperty(this.Kilo, "Text", this.__ttObject, "Kilo");
    }

    public initFormControls(): void {
        this.labelSKRSDiyabetEgitimi = new TTVisual.TTLabel();
        this.labelSKRSDiyabetEgitimi.Text = i18n("M12979", "Diyabet Eğitimi");
        this.labelSKRSDiyabetEgitimi.Name = "labelSKRSDiyabetEgitimi";
        this.labelSKRSDiyabetEgitimi.TabIndex = 8;

        this.SKRSDiyabetEgitimi = new TTVisual.TTObjectListBox();
        this.SKRSDiyabetEgitimi.ListDefName = "SKRSDiyabetEgitimiList";
        this.SKRSDiyabetEgitimi.Name = "SKRSDiyabetEgitimi";
        this.SKRSDiyabetEgitimi.TabIndex = 7;

        //this.DiyabetKompBilgisi = new TTVisual.TTGrid();
        //this.DiyabetKompBilgisi.Name = "DiyabetKompBilgisi";
        //this.DiyabetKompBilgisi.TabIndex = 6;

        this.DiyabetKompBilgisi = new TTVisual.TTGrid();
        this.DiyabetKompBilgisi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DiyabetKompBilgisi.Name = "DiyabetKompBilgisi";
        this.DiyabetKompBilgisi.TabIndex = 0;
        this.DiyabetKompBilgisi.Height = "150px";
        this.DiyabetKompBilgisi.ShowFilterCombo = true;
        this.DiyabetKompBilgisi.FilterColumnName = "SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi";
        this.DiyabetKompBilgisi.FilterLabel = i18n("M12983", "Diyabet Komplikasyonları");
        this.DiyabetKompBilgisi.Filter = { ListDefName: "SKRSDiyabetKomplikasyonlariList" };
        this.DiyabetKompBilgisi.AllowUserToAddRows = false;
        this.DiyabetKompBilgisi.DeleteButtonWidth = "5%";
        this.DiyabetKompBilgisi.AllowUserToDeleteRows = true;
        this.DiyabetKompBilgisi.IsFilterLabelSingleLine = true;


        this.SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi = new TTVisual.TTListBoxColumn();
        this.SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi.ListDefName = "SKRSDiyabetKomplikasyonlariList";
        this.SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi.DataMember = "SKRSDiyabetKomplikasyonlari";
        this.SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi.DisplayIndex = 0;
        this.SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi.HeaderText = "";
        this.SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi.Name = "SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi";
        this.SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi.Width = "90%";

        this.labelKilo = new TTVisual.TTLabel();
        this.labelKilo.Text = "Kilo";
        this.labelKilo.Name = "labelKilo";
        this.labelKilo.TabIndex = 5;

        this.Kilo = new TTVisual.TTTextBox();
        this.Kilo.Name = "Kilo";
        this.Kilo.TabIndex = 4;

        this.Boy = new TTVisual.TTTextBox();
        this.Boy.Name = "Boy";
        this.Boy.TabIndex = 2;

        this.labelBoy = new TTVisual.TTLabel();
        this.labelBoy.Text = "Boy";
        this.labelBoy.Name = "labelBoy";
        this.labelBoy.TabIndex = 3;

        this.labelIlkTaniTarihi = new TTVisual.TTLabel();
        this.labelIlkTaniTarihi.Text = i18n("M16454", "İlk Tanı Tarihi");
        this.labelIlkTaniTarihi.Name = "labelIlkTaniTarihi";
        this.labelIlkTaniTarihi.TabIndex = 1;

        this.IlkTaniTarihi = new TTVisual.TTDateTimePicker();
        this.IlkTaniTarihi.Format = DateTimePickerFormat.Long;
        this.IlkTaniTarihi.Name = "IlkTaniTarihi";
        this.IlkTaniTarihi.TabIndex = 0;

        this.DiyabetKompBilgisiColumns = [this.SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi];
        this.Controls = [this.labelSKRSDiyabetEgitimi, this.SKRSDiyabetEgitimi, this.DiyabetKompBilgisi, this.SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi, this.labelKilo, this.Kilo, this.Boy, this.labelBoy, this.labelIlkTaniTarihi, this.IlkTaniTarihi];

    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.diyabetFormViewModel);


    }
}
