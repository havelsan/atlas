import { Guid } from "NebulaClient/Mscorlib/Guid";

export class ListDefinitionWithResultInput {
    public listDefID?: Guid;
    public listDefName?: string;
    public userFilterExpression?: string;
}