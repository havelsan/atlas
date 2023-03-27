import { Injectable, EventEmitter } from '@angular/core';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { HubConnectionBuilder, HubConnection, LogLevel, HttpTransportType } from "@aspnet/signalr";
import { AtlasNotificationContainer } from '../Models/AtlasNotificationcontainer';
import { AtlasActionContainer } from '../Models/AtlasActionContainer';
import { environment } from 'app/environments/environment';
@Injectable()
export class AtlasSignalRService {

    public newMessageHandle: EventEmitter<any>;
    public newNotificationHandle: EventEmitter<any>;
    public newActionHandle: EventEmitter<any>;
    public newEmergencyHandle: EventEmitter<any>;
    public connectionEstablished: EventEmitter<Boolean>;
    public connectionExists: Boolean;

    constructor(protected activeUserService: IActiveUserService) {
        this.connectionEstablished = new EventEmitter<Boolean>();
        this.newMessageHandle = new EventEmitter<any>();
        this.newNotificationHandle = new EventEmitter<any>();
        this.newActionHandle = new EventEmitter<any>();
        this.newEmergencyHandle = new EventEmitter<any>();
        this.connectionExists = false;
    }
    public stopConnection(): void {
        if (this.signalRConnection != undefined)
            this.signalRConnection.stop();
        this.connectionExists = false;
    }
    private signalRConnection: HubConnection;

    public startConnection(): void {

        if (this.activeUserService.ActiveUser != null) {

            let url = '/AtlasHub';
            if (environment.target == 'dev') {
                url = environment.apiRoot + url;
            }

            const token = sessionStorage.getItem('token');
            let qs = `authtoken=${token}&uname=${this.activeUserService.ActiveUser.Name.toString()}&connid=${this.activeUserService.ActiveUser.UserObject.ObjectID.toString()}`;
            this.signalRConnection = new HubConnectionBuilder()
                .withUrl(`${url}?${qs}`, {
                    accessTokenFactory: () => token,
                    transport: HttpTransportType.WebSockets,
                })
                .configureLogging(LogLevel.Warning)
                .build();

            this.signalRConnection.start()
                .then(data => {
                    console.log("Now connected");
                    this.connectionExists = true;
                    this.connectionEstablished.emit(true);
                    this.registerOnServerEvents();
                })
                .catch(error => {
                    console.log('Could not connect ' + error);
                    this.connectionEstablished.emit(false);
                });
        }
    }

    private registerOnServerEvents(): void {
        this.signalRConnection.on("HandleUserMessage", (data: any) => {
            this.newMessageHandle.emit(data);
        });
        this.signalRConnection.on("HandleUserNotification", (data: any) => {
            this.newNotificationHandle.emit(data);
        });
        this.signalRConnection.on("HandleActions", (data: any) => {
            this.newActionHandle.emit(data);
        });
        this.signalRConnection.on("HandleEmergencies", (data: any) => {
            this.newEmergencyHandle.emit(data);
        });
        console.log("registerOnServerEvents connected");
    }

    public sendMessage(message: string): void {
        this.signalRConnection.send("HandleUserMessage", message);
    }

    public sendNotification(atlasNotificationContainer: AtlasNotificationContainer): void {
        let atlasNotificationContainerStr: string = JSON.stringify(atlasNotificationContainer);
        this.signalRConnection.send("HandleUserNotification", atlasNotificationContainerStr);
    }

    public sendAction(atlasActionContainer: AtlasActionContainer): void {
        let atlasActionContainerStr: string = JSON.stringify(atlasActionContainer);
        this.signalRConnection.send("HandleActions", atlasActionContainerStr);
    }
}