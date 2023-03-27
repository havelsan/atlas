//$2F31D9F8
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Pathology } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICDOYERLESIMYERI } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlindigiDokununTemelOzelligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlinmaSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPatolojiPreparatiDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICDOMORFOLOJIKODU } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyTestProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { vmRequestedPathologyProcedure } from './PathologyMaterialInfoViewModel';
import { PathologyAdditionalReport } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyPanicAlert } from "NebulaClient/Model/AtlasClientModel";

export class PathologyMainFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PathologyMainFormViewModel, Core';

    @Type(() => Pathology)
    public _Pathology: Pathology = new Pathology();
    @Type(() => PathologyAdditionalReport)
    public PathologyAdditionalReportGridList: Array<PathologyAdditionalReport> = new Array<PathologyAdditionalReport>();
    @Type(() => PathologyPanicAlert)
    public PathologyPanicAlertGridList: Array<PathologyPanicAlert> = new Array<PathologyPanicAlert>();
    @Type(() => DiagnosisGrid)
    public DiagnosisDiagnosisGridGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => PathologyMaterial)
    public PathologyMaterialGridList: Array<PathologyMaterial> = new Array<PathologyMaterial>();
    @Type(() => BaseTreatmentMaterial)
    public TreatmentMaterialsGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();
    @Type(() => PathologyRequest)
    public PathologyRequests: Array<PathologyRequest> = new Array<PathologyRequest>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => SKRSICDOYERLESIMYERI)
    public SKRSICDOYERLESIMYERIs: Array<SKRSICDOYERLESIMYERI> = new Array<SKRSICDOYERLESIMYERI>();
    @Type(() => SKRSNumuneAlindigiDokununTemelOzelligi)
    public SKRSNumuneAlindigiDokununTemelOzelligis: Array<SKRSNumuneAlindigiDokununTemelOzelligi> = new Array<SKRSNumuneAlindigiDokununTemelOzelligi>();
    @Type(() => SKRSNumuneAlinmaSekli)
    public SKRSNumuneAlinmaSeklis: Array<SKRSNumuneAlinmaSekli> = new Array<SKRSNumuneAlinmaSekli>();
    @Type(() => SKRSPatolojiPreparatiDurumu)
    public SKRSPatolojiPreparatiDurumus: Array<SKRSPatolojiPreparatiDurumu> = new Array<SKRSPatolojiPreparatiDurumu>();
    @Type(() => SKRSICDOMORFOLOJIKODU)
    public SKRSICDOMORFOLOJIKODUs: Array<SKRSICDOMORFOLOJIKODU> = new Array<SKRSICDOMORFOLOJIKODU>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => MaterialProcedure)
    public MaterialProcedureList: Array<MaterialProcedure> = new Array<MaterialProcedure>();
    @Type(() => vmRequestedPathologyProcedure)
    public _RequestedPathologyProceduresArray: Array<vmRequestedPathologyProcedure> = new Array<vmRequestedPathologyProcedure>();
    public _StateName: string = "";
    public _PatientObjectID: string;
    public hasRolePathologist: boolean;
}

export class MaterialProcedure {
    @Type(() => Guid)
    public MaterialObjectID: Guid;
    @Type(() => PathologyTestProcedure)
    public PathologyTestProcedureGridList: Array<PathologyTestProcedure> = new Array<PathologyTestProcedure>();
}

export class PathologySubepisodeInfo {
    public SubepisodeID: string;
    public ProtocolNo: string;
    public SubepisodeOpeningDate: string;
    public RessectionName: string;
    public DoctorName: string;
    @Type(() => PathologyInfo)
    public pathologyInfos: Array<PathologyInfo> = new Array<PathologyInfo>();
}

export class PathologyInfo {
    public PathologyProtocolNo: string;
    public ApproveDate: string;
    public ReportDate: string;
    public PathologyID: string;
    public CurrentStateName: string;
    public CurrentStateID: string;
    public PatDoctorName: string;
    public IsApproved:boolean;
    public IsReported:boolean;
}