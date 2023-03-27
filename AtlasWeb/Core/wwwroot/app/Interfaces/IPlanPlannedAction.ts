import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { PlannedAction } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { IAppointmentDef } from './IAppointmentDef';

export abstract class IPlanPlannedAction extends IAppointmentDef {
    ObjectContext: TTObjectContext;
    MyNewAppointments: Array<Appointment>;
    MyPlannedAction: PlannedAction;
    MySiblingObjectListForAppointment: Array<PlannedAction>;
}