//$3B757D55
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';

export class RadiologyTestAppointmentFormViewModel extends BaseViewModel {
   @Type(() => RadiologyTest)
   public _RadiologyTest: RadiologyTest = new RadiologyTest();
   @Type(() => DiagnosisGrid)
   public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
   @Type(() => ResRadiologyEquipment)
   public ResRadiologyEquipments: Array<ResRadiologyEquipment> = new Array<ResRadiologyEquipment>();
   @Type(() => ProcedureDefinition)
   public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
   @Type(() => ResRadiologyDepartment)
   public ResRadiologyDepartments: Array<ResRadiologyDepartment> = new Array<ResRadiologyDepartment>();
   @Type(() => Episode)
   public Episodes: Array<Episode> = new Array<Episode>();
   @Type(() => Patient)
   public Patients: Array<Patient> = new Array<Patient>();
   @Type(() => DiagnosisDefinition)
   public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
   @Type(() => ResUser)
   public ResUsers: Array<ResUser> = new Array<ResUser>();
   @Type(() => Radiology)
   public Radiologys: Array<Radiology> = new Array<Radiology>();
   public AppointmentDescription: string;
}
