//$EFCFEDB4
import { Dictionary } from 'NebulaClient/System/Collections/Dictionaries/Dictionary';
import { DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { UserTemplate } from 'NebulaClient/Model/AtlasClientModel';

export class UserTemplateService {
    public static async GetDrugOrderIntroductionTemplate(ResUserObjectId: Guid): Promise<Dictionary<string, Array<DrugOrderIntroductionDet>>> {
        let url: string = "/api/UserTemplateService/GetDrugOrderIntroductionTemplate";
        let input = { "ResUserObjectId": ResUserObjectId };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Dictionary<string, Array<DrugOrderIntroductionDet>>>(url, input);
        return result;
    }
    public static async IsTemplateNameAvailable(ResUserObjectId: Guid, TemplateName: string): Promise<boolean> {
        let url: string = "/api/UserTemplateService/IsTemplateNameAvailable";
        let input = { "ResUserObjectId": ResUserObjectId, "TemplateName": TemplateName };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetUserTemplate(RESUSERID: Guid, TAOBJECTDEFID: Guid, FILITERDATA: string): Promise<Array<UserTemplate.GetUserTemplate_Class>> {
        let url: string = "/api/UserTemplateService/GetUserTemplate";
        let input = { "RESUSERID": RESUSERID, "TAOBJECTDEFID": TAOBJECTDEFID, "FILITERDATA": FILITERDATA };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<UserTemplate.GetUserTemplate_Class>>(url, input);
        return result;
    }
}