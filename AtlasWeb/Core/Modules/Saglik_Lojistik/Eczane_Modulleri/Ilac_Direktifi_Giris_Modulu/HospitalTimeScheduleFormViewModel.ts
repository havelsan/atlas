//$B6481080
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { HospitalTimeSchedule, HospitalTimeScheduleDetail } from 'NebulaClient/Model/AtlasClientModel';


export class HospitalTimeScheduleFormViewModel {
    public HospitalTimeSchedule: HospitalTimeSchedule = new HospitalTimeSchedule();
    public HospitalTimeScheduleDetails: Array<HospitalTimeScheduleDetail> = new Array<HospitalTimeScheduleDetail>();
}

export class GetHospitalTimeSchedule_Input {
    public hospitalTimeScheduleID: Guid;
}

export class GetHospitalTimeSchedule_OutPut {
    public hospitalTimeScheduleFormViewModel: HospitalTimeScheduleFormViewModel;
}