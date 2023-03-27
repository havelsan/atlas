import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class QueryParams {
    public ObjectDefID: Guid;
    public QueryDefID: Guid;
    public QueryName: string;
    public Parameters: any;
}