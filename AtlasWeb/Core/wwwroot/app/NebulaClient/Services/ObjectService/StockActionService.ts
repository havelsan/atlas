//$63865916
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InspectionUserTypeEnum, ExtendExpDateInDetail, InPatientPhysicianApplication, DrugOrderDetail, DocumentTransactionTypeEnum, MKYSControlEnum, ActionInfoCorrectionDet, ChattelDocumentDetailWithPurchase, StockTransactionDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EButceTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { StockAction } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspectionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspection } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MkysServis } from 'NebulaClient/Services/External/MkysServis';
import { ChattelDocumentWithPurchase } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { EventEmitter } from '@angular/core';
import { OuttableLotDTO } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/ChattelDocumentOutputWithAccountancyNewFormViewModel';
import { LogisticDocumentUploadFormInput } from 'app/Logistic/Views/LogiscticDocumentComponents/LogisticPatientDocumentUploadForm';


export class SendMKYSForOutputDocumentTS_Input {
    public stockAction: StockAction;
    public mkysPwd: string;
}
export class SendMKYSForInputDocumentTS_Input {
    public stockAction: StockAction;
    public mkysPwd: string;
}

export class SendDeleteMessageToMkysTS_Input {
    public stockAction: Guid;
    public IsOutOperetion: boolean;
    public AyniyatMakbuzID: number;
    public mkysPwd: string;
}

export class SendITSTo_Input {
    public stockAction: StockAction;
}

export class SendUpdateMessageToMKYSTS_Input {
    public stockAction: StockAction;
    public mkysPwd: string;
}

export class SendIhaleTarihiVeNumarasiUpdateTS_Input {
    public chattelDocumentWithPurchase: ChattelDocumentWithPurchase;
    public mkysPwd: string;
}

export class SendBarkodUpdateTS_Input {
    public newBarcode: string;
    public MKYS_StokHareketID: number;
    public mkysPwd: string;
}
export class SendUTSUpdateTS_Input {
    public newLot: string;
    public newUTSAlma: string;
    public newUTSVerme: string;
    public StockActionDetailInObjID: string;
}

export class InPatientPhysicianApplication_Output {
    public clinicProtocolNo: string;
    public clinicName: string;
    public clinicRoom: string;
    public clinicBed: string;
    public clinicDischargeDate: Date;
    public episodeObjectID: Guid;
    public patientObjectID: Guid;
}

export class InputFor_UnnotifiedBaseTreatmentMaterialToUTS {
    public ResourceIds: Array<Guid>;
}

export class GetInPatientPhysicianApplications_Input {
    public SearchKey: string;
}

export class GetInPatientPhysicianApplications_Output {
    public Key: string;
    public InPatientPhysicianApplication: InPatientPhysicianApplication;
    public PatientInfo: string;
    public Description: string;
    public InvoiceControl: boolean;
}

export class StockActionService {
    /* public static async GetMKYSStokHareketTurEnumFromTedarik(tedarikTuru: ETedarikTurID): Promise<EGirisStokHareketTurID> {
         let url: string = "/api/StockActionService/GetMKYSStokHareketTurEnumFromTedarik";
         let input = { "tedarikTuru": tedarikTuru };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let result = await httpService.post<EGirisStokHareketTurID>(url, input);
         return result;
     } */

    public static async GetInPatientPhysicianApplication_Info(INPATIENTPHYSICIANAPPOBJID: string): Promise<InPatientPhysicianApplication_Output> {
        let url: string = "/api/StockActionService/GetInPatientPhysicianApplication_Info";
        let InPatientPhysicianApplication_Input = { "INPATIENTPHYSICIANAPPOBJID": INPATIENTPHYSICIANAPPOBJID };
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
    public static async SendBarkodUpdateTS(MKYS_StokHareketID: number, newBarcode: string, mkysPwd: string): Promise<string> {
        let url: string = '/api/StockActionService/SendBarkodUpdateTS';
        let input: SendBarkodUpdateTS_Input = new SendBarkodUpdateTS_Input();
        input.mkysPwd = mkysPwd;
        input.MKYS_StokHareketID = MKYS_StokHareketID;
        input.newBarcode = newBarcode;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async SendUTSUpdateTS(input: SendUTSUpdateTS_Input): Promise<boolean> {
        let url: string = '/api/StockActionService/SendUTSUpdateTS';
        let inputS: SendUTSUpdateTS_Input = new SendUTSUpdateTS_Input();
        inputS.newLot = input.newLot;
        inputS.newUTSAlma = input.newUTSAlma;
        inputS.StockActionDetailInObjID = input.StockActionDetailInObjID;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async AutoSupplyRequestDetailCreate(store: Store, requestTypeEnum: SupplyRequestTypeEnum): Promise<Array<AutoSupplyRequestDetailCreate_Output>> {
        let url: string = '/api/StockActionService/AutoSupplyRequestDetailCreate';
        let input = { 'store': store, 'requestTypeEnum': requestTypeEnum };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AutoSupplyRequestDetailCreate_Output>>(url, input);
        return result;
    }

    public static async AutoDistributionCreate(store: Store, destinationStore: Store): Promise<Array<AutoDistributionCreate_Output>> {
        let url: string = '/api/StockActionService/AutoDistributionCreate';
        let input = { 'store': store, 'destinationStore': destinationStore };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AutoDistributionCreate_Output>>(url, input);
        return result;
    }


    public static async SendMKYSForInputDocumentTS(stockAction: StockAction, mkysPwd: string): Promise<string> {
        //-TODO İlaydax (Send metodları için örnek)
        let url: string = '/api/StockActionService/SendMKYSForInputDocumentTS';
        let input: SendMKYSForInputDocumentTS_Input = new SendMKYSForInputDocumentTS_Input();
        input.mkysPwd = mkysPwd;
        input.stockAction = stockAction;
        //let input = { 'stockAction': stockAction, 'mkysPwd': mkysPwd };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async SendMKYSForOutputDocumentTS(stockAction: StockAction, mkysPwd: string): Promise<string> {
        let url: string = '/api/StockActionService/SendMKYSForOutputDocumentTS';
        let input: SendMKYSForOutputDocumentTS_Input = new SendMKYSForOutputDocumentTS_Input();
        input.mkysPwd = mkysPwd;
        input.stockAction = stockAction;
        //let input = { 'stockAction': stockAction, 'mkysPwd': mkysPwd };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async ITSForOutDocument(stockAction: StockAction): Promise<string> {
        let url: string = '/api/StockActionService/ITSForOutDocumentRequest';
        let input: SendITSTo_Input = new SendITSTo_Input();
        input.stockAction = stockAction;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async ITSSendReceiptNotification(stockAction: StockAction): Promise<string> {
        let url: string = '/api/StockActionService/ITSSendReceiptNotification';
        let input: SendITSTo_Input = new SendITSTo_Input();
        input.stockAction = stockAction;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async SendDeleteMessageToMkysTS(stockAction: StockAction, IsOutOperetion: boolean, AyniyatMakbuzID: number, mkysPwd: string): Promise<string> {
        //TODO ilayda
        let url: string = '/api/StockActionService/SendDeleteMessageToMkysTS';
        //let input = { 'stockAction': stockAction, 'IsOutOperetion': IsOutOperetion, 'AyniyatMakbuzID': AyniyatMakbuzID };
        let input: SendDeleteMessageToMkysTS_Input = new SendDeleteMessageToMkysTS_Input();
        input.stockAction = stockAction.ObjectID;
        input.IsOutOperetion = IsOutOperetion;
        input.AyniyatMakbuzID = AyniyatMakbuzID;
        input.mkysPwd = mkysPwd;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async SendMKYSForInputDocument(stockActionId: Guid, mkysPwd: string): Promise<string> {
        let url: string = '/api/EntryOperation/SendToMKYS';
        let input: any = {};
        input.StockActionId = stockActionId;
        input.MKYSPwd = mkysPwd;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(url, input);
        return result;
    }

    public static async SendDeleteToMkys(stockActionId: Guid, mkysPwd: string, receiptNumber: number): Promise<string> {
        let url: string = '/api/EntryOperation/SendDeleteToMkys';
        let input: any = {};
        input.StockActionId = stockActionId;
        input.MKYSPwd = mkysPwd;
        input.ReceiptNumber = receiptNumber;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async SendUpdateMessageToMKYSTS(stockAction: StockAction, mkysPwd: string): Promise<string> {
        let url: string = '/api/StockActionService/SendUpdateMessageToMKYSTS';
        let input: SendUpdateMessageToMKYSTS_Input = new SendUpdateMessageToMKYSTS_Input();
        input.mkysPwd = mkysPwd;
        input.stockAction = stockAction;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async SendIhaleTarihiVeNumarasiUpdateTS(chattelDocumentWithPurchase: ChattelDocumentWithPurchase, mkysPwd: string): Promise<string> {
        let url: string = '/api/StockActionService/SendIhaleTarihiVeNumarasiUpdateTS';
        let input: SendIhaleTarihiVeNumarasiUpdateTS_Input = new SendIhaleTarihiVeNumarasiUpdateTS_Input();
        input.mkysPwd = mkysPwd;
        input.chattelDocumentWithPurchase = chattelDocumentWithPurchase;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async StockActionInspectionDetailTS(signUserTypes: InspectionUserTypeEnum[]): Promise<Array<StockActionInspectionDetail>> {
        let url: string = '/api/StockActionService/StockActionInspectionDetailTS';
        let input = { 'signUserTypes': signUserTypes };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockActionInspectionDetail>>(url, input);
        return result;
    }
    public static async StockActionInspectionTS(signUserTypes: InspectionUserTypeEnum[]): Promise<StockActionInspection_Output> {
        let url: string = '/api/StockActionService/StockActionInspectionTS';
        let input = { 'signUserTypes': signUserTypes };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<StockActionInspection_Output>(url, input);
        return result;
    }
    public static async GetDocumentNumbersForMaterialClassReportQuery(STOREID: Guid, ACCOUNTINGTERM: Guid, MAINCLASSID: Guid, REFERENCELETTER: string):
        Promise<Array<StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class>> {
        let url: string = '/api/StockActionService/GetDocumentNumbersForMaterialClassReportQuery';
        let input = { 'STOREID': STOREID, 'ACCOUNTINGTERM': ACCOUNTINGTERM, 'MAINCLASSID': MAINCLASSID, 'REFERENCELETTER': REFERENCELETTER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class>>(url, input);
        return result;
    }
    public static async StockActionWorkListNQL(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<StockAction>> {
        let url: string = '/api/StockActionService/StockActionWorkListNQL';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'injectionSQL': injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction>>(url, input);
        return result;
    }
    public static async UnitPriceStockActionOutDetailsReportQuery(TTOBJECTID: string): Promise<Array<StockAction.UnitPriceStockActionOutDetailsReportQuery_Class>> {
        let url: string = '/api/StockActionService/UnitPriceStockActionOutDetailsReportQuery';
        let input = { 'TTOBJECTID': TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.UnitPriceStockActionOutDetailsReportQuery_Class>>(url, input);
        return result;
    }
    public static async StockActionInDetailsReportQuery(TTOBJECTID: Guid): Promise<Array<StockAction.StockActionInDetailsReportQuery_Class>> {
        let url: string = '/api/StockActionService/StockActionInDetailsReportQuery';
        let input = { 'TTOBJECTID': TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.StockActionInDetailsReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetDocumentSavingRegisterReportQuery(ACCOUNTINGTERMID: Guid, REGISTRATIONNO: number): Promise<Array<StockAction.GetDocumentSavingRegisterReportQuery_Class>> {
        let url: string = '/api/StockActionService/GetDocumentSavingRegisterReportQuery';
        let input = { 'ACCOUNTINGTERMID': ACCOUNTINGTERMID, 'REGISTRATIONNO': REGISTRATIONNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.GetDocumentSavingRegisterReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetStockCardPresentationReportQuery(STOCKCARDID: string, STOREID: string, STARTDATE: Date, ENDDATE: Date):
        Promise<Array<StockAction.GetStockCardPresentationReportQuery_Class>> {
        let url: string = '/api/StockActionService/GetStockCardPresentationReportQuery';
        let input = { 'STOCKCARDID': STOCKCARDID, 'STOREID': STOREID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.GetStockCardPresentationReportQuery_Class>>(url, input);
        return result;
    }
    public static async StockActionOutDetailsReportQuery(TTOBJECTID: Guid): Promise<Array<StockAction.StockActionOutDetailsReportQuery_Class>> {
        let url: string = '/api/StockActionService/StockActionOutDetailsReportQuery';
        let input = { 'TTOBJECTID': TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.StockActionOutDetailsReportQuery_Class>>(url, input);
        return result;
    }
    public static async CensusReportNQL_AllDocuments(TERMID: string): Promise<Array<StockAction.CensusReportNQL_AllDocuments_Class>> {
        let url: string = '/api/StockActionService/CensusReportNQL_AllDocuments';
        let input = { 'TERMID': TERMID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.CensusReportNQL_AllDocuments_Class>>(url, input);
        return result;
    }
    public static async GetStockActionByTerm(TERMID: Guid): Promise<Array<StockAction>> {
        let url: string = '/api/StockActionService/GetStockActionByTerm';
        let input = { 'TERMID': TERMID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction>>(url, input);
        return result;
    }
    public static async CensusReportNQL_StockActionInDetailsReportQuery(TTOBJECTID: string): Promise<Array<StockAction.CensusReportNQL_StockActionInDetailsReportQuery_Class>> {
        let url: string = '/api/StockActionService/CensusReportNQL_StockActionInDetailsReportQuery';
        let input = { 'TTOBJECTID': TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.CensusReportNQL_StockActionInDetailsReportQuery_Class>>(url, input);
        return result;
    }
    public static async SearchDocumentRegistryReportQuery(injectionSQL: string): Promise<Array<StockAction.SearchDocumentRegistryReportQuery_Class>> {
        let url: string = '/api/StockActionService/SearchDocumentRegistryReportQuery';
        let input = { 'injectionSQL': injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.SearchDocumentRegistryReportQuery_Class>>(url, input);
        return result;
    }
    public static async StockActionWorkListNQLNoDate(injectionSQL: string): Promise<Array<StockAction>> {
        let url: string = '/api/StockActionService/StockActionWorkListNQLNoDate';
        let input = { 'injectionSQL': injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction>>(url, input);
        return result;
    }
    public static async GetStockActionsCount(STARTDATE: Date, ENDDATE: Date): Promise<Array<StockAction.GetStockActionsCount_Class>> {
        let url: string = '/api/StockActionService/GetStockActionsCount';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.GetStockActionsCount_Class>>(url, input);
        return result;
    }
    public static async GetTenderUpdateNQL(ACTIONID: string): Promise<Array<StockAction>> {
        let url: string = '/api/StockActionService/GetTenderUpdateNQL';
        let input = { 'ACTIONID': ACTIONID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction>>(url, input);
        return result;
    }
    public static async MKYSControlGetQuery(): Promise<Array<StockAction.MKYSControlGetQuery_Class>> {
        let url: string = '/api/StockActionService/MKYSControlGetQuery';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.MKYSControlGetQuery_Class>>(url, input);
        return result;
    }
    public static async GetMaxMKYS_MakbuzNo(DEPOKAYITNO: number, BUTCE: MKYS_EButceTurEnum, YIL: number): Promise<Array<StockAction.GetMaxMKYS_MakbuzNo_Class>> {
        let url: string = '/api/StockActionService/GetMaxMKYS_MakbuzNo';
        let input = { 'DEPOKAYITNO': DEPOKAYITNO, 'BUTCE': BUTCE, 'YIL': YIL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<StockAction.GetMaxMKYS_MakbuzNo_Class>>(url, input);
        return result;
    }

    public static async GetOutableStockTransactions(store: string, material: string): Promise<Array<OutableStockTransaction_Response>> {
        let url: string = '/api/StockActionService/GetOutableStockTransactions';
        let input = { 'storeObjectID': store, 'materialObjectID': material };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OutableStockTransaction_Response>>(url, input);
        return result;
    }

    public static async GetDocumentRecordLogs(stockActionID: string): Promise<Array<DocumentRecordLog>> {
        let url: string = '/api/StockActionService/GetDocumentRecordLogs';
        let input = { 'stockActionID': stockActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DocumentRecordLog>>(url, input);
        return result;
    }
    public static async GetMkysLogSearch(inputx: DocumentRecordLogReceiptNumber_Input): Promise<Array<MkysServis.stokHareketLogItem>> {
        let url: string = '/api/StockActionService/GetMkysLogSearch';
        let input = { 'receiptNumber': inputx.receiptNumber, 'password': inputx.password };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<MkysServis.stokHareketLogItem>>(url, input);
        return result;
    }
    public static async DeleteMkysSelectedRow(inputx: DocumentRecordLogReceiptNumber_Input): Promise<boolean> {
        let url: string = '/api/StockActionService/DeleteMkysSelectedRowTS';
        let input = { 'password': inputx.password, 'documentRecordLogObjectID': inputx.documentRecordLogObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async ReGenerateMyGrantMaterial(ActionID: string): Promise<OutputForReGeneration> {
        let url: string = '/api/GrantMaterialService/ReGenerateMyGrantMaterial';
        let input = { 'ActionID': ActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutputForReGeneration>(url, input);
        return result;
    }
    public static async ReGenerateMyChattelDocumentInputWithAccountancy(ActionID: string): Promise<OutputForReGeneration> {
        let url: string = '/api/ChattelDocumentInputWithAccountancyService/ReGenerateMyChattelDocumentInputWithAccountancy';
        let input = { 'ActionID': ActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutputForReGeneration>(url, input);
        return result;
    }
    public static async ReGenerateMyChattelDocumentOutputWithAccountancy(ActionID: string): Promise<OutputForReGeneration> {
        let url: string = '/api/ChattelDocumentOutputWithAccountancyService/ReGenerateMyChattelDocumentOutputWithAccountancy';
        let input = { 'ActionID': ActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutputForReGeneration>(url, input);
        return result;
    }
    public static async ReGenerateMyChattelDocumentWithPurchase(ActionID: string): Promise<OutputForReGeneration> {
        let url: string = '/api/ChattelDocumentWithPurchaseService/ReGenerateMyChattelDocumentWithPurchase';
        let input = { 'ActionID': ActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutputForReGeneration>(url, input);
        return result;
    }
    public static async ReInPatientPhysicianApplicationChattelDocumentWithPurchase(ActionID: string): Promise<OutputForRePhysicianApplication> {
        let url: string = '/api/ChattelDocumentWithPurchaseService/ReInPatientPhysicianApplicationChattelDocumentWithPurchase';
        let input = { 'ActionID': ActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutputForRePhysicianApplication>(url, input);
        return result;
    }
    public static async ReGenerateMyReturningDocument(ActionID: string): Promise<OutputForReGeneration> {
        let url: string = '/api/ReturningDocumentService/ReGenerateMyReturningDocument';
        let input = { 'ActionID': ActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutputForReGeneration>(url, input);
        return result;
    }
    public static async ReGenerateMyDistributionDocument(ActionID: string): Promise<OutputForReGeneration> {
        let url: string = '/api/DistributionDocumentService/ReGenerateMyDistributionDocument';
        let input = { 'ActionID': ActionID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutputForReGeneration>(url, input);
        return result;
    }

    public static async GetEquivalentDrug(store: string, material: string): Promise<Array<EquivalentInfo>> {
        let url: string = '/api/StockActionService/GetEquivalentDrug';
        let input = { 'storeObjectID': store, 'materialObjectID': material };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EquivalentInfo>>(url, input);
        return result;
    }

    public static async CancelStockActionDetail(stockActionDetailObjectID: Guid): Promise<boolean> {
        let url: string = '/api/StockActionService/CancelStockActionDetail';
        let input = { 'stockActionDetailObjectID': stockActionDetailObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }

    public static async GetExtendExpDateIn(supllierID: string, outID: number): Promise<Array<ExtendExpDateInDetail>> {
        let url: string = '/api/StockActionService/GetExtendExpDateIn';
        let input = { 'supllierID': supllierID, 'outID': outID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ExtendExpDateInDetail>>(url, input);
        return result;
    }

    public static async GetInPatientPhysicianApplications(SearchKey: string): Promise<Array<GetInPatientPhysicianApplications_Output>> {
        let url: string = '/api/StockActionService/GetInPatientPhysicianApplications';
        let input = { 'SearchKey': SearchKey };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetInPatientPhysicianApplications_Output>>(url, input);
        return result;
    }

    public static async GetDrugTime(ksObjectID: string,isOwnDrug: boolean): Promise<Array<DrugOrderDetail>> {
        let url: string = '/api/StockActionService/GetDrugTime';
        let input = { 'ksObjectID': ksObjectID , 'isOwnDrug':isOwnDrug};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderDetail>>(url, input);
        return result;
    }
    public static onRowClicked: EventEmitter<any> = new EventEmitter<any>();
    public static onCreateClicked: EventEmitter<any> = new EventEmitter<any>();


    public static async GetOuttableLots(StoreID: Guid, MaterialID: Guid): Promise<Array<GetOuttableLots_Output>> {
        let url: string = '/api/StockActionService/GetOuttableLots';
        let input = { 'StoreID': StoreID, 'MaterialID': MaterialID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetOuttableLots_Output>>(url, input);
        return result;
    }

    public static async ParseQRCode(qrCode: string): Promise<ParseQRcode_Output> {
        let url: string = '/api/StockActionService/ParseQRCode';
        let input = { 'qrCode': qrCode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ParseQRcode_Output>(url, input);
        return result;
    }

    public static async GetDocumentRecordLogInitDVO(): Promise<DocumentRecordLogInitDVO> {
        let url: string = '/api/StockActionService/GetDocumentRecordLogInitDVO';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<DocumentRecordLogInitDVO>(url, input);
        return result;
    }

    public static async GetDocumentRecordLogsSameMKYS(mainStoreID: Guid, outType: string, startDate: Date, endDate: Date, startTIFNo: number, endTIFNo: number): Promise<Array<GetDocumentRecordLogsSameMKYS_Output>> {
        let url: string = '/api/StockActionService/GetDocumentRecordLogsSameMKYS';
        let input = { 'mainStoreID': mainStoreID, 'outType': outType, 'startDate': startDate, 'endDate': endDate, 'startTIFNo': startTIFNo, 'endTIFNo': endTIFNo };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetDocumentRecordLogsSameMKYS_Output>>(url, input);
        return result;
    }

    public static async GetInoutRemaining(mainStoreID: Guid, startDate: Date, endDate: Date, materialObjectID: Guid, budgetTypeObjectID: Guid): Promise<GetInoutRemaining_Output> {
        let url: string = '/api/StockActionService/GetInoutRemaining';
        let input = { 'mainStoreID': mainStoreID, 'startDate': startDate, 'endDate': endDate, 'materialObjectID': materialObjectID, 'budgetTypeObjectID': budgetTypeObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetInoutRemaining_Output>(url, input);
        return result;
    }

    public static async GetInoutRemainingInitDVO(): Promise<InOutRemainingDTO> {
        let url: string = '/api/StockActionService/GetInoutRemainingInitDVO';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<InOutRemainingDTO>(url, input);
        return result;
    }

    public static async GetDocumentRecordLogsDetails(StockActionID: Guid, BudgetType: MKYS_EButceTurEnum): Promise<Array<GetDocumentRecordLogsDetails_Output>> {
        let url: string = '/api/StockActionService/GetDocumentRecordLogsDetails';
        let input = { 'StockActionID': StockActionID, 'BudgetType': BudgetType };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetDocumentRecordLogsDetails_Output>>(url, input);
        return result;
    }
    public static async GetPurchaseStockAction(StockActionID: string, StoreID: Guid): Promise<GetPurchaseStockAction_Output> {
        let url: string = '/api/StockActionService/GetPurchaseStockAction';
        let input = { 'StockActionID': StockActionID, 'StoreID': StoreID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetPurchaseStockAction_Output>(url, input);
        return result;
    }
    public static async CheckDocumentRecordLogForDelete(DocumentRecordLogID: Guid): Promise<Array<CheckDocumentRecordLogForDelete_Output>> {
        let url: string = '/api/StockActionService/CheckDocumentRecordLogForDelete';
        let input = { 'DocumentRecordLogID': DocumentRecordLogID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<CheckDocumentRecordLogForDelete_Output>>(url, input);
        return result;
    }

    public static async GetLogisticPatientDocumentInputDVO(InpatientAppID: Guid): Promise<LogisticDocumentUploadFormInput> {
        let url: string = '/api/StockActionService/GetLogisticPatientDocumentInputDVO';
        let input = { 'InpatientAppID': InpatientAppID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<LogisticDocumentUploadFormInput>(url, input);
        return result;
    }

    public static async GetEpisodeActionIDForStockOut(StockOutID: Guid): Promise<string> {
        let url: string = '/api/StockActionService/GetEpisodeActionIDForStockOut';
        let input = { 'StockOutID': StockOutID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
}
export class AutoDistributionCreate_Output {
    public material: Material;
    public amount: number;
    public distributionType: DistributionTypeDefinition;
    public stockLevelType: StockLevelType;
    public stockCard: StockCard;
    public TagNO: string;
    public storeInheld: number;
    public destinationStoreInheld: number;
    public destinationStoreMaxLevel: number;
}

export class AutoSupplyRequestDetailCreate_Output {

    public material: Material;
    public amount: number;
    public distributionType: DistributionTypeDefinition;

}

export class OutableStockTransaction_Response {
    public LotNo: string;
    public ExpirationDate: Date;
    public Usedamount: number;
    public Restamount: number;
}
export class OutableStockTransaction_Param {
    public materialObjectID: string;
    public storeObjectID: string;
}
export class StockActionInspection_Output {
    public stockActionInspection: StockActionInspection;
    public stockActionInspectionDets: Array<StockActionInspectionDetail>;
}
export class DocumentRecordLogReceiptNumber_Input {
    public receiptNumber: number;
    public transactionType: DocumentTransactionTypeEnum;
    public password: any;
    public documentRecordLogObjectID: string;

}


export class OutputForReGeneration {
    public OutputMessage: string;
    public IsTheActionGenerated: boolean;
}

export class GetEquivalentDrug_Input {
    public materialObjectID: string;
    public storeObjectID: string;
}

export class EquivalentInfo {
    drugObjectId: string;
    name: string;
    barcode: string;
}

export class OutputForRePhysicianApplication {
    public OutputMessage: string;
}

export class OpenStockActionDetailOutput_Input {
    public StoreID: Guid;
    public MaterialID: Guid;
    public MaterialName: string;
    public RequestAmount: number;
    public Barcode: string;
    public DistributionTypeName: string;
    public selectedOuttableLots: Array<OuttableLotDTO> = new Array<OuttableLotDTO>();
}

export class GetOuttableLots_Input {
    public StoreID: Guid;
    public MaterialID: Guid;
}

export class GetOuttableLots_Output {
    public LotNo: string;
    public ExpirationDate: Date;
    public SerialNo: string;
    public BudgetTypeName: string;
    public RestAmount: number;
    public TrxObjectID: Guid;
}

export class ParseQRcode_Output {
    public Barcode: number;
    public ExpirationDate: Date;
    public GTIN: string;
    public BatchNo: string;
    public ExpiryDate: string;
    public PackageCode: string;
    public Karekod: string;
}

export class MainStoreDVO {
    public ObjectID: Guid;
    public Name: string;
}

export class BudgetTypeDefDVO {
    public ObjectID: Guid;
    public Name: string;
}


export class StockTransactionDefDTO {
    public ObjectID: Guid;
    public Name: string;
}

export class OutTypeDVO {
    public TypeName: string;
}

export class DocumentRecordLogInitDVO {
    public mainStores: Array<MainStoreDVO> = new Array<MainStoreDVO>();
    public outTypes: Array<OutTypeDVO> = new Array<OutTypeDVO>();
    public startDate: Date;
    public endDate: Date;
    public startTIFNo: number;
    public endTIFNo: number;
}

export class InOutRemainingDTO {
    public mainStores: Array<MainStoreDVO> = new Array<MainStoreDVO>();
    public budgetTypeDefinitions: Array<BudgetTypeDefDVO> = new Array<BudgetTypeDefDVO>();
    public stockTransactionDefList : Array<StockTransactionDefDTO> = new Array<StockTransactionDefDTO>();
}

export class GetDocumentRecordLogsSameMKYS_Output {
    public TIFNo: string;
    public TransactionDate: Date;
    public TakenGivenPlace: string;
    public Subject: string;
    public MKYSStatus: MKYSControlEnum;
    public DocumentRecordLogID: Guid;
    public StockActionID: Guid;
    public StockActionDefID: Guid;
    public BudgetType: MKYS_EButceTurEnum;
}

export class InoutRemainingInitDVO {

}

export class GetInoutRemaining_Output {
    public devirTutar: number;
    public devirMiktar: number;
    public girisTutar: number;
    public girisMiktar: number;
    public cikisTutar: number;
    public cikisMiktar: number;
    public kalanTutar: number;
    public kalanMiktar: number;
}

export class GetDocumentRecordLogsDetails_Output {
    public NatoStockNo: string;
    public MaterialName: string;
    public Amount: number;
    public DistributionType: string;
    public UnitPrice: number;
    public TotalPrice: number;
}

export class GetPurchaseStockAction_Output {
    public PurchaseAction: ChattelDocumentWithPurchase;
    public PurchaseActionDetails: Array<ChattelDocumentDetailWithPurchase> = new Array<ChattelDocumentDetailWithPurchase>();
    public Materials: Array<Material> = new Array<Material>();
}

export class CheckDocumentRecordLogForDelete_Output {
    public DocumentRecordLogID: Guid;
    public StockActionID: string;
    public DocumentRecordLogNo: string;
    public StockActionName: string;
    public ReceiptNumber: string;
}

export class DocumentRecordLogCheckComponent_Input {
    public Password: string;
    public DeleteDocumentRecordLog: Array<CheckDocumentRecordLogForDelete_Output> = new Array<CheckDocumentRecordLogForDelete_Output>();
}

