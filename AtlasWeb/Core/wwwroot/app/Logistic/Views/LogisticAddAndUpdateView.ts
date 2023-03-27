//$F5D229BA
import { Component, ViewChild } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import {
    LogisticAddAndUpdateViewModel, ReturnAccountancy, ReturnSupplier,
    StockCardType, ReturnSupplierItem,
    ReturnStockCard, StockCardItem, ReturnAccountancyItem,
    CreateMkysKurumlari_InputDVO, CreateMkysKurumlari_OutputDVO,
    UpdateMkysKurumlari_InputDVO, UpdateMkysKurumlari_OutputDVO,
    CreateMkysFirma_InputDVO, CreateMkysFirma_OutputDVO,
    UpdateMkysFirma_InputDVO, UpdateMkysFirma_OutputDVO,
    CreateMkysStockCard_InputDVO, CreateMkysStockCard_OutputDVO,
    UpdateMkysStockCard_InputDVO, UpdateMkysStockCard_OutputDVO,
    ReturnFirstStockIn_Input, StockFirstInDetailGridItem, StockFirstInGridItem,
    GetDetailsOfFirstStockIn_Input, UpdateUnitPriceForSelectedItems_Input, UTS_SynchronizeMaterials_Input, UTSMaterialGridDataModel, UTSUnusedGridDataModel, UTSUnlist_Input, ENabizMaterialInput, ENabizMaterialGrid, InputPriceDTO, UpdateMaterialPriceListDTO, StockActionInDetailDTO, GetStockActionInDetails_Output, GetStockActionInDetails_Input, UpdateStockActionInDetails_Input, GetCovid19StockAction_Input, GetCovid19StockAction_Output, StockActionDetailCovid19, UpdateStockActionCovid19_Input
} from '../Models/LogisticAddAndUpdateViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { UserHelper } from 'app/Helper/UserHelper';
import { IModalService } from 'Fw/Services/IModalService';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Store, MaterialTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { DatePipe } from '@angular/common';
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { DxDataGridComponent } from 'devextreme-angular';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';

@Component({
    selector: 'hvl-logistic-addandupdate-view',
    inputs: ['Model'],
    templateUrl: './LogisticAddAndUpdateView.html',
    styles: [` :host /deep/ .dx-context-menu .dx-menu-items-container { height: 100px; overflow-y: scroll;}`],
    providers: [MessageService]
})

export class LogisticAddAndUpdateView extends BaseComponent<LogisticAddAndUpdateViewModel> {
    public operationTypes: string[];
    public stockCardType: string[];
    public mkysKurumlariGuncelle: boolean = true;
    public mkysFirmalariGuncelle: boolean = false;
    public mkysStokKartlariGuncelle: boolean = false;
    public vademecumIlacIdEslestir: boolean = false;
    public geriOdemeTipiGuncelle: boolean = false;
    public ilkGirisFiyatGuncelle: boolean = false;
    public UTSbildirimigerektirenmalzemeler: boolean = false;
    public UXXXXXXullanimBildirimi: boolean = false;
    public ENabizHataliIslemDuzelt: boolean = false;
    public ConsumableMaterialPriceUpdate: boolean = false;
    public DrugDefinitionPriceUpdate: boolean = false;
    public UpdateStockActionInDetail: boolean = false;
    public Covid19ActionUpdate: boolean = false;
    selectedDetailItems: StockFirstInDetailGridItem[];
    selectedUTSItems: UTSUnusedGridDataModel[];
    _StockCardTypeString: StockCardType = new StockCardType();

    public selectedDate: Date = new Date();
    public startDateUTS: Date = null;
    public endDateUTS: Date = null;
    public UTSUsedStartDate: Date = new Date();
    public UTSUsedEndDate: Date = new Date();

    public ENabizStartDate: Date = new Date();
    public ENabizEndDate: Date = new Date();

    public selectedStore: Array<Store>;

    public StoreObjID: Guid;

    getmkysKurumlariGuncelleButtonText = i18n("M18110", " Kurumlar Listesini Getir ");
    getmkysFirmalariGuncelleButtonText = i18n("M14330", " Firmalar Listesini Getir ");
    getmkysStokKartiGuncelleButtonText = i18n("M22352", " Stok Kartları Getir ");

    CreateButtonText = i18n("M13543", "Ekle");
    UpdateButtonText = i18n("M15005", "Güncelle");
    UpdateButtonVisible = true;
    CreateButtonVisible = true;
    loadingVisible = false;
    public loadingVisibleEnabiz = false;

    CreateFirmButtonText = i18n("M13543", "Ekle");
    UpdateFirmButtonText = i18n("M15005", "Güncelle");
    CreateSupplierButtonVisible = true;
    UpdateSupplierButtonVisible = true;
    loadingVisibleSupplier = false;

    CreateStockCardButtonText = i18n("M13543", "Ekle");
    UpdateStockCardButtonText = i18n("M15005", "Güncelle");
    CreateStockCardButtonVisible = true;
    UpdateStockCardButtonVisible = true;
    loadingVisibleStockCard = false;

    public returnAccountancy: ReturnAccountancy;
    public NewAccountancyList: Array<ReturnAccountancyItem>;
    public UpdateAccountancyList: Array<ReturnAccountancyItem>;
    public selectedNewAccountancyTempItems: Array<ReturnAccountancyItem>;
    public selectedUpdateAccountancyTempItems: Array<ReturnAccountancyItem>;

    public returnSupplier: ReturnSupplier;
    public NewSupplierList: Array<ReturnSupplierItem>;
    public UpdateSupplierList: Array<ReturnSupplierItem>;
    public selectedNewSupplierTempItems: Array<ReturnSupplierItem>;
    public selectedUpdateSupplierTempItems: Array<ReturnSupplierItem>;

    public returnStockCard: ReturnStockCard;
    public NewStockCardList: Array<StockCardItem>;
    public UpdateStockCardList: Array<StockCardItem>;
    public selectedNewStockCardTempItems: Array<StockCardItem>;
    public selectedUpdateStockCardTempItems: Array<StockCardItem>;

    public StockFirstInDetailGridItemList: Array<StockFirstInDetailGridItem>;
    public StockFirstInGridItemList: Array<StockFirstInGridItem>;
    public UTSMaterials: Array<UTSMaterialGridDataModel> = new Array<UTSMaterialGridDataModel>();

    public UTSUnUsedList: Array<UTSUnusedGridDataModel> = new Array<UTSUnusedGridDataModel>();

    public UTSSinif1: boolean = false;
    public UTSSinif2: boolean = false;
    public UTSSinif3: boolean = false;

    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz...';

    public ENabizMaterialGridList: Array<ENabizMaterialGrid> = new Array<ENabizMaterialGrid>();


    ConsumableMaterialPriceUpdateDTO: Array<UpdateMaterialPriceListDTO> = new Array<UpdateMaterialPriceListDTO>();
    StartedDateOfConsumableMaterialPrice: Date = new Date();
    selectedConsumableMaterialPriceItems: Array<UpdateMaterialPriceListDTO> = new Array<UpdateMaterialPriceListDTO>();

    DrugDefinitionPriceUpdateDTO: Array<UpdateMaterialPriceListDTO> = new Array<UpdateMaterialPriceListDTO>();
    StartedDateOfDrugDefinitionPrice: Date = new Date();
    selectedDrugDefinitionPriceItems: Array<UpdateMaterialPriceListDTO> = new Array<UpdateMaterialPriceListDTO>();

    public stockActionID: string;
    public stockActionInDetailDataSource: Array<StockActionInDetailDTO> = new Array<StockActionInDetailDTO>();
    public selectedStockActionInDetails: Array<StockActionInDetailDTO> = new Array<StockActionInDetailDTO>();
    public txtNotKDV: string;
    public txtWithKDV: string
    public txtDiscount: string;
    public txtTotalPrice: string;



    public covid19StockActionID: string;
    public covid19TifID: string;
    public covid19StoreID: Guid;
    public Supplier: TTVisual.ITTObjectListBox;
    public Accountancy: TTVisual.ITTObjectListBox;

    @ViewChild('stockActionInDetailGrid') stockActionInDetailGrid: DxDataGridComponent;

    constructor(container: ServiceContainer, private http: NeHttpService, protected messageService: MessageService, private modalService: IModalService, protected activeUserService: IActiveUserService) {
        super(container);

        this.UTSUsedStartDate = this.UTSUsedEndDate.AddMonths(-2);
        this.ENabizStartDate = this.ENabizEndDate.AddMonths(-2);
        this.operationTypes = [
            'Kurum Güncelleme',
            'Firma Güncelleme',
            'Stok Kartlarını Güncelleme',
            'İlk Giriş Fiyatını Güncelleme',
            'ÜTS Bildirimi Gerektiren Malzeme Güncelleme',
            'ÜTS Toplu Kullanım Bildirimi',
            'E-Nabız Hatalı İşlem Düzeltme',
            'Sarf Malzeme Fiyat Güncelleme',
            'İlaç Fiyat Güncelleme',
            'Giriş Detaylarını Güncelleme',
            'Covid19 Giriş Güncelleme'
        ];

        this.stockCardType = [
            'TÜKETİM & TIBBİ SARF',
            'İLAÇLAR',
            'LABORATUVAR'
        ];

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ReadOnly = false;
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 9;

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ReadOnly = true; //mksy den değişmediği için kapalı.!!.!
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 121;


    }

    private collapseAttr = 0;
    btnCollapse() {

        if (this.collapseAttr == 1) {
            this.collapseAttr = 0;
        } else
            this.collapseAttr = 1;
    }
    public collapseIconProperties(): string {

        if (this.collapseAttr == 1) {
            return "fa fa-2x fa-angle-up";
        }
        return "fa fa-2x fa-angle-left";
    }
    public collapseSelectedDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "hidden";
        }
        return "col-md-3";
    }
    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }
    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 episodeColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-9";

    }
    async clientPreScript() {
        this._StockCardTypeString.StockCardTypeString = "TK";
        this.selectedStore = await UserHelper.UseMainStoreResources;
    }
    async clientPostScript() {

    }

    seletedValueClear() {
        this.mkysKurumlariGuncelle = false;
        this.mkysFirmalariGuncelle = false;
        this.mkysStokKartlariGuncelle = false;
        this.vademecumIlacIdEslestir = false;
        this.geriOdemeTipiGuncelle = false;
        this.ilkGirisFiyatGuncelle = false;
        this.UTSbildirimigerektirenmalzemeler = false;
        this.UXXXXXXullanimBildirimi = false;
        this.ENabizHataliIslemDuzelt = false;
        this.ConsumableMaterialPriceUpdate = false;
        this.DrugDefinitionPriceUpdate = false;
        this.UpdateStockActionInDetail = false;
        this.Covid19ActionUpdate = false;
    }

    async onValueChanged($event) {
        this.seletedValueClear();
        if ('Kurum Güncelleme' === $event.value) {
            this.mkysKurumlariGuncelle = true;
        }
        else if ('Firma Güncelleme' === $event.value) {
            this.mkysFirmalariGuncelle = true;
        }
        else if ('Stok Kartlarını Güncelleme' === $event.value) {
            this.mkysStokKartlariGuncelle = true;
        }
        else if ('VADEMECUM ILAC ID ESLESTIR' === $event.value) {
            this.vademecumIlacIdEslestir = true;
        }
        else if ('GERI ODEME TIPI GUNCELLE' === $event.value) {
            this.geriOdemeTipiGuncelle = true;
        }
        else if ('İlk Giriş Fiyatını Güncelleme' === $event.value) {
            this.ilkGirisFiyatGuncelle = true;
        }
        else if ('ÜTS Bildirimi Gerektiren Malzeme Güncelleme' === $event.value) {
            this.UTSbildirimigerektirenmalzemeler = true;
        }
        else if ('ÜTS Toplu Kullanım Bildirimi' === $event.value) {
            this.UXXXXXXullanimBildirimi = true;
        }
        else if ('E-Nabız Hatalı İşlem Düzeltme' === $event.value) {
            this.ENabizHataliIslemDuzelt = true;
        }
        else if ('Sarf Malzeme Fiyat Güncelleme' == $event.value) {
            this.ConsumableMaterialPriceUpdate = true;
        }
        else if ('İlaç Fiyat Güncelleme' == $event.value) {
            this.DrugDefinitionPriceUpdate = true;
        }
        else if ('Giriş Detaylarını Güncelleme' == $event.value) {
            this.UpdateStockActionInDetail = true;
        }
        else if ('Covid19 Giriş Güncelleme' == $event.value) {
            this.Covid19ActionUpdate = true;
        }
        else { }
    }

    async onStockCardTypeValueChanged($event) {
        if ('TÜKETİM & TIBBİ SARF' === $event.value) {
            this._StockCardTypeString.StockCardTypeString = "TK";
        } else if ('İLAÇLAR' === $event.value) {
            this._StockCardTypeString.StockCardTypeString = "IL";
        } else if ('LABORATUVAR' === $event.value) {
            this._StockCardTypeString.StockCardTypeString = "TS";
        } else { }
    }

    async getmkysKurumlariGuncelleButtonClick() {
        this.returnAccountancy = new ReturnAccountancy;
        this.NewAccountancyList = new Array<ReturnAccountancyItem>();
        this.UpdateAccountancyList = new Array<ReturnAccountancyItem>();
        this.selectedNewAccountancyTempItems = new Array<ReturnAccountancyItem>();
        this.selectedUpdateAccountancyTempItems = new Array<ReturnAccountancyItem>();

        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetMkysKurumlariGuncelle';
        this.http.post(fullApiUrl, null)
            .then((res) => {
                let result = <LogisticAddAndUpdateViewModel>res;
                that.Model = result;
                if (that.Model) {
                    that.returnAccountancy = that.Model.returnAccountancy;
                    that.NewAccountancyList = that.returnAccountancy.NewAccountancyList;
                    that.UpdateAccountancyList = that.returnAccountancy.UpdateAccountancyList;
                    this.loadingVisible = false;
                    this.CreateButtonVisible = false;
                    this.UpdateButtonVisible = false;
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
                this.CreateButtonVisible = true;
                this.UpdateButtonVisible = true;
            });
    }

    async NewAccountancyButtonClick() {
        if (this.selectedNewAccountancyTempItems != null) {
            let that = this;
            let inputDvo = new CreateMkysKurumlari_InputDVO();
            inputDvo.CreateAccountancyList = this.selectedNewAccountancyTempItems;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/CreateMkysKurumlari';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <CreateMkysKurumlari_OutputDVO>res;
                    if (result) {
                        TTVisual.InfoBox.Alert(result.returnMessage);
                        this.getmkysKurumlariGuncelleButtonClick();
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
    }

    async UpdateAccountancyButtonClick() {
        if (this.selectedUpdateAccountancyTempItems != null) {
            let that = this;
            let inputDvo = new UpdateMkysKurumlari_InputDVO();
            inputDvo.UpdateAccountancyList = this.selectedUpdateAccountancyTempItems;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/UpdateMkysKurumlari';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <UpdateMkysKurumlari_OutputDVO>res;
                    if (result) {
                        TTVisual.InfoBox.Alert(result.returnMessage);
                        this.getmkysKurumlariGuncelleButtonClick();
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
    }

    async getmkysFirmalariGuncelleButtonButtonClick() {
        this.returnSupplier = new ReturnSupplier();
        this.NewSupplierList = new Array<ReturnSupplierItem>();
        this.UpdateSupplierList = new Array<ReturnSupplierItem>();
        this.selectedNewSupplierTempItems = new Array<ReturnSupplierItem>();
        this.selectedUpdateSupplierTempItems = new Array<ReturnSupplierItem>();

        this.loadingVisibleSupplier = true;
        let that = this;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetMkysFirmalariGuncelle';
        this.http.post(fullApiUrl, null)
            .then((res) => {
                let result = <LogisticAddAndUpdateViewModel>res;
                that.Model = result;
                if (that.Model) {
                    that.returnSupplier = that.Model.returnSupplier;
                    that.NewSupplierList = that.returnSupplier.NewSupplierList;
                    that.UpdateSupplierList = that.returnSupplier.UpdateSupplierList;
                    this.loadingVisibleSupplier = false;
                    this.CreateSupplierButtonVisible = false;
                    this.UpdateSupplierButtonVisible = false;
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisibleSupplier = false;
                this.CreateSupplierButtonVisible = true;
                this.UpdateSupplierButtonVisible = true;
            });
    }

    async NewSupplierButtonClick() {
        if (this.selectedNewSupplierTempItems != null) {
            let that = this;
            let inputDvo = new CreateMkysFirma_InputDVO();
            inputDvo.CreateSupplerList = this.selectedNewSupplierTempItems;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/CreateMkysFirma';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <CreateMkysFirma_OutputDVO>res;
                    if (result) {
                        TTVisual.InfoBox.Alert(result.returnMessage);
                        this.getmkysFirmalariGuncelleButtonButtonClick();
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
    }

    async UpdateSupplierButtonClick() {
        if (this.selectedUpdateSupplierTempItems != null) {
            let that = this;
            let inputDvo = new UpdateMkysFirma_InputDVO();
            inputDvo.UpdateSupplierList = this.selectedUpdateSupplierTempItems;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/UpdateMkysFirma';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <UpdateMkysFirma_OutputDVO>res;
                    if (result) {
                        TTVisual.InfoBox.Alert(result.returnMessage);
                        this.getmkysFirmalariGuncelleButtonButtonClick();
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
    }

    public GridColumns = [
        {
            'caption': "Mkys Kodu",
            dataField: 'StockCardCode',
            allowSorting: true,
            width: 150
        },
        {
            'caption': "Taşınır Malzeme Adı",
            dataField: 'StockCardName',
            allowSorting: true,
            width: 500
        },
        {
            "caption": "Malzeme Kayıt ID",
            dataField: 'MKYSKayitID',
            allowSorting: true,
            width: 150
        },
        {
            "caption": "Ölçü Birimi",
            dataField: 'StockCardDistribution',
            allowSorting: true,
            width: 160
        },
        {
            "caption": "Açıklama",
            dataField: 'Desciption',
            allowSorting: true,
            width: 180
        },
        {
            "caption": "Aktif/Pasif",
            dataField: 'isActive',
            cellTemplate: "LabelCellTemplate",
            falseText: "Pasif",
            trueText: "Aktif",
            width: 50
        },
    ];

    async getmkysStokKartiGuncelleButtonClick() {

        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            let params = <any>(<ModalActionResult>result).Param;
            let inputDvo = new StockCardType();
            inputDvo.StockCardTypeString = this._StockCardTypeString.StockCardTypeString;
            inputDvo.StockCardDateTime = this.selectedDate;
            inputDvo.MKYSPassword = params.password;
            let input = {
                'StockCardTypeString': inputDvo.StockCardTypeString, 'SelectedDateTime': inputDvo.StockCardDateTime, 'MKYSPassword': inputDvo.MKYSPassword
            };
            this.returnStockCard = new ReturnStockCard();
            this.NewStockCardList = new Array<StockCardItem>();
            this.UpdateStockCardList = new Array<StockCardItem>();
            this.selectedNewStockCardTempItems = new Array<StockCardItem>();
            this.selectedUpdateStockCardTempItems = new Array<StockCardItem>();
            this.loadingVisibleStockCard = true;
            let that = this;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetMkysStockCardGuncelle';
            this.http.post(fullApiUrl, input)
                .then((res) => {
                    let result = <LogisticAddAndUpdateViewModel>res;
                    that.Model = result;
                    if (that.Model) {
                        that.returnStockCard = that.Model.returnStockCard;
                        that.NewStockCardList = that.returnStockCard.NewStockCardList;
                        that.UpdateStockCardList = that.returnStockCard.UpdateStockCardList;
                        this.loadingVisibleStockCard = false;
                        this.CreateStockCardButtonVisible = false;
                        this.UpdateStockCardButtonVisible = false;
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.loadingVisibleStockCard = false;
                    this.CreateStockCardButtonVisible = true;
                    this.UpdateStockCardButtonVisible = true;
                });
        } else {
            ServiceLocator.MessageService.showInfo("MKYS İşleminden Vazgeçildi.")
        }
    }

    async NewStockCardButtonClick() {
        this.loadingVisibleStockCard = true;
        if (this.selectedNewStockCardTempItems != null) {
            if (this.selectedNewStockCardTempItems.length == 0) {
                ServiceLocator.MessageService.showError("Güncellenecek Kartı Seçmediniz.");
                this.loadingVisibleStockCard = false;
                return;
            }


            let that = this;
            let inputDvo = new CreateMkysStockCard_InputDVO();
            inputDvo.CreateStockCardList = this.selectedNewStockCardTempItems;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/CreateMkysStockCard';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <CreateMkysStockCard_OutputDVO>res;
                    if (result) {
                        TTVisual.InfoBox.Alert(result.returnMessage);
                        for (let okItem of this.selectedNewStockCardTempItems) {
                            that.NewStockCardList = that.NewStockCardList.filter(x => x.MKYSKayitID == okItem.MKYSKayitID);
                        }
                    }
                    this.loadingVisibleStockCard = false;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.loadingVisibleStockCard = false;
                });
        } else {
            this.loadingVisibleStockCard = false;

        }
    }

    async UpdateStockCardButtonClick() {
        this.loadingVisibleStockCard = true;
        if (this.selectedUpdateStockCardTempItems != null) {

            if (this.selectedUpdateStockCardTempItems.length == 0) {
                ServiceLocator.MessageService.showError("Güncellenecek Kartı Seçmediniz.");
                this.loadingVisibleStockCard = false;
                return;
            }

            let that = this;
            let inputDvo = new UpdateMkysStockCard_InputDVO();
            inputDvo.UpdateStockCardList = this.selectedUpdateStockCardTempItems;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/UpdateMkysStockCard';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <UpdateMkysStockCard_OutputDVO>res;
                    if (result) {
                        TTVisual.InfoBox.Alert(result.returnMessage);
                        for (let okItem of this.selectedUpdateStockCardTempItems) {
                            that.UpdateStockCardList = that.UpdateStockCardList.filter(x => x.MKYSKayitID == okItem.MKYSKayitID);
                        }
                    }
                    this.loadingVisibleStockCard = false;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.loadingVisibleStockCard = false;

                });
        } else {
            this.loadingVisibleStockCard = false;
        }
    }

    public StockActionListColumns = [
        {
            caption: ' ',
            dataField: 'stockActionObjID',
            cellTemplate: 'buttonCellTemplate'
        },
        {
            'caption': i18n("M16866", "İşlem No"),
            dataField: 'stockActionNo',
            allowSorting: true
        }

    ];

    public StockActionDetailListColumns = [
        {
            'caption': i18n("M18550", "Malzeme Adı"),
            dataField: 'MaterialName',
            allowSorting: true,
            allowEditing: false
        },
        {
            'caption': i18n("M19030", "Taşınır Kodu"),
            dataField: 'NatoStockNo',
            allowSorting: true,
            allowEditing: false
        },
        {
            'caption': i18n("M19030", "Barkodu"),
            dataField: 'Barcode',
            allowSorting: true,
            allowEditing: false
        },
        {
            'caption': i18n("M22071", "son. Kul. Tarih"),
            dataField: 'ExpirationDate',
            allowSorting: true,
            allowEditing: false
        },
        {
            'caption': i18n("M19030", "Hareket ID"),
            dataField: 'MKYS_StokHareketID',
            allowSorting: true,
            allowEditing: false
        },
        {
            'caption': i18n("M19030", "Miktar"),
            dataField: 'Amount',
            allowSorting: true,
            allowEditing: false
        },
        {
            'caption': i18n("M13860", "Eski fiyatı"),
            dataField: 'OldPrice',
            allowSorting: true,
            allowEditing: false
        },
        {
            'caption': i18n("M24553", "Yeni fiyatı"),
            dataField: 'NewPrice',
            allowSorting: true
        }

    ];

    public UTSUnUsedListColumns = [
        {
            'caption': i18n("M18550", "StockTransactionID"),
            dataField: 'StockTransactionID',
            visible: false,
            width: 100,

        },
        {
            'caption': i18n("M18550", "Protokol No"),
            dataField: 'ProtocolNo',
            allowSorting: true,
            allowEditing: false,
            width: 100,
        },
        {
            'caption': i18n("M19030", "Malzeme"),
            dataField: 'MaterialName',
            allowSorting: true,
            allowEditing: false,
            width: 600,
        },
        {
            'caption': i18n("M19030", "Barcode"),
            dataField: 'Barcode',
            allowSorting: true,
            allowEditing: false,
            width: 200,
        },
        {
            'caption': i18n("M19030", "Lot No"),
            dataField: 'LotNo',
            allowSorting: true,
            allowEditing: false,
            width: 100,
        },
        {
            'caption': i18n("M22071", "MKYS TİF No"),
            dataField: 'MKYSTifNo',
            allowSorting: true,
            allowEditing: false,
            width: 100,
        },
        {
            'caption': i18n("M19030", "Miktar"),
            dataField: 'Amount',
            allowSorting: true,
            allowEditing: false,
            width: 100,
        },
        {
            'caption': i18n("M19030", "UTS Gön. Miktar"),
            dataField: 'UTSAmount',
            allowSorting: true,
            allowEditing: false,
            width: 150,
        },
        {
            'caption': i18n("M24553", "UTS Alma Bildirim ID"),
            dataField: 'UTSAlmaBildirimID',
            allowSorting: true,
            allowEditing: false,
            width: 300,
        },
        {
            'caption': "Hata Mesajı",
            dataField: 'UTSErrorMessege',
            allowSorting: true,
            allowEditing: false,
            width: 150,
        },
        {
            'caption': i18n("M13860", "Giriş İşlem No"),
            dataField: 'StockActionID',
            allowSorting: true,
            allowEditing: false,
            width: 100,
        },
        {
            caption: ' ',
            dataField: 'StockActionObjID',
            cellTemplate: 'buttonCellTemplate',
            width: 50,
        },
    ];

    public ENabizMaterialGridListColumns = [{
        'caption': i18n("M18550", "Protokol No"),
        dataField: 'ProtocolNO',
        allowSorting: true,
        allowEditing: false,
        width: 100,
    },
    {
        'caption': i18n("M19030", "Malzeme"),
        dataField: 'MaterialName',
        allowSorting: true,
        allowEditing: false,
        width: 400,
    },
    {
        'caption': i18n("M19030", "Barcode"),
        dataField: 'MaterialBarcode',
        allowSorting: true,
        allowEditing: false,
        width: 100,
    },
    {
        'caption': i18n("M19030", "Uygulama Zamanı"),
        dataField: 'ApplicationDate',
        allowSorting: true,
        allowEditing: false,
        width: 100,
    },
    {
        'caption': i18n("M22071", "İstek Zamanı"),
        dataField: 'RequestDate',
        allowSorting: true,
        allowEditing: false,
        width: 100,
    },
    {
        'caption': i18n("M19030", "Gönderme Zamanı"),
        dataField: 'SendDate',
        allowSorting: true,
        allowEditing: false,
        width: 100,
    },
    {
        'caption': i18n("M19030", "Sonuç Mesajı"),
        dataField: 'ResponseMessage',
        allowSorting: true,
        allowEditing: false,
        width: 600,
    }];

    async SelectBoxStoreChange(data: any) {
        this.StoreObjID = data.itemData.ObjectID;
    }

    tempValueRow: any;
    async selectAction(value: any): Promise<void> {
        if (value.data.stockActionObjID != null) {
            this.tempValueRow = value;
            let that = this;
            let inputDvo = new GetDetailsOfFirstStockIn_Input();
            inputDvo.stockActionObjID = value.data.stockActionObjID;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetDetailsOfFirstStockIn';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <LogisticAddAndUpdateViewModel>res;
                    that.Model = result;
                    if (that.Model) {
                        that.StockFirstInDetailGridItemList = that.Model.StockFirstInDetailGridItemList;
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
    }

    async btnGetFirstStockIn() {

        this.StockFirstInGridItemList = null;
        this.StockFirstInDetailGridItemList = null;
        this.selectedDetailItems = null;
        if (this.StoreObjID != null) {
            let that = this;
            let inputDvo = new ReturnFirstStockIn_Input();
            inputDvo.mainStoreDefinition = this.StoreObjID.toString();
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetReturnFirstStockIn';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <LogisticAddAndUpdateViewModel>res;
                    that.Model = result;
                    if (that.Model) {
                        that.StockFirstInGridItemList = that.Model.StockFirstInGridItemList;
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }

    }

    async btnUpdateUnitPriceForSelectedItems() {
        if (this.selectedDetailItems != null) {
            if (this.selectedDetailItems.length > 0) {
                let that = this;
                let inputDvo = new UpdateUnitPriceForSelectedItems_Input();
                inputDvo.StockFirstInDetailGridItems = this.selectedDetailItems;
                let fullApiUrl: string = 'api/LogisticAddAndUpdate/UpdateUnitPriceForSelectedItems';


                this.http.post(fullApiUrl, inputDvo)
                    .then((res) => {
                        let result = res;
                        if (result) {
                            TTVisual.InfoBox.Alert(i18n("M11598", "Başarılı"));
                            this.selectAction(this.tempValueRow);
                        }
                        else {
                            TTVisual.InfoBox.Alert(i18n("M11602", "Başarısız"));
                        }
                    })
                    .catch(error => {
                        TTVisual.InfoBox.Alert(error);
                    });
            } else { TTVisual.InfoBox.Alert(i18n("M16880", "İşlem Seçiniz!")); }
        } else { TTVisual.InfoBox.Alert(i18n("M16880", "İşlem Seçiniz!")); }
    }

    public btnIlacAra() {
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/ilacAra';
        this.http.post(fullApiUrl, null)
            .then((res) => {
                let result = res;
                if (result) {
                    TTVisual.InfoBox.Alert(i18n("M11598", "Başarılı"));
                    this.selectAction(this.tempValueRow);
                }
                else {
                    TTVisual.InfoBox.Alert(i18n("M11602", "Başarısız"));
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    onStartDatePickerChanged(event) {
        if (event != null) {
            this.startDateUTS = Convert.ToDateTime(Convert.ToDateTime(event.value).ToShortDateString() + " 00:00:00");
        }
    }

    onEndDatePickerChanged(event) {
        if (event != null) {
            this.endDateUTS = Convert.ToDateTime(Convert.ToDateTime(event.value).ToShortDateString() + " 23:59:59");
        }
    }

    async updateAllUTSMaterials() {
        this.panelOperation(true, 'İşlemler Yapılıyor, lütfen bekleyiniz.');
        let fullApiUrl: string = 'api/UTSIslemleriService/SynchronizeAllUTSMaterial';
        let param = new UTS_SynchronizeMaterials_Input();
        let datePipe = new DatePipe('en-US');
        param.StartDate = this.startDateUTS != null ? datePipe.transform(this.startDateUTS, 'dd/MM/yyyy') : null;
        param.EndnDate = this.endDateUTS != null ? datePipe.transform(this.endDateUTS, 'dd/MM/yyyy') : null;
        param.UTSSinif1 = this.UTSSinif1;
        param.UTSSinif2 = this.UTSSinif2;
        param.UTSSinif3 = this.UTSSinif3;

        this.http.post(fullApiUrl, param)
            .then((res) => {
                TTVisual.InfoBox.Alert(res as string);
                this.panelOperation(false, '');
                this.getUTSMaterials();
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.panelOperation(false, '');
            });
    }

    async addToEnabizListEMaterials() {
        this.loadingVisibleEnabiz = true;
        try {
            let that = this;
            let inputDvo = new ENabizMaterialInput();
            inputDvo.startDate = that.ENabizStartDate;
            inputDvo.endDate = that.ENabizEndDate;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/AddToEnabizListEMaterials';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    TTVisual.InfoBox.Alert(res.toString());
                    this.loadingVisibleEnabiz = false;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.loadingVisibleEnabiz = false;
                });
        }
        catch (ex) {
            TTVisual.InfoBox.Alert(ex);
        }
    }

    async getUTSMaterials() {
        this.panelOperation(true, 'Yükleniyor...');
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/LogisticAddAndUpdate/GetUTSMaterials';
            let result = await this.http.post(apiUrlForPASearchUrl, null);
            that.UTSMaterials = result as Array<UTSMaterialGridDataModel>;
            this.panelOperation(false, '');
        }
        catch (ex) {
            TTVisual.InfoBox.Alert(ex);
            this.panelOperation(false, '');
        }

    }


    panelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = 'Lütfen Bekleyiniz...';
    }

    async getUTSUnUsedList() {
        this.showLoadPanel = true;
        //this.panelOperation(true, 'Yükleniyor...');
        try {
            let that = this;
            let inputDvo = new UTSUnlist_Input();
            inputDvo.UTSUsedEndDate = that.UTSUsedEndDate;
            inputDvo.UTSUsedStartDate = that.UTSUsedStartDate;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetUTSUnUsedList';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    that.UTSUnUsedList = res as Array<UTSUnusedGridDataModel>;
                    this.showLoadPanel = false;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.showLoadPanel = false;
                });
            //this.panelOperation(false, '');
        }
        catch (ex) {
            TTVisual.InfoBox.Alert(ex);
            //this.panelOperation(false, '');
            this.showLoadPanel = false;
        }
    }

    async getSelectActionOpen(value: any): Promise<void> {
        this.showStockAction(value.data.StockActionObjID);
    }

    private showStockAction(data: string): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DashboardActionComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16835", "İşlem Detayı");
            modalInfo.Width = 1600;
            modalInfo.Height = 1200;
            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    selectionChangeUTSUnUsedList(value: any) {
        for (let i = 0; i < value.currentSelectedRowKeys.length; i++) {
            if (value.currentSelectedRowKeys[i].UTSAlmaBildirimID == null || value.currentSelectedRowKeys[i].LotNo == null) {
                value.component.deselectRows(value.currentSelectedRowKeys[i]);
            }
        }
    }

    async updateAllUTSUse() {
        let errorControl: boolean = true;
        let updateList: Array<Guid> = new Array<Guid>();
        if (this.selectedUTSItems != null) {
            if (this.selectedUTSItems.length > 0) {
                let that = this;
                for (let i = 0; i < that.selectedUTSItems.length; i++) {
                    updateList.push(that.selectedUTSItems[i].SubActionMaterailObjID);
                }
            }
            try {
                let apiUrl = '/api/UTSIslemleriService/MakeUTSUsageNotificationAll';
                await this.http.post<any>(apiUrl, updateList).then(response => {
                    let result = response;
                    if (result != null) {
                        for (var item of result) {
                            if (item.Message == "Succeed") {
                                ServiceLocator.MessageService.showSuccess("Bildirim Gerçekleşti.");
                            }
                            else {
                                this.UTSUnUsedList.find(x => x.SubActionMaterailObjID == item.ObjectId).UTSErrorMessege = item.Message;
                                ServiceLocator.MessageService.showError("Hata : " + item.Message);
                                errorControl = false;
                            }
                        }
                        if (errorControl)
                            this.getUTSUnUsedList();
                    }
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
            catch (ex) {
                ServiceLocator.MessageService.showError(ex);
            }
        } else { TTVisual.InfoBox.Alert(i18n("M16880", "İşlem Seçiniz!")); }
    }

    public ENabizGondermeListButton: boolean = false;
    async getENabizErrorList() {
        this.loadingVisibleEnabiz = true;
        try {
            let that = this;
            let inputDvo = new ENabizMaterialInput();
            inputDvo.startDate = that.ENabizStartDate;
            inputDvo.endDate = that.ENabizEndDate;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetErrorENabizMaterialList';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    that.ENabizMaterialGridList = res as Array<ENabizMaterialGrid>;
                    if (that.ENabizMaterialGridList.length > 0)
                        that.ENabizGondermeListButton = true;
                    this.loadingVisibleEnabiz = false;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.loadingVisibleEnabiz = false;
                });
        }
        catch (ex) {
            TTVisual.InfoBox.Alert(ex);
            this.loadingVisibleEnabiz = false;
        }
    }

    UpdateMaterialPriceColumns = [
        {
            caption: "Objectid",
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: "Kodu",
            dataField: 'Code',
            allowSorting: true,
            allowEditing: false,
            width: 100,
        },
        {
            caption: "Malzeme",
            dataField: 'MaterialName',
            allowSorting: true,
            allowEditing: false,
            width: 900,
        },
        {
            caption: "Fiyat",
            dataField: 'Price',
            allowSorting: true,
            allowEditing: false,
            width: 100,
        },
        {
            caption: "İndirim Oranı",
            dataField: 'DiscountPercent',
            allowSorting: true,
            allowEditing: false,
            width: 100,
        }];

    getConsumableMaterialPriceUpdate() {
        let that = this;
        that.showLoadPanel = true;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetMaterialPriceUpdate?materialType=1';
        this.http.post(fullApiUrl, null)
            .then((res) => {
                that.ConsumableMaterialPriceUpdateDTO = res as Array<UpdateMaterialPriceListDTO>;
                that.showLoadPanel = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                that.showLoadPanel = false;
            });
    }
    getDrugDefinitionPriceUpdate() {
        let that = this;
        that.showLoadPanel = true;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetMaterialPriceUpdate?materialType=0';
        this.http.post(fullApiUrl, null)
            .then((res) => {
                that.DrugDefinitionPriceUpdateDTO = res as Array<UpdateMaterialPriceListDTO>;
                that.showLoadPanel = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                that.showLoadPanel = false;
            });
    }

    async UpdateConsumableMaterialPrice() {
        if (this.selectedConsumableMaterialPriceItems.length == 0) {
            TTVisual.InfoBox.Alert("Güncellenecek Malzeme Seçilmeden İşlem Devam Edilemez.");
            return;
        }

        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Vazgeç", "E,V", i18n("M23735", "Uyarı"), "Güncelleme Tarihi", "Malzemenin Fiyat Geçerlilik Başlangıç Tarihi = "
            + this.StartedDateOfConsumableMaterialPrice.ToShortDateString() + " Olacaktır. \r\n\r\n Devam etmek istiyor musunuz?");
        if (messageResult === "E") {
            let that = this;
            that.showLoadPanel = true;
            let inputDTO = new InputPriceDTO();
            inputDTO.startDateOfPrice = this.StartedDateOfConsumableMaterialPrice;
            inputDTO.selectedMaterials = this.selectedConsumableMaterialPriceItems;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/UpdateMaterialPriceForSeletectedMats';
            this.http.post(fullApiUrl, inputDTO)
                .then((res) => {
                    that.showLoadPanel = false;
                    that.getConsumableMaterialPriceUpdate();
                    TTVisual.InfoBox.Alert("Seçili Malzemeler İçin Fiyat Güncelleme İşlemi Yapılmıştır.");
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    that.showLoadPanel = false;
                });

        } else {
            ServiceLocator.MessageService.showInfo(i18n("M14753", "İşleminden Vazgeçildi"));
        }
    }

    async UpdateDrugDefinitionPrice() {
        if (this.selectedDrugDefinitionPriceItems.length == 0) {
            TTVisual.InfoBox.Alert("Güncellenecek Malzeme Seçilmeden İşlem Devam Edilemez.");
            return;
        }

        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Vazgeç", "E,V", i18n("M23735", "Uyarı"), "Güncelleme Tarihi", "İlaç Fiyat Geçerlilik Başlangıç Tarihi = "
            + this.StartedDateOfDrugDefinitionPrice.ToShortDateString() + " Olacaktır. \r\n\r\n Devam etmek istiyor musunuz?");
        if (messageResult === "E") {
            let that = this;
            that.showLoadPanel = true;
            let inputDTO = new InputPriceDTO();
            inputDTO.startDateOfPrice = this.StartedDateOfDrugDefinitionPrice;
            inputDTO.selectedMaterials = this.selectedDrugDefinitionPriceItems;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/UpdateMaterialPriceForSeletectedMats';
            this.http.post(fullApiUrl, inputDTO)
                .then((res) => {
                    that.showLoadPanel = false;
                    that.getConsumableMaterialPriceUpdate();
                    TTVisual.InfoBox.Alert("Seçili Malzemeler İçin Fiyat Güncelleme İşlemi Yapılmıştır.");
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    that.showLoadPanel = false;
                });

        } else {
            ServiceLocator.MessageService.showInfo(i18n("M14753", "İşleminden Vazgeçildi"));
        }
    }

    public StockActionInDetailGridColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            visible: false,
            allowEditing: false,
            width: 50
        },
        {
            caption: "Malzeme Adı",
            dataField: 'MaterialName',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Taşınır Kodu',
            dataField: 'NATOStockNO',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'Barkod',
            dataField: 'Barcode',
            allowEditing: false,
            width: 120
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            dataField: 'DistributionTypeName',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: "Miktar",
            dataField: 'OldAmount',
            dataType: 'number',
            allowEditing: false,
            width: 120,
        },
        {
            caption: "Yeni Miktar",
            dataField: 'Amount',
            dataType: 'number',
            headerCellTemplate: 'titleHeaderTemplateMini',
            width: 120,
        },
        {
            caption: i18n("M17464", "KDV\'siz Fiyatı"),
            dataField: 'OldUnitPriceWithOutVat',
            dataType: 'number',
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: "Yeni KVDV\'siz Fiyatı",
            dataField: 'UnitPriceWithOutVat',
            dataType: 'number',
            headerCellTemplate: 'titleHeaderTemplateMini',
            width: 'auto',
        },
        {
            caption: i18n("M17457", "KDV Oranı"),
            dataField: 'OldVatRate',
            dataType: 'number',
            width: 100,
            allowEditing: false,
        },
        {
            caption: "Yeni KDV Oranı",
            dataField: 'VatRate',
            dataType: 'number',
            headerCellTemplate: 'titleHeaderTemplateMini',
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
            allowEditing: false,
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
    ];

    public async GetStockActionInDetails() {
        this.panelOperation(true, 'Yükleniyor...');
        try {
            let that = this;
            let inputDvo = new GetStockActionInDetails_Input();
            inputDvo.stockActionID = that.stockActionID;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetStockActionInDetails';
            this.http.post(fullApiUrl, inputDvo)
                .then((res: GetStockActionInDetails_Output) => {
                    if (res.error) {
                        ServiceLocator.MessageService.showError(res.errorMessage);

                    } else {
                        that.stockActionInDetailDataSource = res.stockActionDetails;
                        that.CalculateFormTotalPrice();
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
            this.panelOperation(false, '');
        }
        catch (ex) {
            TTVisual.InfoBox.Alert(ex);
            this.panelOperation(false, '');
        }
    }

    public onStockActionInDetailGridRowUpdated(event: any) {
        let data = <StockActionInDetailDTO>event.key;
        let cancelEvent: boolean = this.MaterialRowUpdatePriceGridCellChanged(data);
        if (cancelEvent === true) {
            event.cancel = true;
            return;
        }
        this.CalculateFormTotalPrice();
        if (this.selectedStockActionInDetails.find(x => x.ObjectID === data.ObjectID) == null)
            this.selectedStockActionInDetails.push(data);
        this.stockActionInDetailGrid.instance.selectRows(this.selectedStockActionInDetails, true);
    }
    public onStockActionInDetailGridRowUpdating(event: any) {

    }

    public MaterialRowUpdatePriceGridCellChanged(data: StockActionInDetailDTO): boolean {

        if (data.OldAmount > data.Amount) {
            ServiceLocator.MessageService.showError('Yeni miktar eski miktardan az olamaz!');
            return true;
        }
        if (data.Amount <= 0 || data.UnitPriceWithOutVat <= 0) {
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
            return false;
        }
    }

    public CalculateFormTotalPrice() {
        let priceCalc: Array<number> = new Array<number>();
        let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
        priceCalc.push(totalWithoutKDV);
        priceCalc.push(totalWithKDV);
        priceCalc.push(salesTotal);
        priceCalc.push(totalPrice);
        for (let data of this.stockActionInDetailDataSource) {
            if (data.UnitPriceWithInVat === null || data.UnitPriceWithOutVat === null || data.DiscountAmount === null)
                continue;
            priceCalc[0] += data.Amount * data.UnitPriceWithOutVat;
            //prices[1] += <Currency>inDet.Amount * Convert.ToDouble(inDet.UnitPriceWithInVat);
            priceCalc[1] += data.Amount * (data.UnitPriceWithOutVat + (data.UnitPriceWithOutVat * data.VatRate / 100));

            priceCalc[2] += data.DiscountAmount;
        }
        priceCalc[3] = priceCalc[1] - priceCalc[2];
        this.txtNotKDV = priceCalc[0].toFixed(2);
        this.txtWithKDV = priceCalc[1].toFixed(2);
        this.txtDiscount = priceCalc[2].toFixed(2);
        this.txtTotalPrice = priceCalc[3].toFixed(2);
    }

    public UpdateStockActionInDetails() {
        this.panelOperation(true, 'Yükleniyor...');
        try {
            let that = this;
            let inputDvo = new UpdateStockActionInDetails_Input();
            inputDvo.stockActionDetails = that.selectedStockActionInDetails;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/UpdateStockActionInDetails';
            this.http.post(fullApiUrl, inputDvo)
                .then((res: string) => {
                    ServiceLocator.MessageService.showSuccess(res);
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
            this.panelOperation(false, '');
        }
        catch (ex) {
            TTVisual.InfoBox.Alert(ex);
            this.panelOperation(false, '');
        }
    }

    DetailsCovid19GridColumns = [{
        caption: ' ',
        dataField: 'StockActionDetailID',
        visible: false,
        allowEditing: false,
        width: 50
    },
    {
        caption: "Malzeme Adı",
        dataField: 'MaterialName',
        allowEditing: false,
        width: 350
    },
    {
        caption: 'Barkodu',
        dataField: 'Barcode',
        allowEditing: false,
        width: 120
    },
    {
        caption: 'Taiınır Kodu',
        dataField: 'NatoStockNo',
        allowEditing: false,
        width: 120
    },
    {
        caption: 'Miktar',
        dataField: 'Amount',
        allowEditing: false,
        width: 120
    },
    {
        dataField: "NotDiscountedUnitPrice",
        caption: "KDV'siz Fiyatı",
        dataType: "number",
        allowEditing: true,
        width: 120
    },
    {
        dataField: "VatRate",
        caption: "KDV Oranı",
        dataType: "number",
        allowEditing: true,
        width: 120
    },
    {
        dataField: "DiscountRate",
        caption: "İndirim Oranı",
        dataType: "number",
        allowEditing: true,
        width: 120
    },
    {
        caption: 'Birim Fiyat',
        dataField: 'UnitePrice',
        allowEditing: false,
        width: 120
    },
    {
        caption: 'Toplam Fiyat',
        dataField: 'TotalPrice',
        allowEditing: false,
        width: 120
    }
    ];

    public totalNotKDV: string;
    public totalKDV: string;
    public totalDiscount: string;
    public totalPrice: string;


    public CalculateCovid19FormTotalPrice() {

        let totalNotKDVCell: number = 0;
        let totalKDVCell: number = 0;
        let totalDiscountCell: number = 0;
        let totalPriceCell: number = 0;


        for (let data of this.covid19StockAction.DetailsCovid19) {
            totalNotKDVCell += data.NotDiscountedUnitPrice * data.Amount;
            totalKDVCell += (data.NotDiscountedUnitPrice + (data.NotDiscountedUnitPrice * data.VatRate / 100)) * data.Amount;
            totalDiscountCell += (totalKDVCell * data.DiscountRate / 100);
            totalPriceCell += data.TotalPrice;
        }
        this.totalNotKDV = totalNotKDVCell.toFixed(2);
        this.totalKDV = totalKDVCell.toFixed(2);
        this.totalDiscount = totalDiscountCell.toFixed(2);
        this.totalPrice = totalPriceCell.toFixed(2);
    }


    DetailsCovid19PriceUpdate(event: any) {
        let data = <StockActionDetailCovid19>event.data;
        if (data.VatRate < 0 && data.VatRate == null) {
            ServiceLocator.MessageService.showError('KDV Oranı boş ve sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }
        if (data.NotDiscountedUnitPrice < 0 && data.NotDiscountedUnitPrice == null) {
            ServiceLocator.MessageService.showError('Vergisiz Birim fiyat boş ve sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }

        if (data.DiscountRate < 0) {
            ServiceLocator.MessageService.showError('İndirim Oranı sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }


        let kdvsizbirimfiyat: number = data.NotDiscountedUnitPrice;
        let kdvOran: number = data.VatRate;
        let indirimOrani: number = data.DiscountRate;

        let kdvliFiyat: number = kdvsizbirimfiyat + (kdvsizbirimfiyat * kdvOran / 100);
        let indirimliFiyat: number = kdvliFiyat - (kdvliFiyat * indirimOrani / 100);
        let satirFiyat = indirimliFiyat * data.Amount;
        data.TotalPrice = Math.Round(satirFiyat, 4);

        let kdvfiyat = (data.NotDiscountedUnitPrice + (data.NotDiscountedUnitPrice * data.VatRate / 100));
        let indirimlifiyat = (kdvfiyat - (kdvfiyat * data.DiscountRate / 100));
        data.UnitePrice = Math.Round(indirimlifiyat, 4);

        this.CalculateCovid19FormTotalPrice();
    }

    DetailsCovid19PriceCell() {
        for (let data of this.covid19StockAction.DetailsCovid19) {
            let kdvsizbirimfiyat: number = data.NotDiscountedUnitPrice;
            let kdvOran: number = data.VatRate;
            let indirimOrani: number = data.DiscountRate;
            let kdvliFiyat: number = kdvsizbirimfiyat + (kdvsizbirimfiyat * kdvOran / 100);
            let indirimliFiyat: number = kdvliFiyat - (kdvliFiyat * indirimOrani / 100);
            let satirFiyat = indirimliFiyat * data.Amount;
            data.TotalPrice = Math.Round(satirFiyat, 4);
            data.UnitePrice = Math.Round(indirimliFiyat, 4);
        }
    }

    covid19StockAction: GetCovid19StockAction_Output = new GetCovid19StockAction_Output();
    CovidStockActionGet: boolean = false;
    public async GetCovid19StockAction() {
        this.panelOperation(true, 'Yükleniyor...');
        this.totalNotKDV = null;
        this.totalKDV = null;
        this.totalDiscount = null;
        this.totalPrice = null;

        try {
            let that = this;
            this.covid19StoreID = this.activeUserService.SelectedUserStore.ObjectID;

            let inputDvo = new GetCovid19StockAction_Input();
            inputDvo.covid19StoreID = this.covid19StoreID;
            inputDvo.covid19StockActionID = this.covid19StockActionID;
            inputDvo.covid19TifID = this.covid19TifID;

            let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetCovid19StockAction';
            this.http.post(fullApiUrl, inputDvo)
                .then((res: GetCovid19StockAction_Output) => {
                    that.covid19StockAction = res;
                    that.CovidStockActionGet = true;
                    this.DetailsCovid19PriceCell();
                    this.CalculateCovid19FormTotalPrice();
                })
                .catch(error => {
                    that.CovidStockActionGet = false;
                    this.covid19StockAction = new GetCovid19StockAction_Output();
                    this.covid19StockAction.DetailsCovid19 = new Array<StockActionDetailCovid19>();
                    TTVisual.InfoBox.Alert(error);
                });
            this.panelOperation(false, '');
        }
        catch (ex) {
            this.CovidStockActionGet = false;
            this.covid19StockAction = new GetCovid19StockAction_Output();
            this.covid19StockAction.DetailsCovid19 = new Array<StockActionDetailCovid19>();
            TTVisual.InfoBox.Alert(ex);
            this.panelOperation(false, '');
        }
    }


    public ControlOfDocument() {

        if (this.covid19StockAction.DocumentDateTime == null)
            return false;
        if (this.covid19StockAction.Waybill == null || String.isNullOrEmpty(this.covid19StockAction.Waybill) == true)
            return false;
        if (this.covid19StockAction.WaybillDate == null)
            return false;
        if (this.covid19StockAction.MKYS_TeslimAlan == null || String.isNullOrEmpty(this.covid19StockAction.MKYS_TeslimAlan) == true)
            return false;
        if (this.covid19StockAction.MKYS_TeslimEden == null || String.isNullOrEmpty(this.covid19StockAction.MKYS_TeslimEden) == true)
            return false;
        if (this.covid19StockAction.Supplier == null)
            return false;

        if (this.covid19StockAction.ActionType == 2) {
            if (this.covid19StockAction.RegistrationAuctionNo == null || String.isNullOrEmpty(this.covid19StockAction.RegistrationAuctionNo) == true)
                return false;
            if (this.covid19StockAction.AuctionDate == null)
                return false;
            if (this.covid19StockAction.ExaminationReportNo == null || String.isNullOrEmpty(this.covid19StockAction.ExaminationReportNo) == true)
                return false;
            if (this.covid19StockAction.ExaminationReportDate == null)
                return false;
            if (this.covid19StockAction.Supplier == null)
                return false;
        }
    }

    async UpdateCovid19StockAction() {

        if (this.ControlOfDocument() == false) {
            ServiceLocator.MessageService.showError("Boş Alan kontrolü. Değerler doldurulmadan geçilemez.");
            return;
        }


        let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '',
            ' Yaptıgnız değişiklikleri kaydetmek ve MKYSye göndermek istiyormusunuz ? ');
        if (result === "OK") {
            let result = await UsernamePwdBox.Show(true);
            if ((<ModalActionResult>result).Result == DialogResult.OK) {
                this.showLoadPanel = true;
                let params = <any>(<ModalActionResult>result).Param;
                try {

                    if (params.password != null || String.isNullOrEmpty(params.password) != true) {
                        let that = this;
                        let inputDvo = new UpdateStockActionCovid19_Input();
                        inputDvo.DocumentRecordLogID = that.covid19StockAction.DocumentRecordLogID;
                        inputDvo.stockActionObjectID = that.covid19StockAction.StockActionObjectID;
                        inputDvo.covid19ActionChange = that.covid19StockAction;
                        inputDvo.mkyspass = params.password;

                        let fullApiUrl: string = 'api/LogisticAddAndUpdate/UpdateStockActionCovid19MKYS';
                        this.http.post(fullApiUrl, inputDvo)
                            .then((res: string) => {
                                if (res === "OK") {
                                    ServiceLocator.MessageService.showSuccess("İşlem Tamamlandı");
                                } else {
                                    ServiceLocator.MessageService.showError("HATA : "+res);
                                }
                            })
                            .catch(error => {
                                ServiceLocator.MessageService.showError(error);
                            });
                        this.panelOperation(false, '');
                    }
                    else {
                        this.showLoadPanel = false;
                        ServiceLocator.MessageService.showError("MKYS Şifresi boş geçilemez.");
                    }
                }
                catch (ex) {
                    ServiceLocator.MessageService.showError("HATA : "+ex);
                    this.panelOperation(false, '');
                }
            } else {
                ServiceLocator.MessageService.showError("İşlemden vaz geçildi.");
            }
        }
    }


    public onSupplierChanged(event): void {

        if (event != null) {
            if (this.covid19StockAction.Supplier != event) {
                this.covid19StockAction.Supplier = event;
            }
        } else {
            this.covid19StockAction.Supplier = null;
        }
    }
}