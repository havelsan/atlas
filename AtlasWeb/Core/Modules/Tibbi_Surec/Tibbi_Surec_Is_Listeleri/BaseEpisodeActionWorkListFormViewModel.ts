import { BaseModel } from 'Fw/Models/BaseModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { FollowingPatients } from 'app/NebulaClient/Model/AtlasClientModel';

export class BaseEpisodeActionWorkListFormViewModel extends BaseModel {

    maxWorklistItemCount: number;
    timerPeriod: number;
    autoRefreshWorkList : boolean;

    @Type(() => FollowingPatients)
    public TrackingPatientsList: Array<FollowingPatientList> = new Array<FollowingPatientList>();
}


export class BaseEpisodeActionWorkListSearchCriteria {
    @Type(() => Date)
    public WorkListStartDate: Date;
    @Type(() => Date)
    public WorkListEndDate: Date;
    public PatientObjectID: string;

}

export class BaseEpisodeActionWorkListItem {

    public ObjectDefName: string;
    public ObjectDefID: string;
    @Type(() => Guid)
    public ObjectID: Guid;
    public CompComponetOpeningInputParam: any;


    public isEmergency: boolean;
    public isPregnant: boolean;
    public isYoung: boolean;
    public isOld: boolean;
    public isVetera: boolean;
    public isDisabled: boolean;
    public hasMedicalInformation: boolean ;
    public RowColor: string;
    public MedicalInformation: string;
    public isPatientDrugAllergic: boolean;
    public isPatientFoodAllergic: boolean;
    public isPatientOtherAllergic: boolean;
    public PatientCallStatus: string;
    public TriageColor: string;
}


export class ActiveInfoDVO {
    @Type(() => Guid)
    public EpisodeActionObjectID: Guid;
    @Type(() => Guid)
    public EpisodeObjectID: Guid;
    @Type(() => Guid)
    public PatientObjectID: Guid;
}

export class FollowingPatientList 
{
    @Type(() => Guid)
    public ObjectID: Guid ;
    @Type(() => Guid)
    public PatientID: Guid ;
    public Name: string ;
    public ProtocolNO: string ;
    public UniqueRefNo: string ;
    @Type(() => Date)
    public StartDate: Date ;
    @Type(() => Date)
    public EndDate: Date ;
    public CurrentState: string ;
    public Type: string ; 
}