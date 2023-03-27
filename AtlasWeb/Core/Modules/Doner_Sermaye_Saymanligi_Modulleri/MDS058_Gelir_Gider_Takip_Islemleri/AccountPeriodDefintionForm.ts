//$0FA095E1
import { Component, OnInit  } from '@angular/core';
import { AccountPeriodDefintionFormViewModel } from './AccountPeriodDefintionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AccountPeriodDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'AccountPeriodDefintionForm',
    templateUrl: './AccountPeriodDefintionForm.html',
    providers: [MessageService]
})
export class AccountPeriodDefintionForm extends TTVisual.TTForm implements OnInit {
    labelMonth: TTVisual.ITTLabel;
    labelYear: TTVisual.ITTLabel;
    Month: TTVisual.ITTEnumComboBox;
    Year: TTVisual.ITTTextBox;
    public accountPeriodDefintionFormViewModel: AccountPeriodDefintionFormViewModel = new AccountPeriodDefintionFormViewModel();
    public get _AccountPeriodDefinition(): AccountPeriodDefinition {
        return this._TTObject as AccountPeriodDefinition;
    }
    private AccountPeriodDefintionForm_DocumentUrl: string = '/api/AccountPeriodDefinitionService/AccountPeriodDefintionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('ACCOUNTPERIODDEFINITION', 'AccountPeriodDefintionForm');
        this._DocumentServiceUrl = this.AccountPeriodDefintionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AccountPeriodDefinition();
        this.accountPeriodDefintionFormViewModel = new AccountPeriodDefintionFormViewModel();
        this._ViewModel = this.accountPeriodDefintionFormViewModel;
        this.accountPeriodDefintionFormViewModel._AccountPeriodDefinition = this._TTObject as AccountPeriodDefinition;
    }

    protected loadViewModel() {
        let that = this;
        that.accountPeriodDefintionFormViewModel = this._ViewModel as AccountPeriodDefintionFormViewModel;
        that._TTObject = this.accountPeriodDefintionFormViewModel._AccountPeriodDefinition;
        if (this.accountPeriodDefintionFormViewModel == null)
            this.accountPeriodDefintionFormViewModel = new AccountPeriodDefintionFormViewModel();
        if (this.accountPeriodDefintionFormViewModel._AccountPeriodDefinition == null)
            this.accountPeriodDefintionFormViewModel._AccountPeriodDefinition = new AccountPeriodDefinition();

    }

    async ngOnInit() {
        await this.load();
    }

    public onMonthChanged(event): void {
        if (this._AccountPeriodDefinition != null && this._AccountPeriodDefinition.Month != event) {
            this._AccountPeriodDefinition.Month = event;
        }
    }

    public onYearChanged(event): void {
        if (this._AccountPeriodDefinition != null && this._AccountPeriodDefinition.Year != event) {
            this._AccountPeriodDefinition.Year = event;
        }
    }
    public MonthDt = [
        {
            Name: "Ocak",
            Value: 1
        },
        {
            Name: 'Şubat',
            Value: 2
        },
        {
            Name: 'Mart',
            Value: 3
        },
        {
            Name: 'Nisan',
            Value: 4
        },
        {
            Name: 'Mayıs',
            Value: 5
        },
        {
            Name: 'Haziran',
            Value: 6
        },
        {
            Name: 'Temmuz',
            Value: 7
        },
        {
            Name: 'Ağustos',
            Value: 8
        },
        {
            Name: 'Eylül',
            Value: 9
        },
        {
            Name: 'Ekim',
            Value: 10
        },
        {
            Name: 'Kasım',
            Value: 11
        },
        {
            Name: 'Aralık',
            Value: 12
        }
    ];


    protected redirectProperties(): void {
        redirectProperty(this.Year, "Text", this.__ttObject, "Year");
        redirectProperty(this.Month, "Value", this.__ttObject, "Month");
    }

    public initFormControls(): void {
        this.labelMonth = new TTVisual.TTLabel();
        this.labelMonth.Text = "ttlabel2";
        this.labelMonth.Name = "labelMonth";
        this.labelMonth.TabIndex = 3;

        this.Month = new TTVisual.TTEnumComboBox();
        this.Month.DataTypeName = "MonthsEnum";
        this.Month.Name = "Month";
        this.Month.TabIndex = 2;

        this.labelYear = new TTVisual.TTLabel();
        this.labelYear.Text = "ttlabel1";
        this.labelYear.Name = "labelYear";
        this.labelYear.TabIndex = 1;

        this.Year = new TTVisual.TTTextBox();
        this.Year.Name = "Year";
        this.Year.TabIndex = 0;

        this.Controls = [this.labelMonth, this.Month, this.labelYear, this.Year];

    }


}
