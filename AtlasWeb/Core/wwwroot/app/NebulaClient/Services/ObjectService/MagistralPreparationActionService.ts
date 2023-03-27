//$445B5EC8
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MagistralPreparationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralDefUsedDrug } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralDefUsedChemical } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralDefUsedConsMat } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPackagingType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPackagingSubType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationType } from 'NebulaClient/Model/AtlasClientModel';
import { MagistralPreparationSubType } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Type } from 'NebulaClient/ClassTransformer';

export class MagistralPreparationActionService {
    public static async GetMagistralDefinition(OBJECTID: Guid): Promise<GetMagistralDefinition_Output> {
        let url: string = "/api/MagistralPreparationActionService/GetMagistralDefinition";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetMagistralDefinition_Output>(url, input);
        return result;
    }

    public static async GetMagistralPackagingSubTypeMaterial(OBJECTID: Guid): Promise<Material> {
        let url: string = "/api/MagistralPreparationActionService/GetMagistralPackagingSubTypeMaterial";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Material>(url, input);
        return result;
    }

        public static async GetChemicalMaterial(OBJECTID: Guid): Promise<Material> {
        let url: string = "/api/MagistralPreparationActionService/GetChemicalMaterial";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Material>(url, input);
        return result;
    }
}
export class GetMagistralDefinition_Output {
    public magistralDef: MagistralPreparationDefinition;
    public magistralDefUsedDrugs: Array<MagistralDefUsedDrug>;
    public magistralDefUsedChemicals: Array<MagistralDefUsedChemical>;
    public magistralDefUsedConsMats: Array<MagistralDefUsedConsMat>;
    @Type(() => MagistralPackagingType)
    public magistralPackagingType: MagistralPackagingType;
    @Type(() => MagistralPackagingSubType)
    public magistralPackagingSubType: MagistralPackagingSubType;
    @Type(() => MagistralPreparationType)
    public magistralPreparationType: MagistralPreparationType;
    @Type(() => MagistralPreparationSubType)
    public magistralPreparationSubType: MagistralPreparationSubType;
}