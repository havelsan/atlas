import { Guid } from "../../Mscorlib/Guid";

export interface ITTObjectReportDefData {
    ObjectDefID: Guid;
    ReportDefID: Guid;
    DuplicateCount: number;
    AskUser: boolean;
    IsDisplay: boolean;
}