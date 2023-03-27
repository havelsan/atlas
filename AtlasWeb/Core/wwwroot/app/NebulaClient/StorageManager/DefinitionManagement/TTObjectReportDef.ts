import { Guid } from "../../Mscorlib/Guid";
import { TTReportDef } from "./TTReportDef";

export class TTObjectReportDef {
    public ReportDef: TTReportDef;
    public ObjectDefID: Guid;
    public ReportDefID: Guid;
    public DuplicateCount: number;
    public AskUser: boolean;
    public IsDisplay: boolean;
}
