import { Guid } from "../../Mscorlib/Guid";
import { ITTObjectReportDefData } from "./ITTObjectReportDefData";

export interface ITTObjectStateTransitionReportDefData extends ITTObjectReportDefData {
    StateTransitionDefID: Guid;
}