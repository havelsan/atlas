//$DB89F690
import { BaseModel } from 'Fw/Models/BaseModel';
import { ResUser, UserOptionType } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { EpisodeActionWorkListStateItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";

export class OrtezProtezWorkListViewModel extends BaseModel {
    @Type(() => OrtezProtezWorkListItemModel)
    OrtezProtezActionList: Array<OrtezProtezWorkListItemModel> = new Array<OrtezProtezWorkListItemModel>();
    _ortezProtezWorkListSearchCriteria: OrtezProtezWorkListSearchCriteria = new OrtezProtezWorkListSearchCriteria();
}

export class OrtezProtezWorkListItemModel {

    public ObjectID: string;
    public UniqueRefno: string;
    public PatientNameSurname: string;
    @Type(() => Date)
    public RequestDate: Date;
    public Amount: string;
    public ProcedureName: string;
    public ProcedureCode: string;
    public CodeandName: string;
    public ProcedureObjectID: string;
    public Side: string;
    public Technician: string;
    public Protocolno: string;
    public Kurum: string;
    public SigortaliTuruAdi: string;
    @Type(() => Date)
    public BranchDate: Date;
    public CurrentState: string;
    public KabulNo: string;
}

export class OrtezProtezWorkListSearchCriteria {
    @Type(() => Date)
    public workListStartDate: Date;
    @Type(() => Date)
    public workListEndDate: Date;
    @Type(() => Number)
    public patienttype: number;
    @Type(() => EpisodeActionWorkListStateItem)
    public ortezProtezWorkListStateItem: Array<EpisodeActionWorkListStateItem> = new Array<EpisodeActionWorkListStateItem>();
    public uniqueRefno: string;
    public patientObjectID: string;
    public kabulNo: string;
    @Type(() => ResUser)
    public requesterDoctor: ResUser;

    constructor() {
    }

}

export class UserOptionInputDVO {
    public UserOptionType: UserOptionType;
    public OptionValue: string;
}
