//$E47CE7FD
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PatientOwnDrugEntry } from "NebulaClient/Model/AtlasClientModel";
import { PatientOwnDrugEntryDetail } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class PatientOwnDrugEntryApprovalFormViewModel extends BaseViewModel {
    @Type(() => PatientOwnDrugEntry)
    public _PatientOwnDrugEntry: PatientOwnDrugEntry = new PatientOwnDrugEntry();
    @Type(() => PatientOwnDrugEntryDetail)
    public PatientOwnDrugEntryDetailsGridList: Array<PatientOwnDrugEntryDetail> = new Array<PatientOwnDrugEntryDetail>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
}
