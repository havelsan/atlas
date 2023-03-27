import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

export class DataGridMessage {
    constructor(
        public messageName: string,
        public name: string,
        public content: any) {
    }
}

export class Messages {
    public static ItemsChangeMessage: string = "ItemsChange";
    public static ReadOnly: string = "ReadOnly";
    //public static ReadOnly: string = "ReadOnly";
}

@Injectable()
export class DataGridMessageService {
    private MessageSource: Subject<DataGridMessage> = new Subject<DataGridMessage>();
    private GridColumnsObservable: any = {};
    public OnMessage: Observable<DataGridMessage> = this.MessageSource.asObservable();

    public SendMessage(messageName: string, name: string, items: any) {
        this.MessageSource.next(new DataGridMessage(messageName,
            name,
            items));
    }
}