//$CD7701C3
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class ResBedService {
    public static async GetEmptyBeds(): Promise<Array<ResBed.GetEmptyBeds_Class>> {
        let url: string = "/api/ResBedService/GetEmptyBeds";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetEmptyBeds_Class>>(url, input);
        return result;
    }
    public static async GetWithNullUsedByAndRoom(ROOM: string): Promise<Array<ResBed>> {
        let url: string = "/api/ResBedService/GetWithNullUsedByAndRoom";
        let input = { "ROOM": ROOM };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed>>(url, input);
        return result;
    }
    public static async GetWithNullUsedByAndRoomGroup(ROOMGROUP: string): Promise<Array<ResBed>> {
        let url: string = "/api/ResBedService/GetWithNullUsedByAndRoomGroup";
        let input = { "ROOMGROUP": ROOMGROUP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed>>(url, input);
        return result;
    }
    public static async OLAP_GetUsedByRelation(): Promise<Array<ResBed.OLAP_GetUsedByRelation_Class>> {
        let url: string = "/api/ResBedService/OLAP_GetUsedByRelation";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.OLAP_GetUsedByRelation_Class>>(url, input);
        return result;
    }
    public static async GetEmptyBedsByClinic(WARD: string): Promise<Array<ResBed.GetEmptyBedsByClinic_Class>> {
        let url: string = "/api/ResBedService/GetEmptyBedsByClinic";
        let input = { "WARD": WARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetEmptyBedsByClinic_Class>>(url, input);
        return result;
    }
    public static async GetWithNullUsedByAndClinic(WARD: string): Promise<Array<ResBed>> {
        let url: string = "/api/ResBedService/GetWithNullUsedByAndClinic";
        let input = { "WARD": WARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed>>(url, input);
        return result;
    }
    public static async GetBedDefinition(injectionSQL: string): Promise<Array<ResBed.GetBedDefinition_Class>> {
        let url: string = "/api/ResBedService/GetBedDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetBedDefinition_Class>>(url, input);
        return result;
    }
    public static async GetEmptyBedsWithoutIntensiveCare(): Promise<Array<ResBed.GetEmptyBedsWithoutIntensiveCare_Class>> {
        let url: string = "/api/ResBedService/GetEmptyBedsWithoutIntensiveCare";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetEmptyBedsWithoutIntensiveCare_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetResBed(): Promise<Array<ResBed.OLAP_GetResBed_Class>> {
        let url: string = "/api/ResBedService/OLAP_GetResBed";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.OLAP_GetResBed_Class>>(url, input);
        return result;
    }
    public static async GetWithNullUsedBy(): Promise<Array<ResBed>> {
        let url: string = "/api/ResBedService/GetWithNullUsedBy";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed>>(url, input);
        return result;
    }
    public static async GetEmptyBedCountByClinic(WARD: Guid): Promise<Array<ResBed.GetEmptyBedCountByClinic_Class>> {
        let url: string = "/api/ResBedService/GetEmptyBedCountByClinic";
        let input = { "WARD": WARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetEmptyBedCountByClinic_Class>>(url, input);
        return result;
    }
    public static async GetBedCountByClinic(WARD: Guid): Promise<Array<ResBed.GetBedCountByClinic_Class>> {
        let url: string = "/api/ResBedService/GetBedCountByClinic";
        let input = { "WARD": WARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetBedCountByClinic_Class>>(url, input);
        return result;
    }
    public static async GetUsedBedCount(): Promise<Array<ResBed.GetUsedBedCount_Class>> {
        let url: string = "/api/ResBedService/GetUsedBedCount";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetUsedBedCount_Class>>(url, input);
        return result;
    }
    public static async GetBedsByClinic(WARD: Guid): Promise<Array<ResBed.GetBedsByClinic_Class>> {
        let url: string = "/api/ResBedService/GetBedsByClinic";
        let input = { "WARD": WARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetBedsByClinic_Class>>(url, input);
        return result;
    }
    public static async GetEmptyBedCount(): Promise<Array<ResBed.GetEmptyBedCount_Class>> {
        let url: string = "/api/ResBedService/GetEmptyBedCount";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetEmptyBedCount_Class>>(url, input);
        return result;
    }
    public static async GetBedsPropertysByResWard(ONLYEMPTY: boolean, SELECTEDWARD: Guid): Promise<Array<ResBed.GetBedsPropertysByResWard_Class>> {
        let url: string = "/api/ResBedService/GetBedsPropertysByResWard";
        let input = { "ONLYEMPTY": ONLYEMPTY, "SELECTEDWARD": SELECTEDWARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetBedsPropertysByResWard_Class>>(url, input);
        return result;
    }
    public static async OLAP_NewBedQuery(): Promise<Array<ResBed.OLAP_NewBedQuery_Class>> {
        let url: string = "/api/ResBedService/OLAP_NewBedQuery";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.OLAP_NewBedQuery_Class>>(url, input);
        return result;
    }
    public static async GetAllClinicsEmptybedCounts(): Promise<Array<ResBed.GetAllClinicsEmptybedCounts_Class>> {
        let url: string = "/api/ResBedService/GetAllClinicsEmptybedCounts";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetAllClinicsEmptybedCounts_Class>>(url, input);
        return result;
    }
    public static async GetAllClinicsBeds(): Promise<Array<ResBed.GetAllClinicsBeds_Class>> {
        let url: string = "/api/ResBedService/GetAllClinicsBeds";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetAllClinicsBeds_Class>>(url, input);
        return result;
    }
    public static async GetEmptyBedsWithVentilator(): Promise<Array<ResBed.GetEmptyBedsWithVentilator_Class>> {
        let url: string = "/api/ResBedService/GetEmptyBedsWithVentilator";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetEmptyBedsWithVentilator_Class>>(url, input);
        return result;
    }
    public static async GetAllBedsWithVentilator(): Promise<Array<ResBed.GetAllBedsWithVentilator_Class>> {
        let url: string = "/api/ResBedService/GetAllBedsWithVentilator";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetAllBedsWithVentilator_Class>>(url, input);
        return result;
    }
    public static async GetAllBedsKuvez(): Promise<Array<ResBed.GetAllBedsKuvez_Class>> {
        let url: string = "/api/ResBedService/GetAllBedsKuvez";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetAllBedsKuvez_Class>>(url, input);
        return result;
    }
    public static async GetEmptyBedsKuvez(): Promise<Array<ResBed.GetEmptyBedsKuvez_Class>> {
        let url: string = "/api/ResBedService/GetEmptyBedsKuvez";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetEmptyBedsKuvez_Class>>(url, input);
        return result;
    }
    public static async GetAllResBeds(): Promise<Array<ResBed.GetAllResBeds_Class>> {
        let url: string = "/api/ResBedService/GetAllResBeds";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetAllResBeds_Class>>(url, input);
        return result;
    }
    public static async GetBedDef(injectionSQL: string): Promise<Array<ResBed.GetBedDef_Class>> {
        let url: string = "/api/ResBedService/GetBedDef";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetBedDef_Class>>(url, input);
        return result;
    }
    public static async GetAllResBedByResWard(SELECTEDWARD: Guid): Promise<Array<ResBed.GetAllResBedByResWard_Class>> {
        let url: string = "/api/ResBedService/GetAllResBedByResWard";
        let input = { "SELECTEDWARD": SELECTEDWARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetAllResBedByResWard_Class>>(url, input);
        return result;
    }
    public static async GetEmptyBedsByResWard(SELECTEDWARD: Guid): Promise<Array<ResBed.GetEmptyBedsByResWard_Class>> {
        let url: string = "/api/ResBedService/GetEmptyBedsByResWard";
        let input = { "SELECTEDWARD": SELECTEDWARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetEmptyBedsByResWard_Class>>(url, input);
        return result;
    }
    public static async GetUsedBedsByClinic(WARD: Guid): Promise<Array<ResBed>> {
        let url: string = "/api/ResBedService/GetUsedBedsByClinic";
        let input = { "WARD": WARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed>>(url, input);
        return result;
    }
    public static async GetAllWardsEmptyBedCounts(): Promise<Array<ResBed.GetAllWardsEmptyBedCounts_Class>> {
        let url: string = "/api/ResBedService/GetAllWardsEmptyBedCounts";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetAllWardsEmptyBedCounts_Class>>(url, input);
        return result;
    }
    public static async VEM_YATAK(): Promise<Array<ResBed.VEM_YATAK_Class>> {
        let url: string = "/api/ResBedService/VEM_YATAK";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.VEM_YATAK_Class>>(url, input);
        return result;
    }
    public static async GetResWardListWithEmtyBedCount(): Promise<Array<ResBed.GetResWardListWithEmtyBedCount_Class>> {
        let url: string = "/api/ResBedService/GetResWardListWithEmtyBedCount";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResBed.GetResWardListWithEmtyBedCount_Class>>(url, input);
        return result;
    }
}