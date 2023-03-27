import { Guid } from "../../Mscorlib/Guid";
import { List } from "../../System/Collections/List";
import { TTObjectDef } from "../DefinitionManagement/TTObjectDef";
import { TTModuleDef } from "./TTModuleDef";
import { TTFormDef } from "./TTFormDef";
import { TTObjectPropertyDef } from "./TTObjectPropertyDef";
import { TTDefCollection } from "./TTDefCollection";
import { TTQueryDef } from "./TTQueryDef";
import { TTListPropertyDef } from "./TTListPropertyDef";
import { TTListColumnDef } from "./TTListColumnDef";

export class TTListDef {
    public ModuleDefID: Guid;
    public ModuleDef: TTModuleDef;
    public ID: Guid;
    public ListDefID: Guid;
    public Name: string;
    public Caption: string;
    public ApplicationName: string;
    public Description: string;
    public ObjectDef: TTObjectDef;
    public ObjectDefID: Guid;
    public FormDef: TTFormDef;
    public FormDefID: Guid;
    public QueryDef: TTQueryDef;
    public QueryDefID: Guid;
    public ValueProperty: TTObjectPropertyDef;
    public ValuePropertyName: string;
    public TreeViewParentPath: string;
    public AllowSelectionFromTree: boolean;
    public AllowOnlyLeafSelection: boolean;
    public AutoSearchOnTreeSelect: boolean;
    public FilterExpression: string;
    public AutoFillList: boolean;
    public DisplayExpression: string;
    public FormWidth: number;
    public FormHeight: number;
    public Methods: string;
    public ListPropertyDefs: TTDefCollection<TTListPropertyDef>;
    public ListPropertyDefsSorted: List<TTListPropertyDef>;
    public ListColumnDefs: TTDefCollection<TTListColumnDef>;
    public ListColumnDefsSorted: List<TTListColumnDef>;
    public IsNQLList: boolean;
    public IsValueList: boolean;
    public ToString(): string {
        return null;
    }
    public ClassName: string;
    public IsWhereClauseExists: boolean;
    /*
    public GetNqlColumnNames(): IDictionary<string, ExpressionInfo> {
        return null;
    }
    public GetNqlColumnNames(objectDefManager: TTObjectDefManager): IDictionary<string, ExpressionInfo> {
        return null;
    }
    public ParseTreeViewParentPath(): TTObjectRelationDef[] {
        return null;
    }*/
}
