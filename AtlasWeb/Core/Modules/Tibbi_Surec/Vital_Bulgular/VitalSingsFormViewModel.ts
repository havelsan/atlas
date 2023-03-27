//$D451BAA2
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";

export class VitalSingsFormViewModel extends BaseViewModel {

    public BloodPressure_Sistolik: string;
    public BloodPressure_Diastolik: string;
    public Pulse_Value: string;
    public Respiration_Value: string;
    public Temperature_Value: string;
    public SPO2_Value: string;
    //@Type(() => Number)
    public Height_Value: number;
    //@Type(() => Number)
    public Weight_Value: number;
    //@Type(() => Number)
    public BMI_Value: number;
    public VitalSignsValues: VitalSignsValues = new VitalSignsValues();


}

export class VitalSignsValues
{
    // Vital Bulgular Normal Değerler

    public Systolic_MaxValue: number;
    public Systolic_MinValue: number;
    public Diastolic_MaxValue: number;
    public Diastolic_MinValue: number;
    public Pulse_MaxValue: number;
    public Pulse_MinValue: number;
    public Respiration_MaxValue: number;
    public Respiration_MinValue: number;
    public Temperature_MaxValue: number;
    public Temperature_MinValue: number;
    public SPO2_MaxValue: number;
    public SPO2_MinValue: number;
    public Height_MaxValue: number;
    public Height_MinValue: number;
    public Weight_MaxValue: number;
    public Weight_MinValue: number;
    public Systolic_MaxWarning: string = "";
    public Systolic_MinWarning: string = "";
    public Diastolic_MaxWarning: string = "";
    public Diastolic_MinWarning: string = "";
    public Pulse_MaxWarning: string = "";
    public Pulse_MinWarning: string = "";
    public Respiration_MaxWarning: string = "";
    public Respiration_MinWarning: string = "";
    public Temperature_MaxWarning: string = "";
    public Temperature_MinWarning: string = "";
    public SPO2_MaxWarning: string = "";
    public SPO2_MinWarning: string = "";
    public Height_MaxWarning: string = "";
    public Height_MinWarning: string = "";
    public Weight_MaxWarning: string = "";
    public Weight_MinWarning: string = "";
}
