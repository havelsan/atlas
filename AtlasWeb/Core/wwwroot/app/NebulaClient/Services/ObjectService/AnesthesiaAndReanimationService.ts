//$D998E44F
import { AnesthesiaAndReanimation } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class AnesthesiaAndReanimationService {
    public static async AnesthesiaReportNQL(ANESTHESIA: string): Promise<Array<AnesthesiaAndReanimation.AnesthesiaReportNQL_Class>> {
        let url: string = '/api/AnesthesiaAndReanimationService/AnesthesiaReportNQL';
        let input = { "ANESTHESIA": ANESTHESIA };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AnesthesiaAndReanimation.AnesthesiaReportNQL_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetAnesthesiaOfSurgery(SURGERYID: string): Promise<Array<AnesthesiaAndReanimation.OLAP_GetAnesthesiaOfSurgery_Class>> {
        let url: string = '/api/AnesthesiaAndReanimationService/OLAP_GetAnesthesiaOfSurgery';
        let input = { "SURGERYID": SURGERYID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AnesthesiaAndReanimation.OLAP_GetAnesthesiaOfSurgery_Class>>(url, input);
        return result;
    }
    public static async GetByEpisode(EPISODE: Guid): Promise<Array<AnesthesiaAndReanimation>> {
        let url: string = '/api/AnesthesiaAndReanimationService/GetByEpisode';
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AnesthesiaAndReanimation>>(url, input);
        return result;
    }
}