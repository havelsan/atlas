//$DB89F690
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { ResTreatmentDiagnosisUnit, ResSection, PatientStatusEnum, ResUser, ResWard, ResClinic } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionWorkListStateItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";

export class InpatientAppWorkListFormViewModel extends BaseViewModel {

    @Type(() => InpatientAppWorkListItemModel)
    InpatientAppWorkList: Array<InpatientAppWorkListItemModel> = new Array<InpatientAppWorkListItemModel>();

    @Type(() => InpatientAppWorkListItemModel)
    _inpatientAppWorkListSearchCriteria: InpatientAppWorkListSearchCriteria = new InpatientAppWorkListSearchCriteria;

    @Type(() => ResUser)
    public DoctorList: Array<ResUser> = new Array<ResUser>();

    @Type(() => ResClinic)
    public ClinicList: Array<ResClinic> = new Array<ResClinic>();
}

export class InpatientAppWorkListItemModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public ObjectDefID: Guid;
    @Type(() => Guid)

    public ObjectDefName: string;
    public PatientNameSurname: string;
    public PatientRefNo: string;
    public AdmissionNumber: string;
    public ClinicName: string;
    public ProcedureDoctor: string;
    public InpatientDay: string;

    @Type(() => Date)
    public AppointmentDate: Date;
    public AppointmentDoctor: string;
    public InpatientAppState: string;
    public IsQueue: boolean;
}
export class InpatientAppWorkListSearchCriteria {
    @Type(() => Date)
    public WorkListStartDate: Date;

    @Type(() => Date)
    public WorkListEndDate: Date;

    public AdmissionNumber: string;
    public RefNo: string;

    @Type(() => ResClinic)
    public ClinicName: Array<ResClinic> = new Array<ResClinic>();
    @Type(() => ResUser)
    public Doctor: Array<ResUser> = new Array<ResUser>();
    public PatientObjectID: string;
    public IsAppDatePast: boolean;
    public IsInpatientSuitable: boolean;
}