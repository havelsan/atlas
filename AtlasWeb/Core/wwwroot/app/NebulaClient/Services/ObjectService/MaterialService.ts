//$8827B7EB
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class MaterialService {
    public static async GetVatrateFromMaterialTS(material: Material, date: Date): Promise<number> {
        let url: string = "/api/MaterialService/GetVatrateFromMaterialTS";
        let input = { "material": material, "date": date };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetStockCardListReportQuery(OBJECTID: Guid, STATUS: number): Promise<Array<Material.GetStockCardListReportQuery_Class>> {
        let url: string = "/api/MaterialService/GetStockCardListReportQuery";
        let input = { "OBJECTID": OBJECTID, "STATUS": STATUS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetStockCardListReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetMaterialDependStockCardReportQuery(): Promise<Array<Material.GetMaterialDependStockCardReportQuery_Class>> {
        let url: string = "/api/MaterialService/GetMaterialDependStockCardReportQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialDependStockCardReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetTreatmentMaterial(injectionSQL: string): Promise<Array<Material>> {
        let url: string = "/api/MaterialService/GetTreatmentMaterial";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material>>(url, input);
        return result;
    }
    public static async GetMaterialListQuery(injectionSQL: string): Promise<Array<Material.GetMaterialListQuery_Class>> {
        let url: string = "/api/MaterialService/GetMaterialListQuery";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialListQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugAndMagistrals(injectionSQL: string): Promise<Array<Material.GetDrugAndMagistrals_Class>> {
        let url: string = "/api/MaterialService/GetDrugAndMagistrals";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetDrugAndMagistrals_Class>>(url, input);
        return result;
    }
    public static async GetMaterialDetail(MATERIALOBJECTID: string): Promise<Array<Material.GetMaterialDetail_Class>> {
        let url: string = "/api/MaterialService/GetMaterialDetail";
        let input = { "MATERIALOBJECTID": MATERIALOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialDetail_Class>>(url, input);
        return result;
    }
    public static async GetMaterialPricingDetail(MATERIALOBJECTID: string): Promise<Array<Material.GetMaterialPricingDetail_Class>> {
        let url: string = "/api/MaterialService/GetMaterialPricingDetail";
        let input = { "MATERIALOBJECTID": MATERIALOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialPricingDetail_Class>>(url, input);
        return result;
    }
    public static async GetStockCardListByGroupReportQuery(): Promise<Array<Material.GetStockCardListByGroupReportQuery_Class>> {
        let url: string = "/api/MaterialService/GetStockCardListByGroupReportQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetStockCardListByGroupReportQuery_Class>>(url, input);
        return result;
    }
    public static async OLAP_Material(): Promise<Array<Material.OLAP_Material_Class>> {
        let url: string = "/api/MaterialService/OLAP_Material";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.OLAP_Material_Class>>(url, input);
        return result;
    }
    public static async GetMaterialInheldReportQuery(STOCKCARDID: string): Promise<Array<Material.GetMaterialInheldReportQuery_Class>> {
        let url: string = "/api/MaterialService/GetMaterialInheldReportQuery";
        let input = { "STOCKCARDID": STOCKCARDID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialInheldReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetMaterial(injectionSQL: string): Promise<Array<Material>> {
        let url: string = "/api/MaterialService/GetMaterial";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material>>(url, input);
        return result;
    }
    public static async GetMaterials(injectionSQL: string): Promise<Array<Material.GetMaterials_Class>> {
        let url: string = "/api/MaterialService/GetMaterials";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterials_Class>>(url, input);
        return result;
    }
    public static async GetMaterialWithNoEffectivePrice(): Promise<Array<Material.GetMaterialWithNoEffectivePrice_Class>> {
        let url: string = "/api/MaterialService/GetMaterialWithNoEffectivePrice";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialWithNoEffectivePrice_Class>>(url, input);
        return result;
    }
    public static async GetMaterialBarcodeLevelDetail(MATERIALOBJECTID: string): Promise<Array<Material.GetMaterialBarcodeLevelDetail_Class>> {
        let url: string = "/api/MaterialService/GetMaterialBarcodeLevelDetail";
        let input = { "MATERIALOBJECTID": MATERIALOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialBarcodeLevelDetail_Class>>(url, input);
        return result;
    }
    public static async GetMaterialNonDependStockCard(): Promise<Array<Material.GetMaterialNonDependStockCard_Class>> {
        let url: string = "/api/MaterialService/GetMaterialNonDependStockCard";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialNonDependStockCard_Class>>(url, input);
        return result;
    }
    public static async GetStockCardsToActReportQuery(OBJECTID: Guid, STARTDATE: Date, FINISHDATE: Date): Promise<Array<Material.GetStockCardsToActReportQuery_Class>> {
        let url: string = "/api/MaterialService/GetStockCardsToActReportQuery";
        let input = { "OBJECTID": OBJECTID, "STARTDATE": STARTDATE, "FINISHDATE": FINISHDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetStockCardsToActReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetMaterialWithoutStockCard(): Promise<Array<Material>> {
        let url: string = "/api/MaterialService/GetMaterialWithoutStockCard";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material>>(url, input);
        return result;
    }
    public static async GetMaterialsWithPrice(injectionSQL: string): Promise<Array<Material.GetMaterialsWithPrice_Class>> {
        let url: string = "/api/MaterialService/GetMaterialsWithPrice";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialsWithPrice_Class>>(url, input);
        return result;
    }
    public static async OLAP_Material_WithDate(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<Material.OLAP_Material_WithDate_Class>> {
        let url: string = "/api/MaterialService/OLAP_Material_WithDate";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.OLAP_Material_WithDate_Class>>(url, input);
        return result;
    }
    public static async GetMaterialWithMultiEffectivePriceByPriceList(PRICELIST: string): Promise<Array<Material.GetMaterialWithMultiEffectivePriceByPriceList_Class>> {
        let url: string = "/api/MaterialService/GetMaterialWithMultiEffectivePriceByPriceList";
        let input = { "PRICELIST": PRICELIST };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetMaterialWithMultiEffectivePriceByPriceList_Class>>(url, input);
        return result;
    }
    public static async GetMaterialByBarcode(BARCODE: string): Promise<Array<Material>> {
        let url: string = "/api/MaterialService/GetMaterialByBarcode";
        let input = { "BARCODE": BARCODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material>>(url, input);
        return result;
    }
    public static async GetOldMaterialListQuery(injectionSQL: string): Promise<Array<Material.GetOldMaterialListQuery_Class>> {
        let url: string = "/api/MaterialService/GetOldMaterialListQuery";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetOldMaterialListQuery_Class>>(url, input);
        return result;
    }
    public static async ProductMatchMaterialQuery(STORE: Guid, ALL: number): Promise<Array<Material.ProductMatchMaterialQuery_Class>> {
        let url: string = "/api/MaterialService/ProductMatchMaterialQuery";
        let input = { "STORE": STORE, "ALL": ALL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.ProductMatchMaterialQuery_Class>>(url, input);
        return result;
    }
    public static async ProductNotMatchMaterialQuery(): Promise<Array<Material.ProductNotMatchMaterialQuery_Class>> {
        let url: string = "/api/MaterialService/ProductNotMatchMaterialQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.ProductNotMatchMaterialQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugAndMaterialListQuery(injectionSQL: string): Promise<Array<Material.GetDrugAndMaterialListQuery_Class>> {
        let url: string = "/api/MaterialService/GetDrugAndMaterialListQuery";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetDrugAndMaterialListQuery_Class>>(url, input);
        return result;
    }
    public static async GetPrescriptionMaterialListQuery(injectionSQL: string): Promise<Array<Material.GetPrescriptionMaterialListQuery_Class>> {
        let url: string = "/api/MaterialService/GetPrescriptionMaterialListQuery";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.GetPrescriptionMaterialListQuery_Class>>(url, input);
        return result;
    }
    public static async VEM_STOK_KART(injectionSQL: string): Promise<Array<Material.VEM_STOK_KART_Class>> {
        let url: string = "/api/MaterialService/VEM_STOK_KART";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Material.VEM_STOK_KART_Class>>(url, input);
        return result;
    }
}