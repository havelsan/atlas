//$B5A3B7EE
import { Component, OnInit, ViewChild } from '@angular/core';
import { InvoiceCollectionSearchFormModel, InvoiceCollectionSearchResultModel, InvoiceCollectionSearchModel, InvoiceCollectionMergeModel, PriceDetailParameterModel, PriceDetailResultModel } from './InvoiceCollectionSearchFormViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ITTListDefComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTListDefComboBox';
import { ITTObjectListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTObjectListBox';
import { ITTEnumComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTEnumComboBox';
import { ITTTextBox } from 'NebulaClient/Visual/ControlInterfaces/ITTTextBox';
import { ITTMaskedTextBox } from 'NebulaClient/Visual/ControlInterfaces/ITTMaskedTextBox';
import { ITTButton } from 'NebulaClient/Visual/ControlInterfaces/ITTButton';
import { ITTDateTimePicker } from 'NebulaClient/Visual/ControlInterfaces/ITTDateTimePicker';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';
import { HorizontalAlignment } from 'NebulaClient/Utils/Enums/HorizontalAlignment';
import { InputFormat } from 'NebulaClient/Utils/Enums/InputFormat';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { ComboListItem } from 'NebulaClient/Visual/ComboListItem';
import { OperationStatus } from '../CashOfficeForms/OperationStatus';
import { DxDataGridComponent } from 'devextreme-angular';


@Component({
    selector: 'invoice-collection-search-form',
    templateUrl: './InvoiceCollectionSearchForm.html',
    providers: [SystemApiService]

})


export class InvoiceCollectionSearchForm implements OnInit {

    public invoiceCollectionSearchFormModel: InvoiceCollectionSearchFormModel;
    public SelectedInvoiceCollectionObjectID: Guid;
    SelectedInvoiceCollections: Array<InvoiceCollectionSearchResultModel>;
    //selectedInvoiceCollectionID: Guid;

    @ViewChild('invoiceCollectionGrid') invoiceCollectionGrid: DxDataGridComponent;

    cmbTedaviTuru: ITTListDefComboBox = <ITTListDefComboBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'TedaviTuruListDefinition',
        ShowClearButton: true
    };
    cmbTerm: ITTListDefComboBox = <ITTListDefComboBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'InvoiceTermList',
        ShowClearButton: true,
    };
    cmbState: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: 'InvoiceCollectionStateEnum',
        ShowClearButton: true,
    };
    cmbPayer: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'PayerListDefinition',
        ShowClearButton: true,
    };
    dtDate: ITTDateTimePicker = <ITTDateTimePicker>{
        Visible: true,
        ReadOnly: false,
        CustomFormat: 'dd/MM/yyyy',
        ShowClearButton: true,
    };
    txtMaskedPrice: ITTMaskedTextBox = <ITTMaskedTextBox>{
        Visible: true,
        ReadOnly: false,
        Mask: '00000000',
        TextAlign: HorizontalAlignment.Left
    };
    txtText: ITTTextBox = <ITTTextBox>{
        Visible: true,
        ReadOnly: false,
        CharacterCasing: CharacterCasing.Lower,
        TextAlign: HorizontalAlignment.Left,
        InputFormat: InputFormat.AlphaOnly
    };
    btnList: ITTButton = <ITTButton>{
        Visible: true,
        ReadOnly: false,
        Text: 'Listele'
    };

    ResultGridHeight: number;

    public InvoiceCollectionDetailListColumns =
        [
            {
                caption: 'Tarih',
                dataField: 'CreateDate'
            },
            {
                caption: i18n("M15125", "Hasta"),
                dataField: 'PatientName'
            }
        ];

    public InvoiceCollectionListColumns = [
        {
            caption: 'Icmal No',
            dataField: 'No',
            width: 75
        },
        {
            caption: i18n("M16122", "İcmal Adı"),
            dataField: 'Name',
            width: 120
        },
        {
            caption: 'Tarih',
            dataField: 'Date',
            format: 'dd/MM/yyyy',
            dataType: 'date',
            width: 80
        },
        {
            caption: i18n("M18009", "Kurum"),
            dataField: 'Payer.Name',
            width: 150
        },
        {
            caption: 'Durum',
            dataField: 'StateDisplayText',
            width: 70
        },
        {
            caption: i18n("M14190", "Fatura Sayısı"),
            dataField: 'InvoiceCount',
            width: 100
        },
        {
            caption: i18n("M14220", "Fatura Tutarı"),
            dataField: 'InvoicePrice',
            width: 100
        },
        {
            caption: 'Tahsilat Tutarı',
            dataField: 'PaymentPrice',
            width: 100
        },
        {
            caption: i18n("M17512", "Kesinti Tutarı"),
            dataField: 'Deduction',
            width: 100
        },
        {
            caption: i18n("M15925", "Hizmet Tutarı"),
            dataField: 'ProcedureTotal',
            width: 100
        },
        {
            caption: i18n("M18613", "Malzeme Tutarı"),
            dataField: 'MaterialTotal',
            width: 100
        },
        {
            caption: i18n("M16374", "İlaç Tutarı"),
            dataField: 'DrugTotal',
            width: 100
        },
        {
            caption: 'Dönem',
            dataField: 'TermName',
            width: 120
        }
    ];

    // @HostListener('window:resize', ['$event'])

    // onResize(event) {
    //     this.ResultGridHeight = parseInt(event.target.document.getElementById('invoiceCollection-grid-container').offsetHeight);
    // }

    constructor(protected http: NeHttpService, public systemApiService: SystemApiService) {
        this.invoiceCollectionSearchFormModel = new InvoiceCollectionSearchFormModel();
        // $(window).resize(x => {
        //     this.ResultGridHeight = parseInt($('#invoiceCollection-grid-container').css('height'));
        // });
        // $(window).ready(x => {
        //     this.ResultGridHeight = parseInt($('#invoiceCollection-grid-container').css('height'));
        // });
    }

    dynamicComponentActionExecuted(e: any) {
        this.btnListClicked(true);
        //InvoiceCollectionDetailGrid operation completed
        if (e === false) {
            this.systemApiService.componentInfo = null;
        }
        this.systemApiService.open(this.SelectedInvoiceCollectionObjectID, 'InvoiceCollection');
    }

    onCmbTermChanged(e: any) {
        // if (e !== null) {
        //     this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel.ICFirstDate = e.StartDate;
        //     this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel.ICLastDate = e.EndDate;
        // }
        // else {
        //     this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel.ICFirstDate = null;
        //     this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel.ICLastDate = null;
        // }
    }
    ngOnInit(): void {

    }

    async btnListClicked(triggered: boolean): Promise<void> {

        if (triggered === false)
            this.SelectedInvoiceCollectionObjectID = null;

        if ((this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel.Term == null || this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel.Term == undefined) &&
            (this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel.Payer == null || this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel.Payer == undefined)) {
            ServiceLocator.MessageService.showError("Dönem veya Kurum seçiniz.");
            return;
        }

        let apiUrlForInvoiceTerms = '/api/InvoiceApi/InvoiceCollectionSearch';

        let response = await this.http.post<InvoiceCollectionSearchResultModel[]>(apiUrlForInvoiceTerms, this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel);
        if (response !== null) {
            this.invoiceCollectionSearchFormModel.InvoiceCollectionList = response;
        } else {
            this.invoiceCollectionSearchFormModel.InvoiceCollectionList = new Array<InvoiceCollectionSearchResultModel>();
            this.SelectedInvoiceCollectionObjectID = null;
        }
        //this.systemApiService.componentInfo = null;
        // if (this.selectedInvoiceCollectionID !== null && this.selectedInvoiceCollectionID !== undefined)
        //     this.loadInvoiceCollection(null);
    }

    createInvoiceCollectionClick(): void {
        this.systemApiService.new('InvoiceCollection');
    }

    comboListItems: Array<ComboListItem> = new Array<ComboListItem>();

    async mergeInvoiceCollections() {
        let that = this;
        if (that.SelectedInvoiceCollections != null && that.SelectedInvoiceCollections.length > 0) {

            let selectedCollection: ComboListItem;
            that.comboListItems = new Array<ComboListItem>();

            that.SelectedInvoiceCollections.forEach(invoiceCollection => {
                that.comboListItems.push(new ComboListItem(invoiceCollection.ObjectID.valueOf(), invoiceCollection.Name));
            });

            if (that.comboListItems.length > 1)
                selectedCollection = await InputForm.GetValueListItem(i18n("M21518", "Seçilen İcmalde Birleştir"), that.comboListItems);
            else
                ServiceLocator.MessageService.showError(i18n("M11900", "Birleştirme yapabilmek için en az iki İcmal seçilmelidir!"));

            let invoiceCollectionMergeModel: InvoiceCollectionMergeModel = new InvoiceCollectionMergeModel();

            if (selectedCollection.DataValue !== undefined && selectedCollection.DataValue != null) {
                invoiceCollectionMergeModel.ParentInvoiceCollectionID = selectedCollection.DataValue;
                that.SelectedInvoiceCollections.filter(x => x.ObjectID.valueOf() !== selectedCollection.DataValue).forEach(item => {
                    invoiceCollectionMergeModel.ChildInvoiceCollectionsIDs.push(item.ObjectID);
                });
            }
            else
                return false;

            let url = '/api/InvoiceCollectionService/MergeInvoiceCollections';
            that.http.post(url, invoiceCollectionMergeModel).then(x => {
                let result: OperationStatus = <OperationStatus>x;
                if (result.Status)
                    ServiceLocator.MessageService.showSuccess(i18n("M11899", "Birleştirme işlemi tamamlanmıştır."));
                else
                    ServiceLocator.MessageService.showError(result.ErrorMessage);
            });
        }
    }

    changeClasses(): boolean {
        if (parseInt($('div.container-fluid').css('width')) < 1000)
            return true;
        else
            return false;
    }

    getPricesForInvoiceCollections() {
        let priceModel: PriceDetailParameterModel = new PriceDetailParameterModel();

        if (this.SelectedInvoiceCollections == null || this.SelectedInvoiceCollections.length == 0) {
            ServiceLocator.MessageService.showError(i18n("M16141", "İcmal seçilmedi!"));
            return false;
        }

        this.SelectedInvoiceCollections.forEach(invoiceCollection => {
            priceModel.SelectedObjectIDs.push(invoiceCollection.ObjectID);
        });

        let url = '/api/InvoiceApi/GetPricesForInvoiceCollections';
        let that = this;
        this.http.post<Array<PriceDetailResultModel>>(url, priceModel).then(response => {
            response.forEach(element => {

                that.invoiceCollectionSearchFormModel.InvoiceCollectionList.find(x => x.ObjectID == element.ObjectID).DrugTotal = element.DrugTotal;
                that.invoiceCollectionSearchFormModel.InvoiceCollectionList.find(x => x.ObjectID == element.ObjectID).MaterialTotal = element.MaterialTotal;
                that.invoiceCollectionSearchFormModel.InvoiceCollectionList.find(x => x.ObjectID == element.ObjectID).ProcedureTotal = element.ProcedureTotal;
                this.invoiceCollectionGrid.instance.refresh();
            });
        });
    }

    loadInvoiceCollection(e: any): void {
        if (e !== null) {
            this.SelectedInvoiceCollectionObjectID = e.data.ObjectID;
        }
        let component = e.component;
        let prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime) < 250)
            if (this.SelectedInvoiceCollectionObjectID !== undefined && this.SelectedInvoiceCollectionObjectID !== null)
                this.systemApiService.open(this.SelectedInvoiceCollectionObjectID, 'InvoiceCollection');
        // let that = this;
        // var input: Guid;
        // input = e.data.ObjectID;

        // let apiUrlForInvoiceTerms: string = '/api/InvoiceApi/InvoiceCollectionSearchFormDetail?id=' + input;

        // this.http.get<InvoiceCollectionDetailModelDto>(apiUrlForInvoiceTerms)
        //     .then(response => {

        //         this.invoiceCollectionSearchFormModel.InvoiceCollectionDetailModelDto = response;
        //     })
        //     .catch(error => {
        //         console.log(error);
        //     });
    }

    userSearchModelLoaded(value) {
        if (value != null)
            this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel = JSON.parse(value);
        else
            this.invoiceCollectionSearchFormModel.InvoiceCollectionSearchModel = new InvoiceCollectionSearchModel();
    }

    onContextMenuPreparingICGrid(event: any) {
        let that = this;
        if (event.row !== undefined && event.row !== null) {
            if (event.row.rowType === 'data') {
                event.items = [{
                    text: 'İcmal Birleştir',
                    disabled: false,
                    onItemClick: function () {
                        that.mergeInvoiceCollections();
                    },
                },
                {
                    text: i18n("M23614", "Tutarları Hesapla"),
                    disabled: false,
                    onItemClick: function () {
                        that.getPricesForInvoiceCollections();
                    },
                }
                ];
            }
        }
    }
}