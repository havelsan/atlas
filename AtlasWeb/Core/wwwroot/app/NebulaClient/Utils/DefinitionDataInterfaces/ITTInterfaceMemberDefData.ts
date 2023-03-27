import { Guid } from "../../Mscorlib/Guid";

export interface ITTInterfaceMemberDefData {
    InterfaceDefID: Guid;
    Name: string;
    Description: string;
    CodeType: string;
    IsReadOnly: boolean;
}