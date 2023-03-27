import { INotificationDevelopmentService } from './INotificationDevelopmentService';

import { Injectable , EventEmitter} from '@angular/core';
import { Subscription } from 'rxjs';
import { AtlasSignalRService } from 'app/Fw/Services/AtlasSignalRService';
import { AtlasNotificationContainer } from 'Fw/Models/AtlasNotificationcontainer';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { AtlasWebSocketContainer } from 'app/Fw/Models/AtlasWebSocketContainer';

@Injectable()
export class NotificationDevelopmentService implements INotificationDevelopmentService{


    public OnUpdate: EventEmitter<any> = new EventEmitter<any>();
    public BeforeUpdate: EventEmitter<any> = new EventEmitter<any>();
    public LastTime: number;
    public ReachedBottom: boolean = false;
    public NewNotificationAdded: EventEmitter<any>;
    public Notifications: Array<AtlasNotificationContainer> = [];
    private  AddedNotificationCount: number;
    public NotificationSubsription: Subscription;

    constructor(private signalRService: AtlasSignalRService
        , private httpService: NeHttpService) {

        this.NewNotificationAdded  = new EventEmitter<AtlasNotificationContainer>();
        this.AddedNotificationCount = 0;
        this.subscribeSignalRService();

    }
    private subscribeSignalRService() {
        this.NotificationSubsription = this.signalRService.newNotificationHandle.subscribe(atlasNotificationContainer => {
            this.addDevelopmentNotification(atlasNotificationContainer);
        });
    }

    public addDevelopmentNotification(x)
    {
        let item =  new AtlasNotificationContainer(); 
        item.actionData = x.Notification.ActionData;
        item.content = x.Notification.Content;
        item.contentType = x.Notification.ContentType;
        item.createTime = x.Notification.CreateTime;
        item.headerDefinition = x.Notification.HeaderDefinition;
        item.sourceType = x.Notification.SourceType;
        item.isRead = x.NotificationUser.IsRead;
        item.users = [x.NotificationUser.ResUser];
        item.createTimeStr = new Date(item.createTime.toString()).toLocaleString('tr-TR');
        item.notificationType = 0;
        item.notificationID = x.NotificationUser.ObjectID;
        
        this.Notifications.unshift(item);
        this.OnUpdate.emit();
    }

    public ClearAllNotifications(){
        this.Notifications.Clear();
        this.ReachedBottom = false;
    }
    public get  NotificationCount(): string{
         if (this.AddedNotificationCount == 0){
             return "Yeni bildiriminiz bulunmamaktadır!";
         }else{
             return this.AddedNotificationCount + " bildiriminiz bulunmaktadır!";
         }
    }
    SetRead(notificationID: string, read: boolean) {
        this.httpService.get<any>('/api/Account/SetRead?notificationID=' + notificationID + "&read=" + read).then(x => { 

        });
    }
    ReadAll() {
        this.httpService.get<any>('/api/Account/ReadAll').then(x => { 

        });
    }
    GetNotifications(size: number, lastTime?: number) {

        let sessionKey = 'notifications';
        let isLocalDataExist = sessionStorage.getItem(sessionKey);

        if(lastTime == null){
            sessionStorage.removeItem(sessionKey);
        }

        if (isLocalDataExist == null) {
            this.httpService.get<Array<any>>('/api/Account/GetNotifications?lastTime=' + (lastTime == null ? '' : lastTime) + "&size=" + size).then(x => {
                
                if (x != null && x.length > 0) {
                    this.BeforeUpdate.emit();
                    let items : Array<AtlasNotificationContainer> = x.map(x => {

                        let item =  new AtlasNotificationContainer(); 
                        item.actionData = x.Notification.ActionData;
                        item.content = x.Notification.Content;
                        item.contentType = x.Notification.ContentType;
                        item.createTime = x.Notification.CreateTime;
                        item.headerDefinition = x.Notification.HeaderDefinition;
                        item.sourceType = x.Notification.SourceType;
                        item.isRead = x.NotificationUser.IsRead;
                        item.users = [x.NotificationUser.ResUser];
                        item.createTimeStr = new Date(item.createTime.toString()).toLocaleString('tr-TR');
                        item.notificationType = 0;
                        item.notificationID = x.NotificationUser.ObjectID;
                        return item
                    });

                    this.Notifications = this.Notifications.concat(items);

                    //console.log("NEW ITEMS ADDED!");
                    let lastNotification = this.Notifications[this.Notifications.length -1].createTime.toString();
                    this.LastTime = Date.parse( lastNotification + "Z") + (new Date().getTimezoneOffset() / 60 * 3600000);

                    if(x.length < size){
                        //console.log("LAST PAGE !!!");
                        this.ReachedBottom = true;
                    }
                    //sessionStorage.setItem(sessionKey, JSON.stringify(this.Notifications));
                    this.OnUpdate.emit();
                }else{
                    //console.log("LAST PAGE !!!");
                    this.ReachedBottom = true;
                    this.OnUpdate.emit();
                }
                
            });
        } else {
            this.Notifications = JSON.parse(isLocalDataExist);
            
        }
    }
    public Dispose() {
        this.Notifications.Clear();
    }
}