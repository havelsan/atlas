//$168F7506
import { Component,  OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AccountDayTermFormViewModel } from './AccountDayTermFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AccountDayTerm } from 'NebulaClient/Model/AtlasClientModel';
import { AccountPeriodDefinition } from 'NebulaClient/Model/AtlasClientModel';

@Component({
    selector: 'AccountDayTermForm',
    templateUrl: './AccountDayTermForm.html',
    providers: [MessageService]
})
export class AccountDayTermForm extends TTVisual.TTForm implements OnInit {
    AccountPeriod: TTVisual.ITTObjectListBox;
    Average: TTVisual.ITTTextBox;
    labelAccountPeriod: TTVisual.ITTLabel;
    labelAverage: TTVisual.ITTLabel;
    labelMovableAverage: TTVisual.ITTLabel;
    labelProcedureAverage: TTVisual.ITTLabel;
    MovableAverage: TTVisual.ITTTextBox;
    ProcedureAverage: TTVisual.ITTTextBox;
    public accountDayTermFormViewModel: AccountDayTermFormViewModel = new AccountDayTermFormViewModel();
    public get _AccountDayTerm(): AccountDayTerm {
        return this._TTObject as AccountDayTerm;
    }
    private AccountDayTermForm_DocumentUrl: string = '/api/AccountDayTermService/AccountDayTermForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('ACCOUNTDAYTERM', 'AccountDayTermForm');
        this._DocumentServiceUrl = this.AccountDayTermForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AccountDayTerm();
        this.accountDayTermFormViewModel = new AccountDayTermFormViewModel();
        this._ViewModel = this.accountDayTermFormViewModel;
        this.accountDayTermFormViewModel._AccountDayTerm = this._TTObject as AccountDayTerm;
        this.accountDayTermFormViewModel._AccountDayTerm.AccountPeriod = new AccountPeriodDefinition();
    }

    protected loadViewModel() {
        let that = this;
        that.accountDayTermFormViewModel = this._ViewModel as AccountDayTermFormViewModel;
        that._TTObject = this.accountDayTermFormViewModel._AccountDayTerm;
        if (this.accountDayTermFormViewModel == null)
            this.accountDayTermFormViewModel = new AccountDayTermFormViewModel();
        if (this.accountDayTermFormViewModel._AccountDayTerm == null)
            this.accountDayTermFormViewModel._AccountDayTerm = new AccountDayTerm();
        let accountPeriodObjectID = that.accountDayTermFormViewModel._AccountDayTerm["AccountPeriod"];
        if (accountPeriodObjectID != null && (typeof accountPeriodObjectID === "string")) {
            let accountPeriod = that.accountDayTermFormViewModel.AccountPeriodDefinitions.find(o => o.ObjectID.toString() === accountPeriodObjectID.toString());
            if (accountPeriod) {
                that.accountDayTermFormViewModel._AccountDayTerm.AccountPeriod = accountPeriod;
            }
        }

    }

    select(data) {
        let that = this;
        if (data.selectedRowKeys.length > 0) {
            let apiUrl: string = '/api/AccountDayTermService/AccountDayTermForm?id=' + data.selectedRowKeys[data.selectedRowKeys.length - 1].ObjectID.toString();
            this.httpService.get<any>(apiUrl).then(
                x => {
                    this._ViewModel = x;
                    that.loadViewModel();
                });
        }
    }

    AccountDays: Array<any> = new Array<any>();
    GetAccountDays() {
        let apiUrl: string = '/api/AccountDayTermService/GetAccountDays';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.AccountDays = x;
            });
    }

    RowRemoving(data) {
        let that = this;
        let apiUrl: string = '/api/AccountDayTermService/DeleteSelectedAccountDay?id=' + data.key.ObjectID.toString();
        this.httpService.get<any>(apiUrl).then(
            x => {
                that.GetAccountDays();
            });

    }

    public AccountDayColumns = [
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
            'caption': "Ortalama",
            dataField: 'Average',
            cellTemplate: "AverageCellTemplate",
            cssClass: "remove-padding"
        },
        {
            'caption': "Taşınır Ortalama",
            dataField: 'MovableAverage',
            cellTemplate: "MovableAverageCellTemplate",
            cssClass: "remove-padding"
        },
        {
            'caption': "Hizmet Ortalama",
            dataField: 'ProcedureAverage',
            cellTemplate: "ProcedureAverageCellTemplate",
            cssClass: "remove-padding"
        },
    ];

    public async save() {
        if (this._AccountDayTerm.Average == null) {
            this.messageService.showError("Ortalama Alanı Boş Geçilemez.");
            return;
        }
        if (this._AccountDayTerm.ProcedureAverage == null) {
            this.messageService.showError("Hizmet Ortalama Alanı Boş Geçilemez.");
            return;
        }
        if (this._AccountDayTerm.MovableAverage == null) {
            this.messageService.showError("Taşınır Ortalama Alanı Boş Geçilemez.");
            return;
        }

        await super.save();
        this.initViewModel();
        this.GetAccountDays();
    }

    async ngOnInit() {
        await this.load();
        this.GetAccountDays();

    }

    public onAccountPeriodChanged(event): void {
        if (this._AccountDayTerm != null && this._AccountDayTerm.AccountPeriod != event) {
            this._AccountDayTerm.AccountPeriod = event;
        }
    }

    public onAverageChanged(event): void {
        if (this._AccountDayTerm != null && this._AccountDayTerm.Average != event) {
            this._AccountDayTerm.Average = event;
        }
    }

    public onMovableAverageChanged(event): void {
        if (this._AccountDayTerm != null && this._AccountDayTerm.MovableAverage != event) {
            this._AccountDayTerm.MovableAverage = event;
        }
    }

    public onProcedureAverageChanged(event): void {
        if (this._AccountDayTerm != null && this._AccountDayTerm.ProcedureAverage != event) {
            this._AccountDayTerm.ProcedureAverage = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Average, "Text", this.__ttObject, "Average");
        redirectProperty(this.MovableAverage, "Text", this.__ttObject, "MovableAverage");
        redirectProperty(this.ProcedureAverage, "Text", this.__ttObject, "ProcedureAverage");
    }

    public initFormControls(): void {
        this.labelAccountPeriod = new TTVisual.TTLabel();
        this.labelAccountPeriod.Text = "Dönem";
        this.labelAccountPeriod.Name = "labelAccountPeriod";
        this.labelAccountPeriod.TabIndex = 7;

        this.AccountPeriod = new TTVisual.TTObjectListBox();
        this.AccountPeriod.ListDefName = "AccountPeriodList";
        this.AccountPeriod.Name = "AccountPeriod";
        this.AccountPeriod.TabIndex = 6;

        this.labelProcedureAverage = new TTVisual.TTLabel();
        this.labelProcedureAverage.Text = "Hizmet Ortalama";
        this.labelProcedureAverage.Name = "labelProcedureAverage";
        this.labelProcedureAverage.TabIndex = 5;

        this.ProcedureAverage = new TTVisual.TTTextBox();
        this.ProcedureAverage.Name = "ProcedureAverage";
        this.ProcedureAverage.TabIndex = 4;

        this.MovableAverage = new TTVisual.TTTextBox();
        this.MovableAverage.Name = "MovableAverage";
        this.MovableAverage.TabIndex = 2;

        this.Average = new TTVisual.TTTextBox();
        this.Average.Name = "Average";
        this.Average.TabIndex = 0;

        this.labelMovableAverage = new TTVisual.TTLabel();
        this.labelMovableAverage.Text = "Taşınır Ortalama";
        this.labelMovableAverage.Name = "labelMovableAverage";
        this.labelMovableAverage.TabIndex = 3;

        this.labelAverage = new TTVisual.TTLabel();
        this.labelAverage.Text = "Ortalama";
        this.labelAverage.Name = "labelAverage";
        this.labelAverage.TabIndex = 1;

        this.Controls = [this.labelAccountPeriod, this.AccountPeriod, this.labelProcedureAverage, this.ProcedureAverage, this.MovableAverage, this.Average, this.labelMovableAverage, this.labelAverage];

    }


}
