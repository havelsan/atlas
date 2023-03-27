//$3AAC8076
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PsychologyBasedObject } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class OldPsychologyObjectFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldPsychologyObjectFormViewModel, Core';

    @Type(() => PsychologyBasedObject)
    public _PsychologyBasedObject: PsychologyBasedObject = new PsychologyBasedObject();

    public DoctorName: string;
    public DoctorStatement: string;
    public ImportantNoteAboutApp: string;
    public InformationFromParent: string;
    public TherapyReport: string;
    public AppliedTest: string;
    public IsAuthorized: Boolean;
}
