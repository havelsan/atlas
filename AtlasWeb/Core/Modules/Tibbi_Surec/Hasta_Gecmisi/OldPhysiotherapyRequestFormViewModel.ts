//$89C449A6
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PhysiotherapyRequest } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';

export class OldPhysiotherapyRequestFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldPhysiotherapyRequestFormViewModel, Core';

    @Type(() => PhysiotherapyRequest)
    public _PhysiotherapyRequest: PhysiotherapyRequest = new PhysiotherapyRequest();

    public ProcedureDoctorName: string;


    @Type(() => OrderInfo)
    public PhysiotherapyOrderList: Array<OrderInfo>;

    @Type(() => OrderDetailInfo)
    public AdditionalOrderDetailInfoList: Array<OrderDetailInfo> = new Array<OrderDetailInfo>();

    @Type(() => OrderDetailInfo)
    public OrderDetailInfoList: Array<OrderDetailInfo>;
}

export class PhysiotherapyInfo {
    public TreatmentDiagnosisUnit: string;
    public ProcedureObject: string;
    public PhysiotherapyStartDate: Date;
    public TreatmentProperties: string;
    public Duration: number;
    public FTRApplicationAreaDef: string;
    public Dose: string;
    public PackageProcedure: string;
    public ApplicationArea: string;
    public DoseDurationInfo: string;
    public ReportNo: string;
}

export class OrderDetailInfo {
    public SessionNumber: string;
    public PlannedDate: Date;
    public PhysiotherapyState: string;
    public ApplicationArea: string;
    public ApplicationAreaInfo: string;
    public TreatmentDiagnosisUnit: string;
    public Duration: string;
    public Dose: string;
    public NoteToPhysiotherapist: string;
    public Physiotherapist: string;
    public IsAdditionalProcess: Boolean;
    public IsAdditionalTreatment: Boolean;
    public CurrentUserObjectId: Guid;
    public ProcedureObject: string;
    public Package: string;
    public TreatmentProperties: string;

    public StartDate: Date;
    public FinishDate: Date;

    @Type(() => ResUser)
    public ResponsiblePhysiotherapist: ResUser;
}
export class OrderInfo {
    public TreatmentDiagnosisUnit: string;
    public ApplicationArea: string;
    public ApplicationAreaInfo: string;
    public ProcedureObject: string;
    public SessionCount: number;
    public Duration: string;
    public Dose: string;
    public TreatmentProperties: string;

    public IsPlannedBefore: boolean;

    @Type(() => Guid)
    public CurrentStateDefID: Guid;

    @Type(() => Guid)
    public OrderObjectId: Guid;

    @Type(() => Guid)
    public OrderObjectDefId: Guid;
}