//$32B00718
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { HemodialysisInstructionFormViewModel } from './HemodialysisInstructionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { HemodialysisInstruction } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'HemodialysisInstructionForm',
    templateUrl: './HemodialysisInstructionForm.html',
    providers: [MessageService]
})
export class HemodialysisInstructionForm extends BaseMultipleDataEntryForm implements OnInit {
    InstructionDate: TTVisual.ITTDateTimePicker;
    Subject: TTVisual.ITTTextBox;
    Purpose: TTVisual.ITTTextBox;
    Duration: TTVisual.ITTTextBox;

    public hemodialysisInstructionFormViewModel: HemodialysisInstructionFormViewModel = new HemodialysisInstructionFormViewModel();
    public get _HemodialysisInstruction(): HemodialysisInstruction {
        return this._TTObject as HemodialysisInstruction;
    }
    private HemodialysisInstructionForm_DocumentUrl: string = '/api/HemodialysisInstructionService/HemodialysisInstructionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.HemodialysisInstructionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HemodialysisInstruction();
        this.hemodialysisInstructionFormViewModel = new HemodialysisInstructionFormViewModel();
        this._ViewModel = this.hemodialysisInstructionFormViewModel;
        this.hemodialysisInstructionFormViewModel._HemodialysisInstruction = this._TTObject as HemodialysisInstruction;
    }

    protected loadViewModel() {
        let that = this;
        that.hemodialysisInstructionFormViewModel = this._ViewModel as HemodialysisInstructionFormViewModel;
        that._TTObject = this.hemodialysisInstructionFormViewModel._HemodialysisInstruction;
        if (this.hemodialysisInstructionFormViewModel == null)
            this.hemodialysisInstructionFormViewModel = new HemodialysisInstructionFormViewModel();
        if (this.hemodialysisInstructionFormViewModel._HemodialysisInstruction == null)
            this.hemodialysisInstructionFormViewModel._HemodialysisInstruction = new HemodialysisInstruction();
    }


    async ngOnInit() {
        await this.load();
    }


    public onInstructionDateChanged(event): void {
        if (this._HemodialysisInstruction != null && this._HemodialysisInstruction.InstructionDate != event) {
            this._HemodialysisInstruction.InstructionDate = event;
        }
    }

    public onSubjectChanged(event): void {
        if (this._HemodialysisInstruction != null && this._HemodialysisInstruction.Subject != event) {
            this._HemodialysisInstruction.Subject = event;
        }
    }

    public onPurposeChanged(event): void {
        if (this._HemodialysisInstruction != null && this._HemodialysisInstruction.Purpose != event) {
            this._HemodialysisInstruction.Purpose = event;
        }
    }

    public onDurationChanged(event): void {
        if (this._HemodialysisInstruction != null && this._HemodialysisInstruction.Duration != event) {
            this._HemodialysisInstruction.Duration = event;
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.InstructionDate, "Value", this.__ttObject, "InstructionDate");
        redirectProperty(this.Subject, "Text", this.__ttObject, "Subject");
        redirectProperty(this.Purpose, "Text", this.__ttObject, "Purpose");
        redirectProperty(this.Duration, "Text", this.__ttObject, "Duration");
    }

    public initFormControls(): void {

        this.InstructionDate = new TTVisual.TTDateTimePicker();
        this.InstructionDate.Format = DateTimePickerFormat.Long;
        this.InstructionDate.Name = "InstructionDate";
        this.InstructionDate.TabIndex = 7;

        this.Subject = new TTVisual.TTTextBox();
        this.Subject.Name = "Subject";
        this.Subject.TabIndex = 2;

        this.Purpose = new TTVisual.TTTextBox();
        this.Purpose.Name = "Purpose";
        this.Purpose.TabIndex = 2;

        this.Duration = new TTVisual.TTTextBox();
        this.Duration.Name = "Duration";
        this.Duration.TabIndex = 2;

        this.Controls = [this.InstructionDate, this.Subject, this.Purpose, this.Duration];

    }


}
