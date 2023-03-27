import { AppointmentCarrier } from 'NebulaClient/Model/AtlasClientModel';
import { IBaseAppointmentDef } from './IBaseAppointmentDef';

export abstract class IAppointmentDef extends IBaseAppointmentDef {
    AppointmentCarrierList: Array<AppointmentCarrier>;
}