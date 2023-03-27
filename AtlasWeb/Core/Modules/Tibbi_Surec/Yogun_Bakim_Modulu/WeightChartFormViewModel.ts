//$7FE304F0
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { WeightChart } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class WeightChartFormViewModel extends BaseViewModel {
    @Type(() => WeightChart)
    public _WeightChart: WeightChart = new WeightChart();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
