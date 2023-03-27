import { Injectable } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ReplaySubject } from 'rxjs';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { IActiveEpisodeService } from './IActiveEpisodeService';
import { bufferCount } from 'rxjs/operators';

@Injectable()
export class ActiveEpisodeService implements IActiveEpisodeService {

    private _activeEpisodeIDList: Array<Guid>;
    private _activeEpisodeID: Guid;
    private _activeEpisode: Episode = new Episode();

    // En son toplam 25 episode tutulacak
    private readonly MaxBufferedItemCount = 25;

    private _activeEpisodeSource = new ReplaySubject<Guid>(this.MaxBufferedItemCount);
    private _activeEpisodeChanged = new ReplaySubject<Episode>(1);

    public ActiveEpisodeSource = this._activeEpisodeSource.asObservable();
    public ActiveEpisodeChanged = this._activeEpisodeChanged.asObservable();

    constructor() {
        this._activeEpisodeIDList = new Array<Guid>();
        this.subscribe();
    }

    public setActiveEpisode(objectID: Guid): void {
        if (objectID.valueOf == Guid.Empty.valueOf) {
            this._activeEpisodeID = Guid.Empty;
            this._activeEpisode = null;
        }
        else
            this._activeEpisodeSource.next(objectID);
    }

    public get ActiveEpisode(): Episode {
        return this._activeEpisode;
    }

    public get ActiveEpisodeIDList(): Array<Guid> {
        return this._activeEpisodeIDList;
    }

    public get ActiveEpisodeID(): Guid {
        return this._activeEpisodeID;
    }

    private loadActiveEpisode(objectID: Guid) {
        let that = this;
        ServiceLocator.getObjectWithDefName<Episode>(objectID, 'Episode')
            .then(ep => {
                that._activeEpisode = ep;
                that._activeEpisodeChanged.next(ep);
            });
    }

    private subscribe() {
        let that = this;
        this._activeEpisodeSource.subscribe(objectID => {
            that._activeEpisodeID = objectID;
            that.loadActiveEpisode(objectID);
            that._activeEpisodeIDList = new Array<Guid>();
            const bufferedObservable = this.ActiveEpisodeSource.pipe(bufferCount(1));
            bufferedObservable.subscribe(z => {
                z.forEach(item => that._activeEpisodeIDList.push(item));
            }).unsubscribe();
        });
    }
}
