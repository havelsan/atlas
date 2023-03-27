//$6612E97E
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { EmergencyIntervention } from 'NebulaClient/Model/AtlasClientModel';
import { Allergy } from 'NebulaClient/Model/AtlasClientModel';
import { Vaccination } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTRIAJKODU } from 'NebulaClient/Model/AtlasClientModel';
import { PatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class EmergencyTriageFormViewModel extends BaseViewModel {
    @Type(() => EmergencyIntervention)
    public _EmergencyIntervention: EmergencyIntervention = new EmergencyIntervention();
    @Type('Allergy')
    public ttgrid1GridList: Array<Allergy> = new Array<Allergy>();
    @Type('Vaccination')
    public ttgrid2GridList: Array<Vaccination> = new Array<Vaccination>();
    @Type('SKRSTRIAJKODU')
    public SKRSTRIAJKODUs: Array<SKRSTRIAJKODU> = new Array<SKRSTRIAJKODU>();
    @Type(() => PatientAdmission)
    public PatientAdmission: PatientAdmission = new PatientAdmission();
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
}
