//$4CA12A57
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Vaccination } from 'NebulaClient/Model/AtlasClientModel';

export class VaccinationService {
    public static async GetVaccinationsByImpMedInfoID(ImpMedInfoID: string): Promise<Array<Vaccination>> {
        let url: string = "/api/VaccinationService/GetVaccinationsByImpMedInfoID";
        let input = { "ImpMedInfoID": ImpMedInfoID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Vaccination>>(url, input);
        return result;
    }
}