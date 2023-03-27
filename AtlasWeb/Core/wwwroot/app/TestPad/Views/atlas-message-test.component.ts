import { Component, OnDestroy, OnInit } from '@angular/core';
import { AtlasSignalRService } from 'Fw/Services/AtlasSignalRService';
import { AtlasWebSocketContainer, AtlasSourceType } from 'Fw/Models/AtlasWebSocketContainer';
import { Subscription } from 'rxjs';

@Component({
    selector: 'atlas-message-test-component',
    template: `<h1>Message Client</h1>
    <dx-text-box [(value)]="message"></dx-text-box>
    <dx-button [text]="'Send Message'" (onClick)="sendMessage()"></dx-button>
    <div>
    <ul>
    <li *ngFor="let item of receivedMessages">
      {{item | json}}
    </li>
  </ul>
</div>
    `,
    providers: [AtlasSignalRService]
})
export class AtlasMessageTestComponent implements OnInit, OnDestroy {

    public message: string;
    public messageReceivedSubsription: Subscription;
    public receivedMessages: Array<any>;

    constructor(private messageService: AtlasSignalRService) {
        this.receivedMessages = new Array<any>();
    }

    sendMessage() {
        if (this.messageService.connectionExists) {
            const messageItem = new AtlasWebSocketContainer();
            messageItem.sourceType = AtlasSourceType.User;
            messageItem.content = this.message;
            const messageString = JSON.stringify(messageItem);
            this.messageService.sendMessage(messageString);
        }
    }

    ngOnInit() {
        let that = this;
        this.messageService.startConnection();
        this.messageReceivedSubsription = this.messageService.newMessageHandle.subscribe(m => {
            const message = JSON.parse(m);
            that.receivedMessages.push(message);
        });
    }

    ngOnDestroy() {
        this.messageService.stopConnection();
        if (this.messageReceivedSubsription) {
            this.messageReceivedSubsription.unsubscribe();
            this.messageReceivedSubsription = null;
        }
    }

}


