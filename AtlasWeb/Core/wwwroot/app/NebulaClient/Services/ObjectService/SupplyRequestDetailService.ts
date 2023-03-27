//$06A30387
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { SupplyRequestDetail } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestPoolDetail } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

export class SupplyRequestDetailService {
    public static async GetSupplyReqDetsByStoreAndDemandType(STORE: Guid, DEMANDTYPE: SupplyRequestTypeEnum): Promise<GetSupplyReqDetsByStoreAndDemandType_Output> {
        let url: string = "/api/SupplyRequestDetailService/GetSupplyReqDetsByStoreAndDemandType";
        let input = { "STORE": STORE, "DEMANDTYPE": DEMANDTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetSupplyReqDetsByStoreAndDemandType_Output>(url, input);
        return result;
    }

    public static async GetHospitalExcessStocks(input: HospitalExcessStockItem_Input): Promise<ExcessStocks_Output> {
        let url: string = "/api/SupplyRequestDetailService/GetHospitalExcessStocks";
        let params = { "malzemeObjectID": input.malzemeObjectID};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ExcessStocks_Output>(url, params );
        return result;
    }

    public static async GetMKYSExcessStocks(input: MKYSExcessStockItem_Input): Promise<ExcessStocks_Output> {
        let url: string = "/api/SupplyRequestDetailService/GetMKYSExcessStocks";
        let params = {"malzemeAdi": input.malzemeAdi, "malzemeKodu": input.malzemeKodu, "ilAdi": input.ilAdi, "birimAdi": input.birimAdi};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ExcessStocks_Output>(url, params);
        return result;
    }

    public static async GetStockCardInfoByMaterial(input: StockCardInfo_Input): Promise<StockCardInfo_Output> {
        let url: string = "/api/SupplyRequestDetailService/GetStockCardInfoByMaterial";
        let params = { "MaterialID": input.MaterialID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<StockCardInfo_Output>(url, params);
        return result;
    }
}

export class StockCardInfo_Output {
    public NatoStockNo: string;
}
export class StockCardInfo_Input {
    public MaterialID: string;
}


export class GetSupplyReqDetsByStoreAndDemandType_Output {
    public supplyRequestPoolDetails: Array<SupplyRequestPoolDetail>;
    public supplyRequestDetails: Array<SupplyRequestDetail>;
}

export class ExcessStockItem {
    public siraNo: string;
    public malzemeKodu: string;
    public malzemeDigerAciklama: string;
    public malzemeAdi: string;
    public adeti: string;
    public vergiliBirimFiyat: string;
    public tarih: Date;
    public ilAdi: string;
    public ilKodu: string;
    public birimAdi: string;
}
export class MKYSExcessStockItem_Input {
    public malzemeAdi: string;
    public malzemeKodu: string;
    public ilAdi: string;
    public birimAdi: string;
}
export class ExcessStockItemForStore {
    public depoAdi: string;
    public adeti: string;
}
export class HospitalExcessStockItem_Input {
    public malzemeObjectID: string;
}

export class ExcessStocks_Output {
    public excessStockList: ExcessStockItem[];
    public excessStockStoreList: ExcessStockItemForStore[];
}