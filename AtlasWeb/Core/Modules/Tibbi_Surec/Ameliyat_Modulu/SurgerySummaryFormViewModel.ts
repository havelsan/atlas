//$6747A6FD
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SurgeryProcedureFormViewModel } from './SurgeryProcedureFormViewModel';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class SurgerySummaryFormViewModel extends BaseViewModel  {
    @Type(() => EpisodeAction)
    public _EpisodeAction: EpisodeAction;
    public DepartmentName: string;
    public ResponsibleDoctorName: string;
    @Type(() => Object)
    public SurgeryReport: Object;
    @Type(() => SurgeryProcedureFormViewModel)
    public SurgeryProcedureFormViewModelList: Array<SurgeryProcedureFormViewModel> = new Array<SurgeryProcedureFormViewModel>();
}
