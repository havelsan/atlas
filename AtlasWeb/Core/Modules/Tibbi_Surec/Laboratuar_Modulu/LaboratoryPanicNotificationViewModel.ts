
import { Type } from 'NebulaClient/ClassTransformer';

export class LaboratoryPanicNotificationViewModel {
    @Type(() => PanicNotificationInfo)
    public PanicNotificationInfoList: Array<PanicNotificationInfo>;
}

export class PanicNotificationInfo {
    public ObjectID: string;
    public PatientNameSurame: string;
    public ProtocolNo: string;
    public Description: string;
}