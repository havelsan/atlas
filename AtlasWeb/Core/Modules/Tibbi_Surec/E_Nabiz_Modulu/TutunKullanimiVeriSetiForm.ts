//$2F4C169B
import { Component, OnInit, NgZone } from '@angular/core';
import { TutunKullanimiVeriSetiFormViewModel } from './TutunKullanimiVeriSetiFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TutunKullanimiVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigaraKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTutunDumaninaMaruzKalmaPasificicilik } from 'NebulaClient/Model/AtlasClientModel';
import { TutunKullanimiBagimOldUrun } from 'NebulaClient/Model/AtlasClientModel';
import { TutunKullanimiTedaviSekli } from 'NebulaClient/Model/AtlasClientModel';
import { TutunKullanimiTedaviSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'TutunKullanimiVeriSetiForm',
    templateUrl: './TutunKullanimiVeriSetiForm.html',
    providers: [MessageService]
})
export class TutunKullanimiVeriSetiForm extends TTVisual.TTForm implements OnInit {
    labelSigaraAdedi: TTVisual.ITTLabel;
    labelSKRSSigaraKullanimi: TTVisual.ITTLabel;
    labelSKRSTutunDumaninaMaruzKalma: TTVisual.ITTLabel;
    SigaraAdedi: TTVisual.ITTTextBox;
    SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun: TTVisual.ITTListBoxColumn;
    SKRSSigaraKullanimi: TTVisual.ITTObjectListBox;
    SKRSTedaviSekliTutunKullanimiTedaviSekli: TTVisual.ITTListBoxColumn;
    SKRSTutunDumaninaMaruzKalma: TTVisual.ITTObjectListBox;
    SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu: TTVisual.ITTListBoxColumn;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    TutunKullanimiBagimOldUrun: TTVisual.ITTGrid;
    TutunKullanimiTedaviSekli: TTVisual.ITTGrid;
    TutunKullanimiTedaviSonucu: TTVisual.ITTGrid;
    public TutunKullanimiBagimOldUrunColumns = [];
    public TutunKullanimiTedaviSekliColumns = [];
    public TutunKullanimiTedaviSonucuColumns = [];
    public RouteData: any ;
    public RouteData2: any ;
    public tutunKullanimiVeriSetiFormViewModel: TutunKullanimiVeriSetiFormViewModel = new TutunKullanimiVeriSetiFormViewModel();
    public get _TutunKullanimiVeriSeti(): TutunKullanimiVeriSeti {
        return this._TTObject as TutunKullanimiVeriSeti;
    }
    private TutunKullanimiVeriSetiForm_DocumentUrl: string = '/api/TutunKullanimiVeriSetiService/TutunKullanimiVeriSetiForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('TUTUNKULLANIMIVERISETI', 'TutunKullanimiVeriSetiForm');
        this._DocumentServiceUrl = this.TutunKullanimiVeriSetiForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new TutunKullanimiVeriSeti();
        this.tutunKullanimiVeriSetiFormViewModel = new TutunKullanimiVeriSetiFormViewModel();
        this._ViewModel = this.tutunKullanimiVeriSetiFormViewModel;
        this.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti = this._TTObject as TutunKullanimiVeriSeti;
        this.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.SKRSTutunDumaninaMaruzKalma = new SKRSTutunDumaninaMaruzKalmaPasificicilik();
        this.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.SKRSSigaraKullanimi = new SKRSSigaraKullanimi();
        this.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.TutunKullanimiTedaviSonucu = new Array<TutunKullanimiTedaviSonucu>();
        this.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.TutunKullanimiTedaviSekli = new Array<TutunKullanimiTedaviSekli>();
        this.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.TutunKullanimiBagimOldUrun = new Array<TutunKullanimiBagimOldUrun>();
        
    }

    protected loadViewModel() {
        let that = this;
        that.tutunKullanimiVeriSetiFormViewModel = this._ViewModel as TutunKullanimiVeriSetiFormViewModel;
        that._TTObject = this.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti;
        if (this.tutunKullanimiVeriSetiFormViewModel == null)
            this.tutunKullanimiVeriSetiFormViewModel = new TutunKullanimiVeriSetiFormViewModel();
        if (this.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti == null)
            this.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti = new TutunKullanimiVeriSeti();
        let sKRSTutunDumaninaMaruzKalmaObjectID = that.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti["SKRSTutunDumaninaMaruzKalma"];
        if (sKRSTutunDumaninaMaruzKalmaObjectID != null && (typeof sKRSTutunDumaninaMaruzKalmaObjectID === "string")) {
            let sKRSTutunDumaninaMaruzKalma = that.tutunKullanimiVeriSetiFormViewModel.SKRSTutunDumaninaMaruzKalmaPasificiciliks.find(o => o.ObjectID.toString() === sKRSTutunDumaninaMaruzKalmaObjectID.toString());
             if (sKRSTutunDumaninaMaruzKalma) {
                that.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.SKRSTutunDumaninaMaruzKalma = sKRSTutunDumaninaMaruzKalma;
            }
        }
        let sKRSSigaraKullanimiObjectID = that.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti["SKRSSigaraKullanimi"];
        if (sKRSSigaraKullanimiObjectID != null && (typeof sKRSSigaraKullanimiObjectID === "string")) {
            let sKRSSigaraKullanimi = that.tutunKullanimiVeriSetiFormViewModel.SKRSSigaraKullanimis.find(o => o.ObjectID.toString() === sKRSSigaraKullanimiObjectID.toString());
             if (sKRSSigaraKullanimi) {
                that.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.SKRSSigaraKullanimi = sKRSSigaraKullanimi;
            }
        }
        that.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.TutunKullanimiTedaviSonucu = that.tutunKullanimiVeriSetiFormViewModel.TutunKullanimiTedaviSonucuGridList;
        for (let detailItem of that.tutunKullanimiVeriSetiFormViewModel.TutunKullanimiTedaviSonucuGridList) {
            let sKRSTutunTedaviSonucuObjectID = detailItem["SKRSTutunTedaviSonucu"];
            if (sKRSTutunTedaviSonucuObjectID != null && (typeof sKRSTutunTedaviSonucuObjectID === "string")) {
                let sKRSTutunTedaviSonucu = that.tutunKullanimiVeriSetiFormViewModel.SKRSTutunTedaviSonucus.find(o => o.ObjectID.toString() === sKRSTutunTedaviSonucuObjectID.toString());
                 if (sKRSTutunTedaviSonucu) {
                    detailItem.SKRSTutunTedaviSonucu = sKRSTutunTedaviSonucu;
                }
            }
        }
        that.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.TutunKullanimiTedaviSekli = that.tutunKullanimiVeriSetiFormViewModel.TutunKullanimiTedaviSekliGridList;
        for (let detailItem of that.tutunKullanimiVeriSetiFormViewModel.TutunKullanimiTedaviSekliGridList) {
            let sKRSTedaviSekliObjectID = detailItem["SKRSTedaviSekli"];
            if (sKRSTedaviSekliObjectID != null && (typeof sKRSTedaviSekliObjectID === "string")) {
                let sKRSTedaviSekli = that.tutunKullanimiVeriSetiFormViewModel.SKRSTedaviSeklis.find(o => o.ObjectID.toString() === sKRSTedaviSekliObjectID.toString());
                 if (sKRSTedaviSekli) {
                    detailItem.SKRSTedaviSekli = sKRSTedaviSekli;
                }
            }
        }
        that.tutunKullanimiVeriSetiFormViewModel._TutunKullanimiVeriSeti.TutunKullanimiBagimOldUrun = that.tutunKullanimiVeriSetiFormViewModel.TutunKullanimiBagimOldUrunGridList;
        for (let detailItem of that.tutunKullanimiVeriSetiFormViewModel.TutunKullanimiBagimOldUrunGridList) {
            let sKRSBagimliOlduguUrunObjectID = detailItem["SKRSBagimliOlduguUrun"];
            if (sKRSBagimliOlduguUrunObjectID != null && (typeof sKRSBagimliOlduguUrunObjectID === "string")) {
                let sKRSBagimliOlduguUrun = that.tutunKullanimiVeriSetiFormViewModel.SKRSBagimliOlduguUruns.find(o => o.ObjectID.toString() === sKRSBagimliOlduguUrunObjectID.toString());
                 if (sKRSBagimliOlduguUrun) {
                    detailItem.SKRSBagimliOlduguUrun = sKRSBagimliOlduguUrun;
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
        await this.load(TutunKullanimiVeriSetiFormViewModel);
  
    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.tutunKullanimiVeriSetiFormViewModel);


    }



    public onSigaraAdediChanged(event): void {
        if (event != null) {
            if (this._TutunKullanimiVeriSeti != null && this._TutunKullanimiVeriSeti.SigaraAdedi != event) {
                this._TutunKullanimiVeriSeti.SigaraAdedi = event;
            }
        }
    }

    public onSKRSSigaraKullanimiChanged(event): void {
        if (event != null) {
            if (this._TutunKullanimiVeriSeti != null && this._TutunKullanimiVeriSeti.SKRSSigaraKullanimi != event) {
                this._TutunKullanimiVeriSeti.SKRSSigaraKullanimi = event;
            }
        }
    }

    public onSKRSTutunDumaninaMaruzKalmaChanged(event): void {
        if (event != null) {
            if (this._TutunKullanimiVeriSeti != null && this._TutunKullanimiVeriSeti.SKRSTutunDumaninaMaruzKalma != event) {
                this._TutunKullanimiVeriSeti.SKRSTutunDumaninaMaruzKalma = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.SigaraAdedi, "Text", this.__ttObject, "SigaraAdedi");
    }

    public initFormControls(): void {
        this.labelSKRSTutunDumaninaMaruzKalma = new TTVisual.TTLabel();
        this.labelSKRSTutunDumaninaMaruzKalma.Text = "Tütün Dumanına Maruz Kalma";
        this.labelSKRSTutunDumaninaMaruzKalma.Name = "labelSKRSTutunDumaninaMaruzKalma";
        this.labelSKRSTutunDumaninaMaruzKalma.TabIndex = 8;

        this.SKRSTutunDumaninaMaruzKalma = new TTVisual.TTObjectListBox();
        this.SKRSTutunDumaninaMaruzKalma.ListDefName = "SKRSTutunDumaninaMaruzKalmaPasificicilikList";
        this.SKRSTutunDumaninaMaruzKalma.Name = "SKRSTutunDumaninaMaruzKalma";
        this.SKRSTutunDumaninaMaruzKalma.TabIndex = 7;

        this.labelSKRSSigaraKullanimi = new TTVisual.TTLabel();
        this.labelSKRSSigaraKullanimi.Text = i18n("M21841", "Sigara Kullanımı");
        this.labelSKRSSigaraKullanimi.Name = "labelSKRSSigaraKullanimi";
        this.labelSKRSSigaraKullanimi.TabIndex = 6;

        this.SKRSSigaraKullanimi = new TTVisual.TTObjectListBox();
        this.SKRSSigaraKullanimi.ListDefName = "SKRSSigaraKullanimiList";
        this.SKRSSigaraKullanimi.Name = "SKRSSigaraKullanimi";
        this.SKRSSigaraKullanimi.TabIndex = 5;

        /*this.TutunKullanimiTedaviSonucu = new TTVisual.TTGrid();
        this.TutunKullanimiTedaviSonucu.Name = "TutunKullanimiTedaviSonucu";
        this.TutunKullanimiTedaviSonucu.TabIndex = 4;*/

        this.TutunKullanimiTedaviSonucu = new TTVisual.TTGrid();
        this.TutunKullanimiTedaviSonucu.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TutunKullanimiTedaviSonucu.Name = "TutunKullanimiTedaviSonucu";
        this.TutunKullanimiTedaviSonucu.TabIndex = 0;
        this.TutunKullanimiTedaviSonucu.Height = "150px";
        this.TutunKullanimiTedaviSonucu.ShowFilterCombo = true;
        this.TutunKullanimiTedaviSonucu.FilterColumnName = "SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu";
        this.TutunKullanimiTedaviSonucu.FilterLabel = i18n("M23023", "Tedavi Sonucu");
        this.TutunKullanimiTedaviSonucu.Filter = { ListDefName: "SKRSTutunTedaviSonucuList" };
        this.TutunKullanimiTedaviSonucu.AllowUserToAddRows = false;
        this.TutunKullanimiTedaviSonucu.DeleteButtonWidth = "5%";
        this.TutunKullanimiTedaviSonucu.AllowUserToDeleteRows = true;
        this.TutunKullanimiTedaviSonucu.IsFilterLabelSingleLine = false;

        this.SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu = new TTVisual.TTListBoxColumn();
        this.SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu.ListDefName = "SKRSTutunTedaviSonucuList";
        this.SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu.DataMember = "SKRSTutunTedaviSonucu";
        this.SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu.DisplayIndex = 0;
        this.SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu.HeaderText = i18n("M23023", "Tedavi Sonucu");
        this.SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu.Name = "SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu";
        this.SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu.Width = 300;

        /*this.TutunKullanimiTedaviSekli = new TTVisual.TTGrid();
        this.TutunKullanimiTedaviSekli.Name = "TutunKullanimiTedaviSekli";
        this.TutunKullanimiTedaviSekli.TabIndex = 3;*/

        this.TutunKullanimiTedaviSekli = new TTVisual.TTGrid();
        this.TutunKullanimiTedaviSekli.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TutunKullanimiTedaviSekli.Name = "TutunKullanimiTedaviSekli";
        this.TutunKullanimiTedaviSekli.TabIndex = 0;
        this.TutunKullanimiTedaviSekli.Height = "150px";
        this.TutunKullanimiTedaviSekli.ShowFilterCombo = true;
        this.TutunKullanimiTedaviSekli.FilterColumnName = "SKRSTedaviSekliTutunKullanimiTedaviSekli";
        this.TutunKullanimiTedaviSekli.FilterLabel = i18n("M23030", "Tedavi Şekli");
        this.TutunKullanimiTedaviSekli.Filter = { ListDefName: "SKRSTedaviSekliList" };
        this.TutunKullanimiTedaviSekli.AllowUserToAddRows = false;
        this.TutunKullanimiTedaviSekli.DeleteButtonWidth = "5%";
        this.TutunKullanimiTedaviSekli.AllowUserToDeleteRows = true;
        this.TutunKullanimiTedaviSekli.IsFilterLabelSingleLine = false;

        this.SKRSTedaviSekliTutunKullanimiTedaviSekli = new TTVisual.TTListBoxColumn();
        this.SKRSTedaviSekliTutunKullanimiTedaviSekli.ListDefName = "SKRSTedaviSekliList";
        this.SKRSTedaviSekliTutunKullanimiTedaviSekli.DataMember = "SKRSTedaviSekli";
        this.SKRSTedaviSekliTutunKullanimiTedaviSekli.DisplayIndex = 0;
        this.SKRSTedaviSekliTutunKullanimiTedaviSekli.HeaderText = i18n("M23030", "Tedavi Şekli");
        this.SKRSTedaviSekliTutunKullanimiTedaviSekli.Name = "SKRSTedaviSekliTutunKullanimiTedaviSekli";
        this.SKRSTedaviSekliTutunKullanimiTedaviSekli.Width = 300;

        /*this.TutunKullanimiBagimOldUrun = new TTVisual.TTGrid();
        this.TutunKullanimiBagimOldUrun.Name = "TutunKullanimiBagimOldUrun";
        this.TutunKullanimiBagimOldUrun.TabIndex = 2;*/

        this.TutunKullanimiBagimOldUrun = new TTVisual.TTGrid();
        this.TutunKullanimiBagimOldUrun.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TutunKullanimiBagimOldUrun.Name = "TutunKullanimiBagimOldUrun";
        this.TutunKullanimiBagimOldUrun.TabIndex = 0;
        this.TutunKullanimiBagimOldUrun.Height = "150px";
        this.TutunKullanimiBagimOldUrun.ShowFilterCombo = true;
        this.TutunKullanimiBagimOldUrun.FilterColumnName = "SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun";
        this.TutunKullanimiBagimOldUrun.FilterLabel = i18n("M30541", "Bağımlı Olduğu Ürün");
        this.TutunKullanimiBagimOldUrun.Filter = { ListDefName: "SKRSBagimliOlduguUrunList" };
        this.TutunKullanimiBagimOldUrun.AllowUserToAddRows = false;
        this.TutunKullanimiBagimOldUrun.DeleteButtonWidth = "5%";
        this.TutunKullanimiBagimOldUrun.AllowUserToDeleteRows = true;
        this.TutunKullanimiBagimOldUrun.IsFilterLabelSingleLine = false;

        this.SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun = new TTVisual.TTListBoxColumn();
        this.SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun.ListDefName = "SKRSBagimliOlduguUrunList";
        this.SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun.DataMember = "SKRSBagimliOlduguUrun";
        this.SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun.DisplayIndex = 0;
        this.SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun.HeaderText = i18n("M30541", "Bağımlı Olduğu Ürün");
        this.SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun.Name = "SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun";
        this.SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun.Width = 300;

        this.labelSigaraAdedi = new TTVisual.TTLabel();
        this.labelSigaraAdedi.Text = "Sigara Adedi";
        this.labelSigaraAdedi.Name = "labelSigaraAdedi";
        this.labelSigaraAdedi.TabIndex = 1;

        this.SigaraAdedi = new TTVisual.TTTextBox();
        this.SigaraAdedi.Name = "SigaraAdedi";
        this.SigaraAdedi.TabIndex = 0;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Bağımlı Olduğu Ürün";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 8;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M23030", "Tedavi Şekli");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 8;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M23023", "Tedavi Sonucu");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 8;

        this.TutunKullanimiTedaviSonucuColumns = [this.SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu];
        this.TutunKullanimiTedaviSekliColumns = [this.SKRSTedaviSekliTutunKullanimiTedaviSekli];
        this.TutunKullanimiBagimOldUrunColumns = [this.SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun];
        this.Controls = [this.labelSKRSTutunDumaninaMaruzKalma, this.SKRSTutunDumaninaMaruzKalma, this.labelSKRSSigaraKullanimi, this.SKRSSigaraKullanimi, this.TutunKullanimiTedaviSonucu, this.SKRSTutunTedaviSonucuTutunKullanimiTedaviSonucu, this.TutunKullanimiTedaviSekli, this.SKRSTedaviSekliTutunKullanimiTedaviSekli, this.TutunKullanimiBagimOldUrun, this.SKRSBagimliOlduguUrunTutunKullanimiBagimOldUrun, this.labelSigaraAdedi, this.SigaraAdedi, this.ttlabel4, this.ttlabel5, this.ttlabel6];

    }


}
