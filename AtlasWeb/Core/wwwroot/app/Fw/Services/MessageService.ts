import { Injectable, OnDestroy } from '@angular/core';
import { Response } from '@angular/http';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { ToastMessage } from 'Fw/Models/ToastMessage';
import notify from 'devextreme/ui/notify';
import { Observable, Subscription } from 'rxjs';
import { timer } from 'rxjs';


@Injectable()
export class MessageService implements OnDestroy {

    private messageServiceSubscription: Subscription;

    constructor() {
        if (MessageService.Timer == null) {
            MessageService.Timer = timer(5000, 1000);
            this.messageServiceSubscription = MessageService.Timer.subscribe(t => {
                this.update();
            });
        }

    }

    private static ToastDisplayTime: number = 5000;
    private static ToastMaxWidth: string = '500px';
    private static counter: number = 0;
    private static interval = null;
    private static Timer = null;
    private sub: Subscription;
    private static Period: number = 0;
    private static yOffset: number = 50;
    private static positionAt: string = "bottom";
    private static ToastMessageList: Array<ToastMessage> = new Array<ToastMessage>();
    private static isNewAddedMessage: boolean = false;

    private getDefaultProperties(TotalDisplayTime): any {
        return {
            displayTime: TotalDisplayTime,
            maxWidth: MessageService.ToastMaxWidth,
            closeOnClick: true,
            closeOnOutsideClick: true,
            position: {
                at: "bottom",
                my: "center",
                offset: { x: 0, y: (-MessageService.yOffset - MessageService.counter * 50) }

            }
        };
    }

    public showReponseError(error: Response | any): void {
        if (error instanceof Response) {
            let res = <NeResult<any>>error.json();
            if (res !== undefined) {
                this.showError(res.Message);
            }
        } else {
            this.showError(error.toString());
        }
    }

    public showError(errorMessage: string): void {
        let toastMessage = new ToastMessage(errorMessage, "error", MessageService.ToastDisplayTime);
        MessageService.ToastMessageList.push(toastMessage);
        MessageService.isNewAddedMessage = true;
        if (errorMessage.length > 350) {
            MessageService.yOffset = 250;
            MessageService.positionAt = "center";
        }
        else {
            MessageService.yOffset = 50;
            MessageService.positionAt = "bottom";
        }

        this.update();
    }

    public showInfo(infoMessage: string): void {
        let toastMessage = new ToastMessage(infoMessage, "info", MessageService.ToastDisplayTime);
        MessageService.ToastMessageList.push(toastMessage);
        MessageService.isNewAddedMessage = true;
        this.update();
    }

    public showSuccess(successMessage: string): void {
        let toastMessage = new ToastMessage(successMessage, "success", MessageService.ToastDisplayTime);
        MessageService.ToastMessageList.push(toastMessage);
        MessageService.isNewAddedMessage = true;
        this.update();
    }

    public update() {

        let Counter = this.clearOldMessages(MessageService.ToastMessageList);

        if (MessageService.isNewAddedMessage) {

            MessageService.isNewAddedMessage = false;
            let message = "";
            let i: number = 1;
            MessageService.counter = 0;
            for (let toastMessage of MessageService.ToastMessageList) {
                if (toastMessage.Displayable()) {
                    MessageService.counter++;

                    let properties = this.getDefaultProperties(toastMessage.ShowableTime);
                    properties.type = toastMessage.Type;
                    properties.message = toastMessage.Message;

                    notify(properties);
                }

            }
        }

    }

    private clearOldMessages(ToastMessageList: Array<ToastMessage>): number {

        let Counter = 0;
        for (let toastMessage of ToastMessageList) {
            if (toastMessage.Displayable() == false) {
                let index = ToastMessageList.indexOf(toastMessage, 0);
                if (index > -1) {
                    ToastMessageList.splice(index, 1);
                    Counter++;
                }
            }
        }
        return Counter;

    }

    ngOnDestroy() {
        if (this.messageServiceSubscription != null) {
            this.messageServiceSubscription.unsubscribe();
            this.messageServiceSubscription = null;
        }
    }

}