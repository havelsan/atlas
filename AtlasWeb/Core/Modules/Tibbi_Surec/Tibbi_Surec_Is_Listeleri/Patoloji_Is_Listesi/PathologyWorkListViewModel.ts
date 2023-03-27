import { Type } from 'NebulaClient/ClassTransformer';
import { BaseEpisodeActionWorkListSearchCriteria, BaseEpisodeActionWorkListItem, BaseEpisodeActionWorkListFormViewModel } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel";
import { ResSection, SKRSICDOMORFOLOJIKODU } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";

export class PathologyWorkListViewModel extends BaseEpisodeActionWorkListFormViewModel {
    @Type(() => PathologyWorkListItem)
    WorkList: Array<PathologyWorkListItem> = new Array<PathologyWorkListItem>();

    _SearchCriteria: PathologyWorkListSearchCriteria = new PathologyWorkListSearchCriteria();

    @Type(() => ResSection)
    ResourceList: Array<ResSection> = new Array<ResSection>();
    @Type(() => SKRSICDOMORFOLOJIKODU)
    MorphologyList: Array<MorphologyObject> = new Array<MorphologyObject>();
}



export class PathologyWorkListSearchCriteria extends BaseEpisodeActionWorkListSearchCriteria {
    @Type(() => ResSection)
    public Resources: Array<ResSection>;
    @Type(() => MorphologyObject)
    public Morphologies: Array<MorphologyObject>;
    public ProtocolNo: string;
    @Type(() => Number)
    public PatientType: number;
    @Type(() => ListObject)
    public ActionTypes: Array<ListObject>;

    public pathology_EA: boolean;
    public pathologyRequest_EA: boolean;

    //Patoloji Stateleri
    public procedure: boolean; //İşlemde
    public approvement: boolean; //Onaylı
    public senttoapprovement: boolean; //Onay Bekliyor
    public report: boolean; //Rapor Basıldı/Tamamlandı
    public cancel: boolean;//İptal Edildi

    //Patoloji İstek Stateleri
    public accept: boolean; //İstek Kabul
    public request_procedure: boolean; //İşlemde
    public request_cancel: boolean;//İptal Edildi

    //Detaylı Arama
    public MaterialProtocolNo: string;
    public Macroskopi: string;
    public Microskopi: string;
    public PathologyDiagnosis: string;
}

export class PathologyWorkListItem extends BaseEpisodeActionWorkListItem {

    public RequestDate: Date;

    public AdmissionResource: string;

    public PatientType: string;

    public PatientNameSurname: string;

    public PatientTRID: string;
   
    public AdmissionProtocolNo: string;

    public ActionType: string;

    public ActionState: string;

    public RequestResource: string;
    public HasFrozen: boolean = false;



}

export class ListObject {
    public TypeName: string;
    @Type(() => Number)
    public TypeID: number;
}

export class MorphologyObject {
    public ObjectID: string;
    public Name: string;
    public MorfolojiKod: string;
    public MorfolojiTanim: string;
}