//$A363CA42
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PathologyTestDefinition } from "NebulaClient/Model/AtlasClientModel";
import { PathologyGridMaterialDefinition } from "NebulaClient/Model/AtlasClientModel";
import { PathologyGridDescriptionDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { PathologyTestDescriptionDefinition } from "NebulaClient/Model/AtlasClientModel";
import { TahlilTipi } from "NebulaClient/Model/AtlasClientModel";
import { PathologyTestCategoryDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class PathologyTestDefinitionFormViewModel extends ProcedureFormViewModel {
    public _PathologyTestDefinition: PathologyTestDefinition = new PathologyTestDefinition();
    public MaterialsGridList: Array<PathologyGridMaterialDefinition> = new Array<PathologyGridMaterialDefinition>();
    public ttgrid1GridList: Array<PathologyGridDescriptionDefinition> = new Array<PathologyGridDescriptionDefinition>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    public Materials: Array<Material> = new Array<Material>();
    public PathologyTestDescriptionDefinitions: Array<PathologyTestDescriptionDefinition> = new Array<PathologyTestDescriptionDefinition>();
    public TahlilTipis: Array<TahlilTipi> = new Array<TahlilTipi>();
    public PathologyTestCategoryDefinitions: Array<PathologyTestCategoryDefinition> = new Array<PathologyTestCategoryDefinition>();
}
