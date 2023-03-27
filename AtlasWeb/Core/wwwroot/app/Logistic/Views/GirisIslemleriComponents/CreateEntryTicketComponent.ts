import { Component, OnInit, ViewChild, Input, EventEmitter, Output } from '@angular/core';
import { BaseComponent } from 'app/Fw/Components/BaseComponent';
import { MainViewModel } from 'app/Logistic/Models/MainViewModel';
import { ServiceContainer } from 'app/Fw/Services/ServiceContainer';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { MessageService } from 'app/Fw/Services/MessageService';
import { MKYS_EMalzemeGrupEnum, MKYS_ETedarikTurEnum, MKYS_EAlimYontemiEnum, ResUser, TasinirMalGirisTurEnum, DrugDefinition, StockActionDetailIn, DocumentTransactionTypeEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { GetInPatientPhysicianApplications_Output, StockActionService, SendUTSUpdateTS_Input } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { ResUserService } from 'app/NebulaClient/Services/ObjectService/ResUserService';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DxAccordionComponent } from 'devextreme-angular';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'app/NebulaClient/Mscorlib/IntegerParam';
import { MaterialSelectorInput, NewMaterialService } from '../NewMaterialSelectComponent';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { ChattelDocumentWithPurchaseService } from 'app/NebulaClient/Services/ObjectService/ChattelDocumentWithPurchaseService';


@Component({
    selector: 'create-entry-ticket',
    templateUrl: './CreateEntryTicketComponent.html',
    styles: [`
        `]

})

export class CreateEntryTicketComponent extends BaseComponent<MainViewModel> implements OnInit {
    @ViewChild('mainAccordion') accordion: DxAccordionComponent;
    @Input("askForMaterialGroup") materialGroupRequired: boolean;
    MaterialInput: MaterialSelectorInput = new MaterialSelectorInput;
    MKYSInputModel: MKYSInputModel = new MKYSInputModel();
    hiddenItems: any = {};
    budgetTypeSource: any[] = [];
    model: EntryTicketModel = new EntryTicketModel();
    materialGroup: MKYS_EMalzemeGrupEnum;
    materialDataSource: DataSource;
    supplierGridDataSource: DataSource;
    accountancyGridDataSource: DataSource;
    materialGridDataSource: any[] = [];
    selectedItem: any;
    editItem: any;
    selectedItemName: string;
    supplyTypeDisabled: boolean = false;
    bgButtonEnabled: boolean = true;
    isRecordTypeOpened: boolean = false;
    isSupplierOpened: boolean = false;
    isAccountancyOpened: boolean = false;
    supplierHaveNoCode: boolean = false;
    accountancyHaveNoCode: boolean = false;
    isSupplyTypeOpened: boolean = false;
    supplyTypeDataSource: EnumItem[];
    patientSpecialKey: string;
    findPatient: boolean = false;
    buyMethodDataSource: EnumItem[];
    buyMethodRequired: boolean = false;
    receiptColor: string = "#4caf50";
    ticketColor: string = "#4caf50";
    selectedCompanyItem: any;
    selectedSupplierItem: any;
    materialSupplier: string = "";
    materialSupplierId: Guid;
    materialSupplierNumber: string;
    isEditSupplierOpened: boolean = false;
    UTSLot: string;
    UTSAlma: string;
    UTSVerme: string;
    stockactionDetainInObjID: string;
    activeInputDetail: StockActionDetailIn = null;
    showUTSUpdatePopup: boolean = false;
    isEditUTSVisible: boolean = false;
    isPrintEnabled: boolean = false;
    isMKYSVisible: boolean = false;
    isDigerVisible: boolean = false;
    recordTypes = [
        {
            TypeId: 1,
            TypeName: 'Kesin Kayıt'
        },
        {
            TypeId: 2,
            TypeName: 'Ön Kayıt'
        }
    ];
    public materialGridColumns = GridColumns.Columns(this.isEditUTSVisible);

    constructor(container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService,
        protected activeUserService: IActiveUserService, private reportService: AtlasReportService) {
        super(container);
    }

    materialEditClick(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        this.selectedItem = e.data;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code  
            this.editItem = e.data;
        }

    }
    toggleMKYS() {
        this.isMKYSVisible = !this.isMKYSVisible;
    }

    toggleDiger() {
        this.isDigerVisible = !this.isDigerVisible;
    }

    cancelStockAction() {
        this.httpService.post<any>('/api/EntryOperation/CancelStockAction', this.model.StockActionObjectId).then(p => {
            if (p) {
                ServiceLocator.MessageService.showInfo("İşlem iptal edilmiştir.");
            }
        }).catch(e => {
            ServiceLocator.MessageService.showError(e);
        });
    }

    @Output() public onEditClose: EventEmitter<any> = new EventEmitter<any>();
    closeStockAction() {
        this.onEditClose.emit();
    }

    async getDocument() {
        this.model = await ChattelDocumentWithPurchaseService.GetWaybillForInputDocument(this.model.MainStoreId, this.model.BreederDocumentNumber);

        if (this.model) {
            this.model.SupplyType = MKYS_ETedarikTurEnum.satinalma;
            this.supplyTypeDisabled = true;
            this.bgButtonEnabled = false;
            this.materialGridDataSource = this.model.MaterialList;
        }
    }

    updateTicketDate() {
        this.MaterialInput.TicketDate = this.model.TicketDate;
    }

    ngOnInit() {
        this.model.TicketDate = new Date();
        this.updateTicketDate();
        this.getBudgetTypes();
        this.model.MainStore = this.activeUserService.SelectedUserStore.Name;
        this.model.MainStoreId = this.activeUserService.SelectedUserStore.ObjectID;
        this.supplyTypeDataSource = MKYS_ETedarikTurEnum.Items;
        this.buyMethodDataSource = MKYS_EAlimYontemiEnum.Items;
        this.updateAmounts();
        StockActionService.onRowClicked.subscribe((e) => {
            this.model = e.model as EntryTicketModel;
            this.receiptColor = this.model.ReceiptNumber > 0 ? '#4caf50' : 'red';
            this.ticketColor = this.model.TicketNumber > 0 ? '#4caf50' : 'red';
            this.MaterialInput.MaterialGroup = e.model.MaterialGroup;
            this.materialGridDataSource = e.model.MaterialList;
            this.isEditUTSVisible = e.model.MaterialGroup == MKYS_EMalzemeGrupEnum.tibbiSarf;
            this.isPrintEnabled = true;
            this.updateAmounts();
            this.MKYSInputModel.ReceiptNumber = e.model.ReceiptNumber;
            this.MKYSInputModel.SentDisable = this.model.ReceiptNumber > 0;
            this.MKYSInputModel.RemoveDisable = !this.MKYSInputModel.SentDisable;
            this.MKYSInputModel.LogOpDisable = this.MKYSInputModel.RemoveDisable;
            this.MKYSInputModel.QueryDisable = false;
            this.MKYSInputModel.StockActionId = e.model.StockActionObjectId;
            this.MKYSInputModel.UTSReceiveNotifDisable = this.model.TicketNumber > 0;
            this.bgButtonEnabled = false;
        });
        this.MKYSInputModel.SentDisable = true;
        this.MKYSInputModel.RemoveDisable = true;
        this.MKYSInputModel.LogOpDisable = true;
        this.MKYSInputModel.UTSReceiveNotifDisable = true;
        StockActionService.onCreateClicked.subscribe((e) => {
            this.reloadComponent();
        });
        this.activeUserService.onStoreChangeEvent.subscribe(() => {
            this.model.MainStore = this.activeUserService.SelectedUserStore.Name;
            this.model.MainStoreId = this.activeUserService.SelectedUserStore.ObjectID;
        });
        NewMaterialService.onMaterialAdd.subscribe((e) => {
            for (let item of e) {
                this.materialGridDataSource.push(item);
            }
        });
    }

    clientPreScript(): void {
        if (!this.materialGroupRequired) {
            this.askForMaterialGroup();
        }
    }
    clientPostScript(state: String): void {

    }

    reloadComponent() {
        this.accordion.instance.expandItem(0);
        this.model = new EntryTicketModel();
        this.materialGridDataSource.Clear();
    }

    onToolbarPreparing(e) {

    }

    changeDropDownBoxValue(e) {
        this.isRecordTypeOpened = false;
        this.model.RecordType = e.addedItems[0].TypeId;
    }

    checkRequiredFields(model) {
        if (!model.TicketDate) {
            ServiceLocator.MessageService.showError("Fiş tarihi zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!model.BudgetType) {
            ServiceLocator.MessageService.showError("Bütçe türü zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!model.SupplyType && model.SupplyType != 0) {
            ServiceLocator.MessageService.showError("Tedarik türü zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (model.SupplyType == MKYS_ETedarikTurEnum.satinalma && !model.BuyMethod) { //Satın alma seçildi ise zorunlu
            ServiceLocator.MessageService.showError("Alım yöntemi zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!model.BreederDocumentNumber || String.isNullOrEmpty(model.BreederDocumentNumber)) {
            ServiceLocator.MessageService.showError("Dayanak belge numarası zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!model.BreederDocumentDate) {
            ServiceLocator.MessageService.showError("Dayanak belge tarihi zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!model.Deliverer) {
            ServiceLocator.MessageService.showError("Teslim eden zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!model.TakenByName || String.isNullOrEmpty(model.TakenByName)) {
            ServiceLocator.MessageService.showError("Teslim alan zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        return true;
    }

    async clickSave(e) {
        if (!this.checkRequiredFields(this.model)) {
            return;
        }
        var model = this.model;
        this.model.MaterialList = this.materialGridDataSource;
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Vazgeç", "E,V", i18n("M23735", "Uyarı"), "Uyarı", "Dikkat! Bu uyarı doğrulama amaçlıdır. Fişinizin toplam değeri " + this.model.TotalAmount + " TL'dir. Yanlış ise fişinizi kontrol ediniz.");
        if (messageResult === "E") {
            let mkysResult: string;
            if (this.model.RecordType == 1) {
                mkysResult = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "MKYS'ye Gönder", "Giriş Fişini MKYS'ye göndermek istiyor musunuz?");
                this.model.SendToMKYS = mkysResult == "E";
            }
            if (this.model.SendToMKYS) {
                let result = await UsernamePwdBox.Show(true);
                let params = <any>(<ModalActionResult>result).Param;
                this.model.MKYSPassword = params.password;
            }
            this.httpService.post<any>('/api/EntryOperation/SaveOperation', model).then(p => {
                if (p) {
                    ServiceLocator.MessageService.showInfo(p);
                    this.printReport();
                }
            }).catch();
        } else {
            ServiceLocator.MessageService.showInfo("Kaydetme işleminden vazgeçildi.");
        }
    }

    printClick() {
        this.printReport();
    }

    protected async printReport(): Promise<void> {

        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this.model.StockActionObjectId.toString());
        for (let document of documentRecordLogs) {
            //if (this.model.IsPTSAction == false) 
            {
                if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                    const objectIdParam = new GuidParam(document['ObjectID']);
                    const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                    this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
                    this.reportService.showReport('ExaminationChattelDocumentInDetailReport', reportParameters);
                }
            }
            //else 
            // {
            //     if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
            //         const objectIdParam = new GuidParam(document['ObjectID']);
            //         const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
            //         let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
            //         this.reportService.showReport('ChattelDocumentInDetailReportPTS', reportParameters);
            //         this.reportService.showReport('ExaminationChattelDocumentInDetailReportPTS', reportParameters);
            //     }
            // }
        }

    }


    openCompanyList() {
        this.isSupplierOpened = true;
        this.getSuppliers();
    }

    openCompanyFromList() {
        this.isAccountancyOpened = true;
        this.getSuppliers();
    }

    onEditingStart(e) {
        this.materialSupplierId = e.data.MaterialSupplierId;
        this.materialSupplier = e.data.MaterialSupplier;
        this.materialSupplierNumber = e.data.MaterialSupplierNumber;
    }

    openSupplierPopup(e) {
        this.isEditSupplierOpened = true;
        this.getSuppliers();
    }

    setCompany() {
        if (this.selectedCompanyItem) {
            this.model.CompanyFrom = this.selectedCompanyItem.Name;
            this.model.CompanyFromId = this.selectedCompanyItem.ObjectID;
        }
        this.isAccountancyOpened = false;
    }

    onMaterialUpdated(e) {
        this.updateAmounts();
        if (this.materialSupplierId) {
            let temp = e.data.Amount;
            e.data.Amount = "";
            e.data.Amount = temp;
            e.data.MaterialSupplierId = this.materialSupplierId;
            e.data.MaterialSupplierNumber = this.materialSupplierNumber;
            e.data.MaterialSupplier = this.materialSupplier;
            this.materialSupplierId = undefined;
            this.materialSupplier = "";
            this.materialSupplierNumber = "";
        }
    }

    async ShowUTSUpdateModal(value: any): Promise<void> {
        this.UTSLot = "";
        this.UTSAlma = "";
        this.UTSVerme = "";

        if (value) {
            this.activeInputDetail = <StockActionDetailIn>value.data;
            this.stockactionDetainInObjID = this.activeInputDetail.ObjectID.toString();
            this.showUTSUpdatePopup = true;
            this.UTSLot = this.activeInputDetail.LotNo;
            this.UTSAlma = this.activeInputDetail.ReceiveNotificationID;
            this.UTSVerme = this.activeInputDetail.IncomingDeliveryNotifID;
        }
        else {
            this.showUTSUpdatePopup = false;
            this.activeInputDetail = null;
            ServiceLocator.MessageService.showInfo("İlgili satıra ait güncelleme yapılamaz.");
        }
    }

    async SaveUTSUpdate() {
        if (String.isNullOrEmpty(this.UTSLot) == false && String.isNullOrEmpty(this.UTSVerme) == false) {
            try {
                let input: SendUTSUpdateTS_Input = new SendUTSUpdateTS_Input();
                input.StockActionDetailInObjID = this.stockactionDetainInObjID;
                input.newLot = this.UTSLot;
                input.newUTSAlma = this.UTSAlma;
                input.newUTSVerme = this.UTSVerme;
                await StockActionService.SendUTSUpdateTS(input).then(response => {
                    let result = <boolean>response;
                    if (result) {
                        ServiceLocator.MessageService.showInfo("İşlem Başarılı");
                        this.showUTSUpdatePopup = false;
                        this.activeInputDetail.LotNo = input.newLot;
                        this.activeInputDetail.ReceiveNotificationID = input.newUTSAlma;
                        this.activeInputDetail.IncomingDeliveryNotifID = input.newUTSVerme;
                    }
                    else {
                        ServiceLocator.MessageService.showError("İşlem Başarısız");
                    }
                }).catch(error => { throw error; });
            }
            catch (ex) {
                this.showUTSUpdatePopup = false;
                this.activeInputDetail = null;
                throw ex;
            }
        } else {
            this.activeInputDetail = null;
            ServiceLocator.MessageService.showInfo("Alanlar Boş bırakılamaz.");
        }
    }

    async CancelUTSUpdate() {
        this.showUTSUpdatePopup = false;
        this.activeInputDetail = null;
        ServiceLocator.MessageService.showInfo("İşlemden vazgeçildi.");
    }


    updateAmounts() {
        this.model.WithVatRateTotal = 0;
        this.model.WithoutVatRateTotal = 0;
        this.model.TotalAmount = 0;
        this.model.TotalDiscount = 0;
        for (var item of this.materialGridDataSource) {
            if (item.Amount != undefined && item.UnitPriceWithOutVat != undefined) {
                this.model.WithoutVatRateTotal += item.Amount * item.UnitPriceWithOutVat;
            }
            if (item.VatRate != undefined && item.UnitPriceWithOutVat != undefined) {
                item.UnitPriceWithInVat = item.UnitPriceWithOutVat + item.VatRate * item.UnitPriceWithOutVat / 100;
            }
            if (item.Amount != undefined && item.UnitPriceWithInVat != undefined) {
                this.model.WithVatRateTotal += item.Amount * item.UnitPriceWithInVat;
            }
            if (item.UnitPriceWithInVat != undefined && item.DiscountRate != undefined) {
                item.UnitPrice = item.UnitPriceWithInVat - item.UnitPriceWithInVat * item.DiscountRate / 100;
                item.NotDiscountedUnitPrice = item.UnitPriceWithInVat;
                item.Price = item.UnitPrice * item.Amount;
            }
            if (item.DiscountAmount != undefined) {
                this.model.TotalDiscount += item.DiscountAmount;
            } else if (item.Amount != undefined && item.UnitPriceWithInVat != undefined && item.UnitPrice != undefined) {
                this.model.TotalDiscount += item.Amount * (item.UnitPriceWithInVat - item.UnitPrice);
            }
            if (item.Price != undefined) {
                this.model.TotalAmount += item.Price;
            }



        }
        this.model.WithVatRateTotalStr = this.model.WithVatRateTotal.toFixed(2);
        this.model.WithoutVatRateTotalStr = this.model.WithoutVatRateTotal.toFixed(2);
        this.model.TotalAmountStr = this.model.TotalAmount.toFixed(2);
        this.model.TotalDiscountStr = this.model.TotalDiscount.toFixed(2);
    }



    openSupplierList() {
        this.getSuppliers();
    }






    onEditorPrepared(e) {
        if (e.parentType == "dataRow" && e.component.columnOption(e.dataField, "validationRules")) {
            setTimeout(function () {
                var validator = null;
                try {
                    if (e.row.rowType == "data")
                        validator = $(e.editorElement).dxValidator("instance");
                    else
                        validator = $(e.editorElement).parent().parent().dxValidator("instance");
                }
                catch (e) {

                }

                if (validator)
                    validator.validate();
            }, 100)
        }
    }




    getSuppliers() {
        this.supplierGridDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SupplierList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/EntryOperation/GetSuppliers', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    getAccountancyList() {
        this.accountancyGridDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'AccountancyList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/EntryOperation/GetAccountancyList', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    selectSupplier(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code 
            if (e.data.Code) {
                this.model.Company = e.data.Name;
                this.model.CompanyId = e.data.ObjectID;
                this.isSupplierOpened = false;
            } else {
                this.supplierHaveNoCode = true;
            }
        }
    }

    selectLookupSupplier(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code 
            if (e.data.Code) {
                this.materialSupplier = e.data.Name;
                this.materialSupplierId = e.data.ObjectID;
                this.materialSupplierNumber = e.data.SupplierNumber;
                this.isEditSupplierOpened = false;
            }
        }
    }

    selectAccountancy(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code 
            if (e.data.AccountancyCode) {
                this.model.CompanyFrom = e.data.Name;
                this.model.CompanyFromId = e.data.ObjectID;
                this.isAccountancyOpened = false;
            } else {
                this.accountancyHaveNoCode = true;
            }
        }
    }

    closePopup() {
        this.accountancyHaveNoCode = false;
        this.supplierHaveNoCode = false;
    }

    getBudgetTypes() {
        this.httpService.get<any>('/api/EntryOperation/GetBudgetTypes').then(p => {
            if (p) {
                for (var item of p) {
                    this.budgetTypeSource.push({
                        ObjectID: item.ObjectID,
                        Name: item.Name,
                        Code: item.Code
                    });
                }
            }
        }).catch(e => console.log(e));
    }

    supplyTypeChanged(e) {
        this.buyMethodRequired = e.value == MKYS_ETedarikTurEnum.satinalma;
        if (!this.buyMethodRequired) {
            this.model.BuyMethod = MKYS_EAlimYontemiEnum.bos;
        } else {
            this.model.BuyMethod = undefined;
        }
        this.hiddenItems = {
            patientSpecialVisible: this.TasinirMalGirisTurleri(e.value),
            supplierVisible: this.model.SupplyType == MKYS_ETedarikTurEnum.satinalma || this.model.SupplyType == MKYS_ETedarikTurEnum.bagisVeYardim,
            companyVisible: TasinirMalGirisTurEnum.Items.filter(p => p.code == this.model.SupplyType).length > 0,
            buyMethodVisible: this.buyMethodRequired
        };
    }

    TasinirMalGirisTurleri(selected) {
        let items = [];
        for (let item of TasinirMalGirisTurEnum.Items) {
            items.push(item.code);
        }
        items.push(MKYS_ETedarikTurEnum.satinalma);
        return items.filter(p => p == selected).length > 0;
    }

    contentReady(e) {
        e.component.columnOption("command:edit", "visibleIndex", -1);
    }

    async askForMaterialGroup() {
        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        mSelectForm.AddMSItem(i18n("M23417", "Tıbbi Sarf"), i18n("M23417", "Tıbbi Sarf"), MKYS_EMalzemeGrupEnum.tibbiSarf);
        mSelectForm.AddMSItem(i18n("M16287", "İlaç"), i18n("M16287", "İlaç"), MKYS_EMalzemeGrupEnum.ilac);
        mSelectForm.AddMSItem(i18n("M23359", "Tıbbi Cihaz"), i18n("M23359", "Tıbbi Cihaz"), MKYS_EMalzemeGrupEnum.tibbiCihaz);
        mSelectForm.AddMSItem(i18n("M12780", "Diğer"), i18n("M12780", "Diğer"), MKYS_EMalzemeGrupEnum.diger);
        let mkey: string = await mSelectForm.GetMSItem(this, i18n("M14806", "Giriş Yapılacak Malzeme Grubunu Seçiniz"), true);
        if (String.isNullOrEmpty(mkey)) {
            this.messageService.showError(i18n("M18579", "Malzeme grubu seçilmeden işleme devam edemezsiniz."));
        }
        this.MaterialInput.MaterialGroup = <MKYS_EMalzemeGrupEnum>mSelectForm.MSSelectedItemObject;
        this.model.MaterialGroup = <MKYS_EMalzemeGrupEnum>mSelectForm.MSSelectedItemObject;
    }

    openUserList(isTakenBy) {
        if (isTakenBy) {
            this.getAllActiveUsers('Teslim Alan Personeli Seçin', isTakenBy);
        } else {
            this.getAllActiveUsers('Teslim Eden Personeli Seçin', isTakenBy);
        }
    }

    async getAllActiveUsers(title, isTakenBy) {
        let resUser: Array<ResUser> = (await ResUserService.GetAllUser('WHERE ISACTIVE = 1 '));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this, i18n("M23234", title));
        if (String.isNullOrEmpty(key)) {
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        } else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            if (isTakenBy) {
                this.model.TakenBy = selectedPersonel.ObjectID;
                this.model.TakenByName = selectedPersonel.Name.toString();
            } else {
                this.model.Deliverer = selectedPersonel.ObjectID;
                this.model.DelivererName = selectedPersonel.Name.toString();
            }

        }
    }

    async findPatientClick() {

        let inApps: Array<GetInPatientPhysicianApplications_Output> = await StockActionService.GetInPatientPhysicianApplications(this.patientSpecialKey);
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();

        let count: number = 0;
        for (let inApp of inApps) {
            multiSelectForm.AddMSItem(inApp.Key, inApp.Key, inApp);
            count++;
        }

        let mlotKey: string = await multiSelectForm.GetMSItem(null, "Yatış Seçiniz", true);
        if (multiSelectForm.MSSelectedItemObject !== null) {
            let selectedInApp: GetInPatientPhysicianApplications_Output = multiSelectForm.MSSelectedItemObject as GetInPatientPhysicianApplications_Output;
            if (selectedInApp.InvoiceControl == false) {
                this.model.InPatientPhysicianApplication = selectedInApp.InPatientPhysicianApplication.ObjectID;
                this.patientSpecialKey = selectedInApp.PatientInfo;
                this.model.Description = selectedInApp.Description;
                this.findPatient = true;
            } else {
                TTVisual.InfoBox.Alert("Seçilen Hastanın Faturası Kesilmiştir. Önce Faturanın İptali Gerekmektedir");
            }

        }
    }

}

export class MKYSInputModel {
    ReceiptNumber: number;
    StockActionId: Guid;
    SentDisable: boolean = false;
    RemoveDisable: boolean = false;
    QueryDisable: boolean = false;
    LogOpDisable: boolean = false;
    MaterialList: any[];
    UTSReceiveNotifDisable: boolean = false;
}

export class EntryTicketModel {
    StockActionObjectId: Guid;
    OperationNumber: number; // otomatik üret -> readonly ?
    TicketDate: Date;
    TicketNumber: number;
    MainStoreId: Guid;
    MainStore: string; //readonly
    BudgetType: Guid;
    RecordType: number = 1; //Kesin Kayıt(default), Ön Kayıt
    Company: string;
    CompanyId: Guid;
    CompanyFrom: string;
    CompanyFromId: Guid;
    SupplyType: number;
    BuyMethod: number;
    TenderDate: Date;
    TenderNumber: string; //alfanumerik
    ControlDate: Date; //tedarik türü satın alma ise zorunlu
    ControlNumber: number; //tedarik türü satın alma ise zorunlu
    BreederDocumentDate: Date;
    BreederDocumentNumber: string; //alfanumerik
    Deliverer: Guid;  //personel listesi
    DelivererName: string;
    TakenBy: Guid; //personel listesi
    TakenByName: string;
    PatientOnly: boolean;
    Description: string;
    ReceiptNumber: number;
    OperationTicketNumber: number;
    CreatedBy: string;
    CreateDate: Date;
    WithVatRateTotalStr: string;
    WithoutVatRateTotalStr: string;
    TotalDiscountStr: string;
    TotalAmountStr: string;
    WithVatRateTotal: number = 0;
    WithoutVatRateTotal: number = 0;
    TotalDiscount: number = 0;
    IsFormReadOnly: boolean = false;
    TotalAmount: number = 0;
    MaterialList: any[];
    MaterialGroup: MKYS_EMalzemeGrupEnum;
    InPatientPhysicianApplication: Guid;
    NotDiscountedUnitPrice: number;
    UnitPrice: number;
    SendToMKYS: boolean = false;
    MKYSPassword: string;

    checkRequiredFields() {
        if (!this.TicketDate) {
            ServiceLocator.MessageService.showError("Fiş tarihi zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!this.BudgetType) {
            ServiceLocator.MessageService.showError("Bütçe türü zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!this.SupplyType && this.SupplyType != 0) {
            ServiceLocator.MessageService.showError("Tedarik türü zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (this.SupplyType == MKYS_ETedarikTurEnum.satinalma && !this.BuyMethod) { //Satın alma seçildi ise zorunlu
            ServiceLocator.MessageService.showError("Alım yöntemi zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!this.BreederDocumentNumber || String.isNullOrEmpty(this.BreederDocumentNumber)) {
            ServiceLocator.MessageService.showError("Dayanak belge numarası zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!this.BreederDocumentDate) {
            ServiceLocator.MessageService.showError("Dayanak belge tarihi zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!this.Deliverer) {
            ServiceLocator.MessageService.showError("Teslim eden zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        if (!this.TakenByName || String.isNullOrEmpty(this.TakenByName)) {
            ServiceLocator.MessageService.showError("Teslim alan zorunlu alandır. Boş bırakılamaz.");
            return false;
        }
        return true;
    }
}

export class GridColumns {
    public static Columns(isEditUTSVisible) {
        return [
            {
                caption: ' ',
                dataField: 'ObjectID',
                cellTemplate: 'editButtonTemplate',
                visible: isEditUTSVisible,
                allowEditing: false,
                width: 50
            },
            {
                caption: 'ObjectID',
                dataField: 'ObjectID',
                cellTemplate: 'buttonCellTemplate',
                visible: false,
                allowEditing: false,
                width: 120
            },
            {
                caption: i18n("M18550", "Malzeme Adı"),
                dataField: 'Name',
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
                caption: i18n("M19030", "Miktar"),
                dataField: 'Amount',
                validationRules: [{ type: 'required', message: 'Miktar Alanı Boş Geçilemez' }],
                dataType: 'number',
                width: 120
            },
            {
                caption: i18n("M17464", "KDV\'siz Fiyatı"),
                dataField: 'UnitPriceWithOutVat',
                validationRules: [{ type: 'required', message: 'KDV\'siz Fiyatı Alanı Boş Geçilemez' }],
                dataType: 'number',
                width: 'auto'
            },
            {
                caption: i18n("M17457", "KDV Oranı"),
                dataField: 'VatRate',
                validationRules: [{ type: 'required', message: 'KDV Oranı Alanı Boş Geçilemez' }],
                dataType: 'number',
                width: 100
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
                validationRules: [{ type: 'required', message: 'İndirim Oranı Alanı Boş Geçilemez' }],
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
                caption: 'Firma',
                dataField: 'MaterialSupplierNumber',
                allowEditing: false,
                width: 120
            },
            {
                caption: 'Firma',
                dataField: 'MaterialSupplierId',
                allowEditing: false,
                visible: false,
                width: 120
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
                validationRules: [{ type: 'required', message: 'Son Kullanma Tarihi Alanı Boş Geçilemez' }],
                format: 'dd/MM/yyyy',
                width: 150
            },
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
            }
        ]
    }
}