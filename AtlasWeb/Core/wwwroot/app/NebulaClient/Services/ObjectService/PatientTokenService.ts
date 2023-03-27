//$A71810B1
import { NeHttpService } from "Fw/Services/NeHttpService";
import { PatientToken } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class PatientTokenService {
    public static async GetByToken(TOKEN: string): Promise<Array<PatientToken>> {
        let url: string = "/api/PatientTokenService/GetByToken";
        let input = { "TOKEN": TOKEN };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientToken>>(url, input);
        return result;
    }
    public static async GetByObjectID(OBJECTID: string): Promise<Array<PatientToken>> {
        let url: string = "/api/PatientTokenService/GetByObjectID";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientToken>>(url, input);
        return result;
    }
    public static async GetByInjection(injectionSQL: string): Promise<Array<PatientToken.GetByInjection_Class>> {
        let url: string = "/api/PatientTokenService/GetByInjection";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientToken.GetByInjection_Class>>(url, input);
        return result;
    }
    public static async GetPatientByInjection(injectionSQL: string): Promise<Array<PatientToken.GetPatientByInjection_Class>> {
        let url: string = "/api/PatientTokenService/GetPatientByInjection";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientToken.GetPatientByInjection_Class>>(url, input);
        return result;
    }
}