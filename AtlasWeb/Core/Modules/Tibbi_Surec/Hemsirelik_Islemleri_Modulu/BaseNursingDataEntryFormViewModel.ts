//$556BF7BA
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseNursingDataEntry } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseNursingDataEntryFormViewModel extends BaseViewModel{
    @Type(() => BaseNursingDataEntry)
    public _BaseNursingDataEntry: BaseNursingDataEntry = new BaseNursingDataEntry();
}
