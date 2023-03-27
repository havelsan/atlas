//$84052619
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChildGrowthVisits } from 'NebulaClient/Model/AtlasClientModel';

export class OldVisitDetailsFormViewModel extends BaseViewModel {
    public _ChildGrowthVisits: ChildGrowthVisits = new ChildGrowthVisits();
}
