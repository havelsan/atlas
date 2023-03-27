import { BaseModel } from 'Fw/Models/BaseModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class EpisodeActionDisplayFormViewModel extends BaseModel {

    public ObjectID: string;
    public ObjectDefName: string;
    public FormDefID: string;
    public InputParam: any;

}

export class ActiveInfoDVO {
    public EpisodeActionObjectID: Guid;
    public EpisodeObjectID: Guid;
    public PatientObjectID: Guid;
}