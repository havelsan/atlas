//$60044C33
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Infertility } from "NebulaClient/Model/AtlasClientModel";
import { Patient } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class InfertilityFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.InfertilityFormViewModel, Core';

    @Type(() => Infertility)
    public _Infertility: Infertility = new Infertility();

    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();

    @Type(() => Patient)
    public _Patient: Patient = new Patient();
}
