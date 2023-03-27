//$2CF49B4D
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SagSol } from 'NebulaClient/Model/AtlasClientModel';
import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyRepeatReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MalzemeTuru } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { DPADetailFirmPriceOffer } from 'NebulaClient/Model/AtlasClientModel';
import { ProductDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class RadiologyTestProcedureFormViewModel extends BaseViewModel {
    @Type(() => RadiologyTest)
    public _RadiologyTest: RadiologyTest = new RadiologyTest();
    @Type(() => RadiologyMaterial)
    public MaterialsGridList: Array<RadiologyMaterial> = new Array<RadiologyMaterial>();
    @Type(() => SurgeryDirectPurchaseGrid)
    public SurgeryDirectPurchaseGridsGridList: Array<SurgeryDirectPurchaseGrid> = new Array<SurgeryDirectPurchaseGrid>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SagSol)
    public SagSols: Array<SagSol> = new Array<SagSol>();
    @Type(() => AyniFarkliKesi)
    public AyniFarkliKesis: Array<AyniFarkliKesi> = new Array<AyniFarkliKesi>();
    @Type(() => ResRadiologyEquipment)
    public ResRadiologyEquipments: Array<ResRadiologyEquipment> = new Array<ResRadiologyEquipment>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResRadiologyDepartment)
    public ResRadiologyDepartments: Array<ResRadiologyDepartment> = new Array<ResRadiologyDepartment>();
    @Type(() => RadiologyRepeatReasonDefinition)
    public RadiologyRepeatReasonDefinitions: Array<RadiologyRepeatReasonDefinition> = new Array<RadiologyRepeatReasonDefinition>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => MalzemeTuru)
    public MalzemeTurus: Array<MalzemeTuru> = new Array<MalzemeTuru>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    @Type(() => DPADetailFirmPriceOffer)
    public DPADetailFirmPriceOffers: Array<DPADetailFirmPriceOffer> = new Array<DPADetailFirmPriceOffer>();
    @Type(() => ProductDefinition)
    public ProductDefinitions: Array<ProductDefinition> = new Array<ProductDefinition>();
    @Type(() => DirectPurchaseActionDetail)
    public DirectPurchaseActionDetails: Array<DirectPurchaseActionDetail> = new Array<DirectPurchaseActionDetail>();
    @Type(() => Radiology)
    public Radiologys: Array<Radiology> = new Array<Radiology>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();

    public PatientTCNo: string;
    public EpisodeID: string;
    @Type(() => Boolean)
    public NewRadiologyBarcode: boolean;
}
