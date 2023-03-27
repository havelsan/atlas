import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Observable } from 'rxjs';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';

export abstract class IActiveEpisodeService {
    ActiveEpisodeID: Guid;
    ActiveEpisodeIDList: Array<Guid>;
    setActiveEpisode: (objectID: Guid) => void;
    ActiveEpisodeChanged: Observable<Episode>;
}
