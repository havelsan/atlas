//$53A7A91F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { FollowingPatients } from "NebulaClient/Model/AtlasClientModel";

export class FollowingPatientsFormViewModel extends BaseViewModel {
    public _FollowingPatients: FollowingPatients = new FollowingPatients();
}
