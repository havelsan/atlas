import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { EpisodeActionWorkListSharedItemModel } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";
import { Http } from "@angular/http";
import { Observable } from 'rxjs';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DynamicComponentInfo } from '../Models/DynamicComponentInfo';

@Injectable()
export class EpisodeActionWorkListSharedService {

    private _episodeActionWorkListItem = new Subject<EpisodeActionWorkListSharedItemModel>();
    public EpisodeActionWorkListItem = this._episodeActionWorkListItem.asObservable();
    
    private _refreshEpisodeActionWorkList = new Subject<boolean>();
    public RefreshEpisodeActionWorkList: Observable<boolean> = this._refreshEpisodeActionWorkList.asObservable();

    private _refreshHCExaminationForm = new Subject<DynamicComponentInfo>();
    public RefreshHCExaminationForm: Observable<DynamicComponentInfo> = this._refreshHCExaminationForm.asObservable();

    constructor(protected http: Http) {

    }

    openLikeWorkListDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        let episodeActionWorkListSharedItemModel: EpisodeActionWorkListSharedItemModel = new EpisodeActionWorkListSharedItemModel();
        episodeActionWorkListSharedItemModel.ObjectID = objectID;
        episodeActionWorkListSharedItemModel.ObjectDefName = objectDefName;
        episodeActionWorkListSharedItemModel.FormDefID = formDefId;
        episodeActionWorkListSharedItemModel.InputParam = inputparam;
        this._episodeActionWorkListItem.next(episodeActionWorkListSharedItemModel);
    }

    refreshWorklist(isRefresh: boolean) {
        if (!isRefresh)
            return;
        this._refreshEpisodeActionWorkList.next(isRefresh);
    }

    refreshHCExaminationForm(compInfo : DynamicComponentInfo) {
        // this._refreshHCExaminationForm.next(Guid.newGuid().id);
        
        this._refreshHCExaminationForm.next(compInfo);            
    }
}