//$C38DE309
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisForPresc } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisForSPTS } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { SPTSDiagnosisInfo } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class OutPatientPrescriptionThirdFormViewModel extends BaseViewModel {
  @Type(() => OutPatientPrescription)
  public _OutPatientPrescription: OutPatientPrescription = new OutPatientPrescription();
  @Type(() => OutPatientDrugOrder)
  public OutPatientDrugOrdersGridList: Array<OutPatientDrugOrder> = new Array<OutPatientDrugOrder>();
  @Type(() => DiagnosisForPresc)
  public SPTSDiagnosisesGridList: Array<DiagnosisForPresc> = new Array<DiagnosisForPresc>();
  @Type(() => DiagnosisForSPTS)
  public SPTSDiagnosisInfosGridList: Array<DiagnosisForSPTS> = new Array<DiagnosisForSPTS>();
  @Type(() => Episode)
  public Episodes: Array<Episode> = new Array<Episode>();
  @Type(() => Patient)
  public Patients: Array<Patient> = new Array<Patient>();
  @Type(() => Material)
  public Materials: Array<Material> = new Array<Material>();
  @Type(() => SPTSDiagnosisInfo)
  public SPTSDiagnosisInfos: Array<SPTSDiagnosisInfo> = new Array<SPTSDiagnosisInfo>();
  @Type(() => DiagnosisGrid)
  public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
}
