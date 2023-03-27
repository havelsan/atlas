//$1100B515
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Schedule } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class ScheduleService {
    public static async GetByInjection(injectionSQL: string): Promise<Array<Schedule>> {
        let url: string = "/api/ScheduleService/GetByInjection";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule>>(url, input);
        return result;
    }
    public static async GetWorkHourSchByDateAndResource(STARTTIME: Date, RESOURCE: string, APPDEF: string): Promise<Array<Schedule>> {
        let url: string = "/api/ScheduleService/GetWorkHourSchByDateAndResource";
        let input = { "STARTTIME": STARTTIME, "RESOURCE": RESOURCE, "APPDEF": APPDEF };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule>>(url, input);
        return result;
    }
    public static async GetByScheduleDateAndResource(STARTTIME: Date, ENDTIME: Date, RESOURCE: string): Promise<Array<Schedule>> {
        let url: string = "/api/ScheduleService/GetByScheduleDateAndResource";
        let input = { "STARTTIME": STARTTIME, "ENDTIME": ENDTIME, "RESOURCE": RESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule>>(url, input);
        return result;
    }
    public static async GrtScheduleByMHRSKesinCetvelID(MHRSKESINCETVELID: number): Promise<Array<Schedule>> {
        let url: string = "/api/ScheduleService/GrtScheduleByMHRSKesinCetvelID";
        let input = { "MHRSKESINCETVELID": MHRSKESINCETVELID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule>>(url, input);
        return result;
    }
    public static async GetWorkingResourcesForAsal(STARTDATE: Date, ENDDATE: Date): Promise<Array<Schedule.GetWorkingResourcesForAsal_Class>> {
        let url: string = "/api/ScheduleService/GetWorkingResourcesForAsal";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule.GetWorkingResourcesForAsal_Class>>(url, input);
        return result;
    }
    public static async GetSchedulaForMHRSTask(STARTTIME: Date, ENDTIME: Date): Promise<Array<Schedule>> {
        let url: string = "/api/ScheduleService/GetSchedulaForMHRSTask";
        let input = { "STARTTIME": STARTTIME, "ENDTIME": ENDTIME };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule>>(url, input);
        return result;
    }
    public static async GrtScheduleByMHRSTaslakID(TASLAKCETVELID: number): Promise<Array<Schedule>> {
        let url: string = "/api/ScheduleService/GrtScheduleByMHRSTaslakID";
        let input = { "TASLAKCETVELID": TASLAKCETVELID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule>>(url, input);
        return result;
    }
    public static async GetScheduleByResourceAndDate(RESOURCE: string, STARTTIME: Date, ENDTIME: Date, MASTERRESOURCE: string): Promise<Array<Schedule>> {
        let url: string = "/api/ScheduleService/GetScheduleByResourceAndDate";
        let input = { "RESOURCE": RESOURCE, "STARTTIME": STARTTIME, "ENDTIME": ENDTIME, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule>>(url, input);
        return result;
    }
    public static async GetScheduleByMHRSIstisnaID(MHRSISTISNAID: number): Promise<Array<Schedule>> {
        let url: string = "/api/ScheduleService/GetScheduleByMHRSIstisnaID";
        let input = { "MHRSISTISNAID": MHRSISTISNAID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule>>(url, input);
        return result;
    }
    public static async GetMHRSSchedules(MASTERRESOURCE: Guid, RESOURCE: Guid, STARTTIME: Date, ENDTIME: Date): Promise<Array<Schedule.GetMHRSSchedules_Class>> {
        let url: string = "/api/ScheduleService/GetMHRSSchedules";
        let input = { "MASTERRESOURCE": MASTERRESOURCE, "RESOURCE": RESOURCE, "STARTTIME": STARTTIME, "ENDTIME": ENDTIME };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule.GetMHRSSchedules_Class>>(url, input);
        return result;
    }
    public static async GetScheduleForMHRS(STARTTIME: Date, ENDTIME: Date, MASTERRESOURCE: Guid, RESOURCE: Guid): Promise<Array<Schedule>> {
        let url: string = "/api/ScheduleService/GetScheduleForMHRS";
        let input = { "STARTTIME": STARTTIME, "ENDTIME": ENDTIME, "MASTERRESOURCE": MASTERRESOURCE, "RESOURCE": RESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Schedule>>(url, input);
        return result;
    }
}