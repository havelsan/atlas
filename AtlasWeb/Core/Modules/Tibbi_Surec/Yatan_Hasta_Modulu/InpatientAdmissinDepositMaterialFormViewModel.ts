//$F0833093
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientAdmissionDepositMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { Type } from 'NebulaClient/ClassTransformer';

export class InpatientAdmissinDepositMaterialFormViewModel extends BaseViewModel {
    @Type(() => InpatientAdmissionDepositMaterial)
    public _InpatientAdmissionDepositMaterial: InpatientAdmissionDepositMaterial = new InpatientAdmissionDepositMaterial();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}


export class DepositComponentInfoViewModel {
    @Type(() => DynamicComponentInfo)
    public depositComponentInfo: DynamicComponentInfo;
    @Type(() => QueryParams)
    public depositQueryParameters: QueryParams;
}
