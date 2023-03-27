//$DC1E12B0
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SurgeryExtension, BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { MainSurgeryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryExpend } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { VitalSingsFormViewModel } from 'Modules/Tibbi_Surec/Vital_Bulgular/VitalSingsFormViewModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { SurgeryPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { Guard } from "devexpress-dashboard/model/index.internal";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class SurgeryExtensionFormViewModel extends BaseViewModel {
    @Type(() => SurgeryExtension)
    public _SurgeryExtension: SurgeryExtension = new SurgeryExtension();
    @Type(() => MainSurgeryProcedure)
    public GridMainSurgeryProceduresGridList: Array<MainSurgeryProcedure> = new Array<MainSurgeryProcedure>();

    @Type(() => SurgeryExpend)
    public SurgeryExpendsSurgeryExpendGridList: Array<SurgeryExpend> = new Array<SurgeryExpend>();
    @Type(() => SurgeryExpend)
    public GridSurgeryExpendsGridList: Array<SurgeryExpend> = new Array<SurgeryExpend>();

    @Type(() => DirectPurchaseGrid)
    public DirectPurchaseGridsGridList: Array<DirectPurchaseGrid> = new Array<DirectPurchaseGrid>();
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
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => VitalSingsFormViewModel)
    public vitalSingsViewModel: VitalSingsFormViewModel;

    @Type(() => SurgeryPersonnel)
    public GridSurgeryPersonnelsGridList: Array<SurgeryPersonnel> = new Array<SurgeryPersonnel>();
    @Type(() => SurgeryPersonneSpeciality)
    public SurgeryPersonneSpecilaityList: Array<SurgeryPersonneSpeciality> = new Array<SurgeryPersonneSpeciality>();

    @Type(() => Material)
    public MainSurgeryTreatmentMaterialList: Array<Material> = new Array<Material>();

    @Type(() => Guid)
    public InpatientPhyAppObjectId: Guid;

}

export class SurgeryPersonneSpeciality {

    public userObjectId: string;
    public specilaityName: string;

}