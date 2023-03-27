//$B6DDC634
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChemotherapyRadiotherapy, ChemoRadioCureProtocol, Store, ProcedureDefinition, Material, EtkinMadde, ChemotherapyApplyMethod, ChemotherapyApplySubMethod, RadiotherapyXRayTypeDef, ChemoRadiotherapyMaterial, StockCard, DistributionTypeDefinition, PlannedProcedureRequest, ProcedureRequestFormDetailDefinition, ProcedureForPlannedRequest, Episode,Patient,  SKRSCinsiyet } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { UserTemplateModel } from "../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel";

export class ChemotherapyRadiotherapyFormViewModel extends BaseViewModel {
    public _ChemotherapyRadiotherapy: ChemotherapyRadiotherapy = new ChemotherapyRadiotherapy();

    public diagnoseDate;
    public patientHeight: number;
    public patientWeight: number;
    @Type(() => ChemoRadioCureProtocol)
    public lastSelectedCureProtocol: ChemoRadioCureProtocol = new ChemoRadioCureProtocol();
    @Type(() => Store)
    public selectedStore: Store;
    @Type(() => Store)
    public storeList: Array<Store> = new Array<Store>();
    @Type(() => ChemoRadioOrderDetailItem)
    public cureDetails: Array<ChemoRadioOrderDetailItem> = new Array<ChemoRadioOrderDetailItem>();
    @Type(() => ProcedureDefinition)
    public chemoRadioProcedure: ProcedureDefinition;
    @Type(() => UserTemplateModel)
    public userTemplateList: Array<UserTemplateModel> = new Array<UserTemplateModel>();
    @Type(() => ChemoRadiotherapyMaterial)
    public TreatmentMaterialGridList: Array<ChemoRadiotherapyMaterial> = new Array<ChemoRadiotherapyMaterial>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => Guid)
    public _EpisodeActionID: Guid;
    @Type(() => Guid)
    public _EpisodeID: Guid;
    @Type(() => Guid)
    public _PatientID: Guid;
    public patientAge: number;
    @Type(() => PlannedProcedureRequest)
    public PlannedProcedureRequests: Array<PlannedProcedureRequest> = new Array<PlannedProcedureRequest>();
    @Type(() => ProcedureForPlannedRequest)
    public ProcedureForPlannedRequests: Array<ProcedureForPlannedRequest> = new Array<ProcedureForPlannedRequest>();
    @Type(() => ProcedureRequestFormDetailDefinition)
    public ProcedureRequestFormDetailDefinitions: Array<ProcedureRequestFormDetailDefinition> = new Array<ProcedureRequestFormDetailDefinition>();
    @Type(() => Guid)
    public ProcedureRequestFormResourceIDs: Array<Guid> = new Array<Guid>();
    @Type(() => Episode)
    public EpisodeObject: Episode;
    @Type(() => Patient)
    public PatientObject: Patient;
}

export class ChemoRadioOrderDetailItem {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => ChemoRadioCureProtocol)
    public OrderObject: ChemoRadioCureProtocol;
    public AppliedDate: Date;
    public EtkenMadde: string;
    public Cure: string;
    public CureSolvent: string;
    public DrugDose: number;
    public SolventDose: number;
    public ApplyType: string;
    public Store: string;
    public Description: string;
    public currentState: string;
    public isCompleted: boolean;
    public isAborted: boolean;
    public isNew: boolean;
    public isRadiotherapy: boolean;
    public canUndo: boolean;
}

export class AddOrUpdateChemoRadioOrder {
    @Type(() => ChemoRadioCureProtocol)
    public chemoRadioCureProtocol: ChemoRadioCureProtocol;
    @Type(() => Store)
    public store: Store;
    @Type(() => ProcedureDefinition)
    public procedureObject: ProcedureDefinition;
}

export class UpdateChemoRadioOrderDetail {
    public ObjectID: Guid;
    public isCancelled: boolean = false;
    public isAborted: boolean = false;
    public isCompleted: boolean = false;
    public isUndo: boolean = false;
    @Type(() => Store)
    public store: Store;
    public description: string;
}

export class GetTemplateCureProtocolItem {
    public cureProtocol: ChemoRadioCureProtocol;
    public Material: Material;
    public Solvent: Material;
    public EtkinMadde: EtkinMadde;
    public ApplyMethod: ChemotherapyApplyMethod;
    public ApplySubMethod: ChemotherapyApplySubMethod;
    public RadiotherapyXRayTypeDef: RadiotherapyXRayTypeDef;
}
