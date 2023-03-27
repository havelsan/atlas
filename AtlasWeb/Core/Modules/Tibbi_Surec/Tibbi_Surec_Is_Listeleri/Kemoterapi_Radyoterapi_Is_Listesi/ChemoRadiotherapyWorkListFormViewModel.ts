//$DB89F690
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { ResTreatmentDiagnosisUnit, ResSection, PatientStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionWorkListStateItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";

export class ChemoRadiotherapyWorkListFormViewModel extends BaseViewModel {

    @Type(() => ChemoRadiotherapyWorkListItemModel)
    ChemoRadiotherapyActionList: Array<ChemoRadiotherapyWorkListItemModel> = new Array<ChemoRadiotherapyWorkListItemModel>();

    @Type(() => ChemoRadiotherapyWorkListItemModel)
    _ChemoRadiotherapyWorkListSearchCriteria: ChemoRadiotherapyWorkListSearchCriteria = new ChemoRadiotherapyWorkListSearchCriteria;

    @Type(() => ResTreatmentDiagnosisUnit)
    TreatmentDiagnosisUnitList: Array<ResTreatmentDiagnosisUnit> = new Array<ResTreatmentDiagnosisUnit>();

    @Type(() => ResSection)
    FromResourceList: Array<ResSection> = new Array<ResSection>();
}

export class ChemoRadiotherapyWorkListItemModel {
    public ObjectID: Guid;
    public ObjectDefID: Guid;
    public ObjectDefName: string;
    public PatientNameSurname: string;
    public PatientRefNo: string;
    public PatientStatus: string;

    @Type(() => Date)
    public StartDate: Date;

    @Type(() => Date)
    public FinishDate: Date;

    public AdmissionNumber: string;
    public ChemoRadiotherapyState: string;
    public IsPatientDischarged: PatientStatusEnum;
    public IsReportRequired: string;
    public FromResource: string;
    public ProcedureDoctor: string;
}
export class ChemoRadiotherapyWorkListSearchCriteria {
    @Type(() => Date)
    public WorkListStartDate: Date;

    @Type(() => Date)
    public WorkListEndDate: Date;

    public AdmissionNumber: string;
    public RefNo: string;

    @Type(() => ResTreatmentDiagnosisUnit)
    public TreatmentDiagnosisUnit: Array<ResTreatmentDiagnosisUnit> = new Array<ResTreatmentDiagnosisUnit>();

    @Type(() => EpisodeActionWorkListStateItem)
    public ChemoRadioTherapyState: Array<EpisodeActionWorkListStateItem> = new Array<EpisodeActionWorkListStateItem>();

    public FromResource: Array<ResSection>;
    public Patienttype: number;
    public PatientObjectID: string;

}