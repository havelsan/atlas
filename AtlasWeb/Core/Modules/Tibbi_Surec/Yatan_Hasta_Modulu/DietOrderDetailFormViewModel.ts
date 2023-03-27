//$2C9572C7
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DietOrderDetail, EpisodeAction, InPatientPhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';
import { MealTypes } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { DietOrderData } from "../Hasta_Gecmisi/PatientHistoryFormViewModel";

export class DietOrderDetailFormViewModel extends BaseViewModel {
    @Type(() => DietOrderDetail)
    public _DietOrderDetail: DietOrderDetail = new DietOrderDetail();
    @Type(() => MealTypes)
    public MealTypess: Array<MealTypes> = new Array<MealTypes>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => InpatientExtraInfo)
    public _inpatientExtraInfo: InpatientExtraInfo = new InpatientExtraInfo();
    @Type(() => DietLabTestResultList)
    public _DietLabTestResultList: Array<DietLabTestResultList> = new Array<DietLabTestResultList>();
    @Type(() => InPatientPhysicianApplication)
    public InPatientPhyApp: InPatientPhysicianApplication = null;
    @Type(() => DietOrderData)
    public DietOrderList: Array<DietOrderData>;
}

export class InpatientExtraInfo {
    public BedName: string;
    public RoomName: string;
    public RoomGroupName: string;
    public ResponsibleDoctor: string;
}

export class DietLabTestResultList {
    public ObjectID: string;
    public TestName: string;
    public ResultDate: string;
    public Reference: string;
    public Result: string;
}


