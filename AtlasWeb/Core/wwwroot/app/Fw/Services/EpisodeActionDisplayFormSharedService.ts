import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { EpisodeActionDisplayFormViewModel } from "Modules/Tibbi_Surec/Hasta_Islemi_Goruntuleme/EpisodeActionDisplayFormViewModel";
import { Http } from "@angular/http";

@Injectable()
export class EpisodeActionDisplayFormSharedService {

    private _episodeActionDisplayFromViewModel = new ReplaySubject<EpisodeActionDisplayFormViewModel>(1);
    public EpisodeActionDisplayItem = this._episodeActionDisplayFromViewModel.asObservable();


    constructor(protected http: Http) {

    }

    openEpisodeActionDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        let episodeActionDisplayFromViewModel: EpisodeActionDisplayFormViewModel = new EpisodeActionDisplayFormViewModel();
        episodeActionDisplayFromViewModel.ObjectID = objectID;
        episodeActionDisplayFromViewModel.ObjectDefName = objectDefName;
        episodeActionDisplayFromViewModel.FormDefID = formDefId;
        episodeActionDisplayFromViewModel.InputParam = inputparam;
        this._episodeActionDisplayFromViewModel.next(episodeActionDisplayFromViewModel);
    }


}