//$FF690910
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MedicalInformation } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class OldMedicalInformationFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldMedicalInformationFormViewModel, Core';

    @Type(() => MedicalInformation)
    public _MedicalInformation: MedicalInformation = new MedicalInformation();
    public OtherAllergies: string;
    public DrugAllergies: string;
    public FoodAllergies: string;
    public Habits: string;
    public CigaretteUsageFrequency: string;
    public AlcoholUsageFrequency: string;
    public HabitDescription: string;
    public MedicalDisabledGroup: string;
}
