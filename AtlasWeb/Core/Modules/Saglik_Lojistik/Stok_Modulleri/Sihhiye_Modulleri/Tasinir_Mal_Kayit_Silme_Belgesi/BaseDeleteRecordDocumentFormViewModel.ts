//$B6F8824F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseDeleteRecordDocument } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspectionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspection } from 'NebulaClient/Model/AtlasClientModel';

export class BaseDeleteRecordDocumentFormViewModel extends BaseViewModel {
    public _BaseDeleteRecordDocument: BaseDeleteRecordDocument = new BaseDeleteRecordDocument();
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    public StockActionInspectionDetailsStockActionInspectionDetailGridList: Array<StockActionInspectionDetail> = new Array<StockActionInspectionDetail>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public Stores: Array<Store> = new Array<Store>();
    public StockActionInspections: Array<StockActionInspection> = new Array<StockActionInspection>();
}
