//$E13ED8D4
import { Component, OnInit, NgZone  } from '@angular/core';
import { IntiharIzlemFormViewModel } from './IntiharIzlemFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { IntiharIzlemVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { IntiharIzlemNedeni } from 'NebulaClient/Model/AtlasClientModel';
import { IntiharIzlemVakaSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { IntiharIzlemYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIntiharKrizVakaTuru } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'IntiharIzlemForm',
    templateUrl: './IntiharIzlemForm.html',
    providers: [MessageService]
})
export class IntiharIzlemForm extends TTVisual.TTForm implements OnInit {
    IntiharIzlemNedeni: TTVisual.ITTGrid;
    IntiharIzlemVakaSonucu: TTVisual.ITTGrid;
    IntiharIzlemYontemi: TTVisual.ITTGrid;
    labelSKRSIntiharKrizVakaTuru: TTVisual.ITTLabel;
    SKRSICDIntiharIzlemYontemi: TTVisual.ITTListBoxColumn;
    SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni: TTVisual.ITTListBoxColumn;
    SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu: TTVisual.ITTListBoxColumn;
    SKRSIntiharKrizVakaTuru: TTVisual.ITTObjectListBox;
    public IntiharIzlemNedeniColumns = [];
    public IntiharIzlemVakaSonucuColumns = [];
    public IntiharIzlemYontemiColumns = [];
    public RouteData: any;
    public RouteData2: any;

    public intiharIzlemFormViewModel: IntiharIzlemFormViewModel = new IntiharIzlemFormViewModel();
    public get _IntiharIzlemVeriSeti(): IntiharIzlemVeriSeti {
        return this._TTObject as IntiharIzlemVeriSeti;
    }
    private IntiharIzlemForm_DocumentUrl: string = '/api/IntiharIzlemVeriSetiService/IntiharIzlemForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('INTIHARIZLEMVERISETI', 'IntiharIzlemForm');
        this._DocumentServiceUrl = this.IntiharIzlemForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new IntiharIzlemVeriSeti();
        this.intiharIzlemFormViewModel = new IntiharIzlemFormViewModel();
        this._ViewModel = this.intiharIzlemFormViewModel;
        this.intiharIzlemFormViewModel._IntiharIzlemVeriSeti = this._TTObject as IntiharIzlemVeriSeti;
        this.intiharIzlemFormViewModel._IntiharIzlemVeriSeti.SKRSIntiharKrizVakaTuru = new SKRSIntiharKrizVakaTuru();
        this.intiharIzlemFormViewModel._IntiharIzlemVeriSeti.IntiharIzlemYontemi = new Array<IntiharIzlemYontemi>();
        this.intiharIzlemFormViewModel._IntiharIzlemVeriSeti.IntiharIzlemVakaSonucu = new Array<IntiharIzlemVakaSonucu>();
        this.intiharIzlemFormViewModel._IntiharIzlemVeriSeti.IntiharIzlemNedeni = new Array<IntiharIzlemNedeni>();
    }

    protected loadViewModel() {
        let that = this;
        that.intiharIzlemFormViewModel = this._ViewModel as IntiharIzlemFormViewModel;
        that._TTObject = this.intiharIzlemFormViewModel._IntiharIzlemVeriSeti;
        if (this.intiharIzlemFormViewModel == null)
            this.intiharIzlemFormViewModel = new IntiharIzlemFormViewModel();
        if (this.intiharIzlemFormViewModel._IntiharIzlemVeriSeti == null)
            this.intiharIzlemFormViewModel._IntiharIzlemVeriSeti = new IntiharIzlemVeriSeti();
        let sKRSIntiharKrizVakaTuruObjectID = that.intiharIzlemFormViewModel._IntiharIzlemVeriSeti["SKRSIntiharKrizVakaTuru"];
        if (sKRSIntiharKrizVakaTuruObjectID != null && (typeof sKRSIntiharKrizVakaTuruObjectID === "string")) {
            let sKRSIntiharKrizVakaTuru = that.intiharIzlemFormViewModel.SKRSIntiharKrizVakaTurus.find(o => o.ObjectID.toString() === sKRSIntiharKrizVakaTuruObjectID.toString());
             if (sKRSIntiharKrizVakaTuru) {
                that.intiharIzlemFormViewModel._IntiharIzlemVeriSeti.SKRSIntiharKrizVakaTuru = sKRSIntiharKrizVakaTuru;
            }
        }
        that.intiharIzlemFormViewModel._IntiharIzlemVeriSeti.IntiharIzlemYontemi = that.intiharIzlemFormViewModel.IntiharIzlemYontemiGridList;
        for (let detailItem of that.intiharIzlemFormViewModel.IntiharIzlemYontemiGridList) {
            let sKRSICDObjectID = detailItem["SKRSICD"];
            if (sKRSICDObjectID != null && (typeof sKRSICDObjectID === "string")) {
                let sKRSICD = that.intiharIzlemFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === sKRSICDObjectID.toString());
                 if (sKRSICD) {
                    detailItem.SKRSICD = sKRSICD;
                }
            }
        }
        that.intiharIzlemFormViewModel._IntiharIzlemVeriSeti.IntiharIzlemVakaSonucu = that.intiharIzlemFormViewModel.IntiharIzlemVakaSonucuGridList;
        for (let detailItem of that.intiharIzlemFormViewModel.IntiharIzlemVakaSonucuGridList) {
            let sKRSIntiharKrizVakaSonucuObjectID = detailItem["SKRSIntiharKrizVakaSonucu"];
            if (sKRSIntiharKrizVakaSonucuObjectID != null && (typeof sKRSIntiharKrizVakaSonucuObjectID === "string")) {
                let sKRSIntiharKrizVakaSonucu = that.intiharIzlemFormViewModel.SKRSIntiharKrizVakaSonucus.find(o => o.ObjectID.toString() === sKRSIntiharKrizVakaSonucuObjectID.toString());
                 if (sKRSIntiharKrizVakaSonucu) {
                    detailItem.SKRSIntiharKrizVakaSonucu = sKRSIntiharKrizVakaSonucu;
                }
            }
        }
        that.intiharIzlemFormViewModel._IntiharIzlemVeriSeti.IntiharIzlemNedeni = that.intiharIzlemFormViewModel.IntiharIzlemNedeniGridList;
        for (let detailItem of that.intiharIzlemFormViewModel.IntiharIzlemNedeniGridList) {
            let sKRSIntiharGirisimiNedenleriObjectID = detailItem["SKRSIntiharGirisimiNedenleri"];
            if (sKRSIntiharGirisimiNedenleriObjectID != null && (typeof sKRSIntiharGirisimiNedenleriObjectID === "string")) {
                let sKRSIntiharGirisimiNedenleri = that.intiharIzlemFormViewModel.SKRSIntiharGirisimiyadaKrizNedenleris.find(o => o.ObjectID.toString() === sKRSIntiharGirisimiNedenleriObjectID.toString());
                 if (sKRSIntiharGirisimiNedenleri) {
                    detailItem.SKRSIntiharGirisimiNedenleri = sKRSIntiharGirisimiNedenleri;
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
        await this.load(IntiharIzlemFormViewModel);
  


    }

    public onSKRSIntiharKrizVakaTuruChanged(event): void {
        if (event != null) {
            if (this._IntiharIzlemVeriSeti != null && this._IntiharIzlemVeriSeti.SKRSIntiharKrizVakaTuru != event) {
                this._IntiharIzlemVeriSeti.SKRSIntiharKrizVakaTuru = event;
            }
        }
    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.intiharIzlemFormViewModel);


    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.labelSKRSIntiharKrizVakaTuru = new TTVisual.TTLabel();
        this.labelSKRSIntiharKrizVakaTuru.Text = "İntihar / Kriz Vaka Türü";
        this.labelSKRSIntiharKrizVakaTuru.Name = "labelSKRSIntiharKrizVakaTuru";
        this.labelSKRSIntiharKrizVakaTuru.TabIndex = 4;

        this.SKRSIntiharKrizVakaTuru = new TTVisual.TTObjectListBox();
        this.SKRSIntiharKrizVakaTuru.Required = true;
        this.SKRSIntiharKrizVakaTuru.ListDefName = "SKRSIntiharKrizVakaTuruList";
        this.SKRSIntiharKrizVakaTuru.Name = "SKRSIntiharKrizVakaTuru";
        this.SKRSIntiharKrizVakaTuru.TabIndex = 3;

        //this.IntiharIzlemYontemi = new TTVisual.TTGrid();
        //this.IntiharIzlemYontemi.Required = true;
        //this.IntiharIzlemYontemi.Name = "IntiharIzlemYontemi";
        //this.IntiharIzlemYontemi.TabIndex = 2;
        //this.IntiharIzlemYontemi.DeleteButtonWidth = "5%";

        this.IntiharIzlemYontemi = new TTVisual.TTGrid();
        this.IntiharIzlemYontemi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IntiharIzlemYontemi.Name = "IntiharIzlemYontemi";
        this.IntiharIzlemYontemi.TabIndex = 0;
        this.IntiharIzlemYontemi.Height = "150px";
        this.IntiharIzlemYontemi.ShowFilterCombo = true;
        this.IntiharIzlemYontemi.FilterColumnName = "SKRSICDIntiharIzlemYontemi";
        this.IntiharIzlemYontemi.FilterLabel = i18n("M30537", "İntihar Girişimi Yöntemi");
        this.IntiharIzlemYontemi.Filter = { ListDefName: "SKRSICDList" };
        this.IntiharIzlemYontemi.AllowUserToAddRows = false;
        this.IntiharIzlemYontemi.DeleteButtonWidth = "5%";
        this.IntiharIzlemYontemi.AllowUserToDeleteRows = true;
        this.IntiharIzlemYontemi.IsFilterLabelSingleLine = false;

        this.SKRSICDIntiharIzlemYontemi = new TTVisual.TTListBoxColumn();
        this.SKRSICDIntiharIzlemYontemi.ListDefName = "SKRSICDList";
        this.SKRSICDIntiharIzlemYontemi.DataMember = "SKRSICD";
        this.SKRSICDIntiharIzlemYontemi.DisplayIndex = 0;
        this.SKRSICDIntiharIzlemYontemi.HeaderText =  i18n("M30537", "İntihar Girişimi Yöntemi");
        this.SKRSICDIntiharIzlemYontemi.Name = "SKRSICDIntiharIzlemYontemi";
        this.SKRSICDIntiharIzlemYontemi.Width = "90%";

        //this.IntiharIzlemVakaSonucu = new TTVisual.TTGrid();
        //this.IntiharIzlemVakaSonucu.Name = "IntiharIzlemVakaSonucu";
        //this.IntiharIzlemVakaSonucu.TabIndex = 1;
        //this.IntiharIzlemVakaSonucu.DeleteButtonWidth = "5%";

        this.IntiharIzlemVakaSonucu = new TTVisual.TTGrid();
        this.IntiharIzlemVakaSonucu.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IntiharIzlemVakaSonucu.Name = "IntiharIzlemVakaSonucu";
        this.IntiharIzlemVakaSonucu.TabIndex = 0;
        this.IntiharIzlemVakaSonucu.Height = "150px";
        this.IntiharIzlemVakaSonucu.ShowFilterCombo = true;
        this.IntiharIzlemVakaSonucu.FilterColumnName = "SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu";
        this.IntiharIzlemVakaSonucu.FilterLabel = i18n("M16524", "İntihar / Kriz Vaka Sonucu");
        this.IntiharIzlemVakaSonucu.Filter = { ListDefName: "SKRSIntiharKrizVakaSonucuList" };
        this.IntiharIzlemVakaSonucu.AllowUserToAddRows = false;
        this.IntiharIzlemVakaSonucu.DeleteButtonWidth = "5%";
        this.IntiharIzlemVakaSonucu.AllowUserToDeleteRows = true;
        this.IntiharIzlemVakaSonucu.IsFilterLabelSingleLine = false;

        this.SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu = new TTVisual.TTListBoxColumn();
        this.SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu.ListDefName = "SKRSIntiharKrizVakaSonucuList";
        this.SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu.DataMember = "SKRSIntiharKrizVakaSonucu";
        this.SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu.DisplayIndex = 0;
        this.SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu.HeaderText = i18n("M16524", "İntihar / Kriz Vaka Sonucu");
        this.SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu.Name = "SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu";
        this.SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu.Width = "90%";

        //this.IntiharIzlemNedeni = new TTVisual.TTGrid();
        //this.IntiharIzlemNedeni.Name = "IntiharIzlemNedeni";
        //this.IntiharIzlemNedeni.TabIndex = 0;
        //this.IntiharIzlemNedeni.DeleteButtonWidth = "5%";

        this.IntiharIzlemNedeni = new TTVisual.TTGrid();
        this.IntiharIzlemNedeni.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IntiharIzlemNedeni.Name = "IntiharIzlemNedeni";
        this.IntiharIzlemNedeni.TabIndex = 0;
        this.IntiharIzlemNedeni.Height = "150px";
        this.IntiharIzlemNedeni.ShowFilterCombo = true;
        this.IntiharIzlemNedeni.FilterColumnName = "SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni";
        this.IntiharIzlemNedeni.FilterLabel = i18n("M30542", "İntihar Girişimi ya da Kriz Nedeni");
        this.IntiharIzlemNedeni.Filter = { ListDefName: "SKRSIntiharGirisimiyadaKrizNedenleriList" };
        this.IntiharIzlemNedeni.AllowUserToAddRows = false;
        this.IntiharIzlemNedeni.DeleteButtonWidth = "5%";
        this.IntiharIzlemNedeni.AllowUserToDeleteRows = true;
        this.IntiharIzlemNedeni.IsFilterLabelSingleLine = false;


        this.SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni = new TTVisual.TTListBoxColumn();
        this.SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni.ListDefName = "SKRSIntiharGirisimiyadaKrizNedenleriList";
        this.SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni.DataMember = "SKRSIntiharGirisimiNedenleri";
        this.SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni.DisplayIndex = 0;
        this.SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni.HeaderText = i18n("M30542", "İntihar Girişimi ya da Kriz Nedeni");
        this.SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni.Name = "SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni";
        this.SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni.Width = "90%";

        this.IntiharIzlemYontemiColumns = [this.SKRSICDIntiharIzlemYontemi];
        this.IntiharIzlemVakaSonucuColumns = [this.SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu];
        this.IntiharIzlemNedeniColumns = [this.SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni];
        this.Controls = [this.labelSKRSIntiharKrizVakaTuru, this.SKRSIntiharKrizVakaTuru, this.IntiharIzlemYontemi, this.SKRSICDIntiharIzlemYontemi, this.IntiharIzlemVakaSonucu, this.SKRSIntiharKrizVakaSonucuIntiharIzlemVakaSonucu, this.IntiharIzlemNedeni, this.SKRSIntiharGirisimiNedenleriIntiharIzlemNedeni];

    }


}
