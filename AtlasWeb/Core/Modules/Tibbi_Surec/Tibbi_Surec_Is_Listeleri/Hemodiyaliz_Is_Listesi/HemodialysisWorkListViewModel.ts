//$DB89F690
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseEpisodeActionWorkListFormViewModel, BaseEpisodeActionWorkListSearchCriteria, BaseEpisodeActionWorkListItem } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel";
import { ResSection, ResUser, ProvizyonTipi, ResTreatmentDiagnosisUnit, ResEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { EpisodeActionWorkListStateItem } from '../../Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel';

export class HemodialysisWorkListViewModel extends BaseEpisodeActionWorkListFormViewModel {

    @Type(() => HemodialysisWorkListItem)
    WorkList: Array<HemodialysisWorkListItem> = new Array<HemodialysisWorkListItem>();

    @Type(() => HemodialysisWorkListSearchCriteria)
    _SearchCriteria: HemodialysisWorkListSearchCriteria = new HemodialysisWorkListSearchCriteria();

    // _SearchCriteria  dx-tag-box 'ý doldurmak için
    @Type(() => ResTreatmentDiagnosisUnit)
    public TreatmentDiagnosisUnitList: Array<ResTreatmentDiagnosisUnit>;
    @Type(() => ResEquipment)
    public TreatmentEquipmentList: Array<ResEquipment>;

    @Type(() => SelectedHemodialysisStatusItem)
    public SelectedHemodialysisStatusItem: SelectedHemodialysisStatusItem;

}
export class SelectedHemodialysisStatusItem {
    @Type(() => Guid)
    public HemodialysisObjectIdList: Array<Guid> = new Array<Guid>();

    public HemodialysisObjectDefName: string;
}

export class HemodialysisWorkListSearchCriteria extends BaseEpisodeActionWorkListSearchCriteria {
    public WorkListStartDate: Date;
    public WorkListEndDate: Date;
    public TreatmentDiagnosisUnit: Array<ResTreatmentDiagnosisUnit>;
    public TreatmentEquipment: Array<ResEquipment>;
    public HemodialysisState: Array<EpisodeActionWorkListStateItem>;
    public Patienttype: number;

    public Request: boolean;
    public Plan: boolean;
    public Procedure: boolean;
    public Cancelled: boolean;
    public Completed: boolean;
}

export class HemodialysisWorkListItem extends BaseEpisodeActionWorkListItem {
    public PatientNameSurname: string;
    public AdmissionNumber: string;
    public ArchiveNumber: string;
    public UniqueRefno: string;
    public PatientStatus: string;
    public ProcedureDoctor: string;
    public FromResource: string;
    public AdmissionDate: Date;
    public StartDate: Date;
    public FinishDate: Date;
    public HemodialysisState: string;
}

export class UpdateEquipmentViewModel {
    @Type(() => ResTreatmentDiagnosisUnit)
    public TreatmentDiagnosisUnitList: Array<ResTreatmentDiagnosisUnit>;
    @Type(() => ResEquipment)
    public TreatmentEquipmentList: Array<ResEquipment>;
    @Type(() => Boolean)
    public TransferAppointmentsCheck: boolean ;
    @Type(() => Boolean)
    public TransferAllCheck: boolean;
    public Description: string;
    public Count: number;
    @Type(() => ResEquipment)
    public SelectedEquipment: ResEquipment;
    public SelectedEquipmentStatus: number;
    public CountType: number;
    @Type(() => ResTreatmentDiagnosisUnit)
    public TreatmentUnit: ResTreatmentDiagnosisUnit;
    @Type(() => ResEquipment)
    public NotAppointedEquipmentList: Array<ResEquipment>;
    @Type(() => ResEquipment)
    public TransferedEquipment: ResEquipment;


}


