import { AtlasWebSocketContainer} from "./AtlasWebSocketContainer";

export class AtlasActionContainer extends AtlasWebSocketContainer {
    public actionType: AtlasActionType;
    public isExecuted: boolean;
    public actionDefinition: string;
    public actionMethod: string;
}

export enum AtlasActionType {

    CallMethod,
    NotifyUser,
    UpdateWorkList

}