import { Guid } from "../../Mscorlib/Guid";
import { TTModuleDef } from "./TTModuleDef";
import { TTObjectDef } from "./TTObjectDef";
import { QueryDefSubTypeEnum } from "../../Utils/Enums/QueryDefSubTypeEnum";
import { TTDefCollection } from "./TTDefCollection";
import { TTQueryParameterDef } from "./TTQueryParameterDef";

export class TTQueryDef {
    public ModuleDefID: Guid;
    public ModuleDef: TTModuleDef;
    public ID: Guid;
    public static INJECTION_NQL_PLACE_HOLDER: string = "$B$";
    public ObjectDef: TTObjectDef;
    public ObjectDefID: Guid;
    public QueryDefID: Guid;
    public Name: string;
    public StaticFunctionName: string;
    public ClassName: string;
    public FullClassName: string;
    public Nql: string;
    public Description: string;
    public Methods: string;
    public Subtype: QueryDefSubTypeEnum;
    public ParameterDefs: TTDefCollection<TTQueryParameterDef>;
    public ToString(): string {
        return null;
    }
}
