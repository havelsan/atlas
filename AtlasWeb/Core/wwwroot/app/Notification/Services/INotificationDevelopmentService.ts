import { Observable } from 'rxjs';
import { AtlasNotificationContainer } from 'Fw/Models/AtlasNotificationcontainer';
import { EventEmitter } from '@angular/core';


export abstract class INotificationDevelopmentService {
    abstract addDevelopmentNotification(notification: AtlasNotificationContainer);
    abstract Notifications: Array<AtlasNotificationContainer>;
    abstract get NotificationCount(): string;
    abstract ClearAllNotifications();
    abstract NewNotificationAdded: Observable<any>;
    abstract GetNotifications(timeSpan: number, size: number);
    abstract OnUpdate : EventEmitter<any>;
    abstract BeforeUpdate : EventEmitter<any>;
    abstract ReachedBottom: boolean;
    abstract LastTime: number;
    abstract SetRead(notificationID: string, read :boolean);
    abstract ReadAll();
    abstract Dispose();
}