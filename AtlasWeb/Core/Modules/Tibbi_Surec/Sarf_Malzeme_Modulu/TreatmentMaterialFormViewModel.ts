
import { BaseTreatmentMaterial, DrugReportType, SubEpisode, EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class TreatmentMaterialFormViewModel extends BaseViewModel {
    @Type(() => Object)
    public _selectedMaterialValue: Object;
    @Type(() => Store)
    public _selectedStoreValue: Store;
    //public AddedTreatmentMaterial: BaseTreatmentMaterial;
    //public material: Material;
    //public Barcode: string;
    //public StockCard: StockCard;
    //public DistributionTypeDef: DistributionTypeDefinition;
    //public DistributionType: string;
    @Type(() => AddedTreatmentMaterialsViewModel)
    public AddedTreatmentMaterials: Array<AddedTreatmentMaterialsViewModel>;
    @Type(() => Date)
    public ActionDate: Date;
    countForDailyOperations: number = 0;
}

export class AddedTreatmentMaterialsViewModel {
    @Type(() => BaseTreatmentMaterial)
    public AddedTreatmentMaterial: BaseTreatmentMaterial;
    @Type(() => Material)
    public material: Material;
    public Barcode: string;
    @Type(() => StockCard)
    public StockCard: StockCard;
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDef: DistributionTypeDefinition;
    public DistributionType: string;
    @Type(() => Date)
    public TransactionDate: Date;
    public drugSpecification: string;
   public DrugReportType: DrugReportType;
    @Type(() => MaterialProcedureViewModel)
    MaterialProcedureViewModelList: Array<MaterialProcedureViewModel> = new Array<MaterialProcedureViewModel>();
    @Type(() => SubEpisode)
    public subEpisode: SubEpisode;
    @Type(() => EpisodeAction)
    public episodeAction: EpisodeAction;
}



export class AddedTreatmentMaterialInputDVO {
    public AddedTreatmentMaterials: Array<TreatmentMaterialInputDVODetail>;
    public EpisodeActionObjectDefID: string;
    @Type(() => Date)
    public ActionDate: Date;
    @Type(() => Guid)
    public SubEpisodeGuid: Guid;
    public TreatmentMaterialTypeName: string;
    @Type(() => Guid)
    public EpisodeActionMasterResourceId: Guid;
}

export class TreatmentMaterialInputDVODetail {
    public MaterialObjectID: string;
    public Amount: number;
    @Type(() => Date)
    public TransactionDate: Date;
}

export class TreatmentMaterialStartUpViewModel {
    @Type(() => Date)
    public MaxDate: Date;
    @Type(() => Date)
    public MinDate: Date;
    @Type(() => Date)
    public DefaultDate: Date;
    public ProtocolNo: string;
}

export class BaseTreatmentMaterialUTSUsageNotificationResultViewModel {
    @Type(() => Guid)
    public ObjectId: Guid;
    public UTSUseNotificationState: string;
    public Message: string;
}
export class GetTreatmentMaterialDetail_Input{
    @Type(() => BaseTreatmentMaterial)
    public Material: BaseTreatmentMaterial;
}

export class MaterialProcedureViewModel {
    ProcedureName: string;
    @Type(() => Guid)
    ProcedureObjectId: Guid;
    @Type(() => Guid)
    ProcedureRequestFormDetailObjectId: Guid;
    IsAdditionalApplication: Boolean;
}