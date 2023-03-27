//$27C62E62
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { BaseChattelDocumentWithPurchaseFormViewModel } from './BaseChattelDocumentWithPurchaseFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentForm";
import { ChattelDocumentDetailWithPurchase, StockCard, DrugDefinition, DrugOrderDetail, PTSStockActionDetail, StockAction, Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { MaterialService } from "ObjectClassService/MaterialService";
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDistribution } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { ChattelDocumentWithPurchaseService, GetWaybillForInputDetailDocument_Output } from "ObjectClassService/ChattelDocumentWithPurchaseService";
import { StockLevelTypeService } from "ObjectClassService/StockLevelTypeService";
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';


import { Type } from 'NebulaClient/ClassTransformer';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { date } from 'devexpress-dashboard/model/index.metadata';
import { find } from 'rxjs/operators';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'BaseChattelDocumentWithPurchaseForm',
    templateUrl: './BaseChattelDocumentWithPurchaseForm.html',
    providers: [MessageService]
})
export class BaseChattelDocumentWithPurchaseForm extends BaseChattelDocumentForm implements OnInit {
    AmountStockActionDetailIn: TTVisual.ITTTextBoxColumn;
    AuctionDate: TTVisual.ITTDateTimePicker;
    Barcode: TTVisual.ITTTextBoxColumn;
    BudgetTypeDefinition: TTVisual.ITTObjectListBox;
    ChattelDocumentDetailsWithPurchase: TTVisual.ITTGrid;
    ChattelDocumentDetailTabpage: TTVisual.ITTTabPage;
    ChattelDocumentTabcontrol: TTVisual.ITTTabControl;
    ConclusionDateTime: TTVisual.ITTDateTimePicker;
    ConclusionNumber: TTVisual.ITTTextBox;
    DA_DemandAmount: TTVisual.ITTTextBoxColumn;
    DA_DistributionAmount: TTVisual.ITTTextBoxColumn;
    DA_MasterResource: TTVisual.ITTListBoxColumn;
    DA_Material: TTVisual.ITTListBoxColumn;
    DemandAmountsGrid: TTVisual.ITTGrid;
    Detail: TTVisual.ITTButtonColumn;
    DistributionsTab: TTVisual.ITTTabPage;
    DistributionType: TTVisual.ITTTextBoxColumn;
    ExaminationReportDate: TTVisual.ITTDateTimePicker;
    ExaminationReportNo: TTVisual.ITTTextBox;
    ExpirationDateStockActionDetailIn: TTVisual.ITTDateTimePickerColumn;
    GetWaybill: TTButtonTextBox;
    invoicePictureControl: TTVisual.ITTPictureBoxControl;
    labelAuctionDate: TTVisual.ITTLabel;
    labelBudgetTypeDefinition: TTVisual.ITTLabel;
    labelConclusionDateTime: TTVisual.ITTLabel;
    labelConclusionNumber: TTVisual.ITTLabel;
    labelExaminationReportDate: TTVisual.ITTLabel;
    labelExaminationReportNo: TTVisual.ITTLabel;
    labelMKYS_EAlimYontemi: TTVisual.ITTLabel;
    labelMKYS_EMalzemeGrup: TTVisual.ITTLabel;
    labelMKYS_ETedarikTuru: TTVisual.ITTLabel;
    labelRegistrationAuctionNo: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelSupplier: TTVisual.ITTLabel;
    labelWaybill: TTVisual.ITTLabel;
    labelWaybillDate: TTVisual.ITTLabel;
    LotNo: TTVisual.ITTTextBoxColumn;
    MaterialStockActionDetailIn: TTVisual.ITTListBoxColumn;
    MKYS_EAlimYontemi: TTVisual.ITTEnumComboBox;
    MKYS_EdinimYili: TTVisual.ITTTextBoxColumn;
    MKYS_EMalzemeGrup: TTVisual.ITTEnumComboBox;
    MKYS_ETedarikTuru: TTVisual.ITTEnumComboBox;
    MKYS_IndirimOranı: TTVisual.ITTTextBoxColumn;
    MKYS_IndirimTutari: TTVisual.ITTTextBoxColumn;
    MKYS_UretimTarihi: TTVisual.ITTDateTimePickerColumn;
    PictureTabpage: TTVisual.ITTTabPage;
    RegistrationAuctionNo: TTVisual.ITTTextBox;
    StatusStockActionDetailIn: TTVisual.ITTEnumComboBoxColumn;
    StockLevelTypeStockActionDetailIn: TTVisual.ITTListDefComboBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    Supplier: TTVisual.ITTObjectListBox;
    TotalPrice: TTVisual.ITTTextBoxColumn;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    txtDiscount: TTVisual.ITTTextBox;
    txtNotKDV: TTVisual.ITTTextBox;
    txtTotalPrice: TTVisual.ITTTextBox;
    txtWithKDV: TTVisual.ITTTextBox;
    UnitePriceWithVatNoDiscount: TTVisual.ITTTextBoxColumn;
    UnitPriceStockActionDetailIn: TTVisual.ITTTextBoxColumn;
    UnitPriceStockActionDetailInWithOutVat: TTVisual.ITTTextBoxColumn;
    ValueAddedTax: TTVisual.ITTTextBoxColumn;
    Waybill: TTButtonTextBox;
    WaybillDate: TTVisual.ITTDateTimePicker;
    public ChattelDocumentDetailsWithPurchaseColumns = [];
    public selectedMaterialGrid: Array<ChattelDocumentDetailWithPurchase> = new Array<ChattelDocumentDetailWithPurchase>();
    public DemandAmountsGridColumns = [];
    public StockActionSignDetailsColumns = [];
    public baseChattelDocumentWithPurchaseFormViewModel: BaseChattelDocumentWithPurchaseFormViewModel = new BaseChattelDocumentWithPurchaseFormViewModel();
    public get _ChattelDocumentWithPurchase(): ChattelDocumentWithPurchase {
        return this._TTObject as ChattelDocumentWithPurchase;
    }
    private BaseChattelDocumentWithPurchaseForm_DocumentUrl: string = '/api/ChattelDocumentWithPurchaseService/BaseChattelDocumentWithPurchaseForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone, protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseChattelDocumentWithPurchaseForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    //#region dx-data-grid çevirme
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();
    public expirationMinDate: Date = new Date(Date.now());

    @ViewChild('materialGrid') materialGrid: DxDataGridComponent;
    public async stateChange(event: FormSaveInfo) {
        if (this.materialGrid !== undefined) {
            this.materialGrid.instance.closeEditCell();
            this.materialGrid.instance.saveEditData();
        }
        await super.setState(event.transDef, event);
    }

    public async onSaveButtonClick(event: FormSaveInfo) {
        if (this.materialGrid !== undefined) {
            this.materialGrid.instance.closeEditCell();
            this.materialGrid.instance.saveEditData();
        }
        await super.saveForm(event);
    }
    async btnAddClick() {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        if (this.selectedMaterial == null) {
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        }
        else {
            let newRow: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
            newRow.Material = this.selectedMaterial;

            let stockCardObj: Guid = <any>this.selectedMaterial['StockCard'];
            let stockCard: StockCard = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
            newRow.Material.StockCard = stockCard;

            newRow.StockLevelType = this.selectedStockLevelType;
            newRow.Status = StockActionDetailStatusEnum.New;
            if (this._ChattelDocumentWithPurchase.TransactionDate != null)
                newRow.VatRate = await MaterialService.GetVatrateFromMaterialTS(this.selectedMaterial, this._ChattelDocumentWithPurchase.TransactionDate);
            //newRow.VatRate = this.selectedMaterial.MaterialVatRates.find(x => x.StartDate <= this._ChattelDocumentWithPurchase.TransactionDate && x.EndDate >= this._ChattelDocumentWithPurchase.TransactionDate).VatRate;
            this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(newRow);



        }
    }



    public async onMaterialSelectionChange(event: any) {
        let drugDefinitionObjDefId: Guid = DrugDefinition.ObjectDefID;
        if (this.selectedMaterial != null) {
            if (this.stockLeveltypeArray.length === 0)
                this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);

            if (this.selectedMaterial.IsIndividualTrackingRequired === true) {
                ServiceLocator.MessageService.showError('Giriş yapmak istediğiniz malzeme ÜTS Tekil Takip Gerektiren Malzemelerdendir. Lütfen Alma Bildirimi sorgulama işlemi yapınız!');
                return;
            }


            if ((<DrugDefinition>this.selectedMaterial).IsITSDrug === true) {
                ServiceLocator.MessageService.showError('Giriş yapmak istediğiniz malzeme ITS Malzemelerdendir. Lütfen PTS Getir işlemi yapınız!');
                return;
            }


            let newRow: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
            newRow.Material = this.selectedMaterial;

            let stockCardObj: Guid = <any>this.selectedMaterial['StockCard'];
            let stockCard: StockCard = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
            newRow.Material.StockCard = stockCard;

            newRow.StockLevelType = this.selectedStockLevelType;
            newRow.Status = StockActionDetailStatusEnum.New;
            if (this._ChattelDocumentWithPurchase.TransactionDate != null)
                newRow.VatRate = await MaterialService.GetVatrateFromMaterialTS(this.selectedMaterial, this._ChattelDocumentWithPurchase.TransactionDate);
            //newRow.VatRate = this.selectedMaterial.MaterialVatRates.find(x => x.StartDate <= this._ChattelDocumentWithPurchase.TransactionDate && x.EndDate >= this._ChattelDocumentWithPurchase.TransactionDate).VatRate;
            this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(newRow);
            this.selectedMaterialGrid = new Array<ChattelDocumentDetailWithPurchase>();
            this.selectedMaterialGrid.push(newRow);

            setTimeout(x => {
                let rowIndex: number = this.materialGrid.instance.getRowIndexByKey(this.selectedMaterialGrid[0]);
                let selecttedRowIndex: number = rowIndex + 1;
                this.materialGrid.instance.editRow(rowIndex);
            }, 250);

        }

        this.selectedMaterial = null;
    }

    /*  public async btnAddClick() {
          if (this.selectedMaterial == null)
              ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
          else
              if (!this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID)) {
                  let newRow: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
                  newRow.Material = this.selectedMaterial;
                  newRow.StockLevelType = this.selectedStockLevelType;
                  newRow.Status = StockActionDetailStatusEnum.New;
                  if (this._ChattelDocumentWithPurchase.TransactionDate != null)
                      newRow.VatRate = await MaterialService.GetVatrateFromMaterialTS(this.selectedMaterial, this._ChattelDocumentWithPurchase.TransactionDate);
                  //newRow.VatRate = this.selectedMaterial.MaterialVatRates.find(x => x.StartDate <= this._ChattelDocumentWithPurchase.TransactionDate && x.EndDate >= this._ChattelDocumentWithPurchase.TransactionDate).VatRate;
                  this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(newRow);
              }
              else
                  ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
      }*/

    public CalculateFormTotalPrice() {
        let priceCalc: Array<number> = new Array<number>();
        let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
        priceCalc.push(totalWithoutKDV);
        priceCalc.push(totalWithKDV);
        priceCalc.push(salesTotal);
        priceCalc.push(totalPrice);
        for (let data of this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase) {
            if (data.UnitPriceWithInVat === null || data.UnitPriceWithOutVat === null || data.DiscountAmount === null)
                continue;
            priceCalc[0] += data.Amount * data.UnitPriceWithOutVat;
            //prices[1] += <Currency>inDet.Amount * Convert.ToDouble(inDet.UnitPriceWithInVat);
            priceCalc[1] += data.Amount * (data.UnitPriceWithOutVat + (data.UnitPriceWithOutVat * data.VatRate / 100));

            priceCalc[2] += data.DiscountAmount;
        }
        priceCalc[3] = priceCalc[1] - priceCalc[2];
        this.txtNotKDV.Text = priceCalc[0].toFixed(2);
        this.txtWithKDV.Text = priceCalc[1].toFixed(2);
        this.txtDiscount.Text = priceCalc[2].toFixed(2);
        this.txtTotalPrice.Text = priceCalc[3].toFixed(2);
    }


    public async onMaterialGridRowUpdating(event: any) {
        let data = <ChattelDocumentDetailWithPurchase>event.key;
        if (data.Material.IsIndividualTrackingRequired === true) {
            if (event.newData.Amount != null) {
                if (event.newData.Amount != event.oldData.Amount) {
                    let amountChangeMessage: string = await ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", i18n("M23735", "Uyarı"), "", "ÜTS den gelen miktarı değiştiriyorsunuz...Eski Miktar : "+event.oldData.Amount +" Yeni Miktar :"+event.newData.Amount + "\r\n" + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                    if (amountChangeMessage == "T") {
                        return;
                    }else{
                        event.newData.Amount = event.oldData.Amount;
                        return;
                    }
                    //ServiceLocator.MessageService.showError('ÜTS malzemeleri için miktar alanı değiştirilemez!');
                   //event.cancel = true;
                }
            }
        }
    }

    public MaterialRowUpdatePriceGridCellChanged(data: ChattelDocumentDetailWithPurchase): boolean {
        if (data.Amount <= 0 || data.UnitPriceWithInVat <= 0) {
            ServiceLocator.MessageService.showError('Miktar ve İndirimsiz Birim Fiyat sıfırdan küçük olamaz!');
            return true;
        }
        if (data.VatRate < 0) {
            ServiceLocator.MessageService.showError('KDV Oranı sıfırdan küçük olamaz!');
            return true;
        }

        if (data.Amount != null && data.VatRate != null && data.UnitPriceWithOutVat != null) {
            data.UnitPrice = data.UnitPriceWithOutVat;
            let kdvsizBirimFiyat: number = data.UnitPriceWithOutVat;
            let miktar: number = data.Amount;
            let indirimOrani: number = 0;
            let birimFiyatKDVli: number = kdvsizBirimFiyat + kdvsizBirimFiyat * ((data.VatRate / 100));
            data.UnitPriceWithInVat = Math.Round(birimFiyatKDVli, 6);
            data.NotDiscountedUnitPrice = birimFiyatKDVli;
            if ((data.DiscountRate != null)) {
                indirimOrani = data.DiscountRate;
            }

            let indirimliBirimFiyat: number = birimFiyatKDVli - (birimFiyatKDVli * (indirimOrani / 100));
            data.UnitPrice = Math.Round(indirimliBirimFiyat, 6);
            let indirimTutari: number = birimFiyatKDVli * miktar - (indirimliBirimFiyat * miktar);
            data.DiscountAmount = Math.Round(indirimTutari, 6);
            let toplamTutar: number = indirimliBirimFiyat * miktar;
            data.Price = Math.Round(toplamTutar, 6);
            if (data.RetrievalYear == null) {
                let today = new Date();
                data.RetrievalYear = today.getFullYear();
            }

            return false;
        }
    }





    //TODO MK: Sadece Amount, VatRate ve NotDiscountedUnitPrice cell leri değiştiğinde tetiklenecek şekilde yapılacak..
    public MaterialGridCellChanged(event: any) {
        let data = <ChattelDocumentDetailWithPurchase>event.key;
        /*if (data.Material.IsIndividualTrackingRequired === true) {
            if (event.data.Amount != null) {
                ServiceLocator.MessageService.showError('ÜTS malzemeleri için miktar alanı değiştirilemez!');
                event.cancel = true;
                return;
            }
        }*/
        //let detail: ChattelDocumentInputDetailWithAccountancy = <ChattelDocumentInputDetailWithAccountancy>data.Row.TTObject;


        let cancelEvent: boolean = this.MaterialRowUpdatePriceGridCellChanged(data);
        if (cancelEvent === true) {
            event.cancel = true;
            return;
        }


        /*if (data.Amount <= 0 || data.UnitPriceWithInVat <= 0) {
            ServiceLocator.MessageService.showError('Miktar ve İndirimsiz Birim Fiyat sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }
        if (data.VatRate < 0) {
            ServiceLocator.MessageService.showError('KDV Oranı sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }

        if (data.Amount != null && data.VatRate != null && data.UnitPriceWithOutVat != null) {
            data.UnitPrice = data.UnitPriceWithOutVat;
            let kdvsizBirimFiyat: number = data.UnitPriceWithOutVat;
            let miktar: number = data.Amount;
            //let KdvOrani: number = Math.Round(data.VatRate / 100, 2);
            let indirimOrani: number = 0;
            let birimFiyatKDVli: number = kdvsizBirimFiyat + kdvsizBirimFiyat * ((data.VatRate / 100));
            data.UnitPriceWithInVat = Math.Round(birimFiyatKDVli, 6);
            data.NotDiscountedUnitPrice = birimFiyatKDVli;
            if ((data.DiscountRate != null)) {
                indirimOrani = data.DiscountRate;
            }

            let indirimliBirimFiyat: number = birimFiyatKDVli - (birimFiyatKDVli * (indirimOrani / 100));
            data.UnitPrice = Math.Round(indirimliBirimFiyat, 6);
            let indirimTutari: number = birimFiyatKDVli * miktar - (indirimliBirimFiyat * miktar);
            data.DiscountAmount = Math.Round(indirimTutari, 6);
            let toplamTutar: number = indirimliBirimFiyat * miktar;
            data.Price = Math.Round(toplamTutar, 6);
            if (data.RetrievalYear == null) {
                let today = new Date();
                data.RetrievalYear = today.getFullYear();
            }
            this.CalculateFormTotalPrice();
        }*/
        this.CalculateFormTotalPrice();
    }

    public onMaterialGridRowRemoving(event: any) {
        if (event.key.ObjectID != null && this._ChattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.New) {
            this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.find(x => x.ObjectID == event.data.ObjectID).EntityState = EntityStateEnum.Deleted;
            this.materialGrid.instance.filter(['EntityState', '<>', 1]);
            event.cancel = true;
        }
    }

    public onMaterialGridRowRemoved(event: any) {
        this.CalculateFormTotalPrice();
    }

    public onMaterialGridRowUpdated(event: any) {
        //console.log(event);
        this.MaterialGridCellChanged(event);
    }

    public ChattelMaterialGridColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            visible: false,
            allowEditing: false,
            width: 50
        },
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Taşınır Kodu',
            dataField: 'Material.StockCard.NATOStockNO',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            width: 120
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
            // format: "#",
            // editorOptions: {
            //     onKeyPress: function (e) {
            //         var event = e.event,
            //             str = String.fromCharCode(event.keyCode);
            //         if (!/[0-9]/.test(str))
            //             event.preventDefault();
            //     }
            // },
            width: 120,
            validationRules: [{ type: 'required', message: 'Miktar Boş Geçilemez' }]
        },
        {
            caption: i18n("M17464", "KDV\'siz Fiyatı"),
            dataField: 'UnitPriceWithOutVat',
            dataType: 'number',
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 6) + ' TL';
            //     }
            //     //format: "#,##0.## TL",
            // },
            width: 'auto',
            validationRules: [{ type: 'required', message: 'KDV\'siz Fiyatı Boş Geçilemez' }]
        },
        {
            caption: i18n("M17457", "KDV Oranı"),
            dataField: 'VatRate',
            dataType: 'number',
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 5) + ' %';
            //     }
            //     //format: "#,##0.## TL",
            // },
            width: 100,

        },
        {
            caption: i18n("M17462", "KDV\'li Fiyatı"),
            dataField: 'UnitPriceWithInVat',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M16491", "İndirim Oranı"),
            dataField: 'DiscountRate',
            dataType: 'number',
            width: 'auto'
        },
        {
            caption: i18n("M16504", "İndirimli Birim Fiyat"),
            dataField: 'UnitPrice',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M16006", "Indirim Tutarı"),
            dataField: 'DiscountAmount',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M23526", "Toplam Tutar"),
            dataField: 'Price',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Lot No.',
            dataField: 'LotNo',
            width: 85
        },
        {
            caption: 'ÜTS Alma Bildirim ID',
            dataField: 'ReceiveNotificationID',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Seri No.',
            dataField: 'SerialNo',
            width: 85
        },
        {
            caption: i18n("M22057", "Son Kullanma Tarihi"),
            dataField: 'ExpirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150,
            editorOptions: {
                min: this.expirationMinDate,
            }
        },
        // {
        //     caption: i18n("M18519", "Malın Durumu"),
        //     dataField: 'StockLevelType.Description',
        //     allowEditing: false,
        //     width: 'auto'
        // },
        {
            caption: i18n("M13475", "Edinim Yılı"),
            dataField: 'RetrievalYear',
            dataType: 'number',
            width: 85
        },
        {
            caption: i18n("M23966", "Üretim Tarihi"),
            dataField: 'ProductionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150
        },
    ];

    //#endregion

    // ***** Method declarations start *****

    private async ChattelDocumentDetailsWithPurchase_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.ChattelDocumentDetailsWithPurchase.CurrentCell.OwningColumn.Name === "Detail")
            this.ShowStockActionDetailForm(<StockActionDetail>this.ChattelDocumentDetailsWithPurchase.CurrentCell.OwningRow.TTObject);
    }
    private async ChattelDocumentDetailsWithPurchase_CellDoubleClick(rowIndex: number, columnIndex: number): Promise<void> {
        this.CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, this.ChattelDocumentDetailsWithPurchase);
    }
    public async ChattelDocumentDetailsWithPurchase_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let chattelDocumentDetailWithPurchase: ChattelDocumentDetailWithPurchase = <ChattelDocumentDetailWithPurchase>data.Row.TTObject;

        if (data.Column.Name === "MaterialStockActionDetailIn") {
            if (this._ChattelDocumentWithPurchase.TransactionDate !== null && chattelDocumentDetailWithPurchase.VatRate == null)
                chattelDocumentDetailWithPurchase.VatRate = await MaterialService.GetVatrateFromMaterialTS(chattelDocumentDetailWithPurchase.Material, this._ChattelDocumentWithPurchase.TransactionDate);
        }
        if (chattelDocumentDetailWithPurchase.Status === undefined) {
            chattelDocumentDetailWithPurchase.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            chattelDocumentDetailWithPurchase.StockLevelType = stockLeveltypeArray[0];

        }
        let today = new Date();
        let year = today.getFullYear();
        (<ChattelDocumentDetailWithPurchase>data.Row.TTObject).RetrievalYear = year;

        if (data.Column.Name === "UnitPriceStockActionDetailInWithOutVat" || data.Column.Name === "ValueAddedTax" || data.Column.Name === "MKYS_IndirimOranı" || data.Column.Name === "NotDiscountedUnitPrice" || data.Column.Name === "AmountStockActionDetailIn") {
            await this.CalculatePricesWithKdv(chattelDocumentDetailWithPurchase);
            let priceCalc: Array<number> = new Array<number>();
            let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
            priceCalc.push(totalWithoutKDV);
            priceCalc.push(totalWithKDV);
            priceCalc.push(salesTotal);
            priceCalc.push(totalPrice);
            priceCalc = await this.CalcFinalPriceWithKDV(priceCalc);
            this.txtNotKDV.Text = priceCalc[0].toFixed(2);
            this.txtWithKDV.Text = priceCalc[1].toFixed(2);
            this.txtDiscount.Text = priceCalc[2].toFixed(2);
            this.txtTotalPrice.Text = priceCalc[3].toFixed(2);
        }

        if (data.Column.Name === "ExpirationDateStockActionDetailIn") {
            let currentDate: Date = new Date();
            let endOfMonth: Date = new Date(chattelDocumentDetailWithPurchase.ExpirationDate.getFullYear(), chattelDocumentDetailWithPurchase.ExpirationDate.getMonth() + 1, 1).AddDays(-1);
            if (currentDate <= chattelDocumentDetailWithPurchase.ExpirationDate) {
                chattelDocumentDetailWithPurchase.ExpirationDate = endOfMonth;
            } else {
                TTVisual.InfoBox.Alert(i18n("M22059", "Son kullanma tarihi bugunden küçük olamaz."));
                chattelDocumentDetailWithPurchase.ExpirationDate = null;
            }
        }

        this.txtTotalPrice.Text = await this.CalcPrice();

    }

    public async CalcPrice(): Promise<string> {
        let calTot: number = 0;
        for (let cal of this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase) {
            calTot += cal.Price;
        }
        return calTot.toFixed(2);
    }


    public async GetWaybill_Click(): Promise<void> {
        if (this._ChattelDocumentWithPurchase.CurrentStateDefID === ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.New) {
            if (!String.isNullOrEmpty(this._ChattelDocumentWithPurchase.Waybill)) {
                let exp: GetWaybillForInputDetailDocument_Output = await ChattelDocumentWithPurchaseService.GetWaybillForInputDocumentTS(this._ChattelDocumentWithPurchase);

                if (exp != null) {
                    this.ExaminationReportDate.ReadOnly = true;
                    this.ExaminationReportNo.ReadOnly = true;
                    this.MKYS_EAlimYontemi.ReadOnly = true;
                    this.RegistrationAuctionNo.ReadOnly = true;
                    this.AuctionDate.ReadOnly = true;
                    this.BudgetTypeDefinition.ReadOnly = true;
                    this.Waybill.ReadOnly = true;
                    this.GetWaybill.ReadOnly = true;
                    this.WaybillDate.ReadOnly = true;
                    this.ChattelDocumentDetailsWithPurchase.ReadOnly = true;
                    this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
                    this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = true;
                }
            }
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }
    protected async PreScript() {
        super.PreScript();
        if (this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase != null) {
            for (let detail of this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase) {
                this.CalculatePricesWithKdv(detail);
            }

            this.txtTotalPrice.Text = await this.CalcPrice();
        }
        //   txtTotalPrice.Text = CalculateTotalPrice().ToString();
        //  txtTotalPriceCurrency.Text = CalculateTotalPrice().ToString("#.00") ;
        // this.invoicePictureControl.MaxFileSize = Convert.ToInt32((await SystemParameterService.GetParameterValue("MAXPICTUREFILESIZE", "153600")));
    }
    public async CalcFinalPriceWithKDV(prices: Array<number>): Promise<Array<number>> {
        if (this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase != null) {
            for (let inDet of this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase) {
                if (inDet.UnitPriceWithInVat === null || inDet.UnitPriceWithOutVat === null || inDet.DiscountAmount === null)
                    continue;
                prices[0] += <Currency>inDet.Amount * Convert.ToDouble(inDet.UnitPriceWithOutVat);
                //prices[1] += <Currency>inDet.Amount * Convert.ToDouble(inDet.UnitPriceWithInVat);
                prices[1] += <Currency>inDet.Amount * (Convert.ToDouble(inDet.UnitPriceWithOutVat) + (Convert.ToDouble(inDet.UnitPriceWithOutVat) * inDet.VatRate / 100));

                prices[2] += Convert.ToDouble(inDet.DiscountAmount);
            }
            prices[3] = prices[1] - prices[2];
        }
        return prices;
    }

    /*
    CalculatePricesWithKdv methodunda kullanılan toFixed(2) ile virgül sonrasını 2 basamağa yuvarlama işlemi,
    sonuç tutarlarında yanlışlığa sebep olduğu için değiştirildi.
    */
    public async CalculatePricesWithKdv(detail: ChattelDocumentDetailWithPurchase): Promise<void> {
        if ((detail.UnitPriceWithOutVat != null)) {
            detail.UnitPrice = detail.UnitPriceWithOutVat;
            if (((detail.Amount != null)
                && (detail.VatRate != null))) {
                let kdvsizBirimFiyat: BigCurrency = (<BigCurrency>(Convert.ToDouble(detail.UnitPriceWithOutVat)));
                let miktar: Currency = (<Currency>(Convert.ToDouble(detail.Amount)));
                let kdv: number = (<number>(Convert.ToDouble(detail.VatRate)));
                let KdvOrani: number = (Convert.ToDouble(kdv) / 100);
                let indirimOrani: BigCurrency = 0;
                let birimFiyatKDVli: BigCurrency = (<BigCurrency>((kdvsizBirimFiyat
                    + ((<BigCurrency>(Convert.ToDouble(kdvsizBirimFiyat))) * (<BigCurrency>(KdvOrani))))));
                detail.UnitPriceWithInVat = Convert.ToInt32(birimFiyatKDVli.toFixed(6));
                detail.NotDiscountedUnitPrice = Convert.ToInt32(birimFiyatKDVli.toFixed(6));
                if ((detail.DiscountRate != null)) {
                    indirimOrani = (<BigCurrency>(Convert.ToDouble(detail.DiscountRate)));
                }

                let indirimliBirimFiyat: BigCurrency = (<BigCurrency>((birimFiyatKDVli - (birimFiyatKDVli * (indirimOrani / 100)))));
                detail.UnitPrice = Convert.ToInt32(indirimliBirimFiyat.toFixed(6));
                let indirimTutari: BigCurrency = (<BigCurrency>(((birimFiyatKDVli * miktar) - (indirimliBirimFiyat * miktar))));
                detail.DiscountAmount = Convert.ToInt32(indirimTutari.toFixed(6));
                let toplamTutar: BigCurrency = ( detail.UnitPrice * (<BigCurrency>(miktar)));
                detail.Price = Convert.ToInt32(toplamTutar.toFixed(6));
            }
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentWithPurchase();
        this.baseChattelDocumentWithPurchaseFormViewModel = new BaseChattelDocumentWithPurchaseFormViewModel();
        this._ViewModel = this.baseChattelDocumentWithPurchaseFormViewModel;
        this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase = this._TTObject as ChattelDocumentWithPurchase;
        this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.Store = new Store();
        this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.Supplier = new Supplier();
        this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = new Array<ChattelDocumentDetailWithPurchase>();
        this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = new Array<ChattelDocumentDistribution>();
        this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseChattelDocumentWithPurchaseFormViewModel = this._ViewModel as BaseChattelDocumentWithPurchaseFormViewModel;
        that._TTObject = this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase;
        if (this.baseChattelDocumentWithPurchaseFormViewModel == null)
            this.baseChattelDocumentWithPurchaseFormViewModel = new BaseChattelDocumentWithPurchaseFormViewModel();
        if (this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase == null)
            this.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase = new ChattelDocumentWithPurchase();
        let budgetTypeDefinitionObjectID = that.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.baseChattelDocumentWithPurchaseFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseChattelDocumentWithPurchaseFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.Store = store;
            }
        }
        let supplierObjectID = that.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === 'string')) {
            let supplier = that.baseChattelDocumentWithPurchaseFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.Supplier = supplier;
            }
        }
        that.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = that.baseChattelDocumentWithPurchaseFormViewModel.ChattelDocumentDetailsWithPurchaseGridList;
        for (let detailItem of that.baseChattelDocumentWithPurchaseFormViewModel.ChattelDocumentDetailsWithPurchaseGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseChattelDocumentWithPurchaseFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseChattelDocumentWithPurchaseFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                            material.NATOStockNO = stockCard.NATOStockNO;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.baseChattelDocumentWithPurchaseFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.baseChattelDocumentWithPurchaseFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = that.baseChattelDocumentWithPurchaseFormViewModel.DemandAmountsGridGridList;
        for (let detailItem of that.baseChattelDocumentWithPurchaseFormViewModel.DemandAmountsGridGridList) {
            let demandDetailObjectID = detailItem["DemandDetail"];
            if (demandDetailObjectID != null && (typeof demandDetailObjectID === 'string')) {
                let demandDetail = that.baseChattelDocumentWithPurchaseFormViewModel.DemandDetails.find(o => o.ObjectID.toString() === demandDetailObjectID.toString());
                if (demandDetail) {
                    detailItem.DemandDetail = demandDetail;
                }
                if (demandDetail != null) {
                    let demandObjectID = demandDetail["Demand"];
                    if (demandObjectID != null && (typeof demandObjectID === 'string')) {
                        let demand = that.baseChattelDocumentWithPurchaseFormViewModel.Demands.find(o => o.ObjectID.toString() === demandObjectID.toString());
                        if (demand) {
                            demandDetail.Demand = demand;
                        }
                        if (demand != null) {
                            let masterResourceObjectID = demand["MasterResource"];
                            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                                let masterResource = that.baseChattelDocumentWithPurchaseFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                                if (masterResource) {
                                    demand.MasterResource = masterResource;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.baseChattelDocumentWithPurchaseFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = that.baseChattelDocumentWithPurchaseFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseChattelDocumentWithPurchaseFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.baseChattelDocumentWithPurchaseFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseChattelDocumentWithPurchaseFormViewModel);

    }


    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.AdditionalDocumentCount != event) {
                this._ChattelDocumentWithPurchase.AdditionalDocumentCount = event;
            }
        }
    }

    public onAuctionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.AuctionDate != event) {
                this._ChattelDocumentWithPurchase.AuctionDate = event;
            }
        }
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.BudgetTypeDefinition != event) {
                this._ChattelDocumentWithPurchase.BudgetTypeDefinition = event;
            }
        }
    }

    public onConclusionDateTimeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ConclusionDateTime != event) {
                this._ChattelDocumentWithPurchase.ConclusionDateTime = event;
            }
        }
    }

    public onConclusionNumberChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ConclusionNumber != event) {
                this._ChattelDocumentWithPurchase.ConclusionNumber = event;
            }
        }
    }

    public onContractDateTimeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ContractDateTime != event) {
                this._ChattelDocumentWithPurchase.ContractDateTime = event;
            }
        }
    }

    public onContractNumberChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ContractNumber != event) {
                this._ChattelDocumentWithPurchase.ContractNumber = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Description != event) {
                this._ChattelDocumentWithPurchase.Description = event;
            }
        }
    }

    public onExaminationReportDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ExaminationReportDate != event) {
                this._ChattelDocumentWithPurchase.ExaminationReportDate = event;
            }
        }
    }

    public onExaminationReportNoChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.ExaminationReportNo != event) {
                this._ChattelDocumentWithPurchase.ExaminationReportNo = event;
            }
        }
    }

    public onMKYS_EAlimYontemiChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi != event) {
                this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup != event) {
                this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru != event) {
                this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_TeslimAlan != event) {
                this._ChattelDocumentWithPurchase.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.MKYS_TeslimEden != event) {
                this._ChattelDocumentWithPurchase.MKYS_TeslimEden = event;
            }
        }
    }

    public onRegistrationAuctionNoChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.RegistrationAuctionNo != event) {
                this._ChattelDocumentWithPurchase.RegistrationAuctionNo = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.StockActionID != event) {
                this._ChattelDocumentWithPurchase.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Store != event) {
                this._ChattelDocumentWithPurchase.Store = event;
            }
        }
    }

    public onSupplierChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Supplier != event) {
                this._ChattelDocumentWithPurchase.Supplier = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.TransactionDate != event) {
                this._ChattelDocumentWithPurchase.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Waybill != event) {
                this._ChattelDocumentWithPurchase.Waybill = event;

            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.WaybillDate != event) {
                this._ChattelDocumentWithPurchase.WaybillDate = event;
            }
        }
    }



    ChattelDocumentDetailsWithPurchase_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithPurchase_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithPurchase_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.ConclusionNumber, "Text", this.__ttObject, "ConclusionNumber");
        redirectProperty(this.ConclusionDateTime, "Value", this.__ttObject, "ConclusionDateTime");
        redirectProperty(this.RegistrationAuctionNo, "Text", this.__ttObject, "RegistrationAuctionNo");
        redirectProperty(this.AuctionDate, "Value", this.__ttObject, "AuctionDate");
        redirectProperty(this.ExaminationReportDate, "Value", this.__ttObject, "ExaminationReportDate");
        redirectProperty(this.ExaminationReportNo, "Text", this.__ttObject, "ExaminationReportNo");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_ETedarikTuru, "Value", this.__ttObject, "MKYS_ETedarikTuru");
        redirectProperty(this.MKYS_EAlimYontemi, "Value", this.__ttObject, "MKYS_EAlimYontemi");
        redirectProperty(this.GetWaybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
    }

    public initFormControls(): void {
        this.PictureTabpage = new TTVisual.TTTabPage();
        this.PictureTabpage.DisplayIndex = 2;
        this.PictureTabpage.TabIndex = 2;
        this.PictureTabpage.Text = "Fatura";
        this.PictureTabpage.Name = "PictureTabpage";

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.invoicePictureControl = new TTVisual.TTPictureBoxControl();
        this.invoicePictureControl.Name = "invoicePictureControl";
        this.invoicePictureControl.TabIndex = 0;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 145;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.RegistrationAuctionNo = new TTVisual.TTTextBox();
        this.RegistrationAuctionNo.Required = true;
        this.RegistrationAuctionNo.BackColor = "#FFE3C6";
        this.RegistrationAuctionNo.Name = "RegistrationAuctionNo";
        this.RegistrationAuctionNo.TabIndex = 139;

        this.MKYS_TeslimEden = new TTVisual.TTTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 134;

        this.MKYS_TeslimAlan = new TTVisual.TTTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.ExaminationReportNo = new TTVisual.TTTextBox();
        this.ExaminationReportNo.Name = "ExaminationReportNo";
        this.ExaminationReportNo.TabIndex = 130;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.ConclusionNumber = new TTVisual.TTTextBox();
        this.ConclusionNumber.Required = true;
        this.ConclusionNumber.BackColor = "#F0F0F0";
        this.ConclusionNumber.ReadOnly = true;
        this.ConclusionNumber.Name = "ConclusionNumber";
        this.ConclusionNumber.TabIndex = 5;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 149;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Long;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 148;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.GetWaybill = new TTVisual.TTButton();
        this.GetWaybill.Text = i18n("M16570", "İrsaliye Getir");
        this.GetWaybill.Name = "GetWaybill";
        this.GetWaybill.TabIndex = 147;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 146;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 144;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 143;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14807", "Giriş Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 142;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 141;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.labelRegistrationAuctionNo = new TTVisual.TTLabel();
        this.labelRegistrationAuctionNo.Text = i18n("M16214", "İhale No");
        this.labelRegistrationAuctionNo.Name = "labelRegistrationAuctionNo";
        this.labelRegistrationAuctionNo.TabIndex = 140;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.labelAuctionDate = new TTVisual.TTLabel();
        this.labelAuctionDate.Text = i18n("M16199", "İhale  Tarihi");
        this.labelAuctionDate.Name = "labelAuctionDate";
        this.labelAuctionDate.TabIndex = 138;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.AuctionDate = new TTVisual.TTDateTimePicker();
        this.AuctionDate.Required = true;
        this.AuctionDate.BackColor = "#FFE3C6";
        this.AuctionDate.Format = DateTimePickerFormat.Short;
        this.AuctionDate.Name = "AuctionDate";
        this.AuctionDate.TabIndex = 137;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.labelExaminationReportNo = new TTVisual.TTLabel();
        this.labelExaminationReportNo.Text = i18n("M19214", "Muayene Sayısı");
        this.labelExaminationReportNo.Name = "labelExaminationReportNo";
        this.labelExaminationReportNo.TabIndex = 131;

        this.labelExaminationReportDate = new TTVisual.TTLabel();
        this.labelExaminationReportDate.Text = i18n("M19222", "Muayene Tarihi");
        this.labelExaminationReportDate.Name = "labelExaminationReportDate";
        this.labelExaminationReportDate.TabIndex = 129;

        this.ExaminationReportDate = new TTVisual.TTDateTimePicker();
        this.ExaminationReportDate.Format = DateTimePickerFormat.Long;
        this.ExaminationReportDate.Name = "ExaminationReportDate";
        this.ExaminationReportDate.TabIndex = 128;

        this.labelConclusionNumber = new TTVisual.TTLabel();
        this.labelConclusionNumber.Text = i18n("M17276", "Karar Numarası");
        this.labelConclusionNumber.Name = "labelConclusionNumber";
        this.labelConclusionNumber.TabIndex = 123;

        this.labelConclusionDateTime = new TTVisual.TTLabel();
        this.labelConclusionDateTime.Text = i18n("M17284", "Karar Tarihi");
        this.labelConclusionDateTime.Name = "labelConclusionDateTime";
        this.labelConclusionDateTime.TabIndex = 121;

        this.ConclusionDateTime = new TTVisual.TTDateTimePicker();
        this.ConclusionDateTime.BackColor = "#F0F0F0";
        this.ConclusionDateTime.Format = DateTimePickerFormat.Short;
        this.ConclusionDateTime.Enabled = false;
        this.ConclusionDateTime.Name = "ConclusionDateTime";
        this.ConclusionDateTime.TabIndex = 6;

        this.labelSupplier = new TTVisual.TTLabel();
        this.labelSupplier.Text = i18n("M14301", "Firma");
        this.labelSupplier.Name = "labelSupplier";
        this.labelSupplier.TabIndex = 119;

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ReadOnly = true;
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 9;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 10;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentDetailTabpage.Name = "ChattelDocumentDetailTabpage";

        this.ChattelDocumentDetailsWithPurchase = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithPurchase.Required = true;
        this.ChattelDocumentDetailsWithPurchase.Text = i18n("M12146", "Bütçe Türü");
        this.ChattelDocumentDetailsWithPurchase.Name = "ChattelDocumentDetailsWithPurchase";
        this.ChattelDocumentDetailsWithPurchase.TabIndex = 0;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = "MaterialListDefinition";
        this.MaterialStockActionDetailIn.DataMember = "Material";
        this.MaterialStockActionDetailIn.AutoCompleteDialogHeight = "60%";
        this.MaterialStockActionDetailIn.AutoCompleteDialogWidth = "50%";
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetailIn.Name = "MaterialStockActionDetailIn";
        this.MaterialStockActionDetailIn.Width = 500;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = "Amount";
        this.AmountStockActionDetailIn.Required = true;
        this.AmountStockActionDetailIn.Format = "N2";
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 4;
        this.AmountStockActionDetailIn.HeaderText = i18n("M19030", "Miktar");
        this.AmountStockActionDetailIn.Name = "AmountStockActionDetailIn";
        this.AmountStockActionDetailIn.Width = 75;

        this.UnitPriceStockActionDetailInWithOutVat = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailInWithOutVat.DataMember = "UnitPriceWithOutVat";
        this.UnitPriceStockActionDetailInWithOutVat.Required = true;
        this.UnitPriceStockActionDetailInWithOutVat.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailInWithOutVat.DisplayIndex = 5;
        this.UnitPriceStockActionDetailInWithOutVat.HeaderText = i18n("M17471", "Kdvsiz Fiyatı");
        this.UnitPriceStockActionDetailInWithOutVat.Name = "UnitPriceStockActionDetailInWithOutVat";
        this.UnitPriceStockActionDetailInWithOutVat.Width = 100;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = true;
        this.ValueAddedTax.Width = 100;

        this.UnitePriceWithVatNoDiscount = new TTVisual.TTTextBoxColumn();
        this.UnitePriceWithVatNoDiscount.DataMember = "UnitPriceWithInVat";
        this.UnitePriceWithVatNoDiscount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitePriceWithVatNoDiscount.DisplayIndex = 7;
        this.UnitePriceWithVatNoDiscount.HeaderText = i18n("M17467", "Kdvli Fiyatı");
        this.UnitePriceWithVatNoDiscount.Name = "UnitePriceWithVatNoDiscount";
        this.UnitePriceWithVatNoDiscount.ReadOnly = true;
        this.UnitePriceWithVatNoDiscount.Width = 120;

        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = "DiscountRate";
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = i18n("M16491", "İndirim Oranı");
        this.MKYS_IndirimOranı.Name = "MKYS_IndirimOranı";
        this.MKYS_IndirimOranı.Width = 100;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = "UnitPrice";
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 9;
        this.UnitPriceStockActionDetailIn.HeaderText = i18n("M16504", "İndirimli Birim Fiyat");
        this.UnitPriceStockActionDetailIn.Name = "UnitPriceStockActionDetailIn";
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 75;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = "DiscountAmount";
        this.MKYS_IndirimTutari.DisplayIndex = 10;
        this.MKYS_IndirimTutari.HeaderText = i18n("M16006", "Indirim Tutarı");
        this.MKYS_IndirimTutari.Name = "MKYS_IndirimTutari";
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Width = 100;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "Price";
        this.TotalPrice.DisplayIndex = 11;
        this.TotalPrice.HeaderText = i18n("M23526", "Toplam Tutar");
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 100;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = "LotNo";
        this.LotNo.DisplayIndex = 12;
        this.LotNo.HeaderText = "Lot No.";
        this.LotNo.Name = "LotNo";
        this.LotNo.Width = 100;

        this.ExpirationDateStockActionDetailIn = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateStockActionDetailIn.Format = DateTimePickerFormat.Custom;
        this.ExpirationDateStockActionDetailIn.CustomFormat = "MM/yyyy";
        this.ExpirationDateStockActionDetailIn.DataMember = "ExpirationDate";
        this.ExpirationDateStockActionDetailIn.DisplayIndex = 13;
        this.ExpirationDateStockActionDetailIn.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDateStockActionDetailIn.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDateStockActionDetailIn.Width = 120;

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeStockActionDetailIn.DataMember = "StockLevelType";
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 14;
        this.StockLevelTypeStockActionDetailIn.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeStockActionDetailIn.Name = "StockLevelTypeStockActionDetailIn";
        this.StockLevelTypeStockActionDetailIn.Visible = false;
        this.StockLevelTypeStockActionDetailIn.Width = 100;

        this.StatusStockActionDetailIn = new TTVisual.TTEnumComboBoxColumn();
        this.StatusStockActionDetailIn.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusStockActionDetailIn.DataMember = "Status";
        this.StatusStockActionDetailIn.DisplayIndex = 15;
        this.StatusStockActionDetailIn.HeaderText = "Durum";
        this.StatusStockActionDetailIn.Name = "StatusStockActionDetailIn";
        this.StatusStockActionDetailIn.Visible = false;
        this.StatusStockActionDetailIn.Width = 80;

        this.MKYS_EdinimYili = new TTVisual.TTTextBoxColumn();
        this.MKYS_EdinimYili.DataMember = "RetrievalYear";
        this.MKYS_EdinimYili.DisplayIndex = 16;
        this.MKYS_EdinimYili.HeaderText = i18n("M13475", "Edinim Yılı");
        this.MKYS_EdinimYili.Name = "MKYS_EdinimYili";
        this.MKYS_EdinimYili.Width = 100;

        this.MKYS_UretimTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MKYS_UretimTarihi.DataMember = "ProductionDate";
        this.MKYS_UretimTarihi.DisplayIndex = 17;
        this.MKYS_UretimTarihi.HeaderText = i18n("M23966", "Üretim Tarihi");
        this.MKYS_UretimTarihi.Name = "MKYS_UretimTarihi";
        this.MKYS_UretimTarihi.Width = 100;

        this.DistributionsTab = new TTVisual.TTTabPage();
        this.DistributionsTab.DisplayIndex = 1;
        this.DistributionsTab.TabIndex = 1;
        this.DistributionsTab.Text = i18n("M16634", "İstek Miktarları");
        this.DistributionsTab.Name = "DistributionsTab";

        this.DemandAmountsGrid = new TTVisual.TTGrid();
        this.DemandAmountsGrid.AllowUserToDeleteRows = false;
        this.DemandAmountsGrid.RowHeadersVisible = false;
        this.DemandAmountsGrid.Name = "DemandAmountsGrid";
        this.DemandAmountsGrid.TabIndex = 0;

        this.DA_Material = new TTVisual.TTListBoxColumn();
        this.DA_Material.ListDefName = "MaterialListDefinition";
        this.DA_Material.DisplayIndex = 0;
        this.DA_Material.HeaderText = i18n("M18545", "Malzeme");
        this.DA_Material.Name = "DA_Material";
        this.DA_Material.ReadOnly = true;
        this.DA_Material.Visible = false;
        this.DA_Material.Width = 350;

        this.DA_MasterResource = new TTVisual.TTListBoxColumn();
        this.DA_MasterResource.ListDefName = "ResourceListDefinition";
        this.DA_MasterResource.DataMember = "MasterResource";
        this.DA_MasterResource.DisplayIndex = 1;
        this.DA_MasterResource.HeaderText = "Birim";
        this.DA_MasterResource.Name = "DA_MasterResource";
        this.DA_MasterResource.ReadOnly = true;
        this.DA_MasterResource.Width = 350;

        this.DA_DemandAmount = new TTVisual.TTTextBoxColumn();
        this.DA_DemandAmount.DataMember = "Amount";
        this.DA_DemandAmount.DisplayIndex = 2;
        this.DA_DemandAmount.HeaderText = i18n("M16632", "İstek Miktarı");
        this.DA_DemandAmount.Name = "DA_DemandAmount";
        this.DA_DemandAmount.ReadOnly = true;
        this.DA_DemandAmount.Width = 100;

        this.DA_DistributionAmount = new TTVisual.TTTextBoxColumn();
        this.DA_DistributionAmount.DataMember = "DistributionAmount";
        this.DA_DistributionAmount.DisplayIndex = 3;
        this.DA_DistributionAmount.HeaderText = i18n("M12443", "Dağıtım Miktarı");
        this.DA_DistributionAmount.Name = "DA_DistributionAmount";
        this.DA_DistributionAmount.Visible = false;
        this.DA_DistributionAmount.Width = 100;

        this.txtDiscount = new TTVisual.TTTextBox();
        this.txtDiscount.BackColor = "#F0F0F0";
        this.txtDiscount.ReadOnly = true;
        this.txtDiscount.Name = "txtDiscount";
        this.txtDiscount.TabIndex = 124;

        this.txtWithKDV = new TTVisual.TTTextBox();
        this.txtWithKDV.BackColor = "#F0F0F0";
        this.txtWithKDV.ReadOnly = true;
        this.txtWithKDV.Name = "txtWithKDV";
        this.txtWithKDV.TabIndex = 134;

        this.txtNotKDV = new TTVisual.TTTextBox();
        this.txtNotKDV.BackColor = "#F0F0F0";
        this.txtNotKDV.ReadOnly = true;
        this.txtNotKDV.Name = "txtNotKDV";
        this.txtNotKDV.TabIndex = 124;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M23503", "Toplam İndirim Tutarı");
        this.ttlabel2.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 125;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M14100", "Fatura  Tutarı");
        this.ttlabel3.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 125;

        this.MKYS_EAlimYontemi = new TTVisual.TTEnumComboBox();
        this.MKYS_EAlimYontemi.DataTypeName = "MKYS_EAlimYontemiEnum";
        this.MKYS_EAlimYontemi.Required = true;
        this.MKYS_EAlimYontemi.BackColor = "#FFE3C6";
        this.MKYS_EAlimYontemi.Name = "MKYS_EAlimYontemi";
        this.MKYS_EAlimYontemi.TabIndex = 19;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = "MKYS_ETedarikTurEnum";
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = "#F0F0F0";
        this.MKYS_ETedarikTuru.Enabled = false;
        this.MKYS_ETedarikTuru.Name = "MKYS_ETedarikTuru";
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = i18n("M14804", "Giriş Türü");
        this.labelMKYS_ETedarikTuru.Name = "labelMKYS_ETedarikTuru";
        this.labelMKYS_ETedarikTuru.TabIndex = 14;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EAlimYontemi = new TTVisual.TTLabel();
        this.labelMKYS_EAlimYontemi.Text = i18n("M10699", "Alım Yöntemi");
        this.labelMKYS_EAlimYontemi.Name = "labelMKYS_EAlimYontemi";
        this.labelMKYS_EAlimYontemi.TabIndex = 18;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M17470", "KDV'siz Birim Fiyatlar Toplamı");
        this.ttlabel4.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 125;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M17465", "KDV'li Birim Fiyatlar Toplamı");
        this.ttlabel5.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 125;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentDetailsWithPurchaseColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount, this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi];
        this.DemandAmountsGridColumns = [this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount];
        this.PictureTabpage.Controls = [this.invoicePictureControl];
        this.DescriptionAndSignTabControl.Controls = [this.PictureTabpage, this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentDetailTabpage, this.DistributionsTab];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithPurchase];
        this.DistributionsTab.Controls = [this.DemandAmountsGrid];
        this.Controls = [this.PictureTabpage, this.TTTeslimEdenButon, this.invoicePictureControl, this.TTTeslimAlanButon, this.Waybill, this.labelMKYS_TeslimEden, this.RegistrationAuctionNo, this.MKYS_TeslimEden, this.txtTotalPrice, this.MKYS_TeslimAlan, this.ExaminationReportNo, this.Description, this.ConclusionNumber, this.StockActionID, this.labelWaybillDate, this.labelMKYS_TeslimAlan, this.WaybillDate, this.labelTransactionDate, this.GetWaybill, this.TransactionDate, this.labelWaybill, this.labelStockActionID, this.labelBudgetTypeDefinition, this.DescriptionAndSignTabControl, this.BudgetTypeDefinition, this.SignTabpage, this.labelStore, this.StockActionSignDetails, this.Store, this.SignUserType, this.labelRegistrationAuctionNo, this.SignUser, this.labelAuctionDate, this.IsDeputy, this.AuctionDate, this.ttlabel1, this.labelExaminationReportNo, this.labelExaminationReportDate, this.ExaminationReportDate, this.labelConclusionNumber, this.labelConclusionDateTime, this.ConclusionDateTime, this.labelSupplier, this.Supplier, this.ChattelDocumentTabcontrol, this.ChattelDocumentDetailTabpage, this.ChattelDocumentDetailsWithPurchase, this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount, this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.DistributionsTab, this.DemandAmountsGrid, this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount, this.txtDiscount, this.txtWithKDV, this.txtNotKDV, this.ttlabel2, this.ttlabel3, this.MKYS_EAlimYontemi, this.labelMKYS_EMalzemeGrup, this.MKYS_ETedarikTuru, this.labelMKYS_ETedarikTuru, this.MKYS_EMalzemeGrup, this.labelMKYS_EAlimYontemi, this.ttlabel4, this.ttlabel5];

    }


}

export class RespectiveIncomingUTSNotification {
    public IncomingReceiveNotificationID: string;
    public chattelDocumentDetailsWithPurchase: ChattelDocumentDetailWithPurchase;
}

export class UTSBatchGridDataType {
    IncomingDeliveryNotifID: string;
    ProductName: string;
    ProductNo: string;
    SendingOrganizationNo: number; //Gönderen Kurum Kodu
    UniqueDeviceIdentifier: string; //Eşsiz Kimlik
    LotNumber: string; // Lot/Batch Numarası
    SerialNumber: string; // Seri Numarası
    ReceivedMaterial: Material;
    DocumentNo: string;
    Amount: number;
}

export class PTSInputDVO {
    PTSID: string;
    stockAction: StockAction;
}

export class XMLReadDocumentFile {
    xmlFileName: string;
    xmlFile: string;
    stockAction: StockAction;
}

export class PTSMaterialSerialNumber {
    serialNo: string;
    amount: number;
    @Type(() => ChattelDocumentDetailWithPurchase)
    chattelDocumentDetailWithPurchase: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
}

export class PTSMaterialOutput {
    @Type(() => PTSMaterial)
    PTSMaterials: Array<PTSMaterial> = new Array<PTSMaterial>();
    @Type(() => StockCard)
    StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => StockLevelType)
    StockLevelType: StockLevelType;
}

export class PTSMaterial {

    ID: number;
    @Type(() => Guid)
    materialObjectID: Guid;
    @Type(() => Material)
    material: Material;
    barcode: string;
    materialName: string;
    @Type(() => Date)
    expirationDate: Date;
    lotNO: string;
    price: number;
    serialNOList: Array<PTSMaterialSerialNumber> = new Array<PTSMaterialSerialNumber>();
    supplier: Supplier;
    accountancy: Accountancy;
    amount: number;
    NatoStockNo: string;
    DistributionTypeName: string;
    UnitPriceWithOutVat: number;
    VatRate: number;
    UnitPriceWithInVat: number;
    DiscountRate: number;
    UnitPrice: number;
    DiscountAmount: number;
    RetrievalYear: number;
    @Type(() => Date)
    ProductionDate: Date;

    DocumentRecordNo: string;
    @Type(() => Date)
    DocumentRecordDate: Date;

    @Type(() => PTSStockActionDetail)
    PTSStockActionDetail: PTSStockActionDetail;

}
