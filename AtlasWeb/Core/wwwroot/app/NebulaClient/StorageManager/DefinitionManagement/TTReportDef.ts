import { Guid } from "../../Mscorlib/Guid";
import { TTModuleDef } from "./TTModuleDef";
import { TTPermissionDef } from "./TTPermissionDef";

export class TTReportDef {
    public ModuleDefID: Guid;
    public ModuleDef: TTModuleDef;
    public ID: Guid;
    public ReportDefID: Guid;
    public ReportNO: string;
    public CodeName: string;
    public Name: string;
    public Caption: string;
    public Description: string;
    public ReportXML: string;
    public ExcelTemplate: Object;
    public Methods: string;
    public PermissionDefID: Guid;
    public PermissionDef: TTPermissionDef;
    public ApplicationName: string;
    public ToString(): string {
        return null;
    }
}
