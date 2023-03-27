//$0E36B2F1
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisForPresc } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionPaper } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
export class OutPatientPrescriptionFormViewModel extends BaseViewModel {
  @Type(() => OutPatientPrescription)
  public _OutPatientPrescription: OutPatientPrescription = new OutPatientPrescription();
  @Type(() => OutPatientDrugOrder)
  public OutPatientDrugOrdersGridList: Array<OutPatientDrugOrder> = new Array<OutPatientDrugOrder>();
  @Type(() => DiagnosisForPresc)
  public SPTSDiagnosisesGridList: Array<DiagnosisForPresc> = new Array<DiagnosisForPresc>();
  @Type(() => DrugDefinition)
  public DrugDefinitions: Array<DrugDefinition> = new Array<DrugDefinition>();
  @Type(() => Material)
  public Materials: Array<Material> = new Array<Material>();
  @Type(() => PrescriptionPaper)
  public PrescriptionPapers: Array<PrescriptionPaper> = new Array<PrescriptionPaper>();
  @Type(() => SpecialityDefinition)
  public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
  @Type(() => Episode)
  public Episodes: Array<Episode> = new Array<Episode>();
  @Type(() => Patient)
  public Patients: Array<Patient> = new Array<Patient>();
  @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
}
