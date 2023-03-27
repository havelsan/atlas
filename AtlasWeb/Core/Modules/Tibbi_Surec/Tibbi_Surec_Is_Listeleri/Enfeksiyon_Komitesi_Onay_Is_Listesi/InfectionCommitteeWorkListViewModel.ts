//$DB89F690
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseEpisodeActionWorkListFormViewModel, BaseEpisodeActionWorkListSearchCriteria, BaseEpisodeActionWorkListItem } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel";
import { ResSection, ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';

export class InfectionCommitteeWorkListViewModel extends BaseEpisodeActionWorkListFormViewModel {
    @Type(() => InfectionCommitteeWorkListItem)
    WorkList: Array<InfectionCommitteeWorkListItem> = new Array<InfectionCommitteeWorkListItem>();
    _SearchCriteria: InfectionCommitteeWorkListSearchCriteria = new InfectionCommitteeWorkListSearchCriteria();
    // _SearchCriteria  dx-tag-box 'ı doldurmak için
    @Type(() => ResSection)
    ResourceList: Array<ResSection> = new Array<ResSection>();
    DoctorList: Array<ResUser.DoctorListNQL_Class> = new Array<ResUser.DoctorListNQL_Class>();

}



export class InfectionCommitteeWorkListSearchCriteria extends BaseEpisodeActionWorkListSearchCriteria {
    @Type(() => ResSection)
    public Resources: Array<ResSection>;
    public ProtocolNo: string;
    public MinAge: number = 0;
    public MaxAge: number = 150;
    public SelectedState: number;
    @Type(() => Guid)
    public SelectedDoctor: Array<Guid> = new Array<Guid>();
}


export class InfectionCommitteeWorkListItem extends BaseEpisodeActionWorkListItem {
    @Type(() => Date)
    public Date: Date; 
    public PatientNameSurname: string; 
    public KabulNo: string; 
    public UniqueRefno: string;
    public MasterResource: string;
    public RoomResource: string; 
    public Room: string;
    public Bed: string; 
    public DoctorName: string; 
    @Type(() => Date)
    public InpatientDate: Date; 
}


