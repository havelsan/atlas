//$D0EF672B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseAction } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class AppointmentFormBaseViewModel extends BaseViewModel {
    @Type(() => BaseAction)
    public _BaseAction: BaseAction = new BaseAction();

    public AppointmentDescription: string;
}
