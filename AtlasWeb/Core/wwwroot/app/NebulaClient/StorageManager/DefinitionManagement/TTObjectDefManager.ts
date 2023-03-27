import { TTDefCollection } from "./TTDefCollection";
import { TTAssemblyDef } from "./TTAssemblyDef";
import { TTModuleDef } from "./TTModuleDef";
import { TTObjectDef } from "./TTObjectDef";
import { TTDataType } from "../../DataDictionary/TTDataType";
import { TTInterfaceDef } from "./TTInterfaceDef";
import { TTListDef } from "./TTListDef";
import { TTUnboundFormDef } from "./TTUnboundFormDef";
import { TTAttributeDef } from "./TTAttributeDef";
import { TTReportDef } from "./TTReportDef";


export class TTObjectDefManager {
    public static SetGeneratingSourceCodeForClassEditor(forClassEditor: boolean): void {

    }
    public static Instance: TTObjectDefManager;
    public static ServerDateDifferenceInDays: number = 0;
    public static ServerTimeString(isLongString: boolean): string {
        return null;
    }
    public ServerTime: Date;
    public RealServerTime: Date;
    public static GetServerTime(refresh: boolean): Date {
        return null;
    }
    public static GetRealServerTime(refresh: boolean): Date {
        return null;
    }
    public AssemblyDefs: TTDefCollection<TTAssemblyDef>;
    public ModuleDefs: TTDefCollection<TTModuleDef>;
    public ObjectDefs: TTDefCollection<TTObjectDef>;
    public InterfaceDefs: TTDefCollection<TTInterfaceDef>;
    public AttributeDefs: TTDefCollection<TTAttributeDef>;
    public DataTypes: TTDefCollection<TTDataType>;
    public ListDefs: TTDefCollection<TTListDef>;
    public ReportDefs: TTDefCollection<TTReportDef>;
    //public Roles: TTDefCollection<TTRole>;
    //public BuiltInRoles: TTDefCollection<TTBuiltInRole>;
    //public AllRoles: TTDefCollection<TTRole>;
    //public PermissionDefs: TTDefCollection<TTPermissionDef>;
    //public SystemRightDefs: TTDualKeyCollection<number, string, TTRightDef>;
    public UnboundFormDefs: TTDefCollection<TTUnboundFormDef>;
    public GetObjectDef(type: string): TTObjectDef {
        return null;
    }
    public GetObjectDefFromObjectTableName(objectTableName: string): TTObjectDef {
        return null;
    }
    public Dispose(): void {

    }
}
