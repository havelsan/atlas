import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Observable } from 'rxjs';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';

export abstract class IActivePatientService {
    ActivePatientID: Guid;
    ActivePatientIDList: Array<Guid>;
    setActivePatient: (objectID: Guid) => void;
    ActivePatientChanged: Observable<Patient>;
}
