//$7FA10E5A
import { SubActionProcedure, EpisodeAction, UserTitleEnum, ResDepartment, ResClinic } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { Type } from 'app/NebulaClient/ClassTransformer';
import List from 'app/NebulaClient/System/Collections/List';

export class RequestedProceduresFormViewModel extends BaseViewModel {

    public MyRequestedProcedures: Array<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> = new Array<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class>();
    
}

export class InputModelForDoctorList
{
    public EpisodeAction: EpisodeAction;
    public SelectedObjectID: Guid;
    public filter: string;
}
export class DoctorModel
{
    public Name: string;
    public Title: UserTitleEnum;
    public ObjectID: Guid;
}

export class PackageModel
{
    public Name: string;
    public ObjectID: Guid;
}

export class AdditionalAppModel
{
    public Name: string;
    public ObjectID: Guid;
    public Code: string;
    public DailyMedulaProvisionNecessity: boolean;
}
export class ClinicResultModel
{
    @Type(() => ResClinic)
    public ClinicList: List<ResClinic> = new List<ResClinic>();
    public DefaultClinic: ResClinic;
}

export class ObjectIDForAI {
    public objectId: Guid;
}