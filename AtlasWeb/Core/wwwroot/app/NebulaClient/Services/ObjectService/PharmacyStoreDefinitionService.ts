//$1AA10347
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { PharmacyStoreDefinition, Store } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class PharmacyStoreDefinitionService {
    public static async GetInpatientPharmacyStore(): Promise<Array<PharmacyStoreDefinition>> {
        let url: string = "/api/PharmacyStoreDefinitionService/GetInpatientPharmacyStore";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PharmacyStoreDefinition>>(url, input);
        return result;
    }
    public static async GetPharmacyStores(): Promise<Array<PharmacyStoreDefinition>> {
        let url: string = "/api/PharmacyStoreDefinitionService/GetPharmacyStores";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PharmacyStoreDefinition>>(url, input);
        return result;
    }
    public static async GetPharmacyStore(injectionSQL: string): Promise<Array<PharmacyStoreDefinition.GetPharmacyStore_Class>> {
        let url: string = "/api/PharmacyStoreDefinitionService/GetPharmacyStore";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PharmacyStoreDefinition.GetPharmacyStore_Class>>(url, input);
        return result;
    }
    public static async GetOutpatientPharmacyStore(): Promise<Array<PharmacyStoreDefinition>> {
        let url: string = "/api/PharmacyStoreDefinitionService/GetOutpatientPharmacyStore";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PharmacyStoreDefinition>>(url, input);
        return result;
    }
    public static async GetPharmacyByUnitStore(UNITSTORE: Guid): Promise<Array<PharmacyStoreDefinition>> {
        let url: string = "/api/PharmacyStoreDefinitionService/GetPharmacyByUnitStore";
        let input = { "UNITSTORE": UNITSTORE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PharmacyStoreDefinition>>(url, input);
        return result;
    }

    public static async GetPharmacy(): Promise<Store> {
        let url: string = "/api/PharmacyStoreDefinitionService/GetPharmacy";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Store>(url, input);
        return result;
    }
}