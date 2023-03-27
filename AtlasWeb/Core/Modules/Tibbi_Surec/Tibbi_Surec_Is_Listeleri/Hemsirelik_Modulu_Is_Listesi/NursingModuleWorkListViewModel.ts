//$DB89F690
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseEpisodeActionWorkListSearchCriteria, BaseEpisodeActionWorkListItem, BaseEpisodeActionWorkListFormViewModel } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel";
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionWorkListStateItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";

export class NursingModuleWorkListViewModel extends BaseEpisodeActionWorkListFormViewModel {
    @Type(() => NursingModuleWorkListItem)
    WorkList: Array<NursingModuleWorkListItem> = new Array<NursingModuleWorkListItem>();
    @Type(() => NursingModuleWorkListSearchCriteria)
    _SearchCriteria: NursingModuleWorkListSearchCriteria = new NursingModuleWorkListSearchCriteria();
    // _SearchCriteria  dx-tag-box 'ı doldurmak için
    @Type(() => ResSection)
    ResourceList: Array<ResSection> = new Array<ResSection>();
    @Type(() => EpisodeActionWorkListStateItem)
    public DrugOrderWorkListStateItem: Array<EpisodeActionWorkListStateItem> = new Array<EpisodeActionWorkListStateItem>();
    @Type(() => EpisodeActionWorkListStateItem)
    public NursingOrderWorkListStateItem: Array<EpisodeActionWorkListStateItem> = new Array<EpisodeActionWorkListStateItem>();
    @Type(() => Boolean)
    public GicActive: boolean;
}

export class NursingModuleWorkListSearchCriteria extends BaseEpisodeActionWorkListSearchCriteria {
    @Type(() => ResSection)
    public Resources: Array<ResSection>;
    @Type(() => EpisodeActionWorkListStateItem)
    public DrugOrderStatesItem: Array<EpisodeActionWorkListStateItem>;
    @Type(() => EpisodeActionWorkListStateItem)
    public NursingOrderStateItem: Array<EpisodeActionWorkListStateItem>;
    @Type(() => ListObject)
    public InpatientTypeResources: Array<ListObject>;
    @Type(() => Number)
    public PatientType: number;
    @Type(() => Number)
    public ActionType: number;
    public ProtocolNo: string;
}

export class NursingModuleWorkListItem extends BaseEpisodeActionWorkListItem {

    @Type(() => Date)
    public startDate: Date;
    @Type(() => Date)
    public endDate: Date;
    public PatientNameSurname: string;
    public text: string;
    public statusName: string;
    public Result: string;
    public doctorDescription: string;
    public MasterResourceName: string;
    public RoomAndBedName: string;
    public ResponsibleNurse: string;

    public DoctorName: string;
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
    public Companion: string;
    public ProcedureByUser: string;
    @Type(() => Date)
    public ExecutionDate: Date;

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

}

export class InputFor_StateUpdateForSelecetedItem {
    public DrugOrderDetails: Array<Guid>;
}

export class ListObject {
    public TypeName: string;
    @Type(() => Number)
    public TypeID: number;
}

export class UnnotifiedBaseTreatmentMaterialViewModel {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Date)
    public ActionDate: Date;
    public Patientname: string;
    public Storename: string;
    public Materialname: string;
    @Type(() => Number)
    public Amount: number;
    public Barcode: string;
    public DistributionType: string;
    public Note: string;
    public Utsusenotification: string;
    public ProtocolNo:string;
}


