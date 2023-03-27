//$93002847
import { Component, OnInit, NgZone } from '@angular/core';
import { SendMessageToPatientFormViewModel } from './SendMessageToPatientFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SendMessageToPatient } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSHastaMesajlari } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';

@Component({
    selector: 'SendMessageToPatientForm',
    templateUrl: './SendMessageToPatientForm.html',
    providers: [MessageService]
})
export class SendMessageToPatientForm extends TTVisual.TTForm implements OnInit, IModal {
    labelMessageDate: TTVisual.ITTLabel;
    labelMessageInfo: TTVisual.ITTLabel;
    labelSKRSHastaMesajlari: TTVisual.ITTLabel;
    MessageDate: TTVisual.ITTDateTimePicker;
    MessageInfo: TTVisual.ITTTextBox;
    SKRSHastaMesajlari: TTVisual.ITTObjectListBox;

    public sendMessageToPatientFormViewModel: SendMessageToPatientFormViewModel = new SendMessageToPatientFormViewModel();
    public get _SendMessageToPatient(): SendMessageToPatient {
        return this._TTObject as SendMessageToPatient;
    }
    private SendMessageToPatientForm_DocumentUrl: string = '/api/SendMessageToPatientService/SendMessageToPatientForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('SENDMESSAGETOPATIENT', 'SendMessageToPatientForm');
        this._DocumentServiceUrl = this.SendMessageToPatientForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SendMessageToPatient();
        this.sendMessageToPatientFormViewModel = new SendMessageToPatientFormViewModel();
        this._ViewModel = this.sendMessageToPatientFormViewModel;
        this.sendMessageToPatientFormViewModel._SendMessageToPatient = this._TTObject as SendMessageToPatient;
        this.sendMessageToPatientFormViewModel._SendMessageToPatient.SKRSHastaMesajlari = new SKRSHastaMesajlari();
    }

    protected loadViewModel() {
        let that = this;

        that.sendMessageToPatientFormViewModel = this._ViewModel as SendMessageToPatientFormViewModel;
        that._TTObject = this.sendMessageToPatientFormViewModel._SendMessageToPatient;
        if (this.sendMessageToPatientFormViewModel == null)
            this.sendMessageToPatientFormViewModel = new SendMessageToPatientFormViewModel();
        if (this.sendMessageToPatientFormViewModel._SendMessageToPatient == null)
            this.sendMessageToPatientFormViewModel._SendMessageToPatient = new SendMessageToPatient();
        let sKRSHastaMesajlariObjectID = that.sendMessageToPatientFormViewModel._SendMessageToPatient["SKRSHastaMesajlari"];
        if (sKRSHastaMesajlariObjectID != null && (typeof sKRSHastaMesajlariObjectID === 'string')) {
            let sKRSHastaMesajlari = that.sendMessageToPatientFormViewModel.SKRSHastaMesajlaris.find(o => o.ObjectID.toString() === sKRSHastaMesajlariObjectID.toString());
             if (sKRSHastaMesajlari) {
                that.sendMessageToPatientFormViewModel._SendMessageToPatient.SKRSHastaMesajlari = sKRSHastaMesajlari;
            }
        }
        that.sendMessageToPatientFormViewModel._SendMessageToPatient.SKRSHastaMesajlari = this.sendMessageToPatientFormViewModel.HastaMesajlari;

    }


    async ngOnInit()  {
        let that = this;
        await this.load(SendMessageToPatientFormViewModel);
  
    }


    public setInputParam(value: any) {

    }
    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }
    public onMessageDateChanged(event): void {
        if (event != null) {
            if (this._SendMessageToPatient != null && this._SendMessageToPatient.MessageDate != event) {
                this._SendMessageToPatient.MessageDate = event;
            }
        }
    }

    public onMessageInfoChanged(event): void {
        if (event != null) {
            if (this._SendMessageToPatient != null && this._SendMessageToPatient.MessageInfo != event) {
                this._SendMessageToPatient.MessageInfo = event;
            }
        }
    }

    public onSKRSHastaMesajlariChanged(event): void {
        if (event != null) {
            if (this._SendMessageToPatient != null && this._SendMessageToPatient.SKRSHastaMesajlari != event) {
                this._SendMessageToPatient.SKRSHastaMesajlari = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.MessageDate, "Value", this.__ttObject, "MessageDate");
        redirectProperty(this.MessageInfo, "Text", this.__ttObject, "MessageInfo");
    }

    public initFormControls(): void {
        this.labelSKRSHastaMesajlari = new TTVisual.TTLabel();
        this.labelSKRSHastaMesajlari.Text = i18n("M15273", "Hasta Mesaj Tipi");
        this.labelSKRSHastaMesajlari.Name = "labelSKRSHastaMesajlari";
        this.labelSKRSHastaMesajlari.TabIndex = 5;

        this.SKRSHastaMesajlari = new TTVisual.TTObjectListBox();
        this.SKRSHastaMesajlari.Required = true;
        this.SKRSHastaMesajlari.ListDefName = "SKRSHastaMesajlariList";
        this.SKRSHastaMesajlari.Name = "SKRSHastaMesajlari";
        this.SKRSHastaMesajlari.TabIndex = 4;

        this.labelMessageDate = new TTVisual.TTLabel();
        this.labelMessageDate.Text = i18n("M18923", "Mesaj Tarihi");
        this.labelMessageDate.Name = "labelMessageDate";
        this.labelMessageDate.TabIndex = 3;

        this.MessageDate = new TTVisual.TTDateTimePicker();
        this.MessageDate.BackColor = "#F0F0F0";
        this.MessageDate.Format = DateTimePickerFormat.Long;
        this.MessageDate.Enabled = false;
        this.MessageDate.Name = "MessageDate";
        this.MessageDate.TabIndex = 2;

        this.labelMessageInfo = new TTVisual.TTLabel();
        this.labelMessageInfo.Text = i18n("M18911", "Mesaj Detayı");
        this.labelMessageInfo.Name = "labelMessageInfo";
        this.labelMessageInfo.TabIndex = 1;

        this.MessageInfo = new TTVisual.TTTextBox();
        this.MessageInfo.Required = true;
        this.MessageInfo.Multiline = true;
        this.MessageInfo.BackColor = "#FFE3C6";
        this.MessageInfo.Name = "MessageInfo";
        this.MessageInfo.TabIndex = 0;

        this.Controls = [this.labelSKRSHastaMesajlari, this.SKRSHastaMesajlari, this.labelMessageDate, this.MessageDate, this.labelMessageInfo, this.MessageInfo];

    }

    SaveAndSendMessage(): void{
        if (!this.ConfirmAndSaveMessage())
            this.save();
    }

    ConfirmAndSaveMessage(): boolean{
        let flag: boolean = false;
        if (this.sendMessageToPatientFormViewModel._SendMessageToPatient.MessageInfo == undefined || this.sendMessageToPatientFormViewModel._SendMessageToPatient.MessageInfo == null || this.sendMessageToPatientFormViewModel._SendMessageToPatient.MessageInfo == "") {
            flag = true;
            this.messageService.showError("Lütfen Mesaj Detayını Giriniz.");
        }
        return flag;
    }

}
