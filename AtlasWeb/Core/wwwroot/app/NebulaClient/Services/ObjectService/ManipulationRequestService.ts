//$0273CD2B
import { ManipulationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class ManipulationRequestService {
    public static async GetManipulationRequestQuery(REPORTNO: string): Promise<Array<ManipulationRequest.GetManipulationRequestQuery_Class>> {
        let url: string = '/api/ManipulationRequestService/GetManipulationRequestQuery';
        let input = { "REPORTNO": REPORTNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ManipulationRequest.GetManipulationRequestQuery_Class>>(url, input);
        return result;
    }
}