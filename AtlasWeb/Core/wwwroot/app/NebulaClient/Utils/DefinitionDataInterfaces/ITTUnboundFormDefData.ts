import { Guid } from "../../Mscorlib/Guid";

export interface ITTUnboundFormDefData {
    FormDefID: Guid;
    BaseFormDefID: Guid;
    Caption: string;
    Description: string;
    Height: number;
    Name: string;
    NameSpace: string;
    Width: number;
    Methods: string;
    ClientSideMethods: string;
    DifferenceXML: string;
    FormNO: string;
}