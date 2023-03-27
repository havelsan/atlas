//$3CB6F32B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SubSurgery } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryExpend } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { StockCard } from "NebulaClient/Model/AtlasClientModel";
import { DistributionTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { VitalSingsFormViewModel } from 'Modules/Tibbi_Surec/Vital_Bulgular/VitalSingsFormViewModel';
import { SurgeryProcedureFormViewModel } from './SurgeryProcedureFormViewModel';
import { SurgerySummaryFormViewModel } from './SurgerySummaryFormViewModel';

export class SubSurgeryFormViewModel extends BaseViewModel {
    @Type(() => SubSurgery)
    public _SubSurgery: SubSurgery = new SubSurgery();
    @Type(() => SurgeryPersonnel)
    public GridSurgeryPersonnelsGridList: Array<SurgeryPersonnel> = new Array<SurgeryPersonnel>();
    @Type(() => SurgeryExpend)
    public GridSurgeryExpendsGridList: Array<SurgeryExpend> = new Array<SurgeryExpend>();
    @Type(() => DirectPurchaseGrid)
    public DirectPurchaseGridsGridList: Array<DirectPurchaseGrid> = new Array<DirectPurchaseGrid>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => Surgery)
    public Surgerys: Array<Surgery> = new Array<Surgery>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResSurgeryRoom)
    public ResSurgeryRooms: Array<ResSurgeryRoom> = new Array<ResSurgeryRoom>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSurgeryDesk)
    public ResSurgeryDesks: Array<ResSurgeryDesk> = new Array<ResSurgeryDesk>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();

    @Type(() => VitalSingsFormViewModel)
    public vitalSingsViewModel: VitalSingsFormViewModel;
    @Type(() => Object)
    _selectedSurgeryProcedure: Object;
    @Type(() => SurgeryProcedureFormViewModel)
    public SurgeryProcedureFormViewModelList: Array<SurgeryProcedureFormViewModel> = new Array<SurgeryProcedureFormViewModel>();
    @Type(() => SurgerySummaryFormViewModel)
    public OtherSurgerySummaryFormViewModellList: Array<SurgerySummaryFormViewModel> = new Array<SurgerySummaryFormViewModel>();

    @Type(() => Boolean)
    public IsRequiredPathology: Boolean;
}
