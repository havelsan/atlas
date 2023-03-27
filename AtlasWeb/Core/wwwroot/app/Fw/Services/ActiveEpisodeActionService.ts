import { Injectable } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { IActiveEpisodeActionService } from './IActiveEpisodeActionService';

@Injectable()
export class ActiveEpisodeActionService implements IActiveEpisodeActionService {
    private _activeEpisodeActionID: Guid;

    public get ActiveEpisodeActionID(): Guid {
        return this._activeEpisodeActionID;
    }

    public set ActiveEpisodeActionID(value: Guid) {
        this._activeEpisodeActionID = value;
    }

    private _globalTemporaryParam: Guid;

    public get GlobalTemporaryParam(): any {
        return this._globalTemporaryParam;
    }

    public set GlobalTemporaryParam(value: any) {
        this._globalTemporaryParam = value;
    }

}