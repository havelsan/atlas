//$77CD9840
import { Component,  OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AccountTotalDebtFormViewModel } from './AccountTotalDebtFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AccountTotalDebt } from 'NebulaClient/Model/AtlasClientModel';
import { AccountPeriodDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'AccountTotalDebtForm',
    templateUrl: './AccountTotalDebtForm.html',
    providers: [MessageService]
})
export class AccountTotalDebtForm extends TTVisual.TTForm implements OnInit {
    AccountPeriod: TTVisual.ITTObjectListBox;
    labelAccountPeriod: TTVisual.ITTLabel;
    labelTotalDebt: TTVisual.ITTLabel;
    public accountTotalDebtFormViewModel: AccountTotalDebtFormViewModel = new AccountTotalDebtFormViewModel();
    public get _AccountTotalDebt(): AccountTotalDebt {
        return this._TTObject as AccountTotalDebt;
    }
    private AccountTotalDebtForm_DocumentUrl: string = '/api/AccountTotalDebtService/AccountTotalDebtForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('ACCOUNTTOTALDEBT', 'AccountTotalDebtForm');
        this._DocumentServiceUrl = this.AccountTotalDebtForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public AccountTotalDebtColumns = [
        {
            caption: 'Yıl',
            dataField: 'Year',
        },
        {
            caption: 'Ay',
            dataField: 'Month',
            cellTemplate: "MonthCellTemplate",
        },
        {
            caption: 'Toplam Borç',
            dataField: 'TotalDebt',
            cellTemplate: "TotalDebtCellTemplate",
            cssClass: "remove-padding"
        }
    ];

    public initViewModel(): void {
        this._TTObject = new AccountTotalDebt();
        this.accountTotalDebtFormViewModel = new AccountTotalDebtFormViewModel();
        this._ViewModel = this.accountTotalDebtFormViewModel;
        this.accountTotalDebtFormViewModel._AccountTotalDebt = this._TTObject as AccountTotalDebt;
        this.accountTotalDebtFormViewModel._AccountTotalDebt.AccountPeriod = new AccountPeriodDefinition();
    }

    protected loadViewModel() {
        let that = this;
        that.accountTotalDebtFormViewModel = this._ViewModel as AccountTotalDebtFormViewModel;
        that._TTObject = this.accountTotalDebtFormViewModel._AccountTotalDebt;
        if (this.accountTotalDebtFormViewModel == null)
            this.accountTotalDebtFormViewModel = new AccountTotalDebtFormViewModel();
        if (this.accountTotalDebtFormViewModel._AccountTotalDebt == null)
            this.accountTotalDebtFormViewModel._AccountTotalDebt = new AccountTotalDebt();
        let accountPeriodObjectID = that.accountTotalDebtFormViewModel._AccountTotalDebt["AccountPeriod"];
        if (accountPeriodObjectID != null && (typeof accountPeriodObjectID === "string")) {
            let accountPeriod = that.accountTotalDebtFormViewModel.AccountPeriodDefinitions.find(o => o.ObjectID.toString() === accountPeriodObjectID.toString());
            if (accountPeriod) {
                that.accountTotalDebtFormViewModel._AccountTotalDebt.AccountPeriod = accountPeriod;
            }
        }

    }

    async ngOnInit() {
        await this.load();
        this.GetAccountTotalDebts();
    }

    public onAccountPeriodChanged(event): void {
        if (this._AccountTotalDebt != null && this._AccountTotalDebt.AccountPeriod != event) {
            this._AccountTotalDebt.AccountPeriod = event;
        }
    }

    public onTotalDebtChanged(event): void {
        if (this._AccountTotalDebt != null && this._AccountTotalDebt.TotalDebt != event) {
            this._AccountTotalDebt.TotalDebt = event;
        }
    }

    protected redirectProperties(): void {
        //redirectProperty(this.TotalDebt, "Text", this.__ttObject, "TotalDebt");
    }

    public async save() {
        if (this._AccountTotalDebt.TotalDebt == null || this._AccountTotalDebt.TotalDebt == 0) {
            this.messageService.showError("Toplam Borç alanı boş geçilemez ve sıfırdan büyük olmalıdır.");
            return;
        }

        await super.save();
        this.initViewModel();
        this.GetAccountTotalDebts();
    }

    public AccountTotalDebtDataSource: Array<any> = new Array<any>();
    public GetAccountTotalDebts() {
        let apiUrl: string = '/api/AccountTotalDebtService/GetTotalDebts';
        this.httpService.post<any>(apiUrl, null).then(
            result => {
                this.AccountTotalDebtDataSource = result;
            });
    }

    public select(data) {
        let that = this;
        if (data.selectedRowKeys.length > 0) {
            let apiUrl: string = '/api/AccountTotalDebtService/AccountTotalDebtForm?id=' + data.selectedRowKeys[data.selectedRowKeys.length - 1].ObjectID.toString();
            this.httpService.get<any>(apiUrl).then(
                x => {
                    this._ViewModel = x;
                    that.loadViewModel();
                });
        }
    }

    public RowRemoving(data) {
        let that = this;
        let apiUrl: string = '/api/AccountTotalDebtService/DeleteSelectedTotalDebt?id=' + data.key.ObjectID.toString();
        this.httpService.get<any>(apiUrl).then(
            result => {
                that.GetAccountTotalDebts();
            });

    }

    public initFormControls(): void {
        this.labelAccountPeriod = new TTVisual.TTLabel();
        this.labelAccountPeriod.Text = "Dönem";
        this.labelAccountPeriod.Name = "labelAccountPeriod";
        this.labelAccountPeriod.TabIndex = 3;

        this.AccountPeriod = new TTVisual.TTObjectListBox();
        this.AccountPeriod.Required = true;
        this.AccountPeriod.ListDefName = "AccountPeriodList";
        this.AccountPeriod.Name = "AccountPeriod";
        this.AccountPeriod.TabIndex = 2;

        this.labelTotalDebt = new TTVisual.TTLabel();
        this.labelTotalDebt.Text = "Toplam Borç";
        this.labelTotalDebt.Name = "labelTotalDebt";
        this.labelTotalDebt.TabIndex = 1;

        this.Controls = [this.labelAccountPeriod, this.AccountPeriod, this.labelTotalDebt];

    }


}
