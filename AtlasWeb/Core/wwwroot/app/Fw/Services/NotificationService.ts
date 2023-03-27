import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Notification } from '../Models/Notification';

@Injectable()
export class NotificationService {

    notificationSource: Subject<Notification>;

    constructor() {
        this.notificationSource = new Subject<Notification>();
    }

    notify(message: string, type: string = 'success', displayTime: number = 3000): void {
        let notification = new Notification(message, type, displayTime);
        this.notificationSource.next(notification);
    }
}