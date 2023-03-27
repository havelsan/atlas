//$BF215CAB
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { ChattelDocumentInputWithAccountancyNewFormViewModel } from './ChattelDocumentInputWithAccountancyNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { CurrencyType } from 'NebulaClient/DataDictionary/TTDataType';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Accountancy, DocumentTransactionTypeEnum, StockLevelType, PTSStockActionDetail, StockActionDetailStatusEnum, UploadedDocument, ResUser, ConsumableMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BaseChattelDocumentInputWithAccountancyForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentInputWithAccountancyForm';
import { ChattelDocumentInputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentInputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { MKYS_EMalzemeGrupEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { StockMethodEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from 'ObjectClassService/SystemMessageService';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { StockActionDetailIn } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { FixedAssetInDetail, ChattelDocumentDetailWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { IModalService } from 'Fw/Services/IModalService';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { GetWaybillForInputDetailDocument_Output, ChattelDocumentInputWithAccountancyService } from 'ObjectClassService/ChattelDocumentInputWithAccountancyService';

import { MKYS_EButceTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MKYS_ETedarikTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TasinirMalGirisTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionService, GetInPatientPhysicianApplications_Output } from 'NebulaClient/Services/ObjectService/StockActionService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { PTSMaterial, PTSMaterialOutput, XMLReadDocumentFile, PTSInputDVO, PTSMaterialSerialNumber } from './BaseChattelDocumentWithPurchaseForm';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';

@Component({
    selector: 'ChattelDocumentInputWithAccountancyNewForm',
    templateUrl: './ChattelDocumentInputWithAccountancyNewForm.html',
    providers: [MessageService]
})
export class ChattelDocumentInputWithAccountancyNewForm extends BaseChattelDocumentInputWithAccountancyForm implements OnInit {
    public ChattelDocumentDetailsWithAccountancyColumns = [];
    public StockActionSignDetailsColumns = [];
    public IsPatientSpecial: Boolean = false;
    public PatientSpecialKey: string;
    public findPatient: boolean = false;
    public ITSButtonIsActive: boolean = false;
    public checkBoxValuePTS: boolean = false;
    public chattelDocumentInputWithAccountancyNewFormViewModel: ChattelDocumentInputWithAccountancyNewFormViewModel = new ChattelDocumentInputWithAccountancyNewFormViewModel();
    public get _ChattelDocumentInputWithAccountancy(): ChattelDocumentInputWithAccountancy {
        return this._TTObject as ChattelDocumentInputWithAccountancy;
    }
    private ChattelDocumentInputWithAccountancyNewForm_DocumentUrl: string = '/api/ChattelDocumentInputWithAccountancyService/ChattelDocumentInputWithAccountancyNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private modalService: IModalService,
        private reportService: AtlasReportService,
        private changeDetectorRef: ChangeDetectorRef,
        private activeUserService: IActiveUserService,
        protected ngZone: NgZone, protected objectContextService: ObjectContextService) {
        super(httpService, messageService, ngZone, objectContextService);
        this._DocumentServiceUrl = this.ChattelDocumentInputWithAccountancyNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    private async GetWaybill_Click() {
        if (this._ChattelDocumentInputWithAccountancy.CurrentStateDefID.toString() === ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.New.id) {
            if (!String.isNullOrEmpty(this._ChattelDocumentInputWithAccountancy.Waybill)) {
                let exp: GetWaybillForInputDetailDocument_Output = await ChattelDocumentInputWithAccountancyService.GetWaybillForInputDocumentTS(this._ChattelDocumentInputWithAccountancy);

                if (exp != null) {
                    for (let detail of exp.chattelDocumentInputDetailWithAccountancy) {
                        let chattelDetail: ChattelDocumentInputDetailWithAccountancy = new ChattelDocumentInputDetailWithAccountancy();
                        let mat: Guid = <any>detail['Material'];
                        let material: any = await this.objectContextService.getObject(mat, Material.ObjectDefID);
                        chattelDetail.Material = material;
                        let stockCardObj: Guid = <any>material['StockCard'];
                        let stockCard: any = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
                        chattelDetail.Material.StockCard = stockCard;
                        let dist: Guid = <any>stockCard['DistributionType'];
                        let distributionType: any = await this.objectContextService.getObject(dist, DistributionTypeDefinition.ObjectDefID);

                        chattelDetail.SentAmount = detail.SentAmount;
                        chattelDetail.Amount = detail.Amount;
                        chattelDetail.NotDiscountedUnitPrice = detail.NotDiscountedUnitPrice;
                        chattelDetail.VatRate = 0;
                        chattelDetail.ProductionDate = detail.ProductionDate;
                        chattelDetail.ExpirationDate = detail.ExpirationDate;
                        chattelDetail.RetrievalYear = detail.RetrievalYear;

                        this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.push(chattelDetail);
                        await this.CalculatePrices(chattelDetail);
                    }
                }


            }
        }
    }

    public async findPatientClick() {

        let inApps: Array<GetInPatientPhysicianApplications_Output> = await StockActionService.GetInPatientPhysicianApplications(this.PatientSpecialKey);
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();

        let count: number = 0;
        for (let inApp of inApps) {
            multiSelectForm.AddMSItem(inApp.Key, inApp.Key, inApp);
            count++;
        }

        let mlotKey: string = await multiSelectForm.GetMSItem(null, "Yatış Seçiniz", true);
        if (multiSelectForm.MSSelectedItemObject !== null) {
            let selectedInApp: GetInPatientPhysicianApplications_Output = multiSelectForm.MSSelectedItemObject as GetInPatientPhysicianApplications_Output;
            this._ChattelDocumentInputWithAccountancy.InPatientPhysicianApplication = selectedInApp.InPatientPhysicianApplication;
            this.PatientSpecialKey = selectedInApp.PatientInfo;
            this._ChattelDocumentInputWithAccountancy.Description = selectedInApp.Description;
            this.findPatient = true;
            this.Description.Enabled = false;
        }
    }

    protected async BarcodeRead(value: string): Promise<void> {
        super.BarcodeRead(value);
        let material: Material = null;
        let materials: Array<any> = this._ChattelDocumentInputWithAccountancy.ObjectContext.QueryObjects('MATERIAL', 'BARCODE=\'' + value + '\'');
        if (materials.length === 0)
            TTVisual.InfoBox.Show(value + i18n("M23691", " UBB/Barkodlu malzeme bulunamadı."), MessageIconEnum.ErrorMessage);
        else if (materials.length === 1)
            material = <Material>materials[0];
        else {
            let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let m of materials) {
                multiSelectForm.AddMSItem(m.Name, m.Name, m);
            }
            let key: string = await multiSelectForm.GetMSItem(this, i18n("M18606", "Malzeme seçin"));
            if (String.isNullOrEmpty(key))
                TTVisual.InfoBox.Show(i18n("M15735", "Herhangibir malzeme seçilmedi."), MessageIconEnum.ErrorMessage);
            else material = multiSelectForm.MSSelectedItemObject as Material;
        }
        if (material !== null) {
            let getAmount: Currency = 0;
            let retGetAmount: string = await TTVisual.InputForm.GetText(i18n("M14896", "Gönderilen Miktarı Giriniz."));
            if (String.isNullOrEmpty(retGetAmount) === false) {
                if (CurrencyType.TryConvertFrom(retGetAmount, false, getAmount) === false)
                    throw new TTException((await SystemMessageService.GetMessageV3(1192, [retGetAmount.toString()])));
            }
            let retAmount: string = await TTVisual.InputForm.GetText(i18n("M10708", "Alınan Miktarı Giriniz."));
            let amount: Currency = 0;
            if (String.isNullOrEmpty(retAmount) === false) {
                if (CurrencyType.TryConvertFrom(retAmount, false, amount) === false)
                    throw new TTException((await SystemMessageService.GetMessageV3(1192, [retAmount.toString()])));
            }
            let unitPrice: Currency = 0;
            let retUnitPrice: string = await TTVisual.InputForm.GetText(i18n("M11869", "Birim Maliyet Bedelini Giriniz"));
            if (String.isNullOrEmpty(retUnitPrice) === false) {
                if (CurrencyType.TryConvertFrom(retUnitPrice, false, unitPrice) === false)
                    throw new TTException((await SystemMessageService.GetMessageV3(1192, [retUnitPrice.toString()])));
            }
            let chattelDocumentInputDetailWithAccountancy: ChattelDocumentInputDetailWithAccountancy = this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.AddNew();
            chattelDocumentInputDetailWithAccountancy.Material = material;
            chattelDocumentInputDetailWithAccountancy.Amount = amount;
            chattelDocumentInputDetailWithAccountancy.SentAmount = getAmount;
            chattelDocumentInputDetailWithAccountancy.UnitPrice = <Currency>unitPrice;
            //chattelDocumentInputDetailWithAccountancy.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
            switch (<StockMethodEnum>material.StockCard.StockMethod) {
                case StockMethodEnum.ExpirationDated:
                    // let retExpirationDate: Date = await TTVisual.InputForm.GetDateTime("Son Kullanma Tarihi Giriniz.", "mm/dd/yyyy", true);
                    //chattelDocumentInputDetailWithAccountancy.ExpirationDate = (await CommonService.GetLastDayOfMounth(<Date>retExpirationDate));
                    break;
                case StockMethodEnum.LotUsed:
                    let retLotNo: string = await TTVisual.InputForm.GetText(i18n("M18358", "Lot Numarasını Giriniz."));
                    if (String.isNullOrEmpty(retLotNo) === false)
                        chattelDocumentInputDetailWithAccountancy.LotNo = retLotNo;
                    break;
                case StockMethodEnum.StockNumbered:
                case StockMethodEnum.QRCodeUsed:
                default:
                    break;
            }
        }
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
    }
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();


        if (this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup == null) {
            let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            mSelectForm.AddMSItem(i18n("M23417", "Tıbbi Sarf"), i18n("M23417", "Tıbbi Sarf"), MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem(i18n("M16287", "İlaç"), i18n("M16287", "İlaç"), MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem(i18n("M23359", "Tıbbi Cihaz"), i18n("M23359", "Tıbbi Cihaz"), MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem(i18n("M12780", "Diğer"), i18n("M12780", "Diğer"), MKYS_EMalzemeGrupEnum.diger);
            let mkey: string = await mSelectForm.GetMSItem(this, i18n("M14806", "Giriş Yapılacak Malzeme Grubunu Seçiniz"), true);
            if (String.isNullOrEmpty(mkey))
                this.messageService.showError(i18n("M18579", "Malzeme grubu seçilmeden işleme devam edemezsiniz."));
            // throw new TTException((await SystemMessageService.GetMessageV2(369, 'Malzeme grubu seçilmeden işleme devam edemezsiniz.')));
            this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup = <MKYS_EMalzemeGrupEnum>mSelectForm.MSSelectedItemObject;
            if (this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf) {
                this.MaterialStockActionDetailIn.ListFilterExpression = 'OBJECTDEFID =\'58d34696-808e-47de-87e0-1f001d0928a7\'  AND  MKYSMALZEMEKODU IS NOT NULL';
                this.Supplier.Required = true;
                this.Supplier.BackColor = "#FFE3C6";
            }
            if (this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.ilac) {
                this.MaterialStockActionDetailIn.ListFilterExpression = 'OBJECTDEFID =\'65a2337c-bc3c-4c6b-9575-ad47fa7a9a89\'  AND  MKYSMALZEMEKODU IS NOT NULL';
                this.ITSButtonIsActive = true;
            }
            if (this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiCihaz)
                this.MaterialStockActionDetailIn.ListFilterExpression = 'OBJECTDEFID =\'f38f2111-0ee4-4b9f-9707-a63ac02d29f4\'  AND  MKYSMALZEMEKODU IS NOT NULL';
        }

        if (this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru != null) {
            if (this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru === MKYS_ETedarikTurEnum.stokFazlasiDevir) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = TasinirMalGirisTurEnum.stokFazlasiDevir;
            }
            if (this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru === MKYS_ETedarikTurEnum.bagliSaglikTsisisndenDevir) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = TasinirMalGirisTurEnum.bagliSaglikTesisindenDevir;
            }
            if (this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru === MKYS_ETedarikTurEnum.ihtiyacFazlasiDevir) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = TasinirMalGirisTurEnum.ihtiyacFazlasiDevir;
            }
            if (this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru === MKYS_ETedarikTurEnum.tedarikPaylasimDevirGiris) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = TasinirMalGirisTurEnum.tedarikPaylasimDevirGiris;
            }
            if (this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru === MKYS_ETedarikTurEnum.devirAlinan) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = TasinirMalGirisTurEnum.devirAlinan;
            }
            if (this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru === MKYS_ETedarikTurEnum.duzeltme) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = TasinirMalGirisTurEnum.duzeltme;
            }
            if (this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru === MKYS_ETedarikTurEnum.sgkTarafindanTedarikEdilenUrun) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = TasinirMalGirisTurEnum.sgkTarafindanTedarikEdilenUrun;
            }
        }


        for (let detIn of this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {
            let price: number = 0;
            if (detIn.Amount != null && detIn.UnitPrice != null) {
                if (detIn.Amount > 0 && detIn.UnitPrice > 0) {
                    price = detIn.Amount * detIn.UnitPrice;
                    detIn.Price = price;
                }
            }
        }







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
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        for (let detail of this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy) {
            if (detail.ExpirationDate === null || detail.ExpirationDate == Date.MinValue || detail.ExpirationDate == undefined) {
                if (detail.Material.ObjectDefID != ConsumableMaterialDefinition.ObjectDefID) {
                    throw new TTException(detail.Material.Name + " isimli malzemenin Son Kullanma tarihi boş geçilemez.");
                } else {
                    let mat: ConsumableMaterialDefinition = detail.Material as ConsumableMaterialDefinition;
                    if (mat.HasEstimatedTime == true) {
                        throw new TTException(detail.Material.Name + " isimli malzemenin Son Kullanma tarihi boş geçilemez.");
                    }
                }
            }
            if (detail.VatRate === null || detail.VatRate == undefined) {
                throw new TTException(detail.Material.Name + " isimli malzemenin KDV alanı geçilemez.");
            }
        }

        this._ViewModel.ChattelDocumentDetailsWithPurchaseGridList = this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy;
        this._ViewModel.PTSStockActionDetails = this._ChattelDocumentInputWithAccountancy.PTSStockActionDetails;
        this._ChattelDocumentInputWithAccountancy.PTSNumber = this.ItsPackageNo;
        this._ChattelDocumentInputWithAccountancy.IsPTSAction = this.ShowITSReceiveNotifications;
    }

    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() == PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            if (transDef.ToStateDefID != null) {
                if (transDef.ToStateDefID.valueOf() === ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.Completed.id) {
                    super.AfterContextSavedScript(transDef);
                    let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChattelDocumentInputWithAccountancy.ObjectID.toString());
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
                }
            }
        }
    }

    protected async PreScript() {
        super.PreScript();

        let isApproved: string = (await SystemParameterService.GetParameterValue('STOCKACTIONSTATENEWTOCOMPLETED', 'TRUE'));
        if (isApproved === 'TRUE') {
            this.DropStateButton(ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.Approved);
        } else {
            this.DropStateButton(ChattelDocumentInputWithAccountancy.ChattelDocumentInputWithAccountancyStates.Completed);
        }

        if (this._ChattelDocumentInputWithAccountancy.Store == null) {
            this._ChattelDocumentInputWithAccountancy.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }

        if ((<MainStoreDefinition>this._ChattelDocumentInputWithAccountancy.Store).MKYS_ButceTuru !== undefined) {
            if ((<MainStoreDefinition>this._ChattelDocumentInputWithAccountancy.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.donerSermaye) {
                let budgetObj: Guid = new Guid('3511171d-06ae-4434-ad44-3579ee616ecb');
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = budgetTypeDef;
            }
            if ((<MainStoreDefinition>this._ChattelDocumentInputWithAccountancy.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.genelButce) {
                let budgetObj: Guid = new Guid('57c410cc-afea-487a-8327-76e91a696a02');
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = budgetTypeDef;
            }
            this.BudgetTypeDefinition.ReadOnly = true;
        }



        // MaterialStockActionDetailIn.ListFilterExpression = "STOCKCARD.CREATEDSITE is null OR STOCKCARD.CREATEDSITE =" + ConnectionManager.GuidToString(Sites.SiteMerkezSagKom);
        /*let tPrice: number = await this.CalculateTotalPrice();
        this.txtTotalPrice.Text = tPrice.toString();*/

        /*if (this._ChattelDocumentInputWithAccountancy.Store instanceof MainStoreDefinition) {
            this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan = (<MainStoreDefinition>this._ChattelDocumentInputWithAccountancy.Store).GoodsAccountant.Name;
            this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID = (<MainStoreDefinition>this._ChattelDocumentInputWithAccountancy.Store).GoodsAccountant.ObjectID;
        }*/
        if(this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID == null){
            this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID = this.activeUserService.ActiveUserID;
            this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan = (<ResUser>this.activeUserService.ActiveUser.UserObject).Name;
        }
    }
    public async ChattelDocumentDetailsWithAccountancy_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, rowIndex, columnIndex);
    }

    private showStockActionInDetailModal(data: StockActionDetailIn): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'BaseStockActionDetailInForm';
            componentInfo.ModuleName = 'StokEvrenselModule';
            componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StokEvrenselModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M18564", "Malzeme Detayları");
            modalInfo.Width = 800;
            modalInfo.Height = 600;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public cellContentClicked(data: any) {
        let stockActionInDetail: StockActionDetailIn = data.Row.TTObject as StockActionDetailIn;
        if (stockActionInDetail.FixedAssetInDetails == null) {
            stockActionInDetail.FixedAssetInDetails = new Array<FixedAssetInDetail>();
        }

        this.showStockActionInDetailModal(stockActionInDetail).then(result => {
            let modalActionResult = result as ModalActionResult;
            if (modalActionResult.Result === DialogResult.OK) {
                let obj = result.Param as StockActionDetailIn;

            }
        });
    }

    ptsReadIsOk: boolean = false;
    titleGrid: string = "Taşınır Malın";
    ItsPackageNo: string = "";
    ShowITSReceiveNotifications: boolean = false;
    IsPatientSpecialCheck: boolean = true;
    incomingITSReceiptNotificationList: Array<PTSMaterial> = new Array<PTSMaterial>();
    incomingPTSStockCards: Array<StockCard> = new Array<StockCard>();
    newStockLevelType: StockLevelType;
    ptsStockActionDetailSource: Array<PTSStockActionDetail> = new Array<PTSStockActionDetail>();

    async checkBoxValuePTS_valueChanged(e) {
        var newValue = e.value;
        if (newValue == true) {
            this.ShowITSReceiveNotifications = true;
            this.IsPatientSpecialCheck = false;
            this.titleGrid = "PTS Giriş";
            this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = new Array<ChattelDocumentInputDetailWithAccountancy>();
            this._ChattelDocumentInputWithAccountancy.WaybillDate = null;
            this._ChattelDocumentInputWithAccountancy.Waybill = null;
            this.ptsReadIsOk = false;
        } else {
            this.ItsPackageNo = "";
            this.titleGrid = "Taşınır Malın";
            this.ShowITSReceiveNotifications = false;
            this.IsPatientSpecialCheck = true;
            this.incomingITSReceiptNotificationList = new Array<PTSMaterial>();
            this._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy = new Array<ChattelDocumentInputDetailWithAccountancy>();
            this._ChattelDocumentInputWithAccountancy.WaybillDate = null;
            this._ChattelDocumentInputWithAccountancy.Waybill = null;
            this.ptsReadIsOk = true;
        }
        this.CalculatePricesDelete();
    }

    public CalculatePricesDelete() {
        this.txtSalesTotal.Text = "0.00";
        this.txtTotalNotDiscount.Text = "0.00";
        this.txtTotalPrice.Text = "0.00";
    }


    public PTSMaterialPriceUpdate(event: any) {
        let data = <PTSMaterial>event.data;
        if (data.amount <= 0 || data.UnitPriceWithOutVat <= 0) {
            ServiceLocator.MessageService.showError('Miktar ve İndirimsiz Birim Fiyat sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }
        if (data.VatRate < 0) {
            ServiceLocator.MessageService.showError('KDV Oranı sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }

        if (data.amount != null && data.PTSStockActionDetail.VatRate != null && data.UnitPriceWithOutVat != null) {

            let miktar: number = data.amount;
            let birimfiyati: number = data.UnitPriceWithOutVat;
            let toplam: number = miktar * birimfiyati;
            let kdvOrani: number = data.PTSStockActionDetail.VatRate;
            let kdvBirimFiyati: number = birimfiyati + (birimfiyati * (kdvOrani / 100));
            let kdvliToplamFiyat: number = miktar * kdvBirimFiyati;
            let indirimOrani: number = 0;
            let toplamSatirFiyat: number = 0;
            if ((data.PTSStockActionDetail.DiscountRate != null)) {
                indirimOrani = data.PTSStockActionDetail.DiscountRate;
            }
            let indirimliBirimFiyat: number = kdvBirimFiyati - (kdvBirimFiyati * (indirimOrani / 100));
            let indirimliToplamFiyat: number = miktar * indirimliBirimFiyat;
            let toplamindirimTutati: number = kdvliToplamFiyat - indirimliToplamFiyat;
            data.UnitPriceWithInVat = Math.Round(kdvBirimFiyati, 6);
            data.PTSStockActionDetail.UnitPrice = Math.Round(indirimliBirimFiyat, 6);
            data.PTSStockActionDetail.DiscountAmount = Math.Round(toplamindirimTutati, 6);
            toplamSatirFiyat = indirimliBirimFiyat * miktar;
            data.price = Math.Round(toplamSatirFiyat, 6);
            data.UnitPrice = data.UnitPriceWithOutVat;


            data.PTSStockActionDetail.NotDiscountedUnitPrice = Math.Round(kdvBirimFiyati, 6);
            data.PTSStockActionDetail.TotalDiscountAmount = Math.Round(toplamindirimTutati, 6);
            data.PTSStockActionDetail.TotalPriceNotDiscount = Math.Round(kdvliToplamFiyat, 6);
        }
        /*
                for (let detail of data.PTSStockActionDetail.StockActionDetails) {
                    let purchaseDetail: ChattelDocumentInputDetailWithAccountancy = <ChattelDocumentInputDetailWithAccountancy>detail;
                    //purchaseDetail.UnitPriceWithOutVat = data.UnitPriceWithOutVat;
                    purchaseDetail.VatRate = data.VatRate;
                    purchaseDetail.DiscountRate = data.DiscountRate;
                    purchaseDetail.RetrievalYear = data.RetrievalYear;
                    purchaseDetail.ProductionDate = data.ProductionDate;
                    purchaseDetail.Amount = detail.Amount;
                    purchaseDetail.DiscountAmount  = data.DiscountAmount;
                    this.MaterialGridCellChanged(purchaseDetail);
                    }
        */

        this.CalculateFormTotalPriceForITS();
    }

    public CalculateFormTotalPriceForITS() {
        let prices: Array<number> = new Array<number>();
        let total: number = 0, salesTotal = 0, totalPrice = 0;
        prices.push(total);
        prices.push(salesTotal);
        prices.push(totalPrice);
        for (let data of this.chattelDocumentInputWithAccountancyNewFormViewModel.PTSMaterials) {
            if (data.UnitPriceWithOutVat == null || data.PTSStockActionDetail.VatRate == null)
                continue;
            prices[0] += data.amount * data.UnitPriceWithOutVat;
            prices[1] += data.amount * (data.UnitPriceWithOutVat + (data.UnitPriceWithOutVat * data.PTSStockActionDetail.VatRate / 100));
        }
        prices[2] = prices[0] - prices[1];
        this.txtTotalNotDiscount.Text = prices[0].toFixed(2);
        this.txtSalesTotal.Text = prices[1].toFixed(2);
        this.txtTotalPrice.Text = prices[1].toFixed(2);
    }

    public showLoadPanel = false;
    public LoadPanelMessage: string = "İşlem Yapılıyor Bekleyiniz.";
    async getItSForPackageClick() {
        this.showLoadPanel = true;
        if (String.isNullOrEmpty(this.ItsPackageNo) == false) {
            await this.getItsReceiptNotification();
            this.ptsReadIsOk = true;
        }
        else {
            ServiceLocator.MessageService.showError("Paket Numarası Girmeden İşleme Devam Edemessiniz!");
            this.showLoadPanel = false;
        }

    }

    async getItsReceiptNotification() {
        let that = this;
        //let sup: Supplier = new Supplier();
        let waybillDate: Date = new Date();
        let waybill: string;
        let inputDVO: PTSInputDVO = new PTSInputDVO();
        inputDVO.PTSID = this.ItsPackageNo.toString();
        inputDVO.stockAction = this._ChattelDocumentInputWithAccountancy;
        let apiUrlForInvoiceTerms: string = '/api/ChattelDocumentWithPurchaseService/GetItsReceiptNotification';
        this.httpService.post<PTSMaterialOutput>(apiUrlForInvoiceTerms, inputDVO).then(
            x => {
                that.incomingITSReceiptNotificationList = x.PTSMaterials;
                that.incomingPTSStockCards = x.StockCards;
                that.newStockLevelType = x.StockLevelType;
                that.chattelDocumentInputWithAccountancyNewFormViewModel.PTSMaterials = new Array<PTSMaterial>();
                that.chattelDocumentInputWithAccountancyNewFormViewModel.PTSMaterials = that.incomingITSReceiptNotificationList;
                for (let cht of that.incomingITSReceiptNotificationList) {
                    let newPTS: PTSStockActionDetail = new PTSStockActionDetail();
                    newPTS.Material = cht.material;
                    newPTS.Amount = cht.amount;
                    newPTS.LotNo = cht.lotNO;
                    newPTS.ExpirationDate = cht.expirationDate;
                    newPTS.ProductionDate = cht.ProductionDate;
                    newPTS.VatRate = cht.VatRate;
                    newPTS.DiscountRate = cht.DiscountRate;
                    newPTS.RetrievalYear = cht.RetrievalYear;
                    newPTS.StockActionDetails = new Array<ChattelDocumentInputDetailWithAccountancy>();
                    /*for (let chtDet of cht.serialNOList) {
                        let newRow: ChattelDocumentDetailWithPurchase = chtDet.chattelDocumentDetailWithPurchase;
                        that.addedPTStoChattelDetGrid(newPTS, chtDet.serialNo, chtDet.amount);
                    }*/
                    newPTS.StockAction = that._ChattelDocumentInputWithAccountancy;
                    cht.PTSStockActionDetail = newPTS;
                    that._ChattelDocumentInputWithAccountancy.PTSStockActionDetails.push(newPTS);
                    //sup = cht.supplier;
                    waybillDate = cht.DocumentRecordDate;
                    waybill = cht.DocumentRecordNo;
                }
                //that._ChattelDocumentWithPurchase.Supplier = sup;
                //that._ChattelDocumentWithPurchase.WaybillDate = waybillDate;
                //that._ChattelDocumentWithPurchase.Waybill = waybill;
                this.showLoadPanel = false;
            }
        ).catch(error => {
            //ServiceLocator.MessageService.showError("Hata : " + error);
            TTVisual.InfoBox.Alert(error);
            this.showLoadPanel = false;
            this.ptsReadIsOk = false;
        });
    }

    async addedPTStoChattelDetGrid(ptsDetail: PTSStockActionDetail, serialNo: string, amount: number) {
        let that = this;
        let newRow: ChattelDocumentInputDetailWithAccountancy = new ChattelDocumentInputDetailWithAccountancy();

        newRow.SerialNo = serialNo;
        newRow.LotNo = ptsDetail.LotNo;
        newRow.StockAction = that._ChattelDocumentInputWithAccountancy;
        newRow.Material = ptsDetail.Material;
        newRow.Amount = amount;
        let stockCardObj: Guid = <any>ptsDetail.Material['StockCard'];
        let stockCard: StockCard = this.incomingPTSStockCards.find(x => x.ObjectID === stockCardObj);

        //let stockCard: StockCard = await that.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
        newRow.Material.StockCard = stockCard;
        //if (that.stockLeveltypeArray.length == 0)
        //    that.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        that.selectedStockLevelType = this.newStockLevelType;
        newRow.StockLevelType = that.selectedStockLevelType;
        newRow.Status = StockActionDetailStatusEnum.New;
        newRow.ExpirationDate = ptsDetail.ExpirationDate;
        newRow.VatRate = ptsDetail.VatRate;
        ptsDetail.StockActionDetails.push(newRow);
        that._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.push(newRow);

    }

    document: UploadedDocument = new UploadedDocument();
    async readDocumentItSForPackageClick($event) {
        this.showLoadPanel = true;
        let that = this;
        // let sup: Supplier = new Supplier();
        let waybillDate: Date = new Date();
        let waybill: string;
        const file: File = $event.target.files[0];
        const fileReader: FileReader = new FileReader();
        if (file.size > 10000000) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13544", "Eklediğiniz dosyaların boyutu 10 Mb'dan fazla olamaz!"), MessageIconEnum.WarningMessage);
            return;
        }
        fileReader.onloadend = (e) => {
            that.document.FileName = file.name,
                that.document.File = fileReader.result;

            if (that.document.File !== undefined) {
                let inputDVO: XMLReadDocumentFile = new XMLReadDocumentFile();
                inputDVO.xmlFile = that.document.File.toString();
                inputDVO.xmlFileName = that.document.FileName;
                inputDVO.stockAction = that._ChattelDocumentInputWithAccountancy;
                let apiUrlForInvoiceTerms: string = '/api/ChattelDocumentWithPurchaseService/GetItsReceiptNotificationFileRead';
                this.httpService.post<PTSMaterialOutput>(apiUrlForInvoiceTerms, inputDVO).then(
                    x => {
                        that.incomingITSReceiptNotificationList = x.PTSMaterials;
                        that.incomingPTSStockCards = x.StockCards;
                        that.newStockLevelType = x.StockLevelType;
                        that.chattelDocumentInputWithAccountancyNewFormViewModel.PTSMaterials = new Array<PTSMaterial>();
                        that.chattelDocumentInputWithAccountancyNewFormViewModel.PTSMaterials = that.incomingITSReceiptNotificationList;
                        for (let cht of that.incomingITSReceiptNotificationList) {
                            let newPTS: PTSStockActionDetail = new PTSStockActionDetail();
                            newPTS.Material = cht.material;
                            newPTS.Amount = cht.amount;
                            newPTS.LotNo = cht.lotNO;
                            newPTS.ExpirationDate = cht.expirationDate;
                            newPTS.ProductionDate = cht.ProductionDate;
                            newPTS.VatRate = cht.VatRate;
                            newPTS.DiscountRate = cht.DiscountRate;
                            newPTS.RetrievalYear = cht.RetrievalYear;
                            newPTS.StockActionDetails = new Array<ChattelDocumentInputDetailWithAccountancy>();
                            /*for (let chtDet of cht.serialNOList) {
                                that.addedPTStoChattelDetGrid(newPTS, chtDet.serialNo, chtDet.amount);
                            }*/
                            newPTS.StockAction = that._ChattelDocumentInputWithAccountancy;
                            cht.PTSStockActionDetail = newPTS;
                            that._ChattelDocumentInputWithAccountancy.PTSStockActionDetails.push(newPTS);
                            // sup = cht.supplier;
                            // waybillDate = cht.DocumentRecordDate;
                            // waybill = cht.DocumentRecordNo;

                        }
                        //that._ChattelDocumentWithPurchase.Supplier = sup;
                        // that._ChattelDocumentWithPurchase.WaybillDate = waybillDate;
                        // that._ChattelDocumentWithPurchase.Waybill = waybill;
                    }
                ).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                    this.showLoadPanel = false;
                    this.ptsReadIsOk = false;
                });
                this.showLoadPanel = false;
            }
        };
        fileReader.readAsText(file);
        this.ptsReadIsOk = true;
    }



    async initNewRow(data: any) {
    }

    async rowInserting(data: any) {
    }





    // *****Method declarations end *****

    ChattelDocumentDetailsWithAccountancy_CellValueChangedEmitted(data: any) {
        if (data && this.ChattelDocumentDetailsWithAccountancy_CellValueChanged && data.Row && data.Column) {
            this.ChattelDocumentDetailsWithAccountancy_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentInputWithAccountancy();
        this.chattelDocumentInputWithAccountancyNewFormViewModel = new ChattelDocumentInputWithAccountancyNewFormViewModel();
        this._ViewModel = this.chattelDocumentInputWithAccountancyNewFormViewModel;
        this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy = this._TTObject as ChattelDocumentInputWithAccountancy;
        this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.Store = new Store();
        this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.Accountancy = new Accountancy();
        this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy =
            new Array<ChattelDocumentInputDetailWithAccountancy>();
        this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.PTSStockActionDetails = new Array<PTSStockActionDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.chattelDocumentInputWithAccountancyNewFormViewModel = this._ViewModel as ChattelDocumentInputWithAccountancyNewFormViewModel;
        that._TTObject = this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy;
        if (this.chattelDocumentInputWithAccountancyNewFormViewModel == null)
            this.chattelDocumentInputWithAccountancyNewFormViewModel = new ChattelDocumentInputWithAccountancyNewFormViewModel();
        if (this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy == null)
            this.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy = new ChattelDocumentInputWithAccountancy();
        let budgetTypeDefinitionObjectID = that.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy['BudgetTypeDefinition'];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.chattelDocumentInputWithAccountancyNewFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.chattelDocumentInputWithAccountancyNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.Store = store;
            }
        }
        let accountancyObjectID = that.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy['Accountancy'];
        if (accountancyObjectID != null && (typeof accountancyObjectID === 'string')) {
            let accountancy = that.chattelDocumentInputWithAccountancyNewFormViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.Accountancy = accountancy;
            }
        }
        that.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy =
            that.chattelDocumentInputWithAccountancyNewFormViewModel.ChattelDocumentDetailsWithAccountancyGridList;
        for (let detailItem of that.chattelDocumentInputWithAccountancyNewFormViewModel.ChattelDocumentDetailsWithAccountancyGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.chattelDocumentInputWithAccountancyNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.chattelDocumentInputWithAccountancyNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.chattelDocumentInputWithAccountancyNewFormViewModel.DistributionTypeDefinitions.find(o =>
                                    o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem['StockLevelType'];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.chattelDocumentInputWithAccountancyNewFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
            let SupplierID = detailItem['Supplier'];
            if (SupplierID != null && (typeof SupplierID === 'string')) {
                let Supplier = that.chattelDocumentInputWithAccountancyNewFormViewModel.Suppliers.find(o => o.ObjectID.toString() === SupplierID.toString());
                if (Supplier) {
                    detailItem.Supplier = Supplier;
                }
            }
        }
        that.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.PTSStockActionDetails = that.chattelDocumentInputWithAccountancyNewFormViewModel.PTSStockActionDetails;
        for (let detailItem of that.chattelDocumentInputWithAccountancyNewFormViewModel.PTSStockActionDetails) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.chattelDocumentInputWithAccountancyNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.chattelDocumentInputWithAccountancyNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                            material.NATOStockNO = stockCard.NATOStockNO;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.chattelDocumentInputWithAccountancyNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }






        that.chattelDocumentInputWithAccountancyNewFormViewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails =
            that.chattelDocumentInputWithAccountancyNewFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentInputWithAccountancyNewFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.chattelDocumentInputWithAccountancyNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }


    }

    async ngOnInit() {
        let that = this;
        await this.load(ChattelDocumentInputWithAccountancyNewFormViewModel);
        if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = 'Taşınır Mal Giriş ( Yeni )';
        this.changeDetectorRef.detectChanges();

    }


    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Accountancy !== event) {
                this._ChattelDocumentInputWithAccountancy.Accountancy = event;
                this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden = this._ChattelDocumentInputWithAccountancy.Accountancy.Name;
            }
        }
        this.Accountancy_SelectedObjectChanged();
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition !== event) {
                this._ChattelDocumentInputWithAccountancy.BudgetTypeDefinition = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Description !== event) {
                this._ChattelDocumentInputWithAccountancy.Description = event;
            }
        }
    }

    public oninputWithAccountancyTypeChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType !== event) {
                this._ChattelDocumentInputWithAccountancy.inputWithAccountancyType = event;
            }
        }
    }

    public onMKYS_EAlimYontemiChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi !== event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_EAlimYontemi = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup !== event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru !== event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_ETedarikTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan !== event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden !== event) {
                this._ChattelDocumentInputWithAccountancy.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.StockActionID !== event) {
                this._ChattelDocumentInputWithAccountancy.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Store !== event) {
                this._ChattelDocumentInputWithAccountancy.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.TransactionDate !== event) {
                this._ChattelDocumentInputWithAccountancy.TransactionDate = event;
            }
        }
    }

    public onWaybillChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.Waybill !== event) {
                this._ChattelDocumentInputWithAccountancy.Waybill = event;
            }
        }
    }

    public onWaybillDateChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentInputWithAccountancy != null && this._ChattelDocumentInputWithAccountancy.WaybillDate !== event) {
                this._ChattelDocumentInputWithAccountancy.WaybillDate = event;
            }
        }
    }

    //#region dx-data-grid çevirme





    //#endregion

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_EMalzemeGrup, 'Value', this.__ttObject, 'MKYS_EMalzemeGrup');
        redirectProperty(this.MKYS_ETedarikTuru, 'Value', this.__ttObject, 'MKYS_ETedarikTuru');
        redirectProperty(this.MKYS_EAlimYontemi, 'Value', this.__ttObject, 'MKYS_EAlimYontemi');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
        redirectProperty(this.inputWithAccountancyType, 'Value', this.__ttObject, 'inputWithAccountancyType');
        redirectProperty(this.Waybill, 'Text', this.__ttObject, 'Waybill');
        redirectProperty(this.WaybillDate, 'Value', this.__ttObject, 'WaybillDate');
    }

    public initFormControls(): void {
        this.Waybill = new TTButtonTextBox();
        this.Waybill.Name = 'Waybill';
        this.Waybill.TabIndex = 132;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = '#F0F0F0';
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = 'txtTotalPrice';
        this.txtTotalPrice.TabIndex = 124;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;

        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = 'labelWaybillDate';
        this.labelWaybillDate.TabIndex = 135;

        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Short;
        this.WaybillDate.Name = 'WaybillDate';
        this.WaybillDate.TabIndex = 134;

        this.labelWaybill = new TTVisual.TTLabel();
        this.labelWaybill.Text = i18n("M16572", "İrsaliye Numarası");
        this.labelWaybill.Name = 'labelWaybill';
        this.labelWaybill.TabIndex = 133;

        this.labelinputWithAccountancyType = new TTVisual.TTLabel();
        this.labelinputWithAccountancyType.Text = i18n("M14804", "Giriş Türü");
        this.labelinputWithAccountancyType.Name = 'labelinputWithAccountancyType';
        this.labelinputWithAccountancyType.TabIndex = 131;

        this.inputWithAccountancyType = new TTVisual.TTEnumComboBox();
        this.inputWithAccountancyType.DataTypeName = 'TasinirMalGirisTurEnum';
        this.inputWithAccountancyType.Name = 'inputWithAccountancyType';
        this.inputWithAccountancyType.TabIndex = 130;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = 'labelBudgetTypeDefinition';
        this.labelBudgetTypeDefinition.TabIndex = 129;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = 'BudgetTypeDefinition';
        this.BudgetTypeDefinition.TabIndex = 128;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = '10%';
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = '20%';

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ReadOnly = false;
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 9;


        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14807", "Giriş Yapılan Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 127;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 118;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreDefinitionList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 126;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M14220", "Fatura Tutarı");
        this.ttlabel2.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 125;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = 'Description';
        this.Description.TabIndex = 0;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = 'Geldiği Yer';
        this.labelAccountancy.Name = 'labelAccountancy';
        this.labelAccountancy.TabIndex = 122;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 0;

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ReadOnly = false;
        this.Accountancy.ListDefName = 'AccountancyList';
        this.Accountancy.Name = 'Accountancy';
        this.Accountancy.TabIndex = 121;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = 'ChattelDocumentTabcontrol';
        this.ChattelDocumentTabcontrol.TabIndex = 120;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 115;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = 'Taşınır Malın';
        this.ChattelDocumentDetailTabpage.Name = 'ChattelDocumentDetailTabpage';

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 1;

        this.ChattelDocumentDetailsWithAccountancy = new TTVisual.TTGrid();
        this.ChattelDocumentDetailsWithAccountancy.Required = true;
        this.ChattelDocumentDetailsWithAccountancy.Name = 'ChattelDocumentDetailsWithAccountancy';
        this.ChattelDocumentDetailsWithAccountancy.TabIndex = 0;
        this.ChattelDocumentDetailsWithAccountancy.Height = 350;
        this.ChattelDocumentDetailsWithAccountancy.AllowUserToDeleteRows = true;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 113;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.ReadOnly = true;
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = 'DescriptionAndSignTabControl';
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = 'MaterialListDefinition';
        this.MaterialStockActionDetailIn.AutoCompleteDialogHeight = '60%';
        this.MaterialStockActionDetailIn.AutoCompleteDialogWidth = '90%';
        this.MaterialStockActionDetailIn.DataMember = 'Material';
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetailIn.Name = 'MaterialStockActionDetailIn';
        this.MaterialStockActionDetailIn.Width = 450;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = 'SignTabpage';

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Material.Barcode';
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = 'StockActionSignDetails';
        this.StockActionSignDetails.TabIndex = 0;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = 'SignUserTypeEnum';
        this.SignUserType.DataMember = 'SignUserType';
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = 'SignUserType';
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.SentAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DataMember = 'SentAmount';
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Format = '#,###.####';
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 4;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M14894", "Gönderilen Mik.");
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Name = 'SentAmountChattelDocumentInputDetailWithAccountancy';
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Width = 130;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.IsNumeric = true;
        this.SentAmountChattelDocumentInputDetailWithAccountancy.Visible = false;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = 'UserListDefinition';
        this.SignUser.DataMember = 'SignUser';
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = 'SignUser';
        this.SignUser.Width = 400;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = 'Amount';
        this.AmountStockActionDetailIn.Format = '#,###.####';
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 5;
        this.AmountStockActionDetailIn.HeaderText = i18n("M19030", "Miktar");
        this.AmountStockActionDetailIn.Name = 'AmountStockActionDetailIn';
        this.AmountStockActionDetailIn.Width = 120;
        this.AmountStockActionDetailIn.IsNumeric = true;


        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = false;
        this.ValueAddedTax.Width = 100;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = 'IsDeputy';
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = 'IsDeputy';
        this.IsDeputy.Width = 50;

        this.NotDiscountedUnitPrice = new TTVisual.TTTextBoxColumn();
        this.NotDiscountedUnitPrice.DataMember = 'NotDiscountedUnitPrice';
        this.NotDiscountedUnitPrice.DisplayIndex = 6;
        this.NotDiscountedUnitPrice.HeaderText = i18n("M16509", "İndirimsiz Birim Fiyatı");
        this.NotDiscountedUnitPrice.Name = 'NotDiscountedUnitPrice';
        this.NotDiscountedUnitPrice.Width = 120;
        this.NotDiscountedUnitPrice.IsNumeric = true;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 111;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = 'UnitPrice';
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 7;
        this.UnitPriceStockActionDetailIn.HeaderText = i18n("M11866", "Birim Mal. Bedeli");
        this.UnitPriceStockActionDetailIn.Name = 'UnitPriceStockActionDetailIn';
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 120;
        this.UnitPriceStockActionDetailIn.IsNumeric = true;

        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = 'DiscountRate';
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = i18n("M16491", "İndirim Oranı");
        this.MKYS_IndirimOranı.Name = 'MKYS_IndirimOranı';
        this.MKYS_IndirimOranı.Width = 120;
        this.MKYS_IndirimOranı.IsNumeric = true;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = 'DiscountAmount';
        this.MKYS_IndirimTutari.DisplayIndex = 9;
        this.MKYS_IndirimTutari.HeaderText = i18n("M16501", "İndirim Tutarı");
        this.MKYS_IndirimTutari.Name = 'MKYS_IndirimTutari';
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Visible = false;
        this.MKYS_IndirimTutari.Width = 120;
        this.MKYS_IndirimTutari.IsNumeric = true;

        this.TotalPriceNotDiscount = new TTVisual.TTTextBoxColumn();
        this.TotalPriceNotDiscount.DataMember = 'TotalPriceNotDiscount';
        this.TotalPriceNotDiscount.DisplayIndex = 10;
        this.TotalPriceNotDiscount.HeaderText = 'İnd.siz Top. Fiyat';
        this.TotalPriceNotDiscount.Name = 'TotalPriceNotDiscount';
        this.TotalPriceNotDiscount.ReadOnly = true;
        this.TotalPriceNotDiscount.Width = 120;
        this.TotalPriceNotDiscount.IsNumeric = true;


        this.TotalDiscountAmount = new TTVisual.TTTextBoxColumn();
        this.TotalDiscountAmount.DataMember = 'TotalDiscountAmount';
        this.TotalDiscountAmount.DisplayIndex = 11;
        this.TotalDiscountAmount.HeaderText = i18n("M23475", "Top.m İnd. Tutarı");
        this.TotalDiscountAmount.Name = 'TotalDiscountAmount';
        this.TotalDiscountAmount.ReadOnly = true;
        this.TotalDiscountAmount.Width = 120;
        this.TotalDiscountAmount.IsNumeric = true;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = 'Price';
        this.TotalPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.TotalPrice.DisplayIndex = 12;
        this.TotalPrice.HeaderText = i18n("M23613", "Tutarı");
        this.TotalPrice.Name = 'TotalPrice';
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 120;
        this.TotalPrice.IsNumeric = true;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = 'LotNo';
        this.LotNo.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.LotNo.DisplayIndex = 13;
        this.LotNo.HeaderText = 'Lot No.';
        this.LotNo.Name = 'LotNo';
        this.LotNo.Width = 120;

        this.ExpirationDateStockActionDetailIn = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateStockActionDetailIn.Format = DateTimePickerFormat.Short;
        this.ExpirationDateStockActionDetailIn.CustomFormat = 'dd/MM/yyyy';
        this.ExpirationDateStockActionDetailIn.DataMember = 'ExpirationDate';
        this.ExpirationDateStockActionDetailIn.DisplayIndex = 14;
        this.ExpirationDateStockActionDetailIn.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDateStockActionDetailIn.Name = 'ExpirationDateStockActionDetailIn';
        this.ExpirationDateStockActionDetailIn.Width = 180;

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = 'StockLevelTypeList';
        this.StockLevelTypeStockActionDetailIn.DataMember = 'StockLevelType';
        this.StockLevelTypeStockActionDetailIn.Required = true;
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 15;
        this.StockLevelTypeStockActionDetailIn.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeStockActionDetailIn.Name = 'StockLevelTypeStockActionDetailIn';
        this.StockLevelTypeStockActionDetailIn.Width = 140;

        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DataMember = 'ConflictSubject';
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.DisplayIndex = 16;
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M23820", "Uyuşmazlık");
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Name = 'ConflictSubjectChattelDocumentInputDetailWithAccountancy';
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Width = 120;
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.IsNumeric = true;
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy.Visible = false;

        this.StatusStockActionDetailIn = new TTVisual.TTEnumComboBoxColumn();
        this.StatusStockActionDetailIn.DataTypeName = 'StockActionDetailStatusEnum';
        this.StatusStockActionDetailIn.DataMember = 'ChattelDocumentInputDetailWithAccountancy.Status';
        this.StatusStockActionDetailIn.DisplayIndex = 17;
        this.StatusStockActionDetailIn.HeaderText = 'Durum';
        this.StatusStockActionDetailIn.Name = 'StatusStockActionDetailIn';
        this.StatusStockActionDetailIn.Visible = false;
        this.StatusStockActionDetailIn.Width = 80;

        this.MKYS_EdinimYili = new TTVisual.TTTextBoxColumn();
        this.MKYS_EdinimYili.DataMember = 'RetrievalYear';
        this.MKYS_EdinimYili.DisplayIndex = 18;
        this.MKYS_EdinimYili.HeaderText = i18n("M13475", "Edinim Yılı");
        this.MKYS_EdinimYili.Name = 'MKYS_EdinimYili';
        this.MKYS_EdinimYili.Width = 100;

        this.MKYS_UretimTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MKYS_UretimTarihi.DataMember = 'ProductionDate';
        this.MKYS_UretimTarihi.DisplayIndex = 19;
        this.MKYS_UretimTarihi.HeaderText = i18n("M23966", "Üretim Tarihi");
        this.MKYS_UretimTarihi.Name = 'MKYS_UretimTarihi';
        this.MKYS_UretimTarihi.Width = 180;

        this.ConflictAmountChattelDocumentInputDetailWithAccountancy = new TTVisual.TTTextBoxColumn();
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DataMember = 'ChattelDocumentInputDetailWithAccountancy.ConflictAmount';
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Format = '#,###.####';
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.DisplayIndex = 20;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.HeaderText = i18n("M23822", "Uyuşmazlık Miktarı");
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Name = 'ConflictAmountChattelDocumentInputDetailWithAccountancy';
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.ReadOnly = true;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Visible = false;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.Width = 100;
        this.ConflictAmountChattelDocumentInputDetailWithAccountancy.IsNumeric = true;

        this.txtSalesTotal = new TTVisual.TTTextBox();
        this.txtSalesTotal.BackColor = '#F0F0F0';
        this.txtSalesTotal.ReadOnly = true;
        this.txtSalesTotal.Name = 'txtSalesTotal';
        this.txtSalesTotal.TabIndex = 124;


        this.txtTotalNotDiscount = new TTVisual.TTTextBox();
        this.txtTotalNotDiscount.BackColor = '#F0F0F0';
        this.txtTotalNotDiscount.ReadOnly = true;
        this.txtTotalNotDiscount.Name = 'txtTotalNotDiscount';
        this.txtTotalNotDiscount.TabIndex = 124;


        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16501", "İndirim Tutarı");
        this.ttlabel2.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 125;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M23526", "Toplam Tutar");
        this.ttlabel3.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel3.Name = 'ttlabel3';
        this.ttlabel3.TabIndex = 125;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M23526", "Toplam Tutar");
        this.ttlabel4.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel4.Name = 'ttlabel4';
        this.ttlabel4.TabIndex = 125;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = i18n("M22969", "Tedarik Türü");
        this.labelMKYS_ETedarikTuru.Name = 'labelMKYS_ETedarikTuru';
        this.labelMKYS_ETedarikTuru.TabIndex = 14;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = 'MKYS_ETedarikTurEnum';
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = '#FFE3C6';
        this.MKYS_ETedarikTuru.Name = 'MKYS_ETedarikTuru';
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = 'MKYS_EMalzemeGrupEnum';
        this.MKYS_EMalzemeGrup.BackColor = '#F0F0F0';
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = 'MKYS_EMalzemeGrup';
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = 'labelMKYS_EMalzemeGrup';
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.MKYS_EAlimYontemi = new TTVisual.TTEnumComboBox();
        this.MKYS_EAlimYontemi.DataTypeName = 'MKYS_EAlimYontemiEnum';
        this.MKYS_EAlimYontemi.Required = true;
        this.MKYS_EAlimYontemi.BackColor = '#FFE3C6';
        this.MKYS_EAlimYontemi.Name = 'MKYS_EAlimYontemi';
        this.MKYS_EAlimYontemi.TabIndex = 19;

        this.labelMKYS_EAlimYontemi = new TTVisual.TTLabel();
        this.labelMKYS_EAlimYontemi.Text = i18n("M10699", "Alım Yöntemi");
        this.labelMKYS_EAlimYontemi.Name = 'labelMKYS_EAlimYontemi';
        this.labelMKYS_EAlimYontemi.TabIndex = 18;

        this.GetWaybill = new TTButtonTextBox();
        this.GetWaybill.Text = i18n("M16570", "İrsaliye Getir");
        this.GetWaybill.Name = 'GetWaybill';
        this.GetWaybill.TabIndex = 147;


        this.ChattelDocumentDetailsWithAccountancyColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType,
        this.SentAmountChattelDocumentInputDetailWithAccountancy, this.AmountStockActionDetailIn, this.NotDiscountedUnitPrice, this.ValueAddedTax,
        this.UnitPriceStockActionDetailIn, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari, this.TotalPriceNotDiscount, this.TotalDiscountAmount,
        this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn,
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy, this.StatusStockActionDetailIn, this.MKYS_EdinimYili,
        this.MKYS_UretimTarihi, this.ConflictAmountChattelDocumentInputDetailWithAccountancy];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentDetailTabpage];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithAccountancy];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.Waybill, this.TTTeslimEdenButon, this.txtTotalPrice, this.TTTeslimAlanButon, this.labelWaybillDate,
        this.labelMKYS_TeslimEden, this.WaybillDate, this.MKYS_TeslimEden, this.labelWaybill, this.MKYS_TeslimAlan,
        this.labelinputWithAccountancyType, this.Description, this.inputWithAccountancyType, this.StockActionID, this.labelBudgetTypeDefinition,
        this.labelMKYS_TeslimAlan, this.BudgetTypeDefinition, this.labelTransactionDate, this.labelStore, this.TransactionDate, this.Store,
        this.labelStockActionID, this.ttlabel2, this.DescriptionAndSignTabControl, this.labelAccountancy, this.SignTabpage, this.Accountancy,
        this.StockActionSignDetails, this.ChattelDocumentTabcontrol, this.SignUserType, this.ChattelDocumentDetailTabpage, this.SignUser,
        this.ChattelDocumentDetailsWithAccountancy, this.IsDeputy, this.Detail, this.ttlabel1, this.MaterialStockActionDetailIn, this.Barcode,
        this.DistributionType, this.SentAmountChattelDocumentInputDetailWithAccountancy, this.AmountStockActionDetailIn, this.NotDiscountedUnitPrice,
        this.UnitPriceStockActionDetailIn, this.MKYS_IndirimOranı, this.MKYS_IndirimTutari, this.TotalPriceNotDiscount, this.TotalDiscountAmount,
        this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn,
        this.ConflictSubjectChattelDocumentInputDetailWithAccountancy, this.StatusStockActionDetailIn, this.MKYS_EdinimYili,
        this.MKYS_UretimTarihi, this.ConflictAmountChattelDocumentInputDetailWithAccountancy, this.txtSalesTotal, this.txtTotalNotDiscount,
        this.ttlabel3, this.ttlabel4, this.labelMKYS_ETedarikTuru, this.MKYS_ETedarikTuru, this.MKYS_EMalzemeGrup, this.labelMKYS_EMalzemeGrup,
        this.MKYS_EAlimYontemi, this.labelMKYS_EAlimYontemi, this.GetWaybill];

    }


}
