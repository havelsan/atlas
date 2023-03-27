//$2EB63BB8
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class ResSectionService {
    public static async ConsultationRequestResourceListNql(injectionSQL: string): Promise<Array<ResSection.ConsultationRequestResourceListNql_Class>> {
        let url: string = '/api/ResSectionService/ConsultationRequestResourceListNql';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection.ConsultationRequestResourceListNql_Class>>(url, input);
        return result;
    }
    public static async EnableResSectionListNQL(injectionSQL: string): Promise<Array<ResSection.EnableResSectionListNQL_Class>> {
        let url: string = '/api/ResSectionService/EnableResSectionListNQL';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection.EnableResSectionListNQL_Class>>(url, input);
        return result;
    }
    public static async GetResSections(injectionSQL: string): Promise<Array<ResSection>> {
        let url: string = '/api/ResSectionService/GetResSections';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async GetIfHasActionCancelledTime(): Promise<Array<ResSection>> {
        let url: string = '/api/ResSectionService/GetIfHasActionCancelledTime';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async PoliclinicClinicDepartmentListNQL(injectionSQL: string): Promise<Array<ResSection.PoliclinicClinicDepartmentListNQL_Class>> {
        let url: string = '/api/ResSectionService/PoliclinicClinicDepartmentListNQL';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection.PoliclinicClinicDepartmentListNQL_Class>>(url, input);
        return result;
    }
    public static async SendToResourceListNQL(injectionSQL: string): Promise<Array<ResSection.SendToResourceListNQL_Class>> {
        let url: string = '/api/ResSectionService/SendToResourceListNQL';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection.SendToResourceListNQL_Class>>(url, input);
        return result;
    }
    public static async GetResourceOfUserBySpeciality(CURRENTUSER: Guid, INOUTPATIENT: number, SPECIALITIES: Array<string>): Promise<Array<ResSection>> {
        let url: string = '/api/ResSectionService/GetResourceOfUserBySpeciality';
        let input = { "CURRENTUSER": CURRENTUSER, "INOUTPATIENT": INOUTPATIENT, "SPECIALITIES": SPECIALITIES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async ConsultationRequestResourceList(injectionSQL: string): Promise<Array<ResSection>> {
        let url: string = '/api/ResSectionService/ConsultationRequestResourceList';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async PoliclinicClinicListNQL(injectionSQL: string): Promise<Array<ResSection.PoliclinicClinicListNQL_Class>> {
        let url: string = '/api/ResSectionService/PoliclinicClinicListNQL';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection.PoliclinicClinicListNQL_Class>>(url, input);
        return result;
    }
    public static async GetBySpeciality(SPECIALITY: Guid): Promise<Array<ResSection>> {
        let url: string = '/api/ResSectionService/GetBySpeciality';
        let input = { "SPECIALITY": SPECIALITY };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async GetAllSections(): Promise<Array<ResSection.GetAllSections_Class>> {
        let url: string = '/api/ResSectionService/GetAllSections';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection.GetAllSections_Class>>(url, input);
        return result;
    }
    public static async PoliclinicAndEmergencyListNQL(injectionSQL: string): Promise<Array<ResSection>> {
        let url: string = '/api/ResSectionService/PoliclinicAndEmergencyListNQL';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async GetPoliclinicClinicDepartment(): Promise<Array<ResSection>> {
        let url: string = '/api/ResSectionService/GetPoliclinicClinicDepartment';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async PoliclinicClinicTreatmentUnitListNQL(injectionSQL: string): Promise<Array<ResSection.PoliclinicClinicTreatmentUnitListNQL_Class>> {
        let url: string = '/api/ResSectionService/PoliclinicClinicTreatmentUnitListNQL';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection.PoliclinicClinicTreatmentUnitListNQL_Class>>(url, input);
        return result;
    }
    public static async GetDentalResources(injectionSQL: string): Promise<Array<ResSection>> {
        let url: string = '/api/ResSectionService/GetDentalResources';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async GetResourcesExceptDentalResources(injectionSQL: string): Promise<Array<ResSection>> {
        let url: string = '/api/ResSectionService/GetResourcesExceptDentalResources';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async PolClinTreatLabUnitListNql(injectionSQL: string): Promise<Array<ResSection.PolClinTreatLabUnitListNql_Class>> {
        let url: string = '/api/ResSectionService/PolClinTreatLabUnitListNql';
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection.PolClinTreatLabUnitListNql_Class>>(url, input);
        return result;
    }
}