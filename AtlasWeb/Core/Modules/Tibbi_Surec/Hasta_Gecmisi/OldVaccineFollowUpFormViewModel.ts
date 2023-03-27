//$5D8F4100
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { VaccineFollowUp } from 'NebulaClient/Model/AtlasClientModel';
import { VaccineDetails } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class OldVaccineFollowUpFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldEmergencyFormViewModel, Core';

    @Type(() => VaccineFollowUp)
    public _VaccineFollowUp: VaccineFollowUp = new VaccineFollowUp();

    @Type(() => VaccineDetails)
    public VaccineDetailsGridList: Array<VaccineDetails> = new Array<VaccineDetails>();

    @Type(() => VaccineData)
    public VaccineDataList: Array<VaccineData>;
}
export class VaccineData {
    public VaccineName: string;
    public PeriodName: string;
    public PeriodRange: string;
    public PeriodUnit: string;
    public AppointmentDate: string;
    public ApplicationDate: string;
    public Notes: string;
}