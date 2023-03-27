//$E54E8939
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { SafeSurgeryCheckList, Surgery } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'app/NebulaClient/ClassTransformer';

export class SafeSurgeryCheckListFormViewModel extends BaseViewModel {
    public _SafeSurgeryCheckList: SafeSurgeryCheckList = new SafeSurgeryCheckList();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Surgery)
    public _Surgery: Surgery;
}
