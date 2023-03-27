//$AA23C82E
import { GlassesReport } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class GlassesReportService {
    public static async ReceteKaydet(_GlassesReport: GlassesReport, vitrumFar: boolean, vitrumNear: boolean, vitrumCloseReading: boolean): Promise<void> {
        let url: string = "/api/GlassesReportService/ReceteKaydet";
        let input = { "_GlassesReport": _GlassesReport, "vitrumFar": vitrumFar, "vitrumNear": vitrumNear, "vitrumCloseReading": vitrumCloseReading };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async GetGlassesReport(OBJECTID: string): Promise<Array<GlassesReport.GetGlassesReport_Class>> {
        let url: string = "/api/GlassesReportService/GetGlassesReport";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GlassesReport.GetGlassesReport_Class>>(url, input);
        return result;
    }
}