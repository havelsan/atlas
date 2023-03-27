//$523E5A93
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoFoodAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDrugAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDisabledGroup } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoHabits } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigaraKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAlkolKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { DietMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIngredientDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class MedicalInformationFormViewModel extends BaseViewModel {
    @Type(() => MedicalInformation)
    public _MedicalInformation: MedicalInformation = new MedicalInformation();
    @Type(() => MedicalInfoFoodAllergies)
    public MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList: Array<MedicalInfoFoodAllergies> = new Array<MedicalInfoFoodAllergies>();
    @Type(() => MedicalInfoDrugAllergies)
    public MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList: Array<MedicalInfoDrugAllergies> = new Array<MedicalInfoDrugAllergies>();
    @Type(() => MedicalInfoDisabledGroup)
    public MedicalInfoDisabledGroups: Array<MedicalInfoDisabledGroup> = new Array<MedicalInfoDisabledGroup>();
    @Type(() => MedicalInfoHabits)
    public MedicalInfoHabitss: Array<MedicalInfoHabits> = new Array<MedicalInfoHabits>();
    @Type(() => SKRSSigaraKullanimi)
    public SKRSSigaraKullanimis: Array<SKRSSigaraKullanimi> = new Array<SKRSSigaraKullanimi>();
    @Type(() => SKRSAlkolKullanimi)
    public SKRSAlkolKullanimis: Array<SKRSAlkolKullanimi> = new Array<SKRSAlkolKullanimi>();
    @Type(() => MedicalInfoAllergies)
    public MedicalInfoAllergiess: Array<MedicalInfoAllergies> = new Array<MedicalInfoAllergies>();
    @Type(() => DietMaterialDefinition)
    public DietMaterialDefinitions: Array<DietMaterialDefinition> = new Array<DietMaterialDefinition>();
    @Type(() => ActiveIngredientDefinition)
    public ActiveIngredientDefinitions: Array<ActiveIngredientDefinition> = new Array<ActiveIngredientDefinition>();
    @Type(() => Object)
    public _selectedMedicalInfoFoodAllergyValue: Object;
    @Type(() => Object)
    public _selectedMedicalInfoDrugAllergyValue: Object;
    public _PatientID: string;    
    public checkBoxControl : boolean = true;
    public buttonControl: boolean = true;
    public allergyControl: boolean = true;
    public changeHighRiskPregnancy: boolean = false;
}
