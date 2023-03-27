//$EBA622C5
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DrugOrderDetail, DrugUsageTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class DrugOrderDetailFormViewModel extends BaseViewModel {
    @Type(() => DrugOrderDetail)
    public _DrugOrderDetail: DrugOrderDetail = new DrugOrderDetail();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    public DrugUsageType: DrugUsageTypeEnum;
}
