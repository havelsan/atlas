//$3E50D1AE
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PhysiotherapyRequest } from "NebulaClient/Model/AtlasClientModel";


import { Type } from 'NebulaClient/ClassTransformer';

export class PhysiotherapyRequestFormViewModel extends BaseViewModel {

    @Type(() => PhysiotherapyRequest)
    public _PhysiotherapyRequest: PhysiotherapyRequest = new PhysiotherapyRequest();
    public MedicalInfo: string;

    //@Type(() => OrderInfo)
    //public PhysiotherapyOrderList: Array<OrderInfo> = new Array<OrderInfo>();
}

//export class OrderInfo {
//    public TreatmentDiagnosisUnit: string;
//    public ApplicationArea: string;
//    public ApplicationAreaInfo: string;
//    public ProcedureObject: string;
//    public SessionCount: number;
//    public Duration: string;
//    public Dose: string;
//    public TreatmentProperties: string;

//    public IsPlannedBefore: boolean;

//    @Type(() => Guid)
//    public CurrentStateDefID: Guid;

//    @Type(() => Guid)
//    public OrderObjectId: Guid;

//    @Type(() => Guid)
//    public OrderObjectDefId: Guid;
//}