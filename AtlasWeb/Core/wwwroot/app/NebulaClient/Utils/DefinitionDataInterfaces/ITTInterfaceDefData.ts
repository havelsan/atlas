import { Guid } from "../../Mscorlib/Guid";

export interface ITTInterfaceDefData {
    InterfaceDefID: Guid;
    BaseInterfaceDefID: Guid;
    Name: string;
    Methods: string;
    Description: string;
    IsBuiltIn: boolean;
}