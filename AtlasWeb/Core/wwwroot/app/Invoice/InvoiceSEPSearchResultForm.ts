//$843E749C
import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { InvoiceSEPSearchResultFormModel, InvoiceSEPResultGrid, TrxTotalAmount_Model, ButtonVisibityOnPopup, TaskListModel, FixTaskListModel, SavedTaskListModel, ScheduledTaskViewModel, ScheduledTaskModel } from "./InvoiceSEPSearchResultFormViewModel";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { CollectiveOperationResultCount, listboxObject } from './InvoiceHelperModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { PayerTypeEnum, MedulaSubEpisodeStatusEnum, DiagnosisGrid, CollectiveInvoiceOp } from 'NebulaClient/Model/AtlasClientModel';
import { CollectiveInvoiceOpTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { DxDataGridComponent } from 'devextreme-angular';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { DatePipe } from '@angular/common';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from "devextreme/data/data_source";
import { ComboListItem } from 'app/NebulaClient/Visual/ComboListItem';
import { DynamicReportParameters } from '../Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from '../Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from '../Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from '../Fw/Models/ModalInfo';
import { IModalService } from '../Fw/Services/IModalService';
import { InvoiceTabSerivce } from './InvoiceTabSerivce';

@Component({
    selector: "invoice-sep-search-result-form",
    templateUrl: './InvoiceSEPSearchResultForm.html',
    providers: [DatePipe]
})
export class InvoiceSEPSearchResultForm extends BaseComponent<any> implements AfterViewInit {


    public invoiceSEPSearchResultFormModel: InvoiceSEPSearchResultFormModel;
    public collectiveOperationStart: boolean = false;
    public showErrorListPopup: boolean = false;
    //ttenumcomboboxcolumn1: TTVisual.ITTEnumComboBoxColumn;
    //public searchResultHeight: number;
    public doctorArray: Array<any> = [];
    @ViewChild(DxDataGridComponent) ResultGrid: DxDataGridComponent;

    public selectedRowKeysSEPResultList: Array<InvoiceSEPResultGrid> = [];

    public ErrorListColumns = [
        {
            caption: 'ID',
            dataField: 'ObjectID',
            width: '20%'
        },
        {
            caption: i18n("M22633", "Takip"),
            dataField: 'Takip',
            dataType: 'string',
            width: '10%'
        },
        {
            caption: 'Kabul',
            dataField: 'Protocol',
            dataType: 'string',
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
            dataType: 'string',
            width: '50%'
        }
    ];
    public SavedTaskListColumns = [
        {
            caption: 'Kayıt T.',
            dataField: 'CreateDate',
            dataType: 'date',
            format: 'dd/MM/yyyy HH:mm:ss'
        },
        {
            caption: 'Çalışma T.',
            dataField: 'ExecDate',
            dataType: 'date',
            format: 'dd/MM/yyyy HH:mm:ss'
        },
        {
            caption: 'Durum',
            dataField: 'Status'
        }
    ];
    public TaskListColumns = [
        {
            caption: 'Sıra',
            dataField: 'Order',
            width: '10%'
        },
        {
            caption: 'İşlem',
            dataField: 'TaskString',
            width: '20%'
        }, {
            caption: 'T',
            dataField: 'TotalCount',
            width: '5%'
        }, {
            caption: 'Y',
            dataField: 'NewCount',
            width: '5%'
        }, {
            caption: 'B',
            dataField: 'SuccesCount',
            width: '5%'
        }, {
            caption: 'H',
            dataField: 'ErrorCount',
            width: '5%'
        },
        {
            caption: 'Detay',
            dataField: 'Detail',
            width: '50%'
        }
    ];

    public FixTaskListColumns = [
        {
            caption: 'Sıra',
            dataField: 'Order',
            width: '10%'
        },
        {
            caption: 'İşlem',
            dataField: 'TaskString',
            width: '20%'
        },
        {
            caption: 'Hata',
            dataField: 'ErrorCodeText',
            width: '20%'
        },
        {
            caption: 'SUT H.',
            dataField: 'SutCode',
            width: '20%'
        }, {
            caption: 'T',
            dataField: 'TotalCount',
            width: '5%'
        }, {
            caption: 'Y',
            dataField: 'NewCount',
            width: '5%'
        }, {
            caption: 'B',
            dataField: 'SuccesCount',
            width: '5%'
        }, {
            caption: 'H',
            dataField: 'ErrorCount',
            width: '5%'
        },
        {
            caption: 'Detay',
            dataField: 'Detail',
            width: '70%'
        }
    ];

    public changeTrxStateLookUp = [
        {
            "ID": 1,
            'Name': 'Gönder'
        }
        ,
        {
            'ID': 2,
            'Name': 'Gönderme'
        }
    ];
    public ChangeTrxStateColumn = [
        {
            caption: 'İşlem Kodu',
            dataField: 'externalCode',
            allowEditing: false,
            width: '10%'
        },
        {
            caption: 'Açıklama',
            dataField: 'description',
            allowEditing: false,
            dataType: 'string',
            width: '40%'
        },
        {
            caption: 'Birim F.',
            dataField: 'unitPrice',
            allowEditing: false,
            width: '10%'
        },
        {
            caption: 'Adet',
            dataField: 'amount',
            allowEditing: false,
            width: '8%'
        },
        {
            caption: 'Toplam F.',
            dataField: 'totalPrice',
            allowEditing: false,
            width: '13%'
        }
        ,
        {
            caption: 'Seçim',
            dataField: 'choice',
            lookup: { dataSource: this.changeTrxStateLookUp, valueExpr: 'ID', displayExpr: 'Name' },
            //cellTemplate: "choiceCellTemplate",
            allowEditing: true,
            width: '19%'
        }
    ];


    GenerateResultListColumns(columnNameAndOrder: Array<string>) {
        let that = this;
        this.InvoiceSEPSearchResultListColumns = [
            {
                caption: 'No',
                dataField: 'Id',
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
                dataType: 'string',
                visible: false
            },
            {
                caption: i18n("M22205", "Soyadı"),
                dataField: 'Patientsurname',
                dataType: 'string',
                visible: false
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: 'ProtocolNo',
                visible: false
            },
            {
                caption: 'Başvuru No',
                dataField: 'MedulaBasvuruNo',
                visible: false
            },
            {
                caption: i18n("M22659", "Takip No"),
                dataField: 'MedulaTakipNo',
                visible: false
            },
            {
                caption: 'Bağlı Takip No',
                dataField: 'Baglitakipno',
                visible: false
            },
            {
                caption: 'Tarih',
                dataField: 'MedulaProvizyonTarihi',
                dataType: 'date',
                format: 'dd.MM.yyyy',
                visible: false
            },
            {
                caption: i18n("M24446", "Yatış T."),
                dataField: 'Inpatientdate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
                visible: false
            },
            {
                caption: i18n("M12376", "Çıkış T."),
                dataField: 'Dischargedate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
                visible: false
            },
            {
                caption: i18n("M12048", "Branş"),
                dataField: 'Specialityname',
                dataType: 'string',
                visible: false
            },
            {
                caption: 'Durum',
                dataField: 'Status',
                dataType: 'string',
                visible: false
            },
            {
                caption: i18n("M23037", "Tedavi Türü"),
                dataField: 'Tedavituru',
                dataType: 'string',
                visible: false
            },
            {
                caption: i18n("M15593", "HBYS Tutar"),
                dataField: 'Hbystutari',
                visible: false
            }, {
                caption: 'F.Tutar',
                dataField: 'Medulafaturatutari',
                visible: false
            },
            {
                caption: i18n("M18009", "Kurum"),
                dataField: 'Payername',
                dataType: 'string',
                visible: false
            },
            {
                caption: i18n("M16975", "İzlem"),
                dataField: "Izlemusername",
                dataType: 'string',
                visible: false
            },
            {
                caption: i18n("M16122", "İcmal Adı"),
                dataField: 'Icname',
                dataType: 'string',
                visible: false
            },
            {
                caption: i18n("M16136", "İcmal No"),
                dataField: 'ICNo',
                visible: false
            },
            {
                caption: 'M.Sonuç Kodu',
                dataField: 'MedulaSonucKodu',
                visible: false
            },
            {
                caption: 'M.Sonuç Mesajı',
                dataField: 'MedulaSonucMesaji',
                dataType: 'string',
                visible: false
            },
            {
                caption: 'Birim',
                dataField: 'Ressectionname',
                dataType: 'string',
                visible: false
            }


        ];
        let i = 0;
        if (columnNameAndOrder.length > 0) {
            for (let item of columnNameAndOrder) {
                for (let baseItem of this.InvoiceSEPSearchResultListColumns) {
                    if (item == baseItem.dataField) {
                        baseItem.visible = true;
                        baseItem.visibleIndex = i;
                        if (i == 0) {
                            baseItem.sortOrder = 'asc';
                            baseItem.sortIndex = 0;
                        }
                        i++;
                    }
                }
            }

        }
        else {
            for (let baseItem of this.InvoiceSEPSearchResultListColumns) {
                baseItem.visible = true;
                baseItem.visibleIndex = i;
                if (i == 0) {
                    baseItem.sortOrder = 'asc';
                    baseItem.sortIndex = 0;
                }
                i++;
            }
        }
    }

    public InvoiceSEPSearchResultListColumns = [];

    public visibleSEPSearchResultListColumns: any;
    onContentReadySEPSearchResultList(e: any): void {
        this.visibleSEPSearchResultListColumns = e.component.getVisibleColumns();
    }
    customizeMoney(data) {
        if (data.value.value != null)
            return Math.Round(data.value.value, 2);
    }
    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    constructor(private datePipe: DatePipe, protected http: NeHttpService, services: ServiceContainer, private medulaService: GetMedulaDefinitionService, private invoiceTabService:InvoiceTabSerivce, protected modalService: IModalService) {
        super(services);
        this.invoiceSEPSearchResultFormModel = new InvoiceSEPSearchResultFormModel();

        //this.ttenumcomboboxcolumn1 = new TTVisual.TTEnumComboBoxColumn();
        //this.ttenumcomboboxcolumn1.DataTypeName = 'ChangeTrxStateEnum';

        //this.ttenumcomboboxcolumn1.DataMember = 'choice';
        //this.ttenumcomboboxcolumn1.Required = true;
        //this.ttenumcomboboxcolumn1.DisplayIndex = 4;
        //this.ttenumcomboboxcolumn1.HeaderText = 'Seç';
        //this.ttenumcomboboxcolumn1.Name = 'ttenumcomboboxcolumn1';
        //this.ttenumcomboboxcolumn1.Width = 110;

        //this.searchResultHeight = 600;
    }

    public runningTaskID: any;
    public succesCount: number = 0;
    public errorCount: number = 0;
    public totalCount: number = -1;
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

    InvoiceSEPResultList: DataSource;
    errorArrayFirst: Array<listboxObject>;
    BannedStatesArray: Array<listboxObject>;
    errorArraySecond: Array<listboxObject>;
    loadForm(): void {
        let InvoiceSEPSearch: string = '/api/InvoiceApi/InvoiceSEPSearch';
        let apiUrlForInvoiceTransactionList: string = '/api/InvoiceApi/GetColumnAndOrder?gridName=InvoiceSEPSearchResultList&pageName=InvoiceSEPSearchResultForm';
        let promiseArray: Array<Promise<any>> = new Array<any>();
        let that = this;

        //promiseArray.push(this.http.post<InvoiceSearchResultModel>(InvoiceSEPSearch, this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria));
        promiseArray.push(that.http.get(apiUrlForInvoiceTransactionList));

        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            //this.invoiceSEPSearchResultFormModel.InvoiceSEPResultList = sonuc[0].SEPResultList;
            //Enable - Disable Result Top Menu
            this.visibityOfAllTopMenuItem(false);
            this.manageAllTopMenuItem();
            //Enable - Disable Result Top Menu
            this.generateTopMenu();
            this.GenerateResultListColumns(sonuc[0]);
            this.InvoiceSEPResultList = new DataSource({
                store: new CustomStore({
                    key: "ObjectID",
                    load: async (loadOptions: any) => {
                        //if (Object.prototype.hasOwnProperty.call(loadOptions, 'select') == false) {
                        loadOptions.Params = {
                            InvoiceSEPSearchCriteria: that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria,
                        }

                        let res = await this.http.post<any>('/api/InvoiceApi/InvoiceSEPSearch', loadOptions);
                        if ((that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.Contains(6) ||
                            that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.Contains(10) ||
                            that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.Contains(3)) && (
                                that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode == null ||
                                that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode == undefined ||
                                that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode == Guid.Empty
                            )) {
                            this.http.post<Array<listboxObject>>('/api/InvoiceApi/GetInvoiceErrorCodes', that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria).then(result => {
                                that.errorArrayFirst = result;
                            });
                        }
                        if (that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.bannedInvoice && (
                            that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.BannedState == null ||
                            that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.BannedState == undefined ||
                            that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.BannedState == Guid.Empty
                        )
                        ) {
                            this.http.post<Array<listboxObject>>('/api/InvoiceApi/GetBannedStates', that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria).then(result => {
                                that.BannedStatesArray = result;
                            }
                            );
                        }
                        return res;
                        //}
                        // else {
                        //     let res = { data: this.InvoiceSEPResultList.items(), totalCount: this.InvoiceSEPResultList.totalCount(), groupCount: this.InvoiceSEPResultList.group.length }
                        //     return res;
                        // }
                    },
                }),
                paginate: true,
                pageSize: 50
            });
        });
    }

    onToolbarPreparingSEPSearchResultList(event: any): void {
        let that = this;
        event.toolbarOptions.items.unshift(
            {
                location: 'after',
                widget: 'dxButton',
                options: {
                    icon: 'save',
                    text: 'Planlı Görev Kayıt',
                    type: 'btn btn-default',
                    onClick: that.showSaveScheduledTask.bind(that)
                }
            }, {
                location: 'after',
                widget: 'dxButton',
                options: {
                    icon: 'fa fa-bars',
                    text: 'Planlı Görev Listesi',
                    type: 'btn btn-default',
                    onClick: that.showListScheduledTask.bind(that)
                }
            });
    }

    public showSaveScheduledTaskPopup: boolean;
    public showListScheduledTaskPopup: boolean;
    public buttonVisibiltyOnPopup: ButtonVisibityOnPopup = new ButtonVisibityOnPopup();
    showSaveScheduledTask(): void {
        this.decidePopupButtonState(this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status);
        this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode = null;
        this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode = null;

        this.scheduledTaskViewModel.Task = new ScheduledTaskModel();
        this.showSaveScheduledTaskPopup = true;
        this.showListScheduledTaskPopup = false;
        this.scheduledTaskViewModel.SavedTaskList = new Array<SavedTaskListModel>();
    }

    showListScheduledTask(): void {
        this.buttonVisibiltyOnPopup = new ButtonVisibityOnPopup();
        let GetSavedTaskListModel = '/api/CollectiveInvoiceOpTopMenuApi/GetSavedScheduledTask';
        let that = this;
        this.http.get<Array<SavedTaskListModel>>(GetSavedTaskListModel).then(result => {
            that.scheduledTaskViewModel.SavedTaskList = result;
            this.scheduledTaskViewModel.Task = new ScheduledTaskModel();
            that.showSaveScheduledTaskPopup = false;
            that.showListScheduledTaskPopup = true;
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
        });
    }

    // onHiddingScheduledTask(event: any): void {
    //     if(this.showSaveScheduledTaskPopup)
    //         this.showSaveScheduledTaskPopup = false;
    //     if(this.showListScheduledTaskPopup)
    //         this.showListScheduledTaskPopup = false;
    //     console.log("onHiddingScheduledTask");
    // }

    // public TaskList: Array<TaskListModel> = new Array<TaskListModel>();
    // public SavedTaskList: Array<SavedTaskListModel> = new Array<SavedTaskListModel>();
    // public FixTaskList: Array<FixTaskListModel> = new Array<FixTaskListModel>();
    public scheduledTaskViewModel: ScheduledTaskViewModel = new ScheduledTaskViewModel();
    // public FirstSelectErrorCodeOnAutoScript: any;
    // public SecondSelectErrorCodeOnAutoScript: any;
    async addTask(type: number, text: string, nextType: any): Promise<void> {
        let detay: any = {};
        if (type == CollectiveInvoiceOpTypeEnum.SaveInvoice || type == CollectiveInvoiceOpTypeEnum.ReadInvoicePrice) {
            let invDate: any = await InputForm.GetDateTime(i18n("M14208", "Fatura Tarihi Giriniz."));
            //detay.faturaTarihi = this.datePipe.transform(invDate, 'dd.MM.yyyy');
            detay.faturaTarihi = invDate;
            detay.faturaAciklamasi = await InputForm.GetText(i18n("M14107", "Fatura Açıklaması Giriniz."));

            if (detay.faturaTarihi == "" || detay.faturaTarihi == undefined || detay.faturaTarihi == null) {
                ServiceLocator.MessageService.showError(i18n("M22833", "Tarih bilgisi fatura kayıt için zorunlu alanlardır. Lütfen giriş yapınız."));
                return;
            }
        }

        if (nextType != -2) {

            let tempArray: Array<number> = new Array<number>();
            tempArray.push(nextType);

            this.decidePopupButtonState(tempArray);
            let tempItem: TaskListModel = new TaskListModel();
            let tempOrder = this.scheduledTaskViewModel.Task.TaskList.length;
            tempItem.Order = tempOrder + 1;
            tempItem.TaskEnum = type;
            tempItem.TaskString = text;
            tempItem.NextTaskEnum = nextType;
            tempItem.Detail = JSON.stringify(detay);
            tempItem.SearchCriteria = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria;
            this.scheduledTaskViewModel.Task.TaskList.push(tempItem);
        }
        else {
            if ((type == CollectiveInvoiceOpTypeEnum.AddDescription ||
                type == CollectiveInvoiceOpTypeEnum.AddDiagnosis ||
                type == CollectiveInvoiceOpTypeEnum.ChangeDoctor ||
                type == CollectiveInvoiceOpTypeEnum.SetDonotSendMedula ||
                type == CollectiveInvoiceOpTypeEnum.SendNabiz ||
                type == CollectiveInvoiceOpTypeEnum.Fix1108) &&
                (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode == null &&
                    this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.BannedState == null)) {
                ServiceLocator.MessageService.showError("Hata düzeltmeleri için hata/engel durumu seçimi zorunludur. Lütfen giriş yapınız.");
                return;
            }
            let tempDiaList: Array<any> = [];
            if (type == CollectiveInvoiceOpTypeEnum.AddDescription) {
                let accTrxDesc: any = await InputForm.GetText("Açıklama Giriniz.");
                if (accTrxDesc == null)
                    return;
                detay.AccTrxDesc = accTrxDesc;
                detay.Code = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode;
            }
            if (type == CollectiveInvoiceOpTypeEnum.SetDonotSendMedula) {

                detay.StateDefID = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.BannedState;
                detay.errorCodeObjectID = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode;
                detay.Code = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode;
            }
            if (type == CollectiveInvoiceOpTypeEnum.SendNabiz) {
                detay.Code = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode;
            }
            if (type == CollectiveInvoiceOpTypeEnum.AddDiagnosis) {
                if (this.GridDiagnosisGridList.length == 0)
                    return;
                for (let dg of this.GridDiagnosisGridList) {
                    let tempDia: any = {};
                    tempDia.TaniKodu = dg.Diagnose.Code;
                    tempDia.TaniAdi = dg.Diagnose.Name;
                    tempDia.Diagnose = dg.Diagnose;
                    if (dg.DiagnosisType != null)
                        tempDia.DiagnosisType = dg.DiagnosisType.toString();
                    tempDia.IsMainDiagnose = dg.IsMainDiagnose;
                    tempDiaList.push(tempDia);
                }
            }
            if (type == CollectiveInvoiceOpTypeEnum.ChangeDoctor) {
                this.doctorArray = await this.medulaService.Doctor();
                let doctorsList: Array<ComboListItem> = [];

                for (let i = 0; i < this.doctorArray.length; i++) {
                    doctorsList.push(new ComboListItem(this.doctorArray[i].ObjectID, this.doctorArray[i].Name));
                }
                let doctor: ComboListItem = await InputForm.GetValueListItem(i18n("M13201", "Doktor Seçiniz."), doctorsList);

                if (doctor.DataValue !== '' && doctor.DataValue !== null && doctor.DataValue !== undefined) {
                    detay.doctorName = doctor.DisplayText.toString();
                    detay.errorCodeObjectID = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode;
                    detay.newDoctor = doctor.DataValue.toString();
                }
                else {
                    ServiceLocator.MessageService.showError("Doktor seçimi yapılmadan güncelleme yapılamaz.");
                    return;
                }
            }
            if (type == CollectiveInvoiceOpTypeEnum.Fix1108) {
                if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode != null
                    && this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode != undefined) {
                    let splittedCode: string[] = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode.split('-');

                    detay.firstSutCode = splittedCode[0];
                    detay.secondSutCode = splittedCode[1];
                }
                else {
                    ServiceLocator.MessageService.showError("SUT Hatası alanı seçilmeden 1108 hatası düzeltilemez.");
                    return;
                }
            }

            let tempItem: FixTaskListModel = new FixTaskListModel();
            let tempOrder = this.scheduledTaskViewModel.Task.FixTaskList.length;
            tempItem.Order = tempOrder + 1;
            tempItem.TaskEnum = type;
            tempItem.TaskString = text;
            tempItem.NextTaskEnum = nextType;

            if (type == CollectiveInvoiceOpTypeEnum.AddDiagnosis)
                tempItem.Detail = JSON.stringify(tempDiaList);
            else
                tempItem.Detail = JSON.stringify(detay);
            if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode != null)
                tempItem.ErrorCodeText = this.errorArrayFirst.find(x => x.ObjectID == this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode.toString()).Name;
            tempItem.ErrorCode = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode;
            tempItem.SutCode = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode;
            let tempSearchCriteria = Object.assign({}, this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria);
            tempItem.SearchCriteria = tempSearchCriteria;
            this.scheduledTaskViewModel.Task.FixTaskList.push(tempItem);
            this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode = null;
            this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode = null;
        }
    }
    removeTask(): void {
        this.scheduledTaskViewModel.Task.TaskList.pop();
        if (this.scheduledTaskViewModel.Task.TaskList.length > 0) {
            let tempArray: Array<number> = new Array<number>();
            tempArray.push(this.scheduledTaskViewModel.Task.TaskList[this.scheduledTaskViewModel.Task.TaskList.length - 1].NextTaskEnum);
            this.decidePopupButtonState(tempArray);
        }
        else
            this.decidePopupButtonState(this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status);

    }
    removeFixTask(): void {
        this.scheduledTaskViewModel.Task.FixTaskList.pop();
    }
    onRowClickSavedTaskList(event: any): void {
        if (event.data.CioObjectID != this.scheduledTaskViewModel.Task.ObjectID) {
            this.loadSavedTask(event.data.CioObjectID);
        }
    }
    // public ExecTime: DateTime ;
    async onClickSaveScheduledTask(): Promise<void> {
        let takipBazliHizmetKayitUrl = '/api/CollectiveInvoiceOpTopMenuApi/SaveScheduledTask';
        let saveTaskList: any = {};
        saveTaskList.TaskList = this.scheduledTaskViewModel.Task.TaskList;
        saveTaskList.FixTaskList = this.scheduledTaskViewModel.Task.FixTaskList
        saveTaskList.ExecTime = this.scheduledTaskViewModel.Task.ExecTime;
        this.http.post<boolean>(takipBazliHizmetKayitUrl, saveTaskList).then(result => {
            if (result) {
                ServiceLocator.MessageService.showSuccess("Planlı görev başarı ile kayıt edildi.");
                this.showSaveScheduledTaskPopup = false;
                this.showListScheduledTaskPopup = false;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
        });

    }
    loadSavedTask(objectID: Guid): void {
        let GetSavedTaskModel = '/api/CollectiveInvoiceOpTopMenuApi/GetScheduledTask?ObjectID=' + objectID;
        this.http.get<ScheduledTaskModel>(GetSavedTaskModel).then(response => {
            this.scheduledTaskViewModel.Task = response;
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);

        });
    }
    onClickCancelScheduledTask(): void {
        let that = this;
        for (let x of this.scheduledTaskViewModel.SavedTaskList) {
            if (x.CioObjectID == that.scheduledTaskViewModel.Task.ObjectID) {
                if (x.CurrentStateDefID != CollectiveInvoiceOp.CollectiveInvoiceOpStates.New) {
                    ServiceLocator.MessageService.showError("Sadece 'Yeni' durumundaki planlı görevler iptal edilebilir.");
                    return;
                }
            }
        }

        ShowBox.Show(ShowBoxTypeEnum.Message, "&İptal Et,&Vazgeç", "O,V", "Uyarı", "İptal Onayı", "Seçili planlı görev iptal edilecek. Onaylıyor musunuz?").then(result1 => {

            if (result1 === 'O') {
                let takipBazliHizmetKayitUrl = '/api/CollectiveInvoiceOpTopMenuApi/CancelScheduledTask';
                let cancelTask: any = {};
                cancelTask.ObjectID = this.scheduledTaskViewModel.Task.ObjectID;
                this.http.post<boolean>(takipBazliHizmetKayitUrl, cancelTask).then(result => {
                    if (result) {
                        ServiceLocator.MessageService.showSuccess("Planlı görev başarı ile iptal edildi.");
                        this.showListScheduledTask();
                        this.loadSavedTask(cancelTask.ObjectID);
                    }
                }).catch(error => {
                    ServiceLocator.MessageService.showError(error);
                });
            }
            else {
                return;
            }
        });


    }

    decidePopupButtonState(status: Array<number>): void {
        if (status.indexOf(-1) == -1)//Kural çalıştır butonundan geldi ise -1 //SendNabiz700 den geldi ise.
        {
            this.buttonVisibiltyOnPopup = new ButtonVisibityOnPopup();
            if (status.indexOf(MedulaSubEpisodeStatusEnum.ProvisionNoNotExists) > -1) {
                this.buttonVisibiltyOnPopup.takipAl = true;
                this.buttonVisibiltyOnPopup.kuralCalistir = true;
            }
            if (status.indexOf(MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted) > -1) {
                this.buttonVisibiltyOnPopup.takipSil = true;
                this.buttonVisibiltyOnPopup.takipBazliHizmetKayit = true;
                this.buttonVisibiltyOnPopup.takipBazliHizmetKayitIptal = true;
                this.buttonVisibiltyOnPopup.kuralCalistir = true;
                this.buttonVisibiltyOnPopup.SendNabiz700 = true;
            }
            if (status.indexOf(MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted) > -1) {
                this.buttonVisibiltyOnPopup.takipSil = true;
                this.buttonVisibiltyOnPopup.faturaKayit = true;
                this.buttonVisibiltyOnPopup.faturaTutarOku = true;
                this.buttonVisibiltyOnPopup.takipBazliHizmetKayitIptal = true;
                this.buttonVisibiltyOnPopup.SendNabiz700 = true;
            }
            if (status.indexOf(MedulaSubEpisodeStatusEnum.Invoiced) > -1 || status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceInconsistent) > -1) {
                this.buttonVisibiltyOnPopup.faturaIptal = true;
                this.buttonVisibiltyOnPopup.arrangeInvoice = true;
            }
            if (status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceRead) > -1) {
                this.buttonVisibiltyOnPopup.faturaKayit = true;
                this.buttonVisibiltyOnPopup.faturaTutarOku = true;
                this.buttonVisibiltyOnPopup.SendNabiz700 = true;
            }
            if (status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceReadWithError) > -1 ||
                status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceEntryWithError) > -1 || status.indexOf(MedulaSubEpisodeStatusEnum.ProcedureEntryWithError) > -1) {
                this.buttonVisibiltyOnPopup.changeDoctor = true;
                this.buttonVisibiltyOnPopup.faturaKayit = true;
                this.buttonVisibiltyOnPopup.addDiagnosis = true;
                this.buttonVisibiltyOnPopup.addMedulaDescription = true;
                this.buttonVisibiltyOnPopup.fix1108 = true;
                this.buttonVisibiltyOnPopup.takipBazliHizmetKayitFix = true;
                this.buttonVisibiltyOnPopup.faturaKayitOnFix = true;
                this.buttonVisibiltyOnPopup.faturaTutarOkuFix = true;
                this.buttonVisibiltyOnPopup.SetDonotSendMedula = true;
                this.buttonVisibiltyOnPopup.SendNabiz = true;
                this.buttonVisibiltyOnPopup.SendNabiz700 = true;
            }

            if (status.length == 0 || status == null) {
                this.buttonVisibiltyOnPopup = new ButtonVisibityOnPopup();
            }
        }
        return;
    }


    onValueChangedFirstSelectErrorCode(event: any): void {

        if (event.value !== undefined || event.value !== null) {

            this.http.post<Array<listboxObject>>('/api/InvoiceApi/GetSpecificInvoiceErrorCodes', this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria).then(result => {
                this.errorArraySecond = result;
                this.loadForm();
            });
        }
    }

    onValueChangedSecondSelectErrorCode(event: any): void {
        this.loadForm();
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



    visibityOfAllTopMenuItem(type: boolean): void {

        this.visibleTakipAl = type;
        this.visibleTakipSil = type;
        this.visibleTakipOku = type;

        this.visibleTakipBazliHizmetKayit = type;
        this.visibleTakipBazliHizmetKayitIptal = type;
        this.visibleNabizGonder700 = type;
        this.visibleFixBasedOnTakip = type;
        this.visibleArrangeTransactionIn = type;

        this.visibleFaturaKayit = type;
        this.visibleFaturaIptal = type;
        this.visibleFaturaTutarOku = type;
        this.visibleFaturaOku = type;

        this.visibleIcmaleEkle = type;
        this.visibleIcmaldenCikar = type;

        this.visibleSaveUserCustomization = type;
        this.visibleDeleteUserCustomization = type;
        this.visibleAddWatchList = type;
        this.visibleRemoveWatchList = type;
        this.visibleClearWatchList = type;

        this.visiblechangeDoctor = type;
        this.visibleAddDiagnosis = type;
        this.visibleChangeTransactionCurrentState = type;
        this.visibleAddOperation = type;
        this.visibleTransactionException = type;
        this.visibleArrangeTriage = type;

    }

    manageAllTopMenuItem(): void {
        if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.InsideInvoiceCollection) > -1) {
            this.visibleIcmaldenCikar = true;
            this.visibleTakipBazliHizmetKayit = true;
            this.visibleTakipBazliHizmetKayitIptal = true;
            this.visibleFaturaKayit = true;
            this.visibleArrangeTransactionIn = true;
            this.visibleChangeTransactionCurrentState = true;
            this.visibleFixBasedOnTakip = true;
            this.visibleArrangeTriage = true;
            this.visibleAddOperation = true;
            this.visibleTakipSil = true;
            this.visibleTakipOku = true;
            this.visiblechangeDoctor = true;
            this.visibleAddDiagnosis = true;
        }
        if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.Invoiced) > -1 ||
            this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceInconsistent) > -1) {
            this.visibleFaturaIptal = true;
            this.visibleTakipOku = true;
            this.visibleFaturaOku = true;
        }
        if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceEntryWithError) > -1
            || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceRead) > -1
            || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceReadWithError) > -1
            || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted) > -1) {
            this.visibleFaturaKayit = true;
            this.visibleTakipSil = true;
            this.visibleTakipBazliHizmetKayitIptal = true;
            this.visibleNabizGonder700 = true;
            this.visibleArrangeTransactionIn = true;
            this.visibleChangeTransactionCurrentState = true;
            this.visibleTakipOku = true;
            this.visibleFaturaTutarOku = true;
            this.visibleIcmaleEkle = true;
            this.visibleAddOperation = true;
            this.visibleAddDiagnosis = true;

            if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceEntryWithError) > -1
                || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.InvoiceReadWithError) > -1) {
                this.visibleTransactionException = true;
            }
        }
        if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted) > -1) {
            this.visiblechangeDoctor = true;
            this.visibleAddDiagnosis = true;
            this.visibleTakipBazliHizmetKayit = true;
            this.visibleNabizGonder700 = true;
            this.visibleTakipBazliHizmetKayitIptal = true;
            this.visibleArrangeTransactionIn = true;
            this.visibleTakipOku = true;
            this.visibleChangeTransactionCurrentState = true;
            this.visibleFixBasedOnTakip = true;
            this.visibleArrangeTriage = true;
            this.visibleAddOperation = true;
            this.visibleTakipSil = true;
            this.visibleIcmaleEkle = true;
        }
        if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.ProcedureEntryWithError) > -1) {
            this.visiblechangeDoctor = true;
            this.visibleAddDiagnosis = true;
            this.visibleTakipBazliHizmetKayit = true;
            this.visibleTakipBazliHizmetKayitIptal = true;
            this.visibleNabizGonder700 = true;
            this.visibleArrangeTransactionIn = true;
            this.visibleTakipOku = true;
            this.visibleChangeTransactionCurrentState = true;
            this.visibleFixBasedOnTakip = true;
            this.visibleArrangeTriage = true;
            this.visibleAddOperation = true;
            this.visibleTakipSil = true;
            this.visibleTransactionException = true;
            this.visibleIcmaleEkle = true;
        }
        if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.indexOf(MedulaSubEpisodeStatusEnum.ProvisionNoNotExists) > -1) {
            this.visiblechangeDoctor = true;
            this.visibleAddDiagnosis = true;
            this.visibleTakipAl = true;
            this.visibleChangeTransactionCurrentState = true;
            this.visibleFixBasedOnTakip = true;
            this.visibleArrangeTriage = true;
            this.visibleAddOperation = true;
            this.visibleIcmaleEkle = true;
        }
        if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.specialCase != null && this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.specialCase != undefined)//SENDENABIZ700
        {
            this.visibityOfAllTopMenuItem(true);
        }
        if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status === null || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status.length == 0 ||
            this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.status === undefined) {
            this.visibleIcmaleEkle = true;
            this.visiblechangeDoctor = true;
            this.visibleAddDiagnosis = true;
            this.visibleChangeTransactionCurrentState = true;
            this.visibleFixBasedOnTakip = true;
            this.visibleArrangeTriage = true;
            this.visibleAddOperation = true;
            this.visibleTransactionException = true;
        }
        //else {
        //    this.visibityOfAllTopMenuItem(false);
        //}
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
    prepareCollectiveOperationScreenAndProperty(processSearchCriteriaData: boolean): void {
        this.disableTopMenu(true);
        this.errorList = [];
        this.collectiveOperationPanel = true;
        if (processSearchCriteriaData)
            this.totalCount = this.InvoiceSEPResultList.totalCount();
        else
            this.totalCount = this.selectedRowKeysSEPResultList.length;
    }

    async PrepareCollectiveInvoiceOpWithObjectIDList(opType: number, processSearchCriteriaData: boolean): Promise<Guid> {
        let detay: any = {};
        let pciom: any = {};
        if (processSearchCriteriaData == false) {
            if (this.selectedRowKeysSEPResultList.length > 0) {
                pciom.objectIDList = new Array<any>();
                for (let item of this.selectedRowKeysSEPResultList)
                    pciom.objectIDList.push(item);
            }
        }

        pciom.processSearchCriteriaData = processSearchCriteriaData;
        pciom.opType = opType;
        //pciom.invoiceSearchType = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType;
        //pciom.invoiceResultListType = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.searchResultType;
        pciom.invoiceCollectionID = null;
        pciom.InvoiceSEPSearchCriteria = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria;
        if (opType == CollectiveInvoiceOpTypeEnum.SaveInvoice || opType == CollectiveInvoiceOpTypeEnum.ReadInvoicePrice
            || opType == CollectiveInvoiceOpTypeEnum.Fix1108AndInvoice || opType == CollectiveInvoiceOpTypeEnum.Fix1108AndReadInvoice) {
            let invDate: any = await InputForm.GetDateTime(i18n("M14208", "Fatura Tarihi Giriniz."));
            //pciom.invoiceDate = this.datePipe.transform(invDate, 'dd.MM.yyyy');
            detay.faturaTarihi = invDate;
            let invDesc: any = await InputForm.GetText(i18n("M14107", "Fatura Açıklaması Giriniz."));
            detay.faturaAciklamasi = invDesc;

            if (detay.faturaTarihi == "" || detay.faturaTarihi == undefined || detay.faturaTarihi == null) {
                ServiceLocator.MessageService.showError(i18n("M22833", "Tarih bilgisi fatura kayıt için zorunlu alanlardır. Lütfen giriş yapınız."));
                return;
            }
        }

        if (opType == CollectiveInvoiceOpTypeEnum.Fix1108 ||
            opType == CollectiveInvoiceOpTypeEnum.Fix1108AndInvoice || opType == CollectiveInvoiceOpTypeEnum.Fix1108AndReadInvoice) {
            if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode != null
                && this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode != undefined) {
                let splittedCode: string[] = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode.split('-');
                detay.firstSutCode = splittedCode[0];
                detay.secondSutCode = splittedCode[1];
            }
            else {
                ServiceLocator.MessageService.showError("SUT Hatası alanı seçilmeden 1108 hatası düzeltilemez.");
                return;
            }
        }
        if (opType == CollectiveInvoiceOpTypeEnum.SetDonotSendMedula) {
            detay.StateDefID = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.BannedState;
            detay.errorCodeObjectID = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode;
            detay.Code = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode;
        }
        if (opType == CollectiveInvoiceOpTypeEnum.SendNabiz) {
            detay.Code = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode;
        }
        if (opType == CollectiveInvoiceOpTypeEnum.ChangeDoctor) {
            this.doctorArray = await this.medulaService.Doctor();
            let doctorsList: Array<ComboListItem> = [];
            for (let i = 0; i < this.doctorArray.length; i++) {
                doctorsList.push(new ComboListItem(this.doctorArray[i].ObjectID, this.doctorArray[i].Name));
            }
            let doctor: ComboListItem = await InputForm.GetValueListItem(i18n("M13201", "Doktor Seçiniz."), doctorsList);
            if (doctor.DataValue !== '' && doctor.DataValue !== null && doctor.DataValue !== undefined) {
                detay.errorCodeObjectID = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.FirstSelectErrorCode;
                detay.newDoctor = doctor.DataValue.toString();
                detay.doctorName = doctor.DisplayText.toString();
            }
            else {
                ServiceLocator.MessageService.showError("Doktor seçimi yapılmadan güncelleme yapılamaz.");
                return;
            }
        }
        let tempDiaList: Array<any> = [];
        if (opType == CollectiveInvoiceOpTypeEnum.AddDiagnosis) {
            if (this.GridDiagnosisGridList.length == 0)
                return;
            for (let dg of this.GridDiagnosisGridList) {
                let tempDia: any = {};
                tempDia.TaniKodu = dg.Diagnose.Code;
                tempDia.TaniAdi = dg.Diagnose.Name;
                tempDia.Diagnose = dg.Diagnose;
                if (dg.DiagnosisType != null)
                    tempDia.DiagnosisType = dg.DiagnosisType.toString();
                tempDia.IsMainDiagnose = dg.IsMainDiagnose;
                tempDiaList.push(tempDia);
            }
        }
        if (opType == CollectiveInvoiceOpTypeEnum.AddDescription) {
            let accTrxDesc: any = await InputForm.GetText("Açıklama Giriniz.");
            if (accTrxDesc == null)
                return;
            detay.AccTrxDesc = accTrxDesc;
            detay.Code = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.SecondSelectErrorCode
        }

        if (opType == CollectiveInvoiceOpTypeEnum.AddInvoiceCollection) {
            let icmalID = await this.icmalSec();
            if (icmalID) { pciom.invoiceCollectionID = icmalID.DataValue; }
            else { return; }
        }


        if (opType == CollectiveInvoiceOpTypeEnum.AddDiagnosis)
            pciom.extraData = JSON.stringify(tempDiaList);
        else
            pciom.extraData = JSON.stringify(detay);



        let takipBazliHizmetKayitUrl = '/api/CollectiveInvoiceOpTopMenuApi/PrepareCollectiveInvoiceOpWithObjectIDList';
        let collectiveInvoiceOpObjectID = await this.http.post<Guid>(takipBazliHizmetKayitUrl, pciom);
        console.log(collectiveInvoiceOpObjectID);
        return collectiveInvoiceOpObjectID;
    }

    async icmalSec(): Promise<ComboListItem> {

        let aktifIcmal: any;
        let array: Array<ComboListItem> = new Array<ComboListItem>();

        if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.payer == null || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.payer == undefined
            || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.payer == null || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.payer == undefined) {
            ServiceLocator.MessageService.showError("Kurum bilgisi seçilmemiş aramalarda toplu icmale ekleme işlemi yapılamaz. Lütfen kurum seçerek tekrar arama yapınız.");
            return;
        }

        let apiUrlForgetRule: string = '/api/CollectiveInvoiceOpTopMenuApi/uygunIcmalleriGetir?payerObjectID=' + this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.payer;

        let x = await this.http.get<Array<ComboListItem>>(apiUrlForgetRule);

        for (let item of x) {
            array.push(new ComboListItem(item.DataValue, item.DisplayText));
        }

        if (array.length > 0) {
            let selection = await InputForm.GetValueListItem('Icmal Seçim', array);

            if (!(selection.DataValue == undefined || selection.DataValue == null)) { return selection; }
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

    gridRowCount(data: any) {
        return "Adet: " + data.value.value;
    }

    GetCollectiveOperationResultCounts(cio: Guid): void {
        console.log(cio);
        let GetCollectiveOperationResultCountsUrl = '/api/CollectiveInvoiceOpTopMenuApi/GetCollectiveOperationResultCounts?cioObjectID=' + cio;
        this.http.get<CollectiveOperationResultCount>(GetCollectiveOperationResultCountsUrl).then(result => {
            this.errorCount = result.errorCount;
            this.succesCount = result.succesCount;
            this.totalCount = result.succesCount + result.errorCount + result.newCount;
            this.errorList = result.errorList;

            if ((this.totalCount == this.succesCount + this.errorCount) && this.totalCount != 0) {
                console.log("GetCollectiveOperationResultCounts Has Finished: " + cio);
                clearInterval(this.runningTaskID);
                this.disableTopMenu(false);
            }
        }).catch(result => {
            console.log("Catch: GetCollectiveOperationResultCounts : " + cio);
            clearInterval(this.runningTaskID);
            this.disableTopMenu(false);
        });
    }
    execCollectiveOperation(cioObjectID: any): void {
        console.log(cioObjectID);
        let ExecCollectiveOperationUrl = '/api/CollectiveInvoiceOpTopMenuApi/ExecCollectiveOperation?cioObjectID=' + cioObjectID;
        this.http.get<string>(ExecCollectiveOperationUrl);
        //.catch (result => {
        //    console.log("Catch: execCollectiveOperation : "+cioObjectID);
        //    clearInterval(this.runningTaskID);
        //    this.disableTopMenu(false);
        //});

        this.runningTaskID = setInterval(() => { this.GetCollectiveOperationResultCounts(cioObjectID); }, 5000);
    }

    async firstCallWithType(type: CollectiveInvoiceOpTypeEnum) {

        let result = null;
        let processSearchCriteriaData = false;
        if (this.selectedRowKeysSEPResultList.length == 0) {
            result = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), ''
                , 'Herhangi bir seçim yapılmadı. Listelenen tüm veriler için işlem yapılacaktır. Onaylıyor musunuz?');
            if (result != null && result === 'OK')
                processSearchCriteriaData = true;
            else {
                return;
            }
        }

        this.prepareCollectiveOperationScreenAndProperty(processSearchCriteriaData);

        this.PrepareCollectiveInvoiceOpWithObjectIDList(type, processSearchCriteriaData).then(result => {

            this.execCollectiveOperation(result);
        });
    }

    takipAlFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.GetProvision);
    }
    sendENabiz700FromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.SendNabiz700);
    }

    takipSilFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.DeleteProvision);
    }

    takipBazliHizmetKayitFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.SaveProcedure);
    }

    takipBazliHizmetKayitIptalFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.DeleteProcedure);
    }
    fixBasedOnTakipFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.RunRule);
    }
    faturaKayitFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.SaveInvoice);
    }

    faturaIptalFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.DeleteInvoice);
    }

    faturaTutarOkuFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.ReadInvoicePrice);
    }
    fix1108(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.Fix1108);
    }
    Fix1108AndInvoice(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.Fix1108AndInvoice);
    }
    Fix1108AndReadInvoice(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.Fix1108AndReadInvoice);
    }
    setDonotSendMedulaErroredTrx(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.SetDonotSendMedula);
    }
    sendNabiz(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.SendNabiz);
    }
    changeDoctor(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.ChangeDoctor);
    }
    arrangeInvoice(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.ArrangeInvoice);
    }
    addMedulaDescription(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.AddDescription);
    }

    icmaleEkleFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.AddInvoiceCollection);
    }

    icmaldenCikarFromTopMenu(): void {
        this.firstCallWithType(CollectiveInvoiceOpTypeEnum.RemoveInvoiceCollection);
    }

    public changeTrxStateDataSource: Array<TrxTotalAmount_Model>;
    public showChangeTrxStatePopup: boolean;
    public execCioObjectID: Guid;
    public approveChoice: boolean;
    async changeTransactionCurrentState() {
        //this.firstCallWithType(CollectiveInvoiceOpTypeEnum.ChangeTrxCurState);
        let result = null;
        let processSearchCriteriaData = false;
        if (this.selectedRowKeysSEPResultList.length == 0) {
            result = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), ''
                , 'Herhangi bir seçim yapılmadı. Listelenen tüm veriler için işlem yapılacaktır. Onaylıyor musunuz?');
            if (result != null && result === 'OK')
                processSearchCriteriaData = true;
            else {
                return;
            }
        }


        if ((this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.procedure1 != null || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.procedure2 != null)) {
            this.prepareCollectiveOperationScreenAndProperty(processSearchCriteriaData);

            this.PrepareCollectiveInvoiceOpWithObjectIDList(CollectiveInvoiceOpTypeEnum.ChangeTrxCurState, processSearchCriteriaData).then(result => {
                //console.log(result);
                //this.execCollectiveOperation(result);
                //console.log("Hizmet(1) : "+this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.procedure1);
                //console.log("Hizmet(2) : " + this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.procedure2);
                this.showChangeTrxStatePopup = false;
                this.approveChoice = false;
                let apiUrlForInvoiceTransactionList: string = '/api/CollectiveInvoiceOpTopMenuApi/getTrxTotalPriceAndAmountForChangeState?cioObjectID=' + result + '&procedureID1=' + this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.procedure1 + '&procedureID2=' + this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.procedure2;
                this.http.get<Array<TrxTotalAmount_Model>>(apiUrlForInvoiceTransactionList).then(response => {
                    //console.log(response);
                    this.changeTrxStateDataSource = response.sort(x => x.totalPrice);
                    this.showChangeTrxStatePopup = true;
                    this.execCioObjectID = result;
                }).catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                    this.disableTopMenu(false);
                });


            });
        }
        else
            ServiceLocator.MessageService.showError("Hizmet(1) veya Hizmet(2) alanlarından en az biri seçili olmalıdır.");
    }

    btnChangeTrxState(): void {

        if (!this.approveChoice) {
            ServiceLocator.MessageService.showError("Lütfen seçimlerinizi onaylayınız.");
            return;
        }
        console.log(this.changeTrxStateDataSource);

        let apiUrlForExecChangeState: string = '/api/CollectiveInvoiceOpTopMenuApi/ChangeTrxCurrentState?cioObjectID=' + this.execCioObjectID;

        this.http.post(apiUrlForExecChangeState, this.changeTrxStateDataSource).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });

        this.showChangeTrxStatePopup = false;
        this.collectiveOperationPanel = true;
        this.runningTaskID = setInterval(() => { this.GetCollectiveOperationResultCounts(this.execCioObjectID); }, 5000);
    }
    btnCancelChangeTrxState(): void {
        this.showChangeTrxStatePopup = false;
        this.collectiveOperationPanel = false;
        this.disableTopMenu(false);
    }

    onSelectionChangedChoice(event: any, row: any): void {
        console.log(event);
        console.log(row);
    }

    async addWatchList(): Promise<void> {

        let awl: any = {};
        awl.objectIDList = new Array<any>();
        for (let item of this.selectedRowKeysSEPResultList)
            awl.objectIDList.push(item);

        awl.resUserObjectID = null;


        if (awl.objectIDList.length > 0) {

            let takipBazliHizmetKayitUrl = '/api/CollectiveInvoiceOpTopMenuApi/AddWatchList';
            this.http.post<Guid>(takipBazliHizmetKayitUrl, awl).then(response => {
                ServiceLocator.MessageService.showSuccess(i18n("M21561", "Seçili satırlar izlem listeme eklendi."));
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        }

        return;


    }

    removeWatchList(): void {
        let awl: any = {};
        awl.objectIDList = new Array<any>();
        for (let item of this.selectedRowKeysSEPResultList)
            awl.objectIDList.push(item);

        awl.resUserObjectID = null;


        if (awl.objectIDList.length > 0) {

            let takipBazliHizmetKayitUrl = '/api/CollectiveInvoiceOpTopMenuApi/RemoveWatchList';
            this.http.post<Guid>(takipBazliHizmetKayitUrl, awl).then(response => {
                ServiceLocator.MessageService.showSuccess(i18n("M21562", "Seçili satırlar izlem listesinden çıkarıldı."));
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        }

        return;
    }

    clearWatchList(): void {

        ShowBox.Show(ShowBoxTypeEnum.Message, "&Temizle,&Vazgeç", "T,V", i18n("M23735", "Uyarı"), i18n("M16980", "İzlem Listesi Silme Onayı"), i18n("M16983", "İzlem listesindeki bütün takipler çıkarılacaktır, emin misiniz?")).then(result1 => {

            if (result1 === 'T') {
                let takipBazliHizmetKayitUrl = '/api/CollectiveInvoiceOpTopMenuApi/ClearWatchList';
                this.http.get(takipBazliHizmetKayitUrl).then(response => {
                    ServiceLocator.MessageService.showSuccess(i18n("M16981", "izlem listesi temizlendi."));
                }).catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
            }
        });
    }

    printPriceChangedAccTrxsReport() {
        let that = this;

        let data: DynamicReportParameters = {
            Code: 'PriceChangedAccTrxsReport',
            ReportParams: { InvoiceSEPSearchCriteria: that.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Fiyatı Değiştirilen Hizmetler"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    menuData = [];

    visibleTakipAl = false;
    visibleTakipSil = false;
    visibleTakipOku = false;
    visibleNabizGonder700 = false;
    visibleTakipBazliHizmetKayit = false;
    visibleTakipBazliHizmetKayitIptal = false;
    visibleFixBasedOnTakip = false;
    visibleArrangeTransactionIn = false;

    visibleFaturaKayit = false;
    visibleFaturaIptal = false;
    visibleFaturaTutarOku = false;
    visibleFaturaOku = false;

    visibleIcmaleEkle = false;
    visibleIcmaldenCikar = false;

    visibleSaveUserCustomization = false;
    visibleDeleteUserCustomization = false;
    visibleAddWatchList = false;
    visibleRemoveWatchList = false;
    visibleClearWatchList = false;

    visiblechangeDoctor = false;
    visibleAddDiagnosis = false;
    visibleChangeTransactionCurrentState = false;
    visibleAddOperation = false;
    visibleTransactionException = false;
    visibleArrangeTriage = false;

    generateTopMenu(): void {
        this.menuData = [
            {
                id: 'provisionOperations',
                name: i18n("M22633", "Takip"),
                visible: this.visibleTakipAl || this.visibleTakipSil || this.visibleTakipOku || this.visibleNabizGonder700,
                disabled: this.collectiveOperationStart || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType != PayerTypeEnum.SGK,
                items: [
                    {
                        id: 'takipAl',
                        name: i18n("M22634", "Takip Al"),
                        fnName: 'takipAlFromTopMenu',
                        visible: this.visibleTakipAl
                    },
                    {
                        id: 'takipSil',
                        name: i18n("M22668", "Takip Sil"),
                        fnName: 'takipSilFromTopMenu',
                        visible: this.visibleTakipSil
                    },
                    {
                        id: 'takipOkuFromTopMenu',
                        name: "Takip Oku",
                        visible: this.visibleTakipOku,
                        fnName: 'takipOkuFromTopMenu'
                    },
                    {
                        id: 'sendENabiz700FromTopMenu',
                        name: "Nabız Gönder(700)",
                        visible: this.visibleNabizGonder700,
                        fnName: 'sendENabiz700FromTopMenu'
                    }
                ]
            },
            {
                id: 'transactionOperations',
                name: i18n("M15818", "Hizmet"),
                visible: this.visibleTakipBazliHizmetKayit || this.visibleTakipBazliHizmetKayitIptal || this.visibleArrangeTransactionIn,
                disabled: this.collectiveOperationStart || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType != PayerTypeEnum.SGK,
                items: [
                    {
                        id: 'takipBazliHizmetKayit',
                        name: 'Hizmet Kayıt',
                        fnName: 'takipBazliHizmetKayitFromTopMenu',
                        visible: this.visibleTakipBazliHizmetKayit
                    },
                    {
                        id: 'takipBazliHizmetKayitIptal',
                        name: i18n("M15884", "Hizmet Kayıt İptal"),
                        fnName: 'takipBazliHizmetKayitIptalFromTopMenu',
                        visible: this.visibleTakipBazliHizmetKayitIptal
                    },
                    {
                        id: 'arrangeTransactionInconsistency',
                        name: "Hizmet Tutarsızlıkları Düzelt",
                        visible: this.visibleArrangeTransactionIn,
                        fnName: 'arrangeTransactionInconsistency'
                    }
                ]
            },
            {
                id: 'invoiceOperations',
                name: 'Fatura',
                visible: this.visibleFaturaKayit || this.visibleFaturaIptal || this.visibleFaturaTutarOku || this.visibleFaturaOku,
                disabled: this.collectiveOperationStart || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType != PayerTypeEnum.SGK,
                items: [
                    {
                        id: 'faturaKayit',
                        name: 'Fatura Kayıt',
                        visible: this.visibleFaturaKayit,
                        fnName: 'faturaKayitFromTopMenu'
                    },
                    {
                        id: 'faturaIptal',
                        name: 'Fatura İptal',
                        visible: this.visibleFaturaIptal,
                        fnName: 'faturaIptalFromTopMenu'
                    },
                    {
                        id: 'faturaTutarOku',
                        name: i18n("M14215", "Fatura Tutar Oku"),
                        visible: this.visibleFaturaTutarOku,
                        fnName: 'faturaTutarOkuFromTopMenu'
                    },
                    {
                        id: 'faturaOku',
                        name: "Fatura Oku",
                        visible: this.visibleFaturaOku,
                        fnName: 'faturaOku'
                    }
                ]
            },
            {
                id: 'InvoiceCollectionOperations',
                name: i18n("M16121", "İcmal"),
                visible: this.visibleIcmaleEkle || this.visibleIcmaldenCikar,
                disabled: this.collectiveOperationStart,
                items: [
                    {
                        id: 'icmaleEkle',
                        name: i18n("M16152", "İcmale Ekle"),
                        visible: this.visibleIcmaleEkle,
                        fnName: 'icmaleEkleFromTopMenu'
                    },
                    {
                        id: 'icmaldenCikar',
                        name: i18n("M16147", "İcmalden Çıkar"),
                        visible: this.visibleIcmaldenCikar,
                        fnName: 'icmaldenCikarFromTopMenu'
                    }
                ]
            },
            {
                id: 'ArrangeOperations',
                name: i18n("M16121", "Düzenleme İşlemleri"),
                disabled: this.collectiveOperationStart || this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType != PayerTypeEnum.SGK,
                visible: this.visiblechangeDoctor || this.visibleAddDiagnosis || this.visibleChangeTransactionCurrentState || this.visibleFixBasedOnTakip || this.visibleArrangeTriage || this.visibleAddOperation || this.visibleTransactionException,
                items: [
                    {
                        id: 'changeDoctor',
                        name: "Doktor Değiştir",
                        visible: this.visiblechangeDoctor,
                        fnName: 'changeDoctor'
                    },
                    {
                        id: 'addDiagnosis',
                        name: "Tanı Ekle",
                        visible: this.visibleAddDiagnosis,
                        fnName: 'addDiagnosis'
                    },
                    {
                        id: 'changeTransactionCurrentState',
                        name: "İşlem Statü Değiştirme",
                        visible: this.visibleChangeTransactionCurrentState,
                        fnName: 'changeTransactionCurrentState'
                    },
                    {
                        id: 'setDonotSendMedulaErroredTrx',
                        name: "Hatalı Hizmeti Gönderilmeyecek Yap",
                        visible: this.visibleChangeTransactionCurrentState,
                        fnName: 'setDonotSendMedulaErroredTrx'
                    },
                    {
                        id: 'sendNabiz',
                        name: "Nabıza Gönder(1692)",
                        visible: this.visibleChangeTransactionCurrentState,
                        fnName: 'sendNabiz'
                    },
                    {
                        id: 'fixBasedOnTakip',
                        name: i18n("M17995", "Kural Çalıştır"),
                        fnName: 'fixBasedOnTakipFromTopMenu',
                        visible: this.visibleFixBasedOnTakip
                    },
                    {
                        id: 'arrangeTriage',
                        name: "Triaj Düzenleme",
                        visible: this.visibleArrangeTriage,
                        fnName: 'arrangeTriage'
                    },
                    {
                        id: 'addOperation',
                        name: "İşlem Ekle",
                        visible: this.visibleAddOperation,
                        fnName: 'addOperation'
                    },
                    {
                        id: 'transactionException',
                        name: "Hatalı İşlemler",
                        visible: this.visibleTransactionException,
                        fnName: 'transactionException'
                    },
                    {
                        id: 'arrangeInvoice',
                        name: "Fatura Düzelt",
                        visible: true,//Ne zaman gözükeceği daha sonra düzenlenecek.
                        fnName: 'arrangeInvoice'
                    },
                    {
                        id: 'addMedulaDescription',
                        name: "Medula Açıklaması Giriş",
                        visible: true,//Ne zaman gözükeceği daha sonra düzenlenecek.
                        fnName: 'addMedulaDescription'
                    },
                    {
                        id: 'fix1108',
                        name: "1108 Hatası Düzenleme",
                        visible: true,//Ne zaman gözükeceği daha sonra düzenlenecek.
                        fnName: 'fix1108',
                        items: [
                            {
                                id: 'Fix1108AndInvoice',
                                name: "1108 Hatası Düzenle ve Faturala",
                                visible: true,//Ne zaman gözükeceği daha sonra düzenlenecek.
                                fnName: 'Fix1108AndInvoice'
                            }, {
                                id: 'Fix1108AndReadInvoice',
                                name: "1108 Hatası Düzenle ve Fatura Tutar Oku",
                                visible: true,//Ne zaman gözükeceği daha sonra düzenlenecek.
                                fnName: 'Fix1108AndReadInvoice'
                            }
                        ]
                    }
                ]
            },
            {
                id: 'OtherOperations',
                //visible: this.visibleSaveUserCustomization || this.visibleDeleteUserCustomization || this.visibleAddWatchList || this.visibleRemoveWatchList || this.visibleClearWatchList,
                visible: true,
                disabled: this.collectiveOperationStart,
                name: i18n("M12821", "Diğer İşlemler"),
                items: [
                    {
                        id: 'saveUserCustomization',
                        name: i18n("M20111", "Özelleştirmeyi Kaydet"),
                        //visible: this.visibleSaveUserCustomization,
                        visible: true,
                        fnName: 'saveUserCustomization'
                    },
                    {
                        id: 'deleteUserCustomization',
                        name: i18n("M24048", "Varsayılan Ayarlar"),
                        //visible: this.visibleDeleteUserCustomization,
                        visible: true,
                        fnName: 'deleteUserCustomization'
                    },
                    {
                        id: 'addWatchList',
                        name: i18n("M16978", "İzlem Listeme Ekle"),
                        //visible: this.visibleAddWatchList,
                        visible: true,
                        fnName: 'addWatchList'
                    },
                    {
                        id: 'removeWatchList',
                        name: i18n("M16977", "İzlem Listemden Çıkar"),
                        //visible: this.visibleRemoveWatchList,
                        visible: true,
                        fnName: 'removeWatchList'
                    },
                    {
                        id: 'clearWatchList',
                        name: i18n("M16979", "İzlem Listemi Temizle"),
                        //visible: this.visibleClearWatchList,
                        visible: true,
                        fnName: 'clearWatchList'
                    }
                ]
            },
            {
                id: 'Reports',
                visible: true,
                disabled: this.collectiveOperationStart,
                name: i18n("M12821", "Raporlar"),
                items: [
                    {
                        id: 'printPriceChangedAccTrxsReport',
                        name: i18n("M20111", "Fiyatı Değiştirilen Hizmetler"),
                        visible: true,
                        fnName: 'printPriceChangedAccTrxsReport'
                    }
                ]
            }
        ];
    }

    saveUserCustomization(): void {
        let sgcm = [];
        let oneGrid: any = {};
        let transColumnArray = [];
        for (let item of this.visibleSEPSearchResultListColumns) {
            transColumnArray.push(item.dataField);
        }
        oneGrid.PageName = "InvoiceSEPSearchResultForm";
        oneGrid.GridName = "InvoiceSEPSearchResultList";
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
        let apiUrlForInvoiceTransactionList: string = '/api/InvoiceApi/DeleteUserCustomization?gridName=InvoiceSEPSearchResultList&pageName=InvoiceSEPSearchResultForm';
        this.http.get(apiUrlForInvoiceTransactionList).then(response => {
            ServiceLocator.MessageService.showSuccess(i18n("M17906", "Kullanıcı Liste Özelleştirmeleri Temizlendi."));
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    onItemClickTopMenu(event: any): void {
        if (event.itemData.fnName !== undefined)
            this[event.itemData.fnName]();
    }
    ngAfterViewInit(): void {
        this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria = this.RouteData;
        this.loadForm();
    }

    public showAddDiagnosisPopup = false;
    public showAddDiagnosisPopupOnTask = false;
    public GridDiagnosisGridList: Array<DiagnosisGrid>;

    public addDiagnosis(): void {
        this.showAddDiagnosisPopup = true;
        this.showAddDiagnosisPopupOnTask = false;
        this.GridDiagnosisGridList = new Array<DiagnosisGrid>();
    }
    public addDiagnosisOnTask(): void {
        this.showAddDiagnosisPopupOnTask = true;
        this.showAddDiagnosisPopup = false;
        this.GridDiagnosisGridList = new Array<DiagnosisGrid>();
    }

    onClickAddDiagnosis(): void {

        if (this.showAddDiagnosisPopupOnTask) {
            this.addTask(17, 'Tanı Ekle', -2);
            this.showAddDiagnosisPopupOnTask = false;
        }
        else {
            this.firstCallWithType(CollectiveInvoiceOpTypeEnum.AddDiagnosis);
            this.showAddDiagnosisPopup = false;
        }
    }

    searchResultClicked(event: any): void {

        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code

            let detailOpenParameters: any = {};
            detailOpenParameters.ObjectID = event.data.ObjectID;
            if (this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType != null && this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType != undefined)
                detailOpenParameters.Type = this.invoiceSEPSearchResultFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType;
            else
                detailOpenParameters.Type = event.data.PayetTypeEnum;

            this.invoiceTabService.tabMessage.next({ Params: detailOpenParameters, Title: event.data.ProtocolNo + ' ' + event.data.Patientname + ' ' + event.data.Patientsurname });
        }


    }

    public Repaint(): void {
        this.ResultGrid.instance.repaint();
    }

}