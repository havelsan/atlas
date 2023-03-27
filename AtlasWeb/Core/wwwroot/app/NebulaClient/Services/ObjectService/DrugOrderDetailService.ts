//$A32EB333
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Type } from 'NebulaClient/ClassTransformer';

export class DrugOrderDetailService {
    public static async GetDrugOrderDetails(STARTDATE: Date, ENDDATE: Date, RESOURCE: Guid): Promise<Array<DrugOrderDetail>> {
        let url: string = '/api/DrugOrderDetailService/GetDrugOrderDetails';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'RESOURCE': RESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderDetail>>(url, input);
        return result;
    }
    public static async GetSequenceOrderPlanedDates(DRUGORDER: string): Promise<Array<DrugOrderDetail>> {
        let url: string = '/api/DrugOrderDetailService/GetSequenceOrderPlanedDates';
        let input = { 'DRUGORDER': DRUGORDER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderDetail>>(url, input);
        return result;
    }
    public static async GetDrugOrderDetailsByDrug(DRUGID: Guid, EPISODEID: Guid): Promise<Array<DrugOrderDetail>> {
        let url: string = '/api/DrugOrderDetailService/GetDrugOrderDetailsByDrug';
        let input = { 'DRUGID': DRUGID, 'EPISODEID': EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderDetail>>(url, input);
        return result;
    }
    public static async GetOrderPlannedDates(EPISODE: string): Promise<Array<DrugOrderDetail>> {
        let url: string = '/api/DrugOrderDetailService/GetOrderPlannedDates';
        let input = { 'EPISODE': EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderDetail>>(url, input);
        return result;
    }
    public static async DrugOrderDetailListNQL(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<DrugOrderDetail>> {
        let url: string = '/api/DrugOrderDetailService/DrugOrderDetailListNQL';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'injectionSQL': injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderDetail>>(url, input);
        return result;
    }
    public static async GetDrugOrderDetailsForDaily(STARTDATE: Date, ENDDATE: Date, RESOURCE: Guid): Promise<Array<DrugOrderDetail>> {
        let url: string = '/api/DrugOrderDetailService/GetDrugOrderDetailsForDaily';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'RESOURCE': RESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderDetail>>(url, input);
        return result;
    }
    public static async DrugOrderDetailListReportNQL(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<DrugOrderDetail.DrugOrderDetailListReportNQL_Class>> {
        let url: string = '/api/DrugOrderDetailService/DrugOrderDetailListReportNQL';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'injectionSQL': injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderDetail.DrugOrderDetailListReportNQL_Class>>(url, input);
        return result;
    }
    public static async GetDrugOrderDetailsByDrugOrder(DRUGORDER: Guid, STARTDATE: Date, ENDDATE: Date): Promise<Array<DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class>> {
        let url: string = '/api/DrugOrderDetailService/GetDrugOrderDetailsByDrugOrder';
        let input = { 'DRUGORDER': DRUGORDER, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class>>(url, input);
        return result;
    }
    /*  public static async GetActiveDrugOrderDetail(STARTDATE: Date, ENDDATE: Date, NURSINGAPPLICATION: Guid, injectionSQL: string): Promise<Array<DrugOrderDetail.GetActiveDrugOrderDetail_Class>> {
          let url: string = "/api/DrugOrderDetailService/GetActiveDrugOrderDetail";
          let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "NURSINGAPPLICATION": NURSINGAPPLICATION, "injectionSQL": injectionSQL };
          let httpService: NeHttpService = ServiceLocator.NeHttpService;
          let result = await httpService.post<Array<DrugOrderDetail.GetActiveDrugOrderDetail_Class>>(url, input);
          return result;
  }*/

    public static async GetDrugType(Material: Guid): Promise<boolean> {
        let url: string = '/api/DrugOrderDetailService/GetDrugType';
        let input = { 'Material': Material};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }

    public static async GetPatientFullNameByEpisode(input: PatientFullNameInfo_Input): Promise<PatientFullNameInfo_Output> {
        let url: string = '/api/DrugOrderDetailService/GetPatientFullNameByEpisode';
        let params = { 'Episode': input.Episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<PatientFullNameInfo_Output>(url, params);
        return result;
    }

    public static async GetExecutionUser(ObjectID): Promise<GetExecutionUser_Output> {
        let url: string = '/api/DrugOrderDetailService/GetExecutionUser';
        let params = { 'ObjectID': ObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetExecutionUser_Output>(url, params);
        return result;
    }

}

export class PatientFullNameInfo_Input {
    public Episode: string;
}
export class PatientFullNameInfo_Output {
    public FullName: string;
}
export class GetExecutionUser_Output {
    public IsCompleted: boolean;
    public FullName: string;
    @Type(() => Date)
    public ExecutionDate: Date;
}