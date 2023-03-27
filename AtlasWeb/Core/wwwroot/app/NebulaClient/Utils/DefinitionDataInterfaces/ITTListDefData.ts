import { Guid } from "../../Mscorlib/Guid";

export interface ITTListDefData {
    ListDefID: Guid;
    Name: string;
    Caption: string;
    Description: string;
    ObjectDefID: Guid;
    ValuePropertyName: string;
    TreeViewParentPath: string;
    AllowSelectionFromTree: boolean;
    AllowOnlyLeafSelection: boolean;
    AutoSearchOnTreeSelect: boolean;
    AutoFillList: boolean;
    FilterExpression: string;
    DisplayExpression: string;
    FormDefID: Guid;
    FormWidth: number;
    FormHeight: number;
    QueryDefID: Guid;
    Methods: string;
}