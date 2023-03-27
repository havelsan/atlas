//$26A88AFB
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { RegularObstetric } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisGrid } from "NebulaClient/Model/AtlasClientModel";
import { SubActionProcedure } from "NebulaClient/Model/AtlasClientModel";
import { RegularObstetricPersonel } from "NebulaClient/Model/AtlasClientModel";
import { BaseTreatmentMaterial } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";

export class RegularObstetricCesareanReqFormViewModel extends BaseViewModel {
    public _RegularObstetric: RegularObstetric = new RegularObstetric();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public GridManipulationsGridList: Array<SubActionProcedure> = new Array<SubActionProcedure>();
    public GridPersonnelGridList: Array<RegularObstetricPersonel> = new Array<RegularObstetricPersonel>();
    public GridTreatmentMaterialsGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public Materials: Array<Material> = new Array<Material>();
}
