import { Guid } from "../../Mscorlib/Guid";
import { PropertyDefaultValueTypeEnum } from "../Enums/PropertyDefaultValueTypeEnum";
import { ITTDataTypeData } from "./ITTDataTypeData";

export interface ITTObjectPropertyDefData {
    ObjectDefID: Guid;
    PropertyDefID: Guid;
    Name: string;
    Caption: string;
    CodeName: string;
    Description: string;
    DataTypeID: Guid;
    DefaultValueType: PropertyDefaultValueTypeEnum;
    DefaultValue: Object;
    IsDynamic: boolean;
    IsRequired: boolean;
    IsProtected: boolean;
    IsNoLock: boolean;
    SetScript: string;
    DataType: ITTDataTypeData;
    ShadowOfPropertyDefID: Guid;
}