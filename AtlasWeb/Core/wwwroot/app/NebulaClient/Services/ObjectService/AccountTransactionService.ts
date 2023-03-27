//$7B83DF13
import { AccountTransaction } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class AccountTransactionService {
    public static async GetByIdv2(IdList: Array<number>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetByIdv2";
        let input = { "IdList": IdList };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsForReceipt(APR: Guid, STATE: Guid, SEP: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsForReceipt";
        let input = { "APR": APR, "STATE": STATE, "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsForInvoice(STATE: Guid, APR: Guid, SEP: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsForInvoice";
        let input = { "STATE": STATE, "APR": APR, "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsForCollectedInvoice(STARTDATE: Date, ENDDATE: Date, PAYER: Array<Guid>, PATIENTSTATUS: Array<number>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsForCollectedInvoice";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PAYER": PAYER, "PATIENTSTATUS": PATIENTSTATUS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsExceptCancelledBySEP(APR: Guid, SEP: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsExceptCancelledBySEP";
        let input = { "APR": APR, "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsForCollectedInvoiceByResource(STARTDATE: Date, ENDDATE: Date, PAYER: Array<Guid>, PATIENTSTATUS: Array<number>, RESOURCE: Array<Guid>, RESOURCEFLAG: number): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsForCollectedInvoiceByResource";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PAYER": PAYER, "PATIENTSTATUS": PATIENTSTATUS, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async OLAP_GetSubactionAccTransaction(SUBACTIONPROCEDURE: Guid): Promise<Array<AccountTransaction.OLAP_GetSubactionAccTransaction_Class>> {
        let url: string = "/api/AccountTransactionService/OLAP_GetSubactionAccTransaction";
        let input = { "SUBACTIONPROCEDURE": SUBACTIONPROCEDURE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.OLAP_GetSubactionAccTransaction_Class>>(url, input);
        return result;
    }
    public static async GetProcTrxsByDateAndProc(STARTDATE: Date, ENDDATE: Date, STATE: Guid, PROCEDURE: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetProcTrxsByDateAndProc";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "STATE": STATE, "PROCEDURE": PROCEDURE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetMatTrxsByDateAndMat(STARTDATE: Date, ENDDATE: Date, STATE: Guid, MATERIAL: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetMatTrxsByDateAndMat";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "STATE": STATE, "MATERIAL": MATERIAL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetSubActionProcedureTrxsBySEP(SEP: Guid, STATES: Array<Guid>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetSubActionProcedureTrxsBySEP";
        let input = { "SEP": SEP, "STATES": STATES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetSubActionMaterialTrxsBySEP(SEP: Guid, STATES: Array<Guid>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetSubActionMaterialTrxsBySEP";
        let input = { "SEP": SEP, "STATES": STATES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsBySEP(SEP: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsBySEP";
        let input = { "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetProcTrxsByDate(STARTDATE: Date, ENDDATE: Date, STATE: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetProcTrxsByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "STATE": STATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetMatTrxsByDate(STARTDATE: Date, ENDDATE: Date, STATE: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetMatTrxsByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "STATE": STATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetToBeNewTrxsByEpisode(EPISODE: Guid): Promise<Array<AccountTransaction.GetToBeNewTrxsByEpisode_Class>> {
        let url: string = "/api/AccountTransactionService/GetToBeNewTrxsByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetToBeNewTrxsByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetIncomesFromDepartment(STARTDATE: Date, ENDDATE: Date, DEPARTMENT: Array<Guid>, DEPARTMENTFLAG: number): Promise<Array<AccountTransaction.GetIncomesFromDepartment_Class>> {
        let url: string = "/api/AccountTransactionService/GetIncomesFromDepartment";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "DEPARTMENT": DEPARTMENT, "DEPARTMENTFLAG": DEPARTMENTFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetIncomesFromDepartment_Class>>(url, input);
        return result;
    }
    public static async GetNewAndCancelledPackageTrxsBySEP(SEP: Guid, injectionSQL: string): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetNewAndCancelledPackageTrxsBySEP";
        let input = { "SEP": SEP, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetNewAndCancelledProcedureTrxsBySEP(SEP: Guid, injectionSQL: string): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetNewAndCancelledProcedureTrxsBySEP";
        let input = { "SEP": SEP, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async DetailedRevenueListProcedureQuery(STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.DetailedRevenueListProcedureQuery_Class>> {
        let url: string = "/api/AccountTransactionService/DetailedRevenueListProcedureQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.DetailedRevenueListProcedureQuery_Class>>(url, input);
        return result;
    }
    public static async GetTransactionsInsidePackageBySEP(PACKAGE: Guid, SEP: Guid, APR: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsInsidePackageBySEP";
        let input = { "PACKAGE": PACKAGE, "SEP": SEP, "APR": APR };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsForCollectedInvoiceByResource_Tooth(STARTDATE: Date, ENDDATE: Date, PAYER: Array<Guid>, PATIENTSTATUS: Array<number>, RESOURCE: Array<Guid>, RESOURCEFLAG: number): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsForCollectedInvoiceByResource_Tooth";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PAYER": PAYER, "PATIENTSTATUS": PATIENTSTATUS, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsForReceiptByEpisode(CURRENTSTATEID: Guid, EPISODE: Guid, APR: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsForReceiptByEpisode";
        let input = { "CURRENTSTATEID": CURRENTSTATEID, "EPISODE": EPISODE, "APR": APR };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsBySEPAndPackageDef(SEP: Guid, PACKAGE: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsBySEPAndPackageDef";
        let input = { "SEP": SEP, "PACKAGE": PACKAGE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetMaterialListByDateAndDepartment(STARTDATE: Date, ENDDATE: Date, PATIENTSTATUS1: number, PATIENTSTATUS2: number, PATIENTSTATUS3: number, RESOURCE: Array<Guid>, RESOURCEFLAG: number): Promise<Array<AccountTransaction.GetMaterialListByDateAndDepartment_Class>> {
        let url: string = "/api/AccountTransactionService/GetMaterialListByDateAndDepartment";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PATIENTSTATUS1": PATIENTSTATUS1, "PATIENTSTATUS2": PATIENTSTATUS2, "PATIENTSTATUS3": PATIENTSTATUS3, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMaterialListByDateAndDepartment_Class>>(url, input);
        return result;
    }
    public static async GetNotInvoicedPatientListByPatientStatus(STARTDATE: Date, ENDDATE: Date, PATIENTSTATUS1: number, PATIENTSTATUS2: number, PATIENTSTATUS3: number, PAYER: Array<Guid>, PAYERFLAG: number): Promise<Array<AccountTransaction.GetNotInvoicedPatientListByPatientStatus_Class>> {
        let url: string = "/api/AccountTransactionService/GetNotInvoicedPatientListByPatientStatus";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PATIENTSTATUS1": PATIENTSTATUS1, "PATIENTSTATUS2": PATIENTSTATUS2, "PATIENTSTATUS3": PATIENTSTATUS3, "PAYER": PAYER, "PAYERFLAG": PAYERFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetNotInvoicedPatientListByPatientStatus_Class>>(url, input);
        return result;
    }
    public static async DetailedRevenueListMaterialQuery(STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.DetailedRevenueListMaterialQuery_Class>> {
        let url: string = "/api/AccountTransactionService/DetailedRevenueListMaterialQuery";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.DetailedRevenueListMaterialQuery_Class>>(url, input);
        return result;
    }
    public static async GetMaterialTrxsByHospitalProtocolNo(HOSPITALPROTOCOLNO: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class>> {
        let url: string = "/api/AccountTransactionService/GetMaterialTrxsByHospitalProtocolNo";
        let input = { "HOSPITALPROTOCOLNO": HOSPITALPROTOCOLNO, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMaterialTrxsByHospitalProtocolNo_Class>>(url, input);
        return result;
    }
    public static async GetPatientParticipationTransactions(STARTDATE: Date, ENDDATE: Date, PARTICIPATIONPROCEDURE: Guid): Promise<Array<AccountTransaction.GetPatientParticipationTransactions_Class>> {
        let url: string = "/api/AccountTransactionService/GetPatientParticipationTransactions";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PARTICIPATIONPROCEDURE": PARTICIPATIONPROCEDURE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetPatientParticipationTransactions_Class>>(url, input);
        return result;
    }
    public static async CollectedInvoiceProcedureDetailReportQueryCheck(COLLINVOICEOBJID: string, RESOURCE: Array<string>, RESOURCEFLAG: number): Promise<Array<AccountTransaction.CollectedInvoiceProcedureDetailReportQueryCheck_Class>> {
        let url: string = "/api/AccountTransactionService/CollectedInvoiceProcedureDetailReportQueryCheck";
        let input = { "COLLINVOICEOBJID": COLLINVOICEOBJID, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.CollectedInvoiceProcedureDetailReportQueryCheck_Class>>(url, input);
        return result;
    }
    public static async GetProcedureTrxsByHospitalProtocolNo(HOSPITALPROTOCOLNO: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class>> {
        let url: string = "/api/AccountTransactionService/GetProcedureTrxsByHospitalProtocolNo";
        let input = { "HOSPITALPROTOCOLNO": HOSPITALPROTOCOLNO, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetProcedureTrxsByHospitalProtocolNo_Class>>(url, input);
        return result;
    }
    public static async GetDrugTrxsByHospitalProtocolNo(HOSPITALPROTOCOLNO: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class>> {
        let url: string = "/api/AccountTransactionService/GetDrugTrxsByHospitalProtocolNo";
        let input = { "HOSPITALPROTOCOLNO": HOSPITALPROTOCOLNO, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetDrugTrxsByHospitalProtocolNo_Class>>(url, input);
        return result;
    }
    public static async GetProcedureIncomesByMasterResource(DEPARTMENT: Array<Guid>, DEPARTMENTFLAG: number, STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.GetProcedureIncomesByMasterResource_Class>> {
        let url: string = "/api/AccountTransactionService/GetProcedureIncomesByMasterResource";
        let input = { "DEPARTMENT": DEPARTMENT, "DEPARTMENTFLAG": DEPARTMENTFLAG, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetProcedureIncomesByMasterResource_Class>>(url, input);
        return result;
    }
    public static async CollInvoiceDetailedRevenueListMaterialQuery(ID: Array<string>): Promise<Array<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_Class>> {
        let url: string = "/api/AccountTransactionService/CollInvoiceDetailedRevenueListMaterialQuery";
        let input = { "ID": ID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_Class>>(url, input);
        return result;
    }
    public static async GetNewAndCancelledTrxsBySEP(SEP: string): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetNewAndCancelledTrxsBySEP";
        let input = { "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetForInvoiceInclusionBySEP(SEP: Guid, injectionSQL: string): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetForInvoiceInclusionBySEP";
        let input = { "SEP": SEP, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsByPayerInvoice(PAYERINVOICE: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsByPayerInvoice";
        let input = { "PAYERINVOICE": PAYERINVOICE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetMedulaDontSendDrugTrxsByDate(STARTDATE: Date, ENDDATE: Date, BRANCH: Array<Guid>, BRANCHFLAG: number): Promise<Array<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class>> {
        let url: string = "/api/AccountTransactionService/GetMedulaDontSendDrugTrxsByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "BRANCH": BRANCH, "BRANCHFLAG": BRANCHFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class>>(url, input);
        return result;
    }
    public static async GetMedulaDontSendProcedureTrxsByDate(STARTDATE: Date, ENDDATE: Date, BRANCH: Array<Guid>, BRANCHFLAG: number): Promise<Array<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class>> {
        let url: string = "/api/AccountTransactionService/GetMedulaDontSendProcedureTrxsByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "BRANCH": BRANCH, "BRANCHFLAG": BRANCHFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class>>(url, input);
        return result;
    }
    public static async GetMedulaDontSendMaterialTrxsByDate(STARTDATE: Date, ENDDATE: Date, BRANCH: Array<Guid>, BRANCHFLAG: number): Promise<Array<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class>> {
        let url: string = "/api/AccountTransactionService/GetMedulaDontSendMaterialTrxsByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "BRANCH": BRANCH, "BRANCHFLAG": BRANCHFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class>>(url, input);
        return result;
    }
    public static async GetPackageTrxsForInvoice(STATE: Guid, APR: Guid, SEP: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetPackageTrxsForInvoice";
        let input = { "STATE": STATE, "APR": APR, "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetProcedureTrxsForInvoice(STATE: Guid, APR: Guid, SEP: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetProcedureTrxsForInvoice";
        let input = { "STATE": STATE, "APR": APR, "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetMaterialTrxsForInvoice(STATE: Guid, APR: Guid, SEP: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetMaterialTrxsForInvoice";
        let input = { "STATE": STATE, "APR": APR, "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsForCollInvByResource_OutPatient(STARTDATE: Date, ENDDATE: Date, PAYER: Array<Guid>, RESOURCE: Array<Guid>, RESOURCEFLAG: number): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsForCollInvByResource_OutPatient";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PAYER": PAYER, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetTransactionsForInvoiceBySEP(SEP: Guid): Promise<Array<AccountTransaction.GetTransactionsForInvoiceBySEP_Class>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsForInvoiceBySEP";
        let input = { "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetTransactionsForInvoiceBySEP_Class>>(url, input);
        return result;
    }
    public static async GetMaterialIncomesByMasterResource(DEPARTMENT: Array<Guid>, DEPARTMENTFLAG: number, STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.GetMaterialIncomesByMasterResource_Class>> {
        let url: string = "/api/AccountTransactionService/GetMaterialIncomesByMasterResource";
        let input = { "DEPARTMENT": DEPARTMENT, "DEPARTMENTFLAG": DEPARTMENTFLAG, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMaterialIncomesByMasterResource_Class>>(url, input);
        return result;
    }
    public static async GetMaterialIncomesByRessection(DEPARTMENT: Array<Guid>, DEPARTMENTFLAG: number, STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.GetMaterialIncomesByRessection_Class>> {
        let url: string = "/api/AccountTransactionService/GetMaterialIncomesByRessection";
        let input = { "DEPARTMENT": DEPARTMENT, "DEPARTMENTFLAG": DEPARTMENTFLAG, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMaterialIncomesByRessection_Class>>(url, input);
        return result;
    }
    public static async GetDrugIncomesByRessection(DEPARTMENT: Array<Guid>, DEPARTMENTFLAG: number, STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.GetDrugIncomesByRessection_Class>> {
        let url: string = "/api/AccountTransactionService/GetDrugIncomesByRessection";
        let input = { "DEPARTMENT": DEPARTMENT, "DEPARTMENTFLAG": DEPARTMENTFLAG, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetDrugIncomesByRessection_Class>>(url, input);
        return result;
    }
    public static async GetTransactionsForCollInvByResource_InPatient(STARTDATE: Date, ENDDATE: Date, PAYER: Array<Guid>, RESOURCE: Array<Guid>, RESOURCEFLAG: number): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsForCollInvByResource_InPatient";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PAYER": PAYER, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetMedulaProcessNoExistsAndWrongState(): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetMedulaProcessNoExistsAndWrongState";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetMedulaTransactionsByProvisionNoAndState(PROVISIONNO: string, STATES: Array<Guid>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetMedulaTransactionsByProvisionNoAndState";
        let input = { "PROVISIONNO": PROVISIONNO, "STATES": STATES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetCountForMedulaBySEP(SEP: Guid): Promise<Array<AccountTransaction.GetCountForMedulaBySEP_Class>> {
        let url: string = "/api/AccountTransactionService/GetCountForMedulaBySEP";
        let input = { "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetCountForMedulaBySEP_Class>>(url, input);
        return result;
    }
    public static async GetNewAndToBeNewPackageTrxsBySEP(SEP: Guid, injectionSQL: string): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetNewAndToBeNewPackageTrxsBySEP";
        let input = { "SEP": SEP, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetMaterialTrxsBySEPAndCode(SEP: Guid, EXTERNALCODE: string): Promise<Array<AccountTransaction.GetMaterialTrxsBySEPAndCode_Class>> {
        let url: string = "/api/AccountTransactionService/GetMaterialTrxsBySEPAndCode";
        let input = { "SEP": SEP, "EXTERNALCODE": EXTERNALCODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMaterialTrxsBySEPAndCode_Class>>(url, input);
        return result;
    }
    public static async GetById(ID: Array<number>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetById";
        let input = { "ID": ID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetProcedureIncomesByRessection(DEPARTMENT: Array<Guid>, DEPARTMENTFLAG: number, STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.GetProcedureIncomesByRessection_Class>> {
        let url: string = "/api/AccountTransactionService/GetProcedureIncomesByRessection";
        let input = { "DEPARTMENT": DEPARTMENT, "DEPARTMENTFLAG": DEPARTMENTFLAG, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetProcedureIncomesByRessection_Class>>(url, input);
        return result;
    }
    public static async GetPatientTotalNotPaid(APR: Guid): Promise<Array<AccountTransaction.GetPatientTotalNotPaid_Class>> {
        let url: string = "/api/AccountTransactionService/GetPatientTotalNotPaid";
        let input = { "APR": APR };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetPatientTotalNotPaid_Class>>(url, input);
        return result;
    }
    public static async GetPayerTotalPriceBySubEpisode(SUBEPISODE: Guid): Promise<Array<AccountTransaction.GetPayerTotalPriceBySubEpisode_Class>> {
        let url: string = "/api/AccountTransactionService/GetPayerTotalPriceBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetPayerTotalPriceBySubEpisode_Class>>(url, input);
        return result;
    }
    public static async GetMedulaEntryPriceBySEP(SEP: Guid): Promise<Array<AccountTransaction.GetMedulaEntryPriceBySEP_Class>> {
        let url: string = "/api/AccountTransactionService/GetMedulaEntryPriceBySEP";
        let input = { "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMedulaEntryPriceBySEP_Class>>(url, input);
        return result;
    }
    public static async GetMedulaTransactionsBySEPAndState(SEP: Guid, STATES: Array<Guid>): Promise<Array<AccountTransaction.GetMedulaTransactionsBySEPAndState_Class>> {
        let url: string = "/api/AccountTransactionService/GetMedulaTransactionsBySEPAndState";
        let input = { "SEP": SEP, "STATES": STATES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMedulaTransactionsBySEPAndState_Class>>(url, input);
        return result;
    }
    public static async GetTransactionsToSendMedulaBySEP(SEP: Guid, STATES: Array<Guid>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsToSendMedulaBySEP";
        let input = { "SEP": SEP, "STATES": STATES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async CollectedInvoiceProcDetPreviewReportQuery1(PARAMRESOURCE: Array<string>, PARAMRESOURCEFLAG: number, PARAMEPISODE: Array<string>, PARAMPAYER: Array<string>, PATIENTSTATUS: number): Promise<Array<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery1_Class>> {
        let url: string = "/api/AccountTransactionService/CollectedInvoiceProcDetPreviewReportQuery1";
        let input = { "PARAMRESOURCE": PARAMRESOURCE, "PARAMRESOURCEFLAG": PARAMRESOURCEFLAG, "PARAMEPISODE": PARAMEPISODE, "PARAMPAYER": PARAMPAYER, "PATIENTSTATUS": PATIENTSTATUS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery1_Class>>(url, input);
        return result;
    }
    public static async GetNewAndCancelledMaterialTrxsBySEP(SEP: Guid, injectionSQL: string): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetNewAndCancelledMaterialTrxsBySEP";
        let input = { "SEP": SEP, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async OLAP_GetInvoiceByResource(STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.OLAP_GetInvoiceByResource_Class>> {
        let url: string = "/api/AccountTransactionService/OLAP_GetInvoiceByResource";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.OLAP_GetInvoiceByResource_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetInvoiceByPharmacyResource(STARTDATE: Date, ENDDATE: Date): Promise<Array<AccountTransaction.OLAP_GetInvoiceByPharmacyResource_Class>> {
        let url: string = "/api/AccountTransactionService/OLAP_GetInvoiceByPharmacyResource";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.OLAP_GetInvoiceByPharmacyResource_Class>>(url, input);
        return result;
    }
    public static async GetInvoicedSubActionProcedureTrxsBySEP(SEP: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetInvoicedSubActionProcedureTrxsBySEP";
        let input = { "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async CollectedInvoiceProcDetPreviewReportQuery2(PARAMPAYER: Array<string>, PARAMRESOURCE: Array<string>, PARAMRESOURCE2: Array<string>, PARAMEPISODE: Array<string>, PATIENTSTATUS: number): Promise<Array<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class>> {
        let url: string = "/api/AccountTransactionService/CollectedInvoiceProcDetPreviewReportQuery2";
        let input = { "PARAMPAYER": PARAMPAYER, "PARAMRESOURCE": PARAMRESOURCE, "PARAMRESOURCE2": PARAMRESOURCE2, "PARAMEPISODE": PARAMEPISODE, "PATIENTSTATUS": PATIENTSTATUS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class>>(url, input);
        return result;
    }
    public static async GetOrthesisProsthesisByProtocolNoAndYear(STARTDATE: Date, ENDDATE: Date, PROTOCOLNO: string): Promise<Array<AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class>> {
        let url: string = "/api/AccountTransactionService/GetOrthesisProsthesisByProtocolNoAndYear";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PROTOCOLNO": PROTOCOLNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class>>(url, input);
        return result;
    }
    public static async GetProcedureTrxToSendMedulaByEpisode(EPISODE: Guid, STATES: Array<Guid>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetProcedureTrxToSendMedulaByEpisode";
        let input = { "EPISODE": EPISODE, "STATES": STATES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetPackageTrxsByEpisode(EPISODE: Guid): Promise<Array<AccountTransaction.GetPackageTrxsByEpisode_Class>> {
        let url: string = "/api/AccountTransactionService/GetPackageTrxsByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetPackageTrxsByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetTrxBySEPProcedureAndState(SEP: Array<Guid>, PROCEDURE: Guid, STATES: Array<Guid>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTrxBySEPProcedureAndState";
        let input = { "SEP": SEP, "PROCEDURE": PROCEDURE, "STATES": STATES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetOrthesisProsthesisByProcedureAndDate(STARTDATE: Date, ENDDATE: Date, PROCEDURE: Array<string>, PROCEDUREFLAG: number, STATEID: Array<string>): Promise<Array<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class>> {
        let url: string = "/api/AccountTransactionService/GetOrthesisProsthesisByProcedureAndDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PROCEDURE": PROCEDURE, "PROCEDUREFLAG": PROCEDUREFLAG, "STATEID": STATEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetOrthesisProsthesisByProcedureAndDate_Class>>(url, input);
        return result;
    }
    public static async CollInvoiceDetailedRevenueListProcedureQuery(ID: Array<string>): Promise<Array<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_Class>> {
        let url: string = "/api/AccountTransactionService/CollInvoiceDetailedRevenueListProcedureQuery";
        let input = { "ID": ID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_Class>>(url, input);
        return result;
    }
    public static async GetOrthesisProsthesisTrxsForInvoice(STATE: Guid, APR: Guid, SEP: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetOrthesisProsthesisTrxsForInvoice";
        let input = { "STATE": STATE, "APR": APR, "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetAllTransactionsBySEP(SEP: Guid, injectionSQL: string): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetAllTransactionsBySEP";
        let input = { "SEP": SEP, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetMedulaTransactionCountBySEPAndState(SEP: Guid, STATES: Array<Guid>): Promise<Array<AccountTransaction.GetMedulaTransactionCountBySEPAndState_Class>> {
        let url: string = "/api/AccountTransactionService/GetMedulaTransactionCountBySEPAndState";
        let input = { "SEP": SEP, "STATES": STATES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetMedulaTransactionCountBySEPAndState_Class>>(url, input);
        return result;
    }
    public static async GetPatientTotalPriceBySubEpisode(SUBEPISODE: Guid): Promise<Array<AccountTransaction.GetPatientTotalPriceBySubEpisode_Class>> {
        let url: string = "/api/AccountTransactionService/GetPatientTotalPriceBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetPatientTotalPriceBySubEpisode_Class>>(url, input);
        return result;
    }
    public static async GetPayerTotalPriceByEpisode(EPISODE: Guid): Promise<Array<AccountTransaction.GetPayerTotalPriceByEpisode_Class>> {
        let url: string = "/api/AccountTransactionService/GetPayerTotalPriceByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetPayerTotalPriceByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetPatientTotalPriceByEpisode(EPISODE: Guid): Promise<Array<AccountTransaction.GetPatientTotalPriceByEpisode_Class>> {
        let url: string = "/api/AccountTransactionService/GetPatientTotalPriceByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.GetPatientTotalPriceByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetTransactionsWithMedulaProcessNoBySEP(SEP: Array<Guid>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTransactionsWithMedulaProcessNoBySEP";
        let input = { "SEP": SEP };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async CollInvoiceDetailedRevenueListMaterialQuery_NP(ID: Array<string>): Promise<Array<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class>> {
        let url: string = "/api/AccountTransactionService/CollInvoiceDetailedRevenueListMaterialQuery_NP";
        let input = { "ID": ID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class>>(url, input);
        return result;
    }
    public static async CollInvoiceDetailedRevenueListProcedureQuery_NP(ID: Array<string>): Promise<Array<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class>> {
        let url: string = "/api/AccountTransactionService/CollInvoiceDetailedRevenueListProcedureQuery_NP";
        let input = { "ID": ID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class>>(url, input);
        return result;
    }
    public static async GetTrxForMedulaBySubActionProcedure(SUBACTIONPROCEDURE: Guid, STATES: Array<Guid>): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetTrxForMedulaBySubActionProcedure";
        let input = { "SUBACTIONPROCEDURE": SUBACTIONPROCEDURE, "STATES": STATES };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async GetIncludedTrxsExceptCancelledByEpisode(APR: Guid, EPISODE: Guid): Promise<Array<AccountTransaction>> {
        let url: string = "/api/AccountTransactionService/GetIncludedTrxsExceptCancelledByEpisode";
        let input = { "APR": APR, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
}