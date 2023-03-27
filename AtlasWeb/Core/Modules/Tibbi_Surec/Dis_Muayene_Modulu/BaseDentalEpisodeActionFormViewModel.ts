//$D6482374
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseDentalEpisodeAction } from 'NebulaClient/Model/AtlasClientModel';

export class BaseDentalEpisodeActionFormViewModel extends BaseViewModel {
    public _BaseDentalEpisodeAction: BaseDentalEpisodeAction = new BaseDentalEpisodeAction();
}
