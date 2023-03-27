//$68AD2744
import { MaterialPrice } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class MaterialPriceService {
    public static async MaterialPriceNQL(injectionSQL: string): Promise<Array<MaterialPrice.MaterialPriceNQL_Class>> {
        let url: string = '/api/MaterialPriceService/MaterialPriceNQL';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MaterialPrice.MaterialPriceNQL_Class>>(url, input);
        return result;
    }
    public static async GetMaterialPriceBySPTSPricingDetailID(PRICINGDETAILID: number): Promise<Array<MaterialPrice>> {
        let url: string = '/api/MaterialPriceService/GetMaterialPriceBySPTSPricingDetailID';
        let input = { "PRICINGDETAILID": PRICINGDETAILID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MaterialPrice>>(url, input);
        return result;
    }
    public static async GetMaterialPriceByMaterial(MATERIAL: string): Promise<Array<MaterialPrice>> {
        let url: string = '/api/MaterialPriceService/GetMaterialPriceByMaterial';
        let input = { "MATERIAL": MATERIAL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MaterialPrice>>(url, input);
        return result;
    }
    public static async MaterialPriceByMaterialAndPriceList(PRICELIST: string, MATERIALOBJECTID: string): Promise<Array<MaterialPrice.MaterialPriceByMaterialAndPriceList_Class>> {
        let url: string = '/api/MaterialPriceService/MaterialPriceByMaterialAndPriceList';
        let input = { "PRICELIST": PRICELIST, "MATERIALOBJECTID": MATERIALOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MaterialPrice.MaterialPriceByMaterialAndPriceList_Class>>(url, input);
        return result;
    }
    public static async MaterialPriceByMaterialForDefinition(MATERIALOBJECTID: string): Promise<Array<MaterialPrice.MaterialPriceByMaterialForDefinition_Class>> {
        let url: string = '/api/MaterialPriceService/MaterialPriceByMaterialForDefinition';
        let input = { "MATERIALOBJECTID": MATERIALOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MaterialPrice.MaterialPriceByMaterialForDefinition_Class>>(url, input);
        return result;
    }
    public static async GetMaterialPriceByLastUpdateDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<MaterialPrice>> {
        let url: string = '/api/MaterialPriceService/GetMaterialPriceByLastUpdateDate';
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MaterialPrice>>(url, input);
        return result;
    }
    public static async MaterialPriceForCostBenefit(MATERIALOBJECTID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<MaterialPrice.MaterialPriceForCostBenefit_Class>> {
        let url: string = '/api/MaterialPriceService/MaterialPriceForCostBenefit';
        let input = { "MATERIALOBJECTID": MATERIALOBJECTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MaterialPrice.MaterialPriceForCostBenefit_Class>>(url, input);
        return result;
    }
    public static async MaterialPriceByMaterial(MATERIALOBJECTID: string): Promise<Array<MaterialPrice.MaterialPriceByMaterial_Class>> {
        let url: string = '/api/MaterialPriceService/MaterialPriceByMaterial';
        let input = { "MATERIALOBJECTID": MATERIALOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MaterialPrice.MaterialPriceByMaterial_Class>>(url, input);
        return result;
    }
    public static async MaterialPriceForMedicalProcess(DATE: Date, MATERIALOBJECTID: string): Promise<Array<MaterialPrice.MaterialPriceForMedicalProcess_Class>> {
        let url: string = '/api/MaterialPriceService/MaterialPriceForMedicalProcess';
        let input = { "DATE": DATE, "MATERIALOBJECTID": MATERIALOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MaterialPrice.MaterialPriceForMedicalProcess_Class>>(url, input);
        return result;
    }
}