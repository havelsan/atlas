//$8DE847EA
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { ChattelDocumentWithPurchaseNewFormViewModel } from './ChattelDocumentWithPurchaseNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { MKYS_EButceTurEnum, InPatientPhysicianApplication, DocumentTransactionTypeEnum, UploadedDocument, PTSStockActionDetail, StockLevelType, SignUserTypeEnum, MKYS_EAlimYontemiEnum, ResUser, CommisionTypeEnum, ConsumableMaterialDefinition, DrugDefinition, TransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseChattelDocumentWithPurchaseForm, UTSBatchGridDataType, PTSMaterial, XMLReadDocumentFile, PTSMaterialOutput, PTSInputDVO } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentWithPurchaseForm";
import { ChattelDocumentDetailWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentDistribution } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EMalzemeGrupEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ETedarikTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { OrderDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PurchaseOrder } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockAction } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { TmpOrderedDetail } from 'NebulaClient/Model/AtlasClientModel';
import { TmpOrderedSupplier } from 'NebulaClient/Model/AtlasClientModel';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObject } from 'NebulaClient/StorageManager/InstanceManagement/TTObject';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { StockLevelTypeService } from "ObjectClassService/StockLevelTypeService";
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ChattelDocumentWithPurchaseService, GetWaybillForInputDetailDocument_Output } from "ObjectClassService/ChattelDocumentWithPurchaseService";
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { MaterialService } from 'app/NebulaClient/Services/ObjectService/MaterialService';
import { SystemParameterService } from 'ObjectClassService/SystemParameterService';
import { StockActionService, GetInPatientPhysicianApplications_Output } from 'NebulaClient/Services/ObjectService/StockActionService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import Dictionary from 'app/NebulaClient/System/Collections/Dictionaries/Dictionary';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { StockCardType } from 'app/Logistic/Models/LogisticAddAndUpdateViewModel';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { CommisionDefinitionInputDTO } from 'app/Logistic/Views/LogisticDefinitionComponents/CommisionDefinitionComponent';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { LogisticDocumentUploadFormInput } from 'app/Logistic/Views/LogiscticDocumentComponents/LogisticPatientDocumentUploadForm';
import { MaterialSelectorInput, NewMaterialService } from 'app/Logistic/Views/NewMaterialSelectComponent';


@Component({
    selector: 'ChattelDocumentWithPurchaseNewForm',
    templateUrl: './ChattelDocumentWithPurchaseNewForm.html',
    providers: [MessageService]
})
export class ChattelDocumentWithPurchaseNewForm extends BaseChattelDocumentWithPurchaseForm implements OnInit {
    AvailableOrdersTab: TTVisual.ITTTabPage;
    chkFreeEntry: TTVisual.ITTCheckBox;
    cmdTransfer: TTVisual.ITTButton;
    datagridviewcolumn1: TTVisual.ITTCheckBoxColumn;
    datagridviewcolumn2: TTVisual.ITTTextBoxColumn;
    firmdef_ttbutton: TTVisual.ITTButton;
    OrderedDetails: TTVisual.ITTGrid;
    OrderedSuppliersGrid: TTVisual.ITTGrid;
    OrderNo: TTVisual.ITTTextBoxColumn;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlistboxcolumn1: TTVisual.ITTListBoxColumn;
    ttlistboxcolumn2: TTVisual.ITTListBoxColumn;
    tttextboxcolumn2: TTVisual.ITTTextBoxColumn;
    public ChattelDocumentDetailsWithPurchaseColumns = [];
    public DemandAmountsGridColumns = [];
    public OrderedDetailsColumns = [];
    public OrderedSuppliersGridColumns = [];
    public StockActionSignDetailsColumns = [];
    public IsPatientSpecial: Boolean = false;
    public PatientSpecialKey: string;
    public findPatient: boolean = false;

    public ITSButtonIsActive: boolean = false;
    public UTSButtonIsActive: boolean = true;
    public useCommision: boolean = false;
    public MaterialInput: MaterialSelectorInput = new MaterialSelectorInput();


    public chattelDocumentWithPurchaseNewFormViewModel: ChattelDocumentWithPurchaseNewFormViewModel = new ChattelDocumentWithPurchaseNewFormViewModel();
    public get _ChattelDocumentWithPurchase(): ChattelDocumentWithPurchase {
        return this._TTObject as ChattelDocumentWithPurchase;
    }
    private ChattelDocumentWithPurchaseNewForm_DocumentUrl: string = '/api/ChattelDocumentWithPurchaseService/ChattelDocumentWithPurchaseNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected objectContextService: ObjectContextService,
        private http: NeHttpService,
        private reportService: AtlasReportService,
        private changeDetectorRef: ChangeDetectorRef,
        private activeUserService: IActiveUserService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone, objectContextService);
        this._DocumentServiceUrl = this.ChattelDocumentWithPurchaseNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    contentReady(event: any) {
        event.component.columnOption("command:edit", "visibleIndex", -1);
    }


    private async chkFreeEntry_CheckedChanged(): Promise<void> {
        await this.controlFreeEnty();
    }
    public async controlFreeEnty() {
        if (<boolean>this.chkFreeEntry.Value) {
            this.ConclusionNumber.ReadOnly = false;
            this.ConclusionDateTime.ReadOnly = false;
            this.Supplier.ReadOnly = false;
            this.MaterialStockActionDetailIn.ReadOnly = false;
            this.AmountStockActionDetailIn.ReadOnly = false;
            this.UnitPriceStockActionDetailIn.ReadOnly = false;
            this.ValueAddedTax.ReadOnly = false;
            this.Supplier.BackColor = "#FFE3C6";
            this.Store.BackColor = "#F0F0F0";
            this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = true;
            this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = true;

        }
        else {
            this.ConclusionNumber.ReadOnly = true;
            this.ConclusionDateTime.ReadOnly = true;
            this.Supplier.ReadOnly = true;
            this.MaterialStockActionDetailIn.ReadOnly = true;
            this.AmountStockActionDetailIn.ReadOnly = true;
            this.UnitPriceStockActionDetailIn.ReadOnly = true;
            this.ValueAddedTax.ReadOnly = true;
            this.ConclusionDateTime.BackColor = "#F0F0F0";
            this.ConclusionNumber.BackColor = "#F0F0F0";
            this.Supplier.BackColor = "#F0F0F0";
            this.Store.BackColor = "#F0F0F0";
            this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
            this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = false;
        }
    }

    covidCheck(value) {
        if (value.value == true)
            this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.covid19Satinalma;
        else
            this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.satinalma;

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
            if (selectedInApp != null) {
                if (selectedInApp.InvoiceControl == false) {
                    this._ChattelDocumentWithPurchase.InPatientPhysicianApplication = selectedInApp.InPatientPhysicianApplication;
                    this.PatientSpecialKey = selectedInApp.PatientInfo;
                    this._ChattelDocumentWithPurchase.Description = selectedInApp.Description;
                    this.findPatient = true;
                    //this.Description.Enabled = false;
                } else {
                    TTVisual.InfoBox.Alert(selectedInApp.Description);
                }
            }
        }
    }

    public async addLogisticPatientDocument() {
        if (this._ChattelDocumentWithPurchase.InPatientPhysicianApplication != null) {
            let input: LogisticDocumentUploadFormInput = await StockActionService.GetLogisticPatientDocumentInputDVO(this._ChattelDocumentWithPurchase.InPatientPhysicianApplication.ObjectID);
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

    private async cmdTransfer_Click(): Promise<void> {
        if (this._ChattelDocumentWithPurchase.TmpOrderedDetails.length === 0)
            return;
        let supp: Supplier = null;
        let po: PurchaseOrder = null;
        let totalPrice: number = 0;
        for (let tod of this._ChattelDocumentWithPurchase.TmpOrderedDetails) {
            if (po === null)
                po = tod.PurchaseOrderDetail.PurchaseOrder;
            let cdm: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase(this._ChattelDocumentWithPurchase.ObjectContext);
            cdm.StockAction = <StockAction>this._ChattelDocumentWithPurchase;
            cdm.Amount = tod.PurchaseOrderDetail.Amount;
            cdm.Material = tod.PurchaseOrderDetail.ContractDetail.Material;
            cdm.UnitPrice = tod.PurchaseOrderDetail.ContractDetail.UnitPrice;
            supp = tod.PurchaseOrderDetail.PurchaseOrder.Supplier;
            totalPrice += Convert.ToDouble(cdm.Amount) * Convert.ToDouble(cdm.UnitPrice);
            for (let pod of po.PurchaseOrderDetails) {
                for (let dd of pod.PurchaseProjectDetail.DemandDetails) {
                    let cdd: ChattelDocumentDistribution = new ChattelDocumentDistribution(this._ChattelDocumentWithPurchase.ObjectContext);
                    cdd.ChattelDocumentWithPurchase = this._ChattelDocumentWithPurchase;
                    cdd.DemandDetail = dd;
                    cdd.ChattelDocDetailWithPurchase = cdm;
                }
            }
        }
        if (po === null)
            throw new TTException(i18n("M13591", "Eksik Karar yada Sözleşme Numarası tespit edildi."));
        else {
            this.Supplier.SelectedObject = <TTObject>supp;
            this._ChattelDocumentWithPurchase.ConclusionNumber = po.Contract.ConclusionNo;
            this._ChattelDocumentWithPurchase.ConclusionDateTime = po.PurchaseProject.ConclusionApproveDate;
            this._ChattelDocumentWithPurchase.ContractNumber = po.Contract.ContractNo;
            this._ChattelDocumentWithPurchase.ContractDateTime = po.Contract.ContractDate;
        }
        this._ChattelDocumentWithPurchase.TotalPrice = totalPrice;
        this._ChattelDocumentWithPurchase.GrandTotal = totalPrice;
        this.cmdTransfer.Enabled = false;
    }
    private async firmdef_ttbutton_Click(): Promise<void> {

    }
    private async OrderedSuppliersGrid_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.OrderedSuppliersGrid.CurrentCell === null)
            return;
        let tos: TmpOrderedSupplier = <TmpOrderedSupplier>this.OrderedSuppliersGrid.CurrentCell.OwningRow.TTObject;
        for (let pod of tos.PurchaseOrder.PurchaseOrderDetails) {
            if (pod.Status === OrderDetailStatusEnum.KurusluKesilecek) {
                let tod: TmpOrderedDetail = new TmpOrderedDetail(this._ChattelDocumentWithPurchase.ObjectContext);
                tod.ChattelDocumentWithPurchase = this._ChattelDocumentWithPurchase;
                tod.PurchaseOrderDetail = pod;
            }
        }
    }
    private async saveFormContext(ttObject: TTObject, isContextSaved: boolean): Promise<void> {
        if (ttObject === null)
            return;
        ttObject.ObjectContext.Save();
        isContextSaved = true;
    }
    protected async BarcodeRead(value: string): Promise<void> {
        /* super.BarcodeRead(value);
         let material: Material = null;
         let materials: Array<any> = this._ChattelDocumentWithPurchase.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + value + "'");
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
             let retAmount: string = TTVisual.InputForm.GetText("Miktar Bilgisini Giriniz.");
             let amount: Currency = 0;
             if (String.isNullOrEmpty(retAmount) === false) {
                 if (CurrencyType.TryConvertFrom(retAmount, false, amount) === false)
                     throw new TTException((await SystemMessageService.GetMessageV3(1192, [retAmount.toString()])));
             }
             let unitPrice: Currency = 0;
             let retUnitPrice: string = TTVisual.InputForm.GetText("Birim Maliyet Bedelini Giriniz");
             if (String.isNullOrEmpty(retUnitPrice) === false) {
                 if (CurrencyType.TryConvertFrom(retUnitPrice, false, unitPrice) === false)
                     throw new TTException((await SystemMessageService.GetMessageV3(1192, [retUnitPrice.toString()])));
             }
             let returningDocument: ChattelDocumentDetailWithPurchase = this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.AddNew();
             returningDocument.Material = material;
             returningDocument.Amount = amount;
             returningDocument.UnitPrice = <Currency>unitPrice;
             switch (<StockMethodEnum>material.StockCard.StockMethod) {
                 case StockMethodEnum.ExpirationDated:
                     let retExpirationDate: Date = TTVisual.InputForm.GetDateTime("Son Kullanma Tarihi Giriniz.", "mm/dd/yyyy", true);
                     returningDocument.ExpirationDate = (await CommonService.GetLastDayOfMounth(<Date>retExpirationDate));
                     break;
                 case StockMethodEnum.LotUsed:
                     let retLotNo: string = TTVisual.InputForm.GetText("Lot Numarasını Giriniz.");
                     if (String.isNullOrEmpty(retLotNo) === false)
                         returningDocument.LotNo = retLotNo;
                     break;
                 case StockMethodEnum.StockNumbered:
                 case StockMethodEnum.QRCodeUsed:
                 default:
                     break;
             }
         }*/
    }


    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
        this._ChattelDocumentWithPurchase.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.satinalma;

        this.chkFreeEntry.Value = true;
        await this.controlFreeEnty();


        if (this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup == null) {
            let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            mSelectForm.AddMSItem(i18n("M23417", "Tıbbi Sarf"), i18n("M23417", "Tıbbi Sarf"), MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem(i18n("M16287", "İlaç"), i18n("M16287", "İlaç"), MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem(i18n("M23359", "Tıbbi Cihaz"), i18n("M23359", "Tıbbi Cihaz"), MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem(i18n("M12780", "Diğer"), i18n("M12780", "Diğer"), MKYS_EMalzemeGrupEnum.diger);
            let mkey: string = await mSelectForm.GetMSItem(this, i18n("M14806", "Giriş Yapılacak Malzeme Grubunu Seçiniz"), true);
            if (String.isNullOrEmpty(mkey))
                this.messageService.showError(i18n("M18579", "Malzeme grubu seçilmeden işleme devam edemezsiniz."));
            //throw new TTException("Malzeme grubu seçilmeden işleme devam edemezsiniz.");
            this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup = <MKYS_EMalzemeGrupEnum>mSelectForm.MSSelectedItemObject;
        }
        if (this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf)
            this.MaterialStockActionDetailIn.ListFilterExpression = "OBJECTDEFID = '58d34696-808e-47de-87e0-1f001d0928a7'  AND  MKYSMALZEMEKODU IS NOT NULL ";
        if (this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.ilac) {
            this.MaterialStockActionDetailIn.ListFilterExpression = "OBJECTDEFID = '65a2337c-bc3c-4c6b-9575-ad47fa7a9a89'  AND  MKYSMALZEMEKODU IS NOT NULL ";
            this.ITSButtonIsActive = true;
            this.UTSButtonIsActive = false;
        }
        if (this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiCihaz)
            this.MaterialStockActionDetailIn.ListFilterExpression = "OBJECTDEFID = 'f38f2111-0ee4-4b9f-9707-a63ac02d29f4'  AND  MKYSMALZEMEKODU IS NOT NULL";

        this.MaterialInput.MaterialGroup = this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup;
        this.MaterialInput.TransactionType = TransactionTypeEnum.In;
        this.MaterialInput.TicketDate = this._ChattelDocumentWithPurchase.TransactionDate;

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
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        let count: number = 20;

        if (this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf) {
            if (this._ChattelDocumentWithPurchase.Supplier == null) {
                throw new TTException("Firma Seçimi Yapılmalı!");
            }
            else if (String.isNullOrEmpty(this._ChattelDocumentWithPurchase.Supplier.SupplierNumber)) {
                this.SupplierVisible = true;
                throw new TTException("Seçilen firma için bayi no bilgisi bulunmamaktadır. Tıbbi Sarf malzemeler için bayi no bilgisi " + this._ChattelDocumentWithPurchase.Supplier.Name + " firması için tanımlanmalı.");
            }
        }

        if (this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi === null || this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi == undefined) {
            throw new TTException(" Malzemenin Alım Yöntemi Seçilmelidir!");
        }

        for (let detail of this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase) {
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

        for (let signUser of this._ChattelDocumentWithPurchase.StockActionSignDetails) {
            if (signUser.SignUser == null)
                throw new TTException("Muayene Komisyonu boş geçilemez.");
        }

        this._ViewModel.ChattelDocumentDetailsWithPurchaseGridList = this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase;
        this._ViewModel.PTSStockActionDetails = this._ChattelDocumentWithPurchase.PTSStockActionDetails;
        this._ViewModel.StockActionSignDetailsGridList = this._ChattelDocumentWithPurchase.StockActionSignDetails;
        this._ChattelDocumentWithPurchase.PTSNumber = this.ItsPackageNo;
        this._ChattelDocumentWithPurchase.IsPTSAction = this.ShowITSReceiveNotifications;





    }

    inputStore: Store;
    public setInputParam(value: Store) {

        if (value != null) {
            if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() == PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async PreScript() {
        super.PreScript();
        let isApproved: string = (await SystemParameterService.GetParameterValue('STOCKACTIONSTATENEWTOCOMPLETED', 'TRUE'));
        if (isApproved === 'TRUE') {
            this.DropStateButton(ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Approved);
        } else {
            this.DropStateButton(ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Completed);
        }

        if (this._ChattelDocumentWithPurchase.Store == null) {
            this._ChattelDocumentWithPurchase.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }

        if ((<MainStoreDefinition>this._ChattelDocumentWithPurchase.Store).MKYS_ButceTuru != undefined) {
            if ((<MainStoreDefinition>this._ChattelDocumentWithPurchase.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.donerSermaye) {
                let budgetObj: Guid = new Guid("3511171d-06ae-4434-ad44-3579ee616ecb");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDef;
            }
            if ((<MainStoreDefinition>this._ChattelDocumentWithPurchase.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.genelButce) {
                let budgetObj: Guid = new Guid("57c410cc-afea-487a-8327-76e91a696a02");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDef;
            }
            this.BudgetTypeDefinition.ReadOnly = true;
        }
        if (this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.MKYS_TeslimAlanObjID == null) {
            this._ChattelDocumentWithPurchase.MKYS_TeslimAlanObjID = this.activeUserService.ActiveUserID;
            this._ChattelDocumentWithPurchase.MKYS_TeslimAlan = (<ResUser>this.activeUserService.ActiveUser.UserObject).Name;
        }
        let useCommision: string = (await SystemParameterService.GetParameterValue('USEEXAMINATIONCOMMISION', 'FALSE'));
        if (useCommision === "TRUE") {
            this.useCommision = true;
            if (this._ChattelDocumentWithPurchase.StockActionSignDetails.length == 0) {
                for (let index = 0; index < 3; index++) {
                    let signDetail: StockActionSignDetail = new StockActionSignDetail();
                    if (index === 0)
                        signDetail.SignUserType = SignUserTypeEnum.Baskan;
                    else
                        signDetail.SignUserType = SignUserTypeEnum.Uye;
                    signDetail.IsDeputy = false;
                    this._ChattelDocumentWithPurchase.StockActionSignDetails.push(signDetail);
                }
            }
        }
        let useExaminationReportNoSeq: string = await SystemParameterService.GetParameterValue("USEEXAMINATIONREPORTNOSEQ", "FALSE");
        if (useExaminationReportNoSeq === "TRUE") {
            this._ChattelDocumentWithPurchase.ExaminationReportNo = "-2";
            this.ExaminationReportNo.ReadOnly = true;
        }
    }

    public async selectCommision() {
        let useCommision: string = (await SystemParameterService.GetParameterValue('USEEXAMINATIONCOMMISION', 'FALSE'));
        if (useCommision === "TRUE") {
            this.showCommisionComponent(CommisionTypeEnum.PurchaseExaminationCommision).then(res => {
                let modalActionResult = res as ModalActionResult;
                if (modalActionResult.Result === DialogResult.OK) {
                    let commision = res.Param as CommisionDefinitionInputDTO;
                    this._ChattelDocumentWithPurchase.StockActionSignDetails = new Array<StockActionSignDetail>();
                    for (let member of commision.CommisionMembers) {
                        let signDetail: StockActionSignDetail = new StockActionSignDetail();
                        signDetail.SignUser = member.ResUser;
                        signDetail.SignUserType = member.SignUserType;
                        signDetail.IsDeputy = false;
                        this._ChattelDocumentWithPurchase.StockActionSignDetails.push(signDetail);
                    }
                }
            });
        } else {
            if (this._ChattelDocumentWithPurchase.StockActionSignDetails.length == 0) {
                for (let index = 0; index < 3; index++) {
                    let signDetail: StockActionSignDetail = new StockActionSignDetail();
                    if (index === 0)
                        signDetail.SignUserType = SignUserTypeEnum.Baskan;
                    else
                        signDetail.SignUserType = SignUserTypeEnum.Uye;
                    signDetail.IsDeputy = false;
                    this._ChattelDocumentWithPurchase.StockActionSignDetails.push(signDetail);
                }
            }
        }
    }

    private showCommisionComponent(data: CommisionTypeEnum): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'CommisionSelectComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Komisyon';
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

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null && transDef.ToStateDefID != null && transDef.ToStateDefID.valueOf() === ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.Completed.id) {
            super.AfterContextSavedScript(transDef);
            let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChattelDocumentWithPurchase.ObjectID.toString());
            for (let document of documentRecordLogs) {
                if (this._ChattelDocumentWithPurchase.IsPTSAction == false) {
                    if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                        const objectIdParam = new GuidParam(document['ObjectID']);
                        const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                        this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
                        this.reportService.showReport('ExaminationChattelDocumentInDetailReport', reportParameters);
                    }
                    if (document.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                        const objectIdParam = new GuidParam(document['ObjectID']);
                        const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                        this.reportService.showReport('ChattelDocumentOutDetailReport', reportParameters);
                    }
                }
                else {
                    if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                        const objectIdParam = new GuidParam(document['ObjectID']);
                        const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                        this.reportService.showReport('ChattelDocumentInDetailReportPTS', reportParameters);
                        this.reportService.showReport('ExaminationChattelDocumentInDetailReportPTS', reportParameters);
                    }
                }
            }
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChattelDocumentWithPurchase();
        this.chattelDocumentWithPurchaseNewFormViewModel = new ChattelDocumentWithPurchaseNewFormViewModel();
        this._ViewModel = this.chattelDocumentWithPurchaseNewFormViewModel;
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase = this._TTObject as ChattelDocumentWithPurchase;
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.TmpOrderedSuppliers = new Array<TmpOrderedSupplier>();
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.TmpOrderedDetails = new Array<TmpOrderedDetail>();
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.Store = new Store();
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.Supplier = new Supplier();
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = new Array<ChattelDocumentDetailWithPurchase>();
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = new Array<ChattelDocumentDistribution>();
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.PTSStockActionDetails = new Array<PTSStockActionDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.chattelDocumentWithPurchaseNewFormViewModel = this._ViewModel as ChattelDocumentWithPurchaseNewFormViewModel;
        that._TTObject = this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase;
        if (this.chattelDocumentWithPurchaseNewFormViewModel == null)
            this.chattelDocumentWithPurchaseNewFormViewModel = new ChattelDocumentWithPurchaseNewFormViewModel();
        if (this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase == null)
            this.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase = new ChattelDocumentWithPurchase();
        that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.TmpOrderedSuppliers = that.chattelDocumentWithPurchaseNewFormViewModel.OrderedSuppliersGridGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseNewFormViewModel.OrderedSuppliersGridGridList) {
            let purchaseOrderObjectID = detailItem["PurchaseOrder"];
            if (purchaseOrderObjectID != null && (typeof purchaseOrderObjectID === 'string')) {
                let purchaseOrder = that.chattelDocumentWithPurchaseNewFormViewModel.PurchaseOrders.find(o => o.ObjectID.toString() === purchaseOrderObjectID.toString());
                if (purchaseOrder) {
                    detailItem.PurchaseOrder = purchaseOrder;
                }
                if (purchaseOrder != null) {
                    let supplierObjectID = purchaseOrder["Supplier"];
                    if (supplierObjectID != null && (typeof supplierObjectID === 'string')) {
                        let supplier = that.chattelDocumentWithPurchaseNewFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
                        if (supplier) {
                            purchaseOrder.Supplier = supplier;
                        }
                    }
                }
            }
        }
        that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.TmpOrderedDetails = that.chattelDocumentWithPurchaseNewFormViewModel.OrderedDetailsGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseNewFormViewModel.OrderedDetailsGridList) {
            let purchaseOrderDetailObjectID = detailItem["PurchaseOrderDetail"];
            if (purchaseOrderDetailObjectID != null && (typeof purchaseOrderDetailObjectID === 'string')) {
                let purchaseOrderDetail = that.chattelDocumentWithPurchaseNewFormViewModel.PurchaseOrderDetails.find(o => o.ObjectID.toString() === purchaseOrderDetailObjectID.toString());
                if (purchaseOrderDetail) {
                    detailItem.PurchaseOrderDetail = purchaseOrderDetail;
                }
                if (purchaseOrderDetail != null) {
                    let purchaseItemDefObjectID = purchaseOrderDetail["PurchaseItemDef"];
                    if (purchaseItemDefObjectID != null && (typeof purchaseItemDefObjectID === 'string')) {
                        let purchaseItemDef = that.chattelDocumentWithPurchaseNewFormViewModel.PurchaseItemDefs.find(o => o.ObjectID.toString() === purchaseItemDefObjectID.toString());
                        if (purchaseItemDef) {
                            purchaseOrderDetail.PurchaseItemDef = purchaseItemDef;
                        }
                    }
                }
                if (purchaseOrderDetail != null) {
                    let purchaseProjectDetailObjectID = purchaseOrderDetail["PurchaseProjectDetail"];
                    if (purchaseProjectDetailObjectID != null && (typeof purchaseProjectDetailObjectID === 'string')) {
                        let purchaseProjectDetail = that.chattelDocumentWithPurchaseNewFormViewModel.PurchaseProjectDetails.find(o => o.ObjectID.toString() === purchaseProjectDetailObjectID.toString());
                        if (purchaseProjectDetail) {
                            purchaseOrderDetail.PurchaseProjectDetail = purchaseProjectDetail;
                        }
                    }
                }
            }
        }
        let budgetTypeDefinitionObjectID = that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.chattelDocumentWithPurchaseNewFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.chattelDocumentWithPurchaseNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.Store = store;
            }
        }
        let supplierObjectID = that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase["Supplier"];
        if (supplierObjectID != null && (typeof supplierObjectID === 'string')) {
            let supplier = that.chattelDocumentWithPurchaseNewFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
            if (supplier) {
                that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.Supplier = supplier;
            }
        }
        that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = that.chattelDocumentWithPurchaseNewFormViewModel.ChattelDocumentDetailsWithPurchaseGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseNewFormViewModel.ChattelDocumentDetailsWithPurchaseGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.chattelDocumentWithPurchaseNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.chattelDocumentWithPurchaseNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                            material.NATOStockNO = stockCard.NATOStockNO;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.chattelDocumentWithPurchaseNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.chattelDocumentWithPurchaseNewFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.PTSStockActionDetails = that.chattelDocumentWithPurchaseNewFormViewModel.PTSStockActionDetails;
        for (let detailItem of that.chattelDocumentWithPurchaseNewFormViewModel.PTSStockActionDetails) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.chattelDocumentWithPurchaseNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.chattelDocumentWithPurchaseNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                            material.NATOStockNO = stockCard.NATOStockNO;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.chattelDocumentWithPurchaseNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions = that.chattelDocumentWithPurchaseNewFormViewModel.DemandAmountsGridGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseNewFormViewModel.DemandAmountsGridGridList) {
            let demandDetailObjectID = detailItem["DemandDetail"];
            if (demandDetailObjectID != null && (typeof demandDetailObjectID === 'string')) {
                let demandDetail = that.chattelDocumentWithPurchaseNewFormViewModel.DemandDetails.find(o => o.ObjectID.toString() === demandDetailObjectID.toString());
                if (demandDetail) {
                    detailItem.DemandDetail = demandDetail;
                }
                if (demandDetail != null) {
                    let demandObjectID = demandDetail["Demand"];
                    if (demandObjectID != null && (typeof demandObjectID === 'string')) {
                        let demand = that.chattelDocumentWithPurchaseNewFormViewModel.Demands.find(o => o.ObjectID.toString() === demandObjectID.toString());
                        if (demand) {
                            demandDetail.Demand = demand;
                        }
                        if (demand != null) {
                            let masterResourceObjectID = demand["MasterResource"];
                            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                                let masterResource = that.chattelDocumentWithPurchaseNewFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                                if (masterResource) {
                                    demand.MasterResource = masterResource;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.chattelDocumentWithPurchaseNewFormViewModel._ChattelDocumentWithPurchase.StockActionSignDetails = that.chattelDocumentWithPurchaseNewFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.chattelDocumentWithPurchaseNewFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.chattelDocumentWithPurchaseNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }

    //UTS İçin eklendi
    ShowReceiveNotifications: boolean = false;
    incomingUTSReceiveNotificationList: Array<UTSBatchGridDataType> = new Array<UTSBatchGridDataType>();
    async getIncomingReceiveNotifications() {
        if (this._ChattelDocumentWithPurchase.Supplier == undefined || this._ChattelDocumentWithPurchase.Supplier == null)
            TTVisual.InfoBox.Alert("UTS'ye yapılan verme bildirimlerini görüntüleyebilmek için firma seçimi yapılmalıdır!");
        else {
            let BNO: string = '';
            if (this._ChattelDocumentWithPurchase.Waybill != null) {
                BNO = this._ChattelDocumentWithPurchase.Waybill;
            }
            if (this._ChattelDocumentWithPurchase.Supplier.FirmIdentifierNo == null) {
                return ServiceLocator.MessageService.showError("Hata : Seçmiş olduğunuz firmanın numarası kayıtlı değildir, lütfen firma tanımını kontrol ediniz.");
            }
            let apiUrl: string = '/api/ChattelDocumentWithPurchaseService/GetUTSIncomingReceiveNotifications?GKK=' + this._ChattelDocumentWithPurchase.Supplier.FirmIdentifierNo + '&BNO=' + BNO;
            this.httpService.get<any>(apiUrl).then(
                x => {
                    this.incomingUTSReceiveNotificationList = x;
                    this.ShowReceiveNotifications = true;
                }
            ).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

    }

    selectedIncomingReceiveNotifs: any;
    async onReceiveNotifAddButtonClick() {
        let data = this.selectedIncomingReceiveNotifs;
        if (data != undefined) {
            for (let item of data) {
                let that = this;
                let UTSNotifVerificationDone: boolean = false;
                let apiUrl: string = '/api/ChattelDocumentWithPurchaseService/UTSNotificationVerification?VID=' + item.IncomingDeliveryNotifID
                    + '&BarcodeNo?=' + item.ProductNo + '&DocumentNo?=' + item.DocumentNo;
                if (this.stockLeveltypeArray.length == 0)
                    this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
                this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
                let newRow: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
                newRow.Material = item.ReceivedMaterial;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                newRow.LotNo = item.LotNumber;
                newRow.SerialNo = item.SerialNumber;
                newRow.IncomingDeliveryNotifID = item.IncomingDeliveryNotifID;
                newRow.Amount = item.Amount;
                if (this._ChattelDocumentWithPurchase.TransactionDate != null)
                    newRow.VatRate = await MaterialService.GetVatrateFromMaterialTS(item.ReceivedMaterial, this._ChattelDocumentWithPurchase.TransactionDate);
                // let respectiveIncomingUTSNotification: RespectiveIncomingUTSNotification = new RespectiveIncomingUTSNotification();
                // respectiveIncomingUTSNotification.IncomingReceiveNotificationID = item.IncomingDeliveryNotifID;
                // respectiveIncomingUTSNotification.chattelDocumentDetailsWithPurchase = newRow;
                // this.chattelDocumentWithPurchaseNewFormViewModel.RespectiveIncomingUTSNotificationList.push(respectiveIncomingUTSNotification);

                /*if (newRow.SerialNo !== null) {
                    if (!(this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.find(x => newRow.SerialNo.Equals(x.SerialNo)))) {
                        this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(newRow);
                    }
                }
                else if (newRow.LotNo !== null) {
                    if (!(this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.find(x => newRow.LotNo.Equals(x.LotNo)))) {
                        this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(newRow);
                    }
                }*/

                this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(newRow);
                this._ChattelDocumentWithPurchase.Waybill = item.DocumentNo;

            }

        }
        this.ShowReceiveNotifications = false;

    }

    //UTS İÇİN EKLENDİ
    async onShowReceiveNotifButtonClick() {
        await this.getIncomingReceiveNotifications();
        //  this.ShowReceiveNotifications = true;
    }

    titleGrid: string = "Taşınır Malın";
    ItsPackageNo: string = "";
    ShowITSReceiveNotifications: boolean = false;
    IsPatientSpecialCheck: boolean = true;
    async checkBoxValuePTS_valueChanged(e) {
        var newValue = e.value;
        if (newValue == true) {
            this.ShowITSReceiveNotifications = true;
            this.IsPatientSpecialCheck = false;
            this.titleGrid = "PTS Giriş";
            this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = new Array<ChattelDocumentDetailWithPurchase>();
            this._ChattelDocumentWithPurchase.WaybillDate = null;
            this._ChattelDocumentWithPurchase.Waybill = null;
            this.ptsReadIsOk = false;
        } else {
            this.ItsPackageNo = "";
            this.titleGrid = "Taşınır Malın";
            this.ShowITSReceiveNotifications = false;
            this.IsPatientSpecialCheck = true;
            this.incomingITSReceiptNotificationList = new Array<PTSMaterial>();
            this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase = new Array<ChattelDocumentDetailWithPurchase>();
            this._ChattelDocumentWithPurchase.WaybillDate = null;
            this._ChattelDocumentWithPurchase.Waybill = null;
            this.ptsReadIsOk = true;
        }
        this.CalculatePricesDelete();
    }
    public CalculatePricesDelete() {
        this.txtNotKDV.Text = "0.00";
        this.txtWithKDV.Text = "0.00";
        this.txtDiscount.Text = "0.00";
        this.txtTotalPrice.Text = "0.00";
    }

    public showLoadPanel = false;
    public LoadPanelMessage: string = "İşlem Yapılıyor Bekleyiniz.";
    ptsReadIsOk: boolean = false;
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


            data.PTSStockActionDetail.NotDiscountedUnitPrice = Math.Round(kdvliToplamFiyat, 6);
            data.PTSStockActionDetail.TotalDiscountAmount = Math.Round(toplamindirimTutati, 6);
            data.PTSStockActionDetail.TotalPriceNotDiscount = Math.Round(kdvBirimFiyati, 6);
        }

        if (data.RetrievalYear == null) {
            let today = new Date();
            data.RetrievalYear = today.getFullYear();
            data.PTSStockActionDetail.RetrievalYear = today.getFullYear();
        }
        /*
                for (let detail of data.PTSStockActionDetail.StockActionDetails) {
                    let purchaseDetail: ChattelDocumentDetailWithPurchase = <ChattelDocumentDetailWithPurchase>detail;
                    purchaseDetail.UnitPriceWithOutVat = data.UnitPriceWithOutVat;
                    purchaseDetail.VatRate = data.PTSStockActionDetail.VatRate;
                    purchaseDetail.DiscountRate = data.DiscountRate;
                    purchaseDetail.RetrievalYear = data.RetrievalYear;
                    purchaseDetail.ProductionDate = data.ProductionDate;
                    purchaseDetail.DiscountAmount = data.PTSStockActionDetail.DiscountAmount;
                    purchaseDetail.UnitPrice= data.PTSStockActionDetail.UnitPrice;
                    this.MaterialRowUpdatePriceGridCellChanged(purchaseDetail);
                }
        */
        this.CalculateFormTotalPriceForITS();
    }

    public CalculateFormTotalPriceForITS() {
        let priceCalc: Array<number> = new Array<number>();
        let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
        priceCalc.push(totalWithoutKDV);
        priceCalc.push(totalWithKDV);
        priceCalc.push(salesTotal);
        priceCalc.push(totalPrice);
        for (let data of this.chattelDocumentWithPurchaseNewFormViewModel.PTSMaterials) {
            if (data.UnitPriceWithOutVat === null || data.PTSStockActionDetail.DiscountAmount === null)
                continue;
            priceCalc[0] += data.amount * data.UnitPriceWithOutVat;
            priceCalc[1] += data.amount * (data.UnitPriceWithOutVat + (data.UnitPriceWithOutVat * data.PTSStockActionDetail.VatRate / 100));
            priceCalc[2] += data.PTSStockActionDetail.DiscountAmount;
        }
        priceCalc[3] = priceCalc[1] - priceCalc[2];
        this.txtNotKDV.Text = priceCalc[0].toFixed(2);
        this.txtWithKDV.Text = priceCalc[1].toFixed(2);
        this.txtDiscount.Text = priceCalc[2].toFixed(2);
        this.txtTotalPrice.Text = priceCalc[3].toFixed(2);
    }

    incomingITSReceiptNotificationList: Array<PTSMaterial> = new Array<PTSMaterial>();
    incomingPTSStockCards: Array<StockCard> = new Array<StockCard>();
    newStockLevelType: StockLevelType;
    ptsStockActionDetailSource: Array<PTSStockActionDetail> = new Array<PTSStockActionDetail>();
    async getItsReceiptNotification() {
        let that = this;
        let sup: Supplier = new Supplier();
        let waybillDate: Date = new Date();
        let waybill: string;
        let inputDVO: PTSInputDVO = new PTSInputDVO();
        inputDVO.PTSID = this.ItsPackageNo.toString();
        inputDVO.stockAction = this._ChattelDocumentWithPurchase;
        let apiUrlForInvoiceTerms: string = '/api/ChattelDocumentWithPurchaseService/GetItsReceiptNotification';
        this.httpService.post<PTSMaterialOutput>(apiUrlForInvoiceTerms, inputDVO).then(
            x => {
                that.incomingITSReceiptNotificationList = x.PTSMaterials;
                that.chattelDocumentWithPurchaseNewFormViewModel.PTSMaterials = new Array<PTSMaterial>();
                that.chattelDocumentWithPurchaseNewFormViewModel.PTSMaterials = x.PTSMaterials;
                that.incomingPTSStockCards = x.StockCards;
                that.newStockLevelType = x.StockLevelType;
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
                    newPTS.StockActionDetails = new Array<ChattelDocumentDetailWithPurchase>();
                    /* for (let chtDet of cht.serialNOList) {
                         let newRow: ChattelDocumentDetailWithPurchase = chtDet.chattelDocumentDetailWithPurchase;
                         that.addedPTStoChattelDetGrid(newPTS, chtDet.serialNo, chtDet.amount);
                     }*/
                    newPTS.StockAction = that._ChattelDocumentWithPurchase;
                    cht.PTSStockActionDetail = newPTS;
                    that._ChattelDocumentWithPurchase.PTSStockActionDetails.push(newPTS);
                    sup = cht.supplier;
                    waybillDate = cht.DocumentRecordDate;
                    waybill = cht.DocumentRecordNo;
                }
                that._ChattelDocumentWithPurchase.Supplier = sup;
                that._ChattelDocumentWithPurchase.WaybillDate = waybillDate;
                that._ChattelDocumentWithPurchase.Waybill = waybill;
                this.showLoadPanel = false;
            }
        ).catch(error => {
            TTVisual.InfoBox.Alert(error);
            //ServiceLocator.MessageService.showError("Hata : " + error);
            this.showLoadPanel = false;
            this.ptsReadIsOk = false;
        });
    }

    async addedPTStoChattelDetGrid(ptsDetail: PTSStockActionDetail, serialNo: string, amount: number) {
        let that = this;
        let newRow: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();

        newRow.SerialNo = serialNo;
        newRow.LotNo = ptsDetail.LotNo;
        newRow.StockAction = that._ChattelDocumentWithPurchase;
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
        that._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(newRow);

    }

    document: UploadedDocument = new UploadedDocument();
    async readDocumentItSForPackageClick($event) {
        this.showLoadPanel = true;
        let that = this;
        let sup: Supplier = new Supplier();
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
                inputDVO.stockAction = that._ChattelDocumentWithPurchase;
                let apiUrlForInvoiceTerms: string = '/api/ChattelDocumentWithPurchaseService/GetItsReceiptNotificationFileRead';
                this.httpService.post<PTSMaterialOutput>(apiUrlForInvoiceTerms, inputDVO).then(
                    x => {
                        that.incomingITSReceiptNotificationList = x.PTSMaterials;
                        that.incomingPTSStockCards = x.StockCards;
                        that.newStockLevelType = x.StockLevelType;
                        that.chattelDocumentWithPurchaseNewFormViewModel.PTSMaterials = new Array<PTSMaterial>();
                        that.chattelDocumentWithPurchaseNewFormViewModel.PTSMaterials = x.PTSMaterials;
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
                            newPTS.StockActionDetails = new Array<ChattelDocumentDetailWithPurchase>();
                            /*for (let chtDet of cht.serialNOList) {
                                that.addedPTStoChattelDetGrid(newPTS, chtDet.serialNo, chtDet.amount);
                            }*/
                            newPTS.StockAction = that._ChattelDocumentWithPurchase;
                            cht.PTSStockActionDetail = newPTS;
                            that._ChattelDocumentWithPurchase.PTSStockActionDetails.push(newPTS);
                            sup = cht.supplier;
                            waybillDate = cht.DocumentRecordDate;
                            waybill = cht.DocumentRecordNo;

                        }
                        that._ChattelDocumentWithPurchase.Supplier = sup;
                        that._ChattelDocumentWithPurchase.WaybillDate = waybillDate;
                        that._ChattelDocumentWithPurchase.Waybill = waybill;
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




    public BildirimGridColumns = [
        {
            'caption': "Verme Bildirim ID",
            dataField: 'IncomingDeliveryNotifID',
            allowSorting: true,
        },
        {
            'caption': "Belge No",
            dataField: 'DocumentNo',
            allowSorting: true
        },
        {
            'caption': "Malzeme Adı",
            dataField: 'ReceivedMaterial.Name',
            allowSorting: true
        },
        {
            'caption': "Hasta TC Kimlik Numarası",
            dataField: 'PatientUniqueID',
            allowSorting: true
        },
        {
            'caption': "Hasta Adı",
            dataField: 'PatientName',
            allowSorting: true
        },
        {
            'caption': "Ürün Numarası",
            dataField: 'ProductNo',
            allowSorting: true
        },

        {
            'caption': "Gönderen Kurum Numarası",
            dataField: 'SendingOrganizationNo',
            allowSorting: true
        },
        {
            'caption': "Eşsiz Kimlik",
            dataField: 'UniqueDeviceIdentifier',
            allowSorting: true
        },
        {
            'caption': "Lot/Batch Numarası",
            dataField: 'LotNumber',
            allowSorting: true
        },
        {
            'caption': "Seri/Sıra Numarası",
            dataField: 'SerialNumber',
            allowSorting: true
        },
        {
            'caption': "Miktar",
            dataField: 'Amount',
            allowSorting: true
        }

    ];

    public ShowNewMaterialList: boolean = false;
    async ngOnInit() {
        let that = this;
        await this.load(ChattelDocumentWithPurchaseNewFormViewModel);
        if (this._ChattelDocumentWithPurchase.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ChattelDocumentWithPurchase.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M21380", "Satınalma Yoluyla Giriş ( Yeni )");
        this.changeDetectorRef.detectChanges();

        this.ShowITSReceiveNotifications = false;

        let listParameter: string = (await SystemParameterService.GetParameterValue('SHOWNEWMATERIALLIST', 'FALSE'));
        if (listParameter === "TRUE") {
            this.ShowNewMaterialList = true;
        }
        
        NewMaterialService.onMaterialAdd.subscribe((e) => {
            for (let item of e) {
                let newRow: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
                newRow.Material = item.Material;
                newRow.Material.StockCard = item.StockCard;
                newRow.StockLevelType = item.StockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                newRow.VatRate = item.VatRate;
                this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(newRow);
                this.selectedMaterialGrid = new Array<ChattelDocumentDetailWithPurchase>();
                this.selectedMaterialGrid.push(newRow);

                setTimeout(x => {
                    let rowIndex: number = this.materialGrid.instance.getRowIndexByKey(this.selectedMaterialGrid[0]);
                    let selecttedRowIndex: number = rowIndex + 1;
                    this.materialGrid.instance.editRow(rowIndex);
                }, 250);
            }
        });
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

    public onchkFreeEntryChanged(event): void {
        if (event != null) {
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.FreeEntry != event) {
                this._ChattelDocumentWithPurchase.FreeEntry = event;
            }
        }
        this.chkFreeEntry_CheckedChanged();
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

        if (event != null && this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.Supplier != event) {
            let supplier = <Supplier>event;
            if (this._ChattelDocumentWithPurchase.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf) // mevzuat gereği tıbbi sarf malzemelerde bayi no alanı zorunlu hale geldi.
            {
                if (supplier.FirmIdentifierNo == null) {
                    ServiceLocator.MessageService.showError("Seçmiş olduğunuz : " + supplier.Name + " firmanın numarası kayıtlı değildir, lütfen firma tanımını kontrol ediniz");
                    this._ChattelDocumentWithPurchase.Supplier = event;
                    this.SupplierVisible = true;
                }
            }
            this._ChattelDocumentWithPurchase.Supplier = event;
            this._ChattelDocumentWithPurchase.MKYS_TeslimEden = this._ChattelDocumentWithPurchase.Supplier.Name;
        }
        else
            this._ChattelDocumentWithPurchase.Supplier = event;
    }

    /*public onTransactionDateChanged(event): void {
       if (event != null) {
           if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.TransactionDate !== event) {
               this._ChattelDocumentWithPurchase.TransactionDate = event;
           }
       }
   }*/
    public onTransactionDateChanged(event): void {
        if (event != null) {
            let dateNow: Date = new Date();
            if (this._ChattelDocumentWithPurchase != null && this._ChattelDocumentWithPurchase.TransactionDate != event) {
                if (event.getTime() <= dateNow.getTime()) {
                    this._ChattelDocumentWithPurchase.TransactionDate = event;
                } else {
                    ServiceLocator.MessageService.showError(i18n("M16402", "İleri Tarihe giriş yapılamaz."));
                    this._ChattelDocumentWithPurchase.TransactionDate = dateNow;
                }
            }
        }
    }
    private SupplierVisible: boolean = false;
    private UpdatedSupplierNumber: string = "";
    async SaveSupplierNumber() {

        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/BaseChattelDocumentService/UpdateSupplierNumber';
            if (this._ChattelDocumentWithPurchase.Supplier != null && this.UpdatedSupplierNumber != null) {
                let body = { 'SupplierObjectId': this._ChattelDocumentWithPurchase.Supplier.ObjectID, 'SupplierNumber': this.UpdatedSupplierNumber };
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });
                await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                    if (response.IsSuccess) {
                        ServiceLocator.MessageService.showInfo(response.SuccessMessage);
                        this._ChattelDocumentWithPurchase.Supplier.SupplierNumber = this.UpdatedSupplierNumber;
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

    public async GetWaybill_Click(): Promise<void> {

        let PurchaseEServiceName: string = (await SystemParameterService.GetParameterValue('PURCHASESERVICENAME', ''));
        if (PurchaseEServiceName == 'XXXXXX') {
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() === ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.New.id) {
                if (!String.isNullOrEmpty(this._ChattelDocumentWithPurchase.Waybill)) {
                    let inputDetailDocument: GetWaybillForInputDetailDocument_Output = await ChattelDocumentWithPurchaseService.GetWaybillForInputDocumentTS(this._ChattelDocumentWithPurchase);
                    if (inputDetailDocument != null) {
                        let purchaseDocument: ChattelDocumentWithPurchase = inputDetailDocument.chattelDocumentWithPurchase;
                        let purchaseDocumentDetails: Array<ChattelDocumentDetailWithPurchase> = inputDetailDocument.chattelDocumentDetailWithPurchase;
                        let budgetObj: Guid = <any>purchaseDocument["BudgetTypeDefinition"];
                        let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                        this._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDef;
                        let supplierObj: Guid = <any>purchaseDocument["Supplier"];
                        let SupplierDef: any = await this.objectContextService.getObject(supplierObj, Supplier.ObjectDefID);
                        this._ChattelDocumentWithPurchase.Supplier = SupplierDef;
                        this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi = purchaseDocument.MKYS_EAlimYontemi;
                        this._ChattelDocumentWithPurchase.AuctionDate = purchaseDocument.AuctionDate;
                        this._ChattelDocumentWithPurchase.ExaminationReportNo = purchaseDocument.ExaminationReportNo;
                        this._ChattelDocumentWithPurchase.ExaminationReportDate = purchaseDocument.ExaminationReportDate;
                        this._ChattelDocumentWithPurchase.MKYS_TeslimAlan = purchaseDocument.MKYS_TeslimAlan;
                        this._ChattelDocumentWithPurchase.MKYS_TeslimEden = purchaseDocument.MKYS_TeslimEden;
                        this._ChattelDocumentWithPurchase.WaybillDate = purchaseDocument.WaybillDate;
                        this._ChattelDocumentWithPurchase.Description = purchaseDocument.Description;
                        this._ChattelDocumentWithPurchase.FreeEntry = false;
                        this._ChattelDocumentWithPurchase.RegistrationAuctionNo = purchaseDocument.RegistrationAuctionNo;
                        this._ChattelDocumentWithPurchase.ConclusionDateTime = purchaseDocument.ConclusionDateTime;
                        this._ChattelDocumentWithPurchase.ConclusionNumber = purchaseDocument.ConclusionNumber;
                        this._ChattelDocumentWithPurchase.PatientFullName = purchaseDocument.PatientFullName;
                        this._ChattelDocumentWithPurchase.PatientUniqueNo = purchaseDocument.PatientUniqueNo;

                        for (let detail of purchaseDocumentDetails) {
                            let chattelDocumentDetailWithPurchase: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
                            chattelDocumentDetailWithPurchase.Amount = detail.Amount;
                            chattelDocumentDetailWithPurchase.DiscountAmount = detail.DiscountAmount;
                            chattelDocumentDetailWithPurchase.DiscountRate = detail.DiscountRate;
                            chattelDocumentDetailWithPurchase.ExpirationDate = detail.ExpirationDate;
                            let mat: Guid = <any>detail["Material"];
                            let material: any = await this.objectContextService.getObject(mat, Material.ObjectDefID);
                            chattelDocumentDetailWithPurchase.Material = material;
                            let stockCardObj: Guid = <any>material["StockCard"];
                            let stockCard: any = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
                            chattelDocumentDetailWithPurchase.Material.StockCard = stockCard;
                            let dist: Guid = <any>stockCard["DistributionType"];
                            let distributionType: any = await this.objectContextService.getObject(dist, DistributionTypeDefinition.ObjectDefID);
                            chattelDocumentDetailWithPurchase.Material.StockCard.DistributionType = distributionType;
                            chattelDocumentDetailWithPurchase.NotDiscountedUnitPrice = detail.NotDiscountedUnitPrice;
                            chattelDocumentDetailWithPurchase.TotalDiscountAmount = detail.TotalDiscountAmount;
                            chattelDocumentDetailWithPurchase.TotalPriceNotDiscount = detail.TotalPriceNotDiscount;
                            chattelDocumentDetailWithPurchase.UnitPriceWithInVat = detail.UnitPriceWithInVat;
                            chattelDocumentDetailWithPurchase.UnitPriceWithOutVat = detail.UnitPriceWithOutVat;
                            chattelDocumentDetailWithPurchase.VatRate = detail.VatRate;
                            chattelDocumentDetailWithPurchase.DiscountAmount = detail.DiscountAmount;
                            chattelDocumentDetailWithPurchase.LotNo = detail.LotNo;
                            chattelDocumentDetailWithPurchase.StockLevelType = detail.StockLevelType;
                            chattelDocumentDetailWithPurchase.Status = detail.Status;
                            chattelDocumentDetailWithPurchase.RetrievalYear = detail.RetrievalYear;
                            //chattelDocumentDetailWithPurchase.ProductionDate = detail.ProductionDate;

                            this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(chattelDocumentDetailWithPurchase);

                            await this.CalculatePricesWithKdv(chattelDocumentDetailWithPurchase);
                            let priceCalc: Array<number> = new Array<number>();
                            let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
                            priceCalc.push(totalWithoutKDV);
                            priceCalc.push(totalWithKDV);
                            priceCalc.push(salesTotal);
                            priceCalc.push(totalPrice);
                            priceCalc = await this.CalcFinalPriceWithKDV(priceCalc);
                            this.txtNotKDV.Text = priceCalc[0].toString();
                            this.txtWithKDV.Text = priceCalc[1].toString();
                            this.txtDiscount.Text = priceCalc[2].toString();
                            this.txtTotalPrice.Text = priceCalc[3].toString();
                            this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
                            this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = false;
                        }
                    }
                }
            }
        }
        else if (PurchaseEServiceName == 'FASTSOFT') {
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID.toString() === ChattelDocumentWithPurchase.ChattelDocumentWithPurchaseStates.New.id) {
                if (!String.isNullOrEmpty(this._ChattelDocumentWithPurchase.Waybill)) {
                    try {
                        let inputDetailDocument: GetWaybillForInputDetailDocument_Output = await ChattelDocumentWithPurchaseService.GetWaybillForInputDocumentTSFastSoft(this._ChattelDocumentWithPurchase);
                        if (inputDetailDocument != null) {
                            if (inputDetailDocument.chattelDocumentDetailWithPurchase.length > 0) {
                                let purchaseDocument: ChattelDocumentWithPurchase = inputDetailDocument.chattelDocumentWithPurchase;
                                let purchaseDocumentDetails: Array<ChattelDocumentDetailWithPurchase> = inputDetailDocument.chattelDocumentDetailWithPurchase;
                                let budgetObj: Guid = <any>purchaseDocument["BudgetTypeDefinition"];
                                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                                this._ChattelDocumentWithPurchase.BudgetTypeDefinition = budgetTypeDef;
                                let supplierObj: Guid = <any>purchaseDocument["Supplier"];
                                let SupplierDef: any = await this.objectContextService.getObject(supplierObj, Supplier.ObjectDefID);
                                this._ChattelDocumentWithPurchase.Supplier = SupplierDef;
                                this._ChattelDocumentWithPurchase.MKYS_EAlimYontemi = purchaseDocument.MKYS_EAlimYontemi;
                                this._ChattelDocumentWithPurchase.AuctionDate = purchaseDocument.AuctionDate;
                                this._ChattelDocumentWithPurchase.ExaminationReportNo = purchaseDocument.ExaminationReportNo;
                                this._ChattelDocumentWithPurchase.ExaminationReportDate = purchaseDocument.ExaminationReportDate;
                                this._ChattelDocumentWithPurchase.MKYS_TeslimAlan = purchaseDocument.MKYS_TeslimAlan;
                                this._ChattelDocumentWithPurchase.MKYS_TeslimEden = purchaseDocument.MKYS_TeslimEden;
                                this._ChattelDocumentWithPurchase.WaybillDate = purchaseDocument.WaybillDate;
                                this._ChattelDocumentWithPurchase.Description = purchaseDocument.Description;
                                this._ChattelDocumentWithPurchase.FreeEntry = false;
                                this._ChattelDocumentWithPurchase.RegistrationAuctionNo = purchaseDocument.RegistrationAuctionNo;
                                this._ChattelDocumentWithPurchase.ConclusionDateTime = purchaseDocument.ConclusionDateTime;
                                this._ChattelDocumentWithPurchase.ConclusionNumber = purchaseDocument.ConclusionNumber;
                                this._ChattelDocumentWithPurchase.PatientFullName = purchaseDocument.PatientFullName;
                                this._ChattelDocumentWithPurchase.PatientUniqueNo = purchaseDocument.PatientUniqueNo;
                                this._ChattelDocumentWithPurchase.IsFastSoft = true;
                                this._ChattelDocumentWithPurchase.FastSoftFaturaId = purchaseDocument.FastSoftFaturaId;
                                this._ChattelDocumentWithPurchase.FastSoftUygulamaId = purchaseDocument.FastSoftUygulamaId;

                                for (let detail of purchaseDocumentDetails) {
                                    let chattelDocumentDetailWithPurchase: ChattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase();
                                    chattelDocumentDetailWithPurchase.Amount = detail.Amount;
                                    chattelDocumentDetailWithPurchase.DiscountAmount = detail.DiscountAmount;
                                    chattelDocumentDetailWithPurchase.DiscountRate = detail.DiscountRate;
                                    chattelDocumentDetailWithPurchase.ExpirationDate = detail.ExpirationDate;
                                    let mat: Guid = <any>detail["Material"];
                                    let material: any = await this.objectContextService.getObject(mat, Material.ObjectDefID);
                                    chattelDocumentDetailWithPurchase.Material = material;
                                    let stockCardObj: Guid = <any>material["StockCard"];
                                    let stockCard: any = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
                                    chattelDocumentDetailWithPurchase.Material.StockCard = stockCard;
                                    let dist: Guid = <any>stockCard["DistributionType"];
                                    let distributionType: any = await this.objectContextService.getObject(dist, DistributionTypeDefinition.ObjectDefID);
                                    chattelDocumentDetailWithPurchase.Material.StockCard.DistributionType = distributionType;
                                    chattelDocumentDetailWithPurchase.NotDiscountedUnitPrice = detail.NotDiscountedUnitPrice;
                                    chattelDocumentDetailWithPurchase.TotalDiscountAmount = detail.TotalDiscountAmount;
                                    chattelDocumentDetailWithPurchase.TotalPriceNotDiscount = detail.TotalPriceNotDiscount;
                                    chattelDocumentDetailWithPurchase.UnitPriceWithInVat = detail.UnitPriceWithInVat;
                                    chattelDocumentDetailWithPurchase.UnitPriceWithOutVat = detail.UnitPriceWithOutVat;
                                    chattelDocumentDetailWithPurchase.VatRate = detail.VatRate;
                                    chattelDocumentDetailWithPurchase.DiscountAmount = detail.DiscountAmount;
                                    chattelDocumentDetailWithPurchase.LotNo = detail.LotNo;
                                    chattelDocumentDetailWithPurchase.StockLevelType = detail.StockLevelType;
                                    chattelDocumentDetailWithPurchase.Status = detail.Status;
                                    chattelDocumentDetailWithPurchase.RetrievalYear = detail.RetrievalYear;
                                    //chattelDocumentDetailWithPurchase.ProductionDate = detail.ProductionDate;

                                    this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.push(chattelDocumentDetailWithPurchase);

                                    await this.CalculatePricesWithKdv(chattelDocumentDetailWithPurchase);
                                    let priceCalc: Array<number> = new Array<number>();
                                    let totalWithoutKDV: number = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
                                    priceCalc.push(totalWithoutKDV);
                                    priceCalc.push(totalWithKDV);
                                    priceCalc.push(salesTotal);
                                    priceCalc.push(totalPrice);
                                    priceCalc = await this.CalcFinalPriceWithKDV(priceCalc);
                                    this.txtNotKDV.Text = priceCalc[0].toString();
                                    this.txtWithKDV.Text = priceCalc[1].toString();
                                    this.txtDiscount.Text = priceCalc[2].toString();
                                    this.txtTotalPrice.Text = priceCalc[3].toString();


                                    this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
                                    this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = false;
                                }

                            }
                            else {
                                TTVisual.InfoBox.Alert(" İrsaliyeli Kayıt Bulunamamıştır.!");
                            }
                        }
                        else {
                            TTVisual.InfoBox.Alert(" İrsaliyeli Kayıt Bulunamamıştır.!");
                        }
                    }
                    catch (ex) {
                        ServiceLocator.MessageService.showError(ex);
                    }
                }
            }
        }
        else {
            TTVisual.InfoBox.Alert(" PURCHASESERVICENAME parametresini kontrol ediniz!");
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

    onSelectionChange(data: any) {
    }
    public async ChattelDocumentDetailsWithPurchase_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.ChattelDocumentDetailsWithPurchase_CellValueChanged(data, rowIndex, columnIndex);
    }

    // public onlistBoxTreatmentResultCleared(event): void {
    //     if (event == null) {
    //         if (this._ChattelDocumentWithPurchase.Supplier != null && this._ChattelDocumentWithPurchase.Supplier !== event) {
    //             this._ChattelDocumentWithPurchase.Supplier = null;
    //         }
    //     }
    // }



    onCellContentClicked(data: any) {
    }
    async initNewRow(data: any) {
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
        redirectProperty(this.chkFreeEntry, "Value", this.__ttObject, "FreeEntry");
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
        this.AvailableOrdersTab = new TTVisual.TTTabPage();
        this.AvailableOrdersTab.DisplayIndex = 1;
        this.AvailableOrdersTab.TabIndex = 1;
        this.AvailableOrdersTab.Text = i18n("M10662", "Aktif Siparişler");
        this.AvailableOrdersTab.Name = "AvailableOrdersTab";

        this.PictureTabpage = new TTVisual.TTTabPage();
        this.PictureTabpage.DisplayIndex = 2;
        this.PictureTabpage.TabIndex = 2;
        this.PictureTabpage.Text = "Fatura";
        this.PictureTabpage.Name = "PictureTabpage";

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M11729", "Bekleyen Siparişi Bulunan Firmalar");
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 1;

        this.invoicePictureControl = new TTVisual.TTPictureBoxControl();
        this.invoicePictureControl.Name = "invoicePictureControl";
        this.invoicePictureControl.TabIndex = 0;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.OrderedSuppliersGrid = new TTVisual.TTGrid();
        this.OrderedSuppliersGrid.RowHeadersVisible = false;
        this.OrderedSuppliersGrid.Name = "OrderedSuppliersGrid";
        this.OrderedSuppliersGrid.TabIndex = 0;
        this.OrderedSuppliersGrid.Height = 350;

        this.Waybill = new TTVisual.TTTextBox();
        this.Waybill.Name = "Waybill";
        this.Waybill.TabIndex = 145;
        this.Waybill.Required = true;
        this.Waybill.BackColor = "#FFE3C6";

        this.RegistrationAuctionNo = new TTVisual.TTTextBox();
        this.RegistrationAuctionNo.Required = true;
        this.RegistrationAuctionNo.BackColor = "#FFE3C6";
        this.RegistrationAuctionNo.Name = "RegistrationAuctionNo";
        this.RegistrationAuctionNo.TabIndex = 139;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.ttlistboxcolumn1 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn1.ListDefName = "SupplierListDefinition";
        this.ttlistboxcolumn1.DataMember = "Supplier";
        this.ttlistboxcolumn1.DisplayIndex = 0;
        this.ttlistboxcolumn1.HeaderText = i18n("M14301", "Firma");
        this.ttlistboxcolumn1.Name = "ttlistboxcolumn1";
        this.ttlistboxcolumn1.ReadOnly = true;
        this.ttlistboxcolumn1.Width = 275;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 134;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.OrderNo = new TTVisual.TTTextBoxColumn();
        this.OrderNo.DataMember = "OrderNO";
        this.OrderNo.DisplayIndex = 1;
        this.OrderNo.HeaderText = i18n("M21900", "Sipariş No");
        this.OrderNo.Name = "OrderNo";
        this.OrderNo.ReadOnly = true;
        this.OrderNo.Width = 100;

        this.ExaminationReportNo = new TTVisual.TTTextBox();
        this.ExaminationReportNo.Name = "ExaminationReportNo";
        this.ExaminationReportNo.TabIndex = 130;
        this.ExaminationReportNo.Required = false;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.OrderedDetails = new TTVisual.TTGrid();
        this.OrderedDetails.RowHeadersVisible = false;
        this.OrderedDetails.Name = "OrderedDetails";
        this.OrderedDetails.TabIndex = 2;

        this.ConclusionNumber = new TTVisual.TTTextBox();
        this.ConclusionNumber.ReadOnly = true;
        this.ConclusionNumber.Name = "ConclusionNumber";
        this.ConclusionNumber.TabIndex = 5;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.datagridviewcolumn1 = new TTVisual.TTCheckBoxColumn();
        this.datagridviewcolumn1.DataMember = "Checked";
        this.datagridviewcolumn1.DisplayIndex = 0;
        this.datagridviewcolumn1.HeaderText = i18n("M21507", "Seç");
        this.datagridviewcolumn1.Name = "datagridviewcolumn1";
        this.datagridviewcolumn1.Width = 40;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 144;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.ttlistboxcolumn2 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn2.ListDefName = "PurchaseItemList";
        this.ttlistboxcolumn2.DataMember = "PurchaseItemDef";
        this.ttlistboxcolumn2.DisplayIndex = 1;
        this.ttlistboxcolumn2.HeaderText = i18n("M18545", "Malzeme");
        this.ttlistboxcolumn2.Name = "ttlistboxcolumn2";
        this.ttlistboxcolumn2.ReadOnly = true;
        this.ttlistboxcolumn2.Width = 300;

        this.GetWaybill = new TTButtonTextBox();
        this.GetWaybill.ButtonText = "B.G.";
        this.GetWaybill.Name = "GetWaybill";
        this.GetWaybill.TabIndex = 147;
        this.GetWaybill.Required = true;
        this.GetWaybill.BackColor = "#FFE3C6";


        this.labelWaybillDate = new TTVisual.TTLabel();
        this.labelWaybillDate.Text = i18n("M16573", "İrsaliye Tarihi");
        this.labelWaybillDate.Name = "labelWaybillDate";
        this.labelWaybillDate.TabIndex = 149;

        this.WaybillDate = new TTVisual.TTDateTimePicker();
        this.WaybillDate.Format = DateTimePickerFormat.Short;
        this.WaybillDate.Name = "WaybillDate";
        this.WaybillDate.TabIndex = 148;
        this.WaybillDate.Required = true;
        this.WaybillDate.BackColor = "#FFE3C6";

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 143;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = "10%";
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = "20%";

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.tttextboxcolumn2 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn2.DataMember = "Amount";
        this.tttextboxcolumn2.DisplayIndex = 2;
        this.tttextboxcolumn2.HeaderText = i18n("M10505", "Adet");
        this.tttextboxcolumn2.Name = "tttextboxcolumn2";
        this.tttextboxcolumn2.ReadOnly = true;
        this.tttextboxcolumn2.Width = 75;
        this.tttextboxcolumn2.IsNumeric = true;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14807", "Giriş Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 142;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.datagridviewcolumn2 = new TTVisual.TTTextBoxColumn();
        this.datagridviewcolumn2.DataMember = "ConclusionNO";
        this.datagridviewcolumn2.DisplayIndex = 3;
        this.datagridviewcolumn2.HeaderText = i18n("M17275", "Karar No");
        this.datagridviewcolumn2.Name = "datagridviewcolumn2";
        this.datagridviewcolumn2.ReadOnly = true;
        this.datagridviewcolumn2.Width = 90;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 141;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        //this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        //this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M21912", "Siparişte Mevcut Malzemeler");
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 3;

        this.labelRegistrationAuctionNo = new TTVisual.TTLabel();
        this.labelRegistrationAuctionNo.Text = i18n("M16214", "İhale No");
        this.labelRegistrationAuctionNo.Name = "labelRegistrationAuctionNo";
        this.labelRegistrationAuctionNo.TabIndex = 140;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

        this.cmdTransfer = new TTVisual.TTButton();
        this.cmdTransfer.Text = i18n("M21539", "Seçilenleri Ekle");
        this.cmdTransfer.Name = "cmdTransfer";
        this.cmdTransfer.TabIndex = 4;

        this.labelAuctionDate = new TTVisual.TTLabel();
        this.labelAuctionDate.Text = i18n("M16199", "İhale  Tarihi");
        this.labelAuctionDate.Name = "labelAuctionDate";
        this.labelAuctionDate.TabIndex = 138;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.firmdef_ttbutton = new TTVisual.TTButton();
        this.firmdef_ttbutton.Text = i18n("M14317", "Firma Tanım.");
        this.firmdef_ttbutton.Name = "firmdef_ttbutton";
        this.firmdef_ttbutton.TabIndex = 137;

        this.AuctionDate = new TTVisual.TTDateTimePicker();
        this.AuctionDate.Required = true;
        this.AuctionDate.BackColor = "#FFE3C6";
        this.AuctionDate.Format = DateTimePickerFormat.Short;
        this.AuctionDate.Name = "AuctionDate";
        this.AuctionDate.TabIndex = 137;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.chkFreeEntry = new TTVisual.TTCheckBox();
        this.chkFreeEntry.Value = false;
        this.chkFreeEntry.Title = i18n("M21628", "Serbest Giriş");
        this.chkFreeEntry.Name = "chkFreeEntry";
        this.chkFreeEntry.TabIndex = 128;

        this.labelExaminationReportNo = new TTVisual.TTLabel();
        this.labelExaminationReportNo.Text = i18n("M19210", "Muayene Rapor Sayısı");
        this.labelExaminationReportNo.Name = "labelExaminationReportNo";
        this.labelExaminationReportNo.TabIndex = 131;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.AllowUserToAddRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;
        this.StockActionSignDetails.Height = "500px";


        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M14100", "Fatura  Tutarı");
        this.ttlabel6.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 125;

        this.labelExaminationReportDate = new TTVisual.TTLabel();
        this.labelExaminationReportDate.Text = i18n("M19211", "Muayene Rapor Tarihi");
        this.labelExaminationReportDate.Name = "labelExaminationReportDate";
        this.labelExaminationReportDate.TabIndex = 129;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.ExaminationReportDate = new TTVisual.TTDateTimePicker();
        this.ExaminationReportDate.Format = DateTimePickerFormat.Short;
        this.ExaminationReportDate.Name = "ExaminationReportDate";
        this.ExaminationReportDate.TabIndex = 128;
        this.ExaminationReportDate.Required = false;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;
        this.SignUser.ReadOnly = false;

        this.labelConclusionNumber = new TTVisual.TTLabel();
        this.labelConclusionNumber.Text = i18n("M17276", "Karar Numarası");
        this.labelConclusionNumber.Name = "labelConclusionNumber";
        this.labelConclusionNumber.TabIndex = 123;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.labelConclusionDateTime = new TTVisual.TTLabel();
        this.labelConclusionDateTime.Text = i18n("M17284", "Karar Tarihi");
        this.labelConclusionDateTime.Name = "labelConclusionDateTime";
        this.labelConclusionDateTime.TabIndex = 121;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.ConclusionDateTime = new TTVisual.TTDateTimePicker();
        this.ConclusionDateTime.Format = DateTimePickerFormat.Short;
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
        this.Supplier.Required = true;

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
        this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = true;
        this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = true;
        this.ChattelDocumentDetailsWithPurchase.DeleteButtonWidth = 100;
        this.ChattelDocumentDetailsWithPurchase.Height = 350;

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
        this.MaterialStockActionDetailIn.AutoCompleteDialogWidth = "90%";
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetailIn.Name = "MaterialStockActionDetailIn";
        this.MaterialStockActionDetailIn.Width = 500;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = "Amount";
        this.AmountStockActionDetailIn.Required = true;
        this.AmountStockActionDetailIn.Format = "N2";
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 4;
        this.AmountStockActionDetailIn.HeaderText = i18n("M19030", "Miktar");
        this.AmountStockActionDetailIn.Name = "AmountStockActionDetailIn";
        this.AmountStockActionDetailIn.Width = 120;
        this.AmountStockActionDetailIn.IsNumeric = true;

        this.UnitPriceStockActionDetailInWithOutVat = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailInWithOutVat.DataMember = "UnitPriceWithOutVat";
        this.UnitPriceStockActionDetailInWithOutVat.Required = true;
        this.UnitPriceStockActionDetailInWithOutVat.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailInWithOutVat.DisplayIndex = 5;
        this.UnitPriceStockActionDetailInWithOutVat.HeaderText = i18n("M17472", "KDV'siz Fiyatı");
        this.UnitPriceStockActionDetailInWithOutVat.Name = "UnitPriceStockActionDetailInWithOutVat";
        this.UnitPriceStockActionDetailInWithOutVat.Width = 120;
        this.UnitPriceStockActionDetailInWithOutVat.IsNumeric = true;

        this.ValueAddedTax = new TTVisual.TTTextBoxColumn();
        this.ValueAddedTax.DataMember = "VatRate";
        this.ValueAddedTax.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.ValueAddedTax.DisplayIndex = 6;
        this.ValueAddedTax.HeaderText = i18n("M17457", "KDV Oranı");
        this.ValueAddedTax.Name = "ValueAddedTax";
        this.ValueAddedTax.ReadOnly = true;
        this.ValueAddedTax.Width = 120;
        this.ValueAddedTax.IsNumeric = true;

        this.UnitePriceWithVatNoDiscount = new TTVisual.TTTextBoxColumn();
        this.UnitePriceWithVatNoDiscount.DataMember = "UnitPriceWithInVat";
        this.UnitePriceWithVatNoDiscount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitePriceWithVatNoDiscount.DisplayIndex = 7;
        this.UnitePriceWithVatNoDiscount.HeaderText = i18n("M17468", "KDV'li Fiyatı");
        this.UnitePriceWithVatNoDiscount.Name = "UnitePriceWithVatNoDiscount";
        this.UnitePriceWithVatNoDiscount.ReadOnly = true;
        this.UnitePriceWithVatNoDiscount.Width = 120;
        this.UnitePriceWithVatNoDiscount.IsNumeric = true;

        this.MKYS_IndirimOranı = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimOranı.DataMember = "DiscountRate";
        this.MKYS_IndirimOranı.DisplayIndex = 8;
        this.MKYS_IndirimOranı.HeaderText = i18n("M16491", "İndirim Oranı");
        this.MKYS_IndirimOranı.Name = "MKYS_IndirimOranı";
        this.MKYS_IndirimOranı.Width = 120;
        this.MKYS_IndirimOranı.IsNumeric = true;

        this.UnitPriceStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.UnitPriceStockActionDetailIn.DataMember = "UnitPrice";
        this.UnitPriceStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPriceStockActionDetailIn.DisplayIndex = 9;
        this.UnitPriceStockActionDetailIn.HeaderText = i18n("M16484", "İnd. Birim Fiyat");
        this.UnitPriceStockActionDetailIn.Name = "UnitPriceStockActionDetailIn";
        this.UnitPriceStockActionDetailIn.ReadOnly = true;
        this.UnitPriceStockActionDetailIn.Width = 120;
        this.UnitPriceStockActionDetailIn.IsNumeric = true;

        this.MKYS_IndirimTutari = new TTVisual.TTTextBoxColumn();
        this.MKYS_IndirimTutari.DataMember = "DiscountAmount";
        this.MKYS_IndirimTutari.DisplayIndex = 10;
        this.MKYS_IndirimTutari.HeaderText = i18n("M16006", "Indirim Tutarı");
        this.MKYS_IndirimTutari.Name = "MKYS_IndirimTutari";
        this.MKYS_IndirimTutari.ReadOnly = true;
        this.MKYS_IndirimTutari.Width = 120;
        this.MKYS_IndirimTutari.IsNumeric = true;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "Price";
        this.TotalPrice.DisplayIndex = 11;
        this.TotalPrice.HeaderText = i18n("M23526", "Toplam Tutar");
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.ReadOnly = true;
        this.TotalPrice.Width = 120;
        this.TotalPrice.IsNumeric = true;

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
        this.ExpirationDateStockActionDetailIn.Width = 180;

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
        this.MKYS_UretimTarihi.Width = 180;

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
        this.DemandAmountsGrid.Height = 350;

        this.DA_Material = new TTVisual.TTListBoxColumn();
        this.DA_Material.ListDefName = "MaterialListDefinition";
        this.DA_Material.DisplayIndex = 0;
        this.DA_Material.AutoCompleteDialogHeight = '60%';
        this.DA_Material.AutoCompleteDialogWidth = '90%';
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

        this.OrderedSuppliersGridColumns = [this.ttlistboxcolumn1, this.OrderNo];
        this.OrderedDetailsColumns = [this.datagridviewcolumn1, this.ttlistboxcolumn2, this.tttextboxcolumn2, this.datagridviewcolumn2];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentDetailsWithPurchaseColumns = [this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount, this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi];
        this.DemandAmountsGridColumns = [this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount];
        this.AvailableOrdersTab.Controls = [this.ttlabel7, this.OrderedSuppliersGrid, this.OrderedDetails, this.ttlabel8, this.cmdTransfer];
        this.PictureTabpage.Controls = [this.invoicePictureControl];
        this.DescriptionAndSignTabControl.Controls = [this.PictureTabpage, this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.ChattelDocumentTabcontrol.Controls = [this.AvailableOrdersTab, this.ChattelDocumentDetailTabpage, this.DistributionsTab, this.SignTabpage];
        this.ChattelDocumentDetailTabpage.Controls = [this.ChattelDocumentDetailsWithPurchase];
        this.DistributionsTab.Controls = [this.DemandAmountsGrid];
        this.Controls = [this.AvailableOrdersTab, this.PictureTabpage, this.TTTeslimEdenButon, this.ttlabel7, this.invoicePictureControl, this.TTTeslimAlanButon, this.OrderedSuppliersGrid, this.Waybill, this.labelMKYS_TeslimEden, this.ttlistboxcolumn1, this.RegistrationAuctionNo, this.MKYS_TeslimEden, this.OrderNo, this.txtTotalPrice, this.MKYS_TeslimAlan, this.OrderedDetails, this.ExaminationReportNo, this.Description, this.datagridviewcolumn1, this.ConclusionNumber, this.StockActionID, this.ttlistboxcolumn2, this.labelWaybillDate, this.labelMKYS_TeslimAlan, this.tttextboxcolumn2, this.WaybillDate, this.labelTransactionDate, this.datagridviewcolumn2, this.GetWaybill, this.TransactionDate, this.ttlabel8, this.labelWaybill, this.labelStockActionID, this.cmdTransfer, this.labelBudgetTypeDefinition, this.DescriptionAndSignTabControl, this.firmdef_ttbutton, this.BudgetTypeDefinition, this.SignTabpage, this.chkFreeEntry, this.labelStore, this.StockActionSignDetails, this.Store, this.SignUserType, this.labelRegistrationAuctionNo, this.SignUser, this.labelAuctionDate, this.IsDeputy, this.AuctionDate, this.ttlabel1, this.labelExaminationReportNo, this.labelExaminationReportDate, this.ExaminationReportDate, this.labelConclusionNumber, this.labelConclusionDateTime, this.ConclusionDateTime, this.labelSupplier, this.Supplier, this.ChattelDocumentTabcontrol, this.ChattelDocumentDetailTabpage, this.ChattelDocumentDetailsWithPurchase, this.Detail, this.MaterialStockActionDetailIn, this.Barcode, this.DistributionType, this.AmountStockActionDetailIn, this.UnitPriceStockActionDetailInWithOutVat, this.ValueAddedTax, this.UnitePriceWithVatNoDiscount, this.MKYS_IndirimOranı, this.UnitPriceStockActionDetailIn, this.MKYS_IndirimTutari, this.TotalPrice, this.LotNo, this.ExpirationDateStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.StatusStockActionDetailIn, this.MKYS_EdinimYili, this.MKYS_UretimTarihi, this.DistributionsTab, this.DemandAmountsGrid, this.DA_Material, this.DA_MasterResource, this.DA_DemandAmount, this.DA_DistributionAmount, this.txtDiscount, this.txtWithKDV, this.txtNotKDV, this.ttlabel2, this.ttlabel3, this.MKYS_EAlimYontemi, this.labelMKYS_EMalzemeGrup, this.MKYS_ETedarikTuru, this.labelMKYS_ETedarikTuru, this.MKYS_EMalzemeGrup, this.labelMKYS_EAlimYontemi, this.ttlabel4, this.ttlabel5];

    }


}
