//$DB89F690
import { BaseModel } from 'Fw/Models/BaseModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseEpisodeActionWorkListSearchCriteria, BaseEpisodeActionWorkListItem, BaseEpisodeActionWorkListFormViewModel } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel";
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionWorkListStateItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";

export class HealthCommitteeWorkListViewModel extends BaseEpisodeActionWorkListFormViewModel {
    @Type(() => HealthCommitteeWorkListItem)
    WorkList: Array<HealthCommitteeWorkListItem> = new Array<HealthCommitteeWorkListItem>();
    @Type(() => HealthCommitteeWorkListSearchCriteria)
    _SearchCriteria: HealthCommitteeWorkListSearchCriteria = new HealthCommitteeWorkListSearchCriteria();
    // _SearchCriteria  dx-tag-box 'ı doldurmak için
    @Type(() => HCRequestReason)
    HCRequestReasonList: Array<HCRequestReason>

}

export class HealthCommitteeWorkListSearchCriteria extends BaseEpisodeActionWorkListSearchCriteria {
    @Type(() => ListObject)
    public HCStateItems: Array<ListObject>;
    // @Type(() => HCRequestReason)
    public _HCRequestReason: string;// = new HCRequestReason();
    @Type(() => Number)
    public VoteStatus: number;
    public ProtocolNo: string;

}

export class HealthCommitteeWorkListItem extends BaseEpisodeActionWorkListItem {

    @Type(() => Date)
    public startDate: Date;
    @Type(() => Date)
    public endDate: Date;
    public PatientNameSurname: string;
    public statusName: string;
    public ReportName: string;
    public ExaminationStatus: string;

    public KabulNo: string;
    public ComingReason: string;
    public PhoneNumber: string;
    public PayerInfo: string;
    @Type(() => Date)
    public BirthDate: Date;
    public FatherName: string;
    public UniqueRefno: string;
    public HastaTuru: string;
    public BasvuruTuru: string;

    @Type(() => Boolean)
    public HasTightContactIsolation: boolean;
    @Type(() => Boolean)
    public HasFallingRisk: boolean;
    @Type(() => Boolean)
    public HasDropletIsolation: boolean;
    @Type(() => Boolean)
    public HasAirborneContactIsolation: boolean;
    @Type(() => Boolean)
    public HasContactIsolation: boolean;
    public OzelDurum: string;
    public StateID: string;

}

export class ListObject {
    public TypeName: string;
    @Type(() => Number)
    public TypeID: number;
}


