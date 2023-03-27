//$A2D6766F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { AudiologyObject } from "NebulaClient/Model/AtlasClientModel";
import { AudiologyDiagnosis } from "NebulaClient/Model/AtlasClientModel";
import { AudiologyDiagnosisDef } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

export class AudiologyFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.AudiologyFormViewModel, Core';
    @Type(() => AudiologyObject)
    public _AudiologyObject: AudiologyObject = new AudiologyObject();
    @Type(() => AudiologyDiagnosis)
    public AudiologyDiagnosisGridList: Array<AudiologyDiagnosis> = new Array<AudiologyDiagnosis>();
    @Type(() => AudiologyDiagnosisDef)
    public AudiologyDiagnosisDefs: Array<AudiologyDiagnosisDef> = new Array<AudiologyDiagnosisDef>();
    
    @Type(() => Object)
    public _selectedDiagnosis: Object;
    @Type(() => AudiologyDiagnosisObject)
    public DiagnosisArray: Array<AudiologyDiagnosisObject> = new Array<AudiologyDiagnosisObject>();

}

export class AudiologyDiagnosisObject {
    @Type(() => Guid)
    public DiagnosisObjectID: Guid;
    @Type(() => Guid)
    public DiagnosisDefObjectID: Guid;
    public Name: string;
 
}