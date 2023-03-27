//$A3AF4686
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingPupilSymptomsFormViewModel } from './NursingPupilSymptomsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingPupilSymptoms } from 'NebulaClient/Model/AtlasClientModel';

import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';



@Component({
    selector: 'NursingPupilSymptomsForm',
    templateUrl: './NursingPupilSymptomsForm.html',
    providers: [MessageService]
})
export class NursingPupilSymptomsForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    labelApplicationDate: TTVisual.ITTLabel;
    labelLeftGleamRef: TTVisual.ITTLabel;
    labelLeftPupil: TTVisual.ITTLabel;
    labelLeftPupilWideness: TTVisual.ITTLabel;
    labelRightGleamRef: TTVisual.ITTLabel;
    labelRightPupil: TTVisual.ITTLabel;
    labelRightPupilWideness: TTVisual.ITTLabel;
    LeftGleamRef: TTVisual.ITTEnumComboBox;
    LeftPupil: TTVisual.ITTEnumComboBox;
    LeftPupilWideness: TTVisual.ITTEnumComboBox;
    RightGleamRef: TTVisual.ITTEnumComboBox;
    RightPupil: TTVisual.ITTEnumComboBox;
    RightPupilWideness: TTVisual.ITTEnumComboBox;
    public nursingPupilSymptomsFormViewModel: NursingPupilSymptomsFormViewModel = new NursingPupilSymptomsFormViewModel();
    public get _NursingPupilSymptoms(): NursingPupilSymptoms {
        return this._TTObject as NursingPupilSymptoms;
    }
    private NursingPupilSymptomsForm_DocumentUrl: string = '/api/NursingPupilSymptomsService/NursingPupilSymptomsForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingPupilSymptomsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingPupilSymptoms();
        this.nursingPupilSymptomsFormViewModel = new NursingPupilSymptomsFormViewModel();
        this._ViewModel = this.nursingPupilSymptomsFormViewModel;
        this.nursingPupilSymptomsFormViewModel._NursingPupilSymptoms = this._TTObject as NursingPupilSymptoms;
    }

    protected loadViewModel() {
        let that = this;

        that.nursingPupilSymptomsFormViewModel = this._ViewModel as NursingPupilSymptomsFormViewModel;
        that._TTObject = this.nursingPupilSymptomsFormViewModel._NursingPupilSymptoms;
        if (this.nursingPupilSymptomsFormViewModel == null)
            this.nursingPupilSymptomsFormViewModel = new NursingPupilSymptomsFormViewModel();
        if (this.nursingPupilSymptomsFormViewModel._NursingPupilSymptoms == null)
            this.nursingPupilSymptomsFormViewModel._NursingPupilSymptoms = new NursingPupilSymptoms();

    }

    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.nursingPupilSymptomsFormViewModel.ReadOnly = (this.nursingPupilSymptomsFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingPupilSymptomsFormViewModel.ReadOnly)
            this.DropStateButton(NursingPupilSymptoms.NursingPupilSymptomsStates.Cancelled);
        super.ClientSidePreScript();
    }

    async ngOnInit()  {
        let that = this;
        await this.load(NursingPupilSymptomsFormViewModel);
  
    }


    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingPupilSymptoms != null && this._NursingPupilSymptoms.ApplicationDate != event) {
                this._NursingPupilSymptoms.ApplicationDate = event;
            }
        }
    }

    public onLeftGleamRefChanged(event): void {
        if (event != null) {
            if (this._NursingPupilSymptoms != null && this._NursingPupilSymptoms.LeftGleamRef != event) {
                this._NursingPupilSymptoms.LeftGleamRef = event;
            }
        }
    }

    public onLeftPupilChanged(event): void {
        if (event != null) {
            if (this._NursingPupilSymptoms != null && this._NursingPupilSymptoms.LeftPupil != event) {
                this._NursingPupilSymptoms.LeftPupil = event;
            }
        }
    }

    public onLeftPupilWidenessChanged(event): void {
        if (event != null) {
            if (this._NursingPupilSymptoms != null && this._NursingPupilSymptoms.LeftPupilWideness != event) {
                this._NursingPupilSymptoms.LeftPupilWideness = event;
            }
        }
    }

    public onRightGleamRefChanged(event): void {
        if (event != null) {
            if (this._NursingPupilSymptoms != null && this._NursingPupilSymptoms.RightGleamRef != event) {
                this._NursingPupilSymptoms.RightGleamRef = event;
            }
        }
    }

    public onRightPupilChanged(event): void {
        if (event != null) {
            if (this._NursingPupilSymptoms != null && this._NursingPupilSymptoms.RightPupil != event) {
                this._NursingPupilSymptoms.RightPupil = event;
            }
        }
    }

    public onRightPupilWidenessChanged(event): void {
        if (event != null) {
            if (this._NursingPupilSymptoms != null && this._NursingPupilSymptoms.RightPupilWideness != event) {
                this._NursingPupilSymptoms.RightPupilWideness = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.RightPupil, "Value", this.__ttObject, "RightPupil");
        redirectProperty(this.RightPupilWideness, "Value", this.__ttObject, "RightPupilWideness");
        redirectProperty(this.RightGleamRef, "Value", this.__ttObject, "RightGleamRef");
        redirectProperty(this.LeftPupil, "Value", this.__ttObject, "LeftPupil");
        redirectProperty(this.LeftPupilWideness, "Value", this.__ttObject, "LeftPupilWideness");
        redirectProperty(this.LeftGleamRef, "Value", this.__ttObject, "LeftGleamRef");
    }

    public initFormControls(): void {
        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 15;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 14;

        this.labelRightPupilWideness = new TTVisual.TTLabel();
        this.labelRightPupilWideness.Text = i18n("M21138", "Sağ Pupil Genişliği");
        this.labelRightPupilWideness.Name = "labelRightPupilWideness";
        this.labelRightPupilWideness.TabIndex = 13;

        this.RightPupilWideness = new TTVisual.TTEnumComboBox();
        this.RightPupilWideness.DataTypeName = "PupilWidenessEnum";
        this.RightPupilWideness.Name = "RightPupilWideness";
        this.RightPupilWideness.TabIndex = 2;

        this.labelRightPupil = new TTVisual.TTLabel();
        this.labelRightPupil.Text = i18n("M21137", "Sağ Pupil");
        this.labelRightPupil.Name = "labelRightPupil";
        this.labelRightPupil.TabIndex = 11;

        this.RightPupil = new TTVisual.TTEnumComboBox();
        this.RightPupil.DataTypeName = "PupilPropertiesEnum";
        this.RightPupil.Name = "RightPupil";
        this.RightPupil.TabIndex = 1;

        this.labelRightGleamRef = new TTVisual.TTLabel();
        this.labelRightGleamRef.Text = i18n("M16029", "Işık Ref Sağ");
        this.labelRightGleamRef.Name = "labelRightGleamRef";
        this.labelRightGleamRef.TabIndex = 9;

        this.RightGleamRef = new TTVisual.TTEnumComboBox();
        this.RightGleamRef.DataTypeName = "PositiveNegativeEnum";
        this.RightGleamRef.Name = "RightGleamRef";
        this.RightGleamRef.TabIndex = 3;

        this.labelLeftPupilWideness = new TTVisual.TTLabel();
        this.labelLeftPupilWideness.Text = i18n("M22012", "Sol Pupil Genişliği");
        this.labelLeftPupilWideness.Name = "labelLeftPupilWideness";
        this.labelLeftPupilWideness.TabIndex = 7;

        this.LeftPupilWideness = new TTVisual.TTEnumComboBox();
        this.LeftPupilWideness.DataTypeName = "PupilWidenessEnum";
        this.LeftPupilWideness.Name = "LeftPupilWideness";
        this.LeftPupilWideness.TabIndex = 5;

        this.labelLeftPupil = new TTVisual.TTLabel();
        this.labelLeftPupil.Text = i18n("M22011", "Sol Pupil");
        this.labelLeftPupil.Name = "labelLeftPupil";
        this.labelLeftPupil.TabIndex = 5;

        this.LeftPupil = new TTVisual.TTEnumComboBox();
        this.LeftPupil.DataTypeName = "PupilPropertiesEnum";
        this.LeftPupil.Name = "LeftPupil";
        this.LeftPupil.TabIndex = 4;

        this.labelLeftGleamRef = new TTVisual.TTLabel();
        this.labelLeftGleamRef.Text = i18n("M16030", "Işık Ref Sol");
        this.labelLeftGleamRef.Name = "labelLeftGleamRef";
        this.labelLeftGleamRef.TabIndex = 3;

        this.LeftGleamRef = new TTVisual.TTEnumComboBox();
        this.LeftGleamRef.DataTypeName = "PositiveNegativeEnum";
        this.LeftGleamRef.Name = "LeftGleamRef";
        this.LeftGleamRef.TabIndex = 6;

        this.Controls = [this.labelApplicationDate, this.ApplicationDate, this.labelRightPupilWideness, this.RightPupilWideness, this.labelRightPupil, this.RightPupil, this.labelRightGleamRef, this.RightGleamRef, this.labelLeftPupilWideness, this.LeftPupilWideness, this.labelLeftPupil, this.LeftPupil, this.labelLeftGleamRef, this.LeftGleamRef];

    }


}
