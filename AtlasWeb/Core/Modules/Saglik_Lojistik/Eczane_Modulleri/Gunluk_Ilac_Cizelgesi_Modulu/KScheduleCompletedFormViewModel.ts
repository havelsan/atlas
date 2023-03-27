//$824C80DA
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { KSchedule, DrugUsageTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { KScheduleMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { KScheduleUnListMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { KSchedulePatienOwnDrug } from "NebulaClient/Model/AtlasClientModel";
import { KScheduleMaterialRowViewModel } from 'NebulaClient/Services/ObjectService/KScheduleService';

export class KScheduleCompletedFormViewModel extends BaseViewModel {
    @Type(() => KSchedule)
    public _KSchedule: KSchedule = new KSchedule();
    @Type(() => KScheduleMaterial)
    public StockActionOutDetailsGridList: Array<KScheduleMaterial> = new Array<KScheduleMaterial>();
    @Type(() => KScheduleUnListMaterial)
    public ttgrid2GridList: Array<KScheduleUnListMaterial> = new Array<KScheduleUnListMaterial>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockLevelType)
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => KSchedulePatienOwnDrug)
    public KSchedulePatienOwnDrugsGridList: Array<KSchedulePatienOwnDrug> = new Array<KSchedulePatienOwnDrug>();

    @Type(() => KScheduleMaterialRowViewModel)
    public KScheduleMaterialRowViewModelList: Array<KScheduleMaterialRowViewModel> = new Array<KScheduleMaterialRowViewModel>();
}

export class InpatientHasDrugListDTO {
    public OutStatus: string;
    public PlannedStartTime: Date;
    public PlannedEndTime: Date;
    public DrugName: string;
    public EhuStatus: string;
    public Dose: string;
    public DoseAmount: string;
    public Day: string;
    public Amount: string;
    public Desciption: string;
    public IsImmediately: boolean;
    public PatientOwnDrug: boolean;
    public CaseOfNeed: boolean;
    public TreatmentType: DrugUsageTypeEnum;
    public DoctorName: string;
    public ClinikName: string;
    public MaterialType:string;

}
