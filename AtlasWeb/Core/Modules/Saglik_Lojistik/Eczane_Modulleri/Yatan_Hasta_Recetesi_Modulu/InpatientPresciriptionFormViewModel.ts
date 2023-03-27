//$1902127F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisForPresc } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionPaper } from 'NebulaClient/Model/AtlasClientModel';

export class InpatientPresciriptionFormViewModel extends BaseViewModel {
    public _InpatientPrescription: InpatientPrescription = new InpatientPrescription();
    public SPTSDiagnosisesGridList: Array<DiagnosisForPresc> = new Array<DiagnosisForPresc>();
    public InpatientDrugOrdersGridList: Array<InpatientDrugOrder> = new Array<InpatientDrugOrder>();
    public Materials: Array<Material> = new Array<Material>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public Patients: Array<Patient> = new Array<Patient>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
    public PrescriptionPapers: Array<PrescriptionPaper> = new Array<PrescriptionPaper>();
}
