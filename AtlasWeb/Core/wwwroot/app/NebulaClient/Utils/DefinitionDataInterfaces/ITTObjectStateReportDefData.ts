import { Guid } from "../../Mscorlib/Guid";
import { ITTObjectReportDefData } from "./ITTObjectReportDefData";

export interface ITTObjectStateReportDefData extends ITTObjectReportDefData {
    StateDefID: Guid;
}