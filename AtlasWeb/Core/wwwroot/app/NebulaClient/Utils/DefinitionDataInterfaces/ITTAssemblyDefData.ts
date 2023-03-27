import { Guid } from "../../Mscorlib/Guid";

export interface ITTAssemblyDefData {
    AssemblyDefID: Guid;
    Name: string;
    Description: string;
    Version: number;
}