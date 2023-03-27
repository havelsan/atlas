//$F7F60335
import { BaseAction } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class ActionFormViewModel extends BaseViewModel {
    @Type(() => BaseAction)
    public _BaseAction: BaseAction = new BaseAction();
}
