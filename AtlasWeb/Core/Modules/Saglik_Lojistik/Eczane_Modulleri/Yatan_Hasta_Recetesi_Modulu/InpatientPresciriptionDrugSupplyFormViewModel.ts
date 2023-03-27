//$08008020
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialBarcodeLevel } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ExternalPharmacy } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionPaper } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class InpatientPresciriptionDrugSupplyFormViewModel extends BaseViewModel {
     @Type(() => InpatientPrescription)
    public _InpatientPrescription: InpatientPrescription = new InpatientPrescription();
     @Type(() => InpatientDrugOrder)
    public InpatientDrugOrdersGridList: Array<InpatientDrugOrder> = new Array<InpatientDrugOrder>();
     @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
     @Type(() => MaterialBarcodeLevel)
    public MaterialBarcodeLevels: Array<MaterialBarcodeLevel> = new Array<MaterialBarcodeLevel>();
     @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
     @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
     @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
     @Type(() => ExternalPharmacy)
    public ExternalPharmacys: Array<ExternalPharmacy> = new Array<ExternalPharmacy>();
     @Type(() => PrescriptionPaper)
    public PrescriptionPapers: Array<PrescriptionPaper> = new Array<PrescriptionPaper>();
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
}
