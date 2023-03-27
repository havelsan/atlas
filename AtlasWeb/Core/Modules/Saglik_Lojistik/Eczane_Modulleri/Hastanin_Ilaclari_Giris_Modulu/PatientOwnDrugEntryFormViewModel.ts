//$74A653E5
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { PatientOwnDrugEntry, PatientLastUseDrug } from 'NebulaClient/Model/AtlasClientModel';
import { PatientOwnDrugEntryDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';

export class PatientOwnDrugEntryFormViewModel extends BaseViewModel {
    public _PatientOwnDrugEntry: PatientOwnDrugEntry = new PatientOwnDrugEntry();
    public PatientOwnDrugEntryDetailsGridList: Array<PatientOwnDrugEntryDetail> = new Array<PatientOwnDrugEntryDetail>();
    public PatientLastUseDrugs: Array<PatientLastUseDrug> = new Array<PatientLastUseDrug>();
    public Materials: Array<Material> = new Array<Material>();
}
