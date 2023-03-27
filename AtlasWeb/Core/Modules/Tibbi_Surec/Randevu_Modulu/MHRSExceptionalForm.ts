//$00EDC79D

import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { NgForm } from "@angular/forms";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { MHRSExceptionalFormViewModel } from './MHRSExceptionalFormViewModel';
import { Schedule, PhoneTypeEnum, FormField } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AutoCompleteMode } from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';
import { Observable } from "rxjs";



@Component({
    selector: 'MHRSExceptionalForm',
    templateUrl: './MHRSExceptionalForm.html',
    inputs: ['Model'],
    providers: [SystemApiService]
})
export class MHRSExceptionalForm extends TTVisual.TTForm implements OnInit, IModal {

    Email: TTVisual.ITTTextBox;
    PhoneNumber: TTVisual.ITTMaskedTextBox;
    PhoneType: TTVisual.ITTEnumComboBox;
    Description: TTVisual.ITTTextBox;
    ActionType: TTVisual.ITTObjectListBox;
    DocumentPath: TTVisual.ITTTextBox;
    public uploadHeaders: any;
    public uploadAcceptTypes: any;
    public value: any[] = [];
    public messageForm: FormGroup;
    public visibleFormLoad: boolean = true;

    @ViewChild('form') formInstance: NgForm;
    scheduleObjectID: Guid;

    public mHRSExceptionalFormViewModel: MHRSExceptionalFormViewModel = new MHRSExceptionalFormViewModel();
    public get _Schedule(): Schedule {
        return this._TTObject as Schedule;
    }
    private MHRSExceptionalForm_DocumentUrl: string = '/api/MHRSExceptionalService/MHRSExceptionalForm';
    public autoCompleteMode: AutoCompleteMode = AutoCompleteMode.List;
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private formBuilder: FormBuilder,
        private http2: HttpClient,
        protected ngZone: NgZone) {
        super("", "MHRSExceptionalForm");
        this._DocumentServiceUrl = this.MHRSExceptionalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public setInputParam(value: any) {

        this.scheduleObjectID = value.objectID;
        this.mHRSExceptionalFormViewModel.schedule = this.scheduleObjectID;

    }
    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    async ngOnInit() {
        let that = this;
        this.messageForm = this.formBuilder.group({
            schedule: ['', Validators.required],
            email: ['', Validators.required],
            phoneNumber: ['', Validators.required],
            phoneType: ['', Validators.required],
            description: ['', Validators.required],
            actionTypeObjectId: ['', Validators.required],
            attachment: ['', Validators.required]
        });
        // this.messageForm.controls.attachment = new FormControl();
        // this.messageForm.controls.attachment.value = new FormField();

        await this.load(MHRSExceptionalFormViewModel);
        let token = sessionStorage.getItem('token');
        this.uploadHeaders = { Authorization: `Bearer ${token}` };
        this.uploadAcceptTypes = "application/pdf,image/jpg,image/jpeg,image/png";

    }

    public initViewModel(): void {
        this.mHRSExceptionalFormViewModel = new MHRSExceptionalFormViewModel();
        this._ViewModel = this.mHRSExceptionalFormViewModel;
    }
    protected loadViewModel() {
        let that = this;
        this.mHRSExceptionalFormViewModel.PhoneType = PhoneTypeEnum.GSM;
    }

    public async onEmailChanged(event) {
        if (event != null) {
            if (this.mHRSExceptionalFormViewModel != null && this.mHRSExceptionalFormViewModel.Email != event) {
                this.mHRSExceptionalFormViewModel.Email = event;
            }
        }
    }

    public async onActionTypeChanged(event) {
        if (event != null) {
            if (this.mHRSExceptionalFormViewModel != null && this.mHRSExceptionalFormViewModel.ActionType != event) {
                this.mHRSExceptionalFormViewModel.ActionType = event;
            }
        }
        if (this.mHRSExceptionalFormViewModel.ActionType != null) {
            this.mHRSExceptionalFormViewModel.actionTypeObjectId = this.mHRSExceptionalFormViewModel.ActionType.ObjectID;
            if (this.mHRSExceptionalFormViewModel.ActionType.IsDocumentRequired)
                this.visibleFormLoad = true;
            else
                this.visibleFormLoad = false;

        }
    }
    public async onDocumentPathChanged(event) {
        if (event != null) {
            if (this.mHRSExceptionalFormViewModel != null && this.mHRSExceptionalFormViewModel.DocumentPath != event) {
                this.mHRSExceptionalFormViewModel.DocumentPath = event;
            }
        }
    }
    public async onPhoneNumberChanged(event) {
        if (event != null) {
            if (this.mHRSExceptionalFormViewModel != null && this.mHRSExceptionalFormViewModel.PhoneNumber != event) {
                this.mHRSExceptionalFormViewModel.PhoneNumber = event;
            }
        }
    }
    public async onPhoneTypeChanged(event) {
        if (event != null) {
            if (this.mHRSExceptionalFormViewModel != null && this.mHRSExceptionalFormViewModel.PhoneType != event) {
                this.mHRSExceptionalFormViewModel.PhoneType = event;
            }
        }
    }
    public async onDescriptionChanged(event) {
        if (event != null) {
            if (this.mHRSExceptionalFormViewModel != null && this.mHRSExceptionalFormViewModel.Description != event) {
                this.mHRSExceptionalFormViewModel.Description = event;
            }
        }
    }

    public sendMessage(newMessage) {
        let sendMessagePath = '/api/MHRSExceptionalService/Upload';
        if (this.mHRSExceptionalFormViewModel.Email == null) {
            ServiceLocator.MessageService.showError(i18n("M13631", "E-Mail adresi girmediniz!"));
            return;
        }
        if (this.mHRSExceptionalFormViewModel.PhoneNumber == null || this.mHRSExceptionalFormViewModel.PhoneNumber.length != 12) {
            ServiceLocator.MessageService.showError(i18n("M23140", "Telefon numarasını 12 hane olarak giriniz!"));
            return;
        }
        if (this.mHRSExceptionalFormViewModel.PhoneType == null) {
            ServiceLocator.MessageService.showError(i18n("M23143", "Telefon tipi seçmediniz!"));
            return;
        }
        if (this.mHRSExceptionalFormViewModel.Description == null) {
            ServiceLocator.MessageService.showError(i18n("M10477", "Açıklama girmediniz!"));
            return;
        }
        if (this.mHRSExceptionalFormViewModel.ActionType == null) {
            ServiceLocator.MessageService.showError(i18n("M10642", "Aksiyon Tipi seçmelisiniz!"));
            return;
        }

        this.messageForm.value.phoneType = this.mHRSExceptionalFormViewModel.PhoneType;
        this.messageForm.value.description = this.mHRSExceptionalFormViewModel.Description;
        this.messageForm.value.phoneNumber = this.mHRSExceptionalFormViewModel.PhoneNumber;
        this.messageForm.value.actionTypeObjectId = this.mHRSExceptionalFormViewModel.actionTypeObjectId;
        this.messageForm.value.email = this.mHRSExceptionalFormViewModel.Email;
        this.messageForm.value.schedule = this.mHRSExceptionalFormViewModel.schedule;
        // this.messageForm.value.attachment = this.mHRSExceptionalFormViewModel.Attachment;
        let data = new FormData();
        let frm: any = this.messageForm;
        if (this.mHRSExceptionalFormViewModel.ActionType.IsDocumentRequired && frm.controls.attachment.value == null) {
            ServiceLocator.MessageService.showError(i18n("M21572", "Seçtiğiniz Aksiyon Tipi için Belge Zorunludur. Lütfen Belge Yükleyiniz!"));
            return;
        }
        if (frm.controls.attachment.value != null)
            data.append('file', frm.controls.attachment.value[0]);
        data.append('schedule', this.messageForm.value.schedule);
        data.append('email', this.messageForm.value.email);
        data.append('phoneNumber', this.messageForm.value.phoneNumber);
        data.append('phoneType', this.messageForm.value.phoneType);
        data.append('description', this.messageForm.value.description);
        data.append('actionTypeObjectId', this.messageForm.value.actionTypeObjectId);
        // const options = new RequestOptions();
        const headers = this.getHeaders();
        //const http3 = ServiceLocator.Injector.get(Http);
        //return this.http2.post(sendmessagepath, data, { headers: headers })
        //    .map((res: response) => {
        //        console.log(res);
        //    })
        //    .catch(this.handleerror);

        return this.http2.post(sendMessagePath, data, { headers: headers }).toPromise().then(r => {
            if (r != null && r["Result"] != null && r["Result"] == true) {
                ServiceLocator.MessageService.showSuccess(i18n("M16733", "İstisna talebi MHRS'ye bildirilmiştir."));
            }
            else {
                let m ="";
                if (r["Message"] != null && r["Message"] != "") {
                   m = r["Message"];
                }

                 ServiceLocator.MessageService.showReponseError("MHRS'ye bildirilirken bir hata oluştu!\n" + m);
            }
        }).catch(error => {
            console.log(error);
        });
    }
    private handleError(error: any) {
        let errorMsg = error.message || ` Problem in Messages retrieving`;
        console.error(errorMsg);
        return Observable.throw(errorMsg);
    }

    private getHeaders() {
        let token = sessionStorage.getItem('token');
        const headers = new HttpHeaders()
            .append('Authorization', `Bearer ${token}`);

        //let token = sessionStorage.getItem('token');
        //let headers = new HttpHeaders();
        //headers.set('Authorization', `Bearer ${token}`);
        return headers;
    }


    send() {
        console.info(this.messageForm);
        let messageForm: any = {
            schedule: this.messageForm.value.schedule,
            email: this.messageForm.value.email,
            phoneNumber: this.messageForm.value.phoneNumber,
            phoneType: this.messageForm.value.phoneType,
            description: this.messageForm.value.description,
            actionTypeObjectId: this.messageForm.value.actionTypeObjectId,
            attachment: this.messageForm.value.attachment
        };
        this.sendMessage(messageForm);
        //.subscribe(response => {
        //    if (response) {
        //        console.log(response);
        //    }
        //});
    }


    //private async btnSentToMHRS_Click(): Promise<void> {
    //    if (this.mHRSExceptionalFormViewModel.Email == null) {
    //        ServiceLocator.MessageService.showError("E-Mail adresi girmediniz!");
    //    }
    //    if (this.mHRSExceptionalFormViewModel.PhoneNumber == null || this.mHRSExceptionalFormViewModel.PhoneNumber.length != 12) {
    //        ServiceLocator.MessageService.showError("Telefon numarasını 12 hane olarak giriniz!");
    //    }
    //    if (this.mHRSExceptionalFormViewModel.PhoneType == null) {
    //        ServiceLocator.MessageService.showError("Telefon tipi seçmediniz!");
    //    }
    //    if (this.mHRSExceptionalFormViewModel.Description == null) {
    //        ServiceLocator.MessageService.showError("Açıklama girmediniz!");
    //    }
    //    if (this.mHRSExceptionalFormViewModel.ActionType == null) {
    //        ServiceLocator.MessageService.showError("Aksiyon Tipi seçmelisiniz!");
    //    }

    //    let result = <boolean>await this.httpService.post('/api/MHRSExceptionalService/SentToMHRS', this.mHRSExceptionalFormViewModel);
    //    if (result == true) {
    //        TTVisual.InfoBox.Show('İstisna Bildirimi Yapıldı', MessageIconEnum.InformationMessage);
    //    }
    //}

    sendForm() {
        this.formInstance.onSubmit(null);
    }

    public initFormControls(): void {
        this.Email = new TTVisual.TTTextBox();
        this.Email.Multiline = false;
        this.Email.Name = "Email";
        this.Email.TabIndex = 1;

        this.PhoneNumber = new TTVisual.TTMaskedTextBox();
        this.PhoneNumber.Name = "PhoneNumber";
        this.PhoneNumber.Mask = "(999)9999999";
        this.PhoneNumber.TabIndex = 2;

        this.PhoneType = new TTVisual.TTEnumComboBox();
        this.PhoneType.DataTypeName = "MHRSActionTypeDefinition";
        this.PhoneType.Required = true;
        this.PhoneType.BackColor = "#FFE3C6";
        this.PhoneType.Name = "PhoneType";
        this.PhoneType.TabIndex = 3;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 4;
        this.Description.Height = "60";

        this.ActionType = new TTVisual.TTObjectListBox();
        this.ActionType.Enabled = true;
        this.ActionType.ListDefName = "MHRSActionTypeDefinitionListDef";
        this.ActionType.Name = "ActionType";
        this.ActionType.TabIndex = 5;
        this.ActionType.ListFilterExpression = "ISISTISNATYPE=1";

        this.DocumentPath = new TTVisual.TTTextBox();
        this.DocumentPath.Multiline = false;
        this.DocumentPath.Name = "DocumentPath";
        this.DocumentPath.TabIndex = 6;
        this.Controls = [this.Email, this.PhoneNumber, this.PhoneType, this.Description, this.ActionType, this.DocumentPath];

    }
}