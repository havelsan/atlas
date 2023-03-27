//$685E0D9A
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DentalTechnicianTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class DentalLaboratoryProcedureService {
    public static async FillTechnicians(): Promise<Array<FillTechnicians_Output>> {
        let url: string = '/api/DentalLaboratoryProcedureService/FillTechnicians';
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<FillTechnicians_Output>>(url, '');
        return result;
    }
}
export class FillTechnicians_Output {
    name: string;
    technicianType: DentalTechnicianTypeEnum;
    technicianTypeName: string;
    totalWorks: number;
    unfinishedWorks: number;
     @Type(() => Guid)
    TecnicanObjectID: Guid;
}
