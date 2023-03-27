//$A5B51AAB
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyRejectReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class RadiologyTestRejectFormViewModel extends BaseViewModel {
    @Type(() => RadiologyTest)
    public _RadiologyTest: RadiologyTest = new RadiologyTest();
    @Type(() => RadiologyMaterial)
    public MaterialsGridList: Array<RadiologyMaterial> = new Array<RadiologyMaterial>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => ResRadiologyEquipment)
    public ResRadiologyEquipments: Array<ResRadiologyEquipment> = new Array<ResRadiologyEquipment>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResRadiologyDepartment)
    public ResRadiologyDepartments: Array<ResRadiologyDepartment> = new Array<ResRadiologyDepartment>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => Radiology)
    public Radiologys: Array<Radiology> = new Array<Radiology>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => RadiologyRejectReasonDefinition)
    public RadiologyRejectReasonDefinitions: Array<RadiologyRejectReasonDefinition> = new Array<RadiologyRejectReasonDefinition>();
}
