//$B2573412
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { LaboratoryTestDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { LaboratoryTabNamesGrid } from "NebulaClient/Model/AtlasClientModel";
import { LaboratoryGridPanelTestDefinition } from "NebulaClient/Model/AtlasClientModel";
import { LaboratoryGridDepartmentDefinition } from "NebulaClient/Model/AtlasClientModel";
import { LaboratoryGridRestrictedTestDefiniton } from "NebulaClient/Model/AtlasClientModel";
import { LaboratoryGridBoundedTestDefinition } from "NebulaClient/Model/AtlasClientModel";
import { LaboratoryGridMaterialDefinition } from "NebulaClient/Model/AtlasClientModel";
import { LabGridSpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SKRSLOINC } from "NebulaClient/Model/AtlasClientModel";
import { LaboratoryRequestFormTabDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SKRSCinsiyet } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { LaboratoryTestTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResLaboratoryDepartment } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { SpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";
import { TahlilTipi } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "app/NebulaClient/ClassTransformer";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class LaboratoryTestDefinitionNewFormViewModel extends ProcedureFormViewModel {
    protected __type__: string = 'Core.Models.LaboratoryTestDefinitionNewFormViewModel, Core';

    @Type(() => LaboratoryTestDefinition)
    public _LaboratoryTestDefinition: LaboratoryTestDefinition = new LaboratoryTestDefinition();
    @Type(() => LaboratoryTabNamesGrid)
    public TabNameGridGridList: Array<LaboratoryTabNamesGrid> = new Array<LaboratoryTabNamesGrid>();
    @Type(() => LaboratoryGridPanelTestDefinition)
    public GridPanelTestsGridList: Array<LaboratoryGridPanelTestDefinition> = new Array<LaboratoryGridPanelTestDefinition>();
    @Type(() => LaboratoryGridDepartmentDefinition)
    public GridDepartmentsGridList: Array<LaboratoryGridDepartmentDefinition> = new Array<LaboratoryGridDepartmentDefinition>();
    @Type(() => LaboratoryGridRestrictedTestDefiniton)
    public GridRestrictedTestsGridList: Array<LaboratoryGridRestrictedTestDefiniton> = new Array<LaboratoryGridRestrictedTestDefiniton>();
    @Type(() => LaboratoryGridBoundedTestDefinition)
    public GridBoundedTestsGridList: Array<LaboratoryGridBoundedTestDefinition> = new Array<LaboratoryGridBoundedTestDefinition>();
    @Type(() => LaboratoryGridMaterialDefinition)
    public GridMaterialsGridList: Array<LaboratoryGridMaterialDefinition> = new Array<LaboratoryGridMaterialDefinition>();
    @Type(() => LabGridSpecialityDefinition)
    public ttgrid1GridList: Array<LabGridSpecialityDefinition> = new Array<LabGridSpecialityDefinition>();
    @Type(() => SKRSLOINC)
    public SKRSLOINCs: Array<SKRSLOINC> = new Array<SKRSLOINC>();
    @Type(() => LaboratoryRequestFormTabDefinition)
    public LaboratoryRequestFormTabDefinitions: Array<LaboratoryRequestFormTabDefinition> = new Array<LaboratoryRequestFormTabDefinition>();
    @Type(() => SKRSCinsiyet)
    public SKRSCinsiyets: Array<SKRSCinsiyet> = new Array<SKRSCinsiyet>();
    @Type(() => ProcedureTreeDefinition)
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    @Type(() => LaboratoryTestTypeDefinition)
    public LaboratoryTestTypeDefinitions: Array<LaboratoryTestTypeDefinition> = new Array<LaboratoryTestTypeDefinition>();
    @Type(() => LaboratoryTestDefinition)
    public LaboratoryTestDefinitions: Array<LaboratoryTestDefinition> = new Array<LaboratoryTestDefinition>();
    @Type(() => ResLaboratoryDepartment)
    public ResLaboratoryDepartments: Array<ResLaboratoryDepartment> = new Array<ResLaboratoryDepartment>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    @Type(() => TahlilTipi)
    public TahlilTipis: Array<TahlilTipi> = new Array<TahlilTipi>();

    // @Type(() => PackageProcedureDefinition)
    // public PackageProcedureDefinitions: Array<PackageProcedureDefinition> = new Array<PackageProcedureDefinition>();
    // @Type(() => GILDefinition)
    // public GILDefinitions: Array<GILDefinition> = new Array<GILDefinition>();

    // @Type(() => SubProcedureDefinition)
    // public GridSubProceduresGridList: Array<SubProcedureDefinition> = new Array<SubProcedureDefinition>();
}
