//$8685B947
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { CashOfficeWorkListFormViewModel } from "./CashOfficeWorkListFormViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ITTTextBox } from 'NebulaClient/Visual/ControlInterfaces/ITTTextBox';
import { ITTButton } from 'NebulaClient/Visual/ControlInterfaces/ITTButton';
import { ITTComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTComboBox';
import { ITTComboBoxItem } from 'NebulaClient/Visual/ControlInterfaces/ITTComboBoxItem';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';
import { HorizontalAlignment } from 'NebulaClient/Utils/Enums/HorizontalAlignment';
import { InputFormat } from 'NebulaClient/Utils/Enums/InputFormat';
import { listboxObject } from '../Invoice/InvoiceHelperModel';
import { CashOfficeWorkListResultModel } from '../CashOfficeWorkList/CashOfficeWorkListFormViewModel';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Bond } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectStateHelper } from '../Helper/ObjectStateHelper';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { OperationStatus } from "../CashOfficeForms/OperationStatus";
import { DxDataGridComponent } from 'devextreme-angular';
import { NeHttpService } from "Fw/Services/NeHttpService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { CashOfficeFormsService } from 'app/CashOfficeForms/CashOfficeFormsService';

@Component({
    selector: "cashOffice-worklist-form",
    templateUrl: './CashOfficeWorkListForm.html',
    providers: [SystemApiService]
})

export class CashOfficeWorkListForm implements OnInit, AfterViewInit {

    @ViewChild(DxDataGridComponent) Grid: DxDataGridComponent;
    //@ViewChild(DxPopoverComponent) popOver: DxPopoverComponent;
    public cashOfficeWorkListFormViewModel: CashOfficeWorkListFormViewModel;
    public OperationTypes: Array<listboxObject> = new Array<listboxObject>();
    public BondStatesItems: Array<listboxObject> = new Array<listboxObject>();
    //public SelectedOperationTypeListItems: Array<listboxObject> = new Array<listboxObject>();
    SelectedBondStates: Array<listboxObject> = new Array<listboxObject>();
    savedValues = new Array<any>();

    lstBoxCashiers: TTVisual.TTValueListBox;
    lstBoxCashOffices: TTVisual.TTValueListBox;
    PatientStatus: TTVisual.TTEnumComboBox;
    NotificationStatus: TTVisual.TTEnumComboBox;
    cmbOperationID: TTVisual.TTTextBox;
    BondDetailExpired: TTVisual.TTCheckBox;
    BondSearchPanelVisibility: boolean;
    otherButtonsStyle: any;
    selectedWorkListItems: Array<CashOfficeWorkListResultModel> = new Array<CashOfficeWorkListResultModel>();
    receiptNoChangedItems: Array<CashOfficeWorkListResultModel> = new Array<CashOfficeWorkListResultModel>();
    MainCashOfficeOperationButtonVisible: boolean = true;
    BankPaymentDecountButtonVisible: boolean = true;

    // startDate: ITTDateTimePicker = <ITTDateTimePicker>{
    //     Visible: true,
    //     ReadOnly: false,
    //     CustomFormat: 'dd.MM.yyyy',
    //     Format: DateTimePickerFormat.Custom
    // };

    // endDate: ITTDateTimePicker = <ITTDateTimePicker>{
    //     Visible: true,
    //     ReadOnly: false,
    //     CustomFormat: 'dd.MM.yyyy',
    //     Format: DateTimePickerFormat.Custom
    // };

    dynamicComponentActionExecuted(e: any) {
        this.btnSearchClick();
        this.systemApiService.componentInfo = null;
    }

    dynamicComponentLoadErrorOccurred(e: any) {
        this.systemApiService.componentInfo = null;
    }

    cmbStateChanged(state: number) {
        //this.ViewModel.CashOfficeWorkListSearchModel.State = state;
        //alert('cmbStateChanged' + this.ViewModel.CashOfficeWorkListSearchModel.State);
    }

    //cmbOperationType: ITTComboBox = <ITTComboBox>{
    //    Visible: true,
    //    ReadOnly: false,
    //    Font: {
    //        Bold: false,
    //        Italic: false,
    //        Size: 12,
    //        Strikeout: false,
    //        Underline: false
    //    },
    //    SelectedIndex: undefined,
    //    Items: <Array<ITTComboBoxItem>>[
    //        { Text: "Avans", Value: "0" },
    //        { Text: "Avans İade", Value: "1" },
    //        { Text: "Banka Ödeme Fişi", Value: "2" },
    //        { Text: "Makbuz", Value: "3" },
    //        { Text: "Makbuz İade", Value: "4" },
    //        { Text: "Diğer Tahsilatlar", Value: "5" }
    //    ]
    //};
    //cmbOperationTypeChanged(operationType: number) {
    //    //this.ViewModel.CashOfficeWorkListSearchModel.OperationType = operationType;
    //    //alert('cmbOperationTypeChanged' + operationType);
    //}


    //testTagBox: ITTTagBox = <ITTTagBox>{
    //    Name: 'tagBox',
    //    DisplayMemberPath: 'Name',
    //    ValueMemberPath: 'ItemKey'
    //};

    txtOperationType: ITTTextBox;
    txtReceiptNo: ITTTextBox;
    btnSearch: ITTButton;
    cmbState: ITTComboBox;

    public Repaint() {
        if (this.Grid) {
            this.Grid.instance.repaint();
        }
    }

    public CashOfficeWorkListDataGridColumns =
        [
            {
                caption: i18n("M22944", "TC No"),
                dataField: 'UniqueRefNo',
                allowEditing: false,
                allowResizing: true
            },
            {
                caption: i18n("M15131", "Adı Soyadı"),
                dataField: 'PatientFullName',
                allowEditing: false
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: 'EpisodeID',
                allowEditing: false
            },
            {
                caption: 'Tarih',
                dataField: 'Date',
                dataType: 'date',
                format: 'dd/MM/yyyy',
                allowEditing: false
            },
            {
                caption: i18n("M16893", "İşlem Tipi"),
                dataField: 'OperationType',
                allowEditing: false
            },
            {
                caption: 'Durum',
                dataField: 'State',
                allowEditing: false
            },
            {
                caption: i18n("M11745", "Belge No"),
                dataField: 'ReceiptNo',
            },
            {
                caption: i18n("M16866", "İşlem No"),
                dataField: 'Id',
                allowEditing: false
            },
            {
                caption: i18n("M23606", "Tutar"),
                dataField: 'PaymentPrice',
                allowEditing: false
            },
            {
                caption: i18n("M24159", "Veznedar"),
                dataField: 'CashierName',
                allowEditing: false
            }
        ];

    constructor(public cashOfficeFormsService: CashOfficeFormsService, protected http: NeHttpService, public systemApiService: SystemApiService, private objectStateHelper: ObjectStateHelper, protected modalService: IModalService) {
        this.cashOfficeWorkListFormViewModel = new CashOfficeWorkListFormViewModel();
        this.initFormControls();
        objectStateHelper.getStateDefinitions(Bond.ObjectDefID.id).then(result => {
            result.forEach(element => {
                this.BondStatesItems.push({ Name: element.DisplayText, Code: element.Name, ObjectID: element.ObjectDefID.toString() });
            });
        });
    }

    initFormControls() {

        this.txtOperationType = <ITTTextBox>{
            Visible: true,
            ReadOnly: false,
            CharacterCasing: CharacterCasing.Lower,
            TextAlign: HorizontalAlignment.Left,
            InputFormat: InputFormat.AlphaOnly
        };

        this.btnSearch = <ITTButton>{
            Visible: true,
            ReadOnly: false,
            Text: "Listele"
        };

        this.txtReceiptNo = <ITTTextBox>{
            Visible: true,
            ReadOnly: false,
            CharacterCasing: CharacterCasing.Lower,
            TextAlign: HorizontalAlignment.Left,
            InputFormat: InputFormat.AlphaOnly
        };

        this.cmbState = <ITTComboBox>{
            Visible: true,
            ReadOnly: false,
            SelectedIndex: undefined,
            ShowClearButton: true,
            Items: <Array<ITTComboBoxItem>>[
                { Text: i18n("M22717", "Tamamlanmamış"), Value: "0" },
                { Text: "Başarılı Tamamlanmış", Value: "1" },
                { Text: "Başarısız Tamamlanmış", Value: "2" },
                { Text: i18n("M16526", "İptal"), Value: "4" },
            ]
        };

        this.OperationTypes.push(
            { ObjectID: "83762da5-c38d-43ee-b340-f518b6975b30", Name: i18n("M18472", "Makbuz"), Code: "" },
            { ObjectID: "f9fa6079-f22a-4a28-9c36-3910f00c197d", Name: i18n("M11248", "Avans"), Code: "" },
            { ObjectID: "2332794c-f5e7-4828-91f2-068d327b9b45", Name: i18n("M18474", "Makbuz İade"), Code: "" },
            { ObjectID: "9e7b1902-56e4-4b30-8a6d-3587815a0492", Name: i18n("M11258", "Avans İade"), Code: '' },
            { ObjectID: '72f6b8ab-b9d1-41e6-9dd8-53f260aa0b4f', Name: i18n("M12838", "Diğer Tahsilat"), Code: '' },
            { ObjectID: 'dadd2ddc-cc6d-4471-bd13-f4bb4ce2ce00', Name: 'Banka Ödeme Fişi', Code: '' },
            { ObjectID: 'f2beef18-02b8-455d-9346-bfee74bc507c', Name: i18n("M21595", "Senet"), Code: '' },
            { ObjectID: 'f404c7c1-510d-4f12-a9f3-b9b8e3cc2c35', Name: i18n("M21611", "Senet Tahsilat"), Code: '' }
        );

        this.lstBoxCashiers = new TTVisual.TTValueListBox();
        this.lstBoxCashiers.ListDefName = 'CashierListDefinition';
        this.lstBoxCashiers.Name = 'lstBoxCashiers';

        this.lstBoxCashOffices = new TTVisual.TTValueListBox();
        this.lstBoxCashOffices.ListDefName = 'CashOfficeListDefinition';
        this.lstBoxCashOffices.Name = 'lstBoxCashOffices';

        this.PatientStatus = new TTVisual.TTEnumComboBox();
        this.PatientStatus.DataTypeName = 'PatientStatusEnum';
        this.PatientStatus.Name = 'PatientStatus';

        this.NotificationStatus = new TTVisual.TTEnumComboBox();
        this.NotificationStatus.DataTypeName = 'BondNotificationStatusEnum';
        this.NotificationStatus.Name = 'BondNotificationStatus';
        this.NotificationStatus.ShowClearButton = true;

        this.cmbOperationID = new TTVisual.TTTextBox();
        this.cmbOperationID.Name = 'cmbOperationID';

        this.BondDetailExpired = new TTVisual.TTCheckBox();
        this.BondDetailExpired.Name = 'BondDetailExpired';
    }

    async sendFirstNotificationToSelectedBonds(notificationType: number) {

        if (this.selectedWorkListItems != undefined && this.selectedWorkListItems != null) {
            InputForm.GetDateTime(i18n("M10085", "1. İhbarname Tarihi"), 'dd/MM/yyyy').then(x => {

                let NotificationDate: any = x;

                let notificationItems: BondNotificationItem = new BondNotificationItem();

                notificationItems.NotificationDate = NotificationDate.ToShortDateString();
                notificationItems.NotificationType = notificationType;
                this.selectedWorkListItems.forEach(element => {
                    notificationItems.ObjectIDs.push(element.ObjectID);
                });

                let url: string = 'api/CashOfficeWorkListApi/SendNotification';
                //let body = JSON.stringify(notificationItems);
                this.http.post<OperationStatus>(url, notificationItems).then(response => {
                    let result = <OperationStatus>response;
                    if (!String.isNullOrEmpty(result.CustomMessage))
                        ServiceLocator.MessageService.showInfo(result.CustomMessage + i18n("M19529", "numaralı senetler ") + (notificationType + 1) + i18n("M10022", ". ihabar gönderimine uygun değildir!"));

                    if (!String.isNullOrEmpty(result.ErrorMessage))
                        ServiceLocator.MessageService.showInfo(result.ErrorMessage);
                });
            });

        }
        else
            ServiceLocator.MessageService.showError(i18n("M16231", "İhbar göndermek için senet seçimi yapılmalı!"));
    }

    onOperationTypeChanged(event: any) {
        if (event.value.find(x => x == 'f2beef18-02b8-455d-9346-bfee74bc507c') != null && this.cashOfficeWorkListFormViewModel.CashOfficeWorkListSearchModel.SelectedOperationTypeListItems.length == 1) {
            this.BondSearchPanelVisibility = true;
            this.otherButtonsStyle = { 'visibility': 'hidden' };
        }
        else {
            this.BondSearchPanelVisibility = false;
            this.otherButtonsStyle = { 'visibility': 'visible' };
        }

        //this.cashOfficeWorkListFormViewModel.CashOfficeWorkListSearchModel.BondSearchModel = new BondWorkListSearchModel();
    }

    // public onlstBoxCashiersChanged(event): void {
    //     if (event != null)
    //         this.cashOfficeWorkListFormViewModel.CashOfficeWorkListSearchModel.CashierObjID = event.ObjectID;
    //     else
    //         this.cashOfficeWorkListFormViewModel.CashOfficeWorkListSearchModel.CashierObjID = null
    // }

    ngOnInit(): void {
        this.PrepareNewCashOfficeWorkListForm();
    }

    ngAfterViewInit(): void {

    }

    PrepareNewCashOfficeWorkListForm() {
        let url = 'api/CashOfficeWorkListApi/PrepareNewCashOfficeWorkListForm';
        this.http.get<CashOfficeWorkListFormViewModel>(url).then(response => {
            let result: CashOfficeWorkListFormViewModel = <CashOfficeWorkListFormViewModel>response;
            this.cashOfficeWorkListFormViewModel = result;
            this.MainCashOfficeOperationButtonVisible = result.Roles.MainCashOffice;
            this.BankPaymentDecountButtonVisible = result.Roles.BankDecountPayment;
            //this.btnSearchClick();
        });
    }

    btnSearchClick(): void {

        //this.ViewModel.CashOfficeWorkListSearchModel.SelectedOperationTypeListItems = this.OperationTypes.filter(x => this.SelectedOperationTypeListItems.Contains(a => a.ObjectID == x.ObjectID));
        //this.ViewModel.CashOfficeWorkListSearchModel.BondSearchModel.SelectedBondStates = this.SelectedBondStates;

        //let searchModel = JSON.stringify(this.cashOfficeWorkListFormViewModel.CashOfficeWorkListSearchModel);

        // let headers = new Headers({ 'Content-Type': 'application/json' });
        // let options = new RequestOptions({ headers: headers });

        let apiUrl: string = '/api/CashOfficeWorkListApi/GetCashOfficeWorkList';


        this.http.post<Array<CashOfficeWorkListResultModel>>(apiUrl, this.cashOfficeWorkListFormViewModel.CashOfficeWorkListSearchModel).then(response => {
            this.receiptNoChangedItems = new Array<CashOfficeWorkListResultModel>();
            let result = <Array<CashOfficeWorkListResultModel>>response;
            this.cashOfficeWorkListFormViewModel.CashOfficeWorkListResultModel = result;
            this.systemApiService.componentInfo = null;
            this.savedValues.Clear();
        }).catch(error => {
            console.log(error);
        });
    }
    btnBankPaymentDecountClick(): void {
        this.systemApiService.new('BANKPAYMENTDECOUNT');
    }

    btnMainCashOfficeOperationClick(): void {
        this.systemApiService.new('MAINCASHOFFICEOPERATION');
    }

    openBondPaymentForm(episodeObjectID: Guid) {
        if (episodeObjectID != null) {
            this.systemApiService.new('BONDPAYMENT');
        }
    }

    public grdCashOfficeWorkListClick(event: any): void {
        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 250)) {
            //Double click code
            if (event.data.ObjectDefName != 'OLDDEBTRECEIPTDOCUMENT') {
                let input: DynamicComponentInputParam = new DynamicComponentInputParam();
                input.data = this.cashOfficeFormsService;
                this.systemApiService.open(event.data.ObjectID, event.data.ObjectDefName, null, input);
            }
        }
    }

    onEditingStartWorkList(event: any) {
        //TODO: IF içerisine yetki kontrolü eklenecek
        if (event.column.dataField == 'ReceiptNo' && (event.data.ObjectDefName == 'BONDPAYMENT' || event.data.ObjectDefName == 'RECEIPT' || event.data.ObjectDefName == 'ADVANCE' || event.data.ObjectDefName == 'MAINCASHOFFICEOPERATION')
            && !String.isNullOrEmpty(event.data.ReceiptNo))
            event.cancel = false;
        else
            event.cancel = true;
    }

    onCellPrepared(e: any) {
        if (e.key != null && !e.cellElement[0].classList.contains("dx-cell-modified") && this.receiptNoChangedItems.find(x => x.ObjectID == e.key.ObjectID) != null && e.column.dataField == 'ReceiptNo') {
            e.cellElement[0].style.backgroundColor = "lightgreen";
        }
    }

    // onCellHover(e: any) {
    //     if (e.column != null && e.rowType == "data" && e.column.dataField == 'ReceiptNo') {
    //         this.popOver.target = e.cellElement;
    //         this.popOver.contentTemplate = e.data.ReceiptNo;
    //         this.popOver.visible = true;
    //     }
    //     else
    //         this.popOver.visible = false;
    // }

    changeReceiptNo() {

        let url = 'api/CashOfficeWorkListApi/ChangeReceiptNo';

        if (this.receiptNoChangedItems != null && this.receiptNoChangedItems.length > 0) {
            //let body = JSON.stringify(this.receiptNoChangedItems);

            this.http.post<OperationStatus>(url, this.receiptNoChangedItems).then(response => {
                let result = <OperationStatus>response;
                if (result.Status) {
                    ServiceLocator.MessageService.showSuccess("Değişiklikler başarılı olarak kayıt edildi.");
                    this.receiptNoChangedItems.Clear();
                    this.btnSearchClick();
                }
                else if (!result.Status && !String.isNullOrEmpty(result.ErrorMessage))
                    ServiceLocator.MessageService.showError(result.ErrorMessage);
            });
        }
    }

    printOldDebtReceiptReport(receiptDocObjectID: Guid) {
        let url = 'api/CashOfficeWorkListApi/GetPatientObjectIDForOldReceiptDocument?receiptDocObjectID=' + receiptDocObjectID;
        this.http.get<Guid>(url).then(response => {

            if (response != Guid.Empty) {
                let data: DynamicReportParameters = {
                    Code: 'OldDebtReceiptDetailedReport',
                    ReportParams: { PATIENTOBJECTID: response },
                    ViewerMode: true
                };

                return new Promise((resolve, reject) => {

                    let componentInfo = new DynamicComponentInfo();
                    componentInfo.ComponentName = 'HvlDynamicReportComponent';
                    componentInfo.ModuleName = 'DevexpressReportingModule';
                    componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                    componentInfo.InputParam = new DynamicComponentInputParam(data, null);

                    let modalInfo: ModalInfo = new ModalInfo();
                    modalInfo.Title = "Vezne Eski Borç Makbuzu"

                    modalInfo.fullScreen = true;

                    let result = this.modalService.create(componentInfo, modalInfo);
                    result.then(inner => {
                        resolve(inner);
                    }).catch(err => {
                        reject(err);
                    });
                });
            }
            else
                ServiceLocator.MessageService.showError("Makbuz için gerekli hasta bilgilerine ulaşılamadı.");
        });
    }

    onGrdWorkListRowUpdated(e: any) {
        //this.savedValues[e.key] = this.savedValues[e.key] || {};
        //this.receiptNoChangedItems.push(e.key);
        //$.extend(this.savedValues[e.key], e.data);
        // for (var dataField in e.data) {
        //     var $cell = e.component.getCellElement(e.component.getRowIndexByKey(e.key), dataField);
        //     $cell && $cell.css("background-color", "lightgreen");
        // }
    }

    onGrdWorkListRowUpdating(event: any) {
        if (this.receiptNoChangedItems != null && this.receiptNoChangedItems.find(x => x.ObjectID == event.key.ObjectID) == null) {
            event.key.ReceiptNo = event.newData.ReceiptNo;
            this.receiptNoChangedItems.push(event.key);
        }
        else {
            this.receiptNoChangedItems.find(x => x.ObjectID == event.key.ObjectID).ReceiptNo = event.newData.ReceiptNo;
        }
        for (let dataField in event.newData) {
            let $cell = event.component.getCellElement(event.component.getRowIndexByKey(event.key), dataField);
            /*$cell &&*/ $cell.style.backgroundColor = "lightgreen"; //.css("background-color", "lightgreen");
        }
    }

    contextMenuItems: Array<any>;

    //Grid sağ click butonlar ve aktif-pasiflikleri
    contextMenuRoles(event: any): Array<any> {
        let that = this;
        that.contextMenuItems = new Array<any>();
        let disabled: boolean = that.selectedWorkListItems.filter(x => x.ObjectDefName !== 'BOND').length > 0 && that.selectedWorkListItems.length == 0;

        if (this.cashOfficeWorkListFormViewModel.Roles.BondPayment) {
            this.contextMenuItems.push(
                {
                    text: i18n("M21611", "Senet Tahsilat"),
                    disabled: (event.row.data.ObjectDefName != 'BOND' || (event.row.data.State != i18n("M17551", "Kısmen Ödendi") && event.row.data.State != i18n("M19890", "Ödenmedi"))),
                    onItemClick: function () {
                        //Birinci ihbarname
                        that.openBondPaymentForm(event.row.data.EpisodeObjectID);
                    },
                }
            );
        }
        else if (this.cashOfficeWorkListFormViewModel.Roles.Bond) {
            this.contextMenuItems.push(
                {
                    text: '1. İhbarname',
                    disabled: disabled,
                    onItemClick: function () {
                        //Birinci ihbarname
                        that.sendFirstNotificationToSelectedBonds(0);
                    },
                },
                {
                    text: '2. İhbarname',
                    disabled: disabled,
                    onItemClick: function () {
                        //Birinci ihbarname
                        that.sendFirstNotificationToSelectedBonds(1);
                    },
                }
            );
        }

        this.contextMenuItems.push({
            text: i18n("M12537", "Değişiklikleri Kaydet"),
            disabled: false,
            onItemClick: function () {
                that.changeReceiptNo();
            },
        });

        if (event.row.data.ObjectDefName == 'OLDDEBTRECEIPTDOCUMENT') {
            this.contextMenuItems.push({
                text: i18n("M12538", "Eski Borç Tahsilat Makbuzu"),
                disabled: false,
                onItemClick: function () {
                    that.printOldDebtReceiptReport(event.row.data.ObjectID);
                },
            });
        }

        return this.contextMenuItems;
    }

    //Grid sağ click
    onGrdWorkListContextPreparing(event: any): void {
        let that = this;
        if (event.row !== undefined && event.row !== null) {
            if (event.row.rowType === 'data') {
                //let disabled: boolean = that.selectedWorkListItems.filter(x => x.ObjectDefName !== 'BOND').length > 0 && that.selectedWorkListItems.length == 0;

                event.items = that.contextMenuRoles(event);
                //[
                // {
                //     text: 'Senet Tahsilat',
                //     disabled: (event.row.data.ObjectDefName != 'BOND' || (event.row.data.State != 'Kısmen Ödendi' && event.row.data.State != 'Ödenmedi')),
                //     onItemClick: function () {
                //         //Birinci ihbarname
                //         that.openBondPaymentForm(event.row.data.EpisodeObjectID);
                //     },
                // },
                // {
                //     text: '1. İhbarname',
                //     disabled: disabled,
                //     onItemClick: function () {
                //         //Birinci ihbarname
                //         that.sendFirstNotificationToSelectedBonds(0);
                //     },
                // },
                // {
                //     text: '2. İhbarname',
                //     disabled: disabled,
                //     onItemClick: function () {
                //         //Birinci ihbarname
                //         that.sendFirstNotificationToSelectedBonds(1);
                //     },
                // },
                // {
                //     text: 'Değişiklikleri Kaydet',
                //     disabled: false,
                //     onItemClick: function () {
                //         that.changeReceiptNo();
                //     },
                // }
                //];
            }
        }
    }
}

export class BondNotificationItem {
    public ObjectIDs: Array<Guid> = new Array<Guid>();
    public NotificationDate: string;
    public NotificationType: number;
}