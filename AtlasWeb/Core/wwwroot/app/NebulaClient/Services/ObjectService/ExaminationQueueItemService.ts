//$51BBE9A1
import { ExaminationQueueItem } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class ExaminationQueueItemService {
    public static async GetCalledQueueItems(examinationQueueDefinitions: Array<Guid>): Promise<string> {
        let url: string = "/api/ExaminationQueueItemService/GetCalledQueueItems";
        let input = { "examinationQueueDefinitions": examinationQueueDefinitions };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetNextItemsByQueueByDate(QUEUEDEF: Guid, QUEUESTARTDATE: Date, DOCTORS: Array<Guid>, QUEUEENDDATE: Date): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetNextItemsByQueueByDate";
        let input = { "QUEUEDEF": QUEUEDEF, "QUEUESTARTDATE": QUEUESTARTDATE, "DOCTORS": DOCTORS, "QUEUEENDDATE": QUEUEENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetCalledItems(QUEUEDEF: Array<Guid>, QUEUEENDDATE: Date, QUEUESTARTDATE: Date): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetCalledItems";
        let input = { "QUEUEDEF": QUEUEDEF, "QUEUEENDDATE": QUEUEENDDATE, "QUEUESTARTDATE": QUEUESTARTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetDeletableItems(DUEDATE: Date): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetDeletableItems";
        let input = { "DUEDATE": DUEDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetActiveExaminationItems(STARTDATE: Date, ENDDATE: Date, EXAMINATIONQUEUEDEFINITION: Array<string>): Promise<Array<ExaminationQueueItem.GetActiveExaminationItems_Class>> {
        let url: string = "/api/ExaminationQueueItemService/GetActiveExaminationItems";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "EXAMINATIONQUEUEDEFINITION": EXAMINATIONQUEUEDEFINITION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem.GetActiveExaminationItems_Class>>(url, input);
        return result;
    }
    public static async GetActiveQueueItemsByQueueByDate(DOCTORS: Array<Guid>, QUEUEDEF: Guid, QUEUEENDDATE: Date, QUEUESTARTDATE: Date): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetActiveQueueItemsByQueueByDate";
        let input = { "DOCTORS": DOCTORS, "QUEUEDEF": QUEUEDEF, "QUEUEENDDATE": QUEUEENDDATE, "QUEUESTARTDATE": QUEUESTARTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetByEpisodeAction(EPISODEACTION: Guid): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetByEpisodeAction";
        let input = { "EPISODEACTION": EPISODEACTION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetQueueItems(QUEUEDEF: Guid, QUEUESTARTDATE: Date, QUEUEENDDATE: Date): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetQueueItems";
        let input = { "QUEUEDEF": QUEUEDEF, "QUEUESTARTDATE": QUEUESTARTDATE, "QUEUEENDDATE": QUEUEENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetPatientQueueItems(QUEUESTARTDATE: Date, QUEUEENDDATE: Date, PATIENT: Guid): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetPatientQueueItems";
        let input = { "QUEUESTARTDATE": QUEUESTARTDATE, "QUEUEENDDATE": QUEUEENDDATE, "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetByAppointment(APPOINTMENT: Guid): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetByAppointment";
        let input = { "APPOINTMENT": APPOINTMENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetActiveQueueItemsOfPatientByQueueByDate(DOCTORS: Array<Guid>, QUEUEDEF: Guid, QUEUEENDDATE: Date, QUEUESTARTDATE: Date, PATIENT: Guid): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetActiveQueueItemsOfPatientByQueueByDate";
        let input = { "DOCTORS": DOCTORS, "QUEUEDEF": QUEUEDEF, "QUEUEENDDATE": QUEUEENDDATE, "QUEUESTARTDATE": QUEUESTARTDATE, "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetBySubactionProcedureFlowable(SUBACTIONPROCEDUREFLOWABLE: Guid): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetBySubactionProcedureFlowable";
        let input = { "SUBACTIONPROCEDUREFLOWABLE": SUBACTIONPROCEDUREFLOWABLE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetCompletedExaminationQueueItemsGroupedByDoctors(ENDDATE: Date, STARTDATE: Date, EXAMINATIONQUEUEDEFINITION: Array<Guid>): Promise<Array<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class>> {
        let url: string = "/api/ExaminationQueueItemService/GetCompletedExaminationQueueItemsGroupedByDoctors";
        let input = { "ENDDATE": ENDDATE, "STARTDATE": STARTDATE, "EXAMINATIONQUEUEDEFINITION": EXAMINATIONQUEUEDEFINITION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class>>(url, input);
        return result;
    }
    public static async GetCompletedItemsByQueueAndDate(QUEUEDEF: Guid, QUEUESTARTDATE: Date, QUEUEENDDATE: Date): Promise<Array<ExaminationQueueItem>> {
        let url: string = "/api/ExaminationQueueItemService/GetCompletedItemsByQueueAndDate";
        let input = { "QUEUEDEF": QUEUEDEF, "QUEUESTARTDATE": QUEUESTARTDATE, "QUEUEENDDATE": QUEUEENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem>>(url, input);
        return result;
    }
    public static async GetActiveQueueItemsCountInQueueInDate(STARTDATE: Date, ENDDATE: Date, EXAMINATIONQUEUEDEFINITION: string): Promise<Array<ExaminationQueueItem.GetActiveQueueItemsCountInQueueInDate_Class>> {
        let url: string = "/api/ExaminationQueueItemService/GetActiveQueueItemsCountInQueueInDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "EXAMINATIONQUEUEDEFINITION": EXAMINATIONQUEUEDEFINITION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem.GetActiveQueueItemsCountInQueueInDate_Class>>(url, input);
        return result;
    }
    public static async GetCompletedItemsGroupedByCompletedBy(STARTDATE: Date, ENDDATE: Date, EXAMINATIONQUEUEDEFINITION: Array<Guid>): Promise<Array<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class>> {
        let url: string = "/api/ExaminationQueueItemService/GetCompletedItemsGroupedByCompletedBy";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "EXAMINATIONQUEUEDEFINITION": EXAMINATIONQUEUEDEFINITION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class>>(url, input);
        return result;
    }
    public static async GetCompletedExaminationQueueItems(STARTDATE: Date, ENDDATE: Date, EXAMINATIONQUEUEDEFINITION: string): Promise<Array<ExaminationQueueItem.GetCompletedExaminationQueueItems_Class>> {
        let url: string = "/api/ExaminationQueueItemService/GetCompletedExaminationQueueItems";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "EXAMINATIONQUEUEDEFINITION": EXAMINATIONQUEUEDEFINITION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem.GetCompletedExaminationQueueItems_Class>>(url, input);
        return result;
    }
    public static async GetCompletedItemsGroupedByCompletedByAndDate(STARTDATE: Date, ENDDATE: Date, EXAMINATIONQUEUEDEFINITION: Array<Guid>): Promise<Array<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate_Class>> {
        let url: string = "/api/ExaminationQueueItemService/GetCompletedItemsGroupedByCompletedByAndDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "EXAMINATIONQUEUEDEFINITION": EXAMINATIONQUEUEDEFINITION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate_Class>>(url, input);
        return result;
    }
}