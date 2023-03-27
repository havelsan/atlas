//$3E0FF55B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DailyDrugSchedule } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugPatient } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugSchOrder } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugUnDrug } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class DailyDrugScheduleCompletedFormViewModel extends BaseViewModel {
        @Type(() => DailyDrugSchedule)
    public _DailyDrugSchedule: DailyDrugSchedule = new DailyDrugSchedule();
        @Type(() => DailyDrugPatient)
    public DailyDrugPatientsGridGridList: Array<DailyDrugPatient> = new Array<DailyDrugPatient>();
        @Type(() => DailyDrugSchOrder)
    public DailyDrugSchOrdersGridGridList: Array<DailyDrugSchOrder> = new Array<DailyDrugSchOrder>();
        @Type(() => DailyDrugUnDrug)
    public DailyDrugUnDrugsGridGridList: Array<DailyDrugUnDrug> = new Array<DailyDrugUnDrug>();
        @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
        @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
        @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
        @Type(() => DailyDrugPatient)
    public DailyDrugPatients: Array<DailyDrugPatient> = new Array<DailyDrugPatient>();
        @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
}
