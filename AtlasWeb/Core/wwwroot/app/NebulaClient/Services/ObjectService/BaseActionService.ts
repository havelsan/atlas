//$D74176DA
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { BaseAction } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class BaseActionService {
    public static async GetMyNewAppointments(baseAction: BaseAction): Promise<Array<Appointment>> {
        let url: string = "/api/BaseActionService/GetMyNewAppointments";
        let input = { "baseAction": baseAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async GetFullAppointmentDescription(baseAction: BaseAction): Promise<string> {
        let url: string = "/api/BaseActionService/GetFullAppointmentDescription";
        let input = { "baseAction": baseAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetFullCompletedAppointmentDescription(baseAction: BaseAction): Promise<string> {
        let url: string = "/api/BaseActionService/GetFullCompletedAppointmentDescription";
        let input = { "baseAction": baseAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetByFilterExpression(injectionSQL: string): Promise<Array<BaseAction>> {
        let url: string = "/api/BaseActionService/GetByFilterExpression";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseAction>>(url, input);
        return result;
    }
    public static async GetByBaseActionWorklistDate(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<BaseAction>> {
        let url: string = "/api/BaseActionService/GetByBaseActionWorklistDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseAction>>(url, input);
        return result;
    }
    public static async GetByWLFilterExpression(injectionSQL: string): Promise<Array<BaseAction>> {
        let url: string = "/api/BaseActionService/GetByWLFilterExpression";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseAction>>(url, input);
        return result;
    }
    public static async GetAppointmentActions(MASTERRESOURCE: Guid, STARTDATE: Date, ENDDATE: Date): Promise<Array<BaseAction.GetAppointmentActions_Class>> {
        let url: string = "/api/BaseActionService/GetAppointmentActions";
        let input = { "MASTERRESOURCE": MASTERRESOURCE, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<BaseAction.GetAppointmentActions_Class>>(url, input);
        return result;
    }
}