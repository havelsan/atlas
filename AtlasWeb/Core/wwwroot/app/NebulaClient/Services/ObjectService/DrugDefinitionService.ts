//$CFBD74D2
import { DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class DrugDefinitionService {
    public static async GetDrugsHavingEquivalentReportQuery(): Promise<Array<DrugDefinition.GetDrugsHavingEquivalentReportQuery_Class>> {
        let url: string = "/api/DrugDefinitionService/GetDrugsHavingEquivalentReportQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetDrugsHavingEquivalentReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugDefinitionBySPTSGroupID(GROUPID: number): Promise<Array<DrugDefinition>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefinitionBySPTSGroupID";
        let input = { "GROUPID": GROUPID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition>>(url, input);
        return result;
    }
    public static async GetDrugNonDependBarcodeReportQuery(): Promise<Array<DrugDefinition.GetDrugNonDependBarcodeReportQuery_Class>> {
        let url: string = "/api/DrugDefinitionService/GetDrugNonDependBarcodeReportQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetDrugNonDependBarcodeReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetPharmacyStoreInheldReportQuery(): Promise<Array<DrugDefinition.GetPharmacyStoreInheldReportQuery_Class>> {
        let url: string = "/api/DrugDefinitionService/GetPharmacyStoreInheldReportQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetPharmacyStoreInheldReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugDefinitionByEquivalentCRC(EQUIVALENTCRC: string): Promise<Array<DrugDefinition>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefinitionByEquivalentCRC";
        let input = { "EQUIVALENTCRC": EQUIVALENTCRC };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition>>(url, input);
        return result;
    }
    public static async GetDrugsHavingNoEquivalentReportQuery(): Promise<Array<DrugDefinition.GetDrugsHavingNoEquivalentReportQuery_Class>> {
        let url: string = "/api/DrugDefinitionService/GetDrugsHavingNoEquivalentReportQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetDrugsHavingNoEquivalentReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugListVademecumReportQuery(): Promise<Array<DrugDefinition.GetDrugListVademecumReportQuery_Class>> {
        let url: string = "/api/DrugDefinitionService/GetDrugListVademecumReportQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetDrugListVademecumReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugDefinitions(injectionSQL: string): Promise<Array<DrugDefinition.GetDrugDefinitions_Class>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefinitions";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetDrugDefinitions_Class>>(url, input);
        return result;
    }
    public static async GetAllVademecumDrugs(): Promise<Array<DrugDefinition.GetAllVademecumDrugs_Class>> {
        let url: string = "/api/DrugDefinitionService/GetAllVademecumDrugs";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetAllVademecumDrugs_Class>>(url, input);
        return result;
    }
    public static async GetDrugDefinitionbyLastupdateDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<DrugDefinition>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefinitionbyLastupdateDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition>>(url, input);
        return result;
    }
    public static async GetDrugByVademecumProductID(PRODUCTID: number): Promise<Array<DrugDefinition.GetDrugByVademecumProductID_Class>> {
        let url: string = "/api/DrugDefinitionService/GetDrugByVademecumProductID";
        let input = { "PRODUCTID": PRODUCTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetDrugByVademecumProductID_Class>>(url, input);
        return result;
    }
    public static async GetDrugDefinitionHasSPTSGroupID(injectionSQL: string): Promise<Array<DrugDefinition>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefinitionHasSPTSGroupID";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition>>(url, input);
        return result;
    }
    public static async GetDrugDefinitionByEquivalentReportQuery(EQUIVALENTCRC: string): Promise<Array<DrugDefinition.GetDrugDefinitionByEquivalentReportQuery_Class>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefinitionByEquivalentReportQuery";
        let input = { "EQUIVALENTCRC": EQUIVALENTCRC };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetDrugDefinitionByEquivalentReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDrugDefinitionHasSPTSDRUGID(injectionSQL: string): Promise<Array<DrugDefinition>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefinitionHasSPTSDRUGID";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition>>(url, input);
        return result;
    }
    public static async GetDrugDefinition(injectionSQL: string): Promise<Array<DrugDefinition>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition>>(url, input);
        return result;
    }
    public static async GetDrugDefByEtkinMaddeKodu(ETKINMADDEKODU: string): Promise<Array<DrugDefinition.GetDrugDefByEtkinMaddeKodu_Class>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefByEtkinMaddeKodu";
        let input = { "ETKINMADDEKODU": ETKINMADDEKODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition.GetDrugDefByEtkinMaddeKodu_Class>>(url, input);
        return result;
    }
    public static async GetDrugDefinitionByEtkinMaddeKodu(ETKINMADDEKODU: string): Promise<Array<DrugDefinition>> {
        let url: string = "/api/DrugDefinitionService/GetDrugDefinitionByEtkinMaddeKodu";
        let input = { "ETKINMADDEKODU": ETKINMADDEKODU };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugDefinition>>(url, input);
        return result;
    }
}