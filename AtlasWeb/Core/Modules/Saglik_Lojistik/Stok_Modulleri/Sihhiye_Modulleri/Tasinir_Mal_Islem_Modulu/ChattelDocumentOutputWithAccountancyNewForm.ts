//$4A97DC99
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { ChattelDocumentOutputWithAccountancyNewFormViewModel, OuttableLotDTO, QRCodeReadDTO } from './ChattelDocumentOutputWithAccountancyNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentOutputWithAccountancy } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentOutputWithAccountancy";
import { ChattelDocumentOutputDetailWithAccountancy, DocumentTransactionTypeEnum, MKYS_ECikisStokHareketTurEnum, TasinirCikisHareketTurEnum, StockActionDetailStatusEnum, TransactionTypeEnum, MKYS_EMalzemeGrupEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentOutputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisIslemTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { StockActionService, OpenStockActionDetailOutput_Input, GetOuttableLots_Output, GetOuttableLots_Input } from 'NebulaClient/Services/ObjectService/StockActionService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IntegerParam, BooleanParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { NewMaterialService, MaterialSelectorInput } from 'app/Logistic/Views/NewMaterialSelectComponent';
import { StockTransactionForITS } from 'app/Logistic/Views/ITSComponent';

@Component({
    selector: 'ChattelDocumentOutputWithAccountancyNewForm',
    templateUrl: './ChattelDocumentOutputWithAccountancyNewForm.html',
    providers: [MessageService]
})
export class ChattelDocumentOutputWithAccountancyNewForm extends BaseChattelDocumentOutputWithAccountancy implements OnInit {
    public StockActionSignDetailsColumns = [];
    public stockActionOrderNoCount: number = 0;
    public checkBoxValuePTS: boolean = false;
    public MaterialInput: MaterialSelectorInput = new MaterialSelectorInput();
    public qrCodeValue: string;
    public isQRCodeEnter: boolean = false;
    public chattelDocumentOutputWithAccountancyNewFormViewModel: ChattelDocumentOutputWithAccountancyNewFormViewModel = new ChattelDocumentOutputWithAccountancyNewFormViewModel();
    public get _ChattelDocumentOutputWithAccountancy(): ChattelDocumentOutputWithAccountancy {
        return this._TTObject as ChattelDocumentOutputWithAccountancy;
    }
    private ChattelDocumentOutputWithAccountancyNewForm_DocumentUrl: string = '/api/ChattelDocumentOutputWithAccountancyService/ChattelDocumentOutputWithAccountancyNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        private changeDetectorRef: ChangeDetectorRef,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ChattelDocumentOutputWithAccountancyNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    async checkBoxValuePTS_valueChanged(e) {
        var newValue = e.value;
        if (newValue == true) {
            this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.IsPTSAction = newValue;
        } else {
            this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.IsPTSAction = newValue;
        }
    }

    public QRCodeStockActionDetailColumns = [
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
            //   width: 'auto'
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            //   width: 'auto'
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            //  width: 'auto'
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
        }
    ];

    public QRCodeReadColumns = [
        {
            caption: 'Barkod',
            dataField: 'Barcode',
            allowEditing: false,
        },
        {
            caption: 'S.K.T',
            dataField: 'ExpirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
        },
        {
            caption: 'Lot No',
            dataField: 'LotNo',
            allowEditing: false,
        },
        {
            caption: 'Seri No',
            dataField: 'SerialNo',
            allowEditing: false,
        },
        {
            caption: 'Miktar',
            dataField: 'Amount',
            allowEditing: false,
        }
    ];

    // ***** Method declarations start *****

    /*protected async BarcodeRead(value: string): Promise<void> {
        super.BarcodeRead(value);
        let material: Material = null;
        let materials: Array<any> = this._ChattelDocumentOutputWithAccountancy.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + value + "'");
        if (materials.length === 0)
            TTVisual.InfoBox.Show(value + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
        else if (materials.length === 1)
            material = <Material>materials[0];
        else {
            let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let m of materials) {
                multiSelectForm.AddMSItem(m.Name, m.Name, m);
            }
            let key: string = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");
            if (String.isNullOrEmpty(key))
                TTVisual.InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
            else material = multiSelectForm.MSSelectedItemObject as Material;
        }
        if (material !== null) {
            let retAmount: string = TTVisual.InputForm.GetText("Çıkış Yapılacak Miktarı Giriniz.");
            let amount: Currency = 0;
            if (String.isNullOrEmpty(retAmount) === false) {
                if (CurrencyType.TryConvertFrom(retAmount, false, amount) === false)
                    throw new TTException((await SystemMessageService.GetMessageV3(1192, [retAmount.toString()])));
            }
            let chattelDocumentOutputDetailWithAccountancy: ChattelDocumentOutputDetailWithAccountancy = this._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.AddNew();
            chattelDocumentOutputDetailWithAccountancy.Material = material;
            chattelDocumentOutputDetailWithAccountancy.Amount = amount;
            chattelDocumentOutputDetailWithAccountancy.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
        }
    }*/

    async QRCodeAddIn_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let that = this;
            that.onQCodeReadClick();
        }
    }

    async onQCodeReadClick() {
        if (String.isNullOrEmpty(this.qrCodeValue) == false) {
            let that = this;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/QRCodeRead?qrCode=' + that.qrCodeValue;
            this.httpService.post(fullApiUrl, null)
                .then((res) => {
                    let result: StockTransactionForITS = res as StockTransactionForITS;
                    let findReadQRCode: QRCodeReadDTO = that.chattelDocumentOutputWithAccountancyNewFormViewModel.QRCodeReadList.find(x => x.MaterialObjectID === result.materialObjectID &&
                        x.LotNo === result.lotNo && x.SerialNo == result.serialNo && x.ExpirationDate == result.expirationDate);
                    if (findReadQRCode != null) {
                        TTVisual.InfoBox.Alert("Bu kare kod daha önce okutulmuştur.");
                        this.qrCodeValue = "";
                    } else {
                        let findOutDetail: ChattelDocumentOutputDetailWithAccountancy = that.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.find(x => x.Material.ObjectID === result.materialObjectID);
                        if (findOutDetail != null) {
                            let sumAmount: number = result.inAmount;
                            that.chattelDocumentOutputWithAccountancyNewFormViewModel.QRCodeReadList.forEach(element => {
                                sumAmount = sumAmount + element.Amount;
                            });
                            if (sumAmount > findOutDetail.Amount) {
                                TTVisual.InfoBox.Alert("Okutulan İlaç: " + result.materialName + " okutulan miktar çıkış yapılan miktardan fazla olamaz. Okutulan Miktar:" + sumAmount.toString() + " Çıkış Yapılacak Miktar:" + findOutDetail.Amount.toString());
                                this.qrCodeValue = "";
                            } else {
                                let readQRCode: QRCodeReadDTO = new QRCodeReadDTO();
                                readQRCode.Amount = result.inAmount;
                                readQRCode.Barcode = result.barcode;
                                readQRCode.ExpirationDate = result.expirationDate;
                                readQRCode.LotNo = result.lotNo;
                                readQRCode.MaterialObjectID = result.materialObjectID;
                                readQRCode.SerialNo = result.serialNo;
                                that.chattelDocumentOutputWithAccountancyNewFormViewModel.QRCodeReadList.push(readQRCode);
                                this.qrCodeValue = "";
                            }
                        } else {
                            TTVisual.InfoBox.Alert("Okutulan İlaç: " + result.materialName + " güncellenecek listede bulunamadı.");
                            this.qrCodeValue = "";
                        }
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.qrCodeValue = "";
                });
        }
        else {
            TTVisual.InfoBox.Alert("Barkod okutulmadı girilmeden işleme devam edilemez.");
        }
    }

    public addQRCodeClick() {
        this.isQRCodeEnter = true;
    }

    public rowVisible: boolean;
    protected async ClientSidePreScript() {
        super.ClientSidePreScript();
        this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;




    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        let count: number = 20;
        // this._ChattelDocumentOutputWithAccountancy.CheckStockCardCardNofCount(count);
    }

    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() == PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }

    }

    onMaterialGridRowUpdating(data: any) {

    }

    async getDetail_CellContentClicked(data: any) {

        if (data.data == null) {
            ServiceLocator.MessageService.showInfo('Malzeme seçmediniz.');
            return;
        }
        if (this._ChattelDocumentOutputWithAccountancy.Store == null) {
            ServiceLocator.MessageService.showInfo('Depo seçmediniz.');
            return;
        }
        if (data.data.Amount == null) {
            ServiceLocator.MessageService.showInfo('Miktar girmediniz.');
            return;
        }
        let inputParam: OpenStockActionDetailOutput_Input = new OpenStockActionDetailOutput_Input();
        inputParam.MaterialID = data.data.Material.ObjectID;
        inputParam.StoreID = this._ChattelDocumentOutputWithAccountancy.Store.ObjectID;
        inputParam.MaterialName = data.data.Material.Name;
        inputParam.RequestAmount = data.data.Amount;
        inputParam.Barcode = data.data.Material.Barcode;
        inputParam.DistributionTypeName = data.data.Material.DistributionTypeName;
        if (this.chattelDocumentOutputWithAccountancyNewFormViewModel.OuttableLotList != null)
            inputParam.selectedOuttableLots = this.chattelDocumentOutputWithAccountancyNewFormViewModel.OuttableLotList.filter(x => x.StockActionDetailOrderNo === data.data.ChattelDocDetailOrderNo);
        else
            inputParam.selectedOuttableLots = new Array<OuttableLotDTO>();
        this.showStockActionDetailOutForm(inputParam).then(res => {
            let modalActionResult = res as ModalActionResult;
            if (modalActionResult.Result === DialogResult.OK) {
                this.chattelDocumentOutputWithAccountancyNewFormViewModel.OuttableLotList = this.chattelDocumentOutputWithAccountancyNewFormViewModel.OuttableLotList.
                    filter(x => x.StockActionDetailOrderNo !== data.data.ChattelDocDetailOrderNo);
                let outtableLots = res.Param as Array<GetOuttableLots_Output>;
                this.stockActionOrderNoCount = this.stockActionOrderNoCount + 1;
                data.data.ChattelDocDetailOrderNo = this.stockActionOrderNoCount;
                data.data.UserSelectedOutableTrx = true;
                for (let outTRX of outtableLots) {
                    let outtableLot: OuttableLotDTO = new OuttableLotDTO();
                    outtableLot.Amount = outTRX.RestAmount;
                    outtableLot.BudgetTypeName = outTRX.BudgetTypeName;
                    outtableLot.ExpirationDate = outTRX.ExpirationDate;
                    outtableLot.LotNo = outTRX.LotNo;
                    outtableLot.RestAmount = outTRX.RestAmount;
                    outtableLot.SerialNo = outTRX.SerialNo;
                    outtableLot.TrxObjectID = outTRX.TrxObjectID;
                    outtableLot.StockActionDetailOrderNo = this.stockActionOrderNoCount;
                    this.chattelDocumentOutputWithAccountancyNewFormViewModel.OuttableLotList.push(outtableLot);
                }
            }
        });
    }

    private showStockActionDetailOutForm(data: OpenStockActionDetailOutput_Input): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'StockActionDetailOutForm';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Çıkılabilir Girişler';
            modalInfo.Width = 800;
            modalInfo.Height = 500;
            modalInfo.IsShowCloseButton = false;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    protected async PreScript() {
        super.PreScript();

        let isApproved: string = (await SystemParameterService.GetParameterValue('STOCKACTIONSTATENEWTOCOMPLETED', 'TRUE'));
        if (isApproved === 'TRUE') {
            this.DropStateButton(ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputWithAccountancyStates.Approved);
        } else {
            this.DropStateButton(ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputWithAccountancyStates.Completed);
        }

        if (this._ChattelDocumentOutputWithAccountancy.Store == null) {
            this._ChattelDocumentOutputWithAccountancy.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }

        this.MaterialChattelDocumentDetailWithAccountancy.ListFilterExpression = "STOCKS.STORE = '" + this._ChattelDocumentOutputWithAccountancy.Store.ObjectID + "' AND STOCKS.INHELD > 0";

        /* let signUserTypeEnum: Array<SignUserTypeEnum> = new Array<SignUserTypeEnum>();
              signUserTypeEnum.push(SignUserTypeEnum.TeslimAlan);
              signUserTypeEnum.push(SignUserTypeEnum.TeslimEden);
              if (this._ChattelDocumentOutputWithAccountancy.StockActionSignDetails.length === 0) {
                   this.chattelDocumentOutputWithAccountancyNewFormViewModel.StockActionSignDetailsGridList = await StockActionSignDetailService.StockActionSignUsersMethod(signUserTypeEnum);
                  this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails =  this.chattelDocumentOutputWithAccountancyNewFormViewModel.StockActionSignDetailsGridList;

              }*/

        if (this._ChattelDocumentOutputWithAccountancy.Store.ObjectDefID.valueOf() === PharmacyStoreDefinition.ObjectDefID.id || this._ChattelDocumentOutputWithAccountancy.Store.ObjectDefID.valueOf() === MainStoreDefinition.ObjectDefID.id) {
            this.rowVisible = true;
        }
        else {
            this.rowVisible = false;
        }
        this.MaterialInput.MaterialGroup = MKYS_EMalzemeGrupEnum.diger;
        this.MaterialInput.TransactionType = TransactionTypeEnum.Out;
        this.MaterialInput.StoreID = this._ChattelDocumentOutputWithAccountancy.Store.ObjectID;
        this.MaterialInput.TicketDate = this._ChattelDocumentOutputWithAccountancy.TransactionDate;
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            if (transDef.ToStateDefID != null) {
                if (transDef.ToStateDefID.valueOf() === ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputWithAccountancyStates.Completed.id) {
                    let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChattelDocumentOutputWithAccountancy.ObjectID.toString());
                    for (let document of documentRecordLogs) {
                        if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                            const objectIdParam = new GuidParam(document['ObjectID']);
                            const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                            let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                            this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
                        }
                        if (document.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                            const objectIdParam = new GuidParam(document['ObjectID']);
                            const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                            let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                            this.reportService.showReport('ChattelDocumentOutDetailReport', reportParameters);
                        }
                    }
                    if (this._ChattelDocumentOutputWithAccountancy.outputStockMovementType === TasinirCikisHareketTurEnum.stokFazlasiDevir) {
                        const objectIdParam = new GuidParam(this._ChattelDocumentOutputWithAccountancy.ObjectID);
                        const IsContributionMarginParam = new BooleanParam(this._ChattelDocumentOutputWithAccountancy.IsContainsContributions);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'IsContributionMargin': IsContributionMarginParam };
                        this.reportService.showReport('PharmacyInvoiceReport', reportParameters);
                    }
                }
            }
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentOutputWithAccountancy();
        this.chattelDocumentOutputWithAccountancyNewFormViewModel = new ChattelDocumentOutputWithAccountancyNewFormViewModel();
        this._ViewModel = this.chattelDocumentOutputWithAccountancyNewFormViewModel;
        this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy = this._TTObject as ChattelDocumentOutputWithAccountancy;
        this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.Store = new Store();
        this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy = new Array<ChattelDocumentOutputDetailWithAccountancy>();
        this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.Accountancy = new Accountancy();
        this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.chattelDocumentOutputWithAccountancyNewFormViewModel = this._ViewModel as ChattelDocumentOutputWithAccountancyNewFormViewModel;
        that._TTObject = this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy;
        if (this.chattelDocumentOutputWithAccountancyNewFormViewModel == null)
            this.chattelDocumentOutputWithAccountancyNewFormViewModel = new ChattelDocumentOutputWithAccountancyNewFormViewModel();
        if (this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy == null)
            this.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy = new ChattelDocumentOutputWithAccountancy();
        let storeObjectID = that.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.chattelDocumentOutputWithAccountancyNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.Store = store;
            }
        }
        that.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy = that.chattelDocumentOutputWithAccountancyNewFormViewModel.ChattelDocumentDetailsWithAccountancyGridList;
        for (let detailItem of that.chattelDocumentOutputWithAccountancyNewFormViewModel.ChattelDocumentDetailsWithAccountancyGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.chattelDocumentOutputWithAccountancyNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.chattelDocumentOutputWithAccountancyNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.chattelDocumentOutputWithAccountancyNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.chattelDocumentOutputWithAccountancyNewFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let accountancyObjectID = that.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy["Accountancy"];
        if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
            let accountancy = that.chattelDocumentOutputWithAccountancyNewFormViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.Accountancy = accountancy;
            }
        }
        that.chattelDocumentOutputWithAccountancyNewFormViewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails = that.chattelDocumentOutputWithAccountancyNewFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentOutputWithAccountancyNewFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === "string")) {
                let signUser = that.chattelDocumentOutputWithAccountancyNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.chattelDocumentOutputWithAccountancyNewFormViewModel.QRCodeReadList = new Array<QRCodeReadDTO>();
    }

    public ShowNewMaterialList: boolean = false;
    async ngOnInit() {
        let that = this;
        await this.load(ChattelDocumentOutputWithAccountancyNewFormViewModel);
        if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = "Taşınır Mal Çıkış ( Yeni )";
        this.changeDetectorRef.detectChanges();
        this.stockActionOrderNoCount = this._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.filter(x => x.ChattelDocDetailOrderNo != null).length

        if (this.chattelDocumentOutputWithAccountancyNewFormViewModel.OuttableLotList == null) {
            this.chattelDocumentOutputWithAccountancyNewFormViewModel.OuttableLotList = new Array<OuttableLotDTO>();
        }

        let listParameter: string = (await SystemParameterService.GetParameterValue('SHOWNEWMATERIALLIST', 'FALSE'));
        if (listParameter === "TRUE") {
            this.ShowNewMaterialList = true;
        }
        NewMaterialService.onMaterialAdd.subscribe((e) => {
            for (let item of e) {
                let newRow: ChattelDocumentOutputDetailWithAccountancy = new ChattelDocumentOutputDetailWithAccountancy();
                newRow.IsNew = true;
                newRow.Material = item.Material;
                newRow.Material.StockCard = item.StockCard;
                newRow.StockLevelType = item.StockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                newRow.StoreStock = item.StoreStock;
                newRow.VatRate = item.VatRate;
                this._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.push(newRow);
            }
        });
    }


    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Accountancy != event) {
                this._ChattelDocumentOutputWithAccountancy.Accountancy = event;
            }
        }
        // this.Accountancy_SelectedObjectChanged();
    }

    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.AdditionalDocumentCount != event) {
                this._ChattelDocumentOutputWithAccountancy.AdditionalDocumentCount = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Description != event) {
                this._ChattelDocumentOutputWithAccountancy.Description = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_CikisStokHareketTuru != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlan != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEden != event) {
                this._ChattelDocumentOutputWithAccountancy.MKYS_TeslimEden = event;
            }
        }
    }

    public onoutputStockMovementTypeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.outputStockMovementType != event) {
                this._ChattelDocumentOutputWithAccountancy.outputStockMovementType = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.StockActionID != event) {
                this._ChattelDocumentOutputWithAccountancy.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Store != event) {
                this._ChattelDocumentOutputWithAccountancy.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.TransactionDate != event) {
                this._ChattelDocumentOutputWithAccountancy.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.Waybill != event) {
                this._ChattelDocumentOutputWithAccountancy.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.WaybillDate != event) {
                this._ChattelDocumentOutputWithAccountancy.WaybillDate = event;
            }
        }
    }

    ChattelDocumentDetailsWithAccountancy_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithAccountancy_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {

    }
    public async ChattelDocumentDetailsWithAccountancy_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInsertting(data: ChattelDocumentOutputDetailWithAccountancy) {
    }

    onCellContentClicked(data: any) {
    }

    async initNewRow(data: any) {
    }

    public onIsContainsContributionsChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentOutputWithAccountancy != null && this._ChattelDocumentOutputWithAccountancy.IsContainsContributions != event) {
                this._ChattelDocumentOutputWithAccountancy.IsContainsContributions = event;
            }
        }
        this.IsContainsContributions_CheckedChanged();
    }

    private async IsContainsContributions_CheckedChanged(): Promise<void> {
        //await this.controlFreeEnty();
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.outputStockMovementType, "Value", this.__ttObject, "outputStockMovementType");
        redirectProperty(this.Waybill, "Text", this.__ttObject, "Waybill");
        redirectProperty(this.WaybillDate, "Value", this.__ttObject, "WaybillDate");
        redirectProperty(this.IsContainsContributions, "Value", this.__ttObject, "IsContainsContributions");
    }

    public initFormControls(): void {
        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 131;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;


        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Short;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 136;

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 137;

        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 134;

        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = "labelWaybill";
        this.labelWaybill.TabIndex = 135;

        this.labeloutputStockMovementType = new TTVisual.TTLabel();
        this.labeloutputStockMovementType.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.labeloutputStockMovementType.Name = "labeloutputStockMovementType";
        this.labeloutputStockMovementType.TabIndex = 133;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 130;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = "ChattelDocumentTabcontrol";
        this.ChattelDocumentTabcontrol.TabIndex = 6;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.ChattelDocumentTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentTabpage.DisplayIndex = 0;
        this.ChattelDocumentTabpage.TabIndex = 0;
        this.ChattelDocumentTabpage.Text = "Taşınır Malın";
        this.ChattelDocumentTabpage.Name = "ChattelDocumentTabpage";

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.ChattelDocumentDetailsWithAccountancy = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithAccountancy.Required = true;
        this.ChattelDocumentDetailsWithAccountancy.Name = "ChattelDocumentDetailsWithAccountancy";
        this.ChattelDocumentDetailsWithAccountancy.TabIndex = 0;
        this.ChattelDocumentDetailsWithAccountancy.Height = 350;
        this.ChattelDocumentDetailsWithAccountancy.AllowUserToDeleteRows = true;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.MaterialChattelDocumentDetailWithAccountancy = new TTVisual.TTListBoxColumn();
        this.MaterialChattelDocumentDetailWithAccountancy.AllowMultiSelect = true;
        this.MaterialChattelDocumentDetailWithAccountancy.ListDefName = "MaterialListDefinition";
        this.MaterialChattelDocumentDetailWithAccountancy.DataMember = "Material";
        this.MaterialChattelDocumentDetailWithAccountancy.AutoCompleteDialogHeight = '60%';
        this.MaterialChattelDocumentDetailWithAccountancy.AutoCompleteDialogWidth = '90%';
        this.MaterialChattelDocumentDetailWithAccountancy.DisplayIndex = 1;
        this.MaterialChattelDocumentDetailWithAccountancy.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialChattelDocumentDetailWithAccountancy.Name = "MaterialChattelDocumentDetailWithAccountancy";
        this.MaterialChattelDocumentDetailWithAccountancy.Width = 450;

        this.outputStockMovementType = new TTVisual.TTEnumComboBox();
        this.outputStockMovementType.DataTypeName = "TasinirCikisHareketTurEnum";
        this.outputStockMovementType.Name = "outputStockMovementType";
        this.outputStockMovementType.TabIndex = 132;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 130;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.Format = "N2";
        this.StoreStock.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStock.DisplayIndex = 4;
        this.StoreStock.HeaderText = i18n("M18957", "Mevcut");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 120;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.AmountChattelDocumentDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.AmountChattelDocumentDetailWithAccountancy.DataMember = "Amount";
        this.AmountChattelDocumentDetailWithAccountancy.Format = "N2";
        this.AmountChattelDocumentDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountChattelDocumentDetailWithAccountancy.DisplayIndex = 5;
        this.AmountChattelDocumentDetailWithAccountancy.HeaderText = i18n("M19030", "Miktar");
        this.AmountChattelDocumentDetailWithAccountancy.Name = "AmountChattelDocumentDetailWithAccountancy";
        this.AmountChattelDocumentDetailWithAccountancy.Width = 120;
        this.AmountChattelDocumentDetailWithAccountancy.IsNumeric = true;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.Format = "#,###.#########";
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11868", "Birim Maliyet Bedeli");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Visible = false;
        this.UnitPrice.Width = 120;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.Format = "#,###.#########";
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 7;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Visible = false;
        this.Price.Width = 100;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockLevelTypeChattelDocumentDetailWithAccountancy = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.DataMember = "StockLevelType";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.DisplayIndex = 8;
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.Name = "StockLevelTypeChattelDocumentDetailWithAccountancy";
        this.StockLevelTypeChattelDocumentDetailWithAccountancy.Width = 140;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.StatusChattelDocumentDetailWithAccountancy = new TTVisual.TTEnumComboBoxColumn();
        this.StatusChattelDocumentDetailWithAccountancy.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusChattelDocumentDetailWithAccountancy.DataMember = "Status";
        this.StatusChattelDocumentDetailWithAccountancy.DisplayIndex = 9;
        this.StatusChattelDocumentDetailWithAccountancy.HeaderText = "Durum";
        this.StatusChattelDocumentDetailWithAccountancy.Name = "StatusChattelDocumentDetailWithAccountancy";
        this.StatusChattelDocumentDetailWithAccountancy.Visible = false;
        this.StatusChattelDocumentDetailWithAccountancy.Width = 80;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = i18n("M14873", "Gönderildiği Yer");
        this.labelAccountancy.Name = "labelAccountancy";
        this.labelAccountancy.TabIndex = 121;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 5;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 128;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.lblMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisIslemTuru.Text = i18n("M12381", "Çıkış Türü");
        this.lblMKYS_CikisIslemTuru.Name = "lblMKYS_CikisIslemTuru";
        this.lblMKYS_CikisIslemTuru.TabIndex = 125;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 124;

        this.lblMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisStokHareketTuru.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.lblMKYS_CikisStokHareketTuru.Name = "lblMKYS_CikisStokHareketTuru";
        this.lblMKYS_CikisStokHareketTuru.TabIndex = 129;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.Width = 100;
        this.ValueAddedTax.ReadOnly = false;
        this.ValueAddedTax.Enabled = false;


        this.IsContainsContributions = new TTVisual.TTCheckBox();
        this.IsContainsContributions.Value = false;
        this.IsContainsContributions.Title = "Katkı Payı İçerir";
        this.IsContainsContributions.Name = "IsContainsContributions";
        this.IsContainsContributions.TabIndex = 128;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentTabpage];
        this.ChattelDocumentTabpage.Controls = [this.ChattelDocumentDetailsWithAccountancy];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.IsContainsContributions, this.Waybill, this.TTTeslimEdenButon, this.labelWaybillDate, this.TTTeslimAlanButon, this.WaybillDate, this.labelMKYS_TeslimEden, this.labelWaybill, this.MKYS_TeslimEden, this.labeloutputStockMovementType, this.MKYS_TeslimAlan, this.outputStockMovementType, this.Description, this.labelStore, this.StockActionID, this.Store, this.labelMKYS_TeslimAlan, this.ChattelDocumentTabcontrol, this.labelTransactionDate, this.ChattelDocumentTabpage, this.TransactionDate, this.ChattelDocumentDetailsWithAccountancy, this.labelStockActionID, this.Detail, this.DescriptionAndSignTabControl, this.MaterialChattelDocumentDetailWithAccountancy, this.SignTabpage, this.Barcode, this.StockActionSignDetails, this.DistributionType, this.SignUserType, this.StoreStock, this.SignUser, this.AmountChattelDocumentDetailWithAccountancy, this.IsDeputy, this.UnitPrice, this.ttlabel1, this.Price, this.StockLevelTypeChattelDocumentDetailWithAccountancy, this.StatusChattelDocumentDetailWithAccountancy, this.labelAccountancy, this.Accountancy, this.MKYS_CikisStokHareketTuru, this.lblMKYS_CikisIslemTuru, this.MKYS_CikisIslemTuru, this.lblMKYS_CikisStokHareketTuru];

    }


}
