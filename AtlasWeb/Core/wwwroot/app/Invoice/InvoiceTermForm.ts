//$691A6857
import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { InvoiceTermFormViewModel, InvoiceTermFormDetailViewModel } from "./InvoiceTermFormViewModel";
import { PriceDetailParameterModel, PriceDetailResultModel } from './InvoiceCollectionSearchFormViewModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { DxDataGridComponent } from 'devextreme-angular';
import { InvoiceTermFormTabService } from './InvoiceTermFormTabService';

@Component({
    selector: "invoice-term-form",
    templateUrl: './InvoiceTermForm.html',
    providers: [SystemApiService]
})

export class InvoiceTermForm implements AfterViewInit {

    public ViewModelLeft: InvoiceTermFormViewModel;
    public ViewModelRight: InvoiceTermFormDetailViewModel;
    //TabItems: Array<TabItemModel> = [];
    public SelectedTermObjectID: Guid;
    openButtonVisible: boolean = false;
    cancelButtonVisible: boolean = false;
    lockButtonVisible: boolean = false;
    closeButtonVisible: boolean = false;
    SelectedInvoiceCollections: Array<any>;

    @ViewChild('invoiceCollectionGrid') invoiceCollectionGrid: DxDataGridComponent;

    TermGridHeight: number;

    public InvoiceTermListColumns = [

        {
            "caption": i18n("M13308", "Dönem Adı"),
            dataField: "Name"
        },
        {
            "caption": i18n("M11637", "Başlangıç Tarihi"),
            dataField: "StartDate",
            dataType: 'date',
            format: 'dd/MM/yyyy'
        },
        {
            "caption": i18n("M11939", "Bitiş Tarihi"),
            dataField: "EndDate",
            dataType: 'date',
            format: 'dd/MM/yyyy'
        },
        {
            "caption": i18n("M13372", "Durumu"),
            dataField: "StateDisplayText"
        }
        ,
        // {
        //     caption: " ",
        //     dataField: "ObjectID",
        //     cellTemplate: "buttonCellTemplate"
        // }
    ];


    public InvoiceCollectionListColumns = [
        {
            caption: i18n("M16122", "İcmal Adı"),
            dataField: "Name",
            width: 200,
            fixed:true
        },
        {
            caption: "Icmal No",
            dataField: "No",
            width:'auto',
            fixed:true
        },
        {
            caption: "Tarih",
            dataField: "Date",
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width:'auto',
            fixed:true
        },
        {
            caption: "Durum",
            dataField: "StateDisplayText",
            width:'auto',
            fixed:true
        },
        {
            caption: i18n("M17251", "Kapasite"),
            dataField: "Capacity",
            width:'auto',
            fixed:false
        },
        {
            caption: i18n("M14220", "Fatura Tutarı"),
            dataField: "InvoicePrice",
            width:'auto',
            fixed:false
        },
        {
            caption: i18n("M14190", "Fatura Sayısı"),
            dataField: "FaturaSayisi",
            width:'auto',
            fixed:false
        },
        {
            caption: 'Tahsilat Tutarı',
            dataField: 'PaymentPrice',
            width:'auto',
            fixed:false
        },
        {
            caption: i18n("M17512", "Kesinti Tutarı"),
            dataField: 'Deduction',
            width:'auto',
            fixed:false
        },
        {
            caption: i18n("M15925", "Hizmet Tutarı"),
            dataField: 'ProcedureTotal',
            width:'auto',
            fixed:false
        },
        {
            caption: i18n("M18613", "Malzeme Tutarı"),
            dataField: 'MaterialTotal',
            width:'auto',
            fixed:false
        },
        {
            caption: i18n("M16374", "İlaç Tutarı"),
            dataField: 'DrugTotal',
            width:'auto',
            fixed:false
        }
        //{
        //     caption: "Hizmet Tutarı",
        //     dataField: "HizmetTutari"
        // }
        // ,
        // {
        //     caption: "Sarf Tutarı",
        //     dataField: "SarfTutari"
        // },
        // {
        //     caption: "İlaç Tutarı",
        //     dataField: "IlacTutari"
        // },
    ];

    constructor(protected http: NeHttpService, private systemApiService: SystemApiService, private medulaService: InvoiceTermFormTabService) {
        this.ViewModelLeft = new InvoiceTermFormViewModel();
        this.ViewModelRight = new InvoiceTermFormDetailViewModel();
    }

    async ngAfterViewInit(): Promise<void> {
      
        $(window).ready(x => {
            if (this.invoiceCollectionGrid) {
                this.invoiceCollectionGrid.instance.repaint();
            }
        });
        this.GetInvoiceTerms();
    }

  
   changeClasses(): boolean {
        if (parseInt($('div.container-fluid').css('width')) < 1000)
            return true;
        else
            return false;
    }

    async GetInvoiceTerms(): Promise<void> {
        let that = this;
        this.http.get<InvoiceTermFormViewModel>("api/InvoiceApi/InvoiceTermForm").then(result => {
            that.ViewModelLeft = result;
            if (that.SelectedTermObjectID != null)
                that.setStateButtonsVisibility(result.InvoiceTermList.find(x => x.ObjectID == that.SelectedTermObjectID));
        }).catch(x => {
            ServiceLocator.MessageService.showError(x);
        });
    }

    async createTermClick(): Promise<void> {
        let apiUrlForInvoiceTerms: string = '/api/InvoiceApi/InvoiceTermActions?id=""&action=-1';

        this.http.get(apiUrlForInvoiceTerms).then(res => {
            this.GetInvoiceTerms();
        });
    }

    onSelectionChanged(event:any)
    {
        this.invoiceCollectionGrid.instance.refresh();
    }

    invoiceCollectionGridOnRowClick(e: any) {

        let component = e.component;
        let prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();

        if (prevClickTime && (component.lastClickTime - prevClickTime) < 250) {

            let detailOpenParameters: any = {};
            detailOpenParameters.ObjectID = e.data.ObjectID;
            detailOpenParameters.Tabs;
            this.medulaService.tabMessage.next({ Params: detailOpenParameters, Title: e.data.Name });
        }
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

                that.ViewModelRight.DrugTotal = 0;
                that.ViewModelRight.ProcedureTotal = 0;
                that.ViewModelRight.MaterialTotal = 0;
                that.ViewModelRight.DrugTotal += Math.Round(element.DrugTotal, 2);
                that.ViewModelRight.ProcedureTotal += Math.Round(element.ProcedureTotal, 2);
                that.ViewModelRight.MaterialTotal += Math.Round(element.MaterialTotal, 2);

                that.ViewModelRight.InvoiceCollectionList.find(x => x.ObjectID == element.ObjectID).DrugTotal = element.DrugTotal;
                that.ViewModelRight.InvoiceCollectionList.find(x => x.ObjectID == element.ObjectID).MaterialTotal = element.MaterialTotal;
                that.ViewModelRight.InvoiceCollectionList.find(x => x.ObjectID == element.ObjectID).ProcedureTotal = element.ProcedureTotal;

                this.invoiceCollectionGrid.instance.refresh();
            });
        });
    }

    onContextMenuPreparingICGrid(event: any) {
        let that = this;
        if (event.row !== undefined && event.row !== null) {
            if (event.row.rowType === 'data') {
                event.items = [
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

    // onContextMenuPreparingTerms(e: any) {
    //     let that = this;
    //     if (e.row !== undefined && e.row !== null) {
    //         if (e.row.rowType === "data") {
    //             e.items = [
    //                 {
    //                     text: 'Kapat',
    //                     disabled: e.row.data.StateDisplayText !== 'Açık' && e.row.data.StateDisplayText !== 'Kilitli',
    //                     onItemClick: function () {
    //                         that.invoiceTermActions(e.row.data.ObjectID, 3)
    //                     },
    //                 },
    //                 {
    //                     text: 'Kilitle',
    //                     disabled: e.row.data.StateDisplayText !== 'Açık',
    //                     onItemClick: function () {
    //                         that.invoiceTermActions(e.row.data.ObjectID, 2)
    //                     },
    //                 },
    //                 {
    //                     text: 'İptal',
    //                     disabled: e.row.data.StateDisplayText !== 'Açık' && e.row.data.StateDisplayText !== 'Kilitli',
    //                     onItemClick: function () {
    //                         that.invoiceTermActions(e.row.data.ObjectID, 1)
    //                     },
    //                 },
    //                 {
    //                     text: 'Aç',
    //                     disabled: e.row.data.StateDisplayText !== 'Kapalı' && e.row.data.StateDisplayText !== 'Kilitli',
    //                     onItemClick: function () {
    //                         that.invoiceTermActions(e.row.data.ObjectID, 0)
    //                     },
    //                 },
    //             ];
    //         }
    //     }
    // }

    async invoiceTermActions(event: any, action: number): Promise<void> {
        //action .cshtml Tarafında butonların onClick event inde atandı
        let that = this;
        if (action == 0)
            this.loadPanelOperation(true, i18n("M13304", "Dönem açılıyor. Lütfen bekleyiniz."));
        else if (action == 1)
            this.loadPanelOperation(true, i18n("M13312", "Dönem iptal ediliyor. Lütfen bekleyiniz."));
        else if (action == 2)
            this.loadPanelOperation(true, i18n("M13314", "Dönem kilitleniyor. Lütfen bekleyiniz."));
        else if (action == 3)
            this.loadPanelOperation(true, i18n("M13313", "Dönem kapanıyor. Lütfen bekleyiniz."));

        if (this.SelectedTermObjectID != undefined && this.SelectedTermObjectID != null) {
            let apiUrlForInvoiceTerms: string = '/api/InvoiceApi/InvoiceTermActions?id=' + this.SelectedTermObjectID + '&action=' + action;
            this.http.get(apiUrlForInvoiceTerms).then(x => {
                this.loadPanelOperation(false, "");
                ServiceLocator.MessageService.showSuccess(i18n("M16828", "İşlem başarılı olarak gerçekleşti."));
                that.GetInvoiceTerms();
            }).catch(x => {
                this.loadPanelOperation(false, "");
                ServiceLocator.MessageService.showError(x);
            });
        }
        else
            ServiceLocator.MessageService.showError(i18n("M18368", "Lütfen dönem seçimi yapınız!"));
    }

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    loadInvoiceCollection(e: any) {

        let component = e.component, prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();

        if (prevClickTime && (component.lastClickTime - prevClickTime) < 250) {
            this.SelectedTermObjectID = e.data.ObjectID;
            let apiUrlForInvoiceTerms: string = '/api/InvoiceApi/InvoiceTermFormDetail?id=' + this.SelectedTermObjectID;
            this.http.get<InvoiceTermFormDetailViewModel>(apiUrlForInvoiceTerms).then(result => {
                this.ViewModelRight = result;
                this.ViewModelRight.InvoicePrice = Math.Round(this.ViewModelRight.InvoicePrice, 2);
                this.setStateButtonsVisibility(e.data);
            });
        }
    }

    setStateButtonsVisibility(invoiceTerm: any) {
        if (invoiceTerm.StateDisplayText !== i18n("M16526", "İptal")) {
            this.openButtonVisible = invoiceTerm.StateDisplayText !== i18n("M10463", "Açık");
            this.cancelButtonVisible = invoiceTerm.StateDisplayText === i18n("M10463", "Açık") || invoiceTerm.StateDisplayText === i18n("M17560", "Kilitli");
            this.closeButtonVisible = invoiceTerm.StateDisplayText === i18n("M10463", "Açık") || invoiceTerm.StateDisplayText === i18n("M17560", "Kilitli");
            this.lockButtonVisible = invoiceTerm.StateDisplayText === i18n("M10463", "Açık");
        }
        else {
            this.openButtonVisible = false;
            this.cancelButtonVisible = false;
            this.closeButtonVisible = false;
            this.lockButtonVisible = false;
        }
    }
}