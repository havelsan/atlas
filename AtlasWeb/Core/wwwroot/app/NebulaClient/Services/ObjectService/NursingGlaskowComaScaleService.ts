//$602F9000
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { NursingGlaskowComaScale } from 'NebulaClient/Model/AtlasClientModel';
import { GlaskowComaScaleScoreEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class NursingGlaskowComaScaleService {
    public static async CalcGlaskowComaScaleTotalScore(nursingGlaskowComaScale: NursingGlaskowComaScale): Promise<GlaskowComaScaleScoreEnum> {
        let url: string = "/api/NursingGlaskowComaScaleService/CalcGlaskowComaScaleTotalScore";
        let input = { "nursingGlaskowComaScale": nursingGlaskowComaScale };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GlaskowComaScaleScoreEnum>(url, input);
        return result;
    }
}