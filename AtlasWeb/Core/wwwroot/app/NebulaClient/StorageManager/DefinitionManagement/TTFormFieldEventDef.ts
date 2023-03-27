import { Guid } from "../../Mscorlib/Guid";
import { TTFormFieldDef } from "./TTFormFieldDef";

export class TTFormFieldEventDef {
    public EventDefID: Guid;
    public FieldDef: TTFormFieldDef;
    public FieldDefID: Guid;
    public Name: string;
    public Body: string;
    public ToString(): string {
        return null;
    }
}
