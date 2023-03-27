//$B328B461
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Manipulation } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationAdditionalApplication } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationReturnReasonsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SagSol } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class ManipulationProcedureFormViewModel extends BaseViewModel {
    @Type(() => Manipulation)
    public _Manipulation: Manipulation = new Manipulation();
    @Type(() => ManipulationProcedure)
    public GridManipulationsGridList: Array<ManipulationProcedure> = new Array<ManipulationProcedure>();
    @Type(() => ManipulationPersonnel)
    public GridPersonnelGridList: Array<ManipulationPersonnel> = new Array<ManipulationPersonnel>();
    @Type(() => ManipulationTreatmentMaterial)
    public GridTreatmentMaterialsGridList: Array<ManipulationTreatmentMaterial> = new Array<ManipulationTreatmentMaterial>();
    @Type(() => ManipulationAdditionalApplication)
    public GridAdditionalApplicationsGridList: Array<ManipulationAdditionalApplication> = new Array<ManipulationAdditionalApplication>();
    @Type(() => DirectPurchaseGrid)
    public DirectPurchaseGridsGridList: Array<DirectPurchaseGrid> = new Array<DirectPurchaseGrid>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => ManipulationReturnReasonsGrid)
    public GridReturnReasonsGridList: Array<ManipulationReturnReasonsGrid> = new Array<ManipulationReturnReasonsGrid>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => AyniFarkliKesi)
    public AyniFarkliKesis: Array<AyniFarkliKesi> = new Array<AyniFarkliKesi>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SagSol)
    public SagSols: Array<SagSol> = new Array<SagSol>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
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
    @Type(() => ManipulationRequest)
    public ManipulationRequests: Array<ManipulationRequest> = new Array<ManipulationRequest>();
    @Type(() => Boolean)
    public isCurrentUserDoctor: boolean;
    public ManipulationFormBaseObjectViewModels: Array<any> = new Array<any>();
 public hasManipulationFormBaseObject: Boolean;
    public manipulationFormName: string;
}
