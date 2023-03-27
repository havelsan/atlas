//$69D50768
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class AppointmentFormConsultationViewModel extends BaseViewModel {
    @Type(() => Consultation)
    public _Consultation: Consultation = new Consultation();
}
