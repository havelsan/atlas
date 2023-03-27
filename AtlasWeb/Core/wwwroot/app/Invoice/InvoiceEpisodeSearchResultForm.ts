//$8ACE6D7E
import { Component, AfterViewInit } from '@angular/core';
import { InvoiceEpisodeSearchResultFormModel, InvoiceEpisodeResultGrid } from "./InvoiceEpisodeSearchResultFormViewModel";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Guid } from "NebulaClient/Mscorlib/Guid";

import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { InvoiceSearchResultModel } from "./InvoiceSEPSearchFormViewModel";
import { CollectiveOperationResultCount } from './InvoiceHelperModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { CollectiveInvoiceOpTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { ComboListItem } from 'NebulaClient/Visual/ComboListItem';
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";

@Component({
    selector: "invoice-episode-search-result-form",
    templateUrl: './InvoiceEpisodeSearchResultForm.html'
})
export class InvoiceEpisodeSearchResultForm extends BaseComponent<any> implements AfterViewInit {

    public invoiceEpisodeSearchResultFormModel: InvoiceEpisodeSearchResultFormModel;
    public collectiveOperationStart: boolean = false;
    public showErrorListPopup: boolean = false;

    public searchResultHeight: number;
    public ErrorListColumns = [
        {
            caption: 'ID',
            dataField: 'ObjectID',
            width: '30%'
        },
        {
            caption: i18n("M22633", "Takip"),
            dataField: i18n("M22633", "Takip"),
            width: '10%'
        },
        {
            caption: i18n("M15542", "Hata Kodu"),
            dataField: 'Code',
            width: '10%'
        },
        {
            caption: i18n("M15545", "Hata Mesajı"),
            dataField: 'Message',
            width: '50%'
        }
    ];


    public InvoiceEpisodeSearchResultListColumns = [];

    GenerateResultListColumns(columnNameAndOrder: Array<string>) {
        let that = this;
        this.InvoiceEpisodeSearchResultListColumns = [
            {
                caption: i18n("M20566", "Protokol No"),
                dataField: 'HospitalProtocolNo',
                visible: false
            },
            {
                caption: i18n("M22936", "TC Kimlik No"),
                dataField: 'UniqueRefNo',
                visible: false
            },
            {
                caption: i18n("M10514", "Adı"),
                dataField: 'Patientname',
                visible: false
            },
            {
                caption: i18n("M22205", "Soyadı"),
                dataField: 'Patientsurname',
                visible: false
            },
            {
                caption: i18n("M24016", "Vaka Açılış T."),
                dataField: 'Date',
                dataType: 'date',
                format: 'dd.MM.yyyy',
                visible: false
            },
            {
                caption: i18n("M24446", "Yatış T."),
                dataField: 'InPatientDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
                visible: false
            },
            {
                caption: i18n("M12376", "Çıkış T."),
                dataField: 'DischargeDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
                visible: false
            },
            {
                caption: 'Durum',
                dataField: 'Status',
                visible: false
            },
            {
                caption: i18n("M23037", "Tedavi Türü"),
                dataField: 'Tedavituru',
                visible: false
            },
            {
                caption: i18n("M12048", "Branş"),
                dataField: 'Specialityname',
                visible: false
            },
            {
                caption: i18n("M18009", "Kurum"),
                dataField: 'Payername',
                visible: false
            },
            {
                caption: i18n("M15594", "HBYS Tutarı"),
                dataField: 'HBYSTutari',
                visible: false
            },
            {
                caption: 'F. Tutarı',
                dataField: 'FaturaTutari',
                visible: false
            },
            {
                caption: i18n("M16122", "İcmal Adı"),
                dataField: 'ICName',
                visible: false
            },
            {
                caption: i18n("M16136", "İcmal No"),
                dataField: 'ICNo',
                visible: false
            }

        ];
        let i = 0;
        if (columnNameAndOrder.length > 0) {
            for (let item of columnNameAndOrder) {
                for (let baseItem of this.InvoiceEpisodeSearchResultListColumns) {
                    if (item == baseItem.dataField) {
                        baseItem.visible = true;
                        baseItem.visibleIndex = i;
                        i++;
                    }
                }
            }

        }
        else {
            for (let baseItem of this.InvoiceEpisodeSearchResultListColumns) {
                baseItem.visible = true;
                baseItem.visibleIndex = i;
                i++;
            }
        }
    }

    gridRowCount(data: any) {
        return "Adet: " + data.value;
    }


    public visibleEpisodeSearchResultListColumns: any;
    onContentReadyEpisodeSearchResultList(e: any): void {
        this.visibleEpisodeSearchResultListColumns = e.component.getVisibleColumns();
    }


    public selectedRowKeysEpisodeResultList: Array<InvoiceEpisodeResultGrid> = [];

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';


    clientPostScript(state: String) {

    }

    clientPreScript() {

    }


    constructor(protected http: NeHttpService, services: ServiceContainer, private medulaService: GetMedulaDefinitionService, protected modalService: IModalService) {
        super(services);
        this.invoiceEpisodeSearchResultFormModel = new InvoiceEpisodeSearchResultFormModel();
        this.searchResultHeight = 600;
    }

    customizeMoney(data) {
        return Math.Round(data.value, 2);
    }


    public runningTaskID: any;
    public succesCount: number = 0;
    public errorCount: number = 0;
    public totalCount: number = 0;
    public errorList: any = [];
    public collectiveOperationPanel: boolean = false;

    format(value) {
        return i18n("M12321", "Çalışıyor : ") + Math.Round(value * 100, 2) + '%';
    }

    onClickExitCollectiveOperation(): void {
        this.collectiveOperationPanel = false;
    }

    onClickShowErrorList(): void {
        this.showErrorListPopup = true;
    }
    btnRefreshClicked(): void {
        this.loadForm();
    }

    ngAfterViewInit(): void {
        this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria = this.RouteData;

        this.loadForm();
    }

    loadForm(): void {
        let promiseArray: Array<Promise<any>> = new Array<any>();
        let that = this;
        let InvoiceSEPSearch: string = '/api/InvoiceApi/InvoiceSEPSearch';
        let apiUrlForInvoiceTransactionList: string = '/api/InvoiceApi/GetColumnAndOrder?gridName=InvoiceEpisodeSearchResultList&pageName=InvoiceEpisodeSearchResultForm';

        promiseArray.push(this.http.post<InvoiceSearchResultModel>(InvoiceSEPSearch, this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria));
        promiseArray.push(that.http.get(apiUrlForInvoiceTransactionList));

        Promise.all(promiseArray).then(sonuc => {
            this.invoiceEpisodeSearchResultFormModel.InvoiceEpisodeResultList = sonuc[0].EpisodeResultList;
            this.GenerateResultListColumns(sonuc[1]);
            this.generateTopMenu();
        });
    }
    errorHandlerForInvoiceForm(message: string): void {
        ServiceLocator.MessageService.showError(message);
        console.log(message);
    }
    disableTopMenu(isStart: boolean): void {
        if (isStart) {
            this.succesCount = 0;
            this.errorCount = 0;
        }
        this.collectiveOperationStart = isStart;
        this.generateTopMenu();
    }
    pushErrorList(code: any, message: any, takip: any, objectID: any): void {
        let error: any = {};
        error.Code = code;
        error.Message = message;
        error.Takip = takip;
        error.ObjectID = objectID;
        this.errorList.push(error);
        this.errorCount++;
    }
    prepareCollectiveOperationScreenAndProperty(): void {
        this.disableTopMenu(true);
        this.errorList = [];
        this.collectiveOperationPanel = true;
        this.totalCount = this.selectedRowKeysEpisodeResultList.length;
    }

    async icmalSec(): Promise<ComboListItem> {

        let aktifIcmal: any;
        let array: Array<ComboListItem> = new Array<ComboListItem>();

        if (this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.payer == null || this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.payer == undefined
            || this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.payer == null || this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.payer == undefined) {
            ServiceLocator.MessageService.showError("Kurum bilgisi seçilmemiş aramalarda toplu icmale ekleme işlemi yapılamaz. Lütfen kurum seçerek tekrar arama yapınız.");
            return;
        }

        let apiUrlForgetRule: string = '/api/CollectiveInvoiceOpTopMenuApi/uygunIcmalleriGetir?payerObjectID=' + this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.payer;

        let x = await this.http.get<Array<ComboListItem>>(apiUrlForgetRule);

        for (let item of x) {
            array.push(new ComboListItem(item.DataValue, item.DisplayText));
        }

        if (array.length > 0) {
            let selection = await InputForm.GetValueListItem('Icmal Seçim', array);

            if (!(selection.DataValue == undefined || selection.DataValue == null))
            { return selection; }
            else {
                ServiceLocator.MessageService.showError(i18n("M16142", "İcmal seçimi yapılmadı. Atılacak icmal seçilmeden devam edilemez."));
                return;
            }
        }
        else {
            ServiceLocator.MessageService.showError("Kuruma uygun herhangi bir açık icmal bulunamadı.");
            return;
        }
    }


    async PrepareCollectiveInvoiceOpWithObjectIDList(opType: number): Promise<Guid> {

        let pciom: any = {};
        pciom.objectIDList = new Array<any>();
        for (let item of this.selectedRowKeysEpisodeResultList)
            pciom.objectIDList.push(item.ObjectID);

        pciom.opType = opType;
        pciom.invoiceSearchType = this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType;
        pciom.invoiceResultListType = this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.searchResultType;

        if (opType == CollectiveInvoiceOpTypeEnum.AddInvoiceCollection) {
            let icmalID = await this.icmalSec();
            if (icmalID)
            { pciom.invoiceCollectionID = icmalID.DataValue; }
            else
            { return; }
        }

        if (pciom.objectIDList.length > 0) {

            let takipBazliHizmetKayitUrl = '/api/CollectiveInvoiceOpTopMenuApi/PrepareCollectiveInvoiceOpWithObjectIDList';
            let collectiveInvoiceOpObjectID = await this.http.post<Guid>(takipBazliHizmetKayitUrl, pciom);
            return collectiveInvoiceOpObjectID;
        }
    }

    GetCollectiveOperationResultCounts(cio: Guid): void {
        let GetCollectiveOperationResultCountsUrl = '/api/CollectiveInvoiceOpTopMenuApi/GetCollectiveOperationResultCounts?cioObjectID=' + cio;
        this.http.get<CollectiveOperationResultCount>(GetCollectiveOperationResultCountsUrl).then(result => {
            this.errorCount = result.errorCount;
            this.succesCount = result.succesCount;
            this.totalCount = result.succesCount + result.errorCount + result.newCount;
            this.errorList = result.errorList;

            if ((this.totalCount == this.succesCount + this.errorCount) && this.totalCount != 0) {
                clearInterval(this.runningTaskID);
                this.disableTopMenu(false);
            }
        });
    }
    execCollectiveOperation(cioObjectID: any): void {

        let ExecCollectiveOperationUrl = '/api/CollectiveInvoiceOpTopMenuApi/ExecCollectiveOperation?cioObjectID=' + cioObjectID;
        this.http.get<string>(ExecCollectiveOperationUrl);

        this.runningTaskID = setInterval(() => { this.GetCollectiveOperationResultCounts(cioObjectID); }, 10000);
    }

    async firstCallWithType(type: CollectiveInvoiceOpTypeEnum): Promise<void> {

        if (this.selectedRowKeysEpisodeResultList.length > 0) {
            this.prepareCollectiveOperationScreenAndProperty();

            let result = await this.PrepareCollectiveInvoiceOpWithObjectIDList(type);

            if (result != null && result != undefined)
            { this.execCollectiveOperation(result); }
            else
            { this.disableTopMenu(false); }

        }
        else
            ServiceLocator.MessageService.showError(i18n("M21563", "Seçili Takip/Başvuru olmadan toplu işlem başlatamazsınız. Lütfen seçim yapınız."));

    }

    onItemClickTopMenu(event: any): void {
        if (event.itemData.fnName !== undefined)
            this[event.itemData.fnName]();
    }

    private showNewInvoiceCollectionBoundForm(): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'InvoiceCollectionBoundForm';
            componentInfo.ModuleName = "MDS050FaturaIcmalModule";
            componentInfo.ModulePath = '/Modules/Doner_Sermaye_Saymanligi_Modulleri/MDS050_Fatura_Icmal/MDS050FaturaIcmalModule';
            let sepObjectIDs: Array<Guid> = new Array<Guid>();
            if (this.selectedRowKeysEpisodeResultList.length > 0) {
                this.selectedRowKeysEpisodeResultList.forEach(element => {
                    sepObjectIDs.push(element.ObjectID);
                });
            }
            componentInfo.InputParam = sepObjectIDs;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Yeni İcmal";
            modalInfo.Width = 1024;
            modalInfo.Height = 768;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    icmaleEkleFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.AddInvoiceCollection);
    }

    icmaldenCikarFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.RemoveInvoiceCollection);
    }

    searchResultClicked(event: any): void {
        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code

            let detailOpenParameters: any = {};
            detailOpenParameters.ObjectID = event.data.ObjectID;
            if (this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType != null && this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType != undefined)
                detailOpenParameters.Type = this.invoiceEpisodeSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType;
            else
                detailOpenParameters.Type = event.data.PayetTypeEnum;

            this.medulaService.tabMessage.next({ Params: detailOpenParameters, Title: event.data.HospitalProtocolNo + ' ' + event.data.Patientname + ' ' + event.data.Patientsurname });
        }
    }

    menuData = [];

    generateTopMenu(): void {
        this.menuData = [
            {
                id: 'provisionOperations',
                name: i18n("M22633", "Takip"),
                disabled: true,
                items: [
                    {
                        id: 'takipAl',
                        name: i18n("M22634", "Takip Al"),
                        fnName: 'takipAlFromTopMenu',
                    },
                    {
                        id: 'takipSil',
                        name: i18n("M22668", "Takip Sil"),
                        fnName: 'takipSilFromTopMenu'
                    }
                ]
            },
            {
                id: 'transactionOperations',
                name: i18n("M15818", "Hizmet"),
                disabled: true,
                items: [
                    {
                        id: 'takipBazliHizmetKayit',
                        name: 'Hizmet Kayıt',
                        fnName: 'takipBazliHizmetKayitFromTopMenu'
                    },
                    {
                        id: 'takipBazliHizmetKayitIptal',
                        name: i18n("M15884", "Hizmet Kayıt İptal"),
                        fnName: 'takipBazliHizmetKayitIptalFromTopMenu'
                    },
                    {
                        id: 'fixBasedOnTakip',
                        name: i18n("M17995", "Kural Çalıştır"),
                        fnName: 'fixBasedOnTakipFromTopMenu'
                    }
                ]
            },
            {
                id: 'invoiceOperations',
                name: 'Fatura',
                disabled: true,
                items: [
                    {
                        id: 'faturaKayit',
                        name: 'Fatura Kayıt',
                        fnName: 'faturaKayitFromTopMenu'
                    },
                    {
                        id: 'faturaIptal',
                        name: 'Fatura İptal',
                        fnName: 'faturaIptalFromTopMenu'
                    },
                    {
                        id: 'faturaTutarOku',
                        name: i18n("M14215", "Fatura Tutar Oku"),
                        fnName: 'faturaTutarOkuFromTopMenu'
                    }
                ]
            },
            {
                id: 'InvoiceCollectionOperations',
                name: i18n("M16121", "İcmal"),
                disabled: this.collectiveOperationStart,
                items: [
                    {
                        id: 'yeniIcmaleEkle',
                        name: 'Yeni İcmale Ekle',
                        fnName: 'showNewInvoiceCollectionBoundForm'
                    },
                    {
                        id: 'icmaleEkle',
                        name: i18n("M16152", "İcmale Ekle"),
                        fnName: 'icmaleEkleFromTopMenu'
                    },
                    {
                        id: 'icmaldenCikar',
                        name: i18n("M16147", "İcmalden Çıkar"),
                        fnName: 'icmaldenCikarFromTopMenu'
                    },
                ]
            },
            {
                id: 'OtherOperations',
                name: i18n("M12821", "Diğer İşlemler"),
                items: [
                    {
                        id: 'saveUserCustomization',
                        name: i18n("M20111", "Özelleştirmeyi Kaydet"),
                        fnName: 'saveUserCustomization'
                    },
                    {
                        id: 'deleteUserCustomization',
                        name: i18n("M24048", "Varsayılan Ayarlar"),
                        fnName: 'deleteUserCustomization'
                    }
                ]
            }
        ];
    }

    saveUserCustomization(): void {
        let sgcm = [];
        let oneGrid: any = {};
        let transColumnArray = [];
        for (let item of this.visibleEpisodeSearchResultListColumns) {
            transColumnArray.push(item.dataField);
        }
        oneGrid.PageName = "InvoiceEpisodeSearchResultForm";
        oneGrid.GridName = "InvoiceEpisodeSearchResultList";
        oneGrid.ColumnNameList = transColumnArray;
        sgcm.push(oneGrid);


        let apiUrlForUserCustomizationKayit: string = '/api/InvoiceApi/SaveUserBasedGridColumnCustomization';

        this.http.post(apiUrlForUserCustomizationKayit, sgcm).then(response => {
            ServiceLocator.MessageService.showSuccess(i18n("M17905", "Kullanıcı Liste Özelleştirmeleri Kayıt Edildi."));
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    deleteUserCustomization(): void {
        let apiUrlForInvoiceTransactionList: string = '/api/InvoiceApi/DeleteUserCustomization?gridName=InvoiceEpisodeSearchResultList&pageName=InvoiceEpisodeSearchResultForm';
        this.http.get(apiUrlForInvoiceTransactionList).then(response => {
            ServiceLocator.MessageService.showSuccess(i18n("M17906", "Kullanıcı Liste Özelleştirmeleri Temizlendi."));
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

}