//$879839B9
import { Component, OnInit  } from '@angular/core';
import { MuscleStrengthMeasuringFormViewModel } from './MuscleStrengthMeasuringFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MuscleStrengthMeasuringForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'MuscleStrengthMeasuringForm',
    templateUrl: './MuscleStrengthMeasuringFormForm.html',
    providers: [MessageService]
})
export class MuscleStrengthMeasuringFormForm extends BaseAdditionalInfoForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    GripStrengthMeasuring: TTVisual.ITTTextBox;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelGripStrengthMeasuring: TTVisual.ITTLabel;
    public muscleStrengthMeasuringFormViewModel: MuscleStrengthMeasuringFormViewModel = new MuscleStrengthMeasuringFormViewModel();
    public get _MuscleStrengthMeasuringForm(): MuscleStrengthMeasuringForm {
        return this._TTObject as MuscleStrengthMeasuringForm;
    }
    private MuscleStrengthMeasuringForm_DocumentUrl: string = '/api/MuscleStrengthMeasuringFormService/MuscleStrengthMeasuringForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.MuscleStrengthMeasuringForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MuscleStrengthMeasuringForm();
        this.muscleStrengthMeasuringFormViewModel = new MuscleStrengthMeasuringFormViewModel();
        this._ViewModel = this.muscleStrengthMeasuringFormViewModel;
        this.muscleStrengthMeasuringFormViewModel._MuscleStrengthMeasuringForm = this._TTObject as MuscleStrengthMeasuringForm;
    }

    protected loadViewModel() {
        let that = this;
        that.muscleStrengthMeasuringFormViewModel = this._ViewModel as MuscleStrengthMeasuringFormViewModel;
        that._TTObject = this.muscleStrengthMeasuringFormViewModel._MuscleStrengthMeasuringForm;
        if (this.muscleStrengthMeasuringFormViewModel == null)
            this.muscleStrengthMeasuringFormViewModel = new MuscleStrengthMeasuringFormViewModel();
        if (this.muscleStrengthMeasuringFormViewModel._MuscleStrengthMeasuringForm == null)
            this.muscleStrengthMeasuringFormViewModel._MuscleStrengthMeasuringForm = new MuscleStrengthMeasuringForm();

    }

    async ngOnInit() {
        await this.load(MuscleStrengthMeasuringFormViewModel);
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._MuscleStrengthMeasuringForm != null && this._MuscleStrengthMeasuringForm.Code != event) {
                this._MuscleStrengthMeasuringForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._MuscleStrengthMeasuringForm != null && this._MuscleStrengthMeasuringForm.CreationDate != event) {
                this._MuscleStrengthMeasuringForm.CreationDate = event;
            }
        }
    }

    public onGripStrengthMeasuringChanged(event): void {
        if (event != null) {
            if (this._MuscleStrengthMeasuringForm != null && this._MuscleStrengthMeasuringForm.GripStrengthMeasuring != event) {
                this._MuscleStrengthMeasuringForm.GripStrengthMeasuring = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.GripStrengthMeasuring, "Text", this.__ttObject, "GripStrengthMeasuring");
    }

    public initFormControls(): void {
        this.labelGripStrengthMeasuring = new TTVisual.TTLabel();
        this.labelGripStrengthMeasuring.Text = i18n("M17004", "Kaba ve İnce Kavrama Gücünün Ölçümü");
        this.labelGripStrengthMeasuring.Name = "labelGripStrengthMeasuring";
        this.labelGripStrengthMeasuring.TabIndex = 5;

        this.GripStrengthMeasuring = new TTVisual.TTTextBox();
        this.GripStrengthMeasuring.Name = "GripStrengthMeasuring";
        this.GripStrengthMeasuring.TabIndex = 4;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = i18n("M13549", "Ekleme Tarihi Saati");
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 3;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 2;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kodu";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 1;

        this.Controls = [this.labelGripStrengthMeasuring, this.GripStrengthMeasuring, this.Code, this.labelCreationDate, this.CreationDate, this.labelCode];

    }


}
