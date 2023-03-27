import { Dictionary } from "../../System/Collections/Dictionaries/Dictionary";
import { Guid } from "../../Mscorlib/Guid";
import { TTReportDef } from "../../StorageManager/DefinitionManagement/TTReportDef";
import { Set } from "../../System/Collections/Set";

export class PropertyCache<T> extends Set<any> {
    push(name: string, item: any): void {
        this._addInternal(item);
    }
}

export class TTReport {
    public static PrintReport(reportdefName: string, isDisplay: boolean, duplicateCount: number, parameters: Dictionary<string, PropertyCache<string>>): void;
    public static PrintReport(parent: Object, reportDefID: Guid, isDisplay: boolean, duplicateCount: number, parameters: Dictionary<string, PropertyCache<Object>>): void;
    public static PrintReport(parent: Object, reportDef: TTReportDef, isDisplay: boolean, duplicateCount: number, parameters: Dictionary<string, PropertyCache<Object>>): void;
    public static PrintReport(reportType: string, isDisplay: boolean, duplicateCount: number, parameters: Dictionary<string, PropertyCache<Object>>): void;
    public static PrintReport(parent: Object, reportType: string, isDisplay: boolean, duplicateCount: number, parameters: Dictionary<string, PropertyCache<Object>>): void;
    public static PrintReport(parent: Object, reportType: string, isDisplay: boolean, duplicateCount: number, printDuplex: boolean, parameters: Dictionary<string, PropertyCache<Object>>): void;
    public static PrintReport(firstParam: any, ...otherParams): void {

    }
    public static ExportReportToPdf(reportType: string, parameters: Dictionary<string, PropertyCache<Object>>, exportFileName: string): void {
    }
    public static ExportReport(reportType: string, parameters: Dictionary<string, PropertyCache<Object>>, exportFileName: string): void {
    }
}
