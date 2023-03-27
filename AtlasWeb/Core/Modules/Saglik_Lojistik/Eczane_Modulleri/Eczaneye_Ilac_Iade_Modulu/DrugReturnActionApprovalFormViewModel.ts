//$A2225DBA
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DrugReturnAction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugReturnActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderTransaction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
export class DrugReturnActionApprovalFormViewModel extends BaseViewModel {
    @Type(() => DrugReturnAction)
    public _DrugReturnAction: DrugReturnAction = new DrugReturnAction();
    @Type(() => DrugReturnActionDetail)
    public DrugReturnActionDetailsGridList: Array<DrugReturnActionDetail> = new Array<DrugReturnActionDetail>();
    @Type(() => DrugOrderTransaction)
    public DrugOrderTransactions: Array<DrugOrderTransaction> = new Array<DrugOrderTransaction>();
    @Type(() => DrugOrder)
    public DrugOrders: Array<DrugOrder> = new Array<DrugOrder>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => Store)
    public PharmacyStoreDefinitions: Array<Store> = new Array<Store>();
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
}
