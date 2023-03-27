//$BA7F84E8
import { Component, OnInit, NgZone } from '@angular/core';
import { KuduzProfilaksiIzlemFormViewModel } from './KuduzProfilaksiIzlemFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { KuduzProfilaksiVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { KuduzProfilaksiAdres } from 'NebulaClient/Model/AtlasClientModel';
import { KuduzProfilaksiTelefon } from 'NebulaClient/Model/AtlasClientModel';
import { KuduzProfilaksiUygProfilak } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKuduzProfilaksisiTamamlanmaDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { SKRSImmunglobulinTuru } from "NebulaClient/Model/AtlasClientModel";

@Component({
    selector: 'KuduzProfilaksiIzlemForm',
    templateUrl: './KuduzProfilaksiIzlemForm.html',
    providers: [MessageService]
})
export class KuduzProfilaksiIzlemForm extends TTVisual.TTForm implements OnInit {

    ImmunglobulinMiktari: TTVisual.ITTTextBox;
    Kilo: TTVisual.ITTTextBox;
   
    KuduzProfilaksiUygProfilak: TTVisual.ITTGrid;
    labelImmunglobulinMiktari: TTVisual.ITTLabel;
    labelKilo: TTVisual.ITTLabel;
    labelSKRSKuduzProfilaksiTamamlanma: TTVisual.ITTLabel;
    SKRSKuduzProfilaksiTamamlanma: TTVisual.ITTObjectListBox;
    SKRSImmunglobulinTuru: TTVisual.ITTObjectListBox;
    SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak: TTVisual.ITTListBoxColumn;

    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    RouteData: any;
    RouteData2: any;

    private telefonTipiArray: Array<any> = [];
    private TelefonTipiCache: any;
    public KuduzProfilaksiAdresColumns = [];
    public KuduzProfilaksiTelefonColumns = [];
    public KuduzProfilaksiUygProfilakColumns = [];
    public kuduzProfilaksiIzlemFormViewModel: KuduzProfilaksiIzlemFormViewModel = new KuduzProfilaksiIzlemFormViewModel();
    public get _KuduzProfilaksiVeriSeti(): KuduzProfilaksiVeriSeti {
        return this._TTObject as KuduzProfilaksiVeriSeti;
    }
    private KuduzProfilaksiIzlemForm_DocumentUrl: string = '/api/KuduzProfilaksiVeriSetiService/KuduzProfilaksiIzlemForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('KUDUZPROFILAKSIVERISETI', 'KuduzProfilaksiIzlemForm');
        this._DocumentServiceUrl = this.KuduzProfilaksiIzlemForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new KuduzProfilaksiVeriSeti();
        this.kuduzProfilaksiIzlemFormViewModel = new KuduzProfilaksiIzlemFormViewModel();
        this._ViewModel = this.kuduzProfilaksiIzlemFormViewModel;
        this.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti = this._TTObject as KuduzProfilaksiVeriSeti;
        this.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma = new SKRSKuduzProfilaksisiTamamlanmaDurumu();
        this.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti.SKRSImmunglobulinTuru = new SKRSImmunglobulinTuru();
        this.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti.KuduzProfilaksiUygProfilak = new Array<KuduzProfilaksiUygProfilak>();
      
    }

    protected loadViewModel() {
        let that = this;
        that.kuduzProfilaksiIzlemFormViewModel = this._ViewModel as KuduzProfilaksiIzlemFormViewModel;
        that._TTObject = this.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti;
        if (this.kuduzProfilaksiIzlemFormViewModel == null)
            this.kuduzProfilaksiIzlemFormViewModel = new KuduzProfilaksiIzlemFormViewModel();
        if (this.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti == null)
            this.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti = new KuduzProfilaksiVeriSeti();
        let sKRSKuduzProfilaksiTamamlanmaObjectID = that.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti["SKRSKuduzProfilaksiTamamlanma"];
        if (sKRSKuduzProfilaksiTamamlanmaObjectID != null && (typeof sKRSKuduzProfilaksiTamamlanmaObjectID === "string")) {
            let sKRSKuduzProfilaksiTamamlanma = that.kuduzProfilaksiIzlemFormViewModel.SKRSKuduzProfilaksisiTamamlanmaDurumus.find(o => o.ObjectID.toString() === sKRSKuduzProfilaksiTamamlanmaObjectID.toString());
             if (sKRSKuduzProfilaksiTamamlanma) {
                that.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma = sKRSKuduzProfilaksiTamamlanma;
            }
        }

        let sKRSImmunoglobulinObjectID = that.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti["SKRSImmunglobulinTuru"];
        if (sKRSImmunoglobulinObjectID != null && (typeof sKRSImmunoglobulinObjectID === "string")) {
            let sKRSImmunglobulinTuru = that.kuduzProfilaksiIzlemFormViewModel.SKRSImmunglobulinTurus.find(o => o.ObjectID.toString() === sKRSImmunoglobulinObjectID.toString());
            if (sKRSImmunglobulinTuru) {
                that.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti.SKRSImmunglobulinTuru = sKRSImmunglobulinTuru;
            }
        }

        that.kuduzProfilaksiIzlemFormViewModel._KuduzProfilaksiVeriSeti.KuduzProfilaksiUygProfilak = that.kuduzProfilaksiIzlemFormViewModel.KuduzProfilaksiUygProfilakGridList;
        for (let detailItem of that.kuduzProfilaksiIzlemFormViewModel.KuduzProfilaksiUygProfilakGridList) {
            let sKRSUygulananKuduzProfilaksiObjectID = detailItem["SKRSUygulananKuduzProfilaksi"];
            if (sKRSUygulananKuduzProfilaksiObjectID != null && (typeof sKRSUygulananKuduzProfilaksiObjectID === "string")) {
                let sKRSUygulananKuduzProfilaksi = that.kuduzProfilaksiIzlemFormViewModel.SKRSUygulananKuduzProfilaksisis.find(o => o.ObjectID.toString() === sKRSUygulananKuduzProfilaksiObjectID.toString());
                 if (sKRSUygulananKuduzProfilaksi) {
                    detailItem.SKRSUygulananKuduzProfilaksi = sKRSUygulananKuduzProfilaksi;
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
        
        //that.telefonTipiArray = await this.TelefonTipi();
        //that.GenerateTelListColumns();
        await this.load(KuduzProfilaksiIzlemFormViewModel);
  
    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.kuduzProfilaksiIzlemFormViewModel);


    }
    public onImmunglobulinMiktariChanged(event): void {
        if (event != null) {
            if (this._KuduzProfilaksiVeriSeti != null && this._KuduzProfilaksiVeriSeti.ImmunglobulinMiktari != event) {
                this._KuduzProfilaksiVeriSeti.ImmunglobulinMiktari = event;
            }
        }
    }

    public onKiloChanged(event): void {
        if (event != null) {
            if (this._KuduzProfilaksiVeriSeti != null && this._KuduzProfilaksiVeriSeti.Kilo != event) {
                this._KuduzProfilaksiVeriSeti.Kilo = event;
            }
        }
    }

    public onSKRSKuduzProfilaksiTamamlanmaChanged(event): void {
        if (event != null) {
            if (this._KuduzProfilaksiVeriSeti != null && this._KuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma != event) {
                this._KuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma = event;
            }
        }
    }

    public onSKRSImmunglobulinTuruChanged(event): void {
        if (event != null) {
            if (this._KuduzProfilaksiVeriSeti != null && this._KuduzProfilaksiVeriSeti.SKRSImmunglobulinTuru != event) {
                this._KuduzProfilaksiVeriSeti.SKRSImmunglobulinTuru = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.Kilo, "Text", this.__ttObject, "Kilo");
        redirectProperty(this.ImmunglobulinMiktari, "Text", this.__ttObject, "ImmunglobulinMiktari");
    }

    public initFormControls(): void {
        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Adres";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 9;

        this.labelSKRSKuduzProfilaksiTamamlanma = new TTVisual.TTLabel();
        this.labelSKRSKuduzProfilaksiTamamlanma.Text = "Kuduz Profilaksi Tamamlanma Durumu";
        this.labelSKRSKuduzProfilaksiTamamlanma.Name = "labelSKRSKuduzProfilaksiTamamlanma";
        this.labelSKRSKuduzProfilaksiTamamlanma.TabIndex = 8;


        this.SKRSKuduzProfilaksiTamamlanma = new TTVisual.TTObjectListBox();
        this.SKRSKuduzProfilaksiTamamlanma.ListDefName = "SKRSKuduzProfilaksisiTamamlanmaDurumuList";
        this.SKRSKuduzProfilaksiTamamlanma.Name = "SKRSKuduzProfilaksiTamamlanma";
        this.SKRSKuduzProfilaksiTamamlanma.TabIndex = 7;

        this.SKRSImmunglobulinTuru = new TTVisual.TTObjectListBox();
        this.SKRSImmunglobulinTuru.ListDefName = "SKRSImmunglobulinTuruList";
        this.SKRSImmunglobulinTuru.Name = "SKRSImmunglobulinTuru";
        this.SKRSImmunglobulinTuru.TabIndex = 7;

        /* this.KuduzProfilaksiUygProfilak = new TTVisual.TTGrid();
         this.KuduzProfilaksiUygProfilak.Name = "KuduzProfilaksiUygProfilak";
         this.KuduzProfilaksiUygProfilak.TabIndex = 6;
 */

        this.KuduzProfilaksiUygProfilak = new TTVisual.TTGrid();
        this.KuduzProfilaksiUygProfilak.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.KuduzProfilaksiUygProfilak.Name = "KuduzProfilaksiUygProfilak";
        this.KuduzProfilaksiUygProfilak.TabIndex = 0;
        this.KuduzProfilaksiUygProfilak.Height = "150px";
        this.KuduzProfilaksiUygProfilak.ShowFilterCombo = true;
        this.KuduzProfilaksiUygProfilak.FilterColumnName = "SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak";
        this.KuduzProfilaksiUygProfilak.FilterLabel = i18n("M23785", "Uygulanan Kuduz Profilaksisi");
        this.KuduzProfilaksiUygProfilak.Filter = { ListDefName: "SKRSUygulananKuduzProfilaksisiList" };
        this.KuduzProfilaksiUygProfilak.AllowUserToAddRows = false;
        this.KuduzProfilaksiUygProfilak.DeleteButtonWidth = "5%";
        this.KuduzProfilaksiUygProfilak.AllowUserToDeleteRows = true;
        this.KuduzProfilaksiUygProfilak.IsFilterLabelSingleLine = true;

        this.SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak = new TTVisual.TTListBoxColumn();
        this.SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak.ListDefName = "SKRSUygulananKuduzProfilaksisiList";
        this.SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak.DataMember = "SKRSUygulananKuduzProfilaksi";
        this.SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak.DisplayIndex = 0;
        this.SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak.HeaderText = i18n("M23785", "Uygulanan Kuduz Profilaksisi");
        this.SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak.Name = "SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak";
        this.SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak.Width = 500;

        /*this.KuduzProfilaksiTelefon = new TTVisual.TTGrid();
        this.KuduzProfilaksiTelefon.Name = "KuduzProfilaksiTelefon";
        this.KuduzProfilaksiTelefon.TabIndex = 5;
*/

      

        /*this.KuduzProfilaksiAdres = new TTVisual.TTGrid();
        this.KuduzProfilaksiAdres.Name = "KuduzProfilaksiAdres";
        this.KuduzProfilaksiAdres.TabIndex = 4;*/


        this.labelImmunglobulinMiktari = new TTVisual.TTLabel();
        this.labelImmunglobulinMiktari.Text = "İmmünglobulin Miktarı";
        this.labelImmunglobulinMiktari.Name = "labelImmunglobulinMiktari";
        this.labelImmunglobulinMiktari.TabIndex = 3;

        this.ImmunglobulinMiktari = new TTVisual.TTTextBox();
        this.ImmunglobulinMiktari.Name = "ImmunglobulinMiktari";
        this.ImmunglobulinMiktari.TabIndex = 2;

        this.Kilo = new TTVisual.TTTextBox();
        this.Kilo.Name = "Kilo";
        this.Kilo.TabIndex = 0;

        this.labelKilo = new TTVisual.TTLabel();
        this.labelKilo.Text = "Kilo";
        this.labelKilo.Name = "labelKilo";
        this.labelKilo.TabIndex = 1;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Telefon";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 9;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M23785", "Uygulanan Kuduz Profilaksisi");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 9;

        this.KuduzProfilaksiUygProfilakColumns = [this.SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak];
      
        this.Controls = [this.ttlabel4, this.labelSKRSKuduzProfilaksiTamamlanma, this.SKRSKuduzProfilaksiTamamlanma, this.SKRSImmunglobulinTuru, this.KuduzProfilaksiUygProfilak, this.SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak,  this.labelImmunglobulinMiktari, this.ImmunglobulinMiktari, this.Kilo, this.labelKilo, this.ttlabel5, this.ttlabel6];

    }

    private GenerateTelListColumns() {
        let that = this;

        this.KuduzProfilaksiTelefonColumns = [
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
    private async TelefonTipi(): Promise<any> {
        if (!this.TelefonTipiCache) {
            this.TelefonTipiCache = await this.httpService.get('/api/BulasiciHastalikVeriSetiService/GetSKRSTelefonTipi'); //Aynı skrs objecti kullanıyor
            return this.TelefonTipiCache;
        }
        else {
            return this.TelefonTipiCache;
        }
    }
}
