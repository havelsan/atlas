import { PhoneTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MHRSActionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class MHRSExceptionalFormViewModel extends BaseViewModel {
    @Type(() => Guid)
    public schedule: Guid;
    public Email: string;
    public PhoneType: PhoneTypeEnum;
    public PhoneNumber: string;
    public Description: string;
    @Type(() => MHRSActionTypeDefinition)
    public ActionType: MHRSActionTypeDefinition;
    @Type(() => Guid)
    public actionTypeObjectId: Guid;
    public DocumentPath: string;
    @Type(() => Boolean)
    public Result: boolean;
    //public Document: number[];
    //constructor() {
    //    this.Document = new Array<number>();
    //}
}