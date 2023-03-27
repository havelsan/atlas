import { Guid } from "../../Mscorlib/Guid";
import { TTObjectSubTypeEnum } from "../Enums/TTObjectSubTypeEnum";
import { CheckOutStatusEnum } from "../Enums/CheckOutStatusEnum";

export interface ITTObjectDefBaseData {
    ID: Guid;
    BaseObjectDefID: Guid;
    Name: string;
    Description: string;
    DisplayText: string;
    IsAbstract: boolean;
    Methods: string;
    IsCheckOutUser: boolean;
    IsDeleted: boolean;
    IsInserted: boolean;
    SubType: TTObjectSubTypeEnum;
    CheckOutStatus: CheckOutStatusEnum;
    IsOfType(objectDefName: string): boolean;
    IsOfType(objectDefID: Guid): boolean;
    GetBaseObjectDef(): ITTObjectDefBaseData;
    GetRootObjectDef(): ITTObjectDefBaseData;
}