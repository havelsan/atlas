//$9E1BB6DC
import { Component, OnInit  } from '@angular/core';
import { AccountVoucherCodeDefinitionFormViewModel } from './AccountVoucherCodeDefinitionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AccountVoucherCodeDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'AccountVoucherCodeDefinitionForm',
    templateUrl: './AccountVoucherCodeDefinitionForm.html',
    providers: [MessageService]
})
export class AccountVoucherCodeDefinitionForm extends TTVisual.TTForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    labelCode: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    IsDept: TTVisual.ITTCheckBox;
    public accountVoucherCodeDefinitionFormViewModel: AccountVoucherCodeDefinitionFormViewModel = new AccountVoucherCodeDefinitionFormViewModel();
    public get _AccountVoucherCodeDefinition(): AccountVoucherCodeDefinition {
        return this._TTObject as AccountVoucherCodeDefinition;
    }
    private AccountVoucherCodeDefinitionForm_DocumentUrl: string = '/api/AccountVoucherCodeDefinitionService/AccountVoucherCodeDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("AccountVoucherCodeDefinition", "AccountVoucherCodeDefinitionForm");
        this._DocumentServiceUrl = this.AccountVoucherCodeDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AccountVoucherCodeDefinition();
        this.accountVoucherCodeDefinitionFormViewModel = new AccountVoucherCodeDefinitionFormViewModel();
        this._ViewModel = this.accountVoucherCodeDefinitionFormViewModel;
        this.accountVoucherCodeDefinitionFormViewModel._AccountVoucherCodeDefinition = this._TTObject as AccountVoucherCodeDefinition;
    }

    protected loadViewModel() {
        let that = this;
        that.accountVoucherCodeDefinitionFormViewModel = this._ViewModel as AccountVoucherCodeDefinitionFormViewModel;
        that._TTObject = this.accountVoucherCodeDefinitionFormViewModel._AccountVoucherCodeDefinition;
        if (this.accountVoucherCodeDefinitionFormViewModel == null)
            this.accountVoucherCodeDefinitionFormViewModel = new AccountVoucherCodeDefinitionFormViewModel();
        if (this.accountVoucherCodeDefinitionFormViewModel._AccountVoucherCodeDefinition == null)
            this.accountVoucherCodeDefinitionFormViewModel._AccountVoucherCodeDefinition = new AccountVoucherCodeDefinition();

    }

    async ngOnInit() {
        await this.load();
    }

    public onCodeChanged(event): void {
        if (this._AccountVoucherCodeDefinition != null && this._AccountVoucherCodeDefinition.Code != event) {
            this._AccountVoucherCodeDefinition.Code = event;
        }
    }

    public onDescriptionChanged(event): void {
        if (this._AccountVoucherCodeDefinition != null && this._AccountVoucherCodeDefinition.Description != event) {
            this._AccountVoucherCodeDefinition.Description = event;
        }
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

    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.IsDept, "Value", this.__ttObject, "IsDept");
    }

    public initFormControls(): void {
        this.IsDept = new TTVisual.TTCheckBox();
        this.IsDept.Value = false;
        this.IsDept.Text = "Gelir Gider";
        this.IsDept.Name = "IsDept";
        this.IsDept.TabIndex = 4;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = "ttlabel2";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 3;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Name = "Description";
        this.Description.TabIndex = 2;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "ttlabel1";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 1;

        this.Controls = [this.labelDescription, this.Description, this.Code, this.labelCode];

    }


}
