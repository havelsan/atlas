import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { BaseModel } from './Models/BaseModel';

export class TTObject extends BaseModel {
    public ObjectID: Guid;
    public ObjectDefID: Guid;
}