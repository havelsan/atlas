//$45E4008F
import { Component, OnInit, OnDestroy, NgZone } from '@angular/core';
import { Headers, RequestOptions, ResponseContentType } from "@angular/http";
import { UserMessageReadingFormViewModel } from "./UserMessageReadingFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { UserMessage } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { UserMessageAttachment, UserMessageGroupDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { CommonHelper } from 'app/Helper/CommonHelper';

import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';

@Component({
    selector: 'UserMessageReadingForm',
    templateUrl: './UserMessageReadingForm.html',
    providers: [MessageService]
})
export class UserMessageReadingForm extends TTVisual.TTForm implements OnInit, OnDestroy {
    showPopup: boolean;
    cmdSwitchToAction: TTVisual.ITTButton;
    cmdSend: TTVisual.ITTButton;
    cmdSave: TTVisual.ITTButton;
    cmdReply: TTVisual.ITTButton;
    cmdSwitchToFolder: TTVisual.ITTButton;
    isReplyMessage: boolean = false;
    IsSystemMessage: TTVisual.ITTCheckBox;
    labelMessageDate: TTVisual.ITTLabel;
    labelSubject: TTVisual.ITTLabel;
    MessageBody: TTVisual.ITTRichTextBoxControl;
    MessageDate: TTVisual.ITTDateTimePicker;
    SenderUser: TTVisual.ITTObjectListBox;
    Subject: TTVisual.ITTTextBox;
    ToUser: TTVisual.ITTObjectListBox;
    Groups: TTVisual.ITTObjectListBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ViewReportButton: TTVisual.ITTButton;
    public ActiveUser: any;
    param: UserMessageAttachment = new UserMessageAttachment();
    deletedSavedAttachments: any = new Array<UserMessageAttachment>();

    public userMessageReadingFormViewModel: UserMessageReadingFormViewModel = new UserMessageReadingFormViewModel();
    public get _UserMessage(): UserMessage {
        return this._TTObject as UserMessage;
    }
    private UserMessageReadingForm_DocumentUrl: string = '/api/UserMessageService/UserMessageReadingForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone,
                private http: HttpClient,
                private http2: AtlasHttpService) {
        super("USERMESSAGE", "UserMessageReadingForm");
        this.showPopup = false;
        this._DocumentServiceUrl = this.UserMessageReadingForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    // ***** Method declarations start *****
    IsModified: boolean = false;
    public async cmdSwitchToAction_Click(): Promise<void> {
        if (this.IsModified) {
            this.IsModified = false;
            this.isReplyMessage = false;
            this.cmdSwitchToAction.Text = i18n("M16910", "İşleme Geç");
            this.IsModified = false;
            this.Subject.Enabled = false;
            this.MessageBody.Enabled = false;
            this.ToUser.Enabled = false;
            this.Groups.Enabled = false;
            this.MessageDate.ReadOnly = true;
            this.cmdSend.Visible = false;
            this.cmdSave.Visible = false;
            this.MessageBody.ReadOnly = true;
            this.cmdReply.Visible = false;
            this.Reload();
        }
        else {
            this.cmdSwitchToAction.Text = i18n("M24054", "Vazgeç");
            this._UserMessage.OpenForm = true;
            this.Close();
            this.IsModified = true;
            this.Subject.Enabled = true;
            this.MessageBody.Enabled = true;
            this.ToUser.Enabled = true;
            this.Groups.Enabled = true;

            this.MessageDate.ReadOnly = false;
            this.cmdSend.Visible = true;
            this.cmdSave.Visible = true;
            this.MessageBody.ReadOnly = false;
            if (this.userMessageReadingFormViewModel._UserMessage.SenderStatus != 3) {
                this.cmdReply.Visible = true;
            }
        }
    }

    Reload() {
        let apiUrl: string = '/api/UserMessageService/UserMessageReadingForm?id=' + this.userMessageReadingFormViewModel._UserMessage.ObjectID.toString();
        this.httpService.get<any>(apiUrl).then(
            x => {
                this.userMessageReadingFormViewModel._UserMessage = x._UserMessage;
                this.loadViewModel();
            }

        );
    }

    public async cmdSend_Click(): Promise<void> {
        let apiUrlForInvoiceTerms: string;
        if (this.isReplyMessage) {
            apiUrlForInvoiceTerms = '/api/UserMessageService/SendMessageInternalWithGroupsV4';
        }
        else {
            apiUrlForInvoiceTerms = '/api/UserMessageService/SendMessageInternalWithGroupsV5';
        }
        let params: SendMessageInternalWithGroupsV4_Input = new SendMessageInternalWithGroupsV4_Input();
        params.pBody = this.userMessageReadingFormViewModel._UserMessage.MessageBody;
        params.subject = this.userMessageReadingFormViewModel._UserMessage.Subject;
        let userss: Array<string> = new Array<string>();
        userss.push(this.userMessageReadingFormViewModel._UserMessage.ToUser.ObjectID.toString());
        params.toUsers = userss;
        params.ObjectID = this.userMessageReadingFormViewModel._UserMessage.ObjectID;
        params.expireDate = this.userMessageReadingFormViewModel._UserMessage.ExpireDate;
        params.isSplashMessage = this.userMessageReadingFormViewModel._UserMessage.IsSplashMessage;
        params.isSystemMessage = this.userMessageReadingFormViewModel._UserMessage.IsSystemMessage;
        params.messageFeedback = this.userMessageReadingFormViewModel._UserMessage.MessageFeedback;

        let groups: Array<string> = new Array<string>();
        if (this.userMessageReadingFormViewModel._UserMessage.UserMessageGroup != undefined)
            groups.push(this.userMessageReadingFormViewModel._UserMessage.UserMessageGroup.ObjectID.toString());
        params.userMessageGroups = groups;

        this.cmdSwitchToAction.Text = i18n("M16910", "İşleme Geç");
        this.httpService.post<void>(apiUrlForInvoiceTerms, params).then(
            x => {
                this.sendBinaryData(x);
            });
        this.IsModified = false;
        this.isReplyMessage = false;
        this.Subject.Enabled = false;
        this.MessageBody.Enabled = false;
        this.ToUser.Enabled = false;
        this.Groups.Enabled = false;
        this.MessageDate.ReadOnly = true;
        this.cmdSend.Visible = false;
        this.cmdSave.Visible = false;
        this.cmdReply.Visible = false;
    }

    public async cmdSave_Click(): Promise<void> {
        let apiUrlForInvoiceTerms: string = '/api/UserMessageService/OnOKClickInternal';
        if (this.userMessageReadingFormViewModel._UserMessage.SenderStatus == 3) {
            let apiUrl: string = '/api/UserMessageService/DeleteAttachment';
            let params: DeleteAttachment_Input = new DeleteAttachment_Input();
            for (let data of this.deletedSavedAttachments){
                params.attachmentid = data.Attachmentid;
                this.httpService.post<void>(apiUrl, params);
            }
            apiUrlForInvoiceTerms = '/api/UserMessageService/OnOKClickInternalV2';
        }
        let params: SendMessageInternalWithGroupsV4_Input = new SendMessageInternalWithGroupsV4_Input();
        params.pBody    = this.userMessageReadingFormViewModel._UserMessage.MessageBody;
        params.subject  = this.userMessageReadingFormViewModel._UserMessage.Subject;
        params.ObjectID = this.userMessageReadingFormViewModel._UserMessage.ObjectID;
        let userss: Array<string> = new Array<string>();
        userss.push(this.userMessageReadingFormViewModel._UserMessage.ToUser.ObjectID.toString());
        params.toUsers = userss;

        let groups: Array<string> = new Array<string>();
        groups.push(this.userMessageReadingFormViewModel._UserMessage.UserMessageGroup.ObjectID.toString());


        params.expireDate = this.userMessageReadingFormViewModel._UserMessage.ExpireDate;
        params.isSplashMessage = this.userMessageReadingFormViewModel._UserMessage.IsSplashMessage;
        params.isSystemMessage = this.userMessageReadingFormViewModel._UserMessage.IsSystemMessage;
        params.messageFeedback = this.userMessageReadingFormViewModel._UserMessage.MessageFeedback;
        this.httpService.post<void>(apiUrlForInvoiceTerms, params).then(
            x => {
                this.sendBinaryData(x);
            });

        this.cmdSwitchToAction.Text = i18n("M16910", "İşleme Geç");
        this.IsModified = false;
        this.isReplyMessage = false;
        this.Subject.Enabled = false;
        this.MessageBody.Enabled = false;
        this.ToUser.Enabled = false;
        this.MessageDate.ReadOnly = true;
        this.cmdSend.Visible = false;
        this.cmdSave.Visible = false;
        this.cmdReply.Visible = false;
    }

    private async cmdDel_Click(): Promise<void> {
        this.IsModified = false;
        let apiUrlForInvoiceTerms: string = '/api/UserMessageService/DeleteMessage';
        let params: SendMessageInternalWithGroupsV4_Input = new SendMessageInternalWithGroupsV4_Input();
        params.pBody = this.userMessageReadingFormViewModel._UserMessage.MessageBody;
        params.subject = this.userMessageReadingFormViewModel._UserMessage.Subject;
        let userss: Array<string> = new Array<string>();
        userss.push(this.userMessageReadingFormViewModel._UserMessage.ToUser.ObjectID.toString());
        params.toUsers = userss;
        params.ObjectID = this.userMessageReadingFormViewModel._UserMessage.ObjectID;
        params.expireDate = this.userMessageReadingFormViewModel._UserMessage.ExpireDate;
        params.isSplashMessage = this.userMessageReadingFormViewModel._UserMessage.IsSplashMessage;
        params.isSystemMessage = this.userMessageReadingFormViewModel._UserMessage.IsSystemMessage;
        params.messageFeedback = this.userMessageReadingFormViewModel._UserMessage.MessageFeedback;
        this.httpService.post<void>(apiUrlForInvoiceTerms, params);

        this.cmdSwitchToAction.Text = i18n("M16910", "İşleme Geç");
        this.Subject.Enabled = false;
        this.MessageBody.Enabled = false;
        this.ToUser.Enabled = false;
        this.Groups.Enabled = false;
        this.MessageDate.ReadOnly = true;
        this.cmdSend.Visible = false;
        this.cmdSave.Visible = false;
        this.cmdReply.Visible = false;

    }

    public async cmdReply_Click(): Promise<void> {
        this.IsModified = true;
        this.isReplyMessage = true;
        this.userMessageReadingFormViewModel._UserMessage.MessageBody = `<br/><br/><hr style="color:red"><br/>Gönderen: `  + this.userMessageReadingFormViewModel._UserMessage.Sender.Name + i18n("M10051", "<br/>Tarih: ")
            + this.userMessageReadingFormViewModel._UserMessage.MessageDate.toLocaleDateString("tr-TR")  + ' ' + this.userMessageReadingFormViewModel._UserMessage.MessageDate.toLocaleTimeString("tr-TR")
            + i18n("M10050", "<br/>Başlık: ") + this.userMessageReadingFormViewModel._UserMessage.Subject + '<br/><br/>' + this.userMessageReadingFormViewModel._UserMessage.MessageBody.toString();
        if (this.userMessageReadingFormViewModel._UserMessage.Subject.Contains('RE: ')) {
            this.userMessageReadingFormViewModel._UserMessage.Subject = 'RE: ' + this.userMessageReadingFormViewModel._UserMessage.Subject;
        }
        this.userMessageReadingFormViewModel._UserMessage.ToUser = this.userMessageReadingFormViewModel._UserMessage.Sender;
        this.userMessageReadingFormViewModel._UserMessage.Sender = this.ActiveUser.UserObject;
        this.userMessageReadingFormViewModel.UserMessageAttachments.Clear();
        this.cmdReply.Visible = false;
        this.loadViewModel();
    }


    onChange($event) {

                let that = this;
                const file: File = $event.target.files[0];
                const fileReader: FileReader = new FileReader();
                const fileType = $event.target.parentElement.id;
                this.sizeSum(file.size);
                if (this.totalSize > 10000000) {
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13544", "Eklediğiniz dosyaların boyutu 10 Mb'dan fazla olamaz!"), MessageIconEnum.WarningMessage);
                    return;
                }
                fileReader.onloadend = (e) => {

                    that.param.Name = file.name,
                    that.param.Attachment = fileReader.result;
                };

                fileReader.readAsArrayBuffer(file);
                this.userMessageReadingFormViewModel.UserMessageAttachments.push(this.param);
            }

            sendBinaryData(messageID) {

                for (let att of this.userMessageReadingFormViewModel.UserMessageAttachments) {
                    if (att.IsNew){
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
            }



    public async cmdSwitchToFolder_Click(): Promise<void> {
        this._UserMessage.OpenForm = true;
        this.Close();
    }
    public async ViewReportButton_Click(): Promise<void> {
        if ((this._UserMessage.ReportDefID !== undefined)) {
            //let reportDef: TTReportDef = TTObjectDefManager.Instance.ReportDefs[this._UserMessage.ReportDefID.Value];
            //Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

            //TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
            //cache.Add("VALUE", _OutputSendingDocument.ObjectID.ToString());

            //parameters.Add("TTOBJECTID", cache);
            //TTReportTool.TTReport.PrintReport(this, reportDef, true, 1, new Dictionary<string, TTReportTool.PropertyCache<Object>>());
        }
    }
    protected async ClientSidePreScript(): Promise<void> {
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
        this.ActiveUser = TTUser.CurrentUser;
        this.userMessageReadingFormViewModel = new UserMessageReadingFormViewModel();
        this._ViewModel = this.userMessageReadingFormViewModel;
        this.userMessageReadingFormViewModel._UserMessage = this._TTObject as UserMessage;
        this.userMessageReadingFormViewModel._UserMessage.Sender = new ResUser();
        this.userMessageReadingFormViewModel._UserMessage.ToUser = new ResUser();
        this.userMessageReadingFormViewModel._UserMessage.UserMessageGroup = new UserMessageGroupDefinition();
        this.userMessageReadingFormViewModel.UserMessageAttachments  = new Array<UserMessageAttachment>();
    }

    protected loadViewModel() {
        let that = this;
        that.userMessageReadingFormViewModel = this._ViewModel as UserMessageReadingFormViewModel;
        that._TTObject = this.userMessageReadingFormViewModel._UserMessage;
        if (this.userMessageReadingFormViewModel == null)
            this.userMessageReadingFormViewModel = new UserMessageReadingFormViewModel();
        if (this.userMessageReadingFormViewModel._UserMessage == null)
            this.userMessageReadingFormViewModel._UserMessage = new UserMessage();
        if (this.userMessageReadingFormViewModel.UserMessageAttachments == null)
            this.userMessageReadingFormViewModel.UserMessageAttachments = new Array<UserMessageAttachment>();

        let senderObjectID = that.userMessageReadingFormViewModel._UserMessage["Sender"];
        if (senderObjectID != null && (typeof senderObjectID === "string")) {
            let sender = that.userMessageReadingFormViewModel.ResUsers.find(o => o.ObjectID.toString() === senderObjectID.toString());
             if (sender) {
                that.userMessageReadingFormViewModel._UserMessage.Sender = sender;
            }
        }
        let toUserObjectID = that.userMessageReadingFormViewModel._UserMessage["ToUser"];
        if (toUserObjectID != null && (typeof toUserObjectID === "string")) {
            let toUser = that.userMessageReadingFormViewModel.ResUsers.find(o => o.ObjectID.toString() === toUserObjectID.toString());
             if (toUser) {
                that.userMessageReadingFormViewModel._UserMessage.ToUser = toUser;
            }
        }
        let userMessageGroupID = that.userMessageReadingFormViewModel._UserMessage["UserMessageGroup"];
        if (userMessageGroupID != null && (typeof userMessageGroupID === "string")) {
            let userMessageGroup = that.userMessageReadingFormViewModel.messagegroups.find(o => o.ObjectID.toString() === userMessageGroupID.toString());
             if (userMessageGroup) {
                that.userMessageReadingFormViewModel._UserMessage.UserMessageGroup = userMessageGroup;
            }
        }
        if (!this.isReplyMessage)
            this.getMessageAttachments();
    }

    getMessageAttachments() {
        let apiUrlForInvoiceTerms: string = '/api/UserMessageService/GetMessageAttachment';
        let params: GetMessageAttachment_Input = new GetMessageAttachment_Input();
        params.messageID = this.userMessageReadingFormViewModel._UserMessage.ObjectID;
        this.httpService.post<any>(apiUrlForInvoiceTerms, params).then(
            x => {
                this.userMessageReadingFormViewModel.UserMessageAttachments = x;
            });
    }


    async ngOnInit()  {
        let that = this;
        await this.load(UserMessageReadingFormViewModel);
    }

    ngOnDestroy() {
        if (this.IsModified) {
            this.cmdSave_Click();
        }
    }

    private base64textString: String = "";
    fileName: string;
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
            reader.readAsBinaryString(file);
        }
    }

    sizeSum(size: number) {
        this.totalSize += size;
    }

    downloadAttachment(data) {

        let apiUrl: string = '/api/UserMessageDownloadService/DownloadFile';
        let input = { id: data.Attachmentid };
        let headers = new Headers();
        headers.set('Content-Type', 'application/json');
        let options = new RequestOptions();
        options.headers = headers;
        options.responseType = ResponseContentType.Blob;

        this.http2.post(apiUrl, JSON.stringify(input), options).toPromise().then(
            (res) => {
                const blob = new Blob([res.blob()], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
                CommonHelper.saveFile(res.blob(), data.Ekadi);
            });
    }

    deleteAttachment(data) {
        for (let i = 0; i < this.userMessageReadingFormViewModel.UserMessageAttachments.length; i++) {
            if (this.userMessageReadingFormViewModel.UserMessageAttachments[i] == data) {
                this.userMessageReadingFormViewModel.UserMessageAttachments.splice(i, 1);
                if (!data.IsNew){
                    this.deletedSavedAttachments.push(data);
                }
            }
        }
    }

    _handleReaderLoaded(readerEvt) {
        let binaryString = readerEvt.target.result;
        this.base64textString = btoa(binaryString);
        let param: UserMessageAttachment = new UserMessageAttachment();
        param.Name = this.fileName;
        param.Attachment = this.base64textString.toString();
        param.IsNew = true;
        this.userMessageReadingFormViewModel.UserMessageAttachments.push(param);
    }


    public onIsSystemMessageChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.IsSystemMessage != event) {
                this._UserMessage.IsSystemMessage = event;
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

    public onUserMessageGroupChanged(event): void {
        if (event != null) {
            if (this._UserMessage != null && this._UserMessage.UserMessageGroup != event) {
                this._UserMessage.UserMessageGroup = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.MessageDate, "Value", this.__ttObject, "MessageDate");
        redirectProperty(this.IsSystemMessage, "Value", this.__ttObject, "IsSystemMessage");
        redirectProperty(this.Subject, "Text", this.__ttObject, "Subject");
        redirectProperty(this.MessageBody, "Rtf", this.__ttObject, "MessageBody");
    }

    public initFormControls(): void {
        this.cmdSwitchToAction = new TTVisual.TTButton();
        this.cmdSwitchToAction.Text = i18n("M16910", "İşleme Geç");
        this.cmdSwitchToAction.Name = "cmdSwitchToAction";
        this.cmdSwitchToAction.TabIndex = 15;
        this.cmdSwitchToAction.Visible = false;

        this.cmdSend = new TTVisual.TTButton();
        this.cmdSend.Text = i18n("M14849", "Gönder");
        this.cmdSend.Name = "cmdSend";
        this.cmdSend.TabIndex = 15;
        this.cmdSend.Visible = false;

        this.cmdSave = new TTVisual.TTButton();
        this.cmdSave.Text = i18n("M17386", "Kaydet");
        this.cmdSave.Name = "cmdSave";
        this.cmdSave.TabIndex = 15;
        this.cmdSave.Visible = false;

        this.cmdReply = new TTVisual.TTButton();
        this.cmdReply.Text = i18n("M24271", "Yanıtla");
        this.cmdReply.Name = "cmdReply";
        this.cmdReply.TabIndex = 15;
        this.cmdReply.Visible = false;

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
        this.SenderUser.Enabled = false;
        this.SenderUser.TabIndex = 3;

        this.MessageBody = new TTVisual.TTRichTextBoxControl();
        this.MessageBody.DisplayText = "Mesaj";
        this.MessageBody.BackColor = "#DCDCDC";
        this.MessageBody.Name = "MessageBody";
        this.MessageBody.TabIndex = 12;
        this.MessageBody.ReadOnly = true;

        this.labelSubject = new TTVisual.TTLabel();
        this.labelSubject.Text = i18n("M11646", "Başlık");
        this.labelSubject.BackColor = "#DCDCDC";
        this.labelSubject.ForeColor = "#000000";
        this.labelSubject.Name = "labelSubject";
        this.labelSubject.TabIndex = 7;

        this.Subject = new TTVisual.TTTextBox();
        this.Subject.Name = "Subject";
        this.Subject.TabIndex = 2;
        this.Subject.Enabled = false;

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
        this.MessageDate.ReadOnly = true;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M14850", "Gönderen");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 7;

        this.IsSystemMessage = new TTVisual.TTCheckBox();
        this.IsSystemMessage.Value = false;
        this.IsSystemMessage.Text = i18n("M21915", "Sistem Mesajı");
        this.IsSystemMessage.Name = "IsSystemMessage";
        this.IsSystemMessage.TabIndex = 1;
        this.IsSystemMessage.Enabled = false;

        this.ToUser = new TTVisual.TTObjectListBox();
        this.ToUser.ListDefName = "ResUserListDefinition";
        this.ToUser.Name = "ToUser";
        this.ToUser.TabIndex = 4;
        this.ToUser.Enabled = false;

        this.Groups = new TTVisual.TTObjectListBox();
        this.Groups.ListDefName = "UserMessageGroupListDefinition";
        this.Groups.Name = "Groups";
        this.Groups.TabIndex = 5;
        this.Groups.Enabled = false;

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

        this.Controls = [this.cmdSwitchToAction, this.cmdSend, this.cmdSave, this.cmdSwitchToFolder, this.ViewReportButton, this.SenderUser, this.MessageBody, this.labelSubject, this.Subject, this.labelMessageDate, this.MessageDate, this.ttlabel1, this.IsSystemMessage, this.ToUser, this.ttlabel2, this.ttlabel3, this.Groups];

    }


}
export class SendMessageInternalWithGroupsV4_Input {
    public toUsers: Array<string>;
    public userMessageGroups: Array<string> = new Array<string>();
    public subject: string;
    public pBody: Object;
    public isSystemMessage: boolean;
    public messageFeedback: boolean;
    public patient: Patient;
    public isSplashMessage: boolean;
    public expireDate: Date;
    public ObjectID: Guid;
}

export class GetMessageAttachment_Input {
    public messageID: Guid;
}

export class DeleteAttachment_Input{
    public attachmentid: Guid;
}
