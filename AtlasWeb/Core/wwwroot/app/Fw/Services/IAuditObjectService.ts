import { Guid } from 'NebulaClient/Mscorlib/Guid';

export abstract class IAuditObjectService {
    ObjectIDList: Array<AuditObject>;
}

export class AuditObject {
    AuditObjectID: Guid;
    AuditObjectDefID: Guid;
}
