import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { SubactionProcedureFlowable } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { BaseAction } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Injectable } from '@angular/core';

@Injectable()
export class EpisodeActionHelper {

    constructor(private http: NeHttpService) {
    }

    public getNewEpisodeAction(objectDefID: Guid, episodeID: Guid, currentStateDefID: Guid): Promise<EpisodeAction> {
        let apiUrl = `/api/EpisodeActionHelper/GetNewEpisodeAction/${objectDefID}/${episodeID}/${currentStateDefID}`;
        return new Promise<EpisodeAction>((resolve, reject) => {
            this.http.get<DefaultEpisodeActionViewModel>(apiUrl).then(result => {
                let episodeAction: EpisodeAction = EpisodeActionHelper.arrangeEpisodeActionByDefaultEpisodeActionViewModel(result);
                resolve(episodeAction);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public getNewSubactionProcedureFlowable(objectDefID: Guid, episodeID: Guid, currentStateDefID: Guid): Promise<SubactionProcedureFlowable> {
        let apiUrl = `/api/EpisodeActionHelper/GetNewSubactionProcedureFlowable/${objectDefID}/${episodeID}/${currentStateDefID}`;
        return new Promise<SubactionProcedureFlowable>((resolve, reject) => {
            this.http.get<DefaultEpisodeActionViewModel>(apiUrl).then(result => {
                let subactionProcedureFlowable: SubactionProcedureFlowable = EpisodeActionHelper.arrangeSubactionProcedureFlowableByDefaultEpisodeActionViewModel(result);
                resolve(subactionProcedureFlowable);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public getNewEpisodeActionByMasterEpisodeAction(objectDefID: Guid, masterEpisodeAction: EpisodeAction, currentStateDefID: Guid): Promise<EpisodeAction> {
        //let apiUrl = '/api/EpisodeActionHelper/GetNewEpisodeActionByMasterEpisodeAction?objectDefID' + objectDefID.toString() + '&currentStateDefID' + currentStateDefID.toString();
        let apiUrl = `/api/EpisodeActionHelper/GetNewEpisodeActionByMasterEpisodeAction/${objectDefID}/${currentStateDefID}`;
       // let body = JSON.stringify(masterEpisodeAction);
        return new Promise<EpisodeAction>((resolve, reject) => {
            this.http.post<DefaultEpisodeActionViewModel>(apiUrl, masterEpisodeAction).then(result => {
                let episodeAction: EpisodeAction = EpisodeActionHelper.arrangeEpisodeActionByDefaultEpisodeActionViewModel(result);
                resolve(episodeAction);
            }).catch(err => {
                reject(err);
            });
        });

    }


    public static arrangeEpisodeActionByDefaultEpisodeActionViewModel(defaultEpisodeActionViewModel: DefaultEpisodeActionViewModel): any {
        let episodeAction: EpisodeAction = null;
        if (defaultEpisodeActionViewModel['_EpisodeAction'] != null) {
            episodeAction = defaultEpisodeActionViewModel['_EpisodeAction'];
            if (defaultEpisodeActionViewModel['_Episode'] != null)
                episodeAction.Episode = defaultEpisodeActionViewModel['_Episode'];
            if (defaultEpisodeActionViewModel['_MasterResource'] != null)
                episodeAction.MasterResource = defaultEpisodeActionViewModel['_MasterResource'];
            if (defaultEpisodeActionViewModel['_FromResource'] != null)
                episodeAction.FromResource = defaultEpisodeActionViewModel['_FromResource'];
            if (defaultEpisodeActionViewModel['_SecondaryMasterResource'] != null)
                episodeAction.SecondaryMasterResource = defaultEpisodeActionViewModel['_SecondaryMasterResource'];
            if (defaultEpisodeActionViewModel['_ProcedureSpeciality'] != null)
                episodeAction.ProcedureSpeciality = defaultEpisodeActionViewModel['_ProcedureSpeciality'];
            if (defaultEpisodeActionViewModel['_ProcedureDoctor'] != null)
                episodeAction.ProcedureDoctor = defaultEpisodeActionViewModel['_ProcedureDoctor'];
            if (defaultEpisodeActionViewModel['_SubEpisode'] != null)
                episodeAction.SubEpisode = defaultEpisodeActionViewModel['_SubEpisode'];
            if (defaultEpisodeActionViewModel['_MasterAction'] != null)
                episodeAction.MasterAction = defaultEpisodeActionViewModel['_MasterAction'];
        }
        return episodeAction;
    }

    public static arrangeSubactionProcedureFlowableByDefaultEpisodeActionViewModel(defaultEpisodeActionViewModel: DefaultEpisodeActionViewModel): any {
        let subactionProcedureFlowable: SubactionProcedureFlowable;
        if (defaultEpisodeActionViewModel['_SubactionProcedureFlowable'] != null) {
            subactionProcedureFlowable = defaultEpisodeActionViewModel['_SubactionProcedureFlowable'];
            if (defaultEpisodeActionViewModel['_Episode'] != null)
                subactionProcedureFlowable.Episode = defaultEpisodeActionViewModel['_Episode'];
            if (defaultEpisodeActionViewModel['_MasterResource'] != null)
                subactionProcedureFlowable.MasterResource = defaultEpisodeActionViewModel['_MasterResource'];
            if (defaultEpisodeActionViewModel['_FromResource'] != null)
                subactionProcedureFlowable.FromResource = defaultEpisodeActionViewModel['_FromResource'];
            if (defaultEpisodeActionViewModel['_SecondaryMasterResource'] != null)
                subactionProcedureFlowable.SecondaryMasterResource = defaultEpisodeActionViewModel['_SecondaryMasterResource'];
            if (defaultEpisodeActionViewModel['_ProcedureSpeciality'] != null)
                subactionProcedureFlowable.ProcedureSpeciality = defaultEpisodeActionViewModel['_ProcedureSpeciality'];
            if (defaultEpisodeActionViewModel['_ProcedureDoctor'] != null)
                subactionProcedureFlowable.ProcedureDoctor = defaultEpisodeActionViewModel['_ProcedureDoctor'];
            if (defaultEpisodeActionViewModel['_SubEpisode'] != null)
                subactionProcedureFlowable.SubEpisode = defaultEpisodeActionViewModel['_SubEpisode'];
        }
        return subactionProcedureFlowable;
    }




}

export class DefaultEpisodeActionViewModel {
    public _EpisodeAction: EpisodeAction;
    public _SubactionProcedureFlowable: SubactionProcedureFlowable;
    public _Episode: Episode;
    public _MasterResource: ResSection;
    public _FromResource: ResSection;
    public _SecondaryMasterResource: ResSection;
    public _ProcedureSpeciality: SpecialityDefinition;
    public _ProcedureDoctor: ResUser;
    public _SubEpisode: SubEpisode;
    public _MasterAction: BaseAction;
}