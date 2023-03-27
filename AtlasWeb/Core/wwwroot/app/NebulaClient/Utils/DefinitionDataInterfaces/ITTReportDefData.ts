import { Guid } from "../../Mscorlib/Guid";

export interface ITTReportDefData {
    ReportDefID: Guid;
    Name: string;
    Caption: string;
    Description: string;
    ReportXML: string;
    Methods: string;
    ReportNO: string;
    ExcelTemplate: Object;
}