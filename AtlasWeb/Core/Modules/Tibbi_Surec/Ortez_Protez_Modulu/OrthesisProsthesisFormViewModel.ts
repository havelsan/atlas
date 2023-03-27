//$B7A08E5C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesisProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProthesisRequestTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { CodelessMaterialDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesis_ReturnDescriptionsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { MalzemeTuru } from 'NebulaClient/Model/AtlasClientModel';
import { DPADetailFirmPriceOffer } from 'NebulaClient/Model/AtlasClientModel';
import { ProductDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';


export class OrthesisProsthesisFormViewModel extends BaseViewModel {

    @Type(() => OrthesisProsthesisRequest)
    public _OrthesisProsthesisRequest: OrthesisProsthesisRequest = new OrthesisProsthesisRequest();
    @Type(() => OrthesisProsthesisProcedure)
    public OrthesisProsthesisProceduresGridList: Array<OrthesisProsthesisProcedure> = new Array<OrthesisProsthesisProcedure>();
    @Type(() => OrthesisProthesisRequestTreatmentMaterial)
    public TreatmentMaterialsGridList: Array<OrthesisProthesisRequestTreatmentMaterial> = new Array<OrthesisProthesisRequestTreatmentMaterial>();
    @Type(() => SurgeryDirectPurchaseGrid)
    public OPDirectPurchaseGridGridList: Array<SurgeryDirectPurchaseGrid> = new Array<SurgeryDirectPurchaseGrid>();
    @Type(() => CodelessMaterialDirectPurchaseGrid)
    public CodelessMaterialDirectPurchaseGridsGridList: Array<CodelessMaterialDirectPurchaseGrid> = new Array<CodelessMaterialDirectPurchaseGrid>();
    @Type(() => OrthesisProsthesis_ReturnDescriptionsGrid)
    public ReturnDescriptionGridGridList: Array<OrthesisProsthesis_ReturnDescriptionsGrid> = new Array<OrthesisProsthesis_ReturnDescriptionsGrid>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => AyniFarkliKesi)
    public AyniFarkliKesis: Array<AyniFarkliKesi> = new Array<AyniFarkliKesi>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => MalzemeTuru)
    public MalzemeTurus: Array<MalzemeTuru> = new Array<MalzemeTuru>();
    @Type(() => DPADetailFirmPriceOffer)
    public DPADetailFirmPriceOffers: Array<DPADetailFirmPriceOffer> = new Array<DPADetailFirmPriceOffer>();
    @Type(() => ProductDefinition)
    public ProductDefinitions: Array<ProductDefinition> = new Array<ProductDefinition>();
    @Type(() => DirectPurchaseActionDetail)
    public DirectPurchaseActionDetails: Array<DirectPurchaseActionDetail> = new Array<DirectPurchaseActionDetail>();
    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    public RequesterUnit: string;
    public RequesterUserName: string;
}
