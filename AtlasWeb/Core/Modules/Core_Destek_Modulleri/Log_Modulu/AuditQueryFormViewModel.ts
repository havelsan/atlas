//$F69C563C
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { AuditObject } from 'Fw/Services/IAuditObjectService';

export class AuditQueryFormViewModel extends BaseViewModel {
    @Type(() => Users)
    public users: Array<Users> = new Array<Users>();
    @Type(() => ObjectDef)
    public _object: Array<ObjectDef> = new Array<ObjectDef>();
    @Type(() => LogDataSource)
    public LogDataSource: Array<LogDataSource> = new Array<LogDataSource>();
    @Type(() => LogDataSourceDetails)
    public LogDataSourceDetails: Array<LogDataSourceDetails> = new Array<LogDataSourceDetails>();
}
export class ObjectDef {
    public ObjectName: string;
    @Type(() => Guid)
    public ObjectDefId: Guid;
}
export class AuditQueryFilter {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public UserID: Guid;
    @Type(() => Guid)
    public ObjectDefID: Guid;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
}
export class LogDataSource {
    public OperationName: string;
    @Type(() => Date)
    public Date: Date;
    public PcIp: string;
    public AccountName: string;
    @Type(() => Guid)
    public AuditId: Guid;
    public IzId: string;
}
export class LogDataSourceDetails {
    public Caption: string;
    public Value: string;
    public Value2: string;

}

export class Users {
    public Name: string;
    @Type(() => Guid)
    public UserID: Guid;
}

export class ShowAuditFormViewModel extends BaseViewModel {
    @Type(() => Guid)
    public objectID: Guid;
    @Type(() => LogDataSource)
    public LogDataSource: Array<LogDataSource> = new Array<LogDataSource>();
    @Type(() => LogDataSourceDetails)
    public LogDataSourceDetails: Array<LogDataSourceDetails> = new Array<LogDataSourceDetails>();
    @Type(() => AuditObject)
    public auditObjectIDs: Array<AuditObject> = new Array<AuditObject>();
    @Type(() => AuditObjectList)
    public auditObjectList: Array<AuditObjectList> = new Array<AuditObjectList>();
    @Type(() => AuditObject)
    public selectedAuditObject: AuditObject ;
}

export class AuditObjectList {
    @Type(() => Guid)
    public objectID: Guid;
    public objectName: String;
}

