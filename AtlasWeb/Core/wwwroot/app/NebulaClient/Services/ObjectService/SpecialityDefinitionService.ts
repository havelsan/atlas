//$E406C264
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class SpecialityDefinitionService {
    public static async GetBrans(code: string): Promise<SpecialityDefinition> {
        let url: string = "/api/SpecialityDefinitionService/GetBrans";
        let input = { "code": code };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<SpecialityDefinition>(url, input);
        return result;
    }
    public static async GetSpecialityByResUser(resUser: ResUser): Promise<SpecialityDefinition> {
        let url: string = "/api/SpecialityDefinitionService/GetSpecialityByResUser";
        let input = { "resUser": resUser };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<SpecialityDefinition>(url, input);
        return result;
    }
    public static async OLAP_SpecialityDefinition(): Promise<Array<SpecialityDefinition.OLAP_SpecialityDefinition_Class>> {
        let url: string = "/api/SpecialityDefinitionService/OLAP_SpecialityDefinition";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SpecialityDefinition.OLAP_SpecialityDefinition_Class>>(url, input);
        return result;
    }
    public static async GetSpecialityDefinitionByExternalCode(EXTERNALCODE: number, injectionSQL: string): Promise<Array<SpecialityDefinition>> {
        let url: string = "/api/SpecialityDefinitionService/GetSpecialityDefinitionByExternalCode";
        let input = { "EXTERNALCODE": EXTERNALCODE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SpecialityDefinition>>(url, input);
        return result;
    }
    public static async GetSpecialityDefinitionNql(injectionSQL: string): Promise<Array<SpecialityDefinition.GetSpecialityDefinitionNql_Class>> {
        let url: string = "/api/SpecialityDefinitionService/GetSpecialityDefinitionNql";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SpecialityDefinition.GetSpecialityDefinitionNql_Class>>(url, input);
        return result;
    }
    public static async GetSpecialityDefinitionQuery(injectionSQL: string): Promise<Array<SpecialityDefinition.GetSpecialityDefinitionQuery_Class>> {
        let url: string = "/api/SpecialityDefinitionService/GetSpecialityDefinitionQuery";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SpecialityDefinition.GetSpecialityDefinitionQuery_Class>>(url, input);
        return result;
    }
    public static async GetSpecialityDefByLastUpdateDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<SpecialityDefinition>> {
        let url: string = "/api/SpecialityDefinitionService/GetSpecialityDefByLastUpdateDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SpecialityDefinition>>(url, input);
        return result;
    }
    public static async GetAllSpecialityDefinition(injectionSQL: string): Promise<Array<SpecialityDefinition.GetAllSpecialityDefinition_Class>> {
        let url: string = "/api/SpecialityDefinitionService/GetAllSpecialityDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SpecialityDefinition.GetAllSpecialityDefinition_Class>>(url, input);
        return result;
    }
    public static async GetSpecialityByCode(CODE: string): Promise<Array<SpecialityDefinition>> {
        let url: string = "/api/SpecialityDefinitionService/GetSpecialityByCode";
        let input = { "CODE": CODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SpecialityDefinition>>(url, input);
        return result;
    }
    public static async GetMinorSpecialities(): Promise<Array<SpecialityDefinition>> {
        let url: string = "/api/SpecialityDefinitionService/GetMinorSpecialities";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SpecialityDefinition>>(url, input);
        return result;
    }
}