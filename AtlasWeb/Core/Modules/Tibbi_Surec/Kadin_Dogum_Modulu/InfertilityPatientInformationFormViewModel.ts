//$D8343503
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InfertilityPatientInformation } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class InfertilityPatientInformationFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.InfertilityPatientInformationFormViewModel, Core';

    @Type(() => InfertilityPatientInformation)
    public _InfertilityPatientInformation: InfertilityPatientInformation = new InfertilityPatientInformation();
}
