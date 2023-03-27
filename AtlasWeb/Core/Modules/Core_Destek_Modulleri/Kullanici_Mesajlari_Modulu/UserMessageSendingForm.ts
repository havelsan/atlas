//$45E4008F
import { Component, OnInit, EventEmitter } from '@angular/core';
import { UserMessageReadingFormViewModel } from "./UserMessageReadingFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { UserMessage } from 'NebulaClient/Model/AtlasClientModel';
import { UserMessageAttachment } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";

import { AtlasWebSocketContainer, AtlasSourceType } from 'Fw/Models/AtlasWebSocketContainer';

import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AtlasSignalRService } from 'Fw/Services/AtlasSignalRService';

@Component({
    selector: 'UserMessageSendingForm',
    templateUrl: './UserMessageSendingForm.html',
    outputs: ['OnClosing'],
    providers: [MessageService]
})
export class UserMessageSendingForm extends TTVisual.TTForm implements OnInit {
    cmdSwitchToAction: TTVisual.ITTButton;

    ttbuttonSelect: TTVisual.ITTButton;
    ttbutton2: TTVisual.ITTButton;
    ttbutton3: TTVisual.ITTButton;
    ttbutton1: TTVisual.ITTButton;
    btnSend: TTVisual.ITTButton;
    btnOK: TTVisual.ITTButton;
    btnCancel: TTVisual.ITTButton;

    SelectedUser: any;
    SelectedGroups: any;
    SelectedUnits: any;

    SelectedWsUser: any;

    cmdSwitchToFolder: TTVisual.ITTButton;
    IsSystemMessage: TTVisual.ITTCheckBox;
    MessageFeedback: TTVisual.ITTCheckBox;
    IsSplashMessage: TTVisual.ITTCheckBox;

    labelMessageDate: TTVisual.ITTLabel;
    labelSubject: TTVisual.ITTLabel;
    MessageBody: TTVisual.ITTRichTextBoxControl;
    MessageDate: TTVisual.ITTDateTimePicker;
    ExpireDate: TTVisual.ITTDateTimePicker;
    SenderUser: TTVisual.ITTObjectListBox;
    Subject: TTVisual.ITTTextBox;
    ToUser: TTVisual.ITTObjectListBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ViewReportButton: TTVisual.ITTButton;
    public userMessageReadingFormViewModel: UserMessageReadingFormViewModel = new UserMessageReadingFormViewModel();
    public get _UserMessage(): UserMessage {
        return this._TTObject as UserMessage;
    }
    private UserMessageReadingForm_DocumentUrl: string = '/api/UserMessageService/UserMessageReadingForm';
    OnClosing: EventEmitter<Boolean> = new EventEmitter<any>(); /*üstteki controle parametre göndermek için*/
    constructor(private systemmessageService: AtlasSignalRService, protected httpService: NeHttpService, protected messageService: MessageService, private http: HttpClient) {
        super("USERMESSAGE", "UserMessageReadingForm");
        this._DocumentServiceUrl = this.UserMessageReadingForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.SelectedUser = new Array<string>();
        this.SelectedGroups = new Array<string>();
        this.SelectedUnits = new Array<string>();

        this.SelectedWsUser = new Array<string>();
    }


    // ***** Method declarations start *****

    private async ttbutton1_Click(): Promise<void> {
        this._UserMessage.OpenForm = true;
        this.Close();
    }

    sendWsMessageToServer() {
        if (this.systemmessageService.connectionExists) {
            const messageItem = new AtlasWebSocketContainer();
            messageItem.sourceType = AtlasSourceType.User;
            messageItem.content = this.userMessageReadingFormViewModel._UserMessage.MessageBody;
            messageItem.users = this.SelectedWsUser;
            const messageString = JSON.stringify(messageItem);
            this.systemmessageService.sendMessage(messageString);
        }
    }

    public btnSend_Click(): void {
        let apiUrlForInvoiceTerms: string = '/api/UserMessageService/SendMessageInternalWithGroupsV4';
        let params: SendMessageInternalWithGroupsV4_Input = new SendMessageInternalWithGroupsV4_Input();
        params.pBody = this.userMessageReadingFormViewModel._UserMessage.MessageBody;
        params.subject = this.userMessageReadingFormViewModel._UserMessage.Subject;
        params.toUsers = this.SelectedUser;
        for (let i = 0; i < this.SelectedUser.length; i++) {
            this.SelectedWsUser.push(this.SelectedUser[i]);
        }
        this.SendWsMessage();
        params.expireDate = this.userMessageReadingFormViewModel._UserMessage.ExpireDate;
        params.isSplashMessage = this.userMessageReadingFormViewModel._UserMessage.IsSplashMessage;
        params.isSystemMessage = this.userMessageReadingFormViewModel._UserMessage.IsSystemMessage;
        params.messageFeedback = this.userMessageReadingFormViewModel._UserMessage.MessageFeedback;
        params.userMessageGroups = this.SelectedGroups;
        this.httpService.post<void>(apiUrlForInvoiceTerms, params).then(
            x => {
                this.sendBinaryData(x);
            });

        this.OnClosing.emit(true); //üst controle erişmek için
        this.SelectedUser = new Array<string>();
        this.SelectedGroups = new Array<string>();
        this.SelectedUnits = new Array<string>();



    }

    async SendWsMessage() {
        if (this.SelectedGroups != null) {
            let that = this;
            let apiUrlForInvoiceTerms: string = '/api/UserMessageService/GetUserMessageGroupsUser';
            let param: GetUserMessageGroupsUser_Input = new GetUserMessageGroupsUser_Input();
            param.Groups = this.SelectedGroups;
            this.httpService.post<void>(apiUrlForInvoiceTerms, param).then(
                x => {
                    let a: any = x;
                    for (let i = 0; i < a.length; i++) {
                        this.SelectedWsUser.push(a[i]);
                    }
                    this.sendWsMessageToServer();
                    this.SelectedWsUser = new Array<string>();
                    this.userMessageReadingFormViewModel._UserMessage.Subject = "";
                    this.userMessageReadingFormViewModel._UserMessage.MessageBody = "";

                });
        } else {
            this.sendWsMessageToServer();
            this.SelectedWsUser = new Array<string>();
            this.userMessageReadingFormViewModel._UserMessage.Subject = "";
            this.userMessageReadingFormViewModel._UserMessage.MessageBody = "";

        }

    }



    public async btnOK_Click(): Promise<void> {
        let apiUrlForInvoiceTerms: string = '/api/UserMessageService/OnOKClickInternal';
        let params: SendMessageInternalWithGroupsV4_Input = new SendMessageInternalWithGroupsV4_Input();
        params.pBody = this.userMessageReadingFormViewModel._UserMessage.MessageBody;
        params.subject = this.userMessageReadingFormViewModel._UserMessage.Subject;
        params.toUsers = this.SelectedUser;
        params.expireDate = this.userMessageReadingFormViewModel._UserMessage.ExpireDate;
        params.isSplashMessage = this.userMessageReadingFormViewModel._UserMessage.IsSplashMessage;
        params.isSystemMessage = this.userMessageReadingFormViewModel._UserMessage.IsSystemMessage;
        params.messageFeedback = this.userMessageReadingFormViewModel._UserMessage.MessageFeedback;
        params.userMessageGroups = this.SelectedGroups;
        this.httpService.post<void>(apiUrlForInvoiceTerms, params).then(
            x => {
                this.sendBinaryData(x);
            });
        this.OnClosing.emit(true); //üst controle erişmek için
        this.SelectedUser = new Array<string>();
        this.SelectedGroups = new Array<string>();
        this.SelectedUnits = new Array<string>();
        this.userMessageReadingFormViewModel._UserMessage.Subject = "";
        this.userMessageReadingFormViewModel._UserMessage.MessageBody = "";
        this.SelectedWsUser = new Array<string>();


    }



    public async btnCancel_Click(): Promise<void> {
        this._UserMessage.OpenForm = true;
        this.Close();
        this.OnClosing.emit(true); //üst controle erişmek için
        this.SelectedUser = new Array<string>();
        this.SelectedGroups = new Array<string>();
        this.SelectedUnits = new Array<string>();
        this.userMessageReadingFormViewModel._UserMessage.Subject = "";
        this.userMessageReadingFormViewModel._UserMessage.MessageBody = "";
        this.SelectedWsUser = new Array<string>();

    }


    private async cmdSwitchToAction_Click(): Promise<void> {
        this._UserMessage.OpenForm = true;
        this.Close();
    }
    private async cmdSwitchToFolder_Click(): Promise<void> {
        this._UserMessage.OpenForm = true;
        this.Close();
    }
    private async ViewReportButton_Click(): Promise<void> {
        if ((this._UserMessage.ReportDefID !== undefined)) {
            //let reportDef: TTReportDef = TTObjectDefManager.Instance.ReportDefs[this._UserMessage.ReportDefID.Value];
            //Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

            //TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
            //cache.Add("VALUE", _OutputSendingDocument.ObjectID.ToString());

            //parameters.Add("TTOBJECTID", cache);
            //TTReportTool.TTReport.PrintReport(this, reportDef, true, 1, new Dictionary<string, TTReportTool.PropertyCache<Object>>());
        }
    }
    protected async ClientSidePreScript() {
        if ((this._UserMessage.ReportDefID !== undefined))

            this.ViewReportButton.Visible = true;
        else this.ViewReportButton.Visible = false;
        if (this._UserMessage.BaseAction !== null)
            this.cmdSwitchToAction.Visible = true;
        else {
            if (this._UserMessage.Patient !== null)
                this.cmdSwitchToFolder.Visible = true;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new UserMessage();
        this.userMessageReadingFormViewModel = new UserMessageReadingFormViewModel();
        this._ViewModel = this.userMessageReadingFormViewModel;
        this.userMessageReadingFormViewModel._UserMessage.Attachments = new Array<UserMessageAttachment>();
        this.userMessageReadingFormViewModel._UserMessage = this._TTObject as UserMessage;
        this.userMessageReadingFormViewModel._UserMessage.Sender = new ResUser();
        this.userMessageReadingFormViewModel._UserMessage.ToUser = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.userMessageReadingFormViewModel = this._ViewModel as UserMessageReadingFormViewModel;
        that._TTObject = this.userMessageReadingFormViewModel._UserMessage;
        if (this.userMessageReadingFormViewModel == null)
            this.userMessageReadingFormViewModel = new UserMessageReadingFormViewModel();
        if (this.userMessageReadingFormViewModel._UserMessage == null)
            this.userMessageReadingFormViewModel._UserMessage = new UserMessage();
        if (this.userMessageReadingFormViewModel.UserMessageAttachments == null) {
            this.userMessageReadingFormViewModel.UserMessageAttachments = new Array<UserMessageAttachment>();
        }
        let senderObjectID = that.userMessageReadingFormViewModel._UserMessage["Sender"];
        if (senderObjectID != null && (typeof senderObjectID === 'string')) {
            let sender = that.userMessageReadingFormViewModel.ResUsers.find(o => o.ObjectID.toString() === senderObjectID.toString());
             if (sender) {
                that.userMessageReadingFormViewModel._UserMessage.Sender = sender;
            }
        }
        let toUserObjectID = that.userMessageReadingFormViewModel._UserMessage["ToUser"];
        if (toUserObjectID != null && (typeof toUserObjectID === 'string')) {
            let toUser = that.userMessageReadingFormViewModel.ResUsers.find(o => o.ObjectID.toString() === toUserObjectID.toString());
             if (toUser) {
                that.userMessageReadingFormViewModel._UserMessage.ToUser = toUser;
            }
        }
    }

    private base64textString: String = "";
    attachments: Array<UserMessageAttachment> = new Array<UserMessageAttachment>();
    fileName: string;
    fileNames: Array<string> = new Array<string>();
    totalSize: number = 0;

    handleFileSelect(evt) {
        let fileSize: number;
        let files = evt.target.files;
        let file = files[0];
        this.sizeSum(file.size);
        if (this.totalSize > 10000000) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13544", "Eklediğiniz dosyaların boyutu 10 Mb'dan fazla olamaz!"), MessageIconEnum.WarningMessage);
            return;
        }

        if (files && file) {
            let reader = new FileReader();

            reader.onload = this._handleReaderLoaded.bind(this);
            this.fileName = file.name;
            reader.readAsArrayBuffer(file);
        }


    }

    sizeSum(size: number) {
        this.totalSize += size;
    }

    deleteAttachment(data) {
        for (let i = 0; i < this.userMessageReadingFormViewModel.UserMessageAttachments.length; i++) {
            if (this.userMessageReadingFormViewModel.UserMessageAttachments[i].Name == data.Name) {
                this.userMessageReadingFormViewModel.UserMessageAttachments.splice(i, 1);
            }
        }
    }

    _handleReaderLoaded(readerEvt) {
        //var binaryString = readerEvt.target.result;
        //this.base64textString = btoa(binaryString);
        let param: UserMessageAttachment = new UserMessageAttachment();
        param.Name = this.fileName;
        param.Attachment = readerEvt.target.result;
        this.userMessageReadingFormViewModel.UserMessageAttachments.push(param);
    }

    //param: UserMessageAttachment = new UserMessageAttachment();

    //onChange($event) {

    //    let that = this;
    //    const file: File = $event.target.files[0];
    //    const fileReader: FileReader = new FileReader();
    //    const fileType = $event.target.parentElement.id;
    //    fileReader.onloadend = (e) => {

    //        that.param.Name = file.name,
    //        that.param.Attachment = fileReader.result;
    //        this.userMessageReadingFormViewModel.UserMessageAttachments.push(that.param);
    //    }

    //    fileReader.readAsArrayBuffer(file);

    //}

    sendBinaryData(messageID) {

        for (let att of this.userMessageReadingFormViewModel.UserMessageAttachments) {
            let token = sessionStorage.getItem('token');
            const headers = new HttpHeaders()
                .append('Authorization', `Bearer ${token}`);

            let blb: any = att.Attachment;
            const blob = new Blob([new Uint8Array(blb)], { type: 'application/octet-binary' });
            const formData = new FormData();

            formData.append('UserMessageObjectID', messageID.toString());
            formData.append('Attachments', blob);
            formData.append('FileName', att.Name);


            this.http.post('/api/UserMessageService/SendUserMessageAttachment', formData, { headers: headers }).toPromise().then(r => {
                console.log('Success');
            }).catch(error => {
                console.log(error);
            });
        }
    }



    async ngOnInit() {
       // this.systemmessageService.startConnection();
        await this.load();
    }

    public onIsSystemMessageChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.IsSystemMessage != event) {
                this._UserMessage.IsSystemMessage = event;
            }
        }
    }

    public onMessageFeedbackChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.MessageFeedback != event) {
                this._UserMessage.MessageFeedback = event;
            }
        }
    }

    public onIsSplashMessageChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.IsSplashMessage != event) {
                this._UserMessage.IsSplashMessage = event;
            }
        }
    }

    public onMessageBodyChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.MessageBody != event) {
                this._UserMessage.MessageBody = event;
            }
        }
    }

    public onMessageDateChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.MessageDate != event) {
                this._UserMessage.MessageDate = event;
            }
        }
    }

    public onExpireDateChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.ExpireDate != event) {
                this._UserMessage.ExpireDate = event;
            }
        }
    }

    public onSenderUserChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.Sender != event) {
                this._UserMessage.Sender = event;
            }
        }
    }

    public onSubjectChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.Subject != event) {
                this._UserMessage.Subject = event;
            }
        }
    }

    public onToUserChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.ToUser != event) {
                this._UserMessage.ToUser = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.MessageDate, "Value", this.__ttObject, "MessageDate");
        redirectProperty(this.ExpireDate, "Value", this.__ttObject, "ExpireDate");
        redirectProperty(this.IsSystemMessage, "Value", this.__ttObject, "IsSystemMessage");
        redirectProperty(this.MessageFeedback, "Value", this.__ttObject, "MessageFeedback");
        redirectProperty(this.IsSplashMessage, "Value", this.__ttObject, "IsSplashMessage");
        redirectProperty(this.Subject, "Text", this.__ttObject, "Subject");
        redirectProperty(this.MessageBody, "Rtf", this.__ttObject, "MessageBody");
    }

    public initFormControls(): void {
        this.cmdSwitchToAction = new TTVisual.TTButton();
        this.cmdSwitchToAction.Text = i18n("M16910", "İşleme Geç");
        this.cmdSwitchToAction.Name = "cmdSwitchToAction";
        this.cmdSwitchToAction.TabIndex = 15;
        this.cmdSwitchToAction.Visible = false;

        this.ttbuttonSelect = new TTVisual.TTButton();
        this.ttbuttonSelect.Text = i18n("M20335", "Personel Seç");
        this.ttbuttonSelect.Name = "ttbuttonSelect";
        this.ttbuttonSelect.TabIndex = 15;
        this.ttbuttonSelect.Visible = true;

        this.ttbutton2 = new TTVisual.TTButton();
        this.ttbutton2.Text = i18n("M14985", "Grup Seç");
        this.ttbutton2.Name = "ttbutton2";
        this.ttbutton2.TabIndex = 15;
        this.ttbutton2.Visible = true;

        this.ttbutton3 = new TTVisual.TTButton();
        this.ttbutton3.Text = i18n("M12037", "Bölüm Seç");
        this.ttbutton3.Name = "ttbutton3";
        this.ttbutton3.TabIndex = 15;
        this.ttbutton3.Visible = true;

        this.ttbutton1 = new TTVisual.TTButton();
        this.ttbutton1.Text = "Sil";
        this.ttbutton1.Name = "ttbutton1";
        this.ttbutton1.TabIndex = 15;
        this.ttbutton1.Visible = true;

        this.btnSend = new TTVisual.TTButton();
        this.btnSend.Text = i18n("M14849", "Gönder");
        this.btnSend.Name = "btnSend";
        this.btnSend.TabIndex = 15;
        this.btnSend.Visible = true;

        this.btnOK = new TTVisual.TTButton();
        this.btnOK.Text = i18n("M17386", "Kaydet");
        this.btnOK.Name = "btnOK";
        this.btnOK.TabIndex = 15;
        this.btnOK.Visible = true;


        this.btnCancel = new TTVisual.TTButton();
        this.btnCancel.Text = i18n("M24054", "Vazgeç");
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.TabIndex = 15;
        this.btnCancel.Visible = true;

        this.cmdSwitchToFolder = new TTVisual.TTButton();
        this.cmdSwitchToFolder.Text = i18n("M13282", "Dosyasına Git");
        this.cmdSwitchToFolder.Name = "cmdSwitchToFolder";
        this.cmdSwitchToFolder.TabIndex = 14;
        this.cmdSwitchToFolder.Visible = false;

        this.ViewReportButton = new TTVisual.TTButton();
        this.ViewReportButton.Text = i18n("M20893", "Raporu Görüntüle");
        this.ViewReportButton.Name = "ViewReportButton";
        this.ViewReportButton.TabIndex = 13;

        this.SenderUser = new TTVisual.TTObjectListBox();
        this.SenderUser.ListDefName = "ResUserListDefinition";
        this.SenderUser.Name = "SenderUser";
        this.SenderUser.TabIndex = 3;

        this.MessageBody = new TTVisual.TTRichTextBoxControl();
        this.MessageBody.DisplayText = "Mesaj";
        this.MessageBody.BackColor = "#DCDCDC";
        this.MessageBody.Name = "MessageBody";
        this.MessageBody.TabIndex = 12;

        this.labelSubject = new TTVisual.TTLabel();
        this.labelSubject.Text = i18n("M11646", "Başlık");
        this.labelSubject.BackColor = "#DCDCDC";
        this.labelSubject.ForeColor = "#000000";
        this.labelSubject.Name = "labelSubject";
        this.labelSubject.TabIndex = 7;

        this.Subject = new TTVisual.TTTextBox();
        this.Subject.Name = "Subject";
        this.Subject.TabIndex = 2;

        this.labelMessageDate = new TTVisual.TTLabel();
        this.labelMessageDate.Text = i18n("M18923", "Mesaj Tarihi");
        this.labelMessageDate.BackColor = "#DCDCDC";
        this.labelMessageDate.ForeColor = "#000000";
        this.labelMessageDate.Name = "labelMessageDate";
        this.labelMessageDate.TabIndex = 3;

        this.MessageDate = new TTVisual.TTDateTimePicker();
        this.MessageDate.CustomFormat = "dd.MM.yyyy HH:mm:ss";
        this.MessageDate.Format = DateTimePickerFormat.Custom;
        this.MessageDate.Name = "MessageDate";
        this.MessageDate.TabIndex = 0;

        this.ExpireDate = new TTVisual.TTDateTimePicker();
        this.ExpireDate.CustomFormat = "dd.MM.yyyy HH:mm:ss";
        this.ExpireDate.Format = DateTimePickerFormat.Custom;
        this.ExpireDate.Name = "ExpireDate";
        this.ExpireDate.TabIndex = 0;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M14850", "Gönderen");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 7;

        this.IsSystemMessage = new TTVisual.TTCheckBox();
        this.IsSystemMessage.Value = false;
        this.IsSystemMessage.Text = i18n("M21915", "Sistem Mesajı");
        this.IsSystemMessage.Title = i18n("M21915", "Sistem Mesajı");
        this.IsSystemMessage.Name = "IsSystemMessage";
        this.IsSystemMessage.TabIndex = 1;

        this.MessageFeedback = new TTVisual.TTCheckBox();
        this.MessageFeedback.Value = false;
        this.MessageFeedback.Text = i18n("M14836", "Okundu Bilgisi");
        this.MessageFeedback.Title = i18n("M14836", "Okundu Bilgisi");
        this.MessageFeedback.Name = "MessageFeedback";
        this.MessageFeedback.TabIndex = 1;

        this.IsSplashMessage = new TTVisual.TTCheckBox();
        this.IsSplashMessage.Value = false;
        this.IsSplashMessage.Text = i18n("M10495", "Açılış Mesajı");
        this.IsSplashMessage.Title = i18n("M10495", "Açılış Mesajı");
        this.IsSplashMessage.Name = "IsSplashMessage";
        this.IsSplashMessage.TabIndex = 1;

        this.ToUser = new TTVisual.TTObjectListBox();
        this.ToUser.ListDefName = "ResUserListDefinition";
        this.ToUser.Name = "ToUser";
        this.ToUser.TabIndex = 4;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M14885", "Gönderilen");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 7;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Personel";
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 7;

        this.Controls = [this.cmdSwitchToAction, this.btnCancel, this.ttbuttonSelect, this.ttbutton2, this.ttbutton3, this.ttbutton1, this.btnSend, this.btnOK, this.cmdSwitchToFolder, this.ViewReportButton, this.SenderUser, this.MessageBody, this.labelSubject, this.Subject, this.labelMessageDate, this.MessageDate, this.ExpireDate, this.ttlabel1, this.IsSystemMessage, this.MessageFeedback, this.IsSplashMessage, this.ToUser, this.ttlabel2, this.ttlabel3];

    }


}
export class SendMessageInternal_Input {
    public toUsers: Array<string>;
    public subject: string;
    public pBody: Object;
}

export class SendMessageInternalWithGroupsV4_Input {
    public toUsers: Array<string>;
    public userMessageGroups: Array<string>;
    public subject: string;
    public pBody: Object;
    public isSystemMessage: boolean;
    public messageFeedback: boolean;
    public patient: Patient;
    public isSplashMessage: boolean;
    public expireDate: Date;

}
export class GetUserMessageGroupsUser_Input {
    public Groups: Array<string>;
}
