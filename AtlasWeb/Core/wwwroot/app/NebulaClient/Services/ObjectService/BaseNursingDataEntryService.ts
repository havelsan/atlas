//$C0E58B45
import { BaseNursingDataEntry } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class BaseNursingDataEntryService {
    public static async GetBaseNursingDataByType(OBJECTDEFNAME: string, NURSINGAPPLICATION: Guid): Promise<Array<BaseNursingDataEntry>> {
        let url: string = '/api/BaseNursingDataEntryService/GetBaseNursingDataByType';
        let input = { "OBJECTDEFNAME": OBJECTDEFNAME, "NURSINGAPPLICATION": NURSINGAPPLICATION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseNursingDataEntry>>(url, input);
        return result;
    }
    public static async GetByInPatientPhysicianApplication(INPATIENTPHYSICIANAPPLICATION: Guid): Promise<Array<BaseNursingDataEntry>> {
        let url: string = '/api/BaseNursingDataEntryService/GetByInPatientPhysicianApplication';
        let input = { "INPATIENTPHYSICIANAPPLICATION": INPATIENTPHYSICIANAPPLICATION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseNursingDataEntry>>(url, input);
        return result;
    }
}