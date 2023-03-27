import { Component, OnInit, AfterViewInit } from "@angular/core";
import { InvoiceAllInOneTabService } from "./InvoiceAllInOneTabService";
import { NeHttpService } from "app/Fw/Services/NeHttpService";
import { ITTListDefComboBox } from "app/NebulaClient/Visual/TTVisualControlInterfaces";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';

@Component({
    selector: "invoice-all-in-form",
    templateUrl: './InvoiceAllInOneForm.html',
})
export class InvoiceAllInOneForm implements OnInit, AfterViewInit {

    constructor(private http: NeHttpService, private invoiceAllInOneTabService: InvoiceAllInOneTabService) {
        this.viewModel.termGraphDataSource.push(
            {
                Name: 'Ayaktan',
                TotalPrice: 0
            },
            {
                Name: 'Yatan',
                TotalPrice: 0
            },
            {
                Name: 'Günü Bilrlik',
                TotalPrice: 0
            },
        );

        this.viewModel.userGraphDataSource = this.viewModel.termGraphDataSource;

        this.invoiceAllInOneTabService.invoiceSepFormComm.subscribe(t => {
            //If invoiced success get last invoice data
            this.GetLast5InvoicesOfUser();
        });
    }

    userBasedProcedureGroupDataSource: DataSource;
    userBasedInconsistantDataSource: DataSource;
    public initViewModel: InvoiceAllInOneFormInitViewModel = new InvoiceAllInOneFormInitViewModel();
    public viewModel: InvoiceAllInOneFormViewModel = new InvoiceAllInOneFormViewModel();
    public invoiceAllInOneFormSearchModel: InvoiceAllInOneFormSearchModel = new InvoiceAllInOneFormSearchModel();

    public last5InvoicesColumns = [
        {
            caption: 'Kabul',
            dataField: 'HospitalProtocolNo',
            width: 'auto'
        },
        {
            caption: 'Ad Soyad',
            dataField: 'NameSurname',
            width: 'auto'
        },
        {
            caption: 'Tutar',
            dataField: 'Price',
            dataType: 'number',
            //format: "#,###.###",
            format: {
                currency: 'TRY'
            },
            width: 120
        },
    ];

    public invoiceUserStatColumns = [
        {
            caption: 'Ad Soyad',
            dataField: 'NameSurname',
            width: 'auto.'
        },
        {
            caption: 'Tutar',
            dataField: 'Price',
            dataType: 'number',
            //format: "#,###.###",
            format: {
                currency: 'TRY'
            },
            width: 100
        },
    ];

    public userBasedProcedureGroupColumns = [
        {
            caption: 'Hizmet Türü',
            dataField: 'Type',
            width: 'auto'
        },
        {
            caption: 'Hizmet Adı',
            dataField: 'Name',
            width: 250
        },
        {
            caption: 'Hizmet Kodu',
            dataField: 'Code',
            width: 'auto'
        },
        {
            caption: 'Adet',
            dataField: 'Amount',
            dataType: 'number',
            width: 'auto'
        },
        {
            caption: 'Tutar',
            dataField: 'Price',
            dataType: 'number',
            //format: "#,###.###",
            format: {
                currency: 'TRY'
            },
            width: 100
        },
    ];

    public userBasedInconsistantColumns = [
        {
            caption: 'Kabul',
            dataField: 'ProtocolNo',
            width: 'auto'
        },
        {
            caption: 'Birim Adı',
            dataField: 'Name',
            width: 'auto'
        },
        {
            caption: 'Medula Tutar',
            dataField: 'Medulatutar',
            dataType: 'number',
            //format: "#,###.###",
            format: {
                currency: 'TRY'
            },
            width: 'auto'
        },
        {
            caption: 'Atlas Tutar',
            dataField: 'Hbystutar',
            dataType: 'number',
            //format: "#,###.###",
            format: {
                currency: 'TRY'
            },
            width: 'auto'
        },
        {
            caption: 'Fark',
            dataField: 'Fark',
            dataType: 'number',
            //format: "#,###.###",
            format: {
                currency: 'TRY'
            },
            width: 80
        },
    ];

    cmbTerm: ITTListDefComboBox = <ITTListDefComboBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'InvoiceTermList',
        ShowClearButton: true,
        SelectedIndex: 0
    };

    public distributionTypesDataSource = [
        {
            Id: 0,
            Name: 'Fatura Tutar Dağılımı A/Y/G'
        },
        {
            Id: 1,
            Name: 'Kurum Türü Dağılımı'
        },
    ];

    async ngOnInit() {

        let that = this;

        that.userBasedProcedureGroupDataSource = new DataSource({
            store: new CustomStore({
                //key: "ObjectID",
                load: async (loadOptions: any) => {
                    //if (Object.prototype.hasOwnProperty.call(loadOptions, 'select') == false) {

                    if (that.invoiceAllInOneFormSearchModel.selectedUser.length > 0 && that.invoiceAllInOneFormSearchModel.selectedTerm != null) {
                        loadOptions.Params = {
                            InvoiceAllInOneFormSearchModel: this.invoiceAllInOneFormSearchModel,
                        };
                        let res = await this.http.post<any>('/api/InvoiceApi/GetProceduresForDashboard', loadOptions);

                        return res;
                    }
                    else
                        return new Promise<any>(resolve => {
                            let data = {
                                data: [],
                                groupCount: 0,
                                summary: [],
                                totalCount: 0
                            };
                            resolve(data)
                        });

                },
            }),
            paginate: true,
            pageSize: 50
        });
        that.userBasedInconsistantDataSource = new DataSource({
            store: new CustomStore({
                //key: "ObjectID",
                load: async (loadOptions: any) => {

                    if (that.invoiceAllInOneFormSearchModel.selectedUser.length > 0 && that.invoiceAllInOneFormSearchModel.selectedTerm != null) {
                        loadOptions.Params = {
                            InvoiceAllInOneFormSearchModel: this.invoiceAllInOneFormSearchModel,
                        };
                        let res = await this.http.post<any>('/api/InvoiceApi/GetInconsistentForDashboard', loadOptions);

                        return res;
                    }
                    else
                        return new Promise<any>(resolve => {
                            let data = {
                                data: [],
                                groupCount: 0,
                                summary: [],
                                totalCount: 0
                            };
                            resolve(data)
                        });
                },
            }),
            paginate: true,
            pageSize: 50
        });

        let initRes = await that.http.post<InvoiceAllInOneFormInitViewModel>('api/InvoiceApi/InitInvoiceAllInOneForm', null);
        if (initRes != null) {
            that.initViewModel = initRes;
            if (that.initViewModel.TermList != null && that.initViewModel.TermList.length > 0)
                that.invoiceAllInOneFormSearchModel.selectedTerm = that.initViewModel.TermList[0].ObjectID;
            that.invoiceAllInOneFormSearchModel.selectedTermDistributionType = 0;
            that.invoiceAllInOneFormSearchModel.selectedUserDistributionType = 0;
            await that.GetAllStatistics();
        }
    }

    ngAfterViewInit(): void {
        console.log('after');
    }

    public onOpenInvoiceCollection() {
        let parameters: any = {};
        parameters.OpeningComponentName = 'InvoiceCollectionSearchFormTabContainer';
        this.invoiceAllInOneTabService.tabMessage.next({ Params: parameters, Title: 'İcmal İşlemleri' });
    }

    public onOpenInvoiceSepSearchForm() {
        let parameters: any = {};
        parameters.OpeningComponentName = 'Invoice';
        this.invoiceAllInOneTabService.tabMessage.next({ Params: parameters, Title: 'Fatura İşlemleri' });
    }

    public onOpenInvoiceTerm() {
        let parameters: any = {};
        parameters.OpeningComponentName = 'InvoiceTermFormTab';
        this.invoiceAllInOneTabService.tabMessage.next({ Params: parameters, Title: 'Dönem İşlemleri' });
    }

    public onOpenInvoicePayment() {
        let parameters: any = {};
        parameters.OpeningComponentName = 'InvoicePaymentSearchForm';
        this.invoiceAllInOneTabService.tabMessage.next({ Params: parameters, Title: 'Tahsilat İşlemleri' });
    }

    public onOpenInvoiceReports() {
        let parameters: any = {};
        parameters.OpeningComponentName = 'InvoiceReportForm';
        this.invoiceAllInOneTabService.tabMessage.next({ Params: parameters, Title: 'Raporlar' });
    }


    public onCmbTermChanged(event: any) {
        if (event.previousValue != null) {
            this.GetAllStatistics();
        }
    }

    public onTermDistTypeChanged(event: any) {
        if (event.previousValue != null) {
            this.GetTermGraphData();
        }
    }

    public GetTermGraphData() {
        this.http.post<Array<GraphDTO>>("api/InvoiceApi/GetTermGraphData", this.invoiceAllInOneFormSearchModel).then(res => {
            this.viewModel.termGraphDataSource = res;
        });
    }

    public onUserDistTypeChanged(event: any) {
        if (event.previousValue != null) {
            this.http.post<Array<GraphDTO>>("api/InvoiceApi/GetUserGraphData", this.invoiceAllInOneFormSearchModel).then(res => {
                this.viewModel.userGraphDataSource = res;
            });
        }
    }

    customizeLabel(arg) {
        return arg.value.toLocaleString() + " TL";
    }

    customizeTooltip(arg: any) {
        return {
            text: arg.argumentText + ": " + arg.value.toLocaleString("tr") + 'TL'
        };
    }

    public GetLast5InvoicesOfUser() {
        let that = this;
        that.http.post<Array<GridDTO>>('api/InvoiceApi/GetLast5InvoicesOfUser', null).then(result => {
            that.viewModel.Last5Invoices = result;
        });
    }

    public async GetAllStatistics() {
        let that = this;
        let result = await that.http.post<InvoiceAllInOneFormViewModel>('api/InvoiceApi/GetAllStatistics', that.invoiceAllInOneFormSearchModel);
        if (result != null) {
            that.viewModel = result;
            that.invoiceAllInOneFormSearchModel.selectedUser = [ServiceLocator.ActiveUserService.ActiveUserID];
            this.userBasedProcedureGroupDataSource.reload();
            this.userBasedInconsistantDataSource.reload();
        }
    }

    public onUserStatSelectionChanged(event: any) {
        //console.log(event);
        if (this.invoiceAllInOneFormSearchModel.selectedUser.length > 0 && event.currentDeselectedRowKeys.length == 1) {
            this.http.post<Array<GraphDTO>>("api/InvoiceApi/GetUserGraphData", this.invoiceAllInOneFormSearchModel).then(res => {
                this.viewModel.userGraphDataSource = res;
            });
            this.userBasedProcedureGroupDataSource.reload();
            this.userBasedInconsistantDataSource.reload();
        }
    }

}

export class GridDTO {
    //Son işlem ve fatura kesen kullanıcı listesi
    //için aynı model kullanıldı.
    //ObjectID birisinde PayerInvoiceDocument objectid diğerinde UserObjectID set edilecek
    public ObjectID: Guid;
    public HospitalProtocolNo: string;
    public NameSurname: string;
    public Price: number;
    public UniqueRefNo?: number;
}

export class InvoiceAllInOneFormInitViewModel {
    public TermList: Array<ListBoxDTO> = new Array<ListBoxDTO>();
}

export class ListBoxDTO {
    public ObjectID?: Guid;
    public Name: string;
}

export class InvoiceAllInOneFormViewModel {
    public Last5Invoices: Array<GridDTO> = new Array<GridDTO>();
    public invoiceUserStatGridDataSource: Array<GridDTO> = new Array<GridDTO>();
    public termGraphDataSource: Array<GraphDTO> = new Array<GraphDTO>();
    public userGraphDataSource: Array<GraphDTO> = new Array<GraphDTO>();
    // public userBasedProcedureGroupDataSource: Array<UserBasedProcedureGroupGridModel> = new Array<UserBasedProcedureGroupGridModel>();
    // public userBasedInvoiceDifferenceDataSource: Array<UserBasedInvoiceDifferenceGridModel> = new Array<UserBasedInvoiceDifferenceGridModel>();
}

export class InvoiceAllInOneFormSearchModel {
    public selectedTerm?: Guid;
    public selectedUserDistributionType?: number;
    public selectedTermDistributionType?: number;
    public selectedUser?: Array<Guid> = new Array<Guid>();
}

export class GraphDTO {
    public Name: string;
    public TotalPrice: number;
}

export class UserBasedProcedureGroupGridModel {
    public ObjetID: Guid;
    public OrderNo?: number;
    public ProcedureType: string;
    public ProcedureName: string;
    public ProcedureCode: string;
    public Quantity: number;
    public Price: number;
}

export class UserBasedInvoiceDifferenceGridModel {
    public ObjetID: Guid;
    public OrderNo?: number;
    public HospitalProtocolNo: string;
    public DepartmentName: string;
    public MedulaPrice: number;
    public Price: number;
    public Difference: number;
}