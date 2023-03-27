//$2A7D8217
import { AdmissionAppointment } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class AdmissionAppointmentFormViewModel extends BaseViewModel {
    public _AdmissionAppointment: AdmissionAppointment = new AdmissionAppointment();
    public Patients: Array<Patient> = new Array<Patient>();
    public AppointmentDefinitions: Array<AppointmentDefinition> = new Array<AppointmentDefinition>();
}
