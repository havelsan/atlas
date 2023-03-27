//$E5BB9354
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratorySubProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResLaboratoryDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ResLaboratoryEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';

export class LaboratoryProcedureFormViewModel extends BaseViewModel {
    public _LaboratoryProcedure: LaboratoryProcedure = new LaboratoryProcedure();
    public GridSubProceduresGridList: Array<LaboratorySubProcedure> = new Array<LaboratorySubProcedure>();
    public MaterialsGridList: Array<LaboratoryMaterial> = new Array<LaboratoryMaterial>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public ResLaboratoryDepartments: Array<ResLaboratoryDepartment> = new Array<ResLaboratoryDepartment>();
    public LaboratoryRequests: Array<LaboratoryRequest> = new Array<LaboratoryRequest>();
    public ResLaboratoryEquipments: Array<ResLaboratoryEquipment> = new Array<ResLaboratoryEquipment>();
    public Materials: Array<Material> = new Array<Material>();
}
