//$7F229294
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SubProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedurePriceDefinition } from "NebulaClient/Model/AtlasClientModel";
import { GILDefinition } from "NebulaClient/Model/AtlasClientModel";
import { PackageProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RevenueSubAccountCodeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { TedaviTipi } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { TakipTipi } from "NebulaClient/Model/AtlasClientModel";
import { ProvizyonTipi } from "NebulaClient/Model/AtlasClientModel";
import { OzelDurum } from "NebulaClient/Model/AtlasClientModel";
import { PricingDetailDefinition } from "NebulaClient/Model/AtlasClientModel";
import { PricingListDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "app/NebulaClient/ClassTransformer";
import { RequiredDiagnoseProcedure } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";

export class ProcedureFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.ProcedureFormViewModel, Core';

    @Type(() => ProcedureDefinition)
    public _ProcedureDefinition: ProcedureDefinition = new ProcedureDefinition();
    @Type(() => SubProcedureDefinition)
    public GridSubProceduresGridList: Array<SubProcedureDefinition> = new Array<SubProcedureDefinition>();
    @Type(() => ProcedurePriceDefinition)
    public grdPricesGridList: Array<ProcedurePriceDefinition> = new Array<ProcedurePriceDefinition>();
    @Type(() => GILDefinition)
    public GILDefinitions: Array<GILDefinition> = new Array<GILDefinition>();
    @Type(() => PackageProcedureDefinition)
    public PackageProcedureDefinitions: Array<PackageProcedureDefinition> = new Array<PackageProcedureDefinition>();
    @Type(() => RevenueSubAccountCodeDefinition)
    public RevenueSubAccountCodeDefinitions: Array<RevenueSubAccountCodeDefinition> = new Array<RevenueSubAccountCodeDefinition>();
    @Type(() => ProcedureTreeDefinition)
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => TedaviTipi)
    public TedaviTipis: Array<TedaviTipi> = new Array<TedaviTipi>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => TakipTipi)
    public TakipTipis: Array<TakipTipi> = new Array<TakipTipi>();
    @Type(() => ProvizyonTipi)
    public ProvizyonTipis: Array<ProvizyonTipi> = new Array<ProvizyonTipi>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    @Type(() => PricingDetailDefinition)
    public PricingDetailDefinitions: Array<PricingDetailDefinition> = new Array<PricingDetailDefinition>();
    @Type(() => PricingListDefinition)
    public PricingListDefinitions: Array<PricingListDefinition> = new Array<PricingListDefinition>();
    @Type(() => RequiredDiagnoseProcedure)
    public GridRequiredDiagnosisGridList: Array<RequiredDiagnoseProcedure> = new Array<RequiredDiagnoseProcedure>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
}
