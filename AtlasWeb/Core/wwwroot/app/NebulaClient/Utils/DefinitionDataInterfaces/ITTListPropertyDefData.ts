import { Guid } from "../../Mscorlib/Guid";
import { ListPropertyDefAccessEnum } from "../Enums/ListPropertyDefAccessEnum";

export interface ITTListPropertyDefData {
    ListPropertyDefID: Guid;
    ListDefID: Guid;
    MemberName: string;
    Caption: string;
    AccessType: ListPropertyDefAccessEnum;
    CriteriaOrder: number;
    FormFieldDefID: Guid;
    ControlWidth: number;
}