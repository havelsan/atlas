//$8F537642
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingPatientPreAssessment, MedicalInfoDrugAllergies, MedicalInfoFoodAllergies, SKRSKanGrubu, SKRSCinsiyet, SKRSMaddeKullanimi, SKRSMeslekler, SKRSOgrenimDurumu, SKRSMedeniHali, RelationshipType, VarYokGarantiEnum, SKRSSigaraKullanimi, SKRSAlkolKullanimi, ActiveIngredientDefinition, DietMaterialDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class NursingPatientPreAssessmentFormViewModel extends BaseViewModel {
    @Type('NursingPatientPreAssessment')
    public _NursingPatientPreAssessment: NursingPatientPreAssessment = new NursingPatientPreAssessment();
    public PatientName: string;
    public ProtocolNo: string;
    public UniqueRefNo: number;
    @Type('SKRSCinsiyet')
    public Sex: SKRSCinsiyet;
    public Age: number;
    @Type('SKRSMeslekler')
    public Occupation: SKRSMeslekler;
    @Type('SKRSOgrenimDurumu')
    public EducationStatus: SKRSOgrenimDurumu;
    @Type('SKRSMedeniHali')
    public SKRSMaritalStatus: SKRSMedeniHali;

    public RelativeNeed: boolean;
    public RelativeFullName: string;
    public RelativeMobilePhone: string;
    public RelativeHomeAddress: string;
    public RelativeRelationship: RelationshipType;
    public ChronicDiseases: string;
    public HasAllergy: VarYokGarantiEnum;
    public OtherAllergies: string;
    @Type('MedicalInfoDrugAllergies')
    public DrugAllergies: Array<MedicalInfoDrugAllergies> = new Array<MedicalInfoDrugAllergies>();
    @Type('MedicalInfoFoodAllergies')
public FoodAllergies: Array<MedicalInfoFoodAllergies> = new Array<MedicalInfoFoodAllergies>();
    @Type('GetActiveIngredientDefinitions_Class')
public ActiveIngredients: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>;
    @Type('GetDietMaterialDefinition_Class')
public DietMaterialList:  Array<DietMaterialDefinition.GetDietMaterialDefinition_Class>;
    public HasContagiousDisease: VarYokGarantiEnum;
    public ContagiousDisease: string;
    public Cigarette: boolean;
    @Type('SKRSSigaraKullanimi')
public CigaretteUsageFrequency: SKRSSigaraKullanimi;
    public Alcohol: boolean;
    @Type('SKRSAlkolKullanimi')
public AlcoholUsageFrequency: SKRSAlkolKullanimi;
    public Drug: boolean;
    @Type('SKRSMaddeKullanimi')
public DrugUsageFrequency: SKRSMaddeKullanimi;
    public ClinicName: string;
    public Diagnosis: string;
    public ANT: string;
    @Type('SKRSKanGrubu')
    public BloodGroupType: SKRSKanGrubu;
    @Type('SKRSKanGrubu')
    public SKRSKanGrubus: Array<SKRSKanGrubu> = new Array<SKRSKanGrubu>();
}
