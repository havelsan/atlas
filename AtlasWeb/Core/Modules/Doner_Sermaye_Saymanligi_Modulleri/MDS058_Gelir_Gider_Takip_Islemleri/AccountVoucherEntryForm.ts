//$92E9E877
import { Component, OnInit } from '@angular/core';
import { AccountVoucherEntryFormViewModel } from './AccountVoucherEntryFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AccountVoucher } from 'NebulaClient/Model/AtlasClientModel';
import { AccountPeriodDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AccountVoucherCodeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'AccountVoucherEntryForm',
    templateUrl: './AccountVoucherEntryForm.html',
    providers: [MessageService]
})
export class AccountVoucherEntryForm extends TTVisual.TTForm implements OnInit {
    AccountPeriod: TTVisual.ITTObjectListBox;
    AccountVoucherCodeDefinition: TTVisual.ITTObjectListBox;
    SupplierDefinition : TTVisual.ITTObjectListBox;
    IsDept: TTVisual.ITTCheckBox;
    VoucherType: TTVisual.ITTEnumComboBox;
    labelAccountPeriod: TTVisual.ITTLabel;
    labelAccountVoucherCodeDefinition: TTVisual.ITTLabel;
    labelTotalPrice: TTVisual.ITTLabel;
    TotalPrice: TTVisual.ITTTextBox;
    public accountVoucherEntryFormViewModel: AccountVoucherEntryFormViewModel = new AccountVoucherEntryFormViewModel();
    public get _AccountVoucher(): AccountVoucher {
        return this._TTObject as AccountVoucher;
    }
    private AccountVoucherEntryForm_DocumentUrl: string = '/api/AccountVoucherService/AccountVoucherEntryForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('ACCOUNTVOUCHER', 'AccountVoucherEntryForm');
        this._DocumentServiceUrl = this.AccountVoucherEntryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    public GelirGiderDt = [
        {
            Name: "Gelir",
            Value: 0
        },
        {
            Name: 'Gider',
            Value: 1
        }
    ];

    public FisTipiDt = [
        {
            Name: "Muhasebe Fişi",
            Value: 0
        },
        {
            Name: 'Ödeme Emri Fişi',
            Value: 1
        },
        {
            Name: 'Tahsilat Fişi',
            Value: 2
        }
    ];

    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AccountVoucher();
        this.accountVoucherEntryFormViewModel = new AccountVoucherEntryFormViewModel();
        this._ViewModel = this.accountVoucherEntryFormViewModel;
        this.accountVoucherEntryFormViewModel._AccountVoucher = this._TTObject as AccountVoucher;
        this.accountVoucherEntryFormViewModel._AccountVoucher.AccountVoucherCodeDefinition = new AccountVoucherCodeDefinition();
        this.accountVoucherEntryFormViewModel._AccountVoucher.AccountPeriod = new AccountPeriodDefinition();
        this._AccountVoucher.IsDept = null;
        this.accountVoucherEntryFormViewModel._AccountVoucher.Supplier = new Supplier();
        this.accountVoucherEntryFormViewModel._AccountVoucher.VoucherType = null;
    }

    select(data) {
        let that = this;
        if (data.selectedRowKeys.length > 0) {
            let apiUrl: string = '/api/AccountVoucherService/AccountVoucherEntryForm?id=' + data.selectedRowKeys[data.selectedRowKeys.length - 1].ObjectID.toString();
            this.httpService.get<any>(apiUrl).then(
                x => {
                    this._ViewModel = x;
                    that.loadViewModel();
                });
        }
    }

    IsDeptSelectionChanged(event) {
        this.AccountVoucherCodeDefinition.ListFilterExpression = "IsDept = '" + event.selectedItem.Value + "'";
    }

    protected loadViewModel() {
        let that = this;
        that.accountVoucherEntryFormViewModel = this._ViewModel as AccountVoucherEntryFormViewModel;
        that._TTObject = this.accountVoucherEntryFormViewModel._AccountVoucher;
        if (this.accountVoucherEntryFormViewModel == null)
            this.accountVoucherEntryFormViewModel = new AccountVoucherEntryFormViewModel();
        if (this.accountVoucherEntryFormViewModel._AccountVoucher == null)
            this.accountVoucherEntryFormViewModel._AccountVoucher = new AccountVoucher();
        let accountVoucherCodeDefinitionObjectID = that.accountVoucherEntryFormViewModel._AccountVoucher["AccountVoucherCodeDefinition"];
        if (accountVoucherCodeDefinitionObjectID != null && (typeof accountVoucherCodeDefinitionObjectID === "string")) {
            let accountVoucherCodeDefinition = that.accountVoucherEntryFormViewModel.AccountVoucherCodeDefinitions.find(o => o.ObjectID.toString() === accountVoucherCodeDefinitionObjectID.toString());
            if (accountVoucherCodeDefinition) {
                that.accountVoucherEntryFormViewModel._AccountVoucher.AccountVoucherCodeDefinition = accountVoucherCodeDefinition;
            }
        }

        let SupplierDefinitionObjectID = that.accountVoucherEntryFormViewModel._AccountVoucher["Supplier"];
        if (SupplierDefinitionObjectID != null && (typeof SupplierDefinitionObjectID === "string")) {
            let SupplierDefinition = that.accountVoucherEntryFormViewModel.SupplierDefinitions.find(o => o.ObjectID.toString() === SupplierDefinitionObjectID.toString());
            if (SupplierDefinition) {
                that.accountVoucherEntryFormViewModel._AccountVoucher.Supplier = SupplierDefinition;
            }
        }

        let accountPeriodObjectID = that.accountVoucherEntryFormViewModel._AccountVoucher["AccountPeriod"];
        if (accountPeriodObjectID != null && (typeof accountPeriodObjectID === "string")) {
            let accountPeriod = that.accountVoucherEntryFormViewModel.AccountPeriodDefinitions.find(o => o.ObjectID.toString() === accountPeriodObjectID.toString());
            if (accountPeriod) {
                that.accountVoucherEntryFormViewModel._AccountVoucher.AccountPeriod = accountPeriod;
            }
        }
        this._AccountVoucher.IsDept = null;

    }

    public async save() {
        if (this._AccountVoucher.TotalPrice == null || this._AccountVoucher.TotalPrice==0) {
            this.messageService.showError("Toplam Tutar Alanı Boş Geçilemez.");
            return;
        }
        if (this._AccountVoucher.AccountPeriod.Month == null) {
            this.messageService.showError("Dönem Alanı Boş Geçilemez.");
            return;
        }
        if (this._AccountVoucher.AccountVoucherCodeDefinition.Code == null) {
            this.messageService.showError("Kod Alanı Boş Geçilemez.");
            return;
        }
        if (this._AccountVoucher.IsDept == null) {
            this.messageService.showError("Gelir Gider Alanı Boş Geçilemez.");
            return;
        }
        await super.save();
        this.initViewModel();
        this.GetAccountVoucher();
    }


    public AccountVouchersColumns = [
        {
            'caption': "Yıl",
            dataField: 'Year',
        },
        {
            'caption': "Ay",
            dataField: 'Month',
            cellTemplate: "MonthCellTemplate",
        },
        {
            'caption': "Kod",
            dataField: 'Code',
        },
        {
            'caption': "Açıklama",
            dataField: 'Description',
        },
        {
            'caption': "Gelir/Gider",
            dataField: 'IsDept',
            cellTemplate: "IsDeptCellTemplate",
        },
        {
            'caption': "Tip",
            dataField: 'Vtype',
            
        },
        {
            'caption': "Firma",
            dataField: 'Name',

        },
        {
            'caption': "Toplam Tutar",
            dataField: 'TotalPrice',
            dataType: "number",
            cellTemplate: "TotalPriceCellTemplate",
            cssClass:"remove-padding"
        }

    ];

    AccountVouchers: Array<any> = new Array<any>();
    GetAccountVoucher() {
        let apiUrl: string = '/api/AccountVoucherService/GetAccountVoucher';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.AccountVouchers = x;
            });
    }

    Search() {
        let param: GetAccountVoucherDeptParam = new GetAccountVoucherDeptParam();
        param.Year = this._AccountVoucher.AccountPeriod.Year;
        param.Month = this._AccountVoucher.AccountPeriod.Month;
        let apiUrl: string = '/api/AccountVoucherService/GetAccountVoucherWithParam';
        this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.AccountVouchers = x;
            });
    }

    RowRemoving(data) {
        let that = this;
        let apiUrl: string = '/api/AccountVoucherService/DeleteSelectedAccountVoucher?id=' + data.key.ObjectID.toString();
        this.httpService.get<any>(apiUrl).then(
            x => {
                that.GetAccountVoucher();
            });

    }

    async ngOnInit() {
        await this.load();
        this.GetAccountVoucher();
    }

    public onAccountPeriodChanged(event): void {
        if (this._AccountVoucher != null && this._AccountVoucher.AccountPeriod != event) {
            this._AccountVoucher.AccountPeriod = event;
        }
    }

    public onAccountVoucherCodeDefinitionChanged(event): void {
        if (this._AccountVoucher != null && this._AccountVoucher.AccountVoucherCodeDefinition != event) {
            this._AccountVoucher.AccountVoucherCodeDefinition = event;
        }
    }

    public onSupplierChanged(event): void {
        if (this._AccountVoucher != null && this._AccountVoucher.Supplier != event) {
            this._AccountVoucher.Supplier = event;
        }
    }

    public onIsDeptChanged(event): void {
        if (this._AccountVoucher != null && this._AccountVoucher.IsDept != event) {
            this._AccountVoucher.IsDept = event;
        }
    }

    //public IsVoucherTypeChanged(event): void {
    //    if (this._AccountVoucher != null && this._AccountVoucher.VoucherType != event) {
    //        this._AccountVoucher.VoucherType = event;
    //    }
    //}

    public onTotalPriceChanged(event): void {
        if (this._AccountVoucher != null && this._AccountVoucher.TotalPrice != event) {
            this._AccountVoucher.TotalPrice = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.IsDept, "Value", this.__ttObject, "IsDept");
        
        redirectProperty(this.TotalPrice, "Text", this.__ttObject, "TotalPrice");
    }

    public initFormControls(): void {
        this.labelAccountVoucherCodeDefinition = new TTVisual.TTLabel();
        this.labelAccountVoucherCodeDefinition.Text = "ttlabel3";
        this.labelAccountVoucherCodeDefinition.Name = "labelAccountVoucherCodeDefinition";
        this.labelAccountVoucherCodeDefinition.TabIndex = 6;

        this.AccountVoucherCodeDefinition = new TTVisual.TTObjectListBox();
        this.AccountVoucherCodeDefinition.ListDefName = "AccountVoucherCodeList";
        this.AccountVoucherCodeDefinition.Name = "AccountVoucherCodeDefinition";
        this.AccountVoucherCodeDefinition.TabIndex = 5;

        this.SupplierDefinition = new TTVisual.TTObjectListBox();
        this.SupplierDefinition.ListDefName = "SupplierListDefinition";
        this.SupplierDefinition.Name = "SupplierDefinition";
        this.SupplierDefinition.TabIndex = 5;

        this.labelAccountPeriod = new TTVisual.TTLabel();
        this.labelAccountPeriod.Text = "ttlabel2";
        this.labelAccountPeriod.Name = "labelAccountPeriod";
        this.labelAccountPeriod.TabIndex = 4;

        this.AccountPeriod = new TTVisual.TTObjectListBox();
        this.AccountPeriod.ListDefName = "AccountPeriodList";
        this.AccountPeriod.Name = "AccountPeriod";
        this.AccountPeriod.TabIndex = 3;

        this.labelTotalPrice = new TTVisual.TTLabel();
        this.labelTotalPrice.Text = "ttlabel1";
        this.labelTotalPrice.Name = "labelTotalPrice";
        this.labelTotalPrice.TabIndex = 2;

        this.TotalPrice = new TTVisual.TTTextBox();
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.TabIndex = 1;
        this.TotalPrice.IsNonNumeric = true;

        this.IsDept = new TTVisual.TTCheckBox();
        this.IsDept.Value = false;
        this.IsDept.Name = "IsDept";
        this.IsDept.TabIndex = 0;
        this.IsDept.Title = "Gelir/Gider";
        this.IsDept.Text = "Gelir/Gider";

        this.Controls = [this.labelAccountVoucherCodeDefinition, this.AccountVoucherCodeDefinition, this.SupplierDefinition, this.labelAccountPeriod, this.AccountPeriod, this.labelTotalPrice, this.TotalPrice, this.IsDept];

    }


}
export class GetAccountVoucherDeptParam {
    public Month: number;
    public Year: number;
}
