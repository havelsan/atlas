//$8C8D787D
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

export class ResWardService {
    public static async SendResWardToDietRationSystem(resWard: ResWard): Promise<void> {
        let url: string = "/api/ResWardService/SendResWardToDietRationSystem";
        let input = { "resWard": resWard };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async GetSimpleResUserInfoOfWard(ResWardcGuid: Guid): Promise<Array<ResUser>> {
        let url: string = "/api/ResWardService/GetSimpleResUserInfoOfWard";
        let input = { "ResWardcGuid": ResWardcGuid };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async GetSimpleResUserInfoByUserType(userTypeEnum: UserTypeEnum, resRectionGuid: Guid): Promise<Array<ResUser>> {
        let url: string = "/api/ResWardService/GetSimpleResUserInfoByUserType";
        let input = { "userTypeEnum": userTypeEnum, "resRectionGuid": resRectionGuid };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async GetWardDefinition(injectionSQL: string): Promise<Array<ResWard.GetWardDefinition_Class>> {
        let url: string = "/api/ResWardService/GetWardDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResWard.GetWardDefinition_Class>>(url, input);
        return result;
    }
    public static async OLAP_ResWard(): Promise<Array<ResWard.OLAP_ResWard_Class>> {
        let url: string = "/api/ResWardService/OLAP_ResWard";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResWard.OLAP_ResWard_Class>>(url, input);
        return result;
    }
    public static async OLAP_ResWard_OQ(): Promise<Array<ResWard>> {
        let url: string = "/api/ResWardService/OLAP_ResWard_OQ";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResWard>>(url, input);
        return result;
    }
    public static async GetResWards(injectionSQL: string): Promise<Array<ResWard>> {
        let url: string = "/api/ResWardService/GetResWards";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResWard>>(url, input);
        return result;
    }
    public static async GetResWardWityEmtyBed(): Promise<Array<ResWard>> {
        let url: string = "/api/ResWardService/GetResWardWityEmtyBed";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResWard>>(url, input);
        return result;
    }
    public static async GetByID(OBJECTID: Guid): Promise<Array<ResWard>> {
        let url: string = "/api/ResWardService/GetByID";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResWard>>(url, input);
        return result;
    }
}