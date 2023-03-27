import { StateStatusEnum } from "NebulaClient/Utils/Enums/StateStatusEnum";
import { listboxObject } from '../Invoice/InvoiceHelperModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { BondNotificationStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PatientStatusEnum } from "NebulaClient/Model/AtlasClientModel";
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class CashOfficeWorkListFormViewModel extends BaseViewModel {
    public CashOfficeWorkListResultModel: CashOfficeWorkListResultModel[];
    public CashOfficeWorkListSearchModel: CashOfficeWorkListSearchModel;
    // public HasNewMainCashOfficeRole:boolean;
    // public HasNewBankDecountPaymentRole:boolean;
    public Roles: any;
    constructor() {
        super();
        this.CashOfficeWorkListResultModel = new Array<CashOfficeWorkListResultModel>();
        this.CashOfficeWorkListSearchModel = new CashOfficeWorkListSearchModel();
    }
}


export class CashOfficeWorkListResultModel {
    public ObjectID: Guid;
    public ObjectDefName: string;
    public Date: Date;
    public State: string;
    public OperationType: string;
    public Id: string;
    public ReceiptNo: string;
    public PaymentPrice: number;
    public UniqueRefNo: string;
    public PatientFullName: string;
    public EpisodeID: number;
    public EpisodeObjectID: Guid;
    public CashierName: string;
}

export class CashOfficeWorkListSearchModel {
    public StartDate: Date = new Date();
    public EndDate: Date = new Date();
    public State?: StateStatusEnum;
    public SelectedOperationTypeListItems: Array<listboxObject> = new Array<listboxObject>();
    public Id?: number;
    public ReceiptNo: string;
    public UniqueRefNo: string;
    public CashierObjID: Guid;
    public CashOfficeID: Guid;
    public PatientStatus?: PatientStatusEnum;
    public BondSearchModel: BondWorkListSearchModel = new BondWorkListSearchModel();
    constructor() { }
}

export class BondWorkListSearchModel {
    public BondDetailStartDate: Date;
    public BondDetailEndDate: Date;
    public SelectedNotificationStatus?: BondNotificationStatusEnum;
    public SelectedBondStates: Array<listboxObject> = new Array<listboxObject>();
    public BondDetailExpired: boolean;
    public BondFirstNotStartDate?: Date;
    public BondFirstNotEndDate?: Date;
    public BondSecondNotStartDate?: Date;
    public BondSecondNotEndDate?: Date;
}