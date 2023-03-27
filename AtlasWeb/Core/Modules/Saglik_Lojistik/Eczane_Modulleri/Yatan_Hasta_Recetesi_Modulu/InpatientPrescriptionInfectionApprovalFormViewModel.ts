//$3330A880
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisForPresc } from 'NebulaClient/Model/AtlasClientModel';
import { InfectionApprovalDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionPaper } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class InpatientPrescriptionInfectionApprovalFormViewModel extends BaseViewModel {
     @Type(() => InpatientPrescription)
    public _InpatientPrescription: InpatientPrescription = new InpatientPrescription();
     @Type(() => DiagnosisForPresc)
    public SPTSDiagnosisesGridList: Array<DiagnosisForPresc> = new Array<DiagnosisForPresc>();
     @Type(() => InfectionApprovalDrugOrder)
    public InfectionApprovalDrugOrderGridList: Array<InfectionApprovalDrugOrder> = new Array<InfectionApprovalDrugOrder>();
     @Type(() => InpatientDrugOrder)
    public InpatientDrugOrdersGridList: Array<InpatientDrugOrder> = new Array<InpatientDrugOrder>();
     @Type(() => InpatientDrugOrder)
    public InpatientDrugOrders: Array<InpatientDrugOrder> = new Array<InpatientDrugOrder>();
     @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
     @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
     @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
     @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
     @Type(() => PrescriptionPaper)
    public PrescriptionPapers: Array<PrescriptionPaper> = new Array<PrescriptionPaper>();
}
