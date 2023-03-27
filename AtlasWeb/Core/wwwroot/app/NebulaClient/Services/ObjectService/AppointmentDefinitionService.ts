//$6E94921A
import { AppointmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentDefinitionEnum } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class AppointmentDefinitionService {
    public static async GetAppointmentDefinition(injectionSQL: string): Promise<Array<AppointmentDefinition.GetAppointmentDefinition_Class>> {
        let url: string = "/api/AppointmentDefinitionService/GetAppointmentDefinition";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AppointmentDefinition.GetAppointmentDefinition_Class>>(url, input);
        return result;
    }
    public static async GetAppointmentDefinitionByName(APPOINTMENTDEFNAME: AppointmentDefinitionEnum): Promise<Array<AppointmentDefinition>> {
        let url: string = "/api/AppointmentDefinitionService/GetAppointmentDefinitionByName";
        let input = { "APPOINTMENTDEFNAME": APPOINTMENTDEFNAME };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AppointmentDefinition>>(url, input);
        return result;
    }
    public static async GetAllAppointmentDefinitions(): Promise<Array<AppointmentDefinition>> {
        let url: string = "/api/AppointmentDefinitionService/GetAllAppointmentDefinitions";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AppointmentDefinition>>(url, input);
        return result;
    }
    public static async GetAdmissionAppointmentDefinitions(): Promise<Array<AppointmentDefinition>> {
        let url: string = "/api/AppointmentDefinitionService/GetAdmissionAppointmentDefinitions";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AppointmentDefinition>>(url, input);
        return result;
    }
}