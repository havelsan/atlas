import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

export class ProcedureAdditionalInfo {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public BaseAdditionalApplicationObjectID: Guid;
    public SubepisodeOpeningDate: string;
    public CreationDate: string;
    public ProtocolNo: string;
    public ProcedureCode: string;
    public ProcedureName: string;
    public DoctorName: string;

}