//$0C770BE6
import { Allergy } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class AllergyService {
    public static async GetAllergiesByImpMedInfoID(ImpMedInfoID: string): Promise<Array<Allergy>> {
        let url: string = "/api/AllergyService/GetAllergiesByImpMedInfoID";
        let input = { "ImpMedInfoID": ImpMedInfoID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Allergy>>(url, input);
        return result;
    }
}