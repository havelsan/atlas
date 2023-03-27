//$2484EEFE
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { BaseChattelDocumentInputWithAccountancyFormViewModel } from './BaseChattelDocumentInputWithAccountancyFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Accountancy, StockCard, DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BaseChattelDocumentForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentForm";
import { ChattelDocumentInputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentInputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { StockLevelTypeService } from "ObjectClassService/StockLevelTypeService";
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum, Supplier, MKYS_EMalzemeGrupEnum } from 'NebulaClient/Model/AtlasClientModel';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { Convert } from "app/NebulaClient/Mscorlib/Convert";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { PTSMaterial } from './BaseChattelDocumentWithPurchaseForm';
import { LogisticDocumentUploadFormInput } from 'app/Logistic/Views/LogiscticDocumentComponents/LogisticPatientDocumentUploadForm';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { StockActionService, GetInPatientPhysicianApplications_Output } from 'NebulaClient/Services/ObjectService/StockActionService';

@Component({
    selector: 'BaseChattelDocumentInputWithAccountancyForm',
    templateUrl: './BaseChattelDocumentInputWithAccountancyForm.html',
    providers: [MessageService]
})
export class BaseChattelDocumentInputWithAccountancyForm extends BaseChattelDocumentForm implements OnInit {
    Accountancy: TTVisual.ITTObjectListBox;
    AmountStockActionDetailIn: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    BudgetTypeDefinition: TTVisual.ITTObjectListBox;
    ChattelDocumentDetailsWithAccountancy: TTVisual.ITTGrid;
    ChattelDocumentDetailTabpage: TTVisual.ITTTabPage;
    ChattelDocumentTabcontrol: TTVisual.ITTTabControl;
    ConflictAmountChattelDocumentInputDetailWithAccountancy: TTVisual.ITTTextBoxColumn;
    ConflictSubjectChattelDocumentInputDetailWithAccountancy: TTVisual.ITTTextBoxColumn;
    Detail: TTVisual.ITTButtonColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    ExpirationDateStockActionDetailIn: TTVisual.ITTDateTimePickerColumn;
    GetWaybill: TTVisual.ITTButton;
    inputWithAccountancyType: TTVisual.ITTEnumComboBox;
    labelAccountancy: TTVisual.ITTLabel;
    labelBudgetTypeDefinition: TTVisual.ITTLabel;
    labelinputWithAccountancyType: TTVisual.ITTLabel;
    labelMKYS_EAlimYontemi: TTVisual.ITTLabel;
    labelMKYS_EMalzemeGrup: TTVisual.ITTLabel;
    labelMKYS_ETedarikTuru: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
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
    NotDiscountedUnitPrice: TTVisual.ITTTextBoxColumn;
    SentAmountChattelDocumentInputDetailWithAccountancy: TTVisual.ITTTextBoxColumn;
    StatusStockActionDetailIn: TTVisual.ITTEnumComboBoxColumn;
    StockLevelTypeStockActionDetailIn: TTVisual.ITTListDefComboBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    TotalDiscountAmount: TTVisual.ITTTextBoxColumn;
    TotalPrice: TTVisual.ITTTextBoxColumn;
    TotalPriceNotDiscount: TTVisual.ITTTextBoxColumn;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    txtSalesTotal: TTVisual.ITTTextBox;
    txtTotalNotDiscount: TTVisual.ITTTextBox;
    txtTotalPrice: TTVisual.ITTTextBox;
    txtBarkod: TTVisual.ITTTextBox;
    UnitPriceStockActionDetailIn: TTVisual.ITTTextBoxColumn;
    Waybill: TTButtonTextBox;
    WaybillDate: TTVisual.ITTDateTimePicker;
    ValueAddedTax: TTVisual.ITTTextBoxColumn;
    Supplier: TTVisual.ITTObjectListBox;
    public expirationMinDate: Date = new Date(Date.now());

    public ChattelDocumentDetailsWithAccountancyColumns = [];
    public StockActionSignDetailsColumns = [];
    public baseChattelDocumentInputWithAccountancyFormViewModel: BaseChattelDocumentInputWithAccountancyFormViewModel = new BaseChattelDocumentInputWithAccountancyFormViewModel();
    public get _ChattelDocumentInputWithAccountancy(): ChattelDocumentInputWithAccountancy {
        return this._TTObject as ChattelDocumentInputWithAccountancy;
    }
    private BaseChattelDocumentInputWithAccountancyForm_DocumentUrl: string = '/api/ChattelDocumentInputWithAccountancyService/BaseChattelDocumentInputWithAccountancyForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone, protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseChattelDocumentInputWithAccountancyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async Accountancy_SelectedObjectChanged(): Promise<void> {
        //this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.DeleteChildren();
    }
    private async ChattelDocumentDetailsWithAccountancy_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name === 'Detail')
            this.ShowStockActionDetailForm(<StockActionDetail>this.ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningRow.TTObject);
    }
    private async ChattelDocumentDetailsWithAccountancy_CellDoubleClick(rowIndex: number, columnIndex: number): Promise<void> {
        this.CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, this.ChattelDocumentDetailsWithAccountancy);
    }
    public async ChattelDocumentDetailsWithAccountancy_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let detail: ChattelDocumentInputDetailWithAccountancy = <ChattelDocumentInputDetailWithAccountancy>data.Row.TTObject;
        if (this._ChattelDocumentInputWithAccountancy.Accountancy === null) {
            TTVisual.InfoBox.Show(i18n("M19999", "Önce Saymanlık Seçiniz"));
        }
        else {
            if (data.Column.Name === "AmountStockActionDetailIn" || data.Column.Name === "UnitPriceStockActionDetailIn" || data.Column.Name === "ValueAddedTax") {
                let tPrice: number = await this.CalculateTotalPrice();
                this.txtTotalPrice.Text = tPrice.toString();
            }
            if (data.Column.Name === "SentAmountChattelDocumentInputDetailWithAccountancy" || data.Column.Name === "AmountStockActionDetailIn") {
                let conflic: number = 0;
                if (detail.Amount !== null) {
                    detail.SentAmount = detail.Amount;
                }
                if (detail.Amount != null && detail.SentAmount != null) {
                    conflic = detail.Amount - detail.SentAmount;
                    detail.ConflictSubject = conflic.toString();
                }
            }
        }
        if (data.Column.Name === "MKYS_IndirimOranı" || data.Column.Name === "NotDiscountedUnitPrice" || data.Column.Name === "AmountStockActionDetailIn" || data.Column.Name === "ValueAddedTax") {
            await this.CalculatePrices(detail);
            let priceCalc: Array<number> = new Array<number>();
            let total: number = 0, salesTotal = 0, totalPrice = 0;
            priceCalc.push(total);
            priceCalc.push(salesTotal);
            priceCalc.push(totalPrice);
            priceCalc = await this.CalcFinalPrice(priceCalc);
            this.txtTotalNotDiscount.Text = priceCalc[0].toFixed(2);
            this.txtSalesTotal.Text = priceCalc[1].toFixed(2);
            this.txtTotalPrice.Text = priceCalc[2].toFixed(2);
        }
        if (detail.Status === undefined) {
            detail.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            detail.StockLevelType = stockLeveltypeArray[0];
        }
        let today = new Date();
        let year = today.getFullYear();
        detail.RetrievalYear = year;

        if (data.Column.Name === "ExpirationDateStockActionDetailIn") {
            let endOfMonth: Date = new Date(detail.ExpirationDate.getFullYear(), detail.ExpirationDate.getMonth() + 1, 1).AddDays(-1);
            detail.ExpirationDate = endOfMonth;
        }
        if (data.Column.Name === "LotNo") {
            console.log(data);
        }
    }
    //#region dx-data-grid çevirme
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public selectedSupplier: Supplier;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();

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

    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
    }




    public async onSupplierChanged(event) {
        if (event != null) {
            let supplier = <Supplier>event;
            if (this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf) // mevzuat gereği tıbbi sarf malzemelerde bayi no alanı zorunlu hale geldi.
            {
                if (String.isNullOrEmpty(supplier.SupplierNumber)) {
                    ServiceLocator.MessageService.showError("Seçilen firma için bayi no bilgisi bulunmamaktadır. Tıbbi Sarf malzemeler için bayi no bilgisi " + supplier.Name + " firması için tanımlanmalı.");
                    this.selectedSupplier = event;
                    this.SupplierVisible = true;
                }
            }
        }
        this.selectedSupplier = event;
    }

    private IsSupplierValidated() {
        if (this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf) {
            if (this.selectedSupplier == null) {
                ServiceLocator.MessageService.showError('Sağlayıcı bayi seçimi yapınız!');
                return false;
            }
            else if (String.isNullOrEmpty(this.selectedSupplier.SupplierNumber)) {
                ServiceLocator.MessageService.showError(this.selectedSupplier.Name + ' için Bayi No alanını tanım ekranında doldurunuz!');
                this.SupplierVisible = true;
                return false;
            }
        }
        return true;
    }
    public async btnAddClick() {
        if (this.IsSupplierValidated()) {
            let drugDefinitionObjDefId: Guid = DrugDefinition.ObjectDefID;
            if (this.selectedMaterial == null) {
                ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
            }
            else {
                if (this.selectedMaterial.IsIndividualTrackingRequired === true) {
                    ServiceLocator.MessageService.showError('Giriş yapmak istediğiniz malzeme ÜTS Tekil Takip Gerektiren Malzemelerdendir. Lütfen Alma Bildirimi sorgulama işlemi yapınız!');
                    return;
                }

                if ((<DrugDefinition>this.selectedMaterial).IsITSDrug === true) {
                    ServiceLocator.MessageService.showError('Giriş yapmak istediğiniz malzeme ITS Malzemelerdendir. Lütfen PTS Getir işlemi yapınız!');
                    return;
                }

                //if (!this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID)) {
                let newRow: ChattelDocumentInputDetailWithAccountancy = new ChattelDocumentInputDetailWithAccountancy();
                newRow.Material = this.selectedMaterial;
                let stockCardObj: Guid = <any>this.selectedMaterial['StockCard'];
                let stockCard: StockCard = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
                newRow.Material.StockCard = stockCard;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                newRow.Supplier = this.selectedSupplier;
                this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.push(newRow);
                //}
                //else
                //    ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");

            }
        }
    }

    public async addLogisticPatientDocument() {
        if(this._ChattelDocumentInputWithAccountancy.InPatientPhysicianApplication != null){
            let objId: Guid;
            if (this._ChattelDocumentInputWithAccountancy.InPatientPhysicianApplication.ObjectID != null)
                objId = this._ChattelDocumentInputWithAccountancy.InPatientPhysicianApplication.ObjectID;
            else{
                let objIdstr: any = this._ChattelDocumentInputWithAccountancy["InPatientPhysicianApplication"];
                objId = new Guid(objIdstr);
            }

        let input: LogisticDocumentUploadFormInput = await StockActionService.GetLogisticPatientDocumentInputDVO(objId);
        this.openLogisticPatientDocument(input);
        } else {
            ServiceLocator.MessageService.showError("Hasta seçilmemiş işlemler de döküman ekleyemezsiniz.")
        }
    }

    public openLogisticPatientDocument(input: LogisticDocumentUploadFormInput) {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'LogisticPatientDocumentUploadForm';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = input;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M15185", "Hasta Dosyasına Yükle");
            modalInfo.Width = 700;
            modalInfo.Height = 500;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }



    private SupplierVisible: boolean = false;
    private UpdatedSupplierNumber: string = "";
    async SaveSupplierNumber() {

        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/BaseChattelDocumentService/UpdateSupplierNumber';
            if (this.selectedSupplier != null && this.UpdatedSupplierNumber != null) {
                let body = { 'SupplierObjectId': this.selectedSupplier.ObjectID, 'SupplierNumber': this.UpdatedSupplierNumber };
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });
                await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                    if (response.IsSuccess) {
                        ServiceLocator.MessageService.showInfo(response.SuccessMessage);
                        this.selectedSupplier.SupplierNumber = this.UpdatedSupplierNumber;
                        this.UpdatedSupplierNumber = "";
                        this.SupplierVisible = false;
                    } else {
                        ServiceLocator.MessageService.showError("Hata : " + response.ErrorMessage);
                    }

                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
            else {
                ServiceLocator.MessageService.showError("Bayi No Giriniz.");
            }

        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public CalculateFormTotalPrice() {
        let prices: Array<number> = new Array<number>();
        let total: number = 0, salesTotal = 0, totalPrice = 0;
        prices.push(total);
        prices.push(salesTotal);
        prices.push(totalPrice);
        for (let data of this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {
            if (data.NotDiscountedUnitPrice == null || data.TotalDiscountAmount == null)
                continue;
            prices[0] += data.TotalPriceNotDiscount;
            prices[1] += data.TotalDiscountAmount;
        }
        prices[2] = prices[0] - prices[1];
        this.txtTotalNotDiscount.Text = prices[0].toFixed(2);
        this.txtSalesTotal.Text = prices[1].toFixed(2);
        this.txtTotalPrice.Text = prices[2].toFixed(2);
    }



    //TODO MK: Sadece Amount, VatRate ve NotDiscountedUnitPrice cell leri değiştiğinde tetiklenecek şekilde yapılacak..
    public MaterialGridCellChanged(data: ChattelDocumentInputDetailWithAccountancy) {
        //let data = <ChattelDocumentInputDetailWithAccountancy>event.key;
        //let detail: ChattelDocumentInputDetailWithAccountancy = <ChattelDocumentInputDetailWithAccountancy>data.Row.TTObject;
        if (this._ChattelDocumentInputWithAccountancy.Accountancy === null) {
            TTVisual.InfoBox.Show(i18n("M19999", "Önce Saymanlık Seçiniz"));
        }
        else {
            if (data.Amount <= 0 || data.NotDiscountedUnitPrice <= 0) {
                ServiceLocator.MessageService.showError('Miktar ve İndirimsiz Birim Fiyat sıfırdan küçük olamaz!');
                return;
            }
            if (data.VatRate < 0) {
                ServiceLocator.MessageService.showError('KDV Oranı sıfırdan küçük olamaz!');
                return;
            }

            if (data.Amount != null && data.VatRate != null && data.NotDiscountedUnitPrice != null) {
                let KdvOrani: number = data.VatRate / 100;
                let unitPriceWithKDV: number = data.NotDiscountedUnitPrice + (data.NotDiscountedUnitPrice * KdvOrani);
                if (data.DiscountRate == null)
                    data.DiscountRate = 0;
                let indirimliBirimFiyat: number = unitPriceWithKDV - (unitPriceWithKDV * data.DiscountRate / 100);
                data.UnitPrice = Math.Round(indirimliBirimFiyat, 6);
                //data.PTSStockActionDetail.UnitPrice = Math.Round(indirimliBirimFiyat, 6);
                data.TotalPriceNotDiscount = Math.Round(unitPriceWithKDV * data.Amount, 6);
                //data.PTSStockActionDetail.DiscountAmount = Math.Round(unitPriceWithKDV * data.Amount, 6);
                let indirimliToplamFiyat: number = Math.Round(indirimliBirimFiyat * data.Amount, 6);
                data.Price = indirimliToplamFiyat;
                data.SentAmount = data.Amount;
                data.ConflictSubject = (data.Amount - data.SentAmount).toString();
                //data.PTSStockActionDetail.VatRate = data.VatRate;
                //data.PTSStockActionDetail.NotDiscountedUnitPrice = Math.Round(data.NotDiscountedUnitPrice, 6);

                data.TotalDiscountAmount = Math.Round(data.TotalPriceNotDiscount - indirimliToplamFiyat, 6);
                if (data.RetrievalYear == null) {
                    let today = new Date();
                    let year = today.getFullYear();
                    data.RetrievalYear = year;
                }
                this.CalculateFormTotalPrice();
            }
        }
    }
    public onMaterialGridRowRemoving(event: any) {
        if (event.key.ObjectID != null && this._ChattelDocumentInputWithAccountancy.CurrentStateDefID == ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.New) {
            this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.find(x => x.ObjectID == event.data.ObjectID).EntityState = EntityStateEnum.Deleted;
            this.materialGrid.instance.filter(['EntityState', '<>', 1]);
            event.cancel = true;
        }
    }

    public onMaterialGridRowRemoved(event: any) {
        this.CalculateFormTotalPrice();
    }

    public onMaterialGridRowUpdated(event: any) {
        //console.log(event);
        let data = <ChattelDocumentInputDetailWithAccountancy>event.key;
        this.MaterialGridCellChanged(data);
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
            caption: 'Malzeme Adı',
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
            caption: 'Bayi',
            dataField: 'Supplier.Name',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'Ölçü Birimi',
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Miktar',
            dataField: 'Amount',
            dataType: 'number',
            // format: '#',
            // editorOptions: {
            //     onKeyPress: function (e) {
            //         var event = e.event,
            //             str = String.fromCharCode(event.keyCode);
            //         if (!/[0-9]/.test(str))
            //             event.preventDefault();
            //     }
            // },
            width: 'auto'
        },
        {
            caption: 'İnd.siz Birim Fiyat',
            dataField: 'NotDiscountedUnitPrice',
            dataType: 'number',
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 6) + ' TL';
            //     }
            //     //format: "#,##0.## TL",
            // },
            width: 'auto'
        },
        {
            caption: 'KDV Oranı',
            dataField: 'VatRate',
            dataType: 'number',
            width: 100
        },
        {
            caption: 'İndirim Oranı',
            dataField: 'DiscountRate',
            dataType: 'number',
            width: 'auto'
        },
        {
            caption: 'Birim Mal Bedeli',
            dataField: 'UnitPrice',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'İnd.siz Top. Fiyat',
            dataField: 'TotalPriceNotDiscount',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Top. İnd. Tutarı',
            dataField: 'TotalDiscountAmount',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Tutarı',
            dataField: 'Price',
            dataType: 'number',
            allowEditing: false,
            width: 75
        },
        {
            caption: 'Lot No.',
            dataField: 'LotNo',
            width: 75
        },
        {
            caption: 'Seri No.',
            dataField: 'SerialNo',
            width: 75
        },
        {
            caption: 'Son Kul. Tarihi',
            dataField: 'ExpirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150,
            editorOptions: {
                min: this.expirationMinDate,
            }
        },
        {
            caption: 'Malın Durumu',
            dataField: 'StockLevelType.Description',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Edinim Yılı',
            dataField: 'RetrievalYear',
            dataType: 'number',
            width: 85
        },
        {
            caption: 'Üretim Tarihi',
            dataField: 'ProductionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150
        }
    ];

    //#endregion

    public async CalcFinalPrice(prices: Array<number>): Promise<Array<number>> {

        if (this._ChattelDocumentInputWithAccountancy.IsPTSAction == true) {
            for (let inDet of this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {
                if (inDet.TotalPriceNotDiscount == null || inDet.TotalDiscountAmount == null)
                    continue;
                prices[0] += Number(inDet.Amount * inDet.UnitPrice);
                prices[1] += 0; //
            }
            prices[2] = prices[0] - prices[1];
        }
        else {
            for (let inDet of this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {
                if (inDet.TotalPriceNotDiscount == null || inDet.TotalDiscountAmount == null)
                    continue;
                prices[0] += Number(inDet.TotalPriceNotDiscount);
                prices[1] += Number(inDet.TotalDiscountAmount); //
            }
            prices[2] = prices[0] - prices[1];
        }
        return prices;
    }

    public async CalculateTotalPrice(): Promise<number> {
        let totalPrice: number = 0;
        for (let inDet of this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {
            if (inDet.Amount == null && inDet.UnitPrice == null)
                continue;
            totalPrice += Number(inDet.Amount) * Number(inDet.UnitPrice);
        }
        return totalPrice;
    }

    public async CalculatePrices(detail: ChattelDocumentInputDetailWithAccountancy): Promise<void> {
        if (detail.NotDiscountedUnitPrice != null) {
            detail.UnitPrice = Convert.ToInt32(detail.NotDiscountedUnitPrice.toFixed(6));
            if (detail.Amount != null) {
                if (detail.DiscountRate == null) {
                    detail.DiscountRate = 0;
                }
                if (detail.VatRate == null) {
                    detail.DiscountRate = 0;
                }
                let indirimsizFiyat: BigCurrency = <BigCurrency>detail.NotDiscountedUnitPrice;
                let miktar: Currency = <Currency>detail.Amount;
                let kdv: number = (<number>(Convert.ToDouble(detail.VatRate)));
                let KdvOrani: number = (Convert.ToDouble(kdv) / 100);
                let birimFiyatKDVli: BigCurrency = (<BigCurrency>((indirimsizFiyat + ((<BigCurrency>(Convert.ToDouble(indirimsizFiyat))) * (<BigCurrency>(KdvOrani))))));
                let indirimOrani: BigCurrency = <BigCurrency>detail.DiscountRate;
                let indirimliBirimFiyat: BigCurrency = <BigCurrency>(birimFiyatKDVli - (birimFiyatKDVli * indirimOrani / 100));
                detail.UnitPrice = Convert.ToInt32(indirimliBirimFiyat.toFixed(6));
                let indirimsizToplamFiyat: BigCurrency = birimFiyatKDVli * <BigCurrency>miktar;
                detail.TotalPriceNotDiscount = Convert.ToInt32(indirimsizToplamFiyat.toFixed(6));
                let indirimliToplamFiyat: BigCurrency = indirimliBirimFiyat * <BigCurrency>miktar;
                detail.Price = Convert.ToInt32(indirimliToplamFiyat.toFixed(6));
                let toplamIndirim: BigCurrency = indirimsizToplamFiyat - indirimliToplamFiyat;
                detail.TotalDiscountAmount = Convert.ToInt32(toplamIndirim.toFixed(6));
            }
        }
    }
    protected async PreScript() {
        super.PreScript();
        /*let tPrice: number = await this.CalculateTotalPrice();
        this.txtTotalPrice.Text = tPrice.toString();*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentInputWithAccountancy();
        this.baseChattelDocumentInputWithAccountancyFormViewModel = new BaseChattelDocumentInputWithAccountancyFormViewModel();
        this._ViewModel = this.baseChattelDocumentInputWithAccountancyFormViewModel;
        this.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy = this._TTObject as ChattelDocumentInputWithAccountancy;
        this.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.Store = new Store();
        this.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.Accountancy = new Accountancy();
        this.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = new Array<ChattelDocumentInputDetailWithAccountancy>();
        this.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseChattelDocumentInputWithAccountancyFormViewModel = this._ViewModel as BaseChattelDocumentInputWithAccountancyFormViewModel;
        that._TTObject = this.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy;
        if (this.baseChattelDocumentInputWithAccountancyFormViewModel == null)
            this.baseChattelDocumentInputWithAccountancyFormViewModel = new BaseChattelDocumentInputWithAccountancyFormViewModel();
        if (this.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy == null)
            this.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy = new ChattelDocumentInputWithAccountancy();
        let budgetTypeDefinitionObjectID = that.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === "string")) {
            let budgetTypeDefinition = that.baseChattelDocumentInputWithAccountancyFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.baseChattelDocumentInputWithAccountancyFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.Store = store;
            }
        }
        let accountancyObjectID = that.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy["Accountancy"];
        if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
            let accountancy = that.baseChattelDocumentInputWithAccountancyFormViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.Accountancy = accountancy;
            }
        }
        that.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = that.baseChattelDocumentInputWithAccountancyFormViewModel.ChattelDocumentDetailsWithAccountancyGridList;
        for (let detailItem of that.baseChattelDocumentInputWithAccountancyFormViewModel.ChattelDocumentDetailsWithAccountancyGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.baseChattelDocumentInputWithAccountancyFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.baseChattelDocumentInputWithAccountancyFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.baseChattelDocumentInputWithAccountancyFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === "string")) {
                let stockLevelType = that.baseChattelDocumentInputWithAccountancyFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.baseChattelDocumentInputWithAccountancyFormViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails = that.baseChattelDocumentInputWithAccountancyFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseChattelDocumentInputWithAccountancyFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.baseChattelDocumentInputWithAccountancyFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(BaseChattelDocumentInputWithAccountancyFormViewModel);

    }


    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Accountancy != event) {
                this._ChattelDocumentInputWithAccountancy.Accountancy = event;
            }
        }
        this.Accountancy_SelectedObjectChanged();
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition != event) {
                this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Description != event) {
                this._ChattelDocumentInputWithAccountancy.Description = event;
            }
        }
    }

    public oninputWithAccountancyTypeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType != event) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = event;
            }
        }
    }

    public onMKYS_EAlimYontemiChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden != event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.StockActionID != event) {
                this._ChattelDocumentInputWithAccountancy.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Store != event) {
                this._ChattelDocumentInputWithAccountancy.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.TransactionDate != event) {
                this._ChattelDocumentInputWithAccountancy.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Waybill != event) {
                this._ChattelDocumentInputWithAccountancy.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.WaybillDate != event) {
                this._ChattelDocumentInputWithAccountancy.WaybillDate = event;
            }
        }
    }

    ChattelDocumentDetailsWithAccountancy_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithAccountancy_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_ETedarikTuru, "Value", this.__ttObject, "MKYS_ETedarikTuru");
        redirectProperty(this.MKYS_EAlimYontemi, "Value", this.__ttObject, "MKYS_EAlimYontemi");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.inputWithAccountancyType, "Value", this.__ttObject, "inputWithAccountancyType");
        redirectProperty(this.Waybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
    }

    public initFormControls(): void {
        this.Waybill = new TTButtonTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 132;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 124;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 135;

        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Long;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 134;

        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 133;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 129;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 128;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = "10%";
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = "20%";

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14807", "Giriş Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 127;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreDefinitionList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 126;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M14220", "Fatura Tutarı");
        this.ttlabel2.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 125;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = "Geldiği Yer";
        this.labelAccountancy.Name = "labelAccountancy";
        this.labelAccountancy.TabIndex = 122;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ReadOnly = true;
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 121;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 120;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentDetailTabpage.Name = "ChattelDocumentDetailTabpage";

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.ChattelDocumentDetailsWithAccountancy = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithAccountancy.Required = true;
        this.ChattelDocumentDetailsWithAccountancy.Name = "ChattelDocumentDetailsWithAccountancy";
        this.ChattelDocumentDetailsWithAccountancy.TabIndex = 0;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ReadOnly = true;
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = "MaterialListDefinition";
        this.MaterialStockActionDetailIn.DataMember = "Material";
        this.MaterialStockActionDetailIn.AutoCompleteDialogHeight = "60%";
        this.MaterialStockActionDetailIn.AutoCompleteDialogWidth = "50%";
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetailIn.Name = "MaterialStockActionDetailIn";
        this.MaterialStockActionDetailIn.Width = 300;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.SentAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DataMember = "SentAmount";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Format = "#,###.####";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 4;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M14895", "Gönderilen Miktar");
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Name = "SentAmountChattelDocumentInputDetailWithAccountancy";
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Width = 100;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = "Amount";
        this.AmountStockActionDetailIn.Format = "#,###.####";
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 5;
        this.AmountStockActionDetailIn.HeaderText = i18n("M10707", "Alınan Miktar");
        this.AmountStockActionDetailIn.Name = "AmountStockActionDetailIn";
        this.AmountStockActionDetailIn.Width = 75;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.NotDiscountedUnitPrice = new TTVisual.TTTextBoxColumn();
        this.NotDiscountedUnitPrice.DataMember = "NotDiscountedUnitPrice";
        this.NotDiscountedUnitPrice.DisplayIndex = 6;
        this.NotDiscountedUnitPrice.HeaderText = i18n("M16509", "İndirimsiz Birim Fiyatı");
        this.NotDiscountedUnitPrice.Name = "NotDiscountedUnitPrice";
        this.NotDiscountedUnitPrice.Width = 100;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = "UnitPrice";
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 7;
        this.UnitPriceStockActionDetailIn.HeaderText = i18n("M11868", "Birim Maliyet Bedeli");
        this.UnitPriceStockActionDetailIn.Name = "UnitPriceStockActionDetailIn";
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 75;

        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = "DiscountRate";
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = i18n("M16491", "İndirim Oranı");
        this.MKYS_IndirimOranı.Name = "MKYS_IndirimOranı";
        this.MKYS_IndirimOranı.Width = 100;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = "DiscountAmount";
        this.MKYS_IndirimTutari.DisplayIndex = 9;
        this.MKYS_IndirimTutari.HeaderText = i18n("M16501", "İndirim Tutarı");
        this.MKYS_IndirimTutari.Name = "MKYS_IndirimTutari";
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Visible = false;
        this.MKYS_IndirimTutari.Width = 100;

        this.TotalPriceNotDiscount = new TTVisual.TTTextBoxColumn();
        this.TotalPriceNotDiscount.DataMember = "TotalPriceNotDiscount";
        this.TotalPriceNotDiscount.DisplayIndex = 10;
        this.TotalPriceNotDiscount.HeaderText = i18n("M16510", "İndirimsiz Toplam Fiyat");
        this.TotalPriceNotDiscount.Name = "TotalPriceNotDiscount";
        this.TotalPriceNotDiscount.ReadOnly = true;
        this.TotalPriceNotDiscount.Width = 100;

        this.TotalDiscountAmount = new TTVisual.TTTextBoxColumn();
        this.TotalDiscountAmount.DataMember = "TotalDiscountAmount";
        this.TotalDiscountAmount.DisplayIndex = 11;
        this.TotalDiscountAmount.HeaderText = i18n("M23503", "Toplam İndirim Tutarı");
        this.TotalDiscountAmount.Name = "TotalDiscountAmount";
        this.TotalDiscountAmount.ReadOnly = true;
        this.TotalDiscountAmount.Width = 100;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "Price";
        this.TotalPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.TotalPrice.DisplayIndex = 12;
        this.TotalPrice.HeaderText = i18n("M23613", "Tutarı");
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 120;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = "LotNo";
        this.LotNo.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.LotNo.DisplayIndex = 13;
        this.LotNo.HeaderText = "Lot No.";
        this.LotNo.Name = "LotNo";
        this.LotNo.Width = 100;

        this.ExpirationDateStockActionDetailIn = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateStockActionDetailIn.Format = DateTimePickerFormat.Custom;
        this.ExpirationDateStockActionDetailIn.CustomFormat = "MM/yyyy";
        this.ExpirationDateStockActionDetailIn.DataMember = "ExpirationDate";
        this.ExpirationDateStockActionDetailIn.DisplayIndex = 14;
        this.ExpirationDateStockActionDetailIn.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDateStockActionDetailIn.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDateStockActionDetailIn.Width = 120;

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeStockActionDetailIn.DataMember = "StockLevelType";
        this.StockLevelTypeStockActionDetailIn.Required = true;
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 15;
        this.StockLevelTypeStockActionDetailIn.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeStockActionDetailIn.Name = "StockLevelTypeStockActionDetailIn";
        this.StockLevelTypeStockActionDetailIn.Width = 100;

        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DataMember = "ConflictSubject";
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DisplayIndex = 16;
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M23821", "Uyuşmazlık Konusu");
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Name = "ConflictSubjectChattelDocumentInputDetailWithAccountancy";
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Width = 100;

        this.StatusStockActionDetailIn = new TTVisual.TTEnumComboBoxColumn();
        this.StatusStockActionDetailIn.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusStockActionDetailIn.DataMember = "Status";
        this.StatusStockActionDetailIn.DisplayIndex = 17;
        this.StatusStockActionDetailIn.HeaderText = "Durum";
        this.StatusStockActionDetailIn.Name = "StatusStockActionDetailIn";
        this.StatusStockActionDetailIn.Visible = false;
        this.StatusStockActionDetailIn.Width = 80;

        this.MKYS_EdinimYili = new TTVisual.TTTextBoxColumn();
        this.MKYS_EdinimYili.DataMember = "RetrievalYear";
        this.MKYS_EdinimYili.DisplayIndex = 18;
        this.MKYS_EdinimYili.HeaderText = i18n("M13475", "Edinim Yılı");
        this.MKYS_EdinimYili.Name = "MKYS_EdinimYili";
        this.MKYS_EdinimYili.Width = 100;

        this.MKYS_UretimTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MKYS_UretimTarihi.DataMember = "ProductionDate";
        this.MKYS_UretimTarihi.DisplayIndex = 19;
        this.MKYS_UretimTarihi.HeaderText = i18n("M23966", "Üretim Tarihi");
        this.MKYS_UretimTarihi.Name = "MKYS_UretimTarihi";
        this.MKYS_UretimTarihi.Width = 100;

        this.ConflictAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DataMember = "ConflictAmount";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Format = "#,###.####";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 20;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M23822", "Uyuşmazlık Miktarı");
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Name = "ConflictAmountChattelDocumentInputDetailWithAccountancy";
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.ReadOnly = true;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Visible = false;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Width = 100;

        this.txtSalesTotal = new TTVisual.TTTextBox();
        this.txtSalesTotal.BackColor = "#F0F0F0";
        this.txtSalesTotal.ReadOnly = true;
        this.txtSalesTotal.Name = "txtSalesTotal";
        this.txtSalesTotal.TabIndex = 124;

        this.txtTotalNotDiscount = new TTVisual.TTTextBox();
        this.txtTotalNotDiscount.BackColor = "#F0F0F0";
        this.txtTotalNotDiscount.ReadOnly = true;
        this.txtTotalNotDiscount.Name = "txtTotalNotDiscount";
        this.txtTotalNotDiscount.TabIndex = 124;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M16501", "İndirim Tutarı");
        this.ttlabel3.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 125;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M23526", "Toplam Tutar");
        this.ttlabel4.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 125;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = i18n("M22969", "Tedarik Türü");
        this.labelMKYS_ETedarikTuru.Name = "labelMKYS_ETedarikTuru";
        this.labelMKYS_ETedarikTuru.TabIndex = 14;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = "MKYS_ETedarikTurEnum";
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = "#FFE3C6";
        this.MKYS_ETedarikTuru.Name = "MKYS_ETedarikTuru";
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.MKYS_EAlimYontemi = new TTVisual.TTEnumComboBox();
        this.MKYS_EAlimYontemi.DataTypeName = "MKYS_EAlimYontemiEnum";
        this.MKYS_EAlimYontemi.Required = true;
        this.MKYS_EAlimYontemi.BackColor = "#FFE3C6";
        this.MKYS_EAlimYontemi.Name = "MKYS_EAlimYontemi";
        this.MKYS_EAlimYontemi.TabIndex = 19;

        this.labelMKYS_EAlimYontemi = new TTVisual.TTLabel();
        this.labelMKYS_EAlimYontemi.Text = i18n("M10699", "Alım Yöntemi");
        this.labelMKYS_EAlimYontemi.Name = "labelMKYS_EAlimYontemi";
        this.labelMKYS_EAlimYontemi.TabIndex = 18;

        this.GetWaybill = new TTButtonTextBox();
        this.GetWaybill.Text = i18n("M16570", "İrsaliye Getir");
        this.GetWaybill.Name = "GetWaybill";
        this.GetWaybill.TabIndex = 147;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = true;
        this.ValueAddedTax.Width = 100;

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ReadOnly = false;
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 9;

        this.ChattelDocumentDetailsWithAccountancyColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.SentAmountChattelDocumentInputDetailWithAccountancy, this.AmountStockActionDetailIn, this.NotDiscountedUnitPrice, this.UnitPriceStockActionDetailIn, this.ValueAddedTax, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari, this.TotalPriceNotDiscount, this.TotalDiscountAmount, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.ConflictSubjectChattelDocumentInputDetailWithAccountancy, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.ConflictAmountChattelDocumentInputDetailWithAccountancy];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentDetailTabpage];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithAccountancy];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.txtTotalPrice, this.Waybill, this.TTTeslimEdenButon, this.labelBudgetTypeDefinition, this.TTTeslimAlanButon, this.BudgetTypeDefinition, this.labelWaybillDate, this.WaybillDate, this.labelMKYS_TeslimEden, this.labelStore, this.labelWaybill, this.labelinputWithAccountancyType, this.inputWithAccountancyType, this.MKYS_TeslimEden, this.Store, this.MKYS_TeslimAlan, this.ttlabel2, this.Description, this.labelAccountancy, this.StockActionID, this.Accountancy, this.labelMKYS_TeslimAlan, this.ChattelDocumentTabcontrol, this.labelTransactionDate, this.ChattelDocumentDetailTabpage, this.TransactionDate, this.ChattelDocumentDetailsWithAccountancy, this.labelStockActionID, this.Detail, this.DescriptionAndSignTabControl, this.MaterialStockActionDetailIn, this.SignTabpage, this.Barcode, this.StockActionSignDetails, this.DistributionType, this.SignUserType, this.SentAmountChattelDocumentInputDetailWithAccountancy, this.SignUser, this.AmountStockActionDetailIn, this.IsDeputy, this.NotDiscountedUnitPrice, this.ttlabel1, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari, this.TotalPriceNotDiscount, this.TotalDiscountAmount, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.ConflictSubjectChattelDocumentInputDetailWithAccountancy, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.ConflictAmountChattelDocumentInputDetailWithAccountancy, this.txtSalesTotal, this.txtTotalNotDiscount, this.ttlabel3, this.ttlabel4, this.labelMKYS_ETedarikTuru, this.MKYS_ETedarikTuru, this.MKYS_EMalzemeGrup, this.labelMKYS_EMalzemeGrup, this.MKYS_EAlimYontemi, this.labelMKYS_EAlimYontemi, this.GetWaybill];

    }


}
