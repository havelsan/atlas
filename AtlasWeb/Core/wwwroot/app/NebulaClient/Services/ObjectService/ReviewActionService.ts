//$CC75709F
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ReviewAction, Store, BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockCollectedTrx } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ReviewActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ReviewActionPatientDet } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";

export class SendMkysOutputDocumentForReviewActionTS_Input {
    public reviewAction: ReviewAction;
    public mkysPwd: string;
}

export class SendDeleteMkysOutputDocumentForReviewActionTS_Input {
    public reviewAction: ReviewAction;
    public mkysPwd: string;
}
export class ReviewActionService {


    public static async SendMkysOutputDocumentForReviewActionTS(reviewAction: ReviewAction, mkysPwd: string): Promise<string> {
        let url: string = '/api/ReviewActionService/SendMkysOutputDocumentForReviewActionTS';
        let input: SendMkysOutputDocumentForReviewActionTS_Input = new SendMkysOutputDocumentForReviewActionTS_Input();
        input.reviewAction = reviewAction;
        input.mkysPwd = mkysPwd;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }




    public static async SendDeleteMkysOutputDocumentForReviewActionTS(reviewAction: ReviewAction, mkysPwd: string): Promise<string> {
        let url: string = '/api/ReviewActionService/SendDeleteMkysOutputDocumentForReviewActionTS';
        let input: SendDeleteMkysOutputDocumentForReviewActionTS_Input = new SendDeleteMkysOutputDocumentForReviewActionTS_Input();
        input.reviewAction = reviewAction;
        input.mkysPwd = mkysPwd;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }


    public static async GetDrugOrder(startdate: Date, enddate: Date, reviweAction: ReviewAction, filterStores: Array<Guid>, filterBudgets: Array<Guid>): Promise<ReviewActionService_Output> {
        let url: string = '/api/ReviewActionService/GetDrugOrder';
        let input = { "startdate": startdate, "enddate": enddate, "reviweAction": reviweAction, "filterStores": filterStores, "filterBudgets": filterBudgets };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ReviewActionService_Output>(url, input);
        return result;
    }

    public static async GetFiliterList(): Promise<GetFiliterList_Output> {
        let url: string = '/api/ReviewActionService/GetFiliterList';
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<GetFiliterList_Output>(url);
        return result;
    }

}
export class ReviewActionService_Output {
    public ReviewActionDetails: Array<ReviewActionDetail>;
    public StockCollectedTrxs: Array<StockCollectedTrx>;
    public ReviewActionPatientDets: Array<ReviewActionPatientDet>;
    public filterDescription: string;
}

export class GetFiliterList_Output {
    public stores: Array<Store>;
    public budgets: Array<BudgetTypeDefinition>;
}