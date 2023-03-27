//$F69B2BC4
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PhysiotherapyTreatmentNoteFormViewModel } from './PhysiotherapyTreatmentNoteFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysiotherapyTreatmentNote } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'PhysiotherapyTreatmentNoteForm',
    templateUrl: './PhysiotherapyTreatmentNoteForm.html',
    providers: [MessageService]
})
export class PhysiotherapyTreatmentNoteForm extends TTVisual.TTForm implements OnInit {
    Description: TTVisual.ITTRichTextBoxControl;
    EntryDate: TTVisual.ITTDateTimePicker;
    EntryUser: TTVisual.ITTObjectListBox;
    labelDescription: TTVisual.ITTLabel;
    labelEntryDate: TTVisual.ITTLabel;
    labelEntryUser: TTVisual.ITTLabel;
    public physiotherapyTreatmentNoteFormViewModel: PhysiotherapyTreatmentNoteFormViewModel = new PhysiotherapyTreatmentNoteFormViewModel();
    public get _PhysiotherapyTreatmentNote(): PhysiotherapyTreatmentNote {
        return this._TTObject as PhysiotherapyTreatmentNote;
    }
    private PhysiotherapyTreatmentNoteForm_DocumentUrl: string = '/api/PhysiotherapyTreatmentNoteService/PhysiotherapyTreatmentNoteForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('PHYSIOTHERAPYTREATMENTNOTE', 'PhysiotherapyTreatmentNoteForm');
        this._DocumentServiceUrl = this.PhysiotherapyTreatmentNoteForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private isNewTreatmentNote: boolean = false;
    public setInputParam(value: boolean) {
        if (value != null && value['isNewTreatmentNote'] != null) {
            this.isNewTreatmentNote = value['isNewTreatmentNote']; //true->Yeni, false->eski ; Yeni tedavi notu ise not giriş inputu açılacak değilse sadece girilmiş notlar gösterilecek.
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PhysiotherapyTreatmentNote();
        this.physiotherapyTreatmentNoteFormViewModel = new PhysiotherapyTreatmentNoteFormViewModel();
        this._ViewModel = this.physiotherapyTreatmentNoteFormViewModel;
        this.physiotherapyTreatmentNoteFormViewModel._PhysiotherapyTreatmentNote = this._TTObject as PhysiotherapyTreatmentNote;
        this.physiotherapyTreatmentNoteFormViewModel._PhysiotherapyTreatmentNote.EntryUser = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.physiotherapyTreatmentNoteFormViewModel = this._ViewModel as PhysiotherapyTreatmentNoteFormViewModel;
        that._TTObject = this.physiotherapyTreatmentNoteFormViewModel._PhysiotherapyTreatmentNote;
        if (this.physiotherapyTreatmentNoteFormViewModel == null)
            this.physiotherapyTreatmentNoteFormViewModel = new PhysiotherapyTreatmentNoteFormViewModel();
        if (this.physiotherapyTreatmentNoteFormViewModel._PhysiotherapyTreatmentNote == null)
            this.physiotherapyTreatmentNoteFormViewModel._PhysiotherapyTreatmentNote = new PhysiotherapyTreatmentNote();
        let entryUserObjectID = that.physiotherapyTreatmentNoteFormViewModel._PhysiotherapyTreatmentNote["EntryUser"];
        if (entryUserObjectID != null && (typeof entryUserObjectID === "string")) {
            let entryUser = that.physiotherapyTreatmentNoteFormViewModel.ResUsers.find(o => o.ObjectID.toString() === entryUserObjectID.toString());
            if (entryUser) {
                that.physiotherapyTreatmentNoteFormViewModel._PhysiotherapyTreatmentNote.EntryUser = entryUser;
            }
        }

    }


    async ngOnInit() {
        await this.load();
    }

    public onDescriptionChanged(event): void {
        if (this._PhysiotherapyTreatmentNote != null && this._PhysiotherapyTreatmentNote.Description != event) {
            this._PhysiotherapyTreatmentNote.Description = event;
        }
    }

    public onEntryDateChanged(event): void {
        if (this._PhysiotherapyTreatmentNote != null && this._PhysiotherapyTreatmentNote.EntryDate != event) {
            this._PhysiotherapyTreatmentNote.EntryDate = event;
        }
    }

    public onEntryUserChanged(event): void {
        if (this._PhysiotherapyTreatmentNote != null && this._PhysiotherapyTreatmentNote.EntryUser != event) {
            this._PhysiotherapyTreatmentNote.EntryUser = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.Description, "Rtf", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelEntryUser = new TTVisual.TTLabel();
        this.labelEntryUser.Text = "Giriş Yapan Kişi";
        this.labelEntryUser.Name = "labelEntryUser";
        this.labelEntryUser.TabIndex = 7;

        this.EntryUser = new TTVisual.TTObjectListBox();
        this.EntryUser.ListDefName = "ResUserDefinitionList";
        this.EntryUser.Name = "EntryUser";
        this.EntryUser.TabIndex = 6;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 3;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 2;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = "Açıklama";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 1;

        this.Description = new TTVisual.TTRichTextBoxControl();
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.Controls = [this.labelEntryUser, this.EntryUser, this.labelEntryDate, this.EntryDate, this.labelDescription, this.Description];

    }


}
