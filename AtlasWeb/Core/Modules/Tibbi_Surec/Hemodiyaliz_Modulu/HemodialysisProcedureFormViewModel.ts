//$AD229011
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { HemodialysisRequest } from "NebulaClient/Model/AtlasClientModel";
import { Type, ClassType } from 'NebulaClient/ClassTransformer';
import { Guid } from "../../../wwwroot/app/NebulaClient/Mscorlib/Guid";
import { EnumItem } from "../../../wwwroot/app/NebulaClient/Mscorlib/EnumItem";
import { IEnumList } from "../../../wwwroot/app/NebulaClient/Mscorlib/IEnumList";

export class HemodialysisProcedureFormViewModel extends BaseViewModel {
    @Type(() => HemodialysisRequest)
    public _HemodialysisRequest: HemodialysisRequest = new HemodialysisRequest();

    public MedicalInfo: string;
    public AnamnesisComplaintInfo: string;
    public AnamnesisPatientHistoryInfo: string;
    public AnamnesisPhysicalExaminationInfo: string;
    public AnamnesisMTSConclusionInfo: string;
    public HideAnamnesisInfoButton: boolean = true;

    @Type(() => HemodialysisOrderDetailInfo)
    public HemodialysisOrderDetailInfoList: Array<HemodialysisOrderDetailInfo>;

    public cancelAllOrderDetails: boolean;
}

export class HemodialysisOrderDetailInfo {

    @Type(() => Guid)
    public OrderDetailObjectID: Guid;
    public OrderDetailObjectDef: string;

    @Type(() => Date)
    public SessionDate: Date;
    public StartTime: string;
    public FinishTime: string;
    public TreatmentEquipment: string;
    public HemodialysisState: string;
    public ProcedureDoctor: string;
    public BloodFlow: string;
    public Intravenous: string;
    public Information: string;
}
