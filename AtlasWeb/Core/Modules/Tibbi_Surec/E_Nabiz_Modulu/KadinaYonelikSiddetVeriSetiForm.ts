//$F09CF4DD
import { Component, OnInit, NgZone  } from '@angular/core';
import { KadinaYonelikSiddetVeriSetiFormViewModel } from './KadinaYonelikSiddetVeriSetiFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { KadinaYonelikSiddetVeriSet } from 'NebulaClient/Model/AtlasClientModel';
import { KadinaYonelikSiddetSonuc } from 'NebulaClient/Model/AtlasClientModel';
import { KadinaYonelikSiddetTuru } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'KadinaYonelikSiddetVeriSetiForm',
    templateUrl: './KadinaYonelikSiddetVeriSetiForm.html',
    providers: [MessageService]
})
export class KadinaYonelikSiddetVeriSetiForm extends TTVisual.TTForm implements OnInit {
    KadinaYonelikSiddetSonuc: TTVisual.ITTGrid;
    KadinaYonelikSiddetTuru: TTVisual.ITTGrid;
    SKRSSiddetTuruKadinaYonelikSiddetTuru: TTVisual.ITTListBoxColumn;
    SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc: TTVisual.ITTListBoxColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    RouteData: any;
    RouteData2: any;
    public KadinaYonelikSiddetSonucColumns = [];
    public KadinaYonelikSiddetTuruColumns = [];
    public kadinaYonelikSiddetVeriSetiFormViewModel: KadinaYonelikSiddetVeriSetiFormViewModel = new KadinaYonelikSiddetVeriSetiFormViewModel();
    public get _KadinaYonelikSiddetVeriSet(): KadinaYonelikSiddetVeriSet {
        return this._TTObject as KadinaYonelikSiddetVeriSet;
    }
    private KadinaYonelikSiddetVeriSetiForm_DocumentUrl: string = '/api/KadinaYonelikSiddetVeriSetService/KadinaYonelikSiddetVeriSetiForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('KADINAYONELIKSIDDETVERISET', 'KadinaYonelikSiddetVeriSetiForm');
        this._DocumentServiceUrl = this.KadinaYonelikSiddetVeriSetiForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new KadinaYonelikSiddetVeriSet();
        this.kadinaYonelikSiddetVeriSetiFormViewModel = new KadinaYonelikSiddetVeriSetiFormViewModel();
        this._ViewModel = this.kadinaYonelikSiddetVeriSetiFormViewModel;
        this.kadinaYonelikSiddetVeriSetiFormViewModel._KadinaYonelikSiddetVeriSet = this._TTObject as KadinaYonelikSiddetVeriSet;
        this.kadinaYonelikSiddetVeriSetiFormViewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetTuru = new Array<KadinaYonelikSiddetTuru>();
        this.kadinaYonelikSiddetVeriSetiFormViewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetSonuc = new Array<KadinaYonelikSiddetSonuc>();
    }

    protected loadViewModel() {
        let that = this;
        that.kadinaYonelikSiddetVeriSetiFormViewModel = this._ViewModel as KadinaYonelikSiddetVeriSetiFormViewModel;
        that._TTObject = this.kadinaYonelikSiddetVeriSetiFormViewModel._KadinaYonelikSiddetVeriSet;
        if (this.kadinaYonelikSiddetVeriSetiFormViewModel == null)
            this.kadinaYonelikSiddetVeriSetiFormViewModel = new KadinaYonelikSiddetVeriSetiFormViewModel();
        if (this.kadinaYonelikSiddetVeriSetiFormViewModel._KadinaYonelikSiddetVeriSet == null)
            this.kadinaYonelikSiddetVeriSetiFormViewModel._KadinaYonelikSiddetVeriSet = new KadinaYonelikSiddetVeriSet();
        that.kadinaYonelikSiddetVeriSetiFormViewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetTuru = that.kadinaYonelikSiddetVeriSetiFormViewModel.KadinaYonelikSiddetTuruGridList;
        for (let detailItem of that.kadinaYonelikSiddetVeriSetiFormViewModel.KadinaYonelikSiddetTuruGridList) {
            let sKRSSiddetTuruObjectID = detailItem["SKRSSiddetTuru"];
            if (sKRSSiddetTuruObjectID != null && (typeof sKRSSiddetTuruObjectID === "string")) {
                let sKRSSiddetTuru = that.kadinaYonelikSiddetVeriSetiFormViewModel.SKRSSiddetTurus.find(o => o.ObjectID.toString() === sKRSSiddetTuruObjectID.toString());
                 if (sKRSSiddetTuru) {
                    detailItem.SKRSSiddetTuru = sKRSSiddetTuru;
                }
            }
        }
        that.kadinaYonelikSiddetVeriSetiFormViewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetSonuc = that.kadinaYonelikSiddetVeriSetiFormViewModel.KadinaYonelikSiddetSonucGridList;
        for (let detailItem of that.kadinaYonelikSiddetVeriSetiFormViewModel.KadinaYonelikSiddetSonucGridList) {
            let sKRSYonlendirmeDegerlendirmeObjectID = detailItem["SKRSYonlendirmeDegerlendirme"];
            if (sKRSYonlendirmeDegerlendirmeObjectID != null && (typeof sKRSYonlendirmeDegerlendirmeObjectID === "string")) {
                let sKRSYonlendirmeDegerlendirme = that.kadinaYonelikSiddetVeriSetiFormViewModel.SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirmes.find(o => o.ObjectID.toString() === sKRSYonlendirmeDegerlendirmeObjectID.toString());
                 if (sKRSYonlendirmeDegerlendirme) {
                    detailItem.SKRSYonlendirmeDegerlendirme = sKRSYonlendirmeDegerlendirme;
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
        await this.load(KadinaYonelikSiddetVeriSetiFormViewModel);
  
    }

    protected async PreScript() {
        let that = this;
        <Array<any>>this.RouteData.push(this.kadinaYonelikSiddetVeriSetiFormViewModel);
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Şiddet Sonucu Yönlendirme ve Değerlendirme";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 2;

        /*this.KadinaYonelikSiddetTuru = new TTVisual.TTGrid();
        this.KadinaYonelikSiddetTuru.Name = "KadinaYonelikSiddetTuru";
        this.KadinaYonelikSiddetTuru.TabIndex = 1;*/

        this.KadinaYonelikSiddetTuru = new TTVisual.TTGrid();
        this.KadinaYonelikSiddetTuru.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.KadinaYonelikSiddetTuru.Name = "KadinaYonelikSiddetTuru";
        this.KadinaYonelikSiddetTuru.TabIndex = 0;
        this.KadinaYonelikSiddetTuru.Height = "150px";
        this.KadinaYonelikSiddetTuru.ShowFilterCombo = true;
        this.KadinaYonelikSiddetTuru.FilterColumnName = "SKRSSiddetTuruKadinaYonelikSiddetTuru";
        this.KadinaYonelikSiddetTuru.FilterLabel = i18n("M22477", "Şiddet Türü");
        this.KadinaYonelikSiddetTuru.Filter = { ListDefName: "SKRSSiddetTuruList" };
        this.KadinaYonelikSiddetTuru.AllowUserToAddRows = false;
        this.KadinaYonelikSiddetTuru.DeleteButtonWidth = "5%";
        this.KadinaYonelikSiddetTuru.AllowUserToDeleteRows = true;
        this.KadinaYonelikSiddetTuru.IsFilterLabelSingleLine = false;


        this.SKRSSiddetTuruKadinaYonelikSiddetTuru = new TTVisual.TTListBoxColumn();
        this.SKRSSiddetTuruKadinaYonelikSiddetTuru.ListDefName = "SKRSSiddetTuruList";
        this.SKRSSiddetTuruKadinaYonelikSiddetTuru.DataMember = "SKRSSiddetTuru";
        this.SKRSSiddetTuruKadinaYonelikSiddetTuru.DisplayIndex = 0;
        this.SKRSSiddetTuruKadinaYonelikSiddetTuru.HeaderText = i18n("M22477", "Şiddet Türü");
        this.SKRSSiddetTuruKadinaYonelikSiddetTuru.Name = "SKRSSiddetTuruKadinaYonelikSiddetTuru";
        this.SKRSSiddetTuruKadinaYonelikSiddetTuru.Width = 450;

        /*this.KadinaYonelikSiddetSonuc = new TTVisual.TTGrid();
        this.KadinaYonelikSiddetSonuc.Name = "KadinaYonelikSiddetSonuc";
        this.KadinaYonelikSiddetSonuc.TabIndex = 0;*/

        this.KadinaYonelikSiddetSonuc = new TTVisual.TTGrid();
        this.KadinaYonelikSiddetSonuc.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.KadinaYonelikSiddetSonuc.Name = "KadinaYonelikSiddetSonuc";
        this.KadinaYonelikSiddetSonuc.TabIndex = 0;
        this.KadinaYonelikSiddetSonuc.Height = "150px";
        this.KadinaYonelikSiddetSonuc.ShowFilterCombo = true;
        this.KadinaYonelikSiddetSonuc.FilterColumnName = "SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc";
        this.KadinaYonelikSiddetSonuc.FilterLabel = i18n("M30543", "Yönlendirme ve Değerlendirme");
        this.KadinaYonelikSiddetSonuc.Filter = { ListDefName: "SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlen" };
        this.KadinaYonelikSiddetSonuc.AllowUserToAddRows = false;
        this.KadinaYonelikSiddetSonuc.DeleteButtonWidth = "5%";
        this.KadinaYonelikSiddetSonuc.AllowUserToDeleteRows = true;
        this.KadinaYonelikSiddetSonuc.IsFilterLabelSingleLine = false;

        this.SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc = new TTVisual.TTListBoxColumn();
        this.SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc.ListDefName = "SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlen";
        this.SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc.DataMember = "SKRSYonlendirmeDegerlendirme";
        this.SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc.DisplayIndex = 0;
        this.SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc.HeaderText = i18n("M30543", "Yönlendirme ve Değerlendirme");
        this.SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc.Name = "SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc";
        this.SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc.Width = 450;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "Şiddet Türü Bilgisi";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 7;

        this.KadinaYonelikSiddetTuruColumns = [this.SKRSSiddetTuruKadinaYonelikSiddetTuru];
        this.KadinaYonelikSiddetSonucColumns = [this.SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc];
        this.Controls = [this.ttlabel1, this.KadinaYonelikSiddetTuru, this.SKRSSiddetTuruKadinaYonelikSiddetTuru, this.KadinaYonelikSiddetSonuc, this.SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc, this.ttlabel7];

    }


}
