//$EAD2C746
import { Dictionary } from 'NebulaClient/System/Collections/Dictionaries/Dictionary';
import { DrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderTransaction } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { DrugReturnActionDetail } from 'NebulaClient/Model/AtlasClientModel';

export class DrugOrderTransactionService {
    public static async GetRestDose(drugOrder: DrugOrder): Promise<number> {
        let url: string = '/api/DrugOrderTransactionService/GetRestDose';
        let input = { 'drugOrder': drugOrder };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetRestTransaction(context: TTObjectContext, material: Material, episode: Episode): Promise<Array<DrugOrderTransaction>> {
        let url: string = '/api/DrugOrderTransactionService/GetRestTransaction';
        let input = { 'context': context, 'material': material, 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderTransaction>>(url, input);
        return result;
    }
    public static async GetEmployableRestDose(drugOrder: DrugOrder): Promise<number> {
        let url: string = '/api/DrugOrderTransactionService/GetEmployableRestDose';
        let input = { 'drugOrder': drugOrder };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
    public static async GetPatientRestDose(material: Material, episode: Episode): Promise<Dictionary<Object, number>> {
        let url: string = '/api/DrugOrderTransactionService/GetPatientRestDose';
        let input = { 'material': material, 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Dictionary<Object, number>>(url, input);
        return result;
    }
    public static async GetDrugOrderTransactions(material: Material, episode: Episode): Promise<Dictionary<Object, number>> {
        let url: string = '/api/DrugOrderTransactionService/GetDrugOrderTransactions';
        let input = { 'material': material, 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Dictionary<Object, number>>(url, input);
        return result;
    }
    public static async GetReturnableDrugOrderTransactions(episode: Episode): Promise<Dictionary<DrugOrderTransaction, number>> {
        let url: string = '/api/DrugOrderTransactionService/GetReturnableDrugOrderTransactions';
        let input = { 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Dictionary<DrugOrderTransaction, number>>(url, input);
        return result;
    }
    /*public static async GetDrugOrderTransactions(DRUGORDEREPISODE: string, DRUGORDERMATERIAL: string): Promise<Array<DrugOrderTransaction>> {
        let url: string = "/api/DrugOrderTransactionService/GetDrugOrderTransactions";
        let input = { "DRUGORDEREPISODE": DRUGORDEREPISODE, "DRUGORDERMATERIAL": DRUGORDERMATERIAL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderTransaction>>(url, input);
        return result;
    }*/
    public static async GetDrugOrderTransactionByEpisode(DRUGORDEREPISODE: Guid): Promise<Array<DrugOrderTransaction>> {
        let url: string = '/api/DrugOrderTransactionService/GetDrugOrderTransactionByEpisode';
        let input = { 'DRUGORDEREPISODE': DRUGORDEREPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderTransaction>>(url, input);
        return result;
    }
    public static async GetOuttableDrugOrderTransactions(DRUGORDEREPISODE: string, DRUGORDERMATERIAL: string): Promise<Array<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class>> {
        let url: string = '/api/DrugOrderTransactionService/GetOuttableDrugOrderTransactions';
        let input = { 'DRUGORDEREPISODE': DRUGORDEREPISODE, 'DRUGORDERMATERIAL': DRUGORDERMATERIAL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class>>(url, input);
        return result;
    }
    public static async GetDrugOrderTransactionByEpisodeRQ(DRUGORDEREPISODE: Guid): Promise<Array<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class>> {
        let url: string = '/api/DrugOrderTransactionService/GetDrugOrderTransactionByEpisodeRQ';
        let input = { 'DRUGORDEREPISODE': DRUGORDEREPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class>>(url, input);
        return result;
    }
    public static async GetUsableTransactions(DRUGORDEREPISODE: string, DRUGORDERMATERIAL: string): Promise<Array<DrugOrderTransaction>> {
        let url: string = '/api/DrugOrderTransactionService/GetUsableTransactions';
        let input = { 'DRUGORDEREPISODE': DRUGORDEREPISODE, 'DRUGORDERMATERIAL': DRUGORDERMATERIAL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderTransaction>>(url, input);
        return result;
    }
    public static async GetOuttableDrugOrderTrxEpisode(DRUGORDEREPISODE: string): Promise<Array<DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class>> {
        let url: string = '/api/DrugOrderTransactionService/GetOuttableDrugOrderTrxEpisode';
        let input = { 'DRUGORDEREPISODE': DRUGORDEREPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class>>(url, input);
        return result;
    }

    public static async GetOuttableDrugReturnActionDetail(DRUGORDEREPISODE: string): Promise<Array<DrugReturnActionDetail>> {
        let url: string = '/api/DrugOrderTransactionService/GetOuttableDrugReturnActionDetail';
        let input = { 'DRUGORDEREPISODE': DRUGORDEREPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugReturnActionDetail>>(url, input);
        return result;
    }
}