import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

export class ObjectDefLookupItem {
    @Type(() => Guid)
    public ObjectDefID: Guid;
    public ObjectDefName: string;
    public ModulePath: string;
}