//$AD2A1724
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingPupilSymptoms } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class NursingPupilSymptomsFormViewModel extends BaseViewModel{
    @Type(() => NursingPupilSymptoms)
    public _NursingPupilSymptoms: NursingPupilSymptoms = new NursingPupilSymptoms();
}
