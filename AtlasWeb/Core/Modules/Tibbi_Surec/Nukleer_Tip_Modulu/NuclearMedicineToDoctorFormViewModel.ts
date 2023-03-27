//$4C172C49
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NuclearMedicine } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisGrid } from "NebulaClient/Model/AtlasClientModel";
import { NucMedTreatmentMat } from "NebulaClient/Model/AtlasClientModel";
import { NucMedRadPharmMatGrid } from "NebulaClient/Model/AtlasClientModel";
import { CokluOzelDurum } from "NebulaClient/Model/AtlasClientModel";
import { SurgeryDirectPurchaseGrid } from "NebulaClient/Model/AtlasClientModel";
import { RadyofarmasotikDirectPurchaseGrid } from "NebulaClient/Model/AtlasClientModel";
import { DirectPurchaseGrid } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Patient } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { MalzemeTuru } from "NebulaClient/Model/AtlasClientModel";
import { OzelDurum } from "NebulaClient/Model/AtlasClientModel";
import { StockCard } from "NebulaClient/Model/AtlasClientModel";
import { DistributionTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RadioPharmaceuticalUnitDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SagSol } from "NebulaClient/Model/AtlasClientModel";
import { AyniFarkliKesi } from "NebulaClient/Model/AtlasClientModel";
import { DPADetailFirmPriceOffer } from "NebulaClient/Model/AtlasClientModel";
import { ProductDefinition } from "NebulaClient/Model/AtlasClientModel";
import { DirectPurchaseActionDetail } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';

export class NuclearMedicineToDoctorFormViewModel extends BaseViewModel {
    public _NuclearMedicine: NuclearMedicine = new NuclearMedicine();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public GridNuclearMedicineMaterialGridList: Array<NucMedTreatmentMat> = new Array<NucMedTreatmentMat>();
    public ttgrid2GridList: Array<NucMedRadPharmMatGrid> = new Array<NucMedRadPharmMatGrid>();
    public ttgridCokluOzelDurumGridList: Array<CokluOzelDurum> = new Array<CokluOzelDurum>();
    public SurgeryDirectPurchaseGridsGridList: Array<SurgeryDirectPurchaseGrid> = new Array<SurgeryDirectPurchaseGrid>();
    public NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList: Array<RadyofarmasotikDirectPurchaseGrid> = new Array<RadyofarmasotikDirectPurchaseGrid>();
    public DirectPurchaseGridsGridList: Array<DirectPurchaseGrid> = new Array<DirectPurchaseGrid>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    public Patients: Array<Patient> = new Array<Patient>();
    public Materials: Array<Material> = new Array<Material>();
    public MalzemeTurus: Array<MalzemeTuru> = new Array<MalzemeTuru>();
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    public StockCards: Array<StockCard> = new Array<StockCard>();
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    public RadioPharmaceuticalUnitDefinitions: Array<RadioPharmaceuticalUnitDefinition> = new Array<RadioPharmaceuticalUnitDefinition>();
    public SagSols: Array<SagSol> = new Array<SagSol>();
    public AyniFarkliKesis: Array<AyniFarkliKesi> = new Array<AyniFarkliKesi>();
    public DPADetailFirmPriceOffers: Array<DPADetailFirmPriceOffer> = new Array<DPADetailFirmPriceOffer>();
    public ProductDefinitions: Array<ProductDefinition> = new Array<ProductDefinition>();
    public DirectPurchaseActionDetails: Array<DirectPurchaseActionDetail> = new Array<DirectPurchaseActionDetail>();
    public PatientWaitTime: string;
}

export class vmNuclearMedicine {
    @Type(() => Guid)
    public ActionObjectId: Guid;
    public AccessionNo: string;
    @Type(() => Guid)
    public ProcedureCode: string;
    public ProcedureName: string;
    @Type(() => Date)
    public RequestDate: Date;
    public RequestedByResUser: string;
    public ProcedureResUser: string;
    public ActionStatus: string;
    public ProcedureResultLink: string;
    public ProcedureReportLink: string;
    public isResultShown: boolean;
    public isReportShown: boolean;
    public FromResourceName: string;
}

export class TestResultQueryInputDVO {
    public ViewType: string;
    public EpisodeID: string;
    public PatientTCKN: string;
}