//$4CC8C15A
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { DPADetailFirmPriceOffer } from 'NebulaClient/Model/AtlasClientModel';
import { ProductDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { RadiologyRepeatReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class RadiologyTestCompletedFormViewModel extends BaseViewModel {
    @Type(() => RadiologyTest)
    public _RadiologyTest: RadiologyTest = new RadiologyTest();
    @Type(() => RadiologyMaterial)
    public MaterialsGridList: Array<RadiologyMaterial> = new Array<RadiologyMaterial>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => SurgeryDirectPurchaseGrid)
    public SurgeryDirectPurchaseGridsGridList: Array<SurgeryDirectPurchaseGrid> = new Array<SurgeryDirectPurchaseGrid>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => SKRSILKodlari)
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    @Type(() => SKRSCinsiyet)
    public SKRSCinsiyets: Array<SKRSCinsiyet> = new Array<SKRSCinsiyet>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResRadiologyDepartment)
    public ResRadiologyDepartments: Array<ResRadiologyDepartment> = new Array<ResRadiologyDepartment>();
    @Type(() => ResRadiologyEquipment)
    public ResRadiologyEquipments: Array<ResRadiologyEquipment> = new Array<ResRadiologyEquipment>();
    @Type(() => DPADetailFirmPriceOffer)
    public DPADetailFirmPriceOffers: Array<DPADetailFirmPriceOffer> = new Array<DPADetailFirmPriceOffer>();
    @Type(() => ProductDefinition)
    public ProductDefinitions: Array<ProductDefinition> = new Array<ProductDefinition>();
    @Type(() => DirectPurchaseActionDetail)
    public DirectPurchaseActionDetails: Array<DirectPurchaseActionDetail> = new Array<DirectPurchaseActionDetail>();
    @Type(() => Radiology)
    public Radiologys: Array<Radiology> = new Array<Radiology>();
    @Type(() => RadiologyRepeatReasonDefinition)
    public RadiologyRepeatReasonDefinitions: Array<RadiologyRepeatReasonDefinition> = new Array<RadiologyRepeatReasonDefinition>();

    public RadiologyAdditionalReport: Object;
    @Type(() => Boolean)
    public hasAdditionalReport: boolean;
    @Type(() => Boolean)
    public paramNewRadiologyReport: boolean;
}

export class RadiologyTestObject {
    public ObjectID: string;
    public ProcedureCode: string;
    public ProcedureName: string;
}

export class CopyReportInput {
    public SelectedRadiologyTests: Array<RadiologyTestObject>;
    public RadiologyTestObjectID: string;
}