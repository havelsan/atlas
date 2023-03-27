//$D2DAA050
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PathologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyTestProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICDOYERLESIMYERI } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPatolojiPreparatiDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlinmaSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICDOMORFOLOJIKODU } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlindigiDokununTemelOzelligi } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyTestCategoryDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

export class PathologyMaterialInfoViewModel extends BaseViewModel {
    @Type(() => PathologyMaterial)
    public _PathologyMaterial: PathologyMaterial = new PathologyMaterial();
    @Type(() => PathologyTestProcedure)
    public PathologyTestProcedureGridList: Array<PathologyTestProcedure> = new Array<PathologyTestProcedure>();
    @Type(() => SKRSICDOYERLESIMYERI)
    public SKRSICDOYERLESIMYERIs: Array<SKRSICDOYERLESIMYERI> = new Array<SKRSICDOYERLESIMYERI>();
    @Type(() => SKRSPatolojiPreparatiDurumu)
    public SKRSPatolojiPreparatiDurumus: Array<SKRSPatolojiPreparatiDurumu> = new Array<SKRSPatolojiPreparatiDurumu>();
    @Type(() => SKRSNumuneAlinmaSekli)
    public SKRSNumuneAlinmaSeklis: Array<SKRSNumuneAlinmaSekli> = new Array<SKRSNumuneAlinmaSekli>();
    @Type(() => SKRSICDOMORFOLOJIKODU)
    public SKRSICDOMORFOLOJIKODUs: Array<SKRSICDOMORFOLOJIKODU> = new Array<SKRSICDOMORFOLOJIKODU>();
    @Type(() => SKRSNumuneAlindigiDokununTemelOzelligi)
    public SKRSNumuneAlindigiDokununTemelOzelligis: Array<SKRSNumuneAlindigiDokununTemelOzelligi> = new Array<SKRSNumuneAlindigiDokununTemelOzelligi>();
    @Type(() => PathologyTestCategoryDefinition)
    public PathologyTestCategoryDefinitions: Array<PathologyTestCategoryDefinition> = new Array<PathologyTestCategoryDefinition>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Object)
    public _selectedProcedureObject: Object;
}


export class MaterialDefinitionsViewModel {
    @Type(() => SKRSICDOYERLESIMYERI)
    public SKRSICDOYERLESIMYERIs: Array<SKRSICDOYERLESIMYERI> = new Array<SKRSICDOYERLESIMYERI>();
    @Type(() => SKRSPatolojiPreparatiDurumu)
    public SKRSPatolojiPreparatiDurumus: Array<SKRSPatolojiPreparatiDurumu> = new Array<SKRSPatolojiPreparatiDurumu>();
    @Type(() => SKRSNumuneAlinmaSekli)
    public SKRSNumuneAlinmaSeklis: Array<SKRSNumuneAlinmaSekli> = new Array<SKRSNumuneAlinmaSekli>();
    @Type(() => SKRSICDOMORFOLOJIKODU)
    public SKRSICDOMORFOLOJIKODUs: Array<SKRSICDOMORFOLOJIKODU> = new Array<SKRSICDOMORFOLOJIKODU>();
    @Type(() => SKRSNumuneAlindigiDokununTemelOzelligi)
    public SKRSNumuneAlindigiDokununTemelOzelligis: Array<SKRSNumuneAlindigiDokununTemelOzelligi> = new Array<SKRSNumuneAlindigiDokununTemelOzelligi>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();

}

export class vmRequestedPathologyProcedure {
    @Type(() => Guid)
    public MaterialObjectID: Guid;
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
    public IsPaid: boolean;
    public FromClinic: boolean;
}