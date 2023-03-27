//$255077C4
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { EmergencySpecialityObject } from 'NebulaClient/Model/AtlasClientModel';
import { GlaskowComaScaleDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTRIAJKODU } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { AnamnesisFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AnamnesisFormViewModel';
import { PainQualityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PainFrequencyDefiniton } from 'NebulaClient/Model/AtlasClientModel';
import { PainPlaceDefition } from 'NebulaClient/Model/AtlasClientModel';
import { EmergencySurveyObject } from 'NebulaClient/Model/AtlasClientModel';
import { EmergencySurveyDefinition } from 'NebulaClient/Model/AtlasClientModel';
export class EmergencySpecialityObjectFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.EmergencySpecialityObjectFormViewModel, Core';
    @Type('EmergencySpecialityObject')
    public _EmergencySpecialityObject: EmergencySpecialityObject = new EmergencySpecialityObject();
    @Type('GlaskowComaScaleDefinition')
    public GlaskowComaScaleDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
    @Type('GlaskowComaScaleDefinition')
    public GlaskowEyeDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
    @Type('GlaskowComaScaleDefinition')
    public GlaskowOralAnswerDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
    @Type('GlaskowComaScaleDefinition')
    public GlaskowMotorAnswerDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
    @Type('SKRSTRIAJKODU')
    public SKRSTRIAJKODUs: Array<SKRSTRIAJKODU> = new Array<SKRSTRIAJKODU>();
    @Type(() => AnamnesisFormViewModel)
    public anamnesisFormViewModel: AnamnesisFormViewModel;
    @Type(() => Number)
    public BloodPressure_Sistolik: number;
    @Type(() => Number)
    public BloodPressure_Diastolik: number;
    @Type(() => Number)
    public Pulse_Value: number;
    @Type(() => Number)
    public Respiration_Value: number;
    @Type(() => Number)
    public Temperature_Value: number;
    @Type(() => Number)
    public SPO2_Value: number;
    @Type(() => Boolean)
    public isFemale: boolean;
    @Type(() => PainQualityDefinition)
    public PainQualityDefinitions: Array<PainQualityDefinition> = new Array<PainQualityDefinition>();
    @Type(() => PainFrequencyDefiniton)
    public PainFrequencyDefinitons: Array<PainFrequencyDefiniton> = new Array<PainFrequencyDefiniton>();
    @Type(() => PainPlaceDefition)
    public PainPlaceDefitions: Array<PainPlaceDefition> = new Array<PainPlaceDefition>();
    @Type(() => EmergencySurveyObject)
    public EmergencyDefinitionsGridList: Array<EmergencySurveyObject> = new Array<EmergencySurveyObject>();
    @Type(() => EmergencySurveyDefinition)
    public EmergencySurveyDefinitions: Array<EmergencySurveyDefinition> = new Array<EmergencySurveyDefinition>();
    @Type(() => EmergencySurveyDefinitionList_Class)
    public EmergencySurveyDefinitionViewList: Array<EmergencySurveyDefinitionList_Class>;

}

export class EmergencySurveyDefinitionList_Class {
    public GroupName: string;
    public EmergencySurveyDefinitionList: Array<EmergencySurveyDefinition>;
    constructor() {
        this.EmergencySurveyDefinitionList = new Array<EmergencySurveyDefinition>();
    }
}