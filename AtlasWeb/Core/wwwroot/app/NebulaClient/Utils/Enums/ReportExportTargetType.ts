import { EnumItem } from 'NebulaClient/Mscorlib/EnumItem';
import { ClassType } from 'NebulaClient/ClassTransformer';
import { IEnumList } from 'NebulaClient/Mscorlib/IEnumList';

export enum ReportExportTargetType {
    Pdf = 1,
    Excel = 2,
    XPS = 3,
    PlainText = 4,
    HTML = 5,
    Word = 6,
    Access = 7,
}
export namespace ReportExportTargetType {
    export const _Pdf = new EnumItem(ReportExportTargetType.Pdf, 'Pdf', 'Pdf', 1);
    export const _Excel = new EnumItem(ReportExportTargetType.Excel, 'Excel', 'Excel', 2);
    export const _XPS = new EnumItem(ReportExportTargetType.XPS, 'XPS', 'XPS', 3);
    export const _PlaintText = new EnumItem(ReportExportTargetType.PlainText, 'PlainText', 'PlainText', 4);
    export const _HTML = new EnumItem(ReportExportTargetType.HTML, 'HTML', 'HTML', 5);
    export const _Word = new EnumItem(ReportExportTargetType.Word, 'Word', 'Word', 6);
    export const _Access = new EnumItem(ReportExportTargetType.Access, 'Access', 'Access', 7);
    export const Items: Array<EnumItem> = [_Pdf, _Excel, _XPS, _PlaintText, _HTML, _Word, _Access];

    @ClassType()
    export class ReportExportTargetTypeList implements IEnumList {
        get Items(): Array<EnumItem> {
            return ReportExportTargetType.Items;
        }
    }

    export function GetMIMEType(exportType: ReportExportTargetType): string {
        switch (exportType) {
            case ReportExportTargetType.Pdf: {
                return 'application/pdf';
            }
            case ReportExportTargetType.Excel: {
                return 'application/vnd.ms-excel';
            }
            case ReportExportTargetType.XPS: {
                return 'application/vnd.ms-xpsdocument';
            }
            case ReportExportTargetType.PlainText: {
                return 'text/plain';
            }
            case ReportExportTargetType.HTML: {
                return 'text/html';
            }
            case ReportExportTargetType.Word: {
                return 'application/msword';
            }
            case ReportExportTargetType.Access: {
                return 'application/x-msaccess';
            }
        }
    }
}