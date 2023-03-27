//$88ACA629
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Surgery, SurgeryRejectReason } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryExpend } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaAndReanimation } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { VitalSingsFormViewModel } from 'Modules/Tibbi_Surec/Vital_Bulgular/VitalSingsFormViewModel';
import { SurgeryProcedureFormViewModel } from './SurgeryProcedureFormViewModel';
import { SurgerySummaryFormViewModel } from './SurgerySummaryFormViewModel';
import { SurgeryResultDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SurgeryRobsonDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Guard } from "devexpress-dashboard/model/index.internal";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";


export class SurgeryFormViewModel extends BaseViewModel {
    @Type(() => Surgery)
    public _Surgery: Surgery = new Surgery();
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => SurgeryPersonnel)
    public GridSurgeryPersonnelsGridList: Array<SurgeryPersonnel> = new Array<SurgeryPersonnel>();
    @Type(() => SurgeryExpend)
    public GridSurgeryExpendsGridList: Array<SurgeryExpend> = new Array<SurgeryExpend>();
    @Type(() => SurgeryResultDefinition)
    public SurgeryResultDefinitions: Array<SurgeryResultDefinition> = new Array<SurgeryResultDefinition>();
    @Type(() => SurgeryRobsonDefinition)
    public SurgeryRobsonDefinitions: Array<SurgeryRobsonDefinition> = new Array<SurgeryRobsonDefinition>();
    @Type(() => DirectPurchaseGrid)
    public DirectPurchaseGridsGridList: Array<DirectPurchaseGrid> = new Array<DirectPurchaseGrid>();
    @Type(() => AnesthesiaProcedure)
    public GridAnesthesiaProceduresGridList: Array<AnesthesiaProcedure> = new Array<AnesthesiaProcedure>();
    @Type(() => AnesthesiaPersonnel)
    public GridAnesthesiaPersonnelsGridList: Array<AnesthesiaPersonnel> = new Array<AnesthesiaPersonnel>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResSurgeryRoom)
    public ResSurgeryRooms: Array<ResSurgeryRoom> = new Array<ResSurgeryRoom>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => AnesthesiaAndReanimation)
    public AnesthesiaAndReanimations: Array<AnesthesiaAndReanimation> = new Array<AnesthesiaAndReanimation>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSurgeryDesk)
    public ResSurgeryDesks: Array<ResSurgeryDesk> = new Array<ResSurgeryDesk>();

    public SurgeryTemplateDescription: string;
    @Type(() => Boolean)
    public HasUncompleteSubSurgery: boolean;
    @Type(() => VitalSingsFormViewModel)
    public vitalSingsViewModel: VitalSingsFormViewModel;
    @Type(() => Object)
    _selectedSurgeryProcedure: Object;
    @Type(() => SurgeryProcedureFormViewModel)
    public SurgeryProcedureFormViewModelList: Array<SurgeryProcedureFormViewModel> = new Array<SurgeryProcedureFormViewModel>();
    @Type(() => SurgerySummaryFormViewModel)
    public OtherSurgerySummaryFormViewModellList: Array<SurgerySummaryFormViewModel> = new Array<SurgerySummaryFormViewModel>();

    public SurgeryPersonneSpecilaityList: Array<SurgeryPersonneSpecilaity> = new Array<SurgeryPersonneSpecilaity>();

    @Type(() => Guid)
    public InpatientPhyAppObjectId: Guid;

    @Type(() => Boolean)
    public IsRequiredPathology: Boolean;

    public PatientObjectId: string;

    @Type(() => SurgeryRejectReason)
    public SurgeryRejectReasons: Array<SurgeryRejectReason> = new Array<SurgeryRejectReason>();
    public MasterResourceSpecialityID: string;
}


export class SurgeryPersonneSpecilaity {

    public userObjectId: string;
    public specilaityName: string;

}


