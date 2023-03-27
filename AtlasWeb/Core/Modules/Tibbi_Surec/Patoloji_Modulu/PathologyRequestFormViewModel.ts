//$F1D761A3
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PathologyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICDOYERLESIMYERI } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlindigiDokununTemelOzelligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlinmaSekli } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class PathologyRequestFormViewModel extends BaseViewModel {
    @Type(() => PathologyRequest)
    public _PathologyRequest: PathologyRequest = new PathologyRequest();
    @Type(() => PathologyMaterial)
    public PathologyMaterialsGridList: Array<PathologyMaterial> = new Array<PathologyMaterial>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SKRSICDOYERLESIMYERI)
    public SKRSICDOYERLESIMYERIs: Array<SKRSICDOYERLESIMYERI> = new Array<SKRSICDOYERLESIMYERI>();
    @Type(() => SKRSNumuneAlindigiDokununTemelOzelligi)
    public SKRSNumuneAlindigiDokununTemelOzelligis: Array<SKRSNumuneAlindigiDokununTemelOzelligi> = new Array<SKRSNumuneAlindigiDokununTemelOzelligi>();
    @Type(() => SKRSNumuneAlinmaSekli)
    public SKRSNumuneAlinmaSeklis: Array<SKRSNumuneAlinmaSekli> = new Array<SKRSNumuneAlinmaSekli>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => Object)
    public _selectedProcedureObject: Object;
    @Type(() => RequestedPathologyProcedures)
    public _ProcedureArray: Array<RequestedPathologyProcedures> = new Array<RequestedPathologyProcedures>();
    @Type(() => Boolean)
    public _ForceSelectPathologyProcedure: boolean;
}

export class RequestedPathologyProcedures {
    @Type(() => Number)
    public MaterialNo: number;
    @Type(() => Guid)
    public SubActionProcedureObjectId: Guid;
    public ProcedureCode: string;
    public ProcedureName: string;
    @Type(() => Number)
    public Amount: number;
    @Type(() => Number)
    public UnitPrice: Currency;
    @Type(() => Date)
    public RequestDate: Date;
    public RequestBy: string;
    public ProcedureUser: string;
    public MasterResource: string;
    @Type(() => Guid)
    public ProcedureDefObjectID: Guid;
   

}