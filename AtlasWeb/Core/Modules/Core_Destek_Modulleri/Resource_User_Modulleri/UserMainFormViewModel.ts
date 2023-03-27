//$DB89F690
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

export class UserMainFormViewModel extends BaseViewModel {

    @Type(() => ResUserInfo)
    public ResUserInfoList: Array<ResUserInfo> = new Array<ResUserInfo>();
}
export class ResUserInfo {

    @Type(() => Guid)
    public ObjectID: Guid;

    @Type(() => Guid)
    public ObjectDefID: Guid;

    public Name: string;
    public UserName: string;
    public UniqueRefNo: number;
}
