//$CCA0FAE0
import { FavoriteDrug } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DrugInfo, DrugIngredient } from 'ObjectClassService/DrugOrderIntroductionService';

export class FavoriteDrugService {
    public static async GetFavoriteDrugsWithObjectID(RESUSER: Guid): Promise<Array<FavoriteDrug.GetFavoriteDrugsWithObjectID_Class>> {
        let url: string = '/api/FavoriteDrugService/GetFavoriteDrugsWithObjectID';
        let input = { 'RESUSER': RESUSER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<FavoriteDrug.GetFavoriteDrugsWithObjectID_Class>>(url, input);
        return result;
    }
    public static async GetFavoriteDrugs(RESUSER: Guid): Promise<Array<FavoriteDrug.GetFavoriteDrugs_Class>> {
        let url: string = '/api/FavoriteDrugService/GetFavoriteDrugs';
        let input = { 'RESUSER': RESUSER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<FavoriteDrug.GetFavoriteDrugs_Class>>(url, input);
        return result;
    }
    public static async GetFavoriteDrugsWithResUser(RESUSER: Guid, inheldStatus: boolean, drugIngredients: Array<DrugIngredient>): Promise<Array<DrugInfo>> {
        let url: string = '/api/FavoriteDrugService/GetFavoriteDrugsWithResUser';
        let input = { 'RESUSER': RESUSER, 'inheldStatus': inheldStatus , 'drugIngredients': drugIngredients};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugInfo>>(url, input);
        return result;
    }
}