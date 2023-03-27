import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from "NebulaClient/Mscorlib/Guid";

export class MainPatientFolderFormViewModel extends BaseViewModel {
    public SubEpisodeList: Array<SubEpisodeData>;
    public EpisodeActionList: Array<EpisodeActionData>;
}

export class SubEpisodeData {
    public ObjectID: Guid;
    @Type(() => Date)
    public OpeningDate: Date;
    public ProtocolNo: string;
    public SpecialityName: string;
    public DoctorName: string;
    public PatientStatus: string;
    public AdmissionType: string;
    @Type(() => Date)
    public ClosingDate: Date;
}

export class EpisodeActionData {
    public ObjectID: Guid;
    public ObjectDefName: string;
    public FromResourceName: string;
    public MasterResourceName: string;
    @Type(() => Date)
    public ActionDate: Date;
    public ObjectName: string;
    public State: string;
    public DoctorName: string;
    public Description: string;
    public IsOldAction: boolean;
}