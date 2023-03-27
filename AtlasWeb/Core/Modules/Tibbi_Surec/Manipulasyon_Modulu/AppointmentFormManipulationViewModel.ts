//$6120141A
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Manipulation } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class AppointmentFormManipulationViewModel extends BaseViewModel {
    @Type(() => Manipulation)
    public _Manipulation: Manipulation = new Manipulation();

    public AppointmentDescription: string;
}
