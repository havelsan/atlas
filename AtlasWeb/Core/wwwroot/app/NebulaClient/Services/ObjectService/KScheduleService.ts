//$5D4B8ABC
import { DrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { KSchedule } from 'NebulaClient/Model/AtlasClientModel';
import { KScheduleMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { DrugBarcodeInfo, HimsDrugInfo } from 'app/Barcode/Models/DrugBarcodeInfo';
import { Type } from 'NebulaClient/ClassTransformer';
import { StockActionDetailStatusEnum, KScheduleMaterialRowType } from 'NebulaClient/Model/AtlasClientModel';

export class KScheduleService {

    public static async CreateKScheduleMaterial(context: TTObjectContext, drugOrder: DrugOrder, amount: number): Promise<KScheduleMaterial> {
        let url: string = '/api/KScheduleService/CreateKScheduleMaterial';
        let input = { 'context': context, 'drugOrder': drugOrder, 'amount': amount };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<KScheduleMaterial>(url, input);
        return result;
    }
    public static async GetKScheduleDrugPrescriptionTotalReportQuery(STARTDATE: Date, ENDDATE: Date): Promise<Array<KSchedule.GetKScheduleDrugPrescriptionTotalReportQuery_Class>> {
        let url: string = '/api/KScheduleService/GetKScheduleDrugPrescriptionTotalReportQuery';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<KSchedule.GetKScheduleDrugPrescriptionTotalReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetKSchedule(STARTDATE: Date, ENDDATE: Date, STORE: string): Promise<Array<KSchedule>> {
        let url: string = '/api/KScheduleService/GetKSchedule';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'STORE': STORE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<KSchedule>>(url, input);
        return result;
    }
    public static async GetQuarantineNOForKScheduleQuery(TTOBJECTID: Guid, MATERIALID: Guid): Promise<Array<KSchedule.GetQuarantineNOForKScheduleQuery_Class>> {
        let url: string = '/api/KScheduleService/GetQuarantineNOForKScheduleQuery';
        let input = { 'TTOBJECTID': TTOBJECTID, 'MATERIALID': MATERIALID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<KSchedule.GetQuarantineNOForKScheduleQuery_Class>>(url, input);
        return result;
    }
    public static async GetQuaratineNOQuery(DATE: Date, NATOSTOCKNO: string, injectionSQL: string): Promise<Array<KSchedule.GetQuaratineNOQuery_Class>> {
        let url: string = '/api/KScheduleService/GetQuaratineNOQuery';
        let input = { 'DATE': DATE, 'NATOSTOCKNO': NATOSTOCKNO, 'injectionSQL': injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<KSchedule.GetQuaratineNOQuery_Class>>(url, input);
        return result;
    }
    public static async GetKScheduleReportQuery(TTOBJECTID: Guid): Promise<Array<KSchedule.GetKScheduleReportQuery_Class>> {
        let url: string = '/api/KScheduleService/GetKScheduleReportQuery';
        let input = { 'TTOBJECTID': TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<KSchedule.GetKScheduleReportQuery_Class>>(url, input);
        return result;
    }
    public static async KScheduleMaterialBarcodeRQ(TTOBJECTID: Guid): Promise<Array<KSchedule.KScheduleMaterialBarcodeRQ_Class>> {
        let url: string = '/api/KScheduleService/KScheduleMaterialBarcodeRQ';
        let input = { 'TTOBJECTID': TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<KSchedule.KScheduleMaterialBarcodeRQ_Class>>(url, input);
        return result;
    }

    public static async GetMyDrugBarcodes(KscheduleAction: KSchedule): Promise<DrugBarcodesContainer> {
        let url: string = '/api/KScheduleService/GetMyDrugBarcodes';
        let input = { 'KscheduleAction': KscheduleAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<DrugBarcodesContainer>(url, input);
        return result;
    }

    public static async GetCompletedKScheduleMaterial(EPISODEID: Guid): Promise<Array<GetCompletedKScheduleMaterial_Output>> {
        let url: string = '/api/KScheduleService/GetCompletedKScheduleMaterial';
        let input = { 'EPISODEID': EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetCompletedKScheduleMaterial_Output>>(url, input);
        return result;
    }

    public static async GetCompletedKscheduleActions(param: GetCompletedKSchedule_Input): Promise<GetCompletedKSchedule_Output> {
        let url: string = '/api/KScheduleService/GetCompletedKscheduleActions';
        let input = { 'StoreID': param.StoreID, 'StartDate': param.StartDate, 'EndDate': param.EndDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetCompletedKSchedule_Output>(url, input);
        return result;
    }

    public static async PrintBarcodeForGivenActions(param: PrintBarcodeForGivenActions_Input): Promise<DrugBarcodesContainer> {
        let url: string = '/api/KScheduleService/PrintBarcodeForGivenActions';
        let input = { 'GivenActionList': param.GivenActionList };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<DrugBarcodesContainer>(url, input);
        return result;
    }

    public static async PrintBarcodeForPursaklar(InputKS: PrintBarcodeForPursaklar_Input): Promise<DrugBarcodesContainer> {
        let url: string = '/api/KScheduleService/PrintBarcodeForPursaklar';
        let input = { 'KScheduleObjID': InputKS.KScheduleObjID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<DrugBarcodesContainer>(url, input);
        return result;
    }

    public static async IsImmadiatleControl(KScheduleObjID: Guid): Promise<string> {
        let url: string = '/api/KScheduleService/IsImmadiatleControl';
        let input = { 'KScheduleObjID': KScheduleObjID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async StoppedDrugOrderCheck(KScheduleObjID: Guid): Promise<string> {
        let url: string = '/api/KScheduleService/StoppedDrugOrderCheck';
        let input = { 'KScheduleObjID': KScheduleObjID  };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async GetPatientOwnDrugs(getPatientOwnDrug_Input: GetPatientOwnDrug_Input): Promise<Array<GetPatientOwnDrug_Output>> {
        let url: string = '/api/KScheduleService/GetPatientOwnDrugs';
        let input = { 'KSCHEDULEOBJID': getPatientOwnDrug_Input.KSCHEDULEOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetPatientOwnDrug_Output>>(url, input);
        return result;
    }
}

export class DrugBarcodesContainer {

    public DrugBarcodes: Array<DrugBarcodeInfo> = new Array<DrugBarcodeInfo>();
}

export class GetCompletedKScheduleMaterial_Output {
    public KScheduleMaterialRowType: string;
    public StockActionID: number;
    @Type(() => Date)
    public TransactionDate: Date;
    public Barcode: string;
    public Name: string;
    public Amount: number;
}

export class GetCompletedKSchedule_Input {
    public StoreID: string;
    public StartDate: Date;
    public EndDate: Date;
}
export class KScheduleMaterialRowViewModel {

    @Type(() => Guid)
    public RowObjectId: Guid;
    public KScheduleMaterialRowType: KScheduleMaterialRowType;
    @Type(() => Material)
    public Material: Material;
    public BarcodeVerifyCounter: number;
    public Status: StockActionDetailStatusEnum;
    public IsImmediate: boolean;
    @Type(() => Date)
    public DrugOrderStartDate: Date;
    public RequestAmount: number;
    public ReceivedAmount: number;
    public StoreInheld: number;
    public Description: string;
    public UsageNote: string;
    @Type(() => Date)
    public ExpirationDate: Date;
    public IsCV: boolean;
    public PrescriptionNo: string;
    //public IsNarcotic: boolean;
    //public IsPsychotropic: boolean;



}
export class GetCompletedKSchedule_Output {
    public CompletedKscheduleList: CompletedKscheduleAction[];
}
export class CompletedKscheduleAction {
    public ActionObjectID: string;
    public ActionID: string;
    public PatientName: string;
    public StoreName: string;
    public DetailList: CompletedKscheduleActionDetail[];
}
export class CompletedKscheduleActionDetail {
    public Barcode: string;
    public MaterialName: string;
    public Amount: string;
}

export class PrintBarcodeForGivenActions_Input {
    public GivenActionList: CompletedKscheduleAction[];
}

export class PrintBarcodeForPursaklar_Input {
    public KScheduleObjID: string;
}

export class HimsDrugBarcodesContainer {
    public DrugBarcodes: Array<HimsDrugInfo> = new Array<HimsDrugInfo>();
}


export class GetPatientOwnDrug_Output {
    public Barcode: string;
    public Name: string;
    public Amount: number;
    public StockActionDetailStatusEnum: StockActionDetailStatusEnum;
}

export class GetPatientOwnDrug_Input {
    public KSCHEDULEOBJID: string;
}