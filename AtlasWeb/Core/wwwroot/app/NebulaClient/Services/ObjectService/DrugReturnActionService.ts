//$64ABADB4
import { DrugReturnAction, PatientOwnDrugReturnDetail, DrugReturnActionDetail, DrugOrderDetail, UnitDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderTransaction } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { Type } from 'NebulaClient/ClassTransformer';

export class DrugReturnActionService {
    public static async GetDrugReturnReportQuery(TTOBJECTID: Guid): Promise<Array<DrugReturnAction.GetDrugReturnReportQuery_Class>> {
        let url: string = '/api/DrugReturnActionService/GetDrugReturnReportQuery';
        let input = { 'TTOBJECTID': TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugReturnAction.GetDrugReturnReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDocumentRecordLog(TTOBJECTID: Guid): Promise<Array<DocumentRecordLog>> {
        let url: string = '/api/DrugReturnActionService/GetDocumentRecordLog';
        let input = { 'TTOBJECTID': TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DocumentRecordLog>>(url, input);
        return result;
    }
    public static async CreateStockInAction(drugReturnAction: DrugReturnAction, ObjectContext: TTObjectContext): Promise<boolean> {
        let url: string = '/api/DrugReturnActionService/CreateStockInAction';
        let input = { 'drugReturnAction': drugReturnAction, 'ObjectContext': ObjectContext };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async CreateDocumentRecordLog(drugReturnAction: DrugReturnAction): Promise<boolean> {
        let url: string = '/api/DrugReturnActionService/CreateDocumentRecordLog';
        let input = { 'drugReturnAction': drugReturnAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetReturnableDetails(episodeID: Guid): Promise<GetReturnDetails> {
        let url: string = '/api/DrugReturnActionService/GetReturnableDetails';
        let input = { 'episodeID': episodeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetReturnDetails>(url, input);
        return result;
    }
    public static async GetReturnableOwnDetails(episodeID: Guid): Promise<Array<PatientOwnDrugReturnDetail>> {
        let url: string = '/api/DrugReturnActionService/GetReturnableOwnDetails';
        let input = { 'episodeID': episodeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientOwnDrugReturnDetail>>(url, input);
        return result;
    }

    public static async GetDrugReturnAndDeliveryDetail(subEpisodeID: string): Promise<GetDrugReturnAndDeliveryDetails> {
        let url: string = '/api/DrugReturnActionService/GetDrugReturnAndDeliveryDetail';
        let input = { 'subEpisodeID': subEpisodeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetDrugReturnAndDeliveryDetails>(url, input);
        return result;
    }
}

export class GetDrugReturnAndDeliveryDetails {
    public getDrugReturnAndDeliveryDetails: Array<GetReturnableDrugOrderDetails_Output>;
    public MasterResource: Guid;
    public SecondaryMasterResource: Guid;
    public Episode: Guid;
    public SubEpisode: Guid;
    public SelectedDrugReturnAndDeliveryDetails: Array<GetReturnableDrugOrderDetails_Output> = new Array<GetReturnableDrugOrderDetails_Output>();
    public halfDoseDestructionDVOs: Array<HalfDoseDestructionDVO> = new Array<HalfDoseDestructionDVO>();
}

export class GetReturnableDrugOrderDetails_Output {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Date)
    public transactionDate: Date;
    public drugName: string;
    public amount: number;
    public returnAmount: number;
    @Type(() => Guid)
    public drugOrderTransaction: Guid;
    @Type(() => Guid)
    public materialObjectID: Guid;
    public status: string;
    public isReturnable: boolean;
}


export class DrugReturnActionCreate_Input {
    public getDrugReturnAndDeliveryDetail: GetDrugReturnAndDeliveryDetails;
    public txtIadeNedeni: string;
}

export class DrugDeliveryActionCreate_Input {
    public getDrugReturnAndDeliveryDetail: GetDrugReturnAndDeliveryDetails;
}


export class GetReturnDetails {
    public getReturnableDetails: Array<GetReturnableDetails_Output>;
    public getReviewDetails: Array<GetReturnableDetails_Output>;
}

export class GetWaitingPharmacy_Input {
    @Type(() => Guid)
    public episode: Guid;
    @Type(() => Guid)
    public subepisode: Guid;
}


export class GetWaitingPharmacy_Output {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ID: string;
    public ActionDate: Date;
    public DrugReturnReason: string;
    public details: Array<GetWaitingPharmacyDetail_Output>;
}

export class GetWaitingPharmacyDetail_Output {
    @Type(() => Guid)
    public ObjectID: Guid;
    public MaterialName: string;
    public Amount: string;
}


export class GetComplatedPharmacy_Output {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ID: string;
    public ActionDate: Date;
    public DrugReturnReason: string;
    public details: Array<GetWaitingPharmacyDetail_Output>;
}

export class GetComplatedPharmacyDetail_Output {
    @Type(() => Guid)
    public ObjectID: Guid;
    public MaterialName: string;
    public Amount: string;
}

export class GetReturnableDetails_Output {
    @Type(() => Date)
    public transactionDate: Date;
    public drugName: string;
    public Amount: number;
    public ReturnAmount: number;
    @Type(() => DrugOrderTransaction)
    public drugOrderTransaction: DrugOrderTransaction;
}

export class HalfDoseDestructionDVO {
    public drugName: string;
    public drugOrderDetail: DrugOrderDetail;
    public unitName: string;
    public unitDefinition: UnitDefinition;
    public amount: number;
}

export class CreateHalfDoseDestruction_Input {
    @Type(() => Guid)
    public episodeID: Guid;
    @Type(() => Guid)
    public subEpisodeID: Guid;
    @Type(() => Guid)
    public masterResourceID: Guid;
    @Type(() => Guid)
    public secondaryMasterResourceID: Guid;
    public halfDoseDestructionDetails: Array<HalfDoseDestructionDVO> = new Array<HalfDoseDestructionDVO>();
}

export class CreateHalfDoseDestruction_Output {
    public halfDoseDestructionDVOs: Array<HalfDoseDestructionDVO> = new Array<HalfDoseDestructionDVO>();
    @Type(() => Guid)
    public objectID: Guid;
}

export class GetReturnableDrugOrders_Output {
    @Type(() => Guid)
    public objectID: Guid;
    public transactionDate: Date;
    public drugName: string;
    public amount: number;
    public frequency: string;
    public doseAmount: number;
    public isTransferable: boolean;
}
