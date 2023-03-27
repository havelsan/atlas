import { AtlasWebSocketContainer } from "./AtlasWebSocketContainer";

export enum AtlasNotificationType {
    Unknown = 0,
    Warning = 1,
    Info = 2,
    Error = 3,
    Message = 4
}

export class AtlasNotificationContainer extends AtlasWebSocketContainer {
    public notificationType: AtlasNotificationType;
    public isRead: boolean;
}