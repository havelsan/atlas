
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { CashOfficeWorkListResultModel } from "../CashOfficeWorkList/CashOfficeWorkListFormViewModel";
import { PatientDebtTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { BaseModel } from 'Fw/Models/BaseModel';
import { DateTime } from 'NebulaClient/System/Time/DateTime';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class CashOfficePatientFormViewModel extends BaseViewModel {
    CashOfficeWorkListResultModel: CashOfficeWorkListResultModel[];
    CashOfficePatientSearchModel: CashOfficePatientSearchModel;
    CashOfficePatientDetailModel: CashOfficePatientDetailModel;
    PatientOldDebtFormModel: PatientOldDebtFormModel;
    CashOfficePatientResultModel: CashOfficePatientResultModel[];
    public Roles: any;
    constructor() {
        super();
        this.CashOfficeWorkListResultModel = new Array<CashOfficeWorkListResultModel>();
        this.CashOfficePatientSearchModel = new CashOfficePatientSearchModel();
        this.CashOfficePatientDetailModel = new CashOfficePatientDetailModel();
        this.CashOfficePatientResultModel = new Array<CashOfficePatientResultModel>();
        this.PatientOldDebtFormModel = new PatientOldDebtFormModel();
    }
}
//Hasta arama kriteri modeli
export class CashOfficePatientSearchModel {
    public EpisodeID?: number;
    public TCNo: string;
    public Name: string;
    public FirstName: string;
    public LastName: string;
    public ApplicationStartDate: Date = new Date();
    public ApplicationEndDate: Date = new Date();
    public SelectedDebtType: PatientDebtTypeEnum;
    public SelectedBuilding: Guid;
    public SelectedPayerDefinition: Guid;
    constructor() { }
}

//Hasta detay bilgilerinin doldurulacağı model
export class CashOfficePatientDetailModel {
    public EpisodeID: string;
    public FullName: string;
    public BirthDate: string;
    public FatherName: string;
    public MotherName: string;
    public TCNo: string;
    public ServiceName: string;
    public ServiceTotal: Currency;
    public BackPrice: Currency;
    public TotalReceiptPayment: string;
    public AdvancePayment: Currency;
    public RemainingDebt: Currency;
    public BondTotal: Currency;
    public PayerProtocol: string;
    public MedulaSigortaliTuru: string;
    constructor() { }
}
//Episode - Hasta bilgilerinin doldurulacağı model
export class CashOfficePatientResultModel extends BaseModel {
    public EpisodeObjectID: Guid;
    public PatientObjectID: Guid;
    public EpisodeID: string;
    public FullName: string;
    public TotalDebt?: Currency;
    public Date: Date;
    public TCNo: string;
}

export class PatientOldDebtFormModel
{
    public PatientObjectID: Guid;
    public PayeeName: string;
    public TotalPrice: number;
    public Date: DateTime;
    public DocumentNo: string;
    public PatientOldDebtTransactionDebtModel: Array<PatientOldDebtTransactionDebtModel>;
    public PaymentType: number;

    constructor()
    {
        this.PatientOldDebtTransactionDebtModel = new Array<PatientOldDebtTransactionDebtModel>();
    }
}

export class PatientOldDebtTransactionDebtModel
{
    public ProcedureCode: string;
    public ProcedureName: string;
    public ProcedureType: string;
    public TransActionDebt: number;
}