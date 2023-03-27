//$6AA78BCE
import { Component, OnInit } from '@angular/core';
import { TermOpenCloseActionFormViewModel, GetAccountingTerm_Output } from './TermOpenCloseActionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { AccountingTerm } from 'NebulaClient/Model/AtlasClientModel';
import { CostingMethodEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { MainStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TermOpenCloseAction } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
@Component({
    selector: 'TermOpenCloseActionForm',
    templateUrl: './TermOpenCloseActionForm.html',
    providers: [MessageService]
})
export class TermOpenCloseActionForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    CloseTermAccountancy: TTVisual.ITTObjectListBox;
    DescriptionAccountingTerm: TTVisual.ITTTextBox;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelCloseTerm: TTVisual.ITTLabel;
    labelDescriptionAccountingTerm: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttdatetimepicker2: TTVisual.ITTDateTimePicker;
    ttdatetimepicker3: TTVisual.ITTDateTimePicker;
    ttdatetimepicker4: TTVisual.ITTDateTimePicker;
    ttenumcombobox1: TTVisual.ITTEnumComboBox;
    ttenumcombobox2: TTVisual.ITTEnumComboBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;
    public termOpenCloseActionFormViewModel: TermOpenCloseActionFormViewModel = new TermOpenCloseActionFormViewModel();
    public get _TermOpenCloseAction(): TermOpenCloseAction {
        return this._TTObject as TermOpenCloseAction;
    }
    private TermOpenCloseActionForm_DocumentUrl: string = '/api/TermOpenCloseActionService/TermOpenCloseActionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private objectContextService: ObjectContextService) {
        super('TERMOPENCLOSEACTION', 'TermOpenCloseActionForm');
        this._DocumentServiceUrl = this.TermOpenCloseActionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    inputStore: MainStoreDefinition;
    public setInputParam(value: MainStoreDefinition) {
        if (value != null) {
           // if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }


    async GetHalfOpenAccountingTerm(mainStoreInput: MainStoreDefinition): Promise<GetAccountingTerm_Output> {
        try {
            if (mainStoreInput !== undefined) {
                let url: string = '/api/TermOpenCloseActionService/GetHalfOpenAccountingTermByMainStore';
                let input = { 'mainStore': mainStoreInput };
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                let result = await httpService.post<GetAccountingTerm_Output>(url, input);
                return result;
            }
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    async GetOpenAccountingTermByMainStore(mainStoreInput: MainStoreDefinition): Promise<GetAccountingTerm_Output> {
        try {
            if (mainStoreInput !== undefined) {
                let url: string = '/api/TermOpenCloseActionService/GetOpenAccountingTermByMainStore';
                let input = { 'mainStore': mainStoreInput };
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                let result = await httpService.post<GetAccountingTerm_Output>(url, input);
                return result;
            }
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        await this.createNewTerm();
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new TermOpenCloseAction();
        this.termOpenCloseActionFormViewModel = new TermOpenCloseActionFormViewModel();
        this._ViewModel = this.termOpenCloseActionFormViewModel;
        this.termOpenCloseActionFormViewModel._TermOpenCloseAction = this._TTObject as TermOpenCloseAction;
        this.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm = new AccountingTerm();
        this.termOpenCloseActionFormViewModel._TermOpenCloseAction.CloseTerm = new AccountingTerm();
        this.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm.PrevTerm = new AccountingTerm();
        this.termOpenCloseActionFormViewModel._TermOpenCloseAction.CloseTerm.Accountancy = new Accountancy();
    }

    protected loadViewModel() {
        let that = this;
        that.termOpenCloseActionFormViewModel = this._ViewModel as TermOpenCloseActionFormViewModel;
        that._TTObject = this.termOpenCloseActionFormViewModel._TermOpenCloseAction;
        if (this.termOpenCloseActionFormViewModel == null)
            this.termOpenCloseActionFormViewModel = new TermOpenCloseActionFormViewModel();
        if (this.termOpenCloseActionFormViewModel._TermOpenCloseAction == null)
            this.termOpenCloseActionFormViewModel._TermOpenCloseAction = new TermOpenCloseAction();
        let openTermObjectID = that.termOpenCloseActionFormViewModel._TermOpenCloseAction["OpenTerm"];
        if (openTermObjectID != null && (typeof openTermObjectID === "string")) {
            let openTerm = that.termOpenCloseActionFormViewModel.AccountingTerms.find(o => o.ObjectID.toString() === openTermObjectID.toString());
             if (openTerm) {
                that.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm = openTerm;
            }
        }
        let closeTermObjectID = that.termOpenCloseActionFormViewModel._TermOpenCloseAction["CloseTerm"];
        if (closeTermObjectID != null && (typeof closeTermObjectID === "string")) {
            let closeTerm = that.termOpenCloseActionFormViewModel.AccountingTerms.find(o => o.ObjectID.toString() === closeTermObjectID.toString());
             if (closeTerm) {
                that.termOpenCloseActionFormViewModel._TermOpenCloseAction.CloseTerm = closeTerm;
            }
            if (closeTerm != null) {
                let accountancyObjectID = closeTerm["Accountancy"];
                if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
                    let accountancy = that.termOpenCloseActionFormViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
                     if (accountancy) {
                        closeTerm.Accountancy = accountancy;
                    }
                }
            }
        }

    }

    async createNewTerm() {
        let mainStore: MainStoreDefinition = this.inputStore;
        let halfOpenTerm = await this.GetHalfOpenAccountingTerm(mainStore);
        if ((<GetAccountingTerm_Output>halfOpenTerm).accountingTerm == null) {
            let closingTerm = await this.GetOpenAccountingTermByMainStore(mainStore);
            if (closingTerm !== null) {
                let accountancy: any = await this.objectContextService.getObject(new Guid(mainStore.Accountancy.toString()), Accountancy.ObjectDefID);
                this.termOpenCloseActionFormViewModel._TermOpenCloseAction.CloseTerm = closingTerm.accountingTerm;
                this.termOpenCloseActionFormViewModel._TermOpenCloseAction.CloseTerm.Accountancy = accountancy;
                this.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm = await this.objectContextService.getNewObject(AccountingTerm.ObjectDefID, AccountingTerm);
                this.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm.PrevTerm = closingTerm.accountingTerm;
                this.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm.CostingMethod = closingTerm.accountingTerm.CostingMethod;
                this.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm.Accountancy = closingTerm.accountingTerm.Accountancy;
                this.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm.StartDate = closingTerm.accountingTerm.EndDate.AddDays(1);
                this.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm.IsFirstTerm = false;
            }
            else {
                if (mainStore.Accountancy.AccountingTerms.length > 0) {
                    for (let accountingTerm of mainStore.Accountancy.AccountingTerms) {
                        if ((accountingTerm.IsFirstTerm !== undefined) && accountingTerm.IsFirstTerm === true)
                            throw new Exception((await SystemMessageService.GetMessage(926)));
                    }
                }
                this._ViewModel._TermOpenCloseAction.OpenTerm.Accountancy = mainStore.Accountancy;
                this._ViewModel._TermOpenCloseAction.OpenTerm.CostingMethod = CostingMethodEnum.FIFO;
                this._ViewModel._TermOpenCloseAction.OpenTerm.IsFirstTerm = true;
            }

            if ( !this.termOpenCloseActionFormViewModel.AccountingTerms) {
                this.termOpenCloseActionFormViewModel.AccountingTerms = new Array<AccountingTerm>();
                this.termOpenCloseActionFormViewModel.AccountingTerms.push(this.termOpenCloseActionFormViewModel._TermOpenCloseAction.OpenTerm);
                this.termOpenCloseActionFormViewModel.AccountingTerms.push(this.termOpenCloseActionFormViewModel._TermOpenCloseAction.CloseTerm);
            }
        }
        else {
            throw new Exception((await SystemMessageService.GetMessage(927)));
        }

    }

    async ngOnInit() {
        await this.load();
        //await this.createNewTerm();
        this.FormCaption = "Yeni Dönem Açma ( Yeni )";
    }

    public onCloseTermAccountancyChanged(event): void {
        if (event != null) {
            if (this._TermOpenCloseAction != null &&
                this._TermOpenCloseAction.CloseTerm != null && this._TermOpenCloseAction.CloseTerm.Accountancy != event) {
                this._TermOpenCloseAction.CloseTerm.Accountancy = event;
            }
        }
    }

    public onDescriptionAccountingTermChanged(event): void {
        if (event != null) {
            if (this._TermOpenCloseAction != null &&
                this._TermOpenCloseAction.OpenTerm != null && this._TermOpenCloseAction.OpenTerm.Description != event) {
                this._TermOpenCloseAction.OpenTerm.Description = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._TermOpenCloseAction != null &&
                this._TermOpenCloseAction.CloseTerm != null && this._TermOpenCloseAction.CloseTerm.StartDate != event) {
                this._TermOpenCloseAction.CloseTerm.StartDate = event;
            }
        }
    }

    public onttdatetimepicker2Changed(event): void {
        if (event != null) {
            if (this._TermOpenCloseAction != null &&
                this._TermOpenCloseAction.CloseTerm != null && this._TermOpenCloseAction.CloseTerm.EndDate != event) {
                this._TermOpenCloseAction.CloseTerm.EndDate = event;
            }
        }
    }

    public onttdatetimepicker3Changed(event): void {
        if (event != null) {
            if (this._TermOpenCloseAction != null &&
                this._TermOpenCloseAction.OpenTerm != null && this._TermOpenCloseAction.OpenTerm.EndDate != event) {
                this._TermOpenCloseAction.OpenTerm.EndDate = event;
            }
        }
    }

    public onttdatetimepicker4Changed(event): void {
        if (event != null) {
            if (this._TermOpenCloseAction != null &&
                this._TermOpenCloseAction.OpenTerm != null && this._TermOpenCloseAction.OpenTerm.StartDate != event) {
                this._TermOpenCloseAction.OpenTerm.StartDate = event;
            }
        }
    }

    public onttenumcombobox1Changed(event): void {
        if (event != null) {
            if (this._TermOpenCloseAction != null &&
                this._TermOpenCloseAction.CloseTerm != null && this._TermOpenCloseAction.CloseTerm.CostingMethod != event) {
                this._TermOpenCloseAction.CloseTerm.CostingMethod = event;
            }
        }
    }

    public onttenumcombobox2Changed(event): void {
        if (event != null) {
            if (this._TermOpenCloseAction != null &&
                this._TermOpenCloseAction.OpenTerm != null && this._TermOpenCloseAction.OpenTerm.CostingMethod != event) {
                this._TermOpenCloseAction.OpenTerm.CostingMethod = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._TermOpenCloseAction != null &&
                this._TermOpenCloseAction.CloseTerm != null && this._TermOpenCloseAction.CloseTerm.Description != event) {
                this._TermOpenCloseAction.CloseTerm.Description = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "CloseTerm.StartDate");
        redirectProperty(this.ttdatetimepicker2, "Value", this.__ttObject, "CloseTerm.EndDate");
        redirectProperty(this.ttenumcombobox1, "Value", this.__ttObject, "CloseTerm.CostingMethod");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "CloseTerm.Description");
        redirectProperty(this.ttdatetimepicker4, "Value", this.__ttObject, "OpenTerm.StartDate");
        redirectProperty(this.ttdatetimepicker3, "Value", this.__ttObject, "OpenTerm.EndDate");
        redirectProperty(this.ttenumcombobox2, "Value", this.__ttObject, "OpenTerm.CostingMethod");
        redirectProperty(this.DescriptionAccountingTerm, "Text", this.__ttObject, "OpenTerm.Description");
    }

    public initFormControls(): void {
        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = "Açılacak Dönem";
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 7;

        this.labelDescriptionAccountingTerm = new TTVisual.TTLabel();
        this.labelDescriptionAccountingTerm.Text = i18n("M10469", "Açıklama");
        this.labelDescriptionAccountingTerm.Name = "labelDescriptionAccountingTerm";
        this.labelDescriptionAccountingTerm.TabIndex = 7;

        this.DescriptionAccountingTerm = new TTVisual.TTTextBox();
        this.DescriptionAccountingTerm.Required = true;
        this.DescriptionAccountingTerm.BackColor = "#FFE3C6";
        this.DescriptionAccountingTerm.Name = "DescriptionAccountingTerm";
        this.DescriptionAccountingTerm.TabIndex = 6;

        this.ttdatetimepicker3 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker3.Required = true;
        this.ttdatetimepicker3.BackColor = "#FFE3C6";
        this.ttdatetimepicker3.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker3.Name = "ttdatetimepicker3";
        this.ttdatetimepicker3.TabIndex = 1;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M18537", "Maliyetlendirme Yöntemi");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 5;

        this.ttdatetimepicker4 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker4.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker4.Name = "ttdatetimepicker4";
        this.ttdatetimepicker4.TabIndex = 0;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M11939", "Bitiş Tarihi");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 5;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M11637", "Başlangıç Tarihi");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 5;

        this.ttenumcombobox2 = new TTVisual.TTEnumComboBox();
        this.ttenumcombobox2.DataTypeName = "CostingMethodEnum";
        this.ttenumcombobox2.BackColor = "#F0F0F0";
        this.ttenumcombobox2.Enabled = false;
        this.ttenumcombobox2.Name = "ttenumcombobox2";
        this.ttenumcombobox2.TabIndex = 2;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = "Kapatılacak Dönem";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 6;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 7;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 6;

        this.ttenumcombobox1 = new TTVisual.TTEnumComboBox();
        this.ttenumcombobox1.DataTypeName = "CostingMethodEnum";
        this.ttenumcombobox1.BackColor = "#F0F0F0";
        this.ttenumcombobox1.Enabled = false;
        this.ttenumcombobox1.Name = "ttenumcombobox1";
        this.ttenumcombobox1.TabIndex = 2;

        this.ttdatetimepicker2 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker2.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker2.Name = "ttdatetimepicker2";
        this.ttdatetimepicker2.TabIndex = 1;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.BackColor = "#F0F0F0";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker1.Enabled = false;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 0;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M11637", "Başlangıç Tarihi");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 5;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M11939", "Bitiş Tarihi");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 5;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M18537", "Maliyetlendirme Yöntemi");
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 5;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16866", "İşlem No");
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 5;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = "#F0F0F0";
        this.ID.ReadOnly = true;
        this.ID.Name = "ID";
        this.ID.TabIndex = 4;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 1;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.CloseTermAccountancy = new TTVisual.TTObjectListBox();
        this.CloseTermAccountancy.ReadOnly = true;
        this.CloseTermAccountancy.ListDefName = "AccountancyList";
        this.CloseTermAccountancy.Name = "CloseTermAccountancy";
        this.CloseTermAccountancy.TabIndex = 14;

        this.labelCloseTerm = new TTVisual.TTLabel();
        this.labelCloseTerm.Text = i18n("M21460", "Saymanlık");
        this.labelCloseTerm.Name = "labelCloseTerm";
        this.labelCloseTerm.TabIndex = 15;

        this.ttgroupbox2.Controls = [this.labelDescriptionAccountingTerm, this.DescriptionAccountingTerm, this.ttdatetimepicker3, this.ttlabel6, this.ttdatetimepicker4, this.ttlabel5, this.ttlabel4, this.ttenumcombobox2];
        this.ttgroupbox1.Controls = [this.ttlabel1, this.tttextbox1, this.ttenumcombobox1, this.ttdatetimepicker2, this.ttdatetimepicker1, this.ttlabel2, this.ttlabel3, this.ttlabel7];
        this.Controls = [this.ttgroupbox2, this.labelDescriptionAccountingTerm, this.DescriptionAccountingTerm, this.ttdatetimepicker3, this.ttlabel6, this.ttdatetimepicker4, this.ttlabel5, this.ttlabel4, this.ttenumcombobox2, this.ttgroupbox1, this.ttlabel1, this.tttextbox1, this.ttenumcombobox1, this.ttdatetimepicker2, this.ttdatetimepicker1, this.ttlabel2, this.ttlabel3, this.ttlabel7, this.labelID, this.ID, this.labelActionDate, this.ActionDate, this.CloseTermAccountancy, this.labelCloseTerm];

    }


}
