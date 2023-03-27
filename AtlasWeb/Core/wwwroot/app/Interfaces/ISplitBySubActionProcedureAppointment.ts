import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { SubActionProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { IAppointmentDef } from './IAppointmentDef';

export abstract class ISplitBySubActionProcedureAppointment extends IAppointmentDef {
    ObjectContext: TTObjectContext;
    MyEpisodeAction: EpisodeAction;
    MyNewAppointments: Array<Appointment>;
    MySiblingObjectListForAppointment: Array<SubActionProcedure>;
}