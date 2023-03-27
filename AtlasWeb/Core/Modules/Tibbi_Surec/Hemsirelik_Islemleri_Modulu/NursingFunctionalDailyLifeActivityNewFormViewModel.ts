//$37FD138F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingDailyLifeActivity } from 'NebulaClient/Model/AtlasClientModel';
import { NursingFunctionalDailyLifeActivity } from 'NebulaClient/Model/AtlasClientModel';
import { DailyLifeActivityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class NursingFunctionalDailyLifeActivityNewFormViewModel extends BaseViewModel {
    @Type(() => NursingDailyLifeActivity)
    public _NursingDailyLifeActivity: NursingDailyLifeActivity = new NursingDailyLifeActivity();
    @Type(() => NursingFunctionalDailyLifeActivity)
    public NursingFunctionalDailyLifeActivityGridList: Array<NursingFunctionalDailyLifeActivity> = new Array<NursingFunctionalDailyLifeActivity>();
    @Type(() => DailyLifeActivityDefinition)
    public DailyLifeActivityDefinitions: Array<DailyLifeActivityDefinition> = new Array<DailyLifeActivityDefinition>();
    @Type(() => DailyLifeActivityDefinition)
    public FunctionalDailyLifeActivityList: Array<DailyLifeActivityDefinition> = new Array<DailyLifeActivityDefinition>();
    @Type(() => Date)
    public QuarantineInPatientDate: Date;
}
