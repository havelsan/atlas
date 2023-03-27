//$D4E5945D
import { StockAction } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { NeHttpService } from "Fw/Services/NeHttpService";

export class StockActionService {
    public static async GetStockActionsCount(STARRTDATE: Date, ENDDATE: Date): Promise<Array<StockAction.GetStockActionsCount_Class>> {
        let url: string = "/api/StockActionService/GetStockActionsCount";
        let getStockActionsCount_Input = { "STARTDATE": STARRTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post(url, getStockActionsCount_Input);
        return result as Array<StockAction.GetStockActionsCount_Class>;
    }
    public static async GetInPatientPhysicianApplication_Info(INPATIENTPHYSICIANAPPOBJID: string): Promise<InPatientPhysicianApplication_Output> {
        let url: string = "/api/StockActionService/GetInPatientPhysicianApplication_Info";
        let InPatientPhysicianApplication_Input = { "INPATIENTPHYSICIANAPPOBJID": INPATIENTPHYSICIANAPPOBJID};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post(url, InPatientPhysicianApplication_Input);
        return result as InPatientPhysicianApplication_Output;
    }
    public static async GetInPatientPhysicianApplication_InfoByEpisode(EPISODEID: string): Promise<InPatientPhysicianApplication_Output> {
        let url: string = "/api/StockActionService/GetInPatientPhysicianApplication_InfoByEpisode";
        let EpisodeID_Input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post(url, EpisodeID_Input);
        return result as InPatientPhysicianApplication_Output;
    }
}
export class InPatientPhysicianApplication_Output {
    public clinicProtocolNo: string;
    public clinicName: string;
    public clinicRoom: string;
    public clinicBed: string;
    public clinicDischargeDate: Date;
}