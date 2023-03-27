//$3E84D9A6
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { KSchedule } from 'NebulaClient/Model/AtlasClientModel';
import { KScheduleMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { KScheduleUnListMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
export class KScheduleFormViewModel extends BaseViewModel {
    public _KSchedule: KSchedule = new KSchedule();
    public StockActionOutDetailsGridList: Array<KScheduleMaterial> = new Array<KScheduleMaterial>();
    public UnSupplyGridGridList: Array<KScheduleUnListMaterial> = new Array<KScheduleUnListMaterial>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public Patients: Array<Patient> = new Array<Patient>();
    public Stores: Array<Store> = new Array<Store>();
    public Materials: Array<Material> = new Array<Material>();
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
}
