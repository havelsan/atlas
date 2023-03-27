//$36070523
import { DailyDrugPatient } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugPatientOrderDet } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugSchOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DailyDrugSchOrder } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugUnDrug } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugUnDrugDet } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class DailyDrugScheduleService {

    public static async PrapareDailyDrugPatient(storeID: Guid, startDate: Date, endDate: Date, PatientObjectID: Guid): Promise<PrepareDrugDetail_Output> {
        let url: string = '/api/DailyDrugScheduleService/PrapareDailyDrugPatient';
        let input = { 'storeID': storeID, 'startDate': startDate, 'endDate': endDate, 'PatientObjectID': PatientObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<PrepareDrugDetail_Output>(url, input);
        return result;
    }

    public static async PrepareDrugDetail(dailyDrugPatient: DailyDrugPatient, startDate: Date, endDate: Date,
        dailyDrugPatientOrderDets: Array<DailyDrugPatientOrderDet>): Promise<PrepareDrugDetail_Output> {
        let url: string = '/api/DailyDrugScheduleService/PrepareDrugDetail';
        let input = { 'dailyDrugPatient': dailyDrugPatient, 'startDate': startDate, 'endDate': endDate, 'dailyDrugPatientOrderDets': dailyDrugPatientOrderDets };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<PrepareDrugDetail_Output>(url, input);
        return result;
    }
}

export class PrepareDrugDetail_Output {
    @Type(() => DailyDrugSchOrder)
    public dailyDrugSchOrders: Array<DailyDrugSchOrder>;
    @Type(() => DailyDrugUnDrug)
    public dailyDrugUnDrugs: Array<DailyDrugUnDrug>;
    @Type(() => DailyDrugSchOrderDetail)
    public dailyDrugSchOrderDetails: Array<DailyDrugSchOrderDetail>;
    @Type(() => DailyDrugUnDrugDet)
    public dailyDrugUnDrugDets: Array<DailyDrugUnDrugDet>;
    @Type(() => DailyDrugPatient)
    public dailyDrugPatients: Array<DailyDrugPatient>;
    public details: Array<PrepareDrugDetail_Output_Detail>;
    public udDrugDetails: Array<PrepareUnDrugDetail_Output_Detail>;
}

export class DailyDrugPatientDVO {
    public dailyDrugPatient: DailyDrugPatient;
    public dailyDrugPatientOrderDets: Array<DailyDrugPatientOrderDet>;
}
export class PrapareDailyDrugPatient_Output {
    public dailyDrugPatientDVOs: Array<DailyDrugPatientDVO>;
}

export class PrepareDrugDetail_Output_Detail {
    public PatientName: string;
    public DrugName: string;
    public Amount: number;
    public IsNarcotic: boolean;
    public IsPsychotropic: boolean;
    @Type(() => DailyDrugSchOrder)
    public dailyDrugSchOrder: DailyDrugSchOrder;
    @Type(() => DailyDrugSchOrderDetail)
    public dailyDrugSchOrderDetails: Array<DailyDrugSchOrderDetail>;
}
export class PrepareUnDrugDetail_Output_Detail {
    public PatientName: string;
    public DrugName: string;
    public Amount: number;
}

