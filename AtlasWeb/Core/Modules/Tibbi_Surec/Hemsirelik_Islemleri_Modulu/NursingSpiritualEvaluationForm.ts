//$65CB0C9D
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingSpiritualEvaluationFormViewModel } from './NursingSpiritualEvaluationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingSpiritualEvaluation } from 'NebulaClient/Model/AtlasClientModel';

import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';



@Component({
    selector: 'NursingSpiritualEvaluationForm',
    templateUrl: './NursingSpiritualEvaluationForm.html',
    providers: [MessageService]
})
export class NursingSpiritualEvaluationForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    Explanation: TTVisual.ITTTextBox;
    Furious: TTVisual.ITTCheckBox;
    Indifferent: TTVisual.ITTCheckBox;
    labelApplicationDate: TTVisual.ITTLabel;
    labelExplanation: TTVisual.ITTLabel;
    Nervous: TTVisual.ITTCheckBox;
    Normal: TTVisual.ITTCheckBox;
    Other: TTVisual.ITTCheckBox;
    Sad: TTVisual.ITTCheckBox;
    public nursingSpiritualEvaluationFormViewModel: NursingSpiritualEvaluationFormViewModel = new NursingSpiritualEvaluationFormViewModel();
    public get _NursingSpiritualEvaluation(): NursingSpiritualEvaluation {
        return this._TTObject as NursingSpiritualEvaluation;
    }
    private NursingSpiritualEvaluationForm_DocumentUrl: string = '/api/NursingSpiritualEvaluationService/NursingSpiritualEvaluationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingSpiritualEvaluationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingSpiritualEvaluation();
        this.nursingSpiritualEvaluationFormViewModel = new NursingSpiritualEvaluationFormViewModel();
        this._ViewModel = this.nursingSpiritualEvaluationFormViewModel;
        this.nursingSpiritualEvaluationFormViewModel._NursingSpiritualEvaluation = this._TTObject as NursingSpiritualEvaluation;
    }

    protected loadViewModel() {
        let that = this;

        that.nursingSpiritualEvaluationFormViewModel = this._ViewModel as NursingSpiritualEvaluationFormViewModel;
        that._TTObject = this.nursingSpiritualEvaluationFormViewModel._NursingSpiritualEvaluation;
        if (this.nursingSpiritualEvaluationFormViewModel == null)
            this.nursingSpiritualEvaluationFormViewModel = new NursingSpiritualEvaluationFormViewModel();
        if (this.nursingSpiritualEvaluationFormViewModel._NursingSpiritualEvaluation == null)
            this.nursingSpiritualEvaluationFormViewModel._NursingSpiritualEvaluation = new NursingSpiritualEvaluation();

    }

    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.nursingSpiritualEvaluationFormViewModel.ReadOnly = (this.nursingSpiritualEvaluationFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingSpiritualEvaluationFormViewModel.ReadOnly)
            this.DropStateButton(NursingSpiritualEvaluation.NursingSpiritualEvaluationStates.Cancelled);
        super.ClientSidePreScript();
    }

    async ngOnInit()  {
        let that = this;
        await this.load(NursingSpiritualEvaluationFormViewModel);
  
    }


    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingSpiritualEvaluation != null && this._NursingSpiritualEvaluation.ApplicationDate != event) {
                this._NursingSpiritualEvaluation.ApplicationDate = event;
            }
        }
    }

    public onExplanationChanged(event): void {
        if (event != null) {
            if (this._NursingSpiritualEvaluation != null && this._NursingSpiritualEvaluation.Explanation != event) {
                this._NursingSpiritualEvaluation.Explanation = event;
            }
        }
    }

    public onFuriousChanged(event): void {
        if (event != null) {
            if (this._NursingSpiritualEvaluation != null && this._NursingSpiritualEvaluation.Furious != event) {
                this._NursingSpiritualEvaluation.Furious = event;
            }
        }
    }

    public onIndifferentChanged(event): void {
        if (event != null) {
            if (this._NursingSpiritualEvaluation != null && this._NursingSpiritualEvaluation.Indifferent != event) {
                this._NursingSpiritualEvaluation.Indifferent = event;
            }
        }
    }

    public onNervousChanged(event): void {
        if (event != null) {
            if (this._NursingSpiritualEvaluation != null && this._NursingSpiritualEvaluation.Nervous != event) {
                this._NursingSpiritualEvaluation.Nervous = event;
            }
        }
    }

    public onNormalChanged(event): void {
        if (event != null) {
            if (this._NursingSpiritualEvaluation != null && this._NursingSpiritualEvaluation.Normal != event) {
                this._NursingSpiritualEvaluation.Normal = event;
            }
        }
    }

    public onOtherChanged(event): void {
        if (event != null) {
            if (this._NursingSpiritualEvaluation != null && this._NursingSpiritualEvaluation.Other != event) {
                this._NursingSpiritualEvaluation.Other = event;
            }
        }
    }

    public onSadChanged(event): void {
        if (event != null) {
            if (this._NursingSpiritualEvaluation != null && this._NursingSpiritualEvaluation.Sad != event) {
                this._NursingSpiritualEvaluation.Sad = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.Normal, "Value", this.__ttObject, "Normal");
        redirectProperty(this.Furious, "Value", this.__ttObject, "Furious");
        redirectProperty(this.Sad, "Value", this.__ttObject, "Sad");
        redirectProperty(this.Nervous, "Value", this.__ttObject, "Nervous");
        redirectProperty(this.Indifferent, "Value", this.__ttObject, "Indifferent");
        redirectProperty(this.Other, "Value", this.__ttObject, "Other");
        redirectProperty(this.Explanation, "Text", this.__ttObject, "Explanation");
    }

    public initFormControls(): void {
        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 9;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 8;

        this.labelExplanation = new TTVisual.TTLabel();
        this.labelExplanation.Text = i18n("M10469", "Açıklama");
        this.labelExplanation.Name = "labelExplanation";
        this.labelExplanation.TabIndex = 7;

        this.Explanation = new TTVisual.TTTextBox();
        this.Explanation.Name = "Explanation";
        this.Explanation.TabIndex = 6;

        this.Other = new TTVisual.TTCheckBox();
        this.Other.Value = false;
        this.Other.Title = i18n("M12780", "Diğer");
        this.Other.Name = "Other";
        this.Other.TabIndex = 5;

        this.Indifferent = new TTVisual.TTCheckBox();
        this.Indifferent.Value = false;
        this.Indifferent.Title = i18n("M17435", "Kayıtsız");
        this.Indifferent.Name = "Indifferent";
        this.Indifferent.TabIndex = 4;

        this.Nervous = new TTVisual.TTCheckBox();
        this.Nervous.Value = false;
        this.Nervous.Title = i18n("M13718", "Endişeli");
        this.Nervous.Name = "Nervous";
        this.Nervous.TabIndex = 3;

        this.Sad = new TTVisual.TTCheckBox();
        this.Sad.Value = false;
        this.Sad.Title = i18n("M24001", "Üzüntülü");
        this.Sad.Name = "Sad";
        this.Sad.TabIndex = 2;

        this.Furious = new TTVisual.TTCheckBox();
        this.Furious.Value = false;
        this.Furious.Title = i18n("M19896", "Öfkeli");
        this.Furious.Name = "Furious";
        this.Furious.TabIndex = 1;

        this.Normal = new TTVisual.TTCheckBox();
        this.Normal.Value = false;
        this.Normal.Title = "Normal";
        this.Normal.Name = "Normal";
        this.Normal.TabIndex = 0;

        this.Controls = [this.labelApplicationDate, this.ApplicationDate, this.labelExplanation, this.Explanation, this.Other, this.Indifferent, this.Nervous, this.Sad, this.Furious, this.Normal];

    }


}
