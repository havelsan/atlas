//$D87A613A
import { Component, OnInit, NgZone } from '@angular/core';
import { MKYSExcessFormViewModel } from './MKYSExcessFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { City } from 'NebulaClient/Model/AtlasClientModel';
import { MkysServis } from 'NebulaClient/Services/External/MkysServis';
import { SupplyRequestPoolDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'MKYSExcessForm',
    templateUrl: './MKYSExcessForm.html',
    providers: [MessageService]
})
export class MKYSExcessForm extends TTVisual.TTForm implements OnInit {
    adeti: TTVisual.ITTTextBoxColumn;
    birimAdi: TTVisual.ITTTextBoxColumn;
    birimTextBox: TTVisual.ITTTextBox;
    btnExcessQuery: TTVisual.ITTButton;
    CityListBox: TTVisual.ITTObjectListBox;
    CodePurchaseGroup: TTVisual.ITTTextBox;
    ihtiyacFazlasiItemsGrid: TTVisual.ITTGrid;
    ilAdi: TTVisual.ITTTextBoxColumn;
    ilKodu: TTVisual.ITTTextBoxColumn;
    malzemeAdi: TTVisual.ITTTextBoxColumn;
    malzemeDigerAciklama: TTVisual.ITTTextBoxColumn;
    malzemeKodu: TTVisual.ITTTextBoxColumn;
    NamePurchaseGroup: TTVisual.ITTTextBox;
    siraNo: TTVisual.ITTTextBoxColumn;
    tarih: TTVisual.ITTDateTimePickerColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    vergiliBirimFiyat: TTVisual.ITTTextBoxColumn;
    public ihtiyacFazlasiItemsGridColumns = [];
    public mKYSExcessFormViewModel: MKYSExcessFormViewModel = new MKYSExcessFormViewModel();
    public get _SupplyRequestPoolDetail(): SupplyRequestPoolDetail {
        return this._TTObject as SupplyRequestPoolDetail;
    }
    private MKYSExcessForm_DocumentUrl: string = '/api/SupplyRequestPoolDetailService/MKYSExcessForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('SUPPLYREQUESTPOOLDETAIL', 'MKYSExcessForm');
        this._DocumentServiceUrl = this.MKYSExcessForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async btnExcessQuery_Click(): Promise<void> {
        let kriter: MkysServis.ihtiyacFazlasiKriterItem = new MkysServis.ihtiyacFazlasiKriterItem();
        if (this.CityListBox.SelectedObject !== null) {
            let city: City = <City>this.CityListBox.SelectedObject;
            kriter.ilAdi = city.Name;
        }
        if (!String.isNullOrEmpty(this.birimTextBox.Text)) {
            kriter.birimAdi = this.birimTextBox.Text;
        }
        kriter.malzemeAdi = this.NamePurchaseGroup.Text;
        kriter.malzemeKodu = this.CodePurchaseGroup.Text;
        let items: MkysServis.ihtiyacFazlasiItem[]; // =  await MkysServis.WebMethods.ihtiyacFazlasiGetDataSync(Sites.SiteLocalHost, kriter);
        for (let sinif of items) {
            let addedRow: TTVisual.ITTGridRow = this.ihtiyacFazlasiItemsGrid.Rows.push() as TTVisual.ITTGridRow;
            addedRow.Cells[this.siraNo.Name].Value = sinif.siraNo === null ? "\"\"" : sinif.siraNo.toString();
            addedRow.Cells[this.malzemeKodu.Name].Value = String.isNullOrEmpty(sinif.malzemeKodu) ? "\"\"" : sinif.malzemeKodu;
            addedRow.Cells[this.malzemeAdi.Name].Value = String.isNullOrEmpty(sinif.malzemeAdi) ? "\"\"" : sinif.malzemeAdi;
            addedRow.Cells[this.malzemeDigerAciklama.Name].Value = String.isNullOrEmpty(sinif.malzemeDigerAciklama) ? "\"\"" : sinif.malzemeDigerAciklama;
            addedRow.Cells[this.adeti.Name].Value = sinif.adeti != null ? sinif.adeti.toString() : "";
            addedRow.Cells[this.vergiliBirimFiyat.Name].Value = sinif.vergiliBirimFiyat != null ? sinif.vergiliBirimFiyat.toString() : "";
            addedRow.Cells[this.tarih.Name].Value = sinif.tarih;
            addedRow.Cells[this.ilAdi.Name].Value = String.isNullOrEmpty(sinif.ilAdi) ? "\"\"" : sinif.ilAdi;
            addedRow.Cells[this.ilKodu.Name].Value = String.isNullOrEmpty(sinif.ilKodu) ? "\"\"" : sinif.ilKodu;
            addedRow.Cells[this.birimAdi.Name].Value = String.isNullOrEmpty(sinif.birimAdi) ? "\"\"" : sinif.birimAdi;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SupplyRequestPoolDetail();
        this.mKYSExcessFormViewModel = new MKYSExcessFormViewModel();
        this._ViewModel = this.mKYSExcessFormViewModel;
        this.mKYSExcessFormViewModel._SupplyRequestPoolDetail = this._TTObject as SupplyRequestPoolDetail;
        this.mKYSExcessFormViewModel._SupplyRequestPoolDetail.Material = new Material();
        this.mKYSExcessFormViewModel._SupplyRequestPoolDetail.Material.StockCard = new StockCard();
    }

    protected loadViewModel() {
        let that = this;

        that.mKYSExcessFormViewModel = this._ViewModel as MKYSExcessFormViewModel;
        that._TTObject = this.mKYSExcessFormViewModel._SupplyRequestPoolDetail;
        if (this.mKYSExcessFormViewModel == null)
            this.mKYSExcessFormViewModel = new MKYSExcessFormViewModel();
        if (this.mKYSExcessFormViewModel._SupplyRequestPoolDetail == null)
            this.mKYSExcessFormViewModel._SupplyRequestPoolDetail = new SupplyRequestPoolDetail();
        let materialObjectID = that.mKYSExcessFormViewModel._SupplyRequestPoolDetail["Material"];
        if (materialObjectID != null && (typeof materialObjectID === 'string')) {
            let material = that.mKYSExcessFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
             if (material) {
                that.mKYSExcessFormViewModel._SupplyRequestPoolDetail.Material = material;
            }
            if (material != null) {
                let stockCardObjectID = material["StockCard"];
                if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                    let stockCard = that.mKYSExcessFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                     if (stockCard) {
                        material.StockCard = stockCard;
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(MKYSExcessFormViewModel);
        this.FormCaption = "MKYS İhtiyaç Fazlası Sorgulama";
  
    }


    public onCodePurchaseGroupChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPoolDetail != null &&
                this._SupplyRequestPoolDetail.Material != null &&
                this._SupplyRequestPoolDetail.Material.StockCard != null && this._SupplyRequestPoolDetail.Material.StockCard.NATOStockNO != event) {
                this._SupplyRequestPoolDetail.Material.StockCard.NATOStockNO = event;
            }
        }
    }

    public onNamePurchaseGroupChanged(event): void {
        if (event != null) {
            if (this._SupplyRequestPoolDetail != null &&
                this._SupplyRequestPoolDetail.Material != null && this._SupplyRequestPoolDetail.Material.Name != event) {
                this._SupplyRequestPoolDetail.Material.Name = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.NamePurchaseGroup, "Text", this.__ttObject, "Material.Name");
        redirectProperty(this.CodePurchaseGroup, "Text", this.__ttObject, "Material.StockCard.NATOStockNO");
    }

    public initFormControls(): void {
        this.NamePurchaseGroup = new TTVisual.TTTextBox();
        this.NamePurchaseGroup.BackColor = "#F0F0F0";
        this.NamePurchaseGroup.ReadOnly = true;
        this.NamePurchaseGroup.Name = "NamePurchaseGroup";
        this.NamePurchaseGroup.TabIndex = 12;

        this.CodePurchaseGroup = new TTVisual.TTTextBox();
        this.CodePurchaseGroup.BackColor = "#F0F0F0";
        this.CodePurchaseGroup.ReadOnly = true;
        this.CodePurchaseGroup.Name = "CodePurchaseGroup";
        this.CodePurchaseGroup.TabIndex = 10;

        this.birimTextBox = new TTVisual.TTTextBox();
        this.birimTextBox.Name = "birimTextBox";
        this.birimTextBox.TabIndex = 4;

        this.CityListBox = new TTVisual.TTObjectListBox();
        this.CityListBox.ListDefName = "CityNameList";
        this.CityListBox.Name = "CityListBox";
        this.CityListBox.TabIndex = 9;

        this.ihtiyacFazlasiItemsGrid = new TTVisual.TTGrid();
        this.ihtiyacFazlasiItemsGrid.Name = "ihtiyacFazlasiItemsGrid";
        this.ihtiyacFazlasiItemsGrid.TabIndex = 8;

        this.siraNo = new TTVisual.TTTextBoxColumn();
        this.siraNo.DisplayIndex = 0;
        this.siraNo.HeaderText = i18n("M21815", "Sıra No");
        this.siraNo.Name = "siraNo";
        this.siraNo.ReadOnly = true;
        this.siraNo.Width = 100;

        this.malzemeKodu = new TTVisual.TTTextBoxColumn();
        this.malzemeKodu.DisplayIndex = 1;
        this.malzemeKodu.HeaderText = i18n("M18587", "Malzeme Kodu");
        this.malzemeKodu.Name = "malzemeKodu";
        this.malzemeKodu.ReadOnly = true;
        this.malzemeKodu.Width = 100;

        this.malzemeAdi = new TTVisual.TTTextBoxColumn();
        this.malzemeAdi.DisplayIndex = 2;
        this.malzemeAdi.HeaderText = i18n("M18550", "Malzeme Adı");
        this.malzemeAdi.Name = "malzemeAdi";
        this.malzemeAdi.ReadOnly = true;
        this.malzemeAdi.Width = 100;

        this.malzemeDigerAciklama = new TTVisual.TTTextBoxColumn();
        this.malzemeDigerAciklama.DisplayIndex = 3;
        this.malzemeDigerAciklama.HeaderText = i18n("M18565", "Malzeme Diğer Açıklama");
        this.malzemeDigerAciklama.Name = "malzemeDigerAciklama";
        this.malzemeDigerAciklama.ReadOnly = true;
        this.malzemeDigerAciklama.Width = 100;

        this.adeti = new TTVisual.TTTextBoxColumn();
        this.adeti.DisplayIndex = 4;
        this.adeti.HeaderText = i18n("M10513", "Adeti");
        this.adeti.Name = "adeti";
        this.adeti.ReadOnly = true;
        this.adeti.Width = 100;

        this.vergiliBirimFiyat = new TTVisual.TTTextBoxColumn();
        this.vergiliBirimFiyat.DisplayIndex = 5;
        this.vergiliBirimFiyat.HeaderText = i18n("M24092", "Vergili Birim Fiyatı");
        this.vergiliBirimFiyat.Name = "vergiliBirimFiyat";
        this.vergiliBirimFiyat.ReadOnly = true;
        this.vergiliBirimFiyat.Width = 100;

        this.tarih = new TTVisual.TTDateTimePickerColumn();
        this.tarih.DisplayIndex = 6;
        this.tarih.HeaderText = "Tarih";
        this.tarih.Name = "tarih";
        this.tarih.ReadOnly = true;
        this.tarih.Width = 100;

        this.ilAdi = new TTVisual.TTTextBoxColumn();
        this.ilAdi.DisplayIndex = 7;
        this.ilAdi.HeaderText = i18n("M16270", "İl Adı");
        this.ilAdi.Name = "ilAdi";
        this.ilAdi.ReadOnly = true;
        this.ilAdi.Width = 100;

        this.ilKodu = new TTVisual.TTTextBoxColumn();
        this.ilKodu.DisplayIndex = 8;
        this.ilKodu.HeaderText = "İl Kodu";
        this.ilKodu.Name = "ilKodu";
        this.ilKodu.ReadOnly = true;
        this.ilKodu.Width = 100;

        this.birimAdi = new TTVisual.TTTextBoxColumn();
        this.birimAdi.DisplayIndex = 9;
        this.birimAdi.HeaderText = i18n("M11851", "Birim Adı");
        this.birimAdi.Name = "birimAdi";
        this.birimAdi.ReadOnly = true;
        this.birimAdi.Width = 100;

        this.btnExcessQuery = new TTVisual.TTButton();
        this.btnExcessQuery.Text = i18n("M22125", "Sorgula");
        this.btnExcessQuery.Name = "btnExcessQuery";
        this.btnExcessQuery.TabIndex = 7;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M22468", "Şehir Adı");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 3;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M18587", "Malzeme Kodu");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 2;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M11851", "Birim Adı");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 1;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M18550", "Malzeme Adı");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 0;

        this.ihtiyacFazlasiItemsGridColumns = [this.siraNo, this.malzemeKodu, this.malzemeAdi, this.malzemeDigerAciklama, this.adeti, this.vergiliBirimFiyat, this.tarih, this.ilAdi, this.ilKodu, this.birimAdi];
        this.Controls = [this.NamePurchaseGroup, this.CodePurchaseGroup, this.birimTextBox, this.CityListBox, this.ihtiyacFazlasiItemsGrid, this.siraNo, this.malzemeKodu, this.malzemeAdi, this.malzemeDigerAciklama, this.adeti, this.vergiliBirimFiyat, this.tarih, this.ilAdi, this.ilKodu, this.birimAdi, this.btnExcessQuery, this.ttlabel4, this.ttlabel3, this.ttlabel2, this.ttlabel1];

    }


}
