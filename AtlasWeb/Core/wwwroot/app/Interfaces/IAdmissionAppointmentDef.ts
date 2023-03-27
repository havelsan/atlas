import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { IAppointmentDef } from './IAppointmentDef';

export abstract class IAdmissionAppointmentDef extends IAppointmentDef {
    ObjectContext: TTObjectContext;
    PatientName: String;
    PatientSurname: String;
    SelectedPatient: Patient;
}