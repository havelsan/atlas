//$A0680FF8
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ResPoliclinic } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class ResPoliclinicService {
    public static async SendResPoliclinicToMainGateOperation(resPoliclinic: ResPoliclinic): Promise<void> {
        let url: string = "/api/ResPoliclinicService/SendResPoliclinicToMainGateOperation";
        let input = { "resPoliclinic": resPoliclinic };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async GetHCPoliclinicList(): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetHCPoliclinicList";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
    public static async OLAP_GetResPoliclinicCount(): Promise<Array<ResPoliclinic.OLAP_GetResPoliclinicCount_Class>> {
        let url: string = "/api/ResPoliclinicService/OLAP_GetResPoliclinicCount";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic.OLAP_GetResPoliclinicCount_Class>>(url, input);
        return result;
    }
    public static async GetByRelation(RELATIONPARENTNAME: string, PARENTOBJECTID: string): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetByRelation";
        let input = { "RELATIONPARENTNAME": RELATIONPARENTNAME, "PARENTOBJECTID": PARENTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
    public static async GetPoliclinicDefinition(injectionSQL: string): Promise<Array<ResPoliclinic.GetPoliclinicDefinition_Class>> {
        let url: string = "/api/ResPoliclinicService/GetPoliclinicDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic.GetPoliclinicDefinition_Class>>(url, input);
        return result;
    }
    public static async GetPoliclinicListDefinition(injectionSQL: string): Promise<Array<ResPoliclinic.GetPoliclinicListDefinition_Class>> {
        let url: string = "/api/ResPoliclinicService/GetPoliclinicListDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic.GetPoliclinicListDefinition_Class>>(url, input);
        return result;
    }
    public static async GetPoliclinicByMHRSCode(MHRSCODE: number): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetPoliclinicByMHRSCode";
        let input = { "MHRSCODE": MHRSCODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
    public static async GetPoliclinicByMedulaBrans(BRANS: string): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetPoliclinicByMedulaBrans";
        let input = { "BRANS": BRANS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
    public static async GetDentalPoliclinic(): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetDentalPoliclinic";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
    public static async GetPoliclinicByAsalCode(ASALCODE: number): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetPoliclinicByAsalCode";
        let input = { "ASALCODE": ASALCODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
    public static async GetByMHRSKlinikVeAltKlinikKodu(MHRSKLINIKKODU: number, MHRSALTKLINIKKODU: number): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetByMHRSKlinikVeAltKlinikKodu";
        let input = { "MHRSKLINIKKODU": MHRSKLINIKKODU, "MHRSALTKLINIKKODU": MHRSALTKLINIKKODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
    public static async GetMHRSPoliclinics(): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetMHRSPoliclinics";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
    public static async GetMHRSPoliclinicDefinition(injectionSQL: string): Promise<Array<ResPoliclinic.GetMHRSPoliclinicDefinition_Class>> {
        let url: string = "/api/ResPoliclinicService/GetMHRSPoliclinicDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic.GetMHRSPoliclinicDefinition_Class>>(url, input);
        return result;
    }
    public static async GetHCPoliclinic(): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetHCPoliclinic";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
    public static async GetAllPoliclinics(): Promise<Array<ResPoliclinic>> {
        let url: string = "/api/ResPoliclinicService/GetAllPoliclinics";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResPoliclinic>>(url, input);
        return result;
    }
}