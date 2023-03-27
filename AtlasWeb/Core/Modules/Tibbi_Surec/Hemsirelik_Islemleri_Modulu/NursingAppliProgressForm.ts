//$A064FE2A
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingAppliProgressFormViewModel } from './NursingAppliProgressFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { NursingAppliProgress } from 'NebulaClient/Model/AtlasClientModel';
import { BaseNursingDataEntryForm } from './BaseNursingDataEntryForm';

import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'NursingAppliProgressForm',
    templateUrl: './NursingAppliProgressForm.html',
    providers: [MessageService]
})
export class NursingAppliProgressForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    Description: TTVisual.ITTTextBox;
    HandOverNote: TTVisual.ITTCheckBox;
    labelApplicationDate: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    public nursingAppliProgressFormViewModel: NursingAppliProgressFormViewModel = new NursingAppliProgressFormViewModel();
    public get _NursingAppliProgress(): NursingAppliProgress {
        return this._TTObject as NursingAppliProgress;
    }
    private NursingAppliProgressForm_DocumentUrl: string = '/api/NursingAppliProgressService/NursingAppliProgressForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingAppliProgressForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****



    public initViewModel(): void {
        this._TTObject = new NursingAppliProgress();
        this.nursingAppliProgressFormViewModel = new NursingAppliProgressFormViewModel();
        this._ViewModel = this.nursingAppliProgressFormViewModel;
        this.nursingAppliProgressFormViewModel._NursingAppliProgress = this._TTObject as NursingAppliProgress;
    }

    protected loadViewModel() {
        let that = this;

        that.nursingAppliProgressFormViewModel = this._ViewModel as NursingAppliProgressFormViewModel;
        that._TTObject = this.nursingAppliProgressFormViewModel._NursingAppliProgress;
        if (this.nursingAppliProgressFormViewModel == null) {
            this.nursingAppliProgressFormViewModel = new NursingAppliProgressFormViewModel();
        }
        if (this.nursingAppliProgressFormViewModel._NursingAppliProgress == null) {
            this.nursingAppliProgressFormViewModel._NursingAppliProgress = new NursingAppliProgress();
        }

    }

    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.nursingAppliProgressFormViewModel.ReadOnly = (this.nursingAppliProgressFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingAppliProgressFormViewModel.ReadOnly)
            this.DropStateButton(NursingAppliProgress.NursingAppliProgressStates.Cancelled);

        super.ClientSidePreScript();
    }

    async ngOnInit()  {
        let that = this;
        await this.load(NursingAppliProgressFormViewModel);
  
    }


    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingAppliProgress != null && this._NursingAppliProgress.ApplicationDate !== event) {
                this._NursingAppliProgress.ApplicationDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._NursingAppliProgress != null && this._NursingAppliProgress.Description !== event) {
                this._NursingAppliProgress.Description = event;
            }
        }
    }

    public onHandOverNoteChanged(event): void {
        if (event != null) {
            if (this._NursingAppliProgress != null && this._NursingAppliProgress.HandOverNote !== event) {
                this._NursingAppliProgress.HandOverNote = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, 'Value', this.__ttObject, 'ApplicationDate');
        redirectProperty(this.HandOverNote, 'Value', this.__ttObject, 'HandOverNote');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = 'labelApplicationDate';
        this.labelApplicationDate.TabIndex = 4;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Required = true;
        this.ApplicationDate.BackColor = '#FFE3C6';
        this.ApplicationDate.CustomFormat = "dd.MM.yyyy HH:mm";
        this.ApplicationDate.Format = DateTimePickerFormat.Custom;
        this.ApplicationDate.Name = 'ApplicationDate';
        this.ApplicationDate.TabIndex = 3;

        this.HandOverNote = new TTVisual.TTCheckBox();
        this.HandOverNote.Value = false;
        this.HandOverNote.Title = i18n("M12698", "Devir Teslim Notu");
        this.HandOverNote.Name = 'HandOverNote';
        this.HandOverNote.TabIndex = 2;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = 'labelDescription';
        this.labelDescription.TabIndex = 1;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Required = true;
        this.Description.Multiline = true;
        this.Description.BackColor = '#FFE3C6';
        this.Description.Name = 'Description';
        this.Description.TabIndex = 0;

        this.Controls = [this.labelApplicationDate, this.ApplicationDate, this.HandOverNote, this.labelDescription, this.Description];

    }


}
