
export enum AtlasSourceType {
    System = 1,
    User = 2,
}
export enum AtlasContentType {
    Message = 1,
    Notification = 2,
    Action = 3,
    Emergency = 4,
    LaboratoryPanicNotification = 5,
}


export class AtlasWebSocketContainer {
    public users: Array<string> = new Array<string>();
    public actionData: any;
    public content: any;
    public contentType: AtlasContentType ;
    public sourceType: AtlasSourceType;
    public dataProcessedSuccessfully: boolean;
    public status: string ;
    public headerDefinition: string;
    public createTimeStr: string;
    public createTime: Date;
    public notificationID : string;

    constructor(){
        this.createTime = new Date();
        this.createTimeStr =  this.createTime.toLocaleTimeString();
    }

}