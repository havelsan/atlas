//$EC4CFF09
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class BaseNewDoctorExaminationFormViewModel extends BaseViewModel {
    @Type(() => EpisodeAction)
    public _EpisodeAction: EpisodeAction = new EpisodeAction();
    public SpecialityBasedObjectViewModels: Array<any> = new Array<any>();
    public SpecialityBasedObjectList: Array<any> = new Array<any>();
    public ENabizViewModels: Array<any> = new Array<any>();
    public hasSpecialityBasedObject: Boolean;
    public hasWomanSpecialityBasedObject: Boolean;
    public procedureSpecialityName: string;
    
    public hasOpenEpisodeRole: boolean;
    public hasCloseEpisodeRole: boolean;

    @Type(() => Boolean)
    public HasPaidPayerTypeSEPExists: boolean;

    @Type(() => Boolean)
    public IsDischarged: boolean;
}


export class DynamicComponentInfoDVO {
    public ComponentName: string;
    public ModuleName: string;
    public ModulePath: string;
    public objectID: string;
}
