
export enum AtlasMessageType {
    System = 1,
    User = 2,
}


export class AtlasMessageContainer {
    public MessageType: AtlasMessageType;
    public Payload: Object;
    public users: Array<string> = new Array<string>();
    public ResponseMessage: string;
    public DataProcessedSuccessfully: boolean;

}