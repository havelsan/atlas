//$45E4008F
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { UserMessage } from 'NebulaClient/Model/AtlasClientModel';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { DxAccordionComponent } from 'devextreme-angular';

@Component({
    selector: 'UserMessageBoxForm',
    templateUrl: './UserMessageBoxForm.html',
    providers: [MessageService, SystemApiService]
})
export class UserMessageBoxForm extends TTVisual.TTForm implements OnInit, AfterViewInit {
    @ViewChild('messageAcc') messageAcc: DxAccordionComponent;
    public ActiveUser: any;
    SMS: boolean;
    Email: boolean;
    inbox: any;
    inboxToday: any;
    inboxYesterday: any;
    inboxThisWeek: any;
    inboxOlder: any;
    currentBox: string;
    oldBox: string;

    ModelinboxToday: any;
    ModelinboxYesterday: any;
    ModelinboxThisWeek: any;
    ModelinboxOlder: any;

    showPopup: boolean;
    static modeldt: Array<any>;
    usertdt: Array<any>;
    emailnumber: string;
    message: string;
    subject: string;
    subjectvisible: boolean;
    SelectedUser: any;
    TodayDate: Date;
    MessageDate: Date;
    MessageTime: Date;
    public get _UserMessage(): UserMessage {
        return this._TTObject as UserMessage;
    }
    private UserMessageReadingForm_DocumentUrl: string = '/api/UserMessageService/UserMessageReadingForm';
    constructor(public systemApiService: SystemApiService, protected httpService: NeHttpService, protected messageService: MessageService, private activeUserService: IActiveUserService) {
        super("USERMESSAGE", "UserMessageReadingForm");
        this.subjectvisible = false;
        UserMessageBoxForm.modeldt = new Array<any>();
        this.usertdt = new Array<any>();
        this.TodayDate = new Date();
        this.currentBox = 'inbox';
        this.oldBox = this.currentBox;
        this.showPopup = false;
        this._DocumentServiceUrl = this.UserMessageReadingForm_DocumentUrl;
        this.initViewModel();
    }


    // ***** Method declarations start *****

    //btnMessage_Click() {
    //    let attt: any = {};
    //    attt.TOUSER = this.ActiveUser.UserObject.ObjectID;
    //    attt.StartDate = new Date();
    //    attt.EndDate = new Date().AddDays(-7);
    //    let apiUrl: string = '/api/UserMessageService/GetUserInboxMessages';
    //    this.httpService.post<Array<UserMessage.GetUserInboxMessages_Class>>(apiUrl, attt).then(
    //        x => {
    //            this.inbox = x;
    //            UserMessageBoxForm.modeldt = x;
    //        }

    //    );
    //}

    async btnInbox_Click() {
        this.currentBox = 'inbox';
        this.oldBox = this.currentBox;
        await this.fillBox(this.currentBox);
        this.fillModelDt();
        //this.selectedChange(this.inboxToday[0]);
    }

    async btnSendMessage_Click() {
        this.currentBox = 'sent';
        this.oldBox = this.currentBox;
        await this.fillBox(this.currentBox);
        this.fillModelDt();
        //    this.selectedChange(this.inboxToday[0]);

    }

    async btnDraftMessage_Click() {
        this.currentBox = 'draft';
        this.oldBox = this.currentBox;
        await this.fillBox(this.currentBox);
        this.fillModelDt();
        //    this.selectedChange(this.inboxToday[0]);
    }

    async btnDeletedMessage_Click() {
        this.currentBox = 'deleted';
        this.oldBox = this.currentBox;
        await this.fillBox(this.currentBox);
        this.fillModelDt();
    }

    txtChange(e) {
        if (e.value != "") {
            let excludeListToday: Array<any> = Array<any>();
            let excludeListYesterday: Array<any> = Array<any>();
            let excludeListThisWeek: Array<any> = Array<any>();
            let excludeListOlder: Array<any> = Array<any>();
            for (let mc of UserMessageBoxForm.modeldt) {
                if (mc.Gonderenadi.toUpperCase().includes(e.value.toUpperCase()) || mc.Baslik.toUpperCase().includes(e.value.toUpperCase())) {
                    if (new Date(mc.Tarih) >= new Date().AddHours(-new Date().getHours()).AddMinutes(-new Date().getMinutes())) {
                        excludeListToday.push(mc);
                    }
                    else if (new Date(mc.Tarih) >= new Date().AddDays(-1).AddHours(-new Date().getHours()).AddMinutes(-new Date().getMinutes()) && new Date(mc.Tarih) < new Date().AddHours(-new Date().getHours()).AddMinutes(-new Date().getMinutes())) {
                        excludeListYesterday.push(mc);
                    }
                    else if (new Date(mc.Tarih) >= new Date().AddDays(-7).AddHours(-new Date().getHours()).AddMinutes(-new Date().getMinutes()) && new Date(mc.Tarih) < new Date().AddDays(-1).AddHours(-new Date().getHours()).AddMinutes(-new Date().getMinutes())) {
                        excludeListThisWeek.push(mc);
                    }
                    else {
                        excludeListOlder.push(mc);
                    }
                }
            }
            this.inboxToday = excludeListToday;
            this.inboxYesterday = excludeListYesterday;
            this.inboxThisWeek = excludeListThisWeek;
            this.inboxOlder = excludeListOlder;
        }
        else {
            this.inboxToday = this.ModelinboxToday;
            this.inboxYesterday = this.ModelinboxYesterday;
            this.inboxThisWeek = this.ModelinboxThisWeek;
            this.inboxOlder = this.ModelinboxOlder;
        }
    }

    selectedChange(data: any) {
        if (data.itemData.Messageid != undefined) {
            if (this.currentBox == 'inbox') {
                if (data.itemData.Durumu != 0) {
                    let param: InputParam = new InputParam();
                    param.ObjectID = new Guid(data.itemData.Messageid);
                    let apiUrl: string = '/api/UserMessageService/IsMessageRead';
                    this.httpService.post<any>(apiUrl, param).then(
                        x => {
                            this.updateCurrentBox();
                        }
                    );
                }
            }
            this.systemApiService.open(data.itemData.Messageid, 'USERMESSAGE', 'b40ac20a-68fd-485e-9915-ce7c66d5801a');
        }

    }

    async DeleteSelectedMessage(data) {
        if (this.currentBox == 'deleted') {
            let result1: string = await ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", i18n("M23735", "Uyarı"), i18n("M18921", "Mesaj Sil!"), i18n("M12090", "Bu mesaj kalıcı olarak silinecektir.") + "\r\n" + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
            if (result1 == "T") {
                let param: InputParam = new InputParam();
                param.ObjectID = new Guid(data.Messageid);
                param.CurrentBox = this.currentBox;
                let apiUrl: string = '/api/UserMessageService/DeleteMessage';
                this.httpService.post<any>(apiUrl, param).then(
                    x => {
                        this.updateCurrentBox();
                        this.selectedChange(this.inboxToday[0]);
                    }
                );
            }
        }
        else {
            let param: InputParam = new InputParam();
            param.ObjectID = new Guid(data.Messageid);
            param.CurrentBox = this.currentBox;
            let apiUrl: string = '/api/UserMessageService/DeleteMessage';
            this.httpService.post<any>(apiUrl, param).then(
                x => {
                    this.updateCurrentBox();
                    this.selectedChange(this.inboxToday[0]);
                }
            );
        }

    }




    async updateCurrentBox() {
        await this.fillBox(this.oldBox);
        this.fillModelDt();
    }


    btnNewMessage_Click() {
        this.currentBox = 'newMessage';
        this.showPopup = true;
    }


    mailchanged(value) {
        if (value.value == true)
            this.subjectvisible = true;
        else
            this.subjectvisible = false;

    }

    popupHidden() {
        this.updateCurrentBox();
    }


    async fillBox(box: string) {
        let attt: any = {};
        UserMessageBoxForm.modeldt = [];
        attt.StartDate = new Date();
        attt.EndDate = new Date();
        let apiUrl: string;

        if (box == 'inbox') {
            apiUrl = '/api/UserMessageService/GetUserInboxMessages';
        }
        else if (box == 'sent') {
            apiUrl = '/api/UserMessageService/GetSentItemsUserMessages';
        }
        else if (box == 'draft') {
            apiUrl = '/api/UserMessageService/GetDraftUserMessages';
        }
        else {
            apiUrl = '/api/UserMessageService/GetDeletedItemsUserMessages';
        }
        this.currentBox = box;

        attt.Mode = 'Today';
        this.httpService.post<Array<any>>(apiUrl, attt).then(
            x => {
                //this.messageAcc.instance.repaint();
                this.inboxToday = x;
                this.ModelinboxToday = this.inboxToday;
                for (let mc of this.inboxToday) {
                    UserMessageBoxForm.modeldt.push(mc);
                }
            }
        );

        attt.Mode = 'Yesterday';
        this.httpService.post<Array<any>>(apiUrl, attt).then(
            x => {
                //this.messageAcc.instance.repaint();
                this.inboxYesterday = x;
                this.ModelinboxYesterday = this.inboxYesterday;
                for (let mc of this.inboxYesterday) {
                    UserMessageBoxForm.modeldt.push(mc);
                }
            }
        );

        attt.Mode = 'ThisWeek';
        this.httpService.post<Array<any>>(apiUrl, attt).then(
            x => {
                //this.messageAcc.instance.repaint();
                this.inboxThisWeek = x;
                this.ModelinboxThisWeek = this.inboxThisWeek;
                for (let mc of this.inboxThisWeek) {
                    UserMessageBoxForm.modeldt.push(mc);
                }
            }
        );

        attt.Mode = 'Older';
        this.httpService.post<Array<any>>(apiUrl, attt).then(
            x => {
                //  this.messageAcc.instance.repaint();
                this.inboxOlder = x;
                this.ModelinboxOlder = this.inboxOlder;
                for (let mc of this.inboxOlder) {
                    UserMessageBoxForm.modeldt.push(mc);
                }
            }
        );
    }

    async fillModelDt() {
        //UserMessageBoxForm.modeldt = [];
        //for (let mc of this.inboxToday) {
        //    UserMessageBoxForm.modeldt.push(mc);
        //}
        //for (let mc of this.inboxYesterday) {
        //    UserMessageBoxForm.modeldt.push(mc);
        //}
        //for (let mc of this.inboxThisWeek) {
        //    UserMessageBoxForm.modeldt.push(mc);
        //}
    }



    protected async ClientSidePreScript(): Promise<void> {

    }

    // *****Method declarations end *****

    public async initViewModel() {
        this.ActiveUser = TTUser.CurrentUser;
        await this.fillBox(this.currentBox);
        this.fillModelDt();
    }

    send() {
        if (this.Email) {
            let apiUrlForMail: string = '/api/UserMessageService/SendMailCustom';
            let mailparams: SendMailInternalforCustom = new SendMailInternalforCustom();
            mailparams.body = this.message;
            mailparams.subject = this.subject;
            let mails: Array<string> = this.emailnumber.split(';');
            mailparams.mail = mails;
            this.httpService.post<void>(apiUrlForMail, mailparams);
        }
        if (this.SMS) {
            let apiUrlForSMS: string = '/api/UserMessageService/SendSMSCustom';
            let smsparams: SendSMSInternalforCustom = new SendSMSInternalforCustom();
            smsparams.text = this.message;
            let nums: Array<string> = this.emailnumber.split(';');
            smsparams.numbers = nums;
            this.httpService.post<void>(apiUrlForSMS, smsparams);
        }
    }

    protected loadViewModel() {


    }

    async ngOnInit() {
        this.ActiveUser = TTUser.CurrentUser;
        await this.load();
    }

    ngAfterViewInit() {
        //  this.messageAcc.instance.repaint();
        this.messageAcc.instance.expandItem(1);
        this.messageAcc.instance.expandItem(2);
        this.messageAcc.instance.expandItem(3);
    }

}

export class SendMailInternalforCustom {
    public mail: Array<string> = new Array<string>();
    public body: string;
    public subject: string;
}

export class SendSMSInternalforCustom {
    public numbers: Array<string> = new Array<string>();
    public text: string;
}

export class InputParam {
    public ObjectID: Guid;
    public CurrentBox: string;
}

