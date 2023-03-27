//$3BFCCD8E
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { DrugDeliveryAction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDeliveryActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';

export class DrugDeliveryActionNewFormViewModel extends BaseViewModel {
    public _DrugDeliveryAction: DrugDeliveryAction = new DrugDeliveryAction();
    public DrugDeliveryActionDetailsGridList: Array<DrugDeliveryActionDetail> = new Array<DrugDeliveryActionDetail>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public Patients: Array<Patient> = new Array<Patient>();
    public DrugOrderDetails: Array<DrugOrderDetail> = new Array<DrugOrderDetail>();
}
