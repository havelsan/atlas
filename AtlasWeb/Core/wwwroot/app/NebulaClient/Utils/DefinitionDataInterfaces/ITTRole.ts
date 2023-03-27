import { Guid } from "../../Mscorlib/Guid";
import { RoleSubTypeEnum } from "../Enums/RoleSubTypeEnum";

export interface ITTRole {
    RoleID: Guid;
    Name: string;
    Subtype: RoleSubTypeEnum;
}