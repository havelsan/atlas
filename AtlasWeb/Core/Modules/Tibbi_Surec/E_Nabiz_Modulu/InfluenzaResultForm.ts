//$16C62681
import { Component, OnInit  } from '@angular/core';
import { InfluenzaResultFormViewModel } from './InfluenzaResultFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InfluenzaResult } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'InfluenzaResultForm',
    templateUrl: 'InfluenzaResultForm.html',
    providers: [MessageService]
})
export class InfluenzaResultForm extends TTVisual.TTForm implements OnInit {
    ErrorMessage: TTVisual.ITTTextBox;
    InfluenzaResultProp: TTVisual.ITTEnumComboBox;
    labelErrorMessage: TTVisual.ITTLabel;
    labelInfluenzaResultProp: TTVisual.ITTLabel;
    public influenzaResultFormViewModel: InfluenzaResultFormViewModel = new InfluenzaResultFormViewModel();
    public get _InfluenzaResult(): InfluenzaResult {
        return this._TTObject as InfluenzaResult;
    }
    private InfluenzaResultForm_DocumentUrl: string = '/api/InfluenzaResultService/InfluenzaResultForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('INFLUENZARESULT', 'InfluenzaResultForm');
        this._DocumentServiceUrl = this.InfluenzaResultForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InfluenzaResult();
        this.influenzaResultFormViewModel = new InfluenzaResultFormViewModel();
        this._ViewModel = this.influenzaResultFormViewModel;
        this.influenzaResultFormViewModel._InfluenzaResult = this._TTObject as InfluenzaResult;
    }

    protected loadViewModel() {
        let that = this;
        that.influenzaResultFormViewModel = this._ViewModel as InfluenzaResultFormViewModel;
        that._TTObject = this.influenzaResultFormViewModel._InfluenzaResult;
        if (this.influenzaResultFormViewModel == null)
            this.influenzaResultFormViewModel = new InfluenzaResultFormViewModel();
        if (this.influenzaResultFormViewModel._InfluenzaResult == null)
            this.influenzaResultFormViewModel._InfluenzaResult = new InfluenzaResult();

    }

    async ngOnInit() {
        await this.load();
    }

    public onErrorMessageChanged(event): void {
        if (this._InfluenzaResult != null && this._InfluenzaResult.ErrorMessage != event) {
            this._InfluenzaResult.ErrorMessage = event;
        }
    }

    public onInfluenzaResultPropChanged(event): void {
        if (this._InfluenzaResult != null && this._InfluenzaResult.InfluenzaResultProp != event) {
            this._InfluenzaResult.InfluenzaResultProp = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.InfluenzaResultProp, "Value", this.__ttObject, "InfluenzaResultProp");
        redirectProperty(this.ErrorMessage, "Text", this.__ttObject, "ErrorMessage");
    }

    public initFormControls(): void {
        this.labelErrorMessage = new TTVisual.TTLabel();
        this.labelErrorMessage.Text = "Hata Mesajı";
        this.labelErrorMessage.Name = "labelErrorMessage";
        this.labelErrorMessage.TabIndex = 3;

        this.ErrorMessage = new TTVisual.TTTextBox();
        this.ErrorMessage.Multiline = true;
        this.ErrorMessage.Name = "ErrorMessage";
        this.ErrorMessage.TabIndex = 2;
        this.ErrorMessage.ForeColor = "red";

        this.labelInfluenzaResultProp = new TTVisual.TTLabel();
        this.labelInfluenzaResultProp.Text = "Sonuç";
        this.labelInfluenzaResultProp.Name = "labelInfluenzaResultProp";
        this.labelInfluenzaResultProp.TabIndex = 1;

        this.InfluenzaResultProp = new TTVisual.TTEnumComboBox();
        this.InfluenzaResultProp.DataTypeName = "PositiveNegativeEnum";
        this.InfluenzaResultProp.Name = "InfluenzaResultProp";
        this.InfluenzaResultProp.TabIndex = 0;

        this.Controls = [this.labelErrorMessage, this.ErrorMessage, this.labelInfluenzaResultProp, this.InfluenzaResultProp];

    }


}
